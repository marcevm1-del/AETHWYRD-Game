---
type: monster
id: mon_elder_dune_scorpion
family: "Sandborne"
rank: "C"
tier: variant
tags: [monster, sandborne]
---
# Elder Dune Scorpion

![[mon_elder_dune_scorpion_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_elder_dune_scorpion_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 19,992 tris · 2.035 × 3.2 × 1.141 m · local file `Game/Assets/_Game/Art/Models/Monsters/Sandborne/mon_elder_dune_scorpion.fbx`

> The Elder Dune Scorpion is a large creature with a low, wide insectoid build, about 3.2 m long. Its sand-scoured hide is rough, scarred and spiked, colored in sunbaked clay, with sickly green markings. Look for a glass-like tail stinger. It has eyes that catch torchlight like coins. Battle-worn plates and trophies hang from its body. It circles its prey, surrounded by a low toxic haze that clings to the ground. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Sandborne|Sandborne]] · Desert Beast |
| Variant of | [[Monsters/Sandborne/Dune Scorpion\|Dune Scorpion]] (elder) |
| Rank · level | C · 76 (65–86) |
| Menace | 3 · Menacing |
| Element · weakness | Poison · Light |
| Size | 3.2 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 12494 · 314 · 471 · 188 · 314 · 70 |
| XP · gold | 3073 · 648 |
| Ring | 7 |
| Rig · animation | [[Systems/Rigs/hexapod\|hexapod]] · `anim_hexapod` |
| Habitats | [[Regions/Zaruma\|Zaruma]], [[Regions/Sunscar\|Sunscar]], [[Regions/Zarvan\|Zarvan]] |
| Genre | Desert Epic |
| Trope | Desert giants and sandworms (Dune, Children of the Whales) |

**Field note:** Weak to Light. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/hexapod|hexapod]] (rigId); animation set `anim_hexapod`.
- **Dimensions:** 1.06 m high × 3.2 m long × 1.63 m wide; prefab scale 4.
- **Physics:** 1441.8 kg, gravity ×1.4, poise 336, knockback resistance 0.34, death style `flip_legs_curl`.
- **Navigation:** speed 6.88 m/s, turn 280°/s, stopping distance 0.85 m.
- **Attack count:** 5; **signature:** a glass-like tail stinger.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Mandible Crush\|Mandible Crush]] | melee | 1.1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Burrow Ambush\|Burrow Ambush]] | dash | 1.5 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Acid Spray\|Acid Spray]] | ranged | 1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Sand Burrow\|Sand Burrow]] | dash | 1.5 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Venom Spit\|Venom Spit]] | magic | 1.5 | 10 s | Poison | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Elder Dune Scorpion is a **menacing desert beast** encountered at C rank, around level 76. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a glass-like tail stinger. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Zaruma|Zaruma]], [[Regions/Sunscar|Sunscar]], [[Regions/Zarvan|Zarvan]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_hexapod`, animation set `anim_hexapod`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Sandborne C|loot_sandborne_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Desert Glass\|Desert Glass]] | 60% | 1–3 |
| [[Items/Sand Pearl\|Sand Pearl]] | 30% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Zarvan\|Zarvan]] | 5 | B, C+, C, C- | 65–108 | Day & Night |
| [[Regions/Zaruma\|Zaruma]] | 2 | C+ | 86–86 | Day & Night |
| [[Regions/Sunscar\|Sunscar]] | 4 | C+, B, B-, C- | 65–108 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05527` | Zarvan Elder Dune Scorpion Elderborn | [[Regions/Zarvan\|Zarvan]] | Elderborn | B | 108 | 4.32 m | Day & Night | Like a typical Elder Dune Scorpion, but old and wise, with greying features and a cautious hunting style, with sun-bleached, sand-scoured coloring. |
| `pop_05528` | Zaruma Elder Dune Scorpion Albino | [[Regions/Zaruma\|Zaruma]] | Albino | C+ | 86 | 3.2 m | Day & Night | Like a typical Elder Dune Scorpion, but a rare pale form with white skin or fur and red eyes. |
| `pop_05529` | Zarvan Elder Dune Scorpion Scarred | [[Regions/Zarvan\|Zarvan]] | Scarred | C+ | 86 | 3.52 m | Day & Night | Like a typical Elder Dune Scorpion, but covered in old battle scars, with sun-bleached, sand-scoured coloring. |
| `pop_05530` | Sunscar Elder Dune Scorpion Scarred | [[Regions/Sunscar\|Sunscar]] | Scarred | C+ | 86 | 3.52 m | Day & Night | Like a typical Elder Dune Scorpion, but covered in old battle scars, with sun-bleached, sand-scoured coloring. |
| `pop_05531` | Zarvan Elder Dune Scorpion Albino | [[Regions/Zarvan\|Zarvan]] | Albino | C+ | 86 | 3.2 m | Day & Night | Like a typical Elder Dune Scorpion, but a rare pale form with white skin or fur and red eyes. |
| `pop_05532` | Zaruma Elder Dune Scorpion Scarred | [[Regions/Zaruma\|Zaruma]] | Scarred | C+ | 86 | 3.52 m | Day & Night | Like a typical Elder Dune Scorpion, but covered in old battle scars, with sun-bleached, sand-scoured coloring. |
| `pop_05533` | Sunscar Elder Dune Scorpion Elderborn | [[Regions/Sunscar\|Sunscar]] | Elderborn | B | 108 | 4.32 m | Day & Night | Like a typical Elder Dune Scorpion, but old and wise, with greying features and a cautious hunting style, with sun-bleached, sand-scoured coloring. |
| `pop_05534` | Zarvan Elder Dune Scorpion | [[Regions/Zarvan\|Zarvan]] | Adult | C | 76 | 3.2 m | Day & Night | A typical adult Elder Dune Scorpion of this region, with sun-bleached, sand-scoured coloring. |
| `pop_05535` | Sunscar Elder Dune Scorpion Alpha | [[Regions/Sunscar\|Sunscar]] | Alpha | B- | 96 | 4 m | Day & Night | Like a typical Elder Dune Scorpion, but larger and scarred, and others of its kind follow it, with sun-bleached, sand-scoured coloring. |
| `pop_05536` | Zarvan Elder Dune Scorpion Juvenile | [[Regions/Zarvan\|Zarvan]] | Juvenile | C- | 65 | 2.72 m | Day & Night | Like a typical Elder Dune Scorpion, but young, with brighter colors and unworn features, with sun-bleached, sand-scoured coloring. |
| `pop_05537` | Sunscar Elder Dune Scorpion Juvenile | [[Regions/Sunscar\|Sunscar]] | Juvenile | C- | 65 | 2.72 m | Day & Night | Like a typical Elder Dune Scorpion, but young, with brighter colors and unworn features, with sun-bleached, sand-scoured coloring. |

## Design recipe

Rig `rig_hexapod` · mesh `hexapod_base` · material `sand_hide` · VFX `toxic_fog` · palette `#aa7d47` `#70502e` `#b8e986` · triangle-based silhouette, sharp asymmetric spikes
