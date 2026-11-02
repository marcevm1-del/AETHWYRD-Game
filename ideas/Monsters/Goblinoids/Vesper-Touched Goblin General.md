---
type: monster
id: mon_vesper_touched_goblin_general
family: "Goblinoids"
rank: "B-"
tier: variant
tags: [monster, goblinoids]
---
# Vesper-Touched Goblin General

![[mon_vesper_touched_goblin_general_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_vesper_touched_goblin_general_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,524 tris · 0.918 × 1.689 × 2.2 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Vesper-Touched Goblin General is a person-sized creature with an upright humanoid build, about 2.2 m tall. Its skin is patchy and subtly wrong, as if assembled from memory, colored in grey-green and patched leather, with crimson markings. Its most striking feature is a war banner and a horn carved from an ogre's tusk. It has pale, pupil-less eyes. Faint runes glow along its body when it fights. It glides without moving its legs, surrounded by a faint red mist that smells of iron. Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.

| Field | Value |
|---|---|
| Family · type | [[Families/Goblinoids|Goblinoids]] · Humanoid |
| Variant of | [[Monsters/Goblinoids/Goblin General\|Goblin General]] (corrupted) |
| Rank · level | B- · 96 (86–108) |
| Menace | 4 · Dread |
| Element · weakness | Blood · Light |
| Size | 2.2 m |
| Behaviour | Pack (pack_flank+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 12240 · 473 · 394 · 315 · 355 · 100 |
| XP · gold | 4462 · 897 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Strife Marches\|Strife Marches]], [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/Moraveil\|Moraveil]] |
| Genre | Dark Fantasy |
| Trope | Goblins as horror in numbers (Goblin Slayer); hobgoblin → champion → king evolution |

**Field note:** Weak to Light. Never alone. Kill the leader first and the rest may scatter.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 2.2 m high × 0.66 m long × 0.7 m wide; prefab scale 1.222.
- **Physics:** 152.3 kg, gravity ×1.5, poise 88, knockback resistance 0.42, death style `ragdoll`.
- **Navigation:** speed 5.45 m/s, turn 270°/s, stopping distance 0.77 m.
- **Attack count:** 5; **signature:** a war banner and a horn carved from an ogre's tusk.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Sand Toss\|Sand Toss]] | debuff | 0 | 12 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Blood Lance\|Blood Lance]] | magic | 1.5 | 10 s | Blood | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Vesper-Touched Goblin General is a **dread humanoid** encountered at B- rank, around level 96. Its documented behaviour is *Pack* and its AI pattern is *pack_flank+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a war banner and a horn carved from an ogre's tusk. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Strife Marches|Strife Marches]], [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]], [[Regions/Moraveil|Moraveil]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Goblinoids B|loot_goblinoid_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Goblin Ear\|Goblin Ear]] | 60% | 1–3 |
| [[Items/Crude Blade\|Crude Blade]] | 30% | 1–1 |
| [[Items/Stolen Trinket\|Stolen Trinket]] | 15% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Moraveil\|Moraveil]] | 7 | A-, C+, B-, C, B, B+ | 76–132 | Night |
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 3 | A-, C+, B | 86–132 | Night |
| [[Regions/Strife Marches\|Strife Marches]] | 1 | C+ | 86–86 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03148` | Moraveil Vesper-Touched Goblin General Elderborn | [[Regions/Moraveil\|Moraveil]] | Elderborn | A- | 132 | 2.97 m | Night | Like a typical Vesper-Touched Goblin General, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_03149` | Moraveil Vesper-Touched Goblin General Juvenile | [[Regions/Moraveil\|Moraveil]] | Juvenile | C+ | 86 | 1.87 m | Night | Like a typical Vesper-Touched Goblin General, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_03150` | Great Labyrinth (Floors 41-90) Vesper-Touched Goblin General Elderborn | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Elderborn | A- | 132 | 2.97 m | Night | Like a typical Vesper-Touched Goblin General, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_03151` | Moraveil Vesper-Touched Goblin General | [[Regions/Moraveil\|Moraveil]] | Adult | B- | 96 | 2.2 m | Night | A typical adult Vesper-Touched Goblin General of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_03152` | Moraveil Vesper-Touched Goblin General Runt | [[Regions/Moraveil\|Moraveil]] | Runt | C | 76 | 1.54 m | Night | Like a typical Vesper-Touched Goblin General, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_03153` | Moraveil Vesper-Touched Goblin General Scarred | [[Regions/Moraveil\|Moraveil]] | Scarred | B | 108 | 2.42 m | Night | Like a typical Vesper-Touched Goblin General, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_03154` | Great Labyrinth (Floors 41-90) Vesper-Touched Goblin General Juvenile | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Juvenile | C+ | 86 | 1.87 m | Night | Like a typical Vesper-Touched Goblin General, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_03155` | Strife Marches Vesper-Touched Goblin General Juvenile | [[Regions/Strife Marches\|Strife Marches]] | Juvenile | C+ | 86 | 1.87 m | Night | Like a typical Vesper-Touched Goblin General, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_03156` | Moraveil Vesper-Touched Goblin General Alpha | [[Regions/Moraveil\|Moraveil]] | Alpha | B+ | 120 | 2.75 m | Night | Like a typical Vesper-Touched Goblin General, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_03157` | Moraveil Vesper-Touched Goblin General Albino | [[Regions/Moraveil\|Moraveil]] | Albino | B | 108 | 2.2 m | Night | Like a typical Vesper-Touched Goblin General, but a rare pale form with white skin or fur and red eyes. |
| `pop_03158` | Great Labyrinth (Floors 41-90) Vesper-Touched Goblin General Scarred | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Scarred | B | 108 | 2.42 m | Night | Like a typical Vesper-Touched Goblin General, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `rough_skin_leather` · VFX `blood_mist` · palette `#7b8d68` `#584531` `#e0344a` · elongated, irregular silhouette; still-then-sudden timing
