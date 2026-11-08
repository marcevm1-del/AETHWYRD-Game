using System;
using System.Collections.Generic;
using System.Linq;

namespace Ascend.Core
{
    // Civilization Archive and archaeology (12_Systems/civilization_archive.md; 13_Production/archive_v7b_audit.md).
    // Data: Data/World/civilization_archive.json. Optional: nothing in the main story, a rank or a quest reads it. Entries use the
    // Unknown / Heard / Visited record style (MapStatus) and show only lore that already exists, in its public form.

    public sealed class ArchiveCivilization
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string Source { get; set; }
        public string Summary { get; set; }
    }

    public sealed class ArchiveSite
    {
        public string Id { get; set; }
        public string RegionId { get; set; }
        public string Name { get; set; }
        public string CivilizationId { get; set; }
        /// <summary>canon: backed by existing lore. draft: a proposed placement the user has not approved.</summary>
        public string LoreStatus { get; set; } = "draft";
    }

    public sealed class ArchivePlace
    {
        public string SiteId { get; set; }
        public string DungeonId { get; set; }
        public string RoomId { get; set; }
        public string ClueId { get; set; }
    }

    public sealed class ArchiveClueRef
    {
        public string DungeonId { get; set; }
        public string ClueId { get; set; }
    }

    public sealed class ArchiveEntry
    {
        public string Id { get; set; }
        public string CivilizationId { get; set; }
        public string Kind { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Source { get; set; }
        /// <summary>"read": found in place. "restore": rebuilt from fragments.</summary>
        public string How { get; set; } = "read";
        public ArchivePlace ReadAt { get; set; }
        public List<ArchiveClueRef> HearsClues { get; set; } = new List<ArchiveClueRef>();
        public List<string> HearsRegions { get; set; } = new List<string>();
        public string Artifact { get; set; }
        public bool Draft { get; set; }
    }

    public sealed class ArchiveFragment
    {
        public string Id { get; set; }
        public string ItemId { get; set; }
        public string Name { get; set; }
        public string EntryId { get; set; }
        public ArchivePlace FoundIn { get; set; } = new ArchivePlace();
        public bool Draft { get; set; } = true;
    }

    public sealed class ArchiveFile
    {
        public string Notes { get; set; }
        public List<ArchiveCivilization> Civilizations { get; set; } = new List<ArchiveCivilization>();
        public List<ArchiveSite> Sites { get; set; } = new List<ArchiveSite>();
        public List<ArchiveEntry> Entries { get; set; } = new List<ArchiveEntry>();
        public List<ArchiveFragment> Fragments { get; set; } = new List<ArchiveFragment>();

        public ArchiveEntry Entry(string id) => Entries.FirstOrDefault(e => e.Id == id);
        public ArchiveFragment Fragment(string id) => Fragments.FirstOrDefault(f => f.Id == id);
        public ArchiveSite Site(string id) => Sites.FirstOrDefault(s => s.Id == id);
        public IEnumerable<ArchiveFragment> FragmentsOf(string entryId) => Fragments.Where(f => f.EntryId == entryId);
    }

    public sealed class ArchiveSave
    {
        public Dictionary<string, MapStatus> Entries { get; set; } = new Dictionary<string, MapStatus>();
        public List<string> FoundFragments { get; set; } = new List<string>();
        public List<string> Restored { get; set; } = new List<string>();
    }

    public enum ArchiveResult { Ok, Unknown, AlreadyDone, NotThere, NotFoundYet, WrongMethod, MissingFragments, NoBag }

    public sealed class RestoreReport
    {
        public ArchiveResult Result { get; set; }
        public string EntryId { get; set; }
        public string Artifact { get; set; }
        public List<ArchiveClueRef> HeardClues { get; set; } = new List<ArchiveClueRef>();
        public List<string> HeardRegions { get; set; } = new List<string>();
    }

    /// <summary>
    /// What the player has pieced together of lost history. Reading an inscription in place or rebuilding an artifact from its fragments
    /// marks an entry Visited; a rumour marks it Heard. Fragments come from ruins and dungeon rooms, once each. Restoring is optional,
    /// consumes only the fragments (deterministic, nothing random), and rewards knowledge: the entry, a displayable artifact and
    /// pencilled-in hints. It never gates anything.
    /// </summary>
    public sealed class CivilizationArchive
    {
        readonly ArchiveFile _file;
        readonly Dictionary<string, MapStatus> _entries = new Dictionary<string, MapStatus>();
        readonly HashSet<string> _found = new HashSet<string>();
        readonly HashSet<string> _restored = new HashSet<string>();

        public CivilizationArchive(ArchiveFile file) { _file = file ?? new ArchiveFile(); }

        public event Action Changed;
        public ArchiveFile Data => _file;

        public MapStatus Status(string entryId) => entryId != null && _entries.TryGetValue(entryId, out var s) ? s : MapStatus.Unknown;
        public IEnumerable<string> Visited => _entries.Where(kv => kv.Value == MapStatus.Visited).Select(kv => kv.Key);
        public IEnumerable<string> Heard => _entries.Where(kv => kv.Value == MapStatus.Heard).Select(kv => kv.Key);
        public IEnumerable<string> RestoredArtifacts => _restored;
        public bool FragmentFound(string fragmentId) => _found.Contains(fragmentId);

        /// <summary>Entries visited in a civilization, and how many it has.</summary>
        public (int visited, int total) Progress(string civilizationId)
        {
            var all = _file.Entries.Where(e => e.CivilizationId == civilizationId).ToList();
            return (all.Count(e => Status(e.Id) == MapStatus.Visited), all.Count);
        }

        /// <summary>A rumour pencils an entry in; never downgrades a visit.</summary>
        public bool Hear(string entryId)
        {
            if (_file.Entry(entryId) == null || Status(entryId) != MapStatus.Unknown) return false;
            _entries[entryId] = MapStatus.Heard;
            Changed?.Invoke();
            return true;
        }

        /// <summary>Reads an entry in place at a ruin (<paramref name="siteId"/>). Only the entry's own site counts.</summary>
        public ArchiveResult ReadAtSite(string entryId, string siteId)
        {
            var e = _file.Entry(entryId);
            if (e == null) return ArchiveResult.Unknown;
            if (e.How != "read" || e.ReadAt == null) return ArchiveResult.WrongMethod;
            if (e.ReadAt.SiteId == null || e.ReadAt.SiteId != siteId) return ArchiveResult.NotThere;
            return Visit(e);
        }

        /// <summary>Reads an entry that is tied to a dungeon clue; the clue must already have been found in place (Visited).</summary>
        public ArchiveResult ReadFromClue(string entryId, string dungeonId, DungeonKnowledge dungeon)
        {
            var e = _file.Entry(entryId);
            if (e == null) return ArchiveResult.Unknown;
            if (e.How != "read" || e.ReadAt == null) return ArchiveResult.WrongMethod;
            if (e.ReadAt.ClueId == null || e.ReadAt.DungeonId != dungeonId) return ArchiveResult.NotThere;
            if (dungeon == null || dungeon.StatusOfClue(e.ReadAt.ClueId) != MapStatus.Visited) return ArchiveResult.NotFoundYet;
            return Visit(e);
        }

        ArchiveResult Visit(ArchiveEntry e)
        {
            if (Status(e.Id) == MapStatus.Visited) return ArchiveResult.AlreadyDone;
            _entries[e.Id] = MapStatus.Visited;
            Changed?.Invoke();
            return ArchiveResult.Ok;
        }

        /// <summary>
        /// Digs a fragment out of the place it lies (a ruin site, or a dungeon room). Each fragment is found once; it goes into the bag and
        /// stays yours until you restore its artifact. Nothing is rolled and nothing repeats for grinding.
        /// </summary>
        public ArchiveResult Excavate(string fragmentId, string siteId, string dungeonId, string roomId, Inventory inv)
        {
            var f = _file.Fragment(fragmentId);
            if (f == null) return ArchiveResult.Unknown;
            var at = f.FoundIn ?? new ArchivePlace();
            bool here = at.SiteId != null ? at.SiteId == siteId : (at.DungeonId != null && at.DungeonId == dungeonId && at.RoomId == roomId);
            if (!here) return ArchiveResult.NotThere;
            if (inv == null) return ArchiveResult.NoBag;
            // A fragment already found stays found. If it is no longer in the bag (stored away or spent elsewhere) and its artifact is not
            // restored yet, digging at its place hands it back once more, so a restore can never become unreachable. The bag never holds two.
            if (_found.Contains(f.Id) && (_restored.Contains(f.EntryId) || inv.Count(f.ItemId) > 0)) return ArchiveResult.AlreadyDone;
            _found.Add(f.Id);
            inv.Add(f.ItemId);
            Changed?.Invoke();
            return ArchiveResult.Ok;
        }

        /// <summary>Everything an entry still needs: the fragment ids you have not yet found or are not carrying.</summary>
        public List<string> MissingFragments(string entryId, Inventory inv) =>
            _file.FragmentsOf(entryId).Where(f => inv == null || inv.Count(f.ItemId) < 1).Select(f => f.Id).ToList();

        /// <summary>Rebuilds an artifact from all of its fragments (they are used up). Optional and never random. Returns what it pencils in; apply it with <see cref="Apply"/>.</summary>
        public RestoreReport Restore(string entryId, Inventory inv)
        {
            var rep = new RestoreReport { EntryId = entryId };
            var e = _file.Entry(entryId);
            if (e == null) { rep.Result = ArchiveResult.Unknown; return rep; }
            if (e.How != "restore") { rep.Result = ArchiveResult.WrongMethod; return rep; }
            if (_restored.Contains(e.Id)) { rep.Result = ArchiveResult.AlreadyDone; return rep; }
            var frags = _file.FragmentsOf(e.Id).ToList();
            if (frags.Count == 0 || inv == null || frags.Any(f => inv.Count(f.ItemId) < 1)) { rep.Result = ArchiveResult.MissingFragments; return rep; }
            foreach (var f in frags) inv.TryRemove(f.ItemId);
            _entries[e.Id] = MapStatus.Visited;
            _restored.Add(e.Id);
            rep.Artifact = string.IsNullOrEmpty(e.Artifact) ? e.Title : e.Artifact;
            rep.HeardClues = e.HearsClues.ToList();
            rep.HeardRegions = e.HearsRegions.ToList();
            rep.Result = ArchiveResult.Ok;
            Changed?.Invoke();
            return rep;
        }

        /// <summary>Pencils a restore's hints into the dungeon records and the map (a hint never reveals a hidden way; HearClue only pencils).</summary>
        public static void Apply(RestoreReport report, IDictionary<string, DungeonKnowledge> dungeons, MapKnowledge map)
        {
            if (report == null || report.Result != ArchiveResult.Ok) return;
            foreach (var c in report.HeardClues)
                if (dungeons != null && dungeons.TryGetValue(c.DungeonId ?? "", out var d)) d.HearClue(c.ClueId);
            foreach (var r in report.HeardRegions) map?.Hear(r);
        }

        // --- saves ---
        public ArchiveSave Save() => new ArchiveSave
        {
            Entries = new Dictionary<string, MapStatus>(_entries),
            FoundFragments = _found.OrderBy(x => x, StringComparer.Ordinal).ToList(),
            Restored = _restored.OrderBy(x => x, StringComparer.Ordinal).ToList()
        };

        /// <summary>Restores a save. Null (an older save) changes nothing; ids the data no longer has are ignored; a visit is never downgraded.</summary>
        public void Load(ArchiveSave s)
        {
            if (s == null) return;
            foreach (var kv in s.Entries ?? new Dictionary<string, MapStatus>())
            {
                if (_file.Entry(kv.Key) == null) continue;
                if (kv.Value == MapStatus.Visited) _entries[kv.Key] = MapStatus.Visited;
                else if (kv.Value == MapStatus.Heard && Status(kv.Key) == MapStatus.Unknown) _entries[kv.Key] = MapStatus.Heard;
            }
            foreach (var id in s.FoundFragments ?? new List<string>()) if (_file.Fragment(id) != null) _found.Add(id);
            foreach (var id in s.Restored ?? new List<string>()) if (_file.Entry(id) != null) { _restored.Add(id); _entries[id] = MapStatus.Visited; }
            Changed?.Invoke();
        }
    }
}
