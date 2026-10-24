using System;
using System.Collections.Generic;
using System.Linq;

namespace Ascend.Core
{
    public enum EquipResult { Ok, NotOwned, NotGear, WrongWeapon, WrongArmor }

    /// <summary>
    /// What the character wears: one item per slot (items.json "slot": main_hand, head, belt, charm…). Equipping takes
    /// the item out of the bag and puts the old one back. A class can wield only its listed weapon types and wear only
    /// its armour weights (classes.json weapons / armor). Gear stats add to the derived stats: atk, matk, def, mdef, hp,
    /// and crit (a fraction, 0.03 = +3%).
    /// </summary>
    public sealed class Equipment
    {
        readonly Dictionary<string, string> _slots = new Dictionary<string, string>();
        readonly IReadOnlyDictionary<string, ItemData> _items;

        public Equipment(IReadOnlyDictionary<string, ItemData> items) { _items = items ?? throw new ArgumentNullException(nameof(items)); }

        public IReadOnlyDictionary<string, string> Slots => _slots;
        public string In(string slot) => _slots.TryGetValue(slot, out var id) ? id : null;
        public event Action Changed;

        public static bool IsGear(ItemData it) => it != null && (it.Category == "weapon" || it.Category == "armor" || it.Category == "accessory") && !string.IsNullOrEmpty(it.Slot);

        public EquipResult CanEquip(string itemId, ClassData cls)
        {
            if (!_items.TryGetValue(itemId ?? "", out var it) || !IsGear(it)) return EquipResult.NotGear;
            if (it.Category == "weapon" && cls?.Weapons != null && cls.Weapons.Count > 0 && !cls.Weapons.Contains(it.WeaponType)) return EquipResult.WrongWeapon;
            if (it.Category == "armor" && cls?.Armor != null && cls.Armor.Count > 0 && !string.IsNullOrEmpty(it.ArmorWeight) && !cls.Armor.Contains(it.ArmorWeight)) return EquipResult.WrongArmor;
            return EquipResult.Ok;
        }

        /// <summary>Equips from the bag (the previous item in that slot goes back into the bag).</summary>
        public EquipResult Equip(string itemId, Inventory bag, ClassData cls)
        {
            var can = CanEquip(itemId, cls);
            if (can != EquipResult.Ok) return can;
            if (bag != null && !bag.TryRemove(itemId)) return EquipResult.NotOwned;
            string slot = _items[itemId].Slot;
            if (_slots.TryGetValue(slot, out var old)) bag?.Add(old);
            _slots[slot] = itemId;
            Changed?.Invoke();
            return EquipResult.Ok;
        }

        public bool Unequip(string slot, Inventory bag)
        {
            if (!_slots.TryGetValue(slot, out var id)) return false;
            _slots.Remove(slot);
            bag?.Add(id);
            Changed?.Invoke();
            return true;
        }

        /// <summary>Puts gear on directly (a new character's starting kit, or a save).</summary>
        public void Load(IEnumerable<KeyValuePair<string, string>> slots)
        {
            _slots.Clear();
            foreach (var kv in slots ?? Enumerable.Empty<KeyValuePair<string, string>>())
                if (_items.TryGetValue(kv.Value ?? "", out var it) && IsGear(it)) _slots[it.Slot] = kv.Value;
            Changed?.Invoke();
        }

        public GearBonus Bonus()
        {
            var b = new GearBonus();
            foreach (var id in _slots.Values) b = Add(b, _items[id]);
            return b;
        }

        /// <summary>The bonus if <paramref name="itemId"/> replaced what's in its slot (for "better / worse" in the bag).</summary>
        public GearBonus BonusWith(string itemId)
        {
            if (!_items.TryGetValue(itemId ?? "", out var it) || !IsGear(it)) return Bonus();
            var b = new GearBonus();
            foreach (var kv in _slots) if (kv.Key != it.Slot) b = Add(b, _items[kv.Value]);
            return Add(b, it);
        }

        static GearBonus Add(GearBonus b, ItemData it)
        {
            int I(string k) => (int)Math.Round(it.Stat(k));
            b.Atk += I("atk"); b.Matk += I("matk"); b.Def += I("def"); b.Mdef += I("mdef"); b.Hp += I("hp");
            b.Crit += it.Stat("crit");
            return b;
        }
    }
}
