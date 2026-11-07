# Dungeons and Puzzles (system)

> **Built (Wave E, Core + data only; no Unity scene).** Source: `upgrade v7`; audit and scope in `13_Production/dungeon_v7_audit.md`. Data: `Data/World/dungeons.json`, `Data/World/puzzles.json` (schemas `dungeon`, `puzzles`). Code: `Code/Ascend.Core/{Dungeons,Puzzles,DungeonKnowledge}.cs`. Tests: `DungeonTests`, `PuzzleTests`, `DungeonKnowledgeTests`. Validator: `Tools/validate/dungeon_checks.js`.

## 1. Canon rules this system obeys

| Rule | How it holds |
|---|---|
| Puzzles are never a mandatory gate | Every puzzle is `optional: true` (schema-enforced). The boss and every non-secret room stay reachable with all puzzles skipped and all secrets unfound. A puzzle-gated way is legal only where another way already joins its two ends |
| Dungeon cores are never allies | `coreIsAlly` must be `false`; spawn rows have no tame or ally field |
| Dungeons stay reusable | `reusable` must be `true`. The halls reset (`DungeonRun.Reset`): keys, puzzles and the boss are back; what the player learned is kept |
| No enemy hierarchy (§4d) | The boss slot is a plain existing species. No captains or promotions |
| Loss rules (§5) | Falling returns you to the last checkpoint with keys and solved puzzles kept |
| Map vocabulary | Rooms and clues use `MapStatus`: Unknown, Heard, Visited |

## 2. A dungeon layout

A layout is a graph of rooms. Each room has a `level` (floor within the dungeon), a `role` (entry, hub, key, checkpoint, boss, secret, combat, treasure), optional `checkpoint` and `secret` flags, a spawn table of **existing** species that live in the dungeon's region (and are no higher than the region's top rank), optional `keys` lying there, optional `puzzles`, and for the boss room a `boss` slot naming an existing species. Connections join two rooms: `passage`, `stairs`, `door`, `secret` or `shortcut`; they may be `oneWay` and may require a `requiresKey`, a `requiresPuzzle` (solved) or be hidden until a `revealedByClue` is found.

Keys are never used up, so doors stay open once you hold the key. That keeps the soft-lock search exact (the state is a room plus the keys held).

## 3. The Salvage Warren (the first slice)

Great Labyrinth floors 3-4, recommended rank E. A kobold salvage den; the gazetteer's "dungeon-born kobolds run a thriving salvage trade" made into a place. Six rooms on two levels.

| Room | Level | Role | Notes |
|---|---|---|---|
| Chalk Landing | 1 | entry, checkpoint | Scavengers and a Bone Crawler. Holds the chalk-marks clue |
| Scrap Hall | 1 | hub | Miner, Sneak, Red Slime. The Tally Levers (lever sequence) |
| Weighing Gallery | 1 | key | Trapmaster and Bone Crawlers guard the rusted tally key. The Weighing Floor (weight plates) with an optional reward of 2 Rune Plates |
| Lower Landing | 2 | checkpoint | Hollow Mourners and a Red Slime. A cold draught hints at the secret |
| Beetle Vault | 2 | boss | **Armor Beetle**, an existing E+ species. No phases added |
| Rune Cistern | 2 | secret | The Resonance Lock (rune match), optional reward of 1 Core (E). Holds no key and no boss |

Ways: the rusted tally door (key) or the idle lift (solve the levers) lead from the Scrap Hall down to the Lower Landing; a secret seam (needs the draught clue found in place) leads from the Lower Landing to the cistern; a one-way chute drops from the Beetle Vault back to the Chalk Landing. The key way is always available, so the lever way is only a faster alternative.

## 4. The puzzle framework

All puzzles share `Puzzle`: a `Status` (Unsolved, Solved, Skipped), free `NextHint()` (the last hint repeats), a free `Assist()` that names the next correct move once `failsBeforeAssist` wrong tries have passed or every hint has been read, a free `Skip()`, a one-time optional `ClaimReward()` (an item, never anything that gates), and `Reset()`. A skipped puzzle can still be solved later. No puzzle uses a clock or randomness, so the same moves always give the same result.

| Type | Idea | Rules |
|---|---|---|
| `lever_sequence` | Pull the levers in the order the chalk marks show | A wrong pull resets the tally and counts a fail. Nothing is lost |
| `pressure_plate` | Weigh out stones so each plate carries its exact weight | A plate loaded past its weight pops the stone off and counts a fail. The assist first removes wrong stones, then places the rest, and never overloads |
| `rune_match` | The **Resonance Lock**: a ring of rune sconces, each cycling ember, tide, gale, stone. Turning one also turns its linked sconces | Open when every sconce shows its target glyph. A Runecraft rune-word idea (`systems.md`), not borrowed from any game's shrines. The assist is the shortest solution by search, capped at 250,000 states |

Solvability is checked in Core (`IsSolvable`) and in the validator, so a puzzle that cannot be solved cannot ship.

## 5. Validation

`DungeonRules.Validate` (Core) and `dungeon_checks.js` (validator, part of `npm run build`) check: real species of the region and no higher than the region's top rank; entry room is a checkpoint; floors inside the region's band; keys exist before their doors; clue and puzzle references; the boss room and every non-secret room reachable with all optional content removed; secret rooms really secret and holding no key or boss; no puzzle-gated way that is the only way on; **no soft-lock** (from every reachable room-and-keys state the entrance and the boss are still reachable, with and without the optional content); every puzzle placed exactly once and solvable; reward items exist.

## 6. Runtime (`DungeonRun`)

`Move`, `TakeKey`, `FindClue`, `DefeatBoss`, `Die`, `Reset`, `ExitsHere`. A hidden way is not offered until its clue is found in place. The host (Unity, later) renders rooms and spawns; Core decides what is open.

## 7. Secrets and clues (`DungeonKnowledge`)

Rooms and clues are **Unknown** (blank), **Heard** (a rumour pencilled them; a clue's `heard` line) or **Visited** (found in place). A heard secret clue pencils the secret room but reveals nothing; finding the clue in place reveals the way. Hearing never downgrades a visit. Saved in `SaveGame.Dungeons` (`DungeonSave`: per dungeon, rooms, clues and a `Cleared` flag). Older saves have no such field: it deserialises to null and `SaveRules.Upgrade` fills it, so they load with nothing known. Ids the data no longer has are ignored on load.

## 8. Not built (see the audit)

Procedural generation, other dungeon themes, floor traps and hazards, more puzzle families, the Dungeon Designer editor, the Civilization Archive, archaeology, traversal and exploration gear. Mapping `SaveGame.Dungeons` into the Unity `PlayerSave`, and the in-game journal page for clues, are Game work.

## 9. Proposals for Canon §6 (need the user's OK)

Added as rows in Canon §6; none edits a locked row.
1. **Dungeon puzzle contract:** make the rule in the field-journal row explicit for dungeons: every puzzle is optional, skippable for free, hinted and only ever rewards optional items.
2. **Dungeon reset and death:** halls reset weekly (as the gazetteer says); falling returns you to the last checkpoint with keys kept.
3. **Dungeon boss slots:** a dungeon's boss is an existing named or regional species; a boss slot never adds hierarchy.
4. **Dungeon clue record:** rooms and clues use Unknown / Heard / Visited, like the map.
