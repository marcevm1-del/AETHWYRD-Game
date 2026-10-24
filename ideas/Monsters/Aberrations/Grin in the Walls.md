---
type: monster
id: mon_grin_in_the_walls
family: "Aberrations"
rank: "D"
tier: core
tags: [monster, aberrations]
---
# Grin in the Walls

![[mon_grin_in_the_walls_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_grin_in_the_walls_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (858 tris · 0.984 × 1.06 × 1 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Grin in the Walls is a small creature with a hollow shell posing as an everyday object, about 1 m tall. Its skin is stretched, stitched and constantly shifting, colored in ink black with bruised violet. Only its smile is ever visible. It has too many eyes, opening one after another. A distinctive marking runs along its back. It unfolds into something larger, surrounded by shadows that lean toward it.

| Field | Value |
|---|---|
| Family · type | [[Families/Aberrations|Aberrations]] · Aberration |
| Rank · level | D · 48 (40–56) |
| Menace | 5 · Horror |
| Element · weakness | Dark · Light |
| Size | 1 m |
| Behaviour | Aggressive (aggressive_chase+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 3053 · 253 · 182 · 182 · 182 · 100 |
| XP · gold | 1477 · 342 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/amorphous\|amorphous]] · `anim_mimic` |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Aldmere\|Aldmere]], [[Regions/Strife Marches\|Strife Marches]], [[Regions/Moraveil\|Moraveil]] |
| Genre | Cosmic Horror |
| Trope | Mimicking things in the dark |

**Field note:** Weak to Light. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/amorphous|amorphous]] (rigId); animation set `anim_mimic`.
- **Dimensions:** 1 m high × 1.07 m long × 1.05 m wide; prefab scale 0.5.
- **Physics:** 30 kg, gravity ×1.2, poise 28, knockback resistance 0.66, death style `collapse_and_melt`.
- **Navigation:** speed 5.37 m/s, turn 500°/s, stopping distance 0.7 m.
- **Attack count:** 5; **signature:** only its smile is ever visible.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Chomp\|Chomp]] | melee | 1.6 | 0 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Tongue Lash\|Tongue Lash]] | grab | 1.4 | 6 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Disguise\|Disguise]] | stealth | 0 | 20 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Mimic Lure\|Mimic Lure]] | debuff | 0 | 16 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Grin in the Walls is a **horror aberration** encountered at D rank, around level 48. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** only its smile is ever visible. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Aldmere|Aldmere]], [[Regions/Strife Marches|Strife Marches]], [[Regions/Moraveil|Moraveil]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_mimic`, animation set `anim_mimic`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Aberrations D|loot_aberration_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Unreal Fragment\|Unreal Fragment]] | 60% | 1–3 |
| [[Items/Eye of Nothing\|Eye of Nothing]] | 30% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Aberrations/Storm Grin in the Walls|Storm Grin in the Walls]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Strife Marches\|Strife Marches]] | 4 | D-, D, D+, C | 40–76 | Night |
| [[Regions/Aldmere\|Aldmere]] | 3 | D-, C, D+ | 40–76 | Night |
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 2 | C-, D | 48–65 | Night |
| [[Regions/Moraveil\|Moraveil]] | 2 | D-, E+ | 32–40 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02406` | Strife Marches Grin in the Walls Juvenile | [[Regions/Strife Marches\|Strife Marches]] | Juvenile | D- | 40 | 0.85 m | Night | Like a typical Grin in the Walls, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_02407` | Aldmere Grin in the Walls Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | D- | 40 | 0.85 m | Night | Like a typical Grin in the Walls, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_02408` | Aldmere Grin in the Walls Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | C | 76 | 1.35 m | Night | Like a typical Grin in the Walls, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_02409` | Aldmere Grin in the Walls Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | D+ | 56 | 1.1 m | Night | Like a typical Grin in the Walls, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_02410` | Strife Marches Grin in the Walls | [[Regions/Strife Marches\|Strife Marches]] | Adult | D | 48 | 1 m | Night | A typical adult Grin in the Walls of this region, with dust-grey coloring and old rune scars. |
| `pop_02411` | Strife Marches Grin in the Walls Albino | [[Regions/Strife Marches\|Strife Marches]] | Albino | D+ | 56 | 1 m | Night | Like a typical Grin in the Walls, but a rare pale form with white skin or fur and red eyes. |
| `pop_02412` | Great Labyrinth (Floors 1-40) Grin in the Walls Alpha | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Alpha | C- | 65 | 1.25 m | Night | Like a typical Grin in the Walls, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_02413` | Great Labyrinth (Floors 1-40) Grin in the Walls | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Adult | D | 48 | 1 m | Night | A typical adult Grin in the Walls of this region, with dust-grey coloring and old rune scars. |
| `pop_02414` | Moraveil Grin in the Walls Juvenile | [[Regions/Moraveil\|Moraveil]] | Juvenile | D- | 40 | 0.85 m | Night | Like a typical Grin in the Walls, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_02415` | Strife Marches Grin in the Walls Elderborn | [[Regions/Strife Marches\|Strife Marches]] | Elderborn | C | 76 | 1.35 m | Night | Like a typical Grin in the Walls, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_02416` | Moraveil Grin in the Walls Runt | [[Regions/Moraveil\|Moraveil]] | Runt | E+ | 32 | 0.7 m | Night | Like a typical Grin in the Walls, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_mimic` · mesh `mimic_base` · material `wet_flesh_unsettling` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · broken symmetry, mimicry, audio-first reveal
