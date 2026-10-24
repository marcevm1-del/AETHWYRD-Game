using System.Collections.Generic;
using System.Linq;
using Ascend.Core;
using UnityEngine;

namespace Ascend.Game
{
    /// <summary>
    /// An NPC you can talk to (npcs.json). Talking counts for "talk" objectives, and the dialog lists what this NPC
    /// has for you: quests to hand in (with any decision the quest asks for), quests on offer, and goodbye.
    /// A marker floats over the head: "?" when a quest is ready to hand in, "!" when one is on offer.
    /// </summary>
    public sealed class QuestGiver : MonoBehaviour
    {
        public const float TalkRadius = 2.6f;

        [SerializeField] string npcId;
        TextMesh _marker;

        public string NpcId { get => npcId; set => npcId = value; }
        public string DisplayName => AscendData.Db.Npcs.TryGetValue(npcId ?? "", out var n) ? n.Name : name;
        public string Role => AscendData.Db.Npcs.TryGetValue(npcId ?? "", out var n) ? n.Role : "";

        public static QuestGiver Nearest(Vector3 from, float radius = TalkRadius)
        {
            QuestGiver best = null; float bestD = radius;
            foreach (var g in FindObjectsByType<QuestGiver>(FindObjectsSortMode.None))
            {
                Vector3 d = g.transform.position - from; d.y = 0;
                if (d.magnitude <= bestD) { best = g; bestD = d.magnitude; }
            }
            return best;
        }

        public void SetMarker(TextMesh marker) => _marker = marker;

        void Update()
        {
            if (_marker == null) return;
            var quests = FindFirstObjectByType<PlayerQuests>();
            string m = "";
            if (quests != null)
            {
                if (ReadyHere(quests).Any()) m = "?";
                else if (OffersHere(quests).Any()) m = "!";
            }
            if (_marker.text != m) _marker.text = m;
            var cam = Camera.main;
            if (cam != null) _marker.transform.rotation = Quaternion.LookRotation(_marker.transform.position - cam.transform.position);
        }

        public IEnumerable<QuestProgress> ReadyHere(PlayerQuests q) =>
            q.Log.Active.Where(p => p.Status == QuestStatus.ReadyToTurnIn && AscendData.Db.Quests[p.QuestId].Giver == npcId).ToList();

        /// <summary>Active quests from this giver whose only missing objectives are decisions (made here).</summary>
        public IEnumerable<QuestProgress> AwaitingChoiceHere(PlayerQuests q) =>
            q.Log.Active.Where(p => p.Status == QuestStatus.Active && AscendData.Db.Quests[p.QuestId].Giver == npcId && OnlyChoicesLeft(p)).ToList();

        public IEnumerable<QuestData> OffersHere(PlayerQuests q)
        {
            var ctx = q.Context();
            return q.Log.OffersFrom(npcId, ctx).Where(x => q.Log.CanAccept(x.Id, q.Context(x.Region))).ToList();
        }

        static bool OnlyChoicesLeft(QuestProgress p)
        {
            var q = AscendData.Db.Quests[p.QuestId];
            bool anyChoice = false;
            for (int i = 0; i < q.Objectives.Count; i++)
            {
                bool met = p.Counts[i] >= System.Math.Max(1, q.Objectives[i].Count);
                if (q.Objectives[i].Kind == "choice") { anyChoice |= !met; continue; }
                if (!met) return false;
            }
            return anyChoice;
        }
    }

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
