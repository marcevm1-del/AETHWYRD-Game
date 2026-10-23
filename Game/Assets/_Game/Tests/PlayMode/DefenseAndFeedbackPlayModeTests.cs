using System.Collections;
using Ascend.Core;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Ascend.Game.Tests
{
    /// <summary>
    /// Perfect dodge → Flash Time, parry → riposte, block, charged heavies, camera shake and damage numbers,
    /// in real Unity time. Windows and multipliers come from combat_tuning.json.
    /// </summary>
    public sealed class DefenseAndFeedbackPlayModeTests
    {
        const float Dt = 1f / 60f;
        GameObject _ground, _player;
        PlayerMotor _motor;
        PlayerCombat _combat;
        PlayerDefense _defense;
        static CombatTuning T => AscendData.Db.Tuning;

        [SetUp]
        public void SetUp()
        {
            _ground = GameObject.CreatePrimitive(PrimitiveType.Cube);
            _ground.transform.localScale = new Vector3(200, 1, 200);
            _ground.transform.position = new Vector3(0, -0.5f, 0);
            _player = new GameObject("TestPlayer");
            var cc = _player.AddComponent<CharacterController>();
            cc.height = 1.8f; cc.radius = 0.35f; cc.center = new Vector3(0, 0.9f, 0);
            _motor = _player.AddComponent<PlayerMotor>();
            _combat = _player.AddComponent<PlayerCombat>();
            _defense = _player.AddComponent<PlayerDefense>();
            Physics.SyncTransforms();
            for (int i = 0; i < 10; i++) _motor.Tick(Vector3.zero, false, false, Dt);
            FeedbackSettings.ShakeScale = 1f;
            FeedbackSettings.DamageNumbersOverride = null;
        }

        [TearDown]
        public void TearDown()
        {
            GameTime.Clear();
            CameraShake.Reset();
            Object.DestroyImmediate(_player);
            Object.DestroyImmediate(_ground);
            foreach (var m in Object.FindObjectsByType<MonsterDummy>(FindObjectsSortMode.None)) Object.DestroyImmediate(m.gameObject);
            foreach (var d in Object.FindObjectsByType<DamageNumber>(FindObjectsSortMode.None)) Object.DestroyImmediate(d.gameObject);
        }

        MonsterDummy SpawnGoblin(Vector3 pos)
        {
            var go = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            go.transform.position = pos + Vector3.up;
            go.SetActive(false);
            go.AddComponent<MonsterDummy>().SpeciesId = "mon_goblin";
            go.SetActive(true);
            Physics.SyncTransforms();
            return go.GetComponent<MonsterDummy>();
        }

        [UnityTest]
        public IEnumerator HpStartsFromClassStats()
        {
            yield return null; // Start() runs
            Assert.AreEqual(_combat.Stats.Hp, _defense.MaxHp, "max HP from the Lv 1 Swordsman's derived stats");
        }

        [Test]
        public void PerfectDodgeTriggersFlashTimeAndRefundsStamina()
        {
            Assert.IsTrue(_motor.Dodge(Vector3.right));
            float afterDodge = _motor.Stamina;
            var r = _defense.ReceiveAttack(50, Telegraph.Red);
            Assert.AreEqual(DefenseResult.PerfectDodge, r, "hit right after the dodge starts is a perfect dodge");
            Assert.IsTrue(GameTime.FlashTimeActive, "Flash Time starts");
            Assert.AreEqual((float)T.FlashTime.TimeScale, Time.timeScale, 1e-4f, "world slows to the tuned scale");
            Assert.AreEqual(afterDodge + (float)T.Dodge.StaminaCost, _motor.Stamina, 0.01f, "dodge stamina refunded (free defense)");
            Assert.AreEqual(_defense.MaxHp, _defense.Hp, "no damage taken");
        }

        [Test]
        public void ParryStaggersTheAttackerAndOpensARiposte()
        {
            var goblin = SpawnGoblin(new Vector3(0, 0, 1.4f));
            _defense.SetBlock(true);
            var r = _defense.ReceiveAttack(40, Telegraph.Blue, goblin);
            Assert.AreEqual(DefenseResult.Parried, r, "blue attack right after pressing block is parried");
            Assert.AreEqual(1, goblin.Staggers, "attacker staggers");
            Assert.IsTrue(_combat.RiposteReady, "riposte window opens");
            GameTime.Clear();

            int before = goblin.Hp, dealt = 0;
            _combat.HitLanded += (_, res) => dealt = res.Amount;
            _combat.Attack();
            Assert.IsFalse(_combat.RiposteReady, "the riposte consumes the window");
            for (int i = 0; i < 60 && dealt == 0; i++) _combat.Tick(Dt);
            Assert.Greater(dealt, 0, "riposte lands");
            Assert.Less(goblin.Hp, before, "riposte damages the goblin");
        }

        [Test]
        public void HeldBlockReducesDamageButRedGetsThrough()
        {
            _defense.SetBlock(true);
            _defense.ReceiveAttack(1, Telegraph.Blue); // uses up the parry window
            int hp = _defense.Hp;
            Assert.AreEqual(DefenseResult.Blocked, _defense.ReceiveAttack(100, Telegraph.Blue), "a held block blocks");
            Assert.AreEqual(hp - Mathf.RoundToInt(100 * (1 - (float)T.Parry.BlockDamageReduction)), _defense.Hp, "block reduction applied");
            Assert.AreEqual(DefenseResult.Hit, _defense.ReceiveAttack(10, Telegraph.Red), "red ignores blocks");
        }

        [Test]
        public void ChargedHeavyHitsHarderThanATap()
        {
            int Swing(float holdSec)
            {
                var goblin = SpawnGoblin(new Vector3(0, 0, 1.4f));
                int dealt = 0;
                void OnHit(MonsterDummy m, DamageResult r) => dealt = r.Amount;
                _combat.HitLanded += OnHit;
                _combat.BeginHeavy();
                for (float t = 0; t < holdSec; t += Dt) _combat.Tick(Dt);
                _combat.ReleaseHeavy();
                for (int i = 0; i < 90 && dealt == 0; i++) _combat.Tick(Dt);
                _combat.HitLanded -= OnHit;
                GameTime.Clear();
                Object.DestroyImmediate(goblin.gameObject);
                Physics.SyncTransforms();
                for (int i = 0; i < 60; i++) _combat.Tick(Dt); // recover
                return dealt;
            }
            int tap = Swing(0.05f);
            Assert.AreEqual(0, _combat.LastChargeLevel, "tap heavy is level 0");
            int full = Swing((float)T.Combo.ChargeLevels[2] + 0.1f);
            Assert.AreEqual(3, _combat.LastChargeLevel, "full charge is level 3");
            Assert.Greater(tap, 0, "tap heavy lands");
            Assert.Greater(full, tap, "a full charge hits harder than a tap");
        }

        [Test]
        public void HeavyHitsShakeTheCameraAndShowDamageNumbers()
        {
            SpawnGoblin(new Vector3(0, 0, 1.4f));
            bool hit = false;
            _combat.HitLanded += (_, __) => hit = true;
            _combat.BeginHeavy();
            _combat.ReleaseHeavy();
            for (int i = 0; i < 90 && !hit; i++) _combat.Tick(Dt);
            Assert.IsTrue(hit, "heavy lands");
            Assert.Greater(CameraShake.Amplitude, 0f, "heavy hit shakes the camera");
            Assert.LessOrEqual(CameraShake.Amplitude, (float)T.Camera.ShakeMax + 1e-4f, "shake stays under the cap");
            Assert.GreaterOrEqual(Object.FindObjectsByType<DamageNumber>(FindObjectsSortMode.None).Length, 1, "a damage number appears");
        }

        [Test]
        public void ShakeAndDamageNumbersRespectTheSettings()
        {
            FeedbackSettings.ShakeScale = 0f;
            FeedbackSettings.DamageNumbersOverride = false;
            SpawnGoblin(new Vector3(0, 0, 1.4f));
            bool hit = false;
            _combat.HitLanded += (_, __) => hit = true;
            _combat.BeginHeavy();
            _combat.ReleaseHeavy();
            for (int i = 0; i < 90 && !hit; i++) _combat.Tick(Dt);
            Assert.IsTrue(hit, "heavy lands");
            Assert.AreEqual(0f, CameraShake.Amplitude, "shake off at 0");
            Assert.AreEqual(0, Object.FindObjectsByType<DamageNumber>(FindObjectsSortMode.None).Length, "numbers off");
        }

        [UnityTest]
        public IEnumerator HitStopInsideFlashTimeReturnsToFlashSpeed()
        {
            GameTime.FlashTime(0.25f, 1f);
            GameTime.HitStop(0.05f);
            Assert.AreEqual(0f, Time.timeScale, "hit-stop wins while active");
            yield return new WaitForSecondsRealtime(0.15f);
            Assert.AreEqual(0.25f, Time.timeScale, 1e-4f, "back to Flash Time speed, not full speed");
        }
    }
}
