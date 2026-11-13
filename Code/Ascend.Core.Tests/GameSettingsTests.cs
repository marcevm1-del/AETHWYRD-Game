using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Ascend.Core;

// Settings persistence: clamping, rebinds, device split, atomic writes with backup, future files protected.
[Tests]
static class GameSettingsTests
{
    static readonly JsonSerializerOptions Opts = new JsonSerializerOptions { PropertyNameCaseInsensitive = true, Converters = { new JsonStringEnumConverter() } };

    static string TempDir()
    {
        var d = Path.Combine(Path.GetTempPath(), "ascend_settings_test_" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(d);
        return d;
    }

    static SettingsStore<GameSettings> Store(string path) => new SettingsStore<GameSettings>(path,
        s => JsonSerializer.Serialize(s, Opts), t => JsonSerializer.Deserialize<GameSettings>(t, Opts),
        s => SettingsRules.Upgrade(s), SettingsRules.Validate);

    public static void DefaultsAreSafeAndValid()
    {
        var s = SettingsRules.Upgrade(new GameSettings());
        Assert.Equal(0, SettingsRules.Validate(s).Count, "valid");
        Assert.Equal(1.0, s.Accessibility.Volumes.Master, "master volume default");
    }

    public static void OutOfRangeValuesAreClamped()
    {
        var s = SettingsRules.Upgrade(JsonSerializer.Deserialize<GameSettings>(
            "{\"LookSensitivity\":99,\"GamepadDeadzone\":-4,\"Accessibility\":{\"TextScale\":50,\"Volumes\":{\"Master\":7,\"Music\":-1}}}", Opts));
        Assert.Equal(SettingsLimits.LookMax, s.LookSensitivity, "look max");
        Assert.Equal(SettingsLimits.DeadzoneMin, s.GamepadDeadzone, "deadzone min");
        Assert.Equal(AccessibilityLimits.TextScaleMax, s.Accessibility.TextScale, "text scale");
        Assert.Equal(1.0, s.Accessibility.Volumes.Master, "bus clamped high");
        Assert.Equal(0.0, s.Accessibility.Volumes.Music, "bus clamped low");
    }

    public static void BindingsAreCleanedAndCapped()
    {
        var s = SettingsRules.Upgrade(new GameSettings
        {
            Bindings = new Dictionary<string, List<string>>
            {
                ["jump"] = new List<string> { "<Keyboard>/space", "<Keyboard>/space", "", "<Gamepad>/buttonSouth", "<Keyboard>/x", "<Keyboard>/y" },
                ["gone"] = new List<string> { "<Keyboard>/q" },
                ["empty"] = new List<string>(),
                [" "] = new List<string> { "<Keyboard>/z" },
                ["long"] = new List<string> { new string('a', 200) },
            }
        }, new[] { "jump", "empty", "long" });
        Assert.Equal(1, s.Bindings.Count, "only the usable known action survives");
        Assert.Equal(3, s.Bindings["jump"].Count, "deduped, blanks dropped, capped at three");
        Assert.Equal("<Keyboard>/space", s.Bindings["jump"][0], "order kept");
    }

    public static void SharedBindingsAreReportedAsConflicts()
    {
        var s = new GameSettings { Bindings = new Dictionary<string, List<string>>
        {
            ["jump"] = new List<string> { "<Keyboard>/space" }, ["dodge"] = new List<string> { "<Keyboard>/space", "<Keyboard>/c" }, ["use"] = new List<string> { "<Keyboard>/e" },
        } };
        var c = SettingsRules.FindConflicts(s);
        Assert.Equal(1, c.Count, "one clash");
        Assert.Equal(2, c["<Keyboard>/space"].Count, "two actions share space");
    }

    public static void DeviceSettingsFallBackPerField()
    {
        var d = SettingsRules.Upgrade(new DeviceSettings { Width = 10, Height = 99999, Quality = 9, TargetFps = -5, Fullscreen = false });
        Assert.Equal(1920, d.Width, "bad width"); Assert.Equal(1080, d.Height, "bad height");
        Assert.Equal(2, d.Quality, "bad quality"); Assert.Equal(0, d.TargetFps, "bad fps");
        Assert.True(!d.Fullscreen, "valid fields are kept");
    }

    public static void ASeedFromAnOldSaveKeepsItsAccessibilityChoices()
    {
        var save = new SaveGame { Accessibility = new AccessibilitySettings { DyslexiaFont = true, TextScale = 1.5 } };
        var g = SettingsRules.SeedFrom(save);
        Assert.True(g.Accessibility.DyslexiaFont && g.Accessibility.TextScale == 1.5, "carried over");
        Assert.True(SettingsRules.SeedFrom(new SaveGame()).Accessibility != null, "a save without the block still seeds");
    }

    public static void SaveThenLoadRoundTripsAndKeepsABackupOnTheSecondSave()
    {
        var dir = TempDir(); var path = Path.Combine(dir, "settings.json");
        try
        {
            var st = Store(path);
            var s = st.Load();
            s.InvertLookY = true; s.Bindings["jump"] = new List<string> { "<Keyboard>/j" };
            Assert.True(st.Save(s), "first save");
            Assert.True(!File.Exists(AtomicFile.BackupPath(path)), "no backup yet");
            s.LookSensitivity = 2.0;
            Assert.True(st.Save(s), "second save");
            Assert.True(File.Exists(AtomicFile.BackupPath(path)), "previous file kept as .bak");
            Assert.True(!File.Exists(path + ".tmp"), "no temp file left behind");
            var back = Store(path).Load();
            Assert.True(back.InvertLookY && back.LookSensitivity == 2.0 && back.Bindings["jump"][0] == "<Keyboard>/j", "values round trip");
        }
        finally { Directory.Delete(dir, true); }
    }

    public static void ACorruptMainFileRestoresFromTheBackup()
    {
        var dir = TempDir(); var path = Path.Combine(dir, "settings.json");
        try
        {
            var st = Store(path); var s = st.Load(); s.LookSensitivity = 1.5; st.Save(s); s.LookSensitivity = 2.5; st.Save(s);
            File.WriteAllText(path, "{ this is not json");
            var st2 = Store(path);
            var r = st2.Load();
            Assert.Equal(1.5, r.LookSensitivity, "the previous good save is used");
            Assert.True(st2.Notes.Any(n => n.Contains("backup")), "the player can be told");
            File.Delete(AtomicFile.BackupPath(path));
            var r2 = Store(path).Load();
            Assert.Equal(1.0, r2.LookSensitivity, "no good copy at all gives defaults, never a throw");
        }
        finally { Directory.Delete(dir, true); }
    }

    public static void AFutureFileIsNeverOverwritten()
    {
        var dir = TempDir(); var path = Path.Combine(dir, "settings.json");
        try
        {
            var future = "{\"Version\":" + (GameSettings.CurrentVersion + 5) + ",\"LookSensitivity\":2.2}";
            File.WriteAllText(path, future);
            var st = Store(path);
            var s = st.Load();
            Assert.True(st.LoadedFutureFile, "flagged");
            Assert.Equal(1.0, s.LookSensitivity, "defaults used this session");
            Assert.True(!st.Save(s), "save refused");
            Assert.Equal(future, File.ReadAllText(path), "the newer build's file is untouched");
        }
        finally { Directory.Delete(dir, true); }
    }

    public static void AMissingFileGivesDefaultsAndTheFirstSaveCreatesIt()
    {
        var dir = TempDir(); var path = Path.Combine(dir, "sub", "settings.json");
        try
        {
            var st = Store(path); var s = st.Load();
            Assert.Equal(0, SettingsRules.Validate(s).Count, "defaults valid");
            Assert.True(st.Save(s) && File.Exists(path), "created, including the folder");
        }
        finally { Directory.Delete(dir, true); }
    }

    public static void AtomicWriteNeverLeavesTheFileMissing()
    {
        var dir = TempDir(); var path = Path.Combine(dir, "x.json");
        try
        {
            for (int i = 0; i < 5; i++) { AtomicFile.WriteAllText(path, "v" + i); Assert.Equal("v" + i, File.ReadAllText(path), "content " + i); }
            Assert.Equal("v3", File.ReadAllText(AtomicFile.BackupPath(path)), "backup is the one before");
        }
        finally { Directory.Delete(dir, true); }
    }
}
