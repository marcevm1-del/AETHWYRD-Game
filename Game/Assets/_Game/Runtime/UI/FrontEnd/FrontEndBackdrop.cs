using UnityEngine;

namespace Ascend.Game
{
    /// <summary>
    /// The calm painted-sky backdrop of the front end, drawn with IMGUI from a few generated textures (no external art, no shader):
    /// a dusk-to-dawn gradient, a low warm glow, slow clouds, three layers of hills and floating motes of light.
    /// Everything is a function of <c>Time.unscaledTime</c> and a fixed seed, so captures are repeatable. Call <see cref="Draw"/> from OnGUI.
    /// </summary>
    public sealed class FrontEndBackdrop
    {
        Texture2D _sky, _glow, _cloud, _dot;
        Texture2D[] _hills;
        readonly Mote[] _motes = new Mote[70];

        struct Mote { public float X, Y, Speed, Size, Phase, Drift; }

        static readonly Color[] HillColours =
        {
            new Color(0.30f, 0.27f, 0.52f, 1f),
            new Color(0.19f, 0.19f, 0.40f, 1f),
            new Color(0.10f, 0.11f, 0.26f, 1f),
        };

        public FrontEndBackdrop()
        {
            _sky = Gradient();
            _glow = Radial(128, 1.6f);
            _dot = Radial(32, 2.2f);
            _cloud = Cloud();
            _hills = new[] { Hill(1024, 0.10f, new[] { 2f, 5f, 9f }, 0.7f), Hill(1024, 0.14f, new[] { 3f, 7f, 13f }, 2.1f), Hill(1024, 0.17f, new[] { 4f, 9f, 17f }, 4.2f) };
            var rnd = new System.Random(20261108);
            for (int i = 0; i < _motes.Length; i++)
                _motes[i] = new Mote { X = (float)rnd.NextDouble(), Y = (float)rnd.NextDouble(), Speed = 0.012f + (float)rnd.NextDouble() * 0.03f, Size = 3f + (float)rnd.NextDouble() * 7f, Phase = (float)rnd.NextDouble() * 6.28f, Drift = 0.01f + (float)rnd.NextDouble() * 0.03f };
        }

        public void Dispose()
        {
            if (_sky != null) Object.Destroy(_sky);
            if (_glow != null) Object.Destroy(_glow);
            if (_cloud != null) Object.Destroy(_cloud);
            if (_dot != null) Object.Destroy(_dot);
            if (_hills != null) foreach (var h in _hills) if (h != null) Object.Destroy(h);
        }

        // ------------------------------------------------------------------ textures

        static Texture2D Make(int w, int h, TextureWrapMode wrap)
        {
            var t = new Texture2D(w, h, TextureFormat.RGBA32, false) { wrapMode = wrap, filterMode = FilterMode.Bilinear, hideFlags = HideFlags.HideAndDontSave };
            return t;
        }

        static Texture2D Gradient()
        {
            var t = Make(1, 256, TextureWrapMode.Clamp);
            // top to horizon: deep indigo, violet, rose, peach; row 0 is the bottom of the screen.
            var stops = new[]
            {
                (0.00f, new Color(0.09f, 0.12f, 0.29f)), (0.40f, new Color(0.22f, 0.21f, 0.50f)),
                (0.68f, new Color(0.62f, 0.42f, 0.62f)), (0.84f, new Color(0.96f, 0.67f, 0.62f)), (0.93f, new Color(1f, 0.82f, 0.64f)), (1.00f, new Color(0.30f, 0.27f, 0.52f)),
            };
            var px = new Color32[256];
            for (int y = 0; y < 256; y++)
            {
                float v = 1f - y / 255f; // 0 at the top of the screen
                Color c = stops[stops.Length - 1].Item2;
                for (int i = 0; i < stops.Length - 1; i++)
                    if (v >= stops[i].Item1 && v <= stops[i + 1].Item1) { c = Color.Lerp(stops[i].Item2, stops[i + 1].Item2, Mathf.SmoothStep(0f, 1f, Mathf.InverseLerp(stops[i].Item1, stops[i + 1].Item1, v))); break; }
                px[y] = c;
            }
            t.SetPixels32(px); t.Apply(false);
            return t;
        }

        static Texture2D Radial(int n, float power)
        {
            var t = Make(n, n, TextureWrapMode.Clamp);
            var px = new Color32[n * n];
            for (int y = 0; y < n; y++)
                for (int x = 0; x < n; x++)
                {
                    float dx = (x + 0.5f) / n * 2f - 1f, dy = (y + 0.5f) / n * 2f - 1f;
                    float a = Mathf.Clamp01(1f - Mathf.Sqrt(dx * dx + dy * dy));
                    a = Mathf.Pow(a, power);
                    px[y * n + x] = new Color(1f, 1f, 1f, a);
                }
            t.SetPixels32(px); t.Apply(false);
            return t;
        }

        static Texture2D Cloud()
        {
            const int w = 256, h = 64;
            var t = Make(w, h, TextureWrapMode.Clamp);
            var px = new Color32[w * h];
            for (int y = 0; y < h; y++)
                for (int x = 0; x < w; x++)
                {
                    float dx = (x + 0.5f) / w * 2f - 1f, dy = (y + 0.5f) / h * 2f - 1f;
                    float lump = 0.75f + 0.25f * Mathf.Sin(dx * 9f) * Mathf.Cos(dx * 4f + 1f);
                    float a = Mathf.Clamp01(1f - Mathf.Sqrt(dx * dx * 0.9f + dy * dy / (lump * lump)));
                    px[y * w + x] = new Color(1f, 1f, 1f, Mathf.Pow(a, 1.4f));
                }
            t.SetPixels32(px); t.Apply(false);
            return t;
        }

        /// <summary>A seamless hill silhouette (sum of whole-number sine cycles), solid below the ridge, soft at the edge.</summary>
        static Texture2D Hill(int w, float baseline, float[] cycles, float phase)
        {
            const int h = 192;
            var t = Make(w, h, TextureWrapMode.Repeat);
            var px = new Color32[w * h];
            for (int x = 0; x < w; x++)
            {
                float u = x / (float)w * Mathf.PI * 2f;
                float ridge = 0f, amp = 1f;
                for (int i = 0; i < cycles.Length; i++) { ridge += Mathf.Sin(u * cycles[i] + phase * (i + 1)) * amp; amp *= 0.5f; }
                float top = h * (0.55f + 0.25f * ridge / 1.75f + baseline); // ridge height in pixels
                for (int y = 0; y < h; y++)
                {
                    float a = Mathf.Clamp01(top - y); // 1 px soft edge
                    px[y * w + x] = new Color(1f, 1f, 1f, a);
                }
            }
            t.SetPixels32(px); t.Apply(false);
            return t;
        }

        // ------------------------------------------------------------------ drawing (call inside OnGUI, no GUI.matrix set)

        /// <param name="dim">0 = bright, up to 0.6 darkens the sky for the loading and creator screens.</param>
        public void Draw(float dim = 0f)
        {
            float w = Screen.width, h = Screen.height, t = Time.unscaledTime;
            var old = GUI.color;
            GUI.color = Color.white;
            GUI.DrawTexture(new Rect(0, 0, w, h), _sky, ScaleMode.StretchToFill, false);

            // the low sun glow, breathing very slowly
            float breathe = 0.85f + 0.15f * Mathf.Sin(t * 0.35f);
            GUI.color = new Color(1f, 0.78f, 0.55f, 0.55f * breathe);
            float gw = w * 0.9f, gh = h * 0.9f;
            GUI.DrawTexture(new Rect(w * 0.5f - gw / 2f, h * 0.74f - gh / 2f, gw, gh), _glow);

            // a few faint stars in the dark top band
            for (int i = 0; i < 26; i++)
            {
                float sx = Frac(i * 0.6180339f + 0.13f) * w, sy = Frac(i * 0.7548776f + 0.31f) * h * 0.38f;
                float tw = 0.35f + 0.35f * Mathf.Sin(t * (0.6f + (i % 5) * 0.23f) + i);
                GUI.color = new Color(1f, 0.97f, 0.9f, tw * (1f - sy / (h * 0.45f)));
                float s = 2f + (i % 3);
                GUI.DrawTexture(new Rect(sx - s, sy - s, s * 2f, s * 2f), _dot);
            }

            // slow clouds
            for (int i = 0; i < 5; i++)
            {
                float speed = 0.004f + i * 0.0015f;
                float cx = Mathf.Repeat(i * 0.31f + t * speed, 1.4f) - 0.2f;
                float cy = 0.22f + (i % 3) * 0.13f;
                float cw = w * (0.36f + 0.1f * (i % 2)), ch = cw * 0.2f;
                GUI.color = new Color(1f, 0.82f, 0.8f, 0.2f + 0.05f * (i % 2));
                GUI.DrawTexture(new Rect(cx * w - cw / 2f, cy * h - ch / 2f, cw, ch), _cloud);
            }

            // hills, three layers, drifting at different speeds
            for (int i = 0; i < _hills.Length; i++)
            {
                float u = Mathf.Repeat(t * (0.002f + i * 0.0025f) + i * 0.27f, 1f);
                GUI.color = HillColours[i];
                float y = h * (0.62f + i * 0.09f);
                GUI.DrawTextureWithTexCoords(new Rect(0, y, w, h - y), _hills[i], new Rect(u, 0f, 1f, 1f));
            }

            // motes: warm lights rising slowly, swaying
            for (int i = 0; i < _motes.Length; i++)
            {
                var m = _motes[i];
                float y = 1f - Mathf.Repeat(m.Y + t * m.Speed, 1f);
                float x = Mathf.Repeat(m.X + Mathf.Sin(t * 0.3f + m.Phase) * m.Drift, 1f);
                float tw = 0.5f + 0.5f * Mathf.Sin(t * 1.3f + m.Phase * 3f);
                float edge = Mathf.Clamp01(Mathf.Min(y, 1f - y) * 6f);
                GUI.color = new Color(1f, 0.92f, 0.7f, (0.25f + 0.55f * tw) * edge);
                float s = m.Size * (h / 900f);
                GUI.DrawTexture(new Rect(x * w - s, y * h - s, s * 2f, s * 2f), _dot);
            }

            if (dim > 0f)
            {
                GUI.color = new Color(0.03f, 0.04f, 0.1f, Mathf.Clamp01(dim));
                GUI.DrawTexture(new Rect(0, 0, w, h), Texture2D.whiteTexture);
            }
            GUI.color = old;
        }

        static float Frac(float v) => v - Mathf.Floor(v);
    }
}
