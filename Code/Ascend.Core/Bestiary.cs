using System;
using System.Collections.Generic;
using System.Linq;

namespace Ascend.Core
{
    // The Bestiary (12_Systems/hud_and_ui.md §9; systems.md §7.4). Numbers: world_tuning.json → bestiary.

    public sealed class BestiaryTuning
    {
        public double SeenRadius { get; set; } = 20;
        public int Tier2Kills { get; set; } = 3;
        public int Tier3Kills { get; set; } = 10;
    }

    public sealed class BestiaryEntry
    {
        public string SpeciesId { get; set; }
        public bool Seen { get; set; }
        public int Kills { get; set; }
        public bool Tamed { get; set; }
        public List<string> DropsFound { get; set; } = new List<string>();
    }

    /// <summary>
    /// What you know about each species. Tier 0: never seen ("???", a silhouette) · 1: seen (name, rank, Menace) ·
    /// 2: a few kills (HP, element, weakness) · 3: many kills or tamed (attacks, drops, lore). The completion stamp
    /// needs tier 3 and every item in its loot table found.
    /// </summary>
    public sealed class Bestiary
    {
        readonly Dictionary<string, BestiaryEntry> _entries = new Dictionary<string, BestiaryEntry>();
        readonly GameDatabase _db;
        readonly BestiaryTuning _t;

        public Bestiary(GameDatabase db, BestiaryTuning tuning)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _t = tuning ?? new BestiaryTuning();
        }

        public IReadOnlyDictionary<string, BestiaryEntry> Entries => _entries;

        BestiaryEntry E(string id)
        {
            if (!_entries.TryGetValue(id, out var e)) _entries[id] = e = new BestiaryEntry { SpeciesId = id };
            return e;
        }

        /// <summary>Records a sighting; true the first time (a new entry).</summary>
        public bool See(string speciesId)
        {
            if (!_db.Species.ContainsKey(speciesId ?? "")) return false;
            var e = E(speciesId);
            if (e.Seen) return false;
            e.Seen = true;
            return true;
        }

        /// <summary>A kill; returns the new tier if it went up, else null.</summary>
        public int? Kill(string speciesId)
        {
            if (!_db.Species.ContainsKey(speciesId ?? "")) return null;
            int before = Tier(speciesId);
            var e = E(speciesId); e.Seen = true; e.Kills++;
            int after = Tier(speciesId);
            return after > before ? after : (int?)null;
        }

        public void Tame(string speciesId)
        {
            if (!_db.Species.ContainsKey(speciesId ?? "")) return;
            var e = E(speciesId); e.Seen = true; e.Tamed = true;
        }

        public void Drop(string speciesId, string itemId)
        {
            if (!_db.Species.ContainsKey(speciesId ?? "") || string.IsNullOrEmpty(itemId)) return;
            var e = E(speciesId);
            if (!e.DropsFound.Contains(itemId)) e.DropsFound.Add(itemId);
        }

        public int Tier(string speciesId)
        {
            if (!_entries.TryGetValue(speciesId ?? "", out var e) || !e.Seen) return 0;
            if (e.Tamed || e.Kills >= _t.Tier3Kills) return 3;
            return e.Kills >= _t.Tier2Kills ? 2 : 1;
        }

        /// <summary>The items its loot table can drop.</summary>
        public List<string> PossibleDrops(string speciesId) =>
            _db.Species.TryGetValue(speciesId ?? "", out var s) && s.LootTableId != null && _db.LootTables.TryGetValue(s.LootTableId, out var t)
                ? t.Entries.Select(x => x.ItemId).Distinct().ToList() : new List<string>();

        public bool Stamped(string speciesId) =>
            Tier(speciesId) >= 3 && PossibleDrops(speciesId).All(d => _entries[speciesId].DropsFound.Contains(d));

        /// <summary>Share of these species with a completion stamp, 0..1.</summary>
        public double Completion(IEnumerable<string> speciesIds)
        {
            var ids = speciesIds.ToList();
            return ids.Count == 0 ? 0 : ids.Count(Stamped) / (double)ids.Count;
        }

        public List<BestiaryEntry> Save() => _entries.Values.Select(e => new BestiaryEntry
        { SpeciesId = e.SpeciesId, Seen = e.Seen, Kills = e.Kills, Tamed = e.Tamed, DropsFound = e.DropsFound.ToList() }).ToList();

        public void Load(IEnumerable<BestiaryEntry> entries)
        {
            _entries.Clear();
            foreach (var e in entries ?? Enumerable.Empty<BestiaryEntry>())
                if (e != null && _db.Species.ContainsKey(e.SpeciesId ?? ""))
                    _entries[e.SpeciesId] = new BestiaryEntry
                    {
                        SpeciesId = e.SpeciesId, Seen = e.Seen, Kills = Math.Max(0, e.Kills), Tamed = e.Tamed,
                        DropsFound = (e.DropsFound ?? new List<string>()).Distinct().ToList(),
                    };
        }
    }
}
