using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Ascend.Core;

// Libraries and books (12_Systems/libraries_and_books.md) on the REAL data (Data/Library/*.json) plus small synthetic shelves.
[Tests]
static class LibraryTests
{
    static ReadingRecord Fresh() => new ReadingRecord(Repo.Db.Library);
    static Rank F => Rank.Parse("F");
    static Rank B => Rank.Parse("B");

    static LibraryCatalogue Tiny(string bookRank = null) => new LibraryCatalogue(
        new LibraryFile { Libraries = new List<LibraryData> { new LibraryData { Id = "lib_a", Region = "reg_x", Name = "A", Type = "library" } } },
        new BookFile
        {
            Books = new List<BookData>
            {
                new BookData { Id = "bk_1", Library = "lib_a", Region = "reg_x", RankGate = bookRank, Rewards = new List<BookReward> { new BookReward { Kind = "bestiary", Id = "mon_red_slime" } } },
                new BookData { Id = "bk_2", Library = "lib_a", Region = "reg_x", Rewards = new List<BookReward> { new BookReward { Kind = "bestiary", Id = "mon_red_slime" } } },
                new BookData { Id = "bk_h", Library = null, Status = "hold" }
            }
        });

    public static void TheShelfLoadsAndEveryShelvedBookSitsInARealLibrary()
    {
        var cat = Repo.Db.Library;
        Assert.True(cat.Libraries.Count() >= 20, "libraries loaded");
        Assert.True(cat.Books.Count() >= 500, "all 500 drafts plus the gap books are in the data (shelved or held)");
        var regions = Repo.Db.Regions.Keys.ToHashSet();
        foreach (var l in cat.Libraries) Assert.True(regions.Contains(l.Region), l.Id + " is in a real region");
        foreach (var b in cat.Books)
        {
            if (b.Status == "hold") { Assert.True(b.Library == null && b.Text == null, b.Id + " held books are never shelved"); continue; }
            var lib = cat.Library(b.Library);
            Assert.True(lib != null && lib.Region == b.Region, b.Id + " sits in a library of its own region");
        }
        Assert.True(cat.Books.Count(b => b.Status == "hold") > 0 && cat.BooksIn("lib_mages_academy").All(b => b.Status != "hold"), "held books are not listed on shelves");
    }

    public static void ReadingNeedsTheLibrarysRegionAndRank()
    {
        var a = Fresh();
        // bk_047 sits in the upside-down library on floor 72 (rank gate B).
        Assert.True(a.CanOpen("bk_047", F, "reg_labyrinth_deep") == ReadResult.RankTooLow, "rank F cannot enter the deep Labyrinth library");
        Assert.True(a.CanOpen("bk_047", B, "reg_aldmere") == ReadResult.WrongRegion, "you have to be there");
        Assert.True(a.ReadBook("bk_047", B, "reg_labyrinth_deep").Result == ReadResult.Ok, "rank B in the right place reads it");
        Assert.True(a.Status("bk_047") == MapStatus.Visited, "now read");
        Assert.True(a.CanOpen("nope", B, "x") == ReadResult.Unknown, "unknown book");
        var t = new ReadingRecord(Tiny("D"));
        Assert.True(t.CanOpen("bk_1", F, "reg_x") == ReadResult.RankTooLow, "a book's own gate");
        Assert.True(t.CanOpen("bk_1", Rank.Parse("D"), "reg_x") == ReadResult.Ok, "the gate rank itself passes");
        Assert.True(t.CanOpen("bk_2", F, "reg_x") == ReadResult.Ok, "no gate");
    }

    public static void AHeldBookCanNeitherBeReadNorHeardOf()
    {
        var a = Fresh();
        var held = Repo.Db.Library.Books.First(b => b.Status == "hold");
        Assert.True(!a.Hear(held.Id) && a.Status(held.Id) == MapStatus.Unknown, "no rumour of a held book");
        Assert.True(a.ReadBook(held.Id, Rank.Parse("SSS"), "reg_aldmere").Result == ReadResult.Held, "cannot read it");
        var t = new ReadingRecord(Tiny());
        Assert.True(t.CanOpen("bk_h", F, "reg_x") == ReadResult.Held, "synthetic hold too");
    }

    public static void ARumourPencilsABookAndReadingMarksItVisited()
    {
        var a = Fresh();
        Assert.True(a.Hear("bk_048") && !a.Hear("bk_048"), "heard once");
        Assert.True(a.Status("bk_048") == MapStatus.Heard, "pencilled");
        Assert.True(a.ReadBook("bk_048", F, "reg_greymoor").Result == ReadResult.Ok && a.Status("bk_048") == MapStatus.Visited, "read in the Peat Library");
        Assert.True(!a.Hear("bk_048") && a.Status("bk_048") == MapStatus.Visited, "a rumour never downgrades a read");
        Assert.True(a.ReadBook("bk_048", F, "reg_greymoor").Result == ReadResult.AlreadyRead, "the second reading is just a reading");
    }

    public static void ARewardIsGivenOnceEverAcrossBooksAndNeverGivesXp()
    {
        var t = new ReadingRecord(Tiny());
        var r1 = t.ReadBook("bk_1", F, "reg_x");
        Assert.Equal(1, r1.NewRewards.Count, "first book gives its reward");
        var r2 = t.ReadBook("bk_2", F, "reg_x");
        Assert.Equal(0, r2.NewRewards.Count, "the same species reward from a second book is not given again");
        Assert.Equal(0, t.ReadBook("bk_1", F, "reg_x").NewRewards.Count, "rereading gives nothing");
        var json = JsonSerializer.Serialize(Repo.Db.Library.Books);
        foreach (var bad in new[] { "\"Xp", "\"Quest", "\"Flag", "\"Requires" }) Assert.True(!json.Contains(bad), "no " + bad + " field in the book data");
    }

    public static void ABestiaryRewardMarksTheSpeciesSeenAndAnArchiveRewardPencilsEntries()
    {
        var a = Fresh();
        var bestiary = new Bestiary(Repo.Db, new BestiaryTuning());
        var archive = new CivilizationArchive(Repo.Db.Archive);
        // bk_001: a field guide in the Aldmere archive that names mon_red_slime; bk_465: a Valdrisian fragment at the Mages' Academy.
        Assert.True(!bestiary.Entries.ContainsKey("mon_red_slime") || !bestiary.Entries["mon_red_slime"].Seen, "not seen yet");
        var rep = a.ReadBook("bk_001", F, "reg_aldmere");
        Assert.True(rep.Result == ReadResult.Ok && rep.NewRewards.Any(r => r.Id == "mon_red_slime"), "the guide names a species");
        ReadingRecord.Apply(rep, bestiary, archive);
        Assert.True(bestiary.Entries["mon_red_slime"].Seen, "the species entry is revealed");
        var rep2 = a.ReadBook("bk_465", F, "reg_aldmere");
        ReadingRecord.Apply(rep2, bestiary, archive);
        var civ = Repo.Db.Archive.Entries.Where(e => e.CivilizationId == "civ_valdrisia").ToList();
        Assert.True(civ.Count > 0 && civ.All(e => archive.Status(e.Id) == MapStatus.Heard), "the fragment pencils the old empire's entries, it does not visit them");
        Assert.True(archive.Visited.Count() == 0, "reading a book never completes an archive entry");
    }

    public static void TheReadingRecordSurvivesASaveAndOldSavesLoad()
    {
        var a = Fresh();
        a.Hear("bk_048"); a.ReadBook("bk_001", F, "reg_aldmere");
        var save = new SaveGame { Reading = a.Save() };
        var back = SaveRules.Upgrade(JsonSerializer.Deserialize<SaveGame>(JsonSerializer.Serialize(save)));
        var b = Fresh(); b.Load(back.Reading);
        Assert.True(b.Status("bk_048") == MapStatus.Heard && b.Status("bk_001") == MapStatus.Visited, "statuses");
        Assert.True(b.ReadBook("bk_001", F, "reg_aldmere").Result == ReadResult.AlreadyRead, "a read book stays read");

        var old = SaveRules.Upgrade(JsonSerializer.Deserialize<SaveGame>("{\"Version\":1,\"Level\":4}"));
        Assert.True(old.Reading != null && SaveRules.Validate(old).Count == 0, "an old save gets an empty reading record");
        var c = Fresh(); c.Load(old.Reading); c.Load(null);
        Assert.Equal(0, c.Read.Count(), "nothing read");
        // rewards already given are not given again after a load
        var again = Fresh(); again.Load(back.Reading);
        Assert.Equal(0, again.ReadBook("bk_001", F, "reg_aldmere").NewRewards.Count, "no second reward");
    }

    public static void BadSaveEntriesAreIgnoredAndAReadIsNeverDowngraded()
    {
        var a = Fresh();
        a.Load(new ReadingSave { Books = new Dictionary<string, MapStatus> { ["bk_gone"] = MapStatus.Visited, ["bk_048"] = MapStatus.Visited } });
        a.Load(new ReadingSave { Books = new Dictionary<string, MapStatus> { ["bk_048"] = MapStatus.Heard } });
        Assert.True(a.Status("bk_048") == MapStatus.Visited, "a later Heard cannot downgrade");
        Assert.True(a.Status("bk_gone") == MapStatus.Unknown, "unknown ids are ignored");
    }

    public static void EveryShelvedBookCarriesAnExcerptProvenanceAndHooksThatPointAtRealData()
    {
        var cat = Repo.Db.Library;
        int n = 0;
        foreach (var b in cat.Books.Where(b => b.Status != "hold"))
        {
            n++;
            Assert.True(!string.IsNullOrEmpty(b.Excerpt) && b.Excerpt.Length >= 40, b.Id + " has an excerpt");
            Assert.True(b.Provenance != null && !string.IsNullOrEmpty(b.Provenance.Copy) && !string.IsNullOrEmpty(b.Provenance.ShelfPlace) && Repo.Db.Regions.ContainsKey(b.Provenance.WrittenIn), b.Id + " has provenance");
            Assert.True(b.Teaches.Count >= 1 && b.Hooks.Count >= 1, b.Id + " says what it teaches and where it points");
            foreach (var h in b.Hooks)
            {
                if (h.Kind == "species") Assert.True(Repo.Db.Species.ContainsKey(h.Id), b.Id + " species hook " + h.Id);
                if (h.Kind == "region") Assert.True(Repo.Db.Regions.ContainsKey(h.Id), b.Id + " region hook " + h.Id);
            }
        }
        Assert.True(n >= 479, "all shelved books were checked");
        var json = JsonSerializer.Serialize(cat.Books);
        foreach (var bad in new[] { "\"Xp", "\"Requires" }) Assert.True(!json.Contains(bad), "hooks are background only: no " + bad);
    }
}
