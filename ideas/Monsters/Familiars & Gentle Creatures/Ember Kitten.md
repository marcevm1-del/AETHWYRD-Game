---
type: monster
id: mon_ember_kitten
family: "Familiars & Gentle Creatures"
rank: "E"
tier: core
tags: [monster, familiars-gentle-creatures]
---
# Ember Kitten

![[mon_ember_kitten_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_ember_kitten_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 5,998 tris · 0.09 × 0.4 × 0.211 m · local file `Game/Assets/_Game/Art/Models/Monsters/Familiars & Gentle Creatures/mon_ember_kitten.fbx`

> The Ember Kitten is a tiny creature with a small, quick four-legged body, about 0.4 m long. Its coat is smooth and clean, colored in pastel pink, with ember-orange markings. Guild sketches always show fur that flickers like candle flame. It has two bright dot eyes. Small scars and rough edges mark it as a survivor. It bounces happily, surrounded by heat-shimmer and drifting sparks.

| Field | Value |
|---|---|
| Family · type | [[Families/Familiars & Gentle Creatures|Familiars & Gentle Creatures]] · Familiar |
| Rank · level | E · 26 (19–32) |
| Menace | 1 · Charming |
| Element · weakness | Fire · Water |
| Size | 0.4 m |
| Behaviour | Passive (passive_wander) |
| HP · ATK · DEF · MATK · MDEF · SPD | 819 · 114 · 91 · 80 · 91 · 135 |
| XP · gold | 559 · 147 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/quad_small\|quad_small]] · `anim_quad_small` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Lirian\|Lirian]], [[Regions/Whisperwood\|Whisperwood]], [[Regions/Fanghold\|Fanghold]], [[Regions/Sylvaran\|Sylvaran]] |
| Genre | Cozy Fantasy |
| Trope | Cozy companion creatures |

**Field note:** Weak to Water. Leaves you alone unless attacked.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_small|quad_small]] (rigId); animation set `anim_quad_small`.
- **Dimensions:** 0.27 m high × 0.4 m long × 0.06 m wide; prefab scale 0.8.
- **Physics:** 1.9 kg, gravity ×1.6, poise 21, knockback resistance 0.08, death style `ragdoll_tumble`.
- **Navigation:** speed 4.79 m/s, turn 854°/s, stopping distance 0.5 m.
- **Attack count:** 5; **signature:** fur that flickers like candle flame.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Bite\|Bite]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Charge\|Charge]] | dash | 1.3 | 5 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Leap\|Leap]] | dash | 1.2 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Playful Nudge\|Playful Nudge]] | melee | 0.5 | 6 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Ember Burst\|Ember Burst]] | magic | 1.5 | 10 s | Fire | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Ember Kitten is a **charming familiar** encountered at E rank, around level 26. Its documented behaviour is *Passive* and its AI pattern is *passive_wander*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Water**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** fur that flickers like candle flame. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Lirian|Lirian]], [[Regions/Whisperwood|Whisperwood]], [[Regions/Fanghold|Fanghold]], [[Regions/Sylvaran|Sylvaran]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_small`, animation set `anim_quad_small`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Familiars & Gentle Creatures E|loot_familiar_e]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Soft Fur\|Soft Fur]] | 60% | 1–3 |
| [[Items/Shed Scale\|Shed Scale]] | 30% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Familiars & Gentle Creatures/Moss Kitten|Moss Kitten]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Sylvaran\|Sylvaran]] | 3 | D-, F+, D | 13–48 | Day |
| [[Regions/Fanghold\|Fanghold]] | 2 | E+, E- | 19–32 | Day |
| [[Regions/Aldmere\|Aldmere]] | 4 | E-, E+, E, F+ | 13–32 | Day |
| [[Regions/Lirian\|Lirian]] | 2 | D-, D | 40–48 | Day |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02873` | Sylvaran Ember Kitten Alpha | [[Regions/Sylvaran\|Sylvaran]] | Alpha | D- | 40 | 0.5 m | Day | Like a typical Ember Kitten, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_02874` | Fanghold Ember Kitten Scarred | [[Regions/Fanghold\|Fanghold]] | Scarred | E+ | 32 | 0.44 m | Day | Like a typical Ember Kitten, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_02875` | Fanghold Ember Kitten Juvenile | [[Regions/Fanghold\|Fanghold]] | Juvenile | E- | 19 | 0.34 m | Day | Like a typical Ember Kitten, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_02876` | Aldmere Ember Kitten Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | E- | 19 | 0.34 m | Day | Like a typical Ember Kitten, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_02877` | Lirian Ember Kitten Alpha | [[Regions/Lirian\|Lirian]] | Alpha | D- | 40 | 0.5 m | Day | Like a typical Ember Kitten, but larger and scarred, and others of its kind follow it, with salt-crusted, barnacle-flecked hide. |
| `pop_02878` | Sylvaran Ember Kitten Runt | [[Regions/Sylvaran\|Sylvaran]] | Runt | F+ | 13 | 0.28 m | Day | Like a typical Ember Kitten, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_02879` | Aldmere Ember Kitten Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | E+ | 32 | 0.44 m | Day | Like a typical Ember Kitten, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_02880` | Lirian Ember Kitten Elderborn | [[Regions/Lirian\|Lirian]] | Elderborn | D | 48 | 0.54 m | Day | Like a typical Ember Kitten, but old and wise, with greying features and a cautious hunting style, with salt-crusted, barnacle-flecked hide. |
| `pop_02881` | Aldmere Ember Kitten | [[Regions/Aldmere\|Aldmere]] | Adult | E | 26 | 0.4 m | Day | A typical adult Ember Kitten of this region, with golden, grass-toned coloring. |
| `pop_02882` | Aldmere Ember Kitten Runt | [[Regions/Aldmere\|Aldmere]] | Runt | F+ | 13 | 0.28 m | Day | Like a typical Ember Kitten, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_02883` | Sylvaran Ember Kitten Elderborn | [[Regions/Sylvaran\|Sylvaran]] | Elderborn | D | 48 | 0.54 m | Day | Like a typical Ember Kitten, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_quad_small` · mesh `quad_small_base` · material `fur_soft` · VFX `embers_heat_haze` · palette `#f4c0d1` `#ae8593` `#ff7a3d` · circle-based, soft silhouette
