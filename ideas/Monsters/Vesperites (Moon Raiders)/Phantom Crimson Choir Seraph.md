---
type: monster
id: mon_phantom_crimson_choir_seraph
family: "Vesperites (Moon Raiders)"
rank: "A+"
tier: variant
tags: [monster, vesperites-moon-raiders]
---
# Phantom Crimson Choir Seraph

![[mon_phantom_crimson_choir_seraph_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_phantom_crimson_choir_seraph_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (1,776 tris · 3.604 × 3.011 × 3.5 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Phantom Crimson Choir Seraph is a large creature with a drifting, half-formed body, about 3.5 m tall. Its porcelain shell is stretched, stitched and constantly shifting, colored in warm gold and pearl white. Survivors describe six wings of red glass and a singing mask. It has a human-like face in the wrong place. An elegant crest and glowing veins of mana mark it as a champion of its kind. It unfolds into something larger, surrounded by soft radiance and floating motes of light. Its body is translucent blue, half in the spirit world; weapons pass through it unless they are blessed or enchanted.

| Field | Value |
|---|---|
| Family · type | [[Families/Vesperites (Moon Raiders)|Vesperites (Moon Raiders)]] · Lunar Raider |
| Variant of | [[Monsters/Vesperites (Moon Raiders)/Crimson Choir Seraph\|Crimson Choir Seraph]] (spirit) |
| Rank · level | A+ · 159 (146–173) |
| Menace | 5 · Horror |
| Element · weakness | Light · Dark |
| Size | 3.5 m |
| Behaviour | Aggressive (aggressive_chase+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 22108 · 388 · 452 · 904 · 840 · 90 |
| XP · gold | 9993 · 1815 |
| Ring | 7 |
| Rig · animation | [[Systems/Rigs/spirit_float\|spirit_float]] · `anim_floating` |
| Habitats | [[Regions/Sunscar\|Sunscar]], [[Regions/Lustrine Shores\|Lustrine Shores]] |
| Genre | Cosmic Fantasy |
| Trope | Serene moon-raiders harvesting gem people (Land of the Lustrous) |

**Field note:** Weak to Dark. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/spirit_float|spirit_float]] (rigId); animation set `anim_floating`.
- **Dimensions:** 3.5 m high × 1.05 m long × 2.24 m wide; prefab scale 3.5.
- **Physics:** 4.1 kg, gravity ×0, poise 49, knockback resistance 0.15, death style `dissolve_into_motes`.
- **Navigation:** speed 11.72 m/s, turn 385°/s, stopping distance 1.27 m.
- **Attack count:** 5; **signature:** six wings of red glass and a singing mask.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Chill Touch\|Chill Touch]] | melee | 0.9 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Phase Lunge\|Phase Lunge]] | dash | 1.3 | 7 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Wail\|Wail]] | aoe | 1.2 | 12 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Moonglass Shard\|Moonglass Shard]] | ranged | 1.3 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Radiant Pulse\|Radiant Pulse]] | magic | 1.5 | 10 s | Light | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Phantom Crimson Choir Seraph is a **horror lunar raider** encountered at A+ rank, around level 159. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Dark**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

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

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Lustrine Shores\|Lustrine Shores]] | 5 | S+, A+, A, S, S- | 146–203 | Night |
| [[Regions/Sunscar\|Sunscar]] | 6 | S-, A-, S, A+, S+ | 132–203 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05498` | Lustrine Shores Phantom Crimson Choir Seraph Elderborn | [[Regions/Lustrine Shores\|Lustrine Shores]] | Elderborn | S+ | 203 | 4.73 m | Night | Like a typical Phantom Crimson Choir Seraph, but old and wise, with greying features and a cautious hunting style, with salt-crusted, barnacle-flecked hide. |
| `pop_05499` | Sunscar Phantom Crimson Choir Seraph Albino | [[Regions/Sunscar\|Sunscar]] | Albino | S- | 173 | 3.5 m | Night | Like a typical Phantom Crimson Choir Seraph, but a rare pale form with white skin or fur and red eyes. |
| `pop_05500` | Lustrine Shores Phantom Crimson Choir Seraph | [[Regions/Lustrine Shores\|Lustrine Shores]] | Adult | A+ | 159 | 3.5 m | Night | A typical adult Phantom Crimson Choir Seraph of this region, with salt-crusted, barnacle-flecked hide. |
| `pop_05501` | Sunscar Phantom Crimson Choir Seraph Runt | [[Regions/Sunscar\|Sunscar]] | Runt | A- | 132 | 2.45 m | Night | Like a typical Phantom Crimson Choir Seraph, but smaller and scrappier than usual, with sun-bleached, sand-scoured coloring. |
| `pop_05502` | Sunscar Phantom Crimson Choir Seraph Alpha | [[Regions/Sunscar\|Sunscar]] | Alpha | S | 188 | 4.38 m | Night | Like a typical Phantom Crimson Choir Seraph, but larger and scarred, and others of its kind follow it, with sun-bleached, sand-scoured coloring. |
| `pop_05503` | Lustrine Shores Phantom Crimson Choir Seraph Juvenile | [[Regions/Lustrine Shores\|Lustrine Shores]] | Juvenile | A | 146 | 2.98 m | Night | Like a typical Phantom Crimson Choir Seraph, but young, with brighter colors and unworn features, with salt-crusted, barnacle-flecked hide. |
| `pop_05504` | Sunscar Phantom Crimson Choir Seraph Scarred | [[Regions/Sunscar\|Sunscar]] | Scarred | S- | 173 | 3.85 m | Night | Like a typical Phantom Crimson Choir Seraph, but covered in old battle scars, with sun-bleached, sand-scoured coloring. |
| `pop_05505` | Sunscar Phantom Crimson Choir Seraph | [[Regions/Sunscar\|Sunscar]] | Adult | A+ | 159 | 3.5 m | Night | A typical adult Phantom Crimson Choir Seraph of this region, with sun-bleached, sand-scoured coloring. |
| `pop_05506` | Sunscar Phantom Crimson Choir Seraph Elderborn | [[Regions/Sunscar\|Sunscar]] | Elderborn | S+ | 203 | 4.73 m | Night | Like a typical Phantom Crimson Choir Seraph, but old and wise, with greying features and a cautious hunting style, with sun-bleached, sand-scoured coloring. |
| `pop_05507` | Lustrine Shores Phantom Crimson Choir Seraph Alpha | [[Regions/Lustrine Shores\|Lustrine Shores]] | Alpha | S | 188 | 4.38 m | Night | Like a typical Phantom Crimson Choir Seraph, but larger and scarred, and others of its kind follow it, with salt-crusted, barnacle-flecked hide. |
| `pop_05508` | Lustrine Shores Phantom Crimson Choir Seraph Albino | [[Regions/Lustrine Shores\|Lustrine Shores]] | Albino | S- | 173 | 3.5 m | Night | Like a typical Phantom Crimson Choir Seraph, but a rare pale form with white skin or fur and red eyes. |

## Design recipe

Rig `rig_floating` · mesh `floating_base` · material `porcelain_red_glow` · VFX `holy_motes` · palette `#fff3b0` `#ffd166` `#ffffff` · broken symmetry, mimicry, audio-first reveal
