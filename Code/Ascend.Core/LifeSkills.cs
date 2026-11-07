using System;
using System.Collections.Generic;
using System.Linq;

namespace Ascend.Core
{
    // Life skills (12_Systems/systems.md section 5 and 5.3; crafting_v6_audit.md section 3.2). Data: Data/Items/life_skills.json.
    // Parallel F to SSS tracks per skill. No decay, no repetition debt: XP never goes down and a skill held at a
    // rank threshold keeps its XP while it waits for a commission.

    public sealed class LifeSkillDef
    {
        public string Id { get; set; }
        public string Name { get; set; }
        /// <summary>craft, gather or deferred.</summary>
        public string Kind { get; set; }
        public string Station { get; set; }
        public string Notes { get; set; }
    }

    public sealed class LifeSkillXpRules
    {
        public Dictionary<string, long> XpToReach { get; set; } = new Dictionary<string, long>();
        public double FirstCraftMultiplier { get; set; } = 3;
        public int TrivialRankGap { get; set; } = 2;
        public double TrivialMultiplier { get; set; } = 0.25;
        public int MinXp { get; set; } = 1;
        public Dictionary<string, int> DefaultRecipeXpByRank { get; set; } = new Dictionary<string, int>();
        public Dictionary<string, int> GatherXpPerNode { get; set; } = new Dictionary<string, int>();
    }

    /// <summary>Data/Items/life_skills.json.</summary>
    public sealed class LifeSkillFile
    {
        public string Notes { get; set; }
        public List<string> Ranks { get; set; } = new List<string>();
        public string CommissionFromRank { get; set; } = "D";
        public LifeSkillXpRules Xp { get; set; } = new LifeSkillXpRules();
        public List<LifeSkillDef> Skills { get; set; } = new List<LifeSkillDef>();
    }

    /// <summary>The persistent part of the life skills (SaveGame.LifeSkills). Every collection defaults to empty, so older saves load.</summary>
    public sealed class LifeSkillSave
    {
        public Dictionary<string, long> Xp { get; set; } = new Dictionary<string, long>();
        public Dictionary<string, string> Rank { get; set; } = new Dictionary<string, string>();
        /// <summary>Skill id → rank letters whose masterwork commission was passed.</summary>
        public Dictionary<string, List<string>> Commissions { get; set; } = new Dictionary<string, List<string>>();
        /// <summary>Recipe ids crafted at least once (the first-craft XP bonus is paid once).</summary>
        public List<string> Crafted { get; set; } = new List<string>();
    }

    public sealed class LifeSkills
    {
        readonly LifeSkillFile _file;
        readonly List<string> _ranks;
        readonly Dictionary<string, long> _xp = new Dictionary<string, long>();
        readonly Dictionary<string, int> _rank = new Dictionary<string, int>();
        readonly Dictionary<string, HashSet<string>> _passed = new Dictionary<string, HashSet<string>>();
        readonly HashSet<string> _crafted = new HashSet<string>();

        public LifeSkills(LifeSkillFile file)
        {
            _file = file ?? new LifeSkillFile();
            _ranks = _file.Ranks != null && _file.Ranks.Count > 0 ? _file.Ranks : new List<string> { "F", "E", "D", "C", "B", "A", "S", "SS", "SSS" };
        }

        public IReadOnlyList<string> Ranks => _ranks;
        public IEnumerable<LifeSkillDef> Skills => _file.Skills;
        public bool IsKnown(string skill) => skill != null && _file.Skills.Any(s => s.Id == skill);
        public LifeSkillDef Def(string skill) => _file.Skills.FirstOrDefault(s => s.Id == skill);

        /// <summary>Index of a rank letter (F = 0); unknown letters count as F.</summary>
        public int RankIndex(string rank) { int i = rank == null ? -1 : _ranks.IndexOf(rank); return i < 0 ? 0 : i; }
        int CommissionIndex { get { int i = _ranks.IndexOf(_file.CommissionFromRank); return i < 0 ? int.MaxValue : i; } }

        public int RankIdx(string skill) => _rank.TryGetValue(skill ?? "", out var r) ? r : 0;
        public string Rank(string skill) => _ranks[RankIdx(skill)];
        public long Xp(string skill) => _xp.TryGetValue(skill ?? "", out var x) ? x : 0;
        public bool HasCrafted(string recipeId) => recipeId != null && _crafted.Contains(recipeId);

        long Threshold(int rankIdx) => _file.Xp.XpToReach != null && _file.Xp.XpToReach.TryGetValue(_ranks[rankIdx], out var t) ? t : long.MaxValue;

        /// <summary>XP still needed for the next rank (0 when at the cap or already at the threshold).</summary>
        public long XpToNext(string skill)
        {
            int r = RankIdx(skill);
            if (r + 1 >= _ranks.Count) return 0;
            return Math.Max(0, Threshold(r + 1) - Xp(skill));
        }

        /// <summary>Has the XP for the next rank but is waiting for a commission (D and above).</summary>
        public bool Eligible(string skill)
        {
            if (!IsKnown(skill)) return false;
            int r = RankIdx(skill);
            if (r + 1 >= _ranks.Count) return false;
            return Xp(skill) >= Threshold(r + 1) && r + 1 >= CommissionIndex && !CommissionPassed(skill, _ranks[r + 1]);
        }

        public bool CommissionPassed(string skill, string rank) => _passed.TryGetValue(skill ?? "", out var s) && s.Contains(rank);

        /// <summary>Marks the commission for the next rank passed (quest content calls this) and promotes if the XP is there. Returns the new rank or null.</summary>
        public string PassCommission(string skill)
        {
            if (!IsKnown(skill)) return null;
            int r = RankIdx(skill);
            if (r + 1 >= _ranks.Count) return null;
            return PassCommission(skill, _ranks[r + 1]);
        }

        public string PassCommission(string skill, string rank)
        {
            if (!IsKnown(skill) || _ranks.IndexOf(rank) < 0) return null;
            if (!_passed.TryGetValue(skill, out var set)) _passed[skill] = set = new HashSet<string>();
            set.Add(rank);
            return Promote(skill);
        }

        /// <summary>Adds XP (never negative). Returns the new rank letter if it rose, else null. Unknown skill ids are ignored.</summary>
        public string AddXp(string skill, long amount)
        {
            if (!IsKnown(skill) || amount <= 0) return null;
            _xp[skill] = Xp(skill) + amount;
            return Promote(skill);
        }

        string Promote(string skill)
        {
            int start = RankIdx(skill), r = start;
            while (r + 1 < _ranks.Count && Xp(skill) >= Threshold(r + 1))
            {
                if (r + 1 >= CommissionIndex && !CommissionPassed(skill, _ranks[r + 1])) break;
                r++;
            }
            if (r == start) return null;
            _rank[skill] = r;
            return _ranks[r];
        }

        /// <summary>XP for one craft of a recipe at the skill current rank: recipe xp (or the rank default), x3 on the first craft, x0.25 when trivial; at least minXp.</summary>
        public long XpFor(RecipeData recipe, bool firstTime)
        {
            if (recipe == null) return 0;
            var x = _file.Xp;
            int recipeRank = RankIndex(recipe.LifeRank);
            double baseXp = recipe.Xp ?? (x.DefaultRecipeXpByRank != null && x.DefaultRecipeXpByRank.TryGetValue(_ranks[recipeRank], out var d) ? d : x.MinXp);
            double v = baseXp;
            if (firstTime) v *= x.FirstCraftMultiplier;
            if (RankIdx(recipe.Skill) - recipeRank >= x.TrivialRankGap) v *= x.TrivialMultiplier;
            return Math.Max(x.MinXp, (long)Math.Round(v, MidpointRounding.AwayFromZero));
        }

        /// <summary>Records a finished craft: pays XpFor (first craft bonus once per recipe). Returns the XP gained and the new rank if it rose.</summary>
        public long OnCraft(RecipeData recipe, out string rankedUp)
        {
            rankedUp = null;
            if (recipe == null || !IsKnown(recipe.Skill)) return 0;
            bool first = _crafted.Add(recipe.Id);
            long xp = XpFor(recipe, first);
            rankedUp = AddXp(recipe.Skill, xp);
            return xp;
        }

        /// <summary>Gather XP for one node of a given rank (trivial nodes pay less, never zero). Returns the XP gained.</summary>
        public long OnGather(string skill, string nodeRank, out string rankedUp)
        {
            rankedUp = null;
            if (!IsKnown(skill)) return 0;
            var x = _file.Xp;
            int nodeIdx = RankIndex(nodeRank);
            double v = x.GatherXpPerNode != null && x.GatherXpPerNode.TryGetValue(_ranks[nodeIdx], out var g) ? g : x.MinXp;
            if (RankIdx(skill) - nodeIdx >= x.TrivialRankGap) v *= x.TrivialMultiplier;
            long xp = Math.Max(x.MinXp, (long)Math.Round(v, MidpointRounding.AwayFromZero));
            rankedUp = AddXp(skill, xp);
            return xp;
        }

        public long OnGather(string skill, string nodeRank) => OnGather(skill, nodeRank, out _);

        public LifeSkillSave Save()
        {
            var s = new LifeSkillSave();
            foreach (var kv in _xp) s.Xp[kv.Key] = kv.Value;
            foreach (var kv in _rank) s.Rank[kv.Key] = _ranks[kv.Value];
            foreach (var kv in _passed) s.Commissions[kv.Key] = kv.Value.OrderBy(x => _ranks.IndexOf(x)).ToList();
            s.Crafted = _crafted.OrderBy(x => x, StringComparer.Ordinal).ToList();
            return s;
        }

        /// <summary>Restores state; null (an older save) leaves everything at F with no XP. Unknown skills and ranks are dropped.</summary>
        public void Load(LifeSkillSave s)
        {
            _xp.Clear(); _rank.Clear(); _passed.Clear(); _crafted.Clear();
            if (s == null) return;
            foreach (var kv in s.Xp ?? new Dictionary<string, long>()) if (IsKnown(kv.Key) && kv.Value > 0) _xp[kv.Key] = kv.Value;
            foreach (var kv in s.Commissions ?? new Dictionary<string, List<string>>())
                if (IsKnown(kv.Key)) _passed[kv.Key] = new HashSet<string>((kv.Value ?? new List<string>()).Where(x => _ranks.Contains(x)));
            foreach (var kv in s.Rank ?? new Dictionary<string, string>()) if (IsKnown(kv.Key) && _ranks.Contains(kv.Value)) _rank[kv.Key] = _ranks.IndexOf(kv.Value);
            foreach (var id in s.Crafted ?? new List<string>()) if (!string.IsNullOrEmpty(id)) _crafted.Add(id);
        }
    }
}
