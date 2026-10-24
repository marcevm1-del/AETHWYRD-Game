using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace Ascend.Core
{
    /// <summary>How much of a region your map shows (12_Systems/world_map.md §3).</summary>
    public enum MapStatus { Unknown, Heard, Visited }

    /// <summary>world_tuning.json → map.</summary>
    public sealed class MapTuning
    {
        /// <summary>Lands inked on the first day (you wake up in them).</summary>
        public List<string> StartVisited { get; set; } = new List<string> { "reg_whisperwood" };
        /// <summary>Lands everyone in Brindlewick talks about: pencilled in from the start.</summary>
        public List<string> StartHeard { get; set; } = new List<string>();
        /// <summary>Guild rank → the ring up to which the guild's map names the surface (the guild map seal).</summary>
        public Dictionary<string, int> GuildMapRings { get; set; } = new Dictionary<string, int>();
        /// <summary>The System overlay (rank-coloured zones and grid) arrives with the Rank E guild map seal.</summary>
        public string SystemOverlayRank { get; set; } = "E";
        /// <summary>The local map's fog grid, in metres per cell.</summary>
        public double AreaCellMetres { get; set; } = 4;
        /// <summary>How far around you the local map inks itself as you walk.</summary>
        public double AreaRevealMetres { get; set; } = 14;
        /// <summary>Named seas (from the atlas), written in once a nearby land is on your map.</summary>
        public List<MapLabel> Seas { get; set; } = new List<MapLabel>();
        /// <summary>How close (map units) a known land's centre must be to a sea's label for the sea to be named.</summary>
        public double SeaNameRange { get; set; } = 30;
    }

    /// <summary>A name written on the map at a point (map units).</summary>
    public sealed class MapLabel
    {
        public string Name { get; set; }
        public double[] At { get; set; }
    }

    /// <summary>What a save keeps of the map.</summary>
    public sealed class MapSave
    {
        public Dictionary<string, MapStatus> Regions { get; set; } = new Dictionary<string, MapStatus>();
        /// <summary>Explored cells per local area, as compressed base64 bits.</summary>
        public Dictionary<string, string> Areas { get; set; } = new Dictionary<string, string>();
    }

    /// <summary>
    /// The player's map (hud_and_ui.md §8: "it starts blank and inks itself as you explore"). Regions are Unknown
    /// (blank parchment), Heard (pencilled: a name from a quest, a rumour or the guild's map) or Visited (inked).
    /// Each local area also keeps a grid of explored cells. Hearing never downgrades a visit.
    /// </summary>
    public sealed class MapKnowledge
    {
        readonly Dictionary<string, MapStatus> _regions = new Dictionary<string, MapStatus>();
        readonly Dictionary<string, AreaFog> _areas = new Dictionary<string, AreaFog>();
        readonly Dictionary<string, RegionData> _byId;

        public MapTuning Tuning { get; }

        public MapKnowledge(MapTuning tuning, IEnumerable<RegionData> regions)
        {
            Tuning = tuning ?? new MapTuning();
            _byId = regions.ToDictionary(r => r.Id);
            foreach (var id in Tuning.StartHeard) Hear(id);
            foreach (var id in Tuning.StartVisited) Visit(id);
        }

        public MapStatus StatusOf(string regionId) => regionId != null && _regions.TryGetValue(regionId, out var s) ? s : MapStatus.Unknown;
        public IEnumerable<string> Heard => _regions.Where(kv => kv.Value == MapStatus.Heard).Select(kv => kv.Key);
        public IEnumerable<string> Visited => _regions.Where(kv => kv.Value == MapStatus.Visited).Select(kv => kv.Key);

        /// <summary>Pencils a region in; returns true if it was blank before.</summary>
        public bool Hear(string regionId)
        {
            if (regionId == null || !_byId.TryGetValue(regionId, out var r) || r.Map == null) return false;
            if (StatusOf(regionId) != MapStatus.Unknown) return false;
            _regions[regionId] = MapStatus.Heard;
            return true;
        }

        /// <summary>Inks a region in; returns true if it wasn't inked before.</summary>
        public bool Visit(string regionId)
        {
            if (regionId == null || !_byId.TryGetValue(regionId, out var r) || r.Map == null) return false;
            if (StatusOf(regionId) == MapStatus.Visited) return false;
            _regions[regionId] = MapStatus.Visited;
            return true;
        }

        /// <summary>The seas your map names: those with a heard-of or visited land near their label.</summary>
        public IEnumerable<MapLabel> KnownSeas()
        {
            var known = _regions.Where(kv => kv.Value != MapStatus.Unknown).Select(kv => _byId[kv.Key])
                .Where(r => r.Layer == "surface" && r.Map != null && r.Map.Radius > 0).ToList();
            foreach (var sea in Tuning.Seas ?? new List<MapLabel>())
            {
                if (sea?.At == null || sea.At.Length < 2) continue;
                if (known.Any(r => Math.Sqrt((r.Map.X - sea.At[0]) * (r.Map.X - sea.At[0]) + (r.Map.Y - sea.At[1]) * (r.Map.Y - sea.At[1])) <= Tuning.SeaNameRange))
                    yield return sea;
            }
        }

        /// <summary>The guild's map at a new rank names every surface land up to its ring; returns the newly heard ids.</summary>
        public List<string> OnGuildRank(RankLetter rank)
        {
            int ring = -1;
            foreach (var kv in Tuning.GuildMapRings)
                if (Enum.TryParse<RankLetter>(kv.Key, out var at) && at <= rank) ring = Math.Max(ring, kv.Value);
            var news = new List<string>();
            foreach (var r in _byId.Values.Where(r => r.Layer == "surface" && r.Map != null && r.Ring <= ring).OrderBy(r => r.Ring).ThenBy(r => r.Id))
                if (Hear(r.Id)) news.Add(r.Id);
            return news;
        }

        /// <summary>The System overlay (rank-coloured zones, grid) is open from the guild map seal's rank.</summary>
        public bool HasSystemOverlay(RankLetter rank) => Enum.TryParse<RankLetter>(Tuning.SystemOverlayRank, out var need) ? rank >= need : true;

        /// <summary>A local area's explored-cell grid (created blank the first time).</summary>
        public AreaFog Area(string areaId, double minX, double minZ, double size)
        {
            if (!_areas.TryGetValue(areaId, out var fog))
                _areas[areaId] = fog = new AreaFog(minX, minZ, size, Tuning.AreaCellMetres);
            return fog;
        }

        public MapSave Save() => new MapSave
        {
            Regions = new Dictionary<string, MapStatus>(_regions),
            Areas = _areas.ToDictionary(kv => kv.Key, kv => kv.Value.Save()),
        };

        /// <summary>Restores a save on top of the starting map (an older save without a map keeps the start).</summary>
        public void Load(MapSave save, Func<string, AreaFog> areaFor = null)
        {
            if (save == null) return;
            foreach (var kv in save.Regions ?? new Dictionary<string, MapStatus>())
            {
                if (kv.Value == MapStatus.Visited) Visit(kv.Key);
                else if (kv.Value == MapStatus.Heard) Hear(kv.Key);
            }
            foreach (var kv in save.Areas ?? new Dictionary<string, string>())
            {
                var fog = _areas.TryGetValue(kv.Key, out var f) ? f : areaFor?.Invoke(kv.Key);
                if (fog == null) continue;
                _areas[kv.Key] = fog;
                fog.Load(kv.Value);
            }
        }
    }

    /// <summary>A square local area split into cells that ink in as you walk near them.</summary>
    public sealed class AreaFog
    {
        readonly bool[] _cells;
        public double MinX { get; }
        public double MinZ { get; }
        public double Size { get; }
        public double CellSize { get; }
        public int Cells { get; }
        public int RevealedCount { get; private set; }
        public double Explored => RevealedCount / (double)_cells.Length;

        public AreaFog(double minX, double minZ, double size, double cellSize)
        {
            MinX = minX; MinZ = minZ; Size = size;
            Cells = Math.Max(1, (int)Math.Ceiling(size / Math.Max(.5, cellSize)));
            CellSize = size / Cells;
            _cells = new bool[Cells * Cells];
        }

        /// <summary>Cell (cx, cz): cx grows east, cz grows north from the area's south-west corner.</summary>
        public bool IsRevealed(int cx, int cz) => cx >= 0 && cz >= 0 && cx < Cells && cz < Cells && _cells[cz * Cells + cx];

        public bool IsRevealedAt(double x, double z) => IsRevealed((int)Math.Floor((x - MinX) / CellSize), (int)Math.Floor((z - MinZ) / CellSize));

        /// <summary>Inks every cell whose centre is within <paramref name="radius"/> of (x, z); returns how many were new.</summary>
        public int Reveal(double x, double z, double radius)
        {
            int added = 0;
            int c0 = (int)Math.Floor((x - radius - MinX) / CellSize), c1 = (int)Math.Floor((x + radius - MinX) / CellSize);
            int r0 = (int)Math.Floor((z - radius - MinZ) / CellSize), r1 = (int)Math.Floor((z + radius - MinZ) / CellSize);
            for (int cz = Math.Max(0, r0); cz <= Math.Min(Cells - 1, r1); cz++)
                for (int cx = Math.Max(0, c0); cx <= Math.Min(Cells - 1, c1); cx++)
                {
                    double mx = MinX + (cx + .5) * CellSize - x, mz = MinZ + (cz + .5) * CellSize - z;
                    if (mx * mx + mz * mz > radius * radius) continue;
                    int k = cz * Cells + cx;
                    if (_cells[k]) continue;
                    _cells[k] = true; added++;
                }
            RevealedCount += added;
            return added;
        }

        public string Save()
        {
            var bytes = new byte[(_cells.Length + 7) / 8];
            for (int i = 0; i < _cells.Length; i++) if (_cells[i]) bytes[i >> 3] |= (byte)(1 << (i & 7));
            using var ms = new MemoryStream();
            using (var z = new DeflateStream(ms, CompressionLevel.Optimal, true)) z.Write(bytes, 0, bytes.Length);
            return Convert.ToBase64String(ms.ToArray());
        }

        public void Load(string data)
        {
            if (string.IsNullOrEmpty(data)) return;
            byte[] bytes;
            try
            {
                using var ms = new MemoryStream(Convert.FromBase64String(data));
                using var z = new DeflateStream(ms, CompressionMode.Decompress);
                using var o = new MemoryStream();
                z.CopyTo(o); bytes = o.ToArray();
            }
            catch (Exception) { return; } // a damaged grid just leaves the area unexplored
            RevealedCount = 0;
            for (int i = 0; i < _cells.Length; i++)
            {
                _cells[i] = (i >> 3) < bytes.Length && (bytes[i >> 3] & (1 << (i & 7))) != 0;
                if (_cells[i]) RevealedCount++;
            }
        }
    }

    /// <summary>Minimal PNG writer (RGBA, 8-bit) so tools and tests can save the painted map without an engine.</summary>
    public static class MapPng
    {
        public static byte[] Encode(byte[] rgba, int width, int height)
        {
            var raw = new byte[(width * 4 + 1) * height];
            for (int y = 0; y < height; y++) Buffer.BlockCopy(rgba, y * width * 4, raw, y * (width * 4 + 1) + 1, width * 4);
            byte[] deflated;
            using (var ms = new MemoryStream())
            {
                using (var z = new DeflateStream(ms, CompressionLevel.Optimal, true)) z.Write(raw, 0, raw.Length);
                deflated = ms.ToArray();
            }
            uint a = 1, b = 0;
            foreach (var v in raw) { a = (a + v) % 65521; b = (b + a) % 65521; }
            var idat = new byte[deflated.Length + 6];
            idat[0] = 0x78; idat[1] = 0x9C;
            Buffer.BlockCopy(deflated, 0, idat, 2, deflated.Length);
            uint adler = (b << 16) | a;
            for (int i = 0; i < 4; i++) idat[idat.Length - 4 + i] = (byte)(adler >> (24 - 8 * i));
            var ihdr = new byte[13];
            Put(ihdr, 0, (uint)width); Put(ihdr, 4, (uint)height); ihdr[8] = 8; ihdr[9] = 6;
            using var png = new MemoryStream();
            png.Write(new byte[] { 137, 80, 78, 71, 13, 10, 26, 10 }, 0, 8);
            Chunk(png, "IHDR", ihdr); Chunk(png, "IDAT", idat); Chunk(png, "IEND", new byte[0]);
            return png.ToArray();
        }

        static void Put(byte[] b, int at, uint v) { for (int i = 0; i < 4; i++) b[at + i] = (byte)(v >> (24 - 8 * i)); }

        static void Chunk(Stream s, string type, byte[] data)
        {
            var len = new byte[4]; Put(len, 0, (uint)data.Length); s.Write(len, 0, 4);
            var td = new byte[4 + data.Length];
            for (int i = 0; i < 4; i++) td[i] = (byte)type[i];
            Buffer.BlockCopy(data, 0, td, 4, data.Length);
            s.Write(td, 0, td.Length);
            var crc = new byte[4]; Put(crc, 0, Crc(td)); s.Write(crc, 0, 4);
        }

        static uint[] _table;
        static uint Crc(byte[] data)
        {
            if (_table == null)
            {
                var t = new uint[256];
                for (uint n = 0; n < 256; n++) { uint c = n; for (int k = 0; k < 8; k++) c = (c & 1) != 0 ? 0xEDB88320u ^ (c >> 1) : c >> 1; t[n] = c; }
                _table = t;
            }
            uint crc = 0xFFFFFFFFu;
            foreach (var v in data) crc = _table[(crc ^ v) & 0xFF] ^ (crc >> 8);
            return crc ^ 0xFFFFFFFFu;
        }
    }
}
