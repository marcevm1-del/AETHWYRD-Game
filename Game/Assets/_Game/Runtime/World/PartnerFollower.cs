using System.Linq;
using Ascend.Core;
using UnityEngine;

namespace Ascend.Game
{
    /// <summary>
    /// A tamed partner in the field (systems.md §7.2, Striker role for Ring 0): it trails you in formation and joins in
    /// on monsters near you, hitting with its species' ATK every attack interval. Enemies don't target partners yet,
    /// and partners don't die; they rest at full health between fights.
    /// </summary>
    [RequireComponent(typeof(MonsterDummy))]
    public sealed class PartnerFollower : MonoBehaviour
    {
        public const float FollowDistance = 2.5f, EngageRange = 8f, AttackInterval = 1.2f, ReachM = 1.4f;

        MonsterDummy _body;
        Transform _player;
        float _speed, _cooldown;
        int _atk;

        public int Slot { get; set; }
        public MonsterDummy Target { get; private set; }
        public int Hits { get; private set; }

        void Awake()
        {
            _body = GetComponent<MonsterDummy>();
            var db = AscendData.Db;
            _speed = db.Motion.TryGetValue(_body.SpeciesId, out var m) ? Mathf.Max(3f, (float)m.NavAgent.Speed) : 4f;
            _atk = db.Species.TryGetValue(_body.SpeciesId, out var s) ? Mathf.Max(1, s.Stats.Atk) : 5;
        }

        void Update()
        {
            float dt = Time.deltaTime;
            if (dt <= 0f) return;
            if (_player == null) { var p = FindFirstObjectByType<PlayerCombat>(); if (p == null) return; _player = p.transform; }
            _cooldown -= dt;

            if (Target == null || Target.IsDead || Flat(Target.transform.position - _player.position).magnitude > EngageRange * 1.5f) Target = PickTarget();
            Vector3 goal;
            if (Target != null)
            {
                Vector3 to = Flat(Target.transform.position - transform.position);
                if (to.magnitude <= ReachM)
                {
                    Face(to, dt);
                    if (_cooldown <= 0f) { Strike(); _cooldown = AttackInterval; }
                    return;
                }
                goal = Target.transform.position;
            }
            else
            {
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

        MonsterDummy PickTarget() => FindObjectsByType<MonsterDummy>(FindObjectsSortMode.None)
            .Where(m => m != null && !m.IsDead && !m.IsPartner && Flat(m.transform.position - _player.position).magnitude <= EngageRange)
            .OrderBy(m => Flat(m.transform.position - transform.position).sqrMagnitude).FirstOrDefault();

        void Strike()
        {
            Hits++;
            Target.TakeHit(_atk, HitWeight.Light, transform.position, 2);
        }

        void Face(Vector3 dir, float dt)
        {
            if (dir.sqrMagnitude > 1e-4f) transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(dir), 540f * dt);
        }

        public void Warp(Vector3 at) => transform.position = new Vector3(at.x, transform.position.y, at.z);

        static Vector3 Flat(Vector3 v) { v.y = 0; return v; }
    }
}
