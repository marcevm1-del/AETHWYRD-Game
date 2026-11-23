---
type: monster
id: mon_lesser_demon
family: "Demons"
rank: "C"
tier: core
tags: [monster, demons]
---
# Lesser Demon

![[mon_lesser_demon_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_lesser_demon_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 12,000 tris · 1.148 × 1.042 × 2.2 m · local file `Game/Assets/_Game/Art/Models/Monsters/Demons/mon_lesser_demon.fbx`

> The Lesser Demon is a person-sized creature with an upright humanoid build, about 2.2 m tall. Its hide is rough, scarred and spiked, colored in brimstone red, with violet markings. Survivors describe curled horns and a leathery hide. It has narrow glowing eyes. Battle-worn plates and trophies hang from its body. It circles its prey, surrounded by shadows that lean toward it.

| Field | Value |
|---|---|
| Family · type | [[Families/Demons|Demons]] · Demon |
| Rank · level | C · 76 (65–86) |
| Menace | 3 · Menacing |
| Element · weakness | Dark · Light |
| Size | 2.2 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 8647 · 377 · 314 · 251 · 283 · 100 |
| XP · gold | 3073 · 648 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Strife Marches\|Strife Marches]] |
| Genre | Abyssal |
| Trope | Demons as a people of the Abyss, not just evil (Frieren, Maoyuu) |

**Field note:** Weak to Light. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 2.2 m high × 0.66 m long × 0.7 m wide; prefab scale 1.222.
- **Physics:** 138.4 kg, gravity ×1.5, poise 80, knockback resistance 0.39, death style `ragdoll`.
- **Navigation:** speed 6.3 m/s, turn 270°/s, stopping distance 0.77 m.
- **Attack count:** 5; **signature:** curled horns and a leathery hide.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Hellfire Brand\|Hellfire Brand]] | magic | 1.4 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Lesser Demon is a **menacing demon** encountered at C rank, around level 76. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** curled horns and a leathery hide. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Strife Marches|Strife Marches]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Demons C|loot_demon_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Demon Core\|Demon Core]] | 60% | 1–3 |
| [[Items/Horn Shard\|Horn Shard]] | 30% | 1–1 |
| [[Items/Brimstone\|Brimstone]] | 15% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Demons/Elder Lesser Demon|Elder Lesser Demon]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Strife Marches\|Strife Marches]] | 5 | C, C+, D+, C-, B- | 56–96 | Day & Night |
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 4 | B, C-, C+, B- | 65–108 | Day & Night |
| [[Regions/Aldmere\|Aldmere]] | 2 | C-, C | 65–76 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01835` | Strife Marches Lesser Demon | [[Regions/Strife Marches\|Strife Marches]] | Adult | C | 76 | 2.2 m | Day & Night | A typical adult Lesser Demon of this region, with dust-grey coloring and old rune scars. |
| `pop_01836` | Great Labyrinth (Floors 1-40) Lesser Demon Elderborn | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Elderborn | B | 108 | 2.97 m | Day & Night | Like a typical Lesser Demon, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_01837` | Great Labyrinth (Floors 1-40) Lesser Demon Juvenile | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Juvenile | C- | 65 | 1.87 m | Day & Night | Like a typical Lesser Demon, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_01838` | Aldmere Lesser Demon Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | C- | 65 | 1.87 m | Day & Night | Like a typical Lesser Demon, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_01839` | Great Labyrinth (Floors 1-40) Lesser Demon Albino | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Albino | C+ | 86 | 2.2 m | Day & Night | Like a typical Lesser Demon, but a rare pale form with white skin or fur and red eyes. |
| `pop_01840` | Strife Marches Lesser Demon Albino | [[Regions/Strife Marches\|Strife Marches]] | Albino | C+ | 86 | 2.2 m | Day & Night | Like a typical Lesser Demon, but a rare pale form with white skin or fur and red eyes. |
| `pop_01841` | Strife Marches Lesser Demon Runt | [[Regions/Strife Marches\|Strife Marches]] | Runt | D+ | 56 | 1.54 m | Day & Night | Like a typical Lesser Demon, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_01842` | Strife Marches Lesser Demon Juvenile | [[Regions/Strife Marches\|Strife Marches]] | Juvenile | C- | 65 | 1.87 m | Day & Night | Like a typical Lesser Demon, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_01843` | Great Labyrinth (Floors 1-40) Lesser Demon Alpha | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Alpha | B- | 96 | 2.75 m | Day & Night | Like a typical Lesser Demon, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_01844` | Strife Marches Lesser Demon Alpha | [[Regions/Strife Marches\|Strife Marches]] | Alpha | B- | 96 | 2.75 m | Day & Night | Like a typical Lesser Demon, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_01845` | Aldmere Lesser Demon | [[Regions/Aldmere\|Aldmere]] | Adult | C | 76 | 2.2 m | Day & Night | A typical adult Lesser Demon of this region, with dust-grey coloring and old rune scars. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `demon_hide_emissive` · VFX `shadow_wisps` · palette `#a23529` `#5a2a27` `#9a86d8` · triangle-based silhouette, sharp asymmetric spikes
