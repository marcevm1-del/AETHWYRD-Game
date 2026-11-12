# Roadmap and milestones after the upgrade waves (producer, 2026-11-09)

> **2026-11-12:** the live version is now `Planning/MASTER_ROADMAP.md` and `Planning/MILESTONE_TRACKER.md` (milestones M0 to M5 are mapped there). This file is kept as written.

Job 1 of the producer queue. Sources: `ring0_plan.md` (target January 2027), `progress_log.md` (746 Core tests + 183 Unity PlayMode at phase 1), `world_upgrade_plan.md`, `handover_2026-11-02.md`, `project-stage-report.md` and the Unity dependency map in this folder. Dates are windows, not promises: capacity is set by `risk_register_and_usage_budget.md` (2 agents working at a time).

## Where we are (2026-11-09)

- **Ring 0 weeks 1-10:** done except week 3 (your own VRoid character; capsule stand-in until the VRM arrives) and the week-10 fun-test checklist (`combat.md` §12) and polish list.
- **Upgrade waves:** A1 animation, A2 combat, B crafting, C companions, D audio, E dungeons, F-lite world graph merged; Part 2 steps 1-4 (gear and runes, housing and farming, stables, Civilization Archive) merged; Canon §6 decided under delegated creative control; rename to AETHWYRD done; phase 1 (Core wired into Unity, windows, accessibility, photo mode) and phase 1b front end merged.
- **Baseline:** 746 Core tests, 183 PlayMode, data valid, 28 map warnings, 0 graph findings.
- **Open:** about 9 agent branches with unmerged work, world terrain and diorama not in the game, no audio playback (state logger only), no game brief file (adoption plan item 1).

## Milestones

| # | Milestone | Done when | Needs from you | Depends on |
|---|---|---|---|---|
| M0 | **Integrate and clean** | Pending branches merged in the order from the dependency map; baseline verify run green; stale worktrees pruned; progress log, daily note and vault updated | OK to prune worktrees | Risk register caps |
| M1 | **Ring 0 shippable** | Week-10 polish list and the `combat.md` §12 fun-test checklist pass; standalone build runs at steady 60 fps in the field; 746+ and 183+ tests still green | Run the fun test; export the VRM or choose the humans-base character | M0 |
| M2 | **Systems playable in the field** | Companion presets and tactics, crafting quality, journal, accessibility and photo mode persist through save and load (old saves load); companion presets and bonds saved | none | M0, save-migration tests merged |
| M3 | **Look and sound pass** | Player character in game (VRM or humans-base), director-approved creature and building sheets rebuilt in the toon standard, music playback of the Ring 0 cue sheet, SFX list implemented | Pick or approve the character; voice amount; font licence; pack licences | M1 |
| M4 | **Ring 1 (Whisperwood and Millbrook region) content** | Whisperwood field uses real settlement and terrain data behind the terrain flag; quests sit on real places (0 orphans); encounter tables merged | 10.24 km tile size, Brindlewick rebase, out-of-map behaviour | M2, M3 |
| M5 | **Vertical slice for outsiders** | `/vertical-slice` style build: one region start to finish, store-page materials list, qa-lead gate check | Title, store accounts, any purchases (yours) | M4 |

## Suggested order by 5-hour window

1. **Window 1:** M0. Merge order from the dependency map, one `npm run build` after each merge, then the baseline Unity run. Pair: tools-pipeline-engineer + qa-tester (Unity slot).
2. **Window 2:** M1 engineering. gameplay-engineer polish list with qa-tester; narrative-writer or class-skill-designer fills the second slot with Data-only work.
3. **Window 3:** M2. save-platform-engineer + ai-engineer (companion persistence and the group-tactics wiring), then code-reviewer.
4. **Windows 4-5:** M3. environment-artist and creature-artist toon sheet rebuilds in the background GPU slot (counts as one agent); audio-designer and animator-rigger in Unity slots.
5. **Windows 6+:** M4 in the same pair rhythm; M5 when M4's checks are green.

After each window: progress-log row, daily note, vault rebuild (CLAUDE.md rule), and the budget telemetry row.

## Decisions waiting on you (each stops a milestone if unanswered)

| Decision | Stops |
|---|---|
| Your VRoid export or approval of the humans-base character | M1 (week 3), M3 |
| Terrain tile size 10.24 km, Brindlewick rebase, out-of-map = open sea | M4 |
| Voice amount, display-serif font licence, pack licences, TripoSR | M3 |
| MCP bridges for Blender and Unity (add a package to the game) | optional speed-up |
| Settlement moves (proposals only so far) | M4 |
| Whether to prune the 5+ empty agent worktrees | M0 |

Where you said "do it all, stop asking me", agents take the default and log it so you can overrule; the items above are the ones that were left as yours (licences, accounts, purchases, character choice).

## Not on this roadmap (deliberately)

Multiplayer, live-ops, localization and Steam release prep: out of scope until M5. The studio's `/gate-check` and sprint folders are not used at the `minimal` rigor setting; this file and `progress_log.md` are the plan.
