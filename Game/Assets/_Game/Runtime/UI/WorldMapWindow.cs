using System.Collections.Generic;
using System.Linq;
using Ascend.Core;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Ascend.Game
{
    /// <summary>
    /// The map (IMGUI placeholder; hud_and_ui.md §8, 12_Systems/world_map.md). Two pages:
    ///   Area: the ground around you drawn from above in ink, inked only where you've walked, with you, waystones,
    ///         people, named places, herb patches, your coin lantern and the tracked objective.
    ///   World: Aethwyrd on parchment — lands you've visited inked with their towns, Tyrant and siege banner, lands
    ///         you've heard of pencilled in, the rest blank; the System overlay (from Rank E) tints known lands by ring
    ///         and lays a grid over the sheet.
    /// Tab / M / View opens and closes it. 1 / 2 or LB / RB switch pages; scroll, + / − or the triggers zoom; drag,
    /// WASD or the left stick pan; C or R3 centres on you; O or Y toggles the System overlay. Hover a land to read it.
    /// Names that would overlap are skipped (the objective, places and people with quests come first).
    /// </summary>
    public sealed class WorldMapWindow : MonoBehaviour
    {
        public enum Page { Area, World }

        static WorldMapWindow _instance;
        public static bool IsOpen => _instance != null && _instance._open;
        public static WorldMapWindow Instance => _instance != null ? _instance : _instance = FindFirstObjectByType<WorldMapWindow>() ?? new GameObject("WorldMapWindow").AddComponent<WorldMapWindow>();

        bool _open, _needCapture, _overlay, _prevVisible;
        CursorLockMode _prevLock;
        PlayerMap _owner;
        float _openedAt;
        float _zoom = 2f, _areaZoom = 2.5f;
        Vector2 _centre = new Vector2(75f, 50f), _areaCentre = new Vector2(.5f, .5f);
        Vector2 _lastMouse;
        bool _mouseActive;
        Rect _mapRect;
        string _hover;
        readonly List<Rect> _placed = new List<Rect>();
        GUIStyle _title, _tab, _tabOn, _label, _labelBold, _pencil, _small, _side, _hint, _marker, _sea;
        Texture2D _dark, _paperTex;

        /// <summary>Review captures set this so stray keys and mouse moves can't pan the view mid-shot.</summary>
        public static bool IgnoreInput;

        public Page Current { get; private set; } = Page.Area;
        /// <summary>The current page's zoom.</summary>
        public float Zoom => Current == Page.World ? _zoom : _areaZoom;
        public Vector2 Centre => _centre;
        public bool OverlayOn => _overlay && _owner != null && _owner.HasSystemOverlay;
        /// <summary>The land under the cursor (or the view's centre) on the World page.</summary>
        public string Hovered => _hover;

        void Awake() { if (_instance == null) _instance = this; }
        void OnDestroy() { if (_instance == this) { if (_open) Close(); _instance = null; } }

        public void Toggle(PlayerMap owner) { if (_open) Close(); else Open(owner); }

        public void Open(PlayerMap owner, Page? page = null)
        {
            _owner = owner;
            _open = true;
            _openedAt = Time.unscaledTime;
            if (page.HasValue) Current = page.Value;
            owner.RevealHere();
            CentreOnYou();
            _hover = owner.Area != null ? owner.Area.RegionId : null;
            if (owner.Area != null && !AreaMapArt.HasDrawing(owner.Area.AreaId)) _needCapture = true;
            WorldMapArt.Begin();
            _lastMouse = Mouse.current != null ? Mouse.current.position.ReadValue() : Vector2.zero;
            _mouseActive = false;
            _prevLock = Cursor.lockState; _prevVisible = Cursor.visible;
            Cursor.lockState = CursorLockMode.None; Cursor.visible = true;
        }

        public void Close()
        {
            if (!_open) return;
            _open = false;
            Cursor.lockState = _prevLock; Cursor.visible = _prevVisible;
        }

        public void Show(Page page) => Current = page;

        /// <summary>Zooms the current page (World 1–6×, Area 1–5×).</summary>
        public void SetZoom(float z)
        {
            if (Current == Page.World) _zoom = Mathf.Clamp(z, 1f, 6f);
            else _areaZoom = Mathf.Clamp(z, 1f, 5f);
            ClampView();
        }

        public void ToggleOverlay() { if (_owner != null && _owner.HasSystemOverlay) _overlay = !_overlay; }

        void CentreOnYou()
        {
            if (_owner == null || _owner.Area == null) return;
            _centre = _owner.Area.ToWorldMap(_owner.transform.position);
            _areaCentre = _owner.Area.ToLocal(_owner.transform.position);
            ClampView();
        }

        void ClampView()
        {
            float vw = (float)WorldMapTerrain.Width / _zoom, vh = (float)WorldMapTerrain.Height / _zoom;
            _centre.x = Mathf.Clamp(_centre.x, vw / 2f, (float)WorldMapTerrain.Width - vw / 2f);
            _centre.y = Mathf.Clamp(_centre.y, vh / 2f, (float)WorldMapTerrain.Height - vh / 2f);
            float va = 1f / _areaZoom;
            _areaCentre.x = Mathf.Clamp(_areaCentre.x, va / 2f, 1f - va / 2f);
            _areaCentre.y = Mathf.Clamp(_areaCentre.y, va / 2f, 1f - va / 2f);
        }

        // ---------------------------------------------------------------- content (testable without drawing)

        /// <summary>The side panel for the current page, one line per row.</summary>
        public List<string> Lines()
        {
            var lines = new List<string>();
            if (_owner == null) return lines;
            var k = _owner.Knowledge;
            var db = AscendData.Db;
            var area = _owner.Area;
            if (Current == Page.Area)
            {
                if (area != null)
                {
                    lines.Add(area.Title);
                    if (db.Regions.TryGetValue(area.RegionId, out var reg)) lines.Add($"{reg.Name} · Ring {reg.Ring} · rank {reg.RankMin}–{reg.RankMax}");
                    lines.Add($"Explored {_owner.Fog.Explored * 100:0}% of the area");
                }
                lines.Add("");
                lines.Add("▲ You");
                lines.Add("◆ Waystone (glows when attuned)");
                lines.Add("! Someone with a quest for you");
                lines.Add("● Person   ✦ Named place");
                lines.Add("♣ Herb patch, pine or scrap ready");
                lines.Add("★ Tracked objective   ¤ Your coin lantern");
                var hud = FindFirstObjectByType<RingZeroHud>();
                var tracked = hud != null ? hud.TrackedObjective() : default;
                if (tracked.title != null) { lines.Add(""); lines.Add($"★ {tracked.title}"); if (!string.IsNullOrEmpty(tracked.objective)) lines.Add($"   {tracked.objective}{(tracked.distance >= 0 ? $" · {tracked.distance:0} m" : "")}"); }
            }
            else
            {
                var lands = db.Regions.Values.Where(r => r.Map != null && r.Layer == "surface").ToList();
                int visited = lands.Count(r => k.StatusOf(r.Id) == MapStatus.Visited), heard = lands.Count(r => k.StatusOf(r.Id) == MapStatus.Heard);
                lines.Add("Aethwyrd");
                lines.Add($"Lands inked: {visited} · pencilled: {heard} · blank: {lands.Count - visited - heard}");
                lines.Add(_owner.HasSystemOverlay ? $"System overlay: {(OverlayOn ? "on" : "off")} (O / Y)" : "System overlay: the guild's Rank E map seal");
                if (!WorldMapArt.Ready) lines.Add(WorldMapArt.Error != null ? $"The map could not be drawn: {WorldMapArt.Error}" : "The cartographer is still inking the map…");
                lines.Add("");
                lines.AddRange(RegionLines(_hover));
            }
            return lines;
        }

        /// <summary>What your map says about one land.</summary>
        public List<string> RegionLines(string regionId)
        {
            var lines = new List<string>();
            if (_owner == null) return lines;
            if (regionId == null || !AscendData.Db.Regions.TryGetValue(regionId, out var r)) { lines.Add("Open sea"); return lines; }
            var st = _owner.Knowledge.StatusOf(regionId);
            if (st == MapStatus.Unknown) { lines.Add("Uncharted"); lines.Add("Nobody you've met has been there."); return lines; }
            lines.Add(r.Name + (st == MapStatus.Heard ? " (heard of)" : ""));
            if (OverlayOn || st == MapStatus.Visited) lines.Add($"Ring {r.Ring} · rank {r.RankMin}–{r.RankMax}");
            var terrain = r.Map?.Terrain ?? new List<string>();
            if (terrain.Count > 0) lines.Add(string.Join(", ", terrain.Select(t => char.ToUpper(t[0]) + t.Substring(1))));
            if (st == MapStatus.Visited)
            {
                var places = r.Map?.Places?.Keys.ToList() ?? new List<string>();
                if (places.Count > 0) lines.Add("Towns: " + string.Join(", ", places));
                if (r.TyrantSpeciesId != null && AscendData.Db.Species.TryGetValue(r.TyrantSpeciesId, out var ty)) lines.Add($"Tyrant: {ty.Name}");
                lines.Add($"Siege: {StateOf(r)}");
            }
            else lines.Add("Pencilled in from what people say. Go there to ink it.");
            return lines;
        }

        static RegionState StateOf(RegionData r)
        {
            var siege = SiegeDirector.Instance;
            if (siege != null && siege.Threat != null && siege.Threat.RegionId == r.Id) return siege.Threat.State;
            return r.InitialState == "liberated" ? RegionState.Liberated : r.InitialState == "weakened" ? RegionState.Weakened : RegionState.Besieged;
        }

        // ---------------------------------------------------------------- input

        void Update()
        {
            if (!_open) return;
            if (_owner == null) { Close(); return; }
            if (_needCapture && _owner.Area != null)
            {
                _needCapture = false;
                try { AreaMapArt.Capture(_owner.Area); }
                catch (System.Exception e) { Debug.LogWarning($"Area map capture failed: {e.Message}"); }
            }
            if (Time.unscaledTime - _openedAt < 0.15f || IgnoreInput) return;
            float dt = Time.unscaledDeltaTime;
            var kb = Keyboard.current; var pad = Gamepad.current; var mouse = Mouse.current;
            if (kb != null)
            {
                if (kb.escapeKey.wasPressedThisFrame || kb.tabKey.wasPressedThisFrame || kb.mKey.wasPressedThisFrame) { Close(); return; }
                if (kb.digit1Key.wasPressedThisFrame) Current = Page.Area;
                if (kb.digit2Key.wasPressedThisFrame) Current = Page.World;
                if (kb.oKey.wasPressedThisFrame) ToggleOverlay();
                if (kb.cKey.wasPressedThisFrame) CentreOnYou();
                if (kb.equalsKey.wasPressedThisFrame || kb.numpadPlusKey.wasPressedThisFrame) SetZoom(Zoom * 1.25f);
                if (kb.minusKey.wasPressedThisFrame || kb.numpadMinusKey.wasPressedThisFrame) SetZoom(Zoom / 1.25f);
                Vector2 pan = Vector2.zero;
                if (kb.aKey.isPressed || kb.leftArrowKey.isPressed) pan.x -= 1;
                if (kb.dKey.isPressed || kb.rightArrowKey.isPressed) pan.x += 1;
                if (kb.wKey.isPressed || kb.upArrowKey.isPressed) pan.y -= 1;
                if (kb.sKey.isPressed || kb.downArrowKey.isPressed) pan.y += 1;
                Pan(pan * dt);
            }
            if (pad != null)
            {
                if (pad.buttonEast.wasPressedThisFrame || pad.selectButton.wasPressedThisFrame) { Close(); return; }
                if (pad.leftShoulder.wasPressedThisFrame) Current = Page.Area;
                if (pad.rightShoulder.wasPressedThisFrame) Current = Page.World;
                if (pad.buttonNorth.wasPressedThisFrame) ToggleOverlay();
                if (pad.rightStickButton.wasPressedThisFrame) CentreOnYou();
                float zoomIn = pad.rightTrigger.ReadValue() - pad.leftTrigger.ReadValue();
                if (Mathf.Abs(zoomIn) > .1f) SetZoom(Zoom * Mathf.Pow(2f, zoomIn * dt * 1.5f));
                var stick = pad.leftStick.ReadValue();
                if (stick.sqrMagnitude > .04f) { Pan(new Vector2(stick.x, -stick.y) * dt); _mouseActive = false; }
            }
            if (mouse != null)
            {
                float wheel = mouse.scroll.ReadValue().y;
                if (wheel > 0.01f) SetZoom(Zoom * 1.2f); else if (wheel < -0.01f) SetZoom(Zoom / 1.2f);
                var mp = mouse.position.ReadValue();
                if ((mp - _lastMouse).sqrMagnitude > 1f) _mouseActive = true;
                // Drag to pan (mouse y runs up, GUI y runs down).
                if (mouse.leftButton.isPressed && _mapRect.width > 0 && _mapRect.Contains(new Vector2(_lastMouse.x, Screen.height - _lastMouse.y)))
                {
                    Vector2 d = mp - _lastMouse;
                    if (Current == Page.World) _centre -= new Vector2(d.x, -d.y) / _mapRect.width * (float)WorldMapTerrain.Width / _zoom;
                    else _areaCentre -= d / _mapRect.width / _areaZoom;
                    ClampView();
                }
                _lastMouse = mp;
            }
        }

        /// <summary>Pans by a direction in screen terms (x right, y down), per second.</summary>
        void Pan(Vector2 dir)
        {
            if (dir == Vector2.zero) return;
            if (Current == Page.World) _centre += dir * 45f / _zoom;
            else _areaCentre += new Vector2(dir.x, -dir.y) * .3f / _areaZoom;
            ClampView();
        }

        // ---------------------------------------------------------------- drawing

        /// <summary>Reserves screen space for a label; false if it would overlap one already drawn this frame.</summary>
        bool Room(Rect r)
        {
            var padded = new Rect(r.x - 2, r.y - 1, r.width + 4, r.height + 2);
            foreach (var p in _placed) if (p.Overlaps(padded)) return false;
            _placed.Add(padded);
            return true;
        }

        void Label(Vector2 at, string text, GUIStyle style, float dx = 8f)
        {
            var size = style.CalcSize(new GUIContent(text));
            var r = new Rect(at.x + dx, at.y - size.y / 2f, size.x, size.y);
            if (Room(r)) Haloed(r, text, style);
        }

        /// <summary>Text with a parchment-coloured halo so it reads over drawn trees and peaks.</summary>
        void Haloed(Rect r, string text, GUIStyle style)
        {
            var ink = style.normal.textColor;
            style.normal.textColor = new Color(.95f, .9f, .78f, .85f);
            for (int dx = -1; dx <= 1; dx++)
                for (int dy = -1; dy <= 1; dy++)
                    if (dx != 0 || dy != 0) GUI.Label(new Rect(r.x + dx, r.y + dy, r.width, r.height), text, style);
            style.normal.textColor = ink;
            GUI.Label(r, text, style);
        }

        /// <summary>A small siege banner: red for Besieged or Weakened, green for Liberated.</summary>
        void Banner(Rect r, RegionState state)
        {
            var colour = state == RegionState.Liberated ? new Color(.15f, .5f, .2f) : new Color(.7f, .12f, .1f);
            GUI.DrawTexture(new Rect(r.x, r.y + 1, 1.5f, r.height - 2), Texture2D.whiteTexture, ScaleMode.StretchToFill, false, 0, new Color(.23f, .16f, .11f), 0, 0);
            GUI.DrawTexture(new Rect(r.x + 1.5f, r.y + 2, 9, 6), Texture2D.whiteTexture, ScaleMode.StretchToFill, false, 0, colour, 0, 0);
        }

        void OnGUI()
        {
            if (!_open || _owner == null) return;
            GUI.depth = -20;
            _placed.Clear();
            EnsureStyles();
            float sw = Screen.width, sh = Screen.height;
            GUI.DrawTexture(new Rect(0, 0, sw, sh), _dark);

            // Header: page tabs.
            GUI.Label(new Rect(24, 12, 400, 36), "MAP", _title);
            if (GUI.Button(new Rect(120, 14, 150, 30), "1  AREA", Current == Page.Area ? _tabOn : _tab)) Current = Page.Area;
            if (GUI.Button(new Rect(278, 14, 150, 30), "2  WORLD", Current == Page.World ? _tabOn : _tab)) Current = Page.World;
            if (_owner.HasSystemOverlay && Current == Page.World && GUI.Button(new Rect(436, 14, 190, 30), OverlayOn ? "O  System overlay ✓" : "O  System overlay", OverlayOn ? _tabOn : _tab)) ToggleOverlay();

            // Map area and side panel.
            const float side = 320f;
            var area = new Rect(24, 58, sw - side - 64, sh - 100);
            float aspect = Current == Page.World ? 1.5f : 1f;
            float w = Mathf.Min(area.width, area.height * aspect), h = w / aspect;
            _mapRect = new Rect(area.x + (area.width - w) / 2f, area.y + (area.height - h) / 2f, w, h);
            GUI.DrawTexture(new Rect(_mapRect.x - 6, _mapRect.y - 6, w + 12, h + 12), Texture2D.whiteTexture, ScaleMode.StretchToFill, false, 0, new Color(.3f, .2f, .12f), 0, 0);
            if (Current == Page.World) DrawWorld(_mapRect); else DrawArea(_mapRect);

            var panel = new Rect(sw - side - 24, 58, side, sh - 100);
            GUI.DrawTexture(panel, _paperTex);
            float y = panel.y + 12;
            foreach (var line in Lines())
            {
                float lh = _side.CalcHeight(new GUIContent(line), panel.width - 24);
                GUI.Label(new Rect(panel.x + 12, y, panel.width - 24, lh), line, _side);
                y += Mathf.Max(lh, 8f);
            }
            GUI.Label(new Rect(24, sh - 36, sw - 48, 24),
                "Tab / M close  ·  1 / 2 or LB / RB pages  ·  scroll or triggers zoom  ·  drag, WASD or stick pan  ·  C centre on you" + (_owner.HasSystemOverlay ? "  ·  O System overlay" : ""), _hint);
        }

        void DrawWorld(Rect r)
        {
            var k = _owner.Knowledge;
            var tex = WorldMapArt.Composite(k, _owner.Version);
            if (tex == null)
            {
                GUI.DrawTexture(r, _paperTex);
                GUI.Label(r, WorldMapArt.Error ?? "The cartographer is still inking the map…", _labelBold);
                return;
            }
            float W = (float)WorldMapTerrain.Width, H = (float)WorldMapTerrain.Height;
            float vw = W / _zoom, vh = H / _zoom, x0 = _centre.x - vw / 2f, y0 = _centre.y - vh / 2f;
            var uv = new Rect(x0 / W, 1f - (y0 + vh) / H, vw / W, vh / H);
            GUI.DrawTextureWithTexCoords(r, tex, uv);
            Vector2 S(double mx, double my) => new Vector2(r.x + ((float)mx - x0) / vw * r.width, r.y + ((float)my - y0) / vh * r.height);
            bool Inside(Vector2 p) => r.Contains(p);

            if (OverlayOn)
            {
                GUI.DrawTextureWithTexCoords(r, WorldMapArt.Overlay(k, _owner.Version), uv);
                var old = GUI.color; GUI.color = new Color(.25f, .55f, 1f, .35f);
                for (int gx = 0; gx <= 150; gx += 10) { var p = S(gx, 0); if (p.x >= r.x && p.x <= r.xMax) GUI.DrawTexture(new Rect(p.x, r.y, 1, r.height), Texture2D.whiteTexture); }
                for (int gy = 0; gy <= 100; gy += 10) { var p = S(0, gy); if (p.y >= r.y && p.y <= r.yMax) GUI.DrawTexture(new Rect(r.x, p.y, r.width, 1), Texture2D.whiteTexture); }
                GUI.color = old;
            }

            // You are here: the marker is reserved first; its label finds a free spot after the land names.
            var youAt = _owner.Area.ToWorldMap(_owner.transform.position);
            var you = S(youAt.x, youAt.y);
            if (Inside(you)) Room(new Rect(you.x - 10, you.y - 10, 20, 20));

            float fs = Mathf.Clamp(11f + _zoom * 2.2f, 12f, 24f);
            _label.fontSize = _labelBold.fontSize = _pencil.fontSize = Mathf.RoundToInt(fs);
            _small.fontSize = Mathf.RoundToInt(Mathf.Clamp(fs * .7f, 10f, 15f));
            var known = AscendData.Db.Regions.Values.Where(reg => reg.Map != null && k.StatusOf(reg.Id) != MapStatus.Unknown).ToList();
            // Land names first (visited before heard), then you, then siege banners, towns and gates where they fit.
            var banners = new List<(Vector2 at, float y, RegionState state)>();
            foreach (var reg in known.Where(x => x.Layer != "underworld").OrderByDescending(x => k.StatusOf(x.Id)))
            {
                var at = S(reg.Map.X, reg.Map.Y);
                if (!Inside(at)) continue;
                var st = k.StatusOf(reg.Id);
                var style = st == MapStatus.Visited ? _labelBold : _pencil;
                var size = style.CalcSize(new GUIContent(reg.Name));
                var nameRect = new Rect(at.x - size.x / 2f, at.y - size.y / 2f, size.x, size.y);
                Room(nameRect);
                Haloed(nameRect, reg.Name, style);
                float ly = nameRect.yMax;
                if (OverlayOn)
                {
                    var chip = new Rect(at.x - 34, ly, 68, 16);
                    Room(chip);
                    GUI.DrawTexture(chip, Texture2D.whiteTexture, ScaleMode.StretchToFill, false, 0, WorldMapArt.RingColours[Mathf.Clamp(reg.Ring, 0, 9)], 0, 3);
                    GUI.Label(chip, $"R{reg.Ring} · {reg.RankMin}–{reg.RankMax}", _marker);
                    ly += 17;
                }
                if (st == MapStatus.Visited && reg.TyrantSpeciesId != null) banners.Add((at, ly, StateOf(reg)));
            }
            Rect? youLabel = null;
            if (Inside(you))
            {
                var ysz = _small.CalcSize(new GUIContent("You are here"));
                foreach (var off in new[] { new Vector2(14, -32), new Vector2(14, 12), new Vector2(-14 - ysz.x, -32), new Vector2(-14 - ysz.x, 12), new Vector2(16, -ysz.y / 2f) })
                {
                    var yr = new Rect(you.x + off.x, you.y + off.y, ysz.x, ysz.y);
                    if (Room(yr)) { youLabel = yr; break; }
                }
            }
            foreach (var (at, ly, stt) in banners)
            {
                string flag = stt.ToString();
                var old = _small.normal.textColor;
                _small.normal.textColor = stt == RegionState.Liberated ? new Color(.15f, .45f, .2f) : new Color(.6f, .12f, .1f);
                var fsz = _small.CalcSize(new GUIContent(flag));
                var fr = new Rect(at.x - fsz.x / 2f + 7f, ly + 3f, fsz.x, fsz.y); // a small gap below the name
                if (Room(new Rect(fr.x - 14f, fr.y, fr.width + 14f, fr.height)))
                {
                    Banner(new Rect(fr.x - 13f, fr.y + 2f, 12f, fr.height - 4f), stt);
                    Haloed(fr, flag, _small);
                }
                _small.normal.textColor = old;
            }
            // Seas come after the lands (background features, low contrast) and only where they fit.
            _sea.fontSize = Mathf.RoundToInt(fs * 1.1f);
            foreach (var sea in k.KnownSeas())
            {
                var at = S(sea.At[0], sea.At[1]);
                if (!Inside(at)) continue;
                var size = _sea.CalcSize(new GUIContent(sea.Name));
                var sr = new Rect(at.x - size.x / 2f, at.y - size.y / 2f, size.x, size.y);
                if (Room(sr)) Haloed(sr, sea.Name, _sea);
            }
            foreach (var reg in known.Where(x => x.Layer != "underworld" && k.StatusOf(x.Id) == MapStatus.Visited && x.Map.Places != null))
                if (_zoom >= 1.6f)
                    foreach (var pl in reg.Map.Places)
                    {
                        var pp = S(pl.Value[0], pl.Value[1]);
                        if (!Inside(pp)) continue;
                        Glyph(pp, "●", new Color(.23f, .16f, .11f), 12);
                        if (_zoom >= 2.4f) Label(pp, pl.Key, _small);
                    }
            var shownGates = new HashSet<string>();
            foreach (var reg in known.Where(x => x.Layer == "underworld" && x.Map.Gate))
            {
                var at = S(reg.Map.X, reg.Map.Y);
                if (!shownGates.Add(reg.Map.X + "," + reg.Map.Y) || !Inside(at)) continue;
                Glyph(at, "▼", new Color(.36f, .14f, .48f), 18);
                if (_zoom >= 2f) Label(at, GateName(reg), _small, 10f);
            }

            if (Inside(you))
            {
                float pulse = 9f + 3f * Mathf.Sin(Time.unscaledTime * 4f);
                GUI.DrawTexture(new Rect(you.x - pulse, you.y - pulse, pulse * 2, pulse * 2), Texture2D.whiteTexture, ScaleMode.StretchToFill, true, 0, new Color(.9f, .2f, .1f, .35f), 0, pulse);
                Glyph(you, "●", new Color(.75f, .1f, .05f), 16);
                if (youLabel.HasValue) Haloed(youLabel.Value, "You are here", _small);
            }

            // Compass, and the land under the cursor (or the centre when using a pad).
            Glyph(new Vector2(r.x + 32, r.y + 34), "N", new Color(.23f, .16f, .11f), 22);
            Glyph(new Vector2(r.x + 32, r.y + 52), "↑", new Color(.23f, .16f, .11f), 18);
            Vector2 probe;
            if (_mouseActive && Mouse.current != null && r.Contains(Event.current.mousePosition)) probe = Event.current.mousePosition;
            else { probe = r.center; Glyph(probe, "+", new Color(.23f, .16f, .11f, .7f), 20); }
            float ux = x0 + (probe.x - r.x) / r.width * vw, uy = y0 + (probe.y - r.y) / r.height * vh;
            _hover = WorldMapArt.Terrain.RegionAt(ux, uy)?.Id;
        }

        static string GateName(RegionData r) => r.Id.StartsWith("reg_labyrinth") ? "Great Labyrinth" : r.Name + " gate";

        void DrawArea(Rect r)
        {
            var area = _owner.Area;
            var tex = area != null ? AreaMapArt.Composite(area, _owner.Fog) : null;
            if (tex == null)
            {
                GUI.DrawTexture(r, _paperTex);
                GUI.Label(r, "Sketching the area…", _labelBold);
                return;
            }
            float vs = 1f / _areaZoom, ax0 = _areaCentre.x - vs / 2f, ay0 = _areaCentre.y - vs / 2f;
            GUI.DrawTextureWithTexCoords(r, tex, new Rect(ax0, ay0, vs, vs));
            var fog = _owner.Fog;
            Vector2 L(Vector3 world) { var l = area.ToLocal(world); return new Vector2(r.x + (l.x - ax0) / vs * r.width, r.y + (1f - (l.y - ay0) / vs) * r.height); }
            bool Seen(Vector3 world) => fog.IsRevealedAt(world.x, world.z) && r.Contains(L(world));
            _small.fontSize = 13; _label.fontSize = 14;
            var ink = new Color(.23f, .16f, .11f);

            // Reserve the objective and you first so names stay clear of them.
            var hud = FindFirstObjectByType<RingZeroHud>();
            var tracked = hud != null ? hud.TrackedObjective() : default;
            Vector2? goal = null;
            if (tracked.at.HasValue)
            {
                var at = L(tracked.at.Value);
                at.x = Mathf.Clamp(at.x, r.x + 8, r.xMax - 8); at.y = Mathf.Clamp(at.y, r.y + 8, r.yMax - 8);
                goal = at;
                Room(new Rect(at.x - 11, at.y - 11, 22, 22));
            }
            var you = L(_owner.transform.position);
            Room(new Rect(you.x - 11, you.y - 11, 22, 22));

            foreach (var g in GatherNode.All)
                if (g != null && g.Ready && Seen(g.transform.position)) Glyph(L(g.transform.position), "♣", new Color(.2f, .45f, .15f), 15);
            foreach (var p in FindObjectsByType<QuestPlace>(FindObjectsSortMode.None))
            {
                if (string.IsNullOrEmpty(p.ShownAs) || !Seen(p.transform.position)) continue;
                var at = L(p.transform.position);
                Glyph(at, "✦", new Color(.55f, .32f, .08f), 15);
                Label(at, p.ShownAs, _small);
            }
            foreach (var w in FindObjectsByType<Waystone>(FindObjectsSortMode.None))
            {
                if (!Seen(w.transform.position)) continue;
                var at = L(w.transform.position);
                if (w.Attuned)
                {
                    // Attuned waystones glow in the region's siege colour (hud_and_ui.md §28).
                    bool free = AscendData.Db.Regions.TryGetValue(area.RegionId, out var reg) && StateOf(reg) == RegionState.Liberated;
                    float pulse = 10f + 2f * Mathf.Sin(Time.unscaledTime * 3f);
                    GUI.DrawTexture(new Rect(at.x - pulse, at.y - pulse, pulse * 2, pulse * 2), Texture2D.whiteTexture, ScaleMode.StretchToFill, true, 0, free ? new Color(.2f, .8f, .3f, .4f) : new Color(.9f, .25f, .15f, .4f), 0, pulse);
                }
                Glyph(at, "◆", new Color(.2f, .45f, .85f), 18);
                Label(at, "Waystone", _small, 10f);
            }
            // People: those with a quest for you get their names first; others are named once you zoom in.
            foreach (var g in FindObjectsByType<QuestGiver>(FindObjectsSortMode.None).Where(g => g != null).OrderByDescending(g => g.HasMarker))
            {
                if (!Seen(g.transform.position)) continue;
                var at = L(g.transform.position);
                Glyph(at, "●", new Color(.15f, .3f, .6f), 13);
                if (g.HasMarker && r.Contains(at + new Vector2(0, -20))) Glyph(at + new Vector2(0, -13), "!", new Color(.85f, .55f, .05f), 18);
                if (g.HasMarker || _areaZoom >= 3f) Label(at, g.DisplayName, _small);
            }
            var resp = _owner.GetComponent<PlayerRespawn>();
            if (resp != null && resp.Lantern != null && r.Contains(L(resp.Lantern.transform.position))) Glyph(L(resp.Lantern.transform.position), "¤", new Color(.85f, .6f, .05f), 20);
            if (goal.HasValue) Glyph(goal.Value, "★", new Color(.95f, .7f, .1f), 22);

            // You: an arrow turned to your facing (north is up).
            if (r.Contains(you))
            {
                var m = GUI.matrix;
                GUIUtility.RotateAroundPivot(_owner.transform.eulerAngles.y, you);
                Glyph(you, "▲", new Color(.75f, .1f, .05f), 22);
                GUI.matrix = m;
            }

            Glyph(new Vector2(r.x + 26, r.y + 28), "N", ink, 22);
            Glyph(new Vector2(r.x + 26, r.y + 46), "↑", ink, 18);
            // Scale bar: 20 m.
            float px20 = 20f / area.Size / vs * r.width;
            GUI.DrawTexture(new Rect(r.x + 18, r.yMax - 22, px20, 3), Texture2D.whiteTexture, ScaleMode.StretchToFill, false, 0, ink, 0, 0);
            GUI.Label(new Rect(r.x + 18, r.yMax - 42, 80, 18), "20 m", _small);
        }

        void Glyph(Vector2 at, string text, Color colour, int size)
        {
            _marker.fontSize = size;
            var old = _marker.normal.textColor;
            _marker.normal.textColor = colour;
            GUI.Label(new Rect(at.x - size, at.y - size * .65f, size * 2, size * 1.3f), text, _marker);
            _marker.normal.textColor = old;
            _marker.fontSize = 11;
        }

        void EnsureStyles()
        {
            if (_title != null) return;
            var ink = new Color(.23f, .16f, .11f);
            _dark = Solid(new Color(.1f, .075f, .055f, .97f));
            _paperTex = Solid(new Color(.93f, .87f, .73f));
            _title = new GUIStyle(GUI.skin.label) { fontSize = 26, fontStyle = FontStyle.Bold, normal = { textColor = new Color(.95f, .85f, .6f) } };
            _tab = new GUIStyle(GUI.skin.button) { fontSize = 15, fontStyle = FontStyle.Bold };
            _tabOn = new GUIStyle(_tab) { normal = { background = Solid(new Color(.8f, .62f, .3f)), textColor = new Color(.15f, .1f, .05f) } };
            _label = new GUIStyle(GUI.skin.label) { fontSize = 14, normal = { textColor = ink }, alignment = TextAnchor.MiddleLeft, wordWrap = false, clipping = TextClipping.Overflow };
            _labelBold = new GUIStyle(_label) { fontStyle = FontStyle.Bold, alignment = TextAnchor.MiddleCenter };
            _pencil = new GUIStyle(_label) { fontStyle = FontStyle.Italic, normal = { textColor = new Color(.32f, .3f, .28f) }, alignment = TextAnchor.MiddleCenter };
            _sea = new GUIStyle(_label) { fontStyle = FontStyle.Italic, normal = { textColor = new Color(.2f, .3f, .4f) }, alignment = TextAnchor.MiddleCenter };
            _small = new GUIStyle(_label) { fontSize = 12 };
            _side = new GUIStyle(_label) { fontSize = 15, wordWrap = true, alignment = TextAnchor.UpperLeft };
            _hint = new GUIStyle(GUI.skin.label) { fontSize = 13, normal = { textColor = new Color(.85f, .78f, .62f) } };
            _marker = new GUIStyle(GUI.skin.label) { fontSize = 11, alignment = TextAnchor.MiddleCenter, fontStyle = FontStyle.Bold, normal = { textColor = ink }, wordWrap = false, clipping = TextClipping.Overflow };
        }

        static Texture2D Solid(Color c)
        {
            var t = new Texture2D(1, 1) { hideFlags = HideFlags.DontSave };
            t.SetPixel(0, 0, c); t.Apply();
            return t;
        }
    }
}
