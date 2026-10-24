using Ascend.Core;
using UnityEngine;

namespace Ascend.Game
{
    /// <summary>Money dropped at a death spot (Adventurer and Veteran): a glowing blue lantern; walk over it to recover it.</summary>
    public sealed class CoinLantern : MonoBehaviour
    {
        public const float PickupRadius = 1.3f;
        public long Copper { get; private set; }

        public static CoinLantern Spawn(Vector3 at, long copper)
        {
            var go = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            go.name = "CoinLantern";
            Destroy(go.GetComponent<Collider>());
            go.transform.position = at + Vector3.up * 0.5f;
            go.transform.localScale = new Vector3(0.3f, 0.35f, 0.3f);
            var r = go.GetComponent<Renderer>();
            r.material = new Material(Shader.Find("Universal Render Pipeline/Unlit") ?? Shader.Find("Sprites/Default"));
            r.material.color = new Color(0.4f, 0.75f, 1f);
            var l = go.AddComponent<CoinLantern>();
            l.Copper = copper;
            return l;
        }

        void Update()
        {
            transform.position += Vector3.up * Mathf.Sin(Time.time * 2f) * 0.002f;
            var inv = FindFirstObjectByType<PlayerInventory>();
            if (inv == null) return;
            var resp = inv.GetComponent<PlayerRespawn>();
            if (resp != null && resp.IsDead) return;
            Vector3 d = inv.transform.position - transform.position; d.y = 0;
            if (d.magnitude > PickupRadius) return;
            inv.Items.AddCopper(Copper);
            inv.Toast($"Recovered {Money.Format(Copper, AscendData.Db.World.Currency)}");
            Destroy(gameObject);
        }
    }
}
