---
type: monster
id: mon_piranha_swarm
family: "Aquatic"
rank: "E"
tier: core
tags: [monster, aquatic]
---
# Piranha Swarm

![[mon_piranha_swarm_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_piranha_swarm_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Piranha Swarm is a tiny creature with a cloud of tiny creatures, each one is about 0.2 m long, but the swarm covers several meters. Its scales and skin are rough, scarred and spiked, colored in deep blues with a glassy shine. Its most striking feature is silver flashes and red teeth. It has narrow glowing eyes. Small scars and rough edges mark it as a survivor. It strides with heavy steps, surrounded by fine mist and droplets that orbit it.

| Field | Value |
|---|---|
| Family · type | [[Families/Aquatic|Aquatic]] · Aquatic |
| Rank · level | E · 26 (19–32) |
| Menace | 3 · Menacing |
| Element · weakness | Water · Lightning |
| Size | 0.2 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 586 · 91 · 68 · 68 · 68 · 110 |
| XP · gold | 559 · 147 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/swarm\|swarm]] · `anim_swarm` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Greymoor\|Greymoor]], [[Regions/Lirian\|Lirian]] |
| Genre | Seafaring |
| Trope | Sea kings and krakens (One Piece), sirens and merfolk |

**Field note:** Weak to Lightning. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/swarm|swarm]] (rigId); animation set `anim_swarm`.
- **Dimensions:** 0.2 m high × 0.08 m long × 0.02 m wide; prefab scale 0.067.
- **Physics:** 0.5 kg, gravity ×0, poise 4, knockback resistance 1, death style `scatter_and_fall`.
- **Navigation:** speed 2.08 m/s, turn 900°/s, stopping distance 0.5 m.
- **Attack count:** 5; **signature:** silver flashes and red teeth.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Nibble\|Nibble]] | melee | 0.6 | 0 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Engulf\|Engulf]] | grab | 1.4 | 8 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Scatter\|Scatter]] | evade | 0 | 10 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Tidal Drag\|Tidal Drag]] | grab | 1.3 | 11 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Tide Lash\|Tide Lash]] | magic | 1.5 | 10 s | Water | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Piranha Swarm is a **menacing aquatic** encountered at E rank, around level 26. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Lightning**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** silver flashes and red teeth. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Greymoor|Greymoor]], [[Regions/Lirian|Lirian]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_swarm`, animation set `anim_swarm`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Aquatic E|loot_aquatic_e]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Fish Scale\|Fish Scale]] | 60% | 1–3 |
| [[Items/Pearl\|Pearl]] | 30% | 1–1 |
| [[Items/Ink Sac\|Ink Sac]] | 15% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Aquatic/Bog Piranha Swarm|Bog Piranha Swarm]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Lirian\|Lirian]] | 4 | E+, D-, E | 26–40 | Day & Night |
| [[Regions/Aldmere\|Aldmere]] | 5 | F+, E+, E-, D, E | 13–48 | Day & Night |
| [[Regions/Greymoor\|Greymoor]] | 2 | D, F+ | 13–48 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01941` | Lirian Piranha Swarm Scarred | [[Regions/Lirian\|Lirian]] | Scarred | E+ | 32 | 0.22 m | Day & Night | Like a typical Piranha Swarm, but covered in old battle scars, with salt-crusted, barnacle-flecked hide. |
| `pop_01942` | Aldmere Piranha Swarm Runt | [[Regions/Aldmere\|Aldmere]] | Runt | F+ | 13 | 0.14 m | Day & Night | Like a typical Piranha Swarm, but smaller and scrappier than usual, with mud-slick, algae-streaked skin. |
| `pop_01943` | Lirian Piranha Swarm Alpha | [[Regions/Lirian\|Lirian]] | Alpha | D- | 40 | 0.25 m | Day & Night | Like a typical Piranha Swarm, but larger and scarred, and others of its kind follow it, with salt-crusted, barnacle-flecked hide. |
| `pop_01944` | Lirian Piranha Swarm Albino | [[Regions/Lirian\|Lirian]] | Albino | E+ | 32 | 0.2 m | Day & Night | Like a typical Piranha Swarm, but a rare pale form with white skin or fur and red eyes. |
| `pop_01945` | Aldmere Piranha Swarm Albino | [[Regions/Aldmere\|Aldmere]] | Albino | E+ | 32 | 0.2 m | Day & Night | Like a typical Piranha Swarm, but a rare pale form with white skin or fur and red eyes. |
| `pop_01946` | Lirian Piranha Swarm | [[Regions/Lirian\|Lirian]] | Adult | E | 26 | 0.2 m | Day & Night | A typical adult Piranha Swarm of this region, with salt-crusted, barnacle-flecked hide. |
| `pop_01947` | Aldmere Piranha Swarm Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | E- | 19 | 0.17 m | Day & Night | Like a typical Piranha Swarm, but young, with brighter colors and unworn features, with mud-slick, algae-streaked skin. |
| `pop_01948` | Greymoor Piranha Swarm Elderborn | [[Regions/Greymoor\|Greymoor]] | Elderborn | D | 48 | 0.27 m | Day & Night | Like a typical Piranha Swarm, but old and wise, with greying features and a cautious hunting style, with mud-slick, algae-streaked skin. |
| `pop_01949` | Aldmere Piranha Swarm Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | D | 48 | 0.27 m | Day & Night | Like a typical Piranha Swarm, but old and wise, with greying features and a cautious hunting style, with mud-slick, algae-streaked skin. |
| `pop_01950` | Aldmere Piranha Swarm | [[Regions/Aldmere\|Aldmere]] | Adult | E | 26 | 0.2 m | Day & Night | A typical adult Piranha Swarm of this region, with mud-slick, algae-streaked skin. |
| `pop_01951` | Greymoor Piranha Swarm Runt | [[Regions/Greymoor\|Greymoor]] | Runt | F+ | 13 | 0.14 m | Day & Night | Like a typical Piranha Swarm, but smaller and scrappier than usual, with mud-slick, algae-streaked skin. |

## Design recipe

Rig `rig_swarm` · mesh `swarm_base` · material `wet_scale` · VFX `mist_droplets` · palette `#2f7fd1` `#9ad7ff` `#123a5c` · triangle-based silhouette, sharp asymmetric spikes
