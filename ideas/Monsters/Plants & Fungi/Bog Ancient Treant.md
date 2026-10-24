---
type: monster
id: mon_bog_ancient_treant
family: "Plants & Fungi"
rank: "S+"
tier: variant
tags: [monster, plants-fungi]
---
# Bog Ancient Treant

![[mon_bog_ancient_treant_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_bog_ancient_treant_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,052 tris · 21.418 × 15.522 × 30 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Bog Ancient Treant is a colossal creature with a tall, tree-like walking frame, about 30 m tall. Its bark and leaves are weathered and natural, colored in bruise purple with sickly green. Its most striking feature is a forest growing from its shoulders. It has amber predator eyes. Its regal silhouette is crowned by a halo-like ring of aura. It lopes in long strides, surrounded by a low toxic haze that clings to the ground. Adapted to swamp lands, it has mud-slick, algae-streaked skin.

| Field | Value |
|---|---|
| Family · type | [[Families/Plants & Fungi|Plants & Fungi]] · Plant |
| Variant of | [[Monsters/Plants & Fungi/Ancient Treant\|Ancient Treant]] (regional) |
| Rank · level | S+ · 203 (188–218) |
| Menace | 2 · Wild |
| Element · weakness | Poison · Light |
| Size | 30 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 72516 · 1028 · 740 · 740 · 740 · 100 |
| XP · gold | 14769 · 2553 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/plant_rooted\|plant_rooted]] · `anim_plant_walker` |
| Habitats | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] |
| Genre | Fairy-tale Forest |
| Trope | Screaming mandrakes, walking mushrooms and ancient treants |

**Field note:** Weak to Light. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/plant_rooted|plant_rooted]] (keyword); animation set `anim_plant_walker`.
- **Dimensions:** 30 m high × 12 m long × 36 m wide; prefab scale 15.
- **Physics:** 567000 kg, gravity ×1, poise 6932, knockback resistance 1, death style `wilt_collapse`.
- **Navigation:** speed 1.66 m/s, turn 60°/s, stopping distance 4 m.
- **Attack count:** 5; **signature:** a forest growing from its shoulders.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Branch Sweep\|Branch Sweep]] | melee | 1.1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Root Slam\|Root Slam]] | aoe | 1.5 | 9 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Regrow\|Regrow]] | heal | 0 | 20 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Root Bind\|Root Bind]] | grab | 1 | 11 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Venom Spit\|Venom Spit]] | magic | 1.5 | 10 s | Poison | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Bog Ancient Treant is a **wild plant** encountered at S+ rank, around level 203. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a forest growing from its shoulders. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]], [[Regions/Great Labyrinth (Floors 91-120)|Great Labyrinth (Floors 91-120)]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_plant_walker`, animation set `anim_plant_walker`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Plants & Fungi S|loot_plant_s]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Sap\|Sap]] | 60% | 1–3 |
| [[Items/Seed\|Seed]] | 30% | 1–1 |
| [[Items/Spore Cap\|Spore Cap]] | 15% | 1–1 |
| [[Items/S-Rank Monster Core\|S-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 6 | S-, S, SS-, SS+, S+ | 173–253 | Day & Night |
| [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | 5 | SS, SS-, S, S+ | 188–236 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04667` | Great Labyrinth (Floors 41-90) Bog Ancient Treant Runt | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Runt | S- | 173 | 21 m | Day & Night | Like a typical Bog Ancient Treant, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_04668` | Great Labyrinth (Floors 91-120) Bog Ancient Treant Alpha | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Alpha | SS | 236 | 37.5 m | Day & Night | Like a typical Bog Ancient Treant, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_04669` | Great Labyrinth (Floors 91-120) Bog Ancient Treant Scarred | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Scarred | SS- | 218 | 33 m | Day & Night | Like a typical Bog Ancient Treant, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_04670` | Great Labyrinth (Floors 91-120) Bog Ancient Treant Juvenile | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Juvenile | S | 188 | 25.5 m | Day & Night | Like a typical Bog Ancient Treant, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_04671` | Great Labyrinth (Floors 91-120) Bog Ancient Treant Albino | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Albino | SS- | 218 | 30 m | Day & Night | Like a typical Bog Ancient Treant, but a rare pale form with white skin or fur and red eyes. |
| `pop_04672` | Great Labyrinth (Floors 41-90) Bog Ancient Treant Juvenile | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Juvenile | S | 188 | 25.5 m | Day & Night | Like a typical Bog Ancient Treant, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_04673` | Great Labyrinth (Floors 91-120) Bog Ancient Treant | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Adult | S+ | 203 | 30 m | Day & Night | A typical adult Bog Ancient Treant of this region, with dust-grey coloring and old rune scars. |
| `pop_04674` | Great Labyrinth (Floors 41-90) Bog Ancient Treant Albino | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Albino | SS- | 218 | 30 m | Day & Night | Like a typical Bog Ancient Treant, but a rare pale form with white skin or fur and red eyes. |
| `pop_04675` | Great Labyrinth (Floors 41-90) Bog Ancient Treant Elderborn | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Elderborn | SS+ | 253 | 40.5 m | Day & Night | Like a typical Bog Ancient Treant, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_04676` | Great Labyrinth (Floors 41-90) Bog Ancient Treant Scarred | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Scarred | SS- | 218 | 33 m | Day & Night | Like a typical Bog Ancient Treant, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_04677` | Great Labyrinth (Floors 41-90) Bog Ancient Treant | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Adult | S+ | 203 | 30 m | Day & Night | A typical adult Bog Ancient Treant of this region, with dust-grey coloring and old rune scars. |

## Design recipe

Rig `rig_plant_walker` · mesh `plant_walker_base` · material `bark_leaf` · VFX `toxic_fog` · palette `#8e44ad` `#b8e986` `#2d1b3d` · real-animal silhouette with one fantasy exaggeration
