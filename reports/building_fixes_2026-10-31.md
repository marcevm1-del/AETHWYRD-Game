# Building fixes 2026-10-31 (design review B2, B3, B4)

Owner: environment-artist. Source: [[design_review_2026-10-25]] items B2–B4, [[art_direction]] §4.2. Not committed.

## What changed

| Fix | File · function / key |
|---|---|
| B2 Domes only on civic and temple types in Sunscar and Zarvan (6 of 30 catalogue types: guild hall, town hall and library towers, domed hall, temple, bathhouse) | `styles.py` desert and garden: `domes` extra removed, `remap` temple → `domed_temple`, bathhouse → `domed_bathhouse`; `archetypes.py` `domed_temple`, `domed_bathhouse`, `_civic_dome` |
| B2 Mossdeep working buildings | `styles.py` mushroom `remap`; `archetypes.py` `mushroom_smithy` (toadstool forge, stone chimney with ember cap, leaf-thatch forge), `mushroom_barn`, `mushroom_stable` (leaf thatch on stalk posts), `mushroom_gate` (two toadstool towers under a root arch), `hedge_wall` (hedge on roots with toadstools) |
| B3 Iron Hold: bronze bands 2x (0.44 m), copper `roof_b` on 1 roof in 3, lit windows `#FF8C26`, ember-capped forge chimneys | `styles.py` dwarven (`roof_keys`, `band="none"`, `bronze_bands`, `window_glass`, palette); `ornaments.decorate` `bronze_bands`; `construct.window` (`window_glass`); `construct.chimney` forge ember cap |
| B3 Umbravel: stone `#5A5068`, lit violet windows, silk lanterns on all four facades | `styles.py` gothic `window_glass`, umbravel palette; `ornaments.silk_lantern` and the `silk` branch |
| B3 Greymoor: `wall_c` `#8A7A62`, two `#BFFF8C` lanterns per front, doors `#4F7A6A` | `styles.py` greymoor; `ornaments.decorate` `facade_lanterns` |
| B3 Fanghold: red/blue cloth bands on eaves and doors of every building, a banner on every front, banners 2x, stone `#B8A58A` | `styles.py` steppe (`cloth_bands`, `facade_banners`, `banner_scale=2`); `ornaments.decorate`; `construct.door` (cloth jambs and lintel); `construct.banner` (scale) |
| B4 Whisperwood: warmer plaster, moss on roofs, climbing ivy, two lanterns per front, thatch on ~1 roof in 3 | `styles.py` whisperwood (`cover_mix`, extras, palette); `construct.Ctx` (`cover_mix`); `ornaments.decorate` `climbing_ivy` |
| B4 Aldmere: ashlar ground floors, slate roofs dominant, royal blue `#3357AD` and gold banners (1.7x), finials on civic-sized roofs | `styles.py` aldmere; `ornaments.decorate` `facade_banners`, `civic_finials` |
| Tooling: `--types`, `--sheet-dir`, `--out-dir`, `--no-blend` | `Tools/blender/build_building_library.py` |
| Docs | `13_Production/building_system.md` |

Protected: storybook pitch 54, turrets and flower boxes (P1), Mossdeep toadstools (P2), Frostveil untouched (P5).

## Before / after

| Region | Before | After | Render (s, detail high) |
|---|---|---|---|
| Sunscar | [before](building_fixes_2026-10-31/before/sunscar.png) | [after](building_fixes_2026-10-31/after/sunscar.png) | 101 |
| Zarvan | [before](building_fixes_2026-10-31/before/zarvan.png) | [after](building_fixes_2026-10-31/after/zarvan.png) | 155 |
| Mossdeep | [before](building_fixes_2026-10-31/before/mossdeep.png) | [after](building_fixes_2026-10-31/after/mossdeep.png) | 88 |
| Iron Hold | [before](building_fixes_2026-10-31/before/iron_hold.png) | [after](building_fixes_2026-10-31/after/iron_hold.png) | 91 |
| Umbravel | [before](building_fixes_2026-10-31/before/umbravel.png) | [after](building_fixes_2026-10-31/after/umbravel.png) | 101 |
| Greymoor | [before](building_fixes_2026-10-31/before/greymoor.png) | [after](building_fixes_2026-10-31/after/greymoor.png) | 104 |
| Fanghold | [before](building_fixes_2026-10-31/before/fanghold.png) | [after](building_fixes_2026-10-31/after/fanghold.png) | 82 |
| Whisperwood | [before](building_fixes_2026-10-31/before/whisperwood.png) | [after](building_fixes_2026-10-31/after/whisperwood.png) | 121 |
| Aldmere | [before](building_fixes_2026-10-31/before/aldmere.png) | [after](building_fixes_2026-10-31/after/aldmere.png) | 105 |

After sheets show only the `--types` set per region (8 buildings each), not the full catalogue.

## Commands run

- `python3 -m py_compile` on the six touched .py files: all OK (`__pycache__` removed).
- A Blender geometry smoke test (no render) of every remapped type in 12 regions: all built; `catalogue("desert")` still lists 30 types.
- `blender -b --factory-startup -P Tools/blender/build_building_library.py -- --regions <r> --types <list> --sheet-dir reports/building_fixes_2026-10-31/after --out-dir <scratchpad>/team/blend` at detail high: 9 regions, 82–155 s each. Greymoor, Whisperwood and Aldmere were rendered a second time after the lantern and banner tweaks.

## Left for others / notes

- **technical-artist:** emission strength lives in `blend.py` (3.0 for every glowing key). That meets Iron Hold's ≥ 2.5, but the review asks for 2.0 in Umbravel and Greymoor, and the globe lanterns clip to white in these renders. A per-key or per-style strength is theirs. Orange light spilling onto the ground is a runtime light, not mesh.
- Whisperwood thatch is a 1-in-3 chance per building, so the 8 sampled buildings show 4 thatched roofs.
- Aldmere "civic" finials use a footprint of at least 115 m² as a stand-in for civic buildings (the town hall, guild hall and temple qualify), because ornaments cannot see the archetype.
- The new extras (`bronze_bands`, `cloth_bands`, `facade_banners`, `facade_lanterns`, `climbing_ivy`, `civic_finials`) are in `ornaments.py`, and the window glow, ember cap, cloth door jambs, banner scale and `cover_mix` are in `construct.py`. The task allowed these files when needed.

## B1: shared props follow the family (wave 2)

Owner: environment-artist. Source: [[design_review_2026-10-25]] B1. Not committed.

| Fix | File · function / key |
|---|---|
| Market stall canopy always `cloth_a` (was a random pick of three), posts `trim` | `archetypes.py` `market_stall` |
| Lamp post per family: paper lantern on a wooden post (hoshizora, shenlu, haneul), brass gas lamp (clockwork), iron basket of glowing coal (dwarven), two silk lanterns on an iron crook (gothic), green fen lamp in a cage on a crooked pole (fenland); the iron lamp stays the default | `archetypes.py` `LAMP_FORMS`, `paper_lamp_post`, `gas_lamp_post`, `coal_basket_post`, `silk_lamp_post` (reuses `ornaments.silk_lantern`), `fen_lamp_post` |
| Wall segment: battered adobe with rounded merlons, vigas, spouts and round end buttresses (desert); ochre brick with turquoise tile bands and turquoise-capped merlons (garden); nordic keeps the log palisade it already had | `archetypes.py` `wall_segment`, `adobe_wall`, `banded_brick_wall` |
| Fountain basin and column in the family masonry; adobe families use their wall plaster; garden gets a turquoise tile rim | `archetypes.py` `fountain` |
| Mill: desert and garden → wind-catcher tower beside a mill house; nordic → watermill with an overshot wheel and flume; dwarven → water-wheel forge (wheel, flume, axle, forge chimney, glowing hearth); clockwork and gothic → dropped from the catalogue | `archetypes.py` `MILL_FORMS`, `MILL_DROPPED`, `wind_catcher`, `watermill`, `water_forge`, `flume`, `catalogue` |
| Hoshizora granary → raised kura storehouse (stone base, namako-tiled dark skirt, white plaster, barred windows, tile gable roof with crest) | `styles.py` hoshizora `remap` `granary` → `kura`; `archetypes.py` `kura` |
| Docs | `13_Production/building_system.md` (new B1 table) |

Garden's wind-catcher is a call of mine: Zarvan is the "dry mountain wind" garden city and the wind-catcher fits it better than dropping the mill.

### Before / after (B1 types: market_stall, lamp_post, fountain, wall_segment, mill, granary)

| Region | Before (full catalogue) | After | Render (s, detail high) |
|---|---|---|---|
| Hoshizora | [before](building_fixes_2026-10-31/b1_before/hoshizora.png) | [after](building_fixes_2026-10-31/b1_after/hoshizora.png) | 55 |
| Iron Hold | [before](building_fixes_2026-10-31/b1_before/iron_hold.png) | [after](building_fixes_2026-10-31/b1_after/iron_hold.png) | 48 (re-run with the wheel moved) |
| Sunscar | [before](building_fixes_2026-10-31/b1_before/sunscar.png) | [after](building_fixes_2026-10-31/b1_after/sunscar.png) | 39 |
| Frostveil | [before](building_fixes_2026-10-31/b1_before/frostveil.png) | [after](building_fixes_2026-10-31/b1_after/frostveil.png) | 42 (re-run with the wheel moved) |
| Zarvan | [before](building_fixes_2026-10-31/b1_before/zarvan.png) | [after](building_fixes_2026-10-31/b1_after/zarvan.png) | 50 |
| Gearholm | [before](building_fixes_2026-10-31/b1_before/gearholm.png) | [after](building_fixes_2026-10-31/b1_after/gearholm.png) (no mill: dropped) | 38 |

Whisperwood (default family) rendered with the same types to a scratch folder: iron lamp, grey stone fountain, stone wall, sail windmill and round granary unchanged; only the stall canopy rule applies.

## Code-review fixes on 7c1cc44 (wave 2)

| Finding | Fix |
|---|---|
| 1. `facade_banners` z-fought with banners the archetype already hangs | tavern (when `banners`), guild hall, watchtower (when `banners`) and barracks put `own_banners` in `c.notes` before `block()`; `ornaments.decorate` skips `facade_banners` then |
| 2. Dragon Spine lost its bands and inherited Iron Hold's palette | dwarven family restored to its pre-wave-1 values; the bronze bands, `band="none"`, copper `roof_b` 1 in 3, lit windows and ember colours moved to the `iron_hold` region override |
| 3. Ember cap on every smithy, extra rng draws | new style flag `ember_cap` (default False, True for Iron Hold); other forge chimneys get the old glowing slab again, with no extra draws |
| 4. Facade lanterns hit the door lantern on narrow fronts | lanterns at `max(w/4, w/2 - 0.75)`; fronts under 5.5 m keep only the left one (door lanterns hang right of the door) |
| 5. `--no-blend` temp folder leaked on failure | `build_building_library.py`: the rmtree is in a `finally` |
| Lantern colours (technical-artist) | Greymoor `lamp` (0.52, 1.0, 0.26) (#BFFF8C as linear); Umbravel `lamp` violet (0.55, 0.32, 1.0) |

Re-rendered after sheets: iron_hold, umbravel, greymoor, fanghold (cottage, house, inn, smithy, shop, temple, tavern, watchtower; 402 s for the four) and whisperwood, aldmere (cottage, house, townhouse, manor, inn, guild_hall, town_hall, temple; 236 s for the two), with blend.py's per-key glow strengths.

### Checks

- `python3 -m py_compile` on archetypes, styles, construct, ornaments and build_building_library: OK; `__pycache__` removed.
- Geometry smoke test (no render, Blender 5.2.3) of all 28 core types in 18 regions, hashed against the same test on 7c1cc44: 0 errors. Every changed hash is an intended change: market stall everywhere, smithy everywhere (forge slab back), Dragon Spine (family restored, roof-key draw back to two keys), homes and civic buildings in Whisperwood and Greymoor (lantern spacing), banner archetypes in Fanghold, Calamity Steppe and Aldmere, and the B1 props in the named families. Untouched types in untouched families are identical. Gearholm and Umbravel catalogues: 28 → 27 (no mill).

### Notes

- `--types` overrides `catalogue()`, so a dropped type is still built if named: leave `mill` out for Gearholm, Cinderhole, Umbravel and Nox Dominion (done for the Gearholm sheet).
- Iron Hold's fountain water is orange because the dwarven `glass` key (also used for windows) is orange; a separate water key would need a palette change across families.
- The preview camera crops the top of the tall, thin lamp posts a little (`preview.camera` framing).
