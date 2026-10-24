---
type: monster
id: mon_vesper_touched_moon_archer
family: "Vesperites (Moon Raiders)"
rank: "A-"
tier: variant
tags: [monster, vesperites-moon-raiders]
---
# Vesper-Touched Moon Archer

> The Vesper-Touched Moon Archer is a person-sized creature with a broad-shouldered humanoid build, about 2 m tall. Its porcelain shell is patchy and subtly wrong, as if assembled from memory, colored in arterial crimson and dried-blood brown. Its most striking feature is a bow of red glass and robes like falling silk. It has eyes set slightly too far apart. An elegant crest and glowing veins of mana mark it as a champion of its kind. It freezes whenever it is looked at, surrounded by a faint red mist that smells of iron. Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.

| Field | Value |
|---|---|
| Family · type | [[Families/Vesperites (Moon Raiders)|Vesperites (Moon Raiders)]] · Lunar Raider |
| Variant of | [[Monsters/Vesperites (Moon Raiders)/Moon Archer\|Moon Archer]] (corrupted) |
| Rank · level | A- · 132 (120–146) |
| Menace | 4 · Dread |
| Element · weakness | Blood · Light |
| Size | 2 m |
| Behaviour | Aggressive (aggressive_chase+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 19050 · 646 · 538 · 430 · 484 · 100 |
| XP · gold | 7422 · 1399 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Sunscar\|Sunscar]], [[Regions/Lustrine Shores\|Lustrine Shores]] |
| Genre | Cosmic Fantasy |
| Trope | Serene moon-raiders harvesting gem people (Land of the Lustrous) |

**Field note:** Weak to Light. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 2 m high × 0.6 m long × 0.64 m wide; prefab scale 1.111.
- **Physics:** 114.4 kg, gravity ×1.5, poise 92, knockback resistance 0.45, death style `ragdoll`.
- **Navigation:** speed 5.45 m/s, turn 283°/s, stopping distance 0.74 m.
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

Vesper-Touched Moon Archer is a **dread lunar raider** encountered at A- rank, around level 132. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a bow of red glass and robes like falling silk. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Sunscar|Sunscar]], [[Regions/Lustrine Shores|Lustrine Shores]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

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
| [[Regions/Lustrine Shores\|Lustrine Shores]] | 6 | B+, A, S-, B, A+ | 108–173 | Night |
| [[Regions/Sunscar\|Sunscar]] | 5 | B, B+, A+, A, S- | 108–173 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05487` | Lustrine Shores Vesper-Touched Moon Archer Juvenile | [[Regions/Lustrine Shores\|Lustrine Shores]] | Juvenile | B+ | 120 | 1.7 m | Night | Like a typical Vesper-Touched Moon Archer, but young, with brighter colors and unworn features, with salt-crusted, barnacle-flecked hide. |
| `pop_05488` | Lustrine Shores Vesper-Touched Moon Archer Scarred | [[Regions/Lustrine Shores\|Lustrine Shores]] | Scarred | A | 146 | 2.2 m | Night | Like a typical Vesper-Touched Moon Archer, but covered in old battle scars, with salt-crusted, barnacle-flecked hide. |
| `pop_05489` | Sunscar Vesper-Touched Moon Archer Runt | [[Regions/Sunscar\|Sunscar]] | Runt | B | 108 | 1.4 m | Night | Like a typical Vesper-Touched Moon Archer, but smaller and scrappier than usual, with sun-bleached, sand-scoured coloring. |
| `pop_05490` | Lustrine Shores Vesper-Touched Moon Archer Elderborn | [[Regions/Lustrine Shores\|Lustrine Shores]] | Elderborn | S- | 173 | 2.7 m | Night | Like a typical Vesper-Touched Moon Archer, but old and wise, with greying features and a cautious hunting style, with salt-crusted, barnacle-flecked hide. |
| `pop_05491` | Sunscar Vesper-Touched Moon Archer Juvenile | [[Regions/Sunscar\|Sunscar]] | Juvenile | B+ | 120 | 1.7 m | Night | Like a typical Vesper-Touched Moon Archer, but young, with brighter colors and unworn features, with sun-bleached, sand-scoured coloring. |
| `pop_05492` | Sunscar Vesper-Touched Moon Archer Alpha | [[Regions/Sunscar\|Sunscar]] | Alpha | A+ | 159 | 2.5 m | Night | Like a typical Vesper-Touched Moon Archer, but larger and scarred, and others of its kind follow it, with sun-bleached, sand-scoured coloring. |
| `pop_05493` | Sunscar Vesper-Touched Moon Archer Albino | [[Regions/Sunscar\|Sunscar]] | Albino | A | 146 | 2 m | Night | Like a typical Vesper-Touched Moon Archer, but a rare pale form with white skin or fur and red eyes. |
| `pop_05494` | Lustrine Shores Vesper-Touched Moon Archer Runt | [[Regions/Lustrine Shores\|Lustrine Shores]] | Runt | B | 108 | 1.4 m | Night | Like a typical Vesper-Touched Moon Archer, but smaller and scrappier than usual, with salt-crusted, barnacle-flecked hide. |
| `pop_05495` | Lustrine Shores Vesper-Touched Moon Archer Albino | [[Regions/Lustrine Shores\|Lustrine Shores]] | Albino | A | 146 | 2 m | Night | Like a typical Vesper-Touched Moon Archer, but a rare pale form with white skin or fur and red eyes. |
| `pop_05496` | Sunscar Vesper-Touched Moon Archer Elderborn | [[Regions/Sunscar\|Sunscar]] | Elderborn | S- | 173 | 2.7 m | Night | Like a typical Vesper-Touched Moon Archer, but old and wise, with greying features and a cautious hunting style, with sun-bleached, sand-scoured coloring. |
| `pop_05497` | Lustrine Shores Vesper-Touched Moon Archer Alpha | [[Regions/Lustrine Shores\|Lustrine Shores]] | Alpha | A+ | 159 | 2.5 m | Night | Like a typical Vesper-Touched Moon Archer, but larger and scarred, and others of its kind follow it, with salt-crusted, barnacle-flecked hide. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `porcelain_red_glow` · VFX `blood_mist` · palette `#8b0000` `#d7263d` `#1a0505` · elongated, irregular silhouette; still-then-sudden timing
