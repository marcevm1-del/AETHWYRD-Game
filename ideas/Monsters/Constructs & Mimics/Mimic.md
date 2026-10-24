---
type: monster
id: mon_mimic
family: "Constructs & Mimics"
rank: "D"
tier: core
tags: [monster, constructs-mimics]
---
# Mimic

![[mon_mimic_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_mimic_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Mimic is a small creature with an object-shaped body that hides its true form, about 1 m tall. Its surface is stretched, stitched and constantly shifting, colored in muted greys and dusty browns. Look for a treasure chest with a tongue and a ring of teeth. It has no eyes at all, only a wide and patient mouth. A distinctive marking runs along its back. It crawls across ceilings. It has no visible aura; you hear its breathing before you see it.

| Field | Value |
|---|---|
| Family · type | [[Families/Constructs & Mimics|Constructs & Mimics]] · Construct |
| Rank · level | D · 48 (40–56) |
| Menace | 5 · Horror |
| Element · weakness | None · Fire |
| Size | 1 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 3053 · 253 · 182 · 127 · 182 · 100 |
| XP · gold | 1477 · 342 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/amorphous\|amorphous]] · `anim_mimic` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Velmark\|Velmark]], [[Regions/Umbravel\|Umbravel]], [[Regions/Strife Marches\|Strife Marches]] |
| Genre | Ancient Ruins |
| Trope | Treasure-chest mimics and ancient guardian golems |

**Field note:** Weak to Fire. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/amorphous|amorphous]] (rigId); animation set `anim_mimic`.
- **Dimensions:** 1 m high × 1.07 m long × 1.05 m wide; prefab scale 0.5.
- **Physics:** 30 kg, gravity ×1.2, poise 28, knockback resistance 0.66, death style `collapse_and_melt`.
- **Navigation:** speed 5.12 m/s, turn 500°/s, stopping distance 0.7 m.
- **Attack count:** 4; **signature:** a treasure chest with a tongue and a ring of teeth.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Chomp\|Chomp]] | melee | 1.6 | 0 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Tongue Lash\|Tongue Lash]] | grab | 1.4 | 6 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Disguise\|Disguise]] | stealth | 0 | 20 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Rune Pulse\|Rune Pulse]] | magic | 1.3 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Mimic is a **horror construct** encountered at D rank, around level 48. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a treasure chest with a tongue and a ring of teeth. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Velmark|Velmark]], [[Regions/Umbravel|Umbravel]], [[Regions/Strife Marches|Strife Marches]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_mimic`, animation set `anim_mimic`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Constructs & Mimics D|loot_construct_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Golem Core\|Golem Core]] | 60% | 1–3 |
| [[Items/Rune Plate\|Rune Plate]] | 30% | 1–1 |
| [[Items/Gear\|Gear]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Constructs & Mimics/Cloud Mimic|Cloud Mimic]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Velmark\|Velmark]] | 3 | D-, D+, D | 40–56 | Night |
| [[Regions/Aldmere\|Aldmere]] | 4 | D+, C-, E+ | 32–65 | Night |
| [[Regions/Umbravel\|Umbravel]] | 2 | E+, C | 32–76 | Night |
| [[Regions/Strife Marches\|Strife Marches]] | 1 | E+ | 32–32 | Night |
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 1 | D | 48–48 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01495` | Velmark Mimic Juvenile | [[Regions/Velmark\|Velmark]] | Juvenile | D- | 40 | 0.85 m | Night | Like a typical Mimic, but young, with brighter colors and unworn features, with soot-stained hide and scavenged scraps. |
| `pop_01496` | Velmark Mimic Albino | [[Regions/Velmark\|Velmark]] | Albino | D+ | 56 | 1 m | Night | Like a typical Mimic, but a rare pale form with white skin or fur and red eyes. |
| `pop_01497` | Velmark Mimic | [[Regions/Velmark\|Velmark]] | Adult | D | 48 | 1 m | Night | A typical adult Mimic of this region, with soot-stained hide and scavenged scraps. |
| `pop_01498` | Aldmere Mimic Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | D+ | 56 | 1.1 m | Night | Like a typical Mimic, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_01499` | Umbravel Mimic Runt | [[Regions/Umbravel\|Umbravel]] | Runt | E+ | 32 | 0.7 m | Night | Like a typical Mimic, but smaller and scrappier than usual, with bioluminescent spots along its body. |
| `pop_01500` | Umbravel Mimic Elderborn | [[Regions/Umbravel\|Umbravel]] | Elderborn | C | 76 | 1.35 m | Night | Like a typical Mimic, but old and wise, with greying features and a cautious hunting style, with bioluminescent spots along its body. |
| `pop_01501` | Strife Marches Mimic Runt | [[Regions/Strife Marches\|Strife Marches]] | Runt | E+ | 32 | 0.7 m | Night | Like a typical Mimic, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_01502` | Aldmere Mimic Albino | [[Regions/Aldmere\|Aldmere]] | Albino | D+ | 56 | 1 m | Night | Like a typical Mimic, but a rare pale form with white skin or fur and red eyes. |
| `pop_01503` | Aldmere Mimic Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | C- | 65 | 1.25 m | Night | Like a typical Mimic, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_01504` | Aldmere Mimic Runt | [[Regions/Aldmere\|Aldmere]] | Runt | E+ | 32 | 0.7 m | Night | Like a typical Mimic, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_01505` | Great Labyrinth (Floors 1-40) Mimic | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Adult | D | 48 | 1 m | Night | A typical adult Mimic of this region, with dust-grey coloring and old rune scars. |

## Design recipe

Rig `rig_mimic` · mesh `mimic_base` · material `stone_metal_runes` · VFX `dust_puffs` · palette `#8a8f98` `#5b5f66` `#c9c2b5` · broken symmetry, mimicry, audio-first reveal
