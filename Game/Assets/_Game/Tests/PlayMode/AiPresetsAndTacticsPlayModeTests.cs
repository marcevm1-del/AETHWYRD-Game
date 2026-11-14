using System.Collections;
using System.Linq;
using Ascend.Core;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Ascend.Game.Tests
{
    /// <summary>
    /// Job: companion command presets and group enemy tactics in the Unity runtime (Wave A3 wiring).
    /// Written without a Unity run (another session owned the editor): run with the PlayMode suite before merging.
    /// </summary>
    public sealed class AiPresetsAndTacticsPlayModeTests
    {
        GameObject _ground, _player, _lyraGo;
        PlayerCombat _combat;
        CompanionAI _lyra;

        [SetUp]
        public void SetUp()
        {
            Time.captureDeltaTime = 1f / 60f;
            AggroDirector.Reset();
            MonsterController.ResetTactics();
            _ground = GameObject.CreatePrimitive(PrimitiveType.Cube);
            _ground.transform.localScale = new Vector3(200, 1, 200);
            _ground.transform.position = new Vector3(0, -0.5f, 0);
            _player = new GameObject("TestPlayer");
            var cc = _player.AddComponent<CharacterController>();
            cc.height = 1.8f; cc.radius = 0.35f; cc.center = new Vector3(0, 0.9f, 0);
            _player.AddComponent<PlayerMotor>();
            _combat = _player.AddComponent<PlayerCombat>();
            _player.AddComponent<PlayerDefense>();
            _player.AddComponent<PlayerInventory>();
            _lyraGo = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            _lyraGo.transform.position = new Vector3(3, 0.9f, 2);
            _lyraGo.SetActive(false);
            _lyraGo.AddComponent<QuestGiver>().NpcId = "npc_lyra_brightwood";
            _lyra = _lyraGo.AddComponent<CompanionAI>();
            _lyra.enabled = false;
            _lyraGo.SetActive(true);
            Physics.SyncTransforms();
        }

        [TearDown]
        public void TearDown()
        {
            Time.captureDeltaTime = 0f;
            GameTime.Clear();
            CameraShake.Reset();
            foreach (var m in Object.FindObjectsByType<MonsterDummy>(FindObjectsSortMode.None)) Object.DestroyImmediate(m.gameObject);
            Object.DestroyImmediate(_lyraGo);
            Object.DestroyImmediate(_player);
            Object.DestroyImmediate(_ground);
            AggroDirector.Reset();
            MonsterController.ResetTactics();
        }

        MonsterDummy Monster(string species, Vector3 at) => MonsterSpawner.Spawn(null, species, at, _player.transform.position);

        [Test]
        public void PresetChangesHerOrderAndStance()
        {
            _lyra.Join(_combat);
            Assert.AreEqual(CompanionPreset.Balanced, _lyra.Preset, "Balanced is the default");
            _lyra.SetPreset(CompanionPreset.Defensive);
            Assert.AreEqual(CompanionPreset.Defensive, _lyra.Preset);
            Assert.AreEqual(CompanionOrder.Hold, _lyra.Order, "Defensive opens with the preset's default order (Hold)");
            _lyra.SetPreset(CompanionPreset.Aggressive);
            Assert.AreEqual(CompanionOrder.Focus, _lyra.Order);
        }

        [UnityTest]
        public IEnumerator FallBackCommandSendsHerBackToYouInAFight()
        {
            _lyra.Join(_combat);
            Monster("mon_goblin", new Vector3(0, 0, 6));
            _lyra.CommandWheel(CompanionCommand.Retreat);
            bool retreated = false;
            for (int i = 0; i < 180 && !retreated; i++) { yield return null; retreated = _lyra.LastAction == CompanionAction.Retreat; }
            Assert.IsTrue(retreated, "with an enemy in reach, Fall back makes her retreat");
            Assert.IsTrue(_lyra.Retreating);
            _lyra.CommandWheel(CompanionCommand.Follow);
            yield return null;
            Assert.IsFalse(_lyra.Retreating && _lyra.LastAction == CompanionAction.Retreat && _lyra.Hp == _lyra.MaxHp, "any other order lifts a commanded retreat");
        }

        [UnityTest]
        public IEnumerator PackMembersTakeDistinctFlankSlots()
        {
            var a = Monster("mon_goblin", new Vector3(-3, 0, 7)).GetComponent<MonsterController>();
            var b = Monster("mon_goblin", new Vector3(0, 0, 8)).GetComponent<MonsterController>();
            var c = Monster("mon_goblin", new Vector3(3, 0, 7)).GetComponent<MonsterController>();
            yield return null;
            foreach (var m in new[] { a, b, c }) if (m.Brain != null) m.Brain.Alert();
            for (int i = 0; i < 30; i++) yield return null;
            var slots = new[] { a, b, c }.Select(m => m.FlankSlot).ToList();
            Assert.IsTrue(slots.All(s => s >= 1), "every engaged monster has a slot: " + string.Join(",", slots));
            Assert.AreEqual(3, slots.Distinct().Count(), "three peers, three distinct slots (sorted-id assignment): " + string.Join(",", slots));
        }

        [UnityTest]
        public IEnumerator SlotsAndYieldClearWhenTheFightEnds()
        {
            var a = Monster("mon_goblin", new Vector3(0, 0, 7)).GetComponent<MonsterController>();
            yield return null;
            a.Brain.Alert();
            for (int i = 0; i < 20; i++) yield return null;
            Assert.GreaterOrEqual(a.FlankSlot, 1);
            a.GetComponent<MonsterDummy>().TakeHit(99999, HitWeight.Heavy, _player.transform.position, 0);
            for (int i = 0; i < 5; i++) yield return null;
            Assert.AreEqual(0, a.FlankSlot, "a dead monster keeps no slot");
            Assert.IsFalse(a.Yielding, "and no yield timer");
        }
    }
}
