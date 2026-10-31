---
type: monster
id: mon_elder_war_shadow
family: "Shadows"
rank: "C"
tier: variant
tags: [monster, shadows]
---
# Elder War Shadow

![[mon_elder_war_shadow_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_elder_war_shadow_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,474 tris · 1.228 × 0.785 × 3.2 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Elder War Shadow is a large creature with a broad-shouldered humanoid build, about 3.2 m tall. Its smoke-like body is patchy and subtly wrong, as if assembled from memory, colored in storm-grey, with violet markings. Survivors describe a humanoid silhouette with blades for hands. It has eyes that never blink. Battle-worn plates and trophies hang from its body. It glides without moving its legs, surrounded by shadows that lean toward it. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Shadows|Shadows]] · Spirit |
| Variant of | [[Monsters/Shadows/War Shadow\|War Shadow]] (elder) |
| Rank · level | C · 76 (65–86) |
| Menace | 4 · Dread |
| Element · weakness | Dark · Light |
| Size | 3.2 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 9816 · 377 · 314 · 251 · 283 · 100 |
| XP · gold | 3073 · 648 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Umbravel\|Umbravel]] |
| Genre | Dungeon Crawl |
| Trope | Dungeon-born shadow warriors (DanMachi War Shadows) |

**Field note:** Weak to Light. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 3.2 m high × 0.96 m long × 1.02 m wide; prefab scale 1.778.
- **Physics:** 426 kg, gravity ×1.5, poise 97, knockback resistance 0.39, death style `ragdoll`.
- **Navigation:** speed 7.24 m/s, turn 224°/s, stopping distance 0.94 m.
- **Attack count:** 5; **signature:** a humanoid silhouette with blades for hands.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Shade Step Strike\|Shade Step Strike]] | dash | 1.4 | 7 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Elder War Shadow is a **dread spirit** encountered at C rank, around level 76. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a humanoid silhouette with blades for hands. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]], [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Umbravel|Umbravel]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

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
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 5 | C+, B, C-, C | 65–108 | Night |
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 3 | C+, D+, C | 56–86 | Night |
| [[Regions/Umbravel\|Umbravel]] | 3 | C+, C-, D+ | 56–86 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03892` | Great Labyrinth (Floors 41-90) Elder War Shadow Scarred | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Scarred | C+ | 86 | 3.52 m | Night | Like a typical Elder War Shadow, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_03893` | Great Labyrinth (Floors 1-40) Elder War Shadow Scarred | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Scarred | C+ | 86 | 3.52 m | Night | Like a typical Elder War Shadow, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_03894` | Great Labyrinth (Floors 41-90) Elder War Shadow Elderborn | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Elderborn | B | 108 | 4.32 m | Night | Like a typical Elder War Shadow, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_03895` | Umbravel Elder War Shadow Albino | [[Regions/Umbravel\|Umbravel]] | Albino | C+ | 86 | 3.2 m | Night | Like a typical Elder War Shadow, but a rare pale form with white skin or fur and red eyes. |
| `pop_03896` | Great Labyrinth (Floors 41-90) Elder War Shadow Juvenile | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Juvenile | C- | 65 | 2.72 m | Night | Like a typical Elder War Shadow, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_03897` | Umbravel Elder War Shadow Juvenile | [[Regions/Umbravel\|Umbravel]] | Juvenile | C- | 65 | 2.72 m | Night | Like a typical Elder War Shadow, but young, with brighter colors and unworn features, with bioluminescent spots along its body. |
| `pop_03898` | Great Labyrinth (Floors 41-90) Elder War Shadow | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Adult | C | 76 | 3.2 m | Night | A typical adult Elder War Shadow of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_03899` | Great Labyrinth (Floors 1-40) Elder War Shadow Runt | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Runt | D+ | 56 | 2.24 m | Night | Like a typical Elder War Shadow, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_03900` | Umbravel Elder War Shadow Runt | [[Regions/Umbravel\|Umbravel]] | Runt | D+ | 56 | 2.24 m | Night | Like a typical Elder War Shadow, but smaller and scrappier than usual, with bioluminescent spots along its body. |
| `pop_03901` | Great Labyrinth (Floors 41-90) Elder War Shadow Albino | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Albino | C+ | 86 | 3.2 m | Night | Like a typical Elder War Shadow, but a rare pale form with white skin or fur and red eyes. |
| `pop_03902` | Great Labyrinth (Floors 1-40) Elder War Shadow | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Adult | C | 76 | 3.2 m | Night | A typical adult Elder War Shadow of this region, with pale, light-starved coloring and oversized eyes. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `shadow_smoke` · VFX `shadow_wisps` · palette `#545577` `#41405b` `#9a86d8` · elongated, irregular silhouette; still-then-sudden timing
