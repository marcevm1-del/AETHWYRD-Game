---
type: monster
id: mon_drake_lord
family: "Dragons"
rank: "A+"
tier: core
tags: [monster, dragons]
---
# Drake Lord

![[mon_drake_lord_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_drake_lord_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Drake Lord is a huge creature with a sleek flying build, about 10 m long. Its scales are rough, scarred and spiked, colored in ember reds fading to soot black. Guild sketches always show a crown of broken horns from rivals it killed. It has burning slit pupils. An elegant crest and glowing veins of mana mark it as a champion of its kind. It circles its prey, surrounded by heat-shimmer and drifting sparks.

| Field | Value |
|---|---|
| Family · type | [[Families/Dragons|Dragons]] · Dragon |
| Rank · level | A+ · 159 (146–173) |
| Menace | 3 · Menacing |
| Element · weakness | Fire · Water |
| Size | 10 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 41955 · 775 · 646 · 517 · 581 · 100 |
| XP · gold | 9993 · 1815 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/wyvern\|wyvern]] · `anim_wyvern` |
| Habitats | [[Regions/Dragon Spine\|Dragon Spine]], [[Regions/Iron Hold\|Iron Hold]], [[Regions/Zarvan\|Zarvan]], [[Regions/Stormreach\|Stormreach]] |
| Genre | High Fantasy |
| Trope | Dragons as proud, intelligent apex beings; wyverns as their lesser kin |

**Field note:** Weak to Water. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/wyvern|wyvern]] (rigId); animation set `anim_wyvern`.
- **Dimensions:** 5 m high × 10 m long × 15.26 m wide; prefab scale 1.667.
- **Physics:** 4600 kg, gravity ×1, poise 395, knockback resistance 0.95, death style `crash_slide`.
- **Navigation:** speed 8.83 m/s, turn 190°/s, stopping distance 1.2 m.
- **Attack count:** 5; **signature:** a crown of broken horns from rivals it killed.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Talon Rake\|Talon Rake]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Dive Bomb\|Dive Bomb]] | dash | 1.9 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Tail Whip\|Tail Whip]] | aoe | 1.3 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Wing Buffet\|Wing Buffet]] | aoe | 1.1 | 9 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Ember Burst\|Ember Burst]] | magic | 1.5 | 10 s | Fire | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Drake Lord is a **menacing dragon** encountered at A+ rank, around level 159. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Water**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a crown of broken horns from rivals it killed. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Dragon Spine|Dragon Spine]], [[Regions/Iron Hold|Iron Hold]], [[Regions/Zarvan|Zarvan]], [[Regions/Stormreach|Stormreach]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_wyvern`, animation set `anim_wyvern`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Dragons A|loot_draconic_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Dragon Scale\|Dragon Scale]] | 60% | 1–3 |
| [[Items/Dragon Blood\|Dragon Blood]] | 30% | 1–1 |
| [[Items/Dragon Heart\|Dragon Heart]] | 15% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Dragons/Vesper-Touched Drake Lord|Vesper-Touched Drake Lord]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Iron Hold\|Iron Hold]] | 2 | A, A+ | 146–159 | Day & Night |
| [[Regions/Stormreach\|Stormreach]] | 4 | A+, S-, S | 159–188 | Day & Night |
| [[Regions/Dragon Spine\|Dragon Spine]] | 3 | S, S-, A- | 132–188 | Day & Night |
| [[Regions/Zarvan\|Zarvan]] | 2 | S- | 173–173 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01403` | Iron Hold Drake Lord Juvenile | [[Regions/Iron Hold\|Iron Hold]] | Juvenile | A | 146 | 8.5 m | Day & Night | Like a typical Drake Lord, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_01404` | Stormreach Drake Lord | [[Regions/Stormreach\|Stormreach]] | Adult | A+ | 159 | 10 m | Day & Night | A typical adult Drake Lord of this region, with salt-crusted, barnacle-flecked hide. |
| `pop_01405` | Stormreach Drake Lord Albino | [[Regions/Stormreach\|Stormreach]] | Albino | S- | 173 | 10 m | Day & Night | Like a typical Drake Lord, but a rare pale form with white skin or fur and red eyes. |
| `pop_01406` | Stormreach Drake Lord Scarred | [[Regions/Stormreach\|Stormreach]] | Scarred | S- | 173 | 11 m | Day & Night | Like a typical Drake Lord, but covered in old battle scars, with salt-crusted, barnacle-flecked hide. |
| `pop_01407` | Dragon Spine Drake Lord Alpha | [[Regions/Dragon Spine\|Dragon Spine]] | Alpha | S | 188 | 12.5 m | Day & Night | Like a typical Drake Lord, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_01408` | Dragon Spine Drake Lord Albino | [[Regions/Dragon Spine\|Dragon Spine]] | Albino | S- | 173 | 10 m | Day & Night | Like a typical Drake Lord, but a rare pale form with white skin or fur and red eyes. |
| `pop_01409` | Zarvan Drake Lord Albino | [[Regions/Zarvan\|Zarvan]] | Albino | S- | 173 | 10 m | Day & Night | Like a typical Drake Lord, but a rare pale form with white skin or fur and red eyes. |
| `pop_01410` | Zarvan Drake Lord Scarred | [[Regions/Zarvan\|Zarvan]] | Scarred | S- | 173 | 11 m | Day & Night | Like a typical Drake Lord, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_01411` | Stormreach Drake Lord Alpha | [[Regions/Stormreach\|Stormreach]] | Alpha | S | 188 | 12.5 m | Day & Night | Like a typical Drake Lord, but larger and scarred, and others of its kind follow it, with salt-crusted, barnacle-flecked hide. |
| `pop_01412` | Dragon Spine Drake Lord Runt | [[Regions/Dragon Spine\|Dragon Spine]] | Runt | A- | 132 | 7 m | Day & Night | Like a typical Drake Lord, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_01413` | Iron Hold Drake Lord | [[Regions/Iron Hold\|Iron Hold]] | Adult | A+ | 159 | 10 m | Day & Night | A typical adult Drake Lord of this region, with slate-grey coloring and hardened hide. |

## Design recipe

Rig `rig_wyvern` · mesh `wyvern_base` · material `dragon_scale` · VFX `embers_heat_haze` · palette `#e2502b` `#ffb347` `#3a1a12` · triangle-based silhouette, sharp asymmetric spikes
