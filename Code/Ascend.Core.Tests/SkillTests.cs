using System.Linq;
using Ascend.Core;

// Skill casting on the Swordsman's real kit (combat.md §6) and the Fire + Wind reaction (§7).
[Tests]
static class SkillTests
{
    static CombatTuning C => Repo.Db.Tuning;
    static ClassData Sword => Repo.Db.Classes["cls_swordsman"];

    static SkillCaster Caster(int level, ComboBudget budget = null)
    {
        var db = Repo.Db;
        var stats = PlayerStats.Derive(PlayerStats.Primary(Sword, level, db.Progression), level, db.Progression);
        return new SkillCaster(Sword, level, stats, C.Resources, budget);
    }

    public static void SlotsHoldUnlockedSkillsOnly()
    {
        var c = Caster(1);
        Assert.True(c.Slots.Count >= 2 && c.Slots.Count <= C.Resources.SkillSlots, "a few skills at Lv 1, never more than the slot count");
        Assert.True(c.Slots.All(s => s.UnlockLevel <= 1), "only unlocked skills are slotted");
        Assert.Equal(CastResult.Locked, c.CanCast(Sword.Skill("skl_rising_cut")), "Rising Cut is locked until Lv 4");
        c.SetLevel(4);
        Assert.Equal(CastResult.Ok, c.CanCast(Sword.Skill("skl_rising_cut")), "unlocked at Lv 4");
    }

    public static void CastingSpendsCostsAndStartsTheCooldown()
    {
        var c = Caster(1);
        var flash = Sword.Skill("skl_flash_step");
        double sp = c.Sp;
        Assert.Equal(CastResult.Ok, c.Cast(flash), "Flash Step casts");
        Assert.Near(sp - flash.CostSp, c.Sp, 1e-9, "SP spent");
        Assert.Equal(CastResult.Cooldown, c.CanCast(flash), "on cooldown");
        c.Tick(flash.CooldownSec + 0.01);
        Assert.Equal(CastResult.Ok, c.CanCast(flash), "cooldown over");
        Assert.True(c.Sp > sp - flash.CostSp, "SP regenerates");
    }

    public static void AirSlashCostsMpAndRunsOut()
    {
        var db = Repo.Db;
        var stats = PlayerStats.Derive(PlayerStats.Primary(Sword, 1, db.Progression), 1, db.Progression);
        var noRegen = new ResourceTuning { MpRegenPerSec = 0, SpRegenPerSec = 0 };
        var c = new SkillCaster(Sword, 1, stats, noRegen, null);
        var slash = Sword.Skill("skl_air_slash");
        int casts = 0;
        for (int i = 0; i < 1000 && c.Mp >= slash.CostMp; i++) // capped: never loops forever
        {
            if (c.Cast(slash) == CastResult.Ok) casts++;
            c.Tick(slash.CooldownSec + 0.01);
        }
        Assert.True(casts >= 1, "casts while MP lasts");
        Assert.Equal(CastResult.NoMp, c.CanCast(slash), "no MP, no cast");
    }

    public static void UltimateNeedsFullAwakening()
    {
        var c = Caster(1);
        var ult = c.Ultimate;
        Assert.Equal("skl_thousand_petal_blade", ult.Id, "the Swordsman's ultimate");
        Assert.Equal(CastResult.NoAwakening, c.CanCast(ult), "empty meter");
        c.GainAwakeningFromStyle(400);
        c.GainAwakeningFromDamage(50, 100);
        Assert.True(c.Awakening > 0, "style and damage fill Awakening");
        c.AddAwakening(1000);
        Assert.Near(c.MaxAwakening, c.Awakening, 1e-9, "capped at max");
        Assert.Equal(CastResult.Ok, c.Cast(ult), "full meter casts the ultimate");
        Assert.Near(0, c.Awakening, 1e-9, "the ultimate spends it all");
    }

    public static void SkillCancelsSpendTheComboBudget()
    {
        var budget = new ComboBudget(C.Combo);
        var c = Caster(10, budget);
        var flash = Sword.Skill("skl_flash_step");
        for (int i = 0; i < C.Combo.BudgetPerString; i++)
        {
            Assert.Equal(CastResult.Ok, c.Cast(flash, asCancel: true), $"cancel {i + 1}");
            c.Tick(flash.CooldownSec + 0.01);
            budget.Tick(0.01, attacking: true, airborne: false);
        }
        Assert.Equal(CastResult.NoBudget, c.CanCast(flash, asCancel: true), "budget spent");
        Assert.Equal(CastResult.Ok, c.CanCast(flash, asCancel: false), "a fresh cast (not a cancel) is still fine");
    }

    public static void AirSlashAppliesWindAndAFireBombMakesFirestorm()
    {
        var slash = Sword.Skill("skl_air_slash");
        Assert.True(slash.AppliesElement && slash.Element == "Wind", "Air Slash applies Wind");
        var bomb = Repo.Db.Items["itm_fire_bomb"];
        Assert.Equal("Fire", bomb.Stats["applyElement"].ToString(), "the Fire Bomb applies Fire");
        var r = new ReactionState(C.Reactions);
        r.ApplyElement(Element.Wind, 0);
        Assert.Equal(Reaction.Firestorm, r.ApplyElement(Element.Fire, 1), "Wind aura + Fire = Firestorm");
        Assert.True(C.Firestorm.BurstMult > 1 && C.Firestorm.DurationSec > 0 && C.Firestorm.TickSec > 0, "Firestorm is tuned");
    }
}
