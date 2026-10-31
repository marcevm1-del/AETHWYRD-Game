---
type: monster
id: mon_greater_basilisk
family: "Reptiles"
rank: "B"
tier: variant
tags: [monster, reptiles]
---
# Greater Basilisk

![[mon_greater_basilisk_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_greater_basilisk_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,824 tris · 2.208 × 6.4 × 7.033 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Greater Basilisk is a huge creature with a long-legged predatory quadruped build, about 6.4 m long. Its scales are patchy and subtly wrong, as if assembled from memory, colored in teal-grey, with ochre markings. Look for a crown of horns and eyes that petrify. It has eyes that never blink. Faint runes glow along its body when it fights. It glides without moving its legs, surrounded by pebbles that tremble and float near it. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Reptiles|Reptiles]] · Reptile |
| Variant of | [[Monsters/Reptiles/Basilisk\|Basilisk]] (elder) |
| Rank · level | B · 108 (96–120) |
| Menace | 4 · Dread |
| Element · weakness | Earth · Wind |
| Size | 6.4 m |
| Behaviour | Territorial (territorial_guard+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 20671 · 530 · 442 · 354 · 398 · 100 |
| XP · gold | 5386 · 1057 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/quad_large\|quad_large]] · `anim_quad_large` |
| Habitats | [[Regions/Dunewhale Drift\|Dunewhale Drift]], [[Regions/Zarvan\|Zarvan]], [[Regions/Zaruma\|Zaruma]] |
| Genre | Classic Fantasy |
| Trope | Lizardmen as a proud people; the petrifying basilisk |

**Field note:** Weak to Wind. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_large|quad_large]] (rigId); animation set `anim_quad_large`.
- **Dimensions:** 4.16 m high × 6.4 m long × 1.02 m wide; prefab scale 1.6.
- **Physics:** 6815.7 kg, gravity ×1.32, poise 142, knockback resistance 1, death style `heavy_fall_dust`.
- **Navigation:** speed 8.56 m/s, turn 126°/s, stopping distance 1.68 m.
- **Attack count:** 5; **signature:** a crown of horns and eyes that petrify.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Maul\|Maul]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Pounce\|Pounce]] | dash | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Howl\|Howl]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Tail Lash\|Tail Lash]] | aoe | 1.2 | 7 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Greater Basilisk is a **dread reptile** encountered at B rank, around level 108. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a crown of horns and eyes that petrify. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Dunewhale Drift|Dunewhale Drift]], [[Regions/Zarvan|Zarvan]], [[Regions/Zaruma|Zaruma]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_large`, animation set `anim_quad_large`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Reptiles B|loot_reptile_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Scale\|Scale]] | 60% | 1–3 |
| [[Items/Reptile Eye\|Reptile Eye]] | 30% | 1–1 |
| [[Items/Tail Meat\|Tail Meat]] | 15% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Zarvan\|Zarvan]] | 5 | B, A-, B+, C+ | 86–132 | Night |
| [[Regions/Zaruma\|Zaruma]] | 3 | B, B-, A | 96–146 | Night |
| [[Regions/Dunewhale Drift\|Dunewhale Drift]] | 3 | B, A, A- | 108–146 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04175` | Zarvan Greater Basilisk | [[Regions/Zarvan\|Zarvan]] | Adult | B | 108 | 6.4 m | Night | A typical adult Greater Basilisk of this region, with sun-bleached, sand-scoured coloring. |
| `pop_04176` | Zaruma Greater Basilisk | [[Regions/Zaruma\|Zaruma]] | Adult | B | 108 | 6.4 m | Night | A typical adult Greater Basilisk of this region, with sun-bleached, sand-scoured coloring. |
| `pop_04177` | Zaruma Greater Basilisk Juvenile | [[Regions/Zaruma\|Zaruma]] | Juvenile | B- | 96 | 5.44 m | Night | Like a typical Greater Basilisk, but young, with brighter colors and unworn features, with sun-bleached, sand-scoured coloring. |
| `pop_04178` | Zarvan Greater Basilisk Alpha | [[Regions/Zarvan\|Zarvan]] | Alpha | A- | 132 | 8 m | Night | Like a typical Greater Basilisk, but larger and scarred, and others of its kind follow it, with sun-bleached, sand-scoured coloring. |
| `pop_04179` | Zarvan Greater Basilisk Albino | [[Regions/Zarvan\|Zarvan]] | Albino | B+ | 120 | 6.4 m | Night | Like a typical Greater Basilisk, but a rare pale form with white skin or fur and red eyes. |
| `pop_04180` | Dunewhale Drift Greater Basilisk | [[Regions/Dunewhale Drift\|Dunewhale Drift]] | Adult | B | 108 | 6.4 m | Night | A typical adult Greater Basilisk of this region, with sun-bleached, sand-scoured coloring. |
| `pop_04181` | Zarvan Greater Basilisk Runt | [[Regions/Zarvan\|Zarvan]] | Runt | C+ | 86 | 4.48 m | Night | Like a typical Greater Basilisk, but smaller and scrappier than usual, with sun-bleached, sand-scoured coloring. |
| `pop_04182` | Dunewhale Drift Greater Basilisk Elderborn | [[Regions/Dunewhale Drift\|Dunewhale Drift]] | Elderborn | A | 146 | 8.64 m | Night | Like a typical Greater Basilisk, but old and wise, with greying features and a cautious hunting style, with sun-bleached, sand-scoured coloring. |
| `pop_04183` | Dunewhale Drift Greater Basilisk Alpha | [[Regions/Dunewhale Drift\|Dunewhale Drift]] | Alpha | A- | 132 | 8 m | Night | Like a typical Greater Basilisk, but larger and scarred, and others of its kind follow it, with sun-bleached, sand-scoured coloring. |
| `pop_04184` | Zaruma Greater Basilisk Elderborn | [[Regions/Zaruma\|Zaruma]] | Elderborn | A | 146 | 8.64 m | Night | Like a typical Greater Basilisk, but old and wise, with greying features and a cautious hunting style, with sun-bleached, sand-scoured coloring. |
| `pop_04185` | Zarvan Greater Basilisk Scarred | [[Regions/Zarvan\|Zarvan]] | Scarred | B+ | 120 | 7.04 m | Night | Like a typical Greater Basilisk, but covered in old battle scars, with sun-bleached, sand-scoured coloring. |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `scale_matte` · VFX `rock_debris` · palette `#486577` `#334754` `#d1a15a` · elongated, irregular silhouette; still-then-sudden timing
