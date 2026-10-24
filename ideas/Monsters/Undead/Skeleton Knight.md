---
type: monster
id: mon_skeleton_knight
family: "Undead"
rank: "D+"
tier: core
tags: [monster, undead]
---
# Skeleton Knight

![[mon_skeleton_knight_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_skeleton_knight_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,752 tris · 1.178 × 1.266 × 2 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Skeleton Knight is a person-sized creature with a lean humanoid frame, about 2 m tall. Its flesh and bone are rough, scarred and spiked, colored in ink black with bruised violet. Look for rusted plate armor and a shield it still keeps polished. It has eyes that catch torchlight like coins. A distinctive marking runs along its back. It strides with heavy steps, surrounded by shadows that lean toward it.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Rank · level | D+ · 56 (48–65) |
| Menace | 3 · Menacing |
| Element · weakness | Dark · Light |
| Size | 2 m |
| Behaviour | Guardian (guardian_hold) |
| HP · ATK · DEF · MATK · MDEF · SPD | 5324 · 281 · 234 · 187 · 211 · 100 |
| XP · gold | 1888 · 423 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Strife Marches\|Strife Marches]], [[Regions/Greymoor\|Greymoor]], [[Regions/Xochitl Mire\|Xochitl Mire]] |
| Genre | Gothic Horror |
| Trope | Graveyard night threats; the lich and its phylactery; the vampire noble |

**Field note:** Weak to Light. Protects something nearby: a nest, a treasure, or a place.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 2 m high × 0.6 m long × 0.64 m wide; prefab scale 1.111.
- **Physics:** 104 kg, gravity ×1.5, poise 69, knockback resistance 0.36, death style `ragdoll`.
- **Navigation:** speed 4.91 m/s, turn 283°/s, stopping distance 0.74 m.
- **Attack count:** 5; **signature:** rusted plate armor and a shield it still keeps polished.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Grave Grasp\|Grave Grasp]] | grab | 1.2 | 10 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Skeleton Knight is a **menacing undead** encountered at D+ rank, around level 56. Its documented behaviour is *Guardian* and its AI pattern is *guardian_hold*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** rusted plate armor and a shield it still keeps polished. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Strife Marches|Strife Marches]], [[Regions/Greymoor|Greymoor]], [[Regions/Xochitl Mire|Xochitl Mire]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Undead D|loot_undead_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Bone Dust\|Bone Dust]] | 60% | 1–3 |
| [[Items/Grave Cloth\|Grave Cloth]] | 30% | 1–1 |
| [[Items/Soul Ember\|Soul Ember]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Undead/Alley Skeleton Knight|Alley Skeleton Knight]]
- [[Monsters/Undead/Dune Skeleton Knight|Dune Skeleton Knight]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Xochitl Mire\|Xochitl Mire]] | 3 | D-, D, C- | 40–65 | Night |
| [[Regions/Aldmere\|Aldmere]] | 4 | C-, D+, C | 56–76 | Night |
| [[Regions/Greymoor\|Greymoor]] | 2 | C-, C | 65–76 | Night |
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 2 | C-, C+ | 65–86 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00895` | Xochitl Mire Skeleton Knight Runt | [[Regions/Xochitl Mire\|Xochitl Mire]] | Runt | D- | 40 | 1.4 m | Night | Like a typical Skeleton Knight, but smaller and scrappier than usual, with mud-slick, algae-streaked skin. |
| `pop_00896` | Aldmere Skeleton Knight Albino | [[Regions/Aldmere\|Aldmere]] | Albino | C- | 65 | 2 m | Night | Like a typical Skeleton Knight, but a rare pale form with white skin or fur and red eyes. |
| `pop_00897` | Xochitl Mire Skeleton Knight Juvenile | [[Regions/Xochitl Mire\|Xochitl Mire]] | Juvenile | D | 48 | 1.7 m | Night | Like a typical Skeleton Knight, but young, with brighter colors and unworn features, with mud-slick, algae-streaked skin. |
| `pop_00898` | Greymoor Skeleton Knight Scarred | [[Regions/Greymoor\|Greymoor]] | Scarred | C- | 65 | 2.2 m | Night | Like a typical Skeleton Knight, but covered in old battle scars, with mud-slick, algae-streaked skin. |
| `pop_00899` | Xochitl Mire Skeleton Knight Albino | [[Regions/Xochitl Mire\|Xochitl Mire]] | Albino | C- | 65 | 2 m | Night | Like a typical Skeleton Knight, but a rare pale form with white skin or fur and red eyes. |
| `pop_00900` | Aldmere Skeleton Knight Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | C- | 65 | 2.2 m | Night | Like a typical Skeleton Knight, but covered in old battle scars, with mud-slick, algae-streaked skin. |
| `pop_00901` | Greymoor Skeleton Knight Alpha | [[Regions/Greymoor\|Greymoor]] | Alpha | C | 76 | 2.5 m | Night | Like a typical Skeleton Knight, but larger and scarred, and others of its kind follow it, with mud-slick, algae-streaked skin. |
| `pop_00902` | Great Labyrinth (Floors 1-40) Skeleton Knight Scarred | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Scarred | C- | 65 | 2.2 m | Night | Like a typical Skeleton Knight, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_00903` | Aldmere Skeleton Knight | [[Regions/Aldmere\|Aldmere]] | Adult | D+ | 56 | 2 m | Night | A typical adult Skeleton Knight of this region, with mud-slick, algae-streaked skin. |
| `pop_00904` | Aldmere Skeleton Knight Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | C | 76 | 2.5 m | Night | Like a typical Skeleton Knight, but larger and scarred, and others of its kind follow it, with mud-slick, algae-streaked skin. |
| `pop_00905` | Great Labyrinth (Floors 1-40) Skeleton Knight Elderborn | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Elderborn | C+ | 86 | 2.7 m | Night | Like a typical Skeleton Knight, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `rot_bone` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · triangle-based silhouette, sharp asymmetric spikes
