using System.Collections.Generic;
using System.Linq;
using Ascend.Core;
using UnityEngine;

namespace Ascend.Game
{
    /// <summary>
    /// The Adventurers' Guild board (Core WeeklyBoard; weekly_board.json): each dawn it posts the weekday's Day Special,
    /// three dailies and the weekly commission, plus a raid warning on siege days. Quests open at their time of day
    /// (a "night" job can only be taken at night); once taken they track in the journal and are handed in here.
    /// Dailies come back the next day; the special and the weekly once a week. Talk to it like an NPC (it carries a
    /// QuestGiver for the guild clerk).
    /// </summary>
    [RequireComponent(typeof(QuestGiver))]
    public sealed class QuestBoard : MonoBehaviour
    {
        [SerializeField] string boardId = "brindlewick";
        [SerializeField] string regionId = "reg_whisperwood";
        [SerializeField] ulong worldSeed = 7;

        WeeklyBoard _board;

        void Awake()
        {
            var db = AscendData.Db;
            _board = new WeeklyBoard(db.WeeklyQuests.Values, new GameCalendar(db.World.Calendar), worldSeed);
        }

        /// <summary>Today's board.</summary>
        public DailyBoard Today(PlayerQuests quests)
        {
            var clock = WorldClock.Instance;
            int day = clock != null ? clock.Day : 0;
            var siege = SiegeDirector.Instance;
            var state = siege != null && siege.Governs(regionId) ? siege.Threat.State : RegionState.Besieged;
            var attack = siege != null ? siege.NextAttack() : null;
            if (attack != null && attack.Day != day) attack = null;
            return _board.Build(day, boardId, state, quests.BoardDoneThisWeek(day), attack);
        }

        /// <summary>Board quests you can take right now (open at this time of day, not already taken or done today).</summary>
        public IEnumerable<WeeklyQuestData> Takeable(PlayerQuests quests)
        {
            var clock = WorldClock.Instance;
            var part = clock != null ? clock.Part : DayPart.Day;
            int day = clock != null ? clock.Day : 0;
            return Today(quests).AvailableAt(part).Where(w => w.Playable && !quests.Log.IsActive(w.Id) && !quests.BoardDoneOn(w.Id, day));
        }

        /// <summary>Posted today but not open at this hour (shown greyed, with when they open).</summary>
        public IEnumerable<WeeklyQuestData> Later(PlayerQuests quests)
        {
            var clock = WorldClock.Instance;
            var part = clock != null ? clock.Part : DayPart.Day;
            int day = clock != null ? clock.Day : 0;
            return Today(quests).Posted.Where(w => w.Playable && !WeeklyBoard.OpenAt(w.TimeOfDay, part) && !quests.Log.IsActive(w.Id) && !quests.BoardDoneOn(w.Id, day));
        }
    }
}
