# Project status: what actually exists

As of 2026-11-12, from the repository audit. Every statement here is backed by a file or a run named in the audit reports (`Planning/audits/`). The per-system table is `SYSTEM_INVENTORY.md`. Status words: `QUALITY_GATES.md` §1.

## 1. In one paragraph

AETHWYRD has a very large, validated **design and data layer**, a broad and well-tested **rules library**, and a small **playable game**: one graybox scene in which a Swordsman can fight about 22 species, take quests, loot, shop, craft, tame, rest, defend against sieges, rank up from F to E and free one region. Most systems written since late October exist as tested rules that the game does not yet use. Nothing has been verified in Unity since 2026-11-08, and no person has yet judged on record whether the core loop is fun.

## 2. Design against build

| Thing | Canon and data | In the game today | Evidence |
|---|---|---|---|
| Regions | 49 rows (40 surface, 8 underworld and Labyrinth, 1 post-game) | 1 scene covering the Brindlewick field and the edge of Whisperwood; no terrain, no streaming | ecology audit §0 |
| Monster species | 680 in data, 6,754 labelled variants, 25 shared rigs | 19 placed by hand, about 22 reachable with siege spawns; 3 have models in git, the rest are capsules unless local files exist | ecology audit §0 |
| Species with ecological relationship data | - | 0 of 680 | ecology audit §0 |
| Classes | 12 base in data (24 advanced and 48 expert have no data) | 1 playable (Swordsman); no class choice | combat audit SYS-CMB-14 |
| Magic | Designed; kits in data | No magical damage path; every hit is physical | combat audit P-1 |
| Weapon families | 14 designed and validated | 0 read by any code | combat audit SYS-CMB-15 |
| Companions | 14 in data | 1 recruitable (Lyra) | progression audit SYS-CMP-01 |
| NPCs | about 2,500 in canon; 39 records | 12 placed; dialogue is one role line each | exploration audit SYS-QST-08, -09 |
| Quests | 32 (Prologue and part of Act I); Acts II to VI have none | 19 completable by static analysis | exploration audit headline 4, 5 |
| Dungeons | 1 in data, 120 Labyrinth floors as a registry | No dungeon scene | ecology audit SYS-WLD-07, -08 |
| Appraisal | A stat, a skill and detective play in the docs | Bestiary tiers from sightings and kills only | exploration audit headline 1 |
| Lying Interface | Staged corruption designed | One fixed "[REDACTED]" line | exploration audit headline 2 |
| Field Journal | Evidence, confidence, hypotheses designed | Two journal pages that nothing in the world writes to | exploration audit headline 3 |
| Housing, farming, runes, meal buffs, mount riding | Rules built, tested, saved | Not reachable by the player | progression audit SYS-ECN-08 to -10 |
| Audio | Cue sheets, state machines | Silent except placeholder combat cues | technical audit SYS-CORE-08 |
| Player character | VRoid or humans-base | A capsule | `ring0_plan.md` week 3 |

## 3. What is solid

- **The rules library.** 63 files and about 12,000 lines in `Code/Ascend.Core`, free of engine code, with 755 passing tests (run today). Damage, defence, reactions, style, AI, quests, saves, crafting, taming, sieges, calendar and more.
- **The data pipeline.** Generators and a validator run in one command and in CI; data is valid today (28 known map warnings, 0 graph findings).
- **The Ring 0 combat slice.** Attack chain, heavy and charge, launcher and air combat, dodge and perfect dodge, block and parry, Style Rank, skills and ultimate, Firestorm, telegraphs, aggro tokens, a three-phase boss. In the game, with PlayMode tests (183 passed on 2026-11-08).
- **The Ring 0 loop around it** (present in the game; most of it has no automated test of its own, and none of it has been judged in play). Quests and the weekly board, shops, equipment, crafting with quality, gathering, taming and partners, inns and the day clock, sieges and liberation, guild rank F to E, save and load.
- **Save safety.** Bad saves are set aside, a newer save is never overwritten by an older build, migration tests exist.
- **Tooling.** Blender generators for creatures, buildings and terrain; a vault builder; a one-click PC verify script.

## 4. What is not what the documents imply

1. **"Implemented" has meant "rules written".** Finished and tested, but unused by the game: group tactics, boss armour and weak points, the reaction table and synergies, weapon movesets, encounter tables, the region graph, dungeon puzzles, meal buffs, runes, housing and farming.
2. **Journals are wired to the save and the screen, not to the world.** Nothing a player does writes a clue, an archive entry or a discovery.
3. **Some finished data has no reader.** `weapon_movesets.json`, `population.json`, `encounters.json`.
4. **Thirteen quests cannot be completed** in the build (givers or targets not placed; no dungeon scene).
5. **Quest choices have no effect.** The option is stored and ignored.
6. **The fun test has never been run.** Twelve unchecked boxes; four of them depend on unwired systems.
7. **No performance number exists** anywhere in the repo.
8. **Ally kills give no credit.** A kill landed by a companion or partner raises no kill event: no XP, loot, quest credit or liberation (R31; found in review, confirmed by reading, not reproduced).
9. **The newest handover is from 2026-11-02** and is wrong about the test counts and about Unity.

## 5. What could not be inspected

- The Unity project in a running editor: compile state, PlayMode results, the scene as serialized, frame rate. No Unity in the cloud container.
- The owner's PC: local agent branches and worktrees (about 20 and 28 per the risk register), local model libraries, verify-run logs. Only 7 remote branches are visible.
- Whether the PC branch `agent/ai-engineer/companion-presets-tactics` wires group tactics.
- Feel. Nobody has recorded a playthrough.
- Items the auditors marked UNCERTAIN: whether banter lines are spoken, controller rumble, the loot faucet rate.

## 6. Counts

150 system rows across five audits (some systems appear under two IDs).

| | Rules layer | In the game |
|---|---|---|
| TESTED | 98 | 22 |
| IMPLEMENTED (no automated test found) | 5 | 41 |
| PARTIAL or PROTOTYPE | 8 | 39 |
| NOT WIRED, NOT STARTED or NOT RUN | 0 | 18 |
| DATA ONLY, DOCUMENTED or NONE | 25 | 17 |
| UNCERTAIN | 0 | 3 |
| VERIFIED or COMPLETE | 0 | 0 |
| n/a | 14 | 10 |

These are counts of rows, not a percentage of the game. No completion percentage is given because none could be defended.

## 7. Test evidence

| Suite | Result | When | By |
|---|---|---|---|
| Data validation and generators | Valid; 28 map warnings; 0 graph findings | 2026-11-12 | This audit (cloud) |
| Core rules tests | 755 passed | 2026-11-12 | This audit (cloud) |
| Unity PlayMode | 183 passed | 2026-11-08 | Owner's PC (progress log); **not re-run** |
| Fun test (`combat.md` §12) | Not tested | - | - |
| Performance | Not tested | - | - |

## 8. Stage

Canon's Ring 0 ("is combat fun?") is mostly built: the player character is missing, the fun test is unrun, four of its twelve items need systems the game does not use yet, and one confirmed defect can lose the region's main goal (R31). Much of Ring 1's breadth exists as rules and data. In studio terms the project is in pre-production with a vertical slice partly assembled and not yet proven.
