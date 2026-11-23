using System;
using System.Collections.Generic;

namespace Ascend.Core
{
    /// <summary>Monster attack telegraphs (combat.md §5): blue parryable, red unblockable, gold grab, none weak/chip.</summary>
    public enum Telegraph { None, Blue, Red, Gold }

    public enum DefenseResult { Hit, Blocked, Parried, Dodged, PerfectDodge, Grabbed }

    /// <summary>
    /// Decides how an incoming hit meets the player's defence, from input timings alone (engine-free).
    ///   Perfect dodge: the dodge began within `perfectDodgeWindowSec` before the hit and the hit lands in its i-frames → Flash Time.
    ///   Parry: block pressed within `parryWindowSec` before a blue or untelegraphed hit → stagger + riposte.
    ///   Block: holding block against blue/none reduces damage; red ignores blocks; gold grabs a blocker.
    /// </summary>
    public static class DefenseJudge
    {
        public static Telegraph Parse(string telegraph) =>
            Enum.TryParse(telegraph, true, out Telegraph t) ? t : Telegraph.None;

        /// <param name="hitTime">When the attack connects.</param>
        /// <param name="dodgeStart">When the current dodge began, or null.</param>
        /// <param name="invulnerableAtHit">Whether the player is inside dodge i-frames at hitTime.</param>
        /// <param name="blockPress">When block was last pressed, or null.</param>
        /// <param name="blocking">Whether block is held at hitTime.</param>
        /// <param name="guardHolds">False when the guard has no stamina left: a held block then fails and the hit lands (red and gold are unaffected).</param>
        public static DefenseResult Resolve(Telegraph telegraph, double hitTime, double? dodgeStart, bool invulnerableAtHit,
            double? blockPress, bool blocking, DodgeTuning dodge, ParryTuning parry, bool guardHolds = true)
        {
            if (invulnerableAtHit && dodgeStart.HasValue)
                return hitTime - dodgeStart.Value <= dodge.PerfectDodgeWindowSec ? DefenseResult.PerfectDodge : DefenseResult.Dodged;
            bool parryable = telegraph == Telegraph.Blue || telegraph == Telegraph.None;
            if (parryable && blockPress.HasValue && hitTime >= blockPress.Value && hitTime - blockPress.Value <= parry.ParryWindowSec)
                return DefenseResult.Parried;
            if (blocking && guardHolds)
            {
                if (telegraph == Telegraph.Gold) return DefenseResult.Grabbed;
                if (parryable) return DefenseResult.Blocked;
            }
            return telegraph == Telegraph.Gold ? DefenseResult.Grabbed : DefenseResult.Hit;
        }

        /// <summary>Stamina left after a blocked hit drains its cost (never below 0). At 0 the next block fails.</summary>
        public static double StaminaAfterBlockedHit(double stamina, ParryTuning parry) => Math.Max(0, stamina - parry.BlockStaminaPerHit);

        /// <summary>Damage taken after the defence result (blocked hits are reduced by `blockDamageReduction`).</summary>
        public static int DamageTaken(DefenseResult r, int raw, ParryTuning parry)
        {
            switch (r)
            {
                case DefenseResult.Blocked: return (int)Math.Round(raw * (1 - parry.BlockDamageReduction));
                case DefenseResult.Hit: case DefenseResult.Grabbed: return raw;
                default: return 0;
            }
        }
    }

    /// <summary>
    /// Block button state. The parry window opens only on a true press edge (or a buffered press that fires), never
    /// because a held block became active again after an attack or dodge ended. Engine-free.
    /// </summary>
    public sealed class GuardState
    {
        bool _prevHeld;
        public bool Blocking { get; private set; }
        /// <summary>When the parry window opened, or null.</summary>
        public double? PressedAt { get; private set; }

        /// <param name="held">Block button held.</param>
        /// <param name="suppressed">Attacking or dodging: the guard is down but the button state is still tracked.</param>
        public void Update(bool held, bool suppressed, double now)
        {
            if (held && !_prevHeld) PressedAt = now;
            _prevHeld = held;
            Blocking = held && !suppressed;
        }

        /// <summary>A buffered block press fired at its first legal moment: opens the parry window then.</summary>
        public void StampBufferedPress(double now) => PressedAt = now;
        public void ConsumeParry() => PressedAt = null;
        public void Reset() { _prevHeld = false; Blocking = false; PressedAt = null; }
    }

    /// <summary>
    /// Charged heavy (combat.md §4.1): hold to pass the thresholds in `combo.chargeLevels`; release fires at that level.
    /// Level 0 is a tap heavy. Power scales by `combo.chargePowerMult[level]`; level ≥ `combo.guardBreakLevel` breaks guards.
    /// </summary>
    public sealed class ChargeMeter
    {
        readonly ComboTuning _t;
        double _held = -1;

        public ChargeMeter(ComboTuning tuning) { _t = tuning ?? throw new ArgumentNullException(nameof(tuning)); }

        public bool Charging => _held >= 0;
        public double HeldSec => Math.Max(0, _held);
        public int Level => LevelFor(HeldSec);

        public void Begin() => _held = 0;
        public void Tick(double dt) { if (Charging) _held += dt; }

        /// <summary>Ends the charge and returns the level reached (0 if nothing was charging).</summary>
        public int Release()
        {
            int level = Charging ? Level : 0;
            _held = -1;
            return level;
        }

        public void Cancel() => _held = -1;

        public int LevelFor(double heldSec)
        {
            int level = 0;
            foreach (var threshold in _t.ChargeLevels) if (heldSec >= threshold) level++;
            return level;
        }

        public double PowerMult(int level)
        {
            IList<double> m = _t.ChargePowerMult;
            if (m == null || m.Count == 0) return 1.0;
            return m[Math.Max(0, Math.Min(level, m.Count - 1))];
        }

        public bool BreaksGuard(int level) => level >= _t.GuardBreakLevel;
    }
}
