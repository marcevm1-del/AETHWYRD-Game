using UnityEngine;
using UnityEngine.InputSystem;

namespace Ascend.Game
{
    /// <summary>
    /// Ring 0 playtest keys (not part of the real control scheme): F8 grants one level (so the level 19–30 Whisperwood
    /// camps and raid waves can be tried without grinding), Shift+F8 grants five. F9 (SiegeDirector) starts a raid.
    /// </summary>
    [RequireComponent(typeof(PlayerCombat))]
    public sealed class PlaytestShortcuts : MonoBehaviour
    {
        PlayerCombat _combat;

        void Awake() => _combat = GetComponent<PlayerCombat>();

        void Update()
        {
            var kb = Keyboard.current;
            if (kb == null || !kb.f8Key.wasPressedThisFrame) return;
            int levels = kb.shiftKey.isPressed ? 5 : 1;
            for (int i = 0; i < levels; i++) LevelUp();
        }

        /// <summary>Exactly the XP to reach the next level (through GrantXp, so the level-up heal and banner run).</summary>
        public void LevelUp()
        {
            long need = _combat.Progress.ToNext - _combat.Progress.XpIntoLevel;
            if (need > 0) _combat.GrantXp(need);
        }
    }
}
