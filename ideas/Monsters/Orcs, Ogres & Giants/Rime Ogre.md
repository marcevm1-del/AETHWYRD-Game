---
type: monster
id: mon_rime_ogre
family: "Orcs, Ogres & Giants"
rank: "C+"
tier: variant
tags: [monster, orcs-ogres-giants]
---
# Rime Ogre

> The Rime Ogre is a large creature with a giant, barrel-chested humanoid body, about 3.5 m tall. Its hide is rough, scarred and spiked, colored in pale blues and frost-white. Survivors describe a sagging belly, a tree-trunk club and a toll sack. It has eyes that catch torchlight like coins. Battle-worn plates and trophies hang from its body. It charges without hesitation, surrounded by falling snow motes and frosted ground where it steps. Adapted to tundra lands, it has a thick, frost-rimed coat.

| Field | Value |
|---|---|
| Family · type | [[Families/Orcs, Ogres & Giants|Orcs, Ogres & Giants]] · Giant |
| Variant of | [[Monsters/Orcs, Ogres & Giants/Ogre\|Ogre]] (regional) |
| Rank · level | C+ · 86 (76–96) |
| Menace | 3 · Menacing |
| Element · weakness | Ice · Fire |
| Size | 3.5 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 15468 · 354 · 531 · 212 · 354 · 70 |
| XP · gold | 3743 · 769 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/large_biped\|large_biped]] · `anim_large_biped` |
| Habitats | [[Regions/Iron Hold\|Iron Hold]], [[Regions/Vharlen\|Vharlen]], [[Regions/Frostveil\|Frostveil]] |
| Genre | Classic Fantasy |
| Trope | Orc warbands and the Orc Disaster that devours its way to power (Tensura) |

**Field note:** Weak to Fire. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/large_biped|large_biped]] (rigId); animation set `anim_large_biped`.
- **Dimensions:** 3.5 m high × 1.05 m long × 1.47 m wide; prefab scale 1.
- **Physics:** 848.9 kg, gravity ×1.37, poise 203, knockback resistance 0.84, death style `heavy_fall_dust`.
- **Navigation:** speed 5.79 m/s, turn 203°/s, stopping distance 1.1 m.
- **Attack count:** 5; **signature:** a sagging belly, a tree-trunk club and a toll sack.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stomp\|Stomp]] | aoe | 1.3 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Club Slam\|Club Slam]] | melee | 1.8 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Grab and Throw\|Grab and Throw]] | grab | 2 | 14 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/War Cry\|War Cry]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Frost Breath\|Frost Breath]] | magic | 1.5 | 10 s | Ice | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Rime Ogre is a **menacing giant** encountered at C+ rank, around level 86. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a sagging belly, a tree-trunk club and a toll sack. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Iron Hold|Iron Hold]], [[Regions/Vharlen|Vharlen]], [[Regions/Frostveil|Frostveil]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_large_biped`, animation set `anim_large_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Orcs, Ogres & Giants C|loot_orc_giant_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Tusk\|Tusk]] | 60% | 1–3 |
| [[Items/Giant's Hide\|Giant's Hide]] | 30% | 1–1 |
| [[Items/Crude Iron\|Crude Iron]] | 15% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Frostveil\|Frostveil]] | 2 | C+, B+ | 86–120 | Day & Night |
| [[Regions/Iron Hold\|Iron Hold]] | 5 | B-, C+, C-, B, C | 65–108 | Day & Night |
| [[Regions/Vharlen\|Vharlen]] | 4 | C+, B, B-, C | 76–108 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03991` | Frostveil Rime Ogre | [[Regions/Frostveil\|Frostveil]] | Adult | C+ | 86 | 3.5 m | Day & Night | A typical adult Rime Ogre of this region, with a thick, frost-rimed coat. |
| `pop_03992` | Iron Hold Rime Ogre Scarred | [[Regions/Iron Hold\|Iron Hold]] | Scarred | B- | 96 | 3.85 m | Day & Night | Like a typical Rime Ogre, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_03993` | Vharlen Rime Ogre | [[Regions/Vharlen\|Vharlen]] | Adult | C+ | 86 | 3.5 m | Day & Night | A typical adult Rime Ogre of this region, with golden, grass-toned coloring. |
| `pop_03994` | Iron Hold Rime Ogre | [[Regions/Iron Hold\|Iron Hold]] | Adult | C+ | 86 | 3.5 m | Day & Night | A typical adult Rime Ogre of this region, with slate-grey coloring and hardened hide. |
| `pop_03995` | Vharlen Rime Ogre Alpha | [[Regions/Vharlen\|Vharlen]] | Alpha | B | 108 | 4.38 m | Day & Night | Like a typical Rime Ogre, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_03996` | Iron Hold Rime Ogre Runt | [[Regions/Iron Hold\|Iron Hold]] | Runt | C- | 65 | 2.45 m | Day & Night | Like a typical Rime Ogre, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_03997` | Iron Hold Rime Ogre Alpha | [[Regions/Iron Hold\|Iron Hold]] | Alpha | B | 108 | 4.38 m | Day & Night | Like a typical Rime Ogre, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_03998` | Frostveil Rime Ogre Elderborn | [[Regions/Frostveil\|Frostveil]] | Elderborn | B+ | 120 | 4.73 m | Day & Night | Like a typical Rime Ogre, but old and wise, with greying features and a cautious hunting style, with a thick, frost-rimed coat. |
| `pop_03999` | Vharlen Rime Ogre Scarred | [[Regions/Vharlen\|Vharlen]] | Scarred | B- | 96 | 3.85 m | Day & Night | Like a typical Rime Ogre, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_04000` | Iron Hold Rime Ogre Juvenile | [[Regions/Iron Hold\|Iron Hold]] | Juvenile | C | 76 | 2.98 m | Day & Night | Like a typical Rime Ogre, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_04001` | Vharlen Rime Ogre Juvenile | [[Regions/Vharlen\|Vharlen]] | Juvenile | C | 76 | 2.98 m | Day & Night | Like a typical Rime Ogre, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |

## Design recipe

Rig `rig_large_biped` · mesh `large_biped_base` · material `thick_skin` · VFX `frost_trail_snow` · palette `#bfe9ff` `#5fa8d3` `#f4fbff` · triangle-based silhouette, sharp asymmetric spikes
