using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Ascend.Core;

// Life skill ladders (life_skills.json; crafting_v6_audit.md section 3.2).
[Tests]
static class LifeSkillTests
{
    static LifeSkills Fresh() => new LifeSkills(Repo.Db.LifeSkills);

    public static void SkillsStartAtRankFWithNoXp()
    {
        var ls = Fresh();
        Assert.Equal("F", ls.Rank("blacksmithing"), "rank F");
        Assert.Equal(0L, ls.Xp("blacksmithing"), "no xp");
        Assert.True(ls.IsKnown("mining") && ls.IsKnown("cooking") && !ls.IsKnown("mystery_skill"), "ids from the data file");
        Assert.Equal(9, ls.Ranks.Count, "F to SSS");
    }

    public static void FirstCraftOfARecipeGivesTripleXpOnce()
    {
        var cr = CraftKit.Crafter();
        var inv = CraftKit.Inv(("itm_t_ore", 4));
        var first = cr.Make("rcp_t_blade", inv, CraftKit.Smith);
        Assert.Equal(30L, first.XpGained, "10 x 3 the first time");
        var again = cr.Make("rcp_t_blade", CraftKit.Inv(("itm_t_ore", 2)), CraftKit.Smith);
        Assert.Equal(10L, again.XpGained, "10 afterwards");
        var other = cr.Make("rcp_t_xp40", CraftKit.Inv(("itm_t_ore", 1)), CraftKit.Smith);
        Assert.Equal(120L, other.XpGained, "a different recipe gets its own first-time bonus (40 x 3)");
        Assert.Equal(160L, cr.Skills.Xp("blacksmithing"), "30 + 10 + 120");
    }

    public static void TrivialCraftsGiveAQuarterButNeverLessThanOne()
    {
        var ls = CraftKit.Skills(("blacksmithing", "D"));
        var r40 = CraftKit.Recipes().Recipes.First(r => r.Id == "rcp_t_xp40");
        var r2 = CraftKit.Recipes().Recipes.First(r => r.Id == "rcp_t_xp2");
        Assert.Equal(10L, ls.XpFor(r40, false), "40 x 0.25");
        Assert.Equal(30L, ls.XpFor(r40, true), "first time and trivial: 40 x 3 x 0.25");
        Assert.Equal(1L, ls.XpFor(r2, false), "never below 1");
        var notTrivial = CraftKit.Skills(("blacksmithing", "E"));
        Assert.Equal(40L, notTrivial.XpFor(r40, false), "one rank below is not trivial");
    }

    public static void RecipeXpFallsBackToTheRankDefault()
    {
        var ls = Fresh();
        var blade = CraftKit.Recipes().Recipes.First(r => r.Id == "rcp_t_blade");
        Assert.Equal(10L, ls.XpFor(blade, false), "F default");
        var hi = CraftKit.Recipes().Recipes.First(r => r.Id == "rcp_t_hi");
        Assert.Equal(20L, ls.XpFor(hi, false), "D default");
    }

    public static void RanksBelowTheCommissionRiseFromXpAlone()
    {
        var ls = Fresh();
        Assert.True(ls.AddXp("alchemy", 249) == null && ls.Rank("alchemy") == "F", "249 is not enough");
        Assert.Equal("E", ls.AddXp("alchemy", 1), "250 reaches E");
        Assert.Equal("E", ls.Rank("alchemy"), "now E");
        Assert.Equal("F", ls.Rank("blacksmithing"), "other skills are separate tracks");
    }

    public static void RankDNeedsACommissionAndHoldsWithoutLosingXp()
    {
        var ls = Fresh();
        ls.AddXp("blacksmithing", 250);
        Assert.Equal(null, ls.AddXp("blacksmithing", 550), "800 XP total, no commission yet");
        Assert.Equal("E", ls.Rank("blacksmithing"), "holds at E");
        Assert.True(ls.Eligible("blacksmithing"), "ready for the commission");
        Assert.Equal(800L, ls.Xp("blacksmithing"), "no XP lost");
        ls.AddXp("blacksmithing", 100);
        Assert.Equal(900L, ls.Xp("blacksmithing"), "XP keeps accumulating");
        Assert.Equal("E", ls.Rank("blacksmithing"), "still E");
        Assert.Equal("D", ls.PassCommission("blacksmithing"), "the commission lets it through");
        Assert.Equal("D", ls.Rank("blacksmithing"), "now D");
        Assert.True(!ls.Eligible("blacksmithing"), "no longer waiting");
        Assert.Equal(900L, ls.Xp("blacksmithing"), "XP intact");
    }

    public static void ACommissionPassedEarlyAppliesWhenTheXpArrives()
    {
        var ls = Fresh();
        ls.AddXp("cooking", 250);
        Assert.Equal(null, ls.PassCommission("cooking"), "commission first, no XP yet");
        Assert.Equal("E", ls.Rank("cooking"), "still E");
        Assert.Equal("D", ls.AddXp("cooking", 550), "the XP arrives");
    }

    public static void EachRankFromDOnNeedsItsOwnCommission()
    {
        var ls = Fresh();
        ls.AddXp("tailoring", 250);
        ls.AddXp("tailoring", 100000);
        Assert.Equal("E", ls.Rank("tailoring"), "XP alone stops at E");
        Assert.Equal("D", ls.PassCommission("tailoring"), "D commission");
        Assert.Equal("D", ls.Rank("tailoring"), "does not run on to C");
        Assert.True(ls.Eligible("tailoring"), "C waits for its own");
        Assert.Equal("C", ls.PassCommission("tailoring"), "C commission");
    }

    public static void PassCommissionOnAMaxedOrUnknownSkillDoesNothing()
    {
        var ls = Fresh();
        Assert.Equal(null, ls.PassCommission("mystery_skill"), "unknown");
        Assert.Equal(null, ls.AddXp("mystery_skill", 1000), "unknown skill ignores XP");
        Assert.Equal(0L, ls.Xp("mystery_skill"), "nothing stored");
    }

    public static void ARecipeAboveYourRankIsRefusedAndKeepsYourMaterials()
    {
        var cr = CraftKit.Crafter(("blacksmithing", "E"));
        var inv = CraftKit.Inv(("itm_t_ore", 2));
        var before = CraftKit.Snapshot(inv);
        Assert.True(cr.Make("rcp_t_hi", inv, CraftKit.Smith).Result == CraftResult.RankTooLow, "Make");
        Assert.True(cr.CanCraft("rcp_t_hi", inv, CraftKit.Smith) == CraftResult.RankTooLow, "CanCraft");
        Assert.True(cr.Craft("rcp_t_hi", inv, CraftKit.Smith) == CraftResult.RankTooLow, "Craft");
        Assert.True(CraftKit.SameInventory(before, inv), "nothing consumed");
        var d = CraftKit.Crafter(("blacksmithing", "D"));
        Assert.True(d.Make("rcp_t_hi", inv, CraftKit.Smith).Result == CraftResult.Ok, "fine at D");
    }

    public static void UnknownSkillOnARecipeIsNotGated()
    {
        var cr = CraftKit.Crafter();
        var inv = CraftKit.Inv(("itm_t_meat", 1));
        var rep = cr.Make("rcp_t_mystery", inv, null);
        Assert.True(rep.Result == CraftResult.Ok, "tolerated");
        Assert.Equal(0L, rep.XpGained, "but no XP for a skill that does not exist");
    }

    public static void MakeReportsTheRankUp()
    {
        var ls = CraftKit.Skills();
        ls.AddXp("blacksmithing", 240);
        var cr = new Crafter(CraftKit.Recipes(), Repo.Db.Quality, ls);
        var rep = cr.Make("rcp_t_blade", CraftKit.Inv(("itm_t_ore", 2)), CraftKit.Smith);
        Assert.Equal("E", rep.RankedUp, "240 + 30 crosses 250");
        Assert.Equal("E", ls.Rank("blacksmithing"), "now E");
        var next = cr.Make("rcp_t_blade", CraftKit.Inv(("itm_t_ore", 2)), CraftKit.Smith);
        Assert.Equal(null, next.RankedUp, "no rank-up the next time");
    }

    public static void PlainCraftStillWorksAndPaysXpWhenSkillsAreAttached()
    {
        var cr = CraftKit.Crafter();
        var inv = CraftKit.Inv(("itm_t_meat", 4));
        Assert.True(cr.Craft("rcp_t_stew", inv, null) == CraftResult.Ok, "plain craft");
        Assert.Equal(1, inv.Count("itm_t_stew"), "plain Normal output");
        Assert.Equal(30L, cr.Skills.Xp("cooking"), "first craft x3");
        Assert.True(cr.Craft("rcp_t_stew", inv, null) == CraftResult.Ok, "again");
        Assert.Equal(40L, cr.Skills.Xp("cooking"), "then 10");
    }

    public static void RealRecipesNameKnownSkillsAndRanks()
    {
        var ls = Fresh();
        foreach (var r in Repo.Db.Recipes.Recipes)
        {
            Assert.True(ls.IsKnown(r.Skill), r.Id + " names a skill that exists");
            Assert.True(System.Array.IndexOf(new[] { "F", "E", "D", "C", "B", "A", "S", "SS", "SSS" }, r.LifeRank) >= 0, r.Id + " lifeRank is a real rank");
        }
    }

    public static void GatheringPaysXpByNodeRank()
    {
        var ls = Fresh();
        Assert.Equal(5L, ls.OnGather("mining", "F"), "F node");
        Assert.Equal(5L, ls.Xp("mining"), "stored");
        Assert.Equal(10L, ls.OnGather("herbalism", "D"), "D node pays more");
        Assert.Equal(0L, ls.OnGather("mystery_skill", "F"), "unknown skill ignored");
    }

    public static void TrivialGatheringPaysAQuarter()
    {
        var ls = CraftKit.Skills(("logging", "D"));
        Assert.Equal(1L, ls.OnGather("logging", "F"), "5 x 0.25 rounds to 1");
        Assert.Equal(10L, ls.OnGather("logging", "D"), "same rank is full pay");
        var e = CraftKit.Skills(("logging", "E"));
        Assert.Equal(5L, e.OnGather("logging", "F"), "one rank apart is not trivial");
    }

    public static void GatheringCanRaiseARank()
    {
        var ls = Fresh();
        string up = null;
        for (int i = 0; i < 50; i++) { ls.OnGather("fishing", "F", out var r); if (r != null) up = r; }
        Assert.Equal("E", up, "50 nodes x 5 XP = 250");
        Assert.Equal("E", ls.Rank("fishing"), "fishing E");
    }

    public static void SaveAndLoadRoundTripsEverything()
    {
        var ls = Fresh();
        ls.AddXp("blacksmithing", 5000);
        ls.PassCommission("blacksmithing");
        ls.OnGather("mining", "F");
        var cr = new Crafter(CraftKit.Recipes(), Repo.Db.Quality, ls);
        cr.Craft("rcp_t_stew", CraftKit.Inv(("itm_t_meat", 2)), null);

        var save = new SaveGame { LifeSkills = ls.Save() };
        var json = JsonSerializer.Serialize(save);
        var back = SaveRules.Upgrade(JsonSerializer.Deserialize<SaveGame>(json));
        var ls2 = Fresh();
        ls2.Load(back.LifeSkills);

        Assert.Equal(ls.Rank("blacksmithing"), ls2.Rank("blacksmithing"), "rank");
        Assert.Equal("D", ls2.Rank("blacksmithing"), "D after the commission");
        Assert.Equal(ls.Xp("blacksmithing"), ls2.Xp("blacksmithing"), "xp");
        Assert.Equal(5L, ls2.Xp("mining"), "gather xp");
        Assert.True(ls2.CommissionPassed("blacksmithing", "D"), "commission");
        Assert.True(ls2.HasCrafted("rcp_t_stew") && !ls2.HasCrafted("rcp_t_blade"), "crafted recipes");
        Assert.True(ls2.Eligible("blacksmithing") == ls.Eligible("blacksmithing"), "waiting state");
        // The first-time bonus is not paid twice after a reload.
        var cr2 = new Crafter(CraftKit.Recipes(), Repo.Db.Quality, ls2);
        Assert.Equal(10L, cr2.Make("rcp_t_stew", CraftKit.Inv(("itm_t_meat", 2)), null).XpGained, "already crafted");
    }

    public static void AnOldSaveWithoutTheFieldLoadsAsAllRankF()
    {
        var old = JsonSerializer.Deserialize<SaveGame>("{\"Level\":3,\"Copper\":10}");
        Assert.True(old.LifeSkills != null, "default exists even when the JSON lacks it");
        var nulled = JsonSerializer.Deserialize<SaveGame>("{\"Level\":3,\"LifeSkills\":null}");
        Assert.True(nulled.LifeSkills == null, "explicit null really is null");
        SaveRules.Upgrade(nulled);
        Assert.True(nulled.LifeSkills != null, "Upgrade fills it");
        Assert.Equal(0, SaveRules.Validate(nulled).Count, "still a valid save");
        var ls = Fresh();
        ls.AddXp("cooking", 300);
        ls.Load(null);
        Assert.Equal("F", ls.Rank("cooking"), "null state resets to F");
        ls.Load(nulled.LifeSkills);
        Assert.Equal(0L, ls.Xp("cooking"), "empty state");
    }

    public static void LoadDropsUnknownSkillsAndRanks()
    {
        var s = new LifeSkillSave();
        s.Xp["blacksmithing"] = 100; s.Xp["mystery_skill"] = 999;
        s.Rank["blacksmithing"] = "Q"; s.Rank["mining"] = "C";
        var ls = Fresh();
        ls.Load(s);
        Assert.Equal("F", ls.Rank("blacksmithing"), "bad rank letter ignored");
        Assert.Equal("C", ls.Rank("mining"), "good rank kept");
        Assert.Equal(0L, ls.Xp("mystery_skill"), "unknown skill dropped");
    }
}
