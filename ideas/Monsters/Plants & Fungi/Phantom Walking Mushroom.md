---
type: monster
id: mon_phantom_walking_mushroom
family: "Plants & Fungi"
rank: "F+"
tier: variant
tags: [monster, plants-fungi]
---
# Phantom Walking Mushroom

![[mon_phantom_walking_mushroom_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_phantom_walking_mushroom_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Phantom Walking Mushroom is a small creature with a walking body of bark and root, about 0.6 m tall. Its bark and leaves are weathered and natural, colored in warm gold and pearl white. Guild sketches always show a waddling cap on stubby legs. It has alert animal eyes. It has no ornament at all: simple, readable shapes. It prowls, surrounded by soft radiance and floating motes of light. Its body is translucent blue, half in the spirit world; weapons pass through it unless they are blessed or enchanted.

| Field | Value |
|---|---|
| Family · type | [[Families/Plants & Fungi|Plants & Fungi]] · Plant |
| Variant of | [[Monsters/Plants & Fungi/Walking Mushroom\|Walking Mushroom]] (spirit) |
| Rank · level | F+ · 13 (8–19) |
| Menace | 2 · Wild |
| Element · weakness | Light · Dark |
| Size | 0.6 m |
| Behaviour | Passive (passive_wander) |
| HP · ATK · DEF · MATK · MDEF · SPD | 412 · 78 · 56 · 56 · 56 · 100 |
| XP · gold | 190 · 57 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/stub_biped\|stub_biped]] · `anim_plant_walker` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] |
| Genre | Fairy-tale Forest |
| Trope | Screaming mandrakes, walking mushrooms and ancient treants |

**Field note:** Weak to Dark. Leaves you alone unless attacked.

## Motion implementation

- **Rig:** [[Systems/Rigs/stub_biped|stub_biped]] (override (base species)); animation set `anim_plant_walker`.
- **Dimensions:** 0.6 m high × 0.5 m long × 0.5 m wide; prefab scale 1.2.
- **Physics:** 35.9 kg, gravity ×1.35, poise 35, knockback resistance 0.05, death style `topple_puff`.
- **Navigation:** speed 2.05 m/s, turn 387°/s, stopping distance 0.58 m.
- **Attack count:** 5; **signature:** a waddling cap on stubby legs.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Branch Sweep\|Branch Sweep]] | melee | 1.1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Root Slam\|Root Slam]] | aoe | 1.5 | 9 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Regrow\|Regrow]] | heal | 0 | 20 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Root Bind\|Root Bind]] | grab | 1 | 11 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Radiant Pulse\|Radiant Pulse]] | magic | 1.5 | 10 s | Light | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Phantom Walking Mushroom is a **wild plant** encountered at F+ rank, around level 13. Its documented behaviour is *Passive* and its AI pattern is *passive_wander*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Dark**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a waddling cap on stubby legs. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Whisperwood|Whisperwood]], [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_plant_walker`, animation set `anim_plant_walker`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Plants & Fungi F|loot_plant_f]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Sap\|Sap]] | 60% | 1–3 |
| [[Items/Seed\|Seed]] | 30% | 1–1 |
| [[Items/Spore Cap\|Spore Cap]] | 15% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 3 | F+, E, E+ | 13–32 | Day & Night |
| [[Regions/Aldmere\|Aldmere]] | 4 | F-, E+, E- | 3–32 | Day & Night |
| [[Regions/Whisperwood\|Whisperwood]] | 4 | F-, F, F+, E+ | 3–32 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04590` | Great Labyrinth (Floors 1-40) Phantom Walking Mushroom | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Adult | F+ | 13 | 0.6 m | Day & Night | A typical adult Phantom Walking Mushroom of this region, with dust-grey coloring and old rune scars. |
| `pop_04591` | Aldmere Phantom Walking Mushroom Runt | [[Regions/Aldmere\|Aldmere]] | Runt | F- | 3 | 0.42 m | Day & Night | Like a typical Phantom Walking Mushroom, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_04592` | Great Labyrinth (Floors 1-40) Phantom Walking Mushroom Alpha | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Alpha | E | 26 | 0.75 m | Day & Night | Like a typical Phantom Walking Mushroom, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_04593` | Whisperwood Phantom Walking Mushroom Runt | [[Regions/Whisperwood\|Whisperwood]] | Runt | F- | 3 | 0.42 m | Day & Night | Like a typical Phantom Walking Mushroom, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_04594` | Aldmere Phantom Walking Mushroom Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | E+ | 32 | 0.81 m | Day & Night | Like a typical Phantom Walking Mushroom, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_04595` | Great Labyrinth (Floors 1-40) Phantom Walking Mushroom Elderborn | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Elderborn | E+ | 32 | 0.81 m | Day & Night | Like a typical Phantom Walking Mushroom, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_04596` | Whisperwood Phantom Walking Mushroom Juvenile | [[Regions/Whisperwood\|Whisperwood]] | Juvenile | F | 8 | 0.51 m | Day & Night | Like a typical Phantom Walking Mushroom, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_04597` | Aldmere Phantom Walking Mushroom Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | E- | 19 | 0.66 m | Day & Night | Like a typical Phantom Walking Mushroom, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_04598` | Whisperwood Phantom Walking Mushroom | [[Regions/Whisperwood\|Whisperwood]] | Adult | F+ | 13 | 0.6 m | Day & Night | A typical adult Phantom Walking Mushroom of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_04599` | Aldmere Phantom Walking Mushroom Albino | [[Regions/Aldmere\|Aldmere]] | Albino | E- | 19 | 0.6 m | Day & Night | Like a typical Phantom Walking Mushroom, but a rare pale form with white skin or fur and red eyes. |
| `pop_04600` | Whisperwood Phantom Walking Mushroom Elderborn | [[Regions/Whisperwood\|Whisperwood]] | Elderborn | E+ | 32 | 0.81 m | Day & Night | Like a typical Phantom Walking Mushroom, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_plant_walker` · mesh `plant_walker_base` · material `bark_leaf` · VFX `holy_motes` · palette `#fff3b0` `#ffd166` `#ffffff` · real-animal silhouette with one fantasy exaggeration
