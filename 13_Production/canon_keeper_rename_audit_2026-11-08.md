# AETHWYRD rename audit (canon-keeper, 2026-11-08)

Method: re-diffed the scripted rename commit `5726cffe` against its parent (165 files, 544+/489-). A script normalised every name token (Aetheria/Aetherian/Aertheria/Project Ascend and the Aethwyrd forms) and compared each removed line with its added line. Then searched the tracked tree for leftovers and for new-form tokens inside identifiers, paths or packages.

## Result: no lore changed, no identifier broken
- Line-for-line: every changed line in the scripted pass differs only by the name token. The only other differences are 9 hand edits (CLAUDE.md x3, README.md, Canon.md x5 rows below) plus the two new log entries (migration report, CHANGELOG). All were wording-only.
- Canon.md rows touched: Title (open -> AETHWYRD, user decision, allowed), Otherworld memories, Big Upgrade, Diegetic guidance, Worldbuilding research options, Old-life memory and agency model. Only name words changed ("Aetheria" -> "Aethwyrd", "Aetherian" -> "Aethwyrdian", "Ascend" -> "AETHWYRD" in the rationale column). The user authorised editing Canon for the rename (migration report), so this is not a locked-row violation.
- Valdrisia, Vesper, Great Weave, Five Elder Dragons, the System, the Sundering: untouched.
- No new-form token (`Aethwyrd`) appears in any `_`/`/`/`\` path context, package id or `Aethwyrd-Game` URL.

## Remaining old names (all deliberate, match the migration report)
- `.gitignore` `GitHub/Aetheria-Game/` and the `marcevm1-del/Aetheria-Game` URLs in `02_Lore/expansion lore 1` and `expansion lore 2` (repo URL kept).
- `Aetherium` (line 286 of `expansion lore 2`): a different name (material), kept.
- Historical logs (progress_log, handover, dated notes, CHANGELOG older entries, build logs): kept as written.
- No lowercase `aetheria` remains in tracked files outside logs and the `ideas/` vault in this worktree.

## Findings to act on (none blocking)
1. Canon header sentence in `01_Core_Concept` summary reads "Working title: **AETHWYRD** (placeholder, the user decides the title)" (hit in the diff for the core-concept page). The title is now decided; reword to "Title: **AETHWYRD** (chosen by the user, 2026-11-07)". Proposed, not edited here (page is a Canon summary).
2. Keep an eye on the short form "Ascend" in prose: the migration report keeps it for tool names (Ascend Creatures/Buildings), but three Canon rationale cells were changed to AETHWYRD while other docs still say "Ascend" for the game. Cosmetic only; decide one style.
3. Follow-up already flagged in the report: window title/`productName: Game` needs a save-path migration before branding. Not a rename miss.
4. Profile ids `AETHERIA_HUMANOID_V3`/`AETHERIA_CREATURE_V3` in `upgrade v3`: build them as `AETHWYRD_*`.

Not checked: the `ideas/` vault copies (generated) and binary docx/pdf.
