using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Ascend.Core;

// Wave D QA: adversarial regression tests (music machine, environment, accessibility save shapes, photo mode).
// Confirmed bugs live in WaveDQaKnownBugs at the bottom (not marked [Tests], so they do not run until fixed).
[Tests]
static class WaveDQaMusicTests
{
    static MusicMachine Make(MusicPrefs prefs = null) => new MusicMachine(AudioData.Music(), AudioData.Roster(), prefs);
    static MusicInput Calm() => new MusicInput { Region = "reg_ashira_vale" };
    static MusicInput Fight(int threat = 2) => new MusicInput { InCombat = true, ThreatLevel = threat, Region = "reg_ashira_vale" };
    static MusicInput Boss(int phase) => new MusicInput { InCombat = true, ThreatLevel = 4, BossPhase = phase, Region = "reg_ashira_vale" };

    static MusicFrame Run(MusicMachine m, MusicInput i, double seconds)
    {
        MusicFrame f = null;
        for (double t = 0; t < seconds - 1e-9; t += 0.5) { f = m.Update(0.5, i); i.Outcome = CombatOutcome.None; }
        return f ?? m.Update(0, i);
    }

    public static void VictoryDuringBossResolvesToAftermathWithTheBossCrossfade()
    {
        var m = Make(); Run(m, Boss(2), 20);
        Assert.Equal("boss", m.CurrentState, "in boss");
        var calm = Calm(); calm.Outcome = CombatOutcome.Victory;
        var fr = m.Update(0.5, calm);
        Assert.Equal("aftermath", fr.StateId, "victory ends the boss score at once");
        Assert.Equal("boss", fr.Transition.From, "from boss");
        Assert.Near(2.0, fr.Transition.CrossfadeSeconds, 1e-9, "boss>aftermath crossfade");
        Assert.True(!fr.Layers.ContainsKey("rock_lead"), "rock stem is gone in aftermath");
        Assert.Equal(0, fr.BossPhase, "boss phase not reported outside boss");
    }

    public static void VictoryWhileTheBossIsStillWantedDoesNotResolve()
    {
        var m = Make(); Run(m, Boss(1), 20);
        var i = Boss(1); i.Outcome = CombatOutcome.Victory;
        Assert.Equal("boss", m.Update(0.5, i).StateId, "boss still owns the score");
    }

    public static void BossPhaseDroppingToZeroKeepsTheBossScoreForItsHold()
    {
        var m = Make(); Run(m, Boss(3), 16);
        var fr = Run(m, Fight(), 2);
        Assert.Equal("boss", fr.StateId, "boss holds through a phase-0 glitch (exit delay 8 s)");
        Assert.True(fr.Layers.ContainsKey("rock_lead"), "the highest phase reached keeps its layers while the boss state lingers (no musical downgrade on a glitch)");
        Assert.Equal(3, fr.BossPhase, "reports the held phase");
        var back = m.Update(0.5, Boss(3));
        Assert.True(!back.Stingers.Contains("mus_stinger_boss_phase"), "no phase stinger when returning to a phase already reached");
        Assert.True(back.Layers.ContainsKey("rock_lead"), "rock stem returns with phase 3");
    }

    public static void BossPhaseDroppingToZeroEventuallyStepsDownToCombat()
    {
        var m = Make(); Run(m, Boss(2), 16);
        Assert.Equal("boss", Run(m, Fight(), 7.5).StateId, "7.5 s < 8 s exit");
        Assert.Equal("combat", Run(m, Fight(), 1).StateId, "then combat");
    }

    public static void BossPhaseStingerFiresOncePerAdvance()
    {
        var m = Make(); Run(m, Boss(1), 3);
        var f2 = m.Update(0.5, Boss(2));
        Assert.True(f2.Stingers.Contains("mus_stinger_boss_phase"), "phase 2 stinger");
        Assert.True(!m.Update(0.5, Boss(2)).Stingers.Contains("mus_stinger_boss_phase"), "not repeated");
        var f3 = m.Update(0.5, Boss(3));
        Assert.Equal(1, f3.Stingers.Count(s => s == "mus_stinger_boss_phase"), "phase 3 stinger once");
        var jump = Make(); Run(jump, Boss(1), 3);
        Assert.Equal(1, jump.Update(0.5, Boss(3)).Stingers.Count(s => s == "mus_stinger_boss_phase"), "a skipped phase still gives one stinger");
    }

    public static void BossPhaseBeyondTheListKeepsTheLastSet()
    {
        var m = Make(); Run(m, Boss(1), 3);
        var fr = m.Update(0.5, Boss(99));
        Assert.True(fr.Layers.ContainsKey("rock_lead") && fr.Layers.ContainsKey("bass_weight"), "phase 99 uses the last set");
        Assert.Equal(1.0, fr.Layers["rock_lead"], "rock_lead at last-set gain");
    }

    public static void BossEnteredAtPhaseTwoGivesNoPhaseStingerButTheIntroOne()
    {
        var m = Make(); Run(m, Calm(), 3);
        var fr = m.Update(0.5, Boss(2));
        Assert.Equal("boss", fr.StateId, "boss at once");
        Assert.True(fr.Stingers.Contains("mus_stinger_boss_intro") && !fr.Stingers.Contains("mus_stinger_boss_phase"), "intro only");
    }

    public static void CutsceneInterruptsBossThenReturnsToTheBoss()
    {
        var m = Make(); Run(m, Boss(2), 16);
        var cs = Boss(2); cs.CutsceneActive = true;
        Assert.Equal("cutscene", m.Update(0.5, cs).StateId, "cutscene takes the score at once");
        Assert.Equal("cutscene", Run(m, cs, 2.5).StateId, "held");
        var after = Run(m, Boss(2), 1.5);
        Assert.Equal("boss", after.StateId, "boss score returns after the cutscene");
        Assert.True(after.Layers.ContainsKey("rock_lead"), "phase 2 layers present");
    }

    public static void CutsceneEndingToAQuietWorldReturnsAfterItsMinHold()
    {
        var m = Make(); Run(m, Calm(), 3);
        var cs = Calm(); cs.CutsceneActive = true;
        m.Update(0.5, cs);
        Assert.Equal("cutscene", Run(m, Calm(), 2).StateId, "min hold 3 s blocks the exit");
        Assert.Equal("explore", Run(m, Calm(), 1.5).StateId, "then back to explore");
    }

    public static void AdvantageDoesNotSurviveACutsceneIntoTheNextFight()
    {
        var m = Make(); Run(m, Fight(), 10);
        var adv = Fight(); adv.PlayerAdvantage = true; adv.PlayerHpFraction = 0.1; Run(m, adv, 1);
        var cs = Calm(); cs.CutsceneActive = true; m.Update(0.5, cs);
        Run(m, Calm(), 4);
        var fr = Run(m, Fight(), 1);
        Assert.Equal("combat", fr.StateId, "new fight after the cutscene");
        Assert.True(!fr.Layers.ContainsKey("advantage_perc"), "advantage overlay did not survive the cutscene");
    }

    public static void NoCombatMusicWithACutsceneStillPlaysTheCutsceneAndNeverCombat()
    {
        var m = Make(new MusicPrefs { NoCombatMusic = true });
        var f = Run(m, Fight(4), 3);
        Assert.True(f.StateId == "explore", "no combat state, even for a hostile in combat: " + f.StateId);
        var cs = Fight(); cs.CutsceneActive = true;
        Assert.Equal("cutscene", m.Update(0.5, cs).StateId, "cutscene still plays");
        var banned = new[] { "combat", "elite", "boss", "uncertainty", "aftermath" };
        for (int k = 0; k < 40; k++)
        {
            var i = k % 3 == 0 ? Boss(2) : Fight(3); i.Outcome = k % 5 == 0 ? CombatOutcome.Victory : CombatOutcome.None;
            var fr = m.Update(0.5, i);
            Assert.True(!banned.Contains(fr.StateId), "state " + fr.StateId + " must never play with no-combat-music");
            Assert.True(!fr.Layers.ContainsKey("percussion") && !fr.Layers.ContainsKey("rock_lead"), "no combat stems");
            Assert.True(!fr.Stingers.Contains("mus_stinger_victory") && !fr.Stingers.Contains("mus_stinger_boss_intro"), "no combat stingers");
        }
    }

    public static void NoCombatMusicVictoryNeverGivesAnAftermath()
    {
        var m = Make(new MusicPrefs { NoCombatMusic = true }); Run(m, Fight(), 10);
        var calm = Calm(); calm.Outcome = CombatOutcome.Victory;
        Assert.Equal("explore", m.Update(0.5, calm).StateId, "no victory score either");
    }

    public static void RetreatUsesTheLongExitAndTheFlagDoesNotLeakIntoTheNextFight()
    {
        var m = Make(); Run(m, Fight(), 9);
        var r = Calm(); r.Outcome = CombatOutcome.Retreat; m.Update(0.5, r);
        Assert.Equal("combat", Run(m, Calm(), 10).StateId, "retreat exit is 12 s");
        Assert.True(Run(m, Calm(), 2.5).StateId != "combat", "left after 12 s");
        Run(m, Fight(), 9);
        Assert.Equal("combat", m.CurrentState, "fighting again");
        Assert.Equal("combat", Run(m, Calm(), 5.5).StateId, "5.5 s");
        Assert.True(Run(m, Calm(), 1.0).StateId != "combat", "normal exit applies in the next fight");
    }

    // BUG A: a Retreat event latches _retreating until the next state change; if the player re-engages and the same
    // combat state keeps playing, the later normal calm-down waits the 12 s retreat exit instead of 6 s.
    public static void AbandonedRetreatDoesNotStretchTheLaterExit()
    {
        var m = Make(); Run(m, Fight(), 9);
        var r = Fight(); r.Outcome = CombatOutcome.Retreat; m.Update(0.5, r);
        Run(m, Fight(), 5);
        Assert.Equal("combat", Run(m, Calm(), 5.5).StateId, "5.5 s quiet");
        Assert.True(Run(m, Calm(), 1.0).StateId != "combat", "6.5 s quiet should leave combat (normal 6 s exit)");
    }

    public static void RetreatIgnoredOutsideCombatClass()
    {
        var m = Make(); Run(m, Calm(), 3);
        var r = Calm(); r.Outcome = CombatOutcome.Retreat; m.Update(0.5, r);
        Run(m, Fight(), 9);
        Assert.Equal("combat", Run(m, Calm(), 5.5).StateId, "5.5 s");
        Assert.True(Run(m, Calm(), 1.0).StateId != "combat", "a retreat flag sent while exploring did not carry into the fight");
    }

    public static void AdvantageLatchExpiresAfterItsOffDelayAndNotBefore()
    {
        var m = Make(); Run(m, Fight(), 2);
        var adv = Fight(); adv.PlayerAdvantage = true;
        Assert.True(m.Update(0.5, adv).Layers.ContainsKey("advantage_perc"), "on");
        Assert.True(Run(m, Fight(), 2.5).Layers.ContainsKey("advantage_perc"), "2.5 s < 3 s off delay: still on");
        Assert.True(!Run(m, Fight(), 1.0).Layers.ContainsKey("advantage_perc"), "off after 3 s");
    }

    public static void AdvantageFlickerResetsTheOffDelay()
    {
        var m = Make(); Run(m, Fight(), 2);
        var adv = Fight(); adv.PlayerAdvantage = true;
        for (int k = 0; k < 10; k++)
        {
            m.Update(0.5, adv); m.Update(0.5, Fight()); m.Update(0.5, Fight());
            Assert.True(m.Update(0.5, Fight()).Layers.ContainsKey("advantage_perc"), "flicker faster than 3 s keeps it on");
        }
    }

    public static void DangerOverlayHasHysteresisAcrossTheBand()
    {
        var m = Make(); Run(m, Fight(), 2);
        var low = Fight(); low.PlayerHpFraction = 0.29;
        Assert.True(m.Update(0.5, low).Layers.ContainsKey("bass_weight"), "below 0.3: on");
        var mid = Fight(); mid.PlayerHpFraction = 0.40;
        Assert.True(m.Update(0.5, mid).Layers.ContainsKey("bass_weight"), "0.40 is inside the band: stays on");
        var hi = Fight(); hi.PlayerHpFraction = 0.45;
        Assert.True(!m.Update(0.5, hi).Layers.ContainsKey("bass_weight"), "0.45: off");
        Assert.True(!m.Update(0.5, mid).Layers.ContainsKey("bass_weight"), "0.40 after recovery: stays off");
        var edge = Fight(); edge.PlayerHpFraction = 0.30;
        Assert.True(m.Update(0.5, edge).Layers.ContainsKey("bass_weight"), "exactly 0.30 enters");
    }

    public static void DangerAndAdvantageNeverShowOutsideCombatClass()
    {
        var m = Make(); Run(m, Calm(), 3);
        var i = Calm(); i.PlayerAdvantage = true; i.PlayerHpFraction = 0.05;
        var fr = Run(m, i, 3);
        Assert.True(!fr.Layers.ContainsKey("advantage_perc") && !fr.Layers.ContainsKey("bass_weight"), "overlays only in combat-class states");
    }

    public static void DangerSurvivesCombatToEliteSwitch()
    {
        var m = Make(); var low = Fight(); low.PlayerHpFraction = 0.1; Run(m, low, 2);
        var elite = Fight(3); elite.PlayerHpFraction = 0.1;
        var fr = m.Update(0.5, elite);
        Assert.Equal("elite", fr.StateId, "elite");
        Assert.True(fr.Layers.ContainsKey("bass_weight"), "danger overlay is still on across combat to elite");
    }

    public static void NaNAndOutOfRangeHpAreSafe()
    {
        var m = Make(); Run(m, Fight(), 2);
        var i = Fight(); i.PlayerHpFraction = double.NaN;
        Assert.True(!m.Update(0.5, i).Layers.ContainsKey("bass_weight"), "NaN HP reads as full");
        i.PlayerHpFraction = -5;
        Assert.True(m.Update(0.5, i).Layers.ContainsKey("bass_weight"), "negative HP clamps to 0, danger");
        i.PlayerHpFraction = 99;
        Assert.True(!m.Update(0.5, i).Layers.ContainsKey("bass_weight"), "huge HP clamps to 1");
    }

    public static void ZeroDtEventsStillProcess()
    {
        var m = Make(); Run(m, Fight(), 9);
        var calm = Calm(); calm.Outcome = CombatOutcome.Victory;
        Assert.Equal("aftermath", m.Update(0, calm).StateId, "victory with dt = 0");
        var m2 = Make(); Run(m2, Calm(), 3);
        Assert.Equal("combat", m2.Update(0, Fight()).StateId, "an enter delay of 0 needs no time");
        var m3 = Make(); Run(m3, Calm(), 3);
        var steady = Calm(); steady.ThreatLevel = 1;
        for (int k = 0; k < 100; k++) Assert.Equal("explore", m3.Update(0, steady).StateId, "dt = 0 never advances a delay");
    }

    public static void NegativeNaNAndInfiniteDtDoNotCorruptTheMachine()
    {
        var m = Make(); Run(m, Fight(), 9);
        Assert.Equal("combat", m.Update(-100, Calm()).StateId, "negative dt counts as 0");
        Assert.Equal("combat", m.Update(double.NaN, Calm()).StateId, "NaN dt counts as 0");
        var fr = m.Update(1e9, Calm());
        Assert.True(fr.StateId != "combat", "a huge dt satisfies the exit at once");
        Assert.True(!double.IsNaN(fr.HeldSeconds), "held is a number");
        var inf = Make(); Run(inf, Fight(), 9);
        var f2 = inf.Update(double.PositiveInfinity, Calm());
        Assert.True(f2.StateId != "combat", "infinite dt does not throw and exits");
        Assert.True(!double.IsNaN(inf.Update(0.5, Calm()).HeldSeconds), "no NaN after an infinite step");
    }

    public static void HugeDtMakesOnlyOneTransitionPerTick()
    {
        var m = Make(); Run(m, Fight(), 9);
        var fr = m.Update(1e6, Calm());
        Assert.Equal("explore", fr.StateId, "straight to explore");
        Assert.Equal("combat", fr.Transition.From, "single transition");
    }

    public static void ThreatFlappingAtTheExactDelayBoundary()
    {
        var m = Make(); Run(m, Calm(), 3);
        var t = Calm(); t.ThreatLevel = 1;
        for (int k = 0; k < 10; k++)
        {
            Run(m, t, 1.5);
            Assert.Equal("explore", m.CurrentState, "1.5 s < 2 s enter delay");
            m.Update(0.5, Calm());
        }
        Run(m, t, 1.5);
        Assert.Equal("explore", m.CurrentState, "still explore at 1.5");
        Assert.Equal("uncertainty", m.Update(0.5, t).StateId, "exactly 2.0 s trips the enter delay");
    }

    public static void CombatExitBoundaryIsInclusiveAtSixSeconds()
    {
        var m = Make(); Run(m, Fight(), 9);
        Assert.Equal("combat", Run(m, Calm(), 5.5).StateId, "5.5 s");
        Assert.True(Run(m, Calm(), 0.5).StateId != "combat", "6.0 s exactly leaves");
        var m2 = Make(); Run(m2, Fight(), 9); Run(m2, Calm(), 5.5);
        Assert.Equal("combat", m2.Update(0.5, Fight()).StateId, "one fight tick right at the boundary resets the wait");
        Assert.Equal("combat", Run(m2, Calm(), 5.5).StateId, "full 6 s needed again");
    }

    public static void FlappingBetweenCandidatesRestartsTheWait()
    {
        var m = Make(); Run(m, Fight(), 9);
        var unc = Calm(); unc.ThreatLevel = 1;
        for (int k = 0; k < 8; k++) { m.Update(0.5, Calm()); m.Update(0.5, unc); m.Update(0.5, Calm()); }
        Assert.Equal("combat", m.CurrentState, "alternating calm targets never accumulates a wait");
    }

    public static void FuzzKeepsEveryInvariant()
    {
        var m = Make(); var rnd = new Random(12345);
        string prev = m.CurrentState; int transitions = 0;
        var known = new HashSet<string>(AudioData.Music().States.Select(s => s.Id));
        for (int k = 0; k < 4000; k++)
        {
            var i = new MusicInput
            {
                InCombat = rnd.Next(3) == 0, ThreatLevel = rnd.Next(5), BossPhase = rnd.Next(8) == 0 ? rnd.Next(1, 5) : 0,
                Place = (PlaceKind)rnd.Next(4), CutsceneActive = rnd.Next(30) == 0, PlayerAdvantage = rnd.Next(4) == 0,
                PlayerHpFraction = rnd.NextDouble(), Outcome = (CombatOutcome)rnd.Next(3), Region = rnd.Next(6) == 0 ? "reg_b" : "reg_a",
                DayPart = (DayPart)rnd.Next(4), CompanionId = rnd.Next(2) == 0 ? "cmp_lyra" : null,
            };
            var fr = m.Update(rnd.Next(4) == 0 ? 0 : rnd.NextDouble() * 3, i);
            Assert.True(known.Contains(fr.StateId), "known state " + fr.StateId);
            if (fr.StateId != prev) { Assert.True(fr.Transition != null && fr.Transition.To == fr.StateId && fr.Transition.From == prev, "a change carries its transition"); transitions++; }
            else Assert.True(fr.Transition == null, "no transition without a change");
            Assert.True(fr.Layers.Values.All(g => g >= 0 && g <= 1), "gains in range");
            Assert.True(fr.StateId == "boss" || !fr.Layers.ContainsKey("rock_lead"), "rock stem only in boss (fuzz)");
            prev = fr.StateId;
        }
        Assert.True(transitions > 20, "the fuzz actually moved the machine");
    }

    public static void ReducedIntensityDropsIntenseAndKeepsEssentialAtFullGain()
    {
        var m = Make(new MusicPrefs { ReducedIntensity = true });
        var fr = Run(m, Boss(3), 3);
        Assert.True(!fr.Layers.ContainsKey("rock_lead") && !fr.Layers.ContainsKey("percussion") && !fr.Layers.ContainsKey("bass_weight"), "intense stems removed");
        Assert.True(fr.Layers.ContainsKey("bed") && fr.Layers.ContainsKey("pulse"), "bed and pulse remain");
        Assert.Near(0.6, fr.Layers["bed"], 1e-9, "bed at 0.6 base is Essential: not scaled");
        Assert.Near(0.6, fr.Layers["pulse"], 1e-9, "pulse 1.0 * 0.6");
    }

    public static void NullInputThrowsAndRegionArrivalNeverFiresDuringCombatOrOnFirstTick()
    {
        var m = Make();
        Assert.Throws<ArgumentNullException>(() => m.Update(0.5, null), "null input");
        var first = m.Update(0.5, Calm());
        Assert.True(!first.Stingers.Contains("mus_stinger_region_arrival"), "no arrival cue on the first tick");
        var f = Fight(); f.Region = "reg_other";
        Assert.True(!m.Update(0.5, f).Stingers.Contains("mus_stinger_region_arrival"), "no arrival cue in combat");
    }

    public static void CompanionThemeNeverAppearsInBossOrCutscene()
    {
        var m = Make(); var b = Boss(1); b.CompanionId = "cmp_lyra";
        var fr = Run(m, b, 2);
        Assert.True(fr.CompanionThemeEvent == null && !fr.Layers.ContainsKey("companion_theme"), "no theme in boss");
        var cs = Calm(); cs.CutsceneActive = true; cs.CompanionId = "cmp_lyra";
        Assert.True(m.Update(0.5, cs).CompanionThemeEvent == null, "no theme in cutscene");
    }
}

[Tests]
static class WaveDQaEnvironmentTests
{
    static EnvironmentAudio Env() => new EnvironmentAudio(AudioData.Env());

    public static void EqualPriorityZonesTieToTheLowerIdInAnyOrder()
    {
        var e = Env();
        Assert.Equal("forest_canopy", e.ResolveZone(new[] { "town_street", "forest_canopy" }).Id, "ab");
        Assert.Equal("forest_canopy", e.ResolveZone(new[] { "forest_canopy", "town_street" }).Id, "ba");
        Assert.Equal("cave", e.ResolveZone(new[] { "ruin_interior", "cave" }).Id, "cave");
        Assert.Equal("cave", e.ResolveZone(new[] { "cave", "ruin_interior" }).Id, "cave");
        Assert.Equal("stone_hall", e.ResolveZone(new[] { "wood_room", "stone_hall" }).Id, "stone_hall < wood_room");
        Assert.Equal("stone_hall", e.ResolveZone(new[] { "stone_hall", "wood_room" }).Id, "stone_hall < wood_room reversed");
    }

    public static void HigherPriorityAlwaysWinsAndDuplicatesAreHarmless()
    {
        var e = Env();
        Assert.Equal("cave", e.ResolveZone(new[] { "town_street", "cave", "forest_canopy", "cave", "open_air" }).Id, "cave");
        Assert.Equal("open_air", e.ResolveZone(new[] { "open_air", "open_air" }).Id, "open air twice");
    }

    public static void UnknownNullAndEmptyZoneIdsFallBackToOpenAir()
    {
        var e = Env();
        Assert.Equal("open_air", e.ResolveZone(null).Id, "null list");
        Assert.Equal("open_air", e.ResolveZone(new string[0]).Id, "empty list");
        Assert.Equal("open_air", e.ResolveZone(new string[] { null, "", "nope" }).Id, "garbage ids");
        Assert.Equal("forest_canopy", e.ResolveZone(new string[] { null, "nope", "forest_canopy" }).Id, "garbage beside a real zone");
    }

    public static void AmbienceIsSafeForUnknownInputsAndGainsStayInRange()
    {
        var e = Env();
        var fr = e.Ambience(new AmbienceInput { Terrain = "nowhere", Weather = "meteor_shower", DayPart = (DayPart)99, Zones = new[] { "ghost" } });
        Assert.Equal("open_air", fr.ZoneId, "zone");
        var fr2 = e.Ambience(new AmbienceInput { Terrain = null, Weather = null, Zones = null });
        Assert.Equal("open_air", fr2.ZoneId, "all nulls");
        foreach (var terrain in EnvironmentRules.MapTerrain.Concat(new string[] { null, "x" }))
            foreach (var w in e.WeatherIds.Concat(new string[] { null, "x" }))
                foreach (DayPart dp in Enum.GetValues(typeof(DayPart)))
                    foreach (var z in new[] { null, "cave", "wood_room", "town_street", "forest_canopy", "open_air" })
                    {
                        var a = e.Ambience(new AmbienceInput { Terrain = terrain, Weather = w, DayPart = dp, Zones = z == null ? null : new[] { z } });
                        Assert.True(a.Layers.Values.All(g => g >= EnvironmentRules.GainFloor && g <= 1), $"gain range {terrain}/{w}/{dp}/{z}");
                    }
    }

    public static void IndoorZonesSilenceTheStormAndTheBiomeBed()
    {
        var e = Env();
        var open = e.Ambience(new AmbienceInput { Terrain = "forest", Weather = "storm" });
        var cave = e.Ambience(new AmbienceInput { Terrain = "forest", Weather = "storm", Zones = new[] { "cave" } });
        Assert.True(open.Layers.Keys.Any(k => k.Contains("rain")), "storm outside is rainy");
        Assert.True(!cave.Layers.Keys.Any(k => k.Contains("rain") || k.Contains("thunder")), "cave gain 0 silences the storm");
        Assert.True(cave.Indoor, "indoor flag");
    }

    public static void SurfaceHelpersFallBackForUnknownInput()
    {
        var e = Env();
        Assert.Equal("grass", e.ResolveSurface("moon_dust"), "unknown terrain -> fallback");
        Assert.Equal("grass", e.ResolveSurface(null), "null terrain");
        Assert.Equal("sfx_step_grass_walk", e.FootstepEvent("lava", "moonwalk"), "unknown surface and gait");
        Assert.Equal("sfx_step_grass_walk", e.FootstepEvent(null, null), "nulls");
        Assert.Equal("sfx_land_grass", e.LandEvent("lava"), "unknown land surface");
        Assert.Equal("shallow_water", e.ResolveSurface("desert", new SurfaceContext { InShallowWater = true, OnRoad = true, InteriorFloor = "wood" }), "water beats road and interior");
        Assert.Equal("wood", e.ResolveSurface("desert", new SurfaceContext { OnRoad = true, InteriorFloor = "wood" }), "interior beats road");
        Assert.Equal("cobble", e.ResolveSurface("desert", new SurfaceContext { OnRoad = true, InteriorFloor = "carpet" }), "unknown interior floor falls to road");
        Assert.Equal("sand", e.ResolveSurface("desert", new SurfaceContext { InteriorFloor = "carpet" }), "unknown interior floor falls to terrain");
    }

    public static void WetOverlayNeedsWetWeatherWettableSurfaceAndOutdoors()
    {
        var e = Env();
        Assert.True(e.WetOverlay("grass", "rain", false) != null, "wet grass");
        Assert.True(e.WetOverlay("grass", "rain", true) == null, "indoors");
        Assert.True(e.WetOverlay("mud", "rain", false) == null, "mud not wettable");
        Assert.True(e.WetOverlay("grass", "clear", false) == null, "dry weather");
        Assert.True(e.WetOverlay("grass", "typhoon", false) == null, "unknown weather");
        Assert.True(e.WetOverlay("lava", "rain", false) == null, "unknown surface");
        Assert.True(e.WetOverlay(null, "rain", false) == null && e.WetOverlay("grass", null, false) == null, "nulls");
    }
}

[Tests]
static class WaveDQaAccessibilityTests
{
    static SaveGame Load(string json) => SaveRules.Upgrade(JsonSerializer.Deserialize<SaveGame>(json, AudioData.Opts));
    static string Dump(AccessibilitySettings a) => JsonSerializer.Serialize(a, AudioData.Opts);

    public static void MissingAccessibilityFieldGivesDefaults()
    {
        var s = Load("{\"Version\":1,\"Level\":3}");
        Assert.True(s.Accessibility != null, "filled");
        Assert.Equal(Dump(new AccessibilitySettings()), Dump(s.Accessibility), "equals plain defaults");
    }

    public static void NullAccessibilityFieldGivesDefaults()
    {
        var s = Load("{\"Version\":1,\"Accessibility\":null}");
        Assert.Equal(Dump(new AccessibilitySettings()), Dump(s.Accessibility), "null -> defaults");
    }

    public static void EmptyObjectGivesDefaults()
    {
        var s = Load("{\"Accessibility\":{}}");
        Assert.Equal(Dump(new AccessibilitySettings()), Dump(s.Accessibility), "{} -> defaults");
    }

    public static void PartialFieldKeepsWhatItHasAndClampsTheRest()
    {
        var s = Load("{\"Accessibility\":{\"TextScale\":5,\"HudScale\":0.1,\"ScreenShake\":-3,\"Volumes\":{\"Music\":7}}}");
        var a = s.Accessibility;
        Assert.Equal(2.0, a.TextScale, "text scale clamps to max");
        Assert.Equal(0.75, a.HudScale, "hud scale clamps to min");
        Assert.Equal(0.0, a.ScreenShake, "shake clamps to 0");
        Assert.Equal(1.0, a.Volumes.Music, "music volume clamps to 1");
        Assert.Equal(1.0, a.Volumes.Master, "unspecified master volume keeps its default");
        Assert.Equal(0.8, a.Volumes.Ambience, "unspecified ambience keeps its default");
        Assert.True(a.SubtitlesEnabled, "subtitles default on");
    }

    public static void NullNestedObjectsAreRepaired()
    {
        var s = Load("{\"Accessibility\":{\"Volumes\":null,\"ToggleActions\":null}}");
        Assert.True(s.Accessibility.Volumes != null && s.Accessibility.ToggleActions != null, "repaired");
        Assert.Equal(1.0, s.Accessibility.Volumes.Master, "default master");
        Assert.True(!s.Accessibility.IsToggle("sprint"), "no toggles");
    }

    public static void EnumsAsNumbersAndStringsBothLoad()
    {
        var s = Load("{\"Accessibility\":{\"ColorblindPalette\":2,\"SubtitleSize\":\"Large\",\"SubtitleBackground\":0}}");
        Assert.Equal(ColorblindPalette.Deuteranopia, s.Accessibility.ColorblindPalette, "number");
        Assert.Equal(SubtitleSize.Large, s.Accessibility.SubtitleSize, "string");
        Assert.Equal(SubtitleBackground.None, s.Accessibility.SubtitleBackground, "number 0");
        var lower = Load("{\"Accessibility\":{\"SubtitleSize\":\"extralarge\"}}");
        Assert.Equal(SubtitleSize.ExtraLarge, lower.Accessibility.SubtitleSize, "case-insensitive string");
    }

    public static void OutOfRangeEnumNumbersFallBackToTheDefault()
    {
        var s = Load("{\"Accessibility\":{\"ColorblindPalette\":42,\"SubtitleSize\":-1,\"SubtitleBackground\":99}}");
        Assert.Equal(ColorblindPalette.Off, s.Accessibility.ColorblindPalette, "palette");
        Assert.Equal(SubtitleSize.Medium, s.Accessibility.SubtitleSize, "size");
        Assert.Equal(SubtitleBackground.Box, s.Accessibility.SubtitleBackground, "background");
    }

    public static void UnknownAndWrongCaseToggleActionsAreDropped()
    {
        var s = Load("{\"Accessibility\":{\"ToggleActions\":{\"sprint\":true,\"Sprint\":true,\"fly\":true,\"block\":false}}}");
        Assert.True(s.Accessibility.IsToggle("sprint"), "sprint kept");
        Assert.True(!s.Accessibility.IsToggle("fly"), "fly dropped");
        Assert.True(!s.Accessibility.ToggleActions.ContainsKey("fly") && !s.Accessibility.ToggleActions.ContainsKey("Sprint"), "unknown keys gone");
        Assert.Equal(false, s.Accessibility.ToggleActions["block"], "explicit false kept");
        Assert.True(!s.Accessibility.IsToggle(null) && !s.Accessibility.IsToggle("block"), "null / false");
        Assert.Throws<ArgumentException>(() => s.Accessibility.SetToggle("fly", true), "SetToggle refuses non-hold actions");
        Assert.Throws<ArgumentException>(() => s.Accessibility.SetToggle(null, true), "SetToggle refuses null");
    }

    public static void NonFiniteValuesFallBackToDefaultsAndNeverEscapeTheRange()
    {
        var a = new AccessibilitySettings
        {
            TextScale = double.NaN, HudScale = double.PositiveInfinity, DialogueTextSpeed = double.NegativeInfinity,
            ScreenShake = double.NaN, FlashIntensity = double.PositiveInfinity, MotionBlur = double.NegativeInfinity,
            Volumes = new VolumeSettings { Master = double.NaN, Music = double.PositiveInfinity, Effects = -1e300, Ambience = 1e300, Dialogue = double.NaN, Callouts = -0.0001 },
        }.Sanitize();
        Assert.Equal(1.0, a.TextScale, "NaN text scale"); Assert.Equal(1.0, a.HudScale, "inf hud"); Assert.Equal(1.0, a.DialogueTextSpeed, "-inf speed");
        Assert.Equal(0.6, a.ScreenShake, "NaN shake"); Assert.Equal(0.6, a.FlashIntensity, "inf flash"); Assert.Equal(0.3, a.MotionBlur, "-inf blur");
        Assert.Equal(1.0, a.Volumes.Master, "NaN master"); Assert.Equal(0.8, a.Volumes.Music, "inf music"); Assert.Equal(0.0, a.Volumes.Effects, "-1e300");
        Assert.Equal(1.0, a.Volumes.Ambience, "1e300"); Assert.Equal(1.0, a.Volumes.Dialogue, "NaN dialogue"); Assert.Equal(0.0, a.Volumes.Callouts, "tiny negative");
    }

    public static void SanitizeIsIdempotent()
    {
        var a = new AccessibilitySettings
        {
            TextScale = 9, HudScale = -1, DialogueTextSpeed = 0, ScreenShake = 4, FlashIntensity = -4, MotionBlur = 2,
            ColorblindPalette = (ColorblindPalette)77, SubtitleSize = (SubtitleSize)(-5), SubtitleBackground = (SubtitleBackground)9,
            Volumes = new VolumeSettings { Master = 5, Music = -5 },
            ToggleActions = new Dictionary<string, bool> { { "sprint", true }, { "bogus", true } },
        };
        var once = Dump(a.Sanitize());
        var twice = Dump(a.Sanitize());
        Assert.Equal(once, twice, "second Sanitize changes nothing");
        Assert.Equal(once, Dump(JsonSerializer.Deserialize<AccessibilitySettings>(once, AudioData.Opts).Sanitize()), "serialise round trip is stable");
        var save = SaveRules.Upgrade(new SaveGame { Accessibility = a });
        var save2 = SaveRules.Upgrade(save);
        Assert.Equal(Dump(save.Accessibility), Dump(save2.Accessibility), "Upgrade is idempotent for accessibility");
        Assert.True(ReferenceEquals(save, save2), "Upgrade returns the same instance");
    }

    public static void SanitizeKeepsValidValuesUntouchedIncludingBoundaries()
    {
        var a = new AccessibilitySettings { TextScale = 1.37, HudScale = 0.75, ScreenShake = 0, FlashIntensity = 1, ReducedFlash = true, NoCombatMusic = true, ReducedMusicIntensity = true, DyslexiaFont = true };
        var before = Dump(a);
        Assert.True(ReferenceEquals(a, a.Sanitize()), "same instance");
        Assert.Equal(before, Dump(a), "in-range values untouched");
    }

    public static void ReducedFlashCapsEffectiveFlashButNeverRaisesIt()
    {
        var a = new AccessibilitySettings { FlashIntensity = 1.0, ReducedFlash = true };
        Assert.Equal(0.25, a.EffectiveFlash, "capped");
        a.FlashIntensity = 0.1;
        Assert.Equal(0.1, a.EffectiveFlash, "a lower setting is not raised to the cap");
        a.ReducedFlash = false; a.FlashIntensity = 0.9;
        Assert.Equal(0.9, a.EffectiveFlash, "no cap when off");
    }

    public static void MusicPrefsMirrorTheSettingsAndTheMachineHonoursThem()
    {
        var a = new AccessibilitySettings { NoCombatMusic = true, ReducedMusicIntensity = true };
        var p = a.ToMusicPrefs();
        Assert.True(p.NoCombatMusic && p.ReducedIntensity, "copied");
        var m = new MusicMachine(AudioData.Music(), AudioData.Roster(), p);
        Assert.Equal("explore", m.Update(0.5, new MusicInput { InCombat = true, ThreatLevel = 3 }).StateId, "no combat music from settings");
    }

    public static void UpgradeIsSafeOnNullAndFreshSaves()
    {
        Assert.True(SaveRules.Upgrade(null) == null, "null stays null");
        var s = SaveRules.Upgrade(new SaveGame());
        Assert.True(s.Accessibility != null && s.Accessibility.Volumes != null && s.Accessibility.ToggleActions != null, "fresh save is fully populated");
        Assert.Equal(SaveGame.CurrentVersion, s.Version, "version stamped");
    }
}

[Tests]
static class WaveDQaPhotoTests
{
    static PhotoWorldState World(bool companion = false, double hour = 10, string weather = "clear") =>
        new PhotoWorldState { Hour = hour, Weather = weather, HasCompanion = companion };
    static PhotoSession Open(PhotoWorldState w = null) => PhotoSession.Open(AudioData.Photo(), new EnvironmentAudio(AudioData.Env()), w ?? World(), out _);

    public static void OverridesNeverLeakAfterClose()
    {
        var s = Open(World(false, 10, "clear"));
        s.SetHour(3); s.SetWeather("storm"); s.SetUiHidden(true); s.SetElementHidden("compass", true);
        Assert.Equal(3.0, s.EffectiveHour, "override active"); Assert.Equal("storm", s.EffectiveWeather, "override active");
        s.Close();
        Assert.True(!s.IsOpen && !s.HasOverrides, "closed, no overrides");
        Assert.Equal(10.0, s.EffectiveHour, "live hour restored"); Assert.Equal("clear", s.EffectiveWeather, "live weather restored");
        Assert.True(!s.UiHidden && !s.IsHidden("compass") && !s.IsHidden("hud"), "UI hiding gone");
        Assert.True(!s.ChangesSaveState, "never touches the save");
    }

    public static void ClosedSessionRefusesEveryMutationWithoutLeaking()
    {
        var s = Open(); s.Close();
        Assert.Throws<InvalidOperationException>(() => s.SetHour(5), "SetHour");
        Assert.Throws<InvalidOperationException>(() => s.SetWeather("rain"), "SetWeather");
        Assert.Throws<InvalidOperationException>(() => s.SetFov(40), "SetFov");
        Assert.Throws<InvalidOperationException>(() => s.SelectPose("pose_wave"), "SelectPose");
        Assert.Throws<InvalidOperationException>(() => s.SelectFilter("filter_none"), "SelectFilter");
        Assert.Throws<InvalidOperationException>(() => s.SelectFrame("frame_none"), "SelectFrame");
        Assert.Throws<InvalidOperationException>(() => s.SetUiHidden(true), "SetUiHidden");
        Assert.Throws<InvalidOperationException>(() => s.SetElementHidden("hud", true), "SetElementHidden");
        Assert.Throws<InvalidOperationException>(() => s.ClearOverrides(), "ClearOverrides");
        Assert.Throws<InvalidOperationException>(() => s.Capture(), "Capture");
        Assert.True(!s.HasOverrides && s.UiHidden == false, "nothing leaked from the refused calls");
    }

    public static void DoubleCloseIsHarmless()
    {
        var s = Open(); s.SetHour(5); s.Close(); s.Close();
        Assert.True(!s.IsOpen && !s.HasOverrides, "still closed and clean");
        Assert.Equal(10.0, s.EffectiveHour, "live hour");
    }

    public static void ANewSessionNeverInheritsTheLastSessionsOverrides()
    {
        var f = AudioData.Photo(); var env = new EnvironmentAudio(AudioData.Env()); var w = World(true, 7, "fog");
        var a = PhotoSession.Open(f, env, w, out _); a.SetHour(22); a.SetWeather("storm"); a.SelectFilter("filter_anime_cel", 0.2); a.SetFov(30); a.Close();
        var b = PhotoSession.Open(f, env, w, out _);
        Assert.True(!b.HasOverrides, "fresh overrides");
        Assert.Equal(7.0, b.EffectiveHour, "live hour"); Assert.Equal("fog", b.EffectiveWeather, "live weather");
        Assert.Equal(f.Tuning.FovDefault, b.Fov, "fov default"); Assert.Equal("filter_none", b.FilterId, "filter default");
        Assert.Equal(f.Tuning.FilterIntensityDefault, b.FilterIntensity, "intensity default"); Assert.True(b.PoseId == null, "no pose");
        Assert.Equal(1, b.Capture().Number, "shot numbers restart per session");
    }

    public static void SessionDoesNotMutateTheWorldState()
    {
        var w = World(true, 12, "rain");
        var s = PhotoSession.Open(AudioData.Photo(), new EnvironmentAudio(AudioData.Env()), w, out _);
        s.SetHour(1); s.SetWeather("snow"); s.Close();
        Assert.Equal(12.0, w.Hour, "world hour untouched"); Assert.Equal("rain", w.Weather, "world weather untouched");
    }

    public static void HourAtTwentyFourAndFriendsWrapToTheClock()
    {
        var s = Open();
        s.SetHour(24); Assert.Equal(0.0, s.EffectiveHour, "24 -> 0");
        s.SetHour(23.99); Assert.Equal(0.0, s.EffectiveHour, "23.99 snaps to 24 -> 0, never 24");
        s.SetHour(23.875); Assert.Equal(0.0, s.EffectiveHour, "23.875 rounds to 24 -> 0");
        s.SetHour(23.75); Assert.Equal(23.75, s.EffectiveHour, "23.75 stays");
        s.SetHour(-1); Assert.Equal(23.0, s.EffectiveHour, "-1 -> 23");
        s.SetHour(48.25); Assert.Equal(0.25, s.EffectiveHour, "48.25 -> 0.25");
        foreach (var h in new[] { 0.0, 0.1, 5.99, 11.9999, 23.9999, 24, 24.0001, -0.0001, 1e9, -1e9, double.NaN, double.PositiveInfinity, double.NegativeInfinity })
        {
            s.SetHour(h);
            Assert.True(s.EffectiveHour >= 0 && s.EffectiveHour < 24, $"hour {h} stays in [0,24): {s.EffectiveHour}");
        }
    }

    public static void LiveHourOf24OrJunkIsWrappedToo()
    {
        Assert.Equal(0.0, Open(World(false, 24)).EffectiveHour, "live 24");
        Assert.Equal(2.0, Open(World(false, 26)).EffectiveHour, "live 26");
        Assert.Equal(23.0, Open(World(false, -1)).EffectiveHour, "live -1");
        Assert.Equal(0.0, Open(World(false, double.NaN)).EffectiveHour, "live NaN");
    }

    public static void CompanionAndPairPosesAreRefusedWithoutACompanion()
    {
        var f = AudioData.Photo(); var s = Open(World(false));
        Assert.True(s.SelectPose("pose_wave"), "player pose ok");
        foreach (var p in f.Poses.Where(p => p.Target != "player"))
        {
            Assert.True(!s.SelectPose(p.Id), $"{p.Id} ({p.Target}) needs a companion");
            Assert.Equal("pose_wave", s.PoseId, $"the earlier pose survives the refused {p.Id}");
        }
        var c = Open(World(true));
        foreach (var p in f.Poses) Assert.True(c.SelectPose(p.Id), $"{p.Id} allowed with a companion");
    }

    public static void BadPoseFilterFrameWeatherIdsAreRefusedAndChangeNothing()
    {
        var s = Open(); s.SelectPose("pose_wave"); s.SelectFilter("filter_anime_cel", 0.4); s.SelectFrame("frame_parchment"); s.SetWeather("rain");
        Assert.True(!s.SelectPose(null) && !s.SelectPose("") && !s.SelectPose("pose_nope"), "bad poses");
        Assert.True(!s.SelectFilter(null) && !s.SelectFilter("filter_nope"), "bad filters");
        Assert.True(!s.SelectFrame(null) && !s.SelectFrame("frame_nope"), "bad frames");
        Assert.True(!s.SetWeather(null) && !s.SetWeather("") && !s.SetWeather("Rain") && !s.SetWeather("nope"), "bad weather");
        Assert.True(!s.SetElementHidden(null, true) && !s.SetElementHidden("nothing", true), "bad element");
        Assert.Equal("pose_wave", s.PoseId, "pose kept"); Assert.Equal("filter_anime_cel", s.FilterId, "filter kept");
        Assert.Near(0.4, s.FilterIntensity, 1e-9, "intensity kept"); Assert.Equal("frame_parchment", s.FrameId, "frame kept"); Assert.Equal("rain", s.EffectiveWeather, "weather kept");
    }

    public static void FovAndFilterIntensityClamp()
    {
        var f = AudioData.Photo(); var s = Open();
        s.SetFov(-5); Assert.Equal(f.Tuning.FovMin, s.Fov, "min"); s.SetFov(500); Assert.Equal(f.Tuning.FovMax, s.Fov, "max");
        s.SetFov(double.NaN); Assert.Equal(f.Tuning.FovDefault, s.Fov, "NaN -> default");
        s.SetFov(double.PositiveInfinity); Assert.Equal(f.Tuning.FovMax, s.Fov, "inf -> max");
        s.SelectFilter("filter_anime_cel", 7); Assert.Equal(1.0, s.FilterIntensity, "intensity max");
        s.SelectFilter("filter_anime_cel", -7); Assert.Equal(0.0, s.FilterIntensity, "intensity min");
        s.SelectFilter("filter_none"); Assert.Equal(f.Tuning.FilterIntensityDefault, s.FilterIntensity, "default when unspecified");
    }

    public static void CaptureCarriesTheEffectiveLookAndCountsUp()
    {
        var s = Open(World(true, 9, "clear")); s.SelectPose("pose_campfire_sit"); s.SetHour(21); s.SetWeather("snow"); s.SetUiHidden(true);
        var a = s.Capture(); var b = s.Capture();
        Assert.Equal(1, a.Number, "first"); Assert.Equal(2, b.Number, "second");
        Assert.Equal(21.0, a.Hour, "override hour"); Assert.Equal("snow", a.Weather, "override weather"); Assert.True(a.UiHidden, "ui hidden"); Assert.Equal("pose_campfire_sit", a.PoseId, "pose");
        s.ClearOverrides();
        var c = s.Capture();
        Assert.Equal(9.0, c.Hour, "cleared back to live hour"); Assert.Equal("clear", c.Weather, "cleared back to live weather");
    }

    public static void ShowingTheUiAgainClearsIndividualHides()
    {
        var s = Open(); s.SetElementHidden("compass", true);
        Assert.True(s.IsHidden("compass") && !s.IsHidden("hud"), "only the compass hidden");
        s.SetUiHidden(true); Assert.True(s.IsHidden("hud") && s.IsHidden("compass"), "all hidden");
        s.SetUiHidden(false); Assert.True(!s.IsHidden("compass"), "restored");
        s.ToggleUiHidden(); Assert.True(s.UiHidden, "toggle on"); s.ToggleUiHidden(); Assert.True(!s.UiHidden, "toggle off");
    }

    public static void OpenRefusesEveryBlockerAndReportsTheFirstOne()
    {
        var f = AudioData.Photo(); var env = new EnvironmentAudio(AudioData.Env());
        Assert.True(PhotoSession.Open(f, env, null, out var r0) == null && r0 == "no world", "null world");
        Assert.True(PhotoSession.Open(f, env, new PhotoWorldState { InCombat = true, CutsceneActive = true, SiegeBattle = true, InDialogue = true }, out var r1) == null && r1 == "combat", "first blocker is combat");
        Assert.True(PhotoSession.Open(f, env, new PhotoWorldState { CutsceneActive = true, InDialogue = true }, out var r2) == null && r2 == "cutscene", "cutscene before dialogue");
        Assert.Throws<ArgumentNullException>(() => PhotoSession.Open(null, env, World(), out _), "null file");
        Assert.Throws<ArgumentNullException>(() => PhotoSession.Open(f, null, World(), out _), "null env");
    }

    public static void NullWeatherInTheWorldReadsAsClear()
    {
        var s = Open(new PhotoWorldState { Hour = 5, Weather = null });
        Assert.Equal("clear", s.EffectiveWeather, "null live weather");
    }
}

// Probes for suspected bugs. Flip the attribute on once the owning agent has fixed them.
[Tests]
static class WaveDQaKnownBugs
{
    static MusicMachine Make() => new MusicMachine(AudioData.Music(), AudioData.Roster());
    static MusicInput Calm() => new MusicInput { Region = "reg_ashira_vale" };
    static MusicInput Fight(int threat = 2) => new MusicInput { InCombat = true, ThreatLevel = threat, Region = "reg_ashira_vale" };
    static MusicFrame Run(MusicMachine m, MusicInput i, double seconds)
    {
        MusicFrame f = null;
        for (double t = 0; t < seconds - 1e-9; t += 0.5) { f = m.Update(0.5, i); i.Outcome = CombatOutcome.None; }
        return f ?? m.Update(0, i);
    }

    // BUG B: PlayerAdvantage latches outside combat; a fight starting within the 3 s off delay shows the advantage stem at once.
    public static void StaleAdvantageFromExplorationDoesNotColourTheNextFight()
    {
        var m = Make(); Run(m, Calm(), 3);
        var adv = Calm(); adv.PlayerAdvantage = true; m.Update(0.5, adv);
        var fr = m.Update(0.5, Fight());
        Assert.True(!fr.Layers.ContainsKey("advantage_perc"), "advantage_perc present on the first combat tick");
    }

    // BUG C: SelectFilter does not guard NaN intensity (SetFov does); FilterIntensity becomes NaN.
    public static void NaNFilterIntensityIsClamped()
    {
        var s = PhotoSession.Open(AudioData.Photo(), new EnvironmentAudio(AudioData.Env()), new PhotoWorldState { Hour = 8 }, out _);
        s.SelectFilter("filter_anime_cel", double.NaN);
        Assert.True(!double.IsNaN(s.FilterIntensity), "FilterIntensity is NaN");
    }

    // NOTE D: region null in the middle (a -> null -> b) resets _region, so b gets no arrival stinger.
    public static void RegionArrivalSurvivesATransientNullRegion()
    {
        var m = Make(); Run(m, Calm(), 3);
        var n = Calm(); n.Region = null; m.Update(0.5, n);
        var b = Calm(); b.Region = "reg_other";
        Assert.True(m.Update(0.5, b).Stingers.Contains("mus_stinger_region_arrival"), "no arrival stinger after null region");
    }
}


