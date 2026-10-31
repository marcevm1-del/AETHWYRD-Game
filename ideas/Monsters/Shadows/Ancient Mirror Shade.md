---
type: monster
id: mon_ancient_mirror_shade
family: "Shadows"
rank: "A"
tier: variant
tags: [monster, shadows]
---
# Ancient Mirror Shade

![[mon_ancient_mirror_shade_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_ancient_mirror_shade_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (3,012 tris · 1.629 × 0.978 × 2.7 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Ancient Mirror Shade is a large creature with a broad-shouldered humanoid build, about 2.7 m tall. Its smoke-like body is stretched, stitched and constantly shifting, colored in smoky violet. Look for your own silhouette, a heartbeat behind you. It has no eyes at all, only a wide and patient mouth. An elegant crest and glowing veins of mana mark it as a champion of its kind. It crawls across ceilings, surrounded by shadows that lean toward it. Moss, crystals and centuries-old scars cover its body; it has outlived every hunter sent after it.

| Field | Value |
|---|---|
| Family · type | [[Families/Shadows|Shadows]] · Spirit |
| Variant of | [[Monsters/Shadows/Mirror Shade\|Mirror Shade]] (ancient) |
| Rank · level | A · 146 (132–159) |
| Menace | 5 · Horror |
| Element · weakness | Dark · Light |
| Size | 2.7 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 24532 · 713 · 594 · 475 · 535 · 100 |
| XP · gold | 8719 · 1611 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/Aurumdeep\|Aurumdeep]], [[Regions/The Maw\|The Maw]] |
| Genre | Dungeon Crawl |
| Trope | Dungeon-born shadow warriors (DanMachi War Shadows) |

**Field note:** Weak to Light. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 2.7 m high × 0.81 m long × 0.86 m wide; prefab scale 1.5.
- **Physics:** 255.9 kg, gravity ×1.5, poise 107, knockback resistance 0.45, death style `ragdoll`.
- **Navigation:** speed 6.98 m/s, turn 243°/s, stopping distance 0.86 m.
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

Ancient Mirror Shade is a **horror spirit** encountered at A rank, around level 146. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** your own silhouette, a heartbeat behind you. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]], [[Regions/Aurumdeep|Aurumdeep]], [[Regions/The Maw|The Maw]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Shadows A|loot_shadow_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Shade Essence\|Shade Essence]] | 60% | 1–3 |
| [[Items/Night Shard\|Night Shard]] | 30% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Aurumdeep\|Aurumdeep]] | 4 | S, A-, A, B+ | 120–188 | Night |
| [[Regions/The Maw\|The Maw]] | 5 | A+, A-, B+, S- | 120–173 | Night |
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 2 | A+, S- | 159–173 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03925` | Aurumdeep Ancient Mirror Shade Elderborn | [[Regions/Aurumdeep\|Aurumdeep]] | Elderborn | S | 188 | 3.65 m | Night | Like a typical Ancient Mirror Shade, but old and wise, with greying features and a cautious hunting style, with bioluminescent spots along its body. |
| `pop_03926` | The Maw Ancient Mirror Shade Scarred | [[Regions/The Maw\|The Maw]] | Scarred | A+ | 159 | 2.97 m | Night | Like a typical Ancient Mirror Shade, but covered in old battle scars, with bioluminescent spots along its body. |
| `pop_03927` | Aurumdeep Ancient Mirror Shade Juvenile | [[Regions/Aurumdeep\|Aurumdeep]] | Juvenile | A- | 132 | 2.29 m | Night | Like a typical Ancient Mirror Shade, but young, with brighter colors and unworn features, with bioluminescent spots along its body. |
| `pop_03928` | Aurumdeep Ancient Mirror Shade | [[Regions/Aurumdeep\|Aurumdeep]] | Adult | A | 146 | 2.7 m | Night | A typical adult Ancient Mirror Shade of this region, with bioluminescent spots along its body. |
| `pop_03929` | Great Labyrinth (Floors 41-90) Ancient Mirror Shade Albino | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Albino | A+ | 159 | 2.7 m | Night | Like a typical Ancient Mirror Shade, but a rare pale form with white skin or fur and red eyes. |
| `pop_03930` | The Maw Ancient Mirror Shade Juvenile | [[Regions/The Maw\|The Maw]] | Juvenile | A- | 132 | 2.29 m | Night | Like a typical Ancient Mirror Shade, but young, with brighter colors and unworn features, with bioluminescent spots along its body. |
| `pop_03931` | Aurumdeep Ancient Mirror Shade Runt | [[Regions/Aurumdeep\|Aurumdeep]] | Runt | B+ | 120 | 1.89 m | Night | Like a typical Ancient Mirror Shade, but smaller and scrappier than usual, with bioluminescent spots along its body. |
| `pop_03932` | The Maw Ancient Mirror Shade Albino | [[Regions/The Maw\|The Maw]] | Albino | A+ | 159 | 2.7 m | Night | Like a typical Ancient Mirror Shade, but a rare pale form with white skin or fur and red eyes. |
| `pop_03933` | The Maw Ancient Mirror Shade Runt | [[Regions/The Maw\|The Maw]] | Runt | B+ | 120 | 1.89 m | Night | Like a typical Ancient Mirror Shade, but smaller and scrappier than usual, with bioluminescent spots along its body. |
| `pop_03934` | Great Labyrinth (Floors 41-90) Ancient Mirror Shade Alpha | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Alpha | S- | 173 | 3.38 m | Night | Like a typical Ancient Mirror Shade, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_03935` | The Maw Ancient Mirror Shade Alpha | [[Regions/The Maw\|The Maw]] | Alpha | S- | 173 | 3.38 m | Night | Like a typical Ancient Mirror Shade, but larger and scarred, and others of its kind follow it, with bioluminescent spots along its body. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `shadow_smoke` · VFX `shadow_wisps` · palette `#565584` `#464672` `#9a86d8` · broken symmetry, mimicry, audio-first reveal
