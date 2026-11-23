---
type: monster
id: mon_storm_djinn
family: "Elementals & Spirits"
rank: "B+"
tier: core
tags: [monster, elementals-spirits]
---
# Storm Djinn

![[mon_storm_djinn_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_storm_djinn_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 20,000 tris · 3.061 × 3.338 × 4 m · local file `Game/Assets/_Game/Art/Models/Monsters/Elementals & Spirits/mon_storm_djinn.fbx`

> The Storm Djinn is a large creature with a drifting, half-formed body, about 4 m tall. Its body is rough, scarred and spiked, colored in storm violet shot through with electric yellow. Its most striking feature is a cloud body with lightning tattoos. It has eyes that catch torchlight like coins. Faint runes glow along its body when it fights. It strides with heavy steps, surrounded by crackling arcs that jump across its body.

| Field | Value |
|---|---|
| Family · type | [[Families/Elementals & Spirits|Elementals & Spirits]] · Elemental |
| Rank · level | B+ · 120 (108–132) |
| Menace | 3 · Menacing |
| Element · weakness | Lightning · Earth |
| Size | 4 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 15171 · 294 · 343 · 686 · 637 · 90 |
| XP · gold | 6373 · 1225 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/spirit_float\|spirit_float]] · `anim_floating` |
| Habitats | [[Regions/Hoshizora\|Hoshizora]], [[Regions/Shen-Lu\|Shen-Lu]], [[Regions/Dragon Spine\|Dragon Spine]], [[Regions/Iron Hold\|Iron Hold]] |
| Genre | Spirit Realm |
| Trope | Spirits you can contract with; elemental kings |

**Field note:** Weak to Earth. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/spirit_float|spirit_float]] (rigId); animation set `anim_floating`.
- **Dimensions:** 4 m high × 1.2 m long × 2.56 m wide; prefab scale 4.
- **Physics:** 6.4 kg, gravity ×0, poise 54, knockback resistance 0.12, death style `dissolve_into_motes`.
- **Navigation:** speed 12.3 m/s, turn 360°/s, stopping distance 1.4 m.
- **Attack count:** 5; **signature:** a cloud body with lightning tattoos.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Chill Touch\|Chill Touch]] | melee | 0.9 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Phase Lunge\|Phase Lunge]] | dash | 1.3 | 7 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Wail\|Wail]] | aoe | 1.2 | 12 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Elemental Burst\|Elemental Burst]] | magic | 1.4 | 9 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Static Arc\|Static Arc]] | magic | 1.5 | 10 s | Lightning | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Storm Djinn is a **menacing elemental** encountered at B+ rank, around level 120. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Earth**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a cloud body with lightning tattoos. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Hoshizora|Hoshizora]], [[Regions/Shen-Lu|Shen-Lu]], [[Regions/Dragon Spine|Dragon Spine]], [[Regions/Iron Hold|Iron Hold]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_floating`, animation set `anim_floating`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Elementals & Spirits B|loot_elemental_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Elemental Essence\|Elemental Essence]] | 60% | 1–3 |
| [[Items/Spirit Mote\|Spirit Mote]] | 30% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Elementals & Spirits/Crag Djinn|Crag Djinn]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Iron Hold\|Iron Hold]] | 2 | B+, A | 120–146 | Day & Night |
| [[Regions/Shen-Lu\|Shen-Lu]] | 3 | A-, B-, A+ | 96–159 | Day & Night |
| [[Regions/Dragon Spine\|Dragon Spine]] | 4 | A+, B+, B, B- | 96–159 | Day & Night |
| [[Regions/Hoshizora\|Hoshizora]] | 2 | A-, A | 132–146 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01661` | Iron Hold Storm Djinn | [[Regions/Iron Hold\|Iron Hold]] | Adult | B+ | 120 | 4 m | Day & Night | A typical adult Storm Djinn of this region, with slate-grey coloring and hardened hide. |
| `pop_01662` | Iron Hold Storm Djinn Alpha | [[Regions/Iron Hold\|Iron Hold]] | Alpha | A | 146 | 5 m | Day & Night | Like a typical Storm Djinn, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_01663` | Shen-Lu Storm Djinn Albino | [[Regions/Shen-Lu\|Shen-Lu]] | Albino | A- | 132 | 4 m | Day & Night | Like a typical Storm Djinn, but a rare pale form with white skin or fur and red eyes. |
| `pop_01664` | Dragon Spine Storm Djinn Elderborn | [[Regions/Dragon Spine\|Dragon Spine]] | Elderborn | A+ | 159 | 5.4 m | Day & Night | Like a typical Storm Djinn, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_01665` | Shen-Lu Storm Djinn Runt | [[Regions/Shen-Lu\|Shen-Lu]] | Runt | B- | 96 | 2.8 m | Day & Night | Like a typical Storm Djinn, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_01666` | Dragon Spine Storm Djinn | [[Regions/Dragon Spine\|Dragon Spine]] | Adult | B+ | 120 | 4 m | Day & Night | A typical adult Storm Djinn of this region, with slate-grey coloring and hardened hide. |
| `pop_01667` | Dragon Spine Storm Djinn Juvenile | [[Regions/Dragon Spine\|Dragon Spine]] | Juvenile | B | 108 | 3.4 m | Day & Night | Like a typical Storm Djinn, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_01668` | Hoshizora Storm Djinn Scarred | [[Regions/Hoshizora\|Hoshizora]] | Scarred | A- | 132 | 4.4 m | Day & Night | Like a typical Storm Djinn, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_01669` | Hoshizora Storm Djinn Alpha | [[Regions/Hoshizora\|Hoshizora]] | Alpha | A | 146 | 5 m | Day & Night | Like a typical Storm Djinn, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_01670` | Dragon Spine Storm Djinn Runt | [[Regions/Dragon Spine\|Dragon Spine]] | Runt | B- | 96 | 2.8 m | Day & Night | Like a typical Storm Djinn, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_01671` | Shen-Lu Storm Djinn Elderborn | [[Regions/Shen-Lu\|Shen-Lu]] | Elderborn | A+ | 159 | 5.4 m | Day & Night | Like a typical Storm Djinn, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |

## Design recipe

Rig `rig_floating` · mesh `floating_base` · material `elemental_emissive` · VFX `arc_sparks` · palette `#ffe14d` `#6c5ce7` `#1e1e40` · triangle-based silhouette, sharp asymmetric spikes
