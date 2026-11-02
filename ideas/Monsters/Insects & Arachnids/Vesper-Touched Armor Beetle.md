---
type: monster
id: mon_vesper_touched_armor_beetle
family: "Insects & Arachnids"
rank: "D"
tier: variant
tags: [monster, insects-arachnids]
---
# Vesper-Touched Armor Beetle

![[mon_vesper_touched_armor_beetle_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_vesper_touched_armor_beetle_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,880 tris · 0.704 × 1.2 × 0.436 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Vesper-Touched Armor Beetle is a person-sized creature with a segmented six-limbed frame, about 1.2 m long. Its chitin is rough, scarred and spiked, colored in amber, with ochre markings. Look for a shell like polished bronze. It has narrow glowing eyes. A distinctive marking runs along its back. It circles its prey, surrounded by pebbles that tremble and float near it. Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.

| Field | Value |
|---|---|
| Family · type | [[Families/Insects & Arachnids|Insects & Arachnids]] · Insectoid |
| Variant of | [[Monsters/Insects & Arachnids/Armor Beetle\|Armor Beetle]] (corrupted) |
| Rank · level | D · 48 (40–56) |
| Menace | 3 · Menacing |
| Element · weakness | Earth · Wind |
| Size | 1.2 m |
| Behaviour | Swarm (swarm_surround) |
| HP · ATK · DEF · MATK · MDEF · SPD | 4539 · 202 · 303 · 121 · 202 · 70 |
| XP · gold | 1477 · 342 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/hexapod\|hexapod]] · `anim_hexapod` |
| Habitats | [[Regions/Moraveil\|Moraveil]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Umbravel\|Umbravel]] |
| Genre | Classic Fantasy |
| Trope | Giant insects as low-floor threats; the arachne as an intelligent monster race |

**Field note:** Weak to Wind. Dangerous in numbers. Area attacks and chokepoints help.

## Motion implementation

- **Rig:** [[Systems/Rigs/hexapod|hexapod]] (rigId); animation set `anim_hexapod`.
- **Dimensions:** 0.4 m high × 1.2 m long × 0.61 m wide; prefab scale 1.5.
- **Physics:** 98.8 kg, gravity ×1.54, poise 73, knockback resistance 0.46, death style `flip_legs_curl`.
- **Navigation:** speed 3.81 m/s, turn 456°/s, stopping distance 0.57 m.
- **Attack count:** 5; **signature:** a shell like polished bronze.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Mandible Crush\|Mandible Crush]] | melee | 1.1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Burrow Ambush\|Burrow Ambush]] | dash | 1.5 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Acid Spray\|Acid Spray]] | ranged | 1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Silk Snare\|Silk Snare]] | ranged | 0.4 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Vesper-Touched Armor Beetle is a **menacing insectoid** encountered at D rank, around level 48. Its documented behaviour is *Swarm* and its AI pattern is *swarm_surround*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a shell like polished bronze. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Moraveil|Moraveil]], [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Umbravel|Umbravel]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_hexapod`, animation set `anim_hexapod`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Insects & Arachnids D|loot_insect_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Carapace Shard\|Carapace Shard]] | 60% | 1–3 |
| [[Items/Silk\|Silk]] | 30% | 1–1 |
| [[Items/Venom Sac\|Venom Sac]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 4 | D+, D-, E+, D | 32–56 | Day & Night |
| [[Regions/Umbravel\|Umbravel]] | 2 | C, D+ | 56–76 | Day & Night |
| [[Regions/Moraveil\|Moraveil]] | 5 | D+, E+, C, D | 32–76 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03540` | Great Labyrinth (Floors 1-40) Vesper-Touched Armor Beetle Albino | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Albino | D+ | 56 | 1.2 m | Day & Night | Like a typical Vesper-Touched Armor Beetle, but a rare pale form with white skin or fur and red eyes. |
| `pop_03541` | Umbravel Vesper-Touched Armor Beetle Elderborn | [[Regions/Umbravel\|Umbravel]] | Elderborn | C | 76 | 1.62 m | Day & Night | Like a typical Vesper-Touched Armor Beetle, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_03542` | Moraveil Vesper-Touched Armor Beetle Albino | [[Regions/Moraveil\|Moraveil]] | Albino | D+ | 56 | 1.2 m | Day & Night | Like a typical Vesper-Touched Armor Beetle, but a rare pale form with white skin or fur and red eyes. |
| `pop_03543` | Great Labyrinth (Floors 1-40) Vesper-Touched Armor Beetle Juvenile | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Juvenile | D- | 40 | 1.02 m | Day & Night | Like a typical Vesper-Touched Armor Beetle, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_03544` | Great Labyrinth (Floors 1-40) Vesper-Touched Armor Beetle Runt | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Runt | E+ | 32 | 0.84 m | Day & Night | Like a typical Vesper-Touched Armor Beetle, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_03545` | Moraveil Vesper-Touched Armor Beetle Runt | [[Regions/Moraveil\|Moraveil]] | Runt | E+ | 32 | 0.84 m | Day & Night | Like a typical Vesper-Touched Armor Beetle, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_03546` | Moraveil Vesper-Touched Armor Beetle Elderborn | [[Regions/Moraveil\|Moraveil]] | Elderborn | C | 76 | 1.62 m | Day & Night | Like a typical Vesper-Touched Armor Beetle, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_03547` | Umbravel Vesper-Touched Armor Beetle Scarred | [[Regions/Umbravel\|Umbravel]] | Scarred | D+ | 56 | 1.32 m | Day & Night | Like a typical Vesper-Touched Armor Beetle, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_03548` | Great Labyrinth (Floors 1-40) Vesper-Touched Armor Beetle | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Adult | D | 48 | 1.2 m | Day & Night | A typical adult Vesper-Touched Armor Beetle of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_03549` | Moraveil Vesper-Touched Armor Beetle | [[Regions/Moraveil\|Moraveil]] | Adult | D | 48 | 1.2 m | Day & Night | A typical adult Vesper-Touched Armor Beetle of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_03550` | Moraveil Vesper-Touched Armor Beetle Scarred | [[Regions/Moraveil\|Moraveil]] | Scarred | D+ | 56 | 1.32 m | Day & Night | Like a typical Vesper-Touched Armor Beetle, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_hexapod` · mesh `hexapod_base` · material `chitin_gloss` · VFX `rock_debris` · palette `#b87f2c` `#754f1b` `#d1a15a` · triangle-based silhouette, sharp asymmetric spikes
