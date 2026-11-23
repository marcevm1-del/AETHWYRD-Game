---
type: monster
id: mon_ancient_thunder_drake
family: "Dragons"
rank: "C"
tier: variant
tags: [monster, dragons]
---
# Ancient Thunder Drake

![[mon_ancient_thunder_drake_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_ancient_thunder_drake_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 19,998 tris · 1.499 × 4.5 × 1.126 m · local file `Game/Assets/_Game/Art/Models/Monsters/Dragons/mon_ancient_thunder_drake.fbx`

> The Ancient Thunder Drake is a large creature with a heavy, muscular quadruped frame, about 4.5 m long. Its scales are rough, scarred and spiked, colored in iron-grey, with electric-yellow markings. Look for horns that work like lightning rods. It has narrow glowing eyes. Battle-worn plates and trophies hang from its body. It circles its prey, surrounded by crackling arcs that jump across its body. Moss, crystals and centuries-old scars cover its body; it has outlived every hunter sent after it.

| Field | Value |
|---|---|
| Family · type | [[Families/Dragons|Dragons]] · Dragon |
| Variant of | [[Monsters/Dragons/Thunder Drake\|Thunder Drake]] (ancient) |
| Rank · level | C · 76 (65–86) |
| Menace | 3 · Menacing |
| Element · weakness | Lightning · Earth |
| Size | 4.5 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 10976 · 377 · 314 · 251 · 283 · 100 |
| XP · gold | 3073 · 648 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/quad_large\|quad_large]] · `anim_quad_large` |
| Habitats | [[Regions/Stormreach\|Stormreach]], [[Regions/Hoshizora\|Hoshizora]], [[Regions/Frostveil\|Frostveil]] |
| Genre | High Fantasy |
| Trope | Dragons as proud, intelligent apex beings; wyverns as their lesser kin |

**Field note:** Weak to Earth. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_large|quad_large]] (rigId); animation set `anim_quad_large`.
- **Dimensions:** 2.93 m high × 4.5 m long × 0.72 m wide; prefab scale 1.125.
- **Physics:** 1822.5 kg, gravity ×1.2, poise 108, knockback resistance 0.94, death style `heavy_fall_dust`.
- **Navigation:** speed 9.73 m/s, turn 151°/s, stopping distance 1.3 m.
- **Attack count:** 5; **signature:** horns that work like lightning rods.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Maul\|Maul]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Pounce\|Pounce]] | dash | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Howl\|Howl]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Wing Buffet\|Wing Buffet]] | aoe | 1.1 | 9 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Static Arc\|Static Arc]] | magic | 1.5 | 10 s | Lightning | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Ancient Thunder Drake is a **menacing dragon** encountered at C rank, around level 76. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Earth**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** horns that work like lightning rods. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Stormreach|Stormreach]], [[Regions/Hoshizora|Hoshizora]], [[Regions/Frostveil|Frostveil]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_large`, animation set `anim_quad_large`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Dragons C|loot_draconic_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Dragon Scale\|Dragon Scale]] | 60% | 1–3 |
| [[Items/Dragon Blood\|Dragon Blood]] | 30% | 1–1 |
| [[Items/Dragon Heart\|Dragon Heart]] | 15% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Frostveil\|Frostveil]] | 5 | D+, C+, C, C- | 56–86 | Day & Night |
| [[Regions/Hoshizora\|Hoshizora]] | 3 | C+, B-, B | 86–108 | Day & Night |
| [[Regions/Stormreach\|Stormreach]] | 3 | C, C+, D+ | 56–86 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04263` | Frostveil Ancient Thunder Drake Runt | [[Regions/Frostveil\|Frostveil]] | Runt | D+ | 56 | 3.15 m | Day & Night | Like a typical Ancient Thunder Drake, but smaller and scrappier than usual, with a thick, frost-rimed coat. |
| `pop_04264` | Hoshizora Ancient Thunder Drake Albino | [[Regions/Hoshizora\|Hoshizora]] | Albino | C+ | 86 | 4.5 m | Day & Night | Like a typical Ancient Thunder Drake, but a rare pale form with white skin or fur and red eyes. |
| `pop_04265` | Stormreach Ancient Thunder Drake | [[Regions/Stormreach\|Stormreach]] | Adult | C | 76 | 4.5 m | Day & Night | A typical adult Ancient Thunder Drake of this region, with salt-crusted, barnacle-flecked hide. |
| `pop_04266` | Frostveil Ancient Thunder Drake Albino | [[Regions/Frostveil\|Frostveil]] | Albino | C+ | 86 | 4.5 m | Day & Night | Like a typical Ancient Thunder Drake, but a rare pale form with white skin or fur and red eyes. |
| `pop_04267` | Frostveil Ancient Thunder Drake | [[Regions/Frostveil\|Frostveil]] | Adult | C | 76 | 4.5 m | Day & Night | A typical adult Ancient Thunder Drake of this region, with a thick, frost-rimed coat. |
| `pop_04268` | Stormreach Ancient Thunder Drake Albino | [[Regions/Stormreach\|Stormreach]] | Albino | C+ | 86 | 4.5 m | Day & Night | Like a typical Ancient Thunder Drake, but a rare pale form with white skin or fur and red eyes. |
| `pop_04269` | Hoshizora Ancient Thunder Drake Alpha | [[Regions/Hoshizora\|Hoshizora]] | Alpha | B- | 96 | 5.63 m | Day & Night | Like a typical Ancient Thunder Drake, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_04270` | Hoshizora Ancient Thunder Drake Elderborn | [[Regions/Hoshizora\|Hoshizora]] | Elderborn | B | 108 | 6.08 m | Day & Night | Like a typical Ancient Thunder Drake, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_04271` | Frostveil Ancient Thunder Drake Scarred | [[Regions/Frostveil\|Frostveil]] | Scarred | C+ | 86 | 4.95 m | Day & Night | Like a typical Ancient Thunder Drake, but covered in old battle scars, with a thick, frost-rimed coat. |
| `pop_04272` | Frostveil Ancient Thunder Drake Juvenile | [[Regions/Frostveil\|Frostveil]] | Juvenile | C- | 65 | 3.82 m | Day & Night | Like a typical Ancient Thunder Drake, but young, with brighter colors and unworn features, with a thick, frost-rimed coat. |
| `pop_04273` | Stormreach Ancient Thunder Drake Runt | [[Regions/Stormreach\|Stormreach]] | Runt | D+ | 56 | 3.15 m | Day & Night | Like a typical Ancient Thunder Drake, but smaller and scrappier than usual, with salt-crusted, barnacle-flecked hide. |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `dragon_scale` · VFX `arc_sparks` · palette `#6b6a7a` `#4a4a56` `#ffe14d` · triangle-based silhouette, sharp asymmetric spikes
