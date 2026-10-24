---
type: monster
id: mon_elder_treant
family: "Plants & Fungi"
rank: "A"
tier: core
tags: [monster, plants-fungi]
---
# Elder Treant

> The Elder Treant is a huge creature with a mushroom-capped walking body, about 12 m tall. Its bark and leaves are weathered and natural, colored in leaf greens over bark brown. Look for a moss beard and owls living in its branches. It has dark, wary eyes. An elegant crest and glowing veins of mana mark it as a champion of its kind. It lopes in long strides, surrounded by drifting pollen and tiny blossoms.

| Field | Value |
|---|---|
| Family · type | [[Families/Plants & Fungi|Plants & Fungi]] · Plant |
| Rank · level | A · 146 (132–159) |
| Menace | 2 · Wild |
| Element · weakness | Nature · Fire |
| Size | 12 m |
| Behaviour | Passive (passive_wander) |
| HP · ATK · DEF · MATK · MDEF · SPD | 35304 · 743 · 535 · 535 · 535 · 100 |
| XP · gold | 8719 · 1611 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/plant_rooted\|plant_rooted]] · `anim_plant_walker` |
| Habitats | [[Regions/Lumbaya\|Lumbaya]], [[Regions/Shen-Lu\|Shen-Lu]], [[Regions/Hoshizora\|Hoshizora]], [[Regions/Everdusk\|Everdusk]], [[Regions/Moraveil\|Moraveil]] |
| Genre | Fairy-tale Forest |
| Trope | Screaming mandrakes, walking mushrooms and ancient treants |

**Field note:** Weak to Fire. Leaves you alone unless attacked.

## Motion implementation

- **Rig:** [[Systems/Rigs/plant_rooted|plant_rooted]] (keyword); animation set `anim_plant_walker`.
- **Dimensions:** 12 m high × 4.8 m long × 14.4 m wide; prefab scale 6.
- **Physics:** 36288 kg, gravity ×1, poise 1543, knockback resistance 1, death style `wilt_collapse`.
- **Navigation:** speed 1.03 m/s, turn 60°/s, stopping distance 1.84 m.
- **Attack count:** 5; **signature:** a moss beard and owls living in its branches.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Branch Sweep\|Branch Sweep]] | melee | 1.1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Root Slam\|Root Slam]] | aoe | 1.5 | 9 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Regrow\|Regrow]] | heal | 0 | 20 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Root Bind\|Root Bind]] | grab | 1 | 11 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Thorn Volley\|Thorn Volley]] | magic | 1.5 | 10 s | Nature | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Elder Treant is a **wild plant** encountered at A rank, around level 146. Its documented behaviour is *Passive* and its AI pattern is *passive_wander*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a moss beard and owls living in its branches. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Lumbaya|Lumbaya]], [[Regions/Shen-Lu|Shen-Lu]], [[Regions/Hoshizora|Hoshizora]], [[Regions/Everdusk|Everdusk]], [[Regions/Moraveil|Moraveil]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_plant_walker`, animation set `anim_plant_walker`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Plants & Fungi A|loot_plant_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Sap\|Sap]] | 60% | 1–3 |
| [[Items/Seed\|Seed]] | 30% | 1–1 |
| [[Items/Spore Cap\|Spore Cap]] | 15% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Plants & Fungi/Tide Elder Treant|Tide Elder Treant]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Lumbaya\|Lumbaya]] | 4 | B+, A+, S | 120–188 | Day & Night |
| [[Regions/Everdusk\|Everdusk]] | 3 | A+, A, A- | 132–159 | Day & Night |
| [[Regions/Moraveil\|Moraveil]] | 2 | S-, B+ | 120–173 | Day & Night |
| [[Regions/Hoshizora\|Hoshizora]] | 1 | A | 146–146 | Day & Night |
| [[Regions/Shen-Lu\|Shen-Lu]] | 1 | A- | 132–132 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01779` | Lumbaya Elder Treant Runt | [[Regions/Lumbaya\|Lumbaya]] | Runt | B+ | 120 | 8.4 m | Day & Night | Like a typical Elder Treant, but smaller and scrappier than usual, with vivid tropical markings. |
| `pop_01780` | Everdusk Elder Treant Scarred | [[Regions/Everdusk\|Everdusk]] | Scarred | A+ | 159 | 13.2 m | Day & Night | Like a typical Elder Treant, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_01781` | Moraveil Elder Treant Alpha | [[Regions/Moraveil\|Moraveil]] | Alpha | S- | 173 | 15 m | Day & Night | Like a typical Elder Treant, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_01782` | Hoshizora Elder Treant | [[Regions/Hoshizora\|Hoshizora]] | Adult | A | 146 | 12 m | Day & Night | A typical adult Elder Treant of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_01783` | Lumbaya Elder Treant Albino | [[Regions/Lumbaya\|Lumbaya]] | Albino | A+ | 159 | 12 m | Day & Night | Like a typical Elder Treant, but a rare pale form with white skin or fur and red eyes. |
| `pop_01784` | Everdusk Elder Treant | [[Regions/Everdusk\|Everdusk]] | Adult | A | 146 | 12 m | Day & Night | A typical adult Elder Treant of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_01785` | Moraveil Elder Treant Runt | [[Regions/Moraveil\|Moraveil]] | Runt | B+ | 120 | 8.4 m | Day & Night | Like a typical Elder Treant, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_01786` | Shen-Lu Elder Treant Juvenile | [[Regions/Shen-Lu\|Shen-Lu]] | Juvenile | A- | 132 | 10.2 m | Day & Night | Like a typical Elder Treant, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_01787` | Lumbaya Elder Treant Scarred | [[Regions/Lumbaya\|Lumbaya]] | Scarred | A+ | 159 | 13.2 m | Day & Night | Like a typical Elder Treant, but covered in old battle scars, with vivid tropical markings. |
| `pop_01788` | Everdusk Elder Treant Juvenile | [[Regions/Everdusk\|Everdusk]] | Juvenile | A- | 132 | 10.2 m | Day & Night | Like a typical Elder Treant, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_01789` | Lumbaya Elder Treant Elderborn | [[Regions/Lumbaya\|Lumbaya]] | Elderborn | S | 188 | 16.2 m | Day & Night | Like a typical Elder Treant, but old and wise, with greying features and a cautious hunting style, with vivid tropical markings. |

## Design recipe

Rig `rig_plant_walker` · mesh `plant_walker_base` · material `bark_leaf` · VFX `pollen_petals` · palette `#4caf50` `#a5d66f` `#3e2723` · real-animal silhouette with one fantasy exaggeration
