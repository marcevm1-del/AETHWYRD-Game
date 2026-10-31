# Regional Building System (Blender)

> **Built (Blender only for now).** A procedural, high-poly building generator. Each building is written once as an *archetype* and rendered in any of **21 architectural families**. Each of the **48 gazetteer regions** picks a family and adds its own colours, snow, ruin and ornaments. Code: `Tools/blender/ascend_buildings/` (a Blender add-on). Libraries: `Art/Blender/BuildingLibrary/<region>.blend` (generated, not in git). Contact sheets: `13_Production/screenshots/buildings/<region>.png`. Brindlewick's placed town still uses the earlier low-poly kit ([[town_buildings]]).

## What it is

- **Reusable.** Every building in every region library is a Blender asset, with a catalog, tags and a preview. Drag one from the Asset Browser into any scene.
- **Adjustable.** Every building keeps its settings: building type, region, seed, detail, width, depth and floors. Change any of them in the **Ascend** sidebar and it rebuilds in place.
  - **Restyle selection** moves a whole street to another region's style in one click.
  - Materials are shared per region (`AB_<region>_<key>`). Tinting one material, such as Lirian's `wall_a`, recolours that wall paint in every Lirian building.
- **High-poly.** The detail is real geometry:
  - Every roof tile, shingle, slate, thatch bundle, barrel tile or leaf scale is its own bevelled, slightly irregular piece.
  - The same goes for every wall stone, brick, log, board and clapboard.
  - Timber frames, window frames, shutters, sills, flower boxes, doors and ironwork are bevelled solids.
- **Light to work with.** Repeated parts are geometry-nodes instances of shared part meshes (the `AB_Parts` collection, `AB_Instancer` group). A town of them stays fast in the viewport and small on disk.
  - The **Realize** button turns them into real geometry for export.

| Example (realized) | Triangles |
|---|---|
| Whisperwood house | ~430k |
| Whisperwood inn | ~1.2M |
| Shen-Lu pagoda | ~560k |
| Gearholm guild hall (every brick) | ~2.9M |

The same buildings unrealized are 25k–180k faces plus instances, and each builds in 0.1–0.8 s.

## Using it in Blender

1. **Install the add-on once.** Zip the folder:
   ```powershell
   Compress-Archive -Path Tools\blender\ascend_buildings -DestinationPath $env:TEMP\ascend_buildings.zip -Force
   ```
   Then in Blender: *Edit ▸ Preferences ▸ Add-ons ▸ ⌄ ▸ Install from Disk…*, pick the zip and tick **Ascend Buildings**.
2. **Add a building.** *View3D ▸ Sidebar (N) ▸ Ascend*: choose a building and a region, then **Add Building**. It appears at the 3D cursor; each click advances the seed.
3. **Adjust.** With a building selected, change its building type, region, width, depth, floors, detail or seed; it rebuilds live. **Rebuild** reapplies the current settings and **Reroll** tries the next seed.
4. **Restyle.** Select any number of buildings, then **Restyle Selection**: they rebuild in another region's style. A region can swap a type for its own signature, so a Frostveil *house* becomes a longhouse and a Mossdeep *shop* becomes a toadstool.
5. **Use the libraries.** *Preferences ▸ File Paths ▸ Asset Libraries ▸ +*: add `Art/Blender/BuildingLibrary` (and `Art/Blender/AssetLibrary_CC0` for the props). Catalogs are *Ascend Buildings ▸ Family ▸ Region* and *CC0 ▸ Pack*.
6. **Export.** Select the buildings, click **Realize**, then export as usual. **Instance** switches them back.

**From Python:** `generate.building("inn", "lirian", seed=3)`; `generate.regenerate(obj, floors=3)`; `generate.restyle(obj, "frostveil")`.

**Rebuilding the libraries:**
```bash
blender -b --factory-startup -P Tools/blender/build_building_library.py -- --all
```
- With no arguments it builds one region per family.
- `--regions a,b` picks specific regions; `--variants 3` adds seeds.
- `--types smithy,barn,temple` builds only those archetypes (regional remaps still apply) for a quick look-dev pass; without it every region builds its whole catalogue.
- `--sheet-dir <dir>` and `--out-dir <dir>` move the contact sheets and the `.blend` libraries (and their preview tiles); `--no-blend` throws the `.blend` away.
- About 20 s and 40 MB per region; all 48 take about 15 minutes.

## Building types (archetypes)

The 28 core types cover what the town guide in [[anime_town_places_and_taverns]] lists for villages, frontier towns and cities. Signature types are added per family.

| Group | Types |
|---|---|
| Homes | cottage, house, townhouse (gable to the street, balcony), manor (wings, corner tower), stilt house, longhouse, longhouse hall |
| Trade | shop (shopfront, awning, icon sign), inn (wing, porch, benches, sign), tavern, warehouse (hoist beam), market stall |
| Craft and farm | smithy (open forge, chimney, anvil, quench barrel), barn, stable (stalls, trough), granary, mill (watermill or windmill by region) |
| Civic, learning, faith | guild hall (tower, banners), town hall (clock tower), library, bathhouse (cupola), temple (nave and bell tower), shrine |
| Defence | watchtower (lookout), gatehouse (arch, portcullis), wall segment (stone wall or log palisade by region), barracks (weapon rack) |
| Infrastructure | well, bridge (stone arch or timber), fountain, lamp post |
| Signatures | yurt, large yurt, tent, toadstool house, toadstool tower, toadstool shop, toadstool cluster, toadstool forge, toadstool barn, leaf-thatch stable, toadstool gate, hedge wall, pagoda, torii gate, paifang gate, lighthouse, stepped pyramid, domed hall, domed temple, domed bathhouse, adobe tower, tree house |

The adjustable parameters are width, depth and floors (0 keeps the type's default), seed, and detail (high or medium). They're stored on the object as `ab_*` custom properties.

## Families and regions

| Family | Walls · roof · signature | Regions |
|---|---|---|
| Storybook half-timber | Timber frame over pastel plaster, steep flat-tile roofs in blue/red/green/slate, shutters, flower boxes, ivy | Whisperwood, Aldmere, Moraveil, Strife Marches (rubble ground floors, muted), Ashira Vale (bunting) |
| Fen stilt village | Weathered boards on stilts with ladders, reed thatch, rope, moss, green-glow lanterns | Greymoor, Quaking Lands (on footings) |
| Elven living wood | Bark columns and pale panels, curved leaf-scale roofs, onion towers, round windows, crystals, vines, tree house | Sylvaran, Everdusk (dusk gold) |
| Thimblefolk toadstools | Spotted caps on bulging stalks, round doors and portholes; a toadstool forge with a stone chimney, a toadstool barn, a leaf-thatch stable, a gate of two toadstool towers under a root arch, a hedge wall | Mossdeep |
| Lagoon canal city | Pastel stucco over a rusticated ground floor, quoins, arched shuttered windows, low barrel-tile hips, funnel chimneys, balconies, mooring poles | Lirian |
| Wind-plains | Rubble stone, plank roofs, banners; yurts and tents | Fanghold, Calamity Steppe, The Maw |
| Dwarven basalt halls | Black ashlar, slate and bronze, rune-lit doors, slit windows, forge chimneys, buttresses | Iron Hold, Dragon Spine (bone ribs, prayer flags) |
| White-stone duchies | White ashlar, blue slate hips, quoins, arches, banners, finials | Velmark, Vharlen (grey, red banners), Stormreach (dark slate, metal roofs, lightning rods), Bastion (sandstone), Aurumdeep (gold, ruined) |
| Star-sky cedar halls | Post-and-panel walls on stone platforms, curved tiled roofs with upturned eaves and raised ridges, lattice windows, sliding doors, paper lanterns, pagoda, torii | Hoshizora, Kitsune Isles (vermilion) |
| Hundred-stair sect halls | Red columns, glazed green/gold barrel tiles, strong upturn, pagoda, paifang | Shen-Lu |
| Sky-gate hanok | Dancheong-painted beams, grey tiles, gentle curves | Haneul |
| Fjord longhouses | Log walls with corner ends, turf roofs under snow, dragon-board gables | Frostveil, Whitewater Reach (plank roofs) |
| Glass-desert adobe | Mud walls, flat roofs with parapets, vigas, horseshoe arches, awnings, pots; domes only on civic and temple buildings | Sunscar, Zaruma (red mud, adobe towers) |
| Garden cities | Ochre brick, turquoise tile bands, pointed iwans; onion domes only on civic and temple buildings | Zarvan |
| Salvage coast | Clapboard and ship timber on stilts, portholes, nets, buoys, lighthouses | Goldmere Coast, True-Name Isles, Hollow Sea (glow lamps), Lustrine Shores (moon-glass lamps), Dunewhale Drift (canvas) |
| Temple jungle | Carved stone with painted bands, steep palm thatch, terraces, stepped pyramids | Xochitl Mire (stilts, flowers), Lumbaya (ruined) |
| Carved-mountain terraces | Fitted stone, trapezoid doors and windows, steep thatch, textiles | Apu Highlands |
| Clockwork tiers | Red brick, copper roofs with standing seams, gears, pipes and boilers | Gearholm, Cinderhole (soot, ember lamps) |
| Dark spires | Black-violet ashlar, steep slate, pointed arches, glowing windows, webs | Umbravel (silk lanterns), Nox Dominion (obsidian, red glow) |
| Heavenfolk marble | White marble, gold trim, domes, columns, crystals, wings | Heavenreach (snow), Sky Archipelago (ruined) |
| Labyrinth stone | Grey blocks, glowing runes, crenellations, ruin | Great Labyrinth (three bands with their own glow), Root of the World (crystal), Vesper (red stone) |

**Where the region identities come from:** each one follows [[gazetteer]]. Examples: Greymoor's ironwood stilts, Lirian's canals and glass, Fanghold's yurt camps, Karak Dûn's basalt and forge-fire, Frostveil's turf-roofed longhouses, Zaruma's mud-brick towers, Stormreach's lightning rods and Thimblefolk's toadstools.

**Proposal:** the family-per-region table is proposed in Canon §6.

### Signature and palette rules (design review 2026-10-25, B2–B4)

- **A signature goes on at most 1 building in 4.** In the desert and garden families only the guild hall, town hall and library towers, the domed hall, and the temple and bathhouse (remapped to `domed_temple` and `domed_bathhouse`) carry a dome or onion: 6 of the 30 catalogue types. Flat roofs no longer get a dome each.
- **Mossdeep** remaps every working building too: `smithy` → `mushroom_smithy`, `barn` → `mushroom_barn`, `stable` → `mushroom_stable`, `gatehouse` → `mushroom_gate`, `wall_segment` → `hedge_wall`.
- **Dark families glow.** `window_glass="window_glow"` lights the panes (dwarven forge orange `#FF8C26`, gothic violet, Nox red). Forge chimneys carry an ember cap. Iron Hold has 0.44 m bronze bands (`bronze_bands`) and copper `roof_b` on 1 roof in 3. Umbravel's stone is `#5A5068`, with silk lanterns on all four facades.
- **Greymoor**: `wall_c` `#8A7A62`, two green lanterns on every house front (`facade_lanterns`), painted doors `#4F7A6A`.
- **Wind-plains**: red and blue cloth bands under every eave and round every door (`cloth_bands`), a banner on every front (`facade_banners`), banners 2× (`banner_scale`), stone `#B8A58A`.
- **Whisperwood vs Aldmere.** Whisperwood: warmer plaster, moss on roofs, climbing ivy, two lanterns per front, thatch on about 1 roof in 3 (`cover_mix`). Aldmere: ashlar ground floors, slate roofs (mostly slate grey), royal-blue `#3357AD` and gold banners, and finials on roofs of 115 m² or more (civic-sized). Both keep pitch 54, turrets and flower boxes.
- Emission strength is set in `blend.py` (3.0 for every glowing key) and belongs to the technical-artist.

## How it's built (for changes)

| Module | Job |
|---|---|
| `geo.py` | Mesh accumulator: rounded boxes, lathes, prisms, patches; instance placements become carrier vertices |
| `parts.py` | The shared detail parts: tiles, shingles, slates, thatch, barrel tiles, leaves, stones, ashlar, bricks, planks, logs, clapboards, tufts, flowers, ivy, spots |
| `styles.py` | Palettes, the 21 families, the 48 regions and their overrides (`resolve(region)` merges them) |
| `construct.py` | Engine: walls with real openings, 12 wall constructions, arches and their spandrels, windows, doors, footings, roofs and covers, ridges, chimneys, signs, awnings, banners |
| `ornaments.py` | Regional ornaments, driven by each style's `extras` |
| `archetypes.py` | The building types, written once and styled by region |
| `blend.py` | Materials, the parts registry, the instancer, writing objects |
| `generate.py` | The API |
| `library.py` | Asset libraries and contact sheets |
| `__init__.py` | The add-on UI |
| `preview.py` | The look-dev rig |

- **Adding a region:** add one line to `REGIONS` (family plus overrides).
- **Adding a family:** add one `FAMILIES` entry (walls, roof, cover, windows, doors, footing, ornaments, palette, remaps).
- **Adding a building type:** write a function in `archetypes.py` from `block()`, `tower()` and `round_block()`, and register it.

## Not done yet

- **Unity.** None of this is in Unity yet, by request. The next step would be baking each building to a game-weight mesh: the low-poly kit's budget plus normal maps baked from these high-poly versions, with LODs and colliders.
- **Detail levels.** "Medium" only trims bevel segments; a real game-weight level (merged tiles, flat walls) is still to write.
- **Interiors.** They are hollow, and open-fronted stalls and forges have no interior props beyond the forge.
- **Third-party props.** The CC0 packs in [[third_party_assets]] are a separate asset library for dressing (rocks, bushes, hedges, crates, ruins, the Kenney modular kit). They don't recolour by region yet.
