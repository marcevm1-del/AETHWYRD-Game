---
type: monster
id: mon_dune_unicorn
family: "Chimeras & Mythic Beasts"
rank: "A+"
tier: variant
tags: [monster, chimeras-mythic-beasts]
---
# Dune Unicorn

> The Dune Unicorn is a person-sized creature with a powerful four-legged hunter's body, about 2 m long. Its hide is smooth and clean, colored in ochre, clay and mossy stone. Survivors describe a spiral horn of pearl. It has two bright dot eyes. An elegant crest and glowing veins of mana mark it as a champion of its kind. It hops in little bursts, surrounded by pebbles that tremble and float near it. Adapted to desert lands, it has sun-bleached, sand-scoured coloring.

| Field | Value |
|---|---|
| Family · type | [[Families/Chimeras & Mythic Beasts|Chimeras & Mythic Beasts]] · Mythic Beast |
| Variant of | [[Monsters/Chimeras & Mythic Beasts/Unicorn\|Unicorn]] (regional) |
| Rank · level | A+ · 159 (146–173) |
| Menace | 1 · Charming |
| Element · weakness | Earth · Wind |
| Size | 2 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 25157 · 775 · 646 · 517 · 581 · 100 |
| XP · gold | 9993 · 1815 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/quad_large\|quad_large]] · `anim_quad_large` |
| Habitats | [[Regions/Zarvan\|Zarvan]], [[Regions/Sunscar\|Sunscar]] |
| Genre | World Myth |
| Trope | Greek, Persian and East Asian mythic beasts |

**Field note:** Weak to Wind. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_large|quad_large]] (rigId); animation set `anim_quad_large`.
- **Dimensions:** 1.3 m high × 2 m long × 0.32 m wide; prefab scale 0.5.
- **Physics:** 208 kg, gravity ×1.32, poise 87, knockback resistance 1, death style `heavy_fall_dust`.
- **Navigation:** speed 4.74 m/s, turn 226°/s, stopping distance 0.8 m.
- **Attack count:** 5; **signature:** a spiral horn of pearl.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Maul\|Maul]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Pounce\|Pounce]] | dash | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Howl\|Howl]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Many-Headed Bite\|Many-Headed Bite]] | melee | 1.5 | 7 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Dune Unicorn is a **charming mythic beast** encountered at A+ rank, around level 159. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a spiral horn of pearl. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Zarvan|Zarvan]], [[Regions/Sunscar|Sunscar]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_large`, animation set `anim_quad_large`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Chimeras & Mythic Beasts A|loot_chimera_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Chimera Heart\|Chimera Heart]] | 60% | 1–3 |
| [[Items/Mythic Horn\|Mythic Horn]] | 30% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Zarvan\|Zarvan]] | 6 | A, S-, A+, S+, A- | 132–203 | Day |
| [[Regions/Sunscar\|Sunscar]] | 5 | S-, S+, A, A+ | 146–203 | Day |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05048` | Zarvan Dune Unicorn Juvenile | [[Regions/Zarvan\|Zarvan]] | Juvenile | A | 146 | 1.7 m | Day | Like a typical Dune Unicorn, but young, with brighter colors and unworn features, with sun-bleached, sand-scoured coloring. |
| `pop_05049` | Sunscar Dune Unicorn Albino | [[Regions/Sunscar\|Sunscar]] | Albino | S- | 173 | 2 m | Day | Like a typical Dune Unicorn, but a rare pale form with white skin or fur and red eyes. |
| `pop_05050` | Zarvan Dune Unicorn Albino | [[Regions/Zarvan\|Zarvan]] | Albino | S- | 173 | 2 m | Day | Like a typical Dune Unicorn, but a rare pale form with white skin or fur and red eyes. |
| `pop_05051` | Sunscar Dune Unicorn Elderborn | [[Regions/Sunscar\|Sunscar]] | Elderborn | S+ | 203 | 2.7 m | Day | Like a typical Dune Unicorn, but old and wise, with greying features and a cautious hunting style, with sun-bleached, sand-scoured coloring. |
| `pop_05052` | Sunscar Dune Unicorn Scarred | [[Regions/Sunscar\|Sunscar]] | Scarred | S- | 173 | 2.2 m | Day | Like a typical Dune Unicorn, but covered in old battle scars, with sun-bleached, sand-scoured coloring. |
| `pop_05053` | Zarvan Dune Unicorn | [[Regions/Zarvan\|Zarvan]] | Adult | A+ | 159 | 2 m | Day | A typical adult Dune Unicorn of this region, with sun-bleached, sand-scoured coloring. |
| `pop_05054` | Zarvan Dune Unicorn Scarred | [[Regions/Zarvan\|Zarvan]] | Scarred | S- | 173 | 2.2 m | Day | Like a typical Dune Unicorn, but covered in old battle scars, with sun-bleached, sand-scoured coloring. |
| `pop_05055` | Sunscar Dune Unicorn Juvenile | [[Regions/Sunscar\|Sunscar]] | Juvenile | A | 146 | 1.7 m | Day | Like a typical Dune Unicorn, but young, with brighter colors and unworn features, with sun-bleached, sand-scoured coloring. |
| `pop_05056` | Sunscar Dune Unicorn | [[Regions/Sunscar\|Sunscar]] | Adult | A+ | 159 | 2 m | Day | A typical adult Dune Unicorn of this region, with sun-bleached, sand-scoured coloring. |
| `pop_05057` | Zarvan Dune Unicorn Elderborn | [[Regions/Zarvan\|Zarvan]] | Elderborn | S+ | 203 | 2.7 m | Day | Like a typical Dune Unicorn, but old and wise, with greying features and a cautious hunting style, with sun-bleached, sand-scoured coloring. |
| `pop_05058` | Zarvan Dune Unicorn Runt | [[Regions/Zarvan\|Zarvan]] | Runt | A- | 132 | 1.4 m | Day | Like a typical Dune Unicorn, but smaller and scrappier than usual, with sun-bleached, sand-scoured coloring. |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `mixed_hide` · VFX `rock_debris` · palette `#8b5a2b` `#c2a878` `#4a4a3a` · circle-based, soft silhouette
