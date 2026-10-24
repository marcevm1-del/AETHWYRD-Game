---
type: monster
id: mon_vesper_touched_owlbear
family: "Beasts"
rank: "C"
tier: variant
tags: [monster, beasts]
---
# Vesper-Touched Owlbear

![[mon_vesper_touched_owlbear_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_vesper_touched_owlbear_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Vesper-Touched Owlbear is a large creature with a long-legged predatory quadruped build, about 2.6 m long. Its coat is patchy and subtly wrong, as if assembled from memory, colored in arterial crimson and dried-blood brown. Guild sketches always show an owl's feathered face on a bear's muscled body. It has pale, pupil-less eyes. Battle-worn plates and trophies hang from its body. It moves in jerky stop-motion bursts, surrounded by a faint red mist that smells of iron. Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.

| Field | Value |
|---|---|
| Family · type | [[Families/Beasts|Beasts]] · Beast |
| Variant of | [[Monsters/Beasts/Owlbear\|Owlbear]] (corrupted) |
| Rank · level | C · 76 (65–86) |
| Menace | 4 · Dread |
| Element · weakness | Blood · Light |
| Size | 2.6 m |
| Behaviour | Skittish (skittish_flee+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 9153 · 377 · 314 · 251 · 283 · 100 |
| XP · gold | 3073 · 648 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/quad_large\|quad_large]] · `anim_quad_large` |
| Habitats | [[Regions/Strife Marches\|Strife Marches]], [[Regions/Aldmere\|Aldmere]], [[Regions/Vharlen\|Vharlen]] |
| Genre | Classic Fantasy |
| Trope | The horned rabbit "rookie killer" and wolf packs of every isekai starter forest |

**Field note:** Weak to Light. Flees when hurt. Snares or ranged attacks work best.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_large|quad_large]] (rigId); animation set `anim_quad_large`.
- **Dimensions:** 1.69 m high × 2.6 m long × 0.42 m wide; prefab scale 0.65.
- **Physics:** 386.7 kg, gravity ×1.2, poise 82, knockback resistance 0.94, death style `heavy_fall_dust`.
- **Navigation:** speed 7.11 m/s, turn 198°/s, stopping distance 0.92 m.
- **Attack count:** 5; **signature:** an owl's feathered face on a bear's muscled body.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Maul\|Maul]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Pounce\|Pounce]] | dash | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Howl\|Howl]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Rending Bite\|Rending Bite]] | melee | 1.3 | 5 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Blood Lance\|Blood Lance]] | magic | 1.5 | 10 s | Blood | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Vesper-Touched Owlbear is a **dread beast** encountered at C rank, around level 76. Its documented behaviour is *Skittish* and its AI pattern is *skittish_flee+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** an owl's feathered face on a bear's muscled body. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Strife Marches|Strife Marches]], [[Regions/Aldmere|Aldmere]], [[Regions/Vharlen|Vharlen]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_large`, animation set `anim_quad_large`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Beasts C|loot_beast_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Pelt\|Pelt]] | 60% | 1–3 |
| [[Items/Fang\|Fang]] | 30% | 1–1 |
| [[Items/Prime Meat\|Prime Meat]] | 15% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Aldmere\|Aldmere]] | 5 | B, C+, B-, D+ | 56–108 | Night |
| [[Regions/Vharlen\|Vharlen]] | 3 | C+, C | 76–86 | Night |
| [[Regions/Strife Marches\|Strife Marches]] | 3 | B-, C-, B | 65–108 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06176` | Aldmere Vesper-Touched Owlbear Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | B | 108 | 3.51 m | Night | Like a typical Vesper-Touched Owlbear, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_06177` | Aldmere Vesper-Touched Owlbear Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | C+ | 86 | 2.86 m | Night | Like a typical Vesper-Touched Owlbear, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_06178` | Vharlen Vesper-Touched Owlbear Scarred | [[Regions/Vharlen\|Vharlen]] | Scarred | C+ | 86 | 2.86 m | Night | Like a typical Vesper-Touched Owlbear, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_06179` | Strife Marches Vesper-Touched Owlbear Alpha | [[Regions/Strife Marches\|Strife Marches]] | Alpha | B- | 96 | 3.25 m | Night | Like a typical Vesper-Touched Owlbear, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_06180` | Aldmere Vesper-Touched Owlbear Albino | [[Regions/Aldmere\|Aldmere]] | Albino | C+ | 86 | 2.6 m | Night | Like a typical Vesper-Touched Owlbear, but a rare pale form with white skin or fur and red eyes. |
| `pop_06181` | Aldmere Vesper-Touched Owlbear Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | B- | 96 | 3.25 m | Night | Like a typical Vesper-Touched Owlbear, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_06182` | Aldmere Vesper-Touched Owlbear Runt | [[Regions/Aldmere\|Aldmere]] | Runt | D+ | 56 | 1.82 m | Night | Like a typical Vesper-Touched Owlbear, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_06183` | Strife Marches Vesper-Touched Owlbear Juvenile | [[Regions/Strife Marches\|Strife Marches]] | Juvenile | C- | 65 | 2.21 m | Night | Like a typical Vesper-Touched Owlbear, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_06184` | Strife Marches Vesper-Touched Owlbear Elderborn | [[Regions/Strife Marches\|Strife Marches]] | Elderborn | B | 108 | 3.51 m | Night | Like a typical Vesper-Touched Owlbear, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_06185` | Vharlen Vesper-Touched Owlbear | [[Regions/Vharlen\|Vharlen]] | Adult | C | 76 | 2.6 m | Night | A typical adult Vesper-Touched Owlbear of this region, with golden, grass-toned coloring. |
| `pop_06186` | Vharlen Vesper-Touched Owlbear Albino | [[Regions/Vharlen\|Vharlen]] | Albino | C+ | 86 | 2.6 m | Night | Like a typical Vesper-Touched Owlbear, but a rare pale form with white skin or fur and red eyes. |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `fur_groom` · VFX `blood_mist` · palette `#8b0000` `#d7263d` `#1a0505` · elongated, irregular silhouette; still-then-sudden timing
