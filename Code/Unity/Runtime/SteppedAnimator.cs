// AETHWYRD — stop-motion animation for Dread / Horror monsters (Menace 4–5).
// Evaluates the Animator only at a low frame rate (e.g. 8 or 12 fps), so motion "jumps" between poses.
// Optional bursts: every few seconds it switches to smooth motion for a moment (Horror), which is more unsettling.
using UnityEngine;

namespace Ascend.Monsters
{
    public class SteppedAnimator : MonoBehaviour
    {
        public Animator animator;
        [Min(1)] public float fps = 12f;
        [Tooltip("Chance per second to switch to smooth motion for smoothBurstSec (Horror feel).")]
        [Range(0, 1)] public float smoothBurstChancePerSec = 0f;
        public float smoothBurstSec = 0.6f;
        [Tooltip("Speed multiplier (play rate from motion.json, hit-stop, Flash Time).")]
        public float speed = 1f;

        float _acc, _smoothLeft;

        void OnEnable()
        {
            if (!animator) animator = GetComponentInChildren<Animator>();
            if (animator) animator.enabled = false; // evaluated manually below
        }

        void OnDisable()
        {
            if (animator) animator.enabled = true;
        }

        void Update()
        {
            if (!animator) return;
            float dt = Time.deltaTime * speed;
            if (_smoothLeft > 0f)
            {
                _smoothLeft -= Time.deltaTime;
                animator.Update(dt);
                return;
            }
            if (smoothBurstChancePerSec > 0f && Random.value < smoothBurstChancePerSec * Time.deltaTime) _smoothLeft = smoothBurstSec;
            _acc += dt;
            float step = 1f / fps;
            if (_acc >= step)
            {
                animator.Update(_acc); // jump straight to the next pose
                _acc = 0f;
            }
        }
    }
}
