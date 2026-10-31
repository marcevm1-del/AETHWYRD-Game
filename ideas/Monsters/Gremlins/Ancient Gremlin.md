---
type: monster
id: mon_ancient_gremlin
family: "Gremlins"
rank: "E"
tier: variant
tags: [monster, gremlins]
---
# Ancient Gremlin

![[mon_ancient_gremlin_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_ancient_gremlin_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,722 tris · 0.446 × 0.483 × 0.9 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Ancient Gremlin is a small creature with a small, compact humanoid body, about 0.9 m tall. Its skin is weathered and natural, colored in lime-green, with electric-yellow markings. Look for bat ears, a wrench and a laugh like a squeaky hinge. It has dark, wary eyes. Small scars and rough edges mark it as a survivor. It stalks low to the ground, surrounded by crackling arcs that jump across its body. Moss, crystals and centuries-old scars cover its body; it has outlived every hunter sent after it.

| Field | Value |
|---|---|
| Family · type | [[Families/Gremlins|Gremlins]] · Fey Pest |
| Variant of | [[Monsters/Gremlins/Gremlin\|Gremlin]] (ancient) |
| Rank · level | E · 26 (19–32) |
| Menace | 2 · Wild |
| Element · weakness | Lightning · Earth |
| Size | 0.9 m |
| Behaviour | Swarm (swarm_surround) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1030 · 114 · 91 · 80 · 91 · 135 |
| XP · gold | 559 · 147 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/small_biped\|small_biped]] · `anim_small_biped` |
| Habitats | [[Regions/Lirian\|Lirian]], [[Regions/Aldmere\|Aldmere]] |
| Genre | Steampunk Mischief |
| Trope | Machine-breaking pests |

**Field note:** Weak to Earth. Dangerous in numbers. Area attacks and chokepoints help.

## Motion implementation

- **Rig:** [[Systems/Rigs/small_biped|small_biped]] (rigId); animation set `anim_small_biped`.
- **Dimensions:** 0.9 m high × 0.27 m long × 0.36 m wide; prefab scale 0.818.
- **Physics:** 11.7 kg, gravity ×1.5, poise 31, knockback resistance 0.18, death style `ragdoll_crumple`.
- **Navigation:** speed 4.96 m/s, turn 443°/s, stopping distance 0.58 m.
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

Ancient Gremlin is a **wild fey pest** encountered at E rank, around level 26. Its documented behaviour is *Swarm* and its AI pattern is *swarm_surround*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Earth**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** bat ears, a wrench and a laugh like a squeaky hinge. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Lirian|Lirian]], [[Regions/Aldmere|Aldmere]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_small_biped`, animation set `anim_small_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Gremlins E|loot_gremlin_e]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Stolen Bolt\|Stolen Bolt]] | 60% | 1–3 |
| [[Items/Gremlin Ear\|Gremlin Ear]] | 30% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Aldmere\|Aldmere]] | 5 | D, E+, E-, E, D- | 19–48 | Day & Night |
| [[Regions/Lirian\|Lirian]] | 6 | E, D-, D, E+, F+ | 13–48 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05213` | Aldmere Ancient Gremlin Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | D | 48 | 1.22 m | Day & Night | Like a typical Ancient Gremlin, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_05214` | Lirian Ancient Gremlin | [[Regions/Lirian\|Lirian]] | Adult | E | 26 | 0.9 m | Day & Night | A typical adult Ancient Gremlin of this region, with soot-stained hide and scavenged scraps. |
| `pop_05215` | Aldmere Ancient Gremlin Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | E+ | 32 | 0.99 m | Day & Night | Like a typical Ancient Gremlin, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_05216` | Lirian Ancient Gremlin Alpha | [[Regions/Lirian\|Lirian]] | Alpha | D- | 40 | 1.13 m | Day & Night | Like a typical Ancient Gremlin, but larger and scarred, and others of its kind follow it, with soot-stained hide and scavenged scraps. |
| `pop_05217` | Lirian Ancient Gremlin Elderborn | [[Regions/Lirian\|Lirian]] | Elderborn | D | 48 | 1.22 m | Day & Night | Like a typical Ancient Gremlin, but old and wise, with greying features and a cautious hunting style, with soot-stained hide and scavenged scraps. |
| `pop_05218` | Lirian Ancient Gremlin Albino | [[Regions/Lirian\|Lirian]] | Albino | E+ | 32 | 0.9 m | Day & Night | Like a typical Ancient Gremlin, but a rare pale form with white skin or fur and red eyes. |
| `pop_05219` | Aldmere Ancient Gremlin Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | E- | 19 | 0.77 m | Day & Night | Like a typical Ancient Gremlin, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_05220` | Aldmere Ancient Gremlin | [[Regions/Aldmere\|Aldmere]] | Adult | E | 26 | 0.9 m | Day & Night | A typical adult Ancient Gremlin of this region, with dust-grey coloring and old rune scars. |
| `pop_05221` | Lirian Ancient Gremlin Scarred | [[Regions/Lirian\|Lirian]] | Scarred | E+ | 32 | 0.99 m | Day & Night | Like a typical Ancient Gremlin, but covered in old battle scars, with soot-stained hide and scavenged scraps. |
| `pop_05222` | Lirian Ancient Gremlin Runt | [[Regions/Lirian\|Lirian]] | Runt | F+ | 13 | 0.63 m | Day & Night | Like a typical Ancient Gremlin, but smaller and scrappier than usual, with soot-stained hide and scavenged scraps. |
| `pop_05223` | Aldmere Ancient Gremlin Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | D- | 40 | 1.13 m | Day & Night | Like a typical Ancient Gremlin, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `rubbery_skin` · VFX `arc_sparks` · palette `#7aa34b` `#4e6c31` `#ffe14d` · real-animal silhouette with one fantasy exaggeration
