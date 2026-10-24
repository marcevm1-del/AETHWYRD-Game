---
type: monster
id: mon_ukhu_tal_stone_giant_of_the_first_making
family: "Orcs, Ogres & Giants"
rank: "S"
tier: core
tags: [monster, orcs-ogres-giants, tyrant, unique]
---
# Ukhu-Tal, Stone Giant of the First Making

> The Ukhu-Tal, Stone Giant of the First Making is a colossal creature with a massive hunched brute frame, about 25 m tall. Its hide is weathered and natural, colored in ochre, clay and mossy stone. Survivors describe a body of terraced stone older than the Titans' war. It has alert animal eyes. Its regal silhouette is crowned by a halo-like ring of aura. It prowls, surrounded by pebbles that tremble and float near it.

| Field | Value |
|---|---|
| Family · type | [[Families/Orcs, Ogres & Giants|Orcs, Ogres & Giants]] · Giant |
| Rank · level | S · 188 (173–203) |
| Menace | 2 · Wild |
| Element · weakness | Earth · Wind |
| Size | 25 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 86788 · 762 · 1143 · 457 · 762 · 70 |
| XP · gold | 261258 · 2293 |
| Ring | 7 |
| Rig · animation | [[Systems/Rigs/large_biped\|large_biped]] · `anim_large_biped` |
| Habitats | [[Regions/Apu Highlands\|Apu Highlands]] |
| Tyrant | Yes |
| Genre | Classic Fantasy |
| Trope | Orc warbands and the Orc Disaster that devours its way to power (Tensura) |

**Field note:** Weak to Wind. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/large_biped|large_biped]] (rigId); animation set `anim_large_biped`.
- **Dimensions:** 25 m high × 7.5 m long × 10.5 m wide; prefab scale 7.143.
- **Physics:** 365625 kg, gravity ×1.43, poise 818, knockback resistance 1, death style `heavy_fall_dust`.
- **Navigation:** speed 14.73 m/s, turn 76°/s, stopping distance 5.4 m.
- **Attack count:** 5; **signature:** a body of terraced stone older than the Titans' war.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stomp\|Stomp]] | aoe | 1.3 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Club Slam\|Club Slam]] | melee | 1.8 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Grab and Throw\|Grab and Throw]] | grab | 2 | 14 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/War Cry\|War Cry]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Ukhu-Tal, Stone Giant of the First Making is a **wild giant** encountered at S rank, around level 188. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a body of terraced stone older than the Titans' war. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Apu Highlands|Apu Highlands]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_large_biped`, animation set `anim_large_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Orcs, Ogres & Giants S|loot_orc_giant_s]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Tusk\|Tusk]] | 60% | 1–3 |
| [[Items/Giant's Hide\|Giant's Hide]] | 30% | 1–1 |
| [[Items/Crude Iron\|Crude Iron]] | 15% | 1–1 |
| [[Items/S-Rank Monster Core\|S-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (1)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Apu Highlands\|Apu Highlands]] | 1 | S | 188–188 | Story |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06751` | Ukhu-Tal, Stone Giant of the First Making | [[Regions/Apu Highlands\|Apu Highlands]] | Unique | S | 188 | 25 m | Story | Unique being; see the species entry. |

## Design recipe

Rig `rig_large_biped` · mesh `large_biped_base` · material `thick_skin` · VFX `rock_debris` · palette `#8b5a2b` `#c2a878` `#4a4a3a` · real-animal silhouette with one fantasy exaggeration
