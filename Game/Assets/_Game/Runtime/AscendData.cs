using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Ascend.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using UnityEngine;

namespace Ascend.Game
{
    /// <summary>
    /// Loads the design data (repo Data/ folder) into Ascend.Core's GameDatabase.
    /// In the editor it reads ../Data next to the Unity project; in builds it reads StreamingAssets/Data
    /// (copied at build time, Ring 0 task).
    /// </summary>
    public static class AscendData
    {
        static GameDatabase _db;
        public static GameDatabase Db => _db ??= Load();

        public static string DataRoot
        {
            get
            {
                var repoData = Path.GetFullPath(Path.Combine(Application.dataPath, "..", "..", "Data"));
                if (Directory.Exists(repoData)) return repoData;
                return Path.Combine(Application.streamingAssetsPath, "Data");
            }
        }

        static T Read<T>(string relative)
        {
            var path = Path.Combine(DataRoot, relative);
            if (!File.Exists(path)) throw new FileNotFoundException($"Ascend data file missing: {path}");
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(path)); // Newtonsoft matches property names case-insensitively
        }

        // Optional files (Phase 1 systems). Missing or unreadable -> null / empty, so an older Data folder still loads.
        static readonly JsonSerializerSettings OptSettings = new JsonSerializerSettings
        {
            Converters = { new StringEnumConverter() },
            ObjectCreationHandling = ObjectCreationHandling.Replace, // same as System.Text.Json in the Core tests: a file replaces defaults
            Culture = System.Globalization.CultureInfo.InvariantCulture,
        };

        static T ReadOpt<T>(string relative) where T : class
        {
            var path = Path.Combine(DataRoot, relative);
            if (!File.Exists(path)) return null;
            try { return JsonConvert.DeserializeObject<T>(File.ReadAllText(path), OptSettings); }
            catch (Exception e) { Debug.LogWarning($"Ascend data file {relative} not loaded: {e.Message}"); return null; }
        }

        static MusicFile _music; static AccessibilityFile _access; static LivingWorldData _living; static LabyrinthData _lab;
        static CompanionRules _compRules; static List<CompanionData> _companions; static MountTable _mounts; static PhotoFile _photo;
        static bool _musicDone, _accessDone, _livingDone, _labDone, _rulesDone, _compDone, _mountsDone, _photoDone;

        static T Once<T>(ref T field, ref bool done, string relative) where T : class
        {
            if (!done) { field = ReadOpt<T>(relative); done = true; }
            return field;
        }

        /// <summary>Data/Audio/music_states.json (adaptive music); null when missing.</summary>
        public static MusicFile Music => Once(ref _music, ref _musicDone, "Audio/music_states.json");
        /// <summary>Data/Audio/accessibility.json (defaults, palettes); null when missing.</summary>
        public static AccessibilityFile Accessibility => Once(ref _access, ref _accessDone, "Audio/accessibility.json");
        /// <summary>Data/Audio/photo_mode.json; null when missing.</summary>
        public static PhotoFile Photo => Once(ref _photo, ref _photoDone, "Audio/photo_mode.json");
        /// <summary>Data/World/living_world.json (schedules, event pool, journal categories); null when missing.</summary>
        public static LivingWorldData LivingWorld => Once(ref _living, ref _livingDone, "World/living_world.json");
        /// <summary>Data/World/labyrinth.json; null when missing.</summary>
        public static LabyrinthData LabyrinthData => Once(ref _lab, ref _labDone, "World/labyrinth.json");
        /// <summary>Data/Companions/companion_rules.json (presets, retreat, relationships); null when missing.</summary>
        public static CompanionRules CompanionRules => Once(ref _compRules, ref _rulesDone, "Companions/companion_rules.json");
        /// <summary>Data/Companions/companions.json; empty when missing.</summary>
        public static IReadOnlyList<CompanionData> Companions => Once(ref _companions, ref _compDone, "Companions/companions.json") ?? new List<CompanionData>();
        /// <summary>Data/Companions/mounts.json; null when missing.</summary>
        public static MountTable Mounts => Once(ref _mounts, ref _mountsDone, "Companions/mounts.json");

        // Monster lines, variations, guilds, contracts, factions, lairs and grade labels (Canon section 6 proposals M1 to M6). All optional.
        static MonsterLines _lines; static VariationFile _variations; static GuildFile _guildFile; static ContractFile _contractFile;
        static FactionFile _factionFile; static LairFile _lairs; static GradeFile _grades;
        static bool _linesDone, _variationsDone, _guildDone, _contractDone, _factionDone, _lairsDone, _gradesDone;

        /// <summary>Evolution lines and each species' place in them (Data/Monsters/evolution_lines.json, species_lines.json); null when missing.</summary>
        public static MonsterLines MonsterLines
        {
            get
            {
                if (!_linesDone)
                {
                    _linesDone = true;
                    var lines = ReadOpt<EvolutionLineFile>("Monsters/evolution_lines.json");
                    var assigned = ReadOpt<SpeciesLineFile>("Monsters/species_lines.json");
                    if (lines != null) { try { _lines = new MonsterLines(lines, assigned); } catch (Exception e) { Debug.LogWarning($"Ascend monster lines not loaded: {e.Message}"); } }
                }
                return _lines;
            }
        }
        /// <summary>Data/Monsters/variations.json; null when missing.</summary>
        public static VariationFile Variations => Once(ref _variations, ref _variationsDone, "Monsters/variations.json");
        /// <summary>Data/World/guilds.json; null when missing.</summary>
        public static GuildFile GuildFile => Once(ref _guildFile, ref _guildDone, "World/guilds.json");
        /// <summary>Data/Quests/guild_contracts.json; null when missing.</summary>
        public static ContractFile GuildContracts => Once(ref _contractFile, ref _contractDone, "Quests/guild_contracts.json");
        /// <summary>Data/World/faction_relations.json; null when missing.</summary>
        public static FactionFile Factions => Once(ref _factionFile, ref _factionDone, "World/faction_relations.json");
        /// <summary>Data/World/lairs_and_events.json; null when missing.</summary>
        public static LairFile Lairs => Once(ref _lairs, ref _lairsDone, "World/lairs_and_events.json");
        /// <summary>Data/Items/grade_labels.json; null when missing.</summary>
        public static GradeFile Grades => Once(ref _grades, ref _gradesDone, "Items/grade_labels.json");

        public static GameDatabase Load()
        {
            var items = Read<List<ItemData>>("Items/materials.json").Concat(Read<List<ItemData>>("Items/items.json"));
            return new GameDatabase(
                Read<List<RegionData>>("World/regions.json"),
                Read<List<SpeciesData>>("Monsters/species.json"),
                Read<List<AttackData>>("Monsters/attacks.json"),
                Read<List<LootTableData>>("Monsters/loot_tables.json"),
                items,
                Read<CombatTuning>("Combat/combat_tuning.json"),
                Read<List<SiegeWaveData>>("World/siege_waves.json"),
                Read<WorldTuning>("World/world_tuning.json"),
                Read<List<QuestData>>("Quests/quests.json"),
                Read<List<NpcData>>("NPCs/npcs.json"),
                Read<List<ClassData>>("Classes/classes.json"),
                Read<List<StoryFlagData>>("Quests/story_flags.json"),
                Read<ProgressionRules>("Classes/progression.json"),
                Read<List<WeeklyQuestData>>("Quests/weekly_board.json"),
                Read<List<InnData>>("World/inns.json"),
                Read<MotionFile>("Monsters/motion.json"),
                Read<List<ShopData>>("Items/shops.json"),
                Read<RecipeFile>("Items/recipes.json"),
                Read<GuildRankData>("World/guild_ranks.json"),
                Read<GatheringFile>("World/gathering.json"),
                Read<BossFile>("Monsters/boss_phases.json"),
                quality: ReadOpt<QualityRules>("Items/crafting_rules.json"),
                lifeSkills: ReadOpt<LifeSkillFile>("Items/life_skills.json"),
                dungeons: ReadOpt<List<DungeonData>>("World/dungeons.json"),
                puzzles: ReadOpt<PuzzleFile>("World/puzzles.json"),
                gear: ReadOpt<GearRules>("Items/gear_rules.json"),
                housing: ReadOpt<HousingFile>("World/housing.json"),
                crops: ReadOpt<CropFile>("Items/crops.json"),
                stables: ReadOpt<StablesFile>("Companions/stables.json"),
                archive: ReadOpt<ArchiveFile>("World/civilization_archive.json"));
        }

        public static void Reload()
        {
            _db = null;
            _musicDone = _accessDone = _livingDone = _labDone = _rulesDone = _compDone = _mountsDone = _photoDone = false;
            _music = null; _access = null; _living = null; _lab = null; _compRules = null; _companions = null; _mounts = null; _photo = null;
        }
    }
}
