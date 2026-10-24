---
type: monster
id: mon_living_armor
family: "Constructs & Mimics"
rank: "E+"
tier: core
tags: [monster, constructs-mimics]
---
# Living Armor

> The Living Armor is a person-sized creature with an upright humanoid build, about 1.9 m tall. Its surface is rough, scarred and spiked, colored in muted greys and dusty browns. Survivors describe an empty suit of plate that walks. It has narrow glowing eyes. Small scars and rough edges mark it as a survivor. It strides with heavy steps. It has no visible aura; you hear its breathing before you see it.

| Field | Value |
|---|---|
| Family · type | [[Families/Constructs & Mimics|Constructs & Mimics]] · Construct |
| Rank · level | E+ · 32 (26–40) |
| Menace | 3 · Menacing |
| Element · weakness | None · Fire |
| Size | 1.9 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 2306 · 166 · 138 · 77 · 124 · 100 |
| XP · gold | 776 · 195 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Lirian\|Lirian]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Ancient Ruins |
| Trope | Treasure-chest mimics and ancient guardian golems |

**Field note:** Weak to Fire. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 1.9 m high × 0.57 m long × 0.61 m wide; prefab scale 1.056.
- **Physics:** 89.2 kg, gravity ×1.5, poise 59, knockback resistance 0.33, death style `ragdoll`.
- **Navigation:** speed 5.07 m/s, turn 290°/s, stopping distance 0.72 m.
- **Attack count:** 4; **signature:** an empty suit of plate that walks.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Rune Pulse\|Rune Pulse]] | magic | 1.3 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Living Armor is a **menacing construct** encountered at E+ rank, around level 32. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** an empty suit of plate that walks. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Lirian|Lirian]], [[Regions/Whisperwood|Whisperwood]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Constructs & Mimics E|loot_construct_e]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Golem Core\|Golem Core]] | 60% | 1–3 |
| [[Items/Rune Plate\|Rune Plate]] | 30% | 1–1 |
| [[Items/Gear\|Gear]] | 15% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Constructs & Mimics/Greater Living Armor|Greater Living Armor]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Aldmere\|Aldmere]] | 5 | E+, E-, D+, D-, E | 19–56 | Day & Night |
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 2 | E, D | 26–48 | Day & Night |
| [[Regions/Lirian\|Lirian]] | 2 | D- | 40–40 | Day & Night |
| [[Regions/Whisperwood\|Whisperwood]] | 2 | E-, D | 19–48 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01473` | Aldmere Living Armor | [[Regions/Aldmere\|Aldmere]] | Adult | E+ | 32 | 1.9 m | Day & Night | A typical adult Living Armor of this region, with dust-grey coloring and old rune scars. |
| `pop_01474` | Great Labyrinth (Floors 1-40) Living Armor Juvenile | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Juvenile | E | 26 | 1.61 m | Day & Night | Like a typical Living Armor, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_01475` | Lirian Living Armor Albino | [[Regions/Lirian\|Lirian]] | Albino | D- | 40 | 1.9 m | Day & Night | Like a typical Living Armor, but a rare pale form with white skin or fur and red eyes. |
| `pop_01476` | Aldmere Living Armor Runt | [[Regions/Aldmere\|Aldmere]] | Runt | E- | 19 | 1.33 m | Day & Night | Like a typical Living Armor, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_01477` | Whisperwood Living Armor Runt | [[Regions/Whisperwood\|Whisperwood]] | Runt | E- | 19 | 1.33 m | Day & Night | Like a typical Living Armor, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_01478` | Aldmere Living Armor Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | D+ | 56 | 2.56 m | Day & Night | Like a typical Living Armor, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_01479` | Great Labyrinth (Floors 1-40) Living Armor Alpha | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Alpha | D | 48 | 2.38 m | Day & Night | Like a typical Living Armor, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_01480` | Aldmere Living Armor Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | D- | 40 | 2.09 m | Day & Night | Like a typical Living Armor, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_01481` | Whisperwood Living Armor Alpha | [[Regions/Whisperwood\|Whisperwood]] | Alpha | D | 48 | 2.38 m | Day & Night | Like a typical Living Armor, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_01482` | Lirian Living Armor Scarred | [[Regions/Lirian\|Lirian]] | Scarred | D- | 40 | 2.09 m | Day & Night | Like a typical Living Armor, but covered in old battle scars, with soot-stained hide and scavenged scraps. |
| `pop_01483` | Aldmere Living Armor Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | E | 26 | 1.61 m | Day & Night | Like a typical Living Armor, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `stone_metal_runes` · VFX `dust_puffs` · palette `#8a8f98` `#5b5f66` `#c9c2b5` · triangle-based silhouette, sharp asymmetric spikes
