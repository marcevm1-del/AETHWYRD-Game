using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using Ascend.Core;

// Wave D: adaptive music, environmental audio, accessibility and photo mode (12_Systems/audio_and_immersion.md).
static class AudioData
{
    public static readonly JsonSerializerOptions Opts = new() { PropertyNameCaseInsensitive = true, Converters = { new JsonStringEnumConverter() } };
    static T Load<T>(string rel) => JsonSerializer.Deserialize<T>(File.ReadAllText(Path.Combine(Repo.Root(), rel)), Opts);
    public static MusicFile Music() => Load<MusicFile>("Data/Audio/music_states.json");
    public static EnvironmentFile Env() => Load<EnvironmentFile>("Data/Audio/environment_audio.json");
    public static AccessibilityFile Access() => Load<AccessibilityFile>("Data/Audio/accessibility.json");
    public static PhotoFile Photo() => Load<PhotoFile>("Data/Audio/photo_mode.json");
    public static List<string> Roster() => Load<List<CompanionData>>("Data/Companions/companions.json").Select(c => c.Id).ToList();
}

[Tests]
static class AdaptiveMusicTests
{
    static MusicMachine Make(MusicPrefs prefs = null) => new MusicMachine(AudioData.Music(), AudioData.Roster(), prefs);
    static MusicInput Calm() => new MusicInput { Region = "reg_ashira_vale" };
    static MusicInput Fight(int threat = 2) => new MusicInput { InCombat = true, ThreatLevel = threat, Region = "reg_ashira_vale" };

    /// <summary>Runs <paramref name="seconds"/> in 0.5 s ticks and returns the last frame.</summary>
    static MusicFrame Run(MusicMachine m, MusicInput i, double seconds)
    {
        MusicFrame f = null;
        for (double t = 0; t < seconds - 1e-9; t += 0.5) { f = m.Update(0.5, i); i.Outcome = CombatOutcome.None; }
        return f ?? m.Update(0, i);
    }

    public static void ShippedDataValidatesAgainstTheRoster()
    {
        var errors = MusicRules.Validate(AudioData.Music(), AudioData.Roster());
        Assert.True(errors.Count == 0, string.Join("; ", errors));
    }

    public static void BadDataIsCaught()
    {
        var roster = AudioData.Roster();
        var f = AudioData.Music(); f.States.RemoveAll(s => s.Id == "rest");
        Assert.True(MusicRules.Validate(f, roster).Any(e => e.Contains("missing state rest")), "missing state");
        f = AudioData.Music(); f.States.First(s => s.Id == "combat").Layers["rock_lead"] = 1;
        Assert.True(MusicRules.Validate(f, roster).Any(e => e.Contains("boss-only")), "rock stem outside boss");
        f = AudioData.Music(); f.Overlays.Danger.ExitAboveHp = f.Overlays.Danger.EnterBelowHp;
        Assert.True(MusicRules.Validate(f, roster).Any(e => e.Contains("hysteresis")), "no HP hysteresis");
        f = AudioData.Music(); f.States.First(s => s.Id == "combat").ExitDelaySeconds = 0;
        Assert.True(MusicRules.Validate(f, roster).Any(e => e.Contains("exit delay")), "combat without exit delay");
        f = AudioData.Music(); f.CompanionThemes.Add("cmp_nobody");
        Assert.True(MusicRules.Validate(f, roster).Any(e => e.Contains("not in the roster")), "theme for a stranger");
        f = AudioData.Music(); f.Crossfades["explore>nowhere"] = 1;
        Assert.True(MusicRules.Validate(f, roster).Any(e => e.Contains("unknown state")), "crossfade to nowhere");
        Assert.Throws<ArgumentException>(() => new MusicMachine(f), "the machine refuses invalid data");
    }

    public static void EveryRosterCompanionHasATheme_AndOnlyRosterCompanions()
    {
        var f = AudioData.Music(); var roster = AudioData.Roster();
        Assert.Equal(14, roster.Count, "roster size");
        Assert.True(roster.All(f.CompanionThemes.Contains) && f.CompanionThemes.All(roster.Contains), "themes match the roster exactly");
        var m = Make();
        var i = Calm(); i.CompanionId = "cmp_lyra";
        var fr = Run(m, i, 2);
        Assert.Equal("mus_companion_lyra", fr.CompanionThemeEvent, "theme event");
        Assert.True(fr.Layers.ContainsKey("companion_theme"), "theme layer on");
        i.CompanionId = "cmp_stranger";
        Assert.True(Run(m, i, 1).CompanionThemeEvent == null, "unknown companion gets no theme");
    }

    public static void CompanionThemeStaysOutOfCombat()
    {
        var m = Make(); var i = Fight(); i.CompanionId = "cmp_kiri";
        var fr = Run(m, i, 2);
        Assert.Equal("combat", fr.StateId, "combat");
        Assert.True(fr.CompanionThemeEvent == null && !fr.Layers.ContainsKey("companion_theme"), "no companion theme under combat music");
    }

    public static void ExploreToCombatIsImmediateAndCrossfadeComesFromData()
    {
        var m = Make(); Run(m, Calm(), 3);
        var fr = m.Update(0.1, Fight());
        Assert.Equal("combat", fr.StateId, "combat at once");
        Assert.Equal("explore", fr.Transition.From, "from");
        Assert.Near(0.6, fr.Transition.CrossfadeSeconds, 1e-9, "explore>combat crossfade");
        Assert.True(fr.Layers.ContainsKey("percussion") && fr.Layers.ContainsKey("pulse"), "combat layers on");
    }

    public static void CombatSurvivesAFlickerAndMinHold()
    {
        var m = Make(); Run(m, Fight(), 2);
        var calm = Calm();
        Assert.Equal("combat", Run(m, calm, 3).StateId, "3 s of quiet: still combat");
        Assert.Equal("combat", Run(m, Fight(), 1).StateId, "back in the fight: the wait resets");
        // exit delay 6 s AND min hold 8 s: 5.5 s quiet after >8 s held is not enough
        var m2 = Make(); Run(m2, Fight(), 9);
        Assert.Equal("combat", Run(m2, Calm(), 5.5).StateId, "5.5 s quiet < exit delay");
        Assert.True(Run(m2, Calm(), 1).StateId != "combat", "6.5 s quiet: leaves combat");
    }

    public static void MinHoldBlocksAnEarlyExit()
    {
        var m = Make(); Run(m, Fight(), 0.5);
        // 7 s after combat began (<8 s hold) with a quiet field for 6.5 s: the hold still blocks the exit
        var fr = Run(m, Calm(), 6.5);
        Assert.Equal("combat", fr.StateId, "held < 8 s");
        Assert.True(Run(m, Calm(), 1.5).StateId != "combat", "after the hold the exit goes through");
    }

    public static void UncertaintyDoesNotFlapOnFlicker()
    {
        var m = Make(); Run(m, Calm(), 3);
        for (int k = 0; k < 20; k++)
        {
            var i = Calm(); i.ThreatLevel = k % 2 == 0 ? 1 : 0;
            Assert.Equal("explore", m.Update(0.5, i).StateId, "a flickering clue never starts the tense layer");
        }
        var steady = Calm(); steady.ThreatLevel = 1;
        Assert.Equal("uncertainty", Run(m, steady, 2.5).StateId, "a steady uneasy threat does");
    }

    public static void VictoryResolvesThenReturnsToTheWorld()
    {
        var m = Make(); Run(m, Fight(), 10);
        var calm = Calm(); calm.Outcome = CombatOutcome.Victory;
        var fr = m.Update(0.5, calm);
        Assert.Equal("aftermath", fr.StateId, "victory resolves at once");
        Assert.True(fr.Stingers.Contains("mus_stinger_victory"), "victory stinger");
        Assert.True(fr.Layers.ContainsKey("resolve"), "resolve layer");
        Assert.Equal("aftermath", Run(m, Calm(), 4).StateId, "aftermath holds its minimum");
        var back = Run(m, Calm(), 3);
        Assert.Equal("explore", back.StateId, "then the world score returns");
        Assert.Near(4.0, back.Transition?.CrossfadeSeconds ?? 4.0, 1e-9, "slow aftermath>explore crossfade");
    }

    public static void ANewFightInterruptsTheAftermath()
    {
        var m = Make(); Run(m, Fight(), 10);
        var calm = Calm(); calm.Outcome = CombatOutcome.Victory; m.Update(0.5, calm);
        Assert.Equal("combat", m.Update(0.5, Fight()).StateId, "combat outranks the aftermath");
    }

    public static void RetreatReturnsMoreGraduallyThanAWin()
    {
        int Seconds(CombatOutcome o)
        {
            var m = Make(); Run(m, Fight(), 10);
            var calm = Calm(); calm.Outcome = o; m.Update(0.5, calm);
            int n = 0;
            while (m.CurrentState == "combat" && n < 100) { m.Update(1, Calm()); n++; }
            return n;
        }
        int normal = Seconds(CombatOutcome.None), retreat = Seconds(CombatOutcome.Retreat);
        Assert.True(retreat > normal, $"retreat ({retreat}s) must take longer than a plain exit ({normal}s)");
        Assert.True(retreat >= 12, "retreat exit delay is 12 s");
    }

    public static void ASmallEnemyNeverTriggersTheBossTransition()
    {
        var m = Make();
        foreach (var threat in new[] { 1, 2, 3, 4 })
        {
            var fr = Run(m, Fight(threat), 3);
            Assert.True(fr.StateId != "boss", $"threat {threat} without a boss phase is not a boss");
            Assert.True(!fr.Layers.ContainsKey("rock_lead"), "no rock stem outside the boss");
        }
        Assert.Equal("elite", Run(Make(), Fight(3), 1).StateId, "named hunt = elite");
        Assert.True(Run(Make(), Fight(3), 0.5).Stingers != null, "stinger list is never null");
    }

    public static void BossPhasesFollowGameplayStateAndAddLayers()
    {
        var m = Make();
        var i = Fight(4); i.BossPhase = 1;
        var f1 = Run(m, i, 2);
        Assert.Equal("boss", f1.StateId, "boss");
        Assert.True(new MusicMachine(AudioData.Music()).Update(0.1, i).Stingers.Contains("mus_stinger_boss_intro"), "boss intro stinger on entry");
        Assert.True(!f1.Layers.ContainsKey("rock_lead"), "phase 1 has no rock stem yet");
        i.BossPhase = 2;
        var f2 = m.Update(0.5, i);
        Assert.True(f2.Stingers.Contains("mus_stinger_boss_phase"), "phase change cue");
        Assert.True(f2.Layers.ContainsKey("rock_lead") && f2.Layers.ContainsKey("motif"), "phase 2 adds the rock stem on top of phase 1");
        Assert.Near(0.9, f2.Layers["rock_lead"], 1e-9, "phase 2 rock gain");
        i.BossPhase = 3;
        var f3 = m.Update(0.5, i);
        Assert.Near(1.0, f3.Layers["rock_lead"], 1e-9, "phase 3 rock gain");
        i.BossPhase = 9;
        Assert.Near(1.0, m.Update(0.5, i).Layers["rock_lead"], 1e-9, "phases past the list keep the last set");
        // no timestamp drives it: the same phase held for a minute adds nothing
        var late = Run(m, i, 60);
        Assert.True(late.Stingers.Count == 0, "no cue without a phase change");
    }

    public static void BossAlwaysOutranksOrdinaryFightsAndRetreatIsSlow()
    {
        var m = Make(); Run(m, Fight(), 2);
        var i = Fight(4); i.BossPhase = 1;
        Assert.Equal("boss", m.Update(0.1, i).StateId, "boss takes over a normal fight at once");
        Assert.Equal("boss", Run(m, Fight(2), 5).StateId, "boss phase input dropping does not flap the score");
    }

    public static void OnlyOneStateOwnsTheScore()
    {
        var m = Make();
        var i = Fight(4); i.BossPhase = 1; i.CutsceneActive = true; i.Place = PlaceKind.Town; i.ThreatLevel = 4;
        var fr = m.Update(0.1, i);
        Assert.Equal("cutscene", fr.StateId, "the cutscene outranks everything");
        Assert.True(fr.Layers.Keys.All(k => k != "rock_lead" && k != "percussion"), "no combat layers under a cutscene");
    }

    public static void AdvantageAndDangerOverlaysUseHysteresis()
    {
        var m = Make(); var i = Fight(); Run(m, i, 2);
        i.PlayerAdvantage = true;
        Assert.True(m.Update(0.5, i).Layers.ContainsKey("advantage_perc"), "advantage on at once");
        i.PlayerAdvantage = false;
        Assert.True(m.Update(2, i).Layers.ContainsKey("advantage_perc"), "still on 2 s after (off delay 3 s)");
        Assert.True(!m.Update(1.5, i).Layers.ContainsKey("advantage_perc"), "off after the delay");
        i.PlayerHpFraction = 0.29;
        Assert.True(m.Update(0.5, i).Layers.ContainsKey("bass_weight"), "danger below 30% HP");
        i.PlayerHpFraction = 0.40;
        Assert.True(m.Update(0.5, i).Layers.ContainsKey("bass_weight"), "still danger at 40% (exit is 45%)");
        i.PlayerHpFraction = 0.50;
        Assert.True(!m.Update(0.5, i).Layers.ContainsKey("bass_weight"), "danger ends above 45%");
        // overlays never show outside a fight
        var calm = Calm(); calm.PlayerAdvantage = true; calm.PlayerHpFraction = 0.1;
        var fr = Run(m, calm, 20);
        Assert.True(fr.StateId != "combat" && !fr.Layers.ContainsKey("advantage_perc") && !fr.Layers.ContainsKey("bass_weight"), "no overlays in the world score");
    }

    public static void NoCombatMusicKeepsTheWorldScore()
    {
        var m = Make(new MusicPrefs { NoCombatMusic = true });
        var i = Fight(4); i.BossPhase = 2;
        var fr = Run(m, i, 5);
        Assert.Equal("explore", fr.StateId, "boss fight, but the option keeps the explore score");
        Assert.True(!fr.Layers.ContainsKey("percussion") && !fr.Layers.ContainsKey("rock_lead"), "no combat layers");
        var calm = Calm(); calm.Outcome = CombatOutcome.Victory;
        Assert.Equal("explore", m.Update(0.5, calm).StateId, "no victory stinger either");
    }

    public static void ReducedIntensityDropsIntenseLayersAndSoftensTheRest()
    {
        var full = Run(Make(), Fight(3), 2);
        var soft = Run(Make(new MusicPrefs { ReducedIntensity = true }), Fight(3), 2);
        Assert.Equal("elite", soft.StateId, "same state");
        Assert.True(full.Layers.ContainsKey("percussion") && !soft.Layers.ContainsKey("percussion"), "intense layers dropped");
        Assert.True(!soft.Layers.ContainsKey("strings_drive"), "strings drive dropped");
        Assert.Near(full.Layers["pulse"] * 0.6, soft.Layers["pulse"], 1e-9, "pulse scaled by the data factor");
        Assert.Near(full.Layers["bed"], soft.Layers["bed"], 1e-9, "essential bed untouched");
    }

    public static void PlacesTimeOfDayAndRegionDriveTheWorldScore()
    {
        var i = Calm(); i.Place = PlaceKind.Town; i.DayPart = DayPart.Night;
        var town = Run(Make(), i, 3);
        Assert.Equal("town", town.StateId, "town");
        Assert.Equal("night", town.Variant, "town stems split by the time of day");
        Assert.Equal("mus_motif_reg_ashira_vale", town.RegionMotifEvent, "regional identity");
        i.Place = PlaceKind.Rest; Assert.Equal("rest", Run(Make(), i, 3).StateId, "rest");
        i.Place = PlaceKind.Interior; Assert.Equal("dungeon", Run(Make(), i, 3).StateId, "interior");
        Assert.True(Run(Make(), i, 3).Variant == null, "dungeon stems do not split by the time of day");
        i.Place = PlaceKind.Wilderness; i.DayPart = DayPart.Morning;
        Assert.Equal("morning", Run(Make(), i, 3).Variant, "explore variant");
    }

    public static void RegionArrivalStingerIsCalmOnlyAndNeverOnTheFirstTick()
    {
        var m = Make();
        var i = Calm();
        Assert.True(m.Update(0.5, i).Stingers.Count == 0, "first tick (a save load) is silent");
        i.Region = "reg_stormreach";
        Assert.True(m.Update(0.5, i).Stingers.Contains("mus_stinger_region_arrival"), "arrival cue");
        var f = Fight(); f.Region = "reg_other";
        Assert.True(!m.Update(0.5, f).Stingers.Contains("mus_stinger_region_arrival"), "none in a fight");
    }

    public static void TheMachineIsDeterministic()
    {
        string Trace()
        {
            var m = Make(); var sb = new System.Text.StringBuilder();
            for (int k = 0; k < 400; k++)
            {
                var i = new MusicInput
                {
                    InCombat = (k / 37) % 2 == 1, ThreatLevel = (k / 13) % 5, BossPhase = k > 300 ? 1 + (k - 300) / 40 : 0,
                    PlayerHpFraction = 1.0 - (k % 50) / 60.0, PlayerAdvantage = k % 7 < 2, Region = (k / 120) % 2 == 0 ? "reg_a" : "reg_b",
                    Outcome = k % 91 == 90 ? CombatOutcome.Victory : CombatOutcome.None,
                };
                var f = m.Update(0.25, i);
                sb.Append(f.StateId).Append(':').Append(string.Join(",", f.Layers.Select(kv => kv.Key + "=" + kv.Value.ToString("0.###", System.Globalization.CultureInfo.InvariantCulture)))).Append('|').Append(string.Join(",", f.Stingers)).Append(';');
            }
            return sb.ToString();
        }
        Assert.Equal(Trace(), Trace(), "same inputs, same score");
    }

    public static void OddInputsDoNotThrow()
    {
        var m = Make();
        var i = new MusicInput { PlayerHpFraction = double.NaN, ThreatLevel = -5, BossPhase = -3, Region = null, CompanionId = null };
        var f = m.Update(double.NaN, i);
        Assert.Equal("explore", f.StateId, "negative threat and phase are calm");
        Assert.Throws<ArgumentNullException>(() => m.Update(1, null), "null input");
        Assert.Equal(0.0, m.Update(-5, Calm()).HeldSeconds, "negative dt is zero");
    }
}

[Tests]
static class EnvironmentAudioTests
{
    static EnvironmentAudio Env() => new EnvironmentAudio(AudioData.Env());

    public static void ShippedDataValidates()
    {
        var errors = EnvironmentRules.Validate(AudioData.Env());
        Assert.True(errors.Count == 0, string.Join("; ", errors));
    }

    public static void TerrainVocabularyMatchesTheMapSchemaAndRegionData()
    {
        var schema = File.ReadAllText(Path.Combine(Repo.Root(), "Tools/validate/build_schemas.js"));
        var m = Regex.Match(schema, @"const MAP_TERRAIN = \[([^\]]+)\]");
        Assert.True(m.Success, "MAP_TERRAIN found in build_schemas.js");
        var fromSchema = Regex.Matches(m.Groups[1].Value, "'([a-z]+)'").Select(x => x.Groups[1].Value).ToList();
        Assert.True(fromSchema.OrderBy(x => x).SequenceEqual(EnvironmentRules.MapTerrain.OrderBy(x => x)), "Core terrain list = MAP_TERRAIN");
        var regions = Repo.Load<List<RegionDataTerrain>>("Data/World/regions.json");
        var used = regions.Where(r => r.Map?.Terrain != null).SelectMany(r => r.Map.Terrain).Distinct().ToList();
        Assert.True(used.Count > 5, "regions use several terrain kinds");
        var env = AudioData.Env();
        foreach (var t in used) Assert.True(env.TerrainSurface.ContainsKey(t) && env.BiomeBeds.ContainsKey(t), $"terrain {t} used by a region has a surface and a bed");
    }

    sealed class RegionDataTerrain { public string Id { get; set; } public MapPart Map { get; set; } }
    sealed class MapPart { public List<string> Terrain { get; set; } }

    public static void EveryTerrainHasAFootstepForEveryGait()
    {
        var e = Env();
        foreach (var t in EnvironmentRules.MapTerrain)
            foreach (var g in new[] { "walk", "run", "sprint" })
            {
                var ev = e.FootstepEvent(e.ResolveSurface(t), g);
                Assert.True(Regex.IsMatch(ev, "^sfx_step_[a-z_]+_(walk|run|sprint)$"), $"{t}/{g} -> {ev}");
            }
        Assert.Equal("sfx_step_leaf_litter_run", e.FootstepEvent(e.ResolveSurface("forest"), "run"), "forest run");
        Assert.Equal("sfx_step_snow_walk", e.FootstepEvent(e.ResolveSurface("tundra"), "walk"), "tundra walk");
        Assert.Equal("sfx_land_ash", e.LandEvent(e.ResolveSurface("volcanic")), "landing");
    }

    public static void UnknownTerrainAndGaitFallBackInsteadOfGoingSilent()
    {
        var e = Env();
        Assert.Equal("grass", e.ResolveSurface("moonscape"), "unknown terrain");
        Assert.Equal("grass", e.ResolveSurface(null), "null terrain");
        Assert.Equal("sfx_step_grass_walk", e.FootstepEvent("nothing", "moonwalk"), "unknown surface and gait");
        Assert.Equal("sfx_land_grass", e.LandEvent(null), "null surface");
    }

    public static void SurfaceContextOverridesTerrainInOrder()
    {
        var e = Env();
        Assert.Equal("shallow_water", e.ResolveSurface("desert", new SurfaceContext { InShallowWater = true, InteriorFloor = "wood", OnRoad = true }), "water beats all");
        Assert.Equal("wood", e.ResolveSurface("desert", new SurfaceContext { InteriorFloor = "wood", OnRoad = true }), "interior beats road");
        Assert.Equal("cobble", e.ResolveSurface("desert", new SurfaceContext { OnRoad = true }), "road beats terrain");
        Assert.Equal("sand", e.ResolveSurface("desert", new SurfaceContext()), "plain terrain");
        Assert.Equal("sand", e.ResolveSurface("desert", new SurfaceContext { InteriorFloor = "lava" }), "unknown interior floor is ignored");
    }

    public static void RainWetsOnlyWettableOutdoorSurfaces()
    {
        var e = Env();
        Assert.Equal("sfx_step_wet_overlay", e.WetOverlay("grass", "rain", false), "rain on grass");
        Assert.Equal("sfx_step_wet_overlay", e.WetOverlay("rock", "storm", false), "storm on rock");
        Assert.True(e.WetOverlay("grass", "clear", false) == null, "dry day");
        Assert.True(e.WetOverlay("mud", "rain", false) == null, "mud has its own sound");
        Assert.True(e.WetOverlay("grass", "rain", true) == null, "indoors stays dry");
        Assert.True(e.WetOverlay("grass", "fog", false) == null && e.WetOverlay(null, "rain", false) == null && e.WetOverlay("grass", "bogus", false) == null, "no wet from fog, null or unknown");
    }

    public static void WeatherAndTimeOfDayLayerTheAmbience()
    {
        var e = Env();
        var day = e.Ambience(new AmbienceInput { Terrain = "forest", Weather = "clear", DayPart = DayPart.Day });
        var night = e.Ambience(new AmbienceInput { Terrain = "forest", Weather = "clear", DayPart = DayPart.Night });
        Assert.True(day.Layers.ContainsKey("amb_bed_forest") && day.Layers.ContainsKey("amb_insects_day"), "day forest");
        Assert.True(night.Layers.ContainsKey("amb_crickets_night") && !night.Layers.ContainsKey("amb_insects_day"), "night swaps the layers");
        var storm = e.Ambience(new AmbienceInput { Terrain = "plains", Weather = "storm", DayPart = DayPart.Dusk });
        Assert.True(storm.Layers.ContainsKey("amb_rain_heavy") && storm.Layers.ContainsKey("amb_thunder_distant"), "storm layers");
        Assert.Equal("rev_open_air", storm.ReverbPreset, "open air by default");
        Assert.True(e.Ambience(new AmbienceInput { Weather = "weird" }).Layers.Keys.All(k => k.StartsWith("amb_")), "unknown weather plays as clear");
        Assert.True(e.Ambience(new AmbienceInput { Terrain = "nowhere" }).Layers.Keys.All(k => !k.StartsWith("amb_bed_")), "unknown terrain has no bed");
    }

    public static void IndoorZonesMuffleWeatherAndDropTheBiomeBed()
    {
        var e = Env();
        var cave = e.Ambience(new AmbienceInput { Terrain = "forest", Weather = "storm", DayPart = DayPart.Night, Zones = new[] { "cave" } });
        Assert.True(cave.Indoor && cave.ReverbPreset == "rev_cave", "cave reverb");
        Assert.True(!cave.Layers.ContainsKey("amb_rain_heavy") && !cave.Layers.ContainsKey("amb_bed_forest") && !cave.Layers.ContainsKey("amb_crickets_night"), "nothing outdoors leaks into the cave");
        Assert.True(cave.Layers.ContainsKey("amb_cave_drip"), "cave layers");
        var room = e.Ambience(new AmbienceInput { Terrain = "plains", Weather = "rain", Zones = new[] { "wood_room" } });
        Assert.True(room.Layers.TryGetValue("amb_rain_light", out var g) && g > 0 && g < 0.5, "rain muffled but audible through wood");
        Assert.True(!room.Layers.ContainsKey("amb_bed_plains"), "no biome bed indoors");
        var street = e.Ambience(new AmbienceInput { Terrain = "plains", Weather = "clear", DayPart = DayPart.Day, Zones = new[] { "town_street" } });
        Assert.True(street.Layers.ContainsKey("amb_town_murmur") && street.Layers["amb_bed_plains"] < 0.5, "town murmur over a quiet bed");
    }

    public static void OverlappingZonesResolveByPriorityThenId()
    {
        var e = Env();
        Assert.Equal("cave", e.ResolveZone(new[] { "wood_room", "cave", "open_air" }).Id, "highest priority wins");
        Assert.Equal("cave", e.ResolveZone(new[] { "ruin_interior", "cave" }).Id, "tie goes to the lower id");
        Assert.Equal("cave", e.ResolveZone(new[] { "cave", "ruin_interior" }).Id, "order does not matter");
        Assert.Equal("open_air", e.ResolveZone(null).Id, "no zones = open air");
        Assert.Equal("open_air", e.ResolveZone(new string[] { null, "bogus" }).Id, "junk is ignored");
    }

    public static void AmbienceIsDeterministicAndWithinGain()
    {
        var e = Env();
        foreach (var w in e.WeatherIds)
            foreach (DayPart d in Enum.GetValues(typeof(DayPart)))
            {
                var a = e.Ambience(new AmbienceInput { Terrain = "swamp", Weather = w, DayPart = d, Zones = new[] { "forest_canopy" } });
                var b = e.Ambience(new AmbienceInput { Terrain = "swamp", Weather = w, DayPart = d, Zones = new[] { "forest_canopy" } });
                Assert.True(a.Layers.SequenceEqual(b.Layers), "repeatable");
                Assert.True(a.Layers.Values.All(v => v >= EnvironmentRules.GainFloor && v <= 1), "gains in range");
            }
    }

    public static void BadEnvironmentDataIsCaught()
    {
        var f = AudioData.Env(); f.TerrainSurface.Remove("tundra");
        Assert.True(EnvironmentRules.Validate(f).Any(e => e.Contains("tundra")), "terrain without a surface");
        f = AudioData.Env(); f.ReverbZones.First(z => z.Id == "cave").BiomeBedGain = 0.5;
        Assert.True(EnvironmentRules.Validate(f).Any(e => e.Contains("indoor zone must not play the biome bed")), "indoor biome bed");
        f = AudioData.Env(); f.TimeOfDay.Remove("dusk");
        Assert.True(EnvironmentRules.Validate(f).Any(e => e.Contains("dusk")), "missing day part");
        Assert.Throws<ArgumentException>(() => new EnvironmentAudio(f), "invalid data refused");
    }
}

[Tests]
static class AccessibilityTests
{
    public static void DataMatchesCoreLimitsAndDefaults()
    {
        var errors = AccessibilityRules.Validate(AudioData.Access());
        Assert.True(errors.Count == 0, string.Join("; ", errors));
    }

    public static void ThreeColorblindPalettesPlusOffAndTheTelegraphShapesStay()
    {
        var f = AudioData.Access();
        Assert.Equal(4, f.Palettes.Count, "off + three");
        Assert.Equal("circle", f.TelegraphShapes["parry"], "parry = circle");
        Assert.Equal("triangle", f.TelegraphShapes["unblockable"], "unblockable = triangle");
        Assert.Equal("square", f.TelegraphShapes["grab"], "grab = square");
        foreach (ColorblindPalette c in Enum.GetValues(typeof(ColorblindPalette)))
            Assert.True(AccessibilityRules.PaletteFor(f, c).Parry != AccessibilityRules.PaletteFor(f, c).Unblockable, $"{c}: telegraph colours differ");
        Assert.True(AccessibilityRules.PaletteFor(f, (ColorblindPalette)99).Parry == f.Palettes["off"].Parry, "unknown choice falls back to off");
    }

    public static void DefaultsAreSafe()
    {
        var d = new AccessibilitySettings();
        Assert.True(d.SubtitlesEnabled && d.SubtitleBackground == SubtitleBackground.Box && d.SpeakerNamesAlwaysShown, "subtitles on with a readable box and speaker names");
        Assert.True(d.ScreenShake < 1 && d.FlashIntensity < 1 && !d.NoCombatMusic, "shake and flash not at maximum");
        Assert.Equal(1.0, d.TextScale, "text scale");
        Assert.True(d.Volumes.Dialogue >= d.Volumes.Music, "dialogue is never quieter than the music by default");
        Assert.True(!d.IsToggle("sprint"), "hold by default");
    }

    public static void SanitizeClampsEverythingIntoRange()
    {
        var s = new AccessibilitySettings
        {
            TextScale = 9, HudScale = 0.1, DialogueTextSpeed = -4, ScreenShake = 3, FlashIntensity = double.NaN, MotionBlur = double.PositiveInfinity,
            ColorblindPalette = (ColorblindPalette)42, SubtitleSize = (SubtitleSize)(-1), SubtitleBackground = (SubtitleBackground)77,
            Volumes = new VolumeSettings { Master = 5, Music = -1, Effects = double.NaN, Ambience = 0.5, Dialogue = 2, Callouts = -0.1 },
            ToggleActions = new Dictionary<string, bool> { { "sprint", true }, { "teleport", true }, { "block", false } },
        };
        s.Sanitize();
        Assert.Equal(2.0, s.TextScale, "text scale max");
        Assert.Equal(0.75, s.HudScale, "hud scale min");
        Assert.Equal(0.5, s.DialogueTextSpeed, "speed min");
        Assert.Equal(1.0, s.ScreenShake, "shake max");
        Assert.Equal(0.6, s.FlashIntensity, "NaN falls back to the default");
        Assert.Equal(0.3, s.MotionBlur, "infinity falls back to the default");
        Assert.Equal(ColorblindPalette.Off, s.ColorblindPalette, "bad palette");
        Assert.Equal(SubtitleSize.Medium, s.SubtitleSize, "bad size");
        Assert.Equal(SubtitleBackground.Box, s.SubtitleBackground, "bad background");
        Assert.True(s.Volumes.Master == 1 && s.Volumes.Music == 0 && s.Volumes.Effects == 1.0 && s.Volumes.Dialogue == 1 && s.Volumes.Callouts == 0, "volumes clamp");
        Assert.True(s.IsToggle("sprint") && !s.IsToggle("block") && !s.ToggleActions.ContainsKey("teleport"), "unknown hold action dropped");
    }

    public static void ReducedFlashCapsTheFlashAndHoldActionsToggle()
    {
        var s = new AccessibilitySettings { FlashIntensity = 1.0 };
        Assert.Equal(1.0, s.EffectiveFlash, "full flash allowed");
        s.ReducedFlash = true;
        Assert.Equal(0.25, s.EffectiveFlash, "reduced flash caps at 0.25");
        s.FlashIntensity = 0.1;
        Assert.Equal(0.1, s.EffectiveFlash, "a lower slider still wins");
        s.SetToggle("aim", true);
        Assert.True(s.IsToggle("aim") && !s.IsToggle("sprint") && !s.IsToggle("bogus") && !s.IsToggle(null), "per-action toggle");
        Assert.Throws<ArgumentException>(() => s.SetToggle("bogus", true), "unknown action refused");
        s.NoCombatMusic = true; s.ReducedMusicIntensity = true;
        var p = s.ToMusicPrefs();
        Assert.True(p.NoCombatMusic && p.ReducedIntensity, "music options reach the score");
    }

    public static void AnOldSaveWithoutTheFieldLoadsWithSafeDefaults()
    {
        // The shape of a save written before Wave D: no Accessibility key at all.
        const string old = "{\"Version\":1,\"Level\":7,\"Copper\":420,\"Items\":{\"itm_core_f\":2},\"Deaths\":1}";
        var save = JsonSerializer.Deserialize<SaveGame>(old, AudioData.Opts);
        Assert.True(save.Accessibility == null, "the field is absent after a raw load");
        SaveRules.Upgrade(save);
        Assert.True(save.Accessibility != null, "the loader null-coalesces it");
        Assert.Equal(0, SaveRules.Validate(save).Count, "and the save still validates");
        Assert.Equal(7, save.Level, "other fields untouched");
        Assert.Equal(420L, save.Copper, "money untouched");
        var d = new AccessibilitySettings();
        Assert.True(save.Accessibility.SubtitlesEnabled && save.Accessibility.TextScale == d.TextScale && save.Accessibility.ScreenShake == d.ScreenShake, "safe defaults");
        Assert.True(save.Accessibility.Volumes != null && save.Accessibility.ToggleActions != null, "nested objects exist");
    }

    public static void AHandEditedSaveIsClampedOnLoad()
    {
        const string json = "{\"Version\":1,\"Accessibility\":{\"TextScale\":50,\"ScreenShake\":-2,\"Volumes\":null,\"ToggleActions\":null,\"SubtitleSize\":\"Large\"}}";
        var save = JsonSerializer.Deserialize<SaveGame>(json, AudioData.Opts);
        SaveRules.Upgrade(save);
        Assert.Equal(2.0, save.Accessibility.TextScale, "clamped");
        Assert.Equal(0.0, save.Accessibility.ScreenShake, "clamped");
        Assert.Equal(SubtitleSize.Large, save.Accessibility.SubtitleSize, "valid values survive");
        Assert.True(save.Accessibility.Volumes != null && save.Accessibility.ToggleActions != null, "nulls replaced");
    }

    public static void SettingsSurviveASaveRoundTrip()
    {
        var save = new SaveGame { Accessibility = new AccessibilitySettings { ColorblindPalette = ColorblindPalette.Deuteranopia, TextScale = 1.5, ReducedFlash = true } };
        save.Accessibility.SetToggle("block", true);
        var again = JsonSerializer.Deserialize<SaveGame>(JsonSerializer.Serialize(save, AudioData.Opts), AudioData.Opts);
        SaveRules.Upgrade(again);
        Assert.Equal(ColorblindPalette.Deuteranopia, again.Accessibility.ColorblindPalette, "palette");
        Assert.Equal(1.5, again.Accessibility.TextScale, "text scale");
        Assert.True(again.Accessibility.ReducedFlash && again.Accessibility.IsToggle("block"), "flash and toggle");
    }

    public static void SubtitleScalesAreOrdered()
    {
        Assert.True(AccessibilitySettings.SubtitleScale(SubtitleSize.Small) < AccessibilitySettings.SubtitleScale(SubtitleSize.Medium)
            && AccessibilitySettings.SubtitleScale(SubtitleSize.Medium) < AccessibilitySettings.SubtitleScale(SubtitleSize.Large)
            && AccessibilitySettings.SubtitleScale(SubtitleSize.Large) < AccessibilitySettings.SubtitleScale(SubtitleSize.ExtraLarge), "ascending");
    }

    public static void BadAccessibilityDataIsCaught()
    {
        var f = AudioData.Access(); f.Ranges["textScale"] = new[] { 0.5, 2.0 };
        Assert.True(AccessibilityRules.Validate(f).Any(e => e.Contains("textScale")), "range drift");
        f = AudioData.Access(); f.Palettes["off"].Grab = f.Palettes["off"].Parry;
        Assert.True(AccessibilityRules.Validate(f).Any(e => e.Contains("telegraph colours")), "two telegraphs share a colour");
        f = AudioData.Access(); f.TelegraphShapes["grab"] = "circle";
        Assert.True(AccessibilityRules.Validate(f).Any(e => e.Contains("shapes must differ")), "shapes collide");
        f = AudioData.Access(); f.Palettes["off"].Parry = "blue";
        Assert.True(AccessibilityRules.Validate(f).Any(e => e.Contains("bad colour")), "non-hex colour");
    }
}

[Tests]
static class PhotoModeTests
{
    static PhotoWorldState World() => new PhotoWorldState { Hour = 14.5, Weather = "clear", HasCompanion = true };
    static PhotoSession Open(PhotoWorldState w = null) => PhotoSession.Open(AudioData.Photo(), new EnvironmentAudio(AudioData.Env()), w ?? World(), out _);

    public static void ShippedDataValidatesAndEveryPoseIsTeenSafe()
    {
        var env = new EnvironmentAudio(AudioData.Env());
        var f = AudioData.Photo();
        var errors = PhotoRules.Validate(f, env.WeatherIds);
        Assert.True(errors.Count == 0, string.Join("; ", errors));
        Assert.True(f.Poses.Count >= 10, "a decent pose list");
        foreach (var p in f.Poses) Assert.True(!p.Tags.Any(t => f.BlockedTags.Contains(t)), $"pose {p.Id} carries a blocked tag");
        foreach (var t in new[] { "suggestive", "undress", "gore" }) Assert.True(f.BlockedTags.Contains(t), $"{t} is blocked");
    }

    public static void ABlockedTagOnAPoseFailsValidationAndSelection()
    {
        var f = AudioData.Photo();
        f.Poses.Add(new PhotoPoseDef { Id = "pose_bad", Name = "Bad", Tags = new List<string> { "standing", "suggestive" } });
        Assert.True(PhotoRules.Validate(f, new[] { "clear" }).Any(e => e.Contains("blocked tag suggestive")), "validator rejects it");
        var s = PhotoSession.Open(f, new EnvironmentAudio(AudioData.Env()), World(), out _);
        Assert.True(!s.SelectPose("pose_bad"), "and a session will not select it even if it slipped in");
    }

    public static void PhotoModeWillNotOpenInCombatCutscenesSiegesOrDialogue()
    {
        var f = AudioData.Photo(); var env = new EnvironmentAudio(AudioData.Env());
        foreach (var (w, why) in new[]
        {
            (new PhotoWorldState { InCombat = true }, "combat"), (new PhotoWorldState { CutsceneActive = true }, "cutscene"),
            (new PhotoWorldState { SiegeBattle = true }, "siege_battle"), (new PhotoWorldState { InDialogue = true }, "dialogue"),
        })
        {
            Assert.True(PhotoSession.Open(f, env, w, out var reason) == null && reason == why, $"blocked by {why}");
        }
        Assert.True(PhotoSession.Open(f, env, World(), out var none) != null && none == null, "calm world opens");
        Assert.True(PhotoSession.Open(f, env, null, out _) == null, "no world, no session");
    }

    public static void TimeAndWeatherOverridesNeverTouchTheSaveOrTheClock()
    {
        var calendar = new GameCalendar(Repo.Db.World.Calendar);
        var save = new SaveGame { ClockSeconds = 12345.5, Level = 9, Copper = 77, Accessibility = new AccessibilitySettings() };
        SaveRules.Upgrade(save);
        string before = JsonSerializer.Serialize(save, AudioData.Opts);
        var (day0, hour0) = calendar.FromPlaySeconds(save.ClockSeconds.Value);
        var s = Open(new PhotoWorldState { Hour = hour0, Weather = "rain", HasCompanion = false });
        Assert.True(!s.ChangesSaveState, "the session declares it changes nothing");
        s.SetHour(2.0); s.SetWeather("storm"); s.SelectFilter("filter_moonlit", 0.7); s.ToggleUiHidden(); s.SetFov(35);
        var shot = s.Capture();
        Assert.Near(2.0, shot.Hour, 1e-9, "the picture shows the override hour");
        Assert.Equal("storm", shot.Weather, "and the override weather");
        Assert.Equal(DayPart.Night, calendar.PartOf(s.EffectiveHour), "night picture");
        Assert.True(calendar.PartOf(hour0) != DayPart.Night || hour0 < 6 || hour0 >= 20, "sanity");
        s.Close();
        Assert.Near(hour0, s.EffectiveHour, 1e-9, "after closing the live hour is what you see");
        Assert.Equal("rain", s.EffectiveWeather, "and the live weather");
        Assert.Equal(before, JsonSerializer.Serialize(save, AudioData.Opts), "the save is byte-for-byte the same");
        Assert.Equal(12345.5, save.ClockSeconds.Value, "the clock field is untouched");
        var (day1, hour1) = calendar.FromPlaySeconds(save.ClockSeconds.Value);
        Assert.True(day0 == day1 && Math.Abs(hour0 - hour1) < 1e-12, "the in-game time reads the same");
    }

    public static void OverridesAreSnappedWrappedAndValidated()
    {
        var s = Open();
        s.SetHour(25.9); Assert.Near(2.0, s.HourOverride.Value, 1e-9, "25.9 wraps to 1.9 and snaps to 2.0");
        s.SetHour(-1); Assert.Near(23.0, s.HourOverride.Value, 1e-9, "negative wraps");
        s.SetHour(23.99); Assert.Near(0.0, s.HourOverride.Value, 1e-9, "snaps up to midnight, not 24");
        s.SetHour(double.NaN); Assert.Near(0.0, s.HourOverride.Value, 1e-9, "NaN is midnight, not a crash");
        Assert.True(!s.SetWeather("acid_rain") && s.WeatherOverride == null, "unknown weather refused");
        Assert.True(s.SetWeather("fog") && s.EffectiveWeather == "fog", "known weather accepted");
        s.ClearOverrides();
        Assert.True(!s.HasOverrides && Math.Abs(s.EffectiveHour - 14.5) < 1e-9 && s.EffectiveWeather == "clear", "cleared overrides show the live world");
        s.SetFov(500); Assert.Equal(90.0, s.Fov, "fov max");
        s.SetFov(-5); Assert.Equal(20.0, s.Fov, "fov min");
    }

    public static void HideUiPosesFiltersAndFramesWork()
    {
        var s = Open();
        Assert.True(!s.IsHidden("hud"), "ui shown at first");
        s.SetUiHidden(true);
        Assert.True(s.IsHidden("hud") && s.IsHidden("nameplates"), "hide-everything toggle hides every element");
        s.SetUiHidden(false);
        Assert.True(s.SetElementHidden("nameplates", true) && s.IsHidden("nameplates") && !s.IsHidden("hud"), "single element");
        Assert.True(!s.SetElementHidden("sky", true), "unknown element refused");
        Assert.True(s.SelectPose("pose_wave") && s.PoseId == "pose_wave", "pose");
        Assert.True(!s.SelectPose("pose_unknown") && s.PoseId == "pose_wave", "unknown pose refused, previous kept");
        Assert.True(s.SelectFilter("filter_watercolor", 5) && s.FilterIntensity == 1.0, "filter intensity clamps");
        Assert.True(!s.SelectFilter("filter_vhs") && s.FilterId == "filter_watercolor", "unknown filter refused");
        Assert.True(s.SelectFrame("frame_parchment") && !s.SelectFrame("frame_gold"), "frames");
        var a = s.Capture(); var b = s.Capture();
        Assert.True(a.Number == 1 && b.Number == 2 && a.PoseId == "pose_wave", "shots are numbered and carry the look");
    }

    public static void CompanionPosesNeedACompanionAndAClosedSessionIsInert()
    {
        var alone = Open(new PhotoWorldState { Hour = 10, HasCompanion = false });
        Assert.True(!alone.SelectPose("pose_companion_cheer") && !alone.SelectPose("pose_shoulder_to_shoulder") && alone.SelectPose("pose_cheer"), "no companion, no pair poses");
        var withPal = Open();
        Assert.True(withPal.SelectPose("pose_campfire_sit"), "with a companion the pair pose works");
        withPal.Close();
        Assert.True(!withPal.IsOpen && !withPal.UiHidden, "closed");
        Assert.Throws<InvalidOperationException>(() => withPal.SetHour(3), "a closed session refuses changes");
        Assert.Throws<InvalidOperationException>(() => withPal.Capture(), "and captures");
    }
}
