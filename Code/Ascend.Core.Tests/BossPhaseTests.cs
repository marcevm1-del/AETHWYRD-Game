using System.Linq;
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

    // Pins boss_phases.json for Grukk: wave A2 adds weak points beside it and must not change the phases.
    public static void GrukkPhaseDataIsPinned()
    {
        var d = Repo.Db.Bosses["mon_grukk_goblin_chief_of_hollowpine"];
        Assert.Equal(3, d.Phases.Count, "three phases");
        Assert.Equal("Duel, Archers, Rage", string.Join(", ", d.Phases.Select(p => p.Name)), "phase names in order");
        Assert.Near(1.0, d.Phases[0].AtHpFraction, 1e-9, "Duel starts at full HP");
        Assert.Near(0.66, d.Phases[1].AtHpFraction, 1e-9, "Archers at 66%");
        Assert.Near(0.33, d.Phases[2].AtHpFraction, 1e-9, "Rage at 33%");
        Assert.Near(1.0, d.Phases[0].Tempo, 1e-9, "Duel tempo");
        Assert.Near(1.0, d.Phases[1].Tempo, 1e-9, "Archers tempo");
        Assert.Near(1.4, d.Phases[2].Tempo, 1e-9, "Rage tempo 1.4");
        Assert.Near(1.0, d.Phases[0].DamageMult, 1e-9, "Duel damage");
        Assert.Near(1.0, d.Phases[1].DamageMult, 1e-9, "Archers damage");
        Assert.Near(1.3, d.Phases[2].DamageMult, 1e-9, "Rage damage x1.3");
        Assert.Equal(0, d.Phases[0].Summon.Count, "Duel summons nothing");
        Assert.Equal(1, d.Phases[1].Summon.Count, "Archers summons one group");
        Assert.Equal("mon_goblin_archer", d.Phases[1].Summon[0].SpeciesId, "archers");
        Assert.Equal(3, d.Phases[1].Summon[0].Count, "three archers");
        Assert.Equal(0, d.Phases[2].Summon.Count, "Rage summons nothing");
        var f = new BossFight(d);
        Assert.Near(1.0, f.Tempo, 1e-9, "fight starts at tempo 1");
        f.Update(0.3);
        Assert.Near(1.4, f.Tempo, 1e-9, "fight tempo in Rage");
        Assert.Near(1.3, f.DamageMult, 1e-9, "fight damage in Rage");
    }

    public static void ABigHitStillPlaysEveryPhaseInOrder()
    {
        var f = new BossFight(Repo.Db.Bosses["mon_grukk_goblin_chief_of_hollowpine"]);
        var begun = f.Update(0.1);
        Assert.Equal(2, begun.Count, "archers, then rage");
        Assert.Equal("Archers", begun[0].Name, "in order");
    }
}
