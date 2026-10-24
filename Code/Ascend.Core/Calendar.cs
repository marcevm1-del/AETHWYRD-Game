using System;
using System.Collections.Generic;
using System.Linq;

namespace Ascend.Core
{
    public enum DayPart { Morning, Day, Dusk, Night }

    /// <summary>
    /// The Aetherian calendar (Canon §2): 7-day weeks (Solenday … Vexday), a 90-real-minute day by default.
    /// Day 0 is a Solenday. Pure math: callers pass the clock in.
    /// </summary>
    public sealed class GameCalendar
    {
        readonly CalendarTuning _t;
        readonly (DayPart part, double start, double end)[] _parts;

        public GameCalendar(CalendarTuning tuning)
        {
            _t = tuning ?? throw new ArgumentNullException(nameof(tuning));
            if (_t.Weekdays == null || _t.Weekdays.Count != 7) throw new ArgumentException("calendar needs 7 weekdays");
            _parts = _t.DayParts.Select(kv => (Parse(kv.Key), kv.Value[0], kv.Value[1])).ToArray();
        }

        public int DaysPerWeek => _t.Weekdays.Count;
        public IReadOnlyList<string> Weekdays => _t.Weekdays;

        public int WeekdayIndex(int day) => ((day % DaysPerWeek) + DaysPerWeek) % DaysPerWeek;
        public string Weekday(int day) => _t.Weekdays[WeekdayIndex(day)];
        public int Week(int day) => (int)Math.Floor((double)day / DaysPerWeek);

        /// <summary>In-game day number and hour from real seconds of play (the clock only runs while you play).</summary>
        public (int day, double hour) FromPlaySeconds(double playSeconds)
        {
            double days = Math.Max(0, playSeconds) / (_t.DayLengthRealMinutes * 60.0);
            int day = (int)Math.Floor(days);
            return (day, (days - day) * _t.HoursPerDay);
        }

        /// <summary>Play seconds that one in-game hour takes.</summary>
        public double SecondsPerHour => _t.DayLengthRealMinutes * 60.0 / _t.HoursPerDay;
        public int HoursPerDay => _t.HoursPerDay;
        public double DawnHour => _t.DawnHour;

        /// <summary>Hours from <paramref name="hour"/> to the next dawn (a night's sleep). Sleeping after midnight wakes at dawn the same day.</summary>
        public double HoursUntilDawn(double hour)
        {
            double h = ((hour % _t.HoursPerDay) + _t.HoursPerDay) % _t.HoursPerDay;
            double until = _t.DawnHour - h;
            return until > 0 ? until : until + _t.HoursPerDay;
        }

        public DayPart PartOf(double hour)
        {
            hour = ((hour % _t.HoursPerDay) + _t.HoursPerDay) % _t.HoursPerDay;
            foreach (var (part, start, end) in _parts)
            {
                bool inside = start <= end ? hour >= start && hour < end : hour >= start || hour < end; // night wraps midnight
                if (inside) return part;
            }
            return DayPart.Night;
        }

        public static DayPart Parse(string s)
        {
            switch (s) { case "morning": return DayPart.Morning; case "day": return DayPart.Day; case "dusk": return DayPart.Dusk; default: return DayPart.Night; }
        }
    }
}
