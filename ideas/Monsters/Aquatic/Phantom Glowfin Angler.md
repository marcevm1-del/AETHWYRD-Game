---
type: monster
id: mon_phantom_glowfin_angler
family: "Aquatic"
rank: "C+"
tier: variant
tags: [monster, aquatic]
---
# Phantom Glowfin Angler

![[mon_phantom_glowfin_angler_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_phantom_glowfin_angler_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (1,450 tris · 1.184 × 3 × 1.445 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Phantom Glowfin Angler is a large creature with a heavy-jawed fish frame, about 3 m long. Its scales and skin are stretched, stitched and constantly shifting, colored in warm gold and pearl white. Survivors describe a lure of light dangling over a mouth of glass teeth. It has too many eyes, opening one after another. Battle-worn plates and trophies hang from its body. It unfolds into something larger, surrounded by soft radiance and floating motes of light. Its body is translucent blue, half in the spirit world; weapons pass through it unless they are blessed or enchanted.

| Field | Value |
|---|---|
| Family · type | [[Families/Aquatic|Aquatic]] · Aquatic |
| Variant of | [[Monsters/Aquatic/Glowfin Angler\|Glowfin Angler]] (spirit) |
| Rank · level | C+ · 86 (76–96) |
| Menace | 5 · Horror |
| Element · weakness | Light · Dark |
| Size | 3 m |
| Behaviour | Swarm (swarm_surround+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 10495 · 443 · 319 · 319 · 319 · 100 |
| XP · gold | 3743 · 769 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/aquatic\|aquatic]] · `anim_fish` |
| Habitats | [[Regions/Hoshizora\|Hoshizora]], [[Regions/Kitsune Isles\|Kitsune Isles]], [[Regions/Goldmere Coast\|Goldmere Coast]] |
| Genre | Seafaring |
| Trope | Sea kings and krakens (One Piece), sirens and merfolk |

**Field note:** Weak to Dark. Dangerous in numbers. Area attacks and chokepoints help.

## Motion implementation

- **Rig:** [[Systems/Rigs/aquatic|aquatic]] (rigId); animation set `anim_fish`.
- **Dimensions:** 1.2 m high × 3 m long × 1.08 m wide; prefab scale 2.
- **Physics:** 589.9 kg, gravity ×0.9, poise 174, knockback resistance 0.39, death style `float_belly_up`.
- **Navigation:** speed 8.02 m/s, turn 231°/s, stopping distance 0.76 m.
- **Attack count:** 5; **signature:** a lure of light dangling over a mouth of glass teeth.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Bite\|Bite]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Breach Lunge\|Breach Lunge]] | dash | 1.7 | 9 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Thrash\|Thrash]] | aoe | 1.3 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Tidal Drag\|Tidal Drag]] | grab | 1.3 | 11 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Radiant Pulse\|Radiant Pulse]] | magic | 1.5 | 10 s | Light | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Phantom Glowfin Angler is a **horror aquatic** encountered at C+ rank, around level 86. Its documented behaviour is *Swarm* and its AI pattern is *swarm_surround+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Dark**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a lure of light dangling over a mouth of glass teeth. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Hoshizora|Hoshizora]], [[Regions/Kitsune Isles|Kitsune Isles]], [[Regions/Goldmere Coast|Goldmere Coast]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_fish`, animation set `anim_fish`; keep silhouette, movement and signature attack legible at gameplay camera distance.

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
| [[Regions/Kitsune Isles\|Kitsune Isles]] | 4 | B-, B+, C | 76–120 | Night |
| [[Regions/Goldmere Coast\|Goldmere Coast]] | 4 | B-, B, C- | 65–108 | Night |
| [[Regions/Hoshizora\|Hoshizora]] | 3 | B-, C+ | 86–96 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04829` | Kitsune Isles Phantom Glowfin Angler Scarred | [[Regions/Kitsune Isles\|Kitsune Isles]] | Scarred | B- | 96 | 3.3 m | Night | Like a typical Phantom Glowfin Angler, but covered in old battle scars, with salt-crusted, barnacle-flecked hide. |
| `pop_04830` | Goldmere Coast Phantom Glowfin Angler Scarred | [[Regions/Goldmere Coast\|Goldmere Coast]] | Scarred | B- | 96 | 3.3 m | Night | Like a typical Phantom Glowfin Angler, but covered in old battle scars, with salt-crusted, barnacle-flecked hide. |
| `pop_04831` | Goldmere Coast Phantom Glowfin Angler Albino | [[Regions/Goldmere Coast\|Goldmere Coast]] | Albino | B- | 96 | 3 m | Night | Like a typical Phantom Glowfin Angler, but a rare pale form with white skin or fur and red eyes. |
| `pop_04832` | Kitsune Isles Phantom Glowfin Angler Elderborn | [[Regions/Kitsune Isles\|Kitsune Isles]] | Elderborn | B+ | 120 | 4.05 m | Night | Like a typical Phantom Glowfin Angler, but old and wise, with greying features and a cautious hunting style, with salt-crusted, barnacle-flecked hide. |
| `pop_04833` | Kitsune Isles Phantom Glowfin Angler Juvenile | [[Regions/Kitsune Isles\|Kitsune Isles]] | Juvenile | C | 76 | 2.55 m | Night | Like a typical Phantom Glowfin Angler, but young, with brighter colors and unworn features, with salt-crusted, barnacle-flecked hide. |
| `pop_04834` | Kitsune Isles Phantom Glowfin Angler Albino | [[Regions/Kitsune Isles\|Kitsune Isles]] | Albino | B- | 96 | 3 m | Night | Like a typical Phantom Glowfin Angler, but a rare pale form with white skin or fur and red eyes. |
| `pop_04835` | Hoshizora Phantom Glowfin Angler Albino | [[Regions/Hoshizora\|Hoshizora]] | Albino | B- | 96 | 3 m | Night | Like a typical Phantom Glowfin Angler, but a rare pale form with white skin or fur and red eyes. |
| `pop_04836` | Goldmere Coast Phantom Glowfin Angler Alpha | [[Regions/Goldmere Coast\|Goldmere Coast]] | Alpha | B | 108 | 3.75 m | Night | Like a typical Phantom Glowfin Angler, but larger and scarred, and others of its kind follow it, with salt-crusted, barnacle-flecked hide. |
| `pop_04837` | Hoshizora Phantom Glowfin Angler | [[Regions/Hoshizora\|Hoshizora]] | Adult | C+ | 86 | 3 m | Night | A typical adult Phantom Glowfin Angler of this region, with salt-crusted, barnacle-flecked hide. |
| `pop_04838` | Goldmere Coast Phantom Glowfin Angler Runt | [[Regions/Goldmere Coast\|Goldmere Coast]] | Runt | C- | 65 | 2.1 m | Night | Like a typical Phantom Glowfin Angler, but smaller and scrappier than usual, with salt-crusted, barnacle-flecked hide. |
| `pop_04839` | Hoshizora Phantom Glowfin Angler Scarred | [[Regions/Hoshizora\|Hoshizora]] | Scarred | B- | 96 | 3.3 m | Night | Like a typical Phantom Glowfin Angler, but covered in old battle scars, with salt-crusted, barnacle-flecked hide. |

## Design recipe

Rig `rig_fish` · mesh `fish_base` · material `wet_scale` · VFX `holy_motes` · palette `#fff3b0` `#ffd166` `#ffffff` · broken symmetry, mimicry, audio-first reveal
