using System.Collections.Generic;
using System.Linq;
using Ascend.Core;

// Dungeon loader: spawn planner and run snapshots.
[Tests]
static class DungeonPlanTests
{
    static DungeonData Warren() => Repo.Db.Dungeons["dng_salvage_warren"];

    public static void PlanIsDeterministic()
    {
        var a = DungeonPlanner.Plan(Warren(), 7UL, 0);
        var b = DungeonPlanner.Plan(Warren(), 7UL, 0);
        Assert.Equal(string.Join(",", a.Select(x => x.RoomId + x.SpeciesId + x.Slot)), string.Join(",", b.Select(x => x.RoomId + x.SpeciesId + x.Slot)), "same inputs, same halls");
    }

    public static void PlanRespectsMinMaxAndBoss()
    {
        var d = Warren();
        for (int reset = 0; reset < 30; reset++)
        {
            var plan = DungeonPlanner.Plan(d, 99UL, reset);
            foreach (var room in d.Rooms)
                foreach (var sp in room.Spawns)
                {
                    int n = plan.Count(p => p.RoomId == room.Id && p.SpeciesId == sp.SpeciesId && !p.IsBoss);
                    Assert.True(n >= sp.Min && n <= sp.Max, $"{room.Id}/{sp.SpeciesId} count {n} within {sp.Min}-{sp.Max}");
                }
            Assert.Equal(1, plan.Count(p => p.IsBoss), "exactly one boss");
            Assert.True(plan.All(p => d.RoomById(p.RoomId) != null), "spawns only in real rooms");
        }
    }

    public static void ResetCountChangesTheHalls()
    {
        var d = Warren();
        var sigs = new HashSet<string>();
        for (int reset = 0; reset < 20; reset++) sigs.Add(string.Join(",", DungeonPlanner.Plan(d, 1UL, reset).Select(x => x.RoomId + x.SpeciesId)));
        Assert.True(sigs.Count > 1, "a new week can differ");
    }

    public static void SnapshotRoundTripsAMidDungeonRun()
    {
        var d = Warren();
        var run = new DungeonRun(d, Repo.Db.Puzzles);
        Assert.True(run.Move("cn_landing_hall", out _), "to the hall");
        Assert.True(run.Move("cn_hall_gallery", out _), "to the gallery");
        Assert.True(run.TakeKey("key_rusted_tally"), "key");
        Assert.True(run.PuzzleById("pzl_warren_plates").Skip(), "skip is free");
        var snap = DungeonRunSnapshots.Capture(run, 3);

        var json = System.Text.Json.JsonSerializer.Serialize(snap);
        var back = System.Text.Json.JsonSerializer.Deserialize<DungeonRunSnapshot>(json);
        var run2 = new DungeonRun(d, Repo.Db.Puzzles);
        Assert.True(DungeonRunSnapshots.Restore(run2, back), "restored");
        Assert.Equal("rm_weighing_gallery", run2.Room, "same room");
        Assert.True(run2.Keys.Contains("key_rusted_tally"), "key kept");
        Assert.True(run2.PuzzleById("pzl_warren_plates").Status == PuzzleStatus.Skipped, "skip kept");
        Assert.Equal(3, back.ResetCount, "reset counter kept");
    }

    public static void OldSaveAndForeignSnapshotsRestoreNothing()
    {
        var run = new DungeonRun(Warren(), Repo.Db.Puzzles);
        Assert.True(!DungeonRunSnapshots.Restore(run, null), "no snapshot is fine");
        Assert.True(!DungeonRunSnapshots.Restore(run, new DungeonRunSnapshot { DungeonId = "dng_other" }), "other dungeon ignored");
        Assert.Equal("rm_chalk_landing", run.Room, "still at the entry");
        var junk = new DungeonRunSnapshot { DungeonId = "dng_salvage_warren", Room = "rm_gone", Checkpoint = "rm_gone", Keys = { "key_gone" } };
        Assert.True(DungeonRunSnapshots.Restore(run, junk), "stale ids tolerated");
        Assert.Equal("rm_chalk_landing", run.Room, "unknown room falls back to the entry");
        Assert.Equal(0, run.Keys.Count, "unknown keys dropped");
    }

    public static void SolvedPuzzleKeepsItsWayOpen()
    {
        var d = Warren();
        var run = new DungeonRun(d, Repo.Db.Puzzles);
        var lev = (LeverPuzzle)run.PuzzleById("pzl_warren_levers");
        foreach (var l in new[] { "lev_slate", "lev_ash", "lev_chalk", "lev_tin" }) lev.Pull(l);
        Assert.True(lev.Status == PuzzleStatus.Solved, "solved");
        var snap = DungeonRunSnapshots.Capture(run, 0);
        var run2 = new DungeonRun(d, Repo.Db.Puzzles);
        DungeonRunSnapshots.Restore(run2, snap);
        var lift = d.Connections.First(c => c.Id == "cn_hall_lower_lift");
        Assert.True(run2.IsOpen(lift, out _), "the lift stays open after restore");
    }
}
