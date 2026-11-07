# Adoption Plan - 2026-11-07

Tier: minimal (rigor: minimal). Detected phase: Pre-Production (configured), Production (observed).
Found: 0 GDDs, 0 ADRs, 0 stories in studio folders (Ascend uses 00_Questions..13_Production).

## Gap counts
BLOCKING: 0  HIGH: 1  MEDIUM: 2  LOW: 1

## Migration plan
- [ ] 1. HIGH - Write `design/game-brief.md` (only artifact audited at minimal). Map onto 01_Core_Concept or run `/reverse-document design Game/Assets/_Game/Runtime`.
- [ ] 2. MEDIUM - Apply the `paths.code_root` override to asset-scan.sh and content-count.sh (test-scaffold.sh: check).
- [ ] 3. MEDIUM - Make artifact-check.sh honour project.yaml `paths:`.
- [ ] 4. LOW - Add `.claude/docs/templates/patch-notes-template.md` or fix the reference.

## Already resolved (22a309eb)
- .claude/hooks/yaml-helper.sh installed; skills launch.
- project-state.sh resolves code root Game/Assets/_Game/Runtime (50 files).
- docs/engine-reference/unity/VERSION.md added.
- migrate-v1-config dry run: nothing to do.
