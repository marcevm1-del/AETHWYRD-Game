using System.Collections.Generic;
using System.Linq;
using Ascend.Core;
using UnityEngine;

namespace Ascend.Game
{
    /// <summary>One life skill for the rank panel.</summary>
    public struct SkillRow
    {
        public string Id, Name, Rank;
        public int RankIndex;
        public long Xp, XpToNext;
        /// <summary>The XP for the next rank is in, but a masterwork commission is still needed (rank D and up). Nothing is lost while it waits.</summary>
        public bool CommissionPending;
    }

    /// <summary>One rung of a life skill's F..SSS ladder.</summary>
    public struct LadderRung
    {
        public string Rank;
        public long XpToReach;
        public bool Reached, Current;
        /// <summary>Not reached yet and a masterwork commission will be needed on top of the XP.</summary>
        public bool NeedsCommission;
    }

    /// <summary>
    /// Crafting in play (Core Crafter; recipes.json): learn recipes from their teachers, make them at the teacher's
    /// workbench (Torvald's forge, Fennick's alembic) through the talk window, or cook campfire recipes anywhere from
    /// the bag. Crafting uses the item-quality rules (crafting_rules.json) and the life skill ladder (life_skills.json):
    /// quality depends on the materials, the skill rank and the station; every craft earns life skill XP. The crafting
    /// window calls <see cref="StatusOf"/>, <see cref="CraftableHere"/>, <see cref="MakeQuality"/>, <see cref="SkillRows"/> and
    /// <see cref="Ladder"/> (13_Production/phase1_api.md).
    /// </summary>
    [RequireComponent(typeof(PlayerInventory))]
    public sealed class PlayerCrafting : MonoBehaviour
    {
        const ulong CraftSeed = 0x5EEDCAFEu;

        PlayerInventory _inv;
        PlayerWorldState _world;
        int _crafts;

        public Crafter Crafter { get; private set; }

        /// <summary>The life skills (shared with the world state).</summary>
        public LifeSkills Skills => Crafter.Skills;

        public QualityRules Quality => AscendData.Db.Quality;

        void Awake()
        {
            _inv = GetComponent<PlayerInventory>();
            _world = PlayerWorldState.Ensure(gameObject);
            Crafter = new Crafter(AscendData.Db.Recipes, AscendData.Db.Quality, _world.LifeSkills);
            _inv.Items.Changed += NoticeItems;
        }

        void OnDestroy() { if (_inv != null) _inv.Items.Changed -= NoticeItems; }

        /// <summary>Handling a new material may give you an idea (Grounded's analyzer / Subnautica's scanner; design §6.2).</summary>
        void NoticeItems()
        {
            foreach (var id in _inv.Items.Items.Keys.ToList())
                foreach (var r in Crafter.Handle(ItemQuality.BaseId(id)))
                    _inv.Toast($"Idea: you could make a {r.Name} from these — try it at a {r.Station}.", 5f);
        }

        public bool Experiment(RecipeData r, string atNpcId)
        {
            var result = Crafter.Experiment(r.Id, _inv.Items, atNpcId);
            if (result == CraftResult.Ok) _inv.Toast($"You worked it out: {r.Name}! Recipe learned.", 5f);
            else if (result == CraftResult.MissingMaterials) _inv.Toast("To experiment you need every material: " + InputsText(r), 5f);
            else if (result == CraftResult.RankTooLow) _inv.Toast(RankNeededText(r), 5f);
            return result == CraftResult.Ok;
        }

        public bool Learn(RecipeData r, string atNpcId)
        {
            var result = Crafter.Learn(r.Id, _inv.Items, atNpcId);
            if (result == CraftResult.Ok) _inv.Toast($"Learned: {r.Name}", 4f);
            else if (result == CraftResult.NotEnoughMoney) _inv.Toast($"Learning {r.Name} costs {Money.Format(r.LearnFrom.Price, AscendData.Db.World.Currency)}.");
            return result == CraftResult.Ok;
        }

        /// <summary>Makes a recipe (talk window and campfire). Same as <see cref="MakeQuality"/>; true when it was made.</summary>
        public bool Make(RecipeData r, string atNpcId) => MakeQuality(r.Id, atNpcId).Result == CraftResult.Ok;

        /// <summary>
        /// Crafts with quality and life skill XP. <paramref name="attune"/> spends one extra unit of the recipe's attune item for the
        /// experiment bonus. Toasts the result and any rank-up; the report has Result, Quality (tier id), OutputKey, XpGained, RankedUp.
        /// </summary>
        public MakeReport MakeQuality(string recipeId, string atNpcId, bool attune = false)
        {
            var r = Crafter.Recipe(recipeId);
            var opt = new MakeOptions
            {
                Attune = attune,
                Seed = CraftSeed,
                CraftCounter = _crafts + (WorldClock.Instance != null ? (int)WorldClock.Instance.PlaySeconds : 0),
            };
            var rep = Crafter.Make(recipeId, _inv.Items, atNpcId, opt);
            if (rep.Result == CraftResult.Ok && r != null)
            {
                _crafts++;
                _inv.Toast($"Made {ItemName(rep.OutputKey)}" + (r.Output.Count > 1 ? $" ×{r.Output.Count}" : "") + (rep.Mark ? " ★" : ""), 4f);
                if (rep.RankedUp != null) _inv.Toast($"{SkillName(r.Skill)} is now rank {rep.RankedUp}!", 5f);
            }
            else if (r != null)
            {
                string why = StatusText(rep.Result, r);
                if (!string.IsNullOrEmpty(why)) _inv.Toast(why, 5f);
            }
            return rep;
        }

        /// <summary>Can this known recipe be made here and now? Ok, MissingMaterials, WrongStation, RankTooLow, or Unknown (not learned).</summary>
        public CraftResult StatusOf(string recipeId, string atNpcId) => Crafter.CanCraft(recipeId, _inv.Items, atNpcId);

        /// <summary>Known recipes whose station is here. <paramref name="atNpcId"/> null = the campfire and other anywhere stations.</summary>
        public IEnumerable<RecipeData> CraftableHere(string atNpcId) =>
            Crafter.All.Where(r => Crafter.Knows(r.Id) && Crafter.StationAvailable(r.Station, atNpcId));

        /// <summary>Short player text for a status ("" when Ok).</summary>
        public string StatusText(CraftResult result, RecipeData r = null)
        {
            switch (result)
            {
                case CraftResult.Ok: return "";
                case CraftResult.MissingMaterials:
                    return r == null ? "Missing materials." : "Missing: " + string.Join(", ", Crafter.Missing(r, _inv.Items).Select(m => $"{m.Count} {Name(m.ItemId)}"));
                case CraftResult.RankTooLow: return r == null ? "Your skill rank is too low." : RankNeededText(r);
                case CraftResult.WrongStation: return "You need the right workbench for this.";
                case CraftResult.Unknown: return "You have not learned this recipe.";
                case CraftResult.AlreadyKnown: return "You already know this recipe.";
                case CraftResult.NotEnoughMoney: return "Not enough coin.";
                case CraftResult.NotTaughtHere: return "Nobody here teaches this.";
                case CraftResult.NoIdeaYet: return "You have no idea how these fit together yet.";
                default: return "";
            }
        }

        string RankNeededText(RecipeData r) => $"{r.Name} needs {SkillName(r.Skill)} rank {r.LifeRank} (you are {Skills.Rank(r.Skill)}).";

        // ---------------------------------------------------------------- names

        /// <summary>"2 Healing Herb (have 1), 1 Slime Jelly (have 3)", counting every quality of a material.</summary>
        public string InputsText(RecipeData r) =>
            string.Join(", ", r.Inputs.Select(i => $"{i.Count} {Name(i.ItemId)} ({Have(i.ItemId)})"));

        int Have(string itemId) => _inv.Items.Items.Where(kv => ItemQuality.BaseId(kv.Key) == itemId).Sum(kv => kv.Value);

        /// <summary>Display name of an item or an item key with a quality: "Fine Fangblade".</summary>
        public static string Name(string itemKey)
        {
            var (id, tier) = ItemQuality.Split(itemKey);
            string n = id != null && AscendData.Db.Items.TryGetValue(id, out var it) ? it.Name : id;
            string q = QualityNameOf(tier);
            return q.Length > 0 ? q + " " + n : n;
        }

        public string ItemName(string itemKey) => Name(itemKey);

        /// <summary>"Fine", "Masterwork" ...; "" for normal or an unknown tier.</summary>
        public string QualityName(string tierId) => QualityNameOf(tierId);

        static string QualityNameOf(string tierId)
        {
            if (string.IsNullOrEmpty(tierId) || tierId == QualityRules.NormalId) return "";
            var t = AscendData.Db.Quality.Tier(tierId);
            return t != null && !string.IsNullOrEmpty(t.Name) ? t.Name : "";
        }

        static string SkillName(string skillId) => AscendData.Db.LifeSkills.Skills.FirstOrDefault(s => s.Id == skillId)?.Name ?? skillId;

        // ---------------------------------------------------------------- life skill ladder

        /// <summary>One row per life skill (name, rank, XP, XP to the next rank, commission pending).</summary>
        public IReadOnlyList<SkillRow> SkillRows()
        {
            var rows = new List<SkillRow>();
            foreach (var d in Skills.Skills)
                rows.Add(new SkillRow
                {
                    Id = d.Id, Name = string.IsNullOrEmpty(d.Name) ? d.Id : d.Name, Rank = Skills.Rank(d.Id), RankIndex = Skills.RankIdx(d.Id),
                    Xp = Skills.Xp(d.Id), XpToNext = Skills.XpToNext(d.Id), CommissionPending = Skills.Eligible(d.Id),
                });
            return rows;
        }

        /// <summary>The F..SSS ladder of one life skill: XP needed per rung, which are reached, which one you stand on.</summary>
        public IReadOnlyList<LadderRung> Ladder(string skillId)
        {
            var list = new List<LadderRung>();
            var ranks = Skills.Ranks;
            int cur = Skills.RankIdx(skillId);
            var table = AscendData.Db.LifeSkills.Xp.XpToReach;
            int commissionFrom = ranks.ToList().IndexOf(AscendData.Db.LifeSkills.CommissionFromRank);
            for (int i = 0; i < ranks.Count; i++)
            {
                long need = table != null && table.TryGetValue(ranks[i], out var x) ? x : 0;
                bool reached = i <= cur;
                list.Add(new LadderRung
                {
                    Rank = ranks[i], XpToReach = need, Reached = reached, Current = i == cur,
                    NeedsCommission = !reached && commissionFrom >= 0 && i >= commissionFrom && !Skills.CommissionPassed(skillId, ranks[i]),
                });
            }
            return list;
        }

        /// <summary>A masterwork commission handed in for the next rank of a skill. Returns the new rank when it promoted, else null.</summary>
        public string PassCommission(string skillId)
        {
            string up = Skills.PassCommission(skillId);
            if (up != null) _inv.Toast($"{SkillName(skillId)} is now rank {up}!", 5f);
            return up;
        }

        public void Load(IEnumerable<string> known, IEnumerable<string> seen = null) => Crafter.Load(known, seen);
    }
}
