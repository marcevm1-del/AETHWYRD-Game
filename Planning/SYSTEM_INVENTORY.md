# System inventory

Every game and production system, with what actually exists on 2026-11-12. This page is the index; the evidence (source files, line numbers, known issues) is in the audit reports under `Planning/audits/`, one per area, which use the same system IDs.

## How to read it

- **Two statuses per system.** *Rules layer* is `Code/Ascend.Core` and its tests, or `Data/` where there is no code. *In the game* is the Unity project. Status words are defined in `QUALITY_GATES.md` §1, plus these: **NOT WIRED** (rules or data exist, the game does not use them) · **DATA ONLY** (a data file with no code reading it) · **NOT RUN** · **NONE** · **UNCERTAIN** (the auditor could not establish it) · **n/a**.
- **TESTED in the game** means automated PlayMode tests exist and passed in the last recorded run, 2026-11-08 (183 passed). Unity could not be run for this audit, so nothing here was re-verified in the engine. **No system is VERIFIED or COMPLETE**: no playthrough by a person is on record and no system has agreed acceptance criteria yet.
- **TESTED in the rules layer** was re-confirmed today: 755 Core tests passed.
- The status column is the auditor's first status word for that layer; where a row needs a qualifier (for example "Swordsman only"), it is in the audit's own table.
- Priorities are the auditors': P0 blocks the Ring 0 gate, P1 needed for Ring 0 quality or the slice, P2 important, P3 useful, P4 parked.
- Some systems appear in two audits under two IDs; the last column links them.

Update rule: when a system moves, change its row here and cite the evidence in the task that moved it. Never raise a status without the evidence `QUALITY_GATES.md` asks for.


## Core game (9)

Responsible: technical-director / save-platform-engineer. Evidence and full notes: `audits/2026-11-12_technical_production_qa.md`.

| ID | System | Rules layer | In the game | Priority | Next action | Upgrades and ideas | Same system as |
|---|---|---|---|---|---|---|---|
| SYS-CORE-01 | Two-layer architecture | TESTED | IMPLEMENTED | P2 | Keep. Record the layer rule as an ADR | UPG-039 | - |
| SYS-CORE-02 | Data loading | TESTED | IMPLEMENTED | P1 | A "data with no consumer" check in the validator report | UPG-025 | - |
| SYS-CORE-03 | Save and load | TESTED | TESTED | P1 | Decide the product and company name before any outside build; add a version bump rule | UPG-028 | - |
| SYS-CORE-04 | Input | n/a | IMPLEMENTED | P3 | Backlog after the fun test | - | - |
| SYS-CORE-05 | Settings and accessibility | TESTED | IMPLEMENTED | P3 | - | - | - |
| SYS-CORE-06 | UI framework | n/a | IMPLEMENTED | P2 | Architecture decision before any UI polish | UPG-032 | - |
| SYS-CORE-07 | Camera | n/a | TESTED | P4 | - | - | - |
| SYS-CORE-08 | Audio runtime | TESTED | NOT WIRED | P2 | Blocked on audio sources and licences | UPG-030 | - |
| SYS-CORE-09 | Core gameplay loop | TESTED | IMPLEMENTED | P0 | Run the fun test | UPG-001 | - |

## Combat (32)

Responsible: combat-designer / gameplay-engineer. Evidence and full notes: `audits/2026-11-12_combat.md`.

| ID | System | Rules layer | In the game | Priority | Next action | Upgrades and ideas | Same system as |
|---|---|---|---|---|---|---|---|
| SYS-CMB-01 | Player attack chain (L-L-L-L, buffering, cancel windows) | TESTED | TESTED | P1 | Fun test item 1 and 6 | - | - |
| SYS-CMB-02 | Heavy / charged heavy | TESTED | IMPLEMENTED | P2 | none | - | - |
| SYS-CMB-03 | Launcher, air chain, slam, launch-to-slam | n/a | TESTED | P1 | Wire `launchable` into `MonsterDummy.Launch` | UPG-005 | - |
| SYS-CMB-04 | Dodge, i-frames, perfect dodge, Flash Time | TESTED | TESTED | P1 | Fun test item 2 | - | - |
| SYS-CMB-05 | Block, parry, riposte | TESTED | TESTED | P1 | Fun test item 2 | - | - |
| SYS-CMB-06 | Damage formula | TESTED | PARTIAL | P1 | Add MATK/MDEF branch in Core with tests before any non-Swordsman class is exposed | UPG-004 | - |
| SYS-CMB-07 | Elements, aura, reactions (10 pairs) | TESTED | PARTIAL | P1 (table), P3 (extra zones) | Pass `Db.ReactionTable` into `ReactionState`; then wire zones | UPG-003 | - |
| SYS-CMB-08 | Reaction synergies (6) | TESTED | NOT WIRED | P3 | Hold until table is wired | UPG-003 | - |
| SYS-CMB-09 | Status effects | PARTIAL | PARTIAL | P3 | Decide whether a status framework is in Ring 1 scope (OQ) | IDEA-027 | - |
| SYS-CMB-10 | Poise, stagger, knockback | TESTED | PARTIAL | P2 | Decide: build Break gauge for Grukk or strike it from Ring 0 text | UPG-007 | - |
| SYS-CMB-11 | Combo Budget | TESTED | IMPLEMENTED | P3 | none | - | - |
| SYS-CMB-12 | Style Rank / Awakening | TESTED | IMPLEMENTED | P2 | Fun test item 5 | - | - |
| SYS-CMB-13 | Skills and Ultimates (data) | TESTED | PARTIAL | P3 | Do not widen before Ring 0 | - | SYS-PRG-05 |
| SYS-CMB-14 | Classes playable in game | TESTED | PARTIAL | P2 | Owner decision on class-select timing; keep Swordsman for Ring 0 | UPG-034 | SYS-PRG-04 |
| SYS-CMB-15 | Weapon movesets (14 families) | DATA ONLY | NOT WIRED | P2 | Make the validator-only status explicit in docs; wire only `wf_sword` after the fun test | UPG-006 | - |
| SYS-CMB-16 | Monster attack data | TESTED | TESTED | P2 | Fix the doc/charter wording; sample red share per Ring 0 monster | - | - |
| SYS-CMB-17 | Telegraph system | TESTED | IMPLEMENTED | P1 | Audit during fun test | UPG-008 | - |
| SYS-CMB-18 | Monster AI brain | TESTED | TESTED | P2 | Keep | - | - |
| SYS-CMB-19 | Aggro tokens | TESTED | IMPLEMENTED | P3 | none | - | - |
| SYS-CMB-20 | Group tactics (flank slots, threat, yield, retreat tweaks) | TESTED | NOT WIRED | P1 | Decide: wire for Ring 0 (needed by fun test item 3 and the last item) or cut those items | UPG-002 | SYS-ECO-09, SYS-CMP-06 |
| SYS-CMB-21 | Bosses: phases and summons | TESTED | IMPLEMENTED | P2 | Keep for Ring 0 (Grukk only) | UPG-007 | - |
| SYS-CMB-22 | Boss armor, break, weak points | TESTED | NOT WIRED | P2 | Decide scope for Ring 0 (Grukk only) | UPG-007 | - |
| SYS-CMB-23 | Combat sandbox | TESTED | n/a | P4 | none | - | - |
| SYS-CMB-24 | Combat feedback | DATA ONLY | IMPLEMENTED | P1 | Fun test item 6 | - | - |
| SYS-CMB-25 | Lock-on / soft lock | n/a | IMPLEMENTED | P3 | none | - | - |
| SYS-CMB-26 | Companion combat | TESTED | TESTED | P3 | Keep | - | SYS-CMP-04 |
| SYS-CMB-27 | Party synergy (assists, signature synergy) | DOCUMENTED | PARTIAL | P3 | Keep to Lyra; no more now | - | SYS-CMP-06 |
| SYS-CMB-28 | Town ward / safe ground | TESTED | TESTED | done | none | - | - |
| SYS-CMB-29 | Magic and chants in combat | DOCUMENTED | DOCUMENTED | P3 | Park to Ring 1 | - | SYS-PRG-06 |
| SYS-CMB-30 | Wounds, part breaks, anatomy, limp/bleed | DOCUMENTED | NONE | P4 | Owner decision | IDEA-009 | - |
| SYS-CMB-31 | Combat progression | TESTED | IMPLEMENTED | P3 | Owner answers P3 | - | SYS-PRG-02 |
| SYS-CMB-32 | Fun-test checklist (combat.md 12) | n/a | NOT RUN | P0 | Run it; reconcile the 6 vs 12 count | UPG-001 | - |

## Character, progression and magic (13)

Responsible: systems-designer / class-skill-designer. Evidence and full notes: `audits/2026-11-12_progression_economy_companions.md`.

| ID | System | Rules layer | In the game | Priority | Next action | Upgrades and ideas | Same system as |
|---|---|---|---|---|---|---|---|
| SYS-PRG-01 | Attributes and derived stats | TESTED | PARTIAL | P2 | Decide auto-allocate versus manual | UPG-035 | - |
| SYS-PRG-02 | Level and XP curve | TESTED | IMPLEMENTED | P4 | none | - | - |
| SYS-PRG-03 | Guild rank F to SSS and promotions | TESTED | PARTIAL | P3 | Confirm Ring 0 stops at E | - | - |
| SYS-PRG-04 | Classes | TESTED | PARTIAL | P1 | Decide Ring 0 class count; add selector for the 12 base kits if wanted | UPG-034 | - |
| SYS-PRG-05 | Skills and kits | TESTED | PARTIAL | P3 | none | - | - |
| SYS-PRG-06 | Magic | PARTIAL | NOT WIRED | P1 | Wire Kind from skill element or school; spend MP; test | UPG-004 | - |
| SYS-PRG-07 | Spell structure, chants, restrictions | DOCUMENTED | DOCUMENTED | P4 | defer | - | - |
| SYS-PRG-08 | Races and origins | DOCUMENTED | DOCUMENTED | P4 | defer | - | - |
| SYS-PRG-09 | Equipment slots | TESTED | IMPLEMENTED | P4 | none | - | - |
| SYS-PRG-10 | Inventory | TESTED | IMPLEMENTED | P4 | none | - | - |
| SYS-PRG-11 | Titles | DATA ONLY | PARTIAL | P4 | defer | - | - |
| SYS-PRG-12 | Style Rank as progression | TESTED | UNCERTAIN | P3 | none | - | - |
| SYS-PRG-13 | Respec and loss rules | PARTIAL | DOCUMENTED | P2 | Add to backlog with SYS-PRG-01 | UPG-035 | - |

## Companions (9)

Responsible: companion-ai-designer / ai-engineer. Evidence and full notes: `audits/2026-11-12_progression_economy_companions.md`.

| ID | System | Rules layer | In the game | Priority | Next action | Upgrades and ideas | Same system as |
|---|---|---|---|---|---|---|---|
| SYS-CMP-01 | Companion roster | TESTED | PARTIAL | P2 | Ring 0 scope decision | IDEA-024 | - |
| SYS-CMP-02 | Recruitment | PARTIAL | IMPLEMENTED | P3 | none | - | - |
| SYS-CMP-03 | Relationship tracks | TESTED | PARTIAL | P3 | none | - | - |
| SYS-CMP-04 | Roles, field AI, orders | TESTED | IMPLEMENTED | P3 | none | - | - |
| SYS-CMP-05 | Presets | TESTED | PARTIAL | P3 | verify | - | - |
| SYS-CMP-06 | Party synergy | TESTED | UNCERTAIN | P3 | check | - | - |
| SYS-CMP-07 | Taming and partners | TESTED | IMPLEMENTED | P3 | none | - | - |
| SYS-CMP-08 | Stables and mounts | TESTED | PARTIAL | P3 | defer | - | - |
| SYS-CMP-09 | Banter | PARTIAL | IMPLEMENTED | P4 | none | - | - |

## Creatures and ecology (14)

Responsible: creature-ecology-designer / bestiary-designer. Evidence and full notes: `audits/2026-11-12_ecology_world.md`.

| ID | System | Rules layer | In the game | Priority | Next action | Upgrades and ideas | Same system as |
|---|---|---|---|---|---|---|---|
| SYS-ECO-01 | Species catalogue | TESTED | PARTIAL | P1 | Fix or deliberately accept the 18 Whisperwood over-band rows before Ring 1 content (data/generator input, bestiary-designer). | UPG-019, UPG-020 | - |
| SYS-ECO-02 | Body plans, families, rigs | TESTED | PARTIAL | P3 | State this plainly in Canon §2's phrasing for new readers; no work needed for Ring 0. | - | - |
| SYS-ECO-03 | Population variants | DATA ONLY | NOT WIRED | P3 | Do not build ecology on these rows. If a spawn table is needed, `encounters.json` is the closer match (SYS-WLD-12). | - | - |
| SYS-ECO-04 | Habitat data | TESTED | NOT WIRED | P2 | See U1/U2: add 3-4 habitat tags to the generator input, not new simulation. | UPG-019 | - |
| SYS-ECO-05 | Regional ecology doc | TESTED | NOT WIRED | P1 | Reuse as the Ring 1 spawn source (U4). | UPG-020 | - |
| SYS-ECO-06 | Species relationships (predator, prey, competition, symbiosis, scavenging, pollination, etc.) | DOCUMENTED | NONE | P2 | U1: derive a role + diet class per species from family/behaviour (generated), then a few hand relationships for Ring 1. | UPG-021 | - |
| SYS-ECO-07 | Life cycle (birth, juvenile, nesting, aging, death, decomposition) | PARTIAL | PARTIAL | P3 | Do not simulate; treat as dens/eggs content (I1). | IDEA-012 | - |
| SYS-ECO-08 | Population dynamics / ecological states / events | DOCUMENTED | NONE | P2 | U2: the cheapest real ecology layer is a 4-state region cycle, authored per region, saved as a few ints. | UPG-021 | - |
| SYS-ECO-09 | Monster behaviour (AI) | TESTED | IMPLEMENTED | P2 | Wire GroupTactics (brief exists), then add one non-combat idle state set (U6). | UPG-002, UPG-023 | - |
| SYS-ECO-10 | Bestiary / Field Journal knowledge | TESTED | TESTED | P1 | Decide one vocabulary (D2), then build research tasks as data. | UPG-011 | SYS-EXP-04 |
| SYS-ECO-11 | Taming, partners, evolution | TESTED | IMPLEMENTED | P3 | Query which tameable species have zero branches (data check). | - | SYS-CMP-07 |
| SYS-ECO-12 | Named monsters and Tyrants | TESTED | PARTIAL | P3 | None for Ring 0. | - | - |
| SYS-ECO-13 | Creature art pipeline | n/a | PARTIAL | P1 | See U9 (scope art to Ring 1 species only) and the backup risk R-ECO-3. | UPG-024 | - |
| SYS-ECO-14 | Monster loot | TESTED | IMPLEMENTED | P4 | none | - | SYS-ECN-04 |

## World (15)

Responsible: world-designer / world-builder-engineer. Evidence and full notes: `audits/2026-11-12_ecology_world.md`.

| ID | System | Rules layer | In the game | Priority | Next action | Upgrades and ideas | Same system as |
|---|---|---|---|---|---|---|---|
| SYS-WLD-01 | Region catalogue | TESTED | IMPLEMENTED | P2 | Add the 40/8/1 breakdown to the owner-facing project summary (see D1); no data change. | - | - |
| SYS-WLD-02 | Region graph | TESTED | NOT WIRED | P3 | Re-run `build_region_graph.js` doc stats or fix the sentence (world-designer). | - | - |
| SYS-WLD-03 | Physical map | TESTED | IMPLEMENTED | P2 | Apply or formally close the pending rewording/move edits (world-designer + lore). | - | - |
| SYS-WLD-04 | Gazetteer and settlements | TESTED | PARTIAL | P3 | Apply the pending edits in one lore pass. | - | - |
| SYS-WLD-05 | Biomes and terrain data | TESTED | n/a | P3 | None for Ring 0. | - | - |
| SYS-WLD-06 | Terrain tiles and Unity status | TESTED | NOT STARTED | P4 | Keep out of Ring 0 scope. | - | - |
| SYS-WLD-07 | Great Labyrinth | TESTED | PARTIAL | P3 | Not before Ring 0. | - | - |
| SYS-WLD-08 | Dungeons and puzzles | TESTED | NOT WIRED | P3 | None now. | - | SYS-EXP-10, SYS-EXP-11 |
| SYS-WLD-09 | Sieges and liberation | TESTED | TESTED | P4 | None; this is the best-proven world system. | UPG-018 | - |
| SYS-WLD-10 | Living world: schedules, events, discovery journal | TESTED | PARTIAL | P1 | Apply the `rumour` and `shop_stock` effects first (cheapest visible result). | UPG-022 | SYS-EXP-08, SYS-EXP-13 |
| SYS-WLD-11 | Day clock, calendar, weather | TESTED | IMPLEMENTED | P2 | Decide whether seasons exist at all (D3) before any ecology event depends on them. | - | - |
| SYS-WLD-12 | Encounter tables | TESTED | NOT WIRED | P1 | U4. | UPG-020 | - |
| SYS-WLD-13 | Inns | TESTED | IMPLEMENTED | P4 | none | - | SYS-ECN-11 |
| SYS-WLD-14 | Streaming / world scale | TESTED | NOT STARTED | P4 | None for Ring 0. | - | - |
| SYS-WLD-15 | Playable space in Unity | n/a | IMPLEMENTED | P0 (protect) | Keep. | - | - |

## Exploration (19)

Responsible: exploration-designer / ui-engineer. Evidence and full notes: `audits/2026-11-12_exploration_quests.md`.

| ID | System | Rules layer | In the game | Priority | Next action | Upgrades and ideas | Same system as |
|---|---|---|---|---|---|---|---|
| SYS-EXP-01 | Traversal: walk/run/sprint/jump/dodge | n/a | TESTED | P4 | Keep out of Ring 0 | - | - |
| SYS-EXP-02 | Climb / glide / swim | NONE | DOCUMENTED | P4 | Decide if Ring 0 needs any | - | - |
| SYS-EXP-03 | Ground mounts | TESTED | PARTIAL | P3 | Defer past Ring 0 | - | SYS-CMP-08 |
| SYS-EXP-04 | Appraisal (monster tiers) | TESTED | TESTED | P1 | Rename in docs; see Problem 1 | UPG-011, UPG-012 | - |
| SYS-EXP-05 | Appraisal (people, items, detective) | NONE | DOCUMENTED | P2 | Design one stat and one flicker for Ring 0 or defer | UPG-012, IDEA-002 | - |
| SYS-EXP-06 | Lying Interface | NONE | PROTOTYPE | P3 | Keep as one line until Act II exists | UPG-016, IDEA-001 | - |
| SYS-EXP-07 | Field Journal (evidence, confidence, hypotheses) | NONE | DOCUMENTED | P2 | Pick one Ring 0 slice (slime/goblin/rabbit) | - | - |
| SYS-EXP-08 | Discovery journal (creature/landmark/region/secret) | TESTED | PARTIAL | P1 | Wire to landmark/mural visit and add a page | UPG-009, UPG-010 | - |
| SYS-EXP-09 | Map knowledge | TESTED | TESTED | P3 | Leave | - | - |
| SYS-EXP-10 | Dungeon knowledge (rooms and clues) | TESTED | PARTIAL | P2 | See SYS-EXP-08 | UPG-009 | - |
| SYS-EXP-11 | Dungeon puzzles | TESTED | DOCUMENTED | P4 | Defer | - | - |
| SYS-EXP-12 | Civilization Archive | TESTED | PARTIAL | P2 | Wire 2 to 3 Whisperwood entries | UPG-009 | - |
| SYS-EXP-13 | Living world events and NPC schedules | TESTED | PARTIAL | P2 | Wire one caravan and Wendel's rumour board line | UPG-022 | - |
| SYS-EXP-14 | Gathering | TESTED | TESTED | P4 | Leave | - | - |
| SYS-EXP-15 | Waystones | NONE | IMPLEMENTED | P4 | Leave | - | - |
| SYS-EXP-16 | Photo mode | TESTED | TESTED | P4 | Leave | - | - |
| SYS-EXP-17 | Guidance channels (diegetic guidance, clue parity) | NONE | DOCUMENTED | P2 | Build the marker on/off switch first | UPG-017, IDEA-016 | - |
| SYS-EXP-18 | Exploration rewards | NONE | DOCUMENTED | P2 | See Upgrade 3 | UPG-018 | - |
| SYS-EXP-19 | Ring 0 exploration prototype (3 discoveries, clue chain) | NONE | DOCUMENTED | P1 | Scope to Upgrade 2 | UPG-009 | - |

## Quests, NPCs and narrative (14)

Responsible: quest-designer / narrative-writer. Evidence and full notes: `audits/2026-11-12_exploration_quests.md`.

| ID | System | Rules layer | In the game | Priority | Next action | Upgrades and ideas | Same system as |
|---|---|---|---|---|---|---|---|
| SYS-QST-01 | Quest engine (QuestLog) | TESTED | TESTED | P2 | Leave, extend Act | - | - |
| SYS-QST-02 | Objective types | TESTED | IMPLEMENTED | P2 | Add 1 or 2 only if Upgrade 2 needs them | - | - |
| SYS-QST-03 | Quest data | TESTED | PARTIAL | P1 | Place missing NPCs or hide quests | UPG-014 | - |
| SYS-QST-04 | Weekly guild board | TESTED | TESTED | P3 | Leave | UPG-033 | - |
| SYS-QST-05 | Escort / defence / siege events | TESTED | TESTED | P3 | Leave | - | - |
| SYS-QST-06 | Story flags and acts | PARTIAL | PARTIAL | P1 | Add Act as data before writing Act II quests | UPG-015 | - |
| SYS-QST-07 | Quest outcome grammar (choices with consequences, receipts) | NONE | DOCUMENTED | P1 | Upgrade 1 | UPG-013 | - |
| SYS-QST-08 | NPC data | TESTED | PARTIAL | P1 | Leave scale; place the 8 missing quest NPCs | UPG-014 | - |
| SYS-QST-09 | NPC dialogue and talk window | n/a | TESTED | P1 | Needs narrative-writer data schema first | UPG-038 | - |
| SYS-QST-10 | Factions, clans, reputation | NONE | DOCUMENTED | P3 | Decide whether Ring 0 has reputation | - | - |
| SYS-QST-11 | Six-act story as data | NONE | PARTIAL | P4 | Out of Ring 0 | UPG-015 | - |
| SYS-QST-12 | Companion story arcs | TESTED | PARTIAL | P2 | Place Hollis | - | - |
| SYS-QST-13 | Companion banter | PARTIAL | UNCERTAIN | P2 | Trace in next pass | UPG-033 | - |
| SYS-QST-14 | Quest tracker / markers | n/a | IMPLEMENTED | P2 | See SYS-EXP-17 | - | - |

## Economy and crafting (12)

Responsible: economy-designer / items-designer. Evidence and full notes: `audits/2026-11-12_progression_economy_companions.md`.

| ID | System | Rules layer | In the game | Priority | Next action | Upgrades and ideas | Same system as |
|---|---|---|---|---|---|---|---|
| SYS-ECN-01 | Currency | TESTED | IMPLEMENTED | P4 | none | - | - |
| SYS-ECN-02 | Shops and vendors | TESTED | IMPLEMENTED | P3 | none | - | - |
| SYS-ECN-03 | Pricing and sell rates | TESTED | IMPLEMENTED | P3 | none | - | - |
| SYS-ECN-04 | Loot tables and monster cores | TESTED | PARTIAL | P3 | owner of economy to sample | - | - |
| SYS-ECN-05 | Materials and gathering | TESTED | IMPLEMENTED | P3 | none | - | - |
| SYS-ECN-06 | Recipes and crafting quality | TESTED | IMPLEMENTED | P3 | none | - | - |
| SYS-ECN-07 | Life skills | TESTED | PARTIAL | P3 | none | - | - |
| SYS-ECN-08 | Meal buffs | TESTED | NOT WIRED | P3 | wire or defer | UPG-037 | - |
| SYS-ECN-09 | Gear runes and enchanting | TESTED | NOT WIRED | P3 | decide whether Ring 0 needs it | UPG-037 | - |
| SYS-ECN-10 | Housing and farming | TESTED | NOT WIRED | P3 | defer past Ring 0 | - | - |
| SYS-ECN-11 | Inns | TESTED | IMPLEMENTED | P3 | none | - | - |
| SYS-ECN-12 | Sinks, faucets, guardrails | DOCUMENTED | PARTIAL | P3 | Defer, but note | UPG-036 | - |

## Production and technology (13)

Responsible: tools-pipeline-engineer / qa-tester. Evidence and full notes: `audits/2026-11-12_technical_production_qa.md`.

| ID | System | Rules layer | In the game | Priority | Next action | Upgrades and ideas | Same system as |
|---|---|---|---|---|---|---|---|
| SYS-TEC-01 | Data validator and schemas | TESTED | n/a | P2 | Make the CI step fail on untracked files under `Data/` | UPG-025 | - |
| SYS-TEC-02 | Generators | TESTED | n/a | P4 | - | - | - |
| SYS-TEC-03 | Continuous integration | TESTED | NONE | P1 | Accept (licence) and compensate with the weekly PC verify run | UPG-026 | - |
| SYS-TEC-04 | Unity PlayMode suite | n/a | TESTED | P0 | PC verify run | UPG-026 | - |
| SYS-TEC-05 | PC update and verify script | n/a | IMPLEMENTED | P1 | Commit a one-line result per run to `QUALITY_GATES.md` §3 | UPG-026 | - |
| SYS-TEC-06 | Player build | n/a | IMPLEMENTED | P3 | With SYS-CORE-03 | UPG-028 | - |
| SYS-TEC-07 | Obsidian vault builder | IMPLEMENTED | n/a | P4 | - | - | - |
| SYS-TEC-08 | Blender pipelines | IMPLEMENTED | PARTIAL | P1 | One asset through the whole chain | UPG-024 | - |
| SYS-TEC-09 | AI image and image-to-3D tools | IMPLEMENTED | n/a | P4 | - | - | - |
| SYS-TEC-10 | Performance measurement | NONE | n/a | P1 | One profiler capture in the Ring 0 field | UPG-027 | - |
| SYS-TEC-11 | Studio layer | IMPLEMENTED | n/a | P3 | Documentation task | UPG-029 | - |
| SYS-TEC-12 | Version control | IMPLEMENTED | n/a | P2 | Owner: prune or push | - | - |
| SYS-TEC-13 | Release and deployment | DOCUMENTED | n/a | P4 | None until the slice gate | - | - |

## Characters (added 2026-11-15)

| ID | System | Rules layer | In the game | Priority | Next action | Upgrades and ideas | Same system as |
|---|---|---|---|---|---|---|---|
| SYS-CHR-01 | Character customization (faces, hair, outfits, gear, colours, silhouettes, creator screen, saving) | TESTED | IMPLEMENTED (not compiled in Unity) | P1 | T-025 verify in Unity | UPG-041 | SYS-PRG-01 |
| SYS-CHR-02 | Generated human bodies (Tools/blender/ascend_characters) with colour-slot masks | TESTED (generator checks; masks verified 2026-11-15) | NOT WIRED (no body imported as the player yet) | P1 | T-026 | UPG-031, UPG-041 | - |

## Counts (150 rows)

Counted from the tables above. Rows that describe the same system from two audits are both counted, so treat these as proportions, not exact totals. No row is VERIFIED or COMPLETE.

| Status | Rules layer | In the game |
|---|---|---|
| TESTED | 98 | 22 |
| IMPLEMENTED | 5 | 41 |
| PARTIAL | 8 | 38 |
| PROTOTYPE | 0 | 1 |
| NOT WIRED | 0 | 15 |
| NOT STARTED | 0 | 2 |
| NOT RUN | 0 | 1 |
| DATA ONLY | 4 | 0 |
| DOCUMENTED | 9 | 13 |
| UNCERTAIN | 0 | 3 |
| NONE | 12 | 4 |
| n/a | 14 | 10 |
