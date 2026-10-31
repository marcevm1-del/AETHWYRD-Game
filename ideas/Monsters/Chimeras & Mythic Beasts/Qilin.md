---
type: monster
id: mon_qilin
family: "Chimeras & Mythic Beasts"
rank: "S"
tier: core
tags: [monster, chimeras-mythic-beasts]
---
# Qilin

![[mon_qilin_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_qilin_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,756 tris · 0.773 × 3 × 1.535 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Qilin is a large creature with a powerful four-legged hunter's body, about 3 m long. Its hide is smooth and clean, colored in lion-tawny, with gold markings. Look for scales, antlers and hooves that never bend the grass. It has two bright dot eyes. Its regal silhouette is crowned by a halo-like ring of aura. It waddles, surrounded by soft radiance and floating motes of light.

| Field | Value |
|---|---|
| Family · type | [[Families/Chimeras & Mythic Beasts|Chimeras & Mythic Beasts]] · Mythic Beast |
| Rank · level | S · 188 (173–203) |
| Menace | 1 · Charming |
| Element · weakness | Light · Dark |
| Size | 3 m |
| Behaviour | Guardian (guardian_hold) |
| HP · ATK · DEF · MATK · MDEF · SPD | 37099 · 914 · 762 · 610 · 686 · 100 |
| XP · gold | 13063 · 2293 |
| Ring | 7 |
| Rig · animation | [[Systems/Rigs/quad_large\|quad_large]] · `anim_quad_large` |
| Habitats | [[Regions/Heavenreach\|Heavenreach]], [[Regions/Sky Archipelago\|Sky Archipelago]] |
| Genre | World Myth |
| Trope | Greek, Persian and East Asian mythic beasts |

**Field note:** Weak to Dark. Protects something nearby: a nest, a treasure, or a place.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_large|quad_large]] (rigId); animation set `anim_quad_large`.
- **Dimensions:** 1.95 m high × 3 m long × 0.48 m wide; prefab scale 0.75.
- **Physics:** 513 kg, gravity ×1.08, poise 115, knockback resistance 1, death style `heavy_fall_dust`.
- **Navigation:** speed 5.16 m/s, turn 185°/s, stopping distance 1 m.
- **Attack count:** 5; **signature:** scales, antlers and hooves that never bend the grass.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Maul\|Maul]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Pounce\|Pounce]] | dash | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Howl\|Howl]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Many-Headed Bite\|Many-Headed Bite]] | melee | 1.5 | 7 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Radiant Pulse\|Radiant Pulse]] | magic | 1.5 | 10 s | Light | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Qilin is a **charming mythic beast** encountered at S rank, around level 188. Its documented behaviour is *Guardian* and its AI pattern is *guardian_hold*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Dark**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** scales, antlers and hooves that never bend the grass. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Heavenreach|Heavenreach]], [[Regions/Sky Archipelago|Sky Archipelago]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_large`, animation set `anim_quad_large`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Chimeras & Mythic Beasts S|loot_chimera_s]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Chimera Heart\|Chimera Heart]] | 60% | 1–3 |
| [[Items/Mythic Horn\|Mythic Horn]] | 30% | 1–1 |
| [[Items/S-Rank Monster Core\|S-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Chimeras & Mythic Beasts/Ancient Qilin|Ancient Qilin]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Sky Archipelago\|Sky Archipelago]] | 6 | A+, SS, S-, S, S+, SS- | 159–236 | Day |
| [[Regions/Heavenreach\|Heavenreach]] | 5 | SS-, S+, SS, A+, S | 159–236 | Day |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02229` | Sky Archipelago Qilin Runt | [[Regions/Sky Archipelago\|Sky Archipelago]] | Runt | A+ | 159 | 2.1 m | Day | Like a typical Qilin, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_02230` | Sky Archipelago Qilin Elderborn | [[Regions/Sky Archipelago\|Sky Archipelago]] | Elderborn | SS | 236 | 4.05 m | Day | Like a typical Qilin, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_02231` | Heavenreach Qilin Alpha | [[Regions/Heavenreach\|Heavenreach]] | Alpha | SS- | 218 | 3.75 m | Day | Like a typical Qilin, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_02232` | Sky Archipelago Qilin Juvenile | [[Regions/Sky Archipelago\|Sky Archipelago]] | Juvenile | S- | 173 | 2.55 m | Day | Like a typical Qilin, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_02233` | Sky Archipelago Qilin | [[Regions/Sky Archipelago\|Sky Archipelago]] | Adult | S | 188 | 3 m | Day | A typical adult Qilin of this region, with dust-grey coloring and old rune scars. |
| `pop_02234` | Heavenreach Qilin Scarred | [[Regions/Heavenreach\|Heavenreach]] | Scarred | S+ | 203 | 3.3 m | Day | Like a typical Qilin, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_02235` | Heavenreach Qilin Elderborn | [[Regions/Heavenreach\|Heavenreach]] | Elderborn | SS | 236 | 4.05 m | Day | Like a typical Qilin, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_02236` | Sky Archipelago Qilin Scarred | [[Regions/Sky Archipelago\|Sky Archipelago]] | Scarred | S+ | 203 | 3.3 m | Day | Like a typical Qilin, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_02237` | Sky Archipelago Qilin Alpha | [[Regions/Sky Archipelago\|Sky Archipelago]] | Alpha | SS- | 218 | 3.75 m | Day | Like a typical Qilin, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_02238` | Heavenreach Qilin Runt | [[Regions/Heavenreach\|Heavenreach]] | Runt | A+ | 159 | 2.1 m | Day | Like a typical Qilin, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_02239` | Heavenreach Qilin | [[Regions/Heavenreach\|Heavenreach]] | Adult | S | 188 | 3 m | Day | A typical adult Qilin of this region, with slate-grey coloring and hardened hide. |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `mixed_hide` · VFX `holy_motes` · palette `#c09f57` `#7e6539` `#ffd166` · circle-based, soft silhouette
