---
type: monster
id: mon_blighted_world_root
family: "Plants & Fungi"
rank: "EX"
tier: core
tags: [monster, plants-fungi, unique]
---
# Blighted World Root

> The Blighted World Root is a colossal creature with a huge bulbous flower on a thick stalk, about 300 m tall. Its bark and leaves are stretched, stitched and constantly shifting, colored in ink black with bruised violet. Guild sketches always show black roots that pulse like veins. It has no eyes at all, only a wide and patient mouth. Its presence is world-scale; the sky changes color when it appears. It unfolds into something larger, surrounded by shadows that lean toward it.

| Field | Value |
|---|---|
| Family · type | [[Families/Plants & Fungi|Plants & Fungi]] · Plant |
| Rank · level | EX · 300 (300–300) |
| Menace | 5 · Horror |
| Element · weakness | Dark · Light |
| Size | 300 m |
| Behaviour | Passive (passive_wander+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 131111 · 726 · 847 · 1694 · 1573 · 90 |
| XP · gold | 551660 · 4409 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/plant_rooted\|plant_rooted]] · `anim_plant_rooted` |
| Habitats | [[Regions/Sylvaran\|Sylvaran]] |
| Genre | Fairy-tale Forest |
| Trope | Screaming mandrakes, walking mushrooms and ancient treants |

**Field note:** Weak to Light. Leaves you alone unless attacked.

## Motion implementation

- **Rig:** [[Systems/Rigs/plant_rooted|plant_rooted]] (rigId); animation set `anim_plant_rooted`.
- **Dimensions:** 300 m high × 120 m long × 360 m wide; prefab scale 150.
- **Physics:** 567000000 kg, gravity ×1, poise 349688, knockback resistance 1, death style `wilt_collapse`.
- **Navigation:** speed 5.68 m/s, turn 60°/s, stopping distance 12.4 m.
- **Attack count:** 5; **signature:** black roots that pulse like veins.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Vine Lash\|Vine Lash]] | melee | 1.1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Snap Jaw\|Snap Jaw]] | grab | 1.7 | 9 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Spore Burst\|Spore Burst]] | aoe | 1 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Root Bind\|Root Bind]] | grab | 1 | 11 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Blighted World Root is a **horror plant** encountered at EX rank, around level 300. Its documented behaviour is *Passive* and its AI pattern is *passive_wander+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** black roots that pulse like veins. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Sylvaran|Sylvaran]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_plant_rooted`, animation set `anim_plant_rooted`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Plants & Fungi EX|loot_plant_ex]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Sap\|Sap]] | 60% | 1–3 |
| [[Items/Seed\|Seed]] | 30% | 1–1 |
| [[Items/Spore Cap\|Spore Cap]] | 15% | 1–1 |
| [[Items/EX-Rank Monster Core\|EX-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (1)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Sylvaran\|Sylvaran]] | 1 | EX | 300–300 | Story |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01812` | Blighted World Root | [[Regions/Sylvaran\|Sylvaran]] | Unique | EX | 300 | 300 m | Story | Unique being; see the species entry. |

## Design recipe

Rig `rig_plant_rooted` · mesh `plant_rooted_base` · material `bark_leaf` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · broken symmetry, mimicry, audio-first reveal
