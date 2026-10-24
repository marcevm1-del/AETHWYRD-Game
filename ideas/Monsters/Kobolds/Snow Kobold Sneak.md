---
type: monster
id: mon_snow_kobold_sneak
family: "Kobolds"
rank: "E+"
tier: variant
tags: [monster, kobolds]
---
# Snow Kobold Sneak

![[mon_snow_kobold_sneak_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_snow_kobold_sneak_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,702 tris · 0.403 × 0.473 × 0.8 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Snow Kobold Sneak is a small creature with a hunched, wiry humanoid frame, about 0.8 m tall. Its mangy fur is rough, scarred and spiked, colored in pale blues and frost-white. Guild sketches always show soot-blackened fur for hiding in tunnels. It has narrow glowing eyes. Small scars and rough edges mark it as a survivor. It circles its prey, surrounded by falling snow motes and frosted ground where it steps. This Ice-attuned variant carries one extra elemental feature, like element-scarred hide, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Kobolds|Kobolds]] · Humanoid |
| Variant of | [[Monsters/Kobolds/Kobold Sneak\|Kobold Sneak]] (elemental) |
| Rank · level | E+ · 32 (26–40) |
| Menace | 3 · Menacing |
| Element · weakness | Ice · Fire |
| Size | 0.8 m |
| Behaviour | Pack (pack_flank) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1338 · 138 · 110 · 97 · 110 · 135 |
| XP · gold | 776 · 195 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/small_biped\|small_biped]] · `anim_small_biped` |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Dungeon Crawl |
| Trope | Dog-headed first-floor monsters (DanMachi), trap-builders (classic tabletop) |

**Field note:** Weak to Fire. Never alone. Kill the leader first and the rest may scatter.

## Motion implementation

- **Rig:** [[Systems/Rigs/small_biped|small_biped]] (rigId); animation set `anim_small_biped`.
- **Dimensions:** 0.8 m high × 0.24 m long × 0.32 m wide; prefab scale 0.727.
- **Physics:** 9 kg, gravity ×1.58, poise 29, knockback resistance 0.18, death style `ragdoll_crumple`.
- **Navigation:** speed 4.18 m/s, turn 470°/s, stopping distance 0.56 m.
- **Attack count:** 5; **signature:** soot-blackened fur for hiding in tunnels.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stab\|Stab]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Thrown Junk\|Thrown Junk]] | ranged | 0.8 | 4 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Frenzied Lunge\|Frenzied Lunge]] | melee | 1.5 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Trip-Wire Trap\|Trip-Wire Trap]] | debuff | 0 | 14 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Frost Breath\|Frost Breath]] | magic | 1.5 | 10 s | Ice | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Snow Kobold Sneak is a **menacing humanoid** encountered at E+ rank, around level 32. Its documented behaviour is *Pack* and its AI pattern is *pack_flank*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** soot-blackened fur for hiding in tunnels. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Whisperwood|Whisperwood]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_small_biped`, animation set `anim_small_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Kobolds E|loot_kobold_e]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Kobold Fang\|Kobold Fang]] | 60% | 1–3 |
| [[Items/Scrap Metal\|Scrap Metal]] | 30% | 1–1 |
| [[Items/Candle Stub\|Candle Stub]] | 15% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 6 | D-, D+, D, E, E- | 19–56 | Day & Night |
| [[Regions/Whisperwood\|Whisperwood]] | 5 | E+, E, D-, D | 26–48 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03214` | Great Labyrinth (Floors 1-40) Snow Kobold Sneak Scarred | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Scarred | D- | 40 | 0.88 m | Day & Night | Like a typical Snow Kobold Sneak, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_03215` | Great Labyrinth (Floors 1-40) Snow Kobold Sneak Elderborn | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Elderborn | D+ | 56 | 1.08 m | Day & Night | Like a typical Snow Kobold Sneak, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_03216` | Whisperwood Snow Kobold Sneak | [[Regions/Whisperwood\|Whisperwood]] | Adult | E+ | 32 | 0.8 m | Day & Night | A typical adult Snow Kobold Sneak of this region, with dust-grey coloring and old rune scars. |
| `pop_03217` | Whisperwood Snow Kobold Sneak Juvenile | [[Regions/Whisperwood\|Whisperwood]] | Juvenile | E | 26 | 0.68 m | Day & Night | Like a typical Snow Kobold Sneak, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_03218` | Whisperwood Snow Kobold Sneak Scarred | [[Regions/Whisperwood\|Whisperwood]] | Scarred | D- | 40 | 0.88 m | Day & Night | Like a typical Snow Kobold Sneak, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_03219` | Great Labyrinth (Floors 1-40) Snow Kobold Sneak Alpha | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Alpha | D | 48 | 1 m | Day & Night | Like a typical Snow Kobold Sneak, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_03220` | Great Labyrinth (Floors 1-40) Snow Kobold Sneak Juvenile | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Juvenile | E | 26 | 0.68 m | Day & Night | Like a typical Snow Kobold Sneak, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_03221` | Whisperwood Snow Kobold Sneak Alpha | [[Regions/Whisperwood\|Whisperwood]] | Alpha | D | 48 | 1 m | Day & Night | Like a typical Snow Kobold Sneak, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_03222` | Great Labyrinth (Floors 1-40) Snow Kobold Sneak Runt | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Runt | E- | 19 | 0.56 m | Day & Night | Like a typical Snow Kobold Sneak, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_03223` | Great Labyrinth (Floors 1-40) Snow Kobold Sneak Albino | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Albino | D- | 40 | 0.8 m | Day & Night | Like a typical Snow Kobold Sneak, but a rare pale form with white skin or fur and red eyes. |
| `pop_03224` | Whisperwood Snow Kobold Sneak Albino | [[Regions/Whisperwood\|Whisperwood]] | Albino | D- | 40 | 0.8 m | Day & Night | Like a typical Snow Kobold Sneak, but a rare pale form with white skin or fur and red eyes. |

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `fur_short` · VFX `frost_trail_snow` · palette `#bfe9ff` `#5fa8d3` `#f4fbff` · triangle-based silhouette, sharp asymmetric spikes
