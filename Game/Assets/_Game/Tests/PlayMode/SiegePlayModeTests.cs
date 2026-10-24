using System.Collections;
using System.Linq;
using Ascend.Core;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Ascend.Game.Tests
{
    /// <summary>Whisperwood raids: live waves that march on the gate, repelling them, and auto-resolving missed raids.</summary>
    public sealed class SiegePlayModeTests
    {
        GameObject _ground, _player, _clockGo, _siegeGo;
        PlayerQuests _quests;
        WorldClock _clock;
        SiegeDirector _siege;

        [SetUp]
        public void SetUp()
        {
            Time.captureDeltaTime = 1f / 60f;
            AggroDirector.Reset();
            _ground = GameObject.CreatePrimitive(PrimitiveType.Cube);
            _ground.transform.localScale = new Vector3(400, 1, 400);
            _ground.transform.position = new Vector3(0, -0.5f, 0);
            _clockGo = new GameObject("Clock");
            _clock = _clockGo.AddComponent<WorldClock>();
            _player = new GameObject("TestPlayer");
            var cc = _player.AddComponent<CharacterController>();
            cc.height = 1.8f; cc.radius = 0.35f; cc.center = new Vector3(0, 0.9f, 0);
            _player.transform.position = new Vector3(0, 0, 15);
            _player.AddComponent<PlayerMotor>();
            _player.AddComponent<PlayerCombat>();
            var def = _player.AddComponent<PlayerDefense>();
            _player.AddComponent<PlayerInventory>();
            _player.AddComponent<PlayerRespawn>();
            _quests = _player.AddComponent<PlayerQuests>();
            _siegeGo = new GameObject("Siege");
            _siegeGo.SetActive(false);
            _siege = _siegeGo.AddComponent<SiegeDirector>();
            _siege.Gate = new Vector3(0, 0, 21);
            _siege.Muster = new Vector3(0, 0, 30);
            _siegeGo.SetActive(true);
            Physics.SyncTransforms();
        }

        [TearDown]
        public void TearDown()
        {
            Time.captureDeltaTime = 0f;
            GameTime.Clear();
            CameraShake.Reset();
            foreach (var t in new System.Type[] { typeof(MonsterDummy), typeof(DamageNumber) })
                foreach (var o in Object.FindObjectsByType(t, FindObjectsSortMode.None)) Object.DestroyImmediate(((Component)o).gameObject);
            foreach (var go in Object.FindObjectsByType<Transform>(FindObjectsSortMode.None).Where(x => x != null && x.name.StartsWith("Raider_")).Select(x => x.gameObject).ToList())
                Object.DestroyImmediate(go);
            Object.DestroyImmediate(_siegeGo);
            Object.DestroyImmediate(_player);
            Object.DestroyImmediate(_clockGo);
            Object.DestroyImmediate(_ground);
            AggroDirector.Reset();
        }

        void KillAll()
        {
            foreach (var m in _siege.Raiders.ToList()) if (m != null && !m.IsDead) m.TakeHit(999999, HitWeight.Heavy, m.transform.position + Vector3.forward, 0);
        }

        [UnityTest]
        public IEnumerator ARaidMarchesOnTheGate()
        {
            _siege.StartRaidNow();
            Assert.IsNotNull(_siege.Battle, "a raid is on");
            Assert.AreEqual(6, _siege.Raiders.Count, "wave 1: 4 goblins + 2 archers");
            float z0 = _siege.Raiders.Average(m => m.transform.position.z);
            for (int i = 0; i < 60; i++) yield return null;
            Assert.Less(_siege.Raiders.Average(m => m.transform.position.z), z0 - 0.5f, "they advance toward the gate");
            StringAssert.Contains("wave 1/3", _siege.StatusText());
        }

        [UnityTest]
        public IEnumerator ClearingEveryWaveRepelsTheRaidAndCountsForTheContract()
        {
            Assert.IsTrue(_quests.Accept(AscendData.Db.Quests["qst_siege_whisperwood_defence"]), "Captain Holt's contract");
            _siege.StartRaidNow();
            int frames = 0;
            while (_siege.Battle != null && frames++ < 1500) { KillAll(); yield return null; }
            Assert.IsNull(_siege.Battle, "the raid is over");
            Assert.AreEqual(1, _quests.Log.Get("qst_siege_whisperwood_defence").Counts[0], "one defence counted");
            Assert.AreEqual(0, Object.FindObjectsByType<MonsterDummy>(FindObjectsSortMode.None).Count(m => !m.IsDead), "no raider got back up");
        }

        [UnityTest]
        public IEnumerator ARaidYouMissAutoResolves()
        {
            var cc = _player.GetComponent<CharacterController>();
            cc.enabled = false; _player.transform.position = new Vector3(0, 0, -150); cc.enabled = true;
            var next = _siege.NextAttack();
            Assert.IsNotNull(next, "Whisperwood is besieged: a raid is scheduled");
            double hours = (next.Day - _clock.Day) * 24 + next.Hour - _clock.Hour + 0.1;
            _clock.Advance(hours);
            yield return null; yield return null;
            Assert.IsNull(_siege.Battle, "not fought live");
            Assert.IsTrue(_siege.DoneDays.Contains(next.Day), "but resolved");
        }
    }
}
