using System.IO;
using System.Linq;
using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;

namespace Ascend.EditorTools
{
    /// <summary>
    /// Builds the Ring 0 standalone Windows player (ring0_plan.md week 10) into Game/Builds/Ring0/.
    /// The data the game reads is copied into StreamingAssets/Data for the build and removed afterwards, so the
    /// repo's Data/ folder stays the single source. Batch: -executeMethod Ascend.EditorTools.BuildPlayer.BuildRing0
    /// </summary>
    public static class BuildPlayer
    {
        const string ScenePath = "Assets/_Game/Scenes/Ring0_Graybox.unity";
        const string TitleScenePath = "Assets/_Game/Scenes/Title.unity";
        static readonly string[] DataFiles =
        {
            "World/regions.json", "World/world_scale.json", "World/world_tuning.json", "World/siege_waves.json", "World/inns.json", "World/guild_ranks.json", "World/gathering.json",
            "Monsters/species.json", "Monsters/attacks.json", "Monsters/loot_tables.json", "Monsters/motion.json", "Monsters/boss_phases.json",
            "Items/items.json", "Items/materials.json", "Items/shops.json", "Items/recipes.json", "Combat/combat_tuning.json",
            "Quests/quests.json", "Quests/story_flags.json", "Quests/weekly_board.json",
            "NPCs/npcs.json", "Classes/classes.json", "Classes/progression.json",
            "Audio/accessibility.json", "Audio/music_states.json", "Audio/photo_mode.json", "Companions/companion_rules.json", "Companions/companions.json", "Companions/mounts.json", "Companions/stables.json", "Items/crafting_rules.json", "Items/crops.json", "Items/gear_rules.json", "Items/life_skills.json", "World/civilization_archive.json", "World/dungeons.json", "World/housing.json", "World/labyrinth.json", "World/living_world.json", "World/puzzles.json",
            "Characters/player_appearance.json", "UI/loading_tips.json",
        };

        [MenuItem("Assets/Ascend/Build Ring 0 Player (Windows)")]
        public static void BuildRing0Menu() => Build(false);

        public static void BuildRing0() => Build(true);

        static void Build(bool batch)
        {
            string projectRoot = Path.GetFullPath(Path.Combine(Application.dataPath, ".."));
            string repoData = Path.GetFullPath(Path.Combine(projectRoot, "..", "Data"));
            string streaming = Path.Combine(Application.dataPath, "StreamingAssets");
            string streamingData = Path.Combine(streaming, "Data");
            bool hadStreaming = Directory.Exists(streaming);
            string outDir = Path.Combine(projectRoot, "Builds", "Ring0");
            BuildReport report = null;
            try
            {
                foreach (var rel in DataFiles)
                {
                    string dst = Path.Combine(streamingData, rel);
                    Directory.CreateDirectory(Path.GetDirectoryName(dst));
                    File.Copy(Path.Combine(repoData, rel), dst, true);
                }
                AssetDatabase.Refresh();
                Directory.CreateDirectory(outDir);
                // Title first (scene 0), then the field. The title scene is built by TitleSceneBuilder.BuildBatch; without it the build is Ring 0 only.
                var scenes = File.Exists(Path.Combine(projectRoot, TitleScenePath)) ? new[] { TitleScenePath, ScenePath } : new[] { ScenePath };
                report = BuildPipeline.BuildPlayer(new BuildPlayerOptions
                {
                    scenes = scenes,
                    locationPathName = Path.Combine(outDir, "ProjectAscend.exe"),
                    target = BuildTarget.StandaloneWindows64,
                    options = BuildOptions.None,
                });
                var s = report.summary;
                Debug.Log($"[Ascend] Build {s.result}: {s.outputPath} · {s.totalSize / (1024f * 1024f):0.0} MB · {s.totalErrors} errors · {s.totalTime.TotalSeconds:0}s");
            }
            finally
            {
                // Keep the repo clean: StreamingAssets/Data only exists during the build.
                if (Directory.Exists(streamingData)) Directory.Delete(streamingData, true);
                if (File.Exists(streamingData + ".meta")) File.Delete(streamingData + ".meta");
                if (!hadStreaming && Directory.Exists(streaming) && !Directory.EnumerateFileSystemEntries(streaming).Any())
                {
                    Directory.Delete(streaming);
                    if (File.Exists(streaming + ".meta")) File.Delete(streaming + ".meta");
                }
                AssetDatabase.Refresh();
            }
            if (batch) EditorApplication.Exit(report != null && report.summary.result == BuildResult.Succeeded ? 0 : 1);
        }
    }
}
