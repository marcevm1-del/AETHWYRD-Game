---
type: monster
id: mon_queen_ant
family: "Insects & Arachnids"
rank: "C"
tier: core
tags: [monster, insects-arachnids]
---
# Queen Ant

![[mon_queen_ant_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_queen_ant_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,794 tris · 3.183 × 3.5 × 1.973 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Queen Ant is a large creature with a low, wide insectoid build, about 3.5 m long. Its chitin is rough, scarred and spiked, colored in ochre, clay and mossy stone. Look for a swollen abdomen pulsing with eggs. It has eyes that catch torchlight like coins. Battle-worn plates and trophies hang from its body. It circles its prey, surrounded by pebbles that tremble and float near it.

| Field | Value |
|---|---|
| Family · type | [[Families/Insects & Arachnids|Insects & Arachnids]] · Insectoid |
| Rank · level | C · 76 (65–86) |
| Menace | 3 · Menacing |
| Element · weakness | Earth · Wind |
| Size | 3.5 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 12871 · 314 · 471 · 188 · 314 · 70 |
| XP · gold | 3073 · 648 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/hexapod\|hexapod]] · `anim_hexapod` |
| Habitats | [[Regions/Moraveil\|Moraveil]], [[Regions/Zaruma\|Zaruma]], [[Regions/Vharlen\|Vharlen]] |
| Genre | Classic Fantasy |
| Trope | Giant insects as low-floor threats; the arachne as an intelligent monster race |

**Field note:** Weak to Wind. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/hexapod|hexapod]] (rigId); animation set `anim_hexapod`.
- **Dimensions:** 1.16 m high × 3.5 m long × 1.78 m wide; prefab scale 4.375.
- **Physics:** 2452.5 kg, gravity ×1.54, poise 425, knockback resistance 0.49, death style `flip_legs_curl`.
- **Navigation:** speed 6.82 m/s, turn 267°/s, stopping distance 0.89 m.
- **Attack count:** 5; **signature:** a swollen abdomen pulsing with eggs.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Mandible Crush\|Mandible Crush]] | melee | 1.1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Burrow Ambush\|Burrow Ambush]] | dash | 1.5 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Acid Spray\|Acid Spray]] | ranged | 1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Silk Snare\|Silk Snare]] | ranged | 0.4 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Queen Ant is a **menacing insectoid** encountered at C rank, around level 76. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a swollen abdomen pulsing with eggs. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Moraveil|Moraveil]], [[Regions/Zaruma|Zaruma]], [[Regions/Vharlen|Vharlen]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_hexapod`, animation set `anim_hexapod`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Insects & Arachnids C|loot_insect_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Carapace Shard\|Carapace Shard]] | 60% | 1–3 |
| [[Items/Silk\|Silk]] | 30% | 1–1 |
| [[Items/Venom Sac\|Venom Sac]] | 15% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Insects & Arachnids/Dune Queen Ant|Dune Queen Ant]]
- [[Monsters/Insects & Arachnids/Elder Queen Ant|Elder Queen Ant]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Zaruma\|Zaruma]] | 5 | B, C+, C, C- | 65–108 | Day & Night |
| [[Regions/Moraveil\|Moraveil]] | 4 | C+, D+, B | 56–108 | Day & Night |
| [[Regions/Vharlen\|Vharlen]] | 2 | C+ | 86–86 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00674` | Zaruma Queen Ant Elderborn | [[Regions/Zaruma\|Zaruma]] | Elderborn | B | 108 | 4.73 m | Day & Night | Like a typical Queen Ant, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_00675` | Zaruma Queen Ant Scarred | [[Regions/Zaruma\|Zaruma]] | Scarred | C+ | 86 | 3.85 m | Day & Night | Like a typical Queen Ant, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_00676` | Zaruma Queen Ant Albino | [[Regions/Zaruma\|Zaruma]] | Albino | C+ | 86 | 3.5 m | Day & Night | Like a typical Queen Ant, but a rare pale form with white skin or fur and red eyes. |
| `pop_00677` | Zaruma Queen Ant | [[Regions/Zaruma\|Zaruma]] | Adult | C | 76 | 3.5 m | Day & Night | A typical adult Queen Ant of this region, with golden, grass-toned coloring. |
| `pop_00678` | Moraveil Queen Ant Scarred | [[Regions/Moraveil\|Moraveil]] | Scarred | C+ | 86 | 3.85 m | Day & Night | Like a typical Queen Ant, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_00679` | Zaruma Queen Ant Juvenile | [[Regions/Zaruma\|Zaruma]] | Juvenile | C- | 65 | 2.98 m | Day & Night | Like a typical Queen Ant, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_00680` | Vharlen Queen Ant Albino | [[Regions/Vharlen\|Vharlen]] | Albino | C+ | 86 | 3.5 m | Day & Night | Like a typical Queen Ant, but a rare pale form with white skin or fur and red eyes. |
| `pop_00681` | Moraveil Queen Ant Runt | [[Regions/Moraveil\|Moraveil]] | Runt | D+ | 56 | 2.45 m | Day & Night | Like a typical Queen Ant, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_00682` | Moraveil Queen Ant Elderborn | [[Regions/Moraveil\|Moraveil]] | Elderborn | B | 108 | 4.73 m | Day & Night | Like a typical Queen Ant, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_00683` | Vharlen Queen Ant Scarred | [[Regions/Vharlen\|Vharlen]] | Scarred | C+ | 86 | 3.85 m | Day & Night | Like a typical Queen Ant, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_00684` | Moraveil Queen Ant Albino | [[Regions/Moraveil\|Moraveil]] | Albino | C+ | 86 | 3.5 m | Day & Night | Like a typical Queen Ant, but a rare pale form with white skin or fur and red eyes. |

## Design recipe

Rig `rig_hexapod` · mesh `hexapod_base` · material `chitin_gloss` · VFX `rock_debris` · palette `#8b5a2b` `#c2a878` `#4a4a3a` · triangle-based silhouette, sharp asymmetric spikes
