using System.Linq;
using Ascend.Core;

// Map UI feed: graph + knowledge + region data as plain lists.
[Tests]
static class WorldMapViewTests
{
    static RegionGraph _g;
    static RegionGraph G => _g ??= new RegionGraph(Repo.Load<RegionGraphData>("Data/World/region_graph.json"));
    static MapKnowledge Fresh() => new MapKnowledge(Repo.Db.World.Map, Repo.Db.Regions.Values);
    // The Warren lies in the Labyrinth (not a surface graph node), so tests place a copy in a surface land.
    static DungeonData InLand(string region) => new DungeonData { Id = "dng_test", RegionId = region };
    static WorldMapView View(MapKnowledge k, string here = null, string dungeonLand = null) =>
        WorldMapViews.Build(G, k, Repo.Db.Regions, dungeonLand == null ? Repo.Db.Dungeons.Values : new[] { InLand(dungeonLand) }, here);

    public static void EveryGraphLandIsListed()
    {
        var v = View(Fresh());
        Assert.Equal(G.Nodes.Count, v.Nodes.Count, "the sheet keeps its shape");
    }

    public static void UnknownLandsAreNamelessAndDetailFree()
    {
        var v = View(Fresh());
        foreach (var n in v.Nodes.Where(n => n.Status == MapStatus.Unknown))
            Assert.True(n.Name == null && n.RankMax == null && n.DungeonIds.Count == 0, n.Id + " stays blank");
        Assert.True(v.Nodes.Any(n => n.Status == MapStatus.Unknown), "something is still unknown at the start");
    }

    public static void StartLandIsInkedAndShowsItsDungeonsOnceVisited()
    {
        var k = Fresh();
        var v = View(k, G.StartRegion);
        var start = v.Nodes.First(n => n.Id == G.StartRegion);
        Assert.True(start.Status == MapStatus.Visited && start.Name != null && start.IsPlayerHere, "start land visited and marked");
        var land = G.Nodes.First(x => k.StatusOf(x.Id) == MapStatus.Unknown && Repo.Db.Regions.TryGetValue(x.Id, out var r) && r.Map != null).Id;
        Assert.True(k.Visit(land), "visited");
        var v2 = View(k, null, land);
        Assert.True(v2.Nodes.First(n => n.Id == land).DungeonIds.Contains("dng_test"), "visited land lists its dungeon");
    }

    public static void HeardLandsHideDungeonsAndFarWaysStayOff()
    {
        var k = Fresh();
        var land = G.Nodes.First(x => k.StatusOf(x.Id) == MapStatus.Unknown && Repo.Db.Regions.TryGetValue(x.Id, out var r) && r.Map != null).Id;
        Assert.True(k.Hear(land), "heard");
        var n = View(k, null, land).Nodes.First(x => x.Id == land);
        Assert.True(n.Name != null && n.DungeonIds.Count == 0, "heard: named, no dungeons");
        var v = View(Fresh());
        foreach (var e in v.Edges)
        {
            var kn = Fresh();
            Assert.True(kn.StatusOf(e.A) == MapStatus.Visited || kn.StatusOf(e.B) == MapStatus.Visited, e.Id + " touches a visited land");
        }
    }

    public static void StubsPointFromVisitedLandsToUnknownOnes()
    {
        var k = Fresh();
        var v = View(k);
        var stubs = v.Edges.Where(e => e.Stub).ToList();
        Assert.True(stubs.Count > 0, "a new player sees ways leading out");
        foreach (var e in stubs)
            Assert.True(k.StatusOf(e.A) == MapStatus.Unknown || k.StatusOf(e.B) == MapStatus.Unknown, e.Id + " leads to the unknown");
    }

    public static void KnownRouteNeedsKnownGround()
    {
        var k = Fresh();
        var start = G.StartRegion;
        var far = G.Nodes.First(n => k.StatusOf(n.Id) == MapStatus.Unknown && n.Id != start).Id;
        Assert.True(WorldMapViews.KnownRouteKm(G, k, start, far) == null, "no distance to an unknown land");
        var nb = G.Neighbours(start).First(x => k.StatusOf(x) == MapStatus.Unknown);
        k.Visit(nb);
        var km = WorldMapViews.KnownRouteKm(G, k, start, nb);
        Assert.True(km.HasValue && km.Value > 0, "distance between two known lands");
    }
}
