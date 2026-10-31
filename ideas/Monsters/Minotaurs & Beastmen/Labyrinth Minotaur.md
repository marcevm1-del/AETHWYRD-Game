---
type: monster
id: mon_labyrinth_minotaur
family: "Minotaurs & Beastmen"
rank: "B"
tier: core
tags: [monster, minotaurs-beastmen]
---
# Labyrinth Minotaur

![[mon_labyrinth_minotaur_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_labyrinth_minotaur_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,158 tris · 3.436 × 1.975 × 4 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Labyrinth Minotaur is a large creature with a towering, heavy-limbed body, about 4 m tall. Its hide is rough, scarred and spiked, colored in dark chestnut, with ochre markings. Survivors describe horns carved with maze runes. It has eyes that catch torchlight like coins. Faint runes glow along its body when it fights. It charges without hesitation, surrounded by pebbles that tremble and float near it.

| Field | Value |
|---|---|
| Family · type | [[Families/Minotaurs & Beastmen|Minotaurs & Beastmen]] · Beastman |
| Rank · level | B · 108 (96–120) |
| Menace | 3 · Menacing |
| Element · weakness | Earth · Wind |
| Size | 4 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 22688 · 442 · 663 · 265 · 442 · 70 |
| XP · gold | 5386 · 1057 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/large_biped\|large_biped]] · `anim_large_biped` |
| Habitats | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/Umbravel\|Umbravel]], [[Regions/Iron Hold\|Iron Hold]], [[Regions/Sunscar\|Sunscar]], [[Regions/Zarvan\|Zarvan]] |
| Genre | Labyrinth Myth |
| Trope | The minotaur that appears where it shouldn't (DanMachi), Greek labyrinth myth |

**Field note:** Weak to Wind. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/large_biped|large_biped]] (rigId); animation set `anim_large_biped`.
- **Dimensions:** 4 m high × 1.2 m long × 1.68 m wide; prefab scale 1.143.
- **Physics:** 1497.6 kg, gravity ×1.43, poise 239, knockback resistance 1, death style `heavy_fall_dust`.
- **Navigation:** speed 6.19 m/s, turn 190°/s, stopping distance 1.2 m.
- **Attack count:** 5; **signature:** horns carved with maze runes.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stomp\|Stomp]] | aoe | 1.3 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Club Slam\|Club Slam]] | melee | 1.8 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Grab and Throw\|Grab and Throw]] | grab | 2 | 14 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Horn Charge\|Horn Charge]] | dash | 1.8 | 9 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Labyrinth Minotaur is a **menacing beastman** encountered at B rank, around level 108. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** horns carved with maze runes. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]], [[Regions/Umbravel|Umbravel]], [[Regions/Iron Hold|Iron Hold]], [[Regions/Sunscar|Sunscar]], [[Regions/Zarvan|Zarvan]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_large_biped`, animation set `anim_large_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Minotaurs & Beastmen B|loot_minotaur_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Horn\|Horn]] | 60% | 1–3 |
| [[Items/Labyrinth Bronze\|Labyrinth Bronze]] | 30% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Minotaurs & Beastmen/Vesper-Touched Labyrinth Minotaur|Vesper-Touched Labyrinth Minotaur]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Zarvan\|Zarvan]] | 3 | A, C+, B | 86–146 | Day & Night |
| [[Regions/Iron Hold\|Iron Hold]] | 2 | A-, A | 132–146 | Day & Night |
| [[Regions/Sunscar\|Sunscar]] | 3 | B+, A, B- | 96–146 | Day & Night |
| [[Regions/Umbravel\|Umbravel]] | 1 | B+ | 120–120 | Day & Night |
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 2 | A-, B+ | 120–132 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01234` | Zarvan Labyrinth Minotaur Elderborn | [[Regions/Zarvan\|Zarvan]] | Elderborn | A | 146 | 5.4 m | Day & Night | Like a typical Labyrinth Minotaur, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_01235` | Zarvan Labyrinth Minotaur Runt | [[Regions/Zarvan\|Zarvan]] | Runt | C+ | 86 | 2.8 m | Day & Night | Like a typical Labyrinth Minotaur, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_01236` | Iron Hold Labyrinth Minotaur Alpha | [[Regions/Iron Hold\|Iron Hold]] | Alpha | A- | 132 | 5 m | Day & Night | Like a typical Labyrinth Minotaur, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_01237` | Iron Hold Labyrinth Minotaur Elderborn | [[Regions/Iron Hold\|Iron Hold]] | Elderborn | A | 146 | 5.4 m | Day & Night | Like a typical Labyrinth Minotaur, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_01238` | Zarvan Labyrinth Minotaur | [[Regions/Zarvan\|Zarvan]] | Adult | B | 108 | 4 m | Day & Night | A typical adult Labyrinth Minotaur of this region, with slate-grey coloring and hardened hide. |
| `pop_01239` | Sunscar Labyrinth Minotaur Scarred | [[Regions/Sunscar\|Sunscar]] | Scarred | B+ | 120 | 4.4 m | Day & Night | Like a typical Labyrinth Minotaur, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_01240` | Umbravel Labyrinth Minotaur Scarred | [[Regions/Umbravel\|Umbravel]] | Scarred | B+ | 120 | 4.4 m | Day & Night | Like a typical Labyrinth Minotaur, but covered in old battle scars, with bioluminescent spots along its body. |
| `pop_01241` | Great Labyrinth (Floors 41-90) Labyrinth Minotaur Alpha | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Alpha | A- | 132 | 5 m | Day & Night | Like a typical Labyrinth Minotaur, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_01242` | Sunscar Labyrinth Minotaur Elderborn | [[Regions/Sunscar\|Sunscar]] | Elderborn | A | 146 | 5.4 m | Day & Night | Like a typical Labyrinth Minotaur, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_01243` | Great Labyrinth (Floors 41-90) Labyrinth Minotaur Scarred | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Scarred | B+ | 120 | 4.4 m | Day & Night | Like a typical Labyrinth Minotaur, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_01244` | Sunscar Labyrinth Minotaur Juvenile | [[Regions/Sunscar\|Sunscar]] | Juvenile | B- | 96 | 3.4 m | Day & Night | Like a typical Labyrinth Minotaur, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |

## Design recipe

Rig `rig_large_biped` · mesh `large_biped_base` · material `short_hide` · VFX `rock_debris` · palette `#76553a` `#513c2c` `#d1a15a` · triangle-based silhouette, sharp asymmetric spikes
