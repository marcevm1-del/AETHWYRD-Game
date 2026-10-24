---
type: monster
id: mon_vesper_touched_shadow_wisp
family: "Shadows"
rank: "D-"
tier: variant
tags: [monster, shadows]
---
# Vesper-Touched Shadow Wisp

![[mon_vesper_touched_shadow_wisp_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_vesper_touched_shadow_wisp_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Vesper-Touched Shadow Wisp is a tiny creature with a floating, cloth-like shape, about 0.4 m tall. Its smoke-like body is patchy and subtly wrong, as if assembled from memory, colored in ink black with bruised violet. Its most striking feature is a flickering smudge of darkness. It has eyes that never blink. A distinctive marking runs along its back. It glides without moving its legs, surrounded by shadows that lean toward it. Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.

| Field | Value |
|---|---|
| Family · type | [[Families/Shadows|Shadows]] · Spirit |
| Variant of | [[Monsters/Shadows/Shadow Wisp\|Shadow Wisp]] (corrupted) |
| Rank · level | D- · 40 (32–48) |
| Menace | 4 · Dread |
| Element · weakness | Dark · Light |
| Size | 0.4 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1437 · 102 · 119 · 238 · 221 · 90 |
| XP · gold | 1106 · 265 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/spirit_float\|spirit_float]] · `anim_floating` |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Umbravel\|Umbravel]] |
| Genre | Dungeon Crawl |
| Trope | Dungeon-born shadow warriors (DanMachi War Shadows) |

**Field note:** Weak to Light. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/spirit_float|spirit_float]] (rigId); animation set `anim_floating`.
- **Dimensions:** 0.4 m high × 0.12 m long × 0.26 m wide; prefab scale 0.4.
- **Physics:** 0.5 kg, gravity ×0, poise 6, knockback resistance 0.06, death style `dissolve_into_motes`.
- **Navigation:** speed 3.96 m/s, turn 900°/s, stopping distance 0.5 m.
- **Attack count:** 5; **signature:** a flickering smudge of darkness.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Chill Touch\|Chill Touch]] | melee | 0.9 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Phase Lunge\|Phase Lunge]] | dash | 1.3 | 7 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Wail\|Wail]] | aoe | 1.2 | 12 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Shade Step Strike\|Shade Step Strike]] | dash | 1.4 | 7 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Vesper-Touched Shadow Wisp is a **dread spirit** encountered at D- rank, around level 40. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a flickering smudge of darkness. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Umbravel|Umbravel]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_floating`, animation set `anim_floating`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Shadows D|loot_shadow_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Shade Essence\|Shade Essence]] | 60% | 1–3 |
| [[Items/Night Shard\|Night Shard]] | 30% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 6 | D-, D, E+, C-, D+, E | 26–65 | Night |
| [[Regions/Umbravel\|Umbravel]] | 5 | D-, D+, C-, D, E+ | 32–65 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03881` | Great Labyrinth (Floors 1-40) Vesper-Touched Shadow Wisp | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Adult | D- | 40 | 0.4 m | Night | A typical adult Vesper-Touched Shadow Wisp of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_03882` | Great Labyrinth (Floors 1-40) Vesper-Touched Shadow Wisp Scarred | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Scarred | D | 48 | 0.44 m | Night | Like a typical Vesper-Touched Shadow Wisp, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_03883` | Umbravel Vesper-Touched Shadow Wisp | [[Regions/Umbravel\|Umbravel]] | Adult | D- | 40 | 0.4 m | Night | A typical adult Vesper-Touched Shadow Wisp of this region, with bioluminescent spots along its body. |
| `pop_03884` | Great Labyrinth (Floors 1-40) Vesper-Touched Shadow Wisp Juvenile | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Juvenile | E+ | 32 | 0.34 m | Night | Like a typical Vesper-Touched Shadow Wisp, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_03885` | Umbravel Vesper-Touched Shadow Wisp Alpha | [[Regions/Umbravel\|Umbravel]] | Alpha | D+ | 56 | 0.5 m | Night | Like a typical Vesper-Touched Shadow Wisp, but larger and scarred, and others of its kind follow it, with bioluminescent spots along its body. |
| `pop_03886` | Umbravel Vesper-Touched Shadow Wisp Elderborn | [[Regions/Umbravel\|Umbravel]] | Elderborn | C- | 65 | 0.54 m | Night | Like a typical Vesper-Touched Shadow Wisp, but old and wise, with greying features and a cautious hunting style, with bioluminescent spots along its body. |
| `pop_03887` | Great Labyrinth (Floors 1-40) Vesper-Touched Shadow Wisp Elderborn | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Elderborn | C- | 65 | 0.54 m | Night | Like a typical Vesper-Touched Shadow Wisp, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_03888` | Umbravel Vesper-Touched Shadow Wisp Scarred | [[Regions/Umbravel\|Umbravel]] | Scarred | D | 48 | 0.44 m | Night | Like a typical Vesper-Touched Shadow Wisp, but covered in old battle scars, with bioluminescent spots along its body. |
| `pop_03889` | Great Labyrinth (Floors 1-40) Vesper-Touched Shadow Wisp Alpha | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Alpha | D+ | 56 | 0.5 m | Night | Like a typical Vesper-Touched Shadow Wisp, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_03890` | Great Labyrinth (Floors 1-40) Vesper-Touched Shadow Wisp Runt | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Runt | E | 26 | 0.28 m | Night | Like a typical Vesper-Touched Shadow Wisp, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_03891` | Umbravel Vesper-Touched Shadow Wisp Juvenile | [[Regions/Umbravel\|Umbravel]] | Juvenile | E+ | 32 | 0.34 m | Night | Like a typical Vesper-Touched Shadow Wisp, but young, with brighter colors and unworn features, with bioluminescent spots along its body. |

## Design recipe

Rig `rig_floating` · mesh `floating_base` · material `shadow_smoke` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · elongated, irregular silhouette; still-then-sudden timing
