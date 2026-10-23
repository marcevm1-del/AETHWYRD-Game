using System;
using System.Collections.Generic;
using System.Linq;

namespace Ascend.Core
{
    /// <summary>Resource and skill tuning (combat.md §6): regeneration, Awakening gain and skill slots.</summary>
    public sealed class ResourceTuning
    {
        public double SpRegenPerSec { get; set; } = 8;
        public double MpRegenPerSec { get; set; } = 4;
        public double AwakeningMax { get; set; } = 100;
        /// <summary>Awakening per Style point earned by hits (so varied play fills it faster).</summary>
        public double AwakeningPerStylePoint { get; set; } = 0.12;
        /// <summary>Awakening per 1% of max HP lost.</summary>
        public double AwakeningPerHpPercentLost { get; set; } = 0.5;
        public int SkillSlots { get; set; } = 4;
    }

    public enum CastResult { Ok, Locked, Cooldown, NoSp, NoMp, NoAwakening, NoBudget, NotInKit }

    /// <summary>
    /// SP, MP, Awakening, cooldowns and the 4 skill slots for one character (combat.md §6). Casting during an
    /// attack is a skill-cancel and spends a Combo Budget point (§4.1). Engine-free; the game calls Tick each frame.
    /// </summary>
    public sealed class SkillCaster
    {
        readonly ClassData _class;
        readonly ResourceTuning _t;
        readonly ComboBudget _budget;
        readonly Dictionary<string, double> _cooldown = new Dictionary<string, double>();

        public int Level { get; private set; }
        public double Sp { get; private set; }
        public double Mp { get; private set; }
        public double Awakening { get; private set; }
        public double MaxSp { get; }
        public double MaxMp { get; }
        public double MaxAwakening => _t.AwakeningMax;

        public SkillCaster(ClassData cls, int level, DerivedStats stats, ResourceTuning tuning, ComboBudget budget)
        {
            _class = cls ?? throw new ArgumentNullException(nameof(cls));
            _t = tuning ?? new ResourceTuning();
            _budget = budget;
            Level = Math.Max(1, level);
            MaxSp = Sp = Math.Max(1, stats.Sp);
            MaxMp = Mp = Math.Max(1, stats.Mp);
        }

        /// <summary>The slotted skills: unlocked "skill"-slot skills in kit order, up to the slot count.</summary>
        public IReadOnlyList<SkillData> Slots =>
            _class.Kit.Where(k => k.Slot == "skill" && k.UnlockLevel <= Level).Take(_t.SkillSlots).ToList();

        public SkillData Ultimate => _class.Kit.FirstOrDefault(k => k.Slot == "ultimate");

        public void SetLevel(int level) => Level = Math.Max(1, level);

        public double CooldownLeft(string skillId) => _cooldown.TryGetValue(skillId, out var c) ? c : 0;

        public CastResult CanCast(SkillData s, bool asCancel = false)
        {
            if (s == null || !_class.Kit.Contains(s)) return CastResult.NotInKit;
            if (s.UnlockLevel > Level) return CastResult.Locked;
            if (CooldownLeft(s.Id) > 0) return CastResult.Cooldown;
            if (s.CostSp > Sp) return CastResult.NoSp;
            if (s.CostMp > Mp) return CastResult.NoMp;
            if (s.CostAwakening > Awakening) return CastResult.NoAwakening;
            if (asCancel && _budget != null && _budget.Left <= 0) return CastResult.NoBudget;
            return CastResult.Ok;
        }

        /// <summary>Spends the costs and starts the cooldown if the skill can be cast.</summary>
        public CastResult Cast(SkillData s, bool asCancel = false)
        {
            var r = CanCast(s, asCancel);
            if (r != CastResult.Ok) return r;
            if (asCancel && _budget != null) _budget.TrySpend();
            Sp -= s.CostSp; Mp -= s.CostMp; Awakening -= s.CostAwakening;
            if (s.CooldownSec > 0) _cooldown[s.Id] = s.CooldownSec;
            return CastResult.Ok;
        }

        public void Tick(double dt)
        {
            if (dt <= 0) return;
            Sp = Math.Min(MaxSp, Sp + _t.SpRegenPerSec * dt);
            Mp = Math.Min(MaxMp, Mp + _t.MpRegenPerSec * dt);
            foreach (var k in _cooldown.Keys.ToList()) _cooldown[k] = Math.Max(0, _cooldown[k] - dt);
        }

        public void GainAwakeningFromStyle(double stylePoints) => AddAwakening(stylePoints * _t.AwakeningPerStylePoint);

        public void GainAwakeningFromDamage(int damage, int maxHp)
        {
            if (maxHp > 0) AddAwakening(100.0 * damage / maxHp * _t.AwakeningPerHpPercentLost);
        }

        public void AddAwakening(double amount) => Awakening = Math.Max(0, Math.Min(MaxAwakening, Awakening + amount));
    }

    /// <summary>Firestorm (Fire + Wind, combat.md §7): a burst on the triggering hit, then a burning zone.</summary>
    public sealed class FirestormTuning
    {
        public double BurstMult { get; set; } = 1.5;
        public double RadiusM { get; set; } = 4;
        public double DurationSec { get; set; } = 4;
        public double TickSec { get; set; } = 0.5;
        public double TickPower { get; set; } = 0.35;
    }
}
