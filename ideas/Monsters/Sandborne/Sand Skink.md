---
type: monster
id: mon_sand_skink
family: "Sandborne"
rank: "F"
tier: core
tags: [monster, sandborne]
---
# Sand Skink

![[mon_sand_skink_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_sand_skink_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,284 tris · 0.193 × 0.5 × 0.298 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Sand Skink is a small creature with a small, quick four-legged body, about 0.5 m long. Its sand-scoured hide is weathered and natural, colored in ochre, clay and mossy stone. Its most striking feature is sand-colored scales and a tongue that tastes for water. It has alert animal eyes. It has no ornament at all: simple, readable shapes. It lopes in long strides, surrounded by pebbles that tremble and float near it.

| Field | Value |
|---|---|
| Family · type | [[Families/Sandborne|Sandborne]] · Desert Beast |
| Rank · level | F · 8 (3–13) |
| Menace | 2 · Wild |
| Element · weakness | Earth · Wind |
| Size | 0.5 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 182 · 42 · 34 · 29 · 34 · 135 |
| XP · gold | 92 · 31 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/quad_small\|quad_small]] · `anim_quad_small` |
| Habitats | [[Regions/Zaruma\|Zaruma]], [[Regions/Dunewhale Drift\|Dunewhale Drift]], [[Regions/Zarvan\|Zarvan]], [[Regions/Sunscar\|Sunscar]] |
| Genre | Desert Epic |
| Trope | Desert giants and sandworms (Dune, Children of the Whales) |

**Field note:** Weak to Wind. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_small|quad_small]] (rigId); animation set `anim_quad_small`.
- **Dimensions:** 0.34 m high × 0.5 m long × 0.07 m wide; prefab scale 1.
- **Physics:** 4.9 kg, gravity ×1.76, poise 20, knockback resistance 0.2, death style `ragdoll_tumble`.
- **Navigation:** speed 6.04 m/s, turn 764°/s, stopping distance 0.5 m.
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

Sand Skink is a **wild desert beast** encountered at F rank, around level 8. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** sand-colored scales and a tongue that tastes for water. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Zaruma|Zaruma]], [[Regions/Dunewhale Drift|Dunewhale Drift]], [[Regions/Zarvan|Zarvan]], [[Regions/Sunscar|Sunscar]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_small`, animation set `anim_quad_small`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Sandborne F|loot_sandborne_f]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Desert Glass\|Desert Glass]] | 60% | 1–3 |
| [[Items/Sand Pearl\|Sand Pearl]] | 30% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Sandborne/Greater Sand Skink|Greater Sand Skink]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Zarvan\|Zarvan]] | 2 | F+, F- | 3–13 | Day & Night |
| [[Regions/Dunewhale Drift\|Dunewhale Drift]] | 2 | F+, F- | 3–13 | Day & Night |
| [[Regions/Sunscar\|Sunscar]] | 5 | E, F+, E-, F- | 3–26 | Day & Night |
| [[Regions/Zaruma\|Zaruma]] | 2 | F, F+ | 8–13 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02673` | Zarvan Sand Skink Albino | [[Regions/Zarvan\|Zarvan]] | Albino | F+ | 13 | 0.5 m | Day & Night | Like a typical Sand Skink, but a rare pale form with white skin or fur and red eyes. |
| `pop_02674` | Zarvan Sand Skink Runt | [[Regions/Zarvan\|Zarvan]] | Runt | F- | 3 | 0.35 m | Day & Night | Like a typical Sand Skink, but smaller and scrappier than usual, with sun-bleached, sand-scoured coloring. |
| `pop_02675` | Dunewhale Drift Sand Skink Scarred | [[Regions/Dunewhale Drift\|Dunewhale Drift]] | Scarred | F+ | 13 | 0.55 m | Day & Night | Like a typical Sand Skink, but covered in old battle scars, with sun-bleached, sand-scoured coloring. |
| `pop_02676` | Sunscar Sand Skink Elderborn | [[Regions/Sunscar\|Sunscar]] | Elderborn | E | 26 | 0.68 m | Day & Night | Like a typical Sand Skink, but old and wise, with greying features and a cautious hunting style, with sun-bleached, sand-scoured coloring. |
| `pop_02677` | Sunscar Sand Skink Albino | [[Regions/Sunscar\|Sunscar]] | Albino | F+ | 13 | 0.5 m | Day & Night | Like a typical Sand Skink, but a rare pale form with white skin or fur and red eyes. |
| `pop_02678` | Zaruma Sand Skink | [[Regions/Zaruma\|Zaruma]] | Adult | F | 8 | 0.5 m | Day & Night | A typical adult Sand Skink of this region, with sun-bleached, sand-scoured coloring. |
| `pop_02679` | Sunscar Sand Skink Alpha | [[Regions/Sunscar\|Sunscar]] | Alpha | E- | 19 | 0.63 m | Day & Night | Like a typical Sand Skink, but larger and scarred, and others of its kind follow it, with sun-bleached, sand-scoured coloring. |
| `pop_02680` | Sunscar Sand Skink Runt | [[Regions/Sunscar\|Sunscar]] | Runt | F- | 3 | 0.35 m | Day & Night | Like a typical Sand Skink, but smaller and scrappier than usual, with sun-bleached, sand-scoured coloring. |
| `pop_02681` | Zaruma Sand Skink Albino | [[Regions/Zaruma\|Zaruma]] | Albino | F+ | 13 | 0.5 m | Day & Night | Like a typical Sand Skink, but a rare pale form with white skin or fur and red eyes. |
| `pop_02682` | Dunewhale Drift Sand Skink Juvenile | [[Regions/Dunewhale Drift\|Dunewhale Drift]] | Juvenile | F- | 3 | 0.42 m | Day & Night | Like a typical Sand Skink, but young, with brighter colors and unworn features, with sun-bleached, sand-scoured coloring. |
| `pop_02683` | Sunscar Sand Skink Scarred | [[Regions/Sunscar\|Sunscar]] | Scarred | F+ | 13 | 0.55 m | Day & Night | Like a typical Sand Skink, but covered in old battle scars, with sun-bleached, sand-scoured coloring. |

## Design recipe

Rig `rig_quad_small` · mesh `quad_small_base` · material `sand_hide` · VFX `rock_debris` · palette `#8b5a2b` `#c2a878` `#4a4a3a` · real-animal silhouette with one fantasy exaggeration
