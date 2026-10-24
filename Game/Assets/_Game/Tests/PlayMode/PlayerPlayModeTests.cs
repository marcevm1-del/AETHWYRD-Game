using System.Collections;
using Ascend.Core;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Ascend.Game.Tests
{
    /// <summary>
    /// Ring 0 feel checks in real Unity physics: movement speeds, stamina, jump height, dodge distance and
    /// i-frames, and the basic attack string landing damage with hit-stop. Numbers come from combat_tuning.json.
    /// Run: Unity -batchmode -projectPath Game -runTests -testPlatform PlayMode
    /// </summary>
    public sealed class PlayerPlayModeTests
    {
        const float Dt = 1f / 60f;
        GameObject _ground, _player;
        PlayerMotor _motor;
        static CombatTuning T => AscendData.Db.Tuning;

        [SetUp]
        public void SetUp()
        {
            _ground = GameObject.CreatePrimitive(PrimitiveType.Cube);
            _ground.name = "TestGround";
            _ground.transform.localScale = new Vector3(200, 1, 200);
            _ground.transform.position = new Vector3(0, -0.5f, 0);

            _player = new GameObject("TestPlayer");
            var cc = _player.AddComponent<CharacterController>();
            cc.height = 1.8f; cc.radius = 0.35f; cc.center = new Vector3(0, 0.9f, 0); cc.stepOffset = 0.35f;
            _motor = _player.AddComponent<PlayerMotor>();
            Physics.SyncTransforms();
            Settle();
        }

        [TearDown]
        public void TearDown()
        {
            HitStop.Clear();
            Object.DestroyImmediate(_player);
            Object.DestroyImmediate(_ground);
            foreach (var m in Object.FindObjectsByType<MonsterDummy>(FindObjectsSortMode.None)) Object.DestroyImmediate(m.gameObject);
        }

        void Settle() { for (int i = 0; i < 10; i++) _motor.Tick(Vector3.zero, false, false, Dt); }

        float Travel(Vector3 dir, bool walk, bool sprint, float seconds)
        {
            var start = _player.transform.position;
            for (float t = 0; t < seconds - 1e-4f; t += Dt) _motor.Tick(dir, walk, sprint, Dt);
            var d = _player.transform.position - start; d.y = 0;
            return d.magnitude;
        }

        // ---------------- Movement ----------------
        [Test]
        public void StartsGrounded() => Assert.IsTrue(_motor.IsGrounded, "player settles on the ground");

        [Test]
        public void RunWalkAndSprintSpeedsMatchTuning()
        {
            var m = T.Movement;
            Assert.AreEqual(m.RunSpeed, Travel(Vector3.forward, false, false, 1f), m.RunSpeed * 0.05, "run speed (m/s)");
            Assert.AreEqual(m.WalkSpeed, Travel(Vector3.forward, true, false, 1f), m.WalkSpeed * 0.05, "walk speed (m/s)");
            float before = _motor.Stamina;
            Assert.AreEqual(m.SprintSpeed, Travel(Vector3.forward, false, true, 1f), m.SprintSpeed * 0.05, "sprint speed (m/s)");
            Assert.AreEqual(before - m.SprintStaminaPerSec, _motor.Stamina, 1.0, "sprinting drains stamina per second");
        }

        [Test]
        public void SprintFallsBackToRunWhenStaminaIsEmpty()
        {
            var m = T.Movement;
            Travel(Vector3.forward, false, true, (float)(_motor.MaxStamina / m.SprintStaminaPerSec) + 0.1f);
            Assert.AreEqual(0f, _motor.Stamina, 0.01f, "stamina empty");
            Assert.AreEqual(m.RunSpeed, Travel(Vector3.forward, false, true, 0.25f) / 0.25f, m.RunSpeed * 0.06, "sprint without stamina is a run");
        }

        [Test]
        public void TurnsTowardMovement()
        {
            Travel(Vector3.right, false, false, 0.5f);
            Assert.Less(Vector3.Angle(_player.transform.forward, Vector3.right), 1f, "faces the move direction");
        }

        [Test]
        public void JumpReachesTuningHeightAndLands()
        {
            float y0 = _player.transform.position.y, peak = y0;
            Assert.IsTrue(_motor.Jump(), "can jump when grounded");
            Assert.IsFalse(_motor.Jump(), "no double jump");
            for (int i = 0; i < 180; i++) { _motor.Tick(Vector3.zero, false, false, Dt); peak = Mathf.Max(peak, _player.transform.position.y); }
            Assert.AreEqual(T.Movement.JumpHeight, peak - y0, 0.12, "apex height (m)");
            Assert.IsTrue(_motor.IsGrounded, "lands again");
        }

        // ---------------- Feel (13_Production/movement_feel.md) ----------------
        [Test]
        public void AcceleratesQuicklyAndStopsFaster()
        {
            var m = T.Movement;
            _motor.Tick(Vector3.forward, false, false, Dt);
            Assert.Less(_motor.HorizontalVelocity.magnitude, m.RunSpeed * 0.5, "not instantly at full speed");
            Travel(Vector3.forward, false, false, (float)m.AccelSec + 0.05f);
            Assert.AreEqual(m.RunSpeed, _motor.HorizontalVelocity.magnitude, 0.05, "full run within the acceleration time");
            float stopped = -1f;
            for (float t = 0; t < 0.5f && stopped < 0f; t += Dt) { _motor.Tick(Vector3.zero, false, false, Dt); if (_motor.HorizontalVelocity.magnitude < 0.01f) stopped = t + Dt; }
            Assert.Greater(stopped, 0f, "comes to a stop");
            Assert.LessOrEqual(stopped, m.DecelSec + Dt * 1.5f, "stops within the deceleration time");
        }

        [Test]
        public void ALightStickTiltWalks()
        {
            Travel(Vector3.forward * 0.3f, false, false, 0.5f);
            Assert.AreEqual(T.Movement.WalkSpeed, _motor.HorizontalVelocity.magnitude, 0.05, "walk speed");
        }

        [Test]
        public void CoyoteTimeAllowsAJumpJustAfterALedge()
        {
            var ledge = GameObject.CreatePrimitive(PrimitiveType.Cube);
            ledge.transform.position = new Vector3(0, 2f, 0); ledge.transform.localScale = new Vector3(2, 4, 2);
            try
            {
                var cc = _player.GetComponent<CharacterController>();
                cc.enabled = false; _player.transform.position = new Vector3(0, 4.05f, 0.6f); cc.enabled = true;
                Physics.SyncTransforms();
                for (int i = 0; i < 10; i++) _motor.Tick(Vector3.zero, false, false, Dt);
                Assert.IsTrue(_motor.IsGrounded, "standing on the ledge");
                int frames = 0;
                while (_motor.IsGrounded && frames++ < 60) _motor.Tick(Vector3.forward, false, false, Dt);
                Assert.IsFalse(_motor.IsGrounded, "walked off the edge");
                _motor.Tick(Vector3.forward, false, false, Dt); _motor.Tick(Vector3.forward, false, false, Dt);
                Assert.IsTrue(_motor.Jump(), "a jump two frames after leaving the ledge still works");
                Assert.Greater(_motor.VerticalVelocity, 0f, "and goes up");
            }
            finally { Object.DestroyImmediate(ledge); }
        }

        [Test]
        public void AJumpPressedJustBeforeLandingFiresOnLanding()
        {
            Assert.IsTrue(_motor.Jump());
            float landingIn = 0f;
            // Fall until just above the ground, then press jump again.
            for (int i = 0; i < 180 && !(_motor.VerticalVelocity < 0f && _player.transform.position.y < 0.25f); i++) _motor.Tick(Vector3.zero, false, false, Dt);
            Assert.IsFalse(_motor.Jump(), "still in the air: buffered, not a double jump");
            bool rose = false;
            for (int i = 0; i < 20 && !rose; i++) { _motor.Tick(Vector3.zero, false, false, Dt); landingIn += Dt; rose = _motor.VerticalVelocity > 1f; }
            Assert.IsTrue(rose, "the buffered jump fired on landing");
            Assert.LessOrEqual(landingIn, (float)T.Movement.JumpBufferSec + Dt, "within the buffer window");
        }

        [Test]
        public void ReleasingJumpEarlyGivesAShortHop()
        {
            float y0 = _player.transform.position.y, peak = y0;
            _motor.Jump();
            for (int i = 0; i < 4; i++) _motor.Tick(Vector3.zero, false, false, Dt);
            _motor.ReleaseJump();
            for (int i = 0; i < 120; i++) { _motor.Tick(Vector3.zero, false, false, Dt); peak = Mathf.Max(peak, _player.transform.position.y); }
            Assert.Less(peak - y0, T.Movement.JumpHeight * 0.6, "a hop, not the full jump");
            Assert.Greater(peak - y0, 0.2, "but still a hop");
        }

        [Test]
        public void FallsFasterThanItRises()
        {
            float y0 = _player.transform.position.y;
            _motor.Jump();
            int up = 0, down = 0;
            for (int i = 0; i < 240; i++)
            {
                _motor.Tick(Vector3.zero, false, false, Dt);
                if (_motor.IsGrounded && i > 3) break;
                if (_motor.VerticalVelocity > 0f) up++; else down++;
            }
            Assert.Less(down, up, "the descent is quicker than the climb");
        }

        [Test]
        public void DodgeCoversDistanceWithIframesAndCostsStamina()
        {
            var d = T.Dodge;
            float stamina = _motor.Stamina;
            var start = _player.transform.position;
            Assert.IsTrue(_motor.Dodge(Vector3.right), "dodge starts");
            Assert.IsFalse(_motor.Dodge(Vector3.right), "can't start a dodge mid-dodge");
            Assert.AreEqual(stamina - d.StaminaCost, _motor.Stamina, 0.01, "stamina cost");
            _motor.Tick(Vector3.zero, false, false, Dt);
            Assert.IsTrue(_motor.IsInvulnerable, "i-frames at the start");
            for (float t = Dt; t < d.DurationSec + Dt; t += Dt)
            {
                _motor.Tick(Vector3.zero, false, false, Dt);
                if (t > d.IframeSec + Dt) Assert.IsFalse(_motor.IsInvulnerable, "i-frames end after iframeSec");
            }
            Assert.IsFalse(_motor.IsDodging, "dodge finished");
            float moved = Vector3.Distance(new Vector3(start.x, 0, start.z), new Vector3(_player.transform.position.x, 0, _player.transform.position.z));
            Assert.AreEqual(d.Distance, moved, d.Distance * 0.1, "dodge distance (m)");
        }

        [Test]
        public void BackstepWithoutInput()
        {
            var start = _player.transform.position;
            _motor.Dodge(Vector3.zero);
            for (int i = 0; i < 40; i++) _motor.Tick(Vector3.zero, false, false, Dt);
            Assert.Less(_player.transform.position.z, start.z - 0.5f, "dodging with no input steps backwards");
        }

        // ---------------- Combat ----------------
        MonsterDummy SpawnGoblin(Vector3 pos)
        {
            var go = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            go.name = "TestGoblin";
            go.transform.position = pos + Vector3.up;
            go.SetActive(false); // set the species before Awake reads it
            var m = go.AddComponent<MonsterDummy>();
            m.SpeciesId = "mon_goblin";
            go.SetActive(true);
            Physics.SyncTransforms();
            return m;
        }

        PlayerCombat AddCombat() => _player.AddComponent<PlayerCombat>();

        /// <summary>Mashes attack for up to <paramref name="seconds"/>, ticking combat and motor like the input driver.</summary>
        int Mash(PlayerCombat c, float seconds, System.Func<bool> stop = null)
        {
            int hits = 0;
            c.HitLanded += (_, __) => hits++;
            for (float t = 0; t < seconds; t += Dt)
            {
                if (Mathf.RoundToInt(t / Dt) % 6 == 0) c.Attack();
                c.Tick(Dt);
                _motor.Tick(Vector3.zero, false, false, Dt);
                Physics.SyncTransforms();
                if (stop != null && stop()) break;
            }
            return hits;
        }

        [Test]
        public void StringDefeatsALevel1Goblin()
        {
            var goblin = SpawnGoblin(new Vector3(0, 0, 1.4f));
            var c = AddCombat();
            int max = goblin.MaxHp, firstHit = 0;
            c.HitLanded += (m, r) => { if (firstHit == 0) firstHit = r.Amount; };
            int hits = Mash(c, 3f, () => goblin.IsDead);
            Assert.Greater(firstHit, 0, "hits deal damage");
            Assert.Less(firstHit, max, "a Lv 1 light hit doesn't one-shot a goblin");
            Assert.IsTrue(goblin.IsDead, $"goblin defeated within the 4-hit string (HP {goblin.Hp}/{max} after {hits} hits)");
            Assert.LessOrEqual(hits, 4, "within one string");
        }

        [Test]
        public void SoftLockTurnsTowardAMonsterOffToTheSide()
        {
            var goblin = SpawnGoblin(new Vector3(1.0f, 0, 1.2f)); // ~40° to the right
            var c = AddCombat();
            c.Attack();
            c.Tick(Dt);
            Vector3 to = goblin.transform.position - _player.transform.position; to.y = 0;
            Assert.Less(Vector3.Angle(_player.transform.forward, to), 2f, "player snaps to face the target");
        }

        [Test]
        public void MissesWhenNothingIsInReach()
        {
            var goblin = SpawnGoblin(new Vector3(0, 0, 8f));
            var c = AddCombat();
            Assert.AreEqual(0, Mash(c, 1f), "no hits at 8 m");
            Assert.AreEqual(goblin.MaxHp, goblin.Hp, "goblin untouched");
        }

        [UnityTest]
        public IEnumerator HitStopFreezesTimeThenRestores()
        {
            SpawnGoblin(new Vector3(0, 0, 1.4f));
            var c = AddCombat();
            bool hit = false;
            c.HitLanded += (_, __) => hit = true;
            c.Attack();
            for (int i = 0; i < 30 && !hit; i++) c.Tick(Dt);
            Assert.IsTrue(hit, "first hit landed");
            Assert.IsTrue(HitStop.Active, "hit-stop active");
            Assert.AreEqual(0f, Time.timeScale, "time frozen");
            yield return new WaitForSecondsRealtime((float)T.Hitstop.Light + 0.1f);
            Assert.IsFalse(HitStop.Active, "hit-stop ended");
            Assert.AreEqual(1f, Time.timeScale, "time restored");
        }

        [Test]
        public void DodgeCancelsAnAttackOnlyAfterStartup()
        {
            var c = AddCombat();
            c.Attack();
            Assert.IsFalse(c.TryCancelForDodge(), "startup can't be dodge-cancelled");
            for (int i = 0; i < 30 && c.Chain.Phase == AttackPhase.Startup; i++) c.Tick(Dt);
            Assert.IsTrue(c.TryCancelForDodge(), "active frames can be dodge-cancelled");
            Assert.IsFalse(c.IsAttacking, "attack ended");
        }
    }
}
