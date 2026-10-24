using System.Linq;
using Ascend.Core;

// Crafting (systems.md §5; recipes.json).
[Tests]
static class CraftingTests
{
    static Crafter New() => new Crafter(Repo.Db.Recipes);

    public static void CampfireRecipesAreKnownAndWorkAnywhere()
    {
        var c = New();
        Assert.True(c.Knows("rcp_hunters_skewer"), "cooking a skewer needs no teacher");
        Assert.True(!c.Knows("rcp_fangblade"), "smithing does");
        var inv = new Inventory(); inv.Add("itm_mat_prime_meat", 3);
        Assert.True(c.Craft("rcp_hunters_skewer", inv, null) == CraftResult.Ok, "a campfire anywhere");
        Assert.Equal(1, inv.Count("itm_hunters_skewer"), "made one");
        Assert.Equal(1, inv.Count("itm_mat_prime_meat"), "two meat used");
        Assert.True(c.Craft("rcp_hunters_skewer", inv, null) == CraftResult.MissingMaterials, "one meat isn't enough");
        Assert.Equal(1, c.Missing(c.Recipe("rcp_hunters_skewer"), inv).Single().Count, "one short");
    }

    public static void SmithingIsLearnedFromTorvaldAndMadeAtHisForge()
    {
        var c = New();
        var inv = new Inventory(); inv.AddCopper(100);
        Assert.True(c.Learn("rcp_fangblade", inv, "npc_fennick_reed") == CraftResult.NotTaughtHere, "Fennick doesn't teach smithing");
        Assert.True(c.Learn("rcp_fangblade", inv, "npc_torvald_stonebeard") == CraftResult.Ok, "Torvald does");
        Assert.Equal(60L, inv.Copper, "for 40 copper");
        Assert.True(c.Learn("rcp_fangblade", inv, "npc_torvald_stonebeard") == CraftResult.AlreadyKnown, "once");
        inv.Add("itm_mat_crude_blade", 2); inv.Add("itm_mat_fang", 2); inv.Add("itm_core_f", 1);
        Assert.True(c.Craft("rcp_fangblade", inv, null) == CraftResult.WrongStation, "needs the forge");
        Assert.True(c.Craft("rcp_fangblade", inv, "npc_torvald_stonebeard") == CraftResult.Ok, "at Torvald's forge");
        Assert.Equal(1, inv.Count("itm_fangblade"), "a Fangblade");
        Assert.Equal(0, inv.Count("itm_core_f"), "the core went into it");
        Assert.Equal("forge", c.StationOf("npc_torvald_stonebeard"), "his station");
    }

    public static void CraftedGearBeatsTheStarterKit()
    {
        Assert.True(Repo.Db.Items["itm_fangblade"].Stat("atk") > Repo.Db.Items["itm_guild_issue_sword"].Stat("atk"), "worth the effort");
        Assert.True(Repo.Db.Items["itm_carapace_cap"].Stat("def") > Repo.Db.Items["itm_rookie_hood"].Stat("def"), "a better cap");
    }

    public static void KnownRecipesLoadFromASave()
    {
        var c = New();
        c.Load(new[] { "rcp_fire_bomb", "rcp_gone_from_data" });
        Assert.True(c.Knows("rcp_fire_bomb") && !c.Knows("rcp_gone_from_data"), "unknown ids are dropped");
    }

    public static void HandlingEveryMaterialGivesAnIdeaYouCanTestAtTheForge()
    {
        var c = New();
        var r = c.Recipe("rcp_carapace_cap");
        Assert.True(!c.IsHypothesis(r), "no idea yet");
        Assert.Equal(0, c.Handle("itm_mat_carapace_shard").Count, "one material isn't enough");
        var ideas = c.Handle("itm_mat_pelt");
        Assert.True(ideas.Exists(x => x.Id == "rcp_carapace_cap"), "the second material sparks the idea");
        var inv = new Inventory(); inv.Add("itm_mat_carapace_shard", 3); inv.Add("itm_mat_pelt", 1);
        Assert.True(c.Experiment("rcp_carapace_cap", inv, null) == CraftResult.WrongStation, "needs the forge");
        Assert.True(c.Experiment("rcp_carapace_cap", inv, "npc_torvald_stonebeard") == CraftResult.Ok, "worked it out at the forge");
        Assert.True(c.Knows("rcp_carapace_cap") && inv.Count("itm_carapace_cap") == 1, "made one and learned it, no fee");
        Assert.True(c.Experiment("rcp_fangblade", new Inventory(), "npc_torvald_stonebeard") == CraftResult.NoIdeaYet, "never handled its materials");
    }
}
