# Feature backlog

The only list agents implement from. A task enters when its parent upgrade or idea has passed `CHANGE_CONTROL.md` stage E. Template: `TASK_TEMPLATES.md` §1.

## State of this backlog on 2026-11-12

This is the **first, proposed** backlog. Three tasks are READY because earlier owner-accepted plans already call for them (the verify run and the fun test). Every other task is **AWAITING APPROVAL**: it is written out in full so that approval can be a single word per group, but no agent starts it until the owner approves the plan (`MASTER_PROJECT_PLAN.md` §8).

All tasks finish, prove or connect something that exists (decision D-010). No task starts a new system.

Statuses: AWAITING APPROVAL · READY · IN PROGRESS · BLOCKED · IN REVIEW · DONE · DROPPED.
Effort: S under half a usage window, M about one window, L more. These are estimates by the auditors, not measurements.

## Not in the backlog on purpose

The other upgrades needed by the slice (UPG-007 Grukk's verbs, UPG-008 weakness readout, UPG-011 bestiary vocabulary, UPG-018 liberation delta, UPG-016 redacted line) become tasks when phase 2 is done and their owner decisions are in. The presentation work (UPG-024 beyond one creature, UPG-030 audio, UPG-031 character, UPG-032 UI technology) waits on the owner's inputs. Everything else in `UPGRADE.md` and all of `IDEAS.md` is outside the backlog until after the slice gate.


## Index

| ID | Task | Parent | Owner | Priority | Status | Needs Unity |
|---|---|---|---|---|---|---|
| T-001 | PC verify run on current main | UPG-026 / MS-1 | owner (run) / qa-tester (triage) | P0 | READY | yes |
| T-002 | Split the fun test and prepare its record sheet | UPG-001 / MS-2 | combat-designer | P0 | READY | no |
| T-003 | Play the fun test and record it | UPG-001 / MS-2 | owner | P0 | READY | yes |
| T-005 | Magical damage branch in Core, with tests | UPG-004 | core-rules-engineer | P2 | AWAITING APPROVAL | no |
| T-008 | Whisperwood rank-band data fix | UPG-019 | bestiary-designer | P1 | AWAITING APPROVAL | no |
| T-013 | Dead-data report and CI untracked-file check | UPG-025 | tools-pipeline-engineer | P2 | AWAITING APPROVAL | no |
| T-020 | Documentation drift sweep | UPG-029 | documentation-auditor (check) / owning agents (edit) | P2 | AWAITING APPROVAL | no |
| T-021 | Four architecture decision records | UPG-039 | technical-director | P2 | AWAITING APPROVAL | no |
| T-025 | Verify the character system in Unity | UPG-041 | qa-tester | P1 | READY | yes |
| T-026 | Import generated bodies as the player bodies | UPG-041 | technical-artist | P1 | READY | yes |
| T-027 | Model the violet samurai pieces in the character generator | UPG-041 | creature-artist | P2 | READY | no |
| T-024 | Reproduce and fix kill credit for companion and partner kills | UPG-040 | gameplay-engineer | P0 | AWAITING APPROVAL | yes |
| T-004 | Pass the reaction table into the game | UPG-003 | gameplay-engineer | P1 | AWAITING APPROVAL | yes |
| T-006 | Enforce `launchable` | UPG-005 | gameplay-engineer | P1 | AWAITING APPROVAL | yes |
| T-007 | Wire group tactics for the goblin pack | UPG-002 | ai-engineer | P1 | AWAITING APPROVAL | yes |
| T-009 | Quest reachability test; park or place | UPG-014 | qa-tester (test) / quest-designer (data) | P1 | AWAITING APPROVAL | yes |
| T-010 | Journal pages for discoveries and quests | UPG-010 | ui-engineer | P1 | AWAITING APPROVAL | yes |
| T-012 | First profiler capture | UPG-027 / MS-3 | performance-analyst (brief) / owner or qa-tester (capture) | P1 | AWAITING APPROVAL | yes |
| T-018 | Encounter tables as the spawn source for the field, behind a flag | UPG-020 | core-rules-engineer (reader) then world-builder-engineer (spawner) | P1 | AWAITING APPROVAL | yes |
| T-014 | Allocation fixes TD-01 to TD-04, only if T-012 shows them | UPG-027 | core-rules-engineer | P2 | AWAITING APPROVAL | partly |
| T-019 | Show an active event's rumour on the board | UPG-022 | gameplay-engineer | P3 | AWAITING APPROVAL | yes |
| T-023 | Acts and story flags as data | UPG-015 | core-rules-engineer | P3 | AWAITING APPROVAL | partly |
| T-011 | Discovery registry and four to six Whisperwood discoveries | UPG-009 | exploration-designer (design, data) / tools-pipeline-engineer (schema) / world-builder-engineer (placement) | P1 | AWAITING APPROVAL | partly |
| T-015 | One creature from Blender into the shipping scene | UPG-024 | technical-artist / creature-artist | P1 | AWAITING APPROVAL | yes |
| T-017 | Quest choices with outcomes and a receipt | UPG-013 | quest-designer (data) / core-rules-engineer (rules) / ui-engineer (receipt) | P1 | AWAITING APPROVAL | partly |
| T-022 | Save version rule and product identity | UPG-028 | save-platform-engineer | P1 | AWAITING APPROVAL | partly |
| T-016 | File the Ring 0 quests under the confirmed region | UPG-020 / CD-009 | quest-designer | P2 | AWAITING APPROVAL | no |

## A. Approved: can start now

### T-001: PC verify run on current main

```text
TASK ID:            T-001
TASK TITLE:         PC verify run on current main
PARENT FEATURE:     UPG-026 / MS-1
SYSTEM:             SYS-TEC-04, SYS-TEC-05
DESCRIPTION:        Run `Tools/pc/update_and_verify.cmd` on `main` with this branch merged or checked out. Record commit, Core count, PlayMode count, build result.
PLAYER BENEFIT:     A build known to start.
IMPLEMENTATION DETAILS:Commit or discard any local change first (the scene rebuild leaves a diff after each run). Double-click the script; copy the summary line into `QUALITY_GATES.md` §3. If it fails, the failing log goes to the qa-tester as the next task.
OWNER:              owner (run) / qa-tester (triage)
REVIEWER:           orchestrator
MODEL TIER:         sonnet
PRIORITY:           P0
STATUS:             READY
DEPENDENCIES:       None
EFFORT:             S (one owner session)
COMPLEXITY:         S
RISKS:              The run may fail after two unverified merge batches.
AFFECTED FILES:     `Planning/QUALITY_GATES.md`
ACCEPTANCE CRITERIA:The script's pull step says OK (not SKIPPED: a dirty tree skips the pull and tests an old commit), the recorded hash equals the remote's, Core passes, PlayMode has 0 failures and at least 183 passes, the player builds. A red run is recorded as Failed and is not a pass of this task.
TESTING REQUIREMENTS:The run.
DOCUMENTATION REQUIREMENTS:Gate row; progress-log row.
NEEDS UNITY:        yes
```

### T-002: Split the fun test and prepare its record sheet

```text
TASK ID:            T-002
TASK TITLE:         Split the fun test and prepare its record sheet
PARENT FEATURE:     UPG-001 / MS-2
SYSTEM:             SYS-CMB-32
DESCRIPTION:        Divide `combat.md` §12 into 'testable now' and 'needs wiring'; add a record sheet (date, build, settings, pass or fail, one sentence). Reconcile 'six checks' in `ring0_plan.md`.
PLAYER BENEFIT:     The owner's hour is spent playing, not parsing a checklist.
IMPLEMENTATION DETAILS:Doc edit only; no rule changes.
OWNER:              combat-designer
REVIEWER:           qa-tester
MODEL TIER:         sonnet
PRIORITY:           P0
STATUS:             READY
DEPENDENCIES:       None
EFFORT:             S
COMPLEXITY:         S
RISKS:              None.
AFFECTED FILES:     `12_Systems/combat.md`, `13_Production/ring0_plan.md`
ACCEPTANCE CRITERIA:Two lists and a sheet exist; each 'needs wiring' item names its upgrade.
TESTING REQUIREMENTS:Review.
DOCUMENTATION REQUIREMENTS:The files themselves.
NEEDS UNITY:        no
```

### T-003: Play the fun test and record it

```text
TASK ID:            T-003
TASK TITLE:         Play the fun test and record it
PARENT FEATURE:     UPG-001 / MS-2
SYSTEM:             SYS-CMB-32, SYS-CORE-09
DESCRIPTION:        Ten minutes against slimes, goblins and rabbits in the standalone build; fill the sheet.
PLAYER BENEFIT:     Knows whether the core is fun.
IMPLEMENTATION DETAILS:Owner plays; failures become tasks.
OWNER:              owner
REVIEWER:           combat-designer
MODEL TIER:         -
PRIORITY:           P0
STATUS:             READY
DEPENDENCIES:       T-001, T-002
EFFORT:             S (one owner session)
COMPLEXITY:         S
RISKS:              Feel problems found.
AFFECTED FILES:     A dated note in `13_Production/`
ACCEPTANCE CRITERIA:Every testable box is pass or fail against the list frozen in T-002; every fail has a P0 task.
TESTING REQUIREMENTS:Manual.
DOCUMENTATION REQUIREMENTS:The note; dashboard.
NEEDS UNITY:        yes
```


## B. Proposed first wave: no Unity needed

### T-005: Magical damage branch in Core, with tests

```text
TASK ID:            T-005
TASK TITLE:         Magical damage branch in Core, with tests
PARENT FEATURE:     UPG-004
SYSTEM:             SYS-CMB-06, SYS-PRG-06
DESCRIPTION:        `DamageCalculator.Compute` uses MATK against MDEF when the kind is magical; skills carry their kind; casting spends MP.
PLAYER BENEFIT:     Caster classes become possible later.
IMPLEMENTATION DETAILS:Core only; Unity call sites stay as they are until a PC slot.
OWNER:              core-rules-engineer
REVIEWER:           code-reviewer
MODEL TIER:         sonnet
PRIORITY:           P2 (not needed for the slice; do after the slice gate unless a slot is free)
STATUS:             AWAITING APPROVAL
DEPENDENCIES:       A damage-kind field on skill data under a name that does not collide with the existing skill `kind` (chain, launcher)
EFFORT:             S
COMPLEXITY:         S
RISKS:              Balance untested in play.
AFFECTED FILES:     `Code/Ascend.Core/Damage.cs`, `Skills.cs`, new tests
ACCEPTANCE CRITERIA:The documented ratio holds; physical results unchanged; 755 or more tests pass.
TESTING REQUIREMENTS:`npm run build`.
DOCUMENTATION REQUIREMENTS:`combat.md` §9 note; inventory row.
NEEDS UNITY:        no
```

### T-008: Whisperwood rank-band data fix

```text
TASK ID:            T-008
TASK TITLE:         Whisperwood rank-band data fix
PARENT FEATURE:     UPG-019
SYSTEM:             SYS-ECO-04
DESCRIPTION:        Resolve the 18 over-band species-region pairs in Whisperwood by the rule the owner picks.
PLAYER BENEFIT:     No rank-C monster in the starter wood by accident.
IMPLEMENTATION DETAILS:Change generator inputs, regenerate.
OWNER:              bestiary-designer
REVIEWER:           canon-keeper
MODEL TIER:         sonnet
PRIORITY:           P1
STATUS:             AWAITING APPROVAL
DEPENDENCIES:       Owner picks the rule: widen the band, drop the habitat, or mark 'rare, deep only' (recommended: mark)
EFFORT:             S
COMPLEXITY:         S
RISKS:              Generated data: never hand-edit the JSON.
AFFECTED FILES:     `Tools/monster_gen/`, `Data/Monsters/*.json` (generated)
ACCEPTANCE CRITERIA:Zero over-band pairs for Whisperwood; build green.
TESTING REQUIREMENTS:`npm run build`.
DOCUMENTATION REQUIREMENTS:`regional_ecology.md` findings.
NEEDS UNITY:        no
```

### T-013: Dead-data report and CI untracked-file check

```text
TASK ID:            T-013
TASK TITLE:         Dead-data report and CI untracked-file check
PARENT FEATURE:     UPG-025
SYSTEM:             SYS-TEC-01, SYS-CORE-02
DESCRIPTION:        The validator lists each data file and whether Core or Runtime references it; CI fails on untracked files under `Data/`.
PLAYER BENEFIT:     None directly; stops tuning of no-ops.
IMPLEMENTATION DETAILS:A text search over `Code/` and `Game/Assets/_Game/` per file name, with an allow-list of reserved files.
OWNER:              tools-pipeline-engineer
REVIEWER:           code-reviewer
MODEL TIER:         sonnet
PRIORITY:           P2
STATUS:             AWAITING APPROVAL
DEPENDENCIES:       None
EFFORT:             S
COMPLEXITY:         S
RISKS:              False positives.
AFFECTED FILES:     `Tools/validate/`, `.github/workflows/ci.yml`
ACCEPTANCE CRITERIA:The report names today's three unread files; CI fails on an untracked generated file.
TESTING REQUIREMENTS:`npm run build`; a deliberate untracked file.
DOCUMENTATION REQUIREMENTS:`CONTENT_PRODUCTION_PIPELINE.md`.
NEEDS UNITY:        no
```

### T-020: Documentation drift sweep

```text
TASK ID:            T-020
TASK TITLE:         Documentation drift sweep
PARENT FEATURE:     UPG-029
SYSTEM:             docs
DESCRIPTION:        Fix the open rows of `CANON_DISCREPANCIES.md` part B in their owners' files. No rule changes.
PLAYER BENEFIT:     True statements for the next session.
IMPLEMENTATION DETAILS:One pass per owning agent's files; the auditor re-checks.
OWNER:              documentation-auditor (check) / owning agents (edit)
REVIEWER:           canon-keeper
MODEL TIER:         haiku for checks, sonnet for edits
PRIORITY:           P2
STATUS:             AWAITING APPROVAL
DEPENDENCIES:       None
EFFORT:             S
COMPLEXITY:         S
RISKS:              None.
AFFECTED FILES:     Listed per CD row
ACCEPTANCE CRITERIA:Every part B row is RESOLVED or waits on a named owner decision.
TESTING REQUIREMENTS:Re-run of the auditor's checks.
DOCUMENTATION REQUIREMENTS:The register itself.
NEEDS UNITY:        no
```

### T-021: Four architecture decision records

```text
TASK ID:            T-021
TASK TITLE:         Four architecture decision records
PARENT FEATURE:     UPG-039
SYSTEM:             SYS-CORE-01
DESCRIPTION:        Layer rule; save versioning; UI technology options; scenes and streaming for more than one region.
PLAYER BENEFIT:     -
IMPLEMENTATION DETAILS:Short records: context, decision, alternatives, consequences.
OWNER:              technical-director
REVIEWER:           red-team-reviewer
MODEL TIER:         opus
PRIORITY:           P2
STATUS:             AWAITING APPROVAL
DEPENDENCIES:       Owner says where they live (`13_Production/` or a new `docs/architecture/`)
EFFORT:             S
COMPLEXITY:         M
RISKS:              None.
AFFECTED FILES:     New files
ACCEPTANCE CRITERIA:Four records reviewed.
TESTING REQUIREMENTS:Red-team review.
DOCUMENTATION REQUIREMENTS:Linked from the master plan.
NEEDS UNITY:        no
```


## C. Proposed: needs a Unity slot on the owner's PC

### T-025: Verify the character system in Unity

```text
TASK ID:            T-025
TASK TITLE:         Verify the character system in Unity
PARENT FEATURE:     UPG-041
SYSTEM:             SYS-CHR-01
DESCRIPTION:        Compile the 2026-11-15 character work (Runtime/Characters, CharacterImport, Ascend/ToonCharacter, creator changes) and run PlayMode, including CharacterCustomizationPlayModeTests. Fix compile or test failures.
PLAYER BENEFIT:     The customization screen works.
IMPLEMENTATION DETAILS:Part of the PC verify run (T-001); then open the creator, choose Customize look, try every category.
OWNER:              qa-tester (with gameplay-engineer for fixes)
REVIEWER:           code-reviewer
MODEL TIER:         sonnet
PRIORITY:           P1
STATUS:             READY
DEPENDENCIES:       T-001
EFFORT:             S
COMPLEXITY:         S
RISKS:              Unity API differences from the stand-ins used to compile in the cloud.
AFFECTED FILES:     Game/Assets/_Game/Runtime/Characters/, Runtime/UI/FrontEnd/, Editor/CharacterImport.cs, Art/Shaders/AscendToonCharacter.shader
ACCEPTANCE CRITERIA:0 compile errors; PlayMode 0 failures; the new tests pass; a screenshot of the customization screen.
TESTING REQUIREMENTS:Full PlayMode suite.
DOCUMENTATION REQUIREMENTS:Status rows in 12_Systems/character_customization.md.
NEEDS UNITY:        yes
```

### T-026: Import generated bodies as the player bodies

```text
TASK ID:            T-026
TASK TITLE:         Import generated bodies as the player bodies
PARENT FEATURE:     UPG-041
SYSTEM:             SYS-CHR-01
DESCRIPTION:        Regenerate human_female_base and human_male_base with the current generator (slot masks), copy the FBX into Game/Assets/_Game/Art/Models/Characters/, make prefabs Resources/PlayerBodies/Feminine and Masculine with a "Visual" root and the player Animator.
PLAYER BENEFIT:     A real character instead of a capsule.
IMPLEMENTATION DETAILS:CharacterImport sets Humanoid, the shader and UV3. Check the avatar maps all 52 bones.
OWNER:              technical-artist
REVIEWER:           anime-fantasy-director
MODEL TIER:         sonnet
PRIORITY:           P1
STATUS:             READY
DEPENDENCIES:       T-025
EFFORT:             M
COMPLEXITY:         M
RISKS:              FBX size in LFS; the locomotion clips on the new avatar.
AFFECTED FILES:     Game/Assets/_Game/Art/Models/Characters/, Game/Assets/Resources/PlayerBodies/
ACCEPTANCE CRITERIA:The player runs, fights and changes colour per slot in the field; FootIK's humanoid path works; frame time noted.
TESTING REQUIREMENTS:PlayMode; a profiler capture with the new body.
DOCUMENTATION REQUIREMENTS:13_Production/character_system.md import section.
NEEDS UNITY:        yes
```

### T-027: Model the violet samurai pieces in the character generator

```text
TASK ID:            T-027
TASK TITLE:         Model the violet samurai pieces in the character generator
PARENT FEATURE:     UPG-041
SYSTEM:             SYS-CHR-01
DESCRIPTION:        Add to Tools/blender/ascend_characters/outfit.py and hair.py the pieces the two samurai looks need: haori (knee coat, wide sleeves), kimono wrap top, hakama, obi with knot, knee-length layered skirt, tabi boots, sleeve guards; samurai ponytail, messy and topknot hair. Mark them built in customization.json.
PLAYER BENEFIT:     The concept sheet's look becomes playable.
IMPLEMENTATION DETAILS:Shells built like the existing pieces; colours from the slot palette so slots.py classifies them; turnaround sheets per piece.
OWNER:              creature-artist (character generator)
REVIEWER:           anime-fantasy-director
MODEL TIER:         sonnet
PRIORITY:           P2
STATUS:             READY
DEPENDENCIES:       None (Blender only; works in the cloud)
EFFORT:             L
COMPLEXITY:         M
RISKS:              Clipping of long garments when walking; the 30k triangle budget.
AFFECTED FILES:     Tools/blender/ascend_characters/, Data/Characters/human_library.json, Data/Characters/customization.json
ACCEPTANCE CRITERIA:Both samurai looks validate as built; check_characters.py passes; reconstruction error under 0.02 per part; director review passes the teen-rating rule.
TESTING REQUIREMENTS:check_characters.py; npm run build.
DOCUMENTATION REQUIREMENTS:character_system.md.
NEEDS UNITY:        no
```

### T-024: Reproduce and fix kill credit for companion and partner kills

```text
TASK ID:            T-024
TASK TITLE:         Reproduce and fix kill credit for companion and partner kills
PARENT FEATURE:     UPG-040
SYSTEM:             SYS-CMB-26, SYS-CMP-04, SYS-CMP-07
DESCRIPTION:        Write a PlayMode test in which a companion lands the last hit on a quest monster and on Grukk. If it fails as the code reading predicts, raise a defeated event from the monster and move XP, loot, quest, bestiary and siege subscribers onto it.
PLAYER BENEFIT:     Fighting beside a partner never loses the reward or the liberation.
IMPLEMENTATION DETAILS:Test first. Credit rule from data (recommended: full credit).
OWNER:              gameplay-engineer
REVIEWER:           code-reviewer, qa-tester
MODEL TIER:         sonnet
PRIORITY:           P0
STATUS:             AWAITING APPROVAL
DEPENDENCIES:       T-001
EFFORT:             S
COMPLEXITY:         S
RISKS:              Double credit; XP balance.
AFFECTED FILES:     `Runtime/World/MonsterDummy.cs`, `PlayerCombat.Progress.cs`, `SiegeDirector.cs`, `PlayerBestiary.cs`, `PlayerInventory.cs`, `PlayerQuests.cs`, a PlayMode test
ACCEPTANCE CRITERIA:Companion kill of Grukk gives liberation, XP, loot, quest credit and bestiary tick exactly once; PlayMode has 0 failures.
TESTING REQUIREMENTS:New PlayMode test; full PlayMode run.
DOCUMENTATION REQUIREMENTS:Inventory rows; risk R31.
NEEDS UNITY:        yes
```

### T-004: Pass the reaction table into the game

```text
TASK ID:            T-004
TASK TITLE:         Pass the reaction table into the game
PARENT FEATURE:     UPG-003
SYSTEM:             SYS-CMB-07, SYS-CMB-08
DESCRIPTION:        Create the reaction state with the loaded table.
PLAYER BENEFIT:     Reactions follow the design data.
IMPLEMENTATION DETAILS:One constructor argument and a test.
OWNER:              gameplay-engineer
REVIEWER:           code-reviewer
MODEL TIER:         sonnet
PRIORITY:           P1
STATUS:             AWAITING APPROVAL
DEPENDENCIES:       T-001
EFFORT:             S
COMPLEXITY:         S
RISKS:              Low.
AFFECTED FILES:     `Runtime/World/MonsterDummy.cs`, a PlayMode test
ACCEPTANCE CRITERIA:A changed multiplier changes the in-game hit.
TESTING REQUIREMENTS:PlayMode.
DOCUMENTATION REQUIREMENTS:`combat.md` §7; inventory.
NEEDS UNITY:        yes
```

### T-006: Enforce `launchable`

```text
TASK ID:            T-006
TASK TITLE:         Enforce `launchable`
PARENT FEATURE:     UPG-005
SYSTEM:             SYS-CMB-03
DESCRIPTION:        `Launch` respects the species value and shows a 'resisted' cue.
PLAYER BENEFIT:     Heavy monsters feel heavy.
IMPLEMENTATION DETAILS:Read the motion data in `Launch`.
OWNER:              gameplay-engineer
REVIEWER:           qa-tester
MODEL TIER:         sonnet
PRIORITY:           P1
STATUS:             AWAITING APPROVAL
DEPENDENCIES:       T-001
EFFORT:             S
COMPLEXITY:         S
RISKS:              Changes Grukk's fight.
AFFECTED FILES:     `Runtime/World/MonsterDummy.cs`, a PlayMode test
ACCEPTANCE CRITERIA:Staggered large biped launches; unstaggered does not.
TESTING REQUIREMENTS:PlayMode.
DOCUMENTATION REQUIREMENTS:`combat.md` §4.3.
NEEDS UNITY:        yes
```

### T-007: Wire group tactics for the goblin pack

```text
TASK ID:            T-007
TASK TITLE:         Wire group tactics for the goblin pack
PARENT FEATURE:     UPG-002
SYSTEM:             SYS-CMB-20
DESCRIPTION:        Execute `13_Production/handover/group_tactics_wiring.md`, after checking the PC branch `agent/ai-engineer/companion-presets-tactics`.
PLAYER BENEFIT:     Packs surround and break.
IMPLEMENTATION DETAILS:Pass the sense fields; set tactics from tuning.
OWNER:              ai-engineer
REVIEWER:           code-reviewer, qa-tester
MODEL TIER:         sonnet (pass opus if the branch must be reconciled)
PRIORITY:           P1
STATUS:             AWAITING APPROVAL
DEPENDENCIES:       T-001; the PC branch inspected
EFFORT:             M
COMPLEXITY:         M
RISKS:              Yield cycle; Canon §4d.
AFFECTED FILES:     `Runtime/World/MonsterController.cs`, `AggroDirector`, a PlayMode test
ACCEPTANCE CRITERIA:Three distinct approach angles; no state after the fight; off switch restores today.
TESTING REQUIREMENTS:PlayMode; Core unchanged.
DOCUMENTATION REQUIREMENTS:`combat.md` §10a.
NEEDS UNITY:        yes
```

### T-009: Quest reachability test; park or place

```text
TASK ID:            T-009
TASK TITLE:         Quest reachability test; park or place
PARENT FEATURE:     UPG-014
SYSTEM:             SYS-QST-03
DESCRIPTION:        Extend the scene test to every giver, talk target and reach place; mark unreachable quests parked in data or place their NPCs.
PLAYER BENEFIT:     No quest that cannot be finished.
IMPLEMENTATION DETAILS:Test first, then data.
OWNER:              qa-tester (test) / quest-designer (data)
REVIEWER:           code-reviewer
MODEL TIER:         sonnet
PRIORITY:           P1
STATUS:             AWAITING APPROVAL
DEPENDENCIES:       T-001; owner: park or place per quest (recommended: park the 5 dungeon quests, place the NPCs for the rest)
EFFORT:             S
COMPLEXITY:         S
RISKS:              Placing NPCs adds dialogue debt.
AFFECTED FILES:     `Tests/PlayMode/FieldScenePlayModeTests.cs`, `Data/Quests/quests.json`, scene builder
ACCEPTANCE CRITERIA:The test fails on a missing giver for an unparked quest, and passes.
TESTING REQUIREMENTS:PlayMode.
DOCUMENTATION REQUIREMENTS:Quest docs.
NEEDS UNITY:        yes
```

### T-010: Journal pages for discoveries and quests

```text
TASK ID:            T-010
TASK TITLE:         Journal pages for discoveries and quests
PARENT FEATURE:     UPG-010
SYSTEM:             SYS-EXP-08
DESCRIPTION:        Two pages in the journal window.
PLAYER BENEFIT:     One place for what you know and do.
IMPLEMENTATION DETAILS:IMGUI, like the existing pages.
OWNER:              ui-engineer
REVIEWER:           ux-designer
MODEL TIER:         sonnet
PRIORITY:           P1
STATUS:             AWAITING APPROVAL
DEPENDENCIES:       T-001; T-011 for content
EFFORT:             S
COMPLEXITY:         S
RISKS:              Placeholder UI.
AFFECTED FILES:     `Runtime/UI/JournalWindow.cs`
ACCEPTANCE CRITERIA:Both pages list live state in a test.
TESTING REQUIREMENTS:PlayMode.
DOCUMENTATION REQUIREMENTS:`hud_and_ui.md`.
NEEDS UNITY:        yes
```

### T-012: First profiler capture

```text
TASK ID:            T-012
TASK TITLE:         First profiler capture
PARENT FEATURE:     UPG-027 / MS-3
SYSTEM:             SYS-TEC-10
DESCRIPTION:        Capture the Ring 0 field with the goblin pack fighting: frame time, allocations per frame, draw calls.
PLAYER BENEFIT:     Smooth fights, by evidence.
IMPLEMENTATION DETAILS:Unity Profiler; a short note.
OWNER:              performance-analyst (brief) / owner or qa-tester (capture)
REVIEWER:           technical-director
MODEL TIER:         sonnet
PRIORITY:           P1
STATUS:             AWAITING APPROVAL
DEPENDENCIES:       T-001
EFFORT:             S
COMPLEXITY:         S
RISKS:              None.
AFFECTED FILES:     A perf note in `13_Production/`
ACCEPTANCE CRITERIA:Three numbers recorded with the commit.
TESTING REQUIREMENTS:The capture.
DOCUMENTATION REQUIREMENTS:Risk R21 updated.
NEEDS UNITY:        yes
```

### T-018: Encounter tables as the spawn source for the field, behind a flag

```text
TASK ID:            T-018
TASK TITLE:         Encounter tables as the spawn source for the field, behind a flag
PARENT FEATURE:     UPG-020
SYSTEM:             SYS-WLD-12
DESCRIPTION:        A Core reader and a spawner for the Whisperwood camps by zone and time of day.
PLAYER BENEFIT:     The wood differs by day and night.
IMPLEMENTATION DETAILS:Flag off keeps today's hand placement.
OWNER:              core-rules-engineer (reader) then world-builder-engineer (spawner)
REVIEWER:           code-reviewer, qa-tester
MODEL TIER:         sonnet
PRIORITY:           P1
STATUS:             AWAITING APPROVAL
DEPENDENCIES:       T-008; T-001; CD-009
EFFORT:             M
COMPLEXITY:         M
RISKS:              Ring 0 tests assume fixed camps.
AFFECTED FILES:     `Code/Ascend.Core` (new), `Runtime/World/`, scene builder
ACCEPTANCE CRITERIA:Flag on: only listed species per zone and time. Flag off: scene unchanged.
TESTING REQUIREMENTS:Core; PlayMode both ways.
DOCUMENTATION REQUIREMENTS:`encounter_tables.md`.
NEEDS UNITY:        yes
```

### T-014: Allocation fixes TD-01 to TD-04, only if T-012 shows them

```text
TASK ID:            T-014
TASK TITLE:         Allocation fixes TD-01 to TD-04, only if T-012 shows them
PARENT FEATURE:     UPG-027
SYSTEM:             SYS-CMB-18
DESCRIPTION:        Remove the per-frame allocations the capture confirms.
PLAYER BENEFIT:     -
IMPLEMENTATION DETAILS:Keep the random draw order (TD-03).
OWNER:              core-rules-engineer
REVIEWER:           code-reviewer
MODEL TIER:         sonnet
PRIORITY:           P2
STATUS:             AWAITING APPROVAL
DEPENDENCIES:       T-012
EFFORT:             S
COMPLEXITY:         S
RISKS:              Determinism.
AFFECTED FILES:     `Code/Ascend.Core/MonsterAi.cs`, `Loot.cs`, `Skills.cs`, `Defense.cs`
ACCEPTANCE CRITERIA:Before and after numbers from the same scene; tests unchanged.
TESTING REQUIREMENTS:Core tests; capture.
DOCUMENTATION REQUIREMENTS:`tech_debt_register.md` rows set to done.
NEEDS UNITY:        partly
```

### T-019: Show an active event's rumour on the board

```text
TASK ID:            T-019
TASK TITLE:         Show an active event's rumour on the board
PARENT FEATURE:     UPG-022
SYSTEM:             SYS-WLD-10
DESCRIPTION:        Apply the rumour effect of living-world events.
PLAYER BENEFIT:     The town feels alive.
IMPLEMENTATION DETAILS:Read active events in the board.
OWNER:              gameplay-engineer
REVIEWER:           qa-tester
MODEL TIER:         sonnet
PRIORITY:           P3 (not needed for the slice; do after the slice gate unless a slot is free)
STATUS:             AWAITING APPROVAL
DEPENDENCIES:       T-001
EFFORT:             S
COMPLEXITY:         S
RISKS:              Low.
AFFECTED FILES:     `Runtime/World/QuestBoard.cs`
ACCEPTANCE CRITERIA:Rumour appears and disappears with its event.
TESTING REQUIREMENTS:PlayMode.
DOCUMENTATION REQUIREMENTS:`living_world.md`.
NEEDS UNITY:        yes
```

### T-023: Acts and story flags as data

```text
TASK ID:            T-023
TASK TITLE:         Acts and story flags as data
PARENT FEATURE:     UPG-015
SYSTEM:             SYS-QST-06
DESCRIPTION:        Derive the act from flags; every flag has a setter or is marked reserved; validator check.
PLAYER BENEFIT:     Removes a code change from the path to Act II.
IMPLEMENTATION DETAILS:Small.
OWNER:              core-rules-engineer
REVIEWER:           quest-designer
MODEL TIER:         sonnet
PRIORITY:           P3 (not needed for the slice; do after the slice gate unless a slot is free)
STATUS:             AWAITING APPROVAL
DEPENDENCIES:       T-001 for the Unity part
EFFORT:             S
COMPLEXITY:         S
RISKS:              None.
AFFECTED FILES:     `PlayerQuests.cs`, `story_flags.json`, validator
ACCEPTANCE CRITERIA:Validator fails on a setter-less flag; a test reaches act 2 by data.
TESTING REQUIREMENTS:Core; validator.
DOCUMENTATION REQUIREMENTS:Quest docs.
NEEDS UNITY:        partly
```


## D. Proposed: waits on a named owner decision

### T-011: Discovery registry and four to six Whisperwood discoveries

```text
TASK ID:            T-011
TASK TITLE:         Discovery registry and four to six Whisperwood discoveries
PARENT FEATURE:     UPG-009
SYSTEM:             SYS-EXP-08, SYS-EXP-19
DESCRIPTION:        Data file, schema, pickup component, placements, one two-clue chain.
PLAYER BENEFIT:     Curiosity pays.
IMPLEMENTATION DETAILS:Design and schema first (cloud), then the component and placement (Unity).
OWNER:              exploration-designer (design, data) / tools-pipeline-engineer (schema) / world-builder-engineer (placement)
REVIEWER:           red-team-reviewer (before), qa-tester (after)
MODEL TIER:         sonnet; opus for the review
PRIORITY:           P1
STATUS:             AWAITING APPROVAL
DEPENDENCIES:       Owner approves the new data type and the slice scope
EFFORT:             M
COMPLEXITY:         M
RISKS:              Authoring cost per region.
AFFECTED FILES:     `Data/World/` (new), `Data/Schemas/`, `Runtime/World/`, scene builder
ACCEPTANCE CRITERIA:Each discovery appears in the journal and survives save and load.
TESTING REQUIREMENTS:Core; PlayMode; save round-trip.
DOCUMENTATION REQUIREMENTS:`exploration_and_discovery.md`.
NEEDS UNITY:        partly
```

### T-015: One creature from Blender into the shipping scene

```text
TASK ID:            T-015
TASK TITLE:         One creature from Blender into the shipping scene
PARENT FEATURE:     UPG-024
SYSTEM:             SYS-ECO-13, SYS-TEC-08
DESCRIPTION:        Generate, bake to budget, import, place, review. Write the route on one page.
PLAYER BENEFIT:     Creatures instead of capsules.
IMPLEMENTATION DETAILS:PC and GPU.
OWNER:              technical-artist / creature-artist
REVIEWER:           anime-fantasy-director
MODEL TIER:         sonnet
PRIORITY:           P1
STATUS:             AWAITING APPROVAL
DEPENDENCIES:       Owner picks the art route (CD-035); GPU time
EFFORT:             M
COMPLEXITY:         M
RISKS:              GPU hours; style.
AFFECTED FILES:     `Tools/blender/`, `monster_model_pipeline.md`
ACCEPTANCE CRITERIA:One creature in the scene within budget, approved.
TESTING REQUIREMENTS:Budget check; screenshot.
DOCUMENTATION REQUIREMENTS:Pipeline page.
NEEDS UNITY:        yes
```

### T-017: Quest choices with outcomes and a receipt

```text
TASK ID:            T-017
TASK TITLE:         Quest choices with outcomes and a receipt
PARENT FEATURE:     UPG-013
SYSTEM:             SYS-QST-07
DESCRIPTION:        Per-option flags and reward deltas; a receipt line.
PLAYER BENEFIT:     Decisions matter.
IMPLEMENTATION DETAILS:Schema and Core first, then the hand-in UI.
OWNER:              quest-designer (data) / core-rules-engineer (rules) / ui-engineer (receipt)
REVIEWER:           code-reviewer
MODEL TIER:         sonnet
PRIORITY:           P1
STATUS:             AWAITING APPROVAL
DEPENDENCIES:       Owner approves the schema and save change
EFFORT:             M
COMPLEXITY:         M
RISKS:              Ten quests to write out.
AFFECTED FILES:     `Data/Quests/quests.json`, schema, `QuestLog.cs`, `PlayerQuests.cs`
ACCEPTANCE CRITERIA:Two options give two flag sets and two receipts; old saves load.
TESTING REQUIREMENTS:Core; PlayMode; save round-trip.
DOCUMENTATION REQUIREMENTS:`quest_outcome_grammar.md`.
NEEDS UNITY:        partly
```

### T-022: Save version rule and product identity

```text
TASK ID:            T-022
TASK TITLE:         Save version rule and product identity
PARENT FEATURE:     UPG-028
SYSTEM:             SYS-CORE-03
DESCRIPTION:        Write the rule; set product, company and executable names; add the path migration.
PLAYER BENEFIT:     Saves survive the rename.
IMPLEMENTATION DETAILS:Rule and tests in Core; names and migration in Unity.
OWNER:              save-platform-engineer
REVIEWER:           code-reviewer
MODEL TIER:         sonnet
PRIORITY:           P1
STATUS:             AWAITING APPROVAL
DEPENDENCIES:       Owner decides the names
EFFORT:             S
COMPLEXITY:         M
RISKS:              Never touch the real save in tests.
AFFECTED FILES:     `SaveGame.cs`, `PlayerSave.cs`, `ProjectSettings.asset`, `BuildPlayer.cs`
ACCEPTANCE CRITERIA:A save from the old folder loads.
TESTING REQUIREMENTS:Core; PlayMode with a temp folder.
DOCUMENTATION REQUIREMENTS:Decision record.
NEEDS UNITY:        partly
```

### T-016: File the Ring 0 quests under the confirmed region

```text
TASK ID:            T-016
TASK TITLE:         File the Ring 0 quests under the confirmed region
PARENT FEATURE:     UPG-020 / CD-009
SYSTEM:             SYS-WLD-01
DESCRIPTION:        Move the quests filed under Aldmere if the owner confirms Brindlewick belongs to Whisperwood.
PLAYER BENEFIT:     -
IMPLEMENTATION DETAILS:Data edit.
OWNER:              quest-designer
REVIEWER:           canon-keeper
MODEL TIER:         sonnet
PRIORITY:           P2
STATUS:             AWAITING APPROVAL
DEPENDENCIES:       Owner confirms CD-009
EFFORT:             S
COMPLEXITY:         S
RISKS:              None.
AFFECTED FILES:     `Data/Quests/quests.json`
ACCEPTANCE CRITERIA:No Ring 0 quest disagrees with the region decision; build green.
TESTING REQUIREMENTS:`npm run build`.
DOCUMENTATION REQUIREMENTS:`world.md`.
NEEDS UNITY:        no
```
