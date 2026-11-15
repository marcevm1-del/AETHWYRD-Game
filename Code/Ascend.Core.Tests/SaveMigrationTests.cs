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
        // the loader (PlayerAppearance.Load) builds it with CustomizationRules.FromLegacy, which needs customization.json
        nameof(SaveGame.Customization),
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
}
