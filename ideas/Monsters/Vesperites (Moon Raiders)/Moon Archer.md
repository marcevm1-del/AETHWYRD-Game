---
type: monster
id: mon_moon_archer
family: "Vesperites (Moon Raiders)"
rank: "B"
tier: core
tags: [monster, vesperites-moon-raiders]
---
# Moon Archer

![[mon_moon_archer_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_moon_archer_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,608 tris · 1.084 × 1.371 × 2 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Moon Archer is a person-sized creature with a lean humanoid frame, about 2 m tall. Its porcelain shell is rough, scarred and spiked, colored in twilight blue, with crimson markings. Guild sketches always show a bow of red glass and robes like falling silk. It has narrow glowing eyes. Faint runes glow along its body when it fights. It circles its prey, surrounded by a faint red mist that smells of iron.

| Field | Value |
|---|---|
| Family · type | [[Families/Vesperites (Moon Raiders)|Vesperites (Moon Raiders)]] · Lunar Raider |
| Rank · level | B · 108 (96–120) |
| Menace | 3 · Menacing |
| Element · weakness | Blood · Light |
| Size | 2 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 14120 · 530 · 442 · 354 · 398 · 100 |
| XP · gold | 5386 · 1057 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Sunscar\|Sunscar]], [[Regions/Strife Marches\|Strife Marches]], [[Regions/Lustrine Shores\|Lustrine Shores]] |
| Genre | Cosmic Fantasy |
| Trope | Serene moon-raiders harvesting gem people (Land of the Lustrous) |

**Field note:** Weak to Light. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 2 m high × 0.6 m long × 0.64 m wide; prefab scale 1.111.
- **Physics:** 114.4 kg, gravity ×1.5, poise 84, knockback resistance 0.42, death style `ragdoll`.
- **Navigation:** speed 5.72 m/s, turn 283°/s, stopping distance 0.74 m.
- **Attack count:** 5; **signature:** a bow of red glass and robes like falling silk.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Moonglass Shard\|Moonglass Shard]] | ranged | 1.3 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Blood Lance\|Blood Lance]] | magic | 1.5 | 10 s | Blood | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Moon Archer is a **menacing lunar raider** encountered at B rank, around level 108. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a bow of red glass and robes like falling silk. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Sunscar|Sunscar]], [[Regions/Strife Marches|Strife Marches]], [[Regions/Lustrine Shores|Lustrine Shores]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Vesperites (Moon Raiders) B|loot_vesperite_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Vesper Glass\|Vesper Glass]] | 60% | 1–3 |
| [[Items/Captured Soul-Light\|Captured Soul-Light]] | 30% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Vesperites (Moon Raiders)/Vesper-Touched Moon Archer|Vesper-Touched Moon Archer]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Lustrine Shores\|Lustrine Shores]] | 3 | B, A-, B+ | 108–132 | Day & Night |
| [[Regions/Sunscar\|Sunscar]] | 4 | A-, B, B+, A | 108–146 | Day & Night |
| [[Regions/Strife Marches\|Strife Marches]] | 4 | A-, B, C+, B+ | 86–132 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02640` | Lustrine Shores Moon Archer | [[Regions/Lustrine Shores\|Lustrine Shores]] | Adult | B | 108 | 2 m | Day & Night | A typical adult Moon Archer of this region, with salt-crusted, barnacle-flecked hide. |
| `pop_02641` | Sunscar Moon Archer Alpha | [[Regions/Sunscar\|Sunscar]] | Alpha | A- | 132 | 2.5 m | Day & Night | Like a typical Moon Archer, but larger and scarred, and others of its kind follow it, with sun-bleached, sand-scoured coloring. |
| `pop_02642` | Strife Marches Moon Archer Alpha | [[Regions/Strife Marches\|Strife Marches]] | Alpha | A- | 132 | 2.5 m | Day & Night | Like a typical Moon Archer, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_02643` | Sunscar Moon Archer | [[Regions/Sunscar\|Sunscar]] | Adult | B | 108 | 2 m | Day & Night | A typical adult Moon Archer of this region, with sun-bleached, sand-scoured coloring. |
| `pop_02644` | Sunscar Moon Archer Scarred | [[Regions/Sunscar\|Sunscar]] | Scarred | B+ | 120 | 2.2 m | Day & Night | Like a typical Moon Archer, but covered in old battle scars, with sun-bleached, sand-scoured coloring. |
| `pop_02645` | Strife Marches Moon Archer | [[Regions/Strife Marches\|Strife Marches]] | Adult | B | 108 | 2 m | Day & Night | A typical adult Moon Archer of this region, with golden, grass-toned coloring. |
| `pop_02646` | Sunscar Moon Archer Elderborn | [[Regions/Sunscar\|Sunscar]] | Elderborn | A | 146 | 2.7 m | Day & Night | Like a typical Moon Archer, but old and wise, with greying features and a cautious hunting style, with sun-bleached, sand-scoured coloring. |
| `pop_02647` | Strife Marches Moon Archer Runt | [[Regions/Strife Marches\|Strife Marches]] | Runt | C+ | 86 | 1.4 m | Day & Night | Like a typical Moon Archer, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_02648` | Lustrine Shores Moon Archer Alpha | [[Regions/Lustrine Shores\|Lustrine Shores]] | Alpha | A- | 132 | 2.5 m | Day & Night | Like a typical Moon Archer, but larger and scarred, and others of its kind follow it, with salt-crusted, barnacle-flecked hide. |
| `pop_02649` | Lustrine Shores Moon Archer Scarred | [[Regions/Lustrine Shores\|Lustrine Shores]] | Scarred | B+ | 120 | 2.2 m | Day & Night | Like a typical Moon Archer, but covered in old battle scars, with salt-crusted, barnacle-flecked hide. |
| `pop_02650` | Strife Marches Moon Archer Albino | [[Regions/Strife Marches\|Strife Marches]] | Albino | B+ | 120 | 2 m | Day & Night | Like a typical Moon Archer, but a rare pale form with white skin or fur and red eyes. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `porcelain_red_glow` · VFX `blood_mist` · palette `#384a6e` `#29364f` `#e0344a` · triangle-based silhouette, sharp asymmetric spikes
