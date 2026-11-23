---
type: monster
id: mon_greater_bubble_slime
family: "Slimes"
rank: "D"
tier: variant
tags: [monster, slimes]
---
# Greater Bubble Slime

![[mon_greater_bubble_slime_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_greater_bubble_slime_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 5,992 tris · 0.569 × 0.547 × 0.5 m · local file `Game/Assets/_Game/Art/Models/Monsters/Slimes/mon_greater_bubble_slime.fbx`

> The Greater Bubble Slime is a small creature with a teardrop-shaped jelly body, about 0.5 m tall. Its gel is smooth and clean, colored in deep blues with a glassy shine. Look for a cluster of soap-bright spheres that split apart when hit. It has big round glossy eyes. A distinctive marking runs along its back. It waddles, surrounded by fine mist and droplets that orbit it. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Slimes|Slimes]] · Ooze |
| Variant of | [[Monsters/Slimes/Bubble Slime\|Bubble Slime]] (elder) |
| Rank · level | D · 48 (40–56) |
| Menace | 1 · Charming |
| Element · weakness | Water · Lightning |
| Size | 0.5 m |
| Behaviour | Swarm (swarm_surround) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1738 · 162 · 121 · 121 · 121 · 110 |
| XP · gold | 1477 · 342 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/blob\|blob]] · `anim_blob` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] |
| Genre | Classic Fantasy |
| Trope | The cute first enemy (Dragon Quest) and the evolving hero (Tensura) |

**Field note:** Weak to Lightning. Dangerous in numbers. Area attacks and chokepoints help.

## Motion implementation

- **Rig:** [[Systems/Rigs/blob|blob]] (rigId); animation set `anim_blob`.
- **Dimensions:** 0.5 m high × 0.47 m long × 0.45 m wide; prefab scale 1.
- **Physics:** 68.9 kg, gravity ×1.6, poise 33, knockback resistance 0.16, death style `splat_dissolve`.
- **Navigation:** speed 3.63 m/s, turn 509°/s, stopping distance 0.63 m.
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

Greater Bubble Slime is a **charming ooze** encountered at D rank, around level 48. Its documented behaviour is *Swarm* and its AI pattern is *swarm_surround*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Lightning**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a cluster of soap-bright spheres that split apart when hit. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_blob`, animation set `anim_blob`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Slimes D|loot_slime_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Slime Jelly\|Slime Jelly]] | 60% | 1–3 |
| [[Items/Gel Core\|Gel Core]] | 30% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 7 | D+, C-, D-, C, D, E+ | 32–76 | Day |
| [[Regions/Aldmere\|Aldmere]] | 4 | C, D, D-, D+ | 40–76 | Day |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02950` | Great Labyrinth (Floors 1-40) Greater Bubble Slime Albino | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Albino | D+ | 56 | 0.5 m | Day | Like a typical Greater Bubble Slime, but a rare pale form with white skin or fur and red eyes. |
| `pop_02951` | Great Labyrinth (Floors 1-40) Greater Bubble Slime Scarred | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Scarred | D+ | 56 | 0.55 m | Day | Like a typical Greater Bubble Slime, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_02952` | Aldmere Greater Bubble Slime Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | C | 76 | 0.68 m | Day | Like a typical Greater Bubble Slime, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_02953` | Great Labyrinth (Floors 1-40) Greater Bubble Slime Alpha | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Alpha | C- | 65 | 0.63 m | Day | Like a typical Greater Bubble Slime, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_02954` | Great Labyrinth (Floors 1-40) Greater Bubble Slime Juvenile | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Juvenile | D- | 40 | 0.42 m | Day | Like a typical Greater Bubble Slime, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_02955` | Aldmere Greater Bubble Slime | [[Regions/Aldmere\|Aldmere]] | Adult | D | 48 | 0.5 m | Day | A typical adult Greater Bubble Slime of this region, with golden, grass-toned coloring. |
| `pop_02956` | Great Labyrinth (Floors 1-40) Greater Bubble Slime Elderborn | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Elderborn | C | 76 | 0.68 m | Day | Like a typical Greater Bubble Slime, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_02957` | Great Labyrinth (Floors 1-40) Greater Bubble Slime | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Adult | D | 48 | 0.5 m | Day | A typical adult Greater Bubble Slime of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_02958` | Aldmere Greater Bubble Slime Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | D- | 40 | 0.42 m | Day | Like a typical Greater Bubble Slime, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_02959` | Aldmere Greater Bubble Slime Albino | [[Regions/Aldmere\|Aldmere]] | Albino | D+ | 56 | 0.5 m | Day | Like a typical Greater Bubble Slime, but a rare pale form with white skin or fur and red eyes. |
| `pop_02960` | Great Labyrinth (Floors 1-40) Greater Bubble Slime Runt | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Runt | E+ | 32 | 0.35 m | Day | Like a typical Greater Bubble Slime, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |

## Design recipe

Rig `rig_blob` · mesh `blob_base` · material `translucent_gel_sss` · VFX `mist_droplets` · palette `#2f7fd1` `#9ad7ff` `#123a5c` · circle-based, soft silhouette
