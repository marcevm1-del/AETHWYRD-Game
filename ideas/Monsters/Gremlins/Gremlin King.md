---
type: monster
id: mon_gremlin_king
family: "Gremlins"
rank: "C"
tier: core
tags: [monster, gremlins]
---
# Gremlin King

![[mon_gremlin_king_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_gremlin_king_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,324 tris · 0.593 × 0.601 × 1.2 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Gremlin King is a person-sized creature with a small, compact humanoid body, about 1.2 m tall. Its skin is rough, scarred and spiked, colored in lime-green, with electric-yellow markings. Its most striking feature is a throne bolted onto a walking boiler. It has eyes that catch torchlight like coins. Battle-worn plates and trophies hang from its body. It charges without hesitation, surrounded by crackling arcs that jump across its body.

| Field | Value |
|---|---|
| Family · type | [[Families/Gremlins|Gremlins]] · Fey Pest |
| Rank · level | C · 76 (65–86) |
| Menace | 3 · Menacing |
| Element · weakness | Lightning · Earth |
| Size | 1.2 m |
| Behaviour | Swarm (swarm_surround) |
| HP · ATK · DEF · MATK · MDEF · SPD | 5436 · 314 · 251 · 220 · 251 · 135 |
| XP · gold | 3073 · 648 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/small_biped\|small_biped]] · `anim_small_biped` |
| Habitats | [[Regions/Haneul\|Haneul]], [[Regions/Lirian\|Lirian]], [[Regions/Zarvan\|Zarvan]], [[Regions/Bastion\|Bastion]] |
| Genre | Steampunk Mischief |
| Trope | Machine-breaking pests |

**Field note:** Weak to Earth. Dangerous in numbers. Area attacks and chokepoints help.

## Motion implementation

- **Rig:** [[Systems/Rigs/small_biped|small_biped]] (rigId); animation set `anim_small_biped`.
- **Dimensions:** 1.2 m high × 0.36 m long × 0.48 m wide; prefab scale 1.091.
- **Physics:** 27.6 kg, gravity ×1.5, poise 45, knockback resistance 0.24, death style `ragdoll_crumple`.
- **Navigation:** speed 6.01 m/s, turn 383°/s, stopping distance 0.64 m.
- **Attack count:** 5; **signature:** a throne bolted onto a walking boiler.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stab\|Stab]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Thrown Junk\|Thrown Junk]] | ranged | 0.8 | 4 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Frenzied Lunge\|Frenzied Lunge]] | melee | 1.5 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Wrench Sabotage\|Wrench Sabotage]] | debuff | 0 | 14 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Static Arc\|Static Arc]] | magic | 1.5 | 10 s | Lightning | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Gremlin King is a **menacing fey pest** encountered at C rank, around level 76. Its documented behaviour is *Swarm* and its AI pattern is *swarm_surround*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Earth**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a throne bolted onto a walking boiler. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Haneul|Haneul]], [[Regions/Lirian|Lirian]], [[Regions/Zarvan|Zarvan]], [[Regions/Bastion|Bastion]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_small_biped`, animation set `anim_small_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Gremlins C|loot_gremlin_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Stolen Bolt\|Stolen Bolt]] | 60% | 1–3 |
| [[Items/Gremlin Ear\|Gremlin Ear]] | 30% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Gremlins/Ruin Gremlin King|Ruin Gremlin King]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Zarvan\|Zarvan]] | 2 | C+, B- | 86–96 | Day & Night |
| [[Regions/Bastion\|Bastion]] | 3 | C-, B-, C+ | 65–96 | Day & Night |
| [[Regions/Haneul\|Haneul]] | 4 | C+, C-, B-, B | 65–108 | Day & Night |
| [[Regions/Lirian\|Lirian]] | 2 | C+, B- | 86–96 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02384` | Zarvan Gremlin King Albino | [[Regions/Zarvan\|Zarvan]] | Albino | C+ | 86 | 1.2 m | Day & Night | Like a typical Gremlin King, but a rare pale form with white skin or fur and red eyes. |
| `pop_02385` | Bastion Gremlin King Juvenile | [[Regions/Bastion\|Bastion]] | Juvenile | C- | 65 | 1.02 m | Day & Night | Like a typical Gremlin King, but young, with brighter colors and unworn features, with soot-stained hide and scavenged scraps. |
| `pop_02386` | Bastion Gremlin King Alpha | [[Regions/Bastion\|Bastion]] | Alpha | B- | 96 | 1.5 m | Day & Night | Like a typical Gremlin King, but larger and scarred, and others of its kind follow it, with soot-stained hide and scavenged scraps. |
| `pop_02387` | Haneul Gremlin King Scarred | [[Regions/Haneul\|Haneul]] | Scarred | C+ | 86 | 1.32 m | Day & Night | Like a typical Gremlin King, but covered in old battle scars, with soot-stained hide and scavenged scraps. |
| `pop_02388` | Haneul Gremlin King Juvenile | [[Regions/Haneul\|Haneul]] | Juvenile | C- | 65 | 1.02 m | Day & Night | Like a typical Gremlin King, but young, with brighter colors and unworn features, with soot-stained hide and scavenged scraps. |
| `pop_02389` | Haneul Gremlin King Alpha | [[Regions/Haneul\|Haneul]] | Alpha | B- | 96 | 1.5 m | Day & Night | Like a typical Gremlin King, but larger and scarred, and others of its kind follow it, with soot-stained hide and scavenged scraps. |
| `pop_02390` | Lirian Gremlin King Scarred | [[Regions/Lirian\|Lirian]] | Scarred | C+ | 86 | 1.32 m | Day & Night | Like a typical Gremlin King, but covered in old battle scars, with soot-stained hide and scavenged scraps. |
| `pop_02391` | Bastion Gremlin King Scarred | [[Regions/Bastion\|Bastion]] | Scarred | C+ | 86 | 1.32 m | Day & Night | Like a typical Gremlin King, but covered in old battle scars, with soot-stained hide and scavenged scraps. |
| `pop_02392` | Zarvan Gremlin King Alpha | [[Regions/Zarvan\|Zarvan]] | Alpha | B- | 96 | 1.5 m | Day & Night | Like a typical Gremlin King, but larger and scarred, and others of its kind follow it, with soot-stained hide and scavenged scraps. |
| `pop_02393` | Lirian Gremlin King Alpha | [[Regions/Lirian\|Lirian]] | Alpha | B- | 96 | 1.5 m | Day & Night | Like a typical Gremlin King, but larger and scarred, and others of its kind follow it, with soot-stained hide and scavenged scraps. |
| `pop_02394` | Haneul Gremlin King Elderborn | [[Regions/Haneul\|Haneul]] | Elderborn | B | 108 | 1.62 m | Day & Night | Like a typical Gremlin King, but old and wise, with greying features and a cautious hunting style, with soot-stained hide and scavenged scraps. |

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `rubbery_skin` · VFX `arc_sparks` · palette `#6e9d49` `#46682f` `#ffe14d` · triangle-based silhouette, sharp asymmetric spikes
