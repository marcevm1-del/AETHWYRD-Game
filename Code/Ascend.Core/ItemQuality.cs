using System;
using System.Collections.Generic;
using System.Linq;

namespace Ascend.Core
{
    // Item quality (13_Production/crafting_v6_audit.md section 3.1). Data: Data/Items/crafting_rules.json.

    public sealed class QualityTierData
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Index { get; set; }
        public double StatMult { get; set; } = 1;
        public double ValueMult { get; set; } = 1;
        public double BuffMult { get; set; } = 1;
        /// <summary>Crafter mark (Fine and above).</summary>
        public bool Mark { get; set; }
        /// <summary>The crafter may name it (Masterwork and above).</summary>
        public bool Nameable { get; set; }
        /// <summary>False for Legendary (quest and Tyrant recipes only).</summary>
        public bool Craftable { get; set; } = true;
    }

    public sealed class QualityFormula
    {
        public double SkillBonusPerRank { get; set; } = 0.25;
        public double ExperimentBonus { get; set; } = 0.5;
        public double JitterMax { get; set; } = 0.2;
        public int TierAboveBest { get; set; } = 1;
    }

    /// <summary>Data/Items/crafting_rules.json plus lookups. An empty instance (file not loaded) treats every tier as 1.0 and Normal.</summary>
    public sealed class QualityRules
    {
        public const string NormalId = "normal";

        public string Notes { get; set; }
        public List<QualityTierData> QualityTiers { get; set; } = new List<QualityTierData>();
        public QualityFormula Formula { get; set; } = new QualityFormula();
        public Dictionary<string, string> RankQualityCap { get; set; } = new Dictionary<string, string>();
        public Dictionary<string, string> StationQualityCap { get; set; } = new Dictionary<string, string>();

        public QualityTierData Tier(string id) => QualityTiers.FirstOrDefault(t => t.Id == id);
        public QualityTierData TierAt(int index) => QualityTiers.FirstOrDefault(t => t.Index == index);

        /// <summary>The tier's index; unknown or empty ids count as Normal.</summary>
        public int IndexOf(string tierId)
        {
            if (string.IsNullOrEmpty(tierId)) tierId = NormalId;
            var t = Tier(tierId);
            if (t != null) return t.Index;
            return Tier(NormalId)?.Index ?? 1;
        }

        public int NormalIndex => IndexOf(NormalId);
        /// <summary>Highest tier a recipe can produce.</summary>
        public int MaxCraftableIndex => QualityTiers.Where(t => t.Craftable).Select(t => t.Index).DefaultIfEmpty(NormalIndex).Max();

        public double StatMult(string tierId) => Tier(tierId ?? NormalId)?.StatMult ?? 1;
        public double ValueMult(string tierId) => Tier(tierId ?? NormalId)?.ValueMult ?? 1;
        public double BuffMult(string tierId) => Tier(tierId ?? NormalId)?.BuffMult ?? 1;
        public bool Mark(string tierId) => Tier(tierId ?? NormalId)?.Mark ?? false;
        public bool Nameable(string tierId) => Tier(tierId ?? NormalId)?.Nameable ?? false;

        /// <summary>Tier cap for a rank letter, or int.MaxValue when the rank has no entry.</summary>
        public int RankCapIndex(string rank) => RankQualityCap != null && rank != null && RankQualityCap.TryGetValue(rank, out var t) ? IndexOf(t) : int.MaxValue;
        /// <summary>Tier cap for a station, or int.MaxValue when the station has no entry.</summary>
        public int StationCapIndex(string station) => StationQualityCap != null && station != null && StationQualityCap.TryGetValue(station, out var t) ? IndexOf(t) : int.MaxValue;
    }

    /// <summary>Inventory stack keys: "itemId" for Normal, "itemId@tier" otherwise. Plain ids (old saves, old tests) stay Normal.</summary>
    public static class ItemQuality
    {
        public const char Separator = '@';

        public static string Compose(string itemId, string tierId)
        {
            if (string.IsNullOrEmpty(itemId)) return itemId;
            if (string.IsNullOrEmpty(tierId) || tierId == QualityRules.NormalId) return itemId;
            return itemId + Separator + tierId;
        }

        public static (string ItemId, string TierId) Split(string key)
        {
            if (string.IsNullOrEmpty(key)) return (key, QualityRules.NormalId);
            int i = key.IndexOf(Separator);
            if (i <= 0 || i == key.Length - 1) return (key, QualityRules.NormalId);
            return (key.Substring(0, i), key.Substring(i + 1));
        }

        public static string BaseId(string key) => Split(key).ItemId;

        /// <summary>The one way to look an inventory/slot key up in the item table: "itm_x@fine" resolves to "itm_x"'s data. False for null/unknown.</summary>
        public static bool TryGetItem(IReadOnlyDictionary<string, ItemData> items, string key, out ItemData item)
        {
            item = null;
            if (items == null || string.IsNullOrEmpty(key)) return false;
            return items.TryGetValue(BaseId(key), out item);
        }
    }
}
