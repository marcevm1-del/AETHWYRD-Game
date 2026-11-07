using System.IO;
using System.Linq;
using System.Text.Json;
using Ascend.Core;

// Wave F-lite: the coordinate helper. It reads the scale that already exists and decides nothing.
[Tests]
static class WorldScaleTests
{
    static WorldScaleData Raw() => Repo.Load<WorldScaleData>("Data/World/world_scale.json");
    static WorldScale S() => new WorldScale(Raw());
    static WorldScale AtBrindlewick()
    {
        var d = Raw(); d.Origin.MapAt = new[] { 72.6, 60.0 };
        return new WorldScale(d);
    }

    public static void TheDataAgreesWithThePhysicalMapAndTheTerrainTooling()
    {
        using var doc = JsonDocument.Parse(File.ReadAllText(Path.Combine(Repo.Root(), "Data/World/physical_map.json")));
        var grid = doc.RootElement.GetProperty("grid");
        var d = Raw();
        Assert.Near(grid.GetProperty("unitKm").GetDouble(), d.UnitKm, 0, "unitKm");
        Assert.Near(grid.GetProperty("cellKm").GetDouble(), d.CellKm, 0, "cellKm");
        var mu = grid.GetProperty("mapUnits").EnumerateArray().Select(x => x.GetDouble()).ToArray();
        Assert.Near(mu[0], d.MapUnits[0], 0, "map width"); Assert.Near(mu[1], d.MapUnits[1], 0, "map height");
        var g = Repo.Load<RegionGraphData>("Data/World/region_graph.json");
        Assert.Near(d.UnitKm, g.Scale.UnitKm, 0, "the region graph uses the same unit");
        Assert.True(File.ReadAllText(Path.Combine(Repo.Root(), "Tools/blender/build_world_sectors.py")).Contains("\"--tile-km\", type=float, default=" + d.BuiltTileKm.ToString("0.0###", System.Globalization.CultureInfo.InvariantCulture)), "builtTileKm is the sector builder's default");
    }

    public static void OneMapUnitIsAKilometreAndTheMapIs150By100Km()
    {
        var s = S();
        Assert.Near(1.0, s.UnitsToKm(1), 0, "1 unit = 1 km");
        Assert.Near(1000.0, s.UnitsToMetres(1), 0, "1 unit = 1000 m");
        Assert.Near(150.0, s.WidthKm, 0, "width"); Assert.Near(100.0, s.HeightKm, 0, "height");
        Assert.Near(2.5, s.KmToUnits(2.5), 0, "km back to units at 1 km/unit");
        Assert.Near(11.98, s.DistanceKm(72.6, 60, 66, 50), 0.01, "Brindlewick to Aldmere is about 12 km as the crow flies (the road is 12.9)");
        Assert.Near(5.0, s.DistanceKm(0, 0, 3, 4), 1e-12, "3-4-5");
    }

    public static void MapToMetresPutsNorthUpAndEastRight()
    {
        var s = S();
        var b = s.MapToMetres(72.6, 60);
        Assert.Near(72600, b.X, 1e-6, "east"); Assert.Near(-60000, b.Z, 1e-6, "map y grows south, so Z falls");
        var a = s.MapToMetres(66, 50);
        Assert.True(a.Z > b.Z, "Aldmere is north of Brindlewick, so higher Z");
        Assert.True(a.X < b.X, "and west of it");
    }

    public static void RoundTripIsExactAcrossTheWholeMap()
    {
        foreach (var s in new[] { S(), AtBrindlewick() })
            for (double x = 0; x < 150; x += 7.3)
                for (double y = 0; y < 100; y += 5.9)
                {
                    var m = s.MapToMetres(x, y);
                    var back = s.MetresToMap(m.X, m.Z);
                    Assert.Near(x, back.X, 1e-9, $"x at {x},{y}"); Assert.Near(y, back.Y, 1e-9, $"y at {x},{y}");
                }
        Assert.Near(33.3, S().MetresToUnits(S().UnitsToMetres(33.3)), 1e-12, "length round trip");
    }

    public static void ChangingTheOriginMovesEveryConversionByTheSameAmount()
    {
        var s = AtBrindlewick();
        var b = s.MapToMetres(72.6, 60);
        Assert.Near(0, b.X, 1e-6, "Brindlewick is the origin"); Assert.Near(0, b.Z, 1e-6, "Brindlewick is the origin");
        var a = s.MapToMetres(66, 50);
        Assert.Near(-6600, a.X, 1e-6, "Aldmere is 6.6 km west"); Assert.Near(10000, a.Z, 1e-6, "and 10 km north");
        Assert.True(S().TileCount().Nx == s.TileCount().Nx, "tiles do not depend on the origin");
        Assert.True(S().TryTileOf(72.6, 60, out var t1) && s.TryTileOf(72.6, 60, out var t2) && t1.Equals(t2), "same tile");
    }

    public static void TheMapIs15By10Tiles()
    {
        var s = S();
        Assert.Equal((15, 10), s.TileCount(), "10.24 km tiles (terrain_unity_import.md: 15 x 10 = 150 tiles)");
        Assert.Equal((15, 10), s.TileCount(built: true), "10 km tiles built today");
        Assert.Near(10.24, s.TileKm(), 0, "proposed tile");
        Assert.Near(10.0, s.TileKm(built: true), 0, "built tile");
        Assert.True(!s.TileSizeIsPlaceholder, "10.24 km was decided 2026-11-07 (Canon section 6 WF9)");
    }

    public static void APointFallsInTheTileThatStartsBeforeIt()
    {
        var s = S();
        Assert.True(s.TryTileOf(72.6, 60, out var t), "Brindlewick is on the map");
        Assert.Equal(new TileIndex(7, 5), t, "tile of Brindlewick at 10.24 km");
        var o = s.TileOriginMap(t);
        Assert.Near(71.68, o.X, 1e-9, "tile origin x km"); Assert.Near(51.2, o.Y, 1e-9, "tile origin y km");
        var l = s.TileLocalMetres(72.6, 60);
        Assert.Near(920, l.East, 1e-6, "metres east of the tile corner"); Assert.Near(8800, l.South, 1e-6, "metres south of it");
        var m = s.TileOriginMetres(t);
        Assert.Near(71680, m.X, 1e-6, "tile corner east"); Assert.Near(-51200, m.Z, 1e-6, "tile corner north");
        for (double x = 0.0; x < 150; x += 3.1)
            for (double y = 0.0; y < 100; y += 2.7)
            {
                Assert.True(s.TryTileOf(x, y, out var ti), "inside");
                var c = s.TileOriginMap(ti); var loc = s.TileLocalMetres(x, y);
                Assert.True(loc.East >= -1e-9 && loc.East < 10240 && loc.South >= -1e-9 && loc.South < 10240, $"{x},{y} local {loc.East},{loc.South}");
                Assert.Near(x, c.X + loc.East / 1000, 1e-9, "x back"); Assert.Near(y, c.Y + loc.South / 1000, 1e-9, "y back");
            }
    }

    public static void OutsideTheMapHasNoTile()
    {
        var s = S();
        Assert.True(!s.TryTileOf(-0.01, 5, out _) && !s.TryTileOf(5, 100, out _) && !s.TryTileOf(150, 5, out _), "edges outside");
        Assert.True(s.TryTileOf(0, 0, out var nw) && nw.Equals(new TileIndex(0, 0)), "north-west corner is tile (0,0)");
        Assert.True(s.TryTileOf(149.99, 99.99, out var se) && se.Equals(new TileIndex(14, 9)), "south-east corner is the last tile");
        Assert.Throws<System.ArgumentOutOfRangeException>(() => s.TileLocalMetres(200, 5), "local position off the map");
        Assert.True(!s.Contains(double.NaN, 3), "NaN is not on the map");
    }

    public static void BadNumbersAreRefused()
    {
        var s = S();
        Assert.Throws<System.ArgumentException>(() => s.MapToMetres(double.NaN, 1), "NaN x");
        Assert.Throws<System.ArgumentException>(() => s.MetresToMap(1, double.PositiveInfinity), "infinite z");
        Assert.Throws<System.ArgumentException>(() => s.DistanceKm(0, 0, double.NaN, 0), "NaN distance");
        Assert.Throws<System.ArgumentException>(() => s.UnitsToKm(double.NaN), "NaN length");
        var bad = Raw(); bad.UnitKm = 0;
        Assert.Throws<System.ArgumentException>(() => new WorldScale(bad), "zero unit");
        bad = Raw(); bad.MapUnits = new[] { 150.0 };
        Assert.Throws<System.ArgumentException>(() => new WorldScale(bad), "one map dimension");
        bad = Raw(); bad.TerrainTileKm = -1;
        Assert.Throws<System.ArgumentException>(() => new WorldScale(bad), "negative tile");
        Assert.Throws<System.ArgumentNullException>(() => new WorldScale(null), "null data");
    }

    public static void ADifferentUnitScalesEverythingTogether()
    {
        // The helper decides nothing: if the user later picks another scale, only the data value changes.
        var d = Raw(); d.UnitKm = 0.5;
        var s = new WorldScale(d);
        Assert.Near(500, s.UnitsToMetres(1), 1e-9, "1 unit = 500 m");
        var m = s.MapToMetres(10, 20);
        Assert.Near(5000, m.X, 1e-9, "x"); Assert.Near(-10000, m.Z, 1e-9, "z");
        var back = s.MetresToMap(m.X, m.Z);
        Assert.Near(10, back.X, 1e-12, "x back"); Assert.Near(20, back.Y, 1e-12, "y back");
        Assert.Near(75, s.WidthKm, 1e-12, "the map is 75 km wide");
    }
}
