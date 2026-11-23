using Ascend.Core;

// Input buffer for dodge/jump/heavy/block, the parry-window press edge and block stamina (combat.md section 1 and 5).
[Tests]
static class InputBufferTests
{
    static CombatTuning C => Repo.Db.Tuning;
    static AttackChain Slash() => new AttackChain(Repo.Db.Classes["cls_swordsman"].Skill("skl_slash_chain"), C);
    const double Dt = 1.0 / 60;

    public static void EveryActionIsBufferedAndFiresWhenLegal()
    {
        foreach (BufferedAction a in System.Enum.GetValues(typeof(BufferedAction)))
        {
            var b = new InputBuffer(C);
            b.Press(a);
            Assert.True(b.IsBuffered(a), a + " is buffered");
            Assert.True(b.Poll(x => false) == null && b.IsBuffered(a), a + " stays buffered while illegal");
            Assert.True(b.Poll(x => true) == a, a + " fires when legal");
            Assert.True(!b.IsBuffered(a) && b.Poll(x => true) == null, a + " fires once");
        }
    }

    public static void TheWindowExpires()
    {
        var b = new InputBuffer(C);
        b.Press(BufferedAction.Jump);
        b.Tick(C.InputBufferSec - 0.01);
        Assert.True(b.IsBuffered(BufferedAction.Jump), "still inside the window");
        b.Tick(0.02);
        Assert.True(!b.IsBuffered(BufferedAction.Jump) && b.Poll(x => true) == null, "expired press is dropped");
        var off = new InputBuffer(0);
        off.Press(BufferedAction.Dodge);
        Assert.True(!off.IsBuffered(BufferedAction.Dodge), "a zero window buffers nothing");
    }

    public static void PriorityIsDodgeBlockJumpHeavy()
    {
        var b = new InputBuffer(C);
        b.Press(BufferedAction.Heavy); b.Press(BufferedAction.Jump); b.Press(BufferedAction.Block); b.Press(BufferedAction.Dodge);
        var order = new System.Collections.Generic.List<BufferedAction>();
        for (int i = 0; i < 4; i++) order.Add(b.Poll(x => true).Value);
        Assert.True(order[0] == BufferedAction.Dodge && order[1] == BufferedAction.Block && order[2] == BufferedAction.Jump && order[3] == BufferedAction.Heavy,
            "defence first, then jump, then heavy");
        b.Press(BufferedAction.Dodge); b.Press(BufferedAction.Heavy);
        Assert.True(b.Poll(x => x == BufferedAction.Heavy) == BufferedAction.Heavy && b.IsBuffered(BufferedAction.Dodge), "a legal lower priority fires, dodge keeps waiting");
    }

    public static void DodgePressedInStartupFiresAtTheEndOfStartup()
    {
        var a = Slash();
        var b = new InputBuffer(C);
        a.Press();
        double startup = C.AttackTiming.Light.StartupSec;
        for (double t = 0; t < startup - C.InputBufferSec * 0.5; t += Dt) a.Tick(Dt);
        Assert.True(!a.CanDodgeCancel, "still in startup");
        b.Press(BufferedAction.Dodge);
        Assert.True(b.Poll(x => x == BufferedAction.Dodge && a.CanDodgeCancel) == null, "refused during startup, as the cancel rule says");
        BufferedAction? fired = null;
        for (int i = 0; i < 60 && fired == null; i++)
        {
            a.Tick(Dt); b.Tick(Dt);
            fired = b.Poll(x => x == BufferedAction.Dodge && a.CanDodgeCancel);
        }
        Assert.True(fired == BufferedAction.Dodge, "fires at the first legal moment");
        Assert.Equal(AttackPhase.Active, a.Phase, "that moment is active frame 1");
        Assert.True(a.Cancel() && a.Phase == AttackPhase.Idle, "and the dodge cancels the attack");
    }

    public static void JumpWaitsForTheAttackToEnd()
    {
        var a = Slash();
        var b = new InputBuffer(1.0);
        a.Press();
        b.Press(BufferedAction.Jump);
        int frames = 0;
        BufferedAction? fired = null;
        while (fired == null && frames++ < 300)
        {
            a.Tick(Dt); b.Tick(Dt);
            fired = b.Poll(x => !a.IsBusy);
        }
        Assert.True(fired == BufferedAction.Jump && !a.IsBusy, "jump fires once the attack is over");
    }

    // --- Auto-parry (audit item c): proof ---

    /// <summary>The old PlayerDefense.SetBlock rule, replicated: stamp whenever held and not already blocking.</summary>
    static int LegacyStamps(bool[] heldPerFrame, bool[] attackingPerFrame)
    {
        bool blocking = false; int stamps = 0;
        for (int i = 0; i < heldPerFrame.Length; i++)
        {
            bool held = heldPerFrame[i] && !attackingPerFrame[i]; // the driver passed `held && !attacking`
            if (held && !blocking) stamps++;
            blocking = held;
        }
        return stamps;
    }

    public static void HoldingBlockThroughAnAttackDoesNotReopenTheParryWindow()
    {
        int n = 60;
        var held = new bool[n]; var atk = new bool[n]; var times = new double[n];
        for (int i = 0; i < n; i++) { held[i] = true; atk[i] = i >= 30 && i < 40; times[i] = i * Dt; }

        Assert.Equal(2, LegacyStamps(held, atk), "old rule: stamped on the press AND again when the attack ended (the auto-parry)");

        var g = new GuardState();
        int edges = 0; double? prev = null;
        for (int i = 0; i < n; i++)
        {
            g.Update(held[i], atk[i], times[i]);
            if (g.PressedAt != prev) { edges++; prev = g.PressedAt; }
        }
        Assert.Equal(1, edges, "new rule: only the real press opens the window");
        Assert.True(g.Blocking, "the held block comes back up after the attack");
        Assert.Near(0.0, g.PressedAt.Value, 1e-9, "the window still dates from the real press");
    }

    public static void ReleasingAndPressingAgainOpensANewWindow()
    {
        var g = new GuardState();
        g.Update(true, false, 1.0);
        g.Update(false, false, 1.1);
        g.Update(true, false, 2.0);
        Assert.Near(2.0, g.PressedAt.Value, 1e-9, "a fresh press stamps again");
        g.ConsumeParry();
        g.Update(true, false, 2.1);
        Assert.True(g.PressedAt == null, "one parry per press: holding does not re-arm it");
        g.StampBufferedPress(3.0);
        Assert.Near(3.0, g.PressedAt.Value, 1e-9, "a buffered press fired at its first legal moment opens the window then");
    }

    public static void BlockPressedWhileSwingingOpensNoParryWindow()
    {
        var g = new GuardState();
        g.Update(true, true, 5.0); // press edge during an attack or dodge
        Assert.True(g.PressedAt == null, "no window opens while suppressed");
        var r = DefenseJudge.Resolve(Telegraph.Blue, 5.05, null, false, g.PressedAt, g.Blocking, C.Dodge, C.Parry);
        Assert.True(r != DefenseResult.Parried, "a blue hit inside the old window is not parried mid-swing");
        g.Update(true, false, 5.2); // attack over, still held: a plain block, no parry
        Assert.True(g.Blocking && g.PressedAt == null, "block resumes without a parry window");
    }

    public static void DodgeEndingDoesNotReopenTheParryWindow()
    {
        var g = new GuardState();
        g.Update(true, false, 1.0);
        g.ConsumeParry();
        g.Update(true, true, 1.1);
        g.Update(true, false, 1.5);
        Assert.True(g.Blocking && g.PressedAt == null, "block resumes without a new parry window");
    }

    // --- Block stamina (combat.md section 5) ---

    public static void BlockDrainsStaminaPerHitAndFailsAtZero()
    {
        var p = C.Parry;
        Assert.True(p.BlockStaminaPerHit > 0, "a blocked hit costs stamina");
        double s = 100; int blocks = 0;
        while (s > 0 && blocks < 100) { s = DefenseJudge.StaminaAfterBlockedHit(s, p); blocks++; }
        Assert.Equal(0.0, s, "stamina floors at 0");
        Assert.True(blocks > 2, "a full bar withstands several hits");

        var held = DefenseJudge.Resolve(Telegraph.Blue, 5, null, false, 0.0, true, C.Dodge, p, guardHolds: true);
        var broken = DefenseJudge.Resolve(Telegraph.Blue, 5, null, false, 0.0, true, C.Dodge, p, guardHolds: false);
        Assert.Equal(DefenseResult.Blocked, held, "block holds with stamina");
        Assert.Equal(DefenseResult.Hit, broken, "block fails with none: the hit lands in full");
        Assert.Equal(DefenseResult.Parried, DefenseJudge.Resolve(Telegraph.Blue, 5, null, false, 4.95, true, C.Dodge, p, guardHolds: false), "a parry needs no stamina");
        Assert.Equal(DefenseResult.Grabbed, DefenseJudge.Resolve(Telegraph.Gold, 5, null, false, null, true, C.Dodge, p, guardHolds: false), "gold still grabs");
    }
}
