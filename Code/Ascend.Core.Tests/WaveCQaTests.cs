using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using Ascend.Core;

// Wave C adversarial QA: boundaries, combined cases, data hygiene, old/empty configs, anti-farming.
[Tests]
static class WaveCQaTests
{
    static readonly JsonSerializerOptions Opts = new() { PropertyNameCaseInsensitive = true };
    static CompanionRules Rules() => Repo.Load<CompanionRules>("Data/Companions/companion_rules.json");
    static string Text(string rel) => File.ReadAllText(Path.Combine(Repo.Root(), rel));
    static List<JsonElement> Banter() => JsonDocument.Parse(Text("Data/Companions/banter.json")).RootElement.EnumerateArray().Select(e => e.Clone()).ToList();

    public static void RetreatThresholdIsStrictlyBelow()
    {
        var r = new RetreatTuning(); var p = new PresetTuning();
        Assert.True(!CompanionPresetBrain.ShouldRetreat(0.25, false, p, r, false), "hp exactly at enter does not start a retreat");
        Assert.True(CompanionPresetBrain.ShouldRetreat(0.2499, false, p, r, false), "just below starts it");
        Assert.True(!CompanionPresetBrain.ShouldRetreat(0.5, true, p, r, false), "exactly at the recover fraction ends it");
        Assert.True(CompanionPresetBrain.ShouldRetreat(0.4999, true, p, r, false), "just below recover keeps it");
    }

    public static void RetreatEnterIsCappedAndMortalBondsRaisesIt()
    {
        var r = new RetreatTuning();
        Assert.Equal(0.95, CompanionPresetBrain.RetreatEnter(new PresetTuning { RetreatHpMult = 100 }, r, true), "cap 0.95");
        Assert.True(!CompanionPresetBrain.ShouldRetreat(0.95, false, new PresetTuning { RetreatHpMult = 100 }, r, false), "never retreats at exactly the cap");
        Assert.True(CompanionPresetBrain.RetreatEnter(new PresetTuning(), r, true) > CompanionPresetBrain.RetreatEnter(new PresetTuning(), r, false), "mortal bonds retreats earlier");
    }

    public static void PresetMortalBondsAndDownedCombine()
    {
        var rules = Rules(); var t = new CompanionTuning();
        var def = rules.Preset(CompanionPreset.Defensive);
        var fight = new CompanionSense { InCombat = true, EnemyInLeash = true, DistanceToPlayer = 5, Order = CompanionOrder.Follow };
        // hp 0.4: Defensive (0.25*1.3) with mortal bonds (x1.25) = 0.40625 > 0.4 -> retreat; without bonds 0.325 -> no.
        Assert.Equal(CompanionAction.Retreat, CompanionPresetBrain.Decide(fight, t, def, 0.4, false, true, rules), "defensive+bonds retreats at 0.4");
        Assert.True(CompanionPresetBrain.Decide(fight, t, def, 0.4, false, false, rules) != CompanionAction.Retreat, "no bonds: still fighting at 0.4");
        // player downed, no safe path, low hp: cannot retreat (and cannot revive across the room)
        var far = fight; far.DistanceToPlayer = 8;
        var noPath = new CompanionContext { SafeRetreatPath = false };
        Assert.True(CompanionPresetBrain.Decide(far, t, def, 0.1, true, true, rules, noPath) != CompanionAction.Retreat, "no safe path while player downed: no retreat");
        // in range, safe: revive wins over retreat
        var near = fight; near.DistanceToPlayer = 2;
        Assert.Equal(CompanionAction.Revive, CompanionPresetBrain.Decide(near, t, def, 0.1, true, true, rules), "revive outranks retreat");
        // downed companion always Downed whatever else is going on
        near.Downed = true;
        Assert.Equal(CompanionAction.Downed, CompanionPresetBrain.Decide(near, t, def, 0.1, true, true, rules, new CompanionContext { RetreatCommanded = true, InteractRequested = true }), "downed wins");
    }

    public static void ReviveRangeIsInclusiveAndCooldownIsExact()
    {
        var v = new ReviveTuning(); var p = new PresetTuning();
        var s = new CompanionSense { DistanceToPlayer = 3.0 };
        Assert.True(CompanionPresetBrain.CanRevive(s, p, v, new CompanionContext()), "exactly at range is allowed");
        s.DistanceToPlayer = 3.0001;
        Assert.True(!CompanionPresetBrain.CanRevive(s, p, v, new CompanionContext()), "just outside is not");
        s.DistanceToPlayer = 1;
        Assert.True(!CompanionPresetBrain.CanRevive(s, p, v, new CompanionContext { SecSinceLastRevive = 7.99 }), "cooldown not over");
        Assert.True(CompanionPresetBrain.CanRevive(s, p, v, new CompanionContext { SecSinceLastRevive = 8 }), "cooldown over at exactly 8");
    }

    public static void CompanionDeathNeedsMortalBondsAndALethalBlow()
    {
        var t = new CompanionTuning();
        foreach (var bonds in new[] { false, true })
            foreach (var secs in new[] { 0.0, 19.99, 20.0, 1e9 })
                Assert.True(CompanionPresetBrain.DownedOutcome(bonds, false, false, secs, t) != DownedResult.Dead, "timer can never kill");
        Assert.Equal(DownedResult.GravelyWounded, CompanionPresetBrain.DownedOutcome(false, true, false, 1, t), "lethal blow without bonds");
        Assert.Equal(DownedResult.Dead, CompanionPresetBrain.DownedOutcome(true, true, false, 1, t), "lethal blow with bonds");
        Assert.Equal(DownedResult.Revived, CompanionPresetBrain.DownedOutcome(true, true, true, 1, t), "revive beats the blow");
        Assert.Equal(DownedResult.StillDowned, CompanionPresetBrain.DownedOutcome(true, false, false, 19.99, t), "still downed just before the timer");
        Assert.Equal(DownedResult.GravelyWounded, CompanionPresetBrain.DownedOutcome(true, false, false, 20.0, t), "wounded exactly at the timer");
    }

    public static void MountStaminaExhaustedBoundaryAndHysteresis()
    {
        var fam = new MountFamily { Stamina = new MountStamina { Max = 10, SprintDrainPerSec = 5, RegenPerSec = 1, ExhaustedBelow = 5, RecoverTo = 8 } };
        var m = new MountState(fam); m.Mount();
        m.StepStamina(0.5, true);                      // 10 -> 7.5
        Assert.True(!m.Exhausted, "7.5 is fine");
        m.StepStamina(0.5, true);                      // 7.5 -> 5.0 exactly
        Assert.Equal(5.0, m.Stamina, "stamina exactly at threshold");
        Assert.True(m.Exhausted, "exactly at exhaustedBelow counts as exhausted");
        Assert.True(!m.StepStamina(1, true), "no sprint while exhausted");
        Assert.True(m.Exhausted, "6 still exhausted (hysteresis)");
        m.StepStamina(1, false); m.StepStamina(1, false);   // 8 exactly
        Assert.True(!m.Exhausted, "exactly recoverTo clears it");
        var m2 = new MountState(fam); m2.Mount();
        m2.StepStamina(0.999, true);
        m2.StepStamina(0.001, false);
        Assert.True(!m2.Exhausted, "just above threshold is not exhausted");
    }

    public static void BanterRowsAreClean()
    {
        var ids = Repo.Load<List<CompanionData>>("Data/Companions/companions.json").Select(c => c.Id).ToHashSet();
        var forbidden = new Regex(@"Vex|Azrael|Red Prophet|Nocturne", RegexOptions.IgnoreCase);
        var romance = new Regex(@"\b(love|loves|loved|kiss|kisses|darling|sweetheart|romance|romantic|beloved|marry|flirt|handsome|date|dating|sexy)\b", RegexOptions.IgnoreCase);
        var seen = new HashSet<string>();
        foreach (var b in Banter())
        {
            string id = b.GetProperty("id").GetString(), cid = b.GetProperty("companionId").GetString(), line = b.GetProperty("line").GetString(), trig = b.GetProperty("trigger").GetString();
            Assert.True(seen.Add(id), "duplicate banter id " + id);
            Assert.True(ids.Contains(cid), id + ": unknown companionId " + cid);
            Assert.True(!string.IsNullOrWhiteSpace(line) && line.Length <= 160, id + ": line empty or over 160 chars");
            Assert.True(!forbidden.IsMatch(line), id + ": mentions a forbidden secret");
            if (cid == "cmp_nyx" || cid == "cmp_mochi")
            {
                Assert.True(!romance.IsMatch(line), id + ": romance wording on a never-romance companion");
                if (cid == "cmp_nyx") Assert.True(trig != "mounted", id + ": Nyx has a mounted line");
            }
        }
    }

    public static void RosterHasFourteenUniqueNonRideableCompanions()
    {
        var roster = Repo.Load<List<CompanionData>>("Data/Companions/companions.json");
        Assert.Equal(14, roster.Count, "roster size");
        Assert.Equal(14, roster.Select(c => c.Id).Distinct().Count(), "unique ids");
        Assert.True(roster.All(c => !c.Rideable), "no companion is rideable");
        foreach (var id in RelationshipRules.NeverRomance)
        {
            var row = roster.First(c => c.Id == id);
            var s = new RelationshipState { Trust = 100, Closeness = 100, RomanceOptIn = true };
            Assert.True(!new RelationshipRules().CanRomance(row, s), id + " can be romanced");
            row.Romanceable = true; row.Adult = true;
            Assert.True(!new RelationshipRules().CanRomance(row, s), id + " can be romanced even when the row is edited");
        }
    }

    public static void MountsDataHasNoAirOrWaterWordsOutsideNotes()
    {
        var doc = JsonDocument.Parse(Text("Data/Companions/mounts.json"));
        var banned = new Regex("fly|flying|aerial|celestial|dragon|aquatic|wyvern|griffin|pegasus", RegexOptions.IgnoreCase);
        foreach (var prop in doc.RootElement.EnumerateObject().Where(p => p.Name != "notes" && p.Name != "mountedCombat"))   // notes and the banned-tag list legitimately name the banned words
            Assert.True(!banned.IsMatch(prop.Value.GetRawText()), "mounts.json property " + prop.Name + " contains a banned word");
        Repo.Load<MountTable>("Data/Companions/mounts.json").AssertGroundOnly();
    }

    public static void EmptyOrOldJsonLoadsAndStillWorks()
    {
        var rules = JsonSerializer.Deserialize<CompanionRules>("{}", Opts);
        var mounts = JsonSerializer.Deserialize<MountTable>("{}", Opts);
        var rel = JsonSerializer.Deserialize<RelationshipRules>("{}", Opts);
        var a = CompanionPresetBrain.Decide(new CompanionSense { EnemyInLeash = true, DistanceToPlayer = 2 }, new CompanionTuning(), rules.Preset(CompanionPreset.Aggressive), 0.9, false, false, rules);
        Assert.Equal(CompanionAction.Attack, a, "empty rules decide");
        Assert.Equal(0.0, mounts.Speed("horse"), "empty mounts: unknown family is 0");
        Assert.True(!mounts.CanMount("horse", "S"), "empty mounts: nothing rideable");
        Assert.Equal(10, rel.NewState().Trust, "empty relationship rules use default start");
        Assert.True(rel.Apply(rel.NewState(), "kept_promise", 1) == RelationApplyResult.UnknownEvent, "no events in an empty config");
        Assert.True(RelationshipState.FromSave(null, rel, "cmp_kaito").Availability == CompanionAvailability.Rival, "null save gives Kaito rival");
    }

    public static void RelationshipEventsCannotBeFarmed()
    {
        var r = Repo.Load<CompanionRules>("Data/Companions/companion_rules.json").Relationships;
        foreach (var key in r.Events.Keys)
        {
            var s = r.NewState(); var one = r.NewState();
            r.Apply(one, key, 10);
            int applied = 0;
            for (int i = 0; i < 500; i++) if (r.Apply(s, key, 10) == RelationApplyResult.Applied) applied++;
            Assert.Equal(1, applied, key + " applied more than once on one day");
            foreach (var t in new[] { RelationTrack.Trust, RelationTrack.Respect, RelationTrack.Closeness, RelationTrack.Tension })
                Assert.Equal(one.Get(t), s.Get(t), key + " drifted on " + t);
        }
        // cooldown event: exactly at the cooldown it applies again, one day earlier it does not
        var c = r.NewState();
        Assert.Equal(RelationApplyResult.Applied, r.Apply(c, "kept_promise", 5), "first");
        Assert.Equal(RelationApplyResult.OnCooldown, r.Apply(c, "kept_promise", 7), "day 2 of 3");
        Assert.Equal(RelationApplyResult.Applied, r.Apply(c, "kept_promise", 8), "cooldown over");
        // a once event stays blocked on any later day
        Assert.Equal(RelationApplyResult.Applied, r.Apply(c, "confided_secret", 1), "once first");
        Assert.Equal(RelationApplyResult.OnceAlreadySeen, r.Apply(c, "confided_secret", 9999), "once forever");
    }
}
