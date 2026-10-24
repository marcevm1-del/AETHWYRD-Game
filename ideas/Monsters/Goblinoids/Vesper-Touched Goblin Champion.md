---
type: monster
id: mon_vesper_touched_goblin_champion
family: "Goblinoids"
rank: "C"
tier: variant
tags: [monster, goblinoids]
---
# Vesper-Touched Goblin Champion

![[mon_vesper_touched_goblin_champion_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_vesper_touched_goblin_champion_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (3,100 tris · 0.835 × 1.18 × 2 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Vesper-Touched Goblin Champion is a person-sized creature with a lean humanoid frame, about 2 m tall. Its skin is patchy and subtly wrong, as if assembled from memory, colored in arterial crimson and dried-blood brown. Look for a trophy cloak stitched from adventurers' capes. It has pale, pupil-less eyes. Battle-worn plates and trophies hang from its body. It freezes whenever it is looked at, surrounded by a faint red mist that smells of iron. Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.

| Field | Value |
|---|---|
| Family · type | [[Families/Goblinoids|Goblinoids]] · Humanoid |
| Variant of | [[Monsters/Goblinoids/Goblin Champion\|Goblin Champion]] (corrupted) |
| Rank · level | C · 76 (65–86) |
| Menace | 4 · Dread |
| Element · weakness | Blood · Light |
| Size | 2 m |
| Behaviour | Aggressive (aggressive_chase+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 8369 · 377 · 314 · 251 · 283 · 100 |
| XP · gold | 3073 · 648 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Strife Marches\|Strife Marches]], [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] |
| Genre | Dark Fantasy |
| Trope | Goblins as horror in numbers (Goblin Slayer); hobgoblin → champion → king evolution |

**Field note:** Weak to Light. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 2 m high × 0.6 m long × 0.64 m wide; prefab scale 1.111.
- **Physics:** 114.4 kg, gravity ×1.5, poise 76, knockback resistance 0.39, death style `ragdoll`.
- **Navigation:** speed 5.45 m/s, turn 283°/s, stopping distance 0.74 m.
- **Attack count:** 5; **signature:** a trophy cloak stitched from adventurers' capes.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Sand Toss\|Sand Toss]] | debuff | 0 | 12 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Blood Lance\|Blood Lance]] | magic | 1.5 | 10 s | Blood | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Vesper-Touched Goblin Champion is a **dread humanoid** encountered at C rank, around level 76. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a trophy cloak stitched from adventurers' capes. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Strife Marches|Strife Marches]], [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Goblinoids C|loot_goblinoid_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Goblin Ear\|Goblin Ear]] | 60% | 1–3 |
| [[Items/Crude Blade\|Crude Blade]] | 30% | 1–1 |
| [[Items/Stolen Trinket\|Stolen Trinket]] | 15% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Aldmere\|Aldmere]] | 5 | B, D+, C, C+ | 56–108 | Night |
| [[Regions/Strife Marches\|Strife Marches]] | 3 | C+, B-, C | 76–96 | Night |
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 3 | B, B-, C+ | 86–108 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03137` | Aldmere Vesper-Touched Goblin Champion Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | B | 108 | 2.7 m | Night | Like a typical Vesper-Touched Goblin Champion, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_03138` | Aldmere Vesper-Touched Goblin Champion Runt | [[Regions/Aldmere\|Aldmere]] | Runt | D+ | 56 | 1.4 m | Night | Like a typical Vesper-Touched Goblin Champion, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_03139` | Aldmere Vesper-Touched Goblin Champion | [[Regions/Aldmere\|Aldmere]] | Adult | C | 76 | 2 m | Night | A typical adult Vesper-Touched Goblin Champion of this region, with golden, grass-toned coloring. |
| `pop_03140` | Aldmere Vesper-Touched Goblin Champion Albino | [[Regions/Aldmere\|Aldmere]] | Albino | C+ | 86 | 2 m | Night | Like a typical Vesper-Touched Goblin Champion, but a rare pale form with white skin or fur and red eyes. |
| `pop_03141` | Strife Marches Vesper-Touched Goblin Champion Scarred | [[Regions/Strife Marches\|Strife Marches]] | Scarred | C+ | 86 | 2.2 m | Night | Like a typical Vesper-Touched Goblin Champion, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_03142` | Great Labyrinth (Floors 41-90) Vesper-Touched Goblin Champion Elderborn | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Elderborn | B | 108 | 2.7 m | Night | Like a typical Vesper-Touched Goblin Champion, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_03143` | Aldmere Vesper-Touched Goblin Champion Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | C+ | 86 | 2.2 m | Night | Like a typical Vesper-Touched Goblin Champion, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_03144` | Strife Marches Vesper-Touched Goblin Champion Alpha | [[Regions/Strife Marches\|Strife Marches]] | Alpha | B- | 96 | 2.5 m | Night | Like a typical Vesper-Touched Goblin Champion, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_03145` | Great Labyrinth (Floors 41-90) Vesper-Touched Goblin Champion Alpha | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Alpha | B- | 96 | 2.5 m | Night | Like a typical Vesper-Touched Goblin Champion, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_03146` | Great Labyrinth (Floors 41-90) Vesper-Touched Goblin Champion Albino | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Albino | C+ | 86 | 2 m | Night | Like a typical Vesper-Touched Goblin Champion, but a rare pale form with white skin or fur and red eyes. |
| `pop_03147` | Strife Marches Vesper-Touched Goblin Champion | [[Regions/Strife Marches\|Strife Marches]] | Adult | C | 76 | 2 m | Night | A typical adult Vesper-Touched Goblin Champion of this region, with golden, grass-toned coloring. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `rough_skin_leather` · VFX `blood_mist` · palette `#8b0000` `#d7263d` `#1a0505` · elongated, irregular silhouette; still-then-sudden timing
