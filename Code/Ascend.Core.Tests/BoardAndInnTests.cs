using Ascend.Core;

// Part C of the v0.11 session: calendar, weekly board and inns.
[Tests]
static class BoardAndInnTests
{
    static GameCalendar Cal => new(Repo.Db.World.Calendar);
    static WeeklyBoard Board(ulong seed = 1024) => new(Repo.Db.WeeklyQuests.Values, Cal, seed);
    static InnTuning Inn => Repo.Db.World.Inns;

    public static void CalendarWeekdaysAndParts()
    {
        var c = Cal;
        Assert.Equal("Solenday", c.Weekday(0), "day 0");
        Assert.Equal("Vexday", c.Weekday(6), "day 6");
        Assert.Equal("Solenday", c.Weekday(7), "week wraps");
        Assert.Equal(2, c.Week(14), "week number");
        Assert.Equal(DayPart.Morning, c.PartOf(7), "7:00");
        Assert.Equal(DayPart.Dusk, c.PartOf(18), "18:00 (siege dusk hour)");
        Assert.Equal(DayPart.Night, c.PartOf(21), "21:00 (siege night hour)");
        Assert.Equal(DayPart.Night, c.PartOf(2), "night wraps past midnight");
        var (day, hour) = c.FromPlaySeconds(90 * 60 * 3 + 45 * 60); // 3.5 in-game days at 90 min/day
        Assert.Equal(3, day, "day from play time");
        Assert.Near(12, hour, 1e-6, "noon");
    }

    public static void EveryWeekdayHasASpecialAndThreeDailies()
    {
        var b = Board();
        for (int day = 0; day < 7; day++)
        {
            foreach (var state in new[] { RegionState.Besieged, RegionState.Liberated })
            {
                var board = b.Build(day, "Brindlewick", state);
                Assert.True(board.Special != null && board.Special.Day == board.Weekday, $"{board.Weekday}: day special");
                Assert.Equal(3, board.Dailies.Count, $"{board.Weekday}: 3 dailies");
                Assert.Equal(3, board.Dailies.Select(q => q.Id).Distinct().Count(), "no duplicate dailies");
                Assert.True(board.Dailies.All(q => q.Day == board.Weekday || q.Day == "Any"), "dailies from the day's pool or Any");
                Assert.True(board.Weekly != null, "weekly commission posted");
            }
        }
    }

    public static void LiberationSwapsBesiegedFillerForHuntingContracts()
    {
        var b = Board();
        bool sawCullWhileBesieged = false, sawHuntAfter = false;
        for (int day = 0; day < 70; day++)
        {
            var besieged = b.Build(day, "Brindlewick", RegionState.Besieged);
            var liberated = b.Build(day, "Brindlewick", RegionState.Liberated);
            Assert.True(besieged.Posted.All(q => q.RegionState != "liberated"), "no liberated-only quests while besieged");
            Assert.True(liberated.Posted.All(q => q.RegionState != "besieged"), "no besieged-only quests after liberation");
            sawCullWhileBesieged |= besieged.Dailies.Any(q => q.Id == "qst_wk_any_goblin_cull");
            sawHuntAfter |= liberated.Dailies.Any(q => q.RegionState == "liberated");
        }
        Assert.True(sawCullWhileBesieged, "Goblin Cull shows up while besieged");
        Assert.True(sawHuntAfter, "hunting contracts show up after liberation");
    }

    public static void SiegeDefenceGoesOnTopOnAttackDays()
    {
        var region = Repo.Db.Regions["reg_whisperwood"];
        var sched = new SiegeScheduler(Repo.Db.World.Siege, 1024);
        var attack = sched.AttacksInWeek(region, 0)[0];
        var template = Repo.Db.Quests["qst_siege_whisperwood_defence"];
        var board = Board().Build(attack.Day, attack.Settlement, RegionState.Besieged, null, attack, template);
        Assert.True(board.Attack == attack && board.DefenceQuest == template, "defence posted on the attack day");
        Assert.True(board.Special != null && board.Dailies.Count == 3, "the rest of the board stays available");
        var after = Board().Build(attack.Day, attack.Settlement, RegionState.Liberated, null, attack, template);
        Assert.True(after.Attack == null && after.DefenceQuest == null, "no defence once liberated");
    }

    public static void DaySpecialOncePerWeek()
    {
        var b = Board();
        var done = new HashSet<string>();
        var first = b.Build(0, "Brindlewick", RegionState.Besieged, done);
        done.Add(first.Special.Id);
        done.Add(first.Weekly.Id);
        var again = b.Build(0, "Brindlewick", RegionState.Besieged, done); // reloaded the same day
        Assert.True(again.Special == null, "special can't repeat in the same week");
        Assert.True(again.Weekly == null, "weekly commission done for the week");
        var nextWeek = b.Build(7, "Brindlewick", RegionState.Besieged, new HashSet<string>());
        Assert.Equal(first.Special.Id, nextWeek.Special.Id, "it returns next week");
    }

    public static void BoardIsDeterministicAndVaries()
    {
        var a = Board(5).Build(3, "Brindlewick", RegionState.Besieged);
        var b = Board(5).Build(3, "Brindlewick", RegionState.Besieged);
        Assert.Equal(string.Join(",", a.Dailies.Select(q => q.Id)), string.Join(",", b.Dailies.Select(q => q.Id)), "same seed, same board");
        var boards = Enumerable.Range(0, 10).Select(w => string.Join(",", Board(5).Build(3 + 7 * w, "Brindlewick", RegionState.Besieged).Dailies.Select(q => q.Id).OrderBy(x => x))).Distinct().Count();
        Assert.True(boards >= 3, $"the same weekday varies across weeks (got {boards} distinct boards)");
    }

    public static void TimeOfDayFiltering()
    {
        Assert.True(WeeklyBoard.OpenAt("night", DayPart.Night) && !WeeklyBoard.OpenAt("night", DayPart.Dusk), "night quests open after dusk");
        Assert.True(WeeklyBoard.OpenAt("morning", DayPart.Morning) && !WeeklyBoard.OpenAt("morning", DayPart.Day), "morning quests close after the morning");
        Assert.True(WeeklyBoard.OpenAt("dusk", DayPart.Morning) && !WeeklyBoard.OpenAt("dusk", DayPart.Night), "dusk quests open until dusk ends");
        Assert.True(WeeklyBoard.OpenAt("any", DayPart.Night), "any is always open");
    }

    public static void RestBuffsStackCorrectly()
    {
        var griffon = Repo.Db.Inns["inn_sleeping_griffon"];
        var common = InnStay.Rest(griffon.Room("common"), hadMeal: true, hadBath: true, Inn);
        Assert.Equal(2, common.Count, "common room + meal + bath: two buffs");
        Assert.True(common[0].Kind == RestKind.WellRested && Math.Abs(common[0].Hours - 2) < 1e-9, "meal + bath = 2 h Well Rested, played first");
        Assert.True(common[1].Kind == RestKind.Rested && Math.Abs(common[1].Hours - 2) < 1e-9, "then 2 h Rested");

        var priv = InnStay.Rest(griffon.Room("private"), hadMeal: true, hadBath: false, Inn);
        Assert.True(priv.Count == 1 && Math.Abs(priv[0].Hours - 5) < 1e-9, "private room + meal = 5 h Well Rested");

        var suite = InnStay.Rest(griffon.Room("suite"), hadMeal: true, hadBath: true, Inn);
        Assert.True(Math.Abs(suite[0].Hours - 10) < 1e-9, "suite (meal included, no double count) + bath = 10 h");
        Assert.Near(Inn.WellRestedXpBonus, suite[0].XpBonus, 1e-9, "Well Rested XP bonus");

        var stacked = InnStay.Stack(common, priv);
        Assert.True(stacked[0].Kind == RestKind.WellRested && Math.Abs(stacked[0].Hours - 7) < 1e-9, "same kinds add up");
        Assert.True(stacked[1].Kind == RestKind.Rested && Math.Abs(stacked[1].Hours - 2) < 1e-9, "Rested kept after");

        foreach (var inn in Repo.Db.Inns.Values)
            foreach (var room in inn.Rooms) InnStay.Rest(room, false, false, Inn); // every room in the data parses
    }

    public static void RegularThresholds()
    {
        var t = Inn.Regular;
        Assert.Equal(RegularStatus.Stranger, InnStay.Status(2, false, false, t), "2 nights");
        Assert.Equal(RegularStatus.Guest, InnStay.Status(3, false, false, t), "3 nights");
        Assert.Equal(RegularStatus.Guest, InnStay.Status(12, false, false, t), "10+ nights but no favor");
        Assert.Equal(RegularStatus.Regular, InnStay.Status(10, true, false, t), "10 nights + favor");
        Assert.Equal(RegularStatus.Regular, InnStay.Status(40, true, false, t), "30+ nights but no keeper quest");
        Assert.Equal(RegularStatus.Family, InnStay.Status(30, true, true, t), "30 nights + keeper quest");
    }

    public static void MartasTabNeverBlocks()
    {
        var tab = new InnTab(Inn.Tab);
        Assert.True(tab.AvailableAt(InnTab.SleepingGriffon, RankLetter.F, RegularStatus.Stranger), "Griffon tab at F");
        Assert.True(!tab.AvailableAt(InnTab.SleepingGriffon, RankLetter.D, RegularStatus.Guest), "not at D unless a Regular");
        Assert.True(tab.AvailableAt("inn_anvils_rest", RankLetter.C, RegularStatus.Regular), "Regulars get a tab anywhere");
        for (int i = 0; i < 50; i++) Assert.True(tab.Charge(100), "charging always succeeds");
        Assert.True(tab.OverLimit, "over the limit (Marta writes letters)");
        Assert.Equal(0, tab.Pay(5000), "pays off exactly");
        Assert.True(tab.PaidOffOnce && tab.BalanceCopper == 0, "first tab paid off");
        Assert.Equal(40, tab.Pay(40), "overpaying returns the change");
    }
}
