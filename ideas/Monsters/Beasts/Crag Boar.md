---
type: monster
id: mon_crag_boar
family: "Beasts"
rank: "E+"
tier: variant
tags: [monster, beasts]
---
# Crag Boar

![[mon_crag_boar_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_crag_boar_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Crag Boar is a person-sized creature with a long-legged predatory quadruped build, about 1.4 m long. Its coat is weathered and natural, colored in ochre, clay and mossy stone. Survivors describe curved tusks and a ridge of bristles like iron wire. It has amber predator eyes. Small scars and rough edges mark it as a survivor. It stalks low to the ground, surrounded by pebbles that tremble and float near it. Adapted to mountain lands, it has slate-grey coloring and hardened hide.

| Field | Value |
|---|---|
| Family · type | [[Families/Beasts|Beasts]] · Beast |
| Variant of | [[Monsters/Beasts/Wild Boar\|Wild Boar]] (regional) |
| Rank · level | E+ · 32 (26–40) |
| Menace | 2 · Wild |
| Element · weakness | Earth · Wind |
| Size | 1.4 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 2078 · 166 · 138 · 110 · 124 · 100 |
| XP · gold | 776 · 195 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/quad_medium\|quad_medium]] · `anim_quad_large` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Fanghold\|Fanghold]] |
| Genre | Classic Fantasy |
| Trope | The horned rabbit "rookie killer" and wolf packs of every isekai starter forest |

**Field note:** Weak to Wind. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_medium|quad_medium]] (override (base species)); animation set `anim_quad_large`.
- **Dimensions:** 0.94 m high × 1.4 m long × 0.2 m wide; prefab scale 0.933.
- **Physics:** 42.8 kg, gravity ×1.54, poise 38, knockback resistance 0.48, death style `ragdoll_slide`.
- **Navigation:** speed 5.88 m/s, turn 338°/s, stopping distance 0.62 m.
- **Attack count:** 5; **signature:** curved tusks and a ridge of bristles like iron wire.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Maul\|Maul]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Pounce\|Pounce]] | dash | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Howl\|Howl]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Rending Bite\|Rending Bite]] | melee | 1.3 | 5 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Crag Boar is a **wild beast** encountered at E+ rank, around level 32. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** curved tusks and a ridge of bristles like iron wire. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Fanghold|Fanghold]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_large`, animation set `anim_quad_large`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Beasts E|loot_beast_e]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Pelt\|Pelt]] | 60% | 1–3 |
| [[Items/Fang\|Fang]] | 30% | 1–1 |
| [[Items/Prime Meat\|Prime Meat]] | 15% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Fanghold\|Fanghold]] | 6 | D-, D+, E, E-, E+, D | 19–56 | Day & Night |
| [[Regions/Aldmere\|Aldmere]] | 5 | E-, D, D-, D+, E+ | 19–56 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03302` | Fanghold Crag Boar Scarred | [[Regions/Fanghold\|Fanghold]] | Scarred | D- | 40 | 1.54 m | Day & Night | Like a typical Crag Boar, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_03303` | Fanghold Crag Boar Elderborn | [[Regions/Fanghold\|Fanghold]] | Elderborn | D+ | 56 | 1.89 m | Day & Night | Like a typical Crag Boar, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_03304` | Aldmere Crag Boar Runt | [[Regions/Aldmere\|Aldmere]] | Runt | E- | 19 | 0.98 m | Day & Night | Like a typical Crag Boar, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_03305` | Fanghold Crag Boar Juvenile | [[Regions/Fanghold\|Fanghold]] | Juvenile | E | 26 | 1.19 m | Day & Night | Like a typical Crag Boar, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_03306` | Aldmere Crag Boar Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | D | 48 | 1.75 m | Day & Night | Like a typical Crag Boar, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_03307` | Fanghold Crag Boar Runt | [[Regions/Fanghold\|Fanghold]] | Runt | E- | 19 | 0.98 m | Day & Night | Like a typical Crag Boar, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_03308` | Aldmere Crag Boar Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | D- | 40 | 1.54 m | Day & Night | Like a typical Crag Boar, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_03309` | Aldmere Crag Boar Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | D+ | 56 | 1.89 m | Day & Night | Like a typical Crag Boar, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_03310` | Fanghold Crag Boar | [[Regions/Fanghold\|Fanghold]] | Adult | E+ | 32 | 1.4 m | Day & Night | A typical adult Crag Boar of this region, with golden, grass-toned coloring. |
| `pop_03311` | Fanghold Crag Boar Alpha | [[Regions/Fanghold\|Fanghold]] | Alpha | D | 48 | 1.75 m | Day & Night | Like a typical Crag Boar, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_03312` | Aldmere Crag Boar | [[Regions/Aldmere\|Aldmere]] | Adult | E+ | 32 | 1.4 m | Day & Night | A typical adult Crag Boar of this region, with golden, grass-toned coloring. |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `fur_groom` · VFX `rock_debris` · palette `#8b5a2b` `#c2a878` `#4a4a3a` · real-animal silhouette with one fantasy exaggeration
