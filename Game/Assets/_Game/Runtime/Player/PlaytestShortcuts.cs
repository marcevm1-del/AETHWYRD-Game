using System;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Ascend.Game
{
    /// <summary>
    /// Ring 0 / Phase 1 playtest keys (not part of the real control scheme).
    /// F1 toggles the playtest overlay (adaptive-music state and its last state changes, life skill ranks).
    /// F2 crafting, F3 companion presets, F4 journal, F5 accessibility, F6 photo mode: these do not touch any window directly,
    /// they raise <see cref="OpenRequested"/> with the window's class name and the window (a MonoBehaviour owned by the UI) toggles itself.
    /// F8 grants one level (so the level 19-30 Whisperwood camps and raid waves can be tried without grinding), Shift+F8 grants five.
    /// F9 (SiegeDirector) starts a raid.
    /// </summary>
    [RequireComponent(typeof(PlayerCombat))]
    public sealed class PlaytestShortcuts : MonoBehaviour
    {
        /// <summary>Window names carried by <see cref="OpenRequested"/> (the window classes' names).</summary>
        public static class Windows
        {
            public const string Crafting = "CraftingWindow";
            public const string Companion = "CompanionWindow";
            public const string Journal = "JournalWindow";
            public const string Accessibility = "AccessibilityWindow";
            public const string PhotoMode = "PhotoModeController";
        }

        /// <summary>A playtest key asked for a window. The window subscribes in OnEnable, unsubscribes in OnDisable, and toggles itself.</summary>
        public static event Action<string> OpenRequested;
        /// <summary>The F1 overlay was switched on or off.</summary>
        public static event Action<bool> OverlayToggled;

        public static void Request(string windowName) => OpenRequested?.Invoke(windowName);

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        static void ResetStatics() { OpenRequested = null; OverlayToggled = null; }

        PlayerCombat _combat;
        PlayerWorldState _world;
        PlayerCrafting _crafting;
        readonly StringBuilder _text = new StringBuilder();

        public bool OverlayVisible { get; private set; }

        void Awake()
        {
            _combat = GetComponent<PlayerCombat>();
            _world = GetComponent<PlayerWorldState>();
            _crafting = GetComponent<PlayerCrafting>();
        }

        void Update()
        {
            var kb = Keyboard.current;
            if (kb == null) return;

            // ---- window keys: raise OpenRequested, the UI windows listen (see 13_Production/phase1_api.md) ----
            if (kb.f1Key.wasPressedThisFrame) SetOverlay(!OverlayVisible);
            if (kb.f2Key.wasPressedThisFrame) Request(Windows.Crafting);
            if (kb.f3Key.wasPressedThisFrame) Request(Windows.Companion);
            if (kb.f4Key.wasPressedThisFrame) Request(Windows.Journal);
            if (kb.f5Key.wasPressedThisFrame) Request(Windows.Accessibility);
            if (kb.f6Key.wasPressedThisFrame) Request(Windows.PhotoMode);
            // ---- end window keys ----

            if (!kb.f8Key.wasPressedThisFrame) return;
            int levels = kb.shiftKey.isPressed ? 5 : 1;
            for (int i = 0; i < levels; i++) LevelUp();
        }

        public void SetOverlay(bool on)
        {
            if (OverlayVisible == on) return;
            OverlayVisible = on;
            OverlayToggled?.Invoke(on);
        }

        /// <summary>Exactly the XP to reach the next level (through GrantXp, so the level-up heal and banner run).</summary>
        public void LevelUp()
        {
            long need = _combat.Progress.ToNext - _combat.Progress.XpIntoLevel;
            if (need > 0) _combat.GrantXp(need);
        }

        /// <summary>The overlay's text: music state and last state changes, then life skill ranks. Public so tests can read it.</summary>
        public string OverlayText()
        {
            if (_world == null) _world = GetComponent<PlayerWorldState>();
            if (_crafting == null) _crafting = GetComponent<PlayerCrafting>();
            _text.Clear();
            _text.AppendLine("PLAYTEST  (F1 hide | F2 craft | F3 companions | F4 journal | F5 access | F6 photo | F8 level | F9 raid)");
            var music = _world != null ? _world.Music : null;
            if (music == null || !music.Ready) _text.AppendLine("music: not running" + (music != null && music.LastError != null ? " (" + music.LastError + ")" : ""));
            else
            {
                _text.AppendLine($"music: {music.CurrentState}  ({music.Transitions} changes)");
                var log = music.Log;
                for (int i = Math.Max(0, log.Count - 10); i < log.Count; i++) _text.AppendLine("  " + log[i]);
            }
            if (_crafting != null)
            {
                _text.AppendLine("life skills: " + string.Join("  ", _crafting.SkillRows().Where(r => r.Xp > 0 || r.RankIndex > 0).Select(r => $"{r.Name} {r.Rank} ({r.Xp} xp)")));
            }
            return _text.ToString();
        }

        void OnGUI()
        {
            if (!OverlayVisible) return;
            var style = new GUIStyle(GUI.skin.box) { alignment = TextAnchor.UpperLeft, fontSize = 13, wordWrap = false, richText = false };
            GUI.Box(new Rect(8, 8, Mathf.Min(Screen.width - 16, 900), 12 * 20 + 24), OverlayText(), style);
        }
    }
}
