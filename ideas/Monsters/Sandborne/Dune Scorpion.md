---
type: monster
id: mon_dune_scorpion
family: "Sandborne"
rank: "D"
tier: core
tags: [monster, sandborne]
---
# Dune Scorpion

![[mon_dune_scorpion_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_dune_scorpion_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (3,918 tris · 2.067 × 2 × 1.808 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Dune Scorpion is a person-sized creature with a low, wide insectoid build, about 2 m long. Its sand-scoured hide is rough, scarred and spiked, colored in bruise purple with sickly green. Its most striking feature is a glass-like tail stinger. It has eyes that catch torchlight like coins. A distinctive marking runs along its back. It charges without hesitation, surrounded by a low toxic haze that clings to the ground.

| Field | Value |
|---|---|
| Family · type | [[Families/Sandborne|Sandborne]] · Desert Beast |
| Rank · level | D · 48 (40–56) |
| Menace | 3 · Menacing |
| Element · weakness | Poison · Light |
| Size | 2 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 5399 · 202 · 303 · 121 · 202 · 70 |
| XP · gold | 1477 · 342 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/hexapod\|hexapod]] · `anim_hexapod` |
| Habitats | [[Regions/Dunewhale Drift\|Dunewhale Drift]], [[Regions/Zarvan\|Zarvan]], [[Regions/Sunscar\|Sunscar]], [[Regions/Zaruma\|Zaruma]] |
| Genre | Desert Epic |
| Trope | Desert giants and sandworms (Dune, Children of the Whales) |

**Field note:** Weak to Light. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/hexapod|hexapod]] (rigId); animation set `anim_hexapod`.
- **Dimensions:** 0.66 m high × 2 m long × 1.02 m wide; prefab scale 2.5.
- **Physics:** 352 kg, gravity ×1.4, poise 146, knockback resistance 0.31, death style `flip_legs_curl`.
- **Navigation:** speed 4.94 m/s, turn 354°/s, stopping distance 0.68 m.
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

Dune Scorpion is a **menacing desert beast** encountered at D rank, around level 48. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a glass-like tail stinger. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Dunewhale Drift|Dunewhale Drift]], [[Regions/Zarvan|Zarvan]], [[Regions/Sunscar|Sunscar]], [[Regions/Zaruma|Zaruma]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_hexapod`, animation set `anim_hexapod`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Sandborne D|loot_sandborne_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Desert Glass\|Desert Glass]] | 60% | 1–3 |
| [[Items/Sand Pearl\|Sand Pearl]] | 30% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Sandborne/Elder Dune Scorpion|Elder Dune Scorpion]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Zaruma\|Zaruma]] | 1 | E+ | 32–32 | Day & Night |
| [[Regions/Dunewhale Drift\|Dunewhale Drift]] | 3 | C-, D, E+ | 32–65 | Day & Night |
| [[Regions/Zarvan\|Zarvan]] | 3 | D+, C, E+ | 32–76 | Day & Night |
| [[Regions/Sunscar\|Sunscar]] | 4 | C, D+, D-, C- | 40–76 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02684` | Zaruma Dune Scorpion Runt | [[Regions/Zaruma\|Zaruma]] | Runt | E+ | 32 | 1.4 m | Day & Night | Like a typical Dune Scorpion, but smaller and scrappier than usual, with sun-bleached, sand-scoured coloring. |
| `pop_02685` | Dunewhale Drift Dune Scorpion Alpha | [[Regions/Dunewhale Drift\|Dunewhale Drift]] | Alpha | C- | 65 | 2.5 m | Day & Night | Like a typical Dune Scorpion, but larger and scarred, and others of its kind follow it, with sun-bleached, sand-scoured coloring. |
| `pop_02686` | Dunewhale Drift Dune Scorpion | [[Regions/Dunewhale Drift\|Dunewhale Drift]] | Adult | D | 48 | 2 m | Day & Night | A typical adult Dune Scorpion of this region, with sun-bleached, sand-scoured coloring. |
| `pop_02687` | Dunewhale Drift Dune Scorpion Runt | [[Regions/Dunewhale Drift\|Dunewhale Drift]] | Runt | E+ | 32 | 1.4 m | Day & Night | Like a typical Dune Scorpion, but smaller and scrappier than usual, with sun-bleached, sand-scoured coloring. |
| `pop_02688` | Zarvan Dune Scorpion Scarred | [[Regions/Zarvan\|Zarvan]] | Scarred | D+ | 56 | 2.2 m | Day & Night | Like a typical Dune Scorpion, but covered in old battle scars, with sun-bleached, sand-scoured coloring. |
| `pop_02689` | Zarvan Dune Scorpion Elderborn | [[Regions/Zarvan\|Zarvan]] | Elderborn | C | 76 | 2.7 m | Day & Night | Like a typical Dune Scorpion, but old and wise, with greying features and a cautious hunting style, with sun-bleached, sand-scoured coloring. |
| `pop_02690` | Sunscar Dune Scorpion Elderborn | [[Regions/Sunscar\|Sunscar]] | Elderborn | C | 76 | 2.7 m | Day & Night | Like a typical Dune Scorpion, but old and wise, with greying features and a cautious hunting style, with sun-bleached, sand-scoured coloring. |
| `pop_02691` | Sunscar Dune Scorpion Scarred | [[Regions/Sunscar\|Sunscar]] | Scarred | D+ | 56 | 2.2 m | Day & Night | Like a typical Dune Scorpion, but covered in old battle scars, with sun-bleached, sand-scoured coloring. |
| `pop_02692` | Sunscar Dune Scorpion Juvenile | [[Regions/Sunscar\|Sunscar]] | Juvenile | D- | 40 | 1.7 m | Day & Night | Like a typical Dune Scorpion, but young, with brighter colors and unworn features, with sun-bleached, sand-scoured coloring. |
| `pop_02693` | Zarvan Dune Scorpion Runt | [[Regions/Zarvan\|Zarvan]] | Runt | E+ | 32 | 1.4 m | Day & Night | Like a typical Dune Scorpion, but smaller and scrappier than usual, with sun-bleached, sand-scoured coloring. |
| `pop_02694` | Sunscar Dune Scorpion Alpha | [[Regions/Sunscar\|Sunscar]] | Alpha | C- | 65 | 2.5 m | Day & Night | Like a typical Dune Scorpion, but larger and scarred, and others of its kind follow it, with sun-bleached, sand-scoured coloring. |

## Design recipe

Rig `rig_hexapod` · mesh `hexapod_base` · material `sand_hide` · VFX `toxic_fog` · palette `#8e44ad` `#b8e986` `#2d1b3d` · triangle-based silhouette, sharp asymmetric spikes
