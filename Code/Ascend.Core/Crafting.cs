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
        /// <summary>The life rank needed in <see cref="Skill"/> (default F).</summary>
        public string LifeRank { get; set; } = "F";
        /// <summary>XP override for one craft; null uses the rank default from life_skills.json.</summary>
        public int? Xp { get; set; }
        /// <summary>Optional extra item spent to attune the craft (a quality bump); null: cannot be attuned.</summary>
        public string AttuneItem { get; set; }
    }

    public sealed class RecipeFile
    {
        public string Notes { get; set; }
        /// <summary>Station → the NPC whose workbench it is (null: usable anywhere, like a campfire).</summary>
        public Dictionary<string, string> Stations { get; set; } = new Dictionary<string, string>();
        public List<RecipeData> Recipes { get; set; } = new List<RecipeData>();
    }

    public enum CraftResult { Ok, Unknown, WrongStation, MissingMaterials, AlreadyKnown, NotEnoughMoney, NotTaughtHere, NoIdeaYet, RankTooLow }

    public sealed class MakeOptions
    {
        /// <summary>Spend the recipe attuneItem for the experiment bonus.</summary>
        public bool Attune { get; set; }
        public ulong Seed { get; set; }
        /// <summary>How many crafts so far (feeds the deterministic jitter).</summary>
        public int CraftCounter { get; set; }
        /// <summary>Consume the worst stacks first instead of the best.</summary>
        public bool UseLowestQualityFirst { get; set; }
    }

    public sealed class MakeReport
    {
        public CraftResult Result { get; set; }
        /// <summary>Inventory key of the output (itemId or itemId@tier); null unless Ok.</summary>
        public string OutputKey { get; set; }
        /// <summary>Quality tier id of the output.</summary>
        public string Quality { get; set; }
        public bool Mark { get; set; }
        public bool Nameable { get; set; }
        public long XpGained { get; set; }
        /// <summary>The new skill rank if this craft raised it, else null.</summary>
        public string RankedUp { get; set; }
    }

    /// <summary>
    /// What the player knows and can make. Recipes are learned from their teacher (or known from the start); a craft
    /// needs the right station and every input, consumes them and gives the output. Standard quality for now — the
    /// optional mini-games (quality tiers, crafter's mark) come later; skipping them always gives this result.
    /// </summary>
    public sealed class Crafter
    {
        readonly RecipeFile _file;
        readonly HashSet<string> _known = new HashSet<string>();
        readonly HashSet<string> _seen = new HashSet<string>();
        readonly QualityRules _rules;
        readonly LifeSkills _skills;

        public LifeSkills Skills => _skills;

        /// <summary>Materials you've handled (item_and_economy_design.md §6.2: hypotheses come from what you've held).</summary>
        public ICollection<string> SeenItems => _seen;

        /// <summary>Notes an item you've held; returns recipes that just became hypotheses (every input handled, not yet known).</summary>
        public List<RecipeData> Handle(string itemId)
        {
            if (string.IsNullOrEmpty(itemId) || !_seen.Add(itemId)) return new List<RecipeData>();
            return _file.Recipes.Where(r => IsHypothesis(r) && r.Inputs.Any(i => i.ItemId == itemId)).ToList();
        }

        /// <summary>Not known yet, but you've handled every material it needs: you could work it out by experimenting.</summary>
        public bool IsHypothesis(RecipeData r) => r != null && !_known.Contains(r.Id) && r.Inputs.All(i => _seen.Contains(i.ItemId));

        /// <summary>
        /// Experimenting at the right station (§6.1 "each step offers at least two routes"): with a hypothesis and the
        /// materials, you make the item and learn the recipe without a teacher. The materials are used either way.
        /// </summary>
        public CraftResult Experiment(string recipeId, Inventory inv, string atNpcId)
        {
            var r = Recipe(recipeId);
            if (r == null) return CraftResult.Unknown;
            if (_known.Contains(r.Id)) return CraftResult.AlreadyKnown;
            if (!IsHypothesis(r)) return CraftResult.NoIdeaYet;
            if (!StationAvailable(r.Station, atNpcId)) return CraftResult.WrongStation;
            if (Missing(r, inv).Count > 0) return CraftResult.MissingMaterials;
            foreach (var i in r.Inputs) inv.TryRemove(i.ItemId, i.Count);
            inv.Add(r.Output.ItemId, Math.Max(1, r.Output.Count));
            _known.Add(r.Id);
            return CraftResult.Ok;
        }

        public Crafter(RecipeFile file, QualityRules rules = null, LifeSkills skills = null)
        {
            _rules = rules;
            _skills = skills;
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
            if (RankTooLow(r)) return CraftResult.RankTooLow;
            return Missing(r, inv).Count > 0 ? CraftResult.MissingMaterials : CraftResult.Ok;
        }

        /// <summary>True when life skills are attached, know the recipe skill, and the recipe needs a higher rank. Unknown skills never gate.</summary>
        bool RankTooLow(RecipeData r) => _skills != null && _skills.IsKnown(r.Skill) && _skills.RankIndex(r.LifeRank) > _skills.RankIdx(r.Skill);

        public CraftResult Craft(string recipeId, Inventory inv, string atNpcId)
        {
            var can = CanCraft(recipeId, inv, atNpcId);
            if (can != CraftResult.Ok) return can;
            var r = Recipe(recipeId);
            foreach (var i in r.Inputs) inv.TryRemove(i.ItemId, i.Count);
            inv.Add(r.Output.ItemId, Math.Max(1, r.Output.Count));
            _skills?.OnCraft(r, out _);
            return CraftResult.Ok;
        }

        /// <summary>Units of an item across every quality stack.</summary>
        static int UnitsOf(Inventory inv, string itemId) =>
            inv.Items.Where(kv => ItemQuality.BaseId(kv.Key) == itemId).Sum(kv => kv.Value);

        /// <summary>
        /// The quality-aware craft (crafting_v6_audit.md section 3.1). Never fails at random: it cannot start (unknown, station, rank,
        /// missing materials or attune item; nothing is consumed) or it consumes exactly the inputs and yields at least Poor.
        /// </summary>
        public MakeReport Make(string recipeId, Inventory inv, string atNpcId, MakeOptions opt = null)
        {
            opt = opt ?? new MakeOptions();
            var rep = new MakeReport { Result = CanMake(recipeId, inv, atNpcId) };
            var r = Recipe(recipeId);
            if (rep.Result == CraftResult.Ok && opt.Attune)
            {
                if (string.IsNullOrEmpty(r.AttuneItem)) rep.Result = CraftResult.MissingMaterials;
                else
                {
                    int need = r.Inputs.Where(i => i.ItemId == r.AttuneItem).Sum(i => i.Count) + 1;
                    if (UnitsOf(inv, r.AttuneItem) < need) rep.Result = CraftResult.MissingMaterials;
                }
            }
            if (rep.Result != CraftResult.Ok) return rep;

            var rules = _rules ?? new QualityRules();
            int normal = rules.NormalIndex;
            long tierSum = 0; int units = 0, best = int.MinValue;
            foreach (var i in r.Inputs)
            {
                int left = i.Count;
                foreach (var kv in Stacks(inv, i.ItemId, rules, opt.UseLowestQualityFirst))
                {
                    if (left <= 0) break;
                    int take = Math.Min(left, kv.Value);
                    int idx = rules.IndexOf(ItemQuality.Split(kv.Key).TierId);
                    inv.TryRemove(kv.Key, take);
                    tierSum += (long)idx * take; units += take; left -= take;
                    if (idx > best) best = idx;
                }
            }
            if (opt.Attune)
            {
                // The extra unit comes from the worst stack left, so it never costs the better ones; it does not count toward quality.
                var spare = Stacks(inv, r.AttuneItem, rules, true).First();
                inv.TryRemove(spare.Key, 1);
            }
            if (units == 0) best = normal;

            var f = rules.Formula ?? new QualityFormula();
            double mean = units > 0 ? (double)tierSum / units : normal;
            int rankIdx = _skills != null ? _skills.RankIdx(r.Skill) : 0;
            string rank = _skills != null ? _skills.Rank(r.Skill) : "F";
            double jitter = DeterministicRandom.For(opt.Seed, r.Id, opt.CraftCounter).NextDouble() * f.JitterMax;
            double score = mean + f.SkillBonusPerRank * rankIdx + (opt.Attune ? f.ExperimentBonus : 0) + jitter;
            int cap = Math.Min(best + f.TierAboveBest, Math.Min(rules.RankCapIndex(rank), rules.StationCapIndex(r.Station)));
            cap = Math.Min(cap, rules.MaxCraftableIndex);
            int index = Math.Max(0, Math.Min((int)Math.Floor(score), cap));
            string tier = rules.TierAt(index)?.Id ?? QualityRules.NormalId;

            rep.Quality = tier;
            rep.Mark = rules.Mark(tier);
            rep.Nameable = rules.Nameable(tier);
            rep.OutputKey = ItemQuality.Compose(r.Output.ItemId, tier);
            inv.Add(rep.OutputKey, Math.Max(1, r.Output.Count));
            if (_skills != null) { rep.XpGained = _skills.OnCraft(r, out var up); rep.RankedUp = up; }
            return rep;
        }

        /// <summary>Like CanCraft, but counts materials across all quality stacks.</summary>
        CraftResult CanMake(string recipeId, Inventory inv, string atNpcId)
        {
            var r = Recipe(recipeId);
            if (r == null || !_known.Contains(r.Id)) return CraftResult.Unknown;
            if (!StationAvailable(r.Station, atNpcId)) return CraftResult.WrongStation;
            if (RankTooLow(r)) return CraftResult.RankTooLow;
            return r.Inputs.Any(i => UnitsOf(inv, i.ItemId) < i.Count) ? CraftResult.MissingMaterials : CraftResult.Ok;
        }

        static List<KeyValuePair<string, int>> Stacks(Inventory inv, string itemId, QualityRules rules, bool lowestFirst)
        {
            var list = inv.Items.Where(kv => ItemQuality.BaseId(kv.Key) == itemId)
                .Select(kv => new KeyValuePair<string, int>(kv.Key, kv.Value)).ToList();
            list.Sort((a, b) =>
            {
                int c = rules.IndexOf(ItemQuality.Split(a.Key).TierId).CompareTo(rules.IndexOf(ItemQuality.Split(b.Key).TierId));
                if (!lowestFirst) c = -c;
                return c != 0 ? c : string.CompareOrdinal(a.Key, b.Key);
            });
            return list;
        }

        public void Load(IEnumerable<string> known, IEnumerable<string> seen = null)
        {
            foreach (var id in known ?? Enumerable.Empty<string>()) if (Recipe(id) != null) _known.Add(id);
            foreach (var id in seen ?? Enumerable.Empty<string>()) if (!string.IsNullOrEmpty(id)) _seen.Add(id);
        }
    }
}
