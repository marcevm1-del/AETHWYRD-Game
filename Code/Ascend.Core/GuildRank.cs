using System;
using System.Collections.Generic;
using System.Linq;

namespace Ascend.Core
{
    // Adventurer rank (03_Rank_System/ranks.md §2). Data: Data/World/guild_ranks.json.

    public sealed class PromotionData
    {
        public string From { get; set; }
        public string To { get; set; }
        public int Level { get; set; }
        public int Gp { get; set; }
        public int QuestsAtRank { get; set; }
        /// <summary>A non-combat requirement checked by key (life_skill, dungeon, advanced_class…).</summary>
        public string Special { get; set; }
        public string SpecialText { get; set; }
        /// <summary>The trial quest; the promotion needs it completed. Null: that trial isn't built yet.</summary>
        public string TrialQuestId { get; set; }
        public string TrialName { get; set; }
        /// <summary>The Rank Gift item (ranks.md §4).</summary>
        public string Gift { get; set; }
    }

    public sealed class GuildRankData
    {
        public string Notes { get; set; }
        public Dictionary<string, string> Titles { get; set; } = new Dictionary<string, string>();
        public Dictionary<string, string> Cards { get; set; } = new Dictionary<string, string>();
        /// <summary>Quest rank minus your rank → GP multiplier; anything lower than the lowest key pays no GP.</summary>
        public Dictionary<string, double> GpByRankDifference { get; set; } = new Dictionary<string, double>();
        public List<PromotionData> Promotions { get; set; } = new List<PromotionData>();
    }

    /// <summary>One promotion requirement and whether it's met (for the Status Window checklist).</summary>
    public struct RankRequirement
    {
        public string Text;
        public bool Met;
    }

    /// <summary>
    /// Your adventurer rank and the road to the next one: GP (scaled by quest rank vs yours), quests completed at your
    /// rank, level, the special requirement and the trial. Promotion happens at the Guild (the rank-up ceremony).
    /// </summary>
    public sealed class GuildRank
    {
        readonly GuildRankData _data;

        public GuildRank(GuildRankData data) { _data = data ?? new GuildRankData(); }

        public RankLetter Rank { get; private set; } = RankLetter.F;
        public int Gp { get; private set; }
        public int QuestsAtRank { get; private set; }
        public string Title => _data.Titles.TryGetValue(Rank.ToString(), out var t) ? t : Rank.ToString();
        public string Card => _data.Cards.TryGetValue(Rank.ToString(), out var c) ? c : "";
        public PromotionData Next => _data.Promotions.FirstOrDefault(p => p.From == Rank.ToString());

        /// <summary>GP multiplier for a quest of <paramref name="questRank"/> ("F", "E+", …).</summary>
        public double GpMultiplier(string questRank)
        {
            if (!Core.Rank.TryParse(questRank ?? "", out var q)) return 1.0;
            int diff = (int)q.Letter - (int)Rank;
            if (_data.GpByRankDifference.TryGetValue(diff.ToString(), out var m)) return m;
            var keys = _data.GpByRankDifference.Keys.Select(int.Parse).ToList();
            if (keys.Count == 0) return 1.0;
            return diff > keys.Max() ? _data.GpByRankDifference[keys.Max().ToString()] : 0.0; // above: as the highest allowed; far below: none
        }

        /// <summary>A quest handed in: returns the GP actually gained.</summary>
        public int QuestCompleted(string questRank, int baseGp)
        {
            int gp = (int)Math.Round(Math.Max(0, baseGp) * GpMultiplier(questRank), MidpointRounding.AwayFromZero);
            Gp += gp;
            if (Core.Rank.TryParse(questRank ?? "", out var q) && q.Letter == Rank) QuestsAtRank++;
            return gp;
        }

        public List<RankRequirement> Requirements(int level, Func<string, bool> special, ICollection<string> completedQuests)
        {
            var p = Next;
            var list = new List<RankRequirement>();
            if (p == null) return list;
            list.Add(new RankRequirement { Text = $"Level {p.Level}", Met = level >= p.Level });
            list.Add(new RankRequirement { Text = $"{Gp}/{p.Gp} GP", Met = Gp >= p.Gp });
            list.Add(new RankRequirement { Text = $"{QuestsAtRank}/{p.QuestsAtRank} quests at rank {Rank}", Met = QuestsAtRank >= p.QuestsAtRank });
            if (!string.IsNullOrEmpty(p.Special)) list.Add(new RankRequirement { Text = p.SpecialText ?? p.Special, Met = special != null && special(p.Special) });
            list.Add(new RankRequirement
            {
                Text = $"Trial: {p.TrialName}" + (p.TrialQuestId == null ? " (not in this build)" : ""),
                Met = p.TrialQuestId != null && completedQuests != null && completedQuests.Contains(p.TrialQuestId),
            });
            return list;
        }

        public bool CanPromote(int level, Func<string, bool> special, ICollection<string> completedQuests) =>
            Next != null && Requirements(level, special, completedQuests).All(r => r.Met);

        /// <summary>The ceremony: next rank, the at-rank quest count starts over (GP carries on). Returns the promotion.</summary>
        public PromotionData Promote(int level, Func<string, bool> special, ICollection<string> completedQuests)
        {
            if (!CanPromote(level, special, completedQuests)) return null;
            var p = Next;
            Rank = (RankLetter)Enum.Parse(typeof(RankLetter), p.To);
            QuestsAtRank = 0;
            return p;
        }

        public void Load(RankLetter rank, int gp, int questsAtRank) { Rank = rank; Gp = Math.Max(0, gp); QuestsAtRank = Math.Max(0, questsAtRank); }
    }
}
