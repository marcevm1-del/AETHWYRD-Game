---
type: monster
id: mon_thunder_worldroot_behemoth
family: "Plants & Fungi"
rank: "SSS+"
tier: variant
tags: [monster, plants-fungi]
---
# Thunder Worldroot Behemoth

![[mon_thunder_worldroot_behemoth_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_thunder_worldroot_behemoth_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Thunder Worldroot Behemoth is a colossal creature with a walking body of bark and root, about 80 m tall. Its bark and leaves are rough, scarred and spiked, colored in storm violet shot through with electric yellow. Survivors describe a walking forest with a glowing heartwood core. It has burning slit pupils. Its outline is crowned by slowly turning rings of light; lesser monsters flee from it. It charges without hesitation, surrounded by crackling arcs that jump across its body. This Lightning-attuned variant carries one extra elemental feature, like a crest of elemental energy, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Plants & Fungi|Plants & Fungi]] · Plant |
| Variant of | [[Monsters/Plants & Fungi/Worldroot Behemoth\|Worldroot Behemoth]] (elemental) |
| Rank · level | SSS+ · 294 (281–300) |
| Menace | 3 · Menacing |
| Element · weakness | Lightning · Earth |
| Size | 80 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 154593 · 1483 · 1067 · 1067 · 1067 · 100 |
| XP · gold | 26706 · 4286 |
| Ring | 9 |
| Rig · animation | [[Systems/Rigs/plant_rooted\|plant_rooted]] · `anim_plant_walker` |
| Habitats | [[Regions/Nox Dominion\|Nox Dominion]], [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] |
| Genre | Fairy-tale Forest |
| Trope | Screaming mandrakes, walking mushrooms and ancient treants |

**Field note:** Weak to Earth. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/plant_rooted|plant_rooted]] (keyword); animation set `anim_plant_walker`.
- **Dimensions:** 80 m high × 32 m long × 96 m wide; prefab scale 40.
- **Physics:** 10752000 kg, gravity ×1, poise 36691, knockback resistance 1, death style `wilt_collapse`.
- **Navigation:** speed 3.18 m/s, turn 60°/s, stopping distance 10 m.
- **Attack count:** 5; **signature:** a walking forest with a glowing heartwood core.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Branch Sweep\|Branch Sweep]] | melee | 1.1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Root Slam\|Root Slam]] | aoe | 1.5 | 9 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Regrow\|Regrow]] | heal | 0 | 20 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Root Bind\|Root Bind]] | grab | 1 | 11 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Static Arc\|Static Arc]] | magic | 1.5 | 10 s | Lightning | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Thunder Worldroot Behemoth is a **menacing plant** encountered at SSS+ rank, around level 294. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Earth**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a walking forest with a glowing heartwood core. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Nox Dominion|Nox Dominion]], [[Regions/Great Labyrinth (Floors 91-120)|Great Labyrinth (Floors 91-120)]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_plant_walker`, animation set `anim_plant_walker`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Plants & Fungi SSS|loot_plant_sss]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Sap\|Sap]] | 60% | 1–3 |
| [[Items/Seed\|Seed]] | 30% | 1–1 |
| [[Items/Spore Cap\|Spore Cap]] | 15% | 1–1 |
| [[Items/SSS-Rank Monster Core\|SSS-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | 6 | EX+, SSS-, EX, EX-, SSS | 267–300 | Day & Night |
| [[Regions/Nox Dominion\|Nox Dominion]] | 5 | EX-, EX, SSS, EX+, SSS+ | 281–300 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04678` | Great Labyrinth (Floors 91-120) Thunder Worldroot Behemoth Elderborn | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Elderborn | EX+ | 300 | 108 m | Day & Night | Like a typical Thunder Worldroot Behemoth, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_04679` | Great Labyrinth (Floors 91-120) Thunder Worldroot Behemoth Runt | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Runt | SSS- | 267 | 56 m | Day & Night | Like a typical Thunder Worldroot Behemoth, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_04680` | Nox Dominion Thunder Worldroot Behemoth Scarred | [[Regions/Nox Dominion\|Nox Dominion]] | Scarred | EX- | 300 | 88 m | Day & Night | Like a typical Thunder Worldroot Behemoth, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_04681` | Great Labyrinth (Floors 91-120) Thunder Worldroot Behemoth Alpha | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Alpha | EX | 300 | 100 m | Day & Night | Like a typical Thunder Worldroot Behemoth, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_04682` | Great Labyrinth (Floors 91-120) Thunder Worldroot Behemoth Albino | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Albino | EX- | 300 | 80 m | Day & Night | Like a typical Thunder Worldroot Behemoth, but a rare pale form with white skin or fur and red eyes. |
| `pop_04683` | Nox Dominion Thunder Worldroot Behemoth Alpha | [[Regions/Nox Dominion\|Nox Dominion]] | Alpha | EX | 300 | 100 m | Day & Night | Like a typical Thunder Worldroot Behemoth, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_04684` | Nox Dominion Thunder Worldroot Behemoth Juvenile | [[Regions/Nox Dominion\|Nox Dominion]] | Juvenile | SSS | 281 | 68 m | Day & Night | Like a typical Thunder Worldroot Behemoth, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_04685` | Nox Dominion Thunder Worldroot Behemoth Elderborn | [[Regions/Nox Dominion\|Nox Dominion]] | Elderborn | EX+ | 300 | 108 m | Day & Night | Like a typical Thunder Worldroot Behemoth, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_04686` | Great Labyrinth (Floors 91-120) Thunder Worldroot Behemoth Juvenile | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Juvenile | SSS | 281 | 68 m | Day & Night | Like a typical Thunder Worldroot Behemoth, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_04687` | Nox Dominion Thunder Worldroot Behemoth | [[Regions/Nox Dominion\|Nox Dominion]] | Adult | SSS+ | 294 | 80 m | Day & Night | A typical adult Thunder Worldroot Behemoth of this region, with dust-grey coloring and old rune scars. |
| `pop_04688` | Great Labyrinth (Floors 91-120) Thunder Worldroot Behemoth Scarred | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Scarred | EX- | 300 | 88 m | Day & Night | Like a typical Thunder Worldroot Behemoth, but covered in old battle scars, with dust-grey coloring and old rune scars. |

## Design recipe

Rig `rig_plant_walker` · mesh `plant_walker_base` · material `bark_leaf` · VFX `arc_sparks` · palette `#ffe14d` `#6c5ce7` `#1b1b3a` · triangle-based silhouette, sharp asymmetric spikes
