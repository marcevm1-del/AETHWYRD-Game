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
    /// Rolls a loot table. Each entry is rolled independently with its decimal chance (0.001 = 0.1% chase drop).
    /// Luck is a multiplier on every chance (1 = normal, 1.5 = +50%), capped at 100%.
    /// </summary>
    public static class LootRoller
    {
        public static List<LootDrop> Roll(LootTableData table, IRandom rng, double luckMultiplier = 1.0)
        {
            if (table == null) throw new ArgumentNullException(nameof(table));
            if (rng == null) throw new ArgumentNullException(nameof(rng));
            double luck = Math.Max(0, luckMultiplier);
            var drops = new List<LootDrop>();
            foreach (var e in table.Entries)
            {
                double chance = Math.Min(1.0, e.Chance * luck);
                if (rng.NextDouble() >= chance) continue;
                int min = Math.Max(0, e.Min), max = Math.Max(min, e.Max);
                int count = min + (int)Math.Floor(rng.NextDouble() * (max - min + 1));
                if (count > 0) drops.Add(new LootDrop { ItemId = e.ItemId, Count = count });
            }
            return drops;
        }
    }

    /// <summary>Poise / stagger meter for one enemy (combat.md §4.3). Regenerates after a delay without hits.</summary>
    public sealed class PoiseMeter
    {
        readonly double _regenDelay, _regenFractionPerSec;
        double _sinceHit;
        public int Max { get; }
        public double Current { get; private set; }

        public PoiseMeter(int max, double regenDelaySec = 0, double regenFractionPerSec = 0)
        {
            if (max <= 0) throw new ArgumentOutOfRangeException(nameof(max));
            Max = max; Current = max;
            _regenDelay = Math.Max(0, regenDelaySec);
            _regenFractionPerSec = Math.Max(0, regenFractionPerSec);
        }

        public static PoiseMeter For(string rig, CombatTuning t) =>
            new PoiseMeter(t.Poise.TryGetValue(rig.Replace("rig_", ""), out var p) ? p : 50, t.PoiseRegen.DelaySec, t.PoiseRegen.FractionPerSec);

        /// <summary>Applies poise damage; returns true if this hit caused a stagger (poise then refills).</summary>
        public bool Hit(double poiseDamage)
        {
            _sinceHit = 0;
            Current -= Math.Max(0, poiseDamage);
            if (Current > 0) return false;
            Current = Max;
            return true;
        }

        /// <summary>Regenerates poise once no hit has landed for the regen delay.</summary>
        public void Tick(double dt)
        {
            if (dt <= 0) return;
            _sinceHit += dt;
            if (_sinceHit <= _regenDelay || _regenFractionPerSec <= 0) return;
            double regenTime = Math.Min(dt, _sinceHit - _regenDelay);
            Current = Math.Min(Max, Current + Max * _regenFractionPerSec * regenTime);
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
