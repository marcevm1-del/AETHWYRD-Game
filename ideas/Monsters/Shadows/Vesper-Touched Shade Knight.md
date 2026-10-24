---
type: monster
id: mon_vesper_touched_shade_knight
family: "Shadows"
rank: "B-"
tier: variant
tags: [monster, shadows]
---
# Vesper-Touched Shade Knight

![[mon_vesper_touched_shade_knight_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_vesper_touched_shade_knight_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,116 tris · 0.883 × 0.866 × 2.3 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Vesper-Touched Shade Knight is a person-sized creature with an upright humanoid build, about 2.3 m tall. Its smoke-like body is patchy and subtly wrong, as if assembled from memory, colored in ink black with bruised violet. Its most striking feature is armor with nothing but darkness inside. It has eyes set slightly too far apart. Faint runes glow along its body when it fights. It glides without moving its legs, surrounded by shadows that lean toward it. Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.

| Field | Value |
|---|---|
| Family · type | [[Families/Shadows|Shadows]] · Spirit |
| Variant of | [[Monsters/Shadows/Shade Knight\|Shade Knight]] (corrupted) |
| Rank · level | B- · 96 (86–108) |
| Menace | 4 · Dread |
| Element · weakness | Dark · Light |
| Size | 2.3 m |
| Behaviour | Aggressive (aggressive_chase+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 12427 · 473 · 394 · 315 · 355 · 100 |
| XP · gold | 4462 · 897 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/Umbravel\|Umbravel]] |
| Genre | Dungeon Crawl |
| Trope | Dungeon-born shadow warriors (DanMachi War Shadows) |

**Field note:** Weak to Light. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 2.3 m high × 0.69 m long × 0.74 m wide; prefab scale 1.278.
- **Physics:** 158.2 kg, gravity ×1.5, poise 90, knockback resistance 0.42, death style `ragdoll`.
- **Navigation:** speed 6.13 m/s, turn 264°/s, stopping distance 0.79 m.
- **Attack count:** 5; **signature:** armor with nothing but darkness inside.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Shade Step Strike\|Shade Step Strike]] | dash | 1.4 | 7 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Vesper-Touched Shade Knight is a **dread spirit** encountered at B- rank, around level 96. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** armor with nothing but darkness inside. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]], [[Regions/Umbravel|Umbravel]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Shadows B|loot_shadow_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Shade Essence\|Shade Essence]] | 60% | 1–3 |
| [[Items/Night Shard\|Night Shard]] | 30% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Umbravel\|Umbravel]] | 4 | A-, C+, B, B- | 86–132 | Night |
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 7 | B, C, B-, B+, C+, A- | 76–132 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03914` | Umbravel Vesper-Touched Shade Knight Elderborn | [[Regions/Umbravel\|Umbravel]] | Elderborn | A- | 132 | 3.1 m | Night | Like a typical Vesper-Touched Shade Knight, but old and wise, with greying features and a cautious hunting style, with bioluminescent spots along its body. |
| `pop_03915` | Great Labyrinth (Floors 41-90) Vesper-Touched Shade Knight Albino | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Albino | B | 108 | 2.3 m | Night | Like a typical Vesper-Touched Shade Knight, but a rare pale form with white skin or fur and red eyes. |
| `pop_03916` | Great Labyrinth (Floors 41-90) Vesper-Touched Shade Knight Runt | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Runt | C | 76 | 1.61 m | Night | Like a typical Vesper-Touched Shade Knight, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_03917` | Great Labyrinth (Floors 41-90) Vesper-Touched Shade Knight | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Adult | B- | 96 | 2.3 m | Night | A typical adult Vesper-Touched Shade Knight of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_03918` | Great Labyrinth (Floors 41-90) Vesper-Touched Shade Knight Alpha | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Alpha | B+ | 120 | 2.88 m | Night | Like a typical Vesper-Touched Shade Knight, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_03919` | Umbravel Vesper-Touched Shade Knight Juvenile | [[Regions/Umbravel\|Umbravel]] | Juvenile | C+ | 86 | 1.95 m | Night | Like a typical Vesper-Touched Shade Knight, but young, with brighter colors and unworn features, with bioluminescent spots along its body. |
| `pop_03920` | Great Labyrinth (Floors 41-90) Vesper-Touched Shade Knight Scarred | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Scarred | B | 108 | 2.53 m | Night | Like a typical Vesper-Touched Shade Knight, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_03921` | Great Labyrinth (Floors 41-90) Vesper-Touched Shade Knight Juvenile | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Juvenile | C+ | 86 | 1.95 m | Night | Like a typical Vesper-Touched Shade Knight, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_03922` | Umbravel Vesper-Touched Shade Knight Scarred | [[Regions/Umbravel\|Umbravel]] | Scarred | B | 108 | 2.53 m | Night | Like a typical Vesper-Touched Shade Knight, but covered in old battle scars, with bioluminescent spots along its body. |
| `pop_03923` | Umbravel Vesper-Touched Shade Knight | [[Regions/Umbravel\|Umbravel]] | Adult | B- | 96 | 2.3 m | Night | A typical adult Vesper-Touched Shade Knight of this region, with bioluminescent spots along its body. |
| `pop_03924` | Great Labyrinth (Floors 41-90) Vesper-Touched Shade Knight Elderborn | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Elderborn | A- | 132 | 3.1 m | Night | Like a typical Vesper-Touched Shade Knight, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `shadow_smoke` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · elongated, irregular silhouette; still-then-sudden timing
