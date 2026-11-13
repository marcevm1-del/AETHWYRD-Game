using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Ascend.Core
{
    /// <summary>One save upgrade: reads a save at version <see cref="From"/> and leaves it in the shape of <see cref="To"/>.</summary>
    public sealed class SaveMigrationStep
    {
        public int From { get; }
        public int To { get; }
        public string Name { get; }
        public Action<SaveGame> Apply { get; }

        public SaveMigrationStep(int from, int to, string name, Action<SaveGame> apply)
        {
            From = from; To = to; Name = name ?? "";
            Apply = apply ?? throw new ArgumentNullException(nameof(apply));
        }
    }

    /// <summary>What a migration did, so the game can log it and tell the player.</summary>
    public sealed class SaveMigrationResult
    {
        public int FromVersion { get; set; }
        public int ToVersion { get; set; }
        public List<string> Applied { get; } = new List<string>();
        /// <summary>True when the save was written by a newer build: it is left untouched and must not be overwritten.</summary>
        public bool TooNew { get; set; }
        /// <summary>Set when a step threw or the chain had a gap; the save is left at the last good version.</summary>
        public string Error { get; set; }
        public bool Changed => Applied.Count > 0;
        public bool Ok => !TooNew && Error == null;
    }

    /// <summary>
    /// Save version manager. Steps form a chain (1 to 2, 2 to 3, ...); a save is walked up the chain one step at a time, never skipped.
    /// Rules: a future version is never touched (an old build must not eat a newer save); a missing link or a throwing step stops
    /// the walk, leaves the version at the last good step and reports the error so the game can keep the backup and refuse to load.
    /// Add a step here (see <see cref="Default"/>) in the same change that bumps <see cref="SaveGame.CurrentVersion"/>.
    /// </summary>
    public sealed class SaveMigrator
    {
        private readonly Dictionary<int, SaveMigrationStep> _byFrom = new Dictionary<int, SaveMigrationStep>();
        public int CurrentVersion { get; }
        public IReadOnlyCollection<SaveMigrationStep> Steps => _byFrom.Values.OrderBy(s => s.From).ToList();

        public SaveMigrator(int currentVersion, IEnumerable<SaveMigrationStep> steps)
        {
            CurrentVersion = currentVersion;
            foreach (var s in steps ?? Enumerable.Empty<SaveMigrationStep>())
            {
                if (s.To != s.From + 1) throw new ArgumentException($"step '{s.Name}' must go up by exactly one version ({s.From} to {s.To})");
                if (s.To > currentVersion) throw new ArgumentException($"step '{s.Name}' targets {s.To}, past the current version {currentVersion}");
                if (_byFrom.ContainsKey(s.From)) throw new ArgumentException($"two steps start at version {s.From}");
                _byFrom[s.From] = s;
            }
        }

        /// <summary>The game's real chain. Version 1 is the first shipped shape, so there is nothing to migrate yet.</summary>
        public static SaveMigrator Default { get; } = new SaveMigrator(SaveGame.CurrentVersion, new SaveMigrationStep[0]);

        /// <summary>Every version from 1 to current-1 must have a step. Returns the versions that do not (empty = chain is complete).</summary>
        public List<int> MissingLinks()
        {
            var missing = new List<int>();
            for (int v = 1; v < CurrentVersion; v++) if (!_byFrom.ContainsKey(v)) missing.Add(v);
            return missing;
        }

        /// <summary>Walks the save up to the current version. Does not null-fill; <see cref="SaveRules.Upgrade"/> does that first.</summary>
        public SaveMigrationResult Migrate(SaveGame s)
        {
            var r = new SaveMigrationResult();
            if (s == null) { r.Error = "no save data"; return r; }
            r.FromVersion = s.Version; r.ToVersion = s.Version;
            if (s.Version > CurrentVersion) { r.TooNew = true; return r; }
            if (s.Version < 1) { r.Error = $"invalid save version {s.Version}"; return r; }
            while (s.Version < CurrentVersion)
            {
                if (!_byFrom.TryGetValue(s.Version, out var step)) { r.Error = $"no migration from version {s.Version}"; return r; }
                try { step.Apply(s); }
                catch (Exception e) { r.Error = $"migration '{step.Name}' failed: {e.Message}"; return r; }
                s.Version = step.To;
                r.ToVersion = step.To;
                r.Applied.Add(step.Name);
            }
            return r;
        }

        private static readonly Regex VersionField = new Regex("\"Version\"\s*:\s*(-?\d+)", RegexOptions.CultureInvariant);

        /// <summary>Reads the version out of raw save JSON without deserialising (so the game can decide to back up before parsing). Null if absent.</summary>
        public static int? PeekVersion(string json)
        {
            if (string.IsNullOrEmpty(json)) return null;
            var m = VersionField.Match(json);
            return m.Success && int.TryParse(m.Groups[1].Value, out var v) ? v : (int?)null;
        }

        /// <summary>File name for the pre-migration backup, e.g. <c>slot0.v1.bak.json</c>. Slot names are reduced to safe characters.</summary>
        public static string BackupName(string slotName, int fromVersion)
        {
            var safe = new string((slotName ?? "slot").Where(c => char.IsLetterOrDigit(c) || c == '_' || c == '-').ToArray());
            if (safe.Length == 0) safe = "slot";
            return $"{safe}.v{fromVersion}.bak.json";
        }
    }
}
