using System;
using System.Collections.Generic;
using System.Linq;

namespace Ascend.Core
{
    /// <summary>
    /// One save slot (systems.md §10, autosave at waystones). A plain DTO: the game serialises it to JSON in the
    /// player's save folder. Positions are flat floats so Core stays engine-free. Bump <see cref="CurrentVersion"/>
    /// when a field changes meaning, and teach <see cref="SaveRules.Upgrade"/> to read the older shape.
    /// </summary>
    public sealed class SaveGame
    {
        public const int CurrentVersion = 1;

        public int Version { get; set; } = CurrentVersion;
        public string SavedAtUtc { get; set; }
        public Difficulty Difficulty { get; set; } = Difficulty.Adventurer;
        public int Level { get; set; } = 1;
        public long XpIntoLevel { get; set; }
        public long Copper { get; set; }
        public Dictionary<string, int> Items { get; set; } = new Dictionary<string, int>();
        public int Deaths { get; set; }
        /// <summary>Respawn point (the last attuned waystone): x, y, z and facing yaw in degrees.</summary>
        public float[] Respawn { get; set; }
        public string WaystoneId { get; set; }
        /// <summary>An unrecovered coin lantern, if any: x, y, z.</summary>
        public float[] Lantern { get; set; }
        public long LanternCopper { get; set; }
        /// <summary>Fire Bombs left (the Ring 0 quick item).</summary>
        public int FireBombs { get; set; }
        /// <summary>Hardcore character that died: the slot can be viewed but not continued.</summary>
        public bool Fallen { get; set; }
        public List<QuestProgress> Quests { get; set; } = new List<QuestProgress>();
        public List<string> CompletedQuests { get; set; } = new List<string>();
        public List<string> Flags { get; set; } = new List<string>();
        public int GuildPoints { get; set; }
        /// <summary>Worn gear by slot. Null (older saves) keeps the starting kit.</summary>
        public Dictionary<string, string> Equipment { get; set; }
        /// <summary>The day clock: play seconds since the first morning (null in older saves: 08:00 day 1).</summary>
        public double? ClockSeconds { get; set; }
        public List<RestBuff> RestBuffs { get; set; } = new List<RestBuff>();
        public int TabCopper { get; set; }
        public bool TabPaidOnce { get; set; }
        public Dictionary<string, int> InnNights { get; set; } = new Dictionary<string, int>();
    }

    public static class SaveRules
    {
        /// <summary>Checks a loaded save; returns the problems (empty = fine to load).</summary>
        public static List<string> Validate(SaveGame s)
        {
            var errors = new List<string>();
            if (s == null) { errors.Add("no save data"); return errors; }
            if (s.Version < 1 || s.Version > SaveGame.CurrentVersion) errors.Add($"unknown save version {s.Version}");
            if (s.Level < 1 || s.Level > Levels.Cap) errors.Add($"level {s.Level} out of range");
            if (s.XpIntoLevel < 0) errors.Add("negative XP");
            if (s.Copper < 0 || s.LanternCopper < 0 || s.TabCopper < 0) errors.Add("negative money");
            if (s.ClockSeconds.HasValue && (s.ClockSeconds < 0 || double.IsNaN(s.ClockSeconds.Value))) errors.Add("bad clock");
            if (s.Items != null && s.Items.Any(kv => string.IsNullOrEmpty(kv.Key) || kv.Value <= 0)) errors.Add("bad item stack");
            if (s.Respawn != null && s.Respawn.Length != 4) errors.Add("respawn needs x, y, z, yaw");
            if (s.Lantern != null && s.Lantern.Length != 3) errors.Add("lantern needs x, y, z");
            if (s.Respawn != null && s.Respawn.Any(f => float.IsNaN(f) || float.IsInfinity(f))) errors.Add("respawn is not a number");
            return errors;
        }

        /// <summary>Brings an older save up to the current shape (nothing to do yet at version 1).</summary>
        public static SaveGame Upgrade(SaveGame s)
        {
            if (s == null) return null;
            s.Items ??= new Dictionary<string, int>();
            s.Quests ??= new List<QuestProgress>();
            s.CompletedQuests ??= new List<string>();
            s.Flags ??= new List<string>();
            s.RestBuffs ??= new List<RestBuff>();
            s.InnNights ??= new Dictionary<string, int>();
            s.Version = SaveGame.CurrentVersion;
            return s;
        }

        /// <summary>Copies the persistent parts of play into a save.</summary>
        public static SaveGame Capture(PlayerProgress progress, Inventory inventory, Difficulty difficulty, DateTime utcNow)
        {
            return new SaveGame
            {
                SavedAtUtc = utcNow.ToString("o", System.Globalization.CultureInfo.InvariantCulture),
                Difficulty = difficulty,
                Level = progress?.Level ?? 1,
                XpIntoLevel = progress?.XpIntoLevel ?? 0,
                Copper = inventory?.Copper ?? 0,
                Items = inventory != null ? inventory.Items.ToDictionary(kv => kv.Key, kv => kv.Value) : new Dictionary<string, int>(),
            };
        }

        /// <summary>Restores progress and inventory from a validated save.</summary>
        public static void Apply(SaveGame s, PlayerProgress progress, Inventory inventory)
        {
            progress?.Load(s.Level, s.XpIntoLevel);
            inventory?.Load(s.Copper, s.Items);
        }
    }
}
