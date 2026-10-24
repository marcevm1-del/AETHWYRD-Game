---
type: monster
id: mon_mana_fox
family: "Familiars & Gentle Creatures"
rank: "E"
tier: core
tags: [monster, familiars-gentle-creatures]
---
# Mana Fox

![[mon_mana_fox_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_mana_fox_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,810 tris · 0.144 × 0.6 × 0.241 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Mana Fox is a small creature with a small, quick four-legged body, about 0.6 m long. Its coat is smooth and clean, colored in warm gold and pearl white. Look for ears that twitch toward magic. It has big round glossy eyes. Small scars and rough edges mark it as a survivor. It waddles, surrounded by soft radiance and floating motes of light.

| Field | Value |
|---|---|
| Family · type | [[Families/Familiars & Gentle Creatures|Familiars & Gentle Creatures]] · Familiar |
| Rank · level | E · 26 (19–32) |
| Menace | 1 · Charming |
| Element · weakness | Light · Dark |
| Size | 0.6 m |
| Behaviour | Passive (passive_wander) |
| HP · ATK · DEF · MATK · MDEF · SPD | 911 · 114 · 91 · 80 · 91 · 135 |
| XP · gold | 559 · 147 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/quad_small\|quad_small]] · `anim_quad_small` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Fanghold\|Fanghold]], [[Regions/Whisperwood\|Whisperwood]], [[Regions/Sylvaran\|Sylvaran]], [[Regions/Lirian\|Lirian]] |
| Genre | Cozy Fantasy |
| Trope | Cozy companion creatures |

**Field note:** Weak to Dark. Leaves you alone unless attacked.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_small|quad_small]] (rigId); animation set `anim_quad_small`.
- **Dimensions:** 0.41 m high × 0.6 m long × 0.08 m wide; prefab scale 1.2.
- **Physics:** 6.2 kg, gravity ×1.44, poise 25, knockback resistance 0.08, death style `ragdoll_tumble`.
- **Navigation:** speed 5.59 m/s, turn 697°/s, stopping distance 0.5 m.
- **Attack count:** 5; **signature:** ears that twitch toward magic.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Bite\|Bite]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Charge\|Charge]] | dash | 1.3 | 5 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Leap\|Leap]] | dash | 1.2 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Playful Nudge\|Playful Nudge]] | melee | 0.5 | 6 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Radiant Pulse\|Radiant Pulse]] | magic | 1.5 | 10 s | Light | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Mana Fox is a **charming familiar** encountered at E rank, around level 26. Its documented behaviour is *Passive* and its AI pattern is *passive_wander*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Dark**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** ears that twitch toward magic. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Fanghold|Fanghold]], [[Regions/Whisperwood|Whisperwood]], [[Regions/Sylvaran|Sylvaran]], [[Regions/Lirian|Lirian]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_small`, animation set `anim_quad_small`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Familiars & Gentle Creatures E|loot_familiar_e]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Soft Fur\|Soft Fur]] | 60% | 1–3 |
| [[Items/Shed Scale\|Shed Scale]] | 30% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Familiars & Gentle Creatures/Ember Mana Fox|Ember Mana Fox]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Whisperwood\|Whisperwood]] | 3 | D-, D, E- | 19–48 | Day |
| [[Regions/Fanghold\|Fanghold]] | 2 | E, E+ | 26–32 | Day |
| [[Regions/Sylvaran\|Sylvaran]] | 3 | D, E+, E | 26–48 | Day |
| [[Regions/Aldmere\|Aldmere]] | 1 | E- | 19–19 | Day |
| [[Regions/Lirian\|Lirian]] | 2 | F+, E | 13–26 | Day |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02862` | Whisperwood Mana Fox Alpha | [[Regions/Whisperwood\|Whisperwood]] | Alpha | D- | 40 | 0.75 m | Day | Like a typical Mana Fox, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_02863` | Fanghold Mana Fox | [[Regions/Fanghold\|Fanghold]] | Adult | E | 26 | 0.6 m | Day | A typical adult Mana Fox of this region, with golden, grass-toned coloring. |
| `pop_02864` | Sylvaran Mana Fox Elderborn | [[Regions/Sylvaran\|Sylvaran]] | Elderborn | D | 48 | 0.81 m | Day | Like a typical Mana Fox, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_02865` | Aldmere Mana Fox Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | E- | 19 | 0.51 m | Day | Like a typical Mana Fox, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_02866` | Sylvaran Mana Fox Scarred | [[Regions/Sylvaran\|Sylvaran]] | Scarred | E+ | 32 | 0.66 m | Day | Like a typical Mana Fox, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_02867` | Whisperwood Mana Fox Elderborn | [[Regions/Whisperwood\|Whisperwood]] | Elderborn | D | 48 | 0.81 m | Day | Like a typical Mana Fox, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_02868` | Whisperwood Mana Fox Juvenile | [[Regions/Whisperwood\|Whisperwood]] | Juvenile | E- | 19 | 0.51 m | Day | Like a typical Mana Fox, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_02869` | Lirian Mana Fox Runt | [[Regions/Lirian\|Lirian]] | Runt | F+ | 13 | 0.42 m | Day | Like a typical Mana Fox, but smaller and scrappier than usual, with salt-crusted, barnacle-flecked hide. |
| `pop_02870` | Fanghold Mana Fox Scarred | [[Regions/Fanghold\|Fanghold]] | Scarred | E+ | 32 | 0.66 m | Day | Like a typical Mana Fox, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_02871` | Sylvaran Mana Fox | [[Regions/Sylvaran\|Sylvaran]] | Adult | E | 26 | 0.6 m | Day | A typical adult Mana Fox of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_02872` | Lirian Mana Fox | [[Regions/Lirian\|Lirian]] | Adult | E | 26 | 0.6 m | Day | A typical adult Mana Fox of this region, with salt-crusted, barnacle-flecked hide. |

## Design recipe

Rig `rig_quad_small` · mesh `quad_small_base` · material `fur_soft` · VFX `holy_motes` · palette `#fff3b0` `#ffd166` `#ffffff` · circle-based, soft silhouette
