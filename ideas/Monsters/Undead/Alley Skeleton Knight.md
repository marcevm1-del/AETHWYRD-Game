---
type: monster
id: mon_alley_skeleton_knight
family: "Undead"
rank: "C-"
tier: variant
tags: [monster, undead]
---
# Alley Skeleton Knight

![[mon_alley_skeleton_knight_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_alley_skeleton_knight_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,250 tris · 1.084 × 1.784 × 2 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Alley Skeleton Knight is a person-sized creature with an upright humanoid build, about 2 m tall. Its flesh and bone are rough, scarred and spiked, colored in bleached bone and grave-cloth. Its most striking feature is rusted plate armor and a shield it still keeps polished. It has burning slit pupils. Battle-worn plates and trophies hang from its body. It charges without hesitation. It has no visible aura; you hear its breathing before you see it. Adapted to city lands, it has soot-stained hide and scavenged scraps.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Variant of | [[Monsters/Undead/Skeleton Knight\|Skeleton Knight]] (regional) |
| Rank · level | C- · 65 (56–76) |
| Menace | 3 · Menacing |
| Element · weakness | None · Fire |
| Size | 2 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 6637 · 324 · 270 · 151 · 243 · 100 |
| XP · gold | 2395 · 521 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Zarvan\|Zarvan]] |
| Genre | Gothic Horror |
| Trope | Graveyard night threats; the lich and its phylactery; the vampire noble |

**Field note:** Weak to Fire. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 2 m high × 0.6 m long × 0.64 m wide; prefab scale 1.111.
- **Physics:** 104 kg, gravity ×1.5, poise 76, knockback resistance 0.39, death style `ragdoll`.
- **Navigation:** speed 5.72 m/s, turn 283°/s, stopping distance 0.74 m.
- **Attack count:** 4; **signature:** rusted plate armor and a shield it still keeps polished.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Grave Grasp\|Grave Grasp]] | grab | 1.2 | 10 s | None | gold | Grab cue; create distance or dodge before contact. |

## Field guide

Alley Skeleton Knight is a **menacing undead** encountered at C- rank, around level 65. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** rusted plate armor and a shield it still keeps polished. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Zarvan|Zarvan]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

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
| [[Regions/Zarvan\|Zarvan]] | 5 | D, C-, C, B- | 48–96 | Night |
| [[Regions/Aldmere\|Aldmere]] | 6 | D+, C+, C-, B-, C, D | 48–96 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03793` | Zarvan Alley Skeleton Knight Runt | [[Regions/Zarvan\|Zarvan]] | Runt | D | 48 | 1.4 m | Night | Like a typical Alley Skeleton Knight, but smaller and scrappier than usual, with sun-bleached, sand-scoured coloring. |
| `pop_03794` | Zarvan Alley Skeleton Knight | [[Regions/Zarvan\|Zarvan]] | Adult | C- | 65 | 2 m | Night | A typical adult Alley Skeleton Knight of this region, with sun-bleached, sand-scoured coloring. |
| `pop_03795` | Aldmere Alley Skeleton Knight Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | D+ | 56 | 1.7 m | Night | Like a typical Alley Skeleton Knight, but young, with brighter colors and unworn features, with mud-slick, algae-streaked skin. |
| `pop_03796` | Zarvan Alley Skeleton Knight Scarred | [[Regions/Zarvan\|Zarvan]] | Scarred | C | 76 | 2.2 m | Night | Like a typical Alley Skeleton Knight, but covered in old battle scars, with sun-bleached, sand-scoured coloring. |
| `pop_03797` | Aldmere Alley Skeleton Knight Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | C+ | 86 | 2.5 m | Night | Like a typical Alley Skeleton Knight, but larger and scarred, and others of its kind follow it, with mud-slick, algae-streaked skin. |
| `pop_03798` | Aldmere Alley Skeleton Knight | [[Regions/Aldmere\|Aldmere]] | Adult | C- | 65 | 2 m | Night | A typical adult Alley Skeleton Knight of this region, with mud-slick, algae-streaked skin. |
| `pop_03799` | Zarvan Alley Skeleton Knight Elderborn | [[Regions/Zarvan\|Zarvan]] | Elderborn | B- | 96 | 2.7 m | Night | Like a typical Alley Skeleton Knight, but old and wise, with greying features and a cautious hunting style, with sun-bleached, sand-scoured coloring. |
| `pop_03800` | Zarvan Alley Skeleton Knight Albino | [[Regions/Zarvan\|Zarvan]] | Albino | C | 76 | 2 m | Night | Like a typical Alley Skeleton Knight, but a rare pale form with white skin or fur and red eyes. |
| `pop_03801` | Aldmere Alley Skeleton Knight Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | B- | 96 | 2.7 m | Night | Like a typical Alley Skeleton Knight, but old and wise, with greying features and a cautious hunting style, with mud-slick, algae-streaked skin. |
| `pop_03802` | Aldmere Alley Skeleton Knight Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | C | 76 | 2.2 m | Night | Like a typical Alley Skeleton Knight, but covered in old battle scars, with mud-slick, algae-streaked skin. |
| `pop_03803` | Aldmere Alley Skeleton Knight Runt | [[Regions/Aldmere\|Aldmere]] | Runt | D | 48 | 1.4 m | Night | Like a typical Alley Skeleton Knight, but smaller and scrappier than usual, with mud-slick, algae-streaked skin. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `rot_bone` · VFX `dust_puffs` · palette `#cac1a4` `#817961` `#fff1d0` · triangle-based silhouette, sharp asymmetric spikes
