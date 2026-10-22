using System;
using System.Collections.Generic;
using Ascend.Core;
using UnityEngine;

namespace Ascend.Game
{
    /// <summary>
    /// Ring 0 basic attacks (combat.md §4): runs the class's basic chain (Core AttackChain), soft-locks onto the
    /// nearest monster in front, lunges during startup, and on the hit frame damages every monster in the arc
    /// using the shared DamageCalculator, then triggers hit-stop by weight. Input-agnostic like PlayerMotor.
    /// </summary>
    [RequireComponent(typeof(PlayerMotor))]
    public sealed class PlayerCombat : MonoBehaviour
    {
        /// <summary>Poise damage per point of hit power (placeholder until weapons carry their own value).</summary>
        const double PoisePerPower = 10;

        [SerializeField] string classId = "cls_swordsman";
        [SerializeField] int level = 1;
        [SerializeField] int gearAtk = 8;   // Guild-issue sword until the item system is wired in
        [SerializeField] int gearDef = 3;
        [SerializeField] ulong rngSeed = 1;

        PlayerMotor _motor;
        AttackChain _chain;
        DamageCalculator _calc;
        IRandom _rng;
        CombatTuning _tuning;
        int _startedIndex = -1;
        AttackPhase _lastPhase;
        readonly Collider[] _overlap = new Collider[32];
        readonly HashSet<MonsterDummy> _struck = new HashSet<MonsterDummy>();

        public AttackChain Chain => _chain;
        public DerivedStats Stats { get; private set; }
        public bool IsAttacking => _chain != null && _chain.IsBusy;

        /// <summary>Raised for every monster a hit lands on.</summary>
        public event Action<MonsterDummy, DamageResult> HitLanded;

        void Awake()
        {
            _motor = GetComponent<PlayerMotor>();
            var db = AscendData.Db;
            _tuning = db.Tuning;
            var cls = db.Classes[classId];
            Stats = PlayerStats.Derive(PlayerStats.Primary(cls, level, db.Progression), level, db.Progression, new GearBonus { Atk = gearAtk, Def = gearDef });
            var basic = cls.Kit.Find(k => k.Slot == "basic") ?? throw new InvalidOperationException($"{classId} has no basic chain");
            _chain = new AttackChain(basic, _tuning);
            _calc = new DamageCalculator(_tuning.Damage);
            _rng = new DeterministicRandom(rngSeed);
        }

        /// <summary>Attack button. Ignored mid-dodge.</summary>
        public void Attack()
        {
            if (_motor.IsDodging) return;
            _chain.Press();
        }

        /// <summary>Called before a dodge: true if the current attack (if any) allows it.</summary>
        public bool TryCancelForDodge() => !_chain.IsBusy || _chain.Cancel();

        public void Tick(float dt)
        {
            var landed = _chain.Tick(dt);
            bool newHit = _chain.Phase == AttackPhase.Startup && (_chain.HitIndex != _startedIndex || _lastPhase != AttackPhase.Startup);
            if (newHit) { _startedIndex = _chain.HitIndex; FaceTarget(); }
            if (_chain.Phase == AttackPhase.Startup)
            {
                var t = _chain.TimingOf(_chain.Current);
                if (t.StartupSec > 0) _motor.Nudge(transform.forward * (float)(_tuning.AttackTiming.LungeM * dt / t.StartupSec));
            }
            if (landed != null) Strike(landed);
            if (_chain.Phase == AttackPhase.Idle) _startedIndex = -1;
            _lastPhase = _chain.Phase;
        }

        /// <summary>Soft lock: turn toward the nearest live monster within reach × 2 and the soft-lock cone.</summary>
        void FaceTarget()
        {
            MonsterDummy best = null;
            float bestDist = float.MaxValue, reach = (float)_tuning.AttackTiming.ReachM * 2f;
            int n = Physics.OverlapSphereNonAlloc(transform.position, reach, _overlap, ~0, QueryTriggerInteraction.Ignore);
            for (int i = 0; i < n; i++)
            {
                var m = _overlap[i].GetComponentInParent<MonsterDummy>();
                if (m == null || m.IsDead) continue;
                Vector3 to = m.transform.position - transform.position; to.y = 0;
                if (Vector3.Angle(transform.forward, to) > _tuning.SoftLockAngleDeg) continue;
                if (to.magnitude < bestDist) { bestDist = to.magnitude; best = m; }
            }
            if (best == null) return;
            Vector3 dir = best.transform.position - transform.position; dir.y = 0;
            if (dir.sqrMagnitude > 1e-4f) transform.rotation = Quaternion.LookRotation(dir);
        }

        void Strike(SkillHit hit)
        {
            var weight = AttackChain.WeightOf(hit);
            float reach = (float)_tuning.AttackTiming.ReachM, halfArc = (float)_tuning.AttackTiming.ArcDeg * 0.5f;
            Vector3 origin = transform.position + Vector3.up * 0.8f;
            int n = Physics.OverlapSphereNonAlloc(origin, reach, _overlap, ~0, QueryTriggerInteraction.Ignore);
            _struck.Clear();
            for (int i = 0; i < n; i++)
            {
                var m = _overlap[i].GetComponentInParent<MonsterDummy>();
                if (m == null || m.IsDead || !_struck.Add(m)) continue;
                Vector3 to = _overlap[i].ClosestPoint(origin) - transform.position; to.y = 0;
                if (to.sqrMagnitude > 0.01f && Vector3.Angle(transform.forward, to) > halfArc) continue;
                var result = _calc.Compute(new DamageInput
                {
                    Kind = DamageKind.Physical, Attack = Stats.Atk, Defense = m.Defense, Power = hit.Power,
                    DefenderWeakness = m.Weakness, CritChance = Stats.CritChance,
                }, _rng);
                m.TakeHit(result.Amount, weight, transform.position, hit.Power * PoisePerPower);
                HitLanded?.Invoke(m, result);
            }
            if (_struck.Count > 0) HitStop.Trigger(HitstopFor(weight));
        }

        float HitstopFor(HitWeight w)
        {
            var h = _tuning.Hitstop;
            switch (w)
            {
                case HitWeight.Medium: return (float)h.Medium;
                case HitWeight.Heavy: return (float)h.Heavy;
                case HitWeight.Launch: return (float)h.Launch;
                case HitWeight.Ultimate: return (float)h.Ultimate;
                default: return (float)h.Light;
            }
        }
    }
}
