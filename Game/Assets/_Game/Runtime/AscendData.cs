using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Ascend.Core;
using Newtonsoft.Json;
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
                Read<BossFile>("Monsters/boss_phases.json"));
        }

        public static void Reload() => _db = null;
    }
}
