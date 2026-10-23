using System;
using System.Collections.Generic;
using Ascend.Core;
using UnityEngine;

namespace Ascend.Game
{
    /// <summary>
    /// Ring 0 attacks (combat.md §4): the class's basic chain (Core AttackChain), the heavy (tap or hold to charge,
    /// Core ChargeMeter) and the riposte after a parry. Soft-locks onto the nearest monster in front, lunges during
    /// startup, and on the hit frame damages every monster in the arc with the shared DamageCalculator, then plays
    /// hit-stop, camera shake and damage numbers by weight. Input-agnostic like PlayerMotor.
    /// </summary>
    [RequireComponent(typeof(PlayerMotor))]
    public sealed class PlayerCombat : MonoBehaviour
    {
        /// <summary>Poise damage per point of hit power (placeholder until weapons carry their own value).</summary>
        const double PoisePerPower = 10;
        /// <summary>Heavy power when the class has no single-hit heavy skill in its kit.</summary>
        const double DefaultHeavyPower = 1.8;
        const double DefaultRipostePower = 2.0;

        [SerializeField] string classId = "cls_swordsman";
        [SerializeField] int level = 1;
        [SerializeField] int gearAtk = 8;   // Guild-issue sword until the item system is wired in
        [SerializeField] int gearDef = 3;
        [SerializeField] ulong rngSeed = 1;

        PlayerMotor _motor;
        ClassData _class;
        AttackChain _chain, _special;
        ChargeMeter _charge;
        DamageCalculator _calc;
        IRandom _rng;
        CombatTuning _tuning;
        int _startedIndex = -1;
        AttackPhase _lastPhase;
        float _specialHitstop = -1f, _riposteUntil = -1f;
        double _specialPoiseMult = 1;
        readonly Collider[] _overlap = new Collider[32];
        readonly HashSet<MonsterDummy> _struck = new HashSet<MonsterDummy>();

        public AttackChain Chain => _chain;
        public ChargeMeter Charge => _charge;
        public DerivedStats Stats { get; private set; }
        public bool IsCharging => _charge != null && _charge.Charging;
        public bool IsAttacking => (_chain != null && _chain.IsBusy) || (_special != null && _special.IsBusy) || IsCharging;
        public bool RiposteReady => Time.unscaledTime < _riposteUntil;
        public int LastChargeLevel { get; private set; }

        /// <summary>Raised for every monster a hit lands on.</summary>
        public event Action<MonsterDummy, DamageResult> HitLanded;

        void Awake()
        {
            _motor = GetComponent<PlayerMotor>();
            var db = AscendData.Db;
            _tuning = db.Tuning;
            _class = db.Classes[classId];
            Stats = PlayerStats.Derive(PlayerStats.Primary(_class, level, db.Progression), level, db.Progression, new GearBonus { Atk = gearAtk, Def = gearDef });
            _chain = new AttackChain(_class.Basic ?? throw new InvalidOperationException($"{classId} has no basic chain"), _tuning);
            _charge = new ChargeMeter(_tuning.Combo);
            _calc = new DamageCalculator(_tuning.Damage);
            _rng = new DeterministicRandom(rngSeed);
        }

        /// <summary>Attack button. A riposte if a parry just opened one; ignored mid-dodge.</summary>
        public void Attack()
        {
            if (_motor.IsDodging || IsCharging) return;
            if (RiposteReady)
            {
                _riposteUntil = -1f;
                var skill = _class.Skill("skl_parry_riposte");
                double power = skill != null && skill.UnlockLevel <= level && skill.Hits.Count > 0 ? skill.Hits[0].Power : DefaultRipostePower;
                StartSpecial("riposte", power, (float)_tuning.Parry.RiposteHitstopSec, 2.0);
                return;
            }
            if (_special != null && _special.IsBusy) return;
            _chain.Press();
        }

        /// <summary>Heavy button pressed: start charging (cancels a chain in recovery).</summary>
        public void BeginHeavy()
        {
            if (_motor.IsDodging || (_special != null && _special.IsBusy)) return;
            if (_chain.IsBusy && !_chain.Cancel()) return;
            _charge.Begin();
        }

        /// <summary>Heavy button released: strike at the charge level reached (0 = tap heavy).</summary>
        public void ReleaseHeavy()
        {
            if (!IsCharging) return;
            LastChargeLevel = _charge.Release();
            double power = HeavyBasePower() * _charge.PowerMult(LastChargeLevel);
            StartSpecial("heavy", power, -1f, _charge.BreaksGuard(LastChargeLevel) ? 1.5 : 1.0);
        }

        /// <summary>Opened by PlayerDefense after a successful parry.</summary>
        public void OpenRiposte() => _riposteUntil = Time.unscaledTime + (float)_tuning.Combo.RiposteWindowSec;

        /// <summary>Called before a dodge: true if the current attack (if any) allows it.</summary>
        public bool TryCancelForDodge()
        {
            _charge.Cancel();
            if (_special != null && _special.IsBusy && !_special.Cancel()) return false;
            return !_chain.IsBusy || _chain.Cancel();
        }

        public void Tick(float dt)
        {
            _charge.Tick(dt);
            if (_special != null && _special.IsBusy)
            {
                Lunge(_special, dt);
                var hit = _special.Tick(dt);
                if (hit != null) Strike(hit, _specialHitstop, _specialPoiseMult);
                return;
            }
            var landed = _chain.Tick(dt);
            bool newHit = _chain.Phase == AttackPhase.Startup && (_chain.HitIndex != _startedIndex || _lastPhase != AttackPhase.Startup);
            if (newHit) { _startedIndex = _chain.HitIndex; FaceTarget(); }
            Lunge(_chain, dt);
            if (landed != null) Strike(landed, -1f, 1.0);
            if (_chain.Phase == AttackPhase.Idle) _startedIndex = -1;
            _lastPhase = _chain.Phase;
        }

        double HeavyBasePower()
        {
            var guardBreak = _class.Skill("skl_guard_break");
            if (guardBreak != null && guardBreak.Hits.Count == 1) return guardBreak.Hits[0].Power;
            var heavy = _class.Kit.Find(k => k.Slot == "skill" && k.Hits.Count == 1 && k.Hits[0].Weight == "heavy" && k.UnlockLevel <= level);
            return heavy != null ? heavy.Hits[0].Power : DefaultHeavyPower;
        }

        void StartSpecial(string id, double power, float hitstop, double poiseMult)
        {
            _chain.Cancel();
            _special = new AttackChain(new SkillData { Id = id, Name = id, Slot = "special", Hits = { new SkillHit { Power = power, Weight = "heavy" } } }, _tuning);
            _specialHitstop = hitstop;
            _specialPoiseMult = poiseMult;
            _special.Press();
            FaceTarget();
        }

        void Lunge(AttackChain chain, float dt)
        {
            if (chain.Phase != AttackPhase.Startup) return;
            var t = chain.TimingOf(chain.Current);
            if (t.StartupSec > 0) _motor.Nudge(transform.forward * (float)(_tuning.AttackTiming.LungeM * dt / t.StartupSec));
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

        void Strike(SkillHit hit, float hitstopOverride, double poiseMult)
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
                Vector3 contact = _overlap[i].ClosestPoint(origin);
                Vector3 to = contact - transform.position; to.y = 0;
                if (to.sqrMagnitude > 0.01f && Vector3.Angle(transform.forward, to) > halfArc) { _struck.Remove(m); continue; }
                var result = _calc.Compute(new DamageInput
                {
                    Kind = DamageKind.Physical, Attack = Stats.Atk, Defense = m.Defense, Power = hit.Power,
                    DefenderWeakness = m.Weakness, CritChance = Stats.CritChance,
                }, _rng);
                m.TakeHit(result.Amount, weight, transform.position, hit.Power * PoisePerPower * poiseMult);
                DamageNumber.Spawn(contact + Vector3.up * 0.3f, result.Amount, result.Crit);
                HitLanded?.Invoke(m, result);
            }
            if (_struck.Count == 0) return;
            HitStop.Trigger(hitstopOverride > 0f ? hitstopOverride : HitstopFor(weight));
            CameraShake.Kick(weight);
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
