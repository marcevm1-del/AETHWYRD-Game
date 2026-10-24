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
        public string DisplayName => GetComponent<QuestBoard>() != null ? "Adventurers' Guild Board"
            : AscendData.Db.Npcs.TryGetValue(npcId ?? "", out var n) ? n.Name : name;
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
            q.Log.Active.Where(p => p.Status == QuestStatus.ReadyToTurnIn && Mine(q, p)).ToList();

        /// <summary>This NPC's quest — or, for the guild board, any board quest (they're handed in at the board).</summary>
        bool Mine(PlayerQuests q, QuestProgress p)
        {
            var data = q.Log.Quest(p.QuestId);
            if (data == null) return false;
            bool board = data.Id.StartsWith("qst_wk_");
            return board ? GetComponent<QuestBoard>() != null : data.Giver == npcId;
        }

        /// <summary>Active quests from this giver whose only missing objectives are decisions (made here).</summary>
        public IEnumerable<QuestProgress> AwaitingChoiceHere(PlayerQuests q) =>
            q.Log.Active.Where(p => p.Status == QuestStatus.Active && Mine(q, p) && OnlyChoicesLeft(q.Log.Quest(p.QuestId), p)).ToList();

        public IEnumerable<QuestData> OffersHere(PlayerQuests q)
        {
            var ctx = q.Context();
            return q.Log.OffersFrom(npcId, ctx).Where(x => q.Log.CanAccept(x.Id, q.Context(x.Region))).ToList();
        }

        static bool OnlyChoicesLeft(QuestData q, QuestProgress p)
        {
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
}
