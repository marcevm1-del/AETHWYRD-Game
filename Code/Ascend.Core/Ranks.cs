using System;

namespace Ascend.Core
{
    /// <summary>Adventurer/monster rank letters, in order. EX is monster-only.</summary>
    public enum RankLetter { F, E, D, C, B, A, S, SS, SSS, EX }

    /// <summary>A rank with its sub-grade, e.g. "C+", "SS-", "B". Ordered by <see cref="Value"/>.</summary>
    public readonly struct Rank : IComparable<Rank>, IEquatable<Rank>
    {
        public readonly RankLetter Letter;
        /// <summary>-1 for "-", 0 for none, +1 for "+".</summary>
        public readonly int Sub;

        public Rank(RankLetter letter, int sub = 0)
        {
            if (sub < -1 || sub > 1) throw new ArgumentOutOfRangeException(nameof(sub));
            Letter = letter;
            Sub = sub;
        }

        /// <summary>Total ordering value: 3 per letter, 0..29.</summary>
        public int Value => (int)Letter * 3 + Sub + 1;

        public static Rank FromValue(int value)
        {
            int max = ((int)RankLetter.EX) * 3 + 2;
            value = Math.Max(0, Math.Min(max, value));
            return new Rank((RankLetter)(value / 3), value % 3 - 1);
        }

        public Rank Shift(int steps) => FromValue(Value + steps);

        public static Rank Parse(string text)
        {
            if (!TryParse(text, out var rank)) throw new FormatException($"Invalid rank \"{text}\"");
            return rank;
        }

        public static bool TryParse(string text, out Rank rank)
        {
            rank = default;
            if (string.IsNullOrWhiteSpace(text)) return false;
            text = text.Trim();
            int sub = 0;
            char last = text[text.Length - 1];
            if (last == '+' || last == '-')
            {
                sub = last == '+' ? 1 : -1;
                text = text.Substring(0, text.Length - 1);
            }
            if (!Enum.TryParse(text, false, out RankLetter letter) || !Enum.IsDefined(typeof(RankLetter), letter)) return false;
            if (text != letter.ToString()) return false; // reject numeric strings like "3"
            rank = new Rank(letter, sub);
            return true;
        }

        public override string ToString() => Letter + (Sub > 0 ? "+" : Sub < 0 ? "-" : "");
        public int CompareTo(Rank other) => Value.CompareTo(other.Value);
        public bool Equals(Rank other) => Value == other.Value;
        public override bool Equals(object obj) => obj is Rank r && Equals(r);
        public override int GetHashCode() => Value;
        public static bool operator <(Rank a, Rank b) => a.Value < b.Value;
        public static bool operator >(Rank a, Rank b) => a.Value > b.Value;
        public static bool operator <=(Rank a, Rank b) => a.Value <= b.Value;
        public static bool operator >=(Rank a, Rank b) => a.Value >= b.Value;
        public static bool operator ==(Rank a, Rank b) => a.Value == b.Value;
        public static bool operator !=(Rank a, Rank b) => a.Value != b.Value;
    }

    /// <summary>Level bands per rank (Canon.md §2). Level cap is 300.</summary>
    public static class Levels
    {
        public const int Cap = 300;

        static readonly (int min, int max)[] Bands =
        {
            (1, 15), (16, 35), (36, 60), (61, 90), (91, 125), (126, 165), (166, 210), (211, 260), (261, 300), (300, 300)
        };

        public static (int min, int max) Band(RankLetter letter) => Bands[(int)letter];

        /// <summary>Typical level for a rank: 15% / 50% / 85% through the band for -, plain, +.</summary>
        public static int For(Rank rank)
        {
            var (a, b) = Band(rank.Letter);
            double t = rank.Sub < 0 ? 0.15 : rank.Sub > 0 ? 0.85 : 0.5;
            return (int)Math.Round(a + (b - a) * t, MidpointRounding.AwayFromZero);
        }

        /// <summary>Which rank band a character level falls into (EX is never returned).</summary>
        public static RankLetter BandOf(int level)
        {
            level = Math.Max(1, Math.Min(Cap, level));
            for (int i = 0; i < (int)RankLetter.SSS; i++)
                if (level <= Bands[i].max) return (RankLetter)i;
            return RankLetter.SSS;
        }
    }
}
