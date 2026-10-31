---
type: monster
id: mon_ancient_kobold_packleader
family: "Kobolds"
rank: "C+"
tier: variant
tags: [monster, kobolds]
---
# Ancient Kobold Packleader

![[mon_ancient_kobold_packleader_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_ancient_kobold_packleader_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,540 tris · 0.889 × 0.902 × 1.8 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Ancient Kobold Packleader is a person-sized creature with a hunched, wiry humanoid frame, about 1.8 m tall. Its mangy fur is rough, scarred and spiked, colored in slate-blue. Survivors describe a collar of teeth from rival packs. It has eyes that catch torchlight like coins. Battle-worn plates and trophies hang from its body. It strides with heavy steps. It has no visible aura; you hear its breathing before you see it. Moss, crystals and centuries-old scars cover its body; it has outlived every hunter sent after it.

| Field | Value |
|---|---|
| Family · type | [[Families/Kobolds|Kobolds]] · Humanoid |
| Variant of | [[Monsters/Kobolds/Kobold Packleader\|Kobold Packleader]] (ancient) |
| Rank · level | C+ · 86 (76–96) |
| Menace | 3 · Menacing |
| Element · weakness | None · Fire |
| Size | 1.8 m |
| Behaviour | Pack (pack_flank) |
| HP · ATK · DEF · MATK · MDEF · SPD | 7496 · 354 · 283 · 173 · 283 · 135 |
| XP · gold | 3743 · 769 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/small_biped\|small_biped]] · `anim_small_biped` |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] |
| Genre | Dungeon Crawl |
| Trope | Dog-headed first-floor monsters (DanMachi), trap-builders (classic tabletop) |

**Field note:** Weak to Fire. Never alone. Kill the leader first and the rest may scatter.

## Motion implementation

- **Rig:** [[Systems/Rigs/small_biped|small_biped]] (rigId); animation set `anim_small_biped`.
- **Dimensions:** 1.8 m high × 0.54 m long × 0.72 m wide; prefab scale 1.636.
- **Physics:** 93.3 kg, gravity ×1.5, poise 56, knockback resistance 0.24, death style `ragdoll_crumple`.
- **Navigation:** speed 6.81 m/s, turn 313°/s, stopping distance 0.76 m.
- **Attack count:** 4; **signature:** a collar of teeth from rival packs.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stab\|Stab]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Thrown Junk\|Thrown Junk]] | ranged | 0.8 | 4 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Frenzied Lunge\|Frenzied Lunge]] | melee | 1.5 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Trip-Wire Trap\|Trip-Wire Trap]] | debuff | 0 | 14 s | None | none | Keep moving and read the animation; do not assume a safe block. |

## Field guide

Ancient Kobold Packleader is a **menacing humanoid** encountered at C+ rank, around level 86. Its documented behaviour is *Pack* and its AI pattern is *pack_flank*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a collar of teeth from rival packs. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_small_biped`, animation set `anim_small_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Kobolds C|loot_kobold_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Kobold Fang\|Kobold Fang]] | 60% | 1–3 |
| [[Items/Scrap Metal\|Scrap Metal]] | 30% | 1–1 |
| [[Items/Candle Stub\|Candle Stub]] | 15% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 5 | B-, C+, B, C- | 65–108 | Day & Night |
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 6 | B-, B, C, C-, C+ | 65–108 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06088` | Great Labyrinth (Floors 1-40) Ancient Kobold Packleader Scarred | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Scarred | B- | 96 | 1.98 m | Day & Night | Like a typical Ancient Kobold Packleader, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_06089` | Great Labyrinth (Floors 41-90) Ancient Kobold Packleader Scarred | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Scarred | B- | 96 | 1.98 m | Day & Night | Like a typical Ancient Kobold Packleader, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_06090` | Great Labyrinth (Floors 41-90) Ancient Kobold Packleader Alpha | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Alpha | B | 108 | 2.25 m | Day & Night | Like a typical Ancient Kobold Packleader, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_06091` | Great Labyrinth (Floors 1-40) Ancient Kobold Packleader | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Adult | C+ | 86 | 1.8 m | Day & Night | A typical adult Ancient Kobold Packleader of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_06092` | Great Labyrinth (Floors 41-90) Ancient Kobold Packleader Juvenile | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Juvenile | C | 76 | 1.53 m | Day & Night | Like a typical Ancient Kobold Packleader, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_06093` | Great Labyrinth (Floors 1-40) Ancient Kobold Packleader Albino | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Albino | B- | 96 | 1.8 m | Day & Night | Like a typical Ancient Kobold Packleader, but a rare pale form with white skin or fur and red eyes. |
| `pop_06094` | Great Labyrinth (Floors 41-90) Ancient Kobold Packleader Runt | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Runt | C- | 65 | 1.26 m | Day & Night | Like a typical Ancient Kobold Packleader, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_06095` | Great Labyrinth (Floors 41-90) Ancient Kobold Packleader Albino | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Albino | B- | 96 | 1.8 m | Day & Night | Like a typical Ancient Kobold Packleader, but a rare pale form with white skin or fur and red eyes. |
| `pop_06096` | Great Labyrinth (Floors 1-40) Ancient Kobold Packleader Alpha | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Alpha | B | 108 | 2.25 m | Day & Night | Like a typical Ancient Kobold Packleader, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_06097` | Great Labyrinth (Floors 1-40) Ancient Kobold Packleader Runt | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Runt | C- | 65 | 1.26 m | Day & Night | Like a typical Ancient Kobold Packleader, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_06098` | Great Labyrinth (Floors 41-90) Ancient Kobold Packleader | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Adult | C+ | 86 | 1.8 m | Day & Night | A typical adult Ancient Kobold Packleader of this region, with pale, light-starved coloring and oversized eyes. |

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `fur_short` · VFX `dust_puffs` · palette `#5f8499` `#3e5666` `#8ab1de` · triangle-based silhouette, sharp asymmetric spikes
