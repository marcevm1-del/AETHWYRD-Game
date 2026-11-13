using System;
using System.Collections.Generic;
using System.Linq;

namespace Ascend.Core
{
    // Map UI feed (12_Systems/world_graph.md "Map view"). Joins the region graph, what the player knows (MapKnowledge)
    // and region data into plain lists a UI can draw without knowing any of those systems. No engine types.

    public sealed class MapNodeView
    {
        public string Id { get; set; }
        /// <summary>Null while the land is Unknown: the map stays blank until it is heard of or visited.</summary>
        public string Name { get; set; }
        public MapStatus Status { get; set; }
        public int Ring { get; set; }
        public double[] At { get; set; }
        public string RankMin { get; set; }
        public string RankMax { get; set; }
        public bool Isle { get; set; }
        public bool Floating { get; set; }
        /// <summary>Dungeons in this land. Only filled once the land is Visited (a heard land hides its dungeons).</summary>
        public List<string> DungeonIds { get; set; } = new List<string>();
        public bool IsPlayerHere { get; set; }
    }

    public sealed class MapEdgeView
    {
        public string Id { get; set; }
        public string A { get; set; }
        public string B { get; set; }
        public string Kind { get; set; }
        public double Km { get; set; }
        public bool Foot { get; set; }
        /// <summary>True when the far end is not known yet: draw a stub that fades out rather than a full line.</summary>
        public bool Stub { get; set; }
    }

    public sealed class WorldMapView
    {
        public List<MapNodeView> Nodes { get; } = new List<MapNodeView>();
        public List<MapEdgeView> Edges { get; } = new List<MapEdgeView>();
    }

    public static class WorldMapViews
    {
        /// <summary>
        /// Builds what the World page draws. Unknown lands are listed (so the sheet keeps its shape) but nameless and without
        /// detail. A way is drawn when both ends are known (full line), or when exactly one end is Visited (a stub to the
        /// unknown). Ways between two lands the player has not been to, or only heard of, are left off.
        /// </summary>
        public static WorldMapView Build(RegionGraph graph, MapKnowledge knowledge, IReadOnlyDictionary<string, RegionData> regions,
            IEnumerable<DungeonData> dungeons = null, string playerRegion = null)
        {
            if (graph == null) throw new ArgumentNullException(nameof(graph));
            if (knowledge == null) throw new ArgumentNullException(nameof(knowledge));
            var view = new WorldMapView();
            var byRegion = (dungeons ?? Enumerable.Empty<DungeonData>()).GroupBy(d => d.RegionId).ToDictionary(g => g.Key, g => g.Select(d => d.Id).OrderBy(x => x, StringComparer.Ordinal).ToList());
            foreach (var n in graph.Nodes)
            {
                var st = knowledge.StatusOf(n.Id);
                RegionData r = null; regions?.TryGetValue(n.Id, out r);
                var v = new MapNodeView
                {
                    Id = n.Id, Status = st, Ring = n.Ring, At = n.At, Isle = n.Isle, Floating = n.Floating,
                    IsPlayerHere = n.Id == playerRegion,
                };
                if (st != MapStatus.Unknown) { v.Name = n.Name; v.RankMin = r?.RankMin; v.RankMax = r?.RankMax; }
                if (st == MapStatus.Visited && byRegion.TryGetValue(n.Id, out var ds)) v.DungeonIds = ds;
                view.Nodes.Add(v);
            }
            foreach (var e in graph.Edges)
            {
                var a = knowledge.StatusOf(e.A); var b = knowledge.StatusOf(e.B);
                bool aKnown = a != MapStatus.Unknown, bKnown = b != MapStatus.Unknown;
                bool full = aKnown && bKnown && (a == MapStatus.Visited || b == MapStatus.Visited);
                bool stub = !full && ((a == MapStatus.Visited && !bKnown) || (b == MapStatus.Visited && !aKnown));
                if (!full && !stub) continue;
                view.Edges.Add(new MapEdgeView { Id = e.Id, A = e.A, B = e.B, Kind = e.Kind, Km = e.Km, Foot = e.Foot, Stub = stub });
            }
            return view;
        }

        /// <summary>Walking distance in km between two lands over known ground only (both ends known, road/pass/border by foot).</summary>
        public static double? KnownRouteKm(RegionGraph graph, MapKnowledge knowledge, string from, string to)
        {
            if (graph == null || knowledge == null || !graph.Has(from) || !graph.Has(to)) return null;
            if (knowledge.StatusOf(from) == MapStatus.Unknown || knowledge.StatusOf(to) == MapStatus.Unknown) return null;
            var route = graph.ShortestPath(from, to, new TravelOptions { IncludeSea = false });
            if (route == null || route.Regions.Any(r => knowledge.StatusOf(r) == MapStatus.Unknown)) return null;
            return route.Km;
        }
    }
}
