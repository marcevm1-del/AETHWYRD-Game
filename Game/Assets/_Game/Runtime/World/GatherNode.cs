using System.Collections.Generic;
using System.Linq;
using Ascend.Core;
using UnityEngine;

namespace Ascend.Game
{
    /// <summary>
    /// A gathering node in the world (gathering.json): a herb patch, mushroom ring, weeping pine or scrap heap. Press E
    /// beside it to gather; it then regrows over in-game hours (its "Fresh" child hides meanwhile). Each node is
    /// saved by its object name.
    /// </summary>
    public sealed class GatherNode : MonoBehaviour
    {
        public const float Radius = 2.2f;
        static readonly List<GatherNode> _all = new List<GatherNode>();

        [SerializeField] string nodeId = "node_herb_patch";
        [SerializeField] GameObject fresh;

        GatherNodeState _state;
        IRandom _rng;

        public string NodeId { get => nodeId; set => nodeId = value; }
        public GameObject Fresh { get => fresh; set => fresh = value; }
        public GatherNodeData Data => AscendData.Db.GatherNodes.TryGetValue(nodeId ?? "", out var d) ? d : null;
        public string Key => name;
        public double ReadyAtHour { get => State.ReadyAtHour; set => State.ReadyAtHour = value; }
        GatherNodeState State => _state ??= new GatherNodeState(Data);

        public static IReadOnlyList<GatherNode> All => _all;

        void Awake() => _rng = new DeterministicRandom((ulong)Mathf.Abs(name.GetHashCode()) + 3);
        void OnEnable() { if (!_all.Contains(this)) _all.Add(this); }
        void OnDisable() => _all.Remove(this);

        /// <summary>Absolute in-game hour (day × 24 + hour).</summary>
        public static double Now => WorldClock.Instance != null ? WorldClock.Instance.PlaySeconds / WorldClock.Instance.Calendar.SecondsPerHour : Time.time / 225.0;

        public bool Ready => Data != null && State.Ready(Now);

        void Update()
        {
            if (fresh != null && fresh.activeSelf != Ready) fresh.SetActive(Ready);
        }

        public static GatherNode Nearest(Vector3 from, float radius = Radius)
        {
            GatherNode best = null; float bestD = radius;
            foreach (var n in _all)
            {
                if (n == null) continue;
                Vector3 d = n.transform.position - from; d.y = 0;
                if (d.magnitude <= bestD) { best = n; bestD = d.magnitude; }
            }
            return best;
        }

        /// <summary>Gathers into the inventory; returns what was found (empty while regrowing).</summary>
        public List<LootDrop> Gather(PlayerInventory inv)
        {
            if (Data == null) return new List<LootDrop>();
            if (!Ready)
            {
                double hours = State.ReadyAtHour - Now;
                inv.Toast($"The {Data.Name.ToLowerInvariant()} is regrowing ({Mathf.CeilToInt((float)hours)} h).");
                return new List<LootDrop>();
            }
            var drops = State.Gather(Now, inv.Items, _rng);
            inv.Toast($"{Data.Name}: " + string.Join(", ", drops.Select(d => $"+{d.Count} {(AscendData.Db.Items.TryGetValue(d.ItemId, out var it) ? it.Name : d.ItemId)}")), 4f);
            return drops;
        }
    }
}
