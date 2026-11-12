# Master roadmap

The phases of development, each with what lets it start, what ends it, and the evidence that proves it ended. Built from the 2026-11-12 audit. It replaces `13_Production/roadmap_after_upgrade_waves.md` as the live roadmap; that file's milestones M0 to M5 are mapped in `MILESTONE_TRACKER.md`.

**There are no dates.** The production rate has not been measured. Effort is in usage windows (one 5-hour window holds about four jobs) and in owner sessions, with the uncertainty stated. Dates can be added when four weekly telemetry rows exist.

The sixteen generic phases in the owner's command were tested against the evidence and reordered: the core loop, combat foundation, creature foundation and progression are largely built as rules, so they are not separate phases here. What the evidence asks for instead is verification, then wiring, then one slice.

## Phase 0: audit and management system

- **Objective:** know what exists; have a way to manage the rest.
- **Exit:** this folder exists and has been reviewed. **Status: done 2026-11-12.**
- **Evidence:** `Planning/audits/` (five reports), `PROJECT_STATUS.md`, `DECISION_LOG.md` D-003 to D-012.

## Phase 1: verify and judge

- **Objective:** establish that the build still works and whether the core loop is fun.
- **Entry:** phase 0.
- **Deliverables:** a PC verify run on current `main` (T-001); the fun test split and played (T-002, T-003); one profiler capture (T-012); owner decisions on the Ring 0 class line-up and the canon batch.
- **Exit criteria:** a `QUALITY_GATES.md` §3 row for the current commit with PlayMode counts; every testable fun-test box marked pass or fail; three performance numbers recorded.
- **Dependencies:** the owner's PC and about two owner sessions.
- **Risks:** R3, R18, R21, R23. The verify run may fail; then repair is the whole phase.
- **Agents:** `qa-tester`, `combat-designer`, `performance-analyst`.
- **Testing:** the runs are the tests.
- **Effort:** 1 to 2 windows of agent time, 2 owner sessions. Low uncertainty unless the build is broken.
- **Completion evidence:** the gate row, the record sheet, the perf note.

## Phase 2: connect what exists

- **Objective:** the tested rules the slice needs are used by the game.
- **Entry:** phase 1 exit; a green baseline to compare against.
- **Deliverables:** UPG-003 reaction table, UPG-004 magical branch (Core), UPG-005 launchable, UPG-002 group tactics, UPG-014 quest reachability test, UPG-025 dead-data report, UPG-019 rank-band fix, UPG-029 documentation sweep, UPG-039 decision records.
- **Exit criteria:** each has its acceptance criteria met with PlayMode or Core evidence; the fun-test items that depended on wiring are retested; dead-data report lists only files marked reserved.
- **Dependencies:** Unity slots for four of the nine; the rest can be done in the cloud.
- **Risks:** R17, R24; shared-file rule on `MonsterAi.cs` (one engineer per wave).
- **Agents:** `gameplay-engineer`, `ai-engineer`, `core-rules-engineer`, `tools-pipeline-engineer`, `quest-designer`, `bestiary-designer`, `documentation-auditor`, `technical-director`; reviews by `code-reviewer` and `qa-tester`.
- **Testing:** PlayMode for each wiring; Core for the formula; `npm run build` after every merge.
- **Effort:** 4 to 6 windows; 3 to 4 Unity slots. Medium uncertainty (the state of the unmerged PC branch).
- **Completion evidence:** updated rows in `SYSTEM_INVENTORY.md` moving from NOT WIRED to TESTED.

## Phase 3: fill the slice

- **Objective:** one region is a complete loop (`VERTICAL_SLICE_PLAN.md` §2).
- **Entry:** phase 2 exit; owner approval of the slice scope and of the two new data types (discoveries, choice outcomes).
- **Deliverables:** UPG-009 discoveries, UPG-010 journal pages, UPG-011 bestiary vocabulary and research tasks, UPG-013 choice outcomes, UPG-020 encounter tables as spawn source, UPG-007 Grukk's verbs, UPG-018 liberation delta, UPG-008 weakness readout, UPG-028 save version rule; UPG-016 if CD-002 is approved.
- **Exit criteria:** slice gate criteria 1 to 6.
- **Dependencies:** owner decisions CD-002, CD-009, CD-011, CD-012; Unity slots.
- **Risks:** R16 (growth), R25, R27 (writing volume).
- **Agents:** `exploration-designer`, `quest-designer`, `creature-ecology-designer`, `combat-designer`, `ui-engineer`, `world-builder-engineer`, `gameplay-engineer`, `save-platform-engineer`; `red-team-reviewer` on the two new data types before they are built.
- **Testing:** Core tests per rule; PlayMode per feature; save round-trips.
- **Effort:** 6 to 9 windows; 5 to 7 Unity slots. High uncertainty: content authoring has no measured rate.
- **Completion evidence:** a played run of the ten steps.

## Phase 4: look and sound

- **Objective:** the slice can be shown.
- **Entry:** can run alongside phases 2 and 3 where the owner's inputs allow; needs the owner's character, art-route and audio decisions.
- **Deliverables:** UPG-031 player character, UPG-024 creatures for the 21 slice species, UPG-030 audio playback, UPG-032 UI technology decision and one styled screen.
- **Exit criteria:** slice gate criteria 7 and 8.
- **Dependencies:** **owner**: VRM or humans-base, licences, GPU time.
- **Risks:** R10, R22, R28.
- **Agents:** `technical-artist`, `creature-artist`, `animator-rigger`, `audio-designer`, `ux-designer`, `ui-engineer`, `anime-fantasy-director`.
- **Effort:** 5 to 8 windows plus GPU hours. High uncertainty: the bake-to-game chain is unproven.
- **Completion evidence:** screenshots, director review, listening pass.

## Phase 5: slice gate

- **Objective:** decide whether the proven systems justify widening.
- **Entry:** phases 3 and 4 exit (or "systems proven, presentation pending").
- **Deliverables:** a standalone build; a playtest by the owner and one outsider; a milestone review by `qa-tester`, `technical-director`, `documentation-auditor`, `red-team-reviewer`.
- **Exit:** go, fix or rethink (`VERTICAL_SLICE_PLAN.md` §6), recorded in `DECISION_LOG.md`.

## Phase 6: Ring 1 complete

- **Objective:** Canon's "The Wooden Card" in full.
- **Entry:** phase 5 "go".
- **Deliverables (to be planned at the gate):** up to three more classes behind UPG-034 with UPG-004 in the game; the Salvage Warren dungeon; the remaining Act I beats; Mochi; the sword family and one more (UPG-006); real terrain for the region if the tile decisions are made.
- **Exit:** Ring 1's own gate, written at phase 5.
- **Effort:** not estimated.

## Phase 7 onward: Rings 2 to 9

Content production by ring as listed in `13_Production/production.md` §5. Not planned further. Before Ring 2 starts, the canon counts (species per ring, NPCs, classes) are cut to what the measured rate supports, as `Canon.md` §6 already foresees for the Ring 2 roster. Release preparation stays parked by the owner's decision.

## Standing tracks (every phase)

| Track | What | Who |
|---|---|---|
| Weekly verify | One recorded PC run | `qa-tester`, owner |
| Canon hygiene | Discrepancy rows closed; §6 ratification | `canon-keeper`, owner |
| Proposal intake | New documents triaged into UPGRADE and IDEAS within a cycle, never straight to tasks | Orchestrator |
| Debt | `tech_debt_register.md` items when the file is next touched | `code-reviewer` |
| Design-only work | Data and lore inside owned folders, Ring 1 first | Design agents, when a slot is free |
