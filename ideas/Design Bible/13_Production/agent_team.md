# The Agent Team

> 33 specialist Claude subagents that build AETHWYRD together (27 original, 6 added 2026-11-12; the studio layer adds 34 more, see CLAUDE.md). Definitions: `.claude/agents/<name>.md` (role, the files each owns, how it works, the checks it runs, the shared house rules). Shared rules for every session: `CLAUDE.md`.

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
| 3 | **qa-tester** | Leadership | `Code/Ascend.Core.Tests/`, `Game/Assets/_Game/Tests/`, `reports/` (except `reports/design_review_*.md`, the anime-fantasy-director's) |
| 4 | **code-reviewer** | Leadership | Nothing (read-only reviews) |
| 5 | **systems-designer** | Design | `12_Systems/systems.md`, `03_Rank_System/`, `world_tuning.json`, `progression.json`, `guild_ranks.json` |
| 6 | **combat-designer** | Design | `12_Systems/combat.md`, `combat_tuning.json`, `attacks.json`, `boss_phases.json`, `bosses_and_calamities.md` |
| 7 | **quest-designer** | Design | `11_Quests_Encounters/`, `Data/Quests/` |
| 8 | **world-designer** | Design | `10_World/` (except `exploration_and_discovery.md` and `reactive_world_and_field_journal.md`, which the exploration-designer owns), `regions.json`, `gazetteer.json`, `inns.json`, `gathering.json`, `siege_waves.json`, `world_map.md` |
| 9 | **narrative-writer** | Design | `02_Lore/`, `07_Characters/`, `06_Races_Origins/`, NPC text in `npcs.json` |
| 10 | **bestiary-designer** | Design | `08_Bestiary/` (except `regional_ecology.md`, which the creature-ecology-designer owns), `species.*`, `population.json`, `loot_tables.json`, `Tools/monster_gen/` |
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

**Two files have shared owners:**
- `Code/Ascend.Core/MonsterAi.cs`, `Companions.cs` and `BossPhases.cs` belong to ai-engineer together with core-rules-engineer. Only one of them edits these in any given wave.
- Import post-processors belong to technical-artist together with world-builder-engineer, under the same rule.

## The 18 seats of the management system (added 2026-11-12)

The owner's master development command names eighteen roles. Each is filled by an agent that already existed where one did; six agents were created for roles nobody held (rows 28 to 33). No duplicate producer, architect, QA or UI agent was made (decision D-005 in `Planning/DECISION_LOG.md`). The orchestrating Claude session acts as executive producer; the `producer` agent is its planning deputy.

| Seat | Filled by | Pinned tier | Pass a higher tier when | Edits |
|---|---|---|---|---|
| Executive producer | The main session, with **producer** | opus | - | `Planning/`, ring plans, progress log |
| Technical architect | **technical-director** | opus | - | Architecture decision records |
| Gameplay engineer | **gameplay-engineer** (with core-rules-engineer, ai-engineer, ui-engineer, save-platform-engineer, world-builder-engineer for their folders) | sonnet | opus for risky Unity integration | Their runtime folders |
| Systems designer | **systems-designer** | sonnet | opus for cross-system design | `12_Systems/systems.md`, progression data |
| Combat designer | **combat-designer** | sonnet | opus for combat architecture | Combat docs and data |
| Creature ecology designer | **creature-ecology-designer** (new); **bestiary-designer** for species data | sonnet | opus for ecology architecture; haiku for data validation | `08_Bestiary/regional_ecology.md`, ecology data |
| World designer | **world-designer** | sonnet | opus for world structure | `10_World/`, world data |
| Exploration designer | **exploration-designer** (new) | sonnet | opus for a major redesign | `10_World/exploration_and_discovery.md`, `reactive_world_and_field_journal.md` |
| Narrative and quest designer | **quest-designer** and **narrative-writer**; narrative-director for story architecture | sonnet | opus for narrative architecture | Quest and lore folders |
| Progression and economy designer | **systems-designer** (progression), **economy-designer**, **items-designer** | sonnet | - | Progression, items and economy data |
| Companion and AI designer | **companion-ai-designer** (new); **ai-engineer** implements | sonnet | opus for AI architecture | `12_Systems/companion_field_ai.md`, `party_synergy.md`, `companion_rules.json` |
| UI/UX designer | **ux-designer** | sonnet | - | `12_Systems/hud_and_ui.md`, UI specs |
| Technical art director | **technical-artist**; **anime-fantasy-director** for the look | sonnet | - | Shaders, import, bake scripts; the style guide |
| QA and test engineer | **qa-tester** (qa-lead for test strategy) | sonnet | - | Tests, `reports/` |
| Performance engineer | **performance-analyst** | sonnet | opus for performance architecture | Performance notes |
| Documentation auditor | **documentation-auditor** (new); **canon-keeper** rules on canon | haiku | sonnet for a deep audit | Nothing by default (reports) |
| Red-team reviewer | **red-team-reviewer** (new) | opus | - | Nothing (reviews) |
| Research analyst | **research-analyst** (new) | sonnet | haiku for extraction | `research_notes/`, research reports |

### The six new agents

| # | Agent | Tools | Owns |
|---|---|---|---|
| 28 | **red-team-reviewer** | Read, Grep, Glob, Bash (read-only) | Nothing; its reviews are filed by the orchestrator under `Planning/reviews/` |
| 29 | **documentation-auditor** | Read, Grep, Glob, Bash (read-only) | Nothing by default; named `Planning/` files when a task says so |
| 30 | **research-analyst** | Read, Grep, Glob, Bash, WebSearch, WebFetch, Write, Edit | `research_notes/`, research reports, rows in `reference_games.md` |
| 31 | **exploration-designer** | All | `10_World/exploration_and_discovery.md`, `10_World/reactive_world_and_field_journal.md` (taken over from world-designer for these two files) |
| 32 | **creature-ecology-designer** | All | `08_Bestiary/regional_ecology.md` (taken over from bestiary-designer for this file), ecology data when it exists |
| 33 | **companion-ai-designer** | All | `12_Systems/companion_field_ai.md`, `12_Systems/party_synergy.md`, `Data/Companions/companion_rules.json` |

### How to invoke

- By name in a Claude Code session in this repo: "have the red-team-reviewer challenge UPG-021", or let Claude choose from the descriptions. A newly added agent file is picked up without restarting (verified 2026-11-12: the six became invocable mid-session after a few minutes).
- The model pinned in the agent's file is used unless the invocation passes another: the orchestrator passes `opus` for the cases in the fourth column.
- Briefs use `Planning/TASK_TEMPLATES.md` §4 and reports §5. Agents implement only tasks from `Planning/FEATURE_BACKLOG.md`.
- Agent teams as a separate product feature were not used; parallel work is done with background subagents inside the caps of `risk_register_and_usage_budget.md` §1, or with separate sessions and worktrees on the PC as described above.

### Tiers

Opus: producer, technical-director, creative-director, red-team-reviewer. Haiku: documentation-auditor. Sonnet: gameplay-engineer, systems-designer, combat-designer, world-designer, quest-designer, narrative-writer, economy-designer, items-designer, ux-designer, technical-artist, performance-analyst, bestiary-designer, qa-tester, tools-pipeline-engineer, the four other new agents (research-analyst, exploration-designer, creature-ecology-designer, companion-ai-designer), and the studio layer's pinned agents (lead-programmer, devops-engineer, community-manager, prototyper and the four Unity sub-specialists). Every other agent keeps `inherit` (the session's model) until it takes a seat. `.claude/docs/model-tiers.md` predates these pins (CD-024).

## A first wave plan (proposal for the producer)

This turns the Blender buildings and creatures into game assets and keeps Ring 0 moving while the VRoid character is pending.

| Wave | Agents (in parallel) | Goal |
|---|---|---|
| 1 | technical-artist, animator-rigger, bestiary-designer, qa-tester | Set triangle and draw-call budgets and write the high→low bake with LODs. Rig the four Ring 0 monsters to their shared rigs. Fix recipe parts that contradict look text. Take a baseline test and screenshot report |
| 2 | creature-artist, environment-artist, systems-designer, ux-designer | Export baked Ring 0 creatures and Whisperwood buildings. Run a balance pass on Ring 0–1 numbers. Spec the Status Window and Style Rank polish (Ring 0 week 9) |
| 3 | world-builder-engineer, ai-engineer, ui-engineer, audio-designer | Place the baked models. Drive monsters with rigs and motion. Build the specced screens. Write the Ring 0 cue sheet |
| 4 | gameplay-engineer, qa-tester, code-reviewer, producer | The Ring 0 week-10 polish list, the fun-test checklist, the standalone build, then the log and note |

Design agents (narrative, quest, world, class-skill, items, combat, canon-keeper) can run alongside any wave as long as they stay in their own folders.
