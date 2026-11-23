---
type: monster
id: mon_troll
family: "Orcs, Ogres & Giants"
rank: "C+"
tier: core
tags: [monster, orcs-ogres-giants]
---
# Troll

![[mon_troll_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_troll_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 19,998 tris · 3.119 × 1.889 × 3.201 m · local file `Game/Assets/_Game/Art/Models/Monsters/Orcs, Ogres & Giants/mon_troll.fbx`

> The Troll is a large creature with a massive hunched brute frame, about 3.2 m tall. Its hide is rough, scarred and spiked, colored in stone-grey, with leaf-green markings. Guild sketches always show moss-covered skin that knits itself back together. It has eyes that catch torchlight like coins. Battle-worn plates and trophies hang from its body. It circles its prey, surrounded by drifting pollen and tiny blossoms.

| Field | Value |
|---|---|
| Family · type | [[Families/Orcs, Ogres & Giants|Orcs, Ogres & Giants]] · Giant |
| Rank · level | C+ · 86 (76–96) |
| Menace | 3 · Menacing |
| Element · weakness | Nature · Fire |
| Size | 3.2 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 15014 · 354 · 531 · 212 · 354 · 70 |
| XP · gold | 3743 · 769 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/large_biped\|large_biped]] · `anim_large_biped` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Strife Marches\|Strife Marches]], [[Regions/Moraveil\|Moraveil]] |
| Genre | Classic Fantasy |
| Trope | Orc warbands and the Orc Disaster that devours its way to power (Tensura) |

**Field note:** Weak to Fire. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/large_biped|large_biped]] (rigId); animation set `anim_large_biped`.
- **Dimensions:** 3.2 m high × 0.96 m long × 1.34 m wide; prefab scale 0.914.
- **Physics:** 589.8 kg, gravity ×1.3, poise 194, knockback resistance 0.84, death style `heavy_fall_dust`.
- **Navigation:** speed 6.62 m/s, turn 212°/s, stopping distance 1.04 m.
- **Attack count:** 5; **signature:** moss-covered skin that knits itself back together.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stomp\|Stomp]] | aoe | 1.3 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Club Slam\|Club Slam]] | melee | 1.8 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Grab and Throw\|Grab and Throw]] | grab | 2 | 14 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/War Cry\|War Cry]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Thorn Volley\|Thorn Volley]] | magic | 1.5 | 10 s | Nature | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Troll is a **menacing giant** encountered at C+ rank, around level 86. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** moss-covered skin that knits itself back together. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Strife Marches|Strife Marches]], [[Regions/Moraveil|Moraveil]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_large_biped`, animation set `anim_large_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Orcs, Ogres & Giants C|loot_orc_giant_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Tusk\|Tusk]] | 60% | 1–3 |
| [[Items/Giant's Hide\|Giant's Hide]] | 30% | 1–1 |
| [[Items/Crude Iron\|Crude Iron]] | 15% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Orcs, Ogres & Giants/Cinder Troll|Cinder Troll]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Aldmere\|Aldmere]] | 3 | C, B-, B+ | 76–120 | Day & Night |
| [[Regions/Strife Marches\|Strife Marches]] | 4 | C-, B-, C+, C | 65–96 | Day & Night |
| [[Regions/Moraveil\|Moraveil]] | 4 | C-, C, C+, B- | 65–96 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01105` | Aldmere Troll Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | C | 76 | 2.72 m | Day & Night | Like a typical Troll, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_01106` | Aldmere Troll Albino | [[Regions/Aldmere\|Aldmere]] | Albino | B- | 96 | 3.2 m | Day & Night | Like a typical Troll, but a rare pale form with white skin or fur and red eyes. |
| `pop_01107` | Strife Marches Troll Runt | [[Regions/Strife Marches\|Strife Marches]] | Runt | C- | 65 | 2.24 m | Day & Night | Like a typical Troll, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_01108` | Strife Marches Troll Albino | [[Regions/Strife Marches\|Strife Marches]] | Albino | B- | 96 | 3.2 m | Day & Night | Like a typical Troll, but a rare pale form with white skin or fur and red eyes. |
| `pop_01109` | Strife Marches Troll | [[Regions/Strife Marches\|Strife Marches]] | Adult | C+ | 86 | 3.2 m | Day & Night | A typical adult Troll of this region, with golden, grass-toned coloring. |
| `pop_01110` | Aldmere Troll Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | B+ | 120 | 4.32 m | Day & Night | Like a typical Troll, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_01111` | Moraveil Troll Runt | [[Regions/Moraveil\|Moraveil]] | Runt | C- | 65 | 2.24 m | Day & Night | Like a typical Troll, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_01112` | Moraveil Troll Juvenile | [[Regions/Moraveil\|Moraveil]] | Juvenile | C | 76 | 2.72 m | Day & Night | Like a typical Troll, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_01113` | Strife Marches Troll Juvenile | [[Regions/Strife Marches\|Strife Marches]] | Juvenile | C | 76 | 2.72 m | Day & Night | Like a typical Troll, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_01114` | Moraveil Troll | [[Regions/Moraveil\|Moraveil]] | Adult | C+ | 86 | 3.2 m | Day & Night | A typical adult Troll of this region, with golden, grass-toned coloring. |
| `pop_01115` | Moraveil Troll Scarred | [[Regions/Moraveil\|Moraveil]] | Scarred | B- | 96 | 3.52 m | Day & Night | Like a typical Troll, but covered in old battle scars, with golden, grass-toned coloring. |

## Design recipe

Rig `rig_large_biped` · mesh `large_biped_base` · material `thick_skin` · VFX `pollen_petals` · palette `#7f8290` `#555862` `#8fd16a` · triangle-based silhouette, sharp asymmetric spikes
