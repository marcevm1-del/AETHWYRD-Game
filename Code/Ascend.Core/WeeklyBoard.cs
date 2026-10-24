using System;
using System.Collections.Generic;
using System.Linq;

namespace Ascend.Core
{
    /// <summary>Mirror of one entry in Data/Quests/weekly_board.json (schema weekly_quest).</summary>
    public sealed class WeeklyQuestData
    {
        public string Id { get; set; }
        public string Title { get; set; }
        /// <summary>A weekday name, "Any" (filler pool) or "Week" (the weekly commission).</summary>
        public string Day { get; set; }
        /// <summary>"special", "daily" or "weekly".</summary>
        public string Slot { get; set; }
        public string Type { get; set; }
        public string Trope { get; set; }
        public string Giver { get; set; }
        public string Region { get; set; }
        public string RankMin { get; set; }
        public string RankMax { get; set; }
        /// <summary>"morning", "day", "dusk", "night" or "any".</summary>
        public string TimeOfDay { get; set; }
        /// <summary>"any", "besieged" or "liberated".</summary>
        public string RegionState { get; set; }
        public string Repeat { get; set; }
        public string Summary { get; set; }
        public List<QuestObjective> Objectives { get; set; } = new List<QuestObjective>();
        public QuestRewards Rewards { get; set; } = new QuestRewards();
        public List<string> Twists { get; set; } = new List<string>();

        /// <summary>As a journal quest (the board posts it; the journal tracks it like any other).</summary>
        public QuestData ToQuest() => new QuestData
        {
            Id = Id, Title = Title, Rank = RankMin, Type = Type, Giver = Giver, Region = Region, RegionState = RegionState,
            Summary = Summary, Objectives = Objectives, Rewards = Rewards ?? new QuestRewards(),
        };

        /// <summary>Objective kinds the Ring 0 build can track (all of them now: kill, collect, talk, reach, defend, choice, escort, tame).</summary>
        public bool Playable => Objectives.All(o => o.Kind != null);
    }

    /// <summary>One dawn's guild board (weekly_board.md §2–3).</summary>
    public sealed class DailyBoard
    {
        public int Day;
        public string Weekday;
        /// <summary>Tonight's siege attack, if any (posted as the top contract).</summary>
        public SiegeAttack Attack;
        public QuestData DefenceQuest;
        /// <summary>The weekday's Day Special, or null if already done this week / filtered out.</summary>
        public WeeklyQuestData Special;
        public List<WeeklyQuestData> Dailies = new List<WeeklyQuestData>();
        public WeeklyQuestData Weekly;
        /// <summary>Rolled twist per posted quest id.</summary>
        public Dictionary<string, string> Twists = new Dictionary<string, string>();

        /// <summary>Posted board quests in display order (Special, dailies, weekly). The defence is shown above these.</summary>
        public IEnumerable<WeeklyQuestData> Posted => new[] { Special }.Concat(Dailies).Concat(new[] { Weekly }).Where(q => q != null);

        /// <summary>
        /// Which posted quests can be taken now. Morning/day/dusk quests are open from dawn until their part of the day ends;
        /// night quests only open after dusk; "any" is always open.
        /// </summary>
        public IEnumerable<WeeklyQuestData> AvailableAt(DayPart now) => Posted.Where(q => WeeklyBoard.OpenAt(q.TimeOfDay, now));
    }

    /// <summary>Builds the dawn board: the weekday's Day Special (once per week), 3 dailies, the weekly commission, and the siege defence on attack days.</summary>
    public sealed class WeeklyBoard
    {
        public const int DailiesPerBoard = 3;
        readonly List<WeeklyQuestData> _quests;
        readonly GameCalendar _calendar;
        readonly ulong _seed;

        public WeeklyBoard(IEnumerable<WeeklyQuestData> quests, GameCalendar calendar, ulong worldSeed)
        {
            _quests = (quests ?? throw new ArgumentNullException(nameof(quests))).ToList();
            _calendar = calendar ?? throw new ArgumentNullException(nameof(calendar));
            _seed = worldSeed;
        }

        public static bool OpenAt(string timeOfDay, DayPart now)
        {
            switch (timeOfDay)
            {
                case "night": return now == DayPart.Night;
                case "morning": return now == DayPart.Morning;
                case "day": return now == DayPart.Morning || now == DayPart.Day;
                case "dusk": return now != DayPart.Night;
                default: return true;
            }
        }

        /// <param name="day">Absolute in-game day.</param>
        /// <param name="settlementId">Settlement/board key, so two towns roll different dailies.</param>
        /// <param name="regionState">Siege state of the board's region.</param>
        /// <param name="completedThisWeek">Board quest ids already finished this week (specials and the weekly don't come back until next week).</param>
        /// <param name="attackToday">Today's siege attack for this settlement, if any.</param>
        /// <param name="defenceTemplate">The region's SiegeDefence quest template.</param>
        public DailyBoard Build(int day, string settlementId, RegionState regionState, ICollection<string> completedThisWeek = null,
            SiegeAttack attackToday = null, QuestData defenceTemplate = null)
        {
            var done = completedThisWeek ?? new HashSet<string>();
            string weekday = _calendar.Weekday(day);
            bool Allowed(WeeklyQuestData q) => QuestGate.RegionStateAllows(q.RegionState, regionState);
            var rng = DeterministicRandom.For(_seed, "board", settlementId, day);

            var board = new DailyBoard { Day = day, Weekday = weekday };
            if (attackToday != null && regionState != RegionState.Liberated)
            {
                board.Attack = attackToday;
                board.DefenceQuest = defenceTemplate;
            }

            board.Special = _quests.FirstOrDefault(q => q.Slot == "special" && q.Day == weekday && Allowed(q) && !done.Contains(q.Id));

            var pool = _quests.Where(q => q.Slot == "daily" && (q.Day == weekday || q.Day == "Any") && Allowed(q))
                              .OrderBy(q => q.Id, StringComparer.Ordinal).ToList();
            // Deterministic partial shuffle: pick 3 without replacement.
            for (int i = 0; i < DailiesPerBoard && pool.Count > 0; i++)
            {
                int k = rng.Next(0, pool.Count);
                board.Dailies.Add(pool[k]);
                pool.RemoveAt(k);
            }

            board.Weekly = _quests.FirstOrDefault(q => q.Slot == "weekly" && Allowed(q) && !done.Contains(q.Id));

            foreach (var q in board.Posted)
                if (q.Twists != null && q.Twists.Count > 0) board.Twists[q.Id] = q.Twists[rng.Next(0, q.Twists.Count)];
            return board;
        }
    }
}
