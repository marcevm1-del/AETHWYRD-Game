using System;

namespace Ascend.Core
{
    // Wave F-lite (upgrade v10 section 10): one place that converts between atlas map units, kilometres, Unity
    // metres and terrain tiles. It chooses no scale. Every figure comes from Data/World/world_scale.json, which
    // restates physical_map.json (1 map unit = 1 km, 150 x 100) and the terrain tooling; the validator keeps them equal.
    // Axes: map x grows east and map y grows SOUTH (atlas); Unity metres are east (X) and north (Z), so Z = -(y - originY).

    /// <summary>Data/World/world_scale.json.</summary>
    public sealed class WorldScaleData
    {
        public int Version { get; set; }
        /// <summary>Kilometres per map unit (physical_map.json grid.unitKm).</summary>
        public double UnitKm { get; set; } = 1;
        public double CellKm { get; set; } = 0.5;
        /// <summary>Map width and height in map units.</summary>
        public double[] MapUnits { get; set; } = { 150, 100 };
        /// <summary>The tile size the existing terrain tiles were built with.</summary>
        public double BuiltTileKm { get; set; } = 10;
        /// <summary>The tile size proposed for Unity (a placeholder until the user decides).</summary>
        public double TerrainTileKm { get; set; } = 10.24;
        public string TerrainTileKmStatus { get; set; }
        public WorldScaleOrigin Origin { get; set; } = new WorldScaleOrigin();
    }

    public sealed class WorldScaleOrigin
    {
        /// <summary>The map point that is Unity metre (0, 0).</summary>
        public double[] MapAt { get; set; } = { 0, 0 };
        public string Status { get; set; }
    }

    /// <summary>Metres east (X) and north (Z) of the origin.</summary>
    public readonly struct WorldMetres
    {
        public readonly double X, Z;
        public WorldMetres(double x, double z) { X = x; Z = z; }
    }

    /// <summary>A terrain tile index: tx grows east, ty grows south from the map's north-west corner.</summary>
    public readonly struct TileIndex : IEquatable<TileIndex>
    {
        public readonly int Tx, Ty;
        public TileIndex(int tx, int ty) { Tx = tx; Ty = ty; }
        public bool Equals(TileIndex o) => Tx == o.Tx && Ty == o.Ty;
        public override bool Equals(object o) => o is TileIndex t && Equals(t);
        public override int GetHashCode() => Tx * 397 ^ Ty;
        public override string ToString() => $"({Tx},{Ty})";
    }

    public sealed class WorldScale
    {
        public const double MetresPerKm = 1000;

        public WorldScaleData Data { get; }
        public double UnitKm => Data.UnitKm;
        public double WidthUnits => Data.MapUnits[0];
        public double HeightUnits => Data.MapUnits[1];
        public double WidthKm => WidthUnits * UnitKm;
        public double HeightKm => HeightUnits * UnitKm;
        public double OriginX => Data.Origin.MapAt[0];
        public double OriginY => Data.Origin.MapAt[1];
        /// <summary>True while the tile size is the proposed 10.24 km and not a decision.</summary>
        public bool TileSizeIsPlaceholder => !string.IsNullOrEmpty(Data.TerrainTileKmStatus) && Data.TerrainTileKmStatus.StartsWith("placeholder", StringComparison.Ordinal);

        public WorldScale(WorldScaleData data)
        {
            Data = data ?? throw new ArgumentNullException(nameof(data));
            if (!(data.UnitKm > 0) || double.IsInfinity(data.UnitKm)) throw new ArgumentException("unitKm must be a positive number");
            if (data.MapUnits == null || data.MapUnits.Length != 2 || !(data.MapUnits[0] > 0) || !(data.MapUnits[1] > 0)) throw new ArgumentException("mapUnits must be two positive numbers");
            if (!(data.TerrainTileKm > 0) || !(data.BuiltTileKm > 0)) throw new ArgumentException("tile sizes must be positive");
            if (data.Origin?.MapAt == null || data.Origin.MapAt.Length != 2) throw new ArgumentException("origin.mapAt needs x and y");
            if (!IsFinite(data.Origin.MapAt[0]) || !IsFinite(data.Origin.MapAt[1])) throw new ArgumentException("origin must be finite");
        }

        static bool IsFinite(double v) => !double.IsNaN(v) && !double.IsInfinity(v);
        static void Need(double v, string what) { if (!IsFinite(v)) throw new ArgumentException(what + " must be a finite number"); }

        // ---- lengths ----
        public double UnitsToKm(double units) { Need(units, "units"); return units * UnitKm; }
        public double KmToUnits(double km) { Need(km, "km"); return km / UnitKm; }
        public double UnitsToMetres(double units) => UnitsToKm(units) * MetresPerKm;
        public double MetresToUnits(double metres) { Need(metres, "metres"); return metres / MetresPerKm / UnitKm; }

        /// <summary>Straight-line distance between two map points, in km.</summary>
        public double DistanceKm(double ax, double ay, double bx, double by)
        {
            Need(ax, "ax"); Need(ay, "ay"); Need(bx, "bx"); Need(by, "by");
            return Math.Sqrt((ax - bx) * (ax - bx) + (ay - by) * (ay - by)) * UnitKm;
        }

        // ---- points ----
        /// <summary>Map point to Unity metres (east, north) relative to the origin.</summary>
        public WorldMetres MapToMetres(double mapX, double mapY)
        {
            Need(mapX, "mapX"); Need(mapY, "mapY");
            return new WorldMetres((mapX - OriginX) * UnitKm * MetresPerKm, -(mapY - OriginY) * UnitKm * MetresPerKm);
        }

        /// <summary>Unity metres (east, north) back to a map point.</summary>
        public (double X, double Y) MetresToMap(double east, double north)
        {
            Need(east, "east"); Need(north, "north");
            return (OriginX + east / (UnitKm * MetresPerKm), OriginY - north / (UnitKm * MetresPerKm));
        }

        /// <summary>Is the map point inside the 150 x 100 map?</summary>
        public bool Contains(double mapX, double mapY) => IsFinite(mapX) && IsFinite(mapY) && mapX >= 0 && mapY >= 0 && mapX < WidthUnits && mapY < HeightUnits;

        // ---- terrain tiles (measured from the map's north-west corner, whatever the origin is) ----
        /// <summary>Tile edge in km: the proposed size by default, or the size of the tiles built today.</summary>
        public double TileKm(bool built = false) => built ? Data.BuiltTileKm : Data.TerrainTileKm;

        /// <summary>How many tiles cover the map (rounded up): 15 x 10 at 10.24 km.</summary>
        public (int Nx, int Ny) TileCount(bool built = false) =>
            ((int)Math.Ceiling(WidthKm / TileKm(built) - 1e-9), (int)Math.Ceiling(HeightKm / TileKm(built) - 1e-9));

        /// <summary>The tile holding a map point; false when the point is outside the map.</summary>
        public bool TryTileOf(double mapX, double mapY, out TileIndex tile, bool built = false)
        {
            tile = default;
            if (!Contains(mapX, mapY)) return false;
            double s = TileKm(built);
            tile = new TileIndex((int)Math.Floor(mapX * UnitKm / s), (int)Math.Floor(mapY * UnitKm / s));
            return true;
        }

        /// <summary>The tile's north-west corner as a map point (tile (tx, ty) starts at tx * tileKm km).</summary>
        public (double X, double Y) TileOriginMap(TileIndex t, bool built = false) =>
            (t.Tx * TileKm(built) / UnitKm, t.Ty * TileKm(built) / UnitKm);

        /// <summary>The tile's north-west corner in Unity metres.</summary>
        public WorldMetres TileOriginMetres(TileIndex t, bool built = false)
        {
            var o = TileOriginMap(t, built);
            return MapToMetres(o.X, o.Y);
        }

        /// <summary>Metres east and south of the tile's north-west corner (what a terrain-local position is).</summary>
        public (double East, double South) TileLocalMetres(double mapX, double mapY, bool built = false)
        {
            if (!TryTileOf(mapX, mapY, out var t, built)) throw new ArgumentOutOfRangeException(nameof(mapX), "the point is outside the map");
            var o = TileOriginMap(t, built);
            return ((mapX - o.X) * UnitKm * MetresPerKm, (mapY - o.Y) * UnitKm * MetresPerKm);
        }
    }
}
