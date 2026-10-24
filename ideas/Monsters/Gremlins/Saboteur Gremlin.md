---
type: monster
id: mon_saboteur_gremlin
family: "Gremlins"
rank: "E"
tier: core
tags: [monster, gremlins]
---
# Saboteur Gremlin

![[mon_saboteur_gremlin_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_saboteur_gremlin_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Saboteur Gremlin is a small creature with a hunched, wiry humanoid frame, about 0.7 m tall. Its skin is rough, scarred and spiked, colored in storm violet shot through with electric yellow. Guild sketches always show goggles and a bag of stolen bolts. It has burning slit pupils. Small scars and rough edges mark it as a survivor. It charges without hesitation, surrounded by crackling arcs that jump across its body.

| Field | Value |
|---|---|
| Family · type | [[Families/Gremlins|Gremlins]] · Fey Pest |
| Rank · level | E · 26 (19–32) |
| Menace | 3 · Menacing |
| Element · weakness | Lightning · Earth |
| Size | 0.7 m |
| Behaviour | Skittish (skittish_flee) |
| HP · ATK · DEF · MATK · MDEF · SPD | 953 · 114 · 91 · 80 · 91 · 135 |
| XP · gold | 559 · 147 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/small_biped\|small_biped]] · `anim_small_biped` |
| Habitats | [[Regions/Lirian\|Lirian]], [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Steampunk Mischief |
| Trope | Machine-breaking pests |

**Field note:** Weak to Earth. Flees when hurt. Snares or ranged attacks work best.

## Motion implementation

- **Rig:** [[Systems/Rigs/small_biped|small_biped]] (rigId); animation set `anim_small_biped`.
- **Dimensions:** 0.7 m high × 0.21 m long × 0.28 m wide; prefab scale 0.636.
- **Physics:** 5.5 kg, gravity ×1.5, poise 28, knockback resistance 0.18, death style `ragdoll_crumple`.
- **Navigation:** speed 5.24 m/s, turn 502°/s, stopping distance 0.54 m.
- **Attack count:** 5; **signature:** goggles and a bag of stolen bolts.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stab\|Stab]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Thrown Junk\|Thrown Junk]] | ranged | 0.8 | 4 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Frenzied Lunge\|Frenzied Lunge]] | melee | 1.5 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Wrench Sabotage\|Wrench Sabotage]] | debuff | 0 | 14 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Static Arc\|Static Arc]] | magic | 1.5 | 10 s | Lightning | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Saboteur Gremlin is a **menacing fey pest** encountered at E rank, around level 26. Its documented behaviour is *Skittish* and its AI pattern is *skittish_flee*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Earth**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** goggles and a bag of stolen bolts. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Lirian|Lirian]], [[Regions/Aldmere|Aldmere]], [[Regions/Whisperwood|Whisperwood]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_small_biped`, animation set `anim_small_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Gremlins E|loot_gremlin_e]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Stolen Bolt\|Stolen Bolt]] | 60% | 1–3 |
| [[Items/Gremlin Ear\|Gremlin Ear]] | 30% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Gremlins/Vesper-Touched Saboteur Gremlin|Vesper-Touched Saboteur Gremlin]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Lirian\|Lirian]] | 5 | D, E+, F+, D- | 13–48 | Day & Night |
| [[Regions/Whisperwood\|Whisperwood]] | 3 | E+, E- | 19–32 | Day & Night |
| [[Regions/Aldmere\|Aldmere]] | 3 | E-, D, E+ | 19–48 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02373` | Lirian Saboteur Gremlin Elderborn | [[Regions/Lirian\|Lirian]] | Elderborn | D | 48 | 0.94 m | Day & Night | Like a typical Saboteur Gremlin, but old and wise, with greying features and a cautious hunting style, with soot-stained hide and scavenged scraps. |
| `pop_02374` | Lirian Saboteur Gremlin Scarred | [[Regions/Lirian\|Lirian]] | Scarred | E+ | 32 | 0.77 m | Day & Night | Like a typical Saboteur Gremlin, but covered in old battle scars, with soot-stained hide and scavenged scraps. |
| `pop_02375` | Whisperwood Saboteur Gremlin Scarred | [[Regions/Whisperwood\|Whisperwood]] | Scarred | E+ | 32 | 0.77 m | Day & Night | Like a typical Saboteur Gremlin, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_02376` | Lirian Saboteur Gremlin Runt | [[Regions/Lirian\|Lirian]] | Runt | F+ | 13 | 0.49 m | Day & Night | Like a typical Saboteur Gremlin, but smaller and scrappier than usual, with soot-stained hide and scavenged scraps. |
| `pop_02377` | Aldmere Saboteur Gremlin Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | E- | 19 | 0.59 m | Day & Night | Like a typical Saboteur Gremlin, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_02378` | Aldmere Saboteur Gremlin Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | D | 48 | 0.94 m | Day & Night | Like a typical Saboteur Gremlin, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_02379` | Whisperwood Saboteur Gremlin Albino | [[Regions/Whisperwood\|Whisperwood]] | Albino | E+ | 32 | 0.7 m | Day & Night | Like a typical Saboteur Gremlin, but a rare pale form with white skin or fur and red eyes. |
| `pop_02380` | Lirian Saboteur Gremlin Alpha | [[Regions/Lirian\|Lirian]] | Alpha | D- | 40 | 0.88 m | Day & Night | Like a typical Saboteur Gremlin, but larger and scarred, and others of its kind follow it, with soot-stained hide and scavenged scraps. |
| `pop_02381` | Whisperwood Saboteur Gremlin Juvenile | [[Regions/Whisperwood\|Whisperwood]] | Juvenile | E- | 19 | 0.59 m | Day & Night | Like a typical Saboteur Gremlin, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_02382` | Lirian Saboteur Gremlin Albino | [[Regions/Lirian\|Lirian]] | Albino | E+ | 32 | 0.7 m | Day & Night | Like a typical Saboteur Gremlin, but a rare pale form with white skin or fur and red eyes. |
| `pop_02383` | Aldmere Saboteur Gremlin Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | E+ | 32 | 0.77 m | Day & Night | Like a typical Saboteur Gremlin, but covered in old battle scars, with dust-grey coloring and old rune scars. |

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `rubbery_skin` · VFX `arc_sparks` · palette `#ffe14d` `#6c5ce7` `#1b1b3a` · triangle-based silhouette, sharp asymmetric spikes
