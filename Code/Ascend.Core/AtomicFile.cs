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

        /// <summary>
        /// Reads the first candidate that <paramref name="accept"/> takes: main, then <c>.bak</c>, then a leftover <c>.tmp</c>
        /// (a crash after the temp file was written but before the swap). <paramref name="source"/> is "main", "backup", "temp" or null.
        /// </summary>
        public static string ReadWithRecovery(string path, Func<string, bool> accept, out string source, bool includeTemp = true)
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
                    if (accept == null || accept(text)) { source = name; return text; }
                }
                catch (Exception) { }
            }
            return null;
        }

        /// <summary>True when the main file, its backup or a leftover temp file exists.</summary>
        public static bool AnyExists(string path) => File.Exists(path) || File.Exists(BackupPath(path)) || File.Exists(TempPath(path));
    }
}
