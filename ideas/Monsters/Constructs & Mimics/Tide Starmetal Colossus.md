---
type: monster
id: mon_tide_starmetal_colossus
family: "Constructs & Mimics"
rank: "SSS+"
tier: variant
tags: [monster, constructs-mimics]
---
# Tide Starmetal Colossus

![[mon_tide_starmetal_colossus_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_tide_starmetal_colossus_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Tide Starmetal Colossus is a colossal creature with a towering machine-like frame, about 120 m tall. Its surface is weathered and natural, colored in deep blues with a glassy shine. Its most striking feature is a starmetal body that hums with Titan songs. It has amber predator eyes. Its outline is crowned by slowly turning rings of light; lesser monsters flee from it. It lopes in long strides, surrounded by fine mist and droplets that orbit it. This Water-attuned variant carries one extra elemental feature, like a crest of elemental energy, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Constructs & Mimics|Constructs & Mimics]] · Construct |
| Variant of | [[Monsters/Constructs & Mimics/Starmetal Colossus\|Starmetal Colossus]] (elemental) |
| Rank · level | SSS+ · 294 (281–300) |
| Menace | 2 · Wild |
| Element · weakness | Water · Lightning |
| Size | 120 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 222604 · 1186 · 1779 · 712 · 1186 · 70 |
| XP · gold | 26706 · 4286 |
| Ring | 9 |
| Rig · animation | [[Systems/Rigs/golem\|golem]] · `anim_golem` |
| Habitats | [[Regions/Vesper\|Vesper]], [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] |
| Genre | Ancient Ruins |
| Trope | Treasure-chest mimics and ancient guardian golems |

**Field note:** Weak to Lightning. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/golem|golem]] (rigId); animation set `anim_golem`.
- **Dimensions:** 120 m high × 36 m long × 50.4 m wide; prefab scale 40.
- **Physics:** 87091200 kg, gravity ×1.2, poise 2783, knockback resistance 1, death style `crumble_into_rubble`.
- **Navigation:** speed 19.89 m/s, turn 60°/s, stopping distance 12.4 m.
- **Attack count:** 5; **signature:** a starmetal body that hums with Titan songs.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slam\|Slam]] | melee | 1.4 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Ground Pound\|Ground Pound]] | aoe | 1.8 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Stance\|Guard Stance]] | buff | 0 | 15 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Rune Pulse\|Rune Pulse]] | magic | 1.3 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Tide Lash\|Tide Lash]] | magic | 1.5 | 10 s | Water | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Tide Starmetal Colossus is a **wild construct** encountered at SSS+ rank, around level 294. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Lightning**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a starmetal body that hums with Titan songs. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Vesper|Vesper]], [[Regions/Great Labyrinth (Floors 91-120)|Great Labyrinth (Floors 91-120)]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_golem`, animation set `anim_golem`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Constructs & Mimics SSS|loot_construct_sss]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Golem Core\|Golem Core]] | 60% | 1–3 |
| [[Items/Rune Plate\|Rune Plate]] | 30% | 1–1 |
| [[Items/Gear\|Gear]] | 15% | 1–1 |
| [[Items/SSS-Rank Monster Core\|SSS-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | 6 | EX, SSS, EX-, SSS-, SSS+, EX+ | 267–300 | Day & Night |
| [[Regions/Vesper\|Vesper]] | 5 | SSS, EX-, SSS-, EX+, SSS+ | 267–300 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04440` | Great Labyrinth (Floors 91-120) Tide Starmetal Colossus Alpha | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Alpha | EX | 300 | 150 m | Day & Night | Like a typical Tide Starmetal Colossus, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_04441` | Vesper Tide Starmetal Colossus Juvenile | [[Regions/Vesper\|Vesper]] | Juvenile | SSS | 281 | 102 m | Day & Night | Like a typical Tide Starmetal Colossus, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_04442` | Vesper Tide Starmetal Colossus Albino | [[Regions/Vesper\|Vesper]] | Albino | EX- | 300 | 120 m | Day & Night | Like a typical Tide Starmetal Colossus, but a rare pale form with white skin or fur and red eyes. |
| `pop_04443` | Great Labyrinth (Floors 91-120) Tide Starmetal Colossus Juvenile | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Juvenile | SSS | 281 | 102 m | Day & Night | Like a typical Tide Starmetal Colossus, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_04444` | Vesper Tide Starmetal Colossus Runt | [[Regions/Vesper\|Vesper]] | Runt | SSS- | 267 | 84 m | Day & Night | Like a typical Tide Starmetal Colossus, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_04445` | Vesper Tide Starmetal Colossus Elderborn | [[Regions/Vesper\|Vesper]] | Elderborn | EX+ | 300 | 162 m | Day & Night | Like a typical Tide Starmetal Colossus, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_04446` | Great Labyrinth (Floors 91-120) Tide Starmetal Colossus Albino | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Albino | EX- | 300 | 120 m | Day & Night | Like a typical Tide Starmetal Colossus, but a rare pale form with white skin or fur and red eyes. |
| `pop_04447` | Great Labyrinth (Floors 91-120) Tide Starmetal Colossus Runt | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Runt | SSS- | 267 | 84 m | Day & Night | Like a typical Tide Starmetal Colossus, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_04448` | Vesper Tide Starmetal Colossus | [[Regions/Vesper\|Vesper]] | Adult | SSS+ | 294 | 120 m | Day & Night | A typical adult Tide Starmetal Colossus of this region, with dust-grey coloring and old rune scars. |
| `pop_04449` | Great Labyrinth (Floors 91-120) Tide Starmetal Colossus | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Adult | SSS+ | 294 | 120 m | Day & Night | A typical adult Tide Starmetal Colossus of this region, with dust-grey coloring and old rune scars. |
| `pop_04450` | Great Labyrinth (Floors 91-120) Tide Starmetal Colossus Elderborn | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Elderborn | EX+ | 300 | 162 m | Day & Night | Like a typical Tide Starmetal Colossus, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |

## Design recipe

Rig `rig_golem` · mesh `golem_base` · material `stone_metal_runes` · VFX `mist_droplets` · palette `#2f7fd1` `#9ad7ff` `#123a5c` · real-animal silhouette with one fantasy exaggeration
