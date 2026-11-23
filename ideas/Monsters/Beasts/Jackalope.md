---
type: monster
id: mon_jackalope
family: "Beasts"
rank: "E"
tier: core
tags: [monster, beasts]
---
# Jackalope

![[mon_jackalope_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_jackalope_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 6,000 tris · 0.156 × 0.4 × 0.309 m · local file `Game/Assets/_Game/Art/Models/Monsters/Beasts/mon_jackalope.fbx`

> The Jackalope is a tiny creature with a low, springy quadruped build, about 0.4 m long. Its coat is smooth and clean, colored in cream. Look for tiny antlers on a fluffy rabbit. It has big round glossy eyes. Small scars and rough edges mark it as a survivor. It bounces happily. It has no visible aura; you hear its breathing before you see it.

| Field | Value |
|---|---|
| Family · type | [[Families/Beasts|Beasts]] · Beast |
| Rank · level | E · 26 (19–32) |
| Menace | 1 · Charming |
| Element · weakness | None · Fire |
| Size | 0.4 m |
| Behaviour | Pack (pack_flank) |
| HP · ATK · DEF · MATK · MDEF · SPD | 819 · 114 · 91 · 56 · 91 · 135 |
| XP · gold | 559 · 147 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/quad_small\|quad_small]] · `anim_quad_small` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Fanghold\|Fanghold]], [[Regions/Mossdeep\|Mossdeep]], [[Regions/Whisperwood\|Whisperwood]], [[Regions/Sylvaran\|Sylvaran]] |
| Genre | Classic Fantasy |
| Trope | The horned rabbit "rookie killer" and wolf packs of every isekai starter forest |

**Field note:** Weak to Fire. Never alone. Kill the leader first and the rest may scatter.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_small|quad_small]] (rigId); animation set `anim_quad_small`.
- **Dimensions:** 0.27 m high × 0.4 m long × 0.06 m wide; prefab scale 0.8.
- **Physics:** 1.9 kg, gravity ×1.6, poise 21, knockback resistance 0.08, death style `ragdoll_tumble`.
- **Navigation:** speed 5.04 m/s, turn 854°/s, stopping distance 0.5 m.
- **Attack count:** 4; **signature:** tiny antlers on a fluffy rabbit.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Bite\|Bite]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Charge\|Charge]] | dash | 1.3 | 5 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Leap\|Leap]] | dash | 1.2 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Rending Bite\|Rending Bite]] | melee | 1.3 | 5 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |

## Field guide

Jackalope is a **charming beast** encountered at E rank, around level 26. Its documented behaviour is *Pack* and its AI pattern is *pack_flank*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** tiny antlers on a fluffy rabbit. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Fanghold|Fanghold]], [[Regions/Mossdeep|Mossdeep]], [[Regions/Whisperwood|Whisperwood]], [[Regions/Sylvaran|Sylvaran]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_small`, animation set `anim_quad_small`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Beasts E|loot_beast_e]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Pelt\|Pelt]] | 60% | 1–3 |
| [[Items/Fang\|Fang]] | 30% | 1–1 |
| [[Items/Prime Meat\|Prime Meat]] | 15% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Beasts/Crag Jackalope|Crag Jackalope]]
- [[Monsters/Beasts/Phantom Jackalope|Phantom Jackalope]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Whisperwood\|Whisperwood]] | 4 | E-, E+, E, F+ | 13–32 | Day |
| [[Regions/Sylvaran\|Sylvaran]] | 2 | E+, F+ | 13–32 | Day |
| [[Regions/Aldmere\|Aldmere]] | 3 | F+, E+, D- | 13–40 | Day |
| [[Regions/Mossdeep\|Mossdeep]] | 1 | D- | 40–40 | Day |
| [[Regions/Fanghold\|Fanghold]] | 1 | E | 26–26 | Day |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00508` | Whisperwood Jackalope Juvenile | [[Regions/Whisperwood\|Whisperwood]] | Juvenile | E- | 19 | 0.34 m | Day | Like a typical Jackalope, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_00509` | Whisperwood Jackalope Scarred | [[Regions/Whisperwood\|Whisperwood]] | Scarred | E+ | 32 | 0.44 m | Day | Like a typical Jackalope, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_00510` | Sylvaran Jackalope Scarred | [[Regions/Sylvaran\|Sylvaran]] | Scarred | E+ | 32 | 0.44 m | Day | Like a typical Jackalope, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_00511` | Aldmere Jackalope Runt | [[Regions/Aldmere\|Aldmere]] | Runt | F+ | 13 | 0.28 m | Day | Like a typical Jackalope, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_00512` | Mossdeep Jackalope Alpha | [[Regions/Mossdeep\|Mossdeep]] | Alpha | D- | 40 | 0.5 m | Day | Like a typical Jackalope, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_00513` | Sylvaran Jackalope Runt | [[Regions/Sylvaran\|Sylvaran]] | Runt | F+ | 13 | 0.28 m | Day | Like a typical Jackalope, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_00514` | Aldmere Jackalope Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | E+ | 32 | 0.44 m | Day | Like a typical Jackalope, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_00515` | Whisperwood Jackalope | [[Regions/Whisperwood\|Whisperwood]] | Adult | E | 26 | 0.4 m | Day | A typical adult Jackalope of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_00516` | Aldmere Jackalope Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | D- | 40 | 0.5 m | Day | Like a typical Jackalope, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_00517` | Fanghold Jackalope | [[Regions/Fanghold\|Fanghold]] | Adult | E | 26 | 0.4 m | Day | A typical adult Jackalope of this region, with golden, grass-toned coloring. |
| `pop_00518` | Whisperwood Jackalope Runt | [[Regions/Whisperwood\|Whisperwood]] | Runt | F+ | 13 | 0.28 m | Day | Like a typical Jackalope, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_quad_small` · mesh `quad_small_base` · material `fur_groom` · VFX `dust_puffs` · palette `#ded5ac` `#9e9573` `#ffecc6` · circle-based, soft silhouette
