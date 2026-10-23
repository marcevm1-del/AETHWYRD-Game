using System.Text.Json;
using Ascend.Core;

/// <summary>
/// MonsterMotionLaws (C#, used at runtime) must give the same numbers as Data/Monsters/motion.json,
/// which Tools/monster_gen/motion.js writes. Run `npm run motion` after changing either side.
/// </summary>
[Tests]
static class MonsterMotionTests
{
    static readonly string[] Ranks = { "F", "E", "D", "C", "B", "A", "S", "SS", "SSS", "EX" };

    static int RankIndex(string r) => Math.Max(0, Array.IndexOf(Ranks, (r ?? "").TrimEnd('+', '-')));

    static JsonDocument Json(string rel) => JsonDocument.Parse(File.ReadAllText(Path.Combine(Repo.Root(), rel)));

    public static void LawsMatchTheGeneratedMotionData()
    {
        using var motion = Json("Data/Monsters/motion.json");
        using var rigsDoc = Json("Data/Monsters/rigs.json");
        using var speciesDoc = Json("Data/Monsters/species.json");
        using var tuning = Json("Data/Combat/combat_tuning.json");
        double parry = tuning.RootElement.GetProperty("parry").GetProperty("parryWindowSec").GetDouble();
        var rigs = rigsDoc.RootElement.GetProperty("rigs").EnumerateArray().ToDictionary(r => r.GetProperty("key").GetString());
        var species = speciesDoc.RootElement.EnumerateArray().ToDictionary(s => s.GetProperty("id").GetString());

        var bad = new List<string>();
        int n = 0, massChecked = 0;
        void Check(string id, string what, double expected, double actual, double tol)
        {
            if (Math.Abs(expected - actual) > tol) bad.Add($"{id} {what}: motion.json {actual}, C# {expected:0.####}");
        }
        foreach (var p in motion.RootElement.GetProperty("species").EnumerateArray())
        {
            string id = p.GetProperty("speciesId").GetString();
            var sp = species[id];
            var rig = rigs[p.GetProperty("rigKey").GetString()];
            double size = sp.TryGetProperty("sizeMeters", out var sz) && sz.ValueKind == JsonValueKind.Number && sz.GetDouble() > 0
                ? sz.GetDouble() : p.GetProperty("sizeMeters").GetDouble();
            int ri = RankIndex(sp.TryGetProperty("rank", out var rk) && rk.ValueKind == JsonValueKind.String ? rk.GetString() : "F");
            var loco = p.GetProperty("locomotion");
            var timing = p.GetProperty("timing");
            var physics = p.GetProperty("physics");

            Check(id, "playRate", MonsterMotionLaws.PlayRate(rig.GetProperty("refSize").GetDouble(), size), loco.GetProperty("playRate").GetDouble(), 0.0006);
            Check(id, "turnDegPerSec", MonsterMotionLaws.TurnDegPerSec(rig.GetProperty("locomotion").GetProperty("turnDegPerSecAt1m").GetDouble(), size),
                  loco.GetProperty("turnDegPerSec").GetDouble(), 0.51);
            Check(id, "minTelegraphSec", MonsterMotionLaws.MinTelegraphSec(ri, parry), timing.GetProperty("minTelegraphSec").GetDouble(), 0.0051);
            Check(id, "minRecoverySec", MonsterMotionLaws.MinRecoverySec(ri), timing.GetProperty("minRecoverySec").GetDouble(), 0.0051);
            Check(id, "sizeTimeMult", MonsterMotionLaws.SizeTime(size), timing.GetProperty("sizeTimeMult").GetDouble(), 0.0006);
            Check(id, "rankFactor", MonsterMotionLaws.RankFactor(ri), timing.GetProperty("rankFactor").GetDouble(), 0.0006);
            Check(id, "vocalPitch", MonsterMotionLaws.VocalPitch(size), p.GetProperty("audio").GetProperty("vocalPitch").GetDouble(), 0.0051);
            Check(id, "hitstopMult", MonsterMotionLaws.HitstopMult(physics.GetProperty("massKg").GetDouble()), physics.GetProperty("hitstopMult").GetDouble(), 0.011);
            // mass has element and hand-tuned multipliers; compare where both are 1 (element None, no motion override)
            if (p.GetProperty("element").GetProperty("name").GetString() == "None" && !p.GetProperty("rigVia").GetString().StartsWith("override"))
            {
                var ph = rig.GetProperty("physics");
                double mass = MonsterMotionLaws.MassKg(ph.GetProperty("shapeK").GetDouble(), ph.GetProperty("density").GetDouble(), size);
                Check(id, "massKg", mass, physics.GetProperty("massKg").GetDouble(), 0.051);
                massChecked++;
            }
            n++;
        }
        Assert.True(n == motion.RootElement.GetProperty("count").GetInt32() && n > 600, $"expected every species in motion.json, read {n}");
        Assert.True(massChecked >= 20, $"only {massChecked} species had a mass without multipliers");
        Assert.True(bad.Count == 0, $"{bad.Count} value(s) differ, e.g. " + string.Join("; ", bad.Take(5)));
    }

    public static void WindupNeverBeatsTheFairnessFloor()
    {
        for (int ri = 0; ri < Ranks.Length; ri++)
            foreach (double size in new[] { 0.2, 0.5, 1.7, 5, 20, 200 })
            {
                double w = MonsterMotionLaws.WindupSec(0.05, size, ri, menaceMult: 0.5, elementMult: 0.5, telegraphMult: 0.5);
                Assert.True(w >= MonsterMotionLaws.MinTelegraphSec(ri) - 1e-12, $"rank {Ranks[ri]} size {size}: windup {w} below the floor");
            }
    }

    public static void BiggerCreaturesAreHeavierAndSlowerToTurn()
    {
        Assert.Near(8.0, MonsterMotionLaws.MassKg(1, 1, 2) / MonsterMotionLaws.MassKg(1, 1, 1), 1e-9, "mass ∝ size³");
        Assert.True(MonsterMotionLaws.TurnDegPerSec(600, 10) < MonsterMotionLaws.TurnDegPerSec(600, 1), "turn rate falls with size");
        Assert.Near(Math.Sqrt(0.5 * 9.81 * 0.5 * 2), MonsterMotionLaws.GaitSpeed(0.5, 0.5, 2), 1e-9, "Froude speed");
    }
}
