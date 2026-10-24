using Ascend.Core;
using UnityEngine;

namespace Ascend.Game
{
    /// <summary>
    /// Procedural animation for unrigged Ring 0 monsters (until rigs and clips land; 08_Bestiary/monster_motion_bible.md
    /// and each species' motion.json signature). It moves a "Visual" pivot under the monster, never the root, so the
    /// collider, AI and physics are untouched. Style by rig family:
    ///   blob   — breathing wobble, squash → stretch → arc → land-squash hops, squash low to wind up, stretch to strike
    ///   biped  — hunched posture, walk bob and sway, lean with speed, pull back to wind up, lunge to strike
    ///   quad   — hops in bursts, sits up to listen when idle, crouches horn-down to wind up, stretches into a dash
    ///   flyer  — hovers and bobs (spirits float low), pitches forward and banks when moving, rises to wind up, dives to
    ///            strike, flutters down on death (wyverns and dragons land to fight, so they keep their ground style)
    /// Every style: recoil on hits, a wobble while staggered, a tumble in the air, and a death collapse before vanishing.
    /// Uses game time, so hit-stop freezes the pose and Flash Time slows it.
    /// </summary>
    [RequireComponent(typeof(MonsterDummy))]
    public sealed class MonsterAnimator : MonoBehaviour
    {
        public enum Style { Blob, Biped, Quad, Flyer }

        public const float DeathSec = 0.6f;

        MonsterDummy _body;
        MonsterController _ai;
        Transform _visual;
        Vector3 _lastPos;
        float _speed, _phase, _t, _hitT = -1f, _deathT = -1f, _idleEvent, _playRate = 1f, _postureDeg;
        float _squashAmount = 1f, _hover, _lastYaw;

        public Style Kind { get; private set; } = Style.Biped;
        public Transform Visual => _visual;
        /// <summary>Current pose, for tests and debugging.</summary>
        public Vector3 PoseOffset => _visual != null ? _visual.localPosition - new Vector3(0f, _baseY, 0f) : Vector3.zero;
        public Vector3 PoseScale => _visual != null ? _visual.localScale : Vector3.one;
        public Quaternion PoseRotation => _visual != null ? _visual.localRotation : Quaternion.identity;

        void Awake()
        {
            _body = GetComponent<MonsterDummy>();
            _ai = GetComponent<MonsterController>();
            BuildVisualPivot();
            _body.Damaged += OnDamaged;
            _body.HideDelay = DeathSec;
        }

        void Start()
        {
            _lastPos = transform.position;
            _lastYaw = transform.eulerAngles.y;
            if (AscendData.Db.Motion.TryGetValue(_body.SpeciesId, out var m))
            {
                string rig = m.RigKey ?? "";
                bool flyer = m.Locomotion != null && m.Locomotion.Flies && !rig.Contains("dragon") && !rig.Contains("wyvern");
                Kind = flyer ? Style.Flyer
                     : rig.Contains("blob") || rig.Contains("amorphous") ? Style.Blob
                     : rig.StartsWith("quad") || rig.Contains("hexapod") || rig.Contains("arachnid") ? Style.Quad
                     : Style.Biped;
                // Spirits drift just off the ground; winged things hover at about sword height.
                if (Kind == Style.Flyer) _hover = rig.Contains("spirit") ? 0.25f : Mathf.Clamp(1.6f - (float)m.HeightM, 0.6f, 1.3f);
                _playRate = (float)(m.Locomotion?.PlayRate > 0 ? m.Locomotion.PlayRate : 1.0);
                _squashAmount = (float)(m.Menace?.SquashStretch > 0 ? m.Menace.SquashStretch : 1.0);
                string posture = m.Menace?.Posture ?? "";
                _postureDeg = posture.Contains("hunch") || posture.Contains("head_low") ? 18f : 0f;
            }
            _idleEvent = Random.Range(4f, 7f);
        }

        void OnDestroy() { if (_body != null) _body.Damaged -= OnDamaged; }

        void OnDamaged() { _hitT = 0f; }

        /// <summary>Moves every renderer under a feet-level "Visual" pivot (copying a root-level renderer onto it).</summary>
        void BuildVisualPivot()
        {
            _visual = new GameObject("Visual").transform;
            _visual.SetParent(transform, false);
            for (int i = transform.childCount - 1; i >= 0; i--)
            {
                var c = transform.GetChild(i);
                if (c == _visual || c.name.StartsWith("Telegraph") || c.GetComponentInChildren<Renderer>() == null) continue;
                c.SetParent(_visual, true);
            }
            var rootRenderer = GetComponent<MeshRenderer>();
            var rootFilter = GetComponent<MeshFilter>();
            if (rootRenderer != null && rootFilter != null)
            {
                var copy = new GameObject("Mesh");
                copy.transform.SetParent(_visual, false);
                copy.AddComponent<MeshFilter>().sharedMesh = rootFilter.sharedMesh;
                copy.AddComponent<MeshRenderer>().sharedMaterials = rootRenderer.sharedMaterials;
                DestroyImmediate(rootRenderer); // now, so MonsterDummy never caches a dying renderer
                DestroyImmediate(rootFilter);
            }
            // Pivot at the feet: a primitive's root sits at its centre, a model's root at its feet.
            var col = GetComponent<Collider>();
            float feet = col != null ? col.bounds.min.y - transform.position.y : 0f;
            _visual.localPosition = Vector3.zero;
            foreach (Transform c in _visual) c.localPosition -= new Vector3(0f, feet / Mathf.Max(0.0001f, transform.lossyScale.y), 0f);
            _visual.localPosition = new Vector3(0f, feet / Mathf.Max(0.0001f, transform.lossyScale.y), 0f);
            _baseY = _visual.localPosition.y;
            _body.RefreshRenderers();
        }

        float _baseY;

        void Update()
        {
            float dt = Time.deltaTime;
            if (dt <= 0f || _visual == null) return;
            float adt = dt * _playRate;
            _t += adt;

            Vector3 d = transform.position - _lastPos; d.y = 0f;
            _speed = Mathf.Lerp(_speed, d.magnitude / dt, 1f - Mathf.Exp(-12f * dt));
            _lastPos = transform.position;
            float yaw = transform.eulerAngles.y;
            float turn = Mathf.DeltaAngle(_lastYaw, yaw) / dt;
            _lastYaw = yaw;

            Vector3 pos = Vector3.zero, scale = Vector3.one;
            Vector3 euler = new Vector3(_postureDeg, 0f, 0f);

            if (_body.IsDead)
            {
                if (_deathT < 0f) _deathT = 0f;
                _deathT += dt;
                Death(Mathf.Clamp01(_deathT / DeathSec), ref pos, ref scale, ref euler);
                Apply(pos, scale, euler);
                return;
            }
            _deathT = -1f;

            var state = _ai != null && _ai.Brain != null ? _ai.Brain.State : AiState.Idle;
            float windup = _ai != null && _ai.Brain != null ? (float)_ai.Brain.WindupProgress : 0f;

            if (_body.IsAirborne)
            {
                euler.x += _t * 540f; // juggled: tumble
            }
            else switch (state)
            {
                case AiState.Windup: Windup(windup, ref pos, ref scale, ref euler); break;
                case AiState.Active: Strike(ref pos, ref scale, ref euler); break;
                case AiState.Recovery: euler.x += 8f * Mathf.Sin(_t * 18f); break;
                case AiState.Staggered: euler.z += 10f * Mathf.Sin(_t * 22f); euler.x -= 10f; break;
                default:
                    if (_speed > 0.15f) Move(adt, ref pos, ref scale, ref euler);
                    else Idle(adt, ref pos, ref scale, ref euler);
                    break;
            }

            if (_hitT >= 0f)
            {
                _hitT += dt;
                float k = Mathf.Exp(-_hitT * 9f);
                euler.x -= 22f * k;                              // recoil away
                scale += new Vector3(0.12f, -0.15f, 0.12f) * k * _squashAmount;
                if (_hitT > 0.6f) _hitT = -1f;
            }
            if (Kind == Style.Flyer && !_body.IsDead)
            {
                pos.y += _hover + 0.08f * Mathf.Sin(_t * Mathf.PI * 2f / 1.2f); // hover and bob
                euler.z -= Mathf.Clamp(turn * 0.08f, -35f, 35f);              // bank into turns
            }
            Apply(pos, scale, euler);
        }

        void Apply(Vector3 pos, Vector3 scale, Vector3 euler)
        {
            _visual.localPosition = new Vector3(pos.x, _baseY + pos.y, pos.z);
            _visual.localScale = new Vector3(Mathf.Max(0.05f, scale.x), Mathf.Max(0.05f, scale.y), Mathf.Max(0.05f, scale.z));
            _visual.localRotation = Quaternion.Euler(euler);
        }

        // ---------------------------------------------------------------- states
        void Idle(float adt, ref Vector3 pos, ref Vector3 scale, ref Vector3 euler)
        {
            switch (Kind)
            {
                case Style.Blob:
                    float breathe = 0.04f * (0.5f + 0.5f * Mathf.Sin(_t * Mathf.PI * 2f / 1.5f));
                    scale = new Vector3(1f + breathe * 0.5f, 1f + breathe, 1f + breathe * 0.5f);
                    break;
                case Style.Biped:
                    euler.z = 3f * Mathf.Sin(_t * Mathf.PI * 2f / 2.5f); // weight shift foot to foot
                    break;
                case Style.Flyer:
                    euler.z = 6f * Mathf.Sin(_t * Mathf.PI * 2f / 0.9f); // drift side to side
                    break;
                case Style.Quad:
                    _idleEvent -= adt;
                    if (_idleEvent < 0f && _idleEvent > -1.2f) euler.x -= 25f * Mathf.Sin(Mathf.Clamp01(-_idleEvent / 1.2f) * Mathf.PI); // sit up to listen
                    else if (_idleEvent <= -1.2f) _idleEvent = Random.Range(5f, 8f);
                    break;
            }
        }

        void Move(float adt, ref Vector3 pos, ref Vector3 scale, ref Vector3 euler)
        {
            switch (Kind)
            {
                case Style.Blob:
                {
                    _phase = (_phase + _speed * adt / 0.6f) % 1f; // one hop per 0.6 m
                    float p = _phase, s = _squashAmount * 0.35f;
                    if (p < 0.15f) { float k = p / 0.15f; scale = new Vector3(1f + s * k * 0.6f, 1f - s * k, 1f + s * k * 0.6f); }
                    else if (p < 0.25f) scale = new Vector3(1f - s * 0.4f, 1f + s * 1.2f, 1f - s * 0.4f);
                    else if (p < 0.85f) pos.y = 0.15f * Mathf.Sin((p - 0.25f) / 0.6f * Mathf.PI);
                    else { float k = 1f - (p - 0.85f) / 0.15f; scale = new Vector3(1f + s * k * 0.7f, 1f - s * k, 1f + s * k * 0.7f); }
                    break;
                }
                case Style.Biped:
                {
                    _phase = (_phase + _speed * adt / 1.1f) % 1f; // one stride per 1.1 m
                    float step = Mathf.Sin(_phase * Mathf.PI * 2f);
                    pos.y = 0.04f * Mathf.Abs(step) * Mathf.Min(1f, _speed / 2f);
                    euler.z = 6f * step;
                    euler.x += Mathf.Lerp(0f, 35f - _postureDeg, Mathf.Clamp01(_speed / 5f)); // lean with speed
                    break;
                }
                case Style.Flyer:
                    euler.x += Mathf.Lerp(0f, 25f, Mathf.Clamp01(_speed / 4f)); // pitch into the flight
                    break;
                case Style.Quad:
                {
                    _phase = (_phase + _speed * adt / 0.9f) % 1f; // one bound per 0.9 m
                    pos.y = 0.18f * Mathf.Sin(_phase * Mathf.PI);
                    euler.x = Mathf.Lerp(12f, -12f, _phase);
                    scale = new Vector3(1f, 1f, 1f + 0.12f * Mathf.Sin(_phase * Mathf.PI));
                    break;
                }
            }
        }

        void Windup(float p, ref Vector3 pos, ref Vector3 scale, ref Vector3 euler)
        {
            float e = p * p * (3f - 2f * p); // ease in/out
            switch (Kind)
            {
                case Style.Blob: scale = new Vector3(1f + 0.25f * e * _squashAmount, 1f - 0.4f * e * _squashAmount, 1f + 0.25f * e * _squashAmount); break;
                case Style.Biped: euler.x -= 25f * e; pos.z = -0.12f * e; euler.y = -15f * e; break; // pull the blade back
                case Style.Quad: scale = new Vector3(1f, 1f - 0.2f * e, 1f + 0.05f * e); euler.x += 12f * e; break; // crouch, horn down
                case Style.Flyer: pos.y = 0.4f * e; euler.x -= 30f * e; pos.z = -0.2f * e; break; // rise and rear back
            }
            pos.x = 0.015f * Mathf.Sin(_t * 70f) * e; // a tremble that grows to the strike
        }

        void Strike(ref Vector3 pos, ref Vector3 scale, ref Vector3 euler)
        {
            switch (Kind)
            {
                case Style.Blob: scale = new Vector3(0.8f, 1.1f, 1.45f); pos.z = 0.25f; break;
                case Style.Biped: euler.x += 30f; pos.z = 0.3f; euler.y = 20f; break;
                case Style.Quad: scale = new Vector3(0.9f, 0.9f, 1.35f); euler.x += 15f; pos.z = 0.3f; break;
                case Style.Flyer: pos.y = -_hover * 0.6f; euler.x += 40f; pos.z = 0.4f; break; // dive at the target
            }
        }

        void Death(float p, ref Vector3 pos, ref Vector3 scale, ref Vector3 euler)
        {
            switch (Kind)
            {
                case Style.Blob: scale = new Vector3(1f + 0.6f * p, Mathf.Lerp(1f, 0.08f, p), 1f + 0.6f * p); break; // splats
                case Style.Flyer: pos.y = _hover * (1f - p * p); euler.z = 200f * p; break;                        // flutters down
                default: euler.z = 90f * (p * p); pos.y = -0.1f * p; break;                                         // topples
            }
        }
    }
}
