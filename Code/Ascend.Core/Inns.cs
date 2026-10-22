using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Ascend.Core
{
    // Inns (12_Systems/inns.md; Data/World/inns.json, schema inn).

    public sealed class InnRoom
    {
        /// <summary>"common", "private", "suite" or "signature".</summary>
        public string Tier { get; set; }
        public string Name { get; set; }
        public int PriceCopper { get; set; }
        /// <summary>e.g. "Rested (2h)", "Well Rested (4h)", "Well Rested (8h) + meal".</summary>
        public string Rest { get; set; }
        public string Perk { get; set; }
    }

    public sealed class InnFare { public string Name { get; set; } public string Effect { get; set; } }

    /// <summary>Mirror of one entry in Data/World/inns.json.</summary>
    public sealed class InnData
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string RegionId { get; set; }
        public string Settlement { get; set; }
        public string Tier { get; set; }
        public int Ring { get; set; }
        public string KeeperNpcId { get; set; }
        public string KeeperName { get; set; }
        public List<InnRoom> Rooms { get; set; } = new List<InnRoom>();
        public InnFare Dish { get; set; }
        public InnFare Drink { get; set; }
        public string Quirk { get; set; }
        public string RumorTheme { get; set; }
        public List<string> Events { get; set; } = new List<string>();
        public string Secret { get; set; }

        public InnRoom Room(string tier) => Rooms.FirstOrDefault(r => r.Tier == tier);
    }

    public enum RestKind { Rested, WellRested }

    public sealed class RestBuff
    {
        public RestKind Kind;
        /// <summary>Hours of play the buff lasts.</summary>
        public double Hours;
        public double XpBonus;
    }

    public enum RegularStatus { Stranger, Guest, Regular, Family }

    public static class InnStay
    {
        static readonly Regex RestPattern = new Regex(@"^(Well Rested|Rested)\s*\((\d+(?:\.\d+)?)h\)(.*)$", RegexOptions.IgnoreCase);

        /// <summary>
        /// Rest buffs from one night (inns.md §2). The room gives Rested or Well Rested; a meal and a bath each add
        /// +1 hour of Well Rested (a suite's included meal counts as the meal). Well Rested plays first, then Rested.
        /// </summary>
        public static List<RestBuff> Rest(InnRoom room, bool hadMeal, bool hadBath, InnTuning t)
        {
            if (room == null) throw new ArgumentNullException(nameof(room));
            if (t == null) throw new ArgumentNullException(nameof(t));
            var m = RestPattern.Match(room.Rest ?? "");
            if (!m.Success) throw new FormatException($"Unrecognized rest \"{room.Rest}\"");
            var baseKind = m.Groups[1].Value.StartsWith("Well", StringComparison.OrdinalIgnoreCase) ? RestKind.WellRested : RestKind.Rested;
            double baseHours = double.Parse(m.Groups[2].Value, System.Globalization.CultureInfo.InvariantCulture);
            bool includesMeal = m.Groups[3].Value.IndexOf("meal", StringComparison.OrdinalIgnoreCase) >= 0;

            double extraWell = ((hadMeal || includesMeal) ? t.MealBonusHours : 0) + (hadBath ? t.BathBonusHours : 0);
            var buffs = new List<RestBuff>();
            double well = (baseKind == RestKind.WellRested ? baseHours : 0) + extraWell;
            if (well > 0) buffs.Add(new RestBuff { Kind = RestKind.WellRested, Hours = well, XpBonus = t.WellRestedXpBonus });
            if (baseKind == RestKind.Rested) buffs.Add(new RestBuff { Kind = RestKind.Rested, Hours = baseHours, XpBonus = t.RestedXpBonus });
            return buffs;
        }

        /// <summary>Adds a new night's buffs to existing ones: same kinds stack their hours, and Well Rested stays first.</summary>
        public static List<RestBuff> Stack(IEnumerable<RestBuff> current, IEnumerable<RestBuff> added)
        {
            return (current ?? Enumerable.Empty<RestBuff>()).Concat(added ?? Enumerable.Empty<RestBuff>())
                .GroupBy(b => b.Kind)
                .Select(g => new RestBuff { Kind = g.Key, Hours = g.Sum(b => b.Hours), XpBonus = g.First().XpBonus })
                .OrderBy(b => b.Kind == RestKind.WellRested ? 0 : 1)
                .ToList();
        }

        /// <summary>Regular status at one inn (inns.md §3).</summary>
        public static RegularStatus Status(int nights, bool didFavor, bool keeperQuestDone, RegularTuning t)
        {
            if (t == null) throw new ArgumentNullException(nameof(t));
            if (nights >= t.FamilyNights && didFavor && keeperQuestDone) return RegularStatus.Family;
            if (nights >= t.RegularNights && didFavor) return RegularStatus.Regular;
            if (nights >= t.GuestNights) return RegularStatus.Guest;
            return RegularStatus.Stranger;
        }
    }

    /// <summary>
    /// Marta's tab (inns.md §4): eat and sleep on credit. Available at the Sleeping Griffon at F–E rank, and at any inn
    /// where you're a Regular. The limit only changes Marta's letters; the tab never blocks the player.
    /// </summary>
    public sealed class InnTab
    {
        public const string SleepingGriffon = "inn_sleeping_griffon";
        readonly TabTuning _t;
        public int BalanceCopper { get; private set; }
        public int CreditLimitCopper => _t.CreditLimitCopper;
        public bool OverLimit => BalanceCopper > _t.CreditLimitCopper;
        public bool PaidOffOnce { get; private set; }

        public InnTab(TabTuning tuning) { _t = tuning ?? throw new ArgumentNullException(nameof(tuning)); }

        public bool AvailableAt(string innId, RankLetter rank, RegularStatus status) =>
            (innId == SleepingGriffon && _t.Ranks.Contains(rank.ToString())) || status >= RegularStatus.Regular;

        /// <summary>Adds to the tab. Always succeeds: the tab never blocks anything.</summary>
        public bool Charge(int copper) { BalanceCopper += Math.Max(0, copper); return true; }

        /// <summary>Pays down the tab (coins or Rush Hour work). Returns the change if overpaid.</summary>
        public int Pay(int copper)
        {
            copper = Math.Max(0, copper);
            int paid = Math.Min(copper, BalanceCopper);
            BalanceCopper -= paid;
            if (BalanceCopper == 0 && paid > 0) PaidOffOnce = true;
            return copper - paid;
        }
    }
}
