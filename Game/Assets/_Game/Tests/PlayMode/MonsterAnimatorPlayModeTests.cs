using System.Collections;
using Ascend.Core;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Ascend.Game.Tests
{
    /// <summary>Procedural monster animation: visual pivot, per-rig styles, windup/strike poses, hit recoil, death.</summary>
    public sealed class MonsterAnimatorPlayModeTests
    {
        GameObject _ground, _player;

        [SetUp]
        public void SetUp()
        {
            Time.captureDeltaTime = 1f / 60f;
            AggroDirector.Reset();
            _ground = GameObject.CreatePrimitive(PrimitiveType.Cube);
            _ground.transform.localScale = new Vector3(200, 1, 200);
            _ground.transform.position = new Vector3(0, -0.5f, 0);
        }

        [TearDown]
        public void TearDown()
        {
            Time.captureDeltaTime = 0f;
            GameTime.Clear();
            CameraShake.Reset();
            foreach (var m in Object.FindObjectsByType<MonsterDummy>(FindObjectsSortMode.None)) Object.DestroyImmediate(m.gameObject);
            if (_player != null) Object.DestroyImmediate(_player);
            Object.DestroyImmediate(_ground);
            AggroDirector.Reset();
        }

        MonsterAnimator Spawn(string species, Vector3 pos, bool withAi)
        {
            var go = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            go.name = species;
            go.transform.position = pos + Vector3.up;
            go.transform.rotation = Quaternion.LookRotation(-new Vector3(pos.x, 0, pos.z) + Vector3.forward * 0.001f);
            go.SetActive(false);
            go.AddComponent<MonsterDummy>().SpeciesId = species;
            if (withAi) go.AddComponent<MonsterController>();
            var a = go.AddComponent<MonsterAnimator>();
            go.SetActive(true);
            Physics.SyncTransforms();
            return a;
        }

        void AddPlayer()
        {
            _player = new GameObject("TestPlayer");
            var cc = _player.AddComponent<CharacterController>();
            cc.height = 1.8f; cc.radius = 0.35f; cc.center = new Vector3(0, 0.9f, 0);
            _player.AddComponent<PlayerMotor>();
            _player.AddComponent<PlayerCombat>();
            _player.AddComponent<PlayerDefense>();
            Physics.SyncTransforms();
        }

        [UnityTest]
        public IEnumerator RenderersMoveUnderAFeetLevelPivotAndTheRootStaysPut()
        {
            var a = Spawn("mon_goblin", new Vector3(0, 0, 5), false);
            yield return null;
            Assert.IsNotNull(a.Visual, "a visual pivot exists");
            Assert.IsNull(a.GetComponent<MeshRenderer>(), "no renderer left on the physics root");
            Assert.IsNotNull(a.Visual.GetComponentInChildren<MeshRenderer>(), "the mesh lives under the pivot");
            Assert.IsNotNull(a.GetComponent<Collider>(), "the collider stays on the root");
            Assert.AreEqual(0f, a.transform.position.y + a.Visual.localPosition.y, 0.05f, "the pivot sits at the feet (ground level)");
            Assert.AreEqual(Vector3.one, a.transform.localScale, "the root is never scaled");
        }

        [UnityTest]
        public IEnumerator StylesFollowTheRigFamily()
        {
            var slime = Spawn("mon_blue_slime", new Vector3(-3, 0, 6), false);
            var goblin = Spawn("mon_goblin", new Vector3(0, 0, 6), false);
            var rabbit = Spawn("mon_horned_rabbit", new Vector3(3, 0, 6), false);
            yield return null;
            Assert.AreEqual(MonsterAnimator.Style.Blob, slime.Kind, "slime = blob");
            Assert.AreEqual(MonsterAnimator.Style.Biped, goblin.Kind, "goblin = biped");
            Assert.AreEqual(MonsterAnimator.Style.Quad, rabbit.Kind, "rabbit = quad");
        }

        [UnityTest]
        public IEnumerator FlyersHoverAndSpiritsFloatLow()
        {
            var moth = Spawn("mon_lantern_moth", new Vector3(-2, 0, 6), false);
            var wisp = Spawn("mon_wisp", new Vector3(2, 0, 6), false);
            var dragonless = Spawn("mon_goblin", new Vector3(0, 0, 8), false);
            for (int i = 0; i < 30; i++) yield return null;
            Assert.AreEqual(MonsterAnimator.Style.Flyer, moth.Kind);
            Assert.AreEqual(MonsterAnimator.Style.Flyer, wisp.Kind);
            Assert.AreEqual(MonsterAnimator.Style.Biped, dragonless.Kind, "walkers stay on the ground");
            Assert.Greater(moth.PoseOffset.y, 0.45f, "the moth hovers at about sword height");
            Assert.Less(wisp.PoseOffset.y, moth.PoseOffset.y, "spirits drift lower");
            Assert.Greater(wisp.PoseOffset.y, 0.1f, "but still off the ground");
        }

        [UnityTest]
        public IEnumerator SlimeBreathesAndHopsWhenMoving()
        {
            var a = Spawn("mon_blue_slime", new Vector3(0, 0, 6), false);
            float minY = 9, maxY = -9;
            for (int i = 0; i < 90; i++) { yield return null; minY = Mathf.Min(minY, a.PoseScale.y); maxY = Mathf.Max(maxY, a.PoseScale.y); }
            Assert.Greater(maxY - minY, 0.01f, "idle breathing wobble");
            float maxHop = 0f;
            for (int i = 0; i < 90; i++)
            {
                a.transform.position += Vector3.right * 1.8f / 60f;
                yield return null;
                maxHop = Mathf.Max(maxHop, a.PoseOffset.y);
            }
            Assert.Greater(maxHop, 0.05f, "moving makes it hop");
        }

        [UnityTest]
        public IEnumerator GoblinWindsUpThenLungesAndRecoilsWhenHit()
        {
            AddPlayer();
            var a = Spawn("mon_goblin", new Vector3(0, 0, 1.3f), true);
            var ai = a.GetComponent<MonsterController>();
            bool sawWindup = false, sawStrike = false;
            float t = 0f;
            while (t < 4f && !(sawWindup && sawStrike))
            {
                t += Time.deltaTime;
                yield return null;
                if (ai.Brain == null) continue;
                if (ai.Brain.State == AiState.Windup && ai.Brain.WindupProgress > 0.6) { sawWindup |= a.PoseRotation.eulerAngles.x > 300f || a.PoseOffset.z < -0.05f; }
                if (ai.Brain.State == AiState.Active) sawStrike |= a.PoseOffset.z > 0.1f;
            }
            Assert.IsTrue(sawWindup, "pulls back during the windup");
            Assert.IsTrue(sawStrike, "lunges on the strike");

            var body = a.GetComponent<MonsterDummy>();
            body.TakeHit(1, HitWeight.Medium, _player.transform.position, 0);
            yield return null;
            Assert.Less(a.PoseScale.y, 1f, "squashes on the hit");
        }

        [UnityTest]
        public IEnumerator DeathCollapsesBeforeVanishing()
        {
            var a = Spawn("mon_goblin", new Vector3(0, 0, 5), false);
            yield return null;
            var body = a.GetComponent<MonsterDummy>();
            var r = a.Visual.GetComponentInChildren<Renderer>();
            body.TakeHit(99999, HitWeight.Heavy, Vector3.zero, 0);
            yield return null;
            Assert.IsTrue(r.enabled, "still visible right after dying (death animation)");
            Assert.IsFalse(a.GetComponent<Collider>().enabled, "but no longer hittable");
            for (int i = 0; i < 20; i++) yield return null;
            Assert.Greater(Mathf.Abs(Mathf.DeltaAngle(0f, a.PoseRotation.eulerAngles.z)), 20f, "the goblin topples");
            for (int i = 0; i < 40; i++) yield return null;
            Assert.IsFalse(r.enabled, "hidden after the death animation");
        }
    }
}
