---
type: monster
id: mon_cogmaw_the_gremlin_engine_king
family: "Gremlins"
rank: "A"
tier: core
tags: [monster, gremlins, tyrant, unique]
---
# Cogmaw, the Gremlin Engine-King

![[mon_cogmaw_the_gremlin_engine_king_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_cogmaw_the_gremlin_engine_king_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,306 tris · 1.51 × 1.776 × 3 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Cogmaw, the Gremlin Engine-King is a large creature with a small, compact humanoid body, about 3 m tall. Its skin is rough, scarred and spiked, colored in storm violet shot through with electric yellow. Look for a throne bolted onto a walking furnace that eats machines. It has narrow glowing eyes. An elegant crest and glowing veins of mana mark it as a champion of its kind. It strides with heavy steps, surrounded by crackling arcs that jump across its body.

| Field | Value |
|---|---|
| Family · type | [[Families/Gremlins|Gremlins]] · Fey Pest |
| Rank · level | A · 146 (132–159) |
| Menace | 3 · Menacing |
| Element · weakness | Lightning · Earth |
| Size | 3 m |
| Behaviour | Skittish (skittish_flee) |
| HP · ATK · DEF · MATK · MDEF · SPD | 19643 · 594 · 475 · 416 · 475 · 135 |
| XP · gold | 174387 · 1611 |
| Ring | 7 |
| Rig · animation | [[Systems/Rigs/small_biped\|small_biped]] · `anim_small_biped` |
| Habitats | [[Regions/Gearholm\|Gearholm]] |
| Tyrant | Yes |
| Genre | Steampunk Mischief |
| Trope | Machine-breaking pests |

**Field note:** Weak to Earth. Flees when hurt. Snares or ranged attacks work best.

## Motion implementation

- **Rig:** [[Systems/Rigs/small_biped|small_biped]] (rigId); animation set `anim_small_biped`.
- **Dimensions:** 3 m high × 0.9 m long × 1.2 m wide; prefab scale 2.727.
- **Physics:** 432 kg, gravity ×1.5, poise 100, knockback resistance 0.3, death style `ragdoll_crumple`.
- **Navigation:** speed 10.86 m/s, turn 242°/s, stopping distance 1 m.
- **Attack count:** 5; **signature:** a throne bolted onto a walking furnace that eats machines.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stab\|Stab]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Thrown Junk\|Thrown Junk]] | ranged | 0.8 | 4 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Frenzied Lunge\|Frenzied Lunge]] | melee | 1.5 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Wrench Sabotage\|Wrench Sabotage]] | debuff | 0 | 14 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Static Arc\|Static Arc]] | magic | 1.5 | 10 s | Lightning | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Cogmaw, the Gremlin Engine-King is a **menacing fey pest** encountered at A rank, around level 146. Its documented behaviour is *Skittish* and its AI pattern is *skittish_flee*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Earth**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a throne bolted onto a walking furnace that eats machines. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Gearholm|Gearholm]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_small_biped`, animation set `anim_small_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Gremlins A|loot_gremlin_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Stolen Bolt\|Stolen Bolt]] | 60% | 1–3 |
| [[Items/Gremlin Ear\|Gremlin Ear]] | 30% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (1)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Gearholm\|Gearholm]] | 1 | A | 146–146 | Story |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06747` | Cogmaw, the Gremlin Engine-King | [[Regions/Gearholm\|Gearholm]] | Unique | A | 146 | 3 m | Story | Unique being; see the species entry. |

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `rubbery_skin` · VFX `arc_sparks` · palette `#ffe14d` `#6c5ce7` `#1b1b3a` · triangle-based silhouette, sharp asymmetric spikes
