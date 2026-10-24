---
type: monster
id: mon_long_neck_lady
family: "Yokai-Inspired Spirits"
rank: "D"
tier: core
tags: [monster, yokai-inspired-spirits]
---
# Long-Neck Lady

![[mon_long_neck_lady_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_long_neck_lady_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Long-Neck Lady is a person-sized creature with a tall, impossibly thin frame, about 1.7 m tall. Its form is patchy and subtly wrong, as if assembled from memory, colored in ink black with bruised violet. Guild sketches always show a neck that stretches across rooftops. It has eyes set slightly too far apart. A distinctive marking runs along its back. It glides without moving its legs, surrounded by shadows that lean toward it.

| Field | Value |
|---|---|
| Family · type | [[Families/Yokai-Inspired Spirits|Yokai-Inspired Spirits]] · Spirit |
| Rank · level | D · 48 (40–56) |
| Menace | 4 · Dread |
| Element · weakness | Dark · Light |
| Size | 1.7 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 3648 · 253 · 182 · 182 · 182 · 100 |
| XP · gold | 1477 · 342 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/amorphous\|amorphous]] · `anim_aberrant` |
| Habitats | [[Regions/Hoshizora\|Hoshizora]], [[Regions/Kitsune Isles\|Kitsune Isles]] |
| Genre | Japanese Folklore |
| Trope | Gentle and terrifying spirits (Natsume's Book of Friends, Mushishi, Inuyasha) |

**Field note:** Weak to Light. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/amorphous|amorphous]] (rigId); animation set `anim_aberrant`.
- **Dimensions:** 1.7 m high × 1.82 m long × 1.79 m wide; prefab scale 0.85.
- **Physics:** 147.4 kg, gravity ×1.2, poise 62, knockback resistance 0.66, death style `collapse_and_melt`.
- **Navigation:** speed 6.67 m/s, turn 383°/s, stopping distance 0.91 m.
- **Attack count:** 5; **signature:** a neck that stretches across rooftops.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Grasp\|Grasp]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Unfold\|Unfold]] | aoe | 1.8 | 12 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Mimic Voice\|Mimic Voice]] | debuff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Spirit Flame\|Spirit Flame]] | magic | 1.2 | 8 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Long-Neck Lady is a **dread spirit** encountered at D rank, around level 48. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a neck that stretches across rooftops. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Hoshizora|Hoshizora]], [[Regions/Kitsune Isles|Kitsune Isles]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_aberrant`, animation set `anim_aberrant`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Yokai-Inspired Spirits D|loot_yokai_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Spirit Paper\|Spirit Paper]] | 60% | 1–3 |
| [[Items/Fox Fire\|Fox Fire]] | 30% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Yokai-Inspired Spirits/Vesper-Touched Long-Neck Lady|Vesper-Touched Long-Neck Lady]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Hoshizora\|Hoshizora]] | 6 | D+, C-, C, E+, D- | 32–76 | Night |
| [[Regions/Kitsune Isles\|Kitsune Isles]] | 5 | D+, D-, E+, C-, D | 32–65 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02483` | Hoshizora Long-Neck Lady Albino | [[Regions/Hoshizora\|Hoshizora]] | Albino | D+ | 56 | 1.7 m | Night | Like a typical Long-Neck Lady, but a rare pale form with white skin or fur and red eyes. |
| `pop_02484` | Kitsune Isles Long-Neck Lady Albino | [[Regions/Kitsune Isles\|Kitsune Isles]] | Albino | D+ | 56 | 1.7 m | Night | Like a typical Long-Neck Lady, but a rare pale form with white skin or fur and red eyes. |
| `pop_02485` | Hoshizora Long-Neck Lady Alpha | [[Regions/Hoshizora\|Hoshizora]] | Alpha | C- | 65 | 2.13 m | Night | Like a typical Long-Neck Lady, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_02486` | Kitsune Isles Long-Neck Lady Juvenile | [[Regions/Kitsune Isles\|Kitsune Isles]] | Juvenile | D- | 40 | 1.44 m | Night | Like a typical Long-Neck Lady, but young, with brighter colors and unworn features, with salt-crusted, barnacle-flecked hide. |
| `pop_02487` | Hoshizora Long-Neck Lady Scarred | [[Regions/Hoshizora\|Hoshizora]] | Scarred | D+ | 56 | 1.87 m | Night | Like a typical Long-Neck Lady, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_02488` | Hoshizora Long-Neck Lady Elderborn | [[Regions/Hoshizora\|Hoshizora]] | Elderborn | C | 76 | 2.29 m | Night | Like a typical Long-Neck Lady, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_02489` | Kitsune Isles Long-Neck Lady Runt | [[Regions/Kitsune Isles\|Kitsune Isles]] | Runt | E+ | 32 | 1.19 m | Night | Like a typical Long-Neck Lady, but smaller and scrappier than usual, with salt-crusted, barnacle-flecked hide. |
| `pop_02490` | Hoshizora Long-Neck Lady Runt | [[Regions/Hoshizora\|Hoshizora]] | Runt | E+ | 32 | 1.19 m | Night | Like a typical Long-Neck Lady, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_02491` | Kitsune Isles Long-Neck Lady Alpha | [[Regions/Kitsune Isles\|Kitsune Isles]] | Alpha | C- | 65 | 2.13 m | Night | Like a typical Long-Neck Lady, but larger and scarred, and others of its kind follow it, with salt-crusted, barnacle-flecked hide. |
| `pop_02492` | Hoshizora Long-Neck Lady Juvenile | [[Regions/Hoshizora\|Hoshizora]] | Juvenile | D- | 40 | 1.44 m | Night | Like a typical Long-Neck Lady, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_02493` | Kitsune Isles Long-Neck Lady | [[Regions/Kitsune Isles\|Kitsune Isles]] | Adult | D | 48 | 1.7 m | Night | A typical adult Long-Neck Lady of this region, with salt-crusted, barnacle-flecked hide. |

## Design recipe

Rig `rig_aberrant` · mesh `aberrant_base` · material `paper_ink_spirit` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · elongated, irregular silhouette; still-then-sudden timing
