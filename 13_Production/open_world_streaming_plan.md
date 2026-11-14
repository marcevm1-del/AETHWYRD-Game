# Open world streaming: plan and first slice

Owner: world-builder-engineer. Written 2026-11-14 on branch `agent/world-builder-engineer/region-graph-map`. Builds on `13_Production/terrain_unity_import.md` (the wave-0 import plan), `12_Systems/world_graph.md` (region graph, scale, tiles) and `13_Production/world_terrain.md` (the generator). `Canon.md` and `Data/` stay authoritative for every number; where the data cannot answer, this page says so.

Goal (the user's words, via Main v1): "1 massive open world game": the world is one continuous place the player walks across with no loading screen between regions.

## 1. What the data already says

| Fact | Value | Source |
|---|---|---|
| Map | 150 x 100 map units, 1 unit = 1 km | `Data/World/world_scale.json` |
| Terrain tiles | 150 (15 x 10), 10 km square, 501 samples at 20 m, 16-bit heights, one fixed encoding (-1800 to 3400 m) | tile sidecars in `Art/Blender/WorldTerrain/world/` |
| Tile rebuild at 10.24 km | settled in Canon section 6 WF9 but **not done**; the tiles on disk are 10 km | `world_scale.json` `builtTileKm` vs `terrainTileKm` |
| Regions | 49: 40 surface, 8 underworld, 1 post-game | `Data/World/regions.json` |
| Region graph | the 40 surface regions as nodes; 100 edges: 85 border, 10 road, 3 pass, 2 sea | `Data/World/region_graph.json` |
| Ring 0 anchor | Brindlewick, map (72.6, 60.0), pad height 298.649 m, flat for 160 m | tile `x70_y50` sidecar |

Things that follow from this and shape the design:

- **Seams are tile edges, not region borders.** Tiles are a regular 10 km grid; regions are irregular lands. A region spans several tiles and a tile holds several regions. Streaming therefore works on tiles and region identity is looked up by position.
- **The Ring 0 anchor sits on a tile seam.** Brindlewick is at map y = 60.0, exactly the south edge of tile (7, 5) and the north edge of tile (7, 6). Two tiles must be up before the player can stand in the starting field. (The wave-0 plan expected the anchor inside a tile; that was for the 10.24 km grid.)
- **Only the 40 surface regions stream as terrain.** The 8 underworld regions and the post-game region are not on the surface map; they stay separate layers (as the Labyrinth and dungeons already are).

## 2. Design

| Question | Decision | Why / status |
|---|---|---|
| Streaming unit | one Unity Terrain per 10 km tile | matches the generated data; no re-cutting |
| "Cell size" | a tile is 10 km; heights are 20 m samples, resampled to Unity's 513 grid (19.5 m); splat 256 x 256 (39 m) | Unity needs 2^n + 1 |
| Stream radius | load a tile when its nearest edge is within **7.5 km** of the player; unload when beyond **9.5 km** (2 km margin); cap **9** resident | 7.5 km is the smallest radius that reaches the diagonal tiles from the middle of a tile (corner distance 7.07 km); the margin stops flicker at a border. All three are placeholders for the user to tune |
| What loads / unloads | Terrain + collider + splat per tile; decided by Core's `SectorStreamer` (tested without Unity), executed by `WorldStreamer` | rules and Unity side stay separate |
| Load path | file read and resample on a worker thread; Terrain object built on the main thread, one tile per frame | measured 25 to 63 ms per tile build |
| First load | blocking in `Start`, so ground exists before the first physics step | the walk test checks the ground every step |
| Origin | Unity (0,0,0) = Ring 0 anchor at pad height, set from the baked manifest; Canon's origin (north-west corner) is unchanged and `WorldOrigin` converts | `WorldOrigin.cs` |
| Seams | shared edge samples are bit-identical in both tiles; resampling 501 to 513 only interpolates along the edge, so both sides agree; Unity links neighbours automatically (same grouping id) | measured 0.0000 m difference along the x = 80 km seam |
| Region identity | looked up by position with Core's `WorldMapTerrain.RegionAt`; `WorldStreamer.RegionChanged` fires on crossing | see section 4 for the caveat |
| Region graph to traversal | the terrain itself is the traversal: every border edge is ground you can walk. The graph stays the authority for the map, fast travel, travel time and routing | see below |

**How the graph's connections become real traversal.** In a continuous world a `border` edge needs no loader: both lands are the same ground. A `road` or `pass` edge is a walkable route whose geometry comes from `physical_map.json` roads and passes; those are in the generator's tiles but road and path *meshes* are not yet exported (section 5). `foot: false` borders (the lowest crossing is above the pass limit, or the shared border is under 1 km) must be hard to cross on foot because the terrain there is high; nothing yet checks the real terrain against that flag. `sea` edges need a boat and water, neither built. A planned validator (not written): for every `foot: true` edge, a slope-limited walk exists across the baked heights; for every `foot: false` edge, none does.

## 3. What was built and measured

Branch `agent/world-builder-engineer/region-graph-map`. Files: `Tools/world/bake_stream_tiles.py`, `Game/Assets/_Game/Runtime/World/{WorldOrigin,StreamTile,WorldStreamer}.cs`, `Code/Ascend.Core/{SectorStreamer,WorldMapView}.cs`, the Ring 0 builder hook, `ScreenshotRunner` ground snap, `Game/Assets/_Game/Tests/PlayMode/WorldStreamingPlayModeTests.cs`.

**Baked data:** 150 tiles, 113.1 MB (about 754 KB per tile: heights 0.50 MB plus a 251 x 251 splat 0.25 MB), generated locally and gitignored. The built player is 236.4 MB with them (Unity build log).

**PlayMode, Unity 6000.6.7f1 with graphics, filter `WorldStreaming`:** run 1 4 of 4 passed; run 2 (after the radius change) results are in section 6.

- Walk from the Ring 0 anchor east to map x 80.8 km (8.2 km, 25 m strides) across the seam at x = 80 km: 0 steps without ground under the walker, 1 seam crossed, tiles (8,5) up and (6,5) unloaded, region changed from Whisperwood to Greymoor.
- Seam heights agree to 0.0000 m along the whole shared edge sampled every 137 m.
- A 60 km teleport loads its ground at once and drops the old tiles.
- Nine-tile cost (run 2): Unity allocated 17.3 MB more, managed heap 12.2 MB more, graphics driver 32.1 MB more; worst tile build 28.7 ms. The process working-set figure came back as 0.0 MB (the counter was not refreshed correctly), so **real process memory for nine tiles is NOT ASSESSED**; the three figures above are Unity's own counters.

## 4. Honest limits and what will not fit yet

- **Everything resident at once will not be tried.** Scaling the nine-tile numbers by 150 / 9 gives roughly 290 MB of Unity allocations plus 535 MB of graphics memory for terrain alone, before any trees or buildings: that is an extrapolation, not a measurement, and streaming exists to avoid it.
- **Dressing is the real cost and is unmeasured.** The one sidecar I read (tile x70_y50) records 4,944 trees, 91 buildings and many props, as counts only; instance positions are not exported, so none of it can be placed or measured. Terrain alone is cheap; a believable world is mostly dressing. Frame time and GPU cost with dressing at nine tiles are NOT ASSESSED.
- **Frame time and GPU cost** of nine 513 terrains at pixel error 8 were not measured (the tests run headless-timing only). NOT ASSESSED.
- **Float precision.** Float positions are fine near the anchor (about 2 mm at 25 km) and degrade to about 8 mm at the world's far edge (up to about 87 km away). Origin shifting is not built, and the area-map fog and several systems read raw `transform.position`, so shifting needs them made origin-aware first. The streamed slice around Ring 0 stays within about 15 km, where this does not bite.
- **Tiles are 501 samples, resampled to 513.** The seams are exact, but heights between samples are interpolated. The cleaner answer (rebuild at 10.24 km with `--res 20` for 513 samples) needs a Blender run over all 150 tiles; not done.
- **Region lookup is the procedural land map**, not the physical map's own region raster, so the region the HUD names and the region the generator painted can disagree near borders. The data does not currently tie the two together; a decision is needed.
- Not built: trees, buildings, props, roads and paths, water and sea, far-ring impostors beyond 9.5 km (the horizon past the loaded square is empty), the toon terrain shader and colour map (flat layer colours today), origin shifting, saving the streamer's state, dungeon and underworld entrances inside the streamed world.

## 5. Next steps, in order

1. Run the full PlayMode suite and `npm run build` on the merged branch (see the report); fix anything the merge broke.
2. Export dressing positions from the generator (environment-artist) so trees and buildings can stream with their tile; then measure again.
3. Far ring: a decimated 129 x 129 ring or one impostor mesh, so the view past 9.5 km is not blank.
4. Origin shifting plus making fog and area code origin-aware.
5. Decide the region-lookup question (section 4) and write the foot/no-foot validator.
6. Rebuild tiles at 10.24 km (Blender run) when the user wants the cleaner 513 grid.

## 7. Lesson: the editor and the built player see different data

The first photos from the built player showed no terrain: `WorldStreamer` threw `FileNotFoundException` for `world_scale.json` because `BuildPlayer.cs` copies only a listed set of `Data/` files into the build. In the editor `AscendData.DataRoot` reads the repo's `Data/` folder, so the PlayMode tests passed while the streamer was dead in the build. Rules: anything the streamer reads at runtime must be in the build's data list (`BuildPlayer.cs`), and a screenshot from the built player is the only check that catches this. The baked tiles live in `StreamingAssets/World/` and travel with the build (236 MB player).
