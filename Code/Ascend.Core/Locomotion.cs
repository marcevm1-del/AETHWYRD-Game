using System;
using System.Collections.Generic;

namespace Ascend.Core
{
    /// <summary>
    /// Mirror of Data/Player/locomotion.json: V = BaseSpeed * State * Terrain * product(Condition), plus slope and
    /// animation-blend tuning. Pure math, no Unity. The walk/run/sprint state mirrors are cross-checked against
    /// combat_tuning.json movement by the data validator. Terrain and condition multipliers are proposals (Wave A1).
    /// </summary>
    public sealed class LocomotionTable
    {
        public static readonly string[] RequiredStates = { "idle", "walk", "run", "sprint", "air", "dodge" };
        public static readonly string[] RequiredTerrain = { "plains", "forest", "swamp", "steppe", "mountain", "volcanic", "tundra", "desert", "jungle", "spirit", "demon" };

        public int Version { get; set; }
        public double BaseSpeed { get; set; }
        public Dictionary<string, double> State { get; set; } = new Dictionary<string, double>();
        public Dictionary<string, double> Terrain { get; set; } = new Dictionary<string, double>();
        public Dictionary<string, double> Condition { get; set; } = new Dictionary<string, double>();
        public SlopeTuning Slope { get; set; } = new SlopeTuning();
        public BlendTuning Blend { get; set; } = new BlendTuning();
        public DampingTuning Damping { get; set; } = new DampingTuning();

        /// <summary>Speed in m/s. Throws KeyNotFoundException (naming the key) for an unknown state, terrain or condition.</summary>
        public double Speed(string state, string terrain = "plains", IEnumerable<string> conditions = null)
        {
            double v = BaseSpeed * Lookup(State, state, "state") * Lookup(Terrain, terrain ?? "plains", "terrain");
            if (conditions != null) foreach (var c in conditions) v *= Lookup(Condition, c, "condition");
            return v;
        }

        /// <summary>Speed multiplier on a slope: uphill clamp(1 - uphillK*tan, minMult, 1); downhill clamp(1 + downhillK*tan, 1, maxMult).</summary>
        public double SlopeMult(double slopeDeg, bool uphill)
        {
            double deg = Math.Max(0.0, Math.Min(slopeDeg, Slope.LimitDeg));
            double t = Math.Tan(deg * Math.PI / 180.0);
            return uphill
                ? Math.Max(Slope.MinMult, Math.Min(1.0, 1.0 - Slope.UphillK * t))
                : Math.Max(1.0, Math.Min(Slope.MaxMult, 1.0 + Slope.DownhillK * t));
        }

        /// <summary>Blend-tree thresholds {0, walk, run, sprint} on plains with no conditions.</summary>
        public double[] BlendThresholds() => new[] { 0.0, Speed("walk"), Speed("run"), Speed("sprint") };

        /// <summary>Throws InvalidOperationException on missing keys, bad multipliers or non-ascending thresholds.</summary>
        public void Validate()
        {
            foreach (var k in RequiredStates) if (!State.ContainsKey(k)) throw new InvalidOperationException($"locomotion: missing state \"{k}\"");
            foreach (var k in RequiredTerrain) if (!Terrain.ContainsKey(k)) throw new InvalidOperationException($"locomotion: missing terrain \"{k}\"");
            if (BaseSpeed <= 0) throw new InvalidOperationException("locomotion: baseSpeed must be > 0");
            foreach (var kv in State) if (kv.Value < 0) throw new InvalidOperationException($"locomotion: state \"{kv.Key}\" is negative");
            foreach (var kv in Terrain) if (kv.Value <= 0) throw new InvalidOperationException($"locomotion: terrain \"{kv.Key}\" must be > 0");
            foreach (var kv in Condition) if (kv.Value <= 0) throw new InvalidOperationException($"locomotion: condition \"{kv.Key}\" must be > 0");
            var t = BlendThresholds();
            for (int i = 1; i < t.Length; i++)
                if (!(t[i] > t[i - 1])) throw new InvalidOperationException($"locomotion: blend thresholds not ascending ({string.Join(", ", t)})");
        }

        static double Lookup(Dictionary<string, double> d, string key, string kind)
        {
            if (key == null || !d.TryGetValue(key, out var v)) throw new KeyNotFoundException($"locomotion: unknown {kind} \"{key}\"");
            return v;
        }
    }

    public sealed class SlopeTuning
    {
        public double LimitDeg { get; set; } = 50;
        public double UphillK { get; set; } = 0.8;
        public double DownhillK { get; set; } = 0.3;
        public double MinMult { get; set; } = 0.45;
        public double MaxMult { get; set; } = 1.25;
    }

    public sealed class BlendTuning
    {
        public double IdleMaxSpeed { get; set; } = 0.1;
        public double WalkEnter { get; set; } = 0.5;
        public double RunEnter { get; set; } = 4.0;
        public double SprintEnter { get; set; } = 8.0;
        public double Hysteresis { get; set; } = 0.25;
    }

    public sealed class DampingTuning
    {
        public double SpeedSec { get; set; } = 0.10;
        public double GroundedExitGraceSec { get; set; } = 0.08;
        public double CombatLayerBlendSec { get; set; } = 0.06;
        public double PelvisSec { get; set; } = 0.12;
    }
}
