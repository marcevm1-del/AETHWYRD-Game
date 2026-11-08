using System;
using System.Collections.Generic;
using UnityEngine;

namespace Ascend.Game
{
    /// <summary>
    /// The playtest overlay's music panel (IMGUI, top-left under the HUD on a navy plate; hidden until F1; never takes the controls): the adaptive-music state and the last state-change
    /// lines of <see cref="MusicStateLogger"/>. Switched by the F1 playtest key (<c>PlaytestShortcuts.OverlayToggled</c>) or by an
    /// <c>OpenRequested("PlaytestOverlay")</c>. Not part of the real game UI.
    /// </summary>
    public sealed class PlaytestOverlay : MonoBehaviour
    {
        public const int MaxLogLines = 12;

        static PlaytestOverlay _instance;
        public static bool IsOpen => _instance != null && _instance._visible;
        public static PlaytestOverlay Instance => _instance != null ? _instance : _instance = FindFirstObjectByType<PlaytestOverlay>() ?? new GameObject("PlaytestOverlay").AddComponent<PlaytestOverlay>();

        bool _visible;
        GUIStyle _style;
        PlayerWorldState _world;

        public bool Visible => _visible;

        void OnEnable()
        {
            PlaytestShortcuts.OverlayToggled += SetVisible;
            PlaytestShortcuts.OpenRequested += OnOpenRequested;
        }

        void OnDisable()
        {
            PlaytestShortcuts.OverlayToggled -= SetVisible;
            PlaytestShortcuts.OpenRequested -= OnOpenRequested;
        }

        void OnOpenRequested(string windowName) { if (windowName == nameof(PlaytestOverlay)) Toggle(); }

        public void SetVisible(bool on) => _visible = on;
        public void Toggle() => _visible = !_visible;

        /// <summary>The panel's lines: the music state, then up to <see cref="MaxLogLines"/> of the newest state changes (oldest first).</summary>
        public List<string> Lines()
        {
            var lines = new List<string> { "MUSIC LOG" };
            if (_world == null) _world = FindFirstObjectByType<PlayerWorldState>();
            var music = _world != null ? _world.Music : null;
            if (music == null || !music.Ready)
            {
                lines.Add("music: not running" + (music != null && !string.IsNullOrEmpty(music.LastError) ? " (" + music.LastError + ")" : ""));
                return lines;
            }
            lines.Add($"state: {music.CurrentState}  ({music.Transitions} changes)");
            var log = music.Log;
            if (log.Count == 0) lines.Add("(no state changes yet)");
            for (int i = Math.Max(0, log.Count - MaxLogLines); i < log.Count; i++) lines.Add(log[i]);
            return lines;
        }

        void OnGUI()
        {
            if (!_visible) return;
            float k = Mathf.Max(1f, Screen.height / 900f);
            float vw = Screen.width / k, vh = Screen.height / k;
            _style ??= new GUIStyle(GUI.skin.label) { fontSize = 15, wordWrap = false, clipping = TextClipping.Clip };
            var lines = Lines();
            var old = GUI.matrix;
            GUI.matrix = Matrix4x4.Scale(new Vector3(k, k, 1f));
            float w = Mathf.Min(vw - 32f, 600f), h = lines.Count * 20f + 16f;
            var r = new Rect(16f, 128f, w, h); // top-left under the HUD, clear of the hotbar
            var c = GUI.color;
            GUI.color = new Color(0.04f, 0.07f, 0.14f, 0.82f);
            GUI.DrawTexture(r, Texture2D.whiteTexture);
            GUI.color = c;
            for (int i = 0; i < lines.Count; i++)
            {
                _style.fontStyle = i == 0 ? FontStyle.Bold : FontStyle.Normal;
                _style.normal.textColor = i == 0 ? new Color(0.498f, 0.89f, 1f) : new Color(0.93f, 0.95f, 1f);
                GUI.Label(new Rect(r.x + 10f, r.y + 8f + i * 20f, w - 20f, 20f), lines[i], _style);
            }
            GUI.matrix = old;
        }
    }
}
