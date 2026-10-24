using System.Linq;
using Ascend.Core;

// Monster turns (combat.md §10) on the real Ring 0 data: species, attacks and motion timings.
[Tests]
static class MonsterAiTests
{
    const double Dt = 1.0 / 60;

    static MonsterBrain Brain(string id) =>
        new MonsterBrain(Repo.Db.Species[id], Repo.Db.Motion[id], Repo.Db.Attacks, new DeterministicRandom(7));

    static AiSense Near(double d, bool token = true, double hp = 1, double home = 0) =>
        new AiSense { DistanceToPlayer = d, DistanceFromHome = home, HpFraction = hp, HasToken = token };

    /// <summary>Ticks until the brain strikes (or the time runs out); returns seconds taken, or -1.</summary>
    static double UntilStrike(MonsterBrain b, AiSense s, double maxSec = 5)
    {
        for (double t = 0; t < maxSec; t += Dt) if (b.Tick(Dt, s).StrikeNow) return t;
        return -1;
    }

    public static void Ring0MonstersHaveMotionAndUsableAttacks()
    {
        foreach (var id in new[] { "mon_blue_slime", "mon_goblin", "mon_horned_rabbit" })
        {
            Assert.True(Repo.Db.Motion.ContainsKey(id), $"{id} has motion data");
            Assert.True(Brain(id).Attacks.Count >= 2, $"{id} has at least two usable attacks");
        }
        Assert.True(Repo.Db.Motion.Count == Repo.Db.Species.Count, "every species has motion data");
    }

    public static void GoblinIgnoresYouOutsideItsAlertRadius()
    {
        var b = Brain("mon_goblin");
        double alert = Repo.Db.Motion["mon_goblin"].Behavior.AlertRadius;
        for (int i = 0; i < 60; i++) b.Tick(Dt, Near(alert + 5));
        Assert.Equal(AiState.Idle, b.State, "idle while you are far");
        b.Tick(Dt, Near(alert - 1));
        Assert.Equal(AiState.Chase, b.State, "chases once you are inside the alert radius");
        Assert.Equal(AiMove.Toward, b.Tick(Dt, Near(alert - 1)).Move, "moves toward you");
    }

    public static void StrikeComesAfterTheWindupThenARecoveryWindow()
    {
        var b = Brain("mon_goblin");
        b.Tick(Dt, Near(1.2)); // alert → chase
        double t = UntilStrike(b, Near(1.2));
        Assert.True(t >= 0, "it attacks when in range with a token");
        Assert.True(t + 1e-6 >= b.CurrentTiming.WindupSec - Dt, $"strike lands after the {b.CurrentTiming.WindupSec}s windup (took {t:0.00}s)");
        Assert.True(b.CurrentTelegraph != Telegraph.None || b.CurrentAttack.Telegraph == "none", "the attack carries its telegraph");
        // No second strike before active + recovery have passed: that gap is the punish window.
        double window = b.CurrentTiming.ActiveSec + b.CurrentTiming.RecoverySec;
        for (double s = 0; s < window - 2 * Dt; s += Dt) Assert.True(!b.Tick(Dt, Near(1.2)).StrikeNow, "no strike during recovery");
    }

    public static void NoTokenNoAttackOnlyRepositioning()
    {
        var b = Brain("mon_goblin");
        b.Tick(Dt, Near(1.2, token: false));
        AiCommand last = default;
        for (int i = 0; i < 300; i++) { last = b.Tick(Dt, Near(1.2, token: false)); Assert.True(!last.StrikeNow, "never strikes without a token"); }
        Assert.Equal(AiState.Reposition, b.State, "circles while waiting for a token");
        Assert.True(last.WantsToken && last.Move == AiMove.Circle, "asks for a token and circles");
    }

    public static void StaggerInterruptsTheWindup()
    {
        var b = Brain("mon_goblin");
        b.Tick(Dt, Near(1.2));
        b.Tick(Dt, Near(1.2));
        Assert.Equal(AiState.Windup, b.State, "winding up");
        b.Stagger();
        for (double t = 0; t < MonsterBrain.StaggerSec - Dt; t += Dt) Assert.True(!b.Tick(Dt, Near(1.2)).StrikeNow, "no strike while staggered");
        Assert.True(UntilStrike(b, Near(1.2)) >= 0, "attacks again after recovering");
    }

    public static void TerritorialSlimeGoesHomePastItsLeash()
    {
        var b = Brain("mon_blue_slime");
        var m = Repo.Db.Motion["mon_blue_slime"].Behavior;
        b.Tick(Dt, Near(m.AlertRadius - 0.5));
        Assert.Equal(AiState.Chase, b.State, "alerted");
        var cmd = b.Tick(Dt, Near(m.AlertRadius + 3, home: m.AlertRadius * 1.5 + 1));
        Assert.Equal(AiState.Return, b.State, "gives up past its leash");
        Assert.Equal(AiMove.Home, b.Tick(Dt, Near(20, home: 5)).Move, "walks home");
        b.Tick(Dt, Near(20, home: 0.1));
        Assert.Equal(AiState.Idle, b.State, "idle again at home");
    }

    public static void HornedRabbitRunsFirstThenCharges()
    {
        var b = Brain("mon_horned_rabbit");
        var m = Repo.Db.Motion["mon_horned_rabbit"].Behavior;
        var first = b.Tick(Dt, Near(m.AlertRadius - 1));
        Assert.True(b.IsSkittish, "skittish pattern");
        Assert.Equal(AiState.Flee, b.State, "runs when it notices you");
        Assert.Equal(AiMove.Away, b.Tick(Dt, Near(4)).Move, "moves away");
        Assert.True(UntilStrike(b, Near(4), MonsterBrain.FleeSec + 3) >= 0, "then turns and attacks (a dash from range)");
        Assert.True(MonsterBrain.IsGapCloser(b.CurrentTiming.Kind), $"from 4 m the rabbit charges or leaps (got {b.CurrentTiming.Kind})");
    }

    public static void RangedAttacksKeepTheirMinimumRange()
    {
        var b = Brain("mon_goblin");
        foreach (var a in b.Attacks.Where(x => MonsterBrain.IsRanged(x.timing.Kind)))
            Assert.True(b.MinRangeOf(a.timing) > 0 && b.ReachOf(a.timing) > b.MinRangeOf(a.timing), $"{a.data.Id} has a real range band");
    }
}

[Tests]
static class MonsterStunTests
{
    public static void StunHoldsForItsOwnDuration()
    {
        var b = new MonsterBrain(Repo.Db.Species["mon_horned_rabbit"], Repo.Db.Motion["mon_horned_rabbit"], Repo.Db.Attacks, new DeterministicRandom(3));
        var s = new AiSense { DistanceToPlayer = 3, HpFraction = 1, HasToken = true };
        b.Tick(1.0 / 60, s);
        b.Stun(1.5);
        for (double t = 0; t < 1.45; t += 1.0 / 60) { b.Tick(1.0 / 60, s); Assert.Equal(AiState.Staggered, b.State, "stuck for the whole 1.5 s"); }
        for (int i = 0; i < 10; i++) b.Tick(1.0 / 60, s);
        Assert.True(b.State != AiState.Staggered, "free again afterwards");
    }

    public static void FlyersAreReadFromMotionData()
    {
        Assert.True(Repo.Db.Motion["mon_lantern_moth"].Locomotion.Flies, "moths fly");
        Assert.True(Repo.Db.Motion["mon_giant_crow"].Locomotion.Flies, "crows fly");
        Assert.True(Repo.Db.Motion["mon_ghost"].Locomotion.Flies, "ghosts float");
        Assert.True(!Repo.Db.Motion["mon_goblin"].Locomotion.Flies, "goblins walk");
        Assert.True(Repo.Db.Motion["mon_lantern_moth"].HeightM > 0, "heights are read");
    }
}
