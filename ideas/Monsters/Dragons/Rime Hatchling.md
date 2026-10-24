---
type: monster
id: mon_rime_hatchling
family: "Dragons"
rank: "F+"
tier: variant
tags: [monster, dragons]
---
# Rime Hatchling

> The Rime Hatchling is a small creature with an ancient, serpentine dragon body, about 0.5 m long. Its scales are smooth and clean, colored in pale blues and frost-white. Look for a too-big head and wings it can't use yet. It has two bright dot eyes. It has no ornament at all: simple, readable shapes. It hops in little bursts, surrounded by falling snow motes and frosted ground where it steps. Adapted to tundra lands, it has a thick, frost-rimed coat.

| Field | Value |
|---|---|
| Family · type | [[Families/Dragons|Dragons]] · Dragon |
| Variant of | [[Monsters/Dragons/Hatchling\|Hatchling]] (regional) |
| Rank · level | F+ · 13 (8–19) |
| Menace | 1 · Charming |
| Element · weakness | Ice · Fire |
| Size | 0.5 m |
| Behaviour | Guardian (guardian_hold) |
| HP · ATK · DEF · MATK · MDEF · SPD | 588 · 81 · 74 · 81 · 74 · 100 |
| XP · gold | 190 · 57 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/dragon\|dragon]] · `anim_dragon` |
| Habitats | [[Regions/Iron Hold\|Iron Hold]], [[Regions/Hoshizora\|Hoshizora]], [[Regions/Lirian\|Lirian]] |
| Genre | High Fantasy |
| Trope | Dragons as proud, intelligent apex beings; wyverns as their lesser kin |

**Field note:** Weak to Fire. Protects something nearby: a nest, a treasure, or a place.

## Motion implementation

- **Rig:** [[Systems/Rigs/dragon|dragon]] (rigId); animation set `anim_dragon`.
- **Dimensions:** 0.28 m high × 0.5 m long × 0.71 m wide; prefab scale 0.042.
- **Physics:** 0.9 kg, gravity ×1.05, poise 179, knockback resistance 1, death style `cinematic_collapse`.
- **Navigation:** speed 1.07 m/s, turn 849°/s, stopping distance 0.5 m.
- **Attack count:** 6; **signature:** a too-big head and wings it can't use yet.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Claw\|Claw]] | melee | 1.4 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Breath\|Breath]] | aoe | 2.2 | 14 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Wing Gust\|Wing Gust]] | aoe | 1 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Tail Blade\|Tail Blade]] | melee | 1.8 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Wing Buffet\|Wing Buffet]] | aoe | 1.1 | 9 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Frost Breath\|Frost Breath]] | magic | 1.5 | 10 s | Ice | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Rime Hatchling is a **charming dragon** encountered at F+ rank, around level 13. Its documented behaviour is *Guardian* and its AI pattern is *guardian_hold*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a too-big head and wings it can't use yet. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Iron Hold|Iron Hold]], [[Regions/Hoshizora|Hoshizora]], [[Regions/Lirian|Lirian]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_dragon`, animation set `anim_dragon`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Dragons F|loot_draconic_f]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Dragon Scale\|Dragon Scale]] | 60% | 1–3 |
| [[Items/Dragon Blood\|Dragon Blood]] | 30% | 1–1 |
| [[Items/Dragon Heart\|Dragon Heart]] | 15% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Hoshizora\|Hoshizora]] | 4 | F, E+, E- | 8–32 | Day |
| [[Regions/Iron Hold\|Iron Hold]] | 3 | E+, F, E- | 8–32 | Day |
| [[Regions/Lirian\|Lirian]] | 4 | F-, E, E-, F+ | 3–26 | Day |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04219` | Hoshizora Rime Hatchling Juvenile | [[Regions/Hoshizora\|Hoshizora]] | Juvenile | F | 8 | 0.42 m | Day | Like a typical Rime Hatchling, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_04220` | Iron Hold Rime Hatchling Elderborn | [[Regions/Iron Hold\|Iron Hold]] | Elderborn | E+ | 32 | 0.68 m | Day | Like a typical Rime Hatchling, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_04221` | Lirian Rime Hatchling Runt | [[Regions/Lirian\|Lirian]] | Runt | F- | 3 | 0.35 m | Day | Like a typical Rime Hatchling, but smaller and scrappier than usual, with salt-crusted, barnacle-flecked hide. |
| `pop_04222` | Lirian Rime Hatchling Alpha | [[Regions/Lirian\|Lirian]] | Alpha | E | 26 | 0.63 m | Day | Like a typical Rime Hatchling, but larger and scarred, and others of its kind follow it, with salt-crusted, barnacle-flecked hide. |
| `pop_04223` | Lirian Rime Hatchling Albino | [[Regions/Lirian\|Lirian]] | Albino | E- | 19 | 0.5 m | Day | Like a typical Rime Hatchling, but a rare pale form with white skin or fur and red eyes. |
| `pop_04224` | Hoshizora Rime Hatchling Elderborn | [[Regions/Hoshizora\|Hoshizora]] | Elderborn | E+ | 32 | 0.68 m | Day | Like a typical Rime Hatchling, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_04225` | Iron Hold Rime Hatchling Juvenile | [[Regions/Iron Hold\|Iron Hold]] | Juvenile | F | 8 | 0.42 m | Day | Like a typical Rime Hatchling, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_04226` | Iron Hold Rime Hatchling Albino | [[Regions/Iron Hold\|Iron Hold]] | Albino | E- | 19 | 0.5 m | Day | Like a typical Rime Hatchling, but a rare pale form with white skin or fur and red eyes. |
| `pop_04227` | Lirian Rime Hatchling | [[Regions/Lirian\|Lirian]] | Adult | F+ | 13 | 0.5 m | Day | A typical adult Rime Hatchling of this region, with salt-crusted, barnacle-flecked hide. |
| `pop_04228` | Hoshizora Rime Hatchling Scarred | [[Regions/Hoshizora\|Hoshizora]] | Scarred | E- | 19 | 0.55 m | Day | Like a typical Rime Hatchling, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_04229` | Hoshizora Rime Hatchling Albino | [[Regions/Hoshizora\|Hoshizora]] | Albino | E- | 19 | 0.5 m | Day | Like a typical Rime Hatchling, but a rare pale form with white skin or fur and red eyes. |

## Design recipe

Rig `rig_dragon` · mesh `dragon_base` · material `dragon_scale` · VFX `frost_trail_snow` · palette `#bfe9ff` `#5fa8d3` `#f4fbff` · circle-based, soft silhouette
