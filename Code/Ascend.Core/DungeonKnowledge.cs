using System.Collections.Generic;
using System.Linq;

namespace Ascend.Core
{
    // Wave E secrets and clue record, in the map-knowledge style (Canon: Unknown / Heard / Visited).
    // Rooms and clues are Unknown (blank), Heard (a rumour pencilled them in) or Visited (found in place).
    // Hearing never downgrades a visit.

    /// <summary>What a save keeps of one dungeon.</summary>
    public sealed class DungeonProgressSave
    {
        public Dictionary<string, MapStatus> Rooms { get; set; } = new Dictionary<string, MapStatus>();
        public Dictionary<string, MapStatus> Clues { get; set; } = new Dictionary<string, MapStatus>();
        /// <summary>The boss has fallen at least once (the journal remembers; the halls still reset).</summary>
        public bool Cleared { get; set; }
    }

    /// <summary>SaveGame.Dungeons. Null in older saves; the loader null-coalesces it.</summary>
    public sealed class DungeonSave
    {
        public Dictionary<string, DungeonProgressSave> Dungeons { get; set; } = new Dictionary<string, DungeonProgressSave>();
    }

    public sealed class DungeonKnowledge
    {
        readonly DungeonData _d;
        readonly Dictionary<string, MapStatus> _rooms = new Dictionary<string, MapStatus>();
        readonly Dictionary<string, MapStatus> _clues = new Dictionary<string, MapStatus>();

        public bool Cleared { get; set; }

        public DungeonKnowledge(DungeonData dungeon) { _d = dungeon; }

        public MapStatus StatusOfRoom(string roomId) => roomId != null && _rooms.TryGetValue(roomId, out var s) ? s : MapStatus.Unknown;
        public MapStatus StatusOfClue(string clueId) => clueId != null && _clues.TryGetValue(clueId, out var s) ? s : MapStatus.Unknown;
        public IEnumerable<string> VisitedRooms => _rooms.Where(kv => kv.Value == MapStatus.Visited).Select(kv => kv.Key);
        public IEnumerable<string> FoundClues => _clues.Where(kv => kv.Value == MapStatus.Visited).Select(kv => kv.Key);

        /// <summary>Inks a room; returns true if it was not inked before.</summary>
        public bool VisitRoom(string roomId)
        {
            if (_d.RoomById(roomId) == null || StatusOfRoom(roomId) == MapStatus.Visited) return false;
            _rooms[roomId] = MapStatus.Visited;
            return true;
        }

        /// <summary>A rumour pencils a room in; returns true if it was blank before.</summary>
        public bool HearRoom(string roomId)
        {
            if (_d.RoomById(roomId) == null || StatusOfRoom(roomId) != MapStatus.Unknown) return false;
            _rooms[roomId] = MapStatus.Heard;
            return true;
        }

        /// <summary>
        /// A rumour of a clue (its "heard" line). Pencils the clue, and the secret room it points at, but reveals nothing:
        /// a hidden way opens only when the clue is found in place.
        /// </summary>
        public bool HearClue(string clueId)
        {
            var cl = _d.Clues.FirstOrDefault(c => c.Id == clueId);
            if (cl == null || StatusOfClue(clueId) != MapStatus.Unknown) return false;
            _clues[clueId] = MapStatus.Heard;
            var way = _d.Connections.FirstOrDefault(c => c.Id == cl.Reveals);
            if (way != null && (_d.RoomById(way.To)?.Secret ?? false)) HearRoom(way.To);
            else if (way != null && (_d.RoomById(way.From)?.Secret ?? false)) HearRoom(way.From);
            return true;
        }

        /// <summary>Finds a clue in place; returns true if it was not found before. This is what reveals a hidden way.</summary>
        public bool VisitClue(string clueId)
        {
            if (_d.Clues.All(c => c.Id != clueId) || StatusOfClue(clueId) == MapStatus.Visited) return false;
            _clues[clueId] = MapStatus.Visited;
            return true;
        }

        public bool IsRevealed(DungeonConnection c) => c.RevealedByClue == null || StatusOfClue(c.RevealedByClue) == MapStatus.Visited;

        public DungeonProgressSave Save() => new DungeonProgressSave
        {
            Rooms = new Dictionary<string, MapStatus>(_rooms),
            Clues = new Dictionary<string, MapStatus>(_clues),
            Cleared = Cleared,
        };

        /// <summary>Restores a save. Null (an older save) changes nothing; ids the data no longer has are ignored; a visit is never downgraded.</summary>
        public void Load(DungeonProgressSave save)
        {
            if (save == null) return;
            foreach (var kv in save.Rooms ?? new Dictionary<string, MapStatus>())
            {
                if (kv.Value == MapStatus.Visited) VisitRoom(kv.Key);
                else if (kv.Value == MapStatus.Heard) HearRoom(kv.Key);
            }
            foreach (var kv in save.Clues ?? new Dictionary<string, MapStatus>())
            {
                if (kv.Value == MapStatus.Visited) VisitClue(kv.Key);
                else if (kv.Value == MapStatus.Heard) HearClue(kv.Key);
            }
            Cleared = Cleared || save.Cleared;
        }
    }
}
