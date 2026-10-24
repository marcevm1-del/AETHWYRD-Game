---
type: monster
id: mon_vampire
family: "Undead"
rank: "B+"
tier: core
tags: [monster, undead]
---
# Vampire

![[mon_vampire_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_vampire_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Vampire is a person-sized creature with a lean humanoid frame, about 1.8 m tall. Its flesh and bone are rough, scarred and spiked, colored in arterial crimson and dried-blood brown. Guild sketches always show aristocratic clothes and eyes like garnets. It has narrow glowing eyes. Faint runes glow along its body when it fights. It circles its prey, surrounded by a faint red mist that smells of iron.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Rank · level | B+ · 120 (108–132) |
| Menace | 3 · Menacing |
| Element · weakness | Blood · Light |
| Size | 1.8 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 15937 · 588 · 490 · 392 · 441 · 100 |
| XP · gold | 6373 · 1225 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Sunscar\|Sunscar]], [[Regions/Strife Marches\|Strife Marches]], [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/Aurumdeep\|Aurumdeep]], [[Regions/Lumbaya\|Lumbaya]] |
| Genre | Gothic Horror |
| Trope | Graveyard night threats; the lich and its phylactery; the vampire noble |

**Field note:** Weak to Light. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 1.8 m high × 0.54 m long × 0.58 m wide; prefab scale 1.
- **Physics:** 83.4 kg, gravity ×1.5, poise 80, knockback resistance 0.42, death style `ragdoll`.
- **Navigation:** speed 5.43 m/s, turn 298°/s, stopping distance 0.71 m.
- **Attack count:** 5; **signature:** aristocratic clothes and eyes like garnets.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Grave Grasp\|Grave Grasp]] | grab | 1.2 | 10 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Blood Lance\|Blood Lance]] | magic | 1.5 | 10 s | Blood | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Vampire is a **menacing undead** encountered at B+ rank, around level 120. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** aristocratic clothes and eyes like garnets. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Sunscar|Sunscar]], [[Regions/Strife Marches|Strife Marches]], [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]], [[Regions/Aurumdeep|Aurumdeep]], [[Regions/Lumbaya|Lumbaya]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Undead B|loot_undead_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Bone Dust\|Bone Dust]] | 60% | 1–3 |
| [[Items/Grave Cloth\|Grave Cloth]] | 30% | 1–1 |
| [[Items/Soul Ember\|Soul Ember]] | 15% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Undead/Elder Vampire|Elder Vampire]]
- [[Monsters/Undead/Rot Vampire|Rot Vampire]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Sunscar\|Sunscar]] | 2 | B-, B | 96–108 | Night |
| [[Regions/Lumbaya\|Lumbaya]] | 2 | B+, B | 108–120 | Night |
| [[Regions/Aurumdeep\|Aurumdeep]] | 3 | A+, A-, B- | 96–159 | Night |
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 3 | A, B, A- | 108–146 | Night |
| [[Regions/Strife Marches\|Strife Marches]] | 1 | B | 108–108 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00928` | Sunscar Vampire Runt | [[Regions/Sunscar\|Sunscar]] | Runt | B- | 96 | 1.26 m | Night | Like a typical Vampire, but smaller and scrappier than usual, with sun-bleached, sand-scoured coloring. |
| `pop_00929` | Lumbaya Vampire | [[Regions/Lumbaya\|Lumbaya]] | Adult | B+ | 120 | 1.8 m | Night | A typical adult Vampire of this region, with dust-grey coloring and old rune scars. |
| `pop_00930` | Aurumdeep Vampire Elderborn | [[Regions/Aurumdeep\|Aurumdeep]] | Elderborn | A+ | 159 | 2.43 m | Night | Like a typical Vampire, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_00931` | Lumbaya Vampire Juvenile | [[Regions/Lumbaya\|Lumbaya]] | Juvenile | B | 108 | 1.53 m | Night | Like a typical Vampire, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_00932` | Aurumdeep Vampire Scarred | [[Regions/Aurumdeep\|Aurumdeep]] | Scarred | A- | 132 | 1.98 m | Night | Like a typical Vampire, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_00933` | Great Labyrinth (Floors 41-90) Vampire Alpha | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Alpha | A | 146 | 2.25 m | Night | Like a typical Vampire, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_00934` | Strife Marches Vampire Juvenile | [[Regions/Strife Marches\|Strife Marches]] | Juvenile | B | 108 | 1.53 m | Night | Like a typical Vampire, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_00935` | Great Labyrinth (Floors 41-90) Vampire Juvenile | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Juvenile | B | 108 | 1.53 m | Night | Like a typical Vampire, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_00936` | Great Labyrinth (Floors 41-90) Vampire Scarred | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Scarred | A- | 132 | 1.98 m | Night | Like a typical Vampire, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_00937` | Aurumdeep Vampire Runt | [[Regions/Aurumdeep\|Aurumdeep]] | Runt | B- | 96 | 1.26 m | Night | Like a typical Vampire, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_00938` | Sunscar Vampire Juvenile | [[Regions/Sunscar\|Sunscar]] | Juvenile | B | 108 | 1.53 m | Night | Like a typical Vampire, but young, with brighter colors and unworn features, with sun-bleached, sand-scoured coloring. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `rot_bone` · VFX `blood_mist` · palette `#8b0000` `#d7263d` `#1a0505` · triangle-based silhouette, sharp asymmetric spikes
