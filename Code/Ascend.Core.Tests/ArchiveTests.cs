using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Ascend.Core;

// Civilization Archive and archaeology on the REAL data (Data/World/civilization_archive.json, dungeons, regions, items, quests).
[Tests]
static class ArchiveTests
{
    static CivilizationArchive Fresh() => new CivilizationArchive(Repo.Db.Archive);
    static DungeonData Warren => Repo.Db.Dungeons["dng_salvage_warren"];

    /// <summary>Digs up every fragment where it lies.</summary>
    static void ExcavateAll(CivilizationArchive a, Inventory inv)
    {
        foreach (var f in Repo.Db.Archive.Fragments)
            Assert.True(a.Excavate(f.Id, f.FoundIn.SiteId, f.FoundIn.DungeonId, f.FoundIn.RoomId, inv) == ArchiveResult.Ok, "excavate " + f.Id);
    }

    public static void TheDataHasFiveCivilizationsAndEveryEntryCanBeReached()
    {
        var d = Repo.Db.Archive;
        Assert.Equal(5, d.Civilizations.Count, "civilizations");
        Assert.Equal(13, d.Entries.Count, "entries");
        Assert.Equal(11, d.Fragments.Count, "fragments");
        var a = Fresh(); var inv = new Inventory();
        ExcavateAll(a, inv);
        var map = new DungeonKnowledge(Warren);
        map.VisitClue("clue_runesmith_mural");
        foreach (var e in d.Entries)
        {
            ArchiveResult r;
            if (e.How == "restore") r = a.Restore(e.Id, inv).Result;
            else if (e.ReadAt.SiteId != null) r = a.ReadAtSite(e.Id, e.ReadAt.SiteId);
            else r = a.ReadFromClue(e.Id, e.ReadAt.DungeonId, map);
            Assert.True(r == ArchiveResult.Ok, e.Id + " reachable: " + r);
        }
        Assert.Equal(13, a.Visited.Count(), "the whole archive can be completed");
        foreach (var c in d.Civilizations) Assert.True(a.Progress(c.Id).visited == a.Progress(c.Id).total && a.Progress(c.Id).total > 0, c.Id + " complete");
        Assert.Equal(0, inv.Items.Values.Sum(), "restoring used up the fragments and nothing else");
    }

    public static void ReadingNeedsTheRightPlaceAndTheClueNeedsFindingFirst()
    {
        var a = Fresh();
        Assert.True(a.ReadAtSite("ent_valdrisian_towers", "site_aldmere_ruins") == ArchiveResult.NotThere, "wrong ruin");
        Assert.True(a.ReadAtSite("ent_valdrisian_towers", "site_sunscar_ruins") == ArchiveResult.Ok, "the Sunscar ruins");
        Assert.True(a.ReadAtSite("ent_valdrisian_towers", "site_sunscar_ruins") == ArchiveResult.AlreadyDone, "once");
        Assert.True(a.ReadAtSite("ent_draconic_covenant", "site_sunscar_ruins") == ArchiveResult.WrongMethod, "a restore entry cannot be read in place");
        Assert.True(a.ReadAtSite("nope", "x") == ArchiveResult.Unknown, "unknown");
        var k = new DungeonKnowledge(Warren);
        Assert.True(a.ReadFromClue("ent_khazdur_runes", "dng_salvage_warren", k) == ArchiveResult.NotFoundYet, "the mural has not been found");
        k.HearClue("clue_runesmith_mural");
        Assert.True(a.ReadFromClue("ent_khazdur_runes", "dng_salvage_warren", k) == ArchiveResult.NotFoundYet, "hearing about it is not enough");
        k.VisitClue("clue_runesmith_mural");
        Assert.True(a.ReadFromClue("ent_khazdur_runes", "dng_salvage_warren", k) == ArchiveResult.Ok, "found in place");
    }

    public static void FragmentsAreFoundOnceInTheirOwnPlace()
    {
        var a = Fresh(); var inv = new Inventory();
        Assert.True(a.Excavate("frag_dun_a", "site_aldmere_ruins", null, null, inv) == ArchiveResult.NotThere, "wrong place");
        Assert.True(a.Excavate("frag_dun_a", null, "dng_salvage_warren", "rm_scrap_hall", inv) == ArchiveResult.NotThere, "wrong room");
        Assert.True(a.Excavate("frag_dun_a", null, "dng_salvage_warren", "rm_rune_cistern", inv) == ArchiveResult.Ok, "the rune cistern");
        Assert.Equal(1, inv.Count("itm_frag_dun_a"), "in the bag");
        Assert.True(a.Excavate("frag_dun_a", null, "dng_salvage_warren", "rm_rune_cistern", inv) == ArchiveResult.AlreadyDone && inv.Count("itm_frag_dun_a") == 1, "never twice: no grinding");
        Assert.True(a.Excavate("frag_missing", null, null, null, inv) == ArchiveResult.Unknown, "unknown");
    }

    public static void RestoringIsOptionalAndRewardsKnowledgeOnly()
    {
        var a = Fresh(); var inv = new Inventory();
        inv.Add("itm_frag_dun_a"); inv.Add("itm_minor_hp_potion", 2);
        Assert.True(a.Restore("ent_karak_dun_founding", inv).Result == ArchiveResult.MissingFragments, "one half is not enough");
        Assert.Equal(1, inv.Count("itm_frag_dun_a"), "a refusal spends nothing");
        Assert.Equal(1, a.MissingFragments("ent_karak_dun_founding", inv).Count, "one still missing");
        inv.Add("itm_frag_dun_b");
        var rep = a.Restore("ent_karak_dun_founding", inv);
        Assert.True(rep.Result == ArchiveResult.Ok && a.Status("ent_karak_dun_founding") == MapStatus.Visited, "restored");
        Assert.Equal("Karak Dûn foundation plate", rep.Artifact, "a displayable artifact");
        Assert.Equal(0, inv.Count("itm_frag_dun_a") + inv.Count("itm_frag_dun_b"), "fragments used");
        Assert.Equal(2, inv.Count("itm_minor_hp_potion"), "nothing else was touched");
        Assert.Equal(0, inv.Copper, "no money, XP or items are handed out: the reward is knowledge");
        Assert.True(a.Restore("ent_karak_dun_founding", inv).Result == ArchiveResult.AlreadyDone, "once");
        Assert.True(a.Restore("ent_valdrisian_towers", inv).Result == ArchiveResult.WrongMethod, "read entries are not restored");
    }

    public static void RestoredEntriesPencilInHintsAndNeverRevealHiddenWays()
    {
        var a = Fresh(); var inv = new Inventory();
        ExcavateAll(a, inv);
        var rep = a.Restore("ent_karak_dun_founding", inv);
        Assert.Equal("clue_runesmith_mural", rep.HeardClues.Single().ClueId, "points at the Runesmith's mural");
        var k = new DungeonKnowledge(Warren);
        var map = new MapKnowledge(Repo.Db.World.Map, Repo.Db.Regions.Values);
        CivilizationArchive.Apply(rep, new Dictionary<string, DungeonKnowledge> { ["dng_salvage_warren"] = k }, map);
        Assert.True(k.StatusOfClue("clue_runesmith_mural") == MapStatus.Heard, "penciled in, not found");
        Assert.True(k.StatusOfClue("clue_runesmith_mural") != MapStatus.Visited, "the way is not revealed");
        var rep2 = a.Restore("ent_old_weave_tongue", inv);
        CivilizationArchive.Apply(rep2, new Dictionary<string, DungeonKnowledge>(), map);
        Assert.True(map.StatusOf("reg_sunscar") != MapStatus.Unknown, "the Sunscar is pencilled in");
        CivilizationArchive.Apply(null, null, null);
    }

    public static void RumoursNeverDowngradeAVisit()
    {
        var a = Fresh();
        Assert.True(a.Hear("ent_valdrisian_roads") && a.Status("ent_valdrisian_roads") == MapStatus.Heard, "heard");
        Assert.True(!a.Hear("ent_valdrisian_roads"), "once");
        a.ReadAtSite("ent_valdrisian_roads", "site_sunscar_ruins");
        Assert.True(!a.Hear("ent_valdrisian_roads") && a.Status("ent_valdrisian_roads") == MapStatus.Visited, "a visit stays");
        Assert.True(!a.Hear("nope"), "unknown entry");
    }

    // --- lore guard ---
    public static void OnlyPublicLoreAndNothingThatSpoilsCanon()
    {
        var spoilers = new[] { "Vesper", "Ezrath", "Hooded", "Caspian", "Nocturne", "Azrael", "Adrian", "Kaede", "Malchior", "harvest", "soul", "red moon", "Unclosed", "Loom" };
        var all = Repo.Db.Archive.Entries.Select(e => e.Title + " " + e.Text + " " + e.Artifact)
            .Concat(Repo.Db.Archive.Civilizations.Select(c => c.Name + " " + c.Summary));
        foreach (var text in all)
            foreach (var s in spoilers) Assert.True(!(text ?? "").Contains(s), "\"" + s + "\" must not appear: " + text);
        Assert.True(Repo.Db.Archive.Fragments.All(f => f.Draft), "fragment placements are proposals until approved");
        foreach (var c in Repo.Db.Archive.Civilizations)
            Assert.True(c.Source.StartsWith("02_Lore/"), c.Id + " is grounded in 02_Lore");
        // New wording and placements are labelled, never canon: the canon sites are exactly the ones lore backs.
        Assert.True(Repo.Db.Archive.Sites.Where(s => s.LoreStatus == "canon").All(s => s.RegionId == "reg_sunscar"), "only the Sunscar ruins are backed by lore (Valdrisia lay in the Sunscar)");
    }

    public static void TheArchiveNeverGatesAnything()
    {
        var root = Repo.Root();
        foreach (var f in new[] { "Data/Quests/quests.json", "Data/Quests/weekly_board.json", "Data/Quests/story_flags.json", "Data/World/guild_ranks.json" })
        {
            var text = System.IO.File.ReadAllText(System.IO.Path.Combine(root, f));
            Assert.True(!text.Contains("ent_") && !text.Contains("frag_") && !text.Contains("civ_") && !text.Contains("itm_frag_"), f + " does not mention the archive");
        }
        var json = JsonSerializer.Serialize(Repo.Db.Archive);
        foreach (var bad in new[] { "Quest", "Rank", "Gate", "Requires", "Flag" }) Assert.True(!json.Contains("\"" + bad), "no " + bad + " field in the archive data");
    }

    // --- saves ---
    public static void TheArchiveSurvivesASaveAndOldSavesLoad()
    {
        var a = Fresh(); var inv = new Inventory();
        a.Hear("ent_glass_circles"); a.ReadAtSite("ent_valdrisian_towers", "site_sunscar_ruins");
        a.Excavate("frag_dun_a", null, "dng_salvage_warren", "rm_rune_cistern", inv); a.Excavate("frag_dun_b", "site_aldmere_ruins", null, null, inv);
        a.Restore("ent_karak_dun_founding", inv);
        var save = new SaveGame { Archive = a.Save() };
        var back = SaveRules.Upgrade(JsonSerializer.Deserialize<SaveGame>(JsonSerializer.Serialize(save)));
        var b = Fresh(); b.Load(back.Archive);
        Assert.True(b.Status("ent_glass_circles") == MapStatus.Heard && b.Status("ent_valdrisian_towers") == MapStatus.Visited && b.Status("ent_karak_dun_founding") == MapStatus.Visited, "statuses");
        Assert.True(b.FragmentFound("frag_dun_a") && b.Excavate("frag_dun_a", null, "dng_salvage_warren", "rm_rune_cistern", inv) == ArchiveResult.AlreadyDone, "found fragments stay found");
        Assert.Equal(1, b.RestoredArtifacts.Count(), "the artifact is in the collection");

        var old = SaveRules.Upgrade(JsonSerializer.Deserialize<SaveGame>("{\"Version\":1,\"Level\":4}"));
        Assert.True(old.Archive != null && SaveRules.Validate(old).Count == 0, "an old save gets an empty archive");
        var c = Fresh(); c.Load(old.Archive); c.Load(null);
        Assert.Equal(0, c.Visited.Count(), "nothing known");
    }

    public static void BadSaveEntriesAreIgnoredAndAVisitIsNeverDowngraded()
    {
        var a = Fresh();
        a.Load(new ArchiveSave
        {
            Entries = new Dictionary<string, MapStatus> { ["ent_gone"] = MapStatus.Visited, ["ent_valdrisian_roads"] = MapStatus.Visited },
            FoundFragments = new List<string> { "frag_gone", "frag_glass_a" }, Restored = new List<string> { "ent_gone" }
        });
        a.Load(new ArchiveSave { Entries = new Dictionary<string, MapStatus> { ["ent_valdrisian_roads"] = MapStatus.Heard } });
        Assert.True(a.Status("ent_valdrisian_roads") == MapStatus.Visited, "a later Heard cannot downgrade");
        Assert.True(a.Status("ent_gone") == MapStatus.Unknown && !a.FragmentFound("frag_gone") && a.FragmentFound("frag_glass_a"), "unknown ids are ignored");
    }
}
