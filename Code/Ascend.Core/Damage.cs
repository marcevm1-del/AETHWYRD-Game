using System;

namespace Ascend.Core
{
    /// <summary>Random source abstraction so rules stay deterministic in tests.</summary>
    public interface IRandom
    {
        /// <summary>Uniform double in [0, 1).</summary>
        double NextDouble();
    }

    public sealed class SystemRandom : IRandom
    {
        readonly Random _r;
        public SystemRandom(int seed) { _r = new Random(seed); }
        public double NextDouble() => _r.NextDouble();
    }

    public enum DamageKind { Physical, Magical }

    public struct DamageInput
    {
        public DamageKind Kind;
        /// <summary>Attacker ATK (physical) or MATK (magical).</summary>
        public double Attack;
        /// <summary>Defender DEF (physical) or MDEF (magical).</summary>
        public double Defense;
        /// <summary>Attack power multiplier from the attack/skill data.</summary>
        public double Power;
        public Element AttackElement;
        public Element DefenderWeakness;
        /// <summary>Element the defender resists (usually its own element).</summary>
        public Element DefenderResist;
        public double CritChance;
        /// <summary>Added on top of the base crit multiplier (e.g. 0.25 for +25% crit damage).</summary>
        public double CritDamageBonus;
        public bool Stealth;
        /// <summary>Extra multiplier for reactions (e.g. Freeze shatter). 1 = none.</summary>
        public double ReactionMult;
    }

    public struct DamageResult
    {
        public int Amount;
        public bool Crit;
        public double ElementMult;
    }

    /// <summary>Damage formula from 12_Systems/combat.md §9.</summary>
    public sealed class DamageCalculator
    {
        readonly DamageTuning _t;
        public DamageCalculator(DamageTuning tuning) { _t = tuning ?? throw new ArgumentNullException(nameof(tuning)); }

        public double ElementMultiplier(Element attack, Element weakness, Element resist)
        {
            if (attack == Element.None) return 1.0;
            if (attack == weakness) return _t.WeaknessMult;
            if (attack == resist) return _t.ResistMult;
            return 1.0;
        }

        public DamageResult Compute(DamageInput d, IRandom rng)
        {
            if (rng == null) throw new ArgumentNullException(nameof(rng));
            double def = Math.Max(0, d.Defense);
            double mitigation = _t.DefenseConstant / (_t.DefenseConstant + def);
            double elem = ElementMultiplier(d.AttackElement, d.DefenderWeakness, d.DefenderResist);
            bool crit = rng.NextDouble() < d.CritChance;
            double critMult = crit ? _t.CritBaseMult + d.CritDamageBonus : 1.0;
            double lo = _t.Variance.Count > 0 ? _t.Variance[0] : 1.0;
            double hi = _t.Variance.Count > 1 ? _t.Variance[1] : lo;
            double variance = lo + (hi - lo) * rng.NextDouble();
            double stealth = d.Stealth ? _t.StealthMult : 1.0;
            double reaction = d.ReactionMult <= 0 ? 1.0 : d.ReactionMult;
            double raw = d.Attack * d.Power * mitigation * elem * critMult * variance * stealth * reaction;
            int amount = d.Power <= 0 ? 0 : Math.Max(1, (int)Math.Round(raw, MidpointRounding.AwayFromZero));
            return new DamageResult { Amount = amount, Crit = crit, ElementMult = elem };
        }
    }
}
