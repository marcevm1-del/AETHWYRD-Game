using Ascend.Core;

// Perfect dodge, parry, block and charged heavies (combat.md §4.1, §5) on the tuned windows.
[Tests]
static class DefenseTests
{
    static CombatTuning C => Repo.Db.Tuning;
    static DefenseResult R(Telegraph t, double hit, double? dodge, bool iframes, double? block, bool blocking) =>
        DefenseJudge.Resolve(t, hit, dodge, iframes, block, blocking, C.Dodge, C.Parry);

    public static void PerfectDodgeOnlyInsideTheWindow()
    {
        double w = C.Dodge.PerfectDodgeWindowSec;
        Assert.Equal(DefenseResult.PerfectDodge, R(Telegraph.Red, 10, 10 - w + 0.01, true, null, false), "dodge just before the hit is perfect");
        Assert.Equal(DefenseResult.Dodged, R(Telegraph.Red, 10, 10 - w - 0.05, true, null, false), "early dodge still avoids the hit");
        Assert.Equal(DefenseResult.Hit, R(Telegraph.Red, 10, 9.0, false, null, false), "dodge whose i-frames ended does not help");
    }

    public static void ParryNeedsTheWindowAndAParryableAttack()
    {
        double w = C.Parry.ParryWindowSec;
        Assert.Equal(DefenseResult.Parried, R(Telegraph.Blue, 5, null, false, 5 - w + 0.01, true), "blue inside the window parries");
        Assert.Equal(DefenseResult.Parried, R(Telegraph.None, 5, null, false, 5 - 0.02, true), "weak hits can be parried too");
        Assert.Equal(DefenseResult.Blocked, R(Telegraph.Blue, 5, null, false, 5 - w - 0.1, true), "early press only blocks");
        Assert.Equal(DefenseResult.Hit, R(Telegraph.Red, 5, null, false, 5 - 0.02, true), "red can't be parried or blocked");
        Assert.Equal(DefenseResult.Grabbed, R(Telegraph.Gold, 5, null, false, 5 - 0.02, true), "gold grabs a blocker");
        Assert.Equal(DefenseResult.Hit, R(Telegraph.Blue, 5, null, false, 5.05, false), "pressing after the hit is too late");
    }

    public static void BlockReducesDamageAndAvoidedHitsDealNone()
    {
        Assert.Equal((int)System.Math.Round(100 * (1 - C.Parry.BlockDamageReduction)), DefenseJudge.DamageTaken(DefenseResult.Blocked, 100, C.Parry), "block reduction");
        Assert.Equal(0, DefenseJudge.DamageTaken(DefenseResult.Parried, 100, C.Parry), "parry takes nothing");
        Assert.Equal(0, DefenseJudge.DamageTaken(DefenseResult.PerfectDodge, 100, C.Parry), "perfect dodge takes nothing");
        Assert.Equal(100, DefenseJudge.DamageTaken(DefenseResult.Hit, 100, C.Parry), "a clean hit takes everything");
    }

    public static void ChargeLevelsFollowTheThresholds()
    {
        var m = new ChargeMeter(C.Combo);
        var lv = C.Combo.ChargeLevels;
        m.Begin(); m.Tick(lv[0] - 0.05);
        Assert.Equal(0, m.Level, "below the first threshold is a tap heavy");
        m.Tick(0.1);
        Assert.Equal(1, m.Level, "first threshold");
        m.Tick(lv[2]);
        Assert.Equal(3, m.Release(), "fully charged");
        Assert.True(!m.Charging, "release ends the charge");
        Assert.True(m.PowerMult(3) > m.PowerMult(1) && m.PowerMult(1) > m.PowerMult(0), "power rises with level");
        Assert.True(!m.BreaksGuard(1) && m.BreaksGuard(2), "guard break from level 2");
        Assert.Equal(0, new ChargeMeter(C.Combo).Release(), "releasing without charging is a tap");
    }
}
