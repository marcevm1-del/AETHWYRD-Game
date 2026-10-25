using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Ascend.Game
{
    /// <summary>
    /// Ring 0 orbit camera (combat.md §2): mouse / right stick orbit, distance and FOV from combat_tuning.json,
    /// pulls in when terrain is in the way. Lock-on and Cinemachine cinematics come in Ring 0 week 7.
    /// </summary>
    [RequireComponent(typeof(Camera))]
    public sealed class ThirdPersonCamera : MonoBehaviour
    {
        [SerializeField] Transform target;
        [SerializeField] float targetHeight = 1.4f;
        [SerializeField] float mouseSensitivity = 0.12f;
        [SerializeField] float stickSensitivity = 180f;
        [SerializeField] float minPitch = -35f, maxPitch = 70f;
        [SerializeField] float collisionRadius = 0.25f;
        [SerializeField] LayerMask collisionMask = ~0;

        float _yaw, _pitch = 15f, _distance;
        InputAction _look;

        /// <summary>The look bindings' processor strings (tests check they are culture-proof).</summary>
        public string LookProcessors => _look == null ? "" : string.Join("|", System.Linq.Enumerable.Select(_look.bindings, b => b.processors));
        LockOn _lock;

        public Transform Target { get => target; set => target = value; }

        /// <summary>Swings the camera straight behind the target (respawns, review shots).</summary>
        public void SnapBehind() { if (target != null) { _yaw = target.eulerAngles.y; Place(); } }

        void Awake()
        {
            var t = AscendData.Db.Tuning.Camera;
            _distance = (float)t.Distance;
            GetComponent<Camera>().fieldOfView = (float)t.Fov;
            _look = new InputAction("Look", InputActionType.Value);
            // Invariant culture: on comma-decimal systems "0,12" would break the processor string (and mouse look).
            _look.AddBinding("<Mouse>/delta").WithProcessor(FormattableString.Invariant($"scaleVector2(x={mouseSensitivity},y={mouseSensitivity})"));
            _look.AddBinding("<Gamepad>/rightStick").WithProcessor(FormattableString.Invariant($"scaleVector2(x={stickSensitivity},y={stickSensitivity})"));
            if (target != null) { _yaw = target.eulerAngles.y; _lock = target.GetComponent<LockOn>(); }
        }

        void OnEnable() { _look.Enable(); if (Application.isPlaying) Cursor.lockState = CursorLockMode.Locked; }
        void OnDisable() { _look.Disable(); Cursor.lockState = CursorLockMode.None; }
        void OnDestroy() => _look.Dispose();

        void LateUpdate()
        {
            if (target == null) return;
            Vector2 d = WorldMapWindow.IsOpen ? Vector2.zero : _look.ReadValue<Vector2>(); // the map uses the mouse
            bool stick = Gamepad.current != null && Gamepad.current.rightStick.ReadValue().sqrMagnitude > 0.01f;
            if (stick) d *= Time.deltaTime; // stick is a rate, mouse is a delta
            if (_lock == null) _lock = target.GetComponent<LockOn>();
            if (_lock != null && _lock.IsLocked)
            {
                // Keep the target framed: swing behind the player toward it (mouse flicks switch targets instead).
                Vector3 to = _lock.Target.transform.position - target.position; to.y = 0;
                if (to.sqrMagnitude > 0.01f)
                    _yaw = Mathf.MoveTowardsAngle(_yaw, Quaternion.LookRotation(to).eulerAngles.y, 300f * Time.unscaledDeltaTime);
                _pitch = Mathf.MoveTowards(_pitch, 18f, 60f * Time.unscaledDeltaTime);
            }
            else
            {
                _yaw += d.x;
                _pitch = Mathf.Clamp(_pitch - d.y, minPitch, maxPitch);
            }
            Place();
        }

        /// <summary>Positions the camera behind the target (also used by the editor preview).</summary>
        public void Place()
        {
            var pivot = target.position + Vector3.up * targetHeight;
            var rot = Quaternion.Euler(_pitch, _yaw, 0);
            float dist = _distance > 0 ? _distance : 4.5f;
            if (Physics.SphereCast(pivot, collisionRadius, rot * Vector3.back, out var hit, dist, collisionMask, QueryTriggerInteraction.Ignore)
                && hit.transform != target && !hit.transform.IsChildOf(target))
                dist = Mathf.Max(0.5f, hit.distance);
            transform.SetPositionAndRotation(pivot + rot * Vector3.back * dist + rot * CameraShake.Offset, rot);
        }

        public void SetAngles(float yaw, float pitch, float distance) { _yaw = yaw; _pitch = pitch; _distance = distance; }
    }
}
