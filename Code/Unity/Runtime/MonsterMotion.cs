// AETHWYRD — per-monster motion component. Built onto prefabs by Ascend > Build Monster Prefabs (Editor).
// Applies the profile from motion.json to the NavMeshAgent and Animator, exposes attack timings to the AI,
// and receives animation events (footstep_L, hit_on, telegraph, ...) from clips.
using System;
using UnityEngine;
using UnityEngine.AI;

namespace Ascend.Monsters
{
    [DisallowMultipleComponent]
    public class MonsterMotion : MonoBehaviour
    {
        [Tooltip("This species' profile as JSON (written by the prefab builder).")]
        [TextArea(2, 6)] public string profileJson;
        public Animator animator;

        [Header("Animator parameter names")]
        public string speedParam = "Speed";          // m/s
        public string speedNormParam = "SpeedNorm";  // 0 = idle, 1 = full run
        public string attackTrigger = "Attack";
        public string attackIndexParam = "AttackIndex";

        public MonsterProfile Profile { get; private set; }
        public NavMeshAgent Agent { get; private set; }

        /// <summary>Raised for every animation event id ("footstep_L", "hit_on", "telegraph", "vocal", "vfx", "land", "cancel", "ragdoll").</summary>
        public event Action<string> AnimEventRaised;
        /// <summary>Raised when an attack starts its telegraph (attack, color: blue/red/gold/none).</summary>
        public event Action<AttackTiming, string> TelegraphStarted;

        float _baseAnimSpeed = 1f;

        void Awake()
        {
            Agent = GetComponent<NavMeshAgent>();
            if (!animator) animator = GetComponentInChildren<Animator>();
            if (!string.IsNullOrEmpty(profileJson)) Apply(JsonUtility.FromJson<MonsterProfile>(profileJson));
        }

        public void Apply(MonsterProfile p)
        {
            Profile = p;
            if (p == null) return;
            if (Agent && p.navAgent != null)
            {
                Agent.radius = p.navAgent.radius;
                Agent.height = p.navAgent.height;
                Agent.speed = p.navAgent.speed;
                Agent.angularSpeed = p.navAgent.angularSpeed;
                Agent.acceleration = p.navAgent.acceleration;
                Agent.stoppingDistance = p.navAgent.stoppingDistance;
                Agent.baseOffset = p.navAgent.baseOffset;
            }
            if (p.locomotion != null) _baseAnimSpeed = Mathf.Max(0.05f, p.locomotion.playRate);
            if (animator) animator.speed = _baseAnimSpeed;
        }

        void Update()
        {
            if (!animator || Profile == null || Agent == null) return;
            float v = Agent.velocity.magnitude;
            animator.SetFloat(speedParam, v);
            float run = Profile.navAgent != null && Profile.navAgent.speed > 0.01f ? Profile.navAgent.speed : 1f;
            animator.SetFloat(speedNormParam, Mathf.Clamp01(v / run));
        }

        /// <summary>Gait speed by name ("walk", "run", "gallop", "hop"...). Returns the agent speed if missing.</summary>
        public float GaitSpeed(string gait)
        {
            if (Profile?.locomotion?.gaits != null)
                foreach (var g in Profile.locomotion.gaits) if (g.name == gait) return g.speed;
            return Agent ? Agent.speed : 1f;
        }

        /// <summary>
        /// Starts an attack: picks the windup (with Menace jitter), fires the telegraph event and the animator trigger.
        /// Returns the windup actually used. The AI should keep tracking at trackingWindupDegPerSec until the windup ends.
        /// </summary>
        public float BeginAttack(int index, System.Random rng = null)
        {
            if (Profile?.attacks == null || index < 0 || index >= Profile.attacks.Length) return 0f;
            var a = Profile.attacks[index];
            float jitter = a.windupJitter > 0f ? (float)((rng ?? new System.Random()).NextDouble() * 2 - 1) * a.windupJitter : 0f;
            float windup = Mathf.Max(Profile.timing != null ? Profile.timing.minTelegraphSec : 0.25f, a.windupSec * (1f + jitter));
            if (animator)
            {
                animator.SetInteger(attackIndexParam, index);
                animator.SetTrigger(attackTrigger);
            }
            TelegraphStarted?.Invoke(a, a.telegraph);
            return windup;
        }

        /// <summary>Animation Event entry point: add an event that calls AnimEvent with a string parameter.</summary>
        public void AnimEvent(string id) => AnimEventRaised?.Invoke(id);

        /// <summary>Multiplies the base play rate (used by hit-stop, Flash Time and SteppedAnimator).</summary>
        public void SetAnimSpeedScale(float scale)
        {
            if (animator) animator.speed = _baseAnimSpeed * scale;
        }

        public float BaseAnimSpeed => _baseAnimSpeed;
    }
}
