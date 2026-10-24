using System.Collections.Generic;
using System.Linq;
using Ascend.Core;
using UnityEngine;

namespace Ascend.Game
{
    /// <summary>
    /// The player's quest journal in play (Core QuestLog): kills, places, talks and the inventory drive progress; quest
    /// items drop from their species while the quest is active; story flags and the act come from turned-in quests
    /// (the prologue ends when "Status Granted" is handed in). Shown as the HUD tracker; givers are QuestGiver NPCs.
    /// </summary>
    [RequireComponent(typeof(PlayerCombat), typeof(PlayerInventory))]
    public sealed class PlayerQuests : MonoBehaviour
    {
        public const string PrologueQuest = "qst_main_status_granted";

        PlayerCombat _combat;
        PlayerInventory _inv;
        readonly HashSet<string> _flags = new HashSet<string>();

        public QuestLog Log { get; private set; }
        public ICollection<string> Flags => _flags;
        public int Act => Log.Completed.Contains(PrologueQuest) ? 1 : 0;

        void Awake()
        {
            _combat = GetComponent<PlayerCombat>();
            _inv = GetComponent<PlayerInventory>();
            Log = new QuestLog(AscendData.Db.Quests);
            _combat.Killed += OnKilled;
            _inv.Items.Changed += OnItemsChanged;
            Log.Ready += OnReady;
        }

        void OnDestroy()
        {
            if (_combat != null) _combat.Killed -= OnKilled;
            if (_inv != null) _inv.Items.Changed -= OnItemsChanged;
        }

        /// <summary>What quest gating knows about the player now.</summary>
        public QuestContext Context(string regionId = null)
        {
            var state = RegionState.Besieged;
            if (regionId != null && AscendData.Db.Regions.TryGetValue(regionId, out var r) && r.InitialState == "liberated") state = RegionState.Liberated;
            return new QuestContext
            {
                CompletedQuests = new HashSet<string>(Log.Completed),
                Flags = new HashSet<string>(_flags),
                Act = Act,
                Level = _combat.Progress.Level,
                RegionState = state,
            };
        }

        void OnKilled(MonsterDummy m)
        {
            foreach (var item in Log.QuestDrops(m.SpeciesId, _inv.Items))
            {
                _inv.Items.Add(item);
                string name = AscendData.Db.Items.TryGetValue(item, out var it) ? it.Name : item;
                _inv.Toast($"+ {name} (quest)");
            }
            Log.OnKill(m.SpeciesId);
        }

        void OnItemsChanged() => Log.OnInventoryChanged(_inv.Items);

        void OnReady(string questId) => _inv.Toast($"Quest ready: {Title(questId)} — return to {GiverName(questId)}", 5f);

        public void Reach(string placeId) => Log.OnReach(placeId);
        public void Talk(string npcId) => Log.OnTalk(npcId);

        public bool Accept(QuestData q)
        {
            if (!Log.Accept(q.Id, Context(q.Region))) return false;
            Log.OnInventoryChanged(_inv.Items); // collect objectives count what you already hold
            _inv.Toast($"Quest accepted: {q.Title}", 4f);
            return true;
        }

        public bool TurnIn(string questId)
        {
            if (!Log.TryTurnIn(questId, _inv.Items, null, out var pay)) return false;
            if (pay.Xp > 0) _combat.GrantXp(pay.Xp); // through the combat component so level-ups heal and show the banner
            var q = AscendData.Db.Quests[questId];
            foreach (var f in q.SetsFlags ?? new List<string>()) _flags.Add(f);
            _inv.Toast($"Quest complete: {q.Title}", 5f);
            if (pay.Copper > 0) _inv.Toast($"+{Money.Format(pay.Copper, AscendData.Db.World.Currency)}");
            foreach (var item in pay.Items) _inv.Toast($"+ {(AscendData.Db.Items.TryGetValue(item, out var it) ? it.Name : item)}");
            return true;
        }

        /// <summary>One line per active quest for the HUD tracker.</summary>
        public IEnumerable<string> TrackerLines()
        {
            foreach (var p in Log.Active)
            {
                var q = AscendData.Db.Quests[p.QuestId];
                if (p.Status == QuestStatus.ReadyToTurnIn) { yield return $"◆ {q.Title} — return to {GiverName(q.Id)}"; continue; }
                var parts = q.Objectives.Select((o, i) => Describe(o, p.Counts[i])).Where(s => s != null);
                yield return $"◇ {q.Title}: {string.Join(" · ", parts)}";
            }
        }

        static string Describe(QuestObjective o, int have)
        {
            int need = System.Math.Max(1, o.Count);
            string name;
            switch (o.Kind)
            {
                case "kill": name = AscendData.Db.Species.TryGetValue(o.Target, out var s) ? s.Name : o.Target; return $"{name} {have}/{need}";
                case "collect": name = AscendData.Db.Items.TryGetValue(o.Target, out var it) ? it.Name : o.Target; return $"{name} {have}/{need}";
                case "talk": name = AscendData.Db.Npcs.TryGetValue(o.Target, out var n) ? n.Name : o.Target; return have >= need ? null : $"talk to {name}";
                case "choice": return have >= need ? null : "decide at turn-in";
                default: return have >= need ? null : $"{o.Kind} {o.Target.Replace('_', ' ')}" + (need > 1 ? $" {have}/{need}" : "");
            }
        }

        static string Title(string questId) => AscendData.Db.Quests.TryGetValue(questId, out var q) ? q.Title : questId;
        static string GiverName(string questId) =>
            AscendData.Db.Quests.TryGetValue(questId, out var q) && AscendData.Db.Npcs.TryGetValue(q.Giver, out var n) ? n.Name : "the giver";

        // ---------------------------------------------------------------- saves
        public void Load(List<QuestProgress> active, List<string> completed, int guildPoints, List<string> flags)
        {
            Log.Load(active, completed, guildPoints);
            _flags.Clear();
            foreach (var f in flags ?? new List<string>()) _flags.Add(f);
            Log.OnInventoryChanged(_inv.Items);
        }
    }
}
