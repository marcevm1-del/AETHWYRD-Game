using System.Collections.Generic;
using System.Linq;
using Ascend.Core;

// Wave E puzzles: lever sequence, weight plates, rune match. Deterministic, optional, skippable, free hints.
[Tests]
static class PuzzleTests
{
    static PuzzleFile File() => Repo.Db.Puzzles;
    static Puzzle Make(string id) => Puzzle.Create(File().Puzzles.First(p => p.Id == id), File().Tuning);

    // ---- data hygiene (Canon: never a mandatory gate) ----
    public static void EveryPuzzleIsOptionalSolvableAndHinted()
    {
        Assert.True(File().Puzzles.Count >= 3, "three puzzle types shipped");
        Assert.Equal(3, File().Puzzles.Select(p => p.Type).Distinct().Count(), "one of each type");
        foreach (var p in File().Puzzles)
        {
            Assert.True(p.Optional, p.Id + " is optional");
            Assert.True(p.Hints.Count >= 2, p.Id + " has hints");
            Assert.True(Puzzle.Create(p, File().Tuning).IsSolvable(), p.Id + " is solvable");
            if (p.Reward != null)
            {
                Assert.True(Repo.Db.Items.ContainsKey(p.Reward.ItemId), p.Id + " reward is a real item");
                Assert.True(p.Reward.Count >= 1, p.Id + " reward count");
            }
        }
    }

    public static void UnknownTypeIsRejected()
    {
        Assert.Throws<System.ArgumentException>(() => Puzzle.Create(new PuzzleData { Id = "pzl_x", Type = "mirror" }), "unknown type");
    }

    // ---- shared behaviour ----
    public static void HintsAreFreeAndTheLastOneRepeats()
    {
        var p = Make("pzl_warren_levers");
        var seen = new List<string>();
        for (int i = 0; i < 5; i++) seen.Add(p.NextHint());
        Assert.Equal(p.Data.Hints[0], seen[0], "first hint first");
        Assert.Equal(p.Data.Hints[2], seen[2], "third hint third");
        Assert.Equal(p.Data.Hints[2], seen[4], "the last hint repeats");
        Assert.Equal(PuzzleStatus.Unsolved, p.Status, "reading hints costs nothing");
        Assert.True(p.NextHint() != null, "hints never run out");
    }

    public static void SkipIsFreeAndOnlyWhileUnsolved()
    {
        var p = Make("pzl_warren_plates");
        Assert.True(p.Skip(), "skip");
        Assert.Equal(PuzzleStatus.Skipped, p.Status, "skipped");
        Assert.True(!p.Skip(), "skipping twice does nothing");
        Assert.True(p.ClaimReward() == null, "a skipped puzzle pays nothing");
        var l = (LeverPuzzle)Make("pzl_warren_levers");
        foreach (var s in l.Data.Sequence) l.Pull(s);
        Assert.True(!l.Skip(), "a solved puzzle cannot be skipped");
        Assert.Equal(PuzzleStatus.Solved, l.Status, "still solved");
    }

    public static void SkippedPuzzleCanStillBeSolvedLater()
    {
        var l = (LeverPuzzle)Make("pzl_warren_levers");
        l.Skip();
        foreach (var s in l.Data.Sequence) l.Pull(s);
        Assert.Equal(PuzzleStatus.Solved, l.Status, "changing your mind works");
    }

    public static void RewardIsPaidOnceAndResetRestartsEverything()
    {
        var p = (PlatePuzzle)Make("pzl_warren_plates");
        Assert.True(p.ClaimReward() == null, "no reward before solving");
        SolveByAssist(p);
        Assert.Equal(PuzzleStatus.Solved, p.Status, "solved");
        var r = p.ClaimReward();
        Assert.True(r != null && r.ItemId == "itm_mat_rune_plate" && r.Count == 2, "reward");
        Assert.True(p.ClaimReward() == null, "only once");
        p.NextHint(); p.Reset();
        Assert.Equal(PuzzleStatus.Unsolved, p.Status, "reset");
        Assert.Equal(0, p.HintsShown, "hints reset");
        Assert.Equal(0, p.Fails, "fails reset");
        Assert.Equal(0, p.LoadOn("plate_east") + p.LoadOn("plate_west"), "plates empty again");
        SolveByAssist(p);
        Assert.True(p.ClaimReward() != null, "the reset halls pay again");
    }

    // ---- lever sequence ----
    public static void LeversInOrderSolve()
    {
        var p = (LeverPuzzle)Make("pzl_warren_levers");
        Assert.Equal(LeverResult.Correct, p.Pull("lev_slate"), "1");
        Assert.Equal(LeverResult.Correct, p.Pull("lev_ash"), "2");
        Assert.Equal(LeverResult.Correct, p.Pull("lev_chalk"), "3");
        Assert.Equal(LeverResult.Solved, p.Pull("lev_tin"), "4");
        Assert.Equal(PuzzleStatus.Solved, p.Status, "solved");
        Assert.Equal(LeverResult.Ignored, p.Pull("lev_ash"), "a solved lock ignores input");
    }

    public static void WrongLeverResetsTheTallyAndCountsAFail()
    {
        var p = (LeverPuzzle)Make("pzl_warren_levers");
        p.Pull("lev_slate"); p.Pull("lev_ash");
        Assert.Equal(LeverResult.Wrong, p.Pull("lev_tin"), "wrong pull");
        Assert.Equal(0, p.Progress, "tally reset");
        Assert.Equal(1, p.Fails, "fail counted");
        Assert.Equal(LeverResult.Ignored, p.Pull("lev_nope"), "unknown lever");
        Assert.Equal(1, p.Fails, "unknown lever is not a fail");
        Assert.Equal(PuzzleStatus.Unsolved, p.Status, "nothing lost");
    }

    public static void ARepeatedFirstLeverCountsAsAFreshStart()
    {
        var d = new PuzzleData { Id = "pzl_rep", Type = PuzzleTypes.LeverSequence,
            Levers = new List<string> { "a", "b", "c" }, Sequence = new List<string> { "a", "b", "a", "c" } };
        var p = (LeverPuzzle)Puzzle.Create(d);
        p.Pull("a"); p.Pull("b"); p.Pull("a");
        Assert.Equal(LeverResult.Wrong, p.Pull("a"), "a again is wrong at step 4");
        Assert.Equal(1, p.Progress, "but it restarts the tally at step one");
        Assert.Equal(LeverResult.Correct, p.Pull("b"), "carry on from there");
    }

    public static void LeverAssistOpensAfterFailsOrHintsAndNamesTheNextLever()
    {
        var p = (LeverPuzzle)Make("pzl_warren_levers");
        Assert.True(!p.AssistAvailable && p.Assist() == null, "not at the start");
        p.Pull("lev_tin"); p.Pull("lev_tin");
        Assert.True(p.Assist() == null, "two fails are not enough");
        p.Pull("lev_tin");
        Assert.True(p.AssistAvailable, "three fails open the assist");
        Assert.Equal("lev_slate", p.Assist().Target, "first lever");
        p.Pull("lev_slate");
        Assert.Equal("lev_ash", p.Assist().Target, "next lever");

        var q = (LeverPuzzle)Make("pzl_warren_levers");
        for (int i = 0; i < q.Data.Hints.Count; i++) q.NextHint();
        Assert.True(q.AssistAvailable, "reading every hint also opens it");
        var steps = 0;
        while (q.Status != PuzzleStatus.Solved && steps++ < 10) q.Pull(q.Assist().Target);
        Assert.Equal(PuzzleStatus.Solved, q.Status, "following the assist solves it");
        Assert.True(q.Assist() == null, "no assist once solved");
    }

    // ---- weight plates ----
    public static void PlatesNeedExactWeights()
    {
        var p = (PlatePuzzle)Make("pzl_warren_plates");
        Assert.Equal(PlateResult.Placed, p.Place("stone_slab", "plate_east"), "3 on east");
        Assert.Equal(PlateResult.Placed, p.Place("stone_brick", "plate_west"), "2 on west");
        Assert.Equal(PlateResult.Placed, p.Place("stone_block", "plate_west"), "4 on west");
        Assert.Equal(PlateResult.Solved, p.Place("stone_pebble", "plate_west"), "5 on west: both exact");
        Assert.Equal(PuzzleStatus.Solved, p.Status, "solved");
        Assert.Equal(PlateResult.Invalid, p.Place("stone_slab", "plate_west"), "a solved floor is locked");
    }

    public static void OverloadedPlatePopsTheStoneBackOff()
    {
        var p = (PlatePuzzle)Make("pzl_warren_plates");
        p.Place("stone_slab", "plate_east");
        Assert.Equal(PlateResult.Overloaded, p.Place("stone_pebble", "plate_east"), "3 + 1 > 3");
        Assert.Equal(null, p.PlateOf("stone_pebble"), "the stone is off the plate");
        Assert.Equal(3, p.LoadOn("plate_east"), "the plate keeps its load");
        Assert.Equal(1, p.Fails, "fail counted");
        Assert.Equal(PlateResult.Invalid, p.Place("stone_ghost", "plate_east"), "unknown object");
        Assert.Equal(PlateResult.Invalid, p.Place("stone_slab", "plate_nowhere"), "unknown plate");
        Assert.True(p.Remove("stone_slab") && !p.Remove("stone_slab"), "remove once");
    }

    public static void MovingAStoneBetweenPlatesRemovesItFromTheFirst()
    {
        var p = (PlatePuzzle)Make("pzl_warren_plates");
        p.Place("stone_brick", "plate_east");
        p.Place("stone_brick", "plate_west");
        Assert.Equal(0, p.LoadOn("plate_east"), "east empty");
        Assert.Equal(2, p.LoadOn("plate_west"), "west holds it");
    }

    public static void PlateAssistConvergesEvenFromAWrongStart()
    {
        var p = (PlatePuzzle)Make("pzl_warren_plates");
        p.Place("stone_brick", "plate_east");   // wrong for the assist's chosen solution or not: it must cope either way
        p.Place("stone_pebble", "plate_west");
        p.NextHint(); p.NextHint(); p.NextHint();
        SolveByAssist(p);
        Assert.Equal(PuzzleStatus.Solved, p.Status, "assist solves");
        Assert.Equal(0, p.Fails, "the assist never overloads a plate");
    }

    public static void UnsolvablePlatesAreDetected()
    {
        var d = new PuzzleData { Id = "pzl_bad", Type = PuzzleTypes.PressurePlate,
            Plates = new List<PlateData> { new PlateData { Id = "a", Weight = 5 } },
            Objects = new List<WeightObjectData> { new WeightObjectData { Id = "x", Weight = 1 }, new WeightObjectData { Id = "y", Weight = 2 } } };
        Assert.True(!Puzzle.Create(d).IsSolvable(), "1 + 2 can never make 5");
        d.Objects.Add(new WeightObjectData { Id = "z", Weight = 2 });
        Assert.True(Puzzle.Create(d).IsSolvable(), "1 + 2 + 2 makes 5");
    }

    // ---- rune match ----
    public static void RuneTurnsLinkedSconcesAndSolvesWhenAllMatch()
    {
        var p = (RunePuzzle)Make("pzl_warren_runes");
        Assert.Equal("ember", p.GlyphAt("sc_one"), "start");
        Assert.True(p.Turn("sc_one"), "turn");
        Assert.Equal("tide", p.GlyphAt("sc_one"), "turned");
        Assert.Equal("tide", p.GlyphAt("sc_two"), "linked sconce turned too");
        Assert.Equal("tide", p.GlyphAt("sc_three"), "not linked: unchanged");
        Assert.True(!p.Turn("sc_none"), "unknown sconce");
        p.Reset();
        for (int i = 0; i < 3; i++) p.Turn("sc_two");
        for (int i = 0; i < 2; i++) p.Turn("sc_four");
        Assert.Equal(PuzzleStatus.Solved, p.Status, "the hand-worked solution opens the lock");
        Assert.True(!p.Turn("sc_one"), "an open lock ignores turns");
    }

    public static void RuneAssistFindsTheShortestWay()
    {
        var p = (RunePuzzle)Make("pzl_warren_runes");
        for (int i = 0; i < p.Data.Hints.Count; i++) p.NextHint();
        int moves = 0;
        while (p.Status != PuzzleStatus.Solved && moves < 20) { p.Turn(p.Assist().Target); moves++; }
        Assert.Equal(PuzzleStatus.Solved, p.Status, "assist solves");
        Assert.Equal(5, moves, "3 turns of sc_two and 2 of sc_four is the shortest solution");
    }

    public static void UnreachableRunePatternIsDetected()
    {
        var d = new PuzzleData { Id = "pzl_bad", Type = PuzzleTypes.RuneMatch, Glyphs = new List<string> { "a", "b", "c" },
            Sconces = new List<SconceData> {
                new SconceData { Id = "s1", Start = "a", Target = "a", Also = new List<string> { "s2" } },
                new SconceData { Id = "s2", Start = "a", Target = "b", Also = new List<string> { "s1" } } } };
        Assert.True(!Puzzle.Create(d).IsSolvable(), "linked pair always differs by 0: a,b is unreachable");
    }

    // ---- determinism ----
    public static void PuzzlesAreDeterministic()
    {
        var a = (RunePuzzle)Make("pzl_warren_runes"); var b = (RunePuzzle)Make("pzl_warren_runes");
        foreach (var id in new[] { "sc_one", "sc_three", "sc_four", "sc_two" }) { a.Turn(id); b.Turn(id); }
        foreach (var s in a.Data.Sconces) Assert.Equal(a.GlyphAt(s.Id), b.GlyphAt(s.Id), "same moves, same state");
        for (int i = 0; i < 3; i++) { a.NextHint(); b.NextHint(); }
        Assert.Equal(a.Assist().Target, b.Assist().Target, "same assist");
    }

    static void SolveByAssist(Puzzle p)
    {
        for (int i = 0; i < p.Data.Hints.Count; i++) p.NextHint();
        for (int guard = 0; p.Status != PuzzleStatus.Solved && guard < 30; guard++)
        {
            var a = p.Assist();
            Assert.True(a != null, "the assist has a move");
            if (p is PlatePuzzle pl) { if (a.Kind == "remove") pl.Remove(a.Target); else pl.Place(a.Target, a.PlateId); }
            else if (p is LeverPuzzle lv) lv.Pull(a.Target);
            else ((RunePuzzle)p).Turn(a.Target);
        }
    }
}
