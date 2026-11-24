using System;
using UnityEngine;

namespace Ascend.Game
{
    /// <summary>
    /// A dropped item lying in the world: it hops out of the fallen monster, rests on the ground, glows and bobs. Walk over it
    /// to take it. Nothing is lost by walking away in play: after <see cref="AutoCollectSec"/> it comes to you by itself.
    /// </summary>
    public sealed class LootPickup : MonoBehaviour
    {
        public const float PickupRadius = 1.6f, ArmSec = 0.5f, AutoCollectSec = 90f;

        public string ItemId { get; private set; }
        public int Count { get; private set; }

        Transform _taker;
        Action<LootPickup> _onTaken;
        Vector3 _from, _rest;
        float _age;

        /// <summary>Drops an item at a spot. <paramref name="onTaken"/> runs once, when <paramref name="taker"/> picks it up.</summary>
        public static LootPickup Spawn(string itemId, int count, Vector3 at, Transform taker, Color glow, Action<LootPickup> onTaken)
        {
            var go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            go.name = "Loot_" + itemId;
            Destroy(go.GetComponent<Collider>());
            go.transform.localScale = Vector3.one * 0.28f;
            var r = go.GetComponent<Renderer>();
            r.material = new Material(Shader.Find("Universal Render Pipeline/Unlit") ?? Shader.Find("Sprites/Default"));
            r.material.color = glow;
            r.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
            var p = go.AddComponent<LootPickup>();
            p.ItemId = itemId; p.Count = count; p._taker = taker; p._onTaken = onTaken;
            p._from = at + Vector3.up * 0.6f;
            var side = UnityEngine.Random.insideUnitCircle.normalized * 0.7f;
            p._rest = Ground(at + new Vector3(side.x, 0f, side.y));
            go.transform.position = p._from;
            return p;
        }

        /// <summary>The ground under a spot, ignoring triggers and creatures; the spot itself when nothing is below.</summary>
        static Vector3 Ground(Vector3 at)
        {
            float best = float.NegativeInfinity;
            foreach (var h in Physics.RaycastAll(at + Vector3.up * 1.5f, Vector3.down, 6f, ~0, QueryTriggerInteraction.Ignore))
            {
                if (h.collider is CharacterController || h.collider.GetComponentInParent<MonsterDummy>() != null) continue;
                best = Mathf.Max(best, h.point.y);
            }
            return new Vector3(at.x, float.IsNegativeInfinity(best) ? at.y : best, at.z);
        }

        void Update()
        {
            _age += Time.deltaTime;
            float t = Mathf.Clamp01(_age / ArmSec);
            transform.position = Vector3.Lerp(_from, _rest + Vector3.up * 0.3f, t) + Vector3.up * (Mathf.Sin(t * Mathf.PI) * 0.6f + (t >= 1f ? Mathf.Sin(_age * 3f) * 0.06f : 0f));
            if (t < 1f || _taker == null) return;
            var health = _taker.GetComponent<PlayerDefense>();
            if (health != null && health.IsDead) return;
            Vector3 d = _taker.position - transform.position;
            float up = Mathf.Abs(d.y); d.y = 0f;
            if ((d.magnitude <= PickupRadius && up < 2.5f) || _age >= AutoCollectSec) Take();
        }

        /// <summary>Takes everything still on the ground, so saving and leaving loses nothing.</summary>
        public static void CollectAll()
        {
            foreach (var p in FindObjectsByType<LootPickup>(FindObjectsSortMode.None)) p.Take();
        }

        void Take()
        {
            var done = _onTaken;
            _onTaken = null;
            done?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
