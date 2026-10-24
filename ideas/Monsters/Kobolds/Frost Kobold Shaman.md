---
type: monster
id: mon_frost_kobold_shaman
family: "Kobolds"
rank: "D+"
tier: variant
tags: [monster, kobolds]
---
# Frost Kobold Shaman

> The Frost Kobold Shaman is a small creature with a scrawny biped with long arms and bowed legs, about 0.9 m tall. Its mangy fur is rough, scarred and spiked, colored in pale blues and frost-white. Look for tin-can wind chimes and singed whiskers. It has narrow glowing eyes. A distinctive marking runs along its back. It strides with heavy steps, surrounded by falling snow motes and frosted ground where it steps. This Ice-attuned variant carries one extra elemental feature, like element-scarred hide, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Kobolds|Kobolds]] · Humanoid |
| Variant of | [[Monsters/Kobolds/Kobold Shaman\|Kobold Shaman]] (elemental) |
| Rank · level | D+ · 56 (48–65) |
| Menace | 3 · Menacing |
| Element · weakness | Ice · Fire |
| Size | 0.9 m |
| Behaviour | Pack (pack_flank) |
| HP · ATK · DEF · MATK · MDEF · SPD | 3148 · 234 · 187 · 164 · 187 · 135 |
| XP · gold | 1888 · 423 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/small_biped\|small_biped]] · `anim_small_biped` |
| Habitats | [[Regions/Iron Hold\|Iron Hold]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Hoshizora\|Hoshizora]] |
| Genre | Dungeon Crawl |
| Trope | Dog-headed first-floor monsters (DanMachi), trap-builders (classic tabletop) |

**Field note:** Weak to Fire. Never alone. Kill the leader first and the rest may scatter.

## Motion implementation

- **Rig:** [[Systems/Rigs/small_biped|small_biped]] (rigId); animation set `anim_small_biped`.
- **Dimensions:** 0.9 m high × 0.27 m long × 0.36 m wide; prefab scale 0.818.
- **Physics:** 12.8 kg, gravity ×1.58, poise 35, knockback resistance 0.21, death style `ragdoll_crumple`.
- **Navigation:** speed 4.43 m/s, turn 443°/s, stopping distance 0.58 m.
- **Attack count:** 5; **signature:** tin-can wind chimes and singed whiskers.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stab\|Stab]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Thrown Junk\|Thrown Junk]] | ranged | 0.8 | 4 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Frenzied Lunge\|Frenzied Lunge]] | melee | 1.5 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Trip-Wire Trap\|Trip-Wire Trap]] | debuff | 0 | 14 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Frost Breath\|Frost Breath]] | magic | 1.5 | 10 s | Ice | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Frost Kobold Shaman is a **menacing humanoid** encountered at D+ rank, around level 56. Its documented behaviour is *Pack* and its AI pattern is *pack_flank*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** tin-can wind chimes and singed whiskers. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Iron Hold|Iron Hold]], [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Hoshizora|Hoshizora]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_small_biped`, animation set `anim_small_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Kobolds D|loot_kobold_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Kobold Fang\|Kobold Fang]] | 60% | 1–3 |
| [[Items/Scrap Metal\|Scrap Metal]] | 30% | 1–1 |
| [[Items/Candle Stub\|Candle Stub]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Hoshizora\|Hoshizora]] | 5 | C-, D, C+, C | 48–86 | Day & Night |
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 2 | C+, D | 48–86 | Day & Night |
| [[Regions/Iron Hold\|Iron Hold]] | 4 | C-, D, D+, D- | 40–65 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06066` | Hoshizora Frost Kobold Shaman Scarred | [[Regions/Hoshizora\|Hoshizora]] | Scarred | C- | 65 | 0.99 m | Day & Night | Like a typical Frost Kobold Shaman, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_06067` | Great Labyrinth (Floors 1-40) Frost Kobold Shaman Elderborn | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Elderborn | C+ | 86 | 1.22 m | Day & Night | Like a typical Frost Kobold Shaman, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_06068` | Iron Hold Frost Kobold Shaman Scarred | [[Regions/Iron Hold\|Iron Hold]] | Scarred | C- | 65 | 0.99 m | Day & Night | Like a typical Frost Kobold Shaman, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_06069` | Hoshizora Frost Kobold Shaman Juvenile | [[Regions/Hoshizora\|Hoshizora]] | Juvenile | D | 48 | 0.77 m | Day & Night | Like a typical Frost Kobold Shaman, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_06070` | Hoshizora Frost Kobold Shaman Elderborn | [[Regions/Hoshizora\|Hoshizora]] | Elderborn | C+ | 86 | 1.22 m | Day & Night | Like a typical Frost Kobold Shaman, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_06071` | Hoshizora Frost Kobold Shaman Alpha | [[Regions/Hoshizora\|Hoshizora]] | Alpha | C | 76 | 1.13 m | Day & Night | Like a typical Frost Kobold Shaman, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_06072` | Iron Hold Frost Kobold Shaman Juvenile | [[Regions/Iron Hold\|Iron Hold]] | Juvenile | D | 48 | 0.77 m | Day & Night | Like a typical Frost Kobold Shaman, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_06073` | Iron Hold Frost Kobold Shaman | [[Regions/Iron Hold\|Iron Hold]] | Adult | D+ | 56 | 0.9 m | Day & Night | A typical adult Frost Kobold Shaman of this region, with slate-grey coloring and hardened hide. |
| `pop_06074` | Iron Hold Frost Kobold Shaman Runt | [[Regions/Iron Hold\|Iron Hold]] | Runt | D- | 40 | 0.63 m | Day & Night | Like a typical Frost Kobold Shaman, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_06075` | Hoshizora Frost Kobold Shaman Albino | [[Regions/Hoshizora\|Hoshizora]] | Albino | C- | 65 | 0.9 m | Day & Night | Like a typical Frost Kobold Shaman, but a rare pale form with white skin or fur and red eyes. |
| `pop_06076` | Great Labyrinth (Floors 1-40) Frost Kobold Shaman Juvenile | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Juvenile | D | 48 | 0.77 m | Day & Night | Like a typical Frost Kobold Shaman, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `fur_short` · VFX `frost_trail_snow` · palette `#bfe9ff` `#5fa8d3` `#f4fbff` · triangle-based silhouette, sharp asymmetric spikes
