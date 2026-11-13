using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Ascend.Core;

// Save versioning and migration across every SaveGame field. The covered set is derived by reflection, so a new field
// cannot ship without being classified here (and therefore without a migration decision).
[Tests]
static class SaveMigrationTests
{
    static readonly JsonSerializerOptions Opts = new JsonSerializerOptions { PropertyNameCaseInsensitive = true, Converters = { new JsonStringEnumConverter() } };

    // Fields that stay null (or absent) on purpose after Upgrade: the loader treats null as "use the data default".
    static readonly HashSet<string> NullByDesign = new HashSet<string>
    {
        nameof(SaveGame.SavedAtUtc), nameof(SaveGame.Respawn), nameof(SaveGame.WaystoneId), nameof(SaveGame.Lantern),
        nameof(SaveGame.Companion), nameof(SaveGame.Equipment), nameof(SaveGame.ClockSeconds), nameof(SaveGame.Sieges), nameof(SaveGame.Map),
    };

    // Value-type fields: they default to zero/false/first enum value in an older save, which is the intended starting value.
    static bool IsValueType(PropertyInfo p) => p.PropertyType.IsValueType && Nullable.GetUnderlyingType(p.PropertyType) == null;

    static SaveGame Load(string json) => SaveRules.Upgrade(JsonSerializer.Deserialize<SaveGame>(json, Opts));

    public static void EveryReferenceFieldIsFilledByUpgradeOrDeclaredNullByDesign()
    {
        var props = typeof(SaveGame).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        Assert.True(props.Length > 40, "reflection found the SaveGame fields");
        foreach (var name in NullByDesign) Assert.True(props.Any(p => p.Name == name), $"NullByDesign names a field that no longer exists: {name}");
        var s = Load("{}");
        foreach (var p in props)
        {
            if (IsValueType(p) || NullByDesign.Contains(p.Name)) continue;
            Assert.True(p.GetValue(s) != null, $"SaveGame.{p.Name} is null after Upgrade of an old save: fill it in SaveRules.Upgrade, or add it to NullByDesign with a loader that accepts null");
        }
    }

    public static void NullByDesignFieldsReallyStayNullForAnOldSaveAndNothingThrowsOnThem()
    {
        var s = Load("{\"Version\":1}");
        foreach (var n in NullByDesign) Assert.True(typeof(SaveGame).GetProperty(n).GetValue(s) == null, n + " stays null");
        // The loaders that accept these nulls
        var map = new MapKnowledge(Repo.Db.World.Map, Repo.Db.Regions.Values);
        map.Load(s.Map);
        Assert.Equal(0, SaveRules.Validate(s).Count, "valid");
    }

    public static void AnEmptyJsonObjectIsAValidFreshSlot()
    {
        var s = Load("{}");
        Assert.Equal(0, SaveRules.Validate(s).Count, "valid");
        Assert.Equal(SaveGame.CurrentVersion, s.Version, "version");
        Assert.Equal(1, s.Level, "level 1");
    }

    public static void NullJsonSectionsAreRepairedNotRejected()
    {
        // every collection and section written as explicit null, as an older or hand-edited file might have
        var props = typeof(SaveGame).GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(p => !IsValueType(p) && p.Name != nameof(SaveGame.SavedAtUtc));
        var json = "{" + string.Join(",", props.Select(p => $"\"{p.Name}\":null")) + "}";
        var s = Load(json);
        Assert.Equal(0, SaveRules.Validate(s).Count, "valid after nulls");
        Assert.True(s.Items != null && s.Quests != null && s.Home != null && s.Stables != null && s.Archive != null && s.LivingWorld != null, "sections rebuilt");
    }

    public static void HollowNestedSectionsLoadIntoEverySystem()
    {
        // each section present but its inner collections null: the shape of a save written by a build that lacked the inner field
        var s = Load("{\"LifeSkills\":{\"Xp\":null,\"Rank\":null,\"Commissions\":null,\"Crafted\":null},"
            + "\"Home\":{\"Tier\":null,\"Plots\":null,\"Storage\":null},"
            + "\"Stables\":{\"Eggs\":null,\"LastFed\":null,\"PairReady\":null,\"SpeciesSeen\":null,\"Markings\":null,\"NextEgg\":0},"
            + "\"Archive\":{\"Entries\":null,\"FoundFragments\":null,\"Restored\":null},"
            + "\"Dungeons\":{\"Dungeons\":null},\"Labyrinth\":{\"Floors\":null,\"Stairs\":null},"
            + "\"LivingWorld\":{\"Events\":{\"LastStartDay\":null,\"Active\":null},\"Journal\":{\"Entries\":null}},"
            + "\"Map\":{\"Regions\":null,\"Areas\":null},\"GearFittings\":null}");
        Assert.Equal(0, SaveRules.Validate(s).Count, "valid");
        var skills = new LifeSkills(Repo.Db.LifeSkills); skills.Load(s.LifeSkills);
        var home = new Home(Repo.Db.Housing, Repo.Db.Crops, Repo.Db.Quality, skills); home.Load(s.Home);
        var stables = new Stables(Repo.Db.Stables, new PartnerRoster(Repo.Db.World.Taming), Repo.Db.World.Taming, home, Repo.Db.Species); stables.Load(s.Stables);
        Assert.Equal(0, stables.Eggs.Count, "no eggs");
        new CivilizationArchive(Repo.Db.Archive).Load(s.Archive);
        var lab = new Labyrinth(Repo.Load<LabyrinthData>("Data/World/labyrinth.json")); new LabyrinthKnowledge(lab).Load(s.Labyrinth);
        new GearFitter(Repo.Db.Gear, Repo.Db.Items, Repo.Db.Quality).Load(s.GearFittings);
        foreach (var d in Repo.Db.Dungeons.Values) new DungeonKnowledge(d).Load(null);
    }

    public static void UpgradeIsIdempotentAndTheSerialisedFormIsAFixedPoint()
    {
        var old = "{\"Version\":1,\"Level\":7,\"Copper\":50,\"Flags\":[\"a\"],\"CompanionBonds\":[{\"CompanionId\":\"cmp_x\"}],\"CompanionPresets\":{\"cmp_x\":\"defensive\"}}";
        var once = Load(old);
        var j1 = JsonSerializer.Serialize(once, Opts);
        var twice = SaveRules.Upgrade(JsonSerializer.Deserialize<SaveGame>(j1, Opts));
        Assert.Equal(j1, JsonSerializer.Serialize(twice, Opts), "a second load changes nothing");
        Assert.Equal(7, twice.Level, "level kept");
        Assert.Equal("Defensive", twice.CompanionPresets["cmp_x"], "preset normalised once");
    }

    public static void UnknownJsonFieldsFromANewerBuildAreIgnored()
    {
        var s = Load("{\"Version\":1,\"Level\":3,\"SomethingFromTheFuture\":{\"a\":[1,2]},\"Home\":{\"Tier\":\"inn_room\",\"NewField\":7}}");
        Assert.Equal(3, s.Level, "known fields still read");
        Assert.Equal(0, SaveRules.Validate(s).Count, "valid");
    }

    public static void ASaveFromANewerVersionIsRejectedEvenAfterUpgrade()
    {
        // PlayerSave.Load calls Upgrade and then Validate: Upgrade must not stamp a future version as current, or an older build
        // would load a newer save as if it were its own and overwrite it on the next autosave.
        var s = Load("{\"Version\":" + (SaveGame.CurrentVersion + 1) + ",\"Level\":3}");
        Assert.Equal(SaveGame.CurrentVersion + 1, s.Version, "Upgrade leaves a future version alone");
        Assert.True(SaveRules.Validate(s).Count > 0, "Validate still rejects it after Upgrade");
        var zero = Load("{\"Version\":0}");
        Assert.True(SaveRules.Validate(zero).Count > 0, "version 0 is still rejected after Upgrade");
        var neg = Load("{\"Version\":-3}");
        Assert.True(SaveRules.Validate(neg).Count > 0, "negative version is still rejected after Upgrade");
    }

    public static void AnOlderVersionIsStampedCurrentOnlyWhenItWasInRange()
    {
        var s = Load("{\"Version\":1}");
        Assert.Equal(SaveGame.CurrentVersion, s.Version, "stamped current");
        Assert.Equal(0, SaveRules.Validate(s).Count, "valid");
    }

    // ---- QA regression additions: frozen historical shapes and per-field removal ----

    static readonly string[] AllFieldNames = typeof(SaveGame).GetProperties(BindingFlags.Public | BindingFlags.Instance).Select(p => p.Name).ToArray();

    public static void DroppingAnySingleFieldFromAFullSaveStillLoadsValid()
    {
        // A save written by a build that predates field X is the full save minus X. Prove it for every field, so adding a field can never break old saves.
        var full = Load("{}");
        full.Level = 12; full.Copper = 340; full.Items["itm_x"] = 2; full.Flags.Add("f1");
        var json = JsonSerializer.Serialize(full, Opts);
        foreach (var name in AllFieldNames)
        {
            var copy = System.Text.Json.Nodes.JsonNode.Parse(json).AsObject();
            copy.Remove(name);
            SaveGame s;
            try { s = Load(copy.ToJsonString()); }
            catch (Exception e) { throw new Exception($"a save without '{name}' fails to load: {e.Message}"); }
            var errs = SaveRules.Validate(s);
            Assert.Equal(0, errs.Count, $"save without '{name}' is valid ({string.Join("; ", errs)})");
            if (name != nameof(SaveGame.Level)) Assert.Equal(12, s.Level, $"level survives the loss of '{name}'");
        }
    }

    public static void FrozenOldSaveShapesKeepTheirDataAndLoadIntoEverySystem()
    {
        // Hand-written snapshots of what earlier builds wrote. They are frozen: never edit them to make a test pass, fix the loader instead.
        var ring0Early = "{\"Version\":1,\"Difficulty\":\"Adventurer\",\"Level\":4,\"XpIntoLevel\":120,\"Copper\":88,\"Items\":{\"itm_potion_minor\":3},"
            + "\"Deaths\":2,\"Respawn\":[10.5,0,-4,90],\"WaystoneId\":\"ws_start\",\"FireBombs\":2,\"Flags\":[\"met_guide\"],\"CompletedQuests\":[\"q_first\"],"
            + "\"GuildPoints\":15,\"GuildRank\":\"F\"}";
        var midBuild = "{\"Version\":1,\"Level\":18,\"XpIntoLevel\":5,\"Copper\":4000,\"Items\":{\"itm_ore_iron\":9},\"KnownRecipes\":[\"rcp_x\"],"
            + "\"GuildRank\":\"D\",\"RankGp\":40,\"QuestsAtRank\":3,\"Equipment\":{\"Weapon\":\"itm_sword_iron\"},\"ClockSeconds\":5400.5,"
            + "\"LifeSkills\":{\"Xp\":{},\"Rank\":{},\"Commissions\":{},\"Crafted\":[]},\"RestBuffs\":[],\"TabCopper\":30,\"TabPaidOnce\":true,\"InnNights\":{\"brindlewick\":2}}";
        var preCompanions = "{\"Version\":1,\"Level\":30,\"Copper\":1,\"Home\":{\"Tier\":\"inn_room\",\"Plots\":[],\"Storage\":{}},\"Stables\":{\"Eggs\":[],\"NextEgg\":0},"
            + "\"Archive\":{\"Entries\":{},\"FoundFragments\":[],\"Restored\":[]},\"Dungeons\":{\"Dungeons\":{}},\"Labyrinth\":{\"Floors\":{},\"Stairs\":{}}}";

        var a = Load(ring0Early);
        Assert.Equal(4, a.Level, "ring0 level"); Assert.Equal(88L, a.Copper, "ring0 copper"); Assert.Equal(3, a.Items["itm_potion_minor"], "ring0 item");
        Assert.Equal(2, a.Deaths, "ring0 deaths"); Assert.Equal(4, a.Respawn.Length, "ring0 respawn"); Assert.Equal("ws_start", a.WaystoneId, "ring0 waystone");
        Assert.True(a.Flags.Contains("met_guide") && a.CompletedQuests.Contains("q_first"), "ring0 flags and quests");
        Assert.Equal(0, SaveRules.Validate(a).Count, "ring0 valid");

        var b = Load(midBuild);
        Assert.Equal(18, b.Level, "mid level"); Assert.Equal(RankLetter.D, b.GuildRank, "mid rank"); Assert.Equal("itm_sword_iron", b.Equipment["Weapon"], "mid gear");
        Assert.True(b.ClockSeconds.HasValue && b.ClockSeconds.Value == 5400.5, "mid clock"); Assert.True(b.TabPaidOnce && b.TabCopper == 30, "mid tab"); Assert.Equal(2, b.InnNights["brindlewick"], "mid inn");
        Assert.Equal(0, SaveRules.Validate(b).Count, "mid valid");
        Assert.True(b.CompanionBonds != null && b.CompanionBonds.Count == 0 && b.Accessibility != null, "later sections are filled");

        var c = Load(preCompanions);
        Assert.Equal(30, c.Level, "pre-companion level");
        Assert.Equal(0, SaveRules.Validate(c).Count, "pre-companion valid");
        var skills = new LifeSkills(Repo.Db.LifeSkills); skills.Load(c.LifeSkills);
        var home = new Home(Repo.Db.Housing, Repo.Db.Crops, Repo.Db.Quality, skills); home.Load(c.Home);
        new CivilizationArchive(Repo.Db.Archive).Load(c.Archive);
        foreach (var save in new[] { a, b, c })
        {
            var j1 = JsonSerializer.Serialize(save, Opts);
            Assert.Equal(j1, JsonSerializer.Serialize(SaveRules.Upgrade(JsonSerializer.Deserialize<SaveGame>(j1, Opts)), Opts), "fixed point");
        }
    }

    public static void EnumsReadFromNamesAndFromNumbersAndCaseInsensitively()
    {
        Assert.Equal(RankLetter.D, Load("{\"GuildRank\":\"d\"}").GuildRank, "lowercase name");
        Assert.Equal(RankLetter.D, Load("{\"GuildRank\":\"D\"}").GuildRank, "name");
        Assert.Equal((RankLetter)1, Load("{\"GuildRank\":1}").GuildRank, "number");
        Assert.Equal((Difficulty)0, Load("{\"Difficulty\":0}").Difficulty, "difficulty number");
    }

    public static void NonsenseValuesAreRejectedNotLoadedAsValid()
    {
        Assert.True(SaveRules.Validate(Load("{\"Level\":0}")).Count > 0, "level 0");
        Assert.True(SaveRules.Validate(Load("{\"Level\":" + (Levels.Cap + 1) + "}")).Count > 0, "level over cap");
        Assert.True(SaveRules.Validate(Load("{\"Copper\":-1}")).Count > 0, "negative copper");
        Assert.True(SaveRules.Validate(Load("{\"XpIntoLevel\":-5}")).Count > 0, "negative xp");
        Assert.True(SaveRules.Validate(Load("{\"ClockSeconds\":-1}")).Count > 0, "negative clock");
        Assert.True(SaveRules.Validate(Load("{\"Items\":{\"itm_a\":0}}")).Count > 0, "zero stack");
        Assert.True(SaveRules.Validate(Load("{\"Respawn\":[1,2,3]}")).Count > 0, "short respawn");
        Assert.True(SaveRules.Validate(Load("{\"Lantern\":[1,2]}")).Count > 0, "short lantern");
    }
}
