using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Ascend.Core;

// Monster lines, variations, guilds, contracts, bounties, factions, lairs and grade labels
// (Canon section 6 proposals M1 to M6; 13_Production/monster_guild_integration.md).
[Tests]
static class MonsterGuildTests
{
    static MonsterLines _lines;
    static MonsterLines Lines => _lines ??= new MonsterLines(Repo.Load<EvolutionLineFile>("Data/Monsters/evolution_lines.json"), Repo.Load<SpeciesLineFile>("Data/Monsters/species_lines.json"));
    static VariationRules Vars => new VariationRules(Repo.Load<VariationFile>("Data/Monsters/variations.json"), Lines);
    static GuildFile GuildData => Repo.Load<GuildFile>("Data/World/guilds.json");
    static GuildStanding NewStanding() => new GuildStanding(GuildData);
    static ContractFile ContractData => Repo.Load<ContractFile>("Data/Quests/guild_contracts.json");
    static SpeciesData Sp(string name) => Repo.Db.Species.Values.First(s => s.Name == name);
    static readonly Func<string, bool> NoFlags = _ => false;

    // ---------- evolution lines ----------

    public static void ThirtyLinesWithNineStagesEach()
    {
        Assert.Equal(30, Lines.Lines.Count, "30 groups");
        foreach (var l in Lines.Lines)
        {
            Assert.Equal(9, l.Stages.Count, l.Id + " stages");
            for (int i = 0; i < 9; i++) Assert.Equal(i + 1, l.Stages[i].Stage, l.Id + " stage order");
        }
    }

    public static void EverySpeciesIsAssignedOrExplicitlyLeftOut()
    {
        var assigned = Lines.Lines.SelectMany(l => Lines.SpeciesInLine(l.Id)).ToList();
        var left = Repo.Load<SpeciesLineFile>("Data/Monsters/species_lines.json").Unassigned;
        Assert.Equal(Repo.Db.Species.Count, assigned.Count + left.Count, "assigned + left out = every species");
        Assert.Equal(assigned.Count, assigned.Distinct().Count(), "no species in two lines");
        foreach (var id in assigned) Assert.True(Repo.Db.Species.ContainsKey(id), "known species " + id);
    }

    public static void KnownNamesLandOnTheirStage()
    {
        Assert.Equal("evl_goblins", Lines.LineOf(Sp("Goblin").Id).Id, "Goblin");
        Assert.Equal(2, Lines.StageOf(Sp("Goblin").Id), "Goblin is stage 2 (Goblin)");
        Assert.Equal("evl_hobgoblin_kind", Lines.LineOf(Sp("Hobgoblin").Id).Id, "Hobgoblin is its own group");
        Assert.Equal("evl_ogres", Lines.LineOf(Sp("Ogre").Id).Id, "Ogre");
        Assert.Equal("evl_trolls", Lines.LineOf(Sp("Troll").Id).Id, "Troll");
        Assert.Equal("evl_drakes", Lines.LineOf(Sp("Drake Lord").Id).Id, "Drake Lord");
        Assert.Equal(7, Lines.StageOf(Sp("Drake Lord").Id), "Drake Lord is stage 7");
        Assert.Equal("Drake Lord", Lines.StageLabel("evl_drakes", 7), "stage label");
    }

    public static void AVariantSitsWhereItsBaseSits()
    {
        var v = Repo.Db.Species.Values.First(s => !string.IsNullOrEmpty(s.BaseSpeciesId) && Lines.LineOf(s.BaseSpeciesId) != null);
        Assert.Equal(Lines.LineOf(v.BaseSpeciesId).Id, Lines.LineOf(v.Id).Id, "same line as its base");
        Assert.Equal(Lines.StageOf(v.BaseSpeciesId), Lines.StageOf(v.Id), "same stage as its base");
    }

    public static void ThreatIsNotInferredFromStage()
    {
        // Within one stage the species ranks must differ: stage is progression naming, threat is its own rating (bible section 6).
        var byStage = Lines.Lines.SelectMany(l => Lines.SpeciesInLine(l.Id)).GroupBy(id => Lines.StageOf(id));
        int mixed = 0;
        foreach (var g in byStage) if (g.Select(id => Rank.Parse(Repo.Db.Species[id].Rank).Letter).Distinct().Count() > 1) mixed++;
        Assert.True(mixed >= 6, "most stages hold more than one rank letter, so stage does not set threat");
        var loneDragon = Sp("Hatchling"); // stage 1 by name, but not a weak monster by that alone: its rank is its own field
        Assert.Equal(Repo.Db.Species[loneDragon.Id].Rank, loneDragon.Rank, "rank comes from the species");
    }

    public static void NoMonsterEvolvesFromDefeatingThePlayer()
    {
        var id = Sp("Goblin").Id;
        Assert.True(!Lines.IsTriggerAllowed("defeated_player"), "Canon 4d");
        Assert.True(!Lines.IsTriggerAllowed("player_death"), "Canon 4d");
        Assert.True(!Lines.CheckEvolution(id, "defeated_player", new[] { "experience", "age" }).Allowed, "refused even with conditions met");
        Assert.True(Lines.CheckEvolution(id, "region_state", new[] { "environment" }).Allowed, "region state is allowed");
        Assert.Equal(3, Lines.CheckEvolution(id, "region_state", new[] { "environment" }).ToStage, "stage 2 steps to 3");
        Assert.True(!Lines.CheckEvolution(id, "region_state", new string[0]).Allowed, "needs a condition");
        Assert.True(!Lines.CheckEvolution(id, "region_state", new[] { "nonsense" }).Allowed, "unknown conditions do not count");
    }

    public static void LateStagesNeedTwoConditionsAndTheLastCannotEvolve()
    {
        var lateGoblin = Lines.SpeciesInLine("evl_goblins").First(sid => Lines.StageOf(sid) == 8);
        Assert.True(!Lines.CheckEvolution(lateGoblin, "age", new[] { "age" }).Allowed, "stage 8 to 9 needs two");
        Assert.True(Lines.CheckEvolution(lateGoblin, "age", new[] { "age", "awakening" }).Allowed, "two conditions");
        var last = Lines.SpeciesInLine("evl_undead").First(sid => Lines.StageOf(sid) == 9);
        Assert.True(!Lines.CheckEvolution(last, "age", new[] { "age", "mana" }).Allowed, "stage 9 is the end");
        Assert.True(!Lines.CheckEvolution("nope", "age", new[] { "age" }).Allowed, "unknown species");
    }

    public static void FusionNeedsACatalystEnergyCostAndAListedPair()
    {
        Assert.Equal("Dragon Hydra", Lines.Fuse("evl_dragons", "evl_hydras", true, true, true), "listed pair");
        Assert.Equal("Dragon Hydra", Lines.Fuse("evl_hydras", "evl_dragons", true, true, true), "order does not matter");
        Assert.Equal(null, Lines.Fuse("evl_dragons", "evl_hydras", false, true, true), "no catalyst");
        Assert.Equal(null, Lines.Fuse("evl_dragons", "evl_hydras", true, false, true), "no stable energy");
        Assert.Equal(null, Lines.Fuse("evl_dragons", "evl_hydras", true, true, false), "no cost");
        Assert.Equal(null, Lines.Fuse("evl_goblins", "evl_slimes", true, true, true), "unlisted pair");
    }

    // ---------- variations ----------

    public static void TwelveVariationsNeverChangeThreatRank()
    {
        var vars = Vars;
        Assert.Equal(12, vars.All.Count, "12 variations");
        foreach (var v in vars.All) Assert.Equal(0, v.RankShift, v.Id + " never shifts rank");
        var orc = Sp("Orc Grunt");
        var r = vars.Apply(orc, new[] { "var_horned", "var_infernal" });
        Assert.Equal(orc.Rank, r.Rank, "rank is the species' own");
        Assert.Equal(orc.Id, r.SpeciesId, "still the same species");
    }

    public static void StackingHasDiminishingReturns()
    {
        var vars = Vars; var orc = Sp("Orc Grunt");
        double first = vars.Apply(orc, new[] { "var_horned" }).Stats.Atk;
        Assert.Equal((int)Math.Round(orc.Stats.Atk * 1.15, MidpointRounding.AwayFromZero), (int)first, "horned: x1.15 attack");
        var both = vars.Apply(orc, new[] { "var_horned", "var_infernal" }).Stats.Atk;
        double expected = orc.Stats.Atk * 1.15 * (1 + 0.1 * 0.6); // infernal is x1.1, applied at 60%
        Assert.True(Math.Abs(both - expected) <= 1.0, $"second variation at 60% strength: expected ~{expected:0.0}, got {both}");
        Assert.True(both < orc.Stats.Atk * 1.15 * 1.1, "less than two full multipliers");
    }

    public static void IncompatibleExclusiveScriptedAndOverstackedAreRefused()
    {
        var vars = Vars; var orc = Sp("Orc Grunt");
        Assert.True(vars.Problems(orc.Id, new[] { "var_frozen", "var_infernal" }).Count > 0, "frozen and infernal are exclusive");
        Assert.True(vars.Problems(orc.Id, new[] { "var_blessed", "var_cursed" }).Count > 0, "blessed and cursed are exclusive");
        Assert.True(vars.Problems(orc.Id, new[] { "var_awakened" }).Count > 0, "awakened needs a script");
        Assert.Equal(0, vars.Problems(orc.Id, new[] { "var_awakened" }, true).Count, "a script allows awakened");
        Assert.True(vars.Problems(orc.Id, new[] { "var_horned", "var_frozen", "var_shadow", "var_ancient" }).Count > 0, "four is too many");
        Assert.True(vars.Problems(orc.Id, new[] { "var_horned", "var_horned" }).Count > 0, "no repeats");
        var undead = Repo.Db.Species.Values.First(s => Lines.LineOf(s.Id)?.Id == "evl_undead");
        Assert.True(!vars.Compatible(undead.Id, "var_blessed"), "no blessed undead without a lore reason");
        var slime = Sp("Blue Slime");
        Assert.True(!vars.Compatible(slime.Id, "var_horned"), "no horned slimes");
        Assert.Throws<InvalidOperationException>(() => vars.Apply(slime, new[] { "var_horned" }), "Apply refuses what Problems lists");
    }

    public static void AVariationSetsAnElementAndKeepsCues()
    {
        var r = Vars.Apply(Sp("Orc Grunt"), new[] { "var_infernal" });
        Assert.Equal("Fire", r.Element, "infernal burns");
        Assert.True(r.VisualCues.Count == 1 && r.WeaknessNotes.Count == 1, "cue and weakness note");
    }

    // ---------- guilds ----------

    public static void ThirtyGuildsAndAnEightStepLadderWithoutAPlayerGrandmaster()
    {
        var g = GuildData;
        Assert.Equal(30, g.Guilds.Count, "30 guilds");
        Assert.Equal(8, g.MemberLadder.Count, "8 tiers");
        Assert.Equal(7, g.PlayerMaxTier, "the player stops at Master");
        Assert.True(!g.MemberLadder.Last().PlayerCanHold, "Grandmaster is story-only (Canon section 4)");
        Assert.True(!g.Guilds.First(x => x.Id == "gld_adventurers").UsesMemberLadder, "the Adventurers' Guild keeps its own ranks");
    }

    public static void JoiningNeedsTheRightRankOrFlag()
    {
        var s = NewStanding();
        Assert.True(!s.Join("gld_adventurers", RankLetter.SSS, NoFlags), "the main guild uses GuildRank, not this ladder");
        Assert.True(!s.Join("gld_necromancers", RankLetter.D, NoFlags), "restricted: needs rank C");
        Assert.True(s.Join("gld_necromancers", RankLetter.C, NoFlags), "rank C may apply");
        Assert.True(!s.Join("gld_veiled_hand", RankLetter.SSS, NoFlags), "hidden guilds need their story flag");
        Assert.True(s.Join("gld_veiled_hand", RankLetter.F, f => f == "guild_veiled_hand_found"), "found them");
        Assert.True(s.Join("gld_cooks", RankLetter.F, NoFlags), "public guilds are open");
        Assert.True(!s.Join("gld_cooks", RankLetter.F, NoFlags), "no double membership");
        Assert.Equal(1, s.Tier("gld_cooks"), "everyone starts as an Applicant");
        Assert.Equal(3, s.Memberships.Count(), "several guilds at once");
    }

    public static void ReputationIsPerGuildAndCappedEachDay()
    {
        var s = NewStanding();
        s.Join("gld_cooks", RankLetter.F, NoFlags); s.Join("gld_miners", RankLetter.F, NoFlags);
        int gained = 0;
        for (int i = 0; i < 8; i++) gained += s.ContractDone("gld_cooks", 1);
        Assert.Equal(40, gained, "contract_completed stops at its daily cap of 40");
        Assert.Equal(8, s.Contracts("gld_cooks"), "but every contract still counts");
        Assert.Equal(0, s.Reputation("gld_miners"), "another guild is unaffected");
        Assert.Equal(10, s.ContractDone("gld_cooks", 2), "the cap resets next day");
        Assert.Equal(2, s.Apply("gld_cooks", "donation", 2, 1), "a donation unit");
    }

    public static void PromotionNeedsReputationContractsAndTheGate()
    {
        var s = NewStanding();
        s.Join("gld_cooks", RankLetter.F, NoFlags);
        Assert.Equal("needs 10 reputation", s.WhyNotPromote("gld_cooks", false, false), "an Applicant needs a first contribution");
        int day = 1;
        while (s.Contracts("gld_cooks") < 20) s.ContractDone("gld_cooks", day++);
        while (s.Promote("gld_cooks", false, false)) { }
        Assert.Equal(4, s.Tier("gld_cooks"), "Veteran is reached by reputation and contracts alone");
        Assert.Equal("needs 300 reputation", s.WhyNotPromote("gld_cooks", false, false), "Expert needs more reputation first");
        while (s.Reputation("gld_cooks") < 300) s.Apply("gld_cooks", "rescue", day++);
        Assert.Equal("needs 15 contracts", s.Contracts("gld_cooks") >= 15 ? "needs 15 contracts" : "x", "contracts are already enough");
        Assert.Equal("needs a mastery test", s.WhyNotPromote("gld_cooks", false, false), "then a test");
        Assert.True(s.Promote("gld_cooks", true, false), "the test passed");
        Assert.Equal(5, s.Tier("gld_cooks"), "Expert");
        Assert.True(s.WhyNotPromote("gld_cooks", true, false) != null, "Officer needs more");
    }

    public static void TheTopOfTheLadderIsNeverReachedByThePlayer()
    {
        var s = NewStanding();
        s.Join("gld_cooks", RankLetter.F, NoFlags);
        for (int day = 1; day <= 400; day++)
        {
            s.ContractDone("gld_cooks", day);
            s.Apply("gld_cooks", "rescue", day);
            s.Promote("gld_cooks", true, true);
        }
        Assert.Equal(7, s.Tier("gld_cooks"), "Master is the most the player holds");
        Assert.Equal("the top of the ladder is story-only", s.WhyNotPromote("gld_cooks", true, true), "Grandmaster stays story-only");
    }

    public static void BadConductGetsYouBannedAndRevokesMembership()
    {
        var s = NewStanding();
        s.Join("gld_cooks", RankLetter.F, NoFlags);
        for (int day = 1; day <= 6 && s.Level("gld_cooks") != GuildStandingLevel.Banned; day++) s.Apply("gld_cooks", "stole_guild_property", day, 2);
        Assert.Equal(GuildStandingLevel.Banned, s.Level("gld_cooks"), "banned");
        Assert.True(!s.IsMember("gld_cooks"), "membership revoked");
        Assert.True(!s.Join("gld_cooks", RankLetter.F, NoFlags), "cannot rejoin while banned");
        Assert.Equal(0, s.DiscountPercent("gld_cooks"), "no discount");
    }

    public static void DiscountsAreBoundedAndOneGuildCanDistrustYouWhileAnotherRespectsYou()
    {
        var s = NewStanding();
        s.Join("gld_cooks", RankLetter.F, NoFlags); s.Join("gld_miners", RankLetter.F, NoFlags);
        for (int day = 1; day <= 400; day++) { s.ContractDone("gld_cooks", day); s.Apply("gld_cooks", "rescue", day); s.Promote("gld_cooks", true, true); }
        Assert.True(s.DiscountPercent("gld_cooks") <= GuildData.MaxDiscountPercent, "bounded");
        Assert.True(s.DiscountPercent("gld_cooks") > 0, "a Master gets a discount");
        s.Apply("gld_miners", "broke_contract", 1, 2);
        Assert.Equal(GuildStandingLevel.Distrusted, s.Level("gld_miners"), "distrusted by one");
        Assert.True(s.Level("gld_cooks") >= GuildStandingLevel.Neutral, "still welcome at the other");
        Assert.Equal(0, s.DiscountPercent("gld_miners"), "no discount while distrusted");
        Assert.True(s.Rivals("gld_necromancers").Contains("gld_exorcists"), "rivalry table");
    }

    public static void GuildStateRoundTripsAndOlderSavesLoad()
    {
        var s = NewStanding();
        s.Join("gld_cooks", RankLetter.F, NoFlags);
        s.ContractDone("gld_cooks", 3); s.ContractDone("gld_cooks", 3);
        var json = JsonSerializer.Serialize(s.Save());
        var back = NewStanding(); back.Load(JsonSerializer.Deserialize<GuildsSave>(json));
        Assert.Equal(s.Reputation("gld_cooks"), back.Reputation("gld_cooks"), "reputation");
        Assert.Equal(s.Tier("gld_cooks"), back.Tier("gld_cooks"), "tier");
        Assert.Equal(s.Contracts("gld_cooks"), back.Contracts("gld_cooks"), "contracts");
        Assert.Equal(0, back.Apply("gld_cooks", "contract_completed", 3, 5) > 20 ? 1 : 0, "the daily cap survives a load");
        var older = NewStanding(); older.Load(null);
        Assert.Equal(0, older.Memberships.Count(), "an older save loads with no memberships");
        var junk = NewStanding(); junk.Load(new GuildsSave { Guilds = new Dictionary<string, GuildMemberSave> { ["gld_gone"] = new GuildMemberSave { Tier = 9 }, ["gld_cooks"] = new GuildMemberSave { Tier = 99 } } });
        Assert.Equal(7, junk.Tier("gld_cooks"), "a tier above the player's maximum is clamped");
        Assert.Equal(0, junk.Tier("gld_gone"), "unknown guilds are ignored");
    }

    // ---------- contracts and bounties ----------

    public static void EveryGuildExceptTheMainOneHasContracts()
    {
        var c = ContractData; var g = GuildData;
        foreach (var guild in g.Guilds.Where(x => x.UsesMemberLadder)) Assert.True(c.Templates.Any(t => t.GuildId == guild.Id), guild.Id + " has a template");
        Assert.True(c.Templates.All(t => t.CooldownDays >= 1), "every template has a cooldown");
        Assert.Equal(10, c.Categories.Count, "ten quest categories");
    }

    public static void ContractsNeedRankMembershipTierAndWaitOutTheirCooldown()
    {
        var s = NewStanding(); var board = new GuildContractBoard(ContractData, s);
        var easy = ContractData.Templates.First(x => x.GuildId == "gld_cooks" && x.MinRank == "F");
        var t = ContractData.Templates.First(x => x.GuildId == "gld_cooks" && x.MinRank == "E");
        Assert.Equal(1, easy.MinTier, "an F contract needs only Applicant");
        Assert.Equal(2, t.MinTier, "an E contract needs Initiate");
        Assert.True(board.WhyNot(t, RankLetter.F, 1) != null, "rank too low");
        Assert.Equal("join the guild first", board.WhyNot(easy, RankLetter.F, 1), "not a member");
        s.Join("gld_cooks", RankLetter.F, NoFlags);
        Assert.Equal(null, board.WhyNot(easy, RankLetter.F, 1), "an Applicant may take a basic notice");
        Assert.Equal("needs guild tier 2", board.WhyNot(t, RankLetter.E, 1), "but not an E contract yet");
        Assert.True(board.Complete(easy.Id, RankLetter.F, 1) > 0, "the first notice pays");
        for (int d = 2; s.Reputation("gld_cooks") < 10; d++) s.Apply("gld_cooks", "donation", d, 5);
        Assert.True(s.Promote("gld_cooks", false, false), "Initiate");
        Assert.Equal(null, board.WhyNot(t, RankLetter.E, 1), "now an E contract is open");
        int pay = board.Complete(t.Id, RankLetter.E, 1);
        Assert.True(pay > 0, "it pays");
        Assert.True(board.WhyNot(t, RankLetter.E, 1) != null, "cooldown");
        Assert.Equal(-1, board.Complete(t.Id, RankLetter.E, 1), "no double pay in a day");
        Assert.Equal(null, board.WhyNot(t, RankLetter.E, 1 + t.CooldownDays), "available again after the cooldown");
        Assert.Equal(2, s.Contracts("gld_cooks"), "both counted for the guild");
    }

    public static void RewardsScaleByRankInsideTheTemplateRangeAndNeverRunAway()
    {
        var board = new GuildContractBoard(ContractData, NewStanding());
        var t = ContractData.Templates.First(x => x.GuildId == "gld_mercenaries");
        int atMin = board.Reward(t, Rank.Parse(t.MinRank).Letter);
        int overMax = board.Reward(t, RankLetter.SSS);
        int atMax = board.Reward(t, Rank.Parse(t.MaxRank).Letter);
        Assert.True(atMin > 0 && atMax > atMin, "higher range pays more");
        Assert.Equal(atMax, overMax, "a far higher rank player is paid at the template's top, not more");
    }

    public static void ContractCooldownsSurviveASave()
    {
        var s = NewStanding(); var board = new GuildContractBoard(ContractData, s);
        s.Join("gld_farmers", RankLetter.F, NoFlags);
        var t = ContractData.Templates.First(x => x.GuildId == "gld_farmers");
        board.Complete(t.Id, RankLetter.F, 5);
        var s2 = NewStanding(); var board2 = new GuildContractBoard(ContractData, s2); s2.Join("gld_farmers", RankLetter.F, NoFlags);
        board2.Load(JsonSerializer.Deserialize<ContractsSave>(JsonSerializer.Serialize(board.Save())));
        Assert.True(board2.WhyNot(t, RankLetter.F, 5) != null, "still cooling down after a load");
        board2.Load(null);
        Assert.Equal(null, board2.WhyNot(t, RankLetter.F, 5), "an older save has no cooldowns");
    }

    public static void BountiesSplitByContributionAndNeedTheRightProof()
    {
        var rules = ContractData.Bounty;
        var claim = new List<BountyClaimant> { new BountyClaimant { Id = "a", Share = 0.6 }, new BountyClaimant { Id = "b", Share = 0.3 }, new BountyClaimant { Id = "c", Share = 0.1 } };
        var r = BountyResolver.Resolve(rules, "kill", "core", 1000, claim);
        Assert.True(r.Valid, "valid claim");
        Assert.Equal(1000, r.Payouts.Values.Sum(), "the whole reward is paid out, nothing lost to rounding");
        Assert.True(!r.Payouts.ContainsKey("c"), "10% is under the 15% minimum share");
        Assert.True(r.Payouts["a"] > r.Payouts["b"], "more work, more pay");
        Assert.True(r.Reputation.Contains("a") && r.Reputation.Contains("b") && !r.Reputation.Contains("c"), "reputation to qualifying claimants only");
        Assert.True(!BountyResolver.Resolve(rules, "capture", "core", 1000, claim).Valid, "a core does not prove a capture");
        Assert.True(!BountyResolver.Resolve(rules, "kill", "core", 1000, new List<BountyClaimant> { new BountyClaimant { Id = "x", Share = 0.05 } }).Valid, "nobody did enough");
        Assert.True(!BountyResolver.Resolve(rules, "nope", "core", 1000, claim).Valid, "unknown objective");
    }

    public static void ReviewFixesHoldTheLineOnEdgeInput()
    {
        var late = Lines.SpeciesInLine("evl_goblins").First(sid => Lines.StageOf(sid) == 8);
        Assert.True(!Lines.CheckEvolution(late, "age", new[] { "age", "age" }).Allowed, "the same condition twice counts once");
        Assert.True(!Lines.IsTriggerAllowed("Defeated_Player"), "case does not matter");
        Assert.True(!Lines.IsTriggerAllowed(" defeated_player "), "spaces do not matter");
        Assert.True(!Lines.IsTriggerAllowed(" "), "blank is not a trigger");
        var rules = ContractData.Bounty;
        Assert.True(!BountyResolver.Resolve(rules, "kill", "core", -5, new List<BountyClaimant> { new BountyClaimant { Id = "a", Share = 1 } }).Valid, "negative reward");
        var s = NewStanding(); s.Join("gld_cooks", RankLetter.F, NoFlags);
        Assert.True(s.Apply("gld_cooks", "donation", 1, int.MaxValue) > 0, "a huge donation is capped, not lost");
        Assert.Equal(10, s.Reputation("gld_cooks"), "stops at the donation daily cap");
    }

    // ---------- factions, lairs, grades ----------

    public static void FactionStandingStartsAtTheDefaultAndMovesOnlyByActs()
    {
        var f = new FactionStanding(Repo.Load<FactionFile>("Data/World/faction_relations.json"));
        Assert.Equal("Hostile", f.State("evl_undead"), "undead start hostile");
        Assert.Equal("Wary", f.State("evl_goblins"), "goblins start wary");
        Assert.Equal("Neutral", f.State("evl_dragons"), "dragons start neutral");
        f.Shift("evl_goblins", 70);
        Assert.Equal("Friendly", f.State("evl_goblins"), "a goblin clan comes round");
        Assert.Equal("Wary", f.State("evl_orcs"), "other groups are tracked separately");
        Assert.Equal(100, f.Shift("evl_goblins", 500), "clamped to 100");
        Assert.Equal(0, f.Shift("evl_nonexistent", 5), "unknown line changes nothing");
        var back = new FactionStanding(Repo.Load<FactionFile>("Data/World/faction_relations.json"));
        back.Load(JsonSerializer.Deserialize<FactionSave>(JsonSerializer.Serialize(f.Save())));
        Assert.Equal(f.Points("evl_goblins"), back.Points("evl_goblins"), "round trip");
        back.Load(null);
        Assert.Equal("Wary", back.State("evl_goblins"), "an older save: data defaults");
    }

    public static void LairsAndWorldEventsPointAtRealLinesAndGuilds()
    {
        var lairs = Repo.Load<LairFile>("Data/World/lairs_and_events.json");
        var guilds = GuildData.Guilds.Select(g => g.Id).ToHashSet();
        Assert.Equal(10, lairs.LocationTypes.Count, "ten lair types");
        foreach (var l in lairs.LocationTypes) foreach (var id in l.InhabitantLines) Assert.True(Lines.Line(id) != null, l.Id + " -> " + id);
        foreach (var e in lairs.WorldEvents) { Assert.Equal("region", e.Scope, e.Id + " is region-level (Canon 4d)"); foreach (var g in e.RequestedBy) Assert.True(guilds.Contains(g), e.Id + " -> " + g); }
        Assert.True(lairs.LairsFor("evl_dragons").Any(), "a dragon lair exists");
        Assert.True(lairs.EventsRequestedBy("gld_maritime").Any(), "the maritime guild asks for the Leviathan");
    }

    public static void GradeLabelsAreOnlyDisplayNamesOverItemRarity()
    {
        var g = Repo.Load<GradeFile>("Data/Items/grade_labels.json");
        Assert.Equal(7, g.Grades.Count, "Cracked to Mythic");
        Assert.Equal("Common", g.LabelFor("Common"), "common");
        Assert.Equal("Cracked", g.LabelFor("Common", damaged: true), "damaged");
        Assert.Equal("Refined", g.LabelFor("Uncommon"), "uncommon is Refined");
        Assert.Equal("Legendary", g.LabelFor("Legendary"), "legendary");
        Assert.Equal("Mythic", g.LabelFor("Legendary", worldScale: true), "world-scale");
        var rarities = new HashSet<string>(Repo.Db.Items.Values.Select(i => i.Rarity).Where(r => !string.IsNullOrEmpty(r)));
        foreach (var r in rarities) Assert.True(g.LabelFor(r) != null, "every item rarity has a label: " + r);
    }

    // ---------- saves ----------

    public static void AnOldSaveGainsGuildContractAndFactionFieldsAndEverythingRoundTrips()
    {
        var opts = new JsonSerializerOptions { PropertyNameCaseInsensitive = true, Converters = { new JsonStringEnumConverter() } };
        var s = SaveRules.Upgrade(JsonSerializer.Deserialize<SaveGame>("{\"Version\":1,\"Level\":5,\"Copper\":10}", opts));
        Assert.True(s.Guilds != null && s.Contracts != null && s.Factions != null, "Upgrade fills the new fields");
        Assert.Equal(0, SaveRules.Validate(s).Count, "still valid");
        var st = NewStanding(); st.Join("gld_cooks", RankLetter.F, NoFlags); st.ContractDone("gld_cooks", 2);
        var f = new FactionStanding(Repo.Load<FactionFile>("Data/World/faction_relations.json")); f.Shift("evl_orcs", 30);
        s.Guilds = st.Save(); s.Factions = f.Save();
        var back = SaveRules.Upgrade(JsonSerializer.Deserialize<SaveGame>(JsonSerializer.Serialize(s, opts), opts));
        var st2 = NewStanding(); st2.Load(back.Guilds);
        Assert.Equal(1, st2.Contracts("gld_cooks"), "guild state in the save");
        var f2 = new FactionStanding(Repo.Load<FactionFile>("Data/World/faction_relations.json")); f2.Load(back.Factions);
        Assert.Equal(f.Points("evl_orcs"), f2.Points("evl_orcs"), "faction state in the save");
    }
}
