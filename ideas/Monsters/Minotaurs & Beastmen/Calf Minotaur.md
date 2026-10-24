---
type: monster
id: mon_calf_minotaur
family: "Minotaurs & Beastmen"
rank: "D"
tier: core
tags: [monster, minotaurs-beastmen]
---
# Calf Minotaur

![[mon_calf_minotaur_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_calf_minotaur_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,610 tris · 1.718 × 1.024 × 2 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Calf Minotaur is a person-sized creature with a towering, heavy-limbed body, about 2 m tall. Its hide is rough, scarred and spiked, colored in muted greys and dusty browns. Guild sketches always show stubby horns and a bronze nose ring. It has eyes that catch torchlight like coins. A distinctive marking runs along its back. It circles its prey. It has no visible aura; you hear its breathing before you see it.

| Field | Value |
|---|---|
| Family · type | [[Families/Minotaurs & Beastmen|Minotaurs & Beastmen]] · Beastman |
| Rank · level | D · 48 (40–56) |
| Menace | 3 · Menacing |
| Element · weakness | None · Fire |
| Size | 2 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 5399 · 202 · 303 · 85 · 202 · 70 |
| XP · gold | 1477 · 342 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/large_biped\|large_biped]] · `anim_large_biped` |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Umbravel\|Umbravel]], [[Regions/Iron Hold\|Iron Hold]] |
| Genre | Labyrinth Myth |
| Trope | The minotaur that appears where it shouldn't (DanMachi), Greek labyrinth myth |

**Field note:** Weak to Fire. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/large_biped|large_biped]] (rigId); animation set `anim_large_biped`.
- **Dimensions:** 2 m high × 0.6 m long × 0.84 m wide; prefab scale 0.571.
- **Physics:** 144 kg, gravity ×1.3, poise 138, knockback resistance 0.81, death style `heavy_fall_dust`.
- **Navigation:** speed 4.76 m/s, turn 269°/s, stopping distance 0.8 m.
- **Attack count:** 4; **signature:** stubby horns and a bronze nose ring.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stomp\|Stomp]] | aoe | 1.3 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Club Slam\|Club Slam]] | melee | 1.8 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Grab and Throw\|Grab and Throw]] | grab | 2 | 14 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Horn Charge\|Horn Charge]] | dash | 1.8 | 9 s | None | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Calf Minotaur is a **menacing beastman** encountered at D rank, around level 48. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** stubby horns and a bronze nose ring. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Umbravel|Umbravel]], [[Regions/Iron Hold|Iron Hold]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_large_biped`, animation set `anim_large_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Minotaurs & Beastmen D|loot_minotaur_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Horn\|Horn]] | 60% | 1–3 |
| [[Items/Labyrinth Bronze\|Labyrinth Bronze]] | 30% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Minotaurs & Beastmen/Vesper-Touched Calf Minotaur|Vesper-Touched Calf Minotaur]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 6 | D+, C, C-, E+, D- | 32–76 | Day & Night |
| [[Regions/Umbravel\|Umbravel]] | 3 | D, D-, E+ | 32–48 | Day & Night |
| [[Regions/Iron Hold\|Iron Hold]] | 2 | D+, E+ | 32–56 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01190` | Great Labyrinth (Floors 1-40) Calf Minotaur Scarred | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Scarred | D+ | 56 | 2.2 m | Day & Night | Like a typical Calf Minotaur, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_01191` | Umbravel Calf Minotaur | [[Regions/Umbravel\|Umbravel]] | Adult | D | 48 | 2 m | Day & Night | A typical adult Calf Minotaur of this region, with bioluminescent spots along its body. |
| `pop_01192` | Umbravel Calf Minotaur Juvenile | [[Regions/Umbravel\|Umbravel]] | Juvenile | D- | 40 | 1.7 m | Day & Night | Like a typical Calf Minotaur, but young, with brighter colors and unworn features, with bioluminescent spots along its body. |
| `pop_01193` | Great Labyrinth (Floors 1-40) Calf Minotaur Elderborn | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Elderborn | C | 76 | 2.7 m | Day & Night | Like a typical Calf Minotaur, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_01194` | Great Labyrinth (Floors 1-40) Calf Minotaur Alpha | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Alpha | C- | 65 | 2.5 m | Day & Night | Like a typical Calf Minotaur, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_01195` | Great Labyrinth (Floors 1-40) Calf Minotaur Albino | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Albino | D+ | 56 | 2 m | Day & Night | Like a typical Calf Minotaur, but a rare pale form with white skin or fur and red eyes. |
| `pop_01196` | Iron Hold Calf Minotaur Albino | [[Regions/Iron Hold\|Iron Hold]] | Albino | D+ | 56 | 2 m | Day & Night | Like a typical Calf Minotaur, but a rare pale form with white skin or fur and red eyes. |
| `pop_01197` | Great Labyrinth (Floors 1-40) Calf Minotaur Runt | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Runt | E+ | 32 | 1.4 m | Day & Night | Like a typical Calf Minotaur, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_01198` | Iron Hold Calf Minotaur Runt | [[Regions/Iron Hold\|Iron Hold]] | Runt | E+ | 32 | 1.4 m | Day & Night | Like a typical Calf Minotaur, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_01199` | Great Labyrinth (Floors 1-40) Calf Minotaur Juvenile | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Juvenile | D- | 40 | 1.7 m | Day & Night | Like a typical Calf Minotaur, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_01200` | Umbravel Calf Minotaur Runt | [[Regions/Umbravel\|Umbravel]] | Runt | E+ | 32 | 1.4 m | Day & Night | Like a typical Calf Minotaur, but smaller and scrappier than usual, with bioluminescent spots along its body. |

## Design recipe

Rig `rig_large_biped` · mesh `large_biped_base` · material `short_hide` · VFX `dust_puffs` · palette `#8a8f98` `#5b5f66` `#c9c2b5` · triangle-based silhouette, sharp asymmetric spikes
