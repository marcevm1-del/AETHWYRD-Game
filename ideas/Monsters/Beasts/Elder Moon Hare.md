---
type: monster
id: mon_elder_moon_hare
family: "Beasts"
rank: "C"
tier: variant
tags: [monster, beasts]
---
# Elder Moon Hare

![[mon_elder_moon_hare_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_elder_moon_hare_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Elder Moon Hare is a small creature with a small, quick four-legged body, about 0.8 m long. Its coat is smooth and clean, colored in warm gold and pearl white. Guild sketches always show white fur that glows under the full moon. It has wide curious eyes with star-shaped highlights. Battle-worn plates and trophies hang from its body. It waddles, surrounded by soft radiance and floating motes of light. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Beasts|Beasts]] · Beast |
| Variant of | [[Monsters/Beasts/Moon Hare\|Moon Hare]] (elder) |
| Rank · level | C · 76 (65–86) |
| Menace | 1 · Charming |
| Element · weakness | Light · Dark |
| Size | 0.8 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 4769 · 314 · 251 · 220 · 251 · 135 |
| XP · gold | 3073 · 648 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/quad_small\|quad_small]] · `anim_quad_small` |
| Habitats | [[Regions/Shen-Lu\|Shen-Lu]], [[Regions/Hoshizora\|Hoshizora]], [[Regions/Kitsune Isles\|Kitsune Isles]] |
| Genre | Classic Fantasy |
| Trope | The horned rabbit "rookie killer" and wolf packs of every isekai starter forest |

**Field note:** Weak to Dark. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_small|quad_small]] (rigId); animation set `anim_quad_small`.
- **Dimensions:** 0.54 m high × 0.8 m long × 0.11 m wide; prefab scale 1.6.
- **Physics:** 14.6 kg, gravity ×1.44, poise 37, knockback resistance 0.14, death style `ragdoll_tumble`.
- **Navigation:** speed 6.79 m/s, turn 604°/s, stopping distance 0.53 m.
- **Attack count:** 5; **signature:** white fur that glows under the full moon.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Bite\|Bite]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Charge\|Charge]] | dash | 1.3 | 5 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Leap\|Leap]] | dash | 1.2 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Rending Bite\|Rending Bite]] | melee | 1.3 | 5 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Radiant Pulse\|Radiant Pulse]] | magic | 1.5 | 10 s | Light | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Elder Moon Hare is a **charming beast** encountered at C rank, around level 76. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Dark**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** white fur that glows under the full moon. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Shen-Lu|Shen-Lu]], [[Regions/Hoshizora|Hoshizora]], [[Regions/Kitsune Isles|Kitsune Isles]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_small`, animation set `anim_quad_small`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Beasts C|loot_beast_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Pelt\|Pelt]] | 60% | 1–3 |
| [[Items/Fang\|Fang]] | 30% | 1–1 |
| [[Items/Prime Meat\|Prime Meat]] | 15% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Kitsune Isles\|Kitsune Isles]] | 3 | D+, B-, C- | 56–96 | Day |
| [[Regions/Hoshizora\|Hoshizora]] | 4 | B, D+, B-, C+ | 56–108 | Day |
| [[Regions/Shen-Lu\|Shen-Lu]] | 4 | C+, C-, C, B- | 65–96 | Day |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06264` | Kitsune Isles Elder Moon Hare Runt | [[Regions/Kitsune Isles\|Kitsune Isles]] | Runt | D+ | 56 | 0.56 m | Day | Like a typical Elder Moon Hare, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_06265` | Hoshizora Elder Moon Hare Elderborn | [[Regions/Hoshizora\|Hoshizora]] | Elderborn | B | 108 | 1.08 m | Day | Like a typical Elder Moon Hare, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_06266` | Shen-Lu Elder Moon Hare Scarred | [[Regions/Shen-Lu\|Shen-Lu]] | Scarred | C+ | 86 | 0.88 m | Day | Like a typical Elder Moon Hare, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_06267` | Shen-Lu Elder Moon Hare Juvenile | [[Regions/Shen-Lu\|Shen-Lu]] | Juvenile | C- | 65 | 0.68 m | Day | Like a typical Elder Moon Hare, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_06268` | Shen-Lu Elder Moon Hare | [[Regions/Shen-Lu\|Shen-Lu]] | Adult | C | 76 | 0.8 m | Day | A typical adult Elder Moon Hare of this region, with slate-grey coloring and hardened hide. |
| `pop_06269` | Hoshizora Elder Moon Hare Runt | [[Regions/Hoshizora\|Hoshizora]] | Runt | D+ | 56 | 0.56 m | Day | Like a typical Elder Moon Hare, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_06270` | Kitsune Isles Elder Moon Hare Alpha | [[Regions/Kitsune Isles\|Kitsune Isles]] | Alpha | B- | 96 | 1 m | Day | Like a typical Elder Moon Hare, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_06271` | Kitsune Isles Elder Moon Hare Juvenile | [[Regions/Kitsune Isles\|Kitsune Isles]] | Juvenile | C- | 65 | 0.68 m | Day | Like a typical Elder Moon Hare, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_06272` | Shen-Lu Elder Moon Hare Alpha | [[Regions/Shen-Lu\|Shen-Lu]] | Alpha | B- | 96 | 1 m | Day | Like a typical Elder Moon Hare, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_06273` | Hoshizora Elder Moon Hare Alpha | [[Regions/Hoshizora\|Hoshizora]] | Alpha | B- | 96 | 1 m | Day | Like a typical Elder Moon Hare, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_06274` | Hoshizora Elder Moon Hare Scarred | [[Regions/Hoshizora\|Hoshizora]] | Scarred | C+ | 86 | 0.88 m | Day | Like a typical Elder Moon Hare, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_quad_small` · mesh `quad_small_base` · material `fur_groom` · VFX `holy_motes` · palette `#fff3b0` `#ffd166` `#ffffff` · circle-based, soft silhouette
