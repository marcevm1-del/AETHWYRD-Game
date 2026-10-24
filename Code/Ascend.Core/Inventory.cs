using System;
using System.Collections.Generic;
using System.Linq;

namespace Ascend.Core
{
    /// <summary>
    /// The player's carried items and money. Money is stored in copper and displayed with change in the canonical
    /// denominations (Canon: copper → silver → gold → platinum → mithril, 100 each; world_tuning.json currency).
    /// </summary>
    public sealed class Inventory
    {
        readonly Dictionary<string, int> _items = new Dictionary<string, int>();

        public long Copper { get; private set; }
        /// <summary>Raised after any change to items or money (quest collect objectives, the HUD).</summary>
        public event Action Changed;
        public IReadOnlyDictionary<string, int> Items => _items;
        public int Count(string itemId) => _items.TryGetValue(itemId, out var n) ? n : 0;

        public void Add(string itemId, int count = 1)
        {
            if (string.IsNullOrEmpty(itemId) || count <= 0) return;
            _items[itemId] = Count(itemId) + count;
            Changed?.Invoke();
        }

        public bool TryRemove(string itemId, int count = 1)
        {
            if (count <= 0 || Count(itemId) < count) return false;
            int left = Count(itemId) - count;
            if (left == 0) _items.Remove(itemId); else _items[itemId] = left;
            Changed?.Invoke();
            return true;
        }

        public void AddCopper(long amount) { if (amount > 0) { Copper += amount; Changed?.Invoke(); } }

        public bool TrySpend(long amount)
        {
            if (amount < 0 || amount > Copper) return false;
            Copper -= amount;
            Changed?.Invoke();
            return true;
        }

        /// <summary>Removes up to <paramref name="amount"/> copper (death drops); returns what was taken.</summary>
        public long Take(long amount)
        {
            long t = Math.Max(0, Math.Min(Copper, amount));
            Copper -= t;
            if (t > 0) Changed?.Invoke();
            return t;
        }

        /// <summary>Restores items and money from a save.</summary>
        public void Load(long copper, IEnumerable<KeyValuePair<string, int>> items)
        {
            Copper = Math.Max(0, copper);
            _items.Clear();
            foreach (var kv in items ?? Enumerable.Empty<KeyValuePair<string, int>>()) if (!string.IsNullOrEmpty(kv.Key) && kv.Value > 0) _items[kv.Key] = Count(kv.Key) + kv.Value;
            Changed?.Invoke();
        }
    }

    public static class Money
    {
        /// <summary>"1 silver, 28 copper" (largest denominations first, zero parts omitted; "0 copper" for nothing).</summary>
        public static string Format(long copper, CurrencyTuning t)
        {
            var denoms = (t?.Denominations ?? new List<CurrencyDenomination>()).Where(d => d.ValueCopper > 0)
                .OrderByDescending(d => d.ValueCopper).ToList();
            if (denoms.Count == 0) return $"{copper} copper";
            if (copper <= 0) return $"0 {denoms.Last().Name.ToLowerInvariant()}";
            var parts = new List<string>();
            long left = copper;
            foreach (var d in denoms)
            {
                long n = left / d.ValueCopper;
                if (n <= 0) continue;
                parts.Add($"{n:N0} {d.Name.ToLowerInvariant()}");
                left -= n * d.ValueCopper;
            }
            return string.Join(", ", parts);
        }
    }

    public enum Difficulty { Story, Adventurer, Veteran, Hardcore }

    /// <summary>What dying costs (systems.md §10): Story nothing; Adventurer drops 10% of carried money at the death spot;
    /// Veteran also loses 5% of the XP toward the next level; Hardcore is permadeath. Gear never degrades (Canon §6 proposal).</summary>
    public struct DeathPenalty
    {
        public long DroppedCopper;
        public long XpLost;
        public bool Permadeath;
    }

    public static class DeathRules
    {
        public const double AdventurerDropFraction = 0.10, VeteranXpFraction = 0.05;

        public static DeathPenalty Apply(Difficulty mode, Inventory inv, PlayerProgress progress)
        {
            var p = new DeathPenalty();
            switch (mode)
            {
                case Difficulty.Story:
                    break;
                case Difficulty.Hardcore:
                    p.Permadeath = true;
                    break;
                case Difficulty.Veteran:
                    p.DroppedCopper = inv.Take((long)Math.Floor(inv.Copper * AdventurerDropFraction));
                    p.XpLost = progress != null ? progress.LoseXp((long)Math.Floor(progress.XpIntoLevel * VeteranXpFraction)) : 0;
                    break;
                default:
                    p.DroppedCopper = inv.Take((long)Math.Floor(inv.Copper * AdventurerDropFraction));
                    break;
            }
            return p;
        }
    }
}
