using System.Linq;
using Ascend.Core;

// Data-driven reactions and synergies (combat.md section 7; Data/Combat/reactions.json).
// Backward compatibility is the point: the table must reproduce the ten pairs that used to be hard-coded.
[Tests]
static class ReactionTableTests
{
    static CombatTuning Tuning => Repo.Db.Tuning;
    static ReactionFile RFile => Repo.Load<ReactionFile>("Data/Combat/reactions.json");
    static ReactionTable Json => new ReactionTable(RFile);
    static readonly Element[] AllElements = (Element[])System.Enum.GetValues(typeof(Element));

    // The original hard-coded rule, restated here independently of ReactionTable so the comparison is not circular.
    static Reaction Legacy(Element aura, Element trigger)
    {
        if (aura == Element.None || trigger == Element.None || aura == trigger) return Reaction.None;
        bool Is(Element a, Element b) => (aura == a && trigger == b) || (aura == b && trigger == a);
        if (Is(Element.Fire, Element.Wind)) return Reaction.Firestorm;
        if (Is(Element.Water, Element.Lightning)) return Reaction.StormPrison;
        if (Is(Element.Water, Element.Ice)) return Reaction.Freeze;
        if (Is(Element.Fire, Element.Ice)) return Reaction.ThermalShock;
        if (Is(Element.Earth, Element.Fire)) return Reaction.Magma;
        if (Is(Element.Nature, Element.Fire)) return Reaction.Wildfire;
        if (Is(Element.Light, Element.Dark)) return Reaction.TwilightBurst;
        if (Is(Element.Poison, Element.Fire)) return Reaction.MiasmaBlast;
        if (Is(Element.Lightning, Element.Earth)) return Reaction.Grounded;
        if (aura == Element.Wind || trigger == Element.Wind) return Reaction.Swirl;
        return Reaction.None;
    }

    // ------------------------------------------------------------------ parity: every Element x Element pair
    public static void EveryPairMatchesTheOriginalRuleInElementsDefaultAndJson()
    {
        var json = Json;
        var dbTable = Repo.Db.ReactionTable;
        int n = 0;
        foreach (var a in AllElements)
            foreach (var b in AllElements)
            {
                var want = Legacy(a, b);
                Assert.Equal(want, Elements.React(a, b), $"Elements.React {a}+{b}");
                Assert.Equal(want, Elements.React(a, b, null), $"Elements.React(null table) {a}+{b}");
                Assert.Equal(want, ReactionTable.Default.React(a, b), $"Default {a}+{b}");
                Assert.Equal(want, json.React(a, b), $"JSON table {a}+{b}");
                Assert.Equal(want, dbTable.React(a, b), $"GameDatabase table {a}+{b}");
                Assert.Equal(json.React(a, b), ReactionTable.Default.React(a, b), $"JSON vs Default {a}+{b}");
                n++;
            }
        Assert.Equal(AllElements.Length * AllElements.Length, n, "all pairs visited");
    }

    public static void AuraStateAgreesAcrossDefaultAndJsonTables()
    {
        var json = Json;
        foreach (var a in AllElements.Where(e => e != Element.None))
            foreach (var b in AllElements.Where(e => e != Element.None))
            {
                var d = new AuraState(Tuning.Reactions.AuraDurationSec);
                var j = new AuraState(Tuning.Reactions.AuraDurationSec);
                var plain = new AuraState(Tuning.Reactions.AuraDurationSec);
                d.Apply(a, 0, ReactionTable.Default); j.Apply(a, 0, json); plain.Apply(a, 0);
                var rd = d.Apply(b, 1, ReactionTable.Default);
                var rj = j.Apply(b, 1, json);
                var rp = plain.Apply(b, 1);
                Assert.Equal(rd, rj, $"reaction {a} then {b}");
                Assert.Equal(rd, rp, $"reaction (no table) {a} then {b}");
                Assert.Equal(d.Current(1.5), j.Current(1.5), $"aura left after {a} then {b}");
                Assert.Equal(d.Current(1.5), plain.Current(1.5), $"aura left (no table) after {a} then {b}");
            }
    }

    public static void OnlySwirlKeepsTheAuraAndEveryOtherReactionConsumesIt()
    {
        foreach (var table in new[] { ReactionTable.Default, Json })
            foreach (var r in System.Enum.GetValues(typeof(Reaction)).Cast<Reaction>().Where(r => r != Reaction.None))
                Assert.Equal(r != Reaction.Swirl, table.ConsumesAura(r), $"ConsumesAura {r}");
    }

    public static void ReactionStateWithNoTableIsTheOldStateTickForTick()
    {
        var old = new ReactionState(Tuning.Reactions);
        var viaDefault = new ReactionState(Tuning.Reactions, ReactionTable.Default);
        var viaJson = new ReactionState(Tuning.Reactions, Json);
        var script = new (Element e, double t)[] {
            (Element.Water, 0), (Element.Ice, 0.5), (Element.Fire, 1), (Element.Wind, 1.5), (Element.Water, 2), (Element.Lightning, 2.5),
            (Element.Earth, 3), (Element.Fire, 3.5), (Element.Nature, 4), (Element.Fire, 4.5), (Element.Light, 10), (Element.Dark, 10.5) };
        foreach (var (e, t) in script)
        {
            var a = old.ApplyElement(e, t); var b = viaDefault.ApplyElement(e, t); var c = viaJson.ApplyElement(e, t);
            Assert.Equal(a, b, $"default table at t={t}");
            Assert.Equal(a, c, $"json table at t={t}");
            Assert.Equal(old.IsFrozen(t), viaJson.IsFrozen(t), $"frozen at t={t}");
            Assert.Equal(old.IsStunned(t), viaJson.IsStunned(t), $"stunned at t={t}");
            Assert.Equal(old.Aura.Current(t), viaJson.Aura.Current(t), $"aura at t={t}");
        }
    }

    // ------------------------------------------------------------------ the numbers stay in combat_tuning.json
    public static void FreezeAndStormPrisonNumbersEqualCombatTuning()
    {
        var t = Tuning.Reactions;
        var file = RFile;
        var freeze = file.Reactions.Single(r => r.Id == "Freeze");
        var storm = file.Reactions.Single(r => r.Id == "StormPrison");
        Assert.Equal("freeze", freeze.Status.Kind, "freeze kind");
        Assert.Equal("stun", storm.Status.Kind, "storm prison kind");
        Assert.Near(t.FreezeDurationSec, freeze.Status.DurationSec, 1e-9, "reactions.json Freeze seconds vs combat_tuning.json");
        Assert.Near(t.StormPrisonStunSec, storm.Status.DurationSec, 1e-9, "reactions.json StormPrison seconds vs combat_tuning.json");

        foreach (var table in new[] { ReactionTable.Default, new ReactionTable(file) })
        {
            var f = table.Describe(Reaction.Freeze, Element.Water, Element.Ice, t);
            var s = table.Describe(Reaction.StormPrison, Element.Water, Element.Lightning, t);
            Assert.Equal("freeze", f.StatusKind, "described freeze kind");
            Assert.Equal("stun", s.StatusKind, "described stun kind");
            Assert.Near(t.FreezeDurationSec, f.StatusDurationSec, 1e-9, "described freeze seconds");
            Assert.Near(t.StormPrisonStunSec, s.StatusDurationSec, 1e-9, "described stun seconds");
        }
    }

    public static void FreezeHoldsForTheTunedTimeAndShatterUsesTheTunedBonus()
    {
        var t = Tuning.Reactions;
        foreach (var table in new[] { ReactionTable.Default, Json })
        {
            var s = new ReactionState(t, table);
            s.ApplyElement(Element.Water, 0);
            Assert.Equal(Reaction.Freeze, s.ApplyElement(Element.Ice, 1), "freeze");
            Assert.True(s.IsFrozen(1 + t.FreezeDurationSec - 0.01), "still frozen just inside the tuned time");
            Assert.True(!s.IsFrozen(1 + t.FreezeDurationSec + 0.01), "thawed just after the tuned time");
            Assert.Near(1.0, s.HitMultiplier(HitWeight.Light, 1.5), 1e-9, "a light hit does not shatter");
            Assert.Near(t.ShatterBonus, s.HitMultiplier(HitWeight.Heavy, 1.6), 1e-9, "a heavy hit shatters for the tuned bonus");
            Assert.True(!s.IsFrozen(1.7), "shatter ends the freeze");

            var p = new ReactionState(t, table);
            p.ApplyElement(Element.Water, 0);
            Assert.Equal(Reaction.StormPrison, p.ApplyElement(Element.Lightning, 1), "storm prison");
            Assert.True(p.IsStunned(1 + t.StormPrisonStunSec - 0.01), "stunned inside the tuned time");
            Assert.True(!p.IsStunned(1 + t.StormPrisonStunSec + 0.01), "free after the tuned time");
        }
    }

    public static void FirestormHazardRestatesCombatTuningFirestorm()
    {
        var fs = Tuning.Firestorm;
        var row = RFile.Reactions.Single(r => r.Id == "Firestorm");
        Assert.Near(fs.BurstMult, row.BonusDamageMult, 1e-9, "Firestorm bonus equals firestorm.burstMult");
        Assert.Near(fs.RadiusM, row.Hazard.RadiusM, 1e-9, "radius");
        Assert.Near(fs.DurationSec, row.Hazard.DurationSec, 1e-9, "duration");
        Assert.Near(fs.TickPower / fs.TickSec, row.Hazard.DamagePerSecMult, 1e-9, "damage per second = tickPower / tickSec");
    }

    // ------------------------------------------------------------------ the JSON file itself
    public static void JsonHasTheTenReactionsAndAtLeastFourSynergiesAndTheyResolve()
    {
        var file = RFile;
        Assert.Equal(10, file.Reactions.Count, "ten reactions");
        foreach (var r in System.Enum.GetValues(typeof(Reaction)).Cast<Reaction>().Where(r => r != Reaction.None))
            Assert.True(file.Reactions.Any(x => x.Id == r.ToString()), $"{r} has a row");
        Assert.True(file.Synergies.Count >= 4, $"at least 4 synergies (got {file.Synergies.Count})");
        Assert.Equal(file.Synergies.Count, file.Synergies.Select(s => s.Id).Distinct().Count(), "synergy ids unique");
        foreach (var s in file.Synergies)
        {
            Assert.True(System.Enum.TryParse<Reaction>(s.First, out var f) && f != Reaction.None, $"{s.Id} first \"{s.First}\" is a reaction");
            Assert.True(System.Enum.TryParse<Reaction>(s.Then, out var th) && th != Reaction.None, $"{s.Id} then \"{s.Then}\" is a reaction");
            Assert.True(s.WindowSec > 0, $"{s.Id} has a window");
            Assert.True(s.BonusDamageMult > 1.0, $"{s.Id} is a bonus");
        }
        Assert.Equal(file.Synergies.Count, Repo.Db.ReactionTable.Synergies.Count, "GameDatabase table carries the synergies");
    }

    public static void TablesRejectBrokenData()
    {
        Assert.Throws<System.InvalidOperationException>(() => new ReactionTable(new ReactionFile { Reactions = { new ReactionData { Id = "Nope", Elements = { "Fire", "Ice" } } } }), "unknown id");
        var dup = new ReactionFile();
        dup.Reactions.Add(new ReactionData { Id = "Freeze", Elements = { "Water", "Ice" } });
        dup.Reactions.Add(new ReactionData { Id = "Freeze", Elements = { "Water", "Ice" } });
        Assert.Throws<System.InvalidOperationException>(() => new ReactionTable(dup), "duplicate id");
        var dupPair = new ReactionFile();
        dupPair.Reactions.Add(new ReactionData { Id = "Freeze", Elements = { "Water", "Ice" } });
        dupPair.Reactions.Add(new ReactionData { Id = "ThermalShock", Elements = { "Ice", "Water" } });
        Assert.Throws<System.InvalidOperationException>(() => new ReactionTable(dupPair), "same unordered pair twice");
    }

    public static void SwirlSpreadsTheNonWindElementAndKeepsTheAura()
    {
        var json = Json;
        var d1 = json.Describe(Reaction.Swirl, Element.Water, Element.Wind, Tuning.Reactions);
        Assert.Equal(Element.Water, d1.Swirl.Value.Element, "water aura + wind hit spreads water");
        var d2 = json.Describe(Reaction.Swirl, Element.Wind, Element.Fire, Tuning.Reactions);
        Assert.Equal(Element.Fire, d2.Swirl.Value.Element, "wind aura + fire hit spreads fire");
        Assert.Near(RFile.Swirl.SpreadDamageMult, d1.Swirl.Value.DamageMult, 1e-9, "spread mult from the file");
        Assert.Equal(RFile.Swirl.MaxSpreadTargets, d1.Swirl.Value.MaxTargets, "max targets from the file");
        var s = new ReactionState(Tuning.Reactions, json);
        s.ApplyElement(Element.Water, 0);
        var r = s.ApplyElementDetailed(Element.Wind, 1);
        Assert.Equal(Reaction.Swirl, r.Reaction, "swirl");
        Assert.True(r.Swirl.HasValue, "swirl info present");
        Assert.Equal(Element.Water, s.Aura.Current(1), "aura kept");
    }

    public static void ReactionBonusesComeFromTheTableAndDefaultsAreNeutral()
    {
        var s = new ReactionState(Tuning.Reactions, Json);
        s.ApplyElement(Element.Fire, 0);
        var r = s.ApplyElementDetailed(Element.Ice, 1);
        Assert.Equal(Reaction.ThermalShock, r.Reaction, "thermal shock");
        Assert.Near(RFile.Reactions.Single(x => x.Id == "ThermalShock").BonusDamageMult, r.BonusMult, 1e-9, "bonus from the file");
        Assert.Near(r.BonusMult * r.SynergyMult, r.TotalMult, 1e-9, "TotalMult = bonus x synergy");

        var plain = new ReactionState(Tuning.Reactions);
        plain.ApplyElement(Element.Fire, 0);
        var p = plain.ApplyElementDetailed(Element.Ice, 1);
        Assert.Near(1.0, p.BonusMult, 1e-9, "default table adds no bonus (today's behaviour)");
        Assert.Near(1.0, p.TotalMult, 1e-9, "default table: total is neutral");

        var none = new ReactionState(Tuning.Reactions, Json).ApplyElementDetailed(Element.Fire, 0);
        Assert.Equal(Reaction.None, none.Reaction, "no reaction on the first hit");
        Assert.Near(1.0, none.TotalMult, 1e-9, "no reaction, neutral multiplier");
    }

    // ------------------------------------------------------------------ synergies
    public static void FindSynergyFiresInsideTheWindowAndNotOutside()
    {
        var json = Json;
        foreach (var syn in RFile.Synergies)
        {
            var first = System.Enum.Parse<Reaction>(syn.First);
            var then = System.Enum.Parse<Reaction>(syn.Then);
            Assert.Equal(syn.Id, json.FindSynergy(first, then, 0)?.Id, $"{syn.Id} at 0 s");
            Assert.Equal(syn.Id, json.FindSynergy(first, then, syn.WindowSec * 0.5)?.Id, $"{syn.Id} mid window");
            Assert.Equal(syn.Id, json.FindSynergy(first, then, syn.WindowSec)?.Id, $"{syn.Id} at the window edge");
            Assert.True(json.FindSynergy(first, then, syn.WindowSec + 0.01) == null, $"{syn.Id} just outside the window");
            Assert.True(json.FindSynergy(first, then, -0.1) == null, $"{syn.Id} negative elapsed");
            Assert.True(json.FindSynergy(first, Reaction.None, 0) == null, $"{syn.Id} then=None");
            Assert.True(json.FindSynergy(Reaction.None, then, 0) == null, $"{syn.Id} first=None");
        }
        Assert.True(ReactionTable.Default.Synergies.Count == 0 && ReactionTable.Default.FindSynergy(Reaction.Freeze, Reaction.ThermalShock, 0) == null, "the default table has no synergies");
    }

    // Swirl (water aura, wind) then Fire then Wind = Firestorm. fanned_flames: Swirl -> Firestorm within 4 s.
    static ReactionResult FanTheFlames(double windAt)
    {
        var s = new ReactionState(Tuning.Reactions, Json);
        s.ApplyElement(Element.Water, 0);
        Assert.Equal(Reaction.Swirl, s.ApplyElement(Element.Wind, 0.1), "swirl opens");
        Assert.Equal(Reaction.None, s.ApplyElement(Element.Fire, 0.5), "fire replaces the aura");
        return s.ApplyElementDetailed(Element.Wind, windAt);
    }

    public static void SwirlIntoFirestormFiresTheFannedFlamesSynergyInWindow()
    {
        var r = FanTheFlames(1.0);
        Assert.Equal(Reaction.Firestorm, r.Reaction, "firestorm");
        Assert.Equal("fanned_flames", r.Synergy?.Id, "synergy id");
        var want = RFile.Synergies.Single(x => x.Id == "fanned_flames").BonusDamageMult;
        Assert.Near(want, r.SynergyMult, 1e-9, "synergy multiplier");
        Assert.Near(r.BonusMult * want, r.TotalMult, 1e-9, "total multiplier stacks the reaction bonus and the synergy");
    }

    public static void SwirlIntoFirestormDoesNotFireOutsideTheWindow()
    {
        var win = RFile.Synergies.Single(x => x.Id == "fanned_flames").WindowSec;
        // The fire aura set at t=0.5 lasts the aura duration; the swirl happened at t=0.1.
        double late = 0.1 + win + 0.5;
        Assert.True(late < 0.5 + Tuning.Reactions.AuraDurationSec, "test setup: the fire aura is still up");
        var r = FanTheFlames(late);
        Assert.Equal(Reaction.Firestorm, r.Reaction, "the reaction itself still fires");
        Assert.True(r.Synergy == null, "no synergy outside the window");
        Assert.Near(1.0, r.SynergyMult, 1e-9, "synergy multiplier neutral");
    }

    public static void ThawBurstFreezeThenThermalShock()
    {
        ReactionResult Run(double iceAt)
        {
            var s = new ReactionState(Tuning.Reactions, Json);
            s.ApplyElement(Element.Water, 0);
            Assert.Equal(Reaction.Freeze, s.ApplyElement(Element.Ice, 0.1), "freeze");
            Assert.Equal(Reaction.None, s.ApplyElement(Element.Fire, 0.2), "fire aura");
            return s.ApplyElementDetailed(Element.Ice, iceAt);
        }
        var syn = RFile.Synergies.Single(x => x.Id == "thaw_burst");
        var inWin = Run(0.1 + syn.WindowSec - 0.1);
        Assert.Equal(Reaction.ThermalShock, inWin.Reaction, "thermal shock");
        Assert.Equal("thaw_burst", inWin.Synergy?.Id, "in window");
        var outWin = Run(0.1 + syn.WindowSec + 0.2);
        Assert.Equal(Reaction.ThermalShock, outWin.Reaction, "thermal shock out of window");
        Assert.True(outWin.Synergy == null, "no synergy out of window");
    }

    public static void ASynergyNeedsTheFirstReactionOnTheSameTarget()
    {
        // ThermalShock with no Freeze before it: no thaw_burst.
        var s = new ReactionState(Tuning.Reactions, Json);
        s.ApplyElement(Element.Fire, 0);
        var r = s.ApplyElementDetailed(Element.Ice, 0.5);
        Assert.Equal(Reaction.ThermalShock, r.Reaction, "plain thermal shock");
        Assert.True(r.Synergy == null, "no freeze first, no synergy");

        // A Freeze on a different target does not count.
        var a = new ReactionState(Tuning.Reactions, Json);
        var b = new ReactionState(Tuning.Reactions, Json);
        a.ApplyElement(Element.Water, 0); a.ApplyElement(Element.Ice, 0.1);
        b.ApplyElement(Element.Fire, 0.2);
        var rb = b.ApplyElementDetailed(Element.Ice, 0.3);
        Assert.True(rb.Synergy == null, "synergies are per target");
        Assert.Equal(Reaction.Freeze, a.LastReaction, "target a remembers its own last reaction");
    }

    public static void StormGroundSynergyStunThenGrounded()
    {
        var s = new ReactionState(Tuning.Reactions, Json);
        s.ApplyElement(Element.Water, 0);
        Assert.Equal(Reaction.StormPrison, s.ApplyElement(Element.Lightning, 0.1), "storm prison");
        Assert.Equal(Reaction.None, s.ApplyElement(Element.Earth, 0.5), "earth aura");
        var r = s.ApplyElementDetailed(Element.Lightning, 1.0);
        Assert.Equal(Reaction.Grounded, r.Reaction, "grounded");
        Assert.Equal("storm_ground", r.Synergy?.Id, "storm_ground in window");
    }
}
