---
type: monster
id: mon_elder_glass_wraith
family: "Sandborne"
rank: "B"
tier: variant
tags: [monster, sandborne]
---
# Elder Glass Wraith

![[mon_elder_glass_wraith_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_elder_glass_wraith_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (1,276 tris · 2.325 × 2.256 × 3.2 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Elder Glass Wraith is a large creature with a floating, cloth-like shape, about 3.2 m tall. Its sand-scoured hide is patchy and subtly wrong, as if assembled from memory, colored in warm gold and pearl white. Look for a figure of fused desert glass, humming with old magic. It has eyes set slightly too far apart. Faint runes glow along its body when it fights. It moves in jerky stop-motion bursts, surrounded by soft radiance and floating motes of light. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Sandborne|Sandborne]] · Desert Beast |
| Variant of | [[Monsters/Sandborne/Glass Wraith\|Glass Wraith]] (elder) |
| Rank · level | B · 108 (96–120) |
| Menace | 4 · Dread |
| Element · weakness | Light · Dark |
| Size | 3.2 m |
| Behaviour | Territorial (territorial_guard+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 12045 · 265 · 309 · 619 · 575 · 90 |
| XP · gold | 5386 · 1057 |
| Ring | 7 |
| Rig · animation | [[Systems/Rigs/spirit_float\|spirit_float]] · `anim_floating` |
| Habitats | [[Regions/Zarvan\|Zarvan]], [[Regions/Sunscar\|Sunscar]] |
| Genre | Desert Epic |
| Trope | Desert giants and sandworms (Dune, Children of the Whales) |

**Field note:** Weak to Dark. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/spirit_float|spirit_float]] (rigId); animation set `anim_floating`.
- **Dimensions:** 3.2 m high × 0.96 m long × 2.05 m wide; prefab scale 3.2.
- **Physics:** 3.1 kg, gravity ×0, poise 40, knockback resistance 0.12, death style `dissolve_into_motes`.
- **Navigation:** speed 9.7 m/s, turn 402°/s, stopping distance 1.2 m.
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

Elder Glass Wraith is a **dread desert beast** encountered at B rank, around level 108. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Dark**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a figure of fused desert glass, humming with old magic. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Zarvan|Zarvan]], [[Regions/Sunscar|Sunscar]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_floating`, animation set `anim_floating`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Sandborne B|loot_sandborne_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Desert Glass\|Desert Glass]] | 60% | 1–3 |
| [[Items/Sand Pearl\|Sand Pearl]] | 30% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Sunscar\|Sunscar]] | 6 | B, B+, A, B-, C+, A- | 86–146 | Night |
| [[Regions/Zarvan\|Zarvan]] | 5 | B+, B-, B, A | 96–146 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05538` | Sunscar Elder Glass Wraith | [[Regions/Sunscar\|Sunscar]] | Adult | B | 108 | 3.2 m | Night | A typical adult Elder Glass Wraith of this region, with sun-bleached, sand-scoured coloring. |
| `pop_05539` | Sunscar Elder Glass Wraith Scarred | [[Regions/Sunscar\|Sunscar]] | Scarred | B+ | 120 | 3.52 m | Night | Like a typical Elder Glass Wraith, but covered in old battle scars, with sun-bleached, sand-scoured coloring. |
| `pop_05540` | Sunscar Elder Glass Wraith Elderborn | [[Regions/Sunscar\|Sunscar]] | Elderborn | A | 146 | 4.32 m | Night | Like a typical Elder Glass Wraith, but old and wise, with greying features and a cautious hunting style, with sun-bleached, sand-scoured coloring. |
| `pop_05541` | Zarvan Elder Glass Wraith Albino | [[Regions/Zarvan\|Zarvan]] | Albino | B+ | 120 | 3.2 m | Night | Like a typical Elder Glass Wraith, but a rare pale form with white skin or fur and red eyes. |
| `pop_05542` | Zarvan Elder Glass Wraith Juvenile | [[Regions/Zarvan\|Zarvan]] | Juvenile | B- | 96 | 2.72 m | Night | Like a typical Elder Glass Wraith, but young, with brighter colors and unworn features, with sun-bleached, sand-scoured coloring. |
| `pop_05543` | Sunscar Elder Glass Wraith Juvenile | [[Regions/Sunscar\|Sunscar]] | Juvenile | B- | 96 | 2.72 m | Night | Like a typical Elder Glass Wraith, but young, with brighter colors and unworn features, with sun-bleached, sand-scoured coloring. |
| `pop_05544` | Zarvan Elder Glass Wraith | [[Regions/Zarvan\|Zarvan]] | Adult | B | 108 | 3.2 m | Night | A typical adult Elder Glass Wraith of this region, with sun-bleached, sand-scoured coloring. |
| `pop_05545` | Sunscar Elder Glass Wraith Runt | [[Regions/Sunscar\|Sunscar]] | Runt | C+ | 86 | 2.24 m | Night | Like a typical Elder Glass Wraith, but smaller and scrappier than usual, with sun-bleached, sand-scoured coloring. |
| `pop_05546` | Zarvan Elder Glass Wraith Scarred | [[Regions/Zarvan\|Zarvan]] | Scarred | B+ | 120 | 3.52 m | Night | Like a typical Elder Glass Wraith, but covered in old battle scars, with sun-bleached, sand-scoured coloring. |
| `pop_05547` | Sunscar Elder Glass Wraith Alpha | [[Regions/Sunscar\|Sunscar]] | Alpha | A- | 132 | 4 m | Night | Like a typical Elder Glass Wraith, but larger and scarred, and others of its kind follow it, with sun-bleached, sand-scoured coloring. |
| `pop_05548` | Zarvan Elder Glass Wraith Elderborn | [[Regions/Zarvan\|Zarvan]] | Elderborn | A | 146 | 4.32 m | Night | Like a typical Elder Glass Wraith, but old and wise, with greying features and a cautious hunting style, with sun-bleached, sand-scoured coloring. |

## Design recipe

Rig `rig_floating` · mesh `floating_base` · material `sand_hide` · VFX `holy_motes` · palette `#fff3b0` `#ffd166` `#ffffff` · elongated, irregular silhouette; still-then-sudden timing
