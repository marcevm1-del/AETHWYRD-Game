using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Ascend.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Ascend.Game
{
    /// <summary>
    /// Photo mode (hud_and_ui.md section 11; Core PhotoSession, Data/Audio/photo_mode.json). Opens only when the world allows it
    /// (not in combat, a cutscene, a siege battle or a conversation), hides the HUD, keeps the orbit camera free and lets you zoom
    /// inside the Core field-of-view limits. It never touches the save or the clock; it closes itself if trouble starts. Keys:
    /// Up/Down (D-pad) zoom, H (Y) show/hide the HUD, Enter (A) saves a screenshot to the Photos folder, Esc (B) leaves. Opened with F6.
    /// </summary>
    public sealed class PhotoModeController : MonoBehaviour
    {
        const double FovStep = 5;

        static PhotoModeController _instance;
        public static bool IsOpen => _instance != null && _instance._open;
        public static PhotoModeController Instance => _instance != null ? _instance : _instance = FindFirstObjectByType<PhotoModeController>() ?? new GameObject("PhotoModeController").AddComponent<PhotoModeController>();
        /// <summary>True while photo mode wants the HUD gone (RingZeroHud checks it).</summary>
        public static bool HudHidden => _instance != null && _instance._open && _instance._hudHidden;

        bool _open, _hudHidden;
        double _fov = 60, _origFov;
        Camera _cam;
        PhotoSession _session;
        PhotoFile _file;
        float _openedAt, _hintUntil, _nextCheck;
        int _hideHintFrames;
        GUIStyle _style;

        /// <summary>What the last open attempt or action said ("Photo mode is not available during combat.").</summary>
        public string Message { get; private set; } = "";
        public double Fov => _fov;
        public double FovMin => _file != null ? _file.Tuning.FovMin : 20;
        public double FovMax => _file != null ? _file.Tuning.FovMax : 90;
        public int Shots { get; private set; }

        void OnEnable() => PlaytestShortcuts.OpenRequested += OnOpenRequested;
        void OnDisable()
        {
            PlaytestShortcuts.OpenRequested -= OnOpenRequested;
            if (_open) Close();
        }

        void OnOpenRequested(string windowName)
        {
            if (windowName != nameof(PhotoModeController)) return;
            if (_open) Close(); else if (!WindowHub.OldModalOpen) Open();
        }

        public bool Toggle() { if (_open) { Close(); return false; } return Open(); }

        /// <summary>Opens photo mode if the world allows it; false (with <see cref="Message"/>) if not.</summary>
        public bool Open()
        {
            if (_open) return true;
            _file = AscendData.Photo;
            if (_file == null) { Message = "Photo mode is not available."; return false; }
            var world = SampleWorld();
            if (!PhotoRules.CanOpen(_file, world, out var reason)) { Message = "Photo mode is not available during " + reason.Replace('_', ' ') + "."; return false; }
            SystemWindow.CloseAll();
            _session = null;
            var env = LoadEnvironment();
            if (env != null) _session = PhotoSession.Open(_file, env, world, out _);
            _cam = Camera.main != null ? Camera.main : FindFirstObjectByType<Camera>();
            _origFov = _cam != null ? _cam.fieldOfView : _file.Tuning.FovDefault;
            _open = true; _hudHidden = true; _openedAt = Time.unscaledTime; _hintUntil = Time.unscaledTime + 5f; _nextCheck = Time.unscaledTime + 0.5f;
            _session?.SetUiHidden(true);
            SetFov(Math.Max(FovMin, Math.Min(FovMax, _origFov)));
            Message = "Photo mode";
            return true;
        }

        public void Close()
        {
            if (!_open) return;
            _open = false; _hudHidden = false;
            if (_cam != null) _cam.fieldOfView = (float)_origFov;
            _session?.Close();
            _session = null;
            SystemWindow.NoteClosed();
        }

        /// <summary>Zoom, clamped to the Core field-of-view limits.</summary>
        public void SetFov(double fov)
        {
            if (_session != null && _session.IsOpen) { _session.SetFov(fov); _fov = _session.Fov; }
            else _fov = double.IsNaN(fov) ? (_file != null ? _file.Tuning.FovDefault : 60) : Math.Max(FovMin, Math.Min(FovMax, fov));
            if (_open && _cam != null) _cam.fieldOfView = (float)_fov;
        }

        public void SetHudHidden(bool hidden)
        {
            _hudHidden = hidden;
            if (_session != null && _session.IsOpen) _session.SetUiHidden(hidden);
            _hintUntil = Time.unscaledTime + 4f;
        }

        /// <summary>Saves a screenshot to Photos/ in the game's data folder and notes it as a Memory Reel shot.</summary>
        public string Capture()
        {
            if (!_open) return null;
            _session?.Capture();
            Shots++;
            string dir = Path.Combine(Application.persistentDataPath, "Photos");
            string path = Path.Combine(dir, $"photo_{DateTime.Now:yyyyMMdd_HHmmss}_{Shots}.png");
            try { Directory.CreateDirectory(dir); ScreenCapture.CaptureScreenshot(path); _hideHintFrames = 3; Message = "Photo saved."; return path; }
            catch (Exception e) { Message = "Could not save the photo: " + e.Message; return null; }
        }

        /// <summary>The page's text (tests read it).</summary>
        public List<string> Lines() => new List<string>
        {
            "PHOTO MODE",
            $"Field of view {_fov:0}° (limits {FovMin:0}–{FovMax:0})",
            _hudHidden ? "HUD hidden" : "HUD shown",
            "Up/Down zoom · H HUD · Enter save photo · Esc leave",
        };

        static EnvironmentAudio LoadEnvironment()
        {
            try
            {
                var path = Path.Combine(AscendData.DataRoot, "Audio", "environment_audio.json");
                if (!File.Exists(path)) return null;
                var settings = new JsonSerializerSettings { Converters = { new StringEnumConverter() }, ObjectCreationHandling = ObjectCreationHandling.Replace, Culture = System.Globalization.CultureInfo.InvariantCulture };
                return new EnvironmentAudio(JsonConvert.DeserializeObject<EnvironmentFile>(File.ReadAllText(path), settings));
            }
            catch (Exception e) { Debug.LogWarning("Photo mode: environment audio not loaded (" + e.Message + ")"); return null; }
        }

        PhotoWorldState SampleWorld()
        {
            var clock = WorldClock.Instance;
            return new PhotoWorldState
            {
                InCombat = InCombat(),
                InDialogue = NpcDialog.IsOpen,
                Hour = clock != null ? clock.Hour : 12,
                Weather = "clear",
                HasCompanion = FindObjectsByType<CompanionAI>(FindObjectsSortMode.None).Any(c => c != null && c.Joined),
            };
        }

        static bool InCombat()
        {
            var player = FindFirstObjectByType<PlayerCombat>();
            if (player == null) return false;
            Vector3 me = player.transform.position;
            foreach (var m in FindObjectsByType<MonsterDummy>(FindObjectsSortMode.None))
            {
                if (m == null || m.IsDead || m.IsPartner) continue;
                var ai = m.GetComponent<MonsterController>();
                if (ai == null || ai.Brain == null || ai.Brain.State == AiState.Idle) continue;
                var d = m.transform.position - me; d.y = 0f;
                if (d.magnitude < 20f) return true;
            }
            return false;
        }

        void Update()
        {
            if (!_open) return;
            if (Time.unscaledTime >= _nextCheck)
            {
                _nextCheck = Time.unscaledTime + 0.5f;
                var world = SampleWorld();
                if (!PhotoRules.CanOpen(_file, world, out var reason)) { Close(); Message = "Photo mode ended: " + reason.Replace('_', ' ') + "."; return; }
            }
            if (Time.unscaledTime - _openedAt < 0.15f) return;
            var kb = Keyboard.current;
            if (kb != null)
            {
                if (kb.escapeKey.wasPressedThisFrame) { Close(); return; }
                if (kb.upArrowKey.wasPressedThisFrame) { SetFov(_fov - FovStep); _hintUntil = Time.unscaledTime + 4f; }
                if (kb.downArrowKey.wasPressedThisFrame) { SetFov(_fov + FovStep); _hintUntil = Time.unscaledTime + 4f; }
                if (kb.hKey.wasPressedThisFrame) SetHudHidden(!_hudHidden);
                if (kb.enterKey.wasPressedThisFrame) Capture();
            }
            var pad = Gamepad.current;
            if (pad != null)
            {
                if (pad.buttonEast.wasPressedThisFrame) { Close(); return; }
                if (pad.dpad.up.wasPressedThisFrame) SetFov(_fov - FovStep);
                if (pad.dpad.down.wasPressedThisFrame) SetFov(_fov + FovStep);
                if (pad.buttonNorth.wasPressedThisFrame) SetHudHidden(!_hudHidden);
                if (pad.buttonSouth.wasPressedThisFrame) Capture();
            }
        }

        void OnGUI()
        {
            if (!_open) return;
            if (_hideHintFrames > 0) { if (Event.current.type == EventType.Repaint) _hideHintFrames--; return; }
            if (_hudHidden && Time.unscaledTime > _hintUntil) return; // a clean picture: the hint fades after a few seconds
            float k = Mathf.Max(1f, Screen.height / 900f);
            float vw = Screen.width / k, vh = Screen.height / k;
            _style ??= new GUIStyle(GUI.skin.label) { alignment = TextAnchor.MiddleCenter, wordWrap = false };
            var old = GUI.matrix;
            GUI.matrix = Matrix4x4.Scale(new Vector3(k, k, 1f));
            var lines = Lines();
            var r = new Rect((vw - 640) / 2f, vh - 86f, 640, 60);
            var c = GUI.color;
            GUI.color = new Color(0.055f, 0.065f, 0.11f, 0.85f);
            GUI.DrawTexture(r, Texture2D.whiteTexture);
            GUI.color = c;
            _style.fontSize = 16; _style.fontStyle = FontStyle.Bold; _style.normal.textColor = new Color(1f, 0.85f, 0.45f);
            GUI.Label(new Rect(r.x, r.y + 2, r.width, 24), $"{lines[0]}  ·  {lines[1]}  ·  {lines[2]}", _style);
            _style.fontSize = 14; _style.fontStyle = FontStyle.Normal; _style.normal.textColor = new Color(0.94f, 0.95f, 0.98f);
            GUI.Label(new Rect(r.x, r.y + 28, r.width, 24), lines[3], _style);
            GUI.matrix = old;
        }
    }
}
