using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Ascend.Game;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Ascend.EditorTools
{
    /// <summary>
    /// Wave A1 / T3. Builds the placeholder player rig (primitive bones, Generic, no Avatar), the procedural animation
    /// clips and the two-layer Player AnimatorController. Everything is idempotent: re-running reuses the same asset
    /// files (so GUIDs stay stable) and rewrites their content.
    ///
    /// Contract (see the Wave A1 plan): parameters Speed, Grounded, VerticalVelocity, Dodging, Jump (trigger),
    /// CombatPhase, CombatHit, Special, Charging, SpeedMult (+ CombatSpeed, an addition: playback multiplier for the
    /// combat-layer phase states so a 1 s placeholder clip can fill the live phase duration).
    /// Layer 0 "Base": Locomotion (1D blend tree on Speed), JumpStart, Fall, Land, Dodge.
    /// Layer 1 "Combat" (override, default weight 0, script-driven): CombatIdle, Startup, Active, Recovery, Charge.
    /// Curve paths are relative to the Animator object (the Player root): Visual/Hips/Spine/Head etc.
    ///
    /// Run from the command line:
    ///   Unity -batchmode -projectPath Game -quit -executeMethod Ascend.EditorTools.PlayerAnimationAssets.BuildBatch
    /// </summary>
    public static class PlayerAnimationAssets
    {
        public const string Dir = "Assets/_Game/Art/Animation";
        public const string ClipDir = Dir + "/Clips";
        public const string ControllerPath = Dir + "/Player.controller";

        // Bone paths (clip curve paths), relative to the Animator root.
        public const string PathHips = "Visual/Hips";
        public const string PathSpine = "Visual/Hips/Spine";
        public const string PathHead = "Visual/Hips/Spine/Head";
        public const string PathArmL = "Visual/Hips/Spine/ArmL";
        public const string PathArmR = "Visual/Hips/Spine/ArmR";
        public const string PathLegL = "Visual/Hips/LegL";
        public const string PathLegR = "Visual/Hips/LegR";
        public const string PathFootL = "Visual/Hips/LegL/FootL";
        public const string PathFootR = "Visual/Hips/LegR/FootR";

        /// <summary>Hips rest height above the Visual root (feet end at about y = 0.04).</summary>
        const float HipsY = 0.95f;

        static readonly float[] FallbackThresholds = { 0f, 2.2f, 6.5f, 9.5f };
        const float FallbackDodgeSec = 0.42f;

        // ------------------------------------------------------------------ data readers

        [Serializable] class LocoState { public float walk; public float run; public float sprint; }
        [Serializable] class LocoFile { public float baseSpeed; public LocoState state; }
        [Serializable] class DodgeBlock { public float durationSec; }
        [Serializable] class TuningFile { public DodgeBlock dodge; }

        /// <summary>
        /// Blend-tree thresholds {0, walk, run, sprint} in m/s from Data/Player/locomotion.json (baseSpeed * state.X).
        /// Returns false (and the constants 0 / 2.2 / 6.5 / 9.5) when the file is absent or unusable.
        /// </summary>
        public static bool TryLoadThresholds(out float[] thresholds)
        {
            thresholds = (float[])FallbackThresholds.Clone();
            try
            {
                var path = Path.Combine(AscendData.DataRoot, "Player", "locomotion.json");
                if (!File.Exists(path)) return false;
                var f = JsonUtility.FromJson<LocoFile>(File.ReadAllText(path));
                if (f == null || f.state == null || f.baseSpeed <= 0f) return false;
                var t = new[] { 0f, f.baseSpeed * f.state.walk, f.baseSpeed * f.state.run, f.baseSpeed * f.state.sprint };
                if (!(t[1] > t[0] && t[2] > t[1] && t[3] > t[2])) return false;
                thresholds = t;
                return true;
            }
            catch (Exception e)
            {
                Debug.LogWarning("PlayerAnimationAssets: could not read locomotion.json (" + e.Message + "); using fallback thresholds.");
                return false;
            }
        }

        static float LoadDodgeSeconds()
        {
            try
            {
                var path = Path.Combine(AscendData.DataRoot, "Combat", "combat_tuning.json");
                if (!File.Exists(path)) return FallbackDodgeSec;
                var f = JsonUtility.FromJson<TuningFile>(File.ReadAllText(path));
                if (f != null && f.dodge != null && f.dodge.durationSec > 0.05f) return f.dodge.durationSec;
            }
            catch (Exception e) { Debug.LogWarning("PlayerAnimationAssets: could not read dodge duration (" + e.Message + ")."); }
            return FallbackDodgeSec;
        }

        // ------------------------------------------------------------------ entry points

        [MenuItem("Ascend/Animation/Build Player Animation Assets")]
        public static void BuildMenu()
        {
            BuildAll();
            Debug.Log("PlayerAnimationAssets: built " + ControllerPath);
        }

        /// <summary>Batch entry: builds, verifies the contract and exits non-zero on failure.</summary>
        public static void BuildBatch()
        {
            try
            {
                var c = BuildAll();
                var ok = Verify(c, out var report);
                Debug.Log(report);
                if (!ok) EditorApplication.Exit(1);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                EditorApplication.Exit(1);
            }
        }

        /// <summary>Verify only (does not rebuild); useful as a second run to prove idempotency.</summary>
        public static void VerifyBatch()
        {
            var c = AssetDatabase.LoadAssetAtPath<AnimatorController>(ControllerPath);
            if (c == null) { Debug.LogError("PlayerAnimationAssets: " + ControllerPath + " is missing."); EditorApplication.Exit(1); return; }
            var ok = Verify(c, out var report);
            Debug.Log(report);
            if (!ok) EditorApplication.Exit(1);
        }

        /// <summary>Creates (or rewrites in place) every clip and the controller. Returns the controller.</summary>
        public static AnimatorController BuildAll()
        {
            EnsureFolder("Assets/_Game/Art", "Animation");
            EnsureFolder(Dir, "Clips");

            if (!TryLoadThresholds(out var thr))
                Debug.Log("PlayerAnimationAssets: Data/Player/locomotion.json not usable, blend thresholds fall back to 0 / 2.2 / 6.5 / 9.5.");

            var clips = BuildClips(LoadDodgeSeconds());
            var ctrl = BuildController(clips, thr);

            EditorUtility.SetDirty(ctrl);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            return ctrl;
        }

        // ------------------------------------------------------------------ placeholder rig

        /// <summary>
        /// Builds the "Visual" bone hierarchy (primitive meshes, colliders removed) under <paramref name="parent"/> and
        /// returns the Visual root. Any existing "Visual" child is replaced. Materials are optional.
        /// </summary>
        public static GameObject BuildPlaceholderRig(Transform parent, Material body = null, Material accent = null)
        {
            var old = parent.Find("Visual");
            if (old != null) Object.DestroyImmediate(old.gameObject);

            var visual = new GameObject("Visual");
            visual.transform.SetParent(parent, false);

            var hips = Bone(visual.transform, "Hips", new Vector3(0f, HipsY, 0f));
            Part(hips, PrimitiveType.Cube, "Pelvis", Vector3.zero, new Vector3(0.34f, 0.2f, 0.22f), body);

            var spine = Bone(hips, "Spine", new Vector3(0f, 0.1f, 0f));
            Part(spine, PrimitiveType.Capsule, "Torso", new Vector3(0f, 0.3f, 0f), new Vector3(0.36f, 0.3f, 0.24f), body);

            var head = Bone(spine, "Head", new Vector3(0f, 0.72f, 0f));
            Part(head, PrimitiveType.Sphere, "Skull", Vector3.zero, new Vector3(0.26f, 0.28f, 0.26f), body);
            Part(head, PrimitiveType.Cube, "Nose", new Vector3(0f, -0.01f, 0.14f), new Vector3(0.08f, 0.06f, 0.1f), accent);

            var armL = Bone(spine, "ArmL", new Vector3(-0.26f, 0.58f, 0f));
            Part(armL, PrimitiveType.Capsule, "ArmMeshL", new Vector3(0f, -0.27f, 0f), new Vector3(0.1f, 0.27f, 0.1f), accent);
            var armR = Bone(spine, "ArmR", new Vector3(0.26f, 0.58f, 0f));
            Part(armR, PrimitiveType.Capsule, "ArmMeshR", new Vector3(0f, -0.27f, 0f), new Vector3(0.1f, 0.27f, 0.1f), accent);

            var legL = Bone(hips, "LegL", new Vector3(-0.12f, -0.05f, 0f));
            Part(legL, PrimitiveType.Capsule, "LegMeshL", new Vector3(0f, -0.43f, 0f), new Vector3(0.15f, 0.43f, 0.15f), body);
            var footL = Bone(legL, "FootL", new Vector3(0f, -0.86f, 0f));
            Part(footL, PrimitiveType.Cube, "FootMeshL", new Vector3(0f, 0f, 0.06f), new Vector3(0.13f, 0.08f, 0.28f), accent);

            var legR = Bone(hips, "LegR", new Vector3(0.12f, -0.05f, 0f));
            Part(legR, PrimitiveType.Capsule, "LegMeshR", new Vector3(0f, -0.43f, 0f), new Vector3(0.15f, 0.43f, 0.15f), body);
            var footR = Bone(legR, "FootR", new Vector3(0f, -0.86f, 0f));
            Part(footR, PrimitiveType.Cube, "FootMeshR", new Vector3(0f, 0f, 0.06f), new Vector3(0.13f, 0.08f, 0.28f), accent);

            return visual;
        }

        static Transform Bone(Transform parent, string name, Vector3 localPos)
        {
            var go = new GameObject(name);
            go.transform.SetParent(parent, false);
            go.transform.localPosition = localPos;
            return go.transform;
        }

        static void Part(Transform bone, PrimitiveType type, string name, Vector3 localPos, Vector3 scale, Material mat)
        {
            var go = GameObject.CreatePrimitive(type);
            go.name = name;
            var col = go.GetComponent<Collider>();
            if (col != null) Object.DestroyImmediate(col);
            go.transform.SetParent(bone, false);
            go.transform.localPosition = localPos;
            go.transform.localScale = scale;
            if (mat != null) go.GetComponent<Renderer>().sharedMaterial = mat;
        }

        // ------------------------------------------------------------------ clips

        // Animated channels. id -> (curve path, property, rest value). Base-layer clips key every channel
        // (so blends never leave stale values); combat clips key only the channels they list.
        static readonly Dictionary<string, (string path, string prop, float rest)> Channels = new Dictionary<string, (string, string, float)>
        {
            { "Hips.y",   (PathHips,  "m_LocalPosition.y",      HipsY) },
            { "Hips.rx",  (PathHips,  "localEulerAnglesRaw.x",  0f) },
            { "Spine.rx", (PathSpine, "localEulerAnglesRaw.x",  0f) },
            { "Spine.ry", (PathSpine, "localEulerAnglesRaw.y",  0f) },
            { "Head.rx",  (PathHead,  "localEulerAnglesRaw.x",  0f) },
            { "ArmL.rx",  (PathArmL,  "localEulerAnglesRaw.x",  0f) },
            { "ArmR.rx",  (PathArmR,  "localEulerAnglesRaw.x",  0f) },
            { "LegL.rx",  (PathLegL,  "localEulerAnglesRaw.x",  0f) },
            { "LegR.rx",  (PathLegR,  "localEulerAnglesRaw.x",  0f) },
        };

        // ---- small curve helpers (t is normalized clip time 0..1)
        static float Sin(float t, float cycles = 1f, float phase = 0f) => Mathf.Sin(Mathf.PI * 2f * (t * cycles + phase));
        static float Smooth(float t) { t = Mathf.Clamp01(t); return t * t * (3f - 2f * t); }
        static float Seg(float t, float t0, float t1, float a, float b) => Mathf.Lerp(a, b, Smooth(Mathf.InverseLerp(t0, t1, t)));
        static float Bump(float t) => Mathf.Sin(Mathf.PI * Mathf.Clamp01(t));

        /// <summary>Walk / run / sprint share one shape; only amplitude, lean and bob differ.</summary>
        static Dictionary<string, Func<float, float>> Gait(float legAmp, float armAmp, float lean, float bob, float twist)
        {
            return new Dictionary<string, Func<float, float>>
            {
                { "Hips.y",   t => HipsY + bob * Mathf.Cos(Mathf.PI * 2f * 2f * t) },
                { "Spine.rx", t => lean + 1.5f * Mathf.Cos(Mathf.PI * 2f * 2f * t) },
                { "Spine.ry", t => twist * Sin(t) },
                { "Head.rx",  t => -lean * 0.5f },
                { "LegL.rx",  t => -legAmp * Sin(t) },
                { "LegR.rx",  t => legAmp * Sin(t) },
                { "ArmL.rx",  t => armAmp * Sin(t) },
                { "ArmR.rx",  t => -armAmp * Sin(t) },
            };
        }

        struct ClipDef
        {
            public string Name;
            public float Length;
            public bool Loop;
            public bool FullSet; // key every channel (base layer) vs only the listed ones (combat layer)
            public Dictionary<string, Func<float, float>> Fns;
        }

        static Dictionary<string, AnimationClip> BuildClips(float dodgeSec)
        {
            var defs = new List<ClipDef>();

            defs.Add(new ClipDef
            {
                Name = "Idle", Length = 2.0f, Loop = true, FullSet = true,
                Fns = new Dictionary<string, Func<float, float>>
                {
                    { "Hips.y",   t => HipsY + 0.006f * Sin(t) },
                    { "Spine.rx", t => 1.5f * Sin(t) },
                    { "Head.rx",  t => 1.0f * Sin(t, 1f, 0.15f) },
                    { "ArmL.rx",  t => 2.0f * Sin(t, 1f, 0.1f) },
                    { "ArmR.rx",  t => -2.0f * Sin(t, 1f, 0.1f) },
                },
            });
            defs.Add(new ClipDef { Name = "Walk", Length = 1.0f, Loop = true, FullSet = true, Fns = Gait(25f, 20f, 3f, 0.015f, 4f) });
            defs.Add(new ClipDef { Name = "Run", Length = 0.75f, Loop = true, FullSet = true, Fns = Gait(50f, 45f, 8f, 0.04f, 7f) });
            defs.Add(new ClipDef { Name = "Sprint", Length = 0.55f, Loop = true, FullSet = true, Fns = Gait(65f, 60f, 15f, 0.05f, 9f) });

            defs.Add(new ClipDef
            {
                Name = "JumpStart", Length = 0.45f, Loop = false, FullSet = true,
                Fns = new Dictionary<string, Func<float, float>>
                {
                    { "Hips.y",   t => t < 0.4f ? Seg(t, 0f, 0.4f, HipsY, 0.82f) : Seg(t, 0.4f, 1f, 0.82f, 0.97f) },
                    { "Spine.rx", t => t < 0.4f ? Seg(t, 0f, 0.4f, 0f, 10f) : Seg(t, 0.4f, 1f, 10f, -4f) },
                    { "LegL.rx",  t => Seg(t, 0.3f, 1f, 0f, -45f) },
                    { "LegR.rx",  t => Seg(t, 0.3f, 1f, 0f, -15f) },
                    { "ArmL.rx",  t => t < 0.4f ? Seg(t, 0f, 0.4f, 0f, 25f) : Seg(t, 0.4f, 1f, 25f, -70f) },
                    { "ArmR.rx",  t => t < 0.4f ? Seg(t, 0f, 0.4f, 0f, 25f) : Seg(t, 0.4f, 1f, 25f, -70f) },
                },
            });
            defs.Add(new ClipDef
            {
                Name = "Fall", Length = 0.6f, Loop = true, FullSet = true,
                Fns = new Dictionary<string, Func<float, float>>
                {
                    { "Spine.rx", t => 4f },
                    { "ArmL.rx",  t => -65f + 8f * Sin(t) },
                    { "ArmR.rx",  t => -65f + 8f * Sin(t, 1f, 0.5f) },
                    { "LegL.rx",  t => -25f + 8f * Sin(t) },
                    { "LegR.rx",  t => -10f + 8f * Sin(t, 1f, 0.5f) },
                },
            });
            defs.Add(new ClipDef
            {
                Name = "Land", Length = 0.35f, Loop = false, FullSet = true,
                Fns = new Dictionary<string, Func<float, float>>
                {
                    { "Hips.y",   t => HipsY - 0.22f * Bump(t) },
                    { "Spine.rx", t => 18f * Bump(t) },
                    { "Head.rx",  t => -8f * Bump(t) },
                    { "LegL.rx",  t => -30f * Bump(t) },
                    { "LegR.rx",  t => -30f * Bump(t) },
                    { "ArmL.rx",  t => -25f * Bump(t) },
                    { "ArmR.rx",  t => -25f * Bump(t) },
                },
            });
            defs.Add(new ClipDef
            {
                // Forward roll: Hips pitch 0 -> 360 over the dodge duration (combat_tuning dodge.durationSec).
                Name = "Dodge", Length = dodgeSec, Loop = false, FullSet = true,
                Fns = new Dictionary<string, Func<float, float>>
                {
                    { "Hips.rx",  t => 360f * Smooth(t) },
                    { "Hips.y",   t => Mathf.Lerp(HipsY, 0.6f, Bump(t)) },
                    { "Spine.rx", t => 50f * Bump(t) },
                    { "Head.rx",  t => 30f * Bump(t) },
                    { "LegL.rx",  t => -90f * Bump(t) },
                    { "LegR.rx",  t => -90f * Bump(t) },
                    { "ArmL.rx",  t => -70f * Bump(t) },
                    { "ArmR.rx",  t => -70f * Bump(t) },
                },
            });

            // Combat layer (placeholder length 1 s each; the bridge scales playback via the CombatSpeed parameter).
            defs.Add(new ClipDef
            {
                Name = "Combat_Startup", Length = 1f, Loop = false, FullSet = false,
                Fns = new Dictionary<string, Func<float, float>>
                {
                    { "Hips.y",   t => Seg(t, 0f, 1f, HipsY, 0.92f) },
                    { "Spine.rx", t => Seg(t, 0f, 1f, 0f, -10f) },
                    { "Spine.ry", t => Seg(t, 0f, 1f, 0f, -25f) },
                    { "ArmR.rx",  t => Seg(t, 0f, 1f, 0f, -120f) },
                    { "ArmL.rx",  t => Seg(t, 0f, 1f, 0f, -20f) },
                    { "LegL.rx",  t => Seg(t, 0f, 1f, 0f, -15f) },
                    { "LegR.rx",  t => Seg(t, 0f, 1f, 0f, 15f) },
                },
            });
            defs.Add(new ClipDef
            {
                Name = "Combat_Active", Length = 1f, Loop = false, FullSet = false,
                Fns = new Dictionary<string, Func<float, float>>
                {
                    { "Hips.y",   t => Seg(t, 0f, 1f, 0.92f, 0.9f) },
                    { "Spine.rx", t => Seg(t, 0f, 0.7f, -10f, 12f) },
                    { "Spine.ry", t => Seg(t, 0f, 0.7f, -25f, 30f) },
                    { "ArmR.rx",  t => Seg(t, 0f, 0.7f, -120f, 30f) },
                    { "ArmL.rx",  t => Seg(t, 0f, 0.7f, -20f, 15f) },
                    { "LegL.rx",  t => Seg(t, 0f, 0.7f, -15f, -30f) },
                    { "LegR.rx",  t => Seg(t, 0f, 0.7f, 15f, 25f) },
                },
            });
            defs.Add(new ClipDef
            {
                Name = "Combat_Recovery", Length = 1f, Loop = false, FullSet = false,
                Fns = new Dictionary<string, Func<float, float>>
                {
                    { "Hips.y",   t => Seg(t, 0f, 1f, 0.9f, HipsY) },
                    { "Spine.rx", t => Seg(t, 0f, 1f, 12f, 0f) },
                    { "Spine.ry", t => Seg(t, 0f, 1f, 30f, 0f) },
                    { "ArmR.rx",  t => Seg(t, 0f, 1f, 30f, 0f) },
                    { "ArmL.rx",  t => Seg(t, 0f, 1f, 15f, 0f) },
                    { "LegL.rx",  t => Seg(t, 0f, 1f, -30f, 0f) },
                    { "LegR.rx",  t => Seg(t, 0f, 1f, 25f, 0f) },
                },
            });
            defs.Add(new ClipDef
            {
                // Held wind-up with a small tremble; loops while Charging.
                Name = "Combat_Charge", Length = 1f, Loop = true, FullSet = false,
                Fns = new Dictionary<string, Func<float, float>>
                {
                    { "Hips.y",   t => 0.9f + 0.006f * Sin(t, 3f) },
                    { "Spine.rx", t => -8f + 1.5f * Sin(t, 3f) },
                    { "Spine.ry", t => -20f },
                    { "ArmR.rx",  t => -110f + 3f * Sin(t, 3f) },
                    { "ArmL.rx",  t => -25f },
                    { "LegL.rx",  t => -20f },
                    { "LegR.rx",  t => 20f },
                },
            });

            var result = new Dictionary<string, AnimationClip>();
            foreach (var d in defs) result[d.Name] = WriteClip(d);
            return result;
        }

        static AnimationClip WriteClip(ClipDef d)
        {
            var path = ClipDir + "/" + d.Name + ".anim";
            var clip = AssetDatabase.LoadAssetAtPath<AnimationClip>(path);
            var isNew = clip == null;
            if (isNew)
            {
                clip = new AnimationClip { name = d.Name };
                AssetDatabase.CreateAsset(clip, path);
            }
            else
            {
                foreach (var b in AnimationUtility.GetCurveBindings(clip)) AnimationUtility.SetEditorCurve(clip, b, null);
                foreach (var b in AnimationUtility.GetObjectReferenceCurveBindings(clip)) AnimationUtility.SetObjectReferenceCurve(clip, b, null);
                AnimationUtility.SetAnimationEvents(clip, new AnimationEvent[0]);
                clip.ClearCurves();
            }

            clip.frameRate = 30f;
            foreach (var kv in Channels)
            {
                Func<float, float> fn;
                if (!d.Fns.TryGetValue(kv.Key, out fn))
                {
                    if (!d.FullSet) continue;
                    var rest = kv.Value.rest;
                    fn = t => rest;
                }
                var binding = EditorCurveBinding.FloatCurve(kv.Value.path, typeof(Transform), kv.Value.prop);
                AnimationUtility.SetEditorCurve(clip, binding, Sample(fn, d.Length, d.Loop));
            }

            var settings = AnimationUtility.GetAnimationClipSettings(clip);
            settings.loopTime = d.Loop;
            settings.loopBlend = false;
            settings.startTime = 0f;
            settings.stopTime = d.Length;
            AnimationUtility.SetAnimationClipSettings(clip, settings);
            clip.wrapMode = d.Loop ? WrapMode.Loop : WrapMode.Default;

            EditorUtility.SetDirty(clip);
            return clip;
        }

        /// <summary>Samples f(normalized t) at 30 fps into a Hermite curve with analytic-ish (finite-difference) tangents.</summary>
        static AnimationCurve Sample(Func<float, float> f, float length, bool loop)
        {
            var n = Mathf.Max(4, Mathf.CeilToInt(length * 30f));
            var keys = new Keyframe[n + 1];
            const float e = 0.002f;
            for (var i = 0; i <= n; i++)
            {
                var tn = (float)i / n;
                var a = loop ? tn - e : Mathf.Max(0f, tn - e);
                var b = loop ? tn + e : Mathf.Min(1f, tn + e);
                var slope = (f(b) - f(a)) / ((b - a) * length);
                keys[i] = new Keyframe(tn * length, f(tn), slope, slope);
            }
            return new AnimationCurve(keys);
        }

        // ------------------------------------------------------------------ controller

        static AnimatorController BuildController(Dictionary<string, AnimationClip> clips, float[] thr)
        {
            var ctrl = AssetDatabase.LoadAssetAtPath<AnimatorController>(ControllerPath);
            if (ctrl == null)
            {
                ctrl = AnimatorController.CreateAnimatorControllerAtPath(ControllerPath);
            }
            else
            {
                ctrl = ResetController(ctrl);
            }

            // Layers: exactly "Base" then "Combat".
            if (ctrl.layers.Length == 0)
            {
                ctrl.AddLayer("Base");
            }
            else
            {
                var l0 = ctrl.layers;
                l0[0].name = "Base";
                l0[0].stateMachine.name = "Base";
                ctrl.layers = l0;
            }
            ctrl.AddLayer("Combat");

            AddParameters(ctrl);

            var layers = ctrl.layers;
            layers[0].defaultWeight = 1f;
            layers[1].defaultWeight = 0f;
            layers[1].blendingMode = AnimatorLayerBlendingMode.Override;
            ctrl.layers = layers;

            BuildBaseLayer(ctrl, ctrl.layers[0].stateMachine, clips, thr);
            BuildCombatLayer(ctrl, ctrl.layers[1].stateMachine, clips);
            return ctrl;
        }

        /// <summary>Empties an existing controller in place so the asset file (and GUID) is kept.</summary>
        static AnimatorController ResetController(AnimatorController c)
        {
            try
            {
                for (var i = c.layers.Length - 1; i >= 0; i--) c.RemoveLayer(i);
            }
            catch (Exception e)
            {
                Debug.LogWarning("PlayerAnimationAssets: RemoveLayer failed (" + e.Message + ").");
            }

            if (c.layers.Length != 0)
            {
                // Could not clear in place: recreate. The GUID changes in this fallback only.
                Debug.LogWarning("PlayerAnimationAssets: recreating Player.controller (GUID will change).");
                AssetDatabase.DeleteAsset(ControllerPath);
                return AnimatorController.CreateAnimatorControllerAtPath(ControllerPath);
            }

            while (c.parameters.Length > 0) c.RemoveParameter(0);

            // Purge orphaned sub-assets (old states, transitions, blend trees) left behind by the removed layers.
            foreach (var o in AssetDatabase.LoadAllAssetsAtPath(ControllerPath))
            {
                if (o == null || o is AnimatorController) continue;
                Object.DestroyImmediate(o, true);
            }
            return c;
        }

        static void AddParameters(AnimatorController c)
        {
            AddParam(c, "Speed", AnimatorControllerParameterType.Float);
            AddParam(c, "Grounded", AnimatorControllerParameterType.Bool, defBool: true);
            AddParam(c, "VerticalVelocity", AnimatorControllerParameterType.Float);
            AddParam(c, "Dodging", AnimatorControllerParameterType.Bool);
            AddParam(c, "Jump", AnimatorControllerParameterType.Trigger);
            AddParam(c, "CombatPhase", AnimatorControllerParameterType.Int);
            AddParam(c, "CombatHit", AnimatorControllerParameterType.Int);
            AddParam(c, "Special", AnimatorControllerParameterType.Int);
            AddParam(c, "Charging", AnimatorControllerParameterType.Bool);
            AddParam(c, "SpeedMult", AnimatorControllerParameterType.Float, defFloat: 1f);
            AddParam(c, "CombatSpeed", AnimatorControllerParameterType.Float, defFloat: 1f); // addition to the contract
        }

        static void AddParam(AnimatorController c, string name, AnimatorControllerParameterType type, float defFloat = 0f, bool defBool = false)
        {
            c.AddParameter(new AnimatorControllerParameter { name = name, type = type, defaultFloat = defFloat, defaultBool = defBool, defaultInt = 0 });
        }

        static void BuildBaseLayer(AnimatorController ctrl, AnimatorStateMachine sm, Dictionary<string, AnimationClip> clips, float[] thr)
        {
            var loco = sm.AddState("Locomotion", new Vector3(300f, 0f, 0f));
            var tree = new BlendTree
            {
                name = "Locomotion",
                blendType = BlendTreeType.Simple1D,
                blendParameter = "Speed",
                useAutomaticThresholds = false,
            };
            AssetDatabase.AddObjectToAsset(tree, ctrl);
            tree.hideFlags = HideFlags.HideInHierarchy;
            tree.AddChild(clips["Idle"], thr[0]);
            tree.AddChild(clips["Walk"], thr[1]);
            tree.AddChild(clips["Run"], thr[2]);
            tree.AddChild(clips["Sprint"], thr[3]);
            loco.motion = tree;
            loco.speedParameterActive = true;
            loco.speedParameter = "SpeedMult";

            var jump = sm.AddState("JumpStart", new Vector3(600f, -120f, 0f));
            jump.motion = clips["JumpStart"];
            var fall = sm.AddState("Fall", new Vector3(600f, 0f, 0f));
            fall.motion = clips["Fall"];
            var land = sm.AddState("Land", new Vector3(600f, 120f, 0f));
            land.motion = clips["Land"];
            var dodge = sm.AddState("Dodge", new Vector3(300f, 160f, 0f));
            dodge.motion = clips["Dodge"];
            sm.defaultState = loco;

            // Locomotion -> JumpStart on the Jump trigger (listed before ->Fall so it wins on the takeoff frame).
            var t = Link(loco, jump, 0.05f);
            t.AddCondition(AnimatorConditionMode.If, 0f, "Jump");

            // Locomotion -> Fall when walking off a ledge (no Jump trigger).
            t = Link(loco, fall, 0.1f);
            t.AddCondition(AnimatorConditionMode.IfNot, 0f, "Grounded");

            // JumpStart -> Fall once airborne and no longer rising (exit time 0.9).
            t = Link(jump, fall, 0.1f, exitTime: 0.9f);
            t.AddCondition(AnimatorConditionMode.IfNot, 0f, "Grounded");
            t.AddCondition(AnimatorConditionMode.Less, 0.1f, "VerticalVelocity");

            // Safety: a hop that lands before the Fall condition is met must not stick in JumpStart (addition).
            t = Link(jump, land, 0.05f, exitTime: 0.9f);
            t.AddCondition(AnimatorConditionMode.If, 0f, "Grounded");

            // Fall -> Land when grounded.
            t = Link(fall, land, 0.05f);
            t.AddCondition(AnimatorConditionMode.If, 0f, "Grounded");

            // Land -> Locomotion at exit time 0.9.
            Link(land, loco, 0.1f, exitTime: 0.9f);

            // Any state (except Dodge itself) -> Dodge while Dodging.
            var any = sm.AddAnyStateTransition(dodge);
            any.hasExitTime = false;
            any.hasFixedDuration = true;
            any.duration = 0.05f;
            any.canTransitionToSelf = false;
            any.interruptionSource = TransitionInterruptionSource.None;
            any.AddCondition(AnimatorConditionMode.If, 0f, "Dodging");

            // Dodge -> Locomotion when no longer Dodging.
            t = Link(dodge, loco, 0.1f);
            t.AddCondition(AnimatorConditionMode.IfNot, 0f, "Dodging");
        }

        static void BuildCombatLayer(AnimatorController ctrl, AnimatorStateMachine sm, Dictionary<string, AnimationClip> clips)
        {
            var idle = sm.AddState("CombatIdle", new Vector3(300f, 0f, 0f)); // empty: no motion
            var startup = sm.AddState("Startup", new Vector3(600f, -120f, 0f));
            startup.motion = clips["Combat_Startup"];
            var active = sm.AddState("Active", new Vector3(600f, -40f, 0f));
            active.motion = clips["Combat_Active"];
            var recovery = sm.AddState("Recovery", new Vector3(600f, 40f, 0f));
            recovery.motion = clips["Combat_Recovery"];
            var charge = sm.AddState("Charge", new Vector3(600f, 120f, 0f));
            charge.motion = clips["Combat_Charge"];
            sm.defaultState = idle;

            foreach (var s in new[] { startup, active, recovery })
            {
                s.speedParameterActive = true;
                s.speedParameter = "CombatSpeed";
            }

            // Any-state transitions keyed on CombatPhase (0 idle, 1 startup, 2 active, 3 recovery) and Charging.
            // Order matters: Charge is listed first. Each excludes the other via the Charging condition.
            AnyTo(sm, charge, 0.06f).AddCondition(AnimatorConditionMode.If, 0f, "Charging");

            var tr = AnyTo(sm, startup, 0.03f);
            tr.AddCondition(AnimatorConditionMode.Equals, 1f, "CombatPhase");
            tr.AddCondition(AnimatorConditionMode.IfNot, 0f, "Charging");

            tr = AnyTo(sm, active, 0.03f);
            tr.AddCondition(AnimatorConditionMode.Equals, 2f, "CombatPhase");
            tr.AddCondition(AnimatorConditionMode.IfNot, 0f, "Charging");

            tr = AnyTo(sm, recovery, 0.03f);
            tr.AddCondition(AnimatorConditionMode.Equals, 3f, "CombatPhase");
            tr.AddCondition(AnimatorConditionMode.IfNot, 0f, "Charging");

            tr = AnyTo(sm, idle, 0.06f);
            tr.AddCondition(AnimatorConditionMode.Equals, 0f, "CombatPhase");
            tr.AddCondition(AnimatorConditionMode.IfNot, 0f, "Charging");
        }

        static AnimatorStateTransition Link(AnimatorState from, AnimatorState to, float duration, float exitTime = -1f)
        {
            var t = from.AddTransition(to);
            t.hasExitTime = exitTime >= 0f;
            if (exitTime >= 0f) t.exitTime = exitTime;
            t.hasFixedDuration = true;
            t.duration = duration;
            t.offset = 0f;
            t.interruptionSource = TransitionInterruptionSource.None;
            return t;
        }

        static AnimatorStateTransition AnyTo(AnimatorStateMachine sm, AnimatorState to, float duration)
        {
            var t = sm.AddAnyStateTransition(to);
            t.hasExitTime = false;
            t.hasFixedDuration = true;
            t.duration = duration;
            t.canTransitionToSelf = false;
            t.interruptionSource = TransitionInterruptionSource.None;
            return t;
        }

        // ------------------------------------------------------------------ verification

        static readonly string[] ContractParams =
        {
            "Speed:Float", "Grounded:Bool", "VerticalVelocity:Float", "Dodging:Bool", "Jump:Trigger",
            "CombatPhase:Int", "CombatHit:Int", "Special:Int", "Charging:Bool", "SpeedMult:Float",
        };
        static readonly string[] BaseStates = { "Locomotion", "JumpStart", "Fall", "Land", "Dodge" };
        static readonly string[] CombatStates = { "CombatIdle", "Startup", "Active", "Recovery", "Charge" };

        /// <summary>Checks the controller against the contract and that every clip curve path exists on the rig.</summary>
        public static bool Verify(AnimatorController c, out string report)
        {
            var sb = new StringBuilder();
            var ok = true;
            sb.AppendLine("PlayerAnimationAssets.Verify " + ControllerPath);

            if (c.layers.Length != 2) { ok = false; sb.AppendLine("FAIL layers.Length=" + c.layers.Length + " (expected 2)"); }
            else
            {
                sb.AppendLine("layers: " + c.layers[0].name + " (w=" + c.layers[0].defaultWeight + "), " + c.layers[1].name
                              + " (w=" + c.layers[1].defaultWeight + ", " + c.layers[1].blendingMode + ")");
                if (c.layers[0].name != "Base" || c.layers[1].name != "Combat") { ok = false; sb.AppendLine("FAIL layer names"); }
                ok &= CheckStates(c.layers[0].stateMachine, BaseStates, sb);
                ok &= CheckStates(c.layers[1].stateMachine, CombatStates, sb);

                foreach (var cs in c.layers[0].stateMachine.states)
                {
                    if (cs.state.name != "Locomotion") continue;
                    var bt = cs.state.motion as BlendTree;
                    if (bt == null) { ok = false; sb.AppendLine("FAIL Locomotion has no BlendTree"); break; }
                    sb.Append("Locomotion blend tree on '" + bt.blendParameter + "' thresholds:");
                    foreach (var ch in bt.children) sb.Append(" " + ch.threshold.ToString("0.###") + "(" + (ch.motion != null ? ch.motion.name : "null") + ")");
                    sb.AppendLine();
                    if (bt.blendParameter != "Speed" || bt.children.Length != 4) { ok = false; sb.AppendLine("FAIL blend tree param/children"); }
                }
            }

            var have = new Dictionary<string, AnimatorControllerParameterType>();
            foreach (var p in c.parameters) have[p.name] = p.type;
            foreach (var spec in ContractParams)
            {
                var parts = spec.Split(':');
                if (!have.TryGetValue(parts[0], out var type) || type.ToString() != parts[1])
                {
                    ok = false;
                    sb.AppendLine("FAIL parameter " + spec);
                }
            }
            sb.AppendLine("parameters (" + c.parameters.Length + "): " + string.Join(", ", Array.ConvertAll(c.parameters, p => p.name + ":" + p.type)));

            // Curve paths must resolve on a freshly built rig.
            var tmp = new GameObject("__verify_rig");
            try
            {
                BuildPlaceholderRig(tmp.transform);
                var guids = AssetDatabase.FindAssets("t:AnimationClip", new[] { ClipDir });
                sb.AppendLine("clips: " + guids.Length);
                foreach (var g in guids)
                {
                    var clip = AssetDatabase.LoadAssetAtPath<AnimationClip>(AssetDatabase.GUIDToAssetPath(g));
                    if (clip == null) continue;
                    var bad = 0;
                    foreach (var b in AnimationUtility.GetCurveBindings(clip))
                        if (tmp.transform.Find(b.path) == null) { bad++; sb.AppendLine("FAIL " + clip.name + " path not on rig: " + b.path); }
                    if (bad > 0) ok = false;
                    sb.AppendLine("  " + clip.name + " len=" + clip.length.ToString("0.###") + " loop=" + clip.isLooping + " curves=" + AnimationUtility.GetCurveBindings(clip).Length);
                }
            }
            finally { Object.DestroyImmediate(tmp); }

            sb.AppendLine(ok ? "VERIFY OK" : "VERIFY FAILED");
            report = sb.ToString();
            return ok;
        }

        static bool CheckStates(AnimatorStateMachine sm, string[] expected, StringBuilder sb)
        {
            var names = new HashSet<string>();
            foreach (var s in sm.states) names.Add(s.state.name);
            var ok = true;
            foreach (var n in expected)
                if (!names.Contains(n)) { ok = false; sb.AppendLine("FAIL missing state '" + n + "' in " + sm.name); }
            sb.AppendLine(sm.name + " states: " + string.Join(", ", names) + " | default=" + (sm.defaultState != null ? sm.defaultState.name : "none")
                          + " | any-state transitions=" + sm.anyStateTransitions.Length);
            return ok;
        }

        // ------------------------------------------------------------------ utils

        static void EnsureFolder(string parent, string name)
        {
            var full = parent + "/" + name;
            if (!AssetDatabase.IsValidFolder(full)) AssetDatabase.CreateFolder(parent, name);
        }
    }
}
