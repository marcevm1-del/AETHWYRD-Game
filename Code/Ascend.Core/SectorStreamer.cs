using System;
using System.Collections.Generic;
using System.Linq;

namespace Ascend.Core
{
    // Sector loader prototype, engine-agnostic half (12_Systems/world_graph.md). Decides which 10.24 km terrain tiles
    // should be resident around the player; a Unity host loads and unloads scenes or terrains to match.

    public sealed class SectorStreamTuning
    {
        /// <summary>Tiles are wanted when their edge is within this many km of the player.</summary>
        public double LoadRadiusKm { get; set; } = 6;
        /// <summary>A loaded tile is kept until its edge is farther than load radius plus this margin (stops flicker at borders).</summary>
        public double UnloadMarginKm { get; set; } = 2;
        /// <summary>Hard cap on resident tiles (memory budget). The nearest tiles win.</summary>
        public int MaxResident { get; set; } = 9;
    }

    public sealed class SectorStreamStep
    {
        public List<TileIndex> Load { get; } = new List<TileIndex>();
        public List<TileIndex> Unload { get; } = new List<TileIndex>();
        public List<TileIndex> Resident { get; } = new List<TileIndex>();
    }

    public sealed class SectorStreamer
    {
        readonly WorldScale _scale;
        readonly SectorStreamTuning _t;
        readonly HashSet<TileIndex> _resident = new HashSet<TileIndex>();

        public SectorStreamer(WorldScale scale, SectorStreamTuning tuning = null)
        {
            _scale = scale ?? throw new ArgumentNullException(nameof(scale));
            _t = tuning ?? new SectorStreamTuning();
        }

        public IReadOnlyCollection<TileIndex> Resident => _resident;

        /// <summary>Distance in km from a map point to the nearest edge of a tile (0 inside it).</summary>
        public double DistanceKm(double mapX, double mapY, TileIndex t, bool built = false)
        {
            var (ox, oy) = _scale.TileOriginMap(t, built);
            double size = _scale.TileKm(built) / _scale.UnitKm;
            double dx = Math.Max(0, Math.Max(ox - mapX, mapX - (ox + size)));
            double dy = Math.Max(0, Math.Max(oy - mapY, mapY - (oy + size)));
            return Math.Sqrt(dx * dx + dy * dy) * _scale.UnitKm;
        }

        /// <summary>
        /// One streaming step for the player's map position. Returns what to load and unload; the resident set is updated.
        /// The tile under the player is always kept. Positions outside the map change nothing.
        /// </summary>
        public SectorStreamStep Update(double mapX, double mapY, bool built = false)
        {
            var step = new SectorStreamStep();
            if (!_scale.TryTileOf(mapX, mapY, out var here, built))
            {
                step.Resident.AddRange(_resident);
                return step;
            }
            var (nx, ny) = _scale.TileCount(built);
            var candidates = new List<(TileIndex t, double d)>();
            for (int ty = 0; ty < ny; ty++)
                for (int tx = 0; tx < nx; tx++)
                {
                    var t = new TileIndex(tx, ty);
                    double d = DistanceKm(mapX, mapY, t, built);
                    double limit = _resident.Contains(t) ? _t.LoadRadiusKm + _t.UnloadMarginKm : _t.LoadRadiusKm;
                    if (t.Equals(here) || d <= limit) candidates.Add((t, d));
                }
            var keep = candidates.OrderBy(c => c.t.Equals(here) ? -1 : c.d).ThenBy(c => c.t.Ty).ThenBy(c => c.t.Tx)
                .Take(Math.Max(1, _t.MaxResident)).Select(c => c.t).ToList();
            var keepSet = new HashSet<TileIndex>(keep);
            foreach (var t in _resident.Where(t => !keepSet.Contains(t)).OrderBy(t => t.Ty).ThenBy(t => t.Tx).ToList()) { step.Unload.Add(t); _resident.Remove(t); }
            foreach (var t in keep.Where(t => !_resident.Contains(t))) { step.Load.Add(t); _resident.Add(t); }
            step.Resident.AddRange(_resident.OrderBy(t => t.Ty).ThenBy(t => t.Tx));
            return step;
        }

        /// <summary>Forget everything (scene reload or load-game): the next Update loads from scratch.</summary>
        public void Clear() => _resident.Clear();
    }
}
