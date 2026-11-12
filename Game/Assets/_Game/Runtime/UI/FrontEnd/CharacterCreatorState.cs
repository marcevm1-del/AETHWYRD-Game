using System.Collections.Generic;
using System.Linq;
using Ascend.Core;
using UnityEngine;

namespace Ascend.Game
{
    /// <summary>
    /// The character creator's state, without any drawing (06_Races_Origins/races_and_origins.md section 3.1 step 2; the
    /// controller draws it). Every option comes from Data/Characters/player_appearance.json and every change goes through
    /// <see cref="AppearanceRules"/>, so a look can never hold an unknown id or an over-long name.
    /// Rows: Name, Body, Hair style, Hair colour, Skin tone, Outfit colour, a read-only Race and origin note, Begin, Back.
    /// </summary>
    public sealed class CharacterCreatorState
    {
        public enum Field { Name, Body, HairStyle, HairColour, SkinTone, OutfitColour, RaceOrigin, Begin, Back }

        public static readonly Field[] Order = { Field.Name, Field.Body, Field.HairStyle, Field.HairColour, Field.SkinTone, Field.OutfitColour, Field.RaceOrigin, Field.Begin, Field.Back };

        public PlayerAppearanceFile Data { get; }
        public AppearanceChoice Look { get; private set; }
        int _suggest = -1;

        public CharacterCreatorState(PlayerAppearanceFile data, AppearanceChoice start = null)
        {
            Data = data ?? new PlayerAppearanceFile();
            Look = AppearanceRules.Normalize(start != null ? start.Clone() : new AppearanceChoice(), Data);
        }

        public static bool Selectable(Field f) => f != Field.RaceOrigin;

        public int MaxNameLength => Data.MaxNameLength > 0 ? Data.MaxNameLength : AppearanceDefaults.MaxNameLength;

        public void SetName(string name)
        {
            // While typing, keep what was typed (trimmed to the limit); the blank fallback applies when the look is finished.
            var chars = (name ?? "").Where(ch => !char.IsControl(ch)).ToArray();
            string s = new string(chars);
            if (s.Length > MaxNameLength) s = s.Substring(0, MaxNameLength);
            Look.PlayerName = s;
        }

        /// <summary>Trims the name and replaces a blank one with the default.</summary>
        public void FinishName() => Look.PlayerName = AppearanceRules.CleanName(Look.PlayerName, MaxNameLength, string.IsNullOrWhiteSpace(Data.DefaultName) ? AppearanceDefaults.Name : Data.DefaultName);

        /// <summary>Next name from the data's suggestions (for a pad, which cannot type).</summary>
        public void NextSuggestedName()
        {
            if (Data.SuggestedNames == null || Data.SuggestedNames.Count == 0) return;
            _suggest = (_suggest + 1) % Data.SuggestedNames.Count;
            Look.PlayerName = AppearanceRules.CleanName(Data.SuggestedNames[_suggest], MaxNameLength, Look.PlayerName);
        }

        /// <summary>Left or right on a row. Name and the read-only rows do nothing.</summary>
        public void Cycle(Field f, int dir)
        {
            switch (f)
            {
                case Field.Body: Look.Body = AppearanceRules.StepBody(Look.Body, dir); break;
                case Field.HairStyle: Look.HairStyle = AppearanceRules.Step(Data.HairStyles.Select(x => x.Id).ToList(), Look.HairStyle, dir); break;
                case Field.HairColour: Look.HairColour = AppearanceRules.Step(Data.HairColours.Select(x => x.Id).ToList(), Look.HairColour, dir); break;
                case Field.SkinTone: Look.SkinTone = AppearanceRules.Step(Data.SkinTones.Select(x => x.Id).ToList(), Look.SkinTone, dir); break;
                case Field.OutfitColour: Look.OutfitColour = AppearanceRules.Step(Data.OutfitColours.Select(x => x.Id).ToList(), Look.OutfitColour, dir); break;
            }
            Look = AppearanceRules.Normalize(Look, Data);
        }

        /// <summary>The look to start the game with (name finished, ids clamped).</summary>
        public AppearanceChoice Finish()
        {
            FinishName();
            return AppearanceRules.Normalize(Look.Clone(), Data);
        }

        // ------------------------------------------------------------------ what a row shows

        public string ValueText(Field f)
        {
            switch (f)
            {
                case Field.Name: return Look.PlayerName;
                case Field.Body: return AppearanceRules.BodyOf(Data, Look.Body).Name ?? Look.Body.ToString();
                case Field.HairStyle: return Data.HairStyles.FirstOrDefault(x => x.Id == Look.HairStyle)?.Name ?? Look.HairStyle;
                case Field.HairColour: return Data.HairColours.FirstOrDefault(x => x.Id == Look.HairColour)?.Name ?? Look.HairColour;
                case Field.SkinTone: return Data.SkinTones.FirstOrDefault(x => x.Id == Look.SkinTone)?.Name ?? Look.SkinTone;
                case Field.OutfitColour: return Data.OutfitColours.FirstOrDefault(x => x.Id == Look.OutfitColour)?.Name ?? Look.OutfitColour;
                default: return "";
            }
        }

        public static string Label(Field f)
        {
            switch (f)
            {
                case Field.Name: return "Name";
                case Field.Body: return "Body";
                case Field.HairStyle: return "Hair style";
                case Field.HairColour: return "Hair colour";
                case Field.SkinTone: return "Skin tone";
                case Field.OutfitColour: return "Outfit colour";
                case Field.RaceOrigin: return "Race and origin";
                case Field.Begin: return "Begin your journey";
                default: return "Back";
            }
        }

        /// <summary>The swatch colour of a colour row (null for rows without one), straight from the data.</summary>
        public Color? Swatch(Field f)
        {
            AppearanceColour c = null;
            switch (f)
            {
                case Field.HairColour: c = Data.HairColours.FirstOrDefault(x => x.Id == Look.HairColour); break;
                case Field.SkinTone: c = Data.SkinTones.FirstOrDefault(x => x.Id == Look.SkinTone); break;
                case Field.OutfitColour: c = Data.OutfitColours.FirstOrDefault(x => x.Id == Look.OutfitColour); break;
            }
            return c != null ? PlaceholderPlayerBody.ToColour(c, Color.white) : (Color?)null;
        }

        public IReadOnlyList<AppearanceColour> OptionsFor(Field f)
        {
            switch (f)
            {
                case Field.HairColour: return Data.HairColours;
                case Field.SkinTone: return Data.SkinTones;
                case Field.OutfitColour: return Data.OutfitColours;
                default: return null;
            }
        }
    }

    /// <summary>The main menu's entries. Continue only exists when a valid save is on disk.</summary>
    public static class FrontEndMenu
    {
        public enum Entry { Continue, NewGame, Settings, Quit }

        public static List<Entry> Entries(bool hasSave)
        {
            var list = new List<Entry>();
            if (hasSave) list.Add(Entry.Continue);
            list.Add(Entry.NewGame);
            list.Add(Entry.Settings);
            list.Add(Entry.Quit);
            return list;
        }

        public static string Label(Entry e)
        {
            switch (e)
            {
                case Entry.Continue: return "Continue";
                case Entry.NewGame: return "New Game";
                case Entry.Settings: return "Settings";
                default: return "Quit";
            }
        }
    }
}
