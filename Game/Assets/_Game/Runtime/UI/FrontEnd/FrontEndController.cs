using System;
using System.Collections.Generic;
using System.IO;
using Ascend.Core;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace Ascend.Game
{
    /// <summary>
    /// The front end in one object, living in the Title scene (built by Ascend.EditorTools.TitleSceneBuilder): title screen, main menu,
    /// character creator, settings (the existing <see cref="AccessibilityWindow"/>) and the loading screen. IMGUI in the "anime System window"
    /// look of <see cref="SystemWindow"/> (shared colours and chrome helpers), authored for 1600x900 and scaled up for 4K.
    /// Controls: Up/Down (W/S, D-pad, left stick) choose, Enter / Space / A use, Left/Right (A/D, D-pad) change a value, Esc / B back, mouse
    /// hover and click, X (West) suggests a name. The screens and the menu entries are public so tests can drive them without input.
    /// </summary>
    public sealed class FrontEndController : MonoBehaviour
    {
        public enum Screen { Title, Menu, Creator, Settings, Loading }

        /// <summary>Shortest time the loading screen shows (seconds), so the bar and tip can be read.</summary>
        public const float MinLoadingSeconds = 0.8f;

        public static FrontEndController Instance { get; private set; }

        public Screen Current { get; private set; } = Screen.Title;
        public CharacterCreatorState Creator { get; private set; }
        public string StatusLine { get; private set; } = "";
        public string Tip { get; private set; } = "";
        public float LoadProgress { get; private set; }
        public bool ConfirmingNewGame { get; private set; }

        // menu
        readonly List<FrontEndMenu.Entry> _entries = new List<FrontEndMenu.Entry>();
        public IReadOnlyList<FrontEndMenu.Entry> MenuEntries => _entries;
        int _cursor, _creatorCursor;
        bool _editingName, _focusName;
        bool _hasSave;
        string _saveSummary = "";

        // look
        FrontEndBackdrop _backdrop;
        CreatorPreview _preview;
        PlayerWorldState _settingsHolder;
        AccessibilitySettings _settings;
        float _screenAt;

        // loading
        AsyncOperation _op;
        float _loadStartedAt;
        bool _loadingDemo;
        bool _loadActivated;

        // mouse
        readonly List<Rect> _rects = new List<Rect>();           // rows of the current screen, virtual coordinates
        readonly List<int> _rectIndex = new List<int>();         // what each rect stands for
        Vector2 _lastMouse;
        bool _mouseMoved;

        // capture
        string _capture, _shotPath;
        float _captureAt = -1f;
        int _shotFrames = -1;
        float _stickPrevY, _stickPrevX;

        GUIStyle _s, _field;

        // ------------------------------------------------------------------ lifecycle

        void Awake()
        {
            Instance = this;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            EnsureCamera();
            _backdrop = new FrontEndBackdrop();
            _settings = GameSettings.TryLoad();
            RefreshMenu();
            _screenAt = Time.unscaledTime;
        }

        void OnDestroy()
        {
            if (Instance == this) Instance = null;
            if (_madeCamera != null) { DestroyImmediate(_madeCamera); _madeCamera = null; } // a camera this controller made must not outlive it (it would become Camera.main)
            _backdrop?.Dispose();
            _preview?.Dispose();
            if (_settingsHolder != null) Destroy(_settingsHolder.gameObject);
        }

        static GameObject _madeCamera;

        static void EnsureCamera()
        {
            var cam = Camera.main;
            if (cam == null)
            {
                var go = new GameObject("Main Camera") { tag = "MainCamera" };
                _madeCamera = go;
                cam = go.AddComponent<Camera>();
                go.AddComponent<AudioListener>();
            }
            // The front end draws with IMGUI; the 3D preview has its own camera and layer.
            cam.clearFlags = CameraClearFlags.SolidColor;
            cam.backgroundColor = new Color(0.05f, 0.06f, 0.14f, 1f);
            cam.cullingMask = 0;
        }

        void Start()
        {
            _capture = FrontEndSession.CaptureScreen;
            _shotPath = FrontEndSession.Arg("-ascendShot");
            if (!string.IsNullOrEmpty(_capture) && !string.IsNullOrEmpty(_shotPath)) BeginCapture(_capture);
        }

        /// <summary>The capture screens: seeded demo state, then a screenshot a few seconds in (animations and the preview need to settle).</summary>
        void BeginCapture(string screen)
        {
            switch (screen.ToLowerInvariant())
            {
                case "title": Open(Screen.Title); break;
                case "menu":
                    FrontEndSession.SeedDemoSave(PlayerSave.Folder);
                    RefreshMenu();
                    _cursor = 0;
                    Open(Screen.Menu);
                    break;
                case "creator":
                    OpenCreator(new AppearanceChoice { PlayerName = "Wren", Body = Body.Feminine, HairStyle = "ponytail", HairColour = "sky", SkinTone = "golden", OutfitColour = "teal" });
                    _creatorCursor = Array.IndexOf(CharacterCreatorState.Order, CharacterCreatorState.Field.HairColour);
                    break;
                case "loading":
                    _loadingDemo = true; _loadStartedAt = Time.unscaledTime; LoadProgress = 0.62f;
                    Tip = PickTip(5);
                    Open(Screen.Loading);
                    break;
                case "settings":
                    Open(Screen.Settings);
                    OpenSettingsWindow();
                    break;
                default: Debug.LogWarning("ascendFront: unknown screen " + screen); Open(Screen.Title); break;
            }
            _captureAt = Time.unscaledTime + 3.2f;
        }

        // ------------------------------------------------------------------ state changes (public so tests drive them)

        public void Open(Screen s)
        {
            Current = s;
            _screenAt = Time.unscaledTime;
            _rects.Clear(); _rectIndex.Clear();
            ConfirmingNewGame = false;
            if (s != Screen.Creator) { _editingName = false; }
            if (s != Screen.Creator && _preview != null) { _preview.Dispose(); _preview = null; }
        }

        /// <summary>Reads the slot again: Continue shows only for a valid save in the current save folder.</summary>
        public void RefreshMenu()
        {
            _hasSave = FrontEndSession.HasSave;
            _saveSummary = _hasSave ? FrontEndSession.SaveSummary() : "";
            _entries.Clear();
            _entries.AddRange(FrontEndMenu.Entries(_hasSave));
            _cursor = Mathf.Clamp(_cursor, 0, _entries.Count - 1);
        }

        public void OpenCreator(AppearanceChoice start = null)
        {
            Creator = new CharacterCreatorState(AscendData.PlayerAppearance, start);
            _creatorCursor = 0;
            Open(Screen.Creator);
            _preview = new CreatorPreview(Creator.Data);
            _preview.SetLook(Creator.Look);
            StatusLine = "";
        }

        public void ChooseMenu(FrontEndMenu.Entry e)
        {
            StatusLine = "";
            switch (e)
            {
                case FrontEndMenu.Entry.Continue: BeginLoading(); break;
                case FrontEndMenu.Entry.NewGame:
                    if (_hasSave && !ConfirmingNewGame) { ConfirmingNewGame = true; _cursor = 1; }
                    else OpenCreator();
                    break;
                case FrontEndMenu.Entry.Settings: Open(Screen.Settings); OpenSettingsWindow(); break;
                case FrontEndMenu.Entry.Quit:
                    Application.Quit();
#if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;
#endif
                    break;
            }
        }

        /// <summary>Starts the game with the creator's look (a New Game) and shows the loading screen.</summary>
        public void BeginNewGame()
        {
            if (Creator == null) Creator = new CharacterCreatorState(AscendData.PlayerAppearance);
            FrontEndSession.Begin(FrontEndSession.Mode.NewGame, Creator.Finish());
            BeginLoading();
        }

        void BeginLoading()
        {
            Open(Screen.Loading);
            LoadProgress = 0f; _loadActivated = false; _loadingDemo = false;
            _loadStartedAt = Time.unscaledTime;
            Tip = PickTip(Environment.TickCount);
            if (!Application.CanStreamedLevelBeLoaded(FrontEndSession.FieldScene))
            {
                StatusLine = "The field scene is not in this build.";
                FrontEndSession.Clear();
                RefreshMenu();
                Open(Screen.Menu);
                return;
            }
            _op = SceneManager.LoadSceneAsync(FrontEndSession.FieldScene);
            if (_op != null) _op.allowSceneActivation = false;
        }

        static string PickTip(int seed)
        {
            var t = AscendData.LoadingTips?.Pick(seed);
            return t != null ? t.Text : "";
        }

        void OpenSettingsWindow()
        {
            if (FindFirstObjectByType<PlayerWorldState>() == null)
            {
                try { _settingsHolder = new GameObject("FrontEndSettings").AddComponent<PlayerWorldState>(); }
                catch (Exception e) { Debug.LogWarning("Settings holder failed: " + e.Message); }
            }
            WindowHub.EnsureAll();
            AccessibilityWindow.Instance.Open();
        }

        // ------------------------------------------------------------------ input

        bool Blocked => SystemWindow.AnyOpen || Time.unscaledTime - _screenAt < 0.12f;

        void Update()
        {
            float dt = Time.unscaledDeltaTime;
            _preview?.Tick(dt);
            TickCapture();

            var kb = Keyboard.current; var pad = Gamepad.current; var mouse = Mouse.current;
            if (kb != null && kb.anyKey.wasPressedThisFrame) SystemWindow.PadActive = false;
            if (pad != null && (pad.dpad.ReadValue().sqrMagnitude > 0.25f || pad.buttonSouth.wasPressedThisFrame || pad.buttonEast.wasPressedThisFrame || pad.startButton.wasPressedThisFrame)) SystemWindow.PadActive = true;

            if (Current == Screen.Settings)
            {
                if (!AccessibilityWindow.IsOpen && Time.unscaledTime - _screenAt > 0.3f && !SystemWindow.AnyOpen)
                {
                    _settings = _settingsHolder != null ? _settingsHolder.Accessibility : GameSettings.TryLoad();
                    Open(Screen.Menu);
                }
                return;
            }
            if (Current == Screen.Loading) { TickLoading(dt); return; }
            if (Blocked) return;

            // device input as abstract actions
            int move = 0, change = 0; bool use = false, back = false, alt = false, any = false;
            if (kb != null)
            {
                if (kb.downArrowKey.wasPressedThisFrame || (!_editingName && kb.sKey.wasPressedThisFrame)) move++;
                if (kb.upArrowKey.wasPressedThisFrame || (!_editingName && kb.wKey.wasPressedThisFrame)) move--;
                if (!_editingName)
                {
                    if (kb.rightArrowKey.wasPressedThisFrame || kb.dKey.wasPressedThisFrame) change++;
                    if (kb.leftArrowKey.wasPressedThisFrame || kb.aKey.wasPressedThisFrame) change--;
                    if (kb.xKey.wasPressedThisFrame) alt = true;
                }
                if (kb.enterKey.wasPressedThisFrame || kb.numpadEnterKey.wasPressedThisFrame || (!_editingName && kb.spaceKey.wasPressedThisFrame)) use = true;
                if (kb.escapeKey.wasPressedThisFrame) back = true;
                if (kb.anyKey.wasPressedThisFrame) any = true;
            }
            if (pad != null)
            {
                if (pad.dpad.down.wasPressedThisFrame) move++;
                if (pad.dpad.up.wasPressedThisFrame) move--;
                if (pad.dpad.right.wasPressedThisFrame) change++;
                if (pad.dpad.left.wasPressedThisFrame) change--;
                float sy = pad.leftStick.y.ReadValue(), sx = pad.leftStick.x.ReadValue();
                if (sy < -0.6f && _stickPrevY >= -0.6f) move++;
                if (sy > 0.6f && _stickPrevY <= 0.6f) move--;
                if (sx > 0.6f && _stickPrevX <= 0.6f) change++;
                if (sx < -0.6f && _stickPrevX >= -0.6f) change--;
                _stickPrevY = sy; _stickPrevX = sx;
                if (pad.buttonSouth.wasPressedThisFrame) use = true;
                if (pad.buttonEast.wasPressedThisFrame) back = true;
                if (pad.buttonWest.wasPressedThisFrame) alt = true;
                if (pad.startButton.wasPressedThisFrame || pad.buttonNorth.wasPressedThisFrame || pad.buttonSouth.wasPressedThisFrame) any = true;
            }
            int clickRow = -1, clickDir = 0;
            if (mouse != null)
            {
                var mp = mouse.position.ReadValue();
                if ((mp - _lastMouse).sqrMagnitude > 1f) _mouseMoved = true;
                _lastMouse = mp;
                if (_mouseMoved || mouse.leftButton.wasPressedThisFrame)
                {
                    int hit = RowAt(ToVirtual(mp), out clickDir);
                    if (hit >= 0) { if (Current == Screen.Menu) _cursor = hit; else if (Current == Screen.Creator && !_editingName) _creatorCursor = hit; }
                    _mouseMoved = false;
                    if (mouse.leftButton.wasPressedThisFrame) { clickRow = hit; any = true; }
                }
                if (mouse.leftButton.wasPressedThisFrame) any = true;
            }

            switch (Current)
            {
                case Screen.Title:
                    if (any || use) { RefreshMenu(); Open(Screen.Menu); }
                    break;
                case Screen.Menu: UpdateMenu(move, use, back, clickRow); break;
                case Screen.Creator: UpdateCreator(move, change, use, back, alt, clickRow, clickDir); break;
            }
        }

        void UpdateMenu(int move, bool use, bool back, int clickRow)
        {
            var rows = MenuRows();
            if (move != 0) _cursor = Mathf.Clamp(NextSelectable(rows, _cursor, move), 0, rows.Count - 1);
            if (back) { if (ConfirmingNewGame) { ConfirmingNewGame = false; _cursor = 0; } else Open(Screen.Title); return; }
            int pick = clickRow >= 0 ? clickRow : use ? _cursor : -1;
            if (pick >= 0 && pick < rows.Count && rows[pick].Act != null) rows[pick].Act();
        }

        static int NextSelectable(List<MenuRow> rows, int from, int dir)
        {
            for (int i = from + dir; i >= 0 && i < rows.Count; i += dir) if (rows[i].Act != null) return i;
            return from;
        }

        sealed class MenuRow { public string Text, Right; public bool Header, Note; public Action Act; }

        List<MenuRow> MenuRows()
        {
            var rows = new List<MenuRow>();
            if (ConfirmingNewGame)
            {
                rows.Add(new MenuRow { Text = "Replace your saved adventure?", Header = true });
                rows.Add(new MenuRow { Text = "A new game replaces your current save at its first autosave.", Note = true });
                rows.Add(new MenuRow { Text = "Yes, begin a new story", Act = () => { ConfirmingNewGame = false; OpenCreator(); } });
                rows.Add(new MenuRow { Text = "No, keep my save", Act = () => { ConfirmingNewGame = false; _cursor = 0; } });
                if (_cursor < 2) _cursor = 3;
                return rows;
            }
            foreach (var e in _entries)
            {
                var entry = e;
                rows.Add(new MenuRow { Text = FrontEndMenu.Label(entry), Right = entry == FrontEndMenu.Entry.Continue ? _saveSummary : "", Act = () => ChooseMenu(entry) });
            }
            return rows;
        }

        void UpdateCreator(int move, int change, bool use, bool back, bool alt, int clickRow, int clickDir)
        {
            if (Creator == null) return;
            var order = CharacterCreatorState.Order;
            if (_editingName)
            {
                if (use || back) { _editingName = false; Creator.FinishName(); _preview?.SetLook(Creator.Look); }
                return;
            }
            if (back) { Open(Screen.Menu); return; }
            if (move != 0)
            {
                int i = _creatorCursor;
                do { i = Mathf.Clamp(i + move, 0, order.Length - 1); } while (!CharacterCreatorState.Selectable(order[i]) && i > 0 && i < order.Length - 1);
                _creatorCursor = i;
            }
            var f = order[_creatorCursor];
            if (alt && f == CharacterCreatorState.Field.Name) { Creator.NextSuggestedName(); }
            if (change != 0) Creator.Cycle(f, change);
            if (clickRow >= 0 && clickRow < order.Length && CharacterCreatorState.Selectable(order[clickRow]))
            {
                _creatorCursor = clickRow; f = order[clickRow];
                if (clickDir != 0) Creator.Cycle(f, clickDir); else use = true;
            }
            if (use)
            {
                switch (f)
                {
                    case CharacterCreatorState.Field.Name: _editingName = true; _focusName = true; break;
                    case CharacterCreatorState.Field.Begin: BeginNewGame(); return;
                    case CharacterCreatorState.Field.Back: Open(Screen.Menu); return;
                    default: Creator.Cycle(f, 1); break;
                }
            }
            _preview?.SetLook(Creator.Look);
        }

        // ------------------------------------------------------------------ loading and capture

        void TickLoading(float dt)
        {
            float elapsed = Time.unscaledTime - _loadStartedAt;
            if (_loadingDemo) return; // a capture holds a fixed bar
            if (_op == null) return;
            float real = Mathf.Clamp01(_op.progress / 0.9f);
            float target = Mathf.Min(real, Mathf.Clamp01(elapsed / MinLoadingSeconds));
            LoadProgress = Mathf.MoveTowards(LoadProgress, target, dt * 1.6f);
            if (!_loadActivated && LoadProgress >= 0.999f && real >= 1f && elapsed >= MinLoadingSeconds)
            {
                _loadActivated = true;
                _op.allowSceneActivation = true;
            }
        }

        void TickCapture()
        {
            if (_captureAt < 0f || string.IsNullOrEmpty(_shotPath)) return;
            if (_shotFrames < 0 && Time.unscaledTime >= _captureAt)
            {
                try { Directory.CreateDirectory(Path.GetDirectoryName(Path.GetFullPath(_shotPath))); ScreenCapture.CaptureScreenshot(Path.GetFullPath(_shotPath)); }
                catch (Exception e) { Debug.LogWarning("front-end capture failed: " + e.Message); }
                _shotFrames = 0;
                return;
            }
            if (_shotFrames >= 0 && ++_shotFrames > 30) Application.Quit();
        }

        // ------------------------------------------------------------------ mouse mapping

        float K => Mathf.Max(1f, UnityEngine.Screen.height / 900f);
        Vector2 ToVirtual(Vector2 mouse) => new Vector2(mouse.x / K, (UnityEngine.Screen.height - mouse.y) / K);

        /// <summary>The row under a point (virtual coordinates), and for the creator which side of the value it is on (-1 left, +1 right, 0 elsewhere).</summary>
        int RowAt(Vector2 p, out int side)
        {
            side = 0;
            for (int i = 0; i < _rects.Count; i++)
            {
                if (!_rects[i].Contains(p)) continue;
                if (Current == Screen.Creator)
                {
                    float vx0 = _rects[i].x + 250f, vw = _rects[i].width - 270f;
                    if (p.x > vx0 && p.x < vx0 + vw * 0.3f) side = -1;
                    else if (p.x < vx0 + vw && p.x > vx0 + vw * 0.7f) side = 1;
                }
                return _rectIndex[i];
            }
            return -1;
        }

        // ------------------------------------------------------------------ drawing

        float Ts => Mathf.Clamp(_settingsHolder != null ? (float)_settingsHolder.Accessibility.TextScale : _settings != null ? (float)_settings.TextScale : 1f, 0.8f, 2f);
        bool Contrast => (_settingsHolder != null ? _settingsHolder.Accessibility.HighContrastPanels : _settings != null && _settings.HighContrastPanels);

        void EnsureStyles()
        {
            _s ??= new GUIStyle(GUI.skin.label) { wordWrap = false, clipping = TextClipping.Clip, alignment = TextAnchor.MiddleLeft };
            _field ??= new GUIStyle(GUI.skin.textField) { alignment = TextAnchor.MiddleLeft };
        }

        void T(Rect r, string text, float size, Color c, TextAnchor a = TextAnchor.MiddleLeft, FontStyle fs = FontStyle.Normal, bool scale = true, bool wrap = false, bool shadow = false)
        {
            _s.fontSize = Mathf.RoundToInt(size * (scale ? Ts : 1f));
            _s.fontStyle = fs; _s.alignment = a; _s.wordWrap = wrap;
            if (shadow)
            {
                _s.normal.textColor = new Color(0.02f, 0.03f, 0.1f, 0.65f);
                GUI.Label(new Rect(r.x + 1.5f, r.y + 2f, r.width, r.height), text, _s);
            }
            _s.normal.textColor = c;
            GUI.Label(r, text, _s);
        }

        void OnGUI()
        {
            GUI.depth = 10;
            EnsureStyles();
            float k = K;
            float vw = UnityEngine.Screen.width / k, vh = UnityEngine.Screen.height / k;
            _rects.Clear(); _rectIndex.Clear();

            _backdrop?.Draw(Current == Screen.Loading ? 0.3f : Current == Screen.Creator ? 0.45f : Current == Screen.Settings ? 0.25f : 0f);
            var old = GUI.matrix;
            GUI.matrix = Matrix4x4.Scale(new Vector3(k, k, 1f));
            switch (Current)
            {
                case Screen.Title: DrawTitle(vw, vh); break;
                case Screen.Menu: DrawLogo(vw, vh, 0.24f, 0.66f); DrawMenu(vw, vh); break;
                case Screen.Creator: DrawCreator(vw, vh); break;
                case Screen.Loading: DrawLoading(vw, vh); break;
            }
            GUI.matrix = old;
        }

        // ---- logo and title

        void DrawLogo(float vw, float vh, float yFrac, float scale)
        {
            float t = Time.unscaledTime - _screenAt;
            var c = new Vector2(vw / 2f, vh * yFrac);
            // a slow turning sigil behind the word
            var m = GUI.matrix;
            GUIUtility.RotateAroundPivot(Time.unscaledTime * 3f, c);
            SystemWindow.DrawSigil(c, 300f * scale);
            GUIUtility.RotateAroundPivot(-Time.unscaledTime * 5f, c);
            SystemWindow.DrawSigil(c, 210f * scale);
            GUI.matrix = m;

            const string word = "AETHWYRD";
            float size = 120f * scale, tracking = size * 0.16f;
            _s.fontSize = Mathf.RoundToInt(size); _s.fontStyle = FontStyle.Bold; _s.alignment = TextAnchor.MiddleCenter; _s.wordWrap = false;
            var widths = new float[word.Length];
            float total = -tracking;
            for (int i = 0; i < word.Length; i++) { widths[i] = _s.CalcSize(new GUIContent(word[i].ToString())).x; total += widths[i] + tracking; }
            float x = c.x - total / 2f;
            float h = size * 1.3f;
            for (int i = 0; i < word.Length; i++)
            {
                float a = Mathf.Clamp01(t * 1.3f - i * 0.1f);
                float rise = (1f - a) * 16f;
                var r = new Rect(x, c.y - h / 2f + rise, widths[i], h);
                for (int d = 0; d < 8; d++) // soft glow
                {
                    float ang = d * Mathf.PI / 4f;
                    _s.normal.textColor = new Color(0.5f, 0.89f, 1f, 0.1f * a);
                    GUI.Label(new Rect(r.x + Mathf.Cos(ang) * 4f, r.y + Mathf.Sin(ang) * 4f, r.width, r.height), word[i].ToString(), _s);
                }
                _s.normal.textColor = new Color(0.02f, 0.03f, 0.1f, 0.55f * a);
                GUI.Label(new Rect(r.x + 2f, r.y + 5f, r.width, r.height), word[i].ToString(), _s);
                _s.normal.textColor = new Color(1f, 0.97f, 0.9f, a);
                GUI.Label(r, word[i].ToString(), _s);
                x += widths[i] + tracking;
            }
            // rule with diamonds under the word
            float ly = c.y + h * 0.48f;
            float lw = total * 0.8f;
            float la = Mathf.Clamp01(t * 1.2f - 0.6f);
            SystemWindow.Fill(new Rect(c.x - lw / 2f, ly, lw, 2f), SystemWindow.A(SystemWindow.Accent, 0.75f * la));
            foreach (float dx in new[] { -lw / 2f, 0f, lw / 2f })
            {
                var mm = GUI.matrix;
                GUIUtility.RotateAroundPivot(45f, new Vector2(c.x + dx, ly + 1f));
                SystemWindow.Fill(new Rect(c.x + dx - 5f, ly - 4f, 10f, 10f), SystemWindow.A(SystemWindow.Accent, la));
                GUI.matrix = mm;
            }
        }

        void DrawTitle(float vw, float vh)
        {
            DrawLogo(vw, vh, 0.38f, 1f);
            float t = Time.unscaledTime - _screenAt;
            float pulse = 0.65f + 0.35f * Mathf.Sin(Time.unscaledTime * 2.2f);
            float a = Mathf.Clamp01(t - 1.4f) * pulse;
            string prompt = SystemWindow.PadActive ? "Press A or Start" : "Press any key  /  Enter";
            T(new Rect(0, vh * 0.7f, vw, 40f), prompt, 24f, new Color(1f, 0.98f, 0.94f, a), TextAnchor.MiddleCenter, FontStyle.Bold, shadow: true);
            T(new Rect(24f, vh - 44f, 600f, 30f), "v" + Application.version + "   Phase 1 prototype", 14f, new Color(0.95f, 0.95f, 1f, 0.8f), shadow: true);
        }

        // ---- menu

        void DrawMenu(float vw, float vh)
        {
            var rows = MenuRows();
            float ts = Ts;
            float rowH = 50f * ts;
            float w = Mathf.Min(560f, vw - 40f);
            float hb = 46f * ts, fb = 40f * ts;
            float h = hb + 16f + rows.Count * rowH + 16f + fb + 4f;
            var r = new Rect((vw - w) / 2f, vh * 0.5f, w, h);
            float top = Chrome(r, "MAIN MENU", ts);
            for (int i = 0; i < rows.Count; i++)
            {
                var row = rows[i];
                var rr = new Rect(r.x + 14f, top + 8f + i * rowH, w - 28f, rowH);
                bool sel = i == _cursor && row.Act != null;
                if (row.Act != null) { _rects.Add(rr); _rectIndex.Add(i); }
                if (sel) { SystemWindow.RRect(rr, Contrast ? new Color(0.1f, 0.3f, 0.7f, 1f) : SystemWindow.Band, 3f); SystemWindow.Fill(new Rect(rr.x, rr.y + 3f, 3f, rr.height - 6f), SystemWindow.Accent); }
                if (row.Header) SystemWindow.Fill(new Rect(rr.x, rr.yMax - 2f, rr.width, 1f), SystemWindow.A(SystemWindow.Accent, 0.35f));
                var col = Contrast ? Color.white : row.Header ? SystemWindow.Accent : row.Note ? SystemWindow.TextDim : SystemWindow.TextCol;
                string label = (sel ? "▶ " : row.Act != null ? "   " : "") + row.Text;
                float right = rr.xMax - 10f;
                if (!string.IsNullOrEmpty(row.Right))
                {
                    var rw = Mathf.Min(rr.width * 0.5f, 260f);
                    T(new Rect(right - rw, rr.y, rw, rr.height), row.Right, 14f, SystemWindow.TextDim, TextAnchor.MiddleRight);
                }
                T(new Rect(rr.x + 8f, rr.y, rr.width - 16f, rr.height), label, row.Note ? 15f : 22f, col, TextAnchor.MiddleLeft, row.Header ? FontStyle.Bold : FontStyle.Normal);
            }
            if (!string.IsNullOrEmpty(StatusLine)) T(new Rect(r.x, r.yMax + 10f, r.width, 28f), StatusLine, 16f, SystemWindow.Warn, TextAnchor.MiddleCenter, FontStyle.Normal, shadow: true);
            Hints(new Rect(r.x + 2f, r.yMax - fb - 2f, r.width - 4f, fb), ts, new[]
            {
                (SystemWindow.PadActive ? "D-Pad Up/Down" : "Up/Down", "Choose"), (SystemWindow.PadActive ? "A" : "Enter", "Use"), (SystemWindow.PadActive ? "B" : "Esc", "Back"),
            });
        }

        /// <summary>The System window frame: glow, glass, line, brackets and the header bar with its title. Returns the y under the header.</summary>
        float Chrome(Rect r, string title, float ts)
        {
            bool contrast = Contrast;
            SystemWindow.RRect(new Rect(r.x - 5, r.y - 5, r.width + 10, r.height + 10), SystemWindow.A(SystemWindow.Accent, 0.07f), 11f, 3f);
            SystemWindow.RRect(new Rect(r.x - 2, r.y - 2, r.width + 4, r.height + 4), SystemWindow.A(SystemWindow.Accent, 0.14f), 8f, 2f);
            SystemWindow.RRect(r, contrast ? Color.black : SystemWindow.Panel, 6f);
            SystemWindow.RRect(r, SystemWindow.A(SystemWindow.Accent, 0.6f), 6f, 1f);
            SystemWindow.DrawBrackets(r);
            float hb = 46f * ts;
            var hr = new Rect(r.x + 2, r.y + 2, r.width - 4, hb);
            SystemWindow.Fill(hr, contrast ? new Color(0.05f, 0.15f, 0.3f, 1f) : new Color(0.1f, 0.22f, 0.36f, 0.9f));
            SystemWindow.Fill(new Rect(hr.x, hr.yMax - 1f, hr.width, 1f), SystemWindow.A(SystemWindow.Accent, 0.8f));
            float scan = Mathf.Repeat(Time.unscaledTime * 0.35f, 1f);
            SystemWindow.Fill(new Rect(hr.x, hr.y + scan * (hr.height - 2f), hr.width, 1f), SystemWindow.A(SystemWindow.Accent, 0.12f));
            T(new Rect(hr.x + 16, hr.y, 24, hr.height), "▶", 15f, SystemWindow.A(SystemWindow.Accent, 0.85f), TextAnchor.MiddleLeft, FontStyle.Bold);
            T(new Rect(hr.x + 40, hr.y, r.width - 80, hr.height), title, 24f, SystemWindow.Accent, TextAnchor.MiddleLeft, FontStyle.Bold);
            return hr.yMax;
        }

        void Hints(Rect fr, float ts, (string key, string verb)[] hints)
        {
            SystemWindow.Fill(fr, new Color(0.03f, 0.05f, 0.1f, 0.92f));
            SystemWindow.Fill(new Rect(fr.x, fr.y, fr.width, 1f), SystemWindow.A(SystemWindow.Accent, 0.45f));
            float hx = fr.x + 16f;
            foreach (var (key, verb) in hints)
            {
                _s.fontSize = Mathf.RoundToInt(14 * ts); _s.fontStyle = FontStyle.Bold;
                float kw = _s.CalcSize(new GUIContent(key)).x + 16f;
                _s.fontStyle = FontStyle.Normal;
                float vwid = _s.CalcSize(new GUIContent(verb)).x + 4f;
                var kr = new Rect(hx, fr.y + 8f * ts, kw, fr.height - 16f * ts);
                SystemWindow.RRect(kr, SystemWindow.A(SystemWindow.Accent, 0.16f), 4f);
                SystemWindow.RRect(kr, SystemWindow.A(SystemWindow.Accent, 0.7f), 4f, 1f);
                T(kr, key, 14f, SystemWindow.TextCol, TextAnchor.MiddleCenter, FontStyle.Bold);
                T(new Rect(kr.xMax + 6f, fr.y, vwid, fr.height), verb, 14f, SystemWindow.TextDim);
                hx = kr.xMax + 6f + vwid + 18f;
            }
        }

        // ---- creator

        void DrawCreator(float vw, float vh)
        {
            if (Creator == null) return;
            float ts = Ts;
            float pw = Mathf.Min(780f, vw * 0.5f - 60f);
            var r = new Rect(60f, 60f, pw, vh - 120f);
            float top = Chrome(r, "CREATE YOUR CHARACTER", ts);
            var order = CharacterCreatorState.Order;
            float fb = 40f * ts;
            float y = top + 12f;
            for (int i = 0; i < order.Length; i++)
            {
                var f = order[i];
                bool info = f == CharacterCreatorState.Field.RaceOrigin;
                float rh = (info ? 88f : 48f) * (info ? 1f : Mathf.Min(ts, 1.3f));
                var rr = new Rect(r.x + 14f, y, r.width - 28f, rh);
                y += rh + 4f;
                if (!info) { _rects.Add(rr); _rectIndex.Add(i); }
                bool sel = i == _creatorCursor && !info;
                if (sel) { SystemWindow.RRect(rr, Contrast ? new Color(0.1f, 0.3f, 0.7f, 1f) : SystemWindow.Band, 3f); SystemWindow.Fill(new Rect(rr.x, rr.y + 3f, 3f, rr.height - 6f), SystemWindow.Accent); }
                var labelCol = Contrast ? Color.white : info ? SystemWindow.TextDim : SystemWindow.TextCol;
                if (f == CharacterCreatorState.Field.Begin || f == CharacterCreatorState.Field.Back)
                {
                    T(new Rect(rr.x + 12f, rr.y, rr.width - 24f, rr.height), (sel ? "▶ " : "   ") + CharacterCreatorState.Label(f), f == CharacterCreatorState.Field.Begin ? 24f : 20f,
                        f == CharacterCreatorState.Field.Begin ? SystemWindow.Accent : labelCol, TextAnchor.MiddleLeft, f == CharacterCreatorState.Field.Begin ? FontStyle.Bold : FontStyle.Normal);
                    continue;
                }
                T(new Rect(rr.x + 12f, info ? rr.y + 4f : rr.y, 236f, info ? 30f : rr.height), (sel ? "▶ " : "   ") + CharacterCreatorState.Label(f), 19f, labelCol);
                if (info)
                {
                    T(new Rect(rr.x + 250f, rr.y + 4f, rr.width - 270f, 30f), "Human newcomer", 19f, SystemWindow.Accent, TextAnchor.MiddleLeft, FontStyle.Bold);
                    T(new Rect(rr.x + 24f, rr.y + 36f, rr.width - 48f, rr.height - 38f), Creator.Data.RaceOriginNote ?? "", 15f, SystemWindow.TextDim, TextAnchor.UpperLeft, FontStyle.Normal, true, true);
                    continue;
                }
                var vr = new Rect(rr.x + 250f, rr.y, rr.width - 270f, rr.height);
                var sw = Creator.Swatch(f);
                float vx = vr.x;
                T(new Rect(vr.x, vr.y, 24f, vr.height), f == CharacterCreatorState.Field.Name ? "" : "<", 22f, sel ? SystemWindow.Accent : SystemWindow.TextDim, TextAnchor.MiddleCenter, FontStyle.Bold);
                T(new Rect(vr.xMax - 24f, vr.y, 24f, vr.height), f == CharacterCreatorState.Field.Name ? "" : ">", 22f, sel ? SystemWindow.Accent : SystemWindow.TextDim, TextAnchor.MiddleCenter, FontStyle.Bold);
                if (sw.HasValue)
                {
                    var sr = new Rect(vx + 34f, vr.y + vr.height / 2f - 11f, 22f, 22f);
                    SystemWindow.RRect(sr, sw.Value, 5f);
                    SystemWindow.RRect(sr, new Color(1f, 1f, 1f, 0.85f), 5f, 1.5f);
                    vx += 30f;
                }
                if (f == CharacterCreatorState.Field.Name && _editingName)
                {
                    _field.fontSize = Mathf.RoundToInt(20 * ts);
                    _field.normal.textColor = Color.white; _field.focused.textColor = Color.white;
                    GUI.SetNextControlName("crName");
                    string now = GUI.TextField(new Rect(vr.x, vr.y + 6f, vr.width - 10f, vr.height - 12f), Creator.Look.PlayerName, Creator.MaxNameLength, _field);
                    if (now != Creator.Look.PlayerName) { Creator.SetName(now); }
                    if (_focusName) { GUI.FocusControl("crName"); _focusName = false; }
                }
                else
                {
                    string val = Creator.ValueText(f);
                    var rect = new Rect(vx + 34f, vr.y, vr.width - 70f - (vx - vr.x), vr.height);
                    T(rect, val, 20f, Contrast ? Color.white : SystemWindow.Accent, f == CharacterCreatorState.Field.Name ? TextAnchor.MiddleLeft : TextAnchor.MiddleCenter, FontStyle.Bold);
                    if (f == CharacterCreatorState.Field.Name && sel) T(new Rect(vr.xMax - 150f, vr.y, 146f, vr.height), SystemWindow.PadActive ? "A: type  X: suggest" : "Enter: type  X: suggest", 12f, SystemWindow.TextDim, TextAnchor.MiddleRight);
                }
            }
            string rowTip = _editingName ? "Type a name, then press Enter." : "Left and Right change a choice. Colours come from the game data.";
            T(new Rect(r.x + 20f, r.yMax - fb - 30f, r.width - 40f, 26f), rowTip, 14f, SystemWindow.TextDim);
            Hints(new Rect(r.x + 2f, r.yMax - fb - 2f, r.width - 4f, fb), ts, _editingName
                ? new[] { ("Enter", "Done"), ("Esc", "Done") }
                : new[] { (SystemWindow.PadActive ? "D-Pad" : "Arrows", "Choose / Change"), (SystemWindow.PadActive ? "A" : "Enter", "Use"), ("X", "Suggest name"), (SystemWindow.PadActive ? "B" : "Esc", "Back") });

            // the portrait card: the turning preview
            var card = new Rect(r.xMax + 50f, 60f, vw - r.xMax - 110f, vh - 120f);
            SystemWindow.RRect(new Rect(card.x - 5, card.y - 5, card.width + 10, card.height + 10), SystemWindow.A(SystemWindow.Accent, 0.07f), 11f, 3f);
            SystemWindow.RRect(card, SystemWindow.Panel, 6f);
            if (_preview != null && _preview.Texture != null)
            {
                var inner = new Rect(card.x + 6f, card.y + 6f, card.width - 12f, card.height - 12f);
                GUI.DrawTexture(inner, _preview.Texture, ScaleMode.ScaleAndCrop, false);
            }
            SystemWindow.RRect(card, SystemWindow.A(SystemWindow.Accent, 0.6f), 6f, 1f);
            SystemWindow.DrawBrackets(card);
            var plate = new Rect(card.x + 6f, card.yMax - 84f, card.width - 12f, 78f);
            SystemWindow.Fill(plate, new Color(0.03f, 0.05f, 0.12f, 0.72f));
            SystemWindow.Fill(new Rect(plate.x, plate.y, plate.width, 1f), SystemWindow.A(SystemWindow.Accent, 0.5f));
            T(new Rect(plate.x + 16f, plate.y + 4f, plate.width - 32f, 44f), Creator.Look.PlayerName, 30f, SystemWindow.TextCol, TextAnchor.MiddleLeft, FontStyle.Bold);
            T(new Rect(plate.x + 16f, plate.y + 44f, plate.width - 32f, 28f), Creator.ValueText(CharacterCreatorState.Field.Body) + "  ·  " + Creator.ValueText(CharacterCreatorState.Field.HairStyle) + " hair", 16f, SystemWindow.TextDim);
            T(new Rect(card.x + 16f, card.y + 10f, 200f, 24f), "PREVIEW", 13f, SystemWindow.A(SystemWindow.Accent, 0.85f), TextAnchor.MiddleLeft, FontStyle.Bold);
        }

        // ---- loading

        void DrawLoading(float vw, float vh)
        {
            float ts = Ts;
            var c = new Vector2(vw / 2f, vh * 0.34f);
            var m = GUI.matrix;
            GUIUtility.RotateAroundPivot(Time.unscaledTime * 40f, c);
            SystemWindow.DrawSigil(c, 150f);
            GUI.matrix = m;
            T(new Rect(0, c.y + 90f, vw, 50f), "LOADING", 34f, new Color(1f, 0.97f, 0.9f, 1f), TextAnchor.MiddleCenter, FontStyle.Bold, true, false, true);

            // the tip, in a glass strip
            var tip = new Rect(vw / 2f - 450f, vh * 0.64f, 900f, 96f * Mathf.Min(ts, 1.4f));
            SystemWindow.RRect(tip, Contrast ? Color.black : SystemWindow.Panel, 6f);
            SystemWindow.RRect(tip, SystemWindow.A(SystemWindow.Accent, 0.5f), 6f, 1f);
            T(new Rect(tip.x + 18f, tip.y + 10f, 60f, 26f), "TIP", 14f, SystemWindow.Accent, TextAnchor.MiddleLeft, FontStyle.Bold);
            T(new Rect(tip.x + 18f, tip.y + 34f, tip.width - 36f, tip.height - 40f), Tip ?? "", 20f, SystemWindow.TextCol, TextAnchor.UpperLeft, FontStyle.Normal, true, true);

            // the bar
            var bar = new Rect(vw / 2f - 360f, vh * 0.82f, 720f, 14f);
            SystemWindow.RRect(new Rect(bar.x - 3, bar.y - 3, bar.width + 6, bar.height + 6), SystemWindow.A(SystemWindow.Accent, 0.12f), 6f, 2f);
            SystemWindow.RRect(bar, new Color(0.08f, 0.12f, 0.24f, 0.95f), 4f);
            float p = Mathf.Clamp01(LoadProgress);
            if (p > 0.001f)
            {
                var fill = new Rect(bar.x, bar.y, Mathf.Max(8f, bar.width * p), bar.height);
                SystemWindow.RRect(fill, SystemWindow.Accent, 4f);
                float sh = Mathf.Repeat(Time.unscaledTime * 0.8f, 1f);
                SystemWindow.Fill(new Rect(fill.x + (fill.width - 30f) * sh, fill.y + 2f, 30f, 3f), new Color(1f, 1f, 1f, 0.45f));
            }
            SystemWindow.RRect(bar, SystemWindow.A(SystemWindow.Accent, 0.7f), 4f, 1f);
            T(new Rect(bar.x, bar.yMax + 6f, bar.width, 28f), Mathf.RoundToInt(p * 100f) + "%", 16f, SystemWindow.TextCol, TextAnchor.MiddleCenter, FontStyle.Bold, true, false, true);
        }
    }
}
