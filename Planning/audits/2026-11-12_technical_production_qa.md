# Audit 2026-11-12: technical architecture, production pipeline, QA

AGENT: orchestrator (acting as technical architect and QA lead)
MODEL TIER: session model
ASSIGNED TASK: establish the real state of the architecture, the save path, the tool and build pipeline and the test evidence.
WHY NOT A SUBAGENT: the 5-hour usage limit was hit during the first audit wave (three agents stopped mid-run). This audit was done in the main session from files already read, to stay inside the budget.
FILES INSPECTED: `package.json`, `.github/workflows/ci.yml`, `Tools/run_tests.js`, `Tools/validate/*`, `Tools/vault/build_vault.js`, `Game/Packages/manifest.json`, `Game/Assets/_Game/Runtime/Ascend.Game.asmdef`, `Code/Ascend.Core/SaveGame.cs`, `Game/Assets/_Game/Runtime/Player/PlayerSave.cs`, `Game/ProjectSettings/ProjectSettings.asset`, file and line counts of every code folder, `13_Production/{phase1_api,tech_debt_register,perf_review_core_2026-11-08,risk_register_and_usage_budget,unity_integration_dependency_map,project-stage-report,adoption-plan-2026-11-07,production,ring0_plan,progress_log}.md`, `.claude/docs/model-tiers.md`, `.gitattributes`, `.gitignore`.
FILES MODIFIED: this report only.

What was run: `npm run build` with a .NET SDK 8.0.428 installed in the session scratchpad. Result: data valid, **755 Core tests passed**, 28 map warnings, 0 graph findings. Unity was **not** run (none in the container).

## 1. System table

| System ID | System | Description | Core status | In-game status | Source files (evidence) | Depends on | Known issues | Next action | Priority |
|---|---|---|---|---|---|---|---|---|---|
| SYS-CORE-01 | Two-layer architecture | Engine-agnostic rules library consumed by Unity as a local package | TESTED: 63 files, 12,057 lines, no `UnityEngine` reference (grep) | IMPLEMENTED: `Game/Packages/manifest.json` references `com.projectascend.core` by file path; one runtime assembly `Ascend.Game` | `Code/Ascend.Core/`, `Game/Assets/_Game/Runtime/Ascend.Game.asmdef` | - | One runtime assembly for all 64 Unity files (no boundary between Player, Combat, UI, World); no written architecture decision records | Keep. Record the layer rule as an ADR | P2 |
| SYS-CORE-02 | Data loading | JSON under `Data/` read by Core `GameDatabase`, loaded in Unity by `AscendData.cs`; the player build copies data files | TESTED | IMPLEMENTED | `Code/Ascend.Core/Data.cs`, `Runtime/AscendData.cs`, `Editor/BuildPlayer.cs` | Validator | Several finished data files have **no reader at all**: `weapon_movesets.json`, `population.json`, `encounters.json`; `reactions.json` is loaded but not passed to the game (see the combat and ecology audits) | A "data with no consumer" check in the validator report | P1 |
| SYS-CORE-03 | Save and load | One JSON slot; validate, tolerant upgrade, bad saves set aside as `.bad`, a newer save is never overwritten by an older build | TESTED (save migration tests merged 2026-11-09) | IMPLEMENTED, TESTED (`Phase1WorldPlayModeTests`); last PlayMode run 2026-11-08 | `Code/Ascend.Core/SaveGame.cs`, `Runtime/Player/PlayerSave.cs`, `PlayerWorldState.cs` | - | `CurrentVersion` is still 1 after many added fields (works because every field is optional, but there is no version step to hang a real migration on); save folder comes from `companyName: DefaultCompany`, `productName: Game`, so renaming the product moves the save; one slot only; no backup rotation | Decide the product and company name before any outside build; add a version bump rule | P1 |
| SYS-CORE-04 | Input | Unity Input System, keyboard/mouse and gamepad | n/a | IMPLEMENTED; rebinding UI not found (grep for rebind finds only animation files) | `Runtime/Player/`, `12_Systems/hud_and_ui.md` §15 | - | Rebinding is promised in `ring0_plan.md` ("Input System: controller + keyboard/mouse, rebinding") and absent | Backlog after the fun test | P3 |
| SYS-CORE-05 | Settings and accessibility | Colorblind palettes, reduced flash, hold or toggle, volume buses | TESTED (`Accessibility.cs`) | IMPLEMENTED (accessibility window, phase 1) | `Code/Ascend.Core/Accessibility.cs`, `Runtime/UI/` | Save | Not re-verified since 2026-11-08 | - | P3 |
| SYS-CORE-06 | UI framework | Windows drawn with IMGUI as placeholders, opened through `WindowHub` | n/a | IMPLEMENTED as placeholder; the styled "System window" look is DOCUMENTED | `Runtime/UI/` (largest files: `SystemWindow.cs` 646, `WorldMapWindow.cs` 581, `RingZeroHud.cs` 555 lines) | - | IMGUI is not a shipping UI; lazy singletons (TD-11); no decision recorded between UI Toolkit and UGUI | Architecture decision before any UI polish | P2 |
| SYS-CORE-07 | Camera | Cinemachine orbit and lock-on | n/a | IMPLEMENTED, TESTED (locale test, lock-on) | `Runtime/Camera/` | - | - | - | P4 |
| SYS-CORE-08 | Audio runtime | Adaptive music and ambience state machines | TESTED (`AdaptiveMusic.cs`, `EnvironmentAudio.cs`) | **Not wired**: one file in Runtime references an `AudioSource` (`CombatFx.cs`); no music or ambience playback; no audio assets | `Code/Ascend.Core/AdaptiveMusic.cs`, `Runtime/Combat/CombatFx.cs` | Licensed audio (owner) | The game is effectively silent | Blocked on audio sources and licences | P2 |
| SYS-CORE-09 | Core gameplay loop | Take a job, fight, loot, craft or buy, rank up | TESTED in parts | IMPLEMENTED for Ring 0 (quests, combat, loot, shops, crafting, guild rank F to E) | `13_Production/ring0_plan.md` progress table | Everything above | **Never played through and judged by a person on record**: the fun test is unrun | Run the fun test | P0 |
| SYS-TEC-01 | Data validator and schemas | Generated schemas plus cross-file checks (orphans, price loops, map and graph findings) | TESTED by use: passes today | n/a | `Tools/validate/` | - | `build_schemas.js` wrote `Data/Schemas/encounters.schema.json`, which was never committed; CI's "generated data must be committed" step uses `git diff`, which does not see untracked files (committed in this session) | Make the CI step fail on untracked files under `Data/` | P2 |
| SYS-TEC-02 | Generators | Species, rigs, motion, classes | TESTED by use; deterministic (CI diff check) | n/a | `Tools/monster_gen/`, `Tools/classes/` | - | - | - | P4 |
| SYS-TEC-03 | Continuous integration | GitHub Actions: `npm run build` on every push and pull request | Passed for merged batches (progress log) | **Unity is not in CI**: no compile, no PlayMode | `.github/workflows/ci.yml` | Unity licence | A change can break the game and CI stays green | Accept (licence) and compensate with the weekly PC verify run | P1 |
| SYS-TEC-04 | Unity PlayMode suite | 26 test files, 183 test attributes | n/a | TESTED on 2026-11-08 (183 passed); **not re-run after the 2026-11-09 and 2026-11-11 merges** | `Game/Assets/_Game/Tests/PlayMode/`, `13_Production/progress_log.md` | Owner's PC | Four days of merges since the last run. The merges were Core, data and docs by their descriptions, but that is unverified | PC verify run | P0 |
| SYS-TEC-05 | PC update and verify script | Pull, build, rebuild scene, PlayMode, player build, screenshots | n/a | IMPLEMENTED; last run not recorded in the repo (logs are gitignored) | `Tools/pc/update_and_verify.cmd` | Owner | No committed record of any run, so nobody can cite one | Commit a one-line result per run to `QUALITY_GATES.md` §3 | P1 |
| SYS-TEC-06 | Player build | Standalone Windows build of the Ring 0 scene | n/a | IMPLEMENTED (`BuildPlayer.BuildRing0`) | `Editor/BuildPlayer.cs` | - | Executable is `ProjectAscend.exe`, product name "Game", version 1.0 | With SYS-CORE-03 | P3 |
| SYS-TEC-07 | Obsidian vault builder | Mirrors the bible and data into `ideas/` | Works | n/a | `Tools/vault/build_vault.js` | - | `Planning/` was not in its folder list (added in this session) | - | P4 |
| SYS-TEC-08 | Blender pipelines | Buildings, creatures, terrain, diorama, bake to game | Scripts exist; outputs are local and gitignored | Only 3 creature FBX files are tracked; nothing baked is placed in the shipping scene | `Tools/blender/`, `Art/Blender/` | Owner's PC and GPU | The chain bake → import → place has not been proven end to end for one asset | One asset through the whole chain | P1 |
| SYS-TEC-09 | AI image and image-to-3D tools | Gemini image CLI, TripoSR wrapper | Self-test exists | n/a | `Tools/ai_images/`, `Tools/ai3d/` | Owner's keys | - | - | P4 |
| SYS-TEC-10 | Performance measurement | Budgets written (`art_budgets.md`); a read-only Core review found 6 per-frame allocation sites | **No measurement exists**: no profiler capture, no frame-time number anywhere in the repo | n/a | `13_Production/perf_review_core_2026-11-08.md`, `tech_debt_register.md` TD-01 to TD-06 | Owner's PC | The 60 fps target for Ring 0 is asserted, not measured | One profiler capture in the Ring 0 field | P1 |
| SYS-TEC-11 | Studio layer | Skills, 34 extra agents, rules, scripts under `.claude/` | Installed; hooks and `settings.json` are not | n/a | `.claude/`, `13_Production/adoption-plan-2026-11-07.md` | Owner decision on hooks | `.claude/docs/model-tiers.md` describes agent pins that did not match the files and names retired Godot and Unreal agents; several helper scripts assume other paths | Documentation task | P3 |
| SYS-TEC-12 | Version control | Git with LFS for `.blend`, `.fbx`, `.png`, `.wav` | 396 LFS files | n/a | `.gitattributes` | - | Work happened on about 20 local agent branches and 28 worktrees on the PC (risk register); from the cloud only 7 remote branches are visible, so local-only work cannot be audited | Owner: prune or push | P2 |
| SYS-TEC-13 | Release and deployment | Steam release | DOCUMENTED and deliberately parked by the owner | - | `13_Production/production.md` §6 | - | - | None until the slice gate | P4 |

## 2. WHAT IS MISSING

1. Any performance measurement.
2. Unity in an automated gate.
3. Architecture decision records (the layer rule, the UI technology, the save version rule, the scene and streaming plan are all unwritten or implicit).
4. A committed record of PC verify runs.
5. Audio playback and assets.
6. A proven art path from Blender to the shipping scene.
7. A decision on product name, company name and executable name (they fix the save path).

## 3. PROBLEMS IDENTIFIED

| # | Finding | Evidence | Label |
|---|---|---|---|
| T-1 | The usage limit is a live production constraint: it stopped three of this audit's own agents | Task failure notices at the 5-hour limit, 2026-11-12 | VERIFIED FACT |
| T-2 | "Implemented" in the progress log often means "rules written and tested in Core". Three specialist audits independently found finished Core systems and data files that the game never reads | Combat audit rows SYS-CMB-08, -15, -20, -22; ecology audit SYS-ECO-03, SYS-WLD-12; exploration audit headline 3 | VERIFIED FACT |
| T-3 | `13_Production/phase1_api.md` §5 says companion bonds and presets are not in the save; `SaveGame.cs` lines 83 to 85 has both fields | files | VERIFIED FACT (stale doc) |
| T-4 | The newest handover is 2026-11-02; CLAUDE.md tells every session to start there. It reports 177 tests and "nothing compiled in Unity since 2026-10-31", both superseded | `13_Production/handover/handover_2026-11-02.md`, `progress_log.md` | VERIFIED FACT |
| T-5 | Generated schema never committed and CI cannot notice | `git status` after `npm run build`; `ci.yml` last step | VERIFIED FACT (fixed: file committed) |
| T-6 | Test counts in documents disagree: README "57 tests", ring0_plan "177 + 136", roadmap "746 + 183", progress log "755" | files | VERIFIED FACT |
| T-7 | Agent counts disagree: CLAUDE.md and `agent_team.md` say 27; `.claude/agents/` held 61 files before this session | `ls .claude/agents` | VERIFIED FACT |

## 7. RISKS

Added to `Planning/TECHNICAL_RISK_REGISTER.md` as R15 to R24.

## 8. DECISIONS REQUIRED

Product, company and executable name; whether hooks and `settings.json` are installed; UI technology; prune or push the local branches and worktrees.

TESTING REQUIRED: a PC verify run (compile, 183 PlayMode, player build) on current `main` plus this branch; one profiler capture.
CONFIDENCE: high on file facts and on the Core run; none on the Unity state after 2026-11-08, which could not be inspected.
UNRESOLVED QUESTIONS: what is on the PC's local branches and worktrees; whether the 2026-11-11 merge still compiles in Unity.
FINAL STATUS: audit delivered; recommendations only.
