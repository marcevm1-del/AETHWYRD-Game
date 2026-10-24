using System;
using System.Collections.Generic;
using System.Linq;

namespace Ascend.Core
{
    // Gathering nodes (12_Systems/systems.md §5: Mining / Logging / Herbalism). Data: Data/World/gathering.json.

    public sealed class GatherNodeData
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Skill { get; set; }
        /// <summary>In-game hours until it regrows.</summary>
        public double RespawnHours { get; set; } = 24;
        public List<LootEntry> Yields { get; set; } = new List<LootEntry>();

        public LootTableData AsLootTable() => new LootTableData { Id = Id, Entries = Yields };
    }

    public sealed class GatheringFile
    {
        public string Notes { get; set; }
        public List<GatherNodeData> Nodes { get; set; } = new List<GatherNodeData>();
    }

    /// <summary>One node in the world: ready, or regrowing until a given in-game hour.</summary>
    public sealed class GatherNodeState
    {
        readonly GatherNodeData _data;
        public GatherNodeState(GatherNodeData data) { _data = data ?? throw new ArgumentNullException(nameof(data)); }

        /// <summary>Absolute in-game hour (day × 24 + hour) it's ready again; ≤ now means ready.</summary>
        public double ReadyAtHour { get; set; } = double.MinValue;
        public bool Ready(double nowHour) => nowHour >= ReadyAtHour;

        /// <summary>Gathers if ready: the yields go into the inventory and the node starts regrowing. Empty if not ready.</summary>
        public List<LootDrop> Gather(double nowHour, Inventory inv, IRandom rng)
        {
            if (!Ready(nowHour)) return new List<LootDrop>();
            var drops = LootRoller.Roll(_data.AsLootTable(), rng);
            foreach (var d in drops) inv.Add(d.ItemId, d.Count);
            ReadyAtHour = nowHour + _data.RespawnHours;
            return drops;
        }
    }
}
