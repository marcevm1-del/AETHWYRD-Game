using System.Collections.Generic;

namespace Ascend.Core
{
    /// <summary>Mirror of Data/World/world_tuning.json.</summary>
    public sealed class WorldTuning
    {
        public int Version { get; set; }
        public CurrencyTuning Currency { get; set; } = new CurrencyTuning();
        public CalendarTuning Calendar { get; set; } = new CalendarTuning();
        public SiegeTuning Siege { get; set; } = new SiegeTuning();
        public InnTuning Inns { get; set; } = new InnTuning();
        public TamingTuning Taming { get; set; } = new TamingTuning();
    }

    public sealed class CurrencyTuning
    {
        public string BaseUnit { get; set; } = "copper";
        public List<string> DisplayOrder { get; set; } = new List<string>();
        public List<CurrencyDenomination> Denominations { get; set; } = new List<CurrencyDenomination>();
        public int ConversionRate { get; set; } = 100;
        public bool AutoMakeChange { get; set; } = true;
    }

    public sealed class CurrencyDenomination
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public long ValueCopper { get; set; }
    }

    public sealed class CalendarTuning
    {
        public double DayLengthRealMinutes { get; set; } = 90;
        public int HoursPerDay { get; set; } = 24;
        public List<string> Weekdays { get; set; } = new List<string>();
        public int DawnHour { get; set; } = 6;
        /// <summary>Part name → [startHour, endHour). "night" wraps past midnight.</summary>
        public Dictionary<string, List<double>> DayParts { get; set; } = new Dictionary<string, List<double>>();
    }

    public sealed class SiegeTuning
    {
        public int MinAttacksPerWeek { get; set; } = 1;
        public int MaxAttacksPerWeek { get; set; } = 2;
        public double SecondAttackChance { get; set; } = 0.5;
        public double DuskChance { get; set; } = 0.8;
        public double DuskHour { get; set; } = 18;
        public double NightHour { get; set; } = 21;
        public int AnnounceDaysAhead { get; set; } = 1;
        public int EscalationPerWeek { get; set; } = 1;
        public int MaxEscalation { get; set; } = 5;
        public int WeakenedEscalationReduction { get; set; } = 2;
        public AutoResolveTuning AutoResolve { get; set; } = new AutoResolveTuning();
    }

    public sealed class AutoResolveTuning
    {
        public double BaseThreat { get; set; }
        public double EscalationThreat { get; set; }
        public double SafetyWeight { get; set; }
        public double GuardWeight { get; set; }
        public double AdventurerWeight { get; set; }
        public double BarricadeWeight { get; set; }
        public double Variance { get; set; }
        public double RepelMargin { get; set; }
        public double CostlyMargin { get; set; }
        public int MaxWealthLoss { get; set; }
        public int MaxSafetyLoss { get; set; }
        public int MaxBuildingsDamaged { get; set; }
        public int ProsperityFloor { get; set; }
    }

    public sealed class InnTuning
    {
        public double RestedXpBonus { get; set; }
        public double WellRestedXpBonus { get; set; }
        public double MealBonusHours { get; set; }
        public double BathBonusHours { get; set; }
        public RegularTuning Regular { get; set; } = new RegularTuning();
        public TabTuning Tab { get; set; } = new TabTuning();
    }

    public sealed class RegularTuning { public int GuestNights { get; set; } = 3; public int RegularNights { get; set; } = 10; public int FamilyNights { get; set; } = 30; }
    public sealed class TabTuning { public int CreditLimitCopper { get; set; } = 600; public List<string> Ranks { get; set; } = new List<string>(); }
}
