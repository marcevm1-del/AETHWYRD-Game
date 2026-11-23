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

## Done after the inventory (owner approved 2026-11-23)
- The 19 local-only branches are pushed to GitHub as backups: 19 of 19 verified, none merged.
- `agent/producer/fresh-clone-fixes` is pushed (`de9014c7`), not merged. It holds:
  - `monster_models.json` (680 species)
  - `Editor/Audio.meta`, `MonsterMaterialPostprocessor.cs.meta`, `ReimportMonsters.cs.meta`
  - `encounters.schema.json`
  - the quest audit
  - `.gitignore` entries for `/.agents/`, `/.codex/`, `/AGENTS.md`
- Working checkout `E:\Ideas\Project-Ascend`:
  - The 3 regenerated files were discarded. Copies are in the session scratchpad, which is temporary.
  - The 2 duplicate `.cs` files were deleted.
  - `main` was fast-forwarded to `8e6bc72c`, and the LFS files are present.
  - Still untracked there, and identical to the branch: the keeper files. Delete them before fast-forwarding past that branch's merge, or git will refuse.
- The clean clone's `origin` now points at `marcevm1-del/AETHWYRD-Game`. The working checkout's remote `aetheria` still uses the old URL, which redirects.
- **Approved branch plan (inventory "Suggested order"):** PRs go out in that order once `gh` works. The `library-shelf` Canon row L7 edit is flagged for the owner in its PR.

## Open PRs (opened 2026-11-23; `gh` signed in as the owner)
| PR | Branch | Order |
|---|---|---|
| [#11](https://github.com/marcevm1-del/AETHWYRD-Game/pull/11) | `agent/producer/fresh-clone-fixes` | Any time |
| [#12](https://github.com/marcevm1-del/AETHWYRD-Game/pull/12) | `studio/m1-audit` (these records) | Any time |
| [#13](https://github.com/marcevm1-del/AETHWYRD-Game/pull/13) | `agent/qa-tester/save-regression` | Save step 1 |
| [#14](https://github.com/marcevm1-del/AETHWYRD-Game/pull/14) | `agent/save-platform-engineer/save-version-manager` | Save step 2, after #13 |

Next PRs from the approved plan, opened as these merge:
- the rest of the save stack, after reconciling `GameSettings`
- wiring `AtomicFile` into `PlayerSave` (new work)
- research and UX docs (commit the onboarding doc first)
- the data branches
- `dungeon-loader` and the Core commits from `region-graph-map`

`main` has **no branch protection** (checked with `gh api`, HTTP 404).

## Waiting on the owner
1. ~~`gh`~~: done 2026-11-23. Review and merge #11 to #14.
2. **Unity baseline:** run `Tools/pc/update_and_verify.cmd`. The working checkout is still not clean (keeper files, `Resources/`, Codex config), so the script will stop until the fresh-clone branch merges or `-AllowDirty` is used.
3. **`Resources/` (1 GB):** not gitignored. The owner did not approve ignoring it, so it stays as it is until they decide.

## Ready for agents (Phase 0), each on its own `agent/*` branch and PR (D-07)
| Task | Lead role | Depends on |
|---|---|---|
| Durable saves: atomic replace, `.bak`, load fallback, crash test | 01 Technical (`save-platform-engineer`) | Inventory (existing save branches) |
| One data manifest for the player build, a completeness test, load `reactions.json` | 01 Technical (`tools-pipeline-engineer`) | Inventory |
| Confirm, then fix, the toon shader's ignored vertex colour | 02 Art (`technical-artist`) | Baseline screenshot |
| Make the slice scene reference only tracked (LFS) assets | 02 Art + 04 World | Inventory |
| Bring human bodies to the §12 tier (hero 15k, NPC 10k) and lower the art gate cap | 02 Art (character work, art gate) | none |
| Commit `encounters.schema.json` | 01 Technical (`tools-pipeline-engineer`) | Inventory (dungeon-loader) |
