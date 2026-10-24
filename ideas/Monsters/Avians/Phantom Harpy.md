---
type: monster
id: mon_phantom_harpy
family: "Avians"
rank: "D+"
tier: variant
tags: [monster, avians]
---
# Phantom Harpy

![[mon_phantom_harpy_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_phantom_harpy_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,878 tris · 1.075 × 1.424 × 1.6 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Phantom Harpy is a person-sized creature with a feathered avian body, about 1.6 m tall. Its plumage is patchy and subtly wrong, as if assembled from memory, colored in warm gold and pearl white. Its most striking feature is a bird body with a shrieking human-like face. It has eyes set slightly too far apart. A distinctive marking runs along its back. It moves in jerky stop-motion bursts, surrounded by soft radiance and floating motes of light. Its body is translucent blue, half in the spirit world; weapons pass through it unless they are blessed or enchanted.

| Field | Value |
|---|---|
| Family · type | [[Families/Avians|Avians]] · Avian |
| Variant of | [[Monsters/Avians/Harpy\|Harpy]] (spirit) |
| Rank · level | D+ · 56 (48–65) |
| Menace | 4 · Dread |
| Element · weakness | Light · Dark |
| Size | 1.6 m |
| Behaviour | Aggressive (aggressive_chase+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 3812 · 234 · 187 · 164 · 187 · 135 |
| XP · gold | 1888 · 423 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/avian\|avian]] · `anim_avian` |
| Habitats | [[Regions/Hoshizora\|Hoshizora]], [[Regions/Kitsune Isles\|Kitsune Isles]] |
| Genre | High Fantasy |
| Trope | Griffons, harpies and phoenixes of classic fantasy |

**Field note:** Weak to Dark. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/avian|avian]] (rigId); animation set `anim_avian`.
- **Dimensions:** 0.74 m high × 1.6 m long × 2.75 m wide; prefab scale 2.667.
- **Physics:** 54.5 kg, gravity ×0.9, poise 79, knockback resistance 0.11, death style `tumble_feathers_burst`.
- **Navigation:** speed 3.77 m/s, turn 474°/s, stopping distance 0.72 m.
- **Attack count:** 5; **signature:** a bird body with a shrieking human-like face.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Peck\|Peck]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Swoop\|Swoop]] | dash | 1.4 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Screech\|Screech]] | debuff | 0 | 14 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Feather Volley\|Feather Volley]] | ranged | 1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Radiant Pulse\|Radiant Pulse]] | magic | 1.5 | 10 s | Light | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Phantom Harpy is a **dread avian** encountered at D+ rank, around level 56. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Dark**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a bird body with a shrieking human-like face. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Hoshizora|Hoshizora]], [[Regions/Kitsune Isles|Kitsune Isles]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_avian`, animation set `anim_avian`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Avians D|loot_avian_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Feather\|Feather]] | 60% | 1–3 |
| [[Items/Talon\|Talon]] | 30% | 1–1 |
| [[Items/Egg\|Egg]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Hoshizora\|Hoshizora]] | 5 | C+, C-, D+, D, C | 48–86 | Night |
| [[Regions/Kitsune Isles\|Kitsune Isles]] | 6 | C-, D+, C, D, D- | 40–76 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04935` | Hoshizora Phantom Harpy Elderborn | [[Regions/Hoshizora\|Hoshizora]] | Elderborn | C+ | 86 | 2.16 m | Night | Like a typical Phantom Harpy, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_04936` | Kitsune Isles Phantom Harpy Scarred | [[Regions/Kitsune Isles\|Kitsune Isles]] | Scarred | C- | 65 | 1.76 m | Night | Like a typical Phantom Harpy, but covered in old battle scars, with salt-crusted, barnacle-flecked hide. |
| `pop_04937` | Kitsune Isles Phantom Harpy | [[Regions/Kitsune Isles\|Kitsune Isles]] | Adult | D+ | 56 | 1.6 m | Night | A typical adult Phantom Harpy of this region, with salt-crusted, barnacle-flecked hide. |
| `pop_04938` | Kitsune Isles Phantom Harpy Albino | [[Regions/Kitsune Isles\|Kitsune Isles]] | Albino | C- | 65 | 1.6 m | Night | Like a typical Phantom Harpy, but a rare pale form with white skin or fur and red eyes. |
| `pop_04939` | Kitsune Isles Phantom Harpy Alpha | [[Regions/Kitsune Isles\|Kitsune Isles]] | Alpha | C | 76 | 2 m | Night | Like a typical Phantom Harpy, but larger and scarred, and others of its kind follow it, with salt-crusted, barnacle-flecked hide. |
| `pop_04940` | Kitsune Isles Phantom Harpy Juvenile | [[Regions/Kitsune Isles\|Kitsune Isles]] | Juvenile | D | 48 | 1.36 m | Night | Like a typical Phantom Harpy, but young, with brighter colors and unworn features, with salt-crusted, barnacle-flecked hide. |
| `pop_04941` | Kitsune Isles Phantom Harpy Runt | [[Regions/Kitsune Isles\|Kitsune Isles]] | Runt | D- | 40 | 1.12 m | Night | Like a typical Phantom Harpy, but smaller and scrappier than usual, with salt-crusted, barnacle-flecked hide. |
| `pop_04942` | Hoshizora Phantom Harpy Scarred | [[Regions/Hoshizora\|Hoshizora]] | Scarred | C- | 65 | 1.76 m | Night | Like a typical Phantom Harpy, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_04943` | Hoshizora Phantom Harpy | [[Regions/Hoshizora\|Hoshizora]] | Adult | D+ | 56 | 1.6 m | Night | A typical adult Phantom Harpy of this region, with slate-grey coloring and hardened hide. |
| `pop_04944` | Hoshizora Phantom Harpy Juvenile | [[Regions/Hoshizora\|Hoshizora]] | Juvenile | D | 48 | 1.36 m | Night | Like a typical Phantom Harpy, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_04945` | Hoshizora Phantom Harpy Alpha | [[Regions/Hoshizora\|Hoshizora]] | Alpha | C | 76 | 2 m | Night | Like a typical Phantom Harpy, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |

## Design recipe

Rig `rig_avian` · mesh `avian_base` · material `feather_groom` · VFX `holy_motes` · palette `#fff3b0` `#ffd166` `#ffffff` · elongated, irregular silhouette; still-then-sudden timing
