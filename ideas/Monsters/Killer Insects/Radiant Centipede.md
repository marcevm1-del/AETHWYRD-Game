---
type: monster
id: mon_radiant_centipede
family: "Killer Insects"
rank: "C-"
tier: variant
tags: [monster, killer-insects]
---
# Radiant Centipede

![[mon_radiant_centipede_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_radiant_centipede_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (3,728 tris · 1.429 × 6 × 3.296 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Radiant Centipede is a huge creature with a long, sinuous serpentine body, about 6 m long. Its chitin is patchy and subtly wrong, as if assembled from memory, colored in black, with gold markings. Guild sketches always show a hundred legs and a head like a split mask. It has eyes set slightly too far apart. Battle-worn plates and trophies hang from its body. It freezes whenever it is looked at, surrounded by soft radiance and floating motes of light. This Light-attuned variant carries one extra elemental feature, like glowing vein-lines, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Killer Insects|Killer Insects]] · Insectoid |
| Variant of | [[Monsters/Killer Insects/Tunnel Centipede\|Tunnel Centipede]] (elemental) |
| Rank · level | C- · 65 (56–76) |
| Menace | 4 · Dread |
| Element · weakness | Light · Dark |
| Size | 6 m |
| Behaviour | Aggressive (aggressive_chase+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 7362 · 270 · 216 · 189 · 216 · 135 |
| XP · gold | 2395 · 521 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/serpent\|serpent]] · `anim_serpent` |
| Habitats | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] |
| Genre | Dungeon Crawl |
| Trope | The rookie-killing ants of the early dungeon floors (DanMachi) |

**Field note:** Weak to Dark. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/serpent|serpent]] (rigId); animation set `anim_serpent`.
- **Dimensions:** 0.24 m high × 6 m long × 0.6 m wide; prefab scale 1.5.
- **Physics:** 472 kg, gravity ×1.08, poise 140, knockback resistance 0.49, death style `limp_chain`.
- **Navigation:** speed 7.16 m/s, turn 122°/s, stopping distance 0.61 m.
- **Attack count:** 5; **signature:** a hundred legs and a head like a split mask.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Strike\|Strike]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Constrict\|Constrict]] | grab | 1.8 | 12 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Tail Sweep\|Tail Sweep]] | aoe | 1.2 | 7 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Swarm Bite\|Swarm Bite]] | aoe | 0.9 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Radiant Pulse\|Radiant Pulse]] | magic | 1.5 | 10 s | Light | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Radiant Centipede is a **dread insectoid** encountered at C- rank, around level 65. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Dark**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a hundred legs and a head like a split mask. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]], [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_serpent`, animation set `anim_serpent`; keep silhouette, movement and signature attack legible at gameplay camera distance.

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
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 7 | C, C-, C+, B-, D, D+ | 48–96 | Night |
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 4 | D, C, B- | 48–96 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06506` | Great Labyrinth (Floors 41-90) Radiant Centipede Albino | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Albino | C | 76 | 6 m | Night | Like a typical Radiant Centipede, but a rare pale form with white skin or fur and red eyes. |
| `pop_06507` | Great Labyrinth (Floors 1-40) Radiant Centipede Runt | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Runt | D | 48 | 4.2 m | Night | Like a typical Radiant Centipede, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_06508` | Great Labyrinth (Floors 41-90) Radiant Centipede | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Adult | C- | 65 | 6 m | Night | A typical adult Radiant Centipede of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_06509` | Great Labyrinth (Floors 41-90) Radiant Centipede Alpha | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Alpha | C+ | 86 | 7.5 m | Night | Like a typical Radiant Centipede, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_06510` | Great Labyrinth (Floors 41-90) Radiant Centipede Scarred | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Scarred | C | 76 | 6.6 m | Night | Like a typical Radiant Centipede, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_06511` | Great Labyrinth (Floors 41-90) Radiant Centipede Elderborn | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Elderborn | B- | 96 | 8.1 m | Night | Like a typical Radiant Centipede, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_06512` | Great Labyrinth (Floors 1-40) Radiant Centipede Scarred | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Scarred | C | 76 | 6.6 m | Night | Like a typical Radiant Centipede, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_06513` | Great Labyrinth (Floors 1-40) Radiant Centipede Albino | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Albino | C | 76 | 6 m | Night | Like a typical Radiant Centipede, but a rare pale form with white skin or fur and red eyes. |
| `pop_06514` | Great Labyrinth (Floors 1-40) Radiant Centipede Elderborn | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Elderborn | B- | 96 | 8.1 m | Night | Like a typical Radiant Centipede, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_06515` | Great Labyrinth (Floors 41-90) Radiant Centipede Runt | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Runt | D | 48 | 4.2 m | Night | Like a typical Radiant Centipede, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_06516` | Great Labyrinth (Floors 41-90) Radiant Centipede Juvenile | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Juvenile | D+ | 56 | 5.1 m | Night | Like a typical Radiant Centipede, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |

## Design recipe

Rig `rig_serpent` · mesh `serpent_base` · material `chitin_matte` · VFX `holy_motes` · palette `#52535c` `#3d3d45` `#ffd166` · elongated, irregular silhouette; still-then-sudden timing
