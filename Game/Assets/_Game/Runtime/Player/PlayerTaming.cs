using System.Collections.Generic;
using System.Linq;
using Ascend.Core;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Ascend.Game
{
    /// <summary>
    /// Taming in play (systems.md §7.1). Weaken a tameable monster below 30% HP, then press T (D-pad left) near it to
    /// begin: it stops fighting while you stay close and calm it (walking or standing still calms faster; attacks and
    /// dodges near it frighten it). Press T again to offer — its favourite food from your bag if you have some (a big
    /// bonus), then a CHA check. Tamed monsters become partners: up to three travel with you, the rest go to the ranch.
    /// A monster that flees or turns on you remembers you for a minute. Taming counts for "tame" objectives.
    /// </summary>
    [RequireComponent(typeof(PlayerCombat), typeof(PlayerInventory), typeof(PlayerMotor))]
    public sealed class PlayerTaming : MonoBehaviour
    {
        [SerializeField] ulong seed = 41;

        PlayerCombat _combat;
        PlayerInventory _inv;
        PlayerMotor _motor;
        IRandom _rng;
        InputAction _tame;
        bool _wasDodging;
        readonly Dictionary<MonsterDummy, float> _remembered = new Dictionary<MonsterDummy, float>();
        readonly List<PartnerFollower> _following = new List<PartnerFollower>();

        static TamingTuning T => AscendData.Db.World.Taming;

        public PartnerRoster Roster { get; private set; }
        public TameEncounter Encounter { get; private set; }
        public MonsterDummy Target { get; private set; }
        public IReadOnlyList<PartnerFollower> Following => _following;
        public bool IsTamer => _combat.Class != null && _combat.Class.Id == "cls_tamer";

        void Awake()
        {
            _combat = GetComponent<PlayerCombat>();
            _inv = GetComponent<PlayerInventory>();
            _motor = GetComponent<PlayerMotor>();
            _rng = new DeterministicRandom(seed);
            Roster = new PartnerRoster(T);
            _combat.HitLanded += OnHitLanded;
            _tame = new InputAction("Tame", InputActionType.Button);
            _tame.AddBinding("<Keyboard>/t"); _tame.AddBinding("<Gamepad>/dpad/left");
        }

        void OnEnable() => _tame.Enable();
        void OnDisable() => _tame.Disable();
        void OnDestroy() { _tame.Dispose(); if (_combat != null) _combat.HitLanded -= OnHitLanded; }

        void Update()
        {
            if (_tame.WasPressedThisFrame() && !UiModal.Any) Press();
            if (Encounter == null) return;
            if (Target == null || Target.IsDead) { Toast("Too much — it's gone. Overkill ruins a tame."); End(); return; }
            Vector3 d = Target.transform.position - transform.position; d.y = 0;
            bool near = d.magnitude <= (float)T.NearMeters * 1.5f;
            bool calmMove = _motor.HorizontalVelocity.magnitude <= (float)AscendData.Db.Tuning.Movement.WalkSpeed + 0.1f;
            bool dodging = _motor.IsDodging;
            if (dodging && !_wasDodging) Encounter.Dodged();
            _wasDodging = dodging;
            Encounter.Tick(Time.deltaTime, near, calmMove);
            if (d.magnitude > 20f) { Toast($"You left the {Name(Target)} behind."); Release(remember: false); return; }
            if (Encounter.Spooked) { Toast($"The {Name(Target)} bolts!"); Release(remember: true); }
        }

        /// <summary>T: begin a taming near a weakened monster, or offer if one is under way.</summary>
        public void Press()
        {
            if (Encounter != null) { Offer(); return; }
            var cand = FindObjectsByType<MonsterDummy>(FindObjectsSortMode.None)
                .Where(m => m != null && !m.IsDead && !m.IsPartner)
                .OrderBy(m => (m.transform.position - transform.position).sqrMagnitude).FirstOrDefault();
            if (cand == null || Vector3.Distance(Flat(cand.transform.position), Flat(transform.position)) > (float)T.NearMeters) { Toast("Get close to a weakened monster to tame it."); return; }
            Begin(cand);
        }

        public bool Begin(MonsterDummy m)
        {
            if (!AscendData.Db.Species.TryGetValue(m.SpeciesId, out var s)) return false;
            if (_remembered.TryGetValue(m, out var until) && Time.time < until) { Toast($"The {s.Name} remembers you and won't come close."); return false; }
            var block = TamingRules.CanAttempt(s, m.MaxHp > 0 ? m.Hp / (double)m.MaxHp : 0, _combat.Progress.RankBand, IsTamer, T);
            switch (block)
            {
                case TameBlock.Untameable: Toast($"A {s.Name} can't be tamed like this."); return false;
                case TameBlock.AboveYourRank: Toast($"A rank {s.Rank} {s.Name} won't follow a rank {_combat.Progress.RankBand} adventurer."); return false;
                case TameBlock.NotWeakened: Toast($"Weaken the {s.Name} first (below {T.WeakenHpFraction * 100:0}% HP)."); return false;
                case TameBlock.Defeated: return false;
            }
            Target = m;
            Encounter = new TameEncounter(s, T);
            SetAi(m, false);
            string food = TamingRules.FavouriteFood(s, T);
            string hint = food != null && AscendData.Db.Items.TryGetValue(food, out var it) ? $" It likes {it.Name}." : "";
            Toast($"Calm the {s.Name}: stay close, move gently. T to offer.{hint}", 5f);
            return true;
        }

        public TameResult? Offer()
        {
            if (Encounter == null) return null;
            string food = TamingRules.FavouriteFood(Encounter.Species, T);
            bool liked = false;
            if (food != null && _inv.Items.TryRemove(food)) liked = Encounter.Feed(food);
            double cha = PlayerStats.Primary(_combat.Class, _combat.Progress.Level, AscendData.Db.Progression).Cha;
            var result = Encounter.Offer(cha, liked, IsTamer, _rng);
            var m = Target;
            switch (result)
            {
                case TameResult.Tamed:
                    Encounter = null; Target = null;
                    AdoptIntoParty(m);
                    break;
                case TameResult.Enraged:
                    Toast($"The {Name(m)} is furious!");
                    Release(remember: true);
                    break;
                default:
                    Toast($"The {Name(m)} slips away.");
                    Release(remember: true);
                    break;
            }
            return result;
        }

        void AdoptIntoParty(MonsterDummy m)
        {
            var p = Roster.Add(m.SpeciesId, Name(m));
            var quests = GetComponent<PlayerQuests>();
            if (quests != null) quests.Log.OnTame(m.SpeciesId);
            if (p.Active) { MakePartner(m); Toast($"{p.Name} joins you!", 5f); }
            else { Destroy(MonsterSpawner.RootOf(m)); Toast($"{p.Name} is tamed and heads to your ranch (three travel with you).", 5f); }
        }

        void MakePartner(MonsterDummy m)
        {
            var ai = m.GetComponent<MonsterController>();
            if (ai != null) { ai.enabled = false; Destroy(ai); } // off now; the component goes at the end of the frame
            m.BecomePartner();
            m.Heal(m.MaxHp);
            var f = m.gameObject.AddComponent<PartnerFollower>();
            f.Slot = _following.Count;
            _following.Add(f);
        }

        void OnHitLanded(MonsterDummy m, DamageResult r) { if (Encounter != null) Encounter.Attacked(); }

        void Release(bool remember)
        {
            if (Target != null)
            {
                SetAi(Target, true);
                if (remember) _remembered[Target] = Time.time + (float)T.RetrySec;
            }
            End();
        }

        void End() { Encounter = null; Target = null; }

        static void SetAi(MonsterDummy m, bool on)
        {
            var ai = m.GetComponent<MonsterController>();
            if (ai != null) ai.enabled = on;
        }

        public string StatusText()
        {
            if (Encounter == null) return null;
            int chance = (int)(Encounter.Chance(PlayerStats.Primary(_combat.Class, _combat.Progress.Level, AscendData.Db.Progression).Cha,
                Has(TamingRules.FavouriteFood(Encounter.Species, T)), IsTamer) * 100);
            return $"Taming {Encounter.Species.Name} — calm {Encounter.Calm:0} · fear {Encounter.Fear:0} · offer now ≈{chance}% (T)";
        }

        bool Has(string itemId) => itemId != null && _inv.Items.Count(itemId) > 0;

        static string Name(MonsterDummy m) => AscendData.Db.Species.TryGetValue(m.SpeciesId, out var s) ? s.Name : m.SpeciesId;
        static Vector3 Flat(Vector3 v) { v.y = 0; return v; }
        void Toast(string text, float seconds = 4f) => _inv.Toast(text, seconds);

        // ---------------------------------------------------------------- saves
        /// <summary>Restores the roster and brings the active partners back into the world beside you.</summary>
        public void Load(IEnumerable<PartnerData> partners)
        {
            foreach (var f in _following) if (f != null) Destroy(MonsterSpawner.RootOf(f.GetComponent<MonsterDummy>()));
            _following.Clear();
            Roster.Load(partners);
            int i = 0;
            foreach (var p in Roster.Active)
            {
                var at = transform.position - transform.forward * 2.5f + transform.right * (i++ - 1) * 1.2f;
                var m = MonsterSpawner.Spawn(MonsterSpawner.SceneTemplates, p.SpeciesId, at, transform.position);
                if (m != null) MakePartner(m);
            }
        }
    }
}
