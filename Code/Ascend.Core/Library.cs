using System;
using System.Collections.Generic;
using System.Linq;

namespace Ascend.Core
{
    // Libraries and books (12_Systems/libraries_and_books.md). Data: Data/Library/libraries.json and books.json; the texts live in
    // 02_Lore/library/<library-id>/<book-id>.md. Optional: no quest, rank, ending or main-story step reads it. Books are DRAFTS until the
    // user approves them; a library with status "proposed" is not Canon either. Records use the Unknown / Heard / Visited style (MapStatus).

    public sealed class LibraryData
    {
        public string Id { get; set; }
        public string Name { get; set; }
        /// <summary>library, archive, temple, school or guild_hall.</summary>
        public string Type { get; set; }
        public string Region { get; set; }
        public string Settlement { get; set; }
        /// <summary>canon: already in Canon, the lore or Data/World. proposed: invented for the shelf, not Canon.</summary>
        public string Status { get; set; } = "proposed";
        public string Source { get; set; }
        public string Blurb { get; set; }
        public List<string> Covers { get; set; } = new List<string>();
        /// <summary>Optional guild rank needed to enter (for example the Labyrinth library).</summary>
        public string RankGate { get; set; }
    }

    public sealed class LibraryFile
    {
        public int Version { get; set; }
        public string Note { get; set; }
        public List<LibraryData> Libraries { get; set; } = new List<LibraryData>();
    }

    public sealed class BookReward
    {
        /// <summary>bestiary (marks a species Seen), archive (pencils a civilization's archive entries), recipe_hint or clue (data only for now).</summary>
        public string Kind { get; set; }
        public string Id { get; set; }
    }

    public sealed class BookProvenance
    {
        public string Tradition { get; set; }
        public string WrittenIn { get; set; }
        public string Era { get; set; }
        /// <summary>The condition of this copy.</summary>
        public string Copy { get; set; }
        public string ShelfPlace { get; set; }
    }

    public sealed class BookHook
    {
        public string Kind { get; set; }
        public string Id { get; set; }
        public string Note { get; set; }
    }

    public sealed class BookData
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Kind { get; set; }
        /// <summary>Null for a held book (never shelved).</summary>
        public string Library { get; set; }
        /// <summary>The region where the book sits (its library's region).</summary>
        public string Region { get; set; }
        public string SubjectRegion { get; set; }
        public string Shelf { get; set; }
        public string Language { get; set; }
        public string Blurb { get; set; }
        public int ReadingMinutes { get; set; }
        public int Words { get; set; }
        public List<string> Tags { get; set; } = new List<string>();
        /// <summary>accurate, partial, folk belief or propaganda: how far to trust it.</summary>
        public string Reliability { get; set; }
        /// <summary>draft, clear or hold.</summary>
        public string Status { get; set; } = "draft";
        public string Quality { get; set; }
        public string InWorldDate { get; set; }
        public string Source { get; set; }
        public string Text { get; set; }
        public string RankGate { get; set; }
        /// <summary>A few lines from the page itself (verbatim from the text).</summary>
        public string Excerpt { get; set; }
        public BookProvenance Provenance { get; set; }
        /// <summary>What a reader takes away.</summary>
        public List<string> Teaches { get; set; } = new List<string>();
        /// <summary>Pointers into the game data (region, place, species, item, recipe, quest, civilization, god). Background only, never a requirement.</summary>
        public List<BookHook> Hooks { get; set; } = new List<BookHook>();
        public List<string> CanonNotes { get; set; } = new List<string>();
        public List<BookReward> Rewards { get; set; } = new List<BookReward>();
    }

    public sealed class BookFile
    {
        public int Version { get; set; }
        public string Note { get; set; }
        public List<BookData> Books { get; set; } = new List<BookData>();
    }

    /// <summary>The shelf: libraries and the books on them. Held books are in the data but never reachable.</summary>
    public sealed class LibraryCatalogue
    {
        readonly Dictionary<string, LibraryData> _libs = new Dictionary<string, LibraryData>();
        readonly Dictionary<string, BookData> _books = new Dictionary<string, BookData>();
        public LibraryCatalogue(LibraryFile libraries, BookFile books)
        {
            foreach (var l in libraries?.Libraries ?? new List<LibraryData>()) _libs[l.Id] = l;
            foreach (var b in books?.Books ?? new List<BookData>()) _books[b.Id] = b;
        }
        public IEnumerable<LibraryData> Libraries => _libs.Values;
        public IEnumerable<BookData> Books => _books.Values;
        public LibraryData Library(string id) => id != null && _libs.TryGetValue(id, out var l) ? l : null;
        public BookData Book(string id) => id != null && _books.TryGetValue(id, out var b) ? b : null;
        /// <summary>The books a library holds (held books are never listed).</summary>
        public IEnumerable<BookData> BooksIn(string libraryId) => _books.Values.Where(b => b.Library == libraryId && b.Status != "hold");
        /// <summary>Libraries in a region.</summary>
        public IEnumerable<LibraryData> InRegion(string regionId) => _libs.Values.Where(l => l.Region == regionId);
        public bool Empty => _libs.Count == 0 && _books.Count == 0;
    }

    public sealed class ReadingSave
    {
        public Dictionary<string, MapStatus> Books { get; set; } = new Dictionary<string, MapStatus>();
        /// <summary>Rewards already given ("kind:id"). Each is given once, ever.</summary>
        public List<string> RewardsGiven { get; set; } = new List<string>();
    }

    public enum ReadResult { Ok, Unknown, Held, NotShelved, WrongRegion, RankTooLow, AlreadyRead }

    public sealed class ReadReport
    {
        public ReadResult Result { get; set; }
        public string BookId { get; set; }
        /// <summary>Only rewards given for the first time.</summary>
        public List<BookReward> NewRewards { get; set; } = new List<BookReward>();
    }

    /// <summary>
    /// What the player has read. A rumour pencils a book Heard; reading it in its library marks it Visited. A book can carry a small knowledge
    /// reward (a species entry, a pencilled archive civilization) given once ever: reading never gives XP, never repeats, and never gates a
    /// quest, a rank or the story. The rank gate and the region check only decide whether you can open the book here and now.
    /// </summary>
    public sealed class ReadingRecord
    {
        readonly LibraryCatalogue _cat;
        readonly Dictionary<string, MapStatus> _books = new Dictionary<string, MapStatus>();
        readonly HashSet<string> _given = new HashSet<string>();

        public ReadingRecord(LibraryCatalogue catalogue) { _cat = catalogue ?? new LibraryCatalogue(null, null); }
        public event Action Changed;
        public void Reset() { _books.Clear(); _given.Clear(); Changed?.Invoke(); }

        public MapStatus Status(string bookId) => bookId != null && _books.TryGetValue(bookId, out var s) ? s : MapStatus.Unknown;
        public IEnumerable<string> Read => _books.Where(kv => kv.Value == MapStatus.Visited).Select(kv => kv.Key);
        public IEnumerable<string> HeardOf => _books.Where(kv => kv.Value == MapStatus.Heard).Select(kv => kv.Key);

        /// <summary>A rumour pencils a book in; never downgrades a read book. Held books cannot be heard of.</summary>
        public bool Hear(string bookId)
        {
            var b = _cat.Book(bookId);
            if (b == null || b.Status == "hold" || Status(bookId) != MapStatus.Unknown) return false;
            _books[bookId] = MapStatus.Heard;
            Changed?.Invoke();
            return true;
        }

        /// <summary>Whether this player could open the book here: the book is shelved, they stand in its library's region and meet its rank gates.</summary>
        public ReadResult CanOpen(string bookId, Rank rank, string regionId)
        {
            var b = _cat.Book(bookId);
            if (b == null) return ReadResult.Unknown;
            if (b.Status == "hold") return ReadResult.Held;
            var lib = _cat.Library(b.Library);
            if (lib == null) return ReadResult.NotShelved;
            if (lib.Region != regionId) return ReadResult.WrongRegion;
            foreach (var gate in new[] { lib.RankGate, b.RankGate })
                if (!string.IsNullOrEmpty(gate) && Rank.TryParse(gate, out var need) && rank < need) return ReadResult.RankTooLow;
            return ReadResult.Ok;
        }

        /// <summary>Reads a book in its library. First reading marks it Visited and reports any new rewards; later readings change nothing.</summary>
        public ReadReport ReadBook(string bookId, Rank rank, string regionId)
        {
            var rep = new ReadReport { BookId = bookId, Result = CanOpen(bookId, rank, regionId) };
            if (rep.Result != ReadResult.Ok) return rep;
            if (Status(bookId) == MapStatus.Visited) { rep.Result = ReadResult.AlreadyRead; return rep; }
            _books[bookId] = MapStatus.Visited;
            foreach (var r in _cat.Book(bookId).Rewards ?? new List<BookReward>())
                if (_given.Add(r.Kind + ":" + r.Id)) rep.NewRewards.Add(r);
            Changed?.Invoke();
            return rep;
        }

        /// <summary>Applies a reading's new rewards: a bestiary reward marks the species Seen, an archive reward pencils the civilization's entries as Heard.</summary>
        public static void Apply(ReadReport report, Bestiary bestiary, CivilizationArchive archive)
        {
            if (report == null || report.Result != ReadResult.Ok) return;
            foreach (var r in report.NewRewards)
            {
                if (r.Kind == "bestiary") bestiary?.See(r.Id);
                else if (r.Kind == "archive" && archive != null)
                    foreach (var e in archive.Data.Entries.Where(e => e.CivilizationId == r.Id)) archive.Hear(e.Id);
            }
        }

        // --- saves ---
        public ReadingSave Save() => new ReadingSave
        {
            Books = new Dictionary<string, MapStatus>(_books),
            RewardsGiven = _given.OrderBy(x => x, StringComparer.Ordinal).ToList()
        };

        /// <summary>Restores a save. Null (an older save) changes nothing; ids the data no longer has are ignored; a read is never downgraded.</summary>
        public void Load(ReadingSave s)
        {
            if (s == null) return;
            foreach (var kv in s.Books ?? new Dictionary<string, MapStatus>())
            {
                if (_cat.Book(kv.Key) == null) continue;
                if (kv.Value == MapStatus.Visited) _books[kv.Key] = MapStatus.Visited;
                else if (kv.Value == MapStatus.Heard && Status(kv.Key) == MapStatus.Unknown) _books[kv.Key] = MapStatus.Heard;
            }
            foreach (var g in s.RewardsGiven ?? new List<string>()) _given.Add(g);
            Changed?.Invoke();
        }
    }
}
