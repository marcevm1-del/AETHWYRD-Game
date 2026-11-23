using UnityEngine;

namespace Ascend.Game
{
    /// <summary>
    /// Creates the Phase 1 windows once the scene is up, so each one exists and listens for <c>PlaytestShortcuts.OpenRequested</c>
    /// (the playtest keys F1-F6 raise it with the window's class name). Nothing is drawn until a window is opened.
    /// </summary>
    public static class WindowHub
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        static void Boot() => EnsureAll();

        /// <summary>Makes sure every Phase 1 window object exists (they live across scene loads).</summary>
        public static void EnsureAll()
        {
            if (!Application.isPlaying) return;
            Keep(CraftingWindow.Instance);
            Keep(CompanionWindow.Instance);
            Keep(JournalWindow.Instance);
            Keep(AccessibilityWindow.Instance);
            Keep(PauseMenu.Instance);
            Keep(PhotoModeController.Instance);
            Keep(PlaytestOverlay.Instance);
        }

        static void Keep(Component c)
        {
            if (c != null && c.transform.parent == null) Object.DontDestroyOnLoad(c.gameObject);
        }

        /// <summary>Any Phase 1 window that takes the controls (the playtest overlay never does).</summary>
        public static bool AnyOpen => SystemWindow.AnyOpen || PhotoModeController.IsOpen;

        /// <summary>One of the older windows (talk, bag, bestiary, map) is open: the playtest keys leave the screen alone.</summary>
        public static bool OldModalOpen => NpcDialog.IsOpen || BagWindow.IsOpen || BestiaryWindow.IsOpen || WorldMapWindow.IsOpen;
    }
}
