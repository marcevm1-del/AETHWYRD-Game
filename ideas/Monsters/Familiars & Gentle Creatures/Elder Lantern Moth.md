---
type: monster
id: mon_elder_lantern_moth
family: "Familiars & Gentle Creatures"
rank: "E"
tier: variant
tags: [monster, familiars-gentle-creatures]
---
# Elder Lantern Moth

![[mon_elder_lantern_moth_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_elder_lantern_moth_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,456 tris · 0.851 × 0.695 × 0.5 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Elder Lantern Moth is a small creature with a bat-like flying frame, about 0.5 m tall. Its coat is smooth and clean, colored in warm gold and pearl white. Survivors describe wings that glow like paper lanterns. It has big round glossy eyes. Small scars and rough edges mark it as a survivor. It waddles, surrounded by soft radiance and floating motes of light. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Familiars & Gentle Creatures|Familiars & Gentle Creatures]] · Familiar |
| Variant of | [[Monsters/Familiars & Gentle Creatures/Lantern Moth\|Lantern Moth]] (elder) |
| Rank · level | E · 26 (19–32) |
| Menace | 1 · Charming |
| Element · weakness | Light · Dark |
| Size | 0.5 m |
| Behaviour | Passive (passive_wander) |
| HP · ATK · DEF · MATK · MDEF · SPD | 866 · 114 · 91 · 80 · 91 · 135 |
| XP · gold | 559 · 147 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/membrane_flyer\|membrane_flyer]] · `anim_flyer_small` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Cozy Fantasy |
| Trope | Cozy companion creatures |

**Field note:** Weak to Dark. Leaves you alone unless attacked.

## Motion implementation

- **Rig:** [[Systems/Rigs/membrane_flyer|membrane_flyer]] (override (base species)); animation set `anim_flyer_small`.
- **Dimensions:** 0.22 m high × 0.5 m long × 1 m wide; prefab scale 1.
- **Physics:** 2.4 kg, gravity ×0.72, poise 14, knockback resistance 0.08, death style `flutter_fall`.
- **Navigation:** speed 0.4 m/s, turn 900°/s, stopping distance 0.5 m.
- **Attack count:** 5; **signature:** wings that glow like paper lanterns.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Nip\|Nip]] | melee | 0.9 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Dart\|Dart]] | dash | 1.1 | 4 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Swarm Call\|Swarm Call]] | summon | 0 | 20 s | None | none | Interrupt or reposition; watch for added enemies. |
| [[Attacks/Playful Nudge\|Playful Nudge]] | melee | 0.5 | 6 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Radiant Pulse\|Radiant Pulse]] | magic | 1.5 | 10 s | Light | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Elder Lantern Moth is a **charming familiar** encountered at E rank, around level 26. Its documented behaviour is *Passive* and its AI pattern is *passive_wander*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Dark**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** wings that glow like paper lanterns. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Whisperwood|Whisperwood]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_flyer_small`, animation set `anim_flyer_small`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Familiars & Gentle Creatures E|loot_familiar_e]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Soft Fur\|Soft Fur]] | 60% | 1–3 |
| [[Items/Shed Scale\|Shed Scale]] | 30% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Aldmere\|Aldmere]] | 4 | F+, E, D-, D | 13–48 | Day |
| [[Regions/Whisperwood\|Whisperwood]] | 7 | E+, E-, D, F+, E, D- | 13–48 | Day |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05670` | Aldmere Elder Lantern Moth Runt | [[Regions/Aldmere\|Aldmere]] | Runt | F+ | 13 | 0.35 m | Day | Like a typical Elder Lantern Moth, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_05671` | Aldmere Elder Lantern Moth | [[Regions/Aldmere\|Aldmere]] | Adult | E | 26 | 0.5 m | Day | A typical adult Elder Lantern Moth of this region, with golden, grass-toned coloring. |
| `pop_05672` | Aldmere Elder Lantern Moth Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | D- | 40 | 0.63 m | Day | Like a typical Elder Lantern Moth, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_05673` | Whisperwood Elder Lantern Moth Scarred | [[Regions/Whisperwood\|Whisperwood]] | Scarred | E+ | 32 | 0.55 m | Day | Like a typical Elder Lantern Moth, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_05674` | Whisperwood Elder Lantern Moth Juvenile | [[Regions/Whisperwood\|Whisperwood]] | Juvenile | E- | 19 | 0.42 m | Day | Like a typical Elder Lantern Moth, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_05675` | Whisperwood Elder Lantern Moth Elderborn | [[Regions/Whisperwood\|Whisperwood]] | Elderborn | D | 48 | 0.68 m | Day | Like a typical Elder Lantern Moth, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_05676` | Whisperwood Elder Lantern Moth Albino | [[Regions/Whisperwood\|Whisperwood]] | Albino | E+ | 32 | 0.5 m | Day | Like a typical Elder Lantern Moth, but a rare pale form with white skin or fur and red eyes. |
| `pop_05677` | Whisperwood Elder Lantern Moth Runt | [[Regions/Whisperwood\|Whisperwood]] | Runt | F+ | 13 | 0.35 m | Day | Like a typical Elder Lantern Moth, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_05678` | Whisperwood Elder Lantern Moth | [[Regions/Whisperwood\|Whisperwood]] | Adult | E | 26 | 0.5 m | Day | A typical adult Elder Lantern Moth of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_05679` | Whisperwood Elder Lantern Moth Alpha | [[Regions/Whisperwood\|Whisperwood]] | Alpha | D- | 40 | 0.63 m | Day | Like a typical Elder Lantern Moth, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_05680` | Aldmere Elder Lantern Moth Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | D | 48 | 0.68 m | Day | Like a typical Elder Lantern Moth, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |

## Design recipe

Rig `rig_flyer_small` · mesh `flyer_small_base` · material `fur_soft` · VFX `holy_motes` · palette `#fff3b0` `#ffd166` `#ffffff` · circle-based, soft silhouette
