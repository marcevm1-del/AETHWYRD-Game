using System;
using System.Linq;
using Ascend.Core;

// Ground mounts (Data/Companions/mounts.json): speed placeholder, stamina, mounted combat, ground-only guard.
[Tests]
static class MountTests
{
    static MountTable Load() => Repo.Load<MountTable>("Data/Companions/mounts.json");

    public static void SpeedIsPlaceholderTimesFamilyTimesTerrain()
    {
        var t = Load();
        var f = t.Families["wolf"];
        Assert.Near(10.0 * f.SpeedMult * f.Terrain["forest"], t.Speed("wolf", "forest"), 1e-9, "wolf in forest");
        Assert.Near(10.0 * t.Families["horse"].SpeedMult * t.Families["horse"].Terrain["plains"], t.Speed("horse", "plains"), 1e-9, "horse on plains");
    }

    public static void SpeedIsSettledAtTen()
    {
        var t = Load();
        Assert.True(!t.SpeedMps.Placeholder, "speed was settled 2026-11-07 (Canon section 6, Mount speed)");
        Assert.Near(10.0, t.SpeedMps.Value, 1e-9, "settled speed");
    }

    public static void TerrainSuitabilityFollowsTheFamilies()
    {
        var t = Load();
        Assert.True(t.Speed("wolf", "forest") > t.Speed("wolf", "plains"), "wolf is fast in forest");
        Assert.True(t.Speed("bear", "mountain") > t.Speed("horse", "mountain"), "bear beats horse in mountains");
        Assert.True(t.Speed("desert_beast", "desert") > t.Speed("horse", "desert"), "desert beast beats horse in desert");
        foreach (var f in t.Families.Values)
            foreach (var k in f.Terrain.Keys)
                Assert.True(LocomotionTable.RequiredTerrain.Contains(k), "unknown terrain " + k);
    }

    public static void ExhaustionLimitsSpeedToWalk()
    {
        var t = Load();
        double run = t.Speed("horse", "plains");
        double ex = t.Speed("horse", "plains", new[] { "exhausted" });
        Assert.Near(run * t.ExhaustedWalkFraction, ex, 1e-9, "exhausted speed");
        Assert.True(ex < run * 0.5, "walk pace is well below run pace");
    }

    public static void StaminaDrainsWhileSprintingAndRegens()
    {
        var t = Load();
        var f = t.Families["horse"];
        var m = new MountState(f);
        m.Mount();
        m.StepStamina(1.0, true);
        Assert.Near(f.Stamina.Max - f.Stamina.SprintDrainPerSec, m.Stamina, 1e-9, "after 1 s sprint");
        m.StepStamina(1.0, false);
        Assert.Near(f.Stamina.Max - f.Stamina.SprintDrainPerSec + f.Stamina.RegenPerSec, m.Stamina, 1e-9, "after 1 s rest");
        for (int i = 0; i < 100; i++) m.StepStamina(1.0, false);
        Assert.Near(f.Stamina.Max, m.Stamina, 1e-9, "regen caps at max");
    }

    public static void ExhaustedRecoversWithHysteresis()
    {
        var t = Load();
        var f = t.Families["horse"];
        var m = new MountState(f);
        m.Mount();
        int guard = 0;
        while (!m.Exhausted && guard++ < 1000) m.StepStamina(0.5, true);
        Assert.True(m.Exhausted, "sprinting long enough exhausts the mount");
        Assert.Equal(1, m.Conditions().Length, "exhausted condition is reported");
        // Resting up to just below RecoverTo keeps it exhausted; sprint requests are ignored.
        while (m.Stamina + f.Stamina.RegenPerSec * 0.5 < f.Stamina.RecoverTo) m.StepStamina(0.5, true);
        Assert.True(m.Exhausted, "still exhausted below recoverTo (hysteresis)");
        Assert.True(m.Stamina > f.Stamina.ExhaustedBelow, "stamina above exhaustedBelow yet still exhausted");
        Assert.True(!m.StepStamina(0.1, true), "sprint ignored while exhausted");
        guard = 0;
        while (m.Exhausted && guard++ < 1000) m.StepStamina(0.5, false);
        Assert.True(!m.Exhausted, "recovered at recoverTo");
        Assert.True(m.Stamina >= f.Stamina.RecoverTo, "recovered stamina");
    }

    public static void NoFlyingOrAquaticFamilyInRealData()
    {
        var t = Load();
        t.AssertGroundOnly(Repo.Db.Species);
        foreach (var k in t.Families.Keys.Concat(t.Families.Values.SelectMany(f => f.Species)))
            foreach (var bad in new[] { "flying", "aerial", "celestial", "dragon", "griffin", "aquatic", "wyvern", "pegasus" })
                Assert.True(!k.ToLowerInvariant().Contains(bad), k + " contains " + bad);
        Assert.Equal(5, t.Families.Count, "five ground families");
    }

    public static void AssertGroundOnlyRejectsFlyers()
    {
        var t = new MountTable();
        t.Families["griffin"] = new MountFamily { Species = { "mon_x" } };
        Assert.Throws<InvalidOperationException>(() => t.AssertGroundOnly(), "griffin family");
        var t2 = new MountTable();
        t2.Families["horse"] = new MountFamily { Species = { "mon_griffon" } };
        Assert.Throws<InvalidOperationException>(() => t2.AssertGroundOnly(), "griffon species id");
        var t3 = new MountTable();
        t3.Families["horse"] = new MountFamily { Species = { "mon_drake" } };
        Assert.Throws<InvalidOperationException>(() => t3.AssertGroundOnly(Repo.Db.Species), "dragon species");
    }

    public static void EveryMountSpeciesExistsAndIsGroundBound()
    {
        var t = Load();
        foreach (var kv in t.Families)
            foreach (var id in kv.Value.Species)
            {
                Assert.True(Repo.Db.Species.TryGetValue(id, out var sp), kv.Key + ": missing species " + id);
                Assert.True(sp.Type != "Dragon" && sp.Type != "Avian" && sp.Type != "Aquatic", id + " type " + sp.Type);
                Assert.True(!sp.RigId.Contains("flyer") && !sp.RigId.Contains("wyvern") && !sp.RigId.Contains("dragon") && !sp.RigId.Contains("fish"), id + " rig " + sp.RigId);
                Assert.True(sp.SizeMeters >= 1.2, id + " too small to ride");
            }
    }

    public static void MountedSkillRestrictions()
    {
        var t = Load();
        Assert.True(t.CanUseSkillMounted(new[] { "melee" }, 2.0, 0), "plain melee is fine");
        Assert.True(!t.CanUseSkillMounted(new[] { "big" }), "big banned");
        Assert.True(!t.CanUseSkillMounted(new[] { "melee", "AERIAL" }), "aerial banned (case-insensitive)");
        Assert.True(!t.CanUseSkillMounted(new[] { "channelled" }), "channelled banned");
        Assert.True(!t.CanUseSkillMounted(new[] { "melee" }, t.MountedCombat.MeleeReachCapM + 0.1, 0), "reach cap");
        Assert.True(t.CanUseSkillMounted(new[] { "melee" }, 1.0, t.MountedCombat.MaxChainHits - 1), "last allowed hit");
        Assert.True(!t.CanUseSkillMounted(new[] { "melee" }, 1.0, t.MountedCombat.MaxChainHits), "no chain beyond the limit");
        Assert.True(t.MountedCombat.DamageMult > 0 && t.MountedCombat.DamageMult <= 1.0, "damage multiplier does not buff");
    }

    public static void StaggerDismounts()
    {
        var t = Load();
        var m = new MountState(t.Families["horse"]);
        Assert.True(!m.OnStagger(t), "not mounted: nothing to dismount");
        m.Mount();
        Assert.True(m.Mounted, "mounted");
        Assert.True(m.OnStagger(t), "stagger reports a dismount");
        Assert.True(!m.Mounted, "rider is off");
    }

    public static void InteriorDungeonsBanMounts()
    {
        var t = Load();
        Assert.True(t.MountedCombat.NoMountInterior, "data flag");
        Assert.True(t.CanMount("horse", "F", false), "outdoors");
        Assert.True(!t.CanMount("horse", "S", true), "interior dungeon refuses even an S rank");
    }

    public static void RankGateAndUnknownFamily()
    {
        var t = Load();
        Assert.True(!t.CanMount("large_ground_monster", "C"), "B-gated family needs B");
        Assert.True(t.CanMount("large_ground_monster", "B+"), "B+ counts as B");
        Assert.True(!t.CanMount("griffin", "S"), "unknown family never mountable");
    }

    public static void DefaultSettingsKnockOutOnlyMortalBondsKills()
    {
        var t = Load();
        Assert.True(t.KnockedOutNotKilled, "data flag");
        foreach (var f in t.Families.Values) Assert.True(f.KnockoutOnly, f.Label + " knockoutOnly");
        Assert.True(t.KnockedOutInsteadOfKilled(false), "default: knocked out");
        Assert.True(!t.KnockedOutInsteadOfKilled(true), "Mortal Bonds: may die");
        var m = new MountState(t.Families["wolf"]);
        m.Mount();
        Assert.True(m.OnDefeated(t, false), "knocked out");
        Assert.True(m.KnockedOut && !m.Mounted, "down and rider off");
        m.Mount();
        Assert.True(!m.Mounted, "a knocked-out mount cannot be mounted");
        Assert.True(!new MountState(t.Families["wolf"]).OnDefeated(t, true), "mortal bonds: not just knocked out");
    }

    public static void OldConfigWithoutTableIsSafe()
    {
        var t = MountTable.OrDefault(null);
        Assert.Equal(0.0, t.Speed("horse"), "no families, no speed");
        Assert.True(!t.CanMount("horse", "S"), "nothing rideable");
        Assert.True(t.KnockedOutInsteadOfKilled(false), "safe default knocks out");
        t.AssertGroundOnly();
        var m = new MountState();
        m.Mount();
        m.StepStamina(1.0, true);
        Assert.True(!m.OnStagger(null) == false, "null table still dismounts on stagger by default");
        Assert.True(m.OnDefeated(null, false), "null table knocks out");
    }
}
