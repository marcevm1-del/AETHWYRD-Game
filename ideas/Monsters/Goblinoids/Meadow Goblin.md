---
type: monster
id: mon_meadow_goblin
family: "Goblinoids"
rank: "F"
tier: variant
tags: [monster, goblinoids]
---
# Meadow Goblin

> The Meadow Goblin is a small creature with a small, compact humanoid body, about 1 m tall. Its skin is rough, scarred and spiked, colored in pale jade and cloud white. Guild sketches always show a grin of needle teeth under a stolen tin helmet. It has eyes that catch torchlight like coins. It has no ornament at all: simple, readable shapes. It charges without hesitation, surrounded by swirling leaves and a constant breeze. Adapted to plains lands, it has golden, grass-toned coloring.

| Field | Value |
|---|---|
| Family · type | [[Families/Goblinoids|Goblinoids]] · Humanoid |
| Variant of | [[Monsters/Goblinoids/Goblin\|Goblin]] (regional) |
| Rank · level | F · 8 (3–13) |
| Menace | 3 · Menacing |
| Element · weakness | Wind · Fire |
| Size | 1 m |
| Behaviour | Pack (pack_flank) |
| HP · ATK · DEF · MATK · MDEF · SPD | 224 · 42 · 34 · 29 · 34 · 135 |
| XP · gold | 92 · 31 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/small_biped\|small_biped]] · `anim_small_biped` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] |
| Genre | Dark Fantasy |
| Trope | Goblins as horror in numbers (Goblin Slayer); hobgoblin → champion → king evolution |

**Field note:** Weak to Fire. Never alone. Kill the leader first and the rest may scatter.

## Motion implementation

- **Rig:** [[Systems/Rigs/small_biped|small_biped]] (override (base species)); animation set `anim_small_biped`.
- **Dimensions:** 1 m high × 0.3 m long × 0.4 m wide; prefab scale 0.909.
- **Physics:** 14.4 kg, gravity ×1.2, poise 29, knockback resistance 0.15, death style `ragdoll_crumple`.
- **Navigation:** speed 5.49 m/s, turn 420°/s, stopping distance 0.6 m.
- **Attack count:** 5; **signature:** a grin of needle teeth under a stolen tin helmet.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stab\|Stab]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Thrown Junk\|Thrown Junk]] | ranged | 0.8 | 4 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Frenzied Lunge\|Frenzied Lunge]] | melee | 1.5 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Sand Toss\|Sand Toss]] | debuff | 0 | 12 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Gale Cutter\|Gale Cutter]] | magic | 1.5 | 10 s | Wind | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Meadow Goblin is a **menacing humanoid** encountered at F rank, around level 8. Its documented behaviour is *Pack* and its AI pattern is *pack_flank*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a grin of needle teeth under a stolen tin helmet. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_small_biped`, animation set `anim_small_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Goblinoids F|loot_goblinoid_f]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Goblin Ear\|Goblin Ear]] | 60% | 1–3 |
| [[Items/Crude Blade\|Crude Blade]] | 30% | 1–1 |
| [[Items/Stolen Trinket\|Stolen Trinket]] | 15% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 5 | F-, E, F, F+ | 3–26 | Day & Night |
| [[Regions/Aldmere\|Aldmere]] | 6 | F+, F, F-, E, E- | 3–26 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05901` | Great Labyrinth (Floors 1-40) Meadow Goblin Juvenile | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Juvenile | F- | 3 | 0.85 m | Day & Night | Like a typical Meadow Goblin, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_05902` | Aldmere Meadow Goblin Albino | [[Regions/Aldmere\|Aldmere]] | Albino | F+ | 13 | 1 m | Day & Night | Like a typical Meadow Goblin, but a rare pale form with white skin or fur and red eyes. |
| `pop_05903` | Aldmere Meadow Goblin Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | F+ | 13 | 1.1 m | Day & Night | Like a typical Meadow Goblin, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_05904` | Great Labyrinth (Floors 1-40) Meadow Goblin Runt | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Runt | F- | 3 | 0.7 m | Day & Night | Like a typical Meadow Goblin, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_05905` | Great Labyrinth (Floors 1-40) Meadow Goblin Elderborn | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Elderborn | E | 26 | 1.35 m | Day & Night | Like a typical Meadow Goblin, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_05906` | Great Labyrinth (Floors 1-40) Meadow Goblin | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Adult | F | 8 | 1 m | Day & Night | A typical adult Meadow Goblin of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_05907` | Great Labyrinth (Floors 1-40) Meadow Goblin Albino | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Albino | F+ | 13 | 1 m | Day & Night | Like a typical Meadow Goblin, but a rare pale form with white skin or fur and red eyes. |
| `pop_05908` | Aldmere Meadow Goblin | [[Regions/Aldmere\|Aldmere]] | Adult | F | 8 | 1 m | Day & Night | A typical adult Meadow Goblin of this region, with golden, grass-toned coloring. |
| `pop_05909` | Aldmere Meadow Goblin Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | F- | 3 | 0.85 m | Day & Night | Like a typical Meadow Goblin, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_05910` | Aldmere Meadow Goblin Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | E | 26 | 1.35 m | Day & Night | Like a typical Meadow Goblin, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_05911` | Aldmere Meadow Goblin Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | E- | 19 | 1.25 m | Day & Night | Like a typical Meadow Goblin, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `rough_skin_leather` · VFX `wind_ribbons` · palette `#a8e6cf` `#dcedc1` `#5b8c85` · triangle-based silhouette, sharp asymmetric spikes
