using System;
using System.Collections.Generic;
using Ascend.Core;

// Locomotion table (Data/Player/locomotion.json): speed formula, slope, blend thresholds.
[Tests]
static class LocomotionTests
{
    static LocomotionTable Load()
    {
        var t = Repo.Load<LocomotionTable>("Data/Player/locomotion.json");
        t.Validate();
        return t;
    }

    public static void StateSpeedsMatchCombatTuning()
    {
        var t = Load();
        Assert.Near(6.5, t.Speed("run"), 0.01, "run");
        Assert.Near(2.2, t.Speed("walk"), 0.01, "walk");
        Assert.Near(9.5, t.Speed("sprint"), 0.01, "sprint");
        Assert.Near(0.0, t.Speed("idle"), 0.0001, "idle");
        var m = Repo.Load<CombatTuning>("Data/Combat/combat_tuning.json").Movement;
        Assert.Near(m.RunSpeed, t.Speed("run"), 0.01, "run vs combat_tuning");
        Assert.Near(m.WalkSpeed, t.Speed("walk"), 0.01, "walk vs combat_tuning");
        Assert.Near(m.SprintSpeed, t.Speed("sprint"), 0.01, "sprint vs combat_tuning");
    }

    public static void TerrainScalesSpeed()
    {
        var t = Load();
        Assert.Near(6.5 * 0.7, t.Speed("run", "swamp"), 0.0001, "swamp");
        Assert.True(t.Speed("run", "swamp") < t.Speed("run", "plains"), "swamp slower than plains");
    }

    public static void ConditionsMultiply()
    {
        var t = Load();
        Assert.Near(6.5 * 0.75 * 0.95, t.Speed("run", "plains", new[] { "exhausted", "wet" }), 0.0001, "two conditions");
        Assert.Near(6.5, t.Speed("run", "plains", new string[0]), 0.0001, "no conditions");
    }

    public static void UnknownKeysThrow()
    {
        var t = Load();
        Assert.Throws<KeyNotFoundException>(() => t.Speed("crawl"), "unknown state");
        Assert.Throws<KeyNotFoundException>(() => t.Speed("run", "lava"), "unknown terrain");
        Assert.Throws<KeyNotFoundException>(() => t.Speed("run", "plains", new[] { "drunk" }), "unknown condition");
    }

    public static void SlopeMultiplier()
    {
        var t = Load();
        Assert.Near(1.0, t.SlopeMult(0, true), 1e-9, "flat uphill");
        Assert.Near(1.0, t.SlopeMult(0, false), 1e-9, "flat downhill");
        double up = t.SlopeMult(30, true), down = t.SlopeMult(30, false);
        Assert.True(up < 1.0 && up >= t.Slope.MinMult, $"30 deg uphill slows but not below min ({up})");
        Assert.True(down > 1.0 && down <= t.Slope.MaxMult, $"30 deg downhill speeds up but not above max ({down})");
    }

    public static void BlendThresholdsAscend()
    {
        var b = Load().BlendThresholds();
        Assert.Equal(4, b.Length, "four thresholds");
        for (int i = 1; i < b.Length; i++) Assert.True(b[i] > b[i - 1], $"threshold {i} ascends");
        Assert.Near(0.0, b[0], 1e-9, "idle threshold");
    }

    public static void ValidateRejectsBadTables()
    {
        var t = Load();
        t.State.Remove("walk");
        Assert.Throws<InvalidOperationException>(() => t.Validate(), "missing state");
        t = Load();
        t.Terrain.Remove("swamp");
        Assert.Throws<InvalidOperationException>(() => t.Validate(), "missing terrain");
        t = Load();
        t.State["walk"] = 2.0;
        Assert.Throws<InvalidOperationException>(() => t.Validate(), "non-ascending thresholds");
    }
}
