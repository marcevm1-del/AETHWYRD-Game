using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Ascend.Core;

// Wave E adversarial QA: odd data, boundaries, save order, parallel ways, two-way key doors.
[Tests]
static class WaveEQaTests
{
    static readonly JsonSerializerOptions Opts = new() { PropertyNameCaseInsensitive = true };

    static DungeonData Warren() => Repo.Db.Dungeons["dng_salvage_warren"];

    static DungeonRoom Room(string id, bool checkpoint = false) => new DungeonRoom { Id = id, Name = id, Checkpoint = checkpoint, Role = checkpoint ? "entry" : "hub" };

    static DungeonConnection Conn(string id, string from, string to, string key = null) =>
        new DungeonConnection { Id = id, From = from, To = to, Kind = key == null ? "passage" : "door", RequiresKey = key };

    static DungeonData Tiny(params DungeonConnection[] conns)
    {
        var d = new DungeonData { Id = "dng_tiny", RegionId = "reg_x", EntryRoom = "a" };
        d.Rooms.Add(Room("a", true)); d.Rooms.Add(Room("b"));
        d.Connections.AddRange(conns);
        return d;
    }

    // ---- puzzles with odd data ----

    public static void LeverPuzzleWithEmptySequenceNeverSolvesAndNeverThrows()
    {
        var p = (LeverPuzzle)Puzzle.Create(new PuzzleData { Id = "pz", Type = PuzzleTypes.LeverSequence, Levers = new List<string> { "a" } });
        Assert.True(!p.IsSolvable(), "empty sequence is unsolvable");
        Assert.Equal(LeverResult.Wrong, p.Pull("a"), "any pull is wrong");
        Assert.Equal(LeverResult.Ignored, p.Pull("zzz"), "unknown lever ignored");
        Assert.True(p.Assist() == null, "no assist for nothing to do");
        Assert.True(p.Skip() && p.Status == PuzzleStatus.Skipped, "can still be skipped for free");
    }

    public static void PlatePuzzleWithNoObjectsIsInvalidForEveryMoveAndUnsolvable()
    {
        var p = (PlatePuzzle)Puzzle.Create(new PuzzleData { Id = "pz", Type = PuzzleTypes.PressurePlate, Plates = new List<PlateData> { new PlateData { Id = "p1", Weight = 3 } } });
        Assert.Equal(PlateResult.Invalid, p.Place("o1", "p1"), "no such object");
        Assert.Equal(PlateResult.Invalid, p.Place(null, "p1"), "null object");
        Assert.True(!p.IsSolvable(), "weight 3 with nothing to place cannot be solved");
        Assert.True(p.Assist() == null, "no assist");
        Assert.True(!p.Remove("o1") && !p.Remove(null), "nothing to remove");
        var none = (PlatePuzzle)Puzzle.Create(new PuzzleData { Id = "pz2", Type = PuzzleTypes.PressurePlate });
        Assert.True(!none.IsSolvable() && none.Place("o", "p") == PlateResult.Invalid, "no plates at all");
    }

    public static void RunePuzzleWithoutGlyphsDoesNotDivideByZero()
    {
        var data = new PuzzleData
        {
            Id = "pz", Type = PuzzleTypes.RuneMatch,
            Sconces = new List<SconceData> { new SconceData { Id = "s1", Start = "x", Target = "y" } },
        };
        var p = (RunePuzzle)Puzzle.Create(data);
        Assert.True(!p.Turn("s1"), "turning with no glyphs is refused, not a crash");
        Assert.True(p.GlyphAt("s1") == null, "no glyph to show");
        Assert.True(!p.IsSolvable(), "unsolvable");
        p.Skip();
        Assert.True(p.Assist() == null, "assist does not throw");
    }

    public static void NullHintListDoesNotBreakAssistOrHints()
    {
        var data = new PuzzleData { Id = "pz", Type = PuzzleTypes.LeverSequence, Levers = new List<string> { "a" }, Sequence = new List<string> { "a" }, Hints = null };
        var p = Puzzle.Create(data);
        Assert.True(p.NextHint() == null, "no hints");
        Assert.True(!p.AssistAvailable, "no fails yet and no hints to read");
        for (int i = 0; i < 3; i++) ((LeverPuzzle)p).Pull("zz");
        ((LeverPuzzle)p).Pull("a"); // sequence is just "a": solves
        Assert.Equal(PuzzleStatus.Solved, p.Status, "solved");
    }

    public static void RunePuzzleAssistWalksToTheSolutionFromAnyState()
    {
        var data = new PuzzleData
        {
            Id = "pz", Type = PuzzleTypes.RuneMatch, Glyphs = new List<string> { "a", "b", "c" },
            Sconces = new List<SconceData>
            {
                new SconceData { Id = "s1", Start = "a", Target = "c", Also = new List<string> { "s2", "ghost" } },
                new SconceData { Id = "s2", Start = "a", Target = "b" },
            },
        };
        var p = (RunePuzzle)Puzzle.Create(data, new PuzzleTuning { FailsBeforeAssist = 0 });
        Assert.True(p.IsSolvable(), "solvable");
        for (int i = 0; i < 20 && p.Status != PuzzleStatus.Solved; i++)
        {
            var a = p.Assist();
            Assert.True(a != null && a.Kind == "turn", "assist names a sconce at step " + i);
            Assert.True(p.Turn(a.Target), "assist target is turnable");
        }
        Assert.Equal(PuzzleStatus.Solved, p.Status, "following the assist solves it");
        Assert.True(!p.Turn("s1"), "a solved lock ignores further turns");
    }

    // ---- dungeon layout edge cases ----

    public static void TwoParallelWaysBetweenTheSameRoomsAreIndependent()
    {
        var d = Tiny(Conn("c_free", "a", "b"), Conn("c_locked", "a", "b", "key_x"));
        d.Rooms[0].Keys.Add("key_x");
        Assert.True(DungeonRules.Validate(d, null).Count == 0, "parallel ways validate: " + string.Join("; ", DungeonRules.Validate(d, null)));
        var r = new DungeonRun(d);
        Assert.True(!r.Move("c_locked", out var why) && why == "locked", "second way is locked until the key");
        Assert.True(r.Move("c_free", out _), "first way is open");
        Assert.Equal("b", r.Room, "arrived");
        Assert.True(r.ExitsHere().Count() == 2, "both ways are listed");
    }

    public static void TwoWayKeyDoorWorksBothWaysOnceTheKeyIsHeldAndRelocksOnReset()
    {
        var d = Tiny(Conn("c_door", "a", "b", "key_x"));
        d.Rooms[0].Keys.Add("key_x");
        Assert.True(DungeonRules.Validate(d, null).Count == 0, "valid");
        var r = new DungeonRun(d);
        Assert.True(!r.Move("c_door", out _), "locked at first");
        Assert.True(r.TakeKey("key_x"), "key lies in the entry room");
        Assert.True(r.Move("c_door", out _) && r.Room == "b", "through");
        Assert.True(r.Move("c_door", out _) && r.Room == "a", "and back: keys are never used up");
        r.Move("c_door", out _);
        r.Die();
        Assert.True(r.Keys.Contains("key_x"), "dying keeps keys");
        r.Reset();
        Assert.True(r.Keys.Count == 0 && !r.Move("c_door", out var why) && why == "locked", "the weekly reset locks it again");
    }

    public static void KeyOnlyBehindItsOwnDoorIsASoftLockedValidatorError()
    {
        var d = Tiny(Conn("c_door", "a", "b", "key_x"));
        d.Rooms[1].Keys.Add("key_x");
        var errs = DungeonRules.Validate(d, null);
        Assert.True(errs.Any(e => e.Contains("cannot be reached")), "room b never reachable: " + string.Join("; ", errs));
    }

    public static void DungeonWithNoBossValidatesAndHasNothingToDefeat()
    {
        // Documents current behaviour: neither Core nor dungeon_checks.js demands a boss, only that a boss role has a slot.
        var d = Tiny(Conn("c1", "a", "b"));
        var errs = DungeonRules.Validate(d, null);
        Assert.True(errs.Count == 0, "no boss is accepted: " + string.Join("; ", errs));
        var r = new DungeonRun(d);
        Assert.True(!r.DefeatBoss() && !r.Knowledge.Cleared, "no boss to defeat, not cleared");
    }

    public static void DefeatingTheBossMarksTheDungeonClearedAndTheMarkSurvivesReset()
    {
        var r = new DungeonRun(Warren(), Repo.Db.Puzzles);
        foreach (var c in new[] { "cn_landing_hall" }) Assert.True(r.Move(c, out _), c);
        var p = (LeverPuzzle)r.PuzzleById("pzl_warren_levers");
        foreach (var s in p.Data.Sequence) p.Pull(s);
        foreach (var c in new[] { "cn_hall_lower_lift", "cn_lower_vault" }) Assert.True(r.Move(c, out _), c);
        Assert.True(!r.Knowledge.Cleared, "not cleared before the kill");
        Assert.True(r.DefeatBoss(), "boss falls");
        Assert.True(r.Knowledge.Cleared, "journal remembers the clear");
        r.Reset();
        Assert.True(!r.BossDefeated && r.Knowledge.Cleared, "boss stands again but the clear is kept");
        Assert.True(r.Knowledge.Save().Cleared, "and it is saved");
    }

    public static void OneWayConnectionCannotBeWalkedBackwards()
    {
        var d = Tiny(new DungeonConnection { Id = "c1", From = "a", To = "b", Kind = "shortcut", OneWay = true });
        d.Connections.Add(Conn("c_back", "b", "a"));
        var r = new DungeonRun(d);
        Assert.True(r.Move("c1", out _), "forward");
        Assert.True(!r.Move("c1", out var why) && why == "not here", "not backwards: " + why);
        Assert.True(r.ExitsHere().All(c => c.Id != "c1"), "one-way is not offered from its far end");
    }

    // ---- knowledge: order and round trips ----

    public static void HeardThenVisitedUpgradesAndVisitedThenHeardDoesNot()
    {
        var d = Warren();
        var k = new DungeonKnowledge(d);
        Assert.True(k.HearRoom("rm_scrap_hall") && !k.HearRoom("rm_scrap_hall"), "heard once");
        Assert.Equal(MapStatus.Heard, k.StatusOfRoom("rm_scrap_hall"), "pencilled");
        Assert.True(k.VisitRoom("rm_scrap_hall"), "visiting a heard room inks it");
        Assert.Equal(MapStatus.Visited, k.StatusOfRoom("rm_scrap_hall"), "visited");
        Assert.True(!k.HearRoom("rm_scrap_hall"), "hearing never downgrades");
        Assert.Equal(MapStatus.Visited, k.StatusOfRoom("rm_scrap_hall"), "still visited");

        Assert.True(k.HearClue("clue_cistern_draught"), "rumour of the clue");
        Assert.Equal(MapStatus.Heard, k.StatusOfRoom("rm_rune_cistern"), "it pencils the secret room");
        var conn = d.Connections.First(c => c.Id == "cn_lower_cistern");
        Assert.True(!k.IsRevealed(conn), "heard reveals nothing");
        Assert.True(k.VisitClue("clue_cistern_draught") && k.IsRevealed(conn), "found in place reveals the way");
        Assert.True(!k.HearClue("clue_cistern_draught"), "no downgrade of a found clue");
        Assert.Equal(MapStatus.Visited, k.StatusOfClue("clue_cistern_draught"), "still found");
    }

    public static void RunSharesKnowledgeAndAHeardEntryRoomBecomesVisited()
    {
        var k = new DungeonKnowledge(Warren());
        k.HearRoom("rm_chalk_landing");
        var r = new DungeonRun(Warren(), Repo.Db.Puzzles, k);
        Assert.Equal(MapStatus.Visited, k.StatusOfRoom("rm_chalk_landing"), "standing in the entry inks it");
    }

    public static void SaveLoadOrderAndUnknownValuesAreHarmless()
    {
        var d = Warren();
        var save = new DungeonProgressSave();
        save.Rooms["rm_scrap_hall"] = MapStatus.Heard;
        save.Rooms["rm_chalk_landing"] = MapStatus.Visited;
        save.Rooms["rm_gone"] = MapStatus.Visited;
        save.Rooms["rm_beetle_vault"] = MapStatus.Unknown;
        save.Rooms["rm_lower_landing"] = (MapStatus)99;
        save.Clues["clue_cistern_draught"] = MapStatus.Heard;
        save.Clues["clue_gone"] = MapStatus.Heard;
        var json = JsonSerializer.Serialize(save);
        var back = JsonSerializer.Deserialize<DungeonProgressSave>(json, Opts);
        var k = new DungeonKnowledge(d);
        k.Load(back);
        Assert.Equal(MapStatus.Visited, k.StatusOfRoom("rm_chalk_landing"), "visited kept");
        Assert.Equal(MapStatus.Heard, k.StatusOfRoom("rm_scrap_hall"), "heard kept");
        Assert.Equal(MapStatus.Unknown, k.StatusOfRoom("rm_beetle_vault"), "unknown stays blank");
        Assert.Equal(MapStatus.Unknown, k.StatusOfRoom("rm_lower_landing"), "out-of-range status is ignored");
        Assert.Equal(MapStatus.Unknown, k.StatusOfRoom("rm_gone"), "ids the data lost are ignored");
        Assert.Equal(MapStatus.Heard, k.StatusOfRoom("rm_rune_cistern"), "heard clue pencils the secret room");
        // Loading an older, smaller save on top of richer knowledge never downgrades it.
        k.VisitRoom("rm_scrap_hall");
        k.Load(back);
        Assert.Equal(MapStatus.Visited, k.StatusOfRoom("rm_scrap_hall"), "load never downgrades");
        // Null and empty saves change nothing.
        k.Load(null); k.Load(new DungeonProgressSave { Rooms = null, Clues = null });
        Assert.Equal(MapStatus.Visited, k.StatusOfRoom("rm_chalk_landing"), "null parts tolerated");
    }

    public static void EnumsRoundTripAsStringsToo()
    {
        var o = new JsonSerializerOptions(Opts); o.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
        var save = new DungeonProgressSave { Cleared = true };
        save.Rooms["rm_chalk_landing"] = MapStatus.Visited; save.Clues["clue_chalk_marks"] = MapStatus.Heard;
        var back = JsonSerializer.Deserialize<DungeonProgressSave>(JsonSerializer.Serialize(save, o), o);
        Assert.Equal(MapStatus.Visited, back.Rooms["rm_chalk_landing"], "room status");
        Assert.Equal(MapStatus.Heard, back.Clues["clue_chalk_marks"], "clue status");
        Assert.True(back.Cleared, "cleared flag");
    }

    // ---- Core vs validator agreement on the shipped data ----

    public static void EveryShippedPuzzleIsSolvableAndEveryShippedDungeonValidates()
    {
        foreach (var p in Repo.Db.Puzzles.Puzzles) Assert.True(Puzzle.Create(p, Repo.Db.Puzzles.Tuning).IsSolvable(), p.Id + " solvable");
        foreach (var d in Repo.Db.Dungeons.Values)
        {
            var errs = DungeonRules.Validate(d, Repo.Db, Repo.Db.Puzzles);
            Assert.True(errs.Count == 0, d.Id + ": " + string.Join("; ", errs));
        }
    }
}
