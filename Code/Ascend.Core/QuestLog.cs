using System;
using System.Collections.Generic;
using System.Linq;

namespace Ascend.Core
{
    public enum QuestStatus { Active, ReadyToTurnIn, Completed }

    /// <summary>One accepted quest and its progress on each objective (same order as QuestData.Objectives).</summary>
    public sealed class QuestProgress
    {
        public string QuestId { get; set; }
        public List<int> Counts { get; set; } = new List<int>();
        /// <summary>Choice objectives: the option picked (null = not yet decided).</summary>
        public Dictionary<int, string> Choices { get; set; } = new Dictionary<int, string>();
        public QuestStatus Status { get; set; }
    }

    /// <summary>What turning in a quest paid out.</summary>
    public struct QuestPayout
    {
        public long Copper;
        public int GuildPoints;
        public long Xp;
        public List<string> Items;
    }

    /// <summary>
    /// The player's quest journal (quests.md): accept from a giver, progress from events (kill, reach, talk, collect,
    /// defend, choice), turn in to the giver for the rewards. Objective kinds:
    ///   kill    — defeating the target species (count)        reach   — entering the target place (count = visits)
    ///   talk    — speaking to the target NPC                  collect — holding count of the target item at turn-in time
    ///   defend  — a defence event at the target completing     choice  — a decision; any option completes it
    /// Quest reward "gold" is in copper (world_tuning.json currency: prices are stored in copper).
    /// </summary>
    public sealed class QuestLog
    {
        readonly Dictionary<string, QuestProgress> _active = new Dictionary<string, QuestProgress>();
        readonly HashSet<string> _completed = new HashSet<string>();
        readonly Dictionary<string, QuestData> _quests;

        /// <param name="extra">More quests to track besides quests.json (the weekly board's, as journal quests).</param>
        public QuestLog(IReadOnlyDictionary<string, QuestData> quests, IEnumerable<QuestData> extra = null)
        {
            _quests = (quests ?? throw new ArgumentNullException(nameof(quests))).ToDictionary(kv => kv.Key, kv => kv.Value);
            foreach (var q in extra ?? Enumerable.Empty<QuestData>()) _quests[q.Id] = q;
        }

        public QuestData Quest(string id) => _quests.TryGetValue(id ?? "", out var q) ? q : null;

        /// <summary>Lets a repeatable (board) quest be taken again: forgets that it was completed.</summary>
        public void Forget(string questId) => _completed.Remove(questId);

        public IEnumerable<QuestProgress> Active => _active.Values;
        public ICollection<string> Completed => _completed;
        public int GuildPoints { get; private set; }
        public QuestProgress Get(string questId) => _active.TryGetValue(questId, out var p) ? p : null;
        public bool IsActive(string questId) => _active.ContainsKey(questId);

        /// <summary>Raised when an objective's count changes: (quest id, objective index).</summary>
        public event Action<string, int> Progressed;
        /// <summary>Raised when every objective of a quest is met (go back to the giver).</summary>
        public event Action<string> Ready;

        public bool CanAccept(string questId, QuestContext ctx) =>
            _quests.TryGetValue(questId, out var q) && !_active.ContainsKey(questId) && QuestGate.IsAvailable(q, Context(ctx));

        /// <summary>The quests a giver can offer right now.</summary>
        public IEnumerable<QuestData> OffersFrom(string npcId, QuestContext ctx) =>
            _quests.Values.Where(q => q.Giver == npcId && !q.Id.StartsWith("qst_wk_") && CanAccept(q.Id, ctx)).OrderBy(q => q.Rank).ThenBy(q => q.Id);

        public bool Accept(string questId, QuestContext ctx)
        {
            if (!CanAccept(questId, ctx)) return false;
            var q = _quests[questId];
            _active[questId] = new QuestProgress { QuestId = questId, Counts = q.Objectives.Select(_ => 0).ToList() };
            return true;
        }

        public void Abandon(string questId) => _active.Remove(questId);

        public void OnKill(string speciesId) => Advance("kill", speciesId, 1);
        public void OnReach(string placeId) => Advance("reach", placeId, 1);
        public void OnTalk(string npcId) => Advance("talk", npcId, 1);
        public void OnDefend(string placeId) => Advance("defend", placeId, 1);

        /// <summary>Collect objectives track what you hold, so selling or using the item lowers the count again.</summary>
        public void OnInventoryChanged(Inventory inv)
        {
            foreach (var p in _active.Values.ToList())
            {
                var q = _quests[p.QuestId];
                for (int i = 0; i < q.Objectives.Count; i++)
                {
                    var o = q.Objectives[i];
                    if (o.Kind != "collect") continue;
                    int have = Math.Min(Need(o), inv?.Count(o.Target) ?? 0);
                    if (have != p.Counts[i]) { p.Counts[i] = have; Progressed?.Invoke(p.QuestId, i); }
                }
                Recheck(p);
            }
        }

        /// <summary>Quest items a kill of this species drops: one each for active collect objectives still short.</summary>
        public List<string> QuestDrops(string speciesId, Inventory inv)
        {
            var drops = new List<string>();
            foreach (var p in _active.Values)
                foreach (var o in _quests[p.QuestId].Objectives)
                    if (o.Kind == "collect" && o.From == speciesId && (inv?.Count(o.Target) ?? 0) < Need(o) && !drops.Contains(o.Target))
                        drops.Add(o.Target);
            return drops;
        }

        public bool Choose(string questId, int objective, string option)
        {
            if (!_active.TryGetValue(questId, out var p)) return false;
            var q = _quests[questId];
            if (objective < 0 || objective >= q.Objectives.Count || q.Objectives[objective].Kind != "choice" || string.IsNullOrEmpty(option)) return false;
            p.Choices[objective] = option;
            p.Counts[objective] = 1;
            Progressed?.Invoke(questId, objective);
            Recheck(p);
            return true;
        }

        void Advance(string kind, string target, int amount)
        {
            if (string.IsNullOrEmpty(target)) return;
            foreach (var p in _active.Values.ToList())
            {
                if (p.Status != QuestStatus.Active) continue;
                var q = _quests[p.QuestId];
                for (int i = 0; i < q.Objectives.Count; i++)
                {
                    var o = q.Objectives[i];
                    // "{settlement}" (siege defences): any settlement of the quest's region counts.
                    bool matches = o.Target == target || (kind == "defend" && o.Target == "{settlement}");
                    if (o.Kind != kind || !matches || p.Counts[i] >= Need(o)) continue;
                    // Objectives run in order for talk/reach chains only when an earlier talk is unmet (go see A, then B).
                    if (kind == "talk" && EarlierTalkPending(q, p, i)) continue;
                    p.Counts[i] = Math.Min(Need(o), p.Counts[i] + amount);
                    Progressed?.Invoke(p.QuestId, i);
                }
                Recheck(p);
            }
        }

        static bool EarlierTalkPending(QuestData q, QuestProgress p, int i)
        {
            for (int j = 0; j < i; j++) if (q.Objectives[j].Kind == "talk" && p.Counts[j] < Need(q.Objectives[j])) return true;
            return false;
        }

        static int Need(QuestObjective o) => Math.Max(1, o.Count);

        void Recheck(QuestProgress p)
        {
            var q = _quests[p.QuestId];
            bool done = q.Objectives.Select((o, i) => p.Counts[i] >= Need(o)).All(x => x);
            var was = p.Status;
            p.Status = done ? QuestStatus.ReadyToTurnIn : QuestStatus.Active;
            if (done && was != QuestStatus.ReadyToTurnIn) Ready?.Invoke(p.QuestId);
        }

        /// <summary>Hands the quest in: collect items are taken, rewards paid into the inventory and progress.</summary>
        public bool TryTurnIn(string questId, Inventory inv, PlayerProgress progress, out QuestPayout payout)
        {
            payout = default;
            if (!_active.TryGetValue(questId, out var p) || p.Status != QuestStatus.ReadyToTurnIn) return false;
            var q = _quests[questId];
            foreach (var o in q.Objectives.Where(o => o.Kind == "collect"))
                if (inv == null || inv.Count(o.Target) < Need(o)) return false;
            foreach (var o in q.Objectives.Where(o => o.Kind == "collect")) inv.TryRemove(o.Target, Need(o));
            var r = q.Rewards ?? new QuestRewards();
            payout = new QuestPayout { Copper = r.Gold, GuildPoints = r.Gp, Xp = r.Xp, Items = (r.Items ?? new List<string>()).ToList() };
            inv?.AddCopper(r.Gold);
            foreach (var item in payout.Items) inv?.Add(item);
            progress?.AddXp(r.Xp);
            GuildPoints += r.Gp;
            _active.Remove(questId);
            _completed.Add(questId);
            return true;
        }

        QuestContext Context(QuestContext ctx)
        {
            ctx ??= new QuestContext();
            foreach (var c in _completed) if (!ctx.CompletedQuests.Contains(c)) ctx.CompletedQuests.Add(c);
            return ctx;
        }

        // ---------------------------------------------------------------- saves
        public List<QuestProgress> SaveActive() => _active.Values.Select(p => new QuestProgress
        {
            QuestId = p.QuestId, Counts = p.Counts.ToList(), Choices = new Dictionary<int, string>(p.Choices), Status = p.Status,
        }).ToList();

        public void Load(IEnumerable<QuestProgress> active, IEnumerable<string> completed, int guildPoints)
        {
            _active.Clear(); _completed.Clear();
            GuildPoints = Math.Max(0, guildPoints);
            foreach (var c in completed ?? Enumerable.Empty<string>()) if (_quests.ContainsKey(c)) _completed.Add(c);
            foreach (var p in active ?? Enumerable.Empty<QuestProgress>())
            {
                if (p == null || !_quests.TryGetValue(p.QuestId ?? "", out var q) || _completed.Contains(p.QuestId)) continue; // quests removed from data are dropped
                var counts = q.Objectives.Select((o, i) => p.Counts != null && i < p.Counts.Count ? Math.Max(0, Math.Min(Need(o), p.Counts[i])) : 0).ToList();
                var copy = new QuestProgress { QuestId = p.QuestId, Counts = counts, Choices = p.Choices ?? new Dictionary<int, string>() };
                _active[p.QuestId] = copy;
                Recheck(copy);
            }
        }
    }
}

namespace Ascend.Core
{
    /// <summary>
    /// Readable options for a choice objective's target: "spare_or_harvest_the_baby" → spare / harvest the baby;
    /// "slay_tame_or_parley" → slay / tame / parley; a target without "_or_" ("spare_the_goblin_child") is a yes/no:
    /// the action itself, or "refuse".
    /// </summary>
    public static class QuestChoices
    {
        public static System.Collections.Generic.List<string> Options(string target)
        {
            var list = new System.Collections.Generic.List<string>();
            if (string.IsNullOrEmpty(target)) return list;
            int at = target.LastIndexOf("_or_", System.StringComparison.Ordinal);
            if (at < 0) { list.Add(target.Replace('_', ' ')); list.Add("refuse"); return list; }
            foreach (var w in target.Substring(0, at).Split('_')) if (w.Length > 0) list.Add(w);
            list.Add(target.Substring(at + 4).Replace('_', ' '));
            return list;
        }
    }
}
