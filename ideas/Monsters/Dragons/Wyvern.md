---
type: monster
id: mon_wyvern
family: "Dragons"
rank: "B"
tier: core
tags: [monster, dragons]
---
# Wyvern

![[mon_wyvern_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_wyvern_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 30,000 tris · 13.121 × 8.001 × 5.565 m · local file `Game/Assets/_Game/Art/Models/Monsters/Dragons/mon_wyvern.fbx`

> The Wyvern is a huge creature with a sleek flying build, about 8 m long. Its scales are rough, scarred and spiked, colored in emerald, with pale jade markings. Survivors describe tattered wings and a venom-tipped tail. It has eyes that catch torchlight like coins. Faint runes glow along its body when it fights. It strides with heavy steps, surrounded by swirling leaves and a constant breeze.

| Field | Value |
|---|---|
| Family · type | [[Families/Dragons|Dragons]] · Dragon |
| Rank · level | B · 108 (96–120) |
| Menace | 3 · Menacing |
| Element · weakness | Wind · Fire |
| Size | 8 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 22092 · 530 · 442 · 354 · 398 · 100 |
| XP · gold | 5386 · 1057 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/wyvern\|wyvern]] · `anim_wyvern` |
| Habitats | [[Regions/Dragon Spine\|Dragon Spine]], [[Regions/Frostveil\|Frostveil]], [[Regions/Stormreach\|Stormreach]], [[Regions/Iron Hold\|Iron Hold]], [[Regions/Heavenreach\|Heavenreach]] |
| Genre | High Fantasy |
| Trope | Dragons as proud, intelligent apex beings; wyverns as their lesser kin |

**Field note:** Weak to Fire. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/wyvern|wyvern]] (rigId); animation set `anim_wyvern`.
- **Dimensions:** 4 m high × 8 m long × 12.21 m wide; prefab scale 1.333.
- **Physics:** 2119.7 kg, gravity ×0.8, poise 246, knockback resistance 0.92, death style `crash_slide`.
- **Navigation:** speed 8.12 m/s, turn 212°/s, stopping distance 1.04 m.
- **Attack count:** 5; **signature:** tattered wings and a venom-tipped tail.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Talon Rake\|Talon Rake]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Dive Bomb\|Dive Bomb]] | dash | 1.9 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Tail Whip\|Tail Whip]] | aoe | 1.3 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Wing Buffet\|Wing Buffet]] | aoe | 1.1 | 9 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Gale Cutter\|Gale Cutter]] | magic | 1.5 | 10 s | Wind | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Wyvern is a **menacing dragon** encountered at B rank, around level 108. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** tattered wings and a venom-tipped tail. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Dragon Spine|Dragon Spine]], [[Regions/Frostveil|Frostveil]], [[Regions/Stormreach|Stormreach]], [[Regions/Iron Hold|Iron Hold]], [[Regions/Heavenreach|Heavenreach]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_wyvern`, animation set `anim_wyvern`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Dragons B|loot_draconic_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Dragon Scale\|Dragon Scale]] | 60% | 1–3 |
| [[Items/Dragon Blood\|Dragon Blood]] | 30% | 1–1 |
| [[Items/Dragon Heart\|Dragon Heart]] | 15% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Dragons/Rime Wyvern|Rime Wyvern]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Dragon Spine\|Dragon Spine]] | 4 | C+, B+, B | 86–120 | Day & Night |
| [[Regions/Iron Hold\|Iron Hold]] | 1 | B | 108–108 | Day & Night |
| [[Regions/Stormreach\|Stormreach]] | 3 | B-, A-, B | 96–132 | Day & Night |
| [[Regions/Frostveil\|Frostveil]] | 2 | B-, B+ | 96–120 | Day & Night |
| [[Regions/Heavenreach\|Heavenreach]] | 1 | B+ | 120–120 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01381` | Dragon Spine Wyvern Runt | [[Regions/Dragon Spine\|Dragon Spine]] | Runt | C+ | 86 | 5.6 m | Day & Night | Like a typical Wyvern, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_01382` | Dragon Spine Wyvern Albino | [[Regions/Dragon Spine\|Dragon Spine]] | Albino | B+ | 120 | 8 m | Day & Night | Like a typical Wyvern, but a rare pale form with white skin or fur and red eyes. |
| `pop_01383` | Dragon Spine Wyvern | [[Regions/Dragon Spine\|Dragon Spine]] | Adult | B | 108 | 8 m | Day & Night | A typical adult Wyvern of this region, with slate-grey coloring and hardened hide. |
| `pop_01384` | Iron Hold Wyvern | [[Regions/Iron Hold\|Iron Hold]] | Adult | B | 108 | 8 m | Day & Night | A typical adult Wyvern of this region, with slate-grey coloring and hardened hide. |
| `pop_01385` | Dragon Spine Wyvern Scarred | [[Regions/Dragon Spine\|Dragon Spine]] | Scarred | B+ | 120 | 8.8 m | Day & Night | Like a typical Wyvern, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_01386` | Stormreach Wyvern Juvenile | [[Regions/Stormreach\|Stormreach]] | Juvenile | B- | 96 | 6.8 m | Day & Night | Like a typical Wyvern, but young, with brighter colors and unworn features, with salt-crusted, barnacle-flecked hide. |
| `pop_01387` | Frostveil Wyvern Juvenile | [[Regions/Frostveil\|Frostveil]] | Juvenile | B- | 96 | 6.8 m | Day & Night | Like a typical Wyvern, but young, with brighter colors and unworn features, with a thick, frost-rimed coat. |
| `pop_01388` | Heavenreach Wyvern Scarred | [[Regions/Heavenreach\|Heavenreach]] | Scarred | B+ | 120 | 8.8 m | Day & Night | Like a typical Wyvern, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_01389` | Stormreach Wyvern Alpha | [[Regions/Stormreach\|Stormreach]] | Alpha | A- | 132 | 10 m | Day & Night | Like a typical Wyvern, but larger and scarred, and others of its kind follow it, with salt-crusted, barnacle-flecked hide. |
| `pop_01390` | Frostveil Wyvern Scarred | [[Regions/Frostveil\|Frostveil]] | Scarred | B+ | 120 | 8.8 m | Day & Night | Like a typical Wyvern, but covered in old battle scars, with a thick, frost-rimed coat. |
| `pop_01391` | Stormreach Wyvern | [[Regions/Stormreach\|Stormreach]] | Adult | B | 108 | 8 m | Day & Night | A typical adult Wyvern of this region, with salt-crusted, barnacle-flecked hide. |

## Design recipe

Rig `rig_wyvern` · mesh `wyvern_base` · material `dragon_scale` · VFX `wind_ribbons` · palette `#3d7839` `#2c5127` `#8fe0bd` · triangle-based silhouette, sharp asymmetric spikes
