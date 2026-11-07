using System;
using System.Collections.Generic;
using System.Linq;

namespace Ascend.Core
{
    // Wave E dungeon layouts (12_Systems/dungeons_and_puzzles.md). Data: Data/World/dungeons.json.
    // Canon: dungeon cores are never allies, dungeons stay reusable, puzzles are never a mandatory gate.

    public sealed class DungeonSpawn
    {
        public string SpeciesId { get; set; }
        public int Min { get; set; }
        public int Max { get; set; } = 1;
    }

    public sealed class BossSlot { public string SpeciesId { get; set; } }

    public sealed class DungeonRoom
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; } = 1;
        public string Role { get; set; }
        public bool Checkpoint { get; set; }
        public bool Secret { get; set; }
        public List<DungeonSpawn> Spawns { get; set; } = new List<DungeonSpawn>();
        public BossSlot Boss { get; set; }
        public List<string> Keys { get; set; } = new List<string>();
        public List<string> Puzzles { get; set; } = new List<string>();
    }

    public sealed class DungeonConnection
    {
        public string Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        /// <summary>passage, stairs, door, secret or shortcut.</summary>
        public string Kind { get; set; }
        public bool OneWay { get; set; }
        public string RequiresKey { get; set; }
        /// <summary>Opens only once this (optional) puzzle is solved. Legal only where another way already joins the two rooms.</summary>
        public string RequiresPuzzle { get; set; }
        /// <summary>Hidden until this clue has been found in place (status Visited).</summary>
        public string RevealedByClue { get; set; }

        /// <summary>Anything the player may skip: a puzzle reward path or a hidden passage.</summary>
        public bool IsOptionalWay => RequiresPuzzle != null || RevealedByClue != null || Kind == "secret";
    }

    public sealed class DungeonClue
    {
        public string Id { get; set; }
        public string RoomId { get; set; }
        /// <summary>lever, secret or lore.</summary>
        public string Kind { get; set; }
        public string Text { get; set; }
        /// <summary>What a rumour says before the clue is found in place (makes the clue Heard).</summary>
        public string Heard { get; set; }
        /// <summary>The puzzle or connection this clue points at.</summary>
        public string Reveals { get; set; }
    }

    public sealed class DungeonData
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Theme { get; set; }
        public string Summary { get; set; }
        public string RegionId { get; set; }
        public List<int> Floors { get; set; } = new List<int>();
        public string RecommendedRank { get; set; }
        public bool Reusable { get; set; } = true;
        public bool CoreIsAlly { get; set; }
        public string EntryRoom { get; set; }
        public List<DungeonRoom> Rooms { get; set; } = new List<DungeonRoom>();
        public List<DungeonConnection> Connections { get; set; } = new List<DungeonConnection>();
        public List<DungeonClue> Clues { get; set; } = new List<DungeonClue>();

        public DungeonRoom RoomById(string id) => Rooms.FirstOrDefault(r => r.Id == id);
    }

    /// <summary>A place in the key-state search: a room and the keys held on arrival (keys are never used up).</summary>
    public sealed class DungeonState
    {
        public string Room { get; }
        public IReadOnlyCollection<string> Keys { get; }
        public DungeonState(string room, IEnumerable<string> keys) { Room = room; Keys = new SortedSet<string>(keys, StringComparer.Ordinal); }
        public string Key => Room + "|" + string.Join(",", Keys);
    }

    public static class DungeonRules
    {
        static IEnumerable<(DungeonConnection c, string from, string to)> Edges(DungeonData d)
        {
            foreach (var c in d.Connections)
            {
                yield return (c, c.From, c.To);
                if (!c.OneWay) yield return (c, c.To, c.From);
            }
        }

        static DungeonState Arrive(DungeonData d, string room, IEnumerable<string> keys) =>
            new DungeonState(room, keys.Concat(d.RoomById(room)?.Keys ?? new List<string>()));

        /// <summary>
        /// Every (room, keys) state reachable from the entry (or from <paramref name="from"/>). Keys are picked up on arrival
        /// and never used up, so doors stay open. With <paramref name="includeOptional"/> false the search ignores every
        /// puzzle-gated and secret connection: the world as a player who skips all optional content sees it.
        /// </summary>
        public static Dictionary<string, DungeonState> Explore(DungeonData d, bool includeOptional, DungeonState from = null)
        {
            var start = from ?? Arrive(d, d.EntryRoom, new string[0]);
            var seen = new Dictionary<string, DungeonState> { [start.Key] = start };
            var q = new Queue<DungeonState>(); q.Enqueue(start);
            var edges = Edges(d).ToList();
            while (q.Count > 0)
            {
                var s = q.Dequeue();
                foreach (var e in edges)
                {
                    if (e.from != s.Room) continue;
                    if (e.c.RequiresKey != null && !s.Keys.Contains(e.c.RequiresKey)) continue;
                    if (!includeOptional && e.c.IsOptionalWay) continue;
                    var n = Arrive(d, e.to, s.Keys);
                    if (seen.ContainsKey(n.Key)) continue;
                    seen[n.Key] = n; q.Enqueue(n);
                }
            }
            return seen;
        }

        public static HashSet<string> ReachableRooms(DungeonData d, bool includeOptional) =>
            new HashSet<string>(Explore(d, includeOptional).Values.Select(s => s.Room));

        public static bool CanReach(DungeonData d, DungeonState from, bool includeOptional, string room) =>
            Explore(d, includeOptional, from).Values.Any(s => s.Room == room);

        /// <summary>States from which the player can no longer get back to the entry (the way out) or reach the boss room.</summary>
        public static List<string> SoftLocks(DungeonData d, bool includeOptional)
        {
            var bad = new List<string>();
            var boss = d.Rooms.FirstOrDefault(r => r.Boss != null);
            foreach (var s in Explore(d, includeOptional).Values)
            {
                if (!CanReach(d, s, includeOptional, d.EntryRoom)) bad.Add($"in {s.Room} holding [{string.Join(",", s.Keys)}] the player cannot get back to the entry");
                else if (boss != null && !CanReach(d, s, includeOptional, boss.Id)) bad.Add($"in {s.Room} holding [{string.Join(",", s.Keys)}] the player cannot reach the boss room");
            }
            return bad;
        }

        /// <summary>
        /// Checks a layout against the game data and Canon. Returns the problems; empty means the dungeon is sound:
        /// real species of the region, a boss slot, reachable rooms, keys found before their doors, no soft-lock, and nothing
        /// optional on the way to the boss (a puzzle or secret is never the only way on).
        /// </summary>
        public static List<string> Validate(DungeonData d, GameDatabase db, PuzzleFile puzzles = null)
        {
            var errors = new List<string>();
            if (d == null) { errors.Add("no dungeon"); return errors; }
            string w = d.Id ?? "dungeon";
            if (!d.Reusable) errors.Add($"{w}: dungeons stay reusable (Canon)");
            if (d.CoreIsAlly) errors.Add($"{w}: dungeon cores are never allies (Canon)");
            RegionData region = null;
            if (db != null && !db.Regions.TryGetValue(d.RegionId ?? "", out region)) errors.Add($"{w}: unknown region \"{d.RegionId}\"");
            if (d.RoomById(d.EntryRoom) == null) { errors.Add($"{w}: entry room \"{d.EntryRoom}\" is not a room"); return errors; }
            if (!d.RoomById(d.EntryRoom).Checkpoint) errors.Add($"{w}: the entry room must be a checkpoint");
            var ids = new HashSet<string>();
            foreach (var r in d.Rooms) if (!ids.Add(r.Id)) errors.Add($"{w}: duplicate room \"{r.Id}\"");
            var puzzleIds = new HashSet<string>(puzzles?.Puzzles.Select(p => p.Id) ?? Enumerable.Empty<string>());
            var allKeys = new HashSet<string>(d.Rooms.SelectMany(r => r.Keys));
            var clueIds = new HashSet<string>(d.Clues.Select(c => c.Id));
            var connIds = new HashSet<string>();

            foreach (var r in d.Rooms)
            {
                foreach (var sp in r.Spawns) CheckSpecies(sp.SpeciesId, r, db, region, d, errors);
                if (r.Boss != null) CheckSpecies(r.Boss.SpeciesId, r, db, region, d, errors);
                if (r.Role == "boss" && r.Boss == null) errors.Add($"{w}.{r.Id}: a boss room needs a boss slot");
                if (r.Boss != null && r.Role != "boss") errors.Add($"{w}.{r.Id}: a boss slot needs role \"boss\"");
                if (r.Boss != null && r.Keys.Count > 0) errors.Add($"{w}.{r.Id}: a boss room holds no keys");
                if (r.Secret && (r.Keys.Count > 0 || r.Boss != null)) errors.Add($"{w}.{r.Id}: a secret room holds no key and no boss");
                if (puzzles != null) foreach (var p in r.Puzzles) if (!puzzleIds.Contains(p)) errors.Add($"{w}.{r.Id}: unknown puzzle \"{p}\"");
            }
            foreach (var c in d.Connections)
            {
                if (!connIds.Add(c.Id)) errors.Add($"{w}: duplicate connection \"{c.Id}\"");
                if (d.RoomById(c.From) == null || d.RoomById(c.To) == null) errors.Add($"{w}.{c.Id}: connects an unknown room");
                if (c.From == c.To) errors.Add($"{w}.{c.Id}: connects a room to itself");
                if (c.RequiresKey != null && !allKeys.Contains(c.RequiresKey)) errors.Add($"{w}.{c.Id}: key \"{c.RequiresKey}\" is never found in this dungeon");
                if (c.RequiresPuzzle != null && !d.Rooms.Any(r => r.Puzzles.Contains(c.RequiresPuzzle))) errors.Add($"{w}.{c.Id}: puzzle \"{c.RequiresPuzzle}\" is not in any room of this dungeon");
                if (c.RevealedByClue != null && !clueIds.Contains(c.RevealedByClue)) errors.Add($"{w}.{c.Id}: unknown clue \"{c.RevealedByClue}\"");
                if (c.Kind == "secret" && c.RevealedByClue == null) errors.Add($"{w}.{c.Id}: a secret connection needs revealedByClue");
            }
            foreach (var cl in d.Clues)
            {
                if (d.RoomById(cl.RoomId) == null) errors.Add($"{w}.{cl.Id}: clue in unknown room \"{cl.RoomId}\"");
                if (cl.Reveals != null && !puzzleIds.Contains(cl.Reveals) && !connIds.Contains(cl.Reveals)) errors.Add($"{w}.{cl.Id}: reveals unknown puzzle or connection \"{cl.Reveals}\"");
            }
            if (errors.Count > 0) return errors; // the graph checks need sound references

            // Canon: nothing optional may be mandatory.
            var required = ReachableRooms(d, false);
            var everything = ReachableRooms(d, true);
            foreach (var r in d.Rooms)
            {
                if (!everything.Contains(r.Id)) errors.Add($"{w}.{r.Id}: cannot be reached even with every puzzle solved and every secret found");
                else if (!required.Contains(r.Id) && !r.Secret) errors.Add($"{w}.{r.Id}: reachable only through a puzzle or secret but not marked secret (optional content must not hide a required room)");
                if (r.Secret && required.Contains(r.Id)) errors.Add($"{w}.{r.Id}: marked secret but reachable without finding the secret");
                if (r.Boss != null && !required.Contains(r.Id)) errors.Add($"{w}.{r.Id}: the boss room must be reachable without any puzzle or secret");
            }
            foreach (var c in d.Connections.Where(c => c.IsOptionalWay))
            {
                bool bothRequired = required.Contains(c.From) && required.Contains(c.To);
                bool leadsToSecret = (d.RoomById(c.To)?.Secret ?? false) || (d.RoomById(c.From)?.Secret ?? false);
                if (!bothRequired && !leadsToSecret) errors.Add($"{w}.{c.Id}: a puzzle-gated way leads somewhere the player cannot otherwise reach (a puzzle must never be the only way on)");
            }
            foreach (var p in d.Rooms.SelectMany(r => r.Puzzles).GroupBy(x => x).Where(g => g.Count() > 1)) errors.Add($"{w}: puzzle \"{p.Key}\" is placed in more than one room");
            foreach (var s in SoftLocks(d, false)) errors.Add($"{w}: soft-lock on the required path: {s}");
            foreach (var s in SoftLocks(d, true)) errors.Add($"{w}: soft-lock with everything open: {s}");
            return errors;
        }

        static void CheckSpecies(string id, DungeonRoom r, GameDatabase db, RegionData region, DungeonData d, List<string> errors)
        {
            if (db == null) return;
            if (!db.Species.TryGetValue(id ?? "", out var sp)) { errors.Add($"{d.Id}.{r.Id}: unknown species \"{id}\""); return; }
            if (!sp.Habitats.Contains(d.RegionId)) errors.Add($"{d.Id}.{r.Id}: {id} does not live in {d.RegionId}");
            if (region != null && Rank.TryParse(sp.Rank, out var sr) && Rank.TryParse(region.RankMax, out var cap) && sr > cap)
                errors.Add($"{d.Id}.{r.Id}: {id} ({sp.Rank}) is above the region's top rank {region.RankMax}");
        }
    }

    /// <summary>
    /// One visit to a dungeon: where the player is, keys held, checkpoint, puzzles and what they know. Movement obeys the
    /// layout; dying returns to the last checkpoint and loses nothing (Canon §5). Reset() is the weekly hall reset.
    /// </summary>
    public sealed class DungeonRun
    {
        readonly Dictionary<string, Puzzle> _puzzles = new Dictionary<string, Puzzle>();
        readonly HashSet<string> _keys = new HashSet<string>();

        public DungeonData Layout { get; }
        public DungeonKnowledge Knowledge { get; }
        public string Room { get; private set; }
        public string Checkpoint { get; private set; }
        public bool BossDefeated { get; private set; }
        public IReadOnlyCollection<string> Keys => _keys;

        public DungeonRun(DungeonData layout, PuzzleFile puzzles = null, DungeonKnowledge knowledge = null)
        {
            Layout = layout ?? throw new ArgumentNullException(nameof(layout));
            Knowledge = knowledge ?? new DungeonKnowledge(layout);
            foreach (var id in layout.Rooms.SelectMany(r => r.Puzzles))
            {
                var data = puzzles?.Puzzles.FirstOrDefault(p => p.Id == id);
                if (data != null) _puzzles[id] = Puzzle.Create(data, puzzles.Tuning);
            }
            Reset();
        }

        public Puzzle PuzzleById(string id) => id != null && _puzzles.TryGetValue(id, out var p) ? p : null;
        public IEnumerable<Puzzle> Puzzles => _puzzles.Values;
        public bool CanLeave => Room == Layout.EntryRoom;

        /// <summary>Back to the entrance with the halls reset: keys gone, puzzles reset, boss standing again. What the player learned stays.</summary>
        public void Reset()
        {
            _keys.Clear(); BossDefeated = false;
            foreach (var p in _puzzles.Values) p.Reset();
            Room = Layout.EntryRoom; Checkpoint = Layout.EntryRoom;
            Knowledge.VisitRoom(Room);
        }

        /// <summary>Whether a connection is passable and, if not, why.</summary>
        public bool IsOpen(DungeonConnection c, out string why)
        {
            why = null;
            if (c.RevealedByClue != null && Knowledge.StatusOfClue(c.RevealedByClue) != MapStatus.Visited) { why = "hidden"; return false; }
            if (c.RequiresKey != null && !_keys.Contains(c.RequiresKey)) { why = "locked"; return false; }
            if (c.RequiresPuzzle != null && PuzzleById(c.RequiresPuzzle)?.Status != PuzzleStatus.Solved) { why = "mechanism idle"; return false; }
            return true;
        }

        /// <summary>The ways out of the current room the player can see (hidden secrets are left out), open or not.</summary>
        public IEnumerable<DungeonConnection> ExitsHere() =>
            Layout.Connections.Where(c => (c.From == Room || (!c.OneWay && c.To == Room)) && (c.RevealedByClue == null || Knowledge.StatusOfClue(c.RevealedByClue) == MapStatus.Visited));

        public bool Move(string connectionId, out string why)
        {
            why = null;
            var c = Layout.Connections.FirstOrDefault(x => x.Id == connectionId);
            if (c == null) { why = "no such way"; return false; }
            string dest = c.From == Room ? c.To : (!c.OneWay && c.To == Room ? c.From : null);
            if (dest == null) { why = "not here"; return false; }
            if (!IsOpen(c, out why)) return false;
            Room = dest;
            Knowledge.VisitRoom(dest);
            if (Layout.RoomById(dest).Checkpoint) Checkpoint = dest;
            return true;
        }

        /// <summary>Picks up a key lying in the current room.</summary>
        public bool TakeKey(string keyId)
        {
            if (keyId == null || !Layout.RoomById(Room).Keys.Contains(keyId)) return false;
            return _keys.Add(keyId);
        }

        /// <summary>Finds a clue lying in the current room.</summary>
        public bool FindClue(string clueId)
        {
            var cl = Layout.Clues.FirstOrDefault(c => c.Id == clueId);
            return cl != null && cl.RoomId == Room && Knowledge.VisitClue(clueId);
        }

        public bool DefeatBoss()
        {
            if (Layout.RoomById(Room).Boss == null || BossDefeated) return false;
            BossDefeated = true;
            return true;
        }

        /// <summary>Falls in battle: back at the last checkpoint with every key and solved puzzle kept. Returns the room.</summary>
        public string Die()
        {
            Room = Checkpoint;
            return Room;
        }
    }
}
