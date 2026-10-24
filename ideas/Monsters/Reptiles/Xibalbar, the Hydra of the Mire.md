---
type: monster
id: mon_xibalbar_the_hydra_of_the_mire
family: "Reptiles"
rank: "B+"
tier: core
tags: [monster, reptiles, tyrant, unique]
---
# Xibalbar, the Hydra of the Mire

![[mon_xibalbar_the_hydra_of_the_mire_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_xibalbar_the_hydra_of_the_mire_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (3,706 tris · 2.035 × 10 × 4.722 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Xibalbar, the Hydra of the Mire is a huge creature with a coiling, legless body, about 10 m long. Its scales are patchy and subtly wrong, as if assembled from memory, colored in bruise purple with sickly green. Its most striking feature is seven heads, each wearing a feathered mask stolen from a temple. It has eyes that never blink. Faint runes glow along its body when it fights. It moves in jerky stop-motion bursts, surrounded by a low toxic haze that clings to the ground.

| Field | Value |
|---|---|
| Family · type | [[Families/Reptiles|Reptiles]] · Reptile |
| Rank · level | B+ · 120 (108–132) |
| Menace | 4 · Dread |
| Element · weakness | Poison · Light |
| Size | 10 m |
| Behaviour | Passive (passive_wander+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 21293 · 490 · 392 · 343 · 392 · 135 |
| XP · gold | 127464 · 1225 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/serpent\|serpent]] · `anim_serpent` |
| Habitats | [[Regions/Xochitl Mire\|Xochitl Mire]] |
| Tyrant | Yes |
| Genre | Classic Fantasy |
| Trope | Lizardmen as a proud people; the petrifying basilisk |

**Field note:** Weak to Light. Leaves you alone unless attacked.

## Motion implementation

- **Rig:** [[Systems/Rigs/serpent|serpent]] (rigId); animation set `anim_serpent`.
- **Dimensions:** 0.4 m high × 10 m long × 1 m wide; prefab scale 2.5.
- **Physics:** 2300 kg, gravity ×1.2, poise 399, knockback resistance 0.52, death style `limp_chain`.
- **Navigation:** speed 7.74 m/s, turn 95°/s, stopping distance 0.75 m.
- **Attack count:** 5; **signature:** seven heads, each wearing a feathered mask stolen from a temple.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Strike\|Strike]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Constrict\|Constrict]] | grab | 1.8 | 12 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Tail Sweep\|Tail Sweep]] | aoe | 1.2 | 7 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Tail Lash\|Tail Lash]] | aoe | 1.2 | 7 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Venom Spit\|Venom Spit]] | magic | 1.5 | 10 s | Poison | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Xibalbar, the Hydra of the Mire is a **dread reptile** encountered at B+ rank, around level 120. Its documented behaviour is *Passive* and its AI pattern is *passive_wander+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** seven heads, each wearing a feathered mask stolen from a temple. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Xochitl Mire|Xochitl Mire]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_serpent`, animation set `anim_serpent`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Reptiles B|loot_reptile_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Scale\|Scale]] | 60% | 1–3 |
| [[Items/Reptile Eye\|Reptile Eye]] | 30% | 1–1 |
| [[Items/Tail Meat\|Tail Meat]] | 15% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (1)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Xochitl Mire\|Xochitl Mire]] | 1 | B+ | 120–120 | Story |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06738` | Xibalbar, the Hydra of the Mire | [[Regions/Xochitl Mire\|Xochitl Mire]] | Unique | B+ | 120 | 10 m | Story | Unique being; see the species entry. |

## Design recipe

Rig `rig_serpent` · mesh `serpent_base` · material `scale_matte` · VFX `toxic_fog` · palette `#8e44ad` `#b8e986` `#2d1b3d` · elongated, irregular silhouette; still-then-sudden timing
