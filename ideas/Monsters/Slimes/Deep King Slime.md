---
type: monster
id: mon_deep_king_slime
family: "Slimes"
rank: "C+"
tier: variant
tags: [monster, slimes]
---
# Deep King Slime

![[mon_deep_king_slime_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_deep_king_slime_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (1,712 tris · 3.358 × 3.358 × 3 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Deep King Slime is a large creature with a dome-shaped gelatinous body, about 3 m tall. Its gel is weathered and natural, colored in ink black with bruised violet. Its most striking feature is a crown made of smaller slimes fused together. It has amber predator eyes. Battle-worn plates and trophies hang from its body. It prowls, surrounded by shadows that lean toward it. Adapted to underworld lands, it has bioluminescent spots along its body.

| Field | Value |
|---|---|
| Family · type | [[Families/Slimes|Slimes]] · Ooze |
| Variant of | [[Monsters/Slimes/King Slime\|King Slime]] (regional) |
| Rank · level | C+ · 86 (76–96) |
| Menace | 2 · Wild |
| Element · weakness | Dark · Light |
| Size | 3 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 7346 · 283 · 212 · 212 · 212 · 110 |
| XP · gold | 3743 · 769 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/blob\|blob]] · `anim_blob` |
| Habitats | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Umbravel\|Umbravel]] |
| Genre | Classic Fantasy |
| Trope | The cute first enemy (Dragon Quest) and the evolving hero (Tensura) |

**Field note:** Weak to Light. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/blob|blob]] (rigId); animation set `anim_blob`.
- **Dimensions:** 3 m high × 2.79 m long × 2.7 m wide; prefab scale 6.
- **Physics:** 14175 kg, gravity ×1.6, poise 89, knockback resistance 0.19, death style `splat_dissolve`.
- **Navigation:** speed 9.87 m/s, turn 208°/s, stopping distance 1.75 m.
- **Attack count:** 5; **signature:** a crown made of smaller slimes fused together.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Body Slam\|Body Slam]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Engulf\|Engulf]] | grab | 1.4 | 8 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Split\|Split]] | summon | 0 | 20 s | None | none | Interrupt or reposition; watch for added enemies. |
| [[Attacks/Acid Splash\|Acid Splash]] | ranged | 1.1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Deep King Slime is a **wild ooze** encountered at C+ rank, around level 86. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a crown made of smaller slimes fused together. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]], [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Umbravel|Umbravel]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_blob`, animation set `anim_blob`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Slimes C|loot_slime_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Slime Jelly\|Slime Jelly]] | 60% | 1–3 |
| [[Items/Gel Core\|Gel Core]] | 30% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 3 | C+, C-, B+ | 65–120 | Day & Night |
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 5 | C, B+, C+, B, B- | 76–120 | Day & Night |
| [[Regions/Umbravel\|Umbravel]] | 3 | C+, C-, B+ | 65–120 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03005` | Great Labyrinth (Floors 41-90) Deep King Slime | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Adult | C+ | 86 | 3 m | Day & Night | A typical adult Deep King Slime of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_03006` | Great Labyrinth (Floors 1-40) Deep King Slime Juvenile | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Juvenile | C | 76 | 2.55 m | Day & Night | Like a typical Deep King Slime, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_03007` | Umbravel Deep King Slime | [[Regions/Umbravel\|Umbravel]] | Adult | C+ | 86 | 3 m | Day & Night | A typical adult Deep King Slime of this region, with bioluminescent spots along its body. |
| `pop_03008` | Great Labyrinth (Floors 1-40) Deep King Slime Elderborn | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Elderborn | B+ | 120 | 4.05 m | Day & Night | Like a typical Deep King Slime, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_03009` | Umbravel Deep King Slime Runt | [[Regions/Umbravel\|Umbravel]] | Runt | C- | 65 | 2.1 m | Day & Night | Like a typical Deep King Slime, but smaller and scrappier than usual, with bioluminescent spots along its body. |
| `pop_03010` | Great Labyrinth (Floors 1-40) Deep King Slime | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Adult | C+ | 86 | 3 m | Day & Night | A typical adult Deep King Slime of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_03011` | Great Labyrinth (Floors 1-40) Deep King Slime Alpha | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Alpha | B | 108 | 3.75 m | Day & Night | Like a typical Deep King Slime, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_03012` | Great Labyrinth (Floors 1-40) Deep King Slime Albino | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Albino | B- | 96 | 3 m | Day & Night | Like a typical Deep King Slime, but a rare pale form with white skin or fur and red eyes. |
| `pop_03013` | Great Labyrinth (Floors 41-90) Deep King Slime Runt | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Runt | C- | 65 | 2.1 m | Day & Night | Like a typical Deep King Slime, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_03014` | Great Labyrinth (Floors 41-90) Deep King Slime Elderborn | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Elderborn | B+ | 120 | 4.05 m | Day & Night | Like a typical Deep King Slime, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_03015` | Umbravel Deep King Slime Elderborn | [[Regions/Umbravel\|Umbravel]] | Elderborn | B+ | 120 | 4.05 m | Day & Night | Like a typical Deep King Slime, but old and wise, with greying features and a cautious hunting style, with bioluminescent spots along its body. |

## Design recipe

Rig `rig_blob` · mesh `blob_base` · material `translucent_gel_sss` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · real-animal silhouette with one fantasy exaggeration
