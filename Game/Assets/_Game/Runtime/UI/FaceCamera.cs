using UnityEngine;

namespace Ascend.Game
{
    /// <summary>
    /// Turns a world label (a TextMesh) toward the main camera every frame, so it never reads mirrored from behind
    /// (reports/baseline_2026-10-25.md, bug 2). The scene builder adds it to every label it makes.
    /// NPC name labels also hide while the HUD draws its own nameplates, so a name is never drawn twice (bug 3).
    /// </summary>
    [DisallowMultipleComponent]
    public sealed class FaceCamera : MonoBehaviour
    {
        [SerializeField] bool npcName;
        MeshRenderer _renderer;

        /// <summary>True for an NPC's name label: hidden while <see cref="NpcNameLabels"/> is off.</summary>
        public bool NpcName { get => npcName; set => npcName = value; }
        /// <summary>RingZeroHud turns this off while it draws NPC nameplates, and back on when it goes away.</summary>
        public static bool NpcNameLabels { get; set; } = true;

        void Awake() => _renderer = GetComponent<MeshRenderer>();

        void LateUpdate()
        {
            if (npcName && _renderer != null && _renderer.enabled != NpcNameLabels) _renderer.enabled = NpcNameLabels;
            var cam = Camera.main;
            if (cam == null) return;
            Vector3 away = transform.position - cam.transform.position; // TextMesh glyphs read correctly with +Z pointing away
            if (away.sqrMagnitude > 1e-6f) transform.rotation = Quaternion.LookRotation(away);
        }
    }
}
