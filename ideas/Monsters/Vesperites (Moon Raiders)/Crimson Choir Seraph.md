---
type: monster
id: mon_crimson_choir_seraph
family: "Vesperites (Moon Raiders)"
rank: "A"
tier: core
tags: [monster, vesperites-moon-raiders]
---
# Crimson Choir Seraph

![[mon_crimson_choir_seraph_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_crimson_choir_seraph_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (1,848 tris · 2.543 × 2.63 × 3.5 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Crimson Choir Seraph is a large creature with a floating, cloth-like shape, about 3.5 m tall. Its porcelain shell is patchy and subtly wrong, as if assembled from memory, colored in arterial crimson and dried-blood brown. Look for six wings of red glass and a singing mask. It has eyes set slightly too far apart. An elegant crest and glowing veins of mana mark it as a champion of its kind. It moves in jerky stop-motion bursts, surrounded by a faint red mist that smells of iron.

| Field | Value |
|---|---|
| Family · type | [[Families/Vesperites (Moon Raiders)|Vesperites (Moon Raiders)]] · Lunar Raider |
| Rank · level | A · 146 (132–159) |
| Menace | 4 · Dread |
| Element · weakness | Blood · Light |
| Size | 3.5 m |
| Behaviour | Aggressive (aggressive_chase+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 19462 · 356 · 416 · 832 · 772 · 90 |
| XP · gold | 8719 · 1611 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/spirit_float\|spirit_float]] · `anim_floating` |
| Habitats | [[Regions/Sunscar\|Sunscar]], [[Regions/Lustrine Shores\|Lustrine Shores]] |
| Genre | Cosmic Fantasy |
| Trope | Serene moon-raiders harvesting gem people (Land of the Lustrous) |

**Field note:** Weak to Light. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/spirit_float|spirit_float]] (rigId); animation set `anim_floating`.
- **Dimensions:** 3.5 m high × 1.05 m long × 2.24 m wide; prefab scale 3.5.
- **Physics:** 4.7 kg, gravity ×0, poise 52, knockback resistance 0.15, death style `dissolve_into_motes`.
- **Navigation:** speed 11.16 m/s, turn 385°/s, stopping distance 1.27 m.
- **Attack count:** 5; **signature:** six wings of red glass and a singing mask.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Chill Touch\|Chill Touch]] | melee | 0.9 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Phase Lunge\|Phase Lunge]] | dash | 1.3 | 7 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Wail\|Wail]] | aoe | 1.2 | 12 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Moonglass Shard\|Moonglass Shard]] | ranged | 1.3 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Blood Lance\|Blood Lance]] | magic | 1.5 | 10 s | Blood | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Crimson Choir Seraph is a **dread lunar raider** encountered at A rank, around level 146. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** six wings of red glass and a singing mask. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Sunscar|Sunscar]], [[Regions/Lustrine Shores|Lustrine Shores]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_floating`, animation set `anim_floating`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Vesperites (Moon Raiders) A|loot_vesperite_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Vesper Glass\|Vesper Glass]] | 60% | 1–3 |
| [[Items/Captured Soul-Light\|Captured Soul-Light]] | 30% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Vesperites (Moon Raiders)/Phantom Crimson Choir Seraph|Phantom Crimson Choir Seraph]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Lustrine Shores\|Lustrine Shores]] | 5 | A-, B+, A, S, A+ | 120–188 | Night |
| [[Regions/Sunscar\|Sunscar]] | 6 | B+, A+, S, S-, A, A- | 120–188 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02651` | Lustrine Shores Crimson Choir Seraph Juvenile | [[Regions/Lustrine Shores\|Lustrine Shores]] | Juvenile | A- | 132 | 2.98 m | Night | Like a typical Crimson Choir Seraph, but young, with brighter colors and unworn features, with salt-crusted, barnacle-flecked hide. |
| `pop_02652` | Sunscar Crimson Choir Seraph Runt | [[Regions/Sunscar\|Sunscar]] | Runt | B+ | 120 | 2.45 m | Night | Like a typical Crimson Choir Seraph, but smaller and scrappier than usual, with sun-bleached, sand-scoured coloring. |
| `pop_02653` | Sunscar Crimson Choir Seraph Scarred | [[Regions/Sunscar\|Sunscar]] | Scarred | A+ | 159 | 3.85 m | Night | Like a typical Crimson Choir Seraph, but covered in old battle scars, with sun-bleached, sand-scoured coloring. |
| `pop_02654` | Sunscar Crimson Choir Seraph Elderborn | [[Regions/Sunscar\|Sunscar]] | Elderborn | S | 188 | 4.73 m | Night | Like a typical Crimson Choir Seraph, but old and wise, with greying features and a cautious hunting style, with sun-bleached, sand-scoured coloring. |
| `pop_02655` | Lustrine Shores Crimson Choir Seraph Runt | [[Regions/Lustrine Shores\|Lustrine Shores]] | Runt | B+ | 120 | 2.45 m | Night | Like a typical Crimson Choir Seraph, but smaller and scrappier than usual, with salt-crusted, barnacle-flecked hide. |
| `pop_02656` | Lustrine Shores Crimson Choir Seraph | [[Regions/Lustrine Shores\|Lustrine Shores]] | Adult | A | 146 | 3.5 m | Night | A typical adult Crimson Choir Seraph of this region, with salt-crusted, barnacle-flecked hide. |
| `pop_02657` | Lustrine Shores Crimson Choir Seraph Elderborn | [[Regions/Lustrine Shores\|Lustrine Shores]] | Elderborn | S | 188 | 4.73 m | Night | Like a typical Crimson Choir Seraph, but old and wise, with greying features and a cautious hunting style, with salt-crusted, barnacle-flecked hide. |
| `pop_02658` | Sunscar Crimson Choir Seraph Alpha | [[Regions/Sunscar\|Sunscar]] | Alpha | S- | 173 | 4.38 m | Night | Like a typical Crimson Choir Seraph, but larger and scarred, and others of its kind follow it, with sun-bleached, sand-scoured coloring. |
| `pop_02659` | Sunscar Crimson Choir Seraph | [[Regions/Sunscar\|Sunscar]] | Adult | A | 146 | 3.5 m | Night | A typical adult Crimson Choir Seraph of this region, with sun-bleached, sand-scoured coloring. |
| `pop_02660` | Lustrine Shores Crimson Choir Seraph Scarred | [[Regions/Lustrine Shores\|Lustrine Shores]] | Scarred | A+ | 159 | 3.85 m | Night | Like a typical Crimson Choir Seraph, but covered in old battle scars, with salt-crusted, barnacle-flecked hide. |
| `pop_02661` | Sunscar Crimson Choir Seraph Juvenile | [[Regions/Sunscar\|Sunscar]] | Juvenile | A- | 132 | 2.98 m | Night | Like a typical Crimson Choir Seraph, but young, with brighter colors and unworn features, with sun-bleached, sand-scoured coloring. |

## Design recipe

Rig `rig_floating` · mesh `floating_base` · material `porcelain_red_glow` · VFX `blood_mist` · palette `#8b0000` `#d7263d` `#1a0505` · elongated, irregular silhouette; still-then-sudden timing
