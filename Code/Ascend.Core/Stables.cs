using System;
using System.Collections.Generic;
using System.Linq;

namespace Ascend.Core
{
    // Stables and the sanctuary (12_Systems/stables.md; 13_Production/stables_v8_audit.md). Data: Data/Companions/stables.json.
    // Follows Canon: 3 active partners always, the rest on the ranch with capacity growing with home upgrades (systems.md Taming Roster),
    // ranch breeding that passes on markings (Big Upgrade 27) and egg nests hatched at the ranch at Bond 3 (borrowed_features.md 12).
    // Feeding is optional and nothing here punishes absence: no hunger, sickness, loss or escape.

    public sealed class FeedingRules
    {
        public double CooldownHours { get; set; } = 24;
        public int AssistsPerFeed { get; set; } = 1;
    }

    public sealed class BreedingRules
    {
        public string RequiresFeature { get; set; } = "barn";
        public int MinBond { get; set; } = 3;
        public double PairCooldownHours { get; set; } = 72;
        public double IncubateHours { get; set; } = 48;
        public int HatchBond { get; set; } = 3;
        public double CrossElementChance { get; set; } = 0.15;
        /// <summary>After this many eligible breedings without a cross-element hatchling, the next one is guaranteed.</summary>
        public int CrossPityBreedings { get; set; } = 4;
        public List<string> HeritableMarkings { get; set; } = new List<string>();
        public double InheritMarkingChance { get; set; } = 0.5;
        public double NestMarkingChance { get; set; } = 0.1;
        /// <summary>After this many nest eggs without a marking, the next one carries one.</summary>
        public int MarkingPityEggs { get; set; } = 5;
        /// <summary>Eggs you can hold: max(EggFloor, boarding capacity / BoardingSlotsPerEgg).</summary>
        public int BoardingSlotsPerEgg { get; set; } = 2;
        public int EggFloor { get; set; } = 2;
    }

    public sealed class SanctuaryLevelData
    {
        public int MinSpecies { get; set; }
        public string Name { get; set; }
    }

    public sealed class StablesFile
    {
        public string Notes { get; set; }
        /// <summary>Home tier id to how many partners can be boarded at home. A missing tier counts as 0.</summary>
        public Dictionary<string, int> BoardingByTier { get; set; } = new Dictionary<string, int>();
        public FeedingRules Feeding { get; set; } = new FeedingRules();
        public BreedingRules Breeding { get; set; } = new BreedingRules();
        public List<SanctuaryLevelData> Sanctuary { get; set; } = new List<SanctuaryLevelData>();
    }

    public sealed class EggSave
    {
        public string Id { get; set; }
        public string SpeciesId { get; set; }
        public string Marking { get; set; }
        /// <summary>Absolute in-game hour it can hatch. It waits for you forever once ready.</summary>
        public double ReadyHour { get; set; }
    }

    public sealed class StablesSave
    {
        public List<EggSave> Eggs { get; set; } = new List<EggSave>();
        public Dictionary<string, double> LastFed { get; set; } = new Dictionary<string, double>();
        public Dictionary<string, double> PairReady { get; set; } = new Dictionary<string, double>();
        public List<string> SpeciesSeen { get; set; } = new List<string>();
        /// <summary>The marking collection: "speciesId:Marking".</summary>
        public List<string> Markings { get; set; } = new List<string>();
        public int SinceCross { get; set; }
        public int SinceMarking { get; set; }
        public int NextEgg { get; set; } = 1;
        public string MountId { get; set; }
    }

    public enum BoardResult { Ok, NotYours, NoStable, Full }
    public enum FeedResult { Ok, NotYours, NoItem, NotFavouriteFood, TooSoon, MaxBond }
    public enum MountResult { Ok, NotYours, NotMountable, RankTooLow }
    public enum BreedResult { Ok, NoStable, NotYours, NotBoarded, SameCreature, NotCompatible, BondTooLow, PairResting, EggsFull }
    public enum HatchResult { Ok, NoSuchEgg, NotReady }

    public sealed class BreedReport
    {
        public BreedResult Result { get; set; }
        public EggSave Egg { get; set; }
        public bool CrossElement { get; set; }
    }

    /// <summary>
    /// The home stable, the guild kennel and the sanctuary. Partners are in one of three places: travelling (Active, at most 3), boarded at
    /// home (AtHome, limited by the home tier) or in the guild kennel (everyone else, no limit, so taming is never refused). Time is an
    /// absolute in-game hour (day * 24 + hour).
    /// </summary>
    public sealed class Stables
    {
        readonly StablesFile _rules;
        readonly PartnerRoster _roster;
        readonly TamingTuning _taming;
        readonly Home _home;
        readonly IReadOnlyDictionary<string, SpeciesData> _species;
        readonly MountTable _mounts;
        readonly List<EggSave> _eggs = new List<EggSave>();
        readonly Dictionary<string, double> _lastFed = new Dictionary<string, double>();
        readonly Dictionary<string, double> _pairReady = new Dictionary<string, double>();
        readonly HashSet<string> _seen = new HashSet<string>();
        readonly HashSet<string> _markings = new HashSet<string>();
        int _sinceCross, _sinceMarking, _nextEgg = 1;
        string _mountId;

        public Stables(StablesFile rules, PartnerRoster roster, TamingTuning taming, Home home, IReadOnlyDictionary<string, SpeciesData> species, MountTable mounts = null)
        {
            _rules = rules ?? new StablesFile();
            _roster = roster ?? throw new ArgumentNullException(nameof(roster));
            _taming = taming ?? throw new ArgumentNullException(nameof(taming));
            _home = home ?? throw new ArgumentNullException(nameof(home));
            _species = species ?? new Dictionary<string, SpeciesData>();
            _mounts = MountTable.OrDefault(mounts);
        }

        public event Action Changed;
        public IReadOnlyList<EggSave> Eggs => _eggs;
        public int MarkingsCollected => _markings.Count;

        // --- capacity ---
        /// <summary>How many partners the home can board (needs the barn feature; 0 before the Home and Garden tier).</summary>
        public int Capacity => _home.Has(_rules.Breeding.RequiresFeature) && _rules.BoardingByTier.TryGetValue(_home.Tier.Id, out var n) ? n : 0;
        public IEnumerable<PartnerData> Boarded => _roster.All.Where(p => p.AtHome);
        public IEnumerable<PartnerData> Kennel => _roster.All.Where(p => !p.Active && !p.AtHome);
        public int FreeSlots => Math.Max(0, Capacity - Boarded.Count());
        public int EggCapacity => Math.Max(_rules.Breeding.EggFloor, Capacity / Math.Max(1, _rules.Breeding.BoardingSlotsPerEgg));

        // --- roster rules ---
        /// <summary>Sends a partner to the home stable. A travelling partner stands down first (it never counts twice).</summary>
        public BoardResult Board(PartnerData p)
        {
            if (p == null || !_roster.All.Contains(p)) return BoardResult.NotYours;
            if (p.AtHome) return BoardResult.Ok;
            if (Capacity <= 0) return BoardResult.NoStable;
            if (FreeSlots <= 0) return BoardResult.Full;
            p.Active = false; p.AtHome = true;
            NoteSpecies(p.SpeciesId);
            Changed?.Invoke();
            return BoardResult.Ok;
        }

        /// <summary>Moves a partner to the guild kennel (unlimited). Nothing is lost; it can be called back any time.</summary>
        public bool Kenneled(PartnerData p)
        {
            if (p == null || !_roster.All.Contains(p)) return false;
            p.Active = false; p.AtHome = false;
            Changed?.Invoke();
            return true;
        }

        /// <summary>Brings a partner along (only if one of the 3 travelling places is free).</summary>
        public bool Activate(PartnerData p)
        {
            if (p == null || !_roster.All.Contains(p)) return false;
            if (p.Active) return true;
            if (!_roster.SetActive(p, true)) return false;
            p.AtHome = false;
            Changed?.Invoke();
            return true;
        }

        /// <summary>Puts partners above the home capacity (a smaller tier in an odd save) into the kennel. Never releases anyone.</summary>
        public void Reconcile()
        {
            int cap = Capacity;
            foreach (var p in Boarded.Skip(cap).ToList()) p.AtHome = false;
            foreach (var p in _roster.All.Where(x => x.Active && x.AtHome)) p.AtHome = false;
        }

        /// <summary>Lets a partner go. The sanctuary remembers the species, so it never shrinks.</summary>
        public void Release(PartnerData p)
        {
            if (p == null || !_roster.All.Contains(p)) return;
            NoteSpecies(p.SpeciesId);
            if (_mountId == p.Id) _mountId = null;
            _roster.Release(p);
            Changed?.Invoke();
        }

        public void NoteSpecies(string speciesId) { if (!string.IsNullOrEmpty(speciesId)) _seen.Add(speciesId); }

        // --- feeding (optional) ---
        public string FavouriteOf(PartnerData p) =>
            p != null && _species.TryGetValue(p.SpeciesId ?? "", out var sp) ? TamingRules.FavouriteFood(sp, _taming) : null;

        /// <summary>
        /// A treat. Only the species' favourite food is taken. Once a day per partner it counts as a shared moment toward Bond. Too soon, or at max Bond,
        /// the item is not used up. There is no hunger: a partner never needs feeding and never suffers for not being fed.
        /// </summary>
        public FeedResult Feed(PartnerData p, string itemId, Inventory inv, double nowHour)
        {
            if (p == null || !_roster.All.Contains(p)) return FeedResult.NotYours;
            if (itemId == null || itemId != FavouriteOf(p)) return FeedResult.NotFavouriteFood;
            if (inv == null || inv.Count(itemId) < 1) return FeedResult.NoItem;
            if (p.Bond >= _taming.MaxBond) return FeedResult.MaxBond;
            if (_lastFed.TryGetValue(p.Id ?? "", out var last) && nowHour >= last && nowHour - last < _rules.Feeding.CooldownHours) return FeedResult.TooSoon;
            inv.TryRemove(itemId);
            _lastFed[p.Id ?? ""] = nowHour;
            for (int i = 0; i < _rules.Feeding.AssistsPerFeed; i++) Partners.Assist(p, _taming);
            Changed?.Invoke();
            return FeedResult.Ok;
        }

        // --- mounts (ground only; mounts.json already excludes flying and aquatic species) ---
        public string MountFamilyOf(string speciesId) =>
            _mounts.Families.Where(kv => kv.Value != null && kv.Value.Species.Contains(speciesId)).Select(kv => kv.Key).FirstOrDefault();

        public PartnerData Mount => _roster.ById(_mountId);

        public MountResult SetMount(PartnerData p, string playerRank)
        {
            if (p == null || !_roster.All.Contains(p)) return MountResult.NotYours;
            string fam = MountFamilyOf(p.SpeciesId);
            if (fam == null) return MountResult.NotMountable;
            if (!_mounts.CanMount(fam, playerRank ?? "F")) return MountResult.RankTooLow;
            _mountId = p.Id;
            Changed?.Invoke();
            return MountResult.Ok;
        }

        public void ClearMount() { _mountId = null; Changed?.Invoke(); }

        // --- sanctuary ---
        public int SpeciesKnown => _seen.Union(_roster.All.Select(p => p.SpeciesId)).Where(x => !string.IsNullOrEmpty(x)).Distinct().Count();

        /// <summary>The sanctuary grows with the number of different creatures you have cared for. Cosmetic: it costs nothing and never shrinks.</summary>
        public SanctuaryLevelData Sanctuary =>
            _rules.Sanctuary.Where(l => l.MinSpecies <= SpeciesKnown).OrderByDescending(l => l.MinSpecies).FirstOrDefault() ?? new SanctuaryLevelData { Name = "Paddock" };

        // --- eggs and breeding ---
        string BaseOf(SpeciesData s) => string.IsNullOrEmpty(s.BaseSpeciesId) ? s.Id : s.BaseSpeciesId;

        static string PairKey(PartnerData a, PartnerData b) =>
            string.CompareOrdinal(a.Id, b.Id) <= 0 ? a.Id + "|" + b.Id : b.Id + "|" + a.Id;

        /// <summary>Two boarded partners of one family tree make an egg that carries a heritable marking and may be a cross-element hatchling. Deterministic from the seed and the counters; the pity counters guarantee both rare outcomes.</summary>
        public BreedReport Breed(PartnerData a, PartnerData b, double nowHour, ulong seed)
        {
            var rep = new BreedReport();
            var br = _rules.Breeding;
            if (Capacity <= 0) { rep.Result = BreedResult.NoStable; return rep; }
            if (a == null || b == null || !_roster.All.Contains(a) || !_roster.All.Contains(b)) { rep.Result = BreedResult.NotYours; return rep; }
            if (a == b) { rep.Result = BreedResult.SameCreature; return rep; }
            if (!a.AtHome || !b.AtHome) { rep.Result = BreedResult.NotBoarded; return rep; }
            if (!_species.TryGetValue(a.SpeciesId ?? "", out var sa) || !_species.TryGetValue(b.SpeciesId ?? "", out var sb)
                || sa.IsUnique || sa.IsTyrant || sb.IsUnique || sb.IsTyrant || BaseOf(sa) != BaseOf(sb)) { rep.Result = BreedResult.NotCompatible; return rep; }
            if (a.Bond < br.MinBond || b.Bond < br.MinBond) { rep.Result = BreedResult.BondTooLow; return rep; }
            string key = PairKey(a, b);
            if (_pairReady.TryGetValue(key, out var ready) && nowHour < ready) { rep.Result = BreedResult.PairResting; return rep; }
            if (_eggs.Count >= EggCapacity) { rep.Result = BreedResult.EggsFull; return rep; }

            var rng = DeterministicRandom.For(seed, "breed", key, _nextEgg);
            var species = sa;
            bool eligibleCross = sa.Element != sb.Element;
            if (sa.Id != sb.Id) species = rng.NextDouble() < 0.5 ? sa : sb;
            if (eligibleCross)
            {
                var maxRank = Rank.Parse(sa.Rank) > Rank.Parse(sb.Rank) ? Rank.Parse(sa.Rank) : Rank.Parse(sb.Rank);
                var pool = _species.Values.Where(x => BaseOf(x) == BaseOf(sa) && (x.VariantKind == "elemental" || x.Id == BaseOf(sa)) && x.Id != sa.Id && x.Id != sb.Id
                                                      && !x.IsUnique && !x.IsTyrant && Rank.Parse(x.Rank) <= maxRank).OrderBy(x => x.Id).ToList();
                if (pool.Count > 0)
                {
                    bool roll = rng.NextDouble() < br.CrossElementChance;
                    if (roll || _sinceCross + 1 >= br.CrossPityBreedings) { species = pool[(int)(rng.NextDouble() * pool.Count) % pool.Count]; rep.CrossElement = true; _sinceCross = 0; }
                    else _sinceCross++;
                }
            }
            string marking = null;
            var parentMarks = new[] { a.Marking, b.Marking }.Where(m => m != null && br.HeritableMarkings.Contains(m)).Distinct().ToList();
            if (parentMarks.Count > 0 && rng.NextDouble() < br.InheritMarkingChance) marking = parentMarks[(int)(rng.NextDouble() * parentMarks.Count) % parentMarks.Count];

            rep.Egg = NewEgg(species.Id, marking, nowHour + br.IncubateHours);
            _pairReady[key] = nowHour + br.PairCooldownHours;
            rep.Result = BreedResult.Ok;
            Changed?.Invoke();
            return rep;
        }

        /// <summary>An egg taken from a den (egg nests). Fails only when you hold too many eggs; the caller then leaves the egg in the nest. May carry a rare marking, guaranteed after a run of plain eggs.</summary>
        public EggSave AddNestEgg(string speciesId, double nowHour, ulong seed)
        {
            if (!_species.ContainsKey(speciesId ?? "") || _eggs.Count >= EggCapacity) return null;
            var br = _rules.Breeding;
            var rng = DeterministicRandom.For(seed, "nest", speciesId, _nextEgg);
            string marking = null;
            if (br.HeritableMarkings.Count > 0)
            {
                bool roll = rng.NextDouble() < br.NestMarkingChance;
                if (roll || _sinceMarking + 1 >= br.MarkingPityEggs) { marking = br.HeritableMarkings[(int)(rng.NextDouble() * br.HeritableMarkings.Count) % br.HeritableMarkings.Count]; _sinceMarking = 0; }
                else _sinceMarking++;
            }
            var egg = NewEgg(speciesId, marking, nowHour + br.IncubateHours);
            Changed?.Invoke();
            return egg;
        }

        EggSave NewEgg(string speciesId, string marking, double readyHour)
        {
            var egg = new EggSave { Id = "egg_" + _nextEgg.ToString("000"), SpeciesId = speciesId, Marking = marking, ReadyHour = readyHour };
            _nextEgg++;
            _eggs.Add(egg);
            return egg;
        }

        public bool Ready(EggSave egg, double nowHour) => egg != null && nowHour >= egg.ReadyHour;

        /// <summary>Hatches an egg into a hatchling at Bond 3 (it starts at home if there is room, else in the kennel, never travelling). An egg that is ready waits for you.</summary>
        public HatchResult Hatch(string eggId, double nowHour, string name, out PartnerData hatchling)
        {
            hatchling = null;
            var egg = _eggs.FirstOrDefault(e => e.Id == eggId);
            if (egg == null) return HatchResult.NoSuchEgg;
            if (!Ready(egg, nowHour)) return HatchResult.NotReady;
            _species.TryGetValue(egg.SpeciesId, out var sp);
            var p = _roster.Add(egg.SpeciesId, string.IsNullOrWhiteSpace(name) ? (sp?.Name ?? egg.SpeciesId) : name);
            p.Active = false;
            p.Bond = Math.Min(_taming.MaxBond, _rules.Breeding.HatchBond);
            p.Marking = egg.Marking;
            p.AtHome = FreeSlots > 0;
            _eggs.Remove(egg);
            NoteSpecies(egg.SpeciesId);
            if (egg.Marking != null) _markings.Add(egg.SpeciesId + ":" + egg.Marking);
            hatchling = p;
            Changed?.Invoke();
            return HatchResult.Ok;
        }

        // --- saves ---
        public StablesSave Save() => new StablesSave
        {
            Eggs = _eggs.Select(e => new EggSave { Id = e.Id, SpeciesId = e.SpeciesId, Marking = e.Marking, ReadyHour = e.ReadyHour }).ToList(),
            LastFed = new Dictionary<string, double>(_lastFed),
            PairReady = new Dictionary<string, double>(_pairReady),
            SpeciesSeen = _seen.OrderBy(x => x, StringComparer.Ordinal).ToList(),
            Markings = _markings.OrderBy(x => x, StringComparer.Ordinal).ToList(),
            SinceCross = _sinceCross, SinceMarking = _sinceMarking, NextEgg = _nextEgg, MountId = _mountId
        };

        /// <summary>Restores from a save (null in an old save: nothing). Bad entries are dropped; eggs beyond the cap are kept so a load never loses one.</summary>
        public void Load(StablesSave s)
        {
            _eggs.Clear(); _lastFed.Clear(); _pairReady.Clear(); _seen.Clear(); _markings.Clear();
            _sinceCross = Math.Max(0, s?.SinceCross ?? 0); _sinceMarking = Math.Max(0, s?.SinceMarking ?? 0); _nextEgg = Math.Max(1, s?.NextEgg ?? 1);
            _mountId = s?.MountId;
            foreach (var e in s?.Eggs ?? new List<EggSave>())
                if (e != null && !string.IsNullOrEmpty(e.Id) && !string.IsNullOrEmpty(e.SpeciesId) && !double.IsNaN(e.ReadyHour) && !double.IsInfinity(e.ReadyHour) && _eggs.All(x => x.Id != e.Id))
                    _eggs.Add(new EggSave { Id = e.Id, SpeciesId = e.SpeciesId, Marking = e.Marking, ReadyHour = e.ReadyHour });
            foreach (var kv in s?.LastFed ?? new Dictionary<string, double>()) if (!double.IsNaN(kv.Value) && !double.IsInfinity(kv.Value)) _lastFed[kv.Key] = kv.Value;
            foreach (var kv in s?.PairReady ?? new Dictionary<string, double>()) if (!double.IsNaN(kv.Value) && !double.IsInfinity(kv.Value)) _pairReady[kv.Key] = kv.Value;
            foreach (var x in s?.SpeciesSeen ?? new List<string>()) NoteSpecies(x);
            foreach (var m in s?.Markings ?? new List<string>()) if (!string.IsNullOrEmpty(m)) _markings.Add(m);
            Reconcile();
            Changed?.Invoke();
        }
    }
}
