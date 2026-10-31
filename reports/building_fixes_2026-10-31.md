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
