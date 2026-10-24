---
type: monster
id: mon_ogre
family: "Orcs, Ogres & Giants"
rank: "C"
tier: core
tags: [monster, orcs-ogres-giants]
---
# Ogre

> The Ogre is a large creature with a towering, heavy-limbed body, about 3.5 m tall. Its hide is rough, scarred and spiked, colored in ochre, clay and mossy stone. Look for a sagging belly, a tree-trunk club and a toll sack. It has burning slit pupils. Battle-worn plates and trophies hang from its body. It strides with heavy steps, surrounded by pebbles that tremble and float near it.

| Field | Value |
|---|---|
| Family · type | [[Families/Orcs, Ogres & Giants|Orcs, Ogres & Giants]] · Giant |
| Rank · level | C · 76 (65–86) |
| Menace | 3 · Menacing |
| Element · weakness | Earth · Wind |
| Size | 3.5 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 12871 · 314 · 471 · 188 · 314 · 70 |
| XP · gold | 3073 · 648 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/large_biped\|large_biped]] · `anim_large_biped` |
| Habitats | [[Regions/Vharlen\|Vharlen]], [[Regions/Frostveil\|Frostveil]], [[Regions/Iron Hold\|Iron Hold]] |
| Genre | Classic Fantasy |
| Trope | Orc warbands and the Orc Disaster that devours its way to power (Tensura) |

**Field note:** Weak to Wind. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/large_biped|large_biped]] (rigId); animation set `anim_large_biped`.
- **Dimensions:** 3.5 m high × 1.05 m long × 1.47 m wide; prefab scale 1.
- **Physics:** 1003.3 kg, gravity ×1.43, poise 203, knockback resistance 0.99, death style `heavy_fall_dust`.
- **Navigation:** speed 5.79 m/s, turn 203°/s, stopping distance 1.1 m.
- **Attack count:** 5; **signature:** a sagging belly, a tree-trunk club and a toll sack.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stomp\|Stomp]] | aoe | 1.3 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Club Slam\|Club Slam]] | melee | 1.8 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Grab and Throw\|Grab and Throw]] | grab | 2 | 14 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/War Cry\|War Cry]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Ogre is a **menacing giant** encountered at C rank, around level 76. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a sagging belly, a tree-trunk club and a toll sack. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Vharlen|Vharlen]], [[Regions/Frostveil|Frostveil]], [[Regions/Iron Hold|Iron Hold]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_large_biped`, animation set `anim_large_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Orcs, Ogres & Giants C|loot_orc_giant_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Tusk\|Tusk]] | 60% | 1–3 |
| [[Items/Giant's Hide\|Giant's Hide]] | 30% | 1–1 |
| [[Items/Crude Iron\|Crude Iron]] | 15% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Orcs, Ogres & Giants/Rime Ogre|Rime Ogre]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Vharlen\|Vharlen]] | 3 | D+, B-, C+ | 56–96 | Day & Night |
| [[Regions/Frostveil\|Frostveil]] | 5 | C-, B-, C, D+, C+ | 56–96 | Day & Night |
| [[Regions/Iron Hold\|Iron Hold]] | 3 | B-, B, C+ | 86–108 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01094` | Vharlen Ogre Runt | [[Regions/Vharlen\|Vharlen]] | Runt | D+ | 56 | 2.45 m | Day & Night | Like a typical Ogre, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_01095` | Frostveil Ogre Juvenile | [[Regions/Frostveil\|Frostveil]] | Juvenile | C- | 65 | 2.98 m | Day & Night | Like a typical Ogre, but young, with brighter colors and unworn features, with a thick, frost-rimed coat. |
| `pop_01096` | Frostveil Ogre Alpha | [[Regions/Frostveil\|Frostveil]] | Alpha | B- | 96 | 4.38 m | Day & Night | Like a typical Ogre, but larger and scarred, and others of its kind follow it, with a thick, frost-rimed coat. |
| `pop_01097` | Frostveil Ogre | [[Regions/Frostveil\|Frostveil]] | Adult | C | 76 | 3.5 m | Day & Night | A typical adult Ogre of this region, with a thick, frost-rimed coat. |
| `pop_01098` | Vharlen Ogre Alpha | [[Regions/Vharlen\|Vharlen]] | Alpha | B- | 96 | 4.38 m | Day & Night | Like a typical Ogre, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_01099` | Iron Hold Ogre Alpha | [[Regions/Iron Hold\|Iron Hold]] | Alpha | B- | 96 | 4.38 m | Day & Night | Like a typical Ogre, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_01100` | Frostveil Ogre Runt | [[Regions/Frostveil\|Frostveil]] | Runt | D+ | 56 | 2.45 m | Day & Night | Like a typical Ogre, but smaller and scrappier than usual, with a thick, frost-rimed coat. |
| `pop_01101` | Iron Hold Ogre Elderborn | [[Regions/Iron Hold\|Iron Hold]] | Elderborn | B | 108 | 4.73 m | Day & Night | Like a typical Ogre, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_01102` | Frostveil Ogre Albino | [[Regions/Frostveil\|Frostveil]] | Albino | C+ | 86 | 3.5 m | Day & Night | Like a typical Ogre, but a rare pale form with white skin or fur and red eyes. |
| `pop_01103` | Iron Hold Ogre Scarred | [[Regions/Iron Hold\|Iron Hold]] | Scarred | C+ | 86 | 3.85 m | Day & Night | Like a typical Ogre, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_01104` | Vharlen Ogre Albino | [[Regions/Vharlen\|Vharlen]] | Albino | C+ | 86 | 3.5 m | Day & Night | Like a typical Ogre, but a rare pale form with white skin or fur and red eyes. |

## Design recipe

Rig `rig_large_biped` · mesh `large_biped_base` · material `thick_skin` · VFX `rock_debris` · palette `#8b5a2b` `#c2a878` `#4a4a3a` · triangle-based silhouette, sharp asymmetric spikes
