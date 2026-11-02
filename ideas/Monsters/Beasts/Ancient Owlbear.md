---
type: monster
id: mon_ancient_owlbear
family: "Beasts"
rank: "C+"
tier: variant
tags: [monster, beasts]
---
# Ancient Owlbear

![[mon_ancient_owlbear_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_ancient_owlbear_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,646 tris · 0.884 × 3.9 × 1.751 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Ancient Owlbear is a large creature with a long-legged predatory quadruped build, about 3.9 m long. Its coat is rough, scarred and spiked, colored in warm brown. Its most striking feature is an owl's feathered face on a bear's muscled body. It has narrow glowing eyes. Battle-worn plates and trophies hang from its body. It strides with heavy steps. It has no visible aura; you hear its breathing before you see it. Moss, crystals and centuries-old scars cover its body; it has outlived every hunter sent after it.

| Field | Value |
|---|---|
| Family · type | [[Families/Beasts|Beasts]] · Beast |
| Variant of | [[Monsters/Beasts/Owlbear\|Owlbear]] (ancient) |
| Rank · level | C+ · 86 (76–96) |
| Menace | 3 · Menacing |
| Element · weakness | None · Fire |
| Size | 3.9 m |
| Behaviour | Skittish (skittish_flee) |
| HP · ATK · DEF · MATK · MDEF · SPD | 12593 · 425 · 354 · 198 · 319 · 100 |
| XP · gold | 3743 · 769 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/quad_large\|quad_large]] · `anim_quad_large` |
| Habitats | [[Regions/Shen-Lu\|Shen-Lu]], [[Regions/Moraveil\|Moraveil]], [[Regions/Hoshizora\|Hoshizora]] |
| Genre | Classic Fantasy |
| Trope | The horned rabbit "rookie killer" and wolf packs of every isekai starter forest |

**Field note:** Weak to Fire. Flees when hurt. Snares or ranged attacks work best.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_large|quad_large]] (rigId); animation set `anim_quad_large`.
- **Dimensions:** 2.54 m high × 3.9 m long × 0.62 m wide; prefab scale 0.975.
- **Physics:** 1186.4 kg, gravity ×1.2, poise 100, knockback resistance 0.94, death style `heavy_fall_dust`.
- **Navigation:** speed 9.15 m/s, turn 162°/s, stopping distance 1.18 m.
- **Attack count:** 4; **signature:** an owl's feathered face on a bear's muscled body.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Maul\|Maul]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Pounce\|Pounce]] | dash | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Howl\|Howl]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Rending Bite\|Rending Bite]] | melee | 1.3 | 5 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |

## Field guide

Ancient Owlbear is a **menacing beast** encountered at C+ rank, around level 86. Its documented behaviour is *Skittish* and its AI pattern is *skittish_flee*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** an owl's feathered face on a bear's muscled body. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Shen-Lu|Shen-Lu]], [[Regions/Moraveil|Moraveil]], [[Regions/Hoshizora|Hoshizora]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_large`, animation set `anim_quad_large`; keep silhouette, movement and signature attack legible at gameplay camera distance.

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
| [[Regions/Hoshizora\|Hoshizora]] | 6 | C-, B-, B+, C+, C, B | 65–120 | Day & Night |
| [[Regions/Moraveil\|Moraveil]] | 3 | B-, B+, C- | 65–120 | Day & Night |
| [[Regions/Shen-Lu\|Shen-Lu]] | 2 | B-, B | 96–108 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03335` | Hoshizora Ancient Owlbear Runt | [[Regions/Hoshizora\|Hoshizora]] | Runt | C- | 65 | 2.73 m | Day & Night | Like a typical Ancient Owlbear, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_03336` | Moraveil Ancient Owlbear Albino | [[Regions/Moraveil\|Moraveil]] | Albino | B- | 96 | 3.9 m | Day & Night | Like a typical Ancient Owlbear, but a rare pale form with white skin or fur and red eyes. |
| `pop_03337` | Moraveil Ancient Owlbear Elderborn | [[Regions/Moraveil\|Moraveil]] | Elderborn | B+ | 120 | 5.27 m | Day & Night | Like a typical Ancient Owlbear, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_03338` | Hoshizora Ancient Owlbear Albino | [[Regions/Hoshizora\|Hoshizora]] | Albino | B- | 96 | 3.9 m | Day & Night | Like a typical Ancient Owlbear, but a rare pale form with white skin or fur and red eyes. |
| `pop_03339` | Hoshizora Ancient Owlbear Elderborn | [[Regions/Hoshizora\|Hoshizora]] | Elderborn | B+ | 120 | 5.27 m | Day & Night | Like a typical Ancient Owlbear, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_03340` | Hoshizora Ancient Owlbear | [[Regions/Hoshizora\|Hoshizora]] | Adult | C+ | 86 | 3.9 m | Day & Night | A typical adult Ancient Owlbear of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_03341` | Moraveil Ancient Owlbear Runt | [[Regions/Moraveil\|Moraveil]] | Runt | C- | 65 | 2.73 m | Day & Night | Like a typical Ancient Owlbear, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_03342` | Hoshizora Ancient Owlbear Juvenile | [[Regions/Hoshizora\|Hoshizora]] | Juvenile | C | 76 | 3.31 m | Day & Night | Like a typical Ancient Owlbear, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_03343` | Shen-Lu Ancient Owlbear Scarred | [[Regions/Shen-Lu\|Shen-Lu]] | Scarred | B- | 96 | 4.29 m | Day & Night | Like a typical Ancient Owlbear, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_03344` | Hoshizora Ancient Owlbear Alpha | [[Regions/Hoshizora\|Hoshizora]] | Alpha | B | 108 | 4.88 m | Day & Night | Like a typical Ancient Owlbear, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_03345` | Shen-Lu Ancient Owlbear Alpha | [[Regions/Shen-Lu\|Shen-Lu]] | Alpha | B | 108 | 4.88 m | Day & Night | Like a typical Ancient Owlbear, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `fur_groom` · VFX `dust_puffs` · palette `#92714a` `#5e4732` `#ca9a67` · triangle-based silhouette, sharp asymmetric spikes
