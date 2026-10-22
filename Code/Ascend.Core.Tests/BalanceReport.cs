using Ascend.Core;

// Not a test: prints Ring 0 balance numbers when run with ASCEND_REPORT=1.
static class BalanceReport
{
    public static void PrintIfAsked()
    {
        if (Environment.GetEnvironmentVariable("ASCEND_REPORT") != "1") return;
        var db = Repo.Db; var calc = new DamageCalculator(db.Tuning.Damage); var sw = db.Classes["cls_swordsman"];
        foreach (int lv in new[] { 1, 5, 10 })
        {
            var p = PlayerStats.Derive(PlayerStats.Primary(sw, lv, db.Progression), lv, db.Progression, new GearBonus { Atk = 8, Def = 3 });
            Console.WriteLine($"Lv {lv}: HP {p.Hp} ATK {p.Atk} DEF {p.Def}");
            foreach (var id in new[] { "mon_blue_slime", "mon_goblin", "mon_horned_rabbit" })
            {
                var m = db.Species[id];
                int you = calc.Compute(new DamageInput { Attack = p.Atk, Defense = m.Stats.Def, Power = 0.8 }, new FixedRandom(0.99, 0.5)).Amount;
                int them = calc.Compute(new DamageInput { Attack = m.Stats.Atk, Defense = p.Def, Power = 1.0 }, new FixedRandom(0.99, 0.5)).Amount;
                Console.WriteLine($"  vs {m.Name,-14} you: {Math.Ceiling(m.Stats.Hp / (double)you)} hits · it: {Math.Ceiling(p.Hp / (double)them)} hits");
            }
        }
        var xp = new XpCurve(db.Progression.Xp);
        Console.WriteLine($"XP to next: Lv1 {xp.ToNext(1)}, Lv10 {xp.ToNext(10)}, Lv100 {xp.ToNext(100)}, Lv299 {xp.ToNext(299)}; total to 300: {xp.TotalTo(300):N0}");
    }
}
