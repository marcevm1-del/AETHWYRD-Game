using System;
using System.Collections.Generic;
using System.Linq;

namespace Ascend.Core
{
    // Wave D adaptive music (12_Systems/audio_and_immersion.md). Data: Data/Audio/music_states.json.
    // A pure, deterministic state machine: plain inputs in, "which layers are on" out. No audio files, no clock:
    // the caller passes the seconds since the last tick. One state owns the score at a time (no overlapping encounter scores).

    public sealed class MusicLayerDef
    {
        public string Id { get; set; }
        /// <summary>Dropped entirely when reduced music intensity is on.</summary>
        public bool Intense { get; set; }
        /// <summary>Never scaled down by reduced intensity (the bed and the hearth).</summary>
        public bool Essential { get; set; }
    }

    public sealed class MusicStateDef
    {
        public string Id { get; set; }
        public int Priority { get; set; }
        /// <summary>Combat, elite and boss: the states the no-combat-music option replaces and a victory resolves.</summary>
        public bool CombatClass { get; set; }
        /// <summary>Seconds this state must have been playing before a calmer state may replace it.</summary>
        public double MinHoldSeconds { get; set; }
        /// <summary>Seconds a higher-priority state must stay wanted before it takes over (0 = at once).</summary>
        public double EnterDelaySeconds { get; set; }
        /// <summary>Seconds a calmer state must stay wanted before this state is left.</summary>
        public double ExitDelaySeconds { get; set; }
        /// <summary>Longer exit delay after a retreat, so the score returns gradually (0 = use ExitDelaySeconds).</summary>
        public double RetreatExitDelaySeconds { get; set; }
        /// <summary>The stem set swaps with the part of the day (morning / day / dusk / night).</summary>
        public bool DaySplit { get; set; }
        public bool AllowCompanionTheme { get; set; }
        public string StingerOnEnter { get; set; }
        public Dictionary<string, double> Layers { get; set; } = new Dictionary<string, double>();
        /// <summary>Boss only: layers added at phase 1, 2, 3... (cumulative; phases past the list keep the last set).</summary>
        public List<Dictionary<string, double>> PhaseLayers { get; set; } = new List<Dictionary<string, double>>();
    }

    public sealed class MusicOverlayDef
    {
        public double OffDelaySeconds { get; set; }
        public double EnterBelowHp { get; set; }
        public double ExitAboveHp { get; set; }
        public Dictionary<string, double> Layers { get; set; } = new Dictionary<string, double>();
    }

    public sealed class MusicOverlays
    {
        public MusicOverlayDef Advantage { get; set; } = new MusicOverlayDef();
        public MusicOverlayDef Danger { get; set; } = new MusicOverlayDef();
    }

    public sealed class MusicTuning
    {
        public double DefaultCrossfadeSeconds { get; set; } = 2.5;
        public double ReducedIntensityScale { get; set; } = 0.6;
        public string RegionArrivalStinger { get; set; }
        public string BossPhaseStinger { get; set; }
    }

    public sealed class MusicFile
    {
        public int Version { get; set; } = 1;
        public string Notes { get; set; }
        public MusicTuning Tuning { get; set; } = new MusicTuning();
        public List<MusicLayerDef> Layers { get; set; } = new List<MusicLayerDef>();
        public List<MusicStateDef> States { get; set; } = new List<MusicStateDef>();
        /// <summary>"from>to" → crossfade seconds. Anything missing uses the default.</summary>
        public Dictionary<string, double> Crossfades { get; set; } = new Dictionary<string, double>();
        public MusicOverlays Overlays { get; set; } = new MusicOverlays();
        public List<string> CompanionThemes { get; set; } = new List<string>();
    }

    public enum PlaceKind { Wilderness, Town, Interior, Rest }
    public enum CombatOutcome { None, Victory, Retreat }

    /// <summary>Everything the machine looks at. All plain values; the game fills one per tick.</summary>
    public sealed class MusicInput
    {
        /// <summary>0 none, 1 something uneasy nearby (clue, distant threat), 2 hostile and aware, 3 elite or named hunt, 4 boss.</summary>
        public int ThreatLevel { get; set; }
        public bool InCombat { get; set; }
        /// <summary>0 = no boss fight. 1, 2, 3... = the boss's current phase (gameplay state, never a timestamp).</summary>
        public int BossPhase { get; set; }
        public PlaceKind Place { get; set; } = PlaceKind.Wilderness;
        public string Region { get; set; }
        public DayPart DayPart { get; set; } = DayPart.Day;
        public bool CutsceneActive { get; set; }
        public bool PlayerAdvantage { get; set; }
        /// <summary>0..1.</summary>
        public double PlayerHpFraction { get; set; } = 1.0;
        /// <summary>A one-tick event: the fight was won, or the player disengaged.</summary>
        public CombatOutcome Outcome { get; set; }
        public string CompanionId { get; set; }
    }

    /// <summary>Player options (also copied from the accessibility settings).</summary>
    public sealed class MusicPrefs
    {
        public bool NoCombatMusic { get; set; }
        public bool ReducedIntensity { get; set; }
    }

    public sealed class MusicTransition
    {
        public string From { get; set; }
        public string To { get; set; }
        public double CrossfadeSeconds { get; set; }
        public string Reason { get; set; }
    }

    /// <summary>What the audio layer should play right now.</summary>
    public sealed class MusicFrame
    {
        public string StateId { get; set; }
        public string StateEvent => "mus_state_" + StateId;
        /// <summary>morning / day / dusk / night for day-split states, otherwise null.</summary>
        public string Variant { get; set; }
        /// <summary>Layer id → target gain 0..1, ordered by id.</summary>
        public IReadOnlyDictionary<string, double> Layers { get; set; }
        public string RegionMotifEvent { get; set; }
        public string CompanionThemeEvent { get; set; }
        public int BossPhase { get; set; }
        /// <summary>One-shot cues fired this tick.</summary>
        public IReadOnlyList<string> Stingers { get; set; }
        /// <summary>Set only on the tick the state changed.</summary>
        public MusicTransition Transition { get; set; }
        public double HeldSeconds { get; set; }
    }

    public static class MusicRules
    {
        public static readonly string[] RequiredStates = { "explore", "town", "rest", "uncertainty", "aftermath", "combat", "elite", "boss", "cutscene" };

        /// <summary>The one rock stem is allowed only in the boss state (Canon §1).</summary>
        public const string RockLayer = "rock_lead";

        static bool EventSafe(string s) => !string.IsNullOrEmpty(s) && s.All(c => (c >= 'a' && c <= 'z') || (c >= '0' && c <= '9') || c == '_') && s[0] >= 'a' && s[0] <= 'z';

        /// <summary>Checks the state table; returns the problems (empty = fine). <paramref name="rosterIds"/> is the companion roster (null skips that check).</summary>
        public static List<string> Validate(MusicFile f, IEnumerable<string> rosterIds = null)
        {
            var errors = new List<string>();
            if (f == null) { errors.Add("no music data"); return errors; }
            var layerIds = new HashSet<string>(f.Layers.Select(l => l.Id));
            if (layerIds.Count != f.Layers.Count) errors.Add("duplicate layer id");
            var states = new Dictionary<string, MusicStateDef>();
            foreach (var s in f.States)
            {
                if (!EventSafe(s.Id)) errors.Add($"state id \"{s.Id}\" is not event-safe");
                else if (!states.TryAdd(s.Id, s)) errors.Add($"duplicate state {s.Id}");
            }
            foreach (var r in RequiredStates) if (!states.ContainsKey(r)) errors.Add($"missing state {r}");
            if (f.States.Select(s => s.Priority).Distinct().Count() != f.States.Count && f.States.Count > 0)
            {
                // equal priorities are allowed only between calm world states (explore / dungeon)
                foreach (var g in f.States.GroupBy(s => s.Priority).Where(g => g.Count() > 1))
                    if (g.Any(s => s.CombatClass)) errors.Add($"priority {g.Key} is shared with a combat state");
            }
            foreach (var s in f.States)
            {
                string w = $"state {s.Id}";
                if (s.MinHoldSeconds < 0 || s.EnterDelaySeconds < 0 || s.ExitDelaySeconds < 0 || s.RetreatExitDelaySeconds < 0) errors.Add($"{w}: negative time");
                if (s.RetreatExitDelaySeconds != 0 && s.RetreatExitDelaySeconds < s.ExitDelaySeconds) errors.Add($"{w}: retreat exit must not be shorter than the normal exit");
                if (s.CombatClass && s.ExitDelaySeconds <= 0) errors.Add($"{w}: combat states need an exit delay (hysteresis)");
                if (s.CombatClass && s.MinHoldSeconds <= 0) errors.Add($"{w}: combat states need a minimum hold");
                if (s.Layers.Count == 0) errors.Add($"{w}: no layers");
                var all = s.Layers.Concat(s.PhaseLayers.SelectMany(p => p));
                foreach (var kv in all)
                {
                    if (!layerIds.Contains(kv.Key)) errors.Add($"{w}: unknown layer {kv.Key}");
                    if (kv.Value < 0 || kv.Value > 1) errors.Add($"{w}: gain of {kv.Key} outside 0..1");
                    if (kv.Key == RockLayer && s.Id != "boss") errors.Add($"{w}: the rock stem is boss-only");
                }
                if (s.PhaseLayers.Count > 0 && s.Id != "boss") errors.Add($"{w}: only the boss has phase layers");
                if (s.StingerOnEnter != null && !EventSafe(s.StingerOnEnter)) errors.Add($"{w}: stinger name is not event-safe");
            }
            if (states.TryGetValue("boss", out var boss) && boss.PhaseLayers.Count == 0) errors.Add("boss needs phase layers");
            foreach (var key in f.Crossfades.Keys)
            {
                var parts = key.Split('>');
                if (parts.Length != 2 || !states.ContainsKey(parts[0]) || !states.ContainsKey(parts[1])) errors.Add($"crossfade \"{key}\" names an unknown state");
                if (f.Crossfades[key] < 0) errors.Add($"crossfade \"{key}\" is negative");
            }
            foreach (var kv in f.Overlays.Advantage.Layers.Concat(f.Overlays.Danger.Layers))
                if (!layerIds.Contains(kv.Key)) errors.Add($"overlay uses unknown layer {kv.Key}");
            if (f.Overlays.Danger.ExitAboveHp <= f.Overlays.Danger.EnterBelowHp) errors.Add("danger overlay needs exit HP above enter HP (hysteresis)");
            if (!layerIds.Contains("companion_theme")) errors.Add("missing companion_theme layer");
            if (f.Tuning.ReducedIntensityScale < 0 || f.Tuning.ReducedIntensityScale > 1) errors.Add("reducedIntensityScale outside 0..1");
            if (rosterIds != null)
            {
                var roster = new HashSet<string>(rosterIds);
                foreach (var c in f.CompanionThemes) if (!roster.Contains(c)) errors.Add($"companion theme for {c}, who is not in the roster");
            }
            if (f.CompanionThemes.Distinct().Count() != f.CompanionThemes.Count) errors.Add("duplicate companion theme");
            return errors;
        }

        public static string ThemeEvent(string companionId) =>
            "mus_companion_" + (companionId != null && companionId.StartsWith("cmp_", StringComparison.Ordinal) ? companionId.Substring(4) : companionId);
    }

    /// <summary>
    /// The adaptive score state machine. Escalation (a higher-priority state) waits <c>EnterDelaySeconds</c>; stepping down waits
    /// the current state's <c>MinHoldSeconds</c> and <c>ExitDelaySeconds</c> (hysteresis, so threat flicker never flaps the score).
    /// Victory is an event that resolves a fight at once; a retreat lengthens the exit so the score returns gradually.
    /// </summary>
    public sealed class MusicMachine
    {
        readonly MusicFile _f;
        readonly Dictionary<string, MusicStateDef> _states;
        readonly Dictionary<string, MusicLayerDef> _layers;
        readonly HashSet<string> _themes;
        readonly HashSet<string> _roster;
        MusicStateDef _cur;
        double _held;
        string _cand;
        double _candFor;
        bool _retreating;
        bool _adv; double _advOff;
        bool _danger;
        int _lastPhase;
        string _region;

        public MusicPrefs Prefs { get; }

        public MusicMachine(MusicFile file, IEnumerable<string> rosterIds = null, MusicPrefs prefs = null)
        {
            _f = file ?? throw new ArgumentNullException(nameof(file));
            var problems = MusicRules.Validate(file, rosterIds);
            if (problems.Count > 0) throw new ArgumentException("music data invalid: " + string.Join("; ", problems));
            _states = file.States.ToDictionary(s => s.Id);
            _layers = file.Layers.ToDictionary(l => l.Id);
            _themes = new HashSet<string>(file.CompanionThemes);
            _roster = rosterIds == null ? null : new HashSet<string>(rosterIds);
            Prefs = prefs ?? new MusicPrefs();
            _cur = _states["explore"];
        }

        public string CurrentState => _cur.Id;

        string Desire(MusicInput i)
        {
            if (i.CutsceneActive) return "cutscene";
            if (!Prefs.NoCombatMusic)
            {
                if (i.BossPhase > 0) return "boss";
                if (i.InCombat) return i.ThreatLevel >= 3 ? "elite" : "combat";
                if (i.ThreatLevel >= 1) return "uncertainty";
            }
            switch (i.Place)
            {
                case PlaceKind.Rest: return "rest";
                case PlaceKind.Town: return "town";
                case PlaceKind.Interior: return "dungeon";
                default: return "explore";
            }
        }

        double Crossfade(string from, string to) =>
            _f.Crossfades.TryGetValue(from + ">" + to, out var v) ? v : _f.Tuning.DefaultCrossfadeSeconds;

        MusicTransition Enter(string id, string reason, List<string> stingers, MusicInput i)
        {
            var from = _cur.Id;
            _cur = _states[id];
            _held = 0; _cand = null; _candFor = 0; _retreating = false;
            _lastPhase = id == "boss" ? i.BossPhase : 0;
            if (!_cur.CombatClass) { _adv = false; _advOff = 0; _danger = false; }
            if (!string.IsNullOrEmpty(_cur.StingerOnEnter)) stingers.Add(_cur.StingerOnEnter);
            return new MusicTransition { From = from, To = id, CrossfadeSeconds = Crossfade(from, id), Reason = reason };
        }

        /// <summary>Advances <paramref name="dt"/> seconds and returns what to play. A zero <paramref name="dt"/> still processes the input's events.</summary>
        public MusicFrame Update(double dt, MusicInput input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));
            dt = double.IsNaN(dt) || dt < 0 ? 0 : dt;
            _held += dt;
            var stingers = new List<string>();
            MusicTransition tr = null;

            if (input.Outcome == CombatOutcome.Retreat && _cur.CombatClass) _retreating = true;
            string desired = Desire(input);

            if (input.Outcome == CombatOutcome.Victory && _cur.CombatClass && !Prefs.NoCombatMusic && !_states[desired].CombatClass && desired != "cutscene")
            {
                tr = Enter("aftermath", "victory", stingers, input);
            }
            else if (desired == _cur.Id)
            {
                _cand = null; _candFor = 0;
            }
            else
            {
                if (_cand != desired) { _cand = desired; _candFor = 0; }
                _candFor += dt;
                var d = _states[desired];
                bool go;
                if (d.Priority >= _cur.Priority) go = _candFor >= d.EnterDelaySeconds; // equal priority (explore <-> dungeon) swaps after the enter delay
                else
                {
                    double exit = _retreating && _cur.RetreatExitDelaySeconds > 0 ? _cur.RetreatExitDelaySeconds : _cur.ExitDelaySeconds;
                    go = _held >= _cur.MinHoldSeconds && _candFor >= exit;
                }
                if (go) tr = Enter(desired, d.Priority >= _cur.Priority ? "escalate" : (_retreating ? "retreat" : "calm"), stingers, input);
            }

            // boss phase stinger: only while the boss owns the score and the phase moved up
            if (_cur.Id == "boss" && tr == null && input.BossPhase > _lastPhase && _lastPhase > 0 && !string.IsNullOrEmpty(_f.Tuning.BossPhaseStinger))
                stingers.Add(_f.Tuning.BossPhaseStinger);
            if (_cur.Id == "boss") _lastPhase = Math.Max(_lastPhase, input.BossPhase);

            // overlays (advantage with an off delay, danger with HP hysteresis); they only show in combat-class states
            if (input.PlayerAdvantage) { _adv = true; _advOff = 0; }
            else if (_adv) { _advOff += dt; if (_advOff >= _f.Overlays.Advantage.OffDelaySeconds) _adv = false; }
            double hp = Math.Max(0, Math.Min(1, double.IsNaN(input.PlayerHpFraction) ? 1 : input.PlayerHpFraction));
            if (hp <= _f.Overlays.Danger.EnterBelowHp) _danger = true;
            else if (hp >= _f.Overlays.Danger.ExitAboveHp) _danger = false;

            // region arrival cue: calm moments only, never on the first tick
            if (input.Region != _region)
            {
                if (_region != null && input.Region != null && !_cur.CombatClass && _cur.Id != "cutscene" && tr?.To != "aftermath" && !string.IsNullOrEmpty(_f.Tuning.RegionArrivalStinger))
                    stingers.Add(_f.Tuning.RegionArrivalStinger);
                _region = input.Region;
            }

            return Compose(input, tr, stingers);
        }

        MusicFrame Compose(MusicInput input, MusicTransition tr, List<string> stingers)
        {
            var mix = new SortedDictionary<string, double>(StringComparer.Ordinal);
            void Add(Dictionary<string, double> src)
            {
                foreach (var kv in src) mix[kv.Key] = mix.TryGetValue(kv.Key, out var old) ? Math.Max(old, kv.Value) : kv.Value;
            }
            Add(_cur.Layers);
            if (_cur.Id == "boss" && _cur.PhaseLayers.Count > 0)
            {
                int n = Math.Min(Math.Max(input.BossPhase, 1), _cur.PhaseLayers.Count);
                for (int p = 0; p < n; p++) Add(_cur.PhaseLayers[p]);
            }
            if (_cur.CombatClass)
            {
                if (_adv) Add(_f.Overlays.Advantage.Layers);
                if (_danger) Add(_f.Overlays.Danger.Layers);
            }
            string themeEvent = null;
            if (_cur.AllowCompanionTheme && !string.IsNullOrEmpty(input.CompanionId) && _themes.Contains(input.CompanionId) && (_roster == null || _roster.Contains(input.CompanionId)))
            {
                themeEvent = MusicRules.ThemeEvent(input.CompanionId);
                mix["companion_theme"] = 0.8;
            }
            if (Prefs.ReducedIntensity)
            {
                foreach (var id in mix.Keys.ToList())
                {
                    var def = _layers[id];
                    if (def.Intense) mix.Remove(id);
                    else if (!def.Essential) mix[id] = mix[id] * _f.Tuning.ReducedIntensityScale;
                }
            }
            return new MusicFrame
            {
                StateId = _cur.Id,
                Variant = _cur.DaySplit ? input.DayPart.ToString().ToLowerInvariant() : null,
                Layers = mix,
                RegionMotifEvent = mix.ContainsKey("motif") && !string.IsNullOrEmpty(input.Region) ? "mus_motif_" + input.Region : null,
                CompanionThemeEvent = themeEvent,
                BossPhase = _cur.Id == "boss" ? input.BossPhase : 0,
                Stingers = stingers,
                Transition = tr,
                HeldSeconds = _held,
            };
        }
    }
}
