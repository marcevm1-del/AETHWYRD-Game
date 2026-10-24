using System.Collections.Generic;
using System.Linq;
using Ascend.Core;

// The weekly guild board's quests in the journal (weekly_board.json; WeeklyBoard).
[Tests]
static class BoardQuestTests
{
    static QuestLog NewLog() => new QuestLog(Repo.Db.Quests, Repo.Db.WeeklyQuests.Values.Select(w => w.ToQuest()));

    public static void BoardQuestsTrackAndRepeat()
    {
        var log = NewLog();
        Assert.True(log.Accept("qst_wk_syl_slime_patrol", new QuestContext()), "a daily is accepted from the board");
        for (int i = 0; i < 6; i++) log.OnKill("mon_blue_slime");
        log.OnKill("mon_green_slime"); log.OnKill("mon_green_slime");
        var inv = new Inventory();
        Assert.True(log.TryTurnIn("qst_wk_syl_slime_patrol", inv, null, out _), "handed in");
        Assert.True(!log.CanAccept("qst_wk_syl_slime_patrol", new QuestContext()), "done for now");
        log.Forget("qst_wk_syl_slime_patrol");
        Assert.True(log.CanAccept("qst_wk_syl_slime_patrol", new QuestContext()), "posted again another day");
    }

    public static void EscortCountsWhenTheNpcArrives()
    {
        var log = NewLog();
        log.Accept("qst_wk_sol_escort_cart", new QuestContext());
        log.OnEscort("npc_marta_gruel");
        Assert.Equal(0, log.Get("qst_wk_sol_escort_cart").Counts[0], "the wrong NPC doesn't count");
        log.OnEscort("npc_traveling_merchant_pell");
        Assert.Equal(1, log.Get("qst_wk_sol_escort_cart").Counts[0], "Ottoline arrived");
    }

    public static void BoardQuestsArentOfferedByTheirGiversDirectly()
    {
        var log = NewLog();
        Assert.True(!log.OffersFrom("npc_marta_gruel", new QuestContext()).Any(q => q.Id.StartsWith("qst_wk_")), "only the board posts them");
    }

    public static void EscortAndTameAreNowPosted()
    {
        Assert.True(Repo.Db.WeeklyQuests["qst_wk_sol_escort_cart"].Playable, "escort works now");
        Assert.True(Repo.Db.WeeklyQuests["qst_wk_syl_tame_practice"].Playable, "tame works now");
        Assert.True(Repo.Db.WeeklyQuests["qst_wk_syl_slime_patrol"].Playable, "kill quests are fine");
    }
}
