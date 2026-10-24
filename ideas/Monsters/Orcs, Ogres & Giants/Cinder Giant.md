---
type: monster
id: mon_cinder_giant
family: "Orcs, Ogres & Giants"
rank: "S-"
tier: variant
tags: [monster, orcs-ogres-giants]
---
# Cinder Giant

> The Cinder Giant is a huge creature with a giant, barrel-chested humanoid body, about 9 m tall. Its hide is rough, scarred and spiked, colored in ember reds fading to soot black. Guild sketches always show skin like cooling lava and a forge-hammer. It has narrow glowing eyes. Its regal silhouette is crowned by a halo-like ring of aura. It circles its prey, surrounded by heat-shimmer and drifting sparks. Adapted to volcanic lands, it has ash-dark coloring with glowing cracks.

| Field | Value |
|---|---|
| Family · type | [[Families/Orcs, Ogres & Giants|Orcs, Ogres & Giants]] · Giant |
| Variant of | [[Monsters/Orcs, Ogres & Giants/Fire Giant\|Fire Giant]] (regional) |
| Rank · level | S- · 173 (159–188) |
| Menace | 3 · Menacing |
| Element · weakness | Fire · Water |
| Size | 9 m |
| Behaviour | Pack (pack_flank) |
| HP · ATK · DEF · MATK · MDEF · SPD | 58800 · 702 · 1053 · 421 · 702 · 70 |
| XP · gold | 11437 · 2042 |
| Ring | 7 |
| Rig · animation | [[Systems/Rigs/large_biped\|large_biped]] · `anim_large_biped` |
| Habitats | [[Regions/Dragon Spine\|Dragon Spine]], [[Regions/Nox Dominion\|Nox Dominion]] |
| Genre | Classic Fantasy |
| Trope | Orc warbands and the Orc Disaster that devours its way to power (Tensura) |

**Field note:** Weak to Water. Never alone. Kill the leader first and the rest may scatter.

## Motion implementation

- **Rig:** [[Systems/Rigs/large_biped|large_biped]] (rigId); animation set `anim_large_biped`.
- **Dimensions:** 9 m high × 2.7 m long × 3.78 m wide; prefab scale 2.571.
- **Physics:** 13122 kg, gravity ×1.3, poise 427, knockback resistance 0.93, death style `heavy_fall_dust`.
- **Navigation:** speed 11.12 m/s, turn 127°/s, stopping distance 2.2 m.
- **Attack count:** 5; **signature:** skin like cooling lava and a forge-hammer.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stomp\|Stomp]] | aoe | 1.3 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Club Slam\|Club Slam]] | melee | 1.8 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Grab and Throw\|Grab and Throw]] | grab | 2 | 14 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/War Cry\|War Cry]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Ember Burst\|Ember Burst]] | magic | 1.5 | 10 s | Fire | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Cinder Giant is a **menacing giant** encountered at S- rank, around level 173. Its documented behaviour is *Pack* and its AI pattern is *pack_flank*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Water**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** skin like cooling lava and a forge-hammer. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Dragon Spine|Dragon Spine]], [[Regions/Nox Dominion|Nox Dominion]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_large_biped`, animation set `anim_large_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Orcs, Ogres & Giants S|loot_orc_giant_s]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Tusk\|Tusk]] | 60% | 1–3 |
| [[Items/Giant's Hide\|Giant's Hide]] | 30% | 1–1 |
| [[Items/Crude Iron\|Crude Iron]] | 15% | 1–1 |
| [[Items/S-Rank Monster Core\|S-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Dragon Spine\|Dragon Spine]] | 7 | S+, S-, SS-, S, A, A+ | 146–218 | Day & Night |
| [[Regions/Nox Dominion\|Nox Dominion]] | 4 | S+, S-, SS-, S | 173–218 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04057` | Dragon Spine Cinder Giant Alpha | [[Regions/Dragon Spine\|Dragon Spine]] | Alpha | S+ | 203 | 11.25 m | Day & Night | Like a typical Cinder Giant, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_04058` | Dragon Spine Cinder Giant | [[Regions/Dragon Spine\|Dragon Spine]] | Adult | S- | 173 | 9 m | Day & Night | A typical adult Cinder Giant of this region, with slate-grey coloring and hardened hide. |
| `pop_04059` | Nox Dominion Cinder Giant Alpha | [[Regions/Nox Dominion\|Nox Dominion]] | Alpha | S+ | 203 | 11.25 m | Day & Night | Like a typical Cinder Giant, but larger and scarred, and others of its kind follow it, with ash-dark coloring with glowing cracks. |
| `pop_04060` | Dragon Spine Cinder Giant Elderborn | [[Regions/Dragon Spine\|Dragon Spine]] | Elderborn | SS- | 218 | 12.15 m | Day & Night | Like a typical Cinder Giant, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_04061` | Dragon Spine Cinder Giant Albino | [[Regions/Dragon Spine\|Dragon Spine]] | Albino | S | 188 | 9 m | Day & Night | Like a typical Cinder Giant, but a rare pale form with white skin or fur and red eyes. |
| `pop_04062` | Dragon Spine Cinder Giant Runt | [[Regions/Dragon Spine\|Dragon Spine]] | Runt | A | 146 | 6.3 m | Day & Night | Like a typical Cinder Giant, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_04063` | Nox Dominion Cinder Giant | [[Regions/Nox Dominion\|Nox Dominion]] | Adult | S- | 173 | 9 m | Day & Night | A typical adult Cinder Giant of this region, with ash-dark coloring with glowing cracks. |
| `pop_04064` | Nox Dominion Cinder Giant Elderborn | [[Regions/Nox Dominion\|Nox Dominion]] | Elderborn | SS- | 218 | 12.15 m | Day & Night | Like a typical Cinder Giant, but old and wise, with greying features and a cautious hunting style, with ash-dark coloring with glowing cracks. |
| `pop_04065` | Nox Dominion Cinder Giant Scarred | [[Regions/Nox Dominion\|Nox Dominion]] | Scarred | S | 188 | 9.9 m | Day & Night | Like a typical Cinder Giant, but covered in old battle scars, with ash-dark coloring with glowing cracks. |
| `pop_04066` | Dragon Spine Cinder Giant Juvenile | [[Regions/Dragon Spine\|Dragon Spine]] | Juvenile | A+ | 159 | 7.65 m | Day & Night | Like a typical Cinder Giant, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_04067` | Dragon Spine Cinder Giant Scarred | [[Regions/Dragon Spine\|Dragon Spine]] | Scarred | S | 188 | 9.9 m | Day & Night | Like a typical Cinder Giant, but covered in old battle scars, with slate-grey coloring and hardened hide. |

## Design recipe

Rig `rig_large_biped` · mesh `large_biped_base` · material `thick_skin` · VFX `embers_heat_haze` · palette `#e2502b` `#ffb347` `#3a1a12` · triangle-based silhouette, sharp asymmetric spikes
