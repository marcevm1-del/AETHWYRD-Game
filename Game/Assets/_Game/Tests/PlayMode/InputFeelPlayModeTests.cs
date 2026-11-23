using Ascend.Core;
using NUnit.Framework;
using UnityEngine;

namespace Ascend.Game.Tests
{
    /// <summary>
    /// Block stamina, the parry press edge and buffered heavies in real Unity components.
    /// NOT RUN: written without Unity (decision D-06); run through Tools/pc/update_and_verify.cmd.
    /// </summary>
    public sealed class InputFeelPlayModeTests
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
        }

        [TearDown]
        public void TearDown()
        {
            GameTime.Clear();
            Object.DestroyImmediate(_player);
            Object.DestroyImmediate(_ground);
        }

        [Test]
        public void BlockedHit_DrainsBlockStaminaPerHit()
        {
            _defense.SetBlock(true);
            _defense.ReceiveAttack(1, Telegraph.Blue); // spends the parry window
            float before = _motor.Stamina;
            var r = _defense.ReceiveAttack(50, Telegraph.Blue);
            Assert.AreEqual(DefenseResult.Blocked, r);
            Assert.AreEqual(before - (float)T.Parry.BlockStaminaPerHit, _motor.Stamina, 0.01f);
        }

        [Test]
        public void BlockAtZeroStamina_FailsAndTheHitLandsInFull()
        {
            _defense.SetBlock(true);
            _defense.ReceiveAttack(1, Telegraph.Blue);
            _motor.DrainStamina(_motor.MaxStamina);
            _defense.SetBlock(true, false, Dt);
            int hp = _defense.Hp;
            Assert.AreEqual(DefenseResult.Hit, _defense.ReceiveAttack(20, Telegraph.Blue));
            Assert.AreEqual(hp - 20, _defense.Hp);
        }

        [Test]
        public void BlockHeldThroughAnAttack_DoesNotReopenTheParryWindow()
        {
            _defense.SetBlock(true, false, Dt);
            _defense.ReceiveAttack(1, Telegraph.Blue); // parried: window consumed
            _defense.SetBlock(true, true, Dt);   // attack suppresses the guard
            _defense.SetBlock(true, false, Dt);  // attack over, button still held
            Assert.IsTrue(_defense.IsBlocking);
            Assert.AreEqual(DefenseResult.Blocked, _defense.ReceiveAttack(10, Telegraph.Blue), "a plain block, not a parry");
        }

        [Test]
        public void HeavyDuringAttackStartup_IsRefusedSoTheBufferCanRetryIt()
        {
            _combat.Attack();
            Assert.IsFalse(_combat.BeginHeavy(), "startup refuses the heavy");
            for (int i = 0; i < 30 && _combat.Chain.Phase == AttackPhase.Startup; i++) _combat.Tick(Dt);
            Assert.IsTrue(_combat.BeginHeavy(), "after startup it is accepted");
        }
    }
}
