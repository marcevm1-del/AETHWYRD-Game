# Dungeons and puzzles v7 audit and Wave E design contract

Source: `upgrade v7` (repo root; image links ignored). Canon wins: §4 "Dungeon cores: never allies; dungeons stay reusable", §3/§4 world numbers (Great Labyrinth, 120 floors, 3 depth bands), the §6 rows "Field journal and hunt deduction" (no mandatory puzzle gate), "Region discovery and liberation delta" and "Map knowledge rules" (Unknown / Heard / Visited), §4d (no enemy hierarchy), §5 Loss Rules. Scope of this wave: Core rules, data, validator and docs. No Unity scene, no level geometry, nothing under `Game/`.

## 1. What existed before Wave E

| Area | State on main | Where |
|---|---|---|
| Great Labyrinth | Three region rows (`reg_labyrinth_upper` floors 1-40 rank F-C, `_deep` 41-90, `_abyss` 91-120) with gazetteer prose: guardian floor every tenth floor, safe towns on 30 and 40, halls reset weekly, kobold salvage families on the upper floors. **No floor, room, trap or layout data** | `Data/World/regions.json`, `gazetteer.json` |
| Boss phases | `BossFile`/`BossFight` and `boss_phases.json` for named bosses. Reusable by any boss slot | `BossPhases.cs`, `Data/Monsters/boss_phases.json` (Grukk's rows untouched) |
| Map knowledge | `MapStatus {Unknown, Heard, Visited}` for regions and a fog grid for local areas. Not usable for rooms or clues | `MapKnowledge.cs`, `SaveGame.Map` |
| Field journal | Prose only (hunt clues, no mandatory puzzle) | `10_World/reactive_world_and_field_journal.md` |
| Runecraft puzzle idea | One line: "Rune-word puzzle (combine runes in the right order)" | `12_Systems/systems.md` |
| Dungeon layout, locked doors, keys, levers, plates, secrets, checkpoints | Nothing | none |
| Puzzle code | Nothing | none |
| Save | `SaveGame` has `Map` (null in older saves) but no dungeon or clue state | `SaveGame.cs` |

## 2. v7 section map

Status: **built** (Wave E), **partial** (a seed exists), **deferred** (a later wave), **skipped** (deliberately not built; reason given).

| v7 section | Status | Decision |
|---|---|---|
| 1 Dungeon categories (ten themes) | partial | One theme only: a monster lair / salvage warren on the upper Labyrinth. The schema carries a free `theme` string so later dungeons can add themes |
| 1 Multi-level layouts, locked chambers, secret rooms, hidden passages, shortcuts | **built** | Slice has 6 rooms on 2 levels: key door, a lever-opened lift, a secret passage and room, a one-way shortcut |
| 1 Unique enemy populations, dungeon-specific bosses | **built / constrained** | Per-room spawn tables use **existing species only**. The boss slot names an existing species and adds no phases or stats. No new boss |
| 1 Traps and mechanisms | partial | The three puzzle mechanisms are the mechanisms. Floor traps and hazards are deferred (the existing Kobold Trapmaster appears as a spawn) |
| 1 Lore discoveries | **built** | Clues carry a short lore line and are tracked in the new clue record |
| 1 Hidden treasure chambers | **built** | The secret room is optional and holds an optional puzzle reward |
| 1 "Advanced dungeon generation" / varied generated layouts | **skipped** | The task is a hand-designed slice. Procedural generation is out of scope |
| 2 Environmental puzzle system | **built (3 types)** | Lever sequence, weight plates, rune match. Hints, skip, free assist, optional reward only |
| 2 Other puzzle families (physics, light and mirrors, timing, water, music) | deferred | The puzzle base class and data shape take new types without a save change |
| 3+ Ancient civilizations, Civilization Archive, archaeology and restoration, languages | **skipped** | Named out of scope for this wave |
| Traversal (climbing, swimming, gliding), exploration gear | **skipped** | Out of scope. Canon: flight is an ability only |
| Dungeon Designer editor | **skipped** | Out of scope. The JSON layout and the validator are the authoring path for now |
| Map vocabulary "Discovered / Surveyed" | **renamed** | Canon uses Unknown / Heard / Visited. The new clue and room record uses exactly those |
| Multiplayer parts | n/a | v7 itself removes multiplayer |

## 3. Canon constraints and how each is enforced

| Constraint | Enforcement |
|---|---|
| Puzzles are never a mandatory progress gate | Schema: `optional` must be `true`. Validator and `DungeonRules`: with every puzzle-gated and secret connection removed, the entry still reaches the boss room and every key the required doors need. A puzzle-gated connection is only legal if its two ends are already joined by a non-puzzle path. Rooms reachable only through optional connections must be marked `secret` and may hold no key and no boss |
| Puzzles never gate story or guild rank | The layout has no quest, flag or rank field to hang a gate on. `Puzzle.Reward` is items only, and the reward is optional. Skipping costs nothing |
| Skip with no cost | `Puzzle.Skip()` is always allowed while unsolved; it removes only the optional reward and the optional shortcut |
| Hints are free | `Puzzle.NextHint()` has no cost field; after `failsBeforeAssist` wrong tries, or after the last hint, `Assist()` names the next correct move |
| Dungeon cores are never allies | Schema: `coreIsAlly` must be `false`; no tame/ally field exists on spawn rows. A Core test also checks the loaded layout |
| Dungeons stay reusable | Schema: `reusable` must be `true`. `DungeonRun` and puzzles have `Reset()`; rewards claim once per reset cycle |
| No enemy hierarchy (§4d) | The boss is a plain existing species slot. No captain, warchief or promotion field exists in the layout |
| Loss rules (§5) | Dying returns the player to the last checkpoint with keys and solved puzzles kept; nothing is lost |
| Map vocabulary | `MapStatus` is reused for rooms and clues |
| Do not edit locked rows or Grukk's phases | No Canon row and no `boss_phases.json` edit. The Canon §6 proposals are in `12_Systems/dungeons_and_puzzles.md` §9 and Canon §6 |

## 4. What Wave E builds

1. This note.
2. `Data/World/dungeons.json` (+ schema `dungeon`): **The Salvage Warren**, Great Labyrinth floors 3-4. `Code/Ascend.Core/Dungeons.cs` with `DungeonRules.Validate` (reachability, key and door check, soft-lock search, optional-bypass rule) and `DungeonRun` (movement, keys, checkpoints, death). Validator rule in `Tools/validate/validate.js`.
3. `Data/World/puzzles.json` (+ schema `puzzles`) and `Code/Ascend.Core/Puzzles.cs`: lever sequence, weight plates, rune match. All deterministic, each with a solvability check.
4. `Code/Ascend.Core/DungeonKnowledge.cs`: rooms and clues as Unknown / Heard / Visited, `SaveGame.Dungeons` (null in older saves, null-coalesced by the loader).
5. `12_Systems/dungeons_and_puzzles.md` and the Canon §6 proposals.

Tests: `Code/Ascend.Core.Tests/DungeonTests.cs`, `PuzzleTests.cs`, `DungeonKnowledgeTests.cs`.

## 5. Skipped on purpose

Procedural generation; the Civilization Archive; archaeology and restoration; climbing, swimming, gliding; exploration gear; the Dungeon Designer editor; any Unity scene or geometry; any new boss, monster, item or art; floor traps and environmental hazards; extra puzzle families beyond three. Saves from Unity (`PlayerSave`) are not touched; mapping `SaveGame.Dungeons` into the Unity save is Game work for a later wave.
