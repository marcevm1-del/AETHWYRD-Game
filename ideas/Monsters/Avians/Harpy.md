---
type: monster
id: mon_harpy
family: "Avians"
rank: "D"
tier: core
tags: [monster, avians]
---
# Harpy

![[mon_harpy_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_harpy_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Harpy is a person-sized creature with a broad-winged bird frame, about 1.6 m tall. Its plumage is rough, scarred and spiked, colored in pale jade and cloud white. Its most striking feature is a bird body with a shrieking human-like face. It has narrow glowing eyes. A distinctive marking runs along its back. It charges without hesitation, surrounded by swirling leaves and a constant breeze.

| Field | Value |
|---|---|
| Family · type | [[Families/Avians|Avians]] · Avian |
| Rank · level | D · 48 (40–56) |
| Menace | 3 · Menacing |
| Element · weakness | Wind · Fire |
| Size | 1.6 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 3037 · 202 · 162 · 141 · 162 · 135 |
| XP · gold | 1477 · 342 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/avian\|avian]] · `anim_avian` |
| Habitats | [[Regions/Hoshizora\|Hoshizora]], [[Regions/Fanghold\|Fanghold]], [[Regions/Strife Marches\|Strife Marches]], [[Regions/Velmark\|Velmark]] |
| Genre | High Fantasy |
| Trope | Griffons, harpies and phoenixes of classic fantasy |

**Field note:** Weak to Fire. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/avian|avian]] (rigId); animation set `anim_avian`.
- **Dimensions:** 0.74 m high × 1.6 m long × 2.75 m wide; prefab scale 2.667.
- **Physics:** 51.6 kg, gravity ×0.8, poise 76, knockback resistance 0.11, death style `tumble_feathers_burst`.
- **Navigation:** speed 4.28 m/s, turn 474°/s, stopping distance 0.72 m.
- **Attack count:** 5; **signature:** a bird body with a shrieking human-like face.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Peck\|Peck]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Swoop\|Swoop]] | dash | 1.4 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Screech\|Screech]] | debuff | 0 | 14 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Feather Volley\|Feather Volley]] | ranged | 1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Gale Cutter\|Gale Cutter]] | magic | 1.5 | 10 s | Wind | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Harpy is a **menacing avian** encountered at D rank, around level 48. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a bird body with a shrieking human-like face. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Hoshizora|Hoshizora]], [[Regions/Fanghold|Fanghold]], [[Regions/Strife Marches|Strife Marches]], [[Regions/Velmark|Velmark]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_avian`, animation set `anim_avian`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Avians D|loot_avian_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Feather\|Feather]] | 60% | 1–3 |
| [[Items/Talon\|Talon]] | 30% | 1–1 |
| [[Items/Egg\|Egg]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Avians/Phantom Harpy|Phantom Harpy]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Fanghold\|Fanghold]] | 3 | C, D+ | 56–76 | Day & Night |
| [[Regions/Velmark\|Velmark]] | 4 | D+, D-, C | 40–76 | Day & Night |
| [[Regions/Strife Marches\|Strife Marches]] | 3 | D, E+, D- | 32–48 | Day & Night |
| [[Regions/Hoshizora\|Hoshizora]] | 1 | E+ | 32–32 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02074` | Fanghold Harpy Elderborn | [[Regions/Fanghold\|Fanghold]] | Elderborn | C | 76 | 2.16 m | Day & Night | Like a typical Harpy, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_02075` | Fanghold Harpy Scarred | [[Regions/Fanghold\|Fanghold]] | Scarred | D+ | 56 | 1.76 m | Day & Night | Like a typical Harpy, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_02076` | Velmark Harpy Scarred | [[Regions/Velmark\|Velmark]] | Scarred | D+ | 56 | 1.76 m | Day & Night | Like a typical Harpy, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_02077` | Velmark Harpy Juvenile | [[Regions/Velmark\|Velmark]] | Juvenile | D- | 40 | 1.36 m | Day & Night | Like a typical Harpy, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_02078` | Fanghold Harpy Albino | [[Regions/Fanghold\|Fanghold]] | Albino | D+ | 56 | 1.6 m | Day & Night | Like a typical Harpy, but a rare pale form with white skin or fur and red eyes. |
| `pop_02079` | Strife Marches Harpy | [[Regions/Strife Marches\|Strife Marches]] | Adult | D | 48 | 1.6 m | Day & Night | A typical adult Harpy of this region, with golden, grass-toned coloring. |
| `pop_02080` | Strife Marches Harpy Runt | [[Regions/Strife Marches\|Strife Marches]] | Runt | E+ | 32 | 1.12 m | Day & Night | Like a typical Harpy, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_02081` | Velmark Harpy Elderborn | [[Regions/Velmark\|Velmark]] | Elderborn | C | 76 | 2.16 m | Day & Night | Like a typical Harpy, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_02082` | Velmark Harpy Albino | [[Regions/Velmark\|Velmark]] | Albino | D+ | 56 | 1.6 m | Day & Night | Like a typical Harpy, but a rare pale form with white skin or fur and red eyes. |
| `pop_02083` | Strife Marches Harpy Juvenile | [[Regions/Strife Marches\|Strife Marches]] | Juvenile | D- | 40 | 1.36 m | Day & Night | Like a typical Harpy, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_02084` | Hoshizora Harpy Runt | [[Regions/Hoshizora\|Hoshizora]] | Runt | E+ | 32 | 1.12 m | Day & Night | Like a typical Harpy, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |

## Design recipe

Rig `rig_avian` · mesh `avian_base` · material `feather_groom` · VFX `wind_ribbons` · palette `#a8e6cf` `#dcedc1` `#5b8c85` · triangle-based silhouette, sharp asymmetric spikes
