using System.Collections.Generic;
using System.Linq;
using Ascend.Core;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Ascend.Game
{
    /// <summary>
    /// Regional sieges in play (systems.md Regional Siege & Liberation; Core Siege.cs). The Tyrant's raids come 1–2 times
    /// a week, usually at dusk, announced the day before. A raid on the settlement you're near is fought live: waves march
    /// from the wood to the gate, clear them all to repel it (which counts for siege-defence quests). A raid you're not
    /// there for — or one that runs out its time — auto-resolves; nothing is ever destroyed. Escalation grows each week
    /// the Tyrant lives. F9 starts a raid now (playtest shortcut).
    /// </summary>
    public sealed class SiegeDirector : MonoBehaviour
    {
        [SerializeField] string regionId = "reg_whisperwood";
        [SerializeField] string liveSettlement = "Brindlewick";
        [SerializeField] Vector3 gate = new Vector3(0, 0, 21);
        [SerializeField] Vector3 muster = new Vector3(0, 0, 50);
        [SerializeField] float presentRadius = 60f;
        [SerializeField] ulong worldSeed = 7;
        [SerializeField] GameObject[] templates = new GameObject[0];

        RegionThreat _threat;
        SiegeScheduler _scheduler;
        readonly HashSet<int> _done = new HashSet<int>();
        readonly HashSet<int> _announced = new HashSet<int>();
        readonly List<MonsterDummy> _raiders = new List<MonsterDummy>();
        readonly Dictionary<string, SettlementProsperity> _prosperity = new Dictionary<string, SettlementProsperity>();
        int _lastWeek = -1;
        float _nextWaveAt = -1f;
        SiegeAttack _current;
        IRandom _rng;

        public static SiegeDirector Instance { get; private set; }
        public SiegeBattle Battle { get; private set; }
        public RegionThreat Threat => _threat;
        public IReadOnlyCollection<int> DoneDays => _done;
        public IReadOnlyList<MonsterDummy> Raiders => _raiders;
        public GameObject[] Templates { get => templates; set => templates = value; }
        public Vector3 Gate { get => gate; set => gate = value; }
        public Vector3 Muster { get => muster; set => muster = value; }

        RegionData Region => AscendData.Db.Regions[regionId];

        void Awake()
        {
            Instance = this;
            var region = Region;
            _threat = new RegionThreat(regionId, RegionThreat.Parse(region.InitialState), AscendData.Db.World.Siege);
            _scheduler = new SiegeScheduler(AscendData.Db.World.Siege, worldSeed);
            _rng = new DeterministicRandom(worldSeed + 99);
            foreach (var s in region.DefenceSettlements ?? new List<string>())
                _prosperity[s] = new SettlementProsperity(s, 60, 60, AscendData.Db.World.Siege.AutoResolve.ProsperityFloor);
        }

        PlayerCombat _player;

        void Start()
        {
            _player = FindFirstObjectByType<PlayerCombat>();
            if (_player != null) _player.Killed += OnKilled;
        }

        void OnDestroy()
        {
            if (Instance == this) Instance = null;
            if (_player != null) _player.Killed -= OnKilled;
        }

        /// <summary>The Tyrant falls: the region is Liberated for good — no more raids, hunting contracts open up.</summary>
        void OnKilled(MonsterDummy m)
        {
            if (m.SpeciesId != Region.TyrantSpeciesId || !_threat.UnderSiege) return;
            m.Respawns = false;
            _threat.TyrantSlain();
            if (Battle != null) { Toast("The raiders scatter!", 4f); EndBattle(); }
            Toast($"{Region.Name} is liberated! The raids are over.", 8f);
            foreach (var s in _prosperity.Values) s.Raise(5, 15);
        }

        /// <summary>Whether this director governs the region (quests ask it for the live siege state).</summary>
        public bool Governs(string region) => region == regionId;

        public SettlementProsperity ProsperityOf(string settlement) => _prosperity.TryGetValue(settlement, out var p) ? p : null;

        /// <summary>The next attack (today or later), for the HUD and the guild board.</summary>
        public SiegeAttack NextAttack()
        {
            var clock = WorldClock.Instance;
            if (clock == null) return null;
            int week = clock.Day / SiegeScheduler.DaysPerWeek;
            for (int w = week; w <= week + 1; w++)
                foreach (var a in _scheduler.AttacksInWeek(Region, w, _threat))
                    if (!_done.Contains(a.Day) && (a.Day > clock.Day || (a.Day == clock.Day))) return a;
            return null;
        }

        void Update()
        {
            if (Keyboard.current != null && Keyboard.current.f9Key.wasPressedThisFrame && Battle == null) StartRaidNow();
            var clock = WorldClock.Instance;
            if (clock != null) Schedule(clock);
            if (Battle != null) RunBattle();
        }

        void Schedule(WorldClock clock)
        {
            int week = clock.Day / SiegeScheduler.DaysPerWeek;
            if (_lastWeek >= 0 && week > _lastWeek) for (int w = _lastWeek; w < week; w++) _threat.OnWeekEnded();
            _lastWeek = week;
            if (Battle != null || !_threat.UnderSiege) return;
            foreach (var a in _scheduler.AttacksInWeek(Region, week, _threat))
            {
                if (_done.Contains(a.Day)) continue;
                if (clock.Day >= a.AnnouncedOnDay && clock.Day < a.Day && _announced.Add(a.Day))
                    Toast($"Rumour: goblins will raid {a.Settlement} tomorrow around {a.Hour:00}:00.", 6f);
                if (clock.Day > a.Day || (clock.Day == a.Day && clock.Hour >= a.Hour)) Begin(a);
            }
        }

        /// <summary>Playtest: a raid on the live settlement right now.</summary>
        public void StartRaidNow()
        {
            int day = WorldClock.Instance != null ? WorldClock.Instance.Day : 0;
            Begin(new SiegeAttack { RegionId = regionId, Day = day, Hour = WorldClock.Instance != null ? WorldClock.Instance.Hour : 18, Settlement = liveSettlement }, force: true);
        }

        void Begin(SiegeAttack a, bool force = false)
        {
            _done.Add(a.Day);
            var player = FindFirstObjectByType<PlayerDefense>();
            bool present = player != null && a.Settlement == liveSettlement && Vector3.Distance(Flat(player.transform.position), Flat(gate)) <= presentRadius;
            if (!present && !force) { AutoResolve(a, null); return; }
            _current = a;
            Battle = new SiegeBattle(AscendData.Db.SiegeWaves[regionId], _threat.EffectiveEscalation);
            Toast($"⚔ Goblin raid on {a.Settlement}! Hold the gate.", 6f);
            SpawnWave();
        }

        void RunBattle()
        {
            Battle.Tick(Time.deltaTime);
            foreach (var m in _raiders.ToList())
            {
                if (m == null) { _raiders.Remove(m); continue; }
                if (!m.IsDead) continue;
                _raiders.Remove(m);
                Destroy(RootOf(m), 2f);
                if (Battle.UnitDefeated())
                {
                    if (Battle.IsLastWave) { Finish(); return; }
                    Toast($"Wave {Battle.WaveIndex + 1} broken!", 3f);
                    _nextWaveAt = Time.time + 4f;
                }
            }
            if (_nextWaveAt > 0f && Time.time >= _nextWaveAt) { _nextWaveAt = -1f; SpawnWave(); }
            if (Battle.State == BattleState.TimedOut) { AutoResolve(_current, Battle); EndBattle(); }
        }

        void SpawnWave()
        {
            var units = Battle.NextWave();
            if (Battle.State == BattleState.Repelled) { Finish(); return; }
            Toast($"Wave {Battle.WaveIndex + 1} of {Battle.WaveCount}: {string.Join(", ", units.Select(u => $"{u.count} {Name(u.speciesId)}"))}", 5f);
            int i = 0, n = units.Sum(u => u.count);
            foreach (var (speciesId, count) in units)
                for (int k = 0; k < count; k++, i++)
                {
                    float spread = (i - (n - 1) / 2f) * 1.6f;
                    var at = muster + new Vector3(spread, 0, (i % 2) * 1.5f);
                    var m = Spawn(speciesId, at);
                    if (m == null) { Battle.UnitDefeated(); continue; }
                    m.Respawns = false;
                    var ai = m.GetComponent<MonsterController>();
                    if (ai != null) ai.MarchTarget = gate + new Vector3(spread * 0.5f, 0, 1.5f);
                    _raiders.Add(m);
                }
        }

        MonsterDummy Spawn(string speciesId, Vector3 at)
        {
            var template = templates.FirstOrDefault(t => t != null && SpeciesOf(t) == speciesId);
            GameObject go;
            if (template != null)
            {
                go = Instantiate(template, at, Quaternion.LookRotation(Flat(gate - at)));
                go.name = "Raider_" + speciesId;
                go.SetActive(true);
                return go.GetComponentInChildren<MonsterDummy>();
            }
            if (!AscendData.Db.Species.TryGetValue(speciesId, out var sp)) return null;
            // No model template: a labelled capsule sized from the species data.
            float size = sp.SizeMeters > 0 ? (float)sp.SizeMeters : 1f;
            var wrapper = new GameObject("Raider_" + speciesId);
            wrapper.transform.position = at;
            go = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            go.name = speciesId;
            go.transform.SetParent(wrapper.transform, true);
            go.transform.localScale = new Vector3(size * 0.45f, size * 0.5f, size * 0.45f);
            go.transform.SetPositionAndRotation(at + Vector3.up * size * 0.5f, Quaternion.LookRotation(Flat(gate - at)));
            go.SetActive(false);
            var body = go.AddComponent<MonsterDummy>(); body.SpeciesId = speciesId;
            go.AddComponent<MonsterController>();
            go.AddComponent<MonsterAnimator>();
            go.SetActive(true);
            return body;
        }

        void Finish()
        {
            Toast($"The raid on {_current.Settlement} is repelled!", 6f);
            var p = ProsperityOf(_current.Settlement);
            p?.Raise(2, 5);
            var quests = FindFirstObjectByType<PlayerQuests>();
            if (quests != null) quests.Log.OnDefend(_current.Settlement.ToLowerInvariant());
            EndBattle();
        }

        void AutoResolve(SiegeAttack a, SiegeBattle partial)
        {
            var p = ProsperityOf(a.Settlement);
            var d = new SettlementDefence { Safety = p?.Safety ?? 50, Guards = 4, NpcAdventurers = 2, Barricades = 2 };
            var t = AscendData.Db.World.Siege.AutoResolve;
            var r = partial != null ? partial.ResolveRemainder(d, t, _rng) : SiegeAutoResolve.Resolve(d, _threat.EffectiveEscalation, t, _rng);
            p?.Apply(r);
            string what = r.Outcome == SiegeOutcome.Repelled ? "repelled the raid" : r.Outcome == SiegeOutcome.CostlyVictory ? "held, at a cost" : "was breached (it will rebuild)";
            Toast($"{a.Settlement} {what}.", 6f);
        }

        void EndBattle()
        {
            foreach (var m in _raiders) if (m != null) Destroy(RootOf(m));
            _raiders.Clear();
            Battle = null; _current = null; _nextWaveAt = -1f;
        }

        public string StatusText()
        {
            if (Battle == null) return null;
            int left = (int)System.Math.Max(0, Battle.TimeLimitSec - Battle.Elapsed);
            return $"⚔ Raid on {_current.Settlement} — wave {Battle.WaveIndex + 1}/{Battle.WaveCount} · {Battle.Alive} left · {left / 60}:{left % 60:00}";
        }

        static string Name(string id) => AscendData.Db.Species.TryGetValue(id, out var s) ? s.Name + (s.Name.EndsWith("s") ? "" : "s") : id;
        static Vector3 Flat(Vector3 v) { v.y = 0; return v; }

        /// <summary>Raiders live under a "Raider_<species>" object with their label.</summary>
        static GameObject RootOf(MonsterDummy m) =>
            m.transform.parent != null && m.transform.parent.name.StartsWith("Raider_") ? m.transform.parent.gameObject : m.gameObject;

        static string SpeciesOf(GameObject template)
        {
            var body = template.GetComponentInChildren<MonsterDummy>(true);
            return body != null ? body.SpeciesId : null;
        }

        static void Toast(string text, float seconds)
        {
            var inv = FindFirstObjectByType<PlayerInventory>();
            if (inv != null) inv.Toast(text, seconds);
        }

        // ---------------------------------------------------------------- saves
        public void Load(RegionState state, int escalation, IEnumerable<int> doneDays, int lastWeek)
        {
            _threat.Restore(state, escalation);
            if (state == RegionState.Liberated) foreach (var m in FindObjectsByType<MonsterDummy>(FindObjectsSortMode.None)) if (m.SpeciesId == Region.TyrantSpeciesId) m.gameObject.SetActive(false); // slain for good
            _done.Clear();
            foreach (var d in doneDays ?? Enumerable.Empty<int>()) _done.Add(d);
            _lastWeek = lastWeek;
        }

        public int LastWeek => _lastWeek;
    }
}
