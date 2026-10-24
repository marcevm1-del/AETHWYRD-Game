---
type: monster
id: mon_dune_skeleton_knight
family: "Undead"
rank: "C-"
tier: variant
tags: [monster, undead]
---
# Dune Skeleton Knight

![[mon_dune_skeleton_knight_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_dune_skeleton_knight_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Dune Skeleton Knight is a person-sized creature with a lean humanoid frame, about 2 m tall. Its flesh and bone are rough, scarred and spiked, colored in ochre, clay and mossy stone. Survivors describe rusted plate armor and a shield it still keeps polished. It has narrow glowing eyes. Battle-worn plates and trophies hang from its body. It strides with heavy steps, surrounded by pebbles that tremble and float near it. Adapted to desert lands, it has sun-bleached, sand-scoured coloring.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Variant of | [[Monsters/Undead/Skeleton Knight\|Skeleton Knight]] (regional) |
| Rank · level | C- · 65 (56–76) |
| Menace | 3 · Menacing |
| Element · weakness | Earth · Wind |
| Size | 2 m |
| Behaviour | Guardian (guardian_hold) |
| HP · ATK · DEF · MATK · MDEF · SPD | 6637 · 324 · 270 · 216 · 243 · 100 |
| XP · gold | 2395 · 521 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Zarvan\|Zarvan]], [[Regions/Sunscar\|Sunscar]] |
| Genre | Gothic Horror |
| Trope | Graveyard night threats; the lich and its phylactery; the vampire noble |

**Field note:** Weak to Wind. Protects something nearby: a nest, a treasure, or a place.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 2 m high × 0.6 m long × 0.64 m wide; prefab scale 1.111.
- **Physics:** 135.2 kg, gravity ×1.65, poise 76, knockback resistance 0.54, death style `ragdoll`.
- **Navigation:** speed 4.31 m/s, turn 283°/s, stopping distance 0.74 m.
- **Attack count:** 5; **signature:** rusted plate armor and a shield it still keeps polished.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Grave Grasp\|Grave Grasp]] | grab | 1.2 | 10 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Dune Skeleton Knight is a **menacing undead** encountered at C- rank, around level 65. Its documented behaviour is *Guardian* and its AI pattern is *guardian_hold*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** rusted plate armor and a shield it still keeps polished. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Zarvan|Zarvan]], [[Regions/Sunscar|Sunscar]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Undead C|loot_undead_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Bone Dust\|Bone Dust]] | 60% | 1–3 |
| [[Items/Grave Cloth\|Grave Cloth]] | 30% | 1–1 |
| [[Items/Soul Ember\|Soul Ember]] | 15% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Sunscar\|Sunscar]] | 4 | C-, C, C+ | 65–86 | Night |
| [[Regions/Zarvan\|Zarvan]] | 7 | C, B-, D, D+, C+, C- | 48–96 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06638` | Sunscar Dune Skeleton Knight | [[Regions/Sunscar\|Sunscar]] | Adult | C- | 65 | 2 m | Night | A typical adult Dune Skeleton Knight of this region, with sun-bleached, sand-scoured coloring. |
| `pop_06639` | Sunscar Dune Skeleton Knight Scarred | [[Regions/Sunscar\|Sunscar]] | Scarred | C | 76 | 2.2 m | Night | Like a typical Dune Skeleton Knight, but covered in old battle scars, with sun-bleached, sand-scoured coloring. |
| `pop_06640` | Zarvan Dune Skeleton Knight Albino | [[Regions/Zarvan\|Zarvan]] | Albino | C | 76 | 2 m | Night | Like a typical Dune Skeleton Knight, but a rare pale form with white skin or fur and red eyes. |
| `pop_06641` | Sunscar Dune Skeleton Knight Alpha | [[Regions/Sunscar\|Sunscar]] | Alpha | C+ | 86 | 2.5 m | Night | Like a typical Dune Skeleton Knight, but larger and scarred, and others of its kind follow it, with sun-bleached, sand-scoured coloring. |
| `pop_06642` | Sunscar Dune Skeleton Knight Albino | [[Regions/Sunscar\|Sunscar]] | Albino | C | 76 | 2 m | Night | Like a typical Dune Skeleton Knight, but a rare pale form with white skin or fur and red eyes. |
| `pop_06643` | Zarvan Dune Skeleton Knight Elderborn | [[Regions/Zarvan\|Zarvan]] | Elderborn | B- | 96 | 2.7 m | Night | Like a typical Dune Skeleton Knight, but old and wise, with greying features and a cautious hunting style, with sun-bleached, sand-scoured coloring. |
| `pop_06644` | Zarvan Dune Skeleton Knight Scarred | [[Regions/Zarvan\|Zarvan]] | Scarred | C | 76 | 2.2 m | Night | Like a typical Dune Skeleton Knight, but covered in old battle scars, with sun-bleached, sand-scoured coloring. |
| `pop_06645` | Zarvan Dune Skeleton Knight Runt | [[Regions/Zarvan\|Zarvan]] | Runt | D | 48 | 1.4 m | Night | Like a typical Dune Skeleton Knight, but smaller and scrappier than usual, with sun-bleached, sand-scoured coloring. |
| `pop_06646` | Zarvan Dune Skeleton Knight Juvenile | [[Regions/Zarvan\|Zarvan]] | Juvenile | D+ | 56 | 1.7 m | Night | Like a typical Dune Skeleton Knight, but young, with brighter colors and unworn features, with sun-bleached, sand-scoured coloring. |
| `pop_06647` | Zarvan Dune Skeleton Knight Alpha | [[Regions/Zarvan\|Zarvan]] | Alpha | C+ | 86 | 2.5 m | Night | Like a typical Dune Skeleton Knight, but larger and scarred, and others of its kind follow it, with sun-bleached, sand-scoured coloring. |
| `pop_06648` | Zarvan Dune Skeleton Knight | [[Regions/Zarvan\|Zarvan]] | Adult | C- | 65 | 2 m | Night | A typical adult Dune Skeleton Knight of this region, with sun-bleached, sand-scoured coloring. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `rot_bone` · VFX `rock_debris` · palette `#8b5a2b` `#c2a878` `#4a4a3a` · triangle-based silhouette, sharp asymmetric spikes
