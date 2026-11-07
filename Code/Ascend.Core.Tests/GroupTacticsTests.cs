using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using Ascend.Core;

// Group tactics (combat.md section 10a, Canon 4d). Peers are symmetric; there are no leaders and nothing is remembered.
// HARD RULES the source-scan tests below enforce on GroupTactics.cs and MonsterAi.cs: no Captain/Commander/Warchief/
// Leader type or member, no per-player memory store, no static state.
[Tests]
static class GroupTacticsTests
{
    const double Dt = 1.0 / 60;
    const string Pack = "mon_goblin_trapper";   // pack_flank, retreatHpPct 0.25

    static MonsterBrain Brain(string id, ulong seed = 7) =>
        new MonsterBrain(Repo.Db.Species[id], Repo.Db.Motion[id], Repo.Db.Attacks, new DeterministicRandom(seed));

    static AiSense Sense(double d, bool token = true, double hp = 1, double home = 0, int packmates = 0) =>
        new AiSense { DistanceToPlayer = d, DistanceFromHome = home, HpFraction = hp, HasToken = token, PackmatesNear = packmates };

    // ------------------------------------------------------------------ flank slots
    public static void FlankSlotsAreDistinctAndDeterministicFromMemberOrder()
    {
        var a = FlankSlots.Assign(new[] { 7, 3, 5 });
        Assert.Equal(1, a[3], "lowest id takes slot 1");
        Assert.Equal(2, a[5], "next id slot 2");
        Assert.Equal(3, a[7], "next id slot 3");
        Assert.Equal(3, a.Values.Distinct().Count(), "three members, three distinct slots");
        var b = FlankSlots.Assign(new[] { 5, 7, 3 });
        foreach (var kv in a) Assert.Equal(kv.Value, b[kv.Key], $"order of the input list does not matter (id {kv.Key})");
        var dup = FlankSlots.Assign(new[] { 3, 3, 5 });
        Assert.Equal(2, dup.Count, "duplicate ids collapse");
    }

    public static void FlankSlotsWrapOnlyWhenThereAreMoreMembersThanSlots()
    {
        foreach (int slots in new[] { 2, 3, 4 })
        {
            var t = new GroupTacticsTuning { FlankSlotCount = slots };
            var a = FlankSlots.Assign(Enumerable.Range(1, 6), t);
            var firstN = Enumerable.Range(1, slots).Select(i => a[i]).ToList();
            Assert.Equal(slots, firstN.Distinct().Count(), $"first {slots} members get distinct slots");
            Assert.True(a.Values.All(v => v >= 1 && v <= slots), "slots stay in range");
            var angles = Enumerable.Range(1, slots).Select(s => FlankSlots.AngleDeg(s, t)).ToList();
            Assert.Equal(slots, angles.Distinct().Count(), $"{slots} slots have {slots} distinct angles");
            Assert.True(angles.All(x => x >= -t.FlankArcDeg / 2 - 1e-9 && x <= t.FlankArcDeg / 2 + 1e-9), "angles inside the arc");
        }
        Assert.Near(0, FlankSlots.AngleDeg(0), 1e-9, "no slot, no angle");
        Assert.Near(0, FlankSlots.AngleDeg(1, new GroupTacticsTuning { FlankSlotCount = 1 }), 1e-9, "a single slot faces the axis");
        Assert.Equal(6, new GroupTacticsTuning { FlankSlotCount = 99 }.SlotCountClamped, "slot count clamps to 6");
        Assert.Equal(1, new GroupTacticsTuning { FlankSlotCount = 0 }.SlotCountClamped, "and to at least 1");
    }

    public static void ACirclingBrainReportsItsSlotAngleAndNoSlotMeansNoAngle()
    {
        var t = new GroupTacticsTuning();
        var b = Brain("mon_goblin");
        var s = Sense(1.2, token: false);
        s.FlankSlot = 3; s.FlankSlotCount = 3;
        b.Tick(Dt, s);
        var cmd = b.Tick(Dt, s);
        Assert.Equal(AiMove.Circle, cmd.Move, "circles while waiting for a token");
        Assert.Near(FlankSlots.AngleDeg(3, t, 3), cmd.FlankAngleDeg, 1e-9, "flank angle of slot 3 of 3");
        var plain = Brain("mon_goblin");
        plain.Tick(Dt, Sense(1.2, token: false));
        Assert.Near(0, plain.Tick(Dt, Sense(1.2, token: false)).FlankAngleDeg, 1e-9, "no slot supplied, angle 0");
    }

    // ------------------------------------------------------------------ retreat
    public static void RetreatThresholdsAreUnchangedWhenPlayerHpIsNotSupplied()
    {
        Assert.Near(0.5, RetreatRule.LoneThreshold(MonsterBrain.LoneRetreatHp, 0), 1e-9, "lone, no player HP");
        Assert.Near(0.25, RetreatRule.SpeciesThreshold(0.25, 0), 1e-9, "species, no player HP");
        Assert.Near(0, RetreatRule.SpeciesThreshold(0, 0.1), 1e-9, "a species that never retreats still never does");
    }

    public static void RetreatThresholdsPressOnAgainstAWeakPlayerAndFallBackEarlierFromAHealthyOne()
    {
        var t = new GroupTacticsTuning();
        Assert.True(RetreatRule.LoneThreshold(0.5, 0.1, t) < 0.5, "a nearly beaten player: the pack presses on");
        Assert.True(RetreatRule.LoneThreshold(0.5, 0.95, t) > 0.5, "a healthy player: a lone monster falls back sooner");
        Assert.Near(0.5, RetreatRule.LoneThreshold(0.5, 0.5, t), 1e-9, "middle: unchanged");
        Assert.True(RetreatRule.SpeciesThreshold(0.25, 0.1, t) < 0.25, "species retreat also presses on");
        Assert.Near(0.25, RetreatRule.SpeciesThreshold(0.25, 0.9, t), 1e-9, "species retreat otherwise unchanged");
    }

    public static void ALoneHurtPackMonsterFallsBackHome()
    {
        var m = Repo.Db.Motion[Pack].Behavior;
        Assert.True(Brain(Pack).IsPack, "test setup: trapper is a pack species");
        var b = Brain(Pack);
        b.Tick(Dt, Sense(m.AlertRadius - 1));
        Assert.Equal(AiState.Chase, b.State, "alerted and chasing");
        // 0.4 is above its own retreat percentage (0.25) but under the lone limit (0.5), with no packmates.
        var cmd = b.Tick(Dt, Sense(m.AlertRadius - 1, hp: 0.4, home: 3, packmates: 0));
        Assert.Equal(AiState.Return, b.State, "alone and hurt: falls back");
        Assert.Equal(AiMove.Home, cmd.Move, "heading home");
        Assert.True(cmd.ReleaseToken, "and lets go of its token");
    }

    public static void ALoneHurtPackMonsterStaysIfItHasPackmates()
    {
        var m = Repo.Db.Motion[Pack].Behavior;
        var b = Brain(Pack);
        b.Tick(Dt, Sense(m.AlertRadius - 1));
        b.Tick(Dt, Sense(m.AlertRadius - 1, hp: 0.4, home: 3, packmates: 2));
        Assert.True(b.State != AiState.Return, "with packmates near it fights on");
    }

    public static void APackMonsterPressesOnWhenThePlayerIsNearlyBeaten()
    {
        var m = Repo.Db.Motion[Pack].Behavior;
        var b = Brain(Pack);
        b.Tick(Dt, Sense(m.AlertRadius - 1));
        var s = Sense(m.AlertRadius - 1, hp: 0.4, home: 3, packmates: 0);
        s.PlayerHpFraction = 0.1;
        b.Tick(Dt, s);
        Assert.True(b.State != AiState.Return, "player at 10% HP: the lone monster does not fall back at 40%");
    }

    public static void AHealthyPlayerMakesALoneMonsterFallBackAtAHigherHp()
    {
        var m = Repo.Db.Motion[Pack].Behavior;
        var b = Brain(Pack);
        b.Tick(Dt, Sense(m.AlertRadius - 1));
        var s = Sense(m.AlertRadius - 1, hp: 0.55, home: 3, packmates: 0);
        s.PlayerHpFraction = 1.0;
        b.Tick(Dt, s);
        Assert.Equal(AiState.Return, b.State, "55% HP is above the old 50% limit but under the healthy-player limit");
        var old = Brain(Pack);
        old.Tick(Dt, Sense(m.AlertRadius - 1));
        old.Tick(Dt, Sense(m.AlertRadius - 1, hp: 0.55, home: 3, packmates: 0));
        Assert.True(old.State != AiState.Return, "without player HP the same monster fights on (old behaviour)");
    }

    public static void ASpeciesWithARetreatPercentageFleesAtItAndPressesOnAgainstAWeakPlayer()
    {
        const string Id = "mon_bubble_slime";   // passive_wander, retreatHpPct 0.6
        var m = Repo.Db.Motion[Id].Behavior;
        Assert.True(m.RetreatHpPct > 0, "test setup: it retreats");
        MonsterBrain Chasing() { var b = Brain(Id); b.Tick(Dt, Sense(m.AlertRadius - 1)); Assert.Equal(AiState.Chase, b.State, "chasing"); return b; }

        var above = Chasing();
        above.Tick(Dt, Sense(m.AlertRadius - 1, hp: m.RetreatHpPct + 0.1));
        Assert.True(above.State != AiState.Flee, "above its retreat percentage it fights");
        var below = Chasing();
        below.Tick(Dt, Sense(m.AlertRadius - 1, hp: m.RetreatHpPct - 0.1));
        Assert.Equal(AiState.Flee, below.State, "below it, it flees (old behaviour)");
        var weakPlayer = Chasing();
        var s = Sense(m.AlertRadius - 1, hp: m.RetreatHpPct - 0.1);
        s.PlayerHpFraction = 0.1;
        weakPlayer.Tick(Dt, s);
        Assert.True(weakPlayer.State != AiState.Flee, "against a nearly beaten player the same monster presses on");
    }

    // ------------------------------------------------------------------ peer yielding
    static PackMember M(int id, double hp, bool wants = true) => new PackMember { Id = id, HpFraction = hp, WantsToken = wants };

    public static void AHurtMonsterYieldsTheTokenToAHealthierPeer()
    {
        var pack = new[] { M(1, 0.3), M(2, 0.9) };
        Assert.True(PeerCoordinator.ShouldYield(1, pack), "the hurt one yields");
        Assert.True(!PeerCoordinator.ShouldYield(2, pack), "the healthy one keeps it");
        Assert.Equal(2, PeerCoordinator.Winner(pack), "winner is the healthy one");
    }

    public static void YieldingIsSymmetricExactlyOneContenderKeepsTheToken()
    {
        // Same HP bucket: the lowest id keeps it, everyone else yields. Swapping ids swaps the answer; no role is involved.
        var pack = new[] { M(4, 0.8), M(2, 0.8), M(9, 0.8) };
        Assert.Equal(2, PeerCoordinator.Winner(pack), "lowest id wins a tie");
        Assert.True(!PeerCoordinator.ShouldYield(2, pack), "2 keeps");
        Assert.True(PeerCoordinator.ShouldYield(4, pack) && PeerCoordinator.ShouldYield(9, pack), "the others yield");
        Assert.Equal(1, pack.Count(m => !PeerCoordinator.ShouldYield(m.Id, pack)), "exactly one keeper");
        // The answer depends on the list contents, not the list order.
        var shuffled = new[] { M(9, 0.8), M(4, 0.8), M(2, 0.8) };
        Assert.Equal(PeerCoordinator.Winner(pack), PeerCoordinator.Winner(shuffled), "list order does not matter");
        // Gap: 0.31 vs 0.44 differ by 0.13, under the 0.2 gap, so the id decides, not the 13 point lead.
        var near = new[] { M(1, 0.31), M(2, 0.44) };
        Assert.Equal(1, PeerCoordinator.Winner(near), "tiny HP lead inside the gap does not decide");
    }

    public static void YieldComparesTheRealHpGapNotBuckets()
    {
        double gap = new GroupTacticsTuning().YieldHpGap;
        // 0.59 vs 0.61 straddle a bucket edge (0.6) but are only 0.02 apart: equal, so the lower id keeps the token whichever side it is on.
        var a = new[] { M(1, 0.61), M(2, 0.59) };
        Assert.Equal(1, PeerCoordinator.Winner(a), "0.59 vs 0.61: id 1 (healthier here) wins by id");
        var b = new[] { M(1, 0.59), M(2, 0.61) };
        Assert.Equal(1, PeerCoordinator.Winner(b), "0.59 vs 0.61 with ids swapped: id 1 still wins, HP does not decide");
        Assert.True(PeerCoordinator.ShouldYield(2, b) && !PeerCoordinator.ShouldYield(1, b), "the higher id yields despite the higher HP");
        // A large gap: the healthier one wins even with the higher id.
        var c = new[] { M(1, 0.2), M(2, 0.2 + gap + 0.3) };
        Assert.Equal(2, PeerCoordinator.Winner(c), "a large HP gap: the healthier peer wins");
        Assert.True(PeerCoordinator.ShouldYield(1, c) && !PeerCoordinator.ShouldYield(2, c), "the hurt one yields");
        // Exactly the gap counts as a real lead.
        var half = new GroupTacticsTuning { YieldHpGap = 0.5 };   // exactly representable, so the difference is exactly the gap
        var d = new[] { M(1, 0.25), M(2, 0.75) };
        Assert.Equal(2, PeerCoordinator.Winner(d, half), "a lead of exactly the gap decides");
    }

    public static void AnEvenPairAndTheOldBucketEdgeCaseNowAgree()
    {
        // Under buckets 0.29 vs 0.31 (gap 0.2 -> buckets 1 and 1) agreed, 0.39 vs 0.41 (1 vs 2) did not; now both are "equal".
        Assert.Equal(1, PeerCoordinator.Winner(new[] { M(1, 0.39), M(2, 0.41) }), "0.39 vs 0.41 equal -> id");
        Assert.Equal(1, PeerCoordinator.Winner(new[] { M(1, 0.29), M(2, 0.31) }), "0.29 vs 0.31 equal -> id");
    }

    public static void NobodyYieldsWhenAlonePeersDoNotWantItOrTheMemberIsUnknown()
    {
        Assert.True(!PeerCoordinator.ShouldYield(1, new[] { M(1, 0.2) }), "a lone contender never yields");
        Assert.True(!PeerCoordinator.ShouldYield(1, new[] { M(1, 0.2), M(2, 0.9, wants: false) }), "a peer that does not want it is no rival");
        Assert.True(!PeerCoordinator.ShouldYield(1, new[] { M(1, 0.2, wants: false), M(2, 0.9) }), "a monster that does not want one has nothing to yield");
        Assert.True(!PeerCoordinator.ShouldYield(99, new[] { M(1, 0.2), M(2, 0.9) }), "unknown id");
        Assert.Equal(-1, PeerCoordinator.Winner(new[] { M(1, 0.2, false), M(2, 0.9, false) }), "nobody wants a token");
        Assert.Equal(-1, PeerCoordinator.Winner(new PackMember[0]), "empty pack");
    }

    public static void TheBrainSkipsItsAttackAndKeepsCirclingWhenToldToYield()
    {
        var b = Brain("mon_goblin");
        b.Tick(Dt, Sense(1.2));
        var yielded = Sense(1.2);
        yielded.YieldToken = true;
        for (int i = 0; i < 120; i++)
        {
            var cmd = b.Tick(Dt, yielded);
            Assert.True(!cmd.StrikeNow, "no strike while yielding");
            Assert.True(!cmd.WantsToken && cmd.ReleaseToken, "it lets the token go");
        }
        Assert.Equal(AiState.Reposition, b.State, "keeps circling");
        // Told it may keep the token again, it attacks.
        double t = 0; bool struck = false;
        for (; t < 5 && !struck; t += Dt) struck = b.Tick(Dt, Sense(1.2)).StrikeNow;
        Assert.True(struck, "attacks once it no longer has to yield");
    }

    // ------------------------------------------------------------------ threat is information, pure and bounded
    public static void ThreatScoreIsBoundedPureAndMovesTheRightWay()
    {
        var t = new GroupTacticsTuning();
        double calm = ThreatAssessor.Score(0.2, 4, 1.0, t);
        double dire = ThreatAssessor.Score(1.0, 0, 0.1, t);
        Assert.True(calm >= 0 && calm <= 1 && dire >= 0 && dire <= 1, "bounded 0-1");
        Assert.True(dire > calm, "healthy player, no allies, wounded self is more threatening than the reverse");
        Assert.True(ThreatAssessor.Score(1, 0, 1, t) > ThreatAssessor.Score(1, 3, 1, t), "allies lower the threat");
        Assert.True(ThreatAssessor.Score(1, 1, 0.2, t) > ThreatAssessor.Score(1, 1, 0.9, t), "being wounded raises it");
        Assert.True(ThreatAssessor.Score(1.0, 1, 1, t) > ThreatAssessor.Score(0.1, 1, 1, t), "a stronger player raises it");
        // No memory: the same inputs give the same score no matter what was asked before.
        double first = ThreatAssessor.Score(0.6, 2, 0.7, t);
        for (int i = 0; i < 10; i++) ThreatAssessor.Score(0.01 * i, i, 0.1 * i, t);
        Assert.Near(first, ThreatAssessor.Score(0.6, 2, 0.7, t), 0, "pure function of its inputs");
    }

    public static void ThreatLevelIsReportedButNeverChangesTheBrainsChoices()
    {
        var plain = Brain("mon_goblin"); var informed = Brain("mon_goblin");
        for (int i = 0; i < 400; i++)
        {
            var s = Sense(1.2 + (i % 50) * 0.1, token: i % 3 != 0, hp: 1 - i / 500.0);
            var s2 = s; s2.AlliesNear = i % 5;           // allies only feed ThreatLevel
            var a = plain.Tick(Dt, s); var c = informed.Tick(Dt, s2);
            Assert.Equal(plain.State, informed.State, $"state at tick {i}");
            Assert.Equal(a.Move, c.Move, $"move at tick {i}");
            Assert.Equal(a.StrikeNow, c.StrikeNow, $"strike at tick {i}");
            Assert.True(c.ThreatLevel >= 0 && c.ThreatLevel <= 1, "threat bounded");
        }
    }

    // ------------------------------------------------------------------ default AiSense == the old brain, tick for tick
    // The golden hashes were produced by running this exact scenario against MonsterAi.cs as it was at HEAD before
    // group tactics (git show HEAD:Code/Ascend.Core/MonsterAi.cs). Each entry hashes 300 ticks of
    // (state, move, speed, face, strike, wantsToken, releaseToken) for four species.
    static readonly string[] Golden = { "1aace72edcad2ed4", "9f4e797a4e47efa9", "aa118fc8526fdb1b", "b14bcdc91155d3cb", "e53f78178fca91f4", "ae85955ef396bb47" };

    public static string[] BrainTraceHashes()
    {
        var ids = new[] { "mon_goblin", Pack, "mon_horned_rabbit", "mon_blue_slime" };
        var brains = ids.Select(id => Brain(id, 11)).ToArray();
        var sb = new StringBuilder();
        var hashes = new System.Collections.Generic.List<string>();
        const int Ticks = 1800;
        for (int i = 0; i < Ticks; i++)
        {
            for (int k = 0; k < brains.Length; k++)
            {
                var b = brains[k];
                double alert = Repo.Db.Motion[ids[k]].Behavior.AlertRadius;
                var s = new AiSense
                {
                    DistanceToPlayer = 1.0 + (alert + 4) * System.Math.Abs(System.Math.Sin((i + k * 37) / 90.0)),
                    DistanceFromHome = ((i + k * 101) % 600) / 8.0,
                    HpFraction = System.Math.Max(0.2, 1.0 - ((i + k * 200) % 1500) / 1500.0),
                    HasToken = ((i / 40) + k) % 3 != 0,
                    PackmatesNear = (i / 200) % 2 == 0 ? 0 : 2,
                    TargetWarded = i >= 700 && i < 740,
                };
                if (i == 300) b.Alert();
                if (i == 500 && k == 0) b.Stagger();
                if (i == 900 && k == 2) b.Stun(1.2);
                var c = b.Tick(Dt, s);
                sb.Append(k).Append(':').Append(b.State).Append(',').Append(c.Move).Append(',').Append(c.Speed.ToString("0.####", System.Globalization.CultureInfo.InvariantCulture))
                  .Append(',').Append(c.Face ? 1 : 0).Append(c.StrikeNow ? 1 : 0).Append(c.WantsToken ? 1 : 0).Append(c.ReleaseToken ? 1 : 0).Append(';');
            }
            if ((i + 1) % 300 == 0)
            {
                ulong h = 14695981039346656037UL;
                foreach (char ch in sb.ToString()) { h ^= ch; h *= 1099511628211UL; }
                hashes.Add(h.ToString("x16"));
                sb.Clear();
            }
        }
        return hashes.ToArray();
    }

    public static void DefaultAiSenseBehavesTickForTickLikeTheBrainBeforeGroupTactics()
    {
        var now = BrainTraceHashes();
        Assert.Equal(Golden.Length, now.Length, "number of checkpoints");
        for (int i = 0; i < now.Length; i++)
            Assert.Equal(Golden[i], now[i], $"trace hash for ticks {i * 300}-{i * 300 + 299} (the brain no longer matches its pre-tactics behaviour)");
    }

    public static void DefaultAiSenseLeavesTheNewOutputsAtTheirNeutralValues()
    {
        var b = Brain("mon_goblin");
        for (int i = 0; i < 300; i++)
        {
            var c = b.Tick(Dt, Sense(1.2, token: i % 2 == 0));
            Assert.Near(0, c.FlankAngleDeg, 0, "no slot supplied, no flank angle");
        }
    }

    // ------------------------------------------------------------------ nothing remembered, nothing ranked
    public static void ThreatLevelDependsOnlyOnThisTicksSenseNotOnHistory()
    {
        // "Memory of the player" would show up as the history changing later outputs. The threat level is computed
        // from the sense passed in; a brain with a long, violent past reports the same number as a fresh one.
        var m = Repo.Db.Motion[Pack].Behavior;
        var veteran = Brain(Pack, 5);
        var low = Sense(m.AlertRadius - 1); low.PlayerHpFraction = 0.05; low.AlliesNear = 0;
        for (int i = 0; i < 600; i++) veteran.Tick(Dt, low);
        veteran.Stun(0.05);
        for (int i = 0; i < 30; i++) veteran.Tick(Dt, Sense(m.AlertRadius - 1, hp: 0.2));
        var fresh = Brain(Pack, 5);
        var probe = Sense(m.AlertRadius - 1, hp: 0.7, packmates: 1); probe.PlayerHpFraction = 0.8; probe.AlliesNear = 2;
        Assert.Near(fresh.Tick(Dt, probe).ThreatLevel, veteran.Tick(Dt, probe).ThreatLevel, 0, "same sense, same threat");
        Assert.Near(ThreatAssessor.Score(0.8, 2, 0.7, veteran.Tactics), veteran.Tick(Dt, probe).ThreatLevel, 0, "and it is exactly ThreatAssessor.Score of that sense");
    }

    static string Strip(string source)
    {
        source = Regex.Replace(source, @"/\*.*?\*/", " ", RegexOptions.Singleline);
        source = Regex.Replace(source, @"//[^\n]*", " ");
        source = Regex.Replace(source, "@\"(?:[^\"]|\"\")*\"|\"(?:\\\\.|[^\"\\\\\\n])*\"", "\"\"");
        return source;
    }

    static string[] ScannedFiles() => new[] { "Code/Ascend.Core/GroupTactics.cs", "Code/Ascend.Core/MonsterAi.cs" };
    static string Code(string rel) => Strip(File.ReadAllText(Path.Combine(Repo.Root(), rel)));

    public static void SourceHasNoCaptainCommanderWarchiefOrLeaderConceptAndNoPlayerMemory()
    {
        // Comments are stripped first, so a comment restating the ban is fine. Only identifiers are checked.
        var banned = new Regex(@"\b\w*(captain|commander|warchief|leader|memor(y|ies)|remember|learn|adapt)\w*\b", RegexOptions.IgnoreCase);
        foreach (var rel in ScannedFiles())
        {
            var code = Code(rel);
            Assert.True(code.Length > 1000, $"{rel} was read");
            var hits = banned.Matches(code).Select(m => m.Value).Distinct().ToList();
            Assert.True(hits.Count == 0, $"{rel} defines a banned concept (Canon 4d: no ranks among monsters, no learning): {string.Join(", ", hits)}");
        }
    }

    public static void GroupTacticsHasNoRankOrRoleTypeOrMemberAndHoldsNoState()
    {
        var code = Code("Code/Ascend.Core/GroupTactics.cs");
        // Type declarations: none may be a role or rank.
        var types = Regex.Matches(code, @"\b(?:class|struct|enum|interface)\s+(\w+)").Select(m => m.Groups[1].Value).ToList();
        Assert.True(types.Count >= 6, $"expected the group tactics types, found {types.Count}");
        foreach (var name in types)
            Assert.True(!Regex.IsMatch(name, "rank|role|leader|captain|commander|warchief|boss|alpha|chief|elder", RegexOptions.IgnoreCase), $"type \"{name}\" reads like a rank or role");
        // Members that look like a rank or role field.
        Assert.True(!Regex.IsMatch(code, @"\b(?:public|internal|private|protected)\b[^;{(]*\b(Rank|Role|IsLeader|Alpha|Rally|Chain)\w*\s*[;{=(]"), "no rank or role member");
        // No static mutable state and no collection fields that could hold a per-player history.
        foreach (var line in code.Split('\n'))
        {
            var t = line.Trim();
            if (!Regex.IsMatch(t, @"\bstatic\b") || t.Contains("(") || Regex.IsMatch(t, @"\b(class|const|readonly)\b") || t.Contains("=>")) continue;
            Assert.True(false, $"static mutable state in GroupTactics.cs: {t}");
        }
        var fieldLike = Regex.Matches(code, @"^\s*(?:private|internal|public)?\s*(?:readonly\s+)?(?:Dictionary|List|HashSet|Queue)<[^>]*>\s+_\w+", RegexOptions.Multiline);
        Assert.Equal(0, fieldLike.Count, "no collection fields held between calls (nothing remembered)");
        // No randomness of its own: only the brain's injected IRandom may be used.
        Assert.True(!Regex.IsMatch(code, @"\bRandom\b|\bNextDouble\b|\bGuid\b|DateTime"), "no randomness or wall-clock in GroupTactics.cs");
    }

    // ------------------------------------------------------------------ the groupTactics block in combat_tuning.json
    public static void TheGroupTacticsBlockLoadsAndMapsOntoTheBrainTuning()
    {
        var g = Repo.Db.Tuning.GroupTactics;
        using var doc = JsonDocument.Parse(File.ReadAllText(Path.Combine(Repo.Root(), "Data/Combat/combat_tuning.json")));
        var j = doc.RootElement.GetProperty("groupTactics");
        Assert.Equal(j.GetProperty("enabled").GetBoolean(), g.Enabled, "enabled");
        Assert.Equal(j.GetProperty("flank").GetProperty("slotCount").GetInt32(), g.Flank.SlotCount, "flank.slotCount");
        Assert.True(g.Flank.SlotCount >= 2 && g.Flank.SlotCount <= 4, "2-4 slots (plan)");
        Assert.Near(j.GetProperty("flank").GetProperty("arcDeg").GetDouble(), g.Flank.ArcDeg, 1e-9, "flank.arcDeg");
        Assert.Near(j.GetProperty("retreat").GetProperty("packRetreatHpFraction").GetDouble(), g.Retreat.PackRetreatHpFraction, 1e-9, "retreat.packRetreatHpFraction");
        Assert.Near(j.GetProperty("retreat").GetProperty("loneRetreatHpFraction").GetDouble(), g.Retreat.LoneRetreatHpFraction, 1e-9, "retreat.loneRetreatHpFraction");
        Assert.Near(MonsterBrain.LoneRetreatHp, g.Retreat.LoneRetreatHpFraction, 1e-9, "the lone retreat base restates MonsterBrain.LoneRetreatHp");
        Assert.Near(j.GetProperty("threat").GetProperty("playerStrengthWeight").GetDouble(), g.Threat.PlayerStrengthWeight, 1e-9, "threat.playerStrengthWeight");
        Assert.Near(j.GetProperty("yield").GetProperty("hpMargin").GetDouble(), g.Yield.HpMargin, 1e-9, "yield.hpMargin");
        Assert.Equal(2, Repo.Db.Tuning.Ai.MaxSimultaneousAttackers, "ai.maxSimultaneousAttackers is untouched");

        var t = g.ToTuning();
        Assert.Equal(g.Flank.SlotCount, t.FlankSlotCount, "ToTuning slot count");
        Assert.Near(g.Flank.ArcDeg, t.FlankArcDeg, 1e-9, "ToTuning arc");
        Assert.Near(g.Threat.PlayerStrengthWeight, t.ThreatPlayerWeight, 1e-9, "ToTuning player weight");
        Assert.Near(g.Threat.OutnumberedWeight, t.ThreatAlliesWeight, 1e-9, "ToTuning allies weight");
        Assert.Near(g.Threat.OwnWoundedWeight, t.ThreatOwnHpWeight, 1e-9, "ToTuning own-hp weight");
        Assert.Equal(g.Threat.AlliesForFullSupport, t.ThreatAlliesFull, "ToTuning allies-for-full");
        Assert.Near(g.Yield.HpMargin, t.YieldHpGap, 1e-9, "ToTuning yield gap");
        Assert.Near(g.Yield.HoldSec, t.YieldSec, 1e-9, "ToTuning yield seconds");
        Assert.Near(g.Retreat.PressOnPlayerHp, t.PressOnPlayerHp, 1e-9, "ToTuning pressOnPlayerHp");
        Assert.Near(g.Retreat.PressOnRetreatScale, t.PressOnRetreatScale, 1e-9, "ToTuning pressOnRetreatScale");
        Assert.Near(g.Retreat.HealthyPlayerHp, t.HealthyPlayerHp, 1e-9, "ToTuning healthyPlayerHp");
        Assert.Near(g.Retreat.OutnumberedRetreatBonus, t.OutnumberedRetreatBonus, 1e-9, "ToTuning outnumberedRetreatBonus");
        Assert.Near(j.GetProperty("retreat").GetProperty("pressOnPlayerHp").GetDouble(), t.PressOnPlayerHp, 1e-9, "JSON retreat.pressOnPlayerHp");
        Assert.Near(j.GetProperty("retreat").GetProperty("pressOnRetreatScale").GetDouble(), t.PressOnRetreatScale, 1e-9, "JSON retreat.pressOnRetreatScale");
        Assert.Near(j.GetProperty("retreat").GetProperty("healthyPlayerHp").GetDouble(), t.HealthyPlayerHp, 1e-9, "JSON retreat.healthyPlayerHp");
        Assert.Near(j.GetProperty("retreat").GetProperty("outnumberedRetreatBonus").GetDouble(), t.OutnumberedRetreatBonus, 1e-9, "JSON retreat.outnumberedRetreatBonus");
        Assert.Equal(g.Enabled, t.Enabled, "ToTuning enabled");
    }

    public static void InCodeDefaultsEqualTheDataSoTheJsonIsTheSingleSourceOfTruth()
    {
        // Every field of GroupTacticsTuning that ToTuning maps: the default constructed value must equal the value loaded from JSON.
        var d = new GroupTacticsTuning();
        var t = Repo.Db.Tuning.GroupTactics.ToTuning();
        Assert.Equal(t.Enabled, d.Enabled, "Enabled");
        Assert.Equal(t.FlankSlotCount, d.FlankSlotCount, "FlankSlotCount");
        Assert.Near(t.FlankArcDeg, d.FlankArcDeg, 1e-12, "FlankArcDeg");
        Assert.Near(t.PressOnPlayerHp, d.PressOnPlayerHp, 1e-12, "PressOnPlayerHp");
        Assert.Near(t.PressOnRetreatScale, d.PressOnRetreatScale, 1e-12, "PressOnRetreatScale");
        Assert.Near(t.HealthyPlayerHp, d.HealthyPlayerHp, 1e-12, "HealthyPlayerHp");
        Assert.Near(t.OutnumberedRetreatBonus, d.OutnumberedRetreatBonus, 1e-12, "OutnumberedRetreatBonus");
        Assert.Near(t.YieldHpGap, d.YieldHpGap, 1e-12, "YieldHpGap");
        Assert.Near(t.YieldSec, d.YieldSec, 1e-12, "YieldSec");
        Assert.Near(t.ThreatPlayerWeight, d.ThreatPlayerWeight, 1e-12, "ThreatPlayerWeight");
        Assert.Near(t.ThreatAlliesWeight, d.ThreatAlliesWeight, 1e-12, "ThreatAlliesWeight");
        Assert.Near(t.ThreatOwnHpWeight, d.ThreatOwnHpWeight, 1e-12, "ThreatOwnHpWeight");
        Assert.Equal(t.ThreatAlliesFull, d.ThreatAlliesFull, "ThreatAlliesFull");
        // And the mirror classes' own defaults equal the JSON too (an absent key behaves like the file).
        var m = new GroupTacticsData();
        var g = Repo.Db.Tuning.GroupTactics;
        Assert.Near(g.Flank.ArcDeg, m.Flank.ArcDeg, 1e-12, "mirror arc"); Assert.Near(g.Yield.HpMargin, m.Yield.HpMargin, 1e-12, "mirror gap");
        Assert.Near(g.Threat.OutnumberedWeight, m.Threat.OutnumberedWeight, 1e-12, "mirror allies weight");
    }

    public static void DisablingGroupTacticsMakesTheBrainBehaveLikeTheOldBrain()
    {
        var m = Repo.Db.Motion[Pack].Behavior;
        var off = Repo.Db.Tuning.GroupTactics.ToTuning(); off.Enabled = false;
        // 1. A healthy player no longer raises the lone-retreat limit (0.55 stays above 0.5).
        var b = Brain(Pack); b.Tactics = off;
        b.Tick(Dt, Sense(m.AlertRadius - 1));
        var s = Sense(m.AlertRadius - 1, hp: 0.55, home: 3, packmates: 0); s.PlayerHpFraction = 1.0;
        b.Tick(Dt, s);
        Assert.True(b.State != AiState.Return, "tactics off: the player's HP changes nothing");
        // 2. A yield order is ignored, no flank angle, no threat score.
        var g = Brain("mon_goblin"); g.Tactics = off;
        g.Tick(Dt, Sense(1.2, token: false));
        var s2 = Sense(1.2, token: true); s2.YieldToken = true; s2.FlankSlot = 3; s2.FlankSlotCount = 3; s2.PlayerHpFraction = 0.5;
        bool struck = false; AiCommand last = default;
        for (double t = 0; t < 4 && !struck; t += Dt) { last = g.Tick(Dt, s2); struck = last.StrikeNow; }
        Assert.True(struck, "tactics off: the yield order is ignored and it attacks");
        Assert.Near(0, last.FlankAngleDeg, 1e-12, "no flank angle");
        Assert.Near(0, last.ThreatLevel, 1e-12, "no threat score");
        // 3. The same sense with tactics ON does yield.
        var on = Brain("mon_goblin"); on.Tactics = Repo.Db.Tuning.GroupTactics.ToTuning();
        on.Tick(Dt, Sense(1.2, token: false));
        for (int i = 0; i < 120; i++) Assert.True(!on.Tick(Dt, s2).StrikeNow, "tactics on: it yields");
    }

    public static void AMapBackedTuningDrivesTheBrainWithoutBreakingIt()
    {
        var b = Brain("mon_goblin");
        b.Tactics = Repo.Db.Tuning.GroupTactics.ToTuning();
        var s = Sense(1.2, token: false);
        s.FlankSlot = 2; s.FlankSlotCount = Repo.Db.Tuning.GroupTactics.Flank.SlotCount;
        b.Tick(Dt, s);
        var cmd = b.Tick(Dt, s);
        Assert.Near(FlankSlots.AngleDeg(2, b.Tactics, s.FlankSlotCount), cmd.FlankAngleDeg, 1e-9, "angle from the loaded tuning");
        Assert.True(cmd.ThreatLevel >= 0 && cmd.ThreatLevel <= 1, "threat bounded with loaded weights");
    }
}
