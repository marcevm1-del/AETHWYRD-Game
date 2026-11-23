---
type: monster
id: mon_treant_sapling
family: "Plants & Fungi"
rank: "D"
tier: core
tags: [monster, plants-fungi]
---
# Treant Sapling

![[mon_treant_sapling_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_treant_sapling_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 12,000 tris · 1.342 × 0.923 × 2 m · local file `Game/Assets/_Game/Art/Models/Monsters/Plants & Fungi/mon_treant_sapling.fbx`

> The Treant Sapling is a person-sized creature with a mushroom-capped walking body, about 2 m tall. Its bark and leaves are smooth and clean, colored in deep fern green and dark bark. Its most striking feature is a young tree with a sleepy face. It has two bright dot eyes. A distinctive marking runs along its back. It hops in little bursts, surrounded by drifting pollen and tiny blossoms.

| Field | Value |
|---|---|
| Family · type | [[Families/Plants & Fungi|Plants & Fungi]] · Plant |
| Rank · level | D · 48 (40–56) |
| Menace | 1 · Charming |
| Element · weakness | Nature · Fire |
| Size | 2 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 3857 · 253 · 182 · 182 · 182 · 100 |
| XP · gold | 1477 · 342 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/large_biped\|large_biped]] · `anim_plant_walker` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Strife Marches\|Strife Marches]], [[Regions/Xochitl Mire\|Xochitl Mire]], [[Regions/Kitsune Isles\|Kitsune Isles]], [[Regions/Mossdeep\|Mossdeep]] |
| Genre | Fairy-tale Forest |
| Trope | Screaming mandrakes, walking mushrooms and ancient treants |

**Field note:** Weak to Fire. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/large_biped|large_biped]] (override); animation set `anim_plant_walker`.
- **Dimensions:** 2 m high × 0.6 m long × 0.84 m wide; prefab scale 0.571.
- **Physics:** 144 kg, gravity ×1.3, poise 138, knockback resistance 0.81, death style `heavy_fall_dust`.
- **Navigation:** speed 4.08 m/s, turn 269°/s, stopping distance 0.8 m.
- **Attack count:** 5; **signature:** [object Object].

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Branch Sweep\|Branch Sweep]] | melee | 1.1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Root Slam\|Root Slam]] | aoe | 1.5 | 9 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Regrow\|Regrow]] | heal | 0 | 20 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Root Bind\|Root Bind]] | grab | 1 | 11 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Thorn Volley\|Thorn Volley]] | magic | 1.5 | 10 s | Nature | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Treant Sapling is a **charming plant** encountered at D rank, around level 48. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a young tree with a sleepy face. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Strife Marches|Strife Marches]], [[Regions/Xochitl Mire|Xochitl Mire]], [[Regions/Kitsune Isles|Kitsune Isles]], [[Regions/Mossdeep|Mossdeep]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_plant_walker`, animation set `anim_plant_walker`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Plants & Fungi D|loot_plant_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Sap\|Sap]] | 60% | 1–3 |
| [[Items/Seed\|Seed]] | 30% | 1–1 |
| [[Items/Spore Cap\|Spore Cap]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Plants & Fungi/Bog Treant Sapling|Bog Treant Sapling]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Kitsune Isles\|Kitsune Isles]] | 2 | D+ | 56–56 | Day |
| [[Regions/Mossdeep\|Mossdeep]] | 1 | D+ | 56–56 | Day |
| [[Regions/Xochitl Mire\|Xochitl Mire]] | 5 | C-, D+, C, D- | 40–76 | Day |
| [[Regions/Aldmere\|Aldmere]] | 1 | D+ | 56–56 | Day |
| [[Regions/Strife Marches\|Strife Marches]] | 2 | D-, E+ | 32–40 | Day |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01746` | Kitsune Isles Treant Sapling Scarred | [[Regions/Kitsune Isles\|Kitsune Isles]] | Scarred | D+ | 56 | 2.2 m | Day | Like a typical Treant Sapling, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_01747` | Mossdeep Treant Sapling Albino | [[Regions/Mossdeep\|Mossdeep]] | Albino | D+ | 56 | 2 m | Day | Like a typical Treant Sapling, but a rare pale form with white skin or fur and red eyes. |
| `pop_01748` | Kitsune Isles Treant Sapling Albino | [[Regions/Kitsune Isles\|Kitsune Isles]] | Albino | D+ | 56 | 2 m | Day | Like a typical Treant Sapling, but a rare pale form with white skin or fur and red eyes. |
| `pop_01749` | Xochitl Mire Treant Sapling Alpha | [[Regions/Xochitl Mire\|Xochitl Mire]] | Alpha | C- | 65 | 2.5 m | Day | Like a typical Treant Sapling, but larger and scarred, and others of its kind follow it, with mud-slick, algae-streaked skin. |
| `pop_01750` | Aldmere Treant Sapling Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | D+ | 56 | 2.2 m | Day | Like a typical Treant Sapling, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_01751` | Xochitl Mire Treant Sapling Albino | [[Regions/Xochitl Mire\|Xochitl Mire]] | Albino | D+ | 56 | 2 m | Day | Like a typical Treant Sapling, but a rare pale form with white skin or fur and red eyes. |
| `pop_01752` | Strife Marches Treant Sapling Juvenile | [[Regions/Strife Marches\|Strife Marches]] | Juvenile | D- | 40 | 1.7 m | Day | Like a typical Treant Sapling, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_01753` | Xochitl Mire Treant Sapling Scarred | [[Regions/Xochitl Mire\|Xochitl Mire]] | Scarred | D+ | 56 | 2.2 m | Day | Like a typical Treant Sapling, but covered in old battle scars, with mud-slick, algae-streaked skin. |
| `pop_01754` | Strife Marches Treant Sapling Runt | [[Regions/Strife Marches\|Strife Marches]] | Runt | E+ | 32 | 1.4 m | Day | Like a typical Treant Sapling, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_01755` | Xochitl Mire Treant Sapling Elderborn | [[Regions/Xochitl Mire\|Xochitl Mire]] | Elderborn | C | 76 | 2.7 m | Day | Like a typical Treant Sapling, but old and wise, with greying features and a cautious hunting style, with mud-slick, algae-streaked skin. |
| `pop_01756` | Xochitl Mire Treant Sapling Juvenile | [[Regions/Xochitl Mire\|Xochitl Mire]] | Juvenile | D- | 40 | 1.7 m | Day | Like a typical Treant Sapling, but young, with brighter colors and unworn features, with mud-slick, algae-streaked skin. |

## Design recipe

Rig `rig_plant_walker` · mesh `plant_walker_base` · material `bark_leaf` · VFX `pollen_petals` · palette `#4e713f` `#453329` `#8fd16a` · circle-based, soft silhouette
