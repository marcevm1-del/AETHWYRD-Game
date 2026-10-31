---
type: monster
id: mon_vesper_shard_thrall
family: "Vesperites (Moon Raiders)"
rank: "C"
tier: core
tags: [monster, vesperites-moon-raiders]
---
# Vesper Shard-Thrall

![[mon_vesper_shard_thrall_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_vesper_shard_thrall_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,498 tris · 0.691 × 0.736 × 1.8 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Vesper Shard-Thrall is a person-sized creature with an upright humanoid build, about 1.8 m tall. Its porcelain shell is patchy and subtly wrong, as if assembled from memory, colored in dusk violet, with crimson markings. Guild sketches always show porcelain skin cracked with red light. It has eyes that never blink. Battle-worn plates and trophies hang from its body. It moves in jerky stop-motion bursts, surrounded by a faint red mist that smells of iron.

| Field | Value |
|---|---|
| Family · type | [[Families/Vesperites (Moon Raiders)|Vesperites (Moon Raiders)]] · Lunar Raider |
| Rank · level | C · 76 (65–86) |
| Menace | 4 · Dread |
| Element · weakness | Blood · Light |
| Size | 1.8 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 8073 · 377 · 314 · 251 · 283 · 100 |
| XP · gold | 3073 · 648 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Strife Marches\|Strife Marches]], [[Regions/Sunscar\|Sunscar]] |
| Genre | Cosmic Fantasy |
| Trope | Serene moon-raiders harvesting gem people (Land of the Lustrous) |

**Field note:** Weak to Light. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 1.8 m high × 0.54 m long × 0.58 m wide; prefab scale 1.
- **Physics:** 83.4 kg, gravity ×1.5, poise 73, knockback resistance 0.39, death style `ragdoll`.
- **Navigation:** speed 5.17 m/s, turn 298°/s, stopping distance 0.71 m.
- **Attack count:** 5; **signature:** porcelain skin cracked with red light.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Moonglass Shard\|Moonglass Shard]] | ranged | 1.3 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Blood Lance\|Blood Lance]] | magic | 1.5 | 10 s | Blood | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Vesper Shard-Thrall is a **dread lunar raider** encountered at C rank, around level 76. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** porcelain skin cracked with red light. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Strife Marches|Strife Marches]], [[Regions/Sunscar|Sunscar]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Vesperites (Moon Raiders) C|loot_vesperite_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Vesper Glass\|Vesper Glass]] | 60% | 1–3 |
| [[Items/Captured Soul-Light\|Captured Soul-Light]] | 30% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Vesperites (Moon Raiders)/Ruin Vesper Shard-Thrall|Ruin Vesper Shard-Thrall]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Aldmere\|Aldmere]] | 3 | C+, D+ | 56–86 | Night |
| [[Regions/Sunscar\|Sunscar]] | 3 | C-, B, B- | 65–108 | Night |
| [[Regions/Strife Marches\|Strife Marches]] | 5 | C+, B-, C, C-, B | 65–108 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02629` | Aldmere Vesper Shard-Thrall Albino | [[Regions/Aldmere\|Aldmere]] | Albino | C+ | 86 | 1.8 m | Night | Like a typical Vesper Shard-Thrall, but a rare pale form with white skin or fur and red eyes. |
| `pop_02630` | Sunscar Vesper Shard-Thrall Juvenile | [[Regions/Sunscar\|Sunscar]] | Juvenile | C- | 65 | 1.53 m | Night | Like a typical Vesper Shard-Thrall, but young, with brighter colors and unworn features, with sun-bleached, sand-scoured coloring. |
| `pop_02631` | Sunscar Vesper Shard-Thrall Elderborn | [[Regions/Sunscar\|Sunscar]] | Elderborn | B | 108 | 2.43 m | Night | Like a typical Vesper Shard-Thrall, but old and wise, with greying features and a cautious hunting style, with sun-bleached, sand-scoured coloring. |
| `pop_02632` | Strife Marches Vesper Shard-Thrall Albino | [[Regions/Strife Marches\|Strife Marches]] | Albino | C+ | 86 | 1.8 m | Night | Like a typical Vesper Shard-Thrall, but a rare pale form with white skin or fur and red eyes. |
| `pop_02633` | Strife Marches Vesper Shard-Thrall Alpha | [[Regions/Strife Marches\|Strife Marches]] | Alpha | B- | 96 | 2.25 m | Night | Like a typical Vesper Shard-Thrall, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_02634` | Strife Marches Vesper Shard-Thrall | [[Regions/Strife Marches\|Strife Marches]] | Adult | C | 76 | 1.8 m | Night | A typical adult Vesper Shard-Thrall of this region, with golden, grass-toned coloring. |
| `pop_02635` | Aldmere Vesper Shard-Thrall Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | C+ | 86 | 1.98 m | Night | Like a typical Vesper Shard-Thrall, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_02636` | Strife Marches Vesper Shard-Thrall Juvenile | [[Regions/Strife Marches\|Strife Marches]] | Juvenile | C- | 65 | 1.53 m | Night | Like a typical Vesper Shard-Thrall, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_02637` | Strife Marches Vesper Shard-Thrall Elderborn | [[Regions/Strife Marches\|Strife Marches]] | Elderborn | B | 108 | 2.43 m | Night | Like a typical Vesper Shard-Thrall, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_02638` | Aldmere Vesper Shard-Thrall Runt | [[Regions/Aldmere\|Aldmere]] | Runt | D+ | 56 | 1.26 m | Night | Like a typical Vesper Shard-Thrall, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_02639` | Sunscar Vesper Shard-Thrall Alpha | [[Regions/Sunscar\|Sunscar]] | Alpha | B- | 96 | 2.25 m | Night | Like a typical Vesper Shard-Thrall, but larger and scarred, and others of its kind follow it, with sun-bleached, sand-scoured coloring. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `porcelain_red_glow` · VFX `blood_mist` · palette `#67598a` `#564976` `#e0344a` · elongated, irregular silhouette; still-then-sudden timing
