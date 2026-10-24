---
type: monster
id: mon_leviathan_young
family: "Aquatic"
rank: "S"
tier: core
tags: [monster, aquatic]
---
# Leviathan Young

![[mon_leviathan_young_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_leviathan_young_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Leviathan Young is a colossal creature with a streamlined aquatic body, about 60 m long. Its scales and skin are rough, scarred and spiked, colored in deep blues with a glassy shine. Its most striking feature is fins like the sails of a warship. It has narrow glowing eyes. Its regal silhouette is crowned by a halo-like ring of aura. It circles its prey, surrounded by fine mist and droplets that orbit it.

| Field | Value |
|---|---|
| Family · type | [[Families/Aquatic|Aquatic]] · Aquatic |
| Rank · level | S · 188 (173–203) |
| Menace | 3 · Menacing |
| Element · weakness | Water · Lightning |
| Size | 60 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 74869 · 953 · 686 · 686 · 686 · 100 |
| XP · gold | 13063 · 2293 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/aquatic\|aquatic]] · `anim_fish` |
| Habitats | [[Regions/Goldmere Coast\|Goldmere Coast]], [[Regions/Whitewater Reach\|Whitewater Reach]] |
| Genre | Seafaring |
| Trope | Sea kings and krakens (One Piece), sirens and merfolk |

**Field note:** Weak to Lightning. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/aquatic|aquatic]] (rigId); animation set `anim_fish`.
- **Dimensions:** 24 m high × 60 m long × 21.6 m wide; prefab scale 40.
- **Physics:** 5216400 kg, gravity ×1, poise 24598, knockback resistance 0.48, death style `float_belly_up`.
- **Navigation:** speed 37.59 m/s, turn 60°/s, stopping distance 7.6 m.
- **Attack count:** 5; **signature:** fins like the sails of a warship.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Bite\|Bite]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Breach Lunge\|Breach Lunge]] | dash | 1.7 | 9 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Thrash\|Thrash]] | aoe | 1.3 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Tidal Drag\|Tidal Drag]] | grab | 1.3 | 11 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Tide Lash\|Tide Lash]] | magic | 1.5 | 10 s | Water | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Leviathan Young is a **menacing aquatic** encountered at S rank, around level 188. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Lightning**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** fins like the sails of a warship. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Goldmere Coast|Goldmere Coast]], [[Regions/Whitewater Reach|Whitewater Reach]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_fish`, animation set `anim_fish`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Aquatic S|loot_aquatic_s]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Fish Scale\|Fish Scale]] | 60% | 1–3 |
| [[Items/Pearl\|Pearl]] | 30% | 1–1 |
| [[Items/Ink Sac\|Ink Sac]] | 15% | 1–1 |
| [[Items/S-Rank Monster Core\|S-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Aquatic/Phantom Leviathan Young|Phantom Leviathan Young]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Goldmere Coast\|Goldmere Coast]] | 4 | S+, SS-, S | 188–218 | Day & Night |
| [[Regions/Whitewater Reach\|Whitewater Reach]] | 7 | SS, S-, S+, S, SS-, A+ | 159–236 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02029` | Goldmere Coast Leviathan Young Scarred | [[Regions/Goldmere Coast\|Goldmere Coast]] | Scarred | S+ | 203 | 66 m | Day & Night | Like a typical Leviathan Young, but covered in old battle scars, with salt-crusted, barnacle-flecked hide. |
| `pop_02030` | Whitewater Reach Leviathan Young Elderborn | [[Regions/Whitewater Reach\|Whitewater Reach]] | Elderborn | SS | 236 | 81 m | Day & Night | Like a typical Leviathan Young, but old and wise, with greying features and a cautious hunting style, with salt-crusted, barnacle-flecked hide. |
| `pop_02031` | Goldmere Coast Leviathan Young Alpha | [[Regions/Goldmere Coast\|Goldmere Coast]] | Alpha | SS- | 218 | 75 m | Day & Night | Like a typical Leviathan Young, but larger and scarred, and others of its kind follow it, with salt-crusted, barnacle-flecked hide. |
| `pop_02032` | Whitewater Reach Leviathan Young Juvenile | [[Regions/Whitewater Reach\|Whitewater Reach]] | Juvenile | S- | 173 | 51 m | Day & Night | Like a typical Leviathan Young, but young, with brighter colors and unworn features, with salt-crusted, barnacle-flecked hide. |
| `pop_02033` | Goldmere Coast Leviathan Young | [[Regions/Goldmere Coast\|Goldmere Coast]] | Adult | S | 188 | 60 m | Day & Night | A typical adult Leviathan Young of this region, with salt-crusted, barnacle-flecked hide. |
| `pop_02034` | Whitewater Reach Leviathan Young Albino | [[Regions/Whitewater Reach\|Whitewater Reach]] | Albino | S+ | 203 | 60 m | Day & Night | Like a typical Leviathan Young, but a rare pale form with white skin or fur and red eyes. |
| `pop_02035` | Whitewater Reach Leviathan Young | [[Regions/Whitewater Reach\|Whitewater Reach]] | Adult | S | 188 | 60 m | Day & Night | A typical adult Leviathan Young of this region, with salt-crusted, barnacle-flecked hide. |
| `pop_02036` | Goldmere Coast Leviathan Young Albino | [[Regions/Goldmere Coast\|Goldmere Coast]] | Albino | S+ | 203 | 60 m | Day & Night | Like a typical Leviathan Young, but a rare pale form with white skin or fur and red eyes. |
| `pop_02037` | Whitewater Reach Leviathan Young Alpha | [[Regions/Whitewater Reach\|Whitewater Reach]] | Alpha | SS- | 218 | 75 m | Day & Night | Like a typical Leviathan Young, but larger and scarred, and others of its kind follow it, with salt-crusted, barnacle-flecked hide. |
| `pop_02038` | Whitewater Reach Leviathan Young Runt | [[Regions/Whitewater Reach\|Whitewater Reach]] | Runt | A+ | 159 | 42 m | Day & Night | Like a typical Leviathan Young, but smaller and scrappier than usual, with salt-crusted, barnacle-flecked hide. |
| `pop_02039` | Whitewater Reach Leviathan Young Scarred | [[Regions/Whitewater Reach\|Whitewater Reach]] | Scarred | S+ | 203 | 66 m | Day & Night | Like a typical Leviathan Young, but covered in old battle scars, with salt-crusted, barnacle-flecked hide. |

## Design recipe

Rig `rig_fish` · mesh `fish_base` · material `wet_scale` · VFX `mist_droplets` · palette `#2f7fd1` `#9ad7ff` `#123a5c` · triangle-based silhouette, sharp asymmetric spikes
