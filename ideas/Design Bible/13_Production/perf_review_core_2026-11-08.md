# Core performance and allocation review (2026-11-08)

Reviewer: code-reviewer. Scope: `Code/Ascend.Core` (63 files, ~12k lines) plus the Unity call sites of its per-frame code. Method: static read of every per-frame entry point (`Tick`/`Update`/`Ambience`/`Compose`) and a grep sweep of LINQ and `new` collections (1,199 hits in 62 files; most are load-time or validation and are not listed). **Nothing was profiled or run**: severities below are from code reading, not measurement. Unity was not opened.

Per-frame budget context: `MonsterBrain.Tick` runs once per live monster per frame (`MonsterController.cs:187`); with a pack or a siege wave that is dozens of calls per frame, so a few hundred bytes each becomes GC pressure on the main thread.

## Findings, most severe first

### P1 (fix soon): allocations on the per-monster per-frame path
1. **`AggroTokens.Holders` copies the set on every read** — `Code/Ascend.Core/Loot.cs:85` (`_holders.ToList()`), read as `.Holders.Count` at `Game/Assets/_Game/Runtime/World/MonsterController.cs:186`, i.e. once per monster per frame. Allocates a list of up to `Capacity` strings per call. Fix: expose `public int Count => _holders.Count;` and read that (keep `Holders` for tests); or return the `HashSet` as `IReadOnlyCollection<string>` directly.
2. **`MonsterBrain.Tick` allocates its key list every frame** — `MonsterAi.cs:205` `_cooldownLeft.Keys.ToList()`. One list plus enumerator per monster per frame even with no cooldowns. Fix: skip when `_cooldownLeft.Count == 0`; better, store the cooldown as an absolute `_clock + cooldown` expiry (no per-frame decrement at all), or keep a small `string[]/double[]` indexed by attack slot.
3. **`MonsterBrain.Choose` builds a LINQ list per decision** — `MonsterAi.cs:295-298` (`Where(...).ToList()`, closure, then `OrderByDescending(...).First()`). Runs every frame while Chase/Reposition. Calls `ReachOf`/`MinRangeOf` per attack. Fix: loop `_attacks` once, tracking best power and a ready count (reservoir pick for the random branch, same RNG draw order so determinism tests stay green).
4. **`MonsterBrain.CurrentTelegraph` re-parses a string every access** — `MonsterAi.cs:141` -> `DefenseJudge.Parse` -> `Enum.TryParse` (`Defense.cs:19`). Read at `MonsterController.cs:295` and `:473` (every frame while telegraphing). Fix: cache the parsed `Telegraph` when `CurrentAttack` is set in `StartWindup`.
5. **`SkillState.Tick` allocates a key list per frame** — `Skills.cs:89` (`_cooldown.Keys.ToList()`), once per player/companion per frame. Same fix as 2 (skip when empty, or expiry-time storage).

### P2 (worth doing with the above): per-update garbage in the audio layers
6. **`MusicMachine.Update`/`Compose`** — `AdaptiveMusic.cs:289` new `List<string>` every call; `:344` new `SortedDictionary` every call (tree node allocation per layer); `:368` `mix.Keys.ToList()` when ReducedIntensity is on. Called by `MusicStateLogger` (rate not checked). Fix: reuse a cleared scratch list/dictionary in the machine and hand out a frame object that the caller must not retain, or return an immutable snapshot only when the mix changes (the mix is a pure function of state, overlays and phase, so it can be cached and invalidated on transition/overlay flip).
7. **`EnvironmentAudio.Ambience`** — `EnvironmentAudio.cs:217` new `SortedDictionary` plus a local-function closure per call. Same caching idea (key: zone, weather, daypart, terrain).
8. **`BossFight.Update`** — `BossPhases.cs:59` allocates a `List` every call even when no phase begins (almost always); called every frame per boss (`CombatSandbox.cs:178`, Unity boss controller). Fix: return a shared static empty list when nothing begins, or return `int` count plus an out phase.

### P3 (low priority, note only)
9. `AttackChain.Tick` is allocation-free (reviewed; fine). `StyleMeter.Tick`, `ComboBudget.Tick`, `Poise.Tick`, `Taming.Tick`, `Siege.Tick`, `PhotoMode.Update` are allocation-free (reviewed; fine). `ThreatAssessor.Score` is pure arithmetic (fine).
10. `DungeonData.RoomById` is a linear `FirstOrDefault` (`Dungeons.cs:80`) and `Explore` rebuilds `Edges(d).ToList()` and re-concatenates key lists per state (`Dungeons.cs:104,116`). `SoftLocks` calls `Explore` once per reachable state (`:144-147`), so validation is O(states^2 * edges). Only reached from `Validate` (tests/CI/loaders, `:203-220`), never per frame; fine today. If dungeon key counts grow, memoise `Explore` per start and use a room dictionary.
11. `WorldMapPainter.Paint` is heavy by design (full-image Chamfer, box blur, per-pixel loops, `Parallel.For`), but it runs once on a worker thread via `Task.Run` (`MapArt.cs:38`) and is deterministic; no action. Watch that `width` stays bounded (it clamps only the minimum, `Math.Max(150, width)`): a very large caller value allocates several `W*H` float/byte arrays (N x 4 bytes each).
12. Load-time LINQ in constructors (`MonsterBrain` ctor, `BossFight` ctor, `MusicMachine` ctor) is fine because it runs once per spawn/boss. A spawn burst of many monsters runs the `MonsterBrain` ctor `Where/Select/ToList` per monster; if spawn hitches show up, cache the filtered attack list per species id.

## What was not checked
- No profiler run, no allocation measurement, no frame timings; ranking is by call frequency and per-call garbage, not by measured cost.
- `Code/Unity/Runtime` and the Unity runtime outside the listed call sites were not swept; `PickAllyTarget()` and `PackmatesNear()` in `MonsterController.cs` (per monster per frame) are the next things to read, and were NOT assessed here.
- Rate at which `MusicStateLogger` calls `Update` was not checked (so P2 item 6 may be per frame or lower).

## Suggested order for core-rules-engineer / ai-engineer
Items 1, 2, 3, 4, 5, 8 are small, local, and behaviour-preserving (keep RNG call order in `Choose`); do them together with a test that a brain run for N ticks gives identical `AiCommand`s before and after. Items 6 and 7 are a second pass.
