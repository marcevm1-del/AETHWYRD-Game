using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Ascend.Core;

// Companion relationships: four separate tracks, romance gate, departure, anti-farming, save defaults.
[Tests]
static class RelationshipTests
{
    static List<CompanionData> Roster() => Repo.Load<List<CompanionData>>("Data/Companions/companions.json");
    static RelationshipRules R() => Repo.Load<CompanionRules>("Data/Companions/companion_rules.json").Relationships;
    static CompanionData Row(string id) => Roster().First(r => r.Id == id);

    static RelationshipState Maxed(RelationshipRules r)
    {
        var s = r.NewState();
        s.Trust = 100; s.Respect = 100; s.Closeness = 100; s.Tension = 0; s.RomanceOptIn = true;
        return s;
    }

    public static void RulesLoadFromDataWithFourTracks()
    {
        var r = R();
        foreach (var t in new[] { "trust", "respect", "closeness", "tension" }) Assert.True(r.Tracks.ContainsKey(t), "track " + t);
        Assert.Equal(4, r.Tracks.Count, "exactly four tracks");
        Assert.True(r.Events.Count >= 8, "events loaded");
        Assert.Equal(r.Track(RelationTrack.Closeness).StageId(0), "stranger", "closeness starts as stranger");
        Assert.Equal(r.Track(RelationTrack.Closeness).StageId(80), "close", "closeness top stage");
    }

    public static void NoCombinedNumberExists()
    {
        var banned = new[] { "Loyalty", "Approval", "Affinity", "Score" };
        foreach (var type in new[] { typeof(RelationshipState), typeof(RelationshipRules), typeof(CompanionBondSave), typeof(RelationEventData) })
            foreach (var p in type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static))
                foreach (var b in banned) Assert.True(!p.Name.Contains(b), type.Name + "." + p.Name + " must not be a combined number");
    }

    public static void AnEventOnlyMovesTheTracksItNames()
    {
        var r = R();
        var s = r.NewState();
        int tr = s.Trust, rs = s.Respect, cl = s.Closeness, tn = s.Tension;
        Assert.Equal(RelationApplyResult.Applied, r.Apply(s, "shared_meal", 1), "applied");   // closeness only
        Assert.Equal(tr, s.Trust, "trust untouched");
        Assert.Equal(rs, s.Respect, "respect untouched");
        Assert.Equal(tn, s.Tension, "tension untouched");
        Assert.True(s.Closeness > cl, "closeness moved");
    }

    public static void EveryDataEventStaysInsideTheCap()
    {
        var r = R();
        foreach (var kv in r.Events)
            foreach (var d in kv.Value.Deltas) Assert.True(System.Math.Abs(d.Value) <= r.MaxDeltaPerEvent, kv.Key + "." + d.Key + " within cap");
    }

    public static void OversizedDeltaIsCappedAndTracksStayInRange()
    {
        var r = new RelationshipRules { MaxDeltaPerEvent = 5 };
        r.Events["big"] = new RelationEventData { Deltas = new Dictionary<string, int> { ["trust"] = 50, ["tension"] = -50 }, CooldownDays = 1 };
        var s = r.NewState();
        s.Tension = 3;
        r.Apply(s, "big", 1);
        Assert.Equal(15, s.Trust, "start 10 plus capped 5");
        Assert.Equal(0, s.Tension, "floored at 0");
        s.Trust = 98;
        r.Apply(s, "big", 5);
        Assert.Equal(100, s.Trust, "ceiling 100");
    }

    public static void OnceOnlyEventsCannotBeFarmed()
    {
        var r = R();
        var s = r.NewState();
        Assert.Equal(RelationApplyResult.Applied, r.Apply(s, "confided_secret", 1), "first time");
        int t = s.Trust, c = s.Closeness;
        for (int d = 2; d < 40; d++) Assert.Equal(RelationApplyResult.OnceAlreadySeen, r.Apply(s, "confided_secret", d), "repeat blocked");
        Assert.Equal(t, s.Trust, "trust unchanged");
        Assert.Equal(c, s.Closeness, "closeness unchanged");
    }

    public static void CooldownEventsCannotBeSpammedButWorkAgainLater()
    {
        var r = R();
        var s = r.NewState();
        Assert.Equal(RelationApplyResult.Applied, r.Apply(s, "kept_promise", 10), "first");
        int t = s.Trust;
        Assert.Equal(RelationApplyResult.OnCooldown, r.Apply(s, "kept_promise", 10), "same day");
        Assert.Equal(RelationApplyResult.OnCooldown, r.Apply(s, "kept_promise", 11), "inside cooldown");
        Assert.Equal(t, s.Trust, "no points while blocked");
        Assert.Equal(RelationApplyResult.Applied, r.Apply(s, "kept_promise", 10 + r.Events["kept_promise"].CooldownDays), "after cooldown");
    }

    public static void RepeatedBanterAndUnknownEventsGiveNoPoints()
    {
        var r = R();
        var s = r.NewState();
        var snap = s.ToSave("cmp_lyra");
        for (int i = 0; i < 50; i++) Assert.Equal(RelationApplyResult.UnknownEvent, r.Apply(s, "banter_bnt_lyra_001", i), "banter is not an event");
        var after = s.ToSave("cmp_lyra");
        Assert.Equal(snap.Trust + "," + snap.Respect + "," + snap.Closeness + "," + snap.Tension, after.Trust + "," + after.Respect + "," + after.Closeness + "," + after.Tension, "tracks unchanged");
    }

    public static void EveryDataEventCanBeFarmedNoWayToLoopForever()
    {
        var r = R();
        foreach (var kv in r.Events) Assert.True(kv.Value.Once || kv.Value.CooldownDays > 0, kv.Key + " needs once or a cooldown");
    }

    public static void RomanceGateIsFalseForEveryNonRomanceableCompanionAtMaxStats()
    {
        var r = R();
        var bad = Roster().Where(c => !c.Romanceable).ToList();
        Assert.True(bad.Count >= 2, "Nyx and Mochi are in the real roster as non-romanceable");
        foreach (var c in bad) Assert.True(!r.CanRomance(c, Maxed(r)), c.Id + " cannot be romanced");
        foreach (var id in new[] { "cmp_nyx", "cmp_mochi" })
        {
            var forged = Row(id);
            forged.Romanceable = true; forged.Adult = true;   // even a corrupted row cannot open the gate
            Assert.True(!r.CanRomance(forged, Maxed(r)), id + " blocked even if the data lied");
        }
    }

    public static void RomanceGateOpensForARomanceableAdultWhenAllConditionsMet()
    {
        var r = R();
        var lyra = Row("cmp_lyra");
        var s = r.NewState();
        s.Trust = 55; s.Closeness = 55; s.Tension = 10; s.RomanceOptIn = true;
        Assert.True(r.CanRomance(lyra, s), "all conditions met");
        s.RomanceOptIn = false; Assert.True(!r.CanRomance(lyra, s), "needs opt-in");
        s.RomanceOptIn = true; s.Closeness = 40; Assert.True(!r.CanRomance(lyra, s), "closeness stage too low");
        s.Closeness = 55; s.Trust = 40; Assert.True(!r.CanRomance(lyra, s), "trust stage too low");
        s.Trust = 55; s.Tension = 40; Assert.True(!r.CanRomance(lyra, s), "tension at the ceiling");
        s.Tension = 10; lyra.Adult = false; Assert.True(!r.CanRomance(lyra, s), "must be adult");
        lyra.Adult = true; s.Departed = true; Assert.True(!r.CanRomance(lyra, s), "not while departed");
    }

    public static void DepartureNeedsTensionForeshadowAndAnOfferedRepair()
    {
        var r = R();
        int hi = r.Departure.MinTension;
        foreach (var combo in new[] { (false, true, true), (true, false, true), (true, true, false) })
        {
            var s = r.NewState();
            s.Tension = combo.Item1 ? hi : hi - 1; s.Foreshadowed = combo.Item2; s.RepairOffered = combo.Item3;
            Assert.True(!r.MayDepart(s), "missing one condition: " + combo);
            Assert.True(!r.TryDepart(s) && !s.Departed, "stays");
        }
        var ok = r.NewState();
        ok.Tension = hi; ok.Foreshadowed = true; ok.RepairOffered = true;
        Assert.True(r.MayDepart(ok), "all three");
        Assert.True(r.TryDepart(ok) && ok.Departed, "leaves");
    }

    public static void TimeAloneNeverMakesACompanionLeave()
    {
        var r = R();
        var s = r.NewState();
        for (int d = 0; d < 400; d++) { r.Ease(s, 1); Assert.True(!r.TryDepart(s), "no departure by timer"); }
        Assert.True(!s.Departed, "still here");
        Assert.True(s.Tension <= r.Track(RelationTrack.Tension).Start, "tension only eases");
    }

    public static void TensionEasesSlowlyAndOtherTracksDoNot()
    {
        var r = R();
        var s = r.NewState();
        s.Tension = 30; s.Trust = 40;
        r.Ease(s, 3);
        Assert.Equal(30 - 3 * r.Track(RelationTrack.Tension).EasePerDay, s.Tension, "eased");
        Assert.Equal(40, s.Trust, "trust does not decay");
        r.Ease(s, 1000);
        Assert.Equal(0, s.Tension, "floors at 0");
    }

    public static void ADepartedCompanionReturnsThroughRepair()
    {
        var r = R();
        var s = r.NewState();
        s.Tension = 90;
        Assert.Equal(RelationApplyResult.Applied, r.Apply(s, "values_clash", 1), "foreshadow beat");
        Assert.Equal(RelationApplyResult.Applied, r.Apply(s, "repair_offered", 2), "repair chance");
        Assert.True(s.Foreshadowed && s.RepairOffered, "flags raised");
        Assert.True(r.TryDepart(s), "departs");
        Assert.Equal(RelationApplyResult.CompanionDeparted, r.Apply(s, "shared_meal", 3), "other events do nothing while away");
        Assert.Equal(RelationApplyResult.Applied, r.Apply(s, "made_amends", 4), "repair event works");
        Assert.True(!s.Departed, "returned");
        Assert.True(!s.Foreshadowed && !s.RepairOffered, "needs a fresh warning before leaving again");
        Assert.True(!r.MayDepart(s), "cannot leave straight away");
    }

    public static void NullSaveGivesStartingDefaults()
    {
        var r = R();
        var s = RelationshipState.FromSave(null, r, "cmp_lyra");
        Assert.Equal(r.Track(RelationTrack.Trust).Start, s.Trust, "trust start");
        Assert.Equal(r.Track(RelationTrack.Respect).Start, s.Respect, "respect start");
        Assert.Equal(r.Track(RelationTrack.Closeness).Start, s.Closeness, "closeness start");
        Assert.Equal(r.Track(RelationTrack.Tension).Start, s.Tension, "tension start");
        Assert.True(!s.RomanceOptIn && !s.Departed && !s.Foreshadowed && !s.RepairOffered, "flags off");
        Assert.Equal(0, s.LastSeenDay.Count, "nothing seen");
        Assert.Equal(CompanionAvailability.Ally, s.Availability, "non-Kaito is simply available");
        Assert.True(RelationshipState.FromSave(null) != null, "works with no rules too");
    }

    public static void SaveRoundTripKeepsTracksFlagsAndSeenEvents()
    {
        var r = R();
        var s = r.NewState();
        r.Apply(s, "confided_secret", 7);
        s.RomanceOptIn = true;
        var back = RelationshipState.FromSave(s.ToSave("cmp_kiri"), r, "cmp_kiri");
        Assert.Equal(s.Trust, back.Trust, "trust");
        Assert.Equal(s.Closeness, back.Closeness, "closeness");
        Assert.True(back.RomanceOptIn, "opt-in");
        Assert.Equal(RelationApplyResult.OnceAlreadySeen, r.Apply(back, "confided_secret", 50), "once-only survives a save");
        var wild = new CompanionBondSave { Trust = 500, Respect = -5, Seen = new List<string> { null, "x", "ok@3" } };
        var c = RelationshipState.FromSave(wild, r);
        Assert.Equal(100, c.Trust, "clamped high");
        Assert.Equal(0, c.Respect, "clamped low");
        Assert.Equal(1, c.LastSeenDay.Count, "bad rows skipped");
    }

    public static void KaitoAvailabilityIsAStateNotANumber()
    {
        var r = R();
        Assert.Equal(CompanionAvailability.Rival, r.NewState("cmp_kaito").Availability, "Kaito starts as a rival");
        Assert.Equal(CompanionAvailability.Ally, r.NewState("cmp_lyra").Availability, "others are allies");
        var k = r.NewState("cmp_kaito");
        k.Availability = CompanionAvailability.Fallen;
        var back = RelationshipState.FromSave(k.ToSave("cmp_kaito"), r, "cmp_kaito");
        Assert.Equal(CompanionAvailability.Fallen, back.Availability, "round-trips as a state");
        Assert.Equal(CompanionAvailability.Rival, RelationshipState.FromSave(null, r, "cmp_kaito").Availability, "old save starts Kaito as rival");
        Assert.True(typeof(RelationshipState).GetProperty("Availability").PropertyType.IsEnum, "enum, not a number");
    }
}
