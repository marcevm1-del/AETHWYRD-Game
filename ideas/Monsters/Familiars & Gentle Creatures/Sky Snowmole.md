---
type: monster
id: mon_sky_snowmole
family: "Familiars & Gentle Creatures"
rank: "E+"
tier: variant
tags: [monster, familiars-gentle-creatures]
---
# Sky Snowmole

![[mon_sky_snowmole_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_sky_snowmole_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Sky Snowmole is a tiny creature with a small, quick four-legged body, about 0.4 m long. Its coat is smooth and clean, colored in pale jade and cloud white. Look for a white nose and shovel-like paws. It has big round glossy eyes. Small scars and rough edges mark it as a survivor. It waddles, surrounded by swirling leaves and a constant breeze. This Wind-attuned variant carries one extra elemental feature, like a crest of elemental energy, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Familiars & Gentle Creatures|Familiars & Gentle Creatures]] · Familiar |
| Variant of | [[Monsters/Familiars & Gentle Creatures/Snowmole\|Snowmole]] (elemental) |
| Rank · level | E+ · 32 (26–40) |
| Menace | 1 · Charming |
| Element · weakness | Wind · Fire |
| Size | 0.4 m |
| Behaviour | Passive (passive_wander) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1103 · 138 · 110 · 97 · 110 · 135 |
| XP · gold | 776 · 195 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/quad_small\|quad_small]] · `anim_quad_small` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Fanghold\|Fanghold]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Cozy Fantasy |
| Trope | Cozy companion creatures |

**Field note:** Weak to Fire. Leaves you alone unless attacked.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_small|quad_small]] (rigId); animation set `anim_quad_small`.
- **Dimensions:** 0.27 m high × 0.4 m long × 0.06 m wide; prefab scale 0.8.
- **Physics:** 1.7 kg, gravity ×1.28, poise 21, knockback resistance 0.08, death style `ragdoll_tumble`.
- **Navigation:** speed 4.93 m/s, turn 854°/s, stopping distance 0.5 m.
- **Attack count:** 5; **signature:** a white nose and shovel-like paws.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Bite\|Bite]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Charge\|Charge]] | dash | 1.3 | 5 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Leap\|Leap]] | dash | 1.2 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Playful Nudge\|Playful Nudge]] | melee | 0.5 | 6 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Gale Cutter\|Gale Cutter]] | magic | 1.5 | 10 s | Wind | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Sky Snowmole is a **charming familiar** encountered at E+ rank, around level 32. Its documented behaviour is *Passive* and its AI pattern is *passive_wander*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a white nose and shovel-like paws. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Fanghold|Fanghold]], [[Regions/Whisperwood|Whisperwood]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_small`, animation set `anim_quad_small`; keep silhouette, movement and signature attack legible at gameplay camera distance.

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
| [[Regions/Whisperwood\|Whisperwood]] | 3 | D+, E-, E | 19–56 | Day |
| [[Regions/Aldmere\|Aldmere]] | 5 | D-, E-, D, E | 19–48 | Day |
| [[Regions/Fanghold\|Fanghold]] | 3 | D, D-, E | 26–48 | Day |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05725` | Whisperwood Sky Snowmole Elderborn | [[Regions/Whisperwood\|Whisperwood]] | Elderborn | D+ | 56 | 0.54 m | Day | Like a typical Sky Snowmole, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_05726` | Whisperwood Sky Snowmole Runt | [[Regions/Whisperwood\|Whisperwood]] | Runt | E- | 19 | 0.28 m | Day | Like a typical Sky Snowmole, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_05727` | Aldmere Sky Snowmole Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | D- | 40 | 0.44 m | Day | Like a typical Sky Snowmole, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_05728` | Whisperwood Sky Snowmole Juvenile | [[Regions/Whisperwood\|Whisperwood]] | Juvenile | E | 26 | 0.34 m | Day | Like a typical Sky Snowmole, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_05729` | Fanghold Sky Snowmole Alpha | [[Regions/Fanghold\|Fanghold]] | Alpha | D | 48 | 0.5 m | Day | Like a typical Sky Snowmole, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_05730` | Aldmere Sky Snowmole Runt | [[Regions/Aldmere\|Aldmere]] | Runt | E- | 19 | 0.28 m | Day | Like a typical Sky Snowmole, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_05731` | Fanghold Sky Snowmole Scarred | [[Regions/Fanghold\|Fanghold]] | Scarred | D- | 40 | 0.44 m | Day | Like a typical Sky Snowmole, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_05732` | Fanghold Sky Snowmole Juvenile | [[Regions/Fanghold\|Fanghold]] | Juvenile | E | 26 | 0.34 m | Day | Like a typical Sky Snowmole, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_05733` | Aldmere Sky Snowmole Albino | [[Regions/Aldmere\|Aldmere]] | Albino | D- | 40 | 0.4 m | Day | Like a typical Sky Snowmole, but a rare pale form with white skin or fur and red eyes. |
| `pop_05734` | Aldmere Sky Snowmole Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | D | 48 | 0.5 m | Day | Like a typical Sky Snowmole, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_05735` | Aldmere Sky Snowmole Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | E | 26 | 0.34 m | Day | Like a typical Sky Snowmole, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |

## Design recipe

Rig `rig_quad_small` · mesh `quad_small_base` · material `fur_soft` · VFX `wind_ribbons` · palette `#a8e6cf` `#dcedc1` `#5b8c85` · circle-based, soft silhouette
