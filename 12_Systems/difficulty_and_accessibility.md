# Difficulty and accessibility presets (AETHWYRD)

Data: `Data/Player/difficulty.json` (presets, sliders, S-rank floor) and `Data/Player/accessibility_presets.json` (one-tap bundles). Both are checked by `Tools/validate/difficulty_checks.js`. The accessibility model they build on already exists: `Data/Audio/accessibility.json` and `Code/Ascend.Core/Accessibility.cs` (`AccessibilitySettings`). Source rules: `systems.md` §10, §10.2 and "Difficulty: Player Choice + the S-Rank Floor"; `hud_and_ui.md` §14; Canon §4 row "Ring 0 combat/readability contract" and the accessibility floor row. Decided 2026-11-13 by Claude under delegated creative control; the user may overrule. Review: `13_Production/difficulty_accessibility_2026-11-13.md`.

## Principles (Canon wins)
- **Pressure and patterns before health.** Difficulty moves enemy damage, aggression, telegraph lead time, how many enemies attack at once and the player's timing windows. Every preset keeps `enemyHpMult` at 1.0; only the custom slider moves it (the validator enforces this).
- **Difficulty and accessibility are separate.** Choosing a bundle never changes enemy numbers, and the S-rank floor never removes a bundle.
- **Free to change.** Presets and sliders can be changed at any time, except Hardcore, which is locked at creation. Permadeath comes only from the Hardcore preset, never from a slider.
- **Slow-Life.** Nothing here decays, charges upkeep or punishes absence. A death costs what `systems.md` §10 says and nothing grows from it.

## Presets
Base values come from `combat_tuning.json` (`dodge.perfectDodgeWindowSec` 0.15 s, `parry.parryWindowSec` 0.12 s, `flashTime.durationSec` 0.8 s, `ai.maxSimultaneousAttackers` 2); the table gives the multiplier or value.

| Setting | Story | Adventurer (default) | Veteran | Hardcore |
|---|---|---|---|---|
| Enemy damage | x0.6 | x1.0 | x1.25 | x1.5 |
| Enemy HP | x1.0 | x1.0 | x1.0 | x1.0 |
| Enemy aggression | x0.7 | x1.0 | x1.2 | x1.3 |
| Telegraph lead time | x1.4 | x1.0 | x0.85 | x0.8 |
| Enemies attacking at once | 1 | 2 | 3 | 3 |
| Perfect-dodge window | x1.5 (0.225 s) | x1.0 | x1.0 | x1.0 |
| Parry window | x1.6 (0.19 s) | x1.0 | x1.0 | x1.0 |
| Flash Time length | x1.5 (1.2 s) | x1.0 | x1.0 | x1.0 |
| Auto-dodge assist | on | off | off | off |
| Loot (coin and ordinary drops) | x1.0 | x1.0 | x1.1 | x1.25 |
| Death | nothing lost | drop 10% of carried coin | drop 10% coin and lose 5% of the XP toward the next level | permadeath, Mortal Bonds on |
| Carry weight | unlimited bag | generous | strict | strict |

Loot scaling touches counts only, never rarity rolls, unique drops or quest items. The death rows match `DeathRules` in `Code/Ascend.Core/Inventory.cs` exactly, and the validator checks that.

## Custom sliders (under any preset)
`enemyDamageMult` 0.25 to 2.0, `enemyHpMult` 0.5 to 1.5, `enemyAggressionMult` 0.5 to 1.5, `telegraphLeadMult` 0.7 to 1.6, `maxSimultaneousAttackers` 1 to 4, `dodgeWindowMult` and `parryWindowMult` and `flashTimeDurationMult` 0.75 to 2.0, `lootMult` 0.5 to 2.0, `deathPenaltyScale` 0 to 2 (multiplies the preset's coin and XP fractions; it can make a death cost nothing or twice as much, never permadeath). Weight mode follows the preset.

## The S-rank floor
From S content on, easy settings are floored (`systems.md`): damage, aggression and all three windows are at least 1.0, the attacker count is at least 2, telegraph lead time is at most 1.0, auto-dodge is off and boss enrage timers are on. The preset names become Brutal (Story and Adventurer), Brutal+ (Veteran) and Nightmare (Hardcore). The Guild warns the player at A rank: "Beyond this point, the world will not go easy on you."

**The floor never touches accessibility.** The parry timing indicator, telegraph shapes, colour-vision palettes, hold-or-toggle, text scale, subtitles, reduced flash and shake settings all stay (`sRankFloor.keepsAccessibility`; the validator requires four of them by name). A player who needs a bigger window to play at all has the wider timing indicator and every comfort option, and the game says in advance which assists change.

## Accessibility bundles
One tap applies a set of existing settings; the player can change any single setting afterwards, and bundles stack in the order chosen. Values are checked against `accessibility.json` ranges.

| Bundle | What it sets |
|---|---|
| Low vision | text x1.5, HUD x1.25, high-contrast panels, large boxed subtitles, parry indicator |
| Colour-vision helper | deuteranopia palette (the player may pick another), parry indicator |
| Photosensitive-safe | reduced flash on, flash 0.25 (the cap), shake 0.15, motion blur 0 |
| Motion comfort | shake 0.2, motion blur 0, flash 0.4 |
| One-handed play | every hold action becomes a toggle, parry indicator, `one_handed_layout` hint for the controls screen |
| Dyslexia-friendly | dyslexia font, text x1.2, boxed subtitles, dialogue speed 0.8 |
| Hard of hearing | subtitles on and large, callouts and effects at full volume, parry indicator |
| Calm sound | no combat music, reduced music intensity, music 0.5 |
| Relaxed pace | dialogue speed 0.6 |

Suggested pairings (shown, never forced): Story with One-handed and Low vision; Adventurer with Photosensitive-safe and Calm sound.

## Not built here
Core loading and applying these files (a `DifficultyFile` and an `Apply` for the multipliers and the floor), the settings and character-creation screens, the telegraph-lead and aggression hooks in monster AI, saving the chosen preset and sliders (a `SaveGame.Difficulty` enum exists; sliders need a new nullable field with a safe default), the parry timing indicator in the HUD, and text-to-speech menu narration. Each is named in the review for its owning agent.
