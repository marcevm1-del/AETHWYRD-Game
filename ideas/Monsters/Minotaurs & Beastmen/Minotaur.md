---
type: monster
id: mon_minotaur
family: "Minotaurs & Beastmen"
rank: "C"
tier: core
tags: [monster, minotaurs-beastmen]
---
# Minotaur

![[mon_minotaur_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_minotaur_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 19,996 tris · 2.314 × 2.995 × 3.2 m · local file `Game/Assets/_Game/Art/Models/Monsters/Minotaurs & Beastmen/mon_minotaur.fbx`

> The Minotaur is a large creature with a towering, heavy-limbed body, about 3.2 m tall. Its hide is rough, scarred and spiked, colored in tan, with ochre markings. Its most striking feature is a bull's head, a massive labrys axe and snorting breath. It has burning slit pupils. Battle-worn plates and trophies hang from its body. It circles its prey, surrounded by pebbles that tremble and float near it.

| Field | Value |
|---|---|
| Family · type | [[Families/Minotaurs & Beastmen|Minotaurs & Beastmen]] · Beastman |
| Rank · level | C · 76 (65–86) |
| Menace | 3 · Menacing |
| Element · weakness | Earth · Wind |
| Size | 3.2 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 12494 · 314 · 471 · 188 · 314 · 70 |
| XP · gold | 3073 · 648 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/large_biped\|large_biped]] · `anim_large_biped` |
| Habitats | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Umbravel\|Umbravel]], [[Regions/Iron Hold\|Iron Hold]] |
| Genre | Labyrinth Myth |
| Trope | The minotaur that appears where it shouldn't (DanMachi), Greek labyrinth myth |

**Field note:** Weak to Wind. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/large_biped|large_biped]] (rigId); animation set `anim_large_biped`.
- **Dimensions:** 3.2 m high × 0.96 m long × 1.34 m wide; prefab scale 0.914.
- **Physics:** 766.8 kg, gravity ×1.43, poise 194, knockback resistance 0.99, death style `heavy_fall_dust`.
- **Navigation:** speed 6.09 m/s, turn 212°/s, stopping distance 1.04 m.
- **Attack count:** 5; **signature:** a bull's head, a massive labrys axe and snorting breath.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stomp\|Stomp]] | aoe | 1.3 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Club Slam\|Club Slam]] | melee | 1.8 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Grab and Throw\|Grab and Throw]] | grab | 2 | 14 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Horn Charge\|Horn Charge]] | dash | 1.8 | 9 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Minotaur is a **menacing beastman** encountered at C rank, around level 76. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a bull's head, a massive labrys axe and snorting breath. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]], [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Umbravel|Umbravel]], [[Regions/Iron Hold|Iron Hold]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_large_biped`, animation set `anim_large_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Minotaurs & Beastmen C|loot_minotaur_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Horn\|Horn]] | 60% | 1–3 |
| [[Items/Labyrinth Bronze\|Labyrinth Bronze]] | 30% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Minotaurs & Beastmen/Deep Minotaur|Deep Minotaur]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Umbravel\|Umbravel]] | 3 | B-, C-, D+ | 56–96 | Day & Night |
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 2 | D+, C- | 56–65 | Day & Night |
| [[Regions/Iron Hold\|Iron Hold]] | 3 | B-, D+, C | 56–96 | Day & Night |
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 3 | B, D+, B- | 56–108 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01223` | Umbravel Minotaur Alpha | [[Regions/Umbravel\|Umbravel]] | Alpha | B- | 96 | 4 m | Day & Night | Like a typical Minotaur, but larger and scarred, and others of its kind follow it, with bioluminescent spots along its body. |
| `pop_01224` | Great Labyrinth (Floors 41-90) Minotaur Runt | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Runt | D+ | 56 | 2.24 m | Day & Night | Like a typical Minotaur, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_01225` | Umbravel Minotaur Juvenile | [[Regions/Umbravel\|Umbravel]] | Juvenile | C- | 65 | 2.72 m | Day & Night | Like a typical Minotaur, but young, with brighter colors and unworn features, with bioluminescent spots along its body. |
| `pop_01226` | Iron Hold Minotaur Alpha | [[Regions/Iron Hold\|Iron Hold]] | Alpha | B- | 96 | 4 m | Day & Night | Like a typical Minotaur, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_01227` | Iron Hold Minotaur Runt | [[Regions/Iron Hold\|Iron Hold]] | Runt | D+ | 56 | 2.24 m | Day & Night | Like a typical Minotaur, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_01228` | Great Labyrinth (Floors 41-90) Minotaur Juvenile | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Juvenile | C- | 65 | 2.72 m | Day & Night | Like a typical Minotaur, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_01229` | Great Labyrinth (Floors 1-40) Minotaur Elderborn | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Elderborn | B | 108 | 4.32 m | Day & Night | Like a typical Minotaur, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_01230` | Iron Hold Minotaur | [[Regions/Iron Hold\|Iron Hold]] | Adult | C | 76 | 3.2 m | Day & Night | A typical adult Minotaur of this region, with slate-grey coloring and hardened hide. |
| `pop_01231` | Great Labyrinth (Floors 1-40) Minotaur Runt | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Runt | D+ | 56 | 2.24 m | Day & Night | Like a typical Minotaur, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_01232` | Umbravel Minotaur Runt | [[Regions/Umbravel\|Umbravel]] | Runt | D+ | 56 | 2.24 m | Day & Night | Like a typical Minotaur, but smaller and scrappier than usual, with bioluminescent spots along its body. |
| `pop_01233` | Great Labyrinth (Floors 1-40) Minotaur Alpha | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Alpha | B- | 96 | 4 m | Day & Night | Like a typical Minotaur, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |

## Design recipe

Rig `rig_large_biped` · mesh `large_biped_base` · material `short_hide` · VFX `rock_debris` · palette `#91734d` `#624c34` `#d1a15a` · triangle-based silhouette, sharp asymmetric spikes
