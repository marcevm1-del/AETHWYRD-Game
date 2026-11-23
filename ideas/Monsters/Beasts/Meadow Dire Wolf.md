---
type: monster
id: mon_meadow_dire_wolf
family: "Beasts"
rank: "D+"
tier: variant
tags: [monster, beasts]
---
# Meadow Dire Wolf

![[mon_meadow_dire_wolf_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_meadow_dire_wolf_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 11,994 tris · 0.501 × 2 × 1.207 m · local file `Game/Assets/_Game/Art/Models/Monsters/Beasts/mon_meadow_dire_wolf.fbx`

> The Meadow Dire Wolf is a person-sized creature with a powerful four-legged hunter's body, about 2 m long. Its coat is rough, scarred and spiked, colored in cream, with pale jade markings. Its most striking feature is a horse-sized frame and a jaw full of jagged fangs. It has burning slit pupils. A distinctive marking runs along its back. It strides with heavy steps, surrounded by swirling leaves and a constant breeze. Adapted to plains lands, it has golden, grass-toned coloring.

| Field | Value |
|---|---|
| Family · type | [[Families/Beasts|Beasts]] · Beast |
| Variant of | [[Monsters/Beasts/Dire Wolf\|Dire Wolf]] (regional) |
| Rank · level | D+ · 56 (48–65) |
| Menace | 3 · Menacing |
| Element · weakness | Wind · Fire |
| Size | 2 m |
| Behaviour | Skittish (skittish_flee) |
| HP · ATK · DEF · MATK · MDEF · SPD | 5324 · 281 · 234 · 187 · 211 · 100 |
| XP · gold | 1888 · 423 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/quad_large\|quad_large]] · `anim_quad_large` |
| Habitats | [[Regions/Moraveil\|Moraveil]], [[Regions/Strife Marches\|Strife Marches]] |
| Genre | Classic Fantasy |
| Trope | The horned rabbit "rookie killer" and wolf packs of every isekai starter forest |

**Field note:** Weak to Fire. Flees when hurt. Snares or ranged attacks work best.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_large|quad_large]] (rigId); animation set `anim_quad_large`.
- **Dimensions:** 1.3 m high × 2 m long × 0.32 m wide; prefab scale 0.5.
- **Physics:** 144 kg, gravity ×0.96, poise 64, knockback resistance 0.91, death style `heavy_fall_dust`.
- **Navigation:** speed 7.08 m/s, turn 226°/s, stopping distance 0.8 m.
- **Attack count:** 5; **signature:** a horse-sized frame and a jaw full of jagged fangs.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Maul\|Maul]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Pounce\|Pounce]] | dash | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Howl\|Howl]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Rending Bite\|Rending Bite]] | melee | 1.3 | 5 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Gale Cutter\|Gale Cutter]] | magic | 1.5 | 10 s | Wind | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Meadow Dire Wolf is a **menacing beast** encountered at D+ rank, around level 56. Its documented behaviour is *Skittish* and its AI pattern is *skittish_flee*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a horse-sized frame and a jaw full of jagged fangs. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Moraveil|Moraveil]], [[Regions/Strife Marches|Strife Marches]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_large`, animation set `anim_quad_large`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Beasts D|loot_beast_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Pelt\|Pelt]] | 60% | 1–3 |
| [[Items/Fang\|Fang]] | 30% | 1–1 |
| [[Items/Prime Meat\|Prime Meat]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Strife Marches\|Strife Marches]] | 7 | C+, C-, D-, D+, C, D | 40–86 | Day & Night |
| [[Regions/Moraveil\|Moraveil]] | 4 | D+, C-, D-, D | 40–65 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03324` | Strife Marches Meadow Dire Wolf Elderborn | [[Regions/Strife Marches\|Strife Marches]] | Elderborn | C+ | 86 | 2.7 m | Day & Night | Like a typical Meadow Dire Wolf, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_03325` | Strife Marches Meadow Dire Wolf Albino | [[Regions/Strife Marches\|Strife Marches]] | Albino | C- | 65 | 2 m | Day & Night | Like a typical Meadow Dire Wolf, but a rare pale form with white skin or fur and red eyes. |
| `pop_03326` | Strife Marches Meadow Dire Wolf Runt | [[Regions/Strife Marches\|Strife Marches]] | Runt | D- | 40 | 1.4 m | Day & Night | Like a typical Meadow Dire Wolf, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_03327` | Moraveil Meadow Dire Wolf | [[Regions/Moraveil\|Moraveil]] | Adult | D+ | 56 | 2 m | Day & Night | A typical adult Meadow Dire Wolf of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_03328` | Strife Marches Meadow Dire Wolf Scarred | [[Regions/Strife Marches\|Strife Marches]] | Scarred | C- | 65 | 2.2 m | Day & Night | Like a typical Meadow Dire Wolf, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_03329` | Strife Marches Meadow Dire Wolf | [[Regions/Strife Marches\|Strife Marches]] | Adult | D+ | 56 | 2 m | Day & Night | A typical adult Meadow Dire Wolf of this region, with golden, grass-toned coloring. |
| `pop_03330` | Moraveil Meadow Dire Wolf Albino | [[Regions/Moraveil\|Moraveil]] | Albino | C- | 65 | 2 m | Day & Night | Like a typical Meadow Dire Wolf, but a rare pale form with white skin or fur and red eyes. |
| `pop_03331` | Moraveil Meadow Dire Wolf Runt | [[Regions/Moraveil\|Moraveil]] | Runt | D- | 40 | 1.4 m | Day & Night | Like a typical Meadow Dire Wolf, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_03332` | Strife Marches Meadow Dire Wolf Alpha | [[Regions/Strife Marches\|Strife Marches]] | Alpha | C | 76 | 2.5 m | Day & Night | Like a typical Meadow Dire Wolf, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_03333` | Strife Marches Meadow Dire Wolf Juvenile | [[Regions/Strife Marches\|Strife Marches]] | Juvenile | D | 48 | 1.7 m | Day & Night | Like a typical Meadow Dire Wolf, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_03334` | Moraveil Meadow Dire Wolf Juvenile | [[Regions/Moraveil\|Moraveil]] | Juvenile | D | 48 | 1.7 m | Day & Night | Like a typical Meadow Dire Wolf, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `fur_groom` · VFX `wind_ribbons` · palette `#dfcfad` `#9f8f74` `#8fe0bd` · triangle-based silhouette, sharp asymmetric spikes
