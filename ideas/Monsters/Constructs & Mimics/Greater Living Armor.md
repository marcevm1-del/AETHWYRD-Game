---
type: monster
id: mon_greater_living_armor
family: "Constructs & Mimics"
rank: "D+"
tier: variant
tags: [monster, constructs-mimics]
---
# Greater Living Armor

![[mon_greater_living_armor_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_greater_living_armor_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,852 tris · 1.626 × 2.035 × 3 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Greater Living Armor is a large creature with an upright humanoid build, about 3 m tall. Its surface is rough, scarred and spiked, colored in muted greys and dusty browns. Survivors describe an empty suit of plate that walks. It has narrow glowing eyes. A distinctive marking runs along its back. It strides with heavy steps. It has no visible aura; you hear its breathing before you see it. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Constructs & Mimics|Constructs & Mimics]] · Construct |
| Variant of | [[Monsters/Constructs & Mimics/Living Armor\|Living Armor]] (elder) |
| Rank · level | D+ · 56 (48–65) |
| Menace | 3 · Menacing |
| Element · weakness | None · Fire |
| Size | 3 m |
| Behaviour | Guardian (guardian_hold) |
| HP · ATK · DEF · MATK · MDEF · SPD | 6111 · 281 · 234 · 131 · 211 · 100 |
| XP · gold | 1888 · 423 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Aldmere\|Aldmere]] |
| Genre | Ancient Ruins |
| Trope | Treasure-chest mimics and ancient guardian golems |

**Field note:** Weak to Fire. Protects something nearby: a nest, a treasure, or a place.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 3 m high × 0.9 m long × 0.96 m wide; prefab scale 1.667.
- **Physics:** 351 kg, gravity ×1.5, poise 84, knockback resistance 0.36, death style `ragdoll`.
- **Navigation:** speed 5.73 m/s, turn 231°/s, stopping distance 0.91 m.
- **Attack count:** 4; **signature:** an empty suit of plate that walks.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Rune Pulse\|Rune Pulse]] | magic | 1.3 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Greater Living Armor is a **menacing construct** encountered at D+ rank, around level 56. Its documented behaviour is *Guardian* and its AI pattern is *guardian_hold*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** an empty suit of plate that walks. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Aldmere|Aldmere]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Constructs & Mimics D|loot_construct_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Golem Core\|Golem Core]] | 60% | 1–3 |
| [[Items/Rune Plate\|Rune Plate]] | 30% | 1–1 |
| [[Items/Gear\|Gear]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Aldmere\|Aldmere]] | 6 | D-, C-, D+, C+, C, D | 40–86 | Day & Night |
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 5 | C-, D, C, D-, C+ | 40–86 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04352` | Aldmere Greater Living Armor Runt | [[Regions/Aldmere\|Aldmere]] | Runt | D- | 40 | 2.1 m | Day & Night | Like a typical Greater Living Armor, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_04353` | Great Labyrinth (Floors 1-40) Greater Living Armor Scarred | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Scarred | C- | 65 | 3.3 m | Day & Night | Like a typical Greater Living Armor, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_04354` | Great Labyrinth (Floors 1-40) Greater Living Armor Juvenile | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Juvenile | D | 48 | 2.55 m | Day & Night | Like a typical Greater Living Armor, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_04355` | Aldmere Greater Living Armor Albino | [[Regions/Aldmere\|Aldmere]] | Albino | C- | 65 | 3 m | Day & Night | Like a typical Greater Living Armor, but a rare pale form with white skin or fur and red eyes. |
| `pop_04356` | Aldmere Greater Living Armor | [[Regions/Aldmere\|Aldmere]] | Adult | D+ | 56 | 3 m | Day & Night | A typical adult Greater Living Armor of this region, with dust-grey coloring and old rune scars. |
| `pop_04357` | Great Labyrinth (Floors 1-40) Greater Living Armor Alpha | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Alpha | C | 76 | 3.75 m | Day & Night | Like a typical Greater Living Armor, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_04358` | Great Labyrinth (Floors 1-40) Greater Living Armor Runt | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Runt | D- | 40 | 2.1 m | Day & Night | Like a typical Greater Living Armor, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_04359` | Great Labyrinth (Floors 1-40) Greater Living Armor Elderborn | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Elderborn | C+ | 86 | 4.05 m | Day & Night | Like a typical Greater Living Armor, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_04360` | Aldmere Greater Living Armor Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | C+ | 86 | 4.05 m | Day & Night | Like a typical Greater Living Armor, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_04361` | Aldmere Greater Living Armor Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | C | 76 | 3.75 m | Day & Night | Like a typical Greater Living Armor, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_04362` | Aldmere Greater Living Armor Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | D | 48 | 2.55 m | Day & Night | Like a typical Greater Living Armor, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `stone_metal_runes` · VFX `dust_puffs` · palette `#8a8f98` `#5b5f66` `#c9c2b5` · triangle-based silhouette, sharp asymmetric spikes
