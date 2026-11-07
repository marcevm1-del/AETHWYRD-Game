using UnityEngine;

namespace Ascend.EditorTools
{
    /// <summary>
    /// Wave A1 / T3: the animated placeholder visual for the player. Builds the "Visual" bone hierarchy
    /// (PlayerAnimationAssets.BuildPlaceholderRig) under the player root and puts an Animator with the Player
    /// controller on the root (Generic, no Avatar, no root motion; clip curve paths start at "Visual/...").
    /// Nothing is removed: the legacy "Body"/"Facing" primitives are handled by the caller (T2).
    /// </summary>
    public static partial class Ring0SceneBuilder
    {
        static void AttachPlayerVisual(GameObject player, Material body, Material accent)
        {
            PlayerAnimationAssets.BuildPlaceholderRig(player.transform, body, accent);
            var controller = PlayerAnimationAssets.BuildAll();

            var anim = player.GetComponent<Animator>();
            if (anim == null) anim = player.AddComponent<Animator>();
            anim.runtimeAnimatorController = controller;
            anim.avatar = null;
            anim.applyRootMotion = false;
            anim.cullingMode = AnimatorCullingMode.AlwaysAnimate;
            anim.updateMode = AnimatorUpdateMode.Normal;
        }
    }
}
