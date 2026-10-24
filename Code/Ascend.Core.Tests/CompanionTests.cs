using Ascend.Core;

// Companion field AI decision order (companion_field_ai.md).
[Tests]
static class CompanionTests
{
    static CompanionTuning T => Repo.Db.World.Companions;
    static CompanionSense Calm => new CompanionSense { DistanceToPlayer = 3, DodgeReady = true };

    public static void SafetyComesFirst()
    {
        var s = Calm; s.ThreatWindingUpNearMe = true; s.StaggeredEnemyNear = true; s.Order = CompanionOrder.Focus; s.PlayerTargetAlive = true;
        Assert.True(CompanionBrain.Decide(s, T) == CompanionAction.Dodge, "dodge the wind-up before anything else");
        s.DodgeReady = false;
        Assert.True(CompanionBrain.Decide(s, T) == CompanionAction.SignatureAssist, "no dodge left: take the opening");
    }

    public static void OrdersAndRole()
    {
        var s = Calm;
        Assert.True(CompanionBrain.Decide(s, T) == CompanionAction.Follow, "nothing happening: follow");
        s.EnemyInLeash = true;
        Assert.True(CompanionBrain.Decide(s, T) == CompanionAction.Attack, "a threat near you: fight it");
        s.Order = CompanionOrder.Hold; s.EnemyInLeash = false;
        Assert.True(CompanionBrain.Decide(s, T) == CompanionAction.Guard, "hold: guard the spot");
        s.Order = CompanionOrder.Focus; s.PlayerTargetAlive = true;
        Assert.True(CompanionBrain.Decide(s, T) == CompanionAction.Attack, "focus your target");
    }

    public static void FarAwayRegroupsAndDownedWaits()
    {
        var s = Calm; s.DistanceToPlayer = 40; s.EnemyInLeash = true;
        Assert.True(CompanionBrain.Decide(s, T) == CompanionAction.Regroup, "too far: regroup");
        s.Downed = true;
        Assert.True(CompanionBrain.Decide(s, T) == CompanionAction.Downed, "downed: recovering");
    }

    public static void BanterWaitsForQuiet()
    {
        Assert.True(!CompanionBrain.MaySpeak(true, 999, false, T), "not in combat");
        Assert.True(!CompanionBrain.MaySpeak(false, 5, false, T), "cooldown");
        Assert.True(!CompanionBrain.MaySpeak(false, 999, true, T), "quiet mode");
        Assert.True(CompanionBrain.MaySpeak(false, 999, false, T), "otherwise yes");
    }
}
