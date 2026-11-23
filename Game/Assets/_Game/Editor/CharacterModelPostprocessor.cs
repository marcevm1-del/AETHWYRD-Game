// The generated human characters and their locomotion clips are the first Humanoid assets in this project -
// everything before them (buildings, the 680 monsters, the placeholder player rig) is Generic or has no rig at
// all. Humanoid is not a setting you can leave to the importer's defaults, for two reasons we have to hold:
//
//   1. A clip FBX is armature-only. If Unity builds an avatar FROM a clip file, it builds it from whatever pose
//      that file happens to hold on frame 0, not from the T-pose the body was authored in, and every clip then
//      retargets against a slightly different skeleton. Clips must COPY the body's avatar, never make their own.
//   2. An avatar that fails to map reads, in the scene, as a character standing in a T-pose while the Animator
//      cheerfully reports the right state. So the import is checked (CharacterAnimationImport) rather than
//      assumed, and the check is the thing that gates, not the absence of an error.
//
// This postprocessor is the floor: it keeps the rig settings correct through any re-import, including one a
// person triggers by touching the file. CharacterAnimationImport is the ordered, reported path - run that after
// staging new art, because on a fresh import the clips may be processed before the body's avatar exists.
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Ascend.EditorTools
{
    public sealed class CharacterModelPostprocessor : AssetPostprocessor
    {
        public const string CharacterDir = "Assets/_Game/Art/Models/Characters";
        public const string ClipDir = "Assets/_Game/Art/Animation/Humanoid";

        /// <summary>The body whose avatar every locomotion clip retargets through. Authored on by the generator.</summary>
        public const string SourceBodyId = "human_male_base";
        public static string SourceBodyPath => CharacterDir + "/" + SourceBodyId + ".fbx";

        const string ToonShader = "Ascend/Toon";

        /// <summary>
        /// While true, a clip re-import keeps whatever human mapping it already carries instead of clearing it.
        /// Only CharacterAnimationImport sets this, around the one pass that writes the body's mapping, and always
        /// restores it - an ad-hoc re-import by a person must get the clearing behaviour, which is the safe one.
        /// </summary>
        public static bool PreserveHumanDescription { get; set; }

        static string Norm(string p) => (p ?? string.Empty).Replace('\\', '/');

        public static bool IsCharacterPath(string path) => Norm(path).StartsWith(CharacterDir + "/");
        public static bool IsClipPath(string path) => Norm(path).StartsWith(ClipDir + "/");

        bool IsCharacter => IsCharacterPath(assetPath);
        bool IsClip => IsClipPath(assetPath);

        void OnPreprocessModel()
        {
            var importer = assetImporter as ModelImporter;
            if (importer == null) return;

            if (IsCharacter)
            {
                ApplyBodyRig(importer);
                return;
            }

            if (IsClip) ApplyClipRig(importer, assetPath);
        }

        /// <summary>The body owns the avatar: Humanoid, created from this model's own T-pose.</summary>
        public static void ApplyBodyRig(ModelImporter importer)
        {
            importer.animationType = ModelImporterAnimationType.Human;
            importer.avatarSetup = ModelImporterAvatarSetup.CreateFromThisModel;
            importer.importBlendShapes = true;   // the generator ships 19 facial expressions as shape keys
            importer.importAnimation = false;    // the body file carries no clips; the clip files do
            importer.optimizeGameObjects = false; // the tests and the springs need the bone transforms to exist
            importer.importNormals = ModelImporterNormals.Import;
        }

        /// <summary>
        /// A clip file is armature-only: 62 bones and nothing else. The body's hierarchy is the same 62 bones plus
        /// a root and twelve skinned meshes, so "Copy From Other Avatar" cannot be used - Unity rejects it with
        /// "Copied Avatar Rig Configuration mis-match. Transform hierarchy does not match" and then imports the
        /// file with ZERO takes, which looks exactly like an FBX that holds no animation. (It took reading the
        /// asset's hidden ImportLog to see that; the console says nothing.)
        ///
        /// Exporting the meshes into every clip would match the hierarchy and is what most pipelines do, but this
        /// project has 9 locomotion clips, 106 combat clips and 55 rider clips: at ~1.3 MB of body mesh each that
        /// is 220 MB of duplicated geometry. So each clip builds its OWN avatar, and
        /// CharacterAnimationImport.ApplyBodyMapping then overwrites its human mapping and bone rest poses with
        /// the body's, which is what makes the two avatars interchangeable. Auto-mapping alone is not trusted:
        /// Unity derives the rest pose from the file, and a walk file's pose is not a T-pose.
        /// </summary>
        public static void ApplyClipRig(ModelImporter importer, string path)
        {
            importer.animationType = ModelImporterAnimationType.Human;
            importer.avatarSetup = ModelImporterAvatarSetup.CreateFromThisModel;
            importer.importAnimation = true;
            importer.importBlendShapes = false;
            importer.optimizeGameObjects = false;

            // A HumanDescription persists in the .meta, so a mapping written against a different hierarchy keeps
            // failing every later import ("Parent for 'Hips' differs from one found in HumanDescription"). Clearing
            // both arrays makes Unity derive the skeleton and the mapping from THIS file, every time.
            //
            // CharacterAnimationImport turns this off for its own middle pass, where it deliberately writes the
            // body's mapping onto the file's own skeleton. Without that handshake the two fight: the tool assigns
            // the mapping, this clears it on the very reimport meant to apply it, and the mapping silently stays
            // whatever auto-map guessed - which on these clips varied with the pose, 54 bones or 55.
            if (PreserveHumanDescription) return;

            var hd = importer.humanDescription;
            hd.skeleton = new SkeletonBone[0];
            hd.human = new HumanBone[0];
            importer.humanDescription = hd;

            if (AssetDatabase.LoadAssetAtPath<Avatar>(SourceBodyPath) == null)
            {
                Debug.LogWarning("[char-anim] " + Path.GetFileName(path) + ": the body at " + SourceBodyPath
                                 + " is not imported yet, so this clip is auto-mapped and its rest pose comes from "
                                 + "the file rather than the body's T-pose. Run "
                                 + "Ascend.EditorTools.CharacterAnimationImport.Run to import in order.");
            }
        }

        /// <summary>
        /// Character colour lives in a vertex-colour attribute ("Col"), exactly as the monsters' does, and
        /// URP/Lit ignores it - which is how 378 monster materials shipped as grey plastic. AscendToon reads it.
        /// </summary>
        void OnPostprocessMaterial(Material material) => ApplyToon(material);

        void OnPreprocessMaterialDescription(UnityEditor.AssetImporters.MaterialDescription description,
                                             Material material, AnimationClip[] clips) => ApplyToon(material);

        void ApplyToon(Material material)
        {
            if (!IsCharacter || material == null) return;

            var shader = Shader.Find(ToonShader);
            if (shader == null)
            {
                Debug.LogWarning("[char-mat] shader '" + ToonShader + "' not found; " + assetPath
                                 + " keeps the importer default and its vertex colours will not render.");
                return;
            }

            material.shader = shader;
            if (material.HasProperty("_BaseColor")) material.SetColor("_BaseColor", Color.white);
            if (material.HasProperty("_Color")) material.SetColor("_Color", Color.white);
        }
    }
}
