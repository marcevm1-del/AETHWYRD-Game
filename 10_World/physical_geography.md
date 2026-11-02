# Physical Geography of Aetheria

> **Source of truth:** the atlas (`Tools/atlas/aetheria_atlas.html`, coastline seed 1207) for the coast, region borders and where the land is rough; `Data/World/regions.json` for each region's anchor, radius, terrain and places. This page and `Data/World/physical_map.json` add **height, water and climate** on top of them. They move no coast, region or town.
> **Generated:** `node Tools/atlas/build_physical_map.js` writes `Data/World/physical_map.json` and `10_World/maps/physical_map.png`. Never edit the JSON by hand.
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

The build is deterministic. Two runs give byte-identical JSON and PNG. It takes about 5 s. All thresholds are in the `T` table at the top of the script and are echoed into the JSON under `tuning`. If the atlas, a region's anchor, radius or terrain, or a place changes, rerun the builder and reread the findings.

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
