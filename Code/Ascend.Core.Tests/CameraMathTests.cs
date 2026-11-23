using Ascend.Core;

// Over-the-shoulder camera maths and the mouse lock-on flick detector (combat.md section 2).
[Tests]
static class CameraMathTests
{
    static CameraTuning T => Repo.Db.Tuning.Camera;
    static LockOnTuning L => Repo.Db.Tuning.LockOn;
    const double Dt = 1.0 / 60;

    public static void ZeroLagSnapsAndLagApproachesWithoutOvershoot()
    {
        Assert.Near(5.0, CameraMath.Damp(0, 5, 0, Dt), 1e-9, "zero lag snaps");
        double v = 0;
        for (int i = 0; i < 600; i++) { double n = CameraMath.Damp(v, 1, 0.2, Dt); Assert.True(n >= v && n <= 1.0, "monotonic, no overshoot"); v = n; }
        Assert.Near(1.0, v, 1e-6, "converges");
    }

    public static void DampingIsFrameRateIndependent()
    {
        double a = 0, b = 0;
        for (int i = 0; i < 60; i++) a = CameraMath.Damp(a, 1, 0.25, 1.0 / 60);
        for (int i = 0; i < 30; i++) b = CameraMath.Damp(b, 1, 0.25, 1.0 / 30);
        Assert.Near(a, b, 1e-9, "one second at 60 fps equals one second at 30 fps");
    }

    public static void AngleDampingTakesTheShortWayRound()
    {
        double r = CameraMath.DampAngle(350, 10, 0.1, Dt);
        Assert.True(r > 350 || r < 10, "moves up through 360, not back through 180: " + r);
        Assert.Near(10, CameraMath.DampAngle(350, 10, 0, Dt) - 360, 1e-9, "snap lands on target");
    }

    public static void CollisionPullsInFastAndEasesOutSlowly()
    {
        double inStep = CameraMath.DampDistance(4.5, 1.0, T.CollisionInLagSec, T.CollisionOutLagSec, Dt);
        double outStep = CameraMath.DampDistance(1.0, 4.5, T.CollisionInLagSec, T.CollisionOutLagSec, Dt);
        Assert.True(4.5 - inStep > outStep - 1.0, "the pull-in step is larger than the ease-out step");
        Assert.True(T.CollisionInLagSec < T.CollisionOutLagSec, "data: in-lag shorter than out-lag");
    }

    public static void YawOffsetIsClamped()
    {
        Assert.Near(35, CameraMath.ClampYawOffset(90, 35), 1e-9, "upper");
        Assert.Near(-35, CameraMath.ClampYawOffset(-90, 35), 1e-9, "lower");
        Assert.Near(10, CameraMath.ClampYawOffset(10, 35), 1e-9, "inside");
    }

    public static void GroupPullBackNeedsEnoughEngaged()
    {
        Assert.Near(T.Distance, CameraMath.GroupDistance(T.GroupEngagedCount - 1, T.GroupEngagedCount, T.Distance, T.GroupPullBackDistance), 1e-9, "below the count");
        Assert.Near(T.GroupPullBackDistance, CameraMath.GroupDistance(T.GroupEngagedCount, T.GroupEngagedCount, T.Distance, T.GroupPullBackDistance), 1e-9, "at the count");
        Assert.Near(T.Distance, CameraMath.GroupDistance(9, 3, T.Distance, 2), 1e-9, "never closer than the base distance");
    }

    public static void SlowAimingNeverSwitchesButAFlickDoes()
    {
        var f = new FlickDetector(L.FlickVelocityPxPerSec, L.FlickDeadzonePx, L.SwitchCooldownSec);
        for (int i = 0; i < 120; i++) Assert.Equal(0, f.Feed(L.FlickVelocityPxPerSec * Dt * 0.5, Dt), "half-speed aiming");
        Assert.Equal(0, f.Feed(L.FlickDeadzonePx * 0.5, 0.0001), "inside the deadzone even if fast");
        Assert.Equal(1, f.Feed(L.FlickVelocityPxPerSec * Dt * 1.2, Dt), "fast right flick");
    }

    public static void CooldownBlocksRepeatsThenReleases()
    {
        var f = new FlickDetector(L.FlickVelocityPxPerSec, L.FlickDeadzonePx, L.SwitchCooldownSec);
        double flick = -L.FlickVelocityPxPerSec * Dt * 2;
        Assert.Equal(-1, f.Feed(flick, Dt), "first flick left");
        Assert.Equal(0, f.Feed(flick, Dt), "blocked while cooling");
        for (double t = 0; t < L.SwitchCooldownSec + 0.1; t += Dt) f.Feed(0, Dt);
        Assert.Equal(-1, f.Feed(flick, Dt), "works again after the cooldown");
    }

    public static void CameraDataIsSane()
    {
        Assert.True(T.ShoulderOffset > 0 && T.ShoulderOffset < 1.0, "shoulder offset a sensible fraction of a metre");
        Assert.True(T.GroupEngagedCount >= 2, "group count");
        Assert.True(T.GroupPullBackDistance > T.Distance, "group distance pulls back");
        Assert.True(L.MouseYawRangeDeg > 0 && L.MouseYawRangeDeg < 90, "lock-on yaw range");
    }
}
