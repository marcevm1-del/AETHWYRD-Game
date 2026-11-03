# Physical Geography of Aetheria

> **Source of truth:** the atlas (`Tools/atlas/aetheria_atlas.html`, coastline seed 1207) for the coast, region borders and where the land is rough; `Data/World/regions.json` for each region's anchor, radius, terrain and places. This page and `Data/World/physical_map.json` add **height, water and climate** on top of them. They move no coast, region or town.
> **Generated:** `node Tools/atlas/build_physical_map.js` writes `Data/World/physical_map.json` and `10_World/maps/physical_map.png`. Never edit the JSON by hand. §11 documents the detail layer (smooth rivers, settlements, roads) added for the Blender terrain and diorama work.
> **Status:** names marked * are proposals (Canon §6, "Physical map"). Everything else is either computed or quoted from the gazetteer and world.md.

![Physical map](maps/physical_map.png)

## 1. How the terrain is derived

1. **The atlas's own numbers.** `Tools/atlas/atlas_field.js` is a line-for-line port of the atlas's land field and relief: the noise, `sample()`, `biomeAtU()`, the chamfer coast distance, the roughness blur and the `hgt` relief. It was checked against the atlas running in Chromium: all 960,000 pixels give the same height and the same region (difference 0). It reads anchors from `regions.json` (the order the game's `WorldMapTerrain.cs` uses), and the builder checks they still match the atlas's own table.
2. **Metres.** The atlas relief `h` (0 at the shore, about 0.3 on lowland, up to 1.45 on the roughest ground) becomes `m = 750·h + 2600·max(0, h − 0.5)^1.4`. Lowland sits at 250–400 m, the high ranges at 2,000–3,300 m, and the highest point is 3,334 m (Black Peaks). The sea floor deepens with distance from the coast: a shelf to about 125 m within 4 km, then down to about 1,700 m.
3. **Grid.** The 1200 × 800 atlas canvas is averaged 4 × 4 into **300 × 200 cells of 0.5 km**: 1 map unit = 1 km (Canon "Map knowledge rules"). A cell is land if most of its pixels are land. It takes the region that owns most of them, and the biome that region paints most often there.
4. **Water.** The builder floods inward from the sea. A hollow is drained by cutting its outlet down, by up to 120 m plus half of the ground above 1,000 m. In the mountains those cuts are the gorges the lore keeps mentioning (Shen-Lu, the Apu Highlands, Hoshizora). The second pass fills what still holds water, and that becomes the lakes. Lake floors are silted to at most 120 m below the surface. Rain is weighted by biome (jungle 1.5 … desert 0.08), so desert rivers stay small.
5. **Ranges** are ground above 1,000 m, grouped by region. A crest line runs along each range's main axis, and summits are local highs above 1,500 m (at least 4 km apart).
6. **Passes.** Each corridor leg is routed with a cost for grade and altitude, and roads may not cross ground above **2,000 m**. Where the lowest crossing is higher, the builder carves a notch to 1,900 m and lists it. **None was needed:** the atlas relief already has a way through for all five corridors.
7. **Biomes.** Each cell keeps its region's terrain from the atlas. Height and water overlays are added on top: **alpine** above the treeline, **snow** above the snowline (never on volcanic or demon ground), **beach** on the atlas's sandy rim, and **lake**.

## 2. Climate belts

Sea-level mean temperature runs from about 0 °C on the north coast to 28 °C on the south coast (`T = 0.28·y`) and falls 6.5 °C per km of height. Permanent snow lies where the mean is below −5 °C. Trees thin out below −1 °C. Winter snow comes about 1,000 m lower, and that snow feeds Zarvan's springs.

| Belt | Map rows (y) | Lands | Feel |
|---|---|---|---|
| Polar coast and ice | 0–14 | Heavenreach, Whitewater Reach's coast | Sea ice in winter, glaciers down to the water |
| Boreal north | 14–32 | Nox Dominion, Vharlen, Frostveil, Cinderhole, Dragon Spine, Shen-Lu, Haneul, Kitsune Isles | Long winters, pine and tundra, snow on every range (snowline about 1,100–1,600 m) |
| Temperate heartland | 32–68 | Aldmere, Whisperwood, Greymoor, Sylvaran, Velmark, Lirian, Moraveil, Fanghold, Strife Marches, Iron Hold, Hoshizora, Gearholm, Stormreach, Bastion, Everdusk, Ashira Vale, Calamity Steppe, True-Name Isles | Four mild seasons; snow only on the high peaks (snowline about 2,000–2,900 m) |
| Warm south | 68–100 | Mossdeep, Sunscar, Zaruma, Zarvan, Dunewhale Drift, Xochitl Mire, Lumbaya, Apu Highlands, Goldmere Coast, Lustrine Shores, Quaking Lands | Hot and dry in the centre (desert); wet in the south-west (mire, jungle); no permanent snow |

Belts are assigned by each region's anchor row. Per-region figures (mean height, the 90th percentile and the estimated mean temperature) are in `regionStats`.

## 3. Mountain ranges

| Range | Region | Trend | Area km² | Mean / max m | Named summit |
|---|---|---|---|---|---|
| Iron Hold Peaks | Iron Hold | E–W | 162 | 1,963 / 3,083 | |
| Dragon Spine | Dragon Spine | E–W | 225 | 1,735 / 3,219 | The Burning Peaks 3,036 (south end) |
| Cinder Hills* | Cinderhole | N–S | 111 | 2,293 / 3,101 | |
| Glacier Teeth* | Frostveil | N–S | 96 | 1,705 / 3,079 | |
| Whitewater Fells* | Whitewater Reach | E–W | 56 | 1,197 / 2,119 | |
| Hundred-Stair Mountains | Shen-Lu | N–S | 46 | 1,828 / 3,131 | |
| Haneul Highlands | Haneul | N–S | 186 | 2,008 / 3,216 | |
| Heavenreach Plateau | Heavenreach | N–S | 128 | 2,034 / 3,217 | Tribute Peak 3,217 |
| Hoshizora Cedar Mountains* | Hoshizora | E–W | 268 | 1,983 / 3,222 | Oni Volcano 3,222 |
| Clockwork Mountain | Gearholm | E–W | 151 | 1,961 / 3,289 | |
| Zarvan Mountains* | Zarvan | N–S | 259 | 2,077 / 3,272 | |
| Black Peaks | Stormreach | N–S | 181 | 1,991 / 3,334 (the highest point) | |
| Carved Mountains | Apu Highlands | E–W | 169 | 2,011 / 3,180 | The Giant's Bed 3,180 |
| Nox Fire Mountains* | Nox Dominion | E–W | 201 | 1,849 / 3,020 | The Overlord's mountain of fire* 3,020 |
| Frontier Mountains* | Vharlen | N–S | 27 | 1,870 / 2,983 | |
| Quakeback's Ridge | Quaking Lands | N–S | 9 | 1,267 / 1,726 | |
| Everdusk Heights* | Everdusk | E–W | 8 | 1,226 / 1,631 | |

The ranges join into six **massifs** (`massifs[]`):
1. **The north-eastern massif** (Hoshizora, Haneul, Gearholm, Heavenreach, Shen-Lu).
2. **The northern wall** (Dragon Spine, Iron Hold, Cinderhole, Frostveil, Whitewater Reach).
3. **Zarvan.**
4. **The Nox Dominion.**
5. **Stormreach.**
6. **The Apu Highlands.**

The northern wall is the big travel barrier. It cuts the heartland off from the snow coast, and Iron Hold's dwarves hold the way through.

## 4. Rivers and lakes

Thirty watercourses, all checked to fall from source to mouth. Every main river reaches the sea.

| River | Rises in | Runs to | km | Course |
|---|---|---|---|---|
| Greymoor River* (the trunk) | Sylvaran, 306 m | the Sundered Sea | 141 | Sylvaran → Aldmere → Velmark → Lirian → Greymoor → Strife Marches → Goldmere Coast |
| ↳ Lirian River* | Haneul, 1,861 m | Greymoor River | 42 | down from the Haneul pass, through Hoshizora |
| ↳ Iron Hold River* | Cinderhole, 1,184 m | Greymoor River | 30 | out of the northern wall through Iron Hold into Velmark |
| ↳ Whisperwood River* | Mossdeep, 319 m | Greymoor River | 24 | Mossdeep → Sylvaran → Whisperwood → Greymoor |
| ↳ **Millbrook** (canon stream) | Whisperwood, 321 m | Greymoor River | 13 | past Millbrook into Greymoor's fen |
| Moraveil River* | Apu Highlands, 2,068 m | the Veiled Sea | 90 | Apu → Everdusk → Xochitl → Ashira → Moraveil → Fanghold → Vharlen |
| ↳ Aldmere River* | Sylvaran, 296 m | Moraveil River | 55 | through Aldmere's west and Moraveil |
| ↳ Bastion River* | Nox Dominion, 814 m | Moraveil River | 56 | out of the demon lands, across Bastion |
| Shen-Lu River* | Dragon Spine, 1,238 m | the Sundered Sea | 39 | gorges of the Hundred-Stair Mountains; the Haneul River joins it |
| Xochitl Mire River* | Xochitl Mire | the Veiled Sea | 30 | the mire basin, fed from the Apu Highlands and Ashira Vale |
| Dunewhale Drift River* | Mossdeep | the Sundered Sea | 33 | across Sunscar and the Drift; Zarvan's snow-fed streams join it |
| Others* | | | 14–28 | Whitewater Reach, Everdusk, Lumbaya, Hoshizora, Frostveil, Sylvaran and Stormreach rivers |

What the lore asks for and gets:
- a river curves around Aldmere's capital (the trunk is 1.8 km away);
- a river runs through Moraveil and through Ashira;
- Vharlen's capital stands above a great river (the Moraveil River);
- Hoshizora City is at a river mouth;
- Haneul's river runs below the pass;
- Greymoor is the flood basin where three rivers meet: the Whisperwood River, the Millbrook and the trunk do meet there.

The **River and grain** corridor runs beside the trunk for most of its length: 77% of the Aldmere → Velmark leg.

**Lakes:** the relief holds 21 lakes, all tarns and crater lakes in the high ground: Hoshizora, the Iron Hold–Cinderhole wall, Zarvan, the Dragon Spine, Nox and Gearholm. The lowland hollows are shallow and drain. Glacirra's Lake (world.md) is placed on Frostveil's largest lake (placement proposed). Moonwell Lake (Sylvaran) has no basin, so it has to be hand-placed.

## 5. Passes and the five corridors

| Pass | Where | Height | Class | Name |
|---|---|---|---|---|
| Karak Dûn Pass* | Aldmere → Iron Hold, at 67.3, 42.8 | 946 m | mountain pass | proposed |
| Ashen Mines Pass* | Iron Hold, on the Karak Dûn → Cinderhole → Dragon Spine road, at 72.8, 34.3 | 1,751 m | high pass, snowbound in winter | proposed |
| The Pass of the Red Gate* | Haneul, at 116.3, 22.3, right on Haneul's anchor ("the capital sits in the saddle of the pass") | 1,798 m | high pass | name proposed, the pass itself is lore |
| The Hill Road | the way into Ashira Vale, at 42.3, 61.3 | 343 m | easy | canon (gazetteer landmark) |

| Corridor | Legs (road km, highest point) | Verdict |
|---|---|---|
| River and grain | Brindlewick → Aldmere 7.7 km, 349 m · → Velmark 16.4 km, 305 m · → Lirian 6.3 km, 287 m | lowland, follows the trunk river |
| Mountain craft and oath | Aldmere → Karak Dûn 5.2 km, 946 m · → Cinderhole 17.5 km, 1,751 m · → dragon-bone monasteries 21 km, 1,751 m | two passes; the Ashen Mines Pass is the hard one |
| Sanctuary and memorial | Aldmere → Lothaniel 10 km, 366 m · → Ashira 12.7 km, 350 m | lowland forest road |
| Coastal weather and navigation | Lirian → Port Goldmere 21.3 km, 337 m · then 16 km by sea to the Naming Voyage harbour | passable, but Lirian is not on the coast (finding 1) |
| Desert glass and caravan | Mossdeep → Qadira 10.9 km · → Zaruma 14.6 km · → Zarvan 20.4 km, 608 m · → Thalassa 4.9 km | open desert; Zarvan's cities climb out of it |

All corridors are passable under 2,000 m, so no pass had to be carved. Every mainland settlement can be walked to from Brindlewick, to within 2.5 km. Road paths are in `corridors[].legs[].path`.

## 6. What it means for travel and encounters

- **The northern wall** (Iron Hold, Cinderhole and the Dragon Spine) is crossed only by the two corridor passes. Put waystations, Iron Hold patrols and pass-guard encounters there, and close the Ashen Mines Pass in winter (snow above 1,500 m at that latitude). Monsters of the high ground (drakes, fire giants, frost giants) belong above the passes, not on the road.
- **Gorges** cut by the drainage (`elevation.water`) are natural dungeon corridors and ambush sites in Shen-Lu, the Apu Highlands, Hoshizora and Zarvan.
- **River valleys** are the heartland's highways. The trunk, the Moraveil River and the Bastion River give the River and grain corridor, Moraveil's bridge and Vharlen's capital their water, and they are where river monsters spawn (river imps, drowned things in Greymoor and Lirian).
- **High tarns** (the 21 lakes) suit hidden shrines, undines and lake-dwelling bosses. Most are above 900 m.
- **Snow and alpine cells** give the cold-biome encounter tables, and the temperature estimate in `regionStats` can drive the weather.
- **Region scale:** a typical region is 150–370 km² and a corridor leg 5–22 km on the road. That is the walking budget Canon's 1 unit = 1 km implies.

## 7. Consistency findings (the region data is not changed)

1. **Lirian** is tagged `coast` and its lore is a sea lagoon, but in the atlas it is landlocked: the nearest sea is 25 km away. Either move its anchor to the east coast or make the lagoon a river lagoon on the trunk.
2. **Stormreach** is tagged `coast` ("cliffs rise straight from the sea"), but it is landlocked: the sea is 15 km away, behind the Calamity Steppe and Everdusk. Its cliff-towns stand at 2,810 m in the Black Peaks.
3. **Vharlen** and the **Quaking Lands** list `mountain`, but the atlas paints `plains` over most of them: only 9% and 3% of their land is above 1,000 m. The frontier passes toward the Nox Dominion and the "range of jagged mountains" barely exist, and Vharlen's lowest way to Nox never rises above 268 m.
4. **Kitsune Isles**: the lore says "steep volcanic islands", but the terrain (spirit, forest) keeps them under 300 m. Adding `volcanic` or `mountain` to map.terrain would raise them.
5. **Frostveil** has 27 km of fjord coast in the atlas and lore, but no `coast` feature.
6. **Ashira Vale's** ring of hills is only a few tens of metres. The Hill Road crosses at 343 m.
7. **Settlements high in the relief:** Karak Dûn 2,616 m (fits a dwarf hold), the Apu terrace cities 2,882 m (fits), the Zarvan garden cities 2,620 m (the lore puts them in terraced valleys) and the Stormreach cliff-towns 2,810 m (the lore puts them on sea cliffs).
8. **Everdusk** has 5% of its land above 1,000 m (the foothills of the Black Peaks and the Apu Highlands), although its terrain has no mountain.
9. **Moonwell Lake** has no basin in the relief.

The full list, with the numbers, is in `physical_map.json → checks / findings`.

## 8. Regenerating

```
node Tools/atlas/build_physical_map.js            # JSON + labelled PNG (labels need Playwright on the machine)
node Tools/atlas/build_physical_map.js --no-png   # JSON only
```

The build is deterministic. Two runs give byte-identical JSON and PNG (on one machine: the labels use whichever serif the browser finds, so the PNG lettering differs between machines; without Playwright the labeller falls back to headless Chrome or Edge, or the one named in `ASCEND_CHROME`). It takes about 5 s. All thresholds are in the `T` table at the top of the script and are echoed into the JSON under `tuning`. If the atlas, a region's anchor, radius or terrain, or a place changes, rerun the builder and reread the findings.

## 9. Turning it into Unity terrain (for the world-builder-engineer)

- `elevation.rows` is a 300 × 200 grid of metres at 0.5 km cells. For a Unity Terrain, resample it to a 2ⁿ+1 heightmap per tile, normalise by `elevation.max` and write 16-bit RAW. Add detail noise at runtime scale: a 0.5 km cell is far coarser than playable ground.
- `lakes[].surfaceM` are the water-plane heights. `rivers[].path` are the spline centrelines, with `drainageKm2`/`flowIndex` for width. `corridors[].legs[].path` are the road splines. `passes[]` mark where roads crest.
- `biomes.rows` and `regions.rows` are splat and region masks. The biome legend is in the JSON.
- At 1 unit = 1 km the continent is 150 × 100 km. Streaming it needs tiled terrains, about 1–2 km per tile. Ring 0's 200 m patch around Brindlewick is one corner of a single 0.5 km cell, so local scenes stay hand-built and only take their base height and slope from this map.

## 10. 3D relief

Two Blender renders of the same data, for a feel of the land rather than for measuring: [`maps/physical_relief_3d.png`](maps/physical_relief_3d.png) (the whole continent, oblique from the south) and [`maps/physical_relief_heartland.png`](maps/physical_relief_heartland.png) (Aldmere and Whisperwood up close). Heights are exaggerated 5.5x and smoothed by a 1.6-cell Gaussian (display only, the coastline is kept; sea depths a further 4x less), so ranges read as massifs. Colours follow the biome palette of `physical_map.png`, rivers are blue ribbons, lakes sit at `lakes[].surfaceM`, the sea runs past the frame, the sun comes from the north-west, and region names sit on parchment cards drawn over the render at each region's centroid.

```
blender -b --factory-startup -P Tools/blender/render_physical_relief.py -- --repo .
        [--exag 5.5] [--blur 1.6] [--step 1] [--res 1920x1080] [--samples 32] [--only whole|heartland] [--out-dir 10_World/maps]
```

Deterministic, about 5 minutes for both views on a software-GL container (`--step 2 --res 960x540` for a quick look). Rerun after `build_physical_map.js` changes the JSON.

## 11. Detail layer: smooth rivers, settlements, roads

Added for the Blender terrain and the Ring 0 diorama. **Every change to `physical_map.json` is additive**: all the fields above are unchanged (rivers keep `path`, corridors keep `legs[].path`), and the new fields only extend the file. The top-level `detail` block repeats this section's field notes and holds the tuning (`DET` in the builder).

### Rivers (`rivers[]`, 30 watercourses)
| Field | Meaning |
|---|---|
| `path` | unchanged: the simplified cell points |
| `pathCells` | every 0.5 km cell centre of the course, `[x, y]` km, source to mouth (the cell points as traced) |
| `pathSmooth` | the stair-stepped cell route smoothed (three corner-cutting passes) and resampled about every 0.25 km: `[x km, y km, water level m, width m, Strahler order]` |
| `order` | highest stream order on the river (Strahler; 1 = a headwater rill; every cell carrying at least 2.5 km² of drainage counts) |
| `endsIn` | `{type:"sea", name}` for a river that reaches the sea, `{type:"river", id}` for a tributary or stream (follow the chain to the sea) |

Water level is the depression-filled surface used for the flow routing, so it never rises downstream (lakes on the way are flat at their surface), and a main river ends at 0 m, one sea cell offshore. Width is `max(1.5, 1.4·√(rain-weighted drainage km²))` m: 2-3 m at the headwaters, up to 59 m at the Greymoor River's mouth. The smooth line is a cosmetic curve through the cell route and can sit up to about 0.2 km off the cell centres, so in Blender carve the valley along `pathSmooth` rather than trusting the bank cells.

### Settlements (`settlements[]`, 51)
The 50 places of `regions.json → map.places`, with the gazetteer text of the same name, plus **Aldmere**, the capital the corridors start from. It has no map place, so it is taken at its region anchor (its `source` says so; a place entry for it in regions.json would be the proper fix).

| Field | Meaning |
|---|---|
| `id`, `name`, `region` | slug of the name; the name as in regions.json; the region id |
| `x`, `y` | km, exactly as in regions.json (nothing moved) |
| `elevationM` | the heightmap interpolated bilinearly, so it sits on a terrain mesh built from `elevation.rows` |
| `fineElevationM` | the atlas relief at 0.125 km at the same point (a few metres different in lowland, up to hundreds in mountains) |
| `maxSlope300mPct` | steepest gradient of the fine relief within 300 m of the point, in percent (sea counts as 0 m) |
| `kind` | capital, city, town, village, hamlet, farmland, farmstead, camp, fort, fortress, port, monastery, eyrie, shrine, inn, market or glade (from the name and the gazetteer text) |
| `ring0` | `true` for Brindlewick (72.6, 60; 289 m; 4.0%) and Millbrook (76.1, 58.7; 328 m; 5.5%): both are on dry, gentle ground. `false` for the rest |
| `inWater` | `"sea"`, `"lake"` or `null` (a point test on the atlas land field and the lake cells) |

Settlements on a slope over 12% or in water are listed under `findings` and **not moved**: 21 are over 12%, and 2 stand in a lake cell (**Hoshizora City**, 40%, and the **Summer Court glades**, 16%). The ones whose lore asks for flat or low ground are the real gaps: Skjaldheim (32%), Haneul gate-towns (123%), Cinderhole (73%), Fox Shrine Isle and the spirit inns (15-18%), the ice-fishing villages (19%), the town on Thalassa's back (26%), Bastion outer ring (65%), Gearholm Undercity (99%) and the Bamboo Sea villages (199%). Where steep ground fits the lore (Karak Dûn, the Zarvan and Apu terraces, the Stormreach cliff-towns, the Heavenfolk eyries, the Ashen Mines camps, the dragon-bone monasteries, the sect foothill towns, the longhouse steads) the same list is only a reminder to build a pad. Ring 0 needs none.

### Roads (`roads[]`, 13)
One road per land leg of the five corridors (the coastal leg to the Naming Voyage harbor goes by sea and has no road). The cell route of `corridors[].legs[]` is joined to its two towns by the same grade-and-altitude cost with no height limit, smoothed the same way as the rivers and resampled about every 0.25 km, so a road runs the whole way from town to town. That makes it about 5 km longer than the leg's quoted `lengthKm`, which counts only the part between the two 2.5 km approach discs.

| Field | Meaning |
|---|---|
| `id`, `corridor`, `name`, `from`, `to` | `road_01`…, the corridor id, a descriptive name, the end settlement ids |
| `points` | `[x km, y km, heightmap m]` about every 0.25 km |
| `connects`, `connectsAtKm` | settlement ids within 0.75 km of the line, in travel order, and the km along the road at which each is reached |
| `lengthKm`, `climbM`, `highestM`, `highestAt`, `maxGradePct` | `lengthKm` is the whole road; the rest cover the corridor route only (not the lead-in to a town); the grade is the steepest 0.25 km step |
| `endsM` | the road's height at its two end settlements |
| `approachKm` | length of the lead-in from the corridor route to each end settlement |
| `passId` | the `passes[]` entry the road crosses, or `null` |
| `regions` | regions the corridor route runs through |
| `crossings` | river crossings (bridge or ford sites): `{river, at:[x,y], widthM}` |

| Road | Corridor | km | Highest m | Max grade % | Connects | Crossings |
|---|---|---|---|---|---|---|
| road_01 Brindlewick to Aldmere | River and grain | 12.9 | 352 | 5.2 | Brindlewick, Aldmere | 3 |
| road_02 Aldmere to Velmark | River and grain | 21.5 | 305 | 5.2 | Aldmere, Velmark ducal towns | 7 |
| road_03 Velmark to Lirian | River and grain | 11.5 | 287 | 2.8 | Velmark ducal towns, Lirian canal cities | 2 |
| road_04 Aldmere to Karak Dûn | Mountain craft and oath | 10.7 | 881 | 50.9 | Aldmere, Karak Dûn | 0 |
| road_05 Karak Dûn to Cinderhole | Mountain craft and oath | 22.7 | 1,699 | 45.9 | Karak Dûn, Cinderhole | 1 |
| road_06 Cinderhole to the monasteries | Mountain craft and oath | 25.7 | 1,449 | 34.2 | Cinderhole, dragon-bone monasteries | 1 |
| road_07 Aldmere to Lothaniel | Sanctuary and memorial | 15.5 | 363 | 4.7 | Aldmere, Canopy City Lothaniel | 1 |
| road_08 Lothaniel to Ashira | Sanctuary and memorial | 17.7 | 350 | 3.1 | Canopy City Lothaniel, Ashira | 2 |
| road_09 Lirian to Port Goldmere | Coastal weather and navigation | 26.2 | 337 | 3.4 | Lirian canal cities, Port Goldmere | 1 |
| road_10 Mossdeep to Qadira | Desert glass and caravan | 15.8 | 349 | 6.0 | Thimblefolk Mushroom Town, Oasis of Qadira | 1 |
| road_11 Qadira to Zaruma | Desert glass and caravan | 19.5 | 328 | 4.3 | Oasis of Qadira, Zaruma gold-road towns | 1 |
| road_12 Qadira to Zarvan | Desert glass and caravan | 25.0 | 617 | 36.0 | Oasis of Qadira, Zarvan garden cities | 2 |
| road_13 Qadira to Thalassa's back | Desert glass and caravan | 10.1 | 339 | 7.4 | Oasis of Qadira, the town on Thalassa's back | 0 |

Roads 04-06 and 12 climb faster than 15% on the cell-averaged heightmap, so they need switchbacks, stairs or tunnels when built (listed under `findings`). The corridor route of every road stays under 2,000 m; only the lead-ins to Karak Dûn (2,596 m) and Zarvan (2,583 m) climb past it.

### Checks, render and use
`checks[]` gains `rivers_smooth_downhill_to_water` (every smooth point is at or below the one upstream and every river reaches the sea), `ring0_settlements_gentle` and `roads_built`. `maps/physical_map.png` now draws the smooth rivers (width from `pathSmooth`), the roads, every settlement as a dot and Brindlewick as a red star, with Millbrook labelled.

For Blender: carve river valleys along `pathSmooth` (depth from the width, level from the water level), lay roads on `roads[].points` (their heights are the heightmap, so they sit on the mesh before any detail noise), stamp settlements at `x, y, elevationM` and use `maxSlope300mPct` to decide how big a flat pad to cut. Ring 0 is Brindlewick and Millbrook, 4.2 km apart.

## 12. Diorama

A stylised tabletop version of the continent for the world-map screen and promo art: [`maps/diorama_continent.png`](maps/diorama_continent.png) (whole continent), [`maps/diorama_heartland.png`](maps/diorama_heartland.png) (Aldmere and Brindlewick) and [`maps/diorama_spine.png`](maps/diorama_spine.png) (low angle over the Dragon Spine). Unlike §10 it is meant to look good, not to measure: heights are exaggerated 2.4x (continent view rendered at 2.0x with `--exag 2.0`), trees and houses are drawn well over true size, and the data is only changed in the picture (the JSON is read, never written).

```
blender -b --factory-startup -P Tools/blender/world_diorama.py -- --repo .
        [--only continent,heartland,spine] [--res 1920x1080] [--samples 24] [--up 3] [--seed 7] [--exag 2.4]
        [--outline] [--no-toon] [--no-labels] [--tree-cap 40000] [--cloud-cap 60] [--placement-only] [--report-json <path>]
```

- **Terrain.** The 0.5 km cells are upsampled 3x (a node every 1/6 km, 901 x 601 nodes) with Catmull-Rom cubic interpolation, so coasts and slopes have no stair steps. Biome colours meet in one short step (each biome's blurred weight is raised to the 20th power, so there is no wide smear), then painted over with value noise and a two-step clump contrast in forests. Mountains: three scales of ridged noise raise crests and a crest taper lowers everything between them, so peaks read as jagged spines; rock comes from slope, coloured by the sun (warm tan or ochre in the light, violet-grey in shadow, same terminator as the shader); snow follows height (from about 2,400 m) and slope with a ragged edge and one short step, steep faces stay bare. Lakes are flattened and tinted, river valleys are carved 7 m along `pathSmooth`, every settlement gets a levelled pad, and Brindlewick, Millbrook and Aldmere get a farmland patchwork round them.
- **Sea.** Pale cyan shallows, a mid blue, then deep `#3F86B0` by distance from land; one crisp foam line and a fainter outer line follow the shore. The colours are pre-divided by the cream light so the lit result is exactly the colour written. The waves are world-space noise (no sines, nothing tiles) and the only glint is a sparse noise sparkle. The slab skirt, plinth and table stay in the file but are hidden: an ocean plane around the map fades from deep blue to the horizon haze, so no cut edge shows.
- **Dressing.** Trees are merged low-poly meshes (conifer, broadleaf, palm, dead) chosen by biome, latitude and altitude on a jittered 0.24 km grid, kept off roads, rivers, settlements, steep and snowy ground, and capped at 40,000. The continent view swaps them for a forest LOD set (every third tree, 2.2x larger, stronger light and dark) so the Whisperwood reads as trees and not a green smear. Houses fill each settlement from `settlements[]` (3 to 70 by kind; Aldmere 70 with a keep, towers and a wall ring, Brindlewick 22 at 1.5x size with a hall and vermilion roofs; wall and roof colours by region family from `art_direction.md`). Settlements in water (Hoshizora City, the Summer Court glades) get no houses. The 13 roads and 30 rivers are ribbons draped on the surface, with a pale bank under each river. Clouds (60 clusters of 5 flat-bottomed cumulus lumps, capped) float about 2.4 units above ground over about 1,250 m, with a violet underside, so they do not read as snow caps; the spine view adds 13 painted cumulus banks in the sky.
- **Look.** Terrain is a hard two-tone cel: shadow tint `0.58, 0.56, 0.78` below N.L 0.32, cream light `#FFF1D6` above, from the normal against one sun in the north-west (the world light would otherwise lift every face above the terminator, so the terrain ignores the render's diffuse result). A cream rim (0.22) on the lit side of silhouettes, hard strata bands on rock, dressing on a softer three-stop ramp. The sky is a painted gradient (hazy horizon, pale cyan, deeper blue) slid to each shot's horizon. `--outline` adds Freestyle ink lines on trees, houses and clouds (about 90 s per frame; labels get outlined too). The spine view looks from the south-west (yaw -50, pitch 8) so west and south faces catch the light.
- **Labels.** Parchment plates (ink `#3A2A1C` on `#F3E6C8`, 14 px or larger: 16 px continent, 22 px elsewhere) are a camera overlay, so a peak cannot hide them. Each one is auto-nudged round its anchor (a ring of offsets, first free spot that overlaps no other plate, the cartouche or the frame edge) and has a short leader line and an ink diamond on the summit or town. The cartouche is 18.5% of the frame width (was 26%, so it no longer hides Nox Dominion) with a gold rule and a small diamond ornament. The lettering is Blender's bundled Inter (SIL OFL, shipped with Blender); no display serif is listed in `13_Production/third_party_assets.md` yet.
- **Determinism.** All randomness comes from `numpy.default_rng(--seed)`. `--placement-only` prints and writes (`--report-json`) the SHA-256 of the tree, house and cloud placement; two runs on seed 7 gave the same hash (`reports/world_diorama_2026-11-02.md`). A full run of three 1080p frames takes about 12 s on the GTX 1650.

**Revision 3 (director re-review).** Vertical exaggeration 4.2 to 2.4 (never above 3.0); high ridged octave cut about 40% and an above-1,500 m crest taper (eased toward a blurred copy, then compressed) so summits round into cone tips; strata removed from the main faces (only a faint bump on rock, and 3-ish faint bands on cliffs steeper than about 55 degrees below the snowline, via the vertex attribute B channel); terminator softened to a 0.06 linear step (cream rim 0.22 kept); cast shadows from mountains baked into lowland colour by a height-field march toward the sun; clouds placed above the highest ground within 1.4 km (no longer on the peaks); spine labels sit on the highest node near each anchor; five low conical islands far behind the range; Aldmere wall ring darkened. Placement hash (seed 7, exag 2.4): `7f2f359ea2a40d99d63e1e8fb4ddcf4b1d0f8794c66c23bbcdc5a51ade0c65c4` (the continent frame at exag 2.0 has its own cloud heights, hash `91f8a3b5...`).

**Revision 4 (individual cone peaks).** Per-peak cone stamps replace the ridged-noise massifs: the named peaks in `physical_map.json`, secondary peaks every 3.4-5.8 km along each range crest, and local maxima where a massif has no crest data (about 130 peaks, own rng `seed+888`). Each is a slightly concave cone (radius 3 km + 0.95 km per 1,000 m) with 5-9 radial ridges (ridged noise in azimuth), kept apart by saddles and blended into the range through a smoothstep foothill ramp of about 4 km (green lower slopes; rock only above about 850-1,300 m). The baked terminator uses a low-pass normal so each cone splits into one lit tan half and one violet half; shadow tint lightened to `(166,162,206)`; the bump is faint. Snow also caps the top ~18% of each peak's own height, with a ragged one-step edge. Far islands: 3 irregular, differently sized, seeded and hazier with distance. Clouds: cap 12, placed on range flanks, lifted above nearby ground. Placement hash (seed 7, exag 2.4): `de2922513342da18554ebb9248e0ac0edfb034049de97853346e12da582eba55` (continent frame at exag 2.0: `fc9372f3...`).

**Revision 5 (lakes and foothills).** Lakes are kept only on flat ground: where the stamped relief under a lake is steeper than about 8% the water is dropped (the cell becomes foothill green) and the basin is not flattened, so no water sits on a slope. Volcanic ground is lighter, mountain/volcanic ground below the rock line blends to green foothill, and the baked cast-shadow multiply is gentler (0.84, 0.83, 0.95), so no mud brown at mountain bases. Placement hash (seed 7, exag 2.4): `28af1aab8d66c27e2dba544ef12697f173758c92e936f081b4d12b217dec3a20` (houses 701 now that dropped lakes free settlement cells; continent frame at exag 2.0: `557e8745...`). Supersedes the Revision 4 hash.
