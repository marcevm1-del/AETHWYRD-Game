# Accessibility review of every screen (ux-designer, 2026-11-13)

Job 3 of the ux-designer queue. Standard: `12_Systems/hud_and_ui.md` §14, `13_Production/style_consistency_checklist.md` D2, D3, D9, D11 and the input rules in `13_Production/ui_input_flows.md` §9.

## 0. What was and was not assessed
**Method: code reading only.** No Unity run, no screenshots opened, no pad played. I read:
`Code/Ascend.Core/Accessibility.cs`, `AccessibilityWindow.cs`, `PlayerWorldState.ApplyAccessibility`, the input and font blocks of `SystemWindow`, `RingZeroHud`, `NpcDialog`, `BagWindow`, `BestiaryWindow`, `WorldMapWindow`, `PhotoModeController`, `PlaytestOverlay`, `FrontEndController`, plus `MonsterController.ColorOf` (telegraphs), `HitFeedback.cs` (shake) and `HitStop.cs` (Flash Time).
**Not opened:** the six `phase1_*.png` renders (the art director's earlier reviews cover them: `reports/phase1_window_review.md`), any render of the title, menu, creator or loading screen (none exists yet), and the live game.

Result vocabulary (checklist): `PASS`, `FAIL`, `NOT ASSESSED` (could not look). A line read from code is marked **code** and never counts as a visual PASS.

## 1. Headline: the settings exist, but almost nothing listens
`AccessibilitySettings` (text scale, HUD scale, high contrast, dyslexia font, colourblind palette, subtitles, shake, flash, motion blur, reduced flash, volumes, hold/toggle) is **saved and clamped correctly** and the Accessibility window edits it. But a search of the whole `Game/Assets/_Game/Runtime` tree for readers of each setting finds:

| Setting | Read by (outside the Accessibility window) | Verdict |
|---|---|---|
| TextScale | `SystemWindow` (windows), `FrontEndController` (front end) | **Partial:** the six System windows and the front end follow it. Old modals (Bag, Bestiary, Map, NpcDialog, Photo, in-game HUD) do not |
| HighContrastPanels | `SystemWindow`, `FrontEndController` | **Partial**, same set |
| HudScale | nothing | **FAIL (code):** the slider has no effect |
| DyslexiaFont | nothing | **FAIL (code):** the toggle has no effect |
| ColorblindPalette | nothing (only a note line in the window lists the colours) | **FAIL (code):** telegraphs still use `MonsterController.ColorOf` fixed blue, red and gold |
| ScreenShake | nothing: `FeedbackSettings.ShakeScale` exists but is never assigned from the settings | **FAIL (code)** |
| FlashIntensity, ReducedFlash, EffectiveFlash | nothing | **FAIL (code):** Flash Time and impact frames ignore them |
| MotionBlur | nothing | **FAIL (code)** |
| Subtitles (on, size, background), DialogueTextSpeed | nothing: `NpcDialog` has no subtitle path and no text-speed read | **FAIL (code)** |
| Volumes, NoCombatMusic, ReducedMusicIntensity | music machine (`ApplyAccessibility` pushes music prefs) | **Partial:** music options reach the music machine; per-bus volumes not confirmed |
| Hold/toggle actions (`IsToggle`) | nothing: `PlayerInputDriver` always reads hold | **FAIL (code)** |

The Accessibility window therefore promises more than the game does. Players who turn on "Reduced flashes" or pick a colourblind mode are told it is saved and applied ("Changes apply at once") when it is not. **This is the most important finding.** Until each setting is wired, the footer and row text overstate what happens (a checklist E-rule violation in spirit: a control that cannot report it had no effect).

## 2. Screen-by-screen
Legend per line: P = PASS, F = FAIL, N = NOT ASSESSED. "code" means read from source only.

| # | Screen | Text scale (D2) | Contrast (D3) | Colour-independent (D9) | Pad-only | Keyboard-only | Flash and motion (D11) | Summary |
|---|---|---|---|---|---|---|---|---|
| 1 | Title and main menu | P code (`Ts`) | P code (cream on dusk, shadow) | P (text rows) | P code | P code | N | Provisional. 14 px footer is at the minimum; test at scale 0.8 |
| 2 | Character creator | P code | N (swatch contrast against skin not assessed; art review P3) | **F code**: choices are colour swatches; confirm each swatch has a name chip | P code | P code (text entry captures keys) | N | Colour-swatch rows need names |
| 3 | Settings | P code | N | P | P code | P code | N | |
| 4 | Loading screen | N | N | P | n/a | n/a | N | Tip must stay 4 s (art review P6) |
| 5 | In-game HUD (`RingZeroHud`) | **F code:** fonts 11 to 14 px hard-coded, ignores TextScale and HudScale | N | **F code:** HP, MP, SP bars distinguished by red, blue, green fills; the label text "HP/MP/SP" exists, so partly P | n/a | n/a | N | Fonts 11 and 12 px are below the 14 px minimum. HP bar red conflicts with "telegraph red reserved" (checklist D3 says losses are coral, not telegraph red) |
| 6 | Combat telegraphs | n/a | P (high saturation) | **F code:** `ColorOf` returns blue, red, gold only; shapes (circle, triangle, square) from `accessibility.json` are not drawn; palettes not used | n/a | n/a | N | Colour-only telegraph is a real gameplay barrier for red-green and blue-yellow colourblind players |
| 7 | Dialogue (`NpcDialog`) | **F code:** fixed font, no TextScale, no subtitle settings, no text speed | N | P | P code (A, D-pad, B) | P code (Enter, E, 1 to 9, Esc) | N | Speaker names shown (per Canon) not confirmed from code |
| 8 | Bag | **F code:** fixed font | N | N (rank colours must also show the letter, per §14) | P code | P code | N | |
| 9 | Bestiary | **F code:** fixed 14 px | N | N | P code (Esc/B) | P code | N | |
| 10 | World map | **F code:** fonts 11 to 14 px, ignores TextScale | N | **F code:** inked/pencilled/blank distinction is stroke and colour; confirm it also has a pattern | P code (LB/RB, triggers, stick) | P code | N | Overlay colours for zones need non-colour cues |
| 11 | Crafting | P code (`SystemWindow`) | **F** per `reports/phase1_window_review.md`: secondary text `#4F6FA0` under 4.5:1 (from the render, not re-opened by me) | P | P code | P code | N | |
| 12 | Companions | P code | N | N (relationship bars must carry labels; spec says words) | P code | P code | N | |
| 13 | Journal | P code | N | N | P code | P code | N | |
| 14 | Accessibility window | P code | N | P | P code | P code | N | Most complete screen, but see section 1 |
| 15 | Photo mode | **F code:** fixed font | N | P | P code (Y, A, B) | P code (H, Enter, Esc) | N | Hint fades after a few seconds: fine, re-appears on input |
| 16 | Playtest overlay | n/a (dev only) | n/a | n/a | n/a | n/a | n/a | Must not ship; excluded |
| 17 | Status Window hub, Skills constellation, Class tree, Titles, System tab | not built | | | | | | **NOT ASSESSED: screen does not exist.** Specs must carry the rules in section 3 |
| 18 | Pause, death screen, shops, save/load screens | not built | | | | | | **NOT ASSESSED: screens do not exist** |
| 19 | New-system screens from job 1 (`ui_new_systems_specs.md`) | spec only | spec only | spec only | spec only | spec only | spec only | **NOT ASSESSED: specs, not screens.** The spec's rules (section 12) are the acceptance criteria |

Totals: no screen has a visual PASS (no captures exist). From code alone, the table marks FAIL on rows 2, 5, 6, 7, 8, 9, 10, 11 and 15 (one or more lines each), plus every unwired setting in section 1; all remaining lines are PASS (code) or NOT ASSESSED as shown.

## 3. Ranked findings (each with an owner and a concrete fix)
### A1. Unwired settings are shown as working (blocks "accessibility done") - ui-engineer + gameplay-engineer
Wire each setting or hide the control until it works:
1. `ScreenShake` to `FeedbackSettings.ShakeScale` (already read in `CameraShake.Kick`): one line in `ApplyAccessibility`.
2. `EffectiveFlash` to Flash Time's screen tint, impact frames and Ultimate cut-ins: add a single `FlashAmount` the renderer multiplies by.
3. `MotionBlur` to the URP volume.
4. `HudScale` to a `GUI.matrix` in `RingZeroHud` and the world-space nameplates (`FaceCamera` labels).
5. `TextScale` and `DyslexiaFont` through a shared `UiStyle` used by **every** window, HUD, dialogue, Bag, Bestiary, Map and Photo (today only `SystemWindow` and the front end do it).
6. `ToggleActions` read by `PlayerInputDriver` and `PlayerTaming` (hold vs toggle).
7. Subtitles: a subtitle path in `NpcDialog` (size, background, speed); speaker name always shown.
Until each is wired, set that row to read "Not available yet" and the footer to honest wording ("Some changes apply after the next update").

### A2. Colour-only telegraphs - gameplay-engineer + technical-artist
`MonsterController.ColorOf` is the only mapping. Implement the three telegraph **shapes** (circle parryable, triangle unblockable, square grab) as an icon above the ring or a distinct ring pattern, and read the palette from `AccessibilityRules.PaletteFor`. Test with each of the four palettes at 1280x720.

### A3. In-game HUD ignores scale and uses sub-minimum text - ui-engineer
Fonts 11 and 12 px in `RingZeroHud`, `WorldMapWindow`, `BestiaryWindow`: raise to 14 minimum (18 body at 1080p), multiply by TextScale and HudScale. The HP bar uses a red-ish fill (`0.86, 0.22, 0.2`): move to the coral loss colour so telegraph red stays reserved (checklist D3).

### A4. Old modals do not follow the window chrome rules - ui-engineer
Bag, Bestiary, Map, Dialogue, Photo are IMGUI modals outside `SystemWindow`. Either fold them into `SystemWindow` (the one-menu-input-layer plan in `ui_input_flows.md` I11) or give them the same `UiStyle`. They are the screens a player sees most.

### A5. Colour-only information - ux-designer (spec) + ui-engineer
- Creator swatches: add a name label (Deep Brown, Snow) and the selected-state outline, not colour alone.
- Rank colours: the rank letter is always written (§14); verify on Bag, loot beams and map zones.
- Map status (blank, pencilled, inked) and the System overlay: add pattern (hatch, dotted, solid) plus colour.
- Relationship tracks, puzzle glyphs, element icons: already specified with words or shapes; verify in build.

### A6. Narration and text-to-speech missing - save-platform-engineer + ui-engineer
§14 promises menu narration. Nothing in the code reads UI text aloud. Plan: platform text-to-speech call (Windows SAPI) behind an option, focus announcement `row text, chip, hint`. Needs the third-party check in `13_Production/third_party_assets.md` only if a plugin is used (SAPI needs none).

### A7. Settings not in the front-end Settings page - ui-engineer
Accessibility lives in a playtest-only window (F5). The title and in-game settings must expose the same page, reachable by pad. Add it to the Controls and Settings hub.

### A8. Flash and strobing audit - technical-artist
Flash Time tint, impact frames, Ultimate cut-in, level-up ring, rank-up stamp: each must stay under 3 flashes per second (D11) and use the soft-fade path when `ReducedFlash` is on. Add a single check in the QA run: capture 2 s of an Ultimate and count luminance flips.

### A9. Input accessibility (see `ui_input_flows.md` §9, I9, I10) - gameplay-engineer + save-platform-engineer
Remapping, hold/toggle, one-handed presets, input grace: none implemented. Priority after A1.

### A10. Low-HP and critical cues - combat-designer + ui-engineer
Spec says the screen desaturates, a heartbeat plays and the pose changes, no red flash. Confirm in build; add a **text or icon** cue for deaf or hard-of-hearing players (a "Low health" glyph beside the HP bar) and a haptic option for the heartbeat.

### A11. Sound-only cues - audio-designer
List every audio-only cue (companion callouts, siege horns, Blood Vesper warning) and require a visual equivalent in the HUD. Today the Vesper dial turning red is colour-only: add an icon.

### A12. Cognitive load and clarity - ux-designer
- Crafting and fitting screens: one anchor, details only for the selected row (spec done).
- Tutorials replayable from the System tab and never forced (job 4).
- No timed menus, no auto-dismissing text that carries instructions (toasts must be repeatable from the log).

## 4. What is already good (protect it)
- The settings model clamps and sanitises every value, so a hand-edited save cannot break the game (`AccessibilitySettings.Sanitize`, tested).
- Shapes and colours for telegraphs are **defined in data** with a validator that rejects duplicate shapes (`AccessibilityRules.Validate`): only the renderer is missing.
- Speaker names are always shown (a property that cannot be turned off).
- The window family is consistent; the front end and `SystemWindow` already scale text and offer high contrast.
- `PadActive` input-device detection exists and is shared by menus.
- Camera shake has a hard cap (`ShakeMax`) and Flash Time is real-time based, so a stop does not freeze menus.

## 5. Acceptance checklist for "accessibility done" (per screen, mark each line)
| # | Line | How |
|---|---|---|
| X1 | Text scale 0.8, 1.0, 1.5 and 2.0: nothing clipped or overlapping | Screenshot each, at 1280x720 and 1600x900 |
| X2 | High-contrast panels: body text at least 4.5:1, selection at least 3:1 | Eyedrop |
| X3 | Each colourblind palette: telegraphs distinguishable by shape alone | Screenshot all four palettes |
| X4 | Pad-only run: open, use and close the screen without a keyboard | Play |
| X5 | Keyboard-only run, same | Play |
| X6 | Reduced flashes on: no flash above 25 % and under 3 per second | Capture 2 s of the worst effect |
| X7 | Subtitles on: dialogue size, background and speaker name correct | Screenshot |
| X8 | Narration on: the screen reads row, chip and hint | Listen |
| X9 | Rebinding: change one binding, restart, it persists | Play |
| X10 | Hold/toggle on for sprint and block | Play |

**Status of X1 to X10 today: NOT ASSESSED for every screen** (no build, no captures). Nothing is approved. A screen is approved only when all ten lines are PASS or are marked not applicable with a reason.

## 6. Decisions made (overrule me)
1. Treat any setting that does nothing as a bug of the controlling screen, not of the setting: hide or relabel it until wired (A1).
2. Telegraph shapes are mandatory in all palettes, including Off (colour never carries the rule alone).
3. Narration uses platform speech; no new third-party package.
4. HP loss colour moves to coral; telegraph red stays reserved.

## 7. Handover
- **ui-engineer:** A1 (items 4, 5, 7), A3, A4, A5, A7, A10.
- **gameplay-engineer:** A1 (items 1, 6), A2, A9.
- **technical-artist:** A1 (items 2, 3), A2 (art side), A8.
- **save-platform-engineer:** A6, A9 (storage).
- **audio-designer:** A11.
- **qa-tester:** section 5 as the test plan once screens are built.
