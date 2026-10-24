---
type: monster
id: mon_the_nightmother_queen_of_the_nightshifters
family: "Aberrations"
rank: "A+"
tier: core
tags: [monster, aberrations, tyrant, unique]
---
# The Nightmother, Queen of the Nightshifters

![[mon_the_nightmother_queen_of_the_nightshifters_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_the_nightmother_queen_of_the_nightshifters_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The The Nightmother, Queen of the Nightshifters is a person-sized creature with a tall, impossibly thin frame, about 2.2 m tall. Its skin is stretched, stitched and constantly shifting, colored in ink black with bruised violet. Survivors describe a kindly village grandmother whose shadow has wings. It has a human-like face in the wrong place. An elegant crest and glowing veins of mana mark it as a champion of its kind. It crawls across ceilings, surrounded by shadows that lean toward it.

| Field | Value |
|---|---|
| Family · type | [[Families/Aberrations|Aberrations]] · Aberration |
| Rank · level | A+ · 159 (146–173) |
| Menace | 5 · Horror |
| Element · weakness | Dark · Light |
| Size | 2.2 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 23628 · 808 · 581 · 581 · 581 · 100 |
| XP · gold | 199864 · 1815 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/amorphous\|amorphous]] · `anim_aberrant` |
| Habitats | [[Regions/Lumbaya\|Lumbaya]] |
| Tyrant | Yes |
| Genre | Cosmic Horror |
| Trope | Mimicking things in the dark |

**Field note:** Weak to Light. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/amorphous|amorphous]] (rigId); animation set `anim_aberrant`.
- **Dimensions:** 2.2 m high × 2.36 m long × 2.31 m wide; prefab scale 1.1.
- **Physics:** 319.4 kg, gravity ×1.2, poise 146, knockback resistance 0.75, death style `collapse_and_melt`.
- **Navigation:** speed 7.97 m/s, turn 337°/s, stopping distance 1.06 m.
- **Attack count:** 5; **signature:** a kindly village grandmother whose shadow has wings.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Grasp\|Grasp]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Unfold\|Unfold]] | aoe | 1.8 | 12 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Mimic Voice\|Mimic Voice]] | debuff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Mimic Lure\|Mimic Lure]] | debuff | 0 | 16 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

The Nightmother, Queen of the Nightshifters is a **horror aberration** encountered at A+ rank, around level 159. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a kindly village grandmother whose shadow has wings. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Lumbaya|Lumbaya]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_aberrant`, animation set `anim_aberrant`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Aberrations A|loot_aberration_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Unreal Fragment\|Unreal Fragment]] | 60% | 1–3 |
| [[Items/Eye of Nothing\|Eye of Nothing]] | 30% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (1)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Lumbaya\|Lumbaya]] | 1 | A+ | 159–159 | Story |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06739` | The Nightmother, Queen of the Nightshifters | [[Regions/Lumbaya\|Lumbaya]] | Unique | A+ | 159 | 2.2 m | Story | Unique being; see the species entry. |

## Design recipe

Rig `rig_aberrant` · mesh `aberrant_base` · material `wet_flesh_unsettling` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · broken symmetry, mimicry, audio-first reveal
