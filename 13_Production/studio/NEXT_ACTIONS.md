# Next actions and session handoff

_Last updated 2026-11-23 by the executive overseer session._

## Session handoff
- **Done:** M1 read-only audit, consolidated in [M1_AUDIT_2026-11-23.md](M1_AUDIT_2026-11-23.md). Decision D-01 recorded.
- **Audited commit:** `main @ 8e6bc72c`. This file was written in the clean clone `E:\Ideas\Project-Ascend\GitHub\Aetheria-Game` on branch `studio/m1-audit` (local commit; push awaits the owner).
- **Ran:** `npm run build` in the clean clone on 2026-11-23.
  - Data valid; 28 map warnings; 0 graph findings.
  - All 770 rules tests passed.
  - It also generated an uncommitted `Data/Schemas/encounters.schema.json`. I deleted that copy, so the finding is still open.
- **Not run:** Unity in any mode, Blender, the art gate. All Unity test and build figures still come from the 2026-11-13 verify run, which used a dirty tree.
- **Resume checklist:**
  1. Read this file, then DECISION_LOG.md.
  2. Run `git status` and `git log` in both checkouts.
  3. Check the open decisions before starting any work.

## Waiting on the owner
1. Answer D-02 to D-07 in DECISION_LOG.md.
2. Phase 0 steps only you can do:
   - Commit or park the uncommitted edits in `E:\Ideas\Project-Ascend`. That checkout is 82 commits behind `main`.
   - Run `Tools/pc/update_and_verify.cmd` on a clean tree, for a fresh Unity baseline.
   - Install `gh`.

## Ready for agents once approved (Phase 0, from the audit §6)
| Task | Lead role | Depends on |
|---|---|---|
| Durable saves: atomic replace, `.bak`, load fallback, crash test | 01 Technical (`save-platform-engineer`) | D-05 |
| One data manifest for the player build, a completeness test, load `reactions.json` | 01 Technical (`tools-pipeline-engineer`) | D-05 |
| Confirm, then fix, the toon shader's ignored vertex colour | 02 Art (`technical-artist`) | Baseline screenshot |
| Make the slice scene reference only tracked (LFS) assets | 02 Art + 04 World | D-03, D-05 |
| Make the verify script refuse a dirty tree | 07 QA | none |
