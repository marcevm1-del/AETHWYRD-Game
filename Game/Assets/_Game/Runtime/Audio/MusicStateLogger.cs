using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Ascend.Core;
using UnityEngine;

namespace Ascend.Game
{
    /// <summary>
    /// Drives the Core adaptive-music state machine (AdaptiveMusic.cs, Data/Audio/music_states.json) from game signals and keeps a
    /// ring buffer of the last 30 state-change lines. It plays NO audio: the audio designer's player will read <see cref="LastFrame"/>
    /// (state event, layer gains, stingers) later. Signals are sampled four times a second from the scene: monsters that are engaged
    /// (combat / elite), a boss fighting you (boss, with its phase), a hostile that has noticed you but is still far (uncertainty),
    /// a town ward under your feet (town), the day part and your HP (danger overlay). Tests and cutscenes can bypass the scene scan
    /// with <see cref="SignalSource"/> or call <see cref="Tick"/> directly.
    /// </summary>
    public sealed class MusicStateLogger : MonoBehaviour
    {
        public const int Capacity = 30;
        public const float PollSeconds = 0.25f;
        public const float EngageRadius = 25f, AlertRadius = 40f, BossRadius = 30f;

        readonly List<string> _log = new List<string>(Capacity);
        readonly List<MonsterDummy> _engaged = new List<MonsterDummy>();
        readonly List<MonsterDummy> _prevEngaged = new List<MonsterDummy>();
        MusicMachine _machine;
        readonly MusicInput _own = new MusicInput();
        MusicInput _inputOverride;
        MusicInput _input { get => _inputOverride ?? _own; set => _inputOverride = value; }
        PlayerDefense _defense;
        double _elapsed;
        float _pollLeft;
        bool _wasInCombat;

        /// <summary>Oldest first, at most <see cref="Capacity"/> lines, e.g. "[03:12.4] explore -> combat (escalate, fade 1.5s) layers=bed,pulse".</summary>
        public IReadOnlyList<string> Log => _log;
        /// <summary>False when the music data is missing or invalid; everything else then does nothing.</summary>
        public bool Ready => _machine != null;
        public string LastError { get; private set; }
        public string CurrentState => _machine != null ? _machine.CurrentState : "explore";
        public MusicFrame LastFrame { get; private set; }
        public MusicInput LastInput => _input;
        public MusicPrefs Prefs => _machine?.Prefs;
        /// <summary>Number of state changes logged since start (not capped at 30).</summary>
        public int Transitions { get; private set; }
        /// <summary>When set and it returns non-null, replaces the scene scan (cutscenes, tests, a future scene director).</summary>
        public Func<MusicInput> SignalSource { get; set; }
        /// <summary>Raised with the new log line on every state change.</summary>
        public event Action<string> StateChanged;

        void Awake()
        {
            _defense = GetComponent<PlayerDefense>();
            if (_machine == null) Configure(AscendData.Music, AscendData.Companions.Select(c => c.Id));
        }

        /// <summary>Builds the machine from data. Returns false (and sets <see cref="LastError"/>) when the data is missing or invalid.</summary>
        public bool Configure(MusicFile file, IEnumerable<string> rosterIds, MusicPrefs prefs = null)
        {
            _machine = null; LastError = null;
            _log.Clear(); Transitions = 0; _elapsed = 0; LastFrame = null; _wasInCombat = false; _engaged.Clear(); _prevEngaged.Clear();
            if (file == null) { LastError = "no music data"; return false; }
            try { _machine = new MusicMachine(file, rosterIds, prefs); return true; }
            catch (Exception e) { LastError = e.Message; Debug.LogWarning($"Adaptive music not started: {e.Message}"); return false; }
        }

        /// <summary>Copies the music options of the accessibility settings (no combat music, reduced intensity) onto the machine.</summary>
        public void ApplyAccessibility(AccessibilitySettings a)
        {
            if (_machine == null || a == null) return;
            _machine.Prefs.NoCombatMusic = a.NoCombatMusic;
            _machine.Prefs.ReducedIntensity = a.ReducedMusicIntensity;
        }

        void Update()
        {
            if (_machine == null) return;
            float dt = Time.deltaTime;
            _pollLeft -= dt;
            if (_pollLeft <= 0f) { Sample(); _pollLeft = PollSeconds; }
            Tick(dt, _input);
            if (ReferenceEquals(_input, _own)) _input.Outcome = CombatOutcome.None; // a victory or retreat is announced for one tick only (never touch an external input)
        }

        /// <summary>Advances the machine by dt seconds with these signals, logs a state change, returns the frame (null when not Ready).</summary>
        public MusicFrame Tick(double dt, MusicInput input)
        {
            if (_machine == null || input == null) return null;
            if (!(dt > 0) || double.IsInfinity(dt)) dt = 0;
            _elapsed += dt;
            var frame = _machine.Update(dt, input);
            LastFrame = frame;
            if (frame.Transition != null) Add(FormatTransition(_elapsed, frame));
            else if (frame.Stingers != null && frame.Stingers.Count > 0) Add(FormatCue(_elapsed, frame));
            return frame;
        }

        void Add(string line)
        {
            if (_log.Count >= Capacity) _log.RemoveAt(0);
            _log.Add(line);
            Transitions++;
            StateChanged?.Invoke(line);
        }

        static string Stamp(double t)
        {
            int m = (int)(t / 60), s = (int)(t % 60), tenth = (int)((t - Math.Floor(t)) * 10);
            return string.Format(CultureInfo.InvariantCulture, "[{0:00}:{1:00}.{2}]", m, s, tenth);
        }

        static string LayersOf(MusicFrame f) => f.Layers == null ? "" : string.Join(",", f.Layers.Where(kv => kv.Value > 0).Select(kv => kv.Key));

        /// <summary>"[00:12.5] explore -> combat (escalate, fade 1.5s) layers=bed,pulse cue=sting_combat"</summary>
        public static string FormatTransition(double t, MusicFrame f)
        {
            var tr = f.Transition;
            string line = string.Format(CultureInfo.InvariantCulture, "{0} {1} -> {2} ({3}, fade {4:0.0}s)", Stamp(t), tr.From, tr.To, tr.Reason, tr.CrossfadeSeconds);
            if (f.Variant != null) line += " " + f.Variant;
            string layers = LayersOf(f);
            if (layers.Length > 0) line += " layers=" + layers;
            if (f.Stingers != null && f.Stingers.Count > 0) line += " cue=" + string.Join(",", f.Stingers);
            return line;
        }

        /// <summary>A stinger without a state change (boss phase up, region arrival): "[01:02.0] boss cue=sting_phase phase=2".</summary>
        public static string FormatCue(double t, MusicFrame f)
        {
            string line = $"{Stamp(t)} {f.StateId} cue={string.Join(",", f.Stingers)}";
            if (f.BossPhase > 0) line += " phase=" + f.BossPhase;
            return line;
        }

        // ------------------------------------------------------------------ scene scan

        void Sample()
        {
            if (SignalSource != null)
            {
                var external = SignalSource();
                if (external != null) { _input = external; return; }
            }
            var inp = _input = _own;
            Vector3 me = transform.position;
            inp.Place = TownWard.Contains(me) ? PlaceKind.Town : PlaceKind.Wilderness;
            var clock = WorldClock.Instance;
            if (clock != null) inp.DayPart = clock.Part;
            inp.PlayerHpFraction = _defense != null && _defense.MaxHp > 0 ? Mathf.Clamp01(_defense.Hp / (float)_defense.MaxHp) : 1.0;
            inp.CompanionId = JoinedCompanionId();

            _prevEngaged.Clear(); _prevEngaged.AddRange(_engaged); _engaged.Clear();
            int threat = 0, bossPhase = 0;
            var monsters = MonsterController.Registry;
            for (int mi = 0; mi < monsters.Count; mi++)
            {
                var c = monsters[mi];
                if (c == null || c.Brain == null) continue;
                var state = c.Brain.State;
                if (state == AiState.Idle || state == AiState.Return) continue;
                var body = c.GetComponent<MonsterDummy>();
                if (body == null || body.IsDead) continue;
                float d = Flat(c.transform.position - me);
                if (c.Boss != null && d <= BossRadius) { bossPhase = Math.Max(bossPhase, c.Boss.PhaseIndex + 1); _engaged.Add(body); threat = Math.Max(threat, 3); }
                else if (d <= EngageRadius) { _engaged.Add(body); threat = Math.Max(threat, body.IsUnique ? 3 : 2); }
                else if (d <= AlertRadius) threat = Math.Max(threat, 1);
            }
            bool inCombat = _engaged.Count > 0;
            inp.InCombat = inCombat;
            inp.ThreatLevel = threat;
            inp.BossPhase = bossPhase;
            if (_wasInCombat && !inCombat)
                inp.Outcome = AllGone(_prevEngaged) ? CombatOutcome.Victory : CombatOutcome.Retreat;
            _wasInCombat = inCombat;
        }

        static bool AllGone(List<MonsterDummy> list)
        {
            if (list.Count == 0) return false;
            for (int i = 0; i < list.Count; i++) if (list[i] != null && !list[i].IsDead) return false;
            return true;
        }

        static float Flat(Vector3 v) { v.y = 0; return v.magnitude; }

        /// <summary>The roster id (cmp_...) of the companion travelling with the player, or null.</summary>
        static string JoinedCompanionId()
        {
            var allies = Allies.All;
            for (int i = 0; i < allies.Count; i++)
            {
                if (!(allies[i] is CompanionAI c) || c == null || !c.Joined) continue;
                var giver = c.GetComponent<QuestGiver>();
                if (giver == null) continue;
                var row = AscendData.Companions.FirstOrDefault(x => x.NpcId == giver.NpcId);
                if (row != null) return row.Id;
            }
            return null;
        }
    }
}
