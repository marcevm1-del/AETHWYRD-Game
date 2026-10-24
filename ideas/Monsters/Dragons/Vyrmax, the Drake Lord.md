---
type: monster
id: mon_vyrmax_the_drake_lord
family: "Dragons"
rank: "S"
tier: core
tags: [monster, dragons, tyrant, unique]
---
# Vyrmax, the Drake Lord

![[mon_vyrmax_the_drake_lord_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_vyrmax_the_drake_lord_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (3,270 tris · 21.914 × 14 × 15.557 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Vyrmax, the Drake Lord is a huge creature with a bipedal winged body with wing-arms, about 14 m long. Its scales are rough, scarred and spiked, colored in ember reds fading to soot black. Look for a crown of broken horns from every rival drake it killed. It has narrow glowing eyes. Its regal silhouette is crowned by a halo-like ring of aura. It strides with heavy steps, surrounded by heat-shimmer and drifting sparks.

| Field | Value |
|---|---|
| Family · type | [[Families/Dragons|Dragons]] · Dragon |
| Rank · level | S · 188 (173–203) |
| Menace | 3 · Menacing |
| Element · weakness | Fire · Water |
| Size | 14 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 59054 · 914 · 762 · 610 · 686 · 100 |
| XP · gold | 261258 · 2293 |
| Ring | 7 |
| Rig · animation | [[Systems/Rigs/wyvern\|wyvern]] · `anim_wyvern` |
| Habitats | [[Regions/Dragon Spine\|Dragon Spine]] |
| Tyrant | Yes |
| Genre | High Fantasy |
| Trope | Dragons as proud, intelligent apex beings; wyverns as their lesser kin |

**Field note:** Weak to Water. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/wyvern|wyvern]] (rigId); animation set `anim_wyvern`.
- **Dimensions:** 7 m high × 14 m long × 21.36 m wide; prefab scale 2.333.
- **Physics:** 12622.4 kg, gravity ×1, poise 831, knockback resistance 0.98, death style `crash_slide`.
- **Navigation:** speed 9.49 m/s, turn 160°/s, stopping distance 1.52 m.
- **Attack count:** 5; **signature:** a crown of broken horns from every rival drake it killed.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Talon Rake\|Talon Rake]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Dive Bomb\|Dive Bomb]] | dash | 1.9 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Tail Whip\|Tail Whip]] | aoe | 1.3 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Wing Buffet\|Wing Buffet]] | aoe | 1.1 | 9 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Ember Burst\|Ember Burst]] | magic | 1.5 | 10 s | Fire | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Vyrmax, the Drake Lord is a **menacing dragon** encountered at S rank, around level 188. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Water**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a crown of broken horns from every rival drake it killed. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Dragon Spine|Dragon Spine]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_wyvern`, animation set `anim_wyvern`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Dragons S|loot_draconic_s]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Dragon Scale\|Dragon Scale]] | 60% | 1–3 |
| [[Items/Dragon Blood\|Dragon Blood]] | 30% | 1–1 |
| [[Items/Dragon Heart\|Dragon Heart]] | 15% | 1–1 |
| [[Items/S-Rank Monster Core\|S-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (1)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Dragon Spine\|Dragon Spine]] | 1 | S | 188–188 | Story |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06744` | Vyrmax, the Drake Lord | [[Regions/Dragon Spine\|Dragon Spine]] | Unique | S | 188 | 14 m | Story | Unique being; see the species entry. |

## Design recipe

Rig `rig_wyvern` · mesh `wyvern_base` · material `dragon_scale` · VFX `embers_heat_haze` · palette `#e2502b` `#ffb347` `#3a1a12` · triangle-based silhouette, sharp asymmetric spikes
