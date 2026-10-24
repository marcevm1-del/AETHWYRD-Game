using System.Collections;
using System.Linq;
using Ascend.Core;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Ascend.Game.Tests
{
    /// <summary>Kill rewards (coins and loot), death (death screen, penalty, coin lantern) and waystone respawns.</summary>
    public sealed class DeathAndLootPlayModeTests
    {
        GameObject _ground, _player;
        PlayerMotor _motor;
        PlayerCombat _combat;
        PlayerDefense _defense;
        PlayerInventory _inv;
        PlayerRespawn _respawn;

        [SetUp]
        public void SetUp()
        {
            Time.captureDeltaTime = 1f / 60f;
            AggroDirector.Reset();
            _ground = GameObject.CreatePrimitive(PrimitiveType.Cube);
            _ground.transform.localScale = new Vector3(200, 1, 200);
            _ground.transform.position = new Vector3(0, -0.5f, 0);
            _player = new GameObject("TestPlayer");
            var cc = _player.AddComponent<CharacterController>();
            cc.height = 1.8f; cc.radius = 0.35f; cc.center = new Vector3(0, 0.9f, 0);
            _motor = _player.AddComponent<PlayerMotor>();
            _combat = _player.AddComponent<PlayerCombat>();
            _defense = _player.AddComponent<PlayerDefense>();
            _inv = _player.AddComponent<PlayerInventory>();
            _respawn = _player.AddComponent<PlayerRespawn>();
            Physics.SyncTransforms();
            for (int i = 0; i < 10; i++) _motor.Tick(Vector3.zero, false, false, 1f / 60f);
        }

        [TearDown]
        public void TearDown()
        {
            Time.captureDeltaTime = 0f;
            GameTime.Clear();
            CameraShake.Reset();
            foreach (var t in new System.Type[] { typeof(MonsterDummy), typeof(DamageNumber), typeof(ReactionPopup), typeof(CoinLantern), typeof(Waystone) })
                foreach (var o in Object.FindObjectsByType(t, FindObjectsSortMode.None)) Object.DestroyImmediate(((Component)o).gameObject);
            Object.DestroyImmediate(_player);
            Object.DestroyImmediate(_ground);
            AggroDirector.Reset();
        }

        MonsterDummy Goblin(Vector3 pos)
        {
            var go = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            go.transform.position = pos + Vector3.up;
            go.SetActive(false);
            go.AddComponent<MonsterDummy>().SpeciesId = "mon_goblin";
            go.SetActive(true);
            Physics.SyncTransforms();
            return go.GetComponent<MonsterDummy>();
        }

        void Kill() => _defense.ReceiveAttack(100000, Telegraph.Red, Goblin(new Vector3(0, 0, 4f)));

        [UnityTest]
        public IEnumerator KillingAGoblinPaysCoinsAndToasts()
        {
            var g = Goblin(new Vector3(0, 0, 1.3f));
            for (int f = 0; f < 180 && !g.IsDead; f++)
            {
                if (f % 6 == 0) _combat.Attack();
                _combat.Tick(1f / 60f);
                _motor.Tick(Vector3.zero, false, false, 1f / 60f);
                Physics.SyncTransforms();
                GameTime.Clear();
                yield return null;
            }
            Assert.IsTrue(g.IsDead, "the goblin is defeated");
            Assert.AreEqual(AscendData.Db.Species["mon_goblin"].Gold, _inv.Items.Copper, "its coins are in the purse");
            Assert.IsTrue(_inv.Toasts.Any(t => t.Contains("copper")), "and a pickup toast says so");
        }

        [Test]
        public void DeathNamesTheKillerAndShowsItsTip()
        {
            Kill();
            Assert.IsTrue(_defense.IsDead && _respawn.IsDead);
            Assert.AreEqual(AscendData.Db.Species["mon_goblin"].Name, _respawn.KilledBy);
            StringAssert.Contains("Weak to Fire", _respawn.Tip, "the goblin's own field note is the tip");
        }

        [Test]
        public void AdventurerDeathDropsTenPercentInALantern()
        {
            _inv.Items.AddCopper(1000);
            Kill();
            Assert.AreEqual(100, _respawn.LastPenalty.DroppedCopper);
            Assert.AreEqual(900, _inv.Items.Copper);
            Assert.IsNotNull(_respawn.Lantern, "the dropped money waits in a lantern");
            Assert.AreEqual(100, _respawn.Lantern.Copper);
        }

        [UnityTest]
        public IEnumerator OnlyTheNewestLanternStays()
        {
            _inv.Items.AddCopper(1000);
            Kill(); _respawn.Respawn();
            var first = _respawn.Lantern;
            var cc = _player.GetComponent<CharacterController>();
            cc.enabled = false; _player.transform.position = new Vector3(15, 0, 15); cc.enabled = true; // die somewhere else
            Kill();
            yield return null;
            Assert.IsTrue(first == null, "the older lantern is gone");
            Assert.IsTrue(_respawn.Lantern != null, "the new one waits at the new death spot");
            Assert.AreEqual(90, _respawn.Lantern.Copper, "10% of what was left");
        }

        [Test]
        public void StoryModeLosesNothing()
        {
            _inv.Difficulty = Difficulty.Story;
            _inv.Items.AddCopper(1000);
            Kill();
            Assert.AreEqual(1000, _inv.Items.Copper);
            Assert.IsNull(_respawn.Lantern);
        }

        [Test]
        public void ADeadPlayerTakesNoFurtherHits()
        {
            int deaths = 0;
            _defense.Died += _ => deaths++;
            Kill();
            _defense.ReceiveAttack(100000, Telegraph.Red);
            Assert.AreEqual(1, deaths, "dying happens once");
        }

        [UnityTest]
        public IEnumerator RespawnsAtTheAttunedWaystoneWithFullHp()
        {
            var stone = new GameObject("Waystone");
            stone.transform.position = new Vector3(1f, 0, 1f);
            var w = stone.AddComponent<Waystone>();
            yield return null; // the player is close enough to attune it
            Assert.IsTrue(w.Attuned);

            _player.GetComponent<CharacterController>().enabled = false;
            _player.transform.position = new Vector3(30, 0, 30);
            _player.GetComponent<CharacterController>().enabled = true;
            Kill();
            float t = 0f;
            while (_respawn.IsDead && t < PlayerRespawn.DeathScreenSec + 1f) { t += Time.unscaledDeltaTime; yield return null; }
            Assert.IsFalse(_respawn.IsDead, "the death screen ends on its own");
            Assert.AreEqual(_defense.MaxHp, _defense.Hp, "back at full health");
            Assert.Less(Vector3.Distance(_player.transform.position, stone.transform.position), 3f, "beside the waystone");
        }

        [Test]
        public void SaveAndLoadRoundTripsThePlayer()
        {
            string dir = System.IO.Path.Combine(Application.temporaryCachePath, "ascend_save_test");
            if (System.IO.Directory.Exists(dir)) System.IO.Directory.Delete(dir, true);
            PlayerSave.Folder = dir;
            try
            {
                var save = _player.AddComponent<PlayerSave>();
                while (_combat.Progress.Level < 3) _combat.GrantXp(_combat.Progress.ToNext - _combat.Progress.XpIntoLevel);
                _combat.GrantXp(50);
                _inv.Items.AddCopper(777); _inv.Items.Add("itm_core_f", 2);
                _inv.Difficulty = Difficulty.Veteran;
                _respawn.SetPoint(new Vector3(4, 0, 5), Quaternion.Euler(0, 90, 0), "Waystone_Test"); // attuning autosaves
                Assert.AreEqual(1, save.Saves, "attuning a waystone autosaved");
                Assert.IsTrue(System.IO.File.Exists(save.PathOnDisk));
                StringAssert.Contains("\"Difficulty\": \"Veteran\"", System.IO.File.ReadAllText(save.PathOnDisk), "enums are written by name");

                long xp = _combat.Progress.XpIntoLevel; int lvl = _combat.Progress.Level;
                _inv.Items.Load(0, null); _inv.Difficulty = Difficulty.Story;
                _combat.Progress.Load(1, 0); _combat.SetLevel(1);             // a fresh session starts at level 1…
                _defense.ReceiveAttack(40, Telegraph.Red);                     // …and hurt
                Assert.IsTrue(save.Load(), save.LastError);
                Assert.AreEqual(777, _inv.Items.Copper);
                Assert.AreEqual(2, _inv.Items.Count("itm_core_f"));
                Assert.AreEqual(Difficulty.Veteran, _inv.Difficulty);
                Assert.AreEqual(lvl, _combat.Progress.Level); Assert.AreEqual(xp, _combat.Progress.XpIntoLevel);
                Assert.AreEqual("Waystone_Test", _respawn.WaystoneId);
                Assert.AreEqual(lvl, _combat.Level, "the combat level (stats) follows the loaded level");
                Assert.AreEqual(_defense.MaxHp, _defense.Hp, "a loaded game starts at full health");
                Assert.Less(Vector3.Distance(_player.transform.position, new Vector3(4, 0, 5)), 0.01f, "you continue at the waystone");
            }
            finally { PlayerSave.Folder = null; if (System.IO.Directory.Exists(dir)) System.IO.Directory.Delete(dir, true); }
        }

        [Test]
        public void ACorruptSaveIsKeptAndNotLoaded()
        {
            string dir = System.IO.Path.Combine(Application.temporaryCachePath, "ascend_save_bad");
            System.IO.Directory.CreateDirectory(dir);
            PlayerSave.Folder = dir;
            try
            {
                var save = _player.AddComponent<PlayerSave>();
                System.IO.File.WriteAllText(save.PathOnDisk, "{ \"Version\": 1, \"Level\": -3 }");
                _inv.Items.AddCopper(5);
                LogAssert.Expect(LogType.Warning, new System.Text.RegularExpressions.Regex("not loaded"));
                Assert.IsFalse(save.Load());
                Assert.AreEqual(5, _inv.Items.Copper, "the current game is untouched");
                Assert.IsTrue(System.IO.File.Exists(save.PathOnDisk + ".bad"), "the bad file is kept");
            }
            finally { PlayerSave.Folder = null; System.IO.Directory.Delete(dir, true); }
        }

        [UnityTest]
        public IEnumerator WalkingOverTheLanternRecoversTheMoney()
        {
            _inv.Items.AddCopper(1000);
            Kill(); _respawn.Respawn(); // respawn point is where we stand, so the lantern is underfoot
            yield return null;
            Assert.AreEqual(1000, _inv.Items.Copper, "all of it is back");
            yield return null; // Destroy lands at the end of the frame
            Assert.IsTrue(_respawn.Lantern == null, "the lantern is used up");
        }
    }
}
