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
}
