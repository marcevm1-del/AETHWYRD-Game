---
type: monster
id: mon_vesper_touched_long_neck_lady
family: "Yokai-Inspired Spirits"
rank: "C-"
tier: variant
tags: [monster, yokai-inspired-spirits]
---
# Vesper-Touched Long-Neck Lady

![[mon_vesper_touched_long_neck_lady_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_vesper_touched_long_neck_lady_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Vesper-Touched Long-Neck Lady is a person-sized creature with a tall, impossibly thin frame, about 1.7 m tall. Its form is stretched, stitched and constantly shifting, colored in ink black with bruised violet. Guild sketches always show a neck that stretches across rooftops. It has a human-like face in the wrong place. Battle-worn plates and trophies hang from its body. It crawls across ceilings, surrounded by shadows that lean toward it. Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.

| Field | Value |
|---|---|
| Family · type | [[Families/Yokai-Inspired Spirits|Yokai-Inspired Spirits]] · Spirit |
| Variant of | [[Monsters/Yokai-Inspired Spirits/Long-Neck Lady\|Long-Neck Lady]] (corrupted) |
| Rank · level | C- · 65 (56–76) |
| Menace | 5 · Horror |
| Element · weakness | Dark · Light |
| Size | 1.7 m |
| Behaviour | Territorial (territorial_guard+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 5707 · 338 · 243 · 243 · 243 · 100 |
| XP · gold | 2395 · 521 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/amorphous\|amorphous]] · `anim_aberrant` |
| Habitats | [[Regions/Haneul\|Haneul]], [[Regions/Hoshizora\|Hoshizora]] |
| Genre | Japanese Folklore |
| Trope | Gentle and terrifying spirits (Natsume's Book of Friends, Mushishi, Inuyasha) |

**Field note:** Weak to Light. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/amorphous|amorphous]] (rigId); animation set `anim_aberrant`.
- **Dimensions:** 1.7 m high × 1.82 m long × 1.79 m wide; prefab scale 0.85.
- **Physics:** 147.4 kg, gravity ×1.2, poise 70, knockback resistance 0.69, death style `collapse_and_melt`.
- **Navigation:** speed 6.37 m/s, turn 383°/s, stopping distance 0.91 m.
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

Vesper-Touched Long-Neck Lady is a **horror spirit** encountered at C- rank, around level 65. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a neck that stretches across rooftops. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Haneul|Haneul]], [[Regions/Hoshizora|Hoshizora]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_aberrant`, animation set `anim_aberrant`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Yokai-Inspired Spirits C|loot_yokai_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Spirit Paper\|Spirit Paper]] | 60% | 1–3 |
| [[Items/Fox Fire\|Fox Fire]] | 30% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Hoshizora\|Hoshizora]] | 6 | B-, D, C+, C-, C | 48–96 | Night |
| [[Regions/Haneul\|Haneul]] | 5 | C-, C, D, C+ | 48–86 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05334` | Hoshizora Vesper-Touched Long-Neck Lady Elderborn | [[Regions/Hoshizora\|Hoshizora]] | Elderborn | B- | 96 | 2.29 m | Night | Like a typical Vesper-Touched Long-Neck Lady, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_05335` | Hoshizora Vesper-Touched Long-Neck Lady Runt | [[Regions/Hoshizora\|Hoshizora]] | Runt | D | 48 | 1.19 m | Night | Like a typical Vesper-Touched Long-Neck Lady, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_05336` | Haneul Vesper-Touched Long-Neck Lady | [[Regions/Haneul\|Haneul]] | Adult | C- | 65 | 1.7 m | Night | A typical adult Vesper-Touched Long-Neck Lady of this region, with slate-grey coloring and hardened hide. |
| `pop_05337` | Hoshizora Vesper-Touched Long-Neck Lady Alpha | [[Regions/Hoshizora\|Hoshizora]] | Alpha | C+ | 86 | 2.13 m | Night | Like a typical Vesper-Touched Long-Neck Lady, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_05338` | Haneul Vesper-Touched Long-Neck Lady Scarred | [[Regions/Haneul\|Haneul]] | Scarred | C | 76 | 1.87 m | Night | Like a typical Vesper-Touched Long-Neck Lady, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_05339` | Haneul Vesper-Touched Long-Neck Lady Albino | [[Regions/Haneul\|Haneul]] | Albino | C | 76 | 1.7 m | Night | Like a typical Vesper-Touched Long-Neck Lady, but a rare pale form with white skin or fur and red eyes. |
| `pop_05340` | Haneul Vesper-Touched Long-Neck Lady Runt | [[Regions/Haneul\|Haneul]] | Runt | D | 48 | 1.19 m | Night | Like a typical Vesper-Touched Long-Neck Lady, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_05341` | Hoshizora Vesper-Touched Long-Neck Lady | [[Regions/Hoshizora\|Hoshizora]] | Adult | C- | 65 | 1.7 m | Night | A typical adult Vesper-Touched Long-Neck Lady of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_05342` | Haneul Vesper-Touched Long-Neck Lady Alpha | [[Regions/Haneul\|Haneul]] | Alpha | C+ | 86 | 2.13 m | Night | Like a typical Vesper-Touched Long-Neck Lady, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_05343` | Hoshizora Vesper-Touched Long-Neck Lady Scarred | [[Regions/Hoshizora\|Hoshizora]] | Scarred | C | 76 | 1.87 m | Night | Like a typical Vesper-Touched Long-Neck Lady, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_05344` | Hoshizora Vesper-Touched Long-Neck Lady Albino | [[Regions/Hoshizora\|Hoshizora]] | Albino | C | 76 | 1.7 m | Night | Like a typical Vesper-Touched Long-Neck Lady, but a rare pale form with white skin or fur and red eyes. |

## Design recipe

Rig `rig_aberrant` · mesh `aberrant_base` · material `paper_ink_spirit` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · broken symmetry, mimicry, audio-first reveal
