using System;
using System.IO;
using System.Linq;
using Ascend.Core;

// Crash and log capture: bounded buffer, redaction, report shape, report pruning.
[Tests]
static class PlaytestLogTests
{
    static readonly DateTime T0 = new DateTime(2026, 11, 13, 14, 25, 1, DateTimeKind.Utc);

    static string TempDir()
    {
        var d = Path.Combine(Path.GetTempPath(), "ascend_log_test_" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(d);
        return d;
    }

    public static void TheBufferKeepsOnlyTheNewestLinesAndCountsWhatDropped()
    {
        var b = new LogBuffer(3);
        for (int i = 0; i < 5; i++) b.Add(LogLevel.Info, "m" + i, T0);
        var s = b.Snapshot();
        Assert.Equal(3, s.Count, "capacity");
        Assert.Equal("m2", s[0].Message, "oldest kept"); Assert.Equal("m4", s[2].Message, "newest kept");
        Assert.Equal(2, b.Dropped, "dropped count");
    }

    public static void LongMessagesAreCut()
    {
        var b = new LogBuffer(5, 32);
        b.Add(LogLevel.Error, new string('x', 500), T0);
        Assert.True(b.Snapshot()[0].Message.Length < 60, "cut");
        b.Add(LogLevel.Info, null, T0);
        Assert.Equal("", b.Snapshot()[1].Message, "null becomes empty");
    }

    public static void TheBufferIsThreadSafe()
    {
        var b = new LogBuffer(100);
        System.Threading.Tasks.Parallel.For(0, 4, t => { for (int i = 0; i < 500; i++) b.Add(LogLevel.Info, "t" + t, T0); });
        Assert.Equal(100, b.Count, "stays at capacity");
        Assert.Equal(1900, b.Dropped, "every overflow counted exactly once");
    }

    public static void RedactionHidesUserNamesAndSecrets()
    {
        var t = LogRedactor.Redact("Loaded C:\\Users\\marce\\AppData\\LocalLow\\x.json and /Users/Sam/Library/y token=abc123 mail me at a.b@c.com", "marce");
        Assert.True(!t.ToLowerInvariant().Contains("marce") && !t.Contains("Sam/"), "user names gone: " + t);
        Assert.True(!t.Contains("abc123") && !t.Contains("a.b@c.com"), "secrets gone: " + t);
        Assert.True(t.Contains("AppData\\LocalLow"), "the rest of the path stays useful");
        Assert.Equal("", LogRedactor.Redact(null), "null safe");
    }

    public static void AReportHasTheFactsTheLastLinesAndNoUserName()
    {
        var b = new LogBuffer(50);
        for (int i = 0; i < 10; i++) b.Add(LogLevel.Warning, "line " + i, T0);
        var ctx = new CrashContext { GameVersion = "0.3.1", Platform = "Windows 11", Scene = "Field", PlaySeconds = 3725, UserName = "marce" };
        var r = CrashReport.Build(ctx, "NullReferenceException at C:\\Users\\marce\\x.cs", "at Foo.Bar()", b, T0, 4);
        Assert.True(r.Contains("version: 0.3.1") && r.Contains("platform: Windows 11") && r.Contains("scene: Field"), "header");
        Assert.True(r.Contains("play time: 0.01:02:05"), "play time: " + r);
        Assert.True(r.Contains("save format: " + SaveGame.CurrentVersion), "save format");
        Assert.True(r.Contains("last 4 log lines") && r.Contains("line 9") && !r.Contains("line 5"), "only the tail");
        Assert.True(!r.ToLowerInvariant().Contains("marce"), "redacted");
    }

    public static void AReportBuildsEvenWithNothingKnown()
    {
        var r = CrashReport.Build(null, null, null, null, T0);
        Assert.True(r.Contains("reason: unknown") && r.Contains("last 0 log lines"), "safe on nulls");
    }

    public static void ReportsAreWrittenAndOnlyTheNewestAreKept()
    {
        var dir = TempDir();
        try
        {
            for (int i = 0; i < 6; i++) Assert.True(LogFiles.WriteCrashReport(dir, "r" + i, T0.AddMinutes(i), 3) != null, "written " + i);
            var names = Directory.GetFiles(dir, "crash_*.txt").Select(Path.GetFileName).OrderBy(x => x).ToList();
            Assert.Equal(3, names.Count, "pruned to three");
            Assert.Equal(CrashReport.FileName(T0.AddMinutes(3)), names[0], "oldest kept is the fourth");
            Assert.Equal(CrashReport.FileName(T0.AddMinutes(5)), names[2], "newest kept");
            Assert.Equal(0, LogFiles.Prune(Path.Combine(dir, "nope"), "*", 1), "a missing folder is fine");
        }
        finally { Directory.Delete(dir, true); }
    }
}
