using System;
using System.Collections.Generic;
using System.Linq;

namespace Ascend.Core
{
    // Upgrade v4 (Canon-safe subset): optional NPC schedules, a calendar-driven event director for caravans and small
    // wandering encounters, and a discovery journal in the Unknown / Heard / Visited style. Docs: 12_Systems/living_world.md.
    // Everything runs on in-game days only. Nothing here changes a settlement, an owner, a faction or an economy, and
    // nothing gates essential access.

    // ------------------------------------------------------------------ data (Data/World/living_world.json)

    public sealed class LivingScheduleTuning
    {
        public bool DefaultEnabled { get; set; } = true;
        /// <summary>NPC tiers that are always Available (awake and at their post), whatever the schedule says.</summary>
        public List<string> EssentialTiers { get; set; } = new List<string>();
    }

    public sealed class LivingEventEffect
    {
        /// <summary>shop_stock, rumour, small_encounter or board_note: the only things an event may do.</summary>
        public string Kind { get; set; }
        public string Text { get; set; }
        public string ShopId { get; set; }
        public List<string> ItemIds { get; set; } = new List<string>();
        public List<string> SpeciesIds { get; set; } = new List<string>();
    }

    public sealed class LivingEventDef
    {
        public string Id { get; set; }
        /// <summary>caravan or wanderer.</summary>
        public string Kind { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public List<string> Regions { get; set; } = new List<string>();
        /// <summary>Weekday names; empty means any day.</summary>
        public List<string> Weekdays { get; set; } = new List<string>();
        public double ChancePerDay { get; set; }
        public int CooldownDays { get; set; }
        public int DurationDays { get; set; }
        public List<LivingEventEffect> Effects { get; set; } = new List<LivingEventEffect>();
    }

    public sealed class LivingEventTuning
    {
        public int MaxActive { get; set; } = 2;
        public int MaxActivePerRegion { get; set; } = 1;
        /// <summary>Days of events rolled at most when time jumps (sleeping, loading): no storm after a long gap.</summary>
        public int CatchUpDays { get; set; } = 7;
        public List<LivingEventDef> Pool { get; set; } = new List<LivingEventDef>();
    }

    public sealed class JournalCategory { public string Id { get; set; } public string Name { get; set; } }

    public sealed class LivingWorldData
    {
        public int Version { get; set; }
        public LivingScheduleTuning Schedules { get; set; } = new LivingScheduleTuning();
        public LivingEventTuning Events { get; set; } = new LivingEventTuning();
        public List<JournalCategory> JournalCategories { get; set; } = new List<JournalCategory>();
    }

    // ------------------------------------------------------------------ 1. NPC schedules

    public enum PlacementSource { Schedule, Home, Settlement }

    public sealed class NpcPlacement
    {
        public string NpcId { get; set; }
        /// <summary>Where they are (a schedule place, their home post, or just their settlement).</summary>
        public string Place { get; set; }
        public string Settlement { get; set; }
        public PlacementSource Source { get; set; }
        /// <summary>Awake and ready to talk. False for ordinary townsfolk at night; they are at their lodging and talk in the morning.</summary>
        public bool Available { get; set; }
        /// <summary>Always true: a schedule never locks anyone away. The player can always find the NPC in their settlement.</summary>
        public bool Reachable => true;
    }

    public static class NpcScheduleResolver
    {
        /// <summary>
        /// Where an NPC is at a given in-game day and hour. Schedules are optional: with them off, or for an NPC with no matching
        /// entry, the NPC stands at their home post (the first "day" entry, else the settlement). Essential tiers are always Available.
        /// </summary>
        public static NpcPlacement Resolve(NpcData npc, GameCalendar calendar, LivingScheduleTuning tuning, int day, double hour, bool schedulesEnabled = true)
        {
            if (npc == null) throw new ArgumentNullException(nameof(npc));
            if (calendar == null) throw new ArgumentNullException(nameof(calendar));
            tuning ??= new LivingScheduleTuning();
            var part = calendar.PartOf(hour);
            string weekday = calendar.Weekday(day);
            bool essential = tuning.EssentialTiers != null && tuning.EssentialTiers.Contains(npc.Tier);
            string home = npc.Schedule?.FirstOrDefault(s => s.Part == "day")?.Place;

            string place = null;
            var source = PlacementSource.Settlement;
            if (schedulesEnabled)
            {
                place = npc.WhereAt(part.ToString().ToLowerInvariant(), weekday);
                if (place != null) source = PlacementSource.Schedule;
            }
            if (place == null && home != null) { place = home; source = PlacementSource.Home; }
            if (place == null) { place = npc.Settlement; source = PlacementSource.Settlement; }

            bool restsNow = part == DayPart.Night && !essential;
            return new NpcPlacement { NpcId = npc.Id, Place = place, Settlement = npc.Settlement, Source = source, Available = !restsNow };
        }
    }

    // ------------------------------------------------------------------ 2. event director

    public sealed class ActiveLivingEvent
    {
        public string EventId { get; set; }
        public string RegionId { get; set; }
        public int StartDay { get; set; }
        /// <summary>The last in-game day it is present (inclusive).</summary>
        public int EndDay { get; set; }
    }

    /// <summary>SaveGame.LivingWorld.Events. Null in older saves; Upgrade fills it.</summary>
    public sealed class EventDirectorSave
    {
        /// <summary>The last in-game day the director rolled; -1 means never.</summary>
        public int LastRolledDay { get; set; } = -1;
        public Dictionary<string, int> LastStartDay { get; set; } = new Dictionary<string, int>();
        public List<ActiveLivingEvent> Active { get; set; } = new List<ActiveLivingEvent>();
    }

    public sealed class EventDirector
    {
        readonly LivingEventTuning _t;
        readonly GameCalendar _cal;
        readonly ulong _seed;

        public EventDirector(LivingEventTuning tuning, GameCalendar calendar, ulong worldSeed)
        {
            _t = tuning ?? throw new ArgumentNullException(nameof(tuning));
            _cal = calendar ?? throw new ArgumentNullException(nameof(calendar));
            _seed = worldSeed;
        }

        /// <summary>Events present on a day (started on or before it, not yet ended).</summary>
        public static List<ActiveLivingEvent> PresentOn(EventDirectorSave state, int day) =>
            state.Active.Where(a => a.StartDay <= day && day <= a.EndDay).ToList();

        /// <summary>
        /// Rolls every in-game day after <c>LastRolledDay</c> up to <paramref name="today"/> (at most CatchUpDays of them), expiring finished
        /// events first. Deterministic for a world seed, day and event. <paramref name="regionAllows"/> says whether a region may host
        /// an event today (false while besieged); null allows all. Returns the events that started.
        /// </summary>
        public List<ActiveLivingEvent> Advance(EventDirectorSave state, int today, Func<string, bool> regionAllows = null)
        {
            if (state == null) throw new ArgumentNullException(nameof(state));
            state.Active ??= new List<ActiveLivingEvent>();
            state.LastStartDay ??= new Dictionary<string, int>();
            var started = new List<ActiveLivingEvent>();
            if (today <= state.LastRolledDay) return started; // never re-roll a day, never go back

            int from = Math.Max(state.LastRolledDay + 1, today - _t.CatchUpDays + 1);
            if (state.LastRolledDay < 0) from = today; // a fresh save starts quietly on its first day
            for (int day = from; day <= today; day++)
            {
                state.Active.RemoveAll(a => a.EndDay < day);
                var weekday = _cal.Weekday(day);
                // The pool order must not decide who wins the few slots: start each day at a different, seeded place in the pool.
                int offset = _t.Pool.Count == 0 ? 0 : DeterministicRandom.For(_seed, "living_order", day).Next(0, _t.Pool.Count);
                for (int k = 0; k < _t.Pool.Count; k++)
                {
                    var ev = _t.Pool[(k + offset) % _t.Pool.Count];
                    if (ev.Regions == null || ev.Regions.Count == 0) continue;
                    if (ev.Weekdays != null && ev.Weekdays.Count > 0 && !ev.Weekdays.Contains(weekday)) continue;
                    if (state.LastStartDay.TryGetValue(ev.Id, out var last) && day - last < ev.CooldownDays) continue;
                    if (state.Active.Any(a => a.EventId == ev.Id)) continue;
                    if (state.Active.Count >= _t.MaxActive) break;
                    var rng = DeterministicRandom.For(_seed, "living_event", ev.Id, day);
                    var region = ev.Regions[rng.Next(0, ev.Regions.Count)];
                    double roll = rng.NextDouble();
                    if (roll >= ev.ChancePerDay) continue;
                    if (state.Active.Count(a => a.RegionId == region) >= _t.MaxActivePerRegion) continue;
                    if (regionAllows != null && !regionAllows(region)) continue;
                    var a2 = new ActiveLivingEvent { EventId = ev.Id, RegionId = region, StartDay = day, EndDay = day + Math.Max(1, ev.DurationDays) - 1 };
                    state.Active.Add(a2);
                    state.LastStartDay[ev.Id] = day;
                    started.Add(a2);
                }
            }
            state.LastRolledDay = today;
            state.Active.RemoveAll(a => a.EndDay < today);
            return started;
        }
    }

    // ------------------------------------------------------------------ 3. discovery journal

    /// <summary>SaveGame.LivingWorld.Journal: entry id ("category:id") to what the player knows.</summary>
    public sealed class DiscoveryJournalSave
    {
        public Dictionary<string, MapStatus> Entries { get; set; } = new Dictionary<string, MapStatus>();
    }

    public sealed class DiscoveryJournal
    {
        readonly HashSet<string> _categories;
        readonly DiscoveryJournalSave _save;

        public DiscoveryJournal(IEnumerable<JournalCategory> categories, DiscoveryJournalSave save = null)
        {
            _categories = new HashSet<string>((categories ?? Enumerable.Empty<JournalCategory>()).Select(c => c.Id));
            _save = save ?? new DiscoveryJournalSave();
            _save.Entries ??= new Dictionary<string, MapStatus>();
        }

        public static string Key(string category, string id) => category + ":" + id;
        bool Valid(string category, string id) => !string.IsNullOrEmpty(id) && category != null && _categories.Contains(category);

        public MapStatus StatusOf(string category, string id) => Valid(category, id) && _save.Entries.TryGetValue(Key(category, id), out var s) ? s : MapStatus.Unknown;

        /// <summary>A rumour pencils an entry in; returns true if it was blank before. Never downgrades a visit.</summary>
        public bool Hear(string category, string id)
        {
            if (!Valid(category, id) || StatusOf(category, id) != MapStatus.Unknown) return false;
            _save.Entries[Key(category, id)] = MapStatus.Heard;
            return true;
        }

        /// <summary>Finding it in place inks the entry; returns true if it was not inked before.</summary>
        public bool Visit(string category, string id)
        {
            if (!Valid(category, id) || StatusOf(category, id) == MapStatus.Visited) return false;
            _save.Entries[Key(category, id)] = MapStatus.Visited;
            return true;
        }

        public int Count(string category, MapStatus status) =>
            _save.Entries.Count(kv => kv.Value == status && kv.Key.StartsWith(category + ":", StringComparison.Ordinal));

        public DiscoveryJournalSave ToSave() => _save;
    }

    /// <summary>SaveGame.LivingWorld. Null in older saves; SaveRules.Upgrade fills it with an empty journal and a fresh director.</summary>
    public sealed class LivingWorldSave
    {
        public EventDirectorSave Events { get; set; } = new EventDirectorSave();
        public DiscoveryJournalSave Journal { get; set; } = new DiscoveryJournalSave();
    }
}
