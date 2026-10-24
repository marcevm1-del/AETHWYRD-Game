---
type: monster
id: mon_firefly_swarm
family: "Insects & Arachnids"
rank: "E"
tier: core
tags: [monster, insects-arachnids]
---
# Firefly Swarm

![[mon_firefly_swarm_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_firefly_swarm_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Firefly Swarm is a tiny creature with a cloud of tiny creatures, each one is about 0.05 m long, but the swarm covers several meters. Its chitin is smooth and clean, colored in warm gold and pearl white. Guild sketches always show hundreds of soft lantern lights moving together. It has wide curious eyes with star-shaped highlights. Small scars and rough edges mark it as a survivor. It bounces happily, surrounded by soft radiance and floating motes of light.

| Field | Value |
|---|---|
| Family · type | [[Families/Insects & Arachnids|Insects & Arachnids]] · Insectoid |
| Rank · level | E · 26 (19–32) |
| Menace | 1 · Charming |
| Element · weakness | Light · Dark |
| Size | 0.05 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 526 · 91 · 68 · 68 · 68 · 110 |
| XP · gold | 559 · 147 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/swarm\|swarm]] · `anim_swarm` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]], [[Regions/Fanghold\|Fanghold]], [[Regions/Mossdeep\|Mossdeep]], [[Regions/Sylvaran\|Sylvaran]] |
| Genre | Classic Fantasy |
| Trope | Giant insects as low-floor threats; the arachne as an intelligent monster race |

**Field note:** Weak to Dark. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/swarm|swarm]] (rigId); animation set `anim_swarm`.
- **Dimensions:** 0.05 m high × 0.02 m long × 0.01 m wide; prefab scale 0.017.
- **Physics:** 0.5 kg, gravity ×0, poise 4, knockback resistance 1, death style `scatter_and_fall`.
- **Navigation:** speed 0.98 m/s, turn 900°/s, stopping distance 0.5 m.
- **Attack count:** 5; **signature:** hundreds of soft lantern lights moving together.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Nibble\|Nibble]] | melee | 0.6 | 0 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Engulf\|Engulf]] | grab | 1.4 | 8 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Scatter\|Scatter]] | evade | 0 | 10 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Silk Snare\|Silk Snare]] | ranged | 0.4 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Radiant Pulse\|Radiant Pulse]] | magic | 1.5 | 10 s | Light | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Firefly Swarm is a **charming insectoid** encountered at E rank, around level 26. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Dark**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** hundreds of soft lantern lights moving together. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Whisperwood|Whisperwood]], [[Regions/Fanghold|Fanghold]], [[Regions/Mossdeep|Mossdeep]], [[Regions/Sylvaran|Sylvaran]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_swarm`, animation set `anim_swarm`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Insects & Arachnids E|loot_insect_e]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Carapace Shard\|Carapace Shard]] | 60% | 1–3 |
| [[Items/Silk\|Silk]] | 30% | 1–1 |
| [[Items/Venom Sac\|Venom Sac]] | 15% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Insects & Arachnids/Phantom Firefly Swarm|Phantom Firefly Swarm]]
- [[Monsters/Insects & Arachnids/Blight Firefly Swarm|Blight Firefly Swarm]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Sylvaran\|Sylvaran]] | 2 | E, D | 26–48 | Day |
| [[Regions/Whisperwood\|Whisperwood]] | 1 | F+ | 13–13 | Day |
| [[Regions/Mossdeep\|Mossdeep]] | 5 | D-, F+, E+, E- | 13–40 | Day |
| [[Regions/Fanghold\|Fanghold]] | 1 | E- | 19–19 | Day |
| [[Regions/Aldmere\|Aldmere]] | 2 | D-, E- | 19–40 | Day |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00630` | Sylvaran Firefly Swarm | [[Regions/Sylvaran\|Sylvaran]] | Adult | E | 26 | 0.05 m | Day | A typical adult Firefly Swarm of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_00631` | Whisperwood Firefly Swarm Runt | [[Regions/Whisperwood\|Whisperwood]] | Runt | F+ | 13 | 0.03 m | Day | Like a typical Firefly Swarm, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_00632` | Sylvaran Firefly Swarm Elderborn | [[Regions/Sylvaran\|Sylvaran]] | Elderborn | D | 48 | 0.07 m | Day | Like a typical Firefly Swarm, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_00633` | Mossdeep Firefly Swarm Alpha | [[Regions/Mossdeep\|Mossdeep]] | Alpha | D- | 40 | 0.06 m | Day | Like a typical Firefly Swarm, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_00634` | Fanghold Firefly Swarm Juvenile | [[Regions/Fanghold\|Fanghold]] | Juvenile | E- | 19 | 0.04 m | Day | Like a typical Firefly Swarm, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_00635` | Mossdeep Firefly Swarm Runt | [[Regions/Mossdeep\|Mossdeep]] | Runt | F+ | 13 | 0.03 m | Day | Like a typical Firefly Swarm, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_00636` | Mossdeep Firefly Swarm Scarred | [[Regions/Mossdeep\|Mossdeep]] | Scarred | E+ | 32 | 0.06 m | Day | Like a typical Firefly Swarm, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_00637` | Mossdeep Firefly Swarm Juvenile | [[Regions/Mossdeep\|Mossdeep]] | Juvenile | E- | 19 | 0.04 m | Day | Like a typical Firefly Swarm, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_00638` | Aldmere Firefly Swarm Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | D- | 40 | 0.06 m | Day | Like a typical Firefly Swarm, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_00639` | Mossdeep Firefly Swarm Albino | [[Regions/Mossdeep\|Mossdeep]] | Albino | E+ | 32 | 0.05 m | Day | Like a typical Firefly Swarm, but a rare pale form with white skin or fur and red eyes. |
| `pop_00640` | Aldmere Firefly Swarm Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | E- | 19 | 0.04 m | Day | Like a typical Firefly Swarm, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |

## Design recipe

Rig `rig_swarm` · mesh `swarm_base` · material `chitin_gloss` · VFX `holy_motes` · palette `#fff3b0` `#ffd166` `#ffffff` · circle-based, soft silhouette
