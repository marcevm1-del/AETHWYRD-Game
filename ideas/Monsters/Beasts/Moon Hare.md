---
type: monster
id: mon_moon_hare
family: "Beasts"
rank: "D"
tier: core
tags: [monster, beasts]
---
# Moon Hare

![[mon_moon_hare_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_moon_hare_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 6,000 tris · 0.162 × 0.5 × 0.375 m · local file `Game/Assets/_Game/Art/Models/Monsters/Beasts/mon_moon_hare.fbx`

> The Moon Hare is a small creature with a low, springy quadruped build, about 0.5 m long. Its coat is smooth and clean, colored in cream, with gold markings. Survivors describe white fur that glows under the full moon. It has two bright dot eyes. A distinctive marking runs along its back. It bounces happily, surrounded by soft radiance and floating motes of light.

| Field | Value |
|---|---|
| Family · type | [[Families/Beasts|Beasts]] · Beast |
| Rank · level | D · 48 (40–56) |
| Menace | 1 · Charming |
| Element · weakness | Light · Dark |
| Size | 0.5 m |
| Behaviour | Pack (pack_flank) |
| HP · ATK · DEF · MATK · MDEF · SPD | 2110 · 202 · 162 · 141 · 162 · 135 |
| XP · gold | 1477 · 342 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/quad_small\|quad_small]] · `anim_quad_small` |
| Habitats | [[Regions/Hoshizora\|Hoshizora]], [[Regions/Kitsune Isles\|Kitsune Isles]], [[Regions/Fanghold\|Fanghold]] |
| Genre | Classic Fantasy |
| Trope | The horned rabbit "rookie killer" and wolf packs of every isekai starter forest |

**Field note:** Weak to Dark. Never alone. Kill the leader first and the rest may scatter.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_small|quad_small]] (rigId); animation set `anim_quad_small`.
- **Dimensions:** 0.34 m high × 0.5 m long × 0.07 m wide; prefab scale 1.
- **Physics:** 3.6 kg, gravity ×1.44, poise 26, knockback resistance 0.11, death style `ragdoll_tumble`.
- **Navigation:** speed 5.64 m/s, turn 764°/s, stopping distance 0.5 m.
- **Attack count:** 5; **signature:** white fur that glows under the full moon.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Bite\|Bite]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Charge\|Charge]] | dash | 1.3 | 5 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Leap\|Leap]] | dash | 1.2 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Rending Bite\|Rending Bite]] | melee | 1.3 | 5 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Radiant Pulse\|Radiant Pulse]] | magic | 1.5 | 10 s | Light | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Moon Hare is a **charming beast** encountered at D rank, around level 48. Its documented behaviour is *Pack* and its AI pattern is *pack_flank*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Dark**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** white fur that glows under the full moon. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Hoshizora|Hoshizora]], [[Regions/Kitsune Isles|Kitsune Isles]], [[Regions/Fanghold|Fanghold]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_small`, animation set `anim_quad_small`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Beasts D|loot_beast_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Pelt\|Pelt]] | 60% | 1–3 |
| [[Items/Fang\|Fang]] | 30% | 1–1 |
| [[Items/Prime Meat\|Prime Meat]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Beasts/Phantom Moon Hare|Phantom Moon Hare]]
- [[Monsters/Beasts/Elder Moon Hare|Elder Moon Hare]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Hoshizora\|Hoshizora]] | 3 | C, D+, D- | 40–76 | Day |
| [[Regions/Fanghold\|Fanghold]] | 7 | C, C-, E+, D+, D-, D | 32–76 | Day |
| [[Regions/Kitsune Isles\|Kitsune Isles]] | 1 | D- | 40–40 | Day |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00519` | Hoshizora Moon Hare Elderborn | [[Regions/Hoshizora\|Hoshizora]] | Elderborn | C | 76 | 0.68 m | Day | Like a typical Moon Hare, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_00520` | Fanghold Moon Hare Elderborn | [[Regions/Fanghold\|Fanghold]] | Elderborn | C | 76 | 0.68 m | Day | Like a typical Moon Hare, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_00521` | Fanghold Moon Hare Alpha | [[Regions/Fanghold\|Fanghold]] | Alpha | C- | 65 | 0.63 m | Day | Like a typical Moon Hare, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_00522` | Kitsune Isles Moon Hare Juvenile | [[Regions/Kitsune Isles\|Kitsune Isles]] | Juvenile | D- | 40 | 0.42 m | Day | Like a typical Moon Hare, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_00523` | Hoshizora Moon Hare Scarred | [[Regions/Hoshizora\|Hoshizora]] | Scarred | D+ | 56 | 0.55 m | Day | Like a typical Moon Hare, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_00524` | Fanghold Moon Hare Runt | [[Regions/Fanghold\|Fanghold]] | Runt | E+ | 32 | 0.35 m | Day | Like a typical Moon Hare, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_00525` | Fanghold Moon Hare Albino | [[Regions/Fanghold\|Fanghold]] | Albino | D+ | 56 | 0.5 m | Day | Like a typical Moon Hare, but a rare pale form with white skin or fur and red eyes. |
| `pop_00526` | Fanghold Moon Hare Scarred | [[Regions/Fanghold\|Fanghold]] | Scarred | D+ | 56 | 0.55 m | Day | Like a typical Moon Hare, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_00527` | Hoshizora Moon Hare Juvenile | [[Regions/Hoshizora\|Hoshizora]] | Juvenile | D- | 40 | 0.42 m | Day | Like a typical Moon Hare, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_00528` | Fanghold Moon Hare Juvenile | [[Regions/Fanghold\|Fanghold]] | Juvenile | D- | 40 | 0.42 m | Day | Like a typical Moon Hare, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_00529` | Fanghold Moon Hare | [[Regions/Fanghold\|Fanghold]] | Adult | D | 48 | 0.5 m | Day | A typical adult Moon Hare of this region, with golden, grass-toned coloring. |

## Design recipe

Rig `rig_quad_small` · mesh `quad_small_base` · material `fur_groom` · VFX `holy_motes` · palette `#c5b999` `#8d8066` `#ffd166` · circle-based, soft silhouette
