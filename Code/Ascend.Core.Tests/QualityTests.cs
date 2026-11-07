using System.Collections.Generic;
using System.Linq;
using Ascend.Core;

/// <summary>Inline fixtures for the crafting quality, life skill and meal tests (does not depend on recipes.json / items.json rows).</summary>
static class CraftKit
{
    public const string Smith = "npc_t_smith";

    public static RecipeFile Recipes()
    {
        var f = new RecipeFile();
        f.Stations["forge"] = Smith;
        f.Stations["campfire"] = null;
        f.Stations["hearth"] = null;
        f.Recipes.Add(new RecipeData
        {
            Id = "rcp_t_blade", Name = "Test Blade", Skill = "blacksmithing", Station = "forge", AttuneItem = "itm_t_flux",
            Output = new ItemCount { ItemId = "itm_t_blade", Count = 1 },
            Inputs = new List<ItemCount> { new ItemCount { ItemId = "itm_t_ore", Count = 2 } }
        });
        f.Recipes.Add(new RecipeData
        {
            Id = "rcp_t_big", Name = "Test Big Blade", Skill = "blacksmithing", Station = "forge",
            Output = new ItemCount { ItemId = "itm_t_big", Count = 1 },
            Inputs = new List<ItemCount> { new ItemCount { ItemId = "itm_t_ore", Count = 4 } }
        });
        // The attune item is also an input: attuning needs one more unit than the recipe uses.
        f.Recipes.Add(new RecipeData
        {
            Id = "rcp_t_ring", Name = "Test Ring", Skill = "blacksmithing", Station = "forge", AttuneItem = "itm_t_ore",
            Output = new ItemCount { ItemId = "itm_t_ring", Count = 1 },
            Inputs = new List<ItemCount> { new ItemCount { ItemId = "itm_t_ore", Count = 2 } }
        });
        f.Recipes.Add(new RecipeData
        {
            Id = "rcp_t_hi", Name = "Test Rank D Blade", Skill = "blacksmithing", Station = "forge", LifeRank = "D",
            Output = new ItemCount { ItemId = "itm_t_hi", Count = 1 },
            Inputs = new List<ItemCount> { new ItemCount { ItemId = "itm_t_ore", Count = 2 } }
        });
        f.Recipes.Add(new RecipeData
        {
            Id = "rcp_t_stew", Name = "Test Stew", Skill = "cooking", Station = "campfire",
            Output = new ItemCount { ItemId = "itm_t_stew", Count = 1 },
            Inputs = new List<ItemCount> { new ItemCount { ItemId = "itm_t_meat", Count = 2 } }
        });
        f.Recipes.Add(new RecipeData
        {
            Id = "rcp_t_feast", Name = "Test Feast", Skill = "cooking", Station = "hearth",
            Output = new ItemCount { ItemId = "itm_t_feast", Count = 1 },
            Inputs = new List<ItemCount> { new ItemCount { ItemId = "itm_t_meat", Count = 2 } }
        });
        f.Recipes.Add(new RecipeData
        {
            Id = "rcp_t_mystery", Name = "Unknown Skill", Skill = "mystery_skill", Station = "campfire",
            Output = new ItemCount { ItemId = "itm_t_mystery", Count = 1 },
            Inputs = new List<ItemCount> { new ItemCount { ItemId = "itm_t_meat", Count = 1 } }
        });
        f.Recipes.Add(new RecipeData
        {
            Id = "rcp_t_xp40", Name = "Big XP", Skill = "blacksmithing", Station = "forge", Xp = 40,
            Output = new ItemCount { ItemId = "itm_t_xp", Count = 1 },
            Inputs = new List<ItemCount> { new ItemCount { ItemId = "itm_t_ore", Count = 1 } }
        });
        f.Recipes.Add(new RecipeData
        {
            Id = "rcp_t_xp2", Name = "Tiny XP", Skill = "blacksmithing", Station = "forge", Xp = 2,
            Output = new ItemCount { ItemId = "itm_t_xp2", Count = 1 },
            Inputs = new List<ItemCount> { new ItemCount { ItemId = "itm_t_ore", Count = 1 } }
        });
        return f;
    }

    /// <summary>Skills at the given ranks, e.g. Skills(("blacksmithing", "B")).</summary>
    public static LifeSkills Skills(params (string skill, string rank)[] ranks)
    {
        var ls = new LifeSkills(Repo.Db.LifeSkills);
        var s = new LifeSkillSave();
        foreach (var (skill, rank) in ranks) s.Rank[skill] = rank;
        ls.Load(s);
        return ls;
    }

    public static Crafter Crafter(params (string skill, string rank)[] ranks) =>
        new Crafter(Recipes(), Repo.Db.Quality, Skills(ranks));

    public static Inventory Inv(params (string key, int n)[] stacks)
    {
        var inv = new Inventory();
        foreach (var (k, n) in stacks) inv.Add(k, n);
        return inv;
    }

    public static Dictionary<string, int> Snapshot(Inventory inv) => inv.Items.ToDictionary(kv => kv.Key, kv => kv.Value);

    public static bool SameInventory(Dictionary<string, int> a, Inventory inv)
    {
        var b = Snapshot(inv);
        return a.Count == b.Count && a.All(kv => b.TryGetValue(kv.Key, out var n) && n == kv.Value);
    }

    /// <summary>Every quality the craft can give over many craft counters (jitter varies, the rest is fixed).</summary>
    public static HashSet<string> Outcomes(string recipe, string rank, string oreKey, bool attune = false, string skill = "blacksmithing", string npc = Smith, string meat = null, int counters = 60)
    {
        var set = new HashSet<string>();
        for (int c = 0; c < counters; c++)
        {
            var cr = Crafter((skill, rank));
            var inv = meat != null ? Inv((meat, 4), ("itm_t_flux", 2)) : Inv((oreKey, 8), ("itm_t_flux", 2));
            var rep = cr.Make(recipe, inv, npc, new MakeOptions { Attune = attune, Seed = 77, CraftCounter = c });
            Assert.True(rep.Result == CraftResult.Ok, "craft should start: " + rep.Result);
            set.Add(rep.Quality);
        }
        return set;
    }

    public static void Only(HashSet<string> got, string expected, string what) =>
        Assert.True(got.Count == 1 && got.Contains(expected), $"{what}: expected only {expected}, got {string.Join(",", got)}");
}

// Quality tiers, stack keys and the crafting quality formula (crafting_v6_audit.md section 3.1).
[Tests]
static class QualityTests
{
    public static void ComposeAndSplitRoundTripEveryTier()
    {
        foreach (var t in Repo.Db.Quality.QualityTiers)
        {
            var key = ItemQuality.Compose("itm_t_ore", t.Id);
            var (id, tier) = ItemQuality.Split(key);
            Assert.Equal("itm_t_ore", id, "item id back");
            Assert.Equal(t.Id, tier, "tier back");
        }
        Assert.Equal("itm_t_ore@fine", ItemQuality.Compose("itm_t_ore", "fine"), "non-normal key");
    }

    public static void NormalIsThePlainIdAndOldKeysStayNormal()
    {
        Assert.Equal("itm_t_ore", ItemQuality.Compose("itm_t_ore", "normal"), "normal composes to the plain id");
        Assert.Equal("itm_t_ore", ItemQuality.Compose("itm_t_ore", null), "no tier is normal");
        var (id, tier) = ItemQuality.Split("itm_fangblade");
        Assert.True(id == "itm_fangblade" && tier == "normal", "a plain id (old save) is Normal");
        Assert.Equal("itm_fangblade", ItemQuality.BaseId("itm_fangblade@masterwork"), "BaseId strips the tier");
    }

    public static void RulesLoadFromTheDataFile()
    {
        var q = Repo.Db.Quality;
        Assert.Equal(6, q.QualityTiers.Count, "poor..legendary");
        Assert.Near(1.06, q.StatMult("fine"), 1e-9, "fine stat");
        Assert.Near(5, q.ValueMult("masterwork"), 1e-9, "masterwork value");
        Assert.Near(0.8, q.BuffMult("poor"), 1e-9, "poor buff");
        Assert.True(q.Mark("fine") && !q.Mark("normal") && !q.Mark("poor"), "mark from Fine up");
        Assert.True(q.Nameable("masterwork") && !q.Nameable("superior"), "nameable at Masterwork");
        Assert.True(q.Tier("legendary") != null && !q.Tier("legendary").Craftable, "legendary is never crafted");
        Assert.Equal(4, q.MaxCraftableIndex, "Masterwork is the highest craft");
        Assert.Equal(1, q.RankCapIndex("F"), "F caps at Normal");
        Assert.Equal(4, q.RankCapIndex("A"), "A caps at Masterwork");
        Assert.Equal(1, q.StationCapIndex("campfire"), "campfire caps at Normal");
    }

    public static void SameSeedAndCounterGiveTheSameCraft()
    {
        for (int c = 0; c < 20; c++)
        {
            var a = CraftKit.Crafter(("blacksmithing", "B")).Make("rcp_t_blade", CraftKit.Inv(("itm_t_ore", 2)), CraftKit.Smith, new MakeOptions { Seed = 5, CraftCounter = c });
            var b = CraftKit.Crafter(("blacksmithing", "B")).Make("rcp_t_blade", CraftKit.Inv(("itm_t_ore", 2)), CraftKit.Smith, new MakeOptions { Seed = 5, CraftCounter = c });
            Assert.True(a.Quality == b.Quality && a.OutputKey == b.OutputKey && a.Mark == b.Mark, "deterministic");
        }
    }

    public static void JitterOnlyPushesUpAndNeverBelowTheBase()
    {
        // Normal ore at rank B scores exactly 2.0 before jitter; jitter is 0..0.2 so it can never drop below Fine nor reach Superior.
        CraftKit.Only(CraftKit.Outcomes("rcp_t_blade", "B", "itm_t_ore", counters: 200), "fine", "Normal ore, rank B");
    }

    public static void NormalIngredientsGiveNormalToRankCAndFineAtB()
    {
        foreach (var rank in new[] { "F", "E", "D", "C" })
            CraftKit.Only(CraftKit.Outcomes("rcp_t_blade", rank, "itm_t_ore"), "normal", "Normal ore, rank " + rank);
        CraftKit.Only(CraftKit.Outcomes("rcp_t_blade", "B", "itm_t_ore"), "fine", "Normal ore, rank B");
    }

    public static void NormalIngredientsNeverGoAboveFine()
    {
        foreach (var rank in new[] { "A", "S", "SS", "SSS" })
            CraftKit.Only(CraftKit.Outcomes("rcp_t_blade", rank, "itm_t_ore"), "fine", "Normal ore, rank " + rank);
        CraftKit.Only(CraftKit.Outcomes("rcp_t_blade", "SSS", "itm_t_ore", attune: true), "fine", "attuned Normal ore, rank SSS");
    }

    public static void AttunementLiftsARankDCraftToFine()
    {
        CraftKit.Only(CraftKit.Outcomes("rcp_t_blade", "D", "itm_t_ore"), "normal", "not attuned");
        CraftKit.Only(CraftKit.Outcomes("rcp_t_blade", "D", "itm_t_ore", attune: true), "fine", "attuned at D");
        CraftKit.Only(CraftKit.Outcomes("rcp_t_blade", "F", "itm_t_ore", attune: true), "normal", "attuned at F stays Normal");
    }

    public static void FineIngredientsGiveFineAtDAndSuperiorAtB()
    {
        CraftKit.Only(CraftKit.Outcomes("rcp_t_blade", "D", "itm_t_ore@fine"), "fine", "Fine ore, rank D");
        CraftKit.Only(CraftKit.Outcomes("rcp_t_blade", "B", "itm_t_ore@fine"), "superior", "Fine ore, rank B");
    }

    public static void SuperiorIngredientsGiveMasterworkAtAAndSuperiorAtB()
    {
        CraftKit.Only(CraftKit.Outcomes("rcp_t_blade", "A", "itm_t_ore@superior"), "masterwork", "Superior ore, rank A");
        CraftKit.Only(CraftKit.Outcomes("rcp_t_blade", "B", "itm_t_ore@superior"), "superior", "Superior ore, rank B (rank cap)");
        var cr = CraftKit.Crafter(("blacksmithing", "A"));
        var inv = CraftKit.Inv(("itm_t_ore@superior", 2));
        var rep = cr.Make("rcp_t_blade", inv, CraftKit.Smith, new MakeOptions { Seed = 1 });
        Assert.Equal("itm_t_blade@masterwork", rep.OutputKey, "key carries the tier");
        Assert.Equal(1, inv.Count("itm_t_blade@masterwork"), "in the bag under that key");
        Assert.True(rep.Mark && rep.Nameable, "Masterwork has the mark and can be named");
    }

    public static void PoorIngredientsAtRankFStayPoorAndStillMakeSomething()
    {
        CraftKit.Only(CraftKit.Outcomes("rcp_t_blade", "F", "itm_t_ore@poor"), "poor", "Poor ore, rank F");
        var rep = CraftKit.Crafter(("blacksmithing", "F")).Make("rcp_t_blade", CraftKit.Inv(("itm_t_ore@poor", 2)), CraftKit.Smith);
        Assert.True(rep.Result == CraftResult.Ok && rep.OutputKey == "itm_t_blade@poor" && !rep.Mark, "Poor, no mark, never nothing");
    }

    public static void PoorIngredientsCanBeLiftedButOnlyOneTierAboveTheBest()
    {
        // Poor ore (0) + rank B (+1.0) scores 1.0 and the cap is best+1 = Normal.
        CraftKit.Only(CraftKit.Outcomes("rcp_t_blade", "B", "itm_t_ore@poor"), "normal", "Poor ore, rank B");
        CraftKit.Only(CraftKit.Outcomes("rcp_t_blade", "SSS", "itm_t_ore@poor", attune: true), "normal", "Poor ore, attuned, SSS");
    }

    public static void CampfireCapsAtNormalButTheHearthDoesNot()
    {
        CraftKit.Only(CraftKit.Outcomes("rcp_t_stew", "B", null, skill: "cooking", npc: null, meat: "itm_t_meat@fine"), "normal", "campfire, Fine meat, rank B");
        CraftKit.Only(CraftKit.Outcomes("rcp_t_feast", "B", null, skill: "cooking", npc: null, meat: "itm_t_meat@fine"), "superior", "hearth, Fine meat, rank B");
        CraftKit.Only(CraftKit.Outcomes("rcp_t_stew", "SSS", null, skill: "cooking", npc: null, meat: "itm_t_meat@superior"), "normal", "campfire never above Normal");
    }

    public static void ForgeIsNotCapped()
    {
        CraftKit.Only(CraftKit.Outcomes("rcp_t_blade", "A", "itm_t_ore@superior"), "masterwork", "forge reaches Masterwork");
    }

    public static void ARefusedCraftNeverTouchesTheMaterials()
    {
        var cr = CraftKit.Crafter(("blacksmithing", "F"));
        var inv = CraftKit.Inv(("itm_t_ore@fine", 3), ("itm_t_ore", 1));
        var before = CraftKit.Snapshot(inv);
        Assert.True(cr.Make("rcp_t_big", inv, "npc_other").Result == CraftResult.WrongStation, "wrong station");
        Assert.True(cr.Make("rcp_t_hi", inv, CraftKit.Smith).Result == CraftResult.RankTooLow, "rank too low");
        Assert.True(cr.Make("rcp_t_nope", inv, CraftKit.Smith).Result == CraftResult.Unknown, "unknown recipe");
        var poor = CraftKit.Inv(("itm_t_ore", 3));
        var poorBefore = CraftKit.Snapshot(poor);
        var rep = cr.Make("rcp_t_big", poor, CraftKit.Smith);
        Assert.True(rep.Result == CraftResult.MissingMaterials && rep.OutputKey == null, "short of ore");
        Assert.True(CraftKit.SameInventory(before, inv), "nothing lost on refusals");
        Assert.True(CraftKit.SameInventory(poorBefore, poor), "nothing lost when short");
    }

    public static void AttuneNeedsTheExtraItemAndConsumesNothingWithout()
    {
        var cr = CraftKit.Crafter(("blacksmithing", "D"));
        var inv = CraftKit.Inv(("itm_t_ore", 2));
        var before = CraftKit.Snapshot(inv);
        var rep = cr.Make("rcp_t_blade", inv, CraftKit.Smith, new MakeOptions { Attune = true });
        Assert.True(rep.Result == CraftResult.MissingMaterials, "no flux");
        Assert.True(CraftKit.SameInventory(before, inv), "nothing consumed");
        // A recipe with no attuneItem cannot be attuned either.
        var inv2 = CraftKit.Inv(("itm_t_ore", 4), ("itm_t_flux", 1));
        var before2 = CraftKit.Snapshot(inv2);
        Assert.True(cr.Make("rcp_t_big", inv2, CraftKit.Smith, new MakeOptions { Attune = true }).Result == CraftResult.MissingMaterials, "nothing to attune with");
        Assert.True(CraftKit.SameInventory(before2, inv2), "still nothing consumed");
        // With the flux: exactly the inputs plus one flux.
        var inv3 = CraftKit.Inv(("itm_t_ore", 2), ("itm_t_flux", 3));
        var ok = cr.Make("rcp_t_blade", inv3, CraftKit.Smith, new MakeOptions { Attune = true });
        Assert.True(ok.Result == CraftResult.Ok, "attuned craft");
        Assert.Equal(0, inv3.Count("itm_t_ore"), "ore used");
        Assert.Equal(2, inv3.Count("itm_t_flux"), "one flux spent");
    }

    public static void AnAttuneItemThatIsAlsoAnInputNeedsOneMoreUnit()
    {
        var cr = CraftKit.Crafter(("blacksmithing", "D"));
        var inv = CraftKit.Inv(("itm_t_ore", 2));
        Assert.True(cr.Make("rcp_t_ring", inv, CraftKit.Smith, new MakeOptions { Attune = true }).Result == CraftResult.MissingMaterials, "two ore is not three");
        Assert.Equal(2, inv.Count("itm_t_ore"), "untouched");
        inv.Add("itm_t_ore", 1);
        var rep = cr.Make("rcp_t_ring", inv, CraftKit.Smith, new MakeOptions { Attune = true });
        Assert.True(rep.Result == CraftResult.Ok && rep.Quality == "fine", "three ore attunes it");
        Assert.Equal(0, inv.Count("itm_t_ore"), "all three used");
    }

    public static void MixedQualityStacksUseTheCountWeightedMean()
    {
        // 1 Fine + 3 Normal = mean 1.25; rank D adds 0.5 -> 1.75 -> Normal. An unweighted stack mean (1.5) would reach Fine.
        var cr = CraftKit.Crafter(("blacksmithing", "D"));
        var inv = CraftKit.Inv(("itm_t_ore@fine", 1), ("itm_t_ore", 3));
        var rep = cr.Make("rcp_t_big", inv, CraftKit.Smith, new MakeOptions { Seed = 9 });
        Assert.Equal("normal", rep.Quality, "weighted mean 1.25");
        Assert.Equal(0, inv.Count("itm_t_ore@fine") + inv.Count("itm_t_ore"), "all four used");
    }

    public static void HighestQualityStacksAreUsedFirstUnlessAskedOtherwise()
    {
        var hi = CraftKit.Inv(("itm_t_ore@fine", 2), ("itm_t_ore", 4));
        var repHi = CraftKit.Crafter(("blacksmithing", "C")).Make("rcp_t_big", hi, CraftKit.Smith, new MakeOptions { Seed = 3 });
        Assert.Equal("fine", repHi.Quality, "2 Fine + 2 Normal = 1.5, + 0.75");
        Assert.Equal(0, hi.Count("itm_t_ore@fine"), "Fine used first");
        Assert.Equal(2, hi.Count("itm_t_ore"), "two Normal left");

        var lo = CraftKit.Inv(("itm_t_ore@fine", 2), ("itm_t_ore", 4));
        var repLo = CraftKit.Crafter(("blacksmithing", "C")).Make("rcp_t_big", lo, CraftKit.Smith, new MakeOptions { Seed = 3, UseLowestQualityFirst = true });
        Assert.Equal("normal", repLo.Quality, "4 Normal = 1.0, + 0.75");
        Assert.Equal(2, lo.Count("itm_t_ore@fine"), "Fine kept");
        Assert.Equal(0, lo.Count("itm_t_ore"), "Normal used");
    }

    public static void WithoutLifeSkillsOrRulesItIsAPlainNormalCraft()
    {
        var c = new Crafter(CraftKit.Recipes());
        var inv = CraftKit.Inv(("itm_t_ore", 2));
        var rep = c.Make("rcp_t_blade", inv, CraftKit.Smith);
        Assert.True(rep.Result == CraftResult.Ok && rep.Quality == "normal" && rep.OutputKey == "itm_t_blade", "plain Normal output key");
        Assert.Equal(0L, rep.XpGained, "no skills attached, no XP");
    }
}
