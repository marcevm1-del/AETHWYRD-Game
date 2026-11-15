using Ascend.Monsters;
using UnityEngine;

namespace Ascend.Game
{
    /// <summary>
    /// Light secondary motion for long hair and the cloak: one <see cref="SpringChain"/> (the monsters' spring, Code/Unity/Runtime)
    /// on each of the rig's extra chains (human_library.json rig: HairBack_1..3, HairSideL/R_1..2, CloakBack_1..3). No physics
    /// simulation and no colliders; about a dozen bones per character. Chains a body does not have are skipped.
    /// </summary>
    public sealed class HairMotion : MonoBehaviour
    {
        static readonly (string root, int length, float stiffness, float damping, float gravity)[] Chains =
        {
            ("HairBack_1", 3, 0.35f, 0.22f, 0.25f),
            ("HairSideL_1", 2, 0.45f, 0.25f, 0.15f),
            ("HairSideR_1", 2, 0.45f, 0.25f, 0.15f),
            ("CloakBack_1", 3, 0.30f, 0.20f, 0.35f),
        };

        public int Chained { get; private set; }

        public static HairMotion Ensure(GameObject visual)
        {
            var h = visual.GetComponent<HairMotion>();
            return h != null ? h : visual.AddComponent<HairMotion>();
        }

        void Start() => Bind();

        public void Bind()
        {
            Chained = 0;
            var all = GetComponentsInChildren<Transform>(true);
            foreach (var c in Chains)
            {
                Transform root = null;
                foreach (var t in all) if (t.name == c.root) { root = t; break; }
                if (root == null || root.GetComponent<SpringChain>() != null) continue;
                var s = root.gameObject.AddComponent<SpringChain>();
                s.rootBone = root; s.length = c.length; s.stiffness = c.stiffness; s.damping = c.damping; s.gravity = c.gravity;
                s.followAnimation = true;
                s.Init();
                Chained++;
            }
        }
    }
}
