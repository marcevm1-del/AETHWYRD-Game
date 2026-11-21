// Creates the project's AudioMixer asset with the six Canon buses, run headlessly so the asset is reproducible
// rather than hand-made in the editor and impossible to review.
//
//   Unity.exe -batchmode -quit -projectPath Game -executeMethod Ascend.EditorTools.CreateAudioMixer.Build
//
// Unity has no public API for creating an AudioMixer asset: AudioMixerController lives in the internal
// UnityEditor.Audio namespace, so this reaches it by reflection. If a future editor version moves or renames it the
// method fails loudly with what it could not find, which is the point - a silent skip would leave the project with
// no mixer and no sign of why.
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;

namespace Ascend.EditorTools
{
    public static class CreateAudioMixer
    {
        public const string AssetPath = "Assets/_Game/Resources/AethwyrdMixer.mixer";

        /// <summary>The six buses from 12_Systems, plus a UI sub-group under Effects (audio_plan.md item 1).</summary>
        static readonly (string Group, string Parent, string Param)[] Buses =
        {
            ("Music",     "Master",  "vol_music"),
            ("Effects",   "Master",  "vol_effects"),
            ("Ambience",  "Master",  "vol_ambience"),
            ("Dialogue",  "Master",  "vol_dialogue"),
            ("Callouts",  "Master",  "vol_callouts"),
            ("UI",        "Effects", "vol_ui"),
        };

        [MenuItem("Ascend/Audio/Create or update the mixer")]
        public static void Build()
        {
            var ok = TryBuild(out var why);
            Debug.Log(ok ? "[mixer] ok " + AssetPath : "[mixer] FAILED " + why);
            if (Application.isBatchMode)
                EditorApplication.Exit(ok ? 0 : 1);
        }

        public static bool TryBuild(out string why)
        {
            why = "";
            Directory.CreateDirectory(Path.GetDirectoryName(Path.Combine(Directory.GetCurrentDirectory(), AssetPath)));

            var ctrlType = typeof(AudioMixer).Assembly.GetType("UnityEngine.Audio.AudioMixerController")
                           ?? AppDomain.CurrentDomain.GetAssemblies()
                               .Select(a => a.GetType("UnityEditor.Audio.AudioMixerController"))
                               .FirstOrDefault(t => t != null);
            if (ctrlType == null)
            {
                why = "AudioMixerController type not found in any loaded assembly";
                return false;
            }

            var existing = AssetDatabase.LoadAssetAtPath<AudioMixer>(AssetPath);
            UnityEngine.Object controller = existing;
            if (controller == null)
            {
                var create = ctrlType.GetMethod("CreateMixerControllerAtPath",
                    BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic);
                if (create == null)
                {
                    why = "CreateMixerControllerAtPath not found on " + ctrlType.FullName;
                    return false;
                }
                controller = create.Invoke(null, new object[] { AssetPath }) as UnityEngine.Object;
                if (controller == null)
                {
                    why = "CreateMixerControllerAtPath returned null for " + AssetPath;
                    return false;
                }
            }

            var mixer = AssetDatabase.LoadAssetAtPath<AudioMixer>(AssetPath);
            if (mixer == null)
            {
                why = "no AudioMixer at " + AssetPath + " after creation";
                return false;
            }

            var masterProp = ctrlType.GetProperty("masterGroup", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            var master = masterProp?.GetValue(controller);
            if (master == null)
            {
                why = "masterGroup not readable on " + ctrlType.FullName;
                return false;
            }

            var addGroup = ctrlType.GetMethod("CreateNewGroup", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            var addChild = ctrlType.GetMethod("AddChildToParent", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            if (addGroup == null || addChild == null)
            {
                why = "CreateNewGroup/AddChildToParent not found on " + ctrlType.FullName;
                return false;
            }

            var made = new System.Collections.Generic.Dictionary<string, object> { { "Master", master } };
            foreach (var (group, parent, _) in Buses)
            {
                if (mixer.FindMatchingGroups(group).Any(g => g.name == group))
                {
                    made[group] = null;   // already there; nothing to add
                    continue;
                }
                var g = addGroup.Invoke(controller, new object[] { group, true });
                if (g == null)
                {
                    why = "CreateNewGroup returned null for " + group;
                    return false;
                }
                addChild.Invoke(controller, new[] { g, made.TryGetValue(parent, out var p) && p != null ? p : master });
                made[group] = g;
            }

            // Expose each group's volume so AudioBuses can drive it with SetFloat at runtime.
            // The first attempt passed (string, group) and silently produced m_ExposedParameters: []. The real
            // signature, found by introspection, is AddExposedParameter(AudioParameterPath), where the path is
            // AudioGroupParameterPath(AudioMixerGroupController group, GUID parameter) and the GUID comes from the
            // group's own GetGUIDForVolume(). Exposing it gives the parameter a default name, so the names are then
            // written back through the exposedParameters array.
            var pathType = AppDomain.CurrentDomain.GetAssemblies()
                .Select(a => a.GetType("UnityEditor.Audio.AudioGroupParameterPath")).FirstOrDefault(x => x != null);
            var expose = ctrlType.GetMethod("AddExposedParameter", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            if (pathType == null || expose == null)
            {
                why = "AudioGroupParameterPath or AddExposedParameter not found";
                return false;
            }
            var pathCtor = pathType.GetConstructors(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).FirstOrDefault();
            var wanted = Buses.Select(b => (b.Group, b.Param)).Concat(new[] { ("Master", "vol_master") }).ToArray();
            foreach (var (group, param) in wanted)
            {
                var grp = mixer.FindMatchingGroups(group).FirstOrDefault(g => g.name == group);
                if (grp == null) { why = "group missing after creation: " + group; return false; }
                var guidMethod = grp.GetType().GetMethod("GetGUIDForVolume", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                if (guidMethod == null) { why = "GetGUIDForVolume not found on " + grp.GetType().FullName; return false; }
                var guid = guidMethod.Invoke(grp, null);
                var path = pathCtor.Invoke(new[] { grp, guid });
                expose.Invoke(controller, new[] { path });
            }

            // Name them. ExposedAudioParameter carries a guid and a name; match on the guid we just exposed.
            var expProp = ctrlType.GetProperty("exposedParameters", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            var arr = expProp?.GetValue(controller) as Array;
            if (arr == null) { why = "exposedParameters did not read back as an array"; return false; }
            var nameField = arr.GetType().GetElementType().GetField("name", BindingFlags.Public | BindingFlags.Instance);
            var guidField = arr.GetType().GetElementType().GetField("guid", BindingFlags.Public | BindingFlags.Instance);
            if (nameField == null || guidField == null) { why = "ExposedAudioParameter has no name/guid field"; return false; }
            for (int i = 0; i < arr.Length; i++)
            {
                var entry = arr.GetValue(i);
                var g = guidField.GetValue(entry);
                foreach (var (group, param) in wanted)
                {
                    var grp = mixer.FindMatchingGroups(group).FirstOrDefault(x => x.name == group);
                    var gm = grp?.GetType().GetMethod("GetGUIDForVolume", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                    if (gm == null) continue;
                    if (Equals(gm.Invoke(grp, null), g))
                    {
                        nameField.SetValue(entry, param);
                        arr.SetValue(entry, i);
                        break;
                    }
                }
            }
            expProp.SetValue(controller, arr);
            Debug.Log("[mixer] exposed " + arr.Length + " parameters");

            EditorUtility.SetDirty(mixer);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();

            var names = string.Join(", ", Buses.Select(b => b.Group));
            Debug.Log("[mixer] groups now: " + names);
            return true;
        }
    }
}
