---
type: monster
id: mon_prismatic_slime_sovereign
family: "Slimes"
rank: "SSS"
tier: core
tags: [monster, slimes]
---
# Prismatic Slime Sovereign

![[mon_prismatic_slime_sovereign_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_prismatic_slime_sovereign_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 30,000 tris · 8.94 × 8.588 × 8 m · local file `Game/Assets/_Game/Art/Models/Monsters/Slimes/mon_prismatic_slime_sovereign.fbx`

> The Prismatic Slime Sovereign is a huge creature with a wobbling mound of translucent gel, about 8 m tall. Its gel is weathered and natural, colored in warm gold and pearl white. Its most striking feature is a crown of rainbow light refracted through its whole body. It has alert animal eyes. Its outline is crowned by slowly turning rings of light; lesser monsters flee from it. It prowls, surrounded by soft radiance and floating motes of light.

| Field | Value |
|---|---|
| Family · type | [[Families/Slimes|Slimes]] · Ooze |
| Rank · level | SSS · 281 (267–294) |
| Menace | 2 · Wild |
| Element · weakness | Light · Dark |
| Size | 8 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 58736 · 907 · 680 · 680 · 680 · 110 |
| XP · gold | 24842 · 4024 |
| Ring | 8 |
| Rig · animation | [[Systems/Rigs/blob\|blob]] · `anim_blob` |
| Habitats | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]], [[Regions/Nox Dominion\|Nox Dominion]] |
| Genre | Classic Fantasy |
| Trope | The cute first enemy (Dragon Quest) and the evolving hero (Tensura) |

**Field note:** Weak to Dark. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/blob|blob]] (rigId); animation set `anim_blob`.
- **Dimensions:** 8 m high × 7.44 m long × 7.2 m wide; prefab scale 16.
- **Physics:** 255360 kg, gravity ×1.44, poise 220, knockback resistance 0.34, death style `splat_dissolve`.
- **Navigation:** speed 15.34 m/s, turn 127°/s, stopping distance 4 m.
- **Attack count:** 5; **signature:** a crown of rainbow light refracted through its whole body.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Body Slam\|Body Slam]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Engulf\|Engulf]] | grab | 1.4 | 8 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Split\|Split]] | summon | 0 | 20 s | None | none | Interrupt or reposition; watch for added enemies. |
| [[Attacks/Acid Splash\|Acid Splash]] | ranged | 1.1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Radiant Pulse\|Radiant Pulse]] | magic | 1.5 | 10 s | Light | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Prismatic Slime Sovereign is a **wild ooze** encountered at SSS rank, around level 281. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Dark**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a crown of rainbow light refracted through its whole body. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 91-120)|Great Labyrinth (Floors 91-120)]], [[Regions/Nox Dominion|Nox Dominion]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_blob`, animation set `anim_blob`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Slimes SSS|loot_slime_sss]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Slime Jelly\|Slime Jelly]] | 60% | 1–3 |
| [[Items/Gel Core\|Gel Core]] | 30% | 1–1 |
| [[Items/SSS-Rank Monster Core\|SSS-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Slimes/Cavern Prismatic Slime Sovereign|Cavern Prismatic Slime Sovereign]]
- [[Monsters/Slimes/Iron Prismatic Slime Sovereign|Iron Prismatic Slime Sovereign]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Nox Dominion\|Nox Dominion]] | 6 | SSS+, SSS, SSS-, SS+, EX | 253–300 | Day & Night |
| [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | 5 | SSS+, EX-, SSS-, EX | 267–300 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00144` | Nox Dominion Prismatic Slime Sovereign Scarred | [[Regions/Nox Dominion\|Nox Dominion]] | Scarred | SSS+ | 294 | 8.8 m | Day & Night | Like a typical Prismatic Slime Sovereign, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_00145` | Great Labyrinth (Floors 91-120) Prismatic Slime Sovereign Albino | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Albino | SSS+ | 294 | 8 m | Day & Night | Like a typical Prismatic Slime Sovereign, but a rare pale form with white skin or fur and red eyes. |
| `pop_00146` | Nox Dominion Prismatic Slime Sovereign | [[Regions/Nox Dominion\|Nox Dominion]] | Adult | SSS | 281 | 8 m | Day & Night | A typical adult Prismatic Slime Sovereign of this region, with dust-grey coloring and old rune scars. |
| `pop_00147` | Nox Dominion Prismatic Slime Sovereign Juvenile | [[Regions/Nox Dominion\|Nox Dominion]] | Juvenile | SSS- | 267 | 6.8 m | Day & Night | Like a typical Prismatic Slime Sovereign, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_00148` | Nox Dominion Prismatic Slime Sovereign Runt | [[Regions/Nox Dominion\|Nox Dominion]] | Runt | SS+ | 253 | 5.6 m | Day & Night | Like a typical Prismatic Slime Sovereign, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_00149` | Nox Dominion Prismatic Slime Sovereign Albino | [[Regions/Nox Dominion\|Nox Dominion]] | Albino | SSS+ | 294 | 8 m | Day & Night | Like a typical Prismatic Slime Sovereign, but a rare pale form with white skin or fur and red eyes. |
| `pop_00150` | Great Labyrinth (Floors 91-120) Prismatic Slime Sovereign Alpha | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Alpha | EX- | 300 | 10 m | Day & Night | Like a typical Prismatic Slime Sovereign, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_00151` | Great Labyrinth (Floors 91-120) Prismatic Slime Sovereign Juvenile | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Juvenile | SSS- | 267 | 6.8 m | Day & Night | Like a typical Prismatic Slime Sovereign, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_00152` | Great Labyrinth (Floors 91-120) Prismatic Slime Sovereign Elderborn | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Elderborn | EX | 300 | 10.8 m | Day & Night | Like a typical Prismatic Slime Sovereign, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_00153` | Great Labyrinth (Floors 91-120) Prismatic Slime Sovereign Scarred | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Scarred | SSS+ | 294 | 8.8 m | Day & Night | Like a typical Prismatic Slime Sovereign, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_00154` | Nox Dominion Prismatic Slime Sovereign Elderborn | [[Regions/Nox Dominion\|Nox Dominion]] | Elderborn | EX | 300 | 10.8 m | Day & Night | Like a typical Prismatic Slime Sovereign, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |

## Design recipe

Rig `rig_blob` · mesh `blob_base` · material `translucent_gel_sss` · VFX `holy_motes` · palette `#fff3b0` `#ffd166` `#ffffff` · real-animal silhouette with one fantasy exaggeration
