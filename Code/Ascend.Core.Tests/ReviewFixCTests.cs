using System.Collections.Generic;
using System.Linq;
using Ascend.Core;

// Phase 1 code review fixes: quality-suffixed keys resolve to their base item, materials count every quality, commissions have a way up, loads replace.
[Tests]
static class ReviewFixCTests
{
    public static void QualityKeysResolveToTheirBaseItem()
    {
        var first = Repo.Db.Items.Values.First();
        Assert.True(ItemQuality.TryGetItem(Repo.Db.Items, first.Id, out var plain) && plain.Id == first.Id, "a plain id resolves");
        Assert.True(ItemQuality.TryGetItem(Repo.Db.Items, first.Id + "@fine", out var fine) && fine.Id == first.Id, "itm@fine resolves to itm");
        Assert.True(!ItemQuality.TryGetItem(Repo.Db.Items, "itm_no_such_thing@fine", out _), "unknown base is false");
        Assert.True(!ItemQuality.TryGetItem(Repo.Db.Items, null, out _) && !ItemQuality.TryGetItem(null, first.Id, out _), "null key or table is false");
    }

    public static void ShopPricesAndSellsAQualityStackLikeItsBaseItem()
    {
        var shop = Repo.Db.Shops.Values.FirstOrDefault(s => s.Buys.Categories.Count > 0 && s.Buys.Rate > 0);
        if (shop == null) return;
        var item = Repo.Db.Items.Values.FirstOrDefault(i => i.Category != "key" && shop.Buys.Categories.Contains(i.Category) && (long)(i.Value * shop.Buys.Rate) > 0);
        if (item == null) return;
        var s = new Shop(shop, Repo.Db.Items);
        var inv = new Inventory(); inv.Add(item.Id + "@fine", 1);
        Assert.Equal(s.SellPrice(item.Id), s.SellPrice(item.Id + "@fine"), "same price as the base item");
        Assert.True(s.Sell(item.Id + "@fine", inv, new HashSet<string> { item.Id }) == TradeResult.Protected, "a quest-protected base id protects its quality stacks");
        Assert.True(s.Sell(item.Id + "@fine", inv) == TradeResult.Ok && inv.CountAll(item.Id) == 0, "the quality stack sells");
    }

    public static void MaterialsCountEveryQualityStack()
    {
        var inv = new Inventory(); inv.Add("itm_t_ore", 1); inv.Add("itm_t_ore@fine", 1);
        Assert.Equal(2, inv.CountAll("itm_t_ore"), "CountAll adds the stacks");
        var c = CraftKit.Crafter(("blacksmithing", "F"));
        var r = c.Recipe("rcp_t_blade");
        Assert.Equal(0, c.Missing(r, inv).Count, "Missing counts every quality");
        Assert.True(c.CanCraft("rcp_t_blade", inv, CraftKit.Smith) == CraftResult.Ok, "CanCraft counts every quality");
        Assert.True(c.CanMake("rcp_t_blade", inv, CraftKit.Smith) == CraftResult.Ok, "CanMake agrees");
        var onlyFine = CraftKit.Inv(("itm_t_ore@fine", 2));
        Assert.True(c.CanCraft("rcp_t_blade", onlyFine, CraftKit.Smith) == CraftResult.Ok, "a bag with only fine ore can craft");
        Assert.True(c.Craft("rcp_t_blade", onlyFine, CraftKit.Smith) == CraftResult.Ok && onlyFine.CountAll("itm_t_ore") == 0, "Craft consumes the quality stacks");
        var three = CraftKit.Inv(("itm_t_ore", 1), ("itm_t_ore@fine", 2));
        Assert.True(three.TryRemoveAll("itm_t_ore", 2) && three.Count("itm_t_ore") == 0 && three.Count("itm_t_ore@fine") == 1, "TryRemoveAll takes Normal first");
        Assert.True(!three.TryRemoveAll("itm_t_ore", 5) && three.CountAll("itm_t_ore") == 1, "too few removes nothing");
    }

    public static void ACommissionCanBeHandedInWithAFinishedPiece()
    {
        var skills = new LifeSkills(Repo.Db.LifeSkills);
        var save = new LifeSkillSave();
        save.Rank["blacksmithing"] = "E"; save.Xp["blacksmithing"] = 1_000_000;
        skills.Load(save);
        var c = new Crafter(CraftKit.Recipes(), Repo.Db.Quality, skills);
        Assert.True(skills.Eligible("blacksmithing"), "the XP is in, the commission is pending");
        var none = CraftKit.Inv(("itm_t_ore", 5));
        Assert.True(c.CommissionPiece("blacksmithing", none) == null && c.HandInCommission("blacksmithing", none) == null, "no finished piece, nothing happens");
        Assert.Equal("E", skills.Rank("blacksmithing"), "still E");
        var inv = CraftKit.Inv(("itm_t_blade", 1), ("itm_t_ore", 5));
        Assert.Equal("itm_t_blade", c.CommissionPiece("blacksmithing", inv), "the blade qualifies");
        Assert.Equal("D", c.HandInCommission("blacksmithing", inv), "promoted to D");
        Assert.Equal(0, inv.Count("itm_t_blade"), "the piece is taken");
        Assert.True(c.CommissionPiece("blacksmithing", inv) == null, "nothing pending any more");
    }

    public static void ResetThenLoadReplacesInsteadOfMerging()
    {
        var a = new CivilizationArchive(Repo.Db.Archive);
        a.Hear("ent_glass_circles");
        var other = new CivilizationArchive(Repo.Db.Archive);
        other.Hear("ent_valdrisian_roads");
        a.Reset(); a.Load(other.Save());
        Assert.Equal(MapStatus.Unknown, a.Status("ent_glass_circles"), "the earlier archive knowledge is gone");
        Assert.Equal(MapStatus.Heard, a.Status("ent_valdrisian_roads"), "the loaded one is there");
        a.Reset();
        Assert.Equal(0, a.Visited.Count() + a.Heard.Count(), "Reset empties it");

        var d = Repo.Db.Dungeons["dng_salvage_warren"];
        var k = new DungeonKnowledge(d); k.VisitRoom("rm_scrap_hall"); k.Cleared = true;
        k.Reset(); k.Load(new DungeonProgressSave());
        Assert.Equal(MapStatus.Unknown, k.StatusOfRoom("rm_scrap_hall"), "dungeon room forgotten");
        Assert.True(!k.Cleared, "cleared flag forgotten");

        var lab = new Labyrinth(Repo.Load<LabyrinthData>("Data/World/labyrinth.json"));
        var lk = new LabyrinthKnowledge(lab);
        var startHeard = lk.Save().Floors.Count;
        lk.VisitFloor(7); lk.FindStair("stair_100_101");
        lk.Reset(); lk.Load(new LabyrinthSave());
        Assert.Equal(MapStatus.Unknown, lk.StatusOfFloor(7), "labyrinth floor forgotten");
        Assert.Equal(0, lk.Deepest, "deepest reset");
        Assert.Equal(startHeard, lk.Save().Floors.Count, "back to the start rumours only");
        Assert.Equal(0, lk.Save().Stairs.Count, "stairs forgotten");
    }
}
