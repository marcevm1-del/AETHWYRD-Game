---
type: monster
id: mon_hornet_lancer
family: "Killer Insects"
rank: "D"
tier: core
tags: [monster, killer-insects]
---
# Hornet Lancer

![[mon_hornet_lancer_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_hornet_lancer_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 12,000 tris · 2.384 × 1.373 × 1.2 m · local file `Game/Assets/_Game/Art/Models/Monsters/Killer Insects/mon_hornet_lancer.fbx`

> The Hornet Lancer is a person-sized creature with a bat-like flying frame, about 1.2 m tall. Its chitin is rough, scarred and spiked, colored in black, with sickly green markings. Its most striking feature is a lance-like stinger and humming armored wings. It has burning slit pupils. A distinctive marking runs along its back. It circles its prey, surrounded by a low toxic haze that clings to the ground.

| Field | Value |
|---|---|
| Family · type | [[Families/Killer Insects|Killer Insects]] · Insectoid |
| Rank · level | D · 48 (40–56) |
| Menace | 3 · Menacing |
| Element · weakness | Poison · Light |
| Size | 1.2 m |
| Behaviour | Swarm (swarm_surround) |
| HP · ATK · DEF · MATK · MDEF · SPD | 2756 · 202 · 162 · 141 · 162 · 135 |
| XP · gold | 1477 · 342 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/hexapod\|hexapod]] · `anim_flyer_small` |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Umbravel\|Umbravel]], [[Regions/Xochitl Mire\|Xochitl Mire]], [[Regions/Moraveil\|Moraveil]], [[Regions/Iron Hold\|Iron Hold]] |
| Genre | Dungeon Crawl |
| Trope | The rookie-killing ants of the early dungeon floors (DanMachi) |

**Field note:** Weak to Light. Dangerous in numbers. Area attacks and chokepoints help.

## Motion implementation

- **Rig:** [[Systems/Rigs/hexapod|hexapod]] (override); animation set `anim_flyer_small`.
- **Dimensions:** 0.4 m high × 1.2 m long × 0.61 m wide; prefab scale 1.5.
- **Physics:** 76 kg, gravity ×1.4, poise 67, knockback resistance 0.31, death style `flip_legs_curl`.
- **Navigation:** speed 4.02 m/s, turn 456°/s, stopping distance 0.57 m.
- **Attack count:** 5; **signature:** [object Object].

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Nip\|Nip]] | melee | 0.9 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Dart\|Dart]] | dash | 1.1 | 4 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Swarm Call\|Swarm Call]] | summon | 0 | 20 s | None | none | Interrupt or reposition; watch for added enemies. |
| [[Attacks/Swarm Bite\|Swarm Bite]] | aoe | 0.9 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Venom Spit\|Venom Spit]] | magic | 1.5 | 10 s | Poison | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Hornet Lancer is a **menacing insectoid** encountered at D rank, around level 48. Its documented behaviour is *Swarm* and its AI pattern is *swarm_surround*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a lance-like stinger and humming armored wings. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Umbravel|Umbravel]], [[Regions/Xochitl Mire|Xochitl Mire]], [[Regions/Moraveil|Moraveil]], [[Regions/Iron Hold|Iron Hold]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_flyer_small`, animation set `anim_flyer_small`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Killer Insects D|loot_killer_insect_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Killer Mandible\|Killer Mandible]] | 60% | 1–3 |
| [[Items/Stinger\|Stinger]] | 30% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Killer Insects/Greater Hornet Lancer|Greater Hornet Lancer]]
- [[Monsters/Killer Insects/Zephyr Hornet Lancer|Zephyr Hornet Lancer]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Iron Hold\|Iron Hold]] | 3 | D+, E+, C | 32–76 | Day & Night |
| [[Regions/Xochitl Mire\|Xochitl Mire]] | 4 | D-, E+, D, C- | 32–65 | Day & Night |
| [[Regions/Umbravel\|Umbravel]] | 1 | C | 76–76 | Day & Night |
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 2 | C, D | 48–76 | Day & Night |
| [[Regions/Moraveil\|Moraveil]] | 1 | E+ | 32–32 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00752` | Iron Hold Hornet Lancer Scarred | [[Regions/Iron Hold\|Iron Hold]] | Scarred | D+ | 56 | 1.32 m | Day & Night | Like a typical Hornet Lancer, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_00753` | Xochitl Mire Hornet Lancer Juvenile | [[Regions/Xochitl Mire\|Xochitl Mire]] | Juvenile | D- | 40 | 1.02 m | Day & Night | Like a typical Hornet Lancer, but young, with brighter colors and unworn features, with vivid tropical markings. |
| `pop_00754` | Umbravel Hornet Lancer Elderborn | [[Regions/Umbravel\|Umbravel]] | Elderborn | C | 76 | 1.62 m | Day & Night | Like a typical Hornet Lancer, but old and wise, with greying features and a cautious hunting style, with bioluminescent spots along its body. |
| `pop_00755` | Xochitl Mire Hornet Lancer Runt | [[Regions/Xochitl Mire\|Xochitl Mire]] | Runt | E+ | 32 | 0.84 m | Day & Night | Like a typical Hornet Lancer, but smaller and scrappier than usual, with vivid tropical markings. |
| `pop_00756` | Iron Hold Hornet Lancer Runt | [[Regions/Iron Hold\|Iron Hold]] | Runt | E+ | 32 | 0.84 m | Day & Night | Like a typical Hornet Lancer, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_00757` | Great Labyrinth (Floors 1-40) Hornet Lancer Elderborn | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Elderborn | C | 76 | 1.62 m | Day & Night | Like a typical Hornet Lancer, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_00758` | Great Labyrinth (Floors 1-40) Hornet Lancer | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Adult | D | 48 | 1.2 m | Day & Night | A typical adult Hornet Lancer of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_00759` | Xochitl Mire Hornet Lancer | [[Regions/Xochitl Mire\|Xochitl Mire]] | Adult | D | 48 | 1.2 m | Day & Night | A typical adult Hornet Lancer of this region, with vivid tropical markings. |
| `pop_00760` | Moraveil Hornet Lancer Runt | [[Regions/Moraveil\|Moraveil]] | Runt | E+ | 32 | 0.84 m | Day & Night | Like a typical Hornet Lancer, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_00761` | Xochitl Mire Hornet Lancer Alpha | [[Regions/Xochitl Mire\|Xochitl Mire]] | Alpha | C- | 65 | 1.5 m | Day & Night | Like a typical Hornet Lancer, but larger and scarred, and others of its kind follow it, with vivid tropical markings. |
| `pop_00762` | Iron Hold Hornet Lancer Elderborn | [[Regions/Iron Hold\|Iron Hold]] | Elderborn | C | 76 | 1.62 m | Day & Night | Like a typical Hornet Lancer, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |

## Design recipe

Rig `rig_flyer_small` · mesh `flyer_small_base` · material `chitin_matte` · VFX `toxic_fog` · palette `#52515b` `#3e3c45` `#b8e986` · triangle-based silhouette, sharp asymmetric spikes
