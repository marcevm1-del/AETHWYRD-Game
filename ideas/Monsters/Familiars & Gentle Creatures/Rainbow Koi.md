---
type: monster
id: mon_rainbow_koi
family: "Familiars & Gentle Creatures"
rank: "F"
tier: core
tags: [monster, familiars-gentle-creatures]
---
# Rainbow Koi

> The Rainbow Koi is a small creature with a streamlined aquatic body, about 0.5 m long. Its coat is smooth and clean, colored in deep blues with a glassy shine. Guild sketches always show scales that shimmer every color. It has two bright dot eyes. It has no ornament at all: simple, readable shapes. It hops in little bursts, surrounded by fine mist and droplets that orbit it.

| Field | Value |
|---|---|
| Family · type | [[Families/Familiars & Gentle Creatures|Familiars & Gentle Creatures]] · Familiar |
| Rank · level | F · 8 (3–13) |
| Menace | 1 · Charming |
| Element · weakness | Water · Lightning |
| Size | 0.5 m |
| Behaviour | Passive (passive_wander) |
| HP · ATK · DEF · MATK · MDEF · SPD | 214 · 53 · 38 · 38 · 38 · 100 |
| XP · gold | 92 · 31 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/aquatic\|aquatic]] · `anim_fish` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Cozy Fantasy |
| Trope | Cozy companion creatures |

**Field note:** Weak to Lightning. Leaves you alone unless attacked.

## Motion implementation

- **Rig:** [[Systems/Rigs/aquatic|aquatic]] (rigId); animation set `anim_fish`.
- **Dimensions:** 0.2 m high × 0.5 m long × 0.18 m wide; prefab scale 0.333.
- **Physics:** 3 kg, gravity ×1, poise 8, knockback resistance 0.3, death style `float_belly_up`.
- **Navigation:** speed 2.54 m/s, turn 566°/s, stopping distance 0.5 m.
- **Attack count:** 5; **signature:** scales that shimmer every color.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Bite\|Bite]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Breach Lunge\|Breach Lunge]] | dash | 1.7 | 9 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Thrash\|Thrash]] | aoe | 1.3 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Playful Nudge\|Playful Nudge]] | melee | 0.5 | 6 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Tide Lash\|Tide Lash]] | magic | 1.5 | 10 s | Water | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Rainbow Koi is a **charming familiar** encountered at F rank, around level 8. Its documented behaviour is *Passive* and its AI pattern is *passive_wander*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Lightning**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** scales that shimmer every color. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Whisperwood|Whisperwood]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_fish`, animation set `anim_fish`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Familiars & Gentle Creatures F|loot_familiar_f]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Soft Fur\|Soft Fur]] | 60% | 1–3 |
| [[Items/Shed Scale\|Shed Scale]] | 30% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Familiars & Gentle Creatures/Crag Koi|Crag Koi]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Whisperwood\|Whisperwood]] | 6 | F+, E, F-, F | 3–26 | Day |
| [[Regions/Aldmere\|Aldmere]] | 5 | F-, F, E-, F+ | 3–19 | Day |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02851` | Whisperwood Rainbow Koi Albino | [[Regions/Whisperwood\|Whisperwood]] | Albino | F+ | 13 | 0.5 m | Day | Like a typical Rainbow Koi, but a rare pale form with white skin or fur and red eyes. |
| `pop_02852` | Aldmere Rainbow Koi Runt | [[Regions/Aldmere\|Aldmere]] | Runt | F- | 3 | 0.35 m | Day | Like a typical Rainbow Koi, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_02853` | Whisperwood Rainbow Koi Elderborn | [[Regions/Whisperwood\|Whisperwood]] | Elderborn | E | 26 | 0.68 m | Day | Like a typical Rainbow Koi, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_02854` | Aldmere Rainbow Koi Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | F- | 3 | 0.42 m | Day | Like a typical Rainbow Koi, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_02855` | Whisperwood Rainbow Koi Runt | [[Regions/Whisperwood\|Whisperwood]] | Runt | F- | 3 | 0.35 m | Day | Like a typical Rainbow Koi, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_02856` | Aldmere Rainbow Koi | [[Regions/Aldmere\|Aldmere]] | Adult | F | 8 | 0.5 m | Day | A typical adult Rainbow Koi of this region, with golden, grass-toned coloring. |
| `pop_02857` | Aldmere Rainbow Koi Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | E- | 19 | 0.63 m | Day | Like a typical Rainbow Koi, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_02858` | Aldmere Rainbow Koi Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | F+ | 13 | 0.55 m | Day | Like a typical Rainbow Koi, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_02859` | Whisperwood Rainbow Koi | [[Regions/Whisperwood\|Whisperwood]] | Adult | F | 8 | 0.5 m | Day | A typical adult Rainbow Koi of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_02860` | Whisperwood Rainbow Koi Juvenile | [[Regions/Whisperwood\|Whisperwood]] | Juvenile | F- | 3 | 0.42 m | Day | Like a typical Rainbow Koi, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_02861` | Whisperwood Rainbow Koi Scarred | [[Regions/Whisperwood\|Whisperwood]] | Scarred | F+ | 13 | 0.55 m | Day | Like a typical Rainbow Koi, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_fish` · mesh `fish_base` · material `fur_soft` · VFX `mist_droplets` · palette `#2f7fd1` `#9ad7ff` `#123a5c` · circle-based, soft silhouette
