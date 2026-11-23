---
type: monster
id: mon_elder_frost_slime
family: "Slimes"
rank: "C"
tier: variant
tags: [monster, slimes]
---
# Elder Frost Slime

![[mon_elder_frost_slime_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_elder_frost_slime_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 12,000 tris · 0.838 × 0.857 × 0.8 m · local file `Game/Assets/_Game/Art/Models/Monsters/Slimes/mon_elder_frost_slime.fbx`

> The Elder Frost Slime is a small creature with a wobbling mound of translucent gel, about 0.8 m tall. Its gel is weathered and natural, colored in pale blues and frost-white. Guild sketches always show frost crystals growing from its crown. It has dark, wary eyes. Battle-worn plates and trophies hang from its body. It lopes in long strides, surrounded by falling snow motes and frosted ground where it steps. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Slimes|Slimes]] · Ooze |
| Variant of | [[Monsters/Slimes/Frost Slime\|Frost Slime]] (elder) |
| Rank · level | C · 76 (65–86) |
| Menace | 2 · Wild |
| Element · weakness | Ice · Fire |
| Size | 0.8 m |
| Behaviour | Swarm (swarm_surround) |
| HP · ATK · DEF · MATK · MDEF · SPD | 3928 · 251 · 188 · 188 · 188 · 110 |
| XP · gold | 3073 · 648 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/blob\|blob]] · `anim_blob` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] |
| Genre | Classic Fantasy |
| Trope | The cute first enemy (Dragon Quest) and the evolving hero (Tensura) |

**Field note:** Weak to Fire. Dangerous in numbers. Area attacks and chokepoints help.

## Motion implementation

- **Rig:** [[Systems/Rigs/blob|blob]] (rigId); animation set `anim_blob`.
- **Dimensions:** 0.8 m high × 0.74 m long × 0.72 m wide; prefab scale 1.6.
- **Physics:** 295.7 kg, gravity ×1.68, poise 46, knockback resistance 0.19, death style `splat_dissolve`.
- **Navigation:** speed 4.69 m/s, turn 402°/s, stopping distance 0.76 m.
- **Attack count:** 5; **signature:** frost crystals growing from its crown.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Body Slam\|Body Slam]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Engulf\|Engulf]] | grab | 1.4 | 8 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Split\|Split]] | summon | 0 | 20 s | None | none | Interrupt or reposition; watch for added enemies. |
| [[Attacks/Acid Splash\|Acid Splash]] | ranged | 1.1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Frost Breath\|Frost Breath]] | magic | 1.5 | 10 s | Ice | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Elder Frost Slime is a **wild ooze** encountered at C rank, around level 76. Its documented behaviour is *Swarm* and its AI pattern is *swarm_surround*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** frost crystals growing from its crown. Watch for its tell and leave a response window before committing to a long combo.

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
| [[Regions/Aldmere\|Aldmere]] | 6 | C+, C, C-, B, B- | 65–108 | Day & Night |
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 5 | C+, C-, B-, C | 65–96 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02983` | Aldmere Elder Frost Slime Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | C+ | 86 | 0.88 m | Day & Night | Like a typical Elder Frost Slime, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_02984` | Great Labyrinth (Floors 41-90) Elder Frost Slime Scarred | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Scarred | C+ | 86 | 0.88 m | Day & Night | Like a typical Elder Frost Slime, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_02985` | Great Labyrinth (Floors 41-90) Elder Frost Slime Albino | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Albino | C+ | 86 | 0.8 m | Day & Night | Like a typical Elder Frost Slime, but a rare pale form with white skin or fur and red eyes. |
| `pop_02986` | Great Labyrinth (Floors 41-90) Elder Frost Slime Juvenile | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Juvenile | C- | 65 | 0.68 m | Day & Night | Like a typical Elder Frost Slime, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_02987` | Aldmere Elder Frost Slime | [[Regions/Aldmere\|Aldmere]] | Adult | C | 76 | 0.8 m | Day & Night | A typical adult Elder Frost Slime of this region, with golden, grass-toned coloring. |
| `pop_02988` | Aldmere Elder Frost Slime Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | C- | 65 | 0.68 m | Day & Night | Like a typical Elder Frost Slime, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_02989` | Great Labyrinth (Floors 41-90) Elder Frost Slime Alpha | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Alpha | B- | 96 | 1 m | Day & Night | Like a typical Elder Frost Slime, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_02990` | Aldmere Elder Frost Slime Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | B | 108 | 1.08 m | Day & Night | Like a typical Elder Frost Slime, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_02991` | Aldmere Elder Frost Slime Albino | [[Regions/Aldmere\|Aldmere]] | Albino | C+ | 86 | 0.8 m | Day & Night | Like a typical Elder Frost Slime, but a rare pale form with white skin or fur and red eyes. |
| `pop_02992` | Great Labyrinth (Floors 41-90) Elder Frost Slime | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Adult | C | 76 | 0.8 m | Day & Night | A typical adult Elder Frost Slime of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_02993` | Aldmere Elder Frost Slime Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | B- | 96 | 1 m | Day & Night | Like a typical Elder Frost Slime, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |

## Design recipe

Rig `rig_blob` · mesh `blob_base` · material `translucent_gel_sss` · VFX `frost_trail_snow` · palette `#bfe9ff` `#5fa8d3` `#f4fbff` · real-animal silhouette with one fantasy exaggeration
