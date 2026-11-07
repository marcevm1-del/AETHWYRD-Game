using System;
using System.Collections.Generic;
using System.Linq;

namespace Ascend.Core
{
    // Data-driven reactions and synergies (12_Systems/combat.md §7). Data: Data/Combat/reactions.json.
    // ReactionTable.Default reproduces the pairs that used to be hard-coded in Elements, so nothing changes
    // for callers that do not supply a table.

    public sealed class ReactionDot
    {
        public string Element { get; set; }
        public double DamagePerSecMult { get; set; }
        public double DurationSec { get; set; }
        public double TickSec { get; set; } = 1.0;
    }

    public sealed class ReactionHazard
    {
        public string Kind { get; set; }
        public double RadiusM { get; set; }
        public double DurationSec { get; set; }
        public double DamagePerSecMult { get; set; }
    }

    public sealed class ReactionStatus
    {
        /// <summary>"freeze" or "stun".</summary>
        public string Kind { get; set; }
        /// <summary>0 = use the number in combat_tuning.json reactions (the Default table does this).</summary>
        public double DurationSec { get; set; }
    }

    public sealed class SwirlData
    {
        public string Element { get; set; } = "Wind";
        public double SpreadRadiusM { get; set; } = 4.0;
        public double SpreadDamageMult { get; set; } = 0.5;
        public int MaxSpreadTargets { get; set; } = 3;
    }

    public sealed class ReactionData
    {
        /// <summary>Equals a <see cref="Reaction"/> enum name.</summary>
        public string Id { get; set; }
        /// <summary>The two elements (order does not matter).</summary>
        public List<string> Elements { get; set; } = new List<string>();
        public bool ConsumesAura { get; set; } = true;
        public double BonusDamageMult { get; set; } = 1.0;
        public ReactionDot Dot { get; set; }
        public ReactionHazard Hazard { get; set; }
        public ReactionStatus Status { get; set; }

        /// <summary>The enum value for <see cref="Id"/>; <see cref="Reaction.None"/> for null, numeric ("3", "-1") or undefined names.</summary>
        public Reaction ParsedId => !string.IsNullOrEmpty(Id) && Enum.IsDefined(typeof(Reaction), Id) && Enum.TryParse(Id, out Reaction r) ? r : Reaction.None;
    }

    public sealed class SynergyData
    {
        public string Id { get; set; }
        public string First { get; set; }
        public string Then { get; set; }
        public double WindowSec { get; set; }
        public double BonusDamageMult { get; set; } = 1.0;
        public string Note { get; set; }
    }

    public sealed class ReactionFile
    {
        public int Version { get; set; } = 1;
        public string Notes { get; set; }
        public SwirlData Swirl { get; set; } = new SwirlData();
        public List<ReactionData> Reactions { get; set; } = new List<ReactionData>();
        public List<SynergyData> Synergies { get; set; } = new List<SynergyData>();
    }

    /// <summary>What spreading a Swirl does: the (non-Wind) element goes to neighbours.</summary>
    public struct SwirlSpread
    {
        public Element Element;
        public double RadiusM;
        public double DamageMult;
        public int MaxTargets;
    }

    /// <summary>Everything one element hit produced on a target.</summary>
    public struct ReactionResult
    {
        public Reaction Reaction;
        /// <summary>Per-reaction damage multiplier (1 = none).</summary>
        public double BonusMult;
        public ReactionDot Dot;
        public ReactionHazard Hazard;
        /// <summary>Set only when <see cref="Reaction"/> is Swirl.</summary>
        public SwirlSpread? Swirl;
        /// <summary>Set when this reaction completed a synergy (first, then within the window).</summary>
        public SynergyData Synergy;
        /// <summary>Synergy damage multiplier (1 = none).</summary>
        public double SynergyMult;
        /// <summary>"freeze", "stun" or null.</summary>
        public string StatusKind;
        public double StatusDurationSec;
        /// <summary>BonusMult times SynergyMult.</summary>
        public double TotalMult => BonusMult * SynergyMult;

        public static ReactionResult None => new ReactionResult { Reaction = Reaction.None, BonusMult = 1.0, SynergyMult = 1.0 };
    }

    public sealed class ReactionTable
    {
        readonly Dictionary<(Element, Element), ReactionData> _pairs = new Dictionary<(Element, Element), ReactionData>();
        readonly Dictionary<Reaction, ReactionData> _byId = new Dictionary<Reaction, ReactionData>();
        readonly List<SynergyData> _synergies;

        public SwirlData Swirl { get; }
        public IReadOnlyList<SynergyData> Synergies => _synergies;

        public ReactionTable(ReactionFile file)
        {
            if (file == null) throw new ArgumentNullException(nameof(file));
            Swirl = file.Swirl ?? new SwirlData();
            _synergies = (file.Synergies ?? new List<SynergyData>()).ToList();
            foreach (var r in file.Reactions ?? new List<ReactionData>())
            {
                var id = r.ParsedId;
                if (id == Reaction.None) throw new InvalidOperationException($"reaction \"{r.Id}\" is not a known Reaction");
                if (_byId.ContainsKey(id)) throw new InvalidOperationException($"duplicate reaction \"{r.Id}\"");
                _byId[id] = r;
                if (id == Reaction.Swirl) continue;   // Swirl is a rule (Wind + anything), not a pair
                if (r.Elements == null || r.Elements.Count != 2) continue;
                if (!Enum.TryParse(r.Elements[0], out Element a) || !Enum.TryParse(r.Elements[1], out Element b)) continue;
                if (a == Element.None || b == Element.None || a == b) continue;   // wildcard-style entries (Swirl) are handled by the Swirl rule
                if (_pairs.ContainsKey((a, b))) throw new InvalidOperationException($"duplicate reaction pair {a}+{b}");
                _pairs[(a, b)] = r;
                _pairs[(b, a)] = r;
            }
        }

        static ReactionTable _default;
        /// <summary>The ten reactions exactly as <see cref="Elements"/> had them hard-coded.</summary>
        public static ReactionTable Default => _default ??= new ReactionTable(DefaultFile());

        static ReactionFile DefaultFile()
        {
            ReactionData R(Reaction id, Element a, Element b, string status = null) => new ReactionData
            {
                Id = id.ToString(),
                Elements = new List<string> { a.ToString(), b.ToString() },
                ConsumesAura = true,
                Status = status == null ? null : new ReactionStatus { Kind = status, DurationSec = 0 },
            };
            return new ReactionFile
            {
                Notes = "Built-in defaults (the original hard-coded pairs).",
                Reactions = new List<ReactionData>
                {
                    R(Reaction.Firestorm, Element.Fire, Element.Wind),
                    R(Reaction.StormPrison, Element.Water, Element.Lightning, "stun"),
                    R(Reaction.Freeze, Element.Water, Element.Ice, "freeze"),
                    R(Reaction.ThermalShock, Element.Fire, Element.Ice),
                    R(Reaction.Magma, Element.Earth, Element.Fire),
                    // Swirl: Wind with any other element; the aura is kept (see Swirl rule in React).
                    new ReactionData { Id = nameof(Reaction.Swirl), Elements = new List<string> { "Wind", "Wind" }, ConsumesAura = false },
                    R(Reaction.Wildfire, Element.Nature, Element.Fire),
                    R(Reaction.TwilightBurst, Element.Light, Element.Dark),
                    R(Reaction.MiasmaBlast, Element.Poison, Element.Fire),
                    R(Reaction.Grounded, Element.Lightning, Element.Earth),
                },
            };
        }

        /// <summary>
        /// Reaction when <paramref name="trigger"/> hits a target carrying <paramref name="aura"/>.
        /// Specific pairs win; otherwise Wind meeting any other element is a Swirl.
        /// </summary>
        public Reaction React(Element aura, Element trigger)
        {
            if (aura == Element.None || trigger == Element.None || aura == trigger) return Reaction.None;
            if (_pairs.TryGetValue((aura, trigger), out var r)) return r.ParsedId;
            if (aura == Element.Wind || trigger == Element.Wind) return Reaction.Swirl;
            return Reaction.None;
        }

        /// <summary>The data row for a reaction, or null.</summary>
        public ReactionData Get(Reaction reaction) => _byId.TryGetValue(reaction, out var d) ? d : null;

        /// <summary>Whether triggering this reaction removes the aura. Swirl never does (it keeps the aura). Missing rows consume (today's behaviour).</summary>
        public bool ConsumesAura(Reaction reaction)
        {
            if (reaction == Reaction.Swirl) return false;
            var d = Get(reaction);
            return d == null || d.ConsumesAura;
        }

        /// <summary>The synergy that fires when <paramref name="then"/> follows <paramref name="first"/> <paramref name="elapsedSec"/> later, or null.</summary>
        public SynergyData FindSynergy(Reaction first, Reaction then, double elapsedSec)
        {
            if (first == Reaction.None || then == Reaction.None) return null;
            foreach (var s in _synergies)
                if (s.First == first.ToString() && s.Then == then.ToString() && elapsedSec >= 0 && elapsedSec <= s.WindowSec)
                    return s;
            return null;
        }

        /// <summary>Builds the full result for a reaction that just triggered.</summary>
        public ReactionResult Describe(Reaction reaction, Element aura, Element trigger, ReactionTuning tuning)
        {
            var res = ReactionResult.None;
            if (reaction == Reaction.None) return res;
            res.Reaction = reaction;
            var d = Get(reaction);
            if (d != null)
            {
                res.BonusMult = d.BonusDamageMult > 0 ? d.BonusDamageMult : 1.0;
                res.Dot = d.Dot;
                res.Hazard = d.Hazard;
                if (d.Status != null && !string.IsNullOrEmpty(d.Status.Kind))
                {
                    res.StatusKind = d.Status.Kind;
                    res.StatusDurationSec = d.Status.DurationSec > 0 ? d.Status.DurationSec : TuningDuration(d.Status.Kind, tuning);
                }
            }
            if (res.StatusKind == null)
            {
                // Built-in rule: Freeze freezes and StormPrison stuns even if a custom row forgot the status.
                if (reaction == Reaction.Freeze) { res.StatusKind = "freeze"; res.StatusDurationSec = TuningDuration("freeze", tuning); }
                else if (reaction == Reaction.StormPrison) { res.StatusKind = "stun"; res.StatusDurationSec = TuningDuration("stun", tuning); }
            }
            if (reaction == Reaction.Swirl)
            {
                res.Swirl = new SwirlSpread
                {
                    Element = aura == Element.Wind ? trigger : aura,
                    RadiusM = Swirl.SpreadRadiusM,
                    DamageMult = Swirl.SpreadDamageMult,
                    MaxTargets = Swirl.MaxSpreadTargets,
                };
            }
            return res;
        }

        static double TuningDuration(string kind, ReactionTuning t)
        {
            if (t == null) return 0;
            return kind == "freeze" ? t.FreezeDurationSec : kind == "stun" ? t.StormPrisonStunSec : 0;
        }
    }
}
