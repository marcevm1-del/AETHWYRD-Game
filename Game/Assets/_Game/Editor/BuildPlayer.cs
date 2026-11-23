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
        // One rule instead of a hand-kept list: every Data/**/*.json is shipped except what is excluded below.
        // Tools/validate/data_manifest_check.js (part of `npm run build`) reads these two arrays and fails when a
        // Data path the runtime reads is excluded or missing, so the player cannot silently drift from the editor.
        // Excluding costs nothing to maintain only while the list stays short: give every entry a reason.
        static readonly string[] ExcludedDataDirs =
        {
            "Schemas", // JSON-schema files for the validator, never read by the game
        };
        static readonly string[] ExcludedDataFiles =
        {
            // "World/physical_map.json", // example: add a path (relative to Data/, forward slashes) with a reason here
        };

        static bool IsExcluded(string rel)
        {
            foreach (var d in ExcludedDataDirs) if (rel.StartsWith(d + "/")) return true;
            foreach (var f in ExcludedDataFiles) if (rel == f) return true;
            return false;
        }

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
                int copied = 0; long bytes = 0;
                foreach (var file in Directory.GetFiles(repoData, "*.json", SearchOption.AllDirectories))
                {
                    string rel = Path.GetRelativePath(repoData, file).Replace('\\', '/');
                    if (IsExcluded(rel)) continue;
                    string dst = Path.Combine(streamingData, rel);
                    Directory.CreateDirectory(Path.GetDirectoryName(dst));
                    File.Copy(file, dst, true);
                    copied++; bytes += new FileInfo(file).Length;
                }
                Debug.Log($"[Ascend] Data copied to StreamingAssets: {copied} files, {bytes / (1024f * 1024f):0.0} MB");
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
