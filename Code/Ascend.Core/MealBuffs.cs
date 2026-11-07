using System;
using System.Collections.Generic;

namespace Ascend.Core
{
    // Cooking buffs (crafting_v6_audit.md section 3.4): one "Well Fed" slot, replaced by the next meal, expires silently.
    // No hunger, thirst or upkeep anywhere. Not saved (the buffs are short).

    public sealed class MealEffect { public string Stat { get; set; } public double Amount { get; set; } }

    /// <summary>The optional "meal" block on an item.</summary>
    public sealed class MealData
    {
        public List<MealEffect> Effects { get; set; } = new List<MealEffect>();
        public double Seconds { get; set; }
    }

    public sealed class MealBuffs
    {
        public const double MaxDurationScale = 2.0;
        public const string SlotName = "Well Fed";

        readonly Func<string, ItemData> _lookup;
        readonly QualityRules _rules;
        List<MealEffect> _effects = new List<MealEffect>();
        double _expiresAt = double.NegativeInfinity;

        public MealBuffs(IReadOnlyDictionary<string, ItemData> items, QualityRules rules)
        {
            _lookup = id => id != null && items != null && items.TryGetValue(id, out var d) ? d : null;
            _rules = rules ?? new QualityRules();
        }

        /// <summary>The meal that fills the slot (stack key including quality), or null.</summary>
        public string ItemKey { get; private set; }
        public double ExpiresAt => _expiresAt;

        /// <summary>
        /// Eats a meal: false if the item is not a meal (or, when an inventory is given, you hold none). The slot is
        /// replaced, never stacked. Effects scale by the quality buffMult; the duration too, capped at twice the base.
        /// </summary>
        public bool Eat(string itemKey, double nowSeconds, Inventory inv = null)
        {
            var (id, tier) = ItemQuality.Split(itemKey);
            var meal = _lookup(id)?.Meal;
            if (meal == null || meal.Effects == null || meal.Effects.Count == 0 || meal.Seconds <= 0) return false;
            if (inv != null && !inv.TryRemove(itemKey)) return false;
            double mult = _rules.BuffMult(tier);
            _effects = new List<MealEffect>();
            foreach (var e in meal.Effects) _effects.Add(new MealEffect { Stat = e.Stat, Amount = e.Amount * mult });
            _expiresAt = nowSeconds + meal.Seconds * Math.Min(mult, MaxDurationScale);
            ItemKey = itemKey;
            return true;
        }

        public bool IsActive(double nowSeconds) => nowSeconds < _expiresAt;

        /// <summary>The current effects (empty once expired).</summary>
        public IReadOnlyList<MealEffect> Active(double nowSeconds)
        {
            if (!IsActive(nowSeconds)) { Clear(); return Array.Empty<MealEffect>(); }
            return _effects;
        }

        public double SecondsLeft(double nowSeconds) => Math.Max(0, _expiresAt - nowSeconds);

        /// <summary>Total of one stat across the active effects.</summary>
        public double Total(string stat, double nowSeconds)
        {
            double t = 0;
            foreach (var e in Active(nowSeconds)) if (e.Stat == stat) t += e.Amount;
            return t;
        }

        void Clear() { _effects = new List<MealEffect>(); ItemKey = null; _expiresAt = double.NegativeInfinity; }
    }
}
