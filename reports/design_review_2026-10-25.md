# Design Review: Buildings and Creatures, 2026-10-25

> **Reviewer:** anime-fantasy-director. **Rules:** `13_Production/art_direction.md` (v1, written alongside this review).
> **What I looked at (every image opened):**
> - Building contact sheets (15): whisperwood, aldmere, greymoor, mossdeep, lirian, fanghold, iron_hold, hoshizora, frostveil, sunscar, zarvan, gearholm, umbravel (+ cross-checked palettes in `Tools/blender/ascend_buildings/styles.py`).
> - Creature contact sheets (14): beasts, slimes, goblinoids, dragons, undead, lycanthropes, aquatic, demons, plants_fungi, yokai_inspired_spirits, familiars_gentle_creatures, avians, orcs_ogres_giants, elementals_spirits (+ the generator code in `Tools/blender/ascend_creatures/` and recipe statistics from `Data/Monsters/species.json`).
> - In-game: `13_Production/screenshots/ring0_graybox.png`, `brindlewick_aerial.png`, `whisperwood_field.png`, and the current build's `reports/baseline_2026-10-25/01_plaza.png` and `07_whisperwood_field.png`.
> - Not opened this pass: the other 35 building sheets and 17 creature sheets. Findings below are only about what I opened.
>
> **Caveat on the sheets:** the Blender contact sheets are rendered without `Ascend/Toon` or outlines, under flat grey-green light. They undersell the colour and hide the line work. I judge shape, proportion, palette and identity from them, not the final shading.

---

## Verdict in one paragraph

The **building system is the strongest art asset in the project**: the families have real identity, roofs are storybook-steep, and Lirian, Mossdeep, Hoshizora, Frostveil and Zarvan already feel like places from an anime. The **creature system is not yet on genre**: the slimes are charming, but most other families read as smooth clay mannequins in a dozen shared palettes, with faces hidden or missing, wrong parts (antlers on wolves) and dragons that read as winged dogs. The in-game first ten minutes still look like a graybox. Priority order: **fix creature faces, palettes and the Ring 0 cast first** (the player meets them in minute 3), then restyle shared building props, then dress Whisperwood.

---

## 1. What works and must be protected

| # | Asset | Why it works | Protect by |
|---|---|---|---|
| P1 | **Storybook roofs** (Whisperwood, Aldmere) | 50–55° roofs, turrets with witch-hat cones, flower boxes and shutters are exactly the isekai village read | Keep `pitch=54`, turrets and `flower_boxes` as family defaults |
| P2 | **Mossdeep toadstools** | Instantly cute and region-unique; circle language, red/brown/violet caps with white spots | Keep the remap list; extend it (see B2) rather than diluting it |
| P3 | **Lirian** | The most cohesive set: pastel stucco, quoins, terracotta, green shutters, striped mooring poles. Reads "canal city" with no water in frame | Use Lirian as the reference for "a family done right" |
| P4 | **Hoshizora pagoda, torii and curved roofs** | Strong upturned eaves and raised ridges; silhouettes read at 100 m | Keep `curve=0.6`, `overhang=0.9` |
| P5 | **Frostveil longhouses** | Snow-capped long roofs, red shutters and dragon-board gables; a single accent used well | Keep red as the only accent |
| P6 | **Fanghold yurts, Zarvan turquoise** | Strong single-shape signatures | Keep, but see B2/B3 on overuse |
| P7 | **Slimes** | Dome-and-skirt silhouette, glossy gel, big dot eyes with highlights: the right "first monster" appeal | Keep the dot-eye style and skirt; fix only the decal and crown (C4) |
| P8 | **Generator architecture** | One archetype × 21 families × 48 regions; one species recipe × 25 plans. This is how a 2-person team ships 680 monsters | All fixes below are parameter or rule changes, not rewrites |
| P9 | **Toon shader defaults** | Violet shadow tint (0.58, 0.56, 0.78), soft cream rim, warm lamps: on-genre | Keep; tune per §3 of the style guide |

---

## 2. Top problems, ranked

Severity: **S1** blocks the genre read in the first hour; **S2** hurts appeal or consistency across a region; **S3** polish.

### C1 (S1) Creatures have no faces, or the faces are hidden. Owner: **creature-artist** (with bestiary-designer for data)
- **Seen:** goblinoids rows 3–4, all undead mid-tier, orcs row 1, demons, elementals, yokai ghosts: a flat white oval `mask` over a dark tube body. Lycanthropes and ogres show no readable eyes at all. Quadrupeds' eyes are invisible from the 3/4 camera.
- **Why it hurts:** anime monster appeal lives in the eyes. Faceless mannequins read as placeholder or as horror, not fantasy. Worse, **a plain white oval mask with two dark holes on a dark hooded body reads as a very famous character from another studio's film** (yokai sheet row 1, elementals row 1, undead rows 3–5). That is a trade-dress risk for a commercial game.
- **Fix:**
  1. `features.py` mask: only render when the species' `look` text mentions a mask; make every mask species-specific (carved bone with brow ridge, painted wood with a motif, horned noh-style demon face, a metal visor) and put **glowing eye points** (`glow`, r = 0.12·hr) in the holes. Never a plain bone oval on a dark shroud.
  2. Quadrupeds (`plans.py` `quad`): `eye_size` 0.24 → **0.30** (large) and 0.30 → **0.36** (small); `eye_spread` 40/46° → **30/34°**; `eye_up` 15° → **6°**. Today the 40–46° spread puts the eyes on the sides of the skull, so they vanish in 3/4 view.
  3. Large bipeds: add a brow ridge and keep `eye_size` 0.22 but use a bright iris (`glow` for B+). Lycanthropes: `eye_up` 20° → 12° so the eyes sit above the muzzle, not on the forehead.
  4. bestiary-designer: audit the 66 `mask` + 25 `face_decal` recipes; drop `mask` where the look text doesn't call for it.

### C2 (S1) The palette system collapses 680 species into ~12 shared palettes; the starter monsters are grey. Owner: **bestiary-designer** (`Tools/monster_gen`), with creature-artist
- **Seen:** `species.json` palettes: 111 species use the same navy/plum `#2d2a4a,#6b5b95,#0d0d14`, 96 the same brown, 79 the same pale yellow, 52 the same grey `#8a8f98`. The Ring 0 **Goblin, Goblin Archer, Horned Rabbit and Forest Wolf are all grey `#8a8f98`**. Undead, demons and shadows are a sea of near-black navy; lycanthropes are purple and green; aquatic is one glossy blue.
- **Why it hurts:** colour is assigned by element, not by species or habitat. Families blur together, dark-on-dark loses the value contrast rule, and the first fight (goblin, rabbit) looks like a grey placeholder instead of the classic green goblin and brown rabbit players expect.
- **Fix:**
  1. Palette = **species base colour (natural/folk read) + element as the 10% accent only**. Seed per family, jitter hue ±12° and value ±10% per species so siblings differ.
  2. Ring 0–1 cast, explicit: Goblin skin `#6FAE45`, cloth `#8A5A35`, accent tin helmet `#B8BEC6`; Horned Rabbit `#A8774E` with cream belly `#F0E0C0` and ivory horn; Forest Wolf grey-green `#7E8C78` with cream ruff (as its own look text says, "grey-green coat that blends with ferns"); Blue Slime stays `#2F7FD1`.
  3. Darkest body value V ≥ 25% for any species (undead navy lifts from `#2d2a4a` to `#4A4570`, glow accents carry the menace).
  4. Lycanthropes: natural fur only (grey, brown, black-brown, snow); element shows as eye glow and markings.

### C3 (S1) Dragons read as winged dogs. Owner: **creature-artist**
- **Seen:** dragons sheet, all 29: short neck, dog head, no horn crown, small kite wings, legs like a hound. The family the genre most expects to be majestic is the weakest.
- **Fix (dragon / wyvern plans):** neck length ≥ 1.2× head-to-shoulder with an S-curve; head wedge with a swept-back **horn crown** (2 main horns ≥ 0.8× head length); deep chest, front raised so the back slopes down to the hips; **wingspan ≥ 2.2× body length**, with 3–4 finger bones and a scalloped membrane; tail ≥ body length, tapering to a spade or spike. Hatchlings stay chibi (head 35%, stubby wings) but keep the horn nubs. Check: in silhouette at 64 px it must not be confusable with a wolf.

### C4 (S2) Wrong parts and noise. Owner: **bestiary-designer** (data), creature-artist (defaults)
- **Seen:** 21 of 45 beasts carry `antlers`/`horns` (Forest Wolf has antlers; bears and cats wear antlers). Horns on the gentle familiars (bunnies, axolotls). **26 of 43 slimes carry `crown_slot`**, so the crown no longer signals a king. Slime `face_decal` renders as a black vertical bar and a grey plate on the cheek: reads as a glitch. Small pink petal-like growths scatter across many variants (goblins, ogres, undead) as visual noise. 115 species carry the same thin grey sword via `weapon_socket` (kappa with sword and shield, every lycanthrope).
- **Fix:** antlers only on deer/elk/stag species; horns only where the name or look says so; no horns or teeth on Familiars & Gentle Creatures. `crown_slot` only on King/Queen/Monarch names. Replace slime `face_decal` with a small "ω" or "o" mouth (0.12·hr). Pink growths only on species with a plant or blossom element. `weapon_socket` only where the look text names a weapon, with per-class weapon sizes (style guide §7.6).

### C5 (S2) Bipeds are one tube mannequin. Owner: **creature-artist**
- **Seen:** goblinoids, undead, orcs row 1, demons, humanoid enemies, lycanthropes: identical round limbs of constant thickness, no hands, no costume, no breaking shapes; skeletons read as navy bodies with grey stripes.
- **Fix:** taper every limb chain (upper ≥ 1.3× lower radius), add hands as mitten + thumb (0.9× forearm radius), and give each family **one breaking shape** on the silhouette: goblin ears and a loincloth flap, hobgoblin pauldron, orc tusks and topknot, skeleton open ribcage with the background visible through it (thin bars, not stripes on a solid torso), demon horns and wings. Medium monsters at 5–6 heads per the style guide §5.

### C6 (S2) Plants are cactus stumps; avians have boxy beaks and floating feathers. Owner: **creature-artist**
- **Seen:** plants_fungi: 20 of 25 are green trunks with stub arms; no leaves, petals or caps. Mandrake and Walking Mushroom should be among the cutest F-rank monsters. Avians: the beak renders as a box (reads as goggles), and the wing feathers float as detached dashes.
- **Fix:** plant plans must add a crown: a cap (mushrooms), a leaf fan of 5–7 leaves (mandrake), petals (flower monsters), a bulb (pod). Avian beak = tapered lathe (length 0.6·hr, two-tone), feathers attached in an overlapping fan with the first 3 primaries longest.

### B1 (S2) Shared props ignore the region. Owner: **environment-artist**
- **Seen:** on all 13 building sheets, the **market stall (red canopy), iron lamp post, tiered stone fountain, stone bridge and crenellated stone wall** are identical regardless of family (Iron Hold, Sunscar and Hoshizora all get the same European stall). The **sail windmill** appears in Iron Hold, Frostveil, Sunscar, Zarvan, Gearholm and Umbravel. The **round cone-roofed granary tower** is European in Hoshizora and Sunscar.
- **Fix:** route these archetypes through the family: stall canopy uses `cloth_a`, posts use `trim`; lamp post per family (paper lantern on a wooden post for Hoshizora/Shen-Lu/Haneul, brass gas lamp for Gearholm, iron basket of forge-coal for Iron Hold, silk lantern for Umbravel, green fen lamp on a pole for Greymoor); wall uses the family wall construction (adobe in Sunscar, log palisade in Frostveil, turquoise-banded brick in Zarvan); fountain basin in family stone. Remap `mill` → none or a family form (desert: wind-catcher tower; nordic: watermill; dwarven: water-wheel forge). Granary in Hoshizora → a raised kura storehouse.

### B2 (S2) Signatures are overused or missing. Owner: **environment-artist**
- **Seen:** Sunscar puts a white dome on **every** building, including the stable and smithy; Zarvan puts an onion dome on every building, including the stable. Mossdeep's non-remapped types (smithy, barn, gatehouse, wall) fall back to blank white boxes with portholes, the weakest objects on that sheet.
- **Fix:** domes/onions on temple, guild hall, town hall, bathhouse and library only (≤ 1 in 4 buildings). Mossdeep: remap `smithy`, `barn`, `stable`, `gatehouse`, `wall_segment` to toadstool or leaf-thatch variants (a toadstool forge with a stone chimney, a gate made of two toadstool towers, a hedge or root wall).

### B3 (S2) Dark and earthy families go monochrome. Owner: **environment-artist** (palettes), technical-artist (emission)
- **Seen:** Iron Hold is basalt-grey on basalt-grey with pin-dot rune lights; Umbravel is uniform grey-violet; Greymoor is grey boards under grey-green thatch; Fanghold's stone houses are grey with brown plank roofs and one tiny banner.
- **Fix (palette numbers in `styles.py`):**
  - Iron Hold: keep basalt but make bronze trim bands 2× wider; `roof_b` copper on 1 in 3 roofs; door and window glow emission ≥ 2.5 with orange `#FF8C26` light spilling onto the ground; forge chimney with an ember cap.
  - Umbravel: stone `#4C4557` → `#5A5068`; window glow emission 2.0; add the warm silk lanterns (already in the region overrides) on every facade.
  - Greymoor: `wall_c` lift to `#8A7A62`, more lanterns (2 per house) at `#BFFF8C` emission 2.0; one painted door colour (`#4F7A6A`) as the village accent.
  - Fanghold: felt and cloth bands in `cloth_a` red and `cloth_b` blue on every building (door frames, eave bands), banners 2× bigger, stone `#A89980` → `#B8A58A`.

### B4 (S3) Whisperwood and Aldmere are near-identical. Owner: **environment-artist**
- **Seen:** the two sheets differ only in roof colour order.
- **Fix:** Whisperwood (forest village): more timber and moss, `thatch` on 1 in 3 roofs, lanterns and ivy, warmer plaster. Aldmere (the royal valley): stone ground floors (`ground_walls="ashlar"`), slate roofs dominant, royal blue `#3357AD` and gold banners, finials on civic buildings.

### R1 (S2) Contact sheets can't be used to approve the look. Owner: **technical-artist** (with environment-artist and creature-artist)
- **Seen:** every sheet is rendered in flat light without outlines; creature sheets show ground discs that are too small (the camera frames past their edge into a grey-blue band, e.g. dragons row 4, aquatic row 4).
- **Fix:** a toon preview in Blender (Shader-to-RGB two-tone with the `Ascend/Toon` shadow tint, Freestyle or inverted-hull outline at 1.5 px), a painted-sky world colour, and a ground disc sized to 3× the creature's bounds. Add a 1.7 m human silhouette in each creature cell so scale is visible.

### W1 (S1) The first ten minutes in-game. Owner: **world-builder-engineer** (placement), environment-artist (assets), technical-artist (shader), ui-engineer / ux-designer (HUD), creature-artist (Ring 0 exports)
See section 3.

---

## 3. "First 10 minutes" look-and-feel verdict: Brindlewick → Whisperwood

*As a new player would see it, from `ring0_graybox.png`, `brindlewick_aerial.png`, `whisperwood_field.png` and today's `baseline_2026-10-25/01_plaza.png` and `07_whisperwood_field.png`.*

**Minute 0–3, Brindlewick plaza. Verdict: promising layout, graybox look.**
The layout is right: a round cobbled plaza with a fountain, a gate framed by blue witch-hat towers on the north axis, market stalls, a windmill and half-timber houses around the square. The aerial shot already has the bones of a cosy isekai starter town. But the frame the player actually sees is a capsule in the centre of the screen, a flat warm-beige plaza with tile shapes and **no outlines**, grey untextured blocks on the left, a palisade, and white floating text labels too small to read. Nothing moves; no NPC is visible in the plaza; the clock tower (the planned skyline anchor) isn't in view from the spawn. The low camera looks into the ground, so 60% of the screen is paving.
- Raise the spawn camera so the horizon sits at 40% from the top and the gate and clock tower are both in frame (world-builder-engineer).
- Put the new storybook buildings and `Ascend/Toon` outlines on everything in the first view, including the ground and trees (technical-artist).
- 3–5 ambient NPCs and one moving thing (banner, bunting, birds) in the opening frame (world-builder-engineer, animator-rigger).

**Minute 3–10, through the gate into Whisperwood. Verdict: reads as a park, not a forest; monsters are specks.**
Lollipop sphere trees on a single flat dark green with no path, undergrowth, light shafts or landmarks other than a small arch at the far end. Ground and canopy share the same dark value, so the frame is one green block. Monsters at 20–40 m are 10–20 px dots with labels; the green goblins disappear into the green ground (exactly the contrast rule in the style guide §7.2). Lantern Moths read well thanks to their yellow and the label.
- Trees: 3–5-lobe clumps with lighter tops, varied heights (6–14 m), clearings of light (environment-artist).
- Ground: a visible dirt path `#C9A66B` from the gate to the ruins, lit grass `#8CC860` in clearings, grass cards near the camera, flower clusters (environment-artist, world-builder-engineer).
- One landmark visible from the gate: a giant old oak or the ruined arch raised on a rise (world-designer, world-builder-engineer).
- Ring 0 monsters swapped to the baked generator models with C1/C2 fixes (warm, faced, readable at 47 px) (creature-artist).

**HUD. Verdict: functional placeholder, not yet a "System window".** Thin text over the sky with no backing, IMGUI boxes for skills, nameplates overlapping each other. Apply style guide §8 (navy glass panel, cyan line, ≥ 18 px body text, backing plates) (ux-designer spec, ui-engineer build). Also noticed: the baseline shots show **HP 1/162** at spawn; if that isn't a deliberate test state, gameplay-engineer / qa-tester should check it.

**Overall:** the structure of a warm first hour is there (town, gate, training wood, first quest "Slime in the Well"), but nothing on screen yet says "anime". The single biggest jump would come from three things together: toon shader + outlines on every object in the first view, the generator buildings placed in Brindlewick, and faced, colourful Ring 0 monsters.

---

## 4. Owners at a glance

| Agent | Items |
|---|---|
| creature-artist | C1 (mask, eyes), C3 (dragons), C5 (biped shapes), C6 (plants, avians), Ring 0 exports with the fixes |
| bestiary-designer | C2 (palette generation, Ring 0 colours), C1.4 and C4 (recipe parts: antlers, horns, crowns, masks, weapons) |
| environment-artist | B1 (shared props), B2 (signature overuse, Mossdeep remaps), B3 (dark-family palettes), B4 (Whisperwood vs Aldmere), Whisperwood trees and ground |
| technical-artist | R1 (toon preview renders), outline colour = local colour × 0.35, creature rim 0.35, B3 emission values |
| world-builder-engineer | Spawn camera framing, placing generator buildings, path and landmark in Whisperwood, ambient NPCs |
| ux-designer, ui-engineer | System window styling (style guide §8) |
| gameplay-engineer, qa-tester | Confirm whether HP 1/162 at spawn is intended |
| canon-keeper | No canon change needed. Note only: the style guide's palette rules restate, not change, the Canon §1 art pillar |

## 5. Next review
After the Ring 0 creature exports and the first Brindlewick placement with toon shading: re-shoot the plaza and field from the same positions and re-check the first-10-minutes verdict.
