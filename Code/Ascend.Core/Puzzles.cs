using System;
using System.Collections.Generic;
using System.Linq;

namespace Ascend.Core
{
    // Wave E puzzle framework (12_Systems/dungeons_and_puzzles.md). Data: Data/World/puzzles.json.
    // Canon: a puzzle is never a mandatory gate. Every puzzle is optional, can be skipped for free, has free hints and a
    // free assist, and pays only an optional item reward. Everything here is deterministic (no randomness, no clock).

    public sealed class PuzzleTuning
    {
        /// <summary>Wrong tries before the assist (the next correct move) is offered.</summary>
        public int FailsBeforeAssist { get; set; } = 3;
    }

    public sealed class PuzzleReward { public string ItemId { get; set; } public int Count { get; set; } = 1; }
    public sealed class PlateData { public string Id { get; set; } public int Weight { get; set; } }
    public sealed class WeightObjectData { public string Id { get; set; } public int Weight { get; set; } }

    public sealed class SconceData
    {
        public string Id { get; set; }
        public string Start { get; set; }
        public string Target { get; set; }
        /// <summary>Other sconces that turn one step whenever this one is turned.</summary>
        public List<string> Also { get; set; } = new List<string>();
    }

    public static class PuzzleTypes
    {
        public const string LeverSequence = "lever_sequence";
        public const string PressurePlate = "pressure_plate";
        public const string RuneMatch = "rune_match";
    }

    /// <summary>One row of puzzles.json. Fields not used by a puzzle's type stay empty.</summary>
    public sealed class PuzzleData
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public bool Optional { get; set; } = true;
        public List<string> Hints { get; set; } = new List<string>();
        public PuzzleReward Reward { get; set; }
        public List<string> Levers { get; set; } = new List<string>();
        public List<string> Sequence { get; set; } = new List<string>();
        public List<PlateData> Plates { get; set; } = new List<PlateData>();
        public List<WeightObjectData> Objects { get; set; } = new List<WeightObjectData>();
        public List<string> Glyphs { get; set; } = new List<string>();
        public List<SconceData> Sconces { get; set; } = new List<SconceData>();
    }

    public sealed class PuzzleFile
    {
        public int Version { get; set; } = 1;
        public string Notes { get; set; }
        public PuzzleTuning Tuning { get; set; } = new PuzzleTuning();
        public List<PuzzleData> Puzzles { get; set; } = new List<PuzzleData>();
    }

    public enum PuzzleStatus { Unsolved, Solved, Skipped }

    /// <summary>The next correct move, named for the UI: "pull" a lever, "place" an object on a plate, "remove" an object, "turn" a sconce.</summary>
    public sealed class PuzzleAssist
    {
        public string Kind { get; set; }
        public string Target { get; set; }
        public string PlateId { get; set; }
    }

    /// <summary>Shared behaviour: status, free hints, free assist, free skip, one-time optional reward, reset.</summary>
    public abstract class Puzzle
    {
        protected readonly PuzzleTuning Tuning;
        public PuzzleData Data { get; }
        public string Id => Data.Id;
        public PuzzleStatus Status { get; protected set; }
        public int HintsShown { get; private set; }
        public int Fails { get; protected set; }
        public bool RewardClaimed { get; private set; }

        protected Puzzle(PuzzleData data, PuzzleTuning tuning)
        {
            Data = data ?? throw new ArgumentNullException(nameof(data));
            Tuning = tuning ?? new PuzzleTuning();
        }

        public static Puzzle Create(PuzzleData data, PuzzleTuning tuning = null)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));
            switch (data.Type)
            {
                case PuzzleTypes.LeverSequence: return new LeverPuzzle(data, tuning);
                case PuzzleTypes.PressurePlate: return new PlatePuzzle(data, tuning);
                case PuzzleTypes.RuneMatch: return new RunePuzzle(data, tuning);
                default: throw new ArgumentException($"unknown puzzle type \"{data.Type}\" for {data.Id}");
            }
        }

        /// <summary>The next hint, freely and as often as asked. The last hint repeats. Null when the puzzle has none.</summary>
        public string NextHint()
        {
            if (Data.Hints == null || Data.Hints.Count == 0) return null;
            var h = Data.Hints[Math.Min(HintsShown, Data.Hints.Count - 1)];
            if (HintsShown < Data.Hints.Count) HintsShown++;
            return h;
        }

        /// <summary>The assist opens after the wrong tries or after every hint was read. It never costs anything.</summary>
        public bool AssistAvailable => Status != PuzzleStatus.Solved && (Fails >= Tuning.FailsBeforeAssist || (Data.Hints != null && Data.Hints.Count > 0 && HintsShown >= Data.Hints.Count));

        public PuzzleAssist Assist() => AssistAvailable ? NextStep() : null;

        /// <summary>Gives up on the puzzle. Always allowed while it is unsolved; costs nothing; only the optional reward and the optional way it would open stay closed.</summary>
        public bool Skip()
        {
            if (Status != PuzzleStatus.Unsolved) return false;
            Status = PuzzleStatus.Skipped;
            return true;
        }

        /// <summary>The optional reward, once, after solving. Null if unsolved, skipped, already claimed or the puzzle has none.</summary>
        public PuzzleReward ClaimReward()
        {
            if (Status != PuzzleStatus.Solved || RewardClaimed || Data.Reward == null) return null;
            RewardClaimed = true;
            return Data.Reward;
        }

        /// <summary>Back to the start (the halls reset). Hints and fails start over too.</summary>
        public void Reset()
        {
            Status = PuzzleStatus.Unsolved; HintsShown = 0; Fails = 0; RewardClaimed = false;
            ResetState();
        }

        /// <summary>True if the puzzle can be solved from its start (checked by tests and the validator).</summary>
        public abstract bool IsSolvable();
        protected abstract PuzzleAssist NextStep();
        protected abstract void ResetState();

        protected void MarkSolved() { Status = PuzzleStatus.Solved; }
        /// <summary>A skipped puzzle can still be solved later; a solved one ignores further input.</summary>
        protected bool Locked => Status == PuzzleStatus.Solved;
    }

    public enum LeverResult { Ignored, Correct, Wrong, Solved }

    /// <summary>Pull the levers in the right order. A wrong pull only resets the tally.</summary>
    public sealed class LeverPuzzle : Puzzle
    {
        public int Progress { get; private set; }
        public LeverPuzzle(PuzzleData data, PuzzleTuning tuning) : base(data, tuning) { }

        public LeverResult Pull(string leverId)
        {
            if (Locked || leverId == null || !Data.Levers.Contains(leverId)) return LeverResult.Ignored;
            if (Data.Sequence.Count > 0 && Data.Sequence[Progress] == leverId)
            {
                Progress++;
                if (Progress < Data.Sequence.Count) return LeverResult.Correct;
                MarkSolved();
                return LeverResult.Solved;
            }
            // A wrong pull restarts the tally; if that lever is also the first in the sequence it counts as step one.
            Progress = Data.Sequence.Count > 1 && Data.Sequence[0] == leverId ? 1 : 0; Fails++;
            return LeverResult.Wrong;
        }

        public override bool IsSolvable() => Data.Sequence.Count > 0 && Data.Sequence.All(s => Data.Levers.Contains(s));
        protected override PuzzleAssist NextStep() => Locked || Data.Sequence.Count == 0 ? null : new PuzzleAssist { Kind = "pull", Target = Data.Sequence[Progress] };
        protected override void ResetState() { Progress = 0; }
    }

    public enum PlateResult { Invalid, Placed, Overloaded, Solved }

    /// <summary>Put weights on plates so each plate carries exactly its weight. A plate loaded past its weight pops the stone back off.</summary>
    public sealed class PlatePuzzle : Puzzle
    {
        readonly Dictionary<string, string> _placed = new Dictionary<string, string>(); // object -> plate

        public PlatePuzzle(PuzzleData data, PuzzleTuning tuning) : base(data, tuning) { }

        public int LoadOn(string plateId) => Data.Objects.Where(o => _placed.TryGetValue(o.Id, out var p) && p == plateId).Sum(o => o.Weight);
        public string PlateOf(string objectId) => objectId != null && _placed.TryGetValue(objectId, out var p) ? p : null;

        public PlateResult Place(string objectId, string plateId)
        {
            if (Locked) return PlateResult.Invalid;
            var plate = Data.Plates.FirstOrDefault(p => p.Id == plateId);
            if (plate == null || !Data.Objects.Any(o => o.Id == objectId)) return PlateResult.Invalid;
            _placed.Remove(objectId);
            _placed[objectId] = plateId;
            if (LoadOn(plateId) > plate.Weight)
            {
                _placed.Remove(objectId); Fails++;
                return PlateResult.Overloaded;
            }
            if (Data.Plates.All(p => LoadOn(p.Id) == p.Weight)) { MarkSolved(); return PlateResult.Solved; }
            return PlateResult.Placed;
        }

        public bool Remove(string objectId) => !Locked && objectId != null && _placed.Remove(objectId);

        /// <summary>One assignment of objects to plates (or none) that loads every plate exactly, or null.</summary>
        public Dictionary<string, string> FindSolution()
        {
            var objs = Data.Objects; var total = new int[Data.Plates.Count];
            var pick = new string[objs.Count];
            bool Go(int i)
            {
                if (i == objs.Count) { for (int k = 0; k < total.Length; k++) if (total[k] != Data.Plates[k].Weight) return false; return true; }
                for (int k = -1; k < total.Length; k++)
                {
                    if (k >= 0) { if (total[k] + objs[i].Weight > Data.Plates[k].Weight) continue; total[k] += objs[i].Weight; pick[i] = Data.Plates[k].Id; }
                    else pick[i] = null;
                    if (Go(i + 1)) return true;
                    if (k >= 0) total[k] -= objs[i].Weight;
                }
                return false;
            }
            if (!Go(0)) return null;
            var d = new Dictionary<string, string>();
            for (int i = 0; i < objs.Count; i++) d[objs[i].Id] = pick[i];
            return d;
        }

        public override bool IsSolvable() => Data.Plates.Count > 0 && FindSolution() != null;

        protected override PuzzleAssist NextStep()
        {
            var sol = FindSolution();
            if (sol == null || Locked) return null;
            // Take off anything that is in the wrong place first, then place what is still off the plates.
            foreach (var o in Data.Objects)
                if (_placed.ContainsKey(o.Id) && _placed[o.Id] != sol[o.Id]) return new PuzzleAssist { Kind = "remove", Target = o.Id };
            foreach (var o in Data.Objects)
                if (!_placed.ContainsKey(o.Id) && sol[o.Id] != null) return new PuzzleAssist { Kind = "place", Target = o.Id, PlateId = sol[o.Id] };
            return null;
        }

        protected override void ResetState() { _placed.Clear(); }
    }

    /// <summary>
    /// The Resonance Lock: a ring of rune sconces, each cycling through the glyphs. Turning one also turns its linked
    /// sconces. The lock opens when every sconce shows its target glyph (the Runecraft rune-word idea from systems.md).
    /// </summary>
    public sealed class RunePuzzle : Puzzle
    {
        /// <summary>Search cap for solvability and the assist; keep puzzles smaller than this (a few thousand states).</summary>
        public const int MaxSearchStates = 250000;
        readonly int[] _state;
        readonly int[] _goal;
        readonly int[][] _turns; // for each sconce, the indices it turns (itself first)

        public RunePuzzle(PuzzleData data, PuzzleTuning tuning) : base(data, tuning)
        {
            int n = data.Sconces.Count;
            _state = new int[n]; _goal = new int[n]; _turns = new int[n][];
            var idx = data.Sconces.Select((s, i) => new { s.Id, i }).ToDictionary(x => x.Id, x => x.i);
            for (int i = 0; i < n; i++)
            {
                var s = data.Sconces[i];
                _goal[i] = Math.Max(0, data.Glyphs.IndexOf(s.Target));
                _turns[i] = new[] { i }.Concat((s.Also ?? new List<string>()).Where(idx.ContainsKey).Select(a => idx[a])).Distinct().ToArray();
            }
            ResetState();
        }

        public string GlyphAt(string sconceId)
        {
            int i = Data.Sconces.FindIndex(s => s.Id == sconceId);
            return i < 0 || Data.Glyphs.Count == 0 ? null : Data.Glyphs[_state[i]];
        }

        /// <summary>Turns a sconce one step (and its linked sconces). Returns false if the id is unknown or the lock is already open.</summary>
        public bool Turn(string sconceId)
        {
            if (Locked || Data.Glyphs.Count == 0) return false;
            int i = Data.Sconces.FindIndex(s => s.Id == sconceId);
            if (i < 0) return false;
            Step(_state, i);
            if (Matches(_state)) MarkSolved();
            return true;
        }

        void Step(int[] s, int i) { if (Data.Glyphs.Count == 0) return; foreach (var j in _turns[i]) s[j] = (s[j] + 1) % Data.Glyphs.Count; }
        bool Matches(int[] s) { for (int i = 0; i < s.Length; i++) if (s[i] != _goal[i]) return false; return true; }

        int[] Start() => Data.Sconces.Select(s => Math.Max(0, Data.Glyphs.IndexOf(s.Start))).ToArray();

        /// <summary>The shortest list of sconces to turn from the given state, or null if none is found within the search cap.</summary>
        List<int> Search(int[] from)
        {
            if (Matches(from)) return new List<int>();
            var prev = new Dictionary<string, KeyValuePair<string, int>>();
            string Key(int[] s) => string.Join(",", s);
            var q = new Queue<int[]>(); q.Enqueue(from); prev[Key(from)] = new KeyValuePair<string, int>(null, -1);
            while (q.Count > 0 && prev.Count < MaxSearchStates)
            {
                var cur = q.Dequeue();
                for (int i = 0; i < _state.Length; i++)
                {
                    var nx = (int[])cur.Clone(); Step(nx, i);
                    var k = Key(nx);
                    if (prev.ContainsKey(k)) continue;
                    prev[k] = new KeyValuePair<string, int>(Key(cur), i);
                    if (Matches(nx))
                    {
                        var path = new List<int>();
                        for (var at = k; prev[at].Key != null; at = prev[at].Key) path.Add(prev[at].Value);
                        path.Reverse();
                        return path;
                    }
                    q.Enqueue(nx);
                }
            }
            return null;
        }

        public override bool IsSolvable() => Data.Sconces.Count > 0 && Data.Glyphs.Count > 1 && Search(Start()) != null;

        protected override PuzzleAssist NextStep()
        {
            if (Locked) return null;
            var path = Search((int[])_state.Clone());
            return path == null || path.Count == 0 ? null : new PuzzleAssist { Kind = "turn", Target = Data.Sconces[path[0]].Id };
        }

        protected override void ResetState()
        {
            var s = Start();
            for (int i = 0; i < _state.Length; i++) _state[i] = s[i];
        }
    }
}
