using System.Collections;
using Ascend.Core;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Ascend.Game.Tests
{
    /// <summary>L L H launcher, jump-cancel, air juggle, slam (launch-to-slam) and lock-on, in real Unity frames.</summary>
    public sealed class AirCombatPlayModeTests
    {
        GameObject _ground, _player;
        PlayerMotor _motor;
        PlayerCombat _combat;
        LockOn _lock;

        [SetUp]
        public void SetUp()
        {
            Time.captureDeltaTime = 1f / 60f; // fixed 60 fps: airtime is measured in frames
            _ground = GameObject.CreatePrimitive(PrimitiveType.Cube);
            _ground.transform.localScale = new Vector3(200, 1, 200);
            _ground.transform.position = new Vector3(0, -0.5f, 0);
            _player = new GameObject("TestPlayer");
            var cc = _player.AddComponent<CharacterController>();
            cc.height = 1.8f; cc.radius = 0.35f; cc.center = new Vector3(0, 0.9f, 0);
            _motor = _player.AddComponent<PlayerMotor>();
            _combat = _player.AddComponent<PlayerCombat>();
            _player.AddComponent<PlayerDefense>();
            _lock = _player.AddComponent<LockOn>();
            Physics.SyncTransforms();
            for (int i = 0; i < 10; i++) _motor.Tick(Vector3.zero, false, false, 1f / 60f);
        }

        [TearDown]
        public void TearDown()
        {
            Time.captureDeltaTime = 0f;
            GameTime.Clear();
            CameraShake.Reset();
            foreach (var m in Object.FindObjectsByType<MonsterDummy>(FindObjectsSortMode.None)) Object.DestroyImmediate(m.gameObject);
            foreach (var d in Object.FindObjectsByType<DamageNumber>(FindObjectsSortMode.None)) Object.DestroyImmediate(d.gameObject);
            Object.DestroyImmediate(_player);
            Object.DestroyImmediate(_ground);
        }

        /// <summary>A goblin archer (410 HP, survives a full string) with no AI, so it can be launched and locked on to.</summary>
        MonsterDummy Goblin(Vector3 pos)
        {
            var go = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            go.transform.position = pos + Vector3.up;
            go.SetActive(false);
            go.AddComponent<MonsterDummy>().SpeciesId = "mon_goblin_archer";
            go.SetActive(true);
            Physics.SyncTransforms();
            return go.GetComponent<MonsterDummy>();
        }

        /// <summary>One frame of what PlayerInputDriver does, without input devices.</summary>
        void Step(float dt)
        {
            _combat.Tick(dt);
            _motor.Tick(Vector3.zero, false, false, dt);
            Physics.SyncTransforms();
        }

        IEnumerator LightLightHeavy(MonsterDummy target)
        {
            int hits = 0;
            void OnHit(MonsterDummy m, DamageResult r) => hits++;
            _combat.HitLanded += OnHit;
            _combat.Attack();
            for (int f = 0; f < 120 && hits < 2; f++)
            {
                if (f % 6 == 0) _combat.Attack();
                Step(1f / 60f);
                GameTime.Clear();
                yield return null;
            }
            Assert.GreaterOrEqual(hits, 2, "two light hits landed");
            int before = hits;
            _combat.BeginHeavy();
            Assert.AreEqual(PlayerCombat.Special.Launcher, _combat.CurrentSpecial, "L L H starts the launcher");
            for (int f = 0; f < 60 && hits == before; f++) { Step(1f / 60f); yield return null; }
            _combat.HitLanded -= OnHit;
            GameTime.Clear();
        }

        [UnityTest]
        public IEnumerator LightLightHeavyLaunchesTheGoblin()
        {
            var goblin = Goblin(new Vector3(0, 0, 1.3f));
            yield return LightLightHeavy(goblin);
            for (int i = 0; i < 10; i++) yield return null;
            Assert.IsTrue(goblin.IsAirborne, "the goblin is in the air");
            Assert.Greater(goblin.HeightAboveGround, 0.8f, "launched well off the ground");
        }

        [UnityTest]
        public IEnumerator JumpCancelJuggleAndSlam()
        {
            var goblin = Goblin(new Vector3(0, 0, 1.3f));
            bool slammed = false;
            _combat.LaunchToSlam += _ => slammed = true;
            yield return LightLightHeavy(goblin);

            Assert.IsTrue(_combat.TryJumpCancel(), "jump cancels the launcher's recovery");
            // Rise and juggle with light hits for a while: the pops keep the goblin up past its natural airtime.
            float t = 0f;
            while (t < 1.1f)
            {
                float dt = Time.deltaTime > 0 ? Time.deltaTime : 1f / 60f;
                t += dt;
                if (Mathf.RoundToInt(t * 60) % 8 == 0) _combat.Attack();
                Step(dt);
                GameTime.Clear();
                yield return null;
            }
            Assert.IsTrue(goblin.IsAirborne, "air hits keep the goblin juggled past its natural fall time");
            Assert.IsFalse(_motor.IsGrounded, "the player hangs in the air while attacking");

            _combat.BeginHeavy();
            Assert.AreEqual(PlayerCombat.Special.Slam, _combat.CurrentSpecial, "heavy in the air is a slam");
            t = 0f;
            while (t < 1.5f && (!slammed || goblin.IsAirborne))
            {
                float dt = Time.deltaTime > 0 ? Time.deltaTime : 1f / 60f;
                t += dt; Step(dt); GameTime.Clear(); yield return null;
            }
            Assert.IsTrue(slammed, "launch-to-slam fired");
            Assert.IsFalse(goblin.IsAirborne, "the slam brings the goblin down");
        }

        [UnityTest]
        public IEnumerator LockOnPicksSwitchesAndReleases()
        {
            var cam = new GameObject("Main Camera") { tag = "MainCamera" };
            cam.AddComponent<Camera>();
            cam.transform.SetPositionAndRotation(new Vector3(0, 2, -4), Quaternion.Euler(15, 0, 0));
            var front = Goblin(new Vector3(0, 0, 4));
            var right = Goblin(new Vector3(4, 0, 5));
            yield return null;

            _lock.Toggle();
            Assert.AreEqual(front, _lock.Target, "locks the monster in front");
            Assert.AreEqual(front, _combat.LockTarget, "combat uses the lock target");
            Assert.IsTrue(_lock.Switch(+1), "switches right");
            Assert.AreEqual(right, _lock.Target, "the right-hand goblin");
            yield return null;
            Assert.IsTrue(_motor.FaceDirection.HasValue, "the player faces the target");

            right.TakeHit(99999, HitWeight.Heavy, _player.transform.position, 0);
            yield return null;
            Assert.IsFalse(_lock.IsLocked, "a dead target releases the lock");
            Assert.IsNull(_combat.LockTarget, "combat lock cleared");
            Object.DestroyImmediate(cam);
        }
    }
}
