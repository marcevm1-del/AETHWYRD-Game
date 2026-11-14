using System;
using System.Collections.Generic;
using System.Linq;

namespace Ascend.Core
{
    // Phase 1B character creator data (06_Races_Origins/races_and_origins.md section 3.1 step 2 "How you look", Canon: male and female
    // player characters, no gender locks). Data: Data/Characters/player_appearance.json. The save stores option ids, never colours,
    // so a recoloured palette in the data re-tints old saves. Unknown ids fall back to the data default.

    /// <summary>The two player bodies (Canon section 4). A body prefab per value can replace the placeholder later.</summary>
    public enum Body { Masculine, Feminine }

    public sealed class AppearanceOption
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public sealed class AppearanceColour
    {
        public string Id { get; set; }
        public string Name { get; set; }
        /// <summary>#RRGGBB.</summary>
        public string Hex { get; set; }
    }

    public sealed class BodyOption
    {
        /// <summary>The Body enum name in lower case ("masculine", "feminine").</summary>
        public string Id { get; set; }
        public string Name { get; set; }
        /// <summary>Placeholder rig proportions (1 = the original rig). Height is never scaled, so foot IK stays correct.</summary>
        public double TorsoWidth { get; set; } = 1.0;
        public double HipWidth { get; set; } = 1.0;
    }

    public sealed class AppearanceDefaults
    {
        public const string Name = "Traveller";
        public const string HairStyle = "short";
        public const string HairColour = "chestnut";
        public const string SkinTone = "fair";
        public const string OutfitColour = "azure";
        public const int MaxNameLength = 20;
    }

    /// <summary>Data/Characters/player_appearance.json.</summary>
    public sealed class PlayerAppearanceFile
    {
        public int Version { get; set; } = 1;
        public string Notes { get; set; }
        public int MaxNameLength { get; set; } = AppearanceDefaults.MaxNameLength;
        public string DefaultName { get; set; } = AppearanceDefaults.Name;
        public List<string> SuggestedNames { get; set; } = new List<string>();
        /// <summary>One line on the creator's race and origin row (both are chosen later, in the prologues; nothing is stored).</summary>
        public string RaceOriginNote { get; set; }
        public List<BodyOption> Bodies { get; set; } = new List<BodyOption>();
        public List<AppearanceOption> HairStyles { get; set; } = new List<AppearanceOption>();
        public List<AppearanceColour> HairColours { get; set; } = new List<AppearanceColour>();
        public List<AppearanceColour> SkinTones { get; set; } = new List<AppearanceColour>();
        public List<AppearanceColour> OutfitColours { get; set; } = new List<AppearanceColour>();
    }

    /// <summary>One look: what the creator edits and what the save keeps.</summary>
    public sealed class AppearanceChoice
    {
        public string PlayerName { get; set; } = AppearanceDefaults.Name;
        public Body Body { get; set; } = Body.Masculine;
        public string HairStyle { get; set; } = AppearanceDefaults.HairStyle;
        public string HairColour { get; set; } = AppearanceDefaults.HairColour;
        public string SkinTone { get; set; } = AppearanceDefaults.SkinTone;
        public string OutfitColour { get; set; } = AppearanceDefaults.OutfitColour;

        public AppearanceChoice Clone() => (AppearanceChoice)MemberwiseClone();
    }

    public static class AppearanceRules
    {
        public static AppearanceChoice Default(PlayerAppearanceFile f)
        {
            var c = new AppearanceChoice();
            return Normalize(c, f);
        }

        /// <summary>Clamps a choice into the data: trims and limits the name, replaces unknown ids with the first listed option or the default.</summary>
        public static AppearanceChoice Normalize(AppearanceChoice c, PlayerAppearanceFile f)
        {
            c = c ?? new AppearanceChoice();
            int max = f != null && f.MaxNameLength > 0 ? f.MaxNameLength : AppearanceDefaults.MaxNameLength;
            c.PlayerName = CleanName(c.PlayerName, max, f != null && !string.IsNullOrWhiteSpace(f.DefaultName) ? f.DefaultName : AppearanceDefaults.Name);
            if (!Enum.IsDefined(typeof(Body), c.Body)) c.Body = Body.Masculine;
            if (f == null) return c;
            c.HairStyle = Pick(f.HairStyles.Select(x => x.Id), c.HairStyle, AppearanceDefaults.HairStyle);
            c.HairColour = Pick(f.HairColours.Select(x => x.Id), c.HairColour, AppearanceDefaults.HairColour);
            c.SkinTone = Pick(f.SkinTones.Select(x => x.Id), c.SkinTone, AppearanceDefaults.SkinTone);
            c.OutfitColour = Pick(f.OutfitColours.Select(x => x.Id), c.OutfitColour, AppearanceDefaults.OutfitColour);
            return c;
        }

        static string Pick(IEnumerable<string> ids, string id, string preferredDefault)
        {
            var list = ids.ToList();
            if (list.Count == 0) return id ?? preferredDefault;
            if (id != null && list.Contains(id)) return id;
            return list.Contains(preferredDefault) ? preferredDefault : list[0];
        }

        /// <summary>Trims, drops control characters and cuts to the limit; blank names become the fallback.</summary>
        public static string CleanName(string name, int max, string fallback)
        {
            var chars = (name ?? "").Where(ch => !char.IsControl(ch)).ToArray();
            string s = new string(chars).Trim();
            if (s.Length > max) s = s.Substring(0, max).TrimEnd();
            return s.Length == 0 ? fallback : s;
        }

        /// <summary>The id <paramref name="dir"/> steps away in a list (wraps). An unknown id counts as the first.</summary>
        public static string Step(IReadOnlyList<string> ids, string current, int dir)
        {
            if (ids == null || ids.Count == 0) return current;
            int i = 0;
            for (int k = 0; k < ids.Count; k++) if (ids[k] == current) { i = k; break; }
            return ids[((i + (dir < 0 ? -1 : 1)) % ids.Count + ids.Count) % ids.Count];
        }

        public static Body StepBody(Body b, int dir)
        {
            var all = (Body[])Enum.GetValues(typeof(Body));
            int i = Array.IndexOf(all, b);
            return all[((i + (dir < 0 ? -1 : 1)) % all.Length + all.Length) % all.Length];
        }

        /// <summary>Parses #RRGGBB into 0..1 channels; false when malformed.</summary>
        public static bool TryParseHex(string hex, out float r, out float g, out float b)
        {
            r = g = b = 0f;
            if (string.IsNullOrEmpty(hex) || hex.Length != 7 || hex[0] != '#') return false;
            if (!int.TryParse(hex.Substring(1), System.Globalization.NumberStyles.HexNumber, System.Globalization.CultureInfo.InvariantCulture, out int v)) return false;
            r = ((v >> 16) & 255) / 255f; g = ((v >> 8) & 255) / 255f; b = (v & 255) / 255f;
            return true;
        }

        public static BodyOption BodyOf(PlayerAppearanceFile f, Body body) =>
            f?.Bodies.FirstOrDefault(x => string.Equals(x.Id, body.ToString(), StringComparison.OrdinalIgnoreCase)) ?? new BodyOption { Id = body.ToString().ToLowerInvariant() };

        /// <summary>Copies a look into a save.</summary>
        public static void WriteTo(SaveGame s, AppearanceChoice c)
        {
            s.PlayerName = c.PlayerName; s.PlayerBody = c.Body; s.HairStyle = c.HairStyle;
            s.HairColour = c.HairColour; s.SkinTone = c.SkinTone; s.OutfitColour = c.OutfitColour;
        }

        /// <summary>Reads a look from a save (a normalised copy).</summary>
        public static AppearanceChoice ReadFrom(SaveGame s, PlayerAppearanceFile f)
        {
            return Normalize(new AppearanceChoice
            {
                PlayerName = s.PlayerName, Body = s.PlayerBody, HairStyle = s.HairStyle,
                HairColour = s.HairColour, SkinTone = s.SkinTone, OutfitColour = s.OutfitColour,
            }, f);
        }
    }

    /// <summary>Data/UI/loading_tips.json.</summary>
    public sealed class LoadingTip
    {
        public string Id { get; set; }
        public string Text { get; set; }
    }

    public sealed class LoadingTipsFile
    {
        public int Version { get; set; } = 1;
        public string Notes { get; set; }
        public List<LoadingTip> Tips { get; set; } = new List<LoadingTip>();

        /// <summary>A tip for a seed (stable for a given seed); null when there are none.</summary>
        public LoadingTip Pick(int seed)
        {
            var list = Tips.Where(t => t != null && !string.IsNullOrWhiteSpace(t.Text)).ToList();
            if (list.Count == 0) return null;
            return list[((seed % list.Count) + list.Count) % list.Count];
        }
    }
}
