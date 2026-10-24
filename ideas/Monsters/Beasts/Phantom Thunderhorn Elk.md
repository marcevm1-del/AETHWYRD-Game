---
type: monster
id: mon_phantom_thunderhorn_elk
family: "Beasts"
rank: "C+"
tier: variant
tags: [monster, beasts]
---
# Phantom Thunderhorn Elk

![[mon_phantom_thunderhorn_elk_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_phantom_thunderhorn_elk_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,314 tris · 0.963 × 2.8 × 1.881 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Phantom Thunderhorn Elk is a large creature with a long-legged predatory quadruped build, about 2.8 m long. Its coat is rough, scarred and spiked, colored in warm gold and pearl white. Look for branching antlers that crackle in storms. It has burning slit pupils. Battle-worn plates and trophies hang from its body. It charges without hesitation, surrounded by soft radiance and floating motes of light. Its body is translucent blue, half in the spirit world; weapons pass through it unless they are blessed or enchanted.

| Field | Value |
|---|---|
| Family · type | [[Families/Beasts|Beasts]] · Beast |
| Variant of | [[Monsters/Beasts/Thunderhorn Elk\|Thunderhorn Elk]] (spirit) |
| Rank · level | C+ · 86 (76–96) |
| Menace | 3 · Menacing |
| Element · weakness | Light · Dark |
| Size | 2.8 m |
| Behaviour | Pack (pack_flank) |
| HP · ATK · DEF · MATK · MDEF · SPD | 11279 · 425 · 354 · 283 · 319 · 100 |
| XP · gold | 3743 · 769 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/quad_large\|quad_large]] · `anim_quad_large` |
| Habitats | [[Regions/Shen-Lu\|Shen-Lu]], [[Regions/Hoshizora\|Hoshizora]] |
| Genre | Classic Fantasy |
| Trope | The horned rabbit "rookie killer" and wolf packs of every isekai starter forest |

**Field note:** Weak to Dark. Never alone. Kill the leader first and the rest may scatter.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_large|quad_large]] (rigId); animation set `anim_quad_large`.
- **Dimensions:** 1.82 m high × 2.8 m long × 0.45 m wide; prefab scale 0.7.
- **Physics:** 417.1 kg, gravity ×1.08, poise 85, knockback resistance 0.94, death style `heavy_fall_dust`.
- **Navigation:** speed 6.78 m/s, turn 191°/s, stopping distance 0.96 m.
- **Attack count:** 5; **signature:** branching antlers that crackle in storms.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Maul\|Maul]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Pounce\|Pounce]] | dash | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Howl\|Howl]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Rending Bite\|Rending Bite]] | melee | 1.3 | 5 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Radiant Pulse\|Radiant Pulse]] | magic | 1.5 | 10 s | Light | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Phantom Thunderhorn Elk is a **menacing beast** encountered at C+ rank, around level 86. Its documented behaviour is *Pack* and its AI pattern is *pack_flank*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Dark**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** branching antlers that crackle in storms. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Shen-Lu|Shen-Lu]], [[Regions/Hoshizora|Hoshizora]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

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
| [[Regions/Hoshizora\|Hoshizora]] | 6 | C, C-, B-, C+, B, B+ | 65–120 | Day & Night |
| [[Regions/Shen-Lu\|Shen-Lu]] | 5 | B+, B-, B, C- | 65–120 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03346` | Hoshizora Phantom Thunderhorn Elk Juvenile | [[Regions/Hoshizora\|Hoshizora]] | Juvenile | C | 76 | 2.38 m | Day & Night | Like a typical Phantom Thunderhorn Elk, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_03347` | Hoshizora Phantom Thunderhorn Elk Runt | [[Regions/Hoshizora\|Hoshizora]] | Runt | C- | 65 | 1.96 m | Day & Night | Like a typical Phantom Thunderhorn Elk, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_03348` | Shen-Lu Phantom Thunderhorn Elk Elderborn | [[Regions/Shen-Lu\|Shen-Lu]] | Elderborn | B+ | 120 | 3.78 m | Day & Night | Like a typical Phantom Thunderhorn Elk, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_03349` | Hoshizora Phantom Thunderhorn Elk Scarred | [[Regions/Hoshizora\|Hoshizora]] | Scarred | B- | 96 | 3.08 m | Day & Night | Like a typical Phantom Thunderhorn Elk, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_03350` | Hoshizora Phantom Thunderhorn Elk | [[Regions/Hoshizora\|Hoshizora]] | Adult | C+ | 86 | 2.8 m | Day & Night | A typical adult Phantom Thunderhorn Elk of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_03351` | Hoshizora Phantom Thunderhorn Elk Alpha | [[Regions/Hoshizora\|Hoshizora]] | Alpha | B | 108 | 3.5 m | Day & Night | Like a typical Phantom Thunderhorn Elk, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_03352` | Shen-Lu Phantom Thunderhorn Elk Scarred | [[Regions/Shen-Lu\|Shen-Lu]] | Scarred | B- | 96 | 3.08 m | Day & Night | Like a typical Phantom Thunderhorn Elk, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_03353` | Shen-Lu Phantom Thunderhorn Elk Alpha | [[Regions/Shen-Lu\|Shen-Lu]] | Alpha | B | 108 | 3.5 m | Day & Night | Like a typical Phantom Thunderhorn Elk, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_03354` | Shen-Lu Phantom Thunderhorn Elk Albino | [[Regions/Shen-Lu\|Shen-Lu]] | Albino | B- | 96 | 2.8 m | Day & Night | Like a typical Phantom Thunderhorn Elk, but a rare pale form with white skin or fur and red eyes. |
| `pop_03355` | Shen-Lu Phantom Thunderhorn Elk Runt | [[Regions/Shen-Lu\|Shen-Lu]] | Runt | C- | 65 | 1.96 m | Day & Night | Like a typical Phantom Thunderhorn Elk, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_03356` | Hoshizora Phantom Thunderhorn Elk Elderborn | [[Regions/Hoshizora\|Hoshizora]] | Elderborn | B+ | 120 | 3.78 m | Day & Night | Like a typical Phantom Thunderhorn Elk, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `fur_groom` · VFX `holy_motes` · palette `#fff3b0` `#ffd166` `#ffffff` · triangle-based silhouette, sharp asymmetric spikes
