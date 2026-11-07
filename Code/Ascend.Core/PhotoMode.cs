using System;
using System.Collections.Generic;
using System.Linq;

namespace Ascend.Core
{
    // Wave D photo mode (12_Systems/hud_and_ui.md section 11). Data: Data/Audio/photo_mode.json.
    // A photo session is a pure, in-memory overlay: the time-of-day and weather it shows are overrides on top of the live
    // world. It holds no SaveGame and no clock, so it cannot change either (Canon: in-game-time continuity). The game
    // reads EffectiveHour / EffectiveWeather while the session is open and restores the live values when it closes.

    public sealed class PhotoTuning
    {
        public double FovMin { get; set; } = 20;
        public double FovMax { get; set; } = 90;
        public double FovDefault { get; set; } = 60;
        /// <summary>Time-of-day picker step in hours.</summary>
        public double HourStep { get; set; } = 0.25;
        public double FilterIntensityDefault { get; set; } = 1.0;
    }

    public sealed class PhotoPoseDef
    {
        public string Id { get; set; }
        public string Name { get; set; }
        /// <summary>player, companion or both.</summary>
        public string Target { get; set; } = "player";
        public List<string> Tags { get; set; } = new List<string>();
    }

    public sealed class PhotoOptionDef { public string Id { get; set; } public string Name { get; set; } }

    public sealed class PhotoFile
    {
        public int Version { get; set; } = 1;
        public string Notes { get; set; }
        public PhotoTuning Tuning { get; set; } = new PhotoTuning();
        /// <summary>No shipped pose may carry any of these tags (teen rating).</summary>
        public List<string> BlockedTags { get; set; } = new List<string>();
        /// <summary>Situations in which photo mode cannot open: combat, cutscene, siege_battle, dialogue.</summary>
        public List<string> BlockedWhen { get; set; } = new List<string>();
        public List<string> HideElements { get; set; } = new List<string>();
        public List<PhotoPoseDef> Poses { get; set; } = new List<PhotoPoseDef>();
        public List<PhotoOptionDef> Filters { get; set; } = new List<PhotoOptionDef>();
        public List<PhotoOptionDef> Frames { get; set; } = new List<PhotoOptionDef>();
    }

    /// <summary>What the world is doing right now, handed to the session when it opens.</summary>
    public sealed class PhotoWorldState
    {
        public bool InCombat { get; set; }
        public bool CutsceneActive { get; set; }
        public bool SiegeBattle { get; set; }
        public bool InDialogue { get; set; }
        /// <summary>The live in-game hour 0..24.</summary>
        public double Hour { get; set; }
        public string Weather { get; set; } = "clear";
        public bool HasCompanion { get; set; }
    }

    /// <summary>A shot for the Memory Reel. A plain record; saving it is the platform layer's job, not a save-state change.</summary>
    public sealed class PhotoShot
    {
        public string PoseId { get; set; }
        public string FilterId { get; set; }
        public double FilterIntensity { get; set; }
        public string FrameId { get; set; }
        public double Fov { get; set; }
        public double Hour { get; set; }
        public string Weather { get; set; }
        public bool UiHidden { get; set; }
        public int Number { get; set; }
    }

    public static class PhotoRules
    {
        static bool IdSafe(string s) => !string.IsNullOrEmpty(s) && s.All(c => (c >= 'a' && c <= 'z') || (c >= '0' && c <= '9') || c == '_');

        public static List<string> Validate(PhotoFile f, IEnumerable<string> weatherIds = null)
        {
            var errors = new List<string>();
            if (f == null) { errors.Add("no photo data"); return errors; }
            var t = f.Tuning;
            if (!(t.FovMin > 0 && t.FovMin < t.FovMax && t.FovMax <= 120)) errors.Add("fov range invalid");
            if (t.FovDefault < t.FovMin || t.FovDefault > t.FovMax) errors.Add("fov default outside range");
            if (t.HourStep <= 0 || t.HourStep > 1) errors.Add("hour step must be in (0, 1]");
            if (t.FilterIntensityDefault < 0 || t.FilterIntensityDefault > 1) errors.Add("filter intensity default outside 0..1");
            if (f.BlockedTags.Count == 0) errors.Add("blockedTags is empty: the teen-rating guard needs a list");
            foreach (var need in new[] { "combat", "cutscene", "siege_battle", "dialogue" }) if (!f.BlockedWhen.Contains(need)) errors.Add($"blockedWhen needs {need}");
            if (!f.HideElements.Contains("hud")) errors.Add("hideElements needs hud");
            var ids = new HashSet<string>();
            foreach (var p in f.Poses)
            {
                if (!IdSafe(p.Id)) errors.Add($"pose id \"{p.Id}\" is not id-safe");
                if (!ids.Add(p.Id ?? "")) errors.Add($"duplicate pose {p.Id}");
                if (p.Target != "player" && p.Target != "companion" && p.Target != "both") errors.Add($"pose {p.Id}: bad target {p.Target}");
                if (p.Tags.Count == 0) errors.Add($"pose {p.Id}: no tags");
                foreach (var tag in p.Tags) if (f.BlockedTags.Contains(tag)) errors.Add($"pose {p.Id}: blocked tag {tag}");
            }
            if (f.Poses.Count == 0) errors.Add("no poses");
            if (!f.Filters.Any(x => x.Id == "filter_none")) errors.Add("filters need filter_none");
            if (!f.Frames.Any(x => x.Id == "frame_none")) errors.Add("frames need frame_none");
            foreach (var o in f.Filters.Concat(f.Frames)) if (!IdSafe(o.Id)) errors.Add($"option id \"{o.Id}\" is not id-safe");
            if (f.Filters.Select(x => x.Id).Distinct().Count() != f.Filters.Count) errors.Add("duplicate filter");
            if (f.Frames.Select(x => x.Id).Distinct().Count() != f.Frames.Count) errors.Add("duplicate frame");
            if (weatherIds != null && weatherIds.Count() == 0) errors.Add("no weather ids to override with");
            return errors;
        }

        /// <summary>True when photo mode may open now; <paramref name="reason"/> names the first blocker.</summary>
        public static bool CanOpen(PhotoFile f, PhotoWorldState w, out string reason)
        {
            reason = null;
            if (w == null) { reason = "no world"; return false; }
            var checks = new (string key, bool on)[] { ("combat", w.InCombat), ("cutscene", w.CutsceneActive), ("siege_battle", w.SiegeBattle), ("dialogue", w.InDialogue) };
            foreach (var (key, on) in checks)
                if (on && f.BlockedWhen.Contains(key)) { reason = key; return false; }
            return true;
        }
    }

    public sealed class PhotoSession
    {
        readonly PhotoFile _f;
        readonly EnvironmentAudio _env;
        readonly HashSet<string> _hidden = new HashSet<string>();
        readonly double _liveHour;
        readonly string _liveWeather;
        readonly bool _hasCompanion;
        int _shots;

        public bool IsOpen { get; private set; }
        public bool UiHidden { get; private set; }
        public string PoseId { get; private set; }
        public string FilterId { get; private set; } = "filter_none";
        public double FilterIntensity { get; private set; }
        public string FrameId { get; private set; } = "frame_none";
        public double Fov { get; private set; }
        public double? HourOverride { get; private set; }
        public string WeatherOverride { get; private set; }

        /// <summary>The hour to render: the override, else the live in-game hour.</summary>
        public double EffectiveHour => HourOverride ?? _liveHour;
        public string EffectiveWeather => WeatherOverride ?? _liveWeather;
        public bool HasOverrides => HourOverride.HasValue || WeatherOverride != null;

        /// <summary>The photo session never writes the save or the clock.</summary>
        public bool ChangesSaveState => false;

        PhotoSession(PhotoFile f, EnvironmentAudio env, PhotoWorldState w)
        {
            _f = f; _env = env;
            _liveHour = Wrap(w.Hour);
            _liveWeather = w.Weather ?? "clear";
            _hasCompanion = w.HasCompanion;
            Fov = f.Tuning.FovDefault;
            FilterIntensity = f.Tuning.FilterIntensityDefault;
            IsOpen = true;
        }

        static double Wrap(double h) => double.IsNaN(h) || double.IsInfinity(h) ? 0 : ((h % 24) + 24) % 24;

        /// <summary>Opens a session, or returns null (with the blocker in <paramref name="reason"/>) when the world forbids it.</summary>
        public static PhotoSession Open(PhotoFile f, EnvironmentAudio env, PhotoWorldState w, out string reason)
        {
            if (f == null) throw new ArgumentNullException(nameof(f));
            if (env == null) throw new ArgumentNullException(nameof(env));
            if (!PhotoRules.CanOpen(f, w, out reason)) return null;
            return new PhotoSession(f, env, w);
        }

        void Require() { if (!IsOpen) throw new InvalidOperationException("photo session is closed"); }

        public void SetUiHidden(bool hidden) { Require(); UiHidden = hidden; if (!hidden) _hidden.Clear(); }
        public void ToggleUiHidden() => SetUiHidden(!UiHidden);

        /// <summary>Hides or shows one element ("nameplates", ...). Unknown elements are refused.</summary>
        public bool SetElementHidden(string element, bool hidden)
        {
            Require();
            if (element == null || !_f.HideElements.Contains(element)) return false;
            if (hidden) _hidden.Add(element); else _hidden.Remove(element);
            return true;
        }

        public bool IsHidden(string element) => IsOpen && (UiHidden || _hidden.Contains(element));

        /// <summary>Chooses a pose from the allow-list. Companion and pair poses need a companion; an unknown id is refused.</summary>
        public bool SelectPose(string id)
        {
            Require();
            var p = _f.Poses.FirstOrDefault(x => x.Id == id);
            if (p == null || p.Tags.Any(t => _f.BlockedTags.Contains(t))) return false;
            if (p.Target != "player" && !_hasCompanion) return false;
            PoseId = id;
            return true;
        }

        public bool SelectFilter(string id, double? intensity = null)
        {
            Require();
            if (!_f.Filters.Any(x => x.Id == id)) return false;
            FilterId = id;
            FilterIntensity = Math.Max(0, Math.Min(1, intensity ?? _f.Tuning.FilterIntensityDefault));
            return true;
        }

        public bool SelectFrame(string id)
        {
            Require();
            if (!_f.Frames.Any(x => x.Id == id)) return false;
            FrameId = id;
            return true;
        }

        public void SetFov(double fov)
        {
            Require();
            Fov = double.IsNaN(fov) ? _f.Tuning.FovDefault : Math.Max(_f.Tuning.FovMin, Math.Min(_f.Tuning.FovMax, fov));
        }

        /// <summary>Overrides the time of day for the picture only. The hour wraps and snaps to the step. Never touches the clock.</summary>
        public void SetHour(double hour)
        {
            Require();
            double step = _f.Tuning.HourStep;
            double h = Math.Round(Wrap(hour) / step) * step;
            HourOverride = h >= 24 ? 0 : h;
        }

        /// <summary>Overrides the weather for the picture only. Unknown weather ids are refused.</summary>
        public bool SetWeather(string id)
        {
            Require();
            if (!_env.IsWeather(id)) return false;
            WeatherOverride = id;
            return true;
        }

        public void ClearOverrides() { Require(); HourOverride = null; WeatherOverride = null; }

        /// <summary>Records the current look as a Memory Reel shot.</summary>
        public PhotoShot Capture()
        {
            Require();
            return new PhotoShot
            {
                PoseId = PoseId, FilterId = FilterId, FilterIntensity = FilterIntensity, FrameId = FrameId, Fov = Fov,
                Hour = EffectiveHour, Weather = EffectiveWeather, UiHidden = UiHidden, Number = ++_shots,
            };
        }

        /// <summary>Closes the session. The overrides vanish; the game keeps its live hour and weather untouched.</summary>
        public void Close()
        {
            IsOpen = false;
            HourOverride = null; WeatherOverride = null;
            UiHidden = false; _hidden.Clear();
        }
    }
}
