---
type: monster
id: mon_crag_salamander_spirit
family: "Elementals & Spirits"
rank: "D+"
tier: variant
tags: [monster, elementals-spirits]
---
# Crag Salamander Spirit

![[mon_crag_salamander_spirit_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_crag_salamander_spirit_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (3,582 tris · 0.266 × 1 × 0.424 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Crag Salamander Spirit is a small creature with a coiling, legless body, about 1 m long. Its body is weathered and natural, colored in ochre, clay and mossy stone. Guild sketches always show a lizard of living flame. It has amber predator eyes. A distinctive marking runs along its back. It stalks low to the ground, surrounded by pebbles that tremble and float near it. Adapted to mountain lands, it has slate-grey coloring and hardened hide.

| Field | Value |
|---|---|
| Family · type | [[Families/Elementals & Spirits|Elementals & Spirits]] · Elemental |
| Variant of | [[Monsters/Elementals & Spirits/Salamander Spirit\|Salamander Spirit]] (regional) |
| Rank · level | D+ · 56 (48–65) |
| Menace | 2 · Wild |
| Element · weakness | Earth · Wind |
| Size | 1 m |
| Behaviour | Passive (passive_wander) |
| HP · ATK · DEF · MATK · MDEF · SPD | 3257 · 234 · 187 · 164 · 187 · 135 |
| XP · gold | 1888 · 423 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/serpent\|serpent]] · `anim_serpent` |
| Habitats | [[Regions/Hoshizora\|Hoshizora]], [[Regions/Iron Hold\|Iron Hold]] |
| Genre | Spirit Realm |
| Trope | Spirits you can contract with; elemental kings |

**Field note:** Weak to Wind. Leaves you alone unless attacked.

## Motion implementation

- **Rig:** [[Systems/Rigs/serpent|serpent]] (rigId); animation set `anim_serpent`.
- **Dimensions:** 0.04 m high × 1 m long × 0.1 m wide; prefab scale 0.25.
- **Physics:** 3 kg, gravity ×1.32, poise 8, knockback resistance 0.61, death style `limp_chain`.
- **Navigation:** speed 2.32 m/s, turn 300°/s, stopping distance 0.5 m.
- **Attack count:** 5; **signature:** a lizard of living flame.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Strike\|Strike]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Constrict\|Constrict]] | grab | 1.8 | 12 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Tail Sweep\|Tail Sweep]] | aoe | 1.2 | 7 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Elemental Burst\|Elemental Burst]] | magic | 1.4 | 9 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Crag Salamander Spirit is a **wild elemental** encountered at D+ rank, around level 56. Its documented behaviour is *Passive* and its AI pattern is *passive_wander*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a lizard of living flame. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Hoshizora|Hoshizora]], [[Regions/Iron Hold|Iron Hold]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_serpent`, animation set `anim_serpent`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Elementals & Spirits D|loot_elemental_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Elemental Essence\|Elemental Essence]] | 60% | 1–3 |
| [[Items/Spirit Mote\|Spirit Mote]] | 30% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Iron Hold\|Iron Hold]] | 5 | C, C-, D-, D, D+ | 40–76 | Day & Night |
| [[Regions/Hoshizora\|Hoshizora]] | 6 | D-, C, C-, D, C+ | 40–86 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04484` | Iron Hold Crag Salamander Spirit Alpha | [[Regions/Iron Hold\|Iron Hold]] | Alpha | C | 76 | 1.25 m | Day & Night | Like a typical Crag Salamander Spirit, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_04485` | Hoshizora Crag Salamander Spirit Runt | [[Regions/Hoshizora\|Hoshizora]] | Runt | D- | 40 | 0.7 m | Day & Night | Like a typical Crag Salamander Spirit, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_04486` | Iron Hold Crag Salamander Spirit Scarred | [[Regions/Iron Hold\|Iron Hold]] | Scarred | C- | 65 | 1.1 m | Day & Night | Like a typical Crag Salamander Spirit, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_04487` | Iron Hold Crag Salamander Spirit Runt | [[Regions/Iron Hold\|Iron Hold]] | Runt | D- | 40 | 0.7 m | Day & Night | Like a typical Crag Salamander Spirit, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_04488` | Hoshizora Crag Salamander Spirit Alpha | [[Regions/Hoshizora\|Hoshizora]] | Alpha | C | 76 | 1.25 m | Day & Night | Like a typical Crag Salamander Spirit, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_04489` | Iron Hold Crag Salamander Spirit Juvenile | [[Regions/Iron Hold\|Iron Hold]] | Juvenile | D | 48 | 0.85 m | Day & Night | Like a typical Crag Salamander Spirit, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_04490` | Hoshizora Crag Salamander Spirit Albino | [[Regions/Hoshizora\|Hoshizora]] | Albino | C- | 65 | 1 m | Day & Night | Like a typical Crag Salamander Spirit, but a rare pale form with white skin or fur and red eyes. |
| `pop_04491` | Iron Hold Crag Salamander Spirit | [[Regions/Iron Hold\|Iron Hold]] | Adult | D+ | 56 | 1 m | Day & Night | A typical adult Crag Salamander Spirit of this region, with slate-grey coloring and hardened hide. |
| `pop_04492` | Hoshizora Crag Salamander Spirit Scarred | [[Regions/Hoshizora\|Hoshizora]] | Scarred | C- | 65 | 1.1 m | Day & Night | Like a typical Crag Salamander Spirit, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_04493` | Hoshizora Crag Salamander Spirit Juvenile | [[Regions/Hoshizora\|Hoshizora]] | Juvenile | D | 48 | 0.85 m | Day & Night | Like a typical Crag Salamander Spirit, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_04494` | Hoshizora Crag Salamander Spirit Elderborn | [[Regions/Hoshizora\|Hoshizora]] | Elderborn | C+ | 86 | 1.35 m | Day & Night | Like a typical Crag Salamander Spirit, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_serpent` · mesh `serpent_base` · material `elemental_emissive` · VFX `rock_debris` · palette `#8b5a2b` `#c2a878` `#4a4a3a` · real-animal silhouette with one fantasy exaggeration
