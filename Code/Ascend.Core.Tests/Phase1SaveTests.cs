using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Ascend.Core;

// Phase 1 wiring: every system added after the first save (life skills, gear fittings, home, stables, archive, dungeons, labyrinth,
// living world, accessibility) must survive one SaveGame JSON round trip together, and a save written before they existed must load.
// The game (PlayerWorldState) does exactly these Save/Load calls; the Unity side is covered by the PlayMode tests.
[Tests]
static class Phase1SaveTests
{
    static readonly JsonSerializerOptions Opts = new JsonSerializerOptions { PropertyNameCaseInsensitive = true, Converters = { new JsonStringEnumConverter() } };

    static LivingWorldData Lw => Repo.Load<LivingWorldData>("Data/World/living_world.json");

    // An older slot: only what existed before Phase 1, with the keys in the game's JSON style.
    const string OldSave = "{\"Version\":1,\"Level\":12,\"XpIntoLevel\":40,\"Copper\":340,\"Items\":{\"itm_core_f\":2},\"Flags\":[\"arrived_in_aetheria\"],"
        + "\"KnownRecipes\":[\"rcp_fangblade\"],\"Equipment\":{\"Weapon\":\"itm_fangblade\"},\"ClockSeconds\":120.5}";

    public static void AnOldSaveWithoutAnyPhase1FieldLoadsAndEverySystemStartsFresh()
    {
        var s = SaveRules.Upgrade(JsonSerializer.Deserialize<SaveGame>(OldSave, Opts));
        Assert.Equal(0, SaveRules.Validate(s).Count, "valid");
        Assert.True(s.LifeSkills != null && s.GearFittings != null && s.Home != null && s.Stables != null && s.Archive != null
            && s.Dungeons != null && s.Labyrinth != null && s.LivingWorld != null && s.Accessibility != null, "Upgrade fills every Phase 1 field");

        // the Load calls PlayerWorldState.Apply makes, none may throw
        var skills = new LifeSkills(Repo.Db.LifeSkills); skills.Load(s.LifeSkills);
        Assert.Equal("F", skills.Rank(Repo.Db.LifeSkills.Skills[0].Id), "all skills at F");
        var home = new Home(Repo.Db.Housing, Repo.Db.Crops, Repo.Db.Quality, skills); home.Load(s.Home);
        Assert.Equal("inn_room", home.Tier.Id, "the base inn room");
        var roster = new PartnerRoster(Repo.Db.World.Taming);
        var stables = new Stables(Repo.Db.Stables, roster, Repo.Db.World.Taming, home, Repo.Db.Species); stables.Load(s.Stables);
        Assert.Equal(0, stables.Eggs.Count, "no eggs");
        var archive = new CivilizationArchive(Repo.Db.Archive); archive.Load(s.Archive);
        Assert.Equal(0, archive.Visited.Count(), "nothing visited");
        var lab = new Labyrinth(Repo.Load<LabyrinthData>("Data/World/labyrinth.json")); var know = new LabyrinthKnowledge(lab); know.Load(s.Labyrinth);
        Assert.Equal(0, know.Deepest, "no floor visited");
        var fitter = new GearFitter(Repo.Db.Gear, Repo.Db.Items, Repo.Db.Quality); fitter.Load(s.GearFittings);
        Assert.Equal(0, fitter.Fittings.Count, "no fittings");
        foreach (var d in Repo.Db.Dungeons.Values) new DungeonKnowledge(d).Load(s.Dungeons.Dungeons.TryGetValue(d.Id, out var p) ? p : null);
        var journal = new DiscoveryJournal(Lw.JournalCategories, s.LivingWorld.Journal);
        Assert.Equal(0, journal.Count("region", MapStatus.Visited), "empty journal");
        Assert.Equal(-1, s.LivingWorld.Events.LastRolledDay, "the director has never rolled");
        Assert.Equal(ColorblindPalette.Off, s.Accessibility.ColorblindPalette, "safe accessibility defaults");
    }

    public static void EveryPhase1SystemRoundTripsInOneSave()
    {
        var skillId = Repo.Db.LifeSkills.Skills[0].Id;
        var skills = new LifeSkills(Repo.Db.LifeSkills);
        skills.AddXp(skillId, 300); // past the E threshold (250)
        var home = new Home(Repo.Db.Housing, Repo.Db.Crops, Repo.Db.Quality, skills);
        home.Load(new HomeSave { Tier = "rented_room", Storage = new Dictionary<string, int> { ["itm_core_f"] = 4 } });
        var roster = new PartnerRoster(Repo.Db.World.Taming);
        var stables = new Stables(Repo.Db.Stables, roster, Repo.Db.World.Taming, home, Repo.Db.Species);
        string species = Repo.Db.Species.Keys.First();
        stables.NoteSpecies(species);
        var archive = new CivilizationArchive(Repo.Db.Archive);
        string entry = Repo.Db.Archive.Entries.First().Id;
        archive.Hear(entry);
        var dungeon = Repo.Db.Dungeons.Values.First();
        var dk = new DungeonKnowledge(dungeon);
        dk.VisitRoom(dungeon.EntryRoom);
        var lab = new Labyrinth(Repo.Load<LabyrinthData>("Data/World/labyrinth.json"));
        var lk = new LabyrinthKnowledge(lab);
        lk.VisitFloor(3);
        var living = new LivingWorldSave();
        var journal = new DiscoveryJournal(Lw.JournalCategories, living.Journal);
        journal.Visit("region", "reg_test");
        var director = new EventDirector(Lw.Events, new GameCalendar(Repo.Db.World.Calendar), 99);
        director.Advance(living.Events, 5);
        var access = new AccessibilitySettings { ColorblindPalette = ColorblindPalette.Deuteranopia, TextScale = 1.5, NoCombatMusic = true, ReducedMusicIntensity = true };

        var save = SaveRules.Capture(new PlayerProgress(Repo.Db.Progression, 5), new Inventory(), Difficulty.Adventurer, new System.DateTime(2026, 11, 8, 0, 0, 0, System.DateTimeKind.Utc));
        save.LifeSkills = skills.Save();
        save.Home = home.Save();
        save.Stables = stables.Save();
        save.Archive = archive.Save();
        save.Dungeons = new DungeonSave { Dungeons = new Dictionary<string, DungeonProgressSave> { [dungeon.Id] = dk.Save() } };
        save.Labyrinth = lk.Save();
        save.LivingWorld = living;
        save.Accessibility = access;
        save.GearFittings = new Dictionary<string, GearFitting> { ["itm_unknown_blade"] = new GearFitting { Runes = new List<string>() } };

        var back = SaveRules.Upgrade(JsonSerializer.Deserialize<SaveGame>(JsonSerializer.Serialize(save, Opts), Opts));
        Assert.Equal(0, SaveRules.Validate(back).Count, "valid after the round trip");

        var skills2 = new LifeSkills(Repo.Db.LifeSkills); skills2.Load(back.LifeSkills);
        Assert.Equal(300L, skills2.Xp(skillId), "life skill XP");
        Assert.Equal(skills.Rank(skillId), skills2.Rank(skillId), "life skill rank");
        var home2 = new Home(Repo.Db.Housing, Repo.Db.Crops, Repo.Db.Quality, skills2); home2.Load(back.Home);
        Assert.Equal("rented_room", home2.Tier.Id, "home tier");
        Assert.Equal(4, home2.Stored("itm_core_f"), "home storage");
        var stables2 = new Stables(Repo.Db.Stables, new PartnerRoster(Repo.Db.World.Taming), Repo.Db.World.Taming, home2, Repo.Db.Species); stables2.Load(back.Stables);
        Assert.Equal(1, stables2.SpeciesKnown, "stables species seen");
        var archive2 = new CivilizationArchive(Repo.Db.Archive); archive2.Load(back.Archive);
        Assert.Equal(MapStatus.Heard, archive2.Status(entry), "archive entry heard");
        var dk2 = new DungeonKnowledge(dungeon); dk2.Load(back.Dungeons.Dungeons[dungeon.Id]);
        Assert.Equal(MapStatus.Visited, dk2.StatusOfRoom(dungeon.EntryRoom), "dungeon room visited");
        var lk2 = new LabyrinthKnowledge(lab); lk2.Load(back.Labyrinth);
        Assert.Equal(MapStatus.Visited, lk2.StatusOfFloor(3), "labyrinth floor visited");
        var journal2 = new DiscoveryJournal(Lw.JournalCategories, back.LivingWorld.Journal);
        Assert.Equal(MapStatus.Visited, journal2.StatusOf("region", "reg_test"), "journal entry");
        Assert.Equal(5, back.LivingWorld.Events.LastRolledDay, "event director day");
        Assert.Equal(ColorblindPalette.Deuteranopia, back.Accessibility.ColorblindPalette, "colourblind palette");
        Assert.Near(1.5, back.Accessibility.TextScale, 1e-9, "text scale");
        Assert.True(back.Accessibility.ToMusicPrefs().NoCombatMusic && back.Accessibility.ToMusicPrefs().ReducedIntensity, "music options survive");
        Assert.Equal(1, back.GearFittings.Count, "the raw fittings dictionary survives (the fitter drops gear the data no longer has)");
    }

    public static void AnOldSaveHasNoCompanionStateAndUpgradeFillsIt()
    {
        var s = SaveRules.Upgrade(JsonSerializer.Deserialize<SaveGame>(OldSave, Opts));
        Assert.True(s.CompanionBonds != null && s.CompanionBonds.Count == 0, "bonds filled empty");
        Assert.True(s.CompanionPresets != null && s.CompanionPresets.Count == 0, "presets filled empty");
        Assert.Equal(1, s.Version, "version unchanged");
        Assert.Equal(0, SaveRules.Validate(s).Count, "still valid");
    }

    public static void CompanionBondsAndPresetsRoundTripAndJunkIsDroppedGently()
    {
        var rules = new RelationshipRules();
        var st = rules.NewState("cmp_lyra");
        st.Trust = 42; st.Closeness = 17; st.RomanceOptIn = true; st.LastSeenDay["ev_a"] = 9;
        var save = new SaveGame
        {
            CompanionBonds = new List<CompanionBondSave> { st.ToSave("cmp_lyra"), null, new CompanionBondSave { CompanionId = "" }, new CompanionBondSave { CompanionId = "cmp_x", Seen = null } },
            CompanionPresets = new Dictionary<string, string> { ["cmp_lyra"] = "Defensive", [""] = "Aggressive", ["cmp_x"] = "NotAPreset", ["cmp_y"] = "supportive" },
        };
        var back = SaveRules.Upgrade(JsonSerializer.Deserialize<SaveGame>(JsonSerializer.Serialize(save, Opts), Opts));
        Assert.Equal(0, SaveRules.Validate(back).Count, "valid");
        Assert.Equal(2, back.CompanionBonds.Count, "null and id-less rows dropped");
        var lyra = RelationshipState.FromSave(back.CompanionBonds.First(b => b.CompanionId == "cmp_lyra"), rules, "cmp_lyra");
        Assert.Equal(42, lyra.Trust, "trust"); Assert.Equal(17, lyra.Closeness, "closeness");
        Assert.True(lyra.RomanceOptIn, "opt-in flag"); Assert.Equal(9, lyra.LastSeenDay["ev_a"], "seen day");
        Assert.True(back.CompanionBonds.First(b => b.CompanionId == "cmp_x").Seen != null, "null Seen repaired");
        Assert.Equal(2, back.CompanionPresets.Count, "bad key and bad preset dropped");
        Assert.Equal("Defensive", back.CompanionPresets["cmp_lyra"], "preset kept");
        Assert.Equal("Supportive", back.CompanionPresets["cmp_y"], "preset name normalised");
    }

    public static void ABadAccessibilitySectionIsClampedNotRejected()
    {
        var s = SaveRules.Upgrade(new SaveGame { Accessibility = new AccessibilitySettings { TextScale = 99, HudScale = double.NaN, ScreenShake = -4 } });
        Assert.Near(AccessibilityLimits.TextScaleMax, s.Accessibility.TextScale, 1e-9, "text scale clamped");
        Assert.Near(1.0, s.Accessibility.HudScale, 1e-9, "NaN falls back to the default");
        Assert.Near(0, s.Accessibility.ScreenShake, 1e-9, "negative clamped to 0");
        Assert.Equal(0, SaveRules.Validate(s).Count, "still a valid save");
    }
}
