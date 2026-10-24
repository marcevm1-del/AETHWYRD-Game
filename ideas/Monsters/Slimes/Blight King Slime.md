---
type: monster
id: mon_blight_king_slime
family: "Slimes"
rank: "C+"
tier: variant
tags: [monster, slimes]
---
# Blight King Slime

![[mon_blight_king_slime_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_blight_king_slime_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Blight King Slime is a large creature with a dome-shaped gelatinous body, about 3 m tall. Its gel is weathered and natural, colored in bruise purple with sickly green. Guild sketches always show a crown made of smaller slimes fused together. It has alert animal eyes. Battle-worn plates and trophies hang from its body. It stalks low to the ground, surrounded by a low toxic haze that clings to the ground. This Poison-attuned variant carries one extra elemental feature, like crystal spikes, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Slimes|Slimes]] · Ooze |
| Variant of | [[Monsters/Slimes/King Slime\|King Slime]] (elemental) |
| Rank · level | C+ · 86 (76–96) |
| Menace | 2 · Wild |
| Element · weakness | Poison · Light |
| Size | 3 m |
| Behaviour | Passive (passive_wander) |
| HP · ATK · DEF · MATK · MDEF · SPD | 7346 · 283 · 212 · 212 · 212 · 110 |
| XP · gold | 3743 · 769 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/blob\|blob]] · `anim_blob` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] |
| Genre | Classic Fantasy |
| Trope | The cute first enemy (Dragon Quest) and the evolving hero (Tensura) |

**Field note:** Weak to Light. Leaves you alone unless attacked.

## Motion implementation

- **Rig:** [[Systems/Rigs/blob|blob]] (rigId); animation set `anim_blob`.
- **Dimensions:** 3 m high × 2.79 m long × 2.7 m wide; prefab scale 6.
- **Physics:** 14175 kg, gravity ×1.6, poise 89, knockback resistance 0.19, death style `splat_dissolve`.
- **Navigation:** speed 8.66 m/s, turn 208°/s, stopping distance 1.75 m.
- **Attack count:** 5; **signature:** a crown made of smaller slimes fused together.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Body Slam\|Body Slam]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Engulf\|Engulf]] | grab | 1.4 | 8 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Split\|Split]] | summon | 0 | 20 s | None | none | Interrupt or reposition; watch for added enemies. |
| [[Attacks/Acid Splash\|Acid Splash]] | ranged | 1.1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Venom Spit\|Venom Spit]] | magic | 1.5 | 10 s | Poison | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Blight King Slime is a **wild ooze** encountered at C+ rank, around level 86. Its documented behaviour is *Passive* and its AI pattern is *passive_wander*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a crown made of smaller slimes fused together. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_blob`, animation set `anim_blob`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Slimes C|loot_slime_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Slime Jelly\|Slime Jelly]] | 60% | 1–3 |
| [[Items/Gel Core\|Gel Core]] | 30% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 7 | C, C-, B+, B, C+, B- | 65–120 | Day & Night |
| [[Regions/Aldmere\|Aldmere]] | 4 | C+, B-, B+ | 86–120 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05846` | Great Labyrinth (Floors 41-90) Blight King Slime Juvenile | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Juvenile | C | 76 | 2.55 m | Day & Night | Like a typical Blight King Slime, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_05847` | Great Labyrinth (Floors 41-90) Blight King Slime Runt | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Runt | C- | 65 | 2.1 m | Day & Night | Like a typical Blight King Slime, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_05848` | Great Labyrinth (Floors 41-90) Blight King Slime Elderborn | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Elderborn | B+ | 120 | 4.05 m | Day & Night | Like a typical Blight King Slime, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_05849` | Aldmere Blight King Slime | [[Regions/Aldmere\|Aldmere]] | Adult | C+ | 86 | 3 m | Day & Night | A typical adult Blight King Slime of this region, with golden, grass-toned coloring. |
| `pop_05850` | Great Labyrinth (Floors 41-90) Blight King Slime Alpha | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Alpha | B | 108 | 3.75 m | Day & Night | Like a typical Blight King Slime, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_05851` | Great Labyrinth (Floors 41-90) Blight King Slime | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Adult | C+ | 86 | 3 m | Day & Night | A typical adult Blight King Slime of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_05852` | Aldmere Blight King Slime Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | B- | 96 | 3.3 m | Day & Night | Like a typical Blight King Slime, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_05853` | Aldmere Blight King Slime Albino | [[Regions/Aldmere\|Aldmere]] | Albino | B- | 96 | 3 m | Day & Night | Like a typical Blight King Slime, but a rare pale form with white skin or fur and red eyes. |
| `pop_05854` | Great Labyrinth (Floors 41-90) Blight King Slime Scarred | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Scarred | B- | 96 | 3.3 m | Day & Night | Like a typical Blight King Slime, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_05855` | Aldmere Blight King Slime Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | B+ | 120 | 4.05 m | Day & Night | Like a typical Blight King Slime, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_05856` | Great Labyrinth (Floors 41-90) Blight King Slime Albino | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Albino | B- | 96 | 3 m | Day & Night | Like a typical Blight King Slime, but a rare pale form with white skin or fur and red eyes. |

## Design recipe

Rig `rig_blob` · mesh `blob_base` · material `translucent_gel_sss` · VFX `toxic_fog` · palette `#8e44ad` `#b8e986` `#2d1b3d` · real-animal silhouette with one fantasy exaggeration
