using System;
using System.Linq;
using Ascend.Core;

// The 12 base classes (Data/Classes/classes.json, built by Tools/classes/build_classes.js).
[Tests]
static class ClassKitTests
{
    static readonly string[] Casters = { "cls_mage", "cls_cleric", "cls_bard", "cls_occultist" };
    static readonly string[] Supports = { "cls_cleric", "cls_bard", "cls_tamer" };

    static (DerivedStats p, bool magic) Level1(ClassData c)
    {
        var db = Repo.Db;
        var weapon = db.Items[c.StarterWeaponId];
        var gear = new GearBonus { Atk = (int)weapon.Stat("atk"), Matk = (int)weapon.Stat("matk"), Def = (int)weapon.Stat("def") + 3, Mdef = (int)weapon.Stat("mdef") };
        return (PlayerStats.Derive(PlayerStats.Primary(c, 1, db.Progression), 1, db.Progression, gear), Casters.Contains(c.Id));
    }

    public static void TwelveBaseClassesEachWithOneBasicAndOneUltimate()
    {
        var bases = Repo.Db.Classes.Values.Where(c => c.Tier == "base").ToList();
        Assert.Equal(12, bases.Count, "Canon: 12 base classes");
        Assert.True(bases.Sum(c => c.Passives.Count) >= 15, "passives from the doc are carried over (the Cleric's doc lists none)");
        foreach (var c in bases)
        {
            Assert.True(c.Basic != null, $"{c.Id} has a basic string");
            Assert.Equal(1, c.Kit.Count(k => k.Slot == "ultimate"), $"{c.Id} has one ultimate");
            Assert.True(!string.IsNullOrEmpty(c.Trainer) && !string.IsNullOrEmpty(c.ClassQuest), $"{c.Id} has a trainer and class quest");
            Assert.True(Repo.Db.Items.ContainsKey(c.StarterWeaponId), $"{c.Id} starter weapon exists");
        }
    }

    public static void EveryBasicStringRunsInTheAttackChain()
    {
        foreach (var c in Repo.Db.Classes.Values)
        {
            var chain = new AttackChain(c.Basic, Repo.Db.Tuning);
            int landed = 0;
            for (int f = 0; f < 600 && landed < chain.Length; f++)
            {
                if (f % 6 == 0) chain.Press();
                if (chain.Tick(1.0 / 60) != null) landed++;
            }
            Assert.Equal(chain.Length, landed, $"{c.Id}: mashing plays the whole basic string");
        }
    }

    public static void Level1BasicStringIsFairAgainstAGoblin()
    {
        var db = Repo.Db;
        var goblin = db.Species["mon_goblin"];
        var calc = new DamageCalculator(db.Tuning.Damage);
        var rng = new FixedRandom(0.99, 0.5); // no crit, average variance
        foreach (var c in db.Classes.Values)
        {
            var (p, magic) = Level1(c);
            int atk = magic ? p.Matk : p.Atk;
            int def = magic ? goblin.Stats.Mdef : goblin.Stats.Def;
            int stringDmg = c.Basic.Hits.Sum(h => calc.Compute(new DamageInput { Kind = magic ? DamageKind.Magical : DamageKind.Physical, Attack = atk, Defense = def, Power = h.Power }, rng).Amount);
            int strings = (int)Math.Ceiling(goblin.Stats.Hp / (double)stringDmg);
            int maxStrings = Supports.Contains(c.Id) ? 3 : 2;
            Assert.True(strings >= 1 && strings <= maxStrings, $"{c.Id}: a Lv 1 goblin takes {strings} basic strings ({stringDmg} dmg each, {goblin.Stats.Hp} HP); want 1-{maxStrings}");
        }
    }

    public static void SkillsUnlockByLevel()
    {
        var mage = Repo.Db.Classes["cls_mage"];
        Assert.True(mage.SkillsAt(1).Any(k => k.Id == "skl_fire_bolt"), "Fire Bolt at Lv 1");
        Assert.True(!mage.SkillsAt(16).Any(k => k.Id == "skl_fireball"), "true Fireball not before Lv 17");
        Assert.True(mage.SkillsAt(17).Any(k => k.Id == "skl_fireball"), "true Fireball at Lv 17");
        Assert.True(mage.PassivesAt(5).Any(p => p.Id == "psv_second_element"), "Second Element at Lv 5");
    }
}
