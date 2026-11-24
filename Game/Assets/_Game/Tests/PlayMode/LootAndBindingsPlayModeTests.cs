using System.Collections;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Ascend.Game.Tests
{
    /// <summary>Dropped cores wait on the ground until you reach them, and no key does two things.</summary>
    public sealed class LootAndBindingsPlayModeTests
    {
        GameObject _player;

        [SetUp]
        public void SetUp() { GameTime.Clear(); _player = new GameObject("LootPlayer"); }

        [TearDown]
        public void TearDown()
        {
            foreach (var p in Object.FindObjectsByType<LootPickup>(FindObjectsSortMode.None)) Object.DestroyImmediate(p.gameObject);
            Object.DestroyImmediate(_player);
        }

        [UnityTest]
        public IEnumerator DroppedCore_WaitsWhileFar_AndIsTakenOnceWhenReached()
        {
            int taken = 0, count = 0;
            var drop = LootPickup.Spawn("itm_core_f", 3, new Vector3(20f, 0f, 0f), _player.transform, Color.cyan, p => { taken++; count = p.Count; });
            yield return new WaitForSeconds(LootPickup.ArmSec + 0.2f);
            Assert.AreEqual(0, taken, "too far away");
            _player.transform.position = drop.transform.position;
            yield return null;
            yield return null;
            Assert.AreEqual(1, taken, "taken once");
            Assert.AreEqual(3, count, "the whole stack");
            Assert.IsTrue(drop == null, "and it is gone from the ground");
        }

        [UnityTest]
        public IEnumerator DroppedCore_UnderYourFeet_IsSeenBeforeItIsTaken()
        {
            int taken = 0;
            LootPickup.Spawn("itm_core_f", 1, Vector3.zero, _player.transform, Color.cyan, _ => taken++);
            yield return null;
            Assert.AreEqual(0, taken, "it hops out first");
            yield return new WaitForSeconds(LootPickup.ArmSec + 0.2f);
            Assert.AreEqual(1, taken);
        }

        [Test]
        public void PlayerBindings_UseEachKeyOnce_AndLeaveTheMenuKeysAlone()
        {
            _player.AddComponent<CharacterController>();
            _player.AddComponent<PlayerMotor>();
            _player.AddComponent<PlayerInputDriver>();
            var paths = PlayerInputDriver.SimpleBindings.ToList();
            Assert.Greater(paths.Count, 25, "the driver bound its keys");
            var twice = paths.GroupBy(p => p).Where(g => g.Count() > 1).Select(g => g.Key).ToList();
            Assert.IsEmpty(twice, "bound twice: " + string.Join(", ", twice));
            foreach (var menu in new[] { "<Keyboard>/c", "<Keyboard>/escape", "<Gamepad>/start", "<Keyboard>/z", "<Keyboard>/t", "<Keyboard>/v", "<Gamepad>/dpad/down", "<Gamepad>/dpad/left" })
                CollectionAssert.DoesNotContain(paths, menu, "used by the status window, pause menu, orders, taming or camera");
        }
    }
}
