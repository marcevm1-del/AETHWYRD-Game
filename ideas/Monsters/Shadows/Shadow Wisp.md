---
type: monster
id: mon_shadow_wisp
family: "Shadows"
rank: "E"
tier: core
tags: [monster, shadows]
---
# Shadow Wisp

![[mon_shadow_wisp_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_shadow_wisp_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (1,698 tris · 0.37 × 0.342 × 0.4 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Shadow Wisp is a tiny creature with a floating, cloth-like shape, about 0.4 m tall. Its smoke-like body is rough, scarred and spiked, colored in ink black with bruised violet. Survivors describe a flickering smudge of darkness. It has narrow glowing eyes. Small scars and rough edges mark it as a survivor. It strides with heavy steps, surrounded by shadows that lean toward it.

| Field | Value |
|---|---|
| Family · type | [[Families/Shadows|Shadows]] · Spirit |
| Rank · level | E · 26 (19–32) |
| Menace | 3 · Menacing |
| Element · weakness | Dark · Light |
| Size | 0.4 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 770 · 68 · 80 · 160 · 148 · 90 |
| XP · gold | 559 · 147 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/spirit_float\|spirit_float]] · `anim_floating` |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Dungeon Crawl |
| Trope | Dungeon-born shadow warriors (DanMachi War Shadows) |

**Field note:** Weak to Light. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/spirit_float|spirit_float]] (rigId); animation set `anim_floating`.
- **Dimensions:** 0.4 m high × 0.12 m long × 0.26 m wide; prefab scale 0.4.
- **Physics:** 0.5 kg, gravity ×0, poise 5, knockback resistance 0.03, death style `dissolve_into_motes`.
- **Navigation:** speed 4.16 m/s, turn 900°/s, stopping distance 0.5 m.
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

Shadow Wisp is a **menacing spirit** encountered at E rank, around level 26. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a flickering smudge of darkness. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Aldmere|Aldmere]], [[Regions/Whisperwood|Whisperwood]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_floating`, animation set `anim_floating`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Shadows E|loot_shadow_e]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Shade Essence\|Shade Essence]] | 60% | 1–3 |
| [[Items/Night Shard\|Night Shard]] | 30% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Shadows/Vesper-Touched Shadow Wisp|Vesper-Touched Shadow Wisp]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Whisperwood\|Whisperwood]] | 4 | E+, D-, E-, D | 19–48 | Day & Night |
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 2 | D-, E+ | 32–40 | Day & Night |
| [[Regions/Aldmere\|Aldmere]] | 5 | E, F+, D, E+, D- | 13–48 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00984` | Whisperwood Shadow Wisp Scarred | [[Regions/Whisperwood\|Whisperwood]] | Scarred | E+ | 32 | 0.44 m | Day & Night | Like a typical Shadow Wisp, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_00985` | Great Labyrinth (Floors 1-40) Shadow Wisp Alpha | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Alpha | D- | 40 | 0.5 m | Day & Night | Like a typical Shadow Wisp, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_00986` | Aldmere Shadow Wisp | [[Regions/Aldmere\|Aldmere]] | Adult | E | 26 | 0.4 m | Day & Night | A typical adult Shadow Wisp of this region, with dust-grey coloring and old rune scars. |
| `pop_00987` | Aldmere Shadow Wisp Runt | [[Regions/Aldmere\|Aldmere]] | Runt | F+ | 13 | 0.28 m | Day & Night | Like a typical Shadow Wisp, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_00988` | Aldmere Shadow Wisp Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | D | 48 | 0.54 m | Day & Night | Like a typical Shadow Wisp, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_00989` | Great Labyrinth (Floors 1-40) Shadow Wisp Scarred | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Scarred | E+ | 32 | 0.44 m | Day & Night | Like a typical Shadow Wisp, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_00990` | Aldmere Shadow Wisp Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | E+ | 32 | 0.44 m | Day & Night | Like a typical Shadow Wisp, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_00991` | Whisperwood Shadow Wisp Alpha | [[Regions/Whisperwood\|Whisperwood]] | Alpha | D- | 40 | 0.5 m | Day & Night | Like a typical Shadow Wisp, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_00992` | Aldmere Shadow Wisp Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | D- | 40 | 0.5 m | Day & Night | Like a typical Shadow Wisp, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_00993` | Whisperwood Shadow Wisp Juvenile | [[Regions/Whisperwood\|Whisperwood]] | Juvenile | E- | 19 | 0.34 m | Day & Night | Like a typical Shadow Wisp, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_00994` | Whisperwood Shadow Wisp Elderborn | [[Regions/Whisperwood\|Whisperwood]] | Elderborn | D | 48 | 0.54 m | Day & Night | Like a typical Shadow Wisp, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |

## Design recipe

Rig `rig_floating` · mesh `floating_base` · material `shadow_smoke` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · triangle-based silhouette, sharp asymmetric spikes
