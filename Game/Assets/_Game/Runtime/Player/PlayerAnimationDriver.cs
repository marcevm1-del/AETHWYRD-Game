using Ascend.Core;
using UnityEngine;

namespace Ascend.Game
{
    /// <summary>
    /// Feeds the player Animator (Game/Assets/_Game/Art/Animation/Player.controller) from the motor and combat state.
    /// It only reads: PlayerMotor, PlayerCombat and CombatAnimationBridge are never written to, so animation cannot
    /// change movement or hit timing. Numbers come from Data/Player/locomotion.json (LocomotionData.Table).
    ///
    /// Ticking: <see cref="Tick"/> is public so tests can drive it with a fixed dt; once anything calls it the
    /// driver stops self-ticking, otherwise it ticks itself in LateUpdate (after PlayerMotor/PlayerCombat Update).
    /// Tolerates a missing Animator, controller, PlayerCombat, PlayerDefense or bridge (bare test players): no-ops.
    ///
    /// Specials (heavy, riposte, launcher, slam, skill) run on a private chain the bridge cannot see, so while
    /// PlayerCombat.CurrentSpecial != None and the bridge phase is Idle the driver reports CombatPhase=Active (2)
    /// at CombatSpeed 1, which keeps the Combat layer up; the Special parameter carries the enum value.
    /// </summary>
    [DisallowMultipleComponent, RequireComponent(typeof(PlayerMotor))]
    public sealed class PlayerAnimationDriver : MonoBehaviour
    {
        /// <summary>Cached Animator parameter hashes (names match PlayerAnimationAssets).</summary>
        public static class AnimParams
        {
            public static readonly int Speed = Animator.StringToHash("Speed");
            public static readonly int Grounded = Animator.StringToHash("Grounded");
            public static readonly int VerticalVelocity = Animator.StringToHash("VerticalVelocity");
            public static readonly int Dodging = Animator.StringToHash("Dodging");
            public static readonly int Jump = Animator.StringToHash("Jump");
            public static readonly int CombatPhase = Animator.StringToHash("CombatPhase");
            public static readonly int CombatHit = Animator.StringToHash("CombatHit");
            public static readonly int Special = Animator.StringToHash("Special");
            public static readonly int Charging = Animator.StringToHash("Charging");
            public static readonly int SpeedMult = Animator.StringToHash("SpeedMult");
            public static readonly int CombatSpeed = Animator.StringToHash("CombatSpeed");
        }

        const int CombatLayer = 1;
        const float JumpRiseThreshold = 0.5f;
        const float SpeedMultMin = 0.6f, SpeedMultMax = 1.6f;

        public Animator Animator { get; set; }
        public PlayerCombat Combat { get; set; }

        /// <summary>Smoothed horizontal speed fed to the Speed parameter (m/s).</summary>
        public float CurrentSpeedParam { get; private set; }
        /// <summary>Grounded as sent to the Animator (raw motor state held for the exit grace).</summary>
        public bool GroundedParam { get; private set; } = true;
        /// <summary>Current Combat layer weight (0..1).</summary>
        public float CombatLayerWeight { get; private set; }

        PlayerMotor _motor;
        CombatAnimationBridge _bridge;
        LocomotionTable _table;
        bool _externallyTicked, _fetched, _tableTried, _ikTuned;
        bool _prevRawGrounded = true, _jumpFired;
        float _speedVel, _airTime;

        void Awake() { Fetch(); }

        void Start() { TuneFootIK(); }

        void LateUpdate()
        {
            if (!_externallyTicked) TickInternal(Time.deltaTime);
        }

        /// <summary>Advance one step. Called by tests (disables the LateUpdate self-tick).</summary>
        public void Tick(float dt)
        {
            _externallyTicked = true;
            TickInternal(dt);
        }

        void Fetch()
        {
            if (_motor == null) _motor = GetComponent<PlayerMotor>();
            if (Animator == null) Animator = GetComponent<Animator>();
            if (Combat == null) Combat = GetComponent<PlayerCombat>();
            if (_bridge == null) _bridge = GetComponent<CombatAnimationBridge>();
            _fetched = true;
        }

        LocomotionTable Table()
        {
            if (_table == null && !_tableTried)
            {
                _tableTried = true;
                try { _table = LocomotionData.Table; }
                catch (System.Exception e) { Debug.LogWarning($"PlayerAnimationDriver: locomotion table unavailable, using defaults ({e.Message})"); }
            }
            return _table;
        }

        void TuneFootIK()
        {
            if (_ikTuned) return;
            var ik = GetComponent<FootIK>();
            var t = Table();
            if (ik == null || t == null) { _ikTuned = true; return; }
            ik.SprintDisableSpeed = (float)t.Blend.SprintEnter;
            ik.PelvisSpeed = 1f / Mathf.Max(0.01f, (float)t.Damping.PelvisSec);
            _ikTuned = true;
        }

        void TickInternal(float dt)
        {
            if (!_fetched || _motor == null) Fetch();
            if (dt <= 0f) return;
            TuneFootIK();

            var t = Table();
            float speedSec = t != null ? (float)t.Damping.SpeedSec : 0.1f;
            float graceSec = t != null ? (float)t.Damping.GroundedExitGraceSec : 0.08f;
            float blendSec = t != null ? (float)t.Damping.CombatLayerBlendSec : 0.06f;

            // Motor state (read-only).
            float rawSpeed = _motor != null ? _motor.HorizontalVelocity.magnitude : 0f;
            float vy = _motor != null ? _motor.VerticalVelocity : 0f;
            bool rawGrounded = _motor == null || _motor.IsGrounded;
            bool dodging = _motor != null && _motor.IsDodging;

            CurrentSpeedParam = Mathf.Max(0f, Mathf.SmoothDamp(CurrentSpeedParam, rawSpeed, ref _speedVel, Mathf.Max(0.001f, speedSec), Mathf.Infinity, dt));
            if (CurrentSpeedParam < 0.001f && rawSpeed < 0.001f) CurrentSpeedParam = 0f;

            // Grounded with exit grace: a brief airborne frame does not flicker the Fall state.
            if (rawGrounded) _airTime = 0f; else _airTime += dt;
            GroundedParam = rawGrounded || _airTime < graceSec;

            // Jump trigger: rising while previously grounded, once per take-off.
            bool jump = false;
            if (!_jumpFired && _prevRawGrounded && vy > JumpRiseThreshold) { jump = true; _jumpFired = true; }
            if (rawGrounded && vy <= 0.01f) _jumpFired = false;
            _prevRawGrounded = rawGrounded;

            float speedMult = ComputeSpeedMult(CurrentSpeedParam, t);

            // Combat state (read-only).
            var bridge = _bridge;
            if (bridge != null) bridge.Tick(dt);
            var combat = Combat;
            AttackPhase phase = bridge != null ? bridge.Phase : AttackPhase.Idle;
            int hit = bridge != null ? bridge.HitIndex : 0;
            var special = combat != null ? combat.CurrentSpecial : PlayerCombat.Special.None;
            bool charging = combat != null && combat.IsCharging;
            int phaseParam = (int)phase;
            float combatSpeed = bridge != null ? bridge.PlaybackSpeedFor(phase) : 1f;
            if (special != PlayerCombat.Special.None && phase == AttackPhase.Idle) { phaseParam = (int)AttackPhase.Active; combatSpeed = 1f; }

            bool combatActive = charging || phaseParam != 0;
            CombatLayerWeight = Mathf.MoveTowards(CombatLayerWeight, combatActive ? 1f : 0f, dt / Mathf.Max(0.001f, blendSec));

            var a = Animator;
            if (a == null || a.runtimeAnimatorController == null) return;
            a.SetFloat(AnimParams.Speed, CurrentSpeedParam);
            a.SetFloat(AnimParams.SpeedMult, speedMult);
            a.SetBool(AnimParams.Grounded, GroundedParam);
            a.SetFloat(AnimParams.VerticalVelocity, vy);
            a.SetBool(AnimParams.Dodging, dodging);
            if (jump) a.SetTrigger(AnimParams.Jump);
            else if (GroundedParam) a.ResetTrigger(AnimParams.Jump); // a press during Land would otherwise fire late
            a.SetInteger(AnimParams.CombatPhase, phaseParam);
            a.SetInteger(AnimParams.CombatHit, hit);
            a.SetInteger(AnimParams.Special, (int)special);
            a.SetBool(AnimParams.Charging, charging);
            a.SetFloat(AnimParams.CombatSpeed, combatSpeed);
            if (a.layerCount > CombatLayer) a.SetLayerWeight(CombatLayer, CombatLayerWeight);
        }

        /// <summary>Foot-slide control: actual speed over the blend tree nominal speed (walk..sprint), clamped.</summary>
        static float ComputeSpeedMult(float speed, LocomotionTable t)
        {
            if (t == null || speed < 0.01f) return 1f;
            double walk = t.Speed("walk"), sprint = t.Speed("sprint");
            double nominal = System.Math.Max(walk, System.Math.Min(sprint, speed));
            return Mathf.Clamp(speed / (float)nominal, SpeedMultMin, SpeedMultMax);
        }
    }
}
