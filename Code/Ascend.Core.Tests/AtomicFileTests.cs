using System;
using System.IO;
using Ascend.Core;

// Crash-safe writes: each test simulates a crash at one step of the save. Temp directories only, never the real player slot.
[Tests]
static class AtomicFileTests
{
    static string TempDir()
    {
        var d = Path.Combine(Path.GetTempPath(), "ascend_atomic_test_" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(d);
        return d;
    }

    static bool Good(string t) => t.StartsWith("{") && t.EndsWith("}");

    public static void ASecondWriteKeepsTheFirstAsTheBackup()
    {
        var d = TempDir();
        try
        {
            var p = Path.Combine(d, "slot0.json");
            AtomicFile.WriteAllText(p, "{\"v\":1}");
            Assert.True(!File.Exists(AtomicFile.BackupPath(p)), "no backup after the first write");
            AtomicFile.WriteAllText(p, "{\"v\":2}");
            Assert.Equal("{\"v\":2}", File.ReadAllText(p), "main is the newest");
            Assert.Equal("{\"v\":1}", File.ReadAllText(AtomicFile.BackupPath(p)), "backup is the previous save");
            Assert.True(!File.Exists(AtomicFile.TempPath(p)), "no temp file left behind");
        }
        finally { Directory.Delete(d, true); }
    }

    public static void CrashAfterTheOldFileWasRemovedStillLoadsTheBackup()
    {
        var d = TempDir();
        try
        {
            var p = Path.Combine(d, "slot0.json");
            AtomicFile.WriteAllText(p, "{\"v\":1}");
            AtomicFile.WriteAllText(p, "{\"v\":2}");
            File.Delete(p); // crash: target gone, backup present
            var t = AtomicFile.ReadWithRecovery(p, Good, out var src);
            Assert.Equal("{\"v\":1}", t, "backup text");
            Assert.Equal("backup", src, "source");
        }
        finally { Directory.Delete(d, true); }
    }

    public static void CrashBeforeTheSwapLoadsTheLeftoverTempWhenItIsTheOnlyFile()
    {
        var d = TempDir();
        try
        {
            var p = Path.Combine(d, "slot0.json");
            File.WriteAllText(AtomicFile.TempPath(p), "{\"v\":3}"); // crash: only the .tmp exists
            var t = AtomicFile.ReadWithRecovery(p, Good, out var src);
            Assert.Equal("{\"v\":3}", t, "temp text");
            Assert.Equal("temp", src, "source");
            Assert.True(AtomicFile.AnyExists(p), "AnyExists sees a lone temp file");
        }
        finally { Directory.Delete(d, true); }
    }

    public static void ACorruptMainFallsBackToTheBackup()
    {
        var d = TempDir();
        try
        {
            var p = Path.Combine(d, "slot0.json");
            AtomicFile.WriteAllText(p, "{\"v\":1}");
            AtomicFile.WriteAllText(p, "{\"v\":2}");
            File.WriteAllText(p, "{\"v\":2"); // truncated main
            var t = AtomicFile.ReadWithRecovery(p, Good, out var src);
            Assert.Equal("{\"v\":1}", t, "backup text");
            Assert.Equal("backup", src, "source");
        }
        finally { Directory.Delete(d, true); }
    }

    public static void ATruncatedTempIsRejectedAndNothingIsReturnedWhenNothingIsGood()
    {
        var d = TempDir();
        try
        {
            var p = Path.Combine(d, "slot0.json");
            File.WriteAllText(AtomicFile.TempPath(p), "{\"v\":"); // crash mid-write
            var t = AtomicFile.ReadWithRecovery(p, Good, out var src);
            Assert.True(t == null && src == null, "no usable file");
        }
        finally { Directory.Delete(d, true); }
    }

    public static void ReadWithFallbackNeverUsesTheTempFile()
    {
        var d = TempDir();
        try
        {
            var p = Path.Combine(d, "slot0.json");
            File.WriteAllText(AtomicFile.TempPath(p), "{\"v\":3}");
            Assert.True(AtomicFile.ReadWithFallback(p, Good, out var usedBackup) == null && !usedBackup, "temp ignored");
        }
        finally { Directory.Delete(d, true); }
    }

    public static void AGoodBackupSurvivesTheNextSaveAfterARecovery()
    {
        var d = TempDir();
        try
        {
            var p = Path.Combine(d, "slot0.json");
            AtomicFile.WriteAllText(p, "{\"v\":1}");
            AtomicFile.WriteAllText(p, "{\"v\":2}");
            File.WriteAllText(p, "{\"v\":2"); // main corrupted, .bak holds v1
            AtomicFile.ReadWithRecovery(p, Good, out var src);
            Assert.Equal("backup", src, "recovered from the backup");
            Assert.True(AtomicFile.QuarantineMain(p), "corrupt main moved aside");
            Assert.True(!File.Exists(p), "main slot cleared");
            Assert.Equal("{\"v\":2", File.ReadAllText(p + ".bad"), "corrupt copy kept as .bad");
            AtomicFile.WriteAllText(p, "{\"v\":3}"); // the next save
            Assert.Equal("{\"v\":3}", File.ReadAllText(p), "new main");
            Assert.Equal("{\"v\":1}", File.ReadAllText(AtomicFile.BackupPath(p)), "the good backup was not replaced by the corrupt file");
        }
        finally { Directory.Delete(d, true); }
    }

    public static void QuarantineDoesNothingWhenThereIsNoMainFile()
    {
        var d = TempDir();
        try
        {
            var p = Path.Combine(d, "slot0.json");
            Assert.True(!AtomicFile.QuarantineMain(p), "nothing to quarantine");
            Assert.True(!File.Exists(p + ".bad"), "no .bad invented");
        }
        finally { Directory.Delete(d, true); }
    }

    public static void AStopVerdictEndsTheSearchInsteadOfFallingToTheBackup()
    {
        var d = TempDir();
        try
        {
            var p = Path.Combine(d, "slot0.json");
            AtomicFile.WriteAllText(p, "{\"alive\":true}");
            AtomicFile.WriteAllText(p, "{\"fallen\":true}"); // .bak is the older, living save
            var t = AtomicFile.ReadWithRecovery(p, x => x.Contains("fallen") ? AtomicFile.Verdict.Stop : AtomicFile.Verdict.Accept, out var src);
            Assert.True(t == null && src == null, "a fallen main must not fall through to the living backup");
        }
        finally { Directory.Delete(d, true); }
    }
}
