using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;
using UnityEngine.TestTools;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Ascend.Game.Tests
{
    /// <summary>
    /// The generated human body, with the generated locomotion clips retargeted onto it through Unity's Humanoid
    /// system. Until 2026-11-22 none of this had ever run in Unity: the clips existed as FBX and were checked in
    /// Blender, which says nothing about whether Unity can retarget them.
    ///
    /// Every assertion here is about the BODY MOVING, not about a state being active. That distinction is the
    /// point of the file. A character whose avatar failed to map stands in a T-pose while the Animator reports the
    /// correct clip at the correct time, so "the clip is playing" is not evidence of anything. What cannot pass by
    /// accident is a leg that rotates, hips that sit at the height the generator authored, and feet that reach the
    /// ground - those break together under a bad scale, a wrong axis, or a collapsed retarget.
    ///
    /// Clips are sampled through a PlayableGraph at an exact time rather than ticked, so a failure names a pose
    /// instead of a frame budget. SetTime is called twice on purpose: the first call leaves the playable's previous
    /// time behind it, and a single call samples the interpolation between the two.
    ///
    /// Import the assets first (they are staged FBX, not procedural):
    ///   python Tools/unity/stage_character_art.py
    ///   Unity -batchmode -projectPath Game -quit -executeMethod Ascend.EditorTools.CharacterAnimationImport.Run
    /// Run: Unity -batchmode -projectPath Game -runTests -testPlatform PlayMode -testFilter HumanoidLocomotion
    /// </summary>
    public sealed class HumanoidLocomotionPlayModeTests
    {
        const string BodyPath = "Assets/_Game/Art/Models/Characters/human_male_base.fbx";
        const string SidecarPath = "Assets/_Game/Art/Models/Characters/human_male_base.json";
        const string ClipDir = "Assets/_Game/Art/Animation/Humanoid";
        const string ManifestPath = ClipDir + "/locomotion_clips.json";

        /// <summary>The generator's own figure for how tall this variant stands, in metres.</summary>
        const float HeightToleranceM = 0.03f;

        GameObject _instance;
        Animator _animator;
        PlayableGraph _graph;
        AnimationClipPlayable _playable;

        // ---------------------------------------------------------------- fixtures

        [System.Serializable] sealed class Metrics
        {
            public float loopClosureM;
            public float hipsMinZ;
            public float hipsMaxZ;
            public float minFootZ;
        }

        [System.Serializable] sealed class Entry
        {
            public string name;
            public bool loop;
            public int fps;
            public int frames;
            public float seconds;
            public bool rootMotion;
            public Metrics metrics;
        }

        [System.Serializable] sealed class ManifestFile
        {
            public string rigContract;
            public List<Entry> clips = new List<Entry>();
        }

        [System.Serializable] sealed class Sidecar
        {
            public string id;
            public float heightM;
        }

        static string ReadProjectFile(string assetPath)
        {
            var full = Path.Combine(Path.GetDirectoryName(Application.dataPath) ?? ".", assetPath);
            return File.Exists(full) ? File.ReadAllText(full) : null;
        }

        static ManifestFile Manifest()
        {
            var text = ReadProjectFile(ManifestPath);
            Assert.IsNotNull(text, ManifestPath + " is not staged; run python Tools/unity/stage_character_art.py");
            var m = JsonUtility.FromJson<ManifestFile>(text);
            Assert.IsNotNull(m, ManifestPath + " did not parse");
            Assert.IsNotEmpty(m.clips, "the manifest lists no clips, so this suite would assert nothing");
            return m;
        }

        static Sidecar BodySpec()
        {
            var text = ReadProjectFile(SidecarPath);
            Assert.IsNotNull(text, SidecarPath + " is not staged; run python Tools/unity/stage_character_art.py");
            return JsonUtility.FromJson<Sidecar>(text);
        }

        static GameObject LoadBody()
        {
#if UNITY_EDITOR
            var go = AssetDatabase.LoadAssetAtPath<GameObject>(BodyPath);
            Assert.IsNotNull(go, BodyPath + " is not imported; run Ascend.EditorTools.CharacterAnimationImport.Run");
            return go;
#else
            Assert.Ignore("the character model is an Editor asset; this suite runs PlayMode inside the Editor");
            return null;
#endif
        }

        static AnimationClip LoadClip(string name)
        {
#if UNITY_EDITOR
            var path = ClipDir + "/" + name + ".fbx";
            var clip = AssetDatabase.LoadAllAssetsAtPath(path).OfType<AnimationClip>()
                                    .FirstOrDefault(c => !c.name.StartsWith("__preview__"));
            Assert.IsNotNull(clip, path + " holds no AnimationClip; run CharacterAnimationImport.Run");
            return clip;
#else
            return null;
#endif
        }

        /// <summary>
        /// The frame yield is load-bearing. A plain [SetUp] runs without one, and an Animator instantiated in the
        /// same synchronous breath has not initialised: GetBoneTransform already answers, because that comes off
        /// the avatar binding, but no pose is ever applied. Every clip then measured 0.0 degrees of thigh
        /// rotation - and three of the other tests in this file PASSED, because the rest T-pose happens to put the
        /// hips inside the authored height band, the toes on the ground and the hips over the origin. The
        /// movement test is the only reason that was caught, which is the argument for having it.
        /// </summary>
        [UnitySetUp]
        public System.Collections.IEnumerator SetUp()
        {
            _instance = Object.Instantiate(LoadBody());
            _instance.transform.position = Vector3.zero;
            _instance.transform.rotation = Quaternion.identity;
            _animator = _instance.GetComponent<Animator>();
            Assert.IsNotNull(_animator, "the imported body has no Animator, so nothing can drive it");
            _animator.applyRootMotion = false;   // the clips are in place; travel belongs to the controller
            _animator.cullingMode = AnimatorCullingMode.AlwaysAnimate;   // no camera in a batch-mode test
            yield return null;
        }

        [TearDown]
        public void TearDown()
        {
            if (_graph.IsValid()) _graph.Destroy();
            if (_instance != null) Object.Destroy(_instance);
        }

        /// <summary>
        /// Puts the body in the pose the clip holds at <paramref name="t"/> seconds.
        /// <paramref name="footIK"/> selects what is being measured: off is the raw retarget, on is what the game
        /// shows. They differ, and by how much is itself a finding - see the foot test.
        /// </summary>
        void SampleAt(AnimationClip clip, float t, bool footIK = true)
        {
            Begin(clip, footIK);
            At(t);
        }

        /// <summary>Opens a graph on one clip. Call At() for each pose; the graph is reused across samples.</summary>
        void Begin(AnimationClip clip, bool footIK = true)
        {
            if (_graph.IsValid()) _graph.Destroy();
            _graph = PlayableGraph.Create("humanoid-sample");
            _graph.SetTimeUpdateMode(DirectorUpdateMode.Manual);
            _playable = AnimationClipPlayable.Create(_graph, clip);
            _playable.SetApplyFootIK(footIK);
            var output = AnimationPlayableOutput.Create(_graph, "out", _animator);
            output.SetSourcePlayable(_playable);
        }

        void At(float t)
        {
            _playable.SetTime(t);
            _playable.SetTime(t);   // see the class comment: one call samples the interpolation, not the pose
            _graph.Evaluate(0f);
        }

        /// <summary>
        /// Every time the generator authored a frame at, so a Unity measurement compares against a Blender one
        /// over the same instants. Thirteen evenly spaced samples are not enough: Dodge is 21 frames at 50 fps,
        /// and a 13-sample grid missed its lowest pose and read the hips travelling 0.416 m against an authored
        /// 0.448 m - a 3 cm "regression" that was only the sampling.
        /// </summary>
        static IEnumerable<float> AuthoredFrames(Entry entry, AnimationClip clip)
        {
            var fps = entry.fps > 0 ? entry.fps : 30;
            var frames = entry.frames > 0 ? entry.frames : Mathf.RoundToInt(clip.length * fps);
            for (var i = 0; i <= frames; i++) yield return Mathf.Min(i / (float)fps, clip.length);
        }

        /// <summary>The lowest point either toe reaches over the clip, at every authored frame.</summary>
        float LowestToe(Entry entry, AnimationClip clip, bool footIK)
        {
            var lowest = float.MaxValue;
            Begin(clip, footIK);
            foreach (var t in AuthoredFrames(entry, clip))
            {
                At(t);
                lowest = Mathf.Min(lowest, Mathf.Min(Bone(HumanBodyBones.LeftToes).position.y,
                                                     Bone(HumanBodyBones.RightToes).position.y));
            }
            return lowest;
        }

        Transform Bone(HumanBodyBones bone)
        {
            var t = _animator.GetBoneTransform(bone);
            Assert.IsNotNull(t, bone + " is not bound on the avatar, so the retarget is incomplete");
            return t;
        }

        // ---------------------------------------------------------------- the avatar

        [Test]
        public void ImportedBody_HasAValidHumanAvatar()
        {
            var avatar = _animator.avatar;
            Assert.IsNotNull(avatar, "no avatar on the body, so no clip can retarget onto it");
            Assert.IsTrue(avatar.isValid, "the body's avatar is not valid");
            Assert.IsTrue(avatar.isHuman, "the body's avatar is not Human, so Humanoid clips will not apply");
            Assert.IsTrue(_animator.isHuman, "the Animator does not consider this a human rig");
        }

        [Test]
        public void ImportedBody_StandsAtTheAuthoredHeight()
        {
            var spec = BodySpec();
            var renderers = _instance.GetComponentsInChildren<SkinnedMeshRenderer>();
            Assert.IsNotEmpty(renderers, "the body imported with no skinned meshes");

            // The generator's heightM is measured on the _body mesh alone and validated to 1.5 cm
            // (ascend_characters/validate.py). Measuring every renderer instead reads 1.852 m against an authored
            // 1.780 m, because the hair stands 7 cm above the skull - a wrong measurement, not a wrong asset.
            var skin = renderers.FirstOrDefault(r => r.name.EndsWith("_body"));
            Assert.IsNotNull(skin, "no _body mesh among " + string.Join(", ", renderers.Select(r => r.name))
                             + ", so there is nothing to measure height on");

            // SkinnedMeshRenderer.bounds is a conservative, padded box, not the geometry: it reads 1.826 m for a
            // body the generator measures at 1.780 m. BakeMesh gives the actual deformed vertices, which is the
            // same thing Blender measured. Suspect the measurement before the asset.
            var baked = new Mesh();
            skin.BakeMesh(baked, true);
            var verts = baked.vertices;
            Assert.IsNotEmpty(verts, "the baked body mesh has no vertices");
            float lo = verts[0].y, hi = verts[0].y;
            foreach (var v in verts) { lo = Mathf.Min(lo, v.y); hi = Mathf.Max(hi, v.y); }
            Object.Destroy(baked);
            var bounds = new Bounds(new Vector3(0f, (lo + hi) * 0.5f, 0f), new Vector3(0f, hi - lo, 0f));

            Assert.AreEqual(spec.heightM, bounds.size.y, HeightToleranceM,
                "the body measures " + bounds.size.y.ToString("0.000") + " m in Unity but the generator authored "
                + spec.heightM.ToString("0.000") + " m. A factor near 100 or 0.01 means the FBX unit scale is wrong; "
                + "a height near the arm span means the axis fix did not apply.");
            Assert.AreEqual(0f, bounds.min.y, 0.08f,
                "the body's feet sit at y=" + bounds.min.y.ToString("0.000") + " instead of the ground");
        }

        // ---------------------------------------------------------------- the clips

        [Test]
        public void EveryManifestClip_ImportsAtTheAuthoredLengthAndLoopSetting()
        {
            foreach (var entry in Manifest().clips)
            {
                var clip = LoadClip(entry.name);
                Assert.AreEqual(entry.seconds, clip.length, 0.05f,
                    entry.name + " is " + clip.length.ToString("0.000") + " s in Unity but "
                    + entry.seconds.ToString("0.000") + " s in the manifest");
                Assert.AreEqual(entry.loop, clip.isLooping, entry.name + ": loop setting does not match the manifest");
                Assert.IsTrue(clip.humanMotion, entry.name + " is not human motion, so it will not retarget");
            }
        }

        [Test]
        public void Walk_RotatesTheLegsThroughItsCycle()
        {
            var clip = LoadClip("Walk");

            SampleAt(clip, 0f);
            var startThigh = Bone(HumanBodyBones.LeftUpperLeg).localRotation;
            var startKnee = Bone(HumanBodyBones.LeftLowerLeg).localRotation;

            // Measured across the whole cycle, not at one instant. At exactly a quarter of Walk the knee is near
            // as straight as it was at zero and turns only 3.6 degrees, so a single-sample threshold of 5 failed on
            // a clip that in fact bends the knee 23 degrees elsewhere. The leg's range is the claim; where in the
            // cycle it peaks is the generator's business.
            float thighSwing = 0f, kneeBend = 0f;
            for (var i = 1; i <= 12; i++)
            {
                SampleAt(clip, clip.length * i / 12f);
                thighSwing = Mathf.Max(thighSwing,
                                       Quaternion.Angle(startThigh, Bone(HumanBodyBones.LeftUpperLeg).localRotation));
                kneeBend = Mathf.Max(kneeBend,
                                     Quaternion.Angle(startKnee, Bone(HumanBodyBones.LeftLowerLeg).localRotation));
            }

            Assert.Greater(thighSwing, 8f,
                "the left thigh turned at most " + thighSwing.ToString("0.0") + " degrees anywhere in Walk. The clip "
                + "is playing but the body is not moving, which is what a failed retarget looks like.");
            Assert.Greater(kneeBend, 5f,
                "the left knee bent at most " + kneeBend.ToString("0.0") + " degrees anywhere in Walk");
        }

        [Test]
        public void EveryClip_MovesTheBodyAwayFromItsOpeningPose()
        {
            var moved = new List<string>();
            var still = new List<string>();

            foreach (var entry in Manifest().clips)
            {
                var clip = LoadClip(entry.name);
                SampleAt(clip, 0f);
                var opening = Bone(HumanBodyBones.Hips).position;
                var thigh = Bone(HumanBodyBones.LeftUpperLeg).localRotation;
                var arm = Bone(HumanBodyBones.RightUpperArm).localRotation;

                var most = 0f;
                for (var i = 1; i <= 8; i++)
                {
                    SampleAt(clip, clip.length * i / 8f);
                    most = Mathf.Max(most, Quaternion.Angle(thigh, Bone(HumanBodyBones.LeftUpperLeg).localRotation));
                    most = Mathf.Max(most, Quaternion.Angle(arm, Bone(HumanBodyBones.RightUpperArm).localRotation));
                    most = Mathf.Max(most, (Bone(HumanBodyBones.Hips).position - opening).magnitude * 100f);
                }
                // 0.5 and not something rounder: a pose that never reaches the body measures exactly 0.0, and Idle
                // - which is three seconds of breathing, one weight shift and a glance - measures 1.8. The gap
                // between "nothing arrived" and "the quietest clip we have" is where this line belongs.
                (most > 0.5f ? moved : still).Add(entry.name + " (" + most.ToString("0.0") + ")");
            }

            Assert.IsEmpty(still, "these clips never move the body away from their opening pose: "
                           + string.Join(", ", still) + ". Clips that do: " + string.Join(", ", moved));
        }

        [Test]
        public void EveryClip_HoldsTheHipsInTheHeightBandBlenderMeasured()
        {
            // The manifest records, per clip, the hips floor and ceiling the generator measured in Blender (Z up).
            // The band is not flat across the set - Idle holds 0.918 to 0.921 while LandHard drops to 0.555 - so
            // this is nine different numbers, not one.
            //
            // Two tolerances, because Humanoid retargeting guarantees two different things. How far the hips
            // TRAVEL comes across almost exactly: Sprint moves 0.222 m in Unity against 0.220 m in Blender. Where
            // they sit does not, and the error grows with knee bend: Idle matches, Run is 4 cm high, Walk 5.5 cm,
            // Sprint 6.2 cm, every one of them high and never low. That is Unity reconstructing hips height from
            // its own measure of leg length rather than replaying the authored position - the documented cost of
            // Humanoid over Generic, and the reason this project has a FootIK component at all. Ground contact is
            // not left to trust because of it: the foot test checks the toe against the manifest, with IK on.
            //
            // So range is held to 3 cm, which has teeth, and absolute height to 8 cm, which is the offset plus a
            // little. If the range ever drifts, the motion itself has changed.
            const float tol = 0.08f;
            const float rangeTol = 0.03f;
            var off = new List<string>();
            var ranges = new List<string>();

            foreach (var entry in Manifest().clips)
            {
                var clip = LoadClip(entry.name);
                var hips = Bone(HumanBodyBones.Hips);
                var low = float.MaxValue;
                var high = float.MinValue;
                for (var i = 0; i <= 12; i++)
                {
                    // Foot IK OFF here on purpose. This test asks whether the retarget reproduces the motion the
                    // generator authored, and foot IK is a correction applied on top of it: with IK on, Walk and
                    // Sprint read 5-6 cm high at both ends of the band, because IK lifts the body to keep a toe
                    // out of the floor. One test per question - the foot test below is the one that runs with IK.
                    SampleAt(clip, clip.length * i / 12f, footIK: false);
                    low = Mathf.Min(low, hips.position.y);
                    high = Mathf.Max(high, hips.position.y);
                }

                if (low < entry.metrics.hipsMinZ - tol || high > entry.metrics.hipsMaxZ + tol)
                    off.Add(entry.name + ": Unity " + low.ToString("0.000") + "-" + high.ToString("0.000")
                            + " m against Blender " + entry.metrics.hipsMinZ.ToString("0.000") + "-"
                            + entry.metrics.hipsMaxZ.ToString("0.000") + " m");

                var authored = entry.metrics.hipsMaxZ - entry.metrics.hipsMinZ;
                var got = high - low;
                if (Mathf.Abs(got - authored) > rangeTol)
                    ranges.Add(entry.name + ": the hips travel " + got.ToString("0.000") + " m in Unity but "
                               + authored.ToString("0.000") + " m in Blender");
            }

            Assert.IsEmpty(ranges, "the hips no longer travel as far as the generator authored, so the motion "
                           + "itself has changed, not just where it sits: " + string.Join("; ", ranges));
            Assert.IsEmpty(off, "the hips sit outside the height band the generator measured by more than the "
                           + "known retarget offset: " + string.Join("; ", off));
        }

        [Test]
        public void EveryClip_KeepsAFootNearTheGroundAndNoneBelowIt()
        {
            var off = new List<string>();
            var all = new List<string>();

            // Measured with Unity's foot IK on, because that is how the game plays a humanoid clip. With it OFF the
            // raw retarget pushes a toe through the floor on exactly the three deepest clips - Sprint -0.069 m,
            // LandHard -0.111 m, Dodge -0.101 m, whose hips drop to 0.660, 0.555 and 0.535 m - while Blender
            // measured no bone below 0.0036 m in any of them. So the dip is not in the authored motion: it is what
            // Humanoid retargeting does to a deep crouch, and foot IK is the part that answers for it. Worth
            // knowing, because anything that plays these clips without foot IK will show it.
            //
            // The expectation per clip is the manifest's own minFootZ, not one band for the set. A blanket "a foot
            // must come near the ground" is simply false for Fall, where Blender measured 0.1162 m because the
            // character is in the air - and it read as a failure on a clip doing exactly its job.
            const float tol = 0.08f;

            foreach (var entry in Manifest().clips)
            {
                var clip = LoadClip(entry.name);
                var lowest = LowestToe(entry, clip, footIK: true);
                all.Add(entry.name + " " + lowest.ToString("0.000") + " vs " + entry.metrics.minFootZ.ToString("0.000"));

                // The toe bone origin sits a little above the sole, and foot IK shifts it again, so the tolerance
                // is centimetres rather than millimetres. What it still rules out is a foot driven through the
                // floor, a character hovering, and a clip whose ground contact does not match what was authored.
                if (Mathf.Abs(lowest - entry.metrics.minFootZ) > tol)
                    off.Add(entry.name + ": Unity " + lowest.ToString("0.000") + " m, Blender "
                            + entry.metrics.minFootZ.ToString("0.000") + " m, raw "
                            + LowestToe(entry, clip, footIK: false).ToString("0.000") + " m");
            }

            Assert.IsEmpty(off, "the lowest toe does not match what the generator measured: " + string.Join("; ", off)
                           + ". All clips (Unity vs Blender): " + string.Join(", ", all));
        }

        [Test]
        public void InPlaceClips_DoNotDriftAcrossTheFloor()
        {
            var drifted = new List<string>();

            foreach (var entry in Manifest().clips)
            {
                if (entry.rootMotion) continue;   // nothing in this set has root motion, but do not assume it stays so
                var clip = LoadClip(entry.name);
                var worst = 0f;
                for (var i = 0; i <= 12; i++)
                {
                    SampleAt(clip, clip.length * i / 12f);
                    var p = Bone(HumanBodyBones.Hips).position;
                    worst = Mathf.Max(worst, new Vector2(p.x, p.z).magnitude);
                }

                // The generator authors these in place and the import bakes root position into the pose, so the
                // hips sway over the stance foot but go nowhere. A metre of travel in a 0.9 s walk means root
                // motion leaked in, and a character would then slide away from its own controller.
                if (worst > 0.25f) drifted.Add(entry.name + " (" + worst.ToString("0.00") + " m)");
            }

            Assert.IsEmpty(drifted, "these in-place clips travel across the floor: " + string.Join(", ", drifted)
                           + ". Root position should be baked into the pose, not left as root motion.");
        }

        // ---------------------------------------------------------------- the player's combat stand-in
        // NOT RUN: written without Unity. PlayerHumanoid.controller is generated by the scene build, so the test
        // is ignored (not failed) when it is absent, which is also what a clone without LFS looks like.

        [Test]
        public void CombatStandIn_SwingsTheSwordArmAndOnlyThroughHumanMotion()
        {
#if UNITY_EDITOR
            const string combatDir = "Assets/_Game/Art/Animation/Humanoid/Combat";
            var startup = AssetDatabase.LoadAssetAtPath<AnimationClip>(combatDir + "/Combat_Startup.anim");
            var active = AssetDatabase.LoadAssetAtPath<AnimationClip>(combatDir + "/Combat_Active.anim");
            if (startup == null || active == null)
                Assert.Ignore("Combat stand-in clips are generated by the scene build (PlayerAnimationAssets.BuildHumanoidController); not built here.");

            Assert.IsTrue(startup.humanMotion && active.humanMotion, "the combat stand-in must be human motion or it will not retarget");

            // Measured as bone movement, not as 'the state is Active': a stand-in that silently does nothing is the
            // failure this guards against.
            SampleAt(startup, 0f);
            var restArm = Bone(HumanBodyBones.RightUpperArm).localRotation;
            SampleAt(startup, startup.length);
            var windUpArm = Bone(HumanBodyBones.RightUpperArm).localRotation;
            SampleAt(active, active.length * 0.7f);
            var strikeArm = Bone(HumanBodyBones.RightUpperArm).localRotation;

            Assert.Greater(Quaternion.Angle(restArm, windUpArm), 20f, "the wind-up barely moves the sword arm");
            Assert.Greater(Quaternion.Angle(windUpArm, strikeArm), 20f, "the strike barely moves the sword arm from the wind-up");
#else
            Assert.Ignore("Editor-only asset test");
#endif
        }
    }
}
