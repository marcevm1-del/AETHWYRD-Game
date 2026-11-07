using System;
using System.Collections.Generic;
using System.Linq;

namespace Ascend.Core
{
    // Wave D accessibility settings (12_Systems/hud_and_ui.md section 14). Data: Data/Audio/accessibility.json.
    // A plain DTO that rides in the save (SaveGame.Accessibility, null in older saves). Every value clamps into its range,
    // so a hand-edited or older save can never push the game into an unsafe state.

    public enum ColorblindPalette { Off, Protanopia, Deuteranopia, Tritanopia }
    public enum SubtitleSize { Small, Medium, Large, ExtraLarge }
    public enum SubtitleBackground { None, Shadow, Box }

    /// <summary>Mirror of the ranges in Data/Audio/accessibility.json (a test keeps them equal).</summary>
    public static class AccessibilityLimits
    {
        public const double TextScaleMin = 0.8, TextScaleMax = 2.0;
        public const double HudScaleMin = 0.75, HudScaleMax = 1.5;
        public const double TextSpeedMin = 0.5, TextSpeedMax = 3.0;
        public const double SliderMin = 0, SliderMax = 1;
        /// <summary>Flash intensity ceiling while reduced-flash is on (impact frames and Ultimates use soft fades).</summary>
        public const double ReducedFlashCap = 0.25;
        public static readonly string[] HoldActions = { "sprint", "block", "aim", "charge_heavy", "companion_wheel", "second_palette" };
    }

    public sealed class VolumeSettings
    {
        public double Master { get; set; } = 1.0;
        public double Music { get; set; } = 0.8;
        public double Effects { get; set; } = 1.0;
        public double Ambience { get; set; } = 0.8;
        /// <summary>One bus for any spoken line. Silent until the game has voice (the amount of voice is the user's call).</summary>
        public double Dialogue { get; set; } = 1.0;
        /// <summary>Companion combat callouts (their own control, see the adaptive music doc).</summary>
        public double Callouts { get; set; } = 0.8;
    }

    public sealed class AccessibilitySettings
    {
        public ColorblindPalette ColorblindPalette { get; set; } = ColorblindPalette.Off;
        public bool SubtitlesEnabled { get; set; } = true;
        public SubtitleSize SubtitleSize { get; set; } = SubtitleSize.Medium;
        public SubtitleBackground SubtitleBackground { get; set; } = SubtitleBackground.Box;
        public double DialogueTextSpeed { get; set; } = 1.0;
        public double TextScale { get; set; } = 1.0;
        public double HudScale { get; set; } = 1.0;
        public bool HighContrastPanels { get; set; }
        public bool DyslexiaFont { get; set; }
        public double ScreenShake { get; set; } = 0.6;
        public double FlashIntensity { get; set; } = 0.6;
        public double MotionBlur { get; set; } = 0.3;
        public bool ReducedFlash { get; set; }
        public bool NoCombatMusic { get; set; }
        public bool ReducedMusicIntensity { get; set; }
        public VolumeSettings Volumes { get; set; } = new VolumeSettings();
        /// <summary>Hold action id → true when the player wants a toggle instead of holding. Missing = hold.</summary>
        public Dictionary<string, bool> ToggleActions { get; set; } = new Dictionary<string, bool>();

        /// <summary>Speaker names are always shown (Canon / hud_and_ui §14). Not a setting.</summary>
        public bool SpeakerNamesAlwaysShown => true;

        /// <summary>The flash strength the renderer should use: capped hard while reduced-flash is on.</summary>
        public double EffectiveFlash => ReducedFlash ? Math.Min(FlashIntensity, AccessibilityLimits.ReducedFlashCap) : FlashIntensity;

        /// <summary>Whether an action is a toggle for this player. Unknown actions are never toggles.</summary>
        public bool IsToggle(string action) =>
            action != null && AccessibilityLimits.HoldActions.Contains(action) && ToggleActions != null && ToggleActions.TryGetValue(action, out var t) && t;

        public void SetToggle(string action, bool toggle)
        {
            if (action == null || !AccessibilityLimits.HoldActions.Contains(action)) throw new ArgumentException("not a hold action: " + action);
            ToggleActions ??= new Dictionary<string, bool>();
            ToggleActions[action] = toggle;
        }

        /// <summary>The music options the adaptive score reads. A copy: push changes to a live machine by mutating MusicMachine.Prefs.</summary>
        public MusicPrefs ToMusicPrefs() => new MusicPrefs { NoCombatMusic = NoCombatMusic, ReducedIntensity = ReducedMusicIntensity };

        /// <summary>Subtitle text size multiplier from the data table.</summary>
        public static double SubtitleScale(SubtitleSize s)
        {
            switch (s) { case SubtitleSize.Small: return 0.85; case SubtitleSize.Large: return 1.3; case SubtitleSize.ExtraLarge: return 1.6; default: return 1.0; }
        }

        static double Clamp(double v, double lo, double hi, double fallback) => double.IsNaN(v) || double.IsInfinity(v) ? fallback : Math.Max(lo, Math.Min(hi, v));

        /// <summary>Pulls every value into range, replaces unknown enum values with the safe default and drops unknown hold actions.</summary>
        public AccessibilitySettings Sanitize()
        {
            var d = new AccessibilitySettings();
            if (!Enum.IsDefined(typeof(ColorblindPalette), ColorblindPalette)) ColorblindPalette = d.ColorblindPalette;
            if (!Enum.IsDefined(typeof(SubtitleSize), SubtitleSize)) SubtitleSize = d.SubtitleSize;
            if (!Enum.IsDefined(typeof(SubtitleBackground), SubtitleBackground)) SubtitleBackground = d.SubtitleBackground;
            DialogueTextSpeed = Clamp(DialogueTextSpeed, AccessibilityLimits.TextSpeedMin, AccessibilityLimits.TextSpeedMax, d.DialogueTextSpeed);
            TextScale = Clamp(TextScale, AccessibilityLimits.TextScaleMin, AccessibilityLimits.TextScaleMax, d.TextScale);
            HudScale = Clamp(HudScale, AccessibilityLimits.HudScaleMin, AccessibilityLimits.HudScaleMax, d.HudScale);
            ScreenShake = Clamp(ScreenShake, AccessibilityLimits.SliderMin, AccessibilityLimits.SliderMax, d.ScreenShake);
            FlashIntensity = Clamp(FlashIntensity, AccessibilityLimits.SliderMin, AccessibilityLimits.SliderMax, d.FlashIntensity);
            MotionBlur = Clamp(MotionBlur, AccessibilityLimits.SliderMin, AccessibilityLimits.SliderMax, d.MotionBlur);
            Volumes ??= new VolumeSettings();
            var v = Volumes; var dv = d.Volumes;
            v.Master = Clamp(v.Master, 0, 1, dv.Master); v.Music = Clamp(v.Music, 0, 1, dv.Music); v.Effects = Clamp(v.Effects, 0, 1, dv.Effects);
            v.Ambience = Clamp(v.Ambience, 0, 1, dv.Ambience); v.Dialogue = Clamp(v.Dialogue, 0, 1, dv.Dialogue); v.Callouts = Clamp(v.Callouts, 0, 1, dv.Callouts);
            var kept = new Dictionary<string, bool>();
            if (ToggleActions != null)
                foreach (var kv in ToggleActions) if (kv.Key != null && AccessibilityLimits.HoldActions.Contains(kv.Key)) kept[kv.Key] = kv.Value;
            ToggleActions = kept;
            return this;
        }
    }

    public sealed class AccessibilityPalette
    {
        public string Parry { get; set; }
        public string Unblockable { get; set; }
        public string Grab { get; set; }
        public string HpLow { get; set; }
        public string Positive { get; set; }
        public string Negative { get; set; }
    }

    /// <summary>Data/Audio/accessibility.json.</summary>
    public sealed class AccessibilityFile
    {
        public int Version { get; set; } = 1;
        public string Notes { get; set; }
        public AccessibilitySettings Defaults { get; set; } = new AccessibilitySettings();
        public Dictionary<string, double[]> Ranges { get; set; } = new Dictionary<string, double[]>();
        public double ReducedFlashCap { get; set; }
        public Dictionary<string, double> SubtitleSizes { get; set; } = new Dictionary<string, double>();
        public List<string> SubtitleBackgrounds { get; set; } = new List<string>();
        public List<string> HoldActions { get; set; } = new List<string>();
        public Dictionary<string, AccessibilityPalette> Palettes { get; set; } = new Dictionary<string, AccessibilityPalette>();
        public Dictionary<string, string> TelegraphShapes { get; set; } = new Dictionary<string, string>();
    }

    public static class AccessibilityRules
    {
        static bool Hex(string s) =>
            s != null && s.Length == 7 && s[0] == '#' && s.Skip(1).All(c => (c >= '0' && c <= '9') || (c >= 'A' && c <= 'F') || (c >= 'a' && c <= 'f'));

        /// <summary>Checks the data file against the Core limits and palette rules; returns the problems (empty = fine).</summary>
        public static List<string> Validate(AccessibilityFile f)
        {
            var errors = new List<string>();
            if (f == null) { errors.Add("no accessibility data"); return errors; }
            void Range(string key, double lo, double hi)
            {
                if (!f.Ranges.TryGetValue(key, out var r) || r.Length != 2) errors.Add($"missing range {key}");
                else if (Math.Abs(r[0] - lo) > 1e-9 || Math.Abs(r[1] - hi) > 1e-9) errors.Add($"range {key} [{r[0]}, {r[1]}] does not match Core [{lo}, {hi}]");
            }
            Range("textScale", AccessibilityLimits.TextScaleMin, AccessibilityLimits.TextScaleMax);
            Range("hudScale", AccessibilityLimits.HudScaleMin, AccessibilityLimits.HudScaleMax);
            Range("dialogueTextSpeed", AccessibilityLimits.TextSpeedMin, AccessibilityLimits.TextSpeedMax);
            foreach (var k in new[] { "screenShake", "flashIntensity", "motionBlur", "volume" }) Range(k, 0, 1);
            if (Math.Abs(f.ReducedFlashCap - AccessibilityLimits.ReducedFlashCap) > 1e-9) errors.Add("reducedFlashCap does not match Core");
            if (!f.HoldActions.SequenceEqual(AccessibilityLimits.HoldActions)) errors.Add("holdActions do not match Core");
            foreach (var p in Enum.GetNames(typeof(ColorblindPalette)))
            {
                var key = p.ToLowerInvariant();
                if (!f.Palettes.TryGetValue(key, out var pal)) { errors.Add($"missing palette {key}"); continue; }
                var colors = new[] { pal.Parry, pal.Unblockable, pal.Grab, pal.HpLow, pal.Positive, pal.Negative };
                if (colors.Any(c => !Hex(c))) errors.Add($"palette {key} has a bad colour");
                else if (new[] { pal.Parry, pal.Unblockable, pal.Grab }.Select(c => c.ToUpperInvariant()).Distinct().Count() != 3) errors.Add($"palette {key}: the three telegraph colours must differ");
            }
            if (f.Palettes.Count != Enum.GetNames(typeof(ColorblindPalette)).Length) errors.Add("palette count does not match the palette choices");
            foreach (var s in new[] { "parry", "unblockable", "grab" })
                if (!f.TelegraphShapes.ContainsKey(s)) errors.Add($"no telegraph shape for {s}");
            if (f.TelegraphShapes.Values.Distinct().Count() != f.TelegraphShapes.Count) errors.Add("telegraph shapes must differ (shape carries what colour cannot)");
            foreach (var kv in new Dictionary<string, SubtitleSize> { { "small", SubtitleSize.Small }, { "medium", SubtitleSize.Medium }, { "large", SubtitleSize.Large }, { "extraLarge", SubtitleSize.ExtraLarge } })
                if (!f.SubtitleSizes.TryGetValue(kv.Key, out var scale) || Math.Abs(scale - AccessibilitySettings.SubtitleScale(kv.Value)) > 1e-9) errors.Add($"subtitle size {kv.Key} does not match Core");
            var d = new AccessibilitySettings();
            var fd = f.Defaults;
            if (fd.ScreenShake != d.ScreenShake || fd.FlashIntensity != d.FlashIntensity || fd.MotionBlur != d.MotionBlur || fd.TextScale != d.TextScale
                || fd.HudScale != d.HudScale || fd.DialogueTextSpeed != d.DialogueTextSpeed || fd.SubtitleSize != d.SubtitleSize
                || fd.SubtitleBackground != d.SubtitleBackground || fd.SubtitlesEnabled != d.SubtitlesEnabled || fd.ColorblindPalette != d.ColorblindPalette
                || fd.ReducedFlash != d.ReducedFlash || fd.HighContrastPanels != d.HighContrastPanels || fd.DyslexiaFont != d.DyslexiaFont || fd.NoCombatMusic != d.NoCombatMusic || fd.ReducedMusicIntensity != d.ReducedMusicIntensity || fd.Volumes.Master != d.Volumes.Master || fd.Volumes.Music != d.Volumes.Music
                || fd.Volumes.Effects != d.Volumes.Effects || fd.Volumes.Ambience != d.Volumes.Ambience || fd.Volumes.Dialogue != d.Volumes.Dialogue || fd.Volumes.Callouts != d.Volumes.Callouts)
                errors.Add("data defaults differ from the Core defaults");
            return errors;
        }

        /// <summary>The palette for a choice (never null: falls back to Off).</summary>
        public static AccessibilityPalette PaletteFor(AccessibilityFile f, ColorblindPalette choice) =>
            f.Palettes.TryGetValue(choice.ToString().ToLowerInvariant(), out var p) ? p : f.Palettes["off"];
    }
}
