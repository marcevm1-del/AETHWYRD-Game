---
type: monster
id: mon_rime_wyvern
family: "Dragons"
rank: "B+"
tier: variant
tags: [monster, dragons]
---
# Rime Wyvern

> The Rime Wyvern is a huge creature with a sleek flying build, about 8 m long. Its scales are rough, scarred and spiked, colored in pale blues and frost-white. Its most striking feature is tattered wings and a venom-tipped tail. It has eyes that catch torchlight like coins. Faint runes glow along its body when it fights. It circles its prey, surrounded by falling snow motes and frosted ground where it steps. Adapted to tundra lands, it has a thick, frost-rimed coat.

| Field | Value |
|---|---|
| Family · type | [[Families/Dragons|Dragons]] · Dragon |
| Variant of | [[Monsters/Dragons/Wyvern\|Wyvern]] (regional) |
| Rank · level | B+ · 120 (108–132) |
| Menace | 3 · Menacing |
| Element · weakness | Ice · Fire |
| Size | 8 m |
| Behaviour | Guardian (guardian_hold) |
| HP · ATK · DEF · MATK · MDEF · SPD | 25852 · 588 · 490 · 392 · 441 · 100 |
| XP · gold | 6373 · 1225 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/wyvern\|wyvern]] · `anim_wyvern` |
| Habitats | [[Regions/Whitewater Reach\|Whitewater Reach]], [[Regions/Frostveil\|Frostveil]] |
| Genre | High Fantasy |
| Trope | Dragons as proud, intelligent apex beings; wyverns as their lesser kin |

**Field note:** Weak to Fire. Protects something nearby: a nest, a treasure, or a place.

## Motion implementation

- **Rig:** [[Systems/Rigs/wyvern|wyvern]] (rigId); animation set `anim_wyvern`.
- **Dimensions:** 4 m high × 8 m long × 12.21 m wide; prefab scale 1.333.
- **Physics:** 2590.7 kg, gravity ×1.05, poise 264, knockback resistance 0.92, death style `crash_slide`.
- **Navigation:** speed 5.66 m/s, turn 212°/s, stopping distance 1.04 m.
- **Attack count:** 5; **signature:** tattered wings and a venom-tipped tail.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Talon Rake\|Talon Rake]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Dive Bomb\|Dive Bomb]] | dash | 1.9 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Tail Whip\|Tail Whip]] | aoe | 1.3 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Wing Buffet\|Wing Buffet]] | aoe | 1.1 | 9 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Frost Breath\|Frost Breath]] | magic | 1.5 | 10 s | Ice | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Rime Wyvern is a **menacing dragon** encountered at B+ rank, around level 120. Its documented behaviour is *Guardian* and its AI pattern is *guardian_hold*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** tattered wings and a venom-tipped tail. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Whitewater Reach|Whitewater Reach]], [[Regions/Frostveil|Frostveil]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_wyvern`, animation set `anim_wyvern`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Dragons B|loot_draconic_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Dragon Scale\|Dragon Scale]] | 60% | 1–3 |
| [[Items/Dragon Blood\|Dragon Blood]] | 30% | 1–1 |
| [[Items/Dragon Heart\|Dragon Heart]] | 15% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Whitewater Reach\|Whitewater Reach]] | 6 | A-, B-, B, A, A+ | 96–159 | Day & Night |
| [[Regions/Frostveil\|Frostveil]] | 5 | B, A-, A, A+ | 108–159 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04274` | Whitewater Reach Rime Wyvern Albino | [[Regions/Whitewater Reach\|Whitewater Reach]] | Albino | A- | 132 | 8 m | Day & Night | Like a typical Rime Wyvern, but a rare pale form with white skin or fur and red eyes. |
| `pop_04275` | Whitewater Reach Rime Wyvern Runt | [[Regions/Whitewater Reach\|Whitewater Reach]] | Runt | B- | 96 | 5.6 m | Day & Night | Like a typical Rime Wyvern, but smaller and scrappier than usual, with a thick, frost-rimed coat. |
| `pop_04276` | Frostveil Rime Wyvern Juvenile | [[Regions/Frostveil\|Frostveil]] | Juvenile | B | 108 | 6.8 m | Day & Night | Like a typical Rime Wyvern, but young, with brighter colors and unworn features, with a thick, frost-rimed coat. |
| `pop_04277` | Whitewater Reach Rime Wyvern Juvenile | [[Regions/Whitewater Reach\|Whitewater Reach]] | Juvenile | B | 108 | 6.8 m | Day & Night | Like a typical Rime Wyvern, but young, with brighter colors and unworn features, with a thick, frost-rimed coat. |
| `pop_04278` | Frostveil Rime Wyvern Scarred | [[Regions/Frostveil\|Frostveil]] | Scarred | A- | 132 | 8.8 m | Day & Night | Like a typical Rime Wyvern, but covered in old battle scars, with a thick, frost-rimed coat. |
| `pop_04279` | Frostveil Rime Wyvern Alpha | [[Regions/Frostveil\|Frostveil]] | Alpha | A | 146 | 10 m | Day & Night | Like a typical Rime Wyvern, but larger and scarred, and others of its kind follow it, with a thick, frost-rimed coat. |
| `pop_04280` | Frostveil Rime Wyvern Elderborn | [[Regions/Frostveil\|Frostveil]] | Elderborn | A+ | 159 | 10.8 m | Day & Night | Like a typical Rime Wyvern, but old and wise, with greying features and a cautious hunting style, with a thick, frost-rimed coat. |
| `pop_04281` | Frostveil Rime Wyvern Albino | [[Regions/Frostveil\|Frostveil]] | Albino | A- | 132 | 8 m | Day & Night | Like a typical Rime Wyvern, but a rare pale form with white skin or fur and red eyes. |
| `pop_04282` | Whitewater Reach Rime Wyvern Alpha | [[Regions/Whitewater Reach\|Whitewater Reach]] | Alpha | A | 146 | 10 m | Day & Night | Like a typical Rime Wyvern, but larger and scarred, and others of its kind follow it, with a thick, frost-rimed coat. |
| `pop_04283` | Whitewater Reach Rime Wyvern Elderborn | [[Regions/Whitewater Reach\|Whitewater Reach]] | Elderborn | A+ | 159 | 10.8 m | Day & Night | Like a typical Rime Wyvern, but old and wise, with greying features and a cautious hunting style, with a thick, frost-rimed coat. |
| `pop_04284` | Whitewater Reach Rime Wyvern Scarred | [[Regions/Whitewater Reach\|Whitewater Reach]] | Scarred | A- | 132 | 8.8 m | Day & Night | Like a typical Rime Wyvern, but covered in old battle scars, with a thick, frost-rimed coat. |

## Design recipe

Rig `rig_wyvern` · mesh `wyvern_base` · material `dragon_scale` · VFX `frost_trail_snow` · palette `#bfe9ff` `#5fa8d3` `#f4fbff` · triangle-based silhouette, sharp asymmetric spikes
