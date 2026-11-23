using System;
using System.IO;

namespace Ascend.Core
{
    /// <summary>
    /// Crash-safe file writes. Temp file, then replace with the previous file kept as <c>path.bak</c>, so there is never a moment with no file.
    /// Reads fall back to the backup when the main file is missing or rejected, and (via <see cref="ReadWithRecovery"/>) to a leftover temp file.
    /// Used for saves, settings and anything else that must survive a crash.
    /// Public surface (namespace, class name, BackupPath, WriteAllText, ReadWithFallback) matches the AtomicFile that
    /// agent/save-platform-engineer/crash-log-capture carries inline in GameSettings.cs, so that branch's callers compile unchanged.
    /// </summary>
    public static class AtomicFile
    {
        public static string BackupPath(string path) => path + ".bak";
        public static string TempPath(string path) => path + ".tmp";

        public static void WriteAllText(string path, string text)
        {
            if (string.IsNullOrEmpty(path)) throw new ArgumentException("path");
            var dir = Path.GetDirectoryName(path);
            if (!string.IsNullOrEmpty(dir)) Directory.CreateDirectory(dir);
            var tmp = TempPath(path);
            using (var fs = new FileStream(tmp, FileMode.Create, FileAccess.Write, FileShare.None))
            using (var w = new StreamWriter(fs, new System.Text.UTF8Encoding(false)))
            {
                w.Write(text ?? "");
                w.Flush();
                fs.Flush(true); // reach the disk before the swap, so the swap never exposes an empty file
            }
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
            var text = ReadWithRecovery(path, accept, out var source, false);
            usedBackup = source == "backup";
            return text;
        }

        /// <summary>What a reader says about one candidate file: take it, skip it and try the next, or end the search with no result.</summary>
        public enum Verdict { Accept, Reject, Stop }

        /// <summary>
        /// Reads the first candidate that <paramref name="accept"/> takes: main, then <c>.bak</c>, then a leftover <c>.tmp</c>
        /// (a crash after the temp file was written but before the swap). <paramref name="source"/> is "main", "backup", "temp" or null.
        /// </summary>
        public static string ReadWithRecovery(string path, Func<string, bool> accept, out string source, bool includeTemp = true)
            => ReadWithRecovery(path, t => accept == null || accept(t) ? Verdict.Accept : Verdict.Reject, out source, includeTemp);

        /// <summary>As above, but the reader can return <see cref="Verdict.Stop"/> to end the search (a valid but fallen hardcore main must not fall through to an older living backup).</summary>
        public static string ReadWithRecovery(string path, Func<string, Verdict> judge, out string source, bool includeTemp = true)
        {
            source = null;
            var candidates = includeTemp
                ? new[] { (path, "main"), (BackupPath(path), "backup"), (TempPath(path), "temp") }
                : new[] { (path, "main"), (BackupPath(path), "backup") };
            foreach (var (p, name) in candidates)
            {
                try
                {
                    if (!File.Exists(p)) continue;
                    var text = File.ReadAllText(p);
                    var v = judge(text);
                    if (v == Verdict.Accept) { source = name; return text; }
                    if (v == Verdict.Stop) return null;
                }
                catch (Exception) { }
            }
            return null;
        }

        /// <summary>
        /// After a good copy was recovered from .bak or .tmp: keeps the rejected main file as <c>path.bad</c>, and removes it from the main slot
        /// only once the .bad copy exists with the same length. The next write then takes the plain move path, so the good .bak is not
        /// replaced by the corrupt file. Deletes nothing if the copy failed. Returns whether the main slot was cleared.
        /// </summary>
        public static bool QuarantineMain(string path)
        {
            try
            {
                if (!File.Exists(path)) return false;
                var bad = path + ".bad";
                File.Copy(path, bad, true);
                if (!File.Exists(bad) || new FileInfo(bad).Length != new FileInfo(path).Length) return false;
                File.Delete(path);
                return true;
            }
            catch (Exception) { return false; }
        }

        /// <summary>True when the main file, its backup or a leftover temp file exists.</summary>
        public static bool AnyExists(string path) => File.Exists(path) || File.Exists(BackupPath(path)) || File.Exists(TempPath(path));
    }
}
