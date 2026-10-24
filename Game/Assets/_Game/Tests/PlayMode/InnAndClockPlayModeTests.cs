using System.Linq;
using Ascend.Core;
using NUnit.Framework;
using UnityEngine;

namespace Ascend.Game.Tests
{
    /// <summary>The day clock and sun, sleeping at the Sleeping Griffon (pay or tab), rest XP and saves.</summary>
    public sealed class InnAndClockPlayModeTests
    {
        GameObject _player, _clockGo, _sunGo;
        PlayerCombat _combat;
        PlayerDefense _defense;
        PlayerInventory _inv;
        PlayerQuests _quests;
        PlayerRest _rest;
        WorldClock _clock;

        [SetUp]
        public void SetUp()
        {
            _sunGo = new GameObject("Sun");
            var sun = _sunGo.AddComponent<Light>(); sun.type = LightType.Directional;
            _clockGo = new GameObject("Clock");
            _clockGo.SetActive(false);
            _clock = _clockGo.AddComponent<WorldClock>();
            _clock.Sun = sun;
            _clockGo.SetActive(true);
            _player = new GameObject("TestPlayer");
            var cc = _player.AddComponent<CharacterController>();
            cc.height = 1.8f; cc.radius = 0.35f; cc.center = new Vector3(0, 0.9f, 0);
            _player.AddComponent<PlayerMotor>();
            _combat = _player.AddComponent<PlayerCombat>();
            _defense = _player.AddComponent<PlayerDefense>();
            _inv = _player.AddComponent<PlayerInventory>();
            _player.AddComponent<PlayerRespawn>();
            _quests = _player.AddComponent<PlayerQuests>();
            _rest = _player.AddComponent<PlayerRest>();
        }

        [TearDown]
        public void TearDown()
        {
            if (NpcDialog.IsOpen) NpcDialog.Instance.Close();
            foreach (var t in new System.Type[] { typeof(QuestGiver), typeof(NpcDialog) })
                foreach (var o in Object.FindObjectsByType(t, FindObjectsSortMode.None)) Object.DestroyImmediate(((Component)o).gameObject);
            Object.DestroyImmediate(_player);
            Object.DestroyImmediate(_clockGo);
            Object.DestroyImmediate(_sunGo);
            GameTime.Clear();
        }

        static InnData Griffon => AscendData.Db.Inns["inn_sleeping_griffon"];

        [Test]
        public void TheDayStartsInTheMorningAndTheSunFollowsTheClock()
        {
            Assert.AreEqual(8.0, _clock.Hour, 1e-6, "08:00");
            Assert.AreEqual(DayPart.Morning, _clock.Part);
            StringAssert.Contains("Solenday", _clock.Text);
            float dayIntensity = _clock.Sun.intensity;
            _clock.Advance(14); // 22:00
            Assert.AreEqual(DayPart.Night, _clock.Part);
            Assert.Less(_clock.Sun.intensity, dayIntensity, "dimmer at night");
        }

        [Test]
        public void SleepingPaysHealsAndWakesAtDawnRested()
        {
            _inv.Items.AddCopper(100);
            _defense.ReceiveAttack(80, Telegraph.Red);
            Assert.Less(_defense.Hp, _defense.MaxHp);
            Assert.IsTrue(_rest.Sleep(Griffon, Griffon.Room("common")));
            Assert.AreEqual(80, _inv.Items.Copper, "20 copper");
            Assert.AreEqual(_defense.MaxHp, _defense.Hp, "fully healed");
            Assert.AreEqual(6.0, _clock.Hour, 1e-6, "dawn");
            Assert.AreEqual(1, _clock.Day, "the next day");
            Assert.AreEqual(0.05, _rest.XpBonus, 1e-9, "Rested: +5% XP");
            Assert.AreEqual(1.05, _combat.XpMultiplier(), 1e-9, "kill XP uses it");
        }

        [Test]
        public void ARookieShortOfCoinSleepsOnMartasTab()
        {
            Assert.IsTrue(_rest.Sleep(Griffon, Griffon.Room("private")), "F rank: Marta lets you");
            Assert.AreEqual(100, _rest.Tab.BalanceCopper, "a silver on the tab");
            _inv.Items.AddCopper(150);
            Assert.IsTrue(_rest.PayTab());
            Assert.AreEqual(0, _rest.Tab.BalanceCopper);
            Assert.AreEqual(50, _inv.Items.Copper);
            Assert.IsTrue(_rest.Tab.PaidOffOnce);
        }

        [Test]
        public void RoomsThroughMartasDialog()
        {
            var go = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            go.transform.position = new Vector3(0, 1, 1.5f);
            var marta = go.AddComponent<QuestGiver>(); marta.NpcId = "npc_marta_gruel";
            _inv.Items.AddCopper(60);
            NpcDialog.Instance.Open(marta, _quests);
            NpcDialog.Instance.Choose(NpcDialog.Instance.OptionTexts.ToList().FindIndex(t => t.StartsWith("Rooms")));
            int loft = NpcDialog.Instance.OptionTexts.ToList().FindIndex(t => t.Contains("Rookie Loft"));
            Assert.GreaterOrEqual(loft, 0, "the signature room is offered");
            NpcDialog.Instance.Choose(loft);
            Assert.IsFalse(NpcDialog.IsOpen, "you go to bed");
            Assert.AreEqual(0, _inv.Items.Copper, "60 copper");
            Assert.AreEqual(0.10, _rest.XpBonus, 1e-9, "Well Rested");
        }

        [Test]
        public void ClockRestAndTabAreSaved()
        {
            string dir = System.IO.Path.Combine(Application.temporaryCachePath, "ascend_inn_save");
            if (System.IO.Directory.Exists(dir)) System.IO.Directory.Delete(dir, true);
            PlayerSave.Folder = dir;
            try
            {
                var save = _player.AddComponent<PlayerSave>();
                _rest.Sleep(Griffon, Griffon.Room("common")); // on the tab; sleeping sets the respawn point, which autosaves
                Assert.GreaterOrEqual(save.Saves, 1, "autosaved after sleeping");
                double clock = _clock.PlaySeconds;
                _clock.Advance(5);
                _rest.Load(null, 0, false, null);
                Assert.IsTrue(save.Load(), save.LastError);
                Assert.AreEqual(clock, _clock.PlaySeconds, 1e-6, "clock restored");
                Assert.AreEqual(20, _rest.Tab.BalanceCopper, "tab restored");
                Assert.AreEqual(0.05, _rest.XpBonus, 1e-9, "rest buff restored");
                Assert.AreEqual(1, _rest.Nights["inn_sleeping_griffon"], "nights counted");
            }
            finally { PlayerSave.Folder = null; if (System.IO.Directory.Exists(dir)) System.IO.Directory.Delete(dir, true); }
        }
    }
}
