---
type: monster
id: mon_scarab_swarm
family: "Insects & Arachnids"
rank: "A"
tier: core
tags: [monster, insects-arachnids]
---
# Scarab Swarm

> The Scarab Swarm is a tiny creature with a swarm of many small bodies moving as one, each one is about 0.05 m long, but the swarm covers several meters. Its chitin is rough, scarred and spiked, colored in ink black with bruised violet. Look for golden beetles that flow like spilled coins. It has burning slit pupils. An elegant crest and glowing veins of mana mark it as a champion of its kind. It circles its prey, surrounded by shadows that lean toward it.

| Field | Value |
|---|---|
| Family · type | [[Families/Insects & Arachnids|Insects & Arachnids]] · Insectoid |
| Rank · level | A · 146 (132–159) |
| Menace | 3 · Menacing |
| Element · weakness | Dark · Light |
| Size | 0.05 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 6694 · 475 · 356 · 356 · 356 · 110 |
| XP · gold | 8719 · 1611 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/swarm\|swarm]] · `anim_swarm` |
| Habitats | [[Regions/Moraveil\|Moraveil]], [[Regions/Sunscar\|Sunscar]], [[Regions/Iron Hold\|Iron Hold]], [[Regions/Lumbaya\|Lumbaya]], [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] |
| Genre | Classic Fantasy |
| Trope | Giant insects as low-floor threats; the arachne as an intelligent monster race |

**Field note:** Weak to Light. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/swarm|swarm]] (rigId); animation set `anim_swarm`.
- **Dimensions:** 0.05 m high × 0.02 m long × 0.01 m wide; prefab scale 0.017.
- **Physics:** 0.5 kg, gravity ×0, poise 5, knockback resistance 1, death style `scatter_and_fall`.
- **Navigation:** speed 1.09 m/s, turn 900°/s, stopping distance 0.5 m.
- **Attack count:** 5; **signature:** golden beetles that flow like spilled coins.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Nibble\|Nibble]] | melee | 0.6 | 0 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Engulf\|Engulf]] | grab | 1.4 | 8 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Scatter\|Scatter]] | evade | 0 | 10 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Silk Snare\|Silk Snare]] | ranged | 0.4 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Scarab Swarm is a **menacing insectoid** encountered at A rank, around level 146. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** golden beetles that flow like spilled coins. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Moraveil|Moraveil]], [[Regions/Sunscar|Sunscar]], [[Regions/Iron Hold|Iron Hold]], [[Regions/Lumbaya|Lumbaya]], [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_swarm`, animation set `anim_swarm`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Insects & Arachnids A|loot_insect_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Carapace Shard\|Carapace Shard]] | 60% | 1–3 |
| [[Items/Silk\|Silk]] | 30% | 1–1 |
| [[Items/Venom Sac\|Venom Sac]] | 15% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Insects & Arachnids/Vesper-Touched Scarab Swarm|Vesper-Touched Scarab Swarm]]
- [[Monsters/Insects & Arachnids/Elder Scarab Swarm|Elder Scarab Swarm]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 3 | A-, A, S- | 132–173 | Day & Night |
| [[Regions/Iron Hold\|Iron Hold]] | 4 | A+, A, A-, S | 132–188 | Day & Night |
| [[Regions/Sunscar\|Sunscar]] | 2 | S, A- | 132–188 | Day & Night |
| [[Regions/Moraveil\|Moraveil]] | 1 | S | 188–188 | Day & Night |
| [[Regions/Lumbaya\|Lumbaya]] | 1 | A+ | 159–159 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00707` | Great Labyrinth (Floors 41-90) Scarab Swarm Juvenile | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Juvenile | A- | 132 | 0.04 m | Day & Night | Like a typical Scarab Swarm, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_00708` | Great Labyrinth (Floors 41-90) Scarab Swarm | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Adult | A | 146 | 0.05 m | Day & Night | A typical adult Scarab Swarm of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_00709` | Iron Hold Scarab Swarm Albino | [[Regions/Iron Hold\|Iron Hold]] | Albino | A+ | 159 | 0.05 m | Day & Night | Like a typical Scarab Swarm, but a rare pale form with white skin or fur and red eyes. |
| `pop_00710` | Iron Hold Scarab Swarm | [[Regions/Iron Hold\|Iron Hold]] | Adult | A | 146 | 0.05 m | Day & Night | A typical adult Scarab Swarm of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_00711` | Iron Hold Scarab Swarm Juvenile | [[Regions/Iron Hold\|Iron Hold]] | Juvenile | A- | 132 | 0.04 m | Day & Night | Like a typical Scarab Swarm, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_00712` | Sunscar Scarab Swarm Elderborn | [[Regions/Sunscar\|Sunscar]] | Elderborn | S | 188 | 0.07 m | Day & Night | Like a typical Scarab Swarm, but old and wise, with greying features and a cautious hunting style, with sun-bleached, sand-scoured coloring. |
| `pop_00713` | Moraveil Scarab Swarm Elderborn | [[Regions/Moraveil\|Moraveil]] | Elderborn | S | 188 | 0.07 m | Day & Night | Like a typical Scarab Swarm, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_00714` | Lumbaya Scarab Swarm Albino | [[Regions/Lumbaya\|Lumbaya]] | Albino | A+ | 159 | 0.05 m | Day & Night | Like a typical Scarab Swarm, but a rare pale form with white skin or fur and red eyes. |
| `pop_00715` | Sunscar Scarab Swarm Juvenile | [[Regions/Sunscar\|Sunscar]] | Juvenile | A- | 132 | 0.04 m | Day & Night | Like a typical Scarab Swarm, but young, with brighter colors and unworn features, with sun-bleached, sand-scoured coloring. |
| `pop_00716` | Great Labyrinth (Floors 41-90) Scarab Swarm Alpha | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Alpha | S- | 173 | 0.06 m | Day & Night | Like a typical Scarab Swarm, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_00717` | Iron Hold Scarab Swarm Elderborn | [[Regions/Iron Hold\|Iron Hold]] | Elderborn | S | 188 | 0.07 m | Day & Night | Like a typical Scarab Swarm, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |

## Design recipe

Rig `rig_swarm` · mesh `swarm_base` · material `chitin_gloss` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · triangle-based silhouette, sharp asymmetric spikes
