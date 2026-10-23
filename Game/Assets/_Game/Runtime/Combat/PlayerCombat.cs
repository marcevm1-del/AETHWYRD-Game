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
    public sealed partial class PlayerCombat : MonoBehaviour
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
        float _specialHitstop = -1f, _riposteUntil = -1f, _stringIdle;
        double _specialPoiseMult = 1;
        Special _specialKind;
        int _stringHits;
        bool _airString;
        ComboBudget _budget;

        /// <summary>What the current one-hit special is (combat.md §4.1 grammar).</summary>
        public enum Special { None, Heavy, Riposte, Launcher, Slam, Skill }

        /// <summary>Launch speed (m/s up) for a launcher, juggle pop for air hits, slam speed down.</summary>
        public const float LaunchSpeed = 11f, PopSpeed = 4.5f, SlamSpeed = 16f, JumpCancelHeight = 2.0f;
        const double DefaultLaunchPower = 1.2, DefaultSlamPower = 1.6;
        readonly Collider[] _overlap = new Collider[32];
        readonly HashSet<MonsterDummy> _struck = new HashSet<MonsterDummy>();

        public AttackChain Chain => _chain;
        public ChargeMeter Charge => _charge;
        public DerivedStats Stats { get; private set; }
        public bool IsCharging => _charge != null && _charge.Charging;
        public bool IsAttacking => (_chain != null && _chain.IsBusy) || (_special != null && _special.IsBusy) || IsCharging;
        public bool RiposteReady => Time.unscaledTime < _riposteUntil;
        public int LastChargeLevel { get; private set; }
        public Special CurrentSpecial => _special != null && _special.IsBusy ? _specialKind : Special.None;
        public ComboBudget Budget => _budget;
        /// <summary>The lock-on target, if any (set by LockOn); preferred by the soft-lock.</summary>
        public MonsterDummy LockTarget { get; set; }

        /// <summary>Raised for every monster a hit lands on.</summary>
        public event Action<MonsterDummy, DamageResult> HitLanded;
        /// <summary>Raised when a slam lands on a monster that was launched (Style: launch-to-slam).</summary>
        public event Action<MonsterDummy> LaunchToSlam;

        void Awake()
        {
            _motor = GetComponent<PlayerMotor>();
            var db = AscendData.Db;
            _tuning = db.Tuning;
            _class = db.Classes[classId];
            Stats = PlayerStats.Derive(PlayerStats.Primary(_class, level, db.Progression), level, db.Progression, new GearBonus { Atk = gearAtk, Def = gearDef });
            _chain = new AttackChain(_class.Basic ?? throw new InvalidOperationException($"{classId} has no basic chain"), _tuning);
            _charge = new ChargeMeter(_tuning.Combo);
            _budget = new ComboBudget(_tuning.Combo);
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
                StartSpecial(Special.Riposte, power, "heavy", (float)_tuning.Parry.RiposteHitstopSec, 2.0);
                return;
            }
            if (_special != null && _special.IsBusy) return;
            if (!_chain.IsBusy) _airString = !_motor.IsGrounded;
            _chain.Press();
        }

        /// <summary>
        /// Heavy button pressed. In the air: slam. After two or more light hits: launcher (L L H).
        /// Otherwise start charging a heavy (cancels a chain in recovery).
        /// </summary>
        public void BeginHeavy()
        {
            if (_motor.IsDodging || (_special != null && _special.IsBusy)) return;
            if (!_motor.IsGrounded)
            {
                StartSpecial(Special.Slam, KitPower("skl_comet_dive", DefaultSlamPower), "heavy", -1f, 1.5);
                return;
            }
            if (_stringHits >= 2 && (!_chain.IsBusy || _chain.CanDodgeCancel))
            {
                _stringHits = 0;
                StartSpecial(Special.Launcher, KitPower("skl_rising_cut", DefaultLaunchPower), "launch", -1f, 1.0);
                return;
            }
            if (_chain.IsBusy && !_chain.Cancel()) return;
            _charge.Begin();
        }

        /// <summary>
        /// Jump during a launcher (or right after one) cancels into a rising jump that follows the target up.
        /// True if the jump was taken here; otherwise the caller may do a normal jump when not attacking.
        /// </summary>
        public bool TryJumpCancel()
        {
            if (CurrentSpecial != Special.Launcher || _special.Phase == AttackPhase.Startup) return false;
            _special.Cancel();
            _motor.Rise(JumpCancelHeight);
            return true;
        }

        double KitPower(string skillId, double fallback)
        {
            var s = _class.Skill(skillId);
            return s != null && s.UnlockLevel <= level && s.Hits.Count > 0 ? s.Hits[s.Hits.Count - 1].Power : fallback;
        }

        /// <summary>Heavy button released: strike at the charge level reached (0 = tap heavy).</summary>
        public void ReleaseHeavy()
        {
            if (!IsCharging) return;
            LastChargeLevel = _charge.Release();
            double power = HeavyBasePower() * _charge.PowerMult(LastChargeLevel);
            StartSpecial(Special.Heavy, power, "heavy", -1f, _charge.BreaksGuard(LastChargeLevel) ? 1.5 : 1.0);
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
            _budget.Tick(dt, IsAttacking, !_motor.IsGrounded);
            Caster.Tick(dt);
            _motor.Hang = IsAttacking && !_motor.IsGrounded && CurrentSpecial != Special.Slam;
            if (_motor.IsGrounded) _airString = false;
            if (_special != null && _special.IsBusy)
            {
                if (_specialKind != Special.Slam) Lunge(_special, dt);
                var hit = _special.Tick(dt);
                // Multi-hit skills play through on their own (press the next hit while one is running).
                if (_specialKind == Special.Skill && _special.IsBusy && _special.HitIndex < _special.Length - 1) _special.Press();
                if (hit != null) Strike(hit, _specialHitstop, _specialPoiseMult, _specialKind);
                return;
            }
            var landed = _chain.Tick(dt);
            bool newHit = _chain.Phase == AttackPhase.Startup && (_chain.HitIndex != _startedIndex || _lastPhase != AttackPhase.Startup);
            if (newHit) { _startedIndex = _chain.HitIndex; _stringHits++; FaceTarget(); }
            if (!_airString) Lunge(_chain, dt);
            if (landed != null) Strike(landed, -1f, 1.0, Special.None);
            if (_chain.Phase == AttackPhase.Idle)
            {
                _startedIndex = -1;
                if ((_stringIdle += dt) >= _tuning.AttackTiming.ChainResetSec) _stringHits = 0;
            }
            else _stringIdle = 0;
            _lastPhase = _chain.Phase;
        }

        double HeavyBasePower()
        {
            var guardBreak = _class.Skill("skl_guard_break");
            if (guardBreak != null && guardBreak.Hits.Count == 1) return guardBreak.Hits[0].Power;
            var heavy = _class.Kit.Find(k => k.Slot == "skill" && k.Hits.Count == 1 && k.Hits[0].Weight == "heavy" && k.UnlockLevel <= level);
            return heavy != null ? heavy.Hits[0].Power : DefaultHeavyPower;
        }

        void StartSpecial(Special kind, double power, string weight, float hitstop, double poiseMult)
        {
            _chain.Cancel();
            _charge.Cancel();
            string id = kind.ToString().ToLowerInvariant();
            _special = new AttackChain(_pendingSkill ?? new SkillData { Id = id, Name = id, Slot = "special", Hits = { new SkillHit { Power = power, Weight = weight } } }, _tuning);
            _pendingSkill = null;
            _specialKind = kind;
            _specialHitstop = hitstop;
            if (kind == Special.Slam) _motor.Plunge(14f);
            _specialPoiseMult = poiseMult;
            _special.Press();
            FaceTarget();
        }

        void Lunge(AttackChain chain, float dt)
        {
            if (chain.Phase != AttackPhase.Startup) return;
            var t = chain.TimingOf(chain.Current);
            double lunge = chain == _special && _specialKind == Special.Skill && _skillDashM > 0 ? _skillDashM : _tuning.AttackTiming.LungeM;
            if (t.StartupSec > 0) _motor.Nudge(transform.forward * (float)(lunge * dt / t.StartupSec));
        }

        /// <summary>Soft lock: turn toward the nearest live monster within reach × 2 and the soft-lock cone.</summary>
        void FaceTarget()
        {
            if (LockTarget != null && !LockTarget.IsDead)
            {
                Vector3 l = LockTarget.transform.position - transform.position; l.y = 0;
                if (l.sqrMagnitude > 1e-4f) transform.rotation = Quaternion.LookRotation(l);
                return;
            }
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

        void Strike(SkillHit hit, float hitstopOverride, double poiseMult, Special kind)
        {
            var weight = AttackChain.WeightOf(hit);
            bool skill = kind == Special.Skill;
            bool wide = skill && _skillShape == SkillShape.Circle;
            float reach = (float)_tuning.AttackTiming.ReachM * (wide ? _skillReachMult : 1f), halfArc = wide ? 180f : (float)_tuning.AttackTiming.ArcDeg * 0.5f;
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
                bool wasLaunched = m.LaunchedSinceLanding && m.IsAirborne;
                ApplyHit(m, contact, hit.Power, weight, skill ? _skillElement : Element.None, skill && _skillAppliesElement, poiseMult);
                if (!m.IsDead)
                {
                    if (kind == Special.Launcher) m.Launch(LaunchSpeed);
                    else if (kind == Special.Slam) { m.Slam(SlamSpeed); if (wasLaunched) LaunchToSlam?.Invoke(m); }
                    else if ((kind == Special.None || kind == Special.Skill) && !_motor.IsGrounded) m.Pop(PopSpeed);
                }
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
