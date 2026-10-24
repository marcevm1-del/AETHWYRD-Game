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
        /// <summary>Your adventurer rank and the road to the next one (ranks.md §2).</summary>
        public GuildRank Rank { get; private set; }

        /// <summary>The adventurer rank that gates things (taming, the inn tab): the guild rank when there is one, else the level band.</summary>
        public static RankLetter RankOf(Component player)
        {
            var q = player.GetComponent<PlayerQuests>();
            if (q != null && q.Rank != null) return q.Rank.Rank;
            var c = player.GetComponent<PlayerCombat>();
            return c != null ? c.Progress.RankBand : RankLetter.F;
        }

        /// <summary>Promotion specials this build can check (ranks.md §2): "life_skill" = learned a recipe from a teacher.</summary>
        public bool SpecialMet(string key)
        {
            if (key == "life_skill")
            {
                var crafting = GetComponent<PlayerCrafting>();
                return crafting != null && crafting.Crafter.Known.Any(id => crafting.Crafter.Recipe(id)?.LearnFrom != null);
            }
            return false;
        }

        public List<RankRequirement> RankRequirements() => Rank.Requirements(_combat.Progress.Level, SpecialMet, Log.Completed);
        public bool CanRankUp => Rank.CanPromote(_combat.Progress.Level, SpecialMet, Log.Completed);

        /// <summary>The rank-up ceremony at the Guild: new rank, the Rank Gift.</summary>
        public PromotionData RankUp()
        {
            var p = Rank.Promote(_combat.Progress.Level, SpecialMet, Log.Completed);
            if (p == null) return null;
            if (!string.IsNullOrEmpty(p.Gift)) _inv.Items.Add(p.Gift);
            _inv.Toast($"RANK UP: {p.From} → {p.To} ({Rank.Title}). Your card is now {Rank.Card}.", 8f);
            if (!string.IsNullOrEmpty(p.Gift) && AscendData.Db.Items.TryGetValue(p.Gift, out var gift)) _inv.Toast($"Rank Gift: {gift.Name}", 6f);
            return p;
        }
        public ICollection<string> Flags => _flags;
        public int Act => Log.Completed.Contains(PrologueQuest) ? 1 : 0;

        void Awake()
        {
            _combat = GetComponent<PlayerCombat>();
            _inv = GetComponent<PlayerInventory>();
            Rank = new GuildRank(AscendData.Db.GuildRanks);
            Log = new QuestLog(AscendData.Db.Quests, AscendData.Db.WeeklyQuests.Values.Select(w => w.ToQuest()));
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
            if (regionId != null && SiegeDirector.Instance != null && SiegeDirector.Instance.Governs(regionId)) state = SiegeDirector.Instance.Threat.State;
            else if (regionId != null && AscendData.Db.Regions.TryGetValue(regionId, out var r) && r.InitialState == "liberated") state = RegionState.Liberated;
            return new QuestContext
            {
                CompletedQuests = new HashSet<string>(Log.Completed),
                Flags = new HashSet<string>(_flags),
                Act = Act,
                Level = _combat.Progress.Level,
                Rank = Rank.Rank,
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

        /// <summary>Items an active quest still needs you to hand in (shops won't take them).</summary>
        public HashSet<string> ProtectedItems() => new HashSet<string>(Log.Active.SelectMany(p =>
            Log.Quest(p.QuestId).Objectives.Where(o => o.Kind == "collect").Select(o => o.Target)));

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
            int gp = Rank.QuestCompleted(Log.Quest(questId)?.Rank, pay.GuildPoints);
            if (gp > 0) _inv.Toast($"+{gp} GP");
            if (pay.Xp > 0) _combat.GrantXp(pay.Xp); // through the combat component so level-ups heal and show the banner
            var q = Log.Quest(questId);
            foreach (var f in q.SetsFlags ?? new List<string>()) _flags.Add(f);
            _inv.Toast($"Quest complete: {q.Title}", 5f);
            if (pay.Copper > 0) _inv.Toast($"+{Money.Format(pay.Copper, AscendData.Db.World.Currency)}");
            foreach (var item in pay.Items) _inv.Toast($"+ {(AscendData.Db.Items.TryGetValue(item, out var it) ? it.Name : item)}");
            if (q.Id.StartsWith("qst_wk_"))
            {
                // Board quests repeat: remember the day it was done, and let the journal offer it again later.
                Log.Forget(q.Id);
                _boardDone[q.Id] = WorldClock.Instance != null ? WorldClock.Instance.Day : 0;
            }
            return true;
        }

        // ---------------------------------------------------------------- the guild board
        readonly Dictionary<string, int> _boardDone = new Dictionary<string, int>();
        public IReadOnlyDictionary<string, int> BoardDone => _boardDone;

        public bool BoardDoneOn(string questId, int day) => _boardDone.TryGetValue(questId, out var d) && d == day;

        /// <summary>Board quests finished this in-game week (the special and the weekly don't come back until next week).</summary>
        public HashSet<string> BoardDoneThisWeek(int day)
        {
            int week = day / SiegeScheduler.DaysPerWeek;
            return new HashSet<string>(_boardDone.Where(kv => kv.Value / SiegeScheduler.DaysPerWeek == week).Select(kv => kv.Key));
        }

        public void LoadBoard(Dictionary<string, int> done)
        {
            _boardDone.Clear();
            foreach (var kv in done ?? new Dictionary<string, int>()) _boardDone[kv.Key] = kv.Value;
        }

        /// <summary>One line per active quest for the HUD tracker.</summary>
        public IEnumerable<string> TrackerLines()
        {
            foreach (var p in Log.Active)
            {
                var q = Log.Quest(p.QuestId);
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

        string Title(string questId) => Log.Quest(questId)?.Title ?? questId;
        string GiverName(string questId)
        {
            var q = Log.Quest(questId);
            if (q != null && q.Id.StartsWith("qst_wk_")) return "the guild board";
            return q != null && AscendData.Db.Npcs.TryGetValue(q.Giver, out var n) ? n.Name : "the giver";
        }

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
