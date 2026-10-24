---
type: monster
id: mon_ancient_shade_hound
family: "Shadows"
rank: "C+"
tier: variant
tags: [monster, shadows]
---
# Ancient Shade Hound

> The Ancient Shade Hound is a person-sized creature with a long-legged predatory quadruped build, about 2.1 m long. Its smoke-like body is patchy and subtly wrong, as if assembled from memory, colored in ink black with bruised violet. Guild sketches always show a dog made of smoke with ember eyes. It has eyes that never blink. Battle-worn plates and trophies hang from its body. It glides without moving its legs, surrounded by shadows that lean toward it. Moss, crystals and centuries-old scars cover its body; it has outlived every hunter sent after it.

| Field | Value |
|---|---|
| Family · type | [[Families/Shadows|Shadows]] · Spirit |
| Variant of | [[Monsters/Shadows/Shade Hound\|Shade Hound]] (ancient) |
| Rank · level | C+ · 86 (76–96) |
| Menace | 4 · Dread |
| Element · weakness | Dark · Light |
| Size | 2.1 m |
| Behaviour | Aggressive (aggressive_chase+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 10227 · 425 · 354 · 283 · 319 · 100 |
| XP · gold | 3743 · 769 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/quad_large\|quad_large]] · `anim_quad_large` |
| Habitats | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Umbravel\|Umbravel]] |
| Genre | Dungeon Crawl |
| Trope | Dungeon-born shadow warriors (DanMachi War Shadows) |

**Field note:** Weak to Light. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_large|quad_large]] (rigId); animation set `anim_quad_large`.
- **Dimensions:** 1.37 m high × 2.1 m long × 0.34 m wide; prefab scale 0.525.
- **Physics:** 185.2 kg, gravity ×1.2, poise 74, knockback resistance 0.94, death style `heavy_fall_dust`.
- **Navigation:** speed 6.15 m/s, turn 221°/s, stopping distance 0.82 m.
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

Ancient Shade Hound is a **dread spirit** encountered at C+ rank, around level 86. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a dog made of smoke with ember eyes. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]], [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Umbravel|Umbravel]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_large`, animation set `anim_quad_large`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Shadows C|loot_shadow_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Shade Essence\|Shade Essence]] | 60% | 1–3 |
| [[Items/Night Shard\|Night Shard]] | 30% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 4 | C+, B-, B+, C- | 65–120 | Night |
| [[Regions/Umbravel\|Umbravel]] | 5 | B-, B, B+, C, C+ | 76–120 | Night |
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 2 | B-, B | 96–108 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03903` | Great Labyrinth (Floors 1-40) Ancient Shade Hound | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Adult | C+ | 86 | 2.1 m | Night | A typical adult Ancient Shade Hound of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_03904` | Umbravel Ancient Shade Hound Scarred | [[Regions/Umbravel\|Umbravel]] | Scarred | B- | 96 | 2.31 m | Night | Like a typical Ancient Shade Hound, but covered in old battle scars, with bioluminescent spots along its body. |
| `pop_03905` | Great Labyrinth (Floors 1-40) Ancient Shade Hound Scarred | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Scarred | B- | 96 | 2.31 m | Night | Like a typical Ancient Shade Hound, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_03906` | Great Labyrinth (Floors 41-90) Ancient Shade Hound Scarred | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Scarred | B- | 96 | 2.31 m | Night | Like a typical Ancient Shade Hound, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_03907` | Umbravel Ancient Shade Hound Alpha | [[Regions/Umbravel\|Umbravel]] | Alpha | B | 108 | 2.63 m | Night | Like a typical Ancient Shade Hound, but larger and scarred, and others of its kind follow it, with bioluminescent spots along its body. |
| `pop_03908` | Great Labyrinth (Floors 1-40) Ancient Shade Hound Elderborn | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Elderborn | B+ | 120 | 2.84 m | Night | Like a typical Ancient Shade Hound, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_03909` | Umbravel Ancient Shade Hound Elderborn | [[Regions/Umbravel\|Umbravel]] | Elderborn | B+ | 120 | 2.84 m | Night | Like a typical Ancient Shade Hound, but old and wise, with greying features and a cautious hunting style, with bioluminescent spots along its body. |
| `pop_03910` | Umbravel Ancient Shade Hound Juvenile | [[Regions/Umbravel\|Umbravel]] | Juvenile | C | 76 | 1.78 m | Night | Like a typical Ancient Shade Hound, but young, with brighter colors and unworn features, with bioluminescent spots along its body. |
| `pop_03911` | Great Labyrinth (Floors 1-40) Ancient Shade Hound Runt | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Runt | C- | 65 | 1.47 m | Night | Like a typical Ancient Shade Hound, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_03912` | Umbravel Ancient Shade Hound | [[Regions/Umbravel\|Umbravel]] | Adult | C+ | 86 | 2.1 m | Night | A typical adult Ancient Shade Hound of this region, with bioluminescent spots along its body. |
| `pop_03913` | Great Labyrinth (Floors 41-90) Ancient Shade Hound Alpha | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Alpha | B | 108 | 2.63 m | Night | Like a typical Ancient Shade Hound, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `shadow_smoke` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · elongated, irregular silhouette; still-then-sudden timing
