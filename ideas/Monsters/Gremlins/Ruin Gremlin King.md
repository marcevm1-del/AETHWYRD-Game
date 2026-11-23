---
type: monster
id: mon_ruin_gremlin_king
family: "Gremlins"
rank: "C+"
tier: variant
tags: [monster, gremlins]
---
# Ruin Gremlin King

![[mon_ruin_gremlin_king_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_ruin_gremlin_king_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 12,000 tris · 0.599 × 1.06 × 1.201 m · local file `Game/Assets/_Game/Art/Models/Monsters/Gremlins/mon_ruin_gremlin_king.fbx`

> The Ruin Gremlin King is a person-sized creature with a hunched, wiry humanoid frame, about 1.2 m tall. Its skin is rough, scarred and spiked, colored in lime-green, with violet markings. Guild sketches always show a throne bolted onto a walking boiler. It has burning slit pupils. Battle-worn plates and trophies hang from its body. It strides with heavy steps, surrounded by shadows that lean toward it. Adapted to ruins lands, it has dust-grey coloring and old rune scars.

| Field | Value |
|---|---|
| Family · type | [[Families/Gremlins|Gremlins]] · Fey Pest |
| Variant of | [[Monsters/Gremlins/Gremlin King\|Gremlin King]] (regional) |
| Rank · level | C+ · 86 (76–96) |
| Menace | 3 · Menacing |
| Element · weakness | Dark · Light |
| Size | 1.2 m |
| Behaviour | Swarm (swarm_surround) |
| HP · ATK · DEF · MATK · MDEF · SPD | 6533 · 354 · 283 · 248 · 283 · 135 |
| XP · gold | 3743 · 769 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/small_biped\|small_biped]] · `anim_small_biped` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Sunscar\|Sunscar]] |
| Genre | Steampunk Mischief |
| Trope | Machine-breaking pests |

**Field note:** Weak to Light. Dangerous in numbers. Area attacks and chokepoints help.

## Motion implementation

- **Rig:** [[Systems/Rigs/small_biped|small_biped]] (rigId); animation set `anim_small_biped`.
- **Dimensions:** 1.2 m high × 0.36 m long × 0.48 m wide; prefab scale 1.091.
- **Physics:** 27.6 kg, gravity ×1.5, poise 45, knockback resistance 0.24, death style `ragdoll_crumple`.
- **Navigation:** speed 5.84 m/s, turn 383°/s, stopping distance 0.64 m.
- **Attack count:** 5; **signature:** a throne bolted onto a walking boiler.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stab\|Stab]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Thrown Junk\|Thrown Junk]] | ranged | 0.8 | 4 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Frenzied Lunge\|Frenzied Lunge]] | melee | 1.5 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Wrench Sabotage\|Wrench Sabotage]] | debuff | 0 | 14 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Ruin Gremlin King is a **menacing fey pest** encountered at C+ rank, around level 86. Its documented behaviour is *Swarm* and its AI pattern is *swarm_surround*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a throne bolted onto a walking boiler. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Sunscar|Sunscar]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_small_biped`, animation set `anim_small_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Gremlins C|loot_gremlin_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Stolen Bolt\|Stolen Bolt]] | 60% | 1–3 |
| [[Items/Gremlin Ear\|Gremlin Ear]] | 30% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Sunscar\|Sunscar]] | 6 | B, C-, B+, C, B-, C+ | 65–120 | Day & Night |
| [[Regions/Aldmere\|Aldmere]] | 5 | C, B, B+, B-, C- | 65–120 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05235` | Sunscar Ruin Gremlin King Alpha | [[Regions/Sunscar\|Sunscar]] | Alpha | B | 108 | 1.5 m | Day & Night | Like a typical Ruin Gremlin King, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_05236` | Sunscar Ruin Gremlin King Runt | [[Regions/Sunscar\|Sunscar]] | Runt | C- | 65 | 0.84 m | Day & Night | Like a typical Ruin Gremlin King, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_05237` | Sunscar Ruin Gremlin King Elderborn | [[Regions/Sunscar\|Sunscar]] | Elderborn | B+ | 120 | 1.62 m | Day & Night | Like a typical Ruin Gremlin King, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_05238` | Sunscar Ruin Gremlin King Juvenile | [[Regions/Sunscar\|Sunscar]] | Juvenile | C | 76 | 1.02 m | Day & Night | Like a typical Ruin Gremlin King, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_05239` | Sunscar Ruin Gremlin King Albino | [[Regions/Sunscar\|Sunscar]] | Albino | B- | 96 | 1.2 m | Day & Night | Like a typical Ruin Gremlin King, but a rare pale form with white skin or fur and red eyes. |
| `pop_05240` | Aldmere Ruin Gremlin King Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | C | 76 | 1.02 m | Day & Night | Like a typical Ruin Gremlin King, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_05241` | Sunscar Ruin Gremlin King | [[Regions/Sunscar\|Sunscar]] | Adult | C+ | 86 | 1.2 m | Day & Night | A typical adult Ruin Gremlin King of this region, with dust-grey coloring and old rune scars. |
| `pop_05242` | Aldmere Ruin Gremlin King Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | B | 108 | 1.5 m | Day & Night | Like a typical Ruin Gremlin King, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_05243` | Aldmere Ruin Gremlin King Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | B+ | 120 | 1.62 m | Day & Night | Like a typical Ruin Gremlin King, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_05244` | Aldmere Ruin Gremlin King Albino | [[Regions/Aldmere\|Aldmere]] | Albino | B- | 96 | 1.2 m | Day & Night | Like a typical Ruin Gremlin King, but a rare pale form with white skin or fur and red eyes. |
| `pop_05245` | Aldmere Ruin Gremlin King Runt | [[Regions/Aldmere\|Aldmere]] | Runt | C- | 65 | 0.84 m | Day & Night | Like a typical Ruin Gremlin King, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `rubbery_skin` · VFX `shadow_wisps` · palette `#719344` `#49612c` `#9a86d8` · triangle-based silhouette, sharp asymmetric spikes
