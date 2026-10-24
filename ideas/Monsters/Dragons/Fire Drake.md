---
type: monster
id: mon_fire_drake
family: "Dragons"
rank: "D"
tier: core
tags: [monster, dragons]
---
# Fire Drake

![[mon_fire_drake_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_fire_drake_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Fire Drake is a large creature with a long-legged predatory quadruped build, about 3 m long. Its scales are rough, scarred and spiked, colored in ember reds fading to soot black. Its most striking feature is ember scales and a magma-glowing belly. It has burning slit pupils. A distinctive marking runs along its back. It charges without hesitation, surrounded by heat-shimmer and drifting sparks.

| Field | Value |
|---|---|
| Family · type | [[Families/Dragons|Dragons]] · Dragon |
| Rank · level | D · 48 (40–56) |
| Menace | 3 · Menacing |
| Element · weakness | Fire · Water |
| Size | 3 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 4870 · 242 · 202 · 162 · 182 · 100 |
| XP · gold | 1477 · 342 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/quad_large\|quad_large]] · `anim_quad_large` |
| Habitats | [[Regions/Iron Hold\|Iron Hold]], [[Regions/Hoshizora\|Hoshizora]], [[Regions/Lirian\|Lirian]] |
| Genre | High Fantasy |
| Trope | Dragons as proud, intelligent apex beings; wyverns as their lesser kin |

**Field note:** Weak to Water. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_large|quad_large]] (rigId); animation set `anim_quad_large`.
- **Dimensions:** 1.95 m high × 3 m long × 0.48 m wide; prefab scale 0.75.
- **Physics:** 540 kg, gravity ×1.2, poise 79, knockback resistance 0.91, death style `heavy_fall_dust`.
- **Navigation:** speed 7.72 m/s, turn 185°/s, stopping distance 1 m.
- **Attack count:** 5; **signature:** ember scales and a magma-glowing belly.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Maul\|Maul]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Pounce\|Pounce]] | dash | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Howl\|Howl]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Wing Buffet\|Wing Buffet]] | aoe | 1.1 | 9 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Ember Burst\|Ember Burst]] | magic | 1.5 | 10 s | Fire | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Fire Drake is a **menacing dragon** encountered at D rank, around level 48. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Water**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** ember scales and a magma-glowing belly. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Iron Hold|Iron Hold]], [[Regions/Hoshizora|Hoshizora]], [[Regions/Lirian|Lirian]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_large`, animation set `anim_quad_large`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Dragons D|loot_draconic_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Dragon Scale\|Dragon Scale]] | 60% | 1–3 |
| [[Items/Dragon Blood\|Dragon Blood]] | 30% | 1–1 |
| [[Items/Dragon Heart\|Dragon Heart]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Dragons/Greater Fire Drake|Greater Fire Drake]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Lirian\|Lirian]] | 3 | D+, D | 48–56 | Day & Night |
| [[Regions/Hoshizora\|Hoshizora]] | 3 | E+, D+, D | 32–56 | Day & Night |
| [[Regions/Iron Hold\|Iron Hold]] | 5 | D+, D, D-, C- | 40–65 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01348` | Lirian Fire Drake Albino | [[Regions/Lirian\|Lirian]] | Albino | D+ | 56 | 3 m | Day & Night | Like a typical Fire Drake, but a rare pale form with white skin or fur and red eyes. |
| `pop_01349` | Hoshizora Fire Drake Runt | [[Regions/Hoshizora\|Hoshizora]] | Runt | E+ | 32 | 2.1 m | Day & Night | Like a typical Fire Drake, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_01350` | Hoshizora Fire Drake Albino | [[Regions/Hoshizora\|Hoshizora]] | Albino | D+ | 56 | 3 m | Day & Night | Like a typical Fire Drake, but a rare pale form with white skin or fur and red eyes. |
| `pop_01351` | Lirian Fire Drake | [[Regions/Lirian\|Lirian]] | Adult | D | 48 | 3 m | Day & Night | A typical adult Fire Drake of this region, with salt-crusted, barnacle-flecked hide. |
| `pop_01352` | Iron Hold Fire Drake Albino | [[Regions/Iron Hold\|Iron Hold]] | Albino | D+ | 56 | 3 m | Day & Night | Like a typical Fire Drake, but a rare pale form with white skin or fur and red eyes. |
| `pop_01353` | Iron Hold Fire Drake Scarred | [[Regions/Iron Hold\|Iron Hold]] | Scarred | D+ | 56 | 3.3 m | Day & Night | Like a typical Fire Drake, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_01354` | Iron Hold Fire Drake | [[Regions/Iron Hold\|Iron Hold]] | Adult | D | 48 | 3 m | Day & Night | A typical adult Fire Drake of this region, with slate-grey coloring and hardened hide. |
| `pop_01355` | Lirian Fire Drake Scarred | [[Regions/Lirian\|Lirian]] | Scarred | D+ | 56 | 3.3 m | Day & Night | Like a typical Fire Drake, but covered in old battle scars, with salt-crusted, barnacle-flecked hide. |
| `pop_01356` | Iron Hold Fire Drake Juvenile | [[Regions/Iron Hold\|Iron Hold]] | Juvenile | D- | 40 | 2.55 m | Day & Night | Like a typical Fire Drake, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_01357` | Iron Hold Fire Drake Alpha | [[Regions/Iron Hold\|Iron Hold]] | Alpha | C- | 65 | 3.75 m | Day & Night | Like a typical Fire Drake, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_01358` | Hoshizora Fire Drake | [[Regions/Hoshizora\|Hoshizora]] | Adult | D | 48 | 3 m | Day & Night | A typical adult Fire Drake of this region, with slate-grey coloring and hardened hide. |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `dragon_scale` · VFX `embers_heat_haze` · palette `#e2502b` `#ffb347` `#3a1a12` · triangle-based silhouette, sharp asymmetric spikes
