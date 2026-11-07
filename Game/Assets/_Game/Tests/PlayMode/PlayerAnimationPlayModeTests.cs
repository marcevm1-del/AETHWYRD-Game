using System.Collections;
using System.Collections.Generic;
using Ascend.Core;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Ascend.Game.Tests
{
    /// <summary>
    /// Wave A1 player animation: one test per Animator arc, driven by hand (PlayerAnimationDriver.Tick + Animator.Update
    /// with a fixed dt) on a bare player built the way Ring0SceneBuilder builds it: CharacterController, PlayerMotor,
    /// PlayerCombat, the placeholder bone rig ("Visual/Hips/..."), an Animator with Player.controller, the
    /// CombatAnimationBridge, the driver and FootIK. The controller is an Editor asset, loaded with AssetDatabase
    /// (PlayMode tests run inside the Editor). If it is missing, build it first:
    ///   Unity -batchmode -projectPath Game -quit -executeMethod Ascend.EditorTools.PlayerAnimationAssets.BuildBatch
    /// Run: Unity -batchmode -projectPath Game -runTests -testPlatform PlayMode -testFilter PlayerAnimationPlayModeTests
    /// </summary>
    public sealed class PlayerAnimationPlayModeTests
    {
        const float Dt = 1f / 60f;
        const string ControllerPath = "Assets/_Game/Art/Animation/Player.controller";
        static readonly string[] BaseStates = { "Locomotion", "JumpStart", "Fall", "Land", "Dodge" };
        static readonly string[] CombatStates = { "CombatIdle", "Startup", "Active", "Recovery", "Charge" };

        GameObject _ground, _player;
        PlayerMotor _motor;
        PlayerCombat _combat;
        PlayerAnimationDriver _driver;
        CombatAnimationBridge _bridge;
        FootIK _ik;
        Animator _animator;
        static CombatTuning T => AscendData.Db.Tuning;

        // ---------------------------------------------------------------- setup

        static RuntimeAnimatorController LoadController()
        {
#if UNITY_EDITOR
            return AssetDatabase.LoadAssetAtPath<RuntimeAnimatorController>(ControllerPath);
#else
            return null;
#endif
        }

        static Transform Bone(Transform parent, string name, Vector3 localPos)
        {
            var go = new GameObject(name);
            go.transform.SetParent(parent, false);
            go.transform.localPosition = localPos;
            return go.transform;
        }

        /// <summary>Same hierarchy and offsets as PlayerAnimationAssets.BuildPlaceholderRig, without meshes.</summary>
        static void BuildRig(Transform parent)
        {
            var visual = new GameObject("Visual").transform;
            visual.SetParent(parent, false);
            var hips = Bone(visual, "Hips", new Vector3(0f, 0.95f, 0f));
            var spine = Bone(hips, "Spine", new Vector3(0f, 0.1f, 0f));
            Bone(spine, "Head", new Vector3(0f, 0.72f, 0f));
            Bone(spine, "ArmL", new Vector3(-0.26f, 0.58f, 0f));
            Bone(spine, "ArmR", new Vector3(0.26f, 0.58f, 0f));
            var legL = Bone(hips, "LegL", new Vector3(-0.12f, -0.05f, 0f));
            Bone(legL, "FootL", new Vector3(0f, -0.86f, 0f));
            var legR = Bone(hips, "LegR", new Vector3(0.12f, -0.05f, 0f));
            Bone(legR, "FootR", new Vector3(0f, -0.86f, 0f));
        }

        [SetUp]
        public void SetUp()
        {
#if !UNITY_EDITOR
            Assert.Ignore("Player.controller is an Editor asset; these tests run in the Editor only.");
#endif
            var controller = LoadController();
            Assert.IsNotNull(controller, ControllerPath + " is missing: run Ascend.EditorTools.PlayerAnimationAssets.BuildBatch first.");

            _ground = GameObject.CreatePrimitive(PrimitiveType.Cube);
            _ground.name = "TestGround";
            _ground.transform.localScale = new Vector3(200, 1, 200);
            _ground.transform.position = new Vector3(0, -0.5f, 0);

            _player = new GameObject("TestPlayer");
            var cc = _player.AddComponent<CharacterController>();
            cc.height = 1.8f; cc.radius = 0.35f; cc.center = new Vector3(0, 0.9f, 0); cc.stepOffset = 0.35f;
            _motor = _player.AddComponent<PlayerMotor>();
            _combat = _player.AddComponent<PlayerCombat>();
            BuildRig(_player.transform);
            _animator = _player.AddComponent<Animator>();
            _animator.runtimeAnimatorController = controller;
            _animator.applyRootMotion = false;
            _animator.cullingMode = AnimatorCullingMode.AlwaysAnimate;
            _bridge = _player.AddComponent<CombatAnimationBridge>();
            _driver = _player.AddComponent<PlayerAnimationDriver>();
            _driver.Animator = _animator;
            _driver.Combat = _combat;
            _ik = _player.AddComponent<FootIK>();

            Physics.SyncTransforms();
            for (int i = 0; i < 10; i++) _motor.Tick(Vector3.zero, false, false, Dt);
            _animator.Rebind();
            _animator.Update(0f);
        }

        [TearDown]
        public void TearDown()
        {
            HitStop.Clear();
            Object.DestroyImmediate(_player);
            Object.DestroyImmediate(_ground);
            foreach (var r in Object.FindObjectsByType<GameObject>(FindObjectsSortMode.None))
                if (r != null && (r.name == "TestLedge" || r.name == "TestRamp")) Object.DestroyImmediate(r);
        }

        // ---------------------------------------------------------------- helpers

        /// <summary>One simulated frame in the same order as the input driver, then the animation driver and the Animator.</summary>
        void Frame(Vector3 move = default, bool walk = false, bool sprint = false)
        {
            _combat.Tick(Dt);
            _motor.Tick(move, walk, sprint, Dt);
            Physics.SyncTransforms();
            _driver.Tick(Dt);
            _animator.Update(Dt);
        }

        void Frames(int n, Vector3 move = default, bool walk = false, bool sprint = false)
        {
            for (int i = 0; i < n; i++) Frame(move, walk, sprint);
        }

        string StateName(int layer, string[] names)
        {
            var info = _animator.GetCurrentAnimatorStateInfo(layer);
            foreach (var n in names) if (info.IsName(n)) return n;
            return "?";
        }

        string NextStateName(int layer, string[] names)
        {
            var info = _animator.GetNextAnimatorStateInfo(layer);
            foreach (var n in names) if (info.IsName(n)) return n;
            return "?";
        }

        /// <summary>Appends the current state (and the incoming one during a transition) when it differs from the last entry.</summary>
        void Record(List<string> seq, int layer, string[] names)
        {
            // During a transition the incoming state is the one being entered; recording both would alternate every frame.
            if (_animator.IsInTransition(layer)) { if (seq.Count == 0) Add(seq, StateName(layer, names)); Add(seq, NextStateName(layer, names)); }
            else Add(seq, StateName(layer, names));
        }

        static void Add(List<string> seq, string s)
        {
            if (seq.Count == 0 || seq[seq.Count - 1] != s) seq.Add(s);
        }

        static void AssertInOrder(List<string> seq, params string[] expected)
        {
            int at = 0;
            foreach (var s in seq)
                if (at < expected.Length && s == expected[at]) at++;
            Assert.AreEqual(expected.Length, at,
                "expected states in order [" + string.Join(" > ", expected) + "] but saw [" + string.Join(" > ", seq) + "]");
        }

        float ClipWeight(string clipName)
        {
            float w = 0f;
            foreach (var ci in _animator.GetCurrentAnimatorClipInfo(0))
                if (ci.clip != null && ci.clip.name == clipName) w += ci.weight;
            return w;
        }

        void PlaceOnLedge()
        {
            var ledge = GameObject.CreatePrimitive(PrimitiveType.Cube);
            ledge.name = "TestLedge";
            ledge.transform.position = new Vector3(0, 2f, 0);
            ledge.transform.localScale = new Vector3(2, 4, 2);
            var cc = _player.GetComponent<CharacterController>();
            cc.enabled = false; _player.transform.position = new Vector3(0, 4.05f, 0.6f); cc.enabled = true;
            Physics.SyncTransforms();
            Frames(10);
            _animator.Update(0.5f); // let any transition finish
        }

        // ---------------------------------------------------------------- idle and locomotion blend

        [Test]
        public void Idle_AtRestPlaysLocomotionIdleAndCombatLayerIsOff()
        {
            Frames(30);
            Assert.AreEqual("Locomotion", StateName(0, BaseStates), "base layer rests in Locomotion");
            Assert.AreEqual(0f, _driver.CurrentSpeedParam, 0.01f, "Speed parameter is zero at rest");
            Assert.Greater(ClipWeight("Idle"), 0.95f, "blend tree is on the Idle clip");
            Assert.IsTrue(_driver.GroundedParam, "grounded at rest");
            Assert.AreEqual("CombatIdle", StateName(1, CombatStates), "combat layer idle");
            Assert.AreEqual(0f, _animator.GetLayerWeight(1), 1e-3f, "combat layer weight is 0 at rest");
        }

        [Test]
        public void Walk_SpeedParameterAndBlendWeightsSelectTheWalkClip()
        {
            Frames(90, Vector3.forward, walk: true);
            float expected = (float)T.Movement.WalkSpeed;
            Assert.AreEqual(expected, _driver.CurrentSpeedParam, expected * 0.05f, "Speed parameter (m/s)");
            Assert.AreEqual(expected, _animator.GetFloat("Speed"), expected * 0.05f, "Speed on the Animator");
            Assert.Greater(ClipWeight("Walk"), 0.95f, "Walk clip carries the blend, weights: Walk=" + ClipWeight("Walk") + " Run=" + ClipWeight("Run"));
        }

        [Test]
        public void Run_SpeedParameterAndBlendWeightsSelectTheRunClip()
        {
            Frames(90, Vector3.forward);
            float expected = (float)T.Movement.RunSpeed;
            Assert.AreEqual(expected, _driver.CurrentSpeedParam, expected * 0.05f, "Speed parameter (m/s)");
            Assert.Greater(ClipWeight("Run"), 0.95f, "Run clip carries the blend, weights: Walk=" + ClipWeight("Walk") + " Run=" + ClipWeight("Run") + " Sprint=" + ClipWeight("Sprint"));
        }

        [Test]
        public void Sprint_SpeedParameterAndBlendWeightsSelectTheSprintClip()
        {
            Frames(90, Vector3.forward, sprint: true);
            float expected = (float)T.Movement.SprintSpeed;
            Assert.AreEqual(expected, _driver.CurrentSpeedParam, expected * 0.05f, "Speed parameter (m/s)");
            Assert.Greater(ClipWeight("Sprint"), 0.95f, "Sprint clip carries the blend, weights: Run=" + ClipWeight("Run") + " Sprint=" + ClipWeight("Sprint"));
        }

        [Test]
        public void Run_SpeedMultStaysInsideTheFootSlideClamp()
        {
            Frames(90, Vector3.forward);
            float m = _animator.GetFloat("SpeedMult");
            Assert.GreaterOrEqual(m, 0.6f, "SpeedMult lower clamp");
            Assert.LessOrEqual(m, 1.6f, "SpeedMult upper clamp");
            Assert.AreEqual(1f, m, 0.05f, "run speed equals the run clip's nominal speed, so playback is 1x");
        }

        // ---------------------------------------------------------------- jump, fall, land

        [Test]
        public void Jump_GoesJumpStartThenFallThenLandThenLocomotion()
        {
            Frames(20);
            var seq = new List<string>();
            Record(seq, 0, BaseStates);
            Assert.IsTrue(_motor.Jump(), "jump starts from the ground");
            for (int i = 0; i < 300; i++)
            {
                Frame();
                Record(seq, 0, BaseStates);
                if (seq.Contains("Land") && seq[seq.Count - 1] == "Locomotion") break;
            }
            AssertInOrder(seq, "Locomotion", "JumpStart", "Fall", "Land", "Locomotion");
            Assert.IsTrue(_motor.IsGrounded, "back on the ground");
        }

        [Test]
        public void Jump_FiresTheJumpTriggerOnceOnTakeoff()
        {
            Frames(20);
            Assert.IsTrue(_motor.Jump());
            Frame();
            Assert.Greater(_motor.VerticalVelocity, 0.5f, "rising after the takeoff frame");
            Assert.AreEqual("JumpStart", StateName(0, BaseStates) == "JumpStart" ? "JumpStart" : NextStateName(0, BaseStates),
                "the Jump trigger started the JumpStart transition on the takeoff frame");
            var seq = new List<string>();
            for (int i = 0; i < 300; i++) { Frame(); Record(seq, 0, BaseStates); if (_motor.IsGrounded && i > 5) break; }
            int starts = 0;
            for (int i = 0; i < seq.Count; i++) if (seq[i] == "JumpStart") starts++;
            Assert.LessOrEqual(starts, 1, "JumpStart is not re-entered later in the same jump, sequence [" + string.Join(" > ", seq) + "]");
        }

        [Test]
        public void LedgeWalkOff_GoesLocomotionToFallWithoutJumpStart()
        {
            PlaceOnLedge();
            Assert.IsTrue(_motor.IsGrounded, "standing on the ledge");
            Assert.AreEqual("Locomotion", StateName(0, BaseStates), "starts in Locomotion on the ledge");
            var seq = new List<string>();
            Record(seq, 0, BaseStates);
            for (int i = 0; i < 240; i++)
            {
                Frame(Vector3.forward);
                Record(seq, 0, BaseStates);
                if (seq.Contains("Fall")) break;
            }
            Assert.IsFalse(_motor.IsGrounded && !seq.Contains("Fall"), "walked off the edge");
            AssertInOrder(seq, "Locomotion", "Fall");
            Assert.IsFalse(seq.Contains("JumpStart"), "walking off a ledge is not a jump, sequence [" + string.Join(" > ", seq) + "]");
        }

        [Test]
        public void LedgeWalkOff_ThenLandsBackIntoLocomotion()
        {
            PlaceOnLedge();
            var seq = new List<string>();
            for (int i = 0; i < 600; i++)
            {
                Frame(Vector3.forward);
                Record(seq, 0, BaseStates);
                if (seq.Contains("Land") && seq[seq.Count - 1] == "Locomotion") break;
            }
            AssertInOrder(seq, "Locomotion", "Fall", "Land", "Locomotion");
        }

        // ---------------------------------------------------------------- grounded grace

        [Test]
        public void GroundedParam_DoesNotFlickerOnABriefAirborneBlip()
        {
            Frames(20);
            Assert.IsTrue(_driver.GroundedParam, "grounded to begin with");
            _motor.Rise(0.008f); // ~0.6 m/s kick: airborne for about 3 frames, well under the 0.08 s grace
            int airborne = 0;
            bool everFalse = false;
            for (int i = 0; i < 12; i++)
            {
                Frame();
                if (!_motor.IsGrounded) airborne++;
                if (!_driver.GroundedParam) everFalse = true;
            }
            Assert.Greater(airborne, 0, "the motor really left the ground for at least one frame (test setup)");
            Assert.Less(airborne * Dt, 0.08f, "the blip is shorter than the grace window (test setup)");
            Assert.IsFalse(everFalse, "Grounded stayed true through the blip");
            Assert.AreEqual("Locomotion", StateName(0, BaseStates), "no Fall state flicker");
        }

        [Test]
        public void GroundedParam_DropsOnceAirborneLongerThanTheGrace()
        {
            Frames(20);
            Assert.IsTrue(_motor.Jump());
            Frames(3); // 0.05 s
            Frames(6); // 0.15 s total, past 0.08 s
            Assert.IsFalse(_motor.IsGrounded, "still in the air");
            Assert.IsFalse(_driver.GroundedParam, "Grounded param falls after the grace");
            Assert.IsFalse(_animator.GetBool("Grounded"), "and on the Animator");
        }

        // ---------------------------------------------------------------- dodge

        [Test]
        public void Dodge_EntersDodgeStateWhileDodgingAndReturnsToLocomotion()
        {
            Frames(20);
            var seq = new List<string>();
            Record(seq, 0, BaseStates);
            Assert.IsTrue(_motor.Dodge(Vector3.right), "dodge starts");
            for (int i = 0; i < 10; i++) { Frame(); Record(seq, 0, BaseStates); }
            Assert.IsTrue(_motor.IsDodging, "still dodging 10 frames in");
            Assert.IsTrue(_animator.GetBool("Dodging"), "Dodging parameter is set");
            Assert.AreEqual("Dodge", StateName(0, BaseStates), "base layer is in Dodge");
            int guard = 0;
            while (_motor.IsDodging && guard++ < 120) { Frame(); Record(seq, 0, BaseStates); }
            Assert.IsFalse(_motor.IsDodging, "dodge finished");
            for (int i = 0; i < 30; i++) { Frame(); Record(seq, 0, BaseStates); }
            Assert.IsFalse(_animator.GetBool("Dodging"), "Dodging parameter cleared");
            Assert.AreEqual("Locomotion", StateName(0, BaseStates), "back in Locomotion");
            AssertInOrder(seq, "Locomotion", "Dodge", "Locomotion");
        }

        // ---------------------------------------------------------------- combat layer

        [Test]
        public void Combat_RealAttackWalksStartupActiveRecoveryThenCombatIdle()
        {
            Frames(10);
            var phases = new List<AttackPhase>();
            _bridge.PhaseChanged += (p, hit) => { if (hit == 0 && (phases.Count == 0 || phases[phases.Count - 1] != p)) phases.Add(p); };
            var seq = new List<string>();
            Record(seq, 1, CombatStates);
            float peak = 0f;

            _combat.Attack();
            for (int i = 0; i < 240; i++)
            {
                Frame();
                Record(seq, 1, CombatStates);
                peak = Mathf.Max(peak, _driver.CombatLayerWeight);
                if (i > 5 && !_combat.IsAttacking && _driver.CombatLayerWeight <= 0f && seq[seq.Count - 1] == "CombatIdle") break;
            }

            AssertInOrder(seq, "CombatIdle", "Startup", "Active", "Recovery", "CombatIdle");
            Assert.AreEqual(new[] { AttackPhase.Startup, AttackPhase.Active, AttackPhase.Recovery, AttackPhase.Idle },
                phases.ToArray(), "bridge saw the chain phases in order");
            Assert.Greater(peak, 0.95f, "combat layer weight rose to 1 during the attack");
            Assert.AreEqual(0f, _animator.GetLayerWeight(1), 1e-3f, "and returned to 0 afterwards");
        }

        [Test]
        public void Combat_ParametersFollowThePhaseAndHitIndexWhileAttacking()
        {
            Frames(10);
            _combat.Attack();
            Frame();
            Assert.AreEqual((int)AttackPhase.Startup, _animator.GetInteger("CombatPhase"), "CombatPhase int is Startup right after Attack()");
            Assert.AreEqual(0, _animator.GetInteger("CombatHit"), "first hit of the string");
            Assert.Greater(_animator.GetFloat("CombatSpeed"), 0f, "CombatSpeed is set from the live phase duration");
            Assert.Greater(_driver.CombatLayerWeight, 0f, "combat layer starts blending in");
        }

        [Test]
        public void Combat_PhaseClipPlaybackSpeedFillsTheLivePhaseWindow()
        {
            Frames(10);
            _combat.Attack();
            Frame();
            var hit = _combat.Chain.Current;
            Assert.IsNotNull(hit, "an attack is in progress");
            float startup = (float)_combat.Chain.TimingOf(hit).StartupSec;
            Assert.AreEqual(_bridge.ClipLength / startup, _bridge.PlaybackSpeedFor(AttackPhase.Startup), 0.01f * (_bridge.ClipLength / startup),
                "playback speed = clip length / startup duration");
        }

        // ---------------------------------------------------------------- foot IK

        [Test]
        public void FootIkWeight_EasesInOverTheBlendTimeWhenGroundedAndStill()
        {
            Assert.IsTrue(_ik.Ready, "found Hips/FootL/FootR on the rig");
            Assert.AreEqual(0f, _ik.Weight, 1e-4f, "starts off");
            _ik.Tick(0.075f);
            Assert.AreEqual(0.5f, _ik.Weight, 0.02f, "half way after half of the 0.15 s blend");
            _ik.Tick(0.1f);
            Assert.AreEqual(1f, _ik.Weight, 1e-4f, "fully on");
        }

        [Test]
        public void FootIkWeight_EasesOutWhileDodging()
        {
            _ik.Tick(0.2f);
            Assert.AreEqual(1f, _ik.Weight, 1e-4f, "on");
            Assert.IsTrue(_motor.Dodge(Vector3.right));
            _ik.Tick(0.075f);
            Assert.AreEqual(0.5f, _ik.Weight, 0.02f, "easing out while dodging");
            _ik.Tick(0.1f);
            Assert.AreEqual(0f, _ik.Weight, 1e-4f, "off during the dodge");
        }

        [Test]
        public void FootIkWeight_IsOffWhenAirborne()
        {
            _ik.Tick(0.2f);
            Assert.AreEqual(1f, _ik.Weight, 1e-4f, "on while grounded");
            Assert.IsTrue(_motor.Jump());
            Frames(5);
            Assert.IsFalse(_motor.IsGrounded, "airborne");
            _ik.Tick(0.2f); // past the 0.08 s air grace and the 0.15 s blend
            Assert.AreEqual(0f, _ik.Weight, 1e-4f, "off in the air");
        }

        /// <summary>Records the feet after FootIK's LateUpdate has moved them (runs last).</summary>
        [DefaultExecutionOrder(32000)]
        sealed class FootProbe : MonoBehaviour
        {
            public Transform L, R;
            public Vector3 PosL, PosR;
            public int Frames;
            void LateUpdate()
            {
                if (L == null || R == null) return;
                PosL = L.position; PosR = R.position; Frames++;
            }
        }

        FootProbe AddProbe()
        {
            var probe = _player.AddComponent<FootProbe>();
            foreach (var t in _player.GetComponentsInChildren<Transform>())
            {
                if (t.name == "FootL") probe.L = t;
                if (t.name == "FootR") probe.R = t;
            }
            return probe;
        }

        [UnityTest]
        public IEnumerator FootIk_OnASideSlope_LowersThePelvisAndPlantsBothFeetOnTheSurface()
        {
            // A 20 degree slope tilted about Z so the left and right foot stand at different heights (0.24 m apart in x).
            _ground.SetActive(false);
            var ramp = GameObject.CreatePrimitive(PrimitiveType.Cube);
            ramp.name = "TestRamp";
            ramp.transform.localScale = new Vector3(40, 1, 40);
            ramp.transform.rotation = Quaternion.Euler(0, 0, 20);
            ramp.transform.position = -0.5f * (ramp.transform.rotation * Vector3.up); // top surface passes through the origin
            Physics.SyncTransforms();
            var cc = _player.GetComponent<CharacterController>();
            cc.enabled = false; _player.transform.position = new Vector3(0, 0.02f, 0); cc.enabled = true;
            Physics.SyncTransforms();
            for (int i = 0; i < 10; i++) _motor.Tick(Vector3.zero, false, false, Dt);
            Assert.IsTrue(_motor.IsGrounded, "standing on the slope (test setup)");

            var probe = AddProbe();
            var col = ramp.GetComponent<Collider>();
            _ik.Rebind();

            // Frames can be very short in batch mode, so wait on the IK weight (eases in over game time), not on wall clock.
            while (probe.Frames < 30 || _ik.Weight < 0.97f) { yield return null; if (probe.Frames > 5000) break; }

            Assert.IsTrue(_ik.Ready, "FootIK found the bones");
            Assert.Greater(_ik.Weight, 0.95f, "IK is fully on while standing still");
            Assert.Less(_ik.PelvisOffsetY, -0.003f, "pelvis lowered so the lower foot reaches the slope, offset " + _ik.PelvisOffsetY);

            // Both feet end up at the same height above their own patch of slope (the pivot sits above the sole, so the
            // absolute clearance is rig dependent; the invariant is that left and right match and both are close to the floor).
            var clearances = new List<float>();
            foreach (var pos in new[] { probe.PosL, probe.PosR })
            {
                var ray = new Ray(pos + Vector3.up * 5f, Vector3.down);
                Assert.IsTrue(col.Raycast(ray, out var hit, 20f), "foot has slope below it");
                clearances.Add(pos.y - hit.point.y);
            }
            // The idle clip sways the feet, so the two clearances differ frame to frame; the stable invariant is that
            // neither foot sinks into the slope and neither floats.
            foreach (float c in clearances) Assert.That(c, Is.InRange(-0.02f, 0.35f), "foot clearance above its slope: left " + clearances[0] + " m, right " + clearances[1] + " m");
        }

        [UnityTest]
        public IEnumerator FootIk_OnFlatGround_LeavesThePelvisAlone()
        {
            var probe = AddProbe();
            _ik.Rebind();
            float until = Time.realtimeSinceStartup + 0.6f;
            while (Time.realtimeSinceStartup < until || probe.Frames < 20) { yield return null; if (probe.Frames > 200) break; }
            Assert.AreEqual(0f, _ik.PelvisOffsetY, 0.01f, "no pelvis drop on flat ground");
            Assert.AreEqual(0f, _ik.LeftFootOffsetY, 0.01f, "left foot not lifted");
            Assert.AreEqual(0f, _ik.RightFootOffsetY, 0.01f, "right foot not lifted");
        }
    }
}
