---
type: monster
id: mon_crag_jackalope
family: "Beasts"
rank: "E+"
tier: variant
tags: [monster, beasts]
---
# Crag Jackalope

![[mon_crag_jackalope_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_crag_jackalope_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,654 tris · 0.096 × 0.4 × 0.16 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Crag Jackalope is a tiny creature with a low, springy quadruped build, about 0.4 m long. Its coat is smooth and clean, colored in cream, with ochre markings. Survivors describe tiny antlers on a fluffy rabbit. It has two bright dot eyes. Small scars and rough edges mark it as a survivor. It hops in little bursts, surrounded by pebbles that tremble and float near it. Adapted to mountain lands, it has slate-grey coloring and hardened hide.

| Field | Value |
|---|---|
| Family · type | [[Families/Beasts|Beasts]] · Beast |
| Variant of | [[Monsters/Beasts/Jackalope\|Jackalope]] (regional) |
| Rank · level | E+ · 32 (26–40) |
| Menace | 1 · Charming |
| Element · weakness | Earth · Wind |
| Size | 0.4 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1103 · 138 · 110 · 97 · 110 · 135 |
| XP · gold | 776 · 195 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/quad_small\|quad_small]] · `anim_quad_small` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Fanghold\|Fanghold]] |
| Genre | Classic Fantasy |
| Trope | The horned rabbit "rookie killer" and wolf packs of every isekai starter forest |

**Field note:** Weak to Wind. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_small|quad_small]] (rigId); animation set `anim_quad_small`.
- **Dimensions:** 0.27 m high × 0.4 m long × 0.06 m wide; prefab scale 0.8.
- **Physics:** 2.5 kg, gravity ×1.76, poise 21, knockback resistance 0.23, death style `ragdoll_tumble`.
- **Navigation:** speed 4.42 m/s, turn 854°/s, stopping distance 0.5 m.
- **Attack count:** 5; **signature:** tiny antlers on a fluffy rabbit.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Bite\|Bite]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Charge\|Charge]] | dash | 1.3 | 5 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Leap\|Leap]] | dash | 1.2 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Rending Bite\|Rending Bite]] | melee | 1.3 | 5 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Crag Jackalope is a **charming beast** encountered at E+ rank, around level 32. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** tiny antlers on a fluffy rabbit. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Fanghold|Fanghold]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

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
| [[Regions/Fanghold\|Fanghold]] | 6 | D-, E-, D+, E, D | 19–56 | Day |
| [[Regions/Aldmere\|Aldmere]] | 5 | D, D-, E-, E+, E | 19–48 | Day |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03408` | Fanghold Crag Jackalope Scarred | [[Regions/Fanghold\|Fanghold]] | Scarred | D- | 40 | 0.44 m | Day | Like a typical Crag Jackalope, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_03409` | Aldmere Crag Jackalope Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | D | 48 | 0.5 m | Day | Like a typical Crag Jackalope, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_03410` | Aldmere Crag Jackalope Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | D- | 40 | 0.44 m | Day | Like a typical Crag Jackalope, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_03411` | Fanghold Crag Jackalope Runt | [[Regions/Fanghold\|Fanghold]] | Runt | E- | 19 | 0.28 m | Day | Like a typical Crag Jackalope, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_03412` | Fanghold Crag Jackalope Elderborn | [[Regions/Fanghold\|Fanghold]] | Elderborn | D+ | 56 | 0.54 m | Day | Like a typical Crag Jackalope, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_03413` | Aldmere Crag Jackalope Runt | [[Regions/Aldmere\|Aldmere]] | Runt | E- | 19 | 0.28 m | Day | Like a typical Crag Jackalope, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_03414` | Fanghold Crag Jackalope Juvenile | [[Regions/Fanghold\|Fanghold]] | Juvenile | E | 26 | 0.34 m | Day | Like a typical Crag Jackalope, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_03415` | Fanghold Crag Jackalope Albino | [[Regions/Fanghold\|Fanghold]] | Albino | D- | 40 | 0.4 m | Day | Like a typical Crag Jackalope, but a rare pale form with white skin or fur and red eyes. |
| `pop_03416` | Fanghold Crag Jackalope Alpha | [[Regions/Fanghold\|Fanghold]] | Alpha | D | 48 | 0.5 m | Day | Like a typical Crag Jackalope, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_03417` | Aldmere Crag Jackalope | [[Regions/Aldmere\|Aldmere]] | Adult | E+ | 32 | 0.4 m | Day | A typical adult Crag Jackalope of this region, with golden, grass-toned coloring. |
| `pop_03418` | Aldmere Crag Jackalope Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | E | 26 | 0.34 m | Day | Like a typical Crag Jackalope, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |

## Design recipe

Rig `rig_quad_small` · mesh `quad_small_base` · material `fur_groom` · VFX `rock_debris` · palette `#ceb6a0` `#937c6b` `#d1a15a` · circle-based, soft silhouette
