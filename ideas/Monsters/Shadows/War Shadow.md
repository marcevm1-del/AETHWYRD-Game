---
type: monster
id: mon_war_shadow
family: "Shadows"
rank: "D"
tier: core
tags: [monster, shadows]
---
# War Shadow

![[mon_war_shadow_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_war_shadow_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The War Shadow is a person-sized creature with a broad-shouldered humanoid build, about 2 m tall. Its smoke-like body is patchy and subtly wrong, as if assembled from memory, colored in ink black with bruised violet. Survivors describe a humanoid silhouette with blades for hands. It has eyes that never blink. A distinctive marking runs along its back. It glides without moving its legs, surrounded by shadows that lean toward it.

| Field | Value |
|---|---|
| Family · type | [[Families/Shadows|Shadows]] · Spirit |
| Rank · level | D · 48 (40–56) |
| Menace | 4 · Dread |
| Element · weakness | Dark · Light |
| Size | 2 m |
| Behaviour | Aggressive (aggressive_chase+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 4242 · 242 · 202 · 162 · 182 · 100 |
| XP · gold | 1477 · 342 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Umbravel\|Umbravel]], [[Regions/Iron Hold\|Iron Hold]], [[Regions/Strife Marches\|Strife Marches]] |
| Genre | Dungeon Crawl |
| Trope | Dungeon-born shadow warriors (DanMachi War Shadows) |

**Field note:** Weak to Light. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 2 m high × 0.6 m long × 0.64 m wide; prefab scale 1.111.
- **Physics:** 104 kg, gravity ×1.5, poise 69, knockback resistance 0.36, death style `ragdoll`.
- **Navigation:** speed 5.72 m/s, turn 283°/s, stopping distance 0.74 m.
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

War Shadow is a **dread spirit** encountered at D rank, around level 48. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a humanoid silhouette with blades for hands. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Umbravel|Umbravel]], [[Regions/Iron Hold|Iron Hold]], [[Regions/Strife Marches|Strife Marches]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Shadows D|loot_shadow_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Shade Essence\|Shade Essence]] | 60% | 1–3 |
| [[Items/Night Shard\|Night Shard]] | 30% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Shadows/Elder War Shadow|Elder War Shadow]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Strife Marches\|Strife Marches]] | 2 | D, C | 48–76 | Night |
| [[Regions/Iron Hold\|Iron Hold]] | 4 | C-, D+, D | 48–65 | Night |
| [[Regions/Umbravel\|Umbravel]] | 2 | C-, E+ | 32–65 | Night |
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 3 | D, C, D+ | 48–76 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00995` | Strife Marches War Shadow | [[Regions/Strife Marches\|Strife Marches]] | Adult | D | 48 | 2 m | Night | A typical adult War Shadow of this region, with dust-grey coloring and old rune scars. |
| `pop_00996` | Iron Hold War Shadow Alpha | [[Regions/Iron Hold\|Iron Hold]] | Alpha | C- | 65 | 2.5 m | Night | Like a typical War Shadow, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_00997` | Iron Hold War Shadow Scarred | [[Regions/Iron Hold\|Iron Hold]] | Scarred | D+ | 56 | 2.2 m | Night | Like a typical War Shadow, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_00998` | Iron Hold War Shadow Albino | [[Regions/Iron Hold\|Iron Hold]] | Albino | D+ | 56 | 2 m | Night | Like a typical War Shadow, but a rare pale form with white skin or fur and red eyes. |
| `pop_00999` | Umbravel War Shadow Alpha | [[Regions/Umbravel\|Umbravel]] | Alpha | C- | 65 | 2.5 m | Night | Like a typical War Shadow, but larger and scarred, and others of its kind follow it, with bioluminescent spots along its body. |
| `pop_01000` | Strife Marches War Shadow Elderborn | [[Regions/Strife Marches\|Strife Marches]] | Elderborn | C | 76 | 2.7 m | Night | Like a typical War Shadow, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_01001` | Great Labyrinth (Floors 1-40) War Shadow | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Adult | D | 48 | 2 m | Night | A typical adult War Shadow of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_01002` | Great Labyrinth (Floors 1-40) War Shadow Elderborn | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Elderborn | C | 76 | 2.7 m | Night | Like a typical War Shadow, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_01003` | Great Labyrinth (Floors 1-40) War Shadow Albino | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Albino | D+ | 56 | 2 m | Night | Like a typical War Shadow, but a rare pale form with white skin or fur and red eyes. |
| `pop_01004` | Umbravel War Shadow Runt | [[Regions/Umbravel\|Umbravel]] | Runt | E+ | 32 | 1.4 m | Night | Like a typical War Shadow, but smaller and scrappier than usual, with bioluminescent spots along its body. |
| `pop_01005` | Iron Hold War Shadow | [[Regions/Iron Hold\|Iron Hold]] | Adult | D | 48 | 2 m | Night | A typical adult War Shadow of this region, with pale, light-starved coloring and oversized eyes. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `shadow_smoke` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · elongated, irregular silhouette; still-then-sudden timing
