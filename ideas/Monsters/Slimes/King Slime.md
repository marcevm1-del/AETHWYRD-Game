---
type: monster
id: mon_king_slime
family: "Slimes"
rank: "C"
tier: core
tags: [monster, slimes]
---
# King Slime

![[mon_king_slime_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_king_slime_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 20,000 tris · 3.353 × 3.22 × 3 m · local file `Game/Assets/_Game/Art/Models/Monsters/Slimes/mon_king_slime.fbx`

> The King Slime is a large creature with a wobbling mound of translucent gel, about 3 m tall. Its gel is weathered and natural, colored in deep blues with a glassy shine. Survivors describe a crown made of smaller slimes fused together. It has amber predator eyes. Battle-worn plates and trophies hang from its body. It prowls, surrounded by fine mist and droplets that orbit it.

| Field | Value |
|---|---|
| Family · type | [[Families/Slimes|Slimes]] · Ooze |
| Rank · level | C · 76 (65–86) |
| Menace | 2 · Wild |
| Element · weakness | Water · Lightning |
| Size | 3 m |
| Behaviour | Swarm (swarm_surround) |
| HP · ATK · DEF · MATK · MDEF · SPD | 6113 · 251 · 188 · 188 · 188 · 110 |
| XP · gold | 3073 · 648 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/blob\|blob]] · `anim_blob` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Strife Marches\|Strife Marches]], [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/Moraveil\|Moraveil]] |
| Genre | Classic Fantasy |
| Trope | The cute first enemy (Dragon Quest) and the evolving hero (Tensura) |

**Field note:** Weak to Lightning. Dangerous in numbers. Area attacks and chokepoints help.

## Motion implementation

- **Rig:** [[Systems/Rigs/blob|blob]] (rigId); animation set `anim_blob`.
- **Dimensions:** 3 m high × 2.79 m long × 2.7 m wide; prefab scale 6.
- **Physics:** 14883.8 kg, gravity ×1.6, poise 89, knockback resistance 0.19, death style `splat_dissolve`.
- **Navigation:** speed 9.87 m/s, turn 208°/s, stopping distance 1.75 m.
- **Attack count:** 5; **signature:** a crown made of smaller slimes fused together.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Body Slam\|Body Slam]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Engulf\|Engulf]] | grab | 1.4 | 8 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Split\|Split]] | summon | 0 | 20 s | None | none | Interrupt or reposition; watch for added enemies. |
| [[Attacks/Acid Splash\|Acid Splash]] | ranged | 1.1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Tide Lash\|Tide Lash]] | magic | 1.5 | 10 s | Water | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

King Slime is a **wild ooze** encountered at C rank, around level 76. Its documented behaviour is *Swarm* and its AI pattern is *swarm_surround*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Lightning**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a crown made of smaller slimes fused together. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Strife Marches|Strife Marches]], [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]], [[Regions/Moraveil|Moraveil]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_blob`, animation set `anim_blob`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Slimes C|loot_slime_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Slime Jelly\|Slime Jelly]] | 60% | 1–3 |
| [[Items/Gel Core\|Gel Core]] | 30% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Slimes/Deep King Slime|Deep King Slime]]
- [[Monsters/Slimes/Blight King Slime|Blight King Slime]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 4 | C-, D+, C+, C | 56–86 | Day & Night |
| [[Regions/Moraveil\|Moraveil]] | 3 | C-, C+ | 65–86 | Day & Night |
| [[Regions/Aldmere\|Aldmere]] | 2 | B, C- | 65–108 | Day & Night |
| [[Regions/Strife Marches\|Strife Marches]] | 2 | C+ | 86–86 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00100` | Great Labyrinth (Floors 41-90) King Slime Juvenile | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Juvenile | C- | 65 | 2.55 m | Day & Night | Like a typical King Slime, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_00101` | Moraveil King Slime Juvenile | [[Regions/Moraveil\|Moraveil]] | Juvenile | C- | 65 | 2.55 m | Day & Night | Like a typical King Slime, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_00102` | Aldmere King Slime Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | B | 108 | 4.05 m | Day & Night | Like a typical King Slime, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_00103` | Great Labyrinth (Floors 41-90) King Slime Runt | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Runt | D+ | 56 | 2.1 m | Day & Night | Like a typical King Slime, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_00104` | Great Labyrinth (Floors 41-90) King Slime Albino | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Albino | C+ | 86 | 3 m | Day & Night | Like a typical King Slime, but a rare pale form with white skin or fur and red eyes. |
| `pop_00105` | Great Labyrinth (Floors 41-90) King Slime | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Adult | C | 76 | 3 m | Day & Night | A typical adult King Slime of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_00106` | Strife Marches King Slime Scarred | [[Regions/Strife Marches\|Strife Marches]] | Scarred | C+ | 86 | 3.3 m | Day & Night | Like a typical King Slime, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_00107` | Moraveil King Slime Albino | [[Regions/Moraveil\|Moraveil]] | Albino | C+ | 86 | 3 m | Day & Night | Like a typical King Slime, but a rare pale form with white skin or fur and red eyes. |
| `pop_00108` | Aldmere King Slime Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | C- | 65 | 2.55 m | Day & Night | Like a typical King Slime, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_00109` | Moraveil King Slime Scarred | [[Regions/Moraveil\|Moraveil]] | Scarred | C+ | 86 | 3.3 m | Day & Night | Like a typical King Slime, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_00110` | Strife Marches King Slime Albino | [[Regions/Strife Marches\|Strife Marches]] | Albino | C+ | 86 | 3 m | Day & Night | Like a typical King Slime, but a rare pale form with white skin or fur and red eyes. |

## Design recipe

Rig `rig_blob` · mesh `blob_base` · material `translucent_gel_sss` · VFX `mist_droplets` · palette `#2f7fd1` `#9ad7ff` `#123a5c` · real-animal silhouette with one fantasy exaggeration
