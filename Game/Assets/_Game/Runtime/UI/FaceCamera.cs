using System.Collections.Generic;
using UnityEngine;

namespace Ascend.Game
{
    /// <summary>
    /// Turns a world label (a TextMesh) toward the main camera every frame, so it never reads mirrored from behind
    /// (reports/baseline_2026-10-25.md, bug 2). The scene builder adds it to every label it makes.
    /// An NPC's name label also hides while the HUD is drawing that NPC's nameplate, so a name is never drawn twice
    /// (bug 3); beyond nameplate range, or when the nameplate is skipped, the world label shows as before.
    /// Runs after the follow camera's LateUpdate so labels aim at this frame's camera position.
    /// </summary>
    [DisallowMultipleComponent]
    [DefaultExecutionOrder(1000)]
    public sealed class FaceCamera : MonoBehaviour
    {
        [SerializeField] string npcId;
        MeshRenderer _renderer;

        /// <summary>Set on an NPC's name label: the npcs.json id whose HUD nameplate replaces it.</summary>
        public string NpcId { get => npcId; set => npcId = value; }

        static readonly Dictionary<string, int> _nameplateFrame = new Dictionary<string, int>();

        /// <summary>Called by the HUD each frame it draws this NPC's nameplate.</summary>
        public static void NameplateDrawn(string id)
        {
            if (!string.IsNullOrEmpty(id)) _nameplateFrame[id] = Time.frameCount;
        }

        void Awake() => _renderer = GetComponent<MeshRenderer>();

        void LateUpdate()
        {
            if (!string.IsNullOrEmpty(npcId) && _renderer != null)
            {
                // OnGUI runs after LateUpdate, so a nameplate drawn last frame counts as current.
                bool covered = _nameplateFrame.TryGetValue(npcId, out int f) && Time.frameCount - f <= 2;
                if (_renderer.enabled == covered) _renderer.enabled = !covered;
            }
            var cam = Camera.main;
            if (cam == null) return;
            Vector3 away = transform.position - cam.transform.position; // TextMesh glyphs read correctly with +Z pointing away
            if (away.sqrMagnitude > 1e-6f) transform.rotation = Quaternion.LookRotation(away);
        }
    }
}
