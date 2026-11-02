---
type: monster
id: mon_ruin_vesper_shard_thrall
family: "Vesperites (Moon Raiders)"
rank: "C+"
tier: variant
tags: [monster, vesperites-moon-raiders]
---
# Ruin Vesper Shard-Thrall

![[mon_ruin_vesper_shard_thrall_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_ruin_vesper_shard_thrall_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,106 tris · 0.751 × 0.8 × 1.8 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Ruin Vesper Shard-Thrall is a person-sized creature with an upright humanoid build, about 1.8 m tall. Its porcelain shell is patchy and subtly wrong, as if assembled from memory, colored in dusk violet. Guild sketches always show porcelain skin cracked with red light. It has pale, pupil-less eyes. Battle-worn plates and trophies hang from its body. It freezes whenever it is looked at, surrounded by shadows that lean toward it. Adapted to ruins lands, it has dust-grey coloring and old rune scars.

| Field | Value |
|---|---|
| Family · type | [[Families/Vesperites (Moon Raiders)|Vesperites (Moon Raiders)]] · Lunar Raider |
| Variant of | [[Monsters/Vesperites (Moon Raiders)/Vesper Shard-Thrall\|Vesper Shard-Thrall]] (regional) |
| Rank · level | C+ · 86 (76–96) |
| Menace | 4 · Dread |
| Element · weakness | Dark · Light |
| Size | 1.8 m |
| Behaviour | Aggressive (aggressive_chase+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 9701 · 425 · 354 · 283 · 319 · 100 |
| XP · gold | 3743 · 769 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Strife Marches\|Strife Marches]], [[Regions/Sunscar\|Sunscar]], [[Regions/Aldmere\|Aldmere]] |
| Genre | Cosmic Fantasy |
| Trope | Serene moon-raiders harvesting gem people (Land of the Lustrous) |

**Field note:** Weak to Light. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 1.8 m high × 0.54 m long × 0.58 m wide; prefab scale 1.
- **Physics:** 75.8 kg, gravity ×1.5, poise 73, knockback resistance 0.39, death style `ragdoll`.
- **Navigation:** speed 5.43 m/s, turn 298°/s, stopping distance 0.71 m.
- **Attack count:** 5; **signature:** porcelain skin cracked with red light.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Moonglass Shard\|Moonglass Shard]] | ranged | 1.3 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Ruin Vesper Shard-Thrall is a **dread lunar raider** encountered at C+ rank, around level 86. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** porcelain skin cracked with red light. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Strife Marches|Strife Marches]], [[Regions/Sunscar|Sunscar]], [[Regions/Aldmere|Aldmere]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Vesperites (Moon Raiders) C|loot_vesperite_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Vesper Glass\|Vesper Glass]] | 60% | 1–3 |
| [[Items/Captured Soul-Light\|Captured Soul-Light]] | 30% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Sunscar\|Sunscar]] | 4 | C-, C+, B+, B | 65–120 | Night |
| [[Regions/Aldmere\|Aldmere]] | 4 | B+, B, C, C- | 65–120 | Night |
| [[Regions/Strife Marches\|Strife Marches]] | 3 | B-, B, C+ | 86–108 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05476` | Sunscar Ruin Vesper Shard-Thrall Runt | [[Regions/Sunscar\|Sunscar]] | Runt | C- | 65 | 1.26 m | Night | Like a typical Ruin Vesper Shard-Thrall, but smaller and scrappier than usual, with sun-bleached, sand-scoured coloring. |
| `pop_05477` | Aldmere Ruin Vesper Shard-Thrall Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | B+ | 120 | 2.43 m | Night | Like a typical Ruin Vesper Shard-Thrall, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_05478` | Aldmere Ruin Vesper Shard-Thrall Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | B | 108 | 2.25 m | Night | Like a typical Ruin Vesper Shard-Thrall, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_05479` | Sunscar Ruin Vesper Shard-Thrall | [[Regions/Sunscar\|Sunscar]] | Adult | C+ | 86 | 1.8 m | Night | A typical adult Ruin Vesper Shard-Thrall of this region, with sun-bleached, sand-scoured coloring. |
| `pop_05480` | Strife Marches Ruin Vesper Shard-Thrall Scarred | [[Regions/Strife Marches\|Strife Marches]] | Scarred | B- | 96 | 1.98 m | Night | Like a typical Ruin Vesper Shard-Thrall, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_05481` | Strife Marches Ruin Vesper Shard-Thrall Alpha | [[Regions/Strife Marches\|Strife Marches]] | Alpha | B | 108 | 2.25 m | Night | Like a typical Ruin Vesper Shard-Thrall, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_05482` | Sunscar Ruin Vesper Shard-Thrall Elderborn | [[Regions/Sunscar\|Sunscar]] | Elderborn | B+ | 120 | 2.43 m | Night | Like a typical Ruin Vesper Shard-Thrall, but old and wise, with greying features and a cautious hunting style, with sun-bleached, sand-scoured coloring. |
| `pop_05483` | Aldmere Ruin Vesper Shard-Thrall Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | C | 76 | 1.53 m | Night | Like a typical Ruin Vesper Shard-Thrall, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_05484` | Sunscar Ruin Vesper Shard-Thrall Alpha | [[Regions/Sunscar\|Sunscar]] | Alpha | B | 108 | 2.25 m | Night | Like a typical Ruin Vesper Shard-Thrall, but larger and scarred, and others of its kind follow it, with sun-bleached, sand-scoured coloring. |
| `pop_05485` | Strife Marches Ruin Vesper Shard-Thrall | [[Regions/Strife Marches\|Strife Marches]] | Adult | C+ | 86 | 1.8 m | Night | A typical adult Ruin Vesper Shard-Thrall of this region, with golden, grass-toned coloring. |
| `pop_05486` | Aldmere Ruin Vesper Shard-Thrall Runt | [[Regions/Aldmere\|Aldmere]] | Runt | C- | 65 | 1.26 m | Night | Like a typical Ruin Vesper Shard-Thrall, but smaller and scrappier than usual, with golden, grass-toned coloring. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `porcelain_red_glow` · VFX `shadow_wisps` · palette `#594c76` `#4a3f66` `#9a86d8` · elongated, irregular silhouette; still-then-sudden timing
