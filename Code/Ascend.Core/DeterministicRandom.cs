using System;

namespace Ascend.Core
{
    /// <summary>
    /// SplitMix64-based random source. Unlike System.Random, its sequence is defined here, so schedules
    /// (sieges, weekly boards) are identical in tests, in Unity (Mono/IL2CPP) and across save/load.
    /// </summary>
    public sealed class DeterministicRandom : IRandom
    {
        ulong _state;
        public DeterministicRandom(ulong seed) { _state = seed; }

        public ulong NextULong()
        {
            ulong z = (_state += 0x9E3779B97F4A7C15UL);
            z = (z ^ (z >> 30)) * 0xBF58476D1CE4E5B9UL;
            z = (z ^ (z >> 27)) * 0x94D049BB133111EBUL;
            return z ^ (z >> 31);
        }

        /// <summary>Uniform double in [0, 1).</summary>
        public double NextDouble() => (NextULong() >> 11) * (1.0 / (1UL << 53));

        /// <summary>Uniform int in [min, maxExclusive).</summary>
        public int Next(int min, int maxExclusive)
        {
            if (maxExclusive <= min) return min;
            return min + (int)(NextULong() % (ulong)(maxExclusive - min));
        }

        /// <summary>Stable 64-bit seed from a world seed plus any mix of strings and numbers.</summary>
        public static ulong Seed(ulong worldSeed, params object[] parts)
        {
            ulong h = 14695981039346656037UL ^ worldSeed; // FNV-1a
            foreach (var p in parts)
            {
                var s = p?.ToString() ?? "";
                foreach (char c in s) { h ^= c; h *= 1099511628211UL; }
                h ^= 0x1F; h *= 1099511628211UL; // separator
            }
            return h;
        }

        public static DeterministicRandom For(ulong worldSeed, params object[] parts) => new DeterministicRandom(Seed(worldSeed, parts));
    }
}
