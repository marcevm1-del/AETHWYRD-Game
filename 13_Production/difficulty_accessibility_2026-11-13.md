# Difficulty and accessibility presets: review (systems-designer, 2026-11-13)

Design: `12_Systems/difficulty_and_accessibility.md`. Data: `Data/Player/difficulty.json`, `Data/Player/accessibility_presets.json`. Checks: `Tools/validate/difficulty_checks.js` (schemas in `difficulty_schemas.js`, hooked into `build_schemas.js` and `validate.js`). Decided by Claude under delegated creative control; the user may overrule any row.

## Findings before the work
| # | Finding |
|---|---|
| D1 | Difficulty existed only as the `Difficulty` enum (`Inventory.cs`) driving death penalties. The sliders promised by `systems.md` §10.2 (enemy damage, enemy HP, windows, aggro tokens, loot, death penalty, weight) had no data, ranges or defaults. |
| D2 | The S-rank floor was prose only, so nothing said which values it clamps or that it must not remove accessibility cues. |
| D3 | The accessibility model (`accessibility.json`, `AccessibilitySettings`) had no one-tap bundles, and `hud_and_ui.md` §14 lists a one-handed preset and "story difficulty assists" that nothing defined. |
| D4 | The base values to scale are in `combat_tuning.json` (perfect dodge 0.15 s, parry 0.12 s, Flash Time 0.8 s at 0.25 scale, 2 simultaneous attackers). The parry window is the tightest at 0.12 s (about 7 frames at 60 fps), which is why Story widens it to 0.19 s. |

## Decisions
1. Four presets and nine sliders as in the design doc. Every preset leaves enemy HP at 1.0 (Canon: difficulty changes pressure and patterns before health); the validator enforces it.
2. Death rows copied from Core `DeathRules` (Story none, Adventurer 10% coin, Veteran 10% coin and 5% XP, Hardcore permadeath), so the data and code cannot disagree silently (the validator checks the numbers).
3. Veteran and Hardcore are harder through damage, aggression, shorter telegraphs and 3 attackers; no preset narrows the player's windows below the base, because that would fight the Canon readability contract (redundant cues, viable non-parry defence).
4. The S-rank floor clamps only difficulty values and never accessibility (the validator requires the parry indicator, telegraph shapes, colour palettes and hold-toggle to stay on the keep list).
5. Nine accessibility bundles over existing settings only, checked against the existing ranges; bundles never turn subtitles off and respect the reduced-flash cap of 0.25.

## Checks run
- `node Tools/validate/build_schemas.js` then `node Tools/validate/validate.js`: **Data valid** (see the full `npm run build` result in the report to the parent).
- Mutation test: setting Story `enemyHpMult` to 0.9 made the validator fail with "presets keep enemyHpMult at 1"; restored, it passes again.

## Hand-offs and test ideas
- **core-rules-engineer:** a `DifficultyFile` loader and an `Apply(preset, sliders, contentRank)` that returns effective multipliers with the S floor applied; a nullable `SaveGame` field for chosen sliders that defaults to the Adventurer preset for old saves (with an old-save-loads test); `DeathRules` reading the death fractions from data instead of constants; an `AccessibilityPresets.Apply` that stacks bundles in order and applies `toggleAllHoldActions`.
- **ai-engineer / gameplay-engineer:** read `enemyAggressionMult`, `telegraphLeadMult` and `maxSimultaneousAttackers` in monster AI; widen the dodge, parry and Flash Time windows by the multipliers; add the auto-dodge assist.
- **ux-designer / ui-engineer:** the difficulty and accessibility screens (preset cards, slider list, the A-rank Guild warning, a visible parry timing indicator, `one_handed_layout`).
- **qa-tester:** (1) effective values at rank S for each preset equal the floor (damage and windows at least 1.0, 2 or more attackers, no auto-dodge); (2) at rank A the Story values are unchanged; (3) bundles stack in order and a later bundle wins; (4) the one-handed bundle makes all six hold actions toggles; (5) an old save with no difficulty sliders loads as Adventurer; (6) `deathPenaltyScale` 0 means a death costs nothing and 2 doubles the fractions, never permadeath.
