using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ascend.Core
{
    /// <summary>The rendered world map: three RGBA images (row 0 = north) plus which land owns each pixel.</summary>
    public sealed class WorldMapImage
    {
        public int Width { get; internal set; }
        public int Height { get; internal set; }
        /// <summary>The full-colour painted map (the System overlay and the review atlas).</summary>
        public byte[] Painted { get; internal set; }
        /// <summary>The same map inked on parchment (the in-game map, 12_Systems/hud_and_ui.md §8).</summary>
        public byte[] Parchment { get; internal set; }
        /// <summary>The blank sheet the parchment map is inked onto (what unexplored land looks like).</summary>
        public byte[] Paper { get; internal set; }
        /// <summary>Land index per pixel (<see cref="WorldMapTerrain.Lands"/>), -1 for the sea.</summary>
        public short[] Land { get; internal set; }
        public double PixelsPerUnit => Width / WorldMapTerrain.Width;
    }

    /// <summary>
    /// Paints the world map from <see cref="WorldMapTerrain"/>: relief from a height field (ridged noise where the land
    /// is mountainous) with hillshading, soft blends between terrains, a sandy rim and inked coastline, ripple lines
    /// echoing the coast out to sea, rivers running downhill, roads between neighbouring lands, dotted borders, and drawn
    /// symbols (peaks, trees, dunes, reeds, snow hummocks, demon spikes). Deterministic for a seed; pure CPU so the game
    /// can paint it on a worker thread and the tests can check it.
    /// </summary>
    public static class WorldMapPainter
    {
        // Painted palette per terrain kind (WorldMapTerrain.TerrainKinds order).
        static readonly Rgb[] Base =
        {
            new Rgb(170, 186, 104), new Rgb(74, 124, 64), new Rgb(128, 138, 100), new Rgb(198, 184, 122), new Rgb(146, 136, 120), new Rgb(106, 76, 66),
            new Rgb(226, 232, 234), new Rgb(228, 198, 138), new Rgb(48, 108, 60), new Rgb(118, 132, 176), new Rgb(112, 44, 56),
        };
        static readonly double[] Rough = { .06, .16, 0, .08, 1, .95, .5, .12, .2, .3, .75 };
        const int Plains = 0, Forest = 1, Swamp = 2, Steppe = 3, Mountain = 4, Volcanic = 5, Tundra = 6, Desert = 7, Jungle = 8, Spirit = 9, Demon = 10;

        static readonly Rgb Ink = new Rgb(58, 42, 30), PaperBase = new Rgb(236, 222, 186), Burn = new Rgb(166, 124, 72);

        public static WorldMapImage Paint(WorldMapTerrain t, int width)
        {
            int W = Math.Max(150, width), H = (int)Math.Round(W * WorldMapTerrain.Height / WorldMapTerrain.Width);
            double s = W / WorldMapTerrain.Width;
            int n = W * H;
            var field = new float[n];
            var land = new short[n];
            var terr = new byte[n];

            Parallel.For(0, H, y =>
            {
                for (int x = 0; x < W; x++)
                {
                    double ux = (x + .5) / s, uy = (y + .5) / s;
                    var (f, i) = t.Sample(ux, uy);
                    int k = y * W + x;
                    field[k] = (float)f;
                    bool isLand = f > WorldMapTerrain.SeaLevel && i >= 0;
                    land[k] = (short)(isLand ? i : -1);
                    terr[k] = (byte)(isLand ? t.TerrainAt(i, ux, uy) : 255);
                }
            });

            // Signed distance to the coast in pixels (+ on land): chamfer far away, the field's gradient up close.
            var toSea = Chamfer(W, H, k => land[k] < 0);
            var toLand = Chamfer(W, H, k => land[k] >= 0);
            var coast = new float[n];
            Parallel.For(0, H, y =>
            {
                for (int x = 0; x < W; x++)
                {
                    int k = y * W + x;
                    float d = land[k] >= 0 ? toSea[k] : -toLand[k];
                    if (Math.Abs(d) < 3 && x > 0 && y > 0 && x < W - 1 && y < H - 1)
                    {
                        double gx = (field[k + 1] - field[k - 1]) * .5, gy = (field[k + W] - field[k - W]) * .5, g = Math.Sqrt(gx * gx + gy * gy);
                        if (g > 1e-6) d = (float)((field[k] - WorldMapTerrain.SeaLevel) / g);
                    }
                    coast[k] = d;
                }
            });

            // Height: a gentle rise from the shore, small hills everywhere, ridges where the land is rough.
            var rough = new float[n];
            for (int k = 0; k < n; k++) rough[k] = terr[k] == 255 ? 0f : (float)Rough[terr[k]];
            BoxBlur(rough, W, H, Math.Max(1, (int)(1.3 * s)), 2);
            var height = new float[n];
            Parallel.For(0, H, y =>
            {
                for (int x = 0; x < W; x++)
                {
                    int k = y * W + x;
                    if (land[k] < 0) continue;
                    double ux = (x + .5) / s, uy = (y + .5) / s;
                    double shore = Smooth(0, 6 * s, coast[k]);
                    double ridge = 1 - Math.Abs(2 * t.Fbm(ux * .16 + 3, uy * .16 + 5, 5) - 1);
                    height[k] = (float)(.28 * shore + .10 * t.Fbm(ux * .35 + 11, uy * .35 + 7, 5) + rough[k] * (.12 + .95 * ridge * ridge) * Smooth(0, 2.5 * s, coast[k]));
                }
            });
            var shade = new float[n];
            double zs = s * 6.5, lx = -1, ly = -1, lz = 1.4, ll = Math.Sqrt(lx * lx + ly * ly + lz * lz);
            lx /= ll; ly /= ll; lz /= ll;
            Parallel.For(1, H - 1, y =>
            {
                for (int x = 1; x < W - 1; x++)
                {
                    int k = y * W + x;
                    if (land[k] < 0) { shade[k] = 1; continue; }
                    double dx = (height[k + 1] - height[k - 1]) * .5 * zs, dy = (height[k + W] - height[k - W]) * .5 * zs;
                    double nl = Math.Sqrt(dx * dx + dy * dy + 1);
                    shade[k] = (float)((-dx * lx - dy * ly + lz) / nl / lz);
                }
            });

            // Terrain colour, blended softly across terrain and land edges (sea pixels don't bleed in).
            var cr = new float[n]; var cg = new float[n]; var cb = new float[n]; var cm = new float[n];
            for (int k = 0; k < n; k++)
                if (terr[k] != 255) { var c = Base[terr[k]]; cr[k] = (float)c.R; cg[k] = (float)c.G; cb[k] = (float)c.B; cm[k] = 1; }
            int br = Math.Max(1, (int)(.45 * s));
            BoxBlur(cr, W, H, br, 2); BoxBlur(cg, W, H, br, 2); BoxBlur(cb, W, H, br, 2); BoxBlur(cm, W, H, br, 2);

            var border = new float[n];
            for (int y = 1; y < H - 1; y++)
                for (int x = 1; x < W - 1; x++)
                {
                    int k = y * W + x, a = land[k];
                    if (a < 0) continue;
                    int b1 = land[k + 1], b2 = land[k + W];
                    if ((b1 >= 0 && b1 != a) || (b2 >= 0 && b2 != a)) border[k] = 1;
                }
            BoxBlur(border, W, H, 1, 1);

            var painted = new Canvas(W, H);
            var inked = new Canvas(W, H);
            var paper = new Canvas(W, H);
            Parallel.For(0, H, y =>
            {
                for (int x = 0; x < W; x++)
                {
                    int k = y * W + x;
                    double ux = (x + .5) / s, uy = (y + .5) / s;
                    // The sheet: fibres, a few stains, scorched edges.
                    double grain = t.Fbm(ux * .9 + 300, uy * .9 + 300, 4);
                    var pc = PaperBase.Scale(1 + (grain - .5) * .10);
                    pc = Rgb.Lerp(pc, new Rgb(206, 180, 130), Smooth(.56, .8, t.Fbm(ux * .045 + 50, uy * .045 + 80, 3)) * .35);
                    pc = pc.Add((t.ValueNoise(ux * 12, uy * 2.4) - .5) * 9);
                    double e = Math.Min(Math.Min(x, W - 1 - x), Math.Min(y, H - 1 - y)) / (.06 * W);
                    pc = Rgb.Lerp(pc, Burn, (1 - Smooth(0, 1, e)) * .55);
                    paper.Set(k, pc);

                    Rgb pt, ik;
                    double cd = coast[k];
                    if (land[k] < 0)
                    {
                        double d = -cd, deep = Math.Pow(Smooth(0, 8 * s, d), .7);
                        pt = Rgb.Lerp(new Rgb(64, 146, 158), new Rgb(12, 38, 64), deep).Add((t.Fbm(ux * .5 + 3, uy * 1.6, 3) - .5) * 12);
                        ik = new Rgb(pc.R * .92, pc.G * .94, pc.B * .95);
                        double[] echo = { .55, 1.25, 2.2 }, ea = { .45, .3, .18 }, ia = { .5, .32, .18 };
                        for (int j = 0; j < 3; j++)
                        {
                            double a = Math.Max(0, 1 - Math.Abs(d - echo[j] * s) / (.06 * s + .6));
                            pt = Rgb.Lerp(pt, new Rgb(190, 226, 224), a * ea[j]);
                            ik = Rgb.Lerp(ik, Ink, a * ia[j]);
                        }
                    }
                    else
                    {
                        int tk = terr[k];
                        var c = cm[k] > 1e-3 ? new Rgb(cr[k] / cm[k], cg[k] / cm[k], cb[k] / cm[k]) : Base[tk];
                        c = c.Scale(1 + (t.Fbm(ux * .12 + 40, uy * .12 + 70, 3) - .5) * .2);
                        double h = height[k];
                        c = Rgb.Lerp(c, new Rgb(150, 142, 132), Smooth(.55, .9, h) * .7);
                        c = Rgb.Lerp(c, new Rgb(240, 244, 246), Smooth(tk == Tundra ? .62 : 1.3, 1.5, h));
                        double sand = tk == Tundra || tk == Swamp ? 0 : 1 - Smooth(.3 * s, 1.1 * s, cd);
                        c = Rgb.Lerp(c, new Rgb(218, 204, 158), sand * .6);
                        double sh = Math.Max(0, Math.Min(1.6, shade[k]));
                        pt = c.Scale(.5 + .52 * sh).Add((t.Fbm(ux * .6, uy * .6, 3) - .5) * 22);
                        pt = pt.Scale(1 - border[k] * .28 * (.5 + .5 * Math.Cos((x + y) * Math.PI / (.35 * s))));

                        ik = Rgb.Lerp(pc.Scale(1.015), c, .14);
                        ik = Rgb.Lerp(ik, new Rgb(92, 66, 44), Math.Max(0, Math.Min(.6, (1 - sh) * .9)) * .55);
                        ik = Rgb.Lerp(ik, new Rgb(250, 242, 220), Math.Max(0, Math.Min(.3, sh - 1)) * .5);
                        double dot = ((int)((x + y) / Math.Max(2, .28 * s)) & 1) == 0 ? 1 : 0;
                        ik = Rgb.Lerp(ik, Ink, border[k] * .55 * dot);
                    }
                    double line = Math.Max(0, Math.Min(1, Math.Max(.9, .09 * s) + .5 - Math.Abs(cd)));
                    pt = Rgb.Lerp(pt, new Rgb(30, 34, 32), line * .9);
                    ik = Rgb.Lerp(ik, new Rgb(52, 38, 28), line * .95);
                    pt = pt.Scale(.94 + .06 * grain * 2 - .06);
                    painted.Set(k, pt);
                    inked.Set(k, ik);
                }
            });

            Decorate(t, painted, inked, field, land, terr, coast, height, rough, s);

            return new WorldMapImage { Width = W, Height = H, Painted = painted.ToRgba(), Parchment = inked.ToRgba(), Paper = paper.ToRgba(), Land = land };
        }

        // ------------------------------------------------------------------ rivers, roads, symbols

        static void Decorate(WorldMapTerrain t, Canvas painted, Canvas inked, float[] field, short[] land, byte[] terr, float[] coast, float[] height, float[] rough, double s)
        {
            int W = painted.W, H = painted.H;
            double FieldAt(double ux, double uy)
            {
                double fx = Math.Max(0, Math.Min(W - 1.001, ux * s - .5)), fy = Math.Max(0, Math.Min(H - 1.001, uy * s - .5));
                int x0 = (int)fx, y0 = (int)fy; double ax = fx - x0, ay = fy - y0; int k = y0 * W + x0;
                return field[k] * (1 - ax) * (1 - ay) + field[k + 1] * ax * (1 - ay) + field[k + W] * (1 - ax) * ay + field[k + W + 1] * ax * ay;
            }
            int Px(double ux, double uy)
            {
                int x = (int)(ux * s), y = (int)(uy * s);
                return x < 0 || y < 0 || x >= W || y >= H ? -1 : y * W + x;
            }
            bool OnLand(double ux, double uy) { int k = Px(ux, uy); return k >= 0 && land[k] >= 0; }

            var rnd = new Mulberry32(t.Seed * 7 + 1);
            // Rivers: from high ground in mountain, forest, jungle, tundra and swamp lands, walking downhill to the sea.
            for (int li = 0; li < t.Lands.Count; li++)
            {
                var r = t.Lands[li];
                var kinds = r.Map.Terrain;
                if (!(kinds.Contains("mountain") || kinds.Contains("forest") || kinds.Contains("jungle") || kinds.Contains("tundra") || kinds.Contains("swamp"))) continue;
                int count = kinds.Contains("mountain") ? 2 : 1;
                for (int q = 0; q < count; q++)
                {
                    double x = r.Map.X + (rnd.Next() - .5) * r.Map.Radius * .8, y = r.Map.Y + (rnd.Next() - .5) * r.Map.Radius * .8;
                    if (!OnLand(x, y)) continue;
                    var pts = new List<(double x, double y)> { (x, y) };
                    double ang = rnd.Next() * 6.28;
                    for (int step = 0; step < 260; step++)
                    {
                        const double e = .8;
                        double f0 = FieldAt(x, y), gx = FieldAt(x + e, y) - FieldAt(x - e, y), gy = FieldAt(x, y + e) - FieldAt(x, y - e);
                        double gl = Math.Sqrt(gx * gx + gy * gy); if (gl == 0) gl = 1;
                        ang = Math.Atan2(-gy / gl, -gx / gl) + (t.ValueNoise(x * .3 + q * 9, y * .3) - .5) * 1.6;
                        x += Math.Cos(ang) * .55; y += Math.Sin(ang) * .55; pts.Add((x, y));
                        if (f0 < WorldMapTerrain.SeaLevel - .02) break;
                    }
                    if (pts.Count < 12) continue;
                    for (int i = 1; i < pts.Count; i++)
                    {
                        double w = (.25 + .9 * i / pts.Count) * s * .22;
                        double x0 = pts[i - 1].x * s, y0 = pts[i - 1].y * s, x1 = pts[i].x * s, y1 = pts[i].y * s;
                        painted.Line(x0, y0, x1, y1, w + s * .12, new Rgb(30, 70, 90), .55);
                        inked.Line(x0, y0, x1, y1, w * .8 + 1, new Rgb(64, 92, 118), .8);
                    }
                    for (int i = 1; i < pts.Count; i++)
                    {
                        double w = (.25 + .9 * i / pts.Count) * s * .22;
                        painted.Line(pts[i - 1].x * s, pts[i - 1].y * s, pts[i].x * s, pts[i].y * s, w, new Rgb(111, 180, 207), 1);
                        inked.Line(pts[i - 1].x * s, pts[i - 1].y * s, pts[i].x * s, pts[i].y * s, Math.Max(.6, w * .45), new Rgb(196, 214, 222), .9);
                    }
                }
            }

            // Roads: each mainland land joined to its two nearest neighbours over land.
            var edges = new HashSet<string>();
            for (int a = 0; a < t.Lands.Count; a++)
            {
                var ra = t.Lands[a];
                if (ra.Map.Isle) continue;
                var near = new List<(double d, RegionData b)>();
                foreach (var rb in t.Lands) if (rb != ra && !rb.Map.Isle) near.Add((Math.Sqrt(Sq(ra.Map.X - rb.Map.X) + Sq(ra.Map.Y - rb.Map.Y)), rb));
                near.Sort((p, q) => p.d.CompareTo(q.d));
                for (int j = 0; j < Math.Min(2, near.Count); j++)
                {
                    var (d, rb) = near[j];
                    string key = string.CompareOrdinal(ra.Id, rb.Id) < 0 ? ra.Id + "|" + rb.Id : rb.Id + "|" + ra.Id;
                    if (edges.Contains(key) || d > 26) continue;
                    edges.Add(key);
                    double mx = (ra.Map.X + rb.Map.X) / 2 + (rnd.Next() - .5) * 4, my = (ra.Map.Y + rb.Map.Y) / 2 + (rnd.Next() - .5) * 4;
                    if (!OnLand(mx, my)) continue;
                    DashedCurve(painted, inked, ra.Map.X, ra.Map.Y, mx, my, rb.Map.X, rb.Map.Y, s);
                }
            }

            // Symbols on jittered grids, drawn back to front: peaks on a coarse grid where the land is high, the rest finer.
            var glyphs = new List<Glyph>();
            var g = new Mulberry32(t.Seed * 13 + 5);
            const double peakCell = 2.2;
            for (double gy = 0; gy < WorldMapTerrain.Height; gy += peakCell * .8)
                for (double gx = 0; gx < WorldMapTerrain.Width; gx += peakCell)
                {
                    double px = gx + (.1 + .8 * g.Next()) * peakCell + (((int)(gy / (peakCell * .8))) % 2) * peakCell * .5, py = gy + g.Next() * peakCell * .6, roll = g.Next(), size = .85 + .3 * g.Next();
                    int k = Px(px, py);
                    if (k < 0 || land[k] < 0 || coast[k] < 1.0 * s) continue;
                    int tk = terr[k];
                    double h = height[k], rg = rough[k];
                    bool rocky = tk == Mountain || tk == Volcanic || (tk == Tundra && rg > .45);
                    if (!rocky || h < .38 || roll > .35 + h * .6) continue;
                    glyphs.Add(new Glyph(GlyphKind.Peak, px, py, (.95 + 1.1 * Math.Max(0, h - .38)) * size, tk, h, roll));
                }
            const double cell = 1.45;
            for (double gy = 0; gy < WorldMapTerrain.Height; gy += cell)
                for (double gx = 0; gx < WorldMapTerrain.Width; gx += cell)
                {
                    double px = gx + (.15 + .7 * g.Next()) * cell, py = gy + (.15 + .7 * g.Next()) * cell, roll = g.Next(), size = .9 + .3 * g.Next();
                    int k = Px(px, py);
                    if (k < 0 || land[k] < 0 || coast[k] < .7 * s) continue;
                    int tk = terr[k];
                    double h = height[k], rg = rough[k];
                    if ((tk == Mountain || tk == Volcanic) && rg > .4) { if (roll < .12 && h < .5) glyphs.Add(new Glyph(GlyphKind.Hummock, px, py, .55 * size, tk, h, roll)); }
                    else if (tk == Demon) { if (roll < .7) glyphs.Add(new Glyph(GlyphKind.Spike, px, py, .8 * size, tk, h, roll)); }
                    else if (tk == Tundra) { if (rg <= .45 && roll < .3) glyphs.Add(new Glyph(GlyphKind.Hummock, px, py, .7 * size, tk, h, roll)); }
                    else if (tk == Forest || tk == Jungle || tk == Spirit) { if (roll < (tk == Spirit ? .4 : tk == Jungle ? .7 : .55)) glyphs.Add(new Glyph(GlyphKind.Trees, px, py, (tk == Jungle ? .55 : .45) * size, tk, h, roll)); }
                    else if (tk == Desert) { if (roll < .45) glyphs.Add(new Glyph(GlyphKind.Dune, px, py, .75 * size, tk, h, roll)); }
                    else if (tk == Swamp) { if (roll < .55) glyphs.Add(new Glyph(GlyphKind.Reeds, px, py, .55 * size, tk, h, roll)); }
                    else if (roll < .22) glyphs.Add(new Glyph(GlyphKind.Grass, px, py, .4 * size, tk, h, roll));
                }
            // Open-sea wave marks for the parchment.
            for (double gy = 0; gy < WorldMapTerrain.Height; gy += 3.2)
                for (double gx = 0; gx < WorldMapTerrain.Width; gx += 4.1)
                {
                    double px = gx + g.Next() * 3, py = gy + g.Next() * 2;
                    int k = Px(px, py);
                    if (k >= 0 && land[k] < 0 && coast[k] < -3.2 * s) glyphs.Add(new Glyph(GlyphKind.Wave, px, py, .7, 255, 0, g.Next()));
                }
            glyphs.Sort((a, b) => a.Y.CompareTo(b.Y));
            foreach (var gl in glyphs) DrawGlyph(painted, inked, gl, s);
        }

        enum GlyphKind { Peak, Spike, Hummock, Trees, Dune, Reeds, Grass, Wave }

        readonly struct Glyph
        {
            public readonly GlyphKind Kind; public readonly double X, Y, Size, H, Roll; public readonly int Terrain;
            public Glyph(GlyphKind k, double x, double y, double size, int terrain, double h, double roll) { Kind = k; X = x; Y = y; Size = size; Terrain = terrain; H = h; Roll = roll; }
        }

        static void DrawGlyph(Canvas p, Canvas i, Glyph g, double s)
        {
            double x = g.X * s, y = g.Y * s, z = g.Size * s, lw = Math.Max(.8, .07 * s);
            var ink = Ink;
            switch (g.Kind)
            {
                case GlyphKind.Peak:
                {
                    double bw = z * 1.3, ht = z;
                    var A = (x + (g.Roll - .5) * .25 * z, y - ht); var L = (x - bw / 2, y); var R = (x + bw / 2, y); var M = (x + (A.Item1 - x) * .3 + z * .05, y);
                    bool volcanic = g.Terrain == Volcanic, snowy = g.Terrain == Tundra || g.H > 1.25;
                    p.Triangle(L, A, M, volcanic ? new Rgb(132, 98, 86) : new Rgb(182, 172, 154), 1);
                    p.Triangle(A, R, M, volcanic ? new Rgb(72, 50, 44) : new Rgb(102, 92, 82), 1);
                    if (snowy)
                    {
                        var aL = Mix(A, L, .34); var aM = Mix(A, M, .34); var aR = Mix(A, R, .34);
                        p.Triangle(aL, A, aM, new Rgb(246, 248, 250), 1);
                        p.Triangle(A, aR, aM, new Rgb(196, 206, 220), 1);
                    }
                    if (volcanic && g.Roll < .25) p.Disc(A.Item1, A.Item2 - .1 * z, .14 * z, new Rgb(230, 96, 40), .9);
                    p.Line(L.Item1, L.Item2, A.Item1, A.Item2, lw, new Rgb(40, 34, 30), .85);
                    p.Line(A.Item1, A.Item2, R.Item1, R.Item2, lw, new Rgb(40, 34, 30), .85);

                    i.Triangle(L, A, M, new Rgb(246, 236, 206), .7);
                    for (int h = 1; h <= 4; h++)
                    {
                        var top = Mix(A, R, h / 5.0); var bot = Mix(M, R, h / 5.0);
                        i.Line(top.Item1, top.Item2, bot.Item1, bot.Item2, lw * .7, ink, .45);
                    }
                    i.Line(L.Item1, L.Item2, A.Item1, A.Item2, lw, ink, .9);
                    i.Line(A.Item1, A.Item2, R.Item1, R.Item2, lw, ink, .9);
                    break;
                }
                case GlyphKind.Spike:
                {
                    var A = (x, y - z); var L = (x - z * .22, y); var R = (x + z * .22, y);
                    p.Triangle(L, A, R, new Rgb(84, 26, 34), 1);
                    p.Line(A.Item1, A.Item2, R.Item1, R.Item2, lw * .8, new Rgb(30, 12, 16), .8);
                    i.Triangle(L, A, R, new Rgb(120, 60, 50), .55);
                    i.Line(L.Item1, L.Item2, A.Item1, A.Item2, lw * .8, ink, .9);
                    i.Line(A.Item1, A.Item2, R.Item1, R.Item2, lw * .8, ink, .9);
                    break;
                }
                case GlyphKind.Hummock:
                    Arc(p, x, y, z, .3, lw, new Rgb(250, 252, 252), .9);
                    Arc(p, x + .5, y + .5, z, .3, lw * .7, new Rgb(150, 162, 176), .6);
                    Arc(i, x, y, z, .3, lw * .8, ink, .6);
                    break;
                case GlyphKind.Trees:
                {
                    var leaf = g.Terrain == Jungle ? new Rgb(38, 92, 46) : g.Terrain == Spirit ? new Rgb(104, 122, 170) : new Rgb(58, 106, 50);
                    int count = g.Roll < .4 ? 3 : 2;
                    for (int c = 0; c < count; c++)
                    {
                        double cx = x + (c - (count - 1) / 2.0) * z * 1.1, cy = y - (c == 1 ? z * .45 : 0), r = z * (c == 1 ? 1 : .85);
                        p.Disc(cx + r * .25, cy + r * .2, r, new Rgb(20, 40, 20), .35);
                        p.Disc(cx, cy, r, leaf, 1);
                        p.Disc(cx - r * .3, cy - r * .3, r * .5, leaf.Scale(1.35), .55);
                        p.Ring(cx, cy, r, lw * .7, new Rgb(24, 40, 22), .55);
                        i.Disc(cx, cy, r, new Rgb(238, 228, 198), .6);
                        i.Line(cx, cy + r, cx, cy + r * 1.5, lw * .7, ink, .7);
                        i.Ring(cx, cy, r, lw * .75, ink, .85);
                    }
                    break;
                }
                case GlyphKind.Dune:
                    Arc(p, x, y, z, .35, lw * 1.1, new Rgb(170, 138, 86), .75);
                    Arc(p, x - .6, y - .8, z * .9, .35, lw * .7, new Rgb(246, 222, 170), .6);
                    Arc(i, x, y, z, .35, lw * .8, ink, .55);
                    break;
                case GlyphKind.Reeds:
                    for (int c = -1; c <= 1; c++)
                    {
                        double bx = x + c * z * .35, tip = z * (.7 + .3 * Frac(g.Roll * 7 + c + 2));
                        p.Line(bx, y, bx + c * z * .18, y - tip, lw * .7, new Rgb(52, 74, 44), .9);
                        i.Line(bx, y, bx + c * z * .18, y - tip, lw * .7, ink, .75);
                    }
                    p.Line(x - z * .7, y + z * .2, x + z * .7, y + z * .2, lw * .7, new Rgb(84, 130, 150), .6);
                    i.Line(x - z * .7, y + z * .2, x + z * .7, y + z * .2, lw * .6, new Rgb(64, 92, 118), .55);
                    break;
                case GlyphKind.Grass:
                    p.Line(x, y, x - z * .25, y - z, lw * .6, new Rgb(90, 110, 50), .5);
                    p.Line(x + z * .3, y, x + z * .45, y - z * .8, lw * .6, new Rgb(90, 110, 50), .5);
                    i.Line(x, y, x - z * .25, y - z, lw * .55, ink, .4);
                    i.Line(x + z * .3, y, x + z * .45, y - z * .8, lw * .55, ink, .4);
                    break;
                case GlyphKind.Wave:
                    Arc(i, x - z * .35, y, z * .35, -.35, lw * .6, ink, .3);
                    Arc(i, x + z * .35, y, z * .35, -.35, lw * .6, ink, .3);
                    break;
            }
        }

        static (double, double) Mix((double, double) a, (double, double) b, double f) => (a.Item1 + (b.Item1 - a.Item1) * f, a.Item2 + (b.Item2 - a.Item2) * f);

        /// <summary>A shallow arc: rises by <paramref name="bulge"/> × half-width in the middle (negative = dips).</summary>
        static void Arc(Canvas c, double x, double y, double half, double bulge, double width, Rgb col, double a)
        {
            const int steps = 8;
            double px = x - half, py = y;
            for (int j = 1; j <= steps; j++)
            {
                double tt = -1 + 2.0 * j / steps, nx = x + tt * half, ny = y - (1 - tt * tt) * half * bulge;
                c.Line(px, py, nx, ny, width, col, a);
                px = nx; py = ny;
            }
        }

        static void DashedCurve(Canvas painted, Canvas inked, double ax, double ay, double mx, double my, double bx, double by, double s)
        {
            double len = 0, prevX = ax, prevY = ay;
            const int steps = 80;
            for (int j = 1; j <= steps; j++)
            {
                double tt = j / (double)steps, u = 1 - tt;
                double x = u * u * ax + 2 * u * tt * mx + tt * tt * bx, y = u * u * ay + 2 * u * tt * my + tt * tt * by;
                double seg = Math.Sqrt(Sq(x - prevX) + Sq(y - prevY));
                if (len % .95 < .55)
                {
                    painted.Line(prevX * s, prevY * s, x * s, y * s, .16 * s, new Rgb(92, 62, 34), .75);
                    inked.Line(prevX * s, prevY * s, x * s, y * s, Math.Max(.8, .11 * s), new Rgb(110, 80, 50), .8);
                }
                len += seg; prevX = x; prevY = y;
            }
        }

        // ------------------------------------------------------------------ helpers

        static double Sq(double v) => v * v;
        static double Frac(double v) => v - Math.Floor(v);
        static double Smooth(double a, double b, double v) { double x = Math.Max(0, Math.Min(1, (v - a) / (b - a))); return x * x * (3 - 2 * x); }

        /// <summary>Two-pass chamfer distance (pixels) from every pixel to the nearest pixel where <paramref name="target"/> holds.</summary>
        static float[] Chamfer(int W, int H, Func<int, bool> target)
        {
            const float big = 1e6f, a = 1f, b = 1.4142f;
            var d = new float[W * H];
            for (int k = 0; k < d.Length; k++) d[k] = target(k) ? 0 : big;
            for (int y = 0; y < H; y++)
                for (int x = 0; x < W; x++)
                {
                    int k = y * W + x; float v = d[k];
                    if (x > 0) v = Math.Min(v, d[k - 1] + a);
                    if (y > 0) { v = Math.Min(v, d[k - W] + a); if (x > 0) v = Math.Min(v, d[k - W - 1] + b); if (x < W - 1) v = Math.Min(v, d[k - W + 1] + b); }
                    d[k] = v;
                }
            for (int y = H - 1; y >= 0; y--)
                for (int x = W - 1; x >= 0; x--)
                {
                    int k = y * W + x; float v = d[k];
                    if (x < W - 1) v = Math.Min(v, d[k + 1] + a);
                    if (y < H - 1) { v = Math.Min(v, d[k + W] + a); if (x < W - 1) v = Math.Min(v, d[k + W + 1] + b); if (x > 0) v = Math.Min(v, d[k + W - 1] + b); }
                    d[k] = v;
                }
            return d;
        }

        /// <summary>Separable box blur, repeated (2 passes ≈ a soft tent).</summary>
        static void BoxBlur(float[] v, int W, int H, int r, int passes)
        {
            var tmp = new float[v.Length];
            for (int p = 0; p < passes; p++)
            {
                Parallel.For(0, H, y =>
                {
                    double sum = 0; int row = y * W, cnt = 0;
                    for (int x = -r; x <= r; x++) if (x >= 0 && x < W) { sum += v[row + x]; cnt++; }
                    for (int x = 0; x < W; x++)
                    {
                        tmp[row + x] = (float)(sum / cnt);
                        int o = x - r, i = x + r + 1;
                        if (o >= 0) { sum -= v[row + o]; cnt--; }
                        if (i < W) { sum += v[row + i]; cnt++; }
                    }
                });
                Parallel.For(0, W, x =>
                {
                    double sum = 0; int cnt = 0;
                    for (int y = -r; y <= r; y++) if (y >= 0 && y < H) { sum += tmp[y * W + x]; cnt++; }
                    for (int y = 0; y < H; y++)
                    {
                        v[y * W + x] = (float)(sum / cnt);
                        int o = y - r, i = y + r + 1;
                        if (o >= 0) { sum -= tmp[o * W + x]; cnt--; }
                        if (i < H) { sum += tmp[i * W + x]; cnt++; }
                    }
                });
            }
        }

        internal readonly struct Rgb
        {
            public readonly double R, G, B;
            public Rgb(double r, double g, double b) { R = r; G = g; B = b; }
            public Rgb Scale(double f) => new Rgb(R * f, G * f, B * f);
            public Rgb Add(double v) => new Rgb(R + v, G + v, B + v);
            public static Rgb Lerp(Rgb a, Rgb b, double t) => new Rgb(a.R + (b.R - a.R) * t, a.G + (b.G - a.G) * t, a.B + (b.B - a.B) * t);
        }

        /// <summary>A float RGB raster with anti-aliased discs, rings, thick lines and triangles.</summary>
        sealed class Canvas
        {
            public readonly int W, H;
            readonly float[] _r, _g, _b;
            public Canvas(int w, int h) { W = w; H = h; _r = new float[w * h]; _g = new float[w * h]; _b = new float[w * h]; }
            public void Set(int k, Rgb c) { _r[k] = (float)c.R; _g[k] = (float)c.G; _b[k] = (float)c.B; }

            void Blend(int x, int y, Rgb c, double a)
            {
                if (a <= 0 || x < 0 || y < 0 || x >= W || y >= H) return;
                int k = y * W + x;
                _r[k] += (float)((c.R - _r[k]) * a); _g[k] += (float)((c.G - _g[k]) * a); _b[k] += (float)((c.B - _b[k]) * a);
            }

            public void Disc(double cx, double cy, double r, Rgb c, double a)
            {
                for (int y = (int)(cy - r - 1); y <= (int)(cy + r + 1); y++)
                    for (int x = (int)(cx - r - 1); x <= (int)(cx + r + 1); x++)
                    {
                        double d = Math.Sqrt(Sq(x + .5 - cx) + Sq(y + .5 - cy));
                        Blend(x, y, c, a * Math.Max(0, Math.Min(1, r - d + .5)));
                    }
            }

            public void Ring(double cx, double cy, double r, double width, Rgb c, double a)
            {
                double o = r + width;
                for (int y = (int)(cy - o - 1); y <= (int)(cy + o + 1); y++)
                    for (int x = (int)(cx - o - 1); x <= (int)(cx + o + 1); x++)
                    {
                        double d = Math.Abs(Math.Sqrt(Sq(x + .5 - cx) + Sq(y + .5 - cy)) - r);
                        Blend(x, y, c, a * Math.Max(0, Math.Min(1, width / 2 - d + .5)));
                    }
            }

            public void Line(double x0, double y0, double x1, double y1, double width, Rgb c, double a)
            {
                double hw = width / 2, dx = x1 - x0, dy = y1 - y0, l2 = dx * dx + dy * dy;
                int minX = (int)(Math.Min(x0, x1) - hw - 1), maxX = (int)(Math.Max(x0, x1) + hw + 1);
                int minY = (int)(Math.Min(y0, y1) - hw - 1), maxY = (int)(Math.Max(y0, y1) + hw + 1);
                for (int y = minY; y <= maxY; y++)
                    for (int x = minX; x <= maxX; x++)
                    {
                        double px = x + .5 - x0, py = y + .5 - y0, tt = l2 > 0 ? Math.Max(0, Math.Min(1, (px * dx + py * dy) / l2)) : 0;
                        double d = Math.Sqrt(Sq(px - tt * dx) + Sq(py - tt * dy));
                        Blend(x, y, c, a * Math.Max(0, Math.Min(1, hw - d + .5)));
                    }
            }

            public void Triangle((double, double) p0, (double, double) p1, (double, double) p2, Rgb c, double a)
            {
                double area = (p1.Item1 - p0.Item1) * (p2.Item2 - p0.Item2) - (p2.Item1 - p0.Item1) * (p1.Item2 - p0.Item2);
                if (Math.Abs(area) < 1e-9) return;
                if (area < 0) { var tmp = p1; p1 = p2; p2 = tmp; }
                int minX = (int)(Math.Min(p0.Item1, Math.Min(p1.Item1, p2.Item1)) - 1), maxX = (int)(Math.Max(p0.Item1, Math.Max(p1.Item1, p2.Item1)) + 1);
                int minY = (int)(Math.Min(p0.Item2, Math.Min(p1.Item2, p2.Item2)) - 1), maxY = (int)(Math.Max(p0.Item2, Math.Max(p1.Item2, p2.Item2)) + 1);
                double Edge((double, double) a0, (double, double) a1, double px, double py)
                {
                    double ex = a1.Item1 - a0.Item1, ey = a1.Item2 - a0.Item2, len = Math.Sqrt(ex * ex + ey * ey);
                    return len < 1e-9 ? 1e9 : (ex * (py - a0.Item2) - ey * (px - a0.Item1)) / len;
                }
                for (int y = minY; y <= maxY; y++)
                    for (int x = minX; x <= maxX; x++)
                    {
                        double px = x + .5, py = y + .5;
                        double d = Math.Min(Edge(p0, p1, px, py), Math.Min(Edge(p1, p2, px, py), Edge(p2, p0, px, py)));
                        Blend(x, y, c, a * Math.Max(0, Math.Min(1, d + .5)));
                    }
            }

            public byte[] ToRgba()
            {
                var o = new byte[W * H * 4];
                for (int k = 0; k < W * H; k++)
                {
                    o[k * 4] = Clamp(_r[k]); o[k * 4 + 1] = Clamp(_g[k]); o[k * 4 + 2] = Clamp(_b[k]); o[k * 4 + 3] = 255;
                }
                return o;
            }
            static byte Clamp(float v) => (byte)(v < 0 ? 0 : v > 255 ? 255 : (int)(v + .5f));
        }
    }
}
