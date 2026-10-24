using Ascend.Core;

[Tests]
static class WorldMapTests
{
    static WorldMapTerrain Terrain() => new WorldMapTerrain(Repo.Db.Regions.Values);

    public static void TheRandomMatchesTheAtlasBitForBit()
    {
        var r = new Mulberry32(1207);
        Assert.Near(0.09094201843254268, r.Next(), 1e-15, "first draw");
        Assert.Near(0.23204997787252069, r.Next(), 1e-15, "second draw");
        Assert.Near(0.7282224474474788, r.Next(), 1e-15, "third draw");
    }

    public static void TheNoiseMatchesTheAtlas()
    {
        var t = Terrain();
        Assert.Near(0.6480492968581538, t.Fbm(3.7, 9.2), 1e-9, "fbm");
        Assert.Near(0.4276544048776894, t.Fbm(120.5, 40.25, 5), 1e-9, "fbm 5 octaves");
        Assert.Near(0.1383083438405992, t.ValueNoise(10.3, 7.7), 1e-9, "value noise");
    }

    public static void TheCoastlineMatchesTheAtlas()
    {
        var t = Terrain();
        (double x, double y, double f, string id)[] golden =
        {
            (75, 58, 1.3758764682275797, "reg_whisperwood"), (72.6, 60, 1.59105145132952, "reg_whisperwood"),
            (20, 20, 0.9133458349187799, "reg_nox_dominion"), (5, 5, 0.023294179822299175, "reg_nox_dominion"),
            (130, 32, 0.6142917606179171, "reg_kitsune_isles"), (100, 50, 0.8118090427492674, "reg_hoshizora"),
            (66.3, 47.1, 1.4475699959352206, "reg_aldmere"),
        };
        foreach (var g in golden)
        {
            var (f, i) = t.Sample(g.x, g.y);
            Assert.Near(g.f, f, 1e-9, $"field at {g.x},{g.y}");
            Assert.Equal(g.id, t.Lands[i].Id, $"owner at {g.x},{g.y}");
        }
    }

    public static void EveryLandOwnsItsOwnAnchorAndTownsSitOnLand()
    {
        var t = Terrain();
        foreach (var r in t.Lands)
        {
            Assert.Equal(r.Id, t.RegionAt(r.Map.X, r.Map.Y)?.Id, $"{r.Id} anchor");
            foreach (var p in r.Map.Places) Assert.Equal(r.Id, t.RegionAt(p.Value[0], p.Value[1])?.Id, $"{r.Id}: {p.Key}");
        }
        Assert.Equal("reg_whisperwood", t.RegionAt(72.6, 60)?.Id, "Brindlewick is in Whisperwood");
        Assert.True(t.RegionAt(1, 1) == null && t.RegionAt(149, 99) == null, "the map's corners are sea");
    }

    public static void TheIslesAreIslands()
    {
        var t = Terrain();
        foreach (var r in t.Lands.Where(r => r.Map.Isle))
        {
            // Walk west from the isle's anchor: the sea comes before any other land does.
            string firstOther = null; bool sea = false;
            for (double x = r.Map.X; x > r.Map.X - 25 && firstOther == null; x -= .25)
            {
                var at = t.RegionAt(x, r.Map.Y);
                if (at == null) sea = true;
                else if (at.Id != r.Id) firstOther = at.Id;
            }
            Assert.True(sea, $"{r.Id} touches the mainland");
        }
    }

    public static void ThePainterIsDeterministicAndDrawsLandAndSea()
    {
        var t = Terrain();
        var a = WorldMapPainter.Paint(t, 300);
        var b = WorldMapPainter.Paint(t, 300);
        Assert.Equal(300, a.Width, "width"); Assert.Equal(200, a.Height, "height");
        Assert.True(a.Painted.SequenceEqual(b.Painted) && a.Parchment.SequenceEqual(b.Parchment), "same seed, same picture");
        int landPx = a.Land.Count(v => v >= 0);
        Assert.True(landPx > a.Land.Length * .35 && landPx < a.Land.Length * .85, $"land covers {landPx * 100 / a.Land.Length}% of the sheet");
        // The deep sea in a corner is darker and bluer than Whisperwood's forest.
        int corner = 2 * 4, wood = ((int)(58 * a.PixelsPerUnit) * a.Width + (int)(75 * a.PixelsPerUnit)) * 4;
        Assert.True(a.Painted[corner + 2] > a.Painted[corner], "sea is blue");
        Assert.True(a.Painted[wood + 1] > a.Painted[wood + 2], "the forest is green");
        Assert.True(a.Paper.Where((v, i) => i % 4 == 0).Average(v => v) > 150, "the blank sheet is light parchment");
    }

    public static void ThePngWriterWritesAValidHeader()
    {
        var png = MapPng.Encode(new byte[] { 255, 0, 0, 255, 0, 255, 0, 255 }, 2, 1);
        Assert.True(png.Take(8).SequenceEqual(new byte[] { 137, 80, 78, 71, 13, 10, 26, 10 }), "PNG signature");
        Assert.True(png.Length > 40, "has chunks");
    }

    static MapKnowledge Fresh() => new MapKnowledge(Repo.Db.World.Map, Repo.Db.Regions.Values);

    public static void TheMapStartsWithWhisperwoodInkedAndItsNeighboursPencilled()
    {
        var m = Fresh();
        Assert.Equal(MapStatus.Visited, m.StatusOf("reg_whisperwood"), "home");
        Assert.Equal(MapStatus.Heard, m.StatusOf("reg_aldmere"), "the capital everyone talks about");
        Assert.Equal(MapStatus.Unknown, m.StatusOf("reg_nox_dominion"), "the far north-west");
        Assert.True(!m.HasSystemOverlay(RankLetter.F) && m.HasSystemOverlay(RankLetter.E), "System overlay with the Rank E map seal");
    }

    public static void HearingNeverUndoesAVisitAndUnknownIdsAreIgnored()
    {
        var m = Fresh();
        Assert.True(!m.Hear("reg_whisperwood"), "already inked");
        Assert.Equal(MapStatus.Visited, m.StatusOf("reg_whisperwood"), "still inked");
        Assert.True(!m.Hear("reg_nowhere") && !m.Visit("reg_vesper"), "not on the map");
        Assert.True(m.Hear("reg_sylvaran") && m.Visit("reg_sylvaran"), "heard, then walked there");
    }

    public static void TheGuildMapNamesTheNextRingAtEachRank()
    {
        var m = Fresh();
        var atE = m.OnGuildRank(RankLetter.E);
        Assert.True(atE.Contains("reg_sylvaran") && atE.Contains("reg_lirian") && atE.Contains("reg_mossdeep"), "ring 3 named at E");
        Assert.True(!atE.Contains("reg_fanghold"), "ring 4 waits for D");
        Assert.True(m.OnGuildRank(RankLetter.E).Count == 0, "no news twice");
        Assert.True(m.OnGuildRank(RankLetter.D).Contains("reg_fanghold"), "ring 4 at D");
    }

    public static void TheLocalMapInksAsYouWalkAndRoundTrips()
    {
        var m = Fresh();
        var fog = m.Area("ring0_field", -100, -100, 200);
        Assert.Equal(50, fog.Cells, "4 m cells over 200 m");
        int first = fog.Reveal(0, 0, 14);
        Assert.True(first > 30 && first < 60, $"about π·14² / 16 cells ({first})");
        Assert.Equal(0, fog.Reveal(0, 0, 14), "standing still inks nothing new");
        Assert.True(fog.IsRevealedAt(5, 5) && !fog.IsRevealedAt(60, 60), "near is inked, far is blank");
        m.Visit("reg_greymoor");
        var save = m.Save();
        var back = Fresh();
        back.Load(save, id => id == "ring0_field" ? back.Area(id, -100, -100, 200) : null);
        Assert.Equal(MapStatus.Visited, back.StatusOf("reg_greymoor"), "regions restored");
        var fog2 = back.Area("ring0_field", -100, -100, 200);
        Assert.Equal(fog.RevealedCount, fog2.RevealedCount, "cells restored");
        Assert.True(fog2.IsRevealedAt(5, 5), "the same cells");
        fog2.Load("not base64!");
        Assert.Equal(fog.RevealedCount, fog2.RevealedCount, "a damaged grid is ignored");
    }
}
