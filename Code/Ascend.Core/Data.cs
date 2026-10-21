using System;
using System.Collections.Generic;
using System.Linq;

namespace Ascend.Core
{
    // Plain data models mirroring Data/*.json (see Data/Schemas). Property names match the JSON
    // case-insensitively, so any JSON library (System.Text.Json in tests, Newtonsoft in Unity) can fill them.

    public sealed class RegionData
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<string> Biomes { get; set; } = new List<string>();
        public string RankMin { get; set; }
        public string RankMax { get; set; }
        public int Ring { get; set; }
        public string Layer { get; set; }
        public List<string> AllowedFamilies { get; set; }
    }

    public sealed class StatBlock
    {
        public int Hp { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }
        public int Matk { get; set; }
        public int Mdef { get; set; }
        public int Spd { get; set; }
    }

    public sealed class SpeciesData
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string FamilyKey { get; set; }
        public string Family { get; set; }
        public string Type { get; set; }
        public string Tier { get; set; }
        public string BaseSpeciesId { get; set; }
        public string Rank { get; set; }
        public int Level { get; set; }
        public int Menace { get; set; }
        public string Element { get; set; }
        public string Weakness { get; set; }
        public double SizeMeters { get; set; }
        public string RigId { get; set; }
        public string AnimSetId { get; set; }
        public string Behavior { get; set; }
        public string AiPattern { get; set; }
        public StatBlock Stats { get; set; } = new StatBlock();
        public int Xp { get; set; }
        public int Gold { get; set; }
        public List<string> AttackIds { get; set; } = new List<string>();
        public bool IsUnique { get; set; }
        public int Ring { get; set; }
        public List<string> Habitats { get; set; } = new List<string>();
        public string LootTableId { get; set; }
        public string Look { get; set; }

        public Rank ParsedRank => Ascend.Core.Rank.Parse(Rank);
        public Element ParsedElement => ParseElement(Element);
        public Element ParsedWeakness => ParseElement(Weakness);

        static Element ParseElement(string s) =>
            Enum.TryParse(s, out Element e) ? e : Ascend.Core.Element.None;
    }

    public sealed class AttackData
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Kind { get; set; }
        public double Power { get; set; }
        public double CooldownSec { get; set; }
        public string Telegraph { get; set; }
        public string Element { get; set; }
    }

    public sealed class LootEntry
    {
        public string ItemId { get; set; }
        public int Weight { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
    }

    public sealed class LootTableData
    {
        public string Id { get; set; }
        public string Family { get; set; }
        public string Rank { get; set; }
        public List<LootEntry> Entries { get; set; } = new List<LootEntry>();
    }

    public sealed class ItemData
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Rank { get; set; }
        public string Rarity { get; set; }
        public int Value { get; set; }
    }

    /// <summary>All loaded game data, indexed by ID. Loading (file IO + JSON) happens in the host (Unity or tests).</summary>
    public sealed class GameDatabase
    {
        public IReadOnlyDictionary<string, RegionData> Regions { get; }
        public IReadOnlyDictionary<string, SpeciesData> Species { get; }
        public IReadOnlyDictionary<string, AttackData> Attacks { get; }
        public IReadOnlyDictionary<string, LootTableData> LootTables { get; }
        public IReadOnlyDictionary<string, ItemData> Items { get; }
        public CombatTuning Tuning { get; }

        public GameDatabase(IEnumerable<RegionData> regions, IEnumerable<SpeciesData> species, IEnumerable<AttackData> attacks,
            IEnumerable<LootTableData> loot, IEnumerable<ItemData> items, CombatTuning tuning)
        {
            Regions = Index(regions, r => r.Id, "region");
            Species = Index(species, s => s.Id, "species");
            Attacks = Index(attacks, a => a.Id, "attack");
            LootTables = Index(loot, l => l.Id, "loot table");
            Items = Index(items, i => i.Id, "item");
            Tuning = tuning ?? throw new ArgumentNullException(nameof(tuning));
        }

        public IEnumerable<SpeciesData> SpeciesInRing(int ring) => Species.Values.Where(s => s.Ring == ring);
        public IEnumerable<SpeciesData> SpeciesInRegion(string regionId) => Species.Values.Where(s => s.Habitats.Contains(regionId));

        static Dictionary<string, T> Index<T>(IEnumerable<T> rows, Func<T, string> id, string what)
        {
            var d = new Dictionary<string, T>();
            foreach (var r in rows ?? Enumerable.Empty<T>())
            {
                var key = id(r);
                if (string.IsNullOrEmpty(key)) throw new InvalidOperationException($"{what} without id");
                if (d.ContainsKey(key)) throw new InvalidOperationException($"duplicate {what} id \"{key}\"");
                d[key] = r;
            }
            return d;
        }
    }
}
