using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Ascend.Core;

// Wave F-lite adversarial QA: rules the validator enforces on the data but the Core suites did not pin,
// plus old-save behaviour for SaveGame.Labyrinth.
[Tests]
static class WaveFQaTests
{
    static readonly JsonSerializerOptions Opts = new() { PropertyNameCaseInsensitive = true };
    static LabyrinthData RawLab() => Repo.Load<LabyrinthData>("Data/World/labyrinth.json");
    static UnderworldData RawUw() => Repo.Load<UnderworldData>("Data/World/underworld.json");
    static RegionGraph G => new RegionGraph(Repo.Load<RegionGraphData>("Data/World/region_graph.json"));
    static JsonDocument Pm() => JsonDocument.Parse(File.ReadAllText(Path.Combine(Repo.Root(), "Data/World/physical_map.json")));

    public static void UnderworldGatesAndRanksEqualRegionsJson()
    {
        var uw = RawUw();
        Assert.Equal(5, uw.Layers.Count, "5 layers");
        foreach (var l in uw.Layers)
        {
            var r = Repo.Db.Regions[l.RegionId];
            Assert.Equal("underworld", r.Layer, l.RegionId + " is an underworld row");
            Assert.Near(r.Map.At[0], l.Gate.At[0], 0, l.RegionId + " gate x"); Assert.Near(r.Map.At[1], l.Gate.At[1], 0, l.RegionId + " gate y");
            Assert.Equal(r.RankMin, l.RankMin, l.RegionId + " rankMin"); Assert.Equal(r.RankMax, l.RankMax, l.RegionId + " rankMax");
            Assert.Equal(r.Ring, l.Ring, l.RegionId + " ring");
            Assert.Equal("surface", Repo.Db.Regions[l.Gate.SurfaceRegionId].Layer, l.RegionId + " gate sits in a surface region");
        }
    }

    public static void LabyrinthBandsAndEntranceEqualRegionsJson()
    {
        var lab = RawLab();
        foreach (var b in lab.Bands)
        {
            var r = Repo.Db.Regions[b.RegionId];
            Assert.Equal(r.RankMin, b.RankMin, b.Id + " rankMin"); Assert.Equal(r.RankMax, b.RankMax, b.Id + " rankMax"); Assert.Equal(r.Ring, b.Ring, b.Id + " ring");
        }
        var up = Repo.Db.Regions["reg_labyrinth_upper"].Map.At;
        Assert.Near(up[0], lab.Entrance.MapAt[0], 0, "entrance x"); Assert.Near(up[1], lab.Entrance.MapAt[1], 0, "entrance y");
        Assert.Equal("reg_aldmere", lab.Entrance.RegionId, "beneath Aldmere");
    }

    public static void EveryDungeonFloorSitsInItsBandAndIsListedByTheFloor()
    {
        var l = new Labyrinth(RawLab());
        int checkedFloors = 0;
        foreach (var d in Repo.Db.Dungeons.Values)
        {
            var band = l.BandOfRegion(d.RegionId);
            Assert.True(band != null, d.Id + " lives in a Labyrinth band");
            foreach (var n in d.Floors)
            {
                Assert.True(n >= band.Floors[0] && n <= band.Floors[1], d.Id + " floor " + n + " inside " + band.Id);
                Assert.True(l.Floor(n).DungeonIds.Contains(d.Id), "floor " + n + " lists " + d.Id);
                checkedFloors++;
            }
        }
        Assert.True(checkedFloors > 0, "at least one dungeon floor was checked (not vacuous)");
        foreach (var f in l.Floors) foreach (var id in f.DungeonIds)
            Assert.True(Repo.Db.Dungeons[id].Floors.Contains(f.N), "floor " + f.N + " only lists dungeons that claim it");
    }

    public static void EveryPassEdgeCarriesThePhysicalMapPassHeight()
    {
        using var doc = Pm();
        var passes = doc.RootElement.GetProperty("passes").EnumerateArray().ToDictionary(p => p.GetProperty("id").GetString(), p => p.GetProperty("m").GetDouble());
        int n = 0;
        foreach (var e in G.Edges.Where(x => x.Kind == "pass"))
        {
            Assert.True(passes.ContainsKey(e.PassId), e.Id + " names a real pass");
            Assert.Near(passes[e.PassId], e.PassM, 1e-9, e.Id + " pass height"); n++;
        }
        Assert.Equal(3, n, "three pass edges");
    }

    public static void EverySeaLegInThePhysicalMapIsAnEdge()
    {
        using var doc = Pm();
        int legs = 0;
        foreach (var c in doc.RootElement.GetProperty("corridors").EnumerateArray())
            foreach (var leg in c.GetProperty("legs").EnumerateArray())
            {
                if (leg.GetProperty("by").GetString() != "sea") continue;
                legs++;
                var km = leg.GetProperty("lengthKm").GetDouble();
                Assert.True(G.Edges.Any(e => e.Kind == "sea" && e.CorridorId == c.GetProperty("id").GetString() && System.Math.Abs(e.Km - km) < 1e-9), "sea leg of " + c.GetProperty("id").GetString());
            }
        Assert.True(legs > 0, "there is at least one sea leg (not vacuous)");
        Assert.Equal(legs + 1, G.Edges.Count(e => e.Kind == "sea"), "no extra sea edges besides the decided Hoshizora - Fox Shrine Isle leg (WF3)");
        Assert.True(G.Edges.Any(e => e.Kind == "sea" && e.CorridorId == null && e.A == "reg_hoshizora" && e.B == "reg_kitsune_isles"), "the decided leg is there");
    }

    public static void NoRoadEdgeIsDuplicatedAndBordersAreNotRoads()
    {
        var byRoad = G.Edges.Where(e => e.RoadId != null).GroupBy(e => e.RoadId).ToList();
        Assert.True(byRoad.All(g => g.Count() == 1), "each road is exactly one edge");
        Assert.True(G.Edges.Where(e => e.Kind == "border").All(e => e.RoadId == null), "a border is not a road");
        Assert.True(G.Edges.Count(e => e.Kind == "border" && !e.Foot) > 0 && G.Edges.Count(e => e.Kind == "border" && e.Foot) > 0, "both walkable and walled borders exist (not vacuous)");
    }

    public static void StartRegionIsASurfaceNodeAndSeaIsNeverWalkable()
    {
        Assert.True(G.Has(G.StartRegion) && Repo.Db.Regions[G.StartRegion].Layer == "surface", "start is a surface node");
        Assert.True(G.Edges.Where(e => e.Kind == "sea").All(e => !e.Foot), "sea legs are sailed, not walked");
        Assert.True(G.Edges.Where(e => e.Kind == "pass").All(e => e.Foot), "passes are walked");
    }

    public static void AnOldSaveKeepsItsOtherSectionsWhenLabyrinthIsFilled()
    {
        // A save written before the Labyrinth field existed, with real content elsewhere.
        var json = "{\"Version\":1,\"Level\":12,\"Copper\":999,\"Flags\":[\"flag_a\",\"flag_b\"]}";
        var old = JsonSerializer.Deserialize<SaveGame>(json, Opts);
        Assert.True(old.Labyrinth == null, "absent before Upgrade");
        var up = SaveRules.Upgrade(old);
        Assert.Equal(12, up.Level, "level kept"); Assert.Equal(999, up.Copper, "copper kept");
        Assert.Equal(2, up.Flags.Count, "flags kept");
        Assert.Equal(0, SaveRules.Validate(up).Count, "valid after upgrade");
        // Upgrade twice changes nothing; a Labyrinth record already present is not wiped.
        var l = new Labyrinth(RawLab()); var k = new LabyrinthKnowledge(l);
        k.VisitFloor(7);
        up.Labyrinth = k.Save();
        var again = SaveRules.Upgrade(up);
        Assert.Equal(MapStatus.Visited, again.Labyrinth.Floors["flr_007"], "Upgrade does not erase a Labyrinth record");
        var round = JsonSerializer.Deserialize<SaveGame>(JsonSerializer.Serialize(again), Opts);
        Assert.Equal(MapStatus.Visited, round.Labyrinth.Floors["flr_007"], "round trip");
    }

    public static void ASaveWithAnUnknownFutureLabyrinthIdLoadsWithoutCrashing()
    {
        var l = new Labyrinth(RawLab()); var k = new LabyrinthKnowledge(l);
        var s = JsonSerializer.Deserialize<SaveGame>("{\"Labyrinth\":{\"Floors\":{\"flr_130\":2,\"flr_004\":2},\"Stairs\":{\"stair_130_131\":2}}}", Opts);
        k.Load(SaveRules.Upgrade(s).Labyrinth);
        Assert.Equal(4, k.Deepest, "known floor kept");
        Assert.Equal(MapStatus.Unknown, k.StatusOfFloor("flr_130"), "unknown id dropped");
    }
}
