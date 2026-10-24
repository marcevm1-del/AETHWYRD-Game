---
type: monster
id: mon_ruin_goblin_bomber
family: "Goblinoids"
rank: "D+"
tier: variant
tags: [monster, goblinoids]
---
# Ruin Goblin Bomber

> The Ruin Goblin Bomber is a small creature with a scrawny biped with long arms and bowed legs, about 1 m tall. Its skin is rough, scarred and spiked, colored in ink black with bruised violet. Look for a barrel of black powder strapped to its back and a lit fuse in its teeth. It has burning slit pupils. A distinctive marking runs along its back. It charges without hesitation, surrounded by shadows that lean toward it. Adapted to ruins lands, it has dust-grey coloring and old rune scars.

| Field | Value |
|---|---|
| Family · type | [[Families/Goblinoids|Goblinoids]] · Humanoid |
| Variant of | [[Monsters/Goblinoids/Goblin Bomber\|Goblin Bomber]] (regional) |
| Rank · level | D+ · 56 (48–65) |
| Menace | 3 · Menacing |
| Element · weakness | Dark · Light |
| Size | 1 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 3257 · 234 · 187 · 164 · 187 · 135 |
| XP · gold | 1888 · 423 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/small_biped\|small_biped]] · `anim_small_biped` |
| Habitats | [[Regions/Strife Marches\|Strife Marches]], [[Regions/Aldmere\|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] |
| Genre | Dark Fantasy |
| Trope | Goblins as horror in numbers (Goblin Slayer); hobgoblin → champion → king evolution |

**Field note:** Weak to Light. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/small_biped|small_biped]] (rigId); animation set `anim_small_biped`.
- **Dimensions:** 1 m high × 0.3 m long × 0.4 m wide; prefab scale 0.909.
- **Physics:** 16 kg, gravity ×1.5, poise 37, knockback resistance 0.21, death style `ragdoll_crumple`.
- **Navigation:** speed 5.59 m/s, turn 420°/s, stopping distance 0.6 m.
- **Attack count:** 5; **signature:** a barrel of black powder strapped to its back and a lit fuse in its teeth.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stab\|Stab]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Thrown Junk\|Thrown Junk]] | ranged | 0.8 | 4 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Frenzied Lunge\|Frenzied Lunge]] | melee | 1.5 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Sand Toss\|Sand Toss]] | debuff | 0 | 12 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Ruin Goblin Bomber is a **menacing humanoid** encountered at D+ rank, around level 56. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a barrel of black powder strapped to its back and a lit fuse in its teeth. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Strife Marches|Strife Marches]], [[Regions/Aldmere|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_small_biped`, animation set `anim_small_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

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
| [[Regions/Aldmere\|Aldmere]] | 3 | D-, C+, D+ | 40–86 | Day & Night |
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 4 | C-, C, D-, D+ | 40–76 | Day & Night |
| [[Regions/Strife Marches\|Strife Marches]] | 4 | C-, D, C+, D+ | 48–86 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05956` | Aldmere Ruin Goblin Bomber Runt | [[Regions/Aldmere\|Aldmere]] | Runt | D- | 40 | 0.7 m | Day & Night | Like a typical Ruin Goblin Bomber, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_05957` | Great Labyrinth (Floors 1-40) Ruin Goblin Bomber Albino | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Albino | C- | 65 | 1 m | Day & Night | Like a typical Ruin Goblin Bomber, but a rare pale form with white skin or fur and red eyes. |
| `pop_05958` | Great Labyrinth (Floors 1-40) Ruin Goblin Bomber Alpha | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Alpha | C | 76 | 1.25 m | Day & Night | Like a typical Ruin Goblin Bomber, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_05959` | Aldmere Ruin Goblin Bomber Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | C+ | 86 | 1.35 m | Day & Night | Like a typical Ruin Goblin Bomber, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_05960` | Strife Marches Ruin Goblin Bomber Scarred | [[Regions/Strife Marches\|Strife Marches]] | Scarred | C- | 65 | 1.1 m | Day & Night | Like a typical Ruin Goblin Bomber, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_05961` | Strife Marches Ruin Goblin Bomber Juvenile | [[Regions/Strife Marches\|Strife Marches]] | Juvenile | D | 48 | 0.85 m | Day & Night | Like a typical Ruin Goblin Bomber, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_05962` | Strife Marches Ruin Goblin Bomber Elderborn | [[Regions/Strife Marches\|Strife Marches]] | Elderborn | C+ | 86 | 1.35 m | Day & Night | Like a typical Ruin Goblin Bomber, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_05963` | Aldmere Ruin Goblin Bomber | [[Regions/Aldmere\|Aldmere]] | Adult | D+ | 56 | 1 m | Day & Night | A typical adult Ruin Goblin Bomber of this region, with golden, grass-toned coloring. |
| `pop_05964` | Great Labyrinth (Floors 1-40) Ruin Goblin Bomber Runt | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Runt | D- | 40 | 0.7 m | Day & Night | Like a typical Ruin Goblin Bomber, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_05965` | Great Labyrinth (Floors 1-40) Ruin Goblin Bomber | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Adult | D+ | 56 | 1 m | Day & Night | A typical adult Ruin Goblin Bomber of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_05966` | Strife Marches Ruin Goblin Bomber | [[Regions/Strife Marches\|Strife Marches]] | Adult | D+ | 56 | 1 m | Day & Night | A typical adult Ruin Goblin Bomber of this region, with golden, grass-toned coloring. |

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `rough_skin_leather` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · triangle-based silhouette, sharp asymmetric spikes
