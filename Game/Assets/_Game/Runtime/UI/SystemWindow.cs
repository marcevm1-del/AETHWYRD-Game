using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Ascend.Game
{
    /// <summary>
    /// Shared body of the Phase 1 "anime System windows" (IMGUI placeholder, hud_and_ui.md): a dark panel with a title, a status
    /// line, a scrolling list of rows (headers, text, selectable rows with an optional slider bar) and a footer of controls.
    /// Subclasses only describe their rows in <see cref="Build"/>. Controls: Up/Down (D-pad) move, Enter (A) uses the row,
    /// Left/Right (D-pad, Q/E, bumpers) change a value or turn the page, Esc (B) closes. Layout is authored for 1600x900 and
    /// scaled up from there (4K), fonts also follow the saved text scale and the high-contrast panel setting.
    /// </summary>
    public abstract class SystemWindow : MonoBehaviour
    {
        /// <summary>One line of a window. A row with <see cref="Act"/> or <see cref="Adjust"/> can be selected.</summary>
        public sealed class Row
        {
            public string Text;
            /// <summary>Enter / A on the row.</summary>
            public Action Act;
            /// <summary>Left / Right on the row (-1 or +1).</summary>
            public Action<int> Adjust;
            /// <summary>0..1 draws a bar at the right of the row; below 0 draws none.</summary>
            public float Bar = -1f;
            public bool Header;
            public bool Dim;
            public bool Selectable => Act != null || Adjust != null;
        }

        static readonly List<SystemWindow> All = new List<SystemWindow>();
        static int _lastCloseFrame = -10;

        /// <summary>True while any Phase 1 window is open, and for the frame one closed (so the Esc that closed it cannot also open the status window).</summary>
        public static bool AnyOpen
        {
            get
            {
                if (Time.frameCount - _lastCloseFrame <= 1) return true;
                for (int i = 0; i < All.Count; i++) { var w = All[i]; if (w != null && w._open) return true; }
                return false;
            }
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        static void ResetStatics() { All.Clear(); _lastCloseFrame = -10; }

        /// <summary>Closes every open Phase 1 window (photo mode uses it when it opens).</summary>
        public static void CloseAll() { foreach (var w in All.ToList()) if (w != null && w._open) w.Close(); }

        /// <summary>Lets a non-window (photo mode) say it just closed, so the Esc that closed it is not also read by the status window.</summary>
        public static void NoteClosed() => _lastCloseFrame = Time.frameCount;

        protected bool _open;
        GameObject _player;
        PlayerWorldState _world;
        readonly List<Row> _rows = new List<Row>();
        int _cursor, _scroll, _drawnCursor = -1, _visibleRows = 12;
        float _openedAt, _nextRefresh;
        GUIStyle _label, _title;
        static Texture2D _white;

        /// <summary>The window's name in the title bar.</summary>
        protected abstract string Title { get; }
        /// <summary>Fills in the rows. Called on open, after every action and twice a second while open.</summary>
        protected abstract void Build(List<Row> rows);
        /// <summary>Second line of the footer (page hints and the like).</summary>
        protected virtual string Footer => "";
        protected virtual void OnOpened() { }
        protected virtual void OnClosed() { }
        /// <summary>Left/Right with no value row under the cursor (a page turn).</summary>
        protected virtual void OnPage(int dir) { }

        public bool Opened => _open;
        public IReadOnlyList<Row> Rows => _rows;
        /// <summary>The status line under the title (what the last action did).</summary>
        public string Line { get; protected set; } = "";

        /// <summary>The player the window reads (the first PlayerCombat in the scene unless a test sets one).</summary>
        public GameObject PlayerObject
        {
            get
            {
                if (_player == null) { var c = FindFirstObjectByType<PlayerCombat>(); _player = c != null ? c.gameObject : null; }
                return _player;
            }
            set { _player = value; _world = null; }
        }

        protected PlayerWorldState World
        {
            get
            {
                if (_world == null)
                {
                    var p = PlayerObject;
                    _world = p != null ? p.GetComponent<PlayerWorldState>() : null;
                    if (_world == null) _world = FindFirstObjectByType<PlayerWorldState>();
                }
                return _world;
            }
        }

        protected virtual void OnEnable()
        {
            if (!All.Contains(this)) All.Add(this);
            PlaytestShortcuts.OpenRequested += OnOpenRequested;
        }

        protected virtual void OnDisable()
        {
            All.Remove(this);
            PlaytestShortcuts.OpenRequested -= OnOpenRequested;
            if (_open) { _open = false; _lastCloseFrame = Time.frameCount; }
        }

        void OnOpenRequested(string windowName)
        {
            if (windowName != GetType().Name) return;
            if (_open) Close();
            else if (!WindowHub.OldModalOpen) Open();
        }

        public void Open(GameObject player = null)
        {
            if (player != null) PlayerObject = player;
            foreach (var w in All.ToList()) if (w != null && w != this && w._open) w.Close();
            if (PhotoModeController.IsOpen) PhotoModeController.Instance.Close();
            _open = true; _cursor = 0; _scroll = 0; _drawnCursor = -1; Line = ""; _openedAt = Time.unscaledTime; _nextRefresh = Time.unscaledTime + 0.5f;
            OnOpened();
            Rebuild();
        }

        public void Close()
        {
            if (!_open) return;
            _open = false;
            _lastCloseFrame = Time.frameCount;
            OnClosed();
        }

        public void Toggle(GameObject player = null) { if (_open) Close(); else Open(player); }

        /// <summary>Builds the rows again (also what tests call after changing state).</summary>
        public void Rebuild()
        {
            _rows.Clear();
            try { Build(_rows); }
            catch (Exception e)
            {
                _rows.Clear();
                _rows.Add(new Row { Text = "(this page could not be built: " + e.Message + ")", Dim = true });
                Debug.LogWarning($"{GetType().Name}: {e}");
            }
            if (_cursor >= _rows.Count) _cursor = Mathf.Max(0, _rows.Count - 1);
            if (_rows.Count > 0 && !_rows[_cursor].Selectable) { int n = NextSelectable(_cursor, 1); if (n < 0) n = NextSelectable(_cursor, -1); if (n >= 0) _cursor = n; }
        }

        /// <summary>The window's text, one string per row (the status line first when there is one). Tests read this.</summary>
        public List<string> Lines()
        {
            Rebuild();
            var lines = new List<string>();
            if (!string.IsNullOrEmpty(Line)) lines.Add(Line);
            lines.AddRange(_rows.Select(r => r.Text));
            return lines;
        }

        /// <summary>Uses a row as if Enter was pressed on it (rows with only a value change step it up). False when nothing happened.</summary>
        public bool Choose(int index)
        {
            if (index < 0 || index >= _rows.Count || !_rows[index].Selectable) return false;
            var row = _rows[index];
            if (row.Act != null) row.Act(); else row.Adjust(1);
            Rebuild();
            return true;
        }

        /// <summary>Changes a row's value by -1 or +1 as if Left/Right was pressed on it.</summary>
        public bool Change(int index, int dir)
        {
            if (index < 0 || index >= _rows.Count || _rows[index].Adjust == null) return false;
            _rows[index].Adjust(dir < 0 ? -1 : 1);
            Rebuild();
            return true;
        }

        int NextSelectable(int from, int dir)
        {
            for (int i = from + dir; i >= 0 && i < _rows.Count; i += dir) if (_rows[i].Selectable) return i;
            return -1;
        }

        void Move(int dir)
        {
            int n = NextSelectable(_cursor, dir);
            if (n >= 0) _cursor = n; else _scroll = Mathf.Max(0, _scroll + dir);
        }

        void Update()
        {
            if (!_open) return;
            if (Time.unscaledTime >= _nextRefresh) { _nextRefresh = Time.unscaledTime + 0.5f; Rebuild(); }
            if (Time.unscaledTime - _openedAt < 0.15f) return;
            var kb = Keyboard.current;
            if (kb != null)
            {
                if (kb.escapeKey.wasPressedThisFrame) { Close(); return; }
                if (kb.downArrowKey.wasPressedThisFrame) Move(1);
                if (kb.upArrowKey.wasPressedThisFrame) Move(-1);
                if (kb.pageDownKey.wasPressedThisFrame) _scroll += _visibleRows;
                if (kb.pageUpKey.wasPressedThisFrame) _scroll = Mathf.Max(0, _scroll - _visibleRows);
                if (kb.enterKey.wasPressedThisFrame) { Choose(_cursor); return; }
                if (kb.leftArrowKey.wasPressedThisFrame || kb.qKey.wasPressedThisFrame) Step(-1);
                if (kb.rightArrowKey.wasPressedThisFrame || kb.eKey.wasPressedThisFrame) Step(1);
            }
            var pad = Gamepad.current;
            if (pad != null)
            {
                if (pad.buttonEast.wasPressedThisFrame) { Close(); return; }
                if (pad.dpad.down.wasPressedThisFrame) Move(1);
                if (pad.dpad.up.wasPressedThisFrame) Move(-1);
                if (pad.buttonSouth.wasPressedThisFrame) { Choose(_cursor); return; }
                if (pad.dpad.left.wasPressedThisFrame || pad.leftShoulder.wasPressedThisFrame) Step(-1);
                if (pad.dpad.right.wasPressedThisFrame || pad.rightShoulder.wasPressedThisFrame) Step(1);
            }
        }

        void Step(int dir)
        {
            if (_cursor >= 0 && _cursor < _rows.Count && _rows[_cursor].Adjust != null) Change(_cursor, dir);
            else OnPage(dir);
        }

        // ------------------------------------------------------------------ drawing

        static readonly Color Panel = new Color(0.055f, 0.065f, 0.11f, 0.95f);
        static readonly Color Accent = new Color(0.45f, 0.75f, 1f, 1f);
        static readonly Color Gold = new Color(1f, 0.85f, 0.45f, 1f);
        static readonly Color TextCol = new Color(0.94f, 0.95f, 0.98f, 1f);
        static readonly Color TextDim = new Color(0.66f, 0.72f, 0.82f, 1f);
        static readonly Color Band = new Color(0.2f, 0.35f, 0.62f, 0.75f);

        static void Fill(Rect r, Color c)
        {
            _white ??= Texture2D.whiteTexture;
            var old = GUI.color;
            GUI.color = c;
            GUI.DrawTexture(r, _white);
            GUI.color = old;
        }

        void OnGUI()
        {
            if (!_open) return;
            var a = World != null ? World.Accessibility : null;
            float ts = a != null ? Mathf.Clamp((float)a.TextScale, 0.8f, 2f) : 1f;
            bool contrast = a != null && a.HighContrastPanels;
            float k = Mathf.Max(1f, Screen.height / 900f);
            float vw = Screen.width / k, vh = Screen.height / k;
            _label ??= new GUIStyle(GUI.skin.label) { wordWrap = false, clipping = TextClipping.Clip, alignment = TextAnchor.MiddleLeft };
            _title ??= new GUIStyle(GUI.skin.label) { fontStyle = FontStyle.Bold };

            var oldMatrix = GUI.matrix;
            GUI.matrix = Matrix4x4.Scale(new Vector3(k, k, 1f));

            float w = Mathf.Min(940f, vw - 40f), h = Mathf.Min(700f, vh - 40f);
            var r = new Rect((vw - w) / 2f, (vh - h) / 2f, w, h);
            Fill(r, contrast ? new Color(0f, 0f, 0f, 1f) : Panel);
            Fill(new Rect(r.x, r.y, r.width, 4f), Accent);
            Fill(new Rect(r.x, r.yMax - 2f, r.width, 2f), Accent);

            _title.fontSize = Mathf.RoundToInt(24 * ts);
            _title.normal.textColor = Gold;
            GUI.Label(new Rect(r.x + 20, r.y + 10, w - 40, 34 * ts), Title, _title);

            _label.fontSize = Mathf.RoundToInt(15 * ts);
            float rowH = 22f * ts;
            float top = r.y + 48f * ts;
            if (!string.IsNullOrEmpty(Line))
            {
                _label.normal.textColor = Accent;
                GUI.Label(new Rect(r.x + 20, top, w - 40, rowH), Line, _label);
                top += rowH + 4f;
            }
            float listBottom = r.yMax - 14f - 2f * rowH;
            _visibleRows = Mathf.Max(3, (int)((listBottom - top) / rowH));
            if (_cursor != _drawnCursor)
            {
                if (_cursor < _scroll) _scroll = _cursor;
                if (_cursor >= _scroll + _visibleRows) _scroll = _cursor - _visibleRows + 1;
                _drawnCursor = _cursor;
            }
            _scroll = Mathf.Clamp(_scroll, 0, Mathf.Max(0, _rows.Count - _visibleRows));

            for (int i = 0; i < _visibleRows && _scroll + i < _rows.Count; i++)
            {
                int idx = _scroll + i;
                var row = _rows[idx];
                var rr = new Rect(r.x + 14, top + i * rowH, w - 28 - 10, rowH);
                bool selected = idx == _cursor && row.Selectable;
                if (selected) Fill(rr, contrast ? new Color(0.1f, 0.3f, 0.7f, 1f) : Band);
                _label.fontStyle = row.Header ? FontStyle.Bold : FontStyle.Normal;
                _label.normal.textColor = contrast ? Color.white : row.Header ? Gold : row.Dim ? TextDim : TextCol;
                float labelW = rr.width - 12 - (row.Bar >= 0f ? 230f : 0f);
                GUI.Label(new Rect(rr.x + 6, rr.y, labelW, rowH), (selected ? "▶ " : row.Selectable ? "   " : "") + row.Text, _label);
                if (row.Bar >= 0f)
                {
                    var bar = new Rect(rr.xMax - 214, rr.y + rowH / 2f - 5f, 200, 10);
                    Fill(bar, new Color(0.15f, 0.18f, 0.28f, 1f));
                    Fill(new Rect(bar.x, bar.y, bar.width * Mathf.Clamp01(row.Bar), bar.height), Accent);
                }
            }
            if (_rows.Count > _visibleRows)
            {
                float track = _visibleRows * rowH, thumb = Mathf.Max(18f, track * _visibleRows / _rows.Count);
                float y = top + (track - thumb) * _scroll / Mathf.Max(1, _rows.Count - _visibleRows);
                Fill(new Rect(r.xMax - 12, top, 4, track), new Color(1f, 1f, 1f, 0.08f));
                Fill(new Rect(r.xMax - 12, y, 4, thumb), TextDim);
            }

            _label.fontStyle = FontStyle.Normal;
            _label.fontSize = Mathf.RoundToInt(13 * ts);
            _label.normal.textColor = TextDim;
            GUI.Label(new Rect(r.x + 20, r.yMax - 14f - 2f * rowH, w - 40, rowH), "Up/Down choose · Enter use · Left/Right change · PgUp/PgDn scroll · Esc close", _label);
            if (!string.IsNullOrEmpty(Footer)) GUI.Label(new Rect(r.x + 20, r.yMax - 14f - rowH, w - 40, rowH), Footer, _label);

            GUI.matrix = oldMatrix;
        }

        // ------------------------------------------------------------------ helpers for subclasses

        protected static Row Header(string text) => new Row { Text = text, Header = true };
        protected static Row Info(string text, bool dim = false) => new Row { Text = text, Dim = dim };

        /// <summary>Word-wraps text to lines of at most <paramref name="width"/> characters, each starting with <paramref name="indent"/>.</summary>
        protected static IEnumerable<string> Wrap(string text, int width, string indent = "")
        {
            if (string.IsNullOrEmpty(text)) yield break;
            var line = new System.Text.StringBuilder();
            foreach (var word in text.Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries))
            {
                if (line.Length > 0 && line.Length + 1 + word.Length > width) { yield return indent + line; line.Clear(); }
                if (line.Length > 0) line.Append(' ');
                line.Append(word);
            }
            if (line.Length > 0) yield return indent + line;
        }

        /// <summary>Finds the one component of a type, creating it on a new object when none exists (the lazy Instance pattern).</summary>
        protected static T Create<T>() where T : Component
        {
            var found = FindFirstObjectByType<T>();
            return found != null ? found : new GameObject(typeof(T).Name).AddComponent<T>();
        }
    }
}
