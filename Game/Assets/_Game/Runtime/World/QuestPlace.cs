using UnityEngine;

namespace Ascend.Game
{
    /// <summary>A named place for "reach" objectives (quests.json targets such as brindlewick_north_gate).</summary>
    public sealed class QuestPlace : MonoBehaviour
    {
        [SerializeField] string placeId;
        [SerializeField] float radius = 4f;
        bool _inside;

        public string PlaceId { get => placeId; set => placeId = value; }
        public float Radius { get => radius; set => radius = value; }

        void Update()
        {
            var q = FindFirstObjectByType<PlayerQuests>();
            if (q == null) return;
            Vector3 d = q.transform.position - transform.position; d.y = 0;
            bool inside = d.magnitude <= radius;
            if (inside && !_inside) q.Reach(placeId); // counts once per visit
            _inside = inside;
        }
    }
}
