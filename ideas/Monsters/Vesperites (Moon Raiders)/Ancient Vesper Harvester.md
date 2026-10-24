---
type: monster
id: mon_ancient_vesper_harvester
family: "Vesperites (Moon Raiders)"
rank: "SS"
tier: variant
tags: [monster, vesperites-moon-raiders]
---
# Ancient Vesper Harvester

![[mon_ancient_vesper_harvester_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_ancient_vesper_harvester_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Ancient Vesper Harvester is a huge creature with a drifting, half-formed body, about 9 m tall. Its porcelain shell is stretched, stitched and constantly shifting, colored in arterial crimson and dried-blood brown. Survivors describe a lantern cage that holds stolen souls. It has no eyes at all, only a wide and patient mouth. The air distorts slightly around its outline. It unfolds into something larger, surrounded by a faint red mist that smells of iron. Moss, crystals and centuries-old scars cover its body; it has outlived every hunter sent after it.

| Field | Value |
|---|---|
| Family · type | [[Families/Vesperites (Moon Raiders)|Vesperites (Moon Raiders)]] · Lunar Raider |
| Variant of | [[Monsters/Vesperites (Moon Raiders)/Vesper Harvester\|Vesper Harvester]] (ancient) |
| Rank · level | SS · 236 (218–253) |
| Menace | 5 · Horror |
| Element · weakness | Blood · Light |
| Size | 9 m |
| Behaviour | Aggressive (aggressive_chase+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 53477 · 572 · 668 · 1336 · 1240 · 90 |
| XP · gold | 18792 · 3152 |
| Ring | 9 |
| Rig · animation | [[Systems/Rigs/spirit_float\|spirit_float]] · `anim_floating` |
| Habitats | [[Regions/Vesper\|Vesper]] |
| Genre | Cosmic Fantasy |
| Trope | Serene moon-raiders harvesting gem people (Land of the Lustrous) |

**Field note:** Weak to Light. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/spirit_float|spirit_float]] (rigId); animation set `anim_floating`.
- **Dimensions:** 9 m high × 2.7 m long × 5.76 m wide; prefab scale 9.
- **Physics:** 80.2 kg, gravity ×0, poise 258, knockback resistance 0.21, death style `dissolve_into_motes`.
- **Navigation:** speed 18.8 m/s, turn 240°/s, stopping distance 2.65 m.
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

Ancient Vesper Harvester is a **horror lunar raider** encountered at SS rank, around level 236. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a lantern cage that holds stolen souls. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Vesper|Vesper]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_floating`, animation set `anim_floating`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Vesperites (Moon Raiders) SS|loot_vesperite_ss]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Vesper Glass\|Vesper Glass]] | 60% | 1–3 |
| [[Items/Captured Soul-Light\|Captured Soul-Light]] | 30% | 1–1 |
| [[Items/SS-Rank Monster Core\|SS-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (7)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Vesper\|Vesper]] | 7 | SS+, SSS, SSS-, S+, SS-, SS | 203–281 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05509` | Vesper Ancient Vesper Harvester Albino | [[Regions/Vesper\|Vesper]] | Albino | SS+ | 253 | 9 m | Night | Like a typical Ancient Vesper Harvester, but a rare pale form with white skin or fur and red eyes. |
| `pop_05510` | Vesper Ancient Vesper Harvester Elderborn | [[Regions/Vesper\|Vesper]] | Elderborn | SSS | 281 | 12.15 m | Night | Like a typical Ancient Vesper Harvester, but old and wise, with greying features and a cautious hunting style, with red-black coloring with faint ember veins. |
| `pop_05511` | Vesper Ancient Vesper Harvester Alpha | [[Regions/Vesper\|Vesper]] | Alpha | SSS- | 267 | 11.25 m | Night | Like a typical Ancient Vesper Harvester, but larger and scarred, and others of its kind follow it, with red-black coloring with faint ember veins. |
| `pop_05512` | Vesper Ancient Vesper Harvester Runt | [[Regions/Vesper\|Vesper]] | Runt | S+ | 203 | 6.3 m | Night | Like a typical Ancient Vesper Harvester, but smaller and scrappier than usual, with red-black coloring with faint ember veins. |
| `pop_05513` | Vesper Ancient Vesper Harvester Juvenile | [[Regions/Vesper\|Vesper]] | Juvenile | SS- | 218 | 7.65 m | Night | Like a typical Ancient Vesper Harvester, but young, with brighter colors and unworn features, with red-black coloring with faint ember veins. |
| `pop_05514` | Vesper Ancient Vesper Harvester | [[Regions/Vesper\|Vesper]] | Adult | SS | 236 | 9 m | Night | A typical adult Ancient Vesper Harvester of this region, with red-black coloring with faint ember veins. |
| `pop_05515` | Vesper Ancient Vesper Harvester Scarred | [[Regions/Vesper\|Vesper]] | Scarred | SS+ | 253 | 9.9 m | Night | Like a typical Ancient Vesper Harvester, but covered in old battle scars, with red-black coloring with faint ember veins. |

## Design recipe

Rig `rig_floating` · mesh `floating_base` · material `porcelain_red_glow` · VFX `blood_mist` · palette `#8b0000` `#d7263d` `#1a0505` · broken symmetry, mimicry, audio-first reveal
