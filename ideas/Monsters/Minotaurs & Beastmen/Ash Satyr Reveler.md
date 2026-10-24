---
type: monster
id: mon_ash_satyr_reveler
family: "Minotaurs & Beastmen"
rank: "D+"
tier: variant
tags: [monster, minotaurs-beastmen]
---
# Ash Satyr Reveler

![[mon_ash_satyr_reveler_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_ash_satyr_reveler_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,742 tris · 0.921 × 0.914 × 1.7 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Ash Satyr Reveler is a person-sized creature with an upright humanoid build, about 1.7 m tall. Its hide is weathered and natural, colored in ember reds fading to soot black. Survivors describe goat legs and a panpipe that makes you dance. It has amber predator eyes. A distinctive marking runs along its back. It stalks low to the ground, surrounded by heat-shimmer and drifting sparks. This Fire-attuned variant carries one extra elemental feature, like element-scarred hide, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Minotaurs & Beastmen|Minotaurs & Beastmen]] · Beastman |
| Variant of | [[Monsters/Minotaurs & Beastmen/Satyr Reveler\|Satyr Reveler]] (elemental) |
| Rank · level | D+ · 56 (48–65) |
| Menace | 2 · Wild |
| Element · weakness | Fire · Water |
| Size | 1.7 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 5036 · 281 · 234 · 187 · 211 · 100 |
| XP · gold | 1888 · 423 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Iron Hold\|Iron Hold]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Umbravel\|Umbravel]] |
| Genre | Labyrinth Myth |
| Trope | The minotaur that appears where it shouldn't (DanMachi), Greek labyrinth myth |

**Field note:** Weak to Water. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 1.7 m high × 0.51 m long × 0.54 m wide; prefab scale 0.944.
- **Physics:** 63.9 kg, gravity ×1.5, poise 63, knockback resistance 0.36, death style `ragdoll`.
- **Navigation:** speed 4.79 m/s, turn 307°/s, stopping distance 0.69 m.
- **Attack count:** 5; **signature:** goat legs and a panpipe that makes you dance.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Horn Charge\|Horn Charge]] | dash | 1.8 | 9 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Ember Burst\|Ember Burst]] | magic | 1.5 | 10 s | Fire | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Ash Satyr Reveler is a **wild beastman** encountered at D+ rank, around level 56. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Water**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** goat legs and a panpipe that makes you dance. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Iron Hold|Iron Hold]], [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Umbravel|Umbravel]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Minotaurs & Beastmen D|loot_minotaur_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Horn\|Horn]] | 60% | 1–3 |
| [[Items/Labyrinth Bronze\|Labyrinth Bronze]] | 30% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Umbravel\|Umbravel]] | 3 | C-, D-, D | 40–65 | Day & Night |
| [[Regions/Iron Hold\|Iron Hold]] | 5 | C, D-, C-, C+, D+ | 40–86 | Day & Night |
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 3 | C-, D- | 40–65 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04091` | Umbravel Ash Satyr Reveler Scarred | [[Regions/Umbravel\|Umbravel]] | Scarred | C- | 65 | 1.87 m | Day & Night | Like a typical Ash Satyr Reveler, but covered in old battle scars, with bioluminescent spots along its body. |
| `pop_04092` | Iron Hold Ash Satyr Reveler Alpha | [[Regions/Iron Hold\|Iron Hold]] | Alpha | C | 76 | 2.13 m | Day & Night | Like a typical Ash Satyr Reveler, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_04093` | Great Labyrinth (Floors 1-40) Ash Satyr Reveler Scarred | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Scarred | C- | 65 | 1.87 m | Day & Night | Like a typical Ash Satyr Reveler, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_04094` | Great Labyrinth (Floors 1-40) Ash Satyr Reveler Albino | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Albino | C- | 65 | 1.7 m | Day & Night | Like a typical Ash Satyr Reveler, but a rare pale form with white skin or fur and red eyes. |
| `pop_04095` | Umbravel Ash Satyr Reveler Runt | [[Regions/Umbravel\|Umbravel]] | Runt | D- | 40 | 1.19 m | Day & Night | Like a typical Ash Satyr Reveler, but smaller and scrappier than usual, with bioluminescent spots along its body. |
| `pop_04096` | Iron Hold Ash Satyr Reveler Runt | [[Regions/Iron Hold\|Iron Hold]] | Runt | D- | 40 | 1.19 m | Day & Night | Like a typical Ash Satyr Reveler, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_04097` | Iron Hold Ash Satyr Reveler Albino | [[Regions/Iron Hold\|Iron Hold]] | Albino | C- | 65 | 1.7 m | Day & Night | Like a typical Ash Satyr Reveler, but a rare pale form with white skin or fur and red eyes. |
| `pop_04098` | Great Labyrinth (Floors 1-40) Ash Satyr Reveler Runt | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Runt | D- | 40 | 1.19 m | Day & Night | Like a typical Ash Satyr Reveler, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_04099` | Umbravel Ash Satyr Reveler Juvenile | [[Regions/Umbravel\|Umbravel]] | Juvenile | D | 48 | 1.44 m | Day & Night | Like a typical Ash Satyr Reveler, but young, with brighter colors and unworn features, with bioluminescent spots along its body. |
| `pop_04100` | Iron Hold Ash Satyr Reveler Elderborn | [[Regions/Iron Hold\|Iron Hold]] | Elderborn | C+ | 86 | 2.29 m | Day & Night | Like a typical Ash Satyr Reveler, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_04101` | Iron Hold Ash Satyr Reveler | [[Regions/Iron Hold\|Iron Hold]] | Adult | D+ | 56 | 1.7 m | Day & Night | A typical adult Ash Satyr Reveler of this region, with slate-grey coloring and hardened hide. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `short_hide` · VFX `embers_heat_haze` · palette `#e2502b` `#ffb347` `#3a1a12` · real-animal silhouette with one fantasy exaggeration
