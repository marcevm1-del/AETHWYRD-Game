using System;
using System.Collections.Generic;
using System.Linq;
using Ascend.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Ascend.Game
{
    /// <summary>
    /// The pause menu (Esc / Start): Resume, Settings, Controls, Audio, Graphics, Return to Main Menu and Quit. While it is
    /// open <see cref="GameTime.Paused"/> holds time at 0, so enemies, projectiles and the player all stop. Leaving the game
    /// asks first and can save. Esc on a sub-page goes back to the first page; Esc there resumes.
    /// </summary>
    public sealed class PauseMenu : SystemWindow
    {
        public enum Page { Main, Controls, Audio, Graphics, ToMenu, Quit }

        static PauseMenu _instance;
        public static bool IsOpen => _instance != null && _instance._open;
        public static PauseMenu Instance => _instance != null ? _instance : _instance = Create<PauseMenu>();

        const string VSyncPref = "ascend.vsync";

        public Page Current { get; private set; }
        bool _resuming, _reopen, _inSettings, _audioChanged;

        protected override string Title => Current switch
        {
            Page.Controls => "CONTROLS",
            Page.Audio => "AUDIO",
            Page.Graphics => "GRAPHICS",
            Page.ToMenu => "RETURN TO MAIN MENU?",
            Page.Quit => "QUIT GAME?",
            _ => "PAUSED",
        };

        protected override string Footer => Current == Page.Main ? "The world waits while this menu is open." : "Esc goes back.";

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        static void ApplySavedGraphics() { if (PlayerPrefs.HasKey(VSyncPref)) QualitySettings.vSyncCount = PlayerPrefs.GetInt(VSyncPref) != 0 ? 1 : 0; }

        /// <summary>Opens the menu over a live player. Refused without one and on the death screen (the respawn has its own clock).</summary>
        public static bool TryOpen(PlayerCombat player)
        {
            if (player == null || IsOpen) return false;
            var defense = player.GetComponent<PlayerDefense>();
            if (defense != null && defense.IsDead) return false;
            Instance.Current = Page.Main;
            Instance.Open(player.gameObject);
            return true;
        }

        /// <summary>Closes the menu from any page and lets the game run.</summary>
        public void Resume()
        {
            if (!_open) return;
            _resuming = true;
            Close();
        }

        protected override void OnOpened() { _reopen = false; _resuming = false; GameTime.SetPaused(true); }

        protected override void OnClosed()
        {
            SaveAudio();
            if (_inSettings) return; // the settings page took over; LateUpdate brings this menu back
            if (!_resuming && Current != Page.Main) { Current = Page.Main; _reopen = true; return; }
            _resuming = false;
            Current = Page.Main;
            GameTime.SetPaused(false);
        }

        void LateUpdate()
        {
            if (_open) return;
            if (_inSettings && !AccessibilityWindow.IsOpen) { _inSettings = false; _reopen = true; }
            if (_reopen) Open(PlayerObject);
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            _reopen = _inSettings = _resuming = false;
            Current = Page.Main;
            GameTime.SetPaused(false);
        }

        void Show(Page page) { Current = page; Line = ""; }

        protected override void Build(List<Row> rows)
        {
            switch (Current)
            {
                case Page.Controls: BuildControls(rows); break;
                case Page.Audio: BuildAudio(rows); break;
                case Page.Graphics: BuildGraphics(rows); break;
                case Page.ToMenu: BuildLeave(rows, "Return to the main menu", GoToMenu); break;
                case Page.Quit: BuildLeave(rows, "Quit", Application.Quit); break;
                default: BuildMain(rows); break;
            }
        }

        void BuildMain(List<Row> rows)
        {
            rows.Add(new Row { Text = "Resume game", Act = Resume });
            rows.Add(new Row { Text = "Settings", Act = OpenSettings });
            rows.Add(new Row { Text = "Controls", Act = () => Show(Page.Controls) });
            rows.Add(new Row { Text = "Audio", Act = () => Show(Page.Audio) });
            rows.Add(new Row { Text = "Graphics", Act = () => Show(Page.Graphics) });
            rows.Add(new Row { Text = "Character status", Act = ShowStatus });
            rows.Add(new Row { Text = "Return to main menu", Act = () => Show(Page.ToMenu) });
            rows.Add(new Row { Text = "Quit game", Act = () => Show(Page.Quit) });
        }

        void OpenSettings()
        {
            _inSettings = true;
            AccessibilityWindow.Instance.Open(PlayerObject); // opening one window closes the other
        }

        void ShowStatus()
        {
            var hud = FindFirstObjectByType<RingZeroHud>();
            if (hud != null) hud.StatusOpen = true;
            Resume();
        }

        Row BackRow() => new Row { Text = "Back", Act = () => Show(Page.Main) };

        void BuildControls(List<Row> rows)
        {
            rows.Add(BackRow());
            rows.Add(Header("KEYBOARD AND MOUSE"));
            foreach (var s in new[] { "Move: W A S D", "Look: mouse", "1 to 4: skills", "G: fire bomb    R: ultimate", "E: talk, gather", "Esc: pause" }) rows.Add(NoteRow(s));
            rows.Add(Header("CONTROLLER"));
            foreach (var s in new[] { "Left stick: move    Right stick: look", "Hold RB + face button: skills 1 to 4", "L3 + R3: ultimate", "Start: pause" }) rows.Add(NoteRow(s));
            rows.Add(Info("Keys cannot be changed yet.", true));
        }

        void BuildAudio(List<Row> rows)
        {
            rows.Add(BackRow());
            var a = World != null ? World.Accessibility : null;
            if (a == null) { rows.Add(Info("Audio settings are not available yet.", true)); return; }
            var v = a.Volumes;
            rows.Add(Volume("Master", () => v.Master, x => v.Master = x));
            rows.Add(Volume("Music", () => v.Music, x => v.Music = x));
            rows.Add(Volume("Effects", () => v.Effects, x => v.Effects = x));
            rows.Add(Volume("Ambience", () => v.Ambience, x => v.Ambience = x));
            rows.Add(Volume("Dialogue", () => v.Dialogue, x => v.Dialogue = x));
        }

        Row Volume(string label, Func<double> get, Action<double> set) => new Row
        {
            Text = $"{label} volume: {get() * 100:0}%",
            Bar = (float)get(),
            Adjust = dir =>
            {
                set(Math.Round(Math.Max(0, Math.Min(1, get() + dir * 0.1)), 2));
                World.Accessibility.Sanitize();
                World.ApplyAccessibility();
                _audioChanged = true;
            },
        };

        void SaveAudio()
        {
            if (!_audioChanged) return;
            _audioChanged = false;
            if (World != null) GameSettings.Save(World.Accessibility);
        }

        void BuildGraphics(List<Row> rows)
        {
            rows.Add(BackRow());
            bool full = Screen.fullScreenMode != FullScreenMode.Windowed;
            Action flip = () =>
            {
                if (full) Screen.SetResolution(1600, 900, FullScreenMode.Windowed);
                else Screen.SetResolution(Display.main.systemWidth, Display.main.systemHeight, FullScreenMode.FullScreenWindow);
                Line = "Display mode changed.";
            };
            rows.Add(new Row { Text = "Full screen: " + (full ? "On" : "Off"), Act = flip, Adjust = _ => flip() });

            var sizes = Screen.resolutions.Select(r => new Vector2Int(r.width, r.height)).Distinct().ToList();
            if (sizes.Count > 0)
                rows.Add(new Row
                {
                    Text = $"Resolution: {Screen.width} x {Screen.height}",
                    Adjust = dir =>
                    {
                        int i = sizes.IndexOf(new Vector2Int(Screen.width, Screen.height));
                        i = i < 0 ? sizes.Count - 1 : Mathf.Clamp(i + dir, 0, sizes.Count - 1);
                        Screen.SetResolution(sizes[i].x, sizes[i].y, Screen.fullScreenMode);
                    },
                });

            Action vsync = () =>
            {
                QualitySettings.vSyncCount = QualitySettings.vSyncCount > 0 ? 0 : 1;
                PlayerPrefs.SetInt(VSyncPref, QualitySettings.vSyncCount);
            };
            rows.Add(new Row { Text = "V-sync: " + (QualitySettings.vSyncCount > 0 ? "On" : "Off"), Act = vsync, Adjust = _ => vsync() });
        }

        void BuildLeave(List<Row> rows, string what, Action leave)
        {
            rows.Add(new Row { Text = "Cancel", Act = () => Show(Page.Main) });
            rows.Add(new Row { Text = $"Save, then {char.ToLowerInvariant(what[0])}{what.Substring(1)}", Act = () => { if (TrySave()) leave(); } });
            rows.Add(new Row { Text = $"{what} without saving", Act = leave });
            rows.Add(Info("Anything since your last save is lost if you do not save.", true));
        }

        bool TrySave()
        {
            var save = PlayerObject != null ? PlayerObject.GetComponent<PlayerSave>() : null;
            if (save == null) { Line = "There is nothing to save here."; return false; }
            int before = save.Saves;
            save.Save();
            if (save.Saves > before) return true;
            Line = "The game could not be saved, so you are still here. " + save.LastError;
            return false;
        }

        void GoToMenu()
        {
            if (!Application.CanStreamedLevelBeLoaded(FrontEndSession.TitleScene)) { Line = "The main menu is not part of this build."; return; }
            Resume();
            PlayerObject = null;
            GameTime.Clear();
            FrontEndSession.Clear();
            SceneManager.LoadScene(FrontEndSession.TitleScene);
        }
    }
}
