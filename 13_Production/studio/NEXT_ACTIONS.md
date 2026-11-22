# Next actions and session handoff

_Last updated 2026-11-23 by the executive overseer session._

## Session handoff
- **Done:**
  - M1 read-only audit ([M1_AUDIT_2026-11-23.md](M1_AUDIT_2026-11-23.md)).
  - All seven owner decisions D-01 to D-07 are recorded in DECISION_LOG.md.
  - Low-poly tier written into `art_direction.md` §12, with a pointer in `art_budgets.md` (D-03).
  - `Tools/pc/update_and_verify.ps1` now stops on a dirty tree (exit 2) unless given `-AllowDirty`, and writes the commit into `summary.txt` (D-06).
- **Branch:** `studio/m1-audit` in the clean clone `E:\Ideas\Project-Ascend\GitHub\Aetheria-Game`. It is not merged into `main`.
- **Ran 2026-11-23:**
  - `npm run build`: data valid, 770 rules tests passed.
  - Verify script, guard test: dirty tree → exit 2, nothing run.
  - Verify script with `-AllowDirty -SkipPull` and no Unity: summary marked DIRTY TREE, 770 passed, Unity skipped.
- **Not run:** Unity in any mode. No Unity result is newer than the 2026-11-13 dirty-tree run.
- **Open finding:** `npm run build` generates `Data/Schemas/encounters.schema.json`, which `main` does not commit. CI misses it because untracked files pass `git diff`. The fix is in flight on `agent/world-builder-engineer/dungeon-loader` (see the inventory).
- **Resume checklist:**
  1. Read this file, then DECISION_LOG.md.
  2. Run `git status` and `git log` in both checkouts.
  3. Check what the owner approved from the local-work inventory.

## Waiting on the owner
1. **`gh`:** run `winget install GitHub.cli`, then `gh auth login` (D-07).
2. **Local-work inventory (D-05):** approve merge, keep or archive for each item once the read-only inventory is presented.
3. **Unity baseline:** run `Tools/pc/update_and_verify.cmd` on a clean tree once the working checkout is sorted out.

## Ready for agents (Phase 0), each on its own `agent/*` branch and PR (D-07)
| Task | Lead role | Depends on |
|---|---|---|
| Durable saves: atomic replace, `.bak`, load fallback, crash test | 01 Technical (`save-platform-engineer`) | Inventory (existing save branches) |
| One data manifest for the player build, a completeness test, load `reactions.json` | 01 Technical (`tools-pipeline-engineer`) | Inventory |
| Confirm, then fix, the toon shader's ignored vertex colour | 02 Art (`technical-artist`) | Baseline screenshot |
| Make the slice scene reference only tracked (LFS) assets | 02 Art + 04 World | Inventory |
| Bring human bodies to the §12 tier (hero 15k, NPC 10k) and lower the art gate cap | 02 Art (character work, art gate) | none |
| Commit `encounters.schema.json` | 01 Technical (`tools-pipeline-engineer`) | Inventory (dungeon-loader) |
