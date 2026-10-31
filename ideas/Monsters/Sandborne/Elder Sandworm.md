---
type: monster
id: mon_elder_sandworm
family: "Sandborne"
rank: "A"
tier: variant
tags: [monster, sandborne]
---
# Elder Sandworm

![[mon_elder_sandworm_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_elder_sandworm_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (3,584 tris · 17.037 × 64 × 24.349 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Elder Sandworm is a colossal creature with a coiling, legless body, about 64 m long. Its sand-scoured hide is rough, scarred and spiked, colored in sunbaked clay, with ochre markings. Its most striking feature is a round mouth ringed with crystal teeth. It has burning slit pupils. An elegant crest and glowing veins of mana mark it as a champion of its kind. It strides with heavy steps, surrounded by pebbles that tremble and float near it. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Sandborne|Sandborne]] · Desert Beast |
| Variant of | [[Monsters/Sandborne/Sandworm\|Sandworm]] (elder) |
| Rank · level | A · 146 (132–159) |
| Menace | 3 · Menacing |
| Element · weakness | Earth · Wind |
| Size | 64 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 44163 · 594 · 475 · 416 · 475 · 135 |
| XP · gold | 8719 · 1611 |
| Ring | 7 |
| Rig · animation | [[Systems/Rigs/serpent\|serpent]] · `anim_serpent` |
| Habitats | [[Regions/Zaruma\|Zaruma]], [[Regions/Dunewhale Drift\|Dunewhale Drift]] |
| Genre | Desert Epic |
| Trope | Desert giants and sandworms (Dune, Children of the Whales) |

**Field note:** Weak to Wind. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/serpent|serpent]] (rigId); animation set `anim_serpent`.
- **Dimensions:** 2.56 m high × 64 m long × 6.4 m wide; prefab scale 16.
- **Physics:** 783810.6 kg, gravity ×1.32, poise 7385, knockback resistance 0.7, death style `limp_chain`.
- **Navigation:** speed 22.59 m/s, turn 60°/s, stopping distance 2.64 m.
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

Elder Sandworm is a **menacing desert beast** encountered at A rank, around level 146. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a round mouth ringed with crystal teeth. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Zaruma|Zaruma]], [[Regions/Dunewhale Drift|Dunewhale Drift]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_serpent`, animation set `anim_serpent`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Sandborne A|loot_sandborne_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Desert Glass\|Desert Glass]] | 60% | 1–3 |
| [[Items/Sand Pearl\|Sand Pearl]] | 30% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Dunewhale Drift\|Dunewhale Drift]] | 6 | A-, S-, A+, B+, S | 120–188 | Day & Night |
| [[Regions/Zaruma\|Zaruma]] | 5 | A+, B+, S-, A | 120–173 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05549` | Dunewhale Drift Elder Sandworm Juvenile | [[Regions/Dunewhale Drift\|Dunewhale Drift]] | Juvenile | A- | 132 | 54.4 m | Day & Night | Like a typical Elder Sandworm, but young, with brighter colors and unworn features, with sun-bleached, sand-scoured coloring. |
| `pop_05550` | Dunewhale Drift Elder Sandworm Alpha | [[Regions/Dunewhale Drift\|Dunewhale Drift]] | Alpha | S- | 173 | 80 m | Day & Night | Like a typical Elder Sandworm, but larger and scarred, and others of its kind follow it, with sun-bleached, sand-scoured coloring. |
| `pop_05551` | Zaruma Elder Sandworm Scarred | [[Regions/Zaruma\|Zaruma]] | Scarred | A+ | 159 | 70.4 m | Day & Night | Like a typical Elder Sandworm, but covered in old battle scars, with sun-bleached, sand-scoured coloring. |
| `pop_05552` | Dunewhale Drift Elder Sandworm Scarred | [[Regions/Dunewhale Drift\|Dunewhale Drift]] | Scarred | A+ | 159 | 70.4 m | Day & Night | Like a typical Elder Sandworm, but covered in old battle scars, with sun-bleached, sand-scoured coloring. |
| `pop_05553` | Zaruma Elder Sandworm Runt | [[Regions/Zaruma\|Zaruma]] | Runt | B+ | 120 | 44.8 m | Day & Night | Like a typical Elder Sandworm, but smaller and scrappier than usual, with sun-bleached, sand-scoured coloring. |
| `pop_05554` | Dunewhale Drift Elder Sandworm Albino | [[Regions/Dunewhale Drift\|Dunewhale Drift]] | Albino | A+ | 159 | 64 m | Day & Night | Like a typical Elder Sandworm, but a rare pale form with white skin or fur and red eyes. |
| `pop_05555` | Zaruma Elder Sandworm Alpha | [[Regions/Zaruma\|Zaruma]] | Alpha | S- | 173 | 80 m | Day & Night | Like a typical Elder Sandworm, but larger and scarred, and others of its kind follow it, with sun-bleached, sand-scoured coloring. |
| `pop_05556` | Zaruma Elder Sandworm | [[Regions/Zaruma\|Zaruma]] | Adult | A | 146 | 64 m | Day & Night | A typical adult Elder Sandworm of this region, with sun-bleached, sand-scoured coloring. |
| `pop_05557` | Zaruma Elder Sandworm Albino | [[Regions/Zaruma\|Zaruma]] | Albino | A+ | 159 | 64 m | Day & Night | Like a typical Elder Sandworm, but a rare pale form with white skin or fur and red eyes. |
| `pop_05558` | Dunewhale Drift Elder Sandworm Runt | [[Regions/Dunewhale Drift\|Dunewhale Drift]] | Runt | B+ | 120 | 44.8 m | Day & Night | Like a typical Elder Sandworm, but smaller and scrappier than usual, with sun-bleached, sand-scoured coloring. |
| `pop_05559` | Dunewhale Drift Elder Sandworm Elderborn | [[Regions/Dunewhale Drift\|Dunewhale Drift]] | Elderborn | S | 188 | 86.4 m | Day & Night | Like a typical Elder Sandworm, but old and wise, with greying features and a cautious hunting style, with sun-bleached, sand-scoured coloring. |

## Design recipe

Rig `rig_serpent` · mesh `serpent_base` · material `sand_hide` · VFX `rock_debris` · palette `#c18951` `#7f5835` `#d1a15a` · triangle-based silhouette, sharp asymmetric spikes
