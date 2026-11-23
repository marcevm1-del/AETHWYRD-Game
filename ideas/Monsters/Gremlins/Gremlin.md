---
type: monster
id: mon_gremlin
family: "Gremlins"
rank: "F"
tier: core
tags: [monster, gremlins]
---
# Gremlin

![[mon_gremlin_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_gremlin_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 12,000 tris · 0.323 × 0.516 × 0.6 m · local file `Game/Assets/_Game/Art/Models/Monsters/Gremlins/mon_gremlin.fbx`

> The Gremlin is a small creature with a scrawny biped with long arms and bowed legs, about 0.6 m tall. Its skin is weathered and natural, colored in lime-green, with electric-yellow markings. Its most striking feature is bat ears, a wrench and a laugh like a squeaky hinge. It has alert animal eyes. It has no ornament at all: simple, readable shapes. It prowls, surrounded by crackling arcs that jump across its body.

| Field | Value |
|---|---|
| Family · type | [[Families/Gremlins|Gremlins]] · Fey Pest |
| Rank · level | F · 8 (3–13) |
| Menace | 2 · Wild |
| Element · weakness | Lightning · Earth |
| Size | 0.6 m |
| Behaviour | Skittish (skittish_flee) |
| HP · ATK · DEF · MATK · MDEF · SPD | 192 · 42 · 34 · 29 · 34 · 135 |
| XP · gold | 92 · 31 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/small_biped\|small_biped]] · `anim_small_biped` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] |
| Genre | Steampunk Mischief |
| Trope | Machine-breaking pests |

**Field note:** Weak to Earth. Flees when hurt. Snares or ranged attacks work best.

## Motion implementation

- **Rig:** [[Systems/Rigs/small_biped|small_biped]] (rigId); animation set `anim_small_biped`.
- **Dimensions:** 0.6 m high × 0.18 m long × 0.24 m wide; prefab scale 0.545.
- **Physics:** 3.5 kg, gravity ×1.5, poise 22, knockback resistance 0.15, death style `ragdoll_crumple`.
- **Navigation:** speed 4.62 m/s, turn 542°/s, stopping distance 0.52 m.
- **Attack count:** 5; **signature:** bat ears, a wrench and a laugh like a squeaky hinge.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stab\|Stab]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Thrown Junk\|Thrown Junk]] | ranged | 0.8 | 4 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Frenzied Lunge\|Frenzied Lunge]] | melee | 1.5 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Wrench Sabotage\|Wrench Sabotage]] | debuff | 0 | 14 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Static Arc\|Static Arc]] | magic | 1.5 | 10 s | Lightning | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Gremlin is a **wild fey pest** encountered at F rank, around level 8. Its documented behaviour is *Skittish* and its AI pattern is *skittish_flee*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Earth**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** bat ears, a wrench and a laugh like a squeaky hinge. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Whisperwood|Whisperwood]], [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_small_biped`, animation set `anim_small_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Gremlins F|loot_gremlin_f]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Stolen Bolt\|Stolen Bolt]] | 60% | 1–3 |
| [[Items/Gremlin Ear\|Gremlin Ear]] | 30% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Gremlins/Ancient Gremlin|Ancient Gremlin]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 4 | F, F+, E | 8–26 | Day & Night |
| [[Regions/Aldmere\|Aldmere]] | 4 | F-, F, E- | 3–19 | Day & Night |
| [[Regions/Whisperwood\|Whisperwood]] | 3 | E-, F+, F | 8–19 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02362` | Great Labyrinth (Floors 1-40) Gremlin | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Adult | F | 8 | 0.6 m | Day & Night | A typical adult Gremlin of this region, with dust-grey coloring and old rune scars. |
| `pop_02363` | Aldmere Gremlin Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | F- | 3 | 0.51 m | Day & Night | Like a typical Gremlin, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_02364` | Aldmere Gremlin | [[Regions/Aldmere\|Aldmere]] | Adult | F | 8 | 0.6 m | Day & Night | A typical adult Gremlin of this region, with dust-grey coloring and old rune scars. |
| `pop_02365` | Great Labyrinth (Floors 1-40) Gremlin Albino | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Albino | F+ | 13 | 0.6 m | Day & Night | Like a typical Gremlin, but a rare pale form with white skin or fur and red eyes. |
| `pop_02366` | Great Labyrinth (Floors 1-40) Gremlin Scarred | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Scarred | F+ | 13 | 0.66 m | Day & Night | Like a typical Gremlin, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_02367` | Whisperwood Gremlin Alpha | [[Regions/Whisperwood\|Whisperwood]] | Alpha | E- | 19 | 0.75 m | Day & Night | Like a typical Gremlin, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_02368` | Whisperwood Gremlin Albino | [[Regions/Whisperwood\|Whisperwood]] | Albino | F+ | 13 | 0.6 m | Day & Night | Like a typical Gremlin, but a rare pale form with white skin or fur and red eyes. |
| `pop_02369` | Whisperwood Gremlin | [[Regions/Whisperwood\|Whisperwood]] | Adult | F | 8 | 0.6 m | Day & Night | A typical adult Gremlin of this region, with dust-grey coloring and old rune scars. |
| `pop_02370` | Great Labyrinth (Floors 1-40) Gremlin Elderborn | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Elderborn | E | 26 | 0.81 m | Day & Night | Like a typical Gremlin, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_02371` | Aldmere Gremlin Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | E- | 19 | 0.75 m | Day & Night | Like a typical Gremlin, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_02372` | Aldmere Gremlin Runt | [[Regions/Aldmere\|Aldmere]] | Runt | F- | 3 | 0.42 m | Day & Night | Like a typical Gremlin, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `rubbery_skin` · VFX `arc_sparks` · palette `#82a84e` `#537033` `#ffe14d` · real-animal silhouette with one fantasy exaggeration
