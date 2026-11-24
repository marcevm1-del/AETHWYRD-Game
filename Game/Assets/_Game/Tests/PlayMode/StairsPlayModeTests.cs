using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Ascend.Game.Tests
{
    /// <summary>The player walks up the manor's stairs and not up walls.</summary>
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

        /// <summary>The manor's four entrance steps: 0.35 m treads, each rise metres above the last, and the landing behind them.</summary>
        void ManorStairs(float firstTop, float rise)
        {
            for (int i = 0; i < 4; i++) { float top = firstTop + i * rise; Box(new Vector3(500f, top / 2f, 499f + i * 0.35f), new Vector3(4f, top, 0.6f)); }
            float landing = firstTop + 3 * rise;
            Box(new Vector3(500f, landing / 2f, 501.5f), new Vector3(4f, landing, 2.6f));
        }

        [UnityTest]
        public IEnumerator ManorStairs_AsRebuilt_AreClimbed()
        {
            Player(PlayerMotor.StepHeight);
            ManorStairs(0.2f, 0.2f);
            yield return WalkNorth(1.2f);
            Assert.Greater(_motor.transform.position.y, 0.75f, "standing on the landing");
        }

        [UnityTest]
        public IEnumerator ManorStairs_InTheOldShape_AreNot()
        {
            Player(PlayerMotor.StepHeight);
            ManorStairs(0.2f, 0.4f);
            yield return WalkNorth(1.2f);
            Assert.Less(_motor.transform.position.y, 1.0f, "0.4 m rises on 0.35 m treads: why the model had to change");
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
