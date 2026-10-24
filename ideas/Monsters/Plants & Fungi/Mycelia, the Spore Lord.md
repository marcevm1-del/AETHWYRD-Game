---
type: monster
id: mon_mycelia_the_spore_lord
family: "Plants & Fungi"
rank: "B+"
tier: core
tags: [monster, plants-fungi, tyrant, unique]
---
# Mycelia, the Spore Lord

> The Mycelia, the Spore Lord is a huge creature with a tall, tree-like walking frame, about 5 m tall. Its bark and leaves are patchy and subtly wrong, as if assembled from memory, colored in bruise purple with sickly green. Look for a crown of glowing fungus fed by the World Tree's Blight. It has eyes that never blink. Faint runes glow along its body when it fights. It moves in jerky stop-motion bursts, surrounded by a low toxic haze that clings to the ground.

| Field | Value |
|---|---|
| Family · type | [[Families/Plants & Fungi|Plants & Fungi]] · Plant |
| Rank · level | B+ · 120 (108–132) |
| Menace | 4 · Dread |
| Element · weakness | Poison · Light |
| Size | 5 m |
| Behaviour | Passive (passive_wander+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 20372 · 613 · 441 · 441 · 441 · 100 |
| XP · gold | 127464 · 1225 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/plant_rooted\|plant_rooted]] · `anim_plant_walker` |
| Habitats | [[Regions/Sylvaran\|Sylvaran]] |
| Tyrant | Yes |
| Genre | Fairy-tale Forest |
| Trope | Screaming mandrakes, walking mushrooms and ancient treants |

**Field note:** Weak to Light. Leaves you alone unless attacked.

## Motion implementation

- **Rig:** [[Systems/Rigs/plant_rooted|plant_rooted]] (keyword); animation set `anim_plant_walker`.
- **Dimensions:** 5 m high × 2 m long × 6 m wide; prefab scale 2.5.
- **Physics:** 2625 kg, gravity ×1, poise 416, knockback resistance 1, death style `wilt_collapse`.
- **Navigation:** speed 0.65 m/s, turn 80°/s, stopping distance 1 m.
- **Attack count:** 5; **signature:** a crown of glowing fungus fed by the World Tree's Blight.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Branch Sweep\|Branch Sweep]] | melee | 1.1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Root Slam\|Root Slam]] | aoe | 1.5 | 9 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Regrow\|Regrow]] | heal | 0 | 20 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Root Bind\|Root Bind]] | grab | 1 | 11 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Venom Spit\|Venom Spit]] | magic | 1.5 | 10 s | Poison | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Mycelia, the Spore Lord is a **dread plant** encountered at B+ rank, around level 120. Its documented behaviour is *Passive* and its AI pattern is *passive_wander+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a crown of glowing fungus fed by the World Tree's Blight. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Sylvaran|Sylvaran]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_plant_walker`, animation set `anim_plant_walker`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Plants & Fungi B|loot_plant_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Sap\|Sap]] | 60% | 1–3 |
| [[Items/Seed\|Seed]] | 30% | 1–1 |
| [[Items/Spore Cap\|Spore Cap]] | 15% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (1)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Sylvaran\|Sylvaran]] | 1 | B+ | 120–120 | Story |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06718` | Mycelia, the Spore Lord | [[Regions/Sylvaran\|Sylvaran]] | Unique | B+ | 120 | 5 m | Story | Unique being; see the species entry. |

## Design recipe

Rig `rig_plant_walker` · mesh `plant_walker_base` · material `bark_leaf` · VFX `toxic_fog` · palette `#8e44ad` `#b8e986` `#2d1b3d` · elongated, irregular silhouette; still-then-sudden timing
