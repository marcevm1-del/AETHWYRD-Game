---
type: monster
id: mon_cavern_gnoll_raider
family: "Minotaurs & Beastmen"
rank: "D+"
tier: variant
tags: [monster, minotaurs-beastmen]
---
# Cavern Gnoll Raider

![[mon_cavern_gnoll_raider_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_cavern_gnoll_raider_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,482 tris · 1.178 × 1.266 × 2 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Cavern Gnoll Raider is a person-sized creature with a broad-shouldered humanoid build, about 2 m tall. Its hide is rough, scarred and spiked, colored in tan, with ochre markings. Guild sketches always show a hyena head and a laugh that carries for miles. It has burning slit pupils. A distinctive marking runs along its back. It charges without hesitation, surrounded by pebbles that tremble and float near it. Adapted to cave lands, it has pale, light-starved coloring and oversized eyes.

| Field | Value |
|---|---|
| Family · type | [[Families/Minotaurs & Beastmen|Minotaurs & Beastmen]] · Beastman |
| Variant of | [[Monsters/Minotaurs & Beastmen/Gnoll Raider\|Gnoll Raider]] (regional) |
| Rank · level | D+ · 56 (48–65) |
| Menace | 3 · Menacing |
| Element · weakness | Earth · Wind |
| Size | 2 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 5324 · 281 · 234 · 187 · 211 · 100 |
| XP · gold | 1888 · 423 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Iron Hold\|Iron Hold]], [[Regions/Umbravel\|Umbravel]] |
| Genre | Labyrinth Myth |
| Trope | The minotaur that appears where it shouldn't (DanMachi), Greek labyrinth myth |

**Field note:** Weak to Wind. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 2 m high × 0.6 m long × 0.64 m wide; prefab scale 1.111.
- **Physics:** 135.2 kg, gravity ×1.65, poise 69, knockback resistance 0.51, death style `ragdoll`.
- **Navigation:** speed 4.78 m/s, turn 283°/s, stopping distance 0.74 m.
- **Attack count:** 5; **signature:** a hyena head and a laugh that carries for miles.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Horn Charge\|Horn Charge]] | dash | 1.8 | 9 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Cavern Gnoll Raider is a **menacing beastman** encountered at D+ rank, around level 56. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a hyena head and a laugh that carries for miles. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Iron Hold|Iron Hold]], [[Regions/Umbravel|Umbravel]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Minotaurs & Beastmen D|loot_minotaur_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Horn\|Horn]] | 60% | 1–3 |
| [[Items/Labyrinth Bronze\|Labyrinth Bronze]] | 30% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Umbravel\|Umbravel]] | 5 | C-, D-, C+, D | 40–86 | Day & Night |
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 4 | C-, C, D-, C+ | 40–86 | Day & Night |
| [[Regions/Iron Hold\|Iron Hold]] | 2 | D+, D | 48–56 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04102` | Umbravel Cavern Gnoll Raider Scarred | [[Regions/Umbravel\|Umbravel]] | Scarred | C- | 65 | 2.2 m | Day & Night | Like a typical Cavern Gnoll Raider, but covered in old battle scars, with bioluminescent spots along its body. |
| `pop_04103` | Umbravel Cavern Gnoll Raider Runt | [[Regions/Umbravel\|Umbravel]] | Runt | D- | 40 | 1.4 m | Day & Night | Like a typical Cavern Gnoll Raider, but smaller and scrappier than usual, with bioluminescent spots along its body. |
| `pop_04104` | Great Labyrinth (Floors 1-40) Cavern Gnoll Raider Scarred | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Scarred | C- | 65 | 2.2 m | Day & Night | Like a typical Cavern Gnoll Raider, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_04105` | Umbravel Cavern Gnoll Raider Elderborn | [[Regions/Umbravel\|Umbravel]] | Elderborn | C+ | 86 | 2.7 m | Day & Night | Like a typical Cavern Gnoll Raider, but old and wise, with greying features and a cautious hunting style, with bioluminescent spots along its body. |
| `pop_04106` | Great Labyrinth (Floors 1-40) Cavern Gnoll Raider Alpha | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Alpha | C | 76 | 2.5 m | Day & Night | Like a typical Cavern Gnoll Raider, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_04107` | Great Labyrinth (Floors 1-40) Cavern Gnoll Raider Runt | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Runt | D- | 40 | 1.4 m | Day & Night | Like a typical Cavern Gnoll Raider, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_04108` | Umbravel Cavern Gnoll Raider Albino | [[Regions/Umbravel\|Umbravel]] | Albino | C- | 65 | 2 m | Day & Night | Like a typical Cavern Gnoll Raider, but a rare pale form with white skin or fur and red eyes. |
| `pop_04109` | Iron Hold Cavern Gnoll Raider | [[Regions/Iron Hold\|Iron Hold]] | Adult | D+ | 56 | 2 m | Day & Night | A typical adult Cavern Gnoll Raider of this region, with slate-grey coloring and hardened hide. |
| `pop_04110` | Great Labyrinth (Floors 1-40) Cavern Gnoll Raider Elderborn | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Elderborn | C+ | 86 | 2.7 m | Day & Night | Like a typical Cavern Gnoll Raider, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_04111` | Iron Hold Cavern Gnoll Raider Juvenile | [[Regions/Iron Hold\|Iron Hold]] | Juvenile | D | 48 | 1.7 m | Day & Night | Like a typical Cavern Gnoll Raider, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_04112` | Umbravel Cavern Gnoll Raider Juvenile | [[Regions/Umbravel\|Umbravel]] | Juvenile | D | 48 | 1.7 m | Day & Night | Like a typical Cavern Gnoll Raider, but young, with brighter colors and unworn features, with bioluminescent spots along its body. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `short_hide` · VFX `rock_debris` · palette `#846246` `#59412f` `#d1a15a` · triangle-based silhouette, sharp asymmetric spikes
