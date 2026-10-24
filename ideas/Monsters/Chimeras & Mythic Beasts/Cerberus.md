---
type: monster
id: mon_cerberus
family: "Chimeras & Mythic Beasts"
rank: "A+"
tier: core
tags: [monster, chimeras-mythic-beasts]
---
# Cerberus

> The Cerberus is a huge creature with a long-legged predatory quadruped build, about 5 m long. Its hide is rough, scarred and spiked, colored in ember reds fading to soot black. Its most striking feature is three heads with three different moods. It has eyes that catch torchlight like coins. An elegant crest and glowing veins of mana mark it as a champion of its kind. It circles its prey, surrounded by heat-shimmer and drifting sparks.

| Field | Value |
|---|---|
| Family · type | [[Families/Chimeras & Mythic Beasts|Chimeras & Mythic Beasts]] · Mythic Beast |
| Rank · level | A+ · 159 (146–173) |
| Menace | 3 · Menacing |
| Element · weakness | Fire · Water |
| Size | 5 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 34118 · 775 · 646 · 517 · 581 · 100 |
| XP · gold | 9993 · 1815 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/quad_large\|quad_large]] · `anim_quad_large` |
| Habitats | [[Regions/Zarvan\|Zarvan]], [[Regions/Nox Dominion\|Nox Dominion]], [[Regions/Sunscar\|Sunscar]], [[Regions/Zaruma\|Zaruma]], [[Regions/Iron Hold\|Iron Hold]] |
| Genre | World Myth |
| Trope | Greek, Persian and East Asian mythic beasts |

**Field note:** Weak to Water. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_large|quad_large]] (rigId); animation set `anim_quad_large`.
- **Dimensions:** 3.25 m high × 5 m long × 0.8 m wide; prefab scale 1.25.
- **Physics:** 2500 kg, gravity ×1.2, poise 137, knockback resistance 1, death style `heavy_fall_dust`.
- **Navigation:** speed 9.06 m/s, turn 143°/s, stopping distance 1.4 m.
- **Attack count:** 5; **signature:** three heads with three different moods.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Maul\|Maul]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Pounce\|Pounce]] | dash | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Howl\|Howl]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Many-Headed Bite\|Many-Headed Bite]] | melee | 1.5 | 7 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Ember Burst\|Ember Burst]] | magic | 1.5 | 10 s | Fire | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Cerberus is a **menacing mythic beast** encountered at A+ rank, around level 159. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Water**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** three heads with three different moods. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Zarvan|Zarvan]], [[Regions/Nox Dominion|Nox Dominion]], [[Regions/Sunscar|Sunscar]], [[Regions/Zaruma|Zaruma]], [[Regions/Iron Hold|Iron Hold]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_large`, animation set `anim_quad_large`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Chimeras & Mythic Beasts A|loot_chimera_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Chimera Heart\|Chimera Heart]] | 60% | 1–3 |
| [[Items/Mythic Horn\|Mythic Horn]] | 30% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Chimeras & Mythic Beasts/Greater Cerberus|Greater Cerberus]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Iron Hold\|Iron Hold]] | 4 | S-, A+, S, S+ | 159–203 | Day & Night |
| [[Regions/Nox Dominion\|Nox Dominion]] | 2 | S-, S | 173–188 | Day & Night |
| [[Regions/Zaruma\|Zaruma]] | 2 | S-, A | 146–173 | Day & Night |
| [[Regions/Sunscar\|Sunscar]] | 2 | S-, A+ | 159–173 | Day & Night |
| [[Regions/Zarvan\|Zarvan]] | 1 | S+ | 203–203 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02207` | Iron Hold Cerberus Albino | [[Regions/Iron Hold\|Iron Hold]] | Albino | S- | 173 | 5 m | Day & Night | Like a typical Cerberus, but a rare pale form with white skin or fur and red eyes. |
| `pop_02208` | Nox Dominion Cerberus Scarred | [[Regions/Nox Dominion\|Nox Dominion]] | Scarred | S- | 173 | 5.5 m | Day & Night | Like a typical Cerberus, but covered in old battle scars, with red-black coloring with faint ember veins. |
| `pop_02209` | Iron Hold Cerberus | [[Regions/Iron Hold\|Iron Hold]] | Adult | A+ | 159 | 5 m | Day & Night | A typical adult Cerberus of this region, with slate-grey coloring and hardened hide. |
| `pop_02210` | Zaruma Cerberus Scarred | [[Regions/Zaruma\|Zaruma]] | Scarred | S- | 173 | 5.5 m | Day & Night | Like a typical Cerberus, but covered in old battle scars, with sun-bleached, sand-scoured coloring. |
| `pop_02211` | Sunscar Cerberus Scarred | [[Regions/Sunscar\|Sunscar]] | Scarred | S- | 173 | 5.5 m | Day & Night | Like a typical Cerberus, but covered in old battle scars, with sun-bleached, sand-scoured coloring. |
| `pop_02212` | Zaruma Cerberus Juvenile | [[Regions/Zaruma\|Zaruma]] | Juvenile | A | 146 | 4.25 m | Day & Night | Like a typical Cerberus, but young, with brighter colors and unworn features, with sun-bleached, sand-scoured coloring. |
| `pop_02213` | Nox Dominion Cerberus Alpha | [[Regions/Nox Dominion\|Nox Dominion]] | Alpha | S | 188 | 6.25 m | Day & Night | Like a typical Cerberus, but larger and scarred, and others of its kind follow it, with red-black coloring with faint ember veins. |
| `pop_02214` | Sunscar Cerberus | [[Regions/Sunscar\|Sunscar]] | Adult | A+ | 159 | 5 m | Day & Night | A typical adult Cerberus of this region, with sun-bleached, sand-scoured coloring. |
| `pop_02215` | Iron Hold Cerberus Alpha | [[Regions/Iron Hold\|Iron Hold]] | Alpha | S | 188 | 6.25 m | Day & Night | Like a typical Cerberus, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_02216` | Zarvan Cerberus Elderborn | [[Regions/Zarvan\|Zarvan]] | Elderborn | S+ | 203 | 6.75 m | Day & Night | Like a typical Cerberus, but old and wise, with greying features and a cautious hunting style, with sun-bleached, sand-scoured coloring. |
| `pop_02217` | Iron Hold Cerberus Elderborn | [[Regions/Iron Hold\|Iron Hold]] | Elderborn | S+ | 203 | 6.75 m | Day & Night | Like a typical Cerberus, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `mixed_hide` · VFX `embers_heat_haze` · palette `#e2502b` `#ffb347` `#3a1a12` · triangle-based silhouette, sharp asymmetric spikes
