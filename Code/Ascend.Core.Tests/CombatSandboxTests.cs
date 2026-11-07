using System.Linq;
using System.Text;
using Ascend.Core;

// The combat sandbox (CombatSandbox.cs): dummies, scripted hits, a clock, a readout. Deterministic.
[Tests]
static class CombatSandboxTests
{
    const string Grukk = "mon_grukk_goblin_chief_of_hollowpine";

    // Crit roll 0.99 (no crit at chance 0), variance roll 0.5: the same variance every hit.
    static CombatSandbox Sandbox(bool useData = true) =>
        new CombatSandbox(Repo.Db.Tuning, new FixedRandom(0.99, 0.5), useData ? Repo.Db.ReactionTable : null, useData ? Repo.Db.BossWeakPoints : null);

    static SandboxDummySpec Dummy(string id = "d1", int hp = 100000, string species = "mon_goblin") =>
        new SandboxDummySpec { Id = id, SpeciesId = species, Hp = hp, Element = Element.None, Weakness = Element.None };

    static SandboxHit H(Element e, HitWeight w = HitWeight.Light, double wait = 0, string part = null, string target = "d1", double power = 1.0, double attack = 100) =>
        new SandboxHit { TargetId = target, Element = e, Weight = w, WaitSec = wait, BodyPart = part, Power = power, Attack = attack };

    static string Describe(SandboxReadout r)
    {
        var sb = new StringBuilder();
        foreach (var h in r.Hits)
            sb.Append(System.FormattableString.Invariant($"t={h.Time:0.00} {h.TargetId} dmg={h.Damage} hp={h.HpAfter} {h.Reaction} syn={h.SynergyId ?? "-"} x{h.TotalExtraMult:0.####} armor={h.ArmorAfter:0.##}{(h.ArmorBrokeNow ? " BREAK" : "")}\n"));
        foreach (var d in r.Dummies)
            sb.Append(System.FormattableString.Invariant($"{d.Id} hp={d.Hp}/{d.MaxHp} aura={d.Aura} frozen={d.Frozen} stunned={d.Stunned} armor={d.Armor:0.##} broken={d.ArmorBroken} phase={d.Phase ?? "-"}\n"));
        return sb.ToString();
    }

    static SandboxReadout FireIceScript(CombatSandbox sb)
    {
        sb.AddDummy(Dummy());
        return sb.Run(new[] {
            H(Element.Fire),                                  // aura: Fire
            H(Element.Ice, wait: 0.5),                        // Fire + Ice: ThermalShock
            H(Element.Water, wait: 0.5),                      // aura: Water
            H(Element.Ice, wait: 0.5),                        // Water + Ice: Freeze
            H(Element.None, HitWeight.Heavy, wait: 0.5),      // heavy on a frozen target: Shatter
            H(Element.None, HitWeight.Heavy, wait: 0.5),      // frozen no more: plain heavy
        });
    }

    // ------------------------------------------------------------------ stable, asserted readout
    public static void ScriptedFightGivesAStableAssertedReadout()
    {
        var r = FireIceScript(Sandbox());
        Assert.Equal(6, r.Hits.Count, "six scripted hits");
        Assert.Equal("None,ThermalShock,None,Freeze,None,None", string.Join(",", r.Hits.Select(h => h.Reaction)), "reaction per hit");
        Assert.Near(0.0, r.Hits[0].Time, 1e-9, "t0"); Assert.Near(0.5, r.Hits[1].Time, 1e-9, "t1"); Assert.Near(2.5, r.Hits[5].Time, 1e-9, "t5");
        Assert.Near(2.5, r.Time, 1e-9, "clock after the script");

        var tuning = Repo.Db.Tuning;
        double plain = r.Hits[0].Damage;     // 100 attack, no multipliers
        Assert.True(plain > 0, "plain light hit does damage");
        Assert.Near(Repo.Db.ReactionTable.Get(Reaction.ThermalShock).BonusDamageMult, r.Hits[1].ReactionMult, 1e-9, "thermal shock multiplier from the data");
        Assert.Near(r.Hits[1].ReactionMult * plain, r.Hits[1].Damage, 1.0, "thermal shock damage = plain x multiplier");
        Assert.Near(1.0, r.Hits[3].ReactionMult, 1e-9, "freeze has no damage bonus");
        double heavy = r.Hits[5].Damage;
        Assert.Near(tuning.Reactions.ShatterBonus, r.Hits[4].ShatterMult, 1e-9, "heavy on the frozen target shatters");
        Assert.Near(1.0, r.Hits[5].ShatterMult, 1e-9, "the shatter ended the freeze");
        Assert.Near(heavy * tuning.Reactions.ShatterBonus, r.Hits[4].Damage, 1.0, "shatter damage = heavy x ShatterBonus");

        Assert.Equal(100000 - r.Hits.Sum(h => h.Damage), r.Dummies[0].Hp, "dummy HP is the sum of the hits");
        Assert.Equal(Element.None, r.Dummies[0].Aura, "no aura left (the freeze consumed it)");
        Assert.True(!r.Dummies[0].Frozen, "not frozen any more");
    }

    public static void TheSameScriptTwiceGivesTheIdenticalReadout()
    {
        var a = Describe(FireIceScript(Sandbox()));
        var b = Describe(FireIceScript(Sandbox()));
        Assert.Equal(a, b, "deterministic readout");
        Assert.True(a.Contains("ThermalShock") && a.Contains("Freeze"), "readout names the reactions");
        var c = FireIceScript(new CombatSandbox(Repo.Db.Tuning, new DeterministicRandom(99), Repo.Db.ReactionTable, Repo.Db.BossWeakPoints));
        var d = FireIceScript(new CombatSandbox(Repo.Db.Tuning, new DeterministicRandom(99), Repo.Db.ReactionTable, Repo.Db.BossWeakPoints));
        Assert.Equal(Describe(c), Describe(d), "same seed, same fight");
    }

    public static void ThePinnedReadoutOfTheFireIceScript()
    {
        // Attack 100, no defense, variance fixed: 100 per plain hit. Update deliberately if damage tuning changes.
        var r = FireIceScript(Sandbox());
        Assert.Equal("100,200,100,100,180,100", string.Join(",", r.Hits.Select(h => h.Damage)), "damage per hit");
        Assert.Equal("99900,99700,99600,99500,99320,99220", string.Join(",", r.Hits.Select(h => h.HpAfter)), "HP after each hit");
        Assert.Equal(99220, r.Dummies[0].Hp, "final HP");
    }

    // ------------------------------------------------------------------ data-driven table versus the default table
    public static void FireThenIceReadsOutThermalShockWithTheTablesBonus()
    {
        var withData = Sandbox(useData: true); withData.AddDummy(Dummy());
        var r = withData.Run(new[] { H(Element.Fire), H(Element.Ice, wait: 0.5) });
        Assert.Equal(Reaction.None, r.Hits[0].Reaction, "fire only sets the aura");
        Assert.Equal(Reaction.ThermalShock, r.Hits[1].Reaction, "then ice: thermal shock");
        Assert.Near(2.0, r.Hits[1].ReactionMult, 1e-9, "reactions.json proposes x2.0");
        Assert.True(r.Hits[1].Damage > r.Hits[0].Damage * 1.9, "about double the plain hit");

        var plainTable = Sandbox(useData: false); plainTable.AddDummy(Dummy());
        var p = plainTable.Run(new[] { H(Element.Fire), H(Element.Ice, wait: 0.5) });
        Assert.Equal(Reaction.ThermalShock, p.Hits[1].Reaction, "the default table reacts the same");
        Assert.Near(1.0, p.Hits[1].ReactionMult, 1e-9, "but adds no bonus (today's behaviour)");
        Assert.Equal(p.Hits[0].Damage, p.Hits[1].Damage, "so damage is the plain hit");
    }

    public static void ASynergyShowsUpInTheReadoutInsideItsWindowOnly()
    {
        var syn = Repo.Db.ReactionTable.Synergies.Single(s => s.Id == "thaw_burst");
        SandboxReadout Run(double gap)
        {
            var sb = Sandbox(); sb.AddDummy(Dummy());
            return sb.Run(new[] {
                H(Element.Water), H(Element.Ice, wait: 0.1),     // Freeze
                H(Element.Fire, wait: 0.1),                      // fire aura
                H(Element.Ice, wait: gap) });                    // ThermalShock
        }
        var inWindow = Run(syn.WindowSec - 0.5);
        Assert.Equal(Reaction.ThermalShock, inWindow.Hits[3].Reaction, "thermal shock");
        Assert.Equal("thaw_burst", inWindow.Hits[3].SynergyId, "synergy named in the readout");
        Assert.Near(syn.BonusDamageMult, inWindow.Hits[3].SynergyMult, 1e-9, "synergy multiplier");
        Assert.Near(inWindow.Hits[3].ReactionMult * syn.BonusDamageMult, inWindow.Hits[3].TotalExtraMult, 1e-9, "total multiplier stacks");
        var outside = Run(syn.WindowSec + 0.5);
        Assert.Equal(Reaction.ThermalShock, outside.Hits[3].Reaction, "still a thermal shock");
        Assert.True(outside.Hits[3].SynergyId == null, "no synergy outside the window");
        Assert.Near(1.0, outside.Hits[3].SynergyMult, 1e-9, "neutral");
    }

    public static void StatusesAppearInTheDummyReadoutAndExpireWithTheClock()
    {
        var t = Repo.Db.Tuning.Reactions;
        var sb = Sandbox(); sb.AddDummy(Dummy());
        sb.Run(new[] { H(Element.Water), H(Element.Lightning, wait: 0.1) });
        Assert.True(sb.Readout().Dummies[0].Stunned, "storm prison stuns");
        sb.Advance(t.StormPrisonStunSec + 0.1);
        Assert.True(!sb.Readout().Dummies[0].Stunned, "stun is over after the tuned time");

        var f = Sandbox(); f.AddDummy(Dummy());
        f.Run(new[] { H(Element.Water), H(Element.Ice, wait: 0.1) });
        Assert.True(f.Readout().Dummies[0].Frozen, "freeze holds");
        f.Advance(t.FreezeDurationSec - 0.2);
        Assert.True(f.Readout().Dummies[0].Frozen, "still frozen inside the tuned time");
        f.Advance(0.4);
        Assert.True(!f.Readout().Dummies[0].Frozen, "thawed after the tuned time");
    }

    // ------------------------------------------------------------------ dummies
    public static void ManyDummiesAreIndependentAndDeadOnesStayDead()
    {
        var sb = Sandbox();
        sb.AddDummy(Dummy("w", hp: 150), 3);
        var r = sb.Run(new[] { H(Element.Fire, target: "w_1"), H(Element.None, HitWeight.Heavy, target: "w_2", power: 3) });
        Assert.Equal(3, r.Dummies.Count, "three dummies");
        Assert.Equal("w_1,w_2,w_3", string.Join(",", r.Dummies.Select(d => d.Id)), "ids");
        Assert.Equal(Element.Fire, r.Dummies[0].Aura, "w_1 has the aura");
        Assert.Equal(Element.None, r.Dummies[1].Aura, "w_2 does not");
        Assert.Equal(150, r.Dummies[2].Hp, "w_3 untouched");
        Assert.True(r.Hits[1].Killed && r.Dummies[1].Hp == 0, "w_2 dies, HP floors at 0");
        Assert.Throws<System.InvalidOperationException>(() => sb.Hit(H(Element.Fire, target: "nobody")), "unknown target");
        Assert.Throws<System.InvalidOperationException>(() => sb.AddDummy(Dummy("w"), 3), "duplicate ids");
    }

    // ------------------------------------------------------------------ Grukk: weak points, armor, phases
    static CombatSandbox GrukkSandbox(int hp)
    {
        var sb = Sandbox();
        sb.AddDummy(new SandboxDummySpec { Id = "g", SpeciesId = Grukk, Hp = hp, Weakness = Element.None, Phases = Repo.Db.Bosses[Grukk] });
        return sb;
    }

    public static void GrukksWeakPointMultiplierShowsOnlyInTheExposedPhases()
    {
        var sb = GrukkSandbox(1000);
        var wp = Repo.Db.BossWeakPoints.Bosses.Single(b => b.SpeciesId == Grukk).WeakPoints[0];
        SandboxHit Chest() => H(Element.None, part: wp.BodyPart, target: "g", power: 0.01);        // 1 damage: keeps HP where the script puts it
        SandboxHit Big(double power) => H(Element.None, HitWeight.Heavy, part: "left_leg", target: "g", power: power);   // 100 x power
        var r = sb.Run(new[] {
            Chest(),            // [0] Duel: not exposed
            Big(4),             // [1] still Duel when evaluated; HP 1000 -> ~600 (below 66%)
            Chest(),            // [2] Archers: exposed
            Big(3),             // [3] HP ~600 -> ~300 (below 33%)
            Chest(),            // [4] Rage: exposed
            Big(0.01),          // [5] a different part in Rage: not a weak point
        });
        Assert.Equal("Duel", r.Hits[0].Phase, "starts in the Duel");
        Assert.Near(1.0, r.Hits[0].WeakPointMult, 1e-9, "Duel: the brand is hidden");
        Assert.True(r.Hits[0].WeakPointId == null, "no weak point id in the Duel");
        Assert.Equal("Archers", r.Hits[2].Phase, "second phase after HP falls under 66%");
        Assert.Near(wp.DamageMult, r.Hits[2].WeakPointMult, 1e-9, "Archers: exposed");
        Assert.Equal(wp.Id, r.Hits[2].WeakPointId, "weak point named");
        Assert.Equal("Rage", r.Hits[4].Phase, "third phase under 33%");
        Assert.Near(wp.DamageMult, r.Hits[4].WeakPointMult, 1e-9, "Rage: exposed");
        Assert.Near(1.0, r.Hits[5].WeakPointMult, 1e-9, "another part in Rage: no bonus");
        Assert.Equal("Rage", r.Dummies[0].Phase, "dummy readout carries the phase");
        // The multiplier really reaches the damage: chest tiny hits in Duel and Archers differ only by the weak point.
        Assert.True(r.Hits[2].Damage >= r.Hits[0].Damage, "weak point hit does at least as much damage");
    }

    public static void GrukksArmorBreaksOpensAPunishWindowAndRestoresByTheClock()
    {
        var a = Repo.Db.BossWeakPoints.Bosses.Single(b => b.SpeciesId == Grukk).Armor;
        var sb = new CombatSandbox(Repo.Db.Tuning, new FixedRandom(0.99, 0.5), Repo.Db.ReactionTable, Repo.Db.BossWeakPoints);
        sb.AddDummy(new SandboxDummySpec { Id = "g", SpeciesId = Grukk, Hp = 100000000, Weakness = Element.None });   // no phases: weak points stay closed
        double each = BossTargeting.BaseArmorDamage(HitWeight.Ultimate);
        int needed = (int)System.Math.Ceiling(a.MaxArmor / each);
        HitReadout last = null; int broke = -1;
        for (int i = 1; i <= needed + 2; i++)
        {
            last = sb.Hit(H(Element.None, HitWeight.Ultimate, target: "g", part: "left_leg"));
            if (last.ArmorBrokeNow) { broke = i; break; }
            Assert.Near(a.MaxArmor - each * i, last.ArmorAfter, 1e-6, $"armor after hit {i}");
        }
        Assert.Equal(needed, broke, "breaks on the hit that empties it");
        Assert.True(last.ArmorBroken && last.ArmorAfter == 0, "reads broken at 0");
        var plain = sb.Hit(H(Element.None, HitWeight.Light, target: "g", part: "left_leg"));
        Assert.Near(a.DamageTakenMultWhileBroken, plain.BrokenArmorMult, 1e-9, "extra damage while broken");
        Assert.True(sb.Readout().Dummies[0].ArmorBroken, "dummy readout says broken");
        sb.Advance(a.BreakSec + 0.1);
        var after = sb.Hit(H(Element.None, HitWeight.Light, target: "g", part: "left_leg"));
        Assert.Near(1.0, after.BrokenArmorMult, 1e-9, "no bonus once the break is over");
        Assert.True(!after.ArmorBroken, "armor is back");
        Assert.True(plain.Damage > after.Damage, "the broken window did more damage than the same hit afterwards");
    }

    public static void ArmorRegeneratesByTheClockWhenLeftAlone()
    {
        var sb = Sandbox();
        sb.AddDummy(new SandboxDummySpec { Id = "b", SpeciesId = "mon_goblin", Hp = 100000, Weakness = Element.None, Armor = new BossArmorData { MaxArmor = 10, BreakSec = 5, DamageTakenMultWhileBroken = 1.25, RegenDelaySec = 6 } });
        var r = sb.Hit(H(Element.None, HitWeight.Heavy, target: "b"));
        Assert.Near(6, r.ArmorAfter, 1e-9, "heavy chips 4 of 10");
        sb.Advance(5.9);
        Assert.Near(6, sb.Readout().Dummies[0].Armor, 1e-9, "not yet");
        sb.Advance(0.2);
        Assert.Near(10, sb.Readout().Dummies[0].Armor, 1e-9, "refilled after the regen delay");
    }

    public static void ADummyWithoutArmorOrBossDataReportsNoArmor()
    {
        var sb = Sandbox(); sb.AddDummy(Dummy());
        var r = sb.Hit(H(Element.None, HitWeight.Heavy));
        Assert.Near(0, r.ArmorAfter, 0, "no armor"); Assert.True(!r.ArmorBroken, "never broken");
        Assert.Near(1.0, r.BrokenArmorMult, 0, "neutral");
    }
}
