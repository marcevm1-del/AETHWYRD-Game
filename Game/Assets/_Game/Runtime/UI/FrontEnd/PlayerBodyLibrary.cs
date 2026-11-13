using System.Collections.Generic;
using Ascend.Core;
using UnityEngine;

namespace Ascend.Game
{
    /// <summary>
    /// Where a body prefab per <see cref="Body"/> plugs in later. <see cref="Get"/> returns a prefab (a body with a "Visual" rig the same
    /// way the placeholder has it) or null, in which case callers use <see cref="PlaceholderPlayerBody"/>. Lookup order: a prefab set with
    /// <see cref="Set"/> (tests, a future boot step), then <c>Resources/PlayerBodies/Masculine</c> or <c>/Feminine</c>. No ScriptableObject.
    /// </summary>
    public static class PlayerBodyLibrary
    {
        static readonly Dictionary<Body, GameObject> Overrides = new Dictionary<Body, GameObject>();

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        static void ResetStatics() => Overrides.Clear();

        public static string ResourcePath(Body body) => "PlayerBodies/" + body;

        public static GameObject Get(Body body)
        {
            if (Overrides.TryGetValue(body, out var p) && p != null) return p;
            return Resources.Load<GameObject>(ResourcePath(body));
        }

        /// <summary>Registers (or, with null, removes) a prefab for a body.</summary>
        public static void Set(Body body, GameObject prefab)
        {
            if (prefab == null) Overrides.Remove(body); else Overrides[body] = prefab;
        }
    }
}
