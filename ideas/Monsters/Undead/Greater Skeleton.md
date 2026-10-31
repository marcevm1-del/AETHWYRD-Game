---
type: monster
id: mon_greater_skeleton
family: "Undead"
rank: "E+"
tier: variant
tags: [monster, undead]
---
# Greater Skeleton

![[mon_greater_skeleton_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_greater_skeleton_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,728 tris · 1.591 × 1.082 × 2.7 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Greater Skeleton is a large creature with an upright humanoid build, about 2.7 m tall. Its flesh and bone are rough, scarred and spiked, colored in bleached bone and grave-cloth, with violet markings. Survivors describe yellowed bones held together by blue grave-light. It has narrow glowing eyes. Small scars and rough edges mark it as a survivor. It charges without hesitation, surrounded by shadows that lean toward it. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Variant of | [[Monsters/Undead/Skeleton\|Skeleton]] (elder) |
| Rank · level | E+ · 32 (26–40) |
| Menace | 3 · Menacing |
| Element · weakness | Dark · Light |
| Size | 2.7 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 2600 · 166 · 138 · 110 · 124 · 100 |
| XP · gold | 776 · 195 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Gothic Horror |
| Trope | Graveyard night threats; the lich and its phylactery; the vampire noble |

**Field note:** Weak to Light. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (override (base species)); animation set `anim_medium_biped`.
- **Dimensions:** 2.7 m high × 0.81 m long × 0.86 m wide; prefab scale 1.5.
- **Physics:** 255.9 kg, gravity ×1.5, poise 70, knockback resistance 0.33, death style `ragdoll`.
- **Navigation:** speed 6.98 m/s, turn 243°/s, stopping distance 0.86 m.
- **Attack count:** 5; **signature:** yellowed bones held together by blue grave-light.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Grave Grasp\|Grave Grasp]] | grab | 1.2 | 10 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Greater Skeleton is a **menacing undead** encountered at E+ rank, around level 32. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** yellowed bones held together by blue grave-light. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Whisperwood|Whisperwood]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Undead E|loot_undead_e]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Bone Dust\|Bone Dust]] | 60% | 1–3 |
| [[Items/Grave Cloth\|Grave Cloth]] | 30% | 1–1 |
| [[Items/Soul Ember\|Soul Ember]] | 15% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Aldmere\|Aldmere]] | 3 | E-, D-, D+ | 19–56 | Night |
| [[Regions/Whisperwood\|Whisperwood]] | 5 | E, E+, D+, E-, D- | 19–56 | Night |
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 3 | D-, E-, D | 19–48 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03716` | Aldmere Greater Skeleton Runt | [[Regions/Aldmere\|Aldmere]] | Runt | E- | 19 | 1.89 m | Night | Like a typical Greater Skeleton, but smaller and scrappier than usual, with mud-slick, algae-streaked skin. |
| `pop_03717` | Whisperwood Greater Skeleton Juvenile | [[Regions/Whisperwood\|Whisperwood]] | Juvenile | E | 26 | 2.29 m | Night | Like a typical Greater Skeleton, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_03718` | Great Labyrinth (Floors 1-40) Greater Skeleton Albino | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Albino | D- | 40 | 2.7 m | Night | Like a typical Greater Skeleton, but a rare pale form with white skin or fur and red eyes. |
| `pop_03719` | Aldmere Greater Skeleton Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | D- | 40 | 2.97 m | Night | Like a typical Greater Skeleton, but covered in old battle scars, with mud-slick, algae-streaked skin. |
| `pop_03720` | Whisperwood Greater Skeleton | [[Regions/Whisperwood\|Whisperwood]] | Adult | E+ | 32 | 2.7 m | Night | A typical adult Greater Skeleton of this region, with dust-grey coloring and old rune scars. |
| `pop_03721` | Whisperwood Greater Skeleton Elderborn | [[Regions/Whisperwood\|Whisperwood]] | Elderborn | D+ | 56 | 3.65 m | Night | Like a typical Greater Skeleton, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_03722` | Aldmere Greater Skeleton Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | D+ | 56 | 3.65 m | Night | Like a typical Greater Skeleton, but old and wise, with greying features and a cautious hunting style, with mud-slick, algae-streaked skin. |
| `pop_03723` | Great Labyrinth (Floors 1-40) Greater Skeleton Runt | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Runt | E- | 19 | 1.89 m | Night | Like a typical Greater Skeleton, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_03724` | Whisperwood Greater Skeleton Runt | [[Regions/Whisperwood\|Whisperwood]] | Runt | E- | 19 | 1.89 m | Night | Like a typical Greater Skeleton, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_03725` | Great Labyrinth (Floors 1-40) Greater Skeleton Alpha | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Alpha | D | 48 | 3.38 m | Night | Like a typical Greater Skeleton, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_03726` | Whisperwood Greater Skeleton Albino | [[Regions/Whisperwood\|Whisperwood]] | Albino | D- | 40 | 2.7 m | Night | Like a typical Greater Skeleton, but a rare pale form with white skin or fur and red eyes. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `rot_bone` · VFX `shadow_wisps` · palette `#d5cdad` `#888166` `#9a86d8` · triangle-based silhouette, sharp asymmetric spikes
