# Phase 1 window review (creative + UX)

Reviewed: `13_Production/phase1_{crafting,companions,journal,accessibility,photo,overlay}.png` (all six viewed, 1600x900), against `13_Production/art_direction.md` section 8 ("anime System window"). I did not find or read the ux docs (file search timed out), so the UX checks below are against section 8 and general readability, not the ux specs.

## Verdicts

| Window | Verdict | One line |
|---|---|---|
| Accessibility | Pass with fixes | Best of the set: clear groups, live values, bars. Label and bar are too far apart. |
| Crafting | Needs rework | Works as a data dump but reads as a spreadsheet, the thing section 8 forbids. |
| Companions | Needs rework | Functionally right, but about 70% empty, with no empty-state design. |
| Journal | Needs rework | Same empty-panel problem, and the Archive tab is only a footer line. |
| Photo | Fail (capture) | Shows the plain world with no photo UI at all. Either the capture missed the mode or photo mode has no visible chrome. |
| Overlay (music log) | Dev-only, fix before it can show | Debug strip collides with the hotbar and clips its text. |

## What is good (protect it)
- One shared window frame, with the same title, section headers, footer hint line and selection bar on all four panels. The family is consistent and learnable.
- Orange section headers over navy are readable, and the cyan selection bar with the triangle marker is clear.
- Accessibility is genuinely thorough: text and HUD size, high-contrast panels, dyslexia font, colourblind mode, shake, flash and motion-blur sliders, and per-bus volume. The footer line ("Changes apply at once and are saved") is honest and helpful.
- Writing is warm and plain: "Ask around and look closely when you explore", "The stance is a request: companions still retreat when badly hurt". That is the right tone.
- Panels sit centred and keep the minimap and quest tracker visible, so the player keeps their bearings.
- Crafting shows needs with an owned/missing marker and the result ("makes Fire Bomb"). The information is right even though the layout is not.

## Ranked fix list

### 1. Panel chrome is not the System window yet (all windows) - owner: ui-engineer, spec by ux-designer
Section 8 asks for 82% navy glass, 6 px radius, a 1 px cyan inner line and 14 px bracket corners. The screenshots show a flat, hard-cornered rectangle with a cyan line only along the top and bottom, and a plain orange title. There is no chevron header bar, letter-spacing, bracket corners or glow.
- Add 14 px bracket corners in `#7FE3FF` and a 6 px radius.
- Make the header a bar with a chevron, the name letter-spaced 8%, and a faint drifting scan line.
- Keep the panel at 82% opacity. Today the world is almost hidden, which is fine for readability but loses the "glass".
- Add the open/close wipe from section 8 if it is not there.

### 2. Text size and tonal contrast (all windows) - owner: ui-engineer
- Body text is about 14 px high in a 900p frame, roughly 17 px at 1080p. Section 8 sets body at 18 px or more at 1080p and nothing smaller. Raise body to 20 px at 1080p. Hint lines and the hotbar keys are about 11 to 12 px and should be at least 14.
- The dim blue "needs / expected" text in Crafting (about `#4F6FA0` on navy, well under 4.5:1) and the grey hint lines are too faint. Use at least `#B8C8E0` for secondary text, and keep `#7FE3FF` or white for primary.
- Section 8 also says gains flash cyan; do not use the dim-blue tier for anything the player must read.

### 3. Crafting hierarchy - owner: ux-designer (layout), ui-engineer (build), items-designer (wording)
Every recipe is four lines of the same size and weight, so the eye has no anchor.
- One line per recipe: item name (large, white), rank/skill chip on the right, and a status chip (Ready / Missing 2 Prime Meat / Needs workbench).
- Show details only for the selected row, in a right-hand pane: needs list, expected quality, the attuned-craft option.
- "You need the right workbench for this." repeats on five rows and contradicts the header "working at the campfire (anywhere)". Say it once in the header, and grey out rows that cannot be made here.
- Sort craftable rows to the top. Today the only craftable-looking row is hidden among the rest.
- Replace the unexplained filled/empty square markers with a check or cross and the colour pair cyan (have) and coral (missing, `#FF7A6B`).
- "attuned craft (spends one extra X): standard" is jargon. Rename to "Boost: spend 1 extra Sap" with the result named.
- Add item icons (even placeholder shapes) and show owned/needed as "2/2".

### 4. Empty states (Companions, Journal) - owner: ux-designer, narrative-writer for copy
About 70% of each panel is empty navy with a single line of dim text. The anime pattern here is a silhouette or sigil with an invitation.
- Companions: a faint slime/wolf silhouette and "Your first companion is out there. Guild notice boards often mention strays." Keep the three section headers but collapse empty ones into a single line.
- Journal: show the tab row as real tabs (Dungeon clues, Archive, and so on) with the active tab lit. "Left/Right: Archive" as a footer is easy to miss. Add a small inkwell or page sigil in the empty area.
- Journal reads as the "Diegetic parchment" case in section 8 (map, board, letters are warm paper `#F3E6C8` with ink `#3A2A1C`). Decide whether the Journal is a System window or parchment. My recommendation: parchment for the Archive, System for clues and records. At minimum, do not make it identical to Crafting.

### 5. Accessibility layout - owner: ui-engineer
- The label is at x 360 and its slider at x 1030, a gap of about 500 px, so the eye loses the row. Right-align the value and put the bar directly after it, or draw a full-width row hover that links them.
- The bars carry no value ticks. Add end labels (0%, 100%) and a notch at the default.
- The note under "Reduced flashes: Off" says "flashes are drawn at 60% strength" in lowercase and dim text. It looks like an error. Capitalise, use a clearer line ("Flashes are currently 60% strength. Turn on Reduced flashes to lower them."), and place it directly under Flash intensity.
- "Colourblind mode: Off" should show a small preview swatch strip when changed. "Text size" should resize live and show a sample line.
- The scrollbar thumb is a hairline. Use a 6 to 8 px bar with a visible thumb. Show "More below" at the bottom.

### 6. Photo mode capture - owner: qa-tester (re-capture), ui-engineer (UI)
The image has no photo UI: no frame, no hint line, no controls, and the HUD is still on. If this is the real state of photo mode, it needs a hint strip (Move, Zoom, Tilt, Hide HUD, Take photo, Exit) and a rule-of-thirds toggle. If not, re-capture with the mode active. Also confirm the HUD hides in photo mode; a photo with the quest tracker and minimap in it defeats the purpose.

### 7. Overlay collision and clipping - owner: ui-engineer
"MUSIC LOG / music: not running (no music data)" sits in a strip at bottom-left that runs under hotbar slot 4 (its "4" label is covered) and its second line is clipped at the bottom edge ("running" loses its descenders). Mark it debug-only and hide in release builds. If it stays, move it to the top-left under the HUD, give it an 8 px margin and a 40% navy backing plate, and stop it at x 600.

### 8. Controller hints (all windows) - owner: ux-designer, ui-engineer
Every window footer reads "Up/Down choose - Enter use - Left/Right change - PgUp/PgDn scroll - Esc close". These are keyboard names only. Show glyphs for the active device, switching on last input: D-pad or stick to choose, A/South to confirm, bumpers or triggers to page, B/East to close. Put the hints in a fixed footer bar with an icon and verb pair, rather than a sentence of dim text. In Journal, the Archive switch should be a bumper glyph (LB/RB) shown at the tab row.

### 9. HUD and world text (visible in every screenshot) - owner: ui-engineer
- "Rank F - 0 copper" and the date line are thin white text on bright sky, with no outline or plate. Section 8 requires a 2 px dark outline or 40% navy plate. Same for the quest tracker text and "Whisperwood - Tab: map".
- At the right edge a large "M" glyph and a "47 m" marker are clipped by the screen edge. Clamp off-screen markers to an inset (24 px) and shrink them.
- The hotbar's "Combo Budget" label is covered by the panel bottom edge when a window is open. Either dim the HUD under a window or keep windows 24 px clear of it.

### 10. Palette and colour discipline - owner: art-director, with anime-fantasy-director sign-off
- Orange headers vs cyan lines: section 8 spec has cyan as the System voice. Orange reads as warning or telegraph gold, which is reserved. Use cyan `#7FE3FF` for headers, with orange only for quest or rank accents.
- Red/green/blue HP/MP/SP bars are saturated primaries that clash with the navy glass. Soften to the System palette (coral `#FF7A6B`, cyan, a leaf green) with a 1 px inner highlight.

## Out of scope but noticed
The world behind the windows (stick-figure player, primitive stalls) is still greybox. That is expected at this stage and not a window issue.

## Suggested handoff
1. ux-designer: write a one-page System-window spec update (chrome, type scale, secondary-text colour, footer hint bar, empty-state pattern) and the Crafting row layout.
2. ui-engineer: items 1, 2, 5, 7, 9 (mechanical), then 3, 4, 8 from the spec.
3. qa-tester: re-capture Photo with the mode active and re-shoot all six after the fixes, at 1080p as well as 900p.
4. Canon: nothing here changes canon.

Not done: I did not run Unity, edit any code or commit.
