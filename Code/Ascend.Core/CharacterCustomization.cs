using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Ascend.Core
{
    // The character customization layer (12_Systems/character_customization.md). Data: Data/Characters/customization.json.
    // It sits on top of the Phase 1B creator (PlayerAppearance.cs): name, body, skin tone and the legacy ids stay there; everything
    // else a player can change about a look lives in a CustomLook. A look stores option ids and #RRGGBB colours per colour slot, never
    // Unity objects, so it survives a restart and data changes: Normalize repairs any id that is missing, retired, planned or made for
    // the other family. Options with status "planned" are designed but have no mesh yet; the creator only offers them when asked to.

    // ------------------------------------------------------------------ data (customization.json)

    public sealed class CustomizationFile
    {
        public int Version { get; set; } = 1;
        public string Notes { get; set; }
        public List<CharacterFamily> Families { get; set; } = new List<CharacterFamily>();
        public List<ColourSlotDef> ColourSlots { get; set; } = new List<ColourSlotDef>();
        /// <summary>Generator material category (CH_cloth, ...) to colour slot; "skin" means the creator's skin tone.</summary>
        public Dictionary<string, string> MaterialSlots { get; set; } = new Dictionary<string, string>();
        public StyleGuard StyleGuard { get; set; } = new StyleGuard();
        public List<ColourPalette> Palettes { get; set; } = new List<ColourPalette>();
        public List<AppearanceColour> HairColours { get; set; } = new List<AppearanceColour>();
        public List<AppearanceColour> IrisColours { get; set; } = new List<AppearanceColour>();
        public List<FaceFeature> EyeShapes { get; set; } = new List<FaceFeature>();
        public List<FaceFeature> PupilStyles { get; set; } = new List<FaceFeature>();
        public List<FaceFeature> Brows { get; set; } = new List<FaceFeature>();
        public List<FaceFeature> Mouths { get; set; } = new List<FaceFeature>();
        public List<ExpressionChoice> Expressions { get; set; } = new List<ExpressionChoice>();
        public List<FacePreset> Faces { get; set; } = new List<FacePreset>();
        public List<HairStyleOption> HairStyles { get; set; } = new List<HairStyleOption>();
        public List<OutfitPiece> OutfitPieces { get; set; } = new List<OutfitPiece>();
        public List<AccessoryOption> Accessories { get; set; } = new List<AccessoryOption>();
        public List<WeaponOption> Weapons { get; set; } = new List<WeaponOption>();
        public List<SocketDef> Sockets { get; set; } = new List<SocketDef>();
        public List<LookPreset> Looks { get; set; } = new List<LookPreset>();

        public CharacterFamily Family(string id) => Families.FirstOrDefault(f => f.Id == id);
        public ColourPalette Palette(string id) => Palettes.FirstOrDefault(p => p.Id == id);
        public LookPreset Look(string id) => Looks.FirstOrDefault(l => l.Id == id);
        public OutfitPiece Piece(string id) => OutfitPieces.FirstOrDefault(p => p.Id == id);
        public FacePreset Face(string id) => Faces.FirstOrDefault(f => f.Id == id);
    }

    public sealed class CharacterFamily
    {
        /// <summary>"feminine" or "masculine": the <see cref="Body"/> names in lower case.</summary>
        public string Id { get; set; }
        public string Name { get; set; }
        public string Body { get; set; }
        /// <summary>The body in Data/Characters/human_library.json the generator builds for this family.</summary>
        public string GeneratorBody { get; set; }
        public HeightRange HeightM { get; set; } = new HeightRange();
        public List<string> Builds { get; set; } = new List<string>();
        public string DefaultLook { get; set; }
    }

    public sealed class HeightRange
    {
        public double Min { get; set; } = 1.5;
        public double Max { get; set; } = 1.9;
        public double Default { get; set; } = 1.7;
    }

    public sealed class ColourSlotDef
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Group { get; set; }
    }

    /// <summary>art_direction.md section 2: no pure black or white, saturation capped outside UI and telegraphs.</summary>
    public sealed class StyleGuard
    {
        public double MinValue { get; set; } = 0.12;
        public double MaxValue { get; set; } = 0.95;
        public double MaxSaturation { get; set; } = 0.90;
        public string Notes { get; set; }
    }

    public sealed class ColourPalette
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public List<string> Swatches { get; set; } = new List<string>();
        /// <summary>Colour slot id to #RRGGBB; a palette fills every slot.</summary>
        public Dictionary<string, string> Slots { get; set; } = new Dictionary<string, string>();
    }

    /// <summary>Something with a build status: "built" has a mesh from the generator, "planned" is designed only.</summary>
    public abstract class CatalogOption
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; } = "planned";
        public string Notes { get; set; }
        /// <summary>Families the option is made for; empty means both.</summary>
        public List<string> Families { get; set; } = new List<string>();
        public bool Built => Status == "built";
        public bool FitsFamily(string family) => Families == null || Families.Count == 0 || Families.Contains(family);
    }

    public sealed class FaceFeature : CatalogOption
    {
        public EyeDecal Decal { get; set; }
    }

    /// <summary>How an eye shape changes the face decal (Tools/blender/ascend_characters/face.py reads these once it supports shapes).</summary>
    public sealed class EyeDecal
    {
        public double WidthScale { get; set; } = 1.0;
        public double HeightRatio { get; set; } = 1.0;
        public double TiltDeg { get; set; }
        public double LidCurve { get; set; } = 0.5;
    }

    /// <summary>A creator expression: one of the face rig's expressions (Data/Characters/face_expressions.json) at an intensity.</summary>
    public sealed class ExpressionChoice
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string FaceExpression { get; set; }
        public double Intensity { get; set; } = 1.0;
    }

    public sealed class FacePreset
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<string> Families { get; set; } = new List<string>();
        public string Eyes { get; set; }
        public string Brows { get; set; }
        public string Mouth { get; set; }
        public string RestExpression { get; set; }
        public string Notes { get; set; }
        public bool FitsFamily(string family) => Families == null || Families.Count == 0 || Families.Contains(family);
    }

    public sealed class HairStyleOption : CatalogOption
    {
        public string Length { get; set; }
        /// <summary>The style id in human_library.json the generator builds (built styles only).</summary>
        public string GeneratorStyle { get; set; }
        /// <summary>Which placeholder hair shape stands in when no body prefab is installed: short, long, ponytail or bun.</summary>
        public string Placeholder { get; set; } = "short";
        /// <summary>"tail" (one spring chain) or "locks" (several short chains); null for no secondary motion.</summary>
        public string SecondaryMotion { get; set; }
    }

    public sealed class OutfitPiece : CatalogOption
    {
        public string Slot { get; set; }
        /// <summary>Generator part objects this piece shows (top, bottom, skirt, belt, boots, bracers, cloak).</summary>
        public List<string> Parts { get; set; } = new List<string>();
        /// <summary>Material category to colour slot, overriding <see cref="CustomizationFile.MaterialSlots"/> for this piece.</summary>
        public Dictionary<string, string> Materials { get; set; } = new Dictionary<string, string>();
        /// <summary>Outfit slots this piece covers; anything equipped there is taken off.</summary>
        public List<string> Hides { get; set; } = new List<string>();
        public List<string> Silhouette { get; set; } = new List<string>();
    }

    public sealed class AccessoryOption : CatalogOption
    {
        public string Socket { get; set; }
        public string ColourSlot { get; set; }
    }

    public sealed class WeaponOption : CatalogOption
    {
        public string WeaponFamily { get; set; }
        public string Held { get; set; }
        public string HeldOff { get; set; }
        public string Sheathed { get; set; }
    }

    public sealed class SocketDef
    {
        public string Id { get; set; }
        /// <summary>A Unity HumanBodyBones name from the rig contract (human_library.json rig.requiredBones).</summary>
        public string Bone { get; set; }
        public List<double> Position { get; set; } = new List<double>();
        public List<double> RotationEuler { get; set; } = new List<double>();
    }

    public sealed class LookPreset
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Face { get; set; }
        public string Hair { get; set; }
        public string Build { get; set; }
        public Dictionary<string, string> Outfit { get; set; } = new Dictionary<string, string>();
        public string Palette { get; set; }
        public List<string> Accessories { get; set; } = new List<string>();
        public string Weapon { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
    }

    // ------------------------------------------------------------------ the saved look

    /// <summary>
    /// Everything about a look beyond the Phase 1B fields. Ids and #RRGGBB strings only, so it serialises as plain JSON.
    /// Null in saves made before customization existed: <see cref="CustomizationRules.FromLegacy"/> builds one.
    /// </summary>
    public sealed class CustomLook
    {
        public int Version { get; set; } = 1;
        public string Family { get; set; } = "masculine";
        public string FacePreset { get; set; }
        public string EyeShape { get; set; }
        public string PupilStyle { get; set; }
        public string Brows { get; set; }
        public string Mouth { get; set; }
        /// <summary>The expression the face rests in (an id from customization.json expressions).</summary>
        public string Expression { get; set; }
        public string HairStyle { get; set; }
        public string Build { get; set; }
        public double HeightM { get; set; }
        /// <summary>Outfit slot to piece id.</summary>
        public Dictionary<string, string> Outfit { get; set; } = new Dictionary<string, string>();
        public List<string> Accessories { get; set; } = new List<string>();
        public string Weapon { get; set; }
        /// <summary>The palette last applied (for the creator's label); the colours themselves are in <see cref="Colours"/>.</summary>
        public string Palette { get; set; }
        /// <summary>Colour slot to #RRGGBB.</summary>
        public Dictionary<string, string> Colours { get; set; } = new Dictionary<string, string>();
        /// <summary>Keep colours inside the art direction's value and saturation range (on by default).</summary>
        public bool StyleGuard { get; set; } = true;

        public CustomLook Clone()
        {
            var c = (CustomLook)MemberwiseClone();
            c.Outfit = new Dictionary<string, string>(Outfit ?? new Dictionary<string, string>());
            c.Accessories = new List<string>(Accessories ?? new List<string>());
            c.Colours = new Dictionary<string, string>(Colours ?? new Dictionary<string, string>());
            return c;
        }
    }

    // ------------------------------------------------------------------ colour maths

    public struct Rgb
    {
        public double R, G, B;
        public Rgb(double r, double g, double b) { R = r; G = g; B = b; }
    }

    public struct Hsv
    {
        /// <summary>Hue in degrees [0, 360), saturation and value in [0, 1].</summary>
        public double H, S, V;
        public Hsv(double h, double s, double v) { H = h; S = s; V = v; }
    }

    public static class ColourMath
    {
        public static bool TryParseHex(string hex, out Rgb c)
        {
            c = default;
            if (!AppearanceRules.TryParseHex(hex, out float r, out float g, out float b)) return false;
            c = new Rgb(r, g, b);
            return true;
        }

        public static bool IsHex(string hex) => TryParseHex(hex, out _);

        public static string ToHex(Rgb c)
        {
            int B8(double v) => (int)Math.Round(Math.Max(0, Math.Min(1, v)) * 255.0);
            return "#" + B8(c.R).ToString("X2", CultureInfo.InvariantCulture) + B8(c.G).ToString("X2", CultureInfo.InvariantCulture) + B8(c.B).ToString("X2", CultureInfo.InvariantCulture);
        }

        public static Hsv ToHsv(Rgb c)
        {
            double mx = Math.Max(c.R, Math.Max(c.G, c.B)), mn = Math.Min(c.R, Math.Min(c.G, c.B)), d = mx - mn;
            double h = 0;
            if (d > 1e-9)
            {
                if (mx == c.R) h = 60 * (((c.G - c.B) / d) % 6);
                else if (mx == c.G) h = 60 * ((c.B - c.R) / d + 2);
                else h = 60 * ((c.R - c.G) / d + 4);
            }
            if (h < 0) h += 360;
            return new Hsv(h, mx <= 1e-9 ? 0 : d / mx, mx);
        }

        public static Rgb ToRgb(Hsv h)
        {
            double hue = ((h.H % 360) + 360) % 360, s = Clamp01(h.S), v = Clamp01(h.V);
            double c = v * s, x = c * (1 - Math.Abs((hue / 60) % 2 - 1)), m = v - c;
            double r, g, b;
            if (hue < 60) { r = c; g = x; b = 0; }
            else if (hue < 120) { r = x; g = c; b = 0; }
            else if (hue < 180) { r = 0; g = c; b = x; }
            else if (hue < 240) { r = 0; g = x; b = c; }
            else if (hue < 300) { r = x; g = 0; b = c; }
            else { r = c; g = 0; b = x; }
            return new Rgb(r + m, g + m, b + m);
        }

        public static string FromHsv(double h, double s, double v) => ToHex(ToRgb(new Hsv(h, s, v)));

        /// <summary>Pulls a colour inside the style guard: value into [min, max], saturation down to the cap. Hue is kept.</summary>
        public static string Guard(string hex, StyleGuard g)
        {
            if (!TryParseHex(hex, out var c)) return hex;
            if (g == null) return ToHex(c);
            var h = ToHsv(c);
            bool inside = h.V >= g.MinValue - 1e-9 && h.V <= g.MaxValue + 1e-9 && h.S <= g.MaxSaturation + 1e-9;
            if (inside) return hex.ToUpperInvariant();
            h.V = Math.Max(g.MinValue, Math.Min(g.MaxValue, h.V));
            h.S = Math.Min(g.MaxSaturation, h.S);
            // rounding to 8 bits can land a hair outside; nudge inward so the result always passes the guard
            string outHex = ToHex(ToRgb(h));
            for (int i = 0; i < 4 && TryParseHex(outHex, out var q) && !Inside(ToHsv(q), g); i++)
            {
                h.V = Math.Max(g.MinValue + 0.004 * (i + 1), Math.Min(g.MaxValue - 0.004 * (i + 1), h.V));
                h.S = Math.Min(g.MaxSaturation - 0.004 * (i + 1), h.S);
                outHex = ToHex(ToRgb(h));
            }
            return outHex;
        }

        public static bool Inside(Hsv h, StyleGuard g) => h.V >= g.MinValue - 1e-9 && h.V <= g.MaxValue + 1e-9 && h.S <= g.MaxSaturation + 1e-9;

        static double Clamp01(double v) => v < 0 ? 0 : v > 1 ? 1 : v;
    }

    // ------------------------------------------------------------------ rules

    public static class CustomizationRules
    {
        public const int MaxAccessories = 6;
        public static string FamilyOf(Body body) => body == Body.Feminine ? "feminine" : "masculine";

        /// <summary>The family's default look (its built default preset), normalised.</summary>
        public static CustomLook Default(CustomizationFile f, string family)
        {
            var fam = f?.Family(family) ?? f?.Families.FirstOrDefault();
            var preset = fam != null ? f.Look(fam.DefaultLook) : null;
            var look = preset != null ? FromPreset(preset, f) : new CustomLook { Family = fam?.Id ?? family };
            return Normalize(look, f);
        }

        /// <summary>Reset: the default look of the same family.</summary>
        public static CustomLook Reset(CustomizationFile f, CustomLook current) => Default(f, current?.Family ?? "masculine");

        /// <summary>A look from a named preset (not normalised: planned options survive so a caller can see what is missing).</summary>
        public static CustomLook FromPreset(LookPreset p, CustomizationFile f)
        {
            var face = f?.Face(p.Face);
            var fam = f?.Family(p.Family);
            var look = new CustomLook
            {
                Family = p.Family,
                FacePreset = p.Face,
                EyeShape = face?.Eyes,
                Brows = face?.Brows,
                Mouth = face?.Mouth,
                Expression = face?.RestExpression,
                HairStyle = p.Hair,
                Build = p.Build,
                HeightM = fam?.HeightM.Default ?? 1.7,
                Outfit = new Dictionary<string, string>(p.Outfit ?? new Dictionary<string, string>()),
                Accessories = new List<string>(p.Accessories ?? new List<string>()),
                Weapon = p.Weapon,
            };
            var pal = f?.Palette(p.Palette);
            if (pal != null) ApplyPalette(look, pal, f);
            return look;
        }

        /// <summary>
        /// Makes a look safe to show and to save. Unknown, retired or wrong-family ids fall back to the family default; planned
        /// options fall back too unless <paramref name="allowPlanned"/>; an outfit piece in the wrong slot, a piece hidden by
        /// another, duplicate or same-socket accessories are dropped; height is clamped to the family's band; every colour slot
        /// gets a valid colour (inside the style guard when the look asks for it). Never throws on bad input.
        /// </summary>
        public static CustomLook Normalize(CustomLook look, CustomizationFile f, bool allowPlanned = false)
        {
            look = look?.Clone() ?? new CustomLook();
            if (f == null || f.Families.Count == 0) return look;
            var fam = f.Family(look.Family) ?? f.Family("masculine") ?? f.Families[0];
            look.Family = fam.Id;
            var fallback = fam.DefaultLook != null && f.Look(fam.DefaultLook) != null ? FromPreset(f.Look(fam.DefaultLook), f) : new CustomLook { Family = fam.Id };

            bool Ok(CatalogOption o) => o != null && o.FitsFamily(fam.Id) && (allowPlanned || o.Built);
            string PickOpt<T>(List<T> list, string id, string fb) where T : CatalogOption
            {
                var o = list.FirstOrDefault(x => x.Id == id);
                if (Ok(o)) return id;
                var d = list.FirstOrDefault(x => x.Id == fb);
                if (Ok(d)) return fb;
                return list.FirstOrDefault(Ok)?.Id;
            }

            var face = f.Face(look.FacePreset);
            if (face == null || !face.FitsFamily(fam.Id) || (!allowPlanned && !FaceBuilt(f, face))) { face = f.Face(fallback.FacePreset); look.FacePreset = face?.Id; }
            look.EyeShape = PickOpt(f.EyeShapes, look.EyeShape ?? face?.Eyes, face?.Eyes ?? fallback.EyeShape);
            look.PupilStyle = PickOpt(f.PupilStyles, look.PupilStyle, fallback.PupilStyle);
            look.Brows = PickOpt(f.Brows, look.Brows ?? face?.Brows, face?.Brows ?? fallback.Brows);
            look.Mouth = PickOpt(f.Mouths, look.Mouth ?? face?.Mouth, face?.Mouth ?? fallback.Mouth);
            if (f.Expressions.All(e => e.Id != look.Expression)) look.Expression = face?.RestExpression ?? f.Expressions.FirstOrDefault()?.Id;
            look.HairStyle = PickOpt(f.HairStyles, look.HairStyle, fallback.HairStyle);
            if (!fam.Builds.Contains(look.Build)) look.Build = fam.Builds.Contains("average") ? "average" : fam.Builds.FirstOrDefault();
            if (double.IsNaN(look.HeightM) || look.HeightM <= 0) look.HeightM = fam.HeightM.Default;
            look.HeightM = Math.Max(fam.HeightM.Min, Math.Min(fam.HeightM.Max, look.HeightM));

            // outfit: valid piece per slot, then remove what the equipped pieces hide
            var outfit = new Dictionary<string, string>();
            foreach (var kv in (look.Outfit ?? new Dictionary<string, string>()).OrderBy(k => k.Key, StringComparer.Ordinal))
            {
                var p = f.Piece(kv.Value);
                if (p != null && p.Slot == kv.Key && Ok(p)) outfit[kv.Key] = p.Id;
            }
            if (!outfit.ContainsKey("top"))
            {
                var fb = fallback.Outfit != null && fallback.Outfit.TryGetValue("top", out var t) ? f.Piece(t) : null;
                if (Ok(fb)) outfit["top"] = fb.Id;
            }
            foreach (var hidden in outfit.Values.ToList().SelectMany(id => f.Piece(id)?.Hides ?? new List<string>()).Distinct().ToList())
                if (outfit.TryGetValue(hidden, out var hp) && !(f.Piece(hp)?.Hides ?? new List<string>()).Contains(hidden)) outfit.Remove(hidden);
            look.Outfit = outfit;

            // accessories: known, allowed, no duplicates, one per socket, capped
            var acc = new List<string>();
            var sockets = new HashSet<string>();
            foreach (var id in look.Accessories ?? new List<string>())
            {
                var a = f.Accessories.FirstOrDefault(x => x.Id == id);
                if (!Ok(a) || acc.Contains(id) || !sockets.Add(a.Socket) || acc.Count >= MaxAccessories) continue;
                acc.Add(id);
            }
            look.Accessories = acc;
            var w = f.Weapons.FirstOrDefault(x => x.Id == look.Weapon);
            look.Weapon = Ok(w) ? w.Id : null;

            // colours: every slot gets a valid #RRGGBB
            var basePal = f.Palette(look.Palette) ?? f.Palettes.FirstOrDefault();
            var colours = new Dictionary<string, string>();
            foreach (var slot in f.ColourSlots)
            {
                string hex = null;
                if (look.Colours != null && look.Colours.TryGetValue(slot.Id, out var h) && ColourMath.IsHex(h)) hex = h.ToUpperInvariant();
                if (hex == null && basePal != null && basePal.Slots.TryGetValue(slot.Id, out var ph)) hex = ph.ToUpperInvariant();
                if (hex == null) hex = "#808080";
                colours[slot.Id] = look.StyleGuard ? ColourMath.Guard(hex, f.StyleGuard) : hex;
            }
            look.Colours = colours;
            if (look.Palette != null && f.Palette(look.Palette) == null) look.Palette = null;
            return look;
        }

        /// <summary>Fills every colour slot from a palette and remembers which palette it was.</summary>
        public static void ApplyPalette(CustomLook look, ColourPalette p, CustomizationFile f = null)
        {
            if (look == null || p == null) return;
            look.Colours = look.Colours ?? new Dictionary<string, string>();
            foreach (var kv in p.Slots)
                look.Colours[kv.Key] = look.StyleGuard && f != null ? ColourMath.Guard(kv.Value, f.StyleGuard) : kv.Value.ToUpperInvariant();
            look.Palette = p.Id;
        }

        /// <summary>Sets one slot to any colour (RGB or HSV pickers end here). False when the slot or the colour is invalid.</summary>
        public static bool SetColour(CustomLook look, CustomizationFile f, string slot, string hex)
        {
            if (look == null || f == null || f.ColourSlots.All(s => s.Id != slot) || !ColourMath.IsHex(hex)) return false;
            look.Colours[slot] = look.StyleGuard ? ColourMath.Guard(hex, f.StyleGuard) : hex.ToUpperInvariant();
            return true;
        }

        public static bool SetColourHsv(CustomLook look, CustomizationFile f, string slot, double h, double s, double v) =>
            SetColour(look, f, slot, ColourMath.FromHsv(h, s, v));

        /// <summary>Applies a face preset: its eyes, brows, mouth and resting expression.</summary>
        public static void ApplyFace(CustomLook look, FacePreset face)
        {
            if (look == null || face == null) return;
            look.FacePreset = face.Id; look.EyeShape = face.Eyes; look.Brows = face.Brows; look.Mouth = face.Mouth; look.Expression = face.RestExpression;
        }

        /// <summary>Equips a piece in its slot (null id empties the slot). Normalize afterwards resolves what it hides.</summary>
        public static void Equip(CustomLook look, CustomizationFile f, string slot, string pieceId)
        {
            if (look == null) return;
            if (string.IsNullOrEmpty(pieceId)) { look.Outfit.Remove(slot); return; }
            var p = f?.Piece(pieceId);
            if (p == null || p.Slot != slot) return;
            look.Outfit[slot] = pieceId;
            foreach (var h in p.Hides ?? new List<string>()) if (h != slot) look.Outfit.Remove(h);
        }

        /// <summary>
        /// A random but coherent look for a family: random face, hair and pieces among what may be shown, a random palette as the
        /// base, then a random hair colour and eye colour on top so two randomised characters rarely share a scheme.
        /// The same seed always gives the same look.
        /// </summary>
        public static CustomLook Randomize(CustomizationFile f, string family, IRandom rng, bool allowPlanned = false)
        {
            var look = Default(f, family);
            if (f == null || rng == null) return look;
            bool Ok(CatalogOption o) => o.FitsFamily(look.Family) && (allowPlanned || o.Built);
            T Pick<T>(IList<T> list) => list.Count == 0 ? default : list[(int)(rng.NextDouble() * list.Count) % list.Count];

            var faces = f.Faces.Where(x => x.FitsFamily(look.Family)).ToList();
            var face = Pick(faces);
            if (face != null) ApplyFace(look, face);
            look.HairStyle = Pick(f.HairStyles.Where(Ok).ToList())?.Id ?? look.HairStyle;
            var fam = f.Family(look.Family);
            if (fam != null)
            {
                look.Build = Pick(fam.Builds) ?? look.Build;
                look.HeightM = Math.Round(fam.HeightM.Min + rng.NextDouble() * (fam.HeightM.Max - fam.HeightM.Min), 2);
            }
            var slots = f.OutfitPieces.Where(Ok).Select(p => p.Slot).Distinct().OrderBy(s => s, StringComparer.Ordinal).ToList();
            foreach (var slot in slots)
            {
                var choices = f.OutfitPieces.Where(p => p.Slot == slot && Ok(p)).ToList();
                if (slot != "top" && rng.NextDouble() < 0.25) { look.Outfit.Remove(slot); continue; }
                var p = Pick(choices);
                if (p != null) Equip(look, f, slot, p.Id);
            }
            look.Accessories = f.Accessories.Where(Ok).Where(_ => rng.NextDouble() < 0.35).Select(a => a.Id).ToList();
            var weapons = f.Weapons.Where(Ok).ToList();
            look.Weapon = weapons.Count > 0 && rng.NextDouble() < 0.8 ? Pick(weapons).Id : null;
            var pal = Pick(f.Palettes);
            if (pal != null) ApplyPalette(look, pal, f);
            var hair = Pick(f.HairColours);
            if (hair != null) SetColour(look, f, "hair_base", hair.Hex);
            var iris = Pick(f.IrisColours);
            if (iris != null) SetColour(look, f, "eye_iris", iris.Hex);
            return Normalize(look, f, allowPlanned);
        }

        /// <summary>A completely random colour for one slot (the "random colour" button), inside the style guard.</summary>
        public static string RandomColour(IRandom rng, StyleGuard g)
        {
            g = g ?? new StyleGuard();
            double h = rng.NextDouble() * 360, s = 0.25 + rng.NextDouble() * (g.MaxSaturation - 0.25), v = g.MinValue + 0.1 + rng.NextDouble() * (g.MaxValue - g.MinValue - 0.1);
            return ColourMath.FromHsv(h, s, v);
        }

        /// <summary>
        /// A look for a save made before customization existed: the family from the old body, the family default for everything
        /// new, and the old hair and outfit colour choices carried over into their slots.
        /// </summary>
        public static CustomLook FromLegacy(AppearanceChoice old, PlayerAppearanceFile legacy, CustomizationFile f)
        {
            var look = Default(f, FamilyOf(old?.Body ?? Body.Masculine));
            if (old == null || legacy == null || f == null) return look;
            var hair = legacy.HairColours.FirstOrDefault(c => c.Id == old.HairColour);
            if (hair != null) SetColour(look, f, "hair_base", hair.Hex);
            var outfit = legacy.OutfitColours.FirstOrDefault(c => c.Id == old.OutfitColour);
            if (outfit != null) SetColour(look, f, "cloth_primary", outfit.Hex);
            return Normalize(look, f);
        }

        /// <summary>The colour slot a material category takes on a given piece (the piece's override first, then the file's map).</summary>
        public static string SlotForMaterial(CustomizationFile f, OutfitPiece piece, string materialCategory)
        {
            if (piece?.Materials != null && piece.Materials.TryGetValue(materialCategory, out var s)) return s;
            return f != null && f.MaterialSlots.TryGetValue(materialCategory, out var d) ? d : null;
        }

        /// <summary>Which generator parts a look shows: body and face parts always, hair, then the equipped pieces' parts.</summary>
        public static HashSet<string> VisibleParts(CustomLook look, CustomizationFile f)
        {
            var parts = new HashSet<string> { "body", "eyes", "brows", "mouth", "ears", "hair" };
            foreach (var id in look?.Outfit?.Values ?? Enumerable.Empty<string>())
                foreach (var p in f?.Piece(id)?.Parts ?? new List<string>()) parts.Add(p);
            return parts;
        }

        /// <summary>True when every feature a face preset uses has a mesh (only then may a creator offer it without planned options).</summary>
        public static bool FaceBuilt(CustomizationFile f, FacePreset face)
        {
            if (f == null || face == null) return false;
            bool B(List<FaceFeature> l, string id) => l.Any(x => x.Id == id && x.Built);
            return B(f.EyeShapes, face.Eyes) && B(f.Brows, face.Brows) && B(f.Mouths, face.Mouth);
        }

        /// <summary>The options a creator row may offer for a family.</summary>
        public static List<T> Offered<T>(IEnumerable<T> list, string family, bool allowPlanned) where T : CatalogOption =>
            (list ?? Enumerable.Empty<T>()).Where(o => o.FitsFamily(family) && (allowPlanned || o.Built)).ToList();
    }

    // ------------------------------------------------------------------ expressions

    /// <summary>Data/Characters/face_expressions.json (made by Tools/blender/build_face_rig.py).</summary>
    public sealed class FaceExpressionFile
    {
        public string Schema { get; set; }
        public string RigContract { get; set; }
        public string Notes { get; set; }
        /// <summary>Expression id to shape key weights (0..1).</summary>
        public Dictionary<string, Dictionary<string, double>> Expressions { get; set; } = new Dictionary<string, Dictionary<string, double>>();
        public BlinkData Blink { get; set; } = new BlinkData();
        public TransitionData Transition { get; set; } = new TransitionData();
    }

    public sealed class BlinkData
    {
        public List<double> IntervalSec { get; set; } = new List<double> { 2, 5.5 };
        public double CloseSec { get; set; } = 0.06;
        public double HoldSec { get; set; } = 0.03;
        public double OpenSec { get; set; } = 0.09;
        public double DoubleBlinkChance { get; set; } = 0.12;
        public List<string> Keys { get; set; } = new List<string> { "eyes_close_L", "eyes_close_R" };
    }

    public sealed class TransitionData
    {
        public double DefaultBlendSec { get; set; } = 0.18;
        public string Notes { get; set; }
    }

    /// <summary>
    /// Runs a face: blends from one expression to the next with an ease-out over the data's blend time (0.08 s to or from
    /// blink and sleepy, as the data notes say) and lays an automatic blink over the top. Engine-free: the Unity side copies
    /// <see cref="Weights"/> to blend shapes (weight x 100). Deterministic for a given random source.
    /// </summary>
    public sealed class FaceExpressionPlayer
    {
        public const double FastBlendSec = 0.08;
        readonly FaceExpressionFile _data;
        readonly IRandom _rng;
        Dictionary<string, double> _from = new Dictionary<string, double>();
        Dictionary<string, double> _to = new Dictionary<string, double>();
        readonly Dictionary<string, double> _out = new Dictionary<string, double>();
        double _t, _blend;
        double _nextBlink, _blinkT = -1;
        bool _doubleQueued;

        public string Current { get; private set; } = "neutral";
        /// <summary>Automatic blinking (off while the face is closed-eyed: blink, sleepy, or an expression that closes the eyes).</summary>
        public bool AutoBlink { get; set; } = true;
        public IReadOnlyDictionary<string, double> Weights => _out;

        public FaceExpressionPlayer(FaceExpressionFile data, IRandom rng)
        {
            _data = data ?? new FaceExpressionFile();
            _rng = rng ?? new DeterministicRandom(1);
            _to = Scaled(Current, 1.0);
            _from = new Dictionary<string, double>(_to);
            _t = _blend = 0;
            _nextBlink = NextInterval();
            Compose(1.0, 0);
        }

        /// <summary>Starts a blend to an expression at an intensity (0..1). Unknown ids fall back to neutral.</summary>
        public void Set(string expression, double intensity = 1.0)
        {
            if (expression == null || !_data.Expressions.ContainsKey(expression)) expression = "neutral";
            double k = BlendProgress();
            var now = Mix(_from, _to, k);
            bool fast = IsClosedEye(expression) || IsClosedEye(Current);
            Current = expression;
            _from = now;
            _to = Scaled(expression, Math.Max(0, Math.Min(1, intensity)));
            _blend = fast ? FastBlendSec : Math.Max(0, _data.Transition?.DefaultBlendSec ?? 0.18);
            _t = 0;
        }

        /// <summary>Advances time and recomputes <see cref="Weights"/>.</summary>
        public void Tick(double dt)
        {
            if (dt < 0) dt = 0;
            _t += dt;
            double blink = 0;
            if (AutoBlink && !IsClosedEye(Current))
            {
                if (_blinkT < 0)
                {
                    _nextBlink -= dt;
                    if (_nextBlink <= 0) { _blinkT = 0; _doubleQueued = _rng.NextDouble() < (_data.Blink?.DoubleBlinkChance ?? 0); }
                }
                if (_blinkT >= 0)
                {
                    _blinkT += dt;
                    blink = BlinkCurve(_blinkT);
                    if (_blinkT >= BlinkLength())
                    {
                        _blinkT = -1;
                        _nextBlink = _doubleQueued ? 0.12 : NextInterval();
                        _doubleQueued = false;
                    }
                }
            }
            Compose(BlendProgress(), blink);
        }

        /// <summary>0..1 eyelid closure for a blink at time t since it began (close, hold, open).</summary>
        public double BlinkCurve(double t)
        {
            var b = _data.Blink ?? new BlinkData();
            if (t <= 0) return 0;
            if (t < b.CloseSec) return t / b.CloseSec;
            if (t < b.CloseSec + b.HoldSec) return 1;
            double o = t - b.CloseSec - b.HoldSec;
            return o < b.OpenSec ? 1 - o / b.OpenSec : 0;
        }

        double BlinkLength() { var b = _data.Blink ?? new BlinkData(); return b.CloseSec + b.HoldSec + b.OpenSec; }

        double NextInterval()
        {
            var iv = _data.Blink?.IntervalSec;
            double lo = iv != null && iv.Count > 0 ? iv[0] : 2, hi = iv != null && iv.Count > 1 ? iv[1] : lo;
            return lo + _rng.NextDouble() * Math.Max(0, hi - lo);
        }

        double BlendProgress()
        {
            if (_blend <= 1e-9) return 1;
            double x = Math.Min(1, _t / _blend);
            return 1 - (1 - x) * (1 - x); // ease-out
        }

        static bool IsClosedEye(string id) => id == "blink" || id == "sleepy";

        Dictionary<string, double> Scaled(string id, double k)
        {
            var d = new Dictionary<string, double>();
            if (_data.Expressions.TryGetValue(id, out var w) && w != null)
                foreach (var kv in w) d[kv.Key] = Math.Max(0, Math.Min(1, kv.Value * k));
            return d;
        }

        static Dictionary<string, double> Mix(Dictionary<string, double> a, Dictionary<string, double> b, double k)
        {
            var d = new Dictionary<string, double>();
            foreach (var key in a.Keys.Union(b.Keys))
            {
                a.TryGetValue(key, out var x); b.TryGetValue(key, out var y);
                double v = x + (y - x) * k;
                if (v > 1e-6) d[key] = v;
            }
            return d;
        }

        void Compose(double k, double blink)
        {
            _out.Clear();
            foreach (var kv in Mix(_from, _to, k)) _out[kv.Key] = kv.Value;
            if (blink > 0)
                foreach (var key in _data.Blink?.Keys ?? new List<string>())
                {
                    _out.TryGetValue(key, out var v);
                    _out[key] = Math.Max(v, blink);
                }
        }
    }
}
