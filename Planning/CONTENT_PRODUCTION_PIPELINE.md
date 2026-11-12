# Content production pipeline

How each kind of content gets from an idea to something the player can see, which step is automated, and where each pipeline stops today. Statuses use the ladder in `QUALITY_GATES.md` §1. Detailed how-to stays in the linked documents; this page is the map.

## 1. The shared spine

```text
design doc (00..12)  ->  Data/*.json  ->  validator + generators (npm run build)  ->  Core rules (Code/Ascend.Core, tested)
                                                                                         |
Blender source/tools  ->  baked FBX + LODs (local, gitignored)  ->  Unity import  ->  Unity runtime (Game/Assets/_Game)  ->  PlayMode tests  ->  player build
```

Three properties make this pipeline workable for two people, and every new content type should keep them:

1. **Data first.** Content is JSON under `Data/`, validated by generated schemas (`Data/Schemas/`). `Data/` is canonical for numbers.
2. **Rules outside the engine.** Game rules live in `Code/Ascend.Core` with tests that run without Unity. The cloud can verify them; only the PC can verify Unity.
3. **Generated, not hand-made, at scale.** Species, rigs, motion, classes, buildings and creature models come from generators. Hand work goes into the recipe, not the 680th copy.

## 2. Pipelines

| Content | Source of truth | Tool | Check | Reaches | Stops at today |
|---|---|---|---|---|---|
| Monster species, families, variants, loot | `Tools/monster_gen/*.js` inputs → `Data/Monsters/species.json`, `population.json`, `loot_tables.json` | `npm run gen` | validator, Core species-count tests | Data, vault, Core | **In data for all 680; in the game only for species a scene builder places.** See the ecology audit |
| Monster rigs and motion | `Tools/monster_gen/build_rigs.js`, `motion.js` → `rigs.json`, `motion.json` | `npm run rigs`, `npm run motion` | validator, `MonsterMotionLaws` tests | Data, Unity `MonsterAnimator` (procedural) | Authored skeletal animation for monsters: not started |
| Monster models | species `designRecipe` → `Tools/blender/build_creature_library.py` (procedural) or the AI route in `13_Production/monster_model_pipeline.md` | Blender on the PC | contact sheets, `anime-fantasy-director` review | `Art/Blender/CreatureLibrary/` (local) → `bake_to_game.py` → FBX (local) | 677 blockout FBX registered in `Art/Generation/monster_models.json`; baked game-ready creatures with LODs: not in the game. Models are local only, so a lost PC loses them |
| Classes and skills | `Tools/classes/build_classes.js` → `Data/Classes/*.json` | `npm run classes` | validator, Core tests | Data, Core `Skills` | See the progression audit for which classes are playable |
| Items, recipes, shops, materials | `Data/Items/*.json` (hand-edited by `items-designer`) | - | validator (price loops, result rank), Core tests | Data, Core, Unity bag / shop / crafting windows | - |
| Quests, weekly board, story flags | `Data/Quests/*.json` | - | validator (targets exist), Core `QuestLog` tests, PlayMode scene test for reach targets | Data, Core, Unity journal and board | See the exploration and quests audit |
| NPCs, dialogue, banter | `Data/NPCs/npcs.json`, `Data/Companions/banter.json` | - | validator | Unity talk window | 39 NPC records against a canon target of about 2,500; no generator exists |
| Regions, graph, gazetteer, encounters | `Data/World/*.json`, `Tools/atlas/*.js` | atlas builders | validator (map warnings, graph findings) | Data, Core `RegionGraph`, map window | Playable space: see the ecology and world audit |
| Terrain | `Data/World/physical_map.json` → `Tools/blender/build_world_terrain.py` → heightmaps (local) | Blender on the PC | seam and determinism checks (`13_Production/world_terrain.md`) | `13_Production/terrain_unity_import.md` import stub | Terrain is not placed in the game; waits on owner decisions (tile size, Brindlewick rebase) |
| Buildings and props | `Tools/blender/ascend_buildings/`, `build_building_library.py` | Blender on the PC | contact sheets, director review, `art_budgets.md` | `Art/Blender/BuildingLibrary/` (local) → bake → Unity `BuildingImport.cs` | See `13_Production/building_system.md` |
| Player and human characters | VRoid → VRM (owner), or the humans-base pipeline | - | - | - | **Blocked on the owner**: no character in the game, a capsule stands in |
| Animation (player) | Mixamo clips → `Game/Assets/_Game/Art/Animation/` | Unity | PlayMode animation tests | Unity | Placeholder; humanoid path untested until a humanoid model exists |
| Audio | `13_Production/audio_*`, `Data/Audio/*.json` | - | validator `audio_checks.js`, Core `AdaptiveMusic` tests | Core state machine | **No playback in the game** (state logger only); no audio files; sources shortlisted, licences not confirmed |
| UI screens | `12_Systems/hud_and_ui.md`, ux specs → `Runtime/UI/` | Unity | PlayMode, screenshots | Unity (IMGUI placeholder style) | Styled "System window" look: not built |
| Scenes | Editor scene builders (`Ring0SceneBuilder`) | Unity batch | PlayMode scene tests | `Game/Assets/_Game/Scenes` | One Ring 0 field plus the Whisperwood test field |
| Design bible → Obsidian vault | all of the above | `npm run vault` | - | `ideas/` | `Planning/` is not mirrored into the vault (see CD-008) |

## 3. Bottlenecks, in order of how much they hold back

1. **Unity is only on the owner's PC.** Everything right of "Unity import" in §1 waits for a PC session. Mitigation: keep rules in Core; batch Unity work into one verify slot a week.
2. **No player character.** Blocks humanoid animation, foot IK, the look pass, every screenshot that would show the game as it is meant to look.
3. **Art exists in Blender, not in the game.** Creatures, buildings and terrain have generators and local libraries, but the bake → import → place chain has not been run end to end for a single finished asset in the shipping scene.
4. **No audio at all.** Cue sheets and state machines exist; nothing plays.
5. **Hand-authored content has no generator and no budget.** NPCs (39 of about 2,500), quests (32), dialogue. The canon numbers for these are years of writing at the current rate.
6. **Local-only assets have no backup in git.** Generated models and libraries live on one PC.

## 4. Rules for adding content

- New data type: schema first (`tools-pipeline-engineer`), then data, then Core reader with a test, then Unity.
- New asset from outside: register it in `13_Production/third_party_assets.md` with its licence before it is used. No licence file, no import.
- Nothing from another studio's game except ideas and mechanics.
- Ring order: Ring 0 content before Ring 1, Ring 1 before anything else. Content for later rings may be generated as data, but no art or Unity time is spent on it until the vertical slice gate passes (`VERTICAL_SLICE_PLAN.md`).
- Art, world, character and UI work is reviewed by the `anime-fantasy-director` before it is locked.
