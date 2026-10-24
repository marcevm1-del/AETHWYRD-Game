using System.Collections.Generic;
using System.Linq;
using Ascend.Core;
using UnityEngine;

namespace Ascend.Game
{
    /// <summary>
    /// Crafting in play (Core Crafter; recipes.json): learn recipes from their teachers, make them at the teacher's
    /// workbench (Torvald's forge, Fennick's alembic) through the talk window, or cook campfire recipes anywhere from
    /// the bag. Standard quality until the optional mini-games arrive.
    /// </summary>
    [RequireComponent(typeof(PlayerInventory))]
    public sealed class PlayerCrafting : MonoBehaviour
    {
        PlayerInventory _inv;

        public Crafter Crafter { get; private set; }

        void Awake()
        {
            _inv = GetComponent<PlayerInventory>();
            Crafter = new Crafter(AscendData.Db.Recipes);
            _inv.Items.Changed += NoticeItems;
        }

        void OnDestroy() { if (_inv != null) _inv.Items.Changed -= NoticeItems; }

        /// <summary>Handling a new material may give you an idea (Grounded's analyzer / Subnautica's scanner; design §6.2).</summary>
        void NoticeItems()
        {
            foreach (var id in _inv.Items.Items.Keys.ToList())
                foreach (var r in Crafter.Handle(id))
                    _inv.Toast($"Idea: you could make a {r.Name} from these — try it at a {r.Station}.", 5f);
        }

        public bool Experiment(RecipeData r, string atNpcId)
        {
            var result = Crafter.Experiment(r.Id, _inv.Items, atNpcId);
            if (result == CraftResult.Ok) _inv.Toast($"You worked it out: {r.Name}! Recipe learned.", 5f);
            else if (result == CraftResult.MissingMaterials) _inv.Toast("To experiment you need every material: " + InputsText(r), 5f);
            return result == CraftResult.Ok;
        }

        public bool Learn(RecipeData r, string atNpcId)
        {
            var result = Crafter.Learn(r.Id, _inv.Items, atNpcId);
            if (result == CraftResult.Ok) _inv.Toast($"Learned: {r.Name}", 4f);
            else if (result == CraftResult.NotEnoughMoney) _inv.Toast($"Learning {r.Name} costs {Money.Format(r.LearnFrom.Price, AscendData.Db.World.Currency)}.");
            return result == CraftResult.Ok;
        }

        public bool Make(RecipeData r, string atNpcId)
        {
            var result = Crafter.Craft(r.Id, _inv.Items, atNpcId);
            if (result == CraftResult.Ok) _inv.Toast($"Made {Name(r.Output.ItemId)}" + (r.Output.Count > 1 ? $" ×{r.Output.Count}" : ""), 4f);
            else if (result == CraftResult.MissingMaterials)
                _inv.Toast("Missing: " + string.Join(", ", Crafter.Missing(r, _inv.Items).Select(m => $"{m.Count} {Name(m.ItemId)}")), 5f);
            return result == CraftResult.Ok;
        }

        /// <summary>"2 Healing Herb (have 1), 1 Slime Jelly (have 3)".</summary>
        public string InputsText(RecipeData r) =>
            string.Join(", ", r.Inputs.Select(i => $"{i.Count} {Name(i.ItemId)} ({_inv.Items.Count(i.ItemId)})"));

        public static string Name(string itemId) => AscendData.Db.Items.TryGetValue(itemId, out var it) ? it.Name : itemId;

        public void Load(IEnumerable<string> known, IEnumerable<string> seen = null) => Crafter.Load(known, seen);
    }
}
