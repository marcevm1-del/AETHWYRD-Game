using Ascend.Core;

// Equipment: slots, class weapon/armour rules, stat bonuses (classes.json weapons/armor; items.json slot, stats).
[Tests]
static class EquipmentTests
{
    static ClassData Swordsman => Repo.Db.Classes["cls_swordsman"];

    public static void EquipSwapsWithTheBagAndAddsStats()
    {
        var eq = new Equipment(Repo.Db.Items);
        var bag = new Inventory(); bag.Add("itm_guild_issue_sword"); bag.Add("itm_hollis_practice_blade");
        Assert.True(eq.Equip("itm_guild_issue_sword", bag, Swordsman) == EquipResult.Ok, "equipped");
        Assert.Equal(8, eq.Bonus().Atk, "+8 ATK");
        Assert.Equal(0, bag.Count("itm_guild_issue_sword"), "out of the bag");
        Assert.True(eq.BonusWith("itm_hollis_practice_blade").Atk == 22, "preview of the swap");
        eq.Equip("itm_hollis_practice_blade", bag, Swordsman);
        Assert.Equal(22, eq.Bonus().Atk, "the better blade");
        Assert.True(System.Math.Abs(eq.Bonus().Crit - 0.03) < 1e-9, "+3% crit (a fraction)");
        Assert.Equal(1, bag.Count("itm_guild_issue_sword"), "old sword back in the bag");
        Assert.True(eq.Unequip("main_hand", bag) && eq.In("main_hand") == null, "unequipped");
    }

    public static void ClassesWieldOnlyTheirWeapons()
    {
        var eq = new Equipment(Repo.Db.Items);
        var bag = new Inventory(); bag.Add("itm_guild_issue_staff");
        Assert.True(eq.Equip("itm_guild_issue_staff", bag, Swordsman) == EquipResult.WrongWeapon, "a swordsman can't use a staff");
        Assert.Equal(1, bag.Count("itm_guild_issue_staff"), "it stays in the bag");
        Assert.True(eq.Equip("itm_guild_issue_staff", bag, Repo.Db.Classes["cls_mage"]) == EquipResult.Ok, "a mage can");
        Assert.True(eq.Equip("itm_minor_hp_potion", new Inventory(), Swordsman) == EquipResult.NotGear, "potions aren't gear");
        Assert.True(eq.Equip("itm_rookie_hood", new Inventory(), Swordsman) == EquipResult.NotOwned, "must own it");
    }

    public static void EveryStarterWeaponSuitsItsClass()
    {
        foreach (var c in Repo.Db.Classes.Values)
            Assert.True(new Equipment(Repo.Db.Items).CanEquip(c.StarterWeaponId, c) == EquipResult.Ok, c.Id + " starter weapon");
    }

    public static void GearFeedsDerivedStats()
    {
        var eq = new Equipment(Repo.Db.Items);
        eq.Load(new[] { new System.Collections.Generic.KeyValuePair<string, string>("main_hand", "itm_guild_issue_sword"),
                        new System.Collections.Generic.KeyValuePair<string, string>("head", "itm_rookie_hood") });
        var p = PlayerStats.Primary(Swordsman, 1, Repo.Db.Progression);
        var bare = PlayerStats.Derive(p, 1, Repo.Db.Progression);
        var geared = PlayerStats.Derive(p, 1, Repo.Db.Progression, eq.Bonus());
        Assert.Equal(bare.Atk + 8, geared.Atk, "sword ATK");
        Assert.Equal(bare.Def + 3, geared.Def, "hood DEF");
    }
}
