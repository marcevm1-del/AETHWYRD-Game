---
type: monster
id: mon_giant_octopus
family: "Aquatic"
rank: "B"
tier: core
tags: [monster, aquatic]
---
# Giant Octopus

![[mon_giant_octopus_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_giant_octopus_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (1,648 tris · 9.626 × 10 × 10.147 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Giant Octopus is a huge creature with a huge many-armed sea body, about 10 m long. Its scales and skin are rough, scarred and spiked, colored in deep blues with a glassy shine. Look for skin that changes color to match the rocks. It has burning slit pupils. Faint runes glow along its body when it fights. It charges without hesitation, surrounded by fine mist and droplets that orbit it.

| Field | Value |
|---|---|
| Family · type | [[Families/Aquatic|Aquatic]] · Aquatic |
| Rank · level | B · 108 (96–120) |
| Menace | 3 · Menacing |
| Element · weakness | Water · Lightning |
| Size | 10 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 21407 · 553 · 398 · 398 · 398 · 100 |
| XP · gold | 5386 · 1057 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/tentacled\|tentacled]] · `anim_cephalopod` |
| Habitats | [[Regions/Whitewater Reach\|Whitewater Reach]], [[Regions/Goldmere Coast\|Goldmere Coast]], [[Regions/True-Name Isles\|True-Name Isles]] |
| Genre | Seafaring |
| Trope | Sea kings and krakens (One Piece), sirens and merfolk |

**Field note:** Weak to Lightning. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/tentacled|tentacled]] (rigId); animation set `anim_cephalopod`.
- **Dimensions:** 5.5 m high × 10 m long × 12 m wide; prefab scale 3.333.
- **Physics:** 21000 kg, gravity ×1, poise 868, knockback resistance 0.82, death style `sink_limp`.
- **Navigation:** speed 11.39 m/s, turn 95°/s, stopping distance 2.4 m.
- **Attack count:** 5; **signature:** skin that changes color to match the rocks.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Tentacle Slap\|Tentacle Slap]] | melee | 1.1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Drag Under\|Drag Under]] | grab | 1.8 | 12 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Ink Cloud\|Ink Cloud]] | debuff | 0 | 14 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Tidal Drag\|Tidal Drag]] | grab | 1.3 | 11 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Tide Lash\|Tide Lash]] | magic | 1.5 | 10 s | Water | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Giant Octopus is a **menacing aquatic** encountered at B rank, around level 108. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Lightning**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** skin that changes color to match the rocks. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Whitewater Reach|Whitewater Reach]], [[Regions/Goldmere Coast|Goldmere Coast]], [[Regions/True-Name Isles|True-Name Isles]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_cephalopod`, animation set `anim_cephalopod`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Aquatic B|loot_aquatic_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Fish Scale\|Fish Scale]] | 60% | 1–3 |
| [[Items/Pearl\|Pearl]] | 30% | 1–1 |
| [[Items/Ink Sac\|Ink Sac]] | 15% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Aquatic/Reef Octopus|Reef Octopus]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Goldmere Coast\|Goldmere Coast]] | 2 | B-, C+ | 86–96 | Day & Night |
| [[Regions/True-Name Isles\|True-Name Isles]] | 5 | A-, B+, C+, A | 86–146 | Day & Night |
| [[Regions/Whitewater Reach\|Whitewater Reach]] | 4 | B, B+, A-, A | 108–146 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01996` | Goldmere Coast Giant Octopus Juvenile | [[Regions/Goldmere Coast\|Goldmere Coast]] | Juvenile | B- | 96 | 8.5 m | Day & Night | Like a typical Giant Octopus, but young, with brighter colors and unworn features, with salt-crusted, barnacle-flecked hide. |
| `pop_01997` | True-Name Isles Giant Octopus Alpha | [[Regions/True-Name Isles\|True-Name Isles]] | Alpha | A- | 132 | 12.5 m | Day & Night | Like a typical Giant Octopus, but larger and scarred, and others of its kind follow it, with salt-crusted, barnacle-flecked hide. |
| `pop_01998` | Goldmere Coast Giant Octopus Runt | [[Regions/Goldmere Coast\|Goldmere Coast]] | Runt | C+ | 86 | 7 m | Day & Night | Like a typical Giant Octopus, but smaller and scrappier than usual, with salt-crusted, barnacle-flecked hide. |
| `pop_01999` | Whitewater Reach Giant Octopus | [[Regions/Whitewater Reach\|Whitewater Reach]] | Adult | B | 108 | 10 m | Day & Night | A typical adult Giant Octopus of this region, with salt-crusted, barnacle-flecked hide. |
| `pop_02000` | Whitewater Reach Giant Octopus Scarred | [[Regions/Whitewater Reach\|Whitewater Reach]] | Scarred | B+ | 120 | 11 m | Day & Night | Like a typical Giant Octopus, but covered in old battle scars, with salt-crusted, barnacle-flecked hide. |
| `pop_02001` | Whitewater Reach Giant Octopus Alpha | [[Regions/Whitewater Reach\|Whitewater Reach]] | Alpha | A- | 132 | 12.5 m | Day & Night | Like a typical Giant Octopus, but larger and scarred, and others of its kind follow it, with salt-crusted, barnacle-flecked hide. |
| `pop_02002` | True-Name Isles Giant Octopus Albino | [[Regions/True-Name Isles\|True-Name Isles]] | Albino | B+ | 120 | 10 m | Day & Night | Like a typical Giant Octopus, but a rare pale form with white skin or fur and red eyes. |
| `pop_02003` | Whitewater Reach Giant Octopus Elderborn | [[Regions/Whitewater Reach\|Whitewater Reach]] | Elderborn | A | 146 | 13.5 m | Day & Night | Like a typical Giant Octopus, but old and wise, with greying features and a cautious hunting style, with salt-crusted, barnacle-flecked hide. |
| `pop_02004` | True-Name Isles Giant Octopus Runt | [[Regions/True-Name Isles\|True-Name Isles]] | Runt | C+ | 86 | 7 m | Day & Night | Like a typical Giant Octopus, but smaller and scrappier than usual, with salt-crusted, barnacle-flecked hide. |
| `pop_02005` | True-Name Isles Giant Octopus Scarred | [[Regions/True-Name Isles\|True-Name Isles]] | Scarred | B+ | 120 | 11 m | Day & Night | Like a typical Giant Octopus, but covered in old battle scars, with salt-crusted, barnacle-flecked hide. |
| `pop_02006` | True-Name Isles Giant Octopus Elderborn | [[Regions/True-Name Isles\|True-Name Isles]] | Elderborn | A | 146 | 13.5 m | Day & Night | Like a typical Giant Octopus, but old and wise, with greying features and a cautious hunting style, with salt-crusted, barnacle-flecked hide. |

## Design recipe

Rig `rig_cephalopod` · mesh `cephalopod_base` · material `wet_scale` · VFX `mist_droplets` · palette `#2f7fd1` `#9ad7ff` `#123a5c` · triangle-based silhouette, sharp asymmetric spikes
