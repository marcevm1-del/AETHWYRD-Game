using Ascend.Core;

// Gathering nodes (systems.md §5; gathering.json).
[Tests]
static class GatheringTests
{
    public static void AHerbPatchYieldsThenRegrows()
    {
        var node = new GatherNodeState(Repo.Db.GatherNodes["node_herb_patch"]);
        var inv = new Inventory();
        var rng = new DeterministicRandom(4);
        Assert.True(node.Ready(10), "ready at the start");
        var drops = node.Gather(10, inv, rng);
        Assert.True(inv.Count("itm_healing_herb") >= 1, "always at least one herb");
        Assert.True(drops.Count >= 1, "reported");
        Assert.True(!node.Ready(20) && node.Gather(20, inv, rng).Count == 0, "regrowing: nothing more");
        Assert.True(node.Ready(34), "a day later it's back");
    }

    public static void EveryNodeYieldsSomething()
    {
        foreach (var n in Repo.Db.GatherNodes.Values)
            Assert.True(n.Yields.Exists(y => y.Chance >= 1), n.Id + " has a guaranteed yield");
    }
}
