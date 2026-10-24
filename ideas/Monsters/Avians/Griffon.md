---
type: monster
id: mon_griffon
family: "Avians"
rank: "C"
tier: core
tags: [monster, avians]
---
# Griffon

> The Griffon is a large creature with a long-legged predatory quadruped build, about 3 m long. Its plumage is weathered and natural, colored in pale jade and cloud white. Its most striking feature is an eagle's front and a lion's back. It has alert animal eyes. Battle-worn plates and trophies hang from its body. It prowls, surrounded by swirling leaves and a constant breeze.

| Field | Value |
|---|---|
| Family · type | [[Families/Avians|Avians]] · Avian |
| Rank · level | C · 76 (65–86) |
| Menace | 2 · Wild |
| Element · weakness | Wind · Fire |
| Size | 3 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 9607 · 377 · 314 · 251 · 283 · 100 |
| XP · gold | 3073 · 648 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/quad_large\|quad_large]] · `anim_quad_large` |
| Habitats | [[Regions/Hoshizora\|Hoshizora]], [[Regions/Vharlen\|Vharlen]], [[Regions/Stormreach\|Stormreach]] |
| Genre | High Fantasy |
| Trope | Griffons, harpies and phoenixes of classic fantasy |

**Field note:** Weak to Fire. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_large|quad_large]] (rigId); animation set `anim_quad_large`.
- **Dimensions:** 1.95 m high × 3 m long × 0.48 m wide; prefab scale 0.75.
- **Physics:** 486 kg, gravity ×0.96, poise 88, knockback resistance 0.94, death style `heavy_fall_dust`.
- **Navigation:** speed 6.88 m/s, turn 185°/s, stopping distance 1 m.
- **Attack count:** 5; **signature:** an eagle's front and a lion's back.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Maul\|Maul]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Pounce\|Pounce]] | dash | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Howl\|Howl]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Feather Volley\|Feather Volley]] | ranged | 1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Gale Cutter\|Gale Cutter]] | magic | 1.5 | 10 s | Wind | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Griffon is a **wild avian** encountered at C rank, around level 76. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** an eagle's front and a lion's back. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Hoshizora|Hoshizora]], [[Regions/Vharlen|Vharlen]], [[Regions/Stormreach|Stormreach]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_large`, animation set `anim_quad_large`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Avians C|loot_avian_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Feather\|Feather]] | 60% | 1–3 |
| [[Items/Talon\|Talon]] | 30% | 1–1 |
| [[Items/Egg\|Egg]] | 15% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Avians/Vesper-Touched Griffon|Vesper-Touched Griffon]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Hoshizora\|Hoshizora]] | 4 | C+, B-, C, D+ | 56–96 | Day & Night |
| [[Regions/Stormreach\|Stormreach]] | 5 | C-, C+, B-, D+ | 56–96 | Day & Night |
| [[Regions/Vharlen\|Vharlen]] | 2 | C+, C | 76–86 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02085` | Hoshizora Griffon Scarred | [[Regions/Hoshizora\|Hoshizora]] | Scarred | C+ | 86 | 3.3 m | Day & Night | Like a typical Griffon, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_02086` | Stormreach Griffon Juvenile | [[Regions/Stormreach\|Stormreach]] | Juvenile | C- | 65 | 2.55 m | Day & Night | Like a typical Griffon, but young, with brighter colors and unworn features, with salt-crusted, barnacle-flecked hide. |
| `pop_02087` | Stormreach Griffon Albino | [[Regions/Stormreach\|Stormreach]] | Albino | C+ | 86 | 3 m | Day & Night | Like a typical Griffon, but a rare pale form with white skin or fur and red eyes. |
| `pop_02088` | Stormreach Griffon Alpha | [[Regions/Stormreach\|Stormreach]] | Alpha | B- | 96 | 3.75 m | Day & Night | Like a typical Griffon, but larger and scarred, and others of its kind follow it, with salt-crusted, barnacle-flecked hide. |
| `pop_02089` | Hoshizora Griffon Alpha | [[Regions/Hoshizora\|Hoshizora]] | Alpha | B- | 96 | 3.75 m | Day & Night | Like a typical Griffon, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_02090` | Stormreach Griffon Runt | [[Regions/Stormreach\|Stormreach]] | Runt | D+ | 56 | 2.1 m | Day & Night | Like a typical Griffon, but smaller and scrappier than usual, with salt-crusted, barnacle-flecked hide. |
| `pop_02091` | Vharlen Griffon Albino | [[Regions/Vharlen\|Vharlen]] | Albino | C+ | 86 | 3 m | Day & Night | Like a typical Griffon, but a rare pale form with white skin or fur and red eyes. |
| `pop_02092` | Vharlen Griffon | [[Regions/Vharlen\|Vharlen]] | Adult | C | 76 | 3 m | Day & Night | A typical adult Griffon of this region, with golden, grass-toned coloring. |
| `pop_02093` | Stormreach Griffon Scarred | [[Regions/Stormreach\|Stormreach]] | Scarred | C+ | 86 | 3.3 m | Day & Night | Like a typical Griffon, but covered in old battle scars, with salt-crusted, barnacle-flecked hide. |
| `pop_02094` | Hoshizora Griffon | [[Regions/Hoshizora\|Hoshizora]] | Adult | C | 76 | 3 m | Day & Night | A typical adult Griffon of this region, with slate-grey coloring and hardened hide. |
| `pop_02095` | Hoshizora Griffon Runt | [[Regions/Hoshizora\|Hoshizora]] | Runt | D+ | 56 | 2.1 m | Day & Night | Like a typical Griffon, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `feather_groom` · VFX `wind_ribbons` · palette `#a8e6cf` `#dcedc1` `#5b8c85` · real-animal silhouette with one fantasy exaggeration
