---
type: monster
id: mon_adult_dragon
family: "Dragons"
rank: "S"
tier: core
tags: [monster, dragons]
---
# Adult Dragon

![[mon_adult_dragon_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_adult_dragon_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Adult Dragon is a colossal creature with an ancient, serpentine dragon body, about 25 m long. Its scales are rough, scarred and spiked, colored in storm violet shot through with electric yellow. Survivors describe cathedral wings and a voice that shakes stone. It has burning slit pupils. Its regal silhouette is crowned by a halo-like ring of aura. It charges without hesitation, surrounded by crackling arcs that jump across its body.

| Field | Value |
|---|---|
| Family · type | [[Families/Dragons|Dragons]] · Dragon |
| Rank · level | S · 188 (173–203) |
| Menace | 3 · Menacing |
| Element · weakness | Lightning · Earth |
| Size | 25 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 92987 · 991 · 914 · 991 · 914 · 100 |
| XP · gold | 13063 · 2293 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/dragon\|dragon]] · `anim_dragon` |
| Habitats | [[Regions/Whitewater Reach\|Whitewater Reach]], [[Regions/Stormreach\|Stormreach]] |
| Genre | High Fantasy |
| Trope | Dragons as proud, intelligent apex beings; wyverns as their lesser kin |

**Field note:** Weak to Earth. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/dragon|dragon]] (rigId); animation set `anim_dragon`.
- **Dimensions:** 14 m high × 25 m long × 35.25 m wide; prefab scale 2.083.
- **Physics:** 107812.5 kg, gravity ×1, poise 1097, knockback resistance 1, death style `cinematic_collapse`.
- **Navigation:** speed 11.51 m/s, turn 120°/s, stopping distance 2.4 m.
- **Attack count:** 6; **signature:** cathedral wings and a voice that shakes stone.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Claw\|Claw]] | melee | 1.4 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Breath\|Breath]] | aoe | 2.2 | 14 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Wing Gust\|Wing Gust]] | aoe | 1 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Tail Blade\|Tail Blade]] | melee | 1.8 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Wing Buffet\|Wing Buffet]] | aoe | 1.1 | 9 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Static Arc\|Static Arc]] | magic | 1.5 | 10 s | Lightning | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Adult Dragon is a **menacing dragon** encountered at S rank, around level 188. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Earth**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** cathedral wings and a voice that shakes stone. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Whitewater Reach|Whitewater Reach]], [[Regions/Stormreach|Stormreach]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_dragon`, animation set `anim_dragon`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Dragons S|loot_draconic_s]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Dragon Scale\|Dragon Scale]] | 60% | 1–3 |
| [[Items/Dragon Blood\|Dragon Blood]] | 30% | 1–1 |
| [[Items/Dragon Heart\|Dragon Heart]] | 15% | 1–1 |
| [[Items/S-Rank Monster Core\|S-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Dragons/Ancient Adult Dragon|Ancient Adult Dragon]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Stormreach\|Stormreach]] | 4 | S, SS-, S+ | 188–218 | Day & Night |
| [[Regions/Whitewater Reach\|Whitewater Reach]] | 7 | SS, S+, S-, S, A+, SS- | 159–236 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01414` | Stormreach Adult Dragon | [[Regions/Stormreach\|Stormreach]] | Adult | S | 188 | 25 m | Day & Night | A typical adult Adult Dragon of this region, with salt-crusted, barnacle-flecked hide. |
| `pop_01415` | Whitewater Reach Adult Dragon Elderborn | [[Regions/Whitewater Reach\|Whitewater Reach]] | Elderborn | SS | 236 | 33.75 m | Day & Night | Like a typical Adult Dragon, but old and wise, with greying features and a cautious hunting style, with a thick, frost-rimed coat. |
| `pop_01416` | Whitewater Reach Adult Dragon Albino | [[Regions/Whitewater Reach\|Whitewater Reach]] | Albino | S+ | 203 | 25 m | Day & Night | Like a typical Adult Dragon, but a rare pale form with white skin or fur and red eyes. |
| `pop_01417` | Stormreach Adult Dragon Alpha | [[Regions/Stormreach\|Stormreach]] | Alpha | SS- | 218 | 31.25 m | Day & Night | Like a typical Adult Dragon, but larger and scarred, and others of its kind follow it, with salt-crusted, barnacle-flecked hide. |
| `pop_01418` | Whitewater Reach Adult Dragon Scarred | [[Regions/Whitewater Reach\|Whitewater Reach]] | Scarred | S+ | 203 | 27.5 m | Day & Night | Like a typical Adult Dragon, but covered in old battle scars, with a thick, frost-rimed coat. |
| `pop_01419` | Whitewater Reach Adult Dragon Juvenile | [[Regions/Whitewater Reach\|Whitewater Reach]] | Juvenile | S- | 173 | 21.25 m | Day & Night | Like a typical Adult Dragon, but young, with brighter colors and unworn features, with a thick, frost-rimed coat. |
| `pop_01420` | Whitewater Reach Adult Dragon | [[Regions/Whitewater Reach\|Whitewater Reach]] | Adult | S | 188 | 25 m | Day & Night | A typical adult Adult Dragon of this region, with a thick, frost-rimed coat. |
| `pop_01421` | Whitewater Reach Adult Dragon Runt | [[Regions/Whitewater Reach\|Whitewater Reach]] | Runt | A+ | 159 | 17.5 m | Day & Night | Like a typical Adult Dragon, but smaller and scrappier than usual, with a thick, frost-rimed coat. |
| `pop_01422` | Stormreach Adult Dragon Scarred | [[Regions/Stormreach\|Stormreach]] | Scarred | S+ | 203 | 27.5 m | Day & Night | Like a typical Adult Dragon, but covered in old battle scars, with salt-crusted, barnacle-flecked hide. |
| `pop_01423` | Stormreach Adult Dragon Albino | [[Regions/Stormreach\|Stormreach]] | Albino | S+ | 203 | 25 m | Day & Night | Like a typical Adult Dragon, but a rare pale form with white skin or fur and red eyes. |
| `pop_01424` | Whitewater Reach Adult Dragon Alpha | [[Regions/Whitewater Reach\|Whitewater Reach]] | Alpha | SS- | 218 | 31.25 m | Day & Night | Like a typical Adult Dragon, but larger and scarred, and others of its kind follow it, with a thick, frost-rimed coat. |

## Design recipe

Rig `rig_dragon` · mesh `dragon_base` · material `dragon_scale` · VFX `arc_sparks` · palette `#ffe14d` `#6c5ce7` `#1b1b3a` · triangle-based silhouette, sharp asymmetric spikes
