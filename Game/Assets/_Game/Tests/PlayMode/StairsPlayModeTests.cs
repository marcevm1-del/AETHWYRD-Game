using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Ascend.Game.Tests
{
    /// <summary>The player walks up the town's stairs and not up walls, with the scene's 0.35 m step offset.</summary>
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

        /// <summary>Steps from z = 498.7 northward, then a long landing: the player covers about 7.8 m and must not run off the end.</summary>
        void Stairs(int count, float tread, float firstTop, float rise)
        {
            for (int i = 0; i < count; i++) { float top = firstTop + i * rise; Box(new Vector3(500f, top / 2f, 498.7f + (i + 0.5f) * tread), new Vector3(4f, top, tread)); }
            float landing = firstTop + (count - 1) * rise, start = 498.7f + count * tread;
            Box(new Vector3(500f, landing / 2f, (start + 509f) / 2f), new Vector3(4f, landing, 509f - start));
        }

        string Where => "ended at " + _motor.transform.position.ToString("F2");

        [UnityTest]
        public IEnumerator ManorStairs_AreClimbed()
        {
            Player(0.35f);
            Stairs(4, 0.35f, 0.2f, 0.2f);
            yield return WalkNorth(1.2f);
            Assert.Greater(_motor.transform.position.y, 0.75f, Where);
        }

        [UnityTest]
        public IEnumerator FieldStairs_AreClimbed()
        {
            Player(0.35f);
            Stairs(6, 0.6f, 0.3f, 0.3f);
            yield return WalkNorth(1.2f);
            Assert.Greater(_motor.transform.position.y, 1.75f, Where);
        }

        [UnityTest]
        public IEnumerator FieldStairs_InTheOldShape_StopThePlayer()
        {
            Player(0.35f);
            Stairs(6, 0.6f, 0.3f, 0.6f);
            yield return WalkNorth(1.2f);
            Assert.Less(_motor.transform.position.z, 499.3f, "0.6 m rises: " + Where);
        }

        [UnityTest]
        public IEnumerator AWaistHighWall_IsNotClimbed()
        {
            Player(0.35f);
            Box(new Vector3(500f, 0.4f, 500f), new Vector3(4f, 0.8f, 1f));
            yield return WalkNorth(1.2f);
            Assert.Less(_motor.transform.position.y, 0.3f, Where);
            Assert.Less(_motor.transform.position.z, 499.5f, "stopped in front of it, " + Where);
        }
    }
}
