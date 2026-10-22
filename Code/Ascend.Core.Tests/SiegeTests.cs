using Ascend.Core;

[Tests]
static class SiegeTests
{
    static SiegeTuning T => Repo.Db.World.Siege;
    static IEnumerable<RegionData> Besieged => Repo.Db.Regions.Values.Where(r => !r.NoSiege);

    public static void EveryRegionHasATyrantOrIsExempt()
    {
        foreach (var r in Repo.Db.Regions.Values)
        {
            if (r.NoSiege) { Assert.True(!string.IsNullOrEmpty(r.NoSiegeReason), $"{r.Id} noSiege needs a reason"); continue; }
            var t = Repo.Db.TyrantOf(r.Id);
            Assert.True(t != null && t.IsUnique && t.IsTyrant, $"{r.Id} Tyrant must be a unique Tyrant species");
            Assert.True(Repo.Db.SiegeWaves.ContainsKey(r.Id), $"{r.Id} has no wave set");
        }
    }

    public static void Ring1TyrantIsTheGoblinChief()
    {
        var t = Repo.Db.TyrantOf("reg_whisperwood");
        Assert.True(t.Name.StartsWith("Grukk"), "Whisperwood Tyrant");
        Assert.Equal(1, t.Ring, "Goblin Chief ships in Ring 1");
    }

    public static void OneOrTwoAttacksPerWeekNeverConsecutive()
    {
        var sched = new SiegeScheduler(T, worldSeed: 1024);
        int weeksWithTwo = 0, total = 0;
        foreach (var r in Besieged)
        {
            var allDays = new List<int>();
            for (int week = 0; week < 150; week++)
            {
                var attacks = sched.AttacksInWeek(r, week);
                Assert.True(attacks.Count is >= 1 and <= 2, $"{r.Id} week {week}: {attacks.Count} attacks");
                if (attacks.Count == 2) weeksWithTwo++;
                total++;
                foreach (var a in attacks)
                {
                    Assert.True(r.DefenceSettlements.Contains(a.Settlement), "settlement from the region's list");
                    Assert.Equal(a.Day - 1, a.AnnouncedOnDay, "announced one day ahead");
                    Assert.True(a.Hour == T.DuskHour || a.Hour == T.NightHour, "dusk or night");
                    allDays.Add(a.Day);
                }
            }
            for (int i = 1; i < allDays.Count; i++)
                Assert.True(allDays[i] - allDays[i - 1] >= 2, $"{r.Id}: attacks on consecutive days {allDays[i - 1]},{allDays[i]}");
        }
        double share = weeksWithTwo / (double)total;
        Assert.True(share is > 0.3 and < 0.7, $"about half the weeks have two attacks (got {share:P0})");
    }

    public static void ScheduleIsDeterministicPerSeed()
    {
        var r = Repo.Db.Regions["reg_whisperwood"];
        var a = new SiegeScheduler(T, 7).AttacksInWeek(r, 12).Select(x => (x.Day, x.Settlement, x.Hour)).ToList();
        var b = new SiegeScheduler(T, 7).AttacksInWeek(r, 12).Select(x => (x.Day, x.Settlement, x.Hour)).ToList();
        Assert.True(a.SequenceEqual(b), "same seed, same schedule");
        var days = Enumerable.Range(0, 20).Select(w => string.Join(",", new SiegeScheduler(T, 99).DaysOfWeek(r.Id, w))).Distinct().Count();
        Assert.True(days > 5, "schedules vary week to week");
    }

    public static void LiberatedRegionsAreNeverAttacked()
    {
        var r = Repo.Db.Regions["reg_whisperwood"];
        var threat = new RegionThreat(r.Id, RegionState.Besieged, T);
        var sched = new SiegeScheduler(T, 1);
        Assert.True(sched.AttacksInWeek(r, 3, threat).Count >= 1, "besieged: attacks");
        threat.TyrantSlain();
        for (int w = 0; w < 50; w++) Assert.Equal(0, sched.AttacksInWeek(r, w, threat).Count, "liberated: no attacks");
        Assert.Equal(0, sched.AttacksInWeek(Repo.Db.Regions["reg_vesper"], 0).Count, "noSiege region");
    }

    public static void ThreatStatesAndEscalation()
    {
        var t = new RegionThreat("reg_x", RegionState.Besieged, T);
        for (int i = 0; i < 20; i++) t.OnWeekEnded();
        Assert.Equal(T.MaxEscalation, t.Escalation, "escalation caps");
        t.LieutenantsCleared();
        Assert.Equal(RegionState.Weakened, t.State, "weakened");
        Assert.Equal(T.MaxEscalation - T.WeakenedEscalationReduction, t.EffectiveEscalation, "weakened attacks are smaller");
        t.TyrantSlain();
        t.OnWeekEnded(); t.LieutenantsCleared();
        Assert.Equal(RegionState.Liberated, t.State, "liberation is permanent");
        Assert.Equal(0, t.EffectiveEscalation, "no escalation after liberation");
    }

    public static void AutoResolveNeverDestroysASettlement()
    {
        var ar = T.AutoResolve;
        var rng = new DeterministicRandom(5);
        var town = new SettlementProsperity("Brindlewick", 50, 50, ar.ProsperityFloor);
        for (int i = 0; i < 200; i++)
        {
            var r = SiegeAutoResolve.Resolve(new SettlementDefence { Safety = 0 }, T.MaxEscalation, ar, rng);
            Assert.True(!r.SettlementDestroyed, "never destroyed");
            Assert.True(r.WealthLoss <= ar.MaxWealthLoss && r.SafetyLoss <= ar.MaxSafetyLoss && r.BuildingsDamaged <= ar.MaxBuildingsDamaged, "losses capped");
            town.Apply(r);
        }
        Assert.Equal(ar.ProsperityFloor, town.Wealth, "Prosperity bottoms out at the floor");
        town.Repair(1000);
        Assert.Equal(0, town.DamagedBuildings, "damage is repairable");
    }

    public static void StrongDefencesRepelWeakOnes()
    {
        var ar = T.AutoResolve;
        var rng = new DeterministicRandom(11);
        int repelled = 0, breached = 0;
        for (int i = 0; i < 200; i++)
        {
            if (SiegeAutoResolve.Resolve(new SettlementDefence { Safety = 90, Guards = 10, NpcAdventurers = 4, Barricades = 5 }, 0, ar, rng).Outcome == SiegeOutcome.Repelled) repelled++;
            if (SiegeAutoResolve.Resolve(new SettlementDefence { Safety = 10 }, T.MaxEscalation, ar, rng).Outcome == SiegeOutcome.Breached) breached++;
        }
        Assert.True(repelled > 190, $"well-defended town repels (got {repelled}/200)");
        Assert.True(breached > 190, $"undefended town at max escalation is breached (got {breached}/200)");
    }

    public static void WaveCountsEscalate()
    {
        var w = Repo.Db.SiegeWaves["reg_whisperwood"];
        var u = w.Waves[0].Units[0];
        Assert.True(w.ScaledCount(u, 3) > u.Count, "escalation adds units");
        Assert.Equal(w.ScaledCount(u, w.Escalation.MaxStep), w.ScaledCount(u, 99), "capped at max step");
        foreach (var wave in w.Waves) foreach (var unit in wave.Units)
            Assert.True(Repo.Db.Species[unit.SpeciesId].Habitats.Contains("reg_whisperwood"), "wave species live in the region");
    }
}
