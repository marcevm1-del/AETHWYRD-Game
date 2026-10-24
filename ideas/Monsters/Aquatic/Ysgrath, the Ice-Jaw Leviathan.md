---
type: monster
id: mon_ysgrath_the_ice_jaw_leviathan
family: "Aquatic"
rank: "S"
tier: core
tags: [monster, aquatic, tyrant, unique]
---
# Ysgrath, the Ice-Jaw Leviathan

> The Ysgrath, the Ice-Jaw Leviathan is a colossal creature with a streamlined aquatic body, about 45 m long. Its scales and skin are rough, scarred and spiked, colored in pale blues and frost-white. Look for jaws of blue ice that break the frozen sea from below. It has burning slit pupils. Its regal silhouette is crowned by a halo-like ring of aura. It strides with heavy steps, surrounded by falling snow motes and frosted ground where it steps.

| Field | Value |
|---|---|
| Family · type | [[Families/Aquatic|Aquatic]] · Aquatic |
| Rank · level | S · 188 (173–203) |
| Menace | 3 · Menacing |
| Element · weakness | Ice · Fire |
| Size | 45 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 70607 · 953 · 686 · 686 · 686 · 100 |
| XP · gold | 261258 · 2293 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/aquatic\|aquatic]] · `anim_fish` |
| Habitats | [[Regions/Whitewater Reach\|Whitewater Reach]] |
| Tyrant | Yes |
| Genre | Seafaring |
| Trope | Sea kings and krakens (One Piece), sirens and merfolk |

**Field note:** Weak to Fire. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/aquatic|aquatic]] (rigId); animation set `anim_fish`.
- **Dimensions:** 18 m high × 45 m long × 16.2 m wide; prefab scale 30.
- **Physics:** 2305462.5 kg, gravity ×1.05, poise 18406, knockback resistance 0.48, death style `float_belly_up`.
- **Navigation:** speed 29.95 m/s, turn 60°/s, stopping distance 5.8 m.
- **Attack count:** 5; **signature:** jaws of blue ice that break the frozen sea from below.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Bite\|Bite]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Breach Lunge\|Breach Lunge]] | dash | 1.7 | 9 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Thrash\|Thrash]] | aoe | 1.3 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Tidal Drag\|Tidal Drag]] | grab | 1.3 | 11 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Frost Breath\|Frost Breath]] | magic | 1.5 | 10 s | Ice | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Ysgrath, the Ice-Jaw Leviathan is a **menacing aquatic** encountered at S rank, around level 188. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** jaws of blue ice that break the frozen sea from below. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Whitewater Reach|Whitewater Reach]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_fish`, animation set `anim_fish`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Aquatic S|loot_aquatic_s]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Fish Scale\|Fish Scale]] | 60% | 1–3 |
| [[Items/Pearl\|Pearl]] | 30% | 1–1 |
| [[Items/Ink Sac\|Ink Sac]] | 15% | 1–1 |
| [[Items/S-Rank Monster Core\|S-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (1)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Whitewater Reach\|Whitewater Reach]] | 1 | S | 188–188 | Story |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06731` | Ysgrath, the Ice-Jaw Leviathan | [[Regions/Whitewater Reach\|Whitewater Reach]] | Unique | S | 188 | 45 m | Story | Unique being; see the species entry. |

## Design recipe

Rig `rig_fish` · mesh `fish_base` · material `wet_scale` · VFX `frost_trail_snow` · palette `#bfe9ff` `#5fa8d3` `#f4fbff` · triangle-based silhouette, sharp asymmetric spikes
