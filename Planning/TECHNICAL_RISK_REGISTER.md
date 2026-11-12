# Technical and production risk register

This register continues `13_Production/risk_register_and_usage_budget.md` (producer, 2026-11-09). R1 to R14 keep their numbers and their full text there; this file holds their current status and adds R15 onward from the 2026-11-12 audits. The usage-budget rules (working cap, worktrees, windows) stay in that file.

**Kind** separates what has been seen from what is feared: CONFIRMED DEFECT (it is wrong now, with evidence) · OBSERVED (it has happened) · THEORETICAL (it could happen). Severity is probability × impact on H / M / L.

## 1. Carried risks (R1 to R14)

| ID | Risk | Kind | P | I | Status on 2026-11-12 |
|---|---|---|---|---|---|
| R1 | 5-hour usage limit hit mid-job | OBSERVED | H | M | **Happened again today**: three audit agents stopped at the limit while three ran at once. Their reports had been saved first, so one job was lost, not three. The cap (2 working, 3 if one only reads) was honoured and was still too much alongside a long main session. Tightened: see R15 |
| R2 | Disk overload from simultaneous worktrees | OBSERVED | H | M | Not exercised (no worktrees used in the cloud) |
| R3 | Long stretch with nothing compiled or played in Unity | OBSERVED | H | H | Open. Last recorded PlayMode run 2026-11-08; two merge batches since |
| R4 | Unity project mutated by two sessions at once | THEORETICAL | M | H | Open |
| R5 | Merge conflicts across about 20 agent branches | OBSERVED | H | M | Reduced: batches 1 and 2 merged (progress log 2026-11-09, 2026-11-11). Local-only branches on the PC cannot be seen from the cloud |
| R6 | Canon or data drift across parallel design agents | OBSERVED | M | H | Open: see `CANON_DISCREPANCIES.md` (14 canon-level rows) |
| R7 | Save compatibility broken by new fields | THEORETICAL | M | H | Mitigated: save-migration tests merged 2026-11-09. See R19 for the remaining gap |
| R8 | Player save `slot0.json` touched by tests | THEORETICAL | L | H | Open; tests use their own folder (`Phase1WorldPlayModeTests`) |
| R9 | Owner decisions pile up | OBSERVED | H | M | **Worse**: the audits added about 30 decisions. Consolidated to one list in `DASHBOARD.md` |
| R10 | Third-party asset or licence slip | THEORETICAL | M | H | Open |
| R11 | Scope against a two-person team | OBSERVED | H | H | Open and now quantified: see R16 |
| R12 | GPU jobs block the single GPU slot | THEORETICAL | M | L | Open |
| R13 | Locked worktrees hide unmerged work | OBSERVED | M | M | Open; cannot be inspected from the cloud |
| R14 | "Done" reported without checks | OBSERVED | M | M | **Confirmed as a pattern**, see R17 |

## 2. New risks from the 2026-11-12 audits

| ID | Description | Kind | P | I | Sev | Affected systems | Detection | Mitigation | Contingency | Owner | Status |
|---|---|---|---|---|---|---|---|---|---|---|---|
| R15 | Agent orchestration itself exhausts the usage window: a long orchestrating session plus three subagents hit the limit in one afternoon | OBSERVED | H | M | H | All agent work | Limit notices | One subagent at a time while the main session is doing heavy reading; two only when the main session is idle; agents write their report file before their summary; resume a stopped agent instead of restarting it | Do the audit in the main session (as done for the technical audit) | Orchestrator | OPEN |
| R16 | The design is roughly two orders of magnitude larger than the build. Canon: 49 regions, 680 species, 12 → 24 → 48 classes, about 2,500 NPCs, six acts, 120 Labyrinth floors. Built in the game: 1 scene, about 22 species, 1 class, 12 placed NPCs, Prologue and part of Act I as 32 quests (19 completable), 0 dungeon floors | CONFIRMED | H | H | H | Whole project | `PROJECT_STATUS.md` §2 | Hold the ring order; no art or Unity time on later rings before the slice gate; the owner's four new prompt documents are triaged into IDEAS, not built | Cut the canon numbers at Ring 2 planning (already foreseen for species in Canon §6 "Ring 2 roster") | Owner | OPEN |
| R17 | "Implemented" has been used for "rules written and tested in Core". Finished Core systems and data files are not read by the game: weapon movesets, group tactics, boss weak points and armour, reaction table, encounter tables, population rows, region graph, puzzles, both journal pages' writers | CONFIRMED DEFECT | H | H | H | Combat, world, exploration | The two-status ladder in `QUALITY_GATES.md`; a validator report of data files with no consumer (UPG-025) | Phase 2 of the roadmap wires what exists before anything new is written; every status claim cites a Runtime file | Strike unwired features from the Ring 0 description rather than leave them implied | Orchestrator | OPEN |
| R18 | The core loop has never been judged by a person: the `combat.md` §12 fun test is unrun, and four of its twelve items cannot pass without unwired systems | CONFIRMED | H | H | H | Combat, Ring 0 gate | Checkboxes in `combat.md` §12 | T-002 splits the list; the owner plays the testable half now | Treat feel problems as P0 before any content work | Owner | OPEN |
| R19 | Save identity and versioning: `SaveGame.CurrentVersion` is still 1 after many added fields; the save folder derives from company "DefaultCompany" and product "Game"; one slot; no backup copy | THEORETICAL | M | H | M | Save | Save round-trip tests | Decide product identity before any build leaves the PC; version bump rule (UPG-028) | A path migration step, as the rename report already notes | save-platform-engineer | OPEN |
| R20 | Dormant formula defect: `DamageCalculator.Compute` ignores the damage kind, so magic would use the physical formula the day a caster class is enabled | CONFIRMED DEFECT (dormant) | M | M | M | Combat, classes | Core test (to be written) | UPG-004 before any second class is exposed | - | core-rules-engineer | OPEN |
| R21 | No performance measurement exists. The 60 fps target, the art budgets and six known per-frame allocation sites (TD-01 to TD-06) are all unmeasured | CONFIRMED (absence of evidence) | M | H | M | Runtime | Unity Profiler capture | UPG-027: one capture of the Ring 0 field with the goblin pack | Lower monster counts per camp | performance-analyst | OPEN |
| R22 | Generated art lives on one PC only (creature and building libraries, 677 blockout FBX files, terrain tiles), outside git | THEORETICAL | M | M | M | Art pipeline | - | Back up the local model folders; narrow generation to the next ring (UPG-024) | Regenerate from recipes (procedural route is deterministic; the AI route is not) | Owner | OPEN |
| R23 | Unity is outside every automated gate. CI runs data and Core only; a merge can break compile or PlayMode and stay green | CONFIRMED | H | M | H | Runtime | PC verify run | Weekly PC verify run with a committed one-line result (UPG-026); cloud work that touches Unity is labelled "not compiled in Unity" | Revert to the last verified commit | qa-tester, owner | OPEN |
| R24 | Tunable-looking dead data: eight reserved group-tactics keys, `reactions.json`, `bossBreakKnockdownSec`, `weapon_movesets.json` change nothing in play | CONFIRMED DEFECT | H | M | M | Combat tuning | UPG-025 report | Wire or mark each as reserved in its file and doc | - | combat-designer | OPEN |
| R25 | Quests that cannot be completed are offered to the player: 13 of 32 by static analysis (givers or talk targets not placed; no dungeon scene) | CONFIRMED by reading, not by play | H | M | M | Quests | A scene test that every giver and talk target exists (T-009) | Park or place (UPG-014) | Hide unparked quests from the board | quest-designer | OPEN |
| R26 | Proposal volume exceeds build capacity: ten "upgrade vN" documents, a formula bible and four new prompt documents ask for several hundred features; each new document re-asks for audits and 100+ ideas | OBSERVED | H | M | H | Planning | Count of PROPOSED / NEW entries against DONE tasks on the dashboard | `UPGRADE.md` and `IDEAS.md` absorb proposals without committing work; D-010 gates the backlog | The owner chooses a small set per milestone | Owner, orchestrator | OPEN |
| R27 | Hand-authored content has no generator and no budget: NPCs, quests, dialogue (the talk window shows one role line per NPC) | CONFIRMED | H | H | H | Narrative, quests | Counts in `PROJECT_STATUS.md` | Size the slice to what can be written; decide dialogue data format before writing more | Reduce canon counts | narrative-writer, owner | OPEN |
| R28 | No player character: a capsule stands in; humanoid animation and foot IK are untested | CONFIRMED | H | M | M | Character, animation | - | Owner exports a VRM or approves the humans-base route | Ship the slice test with a stand-in model | Owner | OPEN |
| R29 | Canon §6 holds 46 delegated decisions the owner has not reviewed and 48 open rows; systems are being built on both | OBSERVED | M | H | M | All design | `canon_decision_index` | One ratification pass (CD-001); code stays data-driven so an overrule is a data change | - | Owner | OPEN |
| R30 | 167 species-region pairs sit above their region's rank band, 18 of them in Whisperwood, the only playable region | CONFIRMED DEFECT (data) | H | L | M | Bestiary, encounters | `08_Bestiary/regional_ecology.md` findings | UPG-019 before encounter tables become the spawn source | - | bestiary-designer | OPEN |
| R31 | A kill landed by a companion or partner raises no kill event: no XP, loot, quest credit or bestiary tick, and no liberation if the target is the Tyrant (who never respawns). Missed by all five audits; found by the red-team review | CONFIRMED by reading the code; not reproduced in Unity | M | H | H | Combat, companions, quests, sieges | A PlayMode test where a companion lands the last hit | UPG-040 / T-024, first Unity task after the verify run | Until fixed: order the companion to hold during the Grukk fight | gameplay-engineer | OPEN |

## 3. Top five by severity

R31 (companion kills give no credit; the only one that can lose a player's progress today), R16 (scope against build), R17 (rules not wired), R18 (loop never judged), R3 with R23 (Unity unverified and ungated), R27 (authored content has no budget).

## 4. Rule for adding a risk

Use the template in `TASK_TEMPLATES.md` §7. State the kind. A theoretical risk is never written up as a defect, and a confirmed defect also gets an UPGRADE entry or a backlog task.
