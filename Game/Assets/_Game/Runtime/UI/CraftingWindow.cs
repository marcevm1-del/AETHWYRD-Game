using System;
using System.Collections.Generic;
using System.Linq;
using Ascend.Core;
using UnityEngine;

namespace Ascend.Game
{
    /// <summary>
    /// The Crafting page (12_Systems/crafting.md; IMGUI placeholder): every recipe you know with what it needs (owned/needed),
    /// the quality you can expect, a craft row (Enter), an attuned craft when the recipe allows one, and the life-skill rank
    /// ladder F to SSS with an XP bar per skill. Crafts go through <see cref="PlayerCrafting.MakeQuality"/> (Core Crafter.Make).
    /// Opened with F2 (playtest keys); <see cref="AtNpcId"/> names the workbench owner when it is opened at a station (null: the
    /// campfire, which works anywhere).
    /// </summary>
    public sealed class CraftingWindow : SystemWindow
    {
        static CraftingWindow _instance;
        public static bool IsOpen => _instance != null && _instance._open;
        public static CraftingWindow Instance => _instance != null ? _instance : _instance = Create<CraftingWindow>();

        /// <summary>The NPC whose workbench you stand at; null for the campfire / anywhere.</summary>
        public string AtNpcId { get; set; }

        protected override string Title => "CRAFTING";
        protected override string Footer => "Quality depends on the materials you bring and your skill rank.";

        PlayerCrafting Craft
        {
            get
            {
                var p = PlayerObject;
                var c = p != null ? p.GetComponent<PlayerCrafting>() : null;
                return c != null ? c : FindFirstObjectByType<PlayerCrafting>();
            }
        }

        protected override void Build(List<Row> rows)
        {
            var craft = Craft;
            if (craft == null || craft.Crafter == null) { rows.Add(Info("Crafting is not available yet.", true)); return; }
            var crafter = craft.Crafter;
            string station = AtNpcId == null ? "the campfire (anywhere)" : (crafter.StationOf(AtNpcId) ?? "a workbench");
            rows.Add(Header($"RECIPES — at {station}"));

            var skills = craft.Skills;
            var known = crafter.All.Where(r => crafter.Knows(r.Id))
                .OrderBy(r => craft.StatusOf(r.Id, AtNpcId) == CraftResult.Ok ? 0 : 1)   // what you can make right now comes first
                .ThenBy(r => r.Skill).ThenBy(r => skills != null ? skills.RankIndex(r.LifeRank) : 0).ThenBy(r => r.Name).ToList();
            if (known.Count == 0) rows.Add(Invite("You do not know any recipe yet. Teachers sell them, and handling materials may give you ideas."));
            foreach (var r in known)
            {
                var recipe = r;
                var status = craft.StatusOf(r.Id, AtNpcId);
                var row = new Row
                {
                    Text = r.Name,
                    Tag = $"{SkillName(skills, r.Skill)} {r.LifeRank}",
                    Act = () => DoCraft(craft, recipe, false),
                    Detail = DetailFor(craft, r, status),
                };
                row.Chip = ChipText(craft, r, status, out row.ChipColor);
                if (!string.IsNullOrEmpty(r.AttuneItem))
                {
                    row.Alt = () => DoCraft(craft, recipe, true);
                    row.AltLabel = "Boost";
                }
                rows.Add(row);
            }

            rows.Add(Header("LIFE SKILLS — rank ladder F to SSS"));
            if (skills == null) { rows.Add(Info("Life skills are not available.", true)); return; }
            foreach (var s in craft.SkillRows())
            {
                bool used = s.Xp > 0 || s.RankIndex > 0 || crafter.All.Any(r => r.Skill == s.Id);
                if (!used) continue;
                var ladder = craft.Ladder(s.Id);
                bool top = s.XpToNext <= 0 && s.RankIndex >= skills.Ranks.Count - 1;
                string next = top ? "top rank" : s.CommissionPending ? "ready for a commission" : $"{s.XpToNext} XP to next rank";
                rows.Add(new Row { Text = $"{s.Name}   rank {s.Rank}   {s.Xp} XP   ({next})", Bar = XpFraction(s, ladder, top) });
                rows.Add(Info("      " + LadderText(ladder), true));
                if (s.CommissionPending)
                {
                    string skillId = s.Id, piece = craft.CommissionPiece(skillId);
                    rows.Add(new Row
                    {
                        Text = piece != null ? $"      Hand in {craft.ItemName(piece)} as your commission for the next rank" : "      Commission: make a finished piece of your best quality to hand in",
                        Act = () =>
                        {
                            string up = craft.PassCommission(skillId);
                            Line = up != null ? $"The commission is accepted — {SkillName(craft.Skills, skillId)} reached rank {up}!" : "You have no finished piece to hand in yet.";
                        },
                    });
                }
            }
        }

        /// <summary>The status chip of a recipe row: Ready, or the one thing that is in the way.</summary>
        string ChipText(PlayerCrafting craft, RecipeData r, CraftResult status, out ChipKind kind)
        {
            switch (status)
            {
                case CraftResult.Ok: kind = ChipKind.Good; return "Ready";
                case CraftResult.MissingMaterials:
                {
                    kind = ChipKind.Bad;
                    var miss = craft.Crafter.Missing(r, craft.GetComponent<PlayerInventory>().Items).ToList();
                    return miss.Count == 1 ? $"Missing {miss[0].Count} {craft.ItemName(miss[0].ItemId)}" : $"Missing {miss.Count} materials";
                }
                case CraftResult.WrongStation: kind = ChipKind.Warn; return "Needs workbench";
                case CraftResult.RankTooLow: kind = ChipKind.Warn; return $"Needs rank {r.LifeRank}";
                default: kind = ChipKind.Neutral; return craft.StatusText(status, r);
            }
        }

        /// <summary>Right-hand pane for one recipe: what it makes, what it needs (have/need), the expected quality and the boost.</summary>
        List<string> DetailFor(PlayerCrafting craft, RecipeData r, CraftResult status)
        {
            string output = craft.ItemName(r.Output.ItemId) + (r.Output.Count > 1 ? $" ×{r.Output.Count}" : "");
            var d = new List<string> { "# " + r.Name, "Makes " + output, "# Needs:" };
            foreach (var i in r.Inputs)
            {
                int have = Owned(craft, i.ItemId);
                d.Add(have >= i.Count ? $"+ {craft.ItemName(i.ItemId)}  {have}/{i.Count}  (have)" : $"! {craft.ItemName(i.ItemId)}  {have}/{i.Count}  (need {i.Count - have} more)");
            }
            d.Add("Expected quality: " + ExpectedQuality(craft, r, false));
            if (!string.IsNullOrEmpty(r.AttuneItem))
            {
                int have = Owned(craft, r.AttuneItem);
                d.Add($"- Boost (X): spend 1 extra {craft.ItemName(r.AttuneItem)} ({have} owned) for a better result: {ExpectedQuality(craft, r, true)}");
            }
            if (status == CraftResult.WrongStation) d.Add("! This needs a workbench. Visit the right maker, or craft it at their station.");
            else if (status == CraftResult.RankTooLow) d.Add("! " + craft.StatusText(status, r));
            return d;
        }

        // ------------------------------------------------------------------ pieces (public for tests)

        void DoCraft(PlayerCrafting craft, RecipeData r, bool attune)
        {
            var status = craft.StatusOf(r.Id, AtNpcId);
            if (status != CraftResult.Ok) { Line = $"{r.Name}: {craft.StatusText(status, r)}"; return; }
            var rep = craft.MakeQuality(r.Id, AtNpcId, attune);
            if (rep == null || rep.Result != CraftResult.Ok) { Line = $"{r.Name}: {craft.StatusText(rep != null ? rep.Result : CraftResult.Unknown, r)}"; return; }
            string quality = craft.QualityName(rep.Quality);
            Line = $"Made {craft.ItemName(rep.OutputKey)}" + (rep.XpGained > 0 ? $"  (+{rep.XpGained} {SkillName(craft.Skills, r.Skill)} XP)" : "")
                 + (string.IsNullOrEmpty(rep.RankedUp) ? "" : $"  — {SkillName(craft.Skills, r.Skill)} reached rank {rep.RankedUp}!")
                 + (string.IsNullOrEmpty(quality) ? "" : $"  [{quality}]");
        }

        /// <summary>Units of an item in the bag across every quality stack.</summary>
        public static int Owned(PlayerCrafting craft, string itemId)
        {
            var inv = craft.GetComponent<PlayerInventory>();
            if (inv == null) return 0;
            return inv.Items.CountAll(itemId);
        }

        static string SkillName(LifeSkills skills, string id)
        {
            var d = skills != null ? skills.Def(id) : null;
            return d != null ? d.Name : id;
        }

        /// <summary>
        /// The quality range a craft can land in, from the same numbers Core Crafter.Make uses: the mean tier of the best stacks it would take, plus the
        /// skill-rank bonus (and the attune bonus), plus up to the jitter ceiling, floored and capped by one tier above the best input, the rank cap and the
        /// station cap. Display only; the craft itself decides.
        /// </summary>
        public static string ExpectedQuality(PlayerCrafting craft, RecipeData r, bool attune)
        {
            var rules = craft.Quality;
            if (rules == null || rules.QualityTiers.Count == 0) return "standard";
            var inv = craft.GetComponent<PlayerInventory>();
            int normal = rules.NormalIndex;
            long sum = 0; int units = 0, best = int.MinValue;
            if (inv != null)
                foreach (var i in r.Inputs)
                {
                    int left = i.Count;
                    var stacks = inv.Items.Items.Where(kv => ItemQuality.BaseId(kv.Key) == i.ItemId)
                        .Select(kv => (idx: rules.IndexOf(ItemQuality.Split(kv.Key).TierId), count: kv.Value)).OrderByDescending(s => s.idx);
                    foreach (var s in stacks)
                    {
                        if (left <= 0) break;
                        int take = Math.Min(left, s.count);
                        sum += (long)s.idx * take; units += take; left -= take;
                        if (s.idx > best) best = s.idx;
                    }
                }
            if (units == 0) best = normal;
            double mean = units > 0 ? (double)sum / units : normal;
            var f = rules.Formula ?? new QualityFormula();
            var skills = craft.Skills;
            bool known = skills != null && skills.IsKnown(r.Skill);
            int rankIdx = known ? skills.RankIdx(r.Skill) : 0;
            string rank = known ? skills.Rank(r.Skill) : "F";
            double lo = mean + f.SkillBonusPerRank * rankIdx + (attune ? f.ExperimentBonus : 0);
            double hi = lo + f.JitterMax;
            long cap = Math.Min((long)best + f.TierAboveBest, Math.Min((long)rules.RankCapIndex(rank), (long)rules.StationCapIndex(r.Station)));
            cap = Math.Min(cap, rules.MaxCraftableIndex);
            int a = (int)Math.Max(0, Math.Min((long)Math.Floor(lo), cap));
            int b = (int)Math.Max(0, Math.Min((long)Math.Floor(hi), cap));
            string na = rules.TierAt(a)?.Name ?? "Standard", nb = rules.TierAt(b)?.Name ?? "Standard";
            return a == b ? na : $"{na} to {nb}";
        }

        static float XpFraction(SkillRow s, IReadOnlyList<LadderRung> ladder, bool top)
        {
            if (top) return 1f;
            int cur = -1;
            for (int i = 0; i < ladder.Count; i++) if (ladder[i].Current) cur = i;
            if (cur < 0 || cur + 1 >= ladder.Count) return 0f;
            double from = ladder[cur].XpToReach, to = ladder[cur + 1].XpToReach;
            return to <= from ? 1f : (float)Math.Max(0, Math.Min(1, (s.Xp - from) / (to - from)));
        }

        /// <summary>"F■ E■ [D] C B A S SS SSS": reached ranks are marked, the current one is bracketed.</summary>
        public static string LadderText(IReadOnlyList<LadderRung> ladder) =>
            string.Join("  ", ladder.Select(l => l.Current ? $"[{l.Rank}]" : l.Reached ? l.Rank + "■" : l.Rank + (l.NeedsCommission ? "*" : "")));
    }
}
