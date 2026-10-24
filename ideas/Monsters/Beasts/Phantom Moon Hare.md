---
type: monster
id: mon_phantom_moon_hare
family: "Beasts"
rank: "D+"
tier: variant
tags: [monster, beasts]
---
# Phantom Moon Hare

![[mon_phantom_moon_hare_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_phantom_moon_hare_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Phantom Moon Hare is a small creature with a compact quadruped frame, about 0.5 m long. Its coat is weathered and natural, colored in warm gold and pearl white. Its most striking feature is white fur that glows under the full moon. It has dark, wary eyes. A distinctive marking runs along its back. It prowls, surrounded by soft radiance and floating motes of light. Its body is translucent blue, half in the spirit world; weapons pass through it unless they are blessed or enchanted.

| Field | Value |
|---|---|
| Family · type | [[Families/Beasts|Beasts]] · Beast |
| Variant of | [[Monsters/Beasts/Moon Hare\|Moon Hare]] (spirit) |
| Rank · level | D+ · 56 (48–65) |
| Menace | 2 · Wild |
| Element · weakness | Light · Dark |
| Size | 0.5 m |
| Behaviour | Skittish (skittish_flee) |
| HP · ATK · DEF · MATK · MDEF · SPD | 2649 · 234 · 187 · 164 · 187 · 135 |
| XP · gold | 1888 · 423 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/quad_small\|quad_small]] · `anim_quad_small` |
| Habitats | [[Regions/Hoshizora\|Hoshizora]], [[Regions/Kitsune Isles\|Kitsune Isles]], [[Regions/Fanghold\|Fanghold]] |
| Genre | Classic Fantasy |
| Trope | The horned rabbit "rookie killer" and wolf packs of every isekai starter forest |

**Field note:** Weak to Dark. Flees when hurt. Snares or ranged attacks work best.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_small|quad_small]] (rigId); animation set `anim_quad_small`.
- **Dimensions:** 0.34 m high × 0.5 m long × 0.07 m wide; prefab scale 1.
- **Physics:** 3.6 kg, gravity ×1.44, poise 26, knockback resistance 0.11, death style `ragdoll_tumble`.
- **Navigation:** speed 7.16 m/s, turn 764°/s, stopping distance 0.5 m.
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

Phantom Moon Hare is a **wild beast** encountered at D+ rank, around level 56. Its documented behaviour is *Skittish* and its AI pattern is *skittish_flee*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

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

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Fanghold\|Fanghold]] | 3 | C-, C+, D+ | 56–86 | Day & Night |
| [[Regions/Kitsune Isles\|Kitsune Isles]] | 4 | C+, C-, C | 65–86 | Day & Night |
| [[Regions/Hoshizora\|Hoshizora]] | 4 | D, C, C-, C+ | 48–86 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03419` | Fanghold Phantom Moon Hare Scarred | [[Regions/Fanghold\|Fanghold]] | Scarred | C- | 65 | 0.55 m | Day & Night | Like a typical Phantom Moon Hare, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_03420` | Fanghold Phantom Moon Hare Elderborn | [[Regions/Fanghold\|Fanghold]] | Elderborn | C+ | 86 | 0.68 m | Day & Night | Like a typical Phantom Moon Hare, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_03421` | Kitsune Isles Phantom Moon Hare Elderborn | [[Regions/Kitsune Isles\|Kitsune Isles]] | Elderborn | C+ | 86 | 0.68 m | Day & Night | Like a typical Phantom Moon Hare, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_03422` | Kitsune Isles Phantom Moon Hare Albino | [[Regions/Kitsune Isles\|Kitsune Isles]] | Albino | C- | 65 | 0.5 m | Day & Night | Like a typical Phantom Moon Hare, but a rare pale form with white skin or fur and red eyes. |
| `pop_03423` | Kitsune Isles Phantom Moon Hare Alpha | [[Regions/Kitsune Isles\|Kitsune Isles]] | Alpha | C | 76 | 0.63 m | Day & Night | Like a typical Phantom Moon Hare, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_03424` | Hoshizora Phantom Moon Hare Juvenile | [[Regions/Hoshizora\|Hoshizora]] | Juvenile | D | 48 | 0.42 m | Day & Night | Like a typical Phantom Moon Hare, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_03425` | Hoshizora Phantom Moon Hare Alpha | [[Regions/Hoshizora\|Hoshizora]] | Alpha | C | 76 | 0.63 m | Day & Night | Like a typical Phantom Moon Hare, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_03426` | Hoshizora Phantom Moon Hare Albino | [[Regions/Hoshizora\|Hoshizora]] | Albino | C- | 65 | 0.5 m | Day & Night | Like a typical Phantom Moon Hare, but a rare pale form with white skin or fur and red eyes. |
| `pop_03427` | Kitsune Isles Phantom Moon Hare Scarred | [[Regions/Kitsune Isles\|Kitsune Isles]] | Scarred | C- | 65 | 0.55 m | Day & Night | Like a typical Phantom Moon Hare, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_03428` | Fanghold Phantom Moon Hare | [[Regions/Fanghold\|Fanghold]] | Adult | D+ | 56 | 0.5 m | Day & Night | A typical adult Phantom Moon Hare of this region, with golden, grass-toned coloring. |
| `pop_03429` | Hoshizora Phantom Moon Hare Elderborn | [[Regions/Hoshizora\|Hoshizora]] | Elderborn | C+ | 86 | 0.68 m | Day & Night | Like a typical Phantom Moon Hare, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_quad_small` · mesh `quad_small_base` · material `fur_groom` · VFX `holy_motes` · palette `#fff3b0` `#ffd166` `#ffffff` · real-animal silhouette with one fantasy exaggeration
