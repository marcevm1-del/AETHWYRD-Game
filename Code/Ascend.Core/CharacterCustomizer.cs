using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Ascend.Core
{
    /// <summary>
    /// The customization screen without any drawing: categories of rows, each row a label, a value, an optional swatch and a
    /// left/right action. The Unity panel (Game/Assets/_Game/Runtime/UI/FrontEnd/CharacterCustomizerPanel.cs) only renders
    /// <see cref="Rows"/> and forwards input, so every rule here is tested in Core. Every change ends in
    /// <see cref="CustomizationRules.Normalize"/>, so the look can never hold an invalid id or colour.
    /// </summary>
    public sealed class CustomizerModel
    {
        public enum Category { Face, Hair, Body, Outfit, Gear, Colours, Presets }
        public static readonly Category[] Categories = (Category[])Enum.GetValues(typeof(Category));
        public static readonly string[] OutfitSlots = { "top", "outer", "bottom", "skirt", "belt", "footwear", "gloves", "arms", "shoulder", "neck", "armor" };
        public enum ColourMode { Rgb, Hsv }
        public const double ChannelStep = 1.0 / 32.0;
        public const double HueStep = 10.0;
        public const double HeightStep = 0.01;

        public sealed class Row
        {
            public string Id;
            public string Label;
            public Func<string> Value;
            /// <summary>#RRGGBB to draw beside the value, or null.</summary>
            public Func<string> Swatch;
            /// <summary>Left (-1) or right (+1).</summary>
            public Action<int> Cycle;
            /// <summary>Confirm (Enter, A, a click on the value). Null: confirm cycles right.</summary>
            public Action Activate;
            public bool IsButton;
        }

        public CustomizationFile Data { get; }
        public CustomLook Look { get; private set; }
        public Category Current { get; private set; } = Category.Face;
        /// <summary>Show designed options that have no mesh yet (marked "planned"). Off for players; a tool for designers.</summary>
        public bool ShowPlanned { get; private set; }
        public string ColourSlot { get; private set; }
        public ColourMode Mode { get; private set; } = ColourMode.Hsv;
        public CharacterPresetBook Book { get; }
        /// <summary>Bumped on every change; the preview redraws when it moves.</summary>
        public int Version { get; private set; }
        /// <summary>A short line for the panel's status bar (what the last action did).</summary>
        public string Status { get; private set; } = "";
        readonly IRandom _rng;
        int _bookCursor;

        public CustomizerModel(CustomizationFile data, CustomLook start, IRandom rng, CharacterPresetBook book = null)
        {
            Data = data ?? new CustomizationFile();
            _rng = rng ?? new DeterministicRandom(1);
            Book = book ?? new CharacterPresetBook();
            Look = CustomizationRules.Normalize(start ?? CustomizationRules.Default(Data, "masculine"), Data);
            ColourSlot = Data.ColourSlots.FirstOrDefault()?.Id;
        }

        // ------------------------------------------------------------------ navigation and global actions

        public void SelectCategory(Category c) { Current = c; Touch(""); }
        public void StepCategory(int dir)
        {
            int i = Array.IndexOf(Categories, Current);
            Current = Categories[((i + Math.Sign(dir == 0 ? 1 : dir)) % Categories.Length + Categories.Length) % Categories.Length];
            Touch("");
        }

        public void SetFamily(string family)
        {
            if (Data.Family(family) == null || family == Look.Family) return;
            Commit(CustomizationRules.SwitchFamily(Look, Data, family), "Body changed: face, hair and outfit reset to that body's defaults; colours kept.");
        }

        public void SetShowPlanned(bool on) { ShowPlanned = on; Commit(Look, on ? "Showing planned options (not modelled yet)." : "Showing built options only."); }

        public void Randomize() => Commit(CustomizationRules.Randomize(Data, Look.Family, _rng, ShowPlanned), "Randomised.");
        public void Reset() => Commit(CustomizationRules.Reset(Data, Look), "Reset to the default look.");

        /// <summary>Replaces the look from outside (the creator's body or colour rows); keeps the screen state.</summary>
        public void Replace(CustomLook look) => Commit(look ?? Look, "");

        // ------------------------------------------------------------------ rows

        public IReadOnlyList<Row> Rows => Build(Current);

        public IReadOnlyList<Row> Build(Category c)
        {
            var rows = new List<Row>();
            switch (c)
            {
                case Category.Face:
                    rows.Add(Cycler("face", "Face", () => Data.Faces.Where(f => f.FitsFamily(Look.Family) && (ShowPlanned || CustomizationRules.FaceBuilt(Data, f))).Select(f => f.Id).ToList(),
                        () => Look.FacePreset, id => { var x = Look.Clone(); CustomizationRules.ApplyFace(x, Data.Face(id)); return x; }, id => Name(Data.Faces.FirstOrDefault(f => f.Id == id)?.Name, CustomizationRules.FaceBuilt(Data, Data.Face(id)))));
                    rows.Add(OptionRow("eyes", "Eyes", Data.EyeShapes, () => Look.EyeShape, (x, id) => x.EyeShape = id));
                    rows.Add(OptionRow("pupils", "Pupils", Data.PupilStyles, () => Look.PupilStyle, (x, id) => x.PupilStyle = id));
                    rows.Add(OptionRow("brows", "Eyebrows", Data.Brows, () => Look.Brows, (x, id) => x.Brows = id));
                    rows.Add(OptionRow("mouth", "Mouth", Data.Mouths, () => Look.Mouth, (x, id) => x.Mouth = id));
                    rows.Add(Cycler("expression", "Expression", () => Data.Expressions.Select(e => e.Id).ToList(), () => Look.Expression, id => { var x = Look.Clone(); x.Expression = id; return x; },
                        id => Data.Expressions.FirstOrDefault(e => e.Id == id)?.Name ?? id));
                    rows.Add(SwatchRow("eye_colour", "Eye colour", Data.IrisColours, "eye_iris"));
                    break;
                case Category.Hair:
                    rows.Add(OptionRow("hair", "Hair style", Data.HairStyles, () => Look.HairStyle, (x, id) => x.HairStyle = id));
                    rows.Add(SwatchRow("hair_colour", "Hair colour", Data.HairColours, "hair_base"));
                    rows.Add(SwatchRow("hair_highlight", "Highlights", Data.HairColours, "hair_highlight"));
                    rows.Add(SwatchRow("hair_tip", "Tips", Data.HairColours, "hair_tip"));
                    break;
                case Category.Body:
                    rows.Add(Cycler("family", "Body", () => Data.Families.Select(f => f.Id).ToList(), () => Look.Family, id => null, id => Data.Family(id)?.Name ?? id, id => SetFamily(id)));
                    rows.Add(Cycler("build", "Build", () => Data.Family(Look.Family)?.Builds ?? new List<string>(), () => Look.Build, id => { var x = Look.Clone(); x.Build = id; return x; }, Title));
                    rows.Add(new Row
                    {
                        Id = "height", Label = "Height", Value = () => Look.HeightM.ToString("0.00", CultureInfo.InvariantCulture) + " m",
                        Cycle = d => { var x = Look.Clone(); x.HeightM = Math.Round(x.HeightM + d * HeightStep, 2); Commit(x, ""); },
                    });
                    break;
                case Category.Outfit:
                    foreach (var slot in OutfitSlots)
                    {
                        var s = slot;
                        if (!Data.OutfitPieces.Any(p => p.Slot == s && p.FitsFamily(Look.Family) && (ShowPlanned || p.Built))) continue;
                        rows.Add(Cycler("outfit_" + s, Title(s), () => new[] { "" }.Concat(CustomizationRules.Offered(Data.OutfitPieces.Where(p => p.Slot == s), Look.Family, ShowPlanned).Select(p => p.Id)).ToList(),
                            () => Look.Outfit.TryGetValue(s, out var v) ? v : "",
                            id => { var x = Look.Clone(); CustomizationRules.Equip(x, Data, s, id == "" ? null : id); return x; },
                            id => id == "" ? "None" : Name(Data.Piece(id)?.Name, Data.Piece(id)?.Built ?? false)));
                    }
                    break;
                case Category.Gear:
                    rows.Add(Cycler("weapon", "Weapon", () => new[] { "" }.Concat(CustomizationRules.Offered(Data.Weapons, Look.Family, ShowPlanned).Select(w => w.Id)).ToList(),
                        () => Look.Weapon ?? "", id => { var x = Look.Clone(); x.Weapon = id == "" ? null : id; return x; },
                        id => id == "" ? "None" : Name(Data.Weapons.FirstOrDefault(w => w.Id == id)?.Name, Data.Weapons.FirstOrDefault(w => w.Id == id)?.Built ?? false)));
                    foreach (var a in CustomizationRules.Offered(Data.Accessories, Look.Family, ShowPlanned))
                    {
                        var acc = a;
                        rows.Add(new Row
                        {
                            Id = "acc_" + acc.Id, Label = acc.Name, Value = () => Look.Accessories.Contains(acc.Id) ? "On" : "Off",
                            Cycle = _ => ToggleAccessory(acc.Id),
                        });
                    }
                    if (rows.Count == 1 && !ShowPlanned) rows.Add(new Row { Id = "gear_none", Label = "Accessories", Value = () => "None modelled yet" });
                    break;
                case Category.Colours:
                    rows.Add(Cycler("palette", "Palette", () => Data.Palettes.Select(p => p.Id).ToList(), () => Look.Palette ?? "", id => { var x = Look.Clone(); CustomizationRules.ApplyPalette(x, Data.Palette(id), Data); return x; },
                        id => Data.Palette(id)?.Name ?? "Custom"));
                    rows.Add(Cycler("slot", "Part", () => Data.ColourSlots.Select(s => s.Id).ToList(), () => ColourSlot, id => null, id => Data.ColourSlots.FirstOrDefault(s => s.Id == id)?.Name ?? id,
                        id => { ColourSlot = id; Touch(""); }, () => SlotHex()));
                    rows.Add(new Row { Id = "mode", Label = "Picker", Value = () => Mode == ColourMode.Rgb ? "RGB" : "HSV", Cycle = _ => { Mode = Mode == ColourMode.Rgb ? ColourMode.Hsv : ColourMode.Rgb; Touch(""); } });
                    if (Mode == ColourMode.Rgb)
                        foreach (int ch in new[] { 0, 1, 2 }) rows.Add(Channel(ch));
                    else
                        foreach (int ch in new[] { 3, 4, 5 }) rows.Add(Channel(ch));
                    rows.Add(new Row { Id = "random_colour", Label = "Random colour", Value = () => "", IsButton = true, Activate = RandomSlotColour, Cycle = _ => RandomSlotColour() });
                    rows.Add(new Row
                    {
                        Id = "guard", Label = "Keep to the art style", Value = () => Look.StyleGuard ? "On" : "Off",
                        Cycle = _ => { var x = Look.Clone(); x.StyleGuard = !x.StyleGuard; Commit(x, x.StyleGuard ? "Colours are kept inside the art style's range." : "Any colour allowed."); },
                    });
                    break;
                case Category.Presets:
                    rows.Add(new Row { Id = "randomize", Label = "Randomise", Value = () => "", IsButton = true, Activate = Randomize, Cycle = _ => Randomize() });
                    rows.Add(new Row { Id = "reset", Label = "Reset", Value = () => "", IsButton = true, Activate = Reset, Cycle = _ => Reset() });
                    rows.Add(new Row
                    {
                        Id = "book", Label = "Saved looks", Value = () => Book.Entries.Count == 0 ? "None yet" : $"{Book.Entries[Cursor()].Name} ({Cursor() + 1}/{Book.Entries.Count})",
                        Cycle = d => { if (Book.Entries.Count > 0) { _bookCursor = (Cursor() + d + Book.Entries.Count) % Book.Entries.Count; Touch(""); } },
                    });
                    rows.Add(new Row { Id = "save_look", Label = "Save this look", Value = () => "", IsButton = true, Activate = SaveToBook, Cycle = _ => SaveToBook() });
                    rows.Add(new Row { Id = "load_look", Label = "Load the saved look", Value = () => "", IsButton = true, Activate = LoadFromBook, Cycle = _ => LoadFromBook() });
                    foreach (var p in Data.Looks.Where(l => l.Family == Look.Family && (ShowPlanned || l.Status == "built")))
                    {
                        var preset = p;
                        rows.Add(new Row { Id = "preset_" + p.Id, Label = "Preset", Value = () => Name(preset.Name, preset.Status == "built"), IsButton = true,
                            Activate = () => Commit(CustomizationRules.FromPreset(preset, Data), "Preset applied: " + preset.Name), Cycle = _ => Commit(CustomizationRules.FromPreset(preset, Data), "Preset applied: " + preset.Name) });
                    }
                    rows.Add(new Row { Id = "planned", Label = "Show planned options", Value = () => ShowPlanned ? "On" : "Off", Cycle = _ => SetShowPlanned(!ShowPlanned) });
                    break;
            }
            return rows;
        }

        // ------------------------------------------------------------------ colour editing

        public string SlotHex() => ColourSlot != null && Look.Colours.TryGetValue(ColourSlot, out var h) ? h : "#808080";

        /// <summary>The value of a channel of the selected slot: 0 R, 1 G, 2 B (0..1), 3 H (degrees), 4 S, 5 V (0..1).</summary>
        public double ChannelValue(int ch)
        {
            ColourMath.TryParseHex(SlotHex(), out var c);
            var h = ColourMath.ToHsv(c);
            switch (ch) { case 0: return c.R; case 1: return c.G; case 2: return c.B; case 3: return h.H; case 4: return h.S; default: return h.V; }
        }

        /// <summary>Sets a channel of the selected slot to an absolute value (a slider) and stores the result.</summary>
        public void SetChannel(int ch, double value)
        {
            if (ColourSlot == null) return;
            ColourMath.TryParseHex(SlotHex(), out var c);
            string hex;
            if (ch <= 2)
            {
                value = Math.Max(0, Math.Min(1, value));
                if (ch == 0) c.R = value; else if (ch == 1) c.G = value; else c.B = value;
                hex = ColourMath.ToHex(c);
            }
            else
            {
                var h = ColourMath.ToHsv(c);
                if (ch == 3) h.H = ((value % 360) + 360) % 360; else if (ch == 4) h.S = Math.Max(0, Math.Min(1, value)); else h.V = Math.Max(0, Math.Min(1, value));
                hex = ColourMath.ToHex(ColourMath.ToRgb(h));
            }
            var x = Look.Clone();
            CustomizationRules.SetColour(x, Data, ColourSlot, hex);
            x.Palette = null;
            Commit(x, "");
        }

        public void StepChannel(int ch, int dir) => SetChannel(ch, ChannelValue(ch) + dir * (ch == 3 ? HueStep : ChannelStep));

        public void RandomSlotColour()
        {
            if (ColourSlot == null) return;
            var x = Look.Clone();
            CustomizationRules.SetColour(x, Data, ColourSlot, CustomizationRules.RandomColour(_rng, Data.StyleGuard));
            x.Palette = null;
            Commit(x, "Random colour for " + (Data.ColourSlots.FirstOrDefault(s => s.Id == ColourSlot)?.Name ?? ColourSlot) + ".");
        }

        Row Channel(int ch)
        {
            string[] names = { "Red", "Green", "Blue", "Hue", "Saturation", "Value" };
            return new Row
            {
                Id = "ch" + ch, Label = names[ch],
                Value = () => ch == 3 ? ((int)Math.Round(ChannelValue(ch))).ToString(CultureInfo.InvariantCulture) + "°" : ((int)Math.Round(ChannelValue(ch) * 100)).ToString(CultureInfo.InvariantCulture) + "%",
                Cycle = d => StepChannel(ch, d),
            };
        }

        // ------------------------------------------------------------------ presets on disk (the Unity side reads and writes the book)

        int Cursor() => Book.Entries.Count == 0 ? 0 : Math.Max(0, Math.Min(_bookCursor, Book.Entries.Count - 1));

        public void SaveToBook()
        {
            string name = Data.Family(Look.Family)?.Name + " look " + (Book.Entries.Count + 1);
            _bookCursor = Book.Put(name, Look);
            Touch(Book.Entries.Count >= CharacterPresetBook.Capacity ? $"Saved (the book holds {CharacterPresetBook.Capacity}; the oldest is replaced next)." : "Saved as \"" + name + "\".");
        }

        public void LoadFromBook()
        {
            if (Book.Entries.Count == 0) { Touch("No saved looks yet."); return; }
            var e = Book.Entries[Cursor()];
            Commit(e.Look, "Loaded \"" + e.Name + "\".");
        }

        // ------------------------------------------------------------------ helpers

        void ToggleAccessory(string id)
        {
            var x = Look.Clone();
            if (!x.Accessories.Remove(id)) x.Accessories.Add(id);
            Commit(x, "");
        }

        Row OptionRow<T>(string id, string label, List<T> list, Func<string> get, Action<CustomLook, string> set) where T : CatalogOption =>
            Cycler(id, label, () => CustomizationRules.Offered(list, Look.Family, ShowPlanned).Select(o => o.Id).ToList(), get,
                v => { var x = Look.Clone(); set(x, v); return x; }, v => Name(list.FirstOrDefault(o => o.Id == v)?.Name, list.FirstOrDefault(o => o.Id == v)?.Built ?? false));

        Row SwatchRow(string id, string label, List<AppearanceColour> swatches, string slot) => new Row
        {
            Id = id, Label = label,
            Value = () => swatches.FirstOrDefault(s => Same(s.Hex, Look.Colours.TryGetValue(slot, out var h) ? h : null))?.Name ?? "Custom",
            Swatch = () => Look.Colours.TryGetValue(slot, out var h) ? h : null,
            Cycle = d =>
            {
                if (swatches.Count == 0) return;
                string cur = Look.Colours.TryGetValue(slot, out var h) ? h : null;
                int i = swatches.FindIndex(s => Same(s.Hex, cur));
                int n = i < 0 ? (d > 0 ? 0 : swatches.Count - 1) : ((i + d) % swatches.Count + swatches.Count) % swatches.Count;
                var x = Look.Clone();
                CustomizationRules.SetColour(x, Data, slot, swatches[n].Hex);
                x.Palette = null;
                Commit(x, "");
            },
        };

        Row Cycler(string id, string label, Func<List<string>> ids, Func<string> get, Func<string, CustomLook> make, Func<string, string> show, Action<string> instead = null, Func<string> swatch = null) => new Row
        {
            Id = id, Label = label, Value = () => show(get() ?? ""), Swatch = swatch,
            Cycle = d =>
            {
                var list = ids();
                if (list.Count == 0) return;
                string next = AppearanceRules.Step(list, get() ?? "", d);
                if (instead != null) { instead(next); return; }
                var x = make(next);
                if (x != null) Commit(x, "");
            },
        };

        static bool Same(string a, string b) => a != null && b != null && string.Equals(a, b, StringComparison.OrdinalIgnoreCase);
        static string Name(string n, bool built) => (n ?? "?") + (built ? "" : " (planned)");
        static string Title(string s) => string.IsNullOrEmpty(s) ? s : char.ToUpperInvariant(s[0]) + s.Substring(1);

        void Commit(CustomLook next, string status)
        {
            Look = CustomizationRules.Normalize(next, Data, ShowPlanned);
            Touch(status);
        }

        void Touch(string status) { Version++; if (status != null) Status = status; }
    }

    /// <summary>The player's saved looks (a small local book beside the save, never inside it). Newest last; capacity 8.</summary>
    public sealed class CharacterPresetBook
    {
        public const int Capacity = 8;
        public int Version { get; set; } = 1;
        public List<CharacterPresetEntry> Entries { get; set; } = new List<CharacterPresetEntry>();

        /// <summary>Adds a copy of a look (the oldest goes when full) and returns its index.</summary>
        public int Put(string name, CustomLook look)
        {
            Entries = Entries ?? new List<CharacterPresetEntry>();
            if (Entries.Count >= Capacity) Entries.RemoveAt(0);
            Entries.Add(new CharacterPresetEntry { Name = string.IsNullOrWhiteSpace(name) ? "Look" : name.Trim(), Look = look?.Clone() ?? new CustomLook() });
            return Entries.Count - 1;
        }

        /// <summary>Drops entries without a look and normalises the rest against the data (a removed option never breaks a load).</summary>
        public void Repair(CustomizationFile f)
        {
            Entries = (Entries ?? new List<CharacterPresetEntry>()).Where(e => e?.Look != null).Take(Capacity).ToList();
            foreach (var e in Entries) e.Look = CustomizationRules.Normalize(e.Look, f);
        }
    }

    public sealed class CharacterPresetEntry
    {
        public string Name { get; set; }
        public CustomLook Look { get; set; }
    }
}
