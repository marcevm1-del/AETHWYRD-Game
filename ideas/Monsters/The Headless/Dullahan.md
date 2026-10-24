---
type: monster
id: mon_dullahan
family: "The Headless"
rank: "B"
tier: core
tags: [monster, the-headless]
---
# Dullahan

![[mon_dullahan_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_dullahan_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (1,798 tris · 1.244 × 0.878 × 2.8 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Dullahan is a large creature with a tall, headless knightly build, about 2.8 m tall. Its armor is patchy and subtly wrong, as if assembled from memory, colored in ink black with bruised violet. Its own laughing head carried under one arm. It has eyes that never blink. Faint runes glow along its body when it fights. It glides without moving its legs, surrounded by shadows that lean toward it.

| Field | Value |
|---|---|
| Family · type | [[Families/The Headless|The Headless]] · Undead |
| Rank · level | B · 108 (96–120) |
| Menace | 4 · Dread |
| Element · weakness | Dark · Light |
| Size | 2.8 m |
| Behaviour | Guardian (guardian_hold+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 20154 · 442 · 663 · 265 · 442 · 70 |
| XP · gold | 5386 · 1057 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_headless` |
| Habitats | [[Regions/Strife Marches\|Strife Marches]], [[Regions/Sunscar\|Sunscar]], [[Regions/Moraveil\|Moraveil]], [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/Lumbaya\|Lumbaya]] |
| Genre | Celtic Gothic |
| Trope | The dullahan of Irish folklore |

**Field note:** Weak to Light. Protects something nearby: a nest, a treasure, or a place.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_headless`.
- **Dimensions:** 2.8 m high × 0.84 m long × 0.9 m wide; prefab scale 1.556.
- **Physics:** 285.4 kg, gravity ×1.5, poise 100, knockback resistance 0.42, death style `ragdoll`.
- **Navigation:** speed 5.54 m/s, turn 239°/s, stopping distance 0.88 m.
- **Attack count:** 5; **signature:** its own laughing head carried under one arm.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Sweep\|Sweep]] | melee | 1.3 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Charge\|Charge]] | dash | 1.3 | 5 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Head Throw\|Head Throw]] | ranged | 1.4 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Lantern Hurl\|Lantern Hurl]] | ranged | 1.3 | 8 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Dullahan is a **dread undead** encountered at B rank, around level 108. Its documented behaviour is *Guardian* and its AI pattern is *guardian_hold+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** its own laughing head carried under one arm. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Strife Marches|Strife Marches]], [[Regions/Sunscar|Sunscar]], [[Regions/Moraveil|Moraveil]], [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]], [[Regions/Lumbaya|Lumbaya]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_headless`, animation set `anim_headless`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/The Headless B|loot_headless_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Rider's Lantern\|Rider's Lantern]] | 60% | 1–3 |
| [[Items/Cursed Iron\|Cursed Iron]] | 30% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/The Headless/Vesper-Touched Dullahan|Vesper-Touched Dullahan]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Strife Marches\|Strife Marches]] | 3 | B-, B+, A | 96–146 | Night |
| [[Regions/Lumbaya\|Lumbaya]] | 2 | A, B+ | 120–146 | Night |
| [[Regions/Moraveil\|Moraveil]] | 4 | C+, B-, B, A | 86–146 | Night |
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 1 | A | 146–146 | Night |
| [[Regions/Sunscar\|Sunscar]] | 1 | B+ | 120–120 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02340` | Strife Marches Dullahan Juvenile | [[Regions/Strife Marches\|Strife Marches]] | Juvenile | B- | 96 | 2.38 m | Night | Like a typical Dullahan, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_02341` | Lumbaya Dullahan Elderborn | [[Regions/Lumbaya\|Lumbaya]] | Elderborn | A | 146 | 3.78 m | Night | Like a typical Dullahan, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_02342` | Moraveil Dullahan Runt | [[Regions/Moraveil\|Moraveil]] | Runt | C+ | 86 | 1.96 m | Night | Like a typical Dullahan, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_02343` | Strife Marches Dullahan Scarred | [[Regions/Strife Marches\|Strife Marches]] | Scarred | B+ | 120 | 3.08 m | Night | Like a typical Dullahan, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_02344` | Strife Marches Dullahan Elderborn | [[Regions/Strife Marches\|Strife Marches]] | Elderborn | A | 146 | 3.78 m | Night | Like a typical Dullahan, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_02345` | Great Labyrinth (Floors 41-90) Dullahan Elderborn | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Elderborn | A | 146 | 3.78 m | Night | Like a typical Dullahan, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_02346` | Moraveil Dullahan Juvenile | [[Regions/Moraveil\|Moraveil]] | Juvenile | B- | 96 | 2.38 m | Night | Like a typical Dullahan, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_02347` | Moraveil Dullahan | [[Regions/Moraveil\|Moraveil]] | Adult | B | 108 | 2.8 m | Night | A typical adult Dullahan of this region, with golden, grass-toned coloring. |
| `pop_02348` | Sunscar Dullahan Scarred | [[Regions/Sunscar\|Sunscar]] | Scarred | B+ | 120 | 3.08 m | Night | Like a typical Dullahan, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_02349` | Moraveil Dullahan Elderborn | [[Regions/Moraveil\|Moraveil]] | Elderborn | A | 146 | 3.78 m | Night | Like a typical Dullahan, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_02350` | Lumbaya Dullahan Scarred | [[Regions/Lumbaya\|Lumbaya]] | Scarred | B+ | 120 | 3.08 m | Night | Like a typical Dullahan, but covered in old battle scars, with dust-grey coloring and old rune scars. |

## Design recipe

Rig `rig_headless` · mesh `headless_base` · material `old_iron` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · elongated, irregular silhouette; still-then-sudden timing
