---
type: monster
id: mon_chimera
family: "Chimeras & Mythic Beasts"
rank: "B+"
tier: core
tags: [monster, chimeras-mythic-beasts]
---
# Chimera

![[mon_chimera_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_chimera_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Chimera is a large creature with a heavy, muscular quadruped frame, about 3.5 m long. Its hide is rough, scarred and spiked, colored in ember reds fading to soot black. Look for lion, goat and serpent heads on one body. It has eyes that catch torchlight like coins. Faint runes glow along its body when it fights. It circles its prey, surrounded by heat-shimmer and drifting sparks.

| Field | Value |
|---|---|
| Family · type | [[Families/Chimeras & Mythic Beasts|Chimeras & Mythic Beasts]] · Mythic Beast |
| Rank · level | B+ · 120 (108–132) |
| Menace | 3 · Menacing |
| Element · weakness | Fire · Water |
| Size | 3.5 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 19966 · 588 · 490 · 392 · 441 · 100 |
| XP · gold | 6373 · 1225 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/quad_large\|quad_large]] · `anim_quad_large` |
| Habitats | [[Regions/Zarvan\|Zarvan]], [[Regions/Sunscar\|Sunscar]], [[Regions/Zaruma\|Zaruma]], [[Regions/Dragon Spine\|Dragon Spine]], [[Regions/Dunewhale Drift\|Dunewhale Drift]] |
| Genre | World Myth |
| Trope | Greek, Persian and East Asian mythic beasts |

**Field note:** Weak to Water. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_large|quad_large]] (rigId); animation set `anim_quad_large`.
- **Dimensions:** 2.28 m high × 3.5 m long × 0.56 m wide; prefab scale 0.875.
- **Physics:** 857.5 kg, gravity ×1.2, poise 105, knockback resistance 0.97, death style `heavy_fall_dust`.
- **Navigation:** speed 7.58 m/s, turn 171°/s, stopping distance 1.1 m.
- **Attack count:** 5; **signature:** lion, goat and serpent heads on one body.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Maul\|Maul]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Pounce\|Pounce]] | dash | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Howl\|Howl]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Many-Headed Bite\|Many-Headed Bite]] | melee | 1.5 | 7 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Ember Burst\|Ember Burst]] | magic | 1.5 | 10 s | Fire | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Chimera is a **menacing mythic beast** encountered at B+ rank, around level 120. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Water**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** lion, goat and serpent heads on one body. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Zarvan|Zarvan]], [[Regions/Sunscar|Sunscar]], [[Regions/Zaruma|Zaruma]], [[Regions/Dragon Spine|Dragon Spine]], [[Regions/Dunewhale Drift|Dunewhale Drift]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_large`, animation set `anim_quad_large`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Chimeras & Mythic Beasts B|loot_chimera_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Chimera Heart\|Chimera Heart]] | 60% | 1–3 |
| [[Items/Mythic Horn\|Mythic Horn]] | 30% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Chimeras & Mythic Beasts/Greater Chimera|Greater Chimera]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Sunscar\|Sunscar]] | 3 | A, A+, A- | 132–159 | Day & Night |
| [[Regions/Dragon Spine\|Dragon Spine]] | 1 | B- | 96–96 | Day & Night |
| [[Regions/Zaruma\|Zaruma]] | 3 | A-, A, B | 108–146 | Day & Night |
| [[Regions/Zarvan\|Zarvan]] | 1 | A- | 132–132 | Day & Night |
| [[Regions/Dunewhale Drift\|Dunewhale Drift]] | 3 | B, A+, B- | 96–159 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02174` | Sunscar Chimera Alpha | [[Regions/Sunscar\|Sunscar]] | Alpha | A | 146 | 4.38 m | Day & Night | Like a typical Chimera, but larger and scarred, and others of its kind follow it, with sun-bleached, sand-scoured coloring. |
| `pop_02175` | Dragon Spine Chimera Runt | [[Regions/Dragon Spine\|Dragon Spine]] | Runt | B- | 96 | 2.45 m | Day & Night | Like a typical Chimera, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_02176` | Zaruma Chimera Scarred | [[Regions/Zaruma\|Zaruma]] | Scarred | A- | 132 | 3.85 m | Day & Night | Like a typical Chimera, but covered in old battle scars, with sun-bleached, sand-scoured coloring. |
| `pop_02177` | Zarvan Chimera Scarred | [[Regions/Zarvan\|Zarvan]] | Scarred | A- | 132 | 3.85 m | Day & Night | Like a typical Chimera, but covered in old battle scars, with sun-bleached, sand-scoured coloring. |
| `pop_02178` | Dunewhale Drift Chimera Juvenile | [[Regions/Dunewhale Drift\|Dunewhale Drift]] | Juvenile | B | 108 | 2.98 m | Day & Night | Like a typical Chimera, but young, with brighter colors and unworn features, with sun-bleached, sand-scoured coloring. |
| `pop_02179` | Dunewhale Drift Chimera Elderborn | [[Regions/Dunewhale Drift\|Dunewhale Drift]] | Elderborn | A+ | 159 | 4.73 m | Day & Night | Like a typical Chimera, but old and wise, with greying features and a cautious hunting style, with sun-bleached, sand-scoured coloring. |
| `pop_02180` | Sunscar Chimera Elderborn | [[Regions/Sunscar\|Sunscar]] | Elderborn | A+ | 159 | 4.73 m | Day & Night | Like a typical Chimera, but old and wise, with greying features and a cautious hunting style, with sun-bleached, sand-scoured coloring. |
| `pop_02181` | Sunscar Chimera Albino | [[Regions/Sunscar\|Sunscar]] | Albino | A- | 132 | 3.5 m | Day & Night | Like a typical Chimera, but a rare pale form with white skin or fur and red eyes. |
| `pop_02182` | Zaruma Chimera Alpha | [[Regions/Zaruma\|Zaruma]] | Alpha | A | 146 | 4.38 m | Day & Night | Like a typical Chimera, but larger and scarred, and others of its kind follow it, with sun-bleached, sand-scoured coloring. |
| `pop_02183` | Zaruma Chimera Juvenile | [[Regions/Zaruma\|Zaruma]] | Juvenile | B | 108 | 2.98 m | Day & Night | Like a typical Chimera, but young, with brighter colors and unworn features, with sun-bleached, sand-scoured coloring. |
| `pop_02184` | Dunewhale Drift Chimera Runt | [[Regions/Dunewhale Drift\|Dunewhale Drift]] | Runt | B- | 96 | 2.45 m | Day & Night | Like a typical Chimera, but smaller and scrappier than usual, with sun-bleached, sand-scoured coloring. |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `mixed_hide` · VFX `embers_heat_haze` · palette `#e2502b` `#ffb347` `#3a1a12` · triangle-based silhouette, sharp asymmetric spikes
