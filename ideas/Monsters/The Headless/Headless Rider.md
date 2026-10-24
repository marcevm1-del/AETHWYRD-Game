---
type: monster
id: mon_headless_rider
family: "The Headless"
rank: "C"
tier: core
tags: [monster, the-headless]
---
# Headless Rider

> The Headless Rider is a large creature with a headless rider frame, about 2.6 m tall. Its armor is patchy and subtly wrong, as if assembled from memory, colored in ink black with bruised violet. Guild sketches always show a lantern burning where its head should be. It has eyes set slightly too far apart. Battle-worn plates and trophies hang from its body. It freezes whenever it is looked at, surrounded by shadows that lean toward it.

| Field | Value |
|---|---|
| Family · type | [[Families/The Headless|The Headless]] · Undead |
| Rank · level | C · 76 (65–86) |
| Menace | 4 · Dread |
| Element · weakness | Dark · Light |
| Size | 2.6 m |
| Behaviour | Guardian (guardian_hold+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 11650 · 314 · 471 · 188 · 314 · 70 |
| XP · gold | 3073 · 648 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_headless` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Strife Marches\|Strife Marches]], [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] |
| Genre | Celtic Gothic |
| Trope | The dullahan of Irish folklore |

**Field note:** Weak to Light. Protects something nearby: a nest, a treasure, or a place.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_headless`.
- **Dimensions:** 2.6 m high × 0.78 m long × 0.83 m wide; prefab scale 1.444.
- **Physics:** 228.5 kg, gravity ×1.5, poise 87, knockback resistance 0.39, death style `ragdoll`.
- **Navigation:** speed 5.34 m/s, turn 248°/s, stopping distance 0.84 m.
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

Headless Rider is a **dread undead** encountered at C rank, around level 76. Its documented behaviour is *Guardian* and its AI pattern is *guardian_hold+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a lantern burning where its head should be. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Strife Marches|Strife Marches]], [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_headless`, animation set `anim_headless`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/The Headless C|loot_headless_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Rider's Lantern\|Rider's Lantern]] | 60% | 1–3 |
| [[Items/Cursed Iron\|Cursed Iron]] | 30% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/The Headless/Vesper-Touched Headless Rider|Vesper-Touched Headless Rider]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Strife Marches\|Strife Marches]] | 3 | D+, B, C+ | 56–108 | Night |
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 5 | D+, B, C+, C- | 56–108 | Night |
| [[Regions/Aldmere\|Aldmere]] | 3 | C+, B | 86–108 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02329` | Strife Marches Headless Rider Runt | [[Regions/Strife Marches\|Strife Marches]] | Runt | D+ | 56 | 1.82 m | Night | Like a typical Headless Rider, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_02330` | Great Labyrinth (Floors 41-90) Headless Rider Runt | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Runt | D+ | 56 | 1.82 m | Night | Like a typical Headless Rider, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_02331` | Strife Marches Headless Rider Elderborn | [[Regions/Strife Marches\|Strife Marches]] | Elderborn | B | 108 | 3.51 m | Night | Like a typical Headless Rider, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_02332` | Great Labyrinth (Floors 41-90) Headless Rider Elderborn | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Elderborn | B | 108 | 3.51 m | Night | Like a typical Headless Rider, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_02333` | Aldmere Headless Rider Albino | [[Regions/Aldmere\|Aldmere]] | Albino | C+ | 86 | 2.6 m | Night | Like a typical Headless Rider, but a rare pale form with white skin or fur and red eyes. |
| `pop_02334` | Aldmere Headless Rider Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | C+ | 86 | 2.86 m | Night | Like a typical Headless Rider, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_02335` | Great Labyrinth (Floors 41-90) Headless Rider Scarred | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Scarred | C+ | 86 | 2.86 m | Night | Like a typical Headless Rider, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_02336` | Great Labyrinth (Floors 41-90) Headless Rider Albino | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Albino | C+ | 86 | 2.6 m | Night | Like a typical Headless Rider, but a rare pale form with white skin or fur and red eyes. |
| `pop_02337` | Strife Marches Headless Rider Albino | [[Regions/Strife Marches\|Strife Marches]] | Albino | C+ | 86 | 2.6 m | Night | Like a typical Headless Rider, but a rare pale form with white skin or fur and red eyes. |
| `pop_02338` | Great Labyrinth (Floors 41-90) Headless Rider Juvenile | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Juvenile | C- | 65 | 2.21 m | Night | Like a typical Headless Rider, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_02339` | Aldmere Headless Rider Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | B | 108 | 3.51 m | Night | Like a typical Headless Rider, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |

## Design recipe

Rig `rig_headless` · mesh `headless_base` · material `old_iron` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · elongated, irregular silhouette; still-then-sudden timing
