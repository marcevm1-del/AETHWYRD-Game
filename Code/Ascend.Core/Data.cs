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
        // Regional Siege & Liberation
        public string TyrantSpeciesId { get; set; }
        public string SiegeFaction { get; set; }
        public List<string> DefenceSettlements { get; set; } = new List<string>();
        public string InitialState { get; set; }
        public bool NoSiege { get; set; }
        public string NoSiegeReason { get; set; }
    }

    public sealed class SiegeUnit { public string SpeciesId { get; set; } public int Count { get; set; } }
    public sealed class SiegeWave { public int Wave { get; set; } public List<SiegeUnit> Units { get; set; } = new List<SiegeUnit>(); public string LieutenantSpeciesId { get; set; } }
    public sealed class SiegeEscalation { public int MaxStep { get; set; } public double CountGrowthPerStep { get; set; } public double EliteChancePerStep { get; set; } }

    /// <summary>Mirror of one entry in Data/World/siege_waves.json.</summary>
    public sealed class SiegeWaveData
    {
        public string Id { get; set; }
        public string RegionId { get; set; }
        public string Faction { get; set; }
        public bool FactionMixed { get; set; }
        public string RankMin { get; set; }
        public string RankMax { get; set; }
        public string TyrantSpeciesId { get; set; }
        public List<SiegeWave> Waves { get; set; } = new List<SiegeWave>();
        public SiegeEscalation Escalation { get; set; } = new SiegeEscalation();
        public List<double> TargetMinutes { get; set; } = new List<double>();

        /// <summary>Unit count for a wave unit at an escalation step (capped at MaxStep).</summary>
        public int ScaledCount(SiegeUnit unit, int escalation)
        {
            int step = Math.Max(0, Math.Min(Escalation.MaxStep, escalation));
            return (int)Math.Round(unit.Count * (1 + Escalation.CountGrowthPerStep * step), MidpointRounding.AwayFromZero);
        }
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
        public bool IsTyrant { get; set; }
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
        public IReadOnlyDictionary<string, SiegeWaveData> SiegeWaves { get; }
        public WorldTuning World { get; }

        public GameDatabase(IEnumerable<RegionData> regions, IEnumerable<SpeciesData> species, IEnumerable<AttackData> attacks,
            IEnumerable<LootTableData> loot, IEnumerable<ItemData> items, CombatTuning tuning,
            IEnumerable<SiegeWaveData> siegeWaves = null, WorldTuning world = null)
        {
            SiegeWaves = Index(siegeWaves, w => w.RegionId, "siege wave set");
            World = world ?? new WorldTuning();
            Regions = Index(regions, r => r.Id, "region");
            Species = Index(species, s => s.Id, "species");
            Attacks = Index(attacks, a => a.Id, "attack");
            LootTables = Index(loot, l => l.Id, "loot table");
            Items = Index(items, i => i.Id, "item");
            Tuning = tuning ?? throw new ArgumentNullException(nameof(tuning));
        }

        public IEnumerable<SpeciesData> SpeciesInRing(int ring) => Species.Values.Where(s => s.Ring == ring);
        public IEnumerable<SpeciesData> SpeciesInRegion(string regionId) => Species.Values.Where(s => s.Habitats.Contains(regionId));
        public SpeciesData TyrantOf(string regionId) =>
            Regions.TryGetValue(regionId, out var r) && r.TyrantSpeciesId != null && Species.TryGetValue(r.TyrantSpeciesId, out var t) ? t : null;

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
