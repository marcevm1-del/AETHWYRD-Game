using System.Collections.Generic;
using Ascend.Core;

// Inventory, money display in the canonical currency, death penalties (systems.md §10).
[Tests]
static class InventoryTests
{
    static CurrencyTuning Cur => Repo.Db.World.Currency;

    public static void ItemsStackAndRemove()
    {
        var inv = new Inventory();
        inv.Add("itm_mat_goblin_ear", 2); inv.Add("itm_mat_goblin_ear");
        Assert.Equal(3, inv.Count("itm_mat_goblin_ear"), "stacks");
        Assert.True(inv.TryRemove("itm_mat_goblin_ear", 3), "removes");
        Assert.True(!inv.Items.ContainsKey("itm_mat_goblin_ear"), "an empty stack disappears");
        Assert.True(!inv.TryRemove("itm_mat_goblin_ear"), "can't remove what you don't have");
    }

    public static void MoneyDisplaysWithChange()
    {
        Assert.Equal("1 silver, 28 copper", Money.Format(128, Cur), "128 copper (the doc's example)");
        Assert.Equal("5 silver, 12 copper", Money.Format(512, Cur), "512 copper");
        Assert.Equal("1 gold, 1 copper", Money.Format(10_001, Cur), "zero parts are omitted");
        Assert.Equal("0 copper", Money.Format(0, Cur), "nothing");
        Assert.Equal("1 mithril coin", Money.Format(100_000_000, Cur), "the top coin");
    }

    public static void AdventurerDropsTenPercentStoryDropsNothing()
    {
        var inv = new Inventory(); inv.AddCopper(1000);
        var p = DeathRules.Apply(Difficulty.Adventurer, inv, null);
        Assert.Equal(100L, p.DroppedCopper, "10% dropped");
        Assert.Equal(900L, inv.Copper, "90% kept");
        var story = new Inventory(); story.AddCopper(1000);
        Assert.Equal(0L, DeathRules.Apply(Difficulty.Story, story, null).DroppedCopper, "Story: no loss");
        Assert.True(DeathRules.Apply(Difficulty.Hardcore, new Inventory(), null).Permadeath, "Hardcore: permadeath");
    }

    public static void VeteranAlsoLosesXpButNeverALevel()
    {
        var prog = new PlayerProgress(Repo.Db.Progression);
        prog.AddXp(prog.ToNext / 2);
        long before = prog.XpIntoLevel;
        var p = DeathRules.Apply(Difficulty.Veteran, new Inventory(), prog);
        Assert.Equal((long)System.Math.Floor(before * 0.05), p.XpLost, "5% of the XP toward the next level");
        Assert.Equal(1, prog.Level, "never a level-down");
    }

    public static void KillsGiveLootFromTheSpeciesTable()
    {
        var goblin = Repo.Db.Species["mon_goblin"];
        var drops = LootRoller.Roll(Repo.Db.LootTables[goblin.LootTableId], new DeterministicRandom(5));
        Assert.True(drops.Exists(d => d.ItemId == "itm_core_f"), "a goblin always drops an F core");
        var inv = new Inventory();
        foreach (var d in drops) inv.Add(d.ItemId, d.Count);
        Assert.Equal(1, inv.Count("itm_core_f"), "one core");
    }
}
