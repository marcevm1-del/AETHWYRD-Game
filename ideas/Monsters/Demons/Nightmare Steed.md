---
type: monster
id: mon_nightmare_steed
family: "Demons"
rank: "B+"
tier: core
tags: [monster, demons]
---
# Nightmare Steed

> The Nightmare Steed is a large creature with a powerful four-legged hunter's body, about 2.5 m long. Its hide is rough, scarred and spiked, colored in ember reds fading to soot black. Look for flame hooves and a mane of smoke. It has eyes that catch torchlight like coins. Faint runes glow along its body when it fights. It charges without hesitation, surrounded by heat-shimmer and drifting sparks.

| Field | Value |
|---|---|
| Family · type | [[Families/Demons|Demons]] · Demon |
| Rank · level | B+ · 120 (108–132) |
| Menace | 3 · Menacing |
| Element · weakness | Fire · Water |
| Size | 2.5 m |
| Behaviour | Guardian (guardian_hold) |
| HP · ATK · DEF · MATK · MDEF · SPD | 17832 · 588 · 490 · 392 · 441 · 100 |
| XP · gold | 6373 · 1225 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/quad_large\|quad_large]] · `anim_quad_large` |
| Habitats | [[Regions/Iron Hold\|Iron Hold]], [[Regions/Dragon Spine\|Dragon Spine]], [[Regions/Zarvan\|Zarvan]], [[Regions/Sunscar\|Sunscar]], [[Regions/Lirian\|Lirian]] |
| Genre | Abyssal |
| Trope | Demons as a people of the Abyss, not just evil (Frieren, Maoyuu) |

**Field note:** Weak to Water. Protects something nearby: a nest, a treasure, or a place.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_large|quad_large]] (rigId); animation set `anim_quad_large`.
- **Dimensions:** 1.63 m high × 2.5 m long × 0.4 m wide; prefab scale 0.625.
- **Physics:** 312.5 kg, gravity ×1.2, poise 89, knockback resistance 0.97, death style `heavy_fall_dust`.
- **Navigation:** speed 5.77 m/s, turn 202°/s, stopping distance 0.9 m.
- **Attack count:** 5; **signature:** flame hooves and a mane of smoke.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Maul\|Maul]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Pounce\|Pounce]] | dash | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Howl\|Howl]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Hellfire Brand\|Hellfire Brand]] | magic | 1.4 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Ember Burst\|Ember Burst]] | magic | 1.5 | 10 s | Fire | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Nightmare Steed is a **menacing demon** encountered at B+ rank, around level 120. Its documented behaviour is *Guardian* and its AI pattern is *guardian_hold*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Water**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** flame hooves and a mane of smoke. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Iron Hold|Iron Hold]], [[Regions/Dragon Spine|Dragon Spine]], [[Regions/Zarvan|Zarvan]], [[Regions/Sunscar|Sunscar]], [[Regions/Lirian|Lirian]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_large`, animation set `anim_quad_large`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Demons B|loot_demon_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Demon Core\|Demon Core]] | 60% | 1–3 |
| [[Items/Horn Shard\|Horn Shard]] | 30% | 1–1 |
| [[Items/Brimstone\|Brimstone]] | 15% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Demons/Phantom Nightmare Steed|Phantom Nightmare Steed]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Zarvan\|Zarvan]] | 2 | A-, B- | 96–132 | Day & Night |
| [[Regions/Dragon Spine\|Dragon Spine]] | 3 | A-, A+ | 132–159 | Day & Night |
| [[Regions/Lirian\|Lirian]] | 1 | A- | 132–132 | Day & Night |
| [[Regions/Sunscar\|Sunscar]] | 2 | A, B | 108–146 | Day & Night |
| [[Regions/Iron Hold\|Iron Hold]] | 3 | B+, A-, B | 108–132 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01879` | Zarvan Nightmare Steed Albino | [[Regions/Zarvan\|Zarvan]] | Albino | A- | 132 | 2.5 m | Day & Night | Like a typical Nightmare Steed, but a rare pale form with white skin or fur and red eyes. |
| `pop_01880` | Dragon Spine Nightmare Steed Scarred | [[Regions/Dragon Spine\|Dragon Spine]] | Scarred | A- | 132 | 2.75 m | Day & Night | Like a typical Nightmare Steed, but covered in old battle scars, with ash-dark coloring with glowing cracks. |
| `pop_01881` | Lirian Nightmare Steed Scarred | [[Regions/Lirian\|Lirian]] | Scarred | A- | 132 | 2.75 m | Day & Night | Like a typical Nightmare Steed, but covered in old battle scars, with soot-stained hide and scavenged scraps. |
| `pop_01882` | Dragon Spine Nightmare Steed Elderborn | [[Regions/Dragon Spine\|Dragon Spine]] | Elderborn | A+ | 159 | 3.38 m | Day & Night | Like a typical Nightmare Steed, but old and wise, with greying features and a cautious hunting style, with ash-dark coloring with glowing cracks. |
| `pop_01883` | Sunscar Nightmare Steed Alpha | [[Regions/Sunscar\|Sunscar]] | Alpha | A | 146 | 3.13 m | Day & Night | Like a typical Nightmare Steed, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_01884` | Zarvan Nightmare Steed Runt | [[Regions/Zarvan\|Zarvan]] | Runt | B- | 96 | 1.75 m | Day & Night | Like a typical Nightmare Steed, but smaller and scrappier than usual, with soot-stained hide and scavenged scraps. |
| `pop_01885` | Iron Hold Nightmare Steed | [[Regions/Iron Hold\|Iron Hold]] | Adult | B+ | 120 | 2.5 m | Day & Night | A typical adult Nightmare Steed of this region, with ash-dark coloring with glowing cracks. |
| `pop_01886` | Dragon Spine Nightmare Steed Albino | [[Regions/Dragon Spine\|Dragon Spine]] | Albino | A- | 132 | 2.5 m | Day & Night | Like a typical Nightmare Steed, but a rare pale form with white skin or fur and red eyes. |
| `pop_01887` | Sunscar Nightmare Steed Juvenile | [[Regions/Sunscar\|Sunscar]] | Juvenile | B | 108 | 2.13 m | Day & Night | Like a typical Nightmare Steed, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_01888` | Iron Hold Nightmare Steed Albino | [[Regions/Iron Hold\|Iron Hold]] | Albino | A- | 132 | 2.5 m | Day & Night | Like a typical Nightmare Steed, but a rare pale form with white skin or fur and red eyes. |
| `pop_01889` | Iron Hold Nightmare Steed Juvenile | [[Regions/Iron Hold\|Iron Hold]] | Juvenile | B | 108 | 2.13 m | Day & Night | Like a typical Nightmare Steed, but young, with brighter colors and unworn features, with ash-dark coloring with glowing cracks. |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `demon_hide_emissive` · VFX `embers_heat_haze` · palette `#e2502b` `#ffb347` `#3a1a12` · triangle-based silhouette, sharp asymmetric spikes
