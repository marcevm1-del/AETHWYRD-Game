---
type: monster
id: mon_phantom_the_many_mouthed
family: "Aberrations"
rank: "B+"
tier: variant
tags: [monster, aberrations]
---
# Phantom The Many-Mouthed

![[mon_phantom_the_many_mouthed_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_phantom_the_many_mouthed_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,388 tris · 4.291 × 3.836 × 4 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Phantom The Many-Mouthed is a large creature with a shape that keeps rearranging itself, about 4 m tall. Its skin is stretched, stitched and constantly shifting, colored in warm gold and pearl white. Look for mouths opening along its arms, all whispering. It has no eyes at all, only a wide and patient mouth. Faint runes glow along its body when it fights. It copies the walk of whatever it hunts, surrounded by soft radiance and floating motes of light. Its body is translucent blue, half in the spirit world; weapons pass through it unless they are blessed or enchanted.

| Field | Value |
|---|---|
| Family · type | [[Families/Aberrations|Aberrations]] · Aberration |
| Variant of | [[Monsters/Aberrations/The Many-Mouthed\|The Many-Mouthed]] (spirit) |
| Rank · level | B+ · 120 (108–132) |
| Menace | 5 · Horror |
| Element · weakness | Light · Dark |
| Size | 4 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 18964 · 613 · 441 · 441 · 441 · 100 |
| XP · gold | 6373 · 1225 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/amorphous\|amorphous]] · `anim_aberrant` |
| Habitats | [[Regions/Kitsune Isles\|Kitsune Isles]], [[Regions/Everdusk\|Everdusk]], [[Regions/Hoshizora\|Hoshizora]] |
| Genre | Cosmic Horror |
| Trope | Mimicking things in the dark |

**Field note:** Weak to Dark. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/amorphous|amorphous]] (rigId); animation set `anim_aberrant`.
- **Dimensions:** 4 m high × 4.29 m long × 4.2 m wide; prefab scale 2.
- **Physics:** 1824 kg, gravity ×1.08, poise 285, knockback resistance 0.72, death style `collapse_and_melt`.
- **Navigation:** speed 10.23 m/s, turn 250°/s, stopping distance 1.6 m.
- **Attack count:** 5; **signature:** mouths opening along its arms, all whispering.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Grasp\|Grasp]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Unfold\|Unfold]] | aoe | 1.8 | 12 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Mimic Voice\|Mimic Voice]] | debuff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Mimic Lure\|Mimic Lure]] | debuff | 0 | 16 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Radiant Pulse\|Radiant Pulse]] | magic | 1.5 | 10 s | Light | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Phantom The Many-Mouthed is a **horror aberration** encountered at B+ rank, around level 120. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Dark**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** mouths opening along its arms, all whispering. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Kitsune Isles|Kitsune Isles]], [[Regions/Everdusk|Everdusk]], [[Regions/Hoshizora|Hoshizora]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_aberrant`, animation set `anim_aberrant`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Aberrations B|loot_aberration_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Unreal Fragment\|Unreal Fragment]] | 60% | 1–3 |
| [[Items/Eye of Nothing\|Eye of Nothing]] | 30% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Hoshizora\|Hoshizora]] | 2 | A+, B- | 96–159 | Night |
| [[Regions/Everdusk\|Everdusk]] | 4 | A, A-, A+ | 132–159 | Night |
| [[Regions/Kitsune Isles\|Kitsune Isles]] | 5 | B+, A+, B-, A-, A | 96–159 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05279` | Hoshizora Phantom The Many-Mouthed Elderborn | [[Regions/Hoshizora\|Hoshizora]] | Elderborn | A+ | 159 | 5.4 m | Night | Like a typical Phantom The Many-Mouthed, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_05280` | Everdusk Phantom The Many-Mouthed Alpha | [[Regions/Everdusk\|Everdusk]] | Alpha | A | 146 | 5 m | Night | Like a typical Phantom The Many-Mouthed, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_05281` | Kitsune Isles Phantom The Many-Mouthed | [[Regions/Kitsune Isles\|Kitsune Isles]] | Adult | B+ | 120 | 4 m | Night | A typical adult Phantom The Many-Mouthed of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_05282` | Kitsune Isles Phantom The Many-Mouthed Elderborn | [[Regions/Kitsune Isles\|Kitsune Isles]] | Elderborn | A+ | 159 | 5.4 m | Night | Like a typical Phantom The Many-Mouthed, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_05283` | Kitsune Isles Phantom The Many-Mouthed Runt | [[Regions/Kitsune Isles\|Kitsune Isles]] | Runt | B- | 96 | 2.8 m | Night | Like a typical Phantom The Many-Mouthed, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_05284` | Hoshizora Phantom The Many-Mouthed Runt | [[Regions/Hoshizora\|Hoshizora]] | Runt | B- | 96 | 2.8 m | Night | Like a typical Phantom The Many-Mouthed, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_05285` | Kitsune Isles Phantom The Many-Mouthed Albino | [[Regions/Kitsune Isles\|Kitsune Isles]] | Albino | A- | 132 | 4 m | Night | Like a typical Phantom The Many-Mouthed, but a rare pale form with white skin or fur and red eyes. |
| `pop_05286` | Kitsune Isles Phantom The Many-Mouthed Alpha | [[Regions/Kitsune Isles\|Kitsune Isles]] | Alpha | A | 146 | 5 m | Night | Like a typical Phantom The Many-Mouthed, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_05287` | Everdusk Phantom The Many-Mouthed Scarred | [[Regions/Everdusk\|Everdusk]] | Scarred | A- | 132 | 4.4 m | Night | Like a typical Phantom The Many-Mouthed, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_05288` | Everdusk Phantom The Many-Mouthed Albino | [[Regions/Everdusk\|Everdusk]] | Albino | A- | 132 | 4 m | Night | Like a typical Phantom The Many-Mouthed, but a rare pale form with white skin or fur and red eyes. |
| `pop_05289` | Everdusk Phantom The Many-Mouthed Elderborn | [[Regions/Everdusk\|Everdusk]] | Elderborn | A+ | 159 | 5.4 m | Night | Like a typical Phantom The Many-Mouthed, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_aberrant` · mesh `aberrant_base` · material `wet_flesh_unsettling` · VFX `holy_motes` · palette `#fff3b0` `#ffd166` `#ffffff` · broken symmetry, mimicry, audio-first reveal
