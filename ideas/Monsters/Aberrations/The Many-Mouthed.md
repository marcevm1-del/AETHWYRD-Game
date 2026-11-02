---
type: monster
id: mon_the_many_mouthed
family: "Aberrations"
rank: "B"
tier: core
tags: [monster, aberrations]
---
# The Many-Mouthed

![[mon_the_many_mouthed_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_the_many_mouthed_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,388 tris · 3.891 × 3.836 × 4 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The The Many-Mouthed is a large creature with an asymmetric body with too many limbs, about 4 m tall. Its skin is stretched, stitched and constantly shifting, colored in sickly teal, with violet-edged markings. Its most striking feature is mouths opening along its arms, all whispering. It has no eyes at all, only a wide and patient mouth. Faint runes glow along its body when it fights. It copies the walk of whatever it hunts, surrounded by warped air, as if space bends around it.

| Field | Value |
|---|---|
| Family · type | [[Families/Aberrations|Aberrations]] · Aberration |
| Rank · level | B · 108 (96–120) |
| Menace | 5 · Horror |
| Element · weakness | Void · Light |
| Size | 4 m |
| Behaviour | Aggressive (aggressive_chase+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 16206 · 553 · 398 · 398 · 398 · 100 |
| XP · gold | 5386 · 1057 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/amorphous\|amorphous]] · `anim_aberrant` |
| Habitats | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/Aurumdeep\|Aurumdeep]], [[Regions/Hollow Sea\|Hollow Sea]], [[Regions/Umbravel\|Umbravel]], [[Regions/Strife Marches\|Strife Marches]] |
| Genre | Cosmic Horror |
| Trope | Mimicking things in the dark |

**Field note:** Weak to Light. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/amorphous|amorphous]] (rigId); animation set `anim_aberrant`.
- **Dimensions:** 4 m high × 4.29 m long × 4.2 m wide; prefab scale 2.
- **Physics:** 1920 kg, gravity ×0.84, poise 292, knockback resistance 0.72, death style `collapse_and_melt`.
- **Navigation:** speed 10.23 m/s, turn 250°/s, stopping distance 1.6 m.
- **Attack count:** 5; **signature:** mouths opening along its arms, all whispering.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Grasp\|Grasp]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Unfold\|Unfold]] | aoe | 1.8 | 12 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Mimic Voice\|Mimic Voice]] | debuff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Mimic Lure\|Mimic Lure]] | debuff | 0 | 16 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Null Rift\|Null Rift]] | magic | 1.5 | 10 s | Void | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

The Many-Mouthed is a **horror aberration** encountered at B rank, around level 108. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** mouths opening along its arms, all whispering. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]], [[Regions/Aurumdeep|Aurumdeep]], [[Regions/Hollow Sea|Hollow Sea]], [[Regions/Umbravel|Umbravel]], [[Regions/Strife Marches|Strife Marches]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_aberrant`, animation set `anim_aberrant`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Aberrations B|loot_aberration_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Unreal Fragment\|Unreal Fragment]] | 60% | 1–3 |
| [[Items/Eye of Nothing\|Eye of Nothing]] | 30% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Aberrations/Phantom The Many-Mouthed|Phantom The Many-Mouthed]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Hollow Sea\|Hollow Sea]] | 3 | A, C+, A- | 86–146 | Night |
| [[Regions/Strife Marches\|Strife Marches]] | 3 | B, B-, C+ | 86–108 | Night |
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 3 | B+, B- | 96–120 | Night |
| [[Regions/Umbravel\|Umbravel]] | 1 | B+ | 120–120 | Night |
| [[Regions/Aurumdeep\|Aurumdeep]] | 1 | A | 146–146 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02428` | Hollow Sea The Many-Mouthed Elderborn | [[Regions/Hollow Sea\|Hollow Sea]] | Elderborn | A | 146 | 5.4 m | Night | Like a typical The Many-Mouthed, but old and wise, with greying features and a cautious hunting style, with bioluminescent spots along its body. |
| `pop_02429` | Strife Marches The Many-Mouthed | [[Regions/Strife Marches\|Strife Marches]] | Adult | B | 108 | 4 m | Night | A typical adult The Many-Mouthed of this region, with dust-grey coloring and old rune scars. |
| `pop_02430` | Hollow Sea The Many-Mouthed Runt | [[Regions/Hollow Sea\|Hollow Sea]] | Runt | C+ | 86 | 2.8 m | Night | Like a typical The Many-Mouthed, but smaller and scrappier than usual, with bioluminescent spots along its body. |
| `pop_02431` | Strife Marches The Many-Mouthed Juvenile | [[Regions/Strife Marches\|Strife Marches]] | Juvenile | B- | 96 | 3.4 m | Night | Like a typical The Many-Mouthed, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_02432` | Great Labyrinth (Floors 41-90) The Many-Mouthed Albino | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Albino | B+ | 120 | 4 m | Night | Like a typical The Many-Mouthed, but a rare pale form with white skin or fur and red eyes. |
| `pop_02433` | Umbravel The Many-Mouthed Scarred | [[Regions/Umbravel\|Umbravel]] | Scarred | B+ | 120 | 4.4 m | Night | Like a typical The Many-Mouthed, but covered in old battle scars, with bioluminescent spots along its body. |
| `pop_02434` | Strife Marches The Many-Mouthed Runt | [[Regions/Strife Marches\|Strife Marches]] | Runt | C+ | 86 | 2.8 m | Night | Like a typical The Many-Mouthed, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_02435` | Great Labyrinth (Floors 41-90) The Many-Mouthed Scarred | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Scarred | B+ | 120 | 4.4 m | Night | Like a typical The Many-Mouthed, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_02436` | Great Labyrinth (Floors 41-90) The Many-Mouthed Juvenile | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Juvenile | B- | 96 | 3.4 m | Night | Like a typical The Many-Mouthed, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_02437` | Aurumdeep The Many-Mouthed Elderborn | [[Regions/Aurumdeep\|Aurumdeep]] | Elderborn | A | 146 | 5.4 m | Night | Like a typical The Many-Mouthed, but old and wise, with greying features and a cautious hunting style, with bioluminescent spots along its body. |
| `pop_02438` | Hollow Sea The Many-Mouthed Alpha | [[Regions/Hollow Sea\|Hollow Sea]] | Alpha | A- | 132 | 5 m | Night | Like a typical The Many-Mouthed, but larger and scarred, and others of its kind follow it, with bioluminescent spots along its body. |

## Design recipe

Rig `rig_aberrant` · mesh `aberrant_base` · material `wet_flesh_unsettling` · VFX `void_distortion` · palette `#648275` `#42574e` `#8a7cff` · broken symmetry, mimicry, audio-first reveal
