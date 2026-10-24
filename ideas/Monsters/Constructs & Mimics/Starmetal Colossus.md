---
type: monster
id: mon_starmetal_colossus
family: "Constructs & Mimics"
rank: "SSS"
tier: core
tags: [monster, constructs-mimics]
---
# Starmetal Colossus

![[mon_starmetal_colossus_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_starmetal_colossus_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,268 tris · 114.081 × 70.493 × 120 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Starmetal Colossus is a colossal creature with a towering machine-like frame, about 120 m tall. Its surface is weathered and natural, colored in warm gold and pearl white. Survivors describe a starmetal body that hums with Titan songs. It has amber predator eyes. Its outline is crowned by slowly turning rings of light; lesser monsters flee from it. It prowls, surrounded by soft radiance and floating motes of light.

| Field | Value |
|---|---|
| Family · type | [[Families/Constructs & Mimics|Constructs & Mimics]] · Construct |
| Rank · level | SSS · 281 (267–294) |
| Menace | 2 · Wild |
| Element · weakness | Light · Dark |
| Size | 120 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 208023 · 1134 · 1701 · 680 · 1134 · 70 |
| XP · gold | 24842 · 4024 |
| Ring | 8 |
| Rig · animation | [[Systems/Rigs/golem\|golem]] · `anim_golem` |
| Habitats | [[Regions/Vesper\|Vesper]], [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] |
| Genre | Ancient Ruins |
| Trope | Treasure-chest mimics and ancient guardian golems |

**Field note:** Weak to Dark. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/golem|golem]] (rigId); animation set `anim_golem`.
- **Dimensions:** 120 m high × 36 m long × 50.4 m wide; prefab scale 40.
- **Physics:** 78796800 kg, gravity ×1.08, poise 2783, knockback resistance 1, death style `crumble_into_rubble`.
- **Navigation:** speed 21.88 m/s, turn 60°/s, stopping distance 12.4 m.
- **Attack count:** 5; **signature:** a starmetal body that hums with Titan songs.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slam\|Slam]] | melee | 1.4 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Ground Pound\|Ground Pound]] | aoe | 1.8 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Stance\|Guard Stance]] | buff | 0 | 15 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Rune Pulse\|Rune Pulse]] | magic | 1.3 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Radiant Pulse\|Radiant Pulse]] | magic | 1.5 | 10 s | Light | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Starmetal Colossus is a **wild construct** encountered at SSS rank, around level 281. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Dark**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a starmetal body that hums with Titan songs. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Vesper|Vesper]], [[Regions/Great Labyrinth (Floors 91-120)|Great Labyrinth (Floors 91-120)]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_golem`, animation set `anim_golem`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Constructs & Mimics SSS|loot_construct_sss]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Golem Core\|Golem Core]] | 60% | 1–3 |
| [[Items/Rune Plate\|Rune Plate]] | 30% | 1–1 |
| [[Items/Gear\|Gear]] | 15% | 1–1 |
| [[Items/SSS-Rank Monster Core\|SSS-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Constructs & Mimics/Tide Starmetal Colossus|Tide Starmetal Colossus]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Vesper\|Vesper]] | 5 | SSS, SSS+, SS+, EX- | 253–300 | Day & Night |
| [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | 6 | SSS+, SS+, SSS, SSS-, EX- | 253–300 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01561` | Vesper Starmetal Colossus | [[Regions/Vesper\|Vesper]] | Adult | SSS | 281 | 120 m | Day & Night | A typical adult Starmetal Colossus of this region, with dust-grey coloring and old rune scars. |
| `pop_01562` | Vesper Starmetal Colossus Scarred | [[Regions/Vesper\|Vesper]] | Scarred | SSS+ | 294 | 132 m | Day & Night | Like a typical Starmetal Colossus, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_01563` | Vesper Starmetal Colossus Runt | [[Regions/Vesper\|Vesper]] | Runt | SS+ | 253 | 84 m | Day & Night | Like a typical Starmetal Colossus, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_01564` | Great Labyrinth (Floors 91-120) Starmetal Colossus Albino | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Albino | SSS+ | 294 | 120 m | Day & Night | Like a typical Starmetal Colossus, but a rare pale form with white skin or fur and red eyes. |
| `pop_01565` | Vesper Starmetal Colossus Alpha | [[Regions/Vesper\|Vesper]] | Alpha | EX- | 300 | 150 m | Day & Night | Like a typical Starmetal Colossus, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_01566` | Great Labyrinth (Floors 91-120) Starmetal Colossus Scarred | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Scarred | SSS+ | 294 | 132 m | Day & Night | Like a typical Starmetal Colossus, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_01567` | Great Labyrinth (Floors 91-120) Starmetal Colossus Runt | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Runt | SS+ | 253 | 84 m | Day & Night | Like a typical Starmetal Colossus, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_01568` | Great Labyrinth (Floors 91-120) Starmetal Colossus | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Adult | SSS | 281 | 120 m | Day & Night | A typical adult Starmetal Colossus of this region, with dust-grey coloring and old rune scars. |
| `pop_01569` | Great Labyrinth (Floors 91-120) Starmetal Colossus Juvenile | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Juvenile | SSS- | 267 | 102 m | Day & Night | Like a typical Starmetal Colossus, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_01570` | Great Labyrinth (Floors 91-120) Starmetal Colossus Alpha | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Alpha | EX- | 300 | 150 m | Day & Night | Like a typical Starmetal Colossus, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_01571` | Vesper Starmetal Colossus Albino | [[Regions/Vesper\|Vesper]] | Albino | SSS+ | 294 | 120 m | Day & Night | Like a typical Starmetal Colossus, but a rare pale form with white skin or fur and red eyes. |

## Design recipe

Rig `rig_golem` · mesh `golem_base` · material `stone_metal_runes` · VFX `holy_motes` · palette `#fff3b0` `#ffd166` `#ffffff` · real-animal silhouette with one fantasy exaggeration
