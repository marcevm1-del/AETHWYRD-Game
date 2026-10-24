using Ascend.Core;

// Boss phases (bosses_and_calamities.md §1; boss_phases.json).
[Tests]
static class BossPhaseTests
{
    public static void GrukkDuelsThenCallsArchersThenRages()
    {
        var f = new BossFight(Repo.Db.Bosses["mon_grukk_goblin_chief_of_hollowpine"]);
        Assert.Equal("Duel", f.Current.Name, "phase 1: the duel");
        Assert.Equal(0, f.Update(0.8).Count, "no change at 80%");
        var p2 = f.Update(0.6);
        Assert.True(p2.Count == 1 && p2[0].Name == "Archers" && p2[0].Summon[0].Count == 3, "phase 2 calls three archers");
        Assert.Equal(0, f.Update(0.5).Count, "only once");
        f.Update(0.3);
        Assert.Equal("Rage", f.Current.Name, "phase 3: rage");
        Assert.True(f.Tempo > 1 && f.DamageMult > 1, "faster and harder");
    }

    public static void ABigHitStillPlaysEveryPhaseInOrder()
    {
        var f = new BossFight(Repo.Db.Bosses["mon_grukk_goblin_chief_of_hollowpine"]);
        var begun = f.Update(0.1);
        Assert.Equal(2, begun.Count, "archers, then rage");
        Assert.Equal("Archers", begun[0].Name, "in order");
    }
}
