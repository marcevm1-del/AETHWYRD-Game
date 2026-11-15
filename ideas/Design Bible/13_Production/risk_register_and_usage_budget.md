# Risk register and usage-budget plan (producer, 2026-11-09)

> **2026-11-12:** the live version is now `Planning/TECHNICAL_RISK_REGISTER.md` for the risk table (R1 to R14 keep their numbers there, R15 onward are new); sections 1 to 3 and 5 below, the usage-budget rules, stay in force. This file is kept as written.

Job 4 of the producer queue. Inputs: `handover_2026-11-02.md` (the 5-hour limit hit twice with 3 agents in parallel), the Main v1 report (limit hit five times in total; about a dozen simultaneous git worktree checkouts overloaded the slow disk), `world_upgrade_plan.md` ("at most two agents at once"), and `git worktree list` on 2026-11-09 (20 worktrees registered, 6 locked, 1 detached outside the repo at `E:/Ideas/wt-ai-tools`).

No usage numbers were measured for this note (no billing data available to it). Every figure below is a **planning default to tune** after the first week, not a fact.

## 1. How many agent sessions at once (the decision)

| Rule | Value | Why |
|---|---|---|
| Agents **working** at the same time | **2 normally, 3 only if one is read-only / docs-only** | Handover: 3 in parallel burned the 5-hour limit twice; the world upgrade ran fine at 2 |
| Sessions that exist (idle is free) | Any number, but **idle sessions must not start tools** | The 27+ idle specialist sessions cost nothing until GO'd |
| GO messages in flight | Never more than the working cap; the parent queues the rest | The overload happened because many sessions were GO'd at once |
| Worktrees checked out at once | **4 maximum** (the 2 working agents, the integration worktree, 1 spare) | A full checkout of this repo on the slow disk is the slow step; a dozen at once starved the disk and every agent stalled together |
| Unity processes on `Game/` | **1**, and only with "UNITY OK" in the GO | Protocol rule; also the heaviest disk and CPU user |
| Blender GPU jobs (creature/building sheets, 1-2 h) | **1**, run in the background, alone in its slot | Takes the GPU and disk for hours; counts as one of the two working agents |
| Helper subagents per agent | **0 by default, 1 at most** | Each spawn starts cold and re-reads context; protocol already says one at a time |

### Waves in practice
- A wave = at most 2 agents with **disjoint file ownership** (see `agent_team.md`). The next wave starts only when the previous wave is committed on its branches and the parent has merged or parked them.
- Pair design agents with engineers, never two engineers on the same folder. Good pairs: `world-designer` + `tools-pipeline-engineer`; `gameplay-engineer` + `narrative-writer`; `animator-rigger` + `items-designer`. Bad pairs: `ai-engineer` + `core-rules-engineer` (shared files), `gameplay-engineer` + `ui-engineer` (the phase 1 API boundary moves).
- Read-only agents (`code-reviewer`, `qa-tester` for a Core-only run, `anime-fantasy-director` on existing renders) need **no worktree**: point them at a finished agent's worktree or at `main` read-only. This alone removes up to a third of the checkouts.

## 2. Reducing the disk load (the worktree overload)

1. **Sparse worktrees.** Create with `git worktree add --no-checkout -b <branch> <path> aetheria/main`, then `git sparse-checkout set --no-cone <paths>` and `git checkout`. A docs or Data job needs `13_Production`, `Data`, `CLAUDE.md`, `Canon.md`, one agent file. This job's own worktree was made this way. Only Unity and Blender jobs need `Game/` or `Tools/blender/`.
2. **Never run `git gc` / commit-graph writes concurrently.** Seen on this run: `error: failed to write commit-graph` during `fetch` (non-fatal). Set it aside: the parent runs one maintenance pass between waves, with no agents active.
3. **Prune.** 28 worktrees are registered now, many for finished work (`phase1`/wave branches, locked `integrate-agents-1`, `library-shelf`, `audio-designer-sfx-event-list`, `class-skill-designer-companion-kits` still at the base commit `ae78c53f`, i.e. no commits). The parent should merge or archive, then `git worktree remove` the clean ones and keep branches. Four worktrees point at `ae78c53f` with nothing committed: first candidates.
4. **Stagger starts.** Start the second agent only after the first has finished its checkout (about a minute on a normal disk, longer here); never start both in the same minute.
5. **Heavy folders stay out.** `Game/Library`, `Art/Models`, `Art/Blender`, `.blend/.fbx/.glb` are gitignored and local only; never copy them per worktree. Unity runs only in the main checkout path agreed in the GO, not in agent worktrees, unless told.
6. **Keep logs out of worktrees:** write test XML and logs to the session scratchpad with absolute paths.

## 3. Usage-budget plan (5-hour window)

Observed: the limit has been hit 5 times. Cause pattern: 3+ agents concurrently, long Opus runs, helpers spawned inside agents, and re-reading large files repeatedly.

| Lever | Default |
|---|---|
| Model per job | Sonnet for docs, data, Core rules, tests, producer, canon-keeper, narrative, code review. Opus only for design-heavy or risky work: Unity integration, combat feel, AI behaviour, director reviews |
| Window plan | Treat the 5-hour window as 2 agent-slots x about 4 jobs. Per window: 1 heavy Unity-integration job, 2-3 medium jobs, the rest small. When about 70% used (parent judgement), no new GO: finish and commit what is running |
| Reads | Targeted reads (line ranges, grep); do not re-read audits already summarised in the handover |
| Commit cadence | After every task that builds, so a limit hit costs minutes, not the job (protocol step 6 already says stop cleanly after the last commit) |
| Resume | A GO message names the job number and the branch to resume; the agent reads only its branch's last commit message and its job brief |
| Daily shape | Window 1: integration/engineering pair. Window 2: design + art pair. Window 3: review/QA wave, merge, progress log. Never review and build concurrently on the same branch |
| Telemetry | The parent records, after every window: windows used, agents run, whether the limit hit, and which job was running. Four such rows give real numbers to replace the defaults above (add to `progress_log.md` Production notes) |

## 4. Risk register

Likelihood and impact: H/M/L. Owner is who acts; the parent merges everything.

| # | Risk | L | I | Mitigation | Owner |
|---|---|---|---|---|---|
| R1 | 5-hour limit hit mid-job again | H | M | Section 3 caps; commit per task; at most 2 working agents | Parent |
| R2 | Disk overload from simultaneous worktrees/checkouts | H | M | Section 2: 4 worktrees max, sparse checkout, staggered starts, prune | Parent |
| R3 | Branches written without a Unity run (companion presets and tactics) and the untested humanoid foot-IK path; the Unity baseline itself was green on 2026-11-08 (163, then 183 PlayMode) | H | H | One scheduled UNITY OK slot per week: `Tools/pc/update_and_verify.cmd`; fix compile errors before any new Unity work; qa-tester runs first | qa-tester + gameplay-engineer |
| R4 | Unity project mutated by two sessions at once (Library lock, scene corruption) | M | H | One Unity process; check Task Manager; "UNITY OK" only from the parent | Parent |
| R5 | Merge conflicts: about 20 live agent branches off `aetheria/main` at different commits | H | M | Merge in dependency order (section on job 2 later), rebase small branches first, one integration branch (`integrate/agents-1`) | Parent + producer |
| R6 | Locked Canon rows or data drift across parallel design agents (12 Canon §6 rows awaiting the user) | M | H | Design agents stay in owned folders; canon-keeper batch-checks before each merge; `npm run build` green (746+ tests, 28 warnings, 0 graph findings) | canon-keeper |
| R7 | Save compatibility broken by new fields (phase 1 persists many) | M | H | Old-save-loads test per new field (protocol rule 25); core-rules-engineer's save-migration-tests branch merged before more save fields | save-platform-engineer |
| R8 | Player save `slot0.json` touched by tests | L | H | Never touch rule; tests use temp paths; qa-tester greps for the path | qa-tester |
| R9 | User decisions pile up (Canon §6, settlement moves, 10.24 km tile rebase, font licence, MCP bridges, pack licences, title) and block waves 8+ | H | M | One short decision sheet in each weekly digest; agents proceed on defaults where the user said "do it all" and log the decision for overrule | producer |
| R10 | Third-party asset or licence slip (packs, display font, TripoSR) | M | H | Nothing used unless listed in `third_party_assets.md` first | tools-pipeline-engineer |
| R11 | Scope: 680 species, 28 building types x 21 families, 150 terrain tiles vs a two-person team | H | H | Ring plan stays the gate: ship Ring 0 polish first; world terrain, dioramas and library work stay behind flags until Ring 0 week-10 checklist is green | producer |
| R12 | GPU/Blender 1-2 h jobs block the one GPU slot | M | L | One at a time, background, overnight, counted as a working agent | Parent |
| R13 | Locked worktrees and detached `E:/Ideas/wt-ai-tools` hide stale or unmerged work | M | M | Inventory in the job 2/3 notes; user decides keep or drop | Parent |
| R14 | Reports of "done" without checks | M | M | Agents report exact `npm run build` results; parent spot-checks before merge | Parent |

## 5. Recommended defaults to apply today

1. Working cap 2 (3 with one docs-only). Worktree cap 4. Queue the rest.
2. Remove clean, uncommitted-base worktrees after the user agrees (list in R2/R13), keep their branches.
3. Next Unity slot first runs the verify script (R3), then the integration work in `unity_integration_dependency_map.md` (job 2).
4. Fill in the telemetry row after each 5-hour window.
