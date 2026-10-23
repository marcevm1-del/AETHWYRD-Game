using UnityEngine;
using UnityEngine.InputSystem;

namespace Ascend.Game
{
    /// <summary>
    /// Lock-on (combat.md §2, controls R3 / middle mouse): picks the best monster in view, flick the right stick or
    /// mouse to switch, keeps the lock for a grace period while the target is hidden, and releases it on death or
    /// beyond range. The camera keeps the target framed; the player faces it while not sprinting; the soft-lock
    /// prefers it.
    /// </summary>
    [RequireComponent(typeof(PlayerMotor))]
    public sealed class LockOn : MonoBehaviour
    {
        public const float Range = 18f, ReleaseRange = 24f, GraceSec = 1.0f, FlickMouse = 25f, FlickStick = 0.8f, SwitchCooldown = 0.3f;

        PlayerMotor _motor;
        PlayerCombat _combat;
        float _hiddenFor, _switchReady;

        public MonsterDummy Target { get; private set; }
        public bool IsLocked => Target != null;

        void Awake()
        {
            _motor = GetComponent<PlayerMotor>();
            _combat = GetComponent<PlayerCombat>();
        }

        public void Toggle()
        {
            if (IsLocked) Release();
            else Set(FindBest(null, 0));
        }

        /// <summary>Switch to the nearest target on the given side (-1 left, +1 right) of the current one.</summary>
        public bool Switch(int side)
        {
            if (!IsLocked) return false;
            var next = FindBest(Target, side);
            if (next == null) return false;
            Set(next);
            return true;
        }

        public void Release() => Set(null);

        void Set(MonsterDummy t)
        {
            Target = t;
            _hiddenFor = 0f;
            if (_combat != null) _combat.LockTarget = t;
            if (t == null) _motor.FaceDirection = null;
        }

        MonsterDummy FindBest(MonsterDummy from, int side)
        {
            var cam = Camera.main;
            Vector3 fwd = cam != null ? cam.transform.forward : transform.forward; fwd.y = 0; fwd.Normalize();
            Vector3 right = Vector3.Cross(Vector3.up, fwd);
            Vector3 origin = from != null ? from.transform.position : transform.position;
            MonsterDummy best = null; float bestScore = float.MaxValue;
            foreach (var m in FindObjectsByType<MonsterDummy>(FindObjectsSortMode.None))
            {
                if (m == null || m.IsDead || m == from) continue;
                Vector3 to = m.transform.position - transform.position; to.y = 0;
                float dist = to.magnitude;
                if (dist > Range) continue;
                float score;
                if (side == 0)
                {
                    float angle = Vector3.Angle(fwd, to);
                    if (angle > 70f) continue;
                    score = dist + angle * 0.08f;
                }
                else
                {
                    Vector3 rel = m.transform.position - origin; rel.y = 0;
                    float lateral = Vector3.Dot(rel, right) * side;
                    if (lateral <= 0.2f) continue;
                    score = lateral + Mathf.Abs(Vector3.Dot(rel, fwd)) * 0.5f;
                }
                if (score < bestScore) { bestScore = score; best = m; }
            }
            return best;
        }

        void Update()
        {
            if (!IsLocked) return;
            Vector3 to = Target.transform.position - transform.position; to.y = 0;
            if (Target.IsDead || to.magnitude > ReleaseRange) { Release(); return; }

            // Grace period while the target is hidden behind something.
            var cam = Camera.main;
            if (cam != null)
            {
                Vector3 eye = cam.transform.position, aim = Target.transform.position + Vector3.up * 0.5f;
                bool hidden = Physics.Linecast(eye, aim, out var hit, ~0, QueryTriggerInteraction.Ignore)
                    && hit.collider.GetComponentInParent<MonsterDummy>() != Target && !hit.collider.transform.IsChildOf(transform);
                _hiddenFor = hidden ? _hiddenFor + Time.unscaledDeltaTime : 0f;
                if (_hiddenFor > GraceSec) { Release(); return; }
            }

            _motor.FaceDirection = to.sqrMagnitude > 0.01f ? to : (Vector3?)null;

            // Flick to switch.
            if (Time.unscaledTime < _switchReady) return;
            float x = 0f;
            if (Mouse.current != null) x = Mouse.current.delta.ReadValue().x / FlickMouse;
            if (Gamepad.current != null) { float s = Gamepad.current.rightStick.ReadValue().x / FlickStick; if (Mathf.Abs(s) > Mathf.Abs(x)) x = s; }
            if (Mathf.Abs(x) >= 1f && Switch(x > 0 ? 1 : -1)) _switchReady = Time.unscaledTime + SwitchCooldown;
        }
    }
}
