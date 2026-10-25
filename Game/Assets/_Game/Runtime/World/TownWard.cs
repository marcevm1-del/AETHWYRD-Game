using System.Collections.Generic;
using UnityEngine;

namespace Ascend.Game
{
    /// <summary>
    /// A settlement's ward: a box on the ground (centred on this object) that the field's own monsters won't enter.
    /// They don't notice you inside it, and a chase breaks off when you step back in. Raids, ambushes and defence
    /// events bring monsters in on purpose (MonsterSpawner marks them), so sieges still reach the town.
    /// </summary>
    public sealed class TownWard : MonoBehaviour
    {
        static readonly List<TownWard> All = new List<TownWard>();

        [SerializeField] Vector2 size = new Vector2(76f, 93f);

        /// <summary>Width (x) and depth (z) in metres.</summary>
        public Vector2 Size { get => size; set => size = value; }

        void OnEnable() { if (!All.Contains(this)) All.Add(this); }
        void OnDisable() => All.Remove(this);

        public bool ContainsPoint(Vector3 p)
        {
            Vector3 c = transform.position;
            return Mathf.Abs(p.x - c.x) <= size.x / 2f && Mathf.Abs(p.z - c.z) <= size.y / 2f;
        }

        /// <summary>Whether any ward covers the point.</summary>
        public static bool Contains(Vector3 p)
        {
            for (int i = 0; i < All.Count; i++) if (All[i] != null && All[i].ContainsPoint(p)) return true;
            return false;
        }
    }
}
