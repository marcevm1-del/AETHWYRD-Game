# World terrain: Unity import plan

Status: wave-0 plan (technical-artist, 2026-11-02). Source data: `13_Production/world_terrain.md`. Palette: `13_Production/art_direction.md` sections 2, 3 and 9. Stub importer: `Game/Assets/_Game/Editor/Terrain/TerrainTileImportStub.cs` (menu `Assets/Ascend/Terrain/Import Tile (stub)`). Nothing here changes a scene.

## 1. Tile to TerrainData

| Sidecar / raster | Unity |
|---|---|
| `*_height.png`, 16-bit grey, `h = -1800 + v/65535 * 5200` for EVERY tile | `TerrainData.heightmapResolution = 513`, `size = (10240, 5200, 10240)`, normalised height = `v/65535` |
| row 0 = north edge, col 0 = west edge | Unity heights are `[z, x]` with z = 0 at the south edge: flip rows (`heights[N-1-row, col]`) |
| `encoding.minM/maxM` (-1800 / 3400, span 5200) | The importer reads these from the sidecar and uses `maxM - minM` as `size.y`, never constants; the terrain's y position is `minM` |
| `tile.x0Km, y0Km` | World position (section 2) |
| `splat.png` RGBA8 (R veg, G rock, B sand, A snow) | 4 `TerrainLayer`s, `alphamapResolution = 512` (section 4) |

**Use one fixed height range for all tiles, not a per-tile tight range.** The generator already quantises every tile with the same encoding, so a shared edge sample has the same 16-bit value in both tiles. Keeping that value untouched (Unity stores 16-bit heights too) gives bit-identical seams. A per-tile range would re-quantise each tile differently and open cracks of up to one step (0.04-0.08 m). The cost is a taller bounding box per tile (5200 m), which only slightly weakens culling. Caveat to verify: Unity may keep fewer than 16 effective bits; the stub logs a `SetHeights`/`GetHeights` round-trip error in metres. If it reports more than one encoding step (0.079 m), the seams still match (same quantiser both sides) but the heights are coarser than the PNG, and we should say so.

### 513 vs 501: use `--tile-km 10.24 --res 20`

The maths: 513 samples = 512 intervals; 512 x 20 m = 10.24 km. So `--tile-km 10.24 --res 20` yields exactly 513 samples per side, 20 m cells, with no resampling. The current 10 km tiles give 500 intervals = 501 samples.

Resampling 501 to 513 instead means 10,000 m / 512 = 19.53 m cells: every height is interpolated, the SHA-256 and "bit-exact vs the generator" guarantee is gone, the tile grid stays on 10 km multiples but nodes no longer sit on the generator's 20 m lattice (so road-bed and Ring 0 pad flatness is only approximately preserved). Corners and edges would still agree between neighbours (both resample the same edge samples), but only because the edge is 1-D interpolated identically.

Recommendation: rebuild at 10.24 km (the physical map is a pure function of world position, so heights at shared metres are unchanged; tile boundaries just move). Trade-offs to accept:
- Tile origin = `tx * 10.24` km, not a round km. Tile (tx, ty) covers 10.24 km, so the grid is 15 x 10 = 150 tiles covering 153.6 x 102.4 km, i.e. 3.6 km east and 2.4 km south of the 150 x 100 km map. Open question: what the generator returns outside the physical map (it should be open sea or clamped; needs environment-artist to confirm and to add `checks` for the last column/row). The tile count stays 150.
- Existing 10 km tiles and every report hash are superseded; regenerating 150 tiles is a batch run (time not measured here).
- Brindlewick (72.6, 60.0) then lies in tile (7, 5) (origin 71.68, 51.2 km) at offset (0.92, 8.8) km, about 0.9 km from the west edge, so the 300 m pad is nowhere near a tile edge.
- The stub still works on the existing 501 tiles by resampling (log warns "preview only").

## 2. World placement and stitching

Axes. Map x east, map y SOUTH. Unity x east, z north, so `unity = (mapX_km*1000 - originX, y - originY, -(mapY_km*1000) - originZ)`. A Terrain's origin is its south-west corner, which is map `(x0, y1 = y0 + size)`: `terrain.position = (x0*1000, minM, -(y0+size)*1000)` (same convention the .blend uses).

Float precision. A raw 72,600 m x has a float spacing of 8 mm, and the far corner is 150 km out (16 mm). That jitters the camera, animation and physics. Plan: **a world origin at Brindlewick** (`WorldOrigin = mapKm(72.6, 60.0)` in XZ), so the Ring 0 scene needs no move and the player starts near zero; add runtime origin shifting (re-base all root transforms when the player is > 4 km from zero) before leaving the heartland. For Y: Ring 0 content is authored at y = 0 on a pad at 289.904 m, so either (a) rebase Y too (`terrainY = h - 289.904`, sea level becomes y = -289.904, exposed as `WorldOrigin.SeaLevelY`), or (b) keep absolute Y and put the Ring 0 root under an anchor at y = +289.904. Recommend (a): zero changes to Ring 0 code and floating-point stays good; altitude readouts add the constant back. Decision for the user, see questions.

Neighbours. Each tile shares its edge row/column with the next, exactly as Unity expects (terrain width 10240 m, tiles spaced 10240 m). After a tile loads: `terrain.SetNeighbors(left: west, top: north, right: east, bottom: south)` with north = tile `(tx, ty-1)` (map y runs south, so lower ty is north), south = `(tx, ty+1)`. Do it for the new tile and its (up to 4) loaded neighbours, then `terrain.Flush()`. Keep `allowAutoConnect = false` and wire manually, since we stream. Mismatched settings (pixelError, basemapDistance, material) between neighbours cause visible seams on normals, so all tiles share one `TerrainSettings` asset.

## 3. Splat map to terrain layers

The splat (4 channels) carries only coarse classes; the cel look in the preview comes from the baked vertex colour `albedo` (three-tone grass patches, road dirt, rock strata bands, snow tones). Layers alone would lose that, so:

1. **Colour map (needs a new export, ask environment-artist):** `<name>_albedo.png`, 8-bit sRGB RGB, unshaded, 513 x 513 (or 1024), rendered from the `albedo` vertex colour. Today only `_top.png` (a shaded view) exists, which cannot be used as colour.
2. **A custom terrain shader** (`Ascend/TerrainToon`, technical-artist, terrain-compatible URP, toon ramp and shadow tint 0.58/0.56/0.78 from art direction): output = colour map x (optional) layer detail. The cel tones, the paths and strata then come straight from the generator, and the layers only add micro-detail and let the engine paint (footprints, grass).
3. **Layers (flat-ish toon textures, tile size 30 m), in splat channel order:**

| Layer (channel) | Base tone | Notes |
|---|---|---|
| Vegetation (R) | lit grass `#8CC860` (shade `#5E9A4A` and dirt `#C9A66B` live in the colour map) | grass blade stipple only; triplanar not needed |
| Rock (G) | mid `#9E9486` (light `#C4B69C`, dark `#7A726C`) | strata bands come from the colour map; add a normal for cliff breakup; triplanar on steep faces |
| Sand (B) | adobe sand `#E0B885` (desert two tones in the colour map) | ripple normal |
| Snow (A) | snow `#F0F5FF`, shade lavender | no mid-tone; keep hard step |

The splat PNG is sampled at the 513 nodes; Unity's alphamap pixels are cells, so resample 513 -> 512 at cell centres (average of adjacent nodes), then normalise (sum to 1; a zero sum becomes layer 0). The stub does exactly this. Note: with only 4 layers one control texture (one pass) draws the whole tile.

Open: confirm the splat channels sum to 1 (or whether "none" means bare ground). The stub normalises.

## 4. Dressing (trees, buildings, props)

Today dressing exists only in the .blend (true-scale meshes) and as counts/hash/landmarks in the sidecar. It needs an export. Proposal (environment-artist adds to `build_world_terrain.py`; format `ascend-terrain-dressing/1`):

- **`<name>_dressing.json`** next to the sidecar, tile-local metres (x east from the SW corner, z north) so it survives the origin choice; Y is NOT exported (Unity snaps to the terrain height; the generator guarantees positions came from the heightfield). Struct of arrays per kind to stay small: 
  `{ "format": "ascend-terrain-dressing/1", "tile": "x70_y50_s10_r20", "heightmapSha256": "...", "kinds": { "tree_round": { "x":[...], "z":[...], "yawDeg":[...], "scale":[...], "tint":[...] }, "house_cottage": { ..., "variant":[...] }, "lamp_post": {...} } }`.
  Fields per instance: position, yaw, uniform scale (the preview x5/x6 exaggeration must NOT be baked in), variant/colour index, and for buildings the palette key (Aldmere palette flag). Roughly 9,000 trees x ~40 bytes is about 0.4 MB JSON per tile worst case; convert to a binary blob in the importer if load time matters.
  Also: polylines for walls, fences, field outlines, paths, and the delta/lake/river data already in the sidecar (rivers carry `[xKm, yKm, waterSurfaceM, widthM]`, lakes `surfaceM`).
- **Prototype meshes once, not per tile:** buildings already come from `town_buildings.BUILDERS` and `Art/Models/Buildings` (with `BuildingImport` outlines); export trees (round, conifer, snag), rocks, reeds, fences, wall/gate kit the same way from Blender as FBX with LOD0-2 (technical-artist bake step). One `TerrainDressingLibrary` ScriptableObject maps kind names to prefabs.
- **Unity side:** trees and grass go to the Terrain system (`TreeInstance`, detail layers; trees: 3 prototypes, LOD billboard past about 400 m, `treeDistance` 600-800 m; grass 14,000 clumps only on close-ups, so use the Terrain detail layer from the vegetation channel instead). Buildings and props (up to about 420 per tile) become pooled prefab instances spawned per streamed chunk with distance culling and LODGroups; static batching is not available for streamed content, so use the SRP Batcher with a shared material per palette. Lamps get their emission and an optional light only within 60 m.
- **Ring 0 exclusion** (nothing inside the 200 m field + 12 m margin) already holds in the data; the importer must also assert `ring0Violations == 0`.

## 5. LOD and streaming for 150 tiles

- **Active set:** the tile under the player plus its 8 neighbours (3 x 3 = 30.7 km square) as full 513 `Terrain`s, `heightmapPixelError` 5 near and up to 12 for the outer ring, `basemapDistance` 600 m, `drawInstanced = true`. Load/unload by player tile index with hysteresis (hold a tile loaded until the player is 0.4 tile past its edge). Load is async: `TerrainData` from an Addressables group (one per tile) or a pre-built scene per tile loaded additively, one tile per frame budget.
- **Far ring:** a second ring (5 x 5) as decimated 129 x 129 `Terrain`s or a single static mesh with the baked colour map, and beyond that a world-map impostor (the generator's `world_overview.png`) under fog. 
- **Water:** the sea is a single large plane following the camera at sea level; lakes and rivers are small meshes generated at import from sidecar polylines (water level never rises downstream), toon water shader with foam line, per art direction (`#7FB3D0`).
- **Collision:** terrain colliders only for the 3 x 3 set; the 5 x 5 ring has none.
- **Origin shifting** as in section 2.

## 6. Memory budget (per tile, measured by arithmetic, not yet in Unity)

| Item | Per tile | 3 x 3 loaded | All 150 on disk |
|---|---|---|---|
| Heightmap 513 x 513, 16-bit | 0.53 MB (plus a similar copy for the collider heightfield) | about 9.5 MB | about 80 MB (+80 MB colliders if baked) |
| Splat 512 x 512 RGBA8 (DXT5 compressed in the build) | 1.4 MB raw / 0.35 MB compressed | 3.2 MB | about 53 MB |
| Colour map 1024 x 1024 DXT1 + mips (requested export) | 0.7 MB | 6.3 MB | about 105 MB |
| Trees (TreeInstance 32 B x up to 9,000) | 0.3 MB | 2.6 MB | 45 MB |
| Buildings / props (prefab instances, transforms) | about 0.1 MB data + shared meshes | small | small |
| Terrain meshes / render data | handled by Unity, a few MB | ~20-30 MB estimate | not loaded |

Target: terrain + dressing under 150 MB resident on a 4 GB GTX 1650 system, under 1 GB on disk. Triangle cost is driven by pixelError: about 300-500 k triangles for a 3 x 3 set at pixelError 5-12 (to be measured with real tiles before committing).

## 7. Ring 0 (the hand-built 200 m field) inside the world

- Brindlewick sidecar `ring0`: `sizeM 200`, centre (72.6, 60.0) km, `heightM 289.904`; the pad is exactly flat for 160 m radius (the field half-diagonal is 141 m) so the field fits with no gap.
- Origin rebase puts the field centre at world (0, 0 or 289.9, 0): the Ring 0 scene (authored at y = 0) opens unchanged on the terrain, additively.
- **Ground:** the graybox `Ground` plane (200 m, y = 0) would z-fight with the pad. Options: drop the plane in the world scene variant and let the pad terrain (packed earth colour inside the field) carry it, or sink the plane 2 cm. Recommend dropping it so footsteps/terrain material are one system. Ring 0 colliders and nav stay hand-built.
- **Seam of styles:** beyond the field + 12 m margin the terrain dressing takes over (houses ring, clock tower skyline proxy, gate on the road 215 m out); the hand-built scatter (Whisperwood) near the field must not overlap generator dressing; the generator exclusion margin (12 m) is the contract. Millbrook has the same `ring0` block and the same treatment.
- Respawn, map and waypoints continue to use the existing world coordinates; add a single `WorldOrigin` helper (map km <-> Unity) in `Runtime` so nothing else hardcodes it (world-builder-engineer).

## 8. Importer work plan

1. (done, stub) sidecar + 16-bit PNG -> TerrainData asset, 4 layers, round-trip log.
2. Real importer: batch over a folder, one TerrainData + prefab per tile in `Assets/_Game/World/Terrain/`, shared settings, SetNeighbors runtime component, hash check against `heightmapSha256`, pad-height assert against `settlements[].padHeightM`.
3. Environment-artist: 10.24 km rebuild, `_albedo.png` export, `_dressing.json` export.
4. Technical-artist: `Ascend/TerrainToon` shader, prototype mesh LODs, water shader.
5. World-builder-engineer: streaming manager, `WorldOrigin`, origin shifting.

## Questions for the user
1. Rebuild all tiles at 10.24 km (recommended), or keep 10 km and resample to 513?
2. World origin: rebase both XZ and Y to Brindlewick's pad (recommended), or keep absolute Y with an anchored Ring 0 root?
3. OK to ask environment-artist for `_albedo.png` and `_dressing.json` exports?
4. What should a tile beyond the 150 x 100 km map show (the last column/row grows by 3.6 / 2.4 km)?
