using System;
using System.Collections.Generic;
using System.Linq;
using Ascend.Core;
using UnityEngine;

// =====================================================================================================================
// PlayerWorldState API (full notes with examples: 13_Production/phase1_api.md). Namespace Ascend.Game, on the player.
// PlayerSave and PlayerCrafting add this component themselves, or use PlayerWorldState.Ensure(gameObject).
//
//   LifeSkills LifeSkills              the life skill ladder (same object PlayerCrafting.Crafter uses)
//   Home Home                           home tier, storage, crop plots
//   Stables Stables                     eggs, boarding, mount; null until the player has PlayerTaming (its partner roster)
//   CivilizationArchive Archive
//   IReadOnlyDictionary<string, DungeonKnowledge> Dungeons      by dungeon id
//   Labyrinth Labyrinth, LabyrinthKnowledge LabyrinthKnowledge
//   DiscoveryJournal Journal            creature / landmark / region / secret
//   EventDirector Events, EventDirectorSave EventState, IReadOnlyList<ActiveLivingEvent> ActiveEvents
//   GearFitter Gear                     runes and enchantments; null until the player has PlayerCrafting
//   MealBuffs Meals, bool Eat(itemKey)  the one "Well Fed" slot
//   AccessibilitySettings Accessibility, AccessibilityFile AccessibilityData
//   void SetAccessibility(s), void ApplyAccessibility(), event AccessibilityChanged
//   MusicStateLogger Music              adaptive-music driver (no audio): Log (30 lines), CurrentState, LastFrame
//   IReadOnlyList<CompanionData> CompanionRoster, CompanionRules CompanionRules
//   CompanionPreset PresetOf(id), SetPreset(id, preset), RelationshipState BondOf(id), event CompanionsChanged
//   void Capture(SaveGame), void Apply(SaveGame)     used by PlayerSave
//
// A property is null only when its data file is missing (or, for Stables and Gear, when the component it needs is absent).
// Do not cache the Core objects across a load: they keep their identity, but ask the world state each time.
// Companion presets and bonds are saved in SaveGame.CompanionPresets / CompanionBonds.
// =====================================================================================================================
namespace Ascend.Game
{
    /// <summary>
    /// The player's long-lived world knowledge and life-skill state, built from the finished Core rules (life skills, home, stables,
    /// archive, dungeons, labyrinth, living world, gear fittings, meal buffs, accessibility, companion bonds) and saved/loaded
    /// with the slot by <see cref="PlayerSave"/>. Plain holder: the windows read it, the rules live in Core.
    /// </summary>
    [DefaultExecutionOrder(-100)]
    public sealed class PlayerWorldState : MonoBehaviour
    {
        /// <summary>Seed of the living-world event dice: fixed, so a given in-game day always rolls the same events.</summary>
        public const ulong EventSeed = 0xA5CEDu;

        GameDatabase _db;
        bool _built;
        LifeSkills _lifeSkills;
        Home _home;
        CivilizationArchive _archive;
        readonly Dictionary<string, DungeonKnowledge> _dungeons = new Dictionary<string, DungeonKnowledge>();
        Labyrinth _labyrinth;
        LabyrinthKnowledge _labKnowledge;
        DiscoveryJournal _journal;
        EventDirector _events;
        LivingWorldSave _living = new LivingWorldSave();
        MealBuffs _meals;
        MusicStateLogger _music;
        AccessibilitySettings _accessibility;
        Stables _stables; StablesSave _pendingStables;
        GearFitter _gear; Dictionary<string, GearFitting> _pendingFittings;
        int _lastEventDay = int.MinValue;
        readonly Dictionary<string, RelationshipState> _bonds = new Dictionary<string, RelationshipState>();
        readonly Dictionary<string, CompanionPreset> _presets = new Dictionary<string, CompanionPreset>();

        public event Action AccessibilityChanged;
        public event Action CompanionsChanged;

        /// <summary>The world state of a player (adds one if missing).</summary>
        public static PlayerWorldState Ensure(GameObject player)
        {
            var w = player.GetComponent<PlayerWorldState>();
            return w != null ? w : player.AddComponent<PlayerWorldState>();
        }

        /// <summary>The world state next to a component on the player, or null.</summary>
        public static PlayerWorldState Of(Component c) => c != null ? c.GetComponent<PlayerWorldState>() : null;

        void Awake() => Build();

        void Build()
        {
            if (_built) return;
            _built = true;
            _db = AscendData.Db;
            Guard("life skills", () => _lifeSkills = new LifeSkills(_db.LifeSkills));
            Guard("home", () => _home = new Home(_db.Housing, _db.Crops, _db.Quality, _lifeSkills));
            Guard("archive", () => _archive = new CivilizationArchive(_db.Archive));
            Guard("dungeons", () => { foreach (var d in _db.Dungeons.Values) _dungeons[d.Id] = new DungeonKnowledge(d); });
            Guard("labyrinth", () =>
            {
                var data = AscendData.LabyrinthData;
                if (data == null) return;
                _labyrinth = new Labyrinth(data);
                _labKnowledge = new LabyrinthKnowledge(_labyrinth);
            });
            Guard("living world", () =>
            {
                var lw = AscendData.LivingWorld;
                if (lw == null) return;
                _events = new EventDirector(lw.Events, new GameCalendar(_db.World.Calendar), EventSeed);
                _journal = new DiscoveryJournal(lw.JournalCategories, _living.Journal);
            });
            Guard("meals", () => _meals = new MealBuffs(_db.Items, _db.Quality));
            Guard("accessibility", () => _accessibility = CloneSettings(AscendData.Accessibility?.Defaults).Sanitize());
            var saved = GameSettings.TryLoad(); // settings.json beside the saves wins over the data defaults (null in the editor and tests)
            if (saved != null) _accessibility = saved;
            if (_accessibility == null) _accessibility = new AccessibilitySettings();
            Guard("music", () =>
            {
                _music = GetComponent<MusicStateLogger>();
                if (_music == null) _music = gameObject.AddComponent<MusicStateLogger>();
                _music.ApplyAccessibility(_accessibility);
            });
        }

        static void Guard(string what, Action a)
        {
            try { a(); }
            catch (Exception e) { Debug.LogWarning($"PlayerWorldState: {what} not available ({e.Message})"); }
        }

        // ------------------------------------------------------------------ the state

        public LifeSkills LifeSkills { get { Build(); return _lifeSkills; } }
        public Home Home { get { Build(); return _home; } }
        public CivilizationArchive Archive { get { Build(); return _archive; } }
        public IReadOnlyDictionary<string, DungeonKnowledge> Dungeons { get { Build(); return _dungeons; } }
        public Labyrinth Labyrinth { get { Build(); return _labyrinth; } }
        public LabyrinthKnowledge LabyrinthKnowledge { get { Build(); return _labKnowledge; } }
        public DiscoveryJournal Journal { get { Build(); return _journal; } }
        public EventDirector Events { get { Build(); return _events; } }
        public EventDirectorSave EventState { get { Build(); return _living.Events; } }
        public MealBuffs Meals { get { Build(); return _meals; } }
        public MusicStateLogger Music { get { Build(); return _music; } }
        /// <summary>A private copy: the data file's Defaults object is shared and Sanitize works in place.</summary>
        static AccessibilitySettings CloneSettings(AccessibilitySettings src)
        {
            if (src == null) return new AccessibilitySettings();
            var copy = Newtonsoft.Json.JsonConvert.DeserializeObject<AccessibilitySettings>(Newtonsoft.Json.JsonConvert.SerializeObject(src));
            return copy ?? new AccessibilitySettings();
        }

        public AccessibilitySettings Accessibility { get { Build(); return _accessibility; } }
        public AccessibilityFile AccessibilityData => AscendData.Accessibility;
        public IReadOnlyList<CompanionData> CompanionRoster => AscendData.Companions;
        public CompanionRules CompanionRules => AscendData.CompanionRules;
        public RelationshipRules RelationRules => AscendData.CompanionRules?.Relationships;

        /// <summary>Events present today (empty before the world clock exists).</summary>
        public IReadOnlyList<ActiveLivingEvent> ActiveEvents
        {
            get
            {
                Build();
                var clock = WorldClock.Instance;
                return clock == null ? new List<ActiveLivingEvent>() : EventDirector.PresentOn(_living.Events, clock.Day);
            }
        }

        /// <summary>Home stables: built once the player has a partner roster (PlayerTaming). Null before that.</summary>
        public Stables Stables
        {
            get
            {
                Build();
                if (_stables != null) return _stables;
                var taming = GetComponent<PlayerTaming>();
                if (taming == null || taming.Roster == null || _home == null) return null;
                Guard("stables", () =>
                {
                    _stables = new Stables(_db.Stables, taming.Roster, _db.World.Taming, _home, _db.Species, AscendData.Mounts);
                    _stables.Load(_pendingStables);
                    _pendingStables = null;
                });
                return _stables;
            }
        }

        /// <summary>Rune and enchantment fittings: built once the player has PlayerCrafting (station ownership). Null before that.</summary>
        public GearFitter Gear
        {
            get
            {
                Build();
                if (_gear != null) return _gear;
                var crafting = GetComponent<PlayerCrafting>();
                if (crafting == null || crafting.Crafter == null) return null;
                Guard("gear fittings", () =>
                {
                    _gear = new GearFitter(_db.Gear, _db.Items, _db.Quality, crafting.Crafter);
                    _gear.Load(_pendingFittings);
                    _pendingFittings = null;
                });
                return _gear;
            }
        }

        // ------------------------------------------------------------------ meals

        /// <summary>Eats a meal from the bag (item key may carry a quality, "itm_x@fine"): starts the Well Fed buff. False if not a meal or not in the bag.</summary>
        public bool Eat(string itemKey)
        {
            Build();
            var inv = GetComponent<PlayerInventory>();
            if (_meals == null || inv == null) return false;
            bool ok = _meals.Eat(itemKey, Time.timeAsDouble, inv.Items);
            if (ok) inv.Toast($"{MealBuffs.SlotName}: {PlayerCrafting.Name(itemKey)}", 3f);
            return ok;
        }

        // ------------------------------------------------------------------ accessibility

        /// <summary>Replaces the settings (clamped to range), pushes the music options to the logger and raises <see cref="AccessibilityChanged"/>.</summary>
        public void SetAccessibility(AccessibilitySettings s)
        {
            Build();
            _accessibility = (s ?? new AccessibilitySettings()).Sanitize();
            ApplyAccessibility();
        }

        /// <summary>Call after changing fields of <see cref="Accessibility"/> in place.</summary>
        public void ApplyAccessibility()
        {
            Build();
            _accessibility = _accessibility.Sanitize();
            if (_music != null) _music.ApplyAccessibility(_accessibility);
            AccessibilityChanged?.Invoke();
        }

        // ------------------------------------------------------------------ companions (session only)

        public CompanionPreset PresetOf(string companionId)
        {
            if (companionId != null && _presets.TryGetValue(companionId, out var p)) return p;
            var row = AscendData.Companions.FirstOrDefault(c => c.Id == companionId);
            return row != null && Enum.TryParse<CompanionPreset>(row.PresetDefault, true, out var d) && Enum.IsDefined(typeof(CompanionPreset), d) ? d : CompanionPreset.Balanced;
        }

        public void SetPreset(string companionId, CompanionPreset preset)
        {
            if (string.IsNullOrEmpty(companionId)) return;
            _presets[companionId] = preset;
            CompanionsChanged?.Invoke();
        }

        /// <summary>The relationship state with a companion, created from the rules' starting values on first use (null without companion_rules.json).</summary>
        public RelationshipState BondOf(string companionId)
        {
            var rules = RelationRules;
            if (rules == null || string.IsNullOrEmpty(companionId)) return null;
            if (!_bonds.TryGetValue(companionId, out var s)) _bonds[companionId] = s = rules.NewState(companionId);
            return s;
        }

        /// <summary>Written to SaveGame.CompanionBonds by <see cref="Capture"/>.</summary>
        public List<CompanionBondSave> SaveBonds() => _bonds.Select(kv => kv.Value.ToSave(kv.Key)).ToList();

        public void LoadBonds(IEnumerable<CompanionBondSave> saves)
        {
            _bonds.Clear();
            foreach (var b in saves ?? Enumerable.Empty<CompanionBondSave>())
                if (b != null && !string.IsNullOrEmpty(b.CompanionId)) _bonds[b.CompanionId] = RelationshipState.FromSave(b, RelationRules, b.CompanionId);
            CompanionsChanged?.Invoke();
        }

        // ------------------------------------------------------------------ living world tick

        void Update()
        {
            var clock = WorldClock.Instance;
            if (clock == null || _events == null) return;
            int day = clock.Day;
            if (day == _lastEventDay) return;
            _lastEventDay = day;
            Guard("event director", () => _events.Advance(_living.Events, day));
        }

        // ------------------------------------------------------------------ save and load

        /// <summary>Writes the Phase 1 parts of the world state into a save (called by PlayerSave.Save).</summary>
        public void Capture(SaveGame s)
        {
            if (s == null) return;
            Build();
            s.LifeSkills = _lifeSkills != null ? _lifeSkills.Save() : new LifeSkillSave();
            var gear = Gear;
            s.GearFittings = gear != null ? gear.Save() : (_pendingFittings ?? new Dictionary<string, GearFitting>());
            s.Home = _home != null ? _home.Save() : new HomeSave();
            var stables = Stables;
            s.Stables = stables != null ? stables.Save() : (_pendingStables ?? new StablesSave());
            s.Archive = _archive != null ? _archive.Save() : new ArchiveSave();
            s.Dungeons = new DungeonSave { Dungeons = _dungeons.ToDictionary(kv => kv.Key, kv => kv.Value.Save()) };
            s.Labyrinth = _labKnowledge != null ? _labKnowledge.Save() : new LabyrinthSave();
            s.LivingWorld = new LivingWorldSave
            {
                Events = new EventDirectorSave
                {
                    LastRolledDay = _living.Events.LastRolledDay,
                    LastStartDay = new Dictionary<string, int>(_living.Events.LastStartDay ?? new Dictionary<string, int>()),
                    Active = (_living.Events.Active ?? new List<ActiveLivingEvent>())
                        .Select(a => new ActiveLivingEvent { EventId = a.EventId, RegionId = a.RegionId, StartDay = a.StartDay, EndDay = a.EndDay }).ToList(),
                },
                Journal = new DiscoveryJournalSave { Entries = new Dictionary<string, MapStatus>(_living.Journal.Entries ?? new Dictionary<string, MapStatus>()) },
            };
            s.Accessibility = _accessibility;
            s.CompanionBonds = SaveBonds();
            s.CompanionPresets = _presets.ToDictionary(kv => kv.Key, kv => kv.Value.ToString());
        }

        /// <summary>
        /// Restores the Phase 1 parts from a loaded save (called by PlayerSave.Load after SaveRules.Upgrade). Every section is
        /// null-tolerant and isolated: a field missing from an older save keeps its fresh default and never stops the others.
        /// Knowledge (dungeons, labyrinth, archive) is reset and then loaded, so a reload or slot switch replaces it (Core Load alone merges and never downgrades).
        /// </summary>
        public void Apply(SaveGame s)
        {
            if (s == null) return;
            Build();
            Guard("life skills load", () => _lifeSkills?.Load(s.LifeSkills));
            Guard("home load", () => _home?.Load(s.Home));
            Guard("stables load", () =>
            {
                _pendingStables = s.Stables;
                if (_stables != null) { _stables.Load(_pendingStables); _pendingStables = null; }
                else { _ = Stables; } // builds and loads the pending save when a roster exists; otherwise it waits
            });
            Guard("gear load", () =>
            {
                _pendingFittings = s.GearFittings;
                if (_gear != null) { _gear.Load(_pendingFittings); _pendingFittings = null; }
                else { _ = Gear; }
            });
            Guard("archive load", () => { _archive?.Reset(); _archive?.Load(s.Archive); });
            Guard("dungeons load", () =>
            {
                foreach (var k in _dungeons.Values) k.Reset();
                foreach (var kv in s.Dungeons?.Dungeons ?? new Dictionary<string, DungeonProgressSave>())
                    if (_dungeons.TryGetValue(kv.Key, out var k)) k.Load(kv.Value);
            });
            Guard("labyrinth load", () => { _labKnowledge?.Reset(); _labKnowledge?.Load(s.Labyrinth); });
            Guard("living world load", () =>
            {
                var lw = s.LivingWorld;
                var ev = lw?.Events;
                _living.Events = new EventDirectorSave
                {
                    LastRolledDay = ev != null ? ev.LastRolledDay : -1,
                    LastStartDay = ev?.LastStartDay != null ? new Dictionary<string, int>(ev.LastStartDay) : new Dictionary<string, int>(),
                    Active = ev?.Active != null ? ev.Active.Where(a => a != null).ToList() : new List<ActiveLivingEvent>(),
                };
                // The journal wraps this very dictionary, so fill it in place.
                _living.Journal.Entries.Clear();
                foreach (var kv in lw?.Journal?.Entries ?? new Dictionary<string, MapStatus>())
                    if (!string.IsNullOrEmpty(kv.Key) && kv.Value != MapStatus.Unknown) _living.Journal.Entries[kv.Key] = kv.Value;
                _lastEventDay = int.MinValue; // roll today again after a load (the director never re-rolls a day it has done)
            });
            Guard("accessibility load", () => SetAccessibility(GameSettings.TryLoad() ?? s.Accessibility));
            Guard("companion presets load", () =>
            {
                _presets.Clear();
                foreach (var kv in s.CompanionPresets ?? new Dictionary<string, string>())
                    if (!string.IsNullOrEmpty(kv.Key) && Enum.TryParse<CompanionPreset>(kv.Value, true, out var cp) && Enum.IsDefined(typeof(CompanionPreset), cp))
                        _presets[kv.Key] = cp;
            });
            Guard("companion bonds load", () => LoadBonds(s.CompanionBonds));
        }
    }
}
