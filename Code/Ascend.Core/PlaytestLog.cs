using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Ascend.Core
{
    // Playtest crash and log capture, engine-free. Unity feeds it from Application.logMessageReceivedThreaded and
    // AppDomain.UnhandledException (a thin hook, see 13_Production/crash_and_log_capture.md). Everything stays on the
    // player's machine: a report is a text file they choose to send, never uploaded by the game.

    public enum LogLevel { Info, Warning, Error, Exception }

    public sealed class LogEntry
    {
        public DateTime TimeUtc { get; set; }
        public LogLevel Level { get; set; }
        public string Message { get; set; }
    }

    /// <summary>A fixed-size ring of the most recent log lines. Thread-safe (Unity logs from worker threads). Oldest lines drop first.</summary>
    public sealed class LogBuffer
    {
        private readonly object _gate = new object();
        private readonly Queue<LogEntry> _q = new Queue<LogEntry>();
        public int Capacity { get; }
        public int MaxMessageLength { get; }
        public int Dropped { get; private set; }

        public LogBuffer(int capacity = 500, int maxMessageLength = 2000)
        {
            if (capacity < 1) throw new ArgumentException("capacity");
            Capacity = capacity; MaxMessageLength = Math.Max(16, maxMessageLength);
        }

        public void Add(LogLevel level, string message, DateTime timeUtc)
        {
            var m = message ?? "";
            if (m.Length > MaxMessageLength) m = m.Substring(0, MaxMessageLength) + "...[cut]";
            lock (_gate)
            {
                _q.Enqueue(new LogEntry { TimeUtc = timeUtc, Level = level, Message = m });
                while (_q.Count > Capacity) { _q.Dequeue(); Dropped++; }
            }
        }

        public List<LogEntry> Snapshot() { lock (_gate) return _q.ToList(); }
        public int Count { get { lock (_gate) return _q.Count; } }

        public static string Format(LogEntry e) => $"{e.TimeUtc:HH:mm:ss.fff} [{e.Level}] {e.Message}";
    }

    public static class LogRedactor
    {
        /// <summary>Removes the player's Windows user name from paths and drops obvious secrets, so a report is safe to share.</summary>
        public static string Redact(string text, string userName = null)
        {
            if (string.IsNullOrEmpty(text)) return text ?? "";
            var t = Regex.Replace(text, @"([A-Za-z]:[\\/]+Users[\\/]+)[^\\/\s""']+", "$1<user>", RegexOptions.IgnoreCase);
            t = Regex.Replace(t, @"(/(?:Users|home)/)[^/\s""']+", "$1<user>");
            if (!string.IsNullOrEmpty(userName) && userName.Length >= 3) t = Regex.Replace(t, Regex.Escape(userName), "<user>", RegexOptions.IgnoreCase);
            t = Regex.Replace(t, @"(?i)\b(api[_-]?key|token|password|secret)\b\s*[=:]\s*\S+", "$1=<hidden>");
            t = Regex.Replace(t, @"[\w.+-]+@[\w-]+\.[\w.-]+", "<email>");
            return t;
        }
    }

    /// <summary>The facts a bug report needs. Never contains the save file itself (it can hold the player's chosen name).</summary>
    public sealed class CrashContext
    {
        public string GameVersion { get; set; } = "unknown";
        public string Platform { get; set; } = "unknown";
        public string Gpu { get; set; }
        public int SaveVersion { get; set; } = SaveGame.CurrentVersion;
        public string Scene { get; set; }
        public double PlaySeconds { get; set; }
        public string UserName { get; set; }
    }

    public static class CrashReport
    {
        /// <summary>Builds the report text: header, what happened, then the last log lines. Redacted. <paramref name="tail"/> limits the log lines included.</summary>
        public static string Build(CrashContext c, string reason, string stackTrace, LogBuffer log, DateTime nowUtc, int tail = 200)
        {
            c ??= new CrashContext();
            var sb = new StringBuilder();
            sb.AppendLine("AETHWYRD crash report");
            sb.AppendLine("time (UTC): " + nowUtc.ToString("yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture));
            sb.AppendLine("version: " + c.GameVersion);
            sb.AppendLine("platform: " + c.Platform);
            if (!string.IsNullOrEmpty(c.Gpu)) sb.AppendLine("gpu: " + c.Gpu);
            sb.AppendLine("save format: " + c.SaveVersion);
            if (!string.IsNullOrEmpty(c.Scene)) sb.AppendLine("scene: " + c.Scene);
            sb.AppendLine("play time: " + TimeSpan.FromSeconds(Math.Max(0, c.PlaySeconds)).ToString(@"d\.hh\:mm\:ss"));
            sb.AppendLine();
            sb.AppendLine("reason: " + (reason ?? "unknown"));
            if (!string.IsNullOrEmpty(stackTrace)) { sb.AppendLine("stack:"); sb.AppendLine(stackTrace); }
            sb.AppendLine();
            var lines = (log?.Snapshot() ?? new List<LogEntry>());
            var shown = lines.Skip(Math.Max(0, lines.Count - Math.Max(0, tail))).ToList();
            sb.AppendLine($"last {shown.Count} log lines ({lines.Count - shown.Count + (log?.Dropped ?? 0)} older not shown):");
            foreach (var e in shown) sb.AppendLine(LogBuffer.Format(e));
            return LogRedactor.Redact(sb.ToString(), c.UserName);
        }

        /// <summary>File name for a report, e.g. <c>crash_20261113_142501.txt</c>.</summary>
        public static string FileName(DateTime nowUtc) => "crash_" + nowUtc.ToString("yyyyMMdd_HHmmss", System.Globalization.CultureInfo.InvariantCulture) + ".txt";
    }

    public static class LogFiles
    {
        /// <summary>Deletes the oldest files matching a pattern so at most <paramref name="keep"/> remain. Returns how many were removed. Never throws.</summary>
        public static int Prune(string dir, string pattern, int keep)
        {
            int removed = 0;
            try
            {
                if (!Directory.Exists(dir)) return 0;
                var files = new DirectoryInfo(dir).GetFiles(pattern).OrderByDescending(f => f.Name, StringComparer.Ordinal).ToList();
                foreach (var f in files.Skip(Math.Max(0, keep)))
                    try { f.Delete(); removed++; } catch (Exception) { }
            }
            catch (Exception) { }
            return removed;
        }

        /// <summary>Writes a report (atomically) and prunes old ones, keeping the newest <paramref name="keep"/>. Returns the path, or null on failure.</summary>
        public static string WriteCrashReport(string dir, string text, DateTime nowUtc, int keep = 10)
        {
            try
            {
                var path = Path.Combine(dir, CrashReport.FileName(nowUtc));
                AtomicFile.WriteAllText(path, text);
                Prune(dir, "crash_*.txt", keep);
                return path;
            }
            catch (Exception) { return null; }
        }
    }
}
