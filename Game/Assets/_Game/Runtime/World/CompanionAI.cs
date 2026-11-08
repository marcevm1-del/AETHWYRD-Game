using System.Collections.Generic;
using System.Linq;
using Ascend.Core;
using UnityEngine;

namespace Ascend.Game
{
    /// <summary>
    /// A companion who fights beside you (12_Systems/companion_field_ai.md, Ring 0 prototype; the decision order is Core
    /// CompanionBrain). Lyra follows without crowding you, takes your orders (Z / LB: Follow, Hold, Focus — Focus falls
    /// back to Assist on the monster you last hit), dodges wind-ups aimed at her, lands a signature Rising Slash on any
    /// monster you stagger, regroups instead of teleporting into a fight, and is only ever downed (she gets back up).
    /// Out of combat she shares her read on monsters she hasn't seen before — her interpretation, not evidence.
    /// </summary>
    [RequireComponent(typeof(QuestGiver))]
    public sealed class CompanionAI : MonoBehaviour, IAlly
    {
        static CompanionTuning BaseTuning => AscendData.Db.World.Companions;
        static CompanionRules Rules => AscendData.CompanionRules ?? new CompanionRules();
        /// <summary>The base tuning with this companion's preset applied (Balanced is the identity). Rebuilt when the preset changes.</summary>
        CompanionTuning T => _tuning ?? (_tuning = CompanionPresetBrain.ApplyPreset(BaseTuning, Rules, _preset));
        CompanionTuning _tuning;
        CompanionPreset _preset = CompanionPreset.Balanced;
        bool _retreating, _retreatCommanded;
        float _regen;
        /// <summary>Out of a fight a hurt companion recovers this fraction of max HP per second (without it a retreat could never end).</summary>
        public const float OutOfCombatRegenPerSec = 0.05f;
        /// <summary>Quiet mode for companion banter (companion_field_ai.md: frequency control).</summary>
        public static bool QuietBanter { get; set; }

        [SerializeField] string classId = "cls_swordsman";
        [SerializeField] Transform[] followers = new Transform[0];

        QuestGiver _giver;
        PlayerCombat _player;
        PlayerDefense _playerDefense;
        DamageCalculator _calc;
        IRandom _rng;
        Vector3 _home, _holdAt, _lastPos;
        Quaternion _homeRot;
        float _attackCd, _dodgeCd, _downedUntil = -1f, _sinceLine = 999f;
        Vector3 _dodgeVel; float _dodgeLeft;
        MonsterDummy _lastPlayerHit;
        readonly HashSet<string> _seenSpecies = new HashSet<string>();
        readonly Dictionary<MonsterDummy, int> _assistedStagger = new Dictionary<MonsterDummy, int>();

        public CompanionOrder Order { get; private set; } = CompanionOrder.Follow;
        public CompanionPreset Preset => _preset;
        public bool Retreating => _retreating;
        public CompanionAction LastAction { get; private set; } = CompanionAction.Follow;
        public MonsterDummy Target { get; private set; }
        public int Hp { get; private set; }
        public int MaxHp { get; private set; }
        public bool Downed => _downedUntil >= 0f;
        public int Hits { get; private set; }
        public int Assists { get; private set; }
        public int Dodges { get; private set; }
        public string LastLine { get; private set; }
        public string Name => _giver != null ? _giver.DisplayName : name;
        public Transform[] Followers { get => followers; set => followers = value; }

        Transform IAlly.Transform => transform;
        bool IAlly.Down => Downed;
        MonsterDummy IAlly.Engaged => Target;
        bool IAlly.Taunts => false;

        void Awake()
        {
            _giver = GetComponent<QuestGiver>();
            _calc = new DamageCalculator(AscendData.Db.Tuning.Damage);
            _rng = new DeterministicRandom(17);
            _home = transform.position; _homeRot = transform.rotation; _lastPos = transform.position;
        }

        void OnEnable() => Allies.Add(this);
        void OnDisable() => Allies.Remove(this);
        void OnDestroy() { if (_player != null) _player.HitLanded -= OnPlayerHit; }

        /// <summary>Joins you: stats from her class at your level, a trigger collider so she never body-blocks you.</summary>
        public void Join(PlayerCombat player)
        {
            _player = player;
            _playerDefense = player.GetComponent<PlayerDefense>();
            _player.HitLanded += OnPlayerHit;
            foreach (var c in GetComponentsInChildren<Collider>()) c.isTrigger = true;
            ScaleToLevel();
            Hp = MaxHp;
            enabled = true;
        }

        /// <summary>Parts ways: back to her spot.</summary>
        public void Leave()
        {
            if (_player != null) _player.HitLanded -= OnPlayerHit;
            _player = null;
            foreach (var c in GetComponentsInChildren<Collider>()) c.isTrigger = false;
            transform.SetPositionAndRotation(_home, _homeRot);
            enabled = false;
        }

        public bool Joined => _player != null && enabled;

        void ScaleToLevel()
        {
            var db = AscendData.Db;
            var cls = db.Classes[classId];
            int lv = _player.Progress.Level;
            var stats = PlayerStats.Derive(PlayerStats.Primary(cls, lv, db.Progression), lv, db.Progression);
            MaxHp = Mathf.Max(1, stats.Hp);
            _atk = stats.Atk;
        }
        int _atk;

        public void Command(CompanionOrder order)
        {
            Order = order;
            if (order == CompanionOrder.Hold) _holdAt = transform.position;
            Target = null;
            _retreatCommanded = false;
        }

        /// <summary>Applies a stance (companion_rules.json presets): follow distance, leash, assist power and retreat threshold change. Her order becomes the preset's default order.</summary>
        public void SetPreset(CompanionPreset preset)
        {
            _preset = preset;
            _tuning = null;
            Command(Rules.Preset(preset).Order);
        }

        /// <summary>One command-wheel entry (CompanionCommands.Map). Retreat runs to you and stays out of the fight until she has recovered or you give another order; Defend holds at your position.</summary>
        public void CommandWheel(CompanionCommand command)
        {
            var effect = CompanionCommands.Map(command);
            Command(effect.Order);
            if (effect.HoldAtPlayer && _player != null) _holdAt = _player.transform.position;
            _retreatCommanded = effect.Retreat;
        }

        void OnPlayerHit(MonsterDummy m, DamageResult r) => _lastPlayerHit = m;

        void Update()
        {
            if (_player == null) return;
            float dt = Time.deltaTime;
            if (dt <= 0f) return;
            _attackCd -= dt; _dodgeCd -= dt; _sinceLine += dt;

            if (_dodgeLeft > 0f) { _dodgeLeft -= dt; transform.position += _dodgeVel * dt; return; }

            var monsters = FindObjectsByType<MonsterDummy>(FindObjectsSortMode.None).Where(m => m != null && !m.IsDead && !m.IsPartner).ToList();
            Vector3 me = transform.position;
            Vector3 anchor = Order == CompanionOrder.Hold ? _holdAt : _player.transform.position;
            bool inCombat = monsters.Any(m => { var ai = m.GetComponent<MonsterController>(); return ai != null && ai.Brain != null && ai.Brain.State != AiState.Idle && Flat(m.transform.position - anchor).magnitude < 15f; });

            var threat = monsters.FirstOrDefault(m =>
            {
                var ai = m.GetComponent<MonsterController>();
                return ai != null && ai.Brain != null && ai.Brain.State == AiState.Windup && (ReferenceEquals(ai.AllyTarget, this) || Flat(m.transform.position - me).magnitude < 2.2f);
            });
            var staggered = monsters.FirstOrDefault(m =>
            {
                var ai = m.GetComponent<MonsterController>();
                if (ai == null || ai.Brain == null || ai.Brain.State != AiState.Staggered || Flat(m.transform.position - me).magnitude > 7f) return false;
                return !_assistedStagger.TryGetValue(m, out var n) || n != m.Staggers;
            });
            var playerTarget = Order == CompanionOrder.Focus ? (_player.LockTarget != null ? _player.LockTarget : _lastPlayerHit) : null;
            if (playerTarget != null && (playerTarget.IsDead || playerTarget.IsPartner)) playerTarget = null;
            var nearest = monsters.Where(m => Flat(m.transform.position - anchor).magnitude <= T.Leash && IsHostileNow(m))
                                  .OrderBy(m => Flat(m.transform.position - me).sqrMagnitude).FirstOrDefault();

            bool inFight = inCombat || nearest != null || threat != null;
            if ((!inFight || _retreating) && Hp > 0 && Hp < MaxHp && !Downed)
            {
                _regen += MaxHp * OutOfCombatRegenPerSec * dt; int whole = (int)_regen; _regen -= whole;
                Hp = Mathf.Min(MaxHp, Hp + whole);
            }
            if (!inFight) _retreatCommanded = false;
            double hpFraction = MaxHp > 0 ? Hp / (double)MaxHp : 1.0;
            var sense = new CompanionSense
            {
                Downed = Downed, Order = Order,
                DistanceToPlayer = Flat(_player.transform.position - me).magnitude,
                ThreatWindingUpNearMe = threat != null, DodgeReady = _dodgeCd <= 0f,
                StaggeredEnemyNear = staggered != null,
                PlayerTargetAlive = playerTarget != null,
                EnemyInLeash = nearest != null, InCombat = inCombat,
            };
            var action = CompanionPresetBrain.Decide(sense, T, Rules.Preset(_preset), hpFraction, false, false, Rules,
                new CompanionContext { WasRetreating = _retreating, RetreatCommanded = _retreatCommanded });
            _retreating = action == CompanionAction.Retreat;
            LastAction = action;

            switch (action)
            {
                case CompanionAction.Downed: DownedStep(); break;
                case CompanionAction.Dodge: Dodge(threat); break;
                case CompanionAction.Regroup: Regroup(inCombat, dt); break;
                case CompanionAction.SignatureAssist: Strike(staggered, true, dt); break;
                case CompanionAction.Attack: Strike(playerTarget ?? nearest, false, dt); break;
                case CompanionAction.Guard: MoveTo(_holdAt, 0.3f, dt); break;
                case CompanionAction.Retreat: Target = null; MoveTo(_player.transform.position, (float)T.PersonalSpace + 0.5f, dt, sprint: true); break;
                case CompanionAction.Revive: // the player has no downed state in the runtime yet (death is a respawn), so Decide is never given playerDowned
                case CompanionAction.Interact: FollowStep(dt); break; // Interact has no runtime behaviour yet; she just keeps following
                default: FollowStep(dt); break;
            }
            if (!inCombat) Observe(monsters);
        }

        /// <summary>Only monsters that are already fighting (or you're fighting) — she doesn't start fights or pick on the passive.</summary>
        bool IsHostileNow(MonsterDummy m)
        {
            var ai = m.GetComponent<MonsterController>();
            return m == _lastPlayerHit || (ai != null && ai.Brain != null && ai.Brain.State != AiState.Idle && ai.Brain.State != AiState.Return && ai.Brain.State != AiState.Flee);
        }

        void FollowStep(float dt)
        {
            Target = null;
            Vector3 p = _player.transform.position;
            Vector3 slot = p - _player.transform.forward * (float)T.FollowDistance + _player.transform.right * 1.3f;
            MoveTo(slot, 0.5f, dt);
            // Personal space: never stand inside you (no clipping, no body-blocking).
            Vector3 away = Flat(transform.position - p);
            if (away.magnitude < T.PersonalSpace) transform.position = p + (away.sqrMagnitude > 1e-4f ? away.normalized : -_player.transform.forward) * (float)T.PersonalSpace + Vector3.up * (transform.position.y - p.y);
        }

        void Regroup(bool inCombat, float dt)
        {
            Target = null;
            Vector3 p = _player.transform.position;
            if (!inCombat) { Warp(p - _player.transform.forward * (float)T.FollowDistance); return; } // out of sight, catch up
            MoveTo(p, 1.5f, dt, sprint: true); // in a fight: run back rather than teleport into an attack
        }

        void Strike(MonsterDummy m, bool signature, float dt)
        {
            if (m == null) return;
            Target = m;
            Vector3 to = Flat(m.transform.position - transform.position);
            if (to.magnitude > T.ReachM) { MoveTo(m.transform.position, (float)T.ReachM * 0.8f, dt, sprint: signature); return; }
            Face(to);
            if (_attackCd > 0f && !signature) return; // the signature assist answers the opening at once
            _attackCd = (float)T.AttackIntervalSec;
            double power = signature ? T.AssistPower : T.AttackPower;
            var result = _calc.Compute(new DamageInput { Kind = DamageKind.Physical, Attack = _atk, Defense = m.Defense, Power = power }, _rng);
            m.TakeHit(result.Amount, signature ? HitWeight.Heavy : HitWeight.Light, transform.position, power * 8);
            Hits++;
            if (signature)
            {
                Assists++;
                _assistedStagger[m] = m.Staggers;
                Say($"{Name}: Rising Slash!", force: true);
            }
        }

        void Dodge(MonsterDummy threat)
        {
            Dodges++;
            _dodgeCd = (float)T.DodgeCooldownSec;
            Vector3 away = Flat(transform.position - threat.transform.position);
            Vector3 side = Vector3.Cross(Vector3.up, away.sqrMagnitude > 1e-4f ? away.normalized : transform.forward);
            Vector3 dir = (away.normalized + side * (Random.value < 0.5f ? 1f : -1f)).normalized; // a readable sidestep back
            _dodgeLeft = 0.3f;
            _dodgeVel = dir * (float)(T.DodgeDistance / 0.3);
        }

        void DownedStep()
        {
            if (Time.time < _downedUntil) return;
            _downedUntil = -1f;
            ScaleToLevel();
            Hp = MaxHp;
            Say($"{Name} is back on her feet.", force: true);
        }

        void IAlly.TakeAllyHit(int damage, Vector3 from)
        {
            if (Downed || _dodgeLeft > 0f) return; // mid-dodge: it missed
            Hp = Mathf.Max(0, Hp - Mathf.Max(0, damage));
            if (Hp > 0) return;
            _downedUntil = Time.time + (float)T.DownedSec;
            Target = null;
            Say($"{Name} is down! She'll recover in a moment.", force: true);
        }

        /// <summary>Her read on a monster she hasn't seen before (companion interpretation, not your evidence).</summary>
        void Observe(List<MonsterDummy> monsters)
        {
            foreach (var m in monsters)
            {
                if (_seenSpecies.Contains(m.SpeciesId) || Flat(m.transform.position - transform.position).magnitude > 15f) continue;
                if (!CompanionBrain.MaySpeak(false, _sinceLine, QuietBanter, T)) return;
                _seenSpecies.Add(m.SpeciesId);
                if (!AscendData.Db.Species.TryGetValue(m.SpeciesId, out var s) || string.IsNullOrEmpty(s.FieldNote)) continue;
                Say($"{Name} (her read on the {s.Name}): \"{s.FieldNote}\"");
                return;
            }
        }

        void Say(string line, bool force = false)
        {
            if (!force && QuietBanter) return;
            LastLine = line;
            _sinceLine = 0f;
            var inv = _player != null ? _player.GetComponent<PlayerInventory>() : null;
            if (inv != null) inv.Toast(line, 5f);
        }

        void MoveTo(Vector3 goal, float stopAt, float dt, bool sprint = false)
        {
            Vector3 to = Flat(goal - transform.position);
            if (to.magnitude <= stopAt) return;
            float speed = (float)(sprint ? AscendData.Db.Tuning.Movement.SprintSpeed : AscendData.Db.Tuning.Movement.RunSpeed) * 0.9f;
            float step = Mathf.Min(to.magnitude - stopAt, speed * dt);
            Vector3 dir = to.normalized;
            // Walls: slide along them; if blocked, step sideways (same unsticking idea as the monsters).
            if (Physics.Raycast(transform.position + Vector3.up * 0.2f, dir, out var hit, step + 0.4f, ~0, QueryTriggerInteraction.Ignore)
                && hit.collider.GetComponentInParent<PlayerDefense>() == null && hit.collider.GetComponentInParent<MonsterDummy>() == null && hit.normal.y < 0.6f)
                dir = Vector3.ProjectOnPlane(dir, new Vector3(hit.normal.x, 0, hit.normal.z)).normalized;
            transform.position += dir * step;
            Face(dir);
        }

        void Face(Vector3 dir) { if (dir.sqrMagnitude > 1e-4f) transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(dir), 720f * Time.deltaTime); }
        void Warp(Vector3 at) => transform.position = new Vector3(at.x, transform.position.y, at.z);

        void LateUpdate()
        {
            Vector3 moved = transform.position - _lastPos;
            if (moved.sqrMagnitude > 0f) foreach (var f in followers) if (f != null) f.position += moved;
            _lastPos = transform.position;
        }

        static Vector3 Flat(Vector3 v) { v.y = 0; return v; }
    }
}
