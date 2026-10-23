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
        /// <summary>Spawn level spread [min, max].</summary>
        public List<int> LevelRange { get; set; } = new List<int>();
        /// <summary>Boss HP multiplier (1 for normal monsters; Tyrants 5, unique beings 6, EX 15).</summary>
        public double BossHpMult { get; set; } = 1;
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
        public long EffectiveMaxHp => (long)Math.Round(Stats.Hp * Math.Max(1, BossHpMult));
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
        /// <summary>Drop chance 0..1 (0.001 = a 0.1% chase drop).</summary>
        public double Chance { get; set; }
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
        /// <summary>Raw item stats (atk, matk, def, crit, spd, applyElement…); values may be numbers or text.</summary>
        public Dictionary<string, object> Stats { get; set; } = new Dictionary<string, object>();

        /// <summary>A numeric stat, or 0 when absent or not a number (works with any JSON library's value type).</summary>
        public double Stat(string key)
        {
            if (Stats == null || !Stats.TryGetValue(key, out var v) || v == null) return 0;
            if (v is IConvertible c && !(v is string)) return c.ToDouble(System.Globalization.CultureInfo.InvariantCulture);
            return double.TryParse(v.ToString(), System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out var d) ? d : 0;
        }
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
        public IReadOnlyDictionary<string, QuestData> Quests { get; }
        public IReadOnlyDictionary<string, NpcData> Npcs { get; }
        public IReadOnlyDictionary<string, ClassData> Classes { get; }
        public IReadOnlyDictionary<string, StoryFlagData> StoryFlags { get; }
        public ProgressionRules Progression { get; }
        public IReadOnlyDictionary<string, WeeklyQuestData> WeeklyQuests { get; }
        public IReadOnlyDictionary<string, InnData> Inns { get; }
        /// <summary>Per-species motion and behaviour from Data/Monsters/motion.json (empty if not loaded).</summary>
        public IReadOnlyDictionary<string, SpeciesMotion> Motion { get; }

        public GameDatabase(IEnumerable<RegionData> regions, IEnumerable<SpeciesData> species, IEnumerable<AttackData> attacks,
            IEnumerable<LootTableData> loot, IEnumerable<ItemData> items, CombatTuning tuning,
            IEnumerable<SiegeWaveData> siegeWaves = null, WorldTuning world = null,
            IEnumerable<QuestData> quests = null, IEnumerable<NpcData> npcs = null, IEnumerable<ClassData> classes = null,
            IEnumerable<StoryFlagData> flags = null, ProgressionRules progression = null,
            IEnumerable<WeeklyQuestData> weeklyBoard = null, IEnumerable<InnData> inns = null, MotionFile motion = null)
        {
            Motion = Index(motion?.Species, m => m.SpeciesId, "species motion");
            WeeklyQuests = Index(weeklyBoard, q => q.Id, "weekly quest");
            Inns = Index(inns, i => i.Id, "inn");
            Quests = Index(quests, q => q.Id, "quest");
            Npcs = Index(npcs, n => n.Id, "npc");
            Classes = Index(classes, c => c.Id, "class");
            StoryFlags = Index(flags, x => x.Id, "story flag");
            Progression = progression ?? new ProgressionRules();
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
