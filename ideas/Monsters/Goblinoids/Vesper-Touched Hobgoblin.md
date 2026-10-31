---
type: monster
id: mon_vesper_touched_hobgoblin
family: "Goblinoids"
rank: "D"
tier: variant
tags: [monster, goblinoids]
---
# Vesper-Touched Hobgoblin

![[mon_vesper_touched_hobgoblin_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_vesper_touched_hobgoblin_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (3,036 tris · 0.751 × 0.833 × 1.8 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Vesper-Touched Hobgoblin is a person-sized creature with a broad-shouldered humanoid build, about 1.8 m tall. Its skin is patchy and subtly wrong, as if assembled from memory, colored in grey-green and patched leather, with crimson markings. Survivors describe a broad scarred chest and a helmet two sizes too small. It has eyes set slightly too far apart. A distinctive marking runs along its back. It glides without moving its legs, surrounded by a faint red mist that smells of iron. Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.

| Field | Value |
|---|---|
| Family · type | [[Families/Goblinoids|Goblinoids]] · Humanoid |
| Variant of | [[Monsters/Goblinoids/Hobgoblin\|Hobgoblin]] (corrupted) |
| Rank · level | D · 48 (40–56) |
| Menace | 4 · Dread |
| Element · weakness | Blood · Light |
| Size | 1.8 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 4092 · 242 · 202 · 162 · 182 · 100 |
| XP · gold | 1477 · 342 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Strife Marches\|Strife Marches]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] |
| Genre | Dark Fantasy |
| Trope | Goblins as horror in numbers (Goblin Slayer); hobgoblin → champion → king evolution |

**Field note:** Weak to Light. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (override (base species)); animation set `anim_medium_biped`.
- **Dimensions:** 1.8 m high × 0.54 m long × 0.58 m wide; prefab scale 1.
- **Physics:** 83.4 kg, gravity ×1.5, poise 65, knockback resistance 0.36, death style `ragdoll`.
- **Navigation:** speed 5.17 m/s, turn 298°/s, stopping distance 0.71 m.
- **Attack count:** 5; **signature:** a broad scarred chest and a helmet two sizes too small.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Sand Toss\|Sand Toss]] | debuff | 0 | 12 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Blood Lance\|Blood Lance]] | magic | 1.5 | 10 s | Blood | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Vesper-Touched Hobgoblin is a **dread humanoid** encountered at D rank, around level 48. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a broad scarred chest and a helmet two sizes too small. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Strife Marches|Strife Marches]], [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Goblinoids D|loot_goblinoid_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Goblin Ear\|Goblin Ear]] | 60% | 1–3 |
| [[Items/Crude Blade\|Crude Blade]] | 30% | 1–1 |
| [[Items/Stolen Trinket\|Stolen Trinket]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 3 | E+, D, D- | 32–48 | Night |
| [[Regions/Strife Marches\|Strife Marches]] | 4 | D, D+, C-, D- | 40–65 | Night |
| [[Regions/Aldmere\|Aldmere]] | 4 | C, D+, C-, D | 48–76 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05945` | Great Labyrinth (Floors 1-40) Vesper-Touched Hobgoblin Runt | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Runt | E+ | 32 | 1.26 m | Night | Like a typical Vesper-Touched Hobgoblin, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_05946` | Strife Marches Vesper-Touched Hobgoblin | [[Regions/Strife Marches\|Strife Marches]] | Adult | D | 48 | 1.8 m | Night | A typical adult Vesper-Touched Hobgoblin of this region, with golden, grass-toned coloring. |
| `pop_05947` | Great Labyrinth (Floors 1-40) Vesper-Touched Hobgoblin | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Adult | D | 48 | 1.8 m | Night | A typical adult Vesper-Touched Hobgoblin of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_05948` | Aldmere Vesper-Touched Hobgoblin Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | C | 76 | 2.43 m | Night | Like a typical Vesper-Touched Hobgoblin, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_05949` | Strife Marches Vesper-Touched Hobgoblin Scarred | [[Regions/Strife Marches\|Strife Marches]] | Scarred | D+ | 56 | 1.98 m | Night | Like a typical Vesper-Touched Hobgoblin, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_05950` | Aldmere Vesper-Touched Hobgoblin Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | D+ | 56 | 1.98 m | Night | Like a typical Vesper-Touched Hobgoblin, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_05951` | Strife Marches Vesper-Touched Hobgoblin Alpha | [[Regions/Strife Marches\|Strife Marches]] | Alpha | C- | 65 | 2.25 m | Night | Like a typical Vesper-Touched Hobgoblin, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_05952` | Aldmere Vesper-Touched Hobgoblin Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | C- | 65 | 2.25 m | Night | Like a typical Vesper-Touched Hobgoblin, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_05953` | Aldmere Vesper-Touched Hobgoblin | [[Regions/Aldmere\|Aldmere]] | Adult | D | 48 | 1.8 m | Night | A typical adult Vesper-Touched Hobgoblin of this region, with golden, grass-toned coloring. |
| `pop_05954` | Strife Marches Vesper-Touched Hobgoblin Juvenile | [[Regions/Strife Marches\|Strife Marches]] | Juvenile | D- | 40 | 1.53 m | Night | Like a typical Vesper-Touched Hobgoblin, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_05955` | Great Labyrinth (Floors 1-40) Vesper-Touched Hobgoblin Juvenile | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Juvenile | D- | 40 | 1.53 m | Night | Like a typical Vesper-Touched Hobgoblin, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `rough_skin_leather` · VFX `blood_mist` · palette `#849b73` `#615036` `#e0344a` · elongated, irregular silhouette; still-then-sudden timing
