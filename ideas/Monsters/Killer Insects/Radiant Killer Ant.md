---
type: monster
id: mon_radiant_killer_ant
family: "Killer Insects"
rank: "E+"
tier: variant
tags: [monster, killer-insects]
---
# Radiant Killer Ant

![[mon_radiant_killer_ant_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_radiant_killer_ant_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (3,486 tris · 0.59 × 1 × 0.729 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Radiant Killer Ant is a small creature with a segmented six-limbed frame, about 1 m long. Its chitin is patchy and subtly wrong, as if assembled from memory, colored in warm gold and pearl white. Look for a pale soldier ant with a jaw that never stops working. It has eyes that never blink. Small scars and rough edges mark it as a survivor. It freezes whenever it is looked at, surrounded by soft radiance and floating motes of light. This Light-attuned variant carries one extra elemental feature, like element-scarred hide, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Killer Insects|Killer Insects]] · Insectoid |
| Variant of | [[Monsters/Killer Insects/Killer Ant\|Killer Ant]] (elemental) |
| Rank · level | E+ · 32 (26–40) |
| Menace | 4 · Dread |
| Element · weakness | Light · Dark |
| Size | 1 m |
| Behaviour | Swarm (swarm_surround+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 2365 · 138 · 207 · 83 · 138 · 70 |
| XP · gold | 776 · 195 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/hexapod\|hexapod]] · `anim_hexapod` |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Dungeon Crawl |
| Trope | The rookie-killing ants of the early dungeon floors (DanMachi) |

**Field note:** Weak to Dark. Dangerous in numbers. Area attacks and chokepoints help.

## Motion implementation

- **Rig:** [[Systems/Rigs/hexapod|hexapod]] (rigId); animation set `anim_hexapod`.
- **Dimensions:** 0.33 m high × 1 m long × 0.51 m wide; prefab scale 1.25.
- **Physics:** 41.8 kg, gravity ×1.26, poise 44, knockback resistance 0.28, death style `flip_legs_curl`.
- **Navigation:** speed 3.6 m/s, turn 500°/s, stopping distance 0.54 m.
- **Attack count:** 5; **signature:** a pale soldier ant with a jaw that never stops working.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Mandible Crush\|Mandible Crush]] | melee | 1.1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Burrow Ambush\|Burrow Ambush]] | dash | 1.5 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Acid Spray\|Acid Spray]] | ranged | 1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Swarm Bite\|Swarm Bite]] | aoe | 0.9 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Radiant Pulse\|Radiant Pulse]] | magic | 1.5 | 10 s | Light | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Radiant Killer Ant is a **dread insectoid** encountered at E+ rank, around level 32. Its documented behaviour is *Swarm* and its AI pattern is *swarm_surround+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Dark**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a pale soldier ant with a jaw that never stops working. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Aldmere|Aldmere]], [[Regions/Whisperwood|Whisperwood]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_hexapod`, animation set `anim_hexapod`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Killer Insects E|loot_killer_insect_e]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Killer Mandible\|Killer Mandible]] | 60% | 1–3 |
| [[Items/Stinger\|Stinger]] | 30% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Whisperwood\|Whisperwood]] | 3 | E-, D+, D- | 19–56 | Night |
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 4 | D-, D+, E | 26–56 | Night |
| [[Regions/Aldmere\|Aldmere]] | 4 | D-, E-, E | 19–40 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06473` | Whisperwood Radiant Killer Ant Runt | [[Regions/Whisperwood\|Whisperwood]] | Runt | E- | 19 | 0.7 m | Night | Like a typical Radiant Killer Ant, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_06474` | Great Labyrinth (Floors 1-40) Radiant Killer Ant Albino | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Albino | D- | 40 | 1 m | Night | Like a typical Radiant Killer Ant, but a rare pale form with white skin or fur and red eyes. |
| `pop_06475` | Whisperwood Radiant Killer Ant Elderborn | [[Regions/Whisperwood\|Whisperwood]] | Elderborn | D+ | 56 | 1.35 m | Night | Like a typical Radiant Killer Ant, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_06476` | Whisperwood Radiant Killer Ant Scarred | [[Regions/Whisperwood\|Whisperwood]] | Scarred | D- | 40 | 1.1 m | Night | Like a typical Radiant Killer Ant, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_06477` | Aldmere Radiant Killer Ant Albino | [[Regions/Aldmere\|Aldmere]] | Albino | D- | 40 | 1 m | Night | Like a typical Radiant Killer Ant, but a rare pale form with white skin or fur and red eyes. |
| `pop_06478` | Aldmere Radiant Killer Ant Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | D- | 40 | 1.1 m | Night | Like a typical Radiant Killer Ant, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_06479` | Great Labyrinth (Floors 1-40) Radiant Killer Ant Elderborn | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Elderborn | D+ | 56 | 1.35 m | Night | Like a typical Radiant Killer Ant, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_06480` | Great Labyrinth (Floors 1-40) Radiant Killer Ant Scarred | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Scarred | D- | 40 | 1.1 m | Night | Like a typical Radiant Killer Ant, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_06481` | Great Labyrinth (Floors 1-40) Radiant Killer Ant Juvenile | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Juvenile | E | 26 | 0.85 m | Night | Like a typical Radiant Killer Ant, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_06482` | Aldmere Radiant Killer Ant Runt | [[Regions/Aldmere\|Aldmere]] | Runt | E- | 19 | 0.7 m | Night | Like a typical Radiant Killer Ant, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_06483` | Aldmere Radiant Killer Ant Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | E | 26 | 0.85 m | Night | Like a typical Radiant Killer Ant, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |

## Design recipe

Rig `rig_hexapod` · mesh `hexapod_base` · material `chitin_matte` · VFX `holy_motes` · palette `#fff3b0` `#ffd166` `#ffffff` · elongated, irregular silhouette; still-then-sudden timing
