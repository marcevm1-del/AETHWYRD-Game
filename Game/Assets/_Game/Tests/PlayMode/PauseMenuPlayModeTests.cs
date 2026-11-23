using System.Collections;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Ascend.Game.Tests
{
    /// <summary>The pause menu stops the game, asks before leaving and always lets go of the clock.</summary>
    public sealed class PauseMenuPlayModeTests
    {
        GameObject _player;

        [SetUp]
        public void SetUp() { GameTime.Clear(); _player = new GameObject("PausePlayer"); }

        [TearDown]
        public void TearDown()
        {
            PauseMenu.Instance.Resume();
            SystemWindow.CloseAll();
            GameTime.SetPaused(false);
            GameTime.Clear();
            Object.DestroyImmediate(_player);
        }

        static int Row(string text) => PauseMenu.Instance.Rows.ToList().FindIndex(r => r.Text.StartsWith(text));

        [UnityTest]
        public IEnumerator OpeningStopsTimeAndResumeLetsItRun()
        {
            PauseMenu.Instance.Open(_player);
            Assert.IsTrue(GameTime.Paused);
            Assert.AreEqual(0f, Time.timeScale);
            Assert.AreEqual(0f, PlayerInputDriver.PlayerDelta, "the player's clock stops too");
            Assert.IsTrue(UiModal.Any, "the controls are taken");
            yield return null;
            Assert.IsTrue(PauseMenu.Instance.Choose(Row("Resume")));
            Assert.IsFalse(PauseMenu.IsOpen);
            Assert.IsFalse(GameTime.Paused);
            Assert.AreEqual(1f, Time.timeScale);
        }

        [UnityTest]
        public IEnumerator CombatEffectsCannotUnpauseAndFlashTimeIsKept()
        {
            PauseMenu.Instance.Open(_player);
            GameTime.HitStop(0.01f);
            GameTime.Clear();
            GameTime.FlashTime(0.25f, 0.5f);
            for (int i = 0; i < 5; i++) { yield return null; Assert.AreEqual(0f, Time.timeScale, "still paused"); }
            PauseMenu.Instance.Resume();
            Assert.IsTrue(GameTime.FlashTimeActive, "Flash Time resumes with its time left");
            Assert.AreEqual(0.25f, Time.timeScale, 0.001f);
        }

        [UnityTest]
        public IEnumerator LeavingAsksFirstAndEscGoesBackStillPaused()
        {
            var menu = PauseMenu.Instance;
            menu.Open(_player);
            Assert.IsTrue(menu.Choose(Row("Quit game")));
            Assert.AreEqual(PauseMenu.Page.Quit, menu.Current);
            Assert.GreaterOrEqual(Row("Cancel"), 0);
            menu.Close(); // Esc on a sub-page
            yield return null;
            yield return null;
            Assert.IsTrue(PauseMenu.IsOpen, "back on the first page");
            Assert.AreEqual(PauseMenu.Page.Main, menu.Current);
            Assert.IsTrue(GameTime.Paused);
        }

        [UnityTest]
        public IEnumerator SettingsOpensOverThePauseAndReturnsToIt()
        {
            var menu = PauseMenu.Instance;
            menu.Open(_player);
            Assert.IsTrue(menu.Choose(Row("Settings")));
            Assert.IsTrue(AccessibilityWindow.IsOpen);
            Assert.IsTrue(GameTime.Paused, "settings do not unpause");
            AccessibilityWindow.Instance.Close();
            yield return null;
            yield return null;
            Assert.IsTrue(PauseMenu.IsOpen);
            Assert.IsTrue(GameTime.Paused);
        }

        [Test]
        public void ASaveThatCannotHappenKeepsYouInTheGame()
        {
            var menu = PauseMenu.Instance;
            menu.Open(_player); // no PlayerSave on it
            menu.Choose(Row("Quit game"));
            menu.Choose(Row("Save, then"));
            Assert.IsTrue(PauseMenu.IsOpen);
            StringAssert.Contains("nothing to save", menu.Line);
        }
    }
}
