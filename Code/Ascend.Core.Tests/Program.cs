using System.Reflection;
using System.Text.Json;
using Ascend.Core;

BalanceReport.PrintIfAsked();

// Minimal test harness: every public static void method in a class marked [Tests] is a test.
var failures = new List<string>();
int passed = 0;
foreach (var type in typeof(TestsAttribute).Assembly.GetTypes().Where(t => t.GetCustomAttribute<TestsAttribute>() != null))
{
    foreach (var m in type.GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.GetParameters().Length == 0 && m.ReturnType == typeof(void)))
    {
        try { m.Invoke(null, null); passed++; }
        catch (TargetInvocationException e) { failures.Add($"{type.Name}.{m.Name}: {e.InnerException?.Message}"); }
    }
}
foreach (var f in failures) Console.WriteLine("  ✗ " + f);
Console.WriteLine(failures.Count == 0 ? $"✓ {passed} tests passed" : $"✗ {failures.Count} failed, {passed} passed");
return failures.Count == 0 ? 0 : 1;

[AttributeUsage(AttributeTargets.Class)] sealed class TestsAttribute : Attribute { }

static class Assert
{
    public static void True(bool c, string msg) { if (!c) throw new Exception(msg); }
    public static void Equal<T>(T expected, T actual, string what = "") { if (!EqualityComparer<T>.Default.Equals(expected, actual)) throw new Exception($"{what} expected <{expected}> but got <{actual}>"); }
    public static void Near(double expected, double actual, double tol, string what = "") { if (Math.Abs(expected - actual) > tol) throw new Exception($"{what} expected ~{expected} but got {actual}"); }
    public static void Throws<TE>(Action a, string what) where TE : Exception
    {
        try { a(); } catch (TE) { return; }
        throw new Exception($"{what}: expected {typeof(TE).Name}");
    }
}

/// <summary>Returns a fixed sequence of values (cycles), for deterministic tests.</summary>
sealed class FixedRandom : IRandom
{
    readonly double[] _v; int _i;
    public FixedRandom(params double[] v) { _v = v; }
    public double NextDouble() => _v[_i++ % _v.Length];
}

static class Repo
{
    static readonly JsonSerializerOptions Opts = new() { PropertyNameCaseInsensitive = true };
    public static string Root()
    {
        var d = new DirectoryInfo(AppContext.BaseDirectory);
        while (d != null && !Directory.Exists(Path.Combine(d.FullName, "Data", "Monsters"))) d = d.Parent;
        return d?.FullName ?? throw new Exception("Could not find the repo root (Data/Monsters)");
    }
    public static T Load<T>(string rel) => JsonSerializer.Deserialize<T>(File.ReadAllText(Path.Combine(Root(), rel)), Opts);
    static GameDatabase _db;
    public static GameDatabase Db => _db ??= new GameDatabase(
        Load<List<RegionData>>("Data/World/regions.json"),
        Load<List<SpeciesData>>("Data/Monsters/species.json"),
        Load<List<AttackData>>("Data/Monsters/attacks.json"),
        Load<List<LootTableData>>("Data/Monsters/loot_tables.json"),
        Load<List<ItemData>>("Data/Items/materials.json").Concat(Load<List<ItemData>>("Data/Items/items.json")),
        Load<CombatTuning>("Data/Combat/combat_tuning.json"),
        Load<List<SiegeWaveData>>("Data/World/siege_waves.json"),
        Load<WorldTuning>("Data/World/world_tuning.json"),
        Load<List<QuestData>>("Data/Quests/quests.json"),
        Load<List<NpcData>>("Data/NPCs/npcs.json"),
        Load<List<ClassData>>("Data/Classes/classes.json"),
        Load<List<StoryFlagData>>("Data/Quests/story_flags.json"),
        Load<ProgressionRules>("Data/Classes/progression.json"));
}

[Tests]
static class RankTests
{
    public static void ParsesAndFormats()
    {
        foreach (var s in new[] { "F", "E-", "C+", "SS", "SSS-", "EX" }) Assert.Equal(s, Rank.Parse(s).ToString(), "round-trip");
        Assert.True(Rank.Parse("SSS") > Rank.Parse("SS+"), "SSS > SS+");
        Assert.True(Rank.Parse("C+") < Rank.Parse("B-"), "C+ < B-");
    }
    public static void RejectsGarbage()
    {
        foreach (var s in new[] { "", "Q", "3", "S++", "s" }) Assert.True(!Rank.TryParse(s, out _), $"\"{s}\" should not parse");
    }
    public static void ShiftClamps()
    {
        Assert.Equal("D", Rank.Parse("E").Shift(3).ToString(), "E+3");
        Assert.Equal("F-", Rank.Parse("F").Shift(-10).ToString(), "clamp low");
        Assert.Equal("EX+", Rank.Parse("SSS").Shift(50).ToString(), "clamp high");
    }
    public static void LevelBands()
    {
        Assert.Equal(8, Levels.For(Rank.Parse("F")), "F level");
        Assert.Equal(300, Levels.For(Rank.Parse("EX")), "EX level");
        Assert.Equal(RankLetter.C, Levels.BandOf(75), "level 75 band");
        Assert.Equal(RankLetter.SSS, Levels.BandOf(300), "level 300 band");
    }
}

[Tests]
static class ElementTests
{
    public static void Reactions()
    {
        Assert.Equal(Reaction.Firestorm, Elements.React(Element.Fire, Element.Wind), "fire+wind");
        Assert.Equal(Reaction.Firestorm, Elements.React(Element.Wind, Element.Fire), "wind+fire");
        Assert.Equal(Reaction.Freeze, Elements.React(Element.Water, Element.Ice), "water+ice");
        Assert.Equal(Reaction.Swirl, Elements.React(Element.Water, Element.Wind), "water+wind swirls");
        Assert.Equal(Reaction.None, Elements.React(Element.Fire, Element.Water), "fire+water has no reaction");
        Assert.Equal(Reaction.None, Elements.React(Element.Fire, Element.Fire), "same element");
    }
    public static void AuraLifecycle()
    {
        var a = new AuraState(6);
        Assert.Equal(Reaction.None, a.Apply(Element.Fire, 0), "first hit applies aura");
        Assert.Equal(Element.Fire, a.Current(5.9), "aura still up");
        Assert.Equal(Reaction.Firestorm, a.Apply(Element.Wind, 1), "wind triggers firestorm");
        Assert.Equal(Element.None, a.Current(1), "reaction consumes aura");
        a.Apply(Element.Ice, 10);
        Assert.Equal(Element.None, a.Current(16.1), "aura expires");
        a.Apply(Element.Water, 20);
        Assert.Equal(Reaction.Swirl, a.Apply(Element.Wind, 21), "swirl");
        Assert.Equal(Element.Water, a.Current(21), "swirl keeps the spread element");
    }
}

[Tests]
static class DamageTests
{
    static DamageCalculator Calc => new(Repo.Db.Tuning.Damage);
    // FixedRandom order: crit roll, then variance roll. 0.99 = no crit (chance 0); 0.5 = variance 1.0.
    public static void BaseFormula()
    {
        var r = Calc.Compute(new DamageInput { Attack = 100, Defense = 100, Power = 1 }, new FixedRandom(0.99, 0.5));
        Assert.Equal(50, r.Amount, "100 atk vs 100 def");
    }
    public static void Weakness()
    {
        var r = Calc.Compute(new DamageInput { Attack = 100, Defense = 100, Power = 1, AttackElement = Element.Fire, DefenderWeakness = Element.Fire }, new FixedRandom(0.99, 0.5));
        Assert.Equal(75, r.Amount, "weakness x1.5");
    }
    public static void CritAndStealth()
    {
        var r = Calc.Compute(new DamageInput { Attack = 100, Defense = 0, Power = 1, CritChance = 1, Stealth = true }, new FixedRandom(0.0, 0.5));
        Assert.True(r.Crit, "crit");
        Assert.Equal(300, r.Amount, "100 x1.5 crit x2 stealth");
    }
    public static void MinimumOne()
    {
        var r = Calc.Compute(new DamageInput { Attack = 1, Defense = 100000, Power = 0.1 }, new FixedRandom(0.99, 0.0));
        Assert.Equal(1, r.Amount, "chip damage floors at 1");
    }
}

[Tests]
static class StyleTests
{
    static StyleMeter New() => new(Repo.Db.Tuning.Style);
    public static void VarietyBeatsSpam()
    {
        var varied = New(); var spam = New();
        string[] moves = { "l1", "l2", "l3", "l4", "rising_cut", "air_l1", "slam", "flash_step" };
        for (int i = 0; i < 8; i++) { varied.RegisterHit(moves[i], HitWeight.Medium); spam.RegisterHit("l1", HitWeight.Medium); }
        Assert.True(varied.Points > spam.Points * 1.5, $"varied {varied.Points} should beat spam {spam.Points}");
    }
    public static void ReachesSWithSkill()
    {
        var m = New();
        m.RegisterEvent(StyleEvent.PerfectDodge); m.RegisterEvent(StyleEvent.Parry); m.RegisterEvent(StyleEvent.Reaction);
        foreach (var mv in new[] { "l1", "l2", "launcher", "air_l1", "air_l2", "slam", "rising_cut", "air_slash", "flash_step", "l4" }) m.RegisterHit(mv, HitWeight.Heavy);
        m.RegisterEvent(StyleEvent.LaunchToSlam);
        Assert.True(m.Rank >= StyleRank.S, $"expected S or better, got {m.Rank} ({m.Points})");
    }
    public static void HitDropsOneRank()
    {
        var m = New();
        while (m.Rank < StyleRank.A) m.RegisterEvent(StyleEvent.Parry);
        var before = m.Rank;
        m.RegisterPlayerHit();
        Assert.Equal(before - 1, m.Rank, "one rank down");
    }
    public static void DecaysWhenIdle()
    {
        var m = New();
        m.RegisterEvent(StyleEvent.Parry);
        m.Tick(1.0);
        Assert.Near(60, m.Points, 0.001, "no decay inside the delay");
        m.Tick(2.0); // 1 s past the 2 s delay → -20
        Assert.Near(40, m.Points, 0.001, "decay after delay");
    }
}

[Tests]
static class LootAndCombatTests
{
    public static void LootWeights()
    {
        var t = new LootTableData { Id = "loot_t", Entries = { new LootEntry { ItemId = "itm_a", Chance = 1.0, Min = 1, Max = 1 }, new LootEntry { ItemId = "itm_b", Chance = 0.01, Min = 1, Max = 3 } } };
        var rng = new SystemRandom(7);
        int b = 0;
        for (int i = 0; i < 2000; i++)
        {
            var d = LootRoller.Roll(t, rng);
            Assert.True(d.Any(x => x.ItemId == "itm_a"), "chance 1.0 always drops");
            foreach (var x in d.Where(x => x.ItemId == "itm_b")) { b++; Assert.True(x.Count is >= 1 and <= 3, "count range"); }
        }
        Assert.True(b is > 5 and < 60, $"chance 0.01 drops ~1% (got {b}/2000)");
    }
    public static void PoiseStaggers()
    {
        var p = new PoiseMeter(30);
        Assert.True(!p.Hit(20), "no stagger yet");
        Assert.True(p.Hit(15), "stagger at 0");
        Assert.Near(30, p.Current, 0.001, "refills");
    }
    public static void AggroTokensCapAttackers()
    {
        var a = new AggroTokens(Repo.Db.Tuning.Ai.MaxSimultaneousAttackers);
        Assert.True(a.TryTake("g1") && a.TryTake("g2"), "two attackers allowed");
        Assert.True(!a.TryTake("g3"), "third waits");
        a.Release("g1");
        Assert.True(a.TryTake("g3"), "token freed");
    }
}

[Tests]
static class DataTests
{
    public static void DatabaseLoads()
    {
        var db = Repo.Db;
        Assert.True(db.Species.Count >= 600, $"species count {db.Species.Count}");
        Assert.True(db.Regions.Count >= 40, $"region count {db.Regions.Count}");
    }
    public static void SpeciesLevelsMatchRankRules()
    {
        var bad = Repo.Db.Species.Values.Where(s => Levels.For(s.ParsedRank) != s.Level).Select(s => $"{s.Id} {s.Rank}→{s.Level}").ToList();
        Assert.True(bad.Count == 0, "level mismatch between generator and C#: " + string.Join(", ", bad.Take(5)));
    }
    public static void ReferencesResolve()
    {
        var db = Repo.Db;
        foreach (var s in db.Species.Values)
        {
            Assert.True(db.LootTables.ContainsKey(s.LootTableId), $"{s.Id} loot");
            foreach (var a in s.AttackIds) Assert.True(db.Attacks.ContainsKey(a), $"{s.Id} attack {a}");
            foreach (var h in s.Habitats) Assert.True(db.Regions.ContainsKey(h), $"{s.Id} habitat {h}");
        }
        foreach (var l in db.LootTables.Values) foreach (var e in l.Entries) Assert.True(db.Items.ContainsKey(e.ItemId), $"{l.Id} item {e.ItemId}");
    }
    public static void Ring0Roster()
    {
        var names = Repo.Db.SpeciesInRing(0).Select(s => s.Name).OrderBy(n => n).ToArray();
        Assert.Equal("Blue Slime, Goblin, Horned Rabbit", string.Join(", ", names), "Ring 0 species");
    }
    public static void TuningIsSane()
    {
        var t = Repo.Db.Tuning;
        Assert.True(t.Dodge.IframeSec < t.Dodge.DurationSec, "i-frames shorter than the dodge");
        Assert.True(t.Hitstop.Light < t.Hitstop.Heavy && t.Hitstop.Heavy < t.Hitstop.Ultimate, "hit-stop grows with weight");
        Assert.Equal(1000, t.Style.Thresholds["SSS"], "SSS threshold");
    }
}
