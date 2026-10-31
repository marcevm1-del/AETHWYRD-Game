---
type: monster
id: mon_the_briar_king_lord_of_the_winter_court
family: "Plants & Fungi"
rank: "S"
tier: core
tags: [monster, plants-fungi, tyrant, unique]
---
# The Briar King, Lord of the Winter Court

![[mon_the_briar_king_lord_of_the_winter_court_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_the_briar_king_lord_of_the_winter_court_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,826 tris · 2.823 × 1.79 × 4 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The The Briar King, Lord of the Winter Court is a large creature with a walking body of bark and root, about 4 m tall. Its bark and leaves are rough, scarred and spiked, colored in moss green and lichen grey, with frost-blue markings. Survivors describe a crown of frozen thorns and a cloak of dead roses. It has narrow glowing eyes. Its regal silhouette is crowned by a halo-like ring of aura. It circles its prey, surrounded by falling snow motes and frosted ground where it steps.

| Field | Value |
|---|---|
| Family · type | [[Families/Plants & Fungi|Plants & Fungi]] · Plant |
| Rank · level | S · 188 (173–203) |
| Menace | 3 · Menacing |
| Element · weakness | Ice · Fire |
| Size | 4 m |
| Behaviour | Passive (passive_wander) |
| HP · ATK · DEF · MATK · MDEF · SPD | 37096 · 953 · 686 · 686 · 686 · 100 |
| XP · gold | 261258 · 2293 |
| Ring | 7 |
| Rig · animation | [[Systems/Rigs/large_biped\|large_biped]] · `anim_plant_walker` |
| Habitats | [[Regions/Everdusk\|Everdusk]] |
| Tyrant | Yes |
| Genre | Fairy-tale Forest |
| Trope | Screaming mandrakes, walking mushrooms and ancient treants |

**Field note:** Weak to Fire. Leaves you alone unless attacked.

## Motion implementation

- **Rig:** [[Systems/Rigs/large_biped|large_biped]] (override); animation set `anim_plant_walker`.
- **Dimensions:** 4 m high × 1.2 m long × 1.68 m wide; prefab scale 1.143.
- **Physics:** 1267.2 kg, gravity ×1.37, poise 327, knockback resistance 0.93, death style `heavy_fall_dust`.
- **Navigation:** speed 5.88 m/s, turn 190°/s, stopping distance 1.2 m.
- **Attack count:** 5; **signature:** [object Object].

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Branch Sweep\|Branch Sweep]] | melee | 1.1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Root Slam\|Root Slam]] | aoe | 1.5 | 9 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Regrow\|Regrow]] | heal | 0 | 20 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Root Bind\|Root Bind]] | grab | 1 | 11 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Frost Breath\|Frost Breath]] | magic | 1.5 | 10 s | Ice | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

The Briar King, Lord of the Winter Court is a **menacing plant** encountered at S rank, around level 188. Its documented behaviour is *Passive* and its AI pattern is *passive_wander*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a crown of frozen thorns and a cloak of dead roses. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Everdusk|Everdusk]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_plant_walker`, animation set `anim_plant_walker`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Plants & Fungi S|loot_plant_s]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Sap\|Sap]] | 60% | 1–3 |
| [[Items/Seed\|Seed]] | 30% | 1–1 |
| [[Items/Spore Cap\|Spore Cap]] | 15% | 1–1 |
| [[Items/S-Rank Monster Core\|S-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (1)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Everdusk\|Everdusk]] | 1 | S | 188–188 | Story |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06750` | The Briar King, Lord of the Winter Court | [[Regions/Everdusk\|Everdusk]] | Unique | S | 188 | 4 m | Story | Unique being; see the species entry. |

## Design recipe

Rig `rig_plant_walker` · mesh `plant_walker_base` · material `bark_leaf` · VFX `frost_trail_snow` · palette `#6d8b43` `#46512f` `#9fdcff` · triangle-based silhouette, sharp asymmetric spikes
