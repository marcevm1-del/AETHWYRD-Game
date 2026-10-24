using System.Collections.Generic;
using Ascend.Core;

// Day clock and inn rest (world_tuning.json calendar / inns; inns.md §2).
[Tests]
static class RestAndClockTests
{
    static GameCalendar Cal => new GameCalendar(Repo.Db.World.Calendar);

    public static void ADayIsNinetyMinutesOfPlay()
    {
        Assert.Equal(225.0, Cal.SecondsPerHour, "90 min / 24 h = 225 s per hour");
        var (day, hour) = Cal.FromPlaySeconds(Cal.SecondsPerHour * 30);
        Assert.Equal(1, day, "30 hours in: day 1");
        Assert.True(System.Math.Abs(hour - 6) < 1e-9, "06:00");
    }

    public static void SleepWakesAtDawn()
    {
        Assert.True(System.Math.Abs(Cal.HoursUntilDawn(22) - 8) < 1e-9, "22:00 → 8 hours");
        Assert.True(System.Math.Abs(Cal.HoursUntilDawn(2) - 4) < 1e-9, "02:00 → 4 hours (same day)");
        Assert.True(System.Math.Abs(Cal.HoursUntilDawn(6) - 24) < 1e-9, "at dawn already → next dawn");
    }

    public static void RestBuffsPlayDownWellRestedFirst()
    {
        var t = Repo.Db.World.Inns;
        var griffon = Repo.Db.Inns["inn_sleeping_griffon"];
        var buffs = InnStay.Stack(InnStay.Rest(griffon.Room("common"), false, false, t), InnStay.Rest(griffon.Room("private"), false, false, t));
        Assert.Equal(0.10, InnStay.XpBonus(buffs), "Well Rested (+10%) plays first");
        InnStay.Consume(buffs, 4.5);
        Assert.Equal(1, buffs.Count, "Well Rested used up");
        Assert.Equal(0.05, InnStay.XpBonus(buffs), "then Rested (+5%)");
        Assert.True(System.Math.Abs(buffs[0].Hours - 1.5) < 1e-9, "half an hour of it spent");
        InnStay.Consume(buffs, 10);
        Assert.Equal(0.0, InnStay.XpBonus(buffs), "nothing left");
    }

    public static void TheTabLoadsFromASave()
    {
        var tab = new InnTab(Repo.Db.World.Inns.Tab);
        tab.Load(140, false);
        Assert.Equal(140, tab.BalanceCopper, "balance");
        Assert.Equal(10, tab.Pay(150), "overpaid change");
        Assert.True(tab.PaidOffOnce, "first pay-off remembered");
    }
}
