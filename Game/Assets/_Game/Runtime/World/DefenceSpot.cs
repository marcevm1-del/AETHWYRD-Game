using System.Collections.Generic;
using System.Linq;
using Ascend.Core;
using UnityEngine;

namespace Ascend.Game
{
    /// <summary>
    /// A place a quest asks you to defend (a "defend" objective whose target is this place, e.g. Millbrook's granary or
    /// the training yard's mock raid). Arrive with that quest active and the attack starts: its waves come in from the
    /// edge of the area toward the centre (Core SiegeBattle rules); clear them to complete the objective. If time runs
    /// out the attackers withdraw and you can try again.
    /// </summary>
    public sealed class DefenceSpot : MonoBehaviour
    {
        [SerializeField] string placeId;
        [SerializeField] float triggerRadius = 6f;
        [SerializeField] float spawnRadius = 14f;
        [SerializeField] float minutes = 4f;
        /// <summary>One entry per wave: "mon_goblin:4,mon_goblin_archer:1".</summary>
        [SerializeField] string[] waves = { "mon_goblin:4", "mon_goblin:4" };

        readonly List<MonsterDummy> _attackers = new List<MonsterDummy>();
        float _nextWaveAt = -1f, _cooldownUntil;

        public string PlaceId { get => placeId; set => placeId = value; }
        public string[] Waves { get => waves; set => waves = value; }
        public float TriggerRadius { get => triggerRadius; set => triggerRadius = value; }
        public float SpawnRadius { get => spawnRadius; set => spawnRadius = value; }
        public SiegeBattle Battle { get; private set; }
        public IReadOnlyList<MonsterDummy> Attackers => _attackers;

        SiegeWaveData Plan() => new SiegeWaveData
        {
            Id = "defence_" + placeId,
            TargetMinutes = new List<double> { minutes },
            Waves = waves.Select((w, i) => new SiegeWave
            {
                Wave = i + 1,
                Units = w.Split(',').Select(u => u.Trim().Split(':')).Where(p => p.Length == 2)
                         .Select(p => new SiegeUnit { SpeciesId = p[0], Count = int.Parse(p[1]) }).ToList(),
            }).ToList(),
        };

        bool Wanted(PlayerQuests q) => q.Log.Active.Any(p =>
        {
            var data = q.Log.Quest(p.QuestId);
            return data != null && data.Objectives.Select((o, i) => (o, i)).Any(x => x.o.Kind == "defend" && x.o.Target == placeId && p.Counts[x.i] < System.Math.Max(1, x.o.Count));
        });

        void Update()
        {
            var quests = FindFirstObjectByType<PlayerQuests>();
            if (quests == null) return;
            if (Battle == null)
            {
                if (Time.time < _cooldownUntil || !Wanted(quests)) return;
                Vector3 d = quests.transform.position - transform.position; d.y = 0;
                if (d.magnitude <= triggerRadius) Begin();
                return;
            }
            Battle.Tick(Time.deltaTime);
            foreach (var m in _attackers.ToList())
            {
                if (m == null) { _attackers.Remove(m); continue; }
                if (!m.IsDead) continue;
                _attackers.Remove(m);
                Destroy(MonsterSpawner.RootOf(m), 2f);
                if (Battle.UnitDefeated())
                {
                    if (Battle.IsLastWave) { Win(quests); return; }
                    _nextWaveAt = Time.time + 3f;
                }
            }
            if (_nextWaveAt > 0f && Time.time >= _nextWaveAt) { _nextWaveAt = -1f; SpawnWave(); }
            if (Battle != null && Battle.State == BattleState.TimedOut)
            {
                Toast("The attackers fall back. Try again when you're ready.");
                End(cooldown: 10f);
            }
        }

        public void Begin()
        {
            Battle = new SiegeBattle(Plan(), 0);
            Toast($"Defend {Pretty(placeId)}!");
            SpawnWave();
        }

        void SpawnWave()
        {
            var units = Battle.NextWave();
            if (Battle.State == BattleState.Repelled) return;
            int n = units.Sum(u => u.count), i = 0;
            foreach (var (speciesId, count) in units)
                for (int k = 0; k < count; k++, i++)
                {
                    float a = (i / (float)Mathf.Max(1, n)) * Mathf.PI * 2f;
                    var at = transform.position + new Vector3(Mathf.Cos(a), 0, Mathf.Sin(a)) * spawnRadius;
                    at.y = transform.position.y;
                    var m = MonsterSpawner.Spawn(MonsterSpawner.SceneTemplates, speciesId, at, transform.position);
                    if (m == null) { Battle.UnitDefeated(); continue; }
                    var ai = m.GetComponent<MonsterController>();
                    if (ai != null) ai.MarchTarget = transform.position;
                    _attackers.Add(m);
                }
        }

        void Win(PlayerQuests quests)
        {
            quests.Log.OnDefend(placeId, settlement: false);
            Toast($"{Pretty(placeId)} is safe!");
            End(cooldown: 0f);
        }

        void End(float cooldown)
        {
            foreach (var m in _attackers) if (m != null) Destroy(MonsterSpawner.RootOf(m));
            _attackers.Clear();
            Battle = null; _nextWaveAt = -1f;
            _cooldownUntil = Time.time + cooldown;
        }

        static string Pretty(string id) => id.Replace('_', ' ');

        static void Toast(string text)
        {
            var inv = FindFirstObjectByType<PlayerInventory>();
            if (inv != null) inv.Toast(text, 5f);
        }
    }
}
