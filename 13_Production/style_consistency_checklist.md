# Style consistency checklist (characters, outfits, screens)

Owner: anime-fantasy-director. Extends `art_direction.md` section 11 (assets) with what the 2026-11-08 design reviews found. Every new character, outfit and screen must pass the matching section **before** it is called done. Reviews live in `reports/design_review_*.md`.

## How to use it
1. Render or screenshot the thing at the **gameplay distance** first, then close up. Contact sheets without outlines and the toon shader are previews, not approval.
2. Mark each line **PASS**, **FAIL** or **NOT ASSESSED** (could not look: no render, no Unity, file missing). Say which and why. A line that was not checked is never PASS. One NOT ASSESSED or FAIL means the item is not done.
3. Findings go to the owning agent with a concrete fix (numbers where possible).

Result vocabulary: `PASS`, `PASS WITH FIXES` (only minor FAILs, each with an owner), `FAIL`, `NOT ASSESSED` (ranks above PASS, below FAIL).

---

## A. Every item (character, outfit, creature, building, screen)
| # | Check | How |
|---|---|---|
| A1 | **Greyscale at 25 % size:** the hero shape and the face (or focal point) still read | Desaturate and shrink the render |
| A2 | **Value:** it differs from its home ground by 25 points or more, or has rim 0.35 | Sample ground and body |
| A3 | **60/30/10 colour** with one accent; no reserved colour (telegraph red, gold, blue) as dominant | Eyedrop three areas |
| A4 | **Outline and shading:** ink hull a darker version of the local colour (never black), two-tone ramp, shadows tinted violet, **no PBR gloss** except slime, eyes, metal, wet things | Look in `Ascend/Toon`, not the viewport |
| A5 | **Same detail level as its neighbours:** a hero prop is not flatter than the houses around it, a creature is not glossier than the buildings | Place side by side |
| A6 | **Teen rating, no fanservice:** practical clothes, respectful camera, no gore, childlike characters framed as children | Review the three-quarter and back views too |
| A7 | **Resemblance check:** list hair shape and colour, colour triad, outfit silhouette, signature items. Does the combination recall one specific famous character, creature, building or logo? If yes, change two of the four | Write the answer down, even if "none" |
| A8 | **Region fit:** uses its region family palette and materials (`building_system.md`, `creature_system.md`, `gazetteer.md`); shared props restyled per region | Compare with the region sheet |
| A9 | **Warmth over comedy:** default expression or mood is soft and open, not a smirk or a gag | Look at the default pose and face |

## B. Characters and outfits
| # | Check |
|---|---|
| B1 | **Proportions** match the class row in `art_direction.md` section 5: heroic humanoids 6.5 to 7.5 heads, legs about 52 % of height, small hands and feet, **clear waist**; children 4 to 5 heads |
| B2 | **Silhouette first:** each outfit has its own silhouette (tunic, long coat, robe, cloak), not one template recoloured. Two characters must be told apart in solid black at 64 px |
| B3 | **Hair** is 4 to 6 big tapered clumps over a full scalp cap, no flat ribbon strips; default length no longer than the shoulder blade; side strands within 1.15 x shoulder width; an "angel ring" highlight band at 25 % down the hair mass |
| B4 | **Eyes** sit on the 50 to 55 % midline, each 20 to 24 % of face width (use the top of the band for gameplay-distance characters), one eye-width apart; iris about 60 % of eye height; two highlights (upper-outer large, lower-inner small); lash line dark from the hair hue, never pure black |
| B5 | **Eye contrast:** iris at least 25 lightness points off the skin tone, on every skin tone in the creator; test the deepest and the lightest |
| B6 | **Face shadow** comes from the hand-authored face normal: no diagonal band across the face; nose is one soft shade or small wedge; mouth a short line |
| B7 | **Props are explained:** every item on the body is a pouch, strap, charm or tool the viewer can name. No floating slabs or patches |
| B8 | **Age and build cues** beyond hair colour: elders get slightly lower shoulders, a small stoop and one accessory; build changes thigh and shoulder radius, not only height |
| B9 | **Back, side and three-quarter views** have no glitches (no spiky belt strips, no gaps between hair clumps and scalp) |
| B10 | **Variants change one channel** from the base (colour, size, scars, glow), never two |
| B11 | Passes in the **creator preview and in the world** with the same look data (ids from the data library, not hard-coded) |

## C. Creatures and buildings (when they appear next to characters)
| # | Check |
|---|---|
| C1 | Every creature with a head shows a face (eyes or eye-lights) from front and 3/4; eye style matches its rank (round and sparkly F to E, almond D to C, narrowed or glowing B+) |
| C2 | Weapons and shields only where the look text says so; blade width at least 6 cm at scale (readable at 20 m) |
| C3 | Limbs have taper, an elbow or knee bend and a shaped hand or foot; no uniform sausages |
| C4 | Boss silhouettes read as three masses at 60 m with one focal accent at 5 to 8 % of the silhouette |
| C5 | Variants of one family keep the base silhouette (dragons need a hero feature per species, not four recolours) |
| C6 | Town props (lamp post 3.0 to 3.4 m, stall, fountain) are restyled per region and as detailed as the houses |

## D. Screens and windows
| # | Check |
|---|---|
| D1 | **System window chrome:** navy glass `#0E1A2E` at 82 %, 6 px radius, 1 px cyan `#7FE3FF` inner line at 60 %, 14 px bracket corners, header bar with chevron and letter-spaced caps (section 8) |
| D2 | **Type:** one rounded sans; body at least 18 px at 1080p, labels at least 14 px, nothing smaller; check at 720p with text scale below 1 |
| D3 | **Contrast:** secondary text no darker than `#B8C8E0` on navy (4.5:1 or better); gains cyan then white, losses coral `#FF7A6B`, never telegraph red |
| D4 | **Hierarchy:** one anchor per screen; rows are one line with chips, details only for the selected row; no spreadsheet walls |
| D5 | **Empty states** have a sigil or silhouette and an invitation, not a dim line in a blank panel |
| D6 | **Hint line** shows keys and pad glyphs for every action; names a way out (Esc or B) |
| D7 | **Over the world:** text has a 2 px outline or a 40 % navy plate; nothing covers the player, quest tracker or minimap unless it is modal |
| D8 | **Diegetic parchment** (map, board, letters) uses `#F3E6C8` paper and `#3A2A1C` ink, not System chrome |
| D9 | **Accessibility modes** checked: text size, high contrast, colourblind modes, reduced flashes, pad-only navigation |
| D10 | **Copy:** warm, plain, true to what the game does; no developer words ("from the game data"), no "prototype" text in a player build |
| D11 | **Open and close** motion, chime and focus move all work; nothing flashes more than 3 times per second |
| D12 | **Captured:** one screenshot per state (idle, selected, empty, error, confirm) at 1600x900 and 1280x720 is attached to the review |
| D13 | **Character shown on a screen** (creator, status, title) is the real model, not a primitive stand-in, or is hidden behind a framed silhouette card |

## E. Gate rules for reviewers (so the checklist cannot pass silently)
- If the render, screenshot or Unity run needed for a line does not exist, write `NOT ASSESSED: <what is missing>` for that line. Do not infer PASS from the data or the code.
- If a section has no checked lines, the whole section is NOT ASSESSED in the report and the item is not approved.
- Every review names what it opened and what it did not open.
- A new line is added to this file whenever a review finds a defect that no line catches; the review links the new line.

## F. Changelog
- 2026-11-08: first version, from `design_review_humans`, `design_review_ui_screens` and `design_review_creatures_buildings` (all 2026-11-08).
