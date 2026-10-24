using System.Linq;
using Ascend.Core;

// The Bestiary (hud_and_ui.md §9; world_tuning.json bestiary).
[Tests]
static class BestiaryTests
{
    static Bestiary New() => new Bestiary(Repo.Db, Repo.Db.World.Bestiary);

    public static void TiersFillWithSightingsAndKills()
    {
        var b = New();
        Assert.Equal(0, b.Tier("mon_goblin"), "never seen: ???");
        Assert.True(b.See("mon_goblin") && !b.See("mon_goblin"), "a new entry once");
        Assert.Equal(1, b.Tier("mon_goblin"), "seen: name and rank");
        Assert.True(b.Kill("mon_goblin") == null && b.Kill("mon_goblin") == null, "not yet");
        Assert.Equal(2, b.Kill("mon_goblin") ?? -1, "third kill: tier 2 (HP, element, weakness)");
        for (int i = 0; i < 7; i++) b.Kill("mon_goblin");
        Assert.Equal(3, b.Tier("mon_goblin"), "ten kills: full entry");
    }

    public static void TamingFillsToTierThree()
    {
        var b = New();
        b.Tame("mon_horned_rabbit");
        Assert.Equal(3, b.Tier("mon_horned_rabbit"), "systems.md §7.4");
    }

    public static void TheStampNeedsEveryDrop()
    {
        var b = New();
        b.Tame("mon_blue_slime");
        var drops = b.PossibleDrops("mon_blue_slime");
        Assert.True(drops.Contains("itm_core_f"), "slimes drop F cores");
        Assert.True(!b.Stamped("mon_blue_slime"), "drops not found yet");
        foreach (var d in drops) b.Drop("mon_blue_slime", d);
        Assert.True(b.Stamped("mon_blue_slime"), "stamped");
        Assert.Equal(0.5, b.Completion(new[] { "mon_blue_slime", "mon_goblin" }), "half of two");
    }

    public static void SavesRoundTrip()
    {
        var b = New();
        b.Kill("mon_goblin"); b.Drop("mon_goblin", "itm_core_f");
        var c = New();
        c.Load(b.Save().Concat(new[] { new BestiaryEntry { SpeciesId = "mon_not_real" } }));
        Assert.Equal(1, c.Entries["mon_goblin"].Kills, "kills kept");
        Assert.True(!c.Entries.ContainsKey("mon_not_real"), "unknown species dropped");
    }
}
