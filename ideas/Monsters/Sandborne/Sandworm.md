---
type: monster
id: mon_sandworm
family: "Sandborne"
rank: "B"
tier: core
tags: [monster, sandborne]
---
# Sandworm

![[mon_sandworm_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_sandworm_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (3,940 tris · 9.1 × 40 × 16.815 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Sandworm is a colossal creature with a massive snake-like frame, about 40 m long. Its sand-scoured hide is rough, scarred and spiked, colored in sunbaked clay, with ochre markings. Survivors describe a round mouth ringed with crystal teeth. It has eyes that catch torchlight like coins. Faint runes glow along its body when it fights. It circles its prey, surrounded by pebbles that tremble and float near it.

| Field | Value |
|---|---|
| Family · type | [[Families/Sandborne|Sandborne]] · Desert Beast |
| Rank · level | B · 108 (96–120) |
| Menace | 3 · Menacing |
| Element · weakness | Earth · Wind |
| Size | 40 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 25574 · 442 · 354 · 309 · 354 · 135 |
| XP · gold | 5386 · 1057 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/serpent\|serpent]] · `anim_serpent` |
| Habitats | [[Regions/Zarvan\|Zarvan]], [[Regions/Sunscar\|Sunscar]], [[Regions/Zaruma\|Zaruma]], [[Regions/Dunewhale Drift\|Dunewhale Drift]] |
| Genre | Desert Epic |
| Trope | Desert giants and sandworms (Dune, Children of the Whales) |

**Field note:** Weak to Wind. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/serpent|serpent]] (rigId); animation set `anim_serpent`.
- **Dimensions:** 1.6 m high × 40 m long × 4 m wide; prefab scale 10.
- **Physics:** 191360 kg, gravity ×1.32, poise 3258, knockback resistance 0.67, death style `limp_chain`.
- **Navigation:** speed 17.86 m/s, turn 60°/s, stopping distance 1.8 m.
- **Attack count:** 5; **signature:** a round mouth ringed with crystal teeth.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Strike\|Strike]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Constrict\|Constrict]] | grab | 1.8 | 12 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Tail Sweep\|Tail Sweep]] | aoe | 1.2 | 7 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Sand Burrow\|Sand Burrow]] | dash | 1.5 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Sandworm is a **menacing desert beast** encountered at B rank, around level 108. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a round mouth ringed with crystal teeth. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Zarvan|Zarvan]], [[Regions/Sunscar|Sunscar]], [[Regions/Zaruma|Zaruma]], [[Regions/Dunewhale Drift|Dunewhale Drift]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_serpent`, animation set `anim_serpent`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Sandborne B|loot_sandborne_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Desert Glass\|Desert Glass]] | 60% | 1–3 |
| [[Items/Sand Pearl\|Sand Pearl]] | 30% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Sandborne/Elder Sandworm|Elder Sandworm]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Sunscar\|Sunscar]] | 3 | B-, A-, B+ | 96–132 | Day & Night |
| [[Regions/Zaruma\|Zaruma]] | 5 | A-, C+, B+, A, B | 86–146 | Day & Night |
| [[Regions/Dunewhale Drift\|Dunewhale Drift]] | 1 | B+ | 120–120 | Day & Night |
| [[Regions/Zarvan\|Zarvan]] | 2 | A-, B | 108–132 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02706` | Sunscar Sandworm Juvenile | [[Regions/Sunscar\|Sunscar]] | Juvenile | B- | 96 | 34 m | Day & Night | Like a typical Sandworm, but young, with brighter colors and unworn features, with sun-bleached, sand-scoured coloring. |
| `pop_02707` | Zaruma Sandworm Alpha | [[Regions/Zaruma\|Zaruma]] | Alpha | A- | 132 | 50 m | Day & Night | Like a typical Sandworm, but larger and scarred, and others of its kind follow it, with sun-bleached, sand-scoured coloring. |
| `pop_02708` | Sunscar Sandworm Alpha | [[Regions/Sunscar\|Sunscar]] | Alpha | A- | 132 | 50 m | Day & Night | Like a typical Sandworm, but larger and scarred, and others of its kind follow it, with sun-bleached, sand-scoured coloring. |
| `pop_02709` | Dunewhale Drift Sandworm Scarred | [[Regions/Dunewhale Drift\|Dunewhale Drift]] | Scarred | B+ | 120 | 44 m | Day & Night | Like a typical Sandworm, but covered in old battle scars, with sun-bleached, sand-scoured coloring. |
| `pop_02710` | Zaruma Sandworm Runt | [[Regions/Zaruma\|Zaruma]] | Runt | C+ | 86 | 28 m | Day & Night | Like a typical Sandworm, but smaller and scrappier than usual, with sun-bleached, sand-scoured coloring. |
| `pop_02711` | Zarvan Sandworm Alpha | [[Regions/Zarvan\|Zarvan]] | Alpha | A- | 132 | 50 m | Day & Night | Like a typical Sandworm, but larger and scarred, and others of its kind follow it, with sun-bleached, sand-scoured coloring. |
| `pop_02712` | Zaruma Sandworm Albino | [[Regions/Zaruma\|Zaruma]] | Albino | B+ | 120 | 40 m | Day & Night | Like a typical Sandworm, but a rare pale form with white skin or fur and red eyes. |
| `pop_02713` | Sunscar Sandworm Scarred | [[Regions/Sunscar\|Sunscar]] | Scarred | B+ | 120 | 44 m | Day & Night | Like a typical Sandworm, but covered in old battle scars, with sun-bleached, sand-scoured coloring. |
| `pop_02714` | Zaruma Sandworm Elderborn | [[Regions/Zaruma\|Zaruma]] | Elderborn | A | 146 | 54 m | Day & Night | Like a typical Sandworm, but old and wise, with greying features and a cautious hunting style, with sun-bleached, sand-scoured coloring. |
| `pop_02715` | Zaruma Sandworm | [[Regions/Zaruma\|Zaruma]] | Adult | B | 108 | 40 m | Day & Night | A typical adult Sandworm of this region, with sun-bleached, sand-scoured coloring. |
| `pop_02716` | Zarvan Sandworm | [[Regions/Zarvan\|Zarvan]] | Adult | B | 108 | 40 m | Day & Night | A typical adult Sandworm of this region, with sun-bleached, sand-scoured coloring. |

## Design recipe

Rig `rig_serpent` · mesh `serpent_base` · material `sand_hide` · VFX `rock_debris` · palette `#b66c4d` `#784432` `#d1a15a` · triangle-based silhouette, sharp asymmetric spikes
