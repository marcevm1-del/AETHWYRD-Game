using System;
using System.Collections.Generic;
using System.Linq;

namespace Ascend.Core
{
    // Regional Siege & Liberation (12_Systems/systems.md; Canon §4b). Engine-agnostic: time is passed in as day numbers.

    public enum RegionState { Besieged, Weakened, Liberated }

    /// <summary>One region's threat: Besieged → (Weakened) → Liberated (permanent), plus weekly escalation.</summary>
    public sealed class RegionThreat
    {
        readonly SiegeTuning _t;
        public string RegionId { get; }
        public RegionState State { get; private set; }
        /// <summary>Raw escalation: +1 per in-game week the Tyrant lives, capped.</summary>
        public int Escalation { get; private set; }

        public RegionThreat(string regionId, RegionState initial, SiegeTuning tuning)
        {
            RegionId = regionId ?? throw new ArgumentNullException(nameof(regionId));
            _t = tuning ?? throw new ArgumentNullException(nameof(tuning));
            State = initial;
        }

        public static RegionState Parse(string s) =>
            s == "weakened" ? RegionState.Weakened : s == "liberated" ? RegionState.Liberated : RegionState.Besieged;

        public bool UnderSiege => State != RegionState.Liberated;

        /// <summary>Escalation that applies to attacks: Weakened regions attack with less; Liberated ones never.</summary>
        public int EffectiveEscalation =>
            State == RegionState.Liberated ? 0 :
            State == RegionState.Weakened ? Math.Max(0, Escalation - _t.WeakenedEscalationReduction) : Escalation;

        public void OnWeekEnded()
        {
            if (State == RegionState.Liberated) return;
            Escalation = Math.Min(_t.MaxEscalation, Escalation + _t.EscalationPerWeek);
        }

        /// <summary>The Tyrant's lieutenants/dens are cleared: attacks get easier.</summary>
        public void LieutenantsCleared() { if (State == RegionState.Besieged) State = RegionState.Weakened; }

        /// <summary>The Tyrant is slain: the region is Liberated for good.</summary>
        public void TyrantSlain() { State = RegionState.Liberated; Escalation = 0; }
    }

    public sealed class SiegeAttack
    {
        public string RegionId;
        public int Week;
        /// <summary>Absolute in-game day number (day 0 is a Solenday).</summary>
        public int Day;
        /// <summary>0..6 (Solenday..Vexday).</summary>
        public int Weekday;
        public double Hour;
        public string Settlement;
        /// <summary>Day the attack is posted on the guild and rumor boards.</summary>
        public int AnnouncedOnDay;
    }

    /// <summary>
    /// Decides when Besieged regions attack: 1–2 times per 7-day week, at random, usually at dusk,
    /// never on two consecutive days (including across the week boundary). Deterministic per world seed.
    /// </summary>
    public sealed class SiegeScheduler
    {
        public const int DaysPerWeek = 7;
        readonly SiegeTuning _t;
        readonly ulong _worldSeed;

        public SiegeScheduler(SiegeTuning tuning, ulong worldSeed)
        {
            _t = tuning ?? throw new ArgumentNullException(nameof(tuning));
            _worldSeed = worldSeed;
        }

        public IReadOnlyList<SiegeAttack> AttacksInWeek(RegionData region, int week, RegionThreat threat = null)
        {
            if (region == null) throw new ArgumentNullException(nameof(region));
            if (region.NoSiege || (threat != null && !threat.UnderSiege) || region.DefenceSettlements == null || region.DefenceSettlements.Count == 0)
                return Array.Empty<SiegeAttack>();

            var days = DaysOfWeek(region.Id, week);
            var rng = DeterministicRandom.For(_worldSeed, "siege-detail", region.Id, week);
            return days.Select(d => new SiegeAttack
            {
                RegionId = region.Id,
                Week = week,
                Day = week * DaysPerWeek + d,
                Weekday = d,
                Hour = rng.NextDouble() < _t.DuskChance ? _t.DuskHour : _t.NightHour,
                Settlement = region.DefenceSettlements[rng.Next(0, region.DefenceSettlements.Count)],
                AnnouncedOnDay = week * DaysPerWeek + d - _t.AnnounceDaysAhead
            }).ToList();
        }

        public SiegeAttack AttackOnDay(RegionData region, int day, RegionThreat threat = null)
        {
            int week = FloorDiv(day, DaysPerWeek);
            return AttacksInWeek(region, week, threat).FirstOrDefault(a => a.Day == day);
        }

        /// <summary>Weekdays (0..6) with an attack this week, sorted.</summary>
        public int[] DaysOfWeek(string regionId, int week)
        {
            var days = RawDays(regionId, week);
            if (week > 0 && days.Contains(0) && RawDays(regionId, week - 1).Contains(DaysPerWeek - 1))
            {
                // Avoid an attack on Vexday followed by one on Solenday: move this one to the first free, non-adjacent day.
                days.Remove(0);
                for (int d = 1; d < DaysPerWeek; d++)
                    if (!days.Any(x => Math.Abs(x - d) <= 1)) { days.Add(d); break; }
            }
            days.Sort();
            return days.ToArray();
        }

        // Within-week schedule only (no cross-week fix), so DaysOfWeek can look one week back without recursion.
        List<int> RawDays(string regionId, int week)
        {
            var rng = DeterministicRandom.For(_worldSeed, "siege-days", regionId, week);
            int count = _t.MinAttacksPerWeek;
            if (_t.MaxAttacksPerWeek > count && rng.NextDouble() < _t.SecondAttackChance) count++;
            var days = new List<int>();
            for (int guard = 0; days.Count < count && guard < 64; guard++)
            {
                int d = rng.Next(0, DaysPerWeek);
                if (days.Any(x => Math.Abs(x - d) <= 1)) continue; // not the same day, not consecutive
                days.Add(d);
            }
            return days;
        }

        static int FloorDiv(int a, int b) => (int)Math.Floor((double)a / b);
    }

    public struct SettlementDefence
    {
        /// <summary>Prosperity Safety, 0–100.</summary>
        public double Safety;
        public int Guards;
        public int NpcAdventurers;
        public int Barricades;
    }

    public enum SiegeOutcome { Repelled, CostlyVictory, Breached }

    public struct SiegeResult
    {
        public SiegeOutcome Outcome;
        public int WealthLoss;
        public int SafetyLoss;
        public int BuildingsDamaged;
        /// <summary>Always false: settlements are never destroyed by sieges (Canon §5).</summary>
        public bool SettlementDestroyed => false;
    }

    /// <summary>Resolves a siege the player skipped (Canon §4b): Prosperity losses and repairable damage, never destruction.</summary>
    public static class SiegeAutoResolve
    {
        public static SiegeResult Resolve(SettlementDefence d, int escalation, AutoResolveTuning t, IRandom rng)
        {
            if (t == null) throw new ArgumentNullException(nameof(t));
            if (rng == null) throw new ArgumentNullException(nameof(rng));
            double defence = Math.Max(0, Math.Min(100, d.Safety)) * t.SafetyWeight + d.Guards * t.GuardWeight
                           + d.NpcAdventurers * t.AdventurerWeight + d.Barricades * t.BarricadeWeight;
            double threat = t.BaseThreat + Math.Max(0, escalation) * t.EscalationThreat;
            double margin = defence - threat + (rng.NextDouble() - 0.5) * t.Variance;

            if (margin >= t.RepelMargin)
                return new SiegeResult { Outcome = SiegeOutcome.Repelled };

            if (margin >= t.CostlyMargin)
            {
                return new SiegeResult
                {
                    Outcome = SiegeOutcome.CostlyVictory,
                    WealthLoss = (int)Math.Ceiling(t.MaxWealthLoss * 0.3),
                    SafetyLoss = (int)Math.Ceiling(t.MaxSafetyLoss * 0.3),
                    BuildingsDamaged = 0
                };
            }

            // Breached: losses grow with how badly the defence fell short, up to the caps.
            double severity = Math.Min(1.0, (t.CostlyMargin - margin) / Math.Max(1, t.BaseThreat));
            return new SiegeResult
            {
                Outcome = SiegeOutcome.Breached,
                WealthLoss = (int)Math.Ceiling(t.MaxWealthLoss * (0.5 + 0.5 * severity)),
                SafetyLoss = (int)Math.Ceiling(t.MaxSafetyLoss * (0.5 + 0.5 * severity)),
                BuildingsDamaged = Math.Max(1, (int)Math.Round(t.MaxBuildingsDamaged * severity))
            };
        }
    }

    /// <summary>A settlement's Prosperity stats as touched by sieges. Never drops below the floor; damage is always repairable.</summary>
    public sealed class SettlementProsperity
    {
        readonly int _floor;
        public string Name { get; }
        public int Wealth { get; private set; }
        public int Safety { get; private set; }
        public int DamagedBuildings { get; private set; }

        public SettlementProsperity(string name, int wealth, int safety, int floor)
        {
            Name = name; _floor = Math.Max(0, floor);
            Wealth = Clamp(wealth); Safety = Clamp(safety);
        }

        public void Apply(SiegeResult r)
        {
            Wealth = Clamp(Wealth - r.WealthLoss);
            Safety = Clamp(Safety - r.SafetyLoss);
            DamagedBuildings += r.BuildingsDamaged;
        }

        public void Repair(int buildings) => DamagedBuildings = Math.Max(0, DamagedBuildings - Math.Max(0, buildings));
        public void Raise(int wealth, int safety) { Wealth = Clamp(Wealth + wealth); Safety = Clamp(Safety + safety); }

        int Clamp(int v) => Math.Max(_floor, Math.Min(100, v));
    }
}
