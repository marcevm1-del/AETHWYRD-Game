---
type: monster
id: mon_elder_queen_ant
family: "Insects & Arachnids"
rank: "B"
tier: variant
tags: [monster, insects-arachnids]
---
# Elder Queen Ant

![[mon_elder_queen_ant_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_elder_queen_ant_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Elder Queen Ant is a huge creature with a segmented six-limbed frame, about 5.6 m long. Its chitin is rough, scarred and spiked, colored in ochre, clay and mossy stone. Guild sketches always show a swollen abdomen pulsing with eggs. It has burning slit pupils. Faint runes glow along its body when it fights. It strides with heavy steps, surrounded by pebbles that tremble and float near it. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Insects & Arachnids|Insects & Arachnids]] · Insectoid |
| Variant of | [[Monsters/Insects & Arachnids/Queen Ant\|Queen Ant]] (elder) |
| Rank · level | B · 108 (96–120) |
| Menace | 3 · Menacing |
| Element · weakness | Earth · Wind |
| Size | 5.6 m |
| Behaviour | Swarm (swarm_surround) |
| HP · ATK · DEF · MATK · MDEF · SPD | 25252 · 442 · 663 · 265 · 442 · 70 |
| XP · gold | 5386 · 1057 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/hexapod\|hexapod]] · `anim_hexapod` |
| Habitats | [[Regions/Moraveil\|Moraveil]], [[Regions/Zaruma\|Zaruma]] |
| Genre | Classic Fantasy |
| Trope | Giant insects as low-floor threats; the arachne as an intelligent monster race |

**Field note:** Weak to Wind. Dangerous in numbers. Area attacks and chokepoints help.

## Motion implementation

- **Rig:** [[Systems/Rigs/hexapod|hexapod]] (rigId); animation set `anim_hexapod`.
- **Dimensions:** 1.85 m high × 5.6 m long × 2.84 m wide; prefab scale 7.
- **Physics:** 10045.2 kg, gravity ×1.54, poise 974, knockback resistance 0.52, death style `flip_legs_curl`.
- **Navigation:** speed 8.24 m/s, turn 211°/s, stopping distance 1.18 m.
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

Elder Queen Ant is a **menacing insectoid** encountered at B rank, around level 108. Its documented behaviour is *Swarm* and its AI pattern is *swarm_surround*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a swollen abdomen pulsing with eggs. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Moraveil|Moraveil]], [[Regions/Zaruma|Zaruma]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_hexapod`, animation set `anim_hexapod`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Insects & Arachnids B|loot_insect_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Carapace Shard\|Carapace Shard]] | 60% | 1–3 |
| [[Items/Silk\|Silk]] | 30% | 1–1 |
| [[Items/Venom Sac\|Venom Sac]] | 15% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Moraveil\|Moraveil]] | 6 | A-, C+, B-, B, A, B+ | 86–146 | Day & Night |
| [[Regions/Zaruma\|Zaruma]] | 5 | B+, B, A, B- | 96–146 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06418` | Moraveil Elder Queen Ant Alpha | [[Regions/Moraveil\|Moraveil]] | Alpha | A- | 132 | 7 m | Day & Night | Like a typical Elder Queen Ant, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_06419` | Moraveil Elder Queen Ant Runt | [[Regions/Moraveil\|Moraveil]] | Runt | C+ | 86 | 3.92 m | Day & Night | Like a typical Elder Queen Ant, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_06420` | Moraveil Elder Queen Ant Juvenile | [[Regions/Moraveil\|Moraveil]] | Juvenile | B- | 96 | 4.76 m | Day & Night | Like a typical Elder Queen Ant, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_06421` | Zaruma Elder Queen Ant Albino | [[Regions/Zaruma\|Zaruma]] | Albino | B+ | 120 | 5.6 m | Day & Night | Like a typical Elder Queen Ant, but a rare pale form with white skin or fur and red eyes. |
| `pop_06422` | Moraveil Elder Queen Ant | [[Regions/Moraveil\|Moraveil]] | Adult | B | 108 | 5.6 m | Day & Night | A typical adult Elder Queen Ant of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_06423` | Zaruma Elder Queen Ant | [[Regions/Zaruma\|Zaruma]] | Adult | B | 108 | 5.6 m | Day & Night | A typical adult Elder Queen Ant of this region, with golden, grass-toned coloring. |
| `pop_06424` | Moraveil Elder Queen Ant Elderborn | [[Regions/Moraveil\|Moraveil]] | Elderborn | A | 146 | 7.56 m | Day & Night | Like a typical Elder Queen Ant, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_06425` | Zaruma Elder Queen Ant Elderborn | [[Regions/Zaruma\|Zaruma]] | Elderborn | A | 146 | 7.56 m | Day & Night | Like a typical Elder Queen Ant, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_06426` | Zaruma Elder Queen Ant Scarred | [[Regions/Zaruma\|Zaruma]] | Scarred | B+ | 120 | 6.16 m | Day & Night | Like a typical Elder Queen Ant, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_06427` | Moraveil Elder Queen Ant Scarred | [[Regions/Moraveil\|Moraveil]] | Scarred | B+ | 120 | 6.16 m | Day & Night | Like a typical Elder Queen Ant, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_06428` | Zaruma Elder Queen Ant Juvenile | [[Regions/Zaruma\|Zaruma]] | Juvenile | B- | 96 | 4.76 m | Day & Night | Like a typical Elder Queen Ant, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |

## Design recipe

Rig `rig_hexapod` · mesh `hexapod_base` · material `chitin_gloss` · VFX `rock_debris` · palette `#8b5a2b` `#c2a878` `#4a4a3a` · triangle-based silhouette, sharp asymmetric spikes
