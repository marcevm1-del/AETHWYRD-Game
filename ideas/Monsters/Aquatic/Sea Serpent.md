---
type: monster
id: mon_sea_serpent
family: "Aquatic"
rank: "C"
tier: core
tags: [monster, aquatic]
---
# Sea Serpent

![[mon_sea_serpent_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_sea_serpent_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (3,816 tris · 5.324 × 20 × 8.698 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Sea Serpent is a colossal creature with a long, sinuous serpentine body, about 20 m long. Its scales and skin are rough, scarred and spiked, colored in silver, with sea-blue markings. Look for a long fin running down its spine. It has narrow glowing eyes. Battle-worn plates and trophies hang from its body. It circles its prey, surrounded by fine mist and droplets that orbit it.

| Field | Value |
|---|---|
| Family · type | [[Families/Aquatic|Aquatic]] · Aquatic |
| Rank · level | C · 76 (65–86) |
| Menace | 3 · Menacing |
| Element · weakness | Water · Lightning |
| Size | 20 m |
| Behaviour | Swarm (swarm_surround) |
| HP · ATK · DEF · MATK · MDEF · SPD | 12935 · 314 · 251 · 220 · 251 · 135 |
| XP · gold | 3073 · 648 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/serpent\|serpent]] · `anim_serpent` |
| Habitats | [[Regions/Goldmere Coast\|Goldmere Coast]], [[Regions/True-Name Isles\|True-Name Isles]], [[Regions/Hoshizora\|Hoshizora]], [[Regions/Lirian\|Lirian]], [[Regions/Greymoor\|Greymoor]] |
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

Sea Serpent is a **menacing aquatic** encountered at C rank, around level 76. Its documented behaviour is *Swarm* and its AI pattern is *swarm_surround*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Lightning**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a long fin running down its spine. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Goldmere Coast|Goldmere Coast]], [[Regions/True-Name Isles|True-Name Isles]], [[Regions/Hoshizora|Hoshizora]], [[Regions/Lirian|Lirian]], [[Regions/Greymoor|Greymoor]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_serpent`, animation set `anim_serpent`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Aquatic C|loot_aquatic_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Fish Scale\|Fish Scale]] | 60% | 1–3 |
| [[Items/Pearl\|Pearl]] | 30% | 1–1 |
| [[Items/Ink Sac\|Ink Sac]] | 15% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Aquatic/Abyssal Sea Serpent|Abyssal Sea Serpent]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Hoshizora\|Hoshizora]] | 3 | B, C+, B- | 86–108 | Day & Night |
| [[Regions/True-Name Isles\|True-Name Isles]] | 4 | B, C-, C+, B- | 65–108 | Day & Night |
| [[Regions/Lirian\|Lirian]] | 2 | B, C | 76–108 | Day & Night |
| [[Regions/Goldmere Coast\|Goldmere Coast]] | 2 | C-, B- | 65–96 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01974` | Hoshizora Sea Serpent Elderborn | [[Regions/Hoshizora\|Hoshizora]] | Elderborn | B | 108 | 27 m | Day & Night | Like a typical Sea Serpent, but old and wise, with greying features and a cautious hunting style, with salt-crusted, barnacle-flecked hide. |
| `pop_01975` | True-Name Isles Sea Serpent Elderborn | [[Regions/True-Name Isles\|True-Name Isles]] | Elderborn | B | 108 | 27 m | Day & Night | Like a typical Sea Serpent, but old and wise, with greying features and a cautious hunting style, with salt-crusted, barnacle-flecked hide. |
| `pop_01976` | Lirian Sea Serpent Elderborn | [[Regions/Lirian\|Lirian]] | Elderborn | B | 108 | 27 m | Day & Night | Like a typical Sea Serpent, but old and wise, with greying features and a cautious hunting style, with salt-crusted, barnacle-flecked hide. |
| `pop_01977` | True-Name Isles Sea Serpent Juvenile | [[Regions/True-Name Isles\|True-Name Isles]] | Juvenile | C- | 65 | 17 m | Day & Night | Like a typical Sea Serpent, but young, with brighter colors and unworn features, with salt-crusted, barnacle-flecked hide. |
| `pop_01978` | Hoshizora Sea Serpent Albino | [[Regions/Hoshizora\|Hoshizora]] | Albino | C+ | 86 | 20 m | Day & Night | Like a typical Sea Serpent, but a rare pale form with white skin or fur and red eyes. |
| `pop_01979` | True-Name Isles Sea Serpent Albino | [[Regions/True-Name Isles\|True-Name Isles]] | Albino | C+ | 86 | 20 m | Day & Night | Like a typical Sea Serpent, but a rare pale form with white skin or fur and red eyes. |
| `pop_01980` | True-Name Isles Sea Serpent Alpha | [[Regions/True-Name Isles\|True-Name Isles]] | Alpha | B- | 96 | 25 m | Day & Night | Like a typical Sea Serpent, but larger and scarred, and others of its kind follow it, with salt-crusted, barnacle-flecked hide. |
| `pop_01981` | Hoshizora Sea Serpent Alpha | [[Regions/Hoshizora\|Hoshizora]] | Alpha | B- | 96 | 25 m | Day & Night | Like a typical Sea Serpent, but larger and scarred, and others of its kind follow it, with salt-crusted, barnacle-flecked hide. |
| `pop_01982` | Lirian Sea Serpent | [[Regions/Lirian\|Lirian]] | Adult | C | 76 | 20 m | Day & Night | A typical adult Sea Serpent of this region, with salt-crusted, barnacle-flecked hide. |
| `pop_01983` | Goldmere Coast Sea Serpent Juvenile | [[Regions/Goldmere Coast\|Goldmere Coast]] | Juvenile | C- | 65 | 17 m | Day & Night | Like a typical Sea Serpent, but young, with brighter colors and unworn features, with salt-crusted, barnacle-flecked hide. |
| `pop_01984` | Goldmere Coast Sea Serpent Alpha | [[Regions/Goldmere Coast\|Goldmere Coast]] | Alpha | B- | 96 | 25 m | Day & Night | Like a typical Sea Serpent, but larger and scarred, and others of its kind follow it, with salt-crusted, barnacle-flecked hide. |

## Design recipe

Rig `rig_serpent` · mesh `serpent_base` · material `wet_scale` · VFX `mist_droplets` · palette `#9baab1` `#64727a` `#4fa8e8` · triangle-based silhouette, sharp asymmetric spikes
