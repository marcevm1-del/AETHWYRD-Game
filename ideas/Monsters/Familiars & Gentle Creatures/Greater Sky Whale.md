---
type: monster
id: mon_greater_sky_whale
family: "Familiars & Gentle Creatures"
rank: "S"
tier: variant
tags: [monster, familiars-gentle-creatures]
---
# Greater Sky Whale

![[mon_greater_sky_whale_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_greater_sky_whale_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (1,490 tris · 50.629 × 128 × 54.311 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Greater Sky Whale is a colossal creature with a long, finned body, about 128 m long. Its coat is smooth and clean, colored in pale jade and cloud white. Guild sketches always show a gentle giant drifting between floating islands. It has big round glossy eyes. Its regal silhouette is crowned by a halo-like ring of aura. It waddles, surrounded by swirling leaves and a constant breeze. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Familiars & Gentle Creatures|Familiars & Gentle Creatures]] · Familiar |
| Variant of | [[Monsters/Familiars & Gentle Creatures/Sky Whale\|Sky Whale]] (elder) |
| Rank · level | S · 188 (173–203) |
| Menace | 1 · Charming |
| Element · weakness | Wind · Fire |
| Size | 128 m |
| Behaviour | Passive (passive_wander) |
| HP · ATK · DEF · MATK · MDEF · SPD | 81408 · 953 · 686 · 686 · 686 · 100 |
| XP · gold | 13063 · 2293 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/aquatic\|aquatic]] · `anim_fish` |
| Habitats | [[Regions/Heavenreach\|Heavenreach]], [[Regions/Stormreach\|Stormreach]] |
| Genre | Cozy Fantasy |
| Trope | Cozy companion creatures |

**Field note:** Weak to Fire. Leaves you alone unless attacked.

## Motion implementation

- **Rig:** [[Systems/Rigs/aquatic|aquatic]] (rigId); animation set `anim_fish`.
- **Dimensions:** 51.2 m high × 128 m long × 46.08 m wide; prefab scale 85.333.
- **Physics:** 43411046.4 kg, gravity ×0.8, poise 75436, knockback resistance 0.48, death style `float_belly_up`.
- **Navigation:** speed 43.9 m/s, turn 60°/s, stopping distance 12.4 m.
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

Greater Sky Whale is a **charming familiar** encountered at S rank, around level 188. Its documented behaviour is *Passive* and its AI pattern is *passive_wander*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a gentle giant drifting between floating islands. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Heavenreach|Heavenreach]], [[Regions/Stormreach|Stormreach]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_fish`, animation set `anim_fish`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Familiars & Gentle Creatures S|loot_familiar_s]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Soft Fur\|Soft Fur]] | 60% | 1–3 |
| [[Items/Shed Scale\|Shed Scale]] | 30% | 1–1 |
| [[Items/S-Rank Monster Core\|S-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Heavenreach\|Heavenreach]] | 5 | SS-, S-, SS, S+, S | 173–236 | Day |
| [[Regions/Stormreach\|Stormreach]] | 6 | SS, A+, S, S+, SS-, S- | 159–236 | Day |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05736` | Heavenreach Greater Sky Whale Alpha | [[Regions/Heavenreach\|Heavenreach]] | Alpha | SS- | 218 | 160 m | Day | Like a typical Greater Sky Whale, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_05737` | Heavenreach Greater Sky Whale Juvenile | [[Regions/Heavenreach\|Heavenreach]] | Juvenile | S- | 173 | 108.8 m | Day | Like a typical Greater Sky Whale, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_05738` | Heavenreach Greater Sky Whale Elderborn | [[Regions/Heavenreach\|Heavenreach]] | Elderborn | SS | 236 | 172.8 m | Day | Like a typical Greater Sky Whale, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_05739` | Heavenreach Greater Sky Whale Scarred | [[Regions/Heavenreach\|Heavenreach]] | Scarred | S+ | 203 | 140.8 m | Day | Like a typical Greater Sky Whale, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_05740` | Heavenreach Greater Sky Whale | [[Regions/Heavenreach\|Heavenreach]] | Adult | S | 188 | 128 m | Day | A typical adult Greater Sky Whale of this region, with slate-grey coloring and hardened hide. |
| `pop_05741` | Stormreach Greater Sky Whale Elderborn | [[Regions/Stormreach\|Stormreach]] | Elderborn | SS | 236 | 172.8 m | Day | Like a typical Greater Sky Whale, but old and wise, with greying features and a cautious hunting style, with salt-crusted, barnacle-flecked hide. |
| `pop_05742` | Stormreach Greater Sky Whale Runt | [[Regions/Stormreach\|Stormreach]] | Runt | A+ | 159 | 89.6 m | Day | Like a typical Greater Sky Whale, but smaller and scrappier than usual, with salt-crusted, barnacle-flecked hide. |
| `pop_05743` | Stormreach Greater Sky Whale | [[Regions/Stormreach\|Stormreach]] | Adult | S | 188 | 128 m | Day | A typical adult Greater Sky Whale of this region, with salt-crusted, barnacle-flecked hide. |
| `pop_05744` | Stormreach Greater Sky Whale Scarred | [[Regions/Stormreach\|Stormreach]] | Scarred | S+ | 203 | 140.8 m | Day | Like a typical Greater Sky Whale, but covered in old battle scars, with salt-crusted, barnacle-flecked hide. |
| `pop_05745` | Stormreach Greater Sky Whale Alpha | [[Regions/Stormreach\|Stormreach]] | Alpha | SS- | 218 | 160 m | Day | Like a typical Greater Sky Whale, but larger and scarred, and others of its kind follow it, with salt-crusted, barnacle-flecked hide. |
| `pop_05746` | Stormreach Greater Sky Whale Juvenile | [[Regions/Stormreach\|Stormreach]] | Juvenile | S- | 173 | 108.8 m | Day | Like a typical Greater Sky Whale, but young, with brighter colors and unworn features, with salt-crusted, barnacle-flecked hide. |

## Design recipe

Rig `rig_fish` · mesh `fish_base` · material `fur_soft` · VFX `wind_ribbons` · palette `#a8e6cf` `#dcedc1` `#5b8c85` · circle-based, soft silhouette
