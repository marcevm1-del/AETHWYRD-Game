using System.Linq;
using Ascend.Core;

// Sector loader prototype: which terrain tiles stay resident around the player.
[Tests]
static class SectorStreamerTests
{
    static WorldScale Scale => new WorldScale(Repo.Load<WorldScaleData>("Data/World/world_scale.json"));
    static SectorStreamer Make(SectorStreamTuning t = null) => new SectorStreamer(Scale, t);

    public static void FirstUpdateLoadsTheTileUnderThePlayer()
    {
        var s = Make();
        var step = s.Update(75, 58);
        Assert.True(Scale.TryTileOf(75, 58, out var here), "inside the map");
        Assert.True(step.Load.Contains(here) && step.Unload.Count == 0, "home tile loads, nothing unloads");
        Assert.True(step.Resident.Count >= 1 && step.Resident.Count <= 9, "within the budget");
    }

    public static void StandingStillChangesNothing()
    {
        var s = Make();
        s.Update(75, 58);
        var again = s.Update(75, 58);
        Assert.True(again.Load.Count == 0 && again.Unload.Count == 0, "stable");
    }

    public static void WalkingAcrossABorderLoadsAheadAndUnloadsBehind()
    {
        var s = Make(new SectorStreamTuning { LoadRadiusKm = 3, UnloadMarginKm = 1, MaxResident = 9 });
        s.Update(5, 5);
        var first = s.Resident.ToList();
        bool loaded = false, unloaded = false;
        for (double x = 5; x < 70; x += 0.5)
        {
            var st = s.Update(x, 5);
            loaded |= st.Load.Count > 0; unloaded |= st.Unload.Count > 0;
        }
        Assert.True(loaded && unloaded, "tiles come and go while walking");
        Assert.True(!first.All(t => s.Resident.Contains(t)), "the start tiles were dropped far away");
        Assert.True(Scale.TryTileOf(69.5, 5, out var here) && s.Resident.Contains(here), "current tile resident");
    }

    public static void HysteresisStopsFlickerAtABorder()
    {
        var s = Make(new SectorStreamTuning { LoadRadiusKm = 2, UnloadMarginKm = 2, MaxResident = 9 });
        double edge = Scale.TileKm();
        int changes = 0;
        s.Update(edge - 0.1, 5);
        for (int i = 0; i < 20; i++)
        {
            var st = s.Update(edge + (i % 2 == 0 ? 0.1 : -0.1), 5);
            changes += st.Load.Count + st.Unload.Count;
        }
        Assert.True(changes <= 2, "stepping back and forth over the border does not thrash: " + changes);
    }

    public static void BudgetCapKeepsNearestAndHomeTile()
    {
        var s = Make(new SectorStreamTuning { LoadRadiusKm = 50, UnloadMarginKm = 0, MaxResident = 4 });
        var st = s.Update(75, 50);
        Assert.Equal(4, st.Resident.Count, "capped");
        Assert.True(Scale.TryTileOf(75, 50, out var here) && st.Resident.Contains(here), "home tile always kept");
    }

    public static void OutsideTheMapChangesNothingAndClearResets()
    {
        var s = Make();
        s.Update(75, 58);
        int n = s.Resident.Count;
        var out1 = s.Update(-5, -5);
        Assert.True(out1.Load.Count == 0 && out1.Unload.Count == 0 && s.Resident.Count == n, "ignored");
        s.Clear();
        Assert.Equal(0, s.Resident.Count, "cleared");
    }

    public static void BuiltAndProposedTileSizesBothWork()
    {
        var a = Make(); var b = Make();
        Assert.True(a.Update(75, 58, built: true).Load.Count > 0, "built 10 km tiles");
        Assert.True(b.Update(75, 58).Load.Count > 0, "10.24 km tiles");
    }
}
