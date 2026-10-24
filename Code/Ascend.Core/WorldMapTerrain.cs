using System;
using System.Collections.Generic;
using System.Linq;

namespace Ascend.Core
{
    /// <summary>
    /// The world map's land field, a faithful port of the atlas (Tools/atlas/aetheria_atlas.html): every land is a soft
    /// blob around its anchor, the blobs add up, warped by noise; where the sum clears <see cref="SeaLevel"/> there is
    /// land, and the nearest anchor owns it. Same seed, same numbers, so the atlas, the game and the tests agree on the
    /// coastline. Map units: 150 wide, 100 tall, x east, y south.
    /// </summary>
    public sealed class WorldMapTerrain
    {
        public const double Width = 150, Height = 100, SeaLevel = 0.46;
        public const int CanonSeed = 1207;
        public static readonly string[] TerrainKinds = { "plains", "forest", "swamp", "steppe", "mountain", "volcanic", "tundra", "desert", "jungle", "spirit", "demon" };

        readonly float[] _perm = new float[4096];
        readonly double[] _ax, _ay, _r, _sharp;
        readonly int[][] _terrain;

        /// <summary>The surface lands that shape the map, in data order (index = what <see cref="Sample"/> returns).</summary>
        public IReadOnlyList<RegionData> Lands { get; }
        public int Seed { get; }

        public WorldMapTerrain(IEnumerable<RegionData> regions, int seed = CanonSeed)
        {
            Seed = seed;
            Lands = regions.Where(r => r.Layer == "surface" && r.Map != null && r.Map.Radius > 0).ToList();
            _ax = Lands.Select(r => r.Map.X).ToArray();
            _ay = Lands.Select(r => r.Map.Y).ToArray();
            _r = Lands.Select(r => r.Map.Radius).ToArray();
            _sharp = Lands.Select(r => r.Map.Isle ? 1.8 : 0.7).ToArray();
            _terrain = Lands.Select(r =>
            {
                var t = (r.Map.Terrain ?? new List<string>()).Select(k => Array.IndexOf(TerrainKinds, k)).Where(i => i >= 0).ToArray();
                return t.Length > 0 ? t : new[] { 0 };
            }).ToArray();
            var rnd = new Mulberry32(seed);
            for (int i = 0; i < _perm.Length; i++) _perm[i] = (float)rnd.Next();
        }

        public int IndexOf(string regionId)
        {
            for (int i = 0; i < Lands.Count; i++) if (Lands[i].Id == regionId) return i;
            return -1;
        }

        double Hash(int ix, int iy) => _perm[unchecked((int)((long)ix * 73856093L) ^ (int)((long)iy * 19349663L)) & 4095];

        /// <summary>Smooth value noise in [0, 1].</summary>
        public double ValueNoise(double x, double y)
        {
            double fx0 = Math.Floor(x), fy0 = Math.Floor(y);
            int ix = (int)fx0, iy = (int)fy0;
            double fx = x - fx0, fy = y - fy0, u = fx * fx * (3 - 2 * fx), v = fy * fy * (3 - 2 * fy);
            double a = Hash(ix, iy), b = Hash(ix + 1, iy), c = Hash(ix, iy + 1), d = Hash(ix + 1, iy + 1);
            return a + (b - a) * u + (c - a) * v + (a - b - c + d) * u * v;
        }

        /// <summary>Fractal noise in [0, 1] (octaves halve in strength and roughly double in frequency).</summary>
        public double Fbm(double x, double y, int octaves = 4)
        {
            double s = 0, a = 0.5, f = 1, n = 0;
            for (int i = 0; i < octaves; i++) { s += a * ValueNoise(x * f, y * f); n += a; a *= 0.5; f *= 2.03; }
            return s / n;
        }

        /// <summary>The land field at a map point and the land that owns it (nearest anchor, scaled by its radius).</summary>
        public (double field, int land) Sample(double ux, double uy)
        {
            double wx = ux + 16 * (Fbm(ux * .04, uy * .04) - .5), wy = uy + 16 * (Fbm(ux * .04 + 31, uy * .04 + 17) - .5);
            int best = -1; double bd = 1e9, field = 0;
            for (int i = 0; i < _ax.Length; i++)
            {
                double dx = wx - _ax[i], dy = wy - _ay[i], d = Math.Sqrt(dx * dx + dy * dy) / _r[i];
                field += Math.Exp(-d * d * _sharp[i]);
                if (d < bd) { bd = d; best = i; }
            }
            double edge = Math.Min(Math.Min(ux, Width - ux), Math.Min(uy * 1.4, (Height - uy) * 1.4)) / 9;
            field = field * Math.Min(1, Math.Max(0, edge)) + .28 * (Fbm(ux * .11 + 5, uy * .11 + 9) - .5);
            return (field, best);
        }

        /// <summary>The land at a map point, or null over the sea.</summary>
        public RegionData RegionAt(double ux, double uy)
        {
            var (f, i) = Sample(ux, uy);
            return f > SeaLevel && i >= 0 ? Lands[i] : null;
        }

        /// <summary>Which of its terrains a land paints at this point (index into <see cref="TerrainKinds"/>).</summary>
        public int TerrainAt(int land, double ux, double uy)
        {
            var t = _terrain[land];
            return t[Math.Min(t.Length - 1, (int)Math.Floor(Fbm(ux * .07 + 90, uy * .07 + 40, 3) * t.Length * 1.15))];
        }

        /// <summary>Land index for every cell of a w x h grid over the map (-1 = sea), row-major from the north-west.</summary>
        public short[] LandGrid(int w, int h)
        {
            var g = new short[w * h];
            for (int y = 0; y < h; y++)
                for (int x = 0; x < w; x++)
                {
                    var (f, i) = Sample((x + 0.5) * Width / w, (y + 0.5) * Height / h);
                    g[y * w + x] = (short)(f > SeaLevel ? i : -1);
                }
            return g;
        }
    }

    /// <summary>The atlas's seeded random (mulberry32), bit-for-bit.</summary>
    public sealed class Mulberry32
    {
        int _a;
        public Mulberry32(int seed) { _a = seed; }
        public double Next()
        {
            unchecked
            {
                _a += 0x6D2B79F5;
                int t = _a ^ (int)((uint)_a >> 15);
                t *= 1 | _a;
                t = (t + (t ^ (int)((uint)t >> 7)) * (61 | t)) ^ t;
                return (uint)(t ^ (int)((uint)t >> 14)) / 4294967296.0;
            }
        }
    }
}
