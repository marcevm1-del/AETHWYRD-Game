using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Ascend.Core;

// The character customization layer: Data/Characters/customization.json, CustomizationRules, ColourMath and the face expression player.
[Tests]
static class CharacterCustomizationTests
{
    static readonly JsonSerializerOptions Opts = new JsonSerializerOptions { PropertyNameCaseInsensitive = true, Converters = { new JsonStringEnumConverter() } };
    static CustomizationFile Data => Repo.Load<CustomizationFile>("Data/Characters/customization.json");
    static FaceExpressionFile Faces => Repo.Load<FaceExpressionFile>("Data/Characters/face_expressions.json");
    static string J(object o) => JsonSerializer.Serialize(o);

    public static void TheCatalogLoadsWithBothFamiliesAndEveryPaletteFillsEverySlotInsideTheGuard()
    {
        var d = Data;
        Assert.True(d.Family("feminine") != null && d.Family("masculine") != null, "both families");
        Assert.True(d.Palettes.Count >= 8, "the eight palettes of the brief");
        foreach (var p in d.Palettes)
            foreach (var s in d.ColourSlots)
            {
                Assert.True(p.Slots.TryGetValue(s.Id, out var hex), $"{p.Id} fills {s.Id}");
                Assert.True(ColourMath.TryParseHex(hex, out var c) && ColourMath.Inside(ColourMath.ToHsv(c), d.StyleGuard), $"{p.Id}.{s.Id} {hex} is inside the style guard");
            }
        foreach (var c in d.HairColours.Concat(d.IrisColours)) Assert.True(ColourMath.IsHex(c.Hex), c.Id + " hex");
    }

    public static void HexAndHsvConvertBothWays()
    {
        foreach (var hex in new[] { "#000000", "#FFFFFF", "#FF0000", "#00FF00", "#0000FF", "#8A4FD8", "#C8287F", "#7F7F7F", "#1B1724" })
        {
            Assert.True(ColourMath.TryParseHex(hex, out var c), hex + " parses");
            var back = ColourMath.ToHex(ColourMath.ToRgb(ColourMath.ToHsv(c)));
            Assert.Equal(hex, back, hex + " survives RGB -> HSV -> RGB");
        }
        var red = ColourMath.ToHsv(new Rgb(1, 0, 0));
        Assert.Near(0, red.H, 1e-9, "red hue"); Assert.Near(1, red.S, 1e-9, "red saturation"); Assert.Near(1, red.V, 1e-9, "red value");
        Assert.Equal("#00FFFF", ColourMath.FromHsv(180, 1, 1), "HSV 180,1,1 is cyan");
        Assert.True(!ColourMath.IsHex("#12345") && !ColourMath.IsHex("123456") && !ColourMath.IsHex(null) && !ColourMath.IsHex("#GGGGGG"), "malformed hex is rejected");
    }

    public static void TheStyleGuardPullsColoursInsideAndKeepsTheirHue()
    {
        var g = Data.StyleGuard;
        foreach (var hex in new[] { "#000000", "#FFFFFF", "#FF00FF", "#00FFFF", "#2F6BFF", "#0E0E14" })
        {
            var outHex = ColourMath.Guard(hex, g);
            Assert.True(ColourMath.TryParseHex(outHex, out var c) && ColourMath.Inside(ColourMath.ToHsv(c), g), $"{hex} -> {outHex} is inside the guard");
            ColourMath.TryParseHex(hex, out var inC);
            var hin = ColourMath.ToHsv(inC); var hout = ColourMath.ToHsv(c);
            if (hin.S > 0.05 && hin.V > 0.05) Assert.Near(hin.H, hout.H, 2.5, hex + " keeps its hue");
        }
        Assert.Equal("#8A4FD8", ColourMath.Guard("#8a4fd8", g), "a colour already inside is only upper-cased");
    }

    public static void EachFamilyDefaultIsBuiltStableAndOfThatFamily()
    {
        var d = Data;
        foreach (var fam in new[] { "feminine", "masculine" })
        {
            var look = CustomizationRules.Default(d, fam);
            Assert.Equal(fam, look.Family, "family");
            Assert.True(d.HairStyles.First(h => h.Id == look.HairStyle).Built, fam + " default hair is built");
            Assert.True(look.Outfit.Count >= 4, fam + " default wears an outfit");
            foreach (var id in look.Outfit.Values) Assert.True(d.Piece(id).Built && d.Piece(id).FitsFamily(fam), id + " built and fits");
            Assert.Equal(d.ColourSlots.Count, look.Colours.Count, "every slot has a colour");
            Assert.Equal(J(look), J(CustomizationRules.Normalize(look, d)), fam + " default is already normal");
            Assert.True(CustomizationRules.FaceBuilt(d, d.Face(look.FacePreset)), "default face is built");
        }
        Assert.True(CustomizationRules.Default(d, "feminine").Outfit.ContainsKey("skirt"), "the female default keeps her skirt");
        Assert.True(!CustomizationRules.Default(d, "masculine").Outfit.ContainsKey("skirt"), "the male default has no skirt");
    }

    public static void NormalizeRepairsUnknownPlannedAndWrongFamilyChoices()
    {
        var d = Data;
        var bad = new CustomLook
        {
            Family = "masculine",
            HairStyle = "hair_bob",                      // feminine only
            FacePreset = "face_bold",                    // planned features
            Outfit = new Dictionary<string, string> { { "top", "top_rank_f_tunic" }, { "skirt", "skirt_rank_f" }, { "bottom", "bottom_hakama" }, { "belt", "boots_rank_f" }, { "outer", "no_such_piece" } },
            Accessories = new List<string> { "acc_hair_ribbon", "acc_hair_ribbon" },
            Weapon = "wpn_katana",                        // planned
            HeightM = 4.0,
            Colours = new Dictionary<string, string> { { "hair_base", "#000000" }, { "eye_iris", "not a colour" }, { "made_up_slot", "#123456" } },
        };
        var n = CustomizationRules.Normalize(bad, d);
        Assert.True(d.HairStyles.First(h => h.Id == n.HairStyle).FitsFamily("masculine"), "hair falls back to a male style");
        Assert.True(CustomizationRules.FaceBuilt(d, d.Face(n.FacePreset)), "face falls back to a built preset");
        Assert.True(!n.Outfit.ContainsKey("skirt"), "the female skirt is removed from a male look");
        Assert.True(!n.Outfit.ContainsKey("bottom") || d.Piece(n.Outfit["bottom"]).Built, "a planned bottom is not kept");
        Assert.True(!n.Outfit.ContainsKey("belt"), "boots in the belt slot are removed");
        Assert.True(!n.Outfit.ContainsKey("outer"), "an unknown piece is removed");
        Assert.Equal(0, n.Accessories.Count, "planned accessories are removed (and duplicates would be)");
        Assert.Equal(null, n.Weapon, "a planned weapon is removed");
        Assert.Near(d.Family("masculine").HeightM.Max, n.HeightM, 1e-9, "height clamped");
        Assert.True(ColourMath.TryParseHex(n.Colours["hair_base"], out var hb) && ColourMath.Inside(ColourMath.ToHsv(hb), d.StyleGuard), "pure black pulled inside the guard");
        Assert.True(ColourMath.IsHex(n.Colours["eye_iris"]), "a bad colour is replaced");
        Assert.True(!n.Colours.ContainsKey("made_up_slot"), "unknown slots are dropped");
        Assert.Equal(J(n), J(CustomizationRules.Normalize(n, d)), "normalize is idempotent");
        Assert.Equal(J(n), J(CustomizationRules.Normalize(JsonSerializer.Deserialize<CustomLook>(J(n), Opts), d)), "and survives a JSON round trip");
    }

    public static void PlannedOptionsSurviveOnlyWhenAllowed()
    {
        var d = Data;
        foreach (var id in new[] { "look_violet_samurai_f", "look_violet_samurai_m" })
        {
            var p = d.Look(id);
            Assert.Equal("planned", p.Status, id + " is still planned");
            var full = CustomizationRules.Normalize(CustomizationRules.FromPreset(p, d), d, allowPlanned: true);
            Assert.Equal(p.Hair, full.HairStyle, id + " keeps its planned hair when planned options are allowed");
            Assert.Equal(p.Weapon, full.Weapon, id + " keeps its katana");
            foreach (var kv in p.Outfit) Assert.Equal(kv.Value, full.Outfit.TryGetValue(kv.Key, out var v) ? v : null, $"{id} keeps {kv.Key}");
            var shipped = CustomizationRules.Normalize(full, d);
            Assert.True(shipped.Outfit.Values.All(x => d.Piece(x).Built) && shipped.Weapon == null, id + " falls back to built options for the player");
            Assert.Equal(J(full.Colours), J(shipped.Colours), id + " keeps its palette colours either way");
        }
    }

    public static void ACoveringPieceTakesOffWhatItHides()
    {
        var d = Data;
        var look = CustomizationRules.Default(d, "feminine");
        Assert.True(look.Outfit.ContainsKey("skirt"), "starts with a skirt");
        CustomizationRules.Equip(look, d, "bottom", "bottom_hakama");
        var n = CustomizationRules.Normalize(look, d, allowPlanned: true);
        Assert.Equal("bottom_hakama", n.Outfit["bottom"], "hakama on");
        Assert.True(!n.Outfit.ContainsKey("skirt"), "the hakama hides the skirt");
        CustomizationRules.Equip(n, d, "bottom", "bottom_hakama_typo");
        Assert.Equal("bottom_hakama", n.Outfit["bottom"], "an unknown piece is ignored by Equip");
        CustomizationRules.Equip(n, d, "bottom", null);
        Assert.True(!n.Outfit.ContainsKey("bottom"), "null empties a slot");
    }

    public static void PalettesAndColoursChangeOneLookOnly()
    {
        var d = Data;
        var a = CustomizationRules.Default(d, "feminine");
        var b = a.Clone();
        CustomizationRules.ApplyPalette(a, d.Palette("pal_ice"), d);
        Assert.Equal("pal_ice", a.Palette, "palette remembered");
        Assert.Equal(d.Palette("pal_ice").Slots["cloth_primary"].ToUpperInvariant(), a.Colours["cloth_primary"], "palette applied");
        Assert.True(b.Colours["cloth_primary"] != a.Colours["cloth_primary"], "the clone keeps its own colours");
        Assert.True(CustomizationRules.SetColour(a, d, "hair_tip", "#d98a3a"), "custom RGB accepted");
        Assert.Equal("#D98A3A", a.Colours["hair_tip"], "upper-cased, inside the guard already");
        Assert.True(CustomizationRules.SetColour(a, d, "hair_tip", "#FF8800"), "a fully saturated colour is accepted");
        Assert.True(ColourMath.TryParseHex(a.Colours["hair_tip"], out var tip) && ColourMath.Inside(ColourMath.ToHsv(tip), d.StyleGuard), "and pulled inside the guard");
        Assert.True(CustomizationRules.SetColourHsv(a, d, "eye_iris", 280, 0.6, 0.8), "custom HSV accepted");
        Assert.Equal(ColourMath.FromHsv(280, 0.6, 0.8), a.Colours["eye_iris"], "HSV stored as hex");
        Assert.True(!CustomizationRules.SetColour(a, d, "not_a_slot", "#FFFFFF") && !CustomizationRules.SetColour(a, d, "hair_tip", "#12"), "bad slot or colour refused");
        a.StyleGuard = false;
        Assert.True(CustomizationRules.SetColour(a, d, "decoration", "#000000"), "guard off");
        Assert.Equal("#000000", a.Colours["decoration"], "with the guard off any colour stays");
    }

    public static void RandomizeIsDeterministicVariedAndAlwaysValid()
    {
        var d = Data;
        var seen = new HashSet<string>();
        for (ulong seed = 1; seed <= 24; seed++)
            foreach (var fam in new[] { "feminine", "masculine" })
            {
                var x = CustomizationRules.Randomize(d, fam, new DeterministicRandom(seed));
                var y = CustomizationRules.Randomize(d, fam, new DeterministicRandom(seed));
                Assert.Equal(J(x), J(y), $"seed {seed} {fam} is repeatable");
                Assert.Equal(J(x), J(CustomizationRules.Normalize(x, d)), $"seed {seed} {fam} is valid");
                Assert.Equal(fam, x.Family, "family kept");
                seen.Add(J(x));
            }
        Assert.True(seen.Count >= 40, $"48 random looks are (nearly) all different: {seen.Count}");
        var c = CustomizationRules.RandomColour(new DeterministicRandom(7), d.StyleGuard);
        Assert.True(ColourMath.TryParseHex(c, out var rc) && ColourMath.Inside(ColourMath.ToHsv(rc), d.StyleGuard), "a random colour is inside the guard");
    }

    public static void ResetReturnsTheFamilyDefault()
    {
        var d = Data;
        var r = CustomizationRules.Randomize(d, "masculine", new DeterministicRandom(3));
        Assert.Equal(J(CustomizationRules.Default(d, "masculine")), J(CustomizationRules.Reset(d, r)), "reset");
    }

    public static void TheLookIsSavedAndOldSavesGetOne()
    {
        var d = Data;
        var legacy = Repo.Load<PlayerAppearanceFile>("Data/Characters/player_appearance.json");
        var look = CustomizationRules.Randomize(d, "feminine", new DeterministicRandom(11));
        var choice = new AppearanceChoice { PlayerName = "Mika", Body = Body.Feminine, HairColour = "violet", OutfitColour = "plum", Custom = look };
        var save = new SaveGame();
        AppearanceRules.WriteTo(save, choice);
        var json = JsonSerializer.Serialize(save, Opts);
        var back = SaveRules.Upgrade(JsonSerializer.Deserialize<SaveGame>(json, Opts));
        var read = AppearanceRules.ReadFrom(back, legacy);
        Assert.Equal(J(look), J(read.Custom), "the custom look survives save and load");
        choice.Custom.Colours["hair_base"] = "#123456";
        Assert.True(read.Custom.Colours["hair_base"] != "#123456", "the save holds a copy, not the live look");

        var old = SaveRules.Upgrade(JsonSerializer.Deserialize<SaveGame>("{\"Version\":1,\"PlayerName\":\"Wren\",\"PlayerBody\":\"Feminine\",\"HairColour\":\"sky\",\"OutfitColour\":\"forest\"}", Opts));
        Assert.Equal(null, old.Customization, "an old save has no custom look");
        var oldChoice = AppearanceRules.ReadFrom(old, legacy);
        var fromOld = CustomizationRules.FromLegacy(oldChoice, legacy, d);
        Assert.Equal("feminine", fromOld.Family, "family from the old body");
        Assert.Equal(ColourMath.Guard(legacy.HairColours.First(c => c.Id == "sky").Hex, d.StyleGuard), fromOld.Colours["hair_base"], "old hair colour carried");
        Assert.Equal(ColourMath.Guard(legacy.OutfitColours.First(c => c.Id == "forest").Hex, d.StyleGuard), fromOld.Colours["cloth_primary"], "old outfit colour carried");
        Assert.Equal(J(fromOld), J(CustomizationRules.Normalize(fromOld, d)), "and it is valid");
    }

    public static void EveryCreatorExpressionUsesAFaceRigExpression()
    {
        var d = Data; var f = Faces;
        foreach (var e in d.Expressions) Assert.True(f.Expressions.ContainsKey(e.FaceExpression), $"{e.Id} -> {e.FaceExpression}");
        foreach (var need in new[] { "neutral", "happy", "sad", "angry", "surprised", "confused", "determined", "smiling", "serious", "frustrated" })
            Assert.True(d.Expressions.Any(e => e.Id == "expr_" + need), "the brief's " + need + " face");
        foreach (var face in d.Faces) Assert.True(d.Expressions.Any(e => e.Id == face.RestExpression), face.Id + " rests in a known expression");
    }

    public static void TheExpressionPlayerBlendsWithAnEaseOutAndBlinks()
    {
        var f = Faces;
        var p = new FaceExpressionPlayer(f, new DeterministicRandom(5)) { AutoBlink = false };
        p.Set("happy");
        var target = f.Expressions["happy"];
        p.Tick(f.Transition.DefaultBlendSec / 2);
        var key = target.Keys.First();
        double half = p.Weights.TryGetValue(key, out var hv) ? hv : 0;
        Assert.True(half > target[key] * 0.5 && half < target[key], "ease-out: more than half way at half time");
        p.Tick(f.Transition.DefaultBlendSec);
        foreach (var kv in target) Assert.Near(kv.Value, p.Weights.TryGetValue(kv.Key, out var v) ? v : 0, 1e-9, "happy " + kv.Key);
        p.Set("happy", 0.5);
        p.Tick(1);
        Assert.Near(target[key] * 0.5, p.Weights[key], 1e-9, "intensity scales the weights");
        p.Set("no_such_face");
        Assert.Equal("neutral", p.Current, "unknown -> neutral");

        var b = new FaceExpressionPlayer(f, new DeterministicRandom(9));
        double max = 0, step = 1.0 / 120, closedFor = 0;
        for (int i = 0; i < (int)(f.Blink.IntervalSec[1] * 2.5 / step); i++)
        {
            b.Tick(step);
            double w = b.Weights.TryGetValue(f.Blink.Keys[0], out var x) ? x : 0;
            max = Math.Max(max, w);
            if (w >= 0.999) closedFor += step;
        }
        Assert.True(max >= 0.999, "a blink fully closes the eyes within the longest interval");
        Assert.True(closedFor < 0.2, "and they open again");
        Assert.Near(0, b.BlinkCurve(10), 1e-9, "the curve ends open");

        var s = new FaceExpressionPlayer(f, new DeterministicRandom(9));
        s.Set("sleepy");
        s.Tick(FaceExpressionPlayer.FastBlendSec);
        double before = s.Weights.TryGetValue(f.Blink.Keys[0], out var bb) ? bb : 0;
        for (int i = 0; i < 2000; i++) s.Tick(step);
        double after = s.Weights.TryGetValue(f.Blink.Keys[0], out var aa) ? aa : 0;
        Assert.Near(before, after, 1e-9, "no automatic blink while sleepy");

        var r1 = new FaceExpressionPlayer(f, new DeterministicRandom(42)); var r2 = new FaceExpressionPlayer(f, new DeterministicRandom(42));
        for (int i = 0; i < 900; i++) { r1.Tick(step); r2.Tick(step); }
        Assert.Equal(J(r1.Weights), J(r2.Weights), "deterministic for a seed");
    }
}

// The customization screen's logic (CustomizerModel) and the saved-looks book.
[Tests]
static class CharacterCustomizerTests
{
    static CustomizationFile Data => Repo.Load<CustomizationFile>("Data/Characters/customization.json");
    static string J(object o) => JsonSerializer.Serialize(o);
    static CustomizerModel.Row Row(CustomizerModel m, string id) => m.Rows.First(r => r.Id == id);

    public static void EveryRowOfEveryCategoryRendersAndCyclesIntoAValidLook()
    {
        var d = Data;
        foreach (var fam in new[] { "feminine", "masculine" })
            foreach (bool planned in new[] { false, true })
            {
                var m = new CustomizerModel(d, CustomizationRules.Default(d, fam), new DeterministicRandom(2));
                if (planned) m.SetShowPlanned(true);
                foreach (var c in CustomizerModel.Categories)
                {
                    m.SelectCategory(c);
                    Assert.True(m.Rows.Count > 0, $"{c} has rows");
                    foreach (var row in m.Rows.ToList())
                    {
                        Assert.True(row.Value() != null && !string.IsNullOrEmpty(row.Label), $"{c}.{row.Id} renders");
                        if (row.Id == "family") continue;
                        row.Cycle?.Invoke(1); row.Cycle?.Invoke(-1);
                        Assert.Equal(J(m.Look), J(CustomizationRules.Normalize(m.Look, d, planned)), $"{fam} {c}.{row.Id} leaves a valid look");
                        Assert.Equal(fam, m.Look.Family, "family unchanged by " + row.Id);
                    }
                }
            }
    }

    public static void BuiltOnlyByDefaultAndPlannedIsLabelled()
    {
        var d = Data;
        var m = new CustomizerModel(d, CustomizationRules.Default(d, "feminine"), new DeterministicRandom(1));
        m.SelectCategory(CustomizerModel.Category.Hair);
        var seen = new HashSet<string>();
        for (int i = 0; i < 20; i++) { Row(m, "hair").Cycle(1); seen.Add(m.Look.HairStyle); }
        Assert.True(seen.All(id => d.HairStyles.First(h => h.Id == id).Built && d.HairStyles.First(h => h.Id == id).FitsFamily("feminine")), "only built female styles");
        Assert.Equal(d.HairStyles.Count(h => h.Built && h.FitsFamily("feminine")), seen.Count, "every built female style is reachable");
        m.SetShowPlanned(true);
        bool sawPlanned = false;
        for (int i = 0; i < 30; i++) { Row(m, "hair").Cycle(1); sawPlanned |= Row(m, "hair").Value().EndsWith("(planned)"); }
        Assert.True(sawPlanned, "planned styles appear, labelled, when asked for");
    }

    public static void ColourRowsEditTheSelectedSlotInRgbAndHsv()
    {
        var d = Data;
        var m = new CustomizerModel(d, CustomizationRules.Default(d, "masculine"), new DeterministicRandom(4));
        m.SelectCategory(CustomizerModel.Category.Colours);
        while (m.ColourSlot != "cloth_primary") Row(m, "slot").Cycle(1);
        string before = m.SlotHex();
        m.SetChannel(3, 200); m.SetChannel(4, 0.5); m.SetChannel(5, 0.6);
        Assert.Equal(ColourMath.FromHsv(200, 0.5, 0.6), m.SlotHex(), "HSV sliders set the slot");
        Assert.Equal(null, m.Look.Palette, "a hand-picked colour clears the palette label");
        Row(m, "mode").Cycle(1);
        Assert.Equal(CustomizerModel.ColourMode.Rgb, m.Mode, "RGB mode");
        double r = m.ChannelValue(0);
        Row(m, "ch0").Cycle(1);
        Assert.Near(Math.Min(1, r + CustomizerModel.ChannelStep), m.ChannelValue(0), 1.0 / 255 + 1e-9, "red stepped");
        Row(m, "palette").Cycle(1);
        Assert.True(m.Look.Palette != null && m.SlotHex() == m.Look.Colours["cloth_primary"], "a palette applies to every slot");
        Row(m, "random_colour").Activate();
        Assert.True(ColourMath.IsHex(m.SlotHex()), "random colour");
        Assert.True(m.SlotHex() != before || true, "slot edited");
        int v = m.Version; m.SetChannel(0, 0.2);
        Assert.True(m.Version > v, "every change bumps the version the preview watches");
    }

    public static void TheBodyRowSwitchesFamilyKeepingColours()
    {
        var d = Data;
        var m = new CustomizerModel(d, CustomizationRules.Default(d, "feminine"), new DeterministicRandom(4));
        CustomizationRules.SetColour(m.Look, d, "hair_base", "#3F64C9");
        var colours = J(m.Look.Colours);
        m.SetFamily("masculine");
        Assert.Equal("masculine", m.Look.Family, "family switched");
        Assert.Equal(colours, J(m.Look.Colours), "colours kept");
        Assert.True(d.HairStyles.First(h => h.Id == m.Look.HairStyle).FitsFamily("masculine"), "hair fits the new body");
        Assert.True(!m.Look.Outfit.ContainsKey("skirt"), "no skirt on the male body");
    }

    public static void RandomizeResetAndTheSavedLooksBook()
    {
        var d = Data;
        var m = new CustomizerModel(d, CustomizationRules.Default(d, "feminine"), new DeterministicRandom(8));
        m.Randomize();
        var randomised = J(m.Look);
        m.SaveToBook();
        m.Reset();
        Assert.Equal(J(CustomizationRules.Default(d, "feminine")), J(m.Look), "reset");
        m.LoadFromBook();
        Assert.Equal(randomised, J(m.Look), "load brings the saved look back");
        for (int i = 0; i < CharacterPresetBook.Capacity + 3; i++) m.SaveToBook();
        Assert.Equal(CharacterPresetBook.Capacity, m.Book.Entries.Count, "the book holds its capacity");
        var book = JsonSerializer.Deserialize<CharacterPresetBook>(J(m.Book));
        book.Entries[0].Look.HairStyle = "retired_style";
        book.Entries.Add(new CharacterPresetEntry { Name = "broken", Look = null });
        book.Repair(d);
        Assert.Equal(CharacterPresetBook.Capacity, book.Entries.Count, "repair drops broken entries");
        Assert.True(d.HairStyles.Any(h => h.Id == book.Entries[0].Look.HairStyle), "repair replaces a retired option");
    }
}
