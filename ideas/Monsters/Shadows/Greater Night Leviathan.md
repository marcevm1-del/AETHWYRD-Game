---
type: monster
id: mon_greater_night_leviathan
family: "Shadows"
rank: "SS"
tier: variant
tags: [monster, shadows]
---
# Greater Night Leviathan

![[mon_greater_night_leviathan_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_greater_night_leviathan_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 30,000 tris · 16.529 × 48 × 30.152 m · local file `Game/Assets/_Game/Art/Models/Monsters/Shadows/mon_greater_night_leviathan.fbx`

> The Greater Night Leviathan is a colossal creature with a long, finned body, about 48 m long. Its smoke-like body is patchy and subtly wrong, as if assembled from memory, colored in smoky violet, with violet-edged markings. Survivors describe a shadow whale that swims through walls. It has eyes that never blink. The air distorts slightly around its outline. It freezes whenever it is looked at, surrounded by warped air, as if space bends around it. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Shadows|Shadows]] · Spirit |
| Variant of | [[Monsters/Shadows/Night Leviathan\|Night Leviathan]] (elder) |
| Rank · level | SS · 236 (218–253) |
| Menace | 4 · Dread |
| Element · weakness | Void · Light |
| Size | 48 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 100573 · 1193 · 859 · 859 · 859 · 100 |
| XP · gold | 18792 · 3152 |
| Ring | 8 |
| Rig · animation | [[Systems/Rigs/aquatic\|aquatic]] · `anim_fish` |
| Habitats | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]], [[Regions/The Maw\|The Maw]] |
| Genre | Dungeon Crawl |
| Trope | Dungeon-born shadow warriors (DanMachi War Shadows) |

**Field note:** Weak to Light. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/aquatic|aquatic]] (rigId); animation set `anim_fish`.
- **Dimensions:** 19.2 m high × 48 m long × 17.28 m wide; prefab scale 32.
- **Physics:** 2543616 kg, gravity ×0.7, poise 18462, knockback resistance 0.51, death style `float_belly_up`.
- **Navigation:** speed 32.02 m/s, turn 60°/s, stopping distance 6.16 m.
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

Greater Night Leviathan is a **dread spirit** encountered at SS rank, around level 236. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a shadow whale that swims through walls. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 91-120)|Great Labyrinth (Floors 91-120)]], [[Regions/The Maw|The Maw]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_fish`, animation set `anim_fish`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Shadows SS|loot_shadow_ss]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Shade Essence\|Shade Essence]] | 60% | 1–3 |
| [[Items/Night Shard\|Night Shard]] | 30% | 1–1 |
| [[Items/SS-Rank Monster Core\|SS-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/The Maw\|The Maw]] | 6 | SS+, SSS, SS-, SSS-, S+ | 203–281 | Night |
| [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | 5 | SS, SS-, S+, SS+ | 203–253 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03947` | The Maw Greater Night Leviathan Albino | [[Regions/The Maw\|The Maw]] | Albino | SS+ | 253 | 48 m | Night | Like a typical Greater Night Leviathan, but a rare pale form with white skin or fur and red eyes. |
| `pop_03948` | Great Labyrinth (Floors 91-120) Greater Night Leviathan | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Adult | SS | 236 | 48 m | Night | A typical adult Greater Night Leviathan of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_03949` | The Maw Greater Night Leviathan Elderborn | [[Regions/The Maw\|The Maw]] | Elderborn | SSS | 281 | 64.8 m | Night | Like a typical Greater Night Leviathan, but old and wise, with greying features and a cautious hunting style, with bioluminescent spots along its body. |
| `pop_03950` | Great Labyrinth (Floors 91-120) Greater Night Leviathan Juvenile | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Juvenile | SS- | 218 | 40.8 m | Night | Like a typical Greater Night Leviathan, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_03951` | Great Labyrinth (Floors 91-120) Greater Night Leviathan Runt | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Runt | S+ | 203 | 33.6 m | Night | Like a typical Greater Night Leviathan, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_03952` | The Maw Greater Night Leviathan Juvenile | [[Regions/The Maw\|The Maw]] | Juvenile | SS- | 218 | 40.8 m | Night | Like a typical Greater Night Leviathan, but young, with brighter colors and unworn features, with bioluminescent spots along its body. |
| `pop_03953` | Great Labyrinth (Floors 91-120) Greater Night Leviathan Scarred | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Scarred | SS+ | 253 | 52.8 m | Night | Like a typical Greater Night Leviathan, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_03954` | Great Labyrinth (Floors 91-120) Greater Night Leviathan Albino | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Albino | SS+ | 253 | 48 m | Night | Like a typical Greater Night Leviathan, but a rare pale form with white skin or fur and red eyes. |
| `pop_03955` | The Maw Greater Night Leviathan Alpha | [[Regions/The Maw\|The Maw]] | Alpha | SSS- | 267 | 60 m | Night | Like a typical Greater Night Leviathan, but larger and scarred, and others of its kind follow it, with bioluminescent spots along its body. |
| `pop_03956` | The Maw Greater Night Leviathan Scarred | [[Regions/The Maw\|The Maw]] | Scarred | SS+ | 253 | 52.8 m | Night | Like a typical Greater Night Leviathan, but covered in old battle scars, with bioluminescent spots along its body. |
| `pop_03957` | The Maw Greater Night Leviathan Runt | [[Regions/The Maw\|The Maw]] | Runt | S+ | 203 | 33.6 m | Night | Like a typical Greater Night Leviathan, but smaller and scrappier than usual, with bioluminescent spots along its body. |

## Design recipe

Rig `rig_fish` · mesh `fish_base` · material `shadow_smoke` · VFX `void_distortion` · palette `#51517d` `#42436b` `#8a7cff` · elongated, irregular silhouette; still-then-sudden timing
