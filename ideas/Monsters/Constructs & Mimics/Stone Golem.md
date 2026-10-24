---
type: monster
id: mon_stone_golem
family: "Constructs & Mimics"
rank: "D"
tier: core
tags: [monster, constructs-mimics]
---
# Stone Golem

![[mon_stone_golem_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_stone_golem_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (940 tris · 2.939 × 1.816 × 3 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Stone Golem is a large creature with a blocky construct body, about 3 m tall. Its surface is weathered and natural, colored in ochre, clay and mossy stone. Look for a rune glowing on its back. It has dark, wary eyes. A distinctive marking runs along its back. It stalks low to the ground, surrounded by pebbles that tremble and float near it.

| Field | Value |
|---|---|
| Family · type | [[Families/Constructs & Mimics|Constructs & Mimics]] · Construct |
| Rank · level | D · 48 (40–56) |
| Menace | 2 · Wild |
| Element · weakness | Earth · Wind |
| Size | 3 m |
| Behaviour | Guardian (guardian_hold) |
| HP · ATK · DEF · MATK · MDEF · SPD | 6198 · 202 · 303 · 121 · 202 · 70 |
| XP · gold | 1477 · 342 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/golem\|golem]] · `anim_golem` |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Umbravel\|Umbravel]], [[Regions/Aldmere\|Aldmere]], [[Regions/Strife Marches\|Strife Marches]], [[Regions/Velmark\|Velmark]] |
| Genre | Ancient Ruins |
| Trope | Treasure-chest mimics and ancient guardian golems |

**Field note:** Weak to Wind. Protects something nearby: a nest, a treasure, or a place.

## Motion implementation

- **Rig:** [[Systems/Rigs/golem|golem]] (rigId); animation set `anim_golem`.
- **Dimensions:** 3 m high × 0.9 m long × 1.26 m wide; prefab scale 1.
- **Physics:** 1684.8 kg, gravity ×1.32, poise 260, knockback resistance 1, death style `crumble_into_rubble`.
- **Navigation:** speed 2.6 m/s, turn 115°/s, stopping distance 1.06 m.
- **Attack count:** 5; **signature:** a rune glowing on its back.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slam\|Slam]] | melee | 1.4 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Ground Pound\|Ground Pound]] | aoe | 1.8 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Stance\|Guard Stance]] | buff | 0 | 15 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Rune Pulse\|Rune Pulse]] | magic | 1.3 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Stone Golem is a **wild construct** encountered at D rank, around level 48. Its documented behaviour is *Guardian* and its AI pattern is *guardian_hold*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a rune glowing on its back. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Umbravel|Umbravel]], [[Regions/Aldmere|Aldmere]], [[Regions/Strife Marches|Strife Marches]], [[Regions/Velmark|Velmark]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_golem`, animation set `anim_golem`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Constructs & Mimics D|loot_construct_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Golem Core\|Golem Core]] | 60% | 1–3 |
| [[Items/Rune Plate\|Rune Plate]] | 30% | 1–1 |
| [[Items/Gear\|Gear]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Constructs & Mimics/Greater Stone Golem|Greater Stone Golem]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Umbravel\|Umbravel]] | 4 | C-, D+, D, D- | 40–65 | Day & Night |
| [[Regions/Velmark\|Velmark]] | 3 | E+, D+, D- | 32–56 | Day & Night |
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 2 | C-, D- | 40–65 | Day & Night |
| [[Regions/Strife Marches\|Strife Marches]] | 1 | C | 76–76 | Day & Night |
| [[Regions/Aldmere\|Aldmere]] | 1 | D | 48–48 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01484` | Umbravel Stone Golem Alpha | [[Regions/Umbravel\|Umbravel]] | Alpha | C- | 65 | 3.75 m | Day & Night | Like a typical Stone Golem, but larger and scarred, and others of its kind follow it, with bioluminescent spots along its body. |
| `pop_01485` | Velmark Stone Golem Runt | [[Regions/Velmark\|Velmark]] | Runt | E+ | 32 | 2.1 m | Day & Night | Like a typical Stone Golem, but smaller and scrappier than usual, with soot-stained hide and scavenged scraps. |
| `pop_01486` | Great Labyrinth (Floors 1-40) Stone Golem Alpha | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Alpha | C- | 65 | 3.75 m | Day & Night | Like a typical Stone Golem, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_01487` | Great Labyrinth (Floors 1-40) Stone Golem Juvenile | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Juvenile | D- | 40 | 2.55 m | Day & Night | Like a typical Stone Golem, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_01488` | Umbravel Stone Golem Albino | [[Regions/Umbravel\|Umbravel]] | Albino | D+ | 56 | 3 m | Day & Night | Like a typical Stone Golem, but a rare pale form with white skin or fur and red eyes. |
| `pop_01489` | Umbravel Stone Golem | [[Regions/Umbravel\|Umbravel]] | Adult | D | 48 | 3 m | Day & Night | A typical adult Stone Golem of this region, with bioluminescent spots along its body. |
| `pop_01490` | Umbravel Stone Golem Juvenile | [[Regions/Umbravel\|Umbravel]] | Juvenile | D- | 40 | 2.55 m | Day & Night | Like a typical Stone Golem, but young, with brighter colors and unworn features, with bioluminescent spots along its body. |
| `pop_01491` | Strife Marches Stone Golem Elderborn | [[Regions/Strife Marches\|Strife Marches]] | Elderborn | C | 76 | 4.05 m | Day & Night | Like a typical Stone Golem, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_01492` | Velmark Stone Golem Albino | [[Regions/Velmark\|Velmark]] | Albino | D+ | 56 | 3 m | Day & Night | Like a typical Stone Golem, but a rare pale form with white skin or fur and red eyes. |
| `pop_01493` | Aldmere Stone Golem | [[Regions/Aldmere\|Aldmere]] | Adult | D | 48 | 3 m | Day & Night | A typical adult Stone Golem of this region, with dust-grey coloring and old rune scars. |
| `pop_01494` | Velmark Stone Golem Juvenile | [[Regions/Velmark\|Velmark]] | Juvenile | D- | 40 | 2.55 m | Day & Night | Like a typical Stone Golem, but young, with brighter colors and unworn features, with soot-stained hide and scavenged scraps. |

## Design recipe

Rig `rig_golem` · mesh `golem_base` · material `stone_metal_runes` · VFX `rock_debris` · palette `#8b5a2b` `#c2a878` `#4a4a3a` · real-animal silhouette with one fantasy exaggeration
