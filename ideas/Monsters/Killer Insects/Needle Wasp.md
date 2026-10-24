---
type: monster
id: mon_needle_wasp
family: "Killer Insects"
rank: "E+"
tier: core
tags: [monster, killer-insects]
---
# Needle Wasp

![[mon_needle_wasp_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_needle_wasp_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Needle Wasp is a tiny creature with a tiny, darting winged build, about 0.3 m tall. Its chitin is rough, scarred and spiked, colored in bruise purple with sickly green. Look for a stinger as long as its body. It has narrow glowing eyes. Small scars and rough edges mark it as a survivor. It charges without hesitation, surrounded by a low toxic haze that clings to the ground.

| Field | Value |
|---|---|
| Family · type | [[Families/Killer Insects|Killer Insects]] · Insectoid |
| Rank · level | E+ · 32 (26–40) |
| Menace | 3 · Menacing |
| Element · weakness | Poison · Light |
| Size | 0.3 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1034 · 138 · 110 · 97 · 110 · 135 |
| XP · gold | 776 · 195 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/hexapod\|hexapod]] · `anim_flyer_small` |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Dungeon Crawl |
| Trope | The rookie-killing ants of the early dungeon floors (DanMachi) |

**Field note:** Weak to Light. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/hexapod|hexapod]] (keyword); animation set `anim_flyer_small`.
- **Dimensions:** 0.1 m high × 0.3 m long × 0.15 m wide; prefab scale 0.375.
- **Physics:** 1.2 kg, gravity ×1.4, poise 7, knockback resistance 0.28, death style `flip_legs_curl`.
- **Navigation:** speed 2.11 m/s, turn 900°/s, stopping distance 0.5 m.
- **Attack count:** 5; **signature:** a stinger as long as its body.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Nip\|Nip]] | melee | 0.9 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Dart\|Dart]] | dash | 1.1 | 4 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Swarm Call\|Swarm Call]] | summon | 0 | 20 s | None | none | Interrupt or reposition; watch for added enemies. |
| [[Attacks/Swarm Bite\|Swarm Bite]] | aoe | 0.9 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Venom Spit\|Venom Spit]] | magic | 1.5 | 10 s | Poison | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Needle Wasp is a **menacing insectoid** encountered at E+ rank, around level 32. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a stinger as long as its body. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Aldmere|Aldmere]], [[Regions/Whisperwood|Whisperwood]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_flyer_small`, animation set `anim_flyer_small`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Killer Insects E|loot_killer_insect_e]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Killer Mandible\|Killer Mandible]] | 60% | 1–3 |
| [[Items/Stinger\|Stinger]] | 30% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Killer Insects/Cavern Needle Wasp|Cavern Needle Wasp]]
- [[Monsters/Killer Insects/Greater Needle Wasp|Greater Needle Wasp]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 6 | E-, D+, D, E+, E, D- | 19–56 | Day & Night |
| [[Regions/Whisperwood\|Whisperwood]] | 3 | D-, E-, E+ | 19–40 | Day & Night |
| [[Regions/Aldmere\|Aldmere]] | 2 | D- | 40–40 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00741` | Great Labyrinth (Floors 1-40) Needle Wasp Runt | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Runt | E- | 19 | 0.21 m | Day & Night | Like a typical Needle Wasp, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_00742` | Great Labyrinth (Floors 1-40) Needle Wasp Elderborn | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Elderborn | D+ | 56 | 0.41 m | Day & Night | Like a typical Needle Wasp, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_00743` | Whisperwood Needle Wasp Albino | [[Regions/Whisperwood\|Whisperwood]] | Albino | D- | 40 | 0.3 m | Day & Night | Like a typical Needle Wasp, but a rare pale form with white skin or fur and red eyes. |
| `pop_00744` | Aldmere Needle Wasp Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | D- | 40 | 0.33 m | Day & Night | Like a typical Needle Wasp, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_00745` | Great Labyrinth (Floors 1-40) Needle Wasp Alpha | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Alpha | D | 48 | 0.38 m | Day & Night | Like a typical Needle Wasp, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_00746` | Whisperwood Needle Wasp Runt | [[Regions/Whisperwood\|Whisperwood]] | Runt | E- | 19 | 0.21 m | Day & Night | Like a typical Needle Wasp, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_00747` | Aldmere Needle Wasp Albino | [[Regions/Aldmere\|Aldmere]] | Albino | D- | 40 | 0.3 m | Day & Night | Like a typical Needle Wasp, but a rare pale form with white skin or fur and red eyes. |
| `pop_00748` | Great Labyrinth (Floors 1-40) Needle Wasp | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Adult | E+ | 32 | 0.3 m | Day & Night | A typical adult Needle Wasp of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_00749` | Great Labyrinth (Floors 1-40) Needle Wasp Juvenile | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Juvenile | E | 26 | 0.26 m | Day & Night | Like a typical Needle Wasp, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_00750` | Whisperwood Needle Wasp | [[Regions/Whisperwood\|Whisperwood]] | Adult | E+ | 32 | 0.3 m | Day & Night | A typical adult Needle Wasp of this region, with dust-grey coloring and old rune scars. |
| `pop_00751` | Great Labyrinth (Floors 1-40) Needle Wasp Scarred | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Scarred | D- | 40 | 0.33 m | Day & Night | Like a typical Needle Wasp, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |

## Design recipe

Rig `rig_flyer_small` · mesh `flyer_small_base` · material `chitin_matte` · VFX `toxic_fog` · palette `#8e44ad` `#b8e986` `#2d1b3d` · triangle-based silhouette, sharp asymmetric spikes
