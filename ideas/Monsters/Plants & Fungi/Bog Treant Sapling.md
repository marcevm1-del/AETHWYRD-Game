---
type: monster
id: mon_bog_treant_sapling
family: "Plants & Fungi"
rank: "D+"
tier: variant
tags: [monster, plants-fungi]
---
# Bog Treant Sapling

![[mon_bog_treant_sapling_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_bog_treant_sapling_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,568 tris · 1.625 × 1.185 × 2 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Bog Treant Sapling is a person-sized creature with a walking body of bark and root, about 2 m tall. Its bark and leaves are smooth and clean, colored in bruise purple with sickly green. Guild sketches always show a young tree with a sleepy face. It has wide curious eyes with star-shaped highlights. A distinctive marking runs along its back. It hops in little bursts, surrounded by a low toxic haze that clings to the ground. Adapted to swamp lands, it has mud-slick, algae-streaked skin.

| Field | Value |
|---|---|
| Family · type | [[Families/Plants & Fungi|Plants & Fungi]] · Plant |
| Variant of | [[Monsters/Plants & Fungi/Treant Sapling\|Treant Sapling]] (regional) |
| Rank · level | D+ · 56 (48–65) |
| Menace | 1 · Charming |
| Element · weakness | Poison · Light |
| Size | 2 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 4840 · 293 · 211 · 211 · 211 · 100 |
| XP · gold | 1888 · 423 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/plant_rooted\|plant_rooted]] · `anim_plant_walker` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Xochitl Mire\|Xochitl Mire]], [[Regions/Greymoor\|Greymoor]] |
| Genre | Fairy-tale Forest |
| Trope | Screaming mandrakes, walking mushrooms and ancient treants |

**Field note:** Weak to Light. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/plant_rooted|plant_rooted]] (keyword); animation set `anim_plant_walker`.
- **Dimensions:** 2 m high × 0.8 m long × 2.4 m wide; prefab scale 1.
- **Physics:** 168 kg, gravity ×1, poise 72, knockback resistance 1, death style `wilt_collapse`.
- **Navigation:** speed 0.39 m/s, turn 127°/s, stopping distance 0.64 m.
- **Attack count:** 5; **signature:** a young tree with a sleepy face.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Branch Sweep\|Branch Sweep]] | melee | 1.1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Root Slam\|Root Slam]] | aoe | 1.5 | 9 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Regrow\|Regrow]] | heal | 0 | 20 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Root Bind\|Root Bind]] | grab | 1 | 11 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Venom Spit\|Venom Spit]] | magic | 1.5 | 10 s | Poison | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Bog Treant Sapling is a **charming plant** encountered at D+ rank, around level 56. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a young tree with a sleepy face. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Xochitl Mire|Xochitl Mire]], [[Regions/Greymoor|Greymoor]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_plant_walker`, animation set `anim_plant_walker`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Plants & Fungi D|loot_plant_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Sap\|Sap]] | 60% | 1–3 |
| [[Items/Seed\|Seed]] | 30% | 1–1 |
| [[Items/Spore Cap\|Spore Cap]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Xochitl Mire\|Xochitl Mire]] | 3 | C-, C, D+ | 56–76 | Day |
| [[Regions/Aldmere\|Aldmere]] | 4 | D+, C, C- | 56–76 | Day |
| [[Regions/Greymoor\|Greymoor]] | 4 | C+, C, D, D+ | 48–86 | Day |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04623` | Xochitl Mire Bog Treant Sapling Albino | [[Regions/Xochitl Mire\|Xochitl Mire]] | Albino | C- | 65 | 2 m | Day | Like a typical Bog Treant Sapling, but a rare pale form with white skin or fur and red eyes. |
| `pop_04624` | Aldmere Bog Treant Sapling | [[Regions/Aldmere\|Aldmere]] | Adult | D+ | 56 | 2 m | Day | A typical adult Bog Treant Sapling of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_04625` | Greymoor Bog Treant Sapling Elderborn | [[Regions/Greymoor\|Greymoor]] | Elderborn | C+ | 86 | 2.7 m | Day | Like a typical Bog Treant Sapling, but old and wise, with greying features and a cautious hunting style, with mud-slick, algae-streaked skin. |
| `pop_04626` | Aldmere Bog Treant Sapling Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | C | 76 | 2.5 m | Day | Like a typical Bog Treant Sapling, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_04627` | Aldmere Bog Treant Sapling Albino | [[Regions/Aldmere\|Aldmere]] | Albino | C- | 65 | 2 m | Day | Like a typical Bog Treant Sapling, but a rare pale form with white skin or fur and red eyes. |
| `pop_04628` | Xochitl Mire Bog Treant Sapling Alpha | [[Regions/Xochitl Mire\|Xochitl Mire]] | Alpha | C | 76 | 2.5 m | Day | Like a typical Bog Treant Sapling, but larger and scarred, and others of its kind follow it, with mud-slick, algae-streaked skin. |
| `pop_04629` | Greymoor Bog Treant Sapling Alpha | [[Regions/Greymoor\|Greymoor]] | Alpha | C | 76 | 2.5 m | Day | Like a typical Bog Treant Sapling, but larger and scarred, and others of its kind follow it, with mud-slick, algae-streaked skin. |
| `pop_04630` | Greymoor Bog Treant Sapling Juvenile | [[Regions/Greymoor\|Greymoor]] | Juvenile | D | 48 | 1.7 m | Day | Like a typical Bog Treant Sapling, but young, with brighter colors and unworn features, with mud-slick, algae-streaked skin. |
| `pop_04631` | Xochitl Mire Bog Treant Sapling | [[Regions/Xochitl Mire\|Xochitl Mire]] | Adult | D+ | 56 | 2 m | Day | A typical adult Bog Treant Sapling of this region, with mud-slick, algae-streaked skin. |
| `pop_04632` | Aldmere Bog Treant Sapling Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | C- | 65 | 2.2 m | Day | Like a typical Bog Treant Sapling, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_04633` | Greymoor Bog Treant Sapling | [[Regions/Greymoor\|Greymoor]] | Adult | D+ | 56 | 2 m | Day | A typical adult Bog Treant Sapling of this region, with mud-slick, algae-streaked skin. |

## Design recipe

Rig `rig_plant_walker` · mesh `plant_walker_base` · material `bark_leaf` · VFX `toxic_fog` · palette `#8e44ad` `#b8e986` `#2d1b3d` · circle-based, soft silhouette
