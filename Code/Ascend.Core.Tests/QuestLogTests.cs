using System.Linq;
using Ascend.Core;

// The quest journal: accept, progress, turn in, save (quests.md).
[Tests]
static class QuestLogTests
{
    static QuestLog NewLog() => new QuestLog(Repo.Db.Quests);

    public static void KillQuestProgressesAndPaysOnTurnIn()
    {
        var log = NewLog();
        Assert.True(log.Accept("qst_gld_f_rabbit_season", new QuestContext()), "Mina offers Rabbit Season at F");
        string ready = null;
        log.Ready += id => ready = id;
        for (int i = 0; i < 7; i++) log.OnKill("mon_horned_rabbit");
        log.OnKill("mon_goblin");
        Assert.Equal(7, log.Get("qst_gld_f_rabbit_season").Counts[0], "only rabbits count");
        Assert.True(ready == null, "not ready at 7 of 8");
        log.OnKill("mon_horned_rabbit"); log.OnKill("mon_horned_rabbit");
        Assert.Equal(8, log.Get("qst_gld_f_rabbit_season").Counts[0], "capped at the target");
        Assert.Equal("qst_gld_f_rabbit_season", ready, "ready to turn in");

        var inv = new Inventory();
        var prog = new PlayerProgress(Repo.Db.Progression);
        Assert.True(log.TryTurnIn("qst_gld_f_rabbit_season", inv, prog, out var pay), "turned in");
        Assert.Equal(60L, inv.Copper, "60 copper");
        Assert.Equal(1, inv.Count("itm_minor_hp_potion"), "a potion");
        Assert.Equal(8, log.GuildPoints, "guild points");
        Assert.True(prog.Level > 1 || prog.XpIntoLevel == 120, "XP paid");
        Assert.True(log.Completed.Contains("qst_gld_f_rabbit_season") && !log.IsActive("qst_gld_f_rabbit_season"), "completed");
        Assert.True(!log.CanAccept("qst_gld_f_rabbit_season", new QuestContext()), "not offered twice");
    }

    public static void TalkObjectivesGoInOrder()
    {
        var log = NewLog();
        Assert.True(!log.CanAccept("qst_main_wooden_card", new QuestContext()), "needs Status Granted and act 1 first");
        Assert.True(log.Accept("qst_main_wooden_card", new QuestContext { Act = 1, CompletedQuests = new System.Collections.Generic.HashSet<string> { "qst_main_status_granted" } }), "then offered");
        log.OnTalk("npc_rodrick_hale");
        Assert.Equal(0, log.Get("qst_main_wooden_card").Counts[1], "Rodrick waits until you've seen Mina");
        log.OnTalk("npc_mina_feathersby"); log.OnTalk("npc_rodrick_hale");
        Assert.True(log.Get("qst_main_wooden_card").Status == QuestStatus.ReadyToTurnIn, "both talked to, in order");
    }

    public static void ChoicesAndCollectNeedTheItemsAtTurnIn()
    {
        var log = NewLog();
        Assert.True(!log.CanAccept("qst_gather_crying_mandrake", new QuestContext()), "level 4 needed");
        Assert.True(log.Accept("qst_gather_crying_mandrake", new QuestContext { Level = 4 }), "accepted at level 4");
        var inv = new Inventory();
        inv.Add("itm_mandrake_root", 3);
        log.OnInventoryChanged(inv);
        Assert.True(log.Get("qst_gather_crying_mandrake").Status == QuestStatus.Active, "the choice is still open");
        Assert.True(log.Choose("qst_gather_crying_mandrake", 1, "spare"), "choose to spare it");
        Assert.True(!log.Choose("qst_gather_crying_mandrake", 0, "x"), "a collect objective isn't a choice");
        Assert.True(log.Get("qst_gather_crying_mandrake").Status == QuestStatus.ReadyToTurnIn, "ready");
        inv.TryRemove("itm_mandrake_root");
        log.OnInventoryChanged(inv);
        Assert.True(log.Get("qst_gather_crying_mandrake").Status == QuestStatus.Active, "selling a root un-readies it");
        inv.Add("itm_mandrake_root"); log.OnInventoryChanged(inv);
        Assert.True(log.TryTurnIn("qst_gather_crying_mandrake", inv, null, out _), "turned in");
        Assert.Equal(0, inv.Count("itm_mandrake_root"), "the roots are handed over");
    }

    public static void OffersRespectGiverAndLevel()
    {
        var log = NewLog();
        var offers = log.OffersFrom("npc_mina_feathersby", new QuestContext()).Select(q => q.Id).ToList();
        Assert.True(offers.Contains("qst_gld_f_rabbit_season"), "Mina offers Rabbit Season");
        Assert.True(!offers.Contains("qst_gld_f_slime_cleanup"), "Odo's quest isn't hers");
    }

    public static void SaveAndLoadKeepProgress()
    {
        var log = NewLog();
        log.Accept("qst_gld_f_rabbit_season", new QuestContext());
        log.OnKill("mon_horned_rabbit"); log.OnKill("mon_horned_rabbit");
        var saved = log.SaveActive();
        log.OnKill("mon_horned_rabbit");
        Assert.Equal(2, saved[0].Counts[0], "the save is a copy");
        var back = NewLog();
        back.Load(saved, new[] { "qst_main_bowl_of_stew", "qst_removed_from_data" }, 14);
        Assert.Equal(2, back.Get("qst_gld_f_rabbit_season").Counts[0], "progress restored");
        Assert.True(back.Completed.Contains("qst_main_bowl_of_stew") && !back.Completed.Contains("qst_removed_from_data"), "unknown quests are dropped");
        Assert.Equal(14, back.GuildPoints, "guild points restored");
    }

    public static void QuestItemsDropFromTheirSpeciesUntilYouHaveEnough()
    {
        var log = NewLog();
        var inv = new Inventory();
        Assert.Equal(0, log.QuestDrops("mon_giant_crow", inv).Count, "no quest, no earring");
        log.Accept("qst_odd_minas_earring", new QuestContext { Level = 3 });
        Assert.True(log.QuestDrops("mon_giant_crow", inv).SequenceEqual(new[] { "itm_minas_earring" }), "the crow has it");
        Assert.Equal(0, log.QuestDrops("mon_goblin", inv).Count, "goblins don't");
        int changes = 0; inv.Changed += () => changes++;
        inv.Add("itm_minas_earring");
        Assert.Equal(1, changes, "inventory reports the change");
        Assert.Equal(0, log.QuestDrops("mon_giant_crow", inv).Count, "only one earring");
    }

    public static void ChoiceOptionsReadNaturally()
    {
        Assert.True(QuestChoices.Options("spare_or_harvest_the_baby").SequenceEqual(new[] { "spare", "harvest the baby" }), "two options");
        Assert.True(QuestChoices.Options("slay_tame_or_parley").SequenceEqual(new[] { "slay", "tame", "parley" }), "three options");
        Assert.True(QuestChoices.Options("fight_or_walk_away").SequenceEqual(new[] { "fight", "walk away" }), "multi-word last option");
        Assert.True(QuestChoices.Options("spare_the_goblin_child").SequenceEqual(new[] { "spare the goblin child", "refuse" }), "yes or no");
    }
}
