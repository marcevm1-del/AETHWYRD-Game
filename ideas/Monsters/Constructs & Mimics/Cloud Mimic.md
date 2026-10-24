---
type: monster
id: mon_cloud_mimic
family: "Constructs & Mimics"
rank: "D+"
tier: variant
tags: [monster, constructs-mimics]
---
# Cloud Mimic

> The Cloud Mimic is a small creature with a hollow shell posing as an everyday object, about 1 m tall. Its surface is stretched, stitched and constantly shifting, colored in pale jade and cloud white. Survivors describe a treasure chest with a tongue and a ring of teeth. It has no eyes at all, only a wide and patient mouth. A distinctive marking runs along its back. It unfolds into something larger, surrounded by swirling leaves and a constant breeze. Adapted to sky lands, it has cloud-pale coloring and lighter bones.

| Field | Value |
|---|---|
| Family · type | [[Families/Constructs & Mimics|Constructs & Mimics]] · Construct |
| Variant of | [[Monsters/Constructs & Mimics/Mimic\|Mimic]] (regional) |
| Rank · level | D+ · 56 (48–65) |
| Menace | 5 · Horror |
| Element · weakness | Wind · Fire |
| Size | 1 m |
| Behaviour | Guardian (guardian_hold+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 3832 · 293 · 211 · 211 · 211 · 100 |
| XP · gold | 1888 · 423 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/amorphous\|amorphous]] · `anim_mimic` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Strife Marches\|Strife Marches]], [[Regions/Velmark\|Velmark]] |
| Genre | Ancient Ruins |
| Trope | Treasure-chest mimics and ancient guardian golems |

**Field note:** Weak to Fire. Protects something nearby: a nest, a treasure, or a place.

## Motion implementation

- **Rig:** [[Systems/Rigs/amorphous|amorphous]] (rigId); animation set `anim_mimic`.
- **Dimensions:** 1 m high × 1.07 m long × 1.05 m wide; prefab scale 0.5.
- **Physics:** 27 kg, gravity ×0.96, poise 27, knockback resistance 0.66, death style `collapse_and_melt`.
- **Navigation:** speed 4.52 m/s, turn 500°/s, stopping distance 0.7 m.
- **Attack count:** 5; **signature:** a treasure chest with a tongue and a ring of teeth.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Chomp\|Chomp]] | melee | 1.6 | 0 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Tongue Lash\|Tongue Lash]] | grab | 1.4 | 6 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Disguise\|Disguise]] | stealth | 0 | 20 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Rune Pulse\|Rune Pulse]] | magic | 1.3 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Gale Cutter\|Gale Cutter]] | magic | 1.5 | 10 s | Wind | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Cloud Mimic is a **horror construct** encountered at D+ rank, around level 56. Its documented behaviour is *Guardian* and its AI pattern is *guardian_hold+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a treasure chest with a tongue and a ring of teeth. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Strife Marches|Strife Marches]], [[Regions/Velmark|Velmark]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_mimic`, animation set `anim_mimic`; keep silhouette, movement and signature attack legible at gameplay camera distance.

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
| [[Regions/Velmark\|Velmark]] | 3 | C+, D+, C- | 56–86 | Night |
| [[Regions/Aldmere\|Aldmere]] | 5 | D-, C-, D+, C, C+ | 40–86 | Night |
| [[Regions/Strife Marches\|Strife Marches]] | 3 | D, C-, D- | 40–65 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04374` | Velmark Cloud Mimic Elderborn | [[Regions/Velmark\|Velmark]] | Elderborn | C+ | 86 | 1.35 m | Night | Like a typical Cloud Mimic, but old and wise, with greying features and a cautious hunting style, with soot-stained hide and scavenged scraps. |
| `pop_04375` | Aldmere Cloud Mimic Runt | [[Regions/Aldmere\|Aldmere]] | Runt | D- | 40 | 0.7 m | Night | Like a typical Cloud Mimic, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_04376` | Aldmere Cloud Mimic Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | C- | 65 | 1.1 m | Night | Like a typical Cloud Mimic, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_04377` | Strife Marches Cloud Mimic Juvenile | [[Regions/Strife Marches\|Strife Marches]] | Juvenile | D | 48 | 0.85 m | Night | Like a typical Cloud Mimic, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_04378` | Strife Marches Cloud Mimic Albino | [[Regions/Strife Marches\|Strife Marches]] | Albino | C- | 65 | 1 m | Night | Like a typical Cloud Mimic, but a rare pale form with white skin or fur and red eyes. |
| `pop_04379` | Aldmere Cloud Mimic | [[Regions/Aldmere\|Aldmere]] | Adult | D+ | 56 | 1 m | Night | A typical adult Cloud Mimic of this region, with dust-grey coloring and old rune scars. |
| `pop_04380` | Velmark Cloud Mimic | [[Regions/Velmark\|Velmark]] | Adult | D+ | 56 | 1 m | Night | A typical adult Cloud Mimic of this region, with soot-stained hide and scavenged scraps. |
| `pop_04381` | Strife Marches Cloud Mimic Runt | [[Regions/Strife Marches\|Strife Marches]] | Runt | D- | 40 | 0.7 m | Night | Like a typical Cloud Mimic, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_04382` | Velmark Cloud Mimic Albino | [[Regions/Velmark\|Velmark]] | Albino | C- | 65 | 1 m | Night | Like a typical Cloud Mimic, but a rare pale form with white skin or fur and red eyes. |
| `pop_04383` | Aldmere Cloud Mimic Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | C | 76 | 1.25 m | Night | Like a typical Cloud Mimic, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_04384` | Aldmere Cloud Mimic Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | C+ | 86 | 1.35 m | Night | Like a typical Cloud Mimic, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |

## Design recipe

Rig `rig_mimic` · mesh `mimic_base` · material `stone_metal_runes` · VFX `wind_ribbons` · palette `#a8e6cf` `#dcedc1` `#5b8c85` · broken symmetry, mimicry, audio-first reveal
