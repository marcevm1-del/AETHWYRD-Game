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
        /// <summary>Guild board quests handed in, with the day (dailies repeat next day, specials and weeklies next week).</summary>
        public Dictionary<string, int> BoardDone { get; set; } = new Dictionary<string, int>();
        /// <summary>Tamed monsters (active and ranch).</summary>
        public List<PartnerData> Partners { get; set; } = new List<PartnerData>();
        public List<string> KnownRecipes { get; set; } = new List<string>();
        public List<string> HandledItems { get; set; } = new List<string>();
        /// <summary>Life skill XP, ranks, passed commissions and first-time crafts (null in older saves: everything at F).</summary>
        public LifeSkillSave LifeSkills { get; set; } = new LifeSkillSave();
        /// <summary>The companion travelling with you (NPC id), or null.</summary>
        public string Companion { get; set; }
        public RankLetter GuildRank { get; set; } = RankLetter.F;
        public int RankGp { get; set; }
        public int QuestsAtRank { get; set; }
        public List<BestiaryEntry> Bestiary { get; set; } = new List<BestiaryEntry>();
        /// <summary>Regrowing gathering nodes: node object name → absolute in-game hour it's ready.</summary>
        public Dictionary<string, double> GatherNodes { get; set; } = new Dictionary<string, double>();
        /// <summary>Worn gear by slot. Null (older saves) keeps the starting kit.</summary>
        public Dictionary<string, string> Equipment { get; set; }
        /// <summary>Runes and enchantments fitted to gear, by gear item key (null in older saves: none; Upgrade fills it).</summary>
        public Dictionary<string, GearFitting> GearFittings { get; set; }
        /// <summary>The home: tier, storage and crop plots (null in older saves: the base inn room; Upgrade fills it).</summary>
        public HomeSave Home { get; set; }
        /// <summary>Stable eggs, feeding times, the sanctuary collection and the chosen mount (null in older saves; Upgrade fills it).</summary>
        public StablesSave Stables { get; set; }
        /// <summary>The Civilization Archive: entries Unknown / Heard / Visited, fragments found, artifacts restored (null in older saves; Upgrade fills it).</summary>
        public ArchiveSave Archive { get; set; }
        /// <summary>The day clock: play seconds since the first morning (null in older saves: 08:00 day 1).</summary>
        public double? ClockSeconds { get; set; }
        public List<RestBuff> RestBuffs { get; set; } = new List<RestBuff>();
        public int TabCopper { get; set; }
        public bool TabPaidOnce { get; set; }
        public Dictionary<string, int> InnNights { get; set; } = new Dictionary<string, int>();
        /// <summary>Region siege state by region id (null in older saves: data initial state).</summary>
        public Dictionary<string, SiegeSave> Sieges { get; set; }
        /// <summary>The player's map: inked and pencilled regions, explored local cells (null in older saves: a fresh map).</summary>
        public MapSave Map { get; set; }
        /// <summary>Dungeon rooms and clues the player knows: Unknown / Heard / Visited (null in older saves: nothing known; Upgrade fills it).</summary>
        public DungeonSave Dungeons { get; set; }
        /// <summary>Great Labyrinth floors and stairs the player knows: Unknown / Heard / Visited (null in older saves; Upgrade fills it).</summary>
        public LabyrinthSave Labyrinth { get; set; }
        /// <summary>Living-world state: the event director's log and the discovery journal (null in older saves; Upgrade fills it).</summary>
        public LivingWorldSave LivingWorld { get; set; }
        /// <summary>Accessibility and presentation settings (null in older saves: safe defaults; Upgrade fills and clamps it).</summary>
        public AccessibilitySettings Accessibility { get; set; }
        /// <summary>Bond tracks and flags per companion (null in older saves: starting values; Upgrade fills it).</summary>
        public List<CompanionBondSave> CompanionBonds { get; set; }
        /// <summary>Chosen behaviour preset per companion: companion id to preset name (null in older saves: data defaults; Upgrade fills it).</summary>
        public Dictionary<string, string> CompanionPresets { get; set; }
    }

    public sealed class SiegeSave
    {
        public RegionState State { get; set; }
        public int Escalation { get; set; }
        public List<int> DoneDays { get; set; } = new List<int>();
        public int LastWeek { get; set; } = -1;
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
            s.BoardDone ??= new Dictionary<string, int>();
            s.Partners ??= new List<PartnerData>();
            s.KnownRecipes ??= new List<string>();
            s.HandledItems ??= new List<string>();
            s.LifeSkills ??= new LifeSkillSave();
            s.Bestiary ??= new List<BestiaryEntry>();
            s.GatherNodes ??= new Dictionary<string, double>();
            s.RestBuffs ??= new List<RestBuff>();
            s.InnNights ??= new Dictionary<string, int>();
            s.Dungeons ??= new DungeonSave();
            s.Dungeons.Dungeons ??= new Dictionary<string, DungeonProgressSave>();
            s.Labyrinth ??= new LabyrinthSave();
            s.Labyrinth.Floors ??= new Dictionary<string, MapStatus>();
            s.Labyrinth.Stairs ??= new Dictionary<string, MapStatus>();
            s.LivingWorld ??= new LivingWorldSave();
            s.LivingWorld.Events ??= new EventDirectorSave();
            s.LivingWorld.Events.LastStartDay ??= new Dictionary<string, int>();
            s.LivingWorld.Events.Active ??= new List<ActiveLivingEvent>();
            s.LivingWorld.Journal ??= new DiscoveryJournalSave();
            s.LivingWorld.Journal.Entries ??= new Dictionary<string, MapStatus>();
            s.GearFittings ??= new Dictionary<string, GearFitting>();
            s.Home ??= new HomeSave();
            s.Home.Plots ??= new List<PlotSave>();
            s.Home.Storage ??= new Dictionary<string, int>();
            s.Stables ??= new StablesSave();
            s.Stables.Eggs ??= new List<EggSave>();
            s.Stables.LastFed ??= new Dictionary<string, double>();
            s.Stables.PairReady ??= new Dictionary<string, double>();
            s.Stables.SpeciesSeen ??= new List<string>();
            s.Stables.Markings ??= new List<string>();
            s.Archive ??= new ArchiveSave();
            s.Archive.Entries ??= new Dictionary<string, MapStatus>();
            s.Archive.FoundFragments ??= new List<string>();
            s.Archive.Restored ??= new List<string>();
            s.Accessibility = (s.Accessibility ?? new AccessibilitySettings()).Sanitize();
            // Companions: drop unusable rows quietly (no id, duplicates keep the last), never reject the save.
            var bonds = new List<CompanionBondSave>();
            foreach (var b in s.CompanionBonds ?? new List<CompanionBondSave>())
            {
                if (b == null || string.IsNullOrEmpty(b.CompanionId)) continue;
                b.Seen ??= new List<string>();
                bonds.RemoveAll(x => x.CompanionId == b.CompanionId);
                bonds.Add(b);
            }
            s.CompanionBonds = bonds;
            var presets = new Dictionary<string, string>();
            foreach (var kv in s.CompanionPresets ?? new Dictionary<string, string>())
                if (!string.IsNullOrEmpty(kv.Key) && Enum.TryParse<CompanionPreset>(kv.Value, true, out var cp) && Enum.IsDefined(typeof(CompanionPreset), cp))
                    presets[kv.Key] = cp.ToString();
            s.CompanionPresets = presets;
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
