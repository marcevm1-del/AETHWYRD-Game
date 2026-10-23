using System;
using System.Collections.Generic;
using Ascend.Core;
using UnityEngine;

namespace Ascend.Game
{
    /// <summary>
    /// A travelling hitbox: sword waves (Air Slash: straight, piercing) and thrown items (Fire Bomb: arcing, bursting
    /// on contact or on the ground). Game time, so hit-stop freezes it. Each monster is hit at most once.
    /// </summary>
    public sealed class CombatProjectile : MonoBehaviour
    {
        Vector3 _velocity;
        float _gravity, _radius, _explodeRadius, _rangeLeft;
        bool _pierce, _done;
        Action<MonsterDummy, Vector3> _onHit;
        readonly HashSet<MonsterDummy> _hit = new HashSet<MonsterDummy>();
        static readonly Collider[] Overlap = new Collider[32];

        public static int Live { get; private set; }

        public static CombatProjectile Launch(Vector3 from, Vector3 velocity, float range, float radius, float gravity, bool pierce,
            float explodeRadius, PlayerCombat owner, Action<MonsterDummy, Vector3> onHit)
        {
            var go = GameObject.CreatePrimitive(explodeRadius > 0 ? PrimitiveType.Sphere : PrimitiveType.Cube);
            go.name = explodeRadius > 0 ? "FireBomb" : "SwordWave";
            UnityEngine.Object.Destroy(go.GetComponent<Collider>());
            go.transform.position = from;
            go.transform.localScale = explodeRadius > 0 ? Vector3.one * 0.3f : new Vector3(1.6f, 0.08f, 0.25f);
            if (velocity.sqrMagnitude > 0.01f) go.transform.rotation = Quaternion.LookRotation(velocity);
            var r = go.GetComponent<Renderer>();
            r.material = new Material(Shader.Find("Universal Render Pipeline/Unlit") ?? Shader.Find("Sprites/Default"));
            r.material.color = explodeRadius > 0 ? new Color(1f, 0.45f, 0.1f) : new Color(0.75f, 1f, 0.9f);
            var p = go.AddComponent<CombatProjectile>();
            p._velocity = velocity; p._gravity = gravity; p._radius = radius; p._pierce = pierce;
            p._explodeRadius = explodeRadius; p._rangeLeft = range; p._onHit = onHit;
            return p;
        }

        void OnEnable() => Live++;
        void OnDisable() => Live--;

        void Update()
        {
            float dt = Time.deltaTime;
            if (_done || dt <= 0f) return;
            _velocity.y -= _gravity * dt;
            Vector3 step = _velocity * dt;
            transform.position += step;
            _rangeLeft -= step.magnitude;
            if (_velocity.sqrMagnitude > 0.01f) transform.rotation = Quaternion.LookRotation(_velocity);

            int n = Physics.OverlapSphereNonAlloc(transform.position, _radius, Overlap, ~0, QueryTriggerInteraction.Ignore);
            for (int i = 0; i < n; i++)
            {
                var m = Overlap[i].GetComponentInParent<MonsterDummy>();
                if (m == null || m.IsDead || _hit.Contains(m)) continue;
                if (_explodeRadius > 0f) { Explode(); return; }
                _hit.Add(m);
                _onHit?.Invoke(m, Overlap[i].ClosestPoint(transform.position));
                if (!_pierce) { Finish(); return; }
            }
            if (_explodeRadius > 0f && (transform.position.y <= 0.15f)) { Explode(); return; }
            if (_rangeLeft <= 0f) Finish();
        }

        void Explode()
        {
            int n = Physics.OverlapSphereNonAlloc(transform.position, _explodeRadius, Overlap, ~0, QueryTriggerInteraction.Ignore);
            for (int i = 0; i < n; i++)
            {
                var m = Overlap[i].GetComponentInParent<MonsterDummy>();
                if (m == null || m.IsDead || !_hit.Add(m)) continue;
                _onHit?.Invoke(m, Overlap[i].ClosestPoint(transform.position));
            }
            CameraShake.Kick(HitWeight.Medium);
            Finish();
        }

        void Finish() { _done = true; Destroy(gameObject); }
    }

    /// <summary>
    /// Firestorm (Fire + Wind, combat.md §7): a spinning ring of fire that burns every monster inside each tick.
    /// Zone damage carries no element, so it can't chain new reactions.
    /// </summary>
    public sealed class FirestormZone : MonoBehaviour
    {
        PlayerCombat _owner;
        FirestormTuning _t;
        float _age, _nextTick;
        LineRenderer _ring;
        static readonly Collider[] Overlap = new Collider[32];

        public int Ticks { get; private set; }
        public static int Live { get; private set; }

        public static FirestormZone Spawn(Vector3 at, PlayerCombat owner, FirestormTuning tuning)
        {
            var go = new GameObject("Firestorm");
            go.transform.position = new Vector3(at.x, 0.05f, at.z);
            var z = go.AddComponent<FirestormZone>();
            z._owner = owner; z._t = tuning; z._nextTick = (float)tuning.TickSec;
            z._ring = go.AddComponent<LineRenderer>();
            z._ring.loop = true; z._ring.positionCount = 48; z._ring.useWorldSpace = false; z._ring.widthMultiplier = 0.15f;
            z._ring.material = new Material(Shader.Find("Universal Render Pipeline/Unlit") ?? Shader.Find("Sprites/Default"));
            z._ring.startColor = z._ring.endColor = new Color(1f, 0.4f, 0.05f);
            return z;
        }

        void OnEnable() => Live++;
        void OnDisable() => Live--;

        void Update()
        {
            float dt = Time.deltaTime;
            if (dt <= 0f) return;
            _age += dt;
            float r = (float)_t.RadiusM * Mathf.Min(1f, _age / 0.25f);
            for (int i = 0; i < _ring.positionCount; i++)
            {
                float a = i / (float)_ring.positionCount * Mathf.PI * 2f + _age * 4f;
                float wobble = 1f + 0.06f * Mathf.Sin(a * 5f + _age * 10f);
                _ring.SetPosition(i, new Vector3(Mathf.Cos(a) * r * wobble, 0.1f + 0.3f * Mathf.Abs(Mathf.Sin(a * 3f + _age * 6f)), Mathf.Sin(a) * r * wobble));
            }
            if (_age >= _nextTick)
            {
                _nextTick += (float)_t.TickSec;
                Ticks++;
                int n = Physics.OverlapSphereNonAlloc(transform.position, (float)_t.RadiusM, Overlap, ~0, QueryTriggerInteraction.Ignore);
                var seen = new HashSet<MonsterDummy>();
                for (int i = 0; i < n; i++)
                {
                    var m = Overlap[i].GetComponentInParent<MonsterDummy>();
                    if (m == null || m.IsDead || !seen.Add(m) || _owner == null) continue;
                    _owner.ApplyHit(m, m.transform.position, _t.TickPower, HitWeight.Light, Element.Fire, false, 0.2);
                }
            }
            if (_age >= _t.DurationSec) Destroy(gameObject);
        }
    }

    /// <summary>"FIRESTORM!" text over a reaction (combat.md §11 feedback).</summary>
    public sealed class ReactionPopup : MonoBehaviour
    {
        float _age;
        TextMesh _text;

        public static void Spawn(Vector3 at, Reaction r)
        {
            var go = new GameObject("ReactionPopup");
            go.transform.position = at;
            var tm = go.AddComponent<TextMesh>();
            tm.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
            go.GetComponent<MeshRenderer>().sharedMaterial = tm.font.material;
            tm.text = r.ToString().ToUpperInvariant() + "!";
            tm.fontSize = 72; tm.characterSize = 0.05f; tm.fontStyle = FontStyle.Bold;
            tm.anchor = TextAnchor.MiddleCenter;
            tm.color = r == Reaction.Firestorm ? new Color(1f, 0.55f, 0.1f) : new Color(0.7f, 0.9f, 1f);
            go.AddComponent<ReactionPopup>()._text = tm;
        }

        void Update()
        {
            _age += Time.unscaledDeltaTime;
            transform.position += Vector3.up * Time.unscaledDeltaTime * 0.6f;
            if (Camera.main != null) transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position);
            if (_age > 1.2f) Destroy(gameObject);
        }
    }
}
