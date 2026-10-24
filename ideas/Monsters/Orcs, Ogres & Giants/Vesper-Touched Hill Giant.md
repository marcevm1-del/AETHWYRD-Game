---
type: monster
id: mon_vesper_touched_hill_giant
family: "Orcs, Ogres & Giants"
rank: "A"
tier: variant
tags: [monster, orcs-ogres-giants]
---
# Vesper-Touched Hill Giant

> The Vesper-Touched Hill Giant is a huge creature with a massive hunched brute frame, about 7 m tall. Its hide is rough, scarred and spiked, colored in ochre, clay and mossy stone. Survivors describe a boulder slung over its shoulder like a sack. It has eyes that catch torchlight like coins. An elegant crest and glowing veins of mana mark it as a champion of its kind. It strides with heavy steps, surrounded by pebbles that tremble and float near it. Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.

| Field | Value |
|---|---|
| Family · type | [[Families/Orcs, Ogres & Giants|Orcs, Ogres & Giants]] · Giant |
| Variant of | [[Monsters/Orcs, Ogres & Giants/Hill Giant\|Hill Giant]] (corrupted) |
| Rank · level | A · 146 (132–159) |
| Menace | 3 · Menacing |
| Element · weakness | Earth · Wind |
| Size | 7 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 42393 · 594 · 891 · 356 · 594 · 70 |
| XP · gold | 8719 · 1611 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/large_biped\|large_biped]] · `anim_large_biped` |
| Habitats | [[Regions/Frostveil\|Frostveil]], [[Regions/Iron Hold\|Iron Hold]] |
| Genre | Classic Fantasy |
| Trope | Orc warbands and the Orc Disaster that devours its way to power (Tensura) |

**Field note:** Weak to Wind. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/large_biped|large_biped]] (rigId); animation set `anim_large_biped`.
- **Dimensions:** 7 m high × 2.1 m long × 2.94 m wide; prefab scale 2.
- **Physics:** 8026.2 kg, gravity ×1.43, poise 346, knockback resistance 1, death style `heavy_fall_dust`.
- **Navigation:** speed 8.18 m/s, turn 144°/s, stopping distance 1.8 m.
- **Attack count:** 5; **signature:** a boulder slung over its shoulder like a sack.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stomp\|Stomp]] | aoe | 1.3 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Club Slam\|Club Slam]] | melee | 1.8 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Grab and Throw\|Grab and Throw]] | grab | 2 | 14 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/War Cry\|War Cry]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Vesper-Touched Hill Giant is a **menacing giant** encountered at A rank, around level 146. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a boulder slung over its shoulder like a sack. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Frostveil|Frostveil]], [[Regions/Iron Hold|Iron Hold]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_large_biped`, animation set `anim_large_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Orcs, Ogres & Giants A|loot_orc_giant_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Tusk\|Tusk]] | 60% | 1–3 |
| [[Items/Giant's Hide\|Giant's Hide]] | 30% | 1–1 |
| [[Items/Crude Iron\|Crude Iron]] | 15% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Iron Hold\|Iron Hold]] | 6 | A+, S-, A, S, A- | 132–188 | Day & Night |
| [[Regions/Frostveil\|Frostveil]] | 5 | S-, A+, A-, B+ | 120–173 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04024` | Iron Hold Vesper-Touched Hill Giant Albino | [[Regions/Iron Hold\|Iron Hold]] | Albino | A+ | 159 | 7 m | Day & Night | Like a typical Vesper-Touched Hill Giant, but a rare pale form with white skin or fur and red eyes. |
| `pop_04025` | Frostveil Vesper-Touched Hill Giant Alpha | [[Regions/Frostveil\|Frostveil]] | Alpha | S- | 173 | 8.75 m | Day & Night | Like a typical Vesper-Touched Hill Giant, but larger and scarred, and others of its kind follow it, with a thick, frost-rimed coat. |
| `pop_04026` | Iron Hold Vesper-Touched Hill Giant Alpha | [[Regions/Iron Hold\|Iron Hold]] | Alpha | S- | 173 | 8.75 m | Day & Night | Like a typical Vesper-Touched Hill Giant, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_04027` | Iron Hold Vesper-Touched Hill Giant | [[Regions/Iron Hold\|Iron Hold]] | Adult | A | 146 | 7 m | Day & Night | A typical adult Vesper-Touched Hill Giant of this region, with slate-grey coloring and hardened hide. |
| `pop_04028` | Iron Hold Vesper-Touched Hill Giant Elderborn | [[Regions/Iron Hold\|Iron Hold]] | Elderborn | S | 188 | 9.45 m | Day & Night | Like a typical Vesper-Touched Hill Giant, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_04029` | Iron Hold Vesper-Touched Hill Giant Juvenile | [[Regions/Iron Hold\|Iron Hold]] | Juvenile | A- | 132 | 5.95 m | Day & Night | Like a typical Vesper-Touched Hill Giant, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_04030` | Iron Hold Vesper-Touched Hill Giant Scarred | [[Regions/Iron Hold\|Iron Hold]] | Scarred | A+ | 159 | 7.7 m | Day & Night | Like a typical Vesper-Touched Hill Giant, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_04031` | Frostveil Vesper-Touched Hill Giant Albino | [[Regions/Frostveil\|Frostveil]] | Albino | A+ | 159 | 7 m | Day & Night | Like a typical Vesper-Touched Hill Giant, but a rare pale form with white skin or fur and red eyes. |
| `pop_04032` | Frostveil Vesper-Touched Hill Giant Juvenile | [[Regions/Frostveil\|Frostveil]] | Juvenile | A- | 132 | 5.95 m | Day & Night | Like a typical Vesper-Touched Hill Giant, but young, with brighter colors and unworn features, with a thick, frost-rimed coat. |
| `pop_04033` | Frostveil Vesper-Touched Hill Giant Scarred | [[Regions/Frostveil\|Frostveil]] | Scarred | A+ | 159 | 7.7 m | Day & Night | Like a typical Vesper-Touched Hill Giant, but covered in old battle scars, with a thick, frost-rimed coat. |
| `pop_04034` | Frostveil Vesper-Touched Hill Giant Runt | [[Regions/Frostveil\|Frostveil]] | Runt | B+ | 120 | 4.9 m | Day & Night | Like a typical Vesper-Touched Hill Giant, but smaller and scrappier than usual, with a thick, frost-rimed coat. |

## Design recipe

Rig `rig_large_biped` · mesh `large_biped_base` · material `thick_skin` · VFX `rock_debris` · palette `#8b5a2b` `#c2a878` `#4a4a3a` · triangle-based silhouette, sharp asymmetric spikes
