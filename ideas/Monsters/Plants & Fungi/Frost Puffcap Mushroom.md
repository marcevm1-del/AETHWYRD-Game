---
type: monster
id: mon_frost_puffcap_mushroom
family: "Plants & Fungi"
rank: "F+"
tier: variant
tags: [monster, plants-fungi]
---
# Frost Puffcap Mushroom

![[mon_frost_puffcap_mushroom_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_frost_puffcap_mushroom_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,552 tris · 0.403 × 0.294 × 0.5 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Frost Puffcap Mushroom is a small creature with a mushroom-capped walking body, about 0.5 m tall. Its bark and leaves are smooth and clean, colored in pale blues and frost-white. Its most striking feature is a spotted cap that sneezes giggle-spores. It has wide curious eyes with star-shaped highlights. It has no ornament at all: simple, readable shapes. It bounces happily, surrounded by falling snow motes and frosted ground where it steps. This Ice-attuned variant carries one extra elemental feature, like element-scarred hide, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Plants & Fungi|Plants & Fungi]] · Plant |
| Variant of | [[Monsters/Plants & Fungi/Puffcap Mushroom\|Puffcap Mushroom]] (elemental) |
| Rank · level | F+ · 13 (8–19) |
| Menace | 1 · Charming |
| Element · weakness | Ice · Fire |
| Size | 0.5 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 392 · 78 · 56 · 56 · 56 · 100 |
| XP · gold | 190 · 57 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/stub_biped\|stub_biped]] · `anim_plant_walker` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] |
| Genre | Fairy-tale Forest |
| Trope | Screaming mandrakes, walking mushrooms and ancient treants |

**Field note:** Weak to Fire. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/stub_biped|stub_biped]] (override (base species)); animation set `anim_plant_walker`.
- **Dimensions:** 0.5 m high × 0.42 m long × 0.42 m wide; prefab scale 1.
- **Physics:** 24.1 kg, gravity ×1.58, poise 28, knockback resistance 0.05, death style `topple_puff`.
- **Navigation:** speed 1.63 m/s, turn 424°/s, stopping distance 0.55 m.
- **Attack count:** 5; **signature:** a spotted cap that sneezes giggle-spores.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Branch Sweep\|Branch Sweep]] | melee | 1.1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Root Slam\|Root Slam]] | aoe | 1.5 | 9 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Regrow\|Regrow]] | heal | 0 | 20 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Root Bind\|Root Bind]] | grab | 1 | 11 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Frost Breath\|Frost Breath]] | magic | 1.5 | 10 s | Ice | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Frost Puffcap Mushroom is a **charming plant** encountered at F+ rank, around level 13. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a spotted cap that sneezes giggle-spores. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Whisperwood|Whisperwood]], [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_plant_walker`, animation set `anim_plant_walker`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Plants & Fungi F|loot_plant_f]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Sap\|Sap]] | 60% | 1–3 |
| [[Items/Seed\|Seed]] | 30% | 1–1 |
| [[Items/Spore Cap\|Spore Cap]] | 15% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 4 | E+, F-, E-, E | 3–32 | Day |
| [[Regions/Aldmere\|Aldmere]] | 4 | E-, F-, E+ | 3–32 | Day |
| [[Regions/Whisperwood\|Whisperwood]] | 3 | E-, E, F- | 3–26 | Day |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04579` | Great Labyrinth (Floors 1-40) Frost Puffcap Mushroom Elderborn | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Elderborn | E+ | 32 | 0.68 m | Day | Like a typical Frost Puffcap Mushroom, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_04580` | Aldmere Frost Puffcap Mushroom Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | E- | 19 | 0.55 m | Day | Like a typical Frost Puffcap Mushroom, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_04581` | Great Labyrinth (Floors 1-40) Frost Puffcap Mushroom Runt | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Runt | F- | 3 | 0.35 m | Day | Like a typical Frost Puffcap Mushroom, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_04582` | Aldmere Frost Puffcap Mushroom Albino | [[Regions/Aldmere\|Aldmere]] | Albino | E- | 19 | 0.5 m | Day | Like a typical Frost Puffcap Mushroom, but a rare pale form with white skin or fur and red eyes. |
| `pop_04583` | Whisperwood Frost Puffcap Mushroom Scarred | [[Regions/Whisperwood\|Whisperwood]] | Scarred | E- | 19 | 0.55 m | Day | Like a typical Frost Puffcap Mushroom, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_04584` | Whisperwood Frost Puffcap Mushroom Alpha | [[Regions/Whisperwood\|Whisperwood]] | Alpha | E | 26 | 0.63 m | Day | Like a typical Frost Puffcap Mushroom, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_04585` | Great Labyrinth (Floors 1-40) Frost Puffcap Mushroom Scarred | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Scarred | E- | 19 | 0.55 m | Day | Like a typical Frost Puffcap Mushroom, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_04586` | Aldmere Frost Puffcap Mushroom Runt | [[Regions/Aldmere\|Aldmere]] | Runt | F- | 3 | 0.35 m | Day | Like a typical Frost Puffcap Mushroom, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_04587` | Whisperwood Frost Puffcap Mushroom Runt | [[Regions/Whisperwood\|Whisperwood]] | Runt | F- | 3 | 0.35 m | Day | Like a typical Frost Puffcap Mushroom, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_04588` | Great Labyrinth (Floors 1-40) Frost Puffcap Mushroom Alpha | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Alpha | E | 26 | 0.63 m | Day | Like a typical Frost Puffcap Mushroom, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_04589` | Aldmere Frost Puffcap Mushroom Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | E+ | 32 | 0.68 m | Day | Like a typical Frost Puffcap Mushroom, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_plant_walker` · mesh `plant_walker_base` · material `bark_leaf` · VFX `frost_trail_snow` · palette `#bfe9ff` `#5fa8d3` `#f4fbff` · circle-based, soft silhouette
