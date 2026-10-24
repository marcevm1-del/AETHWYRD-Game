---
type: monster
id: mon_deep_queen_s_guard
family: "Killer Insects"
rank: "C+"
tier: variant
tags: [monster, killer-insects]
---
# Deep Queen's Guard

![[mon_deep_queen_s_guard_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_deep_queen_s_guard_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (3,918 tris · 2.067 × 2 × 1.808 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Deep Queen's Guard is a person-sized creature with a six-legged armored body, about 2 m long. Its chitin is rough, scarred and spiked, colored in ink black with bruised violet. Look for a shield-shaped head plate. It has burning slit pupils. Battle-worn plates and trophies hang from its body. It circles its prey, surrounded by shadows that lean toward it. Adapted to underworld lands, it has bioluminescent spots along its body.

| Field | Value |
|---|---|
| Family · type | [[Families/Killer Insects|Killer Insects]] · Insectoid |
| Variant of | [[Monsters/Killer Insects/Queen's Guard\|Queen's Guard]] (regional) |
| Rank · level | C+ · 86 (76–96) |
| Menace | 3 · Menacing |
| Element · weakness | Dark · Light |
| Size | 2 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 12800 · 354 · 531 · 212 · 354 · 70 |
| XP · gold | 3743 · 769 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/hexapod\|hexapod]] · `anim_hexapod` |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] |
| Genre | Dungeon Crawl |
| Trope | The rookie-killing ants of the early dungeon floors (DanMachi) |

**Field note:** Weak to Light. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/hexapod|hexapod]] (rigId); animation set `anim_hexapod`.
- **Dimensions:** 0.66 m high × 2 m long × 1.02 m wide; prefab scale 2.5.
- **Physics:** 352 kg, gravity ×1.4, poise 163, knockback resistance 0.34, death style `flip_legs_curl`.
- **Navigation:** speed 5.88 m/s, turn 354°/s, stopping distance 0.68 m.
- **Attack count:** 5; **signature:** a shield-shaped head plate.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Mandible Crush\|Mandible Crush]] | melee | 1.1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Burrow Ambush\|Burrow Ambush]] | dash | 1.5 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Acid Spray\|Acid Spray]] | ranged | 1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Swarm Bite\|Swarm Bite]] | aoe | 0.9 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Deep Queen's Guard is a **menacing insectoid** encountered at C+ rank, around level 86. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a shield-shaped head plate. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

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
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 5 | C+, B-, C, C- | 65–96 | Day & Night |
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 6 | C-, C+, B-, B+, B | 65–120 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06517` | Great Labyrinth (Floors 1-40) Deep Queen's Guard | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Adult | C+ | 86 | 2 m | Day & Night | A typical adult Deep Queen's Guard of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_06518` | Great Labyrinth (Floors 1-40) Deep Queen's Guard Albino | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Albino | B- | 96 | 2 m | Day & Night | Like a typical Deep Queen's Guard, but a rare pale form with white skin or fur and red eyes. |
| `pop_06519` | Great Labyrinth (Floors 41-90) Deep Queen's Guard Runt | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Runt | C- | 65 | 1.4 m | Day & Night | Like a typical Deep Queen's Guard, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_06520` | Great Labyrinth (Floors 41-90) Deep Queen's Guard | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Adult | C+ | 86 | 2 m | Day & Night | A typical adult Deep Queen's Guard of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_06521` | Great Labyrinth (Floors 1-40) Deep Queen's Guard Juvenile | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Juvenile | C | 76 | 1.7 m | Day & Night | Like a typical Deep Queen's Guard, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_06522` | Great Labyrinth (Floors 1-40) Deep Queen's Guard Scarred | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Scarred | B- | 96 | 2.2 m | Day & Night | Like a typical Deep Queen's Guard, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_06523` | Great Labyrinth (Floors 1-40) Deep Queen's Guard Runt | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Runt | C- | 65 | 1.4 m | Day & Night | Like a typical Deep Queen's Guard, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_06524` | Great Labyrinth (Floors 41-90) Deep Queen's Guard Albino | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Albino | B- | 96 | 2 m | Day & Night | Like a typical Deep Queen's Guard, but a rare pale form with white skin or fur and red eyes. |
| `pop_06525` | Great Labyrinth (Floors 41-90) Deep Queen's Guard Elderborn | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Elderborn | B+ | 120 | 2.7 m | Day & Night | Like a typical Deep Queen's Guard, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_06526` | Great Labyrinth (Floors 41-90) Deep Queen's Guard Alpha | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Alpha | B | 108 | 2.5 m | Day & Night | Like a typical Deep Queen's Guard, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_06527` | Great Labyrinth (Floors 41-90) Deep Queen's Guard Scarred | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Scarred | B- | 96 | 2.2 m | Day & Night | Like a typical Deep Queen's Guard, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |

## Design recipe

Rig `rig_hexapod` · mesh `hexapod_base` · material `chitin_matte` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · triangle-based silhouette, sharp asymmetric spikes
