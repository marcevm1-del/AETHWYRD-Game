---
type: monster
id: mon_vesper_harvester
family: "Vesperites (Moon Raiders)"
rank: "S"
tier: core
tags: [monster, vesperites-moon-raiders]
---
# Vesper Harvester

![[mon_vesper_harvester_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_vesper_harvester_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 20,000 tris · 4.811 × 5.856 × 6.001 m · local file `Game/Assets/_Game/Art/Models/Monsters/Vesperites (Moon Raiders)/mon_vesper_harvester.fbx`

> The Vesper Harvester is a huge creature with a drifting, half-formed body, about 6 m tall. Its porcelain shell is stretched, stitched and constantly shifting, colored in dusk violet, with crimson markings. Its most striking feature is a lantern cage that holds stolen souls. It has a human-like face in the wrong place. Its regal silhouette is crowned by a halo-like ring of aura. It unfolds into something larger, surrounded by a faint red mist that smells of iron.

| Field | Value |
|---|---|
| Family · type | [[Families/Vesperites (Moon Raiders)|Vesperites (Moon Raiders)]] · Lunar Raider |
| Rank · level | S · 188 (173–203) |
| Menace | 5 · Horror |
| Element · weakness | Blood · Light |
| Size | 6 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 33741 · 457 · 533 · 1067 · 991 · 90 |
| XP · gold | 13063 · 2293 |
| Ring | 7 |
| Rig · animation | [[Systems/Rigs/spirit_float\|spirit_float]] · `anim_floating` |
| Habitats | [[Regions/Vesper\|Vesper]], [[Regions/Lustrine Shores\|Lustrine Shores]] |
| Genre | Cosmic Fantasy |
| Trope | Serene moon-raiders harvesting gem people (Land of the Lustrous) |

**Field note:** Weak to Light. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/spirit_float|spirit_float]] (rigId); animation set `anim_floating`.
- **Dimensions:** 6 m high × 1.8 m long × 3.84 m wide; prefab scale 6.
- **Physics:** 23.8 kg, gravity ×0, poise 130, knockback resistance 0.18, death style `dissolve_into_motes`.
- **Navigation:** speed 15.35 m/s, turn 294°/s, stopping distance 1.9 m.
- **Attack count:** 5; **signature:** a lantern cage that holds stolen souls.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Chill Touch\|Chill Touch]] | melee | 0.9 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Phase Lunge\|Phase Lunge]] | dash | 1.3 | 7 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Wail\|Wail]] | aoe | 1.2 | 12 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Moonglass Shard\|Moonglass Shard]] | ranged | 1.3 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Blood Lance\|Blood Lance]] | magic | 1.5 | 10 s | Blood | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Vesper Harvester is a **horror lunar raider** encountered at S rank, around level 188. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a lantern cage that holds stolen souls. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Vesper|Vesper]], [[Regions/Lustrine Shores|Lustrine Shores]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_floating`, animation set `anim_floating`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Vesperites (Moon Raiders) S|loot_vesperite_s]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Vesper Glass\|Vesper Glass]] | 60% | 1–3 |
| [[Items/Captured Soul-Light\|Captured Soul-Light]] | 30% | 1–1 |
| [[Items/S-Rank Monster Core\|S-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Vesperites (Moon Raiders)/Ancient Vesper Harvester|Ancient Vesper Harvester]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Vesper\|Vesper]] | 6 | SS-, S+, S, S-, SS, A+ | 159–236 | Night |
| [[Regions/Lustrine Shores\|Lustrine Shores]] | 5 | S+, S, S-, A+ | 159–203 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02662` | Vesper Vesper Harvester Alpha | [[Regions/Vesper\|Vesper]] | Alpha | SS- | 218 | 7.5 m | Night | Like a typical Vesper Harvester, but larger and scarred, and others of its kind follow it, with red-black coloring with faint ember veins. |
| `pop_02663` | Vesper Vesper Harvester Albino | [[Regions/Vesper\|Vesper]] | Albino | S+ | 203 | 6 m | Night | Like a typical Vesper Harvester, but a rare pale form with white skin or fur and red eyes. |
| `pop_02664` | Lustrine Shores Vesper Harvester Scarred | [[Regions/Lustrine Shores\|Lustrine Shores]] | Scarred | S+ | 203 | 6.6 m | Night | Like a typical Vesper Harvester, but covered in old battle scars, with salt-crusted, barnacle-flecked hide. |
| `pop_02665` | Vesper Vesper Harvester | [[Regions/Vesper\|Vesper]] | Adult | S | 188 | 6 m | Night | A typical adult Vesper Harvester of this region, with red-black coloring with faint ember veins. |
| `pop_02666` | Vesper Vesper Harvester Juvenile | [[Regions/Vesper\|Vesper]] | Juvenile | S- | 173 | 5.1 m | Night | Like a typical Vesper Harvester, but young, with brighter colors and unworn features, with red-black coloring with faint ember veins. |
| `pop_02667` | Lustrine Shores Vesper Harvester | [[Regions/Lustrine Shores\|Lustrine Shores]] | Adult | S | 188 | 6 m | Night | A typical adult Vesper Harvester of this region, with salt-crusted, barnacle-flecked hide. |
| `pop_02668` | Vesper Vesper Harvester Elderborn | [[Regions/Vesper\|Vesper]] | Elderborn | SS | 236 | 8.1 m | Night | Like a typical Vesper Harvester, but old and wise, with greying features and a cautious hunting style, with red-black coloring with faint ember veins. |
| `pop_02669` | Lustrine Shores Vesper Harvester Juvenile | [[Regions/Lustrine Shores\|Lustrine Shores]] | Juvenile | S- | 173 | 5.1 m | Night | Like a typical Vesper Harvester, but young, with brighter colors and unworn features, with salt-crusted, barnacle-flecked hide. |
| `pop_02670` | Lustrine Shores Vesper Harvester Runt | [[Regions/Lustrine Shores\|Lustrine Shores]] | Runt | A+ | 159 | 4.2 m | Night | Like a typical Vesper Harvester, but smaller and scrappier than usual, with salt-crusted, barnacle-flecked hide. |
| `pop_02671` | Vesper Vesper Harvester Runt | [[Regions/Vesper\|Vesper]] | Runt | A+ | 159 | 4.2 m | Night | Like a typical Vesper Harvester, but smaller and scrappier than usual, with red-black coloring with faint ember veins. |
| `pop_02672` | Lustrine Shores Vesper Harvester Albino | [[Regions/Lustrine Shores\|Lustrine Shores]] | Albino | S+ | 203 | 6 m | Night | Like a typical Vesper Harvester, but a rare pale form with white skin or fur and red eyes. |

## Design recipe

Rig `rig_floating` · mesh `floating_base` · material `porcelain_red_glow` · VFX `blood_mist` · palette `#524e79` `#444068` `#e0344a` · broken symmetry, mimicry, audio-first reveal
