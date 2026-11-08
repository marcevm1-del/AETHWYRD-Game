using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Ascend.Core;

// Housing and farming on the REAL data (Data/World/housing.json, Data/Items/crops.json, recipes, life skills).
[Tests]
static class HousingTests
{
    static LifeSkills Skills(string farmingRank = "F")
    {
        var ls = new LifeSkills(Repo.Db.LifeSkills);
        var s = new LifeSkillSave();
        s.Rank["farming"] = farmingRank;
        ls.Load(s);
        return ls;
    }

    static Home NewHome(string farmingRank = "F", LifeSkills skills = null) =>
        new Home(Repo.Db.Housing, Repo.Db.Crops, Repo.Db.Quality, skills ?? Skills(farmingRank));

    /// <summary>A home already at the given tier (paid for with plenty of money).</summary>
    static Home HomeAt(string tierId, Inventory inv, string farmingRank = "F")
    {
        var h = NewHome(farmingRank);
        foreach (var t in Repo.Db.Housing.Tiers.Skip(1))
        {
            inv.AddCopper(t.Cost);
            Assert.True(h.Upgrade(t.Id, "SSS", inv) == UpgradeResult.Ok, "upgrade to " + t.Id);
            if (t.Id == tierId) break;
        }
        return h;
    }

    public static void TheDataHasFourTiersAndFourCrops()
    {
        Assert.Equal(4, Repo.Db.Housing.Tiers.Count, "tiers");
        Assert.Equal("inn_room", Repo.Db.Housing.Tiers[0].Id, "everyone starts in the inn room");
        Assert.True(Repo.Db.Crops.Crops.Count >= 4, "crops");
        Assert.Equal(0, NewHome().PlotCount, "the inn room has no plots");
    }

    // --- tiers ---
    public static void UpgradesNeedRankMoneyAndOrder()
    {
        var h = NewHome(); var inv = new Inventory();
        Assert.True(h.Upgrade("rented_room", "C", inv) == UpgradeResult.NotEnoughMoney, "no money");
        inv.AddCopper(100000);
        Assert.True(h.Upgrade("rented_room", "D", inv) == UpgradeResult.RankTooLow, "guild rank D is too low for a rank C room");
        Assert.True(h.Upgrade("home_plot", "SSS", inv) == UpgradeResult.NotNext, "one tier at a time");
        Assert.True(h.Upgrade("nope", "SSS", inv) == UpgradeResult.Unknown, "unknown");
        Assert.Equal(100000, inv.Copper, "nothing was charged by any refusal");
        Assert.True(h.Upgrade("rented_room", "C", inv) == UpgradeResult.Ok, "now");
        Assert.Equal(100000 - 800, inv.Copper, "800 copper");
        Assert.True(h.Upgrade("rented_room", "C", inv) == UpgradeResult.AlreadyHere, "already here");
        Assert.True(h.Has("kitchen") && h.Has("storage_chest"), "features");
        Assert.Equal("home_plot", h.NextTier.Id, "next");
    }

    public static void StarterSeedsComeOnceOnly()
    {
        var inv = new Inventory(); var h = HomeAt("rented_room", inv);
        Assert.Equal(3, inv.Count("itm_seed_wheat"), "starter seeds");
        var inv2 = new Inventory(); inv2.AddCopper(1000000);
        h.Upgrade("home_plot", "SSS", inv2); h.Upgrade("manor", "SSS", inv2);
        Assert.Equal(0, inv2.Count("itm_seed_wheat"), "no second pack");
    }

    // --- storage ---
    public static void StorageHoldsStacksAndNeverLosesAnything()
    {
        var inv = new Inventory(); var h = NewHome();
        for (int i = 0; i < 20; i++) inv.Add("itm_t_" + i, 5);
        for (int i = 0; i < 20; i++) Assert.True(h.Deposit("itm_t_" + i, 5, inv) == StorageResult.Ok, "deposit " + i);
        inv.Add("itm_extra");
        Assert.True(h.Deposit("itm_extra", 1, inv) == StorageResult.Full, "the 21st stack does not fit in 20");
        Assert.True(h.Deposit("itm_t_3", 1, inv) == StorageResult.NotEnough, "none left to add to an existing stack");
        inv.Add("itm_t_3", 2);
        Assert.True(h.Deposit("itm_t_3", 2, inv) == StorageResult.Ok, "an existing stack always takes more");
        Assert.True(h.Withdraw("itm_t_3", 7, inv) == StorageResult.Ok && h.Stored("itm_t_3") == 0, "all back out");
        Assert.True(h.Withdraw("itm_t_3", 1, inv) == StorageResult.NotEnough, "nothing left");
        Assert.True(h.Deposit("itm_t_4", 0, inv) == StorageResult.BadCount, "bad count");
        Assert.Equal(7, inv.Count("itm_t_3"), "the seven are in the bag");
        var big = new Inventory(); var home = HomeAt("manor", big);
        big.Add("itm_x@fine", 2); big.Add("itm_x", 2);
        home.Deposit("itm_x@fine", 2, big); home.Deposit("itm_x", 2, big);
        Assert.Equal(2, home.StacksUsed, "quality stacks stay separate");
    }

    // --- farming ---
    public static void CropsGrowInGameHoursAndWaitForeverWithoutWithering()
    {
        var inv = new Inventory(); var h = HomeAt("rented_room", inv);
        Assert.True(h.Plant(0, "crop_turnip", inv, 100) == PlantResult.Ok, "planted");
        Assert.Equal(2, inv.Count("itm_seed_turnip"), "a seed was used");
        Assert.True(h.State(0, 100) == PlotState.Growing && h.State(0, 123.9) == PlotState.Growing, "growing");
        Assert.Near(24, h.HoursLeft(0, 100), 1e-9, "24 hours to go");
        Assert.True(h.Harvest(0, inv, 120).Ok == false, "too early");
        Assert.True(h.State(0, 124) == PlotState.Ready, "ready at exactly 24 hours");
        Assert.True(h.State(0, 100 + 24 * 400) == PlotState.Ready, "still ready after a year away: nothing withers");
        var rep = h.Harvest(0, inv, 100 + 24 * 400);
        Assert.True(rep.Ok, "harvested");
        Assert.Equal(3, inv.Count("itm_crop_turnip"), "exactly the listed yield: no bonus for waiting, no loss");
        Assert.Equal(3, inv.Count("itm_seed_turnip"), "the seed came back");
        Assert.True(rep.XpGained > 0, "farming XP");
        Assert.True(h.State(0, 99999) == PlotState.Empty, "the plot is free again");
    }

    public static void PlantingRefusesBeforeSpendingAnything()
    {
        var inv = new Inventory(); var h = HomeAt("rented_room", inv);
        Assert.True(h.Plant(5, "crop_turnip", inv, 0) == PlantResult.NoSuchPlot, "only one plot here");
        Assert.True(h.Plant(0, "crop_none", inv, 0) == PlantResult.UnknownCrop, "unknown crop");
        Assert.True(h.Plant(0, "crop_mandrake", inv, 0) == PlantResult.NoSeed, "no mandrake seeds");
        h.Plant(0, "crop_turnip", inv, 0);
        Assert.True(h.Plant(0, "crop_wheat", inv, 0) == PlantResult.Occupied, "occupied");
        Assert.Equal(3, inv.Count("itm_seed_wheat"), "the wheat seeds were not used");
        Assert.True(h.Clear(0, inv, 0) && inv.Count("itm_seed_turnip") == 3, "clearing returns the seed, no penalty");
        Assert.True(!h.Clear(0, inv, 0), "nothing to clear");
    }

    public static void HarvestQualityFollowsTheFarmingRankAlone()
    {
        foreach (var (rank, tier) in new[] { ("F", "normal"), ("D", "fine"), ("B", "superior"), ("S", "masterwork") })
        {
            var inv = new Inventory(); var h = HomeAt("rented_room", inv, rank);
            h.Plant(0, "crop_turnip", inv, 0);
            var rep = h.Harvest(0, inv, 24);
            Assert.Equal(tier, rep.Quality, "rank " + rank);
            Assert.Equal(3, inv.Count(ItemQuality.Compose("itm_crop_turnip", tier)), "keyed with its tier");
        }
    }

    public static void HarvestsPayFarmingXpAndCanRankUp()
    {
        var inv = new Inventory(); var sk = Skills("F"); var h = new Home(Repo.Db.Housing, Repo.Db.Crops, Repo.Db.Quality, sk);
        inv.AddCopper(800); h.Upgrade("rented_room", "C", inv);
        long before = sk.Xp("farming");
        for (int n = 0; n < 60; n++) { h.Plant(0, "crop_turnip", inv, n * 24); h.Harvest(0, inv, n * 24 + 24); }
        Assert.True(sk.Xp("farming") > before, "XP grew");
        Assert.True(sk.RankIdx("farming") >= 1, "Farming reached at least rank E");
    }

    public static void HarvestedCropsFeedCookingAndBrewing()
    {
        var inv = new Inventory(); var h = HomeAt("home_plot", inv);
        inv.Add("itm_seed_wheat", 2);
        h.Plant(0, "crop_turnip", inv, 0); h.Plant(1, "crop_wheat", inv, 0); h.Plant(2, "crop_healing_herb", inv, 0);
        foreach (int p in new[] { 0, 1, 2 }) Assert.True(h.Harvest(p, inv, 100).Ok, "plot " + p);
        inv.Add("itm_crop_turnip", 3);
        var ls = new LifeSkills(Repo.Db.LifeSkills);
        var crafter = new Crafter(Repo.Db.Recipes, Repo.Db.Quality, ls);
        crafter.Load(Repo.Db.Recipes.Recipes.Select(r => r.Id));
        Assert.True(crafter.Make("rcp_turnip_mash", inv, null, new MakeOptions { Seed = 1 }).Result == CraftResult.Ok, "turnip mash at a campfire");
        Assert.True(crafter.Make("rcp_garden_stew", inv, "npc_marta_gruel", new MakeOptions { Seed = 1 }).Result == CraftResult.Ok, "garden stew at the hearth");
        Assert.True(crafter.Make("rcp_harvest_ale", inv, "npc_marta_gruel", new MakeOptions { Seed = 1 }).Result == CraftResult.Ok, "harvest ale at the brewery");
        Assert.True(Repo.Db.Items["itm_garden_stew"].Meal != null, "the stew is a real meal");
    }

    public static void NoSequenceOfFarmingActionsLosesOrMakesSeeds()
    {
        var inv = new Inventory(); var h = HomeAt("home_plot", inv);
        var rng = new System.Random(11); double now = 0; int harvests = 0;
        int Seeds() => inv.Count("itm_seed_turnip") + Enumerable.Range(0, h.PlotCount).Count(p => h.CropOf(p) == "crop_turnip");
        int baseline = Seeds();
        for (int n = 0; n < 400; n++)
        {
            now += rng.Next(0, 30);
            int p = rng.Next(4);
            switch (rng.Next(3))
            {
                case 0: h.Plant(p, "crop_turnip", inv, now); break;
                case 1: if (h.Harvest(p, inv, now).Ok) harvests++; break;
                default: h.Clear(p, inv, now); break;
            }
            Assert.Equal(baseline, Seeds(), "seeds are conserved (the harvest returns the one planted), step " + n);
        }
    }

    // --- saves ---
    public static void HomeSurvivesASaveAndOldSavesGetTheInnRoom()
    {
        var inv = new Inventory(); var h = HomeAt("home_plot", inv);
        h.Plant(1, "crop_wheat", inv, 50);
        inv.Add("itm_rune_ember", 3); h.Deposit("itm_rune_ember", 3, inv);
        var save = new SaveGame { Home = h.Save() };
        var back = SaveRules.Upgrade(JsonSerializer.Deserialize<SaveGame>(JsonSerializer.Serialize(save)));
        var g = NewHome(); g.Load(back.Home);
        Assert.Equal("home_plot", g.Tier.Id, "tier");
        Assert.Equal(4, g.PlotCount, "plots");
        Assert.Equal("crop_wheat", g.CropOf(1), "the planted crop");
        Assert.True(g.State(1, 50 + 36) == PlotState.Ready && g.State(1, 50 + 35) == PlotState.Growing, "timer kept");
        Assert.Equal(3, g.Stored("itm_rune_ember"), "storage");

        var old = SaveRules.Upgrade(JsonSerializer.Deserialize<SaveGame>("{\"Version\":1,\"Level\":2}"));
        Assert.True(old.Home != null && SaveRules.Validate(old).Count == 0, "an old save validates and gets a Home");
        var k = NewHome(); k.Load(old.Home); k.Load(null);
        Assert.Equal("inn_room", k.Tier.Id, "old saves start in the inn room");
    }

    public static void LoadNeverDropsWhatThePlayerOwns()
    {
        var g = NewHome();
        g.Load(new HomeSave
        {
            Tier = "castle",
            Plots = new List<PlotSave> { null, new PlotSave { Crop = "crop_gone", PlantedHour = 5 }, new PlotSave { Crop = "crop_wheat", PlantedHour = double.NaN } },
            Storage = new Dictionary<string, int> { ["a"] = -3, [""] = 2, ["itm_ok"] = 4 }
        });
        Assert.Equal("castle", g.Tier.Id, "an unknown tier id is kept, not downgraded");
        Assert.Equal(1, g.StacksUsed, "only the invalid stacks go");
        Assert.Equal("crop_gone", g.CropOf(1), "an unknown crop stays in its plot");
        Assert.True(g.CropOf(2) == null, "a plot with a nonsense hour is emptied");

        var many = new HomeSave { Tier = "inn_room" };
        for (int i = 0; i < 50; i++) many.Storage["itm_k" + i] = 1;
        var h = NewHome(); h.Load(many);
        Assert.Equal(50, h.StacksUsed, "50 stacks survive even in a 20-stack tier");
        var inv = new Inventory(); inv.Add("itm_new");
        Assert.True(h.Deposit("itm_new", 1, inv) == StorageResult.Full, "but nothing new fits");
    }

    public static void ClearRefusesARipeCropAndAClockThatRanBack()
    {
        var inv = new Inventory(); var h = HomeAt("rented_room", inv);
        h.Plant(0, "crop_turnip", inv, 100);
        Assert.True(!h.Clear(0, inv, 200), "a ripe crop is harvested, not cleared");
        Assert.Near(24, h.HoursLeft(0, 10), 1e-9, "a clock that ran back counts as just planted");
    }

    public static void EdgeNumbersNeverDestroyAnything()
    {
        var inv = new Inventory(); var h = HomeAt("rented_room", inv);
        Assert.True(h.Plant(0, "crop_turnip", inv, double.NaN) == PlantResult.BadTime, "NaN hour refused");
        Assert.True(h.Plant(0, "crop_turnip", inv, double.PositiveInfinity) == PlantResult.BadTime, "infinite hour refused");
        Assert.Equal(3, inv.Count("itm_seed_turnip"), "no seed was spent");
        var big = new Inventory(); big.Add("itm_big", int.MaxValue);
        Assert.True(h.Deposit("itm_big", int.MaxValue, big) == StorageResult.Ok, "a huge stack goes in");
        big.Add("itm_big", 1);
        Assert.True(h.Deposit("itm_big", 1, big) == StorageResult.Full && big.Count("itm_big") == 1, "a stack never wraps negative; nothing moved");
        Assert.True(h.Withdraw("itm_big", 5, big) == StorageResult.Ok && h.Stored("itm_big") == int.MaxValue - 5, "normal withdraw works");
    }
}
