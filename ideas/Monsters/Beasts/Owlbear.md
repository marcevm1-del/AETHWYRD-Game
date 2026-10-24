---
type: monster
id: mon_owlbear
family: "Beasts"
rank: "D+"
tier: core
tags: [monster, beasts]
---
# Owlbear

![[mon_owlbear_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_owlbear_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,862 tris · 1.003 × 2.6 × 2.262 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Owlbear is a large creature with a long-legged predatory quadruped build, about 2.6 m long. Its coat is rough, scarred and spiked, colored in muted greys and dusty browns. Survivors describe an owl's feathered face on a bear's muscled body. It has burning slit pupils. A distinctive marking runs along its back. It strides with heavy steps. It has no visible aura; you hear its breathing before you see it.

| Field | Value |
|---|---|
| Family · type | [[Families/Beasts|Beasts]] · Beast |
| Rank · level | D+ · 56 (48–65) |
| Menace | 3 · Menacing |
| Element · weakness | None · Fire |
| Size | 2.6 m |
| Behaviour | Skittish (skittish_flee) |
| HP · ATK · DEF · MATK · MDEF · SPD | 5823 · 281 · 234 · 131 · 211 · 100 |
| XP · gold | 1888 · 423 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/quad_large\|quad_large]] · `anim_quad_large` |
| Habitats | [[Regions/Fanghold\|Fanghold]], [[Regions/Hoshizora\|Hoshizora]], [[Regions/Strife Marches\|Strife Marches]] |
| Genre | Classic Fantasy |
| Trope | The horned rabbit "rookie killer" and wolf packs of every isekai starter forest |

**Field note:** Weak to Fire. Flees when hurt. Snares or ranged attacks work best.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_large|quad_large]] (rigId); animation set `anim_quad_large`.
- **Dimensions:** 1.69 m high × 2.6 m long × 0.42 m wide; prefab scale 0.65.
- **Physics:** 351.5 kg, gravity ×1.2, poise 73, knockback resistance 0.91, death style `heavy_fall_dust`.
- **Navigation:** speed 7.47 m/s, turn 198°/s, stopping distance 0.92 m.
- **Attack count:** 4; **signature:** an owl's feathered face on a bear's muscled body.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Maul\|Maul]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Pounce\|Pounce]] | dash | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Howl\|Howl]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Rending Bite\|Rending Bite]] | melee | 1.3 | 5 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |

## Field guide

Owlbear is a **menacing beast** encountered at D+ rank, around level 56. Its documented behaviour is *Skittish* and its AI pattern is *skittish_flee*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** an owl's feathered face on a bear's muscled body. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Fanghold|Fanghold]], [[Regions/Hoshizora|Hoshizora]], [[Regions/Strife Marches|Strife Marches]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_large`, animation set `anim_quad_large`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Beasts D|loot_beast_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Pelt\|Pelt]] | 60% | 1–3 |
| [[Items/Fang\|Fang]] | 30% | 1–1 |
| [[Items/Prime Meat\|Prime Meat]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Beasts/Ancient Owlbear|Ancient Owlbear]]
- [[Monsters/Beasts/Vesper-Touched Owlbear|Vesper-Touched Owlbear]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Hoshizora\|Hoshizora]] | 4 | C, C-, D+, C+ | 56–86 | Day & Night |
| [[Regions/Strife Marches\|Strife Marches]] | 4 | C-, C, D- | 40–76 | Day & Night |
| [[Regions/Fanghold\|Fanghold]] | 3 | C-, C, D+ | 56–76 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00431` | Hoshizora Owlbear Alpha | [[Regions/Hoshizora\|Hoshizora]] | Alpha | C | 76 | 3.25 m | Day & Night | Like a typical Owlbear, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_00432` | Hoshizora Owlbear Albino | [[Regions/Hoshizora\|Hoshizora]] | Albino | C- | 65 | 2.6 m | Day & Night | Like a typical Owlbear, but a rare pale form with white skin or fur and red eyes. |
| `pop_00433` | Strife Marches Owlbear Albino | [[Regions/Strife Marches\|Strife Marches]] | Albino | C- | 65 | 2.6 m | Day & Night | Like a typical Owlbear, but a rare pale form with white skin or fur and red eyes. |
| `pop_00434` | Strife Marches Owlbear Scarred | [[Regions/Strife Marches\|Strife Marches]] | Scarred | C- | 65 | 2.86 m | Day & Night | Like a typical Owlbear, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_00435` | Fanghold Owlbear Scarred | [[Regions/Fanghold\|Fanghold]] | Scarred | C- | 65 | 2.86 m | Day & Night | Like a typical Owlbear, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_00436` | Hoshizora Owlbear | [[Regions/Hoshizora\|Hoshizora]] | Adult | D+ | 56 | 2.6 m | Day & Night | A typical adult Owlbear of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_00437` | Fanghold Owlbear Alpha | [[Regions/Fanghold\|Fanghold]] | Alpha | C | 76 | 3.25 m | Day & Night | Like a typical Owlbear, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_00438` | Strife Marches Owlbear Alpha | [[Regions/Strife Marches\|Strife Marches]] | Alpha | C | 76 | 3.25 m | Day & Night | Like a typical Owlbear, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_00439` | Hoshizora Owlbear Elderborn | [[Regions/Hoshizora\|Hoshizora]] | Elderborn | C+ | 86 | 3.51 m | Day & Night | Like a typical Owlbear, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_00440` | Fanghold Owlbear | [[Regions/Fanghold\|Fanghold]] | Adult | D+ | 56 | 2.6 m | Day & Night | A typical adult Owlbear of this region, with golden, grass-toned coloring. |
| `pop_00441` | Strife Marches Owlbear Runt | [[Regions/Strife Marches\|Strife Marches]] | Runt | D- | 40 | 1.82 m | Day & Night | Like a typical Owlbear, but smaller and scrappier than usual, with golden, grass-toned coloring. |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `fur_groom` · VFX `dust_puffs` · palette `#8a8f98` `#5b5f66` `#c9c2b5` · triangle-based silhouette, sharp asymmetric spikes
