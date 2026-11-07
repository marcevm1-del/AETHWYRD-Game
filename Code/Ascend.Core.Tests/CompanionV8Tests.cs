using System.Collections.Generic;
using System.Linq;
using Ascend.Core;

// Companion v8: roster data, command presets, retreat, revive and the downed outcome.
[Tests]
static class CompanionV8Tests
{
    static readonly string[] Ids = { "cmp_lyra", "cmp_seraphine", "cmp_kiri", "cmp_aldric", "cmp_nyx", "cmp_bram", "cmp_kaito", "cmp_mochi", "cmp_elira", "cmp_vexmor", "cmp_torvald", "cmp_suzune", "cmp_tobin", "cmp_elsie" };
    static readonly string[] Romanceable = { "cmp_lyra", "cmp_seraphine", "cmp_kiri", "cmp_aldric", "cmp_bram", "cmp_kaito", "cmp_elira", "cmp_vexmor", "cmp_torvald", "cmp_suzune", "cmp_tobin", "cmp_elsie" };

    static List<CompanionData> Roster() => Repo.Load<List<CompanionData>>("Data/Companions/companions.json");
    static CompanionRules Rules() => Repo.Load<CompanionRules>("Data/Companions/companion_rules.json");
    static CompanionTuning T => Repo.Db.World.Companions;
    static CompanionSense Calm => new CompanionSense { DistanceToPlayer = 3, DodgeReady = true };
    static CompanionSense Fight { get { var s = Calm; s.InCombat = true; s.EnemyInLeash = true; return s; } }
    static PresetTuning Balanced => Rules().Preset(CompanionPreset.Balanced);

    public static void RosterHasTheFourteenCanonIds()
    {
        var ids = Roster().Select(r => r.Id).ToArray();
        Assert.Equal(14, ids.Length, "row count");
        foreach (var id in Ids) Assert.True(ids.Contains(id), "missing " + id);
        Assert.Equal(14, ids.Distinct().Count(), "ids unique");
    }

    public static void RomanceFlagsMatchCanon()
    {
        foreach (var r in Roster())
        {
            Assert.Equal(Romanceable.Contains(r.Id), r.Romanceable, r.Id + " romanceable");
            if (r.Romanceable) Assert.True(r.Adult, r.Id + " romanceable means adult");
        }
        Assert.Equal(12, Roster().Count(r => r.Romanceable), "twelve romanceable");
    }

    public static void NyxAndMochiAreNeverRomanceableRideableOrFullyKitted()
    {
        foreach (var r in Roster()) Assert.True(!r.Rideable, r.Id + " is never rideable");
        foreach (var id in new[] { "cmp_nyx", "cmp_mochi" })
        {
            var r = Roster().First(x => x.Id == id);
            Assert.True(!r.Romanceable, id + " not romanceable");
            Assert.True(r.EquipmentSlots.Count < 4, id + " has a reduced equipment set");
            Assert.True(!r.EquipmentSlots.Any(s => s.Contains("mount") || s.Contains("saddle")), id + " has no saddle slot");
        }
    }

    public static void StubsAndRedeemableArc()
    {
        var all = Roster();
        Assert.True(all.First(r => r.Id == "cmp_tobin").Stub && all.First(r => r.Id == "cmp_elsie").Stub, "Tobin and Elsie are stubs");
        Assert.Equal(2, all.Count(r => r.Stub), "only two stubs");
        Assert.Equal(2, all.Count(r => r.Kind == "childhoodFriend"), "two childhood friends");
        Assert.Equal("cmp_kaito", all.Single(r => r.RedeemableArc).Id, "only Kaito has a redeemable arc");
    }

    public static void BalancedPresetIsIdentity()
    {
        var b = Balanced;
        Assert.Near(1.0, b.LeashMult, 1e-9, "leash"); Assert.Near(1.0, b.FollowDistanceMult, 1e-9, "follow");
        Assert.Near(1.0, b.RetreatHpMult, 1e-9, "retreat"); Assert.Near(1.0, b.ReviveEagerness, 1e-9, "revive");
        Assert.Near(1.0, b.AssistBias, 1e-9, "assist"); Assert.Near(1.0, b.SkillCostCaution, 1e-9, "caution");
        var t = CompanionPresetBrain.ApplyPreset(T, b);
        Assert.Near(T.Leash, t.Leash, 1e-9, "leash unchanged"); Assert.Near(T.FollowDistance, t.FollowDistance, 1e-9, "follow unchanged");
        Assert.Near(T.AssistPower, t.AssistPower, 1e-9, "assist unchanged");
    }

    public static void AggressiveLeashBeatsDefensiveAndInputIsNotMutated()
    {
        var rules = Rules();
        double before = T.Leash;
        var agg = CompanionPresetBrain.ApplyPreset(T, rules, CompanionPreset.Aggressive);
        var def = CompanionPresetBrain.ApplyPreset(T, rules, CompanionPreset.Defensive);
        Assert.True(agg.Leash > T.Leash && T.Leash > def.Leash, "aggressive > balanced > defensive leash");
        Assert.Near(before, T.Leash, 1e-9, "source tuning untouched");
        Assert.True(agg.AssistPower > def.AssistPower, "aggressive favours the assist");
    }

    public static void PresetDefaultOrdersAreExistingOrders()
    {
        var rules = Rules();
        Assert.True(rules.Preset(CompanionPreset.Aggressive).Order == CompanionOrder.Focus, "aggressive focuses");
        Assert.True(rules.Preset(CompanionPreset.Defensive).Order == CompanionOrder.Hold, "defensive holds");
        Assert.True(rules.Preset(CompanionPreset.Supportive).Order == CompanionOrder.Assist, "supportive assists");
        Assert.True(rules.Preset(CompanionPreset.Balanced).Order == CompanionOrder.Follow, "balanced follows");
        foreach (var r in Roster()) Assert.True(rules.Presets.ContainsKey(r.PresetDefault), r.Id + " preset exists in rules");
    }

    public static void CommandTableMapsOntoExistingOrders()
    {
        Assert.True(CompanionCommands.Map(CompanionCommand.Follow).Order == CompanionOrder.Follow, "follow");
        Assert.True(CompanionCommands.Map(CompanionCommand.HoldPosition).Order == CompanionOrder.Hold, "hold");
        Assert.True(CompanionCommands.Map(CompanionCommand.Attack).Order == CompanionOrder.Focus, "attack = focus");
        var d = CompanionCommands.Map(CompanionCommand.Defend);
        Assert.True(d.Order == CompanionOrder.Hold && d.HoldAtPlayer, "defend = hold at the player");
        Assert.True(CompanionCommands.Map(CompanionCommand.Assist).Order == CompanionOrder.Assist, "assist");
        Assert.True(CompanionCommands.Map(CompanionCommand.Retreat).Retreat, "retreat flag");
        Assert.True(CompanionCommands.Map(CompanionCommand.Interact).Interact, "interact flag");
    }

    public static void PresetBrainMatchesLegacyBrainWhenHealthy()
    {
        var rules = Rules();
        var orders = new[] { CompanionOrder.Follow, CompanionOrder.Hold, CompanionOrder.Focus, CompanionOrder.Assist };
        foreach (var o in orders)
            foreach (bool enemy in new[] { false, true })
                foreach (bool stagger in new[] { false, true })
                    foreach (double dist in new[] { 3.0, 40.0 })
                    {
                        var s = Calm; s.Order = o; s.EnemyInLeash = enemy; s.InCombat = enemy; s.StaggeredEnemyNear = stagger; s.DistanceToPlayer = dist; s.PlayerTargetAlive = true;
                        Assert.True(CompanionBrain.Decide(s, T) == CompanionPresetBrain.Decide(s, T, Balanced, 1.0, false, false, rules), $"order {o} enemy {enemy} stagger {stagger} dist {dist}");
                    }
    }

    public static void RetreatTriggersBelowThresholdOnly()
    {
        var rules = Rules(); var p = Balanced;
        Assert.True(CompanionPresetBrain.Decide(Fight, T, p, 0.20, false, false, rules) == CompanionAction.Retreat, "20% hp in a fight retreats");
        Assert.True(CompanionPresetBrain.Decide(Fight, T, p, 0.60, false, false, rules) == CompanionAction.Attack, "60% hp keeps fighting");
        Assert.True(CompanionPresetBrain.Decide(Calm, T, p, 0.10, false, false, rules) == CompanionAction.Follow, "no fight: nothing to retreat from");
    }

    public static void RetreatHasHysteresis()
    {
        var rules = Rules(); var p = Balanced;
        var ctx = new CompanionContext();
        Assert.True(CompanionPresetBrain.Decide(Fight, T, p, 0.30, false, false, rules, ctx) == CompanionAction.Attack, "30% is above the 25% enter line");
        ctx.WasRetreating = true;
        Assert.True(CompanionPresetBrain.Decide(Fight, T, p, 0.30, false, false, rules, ctx) == CompanionAction.Retreat, "already retreating: keeps going at 30%");
        Assert.True(CompanionPresetBrain.Decide(Fight, T, p, 0.45, false, false, rules, ctx) == CompanionAction.Retreat, "still below the 50% recover line");
        Assert.True(CompanionPresetBrain.Decide(Fight, T, p, 0.50, false, false, rules, ctx) == CompanionAction.Attack, "recovered: back in");
    }

    public static void PresetsAndMortalBondsMoveTheRetreatLine()
    {
        var rules = Rules(); var r = rules.Retreat;
        double agg = CompanionPresetBrain.RetreatEnter(rules.Preset(CompanionPreset.Aggressive), r, false);
        double bal = CompanionPresetBrain.RetreatEnter(Balanced, r, false);
        double def = CompanionPresetBrain.RetreatEnter(rules.Preset(CompanionPreset.Defensive), r, false);
        Assert.True(agg < bal && bal < def, "aggressive fights on longest, defensive retreats first");
        Assert.True(CompanionPresetBrain.RetreatEnter(Balanced, r, true) > bal, "mortal bonds retreats earlier");
    }

    public static void NoRetreatWhilePlayerDownedWithoutSafePath()
    {
        var rules = Rules();
        var ctx = new CompanionContext { SafeRetreatPath = false, EnemyEngagingMe = true };
        var s = Fight; s.DistanceToPlayer = 8;
        Assert.True(CompanionPresetBrain.Decide(s, T, Balanced, 0.10, true, false, rules, ctx) != CompanionAction.Retreat, "no safe path and the player is down: stay");
        ctx.SafeRetreatPath = true;
        Assert.True(CompanionPresetBrain.Decide(s, T, Balanced, 0.10, true, false, rules, ctx) == CompanionAction.Retreat, "safe path: may retreat");
    }

    public static void ReviveWhenPlayerDownedInRangeAndSafe()
    {
        var rules = Rules();
        var s = Calm; s.DistanceToPlayer = 2.0;
        Assert.True(CompanionPresetBrain.Decide(s, T, Balanced, 1.0, true, false, rules) == CompanionAction.Revive, "in range, safe: revive");
        s.DistanceToPlayer = 6.0;
        Assert.True(CompanionPresetBrain.Decide(s, T, Balanced, 1.0, true, false, rules) != CompanionAction.Revive, "out of range: not yet");
        s.DistanceToPlayer = 2.0;
        Assert.True(CompanionPresetBrain.Decide(s, T, Balanced, 1.0, false, false, rules) != CompanionAction.Revive, "nobody down: no revive");
        var cd = new CompanionContext { SecSinceLastRevive = 1 };
        Assert.True(CompanionPresetBrain.Decide(s, T, Balanced, 1.0, true, false, rules, cd) != CompanionAction.Revive, "on cooldown");
    }

    public static void ReviveIsNotAttemptedUnderInterruptingThreat()
    {
        var rules = Rules();
        var s = Calm; s.DistanceToPlayer = 2.0; s.ThreatWindingUpNearMe = true;
        Assert.True(CompanionPresetBrain.Decide(s, T, Balanced, 1.0, true, false, rules) == CompanionAction.Dodge, "wind-up: dodge first");
        s.DodgeReady = false;
        Assert.True(CompanionPresetBrain.Decide(s, T, Balanced, 1.0, true, false, rules) != CompanionAction.Revive, "wind-up and no dodge: do not start an interruptible revive");
        s.ThreatWindingUpNearMe = false;
        var engaged = new CompanionContext { EnemyEngagingMe = true };
        Assert.True(CompanionPresetBrain.Decide(s, T, Balanced, 1.0, true, false, rules, engaged) != CompanionAction.Revive, "enemy on me: not safe");
        rules.Revive.Interruptible = false;
        Assert.True(CompanionPresetBrain.Decide(s, T, Balanced, 1.0, true, false, rules, engaged) == CompanionAction.Revive, "uninterruptible revive ignores pressure");
    }

    public static void SupportiveRevivesFartherThanAggressive()
    {
        var rules = Rules(); var s = Calm; s.DistanceToPlayer = 3.5;
        Assert.True(CompanionPresetBrain.CanRevive(s, rules.Preset(CompanionPreset.Supportive), rules.Revive, new CompanionContext()), "supportive reaches 3.5 m");
        Assert.True(!CompanionPresetBrain.CanRevive(s, rules.Preset(CompanionPreset.Aggressive), rules.Revive, new CompanionContext()), "aggressive does not");
    }

    public static void InteractOnlyWhenNothingIsFighting()
    {
        var rules = Rules(); var ctx = new CompanionContext { InteractRequested = true };
        Assert.True(CompanionPresetBrain.Decide(Calm, T, Balanced, 1.0, false, false, rules, ctx) == CompanionAction.Interact, "calm: interact");
        Assert.True(CompanionPresetBrain.Decide(Fight, T, Balanced, 1.0, false, false, rules, ctx) == CompanionAction.Attack, "fighting: interact waits");
    }

    public static void DefaultSettingsNeverProduceDead()
    {
        var t = T;
        foreach (bool lethal in new[] { false, true })
            foreach (bool revived in new[] { false, true })
                foreach (double sec in new[] { 0.0, 5.0, 20.0, 600.0, 1e9 })
                    Assert.True(CompanionPresetBrain.DownedOutcome(false, lethal, revived, sec, t) != DownedResult.Dead, $"default: lethal {lethal} revived {revived} sec {sec}");
        Assert.True(CompanionPresetBrain.DownedOutcome(false, true, false, 1, t) == DownedResult.GravelyWounded, "lethal blow without mortal bonds: gravely wounded");
        Assert.True(CompanionPresetBrain.DownedOutcome(false, false, false, 5, t) == DownedResult.StillDowned, "still waiting");
    }

    public static void MortalBondsKillsOnlyOnTheExplicitLethalBlow()
    {
        var t = T;
        Assert.True(CompanionPresetBrain.DownedOutcome(true, true, false, 1, t) == DownedResult.Dead, "lethal blow while downed, not revived: dead");
        Assert.True(CompanionPresetBrain.DownedOutcome(true, true, true, 1, t) == DownedResult.Revived, "revived beats the blow");
        foreach (double sec in new[] { 0.0, 20.0, 600.0, 1e9 })
            Assert.True(CompanionPresetBrain.DownedOutcome(true, false, false, sec, t) != DownedResult.Dead, "a timer never kills, even with mortal bonds");
        Assert.True(CompanionPresetBrain.DownedOutcome(true, false, false, 20.0, t) == DownedResult.GravelyWounded, "timer out: gravely wounded");
    }

    public static void MissingRulesSectionsKeepDefaults()
    {
        var empty = System.Text.Json.JsonSerializer.Deserialize<CompanionRules>("{\"version\":1}", new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        var shipped = Rules();
        Assert.Near(shipped.Retreat.LowHpFraction, empty.Retreat.LowHpFraction, 1e-9, "retreat default = shipped");
        Assert.Near(shipped.Revive.ReviveRangeM, empty.Revive.ReviveRangeM, 1e-9, "revive default = shipped");
        Assert.Near(shipped.Downed.GravelyWoundedRecoverySec, empty.Downed.GravelyWoundedRecoverySec, 1e-9, "downed default = shipped");
        Assert.True(!empty.Downed.MortalBonds.DefaultEnabled, "mortal bonds off by default");
        var p = empty.Preset(CompanionPreset.Aggressive);
        Assert.Near(1.0, p.LeashMult, 1e-9, "unlisted preset is the identity");
        // and the brain still runs with a half-empty file
        var s = Calm; s.DistanceToPlayer = 2.0;
        Assert.True(CompanionPresetBrain.Decide(s, T, p, 1.0, true, false, empty) == CompanionAction.Revive, "defaults still revive");
    }
}
