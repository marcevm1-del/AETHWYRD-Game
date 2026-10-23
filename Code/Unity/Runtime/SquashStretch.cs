// Project Ascend — squash & stretch for slimes and Charming (Menace 1) monsters.
// Drives "squash" / "stretch" blend shapes from vertical velocity and landings; falls back to volume-preserving scale.
using UnityEngine;

namespace Ascend.Monsters
{
    public class SquashStretch : MonoBehaviour
    {
        public SkinnedMeshRenderer body;
        public Transform scaleFallback;
        [Tooltip("Menace squashStretch multiplier from motion.json (1 = normal, 1.5 = Charming).")]
        public float amount = 1f;
        public float stretchPerMps = 0.08f;
        public float landSquash = 0.45f;
        public float springFreq = 9f, springDamping = 0.35f;

        int _squashIdx = -1, _stretchIdx = -1;
        Vector3 _lastPos;
        float _lastVy, _value, _vel; // _value > 0 stretch, < 0 squash
        Vector3 _baseScale;

        void Start()
        {
            if (body && body.sharedMesh)
            {
                _squashIdx = body.sharedMesh.GetBlendShapeIndex("squash");
                _stretchIdx = body.sharedMesh.GetBlendShapeIndex("stretch");
            }
            if (!scaleFallback) scaleFallback = transform;
            _baseScale = scaleFallback.localScale;
            _lastPos = transform.position;
        }

        /// <summary>Squash now (e.g. when hit). Positive = stretch.</summary>
        public void Kick(float v) => _vel += v * amount;

        void LateUpdate()
        {
            float dt = Time.deltaTime;
            if (dt <= 0f) return;
            float vy = (transform.position.y - _lastPos.y) / dt;
            _lastPos = transform.position;
            if (_lastVy < -1.5f && vy > -0.2f) Kick(-landSquash * Mathf.Clamp01(-_lastVy / 6f) * 10f); // landing
            _lastVy = vy;

            float target = Mathf.Clamp(vy * stretchPerMps * amount, -0.6f, 0.6f);
            // damped spring toward the velocity-based target
            float accel = springFreq * springFreq * (target - _value) - 2f * springDamping * springFreq * _vel;
            _vel += accel * dt;
            _value = Mathf.Clamp(_value + _vel * dt, -1f, 1f);

            if (_squashIdx >= 0 || _stretchIdx >= 0)
            {
                if (_squashIdx >= 0) body.SetBlendShapeWeight(_squashIdx, Mathf.Max(0f, -_value) * 100f);
                if (_stretchIdx >= 0) body.SetBlendShapeWeight(_stretchIdx, Mathf.Max(0f, _value) * 100f);
            }
            else
            {
                float y = 1f + _value;
                float xz = 1f / Mathf.Sqrt(Mathf.Max(0.2f, y)); // keep volume
                scaleFallback.localScale = new Vector3(_baseScale.x * xz, _baseScale.y * y, _baseScale.z * xz);
            }
        }
    }
}
