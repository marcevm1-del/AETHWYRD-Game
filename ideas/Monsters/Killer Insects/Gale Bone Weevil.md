---
type: monster
id: mon_gale_bone_weevil
family: "Killer Insects"
rank: "C+"
tier: variant
tags: [monster, killer-insects]
---
# Gale Bone Weevil

![[mon_gale_bone_weevil_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_gale_bone_weevil_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (3,792 tris · 0.925 × 1 × 1.142 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Gale Bone Weevil is a small creature with a six-legged armored body, about 1 m long. Its chitin is patchy and subtly wrong, as if assembled from memory, colored in lacquer-red, with pale jade markings. Look for a shell made from the bones it eats. It has eyes set slightly too far apart. Battle-worn plates and trophies hang from its body. It glides without moving its legs, surrounded by swirling leaves and a constant breeze. This Wind-attuned variant carries one extra elemental feature, like crystal spikes, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Killer Insects|Killer Insects]] · Insectoid |
| Variant of | [[Monsters/Killer Insects/Bone Weevil\|Bone Weevil]] (elemental) |
| Rank · level | C+ · 86 (76–96) |
| Menace | 4 · Dread |
| Element · weakness | Wind · Fire |
| Size | 1 m |
| Behaviour | Swarm (swarm_surround+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 10133 · 354 · 531 · 212 · 354 · 70 |
| XP · gold | 3743 · 769 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/hexapod\|hexapod]] · `anim_hexapod` |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/Iron Hold\|Iron Hold]] |
| Genre | Dungeon Crawl |
| Trope | The rookie-killing ants of the early dungeon floors (DanMachi) |

**Field note:** Weak to Fire. Dangerous in numbers. Area attacks and chokepoints help.

## Motion implementation

- **Rig:** [[Systems/Rigs/hexapod|hexapod]] (rigId); animation set `anim_hexapod`.
- **Dimensions:** 0.33 m high × 1 m long × 0.51 m wide; prefab scale 1.25.
- **Physics:** 39.6 kg, gravity ×1.12, poise 53, knockback resistance 0.34, death style `flip_legs_curl`.
- **Navigation:** speed 3.89 m/s, turn 500°/s, stopping distance 0.54 m.
- **Attack count:** 5; **signature:** a shell made from the bones it eats.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Mandible Crush\|Mandible Crush]] | melee | 1.1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Burrow Ambush\|Burrow Ambush]] | dash | 1.5 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Acid Spray\|Acid Spray]] | ranged | 1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Swarm Bite\|Swarm Bite]] | aoe | 0.9 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Gale Cutter\|Gale Cutter]] | magic | 1.5 | 10 s | Wind | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Gale Bone Weevil is a **dread insectoid** encountered at C+ rank, around level 86. Its documented behaviour is *Swarm* and its AI pattern is *swarm_surround+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a shell made from the bones it eats. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]], [[Regions/Iron Hold|Iron Hold]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_hexapod`, animation set `anim_hexapod`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Killer Insects C|loot_killer_insect_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Killer Mandible\|Killer Mandible]] | 60% | 1–3 |
| [[Items/Stinger\|Stinger]] | 30% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 5 | C, C+, C-, B-, B+ | 65–120 | Night |
| [[Regions/Iron Hold\|Iron Hold]] | 3 | B-, C, C- | 65–96 | Night |
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 3 | C+, B- | 86–96 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06528` | Great Labyrinth (Floors 41-90) Gale Bone Weevil Juvenile | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Juvenile | C | 76 | 0.85 m | Night | Like a typical Gale Bone Weevil, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_06529` | Iron Hold Gale Bone Weevil Scarred | [[Regions/Iron Hold\|Iron Hold]] | Scarred | B- | 96 | 1.1 m | Night | Like a typical Gale Bone Weevil, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_06530` | Great Labyrinth (Floors 1-40) Gale Bone Weevil | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Adult | C+ | 86 | 1 m | Night | A typical adult Gale Bone Weevil of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_06531` | Great Labyrinth (Floors 41-90) Gale Bone Weevil | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Adult | C+ | 86 | 1 m | Night | A typical adult Gale Bone Weevil of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_06532` | Great Labyrinth (Floors 41-90) Gale Bone Weevil Runt | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Runt | C- | 65 | 0.7 m | Night | Like a typical Gale Bone Weevil, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_06533` | Great Labyrinth (Floors 41-90) Gale Bone Weevil Albino | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Albino | B- | 96 | 1 m | Night | Like a typical Gale Bone Weevil, but a rare pale form with white skin or fur and red eyes. |
| `pop_06534` | Great Labyrinth (Floors 1-40) Gale Bone Weevil Albino | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Albino | B- | 96 | 1 m | Night | Like a typical Gale Bone Weevil, but a rare pale form with white skin or fur and red eyes. |
| `pop_06535` | Iron Hold Gale Bone Weevil Juvenile | [[Regions/Iron Hold\|Iron Hold]] | Juvenile | C | 76 | 0.85 m | Night | Like a typical Gale Bone Weevil, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_06536` | Iron Hold Gale Bone Weevil Runt | [[Regions/Iron Hold\|Iron Hold]] | Runt | C- | 65 | 0.7 m | Night | Like a typical Gale Bone Weevil, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_06537` | Great Labyrinth (Floors 41-90) Gale Bone Weevil Elderborn | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Elderborn | B+ | 120 | 1.35 m | Night | Like a typical Gale Bone Weevil, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_06538` | Great Labyrinth (Floors 1-40) Gale Bone Weevil Scarred | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Scarred | B- | 96 | 1.1 m | Night | Like a typical Gale Bone Weevil, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |

## Design recipe

Rig `rig_hexapod` · mesh `hexapod_base` · material `chitin_matte` · VFX `wind_ribbons` · palette `#9e292c` `#592628` `#8fe0bd` · elongated, irregular silhouette; still-then-sudden timing
