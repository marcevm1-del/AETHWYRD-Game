using System;
using System.Collections.Generic;
using Ascend.Core;

// Save slots: capture, validate, restore (systems.md §10; autosave at waystones).
[Tests]
static class SaveGameTests
{
    public static void CaptureAndApplyRoundTrip()
    {
        var prog = new PlayerProgress(Repo.Db.Progression, 4);
        prog.AddXp(prog.ToNext / 3);
        var inv = new Inventory(); inv.AddCopper(1234); inv.Add("itm_core_f", 3);
        var save = SaveRules.Capture(prog, inv, Difficulty.Veteran, new DateTime(2026, 10, 24, 12, 0, 0, DateTimeKind.Utc));
        Assert.Equal("2026-10-24T12:00:00.0000000Z", save.SavedAtUtc, "ISO time, invariant");
        Assert.Equal(0, SaveRules.Validate(save).Count, "a fresh capture is valid");

        var prog2 = new PlayerProgress(Repo.Db.Progression);
        var inv2 = new Inventory();
        SaveRules.Apply(save, prog2, inv2);
        Assert.Equal(prog.Level, prog2.Level, "level restored");
        Assert.Equal(prog.XpIntoLevel, prog2.XpIntoLevel, "XP restored");
        Assert.Equal(1234L, inv2.Copper, "money restored");
        Assert.Equal(3, inv2.Count("itm_core_f"), "items restored");
        inv.Add("itm_core_f");
        Assert.Equal(3, save.Items["itm_core_f"], "the save is a copy, not a live view");
    }

    public static void BadSavesAreRejected()
    {
        Assert.True(SaveRules.Validate(null).Count > 0, "null");
        Assert.True(SaveRules.Validate(new SaveGame { Version = 99 }).Count > 0, "future version");
        Assert.True(SaveRules.Validate(new SaveGame { Level = 0 }).Count > 0, "level 0");
        Assert.True(SaveRules.Validate(new SaveGame { Copper = -1 }).Count > 0, "negative money");
        Assert.True(SaveRules.Validate(new SaveGame { Items = new Dictionary<string, int> { ["x"] = 0 } }).Count > 0, "empty stack");
        Assert.True(SaveRules.Validate(new SaveGame { Respawn = new[] { 1f, 2f } }).Count > 0, "short respawn");
        Assert.True(SaveRules.Validate(new SaveGame { Respawn = new[] { float.NaN, 0, 0, 0 } }).Count > 0, "NaN respawn");
    }

    public static void UpgradeFillsMissingParts()
    {
        var s = SaveRules.Upgrade(new SaveGame { Items = null });
        Assert.True(s.Items != null, "items never null after upgrade");
        Assert.Equal(SaveGame.CurrentVersion, s.Version, "current version");
    }
}
