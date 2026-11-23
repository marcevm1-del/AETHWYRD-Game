using System;
using System.IO;
using Ascend.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using UnityEngine;

namespace Ascend.Game
{
    /// <summary>
    /// What the title screen hands to the field scene, plus the capture flags of the built player.
    /// New Game: <see cref="Begin"/> stores the creator's look; the field's <see cref="PlayerAppearance"/> picks it up and
    /// <see cref="PlayerSave"/> skips loading the old slot. Continue: nothing pending, the save loads as always.
    /// Command line (all optional): <c>-ascendFront title|menu|creator|loading|settings</c> with <c>-ascendShot file.png</c>
    /// captures that front-end screen; <c>-ascendSaveDir dir</c> points the saves at a folder (a demo save is written there when it has none).
    /// </summary>
    public static class FrontEndSession
    {
        public enum Mode { None, NewGame }

        public const string FieldScene = "Ring0_Graybox";
        public const string TitleScene = "Title";

        public static Mode Pending { get; private set; }
        public static AppearanceChoice NewLook { get; private set; }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        static void ResetStatics() { Clear(); }

        public static void Begin(Mode mode, AppearanceChoice look)
        {
            Pending = mode;
            NewLook = look != null ? look.Clone() : null;
        }

        public static void Clear() { Pending = Mode.None; NewLook = null; }

        // ------------------------------------------------------------------ command line

        public static string Arg(string name)
        {
            var args = Environment.GetCommandLineArgs();
            for (int i = 0; i < args.Length - 1; i++) if (args[i] == name) return args[i + 1];
            return null;
        }

        /// <summary>The front-end screen to capture (<c>-ascendFront</c>), or null.</summary>
        public static string CaptureScreen => Arg("-ascendFront");

        // ------------------------------------------------------------------ the save on disk

        static readonly JsonSerializerSettings Json = new JsonSerializerSettings
        {
            Formatting = Formatting.Indented,
            Converters = { new StringEnumConverter() },
            Culture = System.Globalization.CultureInfo.InvariantCulture,
        };

        /// <summary>Where the default slot lives right now (<see cref="PlayerSave.Folder"/> or the persistent data path).</summary>
        public static string SlotPath => PlayerSave.PathFor(PlayerSave.DefaultSlot);

        /// <summary>Reads and checks the slot without touching it. False when there is none, it is unreadable, invalid or a fallen hardcore character.</summary>
        public static bool TryReadSave(out SaveGame save)
        {
            save = null;
            try
            {
                var path = SlotPath;
                if (!AtomicFile.AnyExists(path)) return false;
                SaveGame found = null;
                // main, then .bak, then .tmp; a valid but fallen hardcore main ends the search (never an older living backup)
                AtomicFile.ReadWithRecovery(path, t =>
                {
                    try
                    {
                        var s = SaveRules.Upgrade(JsonConvert.DeserializeObject<SaveGame>(t, Json));
                        if (s == null || SaveRules.Validate(s).Count > 0) return AtomicFile.Verdict.Reject;
                        if (s.Fallen) return AtomicFile.Verdict.Stop;
                        found = s; return AtomicFile.Verdict.Accept;
                    }
                    catch (Exception) { return AtomicFile.Verdict.Reject; }
                }, out _);
                if (found == null) return false;
                save = found;
                return true;
            }
            catch (Exception) { return false; }
        }

        public static bool HasSave => TryReadSave(out _);

        /// <summary>One line about the slot for the Continue row ("Wren, level 7, saved 2026-11-08"), or "" without one.</summary>
        public static string SaveSummary()
        {
            if (!TryReadSave(out var s)) return "";
            string when = "";
            if (DateTime.TryParse(s.SavedAtUtc, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.RoundtripKind, out var t))
                when = ", saved " + t.ToLocalTime().ToString("yyyy-MM-dd HH:mm", System.Globalization.CultureInfo.InvariantCulture);
            return $"{s.PlayerName}, level {s.Level}{when}";
        }

        /// <summary>Writes a small valid demo slot into a folder that has none (captures only). Refuses the real save folder.</summary>
        public static void SeedDemoSave(string folder)
        {
            if (string.IsNullOrEmpty(folder)) return;
            string full = Path.GetFullPath(folder);
            if (string.Equals(full.TrimEnd('\\', '/'), Path.GetFullPath(Application.persistentDataPath).TrimEnd('\\', '/'), StringComparison.OrdinalIgnoreCase)) return;
            Directory.CreateDirectory(full);
            string slot = Path.Combine(full, PlayerSave.DefaultSlot + ".json");
            if (File.Exists(slot)) return;
            var s = new SaveGame { Level = 7, Copper = 340, SavedAtUtc = DateTime.UtcNow.ToString("o", System.Globalization.CultureInfo.InvariantCulture) };
            AppearanceRules.WriteTo(s, new AppearanceChoice { PlayerName = "Wren", Body = Body.Feminine, HairStyle = "ponytail", HairColour = "sky", SkinTone = "golden", OutfitColour = "teal" });
            File.WriteAllText(slot, JsonConvert.SerializeObject(SaveRules.Upgrade(s), Json));
        }
    }
}
