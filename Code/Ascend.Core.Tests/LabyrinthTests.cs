using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Ascend.Core;

// Wave F-lite: the Great Labyrinth floor registry, the Underworld layer registry and SaveGame.Labyrinth.
[Tests]
static class LabyrinthTests
{
    static readonly JsonSerializerOptions Opts = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    static LabyrinthData RawLab() => Repo.Load<LabyrinthData>("Data/World/labyrinth.json");
    static UnderworldData RawUw() => Repo.Load<UnderworldData>("Data/World/underworld.json");
    static Labyrinth Lab() => new Labyrinth(RawLab());
    static LabyrinthKnowledge Know(Labyrinth l = null) => new LabyrinthKnowledge(l ?? Lab());
    static UnderworldRegistry Uw() => new UnderworldRegistry(RawUw(), Lab());
    static MapKnowledge FreshMap() => new MapKnowledge(Repo.Db.World.Map, Repo.Db.Regions.Values);

    // ---- the registry -------------------------------------------------------------------------------------------

    public static void ThereAre120FloorsInThreeBands()
    {
        var l = Lab();
        Assert.Equal(120, l.FloorCount, "floor count");
        Assert.Equal(120, l.Floors.Count, "floors");
        Assert.Equal(3, l.Bands.Count, "bands");
        Assert.Equal(119, l.Stairs.Count, "stairs");
        Assert.Equal(3, l.BackDoors.Count, "back-doors");
        for (int n = 1; n <= 120; n++) Assert.Equal(n, l.Floor(n).N, "floor " + n);
        Assert.True(l.Floor(0) == null && l.Floor(121) == null && l.Floor(-5) == null, "out of range is null");
        Assert.True(l.Bands[0].Floors[0] == 1 && l.Bands[0].Floors[1] == 40, "upper 1-40");
        Assert.True(l.Bands[1].Floors[0] == 41 && l.Bands[1].Floors[1] == 90, "deep 41-90");
        Assert.True(l.Bands[2].Floors[0] == 91 && l.Bands[2].Floors[1] == 120, "abyss 91-120");
        for (int n = 1; n <= 120; n++)
        {
            var b = l.BandOf(n);
            Assert.True(b != null && n >= b.Floors[0] && n <= b.Floors[1], "floor " + n + " sits in its band's range");
        }
        Assert.True(l.BandOf(0) == null, "no band off the map");
    }

    public static void BandsAreFoundByRegion()
    {
        var l = Lab();
        Assert.Equal("upper", l.BandOfRegion("reg_labyrinth_upper").Id, "upper");
        Assert.Equal("deep", l.BandOfRegion("reg_labyrinth_deep").Id, "deep");
        Assert.Equal("abyss", l.BandOfRegion("reg_labyrinth_abyss").Id, "abyss");
        Assert.True(l.BandOfRegion("reg_whisperwood") == null && l.BandOfRegion(null) == null, "other regions are not bands");
    }

    public static void GuardiansSitOnEveryTenth()
    {
        var l = Lab();
        var g = Enumerable.Range(1, 120).Where(l.IsGuardianFloor).ToList();
        Assert.Equal("10,20,30,40,50,60,70,80,90,100,110,120", string.Join(",", g), "guardian floors");
        Assert.True(!l.IsGuardianFloor(0) && !l.IsGuardianFloor(121), "off the map");
    }

    public static void SafeTownsOnlyOn30And40AndCampsMatchTheData()
    {
        var l = Lab();
        var towns = l.Floors.Where(f => f.Safe == "town").Select(f => f.N).ToList();
        Assert.Equal("30,40", string.Join(",", towns), "towns");
        var camps = l.Floors.Where(f => f.Safe == "camp").Select(f => f.N).ToList();
        Assert.Equal("50,60,70,80,90,100", string.Join(",", camps), "camps");
        for (int n = 1; n <= 120; n++) Assert.Equal(!string.IsNullOrEmpty(l.Floor(n).Safe), l.IsSafeFloor(n), "IsSafeFloor " + n);
        Assert.True(!l.IsSafeFloor(1) && !l.IsSafeFloor(0) && !l.IsSafeFloor(121), "plain floors are not safe");
    }

    public static void StairsJoinNeighboursAndLicencesAreOnTheBandEdges()
    {
        var l = Lab();
        for (int n = 1; n <= 119; n++)
        {
            var s = l.StairDown(n);
            Assert.True(s != null && s.From == n && s.To == n + 1, "stair " + n);
        }
        Assert.True(l.StairDown(120) == null && l.StairDown(0) == null, "no stair below the bottom");
        var licensed = l.Stairs.Where(s => s.LicenceRank != null).Select(s => s.From + ":" + s.LicenceRank).ToList();
        Assert.Equal("40:B,90:SS", string.Join(",", licensed), "licensed stairs");
        var hidden = l.Stairs.Where(s => s.Hidden).Select(s => s.From).ToList();
        Assert.Equal("100,110", string.Join(",", hidden), "hidden stairs");
    }

    public static void BackDoorsAreOnFloors30_60_90()
    {
        var l = Lab();
        Assert.Equal(3, l.BackDoorOn(30).Layer, "30");
        Assert.Equal(4, l.BackDoorOn(60).Layer, "60");
        Assert.Equal(5, l.BackDoorOn(90).Layer, "90");
        Assert.True(l.BackDoorOn(31) == null && l.BackDoorOn(0) == null, "no door elsewhere");
        Assert.True(l.FloorsWithLandmarks.Any(f => f.N == 30), "floor 30 has landmarks");
        Assert.True(l.FloorsWithLandmarks.All(f => f.Landmarks.Count > 0), "landmark floors have landmarks");
    }

    // ---- descending ---------------------------------------------------------------------------------------------

    public static void DescendOneFloorAtATime()
    {
        var l = Lab(); var k = Know(l);
        Assert.Equal(DescendResult.Ok, l.CanDescend(1, RankLetter.F, k), "1 -> 2");
        Assert.Equal(2, l.Descend(1, RankLetter.F, k), "arrive on 2");
        Assert.Equal(3, l.Descend(2, RankLetter.F, k), "arrive on 3");
        Assert.Equal(DescendResult.UnknownFloor, l.CanDescend(0, RankLetter.EX, k), "floor 0");
        Assert.Equal(DescendResult.UnknownFloor, l.CanDescend(121, RankLetter.EX, k), "floor 121");
        Assert.Equal(DescendResult.UnknownFloor, l.CanDescend(-1, RankLetter.EX, k), "floor -1");
        Assert.Equal(0, l.Descend(0, RankLetter.EX, k), "a refused descent from nowhere stays put");
    }

    public static void CannotSkipFloors()
    {
        var l = Lab(); var k = Know(l);
        // The only stair from floor 5 leads to 6; there is no way to land on 7.
        Assert.Equal(6, l.Descend(5, RankLetter.EX, k), "one step only");
        Assert.True(l.StairDown(5).To == 6, "stairs only join neighbours");
    }

    public static void CannotGoBelowFloor120()
    {
        var l = Lab(); var k = Know(l);
        Assert.Equal(DescendResult.BottomFloor, l.CanDescend(120, RankLetter.EX, k), "bottom");
        Assert.Equal(120, l.Descend(120, RankLetter.EX, k), "stays on 120");
    }

    public static void TheLicenceIsCheckedAtTheBandEdges()
    {
        var l = Lab(); var k = Know(l);
        Assert.Equal(DescendResult.Ok, l.CanDescend(39, RankLetter.F, k), "39 -> 40 needs no licence");
        Assert.Equal(DescendResult.NeedsLicence, l.CanDescend(40, RankLetter.E, k), "40 -> 41, E");
        Assert.Equal(DescendResult.Ok, l.CanDescend(40, RankLetter.A, k), "40 -> 41, A passes B's licence");
        Assert.Equal(DescendResult.NeedsLicence, l.CanDescend(40, RankLetter.C, k), "40 -> 41, C");
        Assert.Equal(DescendResult.Ok, l.CanDescend(40, RankLetter.B, k), "40 -> 41, B");
        Assert.Equal(40, l.Descend(40, RankLetter.E, k), "refused stays");
        Assert.Equal(DescendResult.Ok, l.CanDescend(41, RankLetter.F, k), "inside the deep band nothing else is checked");
        Assert.Equal(DescendResult.NeedsLicence, l.CanDescend(90, RankLetter.S, k), "90 -> 91, S");
        Assert.Equal(DescendResult.Ok, l.CanDescend(90, RankLetter.SS, k), "90 -> 91, SS");
        Assert.Equal(DescendResult.Ok, l.CanDescend(90, RankLetter.EX, k), "90 -> 91, EX");
        Assert.True(Labyrinth.LicenceMet(null, RankLetter.F), "no licence means no check");
        Assert.True(!Labyrinth.LicenceMet("ZZ", RankLetter.EX), "a garbled licence is not met");
    }

    public static void ALicenceRefusalLeavesNoTrace()
    {
        var l = Lab(); var k = Know(l);
        l.Descend(40, RankLetter.E, k);
        Assert.Equal(MapStatus.Unknown, k.StatusOfFloor(41), "41 stays blank");
        Assert.Equal(0, k.Deepest, "nothing visited");
    }

    public static void AHiddenStairNeedsToBeFoundInPlace()
    {
        var l = Lab(); var k = Know(l);
        Assert.Equal(DescendResult.StairHidden, l.CanDescend(100, RankLetter.SS, k), "hidden");
        Assert.Equal(100, l.Descend(100, RankLetter.SS, k), "stays");
        Assert.Equal(DescendResult.StairHidden, l.CanDescend(100, RankLetter.SS, null), "no record: still hidden");
        Assert.True(k.HearStair("stair_100_101"), "a rumour pencils it");
        Assert.Equal(MapStatus.Heard, k.StatusOfStair("stair_100_101"), "Heard");
        Assert.Equal(DescendResult.StairHidden, l.CanDescend(100, RankLetter.SS, k), "a rumour opens nothing");
        Assert.True(k.FindStair("stair_100_101"), "found in place");
        Assert.Equal(DescendResult.Ok, l.CanDescend(100, RankLetter.SS, k), "now open");
        Assert.Equal(101, l.Descend(100, RankLetter.SS, k), "down");
        Assert.True(!k.HearStair("stair_100_101"), "hearing a found stair changes nothing");
        Assert.Equal(MapStatus.Visited, k.StatusOfStair("stair_100_101"), "never downgraded");
    }

    public static void FindingAStairDirectlyWorksWithoutAnEarlierRumour()
    {
        var l = Lab(); var k = Know(l);
        Assert.True(k.FindStair("stair_110_111"), "found cold");
        Assert.True(!k.FindStair("stair_110_111"), "second find changes nothing");
        Assert.Equal(DescendResult.Ok, l.CanDescend(110, RankLetter.SSS, k), "open");
    }

    public static void DescendRecordsTheArrivalAndTheDeepestFloor()
    {
        var l = Lab(); var k = Know(l);
        Assert.Equal(0, k.Deepest, "nothing walked yet");
        Assert.Equal(2, l.Descend(1, RankLetter.F, k), "down");
        Assert.Equal(MapStatus.Visited, k.StatusOfFloor(2), "arrival is Visited");
        Assert.Equal(2, k.Deepest, "deepest");
        l.Descend(2, RankLetter.F, k);
        Assert.Equal(3, k.Deepest, "deepest follows");
        Assert.Equal(2, l.Ascend(3), "back up");
        Assert.Equal(3, k.Deepest, "climbing keeps the record");
    }

    public static void AscendNeverGoesBelowOne()
    {
        var l = Lab();
        Assert.Equal(1, l.Ascend(1), "floor 1");
        Assert.Equal(1, l.Ascend(0), "floor 0");
        Assert.Equal(1, l.Ascend(-4), "negative");
        Assert.Equal(119, l.Ascend(120), "120 -> 119");
        Assert.Equal(119, l.Ascend(500), "past the bottom is clamped first");
    }

    // ---- knowledge ----------------------------------------------------------------------------------------------

    public static void FloorOneStartsHeardAndReachable()
    {
        var l = Lab(); var k = Know(l);
        Assert.Equal(MapStatus.Heard, k.StatusOfFloor(1), "floor 1 is a rumour");
        Assert.Equal(FloorAccess.Reachable, k.AccessOf(1, RankLetter.F), "and the entrance is open");
        Assert.Equal(MapStatus.Unknown, k.StatusOfFloor(2), "2 is blank");
        Assert.Equal(MapStatus.Heard, k.StatusOfFloor("flr_001"), "by id");
        Assert.Equal(MapStatus.Unknown, k.StatusOfFloor("flr_999"), "unknown id is just Unknown");
        Assert.Equal(MapStatus.Unknown, k.StatusOfStair(null), "null stair");
    }

    public static void HearingNeverDowngradesAVisit()
    {
        var l = Lab(); var k = Know(l);
        Assert.True(k.VisitFloor(5), "visit");
        Assert.True(!k.HearFloor(5), "hearing a visited floor changes nothing");
        Assert.Equal(MapStatus.Visited, k.StatusOfFloor(5), "still Visited");
        Assert.True(!k.VisitFloor(5), "visiting twice changes nothing");
        Assert.True(k.HearFloor(6) && !k.HearFloor(6), "hearing twice changes nothing");
        Assert.True(k.VisitFloor(6), "a heard floor can then be visited");
        Assert.Equal(MapStatus.Visited, k.StatusOfFloor(6), "Visited");
    }

    public static void UnknownIdsAreRefused()
    {
        var l = Lab(); var k = Know(l);
        Assert.True(!k.HearFloor(0) && !k.HearFloor(121) && !k.HearFloor(-1), "hear");
        Assert.True(!k.VisitFloor(0) && !k.VisitFloor(121) && !k.VisitFloor(-1), "visit");
        Assert.True(!k.HearStair("nope") && !k.HearStair(null) && !k.HearStair("stair_120_121"), "hear stair");
        Assert.True(!k.FindStair("nope") && !k.FindStair(null), "find stair");
        Assert.Equal(0, k.Deepest, "nothing recorded");
        Assert.Equal(1, k.Save().Floors.Count, "only the starting rumour");
        Assert.Equal(0, k.Save().Stairs.Count, "no stairs");
    }

    public static void AccessProgressesUnknownHeardReachableVisited()
    {
        var l = Lab(); var k = Know(l);
        var r = RankLetter.F;
        Assert.Equal(FloorAccess.Unknown, k.AccessOf(2, r), "blank");
        k.HearFloor(2);
        Assert.Equal(FloorAccess.Heard, k.AccessOf(2, r), "rumoured");
        k.VisitFloor(1);
        Assert.Equal(FloorAccess.Reachable, k.AccessOf(2, r), "a walked floor above and a free stair");
        k.VisitFloor(2);
        Assert.Equal(FloorAccess.Visited, k.AccessOf(2, r), "walked");
        Assert.Equal(FloorAccess.Reachable, k.AccessOf(3, r), "the next one opens");
        Assert.Equal(FloorAccess.Unknown, k.AccessOf(4, r), "but not two ahead");
        Assert.Equal(FloorAccess.Unknown, k.AccessOf(0, r), "off the map");
        Assert.Equal(FloorAccess.Unknown, k.AccessOf(121, r), "off the map");
    }

    public static void AccessRespectsLicencesAndHiddenStairs()
    {
        var l = Lab(); var k = Know(l);
        k.VisitFloor(40);
        Assert.Equal(FloorAccess.Unknown, k.AccessOf(41, RankLetter.C), "licence not met");
        k.HearFloor(41);
        Assert.Equal(FloorAccess.Heard, k.AccessOf(41, RankLetter.C), "rumoured but out of reach");
        Assert.Equal(FloorAccess.Reachable, k.AccessOf(41, RankLetter.B), "licence met");
        k.VisitFloor(100);
        Assert.Equal(FloorAccess.Unknown, k.AccessOf(101, RankLetter.SS), "hidden stair, not found");
        k.HearStair("stair_100_101");
        Assert.Equal(FloorAccess.Unknown, k.AccessOf(101, RankLetter.SS), "a rumour of the stair does not open it");
        k.FindStair("stair_100_101");
        Assert.Equal(FloorAccess.Reachable, k.AccessOf(101, RankLetter.SS), "found");
    }

    public static void SaveAndLoadRoundTrip()
    {
        var l = Lab(); var k = Know(l);
        k.VisitFloor(1); k.VisitFloor(2); k.HearFloor(30); k.FindStair("stair_100_101"); k.HearStair("stair_110_111");
        var save = k.Save();
        Assert.Equal("flr_001,flr_002,flr_030", string.Join(",", save.Floors.Keys.OrderBy(x => x)), "floor keys are ids");
        Assert.Equal(MapStatus.Visited, save.Floors["flr_001"], "visited kept over the start rumour");
        var k2 = Know(l); k2.Load(save);
        Assert.Equal(MapStatus.Visited, k2.StatusOfFloor(2), "floor 2");
        Assert.Equal(MapStatus.Heard, k2.StatusOfFloor(30), "floor 30");
        Assert.Equal(MapStatus.Visited, k2.StatusOfStair("stair_100_101"), "found stair");
        Assert.Equal(MapStatus.Heard, k2.StatusOfStair("stair_110_111"), "heard stair");
        Assert.Equal(2, k2.Deepest, "deepest recomputed");
        save.Floors["flr_005"] = MapStatus.Visited;
        Assert.Equal(MapStatus.Unknown, k.StatusOfFloor(5), "the save is a copy, not a live view");
    }

    public static void LoadIsNullSafeAndIgnoresUnknownIds()
    {
        var l = Lab(); var k = Know(l);
        k.Load(null);
        Assert.Equal(MapStatus.Heard, k.StatusOfFloor(1), "null changes nothing");
        k.Load(new LabyrinthSave { Floors = null, Stairs = null });
        Assert.Equal(0, k.Deepest, "null dictionaries are fine");
        k.Load(new LabyrinthSave
        {
            Floors = new Dictionary<string, MapStatus> { ["flr_999"] = MapStatus.Visited, ["junk"] = MapStatus.Heard, ["flr_003"] = MapStatus.Unknown },
            Stairs = new Dictionary<string, MapStatus> { ["stair_x"] = MapStatus.Visited },
        });
        Assert.Equal(0, k.Deepest, "unknown ids ignored");
        Assert.Equal(MapStatus.Unknown, k.StatusOfFloor(3), "an Unknown entry adds nothing");
        Assert.Equal(1, k.Save().Floors.Count, "nothing leaked in");
        Assert.Equal(0, k.Save().Stairs.Count, "no stray stairs");
    }

    public static void LoadKeepsWhatIsAlreadyVisitedAndNeverDowngrades()
    {
        var l = Lab(); var k = Know(l);
        k.VisitFloor(10); k.FindStair("stair_100_101");
        k.Load(new LabyrinthSave
        {
            Floors = new Dictionary<string, MapStatus> { ["flr_010"] = MapStatus.Heard, ["flr_011"] = MapStatus.Visited },
            Stairs = new Dictionary<string, MapStatus> { ["stair_100_101"] = MapStatus.Heard },
        });
        Assert.Equal(MapStatus.Visited, k.StatusOfFloor(10), "Heard in a save does not downgrade");
        Assert.Equal(MapStatus.Visited, k.StatusOfFloor(11), "the save's visit is added");
        Assert.Equal(MapStatus.Visited, k.StatusOfStair("stair_100_101"), "stair kept");
        Assert.Equal(11, k.Deepest, "deepest");
    }

    // ---- the SaveGame field -------------------------------------------------------------------------------------

    public static void AnOldSaveWithoutTheLabyrinthFieldLoads()
    {
        var old = JsonSerializer.Deserialize<SaveGame>("{\"Version\":1,\"Level\":7,\"Copper\":120,\"Flags\":[\"flag_x\"]}", Opts);
        Assert.True(old.Labyrinth == null, "absent in an old save");
        Assert.Equal(0, SaveRules.Validate(old).Count, "still valid");
        var up = SaveRules.Upgrade(old);
        Assert.True(up.Labyrinth != null && up.Labyrinth.Floors != null && up.Labyrinth.Stairs != null, "Upgrade fills it");
        Assert.Equal(7, up.Level, "nothing else changed");
        var l = Lab();
        var fresh = Know(l); var loaded = Know(l); loaded.Load(up.Labyrinth);
        Assert.Equal(fresh.Deepest, loaded.Deepest, "deepest");
        Assert.Equal(string.Join(",", fresh.Save().Floors.OrderBy(kv => kv.Key).Select(kv => kv.Key + kv.Value)),
            string.Join(",", loaded.Save().Floors.OrderBy(kv => kv.Key).Select(kv => kv.Key + kv.Value)), "equals a new game");
        Assert.Equal(0, loaded.Save().Stairs.Count, "no stairs");
        Assert.Equal(SaveGame.CurrentVersion, up.Version, "version is the current one");
    }

    public static void ADamagedLabyrinthFieldIsRepaired()
    {
        var s = SaveRules.Upgrade(new SaveGame { Labyrinth = new LabyrinthSave { Floors = null, Stairs = null } });
        Assert.True(s.Labyrinth.Floors != null && s.Labyrinth.Stairs != null, "inner dictionaries null-coalesced");
        var j = SaveRules.Upgrade(JsonSerializer.Deserialize<SaveGame>("{\"Labyrinth\":null}", Opts));
        Assert.True(j.Labyrinth != null, "an explicit null is filled too");
    }

    public static void ALabyrinthRecordSurvivesASaveGameRoundTrip()
    {
        var l = Lab(); var k = Know(l);
        l.Descend(1, RankLetter.F, k); l.Descend(2, RankLetter.F, k);
        k.HearFloor(41); k.FindStair("stair_100_101");
        var save = new SaveGame { Labyrinth = k.Save() };
        var back = SaveRules.Upgrade(JsonSerializer.Deserialize<SaveGame>(JsonSerializer.Serialize(save), Opts));
        var k2 = Know(l); k2.Load(back.Labyrinth);
        Assert.Equal(MapStatus.Visited, k2.StatusOfFloor(3), "floor 3");
        Assert.Equal(MapStatus.Heard, k2.StatusOfFloor(41), "floor 41");
        Assert.Equal(MapStatus.Visited, k2.StatusOfStair("stair_100_101"), "stair");
        Assert.Equal(3, k2.Deepest, "deepest");
    }

    // ---- the map link -------------------------------------------------------------------------------------------

    public static void SyncToMapPencilsAndInksTheRightBand()
    {
        var l = Lab(); var k = Know(l); var map = FreshMap();
        // world_tuning already pencils the upper band in from the start, matching floor 1 being a rumour.
        Assert.Equal(MapStatus.Heard, map.StatusOf("reg_labyrinth_upper"), "pencilled from the start");
        Assert.Equal(0, k.SyncToMap(map), "floor 1 is a rumour: nothing new for the upper band");
        Assert.Equal(MapStatus.Heard, map.StatusOf("reg_labyrinth_upper"), "Heard");
        Assert.Equal(MapStatus.Unknown, map.StatusOf("reg_labyrinth_deep"), "deep still blank");
        Assert.Equal(0, k.SyncToMap(map), "a second sync changes nothing");
        k.VisitFloor(2);
        Assert.Equal(1, k.SyncToMap(map), "visiting inks it");
        Assert.Equal(MapStatus.Visited, map.StatusOf("reg_labyrinth_upper"), "Visited");
        k.HearFloor(50);
        k.SyncToMap(map);
        Assert.Equal(MapStatus.Heard, map.StatusOf("reg_labyrinth_deep"), "a rumour of 50 pencils the deep band");
        Assert.Equal(MapStatus.Unknown, map.StatusOf("reg_labyrinth_abyss"), "abyss blank");
        k.VisitFloor(95);
        k.SyncToMap(map);
        Assert.Equal(MapStatus.Visited, map.StatusOf("reg_labyrinth_abyss"), "abyss inked");
        Assert.Equal(MapStatus.Heard, map.StatusOf("reg_labyrinth_deep"), "deep unchanged");
        Assert.Equal(0, k.SyncToMap(null), "no map, no change");
    }

    public static void SyncNeverDowngradesAnInkedRegion()
    {
        var l = Lab(); var k = Know(l); var map = FreshMap();
        map.Visit("reg_labyrinth_upper");
        k.SyncToMap(map);
        Assert.Equal(MapStatus.Visited, map.StatusOf("reg_labyrinth_upper"), "stays inked");
    }

    public static void UnderworldLayersAreRegionsOnTheMap()
    {
        var map = FreshMap();
        foreach (var id in new[] { "reg_aurumdeep", "reg_labyrinth_upper" })
        {
            Assert.True(Repo.Db.Regions[id].Map != null, id + " has a map position");
            if (map.StatusOf(id) == MapStatus.Unknown) Assert.True(map.Hear(id), id + " heard");
            Assert.Equal(MapStatus.Heard, map.StatusOf(id), id + " pencilled");
            Assert.True(map.Visit(id), id + " visited");
            Assert.True(!map.Hear(id), id + " hearing never downgrades");
            Assert.Equal(MapStatus.Visited, map.StatusOf(id), id + " inked");
        }
    }

    // ---- the Underworld -----------------------------------------------------------------------------------------

    public static void ThereAreFiveUnderworldLayersInOrder()
    {
        var u = Uw();
        Assert.Equal(5, u.Layers.Count, "five");
        for (int n = 1; n <= 5; n++) Assert.Equal(n, u.Layer(n).Layer, "layer " + n);
        Assert.Equal("reg_umbravel", u.Layer(1).RegionId, "1");
        Assert.Equal("reg_hollow_sea", u.Layer(2).RegionId, "2");
        Assert.Equal("reg_aurumdeep", u.Layer(3).RegionId, "3");
        Assert.Equal("reg_the_maw", u.Layer(4).RegionId, "4");
        Assert.Equal("reg_root_of_the_world", u.Layer(5).RegionId, "5");
        Assert.Equal(2, u.Next(1).Layer, "next of 1");
        Assert.Equal(5, u.Next(4).Layer, "next of 4");
        Assert.True(u.Next(5) == null, "nothing below layer 5");
        Assert.True(u.Next(0) == null && u.Next(-1) == null, "nothing before layer 1");
        Assert.True(u.Layer(0) == null && u.Layer(6) == null, "out of range");
        Assert.Equal(4, u.ByRegion("reg_the_maw").Layer, "by region");
        Assert.True(u.ByRegion("reg_whisperwood") == null && u.ByRegion(null) == null, "a surface region is no layer");
    }

    public static void UnderworldRanksGateTheLayers()
    {
        var u = Uw();
        Assert.True(!u.CanEnter(1, RankLetter.D) && u.CanEnter(1, RankLetter.C), "Umbravel needs C");
        Assert.True(!u.CanEnter(2, RankLetter.C) && u.CanEnter(2, RankLetter.B), "Hollow Sea needs B");
        Assert.True(!u.CanEnter(3, RankLetter.B) && u.CanEnter(3, RankLetter.A), "Aurumdeep needs A");
        Assert.True(!u.CanEnter(4, RankLetter.A) && !u.CanEnter(4, RankLetter.B) && u.CanEnter(4, RankLetter.S), "the Maw needs S");
        Assert.True(!u.CanEnter(5, RankLetter.S) && u.CanEnter(5, RankLetter.SS), "the Root needs SS");
        Assert.True(!u.CanEnter(0, RankLetter.EX) && !u.CanEnter(6, RankLetter.EX), "no such layer");
    }

    public static void BackDoorsPairFloorsWithLayersBothWays()
    {
        var u = Uw();
        Assert.Equal(30, u.BackDoorFloor(3), "layer 3 <- floor 30");
        Assert.Equal(60, u.BackDoorFloor(4), "layer 4 <- floor 60");
        Assert.Equal(90, u.BackDoorFloor(5), "layer 5 <- floor 90");
        Assert.Equal(0, u.BackDoorFloor(1), "layer 1 has none");
        Assert.Equal(0, u.BackDoorFloor(2), "layer 2 has none");
        Assert.Equal(0, u.BackDoorFloor(9), "no such layer");
        Assert.Equal(3, u.LayerOfBackDoor(30), "30 -> 3");
        Assert.Equal(4, u.LayerOfBackDoor(60), "60 -> 4");
        Assert.Equal(5, u.LayerOfBackDoor(90), "90 -> 5");
        Assert.Equal(0, u.LayerOfBackDoor(31), "no door on 31");
        foreach (var layer in new[] { 3, 4, 5 }) Assert.Equal(layer, u.LayerOfBackDoor(u.BackDoorFloor(layer)), "round trip " + layer);
    }

    public static void OnlyTheMawHasWeavePressure()
    {
        var u = Uw();
        for (int n = 1; n <= 5; n++) Assert.Equal(n == 4, u.HasWeavePressure(n), "layer " + n);
        Assert.True(!u.HasWeavePressure(0) && !u.HasWeavePressure(6), "no such layer");
    }

    // ---- bad data -----------------------------------------------------------------------------------------------

    static void ThrowsArg(Action a, string what) => Assert.Throws<ArgumentException>(a, what);

    public static void BadLabyrinthDataIsRejected()
    {
        ThrowsArg(() => new Labyrinth(null), "null data");
        var d = RawLab(); d.Floors.RemoveAt(119);
        ThrowsArg(() => new Labyrinth(d), "119 floors");
        d = RawLab(); d.FloorCount = 121;
        ThrowsArg(() => new Labyrinth(d), "floor count says 121");
        d = RawLab(); d.Floors[10].N = 99;
        ThrowsArg(() => new Labyrinth(d), "non-contiguous floors");
        d = RawLab(); (d.Floors[4], d.Floors[5]) = (d.Floors[5], d.Floors[4]);
        ThrowsArg(() => new Labyrinth(d), "floors out of order");
        d = RawLab(); d.Stairs[7].To = d.Stairs[7].From + 2;
        ThrowsArg(() => new Labyrinth(d), "a stair that is not N to N+1");
        d = RawLab(); d.Stairs.RemoveAt(20);
        ThrowsArg(() => new Labyrinth(d), "a missing stair");
        d = RawLab(); d.Stairs[3].LicenceRank = "Q";
        ThrowsArg(() => new Labyrinth(d), "a garbled licence");
        d = RawLab(); d.Floors[0].Band = "nowhere";
        ThrowsArg(() => new Labyrinth(d), "a floor in no band");
        d = RawLab(); d.BackDoors[0].Floor = 500;
        ThrowsArg(() => new Labyrinth(d), "a back-door off the map");
        Assert.True(new Labyrinth(RawLab()) != null, "the real data is fine");
    }

    public static void BadUnderworldDataIsRejected()
    {
        var lab = Lab();
        ThrowsArg(() => new UnderworldRegistry(null, lab), "null data");
        ThrowsArg(() => new UnderworldRegistry(new UnderworldData(), lab), "no layers");
        ThrowsArg(() => new UnderworldRegistry(RawUw(), null), "no labyrinth");
        var d = RawUw(); d.Layers.RemoveAt(1);
        ThrowsArg(() => new UnderworldRegistry(d, lab), "a gap in the layer numbers");
        d = RawUw(); (d.Layers[0], d.Layers[1]) = (d.Layers[1], d.Layers[0]);
        ThrowsArg(() => new UnderworldRegistry(d, lab), "layers out of order");
        d = RawUw(); d.Layers[1].RegionId = d.Layers[0].RegionId;
        ThrowsArg(() => new UnderworldRegistry(d, lab), "a duplicate region");
        d = RawUw(); d.Layers[0].RankMin = "??";
        ThrowsArg(() => new UnderworldRegistry(d, lab), "a bad rank");
        d = RawUw(); d.Layers[2].LabyrinthBackDoor = "bd_060";
        ThrowsArg(() => new UnderworldRegistry(d, lab), "a back-door that leads elsewhere");
        d = RawUw(); d.Layers[2].LabyrinthBackDoor = "bd_missing";
        ThrowsArg(() => new UnderworldRegistry(d, lab), "a back-door that does not exist");
        Assert.True(new UnderworldRegistry(RawUw(), lab) != null, "the real data is fine");
    }
}
