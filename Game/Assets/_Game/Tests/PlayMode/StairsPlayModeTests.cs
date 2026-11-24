using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Ascend.Game.Tests
{
    /// <summary>The player walks up the steepest stairs in the town kit (0.4 m rises, 0.35 m treads), and not up walls.</summary>
    public sealed class StairsPlayModeTests
    {
        readonly List<GameObject> _made = new List<GameObject>();
        PlayerMotor _motor;

        [TearDown]
        public void TearDown() { foreach (var g in _made) Object.DestroyImmediate(g); _made.Clear(); }

        void Box(Vector3 centre, Vector3 size)
        {
            var b = GameObject.CreatePrimitive(PrimitiveType.Cube);
            b.transform.position = centre;
            b.transform.localScale = size;
            _made.Add(b);
        }

        void Player(float stepOffset)
        {
            Box(new Vector3(500f, -0.5f, 500f), new Vector3(20f, 1f, 20f));
            var go = new GameObject("StairsPlayer");
            go.transform.position = new Vector3(500f, 0.1f, 497f);
            var cc = go.AddComponent<CharacterController>();
            cc.height = 1.8f; cc.radius = 0.35f; cc.center = new Vector3(0, 0.9f, 0);
            _motor = go.AddComponent<PlayerMotor>();
            cc.stepOffset = stepOffset;
            _made.Add(go);
        }

        IEnumerator WalkNorth(float seconds)
        {
            Physics.SyncTransforms();
            for (float t = 0; t < seconds; t += 1f / 60f) { _motor.Tick(Vector3.forward, false, false, 1f / 60f); yield return null; }
        }

        void KitStairs() { for (int i = 0; i < 4; i++) Box(new Vector3(500f, 0.1f + i * 0.2f, 499f + i * 0.35f), new Vector3(4f, 0.2f + i * 0.4f, 0.6f)); Box(new Vector3(500f, 0.7f, 501.5f), new Vector3(4f, 1.4f, 2.6f)); }

        [UnityTest]
        public IEnumerator KitStairs_AreClimbed()
        {
            Player(PlayerMotor.StepHeight);
            KitStairs();
            yield return WalkNorth(1.2f);
            Assert.Greater(_motor.transform.position.y, 1.3f, "standing on the top step");
        }

        [UnityTest]
        public IEnumerator KitStairs_StopTheOldStepHeight()
        {
            Player(0.35f);
            KitStairs();
            yield return WalkNorth(1.2f);
            Assert.Less(_motor.transform.position.y, 1.0f, "the bug: 0.35 m cannot take a 0.4 m rise");
        }

        [UnityTest]
        public IEnumerator AWaistHighWall_IsNotClimbed()
        {
            Player(PlayerMotor.StepHeight);
            Box(new Vector3(500f, 0.4f, 500f), new Vector3(4f, 0.8f, 1f));
            yield return WalkNorth(1.2f);
            Assert.Less(_motor.transform.position.y, 0.3f);
        }

        [Test]
        public void Motor_SetsTheStepHeightItself()
        {
            Player(0.35f);
            var go = new GameObject("FreshMotor");
            go.AddComponent<CharacterController>().stepOffset = 0.1f;
            go.AddComponent<PlayerMotor>();
            _made.Add(go);
            Assert.AreEqual(PlayerMotor.StepHeight, go.GetComponent<CharacterController>().stepOffset, 0.001f, "so old scenes get it too");
        }
    }
}
