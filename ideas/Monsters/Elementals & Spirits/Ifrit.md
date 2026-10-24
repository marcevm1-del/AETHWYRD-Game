---
type: monster
id: mon_ifrit
family: "Elementals & Spirits"
rank: "B"
tier: core
tags: [monster, elementals-spirits]
---
# Ifrit

![[mon_ifrit_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_ifrit_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Ifrit is a huge creature with a drifting, half-formed body, about 5 m tall. Its body is rough, scarred and spiked, colored in ember reds fading to soot black. Look for a torso of fire rising from a smoking lamp. It has narrow glowing eyes. Faint runes glow along its body when it fights. It charges without hesitation, surrounded by heat-shimmer and drifting sparks.

| Field | Value |
|---|---|
| Family · type | [[Families/Elementals & Spirits|Elementals & Spirits]] · Elemental |
| Rank · level | B · 108 (96–120) |
| Menace | 3 · Menacing |
| Element · weakness | Fire · Water |
| Size | 5 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 13927 · 265 · 309 · 619 · 575 · 90 |
| XP · gold | 5386 · 1057 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/spirit_float\|spirit_float]] · `anim_floating` |
| Habitats | [[Regions/Dragon Spine\|Dragon Spine]], [[Regions/Iron Hold\|Iron Hold]], [[Regions/Shen-Lu\|Shen-Lu]], [[Regions/Zarvan\|Zarvan]] |
| Genre | Spirit Realm |
| Trope | Spirits you can contract with; elemental kings |

**Field note:** Weak to Water. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/spirit_float|spirit_float]] (rigId); animation set `anim_floating`.
- **Dimensions:** 5 m high × 1.5 m long × 3.2 m wide; prefab scale 5.
- **Physics:** 12.5 kg, gravity ×0, poise 79, knockback resistance 0.12, death style `dissolve_into_motes`.
- **Navigation:** speed 13.37 m/s, turn 322°/s, stopping distance 1.65 m.
- **Attack count:** 5; **signature:** a torso of fire rising from a smoking lamp.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Chill Touch\|Chill Touch]] | melee | 0.9 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Phase Lunge\|Phase Lunge]] | dash | 1.3 | 7 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Wail\|Wail]] | aoe | 1.2 | 12 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Elemental Burst\|Elemental Burst]] | magic | 1.4 | 9 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Ember Burst\|Ember Burst]] | magic | 1.5 | 10 s | Fire | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Ifrit is a **menacing elemental** encountered at B rank, around level 108. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Water**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a torso of fire rising from a smoking lamp. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Dragon Spine|Dragon Spine]], [[Regions/Iron Hold|Iron Hold]], [[Regions/Shen-Lu|Shen-Lu]], [[Regions/Zarvan|Zarvan]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_floating`, animation set `anim_floating`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Elementals & Spirits B|loot_elemental_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Elemental Essence\|Elemental Essence]] | 60% | 1–3 |
| [[Items/Spirit Mote\|Spirit Mote]] | 30% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Elementals & Spirits/Phantom Ifrit|Phantom Ifrit]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Zarvan\|Zarvan]] | 4 | B+, A-, A, C+ | 86–146 | Day & Night |
| [[Regions/Shen-Lu\|Shen-Lu]] | 2 | B-, B+ | 96–120 | Day & Night |
| [[Regions/Dragon Spine\|Dragon Spine]] | 2 | C+, B+ | 86–120 | Day & Night |
| [[Regions/Iron Hold\|Iron Hold]] | 3 | B, B+ | 108–120 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01650` | Zarvan Ifrit Scarred | [[Regions/Zarvan\|Zarvan]] | Scarred | B+ | 120 | 5.5 m | Day & Night | Like a typical Ifrit, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_01651` | Shen-Lu Ifrit Juvenile | [[Regions/Shen-Lu\|Shen-Lu]] | Juvenile | B- | 96 | 4.25 m | Day & Night | Like a typical Ifrit, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_01652` | Zarvan Ifrit Alpha | [[Regions/Zarvan\|Zarvan]] | Alpha | A- | 132 | 6.25 m | Day & Night | Like a typical Ifrit, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_01653` | Zarvan Ifrit Elderborn | [[Regions/Zarvan\|Zarvan]] | Elderborn | A | 146 | 6.75 m | Day & Night | Like a typical Ifrit, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_01654` | Dragon Spine Ifrit Runt | [[Regions/Dragon Spine\|Dragon Spine]] | Runt | C+ | 86 | 3.5 m | Day & Night | Like a typical Ifrit, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_01655` | Iron Hold Ifrit | [[Regions/Iron Hold\|Iron Hold]] | Adult | B | 108 | 5 m | Day & Night | A typical adult Ifrit of this region, with slate-grey coloring and hardened hide. |
| `pop_01656` | Dragon Spine Ifrit Scarred | [[Regions/Dragon Spine\|Dragon Spine]] | Scarred | B+ | 120 | 5.5 m | Day & Night | Like a typical Ifrit, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_01657` | Iron Hold Ifrit Albino | [[Regions/Iron Hold\|Iron Hold]] | Albino | B+ | 120 | 5 m | Day & Night | Like a typical Ifrit, but a rare pale form with white skin or fur and red eyes. |
| `pop_01658` | Iron Hold Ifrit Scarred | [[Regions/Iron Hold\|Iron Hold]] | Scarred | B+ | 120 | 5.5 m | Day & Night | Like a typical Ifrit, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_01659` | Zarvan Ifrit Runt | [[Regions/Zarvan\|Zarvan]] | Runt | C+ | 86 | 3.5 m | Day & Night | Like a typical Ifrit, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_01660` | Shen-Lu Ifrit Scarred | [[Regions/Shen-Lu\|Shen-Lu]] | Scarred | B+ | 120 | 5.5 m | Day & Night | Like a typical Ifrit, but covered in old battle scars, with slate-grey coloring and hardened hide. |

## Design recipe

Rig `rig_floating` · mesh `floating_base` · material `elemental_emissive` · VFX `embers_heat_haze` · palette `#e2502b` `#ffb347` `#3a1a12` · triangle-based silhouette, sharp asymmetric spikes
