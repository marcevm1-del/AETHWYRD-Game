---
type: monster
id: mon_shade_hound
family: "Shadows"
rank: "D+"
tier: core
tags: [monster, shadows]
---
# Shade Hound

![[mon_shade_hound_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_shade_hound_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,180 tris · 0.431 × 1.4 × 1.188 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Shade Hound is a person-sized creature with a powerful four-legged hunter's body, about 1.4 m long. Its smoke-like body is patchy and subtly wrong, as if assembled from memory, colored in smoky violet. Its most striking feature is a dog made of smoke with ember eyes. It has eyes set slightly too far apart. A distinctive marking runs along its back. It glides without moving its legs, surrounded by shadows that lean toward it.

| Field | Value |
|---|---|
| Family · type | [[Families/Shadows|Shadows]] · Spirit |
| Rank · level | D+ · 56 (48–65) |
| Menace | 4 · Dread |
| Element · weakness | Dark · Light |
| Size | 1.4 m |
| Behaviour | Aggressive (aggressive_chase+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 4714 · 281 · 234 · 187 · 211 · 100 |
| XP · gold | 1888 · 423 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/quad_large\|quad_large]] · `anim_quad_large` |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Umbravel\|Umbravel]], [[Regions/Moraveil\|Moraveil]], [[Regions/Aldmere\|Aldmere]], [[Regions/Iron Hold\|Iron Hold]] |
| Genre | Dungeon Crawl |
| Trope | Dungeon-born shadow warriors (DanMachi War Shadows) |

**Field note:** Weak to Light. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_large|quad_large]] (rigId); animation set `anim_quad_large`.
- **Dimensions:** 0.91 m high × 1.4 m long × 0.22 m wide; prefab scale 0.35.
- **Physics:** 54.9 kg, gravity ×1.2, poise 54, knockback resistance 0.91, death style `heavy_fall_dust`.
- **Navigation:** speed 5.02 m/s, turn 270°/s, stopping distance 0.68 m.
- **Attack count:** 5; **signature:** a dog made of smoke with ember eyes.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Maul\|Maul]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Pounce\|Pounce]] | dash | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Howl\|Howl]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Shade Step Strike\|Shade Step Strike]] | dash | 1.4 | 7 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Shade Hound is a **dread spirit** encountered at D+ rank, around level 56. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a dog made of smoke with ember eyes. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Umbravel|Umbravel]], [[Regions/Moraveil|Moraveil]], [[Regions/Aldmere|Aldmere]], [[Regions/Iron Hold|Iron Hold]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_large`, animation set `anim_quad_large`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Shadows D|loot_shadow_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Shade Essence\|Shade Essence]] | 60% | 1–3 |
| [[Items/Night Shard\|Night Shard]] | 30% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Shadows/Ancient Shade Hound|Ancient Shade Hound]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Iron Hold\|Iron Hold]] | 3 | C+, D+, D | 48–86 | Night |
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 1 | D+ | 56–56 | Night |
| [[Regions/Moraveil\|Moraveil]] | 5 | C-, C+, C, D, D+ | 48–86 | Night |
| [[Regions/Aldmere\|Aldmere]] | 2 | D-, D | 40–48 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01006` | Iron Hold Shade Hound Elderborn | [[Regions/Iron Hold\|Iron Hold]] | Elderborn | C+ | 86 | 1.89 m | Night | Like a typical Shade Hound, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_01007` | Iron Hold Shade Hound | [[Regions/Iron Hold\|Iron Hold]] | Adult | D+ | 56 | 1.4 m | Night | A typical adult Shade Hound of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_01008` | Iron Hold Shade Hound Juvenile | [[Regions/Iron Hold\|Iron Hold]] | Juvenile | D | 48 | 1.19 m | Night | Like a typical Shade Hound, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_01009` | Great Labyrinth (Floors 1-40) Shade Hound | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Adult | D+ | 56 | 1.4 m | Night | A typical adult Shade Hound of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_01010` | Moraveil Shade Hound Albino | [[Regions/Moraveil\|Moraveil]] | Albino | C- | 65 | 1.4 m | Night | Like a typical Shade Hound, but a rare pale form with white skin or fur and red eyes. |
| `pop_01011` | Moraveil Shade Hound Elderborn | [[Regions/Moraveil\|Moraveil]] | Elderborn | C+ | 86 | 1.89 m | Night | Like a typical Shade Hound, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_01012` | Moraveil Shade Hound Alpha | [[Regions/Moraveil\|Moraveil]] | Alpha | C | 76 | 1.75 m | Night | Like a typical Shade Hound, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_01013` | Aldmere Shade Hound Runt | [[Regions/Aldmere\|Aldmere]] | Runt | D- | 40 | 0.98 m | Night | Like a typical Shade Hound, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_01014` | Moraveil Shade Hound Juvenile | [[Regions/Moraveil\|Moraveil]] | Juvenile | D | 48 | 1.19 m | Night | Like a typical Shade Hound, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_01015` | Aldmere Shade Hound Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | D | 48 | 1.19 m | Night | Like a typical Shade Hound, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_01016` | Moraveil Shade Hound | [[Regions/Moraveil\|Moraveil]] | Adult | D+ | 56 | 1.4 m | Night | A typical adult Shade Hound of this region, with pale, light-starved coloring and oversized eyes. |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `shadow_smoke` · VFX `shadow_wisps` · palette `#504e78` `#424068` `#9a86d8` · elongated, irregular silhouette; still-then-sudden timing
