---
type: monster
id: mon_tide_elder_treant
family: "Plants & Fungi"
rank: "A+"
tier: variant
tags: [monster, plants-fungi]
---
# Tide Elder Treant

![[mon_tide_elder_treant_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_tide_elder_treant_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,528 tris · 8.401 × 5.084 × 12 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Tide Elder Treant is a huge creature with a mushroom-capped walking body, about 12 m tall. Its bark and leaves are weathered and natural, colored in leaf green over bark brown, with sea-blue markings. Guild sketches always show a moss beard and owls living in its branches. It has dark, wary eyes. An elegant crest and glowing veins of mana mark it as a champion of its kind. It lopes in long strides, surrounded by fine mist and droplets that orbit it. This Water-attuned variant carries one extra elemental feature, like crystal spikes, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Plants & Fungi|Plants & Fungi]] · Plant |
| Variant of | [[Monsters/Plants & Fungi/Elder Treant\|Elder Treant]] (elemental) |
| Rank · level | A+ · 159 (146–173) |
| Menace | 2 · Wild |
| Element · weakness | Water · Lightning |
| Size | 12 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 40104 · 808 · 581 · 581 · 581 · 100 |
| XP · gold | 9993 · 1815 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/giant_biped\|giant_biped]] · `anim_plant_walker` |
| Habitats | [[Regions/Lumbaya\|Lumbaya]], [[Regions/Hoshizora\|Hoshizora]] |
| Genre | Fairy-tale Forest |
| Trope | Screaming mandrakes, walking mushrooms and ancient treants |

**Field note:** Weak to Lightning. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/giant_biped|giant_biped]] (override (base species)); animation set `anim_plant_walker`.
- **Dimensions:** 12 m high × 4.08 m long × 5.28 m wide; prefab scale 1.2.
- **Physics:** 29030.4 kg, gravity ×1, poise 638, knockback resistance 1, death style `cinematic_collapse`.
- **Navigation:** speed 6.4 m/s, turn 87°/s, stopping distance 2.56 m.
- **Attack count:** 5; **signature:** a moss beard and owls living in its branches.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Branch Sweep\|Branch Sweep]] | melee | 1.1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Root Slam\|Root Slam]] | aoe | 1.5 | 9 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Regrow\|Regrow]] | heal | 0 | 20 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Root Bind\|Root Bind]] | grab | 1 | 11 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Tide Lash\|Tide Lash]] | magic | 1.5 | 10 s | Water | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Tide Elder Treant is a **wild plant** encountered at A+ rank, around level 159. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Lightning**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a moss beard and owls living in its branches. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Lumbaya|Lumbaya]], [[Regions/Hoshizora|Hoshizora]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_plant_walker`, animation set `anim_plant_walker`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Plants & Fungi A|loot_plant_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Sap\|Sap]] | 60% | 1–3 |
| [[Items/Seed\|Seed]] | 30% | 1–1 |
| [[Items/Spore Cap\|Spore Cap]] | 15% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Lumbaya\|Lumbaya]] | 6 | S, A-, A, A+, S-, S+ | 132–203 | Day & Night |
| [[Regions/Hoshizora\|Hoshizora]] | 5 | S+, A-, A+, S-, A | 132–203 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04656` | Lumbaya Tide Elder Treant Alpha | [[Regions/Lumbaya\|Lumbaya]] | Alpha | S | 188 | 15 m | Day & Night | Like a typical Tide Elder Treant, but larger and scarred, and others of its kind follow it, with vivid tropical markings. |
| `pop_04657` | Hoshizora Tide Elder Treant Elderborn | [[Regions/Hoshizora\|Hoshizora]] | Elderborn | S+ | 203 | 16.2 m | Day & Night | Like a typical Tide Elder Treant, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_04658` | Lumbaya Tide Elder Treant Runt | [[Regions/Lumbaya\|Lumbaya]] | Runt | A- | 132 | 8.4 m | Day & Night | Like a typical Tide Elder Treant, but smaller and scrappier than usual, with vivid tropical markings. |
| `pop_04659` | Lumbaya Tide Elder Treant Juvenile | [[Regions/Lumbaya\|Lumbaya]] | Juvenile | A | 146 | 10.2 m | Day & Night | Like a typical Tide Elder Treant, but young, with brighter colors and unworn features, with vivid tropical markings. |
| `pop_04660` | Lumbaya Tide Elder Treant | [[Regions/Lumbaya\|Lumbaya]] | Adult | A+ | 159 | 12 m | Day & Night | A typical adult Tide Elder Treant of this region, with vivid tropical markings. |
| `pop_04661` | Hoshizora Tide Elder Treant Runt | [[Regions/Hoshizora\|Hoshizora]] | Runt | A- | 132 | 8.4 m | Day & Night | Like a typical Tide Elder Treant, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_04662` | Hoshizora Tide Elder Treant | [[Regions/Hoshizora\|Hoshizora]] | Adult | A+ | 159 | 12 m | Day & Night | A typical adult Tide Elder Treant of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_04663` | Lumbaya Tide Elder Treant Scarred | [[Regions/Lumbaya\|Lumbaya]] | Scarred | S- | 173 | 13.2 m | Day & Night | Like a typical Tide Elder Treant, but covered in old battle scars, with vivid tropical markings. |
| `pop_04664` | Lumbaya Tide Elder Treant Elderborn | [[Regions/Lumbaya\|Lumbaya]] | Elderborn | S+ | 203 | 16.2 m | Day & Night | Like a typical Tide Elder Treant, but old and wise, with greying features and a cautious hunting style, with vivid tropical markings. |
| `pop_04665` | Hoshizora Tide Elder Treant Albino | [[Regions/Hoshizora\|Hoshizora]] | Albino | S- | 173 | 12 m | Day & Night | Like a typical Tide Elder Treant, but a rare pale form with white skin or fur and red eyes. |
| `pop_04666` | Hoshizora Tide Elder Treant Juvenile | [[Regions/Hoshizora\|Hoshizora]] | Juvenile | A | 146 | 10.2 m | Day & Night | Like a typical Tide Elder Treant, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_plant_walker` · mesh `plant_walker_base` · material `bark_leaf` · VFX `mist_droplets` · palette `#56923c` `#5e4832` `#4fa8e8` · real-animal silhouette with one fantasy exaggeration
