using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Ascend.Core;

// Phase 1B: the character creator data, the appearance rules and the loading tips.
[Tests]
static class FrontEndTests
{
    static readonly JsonSerializerOptions Opts = new JsonSerializerOptions { PropertyNameCaseInsensitive = true, Converters = { new JsonStringEnumConverter() } };

    static PlayerAppearanceFile Data => Repo.Load<PlayerAppearanceFile>("Data/Characters/player_appearance.json");

    public static void TheDataHasBothBodiesAndTheCoreDefaults()
    {
        var d = Data;
        Assert.True(d.Bodies.Any(b => b.Id == "masculine") && d.Bodies.Any(b => b.Id == "feminine"), "both bodies");
        Assert.True(d.HairStyles.Any(x => x.Id == AppearanceDefaults.HairStyle), "default hair style");
        Assert.True(d.HairColours.Any(x => x.Id == AppearanceDefaults.HairColour), "default hair colour");
        Assert.True(d.SkinTones.Any(x => x.Id == AppearanceDefaults.SkinTone), "default skin tone");
        Assert.True(d.OutfitColours.Any(x => x.Id == AppearanceDefaults.OutfitColour), "default outfit colour");
        Assert.Equal(AppearanceDefaults.Name, d.DefaultName, "default name");
        Assert.Equal(AppearanceDefaults.MaxNameLength, d.MaxNameLength, "name limit");
        foreach (var c in d.HairColours.Concat(d.SkinTones).Concat(d.OutfitColours))
            Assert.True(AppearanceRules.TryParseHex(c.Hex, out _, out _, out _), c.Id + " has a valid hex");
    }

    public static void NormalizeClampsNamesAndUnknownIds()
    {
        var d = Data;
        var c = AppearanceRules.Normalize(new AppearanceChoice { PlayerName = "   " + new string('x', 40) + "\t", HairStyle = "nope", HairColour = null, SkinTone = "zzz", OutfitColour = "" }, d);
        Assert.Equal(d.MaxNameLength, c.PlayerName.Length, "name cut to the limit");
        Assert.Equal(AppearanceDefaults.HairStyle, c.HairStyle, "unknown hair style");
        Assert.Equal(AppearanceDefaults.HairColour, c.HairColour, "null hair colour");
        Assert.Equal(AppearanceDefaults.SkinTone, c.SkinTone, "unknown skin");
        Assert.Equal(AppearanceDefaults.OutfitColour, c.OutfitColour, "empty outfit");
        Assert.Equal(d.DefaultName, AppearanceRules.Normalize(new AppearanceChoice { PlayerName = " " }, d).PlayerName, "blank name falls back");
        Assert.Equal(Body.Masculine, AppearanceRules.Normalize(new AppearanceChoice { Body = (Body)9 }, d).Body, "bad body");
    }

    public static void StepWrapsBothWays()
    {
        var ids = new List<string> { "a", "b", "c" };
        Assert.Equal("b", AppearanceRules.Step(ids, "a", 1), "forward");
        Assert.Equal("a", AppearanceRules.Step(ids, "c", 1), "wrap forward");
        Assert.Equal("c", AppearanceRules.Step(ids, "a", -1), "wrap back");
        Assert.Equal(Body.Feminine, AppearanceRules.StepBody(Body.Masculine, 1), "body forward");
        Assert.Equal(Body.Feminine, AppearanceRules.StepBody(Body.Masculine, -1), "body wraps");
    }

    public static void TheLookRoundTripsThroughASave()
    {
        var d = Data;
        var look = new AppearanceChoice { PlayerName = "Wren", Body = Body.Feminine, HairStyle = "ponytail", HairColour = "sky", SkinTone = "tan", OutfitColour = "plum" };
        var s = new SaveGame();
        AppearanceRules.WriteTo(s, look);
        var back = SaveRules.Upgrade(JsonSerializer.Deserialize<SaveGame>(JsonSerializer.Serialize(s, Opts), Opts));
        var read = AppearanceRules.ReadFrom(back, d);
        Assert.Equal("Wren", read.PlayerName, "name");
        Assert.Equal(Body.Feminine, read.Body, "body");
        Assert.Equal("ponytail", read.HairStyle, "hair style");
        Assert.Equal("sky", read.HairColour, "hair colour");
        Assert.Equal("tan", read.SkinTone, "skin");
        Assert.Equal("plum", read.OutfitColour, "outfit");
    }

    public static void AnOldSaveGetsTheAppearanceDefaults()
    {
        var s = SaveRules.Upgrade(JsonSerializer.Deserialize<SaveGame>("{\"Version\":1,\"Level\":3}", Opts));
        Assert.Equal(0, SaveRules.Validate(s).Count, "valid");
        Assert.Equal(AppearanceDefaults.Name, s.PlayerName, "name");
        Assert.Equal(Body.Masculine, s.PlayerBody, "body");
        Assert.Equal(AppearanceDefaults.HairStyle, s.HairStyle, "hair style");
        Assert.Equal(AppearanceDefaults.HairColour, s.HairColour, "hair colour");
        Assert.Equal(AppearanceDefaults.SkinTone, s.SkinTone, "skin");
        Assert.Equal(AppearanceDefaults.OutfitColour, s.OutfitColour, "outfit");
    }

    public static void LoadingTipsAreWarmAndPickIsStable()
    {
        var t = Repo.Load<LoadingTipsFile>("Data/UI/loading_tips.json");
        Assert.True(t.Tips.Count >= 5, "enough tips");
        Assert.Equal(t.Tips.Select(x => x.Id).Distinct().Count(), t.Tips.Count, "unique ids");
        Assert.True(t.Tips.All(x => x.Text.Length >= 10 && x.Text.Length <= 160), "tip length");
        Assert.Equal(t.Pick(3).Id, t.Pick(3).Id, "stable");
        Assert.Equal(t.Pick(0).Id, t.Pick(t.Tips.Count).Id, "wraps");
        Assert.True(new LoadingTipsFile().Pick(1) == null, "none when empty");
    }
}
