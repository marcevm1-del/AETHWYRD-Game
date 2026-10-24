using System.Collections.Generic;
using Ascend.Core;

// Adventurer rank (ranks.md §2; guild_ranks.json).
[Tests]
static class GuildRankTests
{
    static GuildRank New() => new GuildRank(Repo.Db.GuildRanks);

    public static void GpScalesWithQuestRank()
    {
        var g = New();
        Assert.Equal(1.0, g.GpMultiplier("F"), "same rank: full GP");
        Assert.Equal(1.5, g.GpMultiplier("E"), "one above: 150%");
        Assert.Equal(15, g.QuestCompleted("E", 10), "15 GP from an E quest");
        Assert.Equal(0, g.QuestsAtRank, "an E quest doesn't count as at-rank for an F");
        g.QuestCompleted("F-", 8);
        Assert.Equal(1, g.QuestsAtRank, "F- is rank F");
        g.Load(RankLetter.D, 0, 0);
        Assert.Equal(0.1, g.GpMultiplier("F"), "two below: 10%");
        g.Load(RankLetter.C, 0, 0);
        Assert.Equal(0.0, g.GpMultiplier("F"), "three below: nothing");
    }

    public static void FToENeedsEverythingOnTheList()
    {
        var g = New();
        var done = new HashSet<string>();
        bool skill = false;
        System.Func<string, bool> special = k => k == "life_skill" && skill;
        Assert.Equal("Rookie", g.Title, "F: Rookie");
        Assert.Equal(5, g.Requirements(1, special, done).Count, "level, GP, quests, life skill, trial");
        g.Load(RankLetter.F, 100, 10);
        Assert.True(!g.CanPromote(12, special, done), "no trial, no skill");
        skill = true;
        done.Add("qst_trial_f_goblin_chief");
        Assert.True(!g.CanPromote(11, special, done), "level 12 needed");
        var p = g.Promote(12, special, done);
        Assert.True(p != null && g.Rank == RankLetter.E, "promoted to E");
        Assert.Equal("itm_copper_compass", p.Gift, "the rank gift");
        Assert.Equal("copper", g.Card, "the oak card burns into copper");
        Assert.Equal(0, g.QuestsAtRank, "at-rank count starts over");
        Assert.Equal(100, g.Gp, "GP carries on");
    }

    public static void LaterTrialsArentBuiltYet()
    {
        var g = New();
        g.Load(RankLetter.E, 9999, 99);
        Assert.True(!g.CanPromote(300, _ => true, new HashSet<string>()), "the Proving Cave doesn't exist yet");
    }
}
