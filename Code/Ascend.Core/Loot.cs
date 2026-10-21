using System;
using System.Collections.Generic;
using System.Linq;

namespace Ascend.Core
{
    public struct LootDrop
    {
        public string ItemId;
        public int Count;
    }

    /// <summary>
    /// Rolls a loot table. Each entry is rolled independently with chance = weight / 100 (capped at 1),
    /// so a weight-100 entry (monster cores) always drops. Luck adds a flat bonus to each chance.
    /// </summary>
    public static class LootRoller
    {
        public static List<LootDrop> Roll(LootTableData table, IRandom rng, double luckBonus = 0)
        {
            if (table == null) throw new ArgumentNullException(nameof(table));
            if (rng == null) throw new ArgumentNullException(nameof(rng));
            var drops = new List<LootDrop>();
            foreach (var e in table.Entries)
            {
                double chance = Math.Min(1.0, e.Weight / 100.0 + luckBonus);
                if (rng.NextDouble() >= chance) continue;
                int min = Math.Max(0, e.Min), max = Math.Max(min, e.Max);
                int count = min + (int)Math.Floor(rng.NextDouble() * (max - min + 1));
                if (count > 0) drops.Add(new LootDrop { ItemId = e.ItemId, Count = count });
            }
            return drops;
        }
    }

    /// <summary>Poise / stagger meter for one enemy (combat.md §4.3).</summary>
    public sealed class PoiseMeter
    {
        public int Max { get; }
        public double Current { get; private set; }
        public PoiseMeter(int max) { if (max <= 0) throw new ArgumentOutOfRangeException(nameof(max)); Max = max; Current = max; }

        /// <summary>Applies poise damage; returns true if this hit caused a stagger (poise then refills).</summary>
        public bool Hit(double poiseDamage)
        {
            Current -= Math.Max(0, poiseDamage);
            if (Current > 0) return false;
            Current = Max;
            return true;
        }
    }

    /// <summary>Limits how many enemies attack at once (combat.md §10, aggro tokens).</summary>
    public sealed class AggroTokens
    {
        readonly HashSet<string> _holders = new HashSet<string>();
        public int Capacity { get; }
        public AggroTokens(int capacity) { Capacity = Math.Max(1, capacity); }
        public bool TryTake(string enemyId) => _holders.Contains(enemyId) || (_holders.Count < Capacity && _holders.Add(enemyId));
        public void Release(string enemyId) => _holders.Remove(enemyId);
        public IReadOnlyCollection<string> Holders => _holders.ToList();
    }
}
