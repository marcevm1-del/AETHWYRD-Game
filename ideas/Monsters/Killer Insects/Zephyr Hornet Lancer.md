---
type: monster
id: mon_zephyr_hornet_lancer
family: "Killer Insects"
rank: "D+"
tier: variant
tags: [monster, killer-insects]
---
# Zephyr Hornet Lancer

> The Zephyr Hornet Lancer is a person-sized creature with a tiny, darting winged build, about 1.2 m tall. Its chitin is rough, scarred and spiked, colored in pale jade and cloud white. Its most striking feature is a lance-like stinger and humming armored wings. It has narrow glowing eyes. A distinctive marking runs along its back. It strides with heavy steps, surrounded by swirling leaves and a constant breeze. This Wind-attuned variant carries one extra elemental feature, like glowing vein-lines, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Killer Insects|Killer Insects]] · Insectoid |
| Variant of | [[Monsters/Killer Insects/Hornet Lancer\|Hornet Lancer]] (elemental) |
| Rank · level | D+ · 56 (48–65) |
| Menace | 3 · Menacing |
| Element · weakness | Wind · Fire |
| Size | 1.2 m |
| Behaviour | Swarm (swarm_surround) |
| HP · ATK · DEF · MATK · MDEF · SPD | 3458 · 234 · 187 · 164 · 187 · 135 |
| XP · gold | 1888 · 423 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/hexapod\|hexapod]] · `anim_flyer_small` |
| Habitats | [[Regions/Moraveil\|Moraveil]], [[Regions/Iron Hold\|Iron Hold]] |
| Genre | Dungeon Crawl |
| Trope | The rookie-killing ants of the early dungeon floors (DanMachi) |

**Field note:** Weak to Fire. Dangerous in numbers. Area attacks and chokepoints help.

## Motion implementation

- **Rig:** [[Systems/Rigs/hexapod|hexapod]] (keyword); animation set `anim_flyer_small`.
- **Dimensions:** 0.4 m high × 1.2 m long × 0.61 m wide; prefab scale 1.5.
- **Physics:** 68.4 kg, gravity ×1.12, poise 64, knockback resistance 0.31, death style `flip_legs_curl`.
- **Navigation:** speed 4.48 m/s, turn 456°/s, stopping distance 0.57 m.
- **Attack count:** 5; **signature:** a lance-like stinger and humming armored wings.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Nip\|Nip]] | melee | 0.9 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Dart\|Dart]] | dash | 1.1 | 4 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Swarm Call\|Swarm Call]] | summon | 0 | 20 s | None | none | Interrupt or reposition; watch for added enemies. |
| [[Attacks/Swarm Bite\|Swarm Bite]] | aoe | 0.9 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Gale Cutter\|Gale Cutter]] | magic | 1.5 | 10 s | Wind | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Zephyr Hornet Lancer is a **menacing insectoid** encountered at D+ rank, around level 56. Its documented behaviour is *Swarm* and its AI pattern is *swarm_surround*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a lance-like stinger and humming armored wings. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Moraveil|Moraveil]], [[Regions/Iron Hold|Iron Hold]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_flyer_small`, animation set `anim_flyer_small`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Killer Insects D|loot_killer_insect_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Killer Mandible\|Killer Mandible]] | 60% | 1–3 |
| [[Items/Stinger\|Stinger]] | 30% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Moraveil\|Moraveil]] | 6 | D+, C-, D, D-, C+ | 40–86 | Day & Night |
| [[Regions/Iron Hold\|Iron Hold]] | 5 | C, C-, D-, D, C+ | 40–86 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06495` | Moraveil Zephyr Hornet Lancer | [[Regions/Moraveil\|Moraveil]] | Adult | D+ | 56 | 1.2 m | Day & Night | A typical adult Zephyr Hornet Lancer of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_06496` | Iron Hold Zephyr Hornet Lancer Alpha | [[Regions/Iron Hold\|Iron Hold]] | Alpha | C | 76 | 1.5 m | Day & Night | Like a typical Zephyr Hornet Lancer, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_06497` | Moraveil Zephyr Hornet Lancer Scarred | [[Regions/Moraveil\|Moraveil]] | Scarred | C- | 65 | 1.32 m | Day & Night | Like a typical Zephyr Hornet Lancer, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_06498` | Moraveil Zephyr Hornet Lancer Juvenile | [[Regions/Moraveil\|Moraveil]] | Juvenile | D | 48 | 1.02 m | Day & Night | Like a typical Zephyr Hornet Lancer, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_06499` | Moraveil Zephyr Hornet Lancer Albino | [[Regions/Moraveil\|Moraveil]] | Albino | C- | 65 | 1.2 m | Day & Night | Like a typical Zephyr Hornet Lancer, but a rare pale form with white skin or fur and red eyes. |
| `pop_06500` | Iron Hold Zephyr Hornet Lancer Scarred | [[Regions/Iron Hold\|Iron Hold]] | Scarred | C- | 65 | 1.32 m | Day & Night | Like a typical Zephyr Hornet Lancer, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_06501` | Moraveil Zephyr Hornet Lancer Runt | [[Regions/Moraveil\|Moraveil]] | Runt | D- | 40 | 0.84 m | Day & Night | Like a typical Zephyr Hornet Lancer, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_06502` | Iron Hold Zephyr Hornet Lancer Runt | [[Regions/Iron Hold\|Iron Hold]] | Runt | D- | 40 | 0.84 m | Day & Night | Like a typical Zephyr Hornet Lancer, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_06503` | Moraveil Zephyr Hornet Lancer Elderborn | [[Regions/Moraveil\|Moraveil]] | Elderborn | C+ | 86 | 1.62 m | Day & Night | Like a typical Zephyr Hornet Lancer, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_06504` | Iron Hold Zephyr Hornet Lancer Juvenile | [[Regions/Iron Hold\|Iron Hold]] | Juvenile | D | 48 | 1.02 m | Day & Night | Like a typical Zephyr Hornet Lancer, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_06505` | Iron Hold Zephyr Hornet Lancer Elderborn | [[Regions/Iron Hold\|Iron Hold]] | Elderborn | C+ | 86 | 1.62 m | Day & Night | Like a typical Zephyr Hornet Lancer, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |

## Design recipe

Rig `rig_flyer_small` · mesh `flyer_small_base` · material `chitin_matte` · VFX `wind_ribbons` · palette `#a8e6cf` `#dcedc1` `#5b8c85` · triangle-based silhouette, sharp asymmetric spikes
