---
type: monster
id: mon_vesper_touched_bone_crawler
family: "Undead"
rank: "E-"
tier: variant
tags: [monster, undead]
---
# Vesper-Touched Bone Crawler

![[mon_vesper_touched_bone_crawler_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_vesper_touched_bone_crawler_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,564 tris · 1.389 × 1.285 × 1.4 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Vesper-Touched Bone Crawler is a person-sized creature with an asymmetric body with too many limbs, about 1.4 m tall. Its flesh and bone are stretched, stitched and constantly shifting, colored in bleached bone and grave-cloth, with violet markings. Survivors describe a skeleton reassembled wrong, crawling on its hands. It has no eyes at all, only a wide and patient mouth. Small scars and rough edges mark it as a survivor. It unfolds into something larger, surrounded by shadows that lean toward it. Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Variant of | [[Monsters/Undead/Bone Crawler\|Bone Crawler]] (corrupted) |
| Rank · level | E- · 19 (13–26) |
| Menace | 5 · Horror |
| Element · weakness | Dark · Light |
| Size | 1.4 m |
| Behaviour | Aggressive (aggressive_chase+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 901 · 108 · 77 · 77 · 77 · 100 |
| XP · gold | 342 · 96 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/amorphous\|amorphous]] · `anim_aberrant` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] |
| Genre | Gothic Horror |
| Trope | Graveyard night threats; the lich and its phylactery; the vampire noble |

**Field note:** Weak to Light. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/amorphous|amorphous]] (rigId); animation set `anim_aberrant`.
- **Dimensions:** 1.4 m high × 1.5 m long × 1.47 m wide; prefab scale 0.7.
- **Physics:** 82.3 kg, gravity ×1.2, poise 41, knockback resistance 0.63, death style `collapse_and_melt`.
- **Navigation:** speed 6.36 m/s, turn 423°/s, stopping distance 0.82 m.
- **Attack count:** 5; **signature:** a skeleton reassembled wrong, crawling on its hands.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Grasp\|Grasp]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Unfold\|Unfold]] | aoe | 1.8 | 12 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Mimic Voice\|Mimic Voice]] | debuff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Grave Grasp\|Grave Grasp]] | grab | 1.2 | 10 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Vesper-Touched Bone Crawler is a **horror undead** encountered at E- rank, around level 19. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a skeleton reassembled wrong, crawling on its hands. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Whisperwood|Whisperwood]], [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_aberrant`, animation set `anim_aberrant`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Undead E|loot_undead_e]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Bone Dust\|Bone Dust]] | 60% | 1–3 |
| [[Items/Grave Cloth\|Grave Cloth]] | 30% | 1–1 |
| [[Items/Soul Ember\|Soul Ember]] | 15% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Whisperwood\|Whisperwood]] | 5 | F+, E, D-, F, E- | 8–40 | Night |
| [[Regions/Aldmere\|Aldmere]] | 4 | E-, F, D-, E | 8–40 | Night |
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 2 | F, E+ | 8–32 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03738` | Whisperwood Vesper-Touched Bone Crawler Juvenile | [[Regions/Whisperwood\|Whisperwood]] | Juvenile | F+ | 13 | 1.19 m | Night | Like a typical Vesper-Touched Bone Crawler, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_03739` | Aldmere Vesper-Touched Bone Crawler | [[Regions/Aldmere\|Aldmere]] | Adult | E- | 19 | 1.4 m | Night | A typical adult Vesper-Touched Bone Crawler of this region, with mud-slick, algae-streaked skin. |
| `pop_03740` | Whisperwood Vesper-Touched Bone Crawler Albino | [[Regions/Whisperwood\|Whisperwood]] | Albino | E | 26 | 1.4 m | Night | Like a typical Vesper-Touched Bone Crawler, but a rare pale form with white skin or fur and red eyes. |
| `pop_03741` | Aldmere Vesper-Touched Bone Crawler Runt | [[Regions/Aldmere\|Aldmere]] | Runt | F | 8 | 0.98 m | Night | Like a typical Vesper-Touched Bone Crawler, but smaller and scrappier than usual, with mud-slick, algae-streaked skin. |
| `pop_03742` | Great Labyrinth (Floors 1-40) Vesper-Touched Bone Crawler Runt | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Runt | F | 8 | 0.98 m | Night | Like a typical Vesper-Touched Bone Crawler, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_03743` | Whisperwood Vesper-Touched Bone Crawler Elderborn | [[Regions/Whisperwood\|Whisperwood]] | Elderborn | D- | 40 | 1.89 m | Night | Like a typical Vesper-Touched Bone Crawler, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_03744` | Whisperwood Vesper-Touched Bone Crawler Runt | [[Regions/Whisperwood\|Whisperwood]] | Runt | F | 8 | 0.98 m | Night | Like a typical Vesper-Touched Bone Crawler, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_03745` | Aldmere Vesper-Touched Bone Crawler Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | D- | 40 | 1.89 m | Night | Like a typical Vesper-Touched Bone Crawler, but old and wise, with greying features and a cautious hunting style, with mud-slick, algae-streaked skin. |
| `pop_03746` | Whisperwood Vesper-Touched Bone Crawler | [[Regions/Whisperwood\|Whisperwood]] | Adult | E- | 19 | 1.4 m | Night | A typical adult Vesper-Touched Bone Crawler of this region, with dust-grey coloring and old rune scars. |
| `pop_03747` | Aldmere Vesper-Touched Bone Crawler Albino | [[Regions/Aldmere\|Aldmere]] | Albino | E | 26 | 1.4 m | Night | Like a typical Vesper-Touched Bone Crawler, but a rare pale form with white skin or fur and red eyes. |
| `pop_03748` | Great Labyrinth (Floors 1-40) Vesper-Touched Bone Crawler Alpha | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Alpha | E+ | 32 | 1.75 m | Night | Like a typical Vesper-Touched Bone Crawler, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |

## Design recipe

Rig `rig_aberrant` · mesh `aberrant_base` · material `rot_bone` · VFX `shadow_wisps` · palette `#ead8bf` `#968671` `#9a86d8` · broken symmetry, mimicry, audio-first reveal
