using System;
using System.Collections.Generic;
using System.Linq;

namespace Ascend.Core
{
    // Dungeon loader, host side of the Core rules (12_Systems/dungeons_and_puzzles.md section 6a).
    // The planner turns a layout into "what stands in each room this visit"; the snapshot lets a run survive quitting.

    public sealed class PlannedSpawn
    {
        public string RoomId { get; set; }
        public string SpeciesId { get; set; }
        public bool IsBoss { get; set; }
        /// <summary>Slot index inside the room, so a host can map it to a spawn marker.</summary>
        public int Slot { get; set; }
    }

    public static class DungeonPlanner
    {
        /// <summary>
        /// Which monsters stand in each room for one visit. Deterministic from the world seed, the dungeon and the reset
        /// counter (weekly hall reset), so a save/reload shows the same halls and a new week shows new counts.
        /// Boss rooms always hold their boss; secret and empty rooms hold only what their data lists.
        /// </summary>
        public static List<PlannedSpawn> Plan(DungeonData d, ulong worldSeed, int resetCount)
        {
            if (d == null) throw new ArgumentNullException(nameof(d));
            var list = new List<PlannedSpawn>();
            foreach (var room in d.Rooms)
            {
                var rng = DeterministicRandom.For(worldSeed, "dungeon", d.Id, room.Id, resetCount);
                int slot = 0;
                foreach (var sp in room.Spawns)
                {
                    int lo = Math.Max(0, sp.Min), hi = Math.Max(lo, sp.Max);
                    int n = rng.Next(lo, hi + 1);
                    for (int i = 0; i < n; i++) list.Add(new PlannedSpawn { RoomId = room.Id, SpeciesId = sp.SpeciesId, Slot = slot++ });
                }
                if (room.Boss != null) list.Add(new PlannedSpawn { RoomId = room.Id, SpeciesId = room.Boss.SpeciesId, IsBoss = true, Slot = slot++ });
            }
            return list;
        }
    }

    public sealed class PuzzleOutcomeSave
    {
        public string Id { get; set; }
        public string Status { get; set; }
        public bool RewardClaimed { get; set; }
    }

    /// <summary>A dungeon run frozen for saving. Every field defaults safely, so an older save (or no snapshot) restores nothing.</summary>
    public sealed class DungeonRunSnapshot
    {
        public string DungeonId { get; set; }
        public string Room { get; set; }
        public string Checkpoint { get; set; }
        public bool BossDefeated { get; set; }
        public int ResetCount { get; set; }
        public List<string> Keys { get; set; } = new List<string>();
        public List<PuzzleOutcomeSave> Puzzles { get; set; } = new List<PuzzleOutcomeSave>();
    }

    public static class DungeonRunSnapshots
    {
        public static DungeonRunSnapshot Capture(DungeonRun run, int resetCount)
        {
            if (run == null) throw new ArgumentNullException(nameof(run));
            return new DungeonRunSnapshot
            {
                DungeonId = run.Layout.Id, Room = run.Room, Checkpoint = run.Checkpoint, BossDefeated = run.BossDefeated, ResetCount = resetCount,
                Keys = run.Keys.OrderBy(k => k, StringComparer.Ordinal).ToList(),
                Puzzles = run.Puzzles.Where(p => p.Status != PuzzleStatus.Unsolved)
                    .Select(p => new PuzzleOutcomeSave { Id = p.Id, Status = p.Status.ToString(), RewardClaimed = p.RewardClaimed }).ToList(),
            };
        }

        /// <summary>
        /// Puts a run back as saved. Ignores anything the data no longer has and returns false (leaving a fresh run) when the
        /// snapshot is null or for another dungeon. Keys are only restored if the layout still has them.
        /// </summary>
        public static bool Restore(DungeonRun run, DungeonRunSnapshot s)
        {
            if (run == null) throw new ArgumentNullException(nameof(run));
            if (s == null || s.DungeonId != run.Layout.Id) return false;
            run.Reset();
            var layout = run.Layout;
            foreach (var o in s.Puzzles ?? new List<PuzzleOutcomeSave>())
            {
                var p = run.PuzzleById(o?.Id);
                if (p != null && Enum.TryParse<PuzzleStatus>(o.Status, out var st)) p.RestoreOutcome(st, o.RewardClaimed);
            }
            run.RestorePosition(
                layout.RoomById(s.Room) != null ? s.Room : layout.EntryRoom,
                layout.RoomById(s.Checkpoint) != null ? s.Checkpoint : layout.EntryRoom,
                s.BossDefeated,
                (s.Keys ?? new List<string>()).Where(k => layout.Rooms.Any(r => r.Keys.Contains(k))));
            return true;
        }
    }
}
