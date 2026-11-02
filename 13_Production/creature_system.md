# Creature System (Blender)

> **Built (Blender only for now).** A procedural, high-poly creature generator for all **680 species** in `Data/Monsters/species.json`. Code: `Tools/blender/ascend_creatures/` (a Blender add-on). Libraries: `Art/Blender/CreatureLibrary/<family>.blend` (generated, not in git). Contact sheets: `13_Production/screenshots/creatures/<family>.png`. It follows the same pattern as [[building_system]]; the earlier low-poly blockouts (`Tools/blender/bestiary_models.py`) and the Unity models are unchanged.

## What it makes

- **Sculpted bodies.** Bodies are metaballs: smooth-unioned balls, ellipsoids, rounded blocks and tapered chains. They melt together like a clay maquette, close to the hand-sculpted stylised look of the Tripo showcase models.
  - The surface is polygonised on a fine grid (0.75 cm at 1 m), relaxed, given a little surface noise for rough hides and bark, and painted per vertex.
  - **Painting:** lighter bellies, darker backs, the species pattern (spots, stripes, Voronoi scales, rings, patches), darkened creases and glowing cracks for emissive hides.
  - A typical creature is 40k–250k triangles.
- **Crisp parts.** Eyes, teeth, horns, claws, armour, cloth, weapons and wings are separate bevelled meshes: anime eyes with iris, pupil and two sparkles, horns and antlers swept along curves, claws, plates, cloaks with ragged hems, masks, crowns, cores, crystal and stone growths.
- **True to the bestiary.** Every species is built from its own `designRecipe`:
  - **body plan:** one of 25 plans, taken from `baseMesh`
  - **parts:** about 110 parts in the vocabulary
  - **surface style:** 31 material styles
  - **palette**, **menace style** and **size:** the species' real `sizeMeters`
  - **eye style:** from its `look` text (dot, beady, slit, glowing)
- **Distinct silhouettes.** Profiles read the species' name and description, using the base species for variants:
  - **Quadrupeds:** a boar is low and heavy with a long snout. An elk is all legs and neck. A bear is massive; a sabretooth has a short muzzle and a long tail; a salamander sprawls. Cerberus has three heads, the Nine-Tailed Vixen nine tails, griffons have beaks and wings, a tortoise has a shell and a sheep has wool.
  - **Bipeds:** skeletons are thin with ribcages, zombies hunch, and werewolves, lizardmen, gnolls and minotaurs get muzzles and tails. Orcs are heavy with tusks, and trolls are long-armed with hooked noses.
- **Variants.** The 353 variants keep their base species' silhouette and gain a treatment:
  - **Elder and Ancient:** bulk, scars, armour, moss and stone.
  - **Phantom:** see-through, lit from within, trailing wisps.
  - **Vesper-Touched:** red glowing cracks and red crystal.
  - **Elemental:** element growths such as embers, ice crystals, stone, moss, spores, fins and wisps.

## Design review fixes (2026-10-31)

From `reports/design_review_2026-10-25.md`, checked with before/after renders:
- **Faces (C1):** a mask only where the species' look text or signature names one. Every mask has a style: carved bone, painted wood with stripes, a horned demon face or a metal visor. Each also has a brow ridge and glowing eye points, never a plain oval. Quadruped eyes are bigger (0.30, small 0.36), set forward (30/34°) and sit on the real skull surface (`eye_out`). Werewolf eyes sit above the muzzle.
- **Colour:** the belly is a lighter body tone with only 15% accent (it was 45%, which turned werewolf chests purple). Species palettes come from `Tools/monster_gen/palettes.js`.
- **Dragons (C3):** a deep chest raised at the front and a long rising S-neck. Two main swept horns (2.1× head radius) under any crown, and a wider wingspan.
- **Birds and plants (C6):**
  - **Birds:** a tapered two-tone beak (hooked for raptors) and wings folded along the flanks as overlapping feathers.
  - **Spread feather wings:** one attached fan.
  - **Plants:** mushrooms get a spotted cap with gills, trees a leafy canopy, flower monsters petals, and the rest a leaf crown.
  - **Mushroom faces (rule):** a mushroom's face must read from the preview camera (yaw -35, pitch 14). The cap rim sits above the brow (head + 0.95 head radii) and reaches no further than 2.3 head radii, so the line of sight from the eyes passes under it. Mushrooms have a rounder head ball, eyes snapped onto the real skull surface (`eye_snap`, `features.surface_hit`), no moss or pods on the face, and the metaball `cap` blob is skipped (it swallowed the face). Cute ones (soft or animal menace) get big low eyes (0.38, 22 degrees) and a small open smile (`features.mushroom_mouth`); the spore lords keep their teeth. Mushrooms are matched on the name (`plans.is_mushroom`), so treants, flowers and the Mandrake are untouched.
- **Slime face decal (C4):** now a small round mouth.

## Design review fixes (2026-11-02)

From `reports/design_review_2026-10-31.md` (C1, C3, C5, mushroom faces, N4), with before/after sheets in `reports/blender_wave_2026-11-02/creatures/`:
- **Werewolf eyes (C1):** `eye_size` 0.26, snapped onto the real skull surface (they were buried in the metaball swell), a glowing amber iris `#FFB347` in a narrowed dark almond with a slit pupil (`eye_style` `glow_iris`), under a brow ridge 0.15 hr deep (`body.brow`).
- **Skull (C1):** skeletons (`plans.skull`) get a cranium, a narrower upper face, cheekbones and carved sockets. `features.skull_parts` adds dark sockets (r 0.22 hr, `#2A2238`) with a glow point (r 0.12 hr), a separate jaw 0.05 hr under the upper face and square teeth. No nose, no lids, bone `#E8DFC8`.
- **Dragons and wyverns (C3):** the wings span ≥ 2.2× the nose-to-tail length (`wing_span` 2.5 / 2.4) with thicker finger bones and deeper scallops. Hind legs are digitigrade (hip, knee forward, hock, toes) with thighs 1.4× the forelimb radius, and the shoulders sit at 0.8× the hip height, so the back slopes. The tail (about 1.1 units) is longer than the torso (0.74) and ends in a flat spade (`features.dragon_spade`, which replaces `tail_blade` on dragons). Wyverns, the Gargoyle and the Arch Demon share the wyvern plan.
- **Bipeds (C5):** `leg`/`arm(taper=True)` swell the thigh and upper arm to 1.15 r0 and thin the ankle and wrist to 0.72 r1. The loincloth (`features.loincloth`) is a curved trapezoid (top 0.8× hip width, bottom 0.55×, 0.35× leg long) in two segments with a 10° flare, folds, a back flap, a waist cord, cloth `#8A5A35` and a 0.03 m darker hem. Skeleton ribs: five thin sloping bars with wide gaps and a short sternum. The sword blade is at least 7 cm wide (`Ctx.metres` turns real-world sizes into model units).
- **Mushroom faces:** F–E mushrooms get dot eyes (0.36, 24°, `eye_up` 0) and a tiny "o" mouth (0.12 hr). There are no teeth, and the painted spots stay off the face. Spore Lords (matched on the name) keep the teeth grin and get glowing irises. Growths of every species keep their edge ≥ 0.5 hr from any eye's edge.

## Using it in Blender

1. **Install.** Zip `Tools/blender/ascend_creatures` and install it like the buildings add-on. `ascend_buildings` must be installed too, because the creatures reuse its mesh helpers.
2. **Add a creature.** *Sidebar ▸ Ascend ▸ Ascend Creatures*: pick a species and click **Add Creature**.
3. **Adjust.** With a creature selected, change its seed, size, element, pattern, detail or its three colours; it rebuilds live. **Reroll** tries the next seed.
4. **Use the libraries.** Add `Art/Blender/CreatureLibrary` as an asset library. Catalogs are *Ascend Creatures ▸ Family*; tags cover element, rank, body plan and tier.

**From Python:** `generate.creature("mon_goblin", seed=2, overrides={"element": "Fire", "palette": ["#c0392b", "#5b1f1a", "#ffb347"], "size": 1.4})`.

**Rebuilding the libraries:** about 45 minutes for all 680 species.
```bash
blender -b --factory-startup -P Tools/blender/build_creature_library.py
```
Add `-- --families Slimes,Beasts` or `-- --ids mon_goblin` to build a subset.

## Modules

| Module | Job |
|---|---|
| `body.py` | Metaball body, tessellation, relax, creases, painting, skin material |
| `plans.py` | The 25 body plans |
| `profile.py` | Species silhouettes and variant treatments |
| `looks.py` | Palette, surface style, pattern, eye style |
| `features.py` | Soft parts as metaballs, hard parts as meshes |
| `generate.py` | The API |
| `__init__.py` | The add-on panel |

## Not done yet

- **Rigs and poses.** These are static T- and A-poses; `Data/Monsters/rigs.json` and `Tools/blender/build_rig.py` would be the next step.
- **Unity.** These are high-poly sources, not game meshes. Going into Unity needs a baked low-poly with normal maps, a rig and LODs.
- **Description detail.** Some recipe parts don't fit their animal (the data gives the Forest Wolf antlers). The generator follows the data; fix it in `species.json`.
- **Still open:** at sheet size the bigger wings make a dragon's body small in its tile, and all four dragon species share one silhouette.
- **Coverage.** The rarer body plans (aberrations, swarms, cephalopods, plants) are simpler than the quadrupeds and bipeds. The giants (Behemoth Ascendant, Hive Mother) are modelled at their true size, up to 2 km.
