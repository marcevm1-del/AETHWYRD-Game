---
type: monster
id: mon_umbral_reaper
family: "Shadows"
rank: "A"
tier: core
tags: [monster, shadows]
---
# Umbral Reaper

![[mon_umbral_reaper_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_umbral_reaper_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (1,394 tris · 1.822 × 2.037 × 3 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Umbral Reaper is a large creature with a drifting, half-formed body, about 3 m tall. Its smoke-like body is patchy and subtly wrong, as if assembled from memory, colored in smoky violet. Look for a scythe of night and a hood with no face. It has eyes that never blink. An elegant crest and glowing veins of mana mark it as a champion of its kind. It freezes whenever it is looked at, surrounded by shadows that lean toward it.

| Field | Value |
|---|---|
| Family · type | [[Families/Shadows|Shadows]] · Spirit |
| Rank · level | A · 146 (132–159) |
| Menace | 4 · Dread |
| Element · weakness | Dark · Light |
| Size | 3 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 18487 · 356 · 416 · 832 · 772 · 90 |
| XP · gold | 8719 · 1611 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/spirit_float\|spirit_float]] · `anim_floating` |
| Habitats | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/Aurumdeep\|Aurumdeep]], [[Regions/The Maw\|The Maw]] |
| Genre | Dungeon Crawl |
| Trope | Dungeon-born shadow warriors (DanMachi War Shadows) |

**Field note:** Weak to Light. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/spirit_float|spirit_float]] (rigId); animation set `anim_floating`.
- **Dimensions:** 3 m high × 0.9 m long × 1.92 m wide; prefab scale 3.
- **Physics:** 2.7 kg, gravity ×0, poise 39, knockback resistance 0.15, death style `dissolve_into_motes`.
- **Navigation:** speed 10.85 m/s, turn 416°/s, stopping distance 1.15 m.
- **Attack count:** 5; **signature:** a scythe of night and a hood with no face.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Chill Touch\|Chill Touch]] | melee | 0.9 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Phase Lunge\|Phase Lunge]] | dash | 1.3 | 7 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Wail\|Wail]] | aoe | 1.2 | 12 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Shade Step Strike\|Shade Step Strike]] | dash | 1.4 | 7 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Umbral Reaper is a **dread spirit** encountered at A rank, around level 146. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a scythe of night and a hood with no face. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]], [[Regions/Aurumdeep|Aurumdeep]], [[Regions/The Maw|The Maw]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_floating`, animation set `anim_floating`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Shadows A|loot_shadow_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Shade Essence\|Shade Essence]] | 60% | 1–3 |
| [[Items/Night Shard\|Night Shard]] | 30% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Shadows/Greater Umbral Reaper|Greater Umbral Reaper]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 4 | A+, S, S-, A | 146–188 | Night |
| [[Regions/The Maw\|The Maw]] | 3 | S, B+, A | 120–188 | Night |
| [[Regions/Aurumdeep\|Aurumdeep]] | 4 | S-, B+, A+ | 120–173 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01039` | Great Labyrinth (Floors 41-90) Umbral Reaper Scarred | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Scarred | A+ | 159 | 3.3 m | Night | Like a typical Umbral Reaper, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_01040` | Great Labyrinth (Floors 41-90) Umbral Reaper Elderborn | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Elderborn | S | 188 | 4.05 m | Night | Like a typical Umbral Reaper, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_01041` | The Maw Umbral Reaper Elderborn | [[Regions/The Maw\|The Maw]] | Elderborn | S | 188 | 4.05 m | Night | Like a typical Umbral Reaper, but old and wise, with greying features and a cautious hunting style, with bioluminescent spots along its body. |
| `pop_01042` | Aurumdeep Umbral Reaper Alpha | [[Regions/Aurumdeep\|Aurumdeep]] | Alpha | S- | 173 | 3.75 m | Night | Like a typical Umbral Reaper, but larger and scarred, and others of its kind follow it, with bioluminescent spots along its body. |
| `pop_01043` | Aurumdeep Umbral Reaper Runt | [[Regions/Aurumdeep\|Aurumdeep]] | Runt | B+ | 120 | 2.1 m | Night | Like a typical Umbral Reaper, but smaller and scrappier than usual, with bioluminescent spots along its body. |
| `pop_01044` | The Maw Umbral Reaper Runt | [[Regions/The Maw\|The Maw]] | Runt | B+ | 120 | 2.1 m | Night | Like a typical Umbral Reaper, but smaller and scrappier than usual, with bioluminescent spots along its body. |
| `pop_01045` | Great Labyrinth (Floors 41-90) Umbral Reaper Alpha | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Alpha | S- | 173 | 3.75 m | Night | Like a typical Umbral Reaper, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_01046` | Aurumdeep Umbral Reaper Scarred | [[Regions/Aurumdeep\|Aurumdeep]] | Scarred | A+ | 159 | 3.3 m | Night | Like a typical Umbral Reaper, but covered in old battle scars, with bioluminescent spots along its body. |
| `pop_01047` | Great Labyrinth (Floors 41-90) Umbral Reaper | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Adult | A | 146 | 3 m | Night | A typical adult Umbral Reaper of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_01048` | Aurumdeep Umbral Reaper Albino | [[Regions/Aurumdeep\|Aurumdeep]] | Albino | A+ | 159 | 3 m | Night | Like a typical Umbral Reaper, but a rare pale form with white skin or fur and red eyes. |
| `pop_01049` | The Maw Umbral Reaper | [[Regions/The Maw\|The Maw]] | Adult | A | 146 | 3 m | Night | A typical adult Umbral Reaper of this region, with bioluminescent spots along its body. |

## Design recipe

Rig `rig_floating` · mesh `floating_base` · material `shadow_smoke` · VFX `shadow_wisps` · palette `#5a4e79` `#4b4069` `#9a86d8` · elongated, irregular silhouette; still-then-sudden timing
