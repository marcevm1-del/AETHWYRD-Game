# Design review: new UI screens (title, menu, character creator, loading, windows) (2026-11-08)

Reviewer: anime-fantasy-director.

## Scope and what could be assessed
| Part | Status | Evidence |
|---|---|---|
| Title, main menu, character creator, loading screen | **NOT ASSESSED visually.** No render exists: the front-end code (`Game/Assets/_Game/Runtime/UI/FrontEnd/*`, `TitleSceneBuilder.cs`, `Data/UI/loading_tips.json`, `Data/Characters/player_appearance.json`) is uncommitted in the main checkout and needs Unity to draw. I am not allowed to run Unity in this job. | Reviewed from source: colours, font sizes, copy, options |
| Windows (crafting, companions, journal, accessibility, photo, overlay) | Assessed from the six `13_Production/phase1_*.png` renders. A full review already exists in `reports/phase1_window_review.md`; I re-checked the three I opened (overlay, crafting, journal) and found its findings still stand. Companions, accessibility and photo images were **not re-opened** by me. | PNGs + existing report |

**What still needs a Unity run:** one screenshot each of title (idle and "press any key" prompt), main menu with Continue, new-game confirm, creator (all fields, name edit), loading screen at 0 / 50 / 100 %, at 1600x900 and 1280x720, plus the colourblind and high-contrast variants. After that, re-run this review's checklist (section 4).

Verdict for the front end from source: **PASS WITH FIXES (provisional, unseen).**

## 1. Protect
- **Concept fits the genre.** Title with a painted dusk-to-dawn sky, three hill layers, drifting light motes, a spaced-out logo with a cyan glow and a soft "press any key" is the right calm, warm first impression (peaceful-isekai, not grimdark). Deterministic seed (`20261108`) makes captures repeatable: good for screenshots.
- **One window family.** The creator and settings reuse `SystemWindow` chrome (`RRect`, `Fill`, `Accent`, `Band`), so title screens match in-game panels. Keep it that way.
- **Honest, warm copy.** "A new game replaces your current save at its first autosave" with explicit Yes/No, and the 16 loading tips ("There is no rush. The world will still be here when you come back from supper.") hit the tone: warm, teen-safe, truthful. No spoilers.
- **Accessibility built in** (text scale `Ts`, a high-contrast path, pad prompt "Press A or Start"). Keep.
- **Creator restraint.** Two bodies, no locks, names suggested ("Haru, Mika, Rowan, Sage, Wren, Kit, Ash, Noa"), race and origin deferred to the prologue: low friction, matches `races_and_origins.md` step 2.

## 2. Problems, priority order
Owner key: ui-engineer builds; ux-designer specs; technical-artist for shaders; narrative-writer for copy; character generator owner = the `humans-base` session.

### P1 The creator previews a capsule-and-cube mannequin, not the new humans
`PlaceholderPlayerBody.Build` makes a capsule/cube rig. The creator is the first place a player judges the art, and a primitive body there undersells the game and contradicts the new base bodies (see `design_review_humans_2026-11-08.md`).
Fix: wire `PlayerBodyLibrary.Get(body)` to the human base prefabs once they pass review (hook already exists; `Apply` is by part name). Until then, hide the 3D body behind a framed silhouette card instead of showing primitives. Owner: ui-engineer + animator-rigger (prefab, bone names), after humans rework.

### P2 Option data and the human generator speak different vocabularies
- `Data/Characters/player_appearance.json`: bodies `masculine/feminine` with `torsoWidth`/`hipWidth` multipliers, 4 hair styles (short, long, ponytail, bun), 8 hair colours, 6 skin tones, 8 outfit colours.
- `Data/Characters/human_library.json` (humans-base branch): sex, height band, build (slim/sturdy), age (young/elder), hair styles, eyes, outfit colourways, cloak.
Same folder, two schemas, no mapping. The creator would show only a slice of what the generator can do, and ids may collide.
Fix: one source of truth. Recommendation: `player_appearance.json` stays the creator's menu and references ids from `human_library.json` (`bodyId`, `hairStyleId`, `skinId`, `eyesId`, `outfitColourwayId`). Add **eye colour** and **build** (slim/standard/sturdy) to the creator: eyes are the most-read part of an anime face and cost one row. Owners: tools-pipeline-engineer (schema + validator), character generator owner (ids), ui-engineer.

### P3 Palette and contrast
- Outfit swatches (`#4D73F2`, `#2FA3A3`, `#E6A93A`, `#D9718F`) are fully saturated. `art_direction.md` section 2 keeps body colours inside the value and saturation rules; check each swatch against it (value spread, saturation cap) and pull the highest-saturation ones down 8 to 10 %, so outfits sit well on the field green.
- Hair colours are good (naturals plus three anime fantasy tints). But `snow #E8ECF5` and `porcelain #F6DCCB` will blow out under rim light: check in the toon shader, not in the swatch.
- `deep #5E3B2A` skin: pair with a lighter iris option or catch-lights (see humans review P3), or dark skin loses its eyes.
- Title text uses cream `(1, .97, .9)` on a dusk gradient with a dark drop-shadow: fine. The cyan glow ring on the logo is alpha 0.1 times 8 samples: confirm it is visible at 720p; if not, raise to 0.16.
Owner: ui-engineer, technical-artist.

### P4 Small, dev-looking text in player view
- Bottom-left reads `v<version>   Phase 1 prototype` at 14 px. Fine in dev; strip or reword ("Early build") before any public build. Owner: ui-engineer. 
- Hint/footer text at 14 px bold is the minimum; section 8 asks for 14 or more for hints and 18 or more at 1080p for body. Creator labels at 19 to 20 px pass at 1080p, but check scaling at 720p with `Ts` below 1.
- Creator row hint "Colours come from the game data" is developer talk. Replace with "Left and Right change a choice. Press Enter on a name to type." Owner: ui-engineer + narrative-writer.

### P5 Menu feel
Menu has Continue, New Game, Settings, Quit as text rows. Add: (a) a subtitle line under the logo (one short tagline, owner narrative-writer), (b) Continue shows the save summary at right (already there: good) with the character's name and play time, (c) a soft one-shot slide-in of the rows (0.25 s ease-out) and a selection sound. Do not add a fifth row until Photo/Gallery or Credits are real: a menu of four clear choices is better than seven.

### P6 Loading screen
Progress bar with a moving highlight and a rotating tip is right. Fix: show the tip in sentence case with a small "Tip" chip, keep it on screen at least 4 s (no flicker on fast loads), and add a tiny drifting motif (slime or lantern silhouette) rather than the word "LOADING" alone at 34 px. Owner: ui-engineer.

### P7 Windows (carry-over from `phase1_window_review.md`)
Still open from my earlier review and visible in the renders I re-opened: body text and hint size, dim-blue secondary text (about `#4F6FA0` on navy, contrast under 4.5:1), crafting rows as a data dump, empty-state panels, music-log overlay colliding with the hotbar. The crafting renders in `phase1_crafting.png` already show the chip-and-detail-pane layout I asked for, so P3 of that report looks addressed; the 70 % empty Companions panel and Journal tab row were not re-checked. Owners as in that report.

## 3. Genre and feel notes
- The "System window" chrome is the game's signature. The title should have one System-window moment: the "Press any key" prompt could appear as a small System notification ("Welcome back, Adventurer"). Cheap, and fans of the genre smile.
- Avoid a heroic-pose character on the title. A quiet landscape with a lantern or road is on-brand ("warmth over comedy").
- Resemblance check (UI): no logo, layout or iconography copied from another game. The cyan-on-navy chrome is generic. Cleared, unseen: re-check once the renders exist.

## 4. Screen checklist (new)
The reusable checklist is in `13_Production/style_consistency_checklist.md` (section "Screens").

## 5. Verified facts
- Font sizes and colours quoted come straight from `FrontEndController.cs` lines 102, 463 to 556, 577, 607 to 755.
- 16 loading tips counted; max name length 20; 8 suggested names.
- I did not run the data validator on `player_appearance.json` (not my files, and `npm run build` is on the final job).
