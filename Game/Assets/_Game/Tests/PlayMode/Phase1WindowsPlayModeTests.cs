using System.Linq;
using Ascend.Core;
using NUnit.Framework;
using UnityEngine;

namespace Ascend.Game.Tests
{
    /// <summary>The Phase 1 windows (crafting, companions, journal, accessibility, photo mode, playtest overlay): text, actions, toggling and routing.</summary>
    public sealed class Phase1WindowsPlayModeTests
    {
        GameObject _player, _camGo;
        PlayerInventory _inv;
        PlayerCrafting _craft;
        PlayerWorldState _world;

        [SetUp]
        public void SetUp()
        {
            _player = new GameObject("TestPlayer");
            var cc = _player.AddComponent<CharacterController>();
            cc.height = 1.8f; cc.radius = 0.35f; cc.center = new Vector3(0, 0.9f, 0);
            _player.AddComponent<PlayerMotor>();
            _player.AddComponent<PlayerCombat>();
            _inv = _player.AddComponent<PlayerInventory>();
            _craft = _player.AddComponent<PlayerCrafting>();
            _world = PlayerWorldState.Ensure(_player);
            _camGo = new GameObject("TestCamera");
            _camGo.AddComponent<Camera>().fieldOfView = 60f;
            _camGo.tag = "MainCamera";
        }

        [TearDown]
        public void TearDown()
        {
            if (PhotoModeController.IsOpen) PhotoModeController.Instance.Close();
            SystemWindow.CloseAll();
            foreach (var w in Object.FindObjectsByType<SystemWindow>(FindObjectsSortMode.None)) Object.DestroyImmediate(w.gameObject);
            foreach (var w in Object.FindObjectsByType<PhotoModeController>(FindObjectsSortMode.None)) Object.DestroyImmediate(w.gameObject);
            foreach (var w in Object.FindObjectsByType<PlaytestOverlay>(FindObjectsSortMode.None)) Object.DestroyImmediate(w.gameObject);
            Object.DestroyImmediate(_camGo);
            Object.DestroyImmediate(_player);
        }

        static int RowStarting(SystemWindow w, string prefix) => w.Rows.ToList().FindIndex(r => r.Text != null && r.Text.StartsWith(prefix));

        // ------------------------------------------------------------------ crafting

        [Test]
        public void CraftingWindowListsRecipesLadderAndCrafts()
        {
            var recipe = _craft.Crafter.All.FirstOrDefault(r => r.LifeRank == "F" && _craft.Crafter.StationAvailable(r.Station, null));
            Assert.IsNotNull(recipe, "there is an anywhere-station rank F recipe to try");
            _craft.Crafter.Known.Add(recipe.Id);
            foreach (var i in recipe.Inputs) _inv.Items.Add(i.ItemId, i.Count);

            var w = CraftingWindow.Instance;
            w.Open(_player);
            Assert.IsTrue(CraftingWindow.IsOpen);
            Assert.IsTrue(UiModal.Any, "the player stands still while a window is open");
            var lines = w.Lines();
            Assert.IsTrue(lines.Any(l => l.StartsWith("RECIPES")), "recipes header");
            Assert.IsTrue(lines.Any(l => l.StartsWith("LIFE SKILLS")), "life skill header");
            Assert.IsTrue(lines.Any(l => l.Contains("needs:")), "ingredient line (owned/needed)");
            Assert.IsTrue(lines.Any(l => l.Contains("expected quality:")), "expected quality line");
            Assert.IsTrue(lines.Any(l => l.Contains("F") && l.Contains("[F]")), "the rank ladder marks the current rank");
            Assert.IsNotEmpty(CraftingWindow.ExpectedQuality(_craft, recipe, false));

            int row = RowStarting(w, recipe.Name + "  ");
            Assert.GreaterOrEqual(row, 0, "the recipe has a row");
            Assert.IsTrue(w.Rows[row].Selectable);
            long xpBefore = _craft.Skills.Xp(recipe.Skill);
            Assert.IsTrue(w.Choose(row));
            Assert.Greater(_inv.Items.Items.Where(kv => ItemQuality.BaseId(kv.Key) == recipe.Output.ItemId).Sum(kv => kv.Value), 0, "the item was made");
            Assert.Greater(_craft.Skills.Xp(recipe.Skill), xpBefore, "crafting earned life skill XP");
            StringAssert.StartsWith("Made", w.Line);

            w.Close();
            Assert.IsFalse(CraftingWindow.IsOpen);
        }

        [Test]
        public void CraftingWindowRefusesWithoutMaterials()
        {
            var recipe = _craft.Crafter.All.First(r => r.LifeRank == "F" && _craft.Crafter.StationAvailable(r.Station, null) && r.Inputs.Count > 0);
            _craft.Crafter.Known.Add(recipe.Id);
            var w = CraftingWindow.Instance;
            w.Open(_player);
            int row = RowStarting(w, recipe.Name + "  ");
            Assert.GreaterOrEqual(row, 0);
            w.Choose(row);
            StringAssert.DoesNotStartWith("Made", w.Line);
            Assert.AreEqual(0, _inv.Items.Items.Where(kv => ItemQuality.BaseId(kv.Key) == recipe.Output.ItemId).Sum(kv => kv.Value));
        }

        // ------------------------------------------------------------------ companions

        [Test]
        public void CompanionWindowShowsPartyAndMountsAndChangesStance()
        {
            var w = CompanionWindow.Instance;
            w.Open(_player);
            var lines = w.Lines();
            Assert.IsTrue(lines.Any(l => l.StartsWith("PARTY")));
            Assert.IsTrue(lines.Any(l => l.StartsWith("COMMANDS")));
            Assert.IsTrue(lines.Any(l => l.StartsWith("MOUNTS")));
            if (AscendData.Mounts != null && AscendData.Mounts.Families.Count > 0) Assert.IsTrue(lines.Any(l => l.Contains("m/s")), "a mount line");

            int row = w.Rows.ToList().FindIndex(r => r.Adjust != null);
            if (_world.CompanionRoster.Any(c => !c.Stub) && _world.BondOf(_world.CompanionRoster.First(c => !c.Stub).Id) != null)
            {
                Assert.GreaterOrEqual(row, 0, "a companion row can be changed");
                var first = _world.CompanionRoster.First(c => !c.Stub);
                var before = _world.PresetOf(first.Id);
                Assert.IsTrue(w.Change(row, 1));
                Assert.AreNotEqual(before, _world.PresetOf(first.Id), "the stance changed");
                StringAssert.Contains("stance set to", w.Line);
            }
        }

        // ------------------------------------------------------------------ journal

        [Test]
        public void JournalShowsHeardAndFoundCluesWithoutSpoilingUnknownOnes()
        {
            var d = AscendData.Db.Dungeons.Values.FirstOrDefault(x => x.Clues.Count >= 3 && x.Clues.Select(c => c.Text).Distinct().Count() == x.Clues.Count);
            Assume.That(d, Is.Not.Null, "a dungeon with three clues");
            var know = _world.Dungeons[d.Id];
            know.HearClue(d.Clues[0].Id);
            know.VisitClue(d.Clues[1].Id);

            var w = JournalWindow.Instance;
            w.Open(_player);
            w.ShowPage(JournalWindow.Page.Clues);
            string all = string.Join("\n", w.Lines());
            StringAssert.Contains(d.Name, all);
            StringAssert.Contains("Rumour", all);
            StringAssert.Contains(d.Clues[1].Text.Substring(0, System.Math.Min(20, d.Clues[1].Text.Length)), all, "a found clue shows its text");
            StringAssert.DoesNotContain(d.Clues[2].Text.Substring(0, System.Math.Min(20, d.Clues[2].Text.Length)), all, "an unknown clue stays hidden");
        }

        [Test]
        public void JournalArchivePageShowsRumoursAndReadEntries()
        {
            var archive = _world.Archive;
            Assume.That(archive, Is.Not.Null);
            var entries = archive.Data.Entries;
            Assume.That(entries.Count, Is.GreaterThan(1));
            var w = JournalWindow.Instance;
            w.Open(_player);
            w.ShowPage(JournalWindow.Page.Archive);
            Assert.IsTrue(w.Lines().Any(l => l.StartsWith("No records yet")), "an empty archive says so");

            var heard = entries[0];
            Assert.IsTrue(archive.Hear(heard.Id));
            var readable = entries.FirstOrDefault(e => e.How == "read" && e.ReadAt != null && e.ReadAt.SiteId != null && archive.Status(e.Id) == MapStatus.Unknown);
            if (readable != null) Assert.AreEqual(ArchiveResult.Ok, archive.ReadAtSite(readable.Id, readable.ReadAt.SiteId));
            string all = string.Join("\n", w.Lines());
            StringAssert.Contains("A rumour of", all);
            if (readable != null) StringAssert.Contains(readable.Title, all);
            StringAssert.DoesNotContain(heard.Title, all, "a rumour never names the entry");
        }

        // ------------------------------------------------------------------ accessibility

        [Test]
        public void AccessibilityWindowChangesAreClampedAndApplied()
        {
            var w = AccessibilityWindow.Instance;
            w.Open(_player);
            int changed = 0;
            _world.AccessibilityChanged += () => changed++;
            var a = _world.Accessibility;

            int size = RowStarting(w, "Text size");
            Assert.GreaterOrEqual(size, 0);
            double before = a.TextScale;
            Assert.IsTrue(w.Change(size, 1));
            Assert.Greater(a.TextScale, before);
            Assert.AreEqual(1, changed, "ApplyAccessibility ran");

            a.TextScale = 99;
            a.HudScale = double.NaN;
            w.Change(RowStarting(w, "High-contrast panels"), 1);
            Assert.AreEqual(AccessibilityLimits.TextScaleMax, a.TextScale, "out-of-range text size is clamped by Sanitize");
            Assert.AreEqual(1.0, a.HudScale, "a broken value falls back to the default");
            Assert.IsTrue(a.HighContrastPanels);

            int palette = RowStarting(w, "Colourblind mode");
            w.Change(palette, 1);
            Assert.AreEqual(ColorblindPalette.Protanopia, a.ColorblindPalette);
            w.Change(palette, -1);
            Assert.AreEqual(ColorblindPalette.Off, a.ColorblindPalette);
            w.Change(palette, -1);
            Assert.AreEqual(ColorblindPalette.Tritanopia, a.ColorblindPalette, "the choices wrap");

            for (int i = 0; i < 40; i++) w.Change(RowStarting(w, "Screen shake"), 1);
            Assert.AreEqual(1.0, a.ScreenShake, 1e-9, "a slider stops at its top");
        }

        // ------------------------------------------------------------------ photo mode

        [Test]
        public void PhotoModeHidesHudAndKeepsFovInsideTheCoreLimits()
        {
            var p = PhotoModeController.Instance;
            Assert.IsTrue(p.Open(), p.Message);
            Assert.IsTrue(PhotoModeController.IsOpen);
            Assert.IsTrue(PhotoModeController.HudHidden);
            Assert.IsTrue(UiModal.Any);
            p.SetFov(500);
            Assert.AreEqual(AscendData.Photo.Tuning.FovMax, p.Fov, 1e-9);
            Assert.AreEqual((float)AscendData.Photo.Tuning.FovMax, _camGo.GetComponent<Camera>().fieldOfView, 1e-3);
            p.SetFov(-5);
            Assert.AreEqual(AscendData.Photo.Tuning.FovMin, p.Fov, 1e-9);
            p.SetHudHidden(false);
            Assert.IsFalse(PhotoModeController.HudHidden);
            StringAssert.Contains("HUD shown", string.Join("\n", p.Lines()));
            p.Close();
            Assert.IsFalse(PhotoModeController.IsOpen);
            Assert.AreEqual(60f, _camGo.GetComponent<Camera>().fieldOfView, 1e-3, "the camera is put back");
        }

        // ------------------------------------------------------------------ overlay

        [Test]
        public void PlaytestOverlayShowsTheMusicLog()
        {
            var o = PlaytestOverlay.Instance;
            bool modalBefore = UiModal.Any; // a window closed in this frame by an earlier test still counts
            o.SetVisible(true);
            Assert.IsTrue(PlaytestOverlay.IsOpen);
            var lines = o.Lines();
            Assert.AreEqual("MUSIC LOG", lines[0]);
            Assert.GreaterOrEqual(lines.Count, 2);
            Assert.LessOrEqual(lines.Count, 2 + PlaytestOverlay.MaxLogLines);
            Assert.AreEqual(modalBefore, UiModal.Any, "the overlay never takes the controls");
            o.Toggle();
            Assert.IsFalse(PlaytestOverlay.IsOpen);
        }

        // ------------------------------------------------------------------ routing

        [Test]
        public void PlaytestKeysOpenAndCloseTheWindows()
        {
            WindowHub.EnsureAll();
            PlaytestShortcuts.Request("CraftingWindow");
            Assert.IsTrue(CraftingWindow.IsOpen);
            PlaytestShortcuts.Request("CompanionWindow");
            Assert.IsTrue(CompanionWindow.IsOpen);
            Assert.IsFalse(CraftingWindow.IsOpen, "opening one window closes the other");
            PlaytestShortcuts.Request("CompanionWindow");
            Assert.IsFalse(CompanionWindow.IsOpen);
            PlaytestShortcuts.Request("JournalWindow");
            Assert.IsTrue(JournalWindow.IsOpen);
            PlaytestShortcuts.Request("AccessibilityWindow");
            Assert.IsTrue(AccessibilityWindow.IsOpen);
            PlaytestShortcuts.Request("PhotoModeController");
            Assert.IsTrue(PhotoModeController.IsOpen);
            Assert.IsFalse(AccessibilityWindow.IsOpen, "photo mode closes the windows");
            PlaytestShortcuts.Request("PhotoModeController");
            Assert.IsFalse(PhotoModeController.IsOpen);
        }
    }
}
