using System;
using System.Collections.Generic;
using System.Linq;

namespace Ascend.Core
{
    // Group tactics (combat.md §10, Canon §4d). Hard rules, enforced by shape:
    //  - Peers are symmetric. There is no rank, title or special role field on any type here.
    //  - Nothing is remembered about the player. Every type below is stateless or a plain value;
    //    scores are recomputed each tick from what is passed in, so nothing survives a fight.
    //  - No randomness here at all (the brain's injected IRandom stays the only source).
    // Every default reproduces the pre-tactics brain: a zero in AiSense means "not supplied".

    /// <summary>
    /// Numbers for group tactics. The in-code defaults equal the values in combat_tuning.json "groupTactics" (a test pins that),
    /// so the data file is the single source of truth and the code default only matters when no data is loaded.
    /// </summary>
    public sealed class GroupTacticsTuning
    {
        /// <summary>Shared default instance for callers that have no data (read-only by convention; do not mutate). Avoids a per-tick allocation.</summary>
        public static readonly GroupTacticsTuning Default = new GroupTacticsTuning();

        /// <summary>When false the monster brain behaves exactly as it did before group tactics (no player-HP retreat scaling, no yielding, no flank angle, no threat score).</summary>
        public bool Enabled { get; set; } = true;
        /// <summary>Distinct angular slots around the target (2-4).</summary>
        public int FlankSlotCount { get; set; } = 3;
        /// <summary>Total arc the slots are spread over, centred on the approach axis (degrees).</summary>
        public double FlankArcDeg { get; set; } = 240;
        /// <summary>When the player is at or below this HP fraction the pack presses on: retreat thresholds are scaled down.</summary>
        public double PressOnPlayerHp { get; set; } = 0.25;
        /// <summary>Multiplier on retreat thresholds while pressing on (0-1).</summary>
        public double PressOnRetreatScale { get; set; } = 0.5;
        /// <summary>When the player is healthy (at or above this) and the monster stands alone, it retreats a little earlier.</summary>
        public double HealthyPlayerHp { get; set; } = 0.75;
        /// <summary>Added to the lone-retreat HP fraction against a healthy player when the monster has no allies near.</summary>
        public double OutnumberedRetreatBonus { get; set; } = 0.1;
        /// <summary>HP fractions closer than this count as equal when two peers contest a token (the order tie-break decides).</summary>
        public double YieldHpGap { get; set; } = 0.2;
        /// <summary>Seconds a yielding monster keeps circling before it asks for the token again.</summary>
        public double YieldSec { get; set; } = 1.5;
        /// <summary>Threat score weights (they need not sum to 1; the score is clamped to 0-1).</summary>
        public double ThreatPlayerWeight { get; set; } = 0.4;
        public double ThreatAlliesWeight { get; set; } = 0.35;
        public double ThreatOwnHpWeight { get; set; } = 0.25;
        /// <summary>Allies at which the threat from "being outnumbered" reaches zero.</summary>
        public int ThreatAlliesFull { get; set; } = 4;

        public int SlotCountClamped => Math.Max(1, Math.Min(6, FlankSlotCount));
    }

    /// <summary>How dangerous the fight feels to one monster right now (0 calm, 1 dire). No memory: pure function of this tick.</summary>
    public static class ThreatAssessor
    {
        /// <param name="playerHp">Player HP fraction; 0 or less means "not supplied" and counts as full.</param>
        public static double Score(double playerHp, int alliesNear, double ownHp, GroupTacticsTuning t = null)
        {
            t = t ?? GroupTacticsTuning.Default;
            double p = playerHp <= 0 ? 1.0 : Math.Min(1.0, playerHp);
            double own = ownHp <= 0 ? 1.0 : Math.Min(1.0, ownHp);
            double alone = 1.0 - Math.Min(1.0, Math.Max(0, alliesNear) / (double)Math.Max(1, t.ThreatAlliesFull));
            double s = t.ThreatPlayerWeight * p + t.ThreatAlliesWeight * alone + t.ThreatOwnHpWeight * (1.0 - own);
            return Math.Max(0, Math.Min(1, s));
        }
    }

    /// <summary>Distinct angular slots around the target, deterministic from member order.</summary>
    public static class FlankSlots
    {
        /// <summary>Slot index (1-based) for each member id, by sorted id order. The first SlotCount members get distinct slots; extras wrap.</summary>
        public static Dictionary<int, int> Assign(IEnumerable<int> memberIds, GroupTacticsTuning t = null)
        {
            t = t ?? GroupTacticsTuning.Default;
            int k = t.SlotCountClamped;
            var result = new Dictionary<int, int>();
            int i = 0;
            foreach (var id in memberIds.Distinct().OrderBy(x => x))
                result[id] = (i++ % k) + 1;
            return result;
        }

        /// <summary>Angle in degrees from the approach axis for a 1-based slot. Slots spread evenly across the arc; 0 for a bad slot.</summary>
        public static double AngleDeg(int slot, GroupTacticsTuning t = null, int slotCount = 0)
        {
            t = t ?? GroupTacticsTuning.Default;
            int k = slotCount > 0 ? Math.Max(1, Math.Min(6, slotCount)) : t.SlotCountClamped;
            if (slot < 1 || k == 1) return 0;
            int idx = Math.Min(slot, k) - 1;
            return -t.FlankArcDeg / 2.0 + t.FlankArcDeg * idx / (k - 1);
        }
    }

    /// <summary>Low-HP retreat with the existing per-species RetreatHpPct and LoneRetreatHp as the base.</summary>
    public static class RetreatRule
    {
        /// <summary>The HP fraction at or below which a species with a retreat percentage flees. Unchanged when the player's HP is not supplied.</summary>
        public static double SpeciesThreshold(double basePct, double playerHp, GroupTacticsTuning t = null)
        {
            if (basePct <= 0 || playerHp <= 0) return basePct;
            t = t ?? GroupTacticsTuning.Default;
            return playerHp <= t.PressOnPlayerHp ? basePct * t.PressOnRetreatScale : basePct;
        }

        /// <summary>The HP fraction below which a pack monster with no allies near falls back. Unchanged when the player's HP is not supplied.</summary>
        public static double LoneThreshold(double baseHp, double playerHp, GroupTacticsTuning t = null)
        {
            if (playerHp <= 0) return baseHp;
            t = t ?? GroupTacticsTuning.Default;
            if (playerHp <= t.PressOnPlayerHp) return baseHp * t.PressOnRetreatScale;
            if (playerHp >= t.HealthyPlayerHp) return Math.Min(1.0, baseHp + t.OutnumberedRetreatBonus);
            return baseHp;
        }
    }

    /// <summary>One monster in a pack as the coordinator sees it. Just numbers; no role.</summary>
    public struct PackMember
    {
        public int Id;
        public double HpFraction;
        public bool WantsToken;
    }

    /// <summary>
    /// Symmetric token yielding. Every pack member runs the same function over the same list and gets the same answer.
    /// A monster that wants a token yields it to a peer that also wants it and is clearly healthier (HP at least
    /// YieldHpGap higher); a gap smaller than that counts as equal and falls to the lowest id, so exactly one wants-token member never yields.
    /// </summary>
    public static class PeerCoordinator
    {
        public static bool ShouldYield(int selfId, IReadOnlyList<PackMember> members, GroupTacticsTuning t = null)
        {
            t = t ?? GroupTacticsTuning.Default;
            PackMember? self = null;
            foreach (var m in members) if (m.Id == selfId) { self = m; break; }
            if (self == null || !self.Value.WantsToken) return false;
            foreach (var m in members)
            {
                if (m.Id == selfId || !m.WantsToken) continue;
                if (Beats(m, self.Value, t)) return true;
            }
            return false;
        }

        /// <summary>The member that keeps the contested token, or -1 when nobody wants one.</summary>
        public static int Winner(IReadOnlyList<PackMember> members, GroupTacticsTuning t = null)
        {
            t = t ?? GroupTacticsTuning.Default;
            int best = -1; PackMember bestM = default;
            foreach (var m in members)
            {
                if (!m.WantsToken) continue;
                if (best < 0 || Beats(m, bestM, t)) { best = m.Id; bestM = m; }
            }
            return best;
        }

        // a beats b when it is healthier by at least YieldHpGap; a smaller gap counts as equal and the lower id wins.
        static bool Beats(PackMember a, PackMember b, GroupTacticsTuning t)
        {
            double gap = Math.Max(0.01, t.YieldHpGap);
            double diff = a.HpFraction - b.HpFraction;
            if (Math.Abs(diff) >= gap) return diff > 0;
            return a.Id < b.Id;
        }
    }
}
