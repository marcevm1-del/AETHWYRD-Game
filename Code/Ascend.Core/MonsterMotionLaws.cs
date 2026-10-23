using System;

namespace Ascend.Core
{
    /// <summary>
    /// The scaling laws behind Data/Monsters/motion.json (same maths as Tools/monster_gen/motion.js).
    /// Use at runtime when a monster's size changes (Nemesis growth, evolution, giant variants) so its
    /// speed, mass, turn rate, play rate and attack windups stay consistent with the generated data.
    /// See 08_Bestiary/monster_motion_bible.md §2.
    /// </summary>
    public static class MonsterMotionLaws
    {
        public const double Gravity = 9.81;
        /// <summary>Human reference size used for attack timing (a 1.7 m creature = 1.0).</summary>
        public const double HumanSize = 1.7;

        static double Clamp(double v, double lo, double hi) => Math.Max(lo, Math.Min(hi, v));

        /// <summary>mass = shapeK · density · size³ (kg), never below 0.5 kg.</summary>
        public static double MassKg(double shapeK, double densityKgM3, double sizeMeters, double mult = 1.0)
            => Math.Max(0.5, shapeK * densityKgM3 * Math.Pow(sizeMeters, 3) * mult);

        /// <summary>Gait speed from the Froude number: v = √(Fr · g · legLength) · multiplier (m/s).</summary>
        public static double GaitSpeed(double froude, double legFrac, double sizeMeters, double multiplier = 1.0)
            => Clamp(Math.Sqrt(froude * Gravity * legFrac * sizeMeters) * multiplier, 0.15, 60);

        /// <summary>Animation play rate for a rig authored at refSize: √(refSize / size), clamped 0.4–1.6.</summary>
        public static double PlayRate(double refSize, double sizeMeters)
            => Clamp(Math.Sqrt(refSize / Math.Max(sizeMeters, 1e-3)), 0.4, 1.6);

        /// <summary>Turn rate (deg/s) = turnDegPerSecAt1m / √size, clamped 60–900.</summary>
        public static double TurnDegPerSec(double turnDegPerSecAt1m, double sizeMeters)
            => Clamp(turnDegPerSecAt1m / Math.Sqrt(Math.Max(sizeMeters, 0.2)), 60, 900);

        /// <summary>Attack timing multiplier from absolute size: √(size / 1.7 m), clamped 0.75–2.2.</summary>
        public static double SizeTime(double sizeMeters) => Clamp(Math.Sqrt(sizeMeters / HumanSize), 0.75, 2.2);

        /// <summary>Rank speed-up for windups: 1 − 0.035 per rank letter (F = 0), never below 0.6.</summary>
        public static double RankFactor(int rankIndex) => Math.Max(0.6, 1 - 0.035 * rankIndex);

        /// <summary>The fairness floor: no real attack telegraphs faster than this (seconds).</summary>
        public static double MinTelegraphSec(int rankIndex, double parryWindowSec = 0.12)
            => Math.Max(Math.Max(0.25, parryWindowSec + 0.18), 0.45 - rankIndex * 0.03);

        /// <summary>Shortest punish window after an attack (seconds).</summary>
        public static double MinRecoverySec(int rankIndex) => Math.Max(0.18, 0.32 - rankIndex * 0.015);

        /// <summary>
        /// Attack windup in seconds: base · sizeTime · rankFactor · menace · element · telegraphColor · power factor,
        /// never below the fairness floor.
        /// </summary>
        public static double WindupSec(double baseWindup, double sizeMeters, int rankIndex, double menaceMult = 1, double elementMult = 1,
            double telegraphMult = 1, double power = 1, double parryWindowSec = 0.12)
        {
            double powerF = Clamp(0.85 + 0.15 * power, 0.85, 1.4);
            double w = baseWindup * SizeTime(sizeMeters) * RankFactor(rankIndex) * menaceMult * elementMult * telegraphMult * powerF;
            return Math.Max(w, MinTelegraphSec(rankIndex, parryWindowSec));
        }

        /// <summary>Hit-stop multiplier for heavy creatures: 1 + log10(mass / 50) · 0.12, clamped 0.85–1.4.</summary>
        public static double HitstopMult(double massKg) => Clamp(1 + Math.Log10(Math.Max(massKg, 1) / 50) * 0.12, 0.85, 1.4);

        /// <summary>Footstep camera shake (0..shakeMax) from mass.</summary>
        public static double FootstepShake(double massKg, double shakeMax = 0.6, double elementMult = 1)
            => Clamp((massKg - 400) / 20000, 0, 1) * shakeMax * elementMult;

        /// <summary>Vocal pitch multiplier: (1 / size)^0.3, clamped 0.45–2.2.</summary>
        public static double VocalPitch(double sizeMeters) => Clamp(Math.Pow(1 / Math.Max(sizeMeters, 0.05), 0.3), 0.45, 2.2);
    }
}
