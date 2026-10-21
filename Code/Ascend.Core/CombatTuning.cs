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
        public ReactionTuning Reactions { get; set; } = new ReactionTuning();
        public Dictionary<string, int> Poise { get; set; } = new Dictionary<string, int>();
        public double BossBreakKnockdownSec { get; set; }
        public AiTuning Ai { get; set; } = new AiTuning();
        public StyleTuning Style { get; set; } = new StyleTuning();
        public DamageTuning Damage { get; set; } = new DamageTuning();
    }

    public sealed class CameraTuning { public double Distance { get; set; } public double Fov { get; set; } public double GroupPullBackDistance { get; set; } public double ShakeMax { get; set; } }
    public sealed class MovementTuning { public double WalkSpeed { get; set; } public double RunSpeed { get; set; } public double SprintSpeed { get; set; } public double SprintStaminaPerSec { get; set; } public double JumpHeight { get; set; } }
    public sealed class DodgeTuning { public double DurationSec { get; set; } public double IframeSec { get; set; } public double Distance { get; set; } public double StaminaCost { get; set; } public int MaxChain { get; set; } public double PerfectDodgeWindowSec { get; set; } }
    public sealed class FlashTimeTuning { public double TimeScale { get; set; } public double DurationSec { get; set; } }
    public sealed class ParryTuning { public double ParryWindowSec { get; set; } public double BlockDamageReduction { get; set; } public double RiposteHitstopSec { get; set; } }
    public sealed class ComboTuning { public int BudgetPerString { get; set; } public double BudgetRefillSec { get; set; } public List<double> ChargeLevels { get; set; } = new List<double>(); }
    public sealed class HitstopTuning { public double Light { get; set; } public double Medium { get; set; } public double Heavy { get; set; } public double Launch { get; set; } public double Ultimate { get; set; } }
    public sealed class ReactionTuning { public double AuraDurationSec { get; set; } public double FreezeDurationSec { get; set; } public double ShatterBonus { get; set; } public double StormPrisonStunSec { get; set; } }
    public sealed class AiTuning { public int MaxSimultaneousAttackers { get; set; } }

    public sealed class StyleTuning
    {
        public Dictionary<string, int> Thresholds { get; set; } = new Dictionary<string, int>();
        public Dictionary<string, int> HitPoints { get; set; } = new Dictionary<string, int>();
        public double VarietyMultiplier { get; set; }
        public int VarietyWindowHits { get; set; }
        public Dictionary<string, int> Bonus { get; set; } = new Dictionary<string, int>();
        public double DecayPerSec { get; set; }
        public double DecayDelaySec { get; set; }
        public int RepeatPenaltyAfter { get; set; }
        public int DropRanksOnHit { get; set; }
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
