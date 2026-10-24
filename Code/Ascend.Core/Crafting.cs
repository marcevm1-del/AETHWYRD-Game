using System;
using System.Collections.Generic;
using System.Linq;

namespace Ascend.Core
{
    // Crafting (12_Systems/systems.md §5; 09_Equipment/item_and_economy_design.md §6). Data: Data/Items/recipes.json.

    public sealed class ItemCount { public string ItemId { get; set; } public int Count { get; set; } = 1; }
    public sealed class RecipeTeacher { public string NpcId { get; set; } public int Price { get; set; } }

    public sealed class RecipeData
    {
        public string Id { get; set; }
        public string Name { get; set; }
        /// <summary>The life skill (alchemy, blacksmithing, cooking…).</summary>
        public string Skill { get; set; }
        /// <summary>Where it's made: a crafter's workbench (forge, alembic) or "campfire" (anywhere).</summary>
        public string Station { get; set; }
        public ItemCount Output { get; set; } = new ItemCount();
        public List<ItemCount> Inputs { get; set; } = new List<ItemCount>();
        /// <summary>Who teaches it, for how much copper. Null: known from the start.</summary>
        public RecipeTeacher LearnFrom { get; set; }
    }

    public sealed class RecipeFile
    {
        public string Notes { get; set; }
        /// <summary>Station → the NPC whose workbench it is (null: usable anywhere, like a campfire).</summary>
        public Dictionary<string, string> Stations { get; set; } = new Dictionary<string, string>();
        public List<RecipeData> Recipes { get; set; } = new List<RecipeData>();
    }

    public enum CraftResult { Ok, Unknown, WrongStation, MissingMaterials, AlreadyKnown, NotEnoughMoney, NotTaughtHere }

    /// <summary>
    /// What the player knows and can make. Recipes are learned from their teacher (or known from the start); a craft
    /// needs the right station and every input, consumes them and gives the output. Standard quality for now — the
    /// optional mini-games (quality tiers, crafter's mark) come later; skipping them always gives this result.
    /// </summary>
    public sealed class Crafter
    {
        readonly RecipeFile _file;
        readonly HashSet<string> _known = new HashSet<string>();

        public Crafter(RecipeFile file)
        {
            _file = file ?? new RecipeFile();
            foreach (var r in _file.Recipes) if (r.LearnFrom == null) _known.Add(r.Id);
        }

        public IEnumerable<RecipeData> All => _file.Recipes;
        public ICollection<string> Known => _known;
        public bool Knows(string recipeId) => _known.Contains(recipeId);
        public RecipeData Recipe(string id) => _file.Recipes.FirstOrDefault(r => r.Id == id);

        /// <summary>The station an NPC keeps (null if none).</summary>
        public string StationOf(string npcId) => npcId == null ? null : _file.Stations.FirstOrDefault(kv => kv.Value == npcId).Key;

        /// <summary>Is this station usable here? Campfire-type stations (no owner) are usable anywhere.</summary>
        public bool StationAvailable(string station, string atNpcId) =>
            _file.Stations.TryGetValue(station ?? "", out var owner) && (owner == null || owner == atNpcId);

        public IEnumerable<RecipeData> TaughtBy(string npcId) => _file.Recipes.Where(r => r.LearnFrom != null && r.LearnFrom.NpcId == npcId);

        public CraftResult Learn(string recipeId, Inventory inv, string atNpcId)
        {
            var r = Recipe(recipeId);
            if (r == null) return CraftResult.Unknown;
            if (_known.Contains(r.Id)) return CraftResult.AlreadyKnown;
            if (r.LearnFrom == null || r.LearnFrom.NpcId != atNpcId) return CraftResult.NotTaughtHere;
            if (!inv.TrySpend(r.LearnFrom.Price)) return CraftResult.NotEnoughMoney;
            _known.Add(r.Id);
            return CraftResult.Ok;
        }

        /// <summary>How many of each input you're short (empty when you can make it).</summary>
        public List<ItemCount> Missing(RecipeData r, Inventory inv) =>
            r.Inputs.Where(i => inv.Count(i.ItemId) < i.Count).Select(i => new ItemCount { ItemId = i.ItemId, Count = i.Count - inv.Count(i.ItemId) }).ToList();

        public CraftResult CanCraft(string recipeId, Inventory inv, string atNpcId)
        {
            var r = Recipe(recipeId);
            if (r == null || !_known.Contains(r.Id)) return CraftResult.Unknown;
            if (!StationAvailable(r.Station, atNpcId)) return CraftResult.WrongStation;
            return Missing(r, inv).Count > 0 ? CraftResult.MissingMaterials : CraftResult.Ok;
        }

        public CraftResult Craft(string recipeId, Inventory inv, string atNpcId)
        {
            var can = CanCraft(recipeId, inv, atNpcId);
            if (can != CraftResult.Ok) return can;
            var r = Recipe(recipeId);
            foreach (var i in r.Inputs) inv.TryRemove(i.ItemId, i.Count);
            inv.Add(r.Output.ItemId, Math.Max(1, r.Output.Count));
            return CraftResult.Ok;
        }

        public void Load(IEnumerable<string> known)
        {
            foreach (var id in known ?? Enumerable.Empty<string>()) if (Recipe(id) != null) _known.Add(id);
        }
    }
}
