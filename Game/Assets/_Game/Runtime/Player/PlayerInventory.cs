using System.Collections.Generic;
using System.Linq;
using Ascend.Core;
using UnityEngine;

namespace Ascend.Game
{
    /// <summary>
    /// The player's carried items and money (Core Inventory) and kill rewards: each defeated monster rolls its species'
    /// loot table (luck raised by the Style Rank's drop bonus, combat.md §8) and pays its coins. Pickups are announced
    /// as short toasts the HUD shows.
    /// </summary>
    [RequireComponent(typeof(PlayerCombat))]
    public sealed class PlayerInventory : MonoBehaviour
    {
        [SerializeField] Difficulty difficulty = Difficulty.Adventurer;
        [SerializeField] ulong lootSeed = 23;

        PlayerCombat _combat;
        IRandom _rng;
        readonly List<(string text, float until)> _toasts = new List<(string, float)>();

        public Inventory Items { get; } = new Inventory();
        public Difficulty Difficulty { get => difficulty; set => difficulty = value; }
        public IEnumerable<string> Toasts { get { _toasts.RemoveAll(t => Time.unscaledTime > t.until); foreach (var t in _toasts) yield return t.text; } }
        public string MoneyText => Money.Format(Items.Copper, AscendData.Db.World.Currency);

        readonly Dictionary<string, Shop> _shops = new Dictionary<string, Shop>();

        /// <summary>The shop an NPC runs (null if none). Kept for the session so limited stock and buyback persist.</summary>
        public Shop ShopFor(string npcId)
        {
            if (string.IsNullOrEmpty(npcId)) return null;
            if (_shops.TryGetValue(npcId, out var s)) return s;
            var data = AscendData.Db.ShopOf(npcId);
            return _shops[npcId] = data != null ? new Shop(data, AscendData.Db.Items) : null;
        }

        void Awake()
        {
            _combat = GetComponent<PlayerCombat>();
            _rng = new DeterministicRandom(lootSeed);
            _combat.Killed += OnKilled;
        }

        void OnDestroy() { if (_combat != null) _combat.Killed -= OnKilled; }

        void OnKilled(MonsterDummy m)
        {
            var db = AscendData.Db;
            if (!db.Species.TryGetValue(m.SpeciesId, out var s)) return;
            if (s.Gold > 0) { Items.AddCopper(s.Gold); Toast($"+{Money.Format(s.Gold, db.World.Currency)}"); }
            if (string.IsNullOrEmpty(s.LootTableId) || !db.LootTables.TryGetValue(s.LootTableId, out var table)) return;
            double luck = 1 + StyleRewards.DropBonus(_combat.Style.Rank, db.Tuning.Style);
            foreach (var d in LootRoller.Roll(table, _rng, luck))
            {
                Items.Add(d.ItemId, d.Count);
                string name = db.Items.TryGetValue(d.ItemId, out var it) ? it.Name : d.ItemId;
                Toast($"+ {name}{(d.Count > 1 ? $" ×{d.Count}" : "")}");
            }
        }

        /// <summary>Drinks the weakest healing consumable you carry (stats.heal); false when you have none or are at full HP.</summary>
        public bool DrinkHealingPotion()
        {
            var def = GetComponent<PlayerDefense>();
            if (def == null || def.IsDead) return false;
            if (def.Hp >= def.MaxHp) { Toast("Already at full health"); return false; }
            var db = AscendData.Db;
            var potion = Items.Items.Keys
                .Select(id => db.Items.TryGetValue(id, out var it) ? it : null)
                .Where(it => it != null && it.Category == "consumable" && it.Stat("heal") > 0)
                .OrderBy(it => it.Stat("heal")).FirstOrDefault();
            if (potion == null) { Toast("No healing potions"); return false; }
            Items.TryRemove(potion.Id);
            def.Heal((int)potion.Stat("heal"));
            Toast($"{potion.Name}: +{potion.Stat("heal"):0} HP");
            return true;
        }

        public void Toast(string text, float seconds = 3f)
        {
            _toasts.Add((text, Time.unscaledTime + seconds));
            if (_toasts.Count > 6) _toasts.RemoveAt(0);
        }
    }
}
