---
type: monster
id: mon_the_gentle_warden_keeper_of_ashira
family: "Aberrations"
rank: "B+"
tier: core
tags: [monster, aberrations, tyrant, unique]
---
# The Gentle Warden, Keeper of Ashira

![[mon_the_gentle_warden_keeper_of_ashira_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_the_gentle_warden_keeper_of_ashira_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 12,000 tris · 2.037 × 2.347 × 2.1 m · local file `Game/Assets/_Game/Art/Models/Monsters/Aberrations/mon_the_gentle_warden_keeper_of_ashira.fbx`

> The The Gentle Warden, Keeper of Ashira is a person-sized creature with a shape that keeps rearranging itself, about 2.1 m tall. Its skin is stretched, stitched and constantly shifting, colored in sickly teal, with violet-edged markings. Survivors describe a smiling elder with a face too smooth, who tests the village children. It has too many eyes, opening one after another. Faint runes glow along its body when it fights. It copies the walk of whatever it hunts, surrounded by warped air, as if space bends around it.

| Field | Value |
|---|---|
| Family · type | [[Families/Aberrations|Aberrations]] · Aberration |
| Rank · level | B+ · 120 (108–132) |
| Menace | 5 · Horror |
| Element · weakness | Void · Light |
| Size | 2.1 m |
| Behaviour | Aggressive (aggressive_chase+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 15274 · 613 · 441 · 441 · 441 · 100 |
| XP · gold | 127464 · 1225 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/amorphous\|amorphous]] · `anim_aberrant` |
| Habitats | [[Regions/Ashira Vale\|Ashira Vale]] |
| Tyrant | Yes |
| Genre | Cosmic Horror |
| Trope | Mimicking things in the dark |

**Field note:** Weak to Light. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/amorphous|amorphous]] (rigId); animation set `anim_aberrant`.
- **Dimensions:** 2.1 m high × 2.25 m long × 2.21 m wide; prefab scale 1.05.
- **Physics:** 277.8 kg, gravity ×0.84, poise 123, knockback resistance 0.72, death style `collapse_and_melt`.
- **Navigation:** speed 7.41 m/s, turn 345°/s, stopping distance 1.03 m.
- **Attack count:** 5; **signature:** a smiling elder with a face too smooth, who tests the village children.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Grasp\|Grasp]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Unfold\|Unfold]] | aoe | 1.8 | 12 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Mimic Voice\|Mimic Voice]] | debuff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Mimic Lure\|Mimic Lure]] | debuff | 0 | 16 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Null Rift\|Null Rift]] | magic | 1.5 | 10 s | Void | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

The Gentle Warden, Keeper of Ashira is a **horror aberration** encountered at B+ rank, around level 120. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a smiling elder with a face too smooth, who tests the village children. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Ashira Vale|Ashira Vale]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_aberrant`, animation set `anim_aberrant`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Aberrations B|loot_aberration_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Unreal Fragment\|Unreal Fragment]] | 60% | 1–3 |
| [[Items/Eye of Nothing\|Eye of Nothing]] | 30% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (1)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Ashira Vale\|Ashira Vale]] | 1 | B+ | 120–120 | Story |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06743` | The Gentle Warden, Keeper of Ashira | [[Regions/Ashira Vale\|Ashira Vale]] | Unique | B+ | 120 | 2.1 m | Story | Unique being; see the species entry. |

## Design recipe

Rig `rig_aberrant` · mesh `aberrant_base` · material `wet_flesh_unsettling` · VFX `void_distortion` · palette `#6e8f78` `#496051` `#8a7cff` · broken symmetry, mimicry, audio-first reveal
