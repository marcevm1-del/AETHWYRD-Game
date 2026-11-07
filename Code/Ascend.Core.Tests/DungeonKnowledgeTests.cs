using System.Collections.Generic;
using System.Text.Json;
using Ascend.Core;

// Wave E secrets and clue record (Unknown / Heard / Visited) and its save field.
[Tests]
static class DungeonKnowledgeTests
{
    static readonly JsonSerializerOptions Opts = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    static DungeonKnowledge Fresh() => new DungeonKnowledge(Repo.Db.Dungeons["dng_salvage_warren"]);

    public static void EverythingStartsUnknown()
    {
        var k = Fresh();
        Assert.Equal(MapStatus.Unknown, k.StatusOfRoom("rm_scrap_hall"), "room");
        Assert.Equal(MapStatus.Unknown, k.StatusOfClue("clue_chalk_marks"), "clue");
        Assert.Equal(MapStatus.Unknown, k.StatusOfRoom("rm_nowhere"), "unknown id is just Unknown");
        Assert.Equal(MapStatus.Unknown, k.StatusOfRoom(null), "null id");
    }

    public static void HearingPencilsAndVisitingInksAndNeverDowngrades()
    {
        var k = Fresh();
        Assert.True(k.HearRoom("rm_scrap_hall") && !k.HearRoom("rm_scrap_hall"), "hear once");
        Assert.Equal(MapStatus.Heard, k.StatusOfRoom("rm_scrap_hall"), "pencilled");
        Assert.True(k.VisitRoom("rm_scrap_hall") && !k.VisitRoom("rm_scrap_hall"), "visit once");
        Assert.True(!k.HearRoom("rm_scrap_hall"), "hearing after a visit does nothing");
        Assert.Equal(MapStatus.Visited, k.StatusOfRoom("rm_scrap_hall"), "still inked");
        Assert.True(!k.VisitRoom("rm_nowhere") && !k.HearRoom("rm_nowhere"), "unknown rooms are refused");
    }

    public static void AHeardSecretCluePencilsTheSecretRoomButRevealsNothing()
    {
        var k = Fresh();
        var way = Repo.Db.Dungeons["dng_salvage_warren"].Connections.Find(c => c.Id == "cn_lower_cistern");
        Assert.True(k.HearClue("clue_cistern_draught"), "heard");
        Assert.Equal(MapStatus.Heard, k.StatusOfRoom("rm_rune_cistern"), "the secret room is pencilled");
        Assert.True(!k.IsRevealed(way), "the way is still hidden");
        Assert.True(k.VisitClue("clue_cistern_draught"), "found in place");
        Assert.True(k.IsRevealed(way), "now it is revealed");
        Assert.True(!k.HearClue("clue_cistern_draught"), "hearing never downgrades");
        Assert.Equal(MapStatus.Visited, k.StatusOfClue("clue_cistern_draught"), "still found");
        Assert.True(!k.VisitClue("clue_nope") && !k.HearClue("clue_nope"), "unknown clues refused");
    }

    public static void SaveAndLoadRoundTrip()
    {
        var k = Fresh();
        k.VisitRoom("rm_chalk_landing"); k.HearRoom("rm_beetle_vault");
        k.VisitClue("clue_chalk_marks"); k.HearClue("clue_cistern_draught"); k.Cleared = true;
        var json = JsonSerializer.Serialize(k.Save());
        var k2 = Fresh();
        k2.Load(JsonSerializer.Deserialize<DungeonProgressSave>(json, Opts));
        Assert.Equal(MapStatus.Visited, k2.StatusOfRoom("rm_chalk_landing"), "visited room");
        Assert.Equal(MapStatus.Heard, k2.StatusOfRoom("rm_beetle_vault"), "heard room");
        Assert.Equal(MapStatus.Visited, k2.StatusOfClue("clue_chalk_marks"), "found clue");
        Assert.Equal(MapStatus.Heard, k2.StatusOfClue("clue_cistern_draught"), "heard clue");
        Assert.Equal(MapStatus.Heard, k2.StatusOfRoom("rm_rune_cistern"), "its secret room");
        Assert.True(k2.Cleared, "cleared flag");
    }

    public static void LoadingNullOrDamagedProgressIsSafe()
    {
        var k = Fresh();
        k.Load(null);
        k.Load(new DungeonProgressSave { Rooms = null, Clues = null });
        k.Load(new DungeonProgressSave { Rooms = new Dictionary<string, MapStatus> { ["rm_gone_from_data"] = MapStatus.Visited }, Clues = new Dictionary<string, MapStatus> { ["clue_gone"] = MapStatus.Visited } });
        Assert.Equal(MapStatus.Unknown, k.StatusOfRoom("rm_gone_from_data"), "ids the data no longer has are ignored");
        k.VisitRoom("rm_scrap_hall");
        k.Load(new DungeonProgressSave { Rooms = new Dictionary<string, MapStatus> { ["rm_scrap_hall"] = MapStatus.Heard } });
        Assert.Equal(MapStatus.Visited, k.StatusOfRoom("rm_scrap_hall"), "an older Heard never downgrades a visit");
    }

    public static void AnOldSaveWithoutTheDungeonFieldLoads()
    {
        // A save written before Wave E has no "Dungeons" key at all.
        var old = JsonSerializer.Deserialize<SaveGame>("{\"Version\":1,\"Level\":7,\"Copper\":120,\"Flags\":[\"flag_x\"]}", Opts);
        Assert.True(old.Dungeons == null, "the field is absent in an old save");
        Assert.Equal(0, SaveRules.Validate(old).Count, "an old save is still valid");
        var up = SaveRules.Upgrade(old);
        Assert.True(up.Dungeons != null && up.Dungeons.Dungeons != null, "the loader fills it in");
        Assert.Equal(7, up.Level, "nothing else changed");
        var k = Fresh();
        k.Load(up.Dungeons.Dungeons.TryGetValue("dng_salvage_warren", out var p) ? p : null);
        Assert.Equal(MapStatus.Unknown, k.StatusOfRoom("rm_chalk_landing"), "a fresh record");
    }

    public static void ASaveWithADamagedDungeonFieldIsRepaired()
    {
        var s = SaveRules.Upgrade(new SaveGame { Dungeons = new DungeonSave { Dungeons = null } });
        Assert.True(s.Dungeons.Dungeons != null, "inner dictionary null-coalesced too");
    }

    public static void TheDungeonRecordSurvivesASaveGameRoundTrip()
    {
        var k = Fresh(); k.VisitRoom("rm_lower_landing"); k.VisitClue("clue_cistern_draught");
        var save = new SaveGame { Dungeons = new DungeonSave() };
        save.Dungeons.Dungeons["dng_salvage_warren"] = k.Save();
        var back = SaveRules.Upgrade(JsonSerializer.Deserialize<SaveGame>(JsonSerializer.Serialize(save), Opts));
        var k2 = Fresh(); k2.Load(back.Dungeons.Dungeons["dng_salvage_warren"]);
        Assert.Equal(MapStatus.Visited, k2.StatusOfRoom("rm_lower_landing"), "room");
        Assert.Equal(MapStatus.Visited, k2.StatusOfClue("clue_cistern_draught"), "clue");
    }

    public static void ARunSharesItsKnowledgeWithTheSave()
    {
        var k = Fresh();
        var run = new DungeonRun(Repo.Db.Dungeons["dng_salvage_warren"], Repo.Db.Puzzles, k);
        Assert.Equal(MapStatus.Visited, k.StatusOfRoom("rm_chalk_landing"), "entering inks the entrance");
        run.Move("cn_landing_hall", out _);
        Assert.Equal(MapStatus.Visited, k.Save().Rooms["rm_scrap_hall"], "the save sees the new room");
    }
}
