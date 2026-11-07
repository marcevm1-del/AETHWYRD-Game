using System;
using System.Collections.Generic;
using System.Linq;

namespace Ascend.Core
{
    // Wave F-lite (upgrade v10 section 9.1): which surface regions join, and how far apart they are by road.
    // Data/World/region_graph.json is generated from physical_map.json and regions.json by
    // Tools/atlas/build_region_graph.js; nothing is invented. The graph is read only: the player's knowledge of the
    // map stays in MapKnowledge (Unknown / Heard / Visited). 12_Systems/world_graph.md.

    /// <summary>Plain model of Data/World/region_graph.json.</summary>
    public sealed class RegionGraphData
    {
        public int Version { get; set; }
        public RegionGraphSource Source { get; set; } = new RegionGraphSource();
        public RegionGraphScale Scale { get; set; } = new RegionGraphScale();
        public List<RegionGraphNode> Nodes { get; set; } = new List<RegionGraphNode>();
        public List<RegionGraphEdge> Edges { get; set; } = new List<RegionGraphEdge>();
        /// <summary>Waystone / portal edges. Empty today: Canon defines waystones only as respawn points.</summary>
        public List<RegionGraphEdge> Portals { get; set; } = new List<RegionGraphEdge>();
    }

    public sealed class RegionGraphSource { public string StartRegion { get; set; } }

    public sealed class RegionGraphScale
    {
        public double UnitKm { get; set; } = 1;
        public double PassLimitM { get; set; } = 2000;
        public double MinWalkBorderKm { get; set; } = 1;
    }

    public sealed class RegionGraphNode
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Ring { get; set; }
        public double[] At { get; set; }
        public bool Isle { get; set; }
        public bool Floating { get; set; }
    }

    public sealed class RegionGraphEdge
    {
        public string Id { get; set; }
        public string A { get; set; }
        public string B { get; set; }
        /// <summary>road, pass, sea or border.</summary>
        public string Kind { get; set; }
        public double Km { get; set; }
        /// <summary>road_length, corridor_leg or anchor_straight_line.</summary>
        public string KmBasis { get; set; }
        /// <summary>Can be walked (a sea leg is sailed, so it is false here and allowed by <see cref="TravelOptions.IncludeSea"/>).</summary>
        public bool Foot { get; set; }
        public string RoadId { get; set; }
        public string CorridorId { get; set; }
        public string PassId { get; set; }
        public string PassName { get; set; }
        public double PassM { get; set; }
        public List<string> Via { get; set; }
        public int RiverCrossings { get; set; }
        public double WidestCrossingM { get; set; }
        public double BorderKm { get; set; }
        public double LowestCrossingM { get; set; }

        public string Other(string regionId) => regionId == A ? B : A;
    }

    /// <summary>What a journey may use.</summary>
    public sealed class TravelOptions
    {
        /// <summary>Sailed legs count (the Naming Voyage). Default true.</summary>
        public bool IncludeSea { get; set; } = true;
        /// <summary>Only roads, passes and sea legs: no cross-country borders. Default false.</summary>
        public bool RoadsOnly { get; set; }
    }

    /// <summary>A found route: the regions in order, the edges between them and the total km.</summary>
    public sealed class RegionRoute
    {
        public List<string> Regions { get; } = new List<string>();
        public List<RegionGraphEdge> Edges { get; } = new List<RegionGraphEdge>();
        public double Km { get; set; }
    }

    public sealed class RegionGraph
    {
        readonly Dictionary<string, RegionGraphNode> _nodes;
        readonly Dictionary<string, List<RegionGraphEdge>> _adj = new Dictionary<string, List<RegionGraphEdge>>();

        public RegionGraphData Data { get; }
        public IReadOnlyList<RegionGraphNode> Nodes => Data.Nodes;
        public IReadOnlyList<RegionGraphEdge> Edges => Data.Edges;
        /// <summary>The surface regions the graph covers (Canon: 40; regions.json also holds 8 underworld rows and Vesper).</summary>
        public int SurfaceRegionCount => Data.Nodes.Count;
        public string StartRegion => Data.Source.StartRegion;

        public RegionGraph(RegionGraphData data)
        {
            Data = data ?? throw new ArgumentNullException(nameof(data));
            _nodes = new Dictionary<string, RegionGraphNode>();
            foreach (var n in data.Nodes)
            {
                if (n?.Id == null || _nodes.ContainsKey(n.Id)) throw new ArgumentException("duplicate or missing node id " + n?.Id);
                _nodes[n.Id] = n; _adj[n.Id] = new List<RegionGraphEdge>();
            }
            foreach (var e in data.Edges.Concat(data.Portals ?? new List<RegionGraphEdge>()))
            {
                if (e == null || !_nodes.ContainsKey(e.A ?? "") || !_nodes.ContainsKey(e.B ?? "")) throw new ArgumentException("edge " + e?.Id + " has an unknown end");
                if (e.Km < 0 || double.IsNaN(e.Km)) throw new ArgumentException("edge " + e.Id + " has a bad length");
                _adj[e.A].Add(e); _adj[e.B].Add(e);
            }
        }

        public bool Has(string regionId) => regionId != null && _nodes.ContainsKey(regionId);
        public RegionGraphNode Node(string regionId) => regionId != null && _nodes.TryGetValue(regionId, out var n) ? n : null;

        /// <summary>Can this edge be travelled under the options?</summary>
        public static bool CanTravel(RegionGraphEdge e, TravelOptions o)
        {
            o = o ?? new TravelOptions();
            if (e.Kind == "sea") return o.IncludeSea;
            if (!e.Foot) return false;
            if (o.RoadsOnly && e.Kind == "border") return false;
            return true;
        }

        /// <summary>All edges touching a region (any kind).</summary>
        public IReadOnlyList<RegionGraphEdge> EdgesOf(string regionId) => regionId != null && _adj.TryGetValue(regionId, out var l) ? l : (IReadOnlyList<RegionGraphEdge>)new List<RegionGraphEdge>();

        /// <summary>Regions one step away under the options, nearest first (ties by id).</summary>
        public List<string> Neighbours(string regionId, TravelOptions o = null) =>
            EdgesOf(regionId).Where(e => CanTravel(e, o)).GroupBy(e => e.Other(regionId))
                .Select(g => new { Id = g.Key, Km = g.Min(e => e.Km) }).OrderBy(x => x.Km).ThenBy(x => x.Id, StringComparer.Ordinal).Select(x => x.Id).ToList();

        /// <summary>Every region reachable from <paramref name="from"/> (itself included), or empty if it is not in the graph.</summary>
        public HashSet<string> Reachable(string from, TravelOptions o = null)
        {
            var seen = new HashSet<string>();
            if (!Has(from)) return seen;
            var stack = new Stack<string>(); stack.Push(from); seen.Add(from);
            while (stack.Count > 0)
            {
                var c = stack.Pop();
                foreach (var e in _adj[c]) if (CanTravel(e, o) && seen.Add(e.Other(c))) stack.Push(e.Other(c));
            }
            return seen;
        }

        /// <summary>Regions with no travellable edge at all (orphans), in data order.</summary>
        public List<string> Orphans(TravelOptions o = null) =>
            Data.Nodes.Where(n => !_adj[n.Id].Any(e => CanTravel(e, o))).Select(n => n.Id).ToList();

        /// <summary>Regions that cannot be reached from <paramref name="from"/> (defaults to the start region), in data order.</summary>
        public List<string> Unreachable(string from = null, TravelOptions o = null)
        {
            var r = Reachable(from ?? StartRegion, o);
            return Data.Nodes.Where(n => !r.Contains(n.Id)).Select(n => n.Id).ToList();
        }

        /// <summary>The connected groups of regions under the options, largest first.</summary>
        public List<List<string>> Components(TravelOptions o = null)
        {
            var left = new HashSet<string>(Data.Nodes.Select(n => n.Id));
            var result = new List<List<string>>();
            foreach (var n in Data.Nodes)
            {
                if (!left.Contains(n.Id)) continue;
                var comp = Reachable(n.Id, o);
                left.ExceptWith(comp);
                result.Add(Data.Nodes.Where(x => comp.Contains(x.Id)).Select(x => x.Id).ToList());
            }
            return result.OrderByDescending(c => c.Count).ToList();
        }

        /// <summary>Shortest route by km (Dijkstra). Null when either region is unknown or no route exists.</summary>
        public RegionRoute ShortestPath(string from, string to, TravelOptions o = null)
        {
            if (!Has(from) || !Has(to)) return null;
            var dist = _nodes.Keys.ToDictionary(k => k, _ => double.PositiveInfinity);
            var prev = new Dictionary<string, RegionGraphEdge>();
            var done = new HashSet<string>();
            dist[from] = 0;
            while (true)
            {
                string cur = null; double best = double.PositiveInfinity;
                foreach (var kv in dist)
                    if (!done.Contains(kv.Key) && (kv.Value < best || (kv.Value == best && cur != null && string.CompareOrdinal(kv.Key, cur) < 0))) { best = kv.Value; cur = kv.Key; }
                if (cur == null || double.IsPositiveInfinity(best)) break;
                if (cur == to) break;
                done.Add(cur);
                foreach (var e in _adj[cur])
                {
                    if (!CanTravel(e, o)) continue;
                    var nx = e.Other(cur); var nd = best + e.Km;
                    if (nd < dist[nx]) { dist[nx] = nd; prev[nx] = e; }
                }
            }
            if (double.IsPositiveInfinity(dist[to])) return null;
            var route = new RegionRoute { Km = Math.Round(dist[to], 3) };
            var at = to; route.Regions.Add(at);
            while (at != from) { var e = prev[at]; route.Edges.Add(e); at = e.Other(at); route.Regions.Add(at); }
            route.Regions.Reverse(); route.Edges.Reverse();
            return route;
        }
    }
}
