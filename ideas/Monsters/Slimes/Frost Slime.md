---
type: monster
id: mon_frost_slime
family: "Slimes"
rank: "D"
tier: core
tags: [monster, slimes]
---
# Frost Slime

![[mon_frost_slime_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_frost_slime_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (1,304 tris · 0.566 × 0.566 × 0.5 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Frost Slime is a small creature with a wobbling mound of translucent gel, about 0.5 m tall. Its gel is weathered and natural, colored in pale blues and frost-white. Guild sketches always show frost crystals growing from its crown. It has alert animal eyes. A distinctive marking runs along its back. It prowls, surrounded by falling snow motes and frosted ground where it steps.

| Field | Value |
|---|---|
| Family · type | [[Families/Slimes|Slimes]] · Ooze |
| Rank · level | D · 48 (40–56) |
| Menace | 2 · Wild |
| Element · weakness | Ice · Fire |
| Size | 0.5 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1738 · 162 · 121 · 121 · 121 · 110 |
| XP · gold | 1477 · 342 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/blob\|blob]] · `anim_blob` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Strife Marches\|Strife Marches]], [[Regions/Iron Hold\|Iron Hold]] |
| Genre | Classic Fantasy |
| Trope | The cute first enemy (Dragon Quest) and the evolving hero (Tensura) |

**Field note:** Weak to Fire. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/blob|blob]] (rigId); animation set `anim_blob`.
- **Dimensions:** 0.5 m high × 0.47 m long × 0.45 m wide; prefab scale 1.
- **Physics:** 72.2 kg, gravity ×1.68, poise 33, knockback resistance 0.16, death style `splat_dissolve`.
- **Navigation:** speed 3.53 m/s, turn 509°/s, stopping distance 0.63 m.
- **Attack count:** 5; **signature:** frost crystals growing from its crown.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Body Slam\|Body Slam]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Engulf\|Engulf]] | grab | 1.4 | 8 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Split\|Split]] | summon | 0 | 20 s | None | none | Interrupt or reposition; watch for added enemies. |
| [[Attacks/Acid Splash\|Acid Splash]] | ranged | 1.1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Frost Breath\|Frost Breath]] | magic | 1.5 | 10 s | Ice | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Frost Slime is a **wild ooze** encountered at D rank, around level 48. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** frost crystals growing from its crown. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Strife Marches|Strife Marches]], [[Regions/Iron Hold|Iron Hold]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_blob`, animation set `anim_blob`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Slimes D|loot_slime_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Slime Jelly\|Slime Jelly]] | 60% | 1–3 |
| [[Items/Gel Core\|Gel Core]] | 30% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Slimes/Elder Frost Slime|Elder Frost Slime]]
- [[Monsters/Slimes/Vesper-Touched Frost Slime|Vesper-Touched Frost Slime]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Iron Hold\|Iron Hold]] | 3 | E+, C, D- | 32–76 | Day & Night |
| [[Regions/Aldmere\|Aldmere]] | 4 | C, D+, E+, D- | 32–76 | Day & Night |
| [[Regions/Strife Marches\|Strife Marches]] | 4 | C-, D+, D- | 40–65 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00078` | Iron Hold Frost Slime Runt | [[Regions/Iron Hold\|Iron Hold]] | Runt | E+ | 32 | 0.35 m | Day & Night | Like a typical Frost Slime, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_00079` | Iron Hold Frost Slime Elderborn | [[Regions/Iron Hold\|Iron Hold]] | Elderborn | C | 76 | 0.68 m | Day & Night | Like a typical Frost Slime, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_00080` | Aldmere Frost Slime Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | C | 76 | 0.68 m | Day & Night | Like a typical Frost Slime, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_00081` | Iron Hold Frost Slime Juvenile | [[Regions/Iron Hold\|Iron Hold]] | Juvenile | D- | 40 | 0.42 m | Day & Night | Like a typical Frost Slime, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_00082` | Aldmere Frost Slime Albino | [[Regions/Aldmere\|Aldmere]] | Albino | D+ | 56 | 0.5 m | Day & Night | Like a typical Frost Slime, but a rare pale form with white skin or fur and red eyes. |
| `pop_00083` | Strife Marches Frost Slime Alpha | [[Regions/Strife Marches\|Strife Marches]] | Alpha | C- | 65 | 0.63 m | Day & Night | Like a typical Frost Slime, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_00084` | Aldmere Frost Slime Runt | [[Regions/Aldmere\|Aldmere]] | Runt | E+ | 32 | 0.35 m | Day & Night | Like a typical Frost Slime, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_00085` | Strife Marches Frost Slime Albino | [[Regions/Strife Marches\|Strife Marches]] | Albino | D+ | 56 | 0.5 m | Day & Night | Like a typical Frost Slime, but a rare pale form with white skin or fur and red eyes. |
| `pop_00086` | Aldmere Frost Slime Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | D- | 40 | 0.42 m | Day & Night | Like a typical Frost Slime, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_00087` | Strife Marches Frost Slime Juvenile | [[Regions/Strife Marches\|Strife Marches]] | Juvenile | D- | 40 | 0.42 m | Day & Night | Like a typical Frost Slime, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_00088` | Strife Marches Frost Slime Scarred | [[Regions/Strife Marches\|Strife Marches]] | Scarred | D+ | 56 | 0.55 m | Day & Night | Like a typical Frost Slime, but covered in old battle scars, with golden, grass-toned coloring. |

## Design recipe

Rig `rig_blob` · mesh `blob_base` · material `translucent_gel_sss` · VFX `frost_trail_snow` · palette `#bfe9ff` `#5fa8d3` `#f4fbff` · real-animal silhouette with one fantasy exaggeration
