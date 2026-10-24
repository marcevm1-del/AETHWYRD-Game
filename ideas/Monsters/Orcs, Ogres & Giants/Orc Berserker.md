---
type: monster
id: mon_orc_berserker
family: "Orcs, Ogres & Giants"
rank: "D+"
tier: core
tags: [monster, orcs-ogres-giants]
---
# Orc Berserker

![[mon_orc_berserker_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_orc_berserker_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,484 tris · 1.296 × 0.899 × 2.2 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Orc Berserker is a person-sized creature with a lean humanoid frame, about 2.2 m tall. Its hide is rough, scarred and spiked, colored in ember reds fading to soot black. Its most striking feature is blood-red war paint and broken chains on its wrists. It has eyes that catch torchlight like coins. A distinctive marking runs along its back. It charges without hesitation, surrounded by heat-shimmer and drifting sparks.

| Field | Value |
|---|---|
| Family · type | [[Families/Orcs, Ogres & Giants|Orcs, Ogres & Giants]] · Giant |
| Rank · level | D+ · 56 (48–65) |
| Menace | 3 · Menacing |
| Element · weakness | Fire · Water |
| Size | 2.2 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 5501 · 281 · 234 · 187 · 211 · 100 |
| XP · gold | 1888 · 423 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Iron Hold\|Iron Hold]], [[Regions/Fanghold\|Fanghold]], [[Regions/Aldmere\|Aldmere]] |
| Genre | Classic Fantasy |
| Trope | Orc warbands and the Orc Disaster that devours its way to power (Tensura) |

**Field note:** Weak to Water. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 2.2 m high × 0.66 m long × 0.7 m wide; prefab scale 1.222.
- **Physics:** 138.4 kg, gravity ×1.5, poise 72, knockback resistance 0.36, death style `ragdoll`.
- **Navigation:** speed 5.73 m/s, turn 270°/s, stopping distance 0.77 m.
- **Attack count:** 5; **signature:** blood-red war paint and broken chains on its wrists.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/War Cry\|War Cry]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Ember Burst\|Ember Burst]] | magic | 1.5 | 10 s | Fire | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Orc Berserker is a **menacing giant** encountered at D+ rank, around level 56. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Water**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** blood-red war paint and broken chains on its wrists. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Iron Hold|Iron Hold]], [[Regions/Fanghold|Fanghold]], [[Regions/Aldmere|Aldmere]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Orcs, Ogres & Giants D|loot_orc_giant_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Tusk\|Tusk]] | 60% | 1–3 |
| [[Items/Giant's Hide\|Giant's Hide]] | 30% | 1–1 |
| [[Items/Crude Iron\|Crude Iron]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Orcs, Ogres & Giants/Meadow Orc Berserker|Meadow Orc Berserker]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Iron Hold\|Iron Hold]] | 6 | D-, D, C-, D+, C+ | 40–86 | Day & Night |
| [[Regions/Aldmere\|Aldmere]] | 3 | C, C-, D | 48–76 | Day & Night |
| [[Regions/Fanghold\|Fanghold]] | 2 | D+, D | 48–56 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01083` | Iron Hold Orc Berserker Runt | [[Regions/Iron Hold\|Iron Hold]] | Runt | D- | 40 | 1.54 m | Day & Night | Like a typical Orc Berserker, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_01084` | Aldmere Orc Berserker Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | C | 76 | 2.75 m | Day & Night | Like a typical Orc Berserker, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_01085` | Iron Hold Orc Berserker Juvenile | [[Regions/Iron Hold\|Iron Hold]] | Juvenile | D | 48 | 1.87 m | Day & Night | Like a typical Orc Berserker, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_01086` | Iron Hold Orc Berserker Albino | [[Regions/Iron Hold\|Iron Hold]] | Albino | C- | 65 | 2.2 m | Day & Night | Like a typical Orc Berserker, but a rare pale form with white skin or fur and red eyes. |
| `pop_01087` | Fanghold Orc Berserker | [[Regions/Fanghold\|Fanghold]] | Adult | D+ | 56 | 2.2 m | Day & Night | A typical adult Orc Berserker of this region, with golden, grass-toned coloring. |
| `pop_01088` | Iron Hold Orc Berserker | [[Regions/Iron Hold\|Iron Hold]] | Adult | D+ | 56 | 2.2 m | Day & Night | A typical adult Orc Berserker of this region, with slate-grey coloring and hardened hide. |
| `pop_01089` | Aldmere Orc Berserker Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | C- | 65 | 2.42 m | Day & Night | Like a typical Orc Berserker, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_01090` | Fanghold Orc Berserker Juvenile | [[Regions/Fanghold\|Fanghold]] | Juvenile | D | 48 | 1.87 m | Day & Night | Like a typical Orc Berserker, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_01091` | Aldmere Orc Berserker Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | D | 48 | 1.87 m | Day & Night | Like a typical Orc Berserker, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_01092` | Iron Hold Orc Berserker Elderborn | [[Regions/Iron Hold\|Iron Hold]] | Elderborn | C+ | 86 | 2.97 m | Day & Night | Like a typical Orc Berserker, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_01093` | Iron Hold Orc Berserker Scarred | [[Regions/Iron Hold\|Iron Hold]] | Scarred | C- | 65 | 2.42 m | Day & Night | Like a typical Orc Berserker, but covered in old battle scars, with slate-grey coloring and hardened hide. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `thick_skin` · VFX `embers_heat_haze` · palette `#e2502b` `#ffb347` `#3a1a12` · triangle-based silhouette, sharp asymmetric spikes
