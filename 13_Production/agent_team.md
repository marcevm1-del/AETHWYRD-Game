# The Agent Team

> 28 specialist Claude subagents that build AETHWYRD together. Definitions: `.claude/agents/<name>.md` (role, the files each owns, how it works, the checks it runs, the shared house rules). Shared rules for every session: `CLAUDE.md`.

> **Handover:** unfinished agent tasks, with briefs ready to paste, are in `13_Production/handover/` (latest: `handover_2026-11-02.md`).

## How to use them

- **In a Claude Code session in this repo:** ask for an agent by name ("have the creature-artist rig the slimes") or let Claude pick one from its description.
- **Big pushes start with the producer.** It splits the goal into one task per agent and gives each task its files, its definition of done and its checks. It puts tasks that share no files into the same **wave**.
- **Parallel work:** agents in one wave can run at the same time, each in its own session or git worktree. Agents in the next wave start when the earlier wave's work is merged and green.
- **Every change ends with the code-reviewer and the qa-tester** before it is committed. **Art, world, character and UI work also goes past the anime-fantasy-director** before it is locked.

## Roster and ownership

| # | Agent | Group | Owns (edits only these) |
|---|---|---|---|
| 1 | **producer** | Leadership | Ring plans, `progress_log.md`, the daily note, this roster |
| 2 | **canon-keeper** | Leadership | `Canon.md` §6 proposals; consistency fixes |
| 3 | **qa-tester** | Leadership | `Code/Ascend.Core.Tests/`, `Game/Assets/_Game/Tests/`, `reports/` |
| 4 | **code-reviewer** | Leadership | Nothing (read-only reviews) |
| 5 | **systems-designer** | Design | `12_Systems/systems.md`, `03_Rank_System/`, `world_tuning.json`, `progression.json`, `guild_ranks.json` |
| 6 | **combat-designer** | Design | `12_Systems/combat.md`, `combat_tuning.json`, `attacks.json`, `boss_phases.json`, `bosses_and_calamities.md` |
| 7 | **quest-designer** | Design | `11_Quests_Encounters/`, `Data/Quests/` |
| 8 | **world-designer** | Design | `10_World/`, `regions.json`, `gazetteer.json`, `inns.json`, `gathering.json`, `siege_waves.json`, `world_map.md` |
| 9 | **narrative-writer** | Design | `02_Lore/`, `07_Characters/`, `06_Races_Origins/`, NPC text in `npcs.json` |
| 10 | **bestiary-designer** | Design | `08_Bestiary/`, `species.*`, `population.json`, `loot_tables.json`, `Tools/monster_gen/` |
| 11 | **class-skill-designer** | Design | `04_Classes/`, `05_Skills_Magic/`, `classes.json`, `Tools/classes/` |
| 12 | **items-designer** | Design | `09_Equipment/`, `Data/Items/` |
| 13 | **ux-designer** | Design | `12_Systems/hud_and_ui.md`, UI specs in `13_Production/` |
| 14 | **core-rules-engineer** | Engineering | `Code/Ascend.Core/` (+ its tests with qa-tester) |
| 15 | **gameplay-engineer** | Engineering | `Runtime/Player/`, `Runtime/Combat/`, `Runtime/Camera/`, `AscendData.cs` |
| 16 | **ai-engineer** | Engineering | `Runtime/World/` AI components, `Code/Unity/Runtime/`, Core AI files |
| 17 | **world-builder-engineer** | Engineering | Scene builders, `Scenes/`, `BuildingImport.cs` |
| 18 | **ui-engineer** | Engineering | `Runtime/UI/` |
| 19 | **save-platform-engineer** | Engineering | Saves, settings, input, `BuildPlayer.cs`, project settings |
| 20 | **tools-pipeline-engineer** | Engineering | `Tools/validate/`, `Tools/vault/`, test runner, `Data/Schemas/`, CI, `package.json` |
| 21 | **environment-artist** | Art & audio | `Tools/blender/ascend_buildings/`, building scripts, `Art/Models/Buildings/`, building docs |
| 22 | **creature-artist** | Art & audio | `Tools/blender/ascend_creatures/`, creature scripts, `creature_system.md` |
| 23 | **technical-artist** | Art & audio | Shaders, materials, import post-processors, bake/LOD scripts |
| 24 | **animator-rigger** | Art & audio | Rig and motion data and scripts, `monster_motion_bible.md`, animator assets |
| 25 | **audio-designer** | Art & audio | Audio specs in `13_Production/`, `Game/Assets/_Game/Audio/` |
| 26 | **anime-fantasy-director** | Leadership | `13_Production/art_direction.md` (style guide), `reports/design_review_*.md`; reviews and directs everyone for genre fit and design quality |
| 27 | **youtube-beta** (beta) | Tools | `Tools/tutorial_vision/`, `13_Production/tutorial_vision.md`, the Blender/Unity MCP entries, `TutorialVisionCapture.cs`; learns techniques from video tutorials by reading their frames and applies them in Blender or Unity |
| 28 | **triposr-modeler** | Tools | `13_Production/model_requests/`, `Tools/ai3d/`, generated output in the gitignored `Art/Generation/staging/`. Turns designers' model requests into meshes with TripoSR (image to 3D) on the local GPU; reviewed by anime-fantasy-director, finished in Blender by the requesting artist |

**Two files have shared owners:**
- `Code/Ascend.Core/MonsterAi.cs`, `Companions.cs` and `BossPhases.cs` belong to ai-engineer together with core-rules-engineer. Only one of them edits these in any given wave.
- Import post-processors belong to technical-artist together with world-builder-engineer, under the same rule.

## A first wave plan (proposal for the producer)

This turns the Blender buildings and creatures into game assets and keeps Ring 0 moving while the VRoid character is pending.

| Wave | Agents (in parallel) | Goal |
|---|---|---|
| 1 | technical-artist, animator-rigger, bestiary-designer, qa-tester | Set triangle and draw-call budgets and write the high→low bake with LODs. Rig the four Ring 0 monsters to their shared rigs. Fix recipe parts that contradict look text. Take a baseline test and screenshot report |
| 2 | creature-artist, environment-artist, systems-designer, ux-designer | Export baked Ring 0 creatures and Whisperwood buildings. Run a balance pass on Ring 0–1 numbers. Spec the Status Window and Style Rank polish (Ring 0 week 9) |
| 3 | world-builder-engineer, ai-engineer, ui-engineer, audio-designer | Place the baked models. Drive monsters with rigs and motion. Build the specced screens. Write the Ring 0 cue sheet |
| 4 | gameplay-engineer, qa-tester, code-reviewer, producer | The Ring 0 week-10 polish list, the fun-test checklist, the standalone build, then the log and note |

Design agents (narrative, quest, world, class-skill, items, combat, canon-keeper) can run alongside any wave as long as they stay in their own folders.
