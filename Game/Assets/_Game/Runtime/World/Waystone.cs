using UnityEngine;

namespace Ascend.Game
{
    /// <summary>A waystone (Canon: waystone respawns): walking up to it attunes it as your respawn point.</summary>
    public sealed class Waystone : MonoBehaviour
    {
        public const float AttuneRadius = 2.5f;
        public bool Attuned { get; private set; }
        public string Id => name;
        public void MarkAttuned(bool on) => Attuned = on;

        void Update()
        {
            if (Attuned) return;
            var resp = FindFirstObjectByType<PlayerRespawn>();
            if (resp == null) return;
            Vector3 d = resp.transform.position - transform.position; d.y = 0;
            if (d.magnitude > AttuneRadius) return;
            foreach (var w in FindObjectsByType<Waystone>(FindObjectsSortMode.None)) w.Attuned = w == this;
            if (resp.TryGetComponent<PlayerInventory>(out var inv)) inv.Toast("Waystone attuned");
            resp.SetPoint(transform.position + transform.forward * 1.5f, transform.rotation, Id);
        }
    }
}
