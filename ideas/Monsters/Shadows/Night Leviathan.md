---
type: monster
id: mon_night_leviathan
family: "Shadows"
rank: "S"
tier: core
tags: [monster, shadows]
---
# Night Leviathan

![[mon_night_leviathan_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_night_leviathan_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (950 tris · 10.617 × 30 × 18.279 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Night Leviathan is a colossal creature with a heavy-jawed fish frame, about 30 m long. Its smoke-like body is patchy and subtly wrong, as if assembled from memory, colored in smoky violet, with violet-edged markings. Guild sketches always show a shadow whale that swims through walls. It has eyes that never blink. Its regal silhouette is crowned by a halo-like ring of aura. It freezes whenever it is looked at, surrounded by warped air, as if space bends around it.

| Field | Value |
|---|---|
| Family · type | [[Families/Shadows|Shadows]] · Spirit |
| Rank · level | S · 188 (173–203) |
| Menace | 4 · Dread |
| Element · weakness | Void · Light |
| Size | 30 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 64647 · 953 · 686 · 686 · 686 · 100 |
| XP · gold | 13063 · 2293 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/aquatic\|aquatic]] · `anim_fish` |
| Habitats | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]], [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] |
| Genre | Dungeon Crawl |
| Trope | Dungeon-born shadow warriors (DanMachi War Shadows) |

**Field note:** Weak to Light. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/aquatic|aquatic]] (rigId); animation set `anim_fish`.
- **Dimensions:** 12 m high × 30 m long × 10.8 m wide; prefab scale 20.
- **Physics:** 621000 kg, gravity ×0.7, poise 8259, knockback resistance 0.48, death style `float_belly_up`.
- **Navigation:** speed 25.32 m/s, turn 73°/s, stopping distance 4 m.
- **Attack count:** 5; **signature:** a shadow whale that swims through walls.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Bite\|Bite]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Breach Lunge\|Breach Lunge]] | dash | 1.7 | 9 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Thrash\|Thrash]] | aoe | 1.3 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Shade Step Strike\|Shade Step Strike]] | dash | 1.4 | 7 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Null Rift\|Null Rift]] | magic | 1.5 | 10 s | Void | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Night Leviathan is a **dread spirit** encountered at S rank, around level 188. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a shadow whale that swims through walls. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 91-120)|Great Labyrinth (Floors 91-120)]], [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_fish`, animation set `anim_fish`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Shadows S|loot_shadow_s]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Shade Essence\|Shade Essence]] | 60% | 1–3 |
| [[Items/Night Shard\|Night Shard]] | 30% | 1–1 |
| [[Items/S-Rank Monster Core\|S-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Shadows/Greater Night Leviathan|Greater Night Leviathan]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | 7 | S+, S-, A+, S, SS-, SS | 159–236 | Night |
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 4 | S+, S, A+ | 159–203 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01050` | Great Labyrinth (Floors 91-120) Night Leviathan Scarred | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Scarred | S+ | 203 | 33 m | Night | Like a typical Night Leviathan, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_01051` | Great Labyrinth (Floors 91-120) Night Leviathan Juvenile | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Juvenile | S- | 173 | 25.5 m | Night | Like a typical Night Leviathan, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_01052` | Great Labyrinth (Floors 91-120) Night Leviathan Runt | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Runt | A+ | 159 | 21 m | Night | Like a typical Night Leviathan, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_01053` | Great Labyrinth (Floors 41-90) Night Leviathan Scarred | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Scarred | S+ | 203 | 33 m | Night | Like a typical Night Leviathan, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_01054` | Great Labyrinth (Floors 41-90) Night Leviathan | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Adult | S | 188 | 30 m | Night | A typical adult Night Leviathan of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_01055` | Great Labyrinth (Floors 91-120) Night Leviathan | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Adult | S | 188 | 30 m | Night | A typical adult Night Leviathan of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_01056` | Great Labyrinth (Floors 41-90) Night Leviathan Runt | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Runt | A+ | 159 | 21 m | Night | Like a typical Night Leviathan, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_01057` | Great Labyrinth (Floors 91-120) Night Leviathan Albino | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Albino | S+ | 203 | 30 m | Night | Like a typical Night Leviathan, but a rare pale form with white skin or fur and red eyes. |
| `pop_01058` | Great Labyrinth (Floors 91-120) Night Leviathan Alpha | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Alpha | SS- | 218 | 37.5 m | Night | Like a typical Night Leviathan, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_01059` | Great Labyrinth (Floors 41-90) Night Leviathan Albino | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Albino | S+ | 203 | 30 m | Night | Like a typical Night Leviathan, but a rare pale form with white skin or fur and red eyes. |
| `pop_01060` | Great Labyrinth (Floors 91-120) Night Leviathan Elderborn | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Elderborn | SS | 236 | 40.5 m | Night | Like a typical Night Leviathan, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |

## Design recipe

Rig `rig_fish` · mesh `fish_base` · material `shadow_smoke` · VFX `void_distortion` · palette `#56517d` `#47426c` `#8a7cff` · elongated, irregular silhouette; still-then-sudden timing
