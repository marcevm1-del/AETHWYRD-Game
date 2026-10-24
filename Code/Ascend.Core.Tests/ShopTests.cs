using System.Linq;
using Ascend.Core;

// Shops: buy, sell, buyback, the Guild core buyback, anti-arbitrage (monster_core_pricing.md §4, §7).
[Tests]
static class ShopTests
{
    static Shop Open(string id) => new Shop(Repo.Db.Shops[id], Repo.Db.Items);

    public static void BuyingCostsTheAuthoredPrice()
    {
        var shop = Open("shop_reed_remedies");
        var inv = new Inventory(); inv.AddCopper(30);
        Assert.True(shop.Buy("itm_minor_hp_potion", inv) == TradeResult.Ok, "bought");
        Assert.Equal(16L, inv.Copper, "14 copper");
        Assert.True(shop.Buy("itm_fire_bomb", inv) == TradeResult.NotSold, "Fennick doesn't sell bombs");
        Assert.True(shop.Buy("itm_minor_hp_potion", inv) == TradeResult.Ok && shop.Buy("itm_minor_hp_potion", inv) == TradeResult.NotEnoughMoney, "until the money runs out");
    }

    public static void LimitedStockRunsOut()
    {
        var shop = Open("shop_ottoline_wagon");
        var inv = new Inventory(); inv.AddCopper(1000);
        Assert.Equal(1, shop.Left("itm_copper_compass") ?? -1, "one compass");
        Assert.True(shop.Buy("itm_copper_compass", inv) == TradeResult.Ok, "bought");
        Assert.True(shop.Buy("itm_copper_compass", inv) == TradeResult.OutOfStock, "sold out");
        Assert.True(shop.Left("itm_minor_hp_potion") == null, "potions are unlimited");
    }

    public static void TheGuildBuysCoresAtThePostedPrice()
    {
        var guild = Open("shop_guild_core_buyback");
        var inv = new Inventory(); inv.Add("itm_core_f", 3); inv.Add("itm_core_e");
        Assert.Equal(2L, guild.SellPrice("itm_core_f"), "F core: 2 copper");
        Assert.Equal(4L, guild.SellPrice("itm_core_e"), "E core: 4 copper");
        Assert.Equal(0L, guild.SellPrice("itm_mat_slime_jelly"), "the Guild doesn't buy jelly");
        Assert.True(guild.Sell("itm_core_f", inv) == TradeResult.Ok, "sold");
        Assert.Equal(2L, inv.Copper, "paid");
        Assert.Equal(0L, Open("shop_reed_remedies").SellPrice("itm_core_f"), "only the Guild buys cores");
    }

    public static void ShopsPayAFractionAndNeverBuyKeys()
    {
        var reed = Open("shop_reed_remedies");
        Assert.Equal(15L, reed.SellPrice("itm_mandrake_root"), "half of 30");
        Assert.Equal(0L, Open("shop_ottoline_wagon").SellPrice("itm_minas_earring"), "key items aren't bought");
    }

    public static void QuestItemsAreProtectedAndBuybackRestores()
    {
        var reed = Open("shop_reed_remedies");
        var inv = new Inventory(); inv.Add("itm_mandrake_root", 2);
        Assert.True(reed.Sell("itm_mandrake_root", inv, new[] { "itm_mandrake_root" }) == TradeResult.Protected, "needed for a quest");
        Assert.True(reed.Sell("itm_mandrake_root", inv) == TradeResult.Ok, "sold when not protected");
        Assert.Equal(15L, inv.Copper, "paid");
        Assert.Equal(1, reed.Buyback.Count, "in the buyback list");
        Assert.True(reed.BuyBack(0, inv) == TradeResult.Ok, "bought back");
        Assert.Equal(0L, inv.Copper, "at the price paid");
        Assert.Equal(2, inv.Count("itm_mandrake_root"), "both roots again");
    }

    public static void BoughtItemsNeverResellAtAProfit()
    {
        foreach (var shop in Repo.Db.Shops.Values.Select(s => new Shop(s, Repo.Db.Items)))
            foreach (var o in shop.Data.Stock)
                foreach (var buyer in Repo.Db.Shops.Values.Select(s => new Shop(s, Repo.Db.Items)))
                    Assert.True(buyer.SellPrice(o.ItemId) <= o.Price, $"{o.ItemId}: {shop.Data.Id} sells for {o.Price}, {buyer.Data.Id} pays {buyer.SellPrice(o.ItemId)}");
    }
}
