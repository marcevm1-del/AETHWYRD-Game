using System;
using System.Linq;
using Ascend.Core;

// The declared aiPattern strings in Data/Monsters/motion.json are all read by MonsterBrain:
// passive_* ignores you until hit, ambush_* waits then opens with a strike, "+stalker" trails then commits.
[Tests]
static class MonsterBehaviourTests
{
    const double Dt = 1.0 / 60;

    static MonsterBrain BrainOf(string id) =>
        new MonsterBrain(Repo.Db.Species[id], Repo.Db.Motion[id], Repo.Db.Attacks, new DeterministicRandom(7));

    static string Pick(Func<string, bool> pattern) =>
        Repo.Db.Motion.Values.Where(m => pattern(m.Behavior.AiPattern ?? "")).Select(m => m.SpeciesId)
            .First(id => BrainOf(id).Attacks.Count > 0);

    static AiSense S(double d, double hp = 1, bool token = true, double playerHp = 0, int allies = 0) =>
        new AiSense { DistanceToPlayer = d, DistanceFromHome = 0, HpFraction = hp, HasToken = token, PlayerHpFraction = playerHp, AlliesNear = allies };

    static bool Strikes(MonsterBrain b, Func<int, AiSense> sense, double sec)
    {
        int n = (int)(sec / Dt);
        for (int i = 0; i < n; i++) if (b.Tick(Dt, sense(i)).StrikeNow) return true;
        return false;
    }

    public static void EveryDeclaredPatternIsHandledAndEverySpeciesTicks()
    {
        int n = 0;
        foreach (var m in Repo.Db.Motion.Values)
        {
            string p = m.Behavior.AiPattern;
            Assert.True(MonsterBrain.IsKnownPattern(p), $"{m.SpeciesId}: aiPattern '{p}' is read by the brain (no silent fallthrough)");
            var b = BrainOf(m.SpeciesId);
            bool handled = b.IsPassive || b.IsAmbush || b.IsSkittish || b.IsPack || b.IsTerritorial || p.StartsWith("aggressive_chase");
            Assert.True(handled, $"{m.SpeciesId}: '{p}' maps to a behaviour");
            Assert.Equal(p.Contains("+stalker"), b.IsStalker, $"{m.SpeciesId}: +stalker is read");
            double alert = Math.Max(m.Behavior.AlertRadius, 1);
            foreach (double d in new[] { alert * 3, alert * 0.9, 1.5, 0.5 })
                for (int i = 0; i < 20; i++) b.Tick(Dt, S(d));
            n++;
        }
        Assert.True(n == Repo.Db.Motion.Count && n >= 680, $"all {n} species ran");
    }

    public static void PassiveNeverChasesFromProximity()
    {
        var b = BrainOf(Pick(p => p.StartsWith("passive_wander") && !p.Contains("+stalker")));
        Assert.True(b.IsPassive, "it is a passive species");
        // The player stands right beside it, idle, for a long time: it never leaves Idle and never attacks.
        for (int i = 0; i < 60 * 30; i++)
        {
            var c = b.Tick(Dt, S(1.0));
            Assert.True(!c.StrikeNow && !c.WantsToken, "passive species never attack an idle player");
            Assert.Equal(AiState.Idle, b.State, "stays idle beside you");
        }
    }

    public static void PassiveFightsOnlyAfterItIsHitThenFollowsItsRetreatData()
    {
        string id = Pick(p => p.StartsWith("passive_wander") && !p.Contains("+stalker"));
        var b = BrainOf(id);
        double retreat = Repo.Db.Motion[id].Behavior.RetreatHpPct;
        for (int i = 0; i < 120; i++) b.Tick(Dt, S(1.0));
        Assert.Equal(AiState.Idle, b.State, "calm before the hit");
        b.Tick(Dt, S(1.0, hp: 0.9)); // the player's hit: HP fraction dropped
        Assert.True(b.State == AiState.Chase || b.State == AiState.Flee, "engages once hit");
        if (retreat > 0)
        {
            b.Tick(Dt, S(1.0, hp: Math.Max(0.01, retreat - 0.05)));
            Assert.Equal(AiState.Flee, b.State, "then follows its retreat data (flees when hurt)");
        }
        else Assert.True(Strikes(b, _ => S(1.0, 0.9), 6), "with no retreat it fights back");
    }

    public static void PassiveJoinsWhenAPackmateCalls()
    {
        var b = BrainOf(Pick(p => p.StartsWith("passive_wander") && !p.Contains("+stalker")));
        for (int i = 0; i < 30; i++) b.Tick(Dt, S(8.0));
        b.Alert();
        Assert.Equal(AiState.Chase, b.State, "the existing Alert call engages a passive monster");
    }

    public static void AmbushHoldsStillThenOpensWithAStrike()
    {
        string id = Pick(p => p.StartsWith("ambush_strike") && !p.Contains("+stalker"));
        var b = BrainOf(id);
        double trigger = Math.Min(Repo.Db.Motion[id].Behavior.AlertRadius, MonsterBrain.AmbushMaxTriggerM);
        for (int i = 0; i < 300; i++)
        {
            var c = b.Tick(Dt, S(trigger + 1.0));
            Assert.Equal(AiState.Idle, b.State, "hidden: holds still outside the trigger radius");
            Assert.Equal(AiMove.None, c.Move, "and does not move");
        }
        Assert.True(Strikes(b, _ => S(trigger * 0.9), 3), "it opens with a strike as soon as you step inside");
        Assert.True(b.CurrentAttack != null, "the opening strike is a real attack");
    }

    public static void AmbushTriggerIsCappedForHugeAlertRadii()
    {
        var huge = Repo.Db.Motion.Values.Where(m => (m.Behavior.AiPattern ?? "").StartsWith("ambush") && m.Behavior.AlertRadius > 20)
            .Select(m => m.SpeciesId).FirstOrDefault(id => BrainOf(id).Attacks.Count > 0);
        if (huge == null) return;
        var b = BrainOf(huge);
        for (int i = 0; i < 60; i++) b.Tick(Dt, S(15));
        Assert.Equal(AiState.Idle, b.State, "a colossal ambusher still waits for the short trigger radius");
    }

    public static void StalkerTrailsThenCommitsWhenThePlayerIsBusyOrHurt()
    {
        string id = Pick(p => p.StartsWith("aggressive_chase+stalker"));
        double alert = Repo.Db.Motion[id].Behavior.AlertRadius;

        var b = BrainOf(id);
        Assert.True(b.IsStalker, "stalker suffix is read");
        double d = alert * 0.9;
        // A lone, healthy player right in front of it: it trails and never attacks, however long.
        for (int i = 0; i < 60 * 20; i++)
        {
            var c = b.Tick(Dt, S(1.5)); if (i == 0) continue; // first tick leaves Idle
            Assert.True(!c.StrikeNow, "uncommitted stalker never strikes a lone healthy player");
            Assert.True(c.Move == AiMove.Away || c.Move == AiMove.Circle || c.Move == AiMove.Toward, "it keeps trailing");
        }
        var far = b.Tick(Dt, S(alert * 0.9));
        Assert.True(far.Move == AiMove.Toward || far.Move == AiMove.Circle, "it closes to its trailing distance, not the attack distance");

        // Commit: the player is engaged with another enemy.
        var busy = BrainOf(id);
        Assert.True(Strikes(busy, _ => S(1.2, allies: 2), 6), "commits when the player fights something else");

        // Commit: the player is below the HP fraction.
        var hurt = BrainOf(id);
        Assert.True(Strikes(hurt, _ => S(1.2, playerHp: MonsterBrain.StalkCommitPlayerHp - 0.1), 6), "commits when the player is low");

        // Commit: it was hit itself.
        var hit = BrainOf(id);
        hit.Tick(Dt, S(1.2));
        hit.Tick(Dt, S(1.2, hp: 0.9));
        Assert.True(Strikes(hit, _ => S(1.2, hp: 0.9), 6), "commits once hit");
    }

    public static void NonStalkersAreUnchangedByTheNewPatterns()
    {
        // The goblin (aggressive_chase) still chases once you are inside its alert radius, as before.
        var b = BrainOf("mon_goblin");
        double alert = Repo.Db.Motion["mon_goblin"].Behavior.AlertRadius;
        b.Tick(Dt, S(alert - 1));
        Assert.Equal(AiState.Chase, b.State, "plain aggressive monsters are unchanged");
    }
}
