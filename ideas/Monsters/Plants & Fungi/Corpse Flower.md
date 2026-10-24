---
type: monster
id: mon_corpse_flower
family: "Plants & Fungi"
rank: "B"
tier: core
tags: [monster, plants-fungi]
---
# Corpse Flower

> The Corpse Flower is a large creature with a rooted plant body, about 4 m tall. Its bark and leaves are patchy and subtly wrong, as if assembled from memory, colored in ink black with bruised violet. Its most striking feature is a rotting bloom the size of a cart. It has eyes set slightly too far apart. Faint runes glow along its body when it fights. It freezes whenever it is looked at, surrounded by shadows that lean toward it.

| Field | Value |
|---|---|
| Family · type | [[Families/Plants & Fungi|Plants & Fungi]] · Plant |
| Rank · level | B · 108 (96–120) |
| Menace | 4 · Dread |
| Element · weakness | Dark · Light |
| Size | 4 m |
| Behaviour | Passive (passive_wander+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 12965 · 265 · 309 · 619 · 575 · 90 |
| XP · gold | 5386 · 1057 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/plant_rooted\|plant_rooted]] · `anim_plant_rooted` |
| Habitats | [[Regions/Strife Marches\|Strife Marches]], [[Regions/Lumbaya\|Lumbaya]], [[Regions/Aurumdeep\|Aurumdeep]] |
| Genre | Fairy-tale Forest |
| Trope | Screaming mandrakes, walking mushrooms and ancient treants |

**Field note:** Weak to Light. Leaves you alone unless attacked.

## Motion implementation

- **Rig:** [[Systems/Rigs/plant_rooted|plant_rooted]] (rigId); animation set `anim_plant_rooted`.
- **Dimensions:** 4 m high × 1.6 m long × 4.8 m wide; prefab scale 2.
- **Physics:** 1344 kg, gravity ×1, poise 258, knockback resistance 1, death style `wilt_collapse`.
- **Navigation:** speed 0.62 m/s, turn 90°/s, stopping distance 0.88 m.
- **Attack count:** 5; **signature:** a rotting bloom the size of a cart.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Vine Lash\|Vine Lash]] | melee | 1.1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Snap Jaw\|Snap Jaw]] | grab | 1.7 | 9 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Spore Burst\|Spore Burst]] | aoe | 1 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Root Bind\|Root Bind]] | grab | 1 | 11 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Corpse Flower is a **dread plant** encountered at B rank, around level 108. Its documented behaviour is *Passive* and its AI pattern is *passive_wander+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a rotting bloom the size of a cart. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Strife Marches|Strife Marches]], [[Regions/Lumbaya|Lumbaya]], [[Regions/Aurumdeep|Aurumdeep]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_plant_rooted`, animation set `anim_plant_rooted`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Plants & Fungi B|loot_plant_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Sap\|Sap]] | 60% | 1–3 |
| [[Items/Seed\|Seed]] | 30% | 1–1 |
| [[Items/Spore Cap\|Spore Cap]] | 15% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Plants & Fungi/Blaze Corpse Flower|Blaze Corpse Flower]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Aurumdeep\|Aurumdeep]] | 6 | C+, B+, A-, A, B- | 86–146 | Night |
| [[Regions/Lumbaya\|Lumbaya]] | 2 | C+, B- | 86–96 | Night |
| [[Regions/Strife Marches\|Strife Marches]] | 3 | B+, B | 108–120 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01768` | Aurumdeep Corpse Flower Runt | [[Regions/Aurumdeep\|Aurumdeep]] | Runt | C+ | 86 | 2.8 m | Night | Like a typical Corpse Flower, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_01769` | Aurumdeep Corpse Flower Albino | [[Regions/Aurumdeep\|Aurumdeep]] | Albino | B+ | 120 | 4 m | Night | Like a typical Corpse Flower, but a rare pale form with white skin or fur and red eyes. |
| `pop_01770` | Aurumdeep Corpse Flower Alpha | [[Regions/Aurumdeep\|Aurumdeep]] | Alpha | A- | 132 | 5 m | Night | Like a typical Corpse Flower, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_01771` | Aurumdeep Corpse Flower Scarred | [[Regions/Aurumdeep\|Aurumdeep]] | Scarred | B+ | 120 | 4.4 m | Night | Like a typical Corpse Flower, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_01772` | Lumbaya Corpse Flower Runt | [[Regions/Lumbaya\|Lumbaya]] | Runt | C+ | 86 | 2.8 m | Night | Like a typical Corpse Flower, but smaller and scrappier than usual, with vivid tropical markings. |
| `pop_01773` | Aurumdeep Corpse Flower Elderborn | [[Regions/Aurumdeep\|Aurumdeep]] | Elderborn | A | 146 | 5.4 m | Night | Like a typical Corpse Flower, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_01774` | Strife Marches Corpse Flower Scarred | [[Regions/Strife Marches\|Strife Marches]] | Scarred | B+ | 120 | 4.4 m | Night | Like a typical Corpse Flower, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_01775` | Aurumdeep Corpse Flower Juvenile | [[Regions/Aurumdeep\|Aurumdeep]] | Juvenile | B- | 96 | 3.4 m | Night | Like a typical Corpse Flower, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_01776` | Strife Marches Corpse Flower | [[Regions/Strife Marches\|Strife Marches]] | Adult | B | 108 | 4 m | Night | A typical adult Corpse Flower of this region, with dust-grey coloring and old rune scars. |
| `pop_01777` | Lumbaya Corpse Flower Juvenile | [[Regions/Lumbaya\|Lumbaya]] | Juvenile | B- | 96 | 3.4 m | Night | Like a typical Corpse Flower, but young, with brighter colors and unworn features, with vivid tropical markings. |
| `pop_01778` | Strife Marches Corpse Flower Albino | [[Regions/Strife Marches\|Strife Marches]] | Albino | B+ | 120 | 4 m | Night | Like a typical Corpse Flower, but a rare pale form with white skin or fur and red eyes. |

## Design recipe

Rig `rig_plant_rooted` · mesh `plant_rooted_base` · material `bark_leaf` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · elongated, irregular silhouette; still-then-sudden timing
