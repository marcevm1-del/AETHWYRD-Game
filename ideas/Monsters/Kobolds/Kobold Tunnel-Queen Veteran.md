---
type: monster
id: mon_kobold_tunnel_queen_veteran
family: "Kobolds"
rank: "A"
tier: variant
tags: [monster, kobolds]
---
# Kobold Tunnel-Queen Veteran

> The Kobold Tunnel-Queen Veteran is a large creature with a small, compact humanoid body, about 2.6 m tall. Its mangy fur is rough, scarred and spiked, colored in ochre, clay and mossy stone. Its most striking feature is a bloated, jewel-encrusted body carried on a litter. It has burning slit pupils. An elegant crest and glowing veins of mana mark it as a champion of its kind. It circles its prey, surrounded by pebbles that tremble and float near it. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Kobolds|Kobolds]] · Humanoid |
| Variant of | [[Monsters/Kobolds/Kobold Tunnel-Queen\|Kobold Tunnel-Queen]] (elder) |
| Rank · level | A · 146 (132–159) |
| Menace | 3 · Menacing |
| Element · weakness | Earth · Wind |
| Size | 2.6 m |
| Behaviour | Pack (pack_flank) |
| HP · ATK · DEF · MATK · MDEF · SPD | 18716 · 594 · 475 · 416 · 475 · 135 |
| XP · gold | 8719 · 1611 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/small_biped\|small_biped]] · `anim_small_biped` |
| Habitats | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/The Maw\|The Maw]] |
| Genre | Dungeon Crawl |
| Trope | Dog-headed first-floor monsters (DanMachi), trap-builders (classic tabletop) |

**Field note:** Weak to Wind. Never alone. Kill the leader first and the rest may scatter.

## Motion implementation

- **Rig:** [[Systems/Rigs/small_biped|small_biped]] (rigId); animation set `anim_small_biped`.
- **Dimensions:** 2.6 m high × 0.78 m long × 1.04 m wide; prefab scale 2.364.
- **Physics:** 365.6 kg, gravity ×1.65, poise 81, knockback resistance 0.45, death style `ragdoll_crumple`.
- **Navigation:** speed 7.53 m/s, turn 260°/s, stopping distance 0.92 m.
- **Attack count:** 5; **signature:** a bloated, jewel-encrusted body carried on a litter.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stab\|Stab]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Thrown Junk\|Thrown Junk]] | ranged | 0.8 | 4 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Frenzied Lunge\|Frenzied Lunge]] | melee | 1.5 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Trip-Wire Trap\|Trip-Wire Trap]] | debuff | 0 | 14 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Kobold Tunnel-Queen Veteran is a **menacing humanoid** encountered at A rank, around level 146. Its documented behaviour is *Pack* and its AI pattern is *pack_flank*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a bloated, jewel-encrusted body carried on a litter. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]], [[Regions/The Maw|The Maw]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_small_biped`, animation set `anim_small_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Kobolds A|loot_kobold_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Kobold Fang\|Kobold Fang]] | 60% | 1–3 |
| [[Items/Scrap Metal\|Scrap Metal]] | 30% | 1–1 |
| [[Items/Candle Stub\|Candle Stub]] | 15% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/The Maw\|The Maw]] | 7 | S, S-, B+, A+, A, A- | 120–188 | Day & Night |
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 4 | A+, S, S- | 159–188 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06110` | The Maw Kobold Tunnel-Queen Veteran Elderborn | [[Regions/The Maw\|The Maw]] | Elderborn | S | 188 | 3.51 m | Day & Night | Like a typical Kobold Tunnel-Queen Veteran, but old and wise, with greying features and a cautious hunting style, with bioluminescent spots along its body. |
| `pop_06111` | Great Labyrinth (Floors 41-90) Kobold Tunnel-Queen Veteran Scarred | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Scarred | A+ | 159 | 2.86 m | Day & Night | Like a typical Kobold Tunnel-Queen Veteran, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_06112` | Great Labyrinth (Floors 41-90) Kobold Tunnel-Queen Veteran Albino | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Albino | A+ | 159 | 2.6 m | Day & Night | Like a typical Kobold Tunnel-Queen Veteran, but a rare pale form with white skin or fur and red eyes. |
| `pop_06113` | The Maw Kobold Tunnel-Queen Veteran Alpha | [[Regions/The Maw\|The Maw]] | Alpha | S- | 173 | 3.25 m | Day & Night | Like a typical Kobold Tunnel-Queen Veteran, but larger and scarred, and others of its kind follow it, with bioluminescent spots along its body. |
| `pop_06114` | Great Labyrinth (Floors 41-90) Kobold Tunnel-Queen Veteran Elderborn | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Elderborn | S | 188 | 3.51 m | Day & Night | Like a typical Kobold Tunnel-Queen Veteran, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_06115` | The Maw Kobold Tunnel-Queen Veteran Runt | [[Regions/The Maw\|The Maw]] | Runt | B+ | 120 | 1.82 m | Day & Night | Like a typical Kobold Tunnel-Queen Veteran, but smaller and scrappier than usual, with bioluminescent spots along its body. |
| `pop_06116` | Great Labyrinth (Floors 41-90) Kobold Tunnel-Queen Veteran Alpha | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Alpha | S- | 173 | 3.25 m | Day & Night | Like a typical Kobold Tunnel-Queen Veteran, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_06117` | The Maw Kobold Tunnel-Queen Veteran Albino | [[Regions/The Maw\|The Maw]] | Albino | A+ | 159 | 2.6 m | Day & Night | Like a typical Kobold Tunnel-Queen Veteran, but a rare pale form with white skin or fur and red eyes. |
| `pop_06118` | The Maw Kobold Tunnel-Queen Veteran | [[Regions/The Maw\|The Maw]] | Adult | A | 146 | 2.6 m | Day & Night | A typical adult Kobold Tunnel-Queen Veteran of this region, with bioluminescent spots along its body. |
| `pop_06119` | The Maw Kobold Tunnel-Queen Veteran Scarred | [[Regions/The Maw\|The Maw]] | Scarred | A+ | 159 | 2.86 m | Day & Night | Like a typical Kobold Tunnel-Queen Veteran, but covered in old battle scars, with bioluminescent spots along its body. |
| `pop_06120` | The Maw Kobold Tunnel-Queen Veteran Juvenile | [[Regions/The Maw\|The Maw]] | Juvenile | A- | 132 | 2.21 m | Day & Night | Like a typical Kobold Tunnel-Queen Veteran, but young, with brighter colors and unworn features, with bioluminescent spots along its body. |

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `fur_short` · VFX `rock_debris` · palette `#8b5a2b` `#c2a878` `#4a4a3a` · triangle-based silhouette, sharp asymmetric spikes
