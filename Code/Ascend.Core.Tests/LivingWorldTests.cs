using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Ascend.Core;

// Upgrade v4 subset: optional NPC schedules, the calendar-driven event director, the discovery journal.
// Canon: in-game time only, nothing gates essential access, no settlement or ownership changes, Unknown / Heard / Visited.
[Tests]
static class LivingWorldTests
{
    static readonly JsonSerializerOptions Opts = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    static LivingWorldData Lw => _lw ??= Repo.Load<LivingWorldData>("Data/World/living_world.json");
    static LivingWorldData _lw;
    static GameCalendar Cal => new GameCalendar(Repo.Db.World.Calendar);
    static EventDirector Director(ulong seed = 42) => new EventDirector(Lw.Events, Cal, seed);

    // ---- data ----
    public static void DataLoadsWithTheSafeShape()
    {
        Assert.True(Lw.Events.Pool.Count >= 5, "a small pool");
        Assert.True(Lw.Events.Pool.All(e => e.Kind == "caravan" || e.Kind == "wanderer"), "only caravans and wanderers");
        var kinds = Lw.Events.Pool.SelectMany(e => e.Effects).Select(x => x.Kind).Distinct().ToList();
        Assert.True(kinds.All(k => k == "shop_stock" || k == "rumour" || k == "small_encounter" || k == "board_note"), "only the four safe effect kinds: " + string.Join(",", kinds));
        Assert.True(Lw.Events.Pool.All(e => e.CooldownDays >= e.DurationDays), "an event never overlaps itself");
        Assert.Equal("creature,landmark,region,secret", string.Join(",", Lw.JournalCategories.Select(c => c.Id).OrderBy(x => x)), "journal categories");
    }

    // ---- 1. schedules ----
    static NpcData WithSchedule(string tier, bool days = false) => new NpcData
    {
        Id = "npc_test", Tier = tier, Settlement = "Brindlewick",
        Schedule = new List<NpcScheduleEntry>
        {
            new NpcScheduleEntry { Part = "morning", Place = "Bakery" },
            new NpcScheduleEntry { Part = "day", Place = "Counter", Days = days ? new List<string> { "Solenday" } : null },
            new NpcScheduleEntry { Part = "dusk", Place = "Tavern" },
        }
    };

    public static void ScheduleResolvesByDayPart()
    {
        var n = WithSchedule("townsfolk");
        Assert.Equal("Bakery", NpcScheduleResolver.Resolve(n, Cal, Lw.Schedules, 0, 7).Place, "morning");
        Assert.Equal("Counter", NpcScheduleResolver.Resolve(n, Cal, Lw.Schedules, 0, 12).Place, "day");
        var dusk = NpcScheduleResolver.Resolve(n, Cal, Lw.Schedules, 0, 18);
        Assert.Equal("Tavern", dusk.Place, "dusk");
        Assert.Equal(PlacementSource.Schedule, dusk.Source, "from the schedule");
    }

    public static void ScheduleHonoursWeekdays()
    {
        var n = WithSchedule("townsfolk", days: true);
        Assert.Equal("Counter", NpcScheduleResolver.Resolve(n, Cal, Lw.Schedules, 0, 12).Place, "Solenday is day 0");
        var other = NpcScheduleResolver.Resolve(n, Cal, Lw.Schedules, 1, 12);
        Assert.Equal(PlacementSource.Home, other.Source, "no entry on Maelsday: falls back to the home post");
        Assert.Equal("Counter", other.Place, "home post is the day entry");
    }

    public static void SchedulesAreOptional()
    {
        var n = WithSchedule("townsfolk");
        var off = NpcScheduleResolver.Resolve(n, Cal, Lw.Schedules, 0, 7, schedulesEnabled: false);
        Assert.Equal("Counter", off.Place, "with schedules off the NPC stands at the home post");
        Assert.Equal(PlacementSource.Home, off.Source, "home");
        var bare = NpcScheduleResolver.Resolve(new NpcData { Id = "npc_x", Tier = "townsfolk", Settlement = "Millbrook" }, Cal, Lw.Schedules, 0, 7);
        Assert.Equal("Millbrook", bare.Place, "no schedule at all: the settlement");
        Assert.Equal(PlacementSource.Settlement, bare.Source, "settlement");
    }

    public static void NoScheduleEverBlocksAccess()
    {
        foreach (var npc in Repo.Db.Npcs.Values)
            for (int day = 0; day < 7; day++)
                for (double hour = 0; hour < 24; hour += 1)
                {
                    var p = NpcScheduleResolver.Resolve(npc, Cal, Lw.Schedules, day, hour);
                    Assert.True(p.Reachable, npc.Id + " must always be reachable");
                    Assert.True(!string.IsNullOrEmpty(p.Place), npc.Id + " always has a place to look");
                    if (Lw.Schedules.EssentialTiers.Contains(npc.Tier)) Assert.True(p.Available, npc.Id + " is essential: always available");
                }
    }

    public static void OrdinaryTownsfolkRestAtNightButEssentialsDoNot()
    {
        Assert.True(!NpcScheduleResolver.Resolve(WithSchedule("townsfolk"), Cal, Lw.Schedules, 0, 22).Available, "townsfolk rest at night");
        Assert.True(NpcScheduleResolver.Resolve(WithSchedule("core"), Cal, Lw.Schedules, 0, 22).Available, "a core NPC is always available");
        Assert.True(NpcScheduleResolver.Resolve(WithSchedule("townsfolk"), Cal, Lw.Schedules, 0, 12).Available, "and awake by day");
    }

    // ---- 2. event director ----
    public static void DirectorIsDeterministic()
    {
        var a = new EventDirectorSave(); var b = new EventDirectorSave();
        var sa = Director().Advance(a, 60); var sb = Director().Advance(b, 60);
        Assert.Equal(string.Join(",", sa.Select(x => x.EventId + x.StartDay)), string.Join(",", sb.Select(x => x.EventId + x.StartDay)), "same seed, same events");
        Assert.True(Enumerable.Range(1, 40).Any(s =>
        {
            var c = new EventDirectorSave(); var d = new EventDirectorSave();
            Director((ulong)s).Advance(c, 200); Director((ulong)s + 1000).Advance(d, 200);
            return string.Join(",", c.LastStartDay) != string.Join(",", d.LastStartDay);
        }), "different seeds differ");
    }

    public static void DirectorRollsEachDayOnceAndNeverBackwards()
    {
        var s = new EventDirectorSave();
        var d = Director();
        d.Advance(s, 10);
        Assert.Equal(10, s.LastRolledDay, "rolled to day 10");
        var snapshot = JsonSerializer.Serialize(s);
        Assert.Equal(0, d.Advance(s, 10).Count, "the same day again does nothing");
        Assert.Equal(0, d.Advance(s, 4).Count, "an earlier day does nothing");
        Assert.Equal(snapshot, JsonSerializer.Serialize(s), "state untouched");
    }

    public static void DirectorRespectsCooldownsAndLimits()
    {
        var s = new EventDirectorSave();
        var d = Director();
        var started = new List<ActiveLivingEvent>();
        for (int day = 0; day <= 400; day++)
        {
            started.AddRange(d.Advance(s, day));
            var present = EventDirector.PresentOn(s, day);
            Assert.True(present.Count <= Lw.Events.MaxActive, $"day {day}: at most {Lw.Events.MaxActive} active");
            foreach (var g in present.GroupBy(a => a.RegionId)) Assert.True(g.Count() <= Lw.Events.MaxActivePerRegion, $"day {day}: one per region");
        }
        Assert.True(started.Count > 10, "events do happen over a long play: " + started.Count);
        foreach (var def in Lw.Events.Pool) Assert.True(started.Any(a => a.EventId == def.Id), def.Id + " is not starved by pool order");
        foreach (var g in started.GroupBy(a => a.EventId))
        {
            var def = Lw.Events.Pool.First(e => e.Id == g.Key);
            var days = g.Select(a => a.StartDay).OrderBy(x => x).ToList();
            for (int i = 1; i < days.Count; i++) Assert.True(days[i] - days[i - 1] >= def.CooldownDays, $"{g.Key} respects its {def.CooldownDays}-day cooldown");
        }
    }

    public static void EventsEndAndKeepToTheirRegionsAndWeekdays()
    {
        var s = new EventDirectorSave();
        var d = Director(7);
        var cal = Cal;
        for (int day = 0; day <= 200; day++)
            foreach (var a in d.Advance(s, day))
            {
                var def = Lw.Events.Pool.First(e => e.Id == a.EventId);
                Assert.True(def.Regions.Contains(a.RegionId), "a listed region");
                if (def.Weekdays.Count > 0) Assert.True(def.Weekdays.Contains(cal.Weekday(a.StartDay)), "starts on a listed weekday");
                Assert.Equal(a.StartDay + def.DurationDays - 1, a.EndDay, "lasts its duration, in game days");
            }
        Assert.True(s.Active.All(a => a.EndDay >= 200), "finished events are gone");
    }

    public static void BesiegedRegionsHostNoEvents()
    {
        var s = new EventDirectorSave();
        var all = Lw.Events.Pool.SelectMany(e => e.Regions).Distinct().ToList();
        var started = new List<ActiveLivingEvent>();
        for (int day = 0; day <= 300; day++) started.AddRange(Director().Advance(s, day, region => region != "reg_whisperwood"));
        Assert.True(started.Count > 0, "events still happen elsewhere");
        Assert.True(started.All(a => a.RegionId != "reg_whisperwood"), "none in the besieged region");
        Assert.True(all.Contains("reg_whisperwood"), "(the region is in the pool, so the filter mattered)");
    }

    public static void LongGapsDoNotCauseAnEventStorm()
    {
        var s = new EventDirectorSave { LastRolledDay = 0 };
        var started = Director().Advance(s, 5000);
        Assert.True(started.Count <= Lw.Events.CatchUpDays * Lw.Events.MaxActive, "a jump of thousands of days rolls only the last " + Lw.Events.CatchUpDays + ": " + started.Count);
        Assert.Equal(5000, s.LastRolledDay, "caught up");
        Assert.True(started.All(a => a.StartDay > 5000 - Lw.Events.CatchUpDays), "only recent days");
    }

    public static void AFreshSaveRollsOnlyItsFirstDay()
    {
        var s = new EventDirectorSave();
        Director().Advance(s, 300);
        Assert.Equal(300, s.LastRolledDay, "rolled today");
        Assert.True(s.LastStartDay.Values.All(d => d == 300), "only day 300 was rolled");
    }

    public static void NoRealTimeInTheDirector()
    {
        // The director takes in-game days only: the same save and day give the same answer whenever it is called.
        var a = new EventDirectorSave { LastRolledDay = 20 }; var b = new EventDirectorSave { LastRolledDay = 20 };
        Director().Advance(a, 40);
        System.Threading.Thread.Sleep(5);
        Director().Advance(b, 40);
        Assert.Equal(JsonSerializer.Serialize(a), JsonSerializer.Serialize(b), "no clock involved");
    }

    // ---- 3. discovery journal ----
    public static void JournalUsesUnknownHeardVisited()
    {
        var j = new DiscoveryJournal(Lw.JournalCategories);
        Assert.Equal(MapStatus.Unknown, j.StatusOf("region", "reg_greymoor"), "blank");
        Assert.True(j.Hear("region", "reg_greymoor"), "a rumour pencils it");
        Assert.Equal(MapStatus.Heard, j.StatusOf("region", "reg_greymoor"), "heard");
        Assert.True(!j.Hear("region", "reg_greymoor"), "hearing twice changes nothing");
        Assert.True(j.Visit("region", "reg_greymoor"), "finding it in place inks it");
        Assert.Equal(MapStatus.Visited, j.StatusOf("region", "reg_greymoor"), "visited");
    }

    public static void HearingNeverDowngradesAVisit()
    {
        var j = new DiscoveryJournal(Lw.JournalCategories);
        j.Visit("landmark", "lm_old_bridge");
        Assert.True(!j.Hear("landmark", "lm_old_bridge"), "no downgrade");
        Assert.Equal(MapStatus.Visited, j.StatusOf("landmark", "lm_old_bridge"), "still visited");
        Assert.True(!j.Visit("landmark", "lm_old_bridge"), "inking twice is a no-op");
    }

    public static void JournalRejectsUnknownCategoriesAndEmptyIds()
    {
        var j = new DiscoveryJournal(Lw.JournalCategories);
        Assert.True(!j.Hear("faction_standing", "x"), "no such category");
        Assert.True(!j.Visit("region", ""), "empty id");
        Assert.True(!j.Visit("region", null), "null id");
        Assert.Equal(0, j.ToSave().Entries.Count, "nothing recorded");
    }

    public static void JournalCountsPerCategoryAndRoundTrips()
    {
        var j = new DiscoveryJournal(Lw.JournalCategories);
        j.Visit("creature", "mon_wild_boar"); j.Hear("creature", "mon_jackalope"); j.Visit("region", "reg_aldmere");
        Assert.Equal(1, j.Count("creature", MapStatus.Visited), "one creature seen");
        Assert.Equal(1, j.Count("creature", MapStatus.Heard), "one creature heard of");
        Assert.Equal(1, j.Count("region", MapStatus.Visited), "regions counted apart");
        var json = JsonSerializer.Serialize(j.ToSave());
        var back = new DiscoveryJournal(Lw.JournalCategories, JsonSerializer.Deserialize<DiscoveryJournalSave>(json, Opts));
        Assert.Equal(MapStatus.Heard, back.StatusOf("creature", "mon_jackalope"), "survives a save");
        Assert.Equal(MapStatus.Visited, back.StatusOf("creature", "mon_wild_boar"), "survives a save");
    }

    // ---- save ----
    public static void OldSavesLoadWithoutLivingWorld()
    {
        // A save written before this field existed has no "livingWorld" key at all.
        var old = JsonSerializer.Deserialize<SaveGame>("{\"version\":1,\"level\":12,\"copper\":340,\"flags\":[\"arrived_in_aetheria\"]}", Opts);
        Assert.True(old.LivingWorld == null, "absent in the old JSON");
        var up = SaveRules.Upgrade(old);
        Assert.True(up.LivingWorld != null && up.LivingWorld.Events != null && up.LivingWorld.Journal != null, "Upgrade fills it");
        Assert.Equal(-1, up.LivingWorld.Events.LastRolledDay, "a fresh director");
        Assert.Equal(0, up.LivingWorld.Journal.Entries.Count, "an empty journal");
        Assert.Equal(12, up.Level, "the rest of the old save is untouched");
        Assert.Equal(0, SaveRules.Validate(up).Count, "and it validates");
    }

    public static void PartialLivingWorldSaveIsRepaired()
    {
        var s = SaveRules.Upgrade(new SaveGame { LivingWorld = new LivingWorldSave { Events = null, Journal = null } });
        Assert.True(s.LivingWorld.Events.Active != null && s.LivingWorld.Journal.Entries != null, "null parts are filled");
        var round = JsonSerializer.Deserialize<SaveGame>(JsonSerializer.Serialize(SaveRules.Upgrade(new SaveGame())), Opts);
        Assert.True(round.LivingWorld.Journal.Entries != null, "survives a round trip");
    }

    public static void NoEventEffectTouchesSettlementsOrOwners()
    {
        var text = string.Join(" ", Lw.Events.Pool.SelectMany(e => new[] { e.Name, e.Text }.Concat(e.Effects.Select(x => x.Text))));
        foreach (var banned in new[] { "siege", "war ", "destroy", "conquer", "owner", "succession" })
            Assert.True(!text.ToLowerInvariant().Contains(banned), "event text must not mention '" + banned + "'");
        Assert.True(Lw.Events.Pool.SelectMany(e => e.Effects).Where(x => x.Kind == "small_encounter")
            .SelectMany(x => x.SpeciesIds).All(id => !Repo.Db.Species[id].IsUnique && !Repo.Db.Species[id].IsTyrant), "ordinary species only");
    }
}
