# Audit 2026-11-12: creatures, ecology and the world

AGENT: creature-ecology-designer (with the world-designer view)
MODEL TIER: sonnet
ASSIGNED TASK: audit creatures, ecology and the world as they exist; triage the owner's ecology proposals (AETHWYRD_2 Systems A-O, plus the ecology/world/monster parts of AETHWYRD.odt: Parts 2, 3, 7, 13, 14).
FILES INSPECTED: Canon.md (§2, §4b, §4d, §5, §6 rows 98-102, 140-141, 154-198); CLAUDE.md; 08_Bestiary/regional_ecology.md, monster_design_kit.md; Data/Monsters/{species,population,rigs,motion,attacks,loot_tables,boss_phases,boss_weakpoints}.json (counted by node one-liners); Data/World/{regions,region_graph,physical_map,gazetteer,encounters,living_world,siege_waves,dungeons,labyrinth,inns,world_tuning}.json; Tools/monster_gen/ (listing, region_ecology.js, audit_recipes.js head); Tools/validate/encounter_checks.js; 12_Systems/living_world.md, world_graph.md; 13_Production/creature_system.md, monster_model_pipeline.md, world_terrain.md, terrain_unity_import.md, world_upgrade_plan.md, living_world_v4_audit.md, world_graph_v10_audit.md, handover/group_tactics_wiring.md, ring0_plan.md (sieges/liberation rows), progress_log.md (grep); 01_Core_Concept/borrowed_features.md (#11, #12, #14), world_response_and_information_flow.md; 10_World/reactive_world_and_field_journal.md; Code/Ascend.Core/{MonsterAi,GroupTactics,Taming,Bestiary,LivingWorld,Calendar}.cs (heads and symbol greps); Game/Assets/_Game/Runtime/World/*.cs, Editor/Ring0SceneBuilder*.cs (species grep), Scenes/, Tests/PlayMode (listing); Art/Generation/monster_models.json; .gitignore.
FILES MODIFIED: this report only.

Not inspected / could not do: no Unity or Blender here, so no PlayMode result, no scene opened (the .unity file is 68,540 lines of YAML; I counted species ids in the scene builder, not in the serialized scene). I did not read the 755 Core test bodies, only test file names. I did not run `npm run build` (brief). Proposal docs AETHWYRD_3, Aethwyrd_4 and the catalogue belong to other auditors.

---

## 0. Answers to the four questions, up front

| Question | Answer | Label | Evidence |
|---|---|---|---|
| How many species have ANY structured ecological relationship data? | **0 of 680.** There is no predator, prey, diet, competition, symbiosis, nesting or migration field anywhere in Data/. The only ecology-adjacent per-species data are: `habitats` (region ids, 1-5 each, 1,769 species-region pairs), `behavior` (8 values), `aiPattern` (16 values), `fieldNote`/`look` prose, and the population row `spawn` (Day / Night / Day & Night / Story). 146 species mention eating/hunting/grazing in free `look` text (208 with a wider word list); that is prose, not data. | VERIFIED FACT | node counts over species.json: no key containing prey/predator/diet; `species.json` keys listed in §1 |
| How many species actually spawn in the Unity build? | **19 species are placed by the scene builder** (3 in the Ring 0 field: blue slime, goblin, horned rabbit; 16 more at the Whisperwood edge, including Grukk the Tyrant). Whisperwood sieges spawn 5 more goblin-family species (goblin, goblin archer, goblin shaman, goblin trapper, hobgoblin); only goblin and goblin archer overlap, so **about 22 distinct species** can appear in the shipped scene. The scene builder's Ring 0 slime/goblin/rabbit placements use hand-built FBXs (3 tracked FBXs); every other species is a labelled primitive (capsule) unless the local-only FBX exists on the owner's PC. **Nothing spawns from `population.json` or `encounters.json`: no game code reads either.** | VERIFIED FACT (scene builder and siege data); UNVERIFIED for the serialized scene | Ring0SceneBuilder.cs lines 213-221, Ring0SceneBuilder.Whisperwood.cs (15 more ids), siege_waves.json `siege_whisperwood`; grep of Code/ and Runtime/ for population/encounters consumers found none |
| Does anything simulate populations over time? | **No.** No population counts, densities, growth or migration exist in data or code. `EventDirector` rolls 6 pooled caravan/wanderer events per in-game day (cap 2 active) and its effects are data-only; sieges are a per-region wave scheduler, not a population model. Canon and docs deliberately say "bounded, not simulated". | VERIFIED FACT | population.json row keys (id, name, speciesId, regionId, region, tier, rank, level, size, ring, look, spawn: no count); LivingWorld.cs; living_world.md "Not built (on purpose)" |
| Which regions have any playable Unity content? | **Two of 49:** Whisperwood (the Brindlewick/Millbrook field, per Canon §6 W-decision filed under `reg_whisperwood`) and the first metres of its edge (the Whisperwood builder). One scene exists: `Ring0_Graybox.unity`. No other region has terrain, spawns, a scene or streaming. The region/world map UI covers all 49 as data. | VERIFIED FACT | Game/Assets/_Game/Scenes/ listing (one scene); SiegeDirector/QuestBoard/LocalMapArea default `reg_whisperwood`; `Game/Assets/_Game/Editor/Terrain/TerrainTileImportStub.cs` is a "STUB" that creates no scene objects |

The "about 40 regions" vs 49 question: see SYS-WLD-01. Short answer: 49 rows in `regions.json` = 40 surface + 8 underworld (5 Underworld layers + 3 Great Labyrinth depth bands) + 1 post-game (Vesper). Both numbers are correct; they count different things. VERIFIED FACT (node count over `layer`, Canon §2 line 34, WF2 row).

---

## 1. System table

Priority scale: P0 blocks Ring 0 (January 2027); P1 should land inside Ring 0 if cheap; P2 after Ring 0; P3 later; P4 parked.

### Scope A: creatures and ecology

| System ID | System | Description | Core status | In-game status | Source files (evidence) | Depends on | Known issues | Next action | Priority |
|---|---|---|---|---|---|---|---|---|---|
| SYS-ECO-01 | Species catalogue | 680 species: 287 core + 353 variants (variantKind regional 74, corrupted 54, elemental 86, elder 69, spirit 35, ancient 35) + 40 Tyrants. In the file `tier: core` is 327 (= 287 + 40 Tyrants), `variant` 353. 65 isUnique, 40 isTyrant, 31 families, 8 behaviours, 16 aiPatterns. Generated by Tools/monster_gen. | TESTED (loaded by Data.cs; validator; BestiaryTests) | PARTIAL: 19 species placed by hand, about 22 reachable (see §0) | Data/Monsters/species.json; Tools/monster_gen/generate.js, families.js; Canon §2 line 35 | none | Canon says "287 core" and the file says `tier: core` 327: both true (Tyrants counted as core in the file); worth a footnote. 167 species-region pairs sit above their region's rank band (non-Tyrants), 18 of them in Whisperwood (the first playable region). | Fix or deliberately accept the 18 Whisperwood over-band rows before Ring 1 content (data/generator input, bestiary-designer). | P1 |
| SYS-ECO-02 | Body plans, families, rigs | 25 shared rigs (`rigs.json`), 25 body plans in the Blender generator, 31 families; `motion.json` has per-species locomotion, behaviour radii, attack timings for all 680. | TESTED (MonsterMotionTests, MonsterAiTests) | PARTIAL: motion data drives `MonsterController`/`MonsterAnimator` (procedural animation on any model); no skinned rigs exist | rigs.json (25), motion.json (680 species); MonsterMotionLaws.cs; MonsterAnimator.cs; creature_system.md "Not done yet: Rigs and poses" | none | "25 rigs" in data are motion/physics rigs, not skeletons. creature_system.md says rigs and Unity-ready meshes are not done. | State this plainly in Canon §2's phrasing for new readers; no work needed for Ring 0. | P3 |
| SYS-ECO-03 | Population variants | 6,754 rows = 1,757 distinct (species, region) pairs x 1-7 tiers (Scarred 971, Adult 951, Juvenile 950, Albino 926, Runt 980, Elderborn 945, Alpha 966, Unique 65). Each row: look text, rank, level, size, ring, spawn window. | Data only; read only by the validator and generators (no Core consumer) | NOT WIRED: no game code reads population.json | population.json; grep of Code/, Game/Runtime for consumers (none); Tools/validate/validate.js | species.json | The rows are cosmetic stat/look variants, not populations: no count, density, or habitat zone. 1,769 habitat pairs vs 1,757 pop pairs: 12 pairs have no row. "6,754 population entries" in Canon invites the misreading that this is ecology data. | Do not build ecology on these rows. If a spawn table is needed, `encounters.json` is the closer match (SYS-WLD-12). | P3 |
| SYS-ECO-04 | Habitat data | `habitats`: 1-5 region ids per species (84 have 1, 270 have 2, 216 have 3, 53 have 4, 57 have 5); every one of 49 regions has at least 2 species; 9 regions have under 10. Regions carry `biomes` lists; `physical_map.json` carries per-region `meanTempC`, belt, biome share, area and relief. | TESTED (validator: no orphan species or regions) | NOT WIRED | species.json `habitats`; regions.json `biomes`; physical_map.json `regionStats`; regional_ecology.md (generated) | SYS-WLD-05 | No moisture, vegetation, mana density, shelter, disturbance or season data at any granularity; habitats are region-level only. | See U1/U2: add 3-4 habitat tags to the generator input, not new simulation. | P2 |
| SYS-ECO-05 | Regional ecology doc | `08_Bestiary/regional_ecology.md` is generated (species, band, dominant families, tyrant per region, plus findings). `Data/World/encounters.json` adds per-region themes ("signature", "avoid") and zone tables (roadside/wild/deep/night) for all 49 regions, 500 distinct species referenced. | TESTED (encounter_checks.js, stale check) | NOT WIRED (no game consumer of encounters.json) | regional_ecology.md; Tools/monster_gen/region_ecology.js; encounters.json; 10_World/encounter_tables.md | species.json, regions.json | This is regional identity, not an ecology network. Prose ecology lives in gazetteer.md. | Reuse as the Ring 1 spawn source (U4). | P1 |
| SYS-ECO-06 | Species relationships (predator, prey, competition, symbiosis, scavenging, pollination, etc.) | DESIGN only as principle: monster_design_kit.md gives an "ecological role" sequence (grazer, scavenger, ambusher, territorial defender, pack caller...) and a one-per-species "ecology modifier"; reactive_world_and_field_journal.md describes bounded states. Zero data. | DOCUMENTED | none | monster_design_kit.md lines 187-220; reactive_world_and_field_journal.md lines 78-84 | SYS-ECO-01 | The proposal's System A does not exist as data, schema or code. | U1: derive a role + diet class per species from family/behaviour (generated), then a few hand relationships for Ring 1. | P2 |
| SYS-ECO-07 | Life cycle (birth, juvenile, nesting, aging, death, decomposition) | Not designed beyond: egg nests for taming (borrowed_features #12, Stables rules) and "Juvenile"/"Elderborn" as population tier labels. | Stables egg rules TESTED (StablesTests, MountTests) | Stables wired to save (PlayerWorldState); no field nests | borrowed_features.md #12; 12_Systems/stables.md; Code/Ascend.Core/Stables.cs | Taming | Wild creatures have no age or breeding; tiers are labels. | Do not simulate; treat as dens/eggs content (I1). | P3 |
| SYS-ECO-08 | Population dynamics / ecological states / events | Nothing exists. Closest: bounded state sets in reactive_world_and_field_journal.md; Canon §6 "Borrowed features" proposes Region Ecology Cycles Lean/Storm/Plenty (borrowed_features #14: Besieged regions stuck in Lean, liberation restarts the cycle). That row has no "Decided" note, so it is still an open proposal. | DOCUMENTED | none | borrowed_features.md #14; Canon §6 row 100; no Code hit for Lean/Storm/Plenty | calendar, SYS-WLD-11 | Calendar has weekdays and day parts only: no seasons, no weeks-as-phases, no weather state. The proposal assumes seasonal and weather inputs that do not exist. | U2: the cheapest real ecology layer is a 4-state region cycle, authored per region, saved as a few ints. | P2 |
| SYS-ECO-09 | Monster behaviour (AI) | `MonsterBrain`: states Idle, Chase, Reposition, Windup, Active, Recovery, Staggered, Flee, Return; 8 behaviours / 16 aiPatterns; aggro tokens (max simultaneous attackers); retreat at HP; leash and alert radii from motion.json. GroupTactics (flank slots, yield, threat score) is Core-complete. | TESTED (MonsterAiTests, GroupTacticsTests) | IMPLEMENTED for the combat loop (MonsterController, 485 lines; PlayMode MonsterAi/MonsterAttacks tests). GroupTactics NOT WIRED: only `PackmatesNear` is passed. No feed, sleep, nest, graze, migrate, shelter, scavenge states. | MonsterAi.cs; GroupTactics.cs; MonsterController.cs lines 92-191; handover/group_tactics_wiring.md | motion.json | The ecological behaviours in the proposal (System F) have no state in the brain; only combat states plus `Skittish`/`Passive` wander and flee. | Wire GroupTactics (brief exists), then add one non-combat idle state set (U6). | P2 |
| SYS-ECO-10 | Bestiary / Field Journal knowledge | Core `Bestiary`: 4 kill-based tiers (0 unseen, 1 seen, 2 at 3 kills: HP/element/weakness, 3 at 10 kills or tamed: drops and lore); 100% stamp needs every drop found. Design docs propose a different vocabulary (Unseen / Encountered / Observed / Understood / Mastered; research tasks 4-6 per species, borrowed_features #11; evidence-based hypotheses in open_world_rpg_research_2026.md). | TESTED (BestiaryTests) | IMPLEMENTED and TESTED in game for the kill tiers (PlayerBestiary, BestiaryPlayModeTests; Ring 0 plan records it) | Bestiary.cs lines 9-99; ring0_plan.md Bestiary row; reactive_world_and_field_journal.md lines 70-78 | none | Three different tier vocabularies across code (4 numeric), docs (5 named) and the proposal (6 named). Kill-gated knowledge conflicts with "no kill required" in the design docs. | Decide one vocabulary (D2), then build research tasks as data. | P1 |
| SYS-ECO-11 | Taming, partners, evolution | Taming (calm/fear/food/chance), partner roster with roles (from behaviour), orders by family trainability, evolution into a variant species at bond threshold (`Partners.Branches` = species with matching `baseSpeciesId`), level follows player. | TESTED (TamingTests) | IMPLEMENTED (PlayerTaming, PartnerFollower, TamingPlayModeTests) | Taming.cs lines 54-262; Runtime/Player/PlayerTaming.cs; Runtime/World/PartnerFollower.cs | Bestiary | Evolution is "swap to a variant species", so only species with variants can evolve; no check seen that every tameable core species has a branch. UNVERIFIED. | Query which tameable species have zero branches (data check). | P3 |
| SYS-ECO-12 | Named monsters and Tyrants | 40 regional Tyrants (one per besieged region), 65 uniques; Canon §4d locked: hand-written roster, no hierarchy, grow with region state not with defeating the player. Boss phases and weak-point data exist (boss_phases.json, boss_weakpoints.json). | TESTED (BossPhaseTests, BossWeakPointTests, Siege tests) | PARTIAL: Grukk (Whisperwood Tyrant) fought and liberation works; the other 39 Tyrants are data only | species.json isTyrant (40); regions.json `tyrantSpeciesId` (40); siege_waves.json (40 entries); Canon §4d | Siege | Canon §6 W5 (Mycelia B+ vs C) is decided as B+. | None for Ring 0. | P3 |
| SYS-ECO-13 | Creature art pipeline | THREE statuses disagree. (a) creature_system.md: a Blender procedural generator for all 680 species, libraries local-only, no rigs, not game meshes. (b) monster_model_pipeline.md: the plan is to AI-generate all 680 (Tripo), Ring order. (c) `Art/Generation/monster_models.json`: 677 entries, all `status: blockout`, all provider "procedural (bestiary_models.py)", i.e. low-poly blockouts, zero AI-generated. In git: 3 FBX (Blue_Slime, Goblin, Horned_Rabbit) + `.blend` stubs of 131 bytes (LFS pointers); `Art/Blender/CreatureLibrary` holds only a catalog file; the per-species FBX folders are gitignored. | n/a | Ring 0's 3 species have models; everything else renders as capsules unless the owner's PC has the local FBXs | creature_system.md; monster_model_pipeline.md; Art/Generation/monster_models.json (counted); .gitignore lines 36-37; `find` shows 3 monster FBX tracked | Blender | A clean checkout cannot reproduce any monster visuals beyond Ring 0's three. Registry says "677" while species are 680 (3 Ring 0 hand-built models account for the gap, VERIFIED by arithmetic). creature_system.md says the Forest Wolf has antlers in the data; the data no longer does (recipe parts are claws, fur_tufts): stale doc line. | See U9 (scope art to Ring 1 species only) and the backup risk R-ECO-3. | P1 |
| SYS-ECO-14 | Monster loot | 221 loot tables keyed by family and rank; species point at them. | TESTED (Loot tests, validator) | IMPLEMENTED for Ring 0 species (DeathAndLoot PlayMode tests) | loot_tables.json; DeathAndLootPlayModeTests.cs | items | none relevant here | none | P4 |

### Scope B: world

| System ID | System | Description | Core status | In-game status | Source files (evidence) | Depends on | Known issues | Next action | Priority |
|---|---|---|---|---|---|---|---|---|---|
| SYS-WLD-01 | Region catalogue | `regions.json`: **49 rows = 40 surface + 8 underworld + 1 post-game**. The 8 underworld rows are 5 Underworld layers (Umbravel, Hollow Sea, Aurumdeep, The Maw, Root of the World) + 3 Great Labyrinth depth bands (Floors 1-40, 41-90, 91-120). Vesper is post-game. 40 have a Tyrant and are `besieged`; 9 are `liberated` from the start with `noSiege` (the 3 Labyrinth bands, Sky Archipelago and others without a Tyrant). Each has rank band, biomes, ring, map anchor and places. | TESTED (validator; GameDatabase) | IMPLEMENTED as data in game (world map, local map, region lines) | Data/World/regions.json (node count by `layer`); Canon §2 line 34; Canon §6 WF2 | none | Why numbers differ: the owner says "about 40" (surface); the validator counts all rows (49); region_graph has 40 nodes (surface only). The `ring` of regions.json (1-9) is a separate concept from "Ring 0/1" in the plan; the Ring 0 field belongs to Whisperwood (Ring 1 band F-E), which is why species.json has 3 ring-0 species but no ring-0 population rows. | Add the 40/8/1 breakdown to the owner-facing project summary (see D1); no data change. | P2 |
| SYS-WLD-02 | Region graph | 40 nodes (surface), 100 edges (10 road, 3 pass, 1 sea, 85 border, 4 under 1 km not walkable... see issue), Dijkstra shortest path, orphans/components, travel options. Generated from physical_map. | TESTED (RegionGraphTests; graph_checks; graph findings 0 per the brief) | NOT WIRED (no Runtime reference to RegionGraph) | Data/World/region_graph.json (node count 40, edges 100); Code/Ascend.Core/RegionGraph.cs; world_graph.md | physical_map | world_graph.md says "99 edges (10 road, 3 pass, 1 sea, 85 border)": that sums to 99; the file has 100 edges, so the doc total is one behind (likely the WF3 Isles sea leg, which is now 2 sea legs or a border added). UNVERIFIED which. | Re-run `build_region_graph.js` doc stats or fix the sentence (world-designer). | P3 |
| SYS-WLD-03 | Physical map | 150 x 100 km, 0.5 km cells: heights, 30 rivers, 21 lakes, ranges, 4 passes, 5 trade corridors, 13 roads, 51 settlements, per-region stats (mean temp, belt, biome share). Validator: 0 errors, 28 warnings (brief). | TESTED (WorldMapTests, validator) | IMPLEMENTED in game as the map windows (MapPlayModeTests) | physical_map.json (keys counted); world_upgrade_plan.md | atlas tools | 28 warnings: steep settlements, 2 on lake cells, roads over grade; owner decisions W3, W7b are recorded as "decided by Claude under delegated creative control, pending the move list; nothing moved" so data still has the issues. | Apply or formally close the pending rewording/move edits (world-designer + lore). | P2 |
| SYS-WLD-04 | Gazetteer and settlements | 49-region gazetteer (gazetteer.json, gazetteer.md 1,950 lines), 51 settlements, 20 signature inns, 51 blurbs (drafts, world_upgrade_plan wave 4). | TESTED (validator) | PARTIAL: Brindlewick, Millbrook, treeline camp built; one more edge; the rest are data and map labels | gazetteer.json (49), physical_map.json settlements (51), inns.json (20) | regions | W7a items (Friendly Goblin ownership, Vharlen capital split) decided but "data and gazetteer edits pending; not applied". | Apply the pending edits in one lore pass. | P3 |
| SYS-WLD-05 | Biomes and terrain data | Atlas biome legend (plains, forest, swamp, steppe, mountain, volcanic, tundra, desert, jungle, spirit, demon, alpine, snow, beach, lake); per-region biome share; climate belts with temperature function. | TESTED | n/a | physical_map.json `biomes`, `climate` | none | No moisture, wind, vegetation density or season fields; weather is not derivable. | None for Ring 0. | P3 |
| SYS-WLD-06 | Terrain tiles and Unity status | Blender builds 10 km tiles (150 tiles, 6 sectors, proven seam-free) into gitignored `Art/Blender/WorldTerrain/`. Unity import spec says rebuild at 10.24 km with 513-sample heightmaps. Unity side: only `TerrainTileImportStub.cs`, "STUB... creates NO scene objects", writes to a throwaway folder. | Scale helper TESTED (WorldScale.cs, WorldScaleTests) | NOT STARTED: no terrain in any scene; Ring 0 is a graybox with a flat ground | terrain_unity_import.md; TerrainTileImportStub.cs lines 8-18; world_terrain.md; scene listing (1 scene) | 10.24 km decision (WF9 decided; builder rerun) | Tile files are not in the repo (gitignored) so a clean checkout cannot import any tile. | Keep out of Ring 0 scope. | P4 |
| SYS-WLD-07 | Great Labyrinth | 120-floor registry (`labyrinth.json`: bands, decades, stairs, back doors, resets), three depth-band regions, floor knowledge record (Heard/Visited). One dungeon (Salvage Warren, floors 3-4, 6 hand-designed rooms). | TESTED (LabyrinthTests, DungeonTests, DungeonKnowledgeTests) | PARTIAL: map and journal windows read it; no floor, stairs or Warren geometry in Unity (grep: no "warren" in Game/) | labyrinth.json (120 floors); dungeons.json (1 dungeon); Labyrinth.cs; JournalWindow.cs | dungeons | Only 1 of the designed dungeon content exists; floors are registry rows, not levels. | Not before Ring 0. | P3 |
| SYS-WLD-08 | Dungeons and puzzles | Room graph, checkpoints, optional secret, 3 puzzle types (lever sequence, etc.), puzzles.json. | TESTED (DungeonTests, PuzzleTests) | NOT WIRED (Puzzle only in AscendData load) | dungeons.json; puzzles.json; Runtime grep (Puzzle: 1 file) | Labyrinth | Content is one dungeon. | None now. | P3 |
| SYS-WLD-09 | Sieges and liberation | Region threat state, scheduler (1-2 raids per 7 days, never consecutive days), waves from `siege_waves.json` (40 regions, 157 distinct species), escalation, defence spots, liberation on Tyrant death (Canon §4b). | TESTED (SiegeTests, SiegeBattleTests) | IMPLEMENTED and TESTED for Whisperwood only (SiegeDirector regionId default; SiegePlayModeTests; Ring 0 plan records live raids and liberation) | siege_waves.json; Siege.cs; SiegeDirector.cs; ring0_plan.md rows "Sieges", "Liberation" | Tyrant, quests | The other 39 regions' waves are data only. | None; this is the best-proven world system. | P4 |
| SYS-WLD-10 | Living world: schedules, events, discovery journal | NPC schedule resolver (6 NPCs have schedules), EventDirector (6 pooled events: 3 caravans, 3 wanderers; cap 2 active, 1 per region; deterministic by seed+event+day), DiscoveryJournal (Unknown/Heard/Visited, categories region/landmark/creature/secret). | TESTED (LivingWorldTests, 21 tests per v4 audit) | PARTIAL: `PlayerWorldState` calls `EventDirector.Advance` on day change and saves state (line 273); nothing applies the four effect kinds (stock, rumour, small encounter, board note); schedules not used by NPC placement (no `NpcSchedule` in Runtime) | LivingWorld.cs; living_world.md; living_world_v4_audit.md; PlayerWorldState.cs lines 18, 53, 273 | Calendar | "nothing is wired into Unity yet" in living_world.md is slightly out of date: save and Advance are wired; effects are not. | Apply the `rumour` and `shop_stock` effects first (cheapest visible result). | P1 |
| SYS-WLD-11 | Day clock, calendar, weather | `WorldClock` (Unity) + `GameCalendar` (weekdays, day parts Morning/Day/Dusk/Night, play-seconds to day/hour, dawn). Audio has weather ids and gains (EnvironmentAudio.cs). | TESTED (RestAndClockTests, AudioWaveDTests) | IMPLEMENTED (day/night sun, sleep until dawn, InnAndClockPlayModeTests) | Calendar.cs; WorldClock.cs; EnvironmentAudio.cs | none | **No seasons and no gameplay weather system exist.** Weather is an audio label only. Quest doc mentions "Dragon Migration | Autumn" (quests_and_encounters.md line 138) with no season clock behind it. | Decide whether seasons exist at all (D3) before any ecology event depends on them. | P2 |
| SYS-WLD-12 | Encounter tables | `encounters.json`: all 49 regions, themes, rates, zone tables (roadside, wild, deep, night), group rules, 500 distinct species; generated with 10_World/encounter_tables.md; validator checks band, no Tyrant/unique in tables, staleness. | TESTED (validator only; no Core reader class) | NOT WIRED | encounters.json; Tools/validate/encounter_checks.js; Tools/world/build_encounters.js | species, regions | Valuable, finished data with no consumer: Ring 0 spawns are hand-placed. | U4. | P1 |
| SYS-WLD-13 | Inns | 20 signature inns plus rules (rest, meals, rumour board, mail). | TESTED (BoardAndInnTests, Inns.cs) | IMPLEMENTED (PlayerRest, NpcDialog; InnAndClock tests) | inns.json (20); Inns.cs | none | none relevant | none | P4 |
| SYS-WLD-14 | Streaming / world scale | `WorldScale` (1 map unit = 1 km, 10.24 km tiles, origin NW corner, coordinate helpers, 15 x 10 tiles). Streaming itself: not started (world_graph.md section 7: out of scope). | TESTED (WorldScaleTests) | NOT STARTED | WorldScale.cs; world_graph.md | terrain | Unity scene is a single small graybox. | None for Ring 0. | P4 |
| SYS-WLD-15 | Playable space in Unity | One scene: `Ring0_Graybox.unity` (Brindlewick town, Millbrook fields and well, treeline camp, Whisperwood edge, waystones). Standalone build recipe exists (`BuildPlayer.BuildRing0`). | n/a | IMPLEMENTED; PlayMode recorded 183 passed on 2026-11-08 (progress_log), not re-run | Scenes/; Ring0SceneBuilder*.cs; progress_log.md | all | Two different "ring" meanings (plan Ring 0 vs data ring 1-9) confuse counts. | Keep. | P0 (protect) |

---

## 2. WHAT IS MISSING (designed or promised, not built)

1. **Any ecological relationship data** (System A): no schema, no data, no code. Only design principles (monster_design_kit.md "ecological role", reactive_world doc "state set").
2. **Habitat zones within a region** (System B): habitats are region-level strings. `encounters.json` zones (roadside/wild/deep/night) are the only sub-region idea, and they are not read by the game.
3. **Seasons and gameplay weather** (inputs to Systems B, G, H): calendar has weekdays and day parts only.
4. **Lean/Storm/Plenty region cycle** (Canon §6 Borrowed features #14, still an open proposal): not built.
5. **Population state per region**, rare-variant distribution, migration: none. Population rows have no counts.
6. **Non-combat monster behaviours** (feed, rest, sleep, nest, migrate, shelter, scavenge): the brain has combat states only.
7. **Group tactics wiring** (flank slots, yield, threat): Core done, Unity brief written, not wired.
8. **Ecological events** with clues and responses (System H): only the 6-row caravan/wanderer pool, with effects unapplied.
9. **Research tasks** (4-6 per species, borrowed_features #11) and non-kill research routes: not built; the live Bestiary is kill-gated.
10. **Encounter tables in the game**: finished data, no spawner.
11. **Regions beyond Whisperwood**: no terrain, scene, spawns or streaming. Terrain Unity importer is a stub.
12. **Skinned rigs, game-ready monster meshes (baked low-poly, LODs)**, and a durable home for monster models (local only).
13. **Great Labyrinth floors as places**, the other 39 Tyrant fights, and any dungeon besides the Warren data.

---

## 3. PROBLEMS IDENTIFIED

| # | Problem | Evidence | Type |
|---|---|---|---|
| P-1 | The owner's ecology brief (AETHWYRD_2) assumes existing "Full, Reduced, Low and Inactive simulation levels" and "existing... regional state". Neither exists. grep for Inactive/Reduced/simulation level finds only accessibility and music words; the only "simulation level of detail" text is in research notes about Kingdom Come: Deliverance II. | grep over Code/, Game/Runtime; open_world_rpg_research_2026.md | Contradiction between proposal and repo (VERIFIED FACT) |
| P-2 | "6,754 population variants" is not population data: it is species x region x tier labels with no counts, and nothing in Code or Game reads it. | population.json keys; consumer grep | Misleading number |
| P-3 | Three Bestiary tier vocabularies: Core 4 numeric kill tiers; reactive_world doc "Unseen to Mastered" (5); proposal 6 (adds Investigated). Kill-gated knowledge also contradicts "no tier should require killing" in the design doc. | Bestiary.cs lines 26-28, 83-96; reactive_world_and_field_journal.md line 70; AETHWYRD_2 System K | Doc/code conflict |
| P-4 | 18 species in Whisperwood (band F-E) and 167 species-region pairs overall are above their region's rank band; Whisperwood is the one region actually playable. | regional_ecology.md Findings; node recount by region | Data defect for the first region (VERIFIED FACT) |
| P-5 | Monster models: registry says 677 "blockout" procedural models; pipeline doc says AI-generate all; creature_system.md describes a high-poly Blender generator; none of these are in git beyond 3 FBXs, and the registry note says the FBXs are local-only. Three docs, three different stories. | monster_models.json; monster_model_pipeline.md; creature_system.md; .gitignore | Doc contradiction plus single-PC dependency |
| P-6 | creature_system.md "Not done yet" still says the Forest Wolf recipe has antlers; the data has `claws, fur_tufts`. `audit_recipes.js` exists to catch this class of issue. | species.json mon_forest_wolf | Stale doc line |
| P-7 | living_world.md says "nothing is wired into Unity yet"; PlayerWorldState does call `EventDirector.Advance` and saves it. Effects remain unapplied. | PlayerWorldState.cs 273 | Stale doc line |
| P-8 | world_graph.md totals (99 edges: 10 road, 3 pass, 1 sea, 85 border) differ from the file (100 edges). | region_graph.json edge count | Doc/data drift |
| P-9 | Many W-row decisions (W3, W7a, W7b) are recorded as decided but "edits pending; not applied". The data still has the findings; the validator keeps 28 warnings. | Canon §6 lines 175-180; brief: 28 map warnings | Open work shown as closed |
| P-10 | Region count confusion: Canon says "40 surface + 5 Underworld layers + Labyrinth + Vesper"; regions.json has 49 rows; graph has 40 nodes; ring numbers mean two different things. | Data/World/regions.json; Canon line 34; WF2 | Wording, not a defect |
| P-11 | No season or weather system, yet Canon-adjacent docs and the proposal use seasons (Dragon Migration "Autumn", "seasonal recovery"). | Calendar.cs; quests_and_encounters.md line 138 | Missing prerequisite |

### Canon conflicts (kept separate)

| # | Conflicting documents and sections | Why it matters | Recommended resolution |
|---|---|---|---|
| C-1 | AETHWYRD_2 rules 8 and 12, System L ("Extend the existing Full, Reduced, Low and Inactive levels") vs repo (no such levels). Not a Canon conflict but a false premise that would push an agent to invent a parallel system. | A generic agent following the prompt will build a second simulation layer. | Tell the owner these levels do not exist (D4); define the minimal tier rule in one paragraph first (near player: real AI; region: a few ints; far: nothing). |
| C-2 | AETHWYRD_2 System C/J (death, extinction-adjacent: "natural death", "Hunting can change local predator pressure") vs Canon §5 and the ecology designer rule: no ordinary action causes permanent extinction. | Players can wreck a 1,000-hour save's content. | Every population number floors at a recovery minimum (e.g. never below 1 band step) and recovers on a clock; add this as a stated rule in the Canon §6 proposal for ecology. |
| C-3 | Proposal Part 3 ("regional legendary encounters connected to local history", "rare roaming monsters") and System C vs Canon §4d (named monsters hand-written, no hierarchy, grow only with region state; no personal memory). | A roaming rare monster that "remembers" the player or promotes from a population would violate §4d and the Nemesis-patent guard. | Keep roaming rares as authored, region-state-triggered, memoryless events. |
| C-4 | Borrowed-features Lean/Storm/Plenty (Canon §6 row 100, open) vs proposal System E (8 states). Two overlapping ecology state vocabularies. | One cycle model should be the Canon one. | Approve one (recommend the 4-state version in U2) and retire the other. |
| C-5 | Canon §6 "Brindlewick's region" (decided Whisperwood by Claude, user may overrule) vs world.md sub-zone list and most Ring 0 quests filed `reg_aldmere`. | Ecology tables for the Ring 0 field depend on which region it is. | Already decided; the quest-designer tidy-up is outstanding (SYS-WLD-01). Confirm with the owner (D6). |

---

## 4. Triage of the owner's proposals

Labels: ALREADY BUILT / ALREADY DESIGNED (where) / UPGRADE candidate / IDEA candidate / CONFLICTS WITH CANON / TOO COSTLY NOW. "Extends" means it plugs into something that exists.

### AETHWYRD_2.docx (Ecology), by system

| Item | Verdict |
|---|---|
| Non-negotiable rules 1-4 (preserve species, rigs, generator, data) | ALREADY BUILT as constraints; agree and adopt as the rule set for any ecology work. |
| Rule 8 "build on existing Field Journal, Appraisal, Bestiary, monster AI, regional state" | Partly false premise: Bestiary, monster AI, region siege state exist; "regional state" is siege threat only; ecology state does not exist. See P-1. |
| Rule 9, 10 (no continuous full simulation; no irreversible extinction) | ALREADY DESIGNED (reactive_world_and_field_journal.md "Ecology stays bounded"; Canon §5; creature-ecology-designer rules). Adopt. |
| A. Relationship network (predator/prey/competition/symbiosis/parasitism/scavenging/decomposition/pollination/seed dispersal/territorial/avoidance/magical dependency; strength, conditions, effects) | UPGRADE candidate (U1) at heavily reduced scope: 4-6 relationship types, 30-60 hand-picked pairs for Ring 1, the rest derived from role. The full 11-type, all-species network is TOO COSTLY NOW (680 species, two people). |
| B. Habitat network (temperature, moisture, water, food, vegetation, mana, shelter, terrain, light, disturbance, season, stability; local habitat zones) | UPGRADE candidate (U1/U2) reduced to 3-4 tags per habitat zone; 12 continuous variables is TOO COSTLY NOW. Temperature already exists per region (physical_map regionStats); zones already exist as encounter zones (roadside/wild/deep/night). |
| C. Life cycle (birth to decomposition per species) | TOO COSTLY NOW as a per-species model. The useful 10%: egg nests/dens (ALREADY DESIGNED, borrowed_features #12) and "juvenile/elder" labels (ALREADY BUILT as population tiers). |
| D. Population dynamics (bounded bands, causes, recovery) | UPGRADE candidate (U2, U3): 3-5 abstract bands for a few "monitored species" per region, as already sketched in world_response_and_information_flow.md section 11 ("Ecology: a few monitored species populations"). Not all 680 species. |
| E. Ecological states (8 states) | UPGRADE candidate (U2) reduced to 4 (Lean, Normal, Plenty, Storm) aligned with Canon §6 #14; the other four (Imbalanced, Disrupted, Corrupted, Calamity-affected) map onto existing siege/Vesper-corruption/liberation state and should not be a second system. CONFLICTS partly with C-4 until one vocabulary is chosen. |
| F. Monster behaviour (feeding, hunting, fleeing, resting, sleeping, nesting, defence, pack, competition, migration, shelter, scavenging) | UPGRADE candidate (U6): fleeing, pack, territorial defence already exist in the brain; add 2-3 ambient states (rest/graze, den guard, shelter in rain once weather exists) for selected species. The rest is TOO COSTLY NOW. |
| G. Environmental response (rain, drought, mana surge, cold, habitat destruction, seasons) | TOO COSTLY NOW: requires seasons and weather, which do not exist (P-11). Defer; a single authored weather trigger per region is an IDEA (I3). |
| H. Ecological events (10 kinds, each with trigger, clues, responses, resolution) | UPGRADE candidate (U7) and IDEA candidate (I2): authored, per region, 1-2 events for Ring 1, built as `EventDirector` pool rows (ALREADY BUILT engine, effects unapplied). Full 10-kind framework is TOO COSTLY NOW. |
| I. Player interaction (appraisal, tracking, observation, research, journal, contracts, hunting, gathering, crafting, companions, settlement, exploration) | ALREADY DESIGNED in part (research_expansion_2026-10-24.md, reactive_world doc, borrowed_features #11, #20 ecology-to-economy bridge in world_response doc §12). UPGRADE candidate U5 (research tasks) for the Bestiary. |
| J. Ecological consequences (hunting changes predator pressure, nest destruction, habitat restoration, invasive removal, liberation changes encounters) | ALREADY DESIGNED (reactive_world doc: "Player-driven ecology change should have a limit and a recovery path"; liberation switches boards to hunting contracts, Canon §4b). Liberation-changes-encounters is cheap (swap the encounter table when region state flips): UPGRADE candidate U4. Others TOO COSTLY NOW. |
| K. Bestiary and research (6 research states, progressive unlocks, alternative methods for intelligent species) | UPGRADE candidate (U5). Conflicts with the existing 4 kill tiers (P-3). Needs owner vocabulary decision (D2). Alternative methods for intelligent species is ALREADY DESIGNED (reactive_world doc line 72). |
| L. Technical architecture (static vs mutable state, save persistence, bounded deterministic updates, reuse Full/Reduced/Low/Inactive) | ALREADY BUILT as a pattern (DeterministicRandom, EventDirector save with null-coalescing upgrade, SaveGame.LivingWorld). The Full/Reduced/Low/Inactive levels do not exist: false premise (C-1). |
| M. Regional ecology identity (profile per region) | ALREADY BUILT at the data level: `encounters.json` theme (pacing, signature, avoid) for all 49 regions, regional_ecology.md (generated), gazetteer prose. Missing: food sources, predators and relationships per region (U1). |
| N. Content production templates (species ecology, habitat, relationship, migration events, clues, consequences) | UPGRADE candidate U1 (generator input as the template; no hand-authoring per species). |
| O. Testing and validation (invalid relationships, missing species, impossible habitats, bounds, determinism, save/load, tier transitions, extinction protection) | ALREADY BUILT as a method (the validator pattern, Core tests, deterministic RNG); to be applied to any new ecology data from day one. Tier transitions test depends on levels that do not exist. |
| Final deliverables 1-15 (audit, inventory, schemas, simulation architecture, roadmap, budget, risk list) | This report delivers 1-3 and 15 in outline; schemas and architecture are a follow-up task once the owner decides D2-D5. A 15-item deliverable list at once is TOO COSTLY NOW for the owner's time. |
| Final philosophy ("monsters have habitats, needs, routines, relationships, territories") | Matches Canon direction and the existing design kit; adopt as the north star. |

### AETHWYRD.odt, ecology / world / monster parts

| Item (Part) | Verdict |
|---|---|
| P2: distinctive daily behaviour; feeding behaviours; rest/sleep/nest | UPGRADE candidate (U6). `spawn` Day/Night is the only activity data today. |
| P2: predators hunt prey; prey flee from predators | UPGRADE candidate (U1 relationships, U6 behaviour); fleeing from the player exists (`Skittish`). Predator-prey between monsters not built; start with an authored pair in one region. |
| P2: territorial behaviour | ALREADY BUILT (144 Territorial species, `territorial_guard`, leash radius in motion.json). |
| P2: migration between regions; populations respond to regional change; environmental conditions influence activity | UPGRADE candidates U2/U3, bounded to a few species; "migration between regions" as authored events (I2). Full version TOO COSTLY NOW. |
| P2: rare variants within families | ALREADY BUILT (353 variants; Albino/Alpha/Elderborn tiers in 6,754 rows). |
| P2: elite behaviours, distinctive group formations, proximity responses, warning behaviours | ALREADY BUILT in part (aggro tokens, telegraphs, flank slots in Core); group formations UPGRADE candidate (U6, GroupTactics wiring). Warning telegraphs exist (the "!" and shrinking ring in MonsterController). |
| P2: ecological interactions between compatible species | UPGRADE candidate (U1). |
| P3: boss mechanics, optional challenges, hidden conditions, arenas, hazards, phases, unique rewards | ALREADY DESIGNED/BUILT (boss_phases.json, boss_weakpoints.json, boss_encounter_storytelling.md); belongs to combat-designer. |
| P3: rare roaming monsters under conditions; regional legendary encounters | IDEA candidate (I4) but only authored and memoryless; CONFLICTS WITH CANON if promoted/remembering (C-3). |
| P3: "do not give individual monsters memories, scars, taunts" | ALREADY locked (Canon §4d). |
| P7: expand world preserving geography; regional identities; points of interest; hazards; wildlife; wilderness-settlement interaction; mysteries | ALREADY DESIGNED (gazetteer.md, "Regional memory atlas" Canon §6 row 140, world_response_and_information_flow region kit); content work, not systems. Regional wildlife and settlement-wilderness link is U4/I1. |
| P7: improve visual identity of regions | Art-director/environment-artist; terrain is not in Unity yet (TOO COSTLY NOW). |
| P13: regional world events, siege/liberation expansion, settlement defence scenarios, recovery objectives, visible settlement response to liberation, environmental change after events, communication of consequences, reputation | ALREADY BUILT at the Whisperwood level (sieges, liberation raises prosperity, hunting contracts); ALREADY DESIGNED (world_response_and_information_flow.md local response bundles, state-change budget). UPGRADE candidate U7 (generalise the Whisperwood liberation response as a data bundle for the next region). |
| P14: ambience, weather presentation, creature animations | Weather presentation needs a weather system (P-11, D3); creature animation has a procedural layer (MonsterAnimator) and an animation audit (animation_v11_audit.md); belongs to technical-artist/audio. |

---

## 5. UPGRADE candidates (existing systems), strongest first

### U1. Ecology Tags: generated role, diet class and a short relationship list
- **Existing system:** species.json generator (Tools/monster_gen), monster_design_kit.md "ecological role".
- **Current status:** role is DESIGNED in prose; no data. 0 of 680 species carry any relationship field.
- **Current problem:** every ecology idea in the proposal needs "what is this species, what does it eat, what avoids it", and the generator already knows family, behaviour, aiPattern and size.
- **Evidence:** species.json keys (no ecology fields); monster_design_kit.md lines 187-220.
- **Proposed improvement:** a new generated file `Data/Monsters/species_ecology.json` (one row per species: `role` from a 10-value list, `diet` class (herbivore, carnivore, scavenger, omnivore, none/magical, mana), `activity` from existing `spawn`, plus 0-3 `relations` of 4 types: preys_on, avoids, competes_with, depends_on). Roles and diets come from family+behaviour rules in the generator; relations are authored only for the Ring 1 species (about 40 in Whisperwood, F to E) and added elsewhere later. Bestiary-designer owns generator inputs; creature-ecology-designer proposes the schema to tools-pipeline-engineer first.
- **Player benefit:** later, believable "wolves hunt rabbits" signs and journal text; no change to fights yet.
- **Technical/gameplay benefit:** one source of truth for every later system (spawns, clues, research, events); validator catches missing species references.
- **Dependencies:** owner decision D2 and D5; tools-pipeline-engineer schema review.
- **Affected files:** Tools/monster_gen (new input and output), Data/Schemas (new schema), Tools/validate (new checks), Code/Ascend.Core/Data.cs (loader, optional).
- **Priority:** P2 (after Ring 0). **Complexity:** M. **Risk:** role rules produce silly results on odd species (swarms, constructs); mitigate with a per-species override file and an audit script like `audit_recipes.js`.
- **Acceptance criteria:** 680 rows; every relation references an existing species; no species with `role: none` except constructs/spirits by rule; `npm run build` passes; regenerated output committed (CI stale-check).
- **Testing:** validator rules for missing species and self-reference; a Core test that loads the file; a determinism check (regen twice, identical bytes).

### U2. Region ecology cycle: four states, saved as a few ints
- **Existing system:** Canon §6 Borrowed features #14 (Lean/Storm/Plenty), siege state, `EventDirector`, `SaveGame.LivingWorld`.
- **Current status:** DOCUMENTED, unbuilt, Canon row open.
- **Current problem:** the world has no state a player can read that says "this region is thriving or hurting"; siege threat is the only region state.
- **Evidence:** borrowed_features.md #14; Calendar.cs has no phases.
- **Proposed improvement:** per region one of Lean, Normal, Plenty, Storm, advancing by in-game week from a seed; Besieged regions stay Lean; liberation restarts the cycle (as the doc says). State changes only the encounter table weighting (U4), 1-2 gather-node availability flags, and one rumour line. No per-creature simulation. Cost: one small enum per region (49 bytes of save), one cheap roll per week.
- **Player benefit:** the same field feels different next week; liberation shows up as the land recovering; reasons to revisit.
- **Technical benefit:** the only ecology state machine that fits the 4-5 hours a week constraint.
- **Dependencies:** D3 (seasons or not), U4.
- **Affected files:** living_world.json (cycle table), LivingWorld.cs (new rule), PlayerWorldState, encounters.json weighting.
- **Priority:** P2. **Complexity:** M. **Risk:** player confusion without a visible sign; require at least one environmental sign per state.
- **Acceptance:** same seed gives the same sequence; a besieged region never leaves Lean; liberating moves it out within one week; save/load stable; old saves load.
- **Testing:** Core determinism and save round-trip tests; a Whisperwood PlayMode check that the table swap changes the spawn list.

### U3. Fix region rank-band defects before any ecology is layered on
- **Existing system:** species habitats, regions rankMax, regional_ecology.md Findings.
- **Current status:** IMPLEMENTED data with a reported finding (167 pairs over band).
- **Current problem:** Whisperwood, the first playable region, lists 18 species above its F-E band (e.g. Hobgoblin E+, Needle Wasp E+). Any spawner reading `habitats` would put them in Ring 1.
- **Evidence:** regional_ecology.md Findings; recount by region (Whisperwood 18, Aldmere 13, Labyrinth abyss 16, Vesper 16).
- **Proposed improvement:** decide per pair: widen the band, drop the habitat, or mark the species "rare deep zone". Fix Whisperwood and Aldmere first.
- **Player benefit:** no E+/D- surprise in the F-E opening.
- **Technical benefit:** the encounter validator and the species habitats agree.
- **Dependencies:** bestiary-designer (generator inputs); owner D7 on band width.
- **Affected files:** Tools/monster_gen inputs, regenerated species.json/population.json, regional_ecology.md.
- **Priority:** P1. **Complexity:** S. **Risk:** low; touching generated data requires rerun and commit.
- **Acceptance:** Whisperwood over-band count 0 (or each remaining one explicitly flagged); `npm run build` green; regional_ecology.md regenerated.
- **Testing:** the existing generator check; encounter_checks band rule.

### U4. Make `encounters.json` the real spawn source for the Ring 0/1 field, and swap tables on liberation
- **Existing system:** encounters.json (49 regions, themes, zone tables), Tools/validate/encounter_checks.js, MonsterSpawner, SiegeDirector state.
- **Current status:** data TESTED (validator), Core reader NONE, in game NOT WIRED.
- **Current problem:** the best-finished ecology data in the repo has no consumer; Ring 0 monsters are hand-placed in the scene builder.
- **Evidence:** grep: only validator and LivingWorld.cs mention encounters; Ring0SceneBuilder.cs lines 213-221.
- **Proposed improvement:** a small Core `EncounterTables` reader plus a Unity roller used for the Whisperwood field's wild/deep zones (leave Ring 0 camps authored). On liberation switch to a "liberated" weighting. Small steps: Core reader first (TESTED), then one Unity call site.
- **Player benefit:** variety and returning visits; liberation visibly changes who you meet.
- **Technical benefit:** removes duplicated hand-placement; one data path to later regions.
- **Dependencies:** U3; gameplay-engineer for the Unity call site; Ring 0 fun-test must not regress.
- **Affected files:** new Code/Ascend.Core/EncounterTables.cs and tests, MonsterSpawner.cs, Ring0SceneBuilder.Whisperwood.cs.
- **Priority:** P1 only if Ring 0 is otherwise stable; else P2. **Complexity:** M. **Risk:** Ring 0 is the January deliverable; changing hand-placed fun-test spawns risks the proven loop. Keep the three Ring 0 camps untouched.
- **Acceptance:** with seed S the same roll gives the same species; no Tyrant or unique rolled; respects band and night multiplier; PlayMode check that Whisperwood spawns only species from its table.
- **Testing:** Core unit tests (determinism, zone, band); PlayMode spawn test; validator unchanged.

### U5. One Bestiary knowledge vocabulary with research tasks, and a non-kill route
- **Existing system:** Core Bestiary (4 kill tiers), PlayerBestiary, borrowed_features #11 (4-6 research tasks).
- **Current status:** IMPLEMENTED/TESTED kill tiers; research tasks DESIGNED.
- **Current problem:** three vocabularies (P-3); knowledge is kill-gated.
- **Evidence:** Bestiary.cs lines 12-13, 83-96; reactive_world doc line 70.
- **Proposed improvement:** keep the existing four thresholds as the mapping to named states (Unseen, Encountered, Observed, Understood; Mastered = existing 100% stamp), and add research tasks as a second way to advance Observed: "see it rest", "survive its Charge", "find tracks", "tame one". Do not add Investigated unless needed.
- **Player benefit:** a hunter who watches and studies, not only kills.
- **Technical benefit:** one tier vocabulary across code, docs, UI and the proposal.
- **Dependencies:** D2; research tasks data (generated from role in U1).
- **Affected files:** Bestiary.cs, BestiaryTuning, species data (tasks), PlayerBestiary.cs, UI text.
- **Priority:** P1 for the decision, P2 for the build. **Complexity:** M. **Risk:** save compatibility (old saves hold kill counts; keep them as one input).
- **Acceptance:** an old save loads with the same tiers; a task completion advances the tier without a kill; labels use the chosen names.
- **Testing:** BestiaryTests additions; old-save load test.

### U6. Wire GroupTactics, then add three ambient behaviour states
- **Existing system:** GroupTactics.cs, MonsterAi.cs, handover/group_tactics_wiring.md, MonsterController.
- **Current status:** Core TESTED, in game not wired (only `PackmatesNear` passed).
- **Problem:** packs do not flank or yield; monsters have no non-combat life.
- **Evidence:** MonsterController.cs lines 92-191; group_tactics_wiring.md.
- **Proposed improvement:** step 1 follow the existing wiring brief; step 2 add `Rest`/`Graze` (passive species, by day part), `GuardDen` (territorial), `Shelter` (after weather exists) as brain idle states, selected by role from U1.
- **Player benefit:** goblin packs and wolf packs read as groups; passive creatures look alive.
- **Technical benefit:** wiring is already specified; ambient states are state-table additions.
- **Dependencies:** U1 for step 2; ai-engineer, gameplay-engineer.
- **Priority:** P2. **Complexity:** M. **Risk:** symmetric peers only (Canon §4d: no leader); the combat fun-test balance may shift.
- **Acceptance:** step 1: pack of 5 goblins uses distinct slots in PlayMode; step 2: passive species change state by day part with no per-frame allocation.
- **Testing:** PlayMode flank test; Core tests exist; a perf check with 30 monsters.

### U7. Apply the living-world event effects (rumour first), then add 2 authored ecological events as pool rows
- **Existing system:** EventDirector, living_world.json (6 pool events), the rumour board.
- **Current status:** Core TESTED; Advance and save wired; effects unapplied.
- **Problem:** events roll and are saved but nothing the player can see.
- **Evidence:** PlayerWorldState.cs line 273; living_world.md.
- **Proposed improvement:** apply `rumour` and `shop_stock` first; then add 2 Whisperwood ecological events as ordinary pool rows (e.g. a boar crossing already exists; add a "wolves driven south" rumour + small encounter), using the existing four effect kinds only.
- **Player benefit:** a living board and caravans that matter.
- **Technical benefit:** no new framework; reuses the deterministic director.
- **Dependencies:** rumour board UI (ui-engineer).
- **Priority:** P1. **Complexity:** S to M. **Risk:** low.
- **Acceptance:** an active event appears on the board and in a shop for its days only; same save, same events.
- **Testing:** existing 21 Core tests plus a PlayMode check of the board line.

### U8. Region ecology profile fields in `regions.json`/encounters: food sources, apex species, local sign
- **Existing system:** encounters.json themes, gazetteer, regional_ecology.md.
- **Current status:** theme prose only.
- **Problem:** the proposal's System M ("not identical food webs with different names") needs a per-region "what makes this different" record that is data.
- **Proposed improvement:** add 3 short fields to each region's theme: `apex`, `staple` (species or family most common), `sign` (one environmental clue). Authored for Ring 1 first (Whisperwood), the rest later.
- **Player benefit:** readable regional identity.
- **Technical benefit:** a stable hook for clues and journal text.
- **Priority:** P3. **Complexity:** S. **Risk:** content volume for 49 regions; do only as regions come into scope.
- **Acceptance/Testing:** validator checks that apex and staple are species in that region's habitats.

### U9. Narrow the creature art plan to the species the next ring needs, and give the models a durable home
- **Existing system:** monster_model_pipeline.md, monster_models.json, creature_system.md.
- **Current status:** 677 blockouts local-only, 3 tracked FBXs; high-poly Blender generator local-only.
- **Problem:** three conflicting plans and a single-PC dependency for every non-Ring-0 monster.
- **Proposed improvement:** one decision sentence in the pipeline doc stating the chosen route, scope the first target to the ~22 species reachable in the Whisperwood build plus Ring 1 core, back up the models folder (owner action), and mark the rest as post-Ring-1.
- **Player benefit:** Ring 1 monsters look like monsters, not capsules.
- **Priority:** P1 for the doc and backup, P2 for art. **Complexity:** S (decision) / L (art). **Risk:** AI-generation licence and cost (owner decision D8).
- **Acceptance:** the pipeline doc names one route; the registry's status counts match the folder; backup confirmed by the owner.
- **Testing:** `build_model_prompts.js` unchanged; a registry-vs-disk check script (creature-artist).

### U10. Tameable species without an evolution branch (data check)
- **Existing system:** Partners.Branches/Evolve.
- **Problem (UNVERIFIED):** evolution only exists where a species has variants; unknown how many tameable species have none.
- **Proposed improvement:** a validator report, then either add a variant or hide the Evolve option.
- **Priority:** P3. **Complexity:** S. **Risk:** low.
- **Acceptance/Testing:** report of zero or explained species; TamingTests extension.

### U11. Close the pending decisions recorded as "decided, edits not applied"
- **Existing system:** Canon §6 W3, W7a, W7b rows; physical_map findings; 28 warnings.
- **Problem:** the repo reports decisions that were never applied (P-9).
- **Proposed improvement:** one lore/world pass applying rewording and tag edits (Lirian, Stormreach, Vharlen, Quaking Lands, Kitsune Isles, Frostveil tags), Friendly Goblin ownership, Vharlen capital split, Hoshizora City anchor.
- **Priority:** P2. **Complexity:** M. **Risk:** moving anchors changes atlas and roads (the decision says reword, move only Hoshizora City within 3 km).
- **Acceptance:** warnings fall; build green; the Canon rows say "applied".

### U12. Fix four stale doc lines found here
- creature_system.md (Forest Wolf antlers), living_world.md ("nothing wired"), world_graph.md (edge totals), Canon §2 Monsters row ("287 core" vs 327 core in file): add the Tyrant footnote.
- **Priority:** P3. **Complexity:** S. **Risk:** none. Owners: creature-artist, producer/world-designer, canon-keeper (Canon change is a §6 proposal, not an edit).

---

## 6. IDEA candidates (new, distinctive), strongest first

### I1. Dens and signs: the creature leaves evidence before you meet it
- **Category:** exploration/ecology. **Description:** each Ring 1 species with a role gets one "sign" (tracks, feeding remains, a den, a call at dusk) placed by the encounter zone. **Player experience:** you read the field before the fight; a hunter's instinct. **Why AETHWYRD:** matches the evidence-led field journal in open_world_rpg_research_2026.md and the Appraisal identity. **Affected systems:** Bestiary, encounters, journal. **Dependencies:** U1, U4, U5. **Suggested implementation:** a sign is a tagged prop drawn from role; observing it counts as a research task. **Technical:** props from the existing graybox kit; no AI. **Content:** about 15 sign types cover roles. **Complexity:** M. **Risks:** over-instrumenting the map; **Design questions:** are signs diegetic only (no icon)?

### I2. The Migration Notice board entry
- **Category:** living world. **Description:** one authored "herd moves" event per region per Plenty/Storm phase that swaps which species roam a zone for 3-7 days and posts a board line. **Experience:** "the elk are in the east meadow this week"; hunting contracts reflect it. **Why:** bounded migration (the proposal's idea) with no simulation. **Systems:** EventDirector, U2, board. **Dependencies:** U2, U7. **Implementation:** pool rows with a zone-table override. **Complexity:** S to M. **Risks:** looks scripted if too regular (add seed jitter). **Questions:** fixed calendar vs state-driven?

### I3. One weather-driven behaviour per region (not a weather system)
- **Category:** presentation/ecology. **Description:** a single authored rule per region (rain brings slimes out in the open; fog hides ambushers) tied to a simple clear/rain/fog toggle. **Experience:** familiar places change character. **Why:** gets 80% of System G without seasons. **Dependencies:** D3. **Complexity:** M. **Risks:** a weather system is an unbounded art/audio cost.

### I4. Roaming rare, authored and memoryless
- **Category:** boss/encounter. **Description:** a few named roaming monsters triggered by region state and time (never by killing the player), listed on the rumour board. **Why:** the proposal's Part 3 wish within Canon §4d. **Dependencies:** U2, U7. **Complexity:** M. **Risks:** C-3.

### I5. Restoration through care, not killing (the "land breathes" loop)
- **Category:** progression/ecology. **Description:** after liberation, optional restoration bundles (seedlings, stocking a pond, relocating a den) raise the region's Plenty weighting. **Experience:** a peaceful post-game verb; matches the post-story open world in Canon §3. **Systems:** U2, restoration bundles (borrowed_features #16), gathering. **Complexity:** M.

### I6. Companion field observations about creatures
- **Category:** companions. **Description:** Lyra and partners comment on signs and behaviours ("those tracks are fresh") as research progress, reusing existing observation lines. **Why:** low cost, high warmth, fits Canon tone. **Dependencies:** U5, companion_field_ai.md. **Complexity:** S.

### I7. Egg-and-den taming path tied to region phases
- **Category:** taming. **Description:** dens appear in Plenty phases; sneaking in yields eggs (existing rules). **Why:** uses built Stables rules (egg nest, 10% marking). **Dependencies:** U2, SYS-ECO-07. **Complexity:** M.

### I8. Field-journal ecology page by region (read-only summary)
- **Category:** UI. **Description:** a generated one-page region summary from U1/U2: apex species, staple, current phase, what the board says. **Why:** gives ecology a visible home without a management UI (the proposal's own wish). **Dependencies:** U1, U2, UI. **Complexity:** S to M.

---

## 7. RISKS

| ID | Risk | Probability / impact | Confirmed or theoretical |
|---|---|---|---|
| R-ECO-1 | A generic agent follows AETHWYRD_2 literally and builds a parallel simulation layer ("extend Full/Reduced/Low/Inactive" does not exist). | High / High | Confirmed premise defect (P-1); outcome theoretical |
| R-ECO-2 | Ecology scope creep fits the existing R11 (scope, high/high): the proposal has 15 systems and 15 deliverables for a two-person, 4-5 hours a week team. | High / High | Theoretical (REASONED CONCLUSION) |
| R-ECO-3 | All non-Ring-0 monster models exist only on the owner's PC (gitignored, "several GB"); disk loss means regeneration (non-deterministic). | Low-Medium / High | Confirmed (monster_model_pipeline.md "Backup") |
| R-ECO-4 | Whisperwood spawns above its rank band once a data-driven spawner exists. | Medium / Medium | Confirmed data defect (P-4), outcome theoretical |
| R-WLD-1 | Ring 0 regression if hand-placed fun-test spawns are replaced by tables (U4). | Medium / High | Theoretical |
| R-WLD-2 | Two meanings of "ring" and two region counts (40/49) cause wrong totals in reports and task briefs. | High / Low | Confirmed (SYS-WLD-01) |
| R-WLD-3 | Terrain import, streaming and world scale remain undecided/unbuilt; any promise of a larger playable area in 2027 is unsupported by current code. | High / Medium | Confirmed state; timeline risk theoretical |
| R-WLD-4 | Seasons and weather are assumed by several proposals but not designed; building ecology events on them first multiplies rework. | Medium / Medium | Confirmed gap |
| R-WLD-5 | Decisions recorded as "decided, edits pending" let the repo claim closure while the data and 28 warnings remain. | Medium / Low | Confirmed (P-9) |
| R-WLD-6 | No PlayMode run since 2026-11-08 (183 passed); any ecology/world wiring now is unverified in Unity until the next UNITY OK slot. | Medium / Medium | Confirmed (brief) |
| R-ECO-5 | Named-monster rules (Canon §4d, Nemesis patent, IP lawyer review) could be accidentally violated by "legendary roaming" or "memory" proposals. | Low / High | Theoretical |

---

## 8. DECISIONS REQUIRED from the owner

- **D1.** Confirm the wording: 49 `regions.json` rows = 40 surface + 8 underworld + 1 post-game. Do you want "about 40" in all owner-facing text to read "40 surface regions"?
- **D2.** One Bestiary knowledge vocabulary: keep Unseen / Encountered / Observed / Understood / Mastered (recommended, mapped onto the existing 4 thresholds plus research tasks), or add Investigated?
- **D3.** Do seasons exist in AETHWYRD, and is weather a gameplay system or only audio/visual? Every environmental ecology item waits on this.
- **D4.** Accept that the "Full/Reduced/Low/Inactive" levels are not built and will be defined as a minimal three-rung rule (near: real; region: a few ints; far: nothing) when ecology is built?
- **D5.** Ecology scope for 2027: only "tags + 4-state region cycle + evidence/research" (U1, U2, U5, U7) or the full network? Recommended: the small set, Ring 1 species first.
- **D6.** Confirm Brindlewick and the Ring 0 field belong to Whisperwood (current decision by Claude; quests still filed under Aldmere).
- **D7.** For the 167 over-band species-region pairs: widen bands, drop habitats, or mark "rare deep"?
- **D8.** Creature art route: AI-generated (Tripo/TripoSR) vs the procedural Blender generator vs hand blockouts, and back up the local models folder.
- **D9.** Approve the Lean/Storm/Plenty cycle row (Canon §6 #14) or replace it.
- **D10.** Are the "decided, edits pending" world rows (W3, W7a, W7b) to be applied now or left as proposals?

## TESTING REQUIRED

- Before any ecology data lands: validator rules for missing species, self-reference, impossible habitat/role combinations; determinism check on regeneration; `npm run build` green.
- Core: determinism, save round-trip and old-save load for any new state (cycle, bestiary tasks); tier mapping test.
- PlayMode (next UNITY OK slot): Whisperwood spawn from tables respects band; liberation swaps the table; GroupTactics slots distinct; frame cost with 30 monsters; Ring 0 fun-test unchanged.
- Data hygiene: registry-vs-disk script for monster models; `audit_recipes.js --strict` result recorded.

## CONFIDENCE

- High (VERIFIED FACT, read or counted): 680/6,754/25/49 counts and breakdowns; absence of relationship data; absence of population/encounter consumers in code; 3 tracked monster FBXs; 677 blockout registry; single scene; Whisperwood-only siege/liberation; absence of seasons/weather/simulation levels.
- Medium: "about 22 species in the shipped scene" (the scene builder names 19; the serialized scene was not parsed, and the siege adds goblin-family species); edge-count discrepancy cause; evolution coverage (U10).
- Low / not checked: the content of the 755 Core tests; PlayMode behaviour (not run, none available); screenshots.

## UNRESOLVED QUESTIONS

1. Why does `region_graph.json` have 100 edges when the doc says 99 (SYS-WLD-02)?
2. Which exact 19-species placements exist in the serialized scene vs the builder? (requires opening Unity)
3. Are the 12 species-region pairs without population rows intentional (likely unique/story rows)?
4. Which Whisperwood over-band species are intended "rare deep" rows by design?
5. Does any shipped saved-game field already carry ecology state? (SaveGame.LivingWorld has events and journal only.)

## FINAL STATUS

Audit complete, read-only; one file written. Status counts for the 29 systems above (Core / in game, counted per row's primary status):

- **Core:** TESTED 21, IMPLEMENTED 0 standalone, DOCUMENTED 3 (SYS-ECO-06, -07 partly, -08), data-only 5 (SYS-ECO-03, -04, -05, -13, SYS-WLD-05 treated as TESTED data), N/A 2.
- **In game:** IMPLEMENTED/VERIFIED-by-recorded-PlayMode 7 (monster AI, bestiary, taming, siege+liberation for Whisperwood, clock, inns, the one scene), PARTIAL 8, NOT WIRED 8 (population, encounters, region graph, GroupTactics, puzzles, habitats, schedules, relationships as data), NOT STARTED 3 (terrain, streaming, relationship/population simulation), VERIFIED by a run today 0 (no Unity here).

Recommended order if only a few hours a week: U3 (S, data), U7 (S/M, visible living world), D2/D3/D5 decisions, then U4 and U1, with ecology kept to a tag file plus a four-state region cycle rather than the 15-system network.
