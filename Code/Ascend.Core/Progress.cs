using System;

namespace Ascend.Core
{
    /// <summary>
    /// A character's level and XP (Data/Classes/progression.json → xp). XP is total XP earned; levels follow the
    /// XpCurve up to the level cap. Kills give MonsterXp(level) times the Style Rank's XP bonus (combat.md §8).
    /// </summary>
    public sealed class PlayerProgress
    {
        readonly XpCurve _curve;

        public int Level { get; private set; }
        /// <summary>XP earned inside the current level (resets on level-up).</summary>
        public long XpIntoLevel { get; private set; }
        public long ToNext => Level >= Levels.Cap ? 0 : _curve.ToNext(Level);
        public RankLetter RankBand => Levels.BandOf(Level);

        public PlayerProgress(ProgressionRules rules, int level = 1)
        {
            _curve = new XpCurve((rules ?? throw new ArgumentNullException(nameof(rules))).Xp);
            Level = Math.Max(1, Math.Min(Levels.Cap, level));
        }

        /// <summary>Adds XP; returns how many levels were gained.</summary>
        public int AddXp(long xp)
        {
            if (xp <= 0 || Level >= Levels.Cap) return 0;
            int gained = 0;
            XpIntoLevel += xp;
            while (Level < Levels.Cap && XpIntoLevel >= ToNext)
            {
                XpIntoLevel -= ToNext;
                Level++;
                gained++;
            }
            if (Level >= Levels.Cap) XpIntoLevel = 0;
            return gained;
        }

        /// <summary>Loses XP inside the current level only (never a level-down); returns the amount lost.</summary>
        public long LoseXp(long xp)
        {
            long lost = Math.Max(0, Math.Min(XpIntoLevel, xp));
            XpIntoLevel -= lost;
            return lost;
        }

        /// <summary>Restores level and XP from a save.</summary>
        public void Load(int level, long xpIntoLevel)
        {
            Level = Math.Max(1, Math.Min(Levels.Cap, level));
            XpIntoLevel = Math.Max(0, xpIntoLevel);
        }

        /// <summary>XP for defeating a monster of <paramref name="monsterLevel"/> at the given Style Rank.</summary>
        public long KillXp(int monsterLevel, bool unique, StyleRank style, StyleTuning styleTuning) =>
            (long)Math.Round(_curve.MonsterXp(Math.Max(1, monsterLevel), unique) * (1 + StyleRewards.XpBonus(style, styleTuning)));
    }

    /// <summary>Style Rank rewards (combat.md §8): extra XP and drop rate by rank, from combat_tuning.json style.</summary>
    public static class StyleRewards
    {
        public static double XpBonus(StyleRank rank, StyleTuning t) =>
            t?.XpBonus != null && t.XpBonus.TryGetValue(rank.ToString(), out var b) ? b : 0;

        public static double DropBonus(StyleRank rank, StyleTuning t) =>
            t?.DropBonus != null && t.DropBonus.TryGetValue(rank.ToString(), out var b) ? b : 0;
    }
}
