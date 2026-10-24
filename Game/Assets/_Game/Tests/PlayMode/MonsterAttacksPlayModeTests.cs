using System.Collections;
using Ascend.Core;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Ascend.Game.Tests
{
    /// <summary>Attack kinds from the motion bible: travelling projectiles, the rabbit's straight charge (stuck on a miss), grabs.</summary>
    public sealed class MonsterAttacksPlayModeTests
    {
        GameObject _ground, _player, _wall;
        PlayerDefense _defense;
        PlayerMotor _motor;

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
            _motor = _player.AddComponent<PlayerMotor>();
            _player.AddComponent<PlayerCombat>();
            _defense = _player.AddComponent<PlayerDefense>();
            Physics.SyncTransforms();
        }

        [TearDown]
        public void TearDown()
        {
            Time.captureDeltaTime = 0f;
            GameTime.Clear();
            CameraShake.Reset();
            foreach (var m in Object.FindObjectsByType<MonsterDummy>(FindObjectsSortMode.None)) Object.DestroyImmediate(m.gameObject);
            foreach (var p in Object.FindObjectsByType<MonsterProjectile>(FindObjectsSortMode.None)) Object.DestroyImmediate(p.gameObject);
            if (_wall != null) Object.DestroyImmediate(_wall);
            Object.DestroyImmediate(_player);
            Object.DestroyImmediate(_ground);
            AggroDirector.Reset();
        }

        MonsterController Spawn(string species, Vector3 pos)
        {
            var go = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            go.name = species;
            go.transform.position = pos + Vector3.up;
            go.transform.rotation = Quaternion.LookRotation(-new Vector3(pos.x, 0, pos.z));
            go.SetActive(false);
            go.AddComponent<MonsterDummy>().SpeciesId = species;
            var c = go.AddComponent<MonsterController>();
            go.SetActive(true);
            Physics.SyncTransforms();
            return c;
        }

        [UnityTest]
        public IEnumerator GoblinThrowsJunkThatTravelsAndHits()
        {
            Spawn("mon_goblin", new Vector3(0, 0, 6f));
            MonsterProjectile seen = null;
            DefenseResult? result = null;
            _defense.Defended += (r, _) => result ??= r;
            float t = 0f;
            while (t < 8f && result == null)
            {
                t += Time.deltaTime;
                seen ??= Object.FindFirstObjectByType<MonsterProjectile>();
                _motor.Tick(Vector3.zero, false, false, Time.deltaTime);
                yield return null;
            }
            Assert.IsNotNull(seen, "a projectile was thrown from range");
            Assert.IsTrue(result.HasValue, "and it reached the player");
        }

        [UnityTest]
        public IEnumerator SidesteppingAProjectileMakesItMiss()
        {
            var goblin = Spawn("mon_goblin", new Vector3(0, 0, 7f));
            MonsterProjectile shot = null;
            float t = 0f;
            while (t < 8f && shot == null) { t += Time.deltaTime; shot = Object.FindFirstObjectByType<MonsterProjectile>(); yield return null; }
            Assume.That(shot, Is.Not.Null, "the goblin threw something");
            goblin.enabled = false; // one throw is enough
            _player.transform.position += Vector3.right * 3f;
            Physics.SyncTransforms();
            int hp = _defense.Hp;
            for (int i = 0; i < 120 && shot != null; i++) yield return null;
            Assert.AreEqual(hp, _defense.Hp, "the junk sails past a player who moved");
        }

        [UnityTest]
        public IEnumerator ChargingRabbitGetsStuckInAWall()
        {
            _wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
            _wall.transform.position = new Vector3(0, 1.25f, 3f);
            _wall.transform.localScale = new Vector3(6f, 2.5f, 0.3f);
            var rabbit = Spawn("mon_horned_rabbit", new Vector3(0, 0, 6f));
            yield return null; // Start
            int hp = _defense.Hp;
            rabbit.BeginDash(Vector3.back, MonsterController.DashMaxM, 30, Telegraph.Red);
            for (int i = 0; i < 60 && !rabbit.IsStuck; i++) yield return null;
            Assert.IsTrue(rabbit.IsStuck, "a charge into the wall leaves the rabbit stuck");
            Assert.AreEqual(AiState.Staggered, rabbit.Brain.State, "stuck = stunned (the punish window)");
            Assert.Greater(rabbit.transform.position.z, 3f, "it stopped at the wall, not through it");
            Assert.AreEqual(hp, _defense.Hp, "the wall took the hit, not the player");
        }

        [UnityTest]
        public IEnumerator AChargeThatConnectsHitsOnce()
        {
            var rabbit = Spawn("mon_horned_rabbit", new Vector3(0, 0, 5f));
            yield return null;
            int hits = 0;
            _defense.Defended += (r, _) => hits++;
            rabbit.BeginDash(Vector3.back, MonsterController.DashMaxM, 30, Telegraph.Red);
            for (int i = 0; i < 90; i++) yield return null;
            Assert.AreEqual(1, hits, "the charge hits the player exactly once");
        }

        [UnityTest]
        public IEnumerator MonstersDontWalkThroughWalls()
        {
            _wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
            _wall.transform.position = new Vector3(0, 1.25f, 3f);
            _wall.transform.localScale = new Vector3(30f, 2.5f, 0.3f);
            var goblin = Spawn("mon_goblin", new Vector3(0, 0, 6f));
            for (int i = 0; i < 240; i++) yield return null;
            Assert.Greater(goblin.transform.position.z, 3f, "the goblin chasing the player is held back by the wall");
        }

        [UnityTest]
        public IEnumerator AMonsterBlockedHeadOnWorksItsWayRound()
        {
            // A short wall dead centre between the goblin and you: sliding alone leaves it pressed against the middle.
            _wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
            _wall.transform.position = new Vector3(0, 1.25f, 3f);
            _wall.transform.localScale = new Vector3(3f, 2.5f, 0.3f);
            var goblin = Spawn("mon_goblin", new Vector3(0, 0, 5.5f));
            bool sidestepped = false;
            float minZ = float.MaxValue;
            for (int i = 0; i < 600; i++)
            {
                sidestepped |= goblin.Sidestepping;
                minZ = Mathf.Min(minZ, goblin.transform.position.z);
                _motor.Tick(Vector3.zero, false, false, Time.deltaTime);
                yield return null;
            }
            Assert.IsTrue(sidestepped, "it noticed it was stuck and stepped aside");
            Assert.Less(minZ, 2.8f, "and got round to your side of the wall");
        }

        [UnityTest]
        public IEnumerator AHurtSkittishMonsterSometimesHopsBack()
        {
            var rabbit = Spawn("mon_horned_rabbit", new Vector3(0, 0, 2.5f));
            var body = rabbit.GetComponent<MonsterDummy>();
            yield return null;
            body.TakeHit(body.MaxHp * 2 / 3, HitWeight.Light, _player.transform.position, 0);
            for (int i = 0; i < 40 && rabbit.Hops == 0 && !body.IsDead; i++)
            {
                body.TakeHit(0, HitWeight.Light, _player.transform.position, 0); // a glancing blow: hurt-reflex without killing it
                for (int f = 0; f < 20; f++) yield return null;
            }
            Assert.Greater(rabbit.Hops, 0, "a badly hurt rabbit leaps back now and then");
            var goblin = Spawn("mon_goblin", new Vector3(3, 0, 3f));
            var gb = goblin.GetComponent<MonsterDummy>();
            yield return null;
            gb.TakeHit(gb.MaxHp * 2 / 3, HitWeight.Light, _player.transform.position, 0);
            for (int i = 0; i < 20; i++) gb.TakeHit(1, HitWeight.Light, _player.transform.position, 0);
            Assert.AreEqual(0, goblin.Hops, "an aggressive goblin stands its ground");
        }

        [UnityTest]
        public IEnumerator HittingOneAntBringsTheSwarm()
        {
            var a = Spawn("mon_giant_ant", new Vector3(0, 0, 25f));
            var b = Spawn("mon_giant_ant", new Vector3(3, 0, 27f));
            var c = Spawn("mon_giant_ant", new Vector3(-3, 0, 27f));
            for (int i = 0; i < 10; i++) yield return null;
            Assert.AreEqual(AiState.Idle, b.Brain.State, "too far away to have noticed you");
            a.GetComponent<MonsterDummy>().TakeHit(1, HitWeight.Light, _player.transform.position, 0);
            yield return null;
            Assert.AreNotEqual(AiState.Idle, b.Brain.State, "its swarm-mates answer the call");
            Assert.AreNotEqual(AiState.Idle, c.Brain.State);
            float zb = b.transform.position.z;
            for (int i = 0; i < 60; i++) { _motor.Tick(Vector3.zero, false, false, Time.deltaTime); yield return null; }
            Assert.Less(b.transform.position.z, zb - 1f, "and come for you");
        }

        [Test]
        public void AGrabHoldsThePlayerForAMoment()
        {
            _defense.SetBlock(true);
            Assert.AreEqual(DefenseResult.Grabbed, _defense.ReceiveAttack(12, Telegraph.Gold), "a gold attack grabs a blocker");
            Assert.IsTrue(_defense.IsHeld, "held");
            Assert.Less(_defense.Hp, _defense.MaxHp, "and hurt");
        }

        [UnityTest]
        public IEnumerator TheGrabLetsGo()
        {
            _defense.ReceiveAttack(12, Telegraph.Gold);
            Assert.IsTrue(_defense.IsHeld, "held");
            for (int i = 0; i < Mathf.CeilToInt(PlayerDefense.GrabHoldSec * 60f) + 5; i++) yield return null;
            Assert.IsFalse(_defense.IsHeld, "released after the hold time");
        }
    }
}
