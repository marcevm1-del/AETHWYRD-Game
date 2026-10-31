---
type: monster
id: mon_wraith
family: "Undead"
rank: "D"
tier: core
tags: [monster, undead]
---
# Wraith

![[mon_wraith_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_wraith_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (1,606 tris · 0.932 × 1.449 × 2 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Wraith is a person-sized creature with a bodiless, glowing form, about 2 m tall. Its flesh and bone are patchy and subtly wrong, as if assembled from memory, colored in grave-mould grey-green, with violet markings. Look for a hooded shape of smoke with cold blue eyes. It has eyes that never blink. A distinctive marking runs along its back. It glides without moving its legs, surrounded by shadows that lean toward it.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Rank · level | D · 48 (40–56) |
| Menace | 4 · Dread |
| Element · weakness | Dark · Light |
| Size | 2 m |
| Behaviour | Guardian (guardian_hold+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 3085 · 121 · 141 · 283 · 263 · 90 |
| XP · gold | 1477 · 342 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/spirit_float\|spirit_float]] · `anim_floating` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Strife Marches\|Strife Marches]] |
| Genre | Gothic Horror |
| Trope | Graveyard night threats; the lich and its phylactery; the vampire noble |

**Field note:** Weak to Light. Protects something nearby: a nest, a treasure, or a place.

## Motion implementation

- **Rig:** [[Systems/Rigs/spirit_float|spirit_float]] (rigId); animation set `anim_floating`.
- **Dimensions:** 2 m high × 0.6 m long × 1.28 m wide; prefab scale 2.
- **Physics:** 0.8 kg, gravity ×0, poise 15, knockback resistance 0.06, death style `dissolve_into_motes`.
- **Navigation:** speed 7.25 m/s, turn 509°/s, stopping distance 0.9 m.
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

Wraith is a **dread undead** encountered at D rank, around level 48. Its documented behaviour is *Guardian* and its AI pattern is *guardian_hold+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a hooded shape of smoke with cold blue eyes. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Strife Marches|Strife Marches]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_floating`, animation set `anim_floating`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Undead D|loot_undead_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Bone Dust\|Bone Dust]] | 60% | 1–3 |
| [[Items/Grave Cloth\|Grave Cloth]] | 30% | 1–1 |
| [[Items/Soul Ember\|Soul Ember]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Undead/Ash Wraith|Ash Wraith]]
- [[Monsters/Undead/Vesper-Touched Wraith|Vesper-Touched Wraith]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Aldmere\|Aldmere]] | 4 | D, C-, D-, E+ | 32–65 | Night |
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 4 | C, D+, C-, D | 48–76 | Night |
| [[Regions/Strife Marches\|Strife Marches]] | 3 | D, C-, D- | 40–65 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00884` | Aldmere Wraith | [[Regions/Aldmere\|Aldmere]] | Adult | D | 48 | 2 m | Night | A typical adult Wraith of this region, with mud-slick, algae-streaked skin. |
| `pop_00885` | Aldmere Wraith Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | C- | 65 | 2.5 m | Night | Like a typical Wraith, but larger and scarred, and others of its kind follow it, with mud-slick, algae-streaked skin. |
| `pop_00886` | Great Labyrinth (Floors 1-40) Wraith Elderborn | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Elderborn | C | 76 | 2.7 m | Night | Like a typical Wraith, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_00887` | Great Labyrinth (Floors 1-40) Wraith Albino | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Albino | D+ | 56 | 2 m | Night | Like a typical Wraith, but a rare pale form with white skin or fur and red eyes. |
| `pop_00888` | Great Labyrinth (Floors 1-40) Wraith Alpha | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Alpha | C- | 65 | 2.5 m | Night | Like a typical Wraith, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_00889` | Aldmere Wraith Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | D- | 40 | 1.7 m | Night | Like a typical Wraith, but young, with brighter colors and unworn features, with mud-slick, algae-streaked skin. |
| `pop_00890` | Aldmere Wraith Runt | [[Regions/Aldmere\|Aldmere]] | Runt | E+ | 32 | 1.4 m | Night | Like a typical Wraith, but smaller and scrappier than usual, with mud-slick, algae-streaked skin. |
| `pop_00891` | Strife Marches Wraith | [[Regions/Strife Marches\|Strife Marches]] | Adult | D | 48 | 2 m | Night | A typical adult Wraith of this region, with dust-grey coloring and old rune scars. |
| `pop_00892` | Strife Marches Wraith Alpha | [[Regions/Strife Marches\|Strife Marches]] | Alpha | C- | 65 | 2.5 m | Night | Like a typical Wraith, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_00893` | Strife Marches Wraith Juvenile | [[Regions/Strife Marches\|Strife Marches]] | Juvenile | D- | 40 | 1.7 m | Night | Like a typical Wraith, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_00894` | Great Labyrinth (Floors 1-40) Wraith | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Adult | D | 48 | 2 m | Night | A typical adult Wraith of this region, with dust-grey coloring and old rune scars. |

## Design recipe

Rig `rig_floating` · mesh `floating_base` · material `rot_bone` · VFX `shadow_wisps` · palette `#889878` `#59654f` `#9a86d8` · elongated, irregular silhouette; still-then-sudden timing
