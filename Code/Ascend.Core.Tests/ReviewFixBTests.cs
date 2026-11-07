using Ascend.Core;

// Wave B code-review fixes.
[Tests]
static class ReviewFixBTests
{
    public static void ExperimentingCannotSkipTheRankGate()
    {
        var c = new Crafter(Repo.Db.Recipes, Repo.Db.Quality, new LifeSkills(Repo.Db.LifeSkills));
        var r = c.Recipe("rcp_cursed_iron_blade");
        foreach (var i in r.Inputs) c.Handle(i.ItemId);
        var inv = new Inventory();
        foreach (var i in r.Inputs) inv.Add(i.ItemId, i.Count);
        var forge = Repo.Db.Recipes.Stations["forge"];
        Assert.True(c.Experiment(r.Id, inv, forge) == CraftResult.RankTooLow, "an F-rank smith cannot work out a C-rank recipe");
        foreach (var i in r.Inputs) Assert.Equal(i.Count, inv.Count(i.ItemId), "nothing consumed");
        Assert.True(!c.Knows(r.Id), "not learned");
    }

    public static void NoRecipeListsTheSameInputTwice()
    {
        foreach (var r in Repo.Db.Recipes.Recipes)
            Assert.Equal(r.Inputs.Count, System.Linq.Enumerable.Count(System.Linq.Enumerable.Distinct(System.Linq.Enumerable.Select(r.Inputs, i => i.ItemId))), r.Id + " inputs are unique");
    }
}
