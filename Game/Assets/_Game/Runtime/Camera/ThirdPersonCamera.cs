using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Ascend.Game
{
    /// <summary>
    /// Over-the-shoulder camera (combat.md §2): mouse / right stick orbit, distance and FOV from combat_tuning.json, a shoulder
    /// offset (V swaps shoulder), damped follow, collision that pulls in fast and eases out slowly, a group pull-back when
    /// several monsters are engaged, and a mouse orbit around the target framing while locked on. Cinemachine cinematics later.
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

        // Over-the-shoulder state (numbers live in combat_tuning.json camera / lockOn).
        Ascend.Core.CameraTuning _cam;
        Ascend.Core.LockOnTuning _lockTuning;
        float _side = 1f;                       // +1 right shoulder, -1 left
        float _sideView = 1f;                   // eased so a swap glides
        float _yawView, _pitchView, _distView;  // damped values the camera is actually placed with
        Vector3 _pivotView;
        bool _placed;
        float _groupDist;                       // eased group pull-back distance
        float _lockYawOffset, _lockIdle;        // mouse orbit around the lock framing
        int _lockVersion = -1;

        /// <summary>The look bindings' processor strings (tests check they are culture-proof).</summary>
        public string LookProcessors => _look == null ? "" : string.Join("|", System.Linq.Enumerable.Select(_look.bindings, b => b.processors));
        LockOn _lock;

        public Transform Target { get => target; set => target = value; }

        /// <summary>Swings the camera straight behind the target (respawns, review shots).</summary>
        public void SnapBehind() { if (target != null) { _yaw = target.eulerAngles.y; Place(); } }

        /// <summary>Swaps the shoulder the camera sits over (also bound to V; PlayerInputDriver has no free slot).</summary>
        public void SwapShoulder() => _side = -_side;

        void Awake()
        {
            var t = _cam = AscendData.Db.Tuning.Camera;
            _lockTuning = AscendData.Db.Tuning.LockOn;
            _side = t.ShoulderOffset < 0 ? -1f : 1f;
            _sideView = _side;
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
            if (!WorldMapWindow.IsOpen && Keyboard.current != null && Keyboard.current.vKey.wasPressedThisFrame) SwapShoulder();
            if (_lock == null) _lock = target.GetComponent<LockOn>();
            if (_lock != null && _lock.IsLocked)
            {
                if (_lock.Version != _lockVersion) { _lockVersion = _lock.Version; _lockYawOffset = 0f; _lockIdle = 0f; }
                // Frame the target; the mouse orbits within a limited range around that framing (a fast flick switches target instead).
                Vector3 to = _lock.Target.transform.position - target.position; to.y = 0;
                float lockYaw = to.sqrMagnitude > 0.01f ? Quaternion.LookRotation(to).eulerAngles.y : _yaw;
                if (!stick && Mathf.Abs(d.x) > 0.001f)
                {
                    _lockYawOffset = (float)Ascend.Core.CameraMath.ClampYawOffset(_lockYawOffset + d.x, _lockTuning.MouseYawRangeDeg);
                    _lockIdle = 0f;
                }
                else
                {
                    _lockIdle += Time.unscaledDeltaTime;
                    if (_lockTuning.RecenterSec > 0 && _lockIdle > _lockTuning.RecenterSec)
                        _lockYawOffset = Mathf.MoveTowards(_lockYawOffset, 0f, (float)_lockTuning.MouseYawRangeDeg * Time.unscaledDeltaTime);
                }
                _yaw = Mathf.MoveTowardsAngle(_yaw, lockYaw + _lockYawOffset, 300f * Time.unscaledDeltaTime);
                float pitchWant = !stick && Mathf.Abs(d.y) > 0.001f ? Mathf.Clamp(_pitch - d.y, minPitch, maxPitch) : 18f;
                _pitch = Mathf.MoveTowards(_pitch, pitchWant, 60f * Time.unscaledDeltaTime);
            }
            else
            {
                _lockVersion = -1; _lockYawOffset = 0f;
                _yaw += d.x;
                _pitch = Mathf.Clamp(_pitch - d.y, minPitch, maxPitch);
            }
            PlaceDamped(Time.unscaledDeltaTime);
        }

        /// <summary>Monsters fighting within 20 m (the controller registry: no scene scan).</summary>
        int EngagedCount()
        {
            int n = 0; float r2 = 20f * 20f;
            foreach (var m in MonsterController.Registry)
            {
                if (m == null || m.Brain == null) continue;
                var st = m.Brain.State;
                if (st == Ascend.Core.AiState.Idle || st == Ascend.Core.AiState.Return || st == Ascend.Core.AiState.Flee) continue;
                var body = m.GetComponent<MonsterDummy>();
                if (body != null && body.IsDead) continue;
                if ((m.transform.position - target.position).sqrMagnitude <= r2) n++;
            }
            return n;
        }

        /// <summary>Positions the camera instantly, no damping (editor preview, respawns, review shots).</summary>
        public void Place() { _placed = false; PlaceDamped(0f); }

        void PlaceDamped(float dt)
        {
            var c = _cam ?? new Ascend.Core.CameraTuning();
            bool snap = !_placed || dt <= 0f;
            float baseDist = _distance > 0 ? _distance : 4.5f;
            float wantGroup = (float)Ascend.Core.CameraMath.GroupDistance(snap ? 0 : EngagedCount(), c.GroupEngagedCount, baseDist, c.GroupPullBackDistance);
            _groupDist = snap ? wantGroup : (float)Ascend.Core.CameraMath.Damp(_groupDist, wantGroup, c.GroupLagSec, dt);

            _sideView = snap ? _side : Mathf.MoveTowards(_sideView, _side, 6f * dt);
            Vector3 pivotWant = target.position + Vector3.up * (targetHeight + (float)c.HeightOffset);
            if (snap) { _pivotView = pivotWant; _yawView = _yaw; _pitchView = _pitch; }
            else
            {
                _pivotView = Vector3.Lerp(_pivotView, pivotWant, (float)Ascend.Core.CameraMath.DampFactor(c.FollowLagSec, dt));
                _yawView = (float)Ascend.Core.CameraMath.DampAngle(_yawView, _yaw, c.AngleLagSec, dt);
                _pitchView = (float)Ascend.Core.CameraMath.Damp(_pitchView, _pitch, c.AngleLagSec, dt);
            }

            var rot = Quaternion.Euler(_pitchView, _yawView, 0);
            // The pivot slides to the shoulder, so camera forward (the aim and soft-lock line) stays parallel to the view
            // direction and the character frames in the left third. Keep that point out of walls: pull it toward the head.
            Vector3 head = _pivotView;
            Vector3 anchor = head + rot * Vector3.right * (Mathf.Abs((float)c.ShoulderOffset) * _sideView);
            if (Physics.Linecast(head, anchor, out var sh, collisionMask, QueryTriggerInteraction.Ignore)
                && sh.transform != target && !sh.transform.IsChildOf(target))
                anchor = head + (anchor - head).normalized * Mathf.Max(0f, sh.distance - collisionRadius);

            float dist = _groupDist;
            Vector3 back = rot * Vector3.back;
            if (Physics.SphereCast(anchor, collisionRadius, back, out var hit, dist, collisionMask, QueryTriggerInteraction.Ignore)
                && hit.transform != target && !hit.transform.IsChildOf(target))
                dist = Mathf.Max(0.5f, hit.distance);
            // Pull in fast, ease back out slowly; never end up behind the wall.
            _distView = snap ? dist : (float)Ascend.Core.CameraMath.DampDistance(_distView, dist, c.CollisionInLagSec, c.CollisionOutLagSec, dt);
            _distView = Mathf.Min(_distView, dist);
            _placed = true;
            transform.SetPositionAndRotation(anchor + back * _distView + rot * CameraShake.Offset, rot);
        }

        public void SetAngles(float yaw, float pitch, float distance) { _yaw = yaw; _pitch = pitch; _distance = distance; _placed = false; }
    }
}
