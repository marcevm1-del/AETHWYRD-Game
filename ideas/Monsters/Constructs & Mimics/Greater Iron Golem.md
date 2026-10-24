---
type: monster
id: mon_greater_iron_golem
family: "Constructs & Mimics"
rank: "A"
tier: variant
tags: [monster, constructs-mimics]
---
# Greater Iron Golem

> The Greater Iron Golem is a huge creature with a heavy, hand-built humanoid shell, about 6.4 m tall. Its surface is weathered and natural, colored in ochre, clay and mossy stone. Survivors describe riveted iron and a furnace heart. It has amber predator eyes. An elegant crest and glowing veins of mana mark it as a champion of its kind. It stalks low to the ground, surrounded by pebbles that tremble and float near it. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Constructs & Mimics|Constructs & Mimics]] · Construct |
| Variant of | [[Monsters/Constructs & Mimics/Iron Golem\|Iron Golem]] (elder) |
| Rank · level | A · 146 (132–159) |
| Menace | 2 · Wild |
| Element · weakness | Earth · Wind |
| Size | 6.4 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 41263 · 594 · 891 · 356 · 594 · 70 |
| XP · gold | 8719 · 1611 |
| Ring | 7 |
| Rig · animation | [[Systems/Rigs/golem\|golem]] · `anim_golem` |
| Habitats | [[Regions/Zarvan\|Zarvan]], [[Regions/Sunscar\|Sunscar]], [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] |
| Genre | Ancient Ruins |
| Trope | Treasure-chest mimics and ancient guardian golems |

**Field note:** Weak to Wind. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/golem|golem]] (rigId); animation set `anim_golem`.
- **Dimensions:** 6.4 m high × 1.92 m long × 2.69 m wide; prefab scale 2.133.
- **Physics:** 16357.8 kg, gravity ×1.32, poise 511, knockback resistance 1, death style `crumble_into_rubble`.
- **Navigation:** speed 4.23 m/s, turn 79°/s, stopping distance 1.81 m.
- **Attack count:** 5; **signature:** riveted iron and a furnace heart.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slam\|Slam]] | melee | 1.4 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Ground Pound\|Ground Pound]] | aoe | 1.8 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Stance\|Guard Stance]] | buff | 0 | 15 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Rune Pulse\|Rune Pulse]] | magic | 1.3 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Greater Iron Golem is a **wild construct** encountered at A rank, around level 146. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** riveted iron and a furnace heart. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Zarvan|Zarvan]], [[Regions/Sunscar|Sunscar]], [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_golem`, animation set `anim_golem`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Constructs & Mimics A|loot_construct_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Golem Core\|Golem Core]] | 60% | 1–3 |
| [[Items/Rune Plate\|Rune Plate]] | 30% | 1–1 |
| [[Items/Gear\|Gear]] | 15% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Zarvan\|Zarvan]] | 3 | A-, S-, A+ | 132–173 | Day & Night |
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 5 | S-, A+, B+, S, A- | 120–188 | Day & Night |
| [[Regions/Sunscar\|Sunscar]] | 3 | A, A+, S- | 146–173 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04396` | Zarvan Greater Iron Golem Juvenile | [[Regions/Zarvan\|Zarvan]] | Juvenile | A- | 132 | 5.44 m | Day & Night | Like a typical Greater Iron Golem, but young, with brighter colors and unworn features, with sun-bleached, sand-scoured coloring. |
| `pop_04397` | Great Labyrinth (Floors 41-90) Greater Iron Golem Alpha | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Alpha | S- | 173 | 8 m | Day & Night | Like a typical Greater Iron Golem, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_04398` | Zarvan Greater Iron Golem Alpha | [[Regions/Zarvan\|Zarvan]] | Alpha | S- | 173 | 8 m | Day & Night | Like a typical Greater Iron Golem, but larger and scarred, and others of its kind follow it, with sun-bleached, sand-scoured coloring. |
| `pop_04399` | Sunscar Greater Iron Golem | [[Regions/Sunscar\|Sunscar]] | Adult | A | 146 | 6.4 m | Day & Night | A typical adult Greater Iron Golem of this region, with sun-bleached, sand-scoured coloring. |
| `pop_04400` | Sunscar Greater Iron Golem Albino | [[Regions/Sunscar\|Sunscar]] | Albino | A+ | 159 | 6.4 m | Day & Night | Like a typical Greater Iron Golem, but a rare pale form with white skin or fur and red eyes. |
| `pop_04401` | Sunscar Greater Iron Golem Alpha | [[Regions/Sunscar\|Sunscar]] | Alpha | S- | 173 | 8 m | Day & Night | Like a typical Greater Iron Golem, but larger and scarred, and others of its kind follow it, with sun-bleached, sand-scoured coloring. |
| `pop_04402` | Great Labyrinth (Floors 41-90) Greater Iron Golem Albino | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Albino | A+ | 159 | 6.4 m | Day & Night | Like a typical Greater Iron Golem, but a rare pale form with white skin or fur and red eyes. |
| `pop_04403` | Great Labyrinth (Floors 41-90) Greater Iron Golem Runt | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Runt | B+ | 120 | 4.48 m | Day & Night | Like a typical Greater Iron Golem, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_04404` | Zarvan Greater Iron Golem Scarred | [[Regions/Zarvan\|Zarvan]] | Scarred | A+ | 159 | 7.04 m | Day & Night | Like a typical Greater Iron Golem, but covered in old battle scars, with sun-bleached, sand-scoured coloring. |
| `pop_04405` | Great Labyrinth (Floors 41-90) Greater Iron Golem Elderborn | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Elderborn | S | 188 | 8.64 m | Day & Night | Like a typical Greater Iron Golem, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_04406` | Great Labyrinth (Floors 41-90) Greater Iron Golem Juvenile | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Juvenile | A- | 132 | 5.44 m | Day & Night | Like a typical Greater Iron Golem, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |

## Design recipe

Rig `rig_golem` · mesh `golem_base` · material `stone_metal_runes` · VFX `rock_debris` · palette `#8b5a2b` `#c2a878` `#4a4a3a` · real-animal silhouette with one fantasy exaggeration
