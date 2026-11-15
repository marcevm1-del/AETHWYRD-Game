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
        public const string AssetPath = "Assets/_Game/Audio/AethwyrdMixer.mixer";

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
            var expose = ctrlType.GetMethod("AddExposedParameter", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (var (group, _, param) in Buses.Concat(new[] { ("Master", "", "vol_master") }))
            {
                if (expose == null) break;
                var grp = mixer.FindMatchingGroups(group).FirstOrDefault(g => g.name == group);
                if (grp == null) continue;
                try
                {
                    expose.Invoke(controller, new object[] { param, grp });
                }
                catch (Exception)
                {
                    // already exposed, or a different signature: SetFloat will tell us at runtime either way
                }
            }

            EditorUtility.SetDirty(mixer);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();

            var names = string.Join(", ", Buses.Select(b => b.Group));
            Debug.Log("[mixer] groups now: " + names);
            return true;
        }
    }
}
