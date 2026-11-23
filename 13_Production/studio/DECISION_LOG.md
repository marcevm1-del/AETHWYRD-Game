# Decision log

Owner decisions only. Proposals stay under "Open" until the owner says yes or no. Locked Canon rows are changed only through Canon §6.

## Decided
| ID | Date | Decision | Consequences | Source |
|---|---|---|---|---|
| D-01 | 2026-11-23 | Studio records live in `13_Production/studio/`, not in root-level docs or `Documentation/AI/` | This folder; nothing is duplicated from `progress_log.md` or `handover/` | Owner, in chat |
| D-02 | 2026-11-23 | **The eight directive roles map onto the existing agents.** No new agent definitions | AGENT_REGISTRY.md is approved. File ownership stays as written in `agent_team.md` | Owner, in chat |
| D-03 | 2026-11-23 | **Production art path: a stylized low-poly tier, authored directly at budget** (like the Brindlewick kit). Cel shading stays. Canon §1 wording is untouched. The high-poly Blender generators become reference and concept only | Budget tier written into `art_direction.md` §11. `art_budgets.md` and `character_system.md` triangle targets must be reconciled to it | Owner, in chat |
| D-04 | 2026-11-23 | **Vertical slice = directive Milestone 4 only, Swordsman-only.** Brindlewick, Whisperwood, NPC interaction, one quest chain, monster encounters, equipment and progression, Grukk, F→E rank-up, full loop, 15–30 min | Class choice, more classes and a dungeon are the first expansion items after the slice, not slice blockers | Owner, in chat |
| D-05 | 2026-11-23 | **Inventory first:** run a read-only review of the uncommitted edits in `E:\Ideas\Project-Ascend` and the 19 unmerged branches, then the owner approves a per-item merge / keep / archive list. Nothing is changed or deleted before approval | Inventory by Agent 07 (QA), read-only | Owner, in chat |
| D-06 | 2026-11-23 | **Unity is verified manually for now, not in CI.** Agents may not mark Unity work "Tested" without a fresh `Tools/pc/update_and_verify.cmd` run on a clean tree, started by the owner. The script refuses a dirty tree. Revisit before Steam prep | Rule added to README.md. Verify script hardened | Owner, in chat |
| D-07 | 2026-11-23 | **The owner installs `gh` and signs in. Agents push `agent/*` branches and open PRs; only the owner merges to `main`.** CODEOWNERS and a branch-protection check follow once `gh` works | Waiting on the owner: `winget install GitHub.cli`, then `gh auth login` | Owner, in chat |

## Open
None.
