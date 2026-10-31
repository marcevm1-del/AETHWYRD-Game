---
type: monster
id: mon_mandrake
family: "Plants & Fungi"
rank: "F"
tier: core
tags: [monster, plants-fungi]
---
# Mandrake

![[mon_mandrake_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_mandrake_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,028 tris · 0.208 × 0.13 × 0.3 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Mandrake is a tiny creature with a tall, tree-like walking frame, about 0.3 m tall. Its bark and leaves are weathered and natural, colored in moss green and lichen grey. Its most striking feature is a screaming root with a leafy tuft. It has alert animal eyes. It has no ornament at all: simple, readable shapes. It lopes in long strides, surrounded by drifting pollen and tiny blossoms.

| Field | Value |
|---|---|
| Family · type | [[Families/Plants & Fungi|Plants & Fungi]] · Plant |
| Rank · level | F · 8 (3–13) |
| Menace | 2 · Wild |
| Element · weakness | Nature · Fire |
| Size | 0.3 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 190 · 53 · 38 · 38 · 38 · 100 |
| XP · gold | 92 · 31 |
| Ring | 1 |
| Rig · animation | [[Systems/Rigs/stub_biped\|stub_biped]] · `anim_plant_walker` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Fairy-tale Forest |
| Trope | Screaming mandrakes, walking mushrooms and ancient treants |

**Field note:** Weak to Fire. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/stub_biped|stub_biped]] (override); animation set `anim_plant_walker`.
- **Dimensions:** 0.3 m high × 0.25 m long × 0.25 m wide; prefab scale 0.6.
- **Physics:** 4.7 kg, gravity ×1.5, poise 12, knockback resistance 0.05, death style `topple_puff`.
- **Navigation:** speed 1.68 m/s, turn 548°/s, stopping distance 0.5 m.
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

Mandrake is a **wild plant** encountered at F rank, around level 8. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a screaming root with a leafy tuft. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Whisperwood|Whisperwood]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_plant_walker`, animation set `anim_plant_walker`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Plants & Fungi F|loot_plant_f]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Sap\|Sap]] | 60% | 1–3 |
| [[Items/Seed\|Seed]] | 30% | 1–1 |
| [[Items/Spore Cap\|Spore Cap]] | 15% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Plants & Fungi/Ancient Mandrake|Ancient Mandrake]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Aldmere\|Aldmere]] | 4 | F-, F, E- | 3–19 | Day & Night |
| [[Regions/Whisperwood\|Whisperwood]] | 7 | F+, E, F-, E-, F | 3–26 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01691` | Aldmere Mandrake Runt | [[Regions/Aldmere\|Aldmere]] | Runt | F- | 3 | 0.21 m | Day & Night | Like a typical Mandrake, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_01692` | Aldmere Mandrake | [[Regions/Aldmere\|Aldmere]] | Adult | F | 8 | 0.3 m | Day & Night | A typical adult Mandrake of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_01693` | Whisperwood Mandrake Scarred | [[Regions/Whisperwood\|Whisperwood]] | Scarred | F+ | 13 | 0.33 m | Day & Night | Like a typical Mandrake, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_01694` | Whisperwood Mandrake Elderborn | [[Regions/Whisperwood\|Whisperwood]] | Elderborn | E | 26 | 0.41 m | Day & Night | Like a typical Mandrake, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_01695` | Whisperwood Mandrake Albino | [[Regions/Whisperwood\|Whisperwood]] | Albino | F+ | 13 | 0.3 m | Day & Night | Like a typical Mandrake, but a rare pale form with white skin or fur and red eyes. |
| `pop_01696` | Whisperwood Mandrake Juvenile | [[Regions/Whisperwood\|Whisperwood]] | Juvenile | F- | 3 | 0.26 m | Day & Night | Like a typical Mandrake, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_01697` | Aldmere Mandrake Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | E- | 19 | 0.38 m | Day & Night | Like a typical Mandrake, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_01698` | Whisperwood Mandrake Alpha | [[Regions/Whisperwood\|Whisperwood]] | Alpha | E- | 19 | 0.38 m | Day & Night | Like a typical Mandrake, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_01699` | Whisperwood Mandrake Runt | [[Regions/Whisperwood\|Whisperwood]] | Runt | F- | 3 | 0.21 m | Day & Night | Like a typical Mandrake, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_01700` | Aldmere Mandrake Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | F- | 3 | 0.26 m | Day & Night | Like a typical Mandrake, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_01701` | Whisperwood Mandrake | [[Regions/Whisperwood\|Whisperwood]] | Adult | F | 8 | 0.3 m | Day & Night | A typical adult Mandrake of this region, with moss-green coloring that blends with the undergrowth. |

## Contracts and story encounters

- [[Quests/Weekly Board/Mandrake Harvest|Mandrake Harvest]] — rank undefined, in [[Regions/Whisperwood|Whisperwood]]

These links show where the species already matters to authored play. A contract target is not a claim that every local population is hostile; check the quest objective and the creature’s behavior before engaging.

## Design recipe

Rig `rig_plant_walker` · mesh `plant_walker_base` · material `bark_leaf` · VFX `pollen_petals` · palette `#709547` `#495732` `#8fd16a` · real-animal silhouette with one fantasy exaggeration
