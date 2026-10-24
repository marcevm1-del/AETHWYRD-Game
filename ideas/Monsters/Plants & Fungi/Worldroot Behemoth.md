---
type: monster
id: mon_worldroot_behemoth
family: "Plants & Fungi"
rank: "SSS"
tier: core
tags: [monster, plants-fungi]
---
# Worldroot Behemoth

![[mon_worldroot_behemoth_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_worldroot_behemoth_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,326 tris · 55.507 × 37.087 × 80 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Worldroot Behemoth is a colossal creature with a walking body of bark and root, about 80 m tall. Its bark and leaves are rough, scarred and spiked, colored in leaf greens over bark brown. Its most striking feature is a walking forest with a glowing heartwood core. It has burning slit pupils. Its outline is crowned by slowly turning rings of light; lesser monsters flee from it. It circles its prey, surrounded by drifting pollen and tiny blossoms.

| Field | Value |
|---|---|
| Family · type | [[Families/Plants & Fungi|Plants & Fungi]] · Plant |
| Rank · level | SSS · 281 (267–294) |
| Menace | 3 · Menacing |
| Element · weakness | Nature · Fire |
| Size | 80 m |
| Behaviour | Passive (passive_wander) |
| HP · ATK · DEF · MATK · MDEF · SPD | 144467 · 1418 · 1021 · 1021 · 1021 · 100 |
| XP · gold | 24842 · 4024 |
| Ring | 8 |
| Rig · animation | [[Systems/Rigs/plant_rooted\|plant_rooted]] · `anim_plant_walker` |
| Habitats | [[Regions/Nox Dominion\|Nox Dominion]], [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] |
| Genre | Fairy-tale Forest |
| Trope | Screaming mandrakes, walking mushrooms and ancient treants |

**Field note:** Weak to Fire. Leaves you alone unless attacked.

## Motion implementation

- **Rig:** [[Systems/Rigs/plant_rooted|plant_rooted]] (keyword); animation set `anim_plant_walker`.
- **Dimensions:** 80 m high × 32 m long × 96 m wide; prefab scale 40.
- **Physics:** 10752000 kg, gravity ×1, poise 36691, knockback resistance 1, death style `wilt_collapse`.
- **Navigation:** speed 2.79 m/s, turn 60°/s, stopping distance 10 m.
- **Attack count:** 5; **signature:** a walking forest with a glowing heartwood core.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Branch Sweep\|Branch Sweep]] | melee | 1.1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Root Slam\|Root Slam]] | aoe | 1.5 | 9 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Regrow\|Regrow]] | heal | 0 | 20 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Root Bind\|Root Bind]] | grab | 1 | 11 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Thorn Volley\|Thorn Volley]] | magic | 1.5 | 10 s | Nature | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Worldroot Behemoth is a **menacing plant** encountered at SSS rank, around level 281. Its documented behaviour is *Passive* and its AI pattern is *passive_wander*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a walking forest with a glowing heartwood core. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Nox Dominion|Nox Dominion]], [[Regions/Great Labyrinth (Floors 91-120)|Great Labyrinth (Floors 91-120)]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_plant_walker`, animation set `anim_plant_walker`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Plants & Fungi SSS|loot_plant_sss]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Sap\|Sap]] | 60% | 1–3 |
| [[Items/Seed\|Seed]] | 30% | 1–1 |
| [[Items/Spore Cap\|Spore Cap]] | 15% | 1–1 |
| [[Items/SSS-Rank Monster Core\|SSS-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Plants & Fungi/Thunder Worldroot Behemoth|Thunder Worldroot Behemoth]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | 7 | SS+, SSS, SSS-, SSS+, EX, EX- | 253–300 | Day & Night |
| [[Regions/Nox Dominion\|Nox Dominion]] | 4 | SSS+, EX, SS+ | 253–300 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01801` | Great Labyrinth (Floors 91-120) Worldroot Behemoth Runt | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Runt | SS+ | 253 | 56 m | Day & Night | Like a typical Worldroot Behemoth, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_01802` | Nox Dominion Worldroot Behemoth Albino | [[Regions/Nox Dominion\|Nox Dominion]] | Albino | SSS+ | 294 | 80 m | Day & Night | Like a typical Worldroot Behemoth, but a rare pale form with white skin or fur and red eyes. |
| `pop_01803` | Great Labyrinth (Floors 91-120) Worldroot Behemoth | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Adult | SSS | 281 | 80 m | Day & Night | A typical adult Worldroot Behemoth of this region, with dust-grey coloring and old rune scars. |
| `pop_01804` | Nox Dominion Worldroot Behemoth Elderborn | [[Regions/Nox Dominion\|Nox Dominion]] | Elderborn | EX | 300 | 108 m | Day & Night | Like a typical Worldroot Behemoth, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_01805` | Great Labyrinth (Floors 91-120) Worldroot Behemoth Juvenile | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Juvenile | SSS- | 267 | 68 m | Day & Night | Like a typical Worldroot Behemoth, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_01806` | Nox Dominion Worldroot Behemoth Runt | [[Regions/Nox Dominion\|Nox Dominion]] | Runt | SS+ | 253 | 56 m | Day & Night | Like a typical Worldroot Behemoth, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_01807` | Great Labyrinth (Floors 91-120) Worldroot Behemoth Albino | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Albino | SSS+ | 294 | 80 m | Day & Night | Like a typical Worldroot Behemoth, but a rare pale form with white skin or fur and red eyes. |
| `pop_01808` | Nox Dominion Worldroot Behemoth Scarred | [[Regions/Nox Dominion\|Nox Dominion]] | Scarred | SSS+ | 294 | 88 m | Day & Night | Like a typical Worldroot Behemoth, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_01809` | Great Labyrinth (Floors 91-120) Worldroot Behemoth Elderborn | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Elderborn | EX | 300 | 108 m | Day & Night | Like a typical Worldroot Behemoth, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_01810` | Great Labyrinth (Floors 91-120) Worldroot Behemoth Scarred | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Scarred | SSS+ | 294 | 88 m | Day & Night | Like a typical Worldroot Behemoth, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_01811` | Great Labyrinth (Floors 91-120) Worldroot Behemoth Alpha | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Alpha | EX- | 300 | 100 m | Day & Night | Like a typical Worldroot Behemoth, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |

## Design recipe

Rig `rig_plant_walker` · mesh `plant_walker_base` · material `bark_leaf` · VFX `pollen_petals` · palette `#4caf50` `#a5d66f` `#3e2723` · triangle-based silhouette, sharp asymmetric spikes
