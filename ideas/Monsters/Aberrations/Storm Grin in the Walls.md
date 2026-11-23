---
type: monster
id: mon_storm_grin_in_the_walls
family: "Aberrations"
rank: "D+"
tier: variant
tags: [monster, aberrations]
---
# Storm Grin in the Walls

![[mon_storm_grin_in_the_walls_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_storm_grin_in_the_walls_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 12,000 tris · 1.097 × 1.266 × 0.999 m · local file `Game/Assets/_Game/Art/Models/Monsters/Aberrations/mon_storm_grin_in_the_walls.fbx`

> The Storm Grin in the Walls is a small creature with an object-shaped body that hides its true form, about 1 m tall. Its skin is stretched, stitched and constantly shifting, colored in raw pink, with electric-yellow markings. Only its smile is ever visible. It has too many eyes, opening one after another. A distinctive marking runs along its back. It copies the walk of whatever it hunts, surrounded by crackling arcs that jump across its body. This Lightning-attuned variant carries one extra elemental feature, like element-scarred hide, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Aberrations|Aberrations]] · Aberration |
| Variant of | [[Monsters/Aberrations/Grin in the Walls\|Grin in the Walls]] (elemental) |
| Rank · level | D+ · 56 (48–65) |
| Menace | 5 · Horror |
| Element · weakness | Lightning · Earth |
| Size | 1 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 3832 · 293 · 211 · 211 · 211 · 100 |
| XP · gold | 1888 · 423 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/amorphous\|amorphous]] · `anim_mimic` |
| Habitats | [[Regions/Hoshizora\|Hoshizora]], [[Regions/Strife Marches\|Strife Marches]], [[Regions/Kitsune Isles\|Kitsune Isles]] |
| Genre | Cosmic Horror |
| Trope | Mimicking things in the dark |

**Field note:** Weak to Earth. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/amorphous|amorphous]] (rigId); animation set `anim_mimic`.
- **Dimensions:** 1 m high × 1.07 m long × 1.05 m wide; prefab scale 0.5.
- **Physics:** 30 kg, gravity ×1.2, poise 28, knockback resistance 0.66, death style `collapse_and_melt`.
- **Navigation:** speed 5.53 m/s, turn 500°/s, stopping distance 0.7 m.
- **Attack count:** 5; **signature:** only its smile is ever visible.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Chomp\|Chomp]] | melee | 1.6 | 0 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Tongue Lash\|Tongue Lash]] | grab | 1.4 | 6 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Disguise\|Disguise]] | stealth | 0 | 20 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Mimic Lure\|Mimic Lure]] | debuff | 0 | 16 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Static Arc\|Static Arc]] | magic | 1.5 | 10 s | Lightning | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Storm Grin in the Walls is a **horror aberration** encountered at D+ rank, around level 56. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Earth**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** only its smile is ever visible. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Hoshizora|Hoshizora]], [[Regions/Strife Marches|Strife Marches]], [[Regions/Kitsune Isles|Kitsune Isles]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_mimic`, animation set `anim_mimic`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Aberrations D|loot_aberration_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Unreal Fragment\|Unreal Fragment]] | 60% | 1–3 |
| [[Items/Eye of Nothing\|Eye of Nothing]] | 30% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Hoshizora\|Hoshizora]] | 5 | C+, C-, D-, D | 40–86 | Night |
| [[Regions/Kitsune Isles\|Kitsune Isles]] | 4 | C, C-, D+, C+ | 56–86 | Night |
| [[Regions/Strife Marches\|Strife Marches]] | 2 | C+, C | 76–86 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05257` | Hoshizora Storm Grin in the Walls Elderborn | [[Regions/Hoshizora\|Hoshizora]] | Elderborn | C+ | 86 | 1.35 m | Night | Like a typical Storm Grin in the Walls, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_05258` | Kitsune Isles Storm Grin in the Walls Alpha | [[Regions/Kitsune Isles\|Kitsune Isles]] | Alpha | C | 76 | 1.25 m | Night | Like a typical Storm Grin in the Walls, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_05259` | Kitsune Isles Storm Grin in the Walls Scarred | [[Regions/Kitsune Isles\|Kitsune Isles]] | Scarred | C- | 65 | 1.1 m | Night | Like a typical Storm Grin in the Walls, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_05260` | Strife Marches Storm Grin in the Walls Elderborn | [[Regions/Strife Marches\|Strife Marches]] | Elderborn | C+ | 86 | 1.35 m | Night | Like a typical Storm Grin in the Walls, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_05261` | Kitsune Isles Storm Grin in the Walls | [[Regions/Kitsune Isles\|Kitsune Isles]] | Adult | D+ | 56 | 1 m | Night | A typical adult Storm Grin in the Walls of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_05262` | Hoshizora Storm Grin in the Walls Scarred | [[Regions/Hoshizora\|Hoshizora]] | Scarred | C- | 65 | 1.1 m | Night | Like a typical Storm Grin in the Walls, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_05263` | Hoshizora Storm Grin in the Walls Runt | [[Regions/Hoshizora\|Hoshizora]] | Runt | D- | 40 | 0.7 m | Night | Like a typical Storm Grin in the Walls, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_05264` | Strife Marches Storm Grin in the Walls Alpha | [[Regions/Strife Marches\|Strife Marches]] | Alpha | C | 76 | 1.25 m | Night | Like a typical Storm Grin in the Walls, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_05265` | Hoshizora Storm Grin in the Walls Juvenile | [[Regions/Hoshizora\|Hoshizora]] | Juvenile | D | 48 | 0.85 m | Night | Like a typical Storm Grin in the Walls, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_05266` | Hoshizora Storm Grin in the Walls Albino | [[Regions/Hoshizora\|Hoshizora]] | Albino | C- | 65 | 1 m | Night | Like a typical Storm Grin in the Walls, but a rare pale form with white skin or fur and red eyes. |
| `pop_05267` | Kitsune Isles Storm Grin in the Walls Elderborn | [[Regions/Kitsune Isles\|Kitsune Isles]] | Elderborn | C+ | 86 | 1.35 m | Night | Like a typical Storm Grin in the Walls, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_mimic` · mesh `mimic_base` · material `wet_flesh_unsettling` · VFX `arc_sparks` · palette `#9e7863` `#674f42` `#ffe14d` · broken symmetry, mimicry, audio-first reveal
