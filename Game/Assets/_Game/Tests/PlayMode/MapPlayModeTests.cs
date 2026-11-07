using System.Collections;
using System.Linq;
using Ascend.Core;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Ascend.Game.Tests
{
    /// <summary>The map: the local area inking as you walk, the window's pages, pencilled regions, the painted world, saves.</summary>
    public sealed class MapPlayModeTests
    {
        GameObject _ground, _player;
        PlayerMap _map;

        [SetUp]
        public void SetUp()
        {
            Time.captureDeltaTime = 1f / 60f;
            _ground = GameObject.CreatePrimitive(PrimitiveType.Cube);
            _ground.transform.localScale = new Vector3(200, 1, 200);
            _ground.transform.position = new Vector3(0, -0.5f, 0);
        }

        void MakePlayer()
        {
            _player = new GameObject("TestPlayer");
            var cc = _player.AddComponent<CharacterController>();
            cc.height = 1.8f; cc.radius = 0.35f; cc.center = new Vector3(0, 0.9f, 0);
            _player.AddComponent<PlayerMotor>();
            _player.AddComponent<PlayerCombat>();
            _player.AddComponent<PlayerDefense>();
            _player.AddComponent<PlayerInventory>();
            _player.AddComponent<PlayerRespawn>();
            _player.AddComponent<PlayerQuests>();
            _map = _player.AddComponent<PlayerMap>();
        }

        [TearDown]
        public void TearDown()
        {
            Time.captureDeltaTime = 0f;
            if (WorldMapWindow.IsOpen) WorldMapWindow.Instance.Close();
            foreach (var w in Object.FindObjectsByType<WorldMapWindow>(FindObjectsSortMode.None)) Object.DestroyImmediate(w.gameObject);
            foreach (var a in Object.FindObjectsByType<LocalMapArea>(FindObjectsSortMode.None)) Object.DestroyImmediate(a.gameObject);
            if (_player != null) Object.DestroyImmediate(_player);
            Object.DestroyImmediate(_ground);
        }

        void MoveTo(Vector3 at)
        {
            var cc = _player.GetComponent<CharacterController>();
            cc.enabled = false; _player.transform.position = at; cc.enabled = true;
        }

        [UnityTest]
        public IEnumerator YourAreaInksItselfAsYouWalk()
        {
            MakePlayer();
            yield return null;
            Assert.AreEqual(MapStatus.Visited, _map.Knowledge.StatusOf("reg_whisperwood"), "you wake up in Whisperwood");
            Assert.AreEqual(MapStatus.Heard, _map.Knowledge.StatusOf("reg_aldmere"), "everyone talks about the capital");
            int start = _map.Fog.RevealedCount;
            Assert.Greater(start, 0, "the ground around you is inked from the start");
            Assert.IsFalse(_map.Fog.IsRevealedAt(40, 40), "the far field is blank");
            int v = _map.Version;
            MoveTo(new Vector3(40, 0, 40));
            yield return null; yield return null;
            Assert.IsTrue(_map.Fog.IsRevealedAt(40, 40), "walking there inks it");
            Assert.Greater(_map.Fog.RevealedCount, start);
            Assert.Greater(_map.Version, v, "the window knows to redraw");
        }

        [UnityTest]
        public IEnumerator TheMapWindowHasAnAreaAndAWorldPage()
        {
            MakePlayer();
            yield return null;
            WorldMapWindow.Instance.Toggle(_map);
            Assert.IsTrue(WorldMapWindow.IsOpen && UiModal.Any, "the map pauses play input like the other windows");
            Assert.AreEqual(WorldMapWindow.Page.Area, WorldMapWindow.Instance.Current, "it opens on your area");
            var lines = WorldMapWindow.Instance.Lines();
            StringAssert.Contains("Brindlewick", lines[0]);
            Assert.IsTrue(lines.Any(l => l.StartsWith("Explored ")), "shows how much you've explored");
            WorldMapWindow.Instance.Show(WorldMapWindow.Page.World);
            lines = WorldMapWindow.Instance.Lines();
            Assert.AreEqual("Aethwyrd", lines[0]);
            Assert.IsTrue(lines.Any(l => l.StartsWith("Lands inked: 1 ")), string.Join(" | ", lines));
            Assert.IsTrue(lines.Any(l => l.Contains("Rank E map seal")), "the System overlay waits for Rank E");
            var wood = WorldMapWindow.Instance.RegionLines("reg_whisperwood");
            Assert.IsTrue(wood.Any(l => l.StartsWith("Tyrant: ")) && wood.Any(l => l.StartsWith("Siege: ")), "a visited land shows its Tyrant and siege");
            Assert.AreEqual("Uncharted", WorldMapWindow.Instance.RegionLines("reg_nox_dominion")[0]);
            StringAssert.Contains("heard of", WorldMapWindow.Instance.RegionLines("reg_aldmere")[0]);
            WorldMapWindow.Instance.Toggle(_map);
            Assert.IsFalse(WorldMapWindow.IsOpen);
        }

        [UnityTest]
        public IEnumerator AcceptingAQuestPencilsItsRegionIn()
        {
            var tuning = AscendData.Db.World.Map;
            var heard = tuning.StartHeard.ToList();
            tuning.StartHeard.Remove("reg_aldmere");
            try
            {
                MakePlayer();
                yield return null;
                Assert.AreEqual(MapStatus.Unknown, _map.Knowledge.StatusOf("reg_aldmere"));
                Assert.IsTrue(_player.GetComponent<PlayerQuests>().Accept(AscendData.Db.Quests["qst_gld_f_rabbit_season"]));
                Assert.AreEqual(MapStatus.Heard, _map.Knowledge.StatusOf("reg_aldmere"), "the quest's land is pencilled in");
                Assert.IsTrue(_player.GetComponent<PlayerInventory>().Toasts.Any(t => t.Contains("Aldmere pencilled in")), "and a toast says so");
            }
            finally { tuning.StartHeard.Clear(); tuning.StartHeard.AddRange(heard); }
        }

        [UnityTest]
        public IEnumerator TheWorldIsPaintedAndInkedByWhatYouKnow()
        {
            int width = WorldMapArt.PaintWidth;
            WorldMapArt.Reset();
            WorldMapArt.PaintWidth = 300;
            try
            {
                MakePlayer();
                yield return null;
                float until = Time.realtimeSinceStartup + 30f;
                while (!WorldMapArt.Ready && WorldMapArt.Error == null && Time.realtimeSinceStartup < until) yield return null;
                Assert.IsTrue(WorldMapArt.Ready, WorldMapArt.Error ?? "painting timed out");
                var img = WorldMapArt.Image;
                var tex = WorldMapArt.Composite(_map.Knowledge, _map.Version);
                Assert.AreEqual(img.Width, tex.width);
                Color At(double ux, double uy) => tex.GetPixel((int)(ux * img.PixelsPerUnit), img.Height - 1 - (int)(uy * img.PixelsPerUnit));
                Color Raw(byte[] rgba, double ux, double uy) { int k = ((int)(uy * img.PixelsPerUnit) * img.Width + (int)(ux * img.PixelsPerUnit)) * 4; return new Color32(rgba[k], rgba[k + 1], rgba[k + 2], 255); }
                // Whisperwood (visited) shows the inked parchment; the Nox Dominion (unknown) is still blank paper.
                Assert.Less(Diff(At(75, 58), Raw(img.Parchment, 75, 58)), .04f, "Whisperwood is inked");
                Assert.Less(Diff(At(22, 18), Raw(img.Paper, 22, 18)), .04f, "the far north-west is blank");
                _map.Knowledge.Visit("reg_nox_dominion");
                tex = WorldMapArt.Composite(_map.Knowledge, _map.Version + 1000);
                Assert.Less(Diff(At(22, 18), Raw(img.Parchment, 22, 18)), .04f, "visiting inks it");
            }
            finally { WorldMapArt.Reset(); WorldMapArt.PaintWidth = width; }
        }

        static float Diff(Color a, Color b) => Mathf.Abs(a.r - b.r) + Mathf.Abs(a.g - b.g) + Mathf.Abs(a.b - b.b);

        [UnityTest]
        public IEnumerator TheAreaIsDrawnFromAbove()
        {
            int res = AreaMapArt.Resolution;
            AreaMapArt.Reset();
            AreaMapArt.Resolution = 128;
            try
            {
                MakePlayer();
                yield return null;
                AreaMapArt.Capture(_map.Area);
                var tex = AreaMapArt.Composite(_map.Area, _map.Fog);
                Assert.IsNotNull(tex, "a drawing of the area");
                Assert.AreEqual(128, tex.width);
                var centre = tex.GetPixel(64, 64); var corner = tex.GetPixel(2, 2);
                Assert.AreNotEqual(centre, corner, "where you stand is inked, the unexplored corner is bare paper");
                Texture2D mini = null;
                Assert.IsTrue(AreaMapArt.Minimap(_map.Area, _map.Fog, Vector3.zero, 30f, 40f, ref mini, 64), "the HUD minimap uses the drawing");
                Assert.AreEqual(0f, mini.GetPixel(0, 0).a, 0.01f, "outside the disc is clear");
                Assert.Greater(mini.GetPixel(32, 32).a, .5f, "the middle is drawn");
                Object.Destroy(mini);
            }
            finally { AreaMapArt.Reset(); AreaMapArt.Resolution = res; }
        }

        [UnityTest]
        public IEnumerator TheMapIsSavedAndLoaded()
        {
            string dir = System.IO.Path.Combine(Application.temporaryCachePath, "ascend_map_save");
            if (System.IO.Directory.Exists(dir)) System.IO.Directory.Delete(dir, true);
            PlayerSave.Folder = dir;
            try
            {
                MakePlayer();
                var save = _player.AddComponent<PlayerSave>();
                yield return null;
                MoveTo(new Vector3(-30, 0, 50));
                yield return null; yield return null;
                _map.Knowledge.Hear("reg_sylvaran");
                int cells = _map.Fog.RevealedCount;
                save.Save();
                Object.DestroyImmediate(_player);
                foreach (var a in Object.FindObjectsByType<LocalMapArea>(FindObjectsSortMode.None)) Object.DestroyImmediate(a.gameObject);
                MakePlayer();
                var again = _player.AddComponent<PlayerSave>();
                yield return null;
                Assert.IsTrue(again.Load(), again.LastError);
                Assert.AreEqual(MapStatus.Heard, _map.Knowledge.StatusOf("reg_sylvaran"), "pencilled lands come back");
                Assert.GreaterOrEqual(_map.Fog.RevealedCount, cells, "so do the explored cells");
                Assert.IsTrue(_map.Fog.IsRevealedAt(-30, 50), "including the walk north");
            }
            finally { PlayerSave.Folder = null; if (System.IO.Directory.Exists(dir)) System.IO.Directory.Delete(dir, true); }
        }
    }
}
