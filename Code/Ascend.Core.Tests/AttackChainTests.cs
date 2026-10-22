using Ascend.Core;

// Ring 0 basic attack string (combat.md §4.1) on the Swordsman's Slash Chain.
[Tests]
static class AttackChainTests
{
    static CombatTuning C => Repo.Db.Tuning;
    static AttackChain Slash() => new AttackChain(Repo.Db.Classes["cls_swordsman"].Skill("skl_slash_chain"), C);

    /// <summary>Ticks in 1/60 s frames for <paramref name="sec"/>; returns how many hits landed.</summary>
    static int Run(AttackChain a, double sec, System.Action<SkillHit> onHit = null)
    {
        int n = 0;
        for (double t = 0; t < sec - 1e-9; t += 1.0 / 60)
        {
            var h = a.Tick(1.0 / 60);
            if (h != null) { n++; onHit?.Invoke(h); }
        }
        return n;
    }

    public static void SinglePressLandsOneHitAfterStartup()
    {
        var a = Slash();
        a.Press();
        Assert.Equal(AttackPhase.Startup, a.Phase, "press starts the first hit");
        Assert.Equal(0, Run(a, C.AttackTiming.Light.StartupSec - 0.02), "nothing lands during startup");
        Assert.Equal(1, Run(a, 0.04), "hit lands on the first active frame");
        Run(a, 1.0);
        Assert.Equal(AttackPhase.Idle, a.Phase, "returns to idle after recovery");
    }

    public static void MashingPlaysTheFullStringWithItsPowers()
    {
        var a = Slash();
        var powers = new System.Collections.Generic.List<double>();
        a.Press();
        for (int f = 0; f < 240; f++)
        {
            if (f % 6 == 0) a.Press(); // mash ~10 presses/s
            var h = a.Tick(1.0 / 60);
            if (h != null) powers.Add(h.Power);
            if (powers.Count == 4) break;
        }
        Assert.Equal(4, powers.Count, "four hits");
        Assert.Near(0.8, powers[0], 1e-9, "hit 1"); Assert.Near(0.8, powers[1], 1e-9, "hit 2");
        Assert.Near(1.0, powers[2], 1e-9, "hit 3"); Assert.Near(1.4, powers[3], 1e-9, "medium finisher");
        Assert.Equal(HitWeight.Medium, AttackChain.WeightOf(a.Current), "finisher is medium weight");
    }

    public static void BufferedPressStartsNextHitAtRecovery()
    {
        var a = Slash();
        var light = C.AttackTiming.Light;
        a.Press();
        Run(a, light.StartupSec + 0.01);
        a.Press(); // buffered during active
        Run(a, light.ActiveSec);
        Assert.Equal(1, a.HitIndex, "second hit started when recovery began");
        Assert.Equal(AttackPhase.Startup, a.Phase, "second hit is in startup");
    }

    public static void LatePressOutsideBufferIsDropped()
    {
        var a = Slash();
        a.Press();
        Run(a, 0.02);
        a.Press(); // during startup, expires before recovery? startup+active = 0.18 < buffer 0.2, so it survives
        Run(a, C.AttackTiming.Light.StartupSec + C.AttackTiming.Light.ActiveSec);
        Assert.Equal(1, a.HitIndex, "an early press within the buffer still chains");

        var b = Slash();
        b.Press();
        Run(b, 1.0);
        Assert.Equal(AttackPhase.Idle, b.Phase, "idle");
        Assert.Equal(0, Run(b, 0.5), "no phantom hits from an expired buffer");
    }

    public static void ChainContinuesWithinResetWindowElseRestarts()
    {
        var t = C.AttackTiming;
        var a = Slash();
        a.Press(); Run(a, t.Light.StartupSec + t.Light.ActiveSec + t.Light.RecoverySec + 0.02);
        a.Press();
        Assert.Equal(1, a.HitIndex, "pressing again soon continues the string");

        var b = Slash();
        b.Press(); Run(b, t.Light.StartupSec + t.Light.ActiveSec + t.Light.RecoverySec + t.ChainResetSec + 0.05);
        b.Press();
        Assert.Equal(0, b.HitIndex, "waiting past chainResetSec restarts at hit 1");
    }

    public static void DodgeCancelsFromActiveButNotStartup()
    {
        var a = Slash();
        a.Press();
        Assert.True(!a.Cancel(), "startup can't be cancelled");
        Run(a, C.AttackTiming.Light.StartupSec + 0.01);
        Assert.True(a.Cancel(), "active frame 1 can be dodge-cancelled");
        Assert.Equal(AttackPhase.Idle, a.Phase, "idle after cancel");
        a.Press();
        Assert.Equal(0, a.HitIndex, "a cancel resets the string");
    }

    public static void LongFrameDoesNotSkipTheHit()
    {
        var a = Slash();
        a.Press();
        var h = a.Tick(0.5); // a hitch longer than the whole hit
        Assert.True(h != null, "the hit still lands");
        Assert.Equal(AttackPhase.Idle, a.Phase, "and the hit completes");
    }
}
