---
type: monster
id: mon_bog_piranha_swarm
family: "Aquatic"
rank: "E+"
tier: variant
tags: [monster, aquatic]
---
# Bog Piranha Swarm

![[mon_bog_piranha_swarm_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_bog_piranha_swarm_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 6,000 tris · 0.233 × 0.2 × 0.175 m · local file `Game/Assets/_Game/Art/Models/Monsters/Aquatic/mon_bog_piranha_swarm.fbx`

> The Bog Piranha Swarm is a tiny creature with a living carpet of small bodies, each one is about 0.2 m long, but the swarm covers several meters. Its scales and skin are rough, scarred and spiked, colored in sea-blue, with sickly green markings. Guild sketches always show silver flashes and red teeth. It has narrow glowing eyes. Small scars and rough edges mark it as a survivor. It strides with heavy steps, surrounded by a low toxic haze that clings to the ground. Adapted to swamp lands, it has mud-slick, algae-streaked skin.

| Field | Value |
|---|---|
| Family · type | [[Families/Aquatic|Aquatic]] · Aquatic |
| Variant of | [[Monsters/Aquatic/Piranha Swarm\|Piranha Swarm]] (regional) |
| Rank · level | E+ · 32 (26–40) |
| Menace | 3 · Menacing |
| Element · weakness | Poison · Light |
| Size | 0.2 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 790 · 110 · 83 · 83 · 83 · 110 |
| XP · gold | 776 · 195 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/swarm\|swarm]] · `anim_swarm` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Greymoor\|Greymoor]] |
| Genre | Seafaring |
| Trope | Sea kings and krakens (One Piece), sirens and merfolk |

**Field note:** Weak to Light. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/swarm|swarm]] (rigId); animation set `anim_swarm`.
- **Dimensions:** 0.2 m high × 0.08 m long × 0.02 m wide; prefab scale 0.067.
- **Physics:** 0.5 kg, gravity ×0, poise 4, knockback resistance 1, death style `scatter_and_fall`.
- **Navigation:** speed 2.02 m/s, turn 900°/s, stopping distance 0.5 m.
- **Attack count:** 5; **signature:** silver flashes and red teeth.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Nibble\|Nibble]] | melee | 0.6 | 0 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Engulf\|Engulf]] | grab | 1.4 | 8 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Scatter\|Scatter]] | evade | 0 | 10 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Tidal Drag\|Tidal Drag]] | grab | 1.3 | 11 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Venom Spit\|Venom Spit]] | magic | 1.5 | 10 s | Poison | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Bog Piranha Swarm is a **menacing aquatic** encountered at E+ rank, around level 32. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** silver flashes and red teeth. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Greymoor|Greymoor]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_swarm`, animation set `anim_swarm`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Aquatic E|loot_aquatic_e]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Fish Scale\|Fish Scale]] | 60% | 1–3 |
| [[Items/Pearl\|Pearl]] | 30% | 1–1 |
| [[Items/Ink Sac\|Ink Sac]] | 15% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Greymoor\|Greymoor]] | 5 | E-, E+, E, D-, D+ | 19–56 | Day & Night |
| [[Regions/Aldmere\|Aldmere]] | 6 | D-, D+, E-, D, E+ | 19–56 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04807` | Greymoor Bog Piranha Swarm Runt | [[Regions/Greymoor\|Greymoor]] | Runt | E- | 19 | 0.14 m | Day & Night | Like a typical Bog Piranha Swarm, but smaller and scrappier than usual, with mud-slick, algae-streaked skin. |
| `pop_04808` | Greymoor Bog Piranha Swarm | [[Regions/Greymoor\|Greymoor]] | Adult | E+ | 32 | 0.2 m | Day & Night | A typical adult Bog Piranha Swarm of this region, with mud-slick, algae-streaked skin. |
| `pop_04809` | Aldmere Bog Piranha Swarm Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | D- | 40 | 0.22 m | Day & Night | Like a typical Bog Piranha Swarm, but covered in old battle scars, with mud-slick, algae-streaked skin. |
| `pop_04810` | Greymoor Bog Piranha Swarm Juvenile | [[Regions/Greymoor\|Greymoor]] | Juvenile | E | 26 | 0.17 m | Day & Night | Like a typical Bog Piranha Swarm, but young, with brighter colors and unworn features, with mud-slick, algae-streaked skin. |
| `pop_04811` | Greymoor Bog Piranha Swarm Albino | [[Regions/Greymoor\|Greymoor]] | Albino | D- | 40 | 0.2 m | Day & Night | Like a typical Bog Piranha Swarm, but a rare pale form with white skin or fur and red eyes. |
| `pop_04812` | Aldmere Bog Piranha Swarm Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | D+ | 56 | 0.27 m | Day & Night | Like a typical Bog Piranha Swarm, but old and wise, with greying features and a cautious hunting style, with mud-slick, algae-streaked skin. |
| `pop_04813` | Aldmere Bog Piranha Swarm Runt | [[Regions/Aldmere\|Aldmere]] | Runt | E- | 19 | 0.14 m | Day & Night | Like a typical Bog Piranha Swarm, but smaller and scrappier than usual, with mud-slick, algae-streaked skin. |
| `pop_04814` | Aldmere Bog Piranha Swarm Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | D | 48 | 0.25 m | Day & Night | Like a typical Bog Piranha Swarm, but larger and scarred, and others of its kind follow it, with mud-slick, algae-streaked skin. |
| `pop_04815` | Aldmere Bog Piranha Swarm | [[Regions/Aldmere\|Aldmere]] | Adult | E+ | 32 | 0.2 m | Day & Night | A typical adult Bog Piranha Swarm of this region, with mud-slick, algae-streaked skin. |
| `pop_04816` | Greymoor Bog Piranha Swarm Elderborn | [[Regions/Greymoor\|Greymoor]] | Elderborn | D+ | 56 | 0.27 m | Day & Night | Like a typical Bog Piranha Swarm, but old and wise, with greying features and a cautious hunting style, with mud-slick, algae-streaked skin. |
| `pop_04817` | Aldmere Bog Piranha Swarm Albino | [[Regions/Aldmere\|Aldmere]] | Albino | D- | 40 | 0.2 m | Day & Night | Like a typical Bog Piranha Swarm, but a rare pale form with white skin or fur and red eyes. |

## Design recipe

Rig `rig_swarm` · mesh `swarm_base` · material `wet_scale` · VFX `toxic_fog` · palette `#3b8797` `#285c6a` `#b8e986` · triangle-based silhouette, sharp asymmetric spikes
