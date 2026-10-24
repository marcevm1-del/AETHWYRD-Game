---
type: monster
id: mon_thunderhorn_elk
family: "Beasts"
rank: "C"
tier: core
tags: [monster, beasts]
---
# Thunderhorn Elk

![[mon_thunderhorn_elk_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_thunderhorn_elk_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,736 tris · 0.722 × 2.8 × 1.628 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Thunderhorn Elk is a large creature with a long-legged predatory quadruped build, about 2.8 m long. Its coat is weathered and natural, colored in storm violet shot through with electric yellow. Guild sketches always show branching antlers that crackle in storms. It has alert animal eyes. Battle-worn plates and trophies hang from its body. It lopes in long strides, surrounded by crackling arcs that jump across its body.

| Field | Value |
|---|---|
| Family · type | [[Families/Beasts|Beasts]] · Beast |
| Rank · level | C · 76 (65–86) |
| Menace | 2 · Wild |
| Element · weakness | Lightning · Earth |
| Size | 2.8 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 9386 · 377 · 314 · 251 · 283 · 100 |
| XP · gold | 3073 · 648 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/quad_large\|quad_large]] · `anim_quad_large` |
| Habitats | [[Regions/Fanghold\|Fanghold]], [[Regions/Vharlen\|Vharlen]], [[Regions/Hoshizora\|Hoshizora]] |
| Genre | Classic Fantasy |
| Trope | The horned rabbit "rookie killer" and wolf packs of every isekai starter forest |

**Field note:** Weak to Earth. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_large|quad_large]] (rigId); animation set `anim_quad_large`.
- **Dimensions:** 1.82 m high × 2.8 m long × 0.45 m wide; prefab scale 0.7.
- **Physics:** 439 kg, gravity ×1.2, poise 85, knockback resistance 0.94, death style `heavy_fall_dust`.
- **Navigation:** speed 6.64 m/s, turn 191°/s, stopping distance 0.96 m.
- **Attack count:** 5; **signature:** branching antlers that crackle in storms.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Maul\|Maul]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Pounce\|Pounce]] | dash | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Howl\|Howl]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Rending Bite\|Rending Bite]] | melee | 1.3 | 5 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Static Arc\|Static Arc]] | magic | 1.5 | 10 s | Lightning | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Thunderhorn Elk is a **wild beast** encountered at C rank, around level 76. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Earth**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** branching antlers that crackle in storms. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Fanghold|Fanghold]], [[Regions/Vharlen|Vharlen]], [[Regions/Hoshizora|Hoshizora]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_large`, animation set `anim_quad_large`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Beasts C|loot_beast_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Pelt\|Pelt]] | 60% | 1–3 |
| [[Items/Fang\|Fang]] | 30% | 1–1 |
| [[Items/Prime Meat\|Prime Meat]] | 15% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Beasts/Phantom Thunderhorn Elk|Phantom Thunderhorn Elk]]
- [[Monsters/Beasts/Ancient Thunderhorn Elk|Ancient Thunderhorn Elk]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Hoshizora\|Hoshizora]] | 5 | C, B, D+, B-, C+ | 56–108 | Day & Night |
| [[Regions/Fanghold\|Fanghold]] | 3 | C+, C | 76–86 | Day & Night |
| [[Regions/Vharlen\|Vharlen]] | 3 | C-, B-, B | 65–108 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00442` | Hoshizora Thunderhorn Elk | [[Regions/Hoshizora\|Hoshizora]] | Adult | C | 76 | 2.8 m | Day & Night | A typical adult Thunderhorn Elk of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_00443` | Fanghold Thunderhorn Elk Albino | [[Regions/Fanghold\|Fanghold]] | Albino | C+ | 86 | 2.8 m | Day & Night | Like a typical Thunderhorn Elk, but a rare pale form with white skin or fur and red eyes. |
| `pop_00444` | Fanghold Thunderhorn Elk Scarred | [[Regions/Fanghold\|Fanghold]] | Scarred | C+ | 86 | 3.08 m | Day & Night | Like a typical Thunderhorn Elk, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_00445` | Vharlen Thunderhorn Elk Juvenile | [[Regions/Vharlen\|Vharlen]] | Juvenile | C- | 65 | 2.38 m | Day & Night | Like a typical Thunderhorn Elk, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_00446` | Vharlen Thunderhorn Elk Alpha | [[Regions/Vharlen\|Vharlen]] | Alpha | B- | 96 | 3.5 m | Day & Night | Like a typical Thunderhorn Elk, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_00447` | Fanghold Thunderhorn Elk | [[Regions/Fanghold\|Fanghold]] | Adult | C | 76 | 2.8 m | Day & Night | A typical adult Thunderhorn Elk of this region, with golden, grass-toned coloring. |
| `pop_00448` | Vharlen Thunderhorn Elk Elderborn | [[Regions/Vharlen\|Vharlen]] | Elderborn | B | 108 | 3.78 m | Day & Night | Like a typical Thunderhorn Elk, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_00449` | Hoshizora Thunderhorn Elk Elderborn | [[Regions/Hoshizora\|Hoshizora]] | Elderborn | B | 108 | 3.78 m | Day & Night | Like a typical Thunderhorn Elk, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_00450` | Hoshizora Thunderhorn Elk Runt | [[Regions/Hoshizora\|Hoshizora]] | Runt | D+ | 56 | 1.96 m | Day & Night | Like a typical Thunderhorn Elk, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_00451` | Hoshizora Thunderhorn Elk Alpha | [[Regions/Hoshizora\|Hoshizora]] | Alpha | B- | 96 | 3.5 m | Day & Night | Like a typical Thunderhorn Elk, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_00452` | Hoshizora Thunderhorn Elk Scarred | [[Regions/Hoshizora\|Hoshizora]] | Scarred | C+ | 86 | 3.08 m | Day & Night | Like a typical Thunderhorn Elk, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `fur_groom` · VFX `arc_sparks` · palette `#ffe14d` `#6c5ce7` `#1b1b3a` · real-animal silhouette with one fantasy exaggeration
