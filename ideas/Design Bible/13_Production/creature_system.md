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
- **Coverage.** The rarer body plans (aberrations, swarms, cephalopods, plants) are simpler than the quadrupeds and bipeds. The giants (Behemoth Ascendant, Hive Mother) are modelled at their true size, up to 2 km.
