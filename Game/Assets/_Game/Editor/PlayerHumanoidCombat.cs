// Stand-in combat poses for the Humanoid player body.
//
// WHY THIS EXISTS: the Generic placeholder combat clips (Player.controller's Combat_*.anim) animate bones named
// "Visual/Hips/Spine/ArmR", which the Humanoid body does not have, so on it they would play as nothing: the
// sword arm would stay at the character's side during every attack. The real answer is the committed combat clip
// generator (Tools/blender/build_combat_clips.py, 106 clips, one FBX per weapon family), but those clips are split
// by hit weight, not by the Startup / Active / Recovery / Charge phases the Animator is driven by, so wiring them
// is a design job of its own (see the PR description).
//
// WHAT THIS IS INSTEAD: four tiny clips written as Humanoid muscle curves (Animator-type float curves named by
// HumanTrait.MuscleName). Muscle curves retarget to any Humanoid avatar, so nothing here depends on this body's
// bones. They pose the upper body only (spine, chest, neck, head, both shoulders, arms and hands) and the combat
// layer is masked to those parts, so the legs keep walking or standing underneath.
//
// NOT UNITY-VERIFIED. The muscle values are estimates from Unity's documented ranges; the SIGN of a muscle
// (which way is "front", which way is "right twist") has not been looked at on this body. Expect to flip or
// rescale a few numbers after the first look. They read as "a sword swing" or they do not; that is the owner's
// eyes, and the numbers are all in the tables below.
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Ascend.EditorTools
{
    public static class PlayerHumanoidCombat
    {
        public const string Dir = "Assets/_Game/Art/Animation/Humanoid/Combat";
        public const string MaskPath = Dir + "/UpperBody.mask";

        // Muscles the combat layer owns. Prefix match against HumanTrait.MuscleName; fingers and eyes do not match.
        static readonly string[] UpperPrefixes =
        {
            "Spine ", "Chest ", "UpperChest ", "Neck ", "Head ",
            "Left Shoulder ", "Left Arm ", "Left Forearm ", "Left Hand ",
            "Right Shoulder ", "Right Arm ", "Right Forearm ", "Right Hand ",
        };

        // ---------------------------------------------------------------- poses (muscle -> normalized value)

        // Arms hang by the sides: -1 on Arm Down-Up is the muscle's lowest reach.
        static readonly Dictionary<string, float> Rest = new Dictionary<string, float>
        {
            { "Right Arm Down-Up", -0.8f }, { "Left Arm Down-Up", -0.8f },
        };

        // Sword hand cocked back and up over the shoulder, off hand forward as a guard, torso wound to the sword side.
        static readonly Dictionary<string, float> WindUp = new Dictionary<string, float>
        {
            { "Right Arm Down-Up", 0.45f }, { "Right Arm Front-Back", 0.55f }, { "Right Forearm Stretch", -0.4f },
            { "Left Arm Down-Up", -0.2f },  { "Left Arm Front-Back", -0.4f },
            { "Spine Twist Left-Right", 0.35f }, { "Chest Twist Left-Right", 0.3f }, { "Spine Front-Back", 0.1f },
        };

        // Sword hand swept forward and across, torso unwound the other way and leaning into it.
        static readonly Dictionary<string, float> Strike = new Dictionary<string, float>
        {
            { "Right Arm Down-Up", 0.1f }, { "Right Arm Front-Back", -0.7f }, { "Right Forearm Stretch", 0.6f },
            { "Left Arm Down-Up", -0.5f }, { "Left Arm Front-Back", 0.3f },
            { "Spine Twist Left-Right", -0.4f }, { "Chest Twist Left-Right", -0.35f }, { "Spine Front-Back", -0.15f },
        };

        // ---------------------------------------------------------------- avatar mask

        /// <summary>Spine, head and both arms. Root, legs, fingers and IK are left to the base layer.</summary>
        public static AvatarMask UpperBodyMask()
        {
            EnsureFolders();
            var mask = AssetDatabase.LoadAssetAtPath<AvatarMask>(MaskPath);
            if (mask == null)
            {
                mask = new AvatarMask { name = "UpperBody" };
                AssetDatabase.CreateAsset(mask, MaskPath);
            }
            foreach (AvatarMaskBodyPart part in Enum.GetValues(typeof(AvatarMaskBodyPart)))
            {
                if (part == AvatarMaskBodyPart.LastBodyPart) continue;
                mask.SetHumanoidBodyPartActive(part, part == AvatarMaskBodyPart.Body || part == AvatarMaskBodyPart.Head
                                                     || part == AvatarMaskBodyPart.LeftArm || part == AvatarMaskBodyPart.RightArm);
            }
            EditorUtility.SetDirty(mask);
            return mask;
        }

        // ---------------------------------------------------------------- clips

        /// <summary>Adds Combat_Startup, Combat_Active, Combat_Recovery and Combat_Charge to <paramref name="clips"/>.</summary>
        public static bool TryBuildClips(Dictionary<string, AnimationClip> clips, out string problem)
        {
            problem = null;
            EnsureFolders();

            var all = HumanTrait.MuscleName;
            var upper = all.Where(n => UpperPrefixes.Any(p => n.StartsWith(p, StringComparison.Ordinal))).ToArray();
            var wanted = Rest.Keys.Concat(WindUp.Keys).Concat(Strike.Keys).Distinct().ToArray();
            var unknown = wanted.Where(w => !all.Contains(w)).ToArray();
            if (unknown.Length > 0)
            {
                problem = "this Unity version has no humanoid muscle named " + string.Join(", ", unknown)
                          + " (HumanTrait.MuscleName changed); fix the tables in PlayerHumanoidCombat.cs";
                return false;
            }
            if (upper.Length < 28)
            {
                problem = "only " + upper.Length + " upper-body muscles matched the name prefixes; expected 28 or more";
                return false;
            }

            // Every upper-body muscle is keyed in every clip. A humanoid muscle that a clip does not mention is
            // evaluated at 0, which is the avatar's T-pose, so leaving the arms out would throw them wide.
            clips["Combat_Startup"] = Write("Combat_Startup", 1f, false, upper,
                t => Pose(Rest, WindUp, Ease(t)));
            clips["Combat_Active"] = Write("Combat_Active", 1f, false, upper,
                t => Pose(WindUp, Strike, Ease(Mathf.Clamp01(t / 0.7f))));
            clips["Combat_Recovery"] = Write("Combat_Recovery", 1f, false, upper,
                t => Pose(Strike, Rest, Ease(t)));
            clips["Combat_Charge"] = Write("Combat_Charge", 1f, true, upper,
                t => (name) => Pose(WindUp, WindUp, 0f)(name) + 0.03f * Mathf.Sin(Mathf.PI * 6f * t));
            return true;
        }

        static float Ease(float t) { t = Mathf.Clamp01(t); return t * t * (3f - 2f * t); }

        /// <summary>The value of one muscle between two poses; a muscle neither pose names is 0 (neutral).</summary>
        static Func<string, float> Pose(Dictionary<string, float> a, Dictionary<string, float> b, float k)
        {
            return name =>
            {
                a.TryGetValue(name, out var va);
                b.TryGetValue(name, out var vb);
                // A pose that omits a muscle falls back to Rest's value for it, so the arms never snap to T.
                if (!a.ContainsKey(name) && Rest.TryGetValue(name, out var ra)) va = ra;
                if (!b.ContainsKey(name) && Rest.TryGetValue(name, out var rb)) vb = rb;
                return Mathf.Lerp(va, vb, k);
            };
        }

        static AnimationClip Write(string name, float length, bool loop, string[] muscles, Func<float, Func<string, float>> pose)
        {
            var path = Dir + "/" + name + ".anim";
            var clip = AssetDatabase.LoadAssetAtPath<AnimationClip>(path);
            if (clip == null)
            {
                clip = new AnimationClip { name = name };
                AssetDatabase.CreateAsset(clip, path);
            }
            else
            {
                clip.ClearCurves();
            }

            clip.frameRate = 30f;
            var n = Mathf.Max(4, Mathf.CeilToInt(length * 30f));
            foreach (var muscle in muscles)
            {
                var keys = new Keyframe[n + 1];
                for (var i = 0; i <= n; i++) keys[i] = new Keyframe(length * i / n, pose(length * i / n / length)(muscle));
                var curve = new AnimationCurve(keys);
                for (var i = 0; i < keys.Length; i++) curve.SmoothTangents(i, 0f);
                AnimationUtility.SetEditorCurve(clip, EditorCurveBinding.FloatCurve(string.Empty, typeof(Animator), muscle), curve);
            }

            var settings = AnimationUtility.GetAnimationClipSettings(clip);
            settings.loopTime = loop;
            settings.startTime = 0f;
            settings.stopTime = length;
            AnimationUtility.SetAnimationClipSettings(clip, settings);
            clip.wrapMode = loop ? WrapMode.Loop : WrapMode.Default;
            EditorUtility.SetDirty(clip);
            return clip;
        }

        static void EnsureFolders()
        {
            foreach (var (parent, leaf) in new[] { ("Assets/_Game/Art", "Animation"), ("Assets/_Game/Art/Animation", "Humanoid"),
                                                    ("Assets/_Game/Art/Animation/Humanoid", "Combat") })
            {
                if (!AssetDatabase.IsValidFolder(parent + "/" + leaf)) AssetDatabase.CreateFolder(parent, leaf);
            }
        }
    }
}
