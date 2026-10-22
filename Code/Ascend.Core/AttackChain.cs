using System;

namespace Ascend.Core
{
    public enum AttackPhase { Idle, Startup, Active, Recovery }

    /// <summary>
    /// A basic attack string (e.g. the Swordsman's Slash Chain) as a frame-free state machine (combat.md §4.1).
    /// Each hit runs startup → active → recovery with timings by weight from combat_tuning.json `attackTiming`.
    /// The hit lands on the first active frame. A press is buffered for `inputBufferSec`; a buffered press starts
    /// the next hit as soon as recovery begins. Dodge may cancel from active frame 1. The string resets after its
    /// last hit or after `chainResetSec` idle. Engine-free: call Press/Tick from the game, Tick returns landed hits.
    /// </summary>
    public sealed class AttackChain
    {
        readonly SkillData _chain;
        readonly AttackTimingTuning _timing;
        readonly double _bufferSec;
        double _phaseTime, _buffered = -1, _idleTime;
        int _next;

        public AttackPhase Phase { get; private set; } = AttackPhase.Idle;
        /// <summary>Index of the hit being performed (or last performed while idle); -1 before the first hit.</summary>
        public int HitIndex { get; private set; } = -1;
        public int Length => _chain.Hits.Count;
        public SkillHit Current => HitIndex >= 0 ? _chain.Hits[HitIndex] : null;
        public bool IsBusy => Phase != AttackPhase.Idle;
        /// <summary>Dodge-cancel allowed: from active frame 1 onwards, or when idle.</summary>
        public bool CanDodgeCancel => Phase != AttackPhase.Startup;
        public string SkillId => _chain.Id;

        public AttackChain(SkillData chain, CombatTuning tuning)
        {
            _chain = chain ?? throw new ArgumentNullException(nameof(chain));
            if (_chain.Hits.Count == 0) throw new ArgumentException($"{chain.Id} has no hits", nameof(chain));
            _timing = (tuning ?? throw new ArgumentNullException(nameof(tuning))).AttackTiming;
            _bufferSec = tuning.InputBufferSec;
        }

        public static HitWeight WeightOf(SkillHit hit) =>
            Enum.TryParse(hit.Weight, true, out HitWeight w) ? w : HitWeight.Light;

        public PhaseTiming TimingOf(SkillHit hit)
        {
            switch (WeightOf(hit))
            {
                case HitWeight.Medium: return _timing.Medium;
                case HitWeight.Heavy: case HitWeight.Ultimate: return _timing.Heavy;
                case HitWeight.Launch: return _timing.Launch;
                default: return _timing.Light;
            }
        }

        /// <summary>Attack button pressed. Starts a hit when idle, otherwise buffers it.</summary>
        public void Press()
        {
            if (Phase == AttackPhase.Idle) StartNext();
            else _buffered = _bufferSec;
        }

        /// <summary>Dodge (or another action) interrupts the string. False during startup, where it isn't allowed.</summary>
        public bool Cancel()
        {
            if (!CanDodgeCancel) return false;
            Phase = AttackPhase.Idle;
            _buffered = -1;
            _next = 0;
            return true;
        }

        /// <summary>Advances time. Returns the hit that landed during this step, or null.</summary>
        public SkillHit Tick(double dt)
        {
            SkillHit landed = null;
            if (_buffered >= 0) _buffered -= dt;
            if (Phase == AttackPhase.Idle)
            {
                _idleTime += dt;
                if (_idleTime >= _timing.ChainResetSec) _next = 0;
                return null;
            }

            _phaseTime += dt;
            var t = TimingOf(Current);
            // Several phases can pass in one long step (e.g. a hitch); walk through them in order.
            while (true)
            {
                if (Phase == AttackPhase.Startup && _phaseTime >= t.StartupSec)
                {
                    _phaseTime -= t.StartupSec;
                    Phase = AttackPhase.Active;
                    landed = Current;
                }
                else if (Phase == AttackPhase.Active && _phaseTime >= t.ActiveSec)
                {
                    _phaseTime -= t.ActiveSec;
                    Phase = AttackPhase.Recovery;
                    if (_buffered >= 0 && _next > 0) { StartNext(); return landed; }
                }
                else if (Phase == AttackPhase.Recovery)
                {
                    if (_buffered >= 0 && _next > 0) { StartNext(); return landed; }
                    if (_phaseTime < t.RecoverySec) break;
                    Phase = AttackPhase.Idle;
                    _idleTime = _phaseTime - t.RecoverySec;
                    if (_buffered >= 0) StartNext(); // press held over the string's end starts a new string
                    break;
                }
                else break;
            }
            return landed;
        }

        void StartNext()
        {
            HitIndex = _next;
            _next = _next + 1 < _chain.Hits.Count ? _next + 1 : 0;
            Phase = AttackPhase.Startup;
            _phaseTime = 0;
            _buffered = -1;
            _idleTime = 0;
        }
    }
}
