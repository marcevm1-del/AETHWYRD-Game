using System;
using System.IO;
using Ascend.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using UnityEngine;

namespace Ascend.Game
{
    /// <summary>
    /// The settings that live outside a save: <c>settings.json</c> beside the slots, holding the Core <see cref="AccessibilitySettings"/>.
    /// The title screen's Settings page edits it (through the same AccessibilityWindow as in play) and the field scene starts from it.
    /// Missing or unreadable file: null, so callers use the data defaults. In the editor with no explicit
    /// <see cref="PlayerSave.Folder"/> nothing is read or written, so tests never touch the real profile folder.
    /// </summary>
    public static class GameSettings
    {
        public const string FileName = "settings.json";

        static readonly JsonSerializerSettings Json = new JsonSerializerSettings
        {
            Formatting = Formatting.Indented,
            Converters = { new StringEnumConverter() },
            Culture = System.Globalization.CultureInfo.InvariantCulture,
        };

        static bool Enabled => PlayerSave.Folder != null || !Application.isEditor;

        public static string PathOnDisk => Path.Combine(PlayerSave.Folder ?? Application.persistentDataPath, FileName);

        /// <summary>The stored settings (clamped), or null when there are none.</summary>
        public static AccessibilitySettings TryLoad()
        {
            if (!Enabled) return null;
            try
            {
                if (!File.Exists(PathOnDisk)) return null;
                var s = JsonConvert.DeserializeObject<AccessibilitySettings>(File.ReadAllText(PathOnDisk), Json);
                return s != null ? s.Sanitize() : null;
            }
            catch (Exception e) { Debug.LogWarning("settings.json not loaded: " + e.Message); return null; }
        }

        public static void Save(AccessibilitySettings s)
        {
            if (!Enabled || s == null) return;
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(PathOnDisk));
                string tmp = PathOnDisk + ".tmp";
                File.WriteAllText(tmp, JsonConvert.SerializeObject(s, Json));
                if (File.Exists(PathOnDisk)) File.Delete(PathOnDisk);
                File.Move(tmp, PathOnDisk);
            }
            catch (Exception e) { Debug.LogWarning("settings.json not saved: " + e.Message); }
        }
    }
}
