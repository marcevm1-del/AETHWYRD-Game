using System;
using System.IO;

namespace Ascend.Game
{
    /// <summary>
    /// One baked terrain tile (Tools/world/bake_stream_tiles.py, format "ATL1") already resampled for Unity: heights as a
    /// 513 x 513 grid in Unity order ([z, x], z = 0 at the south edge) and the vegetation/rock/sand/snow splat as a
    /// 256 x 256 x 4 alphamap. Built on a worker thread, so it touches no Unity API.
    /// </summary>
    public sealed class StreamTile
    {
        public const int HeightRes = 513;
        public const int AlphaRes = 256;

        public string Name;
        public float MinM, MaxM, X0Km, Y0Km, SizeKm;
        public int SourceSamples;
        public float[,] Heights;      // normalised 0..1 over MinM..MaxM
        public float[,,] Alpha;       // [y, x, layer], normalised to sum 1

        public static StreamTile Load(string path)
        {
            var b = File.ReadAllBytes(path);
            if (b.Length < 32 || b[0] != (byte)'A' || b[1] != (byte)'T' || b[2] != (byte)'L' || b[3] != (byte)'1') throw new InvalidDataException("not an ATL1 tile: " + path);
            int n = BitConverter.ToInt32(b, 4), sr = BitConverter.ToInt32(b, 8);
            var t = new StreamTile
            {
                Name = Path.GetFileNameWithoutExtension(path), SourceSamples = n,
                MinM = BitConverter.ToSingle(b, 12), MaxM = BitConverter.ToSingle(b, 16),
                X0Km = BitConverter.ToSingle(b, 20), Y0Km = BitConverter.ToSingle(b, 24), SizeKm = BitConverter.ToSingle(b, 28),
            };
            const int header = 32;
            if (b.Length != header + n * n * 2 + sr * sr * 4) throw new InvalidDataException("truncated tile: " + path);
            var raw = new ushort[n * n];
            Buffer.BlockCopy(b, header, raw, 0, n * n * 2);
            t.Heights = ResampleHeights(raw, n);
            t.Alpha = BuildAlpha(b, header + n * n * 2, sr);
            return t;
        }

        // The generated tiles are 501 samples (10 km at 20 m); Unity wants 2^n + 1, so heights are resampled to 513.
        // Seams still agree: an edge sample only ever interpolates along its own edge, identically in both tiles.
        static float[,] ResampleHeights(ushort[] raw, int w)
        {
            var h = new float[HeightRes, HeightRes];
            float step = (w - 1f) / (HeightRes - 1f);
            for (int zi = 0; zi < HeightRes; zi++)
            {
                float fy = zi * step; int y0 = Math.Min((int)fy, w - 2); float ty = fy - y0;
                for (int xi = 0; xi < HeightRes; xi++)
                {
                    float fx = xi * step; int x0 = Math.Min((int)fx, w - 2); float tx = fx - x0;
                    float a = raw[y0 * w + x0] + (raw[y0 * w + x0 + 1] - raw[y0 * w + x0]) * tx;
                    float c = raw[(y0 + 1) * w + x0] + (raw[(y0 + 1) * w + x0 + 1] - raw[(y0 + 1) * w + x0]) * tx;
                    h[HeightRes - 1 - zi, xi] = (a + (c - a) * ty) / 65535f; // file row 0 is the north edge; Unity z = 0 is the south edge
                }
            }
            return h;
        }

        static float[,,] BuildAlpha(byte[] b, int offset, int sr)
        {
            var a = new float[AlphaRes, AlphaRes, 4];
            for (int y = 0; y < AlphaRes; y++)
            {
                float fy = (AlphaRes - 1 - y + 0.5f) * sr / AlphaRes - 0.5f; // y = 0 is the south edge, file row 0 the north
                int y0 = Math.Max(0, Math.Min((int)Math.Floor(fy), sr - 2)); float ty = Math.Max(0f, Math.Min(1f, fy - y0));
                for (int x = 0; x < AlphaRes; x++)
                {
                    float fx = (x + 0.5f) * sr / AlphaRes - 0.5f;
                    int x0 = Math.Max(0, Math.Min((int)Math.Floor(fx), sr - 2)); float tx = Math.Max(0f, Math.Min(1f, fx - x0));
                    float sum = 0f;
                    for (int c = 0; c < 4; c++)
                    {
                        float p00 = b[offset + (y0 * sr + x0) * 4 + c], p01 = b[offset + (y0 * sr + x0 + 1) * 4 + c];
                        float p10 = b[offset + ((y0 + 1) * sr + x0) * 4 + c], p11 = b[offset + ((y0 + 1) * sr + x0 + 1) * 4 + c];
                        float v = (p00 + (p01 - p00) * tx) * (1f - ty) + (p10 + (p11 - p10) * tx) * ty;
                        a[y, x, c] = v / 255f; sum += a[y, x, c];
                    }
                    if (sum < 1e-4f) a[y, x, 0] = 1f;
                    else for (int c = 0; c < 4; c++) a[y, x, c] /= sum;
                }
            }
            return a;
        }
    }
}
