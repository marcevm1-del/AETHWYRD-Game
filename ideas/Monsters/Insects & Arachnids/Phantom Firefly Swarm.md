---
type: monster
id: mon_phantom_firefly_swarm
family: "Insects & Arachnids"
rank: "E+"
tier: variant
tags: [monster, insects-arachnids]
---
# Phantom Firefly Swarm

> The Phantom Firefly Swarm is a tiny creature with a living carpet of small bodies, each one is about 0.05 m long, but the swarm covers several meters. Its chitin is weathered and natural, colored in warm gold and pearl white. Look for hundreds of soft lantern lights moving together. It has amber predator eyes. Small scars and rough edges mark it as a survivor. It lopes in long strides, surrounded by soft radiance and floating motes of light. Its body is translucent blue, half in the spirit world; weapons pass through it unless they are blessed or enchanted.

| Field | Value |
|---|---|
| Family · type | [[Families/Insects & Arachnids|Insects & Arachnids]] · Insectoid |
| Variant of | [[Monsters/Insects & Arachnids/Firefly Swarm\|Firefly Swarm]] (spirit) |
| Rank · level | E+ · 32 (26–40) |
| Menace | 2 · Wild |
| Element · weakness | Light · Dark |
| Size | 0.05 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 709 · 110 · 83 · 83 · 83 · 110 |
| XP · gold | 776 · 195 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/swarm\|swarm]] · `anim_swarm` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]], [[Regions/Sylvaran\|Sylvaran]] |
| Genre | Classic Fantasy |
| Trope | Giant insects as low-floor threats; the arachne as an intelligent monster race |

**Field note:** Weak to Dark. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/swarm|swarm]] (rigId); animation set `anim_swarm`.
- **Dimensions:** 0.05 m high × 0.02 m long × 0.01 m wide; prefab scale 0.017.
- **Physics:** 0.5 kg, gravity ×0, poise 4, knockback resistance 1, death style `scatter_and_fall`.
- **Navigation:** speed 1.09 m/s, turn 900°/s, stopping distance 0.5 m.
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

Phantom Firefly Swarm is a **wild insectoid** encountered at E+ rank, around level 32. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Dark**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** hundreds of soft lantern lights moving together. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Whisperwood|Whisperwood]], [[Regions/Sylvaran|Sylvaran]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_swarm`, animation set `anim_swarm`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Insects & Arachnids E|loot_insect_e]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Carapace Shard\|Carapace Shard]] | 60% | 1–3 |
| [[Items/Silk\|Silk]] | 30% | 1–1 |
| [[Items/Venom Sac\|Venom Sac]] | 15% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Whisperwood\|Whisperwood]] | 4 | E, D-, D+, E+ | 26–56 | Day & Night |
| [[Regions/Aldmere\|Aldmere]] | 3 | D-, E+, E | 26–40 | Day & Night |
| [[Regions/Sylvaran\|Sylvaran]] | 4 | E-, D-, E+, D | 19–48 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03529` | Whisperwood Phantom Firefly Swarm Juvenile | [[Regions/Whisperwood\|Whisperwood]] | Juvenile | E | 26 | 0.04 m | Day & Night | Like a typical Phantom Firefly Swarm, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_03530` | Whisperwood Phantom Firefly Swarm Albino | [[Regions/Whisperwood\|Whisperwood]] | Albino | D- | 40 | 0.05 m | Day & Night | Like a typical Phantom Firefly Swarm, but a rare pale form with white skin or fur and red eyes. |
| `pop_03531` | Aldmere Phantom Firefly Swarm Albino | [[Regions/Aldmere\|Aldmere]] | Albino | D- | 40 | 0.05 m | Day & Night | Like a typical Phantom Firefly Swarm, but a rare pale form with white skin or fur and red eyes. |
| `pop_03532` | Aldmere Phantom Firefly Swarm | [[Regions/Aldmere\|Aldmere]] | Adult | E+ | 32 | 0.05 m | Day & Night | A typical adult Phantom Firefly Swarm of this region, with golden, grass-toned coloring. |
| `pop_03533` | Whisperwood Phantom Firefly Swarm Elderborn | [[Regions/Whisperwood\|Whisperwood]] | Elderborn | D+ | 56 | 0.07 m | Day & Night | Like a typical Phantom Firefly Swarm, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_03534` | Whisperwood Phantom Firefly Swarm | [[Regions/Whisperwood\|Whisperwood]] | Adult | E+ | 32 | 0.05 m | Day & Night | A typical adult Phantom Firefly Swarm of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_03535` | Sylvaran Phantom Firefly Swarm Runt | [[Regions/Sylvaran\|Sylvaran]] | Runt | E- | 19 | 0.03 m | Day & Night | Like a typical Phantom Firefly Swarm, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_03536` | Sylvaran Phantom Firefly Swarm Albino | [[Regions/Sylvaran\|Sylvaran]] | Albino | D- | 40 | 0.05 m | Day & Night | Like a typical Phantom Firefly Swarm, but a rare pale form with white skin or fur and red eyes. |
| `pop_03537` | Aldmere Phantom Firefly Swarm Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | E | 26 | 0.04 m | Day & Night | Like a typical Phantom Firefly Swarm, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_03538` | Sylvaran Phantom Firefly Swarm | [[Regions/Sylvaran\|Sylvaran]] | Adult | E+ | 32 | 0.05 m | Day & Night | A typical adult Phantom Firefly Swarm of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_03539` | Sylvaran Phantom Firefly Swarm Alpha | [[Regions/Sylvaran\|Sylvaran]] | Alpha | D | 48 | 0.06 m | Day & Night | Like a typical Phantom Firefly Swarm, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_swarm` · mesh `swarm_base` · material `chitin_gloss` · VFX `holy_motes` · palette `#fff3b0` `#ffd166` `#ffffff` · real-animal silhouette with one fantasy exaggeration
