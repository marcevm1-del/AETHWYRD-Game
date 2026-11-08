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
        readonly QualityRules _quality;
        readonly GearFitter _fitter;

        /// <param name="quality">Scales gear stats by the quality tier of a slot's item key (itemId@tier). Null: every item counts as Normal.</param>
        /// <param name="fitter">Adds the runes, rune word and enchantment fitted to the worn item. Null: no fittings.</param>
        public Equipment(IReadOnlyDictionary<string, ItemData> items, QualityRules quality = null, GearFitter fitter = null)
        {
            _items = items ?? throw new ArgumentNullException(nameof(items));
            _quality = quality;
            _fitter = fitter;
            if (_fitter != null) _fitter.Changed += () => Changed?.Invoke();
        }

        /// <summary>Item data for a slot key; a quality key (itemId@tier) resolves to its base item, a plain id to itself.</summary>
        ItemData Lookup(string key) => _items.TryGetValue(ItemQuality.BaseId(key ?? ""), out var it) ? it : null;

        public IReadOnlyDictionary<string, string> Slots => _slots;
        public string In(string slot) => _slots.TryGetValue(slot, out var id) ? id : null;
        public event Action Changed;

        public static bool IsGear(ItemData it) => it != null && (it.Category == "weapon" || it.Category == "armor" || it.Category == "accessory") && !string.IsNullOrEmpty(it.Slot);

        public EquipResult CanEquip(string itemId, ClassData cls)
        {
            var it = Lookup(itemId);
            if (!IsGear(it)) return EquipResult.NotGear;
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
            string slot = Lookup(itemId).Slot;
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
                if (Lookup(kv.Value) is ItemData it && IsGear(it)) _slots[it.Slot] = kv.Value;
            Changed?.Invoke();
        }

        public GearBonus Bonus() => Sum(_slots.Values);

        /// <summary>The bonus if <paramref name="itemId"/> replaced what's in its slot (for "better / worse" in the bag).</summary>
        public GearBonus BonusWith(string itemId)
        {
            var it = Lookup(itemId);
            if (!IsGear(it)) return Bonus();
            return Sum(_slots.Where(kv => kv.Key != it.Slot).Select(kv => kv.Value).Concat(new[] { itemId }));
        }

        /// <summary>
        /// Base stats times the quality tier's statMult, plus fittings, summed over the loadout and rounded once per stat.
        /// With no quality rules and no fitter this equals the plain sum of the items' stats.
        /// </summary>
        GearBonus Sum(IEnumerable<string> keys)
        {
            double atk = 0, matk = 0, def = 0, mdef = 0, hp = 0, crit = 0;
            string element = null, mainElement = null;
            foreach (var key in keys)
            {
                var it = Lookup(key);
                if (it == null) continue;
                double m = _quality?.StatMult(ItemQuality.Split(key).TierId) ?? 1;
                atk += it.Stat("atk") * m; matk += it.Stat("matk") * m; def += it.Stat("def") * m;
                mdef += it.Stat("mdef") * m; hp += it.Stat("hp") * m; crit += it.Stat("crit") * m;
                if (_fitter != null)
                {
                    var f = _fitter.BonusFor(key);
                    atk += f.Atk; matk += f.Matk; def += f.Def; mdef += f.Mdef; hp += f.Hp; crit += f.Crit;
                    if (f.Element != null) { if (it.Slot == "main_hand") mainElement = f.Element; else element = element ?? f.Element; }
                }
            }
            return new GearBonus
            {
                Atk = (int)Math.Round(atk), Matk = (int)Math.Round(matk), Def = (int)Math.Round(def),
                Mdef = (int)Math.Round(mdef), Hp = (int)Math.Round(hp), Crit = crit,
                ApplyElement = mainElement ?? element
            };
        }
    }
}
