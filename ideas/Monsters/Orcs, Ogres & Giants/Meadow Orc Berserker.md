---
type: monster
id: mon_meadow_orc_berserker
family: "Orcs, Ogres & Giants"
rank: "C-"
tier: variant
tags: [monster, orcs-ogres-giants]
---
# Meadow Orc Berserker

![[mon_meadow_orc_berserker_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_meadow_orc_berserker_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Meadow Orc Berserker is a person-sized creature with an upright humanoid build, about 2.2 m tall. Its hide is rough, scarred and spiked, colored in pale jade and cloud white. Guild sketches always show blood-red war paint and broken chains on its wrists. It has narrow glowing eyes. Battle-worn plates and trophies hang from its body. It charges without hesitation, surrounded by swirling leaves and a constant breeze. Adapted to plains lands, it has golden, grass-toned coloring.

| Field | Value |
|---|---|
| Family · type | [[Families/Orcs, Ogres & Giants|Orcs, Ogres & Giants]] · Giant |
| Variant of | [[Monsters/Orcs, Ogres & Giants/Orc Berserker\|Orc Berserker]] (regional) |
| Rank · level | C- · 65 (56–76) |
| Menace | 3 · Menacing |
| Element · weakness | Wind · Fire |
| Size | 2.2 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 6857 · 324 · 270 · 216 · 243 · 100 |
| XP · gold | 2395 · 521 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Vharlen\|Vharlen]], [[Regions/Fanghold\|Fanghold]], [[Regions/Zaruma\|Zaruma]] |
| Genre | Classic Fantasy |
| Trope | Orc warbands and the Orc Disaster that devours its way to power (Tensura) |

**Field note:** Weak to Fire. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 2.2 m high × 0.66 m long × 0.7 m wide; prefab scale 1.222.
- **Physics:** 124.6 kg, gravity ×1.2, poise 80, knockback resistance 0.39, death style `ragdoll`.
- **Navigation:** speed 6.48 m/s, turn 270°/s, stopping distance 0.77 m.
- **Attack count:** 5; **signature:** blood-red war paint and broken chains on its wrists.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/War Cry\|War Cry]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Gale Cutter\|Gale Cutter]] | magic | 1.5 | 10 s | Wind | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Meadow Orc Berserker is a **menacing giant** encountered at C- rank, around level 65. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** blood-red war paint and broken chains on its wrists. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Vharlen|Vharlen]], [[Regions/Fanghold|Fanghold]], [[Regions/Zaruma|Zaruma]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Orcs, Ogres & Giants C|loot_orc_giant_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Tusk\|Tusk]] | 60% | 1–3 |
| [[Items/Giant's Hide\|Giant's Hide]] | 30% | 1–1 |
| [[Items/Crude Iron\|Crude Iron]] | 15% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Zaruma\|Zaruma]] | 4 | D, C-, C, C+ | 48–86 | Day & Night |
| [[Regions/Fanghold\|Fanghold]] | 4 | B-, D, D+, C | 48–96 | Day & Night |
| [[Regions/Vharlen\|Vharlen]] | 3 | C, C+ | 76–86 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03980` | Zaruma Meadow Orc Berserker Runt | [[Regions/Zaruma\|Zaruma]] | Runt | D | 48 | 1.54 m | Day & Night | Like a typical Meadow Orc Berserker, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_03981` | Zaruma Meadow Orc Berserker | [[Regions/Zaruma\|Zaruma]] | Adult | C- | 65 | 2.2 m | Day & Night | A typical adult Meadow Orc Berserker of this region, with golden, grass-toned coloring. |
| `pop_03982` | Zaruma Meadow Orc Berserker Scarred | [[Regions/Zaruma\|Zaruma]] | Scarred | C | 76 | 2.42 m | Day & Night | Like a typical Meadow Orc Berserker, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_03983` | Zaruma Meadow Orc Berserker Alpha | [[Regions/Zaruma\|Zaruma]] | Alpha | C+ | 86 | 2.75 m | Day & Night | Like a typical Meadow Orc Berserker, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_03984` | Fanghold Meadow Orc Berserker Elderborn | [[Regions/Fanghold\|Fanghold]] | Elderborn | B- | 96 | 2.97 m | Day & Night | Like a typical Meadow Orc Berserker, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_03985` | Fanghold Meadow Orc Berserker Runt | [[Regions/Fanghold\|Fanghold]] | Runt | D | 48 | 1.54 m | Day & Night | Like a typical Meadow Orc Berserker, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_03986` | Fanghold Meadow Orc Berserker Juvenile | [[Regions/Fanghold\|Fanghold]] | Juvenile | D+ | 56 | 1.87 m | Day & Night | Like a typical Meadow Orc Berserker, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_03987` | Vharlen Meadow Orc Berserker Scarred | [[Regions/Vharlen\|Vharlen]] | Scarred | C | 76 | 2.42 m | Day & Night | Like a typical Meadow Orc Berserker, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_03988` | Vharlen Meadow Orc Berserker Alpha | [[Regions/Vharlen\|Vharlen]] | Alpha | C+ | 86 | 2.75 m | Day & Night | Like a typical Meadow Orc Berserker, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_03989` | Fanghold Meadow Orc Berserker Scarred | [[Regions/Fanghold\|Fanghold]] | Scarred | C | 76 | 2.42 m | Day & Night | Like a typical Meadow Orc Berserker, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_03990` | Vharlen Meadow Orc Berserker Albino | [[Regions/Vharlen\|Vharlen]] | Albino | C | 76 | 2.2 m | Day & Night | Like a typical Meadow Orc Berserker, but a rare pale form with white skin or fur and red eyes. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `thick_skin` · VFX `wind_ribbons` · palette `#a8e6cf` `#dcedc1` `#5b8c85` · triangle-based silhouette, sharp asymmetric spikes
