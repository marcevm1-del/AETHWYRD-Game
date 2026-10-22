using System;
using System.Collections.Generic;
using System.Linq;

namespace Ascend.Core
{
    // Quests and NPCs (Data/Quests/quests.json, Data/NPCs/npcs.json, Data/Quests/story_flags.json).

    public sealed class QuestObjective { public string Kind { get; set; } public string Target { get; set; } public int Count { get; set; } = 1; }
    public sealed class QuestRewards { public int Gold { get; set; } public int Gp { get; set; } public int Xp { get; set; } public List<string> Items { get; set; } = new List<string>(); }
    public sealed class QuestRequirements { public int MinLevel { get; set; } public string PartySize { get; set; } }

    public sealed class QuestPrerequisites
    {
        public List<string> Quests { get; set; } = new List<string>();
        public List<string> Flags { get; set; } = new List<string>();
        /// <summary>Minimum story act (0 = prologue). Null = any.</summary>
        public int? Act { get; set; }
        /// <summary>Minimum adventurer rank letter. Null = any.</summary>
        public string Rank { get; set; }
    }

    public sealed class QuestData
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Rank { get; set; }
        public string Type { get; set; }
        public string Giver { get; set; }
        public string Region { get; set; }
        /// <summary>"any" (default), "besieged" or "liberated".</summary>
        public string RegionState { get; set; }
        public string Summary { get; set; }
        public QuestRequirements Requirements { get; set; }
        public QuestPrerequisites Prerequisites { get; set; }
        public List<string> SetsFlags { get; set; } = new List<string>();
        public List<QuestObjective> Objectives { get; set; } = new List<QuestObjective>();
        public QuestRewards Rewards { get; set; } = new QuestRewards();
    }

    public sealed class NpcState { public string Flag { get; set; } public string Name { get; set; } public string Role { get; set; } public string Settlement { get; set; } public string Note { get; set; } }
    public sealed class NpcScheduleEntry { public string Part { get; set; } public string Place { get; set; } public List<string> Days { get; set; } }

    public sealed class NpcData
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Tier { get; set; }
        public string Race { get; set; }
        public string HomeRegion { get; set; }
        public string Settlement { get; set; }
        public string Role { get; set; }
        public string Backstory { get; set; }
        public bool Romanceable { get; set; }
        public bool CanDie { get; set; }
        public List<NpcState> States { get; set; } = new List<NpcState>();
        public List<NpcScheduleEntry> Schedule { get; set; } = new List<NpcScheduleEntry>();

        /// <summary>The latest state whose flag is set (states are listed in story order), or null for the default.</summary>
        public NpcState CurrentState(ICollection<string> flags) =>
            States?.LastOrDefault(s => flags != null && flags.Contains(s.Flag));

        /// <summary>Where the NPC is during a day part, optionally on a given weekday.</summary>
        public string WhereAt(string part, string weekday = null)
        {
            var e = Schedule?.FirstOrDefault(s => s.Part == part && (s.Days == null || s.Days.Count == 0 || weekday == null || s.Days.Contains(weekday)));
            return e?.Place;
        }
    }

    public sealed class StoryFlagData { public string Id { get; set; } public string Description { get; set; } public string SetBy { get; set; } }

    /// <summary>What the game knows about the player when deciding whether a quest can be offered.</summary>
    public sealed class QuestContext
    {
        public ICollection<string> CompletedQuests { get; set; } = new HashSet<string>();
        public ICollection<string> Flags { get; set; } = new HashSet<string>();
        public int Act { get; set; }
        public RankLetter Rank { get; set; } = RankLetter.F;
        public int Level { get; set; } = 1;
        /// <summary>Siege state of the quest's region.</summary>
        public RegionState RegionState { get; set; } = RegionState.Besieged;
    }

    public static class QuestGate
    {
        public static bool RegionStateAllows(string questRegionState, RegionState state)
        {
            switch (questRegionState)
            {
                case "besieged": return state != RegionState.Liberated; // Weakened regions are still under siege
                case "liberated": return state == RegionState.Liberated;
                default: return true;
            }
        }

        public static bool IsAvailable(QuestData q, QuestContext ctx)
        {
            if (q == null) throw new ArgumentNullException(nameof(q));
            if (ctx == null) throw new ArgumentNullException(nameof(ctx));
            if (ctx.CompletedQuests.Contains(q.Id)) return false;
            if (!RegionStateAllows(q.RegionState, ctx.RegionState)) return false;
            if (q.Requirements != null && ctx.Level < q.Requirements.MinLevel) return false;
            var p = q.Prerequisites;
            if (p == null) return true;
            if (p.Quests != null && p.Quests.Any(x => !ctx.CompletedQuests.Contains(x))) return false;
            if (p.Flags != null && p.Flags.Any(x => !ctx.Flags.Contains(x))) return false;
            if (p.Act.HasValue && ctx.Act < p.Act.Value) return false;
            if (!string.IsNullOrEmpty(p.Rank) && Enum.TryParse(p.Rank, out RankLetter need) && ctx.Rank < need) return false;
            return true;
        }
    }
}
