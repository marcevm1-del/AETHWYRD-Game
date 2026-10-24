---
type: monster
id: mon_spore_lord
family: "Plants & Fungi"
rank: "C"
tier: core
tags: [monster, plants-fungi]
---
# Spore Lord

![[mon_spore_lord_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_spore_lord_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,492 tris · 1.53 × 1.034 × 3 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Spore Lord is a large creature with a walking body of bark and root, about 3 m tall. Its bark and leaves are patchy and subtly wrong, as if assembled from memory, colored in bruise purple with sickly green. Survivors describe a mushroom crown and a cloak of mycelium. It has eyes that never blink. Battle-worn plates and trophies hang from its body. It moves in jerky stop-motion bursts, surrounded by a low toxic haze that clings to the ground.

| Field | Value |
|---|---|
| Family · type | [[Families/Plants & Fungi|Plants & Fungi]] · Plant |
| Rank · level | C · 76 (65–86) |
| Menace | 4 · Dread |
| Element · weakness | Poison · Light |
| Size | 3 m |
| Behaviour | Passive (passive_wander+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 8733 · 393 · 283 · 283 · 283 · 100 |
| XP · gold | 3073 · 648 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/plant_rooted\|plant_rooted]] · `anim_plant_walker` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Xochitl Mire\|Xochitl Mire]], [[Regions/Lumbaya\|Lumbaya]] |
| Genre | Fairy-tale Forest |
| Trope | Screaming mandrakes, walking mushrooms and ancient treants |

**Field note:** Weak to Light. Leaves you alone unless attacked.

## Motion implementation

- **Rig:** [[Systems/Rigs/plant_rooted|plant_rooted]] (keyword); animation set `anim_plant_walker`.
- **Dimensions:** 3 m high × 1.2 m long × 3.6 m wide; prefab scale 1.5.
- **Physics:** 567 kg, gravity ×1, poise 149, knockback resistance 1, death style `wilt_collapse`.
- **Navigation:** speed 0.5 m/s, turn 104°/s, stopping distance 0.76 m.
- **Attack count:** 5; **signature:** a mushroom crown and a cloak of mycelium.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Branch Sweep\|Branch Sweep]] | melee | 1.1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Root Slam\|Root Slam]] | aoe | 1.5 | 9 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Regrow\|Regrow]] | heal | 0 | 20 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Root Bind\|Root Bind]] | grab | 1 | 11 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Venom Spit\|Venom Spit]] | magic | 1.5 | 10 s | Poison | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Spore Lord is a **dread plant** encountered at C rank, around level 76. Its documented behaviour is *Passive* and its AI pattern is *passive_wander+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a mushroom crown and a cloak of mycelium. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Xochitl Mire|Xochitl Mire]], [[Regions/Lumbaya|Lumbaya]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_plant_walker`, animation set `anim_plant_walker`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Plants & Fungi C|loot_plant_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Sap\|Sap]] | 60% | 1–3 |
| [[Items/Seed\|Seed]] | 30% | 1–1 |
| [[Items/Spore Cap\|Spore Cap]] | 15% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Plants & Fungi/Bog Spore Lord|Bog Spore Lord]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Aldmere\|Aldmere]] | 3 | D+, B-, C- | 56–96 | Night |
| [[Regions/Lumbaya\|Lumbaya]] | 4 | C+, B-, D+, C | 56–96 | Night |
| [[Regions/Xochitl Mire\|Xochitl Mire]] | 4 | C+, B, B- | 86–108 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01757` | Aldmere Spore Lord Runt | [[Regions/Aldmere\|Aldmere]] | Runt | D+ | 56 | 2.1 m | Night | Like a typical Spore Lord, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_01758` | Lumbaya Spore Lord Albino | [[Regions/Lumbaya\|Lumbaya]] | Albino | C+ | 86 | 3 m | Night | Like a typical Spore Lord, but a rare pale form with white skin or fur and red eyes. |
| `pop_01759` | Aldmere Spore Lord Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | B- | 96 | 3.75 m | Night | Like a typical Spore Lord, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_01760` | Xochitl Mire Spore Lord Albino | [[Regions/Xochitl Mire\|Xochitl Mire]] | Albino | C+ | 86 | 3 m | Night | Like a typical Spore Lord, but a rare pale form with white skin or fur and red eyes. |
| `pop_01761` | Xochitl Mire Spore Lord Elderborn | [[Regions/Xochitl Mire\|Xochitl Mire]] | Elderborn | B | 108 | 4.05 m | Night | Like a typical Spore Lord, but old and wise, with greying features and a cautious hunting style, with mud-slick, algae-streaked skin. |
| `pop_01762` | Lumbaya Spore Lord Alpha | [[Regions/Lumbaya\|Lumbaya]] | Alpha | B- | 96 | 3.75 m | Night | Like a typical Spore Lord, but larger and scarred, and others of its kind follow it, with vivid tropical markings. |
| `pop_01763` | Xochitl Mire Spore Lord Scarred | [[Regions/Xochitl Mire\|Xochitl Mire]] | Scarred | C+ | 86 | 3.3 m | Night | Like a typical Spore Lord, but covered in old battle scars, with mud-slick, algae-streaked skin. |
| `pop_01764` | Aldmere Spore Lord Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | C- | 65 | 2.55 m | Night | Like a typical Spore Lord, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_01765` | Xochitl Mire Spore Lord Alpha | [[Regions/Xochitl Mire\|Xochitl Mire]] | Alpha | B- | 96 | 3.75 m | Night | Like a typical Spore Lord, but larger and scarred, and others of its kind follow it, with mud-slick, algae-streaked skin. |
| `pop_01766` | Lumbaya Spore Lord Runt | [[Regions/Lumbaya\|Lumbaya]] | Runt | D+ | 56 | 2.1 m | Night | Like a typical Spore Lord, but smaller and scrappier than usual, with vivid tropical markings. |
| `pop_01767` | Lumbaya Spore Lord | [[Regions/Lumbaya\|Lumbaya]] | Adult | C | 76 | 3 m | Night | A typical adult Spore Lord of this region, with vivid tropical markings. |

## Design recipe

Rig `rig_plant_walker` · mesh `plant_walker_base` · material `bark_leaf` · VFX `toxic_fog` · palette `#8e44ad` `#b8e986` `#2d1b3d` · elongated, irregular silhouette; still-then-sudden timing
