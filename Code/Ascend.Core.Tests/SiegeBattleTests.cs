using System.Linq;
using Ascend.Core;

// Live raid defence (systems.md Regional Siege; siege_waves.json).
[Tests]
static class SiegeBattleTests
{
    static SiegeWaveData Whisperwood => Repo.Db.SiegeWaves["reg_whisperwood"];

    public static void WavesArriveInOrderAndClearingThemRepels()
    {
        var b = new SiegeBattle(Whisperwood, 0);
        Assert.True(b.State == BattleState.Waiting, "not started");
        var w1 = b.NextWave();
        Assert.True(w1.Any(u => u.speciesId == "mon_goblin" && u.count == 4), "wave 1: four goblins");
        Assert.Equal(6, b.Alive, "and two archers");
        Assert.Equal(6 + 8 + 10, b.PlannedUnits, "24 raiders in all at escalation 0");
        for (int i = 0; i < 5; i++) Assert.True(!b.UnitDefeated(), "not cleared yet");
        Assert.True(b.UnitDefeated(), "the sixth clears wave 1");
        b.NextWave(); while (!b.UnitDefeated()) { }
        Assert.True(!b.IsLastWave, "wave 2 isn't the last");
        b.NextWave(); Assert.True(b.IsLastWave, "wave 3 is");
        while (!b.UnitDefeated()) { }
        Assert.Equal(0, b.NextWave().Count, "no fourth wave");
        Assert.True(b.State == BattleState.Repelled, "repelled");
        Assert.Equal(1.0, b.Progress, "everything fought off");
    }

    public static void EscalationGrowsTheWaves()
    {
        var b = new SiegeBattle(Whisperwood, 5);
        var w1 = b.NextWave();
        Assert.Equal(8, w1.First(u => u.speciesId == "mon_goblin").count, "4 × (1 + 0.2 × 5)");
    }

    public static void TimeRunsOutIntoAnAutoResolveThatCreditsThePlayer()
    {
        var b = new SiegeBattle(Whisperwood, 0);
        b.NextWave();
        b.Tick(b.TimeLimitSec + 1);
        Assert.True(b.State == BattleState.TimedOut, "timed out");
        var t = Repo.Db.World.Siege.AutoResolve;
        var weak = new SettlementDefence { Safety = 10 };
        var r = b.ResolveRemainder(weak, t, new DeterministicRandom(3));
        Assert.True(!r.SettlementDestroyed, "never destroyed");
    }

    public static void ThreatRestoresFromASave()
    {
        var th = new RegionThreat("reg_whisperwood", RegionState.Besieged, Repo.Db.World.Siege);
        th.Restore(RegionState.Weakened, 3);
        Assert.True(th.State == RegionState.Weakened && th.Escalation == 3, "restored");
        th.Restore(RegionState.Besieged, 99);
        Assert.Equal(Repo.Db.World.Siege.MaxEscalation, th.Escalation, "capped");
    }

    public static void SiegeDefenceQuestsAcceptAnySettlement()
    {
        var log = new QuestLog(Repo.Db.Quests);
        Assert.True(log.Accept("qst_siege_whisperwood_defence", new QuestContext()), "Captain Holt's contract");
        log.OnDefend("brindlewick");
        Assert.Equal(1, log.Get("qst_siege_whisperwood_defence").Counts[0], "a defended raid counts");
    }
}
