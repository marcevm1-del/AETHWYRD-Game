using System.Collections.Generic;
using System.Threading.Tasks;
using Ascend.Core;
using UnityEngine;
using UnityEngine.Rendering;

namespace Ascend.Game
{
    /// <summary>
    /// The world map's pictures: Core paints the parchment on a worker thread when the game loads, then the parchment
    /// is blended onto the blank sheet by what you know (inked where you've been, a grey pencil sketch where you've only
    /// heard of a land, bare paper elsewhere), with a ragged ink-bleed edge. The System overlay tints known lands by ring.
    /// </summary>
    public static class WorldMapArt
    {
        /// <summary>Painted width in pixels (tests use a small one).</summary>
        public static int PaintWidth = 1536;
        public static readonly Color[] RingColours =
        {
            Hex(0xf3e7b8), Hex(0xf6eccb), Hex(0xf2dc8e), Hex(0xf0c450), Hex(0xef9a33), Hex(0xe2672b), Hex(0xc63a2b), Hex(0xa5222b), Hex(0x7a1a2c), Hex(0x4c1430),
        };

        static Task<WorldMapImage> _task;
        static WorldMapTerrain _terrain;
        static Texture2D _composite, _overlay;
        static int _composedVersion = -1, _overlayVersion = -1;
        static float[] _bleed;
        static short[] _overlayGrid;
        const int OverlayW = 300, OverlayH = 200;

        public static WorldMapTerrain Terrain => _terrain ??= new WorldMapTerrain(AscendData.Db.Regions.Values);

        /// <summary>Starts painting (once); the map window shows "inking" until it's done.</summary>
        public static void Begin()
        {
            if (_task != null) return;
            var t = Terrain; int w = PaintWidth;
            _task = Task.Run(() => WorldMapPainter.Paint(t, w));
        }

        public static bool Ready => _task != null && _task.Status == TaskStatus.RanToCompletion;
        public static string Error => _task != null && _task.IsFaulted ? _task.Exception?.GetBaseException().Message : null;
        public static WorldMapImage Image => Ready ? _task.Result : null;

        /// <summary>Waits for the painting (tests and the screenshot runner).</summary>
        public static bool Wait(int milliseconds) { Begin(); try { return _task.Wait(milliseconds); } catch (System.AggregateException) { return false; } }

        public static void Reset()
        {
            _task = null; _terrain = null; _overlayGrid = null; _bleed = null;
            if (_composite != null) Object.Destroy(_composite);
            if (_overlay != null) Object.Destroy(_overlay);
            _composite = _overlay = null; _composedVersion = _overlayVersion = -1;
        }

        static float Status(MapStatus s, bool inkOnly) => inkOnly ? (s == MapStatus.Visited ? 1f : 0f) : (s == MapStatus.Unknown ? 0f : 1f);

        /// <summary>The parchment as this player knows it (recomposed when <paramref name="version"/> changes).</summary>
        public static Texture2D Composite(MapKnowledge k, int version)
        {
            var img = Image;
            if (img == null) return null;
            if (_composite != null && version == _composedVersion) return _composite;
            int W = img.Width, H = img.Height, n = W * H;
            var lands = Terrain.Lands;
            var ink = new float[lands.Count]; var pencil = new float[lands.Count];
            for (int i = 0; i < lands.Count; i++) { var st = k.StatusOf(lands[i].Id); ink[i] = Status(st, true); pencil[i] = Status(st, false); }

            // Coarse masks: a cell takes the best status of its land, the sea near known coasts is inked too.
            const int cell = 8;
            int gw = (W + cell - 1) / cell, gh = (H + cell - 1) / cell;
            var vi = new float[gw * gh]; var pe = new float[gw * gh]; var landCell = new bool[gw * gh];
            for (int y = 0; y < H; y++)
                for (int x = 0; x < W; x++)
                {
                    int li = img.Land[y * W + x];
                    if (li < 0) continue;
                    int c = (y / cell) * gw + x / cell;
                    landCell[c] = true;
                    if (ink[li] > vi[c]) vi[c] = ink[li];
                    if (pencil[li] > pe[c]) pe[c] = pencil[li];
                }
            Dilate(vi, landCell, gw, gh, 3); Dilate(pe, landCell, gw, gh, 3);
            Blur(vi, gw, gh); Blur(pe, gw, gh);

            if (_bleed == null || _bleed.Length != n)
            {
                _bleed = new float[n];
                for (int y = 0; y < H; y++)
                    for (int x = 0; x < W; x++)
                        _bleed[y * W + x] = (Mathf.PerlinNoise(x * .045f + 3.1f, y * .045f + 7.7f) + .5f * Mathf.PerlinNoise(x * .19f, y * .19f)) / 1.5f - .5f;
            }
            var paper = img.Paper; var parch = img.Parchment;
            var outPx = new byte[n * 4];
            for (int y = 0; y < H; y++)
            {
                float gy = (y + .5f) / cell - .5f;
                int dst = (H - 1 - y) * W; // Unity rows run from the bottom
                for (int x = 0; x < W; x++)
                {
                    float gx = (x + .5f) / cell - .5f;
                    float v = Bilinear(vi, gw, gh, gx, gy), p = Bilinear(pe, gw, gh, gx, gy), b = _bleed[y * W + x] * .4f;
                    float a = Smooth(.4f, .6f, v + b), sketch = Smooth(.4f, .6f, p + b) * .42f;
                    int s = (y * W + x) * 4, d = (dst + x) * 4;
                    float lum = (parch[s] * .3f + parch[s + 1] * .59f + parch[s + 2] * .11f);
                    for (int ch = 0; ch < 3; ch++)
                    {
                        float pc = paper[s + ch], grey = lum * (ch == 0 ? 1f : ch == 1 ? .97f : .93f);
                        float col = pc + (grey - pc) * sketch;
                        col += (parch[s + ch] - col) * a;
                        outPx[d + ch] = (byte)Mathf.Clamp(col, 0, 255);
                    }
                    outPx[d + 3] = 255;
                }
            }
            if (_composite == null || _composite.width != W) { if (_composite != null) Object.Destroy(_composite); _composite = new Texture2D(W, H, TextureFormat.RGBA32, false) { wrapMode = TextureWrapMode.Clamp, filterMode = FilterMode.Bilinear, name = "WorldMap" }; }
            _composite.SetPixelData(outPx, 0);
            _composite.Apply(false);
            _composedVersion = version;
            return _composite;
        }

        /// <summary>The System overlay: every land you know of tinted with its ring's colour (soft-edged, low resolution).</summary>
        public static Texture2D Overlay(MapKnowledge k, int version)
        {
            if (_overlay != null && version == _overlayVersion) return _overlay;
            _overlayGrid ??= Terrain.LandGrid(OverlayW, OverlayH);
            var lands = Terrain.Lands;
            var px = new Color32[OverlayW * OverlayH];
            for (int y = 0; y < OverlayH; y++)
                for (int x = 0; x < OverlayW; x++)
                {
                    int li = _overlayGrid[y * OverlayW + x];
                    Color c = Color.clear;
                    if (li >= 0 && k.StatusOf(lands[li].Id) != MapStatus.Unknown) { c = RingColours[Mathf.Clamp(lands[li].Ring, 0, 9)]; c.a = .42f; }
                    px[(OverlayH - 1 - y) * OverlayW + x] = c;
                }
            if (_overlay == null) _overlay = new Texture2D(OverlayW, OverlayH, TextureFormat.RGBA32, false) { wrapMode = TextureWrapMode.Clamp, filterMode = FilterMode.Bilinear, name = "WorldMapOverlay" };
            _overlay.SetPixels32(px);
            _overlay.Apply(false);
            _overlayVersion = version;
            return _overlay;
        }

        static void Dilate(float[] v, bool[] land, int w, int h, int r)
        {
            var src = (float[])v.Clone();
            for (int y = 0; y < h; y++)
                for (int x = 0; x < w; x++)
                {
                    if (land[y * w + x]) continue;
                    float best = 0;
                    for (int dy = -r; dy <= r; dy++)
                        for (int dx = -r; dx <= r; dx++)
                        {
                            int xx = x + dx, yy = y + dy;
                            if (xx < 0 || yy < 0 || xx >= w || yy >= h || !land[yy * w + xx]) continue;
                            if (dx * dx + dy * dy <= r * r && src[yy * w + xx] > best) best = src[yy * w + xx];
                        }
                    v[y * w + x] = best;
                }
        }

        static void Blur(float[] v, int w, int h)
        {
            var t = new float[v.Length];
            for (int y = 0; y < h; y++)
                for (int x = 0; x < w; x++)
                {
                    float s = 0; int c = 0;
                    for (int dy = -1; dy <= 1; dy++)
                        for (int dx = -1; dx <= 1; dx++)
                        {
                            int xx = x + dx, yy = y + dy;
                            if (xx < 0 || yy < 0 || xx >= w || yy >= h) continue;
                            s += v[yy * w + xx]; c++;
                        }
                    t[y * w + x] = s / c;
                }
            System.Array.Copy(t, v, v.Length);
        }

        internal static float Bilinear(float[] g, int w, int h, float x, float y)
        {
            x = Mathf.Clamp(x, 0, w - 1.001f); y = Mathf.Clamp(y, 0, h - 1.001f);
            int x0 = (int)x, y0 = (int)y; float ax = x - x0, ay = y - y0;
            int x1 = Mathf.Min(w - 1, x0 + 1), y1 = Mathf.Min(h - 1, y0 + 1);
            return Mathf.Lerp(Mathf.Lerp(g[y0 * w + x0], g[y0 * w + x1], ax), Mathf.Lerp(g[y1 * w + x0], g[y1 * w + x1], ax), ay);
        }

        internal static float Smooth(float a, float b, float v) { float t = Mathf.Clamp01((v - a) / (b - a)); return t * t * (3 - 2 * t); }

        static Color Hex(int rgb) => new Color(((rgb >> 16) & 255) / 255f, ((rgb >> 8) & 255) / 255f, (rgb & 255) / 255f);
    }

    /// <summary>
    /// The local Area map: a top-down picture of the scene (characters hidden) redrawn as ink on parchment — levels
    /// stretched, edges inked, colour kept faint — then blended onto paper by the cells you've explored.
    /// </summary>
    public static class AreaMapArt
    {
        public static int Resolution = 1280;
        static readonly Dictionary<string, Color32[]> Drawn = new Dictionary<string, Color32[]>();
        static Texture2D _composite;
        static string _composedFor;
        static int _composedCount = -1, _composedRes;

        public static bool HasDrawing(string areaId) => Drawn.ContainsKey(areaId);

        public static void Reset()
        {
            Drawn.Clear();
            if (_composite != null) Object.Destroy(_composite);
            _composite = null; _composedFor = null; _composedCount = -1;
        }

        /// <summary>Draws the area from above (call outside rendering, e.g. from Update). Kept for the session.</summary>
        public static void Capture(LocalMapArea area)
        {
            int res = Resolution;
            var hidden = new List<Renderer>();
            void Hide<T>() where T : Component
            {
                foreach (var c in Object.FindObjectsByType<T>(FindObjectsSortMode.None))
                    foreach (var r in c.GetComponentsInChildren<Renderer>())
                        if (r.enabled) { r.enabled = false; hidden.Add(r); }
            }
            Hide<MonsterDummy>(); Hide<QuestGiver>(); Hide<PlayerCombat>(); Hide<PartnerFollower>(); Hide<CoinLantern>();

            var go = new GameObject("AreaMapCamera");
            var cam = go.AddComponent<Camera>();
            cam.enabled = false;
            cam.orthographic = true;
            cam.orthographicSize = area.Size / 2f;
            cam.aspect = 1f;
            cam.nearClipPlane = 1f; cam.farClipPlane = 800f;
            cam.clearFlags = CameraClearFlags.SolidColor;
            cam.backgroundColor = new Color(.85f, .8f, .68f);
            cam.transform.SetPositionAndRotation(area.transform.position + Vector3.up * 400f, Quaternion.Euler(90f, 0f, 0f));
            var rt = RenderTexture.GetTemporary(res, res, 24, RenderTextureFormat.ARGB32);
            var tex = new Texture2D(res, res, TextureFormat.RGBA32, false);
            try
            {
                var request = new RenderPipeline.StandardRequest { destination = rt };
                if (RenderPipeline.SupportsRenderRequest(cam, request)) RenderPipeline.SubmitRenderRequest(cam, request);
                else { cam.targetTexture = rt; cam.Render(); cam.targetTexture = null; }
                var prev = RenderTexture.active;
                RenderTexture.active = rt;
                tex.ReadPixels(new Rect(0, 0, res, res), 0, 0);
                tex.Apply(false);
                RenderTexture.active = prev;
                Drawn[area.AreaId] = Stylize(tex.GetPixels32(), res);
            }
            finally
            {
                foreach (var r in hidden) if (r != null) r.enabled = true;
                RenderTexture.ReleaseTemporary(rt);
                Object.Destroy(tex);
                Object.Destroy(go);
            }
            if (_composedFor == area.AreaId) _composedCount = -1;
        }

        static Color32[] Stylize(Color32[] src, int res)
        {
            int n = res * res;
            var lum = new float[n];
            var hist = new int[256];
            for (int i = 0; i < n; i++) { var c = src[i]; lum[i] = (c.r * .3f + c.g * .59f + c.b * .11f) / 255f; hist[Mathf.Clamp((int)(lum[i] * 255), 0, 255)]++; }
            float lo = Percentile(hist, n, .02f), hi = Percentile(hist, n, .98f);
            if (hi - lo < .05f) { lo = 0; hi = 1; }
            var paper = new Color(.93f, .87f, .73f); var ink = new Color(.23f, .16f, .11f);
            var o = new Color32[n];
            for (int y = 0; y < res; y++)
                for (int x = 0; x < res; x++)
                {
                    int i = y * res + x;
                    float l = Mathf.Clamp01((lum[i] - lo) / (hi - lo));
                    float gx = 0, gy = 0;
                    if (x > 0 && y > 0 && x < res - 1 && y < res - 1)
                    {
                        gx = lum[i + 1 - res] + 2 * lum[i + 1] + lum[i + 1 + res] - lum[i - 1 - res] - 2 * lum[i - 1] - lum[i - 1 + res];
                        gy = lum[i - 1 + res] + 2 * lum[i + res] + lum[i + 1 + res] - lum[i - 1 - res] - 2 * lum[i - res] - lum[i + 1 - res];
                    }
                    float edge = Mathf.Clamp01((Mathf.Abs(gx) + Mathf.Abs(gy)) / (hi - lo) * 1.6f - .08f);
                    Color s = src[i];
                    Color tinted = Color.Lerp(paper, s * 1.1f, .38f) * (.62f + .45f * l);
                    Color c = Color.Lerp(tinted, ink, edge * .85f);
                    c *= 1f + (Mathf.PerlinNoise(x * .21f, y * .21f) - .5f) * .08f;
                    c.a = 1f;
                    o[i] = c;
                }
            return o;
        }

        static float Percentile(int[] hist, int n, float p)
        {
            int target = (int)(n * p), acc = 0;
            for (int i = 0; i < 256; i++) { acc += hist[i]; if (acc >= target) return i / 255f; }
            return 1f;
        }

        static Color32[] _mini;

        /// <summary>
        /// The HUD minimap: a disc of the area drawing around <paramref name="centre"/>, turned so the camera's forward is
        /// up, unexplored ground dimmed, soft round edge. Writes into <paramref name="tex"/> (made on first use).
        /// </summary>
        public static bool Minimap(LocalMapArea area, AreaFog fog, Vector3 centre, float yawDegrees, float range, ref Texture2D tex, int size = 128)
        {
            if (area == null || !Drawn.TryGetValue(area.AreaId, out var drawn)) return false;
            int res = Mathf.RoundToInt(Mathf.Sqrt(drawn.Length));
            if (tex == null || tex.width != size) tex = new Texture2D(size, size, TextureFormat.RGBA32, false) { wrapMode = TextureWrapMode.Clamp, name = "Minimap" };
            if (_mini == null || _mini.Length != size * size) _mini = new Color32[size * size];
            float half = size / 2f, yaw = yawDegrees * Mathf.Deg2Rad, s = Mathf.Sin(yaw), c = Mathf.Cos(yaw);
            var dim = new Color(.28f, .24f, .18f);
            for (int y = 0; y < size; y++)
                for (int x = 0; x < size; x++)
                {
                    float dx = (x + .5f - half) / half, dy = (y + .5f - half) / half, rr = Mathf.Sqrt(dx * dx + dy * dy);
                    int i = y * size + x;
                    if (rr > 1f) { _mini[i] = new Color32(0, 0, 0, 0); continue; }
                    // Screen right is the camera's right, screen up its forward (texture rows run upward).
                    float wx = centre.x + (dx * c + dy * s) * range, wz = centre.z + (-dx * s + dy * c) * range;
                    float u = (wx - area.MinX) / area.Size, v = (wz - area.MinZ) / area.Size;
                    Color col = u >= 0 && v >= 0 && u < 1 && v < 1 ? (Color)drawn[(int)(v * res) * res + (int)(u * res)] : dim;
                    if (!fog.IsRevealedAt(wx, wz)) col = Color.Lerp(col, dim, .7f);
                    col.a = Mathf.Clamp01((1f - rr) * 18f) * .95f;
                    _mini[i] = col;
                }
            tex.SetPixels32(_mini);
            tex.Apply(false);
            return true;
        }

        /// <summary>The drawing blended onto paper by the explored cells (null until <see cref="Capture"/> has run).</summary>
        public static Texture2D Composite(LocalMapArea area, AreaFog fog)
        {
            if (!Drawn.TryGetValue(area.AreaId, out var drawn)) return null;
            int res = Mathf.RoundToInt(Mathf.Sqrt(drawn.Length));
            if (_composite != null && _composedFor == area.AreaId && _composedCount == fog.RevealedCount && _composedRes == res) return _composite;
            int cells = fog.Cells;
            var mask = new float[cells * cells];
            for (int cz = 0; cz < cells; cz++) for (int cx = 0; cx < cells; cx++) mask[cz * cells + cx] = fog.IsRevealed(cx, cz) ? 1f : 0f;
            var px = new Color32[res * res];
            var paper = new Color(.93f, .87f, .73f);
            for (int y = 0; y < res; y++)
                for (int x = 0; x < res; x++)
                {
                    // Texture rows run south → north, the same way as the fog's cz.
                    float cx = (x + .5f) / res * cells - .5f, cz = (y + .5f) / res * cells - .5f;
                    float m = WorldMapArt.Bilinear(mask, cells, cells, cx, cz);
                    float n = (Mathf.PerlinNoise(x * .05f + 11f, y * .05f + 5f) - .5f) * .45f;
                    float a = WorldMapArt.Smooth(.42f, .58f, m + n);
                    Color p = paper * (1f + (Mathf.PerlinNoise(x * .31f, y * .07f) - .5f) * .07f);
                    Color c = Color.Lerp(p, drawn[y * res + x], a); c.a = 1f;
                    px[y * res + x] = c;
                }
            if (_composite == null || _composedRes != res) { if (_composite != null) Object.Destroy(_composite); _composite = new Texture2D(res, res, TextureFormat.RGBA32, false) { wrapMode = TextureWrapMode.Clamp, name = "AreaMap" }; }
            _composite.SetPixels32(px);
            _composite.Apply(false);
            _composedFor = area.AreaId; _composedCount = fog.RevealedCount; _composedRes = res;
            return _composite;
        }
    }
}
