---
type: monster
id: mon_walking_mushroom
family: "Plants & Fungi"
rank: "F"
tier: core
tags: [monster, plants-fungi]
---
# Walking Mushroom

![[mon_walking_mushroom_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_walking_mushroom_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Walking Mushroom is a small creature with a walking body of bark and root, about 0.6 m tall. Its bark and leaves are smooth and clean, colored in leaf greens over bark brown. Look for a waddling cap on stubby legs. It has two bright dot eyes. It has no ornament at all: simple, readable shapes. It waddles, surrounded by drifting pollen and tiny blossoms.

| Field | Value |
|---|---|
| Family · type | [[Families/Plants & Fungi|Plants & Fungi]] · Plant |
| Rank · level | F · 8 (3–13) |
| Menace | 1 · Charming |
| Element · weakness | Nature · Fire |
| Size | 0.6 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 225 · 53 · 38 · 38 · 38 · 100 |
| XP · gold | 92 · 31 |
| Ring | 1 |
| Rig · animation | [[Systems/Rigs/stub_biped\|stub_biped]] · `anim_plant_walker` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Fairy-tale Forest |
| Trope | Screaming mandrakes, walking mushrooms and ancient treants |

**Field note:** Weak to Fire. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/stub_biped|stub_biped]] (override); animation set `anim_plant_walker`.
- **Dimensions:** 0.6 m high × 0.5 m long × 0.5 m wide; prefab scale 1.2.
- **Physics:** 37.8 kg, gravity ×1.5, poise 36, knockback resistance 0.05, death style `topple_puff`.
- **Navigation:** speed 2.14 m/s, turn 387°/s, stopping distance 0.58 m.
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

Walking Mushroom is a **charming plant** encountered at F rank, around level 8. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a waddling cap on stubby legs. Watch for its tell and leave a response window before committing to a long combo.

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

- [[Monsters/Plants & Fungi/Phantom Walking Mushroom|Phantom Walking Mushroom]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Aldmere\|Aldmere]] | 5 | F-, F+, E-, F | 3–19 | Day |
| [[Regions/Whisperwood\|Whisperwood]] | 6 | F-, F, F+, E- | 3–19 | Day |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01713` | Aldmere Walking Mushroom Runt | [[Regions/Aldmere\|Aldmere]] | Runt | F- | 3 | 0.42 m | Day | Like a typical Walking Mushroom, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_01714` | Whisperwood Walking Mushroom Juvenile | [[Regions/Whisperwood\|Whisperwood]] | Juvenile | F- | 3 | 0.51 m | Day | Like a typical Walking Mushroom, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_01715` | Whisperwood Walking Mushroom Runt | [[Regions/Whisperwood\|Whisperwood]] | Runt | F- | 3 | 0.42 m | Day | Like a typical Walking Mushroom, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_01716` | Whisperwood Walking Mushroom | [[Regions/Whisperwood\|Whisperwood]] | Adult | F | 8 | 0.6 m | Day | A typical adult Walking Mushroom of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_01717` | Aldmere Walking Mushroom Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | F+ | 13 | 0.66 m | Day | Like a typical Walking Mushroom, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_01718` | Whisperwood Walking Mushroom Albino | [[Regions/Whisperwood\|Whisperwood]] | Albino | F+ | 13 | 0.6 m | Day | Like a typical Walking Mushroom, but a rare pale form with white skin or fur and red eyes. |
| `pop_01719` | Whisperwood Walking Mushroom Alpha | [[Regions/Whisperwood\|Whisperwood]] | Alpha | E- | 19 | 0.75 m | Day | Like a typical Walking Mushroom, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_01720` | Whisperwood Walking Mushroom Scarred | [[Regions/Whisperwood\|Whisperwood]] | Scarred | F+ | 13 | 0.66 m | Day | Like a typical Walking Mushroom, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_01721` | Aldmere Walking Mushroom Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | E- | 19 | 0.75 m | Day | Like a typical Walking Mushroom, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_01722` | Aldmere Walking Mushroom Albino | [[Regions/Aldmere\|Aldmere]] | Albino | F+ | 13 | 0.6 m | Day | Like a typical Walking Mushroom, but a rare pale form with white skin or fur and red eyes. |
| `pop_01723` | Aldmere Walking Mushroom | [[Regions/Aldmere\|Aldmere]] | Adult | F | 8 | 0.6 m | Day | A typical adult Walking Mushroom of this region, with moss-green coloring that blends with the undergrowth. |

## Contracts and story encounters

- [[Quests/Weekly Board/A Basket of Mushrooms|A Basket of Mushrooms]] — rank undefined, in [[Regions/Whisperwood|Whisperwood]]

These links show where the species already matters to authored play. A contract target is not a claim that every local population is hostile; check the quest objective and the creature’s behavior before engaging.

## Design recipe

Rig `rig_plant_walker` · mesh `plant_walker_base` · material `bark_leaf` · VFX `pollen_petals` · palette `#4caf50` `#a5d66f` `#3e2723` · circle-based, soft silhouette
