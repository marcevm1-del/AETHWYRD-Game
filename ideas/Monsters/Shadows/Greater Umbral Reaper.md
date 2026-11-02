---
type: monster
id: mon_greater_umbral_reaper
family: "Shadows"
rank: "S"
tier: variant
tags: [monster, shadows]
---
# Greater Umbral Reaper

![[mon_greater_umbral_reaper_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_greater_umbral_reaper_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (1,394 tris · 2.916 × 3.259 × 4.8 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Greater Umbral Reaper is a large creature with a drifting, half-formed body, about 4.8 m tall. Its smoke-like body is patchy and subtly wrong, as if assembled from memory, colored in smoky violet. Its most striking feature is a scythe of night and a hood with no face. It has pale, pupil-less eyes. Its regal silhouette is crowned by a halo-like ring of aura. It freezes whenever it is looked at, surrounded by shadows that lean toward it. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Shadows|Shadows]] · Spirit |
| Variant of | [[Monsters/Shadows/Umbral Reaper\|Umbral Reaper]] (elder) |
| Rank · level | S · 188 (173–203) |
| Menace | 4 · Dread |
| Element · weakness | Dark · Light |
| Size | 4.8 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 31470 · 457 · 533 · 1067 · 991 · 90 |
| XP · gold | 13063 · 2293 |
| Ring | 7 |
| Rig · animation | [[Systems/Rigs/spirit_float\|spirit_float]] · `anim_floating` |
| Habitats | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]], [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] |
| Genre | Dungeon Crawl |
| Trope | Dungeon-born shadow warriors (DanMachi War Shadows) |

**Field note:** Weak to Light. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/spirit_float|spirit_float]] (rigId); animation set `anim_floating`.
- **Dimensions:** 4.8 m high × 1.44 m long × 3.07 m wide; prefab scale 4.8.
- **Physics:** 11.1 kg, gravity ×0, poise 87, knockback resistance 0.18, death style `dissolve_into_motes`.
- **Navigation:** speed 13.73 m/s, turn 329°/s, stopping distance 1.6 m.
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

Greater Umbral Reaper is a **dread spirit** encountered at S rank, around level 188. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a scythe of night and a hood with no face. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 91-120)|Great Labyrinth (Floors 91-120)]], [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_floating`, animation set `anim_floating`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Shadows S|loot_shadow_s]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Shade Essence\|Shade Essence]] | 60% | 1–3 |
| [[Items/Night Shard\|Night Shard]] | 30% | 1–1 |
| [[Items/S-Rank Monster Core\|S-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 6 | S-, SS, A+, S+, S, SS- | 159–236 | Night |
| [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | 5 | S+, S, SS, SS- | 188–236 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03936` | Great Labyrinth (Floors 41-90) Greater Umbral Reaper Juvenile | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Juvenile | S- | 173 | 4.08 m | Night | Like a typical Greater Umbral Reaper, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_03937` | Great Labyrinth (Floors 41-90) Greater Umbral Reaper Elderborn | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Elderborn | SS | 236 | 6.48 m | Night | Like a typical Greater Umbral Reaper, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_03938` | Great Labyrinth (Floors 41-90) Greater Umbral Reaper Runt | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Runt | A+ | 159 | 3.36 m | Night | Like a typical Greater Umbral Reaper, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_03939` | Great Labyrinth (Floors 91-120) Greater Umbral Reaper Scarred | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Scarred | S+ | 203 | 5.28 m | Night | Like a typical Greater Umbral Reaper, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_03940` | Great Labyrinth (Floors 41-90) Greater Umbral Reaper Scarred | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Scarred | S+ | 203 | 5.28 m | Night | Like a typical Greater Umbral Reaper, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_03941` | Great Labyrinth (Floors 91-120) Greater Umbral Reaper | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Adult | S | 188 | 4.8 m | Night | A typical adult Greater Umbral Reaper of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_03942` | Great Labyrinth (Floors 41-90) Greater Umbral Reaper | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Adult | S | 188 | 4.8 m | Night | A typical adult Greater Umbral Reaper of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_03943` | Great Labyrinth (Floors 91-120) Greater Umbral Reaper Elderborn | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Elderborn | SS | 236 | 6.48 m | Night | Like a typical Greater Umbral Reaper, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_03944` | Great Labyrinth (Floors 91-120) Greater Umbral Reaper Alpha | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Alpha | SS- | 218 | 6 m | Night | Like a typical Greater Umbral Reaper, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_03945` | Great Labyrinth (Floors 91-120) Greater Umbral Reaper Albino | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Albino | S+ | 203 | 4.8 m | Night | Like a typical Greater Umbral Reaper, but a rare pale form with white skin or fur and red eyes. |
| `pop_03946` | Great Labyrinth (Floors 41-90) Greater Umbral Reaper Alpha | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Alpha | SS- | 218 | 6 m | Night | Like a typical Greater Umbral Reaper, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |

## Design recipe

Rig `rig_floating` · mesh `floating_base` · material `shadow_smoke` · VFX `shadow_wisps` · palette `#52547f` `#44466e` `#9a86d8` · elongated, irregular silhouette; still-then-sudden timing
