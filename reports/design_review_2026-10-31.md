# Design Review: Follow-up on the 2026-10-25 Fixes, 2026-10-31

> **Reviewer:** anime-fantasy-director. **Rules:** `13_Production/art_direction.md` (v1.1; this review adds §3.1, the contact-sheet preview standard). **Previous review:** `reports/design_review_2026-10-25.md`.
> **What I opened (every image commented on below):**
> - `reports/building_fixes_2026-10-31/before/` and `after/`, 9 regions each: sunscar, zarvan, mossdeep, iron_hold, umbravel, greymoor, fanghold, whisperwood, aldmere.
> - `reports/building_fixes_2026-10-31/b1_before/` and `b1_after/`, 6 regions: hoshizora, iron_hold, sunscar, frostveil, zarvan, gearholm. (`b1_before/iron_hold.png` is byte-identical to `before/iron_hold.png`, so I compared it once.)
> - `reports/toon_preview_2026-10-31/`, all 7: buildings_plain, buildings_toon, creatures_plain, creatures_toon, dark_families_toon, mushrooms_toon, whisperwood_vs_aldmere_toon.
> - `reports/mushroom_faces_2026-10-31/` before and after; `reports/creature_fixes_2026-10-31/` before and after.
> - `10_World/maps/physical_map.png`, read with `10_World/physical_geography.md`.
> - I also read `reports/building_fixes_2026-10-31.md`, `reports/creature_fixes_2026-10-31.md`, the commit notes for 95da1a6, 910f08f, c0a1fc8 and 3155380, and `Tools/blender/ascend_buildings/preview.py` `camera()` to find the cause of the cropping.
>
> **Caveat:** all of these were rendered headless on software OpenGL. I trust them for shape and colour. I don't treat them as final shading. `dark_families_toon.png` and `mushrooms_toon.png` were rendered from the wave-1 state (7c1cc44), before the per-key glow strengths (3155380) and the B1 and code-review fixes.

---

## Verdict table

| Item | Verdict | One line |
|---|---|---|
| **B1** shared props follow the family | **Partly closed** | Stalls, walls, fountains, mills and the Hoshizora kura are good. Lamps in desert, garden and nordic are still the default iron post. Granaries in Sunscar and Iron Hold, and the Hoshizora wall and fountain, are still European |
| **B2** signature overuse, Mossdeep remaps | **Closed** | Domes and onions now sit only on civic and temple types. The Mossdeep forge, stable, toadstool gate and hedge wall are charming |
| **B3** dark families go monochrome | **Partly closed** | Fanghold and Greymoor are fixed. Iron Hold's glow reads cream, not forge orange. Umbravel's lanterns went violet, where the guide asks for warm, and its windows clip to white |
| **B4** Whisperwood vs Aldmere | **Closed** | Thatch, moss, ivy and lanterns against ashlar, slate and banners: the two now read as different places at a glance |
| **R1** toon preview | **Partly closed** | The renderer is right and should become the standard (§3.1). It is not yet used by the library sheet builders, and the scale figure shrinks small creatures to specks |
| **C1** faces and masks | **Partly closed** | The scarecrow mask is gone and the wolf's eyes now read from 3/4. The werewolf's eyes are still pin-dots, and the skeleton has a fleshy human face, not a skull |
| **C3** dragons | **Partly closed** | The neck rises and the horns read. Wings are still about 1.5× body length (the target is ≥ 2.2×), and the legs are still a hound's |
| **C5** biped mannequins | **Partly closed** | Taper and mitten hands are there but subtle. The new loincloth reads as a flat brown board or clipboard on the goblin, werewolf and scarecrow |
| **C6** plants and avians | **Closed** | The crow has a tapered two-tone beak and folded wings, the mandrake has a leaf crown, and the mushroom has a cap. These are real silhouettes now |
| **Mushroom faces** | **Partly closed** | Faces now show under the caps. The eyes are bulging "googly" eyes pushed to one side of the head, and most species carry a stitched-teeth grin, so they read creepy rather than cute |

---

## 1. What works and must be protected

| # | Asset | Why it works | Protect by |
|---|---|---|---|
| P10 | **Mossdeep working buildings** (`after/mossdeep.png`) | The toadstool forge with its stone chimney, the gate made of two toadstool towers under a root arch, and the hedge wall dotted with tiny toadstools. Each one is cute and region-unique, and the circle language holds across the set | Keep the remaps. Use them as the model for "a working building inside a signature family" |
| P11 | **Fanghold cloth** (`after/fanghold.png`) | Red and blue bands on eaves and door jambs plus big banners: the steppe finally reads from 100 m | Keep. See S3 note N8 on density |
| P12 | **Whisperwood dressing** (`after/whisperwood.png`, `whisperwood_vs_aldmere_toon.png`) | Thatch, moss on slate, ivy and two warm lanterns per front. This is the cosy isekai starter village | Keep `cover_mix`, `climbing_ivy` and `facade_lanterns` as Whisperwood defaults |
| P13 | **Desert and garden walls and the wind-catcher** (`b1_after/sunscar.png`, `zarvan.png`) | Battered adobe with round merlons and spouts; ochre brick with turquoise tile bands and turquoise caps. The wind-catcher is a better call than a windmill | Keep. The environment-artist's choice of a garden wind-catcher is approved |
| P14 | **Hoshizora kura and paper lamp; Iron Hold water-forge; Gearholm gas lamp; Frostveil watermill** | Each prop is now unmistakably from its own region | Keep |
| P15 | **The toon preview look** (`buildings_toon.png`, `whisperwood_vs_aldmere_toon.png`) | Two-tone shading, local-colour outlines, a painted sky band and a bright lawn. The buildings jump from "clay model" to "anime background" | Make it the sheet standard (§3.1 of the style guide) |
| P16 | **The crow and the mandrake** (`creature_fixes/after.png`) | Clear silhouettes, a face from 3/4, one hero shape each (beak, leaf crown) | Use as the reference for avian and plant plans |

---

## 2. Item by item

### B1 (S2) Shared props: **partly closed**. Owner: **environment-artist**
**Seen.** The stall canopy follows `cloth_a` everywhere: indigo in Hoshizora, terracotta in Sunscar, red with blue posts in Zarvan. Walls are fixed for desert, garden and nordic (palisade). Fountains use family stone: basalt in Iron Hold, adobe in Sunscar, a turquoise rim in Zarvan, brick in Gearholm. Mills became a water-forge, a wind-catcher and a watermill, and Gearholm dropped its mill. The Hoshizora kura is excellent. Still open:
1. **Lamp posts in Sunscar, Zarvan and Frostveil** are still the default dark iron post with a box lantern.
2. **Granaries:** Sunscar keeps the European round tower with a white tile cone. Iron Hold's is a round basalt tower with a **straw thatch** cone, and thatch doesn't belong on basalt halls.
3. **Hoshizora** keeps the crenellated grey European wall and the tiered European fountain.
4. Frostveil keeps the tiered stone fountain; a fjord village wouldn't have one.

**Fix.**
- **Lamps:**
  - desert: a pierced-brass lantern (0.45 m) on a 2.4 m adobe pillar with a rounded cap;
  - garden: a turquoise-glazed lantern on a slim ochre brick column, 2.6 m;
  - nordic: an iron lantern under a small shingle hood on a 2.5 m log post.
- **Granary:**
  - desert: two or three beehive mud domes, 2.5–3.5 m, in wall plaster `#E0B885`;
  - dwarven: a squat basalt silo with a copper cone `#B87333`, never thatch.
- **Hoshizora** wall: white plaster `#F2EDE0` on a 0.8 m stone base, with a small tiled coping roof in `#3D4757`.
- **Fountains:** Hoshizora gets a low stone water basin with a wooden spout. Nordic swaps the fountain for a covered well-house with a turf roof.

These forms are generic to their architecture. No specific work is copied.

### B2 (S2) Signature overuse: **closed**. Owner: environment-artist
In Sunscar 3 of the 8 sampled buildings carry a dome, and in Zarvan 3 of 8 carry onions. These are the temple, guild hall and town hall towers; the sample was weighted to civic types, and the catalogue figure is 6 of 30. The stable and smithy are now flat-roofed with vigas. Zarvan's homes now read as crenellated sandstone with turquoise bands. That is correct, but they are close to a "desert castle". If a later sheet looks too martial, the next lever is iwan door frames and tile panels, not more domes. No action needed now.

### B3 (S2) Dark families: **partly closed**. Owners: **technical-artist** (render), **environment-artist** (palette)
**Seen.**
- **Fanghold:** fixed. Stone is warmer, and cloth bands and banners are on every building.
- **Greymoor:** two green-yellow lanterns per front and teal doors. The walls are still grey boards, but the lanterns carry the village. Fixed.
- **Iron Hold:** bronze bands are clearly wider, and 2 of 8 roofs are copper. But the lit windows and ember caps render **pale cream-yellow**, not forge orange `#FF8C26`. In `dark_families_toon.png` the smithy has almost no glow.
- **Umbravel:** stone is lighter, and windows are lit. But the windows clip to near-white. The new silk lanterns render **pinkish violet**, so the town has no warm point at all. The style guide (§4.2) asks for warm silk lanterns against violet window glow. The code-review change that set the Umbravel `lamp` to violet (0.55, 0.32, 1.0) contradicts it.

**Fix.**
1. technical-artist: set the preview and sheet scenes to the `Standard` view transform with no look and exposure 0. AgX/Filmic desaturates bright emission towards white, which is what turns `#FF8C26` cream and `#C77AFF` white. Then re-render `dark_families_toon` with the 3155380 strengths (lamp 1.5, window 2.0, ember 2.5). Acceptance: a lit window pixel keeps saturation ≥ 50% and the hue within ±15° of its key.
2. environment-artist: Umbravel `lamp` goes back to warm amber `#FFB852` (linear ≈ 1.0, 0.48, 0.09). Windows stay violet `#C77AFF` at 2.0. That gives one cool and one warm light per facade.
3. environment-artist: at least 3 warm emissive points per Iron Hold building (§4.2). The smithy needs its forge mouth lit (a 1.2 × 0.8 m glow plane inside the open bay).

### B4 (S3) Whisperwood vs Aldmere: **closed**. Owner: environment-artist
In `whisperwood_vs_aldmere_toon.png` the top row (thatch, moss, ivy, lanterns) and the bottom row (ashlar ground floor, dark slate, no ivy) read as two places at a glance. One S3 note on Aldmere: the royal-blue banners sit on blue shutters and blue-grey slate, so they lose value contrast. Give the banner a gold field `#D9A833` with a blue charge, or a gold border at 15% of its width.

### R1 (S2) Toon preview: **partly closed**. Owners: **technical-artist** (renderer), environment-artist and creature-artist (adopt in their sheet builders)
**Seen.** `buildings_toon` against `buildings_plain` is a night-and-day improvement. The painted sky band, the saturated lawn, two-tone shading and local-colour outlines all work. In `creatures_toon` the slime, goblin and skeleton gain a lot. Problems:
1. **The scale figure overwhelms small creatures.** The tile frames creature + figure, so the Horned Rabbit (~25 px), the Mandrake (~40 px), the Crow, the Blue Slime and the small mushrooms in `mushrooms_toon` become specks next to a 230 px capsule. The tile no longer shows the creature, and that is what we are approving.
2. The figure is a capsule with a ball head and reads as an "i" glyph, not a person.
3. The library builders (`library.py`, `build_creature_library.py`) don't use the preview yet.

**Fix.** The rules are in style guide §3.1:
- frame on the **subject only**, with the subject filling 70–85% of the tile's shorter side;
- the figure stands behind and to the right and may be cropped by the frame (a shin and a boot next to a rabbit still read as scale);
- the figure is a flat lavender-grey `#A9A6C2` human silhouette 1.7 m tall (head 1/7 of height, shoulders, legs);
- write the height in metres in the tile label;
- adopt the preview in both library builders as the default, with `--plain` for geometry debugging only.

### C1 (S1) Faces: **partly closed**. Owner: **creature-artist**
**Seen in `creature_fixes/after.png`:**
- The wolf's eyes are now visible from 3/4.
- The scarecrow lost the white oval mask. Its stitched grin fits a "Smiling Scarecrow".
- The goblin, rabbit, slime, mandrake and crow all show faces.

Still open:
- The **werewolf's** eyes are 2–3 px purple dots.
- The **skeleton** has a pale, smooth human head with a nose and lidded eyes. It reads as a mannequin, not a skull.

**Fix.**
- Werewolf: `eye_size` 0.22 → 0.26 with a glowing amber iris `#FFB347` (B+ rule, §6.1) and a brow ridge 0.15 hr deep.
- Skeleton: a skull plan with hollow sockets (r 0.22 hr, colour `#2A2238`) and a glow point inside each (r 0.12 hr). Add cheekbones and a jaw separated by a 0.05 hr gap, with no nose or skin. Bone `#E8DFC8`.

### C3 (S1) Dragons: **partly closed**. Owner: **creature-artist**
**Seen.** The Young Dragon now has a rising neck and two swept horns. That is better, but at sheet size it still reads as a small winged dog. The wings span about 1.5× body length, and the four legs are straight hound legs of equal length.

**Fix (unchanged targets from 10-25):**
- wingspan ≥ 2.2× body length (today's +17% is not enough: use +50%);
- 3–4 finger bones with a scalloped membrane;
- hind legs digitigrade with thighs 1.4× the forelimb radius, and forelegs 0.8× the hind leg length so the back slopes;
- tail ≥ body length, ending in a spade.

Check: at 64 px in solid black, it must not be confusable with the Forest Wolf on the same sheet.

### C5 (S2) Bipeds: **partly closed**. Owner: **creature-artist**
**Seen.** Tapering is barely visible at sheet size. The skeleton's ribs are bars, but on a solid pale torso, so the background doesn't show through. The **loincloth renders as a flat, rigid brown rectangle** held in front of the goblin, werewolf and scarecrow, and it reads as a board or clipboard. The orc's topknot is visible, and its sword is still the thin grey blade.

**Fix.**
- Loincloth: a trapezoid (top 0.8× hip width, bottom 0.55×, length 0.35× leg) bent in two segments with a 10° forward flare, plus a back flap. Use the cloth colour `#8A5A35` with a 0.03 m darker hem.
- Limb taper: upper radius ≥ 1.3× lower (make it visible, not 1.1×).
- Skeleton: delete the torso fill between the ribs.
- Orc sword: blade width ≥ 6 cm (§7.6).

### C6 (S2) Plants and avians: **closed**. Owner: creature-artist
The crow has a two-tone beak hooked at the tip, folded wings and a clean silhouette. The mandrake's 5-leaf crown is cute. The Walking Mushroom has a spotted cap. The mushroom bodies are still trunk-and-root shapes, and I accept that for now. Face work is the next item.

### Mushroom faces: **partly closed**. Owner: **creature-artist**
**Seen in `mushroom_faces/after.png` and `mushrooms_toon.png`:**
- Faces are now under the caps (closing the 10-25 gap).
- Only the red Walking Mushroom (tile 2) has the right read: two big black dot eyes, centred.
- The others have bulging white "googly" eyes pushed to the camera-right side of the head, one half behind the silhouette. Most have a stitched-teeth grin, and green growth spots sit on the face.

At F–E rank that reads creepy, not cute.

**Fix.**
- F–E mushrooms use the slime and familiar eye row of §6.1: dot eyes, `eye_size` 0.36, `eye_spread` 24°, `eye_up` 0, centred on the face axis, with a tiny "o" mouth (0.12 hr).
- The teeth grin is kept only for Spore Lords (B+), and their eyes get the glowing-iris treatment instead of googly whites.
- Growths stay ≥ 0.5 hr away from any eye.

---

## 3. Toon preview as the standard: verdict

**Yes, adopt it** as the standard for every contact sheet used to approve the look, from the next library rebuild on. The plain render stays as `--plain` for geometry debugging only. It is the first time our sheets look like the game we're making: outlines in local colour, violet-tinted shadows, a painted sky and a bright lawn. The buildings especially gain appeal. Tune before adoption (owner **technical-artist**; rules in style guide §3.1):
1. **Framing and scale (blocker):** frame the subject, not subject + figure (R1 above). Small creatures are unreadable today.
2. **Colour transform:** use `Standard`, not AgX/Filmic, so emissives keep their hue (B3 above).
3. **Glow strengths:** re-render the dark families with lamp 1.5, window 2.0 and ember 2.5. In the wave-1 toon renders Greymoor's `#BFFF8C` lanterns are white globes.
4. **Camera fit:** fit on the vertical field of view (see N2). Tall props are cropped today.
5. **Lawn colour:** the disc is a little more saturated than the in-game ground target `#8CC860`. Use `#8CC860` with a fade to `#A8D47A` at the rim, so green creatures (goblin, mandrake) keep their value contrast. The goblin is close to merging in `creatures_toon`.

---

## 4. The physical map: genre feel (owner **world-designer**)

**Verdict: yes, it reads as an anime-fantasy continent.** It has a snowbound northern wall that cuts the heartland off, a red-tinged demon land in the far north-west corner, a green heartland with the capital at the centre, a golden desert across the south, a jungle and mire in the south-west, a mountain sect and a shrine-island culture in the east, and a dwarf pass guarding the way north. That is the classic JRPG overworld promise: you can point at any corner and guess the adventure there. The parchment frame and hill-shading suit the diegetic map style (§8).

**Notes (S2–S3):**
1. **Mark Brindlewick.** The player's home town isn't on the map. Add a star and label at its anchor; it's the first thing a player looks for.
2. **Rivers look grid-stepped.** Rivers such as the Greymoor River east of Aldmere, the Bastion River and the Moraveil River have right-angle jags from the 0.5 km cell routing. Smooth the drawn paths with 2–3 Chaikin passes, and taper the width from 1 px at the source to 4 px at the mouth. Keep the data as it is.
3. **The coast is one smooth blob with two offshore isles.** Fantasy maps sell adventure through bays, capes, straits and archipelagos. The coast comes from the atlas, so any change is a Canon §6 proposal: for example, a named bay for Lirian's lagoon or a small archipelago off the south-east. Route it through **canon-keeper**.
4. **Lirian and Stormreach are landlocked** (findings 1–2). Lirian is our "family done right" reference (P3 in the 10-25 review), and its whole visual identity is canal and lagoon. I recommend **moving its anchor to the east coast** rather than rewriting it as a river lagoon. For Stormreach, keep the cliff-towns on mountain cliffs and let the lore say "cliffs above the Black Peaks' gorges". Both are Canon §6 decisions; canon-keeper puts them to the user.
5. **Naming:**
   - Three "-reach" names (Whitewater Reach, Stormreach, Heavenreach) blur together.
   - "Cinder Hills" is wrong for a range topping out at 3,101 m; suggest "Cinder Crags".
   - "Frontier Mountains" is generic, and the range barely exists (finding 3).
   - "The Overlord's mountain of fire" is a placeholder and needs a real name.
   - The existing canon name **Karak Dûn** uses a prefix ("Karak") that players strongly associate with another publisher's dwarf holds. That is a distinctiveness risk, not a copy, but this is the cheapest moment to change it.

   All of these go as **Canon §6 proposals via canon-keeper**. My recommendation is an original dwarf-tongue root for the hold.
6. **For the in-game version** (not this dev map): drop the subtitle with the seed, the grid numbers and the "*" proposal marks.

---

## 5. New problems and the two known items

| # | Sev | Problem (seen in) | Owner | Fix |
|---|---|---|---|---|
| N1 | S2 | **Confirmed:** the Iron Hold fountain water renders as an orange-tan pool (`before/iron_hold.png`, `b1_after/iron_hold.png`). It reads as molten metal or sand. The dwarven `glass` key is shared by windows and water | environment-artist | Add a separate `water` palette key to every family, default `#7FB3D0`. Iron Hold water `#5E8FA8` (dark, cool), so the fountain contrasts with the forge glow |
| N2 | S3 | **Confirmed:** lamp-post tops are cropped by the preview camera (`b1_after/iron_hold.png` coal basket, `hoshizora.png` lantern post, `gearholm.png` gas lamp) | environment-artist (`preview.camera`); technical-artist for `toon_preview` | `camera()` fits the bounds diagonal to the horizontal field of view (`fov = 2·atan(18/lens)`), but tiles are landscape, so tall objects overflow vertically. Fit on the vertical field of view, `2·atan(18·tile_h/tile_w / lens)`, or set `sensor_fit='VERTICAL'`, and keep margin 1.2 |
| N3 | S2 | Emissives lose their hue (Iron Hold cream, Umbravel windows white, Greymoor lanterns white in toon) | technical-artist | `Standard` view transform in preview scenes (B3 fix 1) |
| N4 | S2 | Loincloth reads as a flat board on goblin, werewolf and scarecrow | creature-artist | Shaped cloth (C5 fix) |
| N5 | S3 | `dark_families_toon.png` and `mushrooms_toon.png` show the wave-1 state, so they can't confirm B1, the glow strengths or the lantern colours | technical-artist | Re-render both after N3, from current `main` |
| N6 | S3 | Fanghold: small houses now carry 2–3 banners plus door and eave bands. That is close to the "every building the same three colours" don't | environment-artist | Cap `facade_banners` at 1 per facade, and none on buildings under 40 m² footprint (the yurts keep their pole banner) |
| N7 | S3 | The orc's palette is the same tan-with-spots as the rabbit (`creature_fixes/after.png`), so the two families blur | bestiary-designer (C2, still open from 10-25) | Orc skin olive `#7E8F4E` or grey-green, per C2's species-base-colour rule |

---

## 6. Owners at a glance

| Agent | Items |
|---|---|
| environment-artist | B1 (lamps, granaries, Hoshizora wall and fountain, nordic well-house), B3 (Umbravel warm lanterns, Iron Hold forge mouth), N1 (water key), N2 (`preview.camera` vertical fit), N6, the Aldmere banner gold (S3) |
| technical-artist | R1 and §3.1 (framing, figure silhouette, lawn colour), N3 (`Standard` view transform), N5 (re-renders), adopting the preview in sheet builders together with environment-artist and creature-artist |
| creature-artist | C1 (werewolf eyes, skull), C3 (wings, legs), C5 (loincloth, taper, ribcage, sword), mushroom faces |
| bestiary-designer | N7 (orc palette, under C2) |
| world-designer | Map notes 1, 2 and 6 |
| canon-keeper | Map notes 3, 4 and 5 as Canon §6 proposals for the user (coast features, Lirian anchor, Stormreach wording, "-reach" names, Cinder Hills, Karak Dûn) |

## 7. Next review
Re-check after the toon preview is adopted in the library builders, using a full creature sheet for beasts, goblinoids, dragons and plants_fungi plus a dark-family building sheet. Then return to the first-ten-minutes in-game review from 10-25 §3.
