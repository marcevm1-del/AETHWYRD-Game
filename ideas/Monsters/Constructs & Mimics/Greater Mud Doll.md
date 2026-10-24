---
type: monster
id: mon_greater_mud_doll
family: "Constructs & Mimics"
rank: "E"
tier: variant
tags: [monster, constructs-mimics]
---
# Greater Mud Doll

> The Greater Mud Doll is a person-sized creature with a small, compact humanoid body, about 1.3 m tall. Its surface is smooth and clean, colored in ochre, clay and mossy stone. Survivors describe a child's clay figure with thumbprint eyes. It has wide curious eyes with star-shaped highlights. Small scars and rough edges mark it as a survivor. It bounces happily, surrounded by pebbles that tremble and float near it. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Constructs & Mimics|Constructs & Mimics]] · Construct |
| Variant of | [[Monsters/Constructs & Mimics/Mud Doll\|Mud Doll]] (elder) |
| Rank · level | E · 26 (19–32) |
| Menace | 1 · Charming |
| Element · weakness | Earth · Wind |
| Size | 1.3 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1162 · 114 · 91 · 80 · 91 · 135 |
| XP · gold | 559 · 147 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/small_biped\|small_biped]] · `anim_small_biped` |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Ancient Ruins |
| Trope | Treasure-chest mimics and ancient guardian golems |

**Field note:** Weak to Wind. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/small_biped|small_biped]] (rigId); animation set `anim_small_biped`.
- **Dimensions:** 1.3 m high × 0.39 m long × 0.52 m wide; prefab scale 1.182.
- **Physics:** 45.7 kg, gravity ×1.65, poise 38, knockback resistance 0.33, death style `ragdoll_crumple`.
- **Navigation:** speed 4.35 m/s, turn 368°/s, stopping distance 0.66 m.
- **Attack count:** 5; **signature:** a child's clay figure with thumbprint eyes.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stab\|Stab]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Thrown Junk\|Thrown Junk]] | ranged | 0.8 | 4 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Frenzied Lunge\|Frenzied Lunge]] | melee | 1.5 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Rune Pulse\|Rune Pulse]] | magic | 1.3 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Greater Mud Doll is a **charming construct** encountered at E rank, around level 26. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a child's clay figure with thumbprint eyes. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Aldmere|Aldmere]], [[Regions/Whisperwood|Whisperwood]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_small_biped`, animation set `anim_small_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Constructs & Mimics E|loot_construct_e]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Golem Core\|Golem Core]] | 60% | 1–3 |
| [[Items/Rune Plate\|Rune Plate]] | 30% | 1–1 |
| [[Items/Gear\|Gear]] | 15% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Whisperwood\|Whisperwood]] | 2 | D, E+ | 32–48 | Day |
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 3 | D-, E+, D | 32–48 | Day |
| [[Regions/Aldmere\|Aldmere]] | 6 | E+, E, D, E-, D- | 19–48 | Day |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04319` | Whisperwood Greater Mud Doll Elderborn | [[Regions/Whisperwood\|Whisperwood]] | Elderborn | D | 48 | 1.76 m | Day | Like a typical Greater Mud Doll, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_04320` | Great Labyrinth (Floors 1-40) Greater Mud Doll Alpha | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Alpha | D- | 40 | 1.63 m | Day | Like a typical Greater Mud Doll, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_04321` | Aldmere Greater Mud Doll Albino | [[Regions/Aldmere\|Aldmere]] | Albino | E+ | 32 | 1.3 m | Day | Like a typical Greater Mud Doll, but a rare pale form with white skin or fur and red eyes. |
| `pop_04322` | Aldmere Greater Mud Doll | [[Regions/Aldmere\|Aldmere]] | Adult | E | 26 | 1.3 m | Day | A typical adult Greater Mud Doll of this region, with dust-grey coloring and old rune scars. |
| `pop_04323` | Whisperwood Greater Mud Doll Albino | [[Regions/Whisperwood\|Whisperwood]] | Albino | E+ | 32 | 1.3 m | Day | Like a typical Greater Mud Doll, but a rare pale form with white skin or fur and red eyes. |
| `pop_04324` | Aldmere Greater Mud Doll Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | D | 48 | 1.76 m | Day | Like a typical Greater Mud Doll, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_04325` | Aldmere Greater Mud Doll Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | E- | 19 | 1.1 m | Day | Like a typical Greater Mud Doll, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_04326` | Great Labyrinth (Floors 1-40) Greater Mud Doll Scarred | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Scarred | E+ | 32 | 1.43 m | Day | Like a typical Greater Mud Doll, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_04327` | Aldmere Greater Mud Doll Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | E+ | 32 | 1.43 m | Day | Like a typical Greater Mud Doll, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_04328` | Aldmere Greater Mud Doll Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | D- | 40 | 1.63 m | Day | Like a typical Greater Mud Doll, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_04329` | Great Labyrinth (Floors 1-40) Greater Mud Doll Elderborn | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Elderborn | D | 48 | 1.76 m | Day | Like a typical Greater Mud Doll, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `stone_metal_runes` · VFX `rock_debris` · palette `#8b5a2b` `#c2a878` `#4a4a3a` · circle-based, soft silhouette
