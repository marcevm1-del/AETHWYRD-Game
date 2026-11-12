# Decision log

Approved project decisions, newest first. One row per decision. A decision is never edited after the fact: a later decision that changes it gets its own row and names the one it replaces.

- **Decider** is `owner` (the user, in person), `orchestrator` (the coordinating Claude session, inside `CHANGE_CONTROL.md`), or `Claude (delegated)` (a creative decision made under the owner's 2026-11-07 delegation; the owner may overrule it).
- Story and design-rule decisions also live in `Canon.md`. All 97 rows of `Canon.md` §6 are indexed, with decider and date, in `13_Production/canon_decision_index_2026-11-08.md`; they are not copied here.

## Decisions

| ID | Date | Decision | Why | Decider | Replaces | Evidence |
|---|---|---|---|---|---|---|
| D-012 | 2026-11-12 | The planning system was reviewed by four agents before first use; their findings and what was done about each are in §"Review of the planning system" below | Master command §28 phase 7 | orchestrator | - | `Planning/reviews/` |
| D-011 | 2026-11-12 | Nothing from the owner's four new prompt documents (`AETHWYRD.odt`, `AETHWYRD 2/3.docx`, `Aethwyrd 4.docx`) is approved for building. Each proposal was triaged into ALREADY BUILT, ALREADY DESIGNED, an UPGRADE entry, an IDEA entry, or a canon conflict | The command says ideas are not commitments and only approved upgrades enter the backlog | orchestrator | - | `Planning/audits/`, `UPGRADE.md`, `IDEAS.md` |
| D-010 | 2026-11-12 | The backlog holds only work that finishes, proves or connects what already exists, up to the vertical slice gate. No new system is started before that gate | Scope risk R11 is rated high / high; one field is playable and Unity has not verified anything since 2026-11-08 | orchestrator (owner may overrule) | - | `MASTER_PROJECT_PLAN.md` §3 |
| D-009 | 2026-11-12 | The vertical slice is Canon's Ring 1 ("The Wooden Card": Brindlewick and Whisperwood), cut down to what proves the loop. It is not a new design | A slice already exists in `13_Production/production.md` §5 and roadmap M5; a second definition would compete with it | orchestrator | - | `VERTICAL_SLICE_PLAN.md` |
| D-008 | 2026-11-12 | Every system carries two statuses, rules layer and game, on the nine-step ladder. "Implemented" is never used for rules that are not wired into Unity | Most systems are tested in Core and absent or unverified in the game; one word hid that | orchestrator | - | `QUALITY_GATES.md` §1 |
| D-007 | 2026-11-12 | The working cap stays at 2 agents (3 when one only reads). The 2026-11-12 audits ran as two waves of three read-only agents | The cap is the project's own rule after five usage-limit hits; the command asks to match team size to the task | orchestrator | - | `13_Production/risk_register_and_usage_budget.md` §1 |
| D-006 | 2026-11-12 | Model tiers pinned in the agent files: opus for `producer`, `technical-director`, `creative-director`, `red-team-reviewer`; haiku for `documentation-auditor`; sonnet for the other seat holders. Agents outside the 18 seats keep `inherit` | The command asks for explicit tiers; `inherit` ran every agent on the session's most expensive model | orchestrator | - | `.claude/agents/*.md`, `13_Production/agent_team.md` |
| D-005 | 2026-11-12 | The command's 18 roles are filled by existing agents where one exists. Six agents were created for roles nobody held: `red-team-reviewer`, `documentation-auditor`, `research-analyst`, `exploration-designer`, `creature-ecology-designer`, `companion-ai-designer`. No second producer, architect, QA or UI agent was created | The command says to adapt an existing structure and not to duplicate; 61 agent files already existed | orchestrator | - | `13_Production/agent_team.md` |
| D-004 | 2026-11-12 | `Planning/` at the repo root is the home of the management system. `13_Production/` keeps system documentation, audits, the progress log and history. Older plans there are not deleted; where `Planning/` replaces one, the old file says so at its top | The owner named `/Planning/`; the older files are cited from many places and from the vault | orchestrator | - | this folder |
| D-003 | 2026-11-12 | Build a permanent development management system before any further feature work: planning folder, UPGRADE and IDEAS registers, agent team with tiers, audits, master plan | Owner's master development command | **owner** | - | The command of 2026-11-12 |
| D-002 | 2026-11-07 | The game and its world are named AETHWYRD / Aethwyrd | - | **owner** | working title "Project Ascend", world name "Aetheria" | `Canon.md` §1, `13_Production/aethwyrd_migration_report.md` |
| D-001 | 2026-11-07 | Creative decisions on the open `Canon.md` §6 proposals from waves C, D, E, F-lite and the world upgrade are delegated to Claude ("do it all, stop asking me"). Licences, accounts, purchases and the character choice stay with the owner | Owner's instruction | **owner** | - | `Canon.md` §6 header note, `13_Production/roadmap_after_upgrade_waves.md` |

## Earlier owner decisions (recorded elsewhere, listed so they can be found)

| Date | Decision | Where |
|---|---|---|
| 2026-10-22 | Engine Unity 6 (URP), data-driven JSON, single-player, premium, PC | `Canon.md` §1, `13_Production/production.md` §2 |
| 2026-10-23 | Named-monster rules locked | `Canon.md` §4d |
| 2026-10-24 | Monster models: generate from the project's own text, Ring order first, files stay on the PC | `13_Production/monster_model_pipeline.md` |
| - | Steam and release planning parked until near the end | `13_Production/production.md` §6 |
| 2026-11-08 | TripoSR chosen as the local image-to-3D tool | `13_Production/third_party_assets.md` |

## Waiting for the owner

Open decisions are listed once, in `DASHBOARD.md` under "Decisions waiting on you". When the owner answers, the answer becomes a row above.

## Review of the planning system

Filled in after the phase 7 review.
