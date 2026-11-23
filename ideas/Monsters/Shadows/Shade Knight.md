---
type: monster
id: mon_shade_knight
family: "Shadows"
rank: "C"
tier: core
tags: [monster, shadows]
---
# Shade Knight

![[mon_shade_knight_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_shade_knight_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 12,000 tris · 1.162 × 1.091 × 2.301 m · local file `Game/Assets/_Game/Art/Models/Monsters/Shadows/mon_shade_knight.fbx`

> The Shade Knight is a person-sized creature with an upright humanoid build, about 2.3 m tall. Its smoke-like body is rough, scarred and spiked, colored in storm-grey, with violet markings. Guild sketches always show armor with nothing but darkness inside. It has burning slit pupils. Battle-worn plates and trophies hang from its body. It strides with heavy steps, surrounded by shadows that lean toward it.

| Field | Value |
|---|---|
| Family · type | [[Families/Shadows|Shadows]] · Spirit |
| Rank · level | C · 76 (65–86) |
| Menace | 3 · Menacing |
| Element · weakness | Dark · Light |
| Size | 2.3 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 8779 · 377 · 314 · 251 · 283 · 100 |
| XP · gold | 3073 · 648 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Umbravel\|Umbravel]], [[Regions/Aldmere\|Aldmere]], [[Regions/Strife Marches\|Strife Marches]] |
| Genre | Dungeon Crawl |
| Trope | Dungeon-born shadow warriors (DanMachi War Shadows) |

**Field note:** Weak to Light. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 2.3 m high × 0.69 m long × 0.74 m wide; prefab scale 1.278.
- **Physics:** 158.2 kg, gravity ×1.5, poise 82, knockback resistance 0.39, death style `ragdoll`.
- **Navigation:** speed 6.44 m/s, turn 264°/s, stopping distance 0.79 m.
- **Attack count:** 5; **signature:** armor with nothing but darkness inside.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Shade Step Strike\|Shade Step Strike]] | dash | 1.4 | 7 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Shade Knight is a **menacing spirit** encountered at C rank, around level 76. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** armor with nothing but darkness inside. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]], [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Umbravel|Umbravel]], [[Regions/Aldmere|Aldmere]], [[Regions/Strife Marches|Strife Marches]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Shadows C|loot_shadow_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Shade Essence\|Shade Essence]] | 60% | 1–3 |
| [[Items/Night Shard\|Night Shard]] | 30% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Shadows/Vesper-Touched Shade Knight|Vesper-Touched Shade Knight]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 2 | C-, B | 65–108 | Day & Night |
| [[Regions/Aldmere\|Aldmere]] | 4 | C-, C+, B- | 65–96 | Day & Night |
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 3 | B, D+, B- | 56–108 | Day & Night |
| [[Regions/Umbravel\|Umbravel]] | 1 | B- | 96–96 | Day & Night |
| [[Regions/Strife Marches\|Strife Marches]] | 1 | C | 76–76 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01017` | Great Labyrinth (Floors 1-40) Shade Knight Juvenile | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Juvenile | C- | 65 | 1.95 m | Day & Night | Like a typical Shade Knight, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_01018` | Aldmere Shade Knight Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | C- | 65 | 1.95 m | Day & Night | Like a typical Shade Knight, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_01019` | Great Labyrinth (Floors 41-90) Shade Knight Elderborn | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Elderborn | B | 108 | 3.1 m | Day & Night | Like a typical Shade Knight, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_01020` | Umbravel Shade Knight Alpha | [[Regions/Umbravel\|Umbravel]] | Alpha | B- | 96 | 2.88 m | Day & Night | Like a typical Shade Knight, but larger and scarred, and others of its kind follow it, with bioluminescent spots along its body. |
| `pop_01021` | Aldmere Shade Knight Albino | [[Regions/Aldmere\|Aldmere]] | Albino | C+ | 86 | 2.3 m | Day & Night | Like a typical Shade Knight, but a rare pale form with white skin or fur and red eyes. |
| `pop_01022` | Aldmere Shade Knight Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | B- | 96 | 2.88 m | Day & Night | Like a typical Shade Knight, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_01023` | Strife Marches Shade Knight | [[Regions/Strife Marches\|Strife Marches]] | Adult | C | 76 | 2.3 m | Day & Night | A typical adult Shade Knight of this region, with dust-grey coloring and old rune scars. |
| `pop_01024` | Aldmere Shade Knight Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | C+ | 86 | 2.53 m | Day & Night | Like a typical Shade Knight, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_01025` | Great Labyrinth (Floors 41-90) Shade Knight Runt | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Runt | D+ | 56 | 1.61 m | Day & Night | Like a typical Shade Knight, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_01026` | Great Labyrinth (Floors 41-90) Shade Knight Alpha | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Alpha | B- | 96 | 2.88 m | Day & Night | Like a typical Shade Knight, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_01027` | Great Labyrinth (Floors 1-40) Shade Knight Elderborn | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Elderborn | B | 108 | 3.1 m | Day & Night | Like a typical Shade Knight, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `shadow_smoke` · VFX `shadow_wisps` · palette `#565a7a` `#42445e` `#9a86d8` · triangle-based silhouette, sharp asymmetric spikes
