using Ascend.Core;

// Not a test: writes the painted, parchment and blank-paper world maps as PNGs when run with ASCEND_MAP=<folder>
// (optional ASCEND_MAP_WIDTH, default 2400). Used for the review canvas and the atlas.
static class MapRender
{
    public static void RenderIfAsked()
    {
        var dir = Environment.GetEnvironmentVariable("ASCEND_MAP");
        if (string.IsNullOrEmpty(dir)) return;
        int width = int.TryParse(Environment.GetEnvironmentVariable("ASCEND_MAP_WIDTH"), out var w) ? w : 2400;
        var watch = System.Diagnostics.Stopwatch.StartNew();
        var img = WorldMapPainter.Paint(new WorldMapTerrain(Repo.Db.Regions.Values), width);
        Directory.CreateDirectory(dir);
        File.WriteAllBytes(Path.Combine(dir, "world_map_painted.png"), MapPng.Encode(img.Painted, img.Width, img.Height));
        File.WriteAllBytes(Path.Combine(dir, "world_map_parchment.png"), MapPng.Encode(img.Parchment, img.Width, img.Height));
        File.WriteAllBytes(Path.Combine(dir, "world_map_paper.png"), MapPng.Encode(img.Paper, img.Width, img.Height));
        Console.WriteLine($"world map {img.Width}x{img.Height} painted in {watch.ElapsedMilliseconds} ms → {dir}");
    }
}
