using System;
using System.Collections.Generic;
using System.Linq;

namespace Ascend.Core
{
    // Monster evolution lines (13_Production/monster_guild_integration.md; Canon section 6 proposal M1).
    // Data: Data/Monsters/evolution_lines.json (30 groups, nine named stages each) and species_lines.json (which species sits where).
    // A line is a naming and progression template laid OVER the 31 game families. Nothing here sets stats or threat: a species'
    // threat rank is its own Rank and is never inferred from its stage (bible section 6). Canon 4d: monsters never evolve because
    // they defeated the player, so those triggers are refused.

    public sealed class EvolutionStageData
    {
        public int Stage { get; set; }
        public string Label { get; set; }
    }

    public sealed class EvolutionLineData
    {
        public string Id { get; set; }
        public int Order { get; set; }
        public string Name { get; set; }
        public string BibleFamily { get; set; }
        public List<string> FamilyKeys { get; set; } = new List<string>();
        public string Identity { get; set; }
        public List<EvolutionStageData> Stages { get; set; } = new List<EvolutionStageData>();
        public List<string> Branches { get; set; } = new List<string>();
        public List<string> Variants { get; set; } = new List<string>();
        public string SignatureAbilities { get; set; }
        public string Society { get; set; }
    }

    public sealed class EvolutionConditionKind
    {
        public string Id { get; set; }
        public string Text { get; set; }
    }

    public sealed class FusionRulesData
    {
        public bool RequiresCatalyst { get; set; }
        public bool RequiresStableEnergy { get; set; }
        public bool RequiresCost { get; set; }
        public bool OnlyListedPairs { get; set; }
    }

    public sealed class FusionData
    {
        public string A { get; set; }
        public string B { get; set; }
        public string Result { get; set; }
        public string Note { get; set; }
    }

    public sealed class EvolutionLineFile
    {
        public string Notes { get; set; }
        public List<string> StageGrammar { get; set; } = new List<string>();
        public List<EvolutionConditionKind> ConditionKinds { get; set; } = new List<EvolutionConditionKind>();
        public List<string> ForbiddenTriggers { get; set; } = new List<string>();
        public FusionRulesData FusionRules { get; set; } = new FusionRulesData();
        public List<FusionData> Fusions { get; set; } = new List<FusionData>();
        public List<EvolutionLineData> Groups { get; set; } = new List<EvolutionLineData>();
    }

    public sealed class SpeciesLineAssignment
    {
        public string SpeciesId { get; set; }
        public string LineId { get; set; }
        public int Stage { get; set; }
        public string Method { get; set; }
    }

    public sealed class SpeciesLineFile
    {
        public string Notes { get; set; }
        public List<string> Unassigned { get; set; } = new List<string>();
        public List<SpeciesLineAssignment> Assignments { get; set; } = new List<SpeciesLineAssignment>();
    }

    /// <summary>The outcome of asking whether a species may take its next stage.</summary>
    public readonly struct EvolutionCheck
    {
        public readonly bool Allowed;
        public readonly string Reason;
        public readonly int ToStage;
        public EvolutionCheck(bool allowed, string reason, int toStage) { Allowed = allowed; Reason = reason; ToStage = toStage; }
    }

    public sealed class MonsterLines
    {
        readonly EvolutionLineFile _lines;
        readonly Dictionary<string, EvolutionLineData> _byId;
        readonly Dictionary<string, SpeciesLineAssignment> _bySpecies;
        readonly Dictionary<string, List<string>> _inLine;

        public MonsterLines(EvolutionLineFile lines, SpeciesLineFile assignments)
        {
            _lines = lines ?? new EvolutionLineFile();
            _byId = new Dictionary<string, EvolutionLineData>();
            foreach (var l in _lines.Groups) _byId[l.Id] = l;
            _bySpecies = new Dictionary<string, SpeciesLineAssignment>();
            _inLine = new Dictionary<string, List<string>>();
            foreach (var a in (assignments ?? new SpeciesLineFile()).Assignments)
            {
                if (!_byId.ContainsKey(a.LineId)) throw new InvalidOperationException($"species {a.SpeciesId} names unknown line {a.LineId}");
                if (_bySpecies.ContainsKey(a.SpeciesId)) throw new InvalidOperationException($"species {a.SpeciesId} is assigned twice");
                _bySpecies[a.SpeciesId] = a;
                if (!_inLine.TryGetValue(a.LineId, out var list)) _inLine[a.LineId] = list = new List<string>();
                list.Add(a.SpeciesId);
            }
        }

        public IReadOnlyList<EvolutionLineData> Lines => _lines.Groups;
        public EvolutionLineFile File => _lines;
        public EvolutionLineData Line(string lineId) => lineId != null && _byId.TryGetValue(lineId, out var l) ? l : null;

        /// <summary>The line a species sits in, or null (kobolds, floor-born, sandborne and humanoid enemies have no bible group).</summary>
        public EvolutionLineData LineOf(string speciesId) =>
            speciesId != null && _bySpecies.TryGetValue(speciesId, out var a) ? _byId[a.LineId] : null;

        /// <summary>The 1 to 9 stage of a species in its line, or 0 when it has no line.</summary>
        public int StageOf(string speciesId) => speciesId != null && _bySpecies.TryGetValue(speciesId, out var a) ? a.Stage : 0;

        public string StageLabel(string lineId, int stage) =>
            Line(lineId)?.Stages.FirstOrDefault(s => s.Stage == stage)?.Label;

        public IReadOnlyList<string> SpeciesInLine(string lineId) =>
            lineId != null && _inLine.TryGetValue(lineId, out var l) ? l : (IReadOnlyList<string>)Array.Empty<string>();

        /// <summary>True when a trigger may be used to evolve a monster. Canon 4d: never because it defeated or hurt the player.</summary>
        public bool IsTriggerAllowed(string trigger) =>
            !string.IsNullOrEmpty(trigger) && !_lines.ForbiddenTriggers.Contains(trigger);

        /// <summary>
        /// May a species step to its next stage? It needs a stage below 9, an allowed trigger and at least one known evolution condition
        /// met (experience, age, mana, environment, materials, achievement, awakening). Rare (stage 8 to 9) steps need two.
        /// </summary>
        public EvolutionCheck CheckEvolution(string speciesId, string trigger, ICollection<string> conditionsMet)
        {
            int stage = StageOf(speciesId);
            if (stage == 0) return new EvolutionCheck(false, "this species has no evolution line", 0);
            if (stage >= 9) return new EvolutionCheck(false, "already at the last stage", 0);
            if (!IsTriggerAllowed(trigger)) return new EvolutionCheck(false, "that trigger is not allowed (monsters never grow from defeating the player)", 0);
            var known = new HashSet<string>(_lines.ConditionKinds.Select(c => c.Id));
            int met = (conditionsMet ?? Array.Empty<string>()).Count(c => known.Contains(c));
            int need = stage >= 8 ? 2 : 1;
            if (met < need) return new EvolutionCheck(false, $"needs {need} evolution condition(s) met", 0);
            return new EvolutionCheck(true, "ok", stage + 1);
        }

        /// <summary>The species a stage maps to in its line, for display: "Hobgoblin Knight" and so on.</summary>
        public string NextLabel(string speciesId)
        {
            var line = LineOf(speciesId);
            return line == null ? null : StageLabel(line.Id, StageOf(speciesId) + 1);
        }

        /// <summary>Fusion needs a catalyst, stable energy and a cost, and only the listed pairs of lines fuse. Returns the result name or null.</summary>
        public string Fuse(string lineA, string lineB, bool catalyst, bool stableEnergy, bool cost)
        {
            var r = _lines.FusionRules;
            if (r.RequiresCatalyst && !catalyst) return null;
            if (r.RequiresStableEnergy && !stableEnergy) return null;
            if (r.RequiresCost && !cost) return null;
            var f = _lines.Fusions.FirstOrDefault(x => (x.A == lineA && x.B == lineB) || (x.A == lineB && x.B == lineA));
            if (f == null && r.OnlyListedPairs) return null;
            return f?.Result;
        }
    }
}
