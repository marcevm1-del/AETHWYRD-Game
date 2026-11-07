using System.Collections.Generic;
using System.Linq;
using Ascend.Core;

// Cooking buffs: one Well Fed slot, quality-scaled, silent expiry (crafting_v6_audit.md section 3.4).
[Tests]
static class MealTests
{
    static Dictionary<string, ItemData> Items()
    {
        ItemData Meal(string id, string stat, double amount, double seconds) => new ItemData
        {
            Id = id, Name = id, Category = "consumable",
            Meal = new MealData { Effects = new List<MealEffect> { new MealEffect { Stat = stat, Amount = amount } }, Seconds = seconds }
        };
        return new Dictionary<string, ItemData>
        {
            ["itm_t_stew"] = Meal("itm_t_stew", "atk", 10, 100),
            ["itm_t_soup"] = Meal("itm_t_soup", "def", 6, 60),
            ["itm_t_rock"] = new ItemData { Id = "itm_t_rock", Name = "Rock", Category = "material" },
        };
    }

    static MealBuffs New() => new MealBuffs(Items(), Repo.Db.Quality);

    public static void EatingAMealStartsWellFed()
    {
        var m = New();
        Assert.True(m.Eat("itm_t_stew", 0), "a meal");
        var fx = m.Active(10);
        Assert.Equal(1, fx.Count, "one effect");
        Assert.True(fx[0].Stat == "atk" && fx[0].Amount == 10, "atk +10 at Normal");
        Assert.Near(10, m.Total("atk", 10), 1e-9, "total");
        Assert.Near(90, m.SecondsLeft(10), 1e-9, "time left");
    }

    public static void TheBuffExpiresSilentlyWithoutADebuff()
    {
        var m = New();
        m.Eat("itm_t_stew", 0);
        Assert.Equal(1, m.Active(99.9).Count, "still on");
        Assert.Equal(0, m.Active(100).Count, "gone at 100 s");
        Assert.True(!m.IsActive(100) && m.ItemKey == null, "slot is empty");
        Assert.Near(0, m.Total("atk", 500), 1e-9, "no penalty afterwards");
    }

    public static void ANewMealReplacesTheOldOneInTheSingleSlot()
    {
        var m = New();
        m.Eat("itm_t_stew", 0);
        m.Eat("itm_t_soup", 10);
        var fx = m.Active(20);
        Assert.Equal(1, fx.Count, "no stacking");
        Assert.Equal("def", fx[0].Stat, "the soup, not the stew");
        Assert.Near(0, m.Total("atk", 20), 1e-9, "stew effect is gone");
        Assert.Near(70, m.ExpiresAt, 1e-9, "the soup timer: 10 + 60");
        m.Eat("itm_t_soup", 30);
        Assert.Near(90, m.ExpiresAt, 1e-9, "eating the same again restarts it, still one slot");
        Assert.Near(6, m.Total("def", 31), 1e-9, "not 12");
    }

    public static void QualityScalesTheEffectAndTheDuration()
    {
        var fine = New(); fine.Eat("itm_t_stew@fine", 0);
        Assert.Near(11.5, fine.Total("atk", 1), 1e-9, "Fine x1.15");
        Assert.Near(115, fine.ExpiresAt, 1e-9, "Fine lasts x1.15");
        var master = New(); master.Eat("itm_t_stew@masterwork", 0);
        Assert.Near(15, master.Total("atk", 1), 1e-9, "Masterwork x1.5");
        Assert.Near(150, master.ExpiresAt, 1e-9, "and lasts x1.5");
        var poor = New(); poor.Eat("itm_t_stew@poor", 0);
        Assert.Near(8, poor.Total("atk", 1), 1e-9, "Poor x0.8");
        Assert.Near(80, poor.ExpiresAt, 1e-9, "and is shorter");
    }

    public static void DurationScalingIsCappedAtDouble()
    {
        var rules = new QualityRules();
        rules.QualityTiers.Add(new QualityTierData { Id = "normal", Index = 1 });
        rules.QualityTiers.Add(new QualityTierData { Id = "grand", Index = 2, BuffMult = 3 });
        var m = new MealBuffs(Items(), rules);
        m.Eat("itm_t_stew@grand", 0);
        Assert.Near(30, m.Total("atk", 1), 1e-9, "effect still x3");
        Assert.Near(200, m.ExpiresAt, 1e-9, "time capped at 2x");
    }

    public static void NonMealsAreRefusedAndDoNotDisturbTheSlot()
    {
        var m = New();
        m.Eat("itm_t_stew", 0);
        Assert.True(!m.Eat("itm_t_rock", 5), "a rock is not a meal");
        Assert.True(!m.Eat("itm_gone", 5), "unknown item");
        Assert.Equal(1, m.Active(6).Count, "the stew is still on");
    }

    public static void EatingFromTheBagUsesUpOneMeal()
    {
        var m = New();
        var inv = new Inventory(); inv.Add("itm_t_stew@fine", 2);
        Assert.True(m.Eat("itm_t_stew@fine", 0, inv), "from the bag");
        Assert.Equal(1, inv.Count("itm_t_stew@fine"), "one left");
        Assert.True(!m.Eat("itm_t_soup", 0, inv), "none of those in the bag");
        Assert.Equal("itm_t_stew@fine", m.ItemKey, "slot unchanged by a failed eat");
    }

    public static void MealBlockLoadsFromItemJson()
    {
        var item = System.Text.Json.JsonSerializer.Deserialize<ItemData>(
            "{\"id\":\"itm_x\",\"name\":\"X\",\"category\":\"consumable\",\"meal\":{\"effects\":[{\"stat\":\"def\",\"amount\":4}],\"seconds\":90}}",
            new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        Assert.True(item.Meal != null && item.Meal.Seconds == 90 && item.Meal.Effects.Single().Stat == "def", "meal block parsed");
        Assert.True(Repo.Db.Items.Values.All(i => i.Meal == null || i.Meal.Seconds > 0), "data meals are sane");
    }

    public static void CraftedMealsFlowStraightIntoTheSlot()
    {
        // Cook at a campfire, then eat what came out: the quality in the key decides the buff.
        var cr = CraftKit.Crafter(("cooking", "B"));
        var inv = CraftKit.Inv(("itm_t_meat@fine", 2));
        var feast = cr.Make("rcp_t_feast", inv, null, new MakeOptions { Seed = 2 });
        Assert.Equal("itm_t_feast@superior", feast.OutputKey, "Superior at the hearth");
        var items = Items();
        items["itm_t_feast"] = new ItemData { Id = "itm_t_feast", Meal = new MealData { Seconds = 100, Effects = new List<MealEffect> { new MealEffect { Stat = "hp", Amount = 20 } } } };
        var m = new MealBuffs(items, Repo.Db.Quality);
        Assert.True(m.Eat(feast.OutputKey, 0, inv), "eat it");
        Assert.Near(26, m.Total("hp", 1), 1e-9, "Superior x1.3");
    }
}
