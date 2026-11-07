using System;
using System.Collections.Generic;
using System.Linq;

namespace Ascend.Core
{
    // Companion relationships (companion_relationship_pacing.md, Canon rows 57-62).
    // Four SEPARATE tracks (trust, respect, closeness, tension); there is deliberately no combined loyalty,
    // approval, affinity or score number. Numbers: Data/Companions/companion_rules.json "relationships".
    // Defaults below equal the shipped JSON so an old data folder still behaves.

    public enum RelationTrack { Trust, Respect, Closeness, Tension }

    /// <summary>Kaito availability is a story state, not a number.</summary>
    public enum CompanionAvailability { Ally, Rival, Fallen }

    public enum RelationApplyResult { Applied, UnknownEvent, OnceAlreadySeen, OnCooldown, CompanionDeparted }

    public sealed class RelationStage
    {
        public string Id { get; set; }
        public int Min { get; set; }
    }

    public sealed class TrackTuning
    {
        public int Start { get; set; }
        /// <summary>Tension only: how much it eases per quiet day.</summary>
        public int EasePerDay { get; set; }
        public List<RelationStage> Stages { get; set; } = new List<RelationStage>();

        /// <summary>Index of the highest stage whose Min the value reaches.</summary>
        public int StageIndex(int value)
        {
            int idx = 0;
            for (int i = 0; i < Stages.Count; i++) if (value >= Stages[i].Min) idx = i;
            return idx;
        }

        public string StageId(int value) => Stages.Count == 0 ? "" : Stages[StageIndex(value)].Id;

        /// <summary>Index of a named stage, or -1 when the name is unknown.</summary>
        public int IndexOf(string id) => Stages.FindIndex(s => string.Equals(s.Id, id, StringComparison.OrdinalIgnoreCase));
    }

    public sealed class RomanceTuning
    {
        public string MinCloseness { get; set; } = "trusted";
        public string MinTrust { get; set; } = "reliable";
        public int MaxTensionExclusive { get; set; } = 40;
    }

    public sealed class DepartureTuning
    {
        public int MinTension { get; set; } = 80;
        public bool RequiresForeshadow { get; set; } = true;
        public bool RequiresRepairOffered { get; set; } = true;
    }

    public sealed class KaitoTuning
    {
        public string Start { get; set; } = "rival";
    }

    /// <summary>One event: which tracks it moves (and by how much), plus its anti-farming rule.</summary>
    public sealed class RelationEventData
    {
        /// <summary>Keys are track names (trust, respect, closeness, tension). A track not listed is never moved.</summary>
        public Dictionary<string, int> Deltas { get; set; } = new Dictionary<string, int>();
        public bool Once { get; set; }
        public int CooldownDays { get; set; }
        public bool Foreshadow { get; set; }
        public bool OffersRepair { get; set; }
        public bool Repair { get; set; }
    }

    public sealed class RelationshipRules
    {
        public int MaxDeltaPerEvent { get; set; } = 6;
        public Dictionary<string, TrackTuning> Tracks { get; set; } = DefaultTracks();
        public RomanceTuning Romance { get; set; } = new RomanceTuning();
        public DepartureTuning Departure { get; set; } = new DepartureTuning();
        public KaitoTuning Kaito { get; set; } = new KaitoTuning();
        public Dictionary<string, RelationEventData> Events { get; set; } = new Dictionary<string, RelationEventData>();

        /// <summary>Companions that can never be romanced, whatever their numbers or data say (Canon row 57).</summary>
        public static readonly string[] NeverRomance = { "cmp_nyx", "cmp_mochi" };
        public const string KaitoId = "cmp_kaito";

        static List<RelationStage> St(params (string, int)[] a) => a.Select(x => new RelationStage { Id = x.Item1, Min = x.Item2 }).ToList();

        static Dictionary<string, TrackTuning> DefaultTracks() => new Dictionary<string, TrackTuning>
        {
            ["trust"] = new TrackTuning { Start = 10, Stages = St(("wary", 0), ("steady", 25), ("reliable", 50), ("steadfast", 75)) },
            ["respect"] = new TrackTuning { Start = 10, Stages = St(("unproven", 0), ("noted", 25), ("regarded", 50), ("admired", 75)) },
            ["closeness"] = new TrackTuning { Start = 0, Stages = St(("stranger", 0), ("working", 25), ("trusted", 50), ("close", 75)) },
            ["tension"] = new TrackTuning { Start = 0, EasePerDay = 2, Stages = St(("calm", 0), ("uneasy", 25), ("strained", 50), ("breaking", 75)) },
        };

        public TrackTuning Track(RelationTrack t)
        {
            var key = t.ToString().ToLowerInvariant();
            if (Tracks != null && Tracks.TryGetValue(key, out var tt) && tt != null) return tt;
            return DefaultTracks()[key];
        }

        public CompanionAvailability KaitoStart =>
            Enum.TryParse<CompanionAvailability>(Kaito?.Start, true, out var a) ? a : CompanionAvailability.Rival;

        public RelationshipState NewState(string companionId = null)
        {
            var s = new RelationshipState
            {
                Trust = Track(RelationTrack.Trust).Start,
                Respect = Track(RelationTrack.Respect).Start,
                Closeness = Track(RelationTrack.Closeness).Start,
                Tension = Track(RelationTrack.Tension).Start,
            };
            if (companionId == KaitoId) s.Availability = KaitoStart;
            return s;
        }

        /// <summary>
        /// Applies a named event on a day. Only the tracks the event names move, each capped to
        /// +/-MaxDeltaPerEvent and kept in 0..100. Once-only and cooldown events cannot be farmed. An event the
        /// data does not know (e.g. a repeated banter line) changes nothing. A departed companion only
        /// reacts to a repair event.
        /// </summary>
        public RelationApplyResult Apply(RelationshipState s, string eventKey, int day)
        {
            if (s == null || eventKey == null || Events == null || !Events.TryGetValue(eventKey, out var e) || e == null)
                return RelationApplyResult.UnknownEvent;
            if (s.Departed && !e.Repair) return RelationApplyResult.CompanionDeparted;
            if (s.LastSeenDay.TryGetValue(eventKey, out var last))
            {
                if (e.Once) return RelationApplyResult.OnceAlreadySeen;
                if (e.CooldownDays > 0 && day - last < e.CooldownDays) return RelationApplyResult.OnCooldown;
            }
            int cap = Math.Max(0, MaxDeltaPerEvent);
            foreach (var kv in e.Deltas ?? new Dictionary<string, int>())
            {
                if (!Enum.TryParse<RelationTrack>(kv.Key, true, out var t)) continue;
                int d = Math.Max(-cap, Math.Min(cap, kv.Value));
                s.Set(t, Clamp(s.Get(t) + d));
            }
            if (e.Foreshadow) s.Foreshadowed = true;
            if (e.OffersRepair) s.RepairOffered = true;
            if (e.Repair && s.Departed)
            {
                s.Departed = false;
                s.Foreshadowed = false;   // a fresh warning is needed before anyone can leave again
                s.RepairOffered = false;
            }
            s.LastSeenDay[eventKey] = day;
            return RelationApplyResult.Applied;
        }

        /// <summary>Tension eases slowly with quiet days. No other track decays.</summary>
        public void Ease(RelationshipState s, int days)
        {
            if (s == null || days <= 0) return;
            s.Tension = Clamp(s.Tension - Track(RelationTrack.Tension).EasePerDay * days);
        }

        /// <summary>
        /// Romance gate. The roster row must be romanceable AND adult; the player must have opted in; closeness
        /// and trust must reach their minimum stage; tension must be under its ceiling; the companion must not
        /// have left. Nyx and Mochi fail regardless of anything else.
        /// </summary>
        public bool CanRomance(CompanionData c, RelationshipState s)
        {
            if (c == null || s == null) return false;
            if (NeverRomance.Contains(c.Id)) return false;
            if (!c.Romanceable || !c.Adult) return false;
            if (!s.RomanceOptIn || s.Departed) return false;
            var rm = Romance ?? new RomanceTuning();
            var cl = Track(RelationTrack.Closeness);
            var tr = Track(RelationTrack.Trust);
            int ci = cl.IndexOf(rm.MinCloseness), ti = tr.IndexOf(rm.MinTrust);
            if (ci < 0 || ti < 0) return false;   // a misnamed stage never opens the gate
            return cl.StageIndex(s.Closeness) >= ci && tr.StageIndex(s.Trust) >= ti && s.Tension < rm.MaxTensionExclusive;
        }

        /// <summary>
        /// A companion may leave only when tension is at the threshold AND a foreshadowing beat has been seen
        /// AND a repair chance has been offered. Never by timers, pathing or missed payments.
        /// </summary>
        public bool MayDepart(RelationshipState s)
        {
            if (s == null || s.Departed) return false;
            var d = Departure ?? new DepartureTuning();
            return s.Tension >= d.MinTension
                && (!d.RequiresForeshadow || s.Foreshadowed)
                && (!d.RequiresRepairOffered || s.RepairOffered);
        }

        /// <summary>Leaves if (and only if) <see cref="MayDepart"/> allows it.</summary>
        public bool TryDepart(RelationshipState s)
        {
            if (!MayDepart(s)) return false;
            s.Departed = true;
            return true;
        }

        public static int Clamp(int v) => Math.Max(0, Math.Min(100, v));
    }

    /// <summary>Runtime relationship with one companion. Four independent tracks, no combined number.</summary>
    public sealed class RelationshipState
    {
        public int Trust { get; set; }
        public int Respect { get; set; }
        public int Closeness { get; set; }
        public int Tension { get; set; }
        public bool RomanceOptIn { get; set; }
        public bool Departed { get; set; }
        public bool Foreshadowed { get; set; }
        public bool RepairOffered { get; set; }
        /// <summary>Only meaningful for Kaito (ally / rival / fallen); everyone else stays Ally.</summary>
        public CompanionAvailability Availability { get; set; } = CompanionAvailability.Ally;
        /// <summary>Event key to the last day it applied (the once-only and cooldown memory).</summary>
        public Dictionary<string, int> LastSeenDay { get; } = new Dictionary<string, int>();

        public int Get(RelationTrack t) => t switch
        {
            RelationTrack.Trust => Trust,
            RelationTrack.Respect => Respect,
            RelationTrack.Closeness => Closeness,
            _ => Tension,
        };

        public void Set(RelationTrack t, int v)
        {
            switch (t)
            {
                case RelationTrack.Trust: Trust = v; break;
                case RelationTrack.Respect: Respect = v; break;
                case RelationTrack.Closeness: Closeness = v; break;
                default: Tension = v; break;
            }
        }

        public CompanionBondSave ToSave(string companionId)
        {
            var b = new CompanionBondSave
            {
                CompanionId = companionId, Trust = Trust, Respect = Respect, Closeness = Closeness, Tension = Tension,
                RomanceOptIn = RomanceOptIn, Departed = Departed, Foreshadowed = Foreshadowed, RepairOffered = RepairOffered,
                Availability = Availability.ToString(),
            };
            foreach (var kv in LastSeenDay) b.Seen.Add(kv.Key + "@" + kv.Value);
            return b;
        }

        /// <summary>Null-safe: an older save (no bond data) yields the rules starting values.</summary>
        public static RelationshipState FromSave(CompanionBondSave save, RelationshipRules rules = null, string companionId = null)
        {
            rules = rules ?? new RelationshipRules();
            if (save == null) return rules.NewState(companionId);
            var s = new RelationshipState
            {
                Trust = RelationshipRules.Clamp(save.Trust), Respect = RelationshipRules.Clamp(save.Respect),
                Closeness = RelationshipRules.Clamp(save.Closeness), Tension = RelationshipRules.Clamp(save.Tension),
                RomanceOptIn = save.RomanceOptIn, Departed = save.Departed, Foreshadowed = save.Foreshadowed, RepairOffered = save.RepairOffered,
                Availability = Enum.TryParse<CompanionAvailability>(save.Availability, true, out var a)
                    ? a
                    : ((companionId ?? save.CompanionId) == RelationshipRules.KaitoId ? rules.KaitoStart : CompanionAvailability.Ally),
            };
            foreach (var item in save.Seen ?? new List<string>())
            {
                int at = item == null ? -1 : item.LastIndexOf('@');
                if (at > 0 && int.TryParse(item.Substring(at + 1), out var day)) s.LastSeenDay[item.Substring(0, at)] = day;
            }
            return s;
        }
    }

    /// <summary>Compact save row for one companion bond (plain DTO; the game serialises it).</summary>
    public sealed class CompanionBondSave
    {
        public string CompanionId { get; set; }
        public int Trust { get; set; }
        public int Respect { get; set; }
        public int Closeness { get; set; }
        public int Tension { get; set; }
        public bool RomanceOptIn { get; set; }
        public bool Departed { get; set; }
        public bool Foreshadowed { get; set; }
        public bool RepairOffered { get; set; }
        /// <summary>"Ally", "Rival" or "Fallen" (Kaito only).</summary>
        public string Availability { get; set; }
        /// <summary>"eventKey@day" entries.</summary>
        public List<string> Seen { get; set; } = new List<string>();
    }
}
