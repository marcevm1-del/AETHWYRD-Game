---
type: monster
id: mon_deep_thousand_eyed_watcher
family: "Aberrations"
rank: "A+"
tier: variant
tags: [monster, aberrations]
---
# Deep Thousand-Eyed Watcher

![[mon_deep_thousand_eyed_watcher_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_deep_thousand_eyed_watcher_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (1,420 tris · 6.178 × 5.161 × 6 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Deep Thousand-Eyed Watcher is a huge creature with a floating, cloth-like shape, about 6 m tall. Its skin is stretched, stitched and constantly shifting, colored in ink black with bruised violet. Survivors describe a cloud of eyes that blink in sequence. It has too many eyes, opening one after another. An elegant crest and glowing veins of mana mark it as a champion of its kind. It copies the walk of whatever it hunts, surrounded by shadows that lean toward it. Adapted to underworld lands, it has bioluminescent spots along its body.

| Field | Value |
|---|---|
| Family · type | [[Families/Aberrations|Aberrations]] · Aberration |
| Variant of | [[Monsters/Aberrations/Thousand-Eyed Watcher\|Thousand-Eyed Watcher]] (regional) |
| Rank · level | A+ · 159 (146–173) |
| Menace | 5 · Horror |
| Element · weakness | Dark · Light |
| Size | 6 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 26263 · 388 · 452 · 904 · 840 · 90 |
| XP · gold | 9993 · 1815 |
| Ring | 7 |
| Rig · animation | [[Systems/Rigs/spirit_float\|spirit_float]] · `anim_floating` |
| Habitats | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/Aurumdeep\|Aurumdeep]] |
| Genre | Cosmic Horror |
| Trope | Mimicking things in the dark |

**Field note:** Weak to Light. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/spirit_float|spirit_float]] (rigId); animation set `anim_floating`.
- **Dimensions:** 6 m high × 1.8 m long × 3.84 m wide; prefab scale 6.
- **Physics:** 21.6 kg, gravity ×0, poise 116, knockback resistance 0.15, death style `dissolve_into_motes`.
- **Navigation:** speed 16.12 m/s, turn 294°/s, stopping distance 1.9 m.
- **Attack count:** 5; **signature:** a cloud of eyes that blink in sequence.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Chill Touch\|Chill Touch]] | melee | 0.9 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Phase Lunge\|Phase Lunge]] | dash | 1.3 | 7 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Wail\|Wail]] | aoe | 1.2 | 12 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Mimic Lure\|Mimic Lure]] | debuff | 0 | 16 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Deep Thousand-Eyed Watcher is a **horror aberration** encountered at A+ rank, around level 159. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a cloud of eyes that blink in sequence. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]], [[Regions/Aurumdeep|Aurumdeep]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_floating`, animation set `anim_floating`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Aberrations A|loot_aberration_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Unreal Fragment\|Unreal Fragment]] | 60% | 1–3 |
| [[Items/Eye of Nothing\|Eye of Nothing]] | 30% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Aurumdeep\|Aurumdeep]] | 7 | S+, S-, S, A-, A, A+ | 132–203 | Night |
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 4 | S, S+, A-, A | 132–203 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05290` | Aurumdeep Deep Thousand-Eyed Watcher Elderborn | [[Regions/Aurumdeep\|Aurumdeep]] | Elderborn | S+ | 203 | 8.1 m | Night | Like a typical Deep Thousand-Eyed Watcher, but old and wise, with greying features and a cautious hunting style, with bioluminescent spots along its body. |
| `pop_05291` | Great Labyrinth (Floors 41-90) Deep Thousand-Eyed Watcher Alpha | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Alpha | S | 188 | 7.5 m | Night | Like a typical Deep Thousand-Eyed Watcher, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_05292` | Great Labyrinth (Floors 41-90) Deep Thousand-Eyed Watcher Elderborn | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Elderborn | S+ | 203 | 8.1 m | Night | Like a typical Deep Thousand-Eyed Watcher, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_05293` | Great Labyrinth (Floors 41-90) Deep Thousand-Eyed Watcher Runt | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Runt | A- | 132 | 4.2 m | Night | Like a typical Deep Thousand-Eyed Watcher, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_05294` | Aurumdeep Deep Thousand-Eyed Watcher Scarred | [[Regions/Aurumdeep\|Aurumdeep]] | Scarred | S- | 173 | 6.6 m | Night | Like a typical Deep Thousand-Eyed Watcher, but covered in old battle scars, with bioluminescent spots along its body. |
| `pop_05295` | Aurumdeep Deep Thousand-Eyed Watcher Alpha | [[Regions/Aurumdeep\|Aurumdeep]] | Alpha | S | 188 | 7.5 m | Night | Like a typical Deep Thousand-Eyed Watcher, but larger and scarred, and others of its kind follow it, with bioluminescent spots along its body. |
| `pop_05296` | Aurumdeep Deep Thousand-Eyed Watcher Runt | [[Regions/Aurumdeep\|Aurumdeep]] | Runt | A- | 132 | 4.2 m | Night | Like a typical Deep Thousand-Eyed Watcher, but smaller and scrappier than usual, with bioluminescent spots along its body. |
| `pop_05297` | Aurumdeep Deep Thousand-Eyed Watcher Juvenile | [[Regions/Aurumdeep\|Aurumdeep]] | Juvenile | A | 146 | 5.1 m | Night | Like a typical Deep Thousand-Eyed Watcher, but young, with brighter colors and unworn features, with bioluminescent spots along its body. |
| `pop_05298` | Great Labyrinth (Floors 41-90) Deep Thousand-Eyed Watcher Juvenile | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Juvenile | A | 146 | 5.1 m | Night | Like a typical Deep Thousand-Eyed Watcher, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_05299` | Aurumdeep Deep Thousand-Eyed Watcher Albino | [[Regions/Aurumdeep\|Aurumdeep]] | Albino | S- | 173 | 6 m | Night | Like a typical Deep Thousand-Eyed Watcher, but a rare pale form with white skin or fur and red eyes. |
| `pop_05300` | Aurumdeep Deep Thousand-Eyed Watcher | [[Regions/Aurumdeep\|Aurumdeep]] | Adult | A+ | 159 | 6 m | Night | A typical adult Deep Thousand-Eyed Watcher of this region, with bioluminescent spots along its body. |

## Design recipe

Rig `rig_floating` · mesh `floating_base` · material `wet_flesh_unsettling` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · broken symmetry, mimicry, audio-first reveal
