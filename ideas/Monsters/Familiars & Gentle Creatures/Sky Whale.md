---
type: monster
id: mon_sky_whale
family: "Familiars & Gentle Creatures"
rank: "A"
tier: core
tags: [monster, familiars-gentle-creatures]
---
# Sky Whale

![[mon_sky_whale_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_sky_whale_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (1,494 tris · 37.71 × 80 × 40.454 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Sky Whale is a colossal creature with a heavy-jawed fish frame, about 80 m long. Its coat is smooth and clean, colored in mint, with pale jade markings. Its most striking feature is a gentle giant drifting between floating islands. It has big round glossy eyes. An elegant crest and glowing veins of mana mark it as a champion of its kind. It waddles, surrounded by swirling leaves and a constant breeze.

| Field | Value |
|---|---|
| Family · type | [[Families/Familiars & Gentle Creatures|Familiars & Gentle Creatures]] · Familiar |
| Rank · level | A · 146 (132–159) |
| Menace | 1 · Charming |
| Element · weakness | Wind · Fire |
| Size | 80 m |
| Behaviour | Passive (passive_wander) |
| HP · ATK · DEF · MATK · MDEF · SPD | 54233 · 743 · 535 · 535 · 535 · 100 |
| XP · gold | 8719 · 1611 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/aquatic\|aquatic]] · `anim_fish` |
| Habitats | [[Regions/Hoshizora\|Hoshizora]], [[Regions/Vharlen\|Vharlen]], [[Regions/Quaking Lands\|Quaking Lands]] |
| Genre | Cozy Fantasy |
| Trope | Cozy companion creatures |

**Field note:** Weak to Fire. Leaves you alone unless attacked.

## Motion implementation

- **Rig:** [[Systems/Rigs/aquatic|aquatic]] (rigId); animation set `anim_fish`.
- **Dimensions:** 32 m high × 80 m long × 28.8 m wide; prefab scale 53.333.
- **Physics:** 10598400 kg, gravity ×0.8, poise 33535, knockback resistance 0.45, death style `float_belly_up`.
- **Navigation:** speed 34.71 m/s, turn 60°/s, stopping distance 10 m.
- **Attack count:** 5; **signature:** a gentle giant drifting between floating islands.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Bite\|Bite]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Breach Lunge\|Breach Lunge]] | dash | 1.7 | 9 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Thrash\|Thrash]] | aoe | 1.3 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Playful Nudge\|Playful Nudge]] | melee | 0.5 | 6 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Gale Cutter\|Gale Cutter]] | magic | 1.5 | 10 s | Wind | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Sky Whale is a **charming familiar** encountered at A rank, around level 146. Its documented behaviour is *Passive* and its AI pattern is *passive_wander*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a gentle giant drifting between floating islands. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Hoshizora|Hoshizora]], [[Regions/Vharlen|Vharlen]], [[Regions/Quaking Lands|Quaking Lands]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_fish`, animation set `anim_fish`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Familiars & Gentle Creatures A|loot_familiar_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Soft Fur\|Soft Fur]] | 60% | 1–3 |
| [[Items/Shed Scale\|Shed Scale]] | 30% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Familiars & Gentle Creatures/Greater Sky Whale|Greater Sky Whale]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Quaking Lands\|Quaking Lands]] | 3 | A-, B+, S | 120–188 | Day |
| [[Regions/Vharlen\|Vharlen]] | 4 | A-, A+, B+, S- | 120–173 | Day |
| [[Regions/Hoshizora\|Hoshizora]] | 4 | A, S-, B+, S | 120–188 | Day |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02895` | Quaking Lands Sky Whale Juvenile | [[Regions/Quaking Lands\|Quaking Lands]] | Juvenile | A- | 132 | 68 m | Day | Like a typical Sky Whale, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_02896` | Vharlen Sky Whale Juvenile | [[Regions/Vharlen\|Vharlen]] | Juvenile | A- | 132 | 68 m | Day | Like a typical Sky Whale, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_02897` | Hoshizora Sky Whale | [[Regions/Hoshizora\|Hoshizora]] | Adult | A | 146 | 80 m | Day | A typical adult Sky Whale of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_02898` | Quaking Lands Sky Whale Runt | [[Regions/Quaking Lands\|Quaking Lands]] | Runt | B+ | 120 | 56 m | Day | Like a typical Sky Whale, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_02899` | Quaking Lands Sky Whale Elderborn | [[Regions/Quaking Lands\|Quaking Lands]] | Elderborn | S | 188 | 108 m | Day | Like a typical Sky Whale, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_02900` | Vharlen Sky Whale Albino | [[Regions/Vharlen\|Vharlen]] | Albino | A+ | 159 | 80 m | Day | Like a typical Sky Whale, but a rare pale form with white skin or fur and red eyes. |
| `pop_02901` | Hoshizora Sky Whale Alpha | [[Regions/Hoshizora\|Hoshizora]] | Alpha | S- | 173 | 100 m | Day | Like a typical Sky Whale, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_02902` | Vharlen Sky Whale Runt | [[Regions/Vharlen\|Vharlen]] | Runt | B+ | 120 | 56 m | Day | Like a typical Sky Whale, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_02903` | Vharlen Sky Whale Alpha | [[Regions/Vharlen\|Vharlen]] | Alpha | S- | 173 | 100 m | Day | Like a typical Sky Whale, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_02904` | Hoshizora Sky Whale Runt | [[Regions/Hoshizora\|Hoshizora]] | Runt | B+ | 120 | 56 m | Day | Like a typical Sky Whale, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_02905` | Hoshizora Sky Whale Elderborn | [[Regions/Hoshizora\|Hoshizora]] | Elderborn | S | 188 | 108 m | Day | Like a typical Sky Whale, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_fish` · mesh `fish_base` · material `fur_soft` · VFX `wind_ribbons` · palette `#acd29b` `#749567` `#8fe0bd` · circle-based, soft silhouette
