---
type: monster
id: mon_salamander_spirit
family: "Elementals & Spirits"
rank: "D"
tier: core
tags: [monster, elementals-spirits]
---
# Salamander Spirit

![[mon_salamander_spirit_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_salamander_spirit_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 12,000 tris · 0.269 × 1 × 0.393 m · local file `Game/Assets/_Game/Art/Models/Monsters/Elementals & Spirits/mon_salamander_spirit.fbx`

> The Salamander Spirit is a small creature with a long, sinuous serpentine body, about 1 m long. Its body is weathered and natural, colored in ember reds fading to soot black. Its most striking feature is a lizard of living flame. It has alert animal eyes. A distinctive marking runs along its back. It lopes in long strides, surrounded by heat-shimmer and drifting sparks.

| Field | Value |
|---|---|
| Family · type | [[Families/Elementals & Spirits|Elementals & Spirits]] · Elemental |
| Rank · level | D · 48 (40–56) |
| Menace | 2 · Wild |
| Element · weakness | Fire · Water |
| Size | 1 m |
| Behaviour | Passive (passive_wander) |
| HP · ATK · DEF · MATK · MDEF · SPD | 2595 · 202 · 162 · 141 · 162 · 135 |
| XP · gold | 1477 · 342 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/serpent\|serpent]] · `anim_serpent` |
| Habitats | [[Regions/Iron Hold\|Iron Hold]], [[Regions/Hoshizora\|Hoshizora]], [[Regions/Kitsune Isles\|Kitsune Isles]] |
| Genre | Spirit Realm |
| Trope | Spirits you can contract with; elemental kings |

**Field note:** Weak to Water. Leaves you alone unless attacked.

## Motion implementation

- **Rig:** [[Systems/Rigs/serpent|serpent]] (rigId); animation set `anim_serpent`.
- **Dimensions:** 0.04 m high × 1 m long × 0.1 m wide; prefab scale 0.25.
- **Physics:** 2.3 kg, gravity ×1.2, poise 8, knockback resistance 0.46, death style `limp_chain`.
- **Navigation:** speed 2.65 m/s, turn 300°/s, stopping distance 0.5 m.
- **Attack count:** 5; **signature:** a lizard of living flame.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Strike\|Strike]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Constrict\|Constrict]] | grab | 1.8 | 12 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Tail Sweep\|Tail Sweep]] | aoe | 1.2 | 7 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Elemental Burst\|Elemental Burst]] | magic | 1.4 | 9 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Ember Burst\|Ember Burst]] | magic | 1.5 | 10 s | Fire | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Salamander Spirit is a **wild elemental** encountered at D rank, around level 48. Its documented behaviour is *Passive* and its AI pattern is *passive_wander*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Water**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a lizard of living flame. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Iron Hold|Iron Hold]], [[Regions/Hoshizora|Hoshizora]], [[Regions/Kitsune Isles|Kitsune Isles]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_serpent`, animation set `anim_serpent`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Elementals & Spirits D|loot_elemental_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Elemental Essence\|Elemental Essence]] | 60% | 1–3 |
| [[Items/Spirit Mote\|Spirit Mote]] | 30% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Elementals & Spirits/Crag Salamander Spirit|Crag Salamander Spirit]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Iron Hold\|Iron Hold]] | 3 | D, D+, E+ | 32–56 | Day & Night |
| [[Regions/Kitsune Isles\|Kitsune Isles]] | 4 | D-, E+, C-, D | 32–65 | Day & Night |
| [[Regions/Hoshizora\|Hoshizora]] | 4 | D+, D-, D | 40–56 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01606` | Iron Hold Salamander Spirit | [[Regions/Iron Hold\|Iron Hold]] | Adult | D | 48 | 1 m | Day & Night | A typical adult Salamander Spirit of this region, with slate-grey coloring and hardened hide. |
| `pop_01607` | Kitsune Isles Salamander Spirit Juvenile | [[Regions/Kitsune Isles\|Kitsune Isles]] | Juvenile | D- | 40 | 0.85 m | Day & Night | Like a typical Salamander Spirit, but young, with brighter colors and unworn features, with a faint translucent shimmer. |
| `pop_01608` | Hoshizora Salamander Spirit Scarred | [[Regions/Hoshizora\|Hoshizora]] | Scarred | D+ | 56 | 1.1 m | Day & Night | Like a typical Salamander Spirit, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_01609` | Hoshizora Salamander Spirit Juvenile | [[Regions/Hoshizora\|Hoshizora]] | Juvenile | D- | 40 | 0.85 m | Day & Night | Like a typical Salamander Spirit, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_01610` | Iron Hold Salamander Spirit Scarred | [[Regions/Iron Hold\|Iron Hold]] | Scarred | D+ | 56 | 1.1 m | Day & Night | Like a typical Salamander Spirit, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_01611` | Kitsune Isles Salamander Spirit Runt | [[Regions/Kitsune Isles\|Kitsune Isles]] | Runt | E+ | 32 | 0.7 m | Day & Night | Like a typical Salamander Spirit, but smaller and scrappier than usual, with a faint translucent shimmer. |
| `pop_01612` | Iron Hold Salamander Spirit Runt | [[Regions/Iron Hold\|Iron Hold]] | Runt | E+ | 32 | 0.7 m | Day & Night | Like a typical Salamander Spirit, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_01613` | Hoshizora Salamander Spirit Albino | [[Regions/Hoshizora\|Hoshizora]] | Albino | D+ | 56 | 1 m | Day & Night | Like a typical Salamander Spirit, but a rare pale form with white skin or fur and red eyes. |
| `pop_01614` | Kitsune Isles Salamander Spirit Alpha | [[Regions/Kitsune Isles\|Kitsune Isles]] | Alpha | C- | 65 | 1.25 m | Day & Night | Like a typical Salamander Spirit, but larger and scarred, and others of its kind follow it, with a faint translucent shimmer. |
| `pop_01615` | Hoshizora Salamander Spirit | [[Regions/Hoshizora\|Hoshizora]] | Adult | D | 48 | 1 m | Day & Night | A typical adult Salamander Spirit of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_01616` | Kitsune Isles Salamander Spirit | [[Regions/Kitsune Isles\|Kitsune Isles]] | Adult | D | 48 | 1 m | Day & Night | A typical adult Salamander Spirit of this region, with a faint translucent shimmer. |

## Design recipe

Rig `rig_serpent` · mesh `serpent_base` · material `elemental_emissive` · VFX `embers_heat_haze` · palette `#e2502b` `#ffb347` `#401d14` · real-animal silhouette with one fantasy exaggeration
