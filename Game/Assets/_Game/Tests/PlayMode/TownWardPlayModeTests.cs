using System.Collections;
using Ascend.Core;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Ascend.Game.Tests
{
    /// <summary>The town ward: field monsters don't notice you inside it, break off a chase at its edge and never walk in; raiders do.</summary>
    public sealed class TownWardPlayModeTests
    {
        GameObject _ground, _player, _ward;
        PlayerDefense _defense;

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
            _player.AddComponent<PlayerMotor>();
            _player.AddComponent<PlayerCombat>();
            _defense = _player.AddComponent<PlayerDefense>();
            // A ward over everything south of z = 0.
            _ward = new GameObject("Ward");
            _ward.transform.position = new Vector3(0, 0, -20f);
            _ward.AddComponent<TownWard>().Size = new Vector2(60f, 40f);
            Physics.SyncTransforms();
        }

        [TearDown]
        public void TearDown()
        {
            Time.captureDeltaTime = 0f;
            GameTime.Clear();
            CameraShake.Reset();
            foreach (var m in Object.FindObjectsByType<MonsterDummy>(FindObjectsSortMode.None)) Object.DestroyImmediate(MonsterSpawner.RootOf(m));
            foreach (var d in Object.FindObjectsByType<DamageNumber>(FindObjectsSortMode.None)) Object.DestroyImmediate(d.gameObject);
            Object.DestroyImmediate(_player);
            Object.DestroyImmediate(_ward);
            Object.DestroyImmediate(_ground);
            AggroDirector.Reset();
        }

        void MoveTo(Vector3 at)
        {
            var cc = _player.GetComponent<CharacterController>();
            cc.enabled = false; _player.transform.position = at; cc.enabled = true;
            Physics.SyncTransforms();
        }

        MonsterController Resident(string species, Vector3 pos)
        {
            var go = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            go.name = species;
            go.transform.position = pos + Vector3.up;
            go.SetActive(false);
            go.AddComponent<MonsterDummy>().SpeciesId = species;
            var c = go.AddComponent<MonsterController>();
            go.SetActive(true);
            Physics.SyncTransforms();
            return c;
        }

        [UnityTest]
        public IEnumerator AFieldMonsterIgnoresYouInsideTheWard()
        {
            MoveTo(new Vector3(0, 0, -3f));
            var goblin = Resident("mon_goblin", new Vector3(0, 0, 8f)); // 11 m away: well inside its 19 m alert radius
            for (int i = 0; i < 120; i++) yield return null;
            Assert.IsTrue(goblin.Brain == null || goblin.Brain.State == AiState.Idle, "it stays home while you're in town");
            Assert.Greater(goblin.transform.position.z, 7f, "and doesn't move");
        }

        [UnityTest]
        public IEnumerator AChaseBreaksOffAtTheWardAndNeverCrossesIt()
        {
            MoveTo(new Vector3(0, 0, 4f));
            var goblin = Resident("mon_goblin", new Vector3(0, 0, 14f));
            float t = 0;
            while ((goblin.Brain == null || goblin.Brain.State == AiState.Idle) && t < 2f) { t += 1f / 60f; yield return null; }
            Assert.AreNotEqual(AiState.Idle, goblin.Brain.State, "outside town it comes for you");
            MoveTo(new Vector3(0, 0, -6f)); // step back through the gate
            float minZ = float.MaxValue;
            for (int i = 0; i < 300; i++)
            {
                minZ = Mathf.Min(minZ, goblin.transform.position.z);
                yield return null;
            }
            Assert.GreaterOrEqual(minZ, -0.05f, "it never set foot in the ward");
            Assert.IsTrue(goblin.Brain.State == AiState.Return || goblin.Brain.State == AiState.Idle, $"it gave up ({goblin.Brain.State})");
        }

        [UnityTest]
        public IEnumerator RaidersStillComeIntoTown()
        {
            MoveTo(new Vector3(28f, 0, -38f)); // far off, so it marches rather than chases
            var raider = MonsterSpawner.Spawn(null, "mon_goblin", new Vector3(0, 0, 4f), new Vector3(0, 0, -10f));
            Assert.IsNotNull(raider);
            var ai = raider.GetComponent<MonsterController>();
            Assert.IsTrue(ai.IgnoresWard, "spawned raiders, ambushers and defence monsters are exempt");
            ai.MarchTarget = new Vector3(0, 0, -15f); // a raid on the town, as SiegeDirector and DefenceSpot send them
            float minZ = float.MaxValue;
            for (int i = 0; i < 480; i++) { minZ = Mathf.Min(minZ, raider.transform.position.z); yield return null; } // marching at walking pace
            Assert.Less(minZ, -2f, "the raider marched into town");
        }
    }
}
