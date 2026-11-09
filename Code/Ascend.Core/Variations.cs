using System;
using System.Collections.Generic;
using System.Linq;

namespace Ascend.Core
{
    // Universal monster variations (Canon section 6 proposal M2; bible section 5). Data: Data/Monsters/variations.json.
    // A variation MODIFIES a creature: stats, an element, a cue and a weakness note. It never creates a species, never changes
    // threat rank (rankShift is 0 in the data and the result keeps the species' own rank), and stacking has diminishing returns.
    // Awakened is a scripted state: it can only be applied when the caller says a script allows it.

    public sealed class VariationData
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int RarityTier { get; set; }
        public string RarityLabel { get; set; }
        public string Effect { get; set; }
        public Dictionary<string, double> StatMods { get; set; } = new Dictionary<string, double>();
        public List<string> ExcludedLines { get; set; } = new List<string>();
        public List<string> ExclusiveWith { get; set; } = new List<string>();
        public string Element { get; set; }
        public string VisualCue { get; set; }
        public string WeaknessNote { get; set; }
        public int RankShift { get; set; }
        public bool ScriptedOnly { get; set; }
    }

    public sealed class VariationStacking
    {
        public int MaxVariations { get; set; } = 3;
        public List<double> StrengthByCount { get; set; } = new List<double> { 1.0, 0.6, 0.35 };
    }

    public sealed class VariationFile
    {
        public string Notes { get; set; }
        public VariationStacking Stacking { get; set; } = new VariationStacking();
        public List<VariationData> Variations { get; set; } = new List<VariationData>();
    }

    /// <summary>A species with variations applied. Rank is always the species' own.</summary>
    public sealed class VariedMonster
    {
        public string SpeciesId { get; set; }
        public string Rank { get; set; }
        public StatBlock Stats { get; set; }
        public string Element { get; set; }
        public List<string> Variations { get; set; } = new List<string>();
        public List<string> VisualCues { get; set; } = new List<string>();
        public List<string> WeaknessNotes { get; set; } = new List<string>();
    }

    public sealed class VariationRules
    {
        readonly VariationFile _file;
        readonly Dictionary<string, VariationData> _byId;
        readonly MonsterLines _lines;

        public VariationRules(VariationFile file, MonsterLines lines)
        {
            _file = file ?? new VariationFile();
            _lines = lines;
            _byId = _file.Variations.ToDictionary(v => v.Id);
        }

        public IReadOnlyList<VariationData> All => _file.Variations;
        public VariationData Get(string id) => id != null && _byId.TryGetValue(id, out var v) ? v : null;

        /// <summary>Can this variation appear on this species? Species with no line have no exclusions.</summary>
        public bool Compatible(string speciesId, string variationId)
        {
            var v = Get(variationId);
            if (v == null) return false;
            var line = _lines?.LineOf(speciesId);
            return line == null || !v.ExcludedLines.Contains(line.Id);
        }

        /// <summary>The reasons a set of variations cannot go on a species (empty = fine).</summary>
        public List<string> Problems(string speciesId, IList<string> ids, bool scriptAllowsAwakened = false)
        {
            var problems = new List<string>();
            ids ??= new List<string>();
            if (ids.Count > _file.Stacking.MaxVariations) problems.Add($"at most {_file.Stacking.MaxVariations} variations");
            if (ids.Distinct().Count() != ids.Count) problems.Add("a variation cannot be applied twice");
            foreach (var id in ids)
            {
                var v = Get(id);
                if (v == null) { problems.Add($"unknown variation {id}"); continue; }
                if (v.ScriptedOnly && !scriptAllowsAwakened) problems.Add($"{v.Name} is a scripted state, not a spawn modifier");
                if (!Compatible(speciesId, id)) problems.Add($"{v.Name} cannot appear on this kind of monster");
                foreach (var other in ids) if (other != id && v.ExclusiveWith.Contains(other)) problems.Add($"{v.Name} cannot combine with {Get(other)?.Name ?? other}");
            }
            return problems.Distinct().ToList();
        }

        /// <summary>
        /// Applies variations in order. The first applies in full; later ones apply StrengthByCount[i] of the part of each multiplier
        /// above (or below) 1. Throws when the combination is not allowed. Threat rank is never changed.
        /// </summary>
        public VariedMonster Apply(SpeciesData species, IList<string> ids, bool scriptAllowsAwakened = false)
        {
            if (species == null) throw new ArgumentNullException(nameof(species));
            var problems = Problems(species.Id, ids, scriptAllowsAwakened);
            if (problems.Count > 0) throw new InvalidOperationException(string.Join("; ", problems));
            double hp = 1, atk = 1, def = 1, matk = 1, mdef = 1, spd = 1;
            var result = new VariedMonster { SpeciesId = species.Id, Rank = species.Rank, Element = species.Element };
            for (int i = 0; i < (ids?.Count ?? 0); i++)
            {
                var v = Get(ids[i]);
                double strength = _file.Stacking.StrengthByCount[Math.Min(i, _file.Stacking.StrengthByCount.Count - 1)];
                double Scaled(string stat) => v.StatMods.TryGetValue(stat, out var m) ? 1 + (m - 1) * strength : 1;
                hp *= Scaled("hp"); atk *= Scaled("atk"); def *= Scaled("def"); matk *= Scaled("matk"); mdef *= Scaled("mdef"); spd *= Scaled("spd");
                if (!string.IsNullOrEmpty(v.Element) && i == 0) result.Element = v.Element;
                result.Variations.Add(v.Id);
                if (!string.IsNullOrEmpty(v.VisualCue)) result.VisualCues.Add(v.VisualCue);
                if (!string.IsNullOrEmpty(v.WeaknessNote)) result.WeaknessNotes.Add(v.WeaknessNote);
            }
            var s = species.Stats ?? new StatBlock();
            int R(int stat, double mult) => (int)Math.Round(stat * mult, MidpointRounding.AwayFromZero);
            result.Stats = new StatBlock { Hp = R(s.Hp, hp), Atk = R(s.Atk, atk), Def = R(s.Def, def), Matk = R(s.Matk, matk), Mdef = R(s.Mdef, mdef), Spd = R(s.Spd, spd) };
            return result;
        }
    }
}
