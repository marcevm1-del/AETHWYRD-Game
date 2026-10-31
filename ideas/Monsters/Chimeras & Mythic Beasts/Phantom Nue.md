---
type: monster
id: mon_phantom_nue
family: "Chimeras & Mythic Beasts"
rank: "B+"
tier: variant
tags: [monster, chimeras-mythic-beasts]
---
# Phantom Nue

![[mon_phantom_nue_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_phantom_nue_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (3,336 tris · 0.967 × 3 × 1.805 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Phantom Nue is a large creature with a long-legged predatory quadruped build, about 3 m long. Its hide is stretched, stitched and constantly shifting, colored in lion-tawny, with gold markings. Look for a monkey's face, a tiger's body and a snake for a tail. It has a human-like face in the wrong place. Faint runes glow along its body when it fights. It unfolds into something larger, surrounded by soft radiance and floating motes of light. Its body is translucent blue, half in the spirit world; weapons pass through it unless they are blessed or enchanted.

| Field | Value |
|---|---|
| Family · type | [[Families/Chimeras & Mythic Beasts|Chimeras & Mythic Beasts]] · Mythic Beast |
| Variant of | [[Monsters/Chimeras & Mythic Beasts/Nue\|Nue]] (spirit) |
| Rank · level | B+ · 120 (108–132) |
| Menace | 5 · Horror |
| Element · weakness | Light · Dark |
| Size | 3 m |
| Behaviour | Aggressive (aggressive_chase+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 18966 · 588 · 490 · 392 · 441 · 100 |
| XP · gold | 6373 · 1225 |
| Ring | 7 |
| Rig · animation | [[Systems/Rigs/quad_large\|quad_large]] · `anim_quad_large` |
| Habitats | [[Regions/Hoshizora\|Hoshizora]], [[Regions/Shen-Lu\|Shen-Lu]], [[Regions/Zarvan\|Zarvan]] |
| Genre | World Myth |
| Trope | Greek, Persian and East Asian mythic beasts |

**Field note:** Weak to Dark. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_large|quad_large]] (rigId); animation set `anim_quad_large`.
- **Dimensions:** 1.95 m high × 3 m long × 0.48 m wide; prefab scale 0.75.
- **Physics:** 513 kg, gravity ×1.08, poise 97, knockback resistance 0.97, death style `heavy_fall_dust`.
- **Navigation:** speed 7.36 m/s, turn 185°/s, stopping distance 1 m.
- **Attack count:** 5; **signature:** a monkey's face, a tiger's body and a snake for a tail.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Maul\|Maul]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Pounce\|Pounce]] | dash | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Howl\|Howl]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Many-Headed Bite\|Many-Headed Bite]] | melee | 1.5 | 7 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Radiant Pulse\|Radiant Pulse]] | magic | 1.5 | 10 s | Light | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Phantom Nue is a **horror mythic beast** encountered at B+ rank, around level 120. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Dark**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a monkey's face, a tiger's body and a snake for a tail. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Hoshizora|Hoshizora]], [[Regions/Shen-Lu|Shen-Lu]], [[Regions/Zarvan|Zarvan]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_large`, animation set `anim_quad_large`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Chimeras & Mythic Beasts B|loot_chimera_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Chimera Heart\|Chimera Heart]] | 60% | 1–3 |
| [[Items/Mythic Horn\|Mythic Horn]] | 30% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Hoshizora\|Hoshizora]] | 5 | B-, A-, A+, B+, A | 96–159 | Night |
| [[Regions/Shen-Lu\|Shen-Lu]] | 4 | A-, B+, A+, A | 120–159 | Night |
| [[Regions/Zarvan\|Zarvan]] | 2 | B, A+ | 108–159 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05037` | Hoshizora Phantom Nue Runt | [[Regions/Hoshizora\|Hoshizora]] | Runt | B- | 96 | 2.1 m | Night | Like a typical Phantom Nue, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_05038` | Shen-Lu Phantom Nue Albino | [[Regions/Shen-Lu\|Shen-Lu]] | Albino | A- | 132 | 3 m | Night | Like a typical Phantom Nue, but a rare pale form with white skin or fur and red eyes. |
| `pop_05039` | Hoshizora Phantom Nue Albino | [[Regions/Hoshizora\|Hoshizora]] | Albino | A- | 132 | 3 m | Night | Like a typical Phantom Nue, but a rare pale form with white skin or fur and red eyes. |
| `pop_05040` | Shen-Lu Phantom Nue | [[Regions/Shen-Lu\|Shen-Lu]] | Adult | B+ | 120 | 3 m | Night | A typical adult Phantom Nue of this region, with slate-grey coloring and hardened hide. |
| `pop_05041` | Shen-Lu Phantom Nue Elderborn | [[Regions/Shen-Lu\|Shen-Lu]] | Elderborn | A+ | 159 | 4.05 m | Night | Like a typical Phantom Nue, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_05042` | Zarvan Phantom Nue Juvenile | [[Regions/Zarvan\|Zarvan]] | Juvenile | B | 108 | 2.55 m | Night | Like a typical Phantom Nue, but young, with brighter colors and unworn features, with sun-bleached, sand-scoured coloring. |
| `pop_05043` | Shen-Lu Phantom Nue Alpha | [[Regions/Shen-Lu\|Shen-Lu]] | Alpha | A | 146 | 3.75 m | Night | Like a typical Phantom Nue, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_05044` | Zarvan Phantom Nue Elderborn | [[Regions/Zarvan\|Zarvan]] | Elderborn | A+ | 159 | 4.05 m | Night | Like a typical Phantom Nue, but old and wise, with greying features and a cautious hunting style, with sun-bleached, sand-scoured coloring. |
| `pop_05045` | Hoshizora Phantom Nue Elderborn | [[Regions/Hoshizora\|Hoshizora]] | Elderborn | A+ | 159 | 4.05 m | Night | Like a typical Phantom Nue, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_05046` | Hoshizora Phantom Nue | [[Regions/Hoshizora\|Hoshizora]] | Adult | B+ | 120 | 3 m | Night | A typical adult Phantom Nue of this region, with slate-grey coloring and hardened hide. |
| `pop_05047` | Hoshizora Phantom Nue Alpha | [[Regions/Hoshizora\|Hoshizora]] | Alpha | A | 146 | 3.75 m | Night | Like a typical Phantom Nue, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `mixed_hide` · VFX `holy_motes` · palette `#bda156` `#7b6638` `#ffd166` · broken symmetry, mimicry, audio-first reveal
