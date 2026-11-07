using System;
using System.Collections.Generic;
using System.Linq;

namespace Ascend.Core
{
    // Wave D environmental audio (12_Systems/audio_and_immersion.md). Data: Data/Audio/environment_audio.json.
    // Pure rules that turn "where am I, what is the weather, what time is it" into event names and gains.
    // Event names only: no audio files exist. Terrain kinds are the map terrain vocabulary (MAP_TERRAIN).

    public sealed class SurfaceDef
    {
        public string Id { get; set; }
        /// <summary>Rain and storms add a wet overlay on this surface.</summary>
        public bool Wettable { get; set; }
    }

    public sealed class WeatherDef
    {
        public string Id { get; set; }
        public Dictionary<string, double> Layers { get; set; } = new Dictionary<string, double>();
        public bool WetsSurfaces { get; set; }
    }

    public sealed class ReverbZoneDef
    {
        public string Id { get; set; }
        public string ReverbPreset { get; set; }
        public bool Indoor { get; set; }
        /// <summary>When zones overlap the highest priority wins; ties go to the lower id (deterministic).</summary>
        public int Priority { get; set; }
        public double WeatherGain { get; set; } = 1;
        public double TimeOfDayGain { get; set; } = 1;
        public double BiomeBedGain { get; set; } = 1;
        public double BlendSeconds { get; set; } = 1;
        public Dictionary<string, double> Layers { get; set; } = new Dictionary<string, double>();
    }

    public sealed class EnvironmentFile
    {
        public int Version { get; set; } = 1;
        public string Notes { get; set; }
        public string FallbackSurface { get; set; } = "grass";
        public List<string> Gaits { get; set; } = new List<string>();
        public List<SurfaceDef> Surfaces { get; set; } = new List<SurfaceDef>();
        public Dictionary<string, string> TerrainSurface { get; set; } = new Dictionary<string, string>();
        public string WetOverlayEvent { get; set; }
        public List<WeatherDef> Weather { get; set; } = new List<WeatherDef>();
        /// <summary>morning / day / dusk / night → ambience layer gains.</summary>
        public Dictionary<string, Dictionary<string, double>> TimeOfDay { get; set; } = new Dictionary<string, Dictionary<string, double>>();
        public Dictionary<string, string> BiomeBeds { get; set; } = new Dictionary<string, string>();
        public List<ReverbZoneDef> ReverbZones { get; set; } = new List<ReverbZoneDef>();
    }

    /// <summary>Extra context that overrides the terrain under the feet. Water beats an interior floor beats a road beats the terrain.</summary>
    public sealed class SurfaceContext
    {
        public bool InShallowWater { get; set; }
        /// <summary>A surface id such as "wood" or "stone_floor" when indoors, else null.</summary>
        public string InteriorFloor { get; set; }
        public bool OnRoad { get; set; }
    }

    /// <summary>What the audio layer should play for the ambient bed.</summary>
    public sealed class AmbienceInput
    {
        /// <summary>A map terrain kind (plains, forest, ...). Unknown or null gets no biome bed.</summary>
        public string Terrain { get; set; }
        public string Weather { get; set; } = "clear";
        public DayPart DayPart { get; set; } = DayPart.Day;
        /// <summary>Every reverb zone the listener is inside (may be empty = open air).</summary>
        public IEnumerable<string> Zones { get; set; }
    }

    public sealed class AmbienceFrame
    {
        public string ZoneId { get; set; }
        public string ReverbPreset { get; set; }
        public bool Indoor { get; set; }
        public double BlendSeconds { get; set; }
        /// <summary>Ambience event id → gain 0..1, ordered by id. Gains below the floor are dropped.</summary>
        public IReadOnlyDictionary<string, double> Layers { get; set; }
    }

    public static class EnvironmentRules
    {
        /// <summary>The same terrain vocabulary as MAP_TERRAIN in Tools/validate/build_schemas.js and Data/World/regions.json.</summary>
        public static readonly string[] MapTerrain = { "plains", "forest", "swamp", "steppe", "mountain", "volcanic", "tundra", "desert", "jungle", "spirit", "demon" };
        public static readonly string[] DayParts = { "morning", "day", "dusk", "night" };
        /// <summary>Layers quieter than this are not worth a voice.</summary>
        public const double GainFloor = 0.02;

        static bool EventSafe(string s) => !string.IsNullOrEmpty(s) && s[0] >= 'a' && s[0] <= 'z' && s.All(c => (c >= 'a' && c <= 'z') || (c >= '0' && c <= '9') || c == '_');

        public static List<string> Validate(EnvironmentFile f)
        {
            var errors = new List<string>();
            if (f == null) { errors.Add("no environment data"); return errors; }
            var surfaces = new HashSet<string>(f.Surfaces.Select(s => s.Id));
            if (surfaces.Count != f.Surfaces.Count) errors.Add("duplicate surface id");
            foreach (var s in surfaces) if (!EventSafe(s)) errors.Add($"surface id \"{s}\" is not event-safe");
            if (!surfaces.Contains(f.FallbackSurface ?? "")) errors.Add("fallback surface is not a surface");
            foreach (var need in new[] { "shallow_water", "cobble" }) if (!surfaces.Contains(need)) errors.Add($"missing required surface {need}");
            if (f.Gaits.Count == 0) errors.Add("no gaits");
            foreach (var t in MapTerrain)
            {
                if (!f.TerrainSurface.TryGetValue(t, out var s)) errors.Add($"terrain {t} has no surface");
                else if (!surfaces.Contains(s)) errors.Add($"terrain {t} maps to unknown surface {s}");
                if (!f.BiomeBeds.ContainsKey(t)) errors.Add($"terrain {t} has no biome bed");
            }
            foreach (var t in f.TerrainSurface.Keys) if (!MapTerrain.Contains(t)) errors.Add($"unknown terrain kind {t}");
            foreach (var t in f.BiomeBeds.Keys) if (!MapTerrain.Contains(t)) errors.Add($"biome bed for unknown terrain {t}");
            if (!EventSafe(f.WetOverlayEvent)) errors.Add("wet overlay event is not event-safe");
            var weather = new HashSet<string>(f.Weather.Select(w => w.Id));
            if (weather.Count != f.Weather.Count) errors.Add("duplicate weather id");
            if (!weather.Contains("clear")) errors.Add("weather needs a clear entry");
            foreach (var d in DayParts) if (!f.TimeOfDay.ContainsKey(d)) errors.Add($"no ambience for {d}");
            foreach (var d in f.TimeOfDay.Keys) if (!DayParts.Contains(d)) errors.Add($"unknown day part {d}");
            var layerSets = f.Weather.Select(w => w.Layers).Concat(f.TimeOfDay.Values).Concat(f.ReverbZones.Select(z => z.Layers));
            foreach (var set in layerSets)
                foreach (var kv in set)
                {
                    if (!EventSafe(kv.Key)) errors.Add($"layer \"{kv.Key}\" is not event-safe");
                    if (kv.Value < 0 || kv.Value > 1) errors.Add($"layer {kv.Key} gain outside 0..1");
                }
            foreach (var bed in f.BiomeBeds.Values) if (!EventSafe(bed)) errors.Add($"biome bed \"{bed}\" is not event-safe");
            var zones = new HashSet<string>(f.ReverbZones.Select(z => z.Id));
            if (zones.Count != f.ReverbZones.Count) errors.Add("duplicate reverb zone id");
            if (!zones.Contains("open_air")) errors.Add("reverb zones need open_air (the default)");
            foreach (var z in f.ReverbZones)
            {
                if (!EventSafe(z.ReverbPreset)) errors.Add($"zone {z.Id}: reverb preset is not event-safe");
                foreach (var g in new[] { z.WeatherGain, z.TimeOfDayGain, z.BiomeBedGain }) if (g < 0 || g > 1) errors.Add($"zone {z.Id}: gain outside 0..1");
                if (z.BlendSeconds < 0) errors.Add($"zone {z.Id}: negative blend");
                if (z.Indoor && z.BiomeBedGain > 0) errors.Add($"zone {z.Id}: an indoor zone must not play the biome bed");
            }
            foreach (var z in f.ReverbZones) if (z.Id != "open_air" && z.Priority <= 0) errors.Add($"zone {z.Id}: only open_air may sit at priority 0 or below");
            var open = f.ReverbZones.FirstOrDefault(z => z.Id == "open_air");
            if (open != null && (open.Indoor || open.Priority != 0)) errors.Add("open_air must be outdoor at priority 0");
            return errors;
        }
    }

    public sealed class EnvironmentAudio
    {
        readonly EnvironmentFile _f;
        readonly Dictionary<string, SurfaceDef> _surfaces;
        readonly Dictionary<string, WeatherDef> _weather;
        readonly Dictionary<string, ReverbZoneDef> _zones;

        public EnvironmentAudio(EnvironmentFile file)
        {
            _f = file ?? throw new ArgumentNullException(nameof(file));
            var problems = EnvironmentRules.Validate(file);
            if (problems.Count > 0) throw new ArgumentException("environment audio data invalid: " + string.Join("; ", problems));
            _surfaces = file.Surfaces.ToDictionary(s => s.Id);
            _weather = file.Weather.ToDictionary(w => w.Id);
            _zones = file.ReverbZones.ToDictionary(z => z.Id);
        }

        public IReadOnlyCollection<string> WeatherIds => _weather.Keys;
        public bool IsWeather(string id) => id != null && _weather.ContainsKey(id);

        // ---- footsteps ----

        /// <summary>The surface heard underfoot. Unknown terrain falls back (a new terrain kind never goes silent).</summary>
        public string ResolveSurface(string terrain, SurfaceContext ctx = null)
        {
            if (ctx != null)
            {
                if (ctx.InShallowWater) return "shallow_water";
                if (!string.IsNullOrEmpty(ctx.InteriorFloor) && _surfaces.ContainsKey(ctx.InteriorFloor)) return ctx.InteriorFloor;
                if (ctx.OnRoad) return "cobble";
            }
            return terrain != null && _f.TerrainSurface.TryGetValue(terrain, out var s) ? s : _f.FallbackSurface;
        }

        /// <summary>The footstep event for a surface and gait ("walk", "run", "sprint"). An unknown gait plays as walk.</summary>
        public string FootstepEvent(string surface, string gait)
        {
            if (surface == null || !_surfaces.ContainsKey(surface)) surface = _f.FallbackSurface;
            if (gait == null || !_f.Gaits.Contains(gait)) gait = _f.Gaits[0];
            return $"sfx_step_{surface}_{gait}";
        }

        public string LandEvent(string surface)
        {
            if (surface == null || !_surfaces.ContainsKey(surface)) surface = _f.FallbackSurface;
            return $"sfx_land_{surface}";
        }

        /// <summary>The wet overlay event when the weather wets surfaces and this surface can get wet, else null.</summary>
        public string WetOverlay(string surface, string weather, bool indoors)
        {
            if (indoors || surface == null || weather == null) return null;
            if (!_surfaces.TryGetValue(surface, out var s) || !s.Wettable) return null;
            return _weather.TryGetValue(weather, out var w) && w.WetsSurfaces ? _f.WetOverlayEvent : null;
        }

        // ---- ambience ----

        public ReverbZoneDef ResolveZone(IEnumerable<string> ids)
        {
            ReverbZoneDef best = _zones["open_air"];
            if (ids == null) return best;
            foreach (var id in ids)
            {
                if (id == null || !_zones.TryGetValue(id, out var z)) continue;
                if (z.Priority > best.Priority || (z.Priority == best.Priority && z != best && string.CompareOrdinal(z.Id, best.Id) < 0)) best = z;
            }
            return best;
        }

        public AmbienceFrame Ambience(AmbienceInput input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));
            var zone = ResolveZone(input.Zones);
            var mix = new SortedDictionary<string, double>(StringComparer.Ordinal);
            void Add(string id, double g)
            {
                g = Math.Max(0, Math.Min(1, g));
                if (g < EnvironmentRules.GainFloor) return;
                mix[id] = mix.TryGetValue(id, out var old) ? Math.Max(old, g) : g;
            }
            if (input.Terrain != null && _f.BiomeBeds.TryGetValue(input.Terrain, out var bed)) Add(bed, zone.BiomeBedGain);
            // an unknown weather id plays as clear
            var w = input.Weather != null && _weather.TryGetValue(input.Weather, out var wd) ? wd : _weather["clear"];
            foreach (var kv in w.Layers) Add(kv.Key, kv.Value * zone.WeatherGain);
            if (_f.TimeOfDay.TryGetValue(input.DayPart.ToString().ToLowerInvariant(), out var tod))
                foreach (var kv in tod) Add(kv.Key, kv.Value * zone.TimeOfDayGain);
            foreach (var kv in zone.Layers) Add(kv.Key, kv.Value);
            return new AmbienceFrame { ZoneId = zone.Id, ReverbPreset = zone.ReverbPreset, Indoor = zone.Indoor, BlendSeconds = zone.BlendSeconds, Layers = mix };
        }
    }
}
