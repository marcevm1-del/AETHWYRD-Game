---
type: monster
id: mon_crag_kobold_trapmaster
family: "Kobolds"
rank: "D+"
tier: variant
tags: [monster, kobolds]
---
# Crag Kobold Trapmaster

![[mon_crag_kobold_trapmaster_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_crag_kobold_trapmaster_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,348 tris · 0.495 × 0.583 × 1 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Crag Kobold Trapmaster is a small creature with a small, compact humanoid body, about 1 m tall. Its mangy fur is rough, scarred and spiked, colored in rust-red, with ochre markings. Guild sketches always show a harness of gears, springs and tripwires. It has burning slit pupils. A distinctive marking runs along its back. It circles its prey, surrounded by pebbles that tremble and float near it. Adapted to mountain lands, it has slate-grey coloring and hardened hide.

| Field | Value |
|---|---|
| Family · type | [[Families/Kobolds|Kobolds]] · Humanoid |
| Variant of | [[Monsters/Kobolds/Kobold Trapmaster\|Kobold Trapmaster]] (regional) |
| Rank · level | D+ · 56 (48–65) |
| Menace | 3 · Menacing |
| Element · weakness | Earth · Wind |
| Size | 1 m |
| Behaviour | Pack (pack_flank) |
| HP · ATK · DEF · MATK · MDEF · SPD | 3257 · 234 · 187 · 164 · 187 · 135 |
| XP · gold | 1888 · 423 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/small_biped\|small_biped]] · `anim_small_biped` |
| Habitats | [[Regions/Iron Hold\|Iron Hold]], [[Regions/Hoshizora\|Hoshizora]] |
| Genre | Dungeon Crawl |
| Trope | Dog-headed first-floor monsters (DanMachi), trap-builders (classic tabletop) |

**Field note:** Weak to Wind. Never alone. Kill the leader first and the rest may scatter.

## Motion implementation

- **Rig:** [[Systems/Rigs/small_biped|small_biped]] (rigId); animation set `anim_small_biped`.
- **Dimensions:** 1 m high × 0.3 m long × 0.4 m wide; prefab scale 0.909.
- **Physics:** 20.8 kg, gravity ×1.65, poise 37, knockback resistance 0.36, death style `ragdoll_crumple`.
- **Navigation:** speed 4.67 m/s, turn 420°/s, stopping distance 0.6 m.
- **Attack count:** 5; **signature:** a harness of gears, springs and tripwires.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stab\|Stab]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Thrown Junk\|Thrown Junk]] | ranged | 0.8 | 4 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Frenzied Lunge\|Frenzied Lunge]] | melee | 1.5 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Trip-Wire Trap\|Trip-Wire Trap]] | debuff | 0 | 14 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Crag Kobold Trapmaster is a **menacing humanoid** encountered at D+ rank, around level 56. Its documented behaviour is *Pack* and its AI pattern is *pack_flank*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a harness of gears, springs and tripwires. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Iron Hold|Iron Hold]], [[Regions/Hoshizora|Hoshizora]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_small_biped`, animation set `anim_small_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Kobolds D|loot_kobold_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Kobold Fang\|Kobold Fang]] | 60% | 1–3 |
| [[Items/Scrap Metal\|Scrap Metal]] | 30% | 1–1 |
| [[Items/Candle Stub\|Candle Stub]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Hoshizora\|Hoshizora]] | 6 | C, C-, C+, D, D+, D- | 40–86 | Day & Night |
| [[Regions/Iron Hold\|Iron Hold]] | 5 | C-, D-, C+, D | 40–86 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06077` | Hoshizora Crag Kobold Trapmaster Alpha | [[Regions/Hoshizora\|Hoshizora]] | Alpha | C | 76 | 1.25 m | Day & Night | Like a typical Crag Kobold Trapmaster, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_06078` | Iron Hold Crag Kobold Trapmaster Scarred | [[Regions/Iron Hold\|Iron Hold]] | Scarred | C- | 65 | 1.1 m | Day & Night | Like a typical Crag Kobold Trapmaster, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_06079` | Iron Hold Crag Kobold Trapmaster Runt | [[Regions/Iron Hold\|Iron Hold]] | Runt | D- | 40 | 0.7 m | Day & Night | Like a typical Crag Kobold Trapmaster, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_06080` | Iron Hold Crag Kobold Trapmaster Elderborn | [[Regions/Iron Hold\|Iron Hold]] | Elderborn | C+ | 86 | 1.35 m | Day & Night | Like a typical Crag Kobold Trapmaster, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_06081` | Iron Hold Crag Kobold Trapmaster Albino | [[Regions/Iron Hold\|Iron Hold]] | Albino | C- | 65 | 1 m | Day & Night | Like a typical Crag Kobold Trapmaster, but a rare pale form with white skin or fur and red eyes. |
| `pop_06082` | Hoshizora Crag Kobold Trapmaster Scarred | [[Regions/Hoshizora\|Hoshizora]] | Scarred | C- | 65 | 1.1 m | Day & Night | Like a typical Crag Kobold Trapmaster, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_06083` | Hoshizora Crag Kobold Trapmaster Elderborn | [[Regions/Hoshizora\|Hoshizora]] | Elderborn | C+ | 86 | 1.35 m | Day & Night | Like a typical Crag Kobold Trapmaster, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_06084` | Hoshizora Crag Kobold Trapmaster Juvenile | [[Regions/Hoshizora\|Hoshizora]] | Juvenile | D | 48 | 0.85 m | Day & Night | Like a typical Crag Kobold Trapmaster, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_06085` | Iron Hold Crag Kobold Trapmaster Juvenile | [[Regions/Iron Hold\|Iron Hold]] | Juvenile | D | 48 | 0.85 m | Day & Night | Like a typical Crag Kobold Trapmaster, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_06086` | Hoshizora Crag Kobold Trapmaster | [[Regions/Hoshizora\|Hoshizora]] | Adult | D+ | 56 | 1 m | Day & Night | A typical adult Crag Kobold Trapmaster of this region, with slate-grey coloring and hardened hide. |
| `pop_06087` | Hoshizora Crag Kobold Trapmaster Runt | [[Regions/Hoshizora\|Hoshizora]] | Runt | D- | 40 | 0.7 m | Day & Night | Like a typical Crag Kobold Trapmaster, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `fur_short` · VFX `rock_debris` · palette `#a36834` `#633d21` `#d1a15a` · triangle-based silhouette, sharp asymmetric spikes
