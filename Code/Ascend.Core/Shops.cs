using System;
using System.Collections.Generic;
using System.Linq;

namespace Ascend.Core
{
    // Shops (Data/Items/shops.json; 09_Equipment/monster_core_pricing.md §4 and §7; hud_and_ui.md: buy / sell / buyback).

    public sealed class ShopBuys { public List<string> Categories { get; set; } = new List<string>(); public double Rate { get; set; } }
    public sealed class ShopOffer { public string ItemId { get; set; } public int Price { get; set; } public int? Quantity { get; set; } }

    public sealed class ShopData
    {
        public string Id { get; set; }
        public string NpcId { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public ShopBuys Buys { get; set; } = new ShopBuys();
        public List<ShopOffer> Stock { get; set; } = new List<ShopOffer>();
    }

    public enum TradeResult { Ok, NotSold, OutOfStock, NotEnoughMoney, NotBought, NoneToSell, Protected }

    /// <summary>
    /// One shop visit's state: limited stock left and the buyback list (things you sold here, which you can buy back at
    /// the price you were paid until you leave the area). Rules:
    ///   • Retail price is authored per offer (includes the service premium).
    ///   • A shop buys only its categories, paying floor(value × rate); key items are never bought.
    ///   • Quest-protected items (needed by an active collect objective) can't be sold.
    ///   • Something bought from a shop resells for no more than it cost (never an arbitrage loop).
    /// </summary>
    public sealed class Shop
    {
        readonly IReadOnlyDictionary<string, ItemData> _items;
        readonly Dictionary<string, int> _left = new Dictionary<string, int>();
        readonly List<(string itemId, long price)> _buyback = new List<(string, long)>();
        readonly Dictionary<string, long> _paid = new Dictionary<string, long>();

        public ShopData Data { get; }
        public IReadOnlyList<(string itemId, long price)> Buyback => _buyback;
        public const int BuybackSlots = 10;

        public Shop(ShopData data, IReadOnlyDictionary<string, ItemData> items)
        {
            Data = data ?? throw new ArgumentNullException(nameof(data));
            _items = items ?? throw new ArgumentNullException(nameof(items));
            foreach (var o in data.Stock) if (o.Quantity.HasValue) _left[o.ItemId] = o.Quantity.Value;
        }

        /// <summary>Stock remaining for an offer, or null when unlimited.</summary>
        public int? Left(string itemId) => _left.TryGetValue(itemId, out var n) ? n : (int?)null;

        public ShopOffer Offer(string itemId) => Data.Stock.FirstOrDefault(o => o.ItemId == itemId);

        public TradeResult Buy(string itemId, Inventory inv)
        {
            var o = Offer(itemId);
            if (o == null) return TradeResult.NotSold;
            if (Left(itemId) == 0) return TradeResult.OutOfStock;
            if (!inv.TrySpend(o.Price)) return TradeResult.NotEnoughMoney;
            if (_left.ContainsKey(itemId)) _left[itemId]--;
            inv.Add(itemId);
            _paid[itemId] = Math.Max(_paid.TryGetValue(itemId, out var p) ? p : 0, o.Price);
            return TradeResult.Ok;
        }

        /// <summary>What this shop pays for one of the item (0 when it doesn't buy it).</summary>
        public long SellPrice(string itemId)
        {
            if (!ItemQuality.TryGetItem(_items, itemId, out var it) || it.Category == "key" || !Data.Buys.Categories.Contains(it.Category)) return 0;
            long price = (long)Math.Floor(it.Value * Data.Buys.Rate);
            // Bought here earlier: resell for no more than it cost (anti-arbitrage, monster_core_pricing.md §7).
            if (_paid.TryGetValue(itemId, out var paid)) price = Math.Min(price, paid);
            return Math.Max(0, price);
        }

        public TradeResult Sell(string itemId, Inventory inv, ICollection<string> questProtected = null)
        {
            if (inv.Count(itemId) <= 0) return TradeResult.NoneToSell;
            if (questProtected != null && (questProtected.Contains(itemId) || questProtected.Contains(ItemQuality.BaseId(itemId)))) return TradeResult.Protected;
            long price = SellPrice(itemId);
            if (price <= 0) return TradeResult.NotBought;
            inv.TryRemove(itemId);
            inv.AddCopper(price);
            _buyback.Insert(0, (itemId, price));
            if (_buyback.Count > BuybackSlots) _buyback.RemoveAt(_buyback.Count - 1);
            return TradeResult.Ok;
        }

        /// <summary>Sells up to <paramref name="quantity"/> of one item at the shop's price. Returns how many sold and the copper paid; quest items never sell.</summary>
        public (int sold, long paid) SellMany(string itemId, int quantity, Inventory inv, ICollection<string> questProtected = null)
        {
            int sold = 0;
            long before = inv.Copper;
            while (sold < quantity && Sell(itemId, inv, questProtected) == TradeResult.Ok) sold++;
            return (sold, inv.Copper - before);
        }

        /// <summary>Monster cores (monster_core_pricing.md): the itm_core_ family.</summary>
        public static bool IsMonsterCore(string itemId) => itemId != null && ItemQuality.BaseId(itemId).StartsWith("itm_core_", StringComparison.Ordinal);

        /// <summary>What <see cref="SellAllCores"/> would sell and pay right now, leaving out cores a quest needs.</summary>
        public (int count, long total) QuoteAllCores(Inventory inv, ICollection<string> questProtected = null)
        {
            int count = 0; long total = 0;
            foreach (var (_, n, price) in SellableCores(inv, questProtected)) { count += n; total += n * price; }
            return (count, total);
        }

        /// <summary>Sells every monster core this shop buys, except those a quest needs.</summary>
        public (int sold, long paid) SellAllCores(Inventory inv, ICollection<string> questProtected = null)
        {
            int sold = 0; long paid = 0;
            foreach (var (id, n, _) in SellableCores(inv, questProtected).ToList())
            {
                var r = SellMany(id, n, inv, questProtected);
                sold += r.sold; paid += r.paid;
            }
            return (sold, paid);
        }

        IEnumerable<(string itemId, int count, long price)> SellableCores(Inventory inv, ICollection<string> questProtected) =>
            Sellable(inv).Where(x => IsMonsterCore(x.itemId) && (questProtected == null || !(questProtected.Contains(x.itemId) || questProtected.Contains(ItemQuality.BaseId(x.itemId)))));

        /// <summary>Buys back the <paramref name="index"/>-th thing you sold here, at what you were paid.</summary>
        public TradeResult BuyBack(int index, Inventory inv)
        {
            if (index < 0 || index >= _buyback.Count) return TradeResult.NotSold;
            var (itemId, price) = _buyback[index];
            if (!inv.TrySpend(price)) return TradeResult.NotEnoughMoney;
            inv.Add(itemId);
            _buyback.RemoveAt(index);
            return TradeResult.Ok;
        }

        /// <summary>Items in the inventory this shop would buy, with its price for one.</summary>
        public IEnumerable<(string itemId, int count, long price)> Sellable(Inventory inv) =>
            inv.Items.Select(kv => (kv.Key, kv.Value, SellPrice(kv.Key))).Where(x => x.Item3 > 0).OrderBy(x => x.Key);
    }
}
