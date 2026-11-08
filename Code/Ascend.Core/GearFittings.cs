using System;
using System.Collections.Generic;
using System.Linq;

namespace Ascend.Core
{
    // Runes, enchanting and modular parts (12_Systems/gear_and_runes.md; 13_Production/gear_v6b_audit.md).
    // Data: Data/Items/gear_rules.json. Everything is deterministic and nothing here can break, wear out or destroy gear.

    public sealed class SocketRules
    {
        public Dictionary<string, int> ByRarity { get; set; } = new Dictionary<string, int>();
        public int MasterworkBonus { get; set; } = 1;
        public int Max { get; set; } = 3;
    }

    public sealed class GearStations
    {
        public string Socket { get; set; } = "rune_anvil";
        public string Enchant { get; set; } = "enchanting_table";
        public string Assemble { get; set; } = "forge";
    }

    public sealed class RuneData
    {
        /// <summary>The rune item id (itm_rune_*).</summary>
        public string Id { get; set; }
        /// <summary>Gear categories it fits: weapon, armor, accessory.</summary>
        public List<string> Fits { get; set; } = new List<string>();
        public Dictionary<string, double> Stats { get; set; } = new Dictionary<string, double>();
    }

    public sealed class RuneWordData
    {
        public string Id { get; set; }
        public string Name { get; set; }
        /// <summary>Rune item ids in socket order; the word is active when they appear side by side in that order.</summary>
        public List<string> Runes { get; set; } = new List<string>();
        public List<string> Fits { get; set; } = new List<string>();
        public Dictionary<string, double> Stats { get; set; } = new Dictionary<string, double>();
    }

    public sealed class EnchantmentData
    {
        public string Id { get; set; }
        public string Name { get; set; }
        /// <summary>The scroll item that carries it (itm_scroll_*).</summary>
        public string ItemId { get; set; }
        public List<string> Fits { get; set; } = new List<string>();
        public Dictionary<string, double> Stats { get; set; } = new Dictionary<string, double>();
        /// <summary>Weapons only: the element the weapon applies.</summary>
        public string Element { get; set; }
    }

    public sealed class AssemblyData
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Skill { get; set; }
        public string LifeRank { get; set; } = "F";
        public int? Xp { get; set; }
        public string Output { get; set; }
        public List<string> Blades { get; set; } = new List<string>();
        public List<string> Hilts { get; set; } = new List<string>();
    }

    /// <summary>Data/Items/gear_rules.json plus lookups. An empty instance (file not loaded) has no sockets and no content.</summary>
    public sealed class GearRules
    {
        public string Notes { get; set; }
        public SocketRules Sockets { get; set; } = new SocketRules();
        public int EnchantSlots { get; set; } = 1;
        public GearStations Stations { get; set; } = new GearStations();
        public List<RuneData> Runes { get; set; } = new List<RuneData>();
        public List<RuneWordData> RuneWords { get; set; } = new List<RuneWordData>();
        public List<EnchantmentData> Enchantments { get; set; } = new List<EnchantmentData>();
        public List<AssemblyData> Assemblies { get; set; } = new List<AssemblyData>();

        public RuneData Rune(string itemId) => Runes.FirstOrDefault(r => r.Id == itemId);
        public EnchantmentData EnchantmentOfScroll(string scrollItemId) => Enchantments.FirstOrDefault(e => e.ItemId == scrollItemId);
        public EnchantmentData Enchantment(string id) => Enchantments.FirstOrDefault(e => e.Id == id);
        public AssemblyData Assembly(string id) => Assemblies.FirstOrDefault(a => a.Id == id);
    }

    /// <summary>What one piece of gear carries. Rune and scroll entries are inventory keys (itemId or itemId@tier), so quality is kept.</summary>
    public sealed class GearFitting
    {
        /// <summary>Runes in socket order.</summary>
        public List<string> Runes { get; set; } = new List<string>();
        /// <summary>The scroll key of the enchantment, or null.</summary>
        public string Enchant { get; set; }
    }

    /// <summary>Extra stats from a fitting. Fractional until the whole loadout is summed, then rounded once.</summary>
    public struct FittingBonus
    {
        public double Atk, Matk, Def, Mdef, Hp, Crit;
        public string Element;
        public string RuneWord;
    }

    public enum FitResult { Ok, Unknown, NotGear, NotOwned, WrongStation, NotARune, NotAScroll, DoesNotFit, NoFreeSocket, NothingToRemove }

    /// <summary>
    /// Sockets runes and applies enchantment scrolls. A fitting belongs to the item key (itemId or itemId@tier): copies of the
    /// same key share it, so a second copy is plain until you refit. Socketing and scrolls happen at their stations (the rune
    /// anvil and the enchanting table); removing returns the item to the bag at no cost. A scroll replaces the old enchantment.
    /// </summary>
    public sealed class GearFitter
    {
        readonly GearRules _rules;
        readonly IReadOnlyDictionary<string, ItemData> _items;
        readonly QualityRules _quality;
        readonly Crafter _crafter;
        readonly Dictionary<string, GearFitting> _fittings = new Dictionary<string, GearFitting>();

        public event Action Changed;

        /// <param name="crafter">Supplies station ownership (rune anvil, enchanting table). Null: stations are not checked.</param>
        public GearFitter(GearRules rules, IReadOnlyDictionary<string, ItemData> items, QualityRules quality = null, Crafter crafter = null)
        {
            _rules = rules ?? new GearRules();
            _items = items ?? throw new ArgumentNullException(nameof(items));
            _quality = quality ?? new QualityRules();
            _crafter = crafter;
        }

        public GearRules Rules => _rules;
        public IReadOnlyDictionary<string, GearFitting> Fittings => _fittings;

        ItemData Item(string key) => _items.TryGetValue(ItemQuality.BaseId(key ?? ""), out var it) ? it : null;

        /// <summary>weapon, armor or accessory for gear; null otherwise.</summary>
        public string CategoryOf(string gearKey)
        {
            var it = Item(gearKey);
            return Equipment.IsGear(it) ? it.Category : null;
        }

        /// <summary>Sockets a piece of gear has: by rarity, plus one for Masterwork, never above the cap.</summary>
        public int SocketCount(string gearKey)
        {
            var it = Item(gearKey);
            if (!Equipment.IsGear(it)) return 0;
            int n = _rules.Sockets.ByRarity != null && it.Rarity != null && _rules.Sockets.ByRarity.TryGetValue(it.Rarity, out var s) ? s : 0;
            // Divine gear is story-bound and fixed: it takes no fittings.
            if (it.Rarity == "Divine") return 0;
            if (_quality.Tier(ItemQuality.Split(gearKey).TierId)?.Id == "masterwork") n += _rules.Sockets.MasterworkBonus;
            return Math.Min(n, _rules.Sockets.Max);
        }

        public bool CanHoldEnchantment(string gearKey) => CategoryOf(gearKey) != null && _rules.EnchantSlots > 0;

        public GearFitting Of(string gearKey) => gearKey != null && _fittings.TryGetValue(gearKey, out var f) ? f : null;

        bool Owns(string gearKey, Inventory inv, Equipment eq) =>
            (inv != null && inv.Count(gearKey) > 0) || (eq != null && eq.Slots.Values.Contains(gearKey));

        bool StationOk(string station, string atNpcId) => _crafter == null || _crafter.StationAvailable(station, atNpcId);

        public FitResult SocketRune(string gearKey, string runeKey, Inventory inv, Equipment eq, string atNpcId)
        {
            string cat = CategoryOf(gearKey);
            if (cat == null) return FitResult.NotGear;
            if (!Owns(gearKey, inv, eq)) return FitResult.NotOwned;
            if (!StationOk(_rules.Stations.Socket, atNpcId)) return FitResult.WrongStation;
            var rune = _rules.Rune(ItemQuality.BaseId(runeKey ?? ""));
            if (rune == null) return FitResult.NotARune;
            if (!rune.Fits.Contains(cat)) return FitResult.DoesNotFit;
            var fit = Of(gearKey);
            if ((fit?.Runes.Count ?? 0) >= SocketCount(gearKey)) return FitResult.NoFreeSocket;
            if (inv == null || !inv.TryRemove(runeKey)) return FitResult.NotOwned;
            if (fit == null) _fittings[gearKey] = fit = new GearFitting();
            fit.Runes.Add(runeKey);
            Changed?.Invoke();
            return FitResult.Ok;
        }

        /// <summary>Takes the rune in socket <paramref name="index"/> out and returns it to the bag. Later runes shift down.</summary>
        public FitResult RemoveRune(string gearKey, int index, Inventory inv, Equipment eq, string atNpcId)
        {
            if (CategoryOf(gearKey) == null) return FitResult.NotGear;
            if (!StationOk(_rules.Stations.Socket, atNpcId)) return FitResult.WrongStation;
            var fit = Of(gearKey);
            if (fit == null || index < 0 || index >= fit.Runes.Count) return FitResult.NothingToRemove;
            inv?.Add(fit.Runes[index]);
            fit.Runes.RemoveAt(index);
            Prune(gearKey);
            Changed?.Invoke();
            return FitResult.Ok;
        }

        /// <summary>Applies a scroll. If the gear already had an enchantment it is replaced (the old one is gone); the preview call tells the UI first.</summary>
        public FitResult ApplyScroll(string gearKey, string scrollKey, Inventory inv, Equipment eq, string atNpcId)
        {
            string cat = CategoryOf(gearKey);
            if (cat == null) return FitResult.NotGear;
            if (!Owns(gearKey, inv, eq)) return FitResult.NotOwned;
            if (!StationOk(_rules.Stations.Enchant, atNpcId)) return FitResult.WrongStation;
            var enc = _rules.EnchantmentOfScroll(ItemQuality.BaseId(scrollKey ?? ""));
            if (enc == null) return FitResult.NotAScroll;
            if (!enc.Fits.Contains(cat) || _rules.EnchantSlots < 1) return FitResult.DoesNotFit;
            if (inv == null || !inv.TryRemove(scrollKey)) return FitResult.NotOwned;
            var fit = Of(gearKey);
            if (fit == null) _fittings[gearKey] = fit = new GearFitting();
            fit.Enchant = scrollKey;
            Changed?.Invoke();
            return FitResult.Ok;
        }

        /// <summary>The enchantment id that a scroll would replace, or null when the slot is free.</summary>
        public string WouldReplace(string gearKey) => Of(gearKey)?.Enchant == null ? null : _rules.EnchantmentOfScroll(ItemQuality.BaseId(Of(gearKey).Enchant))?.Id;

        /// <summary>Strips the enchantment. The scroll is not returned (it was spent), the gear is untouched.</summary>
        public FitResult RemoveEnchant(string gearKey, string atNpcId)
        {
            if (CategoryOf(gearKey) == null) return FitResult.NotGear;
            if (!StationOk(_rules.Stations.Enchant, atNpcId)) return FitResult.WrongStation;
            var fit = Of(gearKey);
            if (fit?.Enchant == null) return FitResult.NothingToRemove;
            fit.Enchant = null;
            Prune(gearKey);
            Changed?.Invoke();
            return FitResult.Ok;
        }

        void Prune(string gearKey)
        {
            var f = Of(gearKey);
            if (f != null && f.Runes.Count == 0 && f.Enchant == null) _fittings.Remove(gearKey);
        }

        /// <summary>The rune word active on this gear, or null: the longest word whose runes sit side by side in order (ties: file order).</summary>
        public RuneWordData ActiveWord(string gearKey)
        {
            var fit = Of(gearKey);
            string cat = CategoryOf(gearKey);
            if (fit == null || cat == null) return null;
            var ids = fit.Runes.Select(ItemQuality.BaseId).ToList();
            RuneWordData best = null;
            foreach (var w in _rules.RuneWords)
            {
                if (!w.Fits.Contains(cat) || w.Runes.Count < 2 || w.Runes.Count > ids.Count) continue;
                if (best != null && w.Runes.Count <= best.Runes.Count) continue;
                for (int s = 0; s + w.Runes.Count <= ids.Count; s++)
                    if (w.Runes.Select((r, i) => ids[s + i] == r).All(x => x)) { best = w; break; }
            }
            return best;
        }

        static void Add(ref FittingBonus b, Dictionary<string, double> stats, double mult)
        {
            if (stats == null) return;
            foreach (var kv in stats)
            {
                double v = kv.Value * mult;
                switch (kv.Key)
                {
                    case "atk": b.Atk += v; break;
                    case "matk": b.Matk += v; break;
                    case "def": b.Def += v; break;
                    case "mdef": b.Mdef += v; break;
                    case "hp": b.Hp += v; break;
                    case "crit": b.Crit += v; break;
                }
            }
        }

        /// <summary>The extra stats this gear's runes, rune word and enchantment give. Sockets above the gear's current count (a lost Masterwork) simply do not count.</summary>
        public FittingBonus BonusFor(string gearKey)
        {
            var b = new FittingBonus();
            var fit = Of(gearKey);
            if (fit == null) return b;
            int sockets = SocketCount(gearKey);
            var used = fit.Runes.Take(sockets).ToList();
            double minMult = double.MaxValue;
            foreach (var key in used)
            {
                var rune = _rules.Rune(ItemQuality.BaseId(key));
                if (rune == null) continue;
                double m = _quality.StatMult(ItemQuality.Split(key).TierId);
                minMult = Math.Min(minMult, m);
                Add(ref b, rune.Stats, m);
            }
            var word = ActiveWord(gearKey);
            if (word != null && used.Count >= word.Runes.Count)
            {
                Add(ref b, word.Stats, minMult == double.MaxValue ? 1 : minMult);
                b.RuneWord = word.Id;
            }
            if (fit.Enchant != null)
            {
                var enc = _rules.EnchantmentOfScroll(ItemQuality.BaseId(fit.Enchant));
                if (enc != null)
                {
                    Add(ref b, enc.Stats, _quality.StatMult(ItemQuality.Split(fit.Enchant).TierId));
                    b.Element = enc.Element;
                }
            }
            return b;
        }

        // --- saves ---
        public Dictionary<string, GearFitting> Save() =>
            _fittings.ToDictionary(kv => kv.Key, kv => new GearFitting { Runes = new List<string>(kv.Value.Runes), Enchant = kv.Value.Enchant });

        /// <summary>Restores fittings from a save (null in old saves: none). Unknown gear is dropped; excess runes beyond the sockets are kept so a refit never loses them.</summary>
        public void Load(Dictionary<string, GearFitting> saved)
        {
            _fittings.Clear();
            foreach (var kv in saved ?? new Dictionary<string, GearFitting>())
            {
                if (CategoryOf(kv.Key) == null || kv.Value == null) continue;
                var f = new GearFitting { Runes = (kv.Value.Runes ?? new List<string>()).Where(r => _rules.Rune(ItemQuality.BaseId(r ?? "")) != null).ToList(), Enchant = kv.Value.Enchant };
                if (f.Enchant != null && _rules.EnchantmentOfScroll(ItemQuality.BaseId(f.Enchant)) == null) f.Enchant = null;
                if (f.Runes.Count > 0 || f.Enchant != null) _fittings[kv.Key] = f;
            }
            Changed?.Invoke();
        }
    }

    public enum AssembleResult { Ok, Unknown, WrongStation, RankTooLow, MissingPart, WrongPart }

    public sealed class AssembleReport
    {
        public AssembleResult Result { get; set; }
        public string OutputKey { get; set; }
        public string Quality { get; set; }
        public long XpGained { get; set; }
        public string RankedUp { get; set; }
    }

    /// <summary>
    /// Modular weapons: one blade part plus one hilt part make a weapon whose quality is the average tier of the two parts (rounded
    /// down), capped by the smith's rank and the station. Always succeeds once started; both parts are used up and nothing is rolled.
    /// </summary>
    public sealed class GearAssembler
    {
        readonly GearRules _rules;
        readonly QualityRules _quality;
        readonly Crafter _crafter;

        public GearAssembler(GearRules rules, QualityRules quality, Crafter crafter)
        {
            _rules = rules ?? new GearRules();
            _quality = quality ?? new QualityRules();
            _crafter = crafter;
        }

        public AssembleReport Assemble(string assemblyId, string bladeKey, string hiltKey, Inventory inv, string atNpcId)
        {
            var rep = new AssembleReport();
            var a = _rules.Assembly(assemblyId);
            if (a == null) { rep.Result = AssembleResult.Unknown; return rep; }
            string station = _rules.Stations.Assemble;
            if (_crafter != null && !_crafter.StationAvailable(station, atNpcId)) { rep.Result = AssembleResult.WrongStation; return rep; }
            var skills = _crafter?.Skills;
            if (skills != null && skills.IsKnown(a.Skill) && skills.RankIndex(a.LifeRank) > skills.RankIdx(a.Skill)) { rep.Result = AssembleResult.RankTooLow; return rep; }
            if (!a.Blades.Contains(ItemQuality.BaseId(bladeKey ?? "")) || !a.Hilts.Contains(ItemQuality.BaseId(hiltKey ?? ""))) { rep.Result = AssembleResult.WrongPart; return rep; }
            if (bladeKey == hiltKey || inv == null || inv.Count(bladeKey) < 1 || inv.Count(hiltKey) < 1) { rep.Result = AssembleResult.MissingPart; return rep; }

            inv.TryRemove(bladeKey); inv.TryRemove(hiltKey);
            int idx = (_quality.IndexOf(ItemQuality.Split(bladeKey).TierId) + _quality.IndexOf(ItemQuality.Split(hiltKey).TierId)) / 2;
            string rank = skills != null && skills.IsKnown(a.Skill) ? skills.Rank(a.Skill) : "F";
            int cap = Math.Min(Math.Min(_quality.RankCapIndex(rank), _quality.StationCapIndex(station)), _quality.MaxCraftableIndex);
            idx = Math.Max(0, Math.Min(idx, cap));
            string tier = _quality.TierAt(idx)?.Id ?? QualityRules.NormalId;
            rep.Quality = tier;
            rep.OutputKey = ItemQuality.Compose(a.Output, tier);
            inv.Add(rep.OutputKey);
            if (skills != null)
            {
                rep.XpGained = skills.OnCraft(new RecipeData { Id = a.Id, Skill = a.Skill, LifeRank = a.LifeRank, Xp = a.Xp }, out var up);
                rep.RankedUp = up;
            }
            rep.Result = AssembleResult.Ok;
            return rep;
        }
    }
}
