---
type: monster
id: mon_hollow_mourner
family: "Undead"
rank: "F"
tier: core
tags: [monster, undead]
---
# Hollow Mourner

![[mon_hollow_mourner_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_hollow_mourner_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,180 tris · 0.653 × 0.913 × 1.7 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Hollow Mourner is a person-sized creature with a lean humanoid frame, about 1.7 m tall. Its flesh and bone are patchy and subtly wrong, as if assembled from memory, colored in grave-mould grey-green, with violet markings. Guild sketches always show a weeping figure that moves only when you look away. It has pale, pupil-less eyes. It has no ornament at all: simple, readable shapes. It glides without moving its legs, surrounded by shadows that lean toward it.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Rank · level | F · 8 (3–13) |
| Menace | 4 · Dread |
| Element · weakness | Dark · Light |
| Size | 1.7 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 347 · 50 · 42 · 34 · 38 · 100 |
| XP · gold | 92 · 31 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Gothic Horror |
| Trope | Graveyard night threats; the lich and its phylactery; the vampire noble |

**Field note:** Weak to Light. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 1.7 m high × 0.51 m long × 0.54 m wide; prefab scale 0.944.
- **Physics:** 63.9 kg, gravity ×1.5, poise 49, knockback resistance 0.3, death style `ragdoll`.
- **Navigation:** speed 5.27 m/s, turn 307°/s, stopping distance 0.69 m.
- **Attack count:** 5; **signature:** a weeping figure that moves only when you look away.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Grave Grasp\|Grave Grasp]] | grab | 1.2 | 10 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Hollow Mourner is a **dread undead** encountered at F rank, around level 8. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a weeping figure that moves only when you look away. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Whisperwood|Whisperwood]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Undead F|loot_undead_f]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Bone Dust\|Bone Dust]] | 60% | 1–3 |
| [[Items/Grave Cloth\|Grave Cloth]] | 30% | 1–1 |
| [[Items/Soul Ember\|Soul Ember]] | 15% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Undead/Greater Hollow Mourner|Greater Hollow Mourner]]
- [[Monsters/Undead/Vesper-Touched Hollow Mourner|Vesper-Touched Hollow Mourner]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Aldmere\|Aldmere]] | 3 | E-, F- | 3–19 | Night |
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 6 | F-, E-, F, F+, E | 3–26 | Night |
| [[Regions/Whisperwood\|Whisperwood]] | 2 | E, F+ | 13–26 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00829` | Aldmere Hollow Mourner Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | E- | 19 | 2.13 m | Night | Like a typical Hollow Mourner, but larger and scarred, and others of its kind follow it, with mud-slick, algae-streaked skin. |
| `pop_00830` | Great Labyrinth (Floors 1-40) Hollow Mourner Juvenile | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Juvenile | F- | 3 | 1.44 m | Night | Like a typical Hollow Mourner, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_00831` | Great Labyrinth (Floors 1-40) Hollow Mourner Alpha | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Alpha | E- | 19 | 2.13 m | Night | Like a typical Hollow Mourner, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_00832` | Great Labyrinth (Floors 1-40) Hollow Mourner | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Adult | F | 8 | 1.7 m | Night | A typical adult Hollow Mourner of this region, with dust-grey coloring and old rune scars. |
| `pop_00833` | Aldmere Hollow Mourner Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | F- | 3 | 1.44 m | Night | Like a typical Hollow Mourner, but young, with brighter colors and unworn features, with mud-slick, algae-streaked skin. |
| `pop_00834` | Whisperwood Hollow Mourner Elderborn | [[Regions/Whisperwood\|Whisperwood]] | Elderborn | E | 26 | 2.29 m | Night | Like a typical Hollow Mourner, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_00835` | Aldmere Hollow Mourner Runt | [[Regions/Aldmere\|Aldmere]] | Runt | F- | 3 | 1.19 m | Night | Like a typical Hollow Mourner, but smaller and scrappier than usual, with mud-slick, algae-streaked skin. |
| `pop_00836` | Great Labyrinth (Floors 1-40) Hollow Mourner Scarred | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Scarred | F+ | 13 | 1.87 m | Night | Like a typical Hollow Mourner, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_00837` | Whisperwood Hollow Mourner Scarred | [[Regions/Whisperwood\|Whisperwood]] | Scarred | F+ | 13 | 1.87 m | Night | Like a typical Hollow Mourner, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_00838` | Great Labyrinth (Floors 1-40) Hollow Mourner Elderborn | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Elderborn | E | 26 | 2.29 m | Night | Like a typical Hollow Mourner, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_00839` | Great Labyrinth (Floors 1-40) Hollow Mourner Runt | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Runt | F- | 3 | 1.19 m | Night | Like a typical Hollow Mourner, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `rot_bone` · VFX `shadow_wisps` · palette `#849576` `#56634e` `#9a86d8` · elongated, irregular silhouette; still-then-sudden timing
