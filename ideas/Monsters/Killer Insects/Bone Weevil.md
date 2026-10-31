---
type: monster
id: mon_bone_weevil
family: "Killer Insects"
rank: "C"
tier: core
tags: [monster, killer-insects]
---
# Bone Weevil

![[mon_bone_weevil_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_bone_weevil_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,862 tris · 0.519 × 1 × 0.39 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Bone Weevil is a small creature with a low, wide insectoid build, about 1 m long. Its chitin is patchy and subtly wrong, as if assembled from memory, colored in lacquer-red, with violet markings. Look for a shell made from the bones it eats. It has eyes set slightly too far apart. Battle-worn plates and trophies hang from its body. It glides without moving its legs, surrounded by shadows that lean toward it.

| Field | Value |
|---|---|
| Family · type | [[Families/Killer Insects|Killer Insects]] · Insectoid |
| Rank · level | C · 76 (65–86) |
| Menace | 4 · Dread |
| Element · weakness | Dark · Light |
| Size | 1 m |
| Behaviour | Aggressive (aggressive_chase+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 8432 · 314 · 471 · 188 · 314 · 70 |
| XP · gold | 3073 · 648 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/hexapod\|hexapod]] · `anim_hexapod` |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/Umbravel\|Umbravel]], [[Regions/Lumbaya\|Lumbaya]] |
| Genre | Dungeon Crawl |
| Trope | The rookie-killing ants of the early dungeon floors (DanMachi) |

**Field note:** Weak to Light. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/hexapod|hexapod]] (rigId); animation set `anim_hexapod`.
- **Dimensions:** 0.33 m high × 1 m long × 0.51 m wide; prefab scale 1.25.
- **Physics:** 44 kg, gravity ×1.4, poise 55, knockback resistance 0.34, death style `flip_legs_curl`.
- **Navigation:** speed 3.96 m/s, turn 500°/s, stopping distance 0.54 m.
- **Attack count:** 5; **signature:** a shell made from the bones it eats.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Mandible Crush\|Mandible Crush]] | melee | 1.1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Burrow Ambush\|Burrow Ambush]] | dash | 1.5 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Acid Spray\|Acid Spray]] | ranged | 1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Swarm Bite\|Swarm Bite]] | aoe | 0.9 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Bone Weevil is a **dread insectoid** encountered at C rank, around level 76. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a shell made from the bones it eats. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]], [[Regions/Umbravel|Umbravel]], [[Regions/Lumbaya|Lumbaya]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_hexapod`, animation set `anim_hexapod`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Killer Insects C|loot_killer_insect_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Killer Mandible\|Killer Mandible]] | 60% | 1–3 |
| [[Items/Stinger\|Stinger]] | 30% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Killer Insects/Venom Bone Weevil|Venom Bone Weevil]]
- [[Monsters/Killer Insects/Gale Bone Weevil|Gale Bone Weevil]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 2 | C+ | 86–86 | Night |
| [[Regions/Lumbaya\|Lumbaya]] | 3 | B, C, C+ | 76–108 | Night |
| [[Regions/Umbravel\|Umbravel]] | 5 | C+, D+, C-, B | 56–108 | Night |
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 1 | C | 76–76 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00785` | Great Labyrinth (Floors 1-40) Bone Weevil Albino | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Albino | C+ | 86 | 1 m | Night | Like a typical Bone Weevil, but a rare pale form with white skin or fur and red eyes. |
| `pop_00786` | Lumbaya Bone Weevil Elderborn | [[Regions/Lumbaya\|Lumbaya]] | Elderborn | B | 108 | 1.35 m | Night | Like a typical Bone Weevil, but old and wise, with greying features and a cautious hunting style, with vivid tropical markings. |
| `pop_00787` | Lumbaya Bone Weevil | [[Regions/Lumbaya\|Lumbaya]] | Adult | C | 76 | 1 m | Night | A typical adult Bone Weevil of this region, with vivid tropical markings. |
| `pop_00788` | Lumbaya Bone Weevil Scarred | [[Regions/Lumbaya\|Lumbaya]] | Scarred | C+ | 86 | 1.1 m | Night | Like a typical Bone Weevil, but covered in old battle scars, with vivid tropical markings. |
| `pop_00789` | Umbravel Bone Weevil Albino | [[Regions/Umbravel\|Umbravel]] | Albino | C+ | 86 | 1 m | Night | Like a typical Bone Weevil, but a rare pale form with white skin or fur and red eyes. |
| `pop_00790` | Great Labyrinth (Floors 1-40) Bone Weevil Scarred | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Scarred | C+ | 86 | 1.1 m | Night | Like a typical Bone Weevil, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_00791` | Umbravel Bone Weevil Runt | [[Regions/Umbravel\|Umbravel]] | Runt | D+ | 56 | 0.7 m | Night | Like a typical Bone Weevil, but smaller and scrappier than usual, with bioluminescent spots along its body. |
| `pop_00792` | Umbravel Bone Weevil Scarred | [[Regions/Umbravel\|Umbravel]] | Scarred | C+ | 86 | 1.1 m | Night | Like a typical Bone Weevil, but covered in old battle scars, with bioluminescent spots along its body. |
| `pop_00793` | Umbravel Bone Weevil Juvenile | [[Regions/Umbravel\|Umbravel]] | Juvenile | C- | 65 | 0.85 m | Night | Like a typical Bone Weevil, but young, with brighter colors and unworn features, with bioluminescent spots along its body. |
| `pop_00794` | Umbravel Bone Weevil Elderborn | [[Regions/Umbravel\|Umbravel]] | Elderborn | B | 108 | 1.35 m | Night | Like a typical Bone Weevil, but old and wise, with greying features and a cautious hunting style, with bioluminescent spots along its body. |
| `pop_00795` | Great Labyrinth (Floors 41-90) Bone Weevil | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Adult | C | 76 | 1 m | Night | A typical adult Bone Weevil of this region, with pale, light-starved coloring and oversized eyes. |

## Design recipe

Rig `rig_hexapod` · mesh `hexapod_base` · material `chitin_matte` · VFX `shadow_wisps` · palette `#aa2d2c` `#5f2829` `#9a86d8` · elongated, irregular silhouette; still-then-sudden timing
