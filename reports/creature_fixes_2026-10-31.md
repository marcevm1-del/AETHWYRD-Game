# Creature generator fixes from the design review (2026-10-31)

Follow-up to `reports/design_review_2026-10-25.md` (items C1, C3, C4, C5, C6), in `Tools/blender/ascend_creatures/`.

## Before and after
Both sheets use the same 12 species, colours (`palettes.js`, already on `main`), camera (yaw −35°) and detail (medium). They were rendered headless with Blender 5.2.3 using software OpenGL, so they're useful for shape and colour but are not final shading.
- `creature_fixes_2026-10-31/before.png`: the generator on `main`.
- `creature_fixes_2026-10-31/after.png`: this change.

Species, left to right and top to bottom: Blue Slime, Goblin, Horned Rabbit, Forest Wolf, Young Dragon, Skeleton, Werewolf, Orc Grunt, Mandrake, Walking Mushroom, Giant Crow, Smiling Scarecrow.

## What changed
| Review item | Fix | Where |
|---|---|---|
| C1 masks (S1, trade-dress risk) | A mask is drawn only when the species' look text or signature names one; the Smiling Scarecrow now shows its face. Every mask has a style (carved bone, painted wood with stripes, horned demon, metal visor), a brow ridge and glowing eye points. A plain oval is never drawn | `looks.py`, `features.mask` |
| C1 quadruped eyes | Size 0.24 → 0.30 (small 0.30 → 0.36) and spread 40/46° → 30/34°. The eyes also sit on the real skull surface (`eye_out`), because the metaball skull swells past `head_r` and buried them | `plans.quad`, `body.py` |
| C1 werewolf eyes | 20° → 12° up, above the muzzle | `plans.biped` |
| Colour | Belly = lighter body tone with 15% accent (was 45%, which turned werewolf chests purple) | `body.paint` |
| C3 dragons | Deep chest raised at the front, long rising S-neck, two main swept horns (2.1× head radius) under any crown, wingspan +17% | `plans.dragon`, `features.horns` |
| C4 slime face decal | A small round mouth instead of two bars | `features.mask` |
| C5 bipeds | Limbs taper, with a thigh and upper-arm swell; mitten hands with a thumb. Skeletons get an open ribcage of bone bars (the background shows through), goblins a loincloth, hobgoblins a pauldron, orcs a topknot | `plans.leg/arm/biped`, `features.ribcage/breaking_shapes` |
| C6 birds | Tapered two-tone beak, hooked for raptors (was a flat tube that read as a box). Standing birds fold their wings along the flanks; spread feather wings are one attached fan | `features.mouth/wings` |
| C6 plants | Spotted caps with gills for mushrooms, a leafy canopy for trees, petals for flowers, a leaf crown for the rest (mandrake). Matched on the name, because generic body wording ("mushroom-capped walking body") is shared by treants | `features.plant_crown` |

## Still open
- Mushroom faces sit under their new caps.
- The committed family contact sheets (`13_Production/screenshots/creatures/`) are from before this change. On your PC, rebuild them with `blender -b --factory-startup -P Tools/blender/build_creature_library.py` (about 45 minutes); that takes hours with this session's software rendering.
- R1 (toon-shaded previews with outlines and a scale figure) and the building items B1–B4 were not touched.
