using System.Linq;
using Ascend.Core;
using NUnit.Framework;
using UnityEngine;

namespace Ascend.Game.Tests
{
    /// <summary>Starting kit, equipping from the bag window, stats and max HP following gear, and gear in saves.</summary>
    public sealed class EquipmentPlayModeTests
    {
        GameObject _player;
        PlayerCombat _combat;
        PlayerDefense _defense;
        PlayerInventory _inv;

        [SetUp]
        public void SetUp()
        {
            _player = new GameObject("TestPlayer");
            var cc = _player.AddComponent<CharacterController>();
            cc.height = 1.8f; cc.radius = 0.35f; cc.center = new Vector3(0, 0.9f, 0);
            _player.AddComponent<PlayerMotor>();
            _combat = _player.AddComponent<PlayerCombat>();
            _defense = _player.AddComponent<PlayerDefense>();
            _inv = _player.AddComponent<PlayerInventory>();
            _player.AddComponent<PlayerRespawn>();
        }

        [TearDown]
        public void TearDown()
        {
            if (BagWindow.IsOpen) BagWindow.Instance.Close();
            foreach (var b in Object.FindObjectsByType<BagWindow>(FindObjectsSortMode.None)) Object.DestroyImmediate(b.gameObject);
            Object.DestroyImmediate(_player);
        }

        int Option(string contains) => BagWindow.Instance.OptionTexts.ToList().FindIndex(t => t.Contains(contains));

        [Test]
        public void ANewSwordsmanStartsWithSwordAndHood()
        {
            Assert.AreEqual("itm_guild_issue_sword", _combat.Equipment.In("main_hand"));
            Assert.AreEqual("itm_rookie_hood", _combat.Equipment.In("head"));
            var bare = PlayerStats.Derive(PlayerStats.Primary(_combat.Class, 1, AscendData.Db.Progression), 1, AscendData.Db.Progression);
            Assert.AreEqual(bare.Atk + 8, _combat.Stats.Atk, "the sword's ATK is in the stats");
            Assert.AreEqual(bare.Def + 3, _combat.Stats.Def, "the hood's DEF too");
        }

        [Test]
        public void EquippingABetterBladeFromTheBag()
        {
            int atk = _combat.Stats.Atk;
            _inv.Items.Add("itm_hollis_practice_blade");
            _inv.Items.Add("itm_guild_issue_staff");
            BagWindow.Instance.Open(_combat);
            int blade = Option("Hollis");
            Assert.GreaterOrEqual(blade, 0);
            StringAssert.Contains("ATK ▲14", BagWindow.Instance.OptionTexts[blade], "shows it's better");
            StringAssert.Contains("can't wield", BagWindow.Instance.OptionTexts[Option("Staff")], "the staff is marked unusable");
            BagWindow.Instance.Choose(blade);
            Assert.AreEqual(atk + 14, _combat.Stats.Atk, "stats follow the gear");
            Assert.AreEqual(1, _inv.Items.Count("itm_guild_issue_sword"), "the old sword is in the bag");
            BagWindow.Instance.Choose(Option("Staff"));
            Assert.AreEqual("itm_hollis_practice_blade", _combat.Equipment.In("main_hand"), "a swordsman can't equip a staff");
        }

        [Test]
        public void TakingOffArmourLowersDefense()
        {
            int def = _combat.Stats.Def;
            BagWindow.Instance.Open(_combat);
            BagWindow.Instance.Choose(Option("Rookie Hood"));
            Assert.AreEqual(def - 3, _combat.Stats.Def);
            Assert.AreEqual(1, _inv.Items.Count("itm_rookie_hood"));
        }

        [Test]
        public void GearIsSaved()
        {
            string dir = System.IO.Path.Combine(Application.temporaryCachePath, "ascend_gear_save");
            if (System.IO.Directory.Exists(dir)) System.IO.Directory.Delete(dir, true);
            PlayerSave.Folder = dir;
            try
            {
                var save = _player.AddComponent<PlayerSave>();
                _inv.Items.Add("itm_hollis_practice_blade");
                _combat.Equipment.Equip("itm_hollis_practice_blade", _inv.Items, _combat.Class);
                save.Save();
                _combat.Equipment.Equip("itm_guild_issue_sword", _inv.Items, _combat.Class);
                Assert.IsTrue(save.Load(), save.LastError);
                Assert.AreEqual("itm_hollis_practice_blade", _combat.Equipment.In("main_hand"));
            }
            finally { PlayerSave.Folder = null; if (System.IO.Directory.Exists(dir)) System.IO.Directory.Delete(dir, true); }
        }
    }
}
