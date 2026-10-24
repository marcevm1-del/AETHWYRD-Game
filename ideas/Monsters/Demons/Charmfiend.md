---
type: monster
id: mon_charmfiend
family: "Demons"
rank: "C+"
tier: core
tags: [monster, demons]
---
# Charmfiend

![[mon_charmfiend_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_charmfiend_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,498 tris · 0.691 × 0.736 × 1.8 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Charmfiend is a person-sized creature with a lean humanoid frame, about 1.8 m tall. Its hide is patchy and subtly wrong, as if assembled from memory, colored in ink black with bruised violet. Its most striking feature is a beautiful porcelain mask hiding a hollow face. It has pale, pupil-less eyes. Battle-worn plates and trophies hang from its body. It freezes whenever it is looked at, surrounded by shadows that lean toward it.

| Field | Value |
|---|---|
| Family · type | [[Families/Demons|Demons]] · Demon |
| Rank · level | C+ · 86 (76–96) |
| Menace | 4 · Dread |
| Element · weakness | Dark · Light |
| Size | 1.8 m |
| Behaviour | Aggressive (aggressive_chase+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 9701 · 425 · 354 · 283 · 319 · 100 |
| XP · gold | 3743 · 769 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Strife Marches\|Strife Marches]], [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] |
| Genre | Abyssal |
| Trope | Demons as a people of the Abyss, not just evil (Frieren, Maoyuu) |

**Field note:** Weak to Light. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 1.8 m high × 0.54 m long × 0.58 m wide; prefab scale 1.
- **Physics:** 75.8 kg, gravity ×1.5, poise 73, knockback resistance 0.39, death style `ragdoll`.
- **Navigation:** speed 5.43 m/s, turn 298°/s, stopping distance 0.71 m.
- **Attack count:** 5; **signature:** a beautiful porcelain mask hiding a hollow face.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Hellfire Brand\|Hellfire Brand]] | magic | 1.4 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Charmfiend is a **dread demon** encountered at C+ rank, around level 86. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a beautiful porcelain mask hiding a hollow face. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Strife Marches|Strife Marches]], [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Demons C|loot_demon_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Demon Core\|Demon Core]] | 60% | 1–3 |
| [[Items/Horn Shard\|Horn Shard]] | 30% | 1–1 |
| [[Items/Brimstone\|Brimstone]] | 15% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Demons/Hellmarch Charmfiend|Hellmarch Charmfiend]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 6 | B-, C+, B, C, C- | 65–108 | Night |
| [[Regions/Strife Marches\|Strife Marches]] | 2 | C-, B- | 65–96 | Night |
| [[Regions/Aldmere\|Aldmere]] | 3 | B-, C-, B+ | 65–120 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01857` | Great Labyrinth (Floors 41-90) Charmfiend Albino | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Albino | B- | 96 | 1.8 m | Night | Like a typical Charmfiend, but a rare pale form with white skin or fur and red eyes. |
| `pop_01858` | Strife Marches Charmfiend Runt | [[Regions/Strife Marches\|Strife Marches]] | Runt | C- | 65 | 1.26 m | Night | Like a typical Charmfiend, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_01859` | Aldmere Charmfiend Albino | [[Regions/Aldmere\|Aldmere]] | Albino | B- | 96 | 1.8 m | Night | Like a typical Charmfiend, but a rare pale form with white skin or fur and red eyes. |
| `pop_01860` | Great Labyrinth (Floors 41-90) Charmfiend Scarred | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Scarred | B- | 96 | 1.98 m | Night | Like a typical Charmfiend, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_01861` | Great Labyrinth (Floors 41-90) Charmfiend | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Adult | C+ | 86 | 1.8 m | Night | A typical adult Charmfiend of this region, with dust-grey coloring and old rune scars. |
| `pop_01862` | Aldmere Charmfiend Runt | [[Regions/Aldmere\|Aldmere]] | Runt | C- | 65 | 1.26 m | Night | Like a typical Charmfiend, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_01863` | Aldmere Charmfiend Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | B+ | 120 | 2.43 m | Night | Like a typical Charmfiend, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_01864` | Great Labyrinth (Floors 41-90) Charmfiend Alpha | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Alpha | B | 108 | 2.25 m | Night | Like a typical Charmfiend, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_01865` | Great Labyrinth (Floors 41-90) Charmfiend Juvenile | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Juvenile | C | 76 | 1.53 m | Night | Like a typical Charmfiend, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_01866` | Great Labyrinth (Floors 41-90) Charmfiend Runt | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Runt | C- | 65 | 1.26 m | Night | Like a typical Charmfiend, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_01867` | Strife Marches Charmfiend Albino | [[Regions/Strife Marches\|Strife Marches]] | Albino | B- | 96 | 1.8 m | Night | Like a typical Charmfiend, but a rare pale form with white skin or fur and red eyes. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `demon_hide_emissive` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · elongated, irregular silhouette; still-then-sudden timing
