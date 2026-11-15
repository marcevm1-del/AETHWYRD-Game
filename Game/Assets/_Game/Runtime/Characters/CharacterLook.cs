using Ascend.Core;
using UnityEngine;

namespace Ascend.Game
{
    /// <summary>
    /// Puts a look on whatever body is under a root's "Visual": on a generated character (skinned meshes from the character
    /// generator) the applier, the face driver and hair motion; on the placeholder rig nothing more than PlaceholderPlayerBody
    /// already did. Used by the player (PlayerAppearance) and the creator's preview (CreatorPreview), so both always agree.
    /// </summary>
    public static class CharacterLook
    {
        public static void Apply(Transform root, AppearanceChoice look, PlayerAppearanceFile legacy)
        {
            if (root == null || look == null || look.Custom == null) return;
            var visual = root.Find("Visual");
            var f = AscendData.Customization;
            if (visual == null || f == null) return;
            if (visual.GetComponentsInChildren<SkinnedMeshRenderer>(true).Length == 0) return; // the placeholder rig
            var skinEntry = legacy?.SkinTones.Find(s => s.Id == look.SkinTone);
            var skin = CharacterSlots.ToColour(skinEntry?.Hex, new Color(0.94f, 0.79f, 0.66f));
            CharacterAppearanceApplier.Ensure(visual.gameObject).Apply(look.Custom, skin, f);
            FaceExpressionDriver.Ensure(visual.gameObject).Show(look.Custom.Expression);
            HairMotion.Ensure(visual.gameObject);
        }
    }

    /// <summary>The saved-looks book on disk: Application.persistentDataPath/character_looks.json, beside (never inside) the save.</summary>
    public static class CharacterPresetStore
    {
        public const string FileName = "character_looks.json";
        public static string Folder;   // tests point this at a temp folder
        static string PathOnDisk => System.IO.Path.Combine(Folder ?? Application.persistentDataPath, FileName);

        public static CharacterPresetBook Load()
        {
            try
            {
                if (!System.IO.File.Exists(PathOnDisk)) return new CharacterPresetBook();
                var b = Newtonsoft.Json.JsonConvert.DeserializeObject<CharacterPresetBook>(System.IO.File.ReadAllText(PathOnDisk)) ?? new CharacterPresetBook();
                b.Repair(AscendData.Customization);
                return b;
            }
            catch (System.Exception e) { Debug.LogWarning("saved looks could not be read: " + e.Message); return new CharacterPresetBook(); }
        }

        public static void Save(CharacterPresetBook book)
        {
            if (book == null) return;
            try
            {
                System.IO.Directory.CreateDirectory(Folder ?? Application.persistentDataPath);
                string tmp = PathOnDisk + ".tmp";
                System.IO.File.WriteAllText(tmp, Newtonsoft.Json.JsonConvert.SerializeObject(book, Newtonsoft.Json.Formatting.Indented));
                if (System.IO.File.Exists(PathOnDisk)) System.IO.File.Delete(PathOnDisk);
                System.IO.File.Move(tmp, PathOnDisk);
            }
            catch (System.Exception e) { Debug.LogWarning("saved looks could not be written: " + e.Message); }
        }
    }
}
