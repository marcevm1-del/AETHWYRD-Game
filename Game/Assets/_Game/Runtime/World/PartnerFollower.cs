using System.Collections.Generic;
using System.Linq;
using Ascend.Core;
using UnityEngine;

namespace Ascend.Game
{
    /// <summary>
    /// A tamed partner in the field (systems.md §7.2). It trails you in formation and joins in on monsters near you,
    /// hitting with its species' ATK. Its role, from its behaviour, adds one thing:
    ///   Striker  — just fights        Vanguard — monsters close to it turn on it instead of you
    ///   Support  — heals you a little while you're hurt        Scout — calls out monsters ahead before they find you
    /// Monsters can knock a partner out; it recovers after a short rest (partners never die). Victories you share
    /// raise its Bond (Core Partners.Assist), which unlocks evolution at Bond 5.
    /// </summary>
    [RequireComponent(typeof(MonsterDummy))]
    public sealed class PartnerFollower : MonoBehaviour
    {
        public const float FollowDistance = 2.5f, EngageRange = 8f, AttackInterval = 1.2f, ReachM = 1.4f, ScoutRange = 18f;

        static readonly List<PartnerFollower> _active = new List<PartnerFollower>();
        /// <summary>Partners in the world (monster AI checks these for Vanguards and attackers).</summary>
        public static IReadOnlyList<PartnerFollower> ActiveFollowers => _active;

        MonsterDummy _body;
        Transform _player;
        PlayerDefense _defense;
        float _speed, _cooldown, _knockedOutUntil = -1f, _nextHeal, _nextScout;
        int _atk;
        readonly HashSet<MonsterDummy> _foughtWith = new HashSet<MonsterDummy>();
        readonly HashSet<MonsterDummy> _spotted = new HashSet<MonsterDummy>();

        public int Slot { get; set; }
        /// <summary>The current order (Follow / Hold / Focus), limited to what its species can learn.</summary>
        public PartnerOrder Order { get; private set; } = PartnerOrder.Follow;
        Vector3 _holdAt;
        public const float GuardRadius = 5f;

        /// <summary>Gives an order; returns the one it actually follows (Follow if it can't learn this one).</summary>
        public PartnerOrder Command(PartnerOrder order)
        {
            AscendData.Db.Species.TryGetValue(_body.SpeciesId, out var s);
            Order = Partners.OrdersFor(s, AscendData.Db.World.Taming).Contains(order) ? order : PartnerOrder.Follow;
            if (Order == PartnerOrder.Hold) _holdAt = transform.position;
            Target = null;
            return Order;
        }
        /// <summary>Stat multiplier from your level (Core Partners.LevelFactor); set when it joins and on your level-ups.</summary>
        public double LevelFactor { get; private set; } = 1;

        public void SetLevel(int playerLevel)
        {
            AscendData.Db.Species.TryGetValue(_body.SpeciesId, out var s);
            LevelFactor = Partners.LevelFactor(s, playerLevel, AscendData.Db.World.Taming);
            if (!_body.IsDead) _body.ScaleMaxHp(LevelFactor);
        }
        public PartnerData Data { get; set; }
        public PartnerRole Role { get; private set; }
        public MonsterDummy Body => _body;
        public MonsterDummy Target { get; private set; }
        public int Hits { get; private set; }
        public bool KnockedOut => _body != null && _body.IsDead;
        /// <summary>Raised when a fight it shared ends in a win (the taming component turns these into Bond).</summary>
        public event System.Action<PartnerFollower> SharedVictory;
        /// <summary>Now and then, when nothing's going on, it comes over to nuzzle you (after RimWorld's pets). A shared moment.</summary>
        public event System.Action<PartnerFollower> Nuzzled;
        float _nextNuzzle = -1f;
        public int Nuzzles { get; private set; }

        /// <summary>Picks the next nuzzle time: exponential around the tuning's mean (so it feels spontaneous).</summary>
        void ScheduleNuzzle() => _nextNuzzle = Time.time + Mathf.Max(30f, -Mathf.Log(Mathf.Max(0.001f, Random.value)) * (float)T.NuzzleEveryMinutes * 60f);

        /// <summary>For tests and playtests: nuzzle on the next quiet frame.</summary>
        public void NuzzleSoon() => _nextNuzzle = 0f;

        void Awake()
        {
            _body = GetComponent<MonsterDummy>();
            var db = AscendData.Db;
            _speed = db.Motion.TryGetValue(_body.SpeciesId, out var m) ? Mathf.Max(3f, (float)m.NavAgent.Speed) : 4f;
            db.Species.TryGetValue(_body.SpeciesId, out var s);
            _atk = s != null ? Mathf.Max(1, s.Stats.Atk) : 5;
            Role = Partners.RoleOf(s);
        }

        void OnEnable() { if (!_active.Contains(this)) _active.Add(this); }
        void OnDisable() => _active.Remove(this);

        static TamingTuning T => AscendData.Db.World.Taming;

        void Update()
        {
            float dt = Time.deltaTime;
            if (dt <= 0f) return;
            if (_player == null)
            {
                var p = FindFirstObjectByType<PlayerCombat>(); if (p == null) return;
                _player = p.transform; _defense = p.GetComponent<PlayerDefense>();
            }
            if (KnockedOut) { KnockedOutStep(); return; }
            _cooldown -= dt;
            CheckVictories();
            RoleStep();

            if (Order == PartnerOrder.Focus)
            {
                var lockOn = _player.GetComponent<PlayerCombat>().LockTarget;
                Target = lockOn != null && !lockOn.IsDead && !lockOn.IsPartner ? lockOn : null;
            }
            else if (Target == null || Target.IsDead || Target.IsPartner || Flat(Target.transform.position - Anchor).magnitude > Reach * 1.5f) Target = PickTarget();
            Vector3 goal;
            if (Target != null)
            {
                _foughtWith.Add(Target);
                Vector3 to = Flat(Target.transform.position - transform.position);
                if (to.magnitude <= ReachM)
                {
                    Face(to, dt);
                    if (_cooldown <= 0f) { Hits++; Target.TakeHit(Mathf.Max(1, Mathf.RoundToInt((float)(_atk * LevelFactor))), HitWeight.Light, transform.position, 2); _cooldown = AttackInterval; }
                    return;
                }
                goal = Target.transform.position;
            }
            else if (Order == PartnerOrder.Hold)
            {
                goal = _holdAt; // guard the spot
                if (Flat(goal - transform.position).magnitude < 0.3f) return;
            }
            else
            {
                if (_nextNuzzle < 0f) ScheduleNuzzle();
                if (Time.time >= _nextNuzzle && Flat(_player.position - transform.position).magnitude < 6f)
                {
                    Nuzzles++;
                    ScheduleNuzzle();
                    Toast($"{NameOf()} nuzzles you.", 3f);
                    Nuzzled?.Invoke(this);
                }
                // Formation behind you: slot 0 behind-left, 1 behind-right, 2 straight behind.
                Vector3 back = -_player.forward, side = _player.right * (Slot == 0 ? -1.2f : Slot == 1 ? 1.2f : 0f);
                goal = _player.position + back * FollowDistance + side;
                if (Flat(goal - transform.position).magnitude < 0.4f) return;
                if (Flat(_player.position - transform.position).magnitude > 30f) { Warp(goal); return; } // left far behind
            }
            Vector3 dir = Flat(goal - transform.position);
            float step = Mathf.Min(dir.magnitude, _speed * dt);
            transform.position += dir.normalized * step;
            Face(dir, dt);
        }

        void KnockedOutStep()
        {
            if (_knockedOutUntil < 0f)
            {
                _knockedOutUntil = Time.time + (float)T.KnockedOutSec;
                Toast($"{NameOf()} is knocked out! It'll be back after a rest.");
                Target = null;
            }
            else if (Time.time >= _knockedOutUntil)
            {
                _knockedOutUntil = -1f;
                _body.Revive();
                _body.ScaleMaxHp(LevelFactor);
                Warp(_player.position - _player.forward * FollowDistance);
                Toast($"{NameOf()} is back on its feet.");
            }
        }

        /// <summary>A monster it fought fell: a shared victory.</summary>
        void CheckVictories()
        {
            foreach (var m in _foughtWith.ToList())
            {
                if (m == null) { _foughtWith.Remove(m); continue; }
                if (!m.IsDead) continue;
                _foughtWith.Remove(m);
                SharedVictory?.Invoke(this);
            }
        }

        void RoleStep()
        {
            if (Role == PartnerRole.Support && _defense != null && !_defense.IsDead && Time.time >= _nextHeal && _defense.Hp < _defense.MaxHp * 0.7f)
            {
                _nextHeal = Time.time + (float)T.SupportHealEverySec;
                int amount = Mathf.Max(1, Mathf.RoundToInt(_defense.MaxHp * (float)T.SupportHealFraction));
                _defense.Heal(amount);
                Toast($"{NameOf()} soothes you: +{amount} HP", 2f);
            }
            if (Role == PartnerRole.Scout && Time.time >= _nextScout)
            {
                _nextScout = Time.time + 1f;
                foreach (var m in FindObjectsByType<MonsterDummy>(FindObjectsSortMode.None))
                {
                    if (m == null || m.IsDead || m.IsPartner || _spotted.Contains(m)) continue;
                    float d = Flat(m.transform.position - _player.position).magnitude;
                    if (d > ScoutRange || d < EngageRange) continue;
                    _spotted.Add(m);
                    string what = AscendData.Db.Species.TryGetValue(m.SpeciesId, out var s) ? s.Name : m.SpeciesId;
                    Toast($"{NameOf()} spots a {what} ahead ({d:0} m).", 3f);
                    break; // one call-out a second
                }
            }
        }

        /// <summary>What it watches over: you, or the spot it holds.</summary>
        Vector3 Anchor => Order == PartnerOrder.Hold ? _holdAt : _player.position;
        float Reach => Order == PartnerOrder.Hold ? GuardRadius : EngageRange;

        MonsterDummy PickTarget() => FindObjectsByType<MonsterDummy>(FindObjectsSortMode.None)
            .Where(m => m != null && !m.IsDead && !m.IsPartner && Flat(m.transform.position - Anchor).magnitude <= Reach)
            .OrderBy(m => Flat(m.transform.position - transform.position).sqrMagnitude).FirstOrDefault();

        void Face(Vector3 dir, float dt)
        {
            if (dir.sqrMagnitude > 1e-4f) transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(dir), 540f * dt);
        }

        public void Warp(Vector3 at) => transform.position = new Vector3(at.x, transform.position.y, at.z);

        string NameOf() => Data != null && !string.IsNullOrEmpty(Data.Name) ? Data.Name : (AscendData.Db.Species.TryGetValue(_body.SpeciesId, out var s) ? s.Name : "Your partner");

        static Vector3 Flat(Vector3 v) { v.y = 0; return v; }

        static void Toast(string text, float seconds = 4f)
        {
            var inv = FindFirstObjectByType<PlayerInventory>();
            if (inv != null) inv.Toast(text, seconds);
        }
    }
}
