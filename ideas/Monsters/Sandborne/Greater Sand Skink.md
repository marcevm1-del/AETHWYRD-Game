---
type: monster
id: mon_greater_sand_skink
family: "Sandborne"
rank: "E"
tier: variant
tags: [monster, sandborne]
---
# Greater Sand Skink

> The Greater Sand Skink is a small creature with a compact quadruped frame, about 0.8 m long. Its sand-scoured hide is weathered and natural, colored in ochre, clay and mossy stone. Look for sand-colored scales and a tongue that tastes for water. It has alert animal eyes. Small scars and rough edges mark it as a survivor. It prowls, surrounded by pebbles that tremble and float near it. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Sandborne|Sandborne]] · Desert Beast |
| Variant of | [[Monsters/Sandborne/Sand Skink\|Sand Skink]] (elder) |
| Rank · level | E · 26 (19–32) |
| Menace | 2 · Wild |
| Element · weakness | Earth · Wind |
| Size | 0.8 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 992 · 114 · 91 · 80 · 91 · 135 |
| XP · gold | 559 · 147 |
| Ring | 7 |
| Rig · animation | [[Systems/Rigs/quad_small\|quad_small]] · `anim_quad_small` |
| Habitats | [[Regions/Zarvan\|Zarvan]], [[Regions/Sunscar\|Sunscar]], [[Regions/Zaruma\|Zaruma]] |
| Genre | Desert Epic |
| Trope | Desert giants and sandworms (Dune, Children of the Whales) |

**Field note:** Weak to Wind. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_small|quad_small]] (rigId); animation set `anim_quad_small`.
- **Dimensions:** 0.54 m high × 0.8 m long × 0.11 m wide; prefab scale 1.6.
- **Physics:** 20 kg, gravity ×1.76, poise 29, knockback resistance 0.23, death style `ragdoll_tumble`.
- **Navigation:** speed 6.94 m/s, turn 604°/s, stopping distance 0.53 m.
- **Attack count:** 5; **signature:** sand-colored scales and a tongue that tastes for water.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Bite\|Bite]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Charge\|Charge]] | dash | 1.3 | 5 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Leap\|Leap]] | dash | 1.2 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Sand Burrow\|Sand Burrow]] | dash | 1.5 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Greater Sand Skink is a **wild desert beast** encountered at E rank, around level 26. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** sand-colored scales and a tongue that tastes for water. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Zarvan|Zarvan]], [[Regions/Sunscar|Sunscar]], [[Regions/Zaruma|Zaruma]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_small`, animation set `anim_quad_small`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Sandborne E|loot_sandborne_e]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Desert Glass\|Desert Glass]] | 60% | 1–3 |
| [[Items/Sand Pearl\|Sand Pearl]] | 30% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Sunscar\|Sunscar]] | 5 | D, E-, E+, F+, D- | 13–48 | Day & Night |
| [[Regions/Zarvan\|Zarvan]] | 2 | D-, E | 26–40 | Day & Night |
| [[Regions/Zaruma\|Zaruma]] | 4 | D, E+, D-, E | 26–48 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05516` | Sunscar Greater Sand Skink Elderborn | [[Regions/Sunscar\|Sunscar]] | Elderborn | D | 48 | 1.08 m | Day & Night | Like a typical Greater Sand Skink, but old and wise, with greying features and a cautious hunting style, with sun-bleached, sand-scoured coloring. |
| `pop_05517` | Zarvan Greater Sand Skink Alpha | [[Regions/Zarvan\|Zarvan]] | Alpha | D- | 40 | 1 m | Day & Night | Like a typical Greater Sand Skink, but larger and scarred, and others of its kind follow it, with sun-bleached, sand-scoured coloring. |
| `pop_05518` | Zarvan Greater Sand Skink | [[Regions/Zarvan\|Zarvan]] | Adult | E | 26 | 0.8 m | Day & Night | A typical adult Greater Sand Skink of this region, with sun-bleached, sand-scoured coloring. |
| `pop_05519` | Zaruma Greater Sand Skink Elderborn | [[Regions/Zaruma\|Zaruma]] | Elderborn | D | 48 | 1.08 m | Day & Night | Like a typical Greater Sand Skink, but old and wise, with greying features and a cautious hunting style, with sun-bleached, sand-scoured coloring. |
| `pop_05520` | Zaruma Greater Sand Skink Scarred | [[Regions/Zaruma\|Zaruma]] | Scarred | E+ | 32 | 0.88 m | Day & Night | Like a typical Greater Sand Skink, but covered in old battle scars, with sun-bleached, sand-scoured coloring. |
| `pop_05521` | Zaruma Greater Sand Skink Alpha | [[Regions/Zaruma\|Zaruma]] | Alpha | D- | 40 | 1 m | Day & Night | Like a typical Greater Sand Skink, but larger and scarred, and others of its kind follow it, with sun-bleached, sand-scoured coloring. |
| `pop_05522` | Sunscar Greater Sand Skink Juvenile | [[Regions/Sunscar\|Sunscar]] | Juvenile | E- | 19 | 0.68 m | Day & Night | Like a typical Greater Sand Skink, but young, with brighter colors and unworn features, with sun-bleached, sand-scoured coloring. |
| `pop_05523` | Sunscar Greater Sand Skink Scarred | [[Regions/Sunscar\|Sunscar]] | Scarred | E+ | 32 | 0.88 m | Day & Night | Like a typical Greater Sand Skink, but covered in old battle scars, with sun-bleached, sand-scoured coloring. |
| `pop_05524` | Sunscar Greater Sand Skink Runt | [[Regions/Sunscar\|Sunscar]] | Runt | F+ | 13 | 0.56 m | Day & Night | Like a typical Greater Sand Skink, but smaller and scrappier than usual, with sun-bleached, sand-scoured coloring. |
| `pop_05525` | Zaruma Greater Sand Skink | [[Regions/Zaruma\|Zaruma]] | Adult | E | 26 | 0.8 m | Day & Night | A typical adult Greater Sand Skink of this region, with sun-bleached, sand-scoured coloring. |
| `pop_05526` | Sunscar Greater Sand Skink Alpha | [[Regions/Sunscar\|Sunscar]] | Alpha | D- | 40 | 1 m | Day & Night | Like a typical Greater Sand Skink, but larger and scarred, and others of its kind follow it, with sun-bleached, sand-scoured coloring. |

## Design recipe

Rig `rig_quad_small` · mesh `quad_small_base` · material `sand_hide` · VFX `rock_debris` · palette `#8b5a2b` `#c2a878` `#4a4a3a` · real-animal silhouette with one fantasy exaggeration
