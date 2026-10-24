---
type: monster
id: mon_vesper_touched_faceless_one
family: "Aberrations"
rank: "B-"
tier: variant
tags: [monster, aberrations]
---
# Vesper-Touched Faceless One

> The Vesper-Touched Faceless One is a person-sized creature with an asymmetric body with too many limbs, about 2.2 m tall. Its skin is stretched, stitched and constantly shifting, colored in starless black with faint violet edges. Look for a smooth blank face that slowly learns to look like yours. It has no eyes at all, only a wide and patient mouth. Faint runes glow along its body when it fights. It crawls across ceilings, surrounded by warped air, as if space bends around it. Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.

| Field | Value |
|---|---|
| Family · type | [[Families/Aberrations|Aberrations]] · Aberration |
| Variant of | [[Monsters/Aberrations/Faceless One\|Faceless One]] (corrupted) |
| Rank · level | B- · 96 (86–108) |
| Menace | 5 · Horror |
| Element · weakness | Void · Light |
| Size | 2.2 m |
| Behaviour | Aggressive (aggressive_chase+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 11127 · 493 · 355 · 355 · 355 · 100 |
| XP · gold | 4462 · 897 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/amorphous\|amorphous]] · `anim_aberrant` |
| Habitats | [[Regions/Aurumdeep\|Aurumdeep]], [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] |
| Genre | Cosmic Horror |
| Trope | Mimicking things in the dark |

**Field note:** Weak to Light. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/amorphous|amorphous]] (rigId); animation set `anim_aberrant`.
- **Dimensions:** 2.2 m high × 2.36 m long × 2.31 m wide; prefab scale 1.1.
- **Physics:** 319.4 kg, gravity ×0.84, poise 116, knockback resistance 0.72, death style `collapse_and_melt`.
- **Navigation:** speed 7.59 m/s, turn 337°/s, stopping distance 1.06 m.
- **Attack count:** 5; **signature:** a smooth blank face that slowly learns to look like yours.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Grasp\|Grasp]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Unfold\|Unfold]] | aoe | 1.8 | 12 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Mimic Voice\|Mimic Voice]] | debuff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Mimic Lure\|Mimic Lure]] | debuff | 0 | 16 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Null Rift\|Null Rift]] | magic | 1.5 | 10 s | Void | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Vesper-Touched Faceless One is a **horror aberration** encountered at B- rank, around level 96. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a smooth blank face that slowly learns to look like yours. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aurumdeep|Aurumdeep]], [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_aberrant`, animation set `anim_aberrant`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Aberrations B|loot_aberration_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Unreal Fragment\|Unreal Fragment]] | 60% | 1–3 |
| [[Items/Eye of Nothing\|Eye of Nothing]] | 30% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 5 | C+, C, A-, B+, B | 76–132 | Night |
| [[Regions/Aurumdeep\|Aurumdeep]] | 6 | B, C+, B-, B+, A- | 86–132 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05268` | Great Labyrinth (Floors 41-90) Vesper-Touched Faceless One Juvenile | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Juvenile | C+ | 86 | 1.87 m | Night | Like a typical Vesper-Touched Faceless One, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_05269` | Aurumdeep Vesper-Touched Faceless One Scarred | [[Regions/Aurumdeep\|Aurumdeep]] | Scarred | B | 108 | 2.42 m | Night | Like a typical Vesper-Touched Faceless One, but covered in old battle scars, with bioluminescent spots along its body. |
| `pop_05270` | Great Labyrinth (Floors 41-90) Vesper-Touched Faceless One Runt | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Runt | C | 76 | 1.54 m | Night | Like a typical Vesper-Touched Faceless One, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_05271` | Aurumdeep Vesper-Touched Faceless One Albino | [[Regions/Aurumdeep\|Aurumdeep]] | Albino | B | 108 | 2.2 m | Night | Like a typical Vesper-Touched Faceless One, but a rare pale form with white skin or fur and red eyes. |
| `pop_05272` | Great Labyrinth (Floors 41-90) Vesper-Touched Faceless One Elderborn | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Elderborn | A- | 132 | 2.97 m | Night | Like a typical Vesper-Touched Faceless One, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_05273` | Great Labyrinth (Floors 41-90) Vesper-Touched Faceless One Alpha | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Alpha | B+ | 120 | 2.75 m | Night | Like a typical Vesper-Touched Faceless One, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_05274` | Aurumdeep Vesper-Touched Faceless One Juvenile | [[Regions/Aurumdeep\|Aurumdeep]] | Juvenile | C+ | 86 | 1.87 m | Night | Like a typical Vesper-Touched Faceless One, but young, with brighter colors and unworn features, with bioluminescent spots along its body. |
| `pop_05275` | Aurumdeep Vesper-Touched Faceless One | [[Regions/Aurumdeep\|Aurumdeep]] | Adult | B- | 96 | 2.2 m | Night | A typical adult Vesper-Touched Faceless One of this region, with bioluminescent spots along its body. |
| `pop_05276` | Great Labyrinth (Floors 41-90) Vesper-Touched Faceless One Scarred | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Scarred | B | 108 | 2.42 m | Night | Like a typical Vesper-Touched Faceless One, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_05277` | Aurumdeep Vesper-Touched Faceless One Alpha | [[Regions/Aurumdeep\|Aurumdeep]] | Alpha | B+ | 120 | 2.75 m | Night | Like a typical Vesper-Touched Faceless One, but larger and scarred, and others of its kind follow it, with bioluminescent spots along its body. |
| `pop_05278` | Aurumdeep Vesper-Touched Faceless One Elderborn | [[Regions/Aurumdeep\|Aurumdeep]] | Elderborn | A- | 132 | 2.97 m | Night | Like a typical Vesper-Touched Faceless One, but old and wise, with greying features and a cautious hunting style, with bioluminescent spots along its body. |

## Design recipe

Rig `rig_aberrant` · mesh `aberrant_base` · material `wet_flesh_unsettling` · VFX `void_distortion` · palette `#0b0b1a` `#3d2c8d` `#c9c9ff` · broken symmetry, mimicry, audio-first reveal
