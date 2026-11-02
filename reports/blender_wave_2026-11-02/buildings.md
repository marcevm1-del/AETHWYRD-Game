# Buildings: blender wave 2026-11-02

Owner: environment-artist. Source: [[design_review_2026-10-31]] B1, B3, B4, N1, N2, N6, plus the coordinator's glow-saturation note. [[art_direction]] §3.1 and §4.2 apply. Blender only, not committed.

## Fixes and where they live (`Tools/blender/ascend_buildings/`)

| Fix | File · function / key |
|---|---|
| B1 Lamps. Desert: a pierced-brass lantern on a 2.4 m adobe pillar with a rounded cap. Garden: a turquoise-glazed lantern on a 2.6 m ochre brick column. Nordic: an iron lantern under a shingle hood on a 2.5 m log post | `archetypes.py` `brass_lantern_post`, `glazed_lantern_post`, `hooded_lantern_post`, `LAMP_FORMS` |
| B1 Granaries. Desert: three beehive mud domes, 2.5–3.5 m, in `wall_a` `#E0B885`. Dwarven: a squat basalt silo with bronze bands, lit slits, a door lantern and a copper cone `#B87333`, with no thatch | `archetypes.py` `GRANARY_FORMS`, `beehive_granary`, `basalt_silo`, `_prof_r`; `styles.py` `roof_copper` |
| B1 Hoshizora wall: white plaster `#F2EDE0` on a 0.8 m stone base, with a tiled coping roof `#3D4757` | `archetypes.py` `plaster_wall` (from `wall_segment`) |
| B1 Fountains. Hoshizora family: a low stone basin with a wooden spout. Nordic: a covered well-house with a turf roof | `archetypes.py` `FOUNTAIN_FORMS`, `stone_basin`, `well_house` |
| B3 Umbravel `lamp` amber, linear (1.0, 0.48, 0.09); `window_glow` violet `#C77AFF`, linear (0.571, 0.195, 1.0) | `styles.py` umbravel |
| B3 Iron Hold forge mouth: a 1.2 × 0.8 m `ember` glow on a low forge in the smithy's open bay. Warm points per building: lit slits, door lamp, ember chimney cap; the granary now has lit slits and a lamp | `styles.py` `forge_mouth`; `archetypes.py` `smithy` |
| B4 Aldmere banners: gold field `#D9A833` with a royal-blue charge | `styles.py` `banner_keys`, `banner_field`; `construct.banner` |
| N1 A `water` key in every family (default `#7FB3D0`, Iron Hold `#5E8FA8`), used by fountains, wells, quench barrels and flumes | `styles.py` `BASE_PALETTE`, iron_hold; `archetypes.py` `fountain`, `well`, `smithy`, `mushroom_smithy`, `flume` |
| N2 The camera fits the shorter (vertical) side; sheets use margin 1.2 | `preview.camera(aspect=)`, `contact_sheet`; `library.build_region` |
| N6 Steppe banners: at most 1 facade banner per front, none under 40 m²; yurts keep their pole banner | `styles.py` steppe `facade_banner_cap`, `facade_banner_min_area`; `ornaments.decorate` |
| Glow saturation is at least 50% sRGB: Greymoor `lamp` (0.388, 1.0, 0.119), Hoshizora `lamp` (1.0, 0.425, 0.119), clockwork `lamp` (1.0, 0.613, 0.119), all linear | `styles.py` |

## Before / after (plain preview, detail high, yaw -32)

| Region | Types | Before | After | s (before / after) |
|---|---|---|---|---|
| Sunscar | lamp_post, granary, fountain, wall_segment, smithy, house | [before](blender_wave_2026-11-02/buildings/before/sunscar.png) | [after](blender_wave_2026-11-02/buildings/after/sunscar.png) | 87 / 47 |
| Zarvan | same | [before](blender_wave_2026-11-02/buildings/before/zarvan.png) | [after](blender_wave_2026-11-02/buildings/after/zarvan.png) | 57 / 51 |
| Frostveil | same | [before](blender_wave_2026-11-02/buildings/before/frostveil.png) | [after](blender_wave_2026-11-02/buildings/after/frostveil.png) | 39 / 40 |
| Hoshizora | same | [before](blender_wave_2026-11-02/buildings/before/hoshizora.png) | [after](blender_wave_2026-11-02/buildings/after/hoshizora.png) | 54 / 45 |
| Iron Hold | same | [before](blender_wave_2026-11-02/buildings/before/iron_hold.png) | [after](blender_wave_2026-11-02/buildings/after/iron_hold.png) | 66 / 47 |
| Umbravel | house, cottage, inn, smithy | [before](blender_wave_2026-11-02/buildings/before/umbravel.png) | [after](blender_wave_2026-11-02/buildings/after/umbravel.png) | 79 / 50 |
| Fanghold | house, cottage, inn, smithy | [before](blender_wave_2026-11-02/buildings/before/fanghold.png) | [after](blender_wave_2026-11-02/buildings/after/fanghold.png) | 60 / 38 |
| Aldmere | inn, guild_hall, town_hall | [before](blender_wave_2026-11-02/buildings/before/aldmere.png) | [after](blender_wave_2026-11-02/buildings/after/aldmere.png) | 62 / 42 |

Before sheets were rendered from a clean `origin/main` worktree (ee7f861) with its own `build_building_library.py`. Because of N2, the after framing is looser: wide buildings sit smaller in their tiles. Greymoor and Gearholm lamps were checked on a single-type look-dev render only (scratchpad), with no sheet.

## Checks

- `py_compile` on every touched module: OK (`__pycache__` removed).
- Build-only smoke test of every new form at high and medium detail in 11 regions: all built.
- Geometry hash (28 core types × 18 regions, 522 keys) against `origin/main`: 0 errors. The differences are all intended: water key (fountain, well and smithy in all 18; mill in Frostveil, Iron Hold and Dragon Spine); B1 lamp, granary and wall in the named families; Iron Hold smithy (forge); Aldmere banner types; steppe banner types in Fanghold and Calamity Steppe. Palette-only changes do not alter hashes.

## Notes and leftovers

- Iron Hold `roof_b` (0.72, 0.45, 0.20) still renders straw-tan on 1 roof in 3 (see the house tile). The silo's `roof_copper` uses the linear value (0.48, 0.17, 0.03) because the hex-as-decimal value looked like thatch. If the review wants it, the same change can go to `roof_b`.
- Hex-coded non-emissive keys follow the file's existing hex-as-decimal convention (water, banner field).
- `preview.camera` is shared by the creature and toon sheet builders. Their framing is now looser too (N2 intends this).
