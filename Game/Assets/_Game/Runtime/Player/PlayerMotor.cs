using Ascend.Core;
using UnityEngine;

namespace Ascend.Game
{
    /// <summary>
    /// Ring 0 movement (12_Systems/combat.md §3): walk/run/sprint, jump, dodge with i-frames, stamina.
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

        public Vector3 HorizontalVelocity => new Vector3(_velocity.x, 0, _velocity.z);
        /// <summary>Real time (unscaled) when the current dodge began, or null when not dodging (for perfect-dodge judging).</summary>
        public double? DodgeStartedAt => IsDodging ? _dodgeStartedAt : (double?)null;
        double _dodgeStartedAt;

        void Awake()
        {
            _cc = GetComponent<CharacterController>();
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
                bool canSprint = sprint && moveWorld.sqrMagnitude > 0.01f && Stamina > 0f;
                float speed = (float)(walk ? _move.WalkSpeed : canSprint ? _move.SprintSpeed : _move.RunSpeed);
                if (canSprint) UseStamina((float)_move.SprintStaminaPerSec * dt);
                _velocity.x = moveWorld.x * speed;
                _velocity.z = moveWorld.z * speed;
                Vector3 face = FaceDirection ?? moveWorld; face.y = 0;
                if (face.sqrMagnitude > 0.0001f && (FaceDirection.HasValue || moveWorld.sqrMagnitude > 0.0001f))
                {
                    var look = Quaternion.LookRotation(face, Vector3.up);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, look, turnSpeedDeg * dt);
                }
                if (IsGrounded) _dodgeChain = 0;
            }

            if (_sinceStaminaUse > staminaRegenDelay) Stamina = Mathf.Min(maxStamina, Stamina + staminaRegenPerSec * dt);

            if (IsGrounded && _velocity.y < 0) _velocity.y = -2f; // stick to the ground
            bool hanging = Hang && !IsGrounded;
            _velocity.y += gravity * (hanging ? 0.12f : 1f) * dt;
            if (hanging && _velocity.y < -1f) _velocity.y = -1f;
            _cc.Move(_velocity * dt);
        }

        /// <summary>Kicks the character upward (a jump-cancel after a launcher), even if a jump just began.</summary>
        public void Rise(float height) => _velocity.y = Mathf.Max(_velocity.y, Mathf.Sqrt(height * -2f * gravity));

        /// <summary>Drives the character straight down (an air slam).</summary>
        public void Plunge(float speed) => _velocity.y = -Mathf.Abs(speed);

        public bool Jump()
        {
            if (!IsGrounded || IsDodging || _velocity.y > 0f) return false; // grounded flag lags until the next Move
            _velocity.y = Mathf.Sqrt((float)_move.JumpHeight * -2f * gravity);
            return true;
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

        /// <summary>Gives stamina back (a perfect dodge refunds its cost: free defense).</summary>
        public void RefundStamina(float amount) => Stamina = Mathf.Min(maxStamina, Stamina + Mathf.Max(0f, amount));

        void UseStamina(float amount)
        {
            Stamina = Mathf.Max(0f, Stamina - amount);
            _sinceStaminaUse = 0f;
        }
    }
}
