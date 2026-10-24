using Ascend.Core;
using UnityEngine;

namespace Ascend.Game
{
    /// <summary>The scene's shared aggro tokens (combat.md §10: at most `ai.maxSimultaneousAttackers` attack at once).</summary>
    public static class AggroDirector
    {
        static AggroTokens _tokens;
        public static AggroTokens Tokens => _tokens ??= new AggroTokens(AscendData.Db.Tuning.Ai.MaxSimultaneousAttackers);
        public static void Reset() => _tokens = null;
    }

    /// <summary>
    /// Drives a MonsterDummy with a Core MonsterBrain: moves and turns the body (graybox: straight-line movement on
    /// the ground plane), shows the telegraph (a coloured "!" and a ring that shrinks to nothing as the strike
    /// lands: the speed cue, market research A5), and resolves strikes against the player's PlayerDefense.
    /// Monster time is game time, so hit-stop freezes it and Flash Time slows it.
    /// </summary>
    [RequireComponent(typeof(MonsterDummy))]
    public sealed class MonsterController : MonoBehaviour
    {
        const float RingStartRadius = 1.6f, RingEndRadius = 0.2f;

        [SerializeField] ulong seed = 11;
        static int _nextId;
        int _id;

        MonsterDummy _body;
        MonsterBrain _brain;
        PlayerDefense _player;
        PlayerCombat _playerCombat;
        DamageCalculator _calc;
        IRandom _rng;
        Vector3 _home;
        float _turnSpeed;
        bool _holdsToken;
        LineRenderer _ring;
        TextMesh _alert;
        string _tokenId;
        AiState _lastState;

        public MonsterBrain Brain => _brain;
        public bool HoldsToken => _holdsToken;
        public int Strikes { get; private set; }

        void Start()
        {
            _body = GetComponent<MonsterDummy>();
            var db = AscendData.Db;
            if (!db.Species.TryGetValue(_body.SpeciesId, out var species) || !db.Motion.TryGetValue(_body.SpeciesId, out var motion))
            { enabled = false; return; }
            _id = ++_nextId;
            _rng = new DeterministicRandom(seed + (ulong)_id);
            _brain = new MonsterBrain(species, motion, db.Attacks, _rng);
            _calc = new DamageCalculator(db.Tuning.Damage);
            _home = transform.position;
            _turnSpeed = Mathf.Max(90f, (float)motion.NavAgent.AngularSpeed);
            _dashSpeed = (float)System.Math.Max(motion.NavAgent.Speed * 1.3, 6.0); // charges run faster than the chase gait
            _tokenId = $"{_body.SpeciesId}#{_id}";
            _body.Staggered += OnStaggered;
            _body.Landed += OnStaggered; // landing after a launch is a knockdown
            _body.Damaged += OnDamaged;
            _hopper = species.Behavior == "Skittish" || species.Behavior == "Ambush";
            BuildTelegraph();
        }

        void OnDestroy()
        {
            if (_body != null) { _body.Staggered -= OnStaggered; _body.Landed -= OnStaggered; _body.Damaged -= OnDamaged; }
            ReleaseToken();
        }

        void OnStaggered() { _brain?.Stagger(); ReleaseToken(); }

        // Reflex hop (after Project Greyborn's combatReflexes): skittish and ambushing monsters, badly hurt and just hit,
        // sometimes leap back out of reach.
        public const float HopChance = 0.25f, HopHpFraction = 0.4f, HopDistance = 2.5f, HopSec = 0.25f;
        bool _hopper;
        Vector3 _hopVelocity;
        float _hopLeft;
        public int Hops { get; private set; }

        void OnDamaged()
        {
            if (!_hopper || _body.IsDead || _player == null || _hopLeft > 0f || IsDashing) return;
            if (_body.Hp > _body.MaxHp * HopHpFraction || _rng.NextDouble() >= HopChance) return;
            Vector3 away = Flat(transform.position - _player.transform.position);
            if (away.sqrMagnitude < 1e-4f) away = -transform.forward;
            _hopVelocity = away.normalized * (HopDistance / HopSec);
            _hopLeft = HopSec;
            Hops++;
        }

        void Update()
        {
            if (_brain == null) return;
            if (_body.IsDead) { ReleaseToken(); ShowTelegraph(false); return; }
            if (_player == null)
            {
                _player = FindFirstObjectByType<PlayerDefense>();
                _playerCombat = _player != null ? _player.GetComponent<PlayerCombat>() : null;
                if (_player == null) return;
            }
            float dt = Time.deltaTime;
            if (dt <= 0f) return; // hit-stop
            if (_player.IsDead) { ReleaseToken(); ShowTelegraph(false); return; } // the player has fallen: stand down
            if (_body.IsAirborne) { ReleaseToken(); ShowTelegraph(false); return; } // juggled: no thinking in the air

            // Target: you, unless a partner draws it (a Vanguard close by, or a partner fighting it that's closer than you).
            _partnerTarget = PickPartnerTarget();
            Vector3 targetPos = _partnerTarget != null ? _partnerTarget.transform.position : _player.transform.position;
            Vector3 toPlayer = targetPos - transform.position; toPlayer.y = 0;
            Vector3 toHome = _home - transform.position; toHome.y = 0;
            bool hasToken = _holdsToken || AggroDirector.Tokens.Holders.Count < AggroDirector.Tokens.Capacity;
            var cmd = _brain.Tick(dt, new AiSense
            {
                DistanceToPlayer = toPlayer.magnitude, DistanceFromHome = toHome.magnitude,
                HpFraction = _body.MaxHp > 0 ? _body.Hp / (double)_body.MaxHp : 1, HasToken = hasToken,
            });
            if (_brain.State == AiState.Windup && !_holdsToken) _holdsToken = AggroDirector.Tokens.TryTake(_tokenId);
            if (_brain.State == AiState.Windup && _lastState != AiState.Windup) CombatFx.Play(CombatFx.Sfx.Telegraph, transform.position, 0.6f);
            _lastState = _brain.State;
            if (cmd.ReleaseToken) ReleaseToken();
            if (_brain.State != AiState.Staggered) IsStuck = false;

            if (_hopLeft > 0f) { _hopLeft -= dt; transform.position += Blocked(_hopVelocity.normalized, _hopVelocity.magnitude * dt); UpdateTelegraph(); return; }
            if (IsDashing) { DashStep(dt); UpdateTelegraph(); return; }
            if (IsStuck) { UpdateTelegraph(); return; }
            if (MarchTarget.HasValue && (_brain.State == AiState.Idle || _brain.State == AiState.Return) && !Arrived)
            {
                Vector3 to = Flat(MarchTarget.Value - transform.position);
                float speed = Mathf.Max(1.5f, (float)AscendData.Db.Motion[_body.SpeciesId].NavAgent.WalkSpeed);
                transform.position += Blocked(to.normalized, speed * dt);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(to), _turnSpeed * dt);
                _home = transform.position; // the leash travels with the march
                UpdateTelegraph();
                return;
            }
            Move(cmd, toPlayer, toHome, dt);
            if (cmd.Face && toPlayer.sqrMagnitude > 1e-4f)
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(toPlayer), _turnSpeed * dt);
            if (cmd.StrikeNow) Strike(toPlayer);
            UpdateTelegraph();
        }

        void Move(AiCommand cmd, Vector3 toPlayer, Vector3 toHome, float dt)
        {
            Vector3 dir = Vector3.zero;
            switch (cmd.Move)
            {
                case AiMove.Toward: dir = toPlayer.normalized; break;
                case AiMove.Away: dir = -toPlayer.normalized; break;
                case AiMove.Home: dir = toHome.normalized; break;
                case AiMove.Circle: dir = Vector3.Cross(Vector3.up, toPlayer).normalized; break;
            }
            if (dir.sqrMagnitude < 1e-4f) return;
            dir = Unstick(dir, dt);
            transform.position += Blocked(dir, (float)cmd.Speed * dt);
            if (cmd.Move != AiMove.Circle && !cmd.Face) transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(dir), _turnSpeed * dt);
        }

        // Unsticking (ported from Project Greyborn's bot AI, game/src/sim/botAI.ts goTo): a monster that wants to move
        // but has barely moved for StuckAfterSec walks sideways for a moment, which takes it round a wall it hit head-on.
        public const float StuckAfterSec = 1.5f, SidestepSec = 1.2f;
        Vector3 _unstickFrom;
        float _stuckFor, _sidestepLeft;
        int _sidestepSign = 1;
        public bool Sidestepping => _sidestepLeft > 0f;

        Vector3 Unstick(Vector3 dir, float dt)
        {
            if (_sidestepLeft > 0f)
            {
                _sidestepLeft -= dt;
                return Vector3.Cross(Vector3.up, dir).normalized * _sidestepSign;
            }
            if (Flat(transform.position - _unstickFrom).magnitude < 0.05f) _stuckFor += dt;
            else { _stuckFor = 0f; _unstickFrom = transform.position; }
            if (_stuckFor >= StuckAfterSec)
            {
                _stuckFor = 0f;
                _sidestepLeft = SidestepSec;
                _sidestepSign = -_sidestepSign; // alternate sides, so a second try goes the other way
            }
            return dir;
        }

        /// <summary>
        /// The strike, by attack kind (motion bible / species signatures):
        ///   ranged / magic → a projectile that travels (dodge or parry it as it arrives)
        ///   charge / leap  → a straight-line dash that can't turn; a miss into an obstacle leaves it stuck (punish window)
        ///   melee / heavy / grab / aoe → an immediate hit check in front (aoe all around)
        /// </summary>
        MonsterDummy _partnerTarget;
        public MonsterDummy PartnerTarget => _partnerTarget;

        MonsterDummy PickPartnerTarget()
        {
            MonsterDummy best = null; float bestD = float.MaxValue;
            float toPlayer = Vector3.Distance(Flat(_player.transform.position), Flat(transform.position));
            foreach (var f in PartnerFollower.ActiveFollowers)
            {
                if (f == null || f.Body == null || f.Body.IsDead) continue;
                float d = Vector3.Distance(Flat(f.transform.position), Flat(transform.position));
                bool draws = (f.Role == PartnerRole.Vanguard && d <= 6f) || (f.Target == _body && d < toPlayer);
                if (draws && d < bestD) { best = f.Body; bestD = d; }
            }
            return best;
        }

        void Strike(Vector3 toPlayer)
        {
            var atk = _brain.CurrentAttack; var t = _brain.CurrentTiming;
            if (atk == null || t == null) return;
            Strikes++;
            int damage = RollDamage(atk.Power);
            var telegraph = _brain.CurrentTelegraph;
            if (_partnerTarget != null)
            {
                // Partners don't parry or dodge (yet): ranged attacks and charges simply land if it's in reach.
                float partnerReach = MonsterBrain.IsRanged(t.Kind) ? 15f : MonsterBrain.IsGapCloser(t.Kind) ? DashMaxM : (float)(_brain.ReachOf(t) + 0.6);
                if (toPlayer.magnitude <= partnerReach) _partnerTarget.TakeHit(damage, HitWeight.Medium, transform.position, 3);
                return;
            }
            if (MonsterBrain.IsRanged(t.Kind))
            {
                MonsterProjectile.Launch(transform.position + Vector3.up * 0.8f + transform.forward * 0.5f, _player, damage, telegraph, _body,
                    t.Kind == "magic" ? MagicSpeed : ThrowSpeed);
                return;
            }
            if (MonsterBrain.IsGapCloser(t.Kind))
            {
                BeginDash(toPlayer.sqrMagnitude > 1e-4f ? toPlayer.normalized : transform.forward, Mathf.Min(DashMaxM, toPlayer.magnitude + 2f), damage, telegraph);
                return;
            }
            float reach = (float)(_brain.ReachOf(t) + 0.35);
            float arc = t.Kind == "aoe" ? 360f : 100f;
            if (toPlayer.magnitude > reach || Vector3.Angle(transform.forward, toPlayer) > arc * 0.5f) return;
            _player.ReceiveAttack(damage, telegraph, _body);
        }

        public const float ThrowSpeed = 13f, MagicSpeed = 10f, DashMaxM = 6f, StuckSec = 1.5f, DashContactM = 0.9f;
        Vector3 _dashDir;
        float _dashLeft;
        int _dashDamage;
        Telegraph _dashTelegraph;
        bool _dashHit;

        public bool IsDashing => _dashLeft > 0f;
        public bool IsStuck { get; private set; }

        /// <summary>Raiders march here when nothing has their attention, carrying their home (leash centre) with them.</summary>
        public Vector3? MarchTarget { get; set; }
        public bool Arrived => MarchTarget.HasValue && Flat(MarchTarget.Value - transform.position).magnitude < 2f;
        static Vector3 Flat(Vector3 v) { v.y = 0; return v; }

        /// <summary>Starts a straight-line charge: it can't turn, hits the player once on contact, and sticks in obstacles.</summary>
        public void BeginDash(Vector3 direction, float distance, int damage, Telegraph telegraph)
        {
            direction.y = 0f;
            _dashDir = direction.sqrMagnitude > 1e-4f ? direction.normalized : transform.forward;
            _dashLeft = Mathf.Max(0f, distance);
            _dashDamage = damage; _dashTelegraph = telegraph; _dashHit = false;
            transform.rotation = Quaternion.LookRotation(_dashDir);
        }

        /// <summary>The walkable part of a step: slides along walls, stops if fully blocked (monsters no longer pass through scenery).</summary>
        Vector3 Blocked(Vector3 dir, float distance)
        {
            var col = GetComponent<Collider>();
            Vector3 from = col != null ? col.bounds.center : transform.position + Vector3.up * 0.4f;
            float radius = col != null ? Mathf.Min(col.bounds.extents.x, col.bounds.extents.z) * 0.8f : 0.3f;
            Vector3 step = dir * distance;
            for (int i = 0; i < 2; i++)
            {
                if (!Wall(from, radius, step, out var hit)) return step;
                step = Vector3.ProjectOnPlane(step, new Vector3(hit.normal.x, 0f, hit.normal.z).normalized); // slide along it
                if (step.sqrMagnitude < 1e-6f) return Vector3.zero;
            }
            return Vector3.zero;
        }

        /// <summary>
        /// A wall in the way of this step. The sphere cast catches walls at body width; a sphere cast ignores anything it
        /// already overlaps, though, so a thin centre ray (reaching body-radius further) backs it up once a sliding body has
        /// brushed a wall — otherwise it could walk straight through it.
        /// </summary>
        static bool Wall(Vector3 from, float radius, Vector3 step, out RaycastHit hit)
        {
            Vector3 dir = step.normalized;
            if (Physics.SphereCast(from, radius, dir, out hit, step.magnitude + 0.05f, ~0, QueryTriggerInteraction.Ignore) && Solid(hit)) return true;
            return Physics.Raycast(from, dir, out hit, step.magnitude + radius + 0.05f, ~0, QueryTriggerInteraction.Ignore) && Solid(hit);
        }

        static bool Solid(RaycastHit hit) =>
            hit.collider.GetComponentInParent<MonsterDummy>() == null && hit.collider.GetComponentInParent<PlayerDefense>() == null
            && hit.normal.y <= 0.6f; // walkable ground isn't a wall

        int RollDamage(double power)
        {
            int def = _playerCombat != null ? _playerCombat.Stats.Def : 10;
            var species = AscendData.Db.Species[_body.SpeciesId];
            return _calc.Compute(new DamageInput { Kind = DamageKind.Physical, Attack = species.Stats.Atk, Defense = def, Power = power }, _rng).Amount;
        }

        /// <summary>Moves a dash one step: straight on, hits the player once on contact, sticks in obstacles.</summary>
        void DashStep(float dt)
        {
            float speed = Mathf.Max(6f, _dashSpeed);
            float step = Mathf.Min(_dashLeft, speed * dt);
            var col = GetComponent<Collider>();
            Vector3 chest = col != null ? col.bounds.center : transform.position + Vector3.up * 0.4f; // works for feet- and centre-pivoted bodies
            if (Physics.Raycast(chest, _dashDir, out var hit, step + 0.4f, ~0, QueryTriggerInteraction.Ignore)
                && hit.collider.GetComponentInParent<MonsterDummy>() == null && hit.collider.GetComponentInParent<PlayerDefense>() == null)
            {
                // Missed and ran into something solid: horn stuck in the wood (the rookie's punish window).
                _dashLeft = 0f;
                IsStuck = true;
                _brain.Stun(StuckSec);
                CombatFx.Play(CombatFx.Sfx.Block, transform.position);
                return;
            }
            transform.position += _dashDir * step;
            _dashLeft -= step;
            Vector3 toPlayer = _player.transform.position - transform.position; toPlayer.y = 0;
            if (!_dashHit && toPlayer.magnitude <= DashContactM)
            {
                _dashHit = true;
                _player.ReceiveAttack(_dashDamage, _dashTelegraph, _body);
            }
        }

        float _dashSpeed;

        void ReleaseToken()
        {
            if (!_holdsToken) return;
            AggroDirector.Tokens.Release(_tokenId);
            _holdsToken = false;
        }

        // ---------------------------------------------------------------- telegraph
        void BuildTelegraph()
        {
            var ringGo = new GameObject("TelegraphRing");
            ringGo.transform.SetParent(transform, false);
            _ring = ringGo.AddComponent<LineRenderer>();
            _ring.useWorldSpace = false; _ring.loop = true; _ring.positionCount = 40;
            _ring.widthMultiplier = 0.06f;
            _ring.material = new Material(Shader.Find("Universal Render Pipeline/Unlit") ?? Shader.Find("Sprites/Default"));
            var alertGo = new GameObject("TelegraphAlert");
            alertGo.transform.SetParent(transform, false);
            alertGo.transform.localPosition = Vector3.up * 1.6f;
            _alert = alertGo.AddComponent<TextMesh>();
            _alert.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
            alertGo.GetComponent<MeshRenderer>().sharedMaterial = _alert.font.material;
            _alert.text = "!"; _alert.fontSize = 96; _alert.characterSize = 0.05f; _alert.anchor = TextAnchor.LowerCenter; _alert.fontStyle = FontStyle.Bold;
            ShowTelegraph(false);
        }

        public static Color ColorOf(Telegraph t) =>
            t == Telegraph.Blue ? new Color(0.25f, 0.6f, 1f) : t == Telegraph.Red ? new Color(1f, 0.2f, 0.15f) : t == Telegraph.Gold ? new Color(1f, 0.8f, 0.2f) : Color.white;

        public bool TelegraphVisible => _ring != null && _ring.enabled;
        public float RingRadius { get; private set; }

        void ShowTelegraph(bool on)
        {
            if (_ring != null) _ring.enabled = on;
            if (_alert != null) _alert.gameObject.SetActive(on);
        }

        void UpdateTelegraph()
        {
            bool winding = _brain.State == AiState.Windup;
            ShowTelegraph(winding);
            if (!winding) return;
            var c = ColorOf(_brain.CurrentTelegraph);
            _ring.startColor = _ring.endColor = c;
            _alert.color = c;
            RingRadius = Mathf.Lerp(RingStartRadius, RingEndRadius, (float)_brain.WindupProgress);
            for (int i = 0; i < _ring.positionCount; i++)
            {
                float a = i / (float)_ring.positionCount * Mathf.PI * 2f;
                _ring.SetPosition(i, new Vector3(Mathf.Cos(a) * RingRadius, 0.05f - transform.position.y, Mathf.Sin(a) * RingRadius));
            }
            if (Camera.main != null) _alert.transform.rotation = Quaternion.LookRotation(_alert.transform.position - Camera.main.transform.position);
        }
    }
}
