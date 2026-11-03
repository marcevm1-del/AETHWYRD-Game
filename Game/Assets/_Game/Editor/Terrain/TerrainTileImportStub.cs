using System;
using System.IO;
using System.IO.Compression;
using UnityEditor;
using UnityEngine;

namespace Ascend.EditorTools
{
    /// <summary>
    /// STUB (wave 0 of the world-terrain import, spec: 13_Production/terrain_unity_import.md). Reads one tile's
    /// <c>*_height.json</c> sidecar + 16-bit <c>*_height.png</c> (+ <c>*_splat.png</c> when present) from
    /// Art/Blender/WorldTerrain/world and writes a TerrainData asset under the throwaway folder
    /// <see cref="OutFolder"/>. It creates NO scene objects, no Terrain component, no neighbour links, no dressing and
    /// no water; those are the real importer's job. A tile that is not 2^n + 1 samples (the current 501 ones) is
    /// bilinearly resampled to 513 for a look only: build with --tile-km 10.24 --res 20 for the real thing.
    /// Menu: Assets/Ascend/Terrain/Import Tile (stub). Batch: -executeMethod Ascend.EditorTools.TerrainTileImportStub.ImportBatch -terrainSidecar &lt;json&gt;.
    /// </summary>
    public static class TerrainTileImportStub
    {
        public const string OutFolder = "Assets/_TerrainImportScratch"; // throwaway; delete freely
        const int AlphamapRes = 512;

        // Palette: art_direction section 9 (grass lit/shade, dirt) and the rock / sand / snow tones in world_terrain.md.
        // The splat channels are R vegetation, G rock, B sand, A snow.
        static readonly string[] LayerNames = { "Vegetation", "Rock", "Sand", "Snow" };
        static readonly Color[] LayerColors =
        {
            new Color32(0x8C, 0xC8, 0x60, 255), // lit grass (shade #5E9A4A and dirt #C9A66B come from the colour map in the real importer)
            new Color32(0x9E, 0x94, 0x86, 255), // mid rock
            new Color32(0xE0, 0xB8, 0x85, 255), // adobe sand
            new Color32(0xF0, 0xF5, 0xFF, 255), // snow
        };

        [Serializable] class Tile { public float x0Km, y0Km, sizeKm; }
        [Serializable] class Encoding { public int bits; public float minM, maxM; }
        [Serializable] class Files { public string heightmap, splat; }
        [Serializable] class Ring0 { public float sizeM, heightM; }
        [Serializable] class Settlement { public string name; public float[] atKm; public float padHeightM; public Ring0 ring0; }
        [Serializable]
        class Sidecar
        {
            public string name;
            public int samples;
            public float resolutionM;
            public Tile tile;
            public Encoding encoding;
            public Files files;
            public Settlement[] settlements;
        }

        [MenuItem("Assets/Ascend/Terrain/Import Tile (stub)")]
        public static void ImportMenu()
        {
            var start = Path.GetFullPath(Path.Combine(Application.dataPath, "../../Art/Blender/WorldTerrain/world"));
            var json = EditorUtility.OpenFilePanel("Terrain tile sidecar (*_height.json)", Directory.Exists(start) ? start : "", "json");
            if (string.IsNullOrEmpty(json)) return;
            var path = Import(json);
            if (path != null) EditorGUIUtility.PingObject(AssetDatabase.LoadMainAssetAtPath(path));
        }

        public static void ImportBatch()
        {
            string json = null;
            var args = Environment.GetCommandLineArgs();
            for (int i = 0; i < args.Length - 1; i++) if (args[i] == "-terrainSidecar") json = args[i + 1];
            if (json == null || Import(json) == null) EditorApplication.Exit(1);
        }

        /// <summary>Returns the asset path of the new TerrainData, or null on error.</summary>
        public static string Import(string sidecarPath)
        {
            try
            {
                var sc = JsonUtility.FromJson<Sidecar>(File.ReadAllText(sidecarPath));
                var dir = Path.GetDirectoryName(sidecarPath);
                if (sc?.tile == null || sc.encoding == null || sc.files == null) throw new InvalidDataException("not an ascend-terrain-heightmap sidecar");
                if (sc.encoding.bits != 16) throw new InvalidDataException("expected a 16-bit heightmap");

                var raw = ReadPng16(Path.Combine(dir, sc.files.heightmap), out int w, out int h);
                if (w != h) throw new InvalidDataException("heightmap is not square");
                int n = IsPow2Plus1(w) ? w : 513;
                if (n != w) Debug.LogWarning($"[TerrainStub] {sc.name}: {w} samples is not 2^n+1; resampling to {n} for preview only (use --tile-km 10.24 --res 20).");

                var td = new TerrainData { heightmapResolution = n };
                // Fixed encoding for every tile: height = minM + v/65535 * (maxM - minM). Unity stores the same 16 bits.
                float range = sc.encoding.maxM - sc.encoding.minM;
                td.size = new Vector3(sc.tile.sizeKm * 1000f, range, sc.tile.sizeKm * 1000f);
                var heights = new float[n, n]; // [z index (south = 0), x index]; PNG row 0 is the north edge, so flip rows
                for (int zi = 0; zi < n; zi++)
                    for (int xi = 0; xi < n; xi++)
                        heights[n - 1 - zi, xi] = SampleBilinear(raw, w, xi * (w - 1f) / (n - 1f), zi * (w - 1f) / (n - 1f)) / 65535f;
                td.SetHeights(0, 0, heights);
                td.name = sc.name;

                // Round-trip check: Unity's internal quantisation must not lose the 0.08 m step (seams depend on it).
                var back = td.GetHeights(0, 0, n, n);
                float maxErr = 0f;
                for (int zi = 0; zi < n; zi++) for (int xi = 0; xi < n; xi++) maxErr = Mathf.Max(maxErr, Mathf.Abs(back[zi, xi] - heights[zi, xi]) * range);
                Debug.Log($"[TerrainStub] {sc.name}: heightmap {n}x{n}, size {td.size}, Unity round-trip max error {maxErr:F3} m (encoding step {range / 65535f:F3} m).");

                if (sc.settlements != null)
                    foreach (var s in sc.settlements)
                    {
                        if (s.atKm == null || s.atKm.Length < 2 || s.ring0 == null) continue;
                        float fx = (s.atKm[0] - sc.tile.x0Km) * 1000f / sc.resolutionM, fr = (s.atKm[1] - sc.tile.y0Km) * 1000f / sc.resolutionM;
                        float hM = sc.encoding.minM + SampleBilinear(raw, w, fx, fr) / 65535f * range;
                        Debug.Log($"[TerrainStub] Ring 0 settlement {s.name}: raster height {hM:F2} m vs sidecar pad {s.padHeightM:F2} m.");
                    }

                Directory.CreateDirectory(OutFolder);
                if (!string.IsNullOrEmpty(sc.files.splat) && File.Exists(Path.Combine(dir, sc.files.splat)))
                {
                    td.alphamapResolution = AlphamapRes;
                    td.terrainLayers = MakeLayers();
                    td.SetAlphamaps(0, 0, BuildAlphamaps(Path.Combine(dir, sc.files.splat)));
                }

                var assetPath = $"{OutFolder}/{sc.name}_TerrainData.asset";
                AssetDatabase.DeleteAsset(assetPath);
                AssetDatabase.CreateAsset(td, assetPath);
                AssetDatabase.SaveAssets();
                Debug.Log($"[TerrainStub] wrote {assetPath}");
                return assetPath;
            }
            catch (Exception e)
            {
                Debug.LogError($"[TerrainStub] import failed: {e.Message}");
                return null;
            }
        }

        static bool IsPow2Plus1(int v) { int m = v - 1; return m >= 32 && (m & (m - 1)) == 0; }

        static float SampleBilinear(ushort[] raw, int w, float x, float y)
        {
            int x0 = Mathf.Clamp((int)x, 0, w - 1), y0 = Mathf.Clamp((int)y, 0, w - 1);
            int x1 = Mathf.Min(x0 + 1, w - 1), y1 = Mathf.Min(y0 + 1, w - 1);
            float fx = x - x0, fy = y - y0;
            float a = Mathf.Lerp(raw[y0 * w + x0], raw[y0 * w + x1], fx), b = Mathf.Lerp(raw[y1 * w + x0], raw[y1 * w + x1], fx);
            return Mathf.Lerp(a, b, fy);
        }

        /// <summary>Splat nodes (w x w, 8-bit RGBA) to 512 alphamap cells: sample at cell centres, normalise the weights.</summary>
        static float[,,] BuildAlphamaps(string splatPng)
        {
            var tex = new Texture2D(2, 2, TextureFormat.RGBA32, false);
            try
            {
                if (!tex.LoadImage(File.ReadAllBytes(splatPng), false)) throw new InvalidDataException("cannot decode the splat PNG");
                // LoadImage puts PNG row 0 (north) at the highest y, which is exactly the Unity alphamap
                // orientation (y = 0 is the south edge), so no flip is needed here.
                int sw = tex.width;
                var px = tex.GetPixels32();
                var a = new float[AlphamapRes, AlphamapRes, 4];
                for (int y = 0; y < AlphamapRes; y++)
                    for (int x = 0; x < AlphamapRes; x++)
                    {
                        float fx = (x + 0.5f) * (sw - 1f) / AlphamapRes, fy = (y + 0.5f) * (sw - 1f) / AlphamapRes;
                        int x0 = Mathf.Min((int)fx, sw - 2), y0 = Mathf.Min((int)fy, sw - 2);
                        float tx = fx - x0, ty = fy - y0, sum = 0f;
                        for (int c = 0; c < 4; c++)
                        {
                            float lo = Mathf.Lerp(Ch(px[y0 * sw + x0], c), Ch(px[y0 * sw + x0 + 1], c), tx);
                            float hi = Mathf.Lerp(Ch(px[(y0 + 1) * sw + x0], c), Ch(px[(y0 + 1) * sw + x0 + 1], c), tx);
                            a[y, x, c] = Mathf.Lerp(lo, hi, ty);
                            sum += a[y, x, c];
                        }
                        if (sum < 1e-4f) a[y, x, 0] = 1f;
                        else for (int c = 0; c < 4; c++) a[y, x, c] /= sum;
                    }
                return a;
            }
            finally { UnityEngine.Object.DestroyImmediate(tex); }
        }

        static float Ch(Color32 c, int i) => (i == 0 ? c.r : i == 1 ? c.g : i == 2 ? c.b : c.a) / 255f;

        static TerrainLayer[] MakeLayers()
        {
            var layers = new TerrainLayer[LayerNames.Length];
            for (int i = 0; i < layers.Length; i++)
            {
                var tex = new Texture2D(4, 4, TextureFormat.RGBA32, false);
                var fill = new Color[16];
                for (int k = 0; k < 16; k++) fill[k] = LayerColors[i];
                tex.SetPixels(fill);
                tex.Apply();
                var texPath = $"{OutFolder}/Layer_{LayerNames[i]}.png";
                File.WriteAllBytes(texPath, tex.EncodeToPNG());
                UnityEngine.Object.DestroyImmediate(tex);
                AssetDatabase.ImportAsset(texPath);
                var layerPath = $"{OutFolder}/Layer_{LayerNames[i]}.terrainlayer";
                AssetDatabase.DeleteAsset(layerPath);
                var layer = new TerrainLayer { diffuseTexture = AssetDatabase.LoadAssetAtPath<Texture2D>(texPath), tileSize = new Vector2(30f, 30f) };
                AssetDatabase.CreateAsset(layer, layerPath);
                layers[i] = layer;
            }
            return layers;
        }

        /// <summary>Minimal PNG reader for the tiles' 16-bit greyscale, non-interlaced format. Returns big-endian samples as ushort, row 0 first.</summary>
        static ushort[] ReadPng16(string path, out int w, out int h)
        {
            var b = File.ReadAllBytes(path);
            if (b.Length < 33 || b[0] != 0x89 || b[1] != 0x50) throw new InvalidDataException("not a PNG: " + path);
            int pos = 8, bitDepth = 0, colorType = -1, interlace = 0;
            w = h = 0;
            var idat = new MemoryStream();
            while (pos + 8 <= b.Length)
            {
                int len = (b[pos] << 24) | (b[pos + 1] << 16) | (b[pos + 2] << 8) | b[pos + 3];
                string type = System.Text.Encoding.ASCII.GetString(b, pos + 4, 4);
                int d = pos + 8;
                if (type == "IHDR")
                {
                    w = (b[d] << 24) | (b[d + 1] << 16) | (b[d + 2] << 8) | b[d + 3];
                    h = (b[d + 4] << 24) | (b[d + 5] << 16) | (b[d + 6] << 8) | b[d + 7];
                    bitDepth = b[d + 8]; colorType = b[d + 9]; interlace = b[d + 12];
                }
                else if (type == "IDAT") idat.Write(b, d, len);
                else if (type == "IEND") break;
                pos = d + len + 4;
            }
            if (bitDepth != 16 || colorType != 0 || interlace != 0) throw new InvalidDataException("expected 16-bit greyscale, non-interlaced PNG");
            idat.Position = 2; // skip the zlib header
            var data = new byte[h * (1 + w * 2)];
            using (var z = new DeflateStream(idat, CompressionMode.Decompress))
            {
                int got = 0;
                while (got < data.Length) { int r = z.Read(data, got, data.Length - got); if (r <= 0) break; got += r; }
                if (got != data.Length) throw new InvalidDataException("truncated PNG data");
            }
            int stride = w * 2;
            var px = new byte[h * stride];
            for (int y = 0; y < h; y++)
            {
                int f = data[y * (stride + 1)], src = y * (stride + 1) + 1, dst = y * stride;
                for (int i = 0; i < stride; i++)
                {
                    int x = data[src + i];
                    int left = i >= 2 ? px[dst + i - 2] : 0, up = y > 0 ? px[dst - stride + i] : 0, ul = (i >= 2 && y > 0) ? px[dst - stride + i - 2] : 0;
                    switch (f)
                    {
                        case 1: x += left; break;
                        case 2: x += up; break;
                        case 3: x += (left + up) / 2; break;
                        case 4:
                            int p = left + up - ul, pa = Math.Abs(p - left), pb = Math.Abs(p - up), pc = Math.Abs(p - ul);
                            x += (pa <= pb && pa <= pc) ? left : (pb <= pc ? up : ul);
                            break;
                    }
                    px[dst + i] = (byte)x;
                }
            }
            var o = new ushort[w * h];
            for (int i = 0; i < o.Length; i++) o[i] = (ushort)((px[i * 2] << 8) | px[i * 2 + 1]);
            return o;
        }
    }
}
