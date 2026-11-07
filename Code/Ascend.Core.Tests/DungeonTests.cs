using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Ascend.Core;

// Wave E dungeon layout: The Salvage Warren (Great Labyrinth floors 3-4). Canon: puzzles never gate progress,
// cores are never allies, dungeons stay reusable, no soft-locks.
[Tests]
static class DungeonTests
{
    static readonly JsonSerializerOptions Opts = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    static DungeonData Warren() => Repo.Db.Dungeons["dng_salvage_warren"];
    static DungeonData Clone(DungeonData d) => JsonSerializer.Deserialize<DungeonData>(JsonSerializer.Serialize(d), Opts);
    static List<string> Check(DungeonData d) => DungeonRules.Validate(d, Repo.Db, Repo.Db.Puzzles);
    static string All(List<string> l) => string.Join(" | ", l);

    // ---- the real layout ----
    public static void SalvageWarrenValidates()
    {
        var errors = Check(Warren());
        Assert.Equal(0, errors.Count, "no problems: " + All(errors));
    }

    public static void SliceHasTheRequestedShape()
    {
        var d = Warren();
        Assert.True(d.Rooms.Count >= 4 && d.Rooms.Count <= 6, "4 to 6 rooms, got " + d.Rooms.Count);
        Assert.Equal(2, d.Rooms.Select(r => r.Level).Distinct().Count(), "two levels");
        Assert.Equal("reg_labyrinth_upper", d.RegionId, "a Great Labyrinth entry");
        Assert.True(d.Rooms.Count(r => r.Checkpoint) >= 2, "a checkpoint on each level");
        Assert.True(d.Rooms.Any(r => r.Secret), "a secret room");
        Assert.True(d.Rooms.Any(r => r.Keys.Count > 0) && d.Connections.Any(c => c.RequiresKey != null), "a key and a locked door");
        Assert.True(d.Connections.Any(c => c.RequiresPuzzle != null), "a mechanism-opened way");
        Assert.True(d.Connections.Any(c => c.OneWay && c.Kind == "shortcut"), "a shortcut");
        Assert.Equal(1, d.Rooms.Count(r => r.Boss != null), "one boss slot");
        Assert.True(d.Rooms.SelectMany(r => r.Puzzles).Count() == 3, "all three puzzle types placed");
    }

    public static void CanonFlagsHold()
    {
        var d = Warren();
        Assert.True(d.Reusable, "dungeons stay reusable");
        Assert.True(!d.CoreIsAlly, "dungeon cores are never allies");
        Assert.True(Repo.Db.Puzzles.Puzzles.All(p => p.Optional), "no puzzle is mandatory");
    }

    public static void BossIsAnExistingSpeciesWithItsDataUntouched()
    {
        var boss = Warren().Rooms.First(r => r.Boss != null).Boss.SpeciesId;
        Assert.True(Repo.Db.Species.ContainsKey(boss), "existing species");
        Assert.True(Repo.Db.Species[boss].Habitats.Contains("reg_labyrinth_upper"), "lives in the Labyrinth");
        Assert.True(!Repo.Db.Bosses.ContainsKey(boss), "no new phases were invented for it");
        Assert.True(Repo.Db.Bosses.ContainsKey("mon_grukk_goblin_chief_of_hollowpine"), "Grukk's phases are still there");
    }

    public static void EverySpawnIsARealSpeciesOfTheRegion()
    {
        foreach (var s in Warren().Rooms.SelectMany(r => r.Spawns))
        {
            Assert.True(Repo.Db.Species.ContainsKey(s.SpeciesId), s.SpeciesId + " exists");
            Assert.True(Repo.Db.Species[s.SpeciesId].Habitats.Contains("reg_labyrinth_upper"), s.SpeciesId + " lives there");
            Assert.True(s.Min <= s.Max, s.SpeciesId + " min <= max");
        }
    }

    public static void BossAndEveryNonSecretRoomAreReachableWithNoPuzzleAndNoSecret()
    {
        var d = Warren();
        var req = DungeonRules.ReachableRooms(d, false);
        foreach (var r in d.Rooms.Where(r => !r.Secret)) Assert.True(req.Contains(r.Id), r.Id + " reachable on the required path");
        Assert.True(req.Contains(d.Rooms.First(r => r.Boss != null).Id), "boss reachable");
        Assert.True(!req.Contains("rm_rune_cistern"), "the secret room is optional");
        Assert.True(DungeonRules.ReachableRooms(d, true).Contains("rm_rune_cistern"), "and it can be found");
    }

    public static void NoSoftLockWithOrWithoutTheOptionalContent()
    {
        Assert.Equal(0, DungeonRules.SoftLocks(Warren(), false).Count, "required path: " + All(DungeonRules.SoftLocks(Warren(), false)));
        Assert.Equal(0, DungeonRules.SoftLocks(Warren(), true).Count, "everything open: " + All(DungeonRules.SoftLocks(Warren(), true)));
    }

    // ---- the validator rejects broken layouts ----
    public static void MakingAPuzzleTheOnlyWayOnIsRejected()
    {
        var d = Clone(Warren());
        d.Connections.RemoveAll(c => c.Id == "cn_hall_lower_door");
        var e = All(Check(d));
        Assert.True(e.Contains("never the only way") || e.Contains("must be reachable without any puzzle"), "mandatory puzzle caught: " + e);
    }

    public static void AKeyNobodyCanFindIsRejected()
    {
        var d = Clone(Warren());
        d.Rooms.First(r => r.Keys.Count > 0).Keys.Clear();
        d.Connections.RemoveAll(c => c.Id == "cn_hall_lower_lift");
        Assert.True(Check(d).Count > 0, "a door with no key and no other way is rejected: " + All(Check(d)));
    }

    public static void AKeyBehindItsOwnDoorIsRejected()
    {
        var d = Clone(Warren());
        d.Rooms.First(r => r.Keys.Count > 0).Keys.Clear();
        d.Rooms.First(r => r.Id == "rm_lower_landing").Keys.Add("key_rusted_tally");
        d.Connections.RemoveAll(c => c.Id == "cn_hall_lower_lift");
        var e = All(Check(d));
        Assert.True(e.Contains("boss room must be reachable"), "key behind its own door caught: " + e);
    }

    public static void AOneWayDropIntoADeadEndIsASoftLock()
    {
        var d = Clone(Warren());
        d.Connections.First(c => c.Id == "cn_hall_gallery").OneWay = true;
        var e = All(Check(d));
        Assert.True(e.Contains("soft-lock"), "one-way into the key room traps the player: " + e);
    }

    public static void ABossRoomTheKeyRouteCannotReachIsRejected()
    {
        var d = Clone(Warren());
        d.Connections.First(c => c.Id == "cn_lower_vault").OneWay = true;
        d.Connections.First(c => c.Id == "cn_lower_vault").From = "rm_beetle_vault";
        d.Connections.First(c => c.Id == "cn_lower_vault").To = "rm_lower_landing";
        Assert.True(Check(d).Count > 0, "a boss room only reachable the wrong way round is rejected");
    }

    public static void ASecretRoomWithAPlainDoorIsRejected()
    {
        var d = Clone(Warren());
        d.Connections.Add(new DungeonConnection { Id = "cn_extra", From = "rm_scrap_hall", To = "rm_rune_cistern", Kind = "passage" });
        Assert.True(All(Check(d)).Contains("marked secret but reachable"), "secret must be secret");
    }

    public static void AnUnmarkedRoomBehindAPuzzleIsRejected()
    {
        var d = Clone(Warren());
        d.Rooms.First(r => r.Id == "rm_rune_cistern").Secret = false;
        Assert.True(All(Check(d)).Contains("not marked secret"), "optional content must not hide a required room");
    }

    public static void CanonFlagsAreEnforced()
    {
        var a = Clone(Warren()); a.CoreIsAlly = true;
        Assert.True(All(Check(a)).Contains("never allies"), "core ally");
        var b = Clone(Warren()); b.Reusable = false;
        Assert.True(All(Check(b)).Contains("reusable"), "reusable");
    }

    public static void BadReferencesAreRejected()
    {
        var a = Clone(Warren()); a.Rooms[0].Spawns.Add(new DungeonSpawn { SpeciesId = "mon_nonsense", Min = 1, Max = 1 });
        Assert.True(All(Check(a)).Contains("unknown species"), "unknown species");
        var b = Clone(Warren()); b.Rooms[0].Spawns.Add(new DungeonSpawn { SpeciesId = "mon_blue_slime", Min = 1, Max = 1 });
        Assert.True(All(Check(b)).Contains("does not live in"), "wrong habitat");
        var c = Clone(Warren()); c.Rooms[1].Puzzles.Add("pzl_missing");
        Assert.True(All(Check(c)).Contains("unknown puzzle"), "unknown puzzle");
        var e = Clone(Warren()); e.Connections.First(x => x.Id == "cn_lower_cistern").RevealedByClue = "clue_missing";
        Assert.True(All(Check(e)).Contains("unknown clue"), "unknown clue");
        var f = Clone(Warren()); f.EntryRoom = "rm_nowhere";
        Assert.True(All(Check(f)).Contains("not a room"), "entry");
        var g = Clone(Warren()); g.Rooms.First(r => r.Id == "rm_chalk_landing").Checkpoint = false;
        Assert.True(All(Check(g)).Contains("entry room must be a checkpoint"), "entry checkpoint");
    }

    // ---- a run ----
    static DungeonRun Run() => new DungeonRun(Warren(), Repo.Db.Puzzles);

    static void Go(DungeonRun r, params string[] conns)
    {
        foreach (var c in conns) Assert.True(r.Move(c, out var why), c + " should open, said: " + why);
    }

    public static void KeyRouteReachesTheBossAndTheWayBackOut()
    {
        var r = Run();
        Assert.Equal("rm_chalk_landing", r.Room, "starts at the entrance");
        Go(r, "cn_landing_hall");
        Assert.True(!r.Move("cn_hall_lower_door", out var why) && why == "locked", "the tally door is locked");
        Go(r, "cn_hall_gallery");
        Assert.True(r.TakeKey("key_rusted_tally") && !r.TakeKey("key_rusted_tally"), "key taken once");
        Go(r, "cn_hall_gallery", "cn_hall_lower_door");
        Assert.Equal("rm_lower_landing", r.Checkpoint, "checkpoint updated");
        Go(r, "cn_lower_vault");
        Assert.True(r.DefeatBoss() && !r.DefeatBoss(), "boss falls once");
        Go(r, "cn_vault_chute");
        Assert.True(r.CanLeave, "the chute drops back at the entrance");
        Assert.True(!r.Move("cn_vault_chute", out _), "the chute is one-way");
    }

    public static void LeverRouteSkipsTheKeyAndTheGallery()
    {
        var r = Run();
        Go(r, "cn_landing_hall");
        var p = (LeverPuzzle)r.PuzzleById("pzl_warren_levers");
        Assert.True(!r.Move("cn_hall_lower_lift", out var why) && why == "mechanism idle", "idle until solved");
        foreach (var s in p.Data.Sequence) p.Pull(s);
        Go(r, "cn_hall_lower_lift", "cn_lower_vault");
        Assert.True(r.Keys.Count == 0, "never held a key");
        Assert.True(r.DefeatBoss(), "boss reachable the lever way");
    }

    public static void SkippingEveryPuzzleStillFinishesTheDungeon()
    {
        var r = Run();
        foreach (var p in r.Puzzles) Assert.True(p.Skip(), p.Id + " skipped");
        Go(r, "cn_landing_hall", "cn_hall_gallery");
        r.TakeKey("key_rusted_tally");
        Go(r, "cn_hall_gallery", "cn_hall_lower_door", "cn_lower_vault");
        Assert.True(r.DefeatBoss(), "boss beaten with every puzzle skipped");
        Assert.True(r.Puzzles.All(p => p.ClaimReward() == null), "skipping forfeits only the optional rewards");
    }

    public static void TheSecretStaysHiddenUntilItsClueIsFoundInPlace()
    {
        var r = Run();
        Go(r, "cn_landing_hall", "cn_hall_gallery");
        r.TakeKey("key_rusted_tally");
        Go(r, "cn_hall_gallery", "cn_hall_lower_door");
        Assert.True(!r.ExitsHere().Any(c => c.Id == "cn_lower_cistern"), "hidden way not offered");
        Assert.True(!r.Move("cn_lower_cistern", out var why) && why == "hidden", "and not passable");
        Assert.True(r.Knowledge.HearClue("clue_cistern_draught"), "a rumour");
        Assert.True(!r.Move("cn_lower_cistern", out why), "a rumour alone reveals nothing");
        Assert.Equal(MapStatus.Heard, r.Knowledge.StatusOfRoom("rm_rune_cistern"), "but the room is pencilled in");
        Assert.True(!r.FindClue("clue_chalk_marks"), "a clue must be found in its own room");
        Assert.True(r.FindClue("clue_cistern_draught"), "found in place");
        Go(r, "cn_lower_cistern");
        Assert.Equal(MapStatus.Visited, r.Knowledge.StatusOfRoom("rm_rune_cistern"), "inked");
        Go(r, "cn_lower_cistern");
        Assert.Equal("rm_lower_landing", r.Room, "and back out again");
    }

    public static void DyingReturnsToTheCheckpointAndLosesNothing()
    {
        var r = Run();
        Go(r, "cn_landing_hall", "cn_hall_gallery");
        r.TakeKey("key_rusted_tally");
        Go(r, "cn_hall_gallery", "cn_hall_lower_door", "cn_lower_vault");
        Assert.Equal("rm_lower_landing", r.Die(), "back at the lower checkpoint");
        Assert.True(r.Keys.Contains("key_rusted_tally"), "key kept");
        Go(r, "cn_lower_vault");
        var early = Run();
        Go(early, "cn_landing_hall");
        Assert.Equal("rm_chalk_landing", early.Die(), "before the first stairs the entrance is the checkpoint");
    }

    public static void TheHallsResetButWhatYouLearnedStays()
    {
        var r = Run();
        Go(r, "cn_landing_hall", "cn_hall_gallery");
        r.TakeKey("key_rusted_tally");
        var lev = (LeverPuzzle)r.PuzzleById("pzl_warren_levers");
        foreach (var s in lev.Data.Sequence) lev.Pull(s);
        Go(r, "cn_hall_gallery", "cn_hall_lower_door", "cn_lower_vault");
        r.DefeatBoss();
        r.Reset();
        Assert.Equal("rm_chalk_landing", r.Room, "back at the entrance");
        Assert.Equal(0, r.Keys.Count, "keys gone");
        Assert.Equal(PuzzleStatus.Unsolved, lev.Status, "puzzles reset");
        Assert.True(!r.BossDefeated, "the boss stands again");
        Assert.Equal(MapStatus.Visited, r.Knowledge.StatusOfRoom("rm_beetle_vault"), "the map remembers");
    }

    public static void MovingThroughAnUnconnectedWayFails()
    {
        var r = Run();
        Assert.True(!r.Move("cn_lower_vault", out var why) && why == "not here", "not connected to this room");
        Assert.True(!r.Move("cn_nope", out why) && why == "no such way", "no such way");
    }
}
