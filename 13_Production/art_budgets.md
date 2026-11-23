# Art Budgets (60 fps on a GTX 1650)

> **Set 2026-10-25 (technical-artist).** Triangle, material-slot and texture budgets for buildings, creatures and props, the per-scene totals they add up to, and the LOD targets and switch distances. The bake script that enforces them is `Tools/blender/bake_to_game.py`. Its outputs go to `Art/Blender/GameReady/<kind>/<id>_LOD{0,1,2}.fbx` plus `_COL.fbx`, and its numbers go to `Art/Blender/GameReady/report.json`. Sources: [[building_system]] and [[creature_system]]. The first measured run (Ring 0) is at the bottom.

## The target and what it costs

- **Hardware floor:** GTX 1650 (4 GB, about 3 TFLOPS, 128 GB/s), 1920×1080, 60 fps. That leaves a 16.6 ms frame, of which art gets about 8 ms on the GPU. The rest goes to post-processing, UI and headroom.
- **Each visible triangle is drawn three or four times:**
  - the `ToonForward` pass
  - the inverted-hull `Outline` pass (`Ascend/Toon` draws every mesh a second time, pushed out along the smoothed normal)
  - `ShadowCaster` (URP: one cascade, 60 m)
  - `DepthOnly`/`DepthNormals` when depth priming or SSAO is on
- **So the budget is set on visible LOD-weighted triangles, not on scene totals.** Keep at most **about 1.0 M triangles in the main view** (about 3.5–4 M vertex invocations across all passes) and **about 0.6 M in shadow casters**. The 1650 handles that comfortably, so the limit that actually bites is draw calls.
- **Draw calls:** every material slot on a renderer costs one draw per pass, so about 3–4 draws per slot.
  - **Ceiling:** at most **1,500 draws per frame** across all passes, and at most **150 SetPass calls**.
  - **Batching:** the SRP Batcher handles shared `Ascend/Toon` materials well; GPU instancing covers repeated props and vegetation.
  - **Why slots matter:** they are the number to watch. A street of 40 houses at 8 slots each is 40 × 8 × 3.5 ≈ 1,100 draws on its own.
- **Texture memory:** keep at most **1.2 GB resident** of the 4 GB. That leaves room for render targets (about 250 MB at 1080p, including the 2048² shadow map), mesh buffers and the driver.

## Buildings

Size class by archetype (the bake script's `BUILDING_CLASS`): **small** = well, lamp post, market stall, shrine, fountain, tent, torii, wall segment. **Medium** = cottage, house, townhouse, shop, smithy, stable, granary, stilt house, yurt, toadstool house/shop, tree house, adobe tower, longhouse, bridge, paifang. **Large** = inn, tavern, manor, barn, warehouse, mill, library, bathhouse, barracks, longhouse hall, temple, large yurt/tent, toadstool tower/cluster, watchtower, gatehouse. **Landmark** = guild hall, town hall, pagoda, lighthouse, stepped pyramid, domed hall.

| Class | LOD0 | LOD1 | LOD2 | Slots now (target) | Normal map (optional) | Collider |
|---|---|---|---|---|---|---|
| Small (~3 m) | 1,500 | 600 | 200 | 4 (1) | none | convex hull, at most 250 tris |
| Medium (~8 m) | 8,000 | 3,000 | 1,000 | 8 (1–2) | 1024² BC5, 1.4 MB | convex hull, at most 250 tris |
| Large (~12 m) | 15,000 | 6,000 | 2,000 | 10 (2) | 1024² BC5 | convex hull or 2–4 boxes |
| Landmark (~20 m+) | 30,000 | 12,000 | 4,000 | 12 (2–3) | 2048² BC5, 5.3 MB | compound boxes |

**Why these numbers:**
- **Medium, 8k:** a village view shows about 15 buildings near the camera and 25 further out. With mixed LODs that is about 15 × 8k + 25 × 2k ≈ 170k triangles, about a sixth of the frame, leaving room for vegetation and characters.
- **What 8k buys:** a cottage at 8k keeps its timber frame, window recesses, shutters, door, chimney and the roof's eaves as real geometry (see the sheet). Below about 5k the frame turns into colour patches.
- **Large and landmark:** they get double and four times as much because they are seen from further away and there are only one or two per view.
- **Each LOD is about 0.35–0.4× the one before.** Unity's LODGroup cross-fades between them, and that ratio keeps the screen-space edge length roughly constant across each switch.
- **Slots:**
  - **Now:** the `Ascend/Toon` shader has one flat `_BaseColor` per material, so the colour has to live in the slots, and the "slots now" column is the interim cap that the bake script enforces.
  - **Target:** the bake also writes every face's exact flat colour into the vertex colour `Col`. Once the toon shader reads albedo from it, every building drops to one opaque slot plus one emissive slot for lamps and runes, about 3–4 draws per building (see "Next steps").
- **Normal maps:** the cel look reads silhouettes and flat colour, not micro-relief, so these are optional. Where used, they mostly carry the tile, stone and plank rhythm that the voxel shell smooths away.

## Creatures

Role (the bake script's `creature_class`, from `Data/Monsters/species.json`):
- **giant:** `sizeMeters` ≥ 8
- **boss:** `bossHpMult` > 1 or `isUnique`
- **elite:** `elder` or `ancient` variants
- **trash:** everything else; *small trash* is under 0.8 m

| Role | LOD0 | LOD1 | LOD2 | Slots now (target) | Albedo if baked | Collider |
|---|---|---|---|---|---|---|
| Trash, small (<0.8 m) | 3,000 | 1,200 | 400 | 6 (1) | 512², 0.35 MB | convex hull, at most 96 tris (hit boxes come from the rig) |
| Trash | 6,000 | 2,400 | 800 | 6 (1) | 512² | same |
| Elite | 10,000 | 4,000 | 1,200 | 8 (1–2) | 1024², 1.4 MB | same |
| Boss | 25,000 | 10,000 | 3,000 | 10 (2) | 2048², 5.3 MB | same plus rig hurtboxes |
| Giant (≥8 m) | 40,000 | 15,000 | 5,000 | 10 (2) | 2048² | compound, per body part |

**Why these numbers:**
- **Trash LOD0:** a pack fight puts up to 10 trash and 1–2 elites on screen, plus the party.
  - The arithmetic: 10 × 6k + 2 × 10k ≈ 80k triangles before LOD, under a tenth of the frame.
  - Skinned meshes also pay GPU skinning per vertex, which is why trash stays well under the earlier generated-model caps in [[monster_model_pipeline]] (6k below 0.6 m, 12k below 2.5 m). Those caps were for single showcase models.
- **What 6k buys:** a goblin keeps its ears, brow, iris and pupil, teeth, sword guard and pouch.
- **Bosses and giants:** they are alone and fill the screen, so they get 25–40k.
- **Slots:** the painted skin is one slot, which is already vertex-coloured. Eyes, teeth, claws, gear and armour take the rest.

## Props

| Class | Examples | LOD0 | LOD1 | LOD2 | Slots |
|---|---|---|---|---|---|
| Tiny | cup, book, bottle, coin pile | 50–300 | none (cull at 25 m) | none | 1 |
| Small | crate, barrel, bush, sign, fence segment | 300–1,200 | 40% | none (cull at 60 m) | 1–2 |
| Medium | cart, market table, well bucket rig, rock cluster | 1,500–5,000 | 40% | 15% | 2 |
| Large | tree, wagon, statue | 5,000–10,000 | 35% | billboard impostor (trees) or 10% | 2 |

Props are where instancing pays: they share one palette material per pack and are GPU-instanced. Grass and ground cover are instanced shader geometry and are budgeted under vegetation, not here.

## LOD switch distances

These assume a 55° vertical field of view (the Whisperwood camera). Unity's `LODGroup` switches on screen-relative height: **h = size / (2 · d · tan(27.5°)) ≈ size / (1.04 · d)**. Enter the h values in the LODGroup; the distances are what they mean at LOD Bias 1.

| Class | Size used | LOD0→1 | LOD1→2 | Cull |
|---|---|---|---|---|
| Building, small | 3 m | 20 m (h 0.144) | 50 m (0.058) | 120 m (0.024) |
| Building, medium | 8 m | 30 m (0.256) | 80 m (0.096) | 250 m (0.031) |
| Building, large | 12 m | 40 m (0.288) | 100 m (0.115) | 350 m (0.033) |
| Building, landmark | 20 m | 60 m (0.320) | 150 m (0.128) | never (LOD2 to the far plane; 0.010) |
| Creature, small trash | 0.4 m | 8 m (0.048) | 20 m (0.019) | 45 m (0.0085) |
| Creature, trash | 1.0 m | 12 m (0.080) | 30 m (0.032) | 70 m (0.0137) |
| Creature, elite | 2 m | 20 m (0.096) | 45 m (0.043) | 120 m (0.016) |
| Creature, boss | 4 m | 35 m (0.110) | 80 m (0.048) | 200 m (0.019) |
| Creature, giant | 20 m | 80 m (0.240) | 200 m (0.096) | 600 m (0.032) |

- **Outline:** turn the outline pass off from LOD2 onwards, or set its width to 0 in the LOD2 material. At that distance the line is under a pixel and costs a full extra draw.
- **Shadows:** LOD2 should not cast them, because the 60 m shadow distance already excludes most of it.

## Per-scene totals (visible, LOD-weighted, main view)

| Scene | Buildings | Creatures | Characters | Props | Vegetation | Terrain | Total | Draws (all passes) |
|---|---|---|---|---|---|---|---|---|
| Village (Brindlewick, Whisperwood hamlet) | 350k | 20k | 150k (player 30k, NPCs 15k each) | 150k | 200k | 130k | **1.0 M** | 1,500 |
| Field combat (Whisperwood field) | 50k | 120k | 100k | 150k | 350k | 200k | **0.97 M** | 1,200 |
| Boss arena | 100k | 25k boss + 40k adds | 100k | 150k | 150k | 150k | **0.72 M**, leaving headroom for VFX overdraw | 1,000 |

Shadow casters: at most 0.6 M triangles in any scene (60 m, one cascade). Character numbers are an assumption for the character-artist to confirm.

> **Superseded for characters (2026-11-23, D-03):** the owner's low-poly tier in [[art_direction]] §12 caps the player at 15k and named NPCs at 10k, with background townsfolk at 6k. The "player 30k, NPCs 15k each" assumption in the village row above is retired. The character column now leaves headroom, and the scene totals stand as upper bounds. Building, creature and prop budgets on this page are unchanged and are the tier's figures.

## The bake (how `bake_to_game.py` meets these)

```bash
blender -b --factory-startup -P Tools/blender/bake_to_game.py -- \
  --creatures mon_blue_slime,mon_goblin,mon_horned_rabbit,mon_forest_wolf \
  --buildings cottage:whisperwood,house:whisperwood,inn:whisperwood \
  --sheet 13_Production/screenshots/game_ready_ring0.png
```

**Options:**
- **Building spec:** `type:region[:seed]` (seed 1 by default). A creature takes an optional seed: `species[:seed]`.
- **Output:** `--out <dir>` exports elsewhere; `--no-export` only measures.

**Buildings:**
1. Realize the instanced tiles, bricks and planks (`generate.set_realize`).
2. Voxel-remesh into one shell (voxel = largest side ÷ 220, clamped to 3–8 cm), then smooth lightly so tile steps don't blotch the cel shading.
3. Dissolve planar faces, then collapse to 3× LOD0.
4. Delete faces no outside ray reaches: the hollow interior behind closed walls and the underside at ground level. Interiors seen through windows and doors stay.
5. Collapse to LOD0, then LOD1 and LOD2 from the level before.
6. On each LOD:
   - **Slots:** carry them back from the source by nearest-face lookup, with a 7-sample majority per face.
   - **Colour:** write the exact flat colours into `Col`.
   - **Merge:** fold near-duplicate tones (sRGB distance under 0.07), then fold the cheapest slots (area × colour distance) until the slot budget is met.
   - **Normals:** face-area weighted normals, with edges sharper than 40° kept hard.

**Creatures:**
1. Quadric collapse straight from the metaball body, which is already one clean shell. The painted `Col` survives, and is checked as `keptVertexColour` in the report.
2. Hard-part slot colours are written into `Col` too, then the slots are folded to budget.
3. Feet go at the origin.

**Colliders:** the convex hull of LOD2, collapsed and re-hulled to stay convex and under Unity's 255-triangle limit.

**Export:** FBX with `axis_forward -Z`, `axis_up Y`, `FBX_SCALE_UNITS`, `bake_space_transform`, face smoothing and sRGB vertex colours.

## Ring 0 first run (2026-10-25)

Before and after: ![[game_ready_ring0.png]] (`13_Production/screenshots/game_ready_ring0.png`). Each row is one asset: the source, then LOD0, LOD1 and LOD2, each labelled with its triangles against budget and its slot count. Rendered in Eevee with the flat slot colours, not the Unity toon shader.

| Asset | Class | Source tris | LOD0 / budget | LOD1 / budget | LOD2 / budget | Slots (max) | Collider tris | Bake time |
|---|---|---|---|---|---|---|---|---|
| mon_blue_slime | trash, small | 183,868 | 3,000 / 3,000 | 1,200 / 1,200 | 400 / 400 | 3 (6) | 86 | 4.4 s |
| mon_goblin | trash | 155,654 | 6,000 / 6,000 | 2,400 / 2,400 | 800 / 800 | 6 (6) | 86 | 4.0 s |
| mon_horned_rabbit | trash, small | 180,656 | 2,999 / 3,000 | 1,200 / 1,200 | 400 / 400 | 5 (6) | 86 | 4.3 s |
| mon_forest_wolf | trash | 180,976 | 6,000 / 6,000 | 2,400 / 2,400 | 800 / 800 | 5 (6) | 86 | 4.3 s |
| whisperwood_cottage | medium | 260,834 | 7,999 / 8,000 | 3,000 / 3,000 | 1,000 / 1,000 | 8 (8) | 86 | 24.0 s |
| whisperwood_house | medium | 416,682 | 8,000 / 8,000 | 2,999 / 3,000 | 999 / 1,000 | 8 (8) | 76 | 22.1 s |
| whisperwood_inn | large | 1,233,010 | 14,999 / 15,000 | 6,000 / 6,000 | 1,999 / 2,000 | 10 (10) | 110 | 26.3 s |

The FBX files re-import into Blender with the same counts, give or take a few degenerate triangles: the inn's LOD0 is 14,985 and the goblin's LOD2 is 765. Scale is 1, the vertex colour is present and the feet or ground are at z = 0. All 28 files together are 8.3 MB.

**What the sheet shows:**
- **Creatures** keep their silhouette and their eyes, teeth, horns and gear down to LOD1.
  - At LOD2 the slime's round eyes turn into diamonds and the goblin's iris gets coarse; that is fine at 30 m and beyond.
  - The horned rabbit's small painted spots are gone from LOD0 on. 3,000 vertices are too coarse for them, and they would need the baked 512² albedo.
- **Buildings** at LOD0 and LOD1 keep the timber frame, shutters, window boxes, door, chimney and eaves, and the roofs come out as clean single-tone planes.
- **Weak spot:** at LOD2 (1–2k triangles) the half-timbered walls break into triangle-shaped patches of timber and plaster. That is acceptable at the 80–100 m and beyond where LOD2 shows, but it is the first thing a baked colour texture would fix.
- **Lost details:** small accents that lose the slot competition fold into a neighbouring colour, such as the cottage's red chimney pot. Their exact colour is still in `Col`.

## Next steps

- **One-slot path (shader; technical-artist plus world-builder-engineer):**
  - **Done in code (needs a Unity verify run):** the smoothed outline normal now lives in UV3 (`TEXCOORD3`; UV1 is the lightmap UV and UV2 realtime GI, nothing here uses UV3). `BuildingImport.cs` writes it and sets `COLOR` to opaque white; the outline pass reads it and falls back to the vertex normal when the length is near zero (skinned meshes never get UV3, since UV data is not skinned). `GetVersion()` was bumped so Unity reimports the buildings by itself.
  - **Albedo:** the forward pass multiplies `COLOR` (sRGB in the FBX, converted with `SRGBToLinear`) into `_BaseColor`, in the direct and ambient terms. Characters and monsters therefore need `_BaseColor` white (their postprocessors already set it).
  - **Still open:** the slot cuts in the table above stay until the baked-building importer drops buildings to one slot and the building materials are rebuilt from `Col`. What Unity supplies for a missing `COLOR` stream is not documented, so every mesh on `Ascend/Toon` must carry `COLOR` (buildings now do).
- **Normal maps:** the cel look reads silhouettes and flat colour, not micro-relief, so these are optional. Where used, they mostly carry the tile, stone and plank rhythm that the voxel shell smooths away.

## Creatures

Role (the bake script's `creature_class`, from `Data/Monsters/species.json`):
- **giant:** `sizeMeters` ≥ 8
- **boss:** `bossHpMult` > 1 or `isUnique`
- **elite:** `elder` or `ancient` variants
- **trash:** everything else; *small trash* is under 0.8 m

| Role | LOD0 | LOD1 | LOD2 | Slots now (target) | Albedo if baked | Collider |
|---|---|---|---|---|---|---|
| Trash, small (<0.8 m) | 3,000 | 1,200 | 400 | 6 (1) | 512², 0.35 MB | convex hull, at most 96 tris (hit boxes come from the rig) |
| Trash | 6,000 | 2,400 | 800 | 6 (1) | 512² | same |
| Elite | 10,000 | 4,000 | 1,200 | 8 (1–2) | 1024², 1.4 MB | same |
| Boss | 25,000 | 10,000 | 3,000 | 10 (2) | 2048², 5.3 MB | same plus rig hurtboxes |
| Giant (≥8 m) | 40,000 | 15,000 | 5,000 | 10 (2) | 2048² | compound, per body part |

**Why these numbers:**
- **Trash LOD0:** a pack fight puts up to 10 trash and 1–2 elites on screen, plus the party.
  - The arithmetic: 10 × 6k + 2 × 10k ≈ 80k triangles before LOD, under a tenth of the frame.
  - Skinned meshes also pay GPU skinning per vertex, which is why trash stays well under the earlier generated-model caps in [[monster_model_pipeline]] (6k below 0.6 m, 12k below 2.5 m). Those caps were for single showcase models.
- **What 6k buys:** a goblin keeps its ears, brow, iris and pupil, teeth, sword guard and pouch.
- **Bosses and giants:** they are alone and fill the screen, so they get 25–40k.
- **Slots:** the painted skin is one slot, which is already vertex-coloured. Eyes, teeth, claws, gear and armour take the rest.

## Props

| Class | Examples | LOD0 | LOD1 | LOD2 | Slots |
|---|---|---|---|---|---|
| Tiny | cup, book, bottle, coin pile | 50–300 | none (cull at 25 m) | none | 1 |
| Small | crate, barrel, bush, sign, fence segment | 300–1,200 | 40% | none (cull at 60 m) | 1–2 |
| Medium | cart, market table, well bucket rig, rock cluster | 1,500–5,000 | 40% | 15% | 2 |
| Large | tree, wagon, statue | 5,000–10,000 | 35% | billboard impostor (trees) or 10% | 2 |

Props are where instancing pays: they share one palette material per pack and are GPU-instanced. Grass and ground cover are instanced shader geometry and are budgeted under vegetation, not here.

## LOD switch distances

These assume a 55° vertical field of view (the Whisperwood camera). Unity's `LODGroup` switches on screen-relative height: **h = size / (2 · d · tan(27.5°)) ≈ size / (1.04 · d)**. Enter the h values in the LODGroup; the distances are what they mean at LOD Bias 1.

| Class | Size used | LOD0→1 | LOD1→2 | Cull |
|---|---|---|---|---|
| Building, small | 3 m | 20 m (h 0.144) | 50 m (0.058) | 120 m (0.024) |
| Building, medium | 8 m | 30 m (0.256) | 80 m (0.096) | 250 m (0.031) |
| Building, large | 12 m | 40 m (0.288) | 100 m (0.115) | 350 m (0.033) |
| Building, landmark | 20 m | 60 m (0.320) | 150 m (0.128) | never (LOD2 to the far plane; 0.010) |
| Creature, small trash | 0.4 m | 8 m (0.048) | 20 m (0.019) | 45 m (0.0085) |
| Creature, trash | 1.0 m | 12 m (0.080) | 30 m (0.032) | 70 m (0.0137) |
| Creature, elite | 2 m | 20 m (0.096) | 45 m (0.043) | 120 m (0.016) |
| Creature, boss | 4 m | 35 m (0.110) | 80 m (0.048) | 200 m (0.019) |
| Creature, giant | 20 m | 80 m (0.240) | 200 m (0.096) | 600 m (0.032) |

- **Outline:** turn the outline pass off from LOD2 onwards, or set its width to 0 in the LOD2 material. At that distance the line is under a pixel and costs a full extra draw.
- **Shadows:** LOD2 should not cast them, because the 60 m shadow distance already excludes most of it.

## Per-scene totals (visible, LOD-weighted, main view)

| Scene | Buildings | Creatures | Characters | Props | Vegetation | Terrain | Total | Draws (all passes) |
|---|---|---|---|---|---|---|---|---|
| Village (Brindlewick, Whisperwood hamlet) | 350k | 20k | 150k (player 30k, NPCs 15k each) | 150k | 200k | 130k | **1.0 M** | 1,500 |
| Field combat (Whisperwood field) | 50k | 120k | 100k | 150k | 350k | 200k | **0.97 M** | 1,200 |
| Boss arena | 100k | 25k boss + 40k adds | 100k | 150k | 150k | 150k | **0.72 M**, leaving headroom for VFX overdraw | 1,000 |

Shadow casters: at most 0.6 M triangles in any scene (60 m, one cascade). Character numbers are an assumption for the character-artist to confirm.

> **Superseded for characters (2026-11-23, D-03):** the owner's low-poly tier in [[art_direction]] §12 caps the player at 15k and named NPCs at 10k, with background townsfolk at 6k. The "player 30k, NPCs 15k each" assumption in the village row above is retired. The character column now leaves headroom, and the scene totals stand as upper bounds. Building, creature and prop budgets on this page are unchanged and are the tier's figures.

## The bake (how `bake_to_game.py` meets these)

```bash
blender -b --factory-startup -P Tools/blender/bake_to_game.py -- \
  --creatures mon_blue_slime,mon_goblin,mon_horned_rabbit,mon_forest_wolf \
  --buildings cottage:whisperwood,house:whisperwood,inn:whisperwood \
  --sheet 13_Production/screenshots/game_ready_ring0.png
```

**Options:**
- **Building spec:** `type:region[:seed]` (seed 1 by default). A creature takes an optional seed: `species[:seed]`.
- **Output:** `--out <dir>` exports elsewhere; `--no-export` only measures.

**Buildings:**
1. Realize the instanced tiles, bricks and planks (`generate.set_realize`).
2. Voxel-remesh into one shell (voxel = largest side ÷ 220, clamped to 3–8 cm), then smooth lightly so tile steps don't blotch the cel shading.
3. Dissolve planar faces, then collapse to 3× LOD0.
4. Delete faces no outside ray reaches: the hollow interior behind closed walls and the underside at ground level. Interiors seen through windows and doors stay.
5. Collapse to LOD0, then LOD1 and LOD2 from the level before.
6. On each LOD:
   - **Slots:** carry them back from the source by nearest-face lookup, with a 7-sample majority per face.
   - **Colour:** write the exact flat colours into `Col`.
   - **Merge:** fold near-duplicate tones (sRGB distance under 0.07), then fold the cheapest slots (area × colour distance) until the slot budget is met.
   - **Normals:** face-area weighted normals, with edges sharper than 40° kept hard.

**Creatures:**
1. Quadric collapse straight from the metaball body, which is already one clean shell. The painted `Col` survives, and is checked as `keptVertexColour` in the report.
2. Hard-part slot colours are written into `Col` too, then the slots are folded to budget.
3. Feet go at the origin.

**Colliders:** the convex hull of LOD2, collapsed and re-hulled to stay convex and under Unity's 255-triangle limit.

**Export:** FBX with `axis_forward -Z`, `axis_up Y`, `FBX_SCALE_UNITS`, `bake_space_transform`, face smoothing and sRGB vertex colours.

## Ring 0 first run (2026-10-25)

Before and after: ![[game_ready_ring0.png]] (`13_Production/screenshots/game_ready_ring0.png`). Each row is one asset: the source, then LOD0, LOD1 and LOD2, each labelled with its triangles against budget and its slot count. Rendered in Eevee with the flat slot colours, not the Unity toon shader.

| Asset | Class | Source tris | LOD0 / budget | LOD1 / budget | LOD2 / budget | Slots (max) | Collider tris | Bake time |
|---|---|---|---|---|---|---|---|---|
| mon_blue_slime | trash, small | 183,868 | 3,000 / 3,000 | 1,200 / 1,200 | 400 / 400 | 3 (6) | 86 | 4.4 s |
| mon_goblin | trash | 155,654 | 6,000 / 6,000 | 2,400 / 2,400 | 800 / 800 | 6 (6) | 86 | 4.0 s |
| mon_horned_rabbit | trash, small | 180,656 | 2,999 / 3,000 | 1,200 / 1,200 | 400 / 400 | 5 (6) | 86 | 4.3 s |
| mon_forest_wolf | trash | 180,976 | 6,000 / 6,000 | 2,400 / 2,400 | 800 / 800 | 5 (6) | 86 | 4.3 s |
| whisperwood_cottage | medium | 260,834 | 7,999 / 8,000 | 3,000 / 3,000 | 1,000 / 1,000 | 8 (8) | 86 | 24.0 s |
| whisperwood_house | medium | 416,682 | 8,000 / 8,000 | 2,999 / 3,000 | 999 / 1,000 | 8 (8) | 76 | 22.1 s |
| whisperwood_inn | large | 1,233,010 | 14,999 / 15,000 | 6,000 / 6,000 | 1,999 / 2,000 | 10 (10) | 110 | 26.3 s |

The FBX files re-import into Blender with the same counts, give or take a few degenerate triangles: the inn's LOD0 is 14,985 and the goblin's LOD2 is 765. Scale is 1, the vertex colour is present and the feet or ground are at z = 0. All 28 files together are 8.3 MB.

**What the sheet shows:**
- **Creatures** keep their silhouette and their eyes, teeth, horns and gear down to LOD1.
  - At LOD2 the slime's round eyes turn into diamonds and the goblin's iris gets coarse; that is fine at 30 m and beyond.
  - The horned rabbit's small painted spots are gone from LOD0 on. 3,000 vertices are too coarse for them, and they would need the baked 512² albedo.
- **Buildings** at LOD0 and LOD1 keep the timber frame, shutters, window boxes, door, chimney and eaves, and the roofs come out as clean single-tone planes.
- **Weak spot:** at LOD2 (1–2k triangles) the half-timbered walls break into triangle-shaped patches of timber and plaster. That is acceptable at the 80–100 m and beyond where LOD2 shows, but it is the first thing a baked colour texture would fix.
- **Lost details:** small accents that lose the slot competition fold into a neighbouring colour, such as the cottage's red chimney pot. Their exact colour is still in `Col`.

## Next steps

- **One-slot path (shader; technical-artist plus world-builder-engineer):**
  - **The clash:** `Ascend/Toon`'s outline pass reads the smoothed outline normal from the vertex colour, which `BuildingImport.cs` writes there, so `Col` albedo and the outline currently compete for one channel.
  - **Fix:** move the smoothed normal to UV3 (TEXCOORD3) in the shader and the importer, and read albedo from `COLOR` × `_BaseColor`. Every asset then drops to one or two slots, and the draws column above drops by about 3×.
  - **Until then:** creature FBX vertex colours must not go through an importer that overwrites `COLOR`.
- **Normal maps:** not baked yet. The selected-to-active Cycles bake from the realized source to LOD0 needs UVs, a cage and about a minute per building on the CPU. It is optional for the cel look, so it waits until the shader samples a normal map.
- **Unity import:** nothing from `Art/Blender/GameReady` is in `Game/Assets` yet. Next comes an importer that pairs `_LOD0..2` into a `LODGroup` using the h values above, turns the outline off at LOD2 and adds `_COL` as a convex `MeshCollider`.
- **Rigs:** creature LODs are static. Skinning needs `Tools/blender/build_rig.py` run on LOD0, with weights transferred to LOD1 and LOD2.
- **Compound colliders** for L-shaped large buildings and landmarks. A convex hull fills in the inn's courtyard.
