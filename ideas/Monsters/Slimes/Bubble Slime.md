---
type: monster
id: mon_bubble_slime
family: "Slimes"
rank: "E"
tier: core
tags: [monster, slimes]
---
# Bubble Slime

> The Bubble Slime is a tiny creature with a teardrop-shaped jelly body, about 0.3 m tall. Its gel is smooth and clean, colored in deep blues with a glassy shine. Its most striking feature is a cluster of soap-bright spheres that split apart when hit. It has wide curious eyes with star-shaped highlights. Small scars and rough edges mark it as a survivor. It bounces happily, surrounded by fine mist and droplets that orbit it.

| Field | Value |
|---|---|
| Family · type | [[Families/Slimes|Slimes]] · Ooze |
| Rank · level | E · 26 (19–32) |
| Menace | 1 · Charming |
| Element · weakness | Water · Lightning |
| Size | 0.3 m |
| Behaviour | Passive (passive_wander) |
| HP · ATK · DEF · MATK · MDEF · SPD | 632 · 91 · 68 · 68 · 68 · 110 |
| XP · gold | 559 · 147 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/blob\|blob]] · `anim_blob` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Greymoor\|Greymoor]] |
| Genre | Classic Fantasy |
| Trope | The cute first enemy (Dragon Quest) and the evolving hero (Tensura) |

**Field note:** Weak to Lightning. Leaves you alone unless attacked.

## Motion implementation

- **Rig:** [[Systems/Rigs/blob|blob]] (rigId); animation set `anim_blob`.
- **Dimensions:** 0.3 m high × 0.28 m long × 0.27 m wide; prefab scale 0.6.
- **Physics:** 14.9 kg, gravity ×1.6, poise 22, knockback resistance 0.13, death style `splat_dissolve`.
- **Navigation:** speed 2.54 m/s, turn 657°/s, stopping distance 0.54 m.
- **Attack count:** 5; **signature:** a cluster of soap-bright spheres that split apart when hit.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Body Slam\|Body Slam]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Engulf\|Engulf]] | grab | 1.4 | 8 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Split\|Split]] | summon | 0 | 20 s | None | none | Interrupt or reposition; watch for added enemies. |
| [[Attacks/Acid Splash\|Acid Splash]] | ranged | 1.1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Tide Lash\|Tide Lash]] | magic | 1.5 | 10 s | Water | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Bubble Slime is a **charming ooze** encountered at E rank, around level 26. Its documented behaviour is *Passive* and its AI pattern is *passive_wander*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Lightning**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a cluster of soap-bright spheres that split apart when hit. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Greymoor|Greymoor]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_blob`, animation set `anim_blob`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Slimes E|loot_slime_e]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Slime Jelly\|Slime Jelly]] | 60% | 1–3 |
| [[Items/Gel Core\|Gel Core]] | 30% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Slimes/Greater Bubble Slime|Greater Bubble Slime]]
- [[Monsters/Slimes/Ash Slime|Ash Slime]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 3 | D, E-, E+ | 19–48 | Day |
| [[Regions/Aldmere\|Aldmere]] | 4 | E-, E, E+, D- | 19–40 | Day |
| [[Regions/Greymoor\|Greymoor]] | 4 | E+, E, F+, D | 13–48 | Day |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00045` | Great Labyrinth (Floors 1-40) Bubble Slime Elderborn | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Elderborn | D | 48 | 0.41 m | Day | Like a typical Bubble Slime, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_00046` | Aldmere Bubble Slime Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | E- | 19 | 0.26 m | Day | Like a typical Bubble Slime, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_00047` | Greymoor Bubble Slime Scarred | [[Regions/Greymoor\|Greymoor]] | Scarred | E+ | 32 | 0.33 m | Day | Like a typical Bubble Slime, but covered in old battle scars, with mud-slick, algae-streaked skin. |
| `pop_00048` | Greymoor Bubble Slime | [[Regions/Greymoor\|Greymoor]] | Adult | E | 26 | 0.3 m | Day | A typical adult Bubble Slime of this region, with mud-slick, algae-streaked skin. |
| `pop_00049` | Great Labyrinth (Floors 1-40) Bubble Slime Juvenile | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Juvenile | E- | 19 | 0.26 m | Day | Like a typical Bubble Slime, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_00050` | Aldmere Bubble Slime | [[Regions/Aldmere\|Aldmere]] | Adult | E | 26 | 0.3 m | Day | A typical adult Bubble Slime of this region, with golden, grass-toned coloring. |
| `pop_00051` | Aldmere Bubble Slime Albino | [[Regions/Aldmere\|Aldmere]] | Albino | E+ | 32 | 0.3 m | Day | Like a typical Bubble Slime, but a rare pale form with white skin or fur and red eyes. |
| `pop_00052` | Great Labyrinth (Floors 1-40) Bubble Slime Albino | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Albino | E+ | 32 | 0.3 m | Day | Like a typical Bubble Slime, but a rare pale form with white skin or fur and red eyes. |
| `pop_00053` | Greymoor Bubble Slime Runt | [[Regions/Greymoor\|Greymoor]] | Runt | F+ | 13 | 0.21 m | Day | Like a typical Bubble Slime, but smaller and scrappier than usual, with mud-slick, algae-streaked skin. |
| `pop_00054` | Greymoor Bubble Slime Elderborn | [[Regions/Greymoor\|Greymoor]] | Elderborn | D | 48 | 0.41 m | Day | Like a typical Bubble Slime, but old and wise, with greying features and a cautious hunting style, with mud-slick, algae-streaked skin. |
| `pop_00055` | Aldmere Bubble Slime Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | D- | 40 | 0.38 m | Day | Like a typical Bubble Slime, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |

## Design recipe

Rig `rig_blob` · mesh `blob_base` · material `translucent_gel_sss` · VFX `mist_droplets` · palette `#2f7fd1` `#9ad7ff` `#123a5c` · circle-based, soft silhouette
