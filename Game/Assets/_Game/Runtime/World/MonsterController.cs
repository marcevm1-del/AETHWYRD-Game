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
            _tokenId = $"{_body.SpeciesId}#{_id}";
            _body.Staggered += OnStaggered;
            BuildTelegraph();
        }

        void OnDestroy()
        {
            if (_body != null) _body.Staggered -= OnStaggered;
            ReleaseToken();
        }

        void OnStaggered() { _brain?.Stagger(); ReleaseToken(); }

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

            Vector3 toPlayer = _player.transform.position - transform.position; toPlayer.y = 0;
            Vector3 toHome = _home - transform.position; toHome.y = 0;
            bool hasToken = _holdsToken || AggroDirector.Tokens.Holders.Count < AggroDirector.Tokens.Capacity;
            var cmd = _brain.Tick(dt, new AiSense
            {
                DistanceToPlayer = toPlayer.magnitude, DistanceFromHome = toHome.magnitude,
                HpFraction = _body.MaxHp > 0 ? _body.Hp / (double)_body.MaxHp : 1, HasToken = hasToken,
            });
            if (_brain.State == AiState.Windup && !_holdsToken) _holdsToken = AggroDirector.Tokens.TryTake(_tokenId);
            if (cmd.ReleaseToken) ReleaseToken();

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
            transform.position += dir * (float)cmd.Speed * dt;
            if (cmd.Move != AiMove.Circle && !cmd.Face) transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(dir), _turnSpeed * dt);
        }

        void Strike(Vector3 toPlayer)
        {
            var atk = _brain.CurrentAttack; var t = _brain.CurrentTiming;
            if (atk == null || t == null) return;
            Strikes++;
            // Gap-closers lunge their reach toward the player before the hit check.
            if (MonsterBrain.IsGapCloser(t.Kind) && toPlayer.magnitude > 1.2f)
            {
                transform.position += toPlayer.normalized * Mathf.Max(0f, toPlayer.magnitude - 1.0f);
                toPlayer = _player.transform.position - transform.position; toPlayer.y = 0;
            }
            bool ranged = MonsterBrain.IsRanged(t.Kind);
            float reach = ranged ? (float)MonsterBrain.RangedMax : (float)(_brain.ReachOf(t) + 0.35);
            float arc = t.Kind == "aoe" ? 360f : ranged ? 30f : 100f;
            if (toPlayer.magnitude > reach || Vector3.Angle(transform.forward, toPlayer) > arc * 0.5f) return;
            int def = _playerCombat != null ? _playerCombat.Stats.Def : 10;
            var species = AscendData.Db.Species[_body.SpeciesId];
            var dmg = _calc.Compute(new DamageInput { Kind = DamageKind.Physical, Attack = species.Stats.Atk, Defense = def, Power = atk.Power }, _rng);
            _player.ReceiveAttack(dmg.Amount, _brain.CurrentTelegraph, _body);
        }

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
