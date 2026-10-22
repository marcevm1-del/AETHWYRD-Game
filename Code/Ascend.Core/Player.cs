using System;
using System.Collections.Generic;
using System.Linq;

namespace Ascend.Core
{
    // Player progression (Data/Classes/progression.json, Data/Classes/classes.json).

    public sealed class Formula
    {
        public double Flat { get; set; }
        public double Str { get; set; }
        public double Vit { get; set; }
        public double Agi { get; set; }
        public double Dex { get; set; }
        public double Int { get; set; }
        public double Wis { get; set; }
        public double Luk { get; set; }
        public double Cha { get; set; }
        public double PerLevel { get; set; }
        /// <summary>0 = no cap.</summary>
        public double Max { get; set; }

        public double Eval(PrimaryStats p, int level)
        {
            double v = Flat + Str * p.Str + Vit * p.Vit + Agi * p.Agi + Dex * p.Dex + Int * p.Int + Wis * p.Wis + Luk * p.Luk + Cha * p.Cha + PerLevel * level;
            return Max > 0 ? Math.Min(Max, v) : v;
        }
    }

    public sealed class DerivedFormulas
    {
        public Formula Atk { get; set; } = new Formula();
        public Formula Matk { get; set; } = new Formula();
        public Formula Def { get; set; } = new Formula();
        public Formula Mdef { get; set; } = new Formula();
        public Formula Hp { get; set; } = new Formula();
        public Formula Mp { get; set; } = new Formula();
        public Formula Sp { get; set; } = new Formula();
        public Formula Spd { get; set; } = new Formula();
        public Formula CritChance { get; set; } = new Formula();
    }

    public sealed class XpRules
    {
        public double MonsterBase { get; set; }
        public double MonsterExponent { get; set; }
        public double MonsterScale { get; set; }
        public double UniqueMultiplier { get; set; }
        public double KillsPerLevelBase { get; set; }
        public double KillsPerLevelGrowth { get; set; }
    }

    /// <summary>Mirror of Data/Classes/progression.json.</summary>
    public sealed class ProgressionRules
    {
        public int Version { get; set; }
        public double BaseStat { get; set; } = 10;
        public double FreePointsPerLevel { get; set; } = 5;
        public DerivedFormulas Derived { get; set; } = new DerivedFormulas();
        public XpRules Xp { get; set; } = new XpRules();
    }

    public sealed class StatSpread
    {
        public double Str { get; set; }
        public double Vit { get; set; }
        public double Agi { get; set; }
        public double Dex { get; set; }
        public double Int { get; set; }
        public double Wis { get; set; }
        public double Luk { get; set; }
        public double Cha { get; set; }
    }

    public struct PrimaryStats
    {
        public double Str, Vit, Agi, Dex, Int, Wis, Luk, Cha;
    }

    public struct DerivedStats
    {
        public int Hp, Mp, Sp, Atk, Matk, Def, Mdef, Spd;
        public double CritChance;
    }

    public sealed class SkillHit { public double Power { get; set; } public string Weight { get; set; } }

    public sealed class SkillData
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int UnlockLevel { get; set; }
        public string Kind { get; set; }
        public string Slot { get; set; }
        public List<SkillHit> Hits { get; set; } = new List<SkillHit>();
        public double CostSp { get; set; }
        public double CostMp { get; set; }
        public double CostAwakening { get; set; }
        public double CooldownSec { get; set; }
        public string Element { get; set; }
        public bool AppliesElement { get; set; }
    }

    /// <summary>Mirror of one entry in Data/Classes/classes.json.</summary>
    public sealed class ClassData
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Tier { get; set; }
        public string Role { get; set; }
        public StatSpread Growth { get; set; } = new StatSpread();
        public StatSpread RecommendedAllocation { get; set; } = new StatSpread();
        public List<string> Weapons { get; set; } = new List<string>();
        public List<string> Armor { get; set; } = new List<string>();
        public string Mechanic { get; set; }
        public string StarterWeaponId { get; set; }
        public List<SkillData> Kit { get; set; } = new List<SkillData>();

        public SkillData Skill(string id) => Kit.FirstOrDefault(k => k.Id == id);
    }

    /// <summary>Equipment bonuses that feed derived stats (from item "stats").</summary>
    public struct GearBonus
    {
        public int Atk, Matk, Def, Mdef, Hp;
    }

    public static class PlayerStats
    {
        /// <summary>
        /// Primary stats at a level: base + class growth per level + free points (5/level after level 1)
        /// spent with the class's recommended allocation. Real saves store the player's actual allocation.
        /// </summary>
        public static PrimaryStats Primary(ClassData cls, int level, ProgressionRules rules, StatSpread allocation = null)
        {
            if (cls == null) throw new ArgumentNullException(nameof(cls));
            level = Math.Max(1, Math.Min(Levels.Cap, level));
            var g = cls.Growth; var a = allocation ?? cls.RecommendedAllocation;
            double free = rules.FreePointsPerLevel * (level - 1);
            double B = rules.BaseStat;
            return new PrimaryStats
            {
                Str = B + g.Str * level + free * a.Str, Vit = B + g.Vit * level + free * a.Vit,
                Agi = B + g.Agi * level + free * a.Agi, Dex = B + g.Dex * level + free * a.Dex,
                Int = B + g.Int * level + free * a.Int, Wis = B + g.Wis * level + free * a.Wis,
                Luk = B + g.Luk * level + free * a.Luk, Cha = B + g.Cha * level + free * a.Cha
            };
        }

        public static DerivedStats Derive(PrimaryStats p, int level, ProgressionRules rules, GearBonus gear = default)
        {
            var f = rules.Derived;
            int R(double v) => (int)Math.Round(v, MidpointRounding.AwayFromZero);
            return new DerivedStats
            {
                Hp = R(f.Hp.Eval(p, level)) + gear.Hp,
                Mp = R(f.Mp.Eval(p, level)),
                Sp = R(f.Sp.Eval(p, level)),
                Atk = R(f.Atk.Eval(p, level)) + gear.Atk,
                Matk = R(f.Matk.Eval(p, level)) + gear.Matk,
                Def = R(f.Def.Eval(p, level)) + gear.Def,
                Mdef = R(f.Mdef.Eval(p, level)) + gear.Mdef,
                Spd = R(f.Spd.Eval(p, level)),
                CritChance = f.CritChance.Eval(p, level)
            };
        }
    }

    /// <summary>XP rules shared with the monster generator, so monster XP and level costs always agree.</summary>
    public sealed class XpCurve
    {
        readonly XpRules _r;
        public XpCurve(XpRules rules) { _r = rules ?? throw new ArgumentNullException(nameof(rules)); }

        /// <summary>XP a monster of this level gives (before boss multipliers).</summary>
        public int MonsterXp(int level, bool unique = false) =>
            (int)Math.Round((_r.MonsterBase + Math.Pow(level, _r.MonsterExponent) * _r.MonsterScale) * (unique ? _r.UniqueMultiplier : 1), MidpointRounding.AwayFromZero);

        /// <summary>
        /// XP needed to go from <paramref name="level"/> to level+1: about (10 + 0.25 × level) same-level kills.
        /// Quests, discovery and crafting also give XP, so the real kill count is lower.
        /// </summary>
        public long ToNext(int level)
        {
            if (level >= Levels.Cap) return 0;
            double kills = _r.KillsPerLevelBase + _r.KillsPerLevelGrowth * level;
            return (long)Math.Round(MonsterXp(level) * kills);
        }

        public long TotalTo(int level)
        {
            long t = 0;
            for (int l = 1; l < Math.Min(level, Levels.Cap); l++) t += ToNext(l);
            return t;
        }
    }
}
