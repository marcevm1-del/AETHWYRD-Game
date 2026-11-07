using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Ascend.Core;

// Wave F-lite: the region connection graph (Data/World/region_graph.json, upgrade v10 section 9.1).
[Tests]
static class RegionGraphTests
{
    static RegionGraph _g;
    static RegionGraph G => _g ??= new RegionGraph(Repo.Load<RegionGraphData>("Data/World/region_graph.json"));

    static RegionGraphNode N(string id) => new RegionGraphNode { Id = id, Name = id };
    static RegionGraphEdge E(string id, string a, string b, double km, string kind = "road", bool foot = true) =>
        new RegionGraphEdge { Id = id, A = a, B = b, Km = km, Kind = kind, Foot = foot };
    static RegionGraph Small(params RegionGraphEdge[] edges)
    {
        var d = new RegionGraphData { Source = new RegionGraphSource { StartRegion = "a" } };
        foreach (var id in new[] { "a", "b", "c", "d", "e" }) d.Nodes.Add(N(id));
        d.Edges.AddRange(edges);
        return new RegionGraph(d);
    }

    // ---- the real data ----
    public static void TheGraphCoversExactlyTheFortySurfaceRegions()
    {
        var surface = Repo.Db.Regions.Values.Where(r => r.Layer == "surface").Select(r => r.Id).OrderBy(x => x).ToList();
        Assert.Equal(40, surface.Count, "Canon: 40 surface regions");
        Assert.Equal(40, G.SurfaceRegionCount, "graph nodes");
        Assert.True(G.Nodes.Select(n => n.Id).OrderBy(x => x).SequenceEqual(surface), "same ids as regions.json (surface)");
        Assert.True(Repo.Db.Regions.Count > 40, "regions.json holds more rows than surface lands (underworld and post-game)");
    }

    public static void EveryRoadInThePhysicalMapIsAnEdgeWithTheSameLength()
    {
        using var doc = JsonDocument.Parse(File.ReadAllText(Path.Combine(Repo.Root(), "Data/World/physical_map.json")));
        var roads = doc.RootElement.GetProperty("roads").EnumerateArray().ToList();
        Assert.Equal(13, roads.Count, "13 roads");
        foreach (var r in roads)
        {
            var id = r.GetProperty("id").GetString();
            var e = G.Edges.FirstOrDefault(x => x.RoadId == id);
            Assert.True(e != null, id + " is an edge");
            Assert.Near(r.GetProperty("lengthKm").GetDouble(), e.Km, 1e-9, id + " length");
            Assert.True(e.Kind == "road" || e.Kind == "pass", id + " is a road or a pass");
            Assert.Equal(r.GetProperty("passId").ValueKind == JsonValueKind.Null ? "road" : "pass", e.Kind, id + " kind follows passId");
        }
    }

    public static void ThreeRoadsCrossNamedPasses()
    {
        var passes = G.Edges.Where(e => e.Kind == "pass").ToList();
        Assert.Equal(3, passes.Count, "roads 04, 05, 06");
        Assert.True(passes.All(p => !string.IsNullOrEmpty(p.PassId) && p.PassM > 0 && p.PassM <= G.Data.Scale.PassLimitM), "pass data, under the 2,000 m limit");
        Assert.True(G.Edges.Where(e => e.Kind != "pass").All(e => e.PassId == null), "only pass edges carry a pass");
    }

    public static void EveryEdgeHasTwoRealRegionsADistanceAndAKnownKind()
    {
        var kinds = new HashSet<string> { "road", "pass", "sea", "border" };
        var ids = new HashSet<string>();
        foreach (var e in G.Edges)
        {
            Assert.True(ids.Add(e.Id), "unique edge id " + e.Id);
            Assert.True(kinds.Contains(e.Kind), e.Id + " kind");
            Assert.True(G.Has(e.A) && G.Has(e.B) && e.A != e.B, e.Id + " ends");
            Assert.True(e.Km > 0, e.Id + " km");
            Assert.True(!string.IsNullOrEmpty(e.KmBasis), e.Id + " says where its km came from");
        }
        Assert.True(G.Data.Portals.Count == 0, "no portal edges: Canon defines no portal or fast-travel place yet");
    }

    public static void TheOnlyRegionWithNoWayInIsTheSkyArchipelago()
    {
        // Decided 2026-11-07 (Canon section 6 WF3): a sailed leg Hoshizora City -> Fox Shrine Isle joins the Kitsune Isles; the
        // Sky Archipelago floats and is reached by a story event, so it stays off the graph.
        var orphans = G.Orphans().OrderBy(x => x).ToList();
        Assert.True(orphans.SequenceEqual(new[] { "reg_sky_archipelago" }), "orphans: " + string.Join(",", orphans));
        var unreachable = G.Unreachable().OrderBy(x => x).ToList();
        Assert.True(unreachable.SequenceEqual(orphans), "everything else is reachable from the start region");
        Assert.Equal("reg_whisperwood", G.StartRegion, "starts in Whisperwood (Canon)");
        Assert.Equal(1, G.Components().Count(c => c.Count == 1), "one lone region");
        Assert.Equal(39, G.Components()[0].Count, "one 39-region continent (the Isles are sailed to)");
    }

    public static void ShortestPathByRoadAddsUpTheRoadLengths()
    {
        var o = new TravelOptions { RoadsOnly = true };
        var p = G.ShortestPath("reg_whisperwood", "reg_cinderhole", o);
        Assert.True(p != null, "route exists");
        Assert.True(p.Regions.SequenceEqual(new[] { "reg_whisperwood", "reg_aldmere", "reg_iron_hold", "reg_cinderhole" }), "via Aldmere and Iron Hold: " + string.Join(">", p.Regions));
        Assert.Near(12.9 + 10.7 + 22.7, p.Km, 1e-6, "km");
        Assert.Equal(3, p.Edges.Count, "three legs");
        var back = G.ShortestPath("reg_cinderhole", "reg_whisperwood", o);
        Assert.Near(p.Km, back.Km, 1e-9, "symmetric");
        Assert.True(back.Regions.SequenceEqual(Enumerable.Reverse(p.Regions)), "reverse route");
    }

    public static void TheNamingVoyageIsTheOnlyWayToTheTrueNameIsles()
    {
        var sea = G.ShortestPath("reg_goldmere_coast", "reg_true_name_isles");
        Assert.True(sea != null && sea.Edges.Count == 1 && sea.Edges[0].Kind == "sea", "one sailed leg");
        Assert.Near(16, sea.Km, 1e-9, "16 km");
        Assert.True(G.ShortestPath("reg_goldmere_coast", "reg_true_name_isles", new TravelOptions { IncludeSea = false }) == null, "no walking route");
        Assert.True(G.Reachable("reg_whisperwood", new TravelOptions { IncludeSea = false }).Contains("reg_true_name_isles") == false, "without sea the isles are cut off");
    }

    public static void BordersAreOnlyWalkableUnderThePassLimitAndOverAKilometre()
    {
        foreach (var e in G.Edges.Where(x => x.Kind == "border"))
        {
            bool walk = e.LowestCrossingM <= G.Data.Scale.PassLimitM && e.BorderKm >= G.Data.Scale.MinWalkBorderKm;
            Assert.Equal(walk, e.Foot, e.Id + " foot");
        }
        // a road-only journey never uses a border
        var all = G.Edges.Where(e => RegionGraph.CanTravel(e, new TravelOptions { RoadsOnly = true })).Select(e => e.Kind).Distinct().OrderBy(k => k).ToList();
        Assert.True(all.SequenceEqual(new[] { "pass", "road", "sea" }), string.Join(",", all));
    }

    public static void RoadLengthsAreNotAbsurdlyShortForTheirEnds()
    {
        // Sanity on the km basis: a 2-leg road journey is never shorter than the straight line between its ends
        // (anchor distance), within rounding. Catches a swapped unit or a bad road length.
        foreach (var e in G.Edges.Where(x => x.Kind == "road" || x.Kind == "pass"))
        {
            var a = G.Node(e.A).At; var b = G.Node(e.B).At;
            double straight = System.Math.Sqrt((a[0] - b[0]) * (a[0] - b[0]) + (a[1] - b[1]) * (a[1] - b[1])) * G.Data.Scale.UnitKm;
            Assert.True(e.Km >= straight * 0.4, $"{e.Id}: {e.Km} km road vs {straight:F1} km between anchors");
        }
    }

    // ---- the rules, on small synthetic graphs ----
    public static void ShortestPathPicksTheCheaperRouteNotTheFewerHops()
    {
        var g = Small(E("ab", "a", "b", 10), E("bc", "b", "c", 10), E("ac", "a", "c", 50));
        var p = g.ShortestPath("a", "c");
        Assert.Equal(20.0, p.Km, "two cheap hops beat one long one");
        Assert.True(p.Regions.SequenceEqual(new[] { "a", "b", "c" }), "route");
    }

    public static void ShortestPathToSelfIsEmptyAndUnknownIdsGiveNull()
    {
        var g = Small(E("ab", "a", "b", 10));
        var self = g.ShortestPath("a", "a");
        Assert.True(self != null && self.Km == 0 && self.Edges.Count == 0 && self.Regions.Count == 1, "stay put");
        Assert.True(g.ShortestPath("a", "zzz") == null && g.ShortestPath(null, "a") == null && g.ShortestPath("a", "d") == null, "unknown or disconnected");
    }

    public static void OrphansAndComponentsFollowTheOptions()
    {
        var g = Small(E("ab", "a", "b", 5), E("cd", "c", "d", 5, "sea", false));
        Assert.True(g.Orphans().SequenceEqual(new[] { "e" }), "only e has no way at all");
        Assert.True(g.Orphans(new TravelOptions { IncludeSea = false }).OrderBy(x => x).SequenceEqual(new[] { "c", "d", "e" }), "without sea, c and d are cut off");
        var comps = g.Components();
        Assert.Equal(3, comps.Count, "ab, cd, e");
        Assert.True(comps[0].Count == 2, "largest first");
        Assert.True(g.Unreachable().OrderBy(x => x).SequenceEqual(new[] { "c", "d", "e" }), "from a");
    }

    public static void ANonWalkableBorderIsNotAWay()
    {
        var g = Small(E("ab", "a", "b", 5, "border", false), E("bc", "b", "c", 5));
        Assert.True(g.Neighbours("a").Count == 0, "a is walled off");
        Assert.True(g.Neighbours("b").SequenceEqual(new[] { "c" }), "b only reaches c");
    }

    public static void NeighboursAreNearestFirstWithOrdinalTies()
    {
        var g = Small(E("ac", "a", "c", 7), E("ab", "a", "b", 7), E("ad", "a", "d", 3), E("ad2", "a", "d", 9));
        Assert.True(g.Neighbours("a").SequenceEqual(new[] { "d", "b", "c" }), string.Join(",", g.Neighbours("a")));
    }

    public static void BadDataIsRefused()
    {
        var d = new RegionGraphData(); d.Nodes.Add(N("a")); d.Nodes.Add(N("a"));
        Assert.Throws<System.ArgumentException>(() => new RegionGraph(d), "duplicate node");
        Assert.Throws<System.ArgumentException>(() => Small(E("x", "a", "nope", 1)), "unknown end");
        Assert.Throws<System.ArgumentException>(() => Small(E("x", "a", "b", -1)), "negative km");
        Assert.Throws<System.ArgumentNullException>(() => new RegionGraph(null), "null data");
    }
}
