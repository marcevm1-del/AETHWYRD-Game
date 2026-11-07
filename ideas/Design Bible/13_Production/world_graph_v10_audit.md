# World graph v10 audit and Wave F-lite contract

Source: `upgrade v10` (repo root; image links ignored). Canon wins: §3/§4 world numbers (40 surface regions, 5 Underworld layers, Great Labyrinth 120 floors in 3 depth bands), the §6 rows "Map knowledge rules" (Unknown / Heard / Visited), "World map layout" (the atlas, seed 1207, is the map), "Physical map", "Dungeon clue record", and the open proposals W3 (region data vs the relief) and the 10.24 km tile question (`13_Production/world_upgrade_plan.md`, "Waiting on the user" item 3).

## 1. What existed before this wave

| Area | State on main | Where |
|---|---|---|
| Region data | 49 entries: 40 surface, 8 underworld (3 Labyrinth bands + Umbravel, Hollow Sea, Aurumdeep, The Maw, Root of the World; that is 5 Underworld layers + 3 bands), 1 post-game (Vesper). Surface regions carry `map.at / radius / terrain`; underworld ones a `map.gate` and `map.depth` | `Data/World/regions.json` |
| Geography | Heights, rivers, lakes, ranges, 4 passes, 5 trade corridors, **13 roads** (with river crossings, pass ids, lengths), 51 settlements, region raster | `Data/World/physical_map.json` (validated, 0 errors, 28 warnings) |
| Map knowledge | `MapStatus {Unknown, Heard, Visited}` per region, local fog grid, `SaveGame.Map` | `MapKnowledge.cs` |
| Dungeon knowledge | The same three states for rooms and clues | `DungeonKnowledge.cs`, `SaveGame.Dungeons` |
| Terrain tooling | Tiles of a configurable `--tile-km` (script default 10; 10.24 recommended for 513-sample Unity tiles, awaiting the user) | `Tools/blender/build_world_*.py`, `terrain_unity_import.md` |
| Region graph | Nothing. Roads exist as geometry only; nothing says which regions join | none |
| Labyrinth floors | Prose only (12 biome bands in `10_World/world.md`, safe towns and guardians in the gazetteer) and one dungeon on floors 3-4 | `world.md`, `gazetteer.md`, `dungeons.json` |
| Streaming, biome rendering, map dev tools | Not started | n/a |

## 2. Facts that differ from v10

| v10 says | The project has | Decision |
|---|---|---|
| "The 40 surface regions" | `regions.json` has **49 entries**. 40 are `layer: surface`, so v10 and Canon agree; the other 9 are 8 underworld rows and Vesper. Nothing is wrong, but any code that counts "regions" must filter by layer | Graph nodes are the 40 surface regions. Core exposes `SurfaceRegionCount`. A test pins 40 |
| Map states Unknown / **Discovered / Surveyed** | Canon: **Unknown / Heard / Visited** | Not adopted. The Labyrinth record uses Heard / Visited. A fourth state is a Canon §6 proposal (WF1), not built |
| A world size in metres | `physical_map.json` already says 1 map unit = 1 km (150 x 100 km) and Canon §6 "Map knowledge rules" says the same | Core reads that one value; the user's W3 decision can still change the data, not the code |
| Tile size | Script default 10 km; 10.24 km recommended and pending | One data value flagged `placeholder`, not decided here |
| "Do not create a second list of 120 floor definitions" | None existed as data | `labyrinth.json` is the first and only one; `dungeons.json` floors are cross-checked against it |

## 3. v10 section map

Status: **built** (this wave), **partial**, **deferred** (a later wave, needs the user's decision or a Unity pass), **skipped** (and why).

| v10 section | Status | Decision |
|---|---|---|
| 8 Exploration, cartography, fog of war (3 levels) | partial | The three levels are already `Unknown / Heard / Visited` (built). 8.2 progression and 8.3 data are covered by the guild map seal and `SaveGame.Map` |
| 9.1 Region connection graph | **built** | `Data/World/region_graph.json`, generated from the 13 roads, the pass list, the sea leg and the region raster; `RegionGraph.cs` |
| 9.2 Boundary validation | **built (graph level)** | Validator: every edge resolves, no orphan, every surface region reachable from the start. Geometric boundary tests are deferred to the Studio |
| 9.3 Regional transition system | deferred | Needs streaming (out of scope) |
| 10 World scale calibration | **built (read-only)** | `WorldScale` helper reads `physical_map.json grid`. Calibration against travel times stays with the systems-designer (`systems.md` §11.3). No scale is chosen |
| 11 Multi-scale rendering, zoom, navigation | skipped | A map UI wave, not rules |
| 12.1 Layer maps, 12.3 vertical navigation | partial | `underworld.json` gives the 5 layers an order, depth and entry rules; no UI |
| 12.2 Surface-to-underground registry | partial | Only the connections Canon already names: the Labyrinth entrance under Aldmere, the three Labyrinth back-doors (floors 30 / 60 / 90) and the Maw as one pit. The other ~55 entrances in `world.md` have no places yet and are not invented |
| 13 Labyrinth 120-floor navigation | **built (rules)** | `labyrinth.json` + `Labyrinth.cs`: floors, stairs, bands, guardian and safe floors, back-doors, discovery record, save field. Floor geometry, minimap and selector UI skipped |
| 14 Unity streaming and additive scenes | skipped | Out of scope by instruction (depends on the scale decision) |
| 15 Terrain rendering and URP, 15.3 vegetation, 15.4 lighting | skipped | Rendering; not Core |
| 16 Roads, paths, traversal network | partial | The road list becomes graph edges; road categories and generation stay in `physical_map.json` |
| 17 World save data | **built (one field)** | `SaveGame.Labyrinth`, null-coalesced by `SaveRules.Upgrade` |
| 18 World Map Developer Studio | skipped | Editor tooling, `Game/` |

## 4. What this wave builds

1. `Tools/atlas/build_region_graph.js` writes `Data/World/region_graph.json` (deterministic; nothing hand-edited).
2. `Code/Ascend.Core/RegionGraph.cs`: connectivity, shortest path by km, orphans, reachability.
3. `Tools/validate/graph_checks.js`: schema plus graph rules. Its findings are counted **separately** from the 28 map warnings.
4. `Data/World/labyrinth.json`, `Data/World/underworld.json`, `Code/Ascend.Core/Labyrinth.cs`, save field `SaveGame.Labyrinth`.
5. `Code/Ascend.Core/WorldScale.cs`: map units to km to Unity metres to terrain tile.
6. Docs: `12_Systems/world_graph.md` and Canon §6 proposals.

## 5. Findings (data is not changed to hide them)

Filled in from the generator and validator runs; see `12_Systems/world_graph.md` §5.

## 6. Constraints honoured

- `regions.json` was not edited (ids, coordinates, text). Canon rows were not edited; every question is a §6 proposal.
- No scale or tile size was chosen: the 1 unit = 1 km figure is read from the existing data and the tile size is flagged as awaiting the W3 decision.
- No streaming, scene loading, Addressables, rendering, map UI or `Game/` change.
- Vocabulary stays Unknown / Heard / Visited.
