---
type: monster
id: mon_glass_wraith
family: "Sandborne"
rank: "C"
tier: core
tags: [monster, sandborne]
---
# Glass Wraith

![[mon_glass_wraith_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_glass_wraith_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (1,108 tris · 1.453 × 1.371 × 2 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Glass Wraith is a person-sized creature with a bodiless, glowing form, about 2 m tall. Its sand-scoured hide is patchy and subtly wrong, as if assembled from memory, colored in warm gold and pearl white. Guild sketches always show a figure of fused desert glass, humming with old magic. It has pale, pupil-less eyes. Battle-worn plates and trophies hang from its body. It glides without moving its legs, surrounded by soft radiance and floating motes of light.

| Field | Value |
|---|---|
| Family · type | [[Families/Sandborne|Sandborne]] · Desert Beast |
| Rank · level | C · 76 (65–86) |
| Menace | 4 · Dread |
| Element · weakness | Light · Dark |
| Size | 2 m |
| Behaviour | Territorial (territorial_guard+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 6087 · 188 · 220 · 440 · 408 · 90 |
| XP · gold | 3073 · 648 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/spirit_float\|spirit_float]] · `anim_floating` |
| Habitats | [[Regions/Zarvan\|Zarvan]], [[Regions/Dunewhale Drift\|Dunewhale Drift]], [[Regions/Zaruma\|Zaruma]] |
| Genre | Desert Epic |
| Trope | Desert giants and sandworms (Dune, Children of the Whales) |

**Field note:** Weak to Dark. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/spirit_float|spirit_float]] (rigId); animation set `anim_floating`.
- **Dimensions:** 2 m high × 0.6 m long × 1.28 m wide; prefab scale 2.
- **Physics:** 0.8 kg, gravity ×0, poise 16, knockback resistance 0.09, death style `dissolve_into_motes`.
- **Navigation:** speed 7.67 m/s, turn 509°/s, stopping distance 0.9 m.
- **Attack count:** 5; **signature:** a figure of fused desert glass, humming with old magic.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Chill Touch\|Chill Touch]] | melee | 0.9 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Phase Lunge\|Phase Lunge]] | dash | 1.3 | 7 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Wail\|Wail]] | aoe | 1.2 | 12 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Sand Burrow\|Sand Burrow]] | dash | 1.5 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Radiant Pulse\|Radiant Pulse]] | magic | 1.5 | 10 s | Light | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Glass Wraith is a **dread desert beast** encountered at C rank, around level 76. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Dark**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a figure of fused desert glass, humming with old magic. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Zarvan|Zarvan]], [[Regions/Dunewhale Drift|Dunewhale Drift]], [[Regions/Zaruma|Zaruma]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_floating`, animation set `anim_floating`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Sandborne C|loot_sandborne_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Desert Glass\|Desert Glass]] | 60% | 1–3 |
| [[Items/Sand Pearl\|Sand Pearl]] | 30% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Sandborne/Elder Glass Wraith|Elder Glass Wraith]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Dunewhale Drift\|Dunewhale Drift]] | 3 | D+, C+ | 56–86 | Night |
| [[Regions/Zaruma\|Zaruma]] | 4 | C, C+, D+, C- | 56–86 | Night |
| [[Regions/Zarvan\|Zarvan]] | 4 | C+, B, C-, D+ | 56–108 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02695` | Dunewhale Drift Glass Wraith Runt | [[Regions/Dunewhale Drift\|Dunewhale Drift]] | Runt | D+ | 56 | 1.4 m | Night | Like a typical Glass Wraith, but smaller and scrappier than usual, with sun-bleached, sand-scoured coloring. |
| `pop_02696` | Zaruma Glass Wraith | [[Regions/Zaruma\|Zaruma]] | Adult | C | 76 | 2 m | Night | A typical adult Glass Wraith of this region, with sun-bleached, sand-scoured coloring. |
| `pop_02697` | Zaruma Glass Wraith Scarred | [[Regions/Zaruma\|Zaruma]] | Scarred | C+ | 86 | 2.2 m | Night | Like a typical Glass Wraith, but covered in old battle scars, with sun-bleached, sand-scoured coloring. |
| `pop_02698` | Zaruma Glass Wraith Runt | [[Regions/Zaruma\|Zaruma]] | Runt | D+ | 56 | 1.4 m | Night | Like a typical Glass Wraith, but smaller and scrappier than usual, with sun-bleached, sand-scoured coloring. |
| `pop_02699` | Zaruma Glass Wraith Juvenile | [[Regions/Zaruma\|Zaruma]] | Juvenile | C- | 65 | 1.7 m | Night | Like a typical Glass Wraith, but young, with brighter colors and unworn features, with sun-bleached, sand-scoured coloring. |
| `pop_02700` | Dunewhale Drift Glass Wraith Scarred | [[Regions/Dunewhale Drift\|Dunewhale Drift]] | Scarred | C+ | 86 | 2.2 m | Night | Like a typical Glass Wraith, but covered in old battle scars, with sun-bleached, sand-scoured coloring. |
| `pop_02701` | Zarvan Glass Wraith Albino | [[Regions/Zarvan\|Zarvan]] | Albino | C+ | 86 | 2 m | Night | Like a typical Glass Wraith, but a rare pale form with white skin or fur and red eyes. |
| `pop_02702` | Zarvan Glass Wraith Elderborn | [[Regions/Zarvan\|Zarvan]] | Elderborn | B | 108 | 2.7 m | Night | Like a typical Glass Wraith, but old and wise, with greying features and a cautious hunting style, with sun-bleached, sand-scoured coloring. |
| `pop_02703` | Zarvan Glass Wraith Juvenile | [[Regions/Zarvan\|Zarvan]] | Juvenile | C- | 65 | 1.7 m | Night | Like a typical Glass Wraith, but young, with brighter colors and unworn features, with sun-bleached, sand-scoured coloring. |
| `pop_02704` | Zarvan Glass Wraith Runt | [[Regions/Zarvan\|Zarvan]] | Runt | D+ | 56 | 1.4 m | Night | Like a typical Glass Wraith, but smaller and scrappier than usual, with sun-bleached, sand-scoured coloring. |
| `pop_02705` | Dunewhale Drift Glass Wraith Albino | [[Regions/Dunewhale Drift\|Dunewhale Drift]] | Albino | C+ | 86 | 2 m | Night | Like a typical Glass Wraith, but a rare pale form with white skin or fur and red eyes. |

## Design recipe

Rig `rig_floating` · mesh `floating_base` · material `sand_hide` · VFX `holy_motes` · palette `#fff3b0` `#ffd166` `#ffffff` · elongated, irregular silhouette; still-then-sudden timing
