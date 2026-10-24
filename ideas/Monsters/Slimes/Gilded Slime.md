---
type: monster
id: mon_gilded_slime
family: "Slimes"
rank: "D+"
tier: variant
tags: [monster, slimes]
---
# Gilded Slime

![[mon_gilded_slime_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_gilded_slime_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Gilded Slime is a tiny creature with a teardrop-shaped jelly body, about 0.3 m tall. Its gel is smooth and clean, colored in warm gold and pearl white. Its most striking feature is mirror-chrome skin that reflects the world around it. It has wide curious eyes with star-shaped highlights. A distinctive marking runs along its back. It waddles, surrounded by soft radiance and floating motes of light. This Light-attuned variant carries one extra elemental feature, like element-scarred hide, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Slimes|Slimes]] · Ooze |
| Variant of | [[Monsters/Slimes/Metal Slime\|Metal Slime]] (elemental) |
| Rank · level | D+ · 56 (48–65) |
| Menace | 1 · Charming |
| Element · weakness | Light · Dark |
| Size | 0.3 m |
| Behaviour | Passive (passive_wander) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1932 · 187 · 140 · 140 · 140 · 110 |
| XP · gold | 1888 · 423 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/blob\|blob]] · `anim_blob` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Moraveil\|Moraveil]] |
| Genre | Classic Fantasy |
| Trope | The cute first enemy (Dragon Quest) and the evolving hero (Tensura) |

**Field note:** Weak to Dark. Leaves you alone unless attacked.

## Motion implementation

- **Rig:** [[Systems/Rigs/blob|blob]] (rigId); animation set `anim_blob`.
- **Dimensions:** 0.3 m high × 0.28 m long × 0.27 m wide; prefab scale 0.6.
- **Physics:** 13.5 kg, gravity ×1.44, poise 25, knockback resistance 0.16, death style `splat_dissolve`.
- **Navigation:** speed 2.54 m/s, turn 657°/s, stopping distance 0.54 m.
- **Attack count:** 5; **signature:** mirror-chrome skin that reflects the world around it.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Body Slam\|Body Slam]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Engulf\|Engulf]] | grab | 1.4 | 8 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Split\|Split]] | summon | 0 | 20 s | None | none | Interrupt or reposition; watch for added enemies. |
| [[Attacks/Acid Splash\|Acid Splash]] | ranged | 1.1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Radiant Pulse\|Radiant Pulse]] | magic | 1.5 | 10 s | Light | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Gilded Slime is a **charming ooze** encountered at D+ rank, around level 56. Its documented behaviour is *Passive* and its AI pattern is *passive_wander*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Dark**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** mirror-chrome skin that reflects the world around it. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Moraveil|Moraveil]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

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
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 3 | D-, C, C+ | 40–86 | Day |
| [[Regions/Aldmere\|Aldmere]] | 5 | D-, C+, C, C- | 40–86 | Day |
| [[Regions/Moraveil\|Moraveil]] | 3 | D-, D+, C | 40–76 | Day |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02961` | Great Labyrinth (Floors 1-40) Gilded Slime Runt | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Runt | D- | 40 | 0.21 m | Day | Like a typical Gilded Slime, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_02962` | Aldmere Gilded Slime Runt | [[Regions/Aldmere\|Aldmere]] | Runt | D- | 40 | 0.21 m | Day | Like a typical Gilded Slime, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_02963` | Aldmere Gilded Slime Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | C+ | 86 | 0.41 m | Day | Like a typical Gilded Slime, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_02964` | Aldmere Gilded Slime Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | C | 76 | 0.38 m | Day | Like a typical Gilded Slime, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_02965` | Aldmere Gilded Slime Albino | [[Regions/Aldmere\|Aldmere]] | Albino | C- | 65 | 0.3 m | Day | Like a typical Gilded Slime, but a rare pale form with white skin or fur and red eyes. |
| `pop_02966` | Aldmere Gilded Slime Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | C- | 65 | 0.33 m | Day | Like a typical Gilded Slime, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_02967` | Moraveil Gilded Slime Runt | [[Regions/Moraveil\|Moraveil]] | Runt | D- | 40 | 0.21 m | Day | Like a typical Gilded Slime, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_02968` | Great Labyrinth (Floors 1-40) Gilded Slime Alpha | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Alpha | C | 76 | 0.38 m | Day | Like a typical Gilded Slime, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_02969` | Moraveil Gilded Slime | [[Regions/Moraveil\|Moraveil]] | Adult | D+ | 56 | 0.3 m | Day | A typical adult Gilded Slime of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_02970` | Moraveil Gilded Slime Alpha | [[Regions/Moraveil\|Moraveil]] | Alpha | C | 76 | 0.38 m | Day | Like a typical Gilded Slime, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_02971` | Great Labyrinth (Floors 1-40) Gilded Slime Elderborn | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Elderborn | C+ | 86 | 0.41 m | Day | Like a typical Gilded Slime, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |

## Design recipe

Rig `rig_blob` · mesh `blob_base` · material `translucent_gel_sss` · VFX `holy_motes` · palette `#fff3b0` `#ffd166` `#ffffff` · circle-based, soft silhouette
