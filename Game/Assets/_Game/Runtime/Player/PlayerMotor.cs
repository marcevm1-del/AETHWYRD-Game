using Ascend.Core;
using UnityEngine;

namespace Ascend.Game
{
    /// <summary>
    /// Ring 0 movement (12_Systems/combat.md §3): walk/run/sprint, jump, dodge with i-frames, stamina.
    /// Feel (13_Production/movement_feel.md): short acceleration and deceleration, reduced air control, coyote time,
    /// a buffered jump, variable jump height (release early for a hop) and a faster fall than rise; a light stick
    /// tilt walks.
    /// All numbers come from Data/Combat/combat_tuning.json. Input-agnostic: call Tick from an input driver or a test.
    /// </summary>
    [RequireComponent(typeof(CharacterController))]
    public sealed class PlayerMotor : MonoBehaviour
    {
        [SerializeField] float gravity = -25f;          // snappier than real gravity (anime feel)
        [SerializeField] float turnSpeedDeg = 720f;
        [SerializeField] float maxStamina = 100f;
        [SerializeField] float staminaRegenPerSec = 30f;
        [SerializeField] float staminaRegenDelay = 0.8f;

        CharacterController _cc;
        MovementTuning _move;
        DodgeTuning _dodge;
        Vector3 _velocity;
        Vector3 _dodgeDir;
        float _dodgeTime = -1f;
        int _dodgeChain;
        float _sinceStaminaUse;
        float _sinceGrounded = 99f, _jumpBuffered = -1f;
        bool _jumpedThisAirtime;

        public float Stamina { get; private set; }
        public float MaxStamina => maxStamina;
        public bool IsGrounded => _cc != null && _cc.isGrounded;
        public bool IsDodging => _dodgeTime >= 0f;
        /// <summary>True during the dodge's i-frames: hits should be ignored.</summary>
        public bool IsInvulnerable => IsDodging && _dodgeTime < _dodge.IframeSec;
        /// <summary>Air-attack hang time: while true and airborne, gravity is cut and the fall is capped (anime juggles).</summary>
        public bool Hang { get; set; }
        /// <summary>Lock-on: face this world direction instead of the movement direction (null = face movement).</summary>
        public Vector3? FaceDirection { get; set; }
        public float VerticalVelocity => _velocity.y;
        /// <summary>Still allowed to jump: on the ground, or just walked off a ledge (coyote time).</summary>
        public bool CanJump => !IsDodging && !_jumpedThisAirtime && _velocity.y <= 0.01f && _sinceGrounded <= (float)_move.CoyoteSec;

        public Vector3 HorizontalVelocity => new Vector3(_velocity.x, 0, _velocity.z);
        /// <summary>Real time (unscaled) when the current dodge began, or null when not dodging (for perfect-dodge judging).</summary>
        public double? DodgeStartedAt => IsDodging ? _dodgeStartedAt : (double?)null;
        double _dodgeStartedAt;

        /// <summary>The tallest step the player walks up (the town kit has 0.4 m rises).</summary>
        public const float StepHeight = 0.45f;

        void Awake()
        {
            _cc = GetComponent<CharacterController>(); _cc.stepOffset = StepHeight;
            var t = AscendData.Db.Tuning;
            _move = t.Movement;
            _dodge = t.Dodge;
            Stamina = maxStamina;
        }

        /// <param name="moveWorld">Desired direction in world space (magnitude 0..1).</param>
        public void Tick(Vector3 moveWorld, bool walk, bool sprint, float dt)
        {
            moveWorld.y = 0;
            if (moveWorld.sqrMagnitude > 1f) moveWorld.Normalize();
            _sinceStaminaUse += dt;

            if (IsDodging)
            {
                _dodgeTime += dt;
                float speed = (float)(_dodge.Distance / _dodge.DurationSec);
                _velocity.x = _dodgeDir.x * speed;
                _velocity.z = _dodgeDir.z * speed;
                if (_dodgeTime >= _dodge.DurationSec) { _dodgeTime = -1f; }
            }
            else
            {
                float tilt = moveWorld.magnitude;
                bool lightTilt = tilt > 0.01f && tilt < (float)_move.WalkStickThreshold;
                bool canSprint = sprint && tilt > 0.01f && Stamina > 0f && !lightTilt;
                float speed = (float)(walk || lightTilt ? _move.WalkSpeed : canSprint ? _move.SprintSpeed : _move.RunSpeed);
                if (canSprint) UseStamina((float)_move.SprintStaminaPerSec * dt);
                Vector3 dir = tilt > 0.01f ? moveWorld / tilt : Vector3.zero;
                Vector3 target = dir * speed;
                Vector3 horiz = new Vector3(_velocity.x, 0f, _velocity.z);
                // Accelerate toward the target at a rate set by the time to reach run speed; stop faster than you start.
                bool stopping = target.sqrMagnitude < horiz.sqrMagnitude * 0.25f;
                float secs = (float)(stopping ? _move.DecelSec : _move.AccelSec);
                float rate = secs > 0f ? (float)_move.RunSpeed / secs : float.MaxValue;
                if (!IsGrounded) rate *= (float)_move.AirControl;
                horiz = Vector3.MoveTowards(horiz, target, rate * dt);
                _velocity.x = horiz.x;
                _velocity.z = horiz.z;
                Vector3 face = FaceDirection ?? moveWorld; face.y = 0;
                if (face.sqrMagnitude > 0.0001f && (FaceDirection.HasValue || moveWorld.sqrMagnitude > 0.0001f))
                {
                    var look = Quaternion.LookRotation(face, Vector3.up);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, look, turnSpeedDeg * dt);
                }
                if (IsGrounded) _dodgeChain = 0;
            }

            if (_sinceStaminaUse > staminaRegenDelay) Stamina = Mathf.Min(maxStamina, Stamina + staminaRegenPerSec * dt);

            if (IsGrounded && _velocity.y <= 0f) { _sinceGrounded = 0f; _jumpedThisAirtime = false; }
            else _sinceGrounded += dt;
            if (_jumpBuffered >= 0f)
            {
                if (CanJump) DoJump();
                else if ((_jumpBuffered += dt) > (float)_move.JumpBufferSec) _jumpBuffered = -1f;
            }

            if (IsGrounded && _velocity.y < 0) _velocity.y = -2f; // stick to the ground
            bool hanging = Hang && !IsGrounded;
            float fall = _velocity.y < 0f && !IsGrounded ? (float)_move.FallGravityMult : 1f;
            _velocity.y += gravity * (hanging ? 0.12f : fall) * dt;
            if (hanging && _velocity.y < -1f) _velocity.y = -1f;
            _cc.Move(_velocity * dt);
        }

        /// <summary>Kicks the character upward (a jump-cancel after a launcher), even if a jump just began.</summary>
        public void Rise(float height) => _velocity.y = Mathf.Max(_velocity.y, Mathf.Sqrt(height * -2f * gravity));

        /// <summary>Drives the character straight down (an air slam).</summary>
        public void Plunge(float speed) => _velocity.y = -Mathf.Abs(speed);

        /// <summary>Jumps now if possible (grounded or within coyote time); otherwise remembers the press for a moment so
        /// it fires on landing. Returns whether the jump happened now.</summary>
        public bool Jump()
        {
            if (CanJump) { DoJump(); return true; }
            _jumpBuffered = 0f;
            return false;
        }

        /// <summary>Jump button released: cut the rise short for a small hop.</summary>
        public void ReleaseJump()
        {
            _jumpBuffered = -1f;
            if (_jumpedThisAirtime && _velocity.y > 0f && !Hang) _velocity.y *= (float)_move.JumpCutMult;
        }

        void DoJump()
        {
            _velocity.y = Mathf.Sqrt((float)_move.JumpHeight * -2f * gravity);
            _jumpedThisAirtime = true;
            _jumpBuffered = -1f;
            _sinceGrounded = 99f;
        }

        /// <summary>Starts a dodge toward <paramref name="dirWorld"/> (backstep if zero). Costs stamina; chains up to MaxChain.</summary>
        public bool Dodge(Vector3 dirWorld)
        {
            if (IsDodging || _dodgeChain >= _dodge.MaxChain || Stamina < (float)_dodge.StaminaCost) return false;
            dirWorld.y = 0;
            _dodgeDir = dirWorld.sqrMagnitude > 0.01f ? dirWorld.normalized : -transform.forward;
            _dodgeTime = 0f;
            _dodgeStartedAt = Time.unscaledTimeAsDouble;
            _dodgeChain++;
            UseStamina((float)_dodge.StaminaCost);
            return true;
        }

        /// <summary>Moves the character by a world offset this frame (attack lunges, knockback), respecting collisions.</summary>
        public void Nudge(Vector3 worldOffset)
        {
            worldOffset.y = 0;
            if (worldOffset.sqrMagnitude <= 0f) return;
            // A purely sideways Move makes CharacterController report "not grounded"; keep contact while grounded.
            _cc.Move(worldOffset + (_cc.isGrounded ? Vector3.down * 0.05f : Vector3.zero));
        }

        /// <summary>True when a dodge could start now (not mid-dodge, chain and stamina allow it).</summary>
        public bool CanDodge => !IsDodging && _dodgeChain < _dodge.MaxChain && Stamina >= (float)_dodge.StaminaCost;

        /// <summary>Spends stamina (blocking drains it, combat.md section 5); regeneration pauses as for any use.</summary>
        public void DrainStamina(float amount) { if (amount > 0f) UseStamina(amount); }

        /// <summary>Gives stamina back (a perfect dodge refunds its cost: free defense).</summary>
        public void RefundStamina(float amount) => Stamina = Mathf.Min(maxStamina, Stamina + Mathf.Max(0f, amount));

        void UseStamina(float amount)
        {
            Stamina = Mathf.Max(0f, Stamina - amount);
            _sinceStaminaUse = 0f;
        }
    }
}
