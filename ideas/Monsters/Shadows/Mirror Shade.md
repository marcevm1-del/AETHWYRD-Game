---
type: monster
id: mon_mirror_shade
family: "Shadows"
rank: "B"
tier: core
tags: [monster, shadows]
---
# Mirror Shade

![[mon_mirror_shade_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_mirror_shade_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Mirror Shade is a person-sized creature with a broad-shouldered humanoid build, about 1.8 m tall. Its smoke-like body is stretched, stitched and constantly shifting, colored in ink black with bruised violet. Guild sketches always show your own silhouette, a heartbeat behind you. It has a human-like face in the wrong place. Faint runes glow along its body when it fights. It crawls across ceilings, surrounded by shadows that lean toward it.

| Field | Value |
|---|---|
| Family · type | [[Families/Shadows|Shadows]] · Spirit |
| Rank · level | B · 108 (96–120) |
| Menace | 5 · Horror |
| Element · weakness | Dark · Light |
| Size | 1.8 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 13619 · 530 · 442 · 354 · 398 · 100 |
| XP · gold | 5386 · 1057 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/Umbravel\|Umbravel]], [[Regions/Aurumdeep\|Aurumdeep]], [[Regions/Iron Hold\|Iron Hold]] |
| Genre | Dungeon Crawl |
| Trope | Dungeon-born shadow warriors (DanMachi War Shadows) |

**Field note:** Weak to Light. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 1.8 m high × 0.54 m long × 0.58 m wide; prefab scale 1.
- **Physics:** 75.8 kg, gravity ×1.5, poise 80, knockback resistance 0.42, death style `ragdoll`.
- **Navigation:** speed 5.7 m/s, turn 298°/s, stopping distance 0.71 m.
- **Attack count:** 5; **signature:** your own silhouette, a heartbeat behind you.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Shade Step Strike\|Shade Step Strike]] | dash | 1.4 | 7 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Mirror Shade is a **horror spirit** encountered at B rank, around level 108. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** your own silhouette, a heartbeat behind you. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]], [[Regions/Umbravel|Umbravel]], [[Regions/Aurumdeep|Aurumdeep]], [[Regions/Iron Hold|Iron Hold]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Shadows B|loot_shadow_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Shade Essence\|Shade Essence]] | 60% | 1–3 |
| [[Items/Night Shard\|Night Shard]] | 30% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Shadows/Ancient Mirror Shade|Ancient Mirror Shade]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 3 | B+, A- | 120–132 | Night |
| [[Regions/Iron Hold\|Iron Hold]] | 4 | B, C+, A, B+ | 86–146 | Night |
| [[Regions/Umbravel\|Umbravel]] | 3 | B+, A | 120–146 | Night |
| [[Regions/Aurumdeep\|Aurumdeep]] | 1 | A | 146–146 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01028` | Great Labyrinth (Floors 41-90) Mirror Shade Scarred | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Scarred | B+ | 120 | 1.98 m | Night | Like a typical Mirror Shade, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_01029` | Iron Hold Mirror Shade | [[Regions/Iron Hold\|Iron Hold]] | Adult | B | 108 | 1.8 m | Night | A typical adult Mirror Shade of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_01030` | Umbravel Mirror Shade Scarred | [[Regions/Umbravel\|Umbravel]] | Scarred | B+ | 120 | 1.98 m | Night | Like a typical Mirror Shade, but covered in old battle scars, with bioluminescent spots along its body. |
| `pop_01031` | Iron Hold Mirror Shade Runt | [[Regions/Iron Hold\|Iron Hold]] | Runt | C+ | 86 | 1.26 m | Night | Like a typical Mirror Shade, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_01032` | Umbravel Mirror Shade Elderborn | [[Regions/Umbravel\|Umbravel]] | Elderborn | A | 146 | 2.43 m | Night | Like a typical Mirror Shade, but old and wise, with greying features and a cautious hunting style, with bioluminescent spots along its body. |
| `pop_01033` | Aurumdeep Mirror Shade Elderborn | [[Regions/Aurumdeep\|Aurumdeep]] | Elderborn | A | 146 | 2.43 m | Night | Like a typical Mirror Shade, but old and wise, with greying features and a cautious hunting style, with bioluminescent spots along its body. |
| `pop_01034` | Umbravel Mirror Shade Albino | [[Regions/Umbravel\|Umbravel]] | Albino | B+ | 120 | 1.8 m | Night | Like a typical Mirror Shade, but a rare pale form with white skin or fur and red eyes. |
| `pop_01035` | Iron Hold Mirror Shade Elderborn | [[Regions/Iron Hold\|Iron Hold]] | Elderborn | A | 146 | 2.43 m | Night | Like a typical Mirror Shade, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_01036` | Great Labyrinth (Floors 41-90) Mirror Shade Albino | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Albino | B+ | 120 | 1.8 m | Night | Like a typical Mirror Shade, but a rare pale form with white skin or fur and red eyes. |
| `pop_01037` | Great Labyrinth (Floors 41-90) Mirror Shade Alpha | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Alpha | A- | 132 | 2.25 m | Night | Like a typical Mirror Shade, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_01038` | Iron Hold Mirror Shade Scarred | [[Regions/Iron Hold\|Iron Hold]] | Scarred | B+ | 120 | 1.98 m | Night | Like a typical Mirror Shade, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `shadow_smoke` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · broken symmetry, mimicry, audio-first reveal
