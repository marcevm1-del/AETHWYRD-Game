---
type: monster
id: mon_death_knight
family: "Undead"
rank: "B"
tier: core
tags: [monster, undead]
---
# Death Knight

![[mon_death_knight_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_death_knight_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Death Knight is a person-sized creature with a broad-shouldered humanoid build, about 2.4 m tall. Its flesh and bone are rough, scarred and spiked, colored in ink black with bruised violet. Guild sketches always show black plate, a cloak of ash and a sword of cold fire. It has narrow glowing eyes. Faint runes glow along its body when it fights. It charges without hesitation, surrounded by shadows that lean toward it.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Rank · level | B · 108 (96–120) |
| Menace | 3 · Menacing |
| Element · weakness | Dark · Light |
| Size | 2.4 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 15028 · 530 · 442 · 354 · 398 · 100 |
| XP · gold | 5386 · 1057 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Sunscar\|Sunscar]], [[Regions/Cinderhole\|Cinderhole]], [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/Lumbaya\|Lumbaya]] |
| Genre | Gothic Horror |
| Trope | Graveyard night threats; the lich and its phylactery; the vampire noble |

**Field note:** Weak to Light. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 2.4 m high × 0.72 m long × 0.77 m wide; prefab scale 1.333.
- **Physics:** 179.7 kg, gravity ×1.5, poise 92, knockback resistance 0.42, death style `ragdoll`.
- **Navigation:** speed 6.58 m/s, turn 258°/s, stopping distance 0.81 m.
- **Attack count:** 5; **signature:** black plate, a cloak of ash and a sword of cold fire.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Grave Grasp\|Grave Grasp]] | grab | 1.2 | 10 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Death Knight is a **menacing undead** encountered at B rank, around level 108. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** black plate, a cloak of ash and a sword of cold fire. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Sunscar|Sunscar]], [[Regions/Cinderhole|Cinderhole]], [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]], [[Regions/Lumbaya|Lumbaya]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

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

- [[Monsters/Undead/Bog Death Knight|Bog Death Knight]]
- [[Monsters/Undead/Phantom Death Knight|Phantom Death Knight]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Sunscar\|Sunscar]] | 4 | B+, B-, C+, A | 86–146 | Night |
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 2 | B-, A | 96–146 | Night |
| [[Regions/Lumbaya\|Lumbaya]] | 3 | A, A-, B- | 96–146 | Night |
| [[Regions/Cinderhole\|Cinderhole]] | 2 | B+ | 120–120 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00917` | Sunscar Death Knight Albino | [[Regions/Sunscar\|Sunscar]] | Albino | B+ | 120 | 2.4 m | Night | Like a typical Death Knight, but a rare pale form with white skin or fur and red eyes. |
| `pop_00918` | Great Labyrinth (Floors 41-90) Death Knight Juvenile | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Juvenile | B- | 96 | 2.04 m | Night | Like a typical Death Knight, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_00919` | Lumbaya Death Knight Elderborn | [[Regions/Lumbaya\|Lumbaya]] | Elderborn | A | 146 | 3.24 m | Night | Like a typical Death Knight, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_00920` | Sunscar Death Knight Juvenile | [[Regions/Sunscar\|Sunscar]] | Juvenile | B- | 96 | 2.04 m | Night | Like a typical Death Knight, but young, with brighter colors and unworn features, with sun-bleached, sand-scoured coloring. |
| `pop_00921` | Lumbaya Death Knight Alpha | [[Regions/Lumbaya\|Lumbaya]] | Alpha | A- | 132 | 3 m | Night | Like a typical Death Knight, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_00922` | Cinderhole Death Knight Scarred | [[Regions/Cinderhole\|Cinderhole]] | Scarred | B+ | 120 | 2.64 m | Night | Like a typical Death Knight, but covered in old battle scars, with soot-stained hide and scavenged scraps. |
| `pop_00923` | Sunscar Death Knight Runt | [[Regions/Sunscar\|Sunscar]] | Runt | C+ | 86 | 1.68 m | Night | Like a typical Death Knight, but smaller and scrappier than usual, with sun-bleached, sand-scoured coloring. |
| `pop_00924` | Sunscar Death Knight Elderborn | [[Regions/Sunscar\|Sunscar]] | Elderborn | A | 146 | 3.24 m | Night | Like a typical Death Knight, but old and wise, with greying features and a cautious hunting style, with sun-bleached, sand-scoured coloring. |
| `pop_00925` | Great Labyrinth (Floors 41-90) Death Knight Elderborn | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Elderborn | A | 146 | 3.24 m | Night | Like a typical Death Knight, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_00926` | Lumbaya Death Knight Juvenile | [[Regions/Lumbaya\|Lumbaya]] | Juvenile | B- | 96 | 2.04 m | Night | Like a typical Death Knight, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_00927` | Cinderhole Death Knight Albino | [[Regions/Cinderhole\|Cinderhole]] | Albino | B+ | 120 | 2.4 m | Night | Like a typical Death Knight, but a rare pale form with white skin or fur and red eyes. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `rot_bone` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · triangle-based silhouette, sharp asymmetric spikes
