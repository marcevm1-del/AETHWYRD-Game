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

    public static void SellingAllCoresPaysTheQuoteAndLeavesTheRest()
    {
        var guild = Open("shop_guild_core_buyback");
        var inv = new Inventory(); inv.Add("itm_core_f", 30); inv.Add("itm_core_e", 2); inv.Add("itm_mat_slime_jelly", 4);
        var quote = guild.QuoteAllCores(inv);
        Assert.Equal(32, quote.count, "every core is counted");
        Assert.Equal(68L, quote.total, "30 x 2 + 2 x 4");
        var done = guild.SellAllCores(inv);
        Assert.Equal(32, done.sold, "every core sold");
        Assert.Equal(68L, done.paid, "paid what was quoted");
        Assert.Equal(68L, inv.Copper, "and the purse has it");
        Assert.Equal(0, inv.Count("itm_core_f") + inv.Count("itm_core_e"), "no cores left");
        Assert.Equal(4, inv.Count("itm_mat_slime_jelly"), "nothing else was touched");
        Assert.Equal(0, guild.SellAllCores(inv).sold, "a second press sells nothing");
    }

    public static void SellingAllCoresKeepsQuestCoresAndOtherShopsRefuse()
    {
        var guild = Open("shop_guild_core_buyback");
        var inv = new Inventory(); inv.Add("itm_core_f", 5); inv.Add("itm_core_e", 3);
        var keep = new[] { "itm_core_f" };
        Assert.Equal(3, guild.QuoteAllCores(inv, keep).count, "quest cores are not in the quote");
        Assert.Equal(12L, guild.SellAllCores(inv, keep).paid, "only the E cores sold");
        Assert.Equal(5, inv.Count("itm_core_f"), "the quest keeps its cores");
        Assert.Equal(0, Open("shop_reed_remedies").QuoteAllCores(inv).count, "only the Guild buys cores");
    }

    public static void SellingAQuantityStopsAtWhatYouHave()
    {
        var guild = Open("shop_guild_core_buyback");
        var inv = new Inventory(); inv.Add("itm_core_f", 7);
        var five = guild.SellMany("itm_core_f", 5, inv);
        Assert.True(five.sold == 5 && five.paid == 10L, "five for 10 copper");
        var rest = guild.SellMany("itm_core_f", 50, inv);
        Assert.True(rest.sold == 2 && inv.Copper == 14L, "only the two left");
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
