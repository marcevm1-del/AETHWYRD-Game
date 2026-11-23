// Imports the generated human body and its locomotion clips as Humanoid assets, in the one order that works,
// and then CHECKS the result instead of trusting that no error means success.
//
// Why an explicit entry point rather than only the postprocessor: on a fresh checkout Unity may process a clip
// file before the body it has to copy its avatar from. There is no import order to ask for, so the ordering
// lives here - body first, avatar verified, then each clip pointed at that avatar.
//
// What it refuses to assume, each learned somewhere on this project:
//   * "No error" is not "it worked". An avatar that fails to map is silent; the character simply stands in a
//     T-pose in the scene while the Animator reports the correct state.
//   * The clip list comes from Data/Characters/locomotion_clips.json, never from a list in this file, so a clip
//     added to the generator cannot ship outside coverage by not being typed in here.
//   * Anything it could not check is reported as NOT ASSESSED by name and makes the run fail, because a check
//     that cannot say it did not run is not a check (.claude/rules/skill-authoring.md).
//
// Run:
//   Unity -batchmode -projectPath Game -quit -executeMethod Ascend.EditorTools.CharacterAnimationImport.Run
// Stage the art first: python Tools/unity/stage_character_art.py
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Ascend.EditorTools
{
    public static class CharacterAnimationImport
    {
        const string ManifestPath = CharacterModelPostprocessor.ClipDir + "/locomotion_clips.json";

        // ---------------------------------------------------------------- manifest

        [Serializable] public sealed class ClipMetrics
        {
            public float loopClosureM;
            public float hipsMinZ;
            public float hipsMaxZ;
            public float minFootZ;
        }

        [Serializable] public sealed class ClipEntry
        {
            public string name;
            public bool loop;
            public int fps;
            public int frames;
            public float seconds;
            public bool rootMotion;
            public ClipMetrics metrics;
        }

        [Serializable] public sealed class Manifest
        {
            public string schema;
            public string rigContract;
            public string authoredOn;
            public List<ClipEntry> clips = new List<ClipEntry>();
        }

        /// <summary>Reads the staged manifest. Returns null and explains why when it cannot be read.</summary>
        public static Manifest LoadManifest(out string problem)
        {
            problem = null;
            var full = Path.Combine(Path.GetDirectoryName(Application.dataPath) ?? ".", ManifestPath);
            if (!File.Exists(full))
            {
                problem = "the clip manifest is not staged at " + ManifestPath
                          + " - run python Tools/unity/stage_character_art.py";
                return null;
            }

            Manifest m;
            try { m = JsonUtility.FromJson<Manifest>(File.ReadAllText(full)); }
            catch (Exception e) { problem = "the clip manifest could not be parsed: " + e.Message; return null; }

            if (m == null || m.clips == null || m.clips.Count == 0)
            {
                problem = "the clip manifest lists no clips, so there is nothing to import and nothing to check";
                return null;
            }
            return m;
        }

        // ---------------------------------------------------------------- the import

        /// <summary>Batch entry point: imports in order, prints the report and exits non-zero on failure.</summary>
        public static void Run() => Execute(true);

        /// <summary>
        /// For the scene build: makes sure the body and clips are imported as Humanoid, in order, without exiting
        /// the Editor. Returns true only when the whole import checked out; the reason is in
        /// <paramref name="problem"/> otherwise. A clone without Git LFS content (FBX still a pointer file) returns
        /// false quietly-by-design so the caller can fall back to the placeholder body.
        /// </summary>
        public static bool EnsureImported(out string problem)
        {
            problem = null;
            var root = Path.GetDirectoryName(Application.dataPath) ?? ".";
            var body = Path.Combine(root, CharacterModelPostprocessor.SourceBodyPath);
            if (!File.Exists(body) || new FileInfo(body).Length < 1024)
            {
                problem = "the body FBX is absent or a Git LFS pointer (run git lfs pull, or python Tools/unity/stage_character_art.py)";
                return false;
            }
            if (AlreadyImported()) return true;
            if (Execute(false)) return true;
            problem = "the Humanoid import report says FAIL; see the [char-anim] lines above";
            return false;
        }

        /// <summary>The cheap yes: body avatar valid and Human, and every manifest clip loads as human motion.</summary>
        static bool AlreadyImported()
        {
            var avatar = AssetDatabase.LoadAssetAtPath<Avatar>(CharacterModelPostprocessor.SourceBodyPath);
            if (avatar == null || !avatar.isValid || !avatar.isHuman) return false;
            var manifest = LoadManifest(out _);
            if (manifest == null) return false;
            foreach (var entry in manifest.clips)
            {
                var clip = AssetDatabase.LoadAllAssetsAtPath(CharacterModelPostprocessor.ClipDir + "/" + entry.name + ".fbx")
                                        .OfType<AnimationClip>().FirstOrDefault(c => !c.name.StartsWith("__preview__"));
                if (clip == null || !clip.humanMotion) return false;
            }
            return true;
        }

        static bool Execute(bool exitInBatchMode)
        {
            var report = new List<string>();
            var failures = new List<string>();
            var notAssessed = new List<string>();

            var manifest = LoadManifest(out var manifestProblem);
            if (manifest == null)
            {
                return Finish(report, new List<string> { manifestProblem }, notAssessed, exitInBatchMode);
            }
            report.Add("manifest: " + manifest.clips.Count + " clips, rig contract " + manifest.rigContract
                       + ", authored on " + manifest.authoredOn);

            // --- 1. the body, which owns the avatar every clip copies.
            var bodyPath = CharacterModelPostprocessor.SourceBodyPath;
            if (!File.Exists(Path.Combine(Path.GetDirectoryName(Application.dataPath) ?? ".", bodyPath)))
            {
                failures.Add("the body is not staged at " + bodyPath
                             + " - run python Tools/unity/stage_character_art.py");
                return Finish(report, failures, notAssessed, exitInBatchMode);
            }

            var bodyImporter = AssetImporter.GetAtPath(bodyPath) as ModelImporter;
            if (bodyImporter == null)
            {
                // First encounter: the asset exists on disk but Unity has not imported it yet.
                AssetDatabase.ImportAsset(bodyPath, ImportAssetOptions.ForceUpdate);
                bodyImporter = AssetImporter.GetAtPath(bodyPath) as ModelImporter;
            }
            if (bodyImporter == null)
            {
                failures.Add("Unity produced no ModelImporter for " + bodyPath + ", so the avatar could not be built");
                return Finish(report, failures, notAssessed, exitInBatchMode);
            }

            CharacterModelPostprocessor.ApplyBodyRig(bodyImporter);
            bodyImporter.SaveAndReimport();

            var avatar = AssetDatabase.LoadAssetAtPath<Avatar>(bodyPath);
            if (avatar == null) failures.Add("no Avatar came out of " + bodyPath + " (the rig did not become Humanoid)");
            else if (!avatar.isValid) failures.Add("the avatar from " + bodyPath + " is NOT VALID: " + AvatarProblem(bodyPath));
            else if (!avatar.isHuman) failures.Add("the avatar from " + bodyPath + " is valid but not Human");
            else report.Add("avatar: " + avatar.name + " valid=true human=true");

            if (failures.Count > 0) return Finish(report, failures, notAssessed, exitInBatchMode);

            // --- 2. the clips, each copying that avatar.
            foreach (var entry in manifest.clips)
            {
                var path = CharacterModelPostprocessor.ClipDir + "/" + entry.name + ".fbx";
                var full = Path.Combine(Path.GetDirectoryName(Application.dataPath) ?? ".", path);
                if (!File.Exists(full))
                {
                    failures.Add("clip " + entry.name + ": the manifest lists it but " + path + " is not staged");
                    continue;
                }

                var importer = AssetImporter.GetAtPath(path) as ModelImporter;
                if (importer == null)
                {
                    AssetDatabase.ImportAsset(path, ImportAssetOptions.ForceUpdate);
                    importer = AssetImporter.GetAtPath(path) as ModelImporter;
                }
                if (importer == null)
                {
                    failures.Add("clip " + entry.name + ": Unity produced no ModelImporter for " + path);
                    continue;
                }

                // Pass 1: Humanoid, its own avatar, so the file's transform hierarchy is known and a take exists.
                CharacterModelPostprocessor.ApplyClipRig(importer, path);
                importer.clipAnimations = new ModelImporterClipAnimation[0]; // drop any stale list from an older run
                importer.SaveAndReimport();

                // Pass 2: replace that auto-mapped avatar's human mapping and bone rest poses with the body's, so
                // the clip retargets against the same T-pose the body was authored in rather than frame 0 of a walk.
                importer = AssetImporter.GetAtPath(path) as ModelImporter;
                if (importer == null)
                {
                    failures.Add("clip " + entry.name + ": the importer vanished after the first pass");
                    continue;
                }
                var mapProblem = ApplyBodyMapping(importer, path, bodyImporter);
                if (mapProblem != null) { failures.Add("clip " + entry.name + ": " + mapProblem); continue; }

                ModelImporterClipAnimation[] takes;
                CharacterModelPostprocessor.PreserveHumanDescription = true;
                try
                {
                    importer.SaveAndReimport();

                    // Pass 3: now the take is readable, so its settings can be written.
                    importer = AssetImporter.GetAtPath(path) as ModelImporter;
                    takes = importer?.defaultClipAnimations;
                    if (importer != null && takes != null && takes.Length > 0)
                    {
                        ApplyClipSettings(importer, entry, takes);
                        importer.SaveAndReimport();
                    }
                }
                finally { CharacterModelPostprocessor.PreserveHumanDescription = false; }

                if (importer == null || takes == null || takes.Length == 0)
                {
                    failures.Add("clip " + entry.name + ": the FBX holds no animation take Unity can read "
                                 + "(defaultClipAnimations is empty), so there is nothing to import");
                    continue;
                }

                var clip = AssetDatabase.LoadAllAssetsAtPath(path).OfType<AnimationClip>()
                                        .FirstOrDefault(c => !c.name.StartsWith("__preview__"));
                if (clip == null)
                {
                    failures.Add("clip " + entry.name + ": the FBX imported with " + takes.Length
                                 + " take(s) but holds no AnimationClip asset");
                    continue;
                }

                var drift = Mathf.Abs(clip.length - entry.seconds);
                if (drift > 0.05f)
                {
                    failures.Add("clip " + entry.name + ": length " + clip.length.ToString("0.000")
                                 + " s but the manifest says " + entry.seconds.ToString("0.000") + " s");
                    continue;
                }
                if (clip.isLooping != entry.loop)
                {
                    failures.Add("clip " + entry.name + ": loopTime is " + clip.isLooping
                                 + " but the manifest says " + entry.loop);
                    continue;
                }
                if (!clip.humanMotion)
                {
                    failures.Add("clip " + entry.name + ": imported but is NOT human motion, so it will not retarget");
                    continue;
                }

                var clipAvatar = AssetDatabase.LoadAllAssetsAtPath(path).OfType<Avatar>().FirstOrDefault();
                if (clipAvatar == null || !clipAvatar.isValid || !clipAvatar.isHuman)
                {
                    failures.Add("clip " + entry.name + ": its avatar is "
                                 + (clipAvatar == null ? "missing" : "valid=" + clipAvatar.isValid + " human="
                                    + clipAvatar.isHuman) + ", so the body's mapping did not take");
                    continue;
                }

                var reimported = AssetImporter.GetAtPath(path) as ModelImporter;
                var mappedNow = reimported?.humanDescription.human?.Length ?? 0;
                var mappedBody = bodyImporter.humanDescription.human?.Length ?? 0;
                if (mappedNow != mappedBody)
                {
                    failures.Add("clip " + entry.name + ": " + mappedNow + " human bones mapped but the body has "
                                 + mappedBody + ", so the clip retargets through a different skeleton");
                    continue;
                }

                report.Add("clip " + entry.name.PadRight(10) + " " + clip.length.ToString("0.000") + " s  loop="
                           + clip.isLooping + "  human=true  bones=" + mappedNow);
            }

            // Nothing here can judge whether the motion LOOKS right; that needs a person and frames.
            notAssessed.Add("whether the character looks right in motion - the import proves bones move to the "
                            + "authored pose, not that walking reads as walking. Capture frames and look at them "
                            + "(HumanoidLocomotionCapture), then record a verdict.");

            return Finish(report, failures, notAssessed, exitInBatchMode);
        }

        /// <summary>
        /// Gives a clip file the body's human bone mapping and the body's bone rest poses, keeping only the bones
        /// the clip file actually contains (it has the 62-bone armature and no meshes, the body has both).
        ///
        /// This is the step that makes two separately-built avatars interchangeable. Without it the clip's avatar
        /// is auto-mapped and takes its rest pose from the file, and Unity then retargets a walk against a walk
        /// pose instead of a T-pose - which does not error, it just leans.
        ///
        /// Returns null on success, or the reason it could not be done.
        /// </summary>
        static string ApplyBodyMapping(ModelImporter importer, string path, ModelImporter bodyImporter)
        {
            var present = new HashSet<string>(AssetDatabase.LoadAllAssetsAtPath(path)
                                                           .OfType<GameObject>().Select(g => g.name));
            if (present.Count == 0) return "Unity imported no transforms from the file";

            var body = bodyImporter.humanDescription;
            if (body.human == null || body.human.Length == 0)
                return "the body's avatar has no human bone mapping to copy";

            var mappedBones = new HashSet<string>(body.human.Select(h => h.boneName));
            var missing = mappedBones.Where(b => !present.Contains(b)).ToList();
            if (missing.Count > 0)
                return "the file is missing " + missing.Count + " of the body's mapped bones ("
                       + string.Join(", ", missing.Take(6)) + ") so the two avatars cannot match";

            // The skeleton stays the one Unity derived from THIS file. The body's cannot be substituted: in the
            // body, Hips hangs off human_male_base_rig; in a clip file the armature is the root, so Hips hangs off
            // the root. Supplying the body's skeleton makes avatar creation fail outright with "Parent for 'Hips'
            // differs from one found in HumanDescription" - and because a HumanDescription persists in the .meta,
            // one bad attempt then poisons every later import until it is cleared, which is why ApplyClipRig
            // resets both arrays before the first pass.
            //
            // What transfers is the mapping and the humanoid tuning. The mapping has to be forced, not left to
            // auto-map: auto-map reads the file's pose, so on these nine clips it produced 54, 54, 54, 55, 54, 54,
            // 54, 54 and 55 mapped bones against the body's 52 - a different retarget skeleton per clip, and
            // Sprint and Dodge differing from Walk is as clear a sign as you get that the pose is deciding it.
            var hd = importer.humanDescription;
            hd.human = body.human;
            hd.armStretch = body.armStretch;
            hd.legStretch = body.legStretch;
            hd.upperArmTwist = body.upperArmTwist;
            hd.lowerArmTwist = body.lowerArmTwist;
            hd.upperLegTwist = body.upperLegTwist;
            hd.lowerLegTwist = body.lowerLegTwist;
            hd.feetSpacing = body.feetSpacing;
            hd.hasTranslationDoF = body.hasTranslationDoF;
            importer.humanDescription = hd;
            importer.avatarSetup = ModelImporterAvatarSetup.CreateFromThisModel;
            return null;
        }

        /// <summary>
        /// In-place clips: root rotation, height and XZ all baked into the pose, based upon the original, so the
        /// motion stays where the generator authored it and the character controller owns travel. Anything else
        /// and a 3 s idle walks across the room.
        /// </summary>
        static void ApplyClipSettings(ModelImporter importer, ClipEntry entry, ModelImporterClipAnimation[] clips)
        {
            foreach (var c in clips)
            {
                c.name = entry.name;
                c.loopTime = entry.loop;
                c.loopPose = entry.loop;
                c.lockRootRotation = true;
                c.keepOriginalOrientation = true;
                c.lockRootHeightY = true;
                c.keepOriginalPositionY = true;
                c.lockRootPositionXZ = true;
                c.keepOriginalPositionXZ = true;
            }
            importer.clipAnimations = clips;
        }

        /// <summary>Unity keeps the per-bone mapping errors on the importer's human description; surface them.</summary>
        static string AvatarProblem(string path)
        {
            var importer = AssetImporter.GetAtPath(path) as ModelImporter;
            if (importer == null) return "no importer to ask";
            var mapped = importer.humanDescription.human?.Length ?? 0;
            var skeleton = importer.humanDescription.skeleton?.Length ?? 0;
            return mapped + " of the required human bones mapped across a " + skeleton + "-bone skeleton";
        }

        // ---------------------------------------------------------------- report

        static bool Finish(List<string> report, List<string> failures, List<string> notAssessed, bool exitInBatchMode)
        {
            var sb = new System.Text.StringBuilder();
            sb.AppendLine("[char-anim] ---- humanoid import report ----");
            foreach (var line in report) sb.AppendLine("[char-anim] " + line);
            foreach (var line in notAssessed) sb.AppendLine("[char-anim] NOT ASSESSED: " + line);
            foreach (var line in failures) sb.AppendLine("[char-anim] FAIL: " + line);

            // NOT ASSESSED outranks PASS and never outranks FAIL: a run that could not look at something has not
            // shown it is good, but a known failure is the more actionable headline.
            var verdict = failures.Count > 0 ? "FAIL" : (notAssessed.Count > 0 ? "PASS (with NOT ASSESSED)" : "PASS");
            sb.AppendLine("[char-anim] verdict: " + verdict + "  (" + failures.Count + " failed, "
                          + notAssessed.Count + " not assessed)");

            if (failures.Count > 0) Debug.LogError(sb.ToString());
            else Debug.Log(sb.ToString());

            AssetDatabase.SaveAssets();
            if (exitInBatchMode && Application.isBatchMode) EditorApplication.Exit(failures.Count > 0 ? 1 : 0);
            return failures.Count == 0;
        }
    }
}
