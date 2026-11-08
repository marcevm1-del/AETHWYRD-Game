using System;
using System.Collections.Generic;
using System.Linq;
using Ascend.Core;
using UnityEngine;

namespace Ascend.Game
{
    /// <summary>
    /// The Accessibility page (hud_and_ui.md section 14; IMGUI placeholder): exactly the Core <see cref="AccessibilitySettings"/>.
    /// Left/Right (or Enter) changes the row under the cursor in the Core steps, every change goes through Sanitize and
    /// <see cref="PlayerWorldState.ApplyAccessibility"/> (which pushes the music options), and the saved slot is updated when the
    /// window closes. This window itself follows the text scale and the high-contrast panel setting. Opened with F5.
    /// </summary>
    public sealed class AccessibilityWindow : SystemWindow
    {
        static AccessibilityWindow _instance;
        public static bool IsOpen => _instance != null && _instance._open;
        public static AccessibilityWindow Instance => _instance != null ? _instance : _instance = Create<AccessibilityWindow>();

        bool _changed;

        protected override string Title => "ACCESSIBILITY";
        protected override string Footer => "Changes apply at once and are saved with your game when you close this page.";

        protected override void OnClosed()
        {
            if (!_changed) return;
            _changed = false;
            var p = PlayerObject;
            var save = p != null ? p.GetComponent<PlayerSave>() : null;
            if (save != null) save.Save();
        }

        protected override void Build(List<Row> rows)
        {
            var world = World;
            if (world == null || world.Accessibility == null) { rows.Add(Info("Accessibility settings are not available yet.", true)); return; }
            var a = world.Accessibility;
            var d = new AccessibilitySettings(); // the defaults, for the notch on each bar

            rows.Add(Header("TEXT AND PANELS"));
            rows.Add(SliderRow("Text size", () => a.TextScale, v => a.TextScale = v, AccessibilityLimits.TextScaleMin, AccessibilityLimits.TextScaleMax, 0.1, "0.0#", "×", def: d.TextScale));
            rows.Add(NoteRow("Sample: The guild board opens at dawn. Read it like this."));
            rows.Add(SliderRow("HUD size", () => a.HudScale, v => a.HudScale = v, AccessibilityLimits.HudScaleMin, AccessibilityLimits.HudScaleMax, 0.05, "0.0#", "×", def: d.HudScale));
            rows.Add(ToggleRow("High-contrast panels", () => a.HighContrastPanels, v => a.HighContrastPanels = v));
            rows.Add(ToggleRow("Dyslexia-friendly font", () => a.DyslexiaFont, v => a.DyslexiaFont = v));
            rows.Add(CycleRow("Colourblind mode", () => a.ColorblindPalette, v => a.ColorblindPalette = v));
            var pal = world.AccessibilityData != null && world.AccessibilityData.Palettes.Count > 0 ? AccessibilityRules.PaletteFor(world.AccessibilityData, a.ColorblindPalette) : null;
            if (pal != null) rows.Add(NoteRow($"Telegraph colours: parry {pal.Parry}, unblockable {pal.Unblockable}, grab {pal.Grab}. Shapes differ too."));

            rows.Add(Header("SUBTITLES AND DIALOGUE"));
            rows.Add(ToggleRow("Subtitles", () => a.SubtitlesEnabled, v => a.SubtitlesEnabled = v));
            rows.Add(CycleRow("Subtitle size", () => a.SubtitleSize, v => a.SubtitleSize = v));
            rows.Add(CycleRow("Subtitle background", () => a.SubtitleBackground, v => a.SubtitleBackground = v));
            rows.Add(SliderRow("Dialogue text speed", () => a.DialogueTextSpeed, v => a.DialogueTextSpeed = v, AccessibilityLimits.TextSpeedMin, AccessibilityLimits.TextSpeedMax, 0.25, "0.0#", "×", def: d.DialogueTextSpeed));
            rows.Add(NoteRow("Speaker names are always shown."));

            rows.Add(Header("MOTION AND FLASHES"));
            rows.Add(SliderRow("Screen shake", () => a.ScreenShake, v => a.ScreenShake = v, 0, 1, 0.1, "0%", def: d.ScreenShake));
            rows.Add(SliderRow("Flash intensity", () => a.FlashIntensity, v => a.FlashIntensity = v, 0, 1, 0.1, "0%", def: d.FlashIntensity));
            rows.Add(NoteRow(a.ReducedFlash ? $"Flashes are currently {a.EffectiveFlash * 100:0}% strength (Reduced flashes is on)." : $"Flashes are currently {a.EffectiveFlash * 100:0}% strength. Turn on Reduced flashes to lower them."));
            rows.Add(SliderRow("Motion blur", () => a.MotionBlur, v => a.MotionBlur = v, 0, 1, 0.1, "0%", def: d.MotionBlur));
            rows.Add(ToggleRow("Reduced flashes", () => a.ReducedFlash, v => a.ReducedFlash = v));

            rows.Add(Header("SOUND"));
            var vol = a.Volumes;
            rows.Add(SliderRow("Master volume", () => vol.Master, v => vol.Master = v, 0, 1, 0.1, "0%", def: d.Volumes.Master));
            rows.Add(SliderRow("Music volume", () => vol.Music, v => vol.Music = v, 0, 1, 0.1, "0%", def: d.Volumes.Music));
            rows.Add(SliderRow("Effects volume", () => vol.Effects, v => vol.Effects = v, 0, 1, 0.1, "0%", def: d.Volumes.Effects));
            rows.Add(SliderRow("Ambience volume", () => vol.Ambience, v => vol.Ambience = v, 0, 1, 0.1, "0%", def: d.Volumes.Ambience));
            rows.Add(SliderRow("Dialogue volume", () => vol.Dialogue, v => vol.Dialogue = v, 0, 1, 0.1, "0%", def: d.Volumes.Dialogue));
            rows.Add(SliderRow("Companion callouts", () => vol.Callouts, v => vol.Callouts = v, 0, 1, 0.1, "0%", def: d.Volumes.Callouts));
            rows.Add(ToggleRow("No combat music", () => a.NoCombatMusic, v => a.NoCombatMusic = v));
            rows.Add(ToggleRow("Calmer music in fights", () => a.ReducedMusicIntensity, v => a.ReducedMusicIntensity = v));

            rows.Add(Header("HOLD OR TOGGLE"));
            foreach (var action in AccessibilityLimits.HoldActions)
            {
                var id = action;
                rows.Add(ToggleRow(Pretty(id) + " (toggle instead of hold)", () => a.IsToggle(id), v => a.SetToggle(id, v)));
            }
        }

        // ------------------------------------------------------------------ row makers

        void Commit()
        {
            var world = World;
            if (world == null) return;
            world.Accessibility.Sanitize();
            world.ApplyAccessibility();
            _changed = true;
        }

        Row ToggleRow(string label, Func<bool> get, Action<bool> set)
        {
            Action flip = () => { set(!get()); Commit(); };
            return new Row { Text = $"{label}: {(get() ? "On" : "Off")}", Act = flip, Adjust = _ => flip() };
        }

        Row SliderRow(string label, Func<double> get, Action<double> set, double lo, double hi, double step, string format, string suffix = "", double def = double.NaN)
        {
            double v = get();
            string shown = format.EndsWith("%") ? (v * 100).ToString("0") + "%" : v.ToString(format, System.Globalization.CultureInfo.InvariantCulture) + suffix;
            return new Row
            {
                Text = $"{label}: {shown}",
                Adjust = dir =>
                {
                    double next = Math.Round(Math.Max(lo, Math.Min(hi, get() + dir * step)) / step) * step;
                    set(Math.Round(Math.Max(lo, Math.Min(hi, next)), 4));
                    Commit();
                },
                Bar = hi > lo ? (float)((v - lo) / (hi - lo)) : 0f,
                BarDefault = hi > lo && !double.IsNaN(def) ? (float)((def - lo) / (hi - lo)) : -1f,
            };
        }

        Row CycleRow<T>(string label, Func<T> get, Action<T> set) where T : struct, Enum
        {
            var values = (T[])Enum.GetValues(typeof(T));
            Action<int> step = dir =>
            {
                int i = Array.IndexOf(values, get());
                set(values[((i < 0 ? 0 : i) + dir + values.Length) % values.Length]);
                Commit();
            };
            return new Row { Text = $"{label}: {get()}", Act = () => step(1), Adjust = step };
        }

        static string Pretty(string actionId) => string.IsNullOrEmpty(actionId) ? "" : char.ToUpperInvariant(actionId[0]) + actionId.Substring(1).Replace('_', ' ');
    }
}
