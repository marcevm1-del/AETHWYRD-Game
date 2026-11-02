---
type: monster
id: mon_elder_bone_crawler
family: "Undead"
rank: "E"
tier: variant
tags: [monster, undead]
---
# Elder Bone Crawler

![[mon_elder_bone_crawler_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_elder_bone_crawler_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,464 tris · 1.532 × 1.644 × 2.2 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Elder Bone Crawler is a person-sized creature with a shape that keeps rearranging itself, about 2.2 m tall. Its flesh and bone are patchy and subtly wrong, as if assembled from memory, colored in bleached bone and grave-cloth, with violet markings. Survivors describe a skeleton reassembled wrong, crawling on its hands. It has eyes set slightly too far apart. Small scars and rough edges mark it as a survivor. It moves in jerky stop-motion bursts, surrounded by shadows that lean toward it. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Variant of | [[Monsters/Undead/Bone Crawler\|Bone Crawler]] (elder) |
| Rank · level | E · 26 (19–32) |
| Menace | 4 · Dread |
| Element · weakness | Dark · Light |
| Size | 2.2 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1636 · 143 · 103 · 103 · 103 · 100 |
| XP · gold | 559 · 147 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/amorphous\|amorphous]] · `anim_aberrant` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Gothic Horror |
| Trope | Graveyard night threats; the lich and its phylactery; the vampire noble |

**Field note:** Weak to Light. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/amorphous|amorphous]] (rigId); animation set `anim_aberrant`.
- **Dimensions:** 2.2 m high × 2.36 m long × 2.31 m wide; prefab scale 1.1.
- **Physics:** 319.4 kg, gravity ×1.2, poise 83, knockback resistance 0.63, death style `collapse_and_melt`.
- **Navigation:** speed 7.59 m/s, turn 337°/s, stopping distance 1.06 m.
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

Elder Bone Crawler is a **dread undead** encountered at E rank, around level 26. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a skeleton reassembled wrong, crawling on its hands. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Whisperwood|Whisperwood]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

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
| [[Regions/Aldmere\|Aldmere]] | 5 | E-, D, E, E+, D- | 19–48 | Night |
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 3 | F+, E-, D | 13–48 | Night |
| [[Regions/Whisperwood\|Whisperwood]] | 3 | E, E-, F+ | 13–26 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06583` | Aldmere Elder Bone Crawler Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | E- | 19 | 1.87 m | Night | Like a typical Elder Bone Crawler, but young, with brighter colors and unworn features, with mud-slick, algae-streaked skin. |
| `pop_06584` | Aldmere Elder Bone Crawler Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | D | 48 | 2.97 m | Night | Like a typical Elder Bone Crawler, but old and wise, with greying features and a cautious hunting style, with mud-slick, algae-streaked skin. |
| `pop_06585` | Aldmere Elder Bone Crawler | [[Regions/Aldmere\|Aldmere]] | Adult | E | 26 | 2.2 m | Night | A typical adult Elder Bone Crawler of this region, with mud-slick, algae-streaked skin. |
| `pop_06586` | Great Labyrinth (Floors 1-40) Elder Bone Crawler Runt | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Runt | F+ | 13 | 1.54 m | Night | Like a typical Elder Bone Crawler, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_06587` | Whisperwood Elder Bone Crawler | [[Regions/Whisperwood\|Whisperwood]] | Adult | E | 26 | 2.2 m | Night | A typical adult Elder Bone Crawler of this region, with dust-grey coloring and old rune scars. |
| `pop_06588` | Great Labyrinth (Floors 1-40) Elder Bone Crawler Juvenile | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Juvenile | E- | 19 | 1.87 m | Night | Like a typical Elder Bone Crawler, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_06589` | Aldmere Elder Bone Crawler Albino | [[Regions/Aldmere\|Aldmere]] | Albino | E+ | 32 | 2.2 m | Night | Like a typical Elder Bone Crawler, but a rare pale form with white skin or fur and red eyes. |
| `pop_06590` | Whisperwood Elder Bone Crawler Juvenile | [[Regions/Whisperwood\|Whisperwood]] | Juvenile | E- | 19 | 1.87 m | Night | Like a typical Elder Bone Crawler, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_06591` | Great Labyrinth (Floors 1-40) Elder Bone Crawler Elderborn | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Elderborn | D | 48 | 2.97 m | Night | Like a typical Elder Bone Crawler, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_06592` | Whisperwood Elder Bone Crawler Runt | [[Regions/Whisperwood\|Whisperwood]] | Runt | F+ | 13 | 1.54 m | Night | Like a typical Elder Bone Crawler, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_06593` | Aldmere Elder Bone Crawler Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | D- | 40 | 2.75 m | Night | Like a typical Elder Bone Crawler, but larger and scarred, and others of its kind follow it, with mud-slick, algae-streaked skin. |

## Design recipe

Rig `rig_aberrant` · mesh `aberrant_base` · material `rot_bone` · VFX `shadow_wisps` · palette `#c7bfa2` `#7f7860` `#9a86d8` · elongated, irregular silhouette; still-then-sudden timing
