---
type: monster
id: mon_hippogriff
family: "Avians"
rank: "C"
tier: core
tags: [monster, avians]
---
# Hippogriff

![[mon_hippogriff_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_hippogriff_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Hippogriff is a large creature with a powerful four-legged hunter's body, about 2.8 m long. Its plumage is weathered and natural, colored in pale jade and cloud white. Survivors describe an eagle's head on a horse's body. It has amber predator eyes. Battle-worn plates and trophies hang from its body. It lopes in long strides, surrounded by swirling leaves and a constant breeze.

| Field | Value |
|---|---|
| Family · type | [[Families/Avians|Avians]] · Avian |
| Rank · level | C · 76 (65–86) |
| Menace | 2 · Wild |
| Element · weakness | Wind · Fire |
| Size | 2.8 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 9386 · 377 · 314 · 251 · 283 · 100 |
| XP · gold | 3073 · 648 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/quad_large\|quad_large]] · `anim_quad_large` |
| Habitats | [[Regions/Hoshizora\|Hoshizora]], [[Regions/Stormreach\|Stormreach]], [[Regions/Vharlen\|Vharlen]], [[Regions/Aldmere\|Aldmere]], [[Regions/Zarvan\|Zarvan]] |
| Genre | High Fantasy |
| Trope | Griffons, harpies and phoenixes of classic fantasy |

**Field note:** Weak to Fire. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_large|quad_large]] (rigId); animation set `anim_quad_large`.
- **Dimensions:** 1.82 m high × 2.8 m long × 0.45 m wide; prefab scale 0.7.
- **Physics:** 395.1 kg, gravity ×0.96, poise 85, knockback resistance 0.94, death style `heavy_fall_dust`.
- **Navigation:** speed 7.31 m/s, turn 191°/s, stopping distance 0.96 m.
- **Attack count:** 5; **signature:** an eagle's head on a horse's body.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Maul\|Maul]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Pounce\|Pounce]] | dash | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Howl\|Howl]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Feather Volley\|Feather Volley]] | ranged | 1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Gale Cutter\|Gale Cutter]] | magic | 1.5 | 10 s | Wind | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Hippogriff is a **wild avian** encountered at C rank, around level 76. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** an eagle's head on a horse's body. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Hoshizora|Hoshizora]], [[Regions/Stormreach|Stormreach]], [[Regions/Vharlen|Vharlen]], [[Regions/Aldmere|Aldmere]], [[Regions/Zarvan|Zarvan]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_large`, animation set `anim_quad_large`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Avians C|loot_avian_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Feather\|Feather]] | 60% | 1–3 |
| [[Items/Talon\|Talon]] | 30% | 1–1 |
| [[Items/Egg\|Egg]] | 15% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Avians/Ancient Hippogriff|Ancient Hippogriff]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Zarvan\|Zarvan]] | 3 | C+, C- | 65–86 | Day & Night |
| [[Regions/Aldmere\|Aldmere]] | 4 | B, D+, C+ | 56–108 | Day & Night |
| [[Regions/Vharlen\|Vharlen]] | 2 | C+, D+ | 56–86 | Day & Night |
| [[Regions/Hoshizora\|Hoshizora]] | 1 | C- | 65–65 | Day & Night |
| [[Regions/Stormreach\|Stormreach]] | 1 | B- | 96–96 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02096` | Zarvan Hippogriff Albino | [[Regions/Zarvan\|Zarvan]] | Albino | C+ | 86 | 2.8 m | Day & Night | Like a typical Hippogriff, but a rare pale form with white skin or fur and red eyes. |
| `pop_02097` | Zarvan Hippogriff Scarred | [[Regions/Zarvan\|Zarvan]] | Scarred | C+ | 86 | 3.08 m | Day & Night | Like a typical Hippogriff, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_02098` | Aldmere Hippogriff Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | B | 108 | 3.78 m | Day & Night | Like a typical Hippogriff, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_02099` | Vharlen Hippogriff Scarred | [[Regions/Vharlen\|Vharlen]] | Scarred | C+ | 86 | 3.08 m | Day & Night | Like a typical Hippogriff, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_02100` | Aldmere Hippogriff Runt | [[Regions/Aldmere\|Aldmere]] | Runt | D+ | 56 | 1.96 m | Day & Night | Like a typical Hippogriff, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_02101` | Vharlen Hippogriff Runt | [[Regions/Vharlen\|Vharlen]] | Runt | D+ | 56 | 1.96 m | Day & Night | Like a typical Hippogriff, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_02102` | Hoshizora Hippogriff Juvenile | [[Regions/Hoshizora\|Hoshizora]] | Juvenile | C- | 65 | 2.38 m | Day & Night | Like a typical Hippogriff, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_02103` | Aldmere Hippogriff Albino | [[Regions/Aldmere\|Aldmere]] | Albino | C+ | 86 | 2.8 m | Day & Night | Like a typical Hippogriff, but a rare pale form with white skin or fur and red eyes. |
| `pop_02104` | Aldmere Hippogriff Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | C+ | 86 | 3.08 m | Day & Night | Like a typical Hippogriff, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_02105` | Zarvan Hippogriff Juvenile | [[Regions/Zarvan\|Zarvan]] | Juvenile | C- | 65 | 2.38 m | Day & Night | Like a typical Hippogriff, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_02106` | Stormreach Hippogriff Alpha | [[Regions/Stormreach\|Stormreach]] | Alpha | B- | 96 | 3.5 m | Day & Night | Like a typical Hippogriff, but larger and scarred, and others of its kind follow it, with salt-crusted, barnacle-flecked hide. |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `feather_groom` · VFX `wind_ribbons` · palette `#a8e6cf` `#dcedc1` `#5b8c85` · real-animal silhouette with one fantasy exaggeration
