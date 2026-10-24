---
type: monster
id: mon_vesper_touched_headless_rider
family: "The Headless"
rank: "B-"
tier: variant
tags: [monster, the-headless]
---
# Vesper-Touched Headless Rider

![[mon_vesper_touched_headless_rider_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_vesper_touched_headless_rider_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Vesper-Touched Headless Rider is a large creature with a tall, headless knightly build, about 2.6 m tall. Its armor is stretched, stitched and constantly shifting, colored in ink black with bruised violet. Survivors describe a lantern burning where its head should be. It has no eyes at all, only a wide and patient mouth. Faint runes glow along its body when it fights. It crawls across ceilings, surrounded by shadows that lean toward it. Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.

| Field | Value |
|---|---|
| Family · type | [[Families/The Headless|The Headless]] · Undead |
| Variant of | [[Monsters/The Headless/Headless Rider\|Headless Rider]] (corrupted) |
| Rank · level | B- · 96 (86–108) |
| Menace | 5 · Horror |
| Element · weakness | Dark · Light |
| Size | 2.6 m |
| Behaviour | Guardian (guardian_hold+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 16490 · 394 · 591 · 236 · 394 · 70 |
| XP · gold | 4462 · 897 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_headless` |
| Habitats | [[Regions/Strife Marches\|Strife Marches]], [[Regions/Sunscar\|Sunscar]] |
| Genre | Celtic Gothic |
| Trope | The dullahan of Irish folklore |

**Field note:** Weak to Light. Protects something nearby: a nest, a treasure, or a place.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_headless`.
- **Dimensions:** 2.6 m high × 0.78 m long × 0.83 m wide; prefab scale 1.444.
- **Physics:** 228.5 kg, gravity ×1.5, poise 96, knockback resistance 0.42, death style `ragdoll`.
- **Navigation:** speed 5.6 m/s, turn 248°/s, stopping distance 0.84 m.
- **Attack count:** 5; **signature:** a lantern burning where its head should be.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Sweep\|Sweep]] | melee | 1.3 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Charge\|Charge]] | dash | 1.3 | 5 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Head Throw\|Head Throw]] | ranged | 1.4 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Lantern Hurl\|Lantern Hurl]] | ranged | 1.3 | 8 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Vesper-Touched Headless Rider is a **horror undead** encountered at B- rank, around level 96. Its documented behaviour is *Guardian* and its AI pattern is *guardian_hold+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a lantern burning where its head should be. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Strife Marches|Strife Marches]], [[Regions/Sunscar|Sunscar]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_headless`, animation set `anim_headless`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/The Headless B|loot_headless_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Rider's Lantern\|Rider's Lantern]] | 60% | 1–3 |
| [[Items/Cursed Iron\|Cursed Iron]] | 30% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Sunscar\|Sunscar]] | 6 | A-, C+, B, B+, C | 76–132 | Night |
| [[Regions/Strife Marches\|Strife Marches]] | 5 | C+, C, B-, A-, B | 76–132 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05180` | Sunscar Vesper-Touched Headless Rider Elderborn | [[Regions/Sunscar\|Sunscar]] | Elderborn | A- | 132 | 3.51 m | Night | Like a typical Vesper-Touched Headless Rider, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_05181` | Sunscar Vesper-Touched Headless Rider Juvenile | [[Regions/Sunscar\|Sunscar]] | Juvenile | C+ | 86 | 2.21 m | Night | Like a typical Vesper-Touched Headless Rider, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_05182` | Sunscar Vesper-Touched Headless Rider Albino | [[Regions/Sunscar\|Sunscar]] | Albino | B | 108 | 2.6 m | Night | Like a typical Vesper-Touched Headless Rider, but a rare pale form with white skin or fur and red eyes. |
| `pop_05183` | Strife Marches Vesper-Touched Headless Rider Juvenile | [[Regions/Strife Marches\|Strife Marches]] | Juvenile | C+ | 86 | 2.21 m | Night | Like a typical Vesper-Touched Headless Rider, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_05184` | Sunscar Vesper-Touched Headless Rider Alpha | [[Regions/Sunscar\|Sunscar]] | Alpha | B+ | 120 | 3.25 m | Night | Like a typical Vesper-Touched Headless Rider, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_05185` | Strife Marches Vesper-Touched Headless Rider Runt | [[Regions/Strife Marches\|Strife Marches]] | Runt | C | 76 | 1.82 m | Night | Like a typical Vesper-Touched Headless Rider, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_05186` | Sunscar Vesper-Touched Headless Rider Runt | [[Regions/Sunscar\|Sunscar]] | Runt | C | 76 | 1.82 m | Night | Like a typical Vesper-Touched Headless Rider, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_05187` | Sunscar Vesper-Touched Headless Rider Scarred | [[Regions/Sunscar\|Sunscar]] | Scarred | B | 108 | 2.86 m | Night | Like a typical Vesper-Touched Headless Rider, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_05188` | Strife Marches Vesper-Touched Headless Rider | [[Regions/Strife Marches\|Strife Marches]] | Adult | B- | 96 | 2.6 m | Night | A typical adult Vesper-Touched Headless Rider of this region, with golden, grass-toned coloring. |
| `pop_05189` | Strife Marches Vesper-Touched Headless Rider Elderborn | [[Regions/Strife Marches\|Strife Marches]] | Elderborn | A- | 132 | 3.51 m | Night | Like a typical Vesper-Touched Headless Rider, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_05190` | Strife Marches Vesper-Touched Headless Rider Albino | [[Regions/Strife Marches\|Strife Marches]] | Albino | B | 108 | 2.6 m | Night | Like a typical Vesper-Touched Headless Rider, but a rare pale form with white skin or fur and red eyes. |

## Design recipe

Rig `rig_headless` · mesh `headless_base` · material `old_iron` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · broken symmetry, mimicry, audio-first reveal
