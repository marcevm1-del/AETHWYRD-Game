---
type: monster
id: mon_vesper_touched_saboteur_gremlin
family: "Gremlins"
rank: "D-"
tier: variant
tags: [monster, gremlins]
---
# Vesper-Touched Saboteur Gremlin

![[mon_vesper_touched_saboteur_gremlin_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_vesper_touched_saboteur_gremlin_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,656 tris · 0.25 × 0.318 × 0.7 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Vesper-Touched Saboteur Gremlin is a small creature with a scrawny biped with long arms and bowed legs, about 0.7 m tall. Its skin is patchy and subtly wrong, as if assembled from memory, colored in storm violet shot through with electric yellow. Its most striking feature is goggles and a bag of stolen bolts. It has pale, pupil-less eyes. A distinctive marking runs along its back. It glides without moving its legs, surrounded by crackling arcs that jump across its body. Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.

| Field | Value |
|---|---|
| Family · type | [[Families/Gremlins|Gremlins]] · Fey Pest |
| Variant of | [[Monsters/Gremlins/Saboteur Gremlin\|Saboteur Gremlin]] (corrupted) |
| Rank · level | D- · 40 (32–48) |
| Menace | 4 · Dread |
| Element · weakness | Lightning · Earth |
| Size | 0.7 m |
| Behaviour | Skittish (skittish_flee+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1777 · 170 · 136 · 119 · 136 · 135 |
| XP · gold | 1106 · 265 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/small_biped\|small_biped]] · `anim_small_biped` |
| Habitats | [[Regions/Lirian\|Lirian]], [[Regions/Aldmere\|Aldmere]] |
| Genre | Steampunk Mischief |
| Trope | Machine-breaking pests |

**Field note:** Weak to Earth. Flees when hurt. Snares or ranged attacks work best.

## Motion implementation

- **Rig:** [[Systems/Rigs/small_biped|small_biped]] (rigId); animation set `anim_small_biped`.
- **Dimensions:** 0.7 m high × 0.21 m long × 0.28 m wide; prefab scale 0.636.
- **Physics:** 5.5 kg, gravity ×1.5, poise 31, knockback resistance 0.21, death style `ragdoll_crumple`.
- **Navigation:** speed 5 m/s, turn 502°/s, stopping distance 0.54 m.
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

Vesper-Touched Saboteur Gremlin is a **dread fey pest** encountered at D- rank, around level 40. Its documented behaviour is *Skittish* and its AI pattern is *skittish_flee+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Earth**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** goggles and a bag of stolen bolts. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Lirian|Lirian]], [[Regions/Aldmere|Aldmere]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_small_biped`, animation set `anim_small_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Gremlins D|loot_gremlin_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Stolen Bolt\|Stolen Bolt]] | 60% | 1–3 |
| [[Items/Gremlin Ear\|Gremlin Ear]] | 30% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Aldmere\|Aldmere]] | 6 | D-, E+, D, D+, E | 26–56 | Night |
| [[Regions/Lirian\|Lirian]] | 5 | D, C-, D-, E | 26–65 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05224` | Aldmere Vesper-Touched Saboteur Gremlin | [[Regions/Aldmere\|Aldmere]] | Adult | D- | 40 | 0.7 m | Night | A typical adult Vesper-Touched Saboteur Gremlin of this region, with dust-grey coloring and old rune scars. |
| `pop_05225` | Lirian Vesper-Touched Saboteur Gremlin Albino | [[Regions/Lirian\|Lirian]] | Albino | D | 48 | 0.7 m | Night | Like a typical Vesper-Touched Saboteur Gremlin, but a rare pale form with white skin or fur and red eyes. |
| `pop_05226` | Lirian Vesper-Touched Saboteur Gremlin Elderborn | [[Regions/Lirian\|Lirian]] | Elderborn | C- | 65 | 0.94 m | Night | Like a typical Vesper-Touched Saboteur Gremlin, but old and wise, with greying features and a cautious hunting style, with soot-stained hide and scavenged scraps. |
| `pop_05227` | Aldmere Vesper-Touched Saboteur Gremlin Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | E+ | 32 | 0.59 m | Night | Like a typical Vesper-Touched Saboteur Gremlin, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_05228` | Aldmere Vesper-Touched Saboteur Gremlin Albino | [[Regions/Aldmere\|Aldmere]] | Albino | D | 48 | 0.7 m | Night | Like a typical Vesper-Touched Saboteur Gremlin, but a rare pale form with white skin or fur and red eyes. |
| `pop_05229` | Lirian Vesper-Touched Saboteur Gremlin | [[Regions/Lirian\|Lirian]] | Adult | D- | 40 | 0.7 m | Night | A typical adult Vesper-Touched Saboteur Gremlin of this region, with soot-stained hide and scavenged scraps. |
| `pop_05230` | Lirian Vesper-Touched Saboteur Gremlin Scarred | [[Regions/Lirian\|Lirian]] | Scarred | D | 48 | 0.77 m | Night | Like a typical Vesper-Touched Saboteur Gremlin, but covered in old battle scars, with soot-stained hide and scavenged scraps. |
| `pop_05231` | Aldmere Vesper-Touched Saboteur Gremlin Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | D+ | 56 | 0.88 m | Night | Like a typical Vesper-Touched Saboteur Gremlin, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_05232` | Lirian Vesper-Touched Saboteur Gremlin Runt | [[Regions/Lirian\|Lirian]] | Runt | E | 26 | 0.49 m | Night | Like a typical Vesper-Touched Saboteur Gremlin, but smaller and scrappier than usual, with soot-stained hide and scavenged scraps. |
| `pop_05233` | Aldmere Vesper-Touched Saboteur Gremlin Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | D | 48 | 0.77 m | Night | Like a typical Vesper-Touched Saboteur Gremlin, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_05234` | Aldmere Vesper-Touched Saboteur Gremlin Runt | [[Regions/Aldmere\|Aldmere]] | Runt | E | 26 | 0.49 m | Night | Like a typical Vesper-Touched Saboteur Gremlin, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `rubbery_skin` · VFX `arc_sparks` · palette `#ffe14d` `#6c5ce7` `#1b1b3a` · elongated, irregular silhouette; still-then-sudden timing
