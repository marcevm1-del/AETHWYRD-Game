using System.Collections.Generic;

namespace Ascend.Core
{
    /// <summary>Mirror of Data/Combat/combat_tuning.json. Property names match the JSON (case-insensitive).</summary>
    public sealed class CombatTuning
    {
        public int Version { get; set; }
        public double InputBufferSec { get; set; }
        public double SoftLockAngleDeg { get; set; }
        public CameraTuning Camera { get; set; } = new CameraTuning();
        public MovementTuning Movement { get; set; } = new MovementTuning();
        public DodgeTuning Dodge { get; set; } = new DodgeTuning();
        public FlashTimeTuning FlashTime { get; set; } = new FlashTimeTuning();
        public ParryTuning Parry { get; set; } = new ParryTuning();
        public ComboTuning Combo { get; set; } = new ComboTuning();
        public HitstopTuning Hitstop { get; set; } = new HitstopTuning();
        public AttackTimingTuning AttackTiming { get; set; } = new AttackTimingTuning();
        public FeedbackTuning Feedback { get; set; } = new FeedbackTuning();
        public ResourceTuning Resources { get; set; } = new ResourceTuning();
        public FirestormTuning Firestorm { get; set; } = new FirestormTuning();
        public ReactionTuning Reactions { get; set; } = new ReactionTuning();
        public Dictionary<string, int> Poise { get; set; } = new Dictionary<string, int>();
        public PoiseRegenTuning PoiseRegen { get; set; } = new PoiseRegenTuning();
        public double BossBreakKnockdownSec { get; set; }
        public AiTuning Ai { get; set; } = new AiTuning();
        public GroupTacticsData GroupTactics { get; set; } = new GroupTacticsData();
        public SandboxTuning Sandbox { get; set; } = new SandboxTuning();
        public StyleTuning Style { get; set; } = new StyleTuning();
        public DamageTuning Damage { get; set; } = new DamageTuning();
    }

    public sealed class CameraTuning { public double Distance { get; set; } public double Fov { get; set; } public double GroupPullBackDistance { get; set; } public double ShakeMax { get; set; } }
    public sealed class MovementTuning
    {
        public double WalkSpeed { get; set; }
        public double RunSpeed { get; set; }
        public double SprintSpeed { get; set; }
        public double SprintStaminaPerSec { get; set; }
        public double JumpHeight { get; set; }
        /// <summary>Seconds from standing to full run speed (0 = instant). Short: responsive, with a little weight.</summary>
        public double AccelSec { get; set; } = 0.1;
        /// <summary>Seconds from full run to a stop.</summary>
        public double DecelSec { get; set; } = 0.06;
        /// <summary>Steering in the air as a fraction of ground acceleration (momentum mostly carries).</summary>
        public double AirControl { get; set; } = 0.45;
        /// <summary>Grace after walking off a ledge in which a jump still works ("coyote time").</summary>
        public double CoyoteSec { get; set; } = 0.12;
        /// <summary>A jump pressed this long before landing fires on landing (input buffer).</summary>
        public double JumpBufferSec { get; set; } = 0.15;
        /// <summary>Releasing jump while rising multiplies the upward speed by this (short hop vs full jump).</summary>
        public double JumpCutMult { get; set; } = 0.5;
        /// <summary>Gravity multiplier while falling: a snappier arc that falls faster than it rises.</summary>
        public double FallGravityMult { get; set; } = 1.6;
        /// <summary>Stick tilt below this walks; at or above it runs (keyboard is always full tilt).</summary>
        public double WalkStickThreshold { get; set; } = 0.5;
    }
    public sealed class DodgeTuning { public double DurationSec { get; set; } public double IframeSec { get; set; } public double Distance { get; set; } public double StaminaCost { get; set; } public int MaxChain { get; set; } public double PerfectDodgeWindowSec { get; set; } }
    public sealed class FlashTimeTuning { public double TimeScale { get; set; } public double DurationSec { get; set; } }
    public sealed class ParryTuning
    {
        public double ParryWindowSec { get; set; }
        public double BlockDamageReduction { get; set; }
        public double RiposteHitstopSec { get; set; }
        /// <summary>Stamina a blocked hit drains (combat.md §5: block drains stamina). Parries and dodges cost none here.</summary>
        public double BlockStaminaPerHit { get; set; }
        /// <summary>Stamina drained per second while block is held (0 = holding is free).</summary>
        public double BlockStaminaPerSec { get; set; }
    }
    public sealed class ComboTuning
    {
        public int BudgetPerString { get; set; }
        public double BudgetRefillSec { get; set; }
        public List<double> ChargeLevels { get; set; } = new List<double>();
        public List<double> ChargePowerMult { get; set; } = new List<double>();
        public int GuardBreakLevel { get; set; } = 2;
        /// <summary>After a parry, an attack pressed within this many seconds becomes a riposte.</summary>
        public double RiposteWindowSec { get; set; } = 1.0;
    }
    public sealed class HitstopTuning { public double Light { get; set; } public double Medium { get; set; } public double Heavy { get; set; } public double Launch { get; set; } public double Ultimate { get; set; } }
    /// <summary>Hit feedback: camera shake by hit weight (metres, capped by camera.shakeMax) and damage numbers.</summary>
    public sealed class FeedbackTuning
    {
        public Dictionary<string, double> Shake { get; set; } = new Dictionary<string, double>();
        public double ShakeDecaySec { get; set; } = 0.25;
        public bool DamageNumbers { get; set; } = true;
        public double DamageNumberRiseM { get; set; } = 0.8;
        public double DamageNumberSec { get; set; } = 0.7;

        public double ShakeFor(HitWeight w) => Shake.TryGetValue(char.ToLowerInvariant(w.ToString()[0]) + w.ToString().Substring(1), out var v) ? v : 0;
    }
    public sealed class PhaseTiming { public double StartupSec { get; set; } public double ActiveSec { get; set; } public double RecoverySec { get; set; } }
    public sealed class AttackTimingTuning
    {
        public PhaseTiming Light { get; set; } = new PhaseTiming();
        public PhaseTiming Medium { get; set; } = new PhaseTiming();
        public PhaseTiming Heavy { get; set; } = new PhaseTiming();
        public PhaseTiming Launch { get; set; } = new PhaseTiming();
        public double ChainResetSec { get; set; }
        public double ReachM { get; set; }
        public double ArcDeg { get; set; }
        public double LungeM { get; set; }
    }
    public sealed class ReactionTuning { public double AuraDurationSec { get; set; } public double FreezeDurationSec { get; set; } public double ShatterBonus { get; set; } public double StormPrisonStunSec { get; set; } }
    public sealed class PoiseRegenTuning { public double DelaySec { get; set; } = 2.5; public double FractionPerSec { get; set; } = 0.25; }
    /// <summary>Mirror of the groupTactics block in combat_tuning.json (combat.md 10a). <see cref="ToTuning"/> maps it onto the brain's flat tuning. No leader, no memory (Canon 4d).</summary>
    public sealed class GroupTacticsData
    {
        public bool Enabled { get; set; } = true;
        public GtFlank Flank { get; set; } = new GtFlank();
        public GtRetreat Retreat { get; set; } = new GtRetreat();
        public GtThreat Threat { get; set; } = new GtThreat();
        public GtYield Yield { get; set; } = new GtYield();

        /// <summary>Maps every field the brain reads onto the flat tuning. Fields documented as reserved in the JSON notes are not mapped.</summary>
        public GroupTacticsTuning ToTuning() => new GroupTacticsTuning
        {
            Enabled = Enabled,
            FlankSlotCount = Flank.SlotCount,
            FlankArcDeg = Flank.ArcDeg,
            PressOnPlayerHp = Retreat.PressOnPlayerHp,
            PressOnRetreatScale = Retreat.PressOnRetreatScale,
            HealthyPlayerHp = Retreat.HealthyPlayerHp,
            OutnumberedRetreatBonus = Retreat.OutnumberedRetreatBonus,
            ThreatPlayerWeight = Threat.PlayerStrengthWeight,
            ThreatAlliesWeight = Threat.OutnumberedWeight,
            ThreatOwnHpWeight = Threat.OwnWoundedWeight,
            ThreatAlliesFull = Threat.AlliesForFullSupport,
            YieldHpGap = Yield.HpMargin,
            YieldSec = Yield.HoldSec,
        };
    }
    // Reserved (read by nothing yet, kept so the data and the design doc line up): flank.slotRadiusM, flank.reassignSec,
    // retreat.packRetreatHpFraction, retreat.regroupHpFraction, retreat.regroupSec, threat.cautiousAbove, threat.boldBelow, yield.cooldownSec.
    // retreat.loneRetreatHpFraction restates MonsterBrain.LoneRetreatHp (a test pins them equal).
    public sealed class GtFlank { public int SlotCount { get; set; } = 3; public double SlotRadiusM { get; set; } = 4.5; public double ArcDeg { get; set; } = 240; public double ReassignSec { get; set; } = 1.5; }
    public sealed class GtRetreat
    {
        public double PackRetreatHpFraction { get; set; } = 0.3;
        public double LoneRetreatHpFraction { get; set; } = 0.5;
        public double RegroupHpFraction { get; set; } = 0.6;
        public double RegroupSec { get; set; } = 4;
        public double PressOnPlayerHp { get; set; } = 0.25;
        public double PressOnRetreatScale { get; set; } = 0.5;
        public double HealthyPlayerHp { get; set; } = 0.75;
        public double OutnumberedRetreatBonus { get; set; } = 0.1;
    }
    public sealed class GtThreat { public double PlayerStrengthWeight { get; set; } = 0.4; public double OutnumberedWeight { get; set; } = 0.35; public double OwnWoundedWeight { get; set; } = 0.25; public int AlliesForFullSupport { get; set; } = 4; public double CautiousAbove { get; set; } = 0.6; public double BoldBelow { get; set; } = 0.3; }
    public sealed class GtYield { public double HpMargin { get; set; } = 0.2; public double HoldSec { get; set; } = 1.5; public double CooldownSec { get; set; } = 3; }
    /// <summary>Mirror of the sandbox block (combat.md 7e). Dev tool only.</summary>
    public sealed class SandboxTuning
    {
        public int DefaultSeed { get; set; } = 12345;
        /// <summary>Most dummies one sandbox holds.</summary>
        public int MaxDummies { get; set; } = 8;
        public int DefaultDummyHp { get; set; } = 1000;
    }
    public sealed class AiTuning { public int MaxSimultaneousAttackers { get; set; } }

    public sealed class StyleTuning
    {
        public Dictionary<string, int> Thresholds { get; set; } = new Dictionary<string, int>();
        public Dictionary<string, int> HitPoints { get; set; } = new Dictionary<string, int>();
        public double VarietyMultiplier { get; set; }
        public int VarietyWindowHits { get; set; }
        public Dictionary<string, int> Bonus { get; set; } = new Dictionary<string, int>();
        /// <summary>Extra XP by Style Rank (combat.md §8), e.g. "S": 0.15.</summary>
        public Dictionary<string, double> XpBonus { get; set; } = new Dictionary<string, double>();
        /// <summary>Extra drop rate by Style Rank.</summary>
        public Dictionary<string, double> DropBonus { get; set; } = new Dictionary<string, double>();
        public double DecayPerSec { get; set; }
        public double DecayDelaySec { get; set; }
        public int RepeatPenaltyAfter { get; set; }
        public int DropRanksOnHit { get; set; }
        /// <summary>Points can't exceed this (a little above the SSS threshold), so decay still bites after long combos.</summary>
        public double PointsCap { get; set; }
    }

    public sealed class DamageTuning
    {
        public double DefenseConstant { get; set; }
        public double WeaknessMult { get; set; }
        public double ResistMult { get; set; }
        public double CritBaseMult { get; set; }
        public List<double> Variance { get; set; } = new List<double>();
        public double StealthMult { get; set; }
    }
}
