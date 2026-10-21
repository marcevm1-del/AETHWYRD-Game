using System;
using System.Collections.Generic;
using System.Linq;

namespace Ascend.Core
{
    public enum StyleRank { C, B, A, S, SS, SSS }
    public enum HitWeight { Light, Medium, Heavy, Launch, Ultimate, Skill }
    public enum StyleEvent { Reaction, PerfectDodge, Parry, LaunchToSlam }

    /// <summary>
    /// Style Rank meter (combat.md §8). Engine-agnostic: call <see cref="Tick"/> every frame with delta time.
    /// Points rise with varied hits and skill events, decay when idle, and drop a whole rank when the player is hit.
    /// </summary>
    public sealed class StyleMeter
    {
        readonly StyleTuning _t;
        readonly (StyleRank rank, int threshold)[] _ranks;
        readonly Queue<string> _recentMoves = new Queue<string>();
        string _lastMove;
        int _repeatCount;
        double _idle;

        public double Points { get; private set; }
        public StyleRank Rank => RankFor(Points);

        public StyleMeter(StyleTuning tuning)
        {
            _t = tuning ?? throw new ArgumentNullException(nameof(tuning));
            _ranks = Enum.GetValues(typeof(StyleRank)).Cast<StyleRank>()
                .Select(r => (r, _t.Thresholds.TryGetValue(r.ToString(), out var v) ? v : 0))
                .OrderBy(x => x.Item2).ToArray();
        }

        public StyleRank RankFor(double points)
        {
            var best = StyleRank.C;
            foreach (var (rank, threshold) in _ranks) if (points >= threshold) best = rank;
            return best;
        }

        public int ThresholdOf(StyleRank rank) => _ranks.First(x => x.rank == rank).threshold;

        /// <summary>Registers a landed hit. <paramref name="moveId"/> identifies the move (e.g. "light_3", "rising_cut").</summary>
        public double RegisterHit(string moveId, HitWeight weight)
        {
            if (string.IsNullOrEmpty(moveId)) throw new ArgumentException("moveId required", nameof(moveId));
            _idle = 0;
            double pts = _t.HitPoints.TryGetValue(Key(weight), out var p) ? p : 10;

            bool isNewInWindow = !_recentMoves.Contains(moveId);
            if (isNewInWindow) pts *= _t.VarietyMultiplier;

            _repeatCount = moveId == _lastMove ? _repeatCount + 1 : 1;
            _lastMove = moveId;
            if (_t.RepeatPenaltyAfter > 0 && _repeatCount >= _t.RepeatPenaltyAfter) pts *= 0.5;

            _recentMoves.Enqueue(moveId);
            while (_recentMoves.Count > Math.Max(1, _t.VarietyWindowHits)) _recentMoves.Dequeue();

            Points += pts;
            return pts;
        }

        public double RegisterEvent(StyleEvent e)
        {
            _idle = 0;
            double pts = _t.Bonus.TryGetValue(Key(e), out var p) ? p : 0;
            Points += pts;
            return pts;
        }

        /// <summary>The player took a hit: drop <c>DropRanksOnHit</c> ranks (to the start of that rank).</summary>
        public void RegisterPlayerHit()
        {
            int idx = Array.FindIndex(_ranks, x => x.rank == Rank);
            int target = Math.Max(0, idx - Math.Max(1, _t.DropRanksOnHit));
            Points = _ranks[target].threshold;
            _idle = 0;
        }

        public void Tick(double dt)
        {
            if (dt <= 0) return;
            _idle += dt;
            if (_idle > _t.DecayDelaySec)
            {
                double decayTime = Math.Min(dt, _idle - _t.DecayDelaySec);
                Points = Math.Max(0, Points - _t.DecayPerSec * decayTime);
            }
        }

        public void Reset()
        {
            Points = 0; _idle = 0; _lastMove = null; _repeatCount = 0; _recentMoves.Clear();
        }

        static string Key(HitWeight w) => char.ToLowerInvariant(w.ToString()[0]) + w.ToString().Substring(1);
        static string Key(StyleEvent e) => char.ToLowerInvariant(e.ToString()[0]) + e.ToString().Substring(1);
    }
}
