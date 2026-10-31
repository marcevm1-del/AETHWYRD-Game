---
type: monster
id: mon_blaze_corpse_flower
family: "Plants & Fungi"
rank: "B+"
tier: variant
tags: [monster, plants-fungi]
---
# Blaze Corpse Flower

![[mon_blaze_corpse_flower_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_blaze_corpse_flower_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (1,820 tris · 2.886 × 2.427 × 4 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Blaze Corpse Flower is a large creature with a huge bulbous flower on a thick stalk, about 4 m tall. Its bark and leaves are patchy and subtly wrong, as if assembled from memory, colored in deep fern green and dark bark, with ember-orange markings. Survivors describe a rotting bloom the size of a cart. It has pale, pupil-less eyes. Faint runes glow along its body when it fights. It glides without moving its legs, surrounded by heat-shimmer and drifting sparks. This Fire-attuned variant carries one extra elemental feature, like glowing vein-lines, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Plants & Fungi|Plants & Fungi]] · Plant |
| Variant of | [[Monsters/Plants & Fungi/Corpse Flower\|Corpse Flower]] (elemental) |
| Rank · level | B+ · 120 (108–132) |
| Menace | 4 · Dread |
| Element · weakness | Fire · Water |
| Size | 4 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 15171 · 294 · 343 · 686 · 637 · 90 |
| XP · gold | 6373 · 1225 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/plant_rooted\|plant_rooted]] · `anim_plant_rooted` |
| Habitats | [[Regions/Sunscar\|Sunscar]], [[Regions/Xochitl Mire\|Xochitl Mire]] |
| Genre | Fairy-tale Forest |
| Trope | Screaming mandrakes, walking mushrooms and ancient treants |

**Field note:** Weak to Water. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/plant_rooted|plant_rooted]] (rigId); animation set `anim_plant_rooted`.
- **Dimensions:** 4 m high × 1.6 m long × 4.8 m wide; prefab scale 2.
- **Physics:** 1344 kg, gravity ×1, poise 258, knockback resistance 1, death style `wilt_collapse`.
- **Navigation:** speed 0.72 m/s, turn 90°/s, stopping distance 0.88 m.
- **Attack count:** 5; **signature:** a rotting bloom the size of a cart.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Vine Lash\|Vine Lash]] | melee | 1.1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Snap Jaw\|Snap Jaw]] | grab | 1.7 | 9 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Spore Burst\|Spore Burst]] | aoe | 1 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Root Bind\|Root Bind]] | grab | 1 | 11 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Ember Burst\|Ember Burst]] | magic | 1.5 | 10 s | Fire | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Blaze Corpse Flower is a **dread plant** encountered at B+ rank, around level 120. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Water**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a rotting bloom the size of a cart. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Sunscar|Sunscar]], [[Regions/Xochitl Mire|Xochitl Mire]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_plant_rooted`, animation set `anim_plant_rooted`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Plants & Fungi B|loot_plant_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Sap\|Sap]] | 60% | 1–3 |
| [[Items/Seed\|Seed]] | 30% | 1–1 |
| [[Items/Spore Cap\|Spore Cap]] | 15% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Xochitl Mire\|Xochitl Mire]] | 5 | A+, A-, B, B- | 96–159 | Night |
| [[Regions/Sunscar\|Sunscar]] | 6 | B-, A-, A, B, A+ | 96–159 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04645` | Xochitl Mire Blaze Corpse Flower Elderborn | [[Regions/Xochitl Mire\|Xochitl Mire]] | Elderborn | A+ | 159 | 5.4 m | Night | Like a typical Blaze Corpse Flower, but old and wise, with greying features and a cautious hunting style, with mud-slick, algae-streaked skin. |
| `pop_04646` | Sunscar Blaze Corpse Flower Runt | [[Regions/Sunscar\|Sunscar]] | Runt | B- | 96 | 2.8 m | Night | Like a typical Blaze Corpse Flower, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_04647` | Sunscar Blaze Corpse Flower Scarred | [[Regions/Sunscar\|Sunscar]] | Scarred | A- | 132 | 4.4 m | Night | Like a typical Blaze Corpse Flower, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_04648` | Sunscar Blaze Corpse Flower Alpha | [[Regions/Sunscar\|Sunscar]] | Alpha | A | 146 | 5 m | Night | Like a typical Blaze Corpse Flower, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_04649` | Xochitl Mire Blaze Corpse Flower Scarred | [[Regions/Xochitl Mire\|Xochitl Mire]] | Scarred | A- | 132 | 4.4 m | Night | Like a typical Blaze Corpse Flower, but covered in old battle scars, with mud-slick, algae-streaked skin. |
| `pop_04650` | Xochitl Mire Blaze Corpse Flower Juvenile | [[Regions/Xochitl Mire\|Xochitl Mire]] | Juvenile | B | 108 | 3.4 m | Night | Like a typical Blaze Corpse Flower, but young, with brighter colors and unworn features, with mud-slick, algae-streaked skin. |
| `pop_04651` | Xochitl Mire Blaze Corpse Flower Albino | [[Regions/Xochitl Mire\|Xochitl Mire]] | Albino | A- | 132 | 4 m | Night | Like a typical Blaze Corpse Flower, but a rare pale form with white skin or fur and red eyes. |
| `pop_04652` | Sunscar Blaze Corpse Flower Juvenile | [[Regions/Sunscar\|Sunscar]] | Juvenile | B | 108 | 3.4 m | Night | Like a typical Blaze Corpse Flower, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_04653` | Xochitl Mire Blaze Corpse Flower Runt | [[Regions/Xochitl Mire\|Xochitl Mire]] | Runt | B- | 96 | 2.8 m | Night | Like a typical Blaze Corpse Flower, but smaller and scrappier than usual, with mud-slick, algae-streaked skin. |
| `pop_04654` | Sunscar Blaze Corpse Flower Elderborn | [[Regions/Sunscar\|Sunscar]] | Elderborn | A+ | 159 | 5.4 m | Night | Like a typical Blaze Corpse Flower, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_04655` | Sunscar Blaze Corpse Flower Albino | [[Regions/Sunscar\|Sunscar]] | Albino | A- | 132 | 4 m | Night | Like a typical Blaze Corpse Flower, but a rare pale form with white skin or fur and red eyes. |

## Design recipe

Rig `rig_plant_rooted` · mesh `plant_rooted_base` · material `bark_leaf` · VFX `embers_heat_haze` · palette `#4e8047` `#4e3f2e` `#ff7a3d` · elongated, irregular silhouette; still-then-sudden timing
