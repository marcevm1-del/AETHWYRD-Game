---
type: monster
id: mon_deep_minotaur
family: "Minotaurs & Beastmen"
rank: "C+"
tier: variant
tags: [monster, minotaurs-beastmen]
---
# Deep Minotaur

![[mon_deep_minotaur_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_deep_minotaur_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,238 tris · 2.748 × 1.662 × 3.2 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Deep Minotaur is a large creature with a giant, barrel-chested humanoid body, about 3.2 m tall. Its hide is rough, scarred and spiked, colored in ink black with bruised violet. Guild sketches always show a bull's head, a massive labrys axe and snorting breath. It has burning slit pupils. Battle-worn plates and trophies hang from its body. It circles its prey, surrounded by shadows that lean toward it. Adapted to underworld lands, it has bioluminescent spots along its body.

| Field | Value |
|---|---|
| Family · type | [[Families/Minotaurs & Beastmen|Minotaurs & Beastmen]] · Beastman |
| Variant of | [[Monsters/Minotaurs & Beastmen/Minotaur\|Minotaur]] (regional) |
| Rank · level | C+ · 86 (76–96) |
| Menace | 3 · Menacing |
| Element · weakness | Dark · Light |
| Size | 3.2 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 15014 · 354 · 531 · 212 · 354 · 70 |
| XP · gold | 3743 · 769 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/large_biped\|large_biped]] · `anim_large_biped` |
| Habitats | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] |
| Genre | Labyrinth Myth |
| Trope | The minotaur that appears where it shouldn't (DanMachi), Greek labyrinth myth |

**Field note:** Weak to Light. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/large_biped|large_biped]] (rigId); animation set `anim_large_biped`.
- **Dimensions:** 3.2 m high × 0.96 m long × 1.34 m wide; prefab scale 0.914.
- **Physics:** 589.8 kg, gravity ×1.3, poise 194, knockback resistance 0.84, death style `heavy_fall_dust`.
- **Navigation:** speed 6.32 m/s, turn 212°/s, stopping distance 1.04 m.
- **Attack count:** 5; **signature:** a bull's head, a massive labrys axe and snorting breath.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stomp\|Stomp]] | aoe | 1.3 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Club Slam\|Club Slam]] | melee | 1.8 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Grab and Throw\|Grab and Throw]] | grab | 2 | 14 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Horn Charge\|Horn Charge]] | dash | 1.8 | 9 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Deep Minotaur is a **menacing beastman** encountered at C+ rank, around level 86. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a bull's head, a massive labrys axe and snorting breath. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]], [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_large_biped`, animation set `anim_large_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Minotaurs & Beastmen C|loot_minotaur_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Horn\|Horn]] | 60% | 1–3 |
| [[Items/Labyrinth Bronze\|Labyrinth Bronze]] | 30% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 6 | B, B-, C+, C-, C, B+ | 65–120 | Day & Night |
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 5 | B-, C-, B, C+ | 65–108 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04113` | Great Labyrinth (Floors 1-40) Deep Minotaur Alpha | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Alpha | B | 108 | 4 m | Day & Night | Like a typical Deep Minotaur, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_04114` | Great Labyrinth (Floors 41-90) Deep Minotaur Scarred | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Scarred | B- | 96 | 3.52 m | Day & Night | Like a typical Deep Minotaur, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_04115` | Great Labyrinth (Floors 1-40) Deep Minotaur Albino | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Albino | B- | 96 | 3.2 m | Day & Night | Like a typical Deep Minotaur, but a rare pale form with white skin or fur and red eyes. |
| `pop_04116` | Great Labyrinth (Floors 1-40) Deep Minotaur | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Adult | C+ | 86 | 3.2 m | Day & Night | A typical adult Deep Minotaur of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_04117` | Great Labyrinth (Floors 41-90) Deep Minotaur Albino | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Albino | B- | 96 | 3.2 m | Day & Night | Like a typical Deep Minotaur, but a rare pale form with white skin or fur and red eyes. |
| `pop_04118` | Great Labyrinth (Floors 1-40) Deep Minotaur Runt | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Runt | C- | 65 | 2.24 m | Day & Night | Like a typical Deep Minotaur, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_04119` | Great Labyrinth (Floors 41-90) Deep Minotaur Runt | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Runt | C- | 65 | 2.24 m | Day & Night | Like a typical Deep Minotaur, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_04120` | Great Labyrinth (Floors 41-90) Deep Minotaur Alpha | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Alpha | B | 108 | 4 m | Day & Night | Like a typical Deep Minotaur, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_04121` | Great Labyrinth (Floors 1-40) Deep Minotaur Juvenile | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Juvenile | C | 76 | 2.72 m | Day & Night | Like a typical Deep Minotaur, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_04122` | Great Labyrinth (Floors 41-90) Deep Minotaur | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Adult | C+ | 86 | 3.2 m | Day & Night | A typical adult Deep Minotaur of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_04123` | Great Labyrinth (Floors 1-40) Deep Minotaur Elderborn | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Elderborn | B+ | 120 | 4.32 m | Day & Night | Like a typical Deep Minotaur, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |

## Design recipe

Rig `rig_large_biped` · mesh `large_biped_base` · material `short_hide` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · triangle-based silhouette, sharp asymmetric spikes
