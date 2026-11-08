using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Ascend.Game
{
    /// <summary>
    /// Shared body of the Phase 1 "anime System windows" (IMGUI placeholder, hud_and_ui.md, art_direction.md section 8): a navy glass panel
    /// with bracket corners and a faint cyan glow, a header bar with a cyan title, optional real tabs, a status line, a scrolling list of rows
    /// (headers, text, selectable rows with status chips, a slider bar or a detail pane) and a fixed footer bar of control hints that
    /// shows gamepad names after the last input came from a pad. Subclasses only describe their rows in <see cref="Build"/>.
    /// Controls: Up/Down (D-pad) move, Enter (A) uses the row, X (West) is the row's alternate action, Left/Right (D-pad, Q/E, bumpers)
    /// change a value or turn the page / tab, Esc (B) closes. Layout is authored for 1600x900 and scaled up from there (4K); fonts also
    /// follow the saved text scale and the high-contrast panel setting.
    /// </summary>
    public abstract class SystemWindow : MonoBehaviour
    {
        /// <summary>Colour of a chip on a row.</summary>
        public enum ChipKind { Neutral, Good, Bad, Warn }

        /// <summary>One line of a window. A row with <see cref="Act"/> or <see cref="Adjust"/> can be selected.</summary>
        public sealed class Row
        {
            public string Text;
            /// <summary>Enter / A on the row.</summary>
            public Action Act;
            /// <summary>Left / Right on the row (-1 or +1).</summary>
            public Action<int> Adjust;
            /// <summary>X / West on the row (the footer names it with <see cref="AltLabel"/>).</summary>
            public Action Alt;
            public string AltLabel;
            /// <summary>0..1 draws a bar at the right of the row (after the label for value rows); below 0 draws none.</summary>
            public float Bar = -1f;
            /// <summary>Where the default sits on the bar (a notch); below 0 draws none.</summary>
            public float BarDefault = -1f;
            public bool Header;
            public bool Dim;
            /// <summary>A short status at the right of the row ("Ready", "Missing 2 Prime Meat").</summary>
            public string Chip;
            public ChipKind ChipColor;
            /// <summary>A small neutral tag left of the chip (a skill and rank).</summary>
            public string Tag;
            /// <summary>An invitation shown on an empty page; a sigil is drawn in the free space below.</summary>
            public bool Invite;
            /// <summary>A note line (plain information under a setting), drawn indented in the readable secondary colour.</summary>
            public bool Note;
            /// <summary>Lines for the right-hand pane while this row is selected. Prefixes: "# " title, "+ " good (cyan), "! " bad (coral), "- " dim.</summary>
            public List<string> Detail;
            public bool Selectable => Act != null || Adjust != null;
        }

        static readonly List<SystemWindow> All = new List<SystemWindow>();
        static int _lastCloseFrame = -10;

        /// <summary>True when the last input came from a gamepad: the footer then names pad buttons. Tests and the capture runner may set it.</summary>
        public static bool PadActive { get; set; }

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
        static void ResetStatics() { All.Clear(); _lastCloseFrame = -10; PadActive = false; }

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
        GUIStyle _label, _title, _body, _chip;
        static Texture2D _white;

        /// <summary>The window's name in the title bar.</summary>
        protected abstract string Title { get; }
        /// <summary>Fills in the rows. Called on open, after every action and twice a second while open.</summary>
        protected abstract void Build(List<Row> rows);
        /// <summary>A note line above the footer bar (what the page means, in a sentence).</summary>
        protected virtual string Footer => "";
        /// <summary>Real tabs under the header (null for none); the lit one is <see cref="TabIndex"/>. Left/Right (Q/E, bumpers) turns them via <see cref="OnPage"/>.</summary>
        protected virtual string[] Tabs => null;
        protected virtual int TabIndex => 0;
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

        /// <summary>The window's text, one string per row (the status line first when there is one; a row's detail lines follow it). Tests read this.</summary>
        public List<string> Lines()
        {
            Rebuild();
            var lines = new List<string>();
            if (!string.IsNullOrEmpty(Line)) lines.Add(Line);
            foreach (var r in _rows)
            {
                lines.Add(r.Text);
                if (r.Detail != null) foreach (var d in r.Detail) lines.Add(StripMark(d));
            }
            return lines;
        }

        static string StripMark(string d) => d != null && d.Length > 2 && d[1] == ' ' && "#+!-~".IndexOf(d[0]) >= 0 ? d.Substring(2) : d;

        /// <summary>Uses a row as if Enter was pressed on it (rows with only a value change step it up). False when nothing happened.</summary>
        public bool Choose(int index)
        {
            if (index < 0 || index >= _rows.Count || !_rows[index].Selectable) return false;
            var row = _rows[index];
            if (row.Act != null) row.Act(); else row.Adjust(1);
            Rebuild();
            return true;
        }

        /// <summary>Runs a row's alternate action (X / West), such as a boosted craft. False when the row has none.</summary>
        public bool ChooseAlt(int index)
        {
            if (index < 0 || index >= _rows.Count || _rows[index].Alt == null) return false;
            _rows[index].Alt();
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
            var kb = Keyboard.current;
            var pad = Gamepad.current;
            // Which device the footer names: whichever was touched last.
            if (kb != null && kb.anyKey.wasPressedThisFrame) PadActive = false;
            if (pad != null && (pad.dpad.ReadValue().sqrMagnitude > 0.25f || pad.leftStick.ReadValue().sqrMagnitude > 0.25f || pad.buttonSouth.wasPressedThisFrame || pad.buttonEast.wasPressedThisFrame
                || pad.buttonWest.wasPressedThisFrame || pad.buttonNorth.wasPressedThisFrame || pad.leftShoulder.wasPressedThisFrame || pad.rightShoulder.wasPressedThisFrame)) PadActive = true;
            if (Time.unscaledTime - _openedAt < 0.15f) return;
            if (kb != null)
            {
                if (kb.escapeKey.wasPressedThisFrame) { Close(); return; }
                if (kb.downArrowKey.wasPressedThisFrame) Move(1);
                if (kb.upArrowKey.wasPressedThisFrame) Move(-1);
                if (kb.pageDownKey.wasPressedThisFrame) _scroll += _visibleRows;
                if (kb.pageUpKey.wasPressedThisFrame) _scroll = Mathf.Max(0, _scroll - _visibleRows);
                if (kb.enterKey.wasPressedThisFrame) { Choose(_cursor); return; }
                if (kb.xKey.wasPressedThisFrame) { ChooseAlt(_cursor); return; }
                if (kb.leftArrowKey.wasPressedThisFrame || kb.qKey.wasPressedThisFrame) Step(-1);
                if (kb.rightArrowKey.wasPressedThisFrame || kb.eKey.wasPressedThisFrame) Step(1);
            }
            if (pad != null)
            {
                if (pad.buttonEast.wasPressedThisFrame) { Close(); return; }
                if (pad.dpad.down.wasPressedThisFrame) Move(1);
                if (pad.dpad.up.wasPressedThisFrame) Move(-1);
                if (pad.buttonSouth.wasPressedThisFrame) { Choose(_cursor); return; }
                if (pad.buttonWest.wasPressedThisFrame) { ChooseAlt(_cursor); return; }
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

        // System palette (art_direction.md section 8): navy glass, cyan voice, coral for what is missing.
        static readonly Color Panel = new Color(0.055f, 0.075f, 0.14f, 0.84f);
        static readonly Color Accent = new Color(0.498f, 0.89f, 1f, 1f);        // #7FE3FF
        static readonly Color Coral = new Color(1f, 0.478f, 0.42f, 1f);          // #FF7A6B
        static readonly Color Warn = new Color(1f, 0.82f, 0.45f, 1f);
        static readonly Color TextCol = new Color(0.96f, 0.97f, 1f, 1f);
        static readonly Color TextDim = new Color(0.72f, 0.78f, 0.88f, 1f);       // #B8C8E0, over 7:1 on the panel
        static readonly Color Band = new Color(0.16f, 0.32f, 0.55f, 0.85f);

        static void Fill(Rect r, Color c)
        {
            _white ??= Texture2D.whiteTexture;
            var old = GUI.color;
            GUI.color = c;
            GUI.DrawTexture(r, _white);
            GUI.color = old;
        }

        /// <summary>A rounded rectangle: filled when <paramref name="border"/> is 0, an outline of that width otherwise.</summary>
        static void RRect(Rect r, Color c, float radius, float border = 0f)
        {
            _white ??= Texture2D.whiteTexture;
            GUI.DrawTexture(r, _white, ScaleMode.StretchToFill, true, 0f, c, new Vector4(border, border, border, border), new Vector4(radius, radius, radius, radius));
        }

        static Color A(Color c, float a) => new Color(c.r, c.g, c.b, a);

        void EnsureStyles()
        {
            _label ??= new GUIStyle(GUI.skin.label) { wordWrap = false, clipping = TextClipping.Clip, alignment = TextAnchor.MiddleLeft };
            _title ??= new GUIStyle(GUI.skin.label) { fontStyle = FontStyle.Bold, alignment = TextAnchor.MiddleLeft, wordWrap = false };
            _body ??= new GUIStyle(GUI.skin.label) { wordWrap = true, alignment = TextAnchor.UpperLeft };
            _chip ??= new GUIStyle(GUI.skin.label) { wordWrap = false, clipping = TextClipping.Clip, alignment = TextAnchor.MiddleCenter, fontStyle = FontStyle.Bold };
        }

        float TextW(GUIStyle s, string t) => s.CalcSize(new GUIContent(t)).x;

        void DrawChip(ref float right, Rect rr, string text, Color col, float ts, bool solid)
        {
            _chip.fontSize = Mathf.RoundToInt(14 * ts);
            float cw = TextW(_chip, text) + 18f;
            var cr = new Rect(right - cw, rr.y + 3f, cw, rr.height - 6f);
            if (solid) { RRect(cr, A(col, 0.22f), 4f); }
            RRect(cr, A(col, 0.9f), 4f, 1f);
            _chip.normal.textColor = col;
            GUI.Label(cr, text, _chip);
            right -= cw + 8f;
        }

        static Color ChipCol(ChipKind k) => k == ChipKind.Good ? Accent : k == ChipKind.Bad ? Coral : k == ChipKind.Warn ? Warn : TextDim;

        void OnGUI()
        {
            if (!_open) return;
            var a = World != null ? World.Accessibility : null;
            float ts = a != null ? Mathf.Clamp((float)a.TextScale, 0.8f, 2f) : 1f;
            bool contrast = a != null && a.HighContrastPanels;
            float k = Mathf.Max(1f, Screen.height / 900f);
            float vw = Screen.width / k, vh = Screen.height / k;
            EnsureStyles();

            var oldMatrix = GUI.matrix;
            GUI.matrix = Matrix4x4.Scale(new Vector3(k, k, 1f));

            // The panel sits a little above centre so it stays clear of the hotbar and the Combo Budget bar.
            float w = Mathf.Min(1000f, vw - 40f), h = Mathf.Min(680f, vh - 60f);
            var r = new Rect((vw - w) / 2f, (vh - h) / 2f - 20f, w, h);

            // --- chrome: soft glow, navy glass, 1 px cyan line, 14 px bracket corners
            RRect(new Rect(r.x - 5, r.y - 5, r.width + 10, r.height + 10), A(Accent, 0.07f), 11f, 3f);
            RRect(new Rect(r.x - 2, r.y - 2, r.width + 4, r.height + 4), A(Accent, 0.14f), 8f, 2f);
            RRect(r, contrast ? Color.black : Panel, 6f);
            RRect(r, A(Accent, 0.6f), 6f, 1f);
            DrawBrackets(r);

            // --- header bar with chevron, cyan title and a faint scan line drifting through it
            float hb = 46f * ts;
            var hr = new Rect(r.x + 2, r.y + 2, r.width - 4, hb);
            Fill(hr, contrast ? new Color(0.05f, 0.15f, 0.3f, 1f) : new Color(0.1f, 0.22f, 0.36f, 0.9f));
            Fill(new Rect(hr.x, hr.yMax - 1f, hr.width, 1f), A(Accent, 0.8f));
            float scan = Mathf.Repeat(Time.unscaledTime * 0.35f, 1f);
            Fill(new Rect(hr.x, hr.y + scan * (hr.height - 2f), hr.width, 1f), A(Accent, 0.12f));
            _title.fontSize = Mathf.RoundToInt(15 * ts);
            _title.normal.textColor = A(Accent, 0.85f);
            GUI.Label(new Rect(hr.x + 16, hr.y, 24, hr.height), "▶", _title);
            _title.fontSize = Mathf.RoundToInt(24 * ts);
            _title.normal.textColor = Accent;
            GUI.Label(new Rect(hr.x + 40, hr.y, w - 80, hr.height), (Title ?? "").ToUpperInvariant(), _title);

            float top = hr.yMax + 10f;
            // --- real tabs
            var tabs = Tabs;
            if (tabs != null && tabs.Length > 0)
            {
                float tx = r.x + 16f, th = 30f * ts;
                _chip.fontSize = Mathf.RoundToInt(16 * ts);
                for (int i = 0; i < tabs.Length; i++)
                {
                    float tw = TextW(_chip, tabs[i]) + 34f;
                    var tr = new Rect(tx, top, tw, th);
                    bool lit = i == TabIndex;
                    if (lit) RRect(tr, A(Accent, 0.95f), 5f); else RRect(tr, A(Accent, 0.4f), 5f, 1f);
                    _chip.normal.textColor = lit ? new Color(0.03f, 0.07f, 0.14f, 1f) : TextDim;
                    GUI.Label(tr, tabs[i], _chip);
                    tx += tw + 8f;
                }
                top += th + 10f;
            }

            float bodySize = 17f * ts;
            _label.fontSize = Mathf.RoundToInt(bodySize);
            float rowH = 28f * ts;
            if (!string.IsNullOrEmpty(Line))
            {
                _label.fontStyle = FontStyle.Normal;
                _label.normal.textColor = Accent;
                GUI.Label(new Rect(r.x + 20, top, w - 40, rowH), Line, _label);
                top += rowH + 4f;
            }

            // --- footer bar (fixed) with the control hints, and the page's note line above it
            float fb = 40f * ts;
            var fr = new Rect(r.x + 2, r.yMax - fb - 2f, r.width - 4, fb);
            Fill(fr, new Color(0.03f, 0.05f, 0.1f, 0.92f));
            Fill(new Rect(fr.x, fr.y, fr.width, 1f), A(Accent, 0.45f));
            float noteH = 0f;
            string note = Footer;
            if (!string.IsNullOrEmpty(note))
            {
                noteH = rowH;
                _label.fontSize = Mathf.RoundToInt(14 * ts);
                _label.fontStyle = FontStyle.Normal;
                _label.normal.textColor = TextDim;
                GUI.Label(new Rect(r.x + 20, fr.y - noteH - 2f, w - 40, noteH), note, _label);
                _label.fontSize = Mathf.RoundToInt(bodySize);
            }
            float listBottom = fr.y - noteH - 8f;

            // --- list and optional detail pane
            bool pane = _rows.Any(x => x.Detail != null);
            float listX = r.x + 14f, listW = pane ? (w - 28f) * 0.56f : w - 28f;
            _visibleRows = Mathf.Max(3, (int)((listBottom - top) / rowH));
            if (_cursor != _drawnCursor)
            {
                if (_cursor < _scroll) _scroll = _cursor;
                if (_cursor >= _scroll + _visibleRows) _scroll = _cursor - _visibleRows + 1;
                _drawnCursor = _cursor;
            }
            _scroll = Mathf.Clamp(_scroll, 0, Mathf.Max(0, _rows.Count - _visibleRows));

            bool anyInvite = false;
            int shown = 0;
            for (int i = 0; i < _visibleRows && _scroll + i < _rows.Count; i++)
            {
                int idx = _scroll + i;
                var row = _rows[idx];
                shown++;
                if (row.Invite) anyInvite = true;
                var rr = new Rect(listX, top + i * rowH, listW - 14f, rowH);
                bool selected = idx == _cursor && row.Selectable;
                if (selected)
                {
                    RRect(rr, contrast ? new Color(0.1f, 0.3f, 0.7f, 1f) : Band, 3f);
                    Fill(new Rect(rr.x, rr.y + 3f, 3f, rr.height - 6f), Accent);
                }
                if (row.Header)
                {
                    Fill(new Rect(rr.x, rr.yMax - 2f, rr.width, 1f), A(Accent, 0.35f));
                }
                _label.fontSize = Mathf.RoundToInt(bodySize);
                _label.fontStyle = row.Header ? FontStyle.Bold : FontStyle.Normal;
                Color col = contrast ? Color.white : row.Header ? Accent : row.Dim || row.Note ? TextDim : TextCol;
                _label.normal.textColor = col;

                float right = rr.xMax - 8f;
                if (!string.IsNullOrEmpty(row.Chip)) DrawChip(ref right, rr, row.Chip, ChipCol(row.ChipColor), ts, true);
                if (!string.IsNullOrEmpty(row.Tag)) DrawChip(ref right, rr, row.Tag, TextDim, ts, false);

                string text = row.Text ?? "";
                int split = row.Adjust != null && !row.Header ? text.IndexOf(": ", StringComparison.Ordinal) : -1;
                string prefix = selected ? "▶ " : row.Selectable ? "   " : "";
                if (split > 0)
                {
                    // Label, then the bar right after it, then the value: the eye never has to cross the panel.
                    string lab = text.Substring(0, split), val = text.Substring(split + 2);
                    float labW = Mathf.Min(420f * ts, rr.width * 0.55f);
                    GUI.Label(new Rect(rr.x + 6, rr.y, labW, rowH), prefix + lab, _label);
                    float vx = rr.x + 6 + labW + 10f;
                    if (row.Bar >= 0f)
                    {
                        var bar = new Rect(vx, rr.y + rowH / 2f - 5f, 220f, 10f);
                        RRect(bar, new Color(0.15f, 0.2f, 0.32f, 1f), 3f);
                        RRect(new Rect(bar.x, bar.y, Mathf.Max(6f, bar.width * Mathf.Clamp01(row.Bar)), bar.height), Accent, 3f);
                        Fill(new Rect(bar.x, bar.y - 3f, 1f, bar.height + 6f), A(TextDim, 0.7f));
                        Fill(new Rect(bar.xMax - 1f, bar.y - 3f, 1f, bar.height + 6f), A(TextDim, 0.7f));
                        if (row.BarDefault >= 0f) Fill(new Rect(bar.x + bar.width * Mathf.Clamp01(row.BarDefault) - 1f, bar.y - 5f, 2f, bar.height + 10f), A(Color.white, 0.85f));
                        vx = bar.xMax + 12f;
                    }
                    _label.fontStyle = FontStyle.Bold;
                    _label.normal.textColor = contrast ? Color.white : Accent;
                    GUI.Label(new Rect(vx, rr.y, Mathf.Max(40f, right - vx), rowH), val, _label);
                }
                else
                {
                    float barW = row.Bar >= 0f ? 220f : 0f;
                    float labelW = Mathf.Max(60f, right - rr.x - 12f - barW);
                    GUI.Label(new Rect(rr.x + 6 + (row.Note ? 20f : 0f), rr.y, labelW, rowH), prefix + text, _label);
                    if (row.Bar >= 0f)
                    {
                        var bar = new Rect(right - 210f, rr.y + rowH / 2f - 5f, 200f, 10f);
                        RRect(bar, new Color(0.15f, 0.2f, 0.32f, 1f), 3f);
                        RRect(new Rect(bar.x, bar.y, Mathf.Max(6f, bar.width * Mathf.Clamp01(row.Bar)), bar.height), Accent, 3f);
                    }
                }
            }

            // empty-state sigil in the free space under an invitation
            if (anyInvite)
            {
                float freeTop = top + shown * rowH + 10f;
                if (listBottom - freeTop > 140f) DrawSigil(new Vector2(listX + listW / 2f, (freeTop + listBottom) / 2f), Mathf.Min(60f, (listBottom - freeTop) / 3f));
            }

            if (_rows.Count > _visibleRows)
            {
                float track = _visibleRows * rowH, thumb = Mathf.Max(28f, track * _visibleRows / _rows.Count);
                float y = top + (track - thumb) * _scroll / Mathf.Max(1, _rows.Count - _visibleRows);
                RRect(new Rect(listX + listW - 10f, top, 8f, track), new Color(1f, 1f, 1f, 0.1f), 4f);
                RRect(new Rect(listX + listW - 10f, y, 8f, thumb), A(Accent, 0.85f), 4f);
            }

            if (pane) DrawPane(new Rect(listX + listW + 6f, top, w - 28f - listW - 6f, listBottom - top), _cursor >= 0 && _cursor < _rows.Count ? _rows[_cursor] : null, ts);

            // --- footer bar contents
            DrawHints(fr, ts, _rows.Count > _visibleRows && _scroll + _visibleRows < _rows.Count);

            GUI.matrix = oldMatrix;
        }

        static void DrawBrackets(Rect r)
        {
            const float L = 14f, T = 2f, o = 3f;
            var c = Accent;
            float x0 = r.x - o, y0 = r.y - o, x1 = r.xMax + o, y1 = r.yMax + o;
            Fill(new Rect(x0, y0, L, T), c); Fill(new Rect(x0, y0, T, L), c);
            Fill(new Rect(x1 - L, y0, L, T), c); Fill(new Rect(x1 - T, y0, T, L), c);
            Fill(new Rect(x0, y1 - T, L, T), c); Fill(new Rect(x0, y1 - L, T, L), c);
            Fill(new Rect(x1 - L, y1 - T, L, T), c); Fill(new Rect(x1 - T, y1 - L, T, L), c);
        }

        /// <summary>A faint diamond sigil (two nested outlines and a dot) for pages with nothing on them yet.</summary>
        static void DrawSigil(Vector2 c, float size)
        {
            var old = GUI.matrix;
            GUIUtility.RotateAroundPivot(45f, c);
            RRect(new Rect(c.x - size / 2f, c.y - size / 2f, size, size), A(Accent, 0.35f), 3f, 2f);
            float s2 = size * 0.62f;
            RRect(new Rect(c.x - s2 / 2f, c.y - s2 / 2f, s2, s2), A(Accent, 0.2f), 2f, 1f);
            float s3 = size * 0.16f;
            RRect(new Rect(c.x - s3 / 2f, c.y - s3 / 2f, s3, s3), A(Accent, 0.45f), 1f);
            GUI.matrix = old;
        }

        void DrawPane(Rect pr, Row row, float ts)
        {
            RRect(pr, new Color(0.06f, 0.1f, 0.18f, 0.75f), 4f);
            RRect(pr, A(Accent, 0.3f), 4f, 1f);
            float x = pr.x + 14f, wd = pr.width - 28f, y = pr.y + 10f;
            var lines = row != null ? row.Detail : null;
            if (lines == null || lines.Count == 0)
            {
                _body.fontSize = Mathf.RoundToInt(16 * ts);
                _body.fontStyle = FontStyle.Normal;
                _body.normal.textColor = TextDim;
                GUI.Label(new Rect(x, y, wd, pr.height - 20f), "Choose a recipe to see what it needs.", _body);
                return;
            }
            foreach (var d in lines)
            {
                char m = d.Length > 2 && d[1] == ' ' ? d[0] : ' ';
                string t = StripMark(d);
                bool title = m == '#';
                _body.fontSize = Mathf.RoundToInt((title ? 20 : 17) * ts);
                _body.fontStyle = title ? FontStyle.Bold : FontStyle.Normal;
                _body.normal.textColor = m == '#' ? Accent : m == '+' ? Accent : m == '!' ? Coral : m == '-' ? TextDim : TextCol;
                float hh = _body.CalcHeight(new GUIContent(t), wd);
                if (y + hh > pr.yMax - 6f) break;
                GUI.Label(new Rect(x, y, wd, hh), t, _body);
                y += hh + (title ? 8f : 4f);
            }
        }

        void DrawHints(Rect fr, float ts, bool more)
        {
            bool pad = PadActive;
            var hints = new List<(string key, string verb)>();
            var sel = _cursor >= 0 && _cursor < _rows.Count ? _rows[_cursor] : null;
            hints.Add((pad ? "D-Pad Up/Down" : "Up/Down", "Choose"));
            if (_rows.Any(x => x.Act != null)) hints.Add((pad ? "A" : "Enter", "Use"));
            if (sel != null && sel.Alt != null) hints.Add(("X", string.IsNullOrEmpty(sel.AltLabel) ? "Alternate" : sel.AltLabel));
            if (_rows.Any(x => x.Adjust != null)) hints.Add((pad ? "D-Pad Left/Right" : "Left/Right", "Change"));
            if (Tabs != null) hints.Add((pad ? "LB/RB" : "Q/E", "Switch tab"));
            if (!pad && _rows.Count > _visibleRows) hints.Add(("PgUp/PgDn", "Scroll"));
            hints.Add((pad ? "B" : "Esc", "Close"));

            _chip.fontSize = Mathf.RoundToInt(14 * ts);
            _label.fontSize = Mathf.RoundToInt(14 * ts);
            _label.fontStyle = FontStyle.Normal;
            float hx = fr.x + 16f;
            foreach (var (key, verb) in hints)
            {
                float kw = TextW(_chip, key) + 16f, vw2 = TextW(_label, verb) + 4f;
                var kr = new Rect(hx, fr.y + 8f * ts, kw, fr.height - 16f * ts);
                RRect(kr, A(Accent, 0.16f), 4f);
                RRect(kr, A(Accent, 0.7f), 4f, 1f);
                _chip.normal.textColor = TextCol;
                GUI.Label(kr, key, _chip);
                _label.normal.textColor = TextDim;
                GUI.Label(new Rect(kr.xMax + 6f, fr.y, vw2, fr.height), verb, _label);
                hx = kr.xMax + 6f + vw2 + 18f;
            }
            if (more)
            {
                _label.normal.textColor = Accent;
                _label.alignment = TextAnchor.MiddleRight;
                GUI.Label(new Rect(fr.xMax - 200f, fr.y, 184f, fr.height), "More below", _label);
                _label.alignment = TextAnchor.MiddleLeft;
            }
        }

        // ------------------------------------------------------------------ helpers for subclasses

        protected static Row Header(string text) => new Row { Text = text, Header = true };
        protected static Row Info(string text, bool dim = false) => new Row { Text = text, Dim = dim };
        protected static Row NoteRow(string text) => new Row { Text = text, Note = true };
        /// <summary>An empty-page invitation (a sigil is drawn under it).</summary>
        protected static Row Invite(string text) => new Row { Text = text, Dim = true, Invite = true };

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
