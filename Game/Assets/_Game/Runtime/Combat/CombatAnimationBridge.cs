using System;
using Ascend.Core;
using UnityEngine;

namespace Ascend.Game
{
    /// <summary>
    /// Read-only bridge between the time-driven combat rules (Core AttackChain, owned by PlayerCombat) and the
    /// animation layer. It polls <c>PlayerCombat.Chain</c> each tick, raises <see cref="PhaseChanged"/> when the
    /// phase or hit changes, tracks how far through the current phase we are, and tells the Animator how fast to
    /// play the Combat-layer clip so it fills the real phase window (placeholder clips are 1 s long).
    /// It never drives rules: damage and timing stay in AttackChain, so animation can never desync a hit.
    ///
    /// Limits: only the basic chain is observed. One-hit specials (heavy, riposte, launcher, slam, skill) run on a
    /// private chain in PlayerCombat, so their phase durations are not readable here; for those the bridge reports
    /// the chain phase (usually Idle) and the driver should use <c>PlayerCombat.CurrentSpecial</c>.
    ///
    /// Ticking: the animation driver calls <see cref="Tick"/>. If nothing calls it, the bridge ticks itself in
    /// LateUpdate. Tolerates a missing PlayerCombat or chain (bare test players): everything stays Idle.
    /// </summary>
    [DisallowMultipleComponent]
    public sealed class CombatAnimationBridge : MonoBehaviour
    {
        /// <summary>Animation events a real clip may send through <see cref="OnAnimEvent"/>.</summary>
        public const string EvStartupEnd = "StartupEnd", EvActiveBegin = "ActiveBegin",
                            EvActiveEnd = "ActiveEnd", EvRecoveryEnd = "RecoveryEnd";

        /// <summary>Length in seconds of the Combat-layer phase clips (placeholders are 1 s).</summary>
        [SerializeField] float clipLength = 1f;
        /// <summary>Playback speed is clamped to this range so a degenerate timing cannot freeze or explode a clip.</summary>
        [SerializeField] float minPlaybackSpeed = 0.05f, maxPlaybackSpeed = 20f;

        PlayerCombat _combat;
        bool _externallyDriven;
        int _hitIndex;
        float _elapsed, _duration;

        /// <summary>The phase seen on the previous tick.</summary>
        public AttackPhase LastPhase { get; private set; } = AttackPhase.Idle;
        /// <summary>Current phase, polled on the last tick.</summary>
        public AttackPhase Phase => LastPhase;
        /// <summary>Hit index of the current string hit (0-based; 0 when none yet).</summary>
        public int HitIndex => _hitIndex;
        /// <summary>Length in seconds of the current phase from combat_tuning; 0 when Idle.</summary>
        public float PhaseDuration => _duration;
        /// <summary>Seconds spent in the current phase (accumulated from tick dt).</summary>
        public float PhaseElapsed => _elapsed;
        /// <summary>0..1 progress through the current phase; 0 when Idle.</summary>
        public float PhaseNormalizedTime => _duration > 1e-4f ? Mathf.Clamp01(_elapsed / _duration) : 0f;
        /// <summary>Last animation event received through <see cref="OnAnimEvent"/>, or null.</summary>
        public string LastAnimEvent { get; private set; }

        /// <summary>Raised when the phase or the hit index changes: (new phase, hit index 0-based).</summary>
        public event Action<AttackPhase, int> PhaseChanged;

        public float ClipLength { get => clipLength; set => clipLength = Mathf.Max(0.01f, value); }

        void Awake() { _combat = GetComponent<PlayerCombat>(); }

        void LateUpdate()
        {
            // Self-tick only when no driver calls Tick (the driver runs earlier or later, but always every frame).
            if (!_externallyDriven) TickInternal(Time.deltaTime);
        }

        /// <summary>Advance by dt. Called by the animation driver (or tests); disables the self-tick.</summary>
        public void Tick(float dt)
        {
            _externallyDriven = true;
            TickInternal(dt);
        }

        void TickInternal(float dt)
        {
            if (_combat == null) _combat = GetComponent<PlayerCombat>();
            var chain = _combat != null ? _combat.Chain : null;

            AttackPhase phase = chain != null ? chain.Phase : AttackPhase.Idle;
            int hit = chain != null ? Mathf.Max(0, chain.HitIndex) : 0;
            bool changed = phase != LastPhase || (phase != AttackPhase.Idle && hit != _hitIndex);

            if (changed)
            {
                LastPhase = phase;
                _hitIndex = hit;
                _elapsed = 0f;
                _duration = DurationOf(chain, phase);
                PhaseChanged?.Invoke(phase, hit);
                return;
            }

            if (phase == AttackPhase.Idle) { _elapsed = 0f; _duration = 0f; return; }
            _elapsed += Mathf.Max(0f, dt);
        }

        static float DurationOf(AttackChain chain, AttackPhase phase)
        {
            if (chain == null || phase == AttackPhase.Idle) return 0f;
            var hit = chain.Current;
            if (hit == null) return 0f;
            var t = chain.TimingOf(hit);
            if (t == null) return 0f;
            switch (phase)
            {
                case AttackPhase.Startup: return (float)t.StartupSec;
                case AttackPhase.Active: return (float)t.ActiveSec;
                case AttackPhase.Recovery: return (float)t.RecoverySec;
                default: return 0f;
            }
        }

        /// <summary>
        /// Animator speed that makes a <see cref="ClipLength"/>-second clip span the live window of <paramref name="phase"/>:
        /// clipLength / phaseDuration. Idle (or an unknown duration) returns 1.
        /// </summary>
        public float PlaybackSpeedFor(AttackPhase phase)
        {
            if (phase == AttackPhase.Idle) return 1f;
            float d = phase == LastPhase ? _duration : DurationOf(_combat != null ? _combat.Chain : null, phase);
            if (d <= 1e-4f) return 1f;
            return Mathf.Clamp(clipLength / d, minPlaybackSpeed, maxPlaybackSpeed);
        }

        /// <summary>
        /// Receiver for animation events on real (mocap) clips: StartupEnd, ActiveBegin, ActiveEnd, RecoveryEnd.
        /// Only records the last one; never drives rules. Unknown names are ignored.
        /// </summary>
        public void OnAnimEvent(string eventName)
        {
            switch (eventName)
            {
                case EvStartupEnd:
                case EvActiveBegin:
                case EvActiveEnd:
                case EvRecoveryEnd:
                    LastAnimEvent = eventName;
                    break;
            }
        }
    }
}
