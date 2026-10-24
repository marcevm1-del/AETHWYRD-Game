---
type: monster
id: mon_meadow_orc_lord
family: "Orcs, Ogres & Giants"
rank: "B+"
tier: variant
tags: [monster, orcs-ogres-giants]
---
# Meadow Orc Lord

> The Meadow Orc Lord is a large creature with an upright humanoid build, about 2.6 m tall. Its hide is rough, scarred and spiked, colored in pale jade and cloud white. Look for a horned helm and a cloak of wolf pelts. It has narrow glowing eyes. Faint runes glow along its body when it fights. It strides with heavy steps, surrounded by swirling leaves and a constant breeze. Adapted to plains lands, it has golden, grass-toned coloring.

| Field | Value |
|---|---|
| Family · type | [[Families/Orcs, Ogres & Giants|Orcs, Ogres & Giants]] · Giant |
| Variant of | [[Monsters/Orcs, Ogres & Giants/Orc Lord\|Orc Lord]] (regional) |
| Rank · level | B+ · 120 (108–132) |
| Menace | 3 · Menacing |
| Element · weakness | Wind · Fire |
| Size | 2.6 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 18071 · 588 · 490 · 392 · 441 · 100 |
| XP · gold | 6373 · 1225 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Vharlen\|Vharlen]], [[Regions/Fanghold\|Fanghold]], [[Regions/Zaruma\|Zaruma]] |
| Genre | Classic Fantasy |
| Trope | Orc warbands and the Orc Disaster that devours its way to power (Tensura) |

**Field note:** Weak to Fire. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 2.6 m high × 0.78 m long × 0.83 m wide; prefab scale 1.444.
- **Physics:** 205.6 kg, gravity ×1.2, poise 96, knockback resistance 0.42, death style `ragdoll`.
- **Navigation:** speed 7.04 m/s, turn 248°/s, stopping distance 0.84 m.
- **Attack count:** 5; **signature:** a horned helm and a cloak of wolf pelts.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/War Cry\|War Cry]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Gale Cutter\|Gale Cutter]] | magic | 1.5 | 10 s | Wind | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Meadow Orc Lord is a **menacing giant** encountered at B+ rank, around level 120. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a horned helm and a cloak of wolf pelts. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Vharlen|Vharlen]], [[Regions/Fanghold|Fanghold]], [[Regions/Zaruma|Zaruma]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Orcs, Ogres & Giants B|loot_orc_giant_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Tusk\|Tusk]] | 60% | 1–3 |
| [[Items/Giant's Hide\|Giant's Hide]] | 30% | 1–1 |
| [[Items/Crude Iron\|Crude Iron]] | 15% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Fanghold\|Fanghold]] | 4 | A-, B-, B+, A | 96–146 | Day & Night |
| [[Regions/Zaruma\|Zaruma]] | 3 | B-, A-, A | 96–146 | Day & Night |
| [[Regions/Vharlen\|Vharlen]] | 4 | A+, A, A-, B | 108–159 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04013` | Fanghold Meadow Orc Lord Scarred | [[Regions/Fanghold\|Fanghold]] | Scarred | A- | 132 | 2.86 m | Day & Night | Like a typical Meadow Orc Lord, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_04014` | Zaruma Meadow Orc Lord Runt | [[Regions/Zaruma\|Zaruma]] | Runt | B- | 96 | 1.82 m | Day & Night | Like a typical Meadow Orc Lord, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_04015` | Vharlen Meadow Orc Lord Elderborn | [[Regions/Vharlen\|Vharlen]] | Elderborn | A+ | 159 | 3.51 m | Day & Night | Like a typical Meadow Orc Lord, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_04016` | Vharlen Meadow Orc Lord Alpha | [[Regions/Vharlen\|Vharlen]] | Alpha | A | 146 | 3.25 m | Day & Night | Like a typical Meadow Orc Lord, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_04017` | Zaruma Meadow Orc Lord Scarred | [[Regions/Zaruma\|Zaruma]] | Scarred | A- | 132 | 2.86 m | Day & Night | Like a typical Meadow Orc Lord, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_04018` | Vharlen Meadow Orc Lord Scarred | [[Regions/Vharlen\|Vharlen]] | Scarred | A- | 132 | 2.86 m | Day & Night | Like a typical Meadow Orc Lord, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_04019` | Fanghold Meadow Orc Lord Runt | [[Regions/Fanghold\|Fanghold]] | Runt | B- | 96 | 1.82 m | Day & Night | Like a typical Meadow Orc Lord, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_04020` | Zaruma Meadow Orc Lord Alpha | [[Regions/Zaruma\|Zaruma]] | Alpha | A | 146 | 3.25 m | Day & Night | Like a typical Meadow Orc Lord, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_04021` | Vharlen Meadow Orc Lord Juvenile | [[Regions/Vharlen\|Vharlen]] | Juvenile | B | 108 | 2.21 m | Day & Night | Like a typical Meadow Orc Lord, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_04022` | Fanghold Meadow Orc Lord | [[Regions/Fanghold\|Fanghold]] | Adult | B+ | 120 | 2.6 m | Day & Night | A typical adult Meadow Orc Lord of this region, with golden, grass-toned coloring. |
| `pop_04023` | Fanghold Meadow Orc Lord Alpha | [[Regions/Fanghold\|Fanghold]] | Alpha | A | 146 | 3.25 m | Day & Night | Like a typical Meadow Orc Lord, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `thick_skin` · VFX `wind_ribbons` · palette `#a8e6cf` `#dcedc1` `#5b8c85` · triangle-based silhouette, sharp asymmetric spikes
