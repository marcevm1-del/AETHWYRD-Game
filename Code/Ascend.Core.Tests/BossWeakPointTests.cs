using System.Linq;
using Ascend.Core;

// Boss weak points and armor (bosses_and_calamities.md; Data/Monsters/boss_weakpoints.json). Time is a passed-in clock.
[Tests]
static class BossWeakPointTests
{
    const string Grukk = "mon_grukk_goblin_chief_of_hollowpine";
    static BossWeakPointData GrukkData => Repo.Db.BossWeakPoints.Bosses.Single(b => b.SpeciesId == Grukk);

    static BossArmorData Small() => new BossArmorData { MaxArmor = 10, BreakSec = 5, DamageTakenMultWhileBroken = 1.25, RegenDelaySec = 6 };

    // ------------------------------------------------------------------ data
    public static void GrukkWeakPointDataLoadsAndMatchesThePhases()
    {
        Assert.True(Repo.Db.BossWeakPoints.Bosses.Count >= 1, "at least the Grukk record");
        var g = GrukkData;
        Assert.True(Repo.Db.Species.ContainsKey(g.SpeciesId), "species exists");
        Assert.True(g.Armor.MaxArmor > 0 && g.Armor.BreakSec > 0 && g.Armor.RegenDelaySec > 0, "armor numbers set");
        Assert.True(g.Armor.DamageTakenMultWhileBroken > 1.0, "a broken armor means extra damage taken");
        Assert.True(g.WeakPoints.Count >= 1, "at least one weak point");
        var phases = Repo.Db.Bosses[Grukk].Phases.Select(p => p.Name).ToList();
        foreach (var wp in g.WeakPoints)
        {
            Assert.True(wp.DamageMult > 1.0 && wp.ArmorDamageMult > 0, $"{wp.Id} multipliers");
            Assert.True(wp.ExposedInPhases.Count >= 1, $"{wp.Id} is exposed somewhere");
            foreach (var p in wp.ExposedInPhases) Assert.True(phases.Contains(p), $"{wp.Id} exposes in unknown phase \"{p}\"");
        }
    }

    public static void EveryWeakPointRecordPointsAtARealSpecies()
    {
        foreach (var b in Repo.Db.BossWeakPoints.Bosses)
            Assert.True(Repo.Db.Species.ContainsKey(b.SpeciesId), $"{b.SpeciesId} is in species.json");
    }

    // ------------------------------------------------------------------ armor by the clock
    public static void ArmorChipsThenBreaksThenRestores()
    {
        var a = new BossArmor(Small());
        Assert.Near(10, a.Value(0), 1e-9, "full at the start");
        Assert.True(!a.Hit(4, 0), "a chip does not break it");
        Assert.Near(6, a.Value(0), 1e-9, "10 - 4");
        Assert.True(!a.IsBroken(0), "not broken");
        Assert.True(a.Hit(6, 1), "the hit that empties it reports the break");
        Assert.True(a.IsBroken(1.0), "broken at the moment of the hit");
        Assert.Near(0, a.Value(2), 1e-9, "armor reads 0 while broken");
        Assert.Near(1.25, a.DamageTakenMult(2), 1e-9, "extra damage taken while broken");
        Assert.True(a.IsBroken(5.9), "still broken just before the break ends (1 + 5 = 6)");
        Assert.True(!a.IsBroken(6.0), "break ends at breakSec");
        Assert.Near(1.0, a.DamageTakenMult(6.0), 1e-9, "no bonus after the break");
        Assert.Near(10, a.Value(6.0), 1e-9, "armor is restored in full");
    }

    public static void HitsDuringABreakChangeNothing()
    {
        var a = new BossArmor(Small());
        a.Hit(10, 0);
        Assert.True(!a.Hit(50, 1), "no second break");
        Assert.True(a.IsBroken(4.9), "the break did not extend");
        Assert.True(!a.IsBroken(5.0), "break still ends on the first schedule");
        Assert.Near(10, a.Value(5.0), 1e-9, "restored in full");
    }

    public static void UnbrokenArmorRefillsAfterTheRegenDelay()
    {
        var a = new BossArmor(Small());
        a.Hit(4, 0);
        Assert.Near(6, a.Value(5.9), 1e-9, "not yet (delay is 6 s)");
        Assert.Near(10, a.Value(6.0), 1e-9, "refilled at the delay");
    }

    public static void AnotherHitRestartsTheRegenDelay()
    {
        var a = new BossArmor(Small());
        a.Hit(4, 0);
        a.Hit(4, 5);
        Assert.Near(2, a.Value(5), 1e-9, "10 - 4 - 4");
        Assert.Near(2, a.Value(10.9), 1e-9, "5.9 s since the last hit: still chipped");
        Assert.Near(10, a.Value(11.0), 1e-9, "6 s since the last hit: refilled");
    }

    public static void NoArmorBossesAreNeverBroken()
    {
        var a = new BossArmor(new BossArmorData { MaxArmor = 0 });
        Assert.True(!a.HasArmor, "no armor");
        Assert.True(!a.Hit(100, 0), "cannot be broken");
        Assert.True(!a.IsBroken(0), "never broken");
        var b = new BossArmor(Small());
        Assert.True(!b.Hit(0, 0) && !b.Hit(-3, 0), "zero or negative armor damage does nothing");
        Assert.Near(10, b.Value(0), 1e-9, "untouched");
    }

    public static void AfterARestoreItCanBreakAgain()
    {
        var a = new BossArmor(Small());
        Assert.True(a.Hit(10, 0), "first break");
        Assert.True(a.Hit(10, 5), "restored at 5 and broken again");
        Assert.True(a.IsBroken(5.1), "second break active");
    }

    // ------------------------------------------------------------------ weak points by phase
    public static void WeakPointMultiplierAppliesOnlyInExposedPhases()
    {
        var g = GrukkData;
        var wp = g.WeakPoints[0];
        foreach (var phase in Repo.Db.Bosses[Grukk].Phases.Select(p => p.Name))
        {
            var r = BossTargeting.Resolve(g, phase, wp.BodyPart, HitWeight.Heavy);
            bool exposed = wp.ExposedInPhases.Contains(phase);
            if (exposed)
            {
                Assert.Near(wp.DamageMult, r.DamageMult, 1e-9, $"{phase}: weak point damage");
                Assert.True(r.WeakPoint != null && r.WeakPoint.Id == wp.Id, $"{phase}: weak point reported");
                Assert.Near(BossTargeting.BaseArmorDamage(HitWeight.Heavy) * wp.ArmorDamageMult, r.ArmorDamage, 1e-9, $"{phase}: armor damage scaled");
            }
            else
            {
                Assert.Near(1.0, r.DamageMult, 1e-9, $"{phase}: not exposed, no bonus");
                Assert.True(r.WeakPoint == null, $"{phase}: no weak point reported");
                Assert.Near(BossTargeting.BaseArmorDamage(HitWeight.Heavy), r.ArmorDamage, 1e-9, $"{phase}: plain armor damage");
            }
        }
        // The Duel is the one Grukk phase where the brand is hidden.
        Assert.True(!wp.ExposedInPhases.Contains("Duel"), "the rune brand is hidden in the Duel");
        Assert.True(wp.ExposedInPhases.Contains("Archers") && wp.ExposedInPhases.Contains("Rage"), "and exposed in Archers and Rage");
    }

    public static void OtherBodyPartsAndUnknownPhasesGetNoBonus()
    {
        var g = GrukkData;
        var r = BossTargeting.Resolve(g, "Archers", "left_leg", HitWeight.Medium);
        Assert.Near(1.0, r.DamageMult, 1e-9, "another part");
        Assert.True(r.WeakPoint == null, "no weak point");
        Assert.Near(BossTargeting.BaseArmorDamage(HitWeight.Medium), r.ArmorDamage, 1e-9, "plain armor damage");
        Assert.Near(1.0, BossTargeting.Resolve(g, "NoSuchPhase", "chest", HitWeight.Light).DamageMult, 1e-9, "unknown phase");
        Assert.Near(1.0, BossTargeting.Resolve(g, "Archers", null, HitWeight.Light).DamageMult, 1e-9, "no part named");
        Assert.Near(1.0, BossTargeting.Resolve(null, "Archers", "chest", HitWeight.Light).DamageMult, 1e-9, "no boss data");
    }

    public static void PartMatchingIsCaseInsensitiveAndAcceptsTheWeakPointId()
    {
        var g = GrukkData;
        var wp = g.WeakPoints[0];
        Assert.Near(wp.DamageMult, BossTargeting.Resolve(g, "archers", wp.BodyPart.ToUpperInvariant(), HitWeight.Light).DamageMult, 1e-9, "case-insensitive part and phase");
        Assert.Near(wp.DamageMult, BossTargeting.Resolve(g, "Rage", wp.Id, HitWeight.Light).DamageMult, 1e-9, "matched by id");
    }

    public static void BaseArmorDamageGrowsWithWeight()
    {
        Assert.Near(1.0, BossTargeting.BaseArmorDamage(HitWeight.Light), 1e-9, "light");
        Assert.Near(2.0, BossTargeting.BaseArmorDamage(HitWeight.Medium), 1e-9, "medium");
        Assert.Near(4.0, BossTargeting.BaseArmorDamage(HitWeight.Heavy), 1e-9, "heavy");
        Assert.Near(4.0, BossTargeting.BaseArmorDamage(HitWeight.Launch), 1e-9, "launch");
        Assert.Near(3.0, BossTargeting.BaseArmorDamage(HitWeight.Skill), 1e-9, "skill");
        Assert.Near(8.0, BossTargeting.BaseArmorDamage(HitWeight.Ultimate), 1e-9, "ultimate");
    }

    public static void ATimedWeakPointClosesAfterItsExposedSeconds()
    {
        var boss = new BossWeakPointData
        {
            SpeciesId = "x",
            WeakPoints = { new WeakPointData { Id = "wp_x", BodyPart = "back", DamageMult = 2, ArmorDamageMult = 1, ExposedInPhases = { "P" }, ExposedSec = 4 } },
        };
        Assert.Near(2.0, BossTargeting.Resolve(boss, "P", "back", HitWeight.Light, 3.9).DamageMult, 1e-9, "open at 3.9 s");
        Assert.Near(2.0, BossTargeting.Resolve(boss, "P", "back", HitWeight.Light, 4.0).DamageMult, 1e-9, "open at exactly 4 s");
        Assert.Near(1.0, BossTargeting.Resolve(boss, "P", "back", HitWeight.Light, 4.1).DamageMult, 1e-9, "closed after 4 s");
        Assert.Near(2.0, BossTargeting.Resolve(boss, "P", "back", HitWeight.Light).DamageMult, 1e-9, "no timer passed: phase rule only");
    }
}
