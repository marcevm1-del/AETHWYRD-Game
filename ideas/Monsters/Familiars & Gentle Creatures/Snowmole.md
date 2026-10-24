---
type: monster
id: mon_snowmole
family: "Familiars & Gentle Creatures"
rank: "E"
tier: core
tags: [monster, familiars-gentle-creatures]
---
# Snowmole

> The Snowmole is a tiny creature with a small, quick four-legged body, about 0.4 m long. Its coat is smooth and clean, colored in pale blues and frost-white. Survivors describe a white nose and shovel-like paws. It has big round glossy eyes. Small scars and rough edges mark it as a survivor. It hops in little bursts, surrounded by falling snow motes and frosted ground where it steps.

| Field | Value |
|---|---|
| Family · type | [[Families/Familiars & Gentle Creatures|Familiars & Gentle Creatures]] · Familiar |
| Rank · level | E · 26 (19–32) |
| Menace | 1 · Charming |
| Element · weakness | Ice · Fire |
| Size | 0.4 m |
| Behaviour | Passive (passive_wander) |
| HP · ATK · DEF · MATK · MDEF · SPD | 819 · 114 · 91 · 80 · 91 · 135 |
| XP · gold | 559 · 147 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/quad_small\|quad_small]] · `anim_quad_small` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Sylvaran\|Sylvaran]], [[Regions/Lirian\|Lirian]] |
| Genre | Cozy Fantasy |
| Trope | Cozy companion creatures |

**Field note:** Weak to Fire. Leaves you alone unless attacked.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_small|quad_small]] (rigId); animation set `anim_quad_small`.
- **Dimensions:** 0.27 m high × 0.4 m long × 0.06 m wide; prefab scale 0.8.
- **Physics:** 2.1 kg, gravity ×1.68, poise 21, knockback resistance 0.08, death style `ragdoll_tumble`.
- **Navigation:** speed 4.2 m/s, turn 854°/s, stopping distance 0.5 m.
- **Attack count:** 5; **signature:** a white nose and shovel-like paws.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Bite\|Bite]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Charge\|Charge]] | dash | 1.3 | 5 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Leap\|Leap]] | dash | 1.2 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Playful Nudge\|Playful Nudge]] | melee | 0.5 | 6 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Frost Breath\|Frost Breath]] | magic | 1.5 | 10 s | Ice | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Snowmole is a **charming familiar** encountered at E rank, around level 26. Its documented behaviour is *Passive* and its AI pattern is *passive_wander*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a white nose and shovel-like paws. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Sylvaran|Sylvaran]], [[Regions/Lirian|Lirian]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_small`, animation set `anim_quad_small`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Familiars & Gentle Creatures E|loot_familiar_e]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Soft Fur\|Soft Fur]] | 60% | 1–3 |
| [[Items/Shed Scale\|Shed Scale]] | 30% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Familiars & Gentle Creatures/Sky Snowmole|Sky Snowmole]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Aldmere\|Aldmere]] | 2 | F+, E- | 13–19 | Day |
| [[Regions/Lirian\|Lirian]] | 5 | E, D, E+, D-, F+ | 13–48 | Day |
| [[Regions/Sylvaran\|Sylvaran]] | 4 | E+, E, D-, F+ | 13–40 | Day |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02884` | Aldmere Snowmole Runt | [[Regions/Aldmere\|Aldmere]] | Runt | F+ | 13 | 0.28 m | Day | Like a typical Snowmole, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_02885` | Lirian Snowmole | [[Regions/Lirian\|Lirian]] | Adult | E | 26 | 0.4 m | Day | A typical adult Snowmole of this region, with salt-crusted, barnacle-flecked hide. |
| `pop_02886` | Sylvaran Snowmole Scarred | [[Regions/Sylvaran\|Sylvaran]] | Scarred | E+ | 32 | 0.44 m | Day | Like a typical Snowmole, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_02887` | Lirian Snowmole Elderborn | [[Regions/Lirian\|Lirian]] | Elderborn | D | 48 | 0.54 m | Day | Like a typical Snowmole, but old and wise, with greying features and a cautious hunting style, with salt-crusted, barnacle-flecked hide. |
| `pop_02888` | Lirian Snowmole Scarred | [[Regions/Lirian\|Lirian]] | Scarred | E+ | 32 | 0.44 m | Day | Like a typical Snowmole, but covered in old battle scars, with salt-crusted, barnacle-flecked hide. |
| `pop_02889` | Sylvaran Snowmole | [[Regions/Sylvaran\|Sylvaran]] | Adult | E | 26 | 0.4 m | Day | A typical adult Snowmole of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_02890` | Aldmere Snowmole Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | E- | 19 | 0.34 m | Day | Like a typical Snowmole, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_02891` | Sylvaran Snowmole Alpha | [[Regions/Sylvaran\|Sylvaran]] | Alpha | D- | 40 | 0.5 m | Day | Like a typical Snowmole, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_02892` | Lirian Snowmole Alpha | [[Regions/Lirian\|Lirian]] | Alpha | D- | 40 | 0.5 m | Day | Like a typical Snowmole, but larger and scarred, and others of its kind follow it, with salt-crusted, barnacle-flecked hide. |
| `pop_02893` | Lirian Snowmole Runt | [[Regions/Lirian\|Lirian]] | Runt | F+ | 13 | 0.28 m | Day | Like a typical Snowmole, but smaller and scrappier than usual, with salt-crusted, barnacle-flecked hide. |
| `pop_02894` | Sylvaran Snowmole Runt | [[Regions/Sylvaran\|Sylvaran]] | Runt | F+ | 13 | 0.28 m | Day | Like a typical Snowmole, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_quad_small` · mesh `quad_small_base` · material `fur_soft` · VFX `frost_trail_snow` · palette `#bfe9ff` `#5fa8d3` `#f4fbff` · circle-based, soft silhouette
