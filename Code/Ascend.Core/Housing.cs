using System;
using System.Collections.Generic;
using System.Linq;

namespace Ascend.Core
{
    // Optional housing and farming (12_Systems/housing_and_farming.md; 13_Production/housing_v6b_audit.md).
    // Data: Data/World/housing.json and Data/Items/crops.json. A personal home only: no guild, no staff, no upkeep, no decay.

    public sealed class HomeTierData
    {
        public string Id { get; set; }
        public string Name { get; set; }
        /// <summary>Guild rank needed to take the tier (systems.md section 6).</summary>
        public string Rank { get; set; } = "F";
        /// <summary>One-time price in copper.</summary>
        public long Cost { get; set; }
        /// <summary>How many different item stacks the storage chest holds.</summary>
        public int StorageStacks { get; set; }
        /// <summary>Crop plots.</summary>
        public int Plots { get; set; }
        public List<string> Features { get; set; } = new List<string>();
    }

    public sealed class HousingFile
    {
        public string Notes { get; set; }
        public List<HomeTierData> Tiers { get; set; } = new List<HomeTierData>();
        /// <summary>Seeds given once, the first time you own a tier with plots.</summary>
        public Dictionary<string, int> StarterSeeds { get; set; } = new Dictionary<string, int>();

        public HomeTierData Tier(string id) => Tiers.FirstOrDefault(t => t.Id == id);
        public int IndexOf(string id) => Tiers.FindIndex(t => t.Id == id);
    }

    public sealed class CropData
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string SeedItem { get; set; }
        public string YieldItem { get; set; }
        public int YieldCount { get; set; } = 1;
        /// <summary>Seeds returned by a harvest, so a crop never needs buying twice.</summary>
        public int SeedsBack { get; set; } = 1;
        /// <summary>In-game hours from planting to ready (a game day is 24 hours, 90 real minutes).</summary>
        public double GrowHours { get; set; } = 24;
        /// <summary>Farming rank letter of the crop (feeds the XP rule for gathering).</summary>
        public string Rank { get; set; } = "F";
    }

    public sealed class CropFile
    {
        public string Notes { get; set; }
        public string Skill { get; set; } = "farming";
        /// <summary>Farming life rank letter to the quality tier of the harvest (deterministic, no luck).</summary>
        public Dictionary<string, string> QualityByRank { get; set; } = new Dictionary<string, string>();
        public List<CropData> Crops { get; set; } = new List<CropData>();

        public CropData Crop(string id) => Crops.FirstOrDefault(c => c.Id == id);
    }

    public sealed class PlotSave
    {
        public string Crop { get; set; }
        public double PlantedHour { get; set; }
    }

    public sealed class HomeSave
    {
        public string Tier { get; set; }
        public List<PlotSave> Plots { get; set; } = new List<PlotSave>();
        public Dictionary<string, int> Storage { get; set; } = new Dictionary<string, int>();
        public bool StarterSeedsGiven { get; set; }
    }

    public enum UpgradeResult { Ok, Unknown, AlreadyHere, NotNext, RankTooLow, NotEnoughMoney }
    public enum StorageResult { Ok, NotEnough, Full, BadCount }
    public enum PlantResult { Ok, NoSuchPlot, Occupied, UnknownCrop, NoSeed, BadTime }
    public enum PlotState { Empty, Growing, Ready }

    public sealed class HarvestReport
    {
        public bool Ok { get; set; }
        public string OutputKey { get; set; }
        public int Count { get; set; }
        public string Quality { get; set; }
        public int SeedsBack { get; set; }
        public long XpGained { get; set; }
        public string RankedUp { get; set; }
    }

    /// <summary>
    /// Your home: the tier you own, the storage chest and the crop plots. Crops grow in in-game hours and stay ready for as long as you
    /// are away; nothing withers, spoils or rots, and waiting gives no bonus or penalty. There is no upkeep and no daily chore.
    /// Time is an absolute in-game hour (day * 24 + hour), the same clock the gathering nodes use.
    /// </summary>
    public sealed class Home
    {
        public const string BaseTierId = "inn_room";

        readonly HousingFile _housing;
        readonly CropFile _crops;
        readonly QualityRules _quality;
        readonly LifeSkills _skills;
        readonly Dictionary<string, int> _storage = new Dictionary<string, int>();
        readonly List<PlotSave> _plots = new List<PlotSave>();
        string _tier;
        bool _starterGiven;

        public Home(HousingFile housing, CropFile crops = null, QualityRules quality = null, LifeSkills skills = null)
        {
            _housing = housing ?? new HousingFile();
            _crops = crops ?? new CropFile();
            _quality = quality ?? new QualityRules();
            _skills = skills;
            _tier = _housing.Tiers.Count > 0 ? _housing.Tiers[0].Id : BaseTierId;
            ResizePlots();
        }

        public event Action Changed;

        public HomeTierData Tier => _housing.Tier(_tier) ?? new HomeTierData { Id = _tier };
        public HomeTierData NextTier { get { int i = _housing.IndexOf(_tier); return i >= 0 && i + 1 < _housing.Tiers.Count ? _housing.Tiers[i + 1] : null; } }
        public IReadOnlyDictionary<string, int> Storage => _storage;
        public int PlotCount => _plots.Count;
        public bool Has(string feature) => Tier.Features.Contains(feature);

        void ResizePlots()
        {
            int want = Tier.Plots;
            while (_plots.Count < want) _plots.Add(new PlotSave());
            // Plots are never taken away: a tier can only go up, and an odd save keeps what it had.
        }

        /// <summary>Moves up one tier: needs the guild rank and the price. Tiers are taken in order, one at a time.</summary>
        public UpgradeResult Upgrade(string tierId, string guildRank, Inventory inv)
        {
            var t = _housing.Tier(tierId);
            if (t == null) return UpgradeResult.Unknown;
            int have = _housing.IndexOf(_tier), want = _housing.IndexOf(tierId);
            if (want <= have) return UpgradeResult.AlreadyHere;
            if (want != have + 1) return UpgradeResult.NotNext;
            if (!Rank.TryParse(guildRank ?? "F", out var mine) || !Rank.TryParse(t.Rank, out var needed) || mine < needed) return UpgradeResult.RankTooLow;
            if (inv == null || !inv.TrySpend(t.Cost)) return UpgradeResult.NotEnoughMoney;
            _tier = tierId;
            ResizePlots();
            if (t.Plots > 0 && !_starterGiven)
            {
                _starterGiven = true;
                foreach (var kv in _housing.StarterSeeds) inv.Add(kv.Key, kv.Value);
            }
            Changed?.Invoke();
            return UpgradeResult.Ok;
        }

        // --- storage ---
        public int StacksUsed => _storage.Count;
        public int Stored(string key) => _storage.TryGetValue(key ?? "", out var n) ? n : 0;

        public StorageResult Deposit(string key, int count, Inventory inv)
        {
            if (count < 1 || string.IsNullOrEmpty(key)) return StorageResult.BadCount;
            if (inv == null || inv.Count(key) < count) return StorageResult.NotEnough;
            if (!_storage.ContainsKey(key) && _storage.Count >= Tier.StorageStacks) return StorageResult.Full;
            if (Stored(key) > int.MaxValue - count) return StorageResult.Full; // never wrap a stack
            inv.TryRemove(key, count);
            _storage[key] = Stored(key) + count;
            Changed?.Invoke();
            return StorageResult.Ok;
        }

        public StorageResult Withdraw(string key, int count, Inventory inv)
        {
            if (count < 1 || string.IsNullOrEmpty(key) || inv == null) return StorageResult.BadCount;
            if (Stored(key) < count) return StorageResult.NotEnough;
            if (inv.Count(key) > int.MaxValue - count) return StorageResult.Full; // the bag cannot hold that many; nothing moves
            _storage[key] -= count;
            if (_storage[key] == 0) _storage.Remove(key);
            inv.Add(key, count);
            Changed?.Invoke();
            return StorageResult.Ok;
        }

        // --- farming ---
        public PlotState State(int plot, double nowHour)
        {
            if (plot < 0 || plot >= _plots.Count || _plots[plot].Crop == null) return PlotState.Empty;
            var c = _crops.Crop(_plots[plot].Crop);
            return c != null && nowHour >= _plots[plot].PlantedHour + c.GrowHours ? PlotState.Ready : PlotState.Growing;
        }

        public string CropOf(int plot) => plot >= 0 && plot < _plots.Count ? _plots[plot].Crop : null;

        /// <summary>In-game hours until the plot is ready (0 when ready or empty).</summary>
        public double HoursLeft(int plot, double nowHour)
        {
            if (State(plot, nowHour) != PlotState.Growing) return 0;
            var c = _crops.Crop(_plots[plot].Crop);
            // A clock that reads earlier than the planting hour (a reset clock, an old save) counts as just planted.
            return Math.Min(c.GrowHours, _plots[plot].PlantedHour + c.GrowHours - nowHour);
        }

        public PlantResult Plant(int plot, string cropId, Inventory inv, double nowHour)
        {
            if (plot < 0 || plot >= _plots.Count) return PlantResult.NoSuchPlot;
            if (double.IsNaN(nowHour) || double.IsInfinity(nowHour)) return PlantResult.BadTime;
            var c = _crops.Crop(cropId);
            if (c == null) return PlantResult.UnknownCrop;
            if (_plots[plot].Crop != null) return PlantResult.Occupied;
            if (inv == null || !inv.TryRemove(c.SeedItem)) return PlantResult.NoSeed;
            _plots[plot].Crop = c.Id;
            _plots[plot].PlantedHour = nowHour;
            Changed?.Invoke();
            return PlantResult.Ok;
        }

        /// <summary>Picks a ready crop. Quality is set by the farming rank alone. Returns Ok=false when the plot is empty or still growing.</summary>
        public HarvestReport Harvest(int plot, Inventory inv, double nowHour)
        {
            var rep = new HarvestReport();
            if (State(plot, nowHour) != PlotState.Ready || inv == null) return rep;
            var c = _crops.Crop(_plots[plot].Crop);
            string rank = _skills != null && _skills.IsKnown(_crops.Skill) ? _skills.Rank(_crops.Skill) : "F";
            string tier = _crops.QualityByRank != null && _crops.QualityByRank.TryGetValue(rank, out var q) ? q : QualityRules.NormalId;
            if (_quality.IndexOf(tier) > _quality.MaxCraftableIndex) tier = QualityRules.NormalId;
            rep.Quality = tier;
            rep.OutputKey = ItemQuality.Compose(c.YieldItem, tier);
            rep.Count = Math.Max(1, c.YieldCount);
            rep.SeedsBack = Math.Max(0, c.SeedsBack);
            inv.Add(rep.OutputKey, rep.Count);
            if (rep.SeedsBack > 0) inv.Add(c.SeedItem, rep.SeedsBack);
            if (_skills != null) { rep.XpGained = _skills.OnGather(_crops.Skill, c.Rank, out var up); rep.RankedUp = up; }
            _plots[plot].Crop = null; _plots[plot].PlantedHour = 0;
            rep.Ok = true;
            Changed?.Invoke();
            return rep;
        }

        /// <summary>Pulls a crop that is still growing and gives the seed back. No penalty. A ripe crop is refused (harvest it instead) so a mis-click never costs a yield.</summary>
        public bool Clear(int plot, Inventory inv, double nowHour)
        {
            if (plot < 0 || plot >= _plots.Count || _plots[plot].Crop == null || inv == null) return false;
            if (State(plot, nowHour) == PlotState.Ready) return false;
            var c = _crops.Crop(_plots[plot].Crop);
            if (c != null) inv.Add(c.SeedItem);
            _plots[plot].Crop = null; _plots[plot].PlantedHour = 0;
            Changed?.Invoke();
            return true;
        }

        // --- saves ---
        public HomeSave Save() => new HomeSave
        {
            Tier = _tier,
            Plots = _plots.Select(p => new PlotSave { Crop = p.Crop, PlantedHour = p.PlantedHour }).ToList(),
            Storage = new Dictionary<string, int>(_storage),
            StarterSeedsGiven = _starterGiven
        };

        /// <summary>Restores from a save. Null (an old save) means the base tier with nothing stored. Only invalid entries (bad numbers, empty keys) are dropped; unknown tiers and crops are kept as they are.</summary>
        public void Load(HomeSave s)
        {
            _storage.Clear(); _plots.Clear();
            // An unknown tier id is kept (a renamed tier must not downgrade the player or drop their things); the first tier is only the default for a missing one.
            _tier = !string.IsNullOrEmpty(s?.Tier) ? s.Tier : (_housing.Tiers.Count > 0 ? _housing.Tiers[0].Id : BaseTierId);
            _starterGiven = s?.StarterSeedsGiven ?? false;
            foreach (var p in s?.Plots ?? new List<PlotSave>())
            {
                bool ok = p != null && p.Crop != null && !double.IsNaN(p.PlantedHour) && !double.IsInfinity(p.PlantedHour);
                _plots.Add(ok ? new PlotSave { Crop = p.Crop, PlantedHour = p.PlantedHour } : new PlotSave());
            }
            ResizePlots();
            foreach (var kv in s?.Storage ?? new Dictionary<string, int>())
                if (!string.IsNullOrEmpty(kv.Key) && kv.Value > 0) _storage[kv.Key] = kv.Value; // the cap limits new deposits only; a load never drops stored items
            Changed?.Invoke();
        }
    }
}
