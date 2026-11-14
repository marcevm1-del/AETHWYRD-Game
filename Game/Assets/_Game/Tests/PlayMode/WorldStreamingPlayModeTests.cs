using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Ascend.Core;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.TestTools;

namespace Ascend.Game.Tests
{
    /// <summary>
    /// The open world streams as the player walks (13_Production/open_world_streaming_plan.md). Walks from the Ring 0
    /// anchor east across the tile seam at map x = 80 km, with no loading screen: the ground must be there every step.
    /// Needs the baked tiles (python Tools/world/bake_stream_tiles.py); without them the tests are inconclusive, not passed.
    /// </summary>
    public sealed class WorldStreamingPlayModeTests
    {
        readonly List<GameObject> _made = new List<GameObject>();

        [TearDown]
        public void TearDown()
        {
            foreach (var go in _made) if (go != null) UnityEngine.Object.DestroyImmediate(go);
            _made.Clear();
        }

        static string TileFolder => Path.Combine(Application.streamingAssetsPath, "World");

        void RequireTiles()
        {
            if (!File.Exists(Path.Combine(TileFolder, "manifest.json")))
                Assert.Inconclusive("baked terrain tiles are missing: run python Tools/world/bake_stream_tiles.py");
        }

        (GameObject player, WorldStreamer streamer) Spawn(Vector3 at)
        {
            var player = new GameObject("StreamTestPlayer");
            player.transform.position = at;
            _made.Add(player);
            var host = new GameObject("StreamTestWorld");
            _made.Add(host);
            var s = host.AddComponent<WorldStreamer>();
            s.Target = player.transform;
            s.TileFolder = TileFolder;
            return (player, s);
        }

        static bool GroundBelow(Vector3 p, out float y)
        {
            Physics.SyncTransforms();
            if (Physics.Raycast(p + Vector3.up * 4000f, Vector3.down, out var hit, 8000f) && hit.collider is TerrainCollider) { y = hit.point.y; return true; }
            y = float.NaN; return false;
        }

        [UnityTest]
        public IEnumerator WalkingEastAcrossASeamNeverLeavesTheWalkerWithoutGround()
        {
            RequireTiles();
            var (player, s) = Spawn(Vector3.zero);
            yield return null; // Start: the first load is blocking, so the ground exists now
            Assert.IsTrue(s.Initialised, "streamer initialised");
            Assert.GreaterOrEqual(s.ReadyCount, 2, "Ring 0 sits on a tile seam: at least two tiles are up at spawn");
            Assert.IsTrue(GroundBelow(player.transform.position, out float y0), "ground under the Ring 0 anchor at spawn");
            Assert.AreEqual(0f, y0, 0.6f, "the Ring 0 pad is the origin height (the pad is flat)");

            var regions = new HashSet<string> { s.RegionNow() };
            int missingGround = 0, maxReady = 0;
            var tilesSeen = new HashSet<string>();
            // Brindlewick is at map x 72.6 km, so the tile seam at x = 80 km is 7.4 km east. Walk 8.2 km in 25 m strides.
            for (float x = 0f; x <= 8200f; x += 25f)
            {
                player.transform.position = new Vector3(x, 0f, 0f);
                yield return null;
                if (!GroundBelow(player.transform.position, out _)) missingGround++;
                maxReady = Mathf.Max(maxReady, s.ReadyCount);
                foreach (var t in s.ReadyTiles) tilesSeen.Add(t.ToString());
                if (((int)(x / 25f)) % 40 == 0) regions.Add(s.RegionNow());
            }
            regions.Add(s.RegionNow());
            for (int i = 0; i < 20; i++) yield return null; // let the last builds finish

            WorldOrigin.ToMapKm(player.transform.position, out double mx, out _);
            Debug.Log($"[WorldStreamTest] ended at map x {mx:F2} km; seams crossed {s.SeamsCrossed}; tiles loaded {s.TilesLoadedTotal}, unloaded {s.TilesUnloadedTotal}; max resident {maxReady}; frames without ground {missingGround}; max tile build {s.MaxBuildMs:F1} ms; regions {string.Join(",", regions.Where(r => r != null))}");
            Assert.AreEqual(0, missingGround, "no step of the walk had no ground under it (no loading screen, no fall-through)");
            Assert.GreaterOrEqual(s.SeamsCrossed, 1, "the walk crossed at least one tile seam");
            Assert.IsTrue(s.IsReady(new TileIndex(8, 5)), "the tile beyond the seam is up");
            Assert.IsFalse(s.IsReady(new TileIndex(6, 5)), "the tile far behind was unloaded");
            Assert.Greater(s.TilesUnloadedTotal, 0, "tiles went out as well as in");
            Assert.LessOrEqual(maxReady, 9, "never more than the resident cap");
            Assert.GreaterOrEqual(regions.Count(r => r != null), 2, "the walk passed from one region into another");
        }

        [UnityTest]
        public IEnumerator NeighbouringTilesMeetWithoutACrack()
        {
            RequireTiles();
            var (player, s) = Spawn(new Vector3(7000f, 0f, 0f)); // 400 m west of the x = 80 km seam
            yield return null;
            var west = s.TerrainOf(new TileIndex(7, 5));
            var east = s.TerrainOf(new TileIndex(8, 5));
            Assert.IsNotNull(west, "tile (7,5) is up");
            Assert.IsNotNull(east, "tile (8,5) is up");
            float worst = 0f;
            for (float z = 100f; z < 9900f; z += 137f)
            {
                var p = new Vector3(7400f, 0f, z); // x = 80 km, the shared edge
                worst = Mathf.Max(worst, Mathf.Abs(west.SampleHeight(p) - east.SampleHeight(p)));
            }
            Debug.Log($"[WorldStreamTest] worst height difference along the x=80 km seam: {worst:F4} m");
            Assert.Less(worst, 0.2f, "heights agree along the seam (one quantisation step is 0.08 m)");
            yield return null;
        }

        [UnityTest]
        public IEnumerator FarTeleportLoadsItsGroundAtOnce()
        {
            RequireTiles();
            // 60 km south-west of the anchor: a long fast-travel jump (Core's own tiles, no scene).
            var (player, s) = Spawn(Vector3.zero);
            yield return null;
            player.transform.position = WorldOrigin.ToUnity(30.5, 85.5, 0f);
            s.LoadNow();
            Assert.IsTrue(s.HomeTile.HasValue && s.HomeTile.Value.Equals(new TileIndex(3, 8)), "home tile follows the jump");
            Assert.IsTrue(s.IsReady(new TileIndex(3, 8)), "the destination tile is up after LoadNow");
            Assert.IsFalse(s.IsReady(new TileIndex(7, 5)), "the old tiles are gone");
            Assert.LessOrEqual(s.ReadyCount, 9);
        }

        [UnityTest]
        public IEnumerator MeasureResidentCostOfANineTileWorld()
        {
            RequireTiles();
            var proc = System.Diagnostics.Process.GetCurrentProcess();
            proc.Refresh(); long wsBefore = proc.WorkingSet64, privBefore = proc.PrivateMemorySize64;
            long before = Profiler.GetTotalAllocatedMemoryLong(), gcBefore = GC.GetTotalMemory(false), gfxBefore = Profiler.GetAllocatedMemoryForGraphicsDriver();
            var (player, s) = Spawn(WorldOrigin.ToUnity(75.0, 55.0, 0f)); // the middle of tile (7,5): all 9 neighbours are wanted
            yield return null;
            for (int i = 0; i < 30; i++) yield return null;
            long after = Profiler.GetTotalAllocatedMemoryLong(), gcAfter = GC.GetTotalMemory(false);
            long gfx = Profiler.GetAllocatedMemoryForGraphicsDriver();
            proc.Refresh(); long wsAfter = proc.WorkingSet64, privAfter = proc.PrivateMemorySize64;
            string line = $"[WorldStreamMetrics] tiles ready {s.ReadyCount}; Unity allocated {(after - before) / 1048576.0:F1} MB more than before; managed heap {(gcAfter - gcBefore) / 1048576.0:F1} MB more; graphics driver {(gfx - gfxBefore) / 1048576.0:F1} MB more; process working set {(wsAfter - wsBefore) / 1048576.0:F1} MB more, private bytes {(privAfter - privBefore) / 1048576.0:F1} MB more; last tile build {s.LastBuildMs:F1} ms, worst {s.MaxBuildMs:F1} ms";
            Debug.Log(line);
            var dir = Path.GetFullPath(Path.Combine(Application.dataPath, "..", "Logs"));
            Directory.CreateDirectory(dir);
            File.WriteAllText(Path.Combine(dir, "world_stream_metrics.txt"), line + "\n");
            Assert.AreEqual(9, s.ReadyCount, "the full 3 x 3 square is up from the middle of a tile");
            Assert.Less(s.MaxBuildMs, 250.0, "one tile builds in under a quarter of a second (one-tile-per-frame budget)");
        }
    }
}
