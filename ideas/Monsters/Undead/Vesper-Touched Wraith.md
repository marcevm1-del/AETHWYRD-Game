---
type: monster
id: mon_vesper_touched_wraith
family: "Undead"
rank: "C-"
tier: variant
tags: [monster, undead]
---
# Vesper-Touched Wraith

![[mon_vesper_touched_wraith_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_vesper_touched_wraith_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (1,822 tris · 1.711 × 1.914 × 2 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Vesper-Touched Wraith is a person-sized creature with a bodiless, glowing form, about 2 m tall. Its flesh and bone are stretched, stitched and constantly shifting, colored in grave-mould grey-green, with violet markings. Guild sketches always show a hooded shape of smoke with cold blue eyes. It has too many eyes, opening one after another. Battle-worn plates and trophies hang from its body. It crawls across ceilings, surrounded by shadows that lean toward it. Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Variant of | [[Monsters/Undead/Wraith\|Wraith]] (corrupted) |
| Rank · level | C- · 65 (56–76) |
| Menace | 5 · Horror |
| Element · weakness | Dark · Light |
| Size | 2 m |
| Behaviour | Aggressive (aggressive_chase+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 4827 · 162 · 189 · 378 · 351 · 90 |
| XP · gold | 2395 · 521 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/spirit_float\|spirit_float]] · `anim_floating` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Sunscar\|Sunscar]], [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] |
| Genre | Gothic Horror |
| Trope | Graveyard night threats; the lich and its phylactery; the vampire noble |

**Field note:** Weak to Light. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/spirit_float|spirit_float]] (rigId); animation set `anim_floating`.
- **Dimensions:** 2 m high × 0.6 m long × 1.28 m wide; prefab scale 2.
- **Physics:** 0.8 kg, gravity ×0, poise 16, knockback resistance 0.09, death style `dissolve_into_motes`.
- **Navigation:** speed 9.3 m/s, turn 509°/s, stopping distance 0.9 m.
- **Attack count:** 5; **signature:** a hooded shape of smoke with cold blue eyes.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Chill Touch\|Chill Touch]] | melee | 0.9 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Phase Lunge\|Phase Lunge]] | dash | 1.3 | 7 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Wail\|Wail]] | aoe | 1.2 | 12 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Grave Grasp\|Grave Grasp]] | grab | 1.2 | 10 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Vesper-Touched Wraith is a **horror undead** encountered at C- rank, around level 65. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a hooded shape of smoke with cold blue eyes. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Sunscar|Sunscar]], [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_floating`, animation set `anim_floating`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Undead C|loot_undead_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Bone Dust\|Bone Dust]] | 60% | 1–3 |
| [[Items/Grave Cloth\|Grave Cloth]] | 30% | 1–1 |
| [[Items/Soul Ember\|Soul Ember]] | 15% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Sunscar\|Sunscar]] | 5 | D, C, B-, C- | 48–96 | Night |
| [[Regions/Aldmere\|Aldmere]] | 4 | C+, D+, C, D | 48–86 | Night |
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 2 | D, C | 48–76 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06627` | Sunscar Vesper-Touched Wraith Runt | [[Regions/Sunscar\|Sunscar]] | Runt | D | 48 | 1.4 m | Night | Like a typical Vesper-Touched Wraith, but smaller and scrappier than usual, with sun-bleached, sand-scoured coloring. |
| `pop_06628` | Aldmere Vesper-Touched Wraith Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | C+ | 86 | 2.5 m | Night | Like a typical Vesper-Touched Wraith, but larger and scarred, and others of its kind follow it, with mud-slick, algae-streaked skin. |
| `pop_06629` | Sunscar Vesper-Touched Wraith Albino | [[Regions/Sunscar\|Sunscar]] | Albino | C | 76 | 2 m | Night | Like a typical Vesper-Touched Wraith, but a rare pale form with white skin or fur and red eyes. |
| `pop_06630` | Sunscar Vesper-Touched Wraith Elderborn | [[Regions/Sunscar\|Sunscar]] | Elderborn | B- | 96 | 2.7 m | Night | Like a typical Vesper-Touched Wraith, but old and wise, with greying features and a cautious hunting style, with sun-bleached, sand-scoured coloring. |
| `pop_06631` | Aldmere Vesper-Touched Wraith Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | D+ | 56 | 1.7 m | Night | Like a typical Vesper-Touched Wraith, but young, with brighter colors and unworn features, with mud-slick, algae-streaked skin. |
| `pop_06632` | Aldmere Vesper-Touched Wraith Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | C | 76 | 2.2 m | Night | Like a typical Vesper-Touched Wraith, but covered in old battle scars, with mud-slick, algae-streaked skin. |
| `pop_06633` | Sunscar Vesper-Touched Wraith | [[Regions/Sunscar\|Sunscar]] | Adult | C- | 65 | 2 m | Night | A typical adult Vesper-Touched Wraith of this region, with sun-bleached, sand-scoured coloring. |
| `pop_06634` | Great Labyrinth (Floors 41-90) Vesper-Touched Wraith Runt | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Runt | D | 48 | 1.4 m | Night | Like a typical Vesper-Touched Wraith, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_06635` | Aldmere Vesper-Touched Wraith Runt | [[Regions/Aldmere\|Aldmere]] | Runt | D | 48 | 1.4 m | Night | Like a typical Vesper-Touched Wraith, but smaller and scrappier than usual, with mud-slick, algae-streaked skin. |
| `pop_06636` | Sunscar Vesper-Touched Wraith Scarred | [[Regions/Sunscar\|Sunscar]] | Scarred | C | 76 | 2.2 m | Night | Like a typical Vesper-Touched Wraith, but covered in old battle scars, with sun-bleached, sand-scoured coloring. |
| `pop_06637` | Great Labyrinth (Floors 41-90) Vesper-Touched Wraith Albino | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Albino | C | 76 | 2 m | Night | Like a typical Vesper-Touched Wraith, but a rare pale form with white skin or fur and red eyes. |

## Design recipe

Rig `rig_floating` · mesh `floating_base` · material `rot_bone` · VFX `shadow_wisps` · palette `#8c9878` `#5b654f` `#9a86d8` · broken symmetry, mimicry, audio-first reveal
