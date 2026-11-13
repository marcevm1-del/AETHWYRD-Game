using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Ascend.Core
{
    // Settings that belong to the player, not to a save slot: accessibility, audio buses and control bindings travel in
    // settings.json (cloud-synced, see 13_Production/steam_cloud_save_plan.md). Machine-specific choices (resolution, quality)
    // live in device.json and are never synced. Both files are written atomically with a .bak, load never throws, and every
    // value is clamped, so a hand-edited or damaged file can never lock the player out of the menu.

    /// <summary>The player's settings file. Version is bumped when a field changes meaning; <see cref="SettingsRules.Upgrade"/> reads older shapes.</summary>
    public sealed class GameSettings
    {
        public const int CurrentVersion = 1;
        public int Version { get; set; } = CurrentVersion;
        /// <summary>Accessibility, presentation, the six audio buses and hold-to-toggle choices (the same DTO the save used to carry alone).</summary>
        public AccessibilitySettings Accessibility { get; set; } = new AccessibilitySettings();
        /// <summary>Control rebinds: action id to the binding paths (Input System strings such as "&lt;Keyboard&gt;/e"). Missing action = the default binding.</summary>
        public Dictionary<string, List<string>> Bindings { get; set; } = new Dictionary<string, List<string>>();
        /// <summary>Camera and aim feel.</summary>
        public double LookSensitivity { get; set; } = 1.0;
        public bool InvertLookY { get; set; }
        public double GamepadDeadzone { get; set; } = 0.2;
    }

    /// <summary>Per-machine display and quality choices. Kept out of the synced settings file on purpose.</summary>
    public sealed class DeviceSettings
    {
        public const int CurrentVersion = 1;
        public int Version { get; set; } = CurrentVersion;
        public int Width { get; set; } = 1920;
        public int Height { get; set; } = 1080;
        public bool Fullscreen { get; set; } = true;
        public bool VSync { get; set; } = true;
        /// <summary>0 low, 1 medium, 2 high.</summary>
        public int Quality { get; set; } = 2;
        /// <summary>Frame cap; 0 = uncapped.</summary>
        public int TargetFps { get; set; } = 0;
    }

    public static class SettingsLimits
    {
        public const double LookMin = 0.2, LookMax = 3.0;
        public const double DeadzoneMin = 0.0, DeadzoneMax = 0.6;
        public const int MaxBindingsPerAction = 3, MaxBindingLength = 64;
        public const int MinWidth = 640, MinHeight = 360, MaxWidth = 7680, MaxHeight = 4320, MaxFps = 360;
    }

    public static class SettingsRules
    {
        static double Clamp(double v, double lo, double hi, double fb) => double.IsNaN(v) || double.IsInfinity(v) ? fb : Math.Max(lo, Math.Min(hi, v));

        /// <summary>Fills and clamps a loaded settings object. A future version is left as it is (and reported by <see cref="Validate"/>) so an old build never rewrites it.</summary>
        /// <param name="knownActions">If given, bindings for other actions are dropped (an action renamed or removed in a later build).</param>
        public static GameSettings Upgrade(GameSettings s, IEnumerable<string> knownActions = null)
        {
            if (s == null) return new GameSettings();
            s.Accessibility = (s.Accessibility ?? new AccessibilitySettings()).Sanitize();
            var d = new GameSettings();
            s.LookSensitivity = Clamp(s.LookSensitivity, SettingsLimits.LookMin, SettingsLimits.LookMax, d.LookSensitivity);
            s.GamepadDeadzone = Clamp(s.GamepadDeadzone, SettingsLimits.DeadzoneMin, SettingsLimits.DeadzoneMax, d.GamepadDeadzone);
            var known = knownActions == null ? null : new HashSet<string>(knownActions);
            var clean = new Dictionary<string, List<string>>();
            foreach (var kv in s.Bindings ?? new Dictionary<string, List<string>>())
            {
                if (string.IsNullOrWhiteSpace(kv.Key) || (known != null && !known.Contains(kv.Key))) continue;
                var list = (kv.Value ?? new List<string>())
                    .Where(b => !string.IsNullOrWhiteSpace(b) && b.Length <= SettingsLimits.MaxBindingLength)
                    .Distinct().Take(SettingsLimits.MaxBindingsPerAction).ToList();
                if (list.Count > 0) clean[kv.Key] = list;
            }
            s.Bindings = clean;
            if (s.Version >= 1 && s.Version <= GameSettings.CurrentVersion) s.Version = GameSettings.CurrentVersion;
            return s;
        }

        public static List<string> Validate(GameSettings s)
        {
            var e = new List<string>();
            if (s == null) { e.Add("no settings"); return e; }
            if (s.Version < 1 || s.Version > GameSettings.CurrentVersion) e.Add($"unknown settings version {s.Version}");
            return e;
        }

        public static DeviceSettings Upgrade(DeviceSettings s)
        {
            if (s == null) return new DeviceSettings();
            var d = new DeviceSettings();
            if (s.Width < SettingsLimits.MinWidth || s.Width > SettingsLimits.MaxWidth) s.Width = d.Width;
            if (s.Height < SettingsLimits.MinHeight || s.Height > SettingsLimits.MaxHeight) s.Height = d.Height;
            if (s.Quality < 0 || s.Quality > 2) s.Quality = d.Quality;
            if (s.TargetFps < 0 || s.TargetFps > SettingsLimits.MaxFps) s.TargetFps = d.TargetFps;
            if (s.Version >= 1 && s.Version <= DeviceSettings.CurrentVersion) s.Version = DeviceSettings.CurrentVersion;
            return s;
        }

        /// <summary>One-time seed for a player who already has saves from before settings.json existed: take the accessibility block from a loaded save.</summary>
        public static GameSettings SeedFrom(SaveGame save)
        {
            var g = new GameSettings();
            if (save?.Accessibility != null) g.Accessibility = save.Accessibility.Sanitize();
            return g;
        }

        /// <summary>Bindings that two different actions share (a conflict the rebind screen must resolve). Returns binding path to the actions using it.</summary>
        public static Dictionary<string, List<string>> FindConflicts(GameSettings s)
        {
            var by = new Dictionary<string, List<string>>();
            foreach (var kv in s?.Bindings ?? new Dictionary<string, List<string>>())
                foreach (var b in kv.Value ?? new List<string>())
                {
                    if (!by.TryGetValue(b, out var l)) by[b] = l = new List<string>();
                    if (!l.Contains(kv.Key)) l.Add(kv.Key);
                }
            return by.Where(kv => kv.Value.Count > 1).ToDictionary(kv => kv.Key, kv => kv.Value);
        }
    }

    /// <summary>
    /// Crash-safe file writes. Temp file, then replace with the previous file kept as <c>path.bak</c>, so there is never a moment with no file.
    /// Reads fall back to the backup when the main file is missing or rejected. Used for saves, settings and anything else that must survive a crash.
    /// </summary>
    public static class AtomicFile
    {
        public static string BackupPath(string path) => path + ".bak";

        public static void WriteAllText(string path, string text)
        {
            if (string.IsNullOrEmpty(path)) throw new ArgumentException("path");
            var dir = Path.GetDirectoryName(path);
            if (!string.IsNullOrEmpty(dir)) Directory.CreateDirectory(dir);
            var tmp = path + ".tmp";
            File.WriteAllText(tmp, text ?? "");
            if (File.Exists(path))
            {
                try { File.Replace(tmp, path, BackupPath(path)); return; }
                catch (PlatformNotSupportedException) { }
                catch (IOException) { }
                // Fallback: keep the old file as the backup, then move the new one in. The old copy is never deleted first.
                File.Copy(path, BackupPath(path), true);
                File.Copy(tmp, path, true);
                File.Delete(tmp);
            }
            else File.Move(tmp, path);
        }

        /// <summary>Reads the first candidate (main, then backup) for which <paramref name="accept"/> returns true. Null if none.</summary>
        public static string ReadWithFallback(string path, Func<string, bool> accept, out bool usedBackup)
        {
            usedBackup = false;
            foreach (var (p, isBak) in new[] { (path, false), (BackupPath(path), true) })
            {
                try
                {
                    if (!File.Exists(p)) continue;
                    var text = File.ReadAllText(p);
                    if (accept == null || accept(text)) { usedBackup = isBak; return text; }
                }
                catch (Exception) { }
            }
            return null;
        }
    }

    /// <summary>Loads and saves one settings object. Never throws on load: a missing, damaged or future-version file yields defaults (or the backup) plus a note.</summary>
    public sealed class SettingsStore<T> where T : class, new()
    {
        private readonly string _path;
        private readonly Func<T, string> _serialize;
        private readonly Func<string, T> _deserialize;
        private readonly Func<T, T> _upgrade;
        private readonly Func<T, List<string>> _validate;
        public List<string> Notes { get; } = new List<string>();

        public SettingsStore(string path, Func<T, string> serialize, Func<string, T> deserialize, Func<T, T> upgrade, Func<T, List<string>> validate = null)
        {
            _path = path; _serialize = serialize; _deserialize = deserialize; _upgrade = upgrade; _validate = validate;
        }

        /// <summary>True when the file was written by a newer build; the caller must then not Save over it (use defaults for this session).</summary>
        public bool LoadedFutureFile { get; private set; }

        public T Load()
        {
            Notes.Clear(); LoadedFutureFile = false;
            T result = null;
            var text = AtomicFile.ReadWithFallback(_path, t =>
            {
                try
                {
                    var obj = _upgrade(_deserialize(t));
                    var errs = _validate?.Invoke(obj) ?? new List<string>();
                    if (errs.Count > 0) { Notes.Add("rejected: " + string.Join("; ", errs)); LoadedFutureFile = true; return false; }
                    result = obj; return true;
                }
                catch (Exception e) { Notes.Add("unreadable: " + e.Message); return false; }
            }, out var usedBackup);
            if (text == null) { if (File.Exists(_path)) Notes.Add("using defaults"); return _upgrade(new T()); }
            if (usedBackup) Notes.Add("restored from backup");
            return result;
        }

        /// <summary>Writes atomically. Returns false (and a note) instead of throwing; refuses to overwrite a newer build's file.</summary>
        public bool Save(T value)
        {
            if (LoadedFutureFile) { Notes.Add("not saved: file belongs to a newer build"); return false; }
            try { AtomicFile.WriteAllText(_path, _serialize(value)); return true; }
            catch (Exception e) { Notes.Add("save failed: " + e.Message); return false; }
        }
    }
}
