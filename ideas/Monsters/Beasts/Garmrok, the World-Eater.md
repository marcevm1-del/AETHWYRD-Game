---
type: monster
id: mon_garmrok_the_world_eater
family: "Beasts"
rank: "EX"
tier: core
tags: [monster, beasts, unique]
---
# Garmrok, the World-Eater

![[mon_garmrok_the_world_eater_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_garmrok_the_world_eater_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,728 tris · 41.401 × 120 × 131.861 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Garmrok, the World-Eater is a colossal creature with a heavy, muscular quadruped frame, about 120 m long. Its coat is patchy and subtly wrong, as if assembled from memory, colored in starless black with faint violet edges. Its most striking feature is a wolf so vast its broken chains drag across the sky. It has eyes set slightly too far apart. Its presence is world-scale; the sky changes color when it appears. It moves in jerky stop-motion bursts, surrounded by warped air, as if space bends around it.

| Field | Value |
|---|---|
| Family · type | [[Families/Beasts|Beasts]] · Beast |
| Rank · level | EX · 300 (300–300) |
| Menace | 4 · Dread |
| Element · weakness | Void · Light |
| Size | 120 m |
| Behaviour | Territorial (territorial_guard+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 180278 · 1452 · 1210 · 968 · 1089 · 100 |
| XP · gold | 551660 · 4409 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/quad_large\|quad_large]] · `anim_quad_large` |
| Habitats | [[Regions/Frostveil\|Frostveil]] |
| Genre | Classic Fantasy |
| Trope | The horned rabbit "rookie killer" and wolf packs of every isekai starter forest |

**Field note:** Weak to Light. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_large|quad_large]] (rigId); animation set `anim_quad_large`.
- **Dimensions:** 78 m high × 120 m long × 19.2 m wide; prefab scale 30.
- **Physics:** 34560000 kg, gravity ×0.84, poise 1036, knockback resistance 1, death style `heavy_fall_dust`.
- **Navigation:** speed 40.28 m/s, turn 60°/s, stopping distance 12.4 m.
- **Attack count:** 5; **signature:** a wolf so vast its broken chains drag across the sky.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Maul\|Maul]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Pounce\|Pounce]] | dash | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Howl\|Howl]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Rending Bite\|Rending Bite]] | melee | 1.3 | 5 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Null Rift\|Null Rift]] | magic | 1.5 | 10 s | Void | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Garmrok, the World-Eater is a **dread beast** encountered at EX rank, around level 300. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a wolf so vast its broken chains drag across the sky. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Frostveil|Frostveil]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_large`, animation set `anim_quad_large`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Beasts EX|loot_beast_ex]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Pelt\|Pelt]] | 60% | 1–3 |
| [[Items/Fang\|Fang]] | 30% | 1–1 |
| [[Items/Prime Meat\|Prime Meat]] | 15% | 1–1 |
| [[Items/EX-Rank Monster Core\|EX-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (1)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Frostveil\|Frostveil]] | 1 | EX | 300–300 | Story |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00530` | Garmrok, the World-Eater | [[Regions/Frostveil\|Frostveil]] | Unique | EX | 300 | 120 m | Story | Unique being; see the species entry. |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `fur_groom` · VFX `void_distortion` · palette `#0b0b1a` `#3d2c8d` `#c9c9ff` · elongated, irregular silhouette; still-then-sudden timing
