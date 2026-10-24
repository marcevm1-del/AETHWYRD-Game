using System.Linq;
using Ascend.Core;

// Taming (systems.md §7.1, Taming Roster; world_tuning.json taming).
[Tests]
static class TamingTests
{
    static TamingTuning T => Repo.Db.World.Taming;
    static SpeciesData S(string id) => Repo.Db.Species[id];

    public static void WhatCanBeTamed()
    {
        Assert.True(TamingRules.CanAttempt(S("mon_horned_rabbit"), 0.2, RankLetter.F, false, T) == TameBlock.None, "a weakened rabbit");
        Assert.True(TamingRules.CanAttempt(S("mon_horned_rabbit"), 0.8, RankLetter.F, false, T) == TameBlock.NotWeakened, "weaken it first");
        Assert.True(TamingRules.CanAttempt(S("mon_horned_rabbit"), 0, RankLetter.F, false, T) == TameBlock.Defeated, "overkill ruins it");
        Assert.True(TamingRules.CanAttempt(S("mon_goblin"), 0.2, RankLetter.F, false, T) == TameBlock.Untameable, "goblins need special quests");
        Assert.True(TamingRules.CanAttempt(S("mon_grukk_goblin_chief_of_hollowpine"), 0.2, RankLetter.SSS, false, T) == TameBlock.Untameable, "never the Tyrant");
        Assert.True(TamingRules.CanAttempt(S("mon_wild_boar"), 0.2, RankLetter.F, false, T) == TameBlock.AboveYourRank, "an E boar is above an F rookie");
        Assert.True(TamingRules.CanAttempt(S("mon_wild_boar"), 0.2, RankLetter.F, true, T) == TameBlock.None, "a Tamer reaches one rank up");
    }

    public static void CalmBuildsFearSpoils()
    {
        var e = new TameEncounter(S("mon_horned_rabbit"), T);
        e.Tick(3, near: true, crouched: false);
        Assert.Equal(30.0, e.Calm, "10 calm a second nearby");
        e.Tick(2, near: true, crouched: true);
        Assert.Equal(66.0, e.Calm, "crouching calms faster");
        double before = e.Chance(10, false, false);
        e.Attacked();
        Assert.True(e.Chance(10, false, false) < before, "attacking near it lowers the chance");
        Assert.True(e.Feed("itm_mat_prime_meat") && e.Calm == 100, "rabbits (Beasts) love prime meat");
        Assert.True(!e.Feed("itm_core_f"), "but not cores");
        for (int i = 0; i < 4; i++) e.Attacked();
        Assert.True(e.Spooked, "enough fear and it bolts");
    }

    public static void OfferingIsAChance()
    {
        var e = new TameEncounter(S("mon_horned_rabbit"), T);
        e.Tick(10, true, true);
        int tamed = 0;
        var rng = new DeterministicRandom(11);
        for (int i = 0; i < 1000; i++) if (e.Offer(10, true, false, rng) == TameResult.Tamed) tamed++;
        double expected = e.Chance(10, true, false);
        Assert.True(System.Math.Abs(tamed / 1000.0 - expected) < 0.05, $"about {expected:P0} ({tamed / 10.0}%)");
    }

    public static void FavouriteFoodsAreRealItems()
    {
        foreach (var kv in T.FavouriteFood) Assert.True(Repo.Db.Items.ContainsKey(kv.Value), kv.Key + ": " + kv.Value);
        foreach (var f in T.UntameableFamilies) Assert.True(Repo.Db.Species.Values.Any(s => s.Family == f), "family exists: " + f);
    }

    public static void TameObjectivesCount()
    {
        var log = new QuestLog(Repo.Db.Quests, Repo.Db.WeeklyQuests.Values.Select(w => w.ToQuest()));
        log.Accept("qst_wk_syl_tame_practice", new QuestContext());
        log.OnTame("mon_horned_rabbit");
        Assert.True(log.Get("qst_wk_syl_tame_practice").Status == QuestStatus.ReadyToTurnIn, "tamed a rabbit");
    }

    public static void ThreeTravelWithYouTheRestGoToTheRanch()
    {
        var r = new PartnerRoster(T);
        for (int i = 0; i < 4; i++) r.Add("mon_horned_rabbit", "Bun " + i);
        Assert.Equal(3, r.Active.Count(), "three active");
        Assert.Equal(1, r.Ranch.Count(), "one on the ranch");
        Assert.True(!r.SetActive(r.Ranch.First(), true), "no room");
        r.SetActive(r.Active.First(), false);
        Assert.True(r.SetActive(r.Ranch.First(), true), "swap in");
    }
}
