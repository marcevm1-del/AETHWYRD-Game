using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Ascend.Core;
using Newtonsoft.Json;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Ascend.Game
{
    /// <summary>
    /// Streams the world's terrain as the player walks: one Unity Terrain per 10 km tile, loaded and unloaded around the
    /// target with no loading screen. Which tiles stay resident is decided by Core's SectorStreamer (the rules and tests live
    /// there); this class does the files, the Terrain objects and the bookkeeping. Plan and numbers:
    /// 13_Production/open_world_streaming_plan.md. Tile files come from Tools/world/bake_stream_tiles.py.
    /// Not built yet: trees, buildings and props (dressing), water, far-ring impostors, origin shifting.
    /// </summary>
    public sealed class WorldStreamer : MonoBehaviour
    {
        sealed class TileSlot
        {
            public TileIndex Index; public string Name;
            public Task<StreamTile> Task; public Terrain Terrain; public TerrainData Data; public bool Cancelled;
            public bool Ready => Terrain != null;
        }

        [Serializable] class Manifest { public Anchor anchor; public ManifestTile[] tiles; public long totalBytes; }
        [Serializable] class Anchor { public double[] mapKm; public float heightM; }
        [Serializable] class ManifestTile { public string name; public string file; }

        static TerrainLayer[] _layers;

        /// <summary>The thing the world streams around (the player). Streaming idles while it is null.</summary>
        public Transform Target;
        /// <summary>Folder of baked tiles. Default: StreamingAssets/World.</summary>
        public string TileFolder;
        // 7.5 km reaches the diagonal tiles from the middle of a 10 km tile (their corner is 7.07 km away): the full 3 x 3 square.
        [NonSerialized] public SectorStreamTuning Tuning = new SectorStreamTuning { LoadRadiusKm = 7.5, UnloadMarginKm = 2, MaxResident = 9 };
        /// <summary>Terrain objects built per frame (the build itself is about one tile's SetHeights).</summary>
        public int BuildsPerFrame = 1;
        public float HeightmapPixelError = 8f;
        /// <summary>Load the tiles around the target at once in Start, so the ground exists before the first physics step.</summary>
        public bool BlockingFirstLoad = true;

        readonly Dictionary<TileIndex, TileSlot> _slots = new Dictionary<TileIndex, TileSlot>();
        readonly Dictionary<string, string> _files = new Dictionary<string, string>();
        SectorStreamer _streamer;
        WorldScale _scale;
        Transform _root;
        float _nextRegionCheck;
        TileIndex? _lastHome;

        // ---- what the tests and the HUD can read ----
        public bool Initialised { get; private set; }
        public int ReadyCount { get { int n = 0; foreach (var s in _slots.Values) if (s.Ready) n++; return n; } }
        public int PendingCount { get { int n = 0; foreach (var s in _slots.Values) if (!s.Ready && !s.Cancelled) n++; return n; } }
        public int ResidentCount => _slots.Count;
        public int TilesLoadedTotal { get; private set; }
        public int TilesUnloadedTotal { get; private set; }
        public int SeamsCrossed { get; private set; }
        public double LastBuildMs { get; private set; }
        public double MaxBuildMs { get; private set; }
        public string CurrentRegionId { get; private set; }
        public event Action<string, string> RegionChanged;
        public TileIndex? HomeTile => _lastHome;

        public IEnumerable<TileIndex> ReadyTiles { get { foreach (var s in _slots.Values) if (s.Ready) yield return s.Index; } }
        public Terrain TerrainOf(TileIndex t) => _slots.TryGetValue(t, out var s) ? s.Terrain : null;
        public bool IsReady(TileIndex t) => TerrainOf(t) != null;

        void Start()
        {
            Initialise();
            if (BlockingFirstLoad && Target != null) LoadNow();
        }

        public void Initialise()
        {
            if (Initialised) return;
            if (string.IsNullOrEmpty(TileFolder)) TileFolder = Path.Combine(Application.streamingAssetsPath, "World");
            var manifestPath = Path.Combine(TileFolder, "manifest.json");
            if (!File.Exists(manifestPath)) { Debug.LogWarning("[WorldStreamer] no baked tiles at " + TileFolder + " (run Tools/world/bake_stream_tiles.py): the world will not stream."); return; }
            var m = JsonConvert.DeserializeObject<Manifest>(File.ReadAllText(manifestPath));
            if (m.anchor?.mapKm != null && m.anchor.mapKm.Length >= 2) WorldOrigin.Configure(m.anchor.mapKm[0], m.anchor.mapKm[1], m.anchor.heightM);
            foreach (var t in m.tiles) _files[t.name] = Path.Combine(TileFolder, t.file);
            var scaleData = JsonConvert.DeserializeObject<WorldScaleData>(File.ReadAllText(Path.Combine(AscendData.DataRoot, "World", "world_scale.json")));
            _scale = new WorldScale(scaleData);
            _streamer = new SectorStreamer(_scale, Tuning);
            _root = new GameObject("StreamedWorld").transform;
            _root.SetParent(transform, false);
            Initialised = true;
        }

        /// <summary>The generated tiles are named by their south-west corner in whole km (x70_y50_s10_r20).</summary>
        string NameOf(TileIndex t)
        {
            double km = _scale.TileKm(built: true);
            return $"x{(int)Math.Round(t.Tx * km)}_y{(int)Math.Round(t.Ty * km)}_s{(int)Math.Round(km)}_r20";
        }

        /// <summary>Loads every wanted tile around the target before returning (start-up, teleports, load-game).</summary>
        public void LoadNow()
        {
            if (!Initialised || Target == null) return;
            Step();
            foreach (var s in new List<TileSlot>(_slots.Values))
                if (!s.Ready && !s.Cancelled) { try { s.Task.Wait(); } catch (AggregateException) { } Build(s); }
        }

        void Update()
        {
            if (!Initialised || Target == null) return;
            Step();
            int budget = BuildsPerFrame;
            foreach (var s in new List<TileSlot>(_slots.Values))
            {
                if (budget <= 0) break;
                if (!s.Ready && !s.Cancelled && s.Task.IsCompleted) { Build(s); budget--; }
            }
            if (Time.unscaledTime >= _nextRegionCheck) { _nextRegionCheck = Time.unscaledTime + 0.5f; CheckRegion(); }
        }

        void Step()
        {
            WorldOrigin.ToMapKm(Target.position, out double mx, out double my);
            var step = _streamer.Update(mx, my, built: true);
            if (_scale.TryTileOf(mx, my, out var home, built: true))
            {
                if (_lastHome.HasValue && !_lastHome.Value.Equals(home)) SeamsCrossed++;
                _lastHome = home;
            }
            foreach (var t in step.Unload) Unload(t);
            foreach (var t in step.Load) Begin(t);
        }

        void Begin(TileIndex t)
        {
            string name = NameOf(t);
            if (!_files.TryGetValue(name, out var path)) { Debug.LogWarning("[WorldStreamer] tile not baked: " + name); return; }
            var slot = new TileSlot { Index = t, Name = name, Task = Task.Run(() => StreamTile.Load(path)) };
            _slots[t] = slot;
        }

        void Build(TileSlot s)
        {
            if (s.Task.IsFaulted) { Debug.LogError("[WorldStreamer] " + s.Name + ": " + s.Task.Exception?.GetBaseException().Message); s.Cancelled = true; return; }
            var sw = Stopwatch.StartNew();
            var tile = s.Task.Result;
            var td = new TerrainData { heightmapResolution = StreamTile.HeightRes, alphamapResolution = StreamTile.AlphaRes };
            td.size = new Vector3(tile.SizeKm * 1000f, tile.MaxM - tile.MinM, tile.SizeKm * 1000f);
            td.SetHeights(0, 0, tile.Heights);
            td.terrainLayers = Layers();
            td.SetAlphamaps(0, 0, tile.Alpha);
            td.name = tile.Name;
            var go = Terrain.CreateTerrainGameObject(td);
            go.name = "Tile_" + tile.Name;
            go.transform.SetParent(_root, false);
            // south-west corner of the tile; map y runs south, so the tile's south edge is y0 + size
            go.transform.position = WorldOrigin.ToUnity(tile.X0Km, tile.Y0Km + tile.SizeKm, tile.MinM);
            var terrain = go.GetComponent<Terrain>();
            terrain.heightmapPixelError = HeightmapPixelError;
            var template = Resources.Load<Material>("World/StreamTerrain"); // also keeps URP's Terrain/Lit shader in a build
            if (template != null) terrain.materialTemplate = template;
            terrain.basemapDistance = 1000f;
            terrain.drawInstanced = true;
            terrain.allowAutoConnect = true; // same grouping id: Unity links neighbours as they appear
            terrain.groupingID = 0;
            s.Terrain = terrain; s.Data = td; s.Task = null;
            TilesLoadedTotal++;
            LastBuildMs = sw.Elapsed.TotalMilliseconds;
            if (LastBuildMs > MaxBuildMs) MaxBuildMs = LastBuildMs;
        }

        void Unload(TileIndex t)
        {
            if (!_slots.TryGetValue(t, out var s)) return;
            s.Cancelled = true;
            if (s.Terrain != null) { Destroy(s.Terrain.gameObject); TilesUnloadedTotal++; }
            if (s.Data != null) Destroy(s.Data);
            _slots.Remove(t);
        }

        void CheckRegion()
        {
            WorldOrigin.ToMapKm(Target.position, out double mx, out double my);
            var id = WorldMapArt.Terrain.RegionAt(mx, my)?.Id;
            if (id == CurrentRegionId) return;
            var from = CurrentRegionId; CurrentRegionId = id;
            RegionChanged?.Invoke(from, id);
        }

        /// <summary>The region under the target right now (recomputed, not cached).</summary>
        public string RegionNow()
        {
            if (Target == null) return null;
            WorldOrigin.ToMapKm(Target.position, out double mx, out double my);
            return WorldMapArt.Terrain.RegionAt(mx, my)?.Id;
        }

        static TerrainLayer[] Layers()
        {
            if (_layers != null && _layers[0] != null) return _layers;
            // vegetation, rock, sand, snow: art_direction section 9 tones; the colour map and toon shader replace these later
            var colours = new[] { new Color32(0x8C, 0xC8, 0x60, 255), new Color32(0x9E, 0x94, 0x86, 255), new Color32(0xE0, 0xB8, 0x85, 255), new Color32(0xF0, 0xF5, 0xFF, 255) };
            _layers = new TerrainLayer[4];
            for (int i = 0; i < 4; i++)
            {
                var tex = new Texture2D(4, 4, TextureFormat.RGBA32, false) { name = "TerrainLayerColour" + i };
                var fill = new Color32[16]; for (int k = 0; k < 16; k++) fill[k] = colours[i];
                tex.SetPixels32(fill); tex.Apply();
                _layers[i] = new TerrainLayer { diffuseTexture = tex, tileSize = new Vector2(30f, 30f), name = "StreamLayer" + i };
            }
            return _layers;
        }

        void OnDestroy()
        {
            foreach (var s in new List<TileSlot>(_slots.Values)) { if (s.Data != null) Destroy(s.Data); }
            _slots.Clear();
        }
    }
}
