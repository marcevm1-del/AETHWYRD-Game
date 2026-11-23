---
type: monster
id: mon_bone_crawler
family: "Undead"
rank: "F"
tier: core
tags: [monster, undead]
---
# Bone Crawler

![[mon_bone_crawler_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_bone_crawler_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 12,000 tris · 1.528 × 1.726 × 1.399 m · local file `Game/Assets/_Game/Art/Models/Monsters/Undead/mon_bone_crawler.fbx`

> The Bone Crawler is a person-sized creature with an asymmetric body with too many limbs, about 1.4 m tall. Its flesh and bone are patchy and subtly wrong, as if assembled from memory, colored in bleached bone and grave-cloth, with violet markings. Look for a skeleton reassembled wrong, crawling on its hands. It has eyes that never blink. It has no ornament at all: simple, readable shapes. It freezes whenever it is looked at, surrounded by shadows that lean toward it.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Rank · level | F · 8 (3–13) |
| Menace | 4 · Dread |
| Element · weakness | Dark · Light |
| Size | 1.4 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 295 · 53 · 38 · 38 · 38 · 100 |
| XP · gold | 92 · 31 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/amorphous\|amorphous]] · `anim_aberrant` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Gothic Horror |
| Trope | Graveyard night threats; the lich and its phylactery; the vampire noble |

**Field note:** Weak to Light. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/amorphous|amorphous]] (rigId); animation set `anim_aberrant`.
- **Dimensions:** 1.4 m high × 1.5 m long × 1.47 m wide; prefab scale 0.7.
- **Physics:** 82.3 kg, gravity ×1.2, poise 36, knockback resistance 0.6, death style `collapse_and_melt`.
- **Navigation:** speed 6.05 m/s, turn 423°/s, stopping distance 0.82 m.
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

Bone Crawler is a **dread undead** encountered at F rank, around level 8. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a skeleton reassembled wrong, crawling on its hands. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Whisperwood|Whisperwood]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_aberrant`, animation set `anim_aberrant`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Undead F|loot_undead_f]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Bone Dust\|Bone Dust]] | 60% | 1–3 |
| [[Items/Grave Cloth\|Grave Cloth]] | 30% | 1–1 |
| [[Items/Soul Ember\|Soul Ember]] | 15% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Undead/Vesper-Touched Bone Crawler|Vesper-Touched Bone Crawler]]
- [[Monsters/Undead/Elder Bone Crawler|Elder Bone Crawler]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 4 | F+, E, F, F- | 3–26 | Night |
| [[Regions/Whisperwood\|Whisperwood]] | 4 | F+, E, E-, F- | 3–26 | Night |
| [[Regions/Aldmere\|Aldmere]] | 3 | E-, F- | 3–19 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00840` | Great Labyrinth (Floors 1-40) Bone Crawler Albino | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Albino | F+ | 13 | 1.4 m | Night | Like a typical Bone Crawler, but a rare pale form with white skin or fur and red eyes. |
| `pop_00841` | Great Labyrinth (Floors 1-40) Bone Crawler Elderborn | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Elderborn | E | 26 | 1.89 m | Night | Like a typical Bone Crawler, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_00842` | Whisperwood Bone Crawler Albino | [[Regions/Whisperwood\|Whisperwood]] | Albino | F+ | 13 | 1.4 m | Night | Like a typical Bone Crawler, but a rare pale form with white skin or fur and red eyes. |
| `pop_00843` | Great Labyrinth (Floors 1-40) Bone Crawler | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Adult | F | 8 | 1.4 m | Night | A typical adult Bone Crawler of this region, with dust-grey coloring and old rune scars. |
| `pop_00844` | Aldmere Bone Crawler Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | E- | 19 | 1.75 m | Night | Like a typical Bone Crawler, but larger and scarred, and others of its kind follow it, with mud-slick, algae-streaked skin. |
| `pop_00845` | Aldmere Bone Crawler Runt | [[Regions/Aldmere\|Aldmere]] | Runt | F- | 3 | 0.98 m | Night | Like a typical Bone Crawler, but smaller and scrappier than usual, with mud-slick, algae-streaked skin. |
| `pop_00846` | Whisperwood Bone Crawler Elderborn | [[Regions/Whisperwood\|Whisperwood]] | Elderborn | E | 26 | 1.89 m | Night | Like a typical Bone Crawler, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_00847` | Aldmere Bone Crawler Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | F- | 3 | 1.19 m | Night | Like a typical Bone Crawler, but young, with brighter colors and unworn features, with mud-slick, algae-streaked skin. |
| `pop_00848` | Whisperwood Bone Crawler Alpha | [[Regions/Whisperwood\|Whisperwood]] | Alpha | E- | 19 | 1.75 m | Night | Like a typical Bone Crawler, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_00849` | Great Labyrinth (Floors 1-40) Bone Crawler Juvenile | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Juvenile | F- | 3 | 1.19 m | Night | Like a typical Bone Crawler, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_00850` | Whisperwood Bone Crawler Runt | [[Regions/Whisperwood\|Whisperwood]] | Runt | F- | 3 | 0.98 m | Night | Like a typical Bone Crawler, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |

## Design recipe

Rig `rig_aberrant` · mesh `aberrant_base` · material `rot_bone` · VFX `shadow_wisps` · palette `#dad6b2` `#8b8769` `#9a86d8` · elongated, irregular silhouette; still-then-sudden timing
