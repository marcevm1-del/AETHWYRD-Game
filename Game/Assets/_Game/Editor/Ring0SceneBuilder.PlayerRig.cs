using UnityEditor;
using UnityEngine;

namespace Ascend.EditorTools
{
    /// <summary>
    /// The player's visual. Prefers the imported Humanoid body (human_male_base.fbx) with its locomotion clips and
    /// PlayerHumanoid.controller; falls back to the primitive placeholder (PlayerAnimationAssets.BuildPlaceholderRig +
    /// Player.controller, Generic, no Avatar) whenever any piece is missing, so a clone without Git LFS still builds.
    /// Either way: Animator on the player root, applyRootMotion off (travel and combat are code-driven), the legacy
    /// "Body"/"Facing" primitives are handled by the caller.
    /// </summary>
    public static partial class Ring0SceneBuilder
    {
        static void AttachPlayerVisual(GameObject player, Material body, Material accent)
        {
            var anim = player.GetComponent<Animator>();
            if (anim == null) anim = player.AddComponent<Animator>();

            if (TryAttachHumanoidVisual(player, anim, out var why))
            {
                anim.cullingMode = AnimatorCullingMode.AlwaysAnimate;
                anim.updateMode = AnimatorUpdateMode.Normal;
                return;
            }

            Debug.LogWarning("[player-rig] FALLING BACK to the primitive placeholder body: " + why);
            PlayerAnimationAssets.BuildPlaceholderRig(player.transform, body, accent);
            anim.runtimeAnimatorController = PlayerAnimationAssets.BuildAll();
            anim.avatar = null;
            anim.applyRootMotion = false;
            anim.cullingMode = AnimatorCullingMode.AlwaysAnimate;
            anim.updateMode = AnimatorUpdateMode.Normal;
        }

        /// <summary>
        /// Puts the Humanoid body under <paramref name="player"/> without leaving the scene half-built on failure:
        /// every check that can fail runs before anything is added to the player.
        /// </summary>
        static bool TryAttachHumanoidVisual(GameObject player, Animator anim, out string why)
        {
            // Import in order (body avatar first, then clips), checked, because on a fresh checkout Unity may
            // process a clip before the avatar it copies exists. Quiet when the art is simply not there (no LFS).
            if (!CharacterAnimationImport.EnsureImported(out why)) return false;

            var bodyPath = CharacterModelPostprocessor.SourceBodyPath;
            var model = AssetDatabase.LoadAssetAtPath<GameObject>(bodyPath);
            var avatar = AssetDatabase.LoadAssetAtPath<Avatar>(bodyPath);
            if (model == null) { why = bodyPath + " did not load as a model"; return false; }
            if (avatar == null || !avatar.isValid || !avatar.isHuman) { why = "the body's avatar is missing, invalid or not Human"; return false; }

            var controller = PlayerAnimationAssets.BuildHumanoidController(out why);
            if (controller == null) return false;

            // The model is a plain clone, not a prefab instance, so its children can be moved. They go straight under
            // the player: the avatar's bone paths are relative to the model root ("human_male_base_rig/Hips/..."),
            // and the Animator sits on the player root, so the children must be at the same depth for the Humanoid
            // binding to find them. The empty model root is then discarded. FootIK and PlayerAnimationDriver look for
            // the Animator on the player root, which is why it is not left on the model.
            var instance = Object.Instantiate(model);
            instance.name = "HumanoidBody";
            foreach (var strip in instance.GetComponentsInChildren<Animator>(true)) Object.DestroyImmediate(strip);
            while (instance.transform.childCount > 0)
            {
                var child = instance.transform.GetChild(0);
                child.SetParent(player.transform, false);
            }
            Object.DestroyImmediate(instance);

            // The imported body stands on y = 0 at 1.78 m; the CharacterController (height 1.8, centre 0.9) puts the
            // player's feet at y = 0 too, so no offset is applied. The placeholder rig, if present, is removed.
            var old = player.transform.Find("Visual");
            if (old != null) Object.DestroyImmediate(old.gameObject);

            anim.runtimeAnimatorController = controller;
            anim.avatar = avatar;
            anim.applyRootMotion = false;
            why = null;
            return true;
        }
    }
}
