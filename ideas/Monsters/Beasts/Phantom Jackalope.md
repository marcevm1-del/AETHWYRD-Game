---
type: monster
id: mon_phantom_jackalope
family: "Beasts"
rank: "E+"
tier: variant
tags: [monster, beasts]
---
# Phantom Jackalope

![[mon_phantom_jackalope_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_phantom_jackalope_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Phantom Jackalope is a tiny creature with a low, springy quadruped build, about 0.4 m long. Its coat is weathered and natural, colored in warm gold and pearl white. Guild sketches always show tiny antlers on a fluffy rabbit. It has amber predator eyes. Small scars and rough edges mark it as a survivor. It prowls, surrounded by soft radiance and floating motes of light. Its body is translucent blue, half in the spirit world; weapons pass through it unless they are blessed or enchanted.

| Field | Value |
|---|---|
| Family · type | [[Families/Beasts|Beasts]] · Beast |
| Variant of | [[Monsters/Beasts/Jackalope\|Jackalope]] (spirit) |
| Rank · level | E+ · 32 (26–40) |
| Menace | 2 · Wild |
| Element · weakness | Light · Dark |
| Size | 0.4 m |
| Behaviour | Pack (pack_flank) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1103 · 138 · 110 · 97 · 110 · 135 |
| XP · gold | 776 · 195 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/quad_small\|quad_small]] · `anim_quad_small` |
| Habitats | [[Regions/Fanghold\|Fanghold]], [[Regions/Aldmere\|Aldmere]], [[Regions/Sylvaran\|Sylvaran]] |
| Genre | Classic Fantasy |
| Trope | The horned rabbit "rookie killer" and wolf packs of every isekai starter forest |

**Field note:** Weak to Dark. Never alone. Kill the leader first and the rest may scatter.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_small|quad_small]] (rigId); animation set `anim_quad_small`.
- **Dimensions:** 0.27 m high × 0.4 m long × 0.06 m wide; prefab scale 0.8.
- **Physics:** 1.8 kg, gravity ×1.44, poise 21, knockback resistance 0.08, death style `ragdoll_tumble`.
- **Navigation:** speed 5.6 m/s, turn 854°/s, stopping distance 0.5 m.
- **Attack count:** 5; **signature:** tiny antlers on a fluffy rabbit.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Bite\|Bite]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Charge\|Charge]] | dash | 1.3 | 5 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Leap\|Leap]] | dash | 1.2 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Rending Bite\|Rending Bite]] | melee | 1.3 | 5 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Radiant Pulse\|Radiant Pulse]] | magic | 1.5 | 10 s | Light | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Phantom Jackalope is a **wild beast** encountered at E+ rank, around level 32. Its documented behaviour is *Pack* and its AI pattern is *pack_flank*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Dark**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** tiny antlers on a fluffy rabbit. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Fanghold|Fanghold]], [[Regions/Aldmere|Aldmere]], [[Regions/Sylvaran|Sylvaran]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_small`, animation set `anim_quad_small`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Beasts E|loot_beast_e]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Pelt\|Pelt]] | 60% | 1–3 |
| [[Items/Fang\|Fang]] | 30% | 1–1 |
| [[Items/Prime Meat\|Prime Meat]] | 15% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Aldmere\|Aldmere]] | 4 | D-, E-, D+ | 19–56 | Day & Night |
| [[Regions/Fanghold\|Fanghold]] | 4 | D-, E, D | 26–48 | Day & Night |
| [[Regions/Sylvaran\|Sylvaran]] | 3 | D-, E-, D+ | 19–56 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06253` | Aldmere Phantom Jackalope Albino | [[Regions/Aldmere\|Aldmere]] | Albino | D- | 40 | 0.4 m | Day & Night | Like a typical Phantom Jackalope, but a rare pale form with white skin or fur and red eyes. |
| `pop_06254` | Aldmere Phantom Jackalope Runt | [[Regions/Aldmere\|Aldmere]] | Runt | E- | 19 | 0.28 m | Day & Night | Like a typical Phantom Jackalope, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_06255` | Fanghold Phantom Jackalope Scarred | [[Regions/Fanghold\|Fanghold]] | Scarred | D- | 40 | 0.44 m | Day & Night | Like a typical Phantom Jackalope, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_06256` | Fanghold Phantom Jackalope Juvenile | [[Regions/Fanghold\|Fanghold]] | Juvenile | E | 26 | 0.34 m | Day & Night | Like a typical Phantom Jackalope, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_06257` | Aldmere Phantom Jackalope Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | D- | 40 | 0.44 m | Day & Night | Like a typical Phantom Jackalope, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_06258` | Fanghold Phantom Jackalope Alpha | [[Regions/Fanghold\|Fanghold]] | Alpha | D | 48 | 0.5 m | Day & Night | Like a typical Phantom Jackalope, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_06259` | Sylvaran Phantom Jackalope Scarred | [[Regions/Sylvaran\|Sylvaran]] | Scarred | D- | 40 | 0.44 m | Day & Night | Like a typical Phantom Jackalope, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_06260` | Aldmere Phantom Jackalope Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | D+ | 56 | 0.54 m | Day & Night | Like a typical Phantom Jackalope, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_06261` | Fanghold Phantom Jackalope Albino | [[Regions/Fanghold\|Fanghold]] | Albino | D- | 40 | 0.4 m | Day & Night | Like a typical Phantom Jackalope, but a rare pale form with white skin or fur and red eyes. |
| `pop_06262` | Sylvaran Phantom Jackalope Runt | [[Regions/Sylvaran\|Sylvaran]] | Runt | E- | 19 | 0.28 m | Day & Night | Like a typical Phantom Jackalope, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_06263` | Sylvaran Phantom Jackalope Elderborn | [[Regions/Sylvaran\|Sylvaran]] | Elderborn | D+ | 56 | 0.54 m | Day & Night | Like a typical Phantom Jackalope, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_quad_small` · mesh `quad_small_base` · material `fur_groom` · VFX `holy_motes` · palette `#fff3b0` `#ffd166` `#ffffff` · real-animal silhouette with one fantasy exaggeration
