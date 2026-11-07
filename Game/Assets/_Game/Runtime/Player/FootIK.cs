using UnityEngine;

namespace Ascend.Game
{
    /// <summary>
    /// Foot placement on uneven ground, with two paths (Wave A1, task T5).
    ///
    /// (a) Humanoid path: when the Animator has a humanoid Avatar, <see cref="OnAnimatorIK"/> sets the
    ///     foot IK goals and lowers the body. Needs "IK Pass" ticked on an Animator layer and this
    ///     component on the same GameObject as the Animator (Unity only calls OnAnimatorIK there).
    ///     UNTESTED until a humanoid import exists (the placeholder rig is Generic).
    /// (b) Generic path (the placeholder rig, no Avatar): in LateUpdate, after the Animator has posed
    ///     the bones, the Hips are lowered and the FootL / FootR transforms are lifted directly.
    ///
    /// Method (both paths): a ray is cast down at the root and at each animated foot. The height of the
    /// ground under a foot, relative to the ground under the root, is how far that foot must move.
    /// The pelvis drops by the lowest of those (never rises) so the lower foot can reach, then each foot
    /// is lifted by the remainder. Foot swing height from the animation is preserved because only the
    /// terrain difference is applied, not "snap to ground". Feet never end below ground + FootOffset
    /// (blended in by the weight). Feet tilt to the ground normal, clamped to 35 degrees.
    ///
    /// Off while dodging, airborne (0.08 s grace so a step does not flicker it) or running faster than
    /// SprintDisableSpeed; the weight eases in and out over 0.15 s. No per-frame allocation (a shared
    /// RaycastNonAlloc buffer). Missing feet or Hips: logs a warning once and stops. Missing Animator
    /// or PlayerMotor is tolerated (no motor means "always grounded, never dodging, standing").
    ///
    /// Limits: leg bones are not bent, so the Generic path just translates the foot transform (fine for
    /// the placeholder, wrong for a skinned humanoid, which uses path (a)). Ignores the player's own
    /// colliders by hierarchy. Trigger colliders are ignored.
    /// </summary>
    [DisallowMultipleComponent]
    public sealed class FootIK : MonoBehaviour
    {
        const float MaxFootAlignDeg = 35f;
        const float BlendSec = 0.15f;
        const float AirGraceSec = 0.08f;
        const float RayStartUp = 0.5f;
        const float MaxRaise = 0.5f;

        static readonly RaycastHit[] Hits = new RaycastHit[8];

        // ---- tuning (contract) ----
        public bool Enabled = true;
        public float RayLength = 1.2f;
        public float PelvisSpeed = 8f;
        public float FootOffset = 0.08f;
        public LayerMask GroundMask = ~0;

        /// <summary>Speed (m/s) above which IK is off. Mirrors locomotion.json blend.sprintEnter.</summary>
        public float SprintDisableSpeed = 8f;

        // ---- read-only state (tests) ----
        public float LeftFootOffsetY => _extraL;
        public float RightFootOffsetY => _extraR;
        public float PelvisOffsetY => _pelvis;
        public float Weight => _weight;
        /// <summary>True once bones/animator were found and the component can work.</summary>
        public bool Ready => _ready;
        public bool IsHumanoidPath => _humanoid;

        PlayerMotor _motor;
        Animator _animator;
        bool _humanoid, _ready, _warned, _resolved;
        float _weight, _airTime;
        float _pelvis, _extraL, _extraR;
        Vector3 _nL = Vector3.up, _nR = Vector3.up;
        float _minL = float.NegativeInfinity, _minR = float.NegativeInfinity; // lowest allowed foot y
        bool _hitL, _hitR;
        int _ikFrame = -1;

        Slot _hips, _footL, _footR;

        /// <summary>Tracks one bone so we can tell whether the Animator rewrote it this frame.</summary>
        sealed class Slot
        {
            public Transform T;
            public Vector3 AnimPos, WrittenPos;
            public Quaternion AnimRot, WrittenRot;
            public bool Wrote;

            public Slot(Transform t) { T = t; }

            /// <summary>Restore the bone to its animated pose (undoing last frame's IK if the Animator did not overwrite it).</summary>
            public void RestoreAnimated()
            {
                if (T == null) return;
                if (Wrote)
                {
                    bool untouchedPos = (T.localPosition - WrittenPos).sqrMagnitude < 1e-10f;
                    bool untouchedRot = Quaternion.Angle(T.localRotation, WrittenRot) < 0.001f;
                    if (untouchedPos) T.localPosition = AnimPos;
                    if (untouchedRot) T.localRotation = AnimRot;
                }
                Wrote = false;
                AnimPos = T.localPosition;
                AnimRot = T.localRotation;
            }

            public void MarkWritten()
            {
                WrittenPos = T.localPosition;
                WrittenRot = T.localRotation;
                Wrote = true;
            }
        }

        void Awake() { Resolve(); }

        /// <summary>Find the Animator, motor and (Generic path) bones again. Safe to call any time.</summary>
        public void Rebind()
        {
            _warned = false;
            _resolved = false;
            Resolve();
        }

        void Resolve()
        {
            _resolved = true;
            _ready = false;
            _motor = GetComponent<PlayerMotor>();
            if (_motor == null) _motor = GetComponentInParent<PlayerMotor>();
            _animator = GetComponent<Animator>();
            if (_animator == null) _animator = GetComponentInChildren<Animator>();

            _humanoid = _animator != null && _animator.isHuman;
            if (_humanoid) { _ready = true; return; }

            var all = GetComponentsInChildren<Transform>(true);
            Transform hips = Find(all, "Hips", "Pelvis", "mixamorig:Hips");
            Transform fl = Find(all, "FootL", "LeftFoot", "mixamorig:LeftFoot");
            Transform fr = Find(all, "FootR", "RightFoot", "mixamorig:RightFoot");
            if (hips == null || fl == null || fr == null)
            {
                if (!_warned)
                {
                    _warned = true;
                    Debug.LogWarning("[FootIK] " + name + ": Hips/FootL/FootR not found and no humanoid Avatar; foot IK disabled.");
                }
                return;
            }
            _hips = new Slot(hips);
            _footL = new Slot(fl);
            _footR = new Slot(fr);
            _ready = true;
        }

        static Transform Find(Transform[] all, params string[] names)
        {
            for (int n = 0; n < names.Length; n++)
                for (int i = 0; i < all.Length; i++)
                    if (all[i] != null && string.Equals(all[i].name, names[n], System.StringComparison.OrdinalIgnoreCase))
                        return all[i];
            return null;
        }

        /// <summary>Advance the on/off weight. Public so tests can drive it without a frame.</summary>
        public void Tick(float dt)
        {
            if (dt <= 0f) return;
            bool grounded = _motor == null || _motor.IsGrounded;
            _airTime = grounded ? 0f : _airTime + dt;

            bool active = Enabled && _ready;
            if (active && _motor != null)
            {
                if (_motor.IsDodging) active = false;
                else if (_airTime > AirGraceSec) active = false;
                else if (_motor.HorizontalVelocity.sqrMagnitude > SprintDisableSpeed * SprintDisableSpeed) active = false;
            }
            _weight = Mathf.MoveTowards(_weight, active ? 1f : 0f, dt / BlendSec);
        }

        // ------------------------------------------------------------------ Generic path

        void LateUpdate()
        {
            if (!_resolved) Resolve();
            if (!_ready || _humanoid) return;
            if (_hips.T == null || _footL.T == null || _footR.T == null) { _ready = false; return; }

            float dt = Time.deltaTime;
            Tick(dt);

            // Undo our last write (when the Animator did not overwrite it) so we read the animated pose.
            _hips.RestoreAnimated();
            _footL.RestoreAnimated();
            _footR.RestoreAnimated();

            bool idle = _weight <= 0f && Mathf.Abs(_pelvis) < 1e-4f && Mathf.Abs(_extraL) < 1e-4f && Mathf.Abs(_extraR) < 1e-4f;
            if (idle) { _pelvis = _extraL = _extraR = 0f; return; }

            Solve(_footL.T.position, _footR.T.position, dt);

            Vector3 up = Vector3.up;
            _hips.T.position += up * _pelvis;                // feet follow the hips
            _hips.MarkWritten();

            ApplyFoot(_footL, _extraL, _nL, _minL, _hitL);
            ApplyFoot(_footR, _extraR, _nR, _minR, _hitR);
        }

        void ApplyFoot(Slot s, float extra, Vector3 normal, float minY, bool hit)
        {
            Transform t = s.T;
            Vector3 p = t.position;
            p.y += extra;
            if (hit && _weight > 0f)
            {
                float floor = minY;                           // ground + FootOffset
                if (p.y < floor) p.y = Mathf.Lerp(p.y, floor, _weight);
            }
            t.position = p;

            if (hit && _weight > 0f)
            {
                Quaternion tilt = Quaternion.FromToRotation(Vector3.up, normal);
                t.rotation = Quaternion.Slerp(t.rotation, tilt * t.rotation, _weight);
            }
            s.MarkWritten();
        }

        // ------------------------------------------------------------------ Humanoid path

        void OnAnimatorIK(int layerIndex)
        {
            if (!_resolved) Resolve();
            if (!_ready || !_humanoid || _animator == null) return;

            if (_ikFrame != Time.frameCount)
            {
                _ikFrame = Time.frameCount;
                float dt = Time.deltaTime;
                Tick(dt);
                if (_weight > 0f || Mathf.Abs(_pelvis) > 1e-4f || Mathf.Abs(_extraL) > 1e-4f || Mathf.Abs(_extraR) > 1e-4f)
                    Solve(_animator.GetIKPosition(AvatarIKGoal.LeftFoot), _animator.GetIKPosition(AvatarIKGoal.RightFoot), dt);
                else { _pelvis = _extraL = _extraR = 0f; }
            }

            if (_weight <= 0f && Mathf.Abs(_extraL) < 1e-4f && Mathf.Abs(_extraR) < 1e-4f)
            {
                _animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 0f);
                _animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot, 0f);
                _animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, 0f);
                _animator.SetIKRotationWeight(AvatarIKGoal.RightFoot, 0f);
                return;
            }

            _animator.bodyPosition += Vector3.up * _pelvis;
            GoalFoot(AvatarIKGoal.LeftFoot, _extraL, _nL, _minL, _hitL);
            GoalFoot(AvatarIKGoal.RightFoot, _extraR, _nR, _minR, _hitR);
        }

        void GoalFoot(AvatarIKGoal goal, float extra, Vector3 normal, float minY, bool hit)
        {
            Vector3 p = _animator.GetIKPosition(goal);
            p.y += _pelvis + extra;
            if (hit && _weight > 0f && p.y < minY) p.y = Mathf.Lerp(p.y, minY, _weight);
            Quaternion rot = _animator.GetIKRotation(goal);
            if (hit) rot = Quaternion.FromToRotation(Vector3.up, normal) * rot;
            _animator.SetIKPositionWeight(goal, 1f);
            _animator.SetIKRotationWeight(goal, _weight);
            _animator.SetIKPosition(goal, p);
            _animator.SetIKRotation(goal, rot);
        }

        // ------------------------------------------------------------------ shared solve

        /// <summary>Cast rays, derive pelvis and per-foot offsets, smooth them toward weight-scaled targets.</summary>
        void Solve(Vector3 animL, Vector3 animR, float dt)
        {
            float w = _weight;
            float refY;
            Vector3 rootPos = transform.position;
            if (!CastGround(rootPos, out RaycastHit rootHit)) refY = rootPos.y;
            else refY = rootHit.point.y;

            float dL = 0f, dR = 0f;
            _hitL = CastGround(animL, out RaycastHit hl);
            _hitR = CastGround(animR, out RaycastHit hr);
            Vector3 nL = Vector3.up, nR = Vector3.up;
            if (_hitL)
            {
                dL = Mathf.Clamp(hl.point.y - refY, -RayLength, MaxRaise);
                _minL = hl.point.y + FootOffset;
                nL = ClampNormal(hl.normal);
            }
            if (_hitR)
            {
                dR = Mathf.Clamp(hr.point.y - refY, -RayLength, MaxRaise);
                _minR = hr.point.y + FootOffset;
                nR = ClampNormal(hr.normal);
            }

            float p = Mathf.Min(0f, Mathf.Min(_hitL ? dL : 0f, _hitR ? dR : 0f));
            float tPelvis = p * w;
            float tL = _hitL ? (dL - p) * w : 0f;
            float tR = _hitR ? (dR - p) * w : 0f;

            float kp = 1f - Mathf.Exp(-Mathf.Max(0.01f, PelvisSpeed) * dt);
            float kf = 1f - Mathf.Exp(-Mathf.Max(0.01f, PelvisSpeed) * 2f * dt);
            _pelvis = Mathf.Lerp(_pelvis, tPelvis, kp);
            _extraL = Mathf.Lerp(_extraL, tL, kf);
            _extraR = Mathf.Lerp(_extraR, tR, kf);
            _nL = Vector3.Slerp(_nL, nL, kf);
            _nR = Vector3.Slerp(_nR, nR, kf);
        }

        static Vector3 ClampNormal(Vector3 n)
        {
            return Vector3.RotateTowards(Vector3.up, n, MaxFootAlignDeg * Mathf.Deg2Rad, 0f);
        }

        /// <summary>Downward ray from above `pos`, nearest hit that is not part of this character.</summary>
        bool CastGround(Vector3 pos, out RaycastHit best)
        {
            best = default;
            Vector3 origin = new Vector3(pos.x, transform.position.y + RayStartUp, pos.z);
            int n = Physics.RaycastNonAlloc(origin, Vector3.down, Hits, RayStartUp + RayLength, GroundMask, QueryTriggerInteraction.Ignore);
            float bestDist = float.MaxValue;
            bool found = false;
            for (int i = 0; i < n; i++)
            {
                var h = Hits[i];
                if (h.collider == null || h.collider.transform.IsChildOf(transform)) continue;
                if (h.distance < bestDist) { bestDist = h.distance; best = h; found = true; }
            }
            return found;
        }

        void OnDisable()
        {
            // Leave the bones as the Animator will pose them next frame.
            _weight = 0f; _pelvis = _extraL = _extraR = 0f;
            if (_hips != null) { _hips.RestoreAnimated(); _footL.RestoreAnimated(); _footR.RestoreAnimated(); }
        }
    }
}
