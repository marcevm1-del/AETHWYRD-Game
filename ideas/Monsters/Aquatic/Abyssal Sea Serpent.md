---
type: monster
id: mon_abyssal_sea_serpent
family: "Aquatic"
rank: "C+"
tier: variant
tags: [monster, aquatic]
---
# Abyssal Sea Serpent

![[mon_abyssal_sea_serpent_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_abyssal_sea_serpent_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Abyssal Sea Serpent is a colossal creature with a massive snake-like frame, about 20 m long. Its scales and skin are rough, scarred and spiked, colored in deep blues with a glassy shine. Guild sketches always show a long fin running down its spine. It has narrow glowing eyes. Battle-worn plates and trophies hang from its body. It strides with heavy steps, surrounded by fine mist and droplets that orbit it. Adapted to sea lands, it has deep-water coloring and glowing lures.

| Field | Value |
|---|---|
| Family · type | [[Families/Aquatic|Aquatic]] · Aquatic |
| Variant of | [[Monsters/Aquatic/Sea Serpent\|Sea Serpent]] (regional) |
| Rank · level | C+ · 86 (76–96) |
| Menace | 3 · Menacing |
| Element · weakness | Water · Lightning |
| Size | 20 m |
| Behaviour | Swarm (swarm_surround) |
| HP · ATK · DEF · MATK · MDEF · SPD | 15544 · 354 · 283 · 248 · 283 · 135 |
| XP · gold | 3743 · 769 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/serpent\|serpent]] · `anim_serpent` |
| Habitats | [[Regions/True-Name Isles\|True-Name Isles]], [[Regions/Goldmere Coast\|Goldmere Coast]] |
| Genre | Seafaring |
| Trope | Sea kings and krakens (One Piece), sirens and merfolk |

**Field note:** Weak to Lightning. Dangerous in numbers. Area attacks and chokepoints help.

## Motion implementation

- **Rig:** [[Systems/Rigs/serpent|serpent]] (rigId); animation set `anim_serpent`.
- **Dimensions:** 0.8 m high × 20 m long × 2 m wide; prefab scale 5.
- **Physics:** 19320 kg, gravity ×1.2, poise 937, knockback resistance 0.49, death style `limp_chain`.
- **Navigation:** speed 13.1 m/s, turn 67°/s, stopping distance 1.1 m.
- **Attack count:** 5; **signature:** a long fin running down its spine.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Strike\|Strike]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Constrict\|Constrict]] | grab | 1.8 | 12 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Tail Sweep\|Tail Sweep]] | aoe | 1.2 | 7 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Tidal Drag\|Tidal Drag]] | grab | 1.3 | 11 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Tide Lash\|Tide Lash]] | magic | 1.5 | 10 s | Water | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Abyssal Sea Serpent is a **menacing aquatic** encountered at C+ rank, around level 86. Its documented behaviour is *Swarm* and its AI pattern is *swarm_surround*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Lightning**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a long fin running down its spine. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/True-Name Isles|True-Name Isles]], [[Regions/Goldmere Coast|Goldmere Coast]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_serpent`, animation set `anim_serpent`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Aquatic C|loot_aquatic_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Fish Scale\|Fish Scale]] | 60% | 1–3 |
| [[Items/Pearl\|Pearl]] | 30% | 1–1 |
| [[Items/Ink Sac\|Ink Sac]] | 15% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/True-Name Isles\|True-Name Isles]] | 6 | C-, C, B-, B, B+ | 65–120 | Day & Night |
| [[Regions/Goldmere Coast\|Goldmere Coast]] | 5 | B, B+, B-, C+ | 86–120 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04840` | True-Name Isles Abyssal Sea Serpent Runt | [[Regions/True-Name Isles\|True-Name Isles]] | Runt | C- | 65 | 14 m | Day & Night | Like a typical Abyssal Sea Serpent, but smaller and scrappier than usual, with salt-crusted, barnacle-flecked hide. |
| `pop_04841` | Goldmere Coast Abyssal Sea Serpent Alpha | [[Regions/Goldmere Coast\|Goldmere Coast]] | Alpha | B | 108 | 25 m | Day & Night | Like a typical Abyssal Sea Serpent, but larger and scarred, and others of its kind follow it, with salt-crusted, barnacle-flecked hide. |
| `pop_04842` | True-Name Isles Abyssal Sea Serpent Juvenile | [[Regions/True-Name Isles\|True-Name Isles]] | Juvenile | C | 76 | 17 m | Day & Night | Like a typical Abyssal Sea Serpent, but young, with brighter colors and unworn features, with salt-crusted, barnacle-flecked hide. |
| `pop_04843` | True-Name Isles Abyssal Sea Serpent Scarred | [[Regions/True-Name Isles\|True-Name Isles]] | Scarred | B- | 96 | 22 m | Day & Night | Like a typical Abyssal Sea Serpent, but covered in old battle scars, with salt-crusted, barnacle-flecked hide. |
| `pop_04844` | True-Name Isles Abyssal Sea Serpent Alpha | [[Regions/True-Name Isles\|True-Name Isles]] | Alpha | B | 108 | 25 m | Day & Night | Like a typical Abyssal Sea Serpent, but larger and scarred, and others of its kind follow it, with salt-crusted, barnacle-flecked hide. |
| `pop_04845` | True-Name Isles Abyssal Sea Serpent Elderborn | [[Regions/True-Name Isles\|True-Name Isles]] | Elderborn | B+ | 120 | 27 m | Day & Night | Like a typical Abyssal Sea Serpent, but old and wise, with greying features and a cautious hunting style, with salt-crusted, barnacle-flecked hide. |
| `pop_04846` | True-Name Isles Abyssal Sea Serpent Albino | [[Regions/True-Name Isles\|True-Name Isles]] | Albino | B- | 96 | 20 m | Day & Night | Like a typical Abyssal Sea Serpent, but a rare pale form with white skin or fur and red eyes. |
| `pop_04847` | Goldmere Coast Abyssal Sea Serpent Elderborn | [[Regions/Goldmere Coast\|Goldmere Coast]] | Elderborn | B+ | 120 | 27 m | Day & Night | Like a typical Abyssal Sea Serpent, but old and wise, with greying features and a cautious hunting style, with salt-crusted, barnacle-flecked hide. |
| `pop_04848` | Goldmere Coast Abyssal Sea Serpent Albino | [[Regions/Goldmere Coast\|Goldmere Coast]] | Albino | B- | 96 | 20 m | Day & Night | Like a typical Abyssal Sea Serpent, but a rare pale form with white skin or fur and red eyes. |
| `pop_04849` | Goldmere Coast Abyssal Sea Serpent | [[Regions/Goldmere Coast\|Goldmere Coast]] | Adult | C+ | 86 | 20 m | Day & Night | A typical adult Abyssal Sea Serpent of this region, with salt-crusted, barnacle-flecked hide. |
| `pop_04850` | Goldmere Coast Abyssal Sea Serpent Scarred | [[Regions/Goldmere Coast\|Goldmere Coast]] | Scarred | B- | 96 | 22 m | Day & Night | Like a typical Abyssal Sea Serpent, but covered in old battle scars, with salt-crusted, barnacle-flecked hide. |

## Design recipe

Rig `rig_serpent` · mesh `serpent_base` · material `wet_scale` · VFX `mist_droplets` · palette `#2f7fd1` `#9ad7ff` `#123a5c` · triangle-based silhouette, sharp asymmetric spikes
