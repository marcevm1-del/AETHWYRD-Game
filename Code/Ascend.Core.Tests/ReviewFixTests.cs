using Ascend.Core;

// Tests for the 2026-10-22 review fixes (Part B of the v0.11 session).
[Tests]
static class ReviewFixTests
{
    static CombatTuning C => Repo.Db.Tuning;

    // B1 — Style points are capped, so decay works right after long combos.
    public static void StylePointsCapAndStillDecay()
    {
        var m = new StyleMeter(C.Style);
        for (int i = 0; i < 300; i++) m.RegisterHit("move_" + (i % 9), HitWeight.Heavy);
        Assert.Near(C.Style.PointsCap, m.Points, 0.001, "points capped");
        Assert.Equal(StyleRank.SSS, m.Rank, "still SSS at the cap");
        m.Tick(C.Style.DecayDelaySec + 1);
        Assert.True(m.Points < C.Style.PointsCap, "decay starts immediately after the delay");
        m.Tick(15);
        Assert.True(m.Rank < StyleRank.SSS, "SSS is lost after ~15 s idle");
    }

    // B2 — Freeze and Storm Prison have real effects.
    public static void FreezeHoldsAndHeavyHitShatters()
    {
        var r = new ReactionState(C.Reactions);
        r.ApplyElement(Element.Water, 0);
        Assert.Equal(Reaction.Freeze, r.ApplyElement(Element.Ice, 1), "water + ice");
        Assert.True(r.IsFrozen(1.5) && !r.CanAct(1.5), "frozen target can't act");
        Assert.Near(1.0, r.HitMultiplier(HitWeight.Light, 1.6), 1e-9, "light hits don't shatter");
        Assert.Near(C.Reactions.ShatterBonus, r.HitMultiplier(HitWeight.Heavy, 1.7), 1e-9, "heavy hit shatters");
        Assert.True(!r.IsFrozen(1.8), "shatter ends the freeze");
        var r2 = new ReactionState(C.Reactions);
        r2.ApplyElement(Element.Ice, 0); r2.ApplyElement(Element.Water, 0);
        Assert.True(!r2.IsFrozen(C.Reactions.FreezeDurationSec + 0.01), "freeze expires after its duration");
    }

    public static void StormPrisonStuns()
    {
        var r = new ReactionState(C.Reactions);
        r.ApplyElement(Element.Water, 0);
        Assert.Equal(Reaction.StormPrison, r.ApplyElement(Element.Lightning, 2), "water + lightning");
        Assert.True(r.IsStunned(2 + C.Reactions.StormPrisonStunSec - 0.01), "stunned for the tuned duration");
        Assert.True(r.CanAct(2 + C.Reactions.StormPrisonStunSec + 0.01), "stun ends");
    }

    // B3 — Poise regenerates after a delay.
    public static void PoiseRegenerates()
    {
        var p = PoiseMeter.For("rig_small_biped", C); // 30 poise, 2.5 s delay, 25%/s
        p.Hit(20);
        p.Tick(2.0);
        Assert.Near(10, p.Current, 1e-9, "no regen during the delay");
        p.Tick(1.0); // 0.5 s past the delay → +3.75
        Assert.Near(13.75, p.Current, 1e-9, "regen after the delay");
        p.Tick(10);
        Assert.Near(30, p.Current, 1e-9, "caps at max");
    }

    // B4 — Decimal loot chances (chase drops) and luck as a multiplier.
    public static void ChaseDropsAndLuckMultiplier()
    {
        var t = new LootTableData { Id = "loot_t", Entries = { new LootEntry { ItemId = "itm_relic", Chance = 0.001, Min = 1, Max = 1 } } };
        int Count(double luck) { var rng = new DeterministicRandom(3); int n = 0; for (int i = 0; i < 200000; i++) n += LootRoller.Roll(t, rng, luck).Count; return n; }
        int normal = Count(1.0), lucky = Count(2.0);
        Assert.True(normal is > 140 and < 260, $"0.1% chase drop (got {normal}/200000)");
        Assert.True(lucky > normal * 1.6 && lucky < normal * 2.4, $"luck x2 roughly doubles it ({normal} → {lucky})");
        var all = Repo.Db.LootTables.Values.SelectMany(l => l.Entries);
        Assert.True(all.All(e => e.Chance > 0 && e.Chance <= 1), "all loot chances in (0, 1]");
        Assert.True(all.Any(e => e.Chance < 0.01), "data contains a chase drop");
    }

    // B5 — Player stats and XP.
    static (DerivedStats player, SpeciesData goblin, DamageCalculator calc) Setup(int level)
    {
        var db = Repo.Db;
        var sw = db.Classes["cls_swordsman"];
        var prim = PlayerStats.Primary(sw, level, db.Progression);
        var gear = new GearBonus { Atk = 8, Def = 3 }; // Guild Issue Sword + Rookie Hood
        return (PlayerStats.Derive(prim, level, db.Progression, gear), db.Species["mon_goblin"], new DamageCalculator(db.Tuning.Damage));
    }

    static int HitsToKill(int attack, double power, int defense, long hp, DamageCalculator calc)
    {
        var rng = new FixedRandom(0.99, 0.5); // no crit, average variance
        int dmg = calc.Compute(new DamageInput { Attack = attack, Defense = defense, Power = power }, rng).Amount;
        return (int)Math.Ceiling(hp / (double)dmg);
    }

    public static void Level1PlayerVsGoblinFeelsRight()
    {
        var (p, g, calc) = Setup(1);
        var lightPower = Repo.Db.Classes["cls_swordsman"].Skill("skl_slash_chain").Hits[0].Power;
        int playerHits = HitsToKill(p.Atk, lightPower, g.Stats.Def, g.EffectiveMaxHp, calc);
        Assert.True(playerHits is >= 3 and <= 5, $"Lv 1 player kills a goblin in 3-5 light hits (got {playerHits})");
        int goblinHits = HitsToKill(g.Stats.Atk, 1.0, p.Def, p.Hp, calc);
        Assert.True(goblinHits is >= 6 and <= 12, $"a goblin needs 6-12 hits to down a Lv 1 player (got {goblinHits}), so a pack is dangerous");
    }

    public static void Level10PlayerFindsGoblinsTrivial()
    {
        var (p, g, calc) = Setup(10);
        var lightPower = Repo.Db.Classes["cls_swordsman"].Skill("skl_slash_chain").Hits[0].Power;
        Assert.True(HitsToKill(p.Atk, lightPower, g.Stats.Def, g.EffectiveMaxHp, calc) <= 2, "Lv 10 kills a goblin in 1-2 hits");
        Assert.True(HitsToKill(g.Stats.Atk, 1.0, p.Def, p.Hp, calc) >= 15, "goblins barely scratch a Lv 10 player");
    }

    public static void XpCurveMatchesGeneratorAndGrows()
    {
        var xp = new XpCurve(Repo.Db.Progression.Xp);
        foreach (var s in Repo.Db.Species.Values)
            Assert.Equal(xp.MonsterXp(s.Level, s.IsUnique), s.Xp, $"{s.Id} xp");
        for (int l = 2; l < Levels.Cap; l++) Assert.True(xp.ToNext(l) > xp.ToNext(l - 1), $"ToNext grows at {l}");
        Assert.True(xp.ToNext(1) is >= 80 and <= 200, $"level 1→2 costs a handful of kills (got {xp.ToNext(1)})");
        Assert.Equal(0L, xp.ToNext(Levels.Cap), "no XP past the cap");
        // Pacing shape: each rank band costs more than the one before it.
        long prev = 0;
        foreach (var letter in new[] { RankLetter.F, RankLetter.E, RankLetter.D, RankLetter.C, RankLetter.B, RankLetter.A, RankLetter.S, RankLetter.SS, RankLetter.SSS })
        {
            var (a, b) = Levels.Band(letter);
            long band = xp.TotalTo(b) - xp.TotalTo(a);
            Assert.True(band > prev, $"{letter} band costs more than the previous band");
            prev = band;
        }
    }

    // B6 — Ring 0 monsters: low levels, a spread, and a distinct rabbit.
    public static void Ring0MonstersFitTheFunTest()
    {
        foreach (var id in new[] { "mon_blue_slime", "mon_goblin", "mon_horned_rabbit" })
        {
            var s = Repo.Db.Species[id];
            Assert.Equal("F-", s.Rank, $"{id} rank");
            Assert.True(s.LevelRange[0] >= 1 && s.LevelRange[1] <= 8 && s.LevelRange[0] < s.LevelRange[1], $"{id} level spread");
        }
        var rabbit = Repo.Db.Species["mon_horned_rabbit"]; var goblin = Repo.Db.Species["mon_goblin"];
        Assert.True(rabbit.Stats.Spd > goblin.Stats.Spd && rabbit.Stats.Hp < goblin.Stats.Hp, "rabbit: faster and more fragile than a goblin");
        Assert.True(rabbit.Stats.Atk >= goblin.Stats.Atk, "rabbit hits at least as hard");
    }

    // B8 — Boss HP lives in an explicit multiplier.
    public static void BossHpIsAnExplicitMultiplier()
    {
        foreach (var s in Repo.Db.Species.Values)
        {
            if (!s.IsUnique) Assert.Near(1, s.BossHpMult, 1e-9, $"{s.Id} normal monsters have no boss multiplier");
            if (s.IsTyrant) Assert.Near(5, s.BossHpMult, 1e-9, $"{s.Id} Tyrant x5");
        }
        long maxSssBase = Repo.Db.Species.Values.Where(s => s.Rank.StartsWith("SSS") && !s.IsUnique).Max(s => (long)s.Stats.Hp);
        Assert.True(Repo.Db.Species["mon_taurgrim_the_maze_king"].Stats.Hp < maxSssBase, "Taurgrim's base HP is below SSS species; the boss part is the multiplier");
    }

    // B9 — Families fight differently even on the same rig.
    public static void FamiliesHaveSignatureAttacks()
    {
        var early = Repo.Db.Species.Values.Where(s => s.Ring <= 2 && s.Tier == "core").ToList();
        foreach (var rig in early.GroupBy(s => s.RigId))
        {
            foreach (var fam in rig.Select(s => s.FamilyKey).Distinct())
            {
                var mine = rig.First(s => s.FamilyKey == fam).AttackIds;
                var others = rig.Where(s => s.FamilyKey != fam).SelectMany(s => s.AttackIds).ToHashSet();
                Assert.True(mine.Any(a => !others.Contains(a)), $"{fam} on {rig.Key} has an attack no other family on that rig has");
            }
        }
    }

    // B7 — Quest prerequisites, region state and NPC story states.
    public static void QuestGateRespectsSiegeStateAndPrerequisites()
    {
        var q = Repo.Db.Quests;
        var ctx = new QuestContext { Level = 15, Rank = RankLetter.E, Act = 1, RegionState = RegionState.Besieged };
        Assert.True(QuestGate.IsAvailable(q["qst_siege_whisperwood_defence"], ctx), "defence while besieged");
        Assert.True(!QuestGate.IsAvailable(q["qst_hunt_whisperwood_contract"], ctx), "no hunting contract while besieged");
        ctx.RegionState = RegionState.Liberated;
        Assert.True(!QuestGate.IsAvailable(q["qst_siege_whisperwood_defence"], ctx), "no defence after liberation");
        Assert.True(QuestGate.IsAvailable(q["qst_hunt_whisperwood_contract"], ctx), "hunting contract after liberation");

        var stew = q["qst_main_bowl_of_stew"];
        var fresh = new QuestContext { Act = 1 };
        Assert.True(!QuestGate.IsAvailable(stew, fresh), "needs the Wooden Card first");
        fresh.CompletedQuests.Add("qst_main_wooden_card");
        Assert.True(!QuestGate.IsAvailable(stew, fresh), "and the guild_registered flag");
        fresh.Flags.Add("guild_registered");
        Assert.True(QuestGate.IsAvailable(stew, fresh), "available once both are met");
        fresh.Act = 0;
        Assert.True(!QuestGate.IsAvailable(stew, fresh), "act requirement");
    }

    public static void NpcStatesAndSchedules()
    {
        var mina = Repo.Db.Npcs["npc_mina_feathersby"];
        Assert.True(mina.CurrentState(new HashSet<string>()) == null, "default Mina before Act III");
        Assert.True(mina.CurrentState(new HashSet<string> { "act3_nocturne_replaces_mina" }).Role.Contains("Nocturne"), "Nocturne from Act III");
        Assert.True(mina.CurrentState(new HashSet<string> { "act3_nocturne_replaces_mina", "nocturne_unmasked" }).Role == "Guild receptionist", "real Mina returns");
        Assert.True(mina.WhereAt("morning").Contains("Oaken Card"), "Mina works mornings at the guild");
        var caspian = Repo.Db.Npcs["npc_brother_caspian"];
        Assert.True(caspian.WhereAt("day", "Morrowsday") == null, "Caspian's market trips skip Morrowsday");
        Assert.True(caspian.WhereAt("day", "Vexday").Contains("Market"), "Caspian at the market on Vexday");
    }
}
