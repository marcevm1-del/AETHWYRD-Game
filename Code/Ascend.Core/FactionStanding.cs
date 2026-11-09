using System;
using System.Collections.Generic;
using System.Linq;

namespace Ascend.Core
{
    // Player standing with each monster group, lair types and world events, and core grade labels
    // (Canon section 6 proposals M1, M4, M5; bible sections 10, 11 and 12).
    // Data: Data/World/faction_relations.json, Data/World/lairs_and_events.json, Data/Items/grade_labels.json.
    // Standing is the PLAYER's relation to a group, tracked per group. It moves only through quests, flags and the player's own acts.
    // There is no enemy hierarchy and no autonomous faction war (Canon 4d); the ally and rival lists are flavour for writers.

    public sealed class PlayerStateData
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int MinPoints { get; set; }
    }

    public sealed class FactionGroupData
    {
        public string LineId { get; set; }
        public string DefaultState { get; set; } = "Neutral";
        public List<string> AllyLines { get; set; } = new List<string>();
        public List<string> RivalLines { get; set; } = new List<string>();
    }

    public sealed class FactionFile
    {
        public string Notes { get; set; }
        public List<PlayerStateData> PlayerStates { get; set; } = new List<PlayerStateData>();
        public Dictionary<string, int> StartingStandingPoints { get; set; } = new Dictionary<string, int>();
        public List<FactionGroupData> Groups { get; set; } = new List<FactionGroupData>();
    }

    public sealed class FactionSave
    {
        /// <summary>Line id to standing points, only for lines the player has changed.</summary>
        public Dictionary<string, int> Points { get; set; } = new Dictionary<string, int>();
    }

    public sealed class FactionStanding
    {
        public const int Min = -100, Max = 100;
        readonly FactionFile _file;
        readonly Dictionary<string, FactionGroupData> _byLine;
        readonly Dictionary<string, int> _changed = new Dictionary<string, int>();

        public FactionStanding(FactionFile file)
        {
            _file = file ?? new FactionFile();
            _byLine = _file.Groups.ToDictionary(g => g.LineId);
        }

        public event Action Changed;
        public IReadOnlyList<FactionGroupData> Groups => _file.Groups;

        public int Points(string lineId)
        {
            if (lineId == null || !_byLine.TryGetValue(lineId, out var g)) return 0;
            if (_changed.TryGetValue(lineId, out var p)) return p;
            return _file.StartingStandingPoints.TryGetValue(g.DefaultState, out var d) ? d : 0;
        }

        /// <summary>The named state for a number of points: the highest state whose threshold is met.</summary>
        public string StateName(int points)
        {
            var s = _file.PlayerStates.OrderBy(x => x.MinPoints).LastOrDefault(x => points >= x.MinPoints);
            return (s ?? _file.PlayerStates.OrderBy(x => x.MinPoints).FirstOrDefault())?.Name ?? "Neutral";
        }

        public string State(string lineId) => StateName(Points(lineId));

        /// <summary>Moves standing with one group (clamped to -100 to 100). Returns the new points. Unknown lines change nothing.</summary>
        public int Shift(string lineId, int delta)
        {
            if (lineId == null || !_byLine.ContainsKey(lineId)) return 0;
            int now = Math.Max(Min, Math.Min(Max, Points(lineId) + delta));
            _changed[lineId] = now;
            Changed?.Invoke();
            return now;
        }

        /// <summary>Groups the flavour table lists as allies or rivals of a group. Used for writing and events, never for rules.</summary>
        public IEnumerable<string> AlliesOf(string lineId) => _byLine.TryGetValue(lineId ?? "", out var g) ? g.AllyLines : new List<string>();
        public IEnumerable<string> RivalsOf(string lineId) => _byLine.TryGetValue(lineId ?? "", out var g) ? g.RivalLines : new List<string>();

        public FactionSave Save() => new FactionSave { Points = new Dictionary<string, int>(_changed) };

        public void Load(FactionSave s)
        {
            _changed.Clear();
            foreach (var kv in s?.Points ?? new Dictionary<string, int>())
                if (_byLine.ContainsKey(kv.Key)) _changed[kv.Key] = Math.Max(Min, Math.Min(Max, kv.Value));
            Changed?.Invoke();
        }
    }

    public sealed class LairTypeData
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<string> InhabitantLines { get; set; } = new List<string>();
        public string SignatureFeatures { get; set; }
    }

    public sealed class WorldEventData
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public List<string> Lines { get; set; } = new List<string>();
        public List<string> RequestedBy { get; set; } = new List<string>();
        public string Scope { get; set; }
    }

    public sealed class LairFile
    {
        public string Notes { get; set; }
        public List<LairTypeData> LocationTypes { get; set; } = new List<LairTypeData>();
        public List<WorldEventData> WorldEvents { get; set; } = new List<WorldEventData>();

        public IEnumerable<LairTypeData> LairsFor(string lineId) => LocationTypes.Where(l => l.InhabitantLines.Contains(lineId));
        public IEnumerable<WorldEventData> EventsRequestedBy(string guildId) => WorldEvents.Where(e => e.RequestedBy.Contains(guildId));
    }

    public sealed class GradeLabelData
    {
        public string Id { get; set; }
        public int Tier { get; set; }
        public string Name { get; set; }
        public string ItemRarity { get; set; }
    }

    /// <summary>Core and harvest grade names (Cracked to Mythic) as display labels over the existing item rarity. No second economy.</summary>
    public sealed class GradeFile
    {
        public string Notes { get; set; }
        public List<GradeLabelData> Grades { get; set; } = new List<GradeLabelData>();

        /// <summary>The label for an item rarity: Cracked stands for a damaged Common, Mythic for a world-scale Legendary.</summary>
        public string LabelFor(string itemRarity, bool damaged = false, bool worldScale = false)
        {
            if (damaged) return Grades.FirstOrDefault(g => g.Name == "Cracked")?.Name;
            if (worldScale && itemRarity == "Legendary") return Grades.FirstOrDefault(g => g.Name == "Mythic")?.Name;
            if (itemRarity == "Common") return Grades.FirstOrDefault(g => g.Name == "Common")?.Name;
            return Grades.FirstOrDefault(g => g.ItemRarity == itemRarity)?.Name;
        }
    }
}
