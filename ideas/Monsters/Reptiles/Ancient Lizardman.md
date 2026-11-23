---
type: monster
id: mon_ancient_lizardman
family: "Reptiles"
rank: "C"
tier: variant
tags: [monster, reptiles]
---
# Ancient Lizardman

![[mon_ancient_lizardman_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_ancient_lizardman_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 19,998 tris · 1.803 × 2.576 × 3 m · local file `Game/Assets/_Game/Art/Models/Monsters/Reptiles/mon_ancient_lizardman.fbx`

> The Ancient Lizardman is a large creature with a broad-shouldered humanoid build, about 3 m tall. Its scales are weathered and natural, colored in sand-coloured, with sea-blue markings. Guild sketches always show a proud crest and a coral-tipped spear. It has amber predator eyes. Battle-worn plates and trophies hang from its body. It stalks low to the ground, surrounded by fine mist and droplets that orbit it. Moss, crystals and centuries-old scars cover its body; it has outlived every hunter sent after it.

| Field | Value |
|---|---|
| Family · type | [[Families/Reptiles|Reptiles]] · Reptile |
| Variant of | [[Monsters/Reptiles/Lizardman\|Lizardman]] (ancient) |
| Rank · level | C · 76 (65–86) |
| Menace | 2 · Wild |
| Element · weakness | Water · Lightning |
| Size | 3 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 9607 · 377 · 314 · 251 · 283 · 100 |
| XP · gold | 3073 · 648 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Lumbaya\|Lumbaya]], [[Regions/Xochitl Mire\|Xochitl Mire]], [[Regions/Greymoor\|Greymoor]] |
| Genre | Classic Fantasy |
| Trope | Lizardmen as a proud people; the petrifying basilisk |

**Field note:** Weak to Lightning. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 3 m high × 0.9 m long × 0.96 m wide; prefab scale 1.667.
- **Physics:** 368.6 kg, gravity ×1.5, poise 94, knockback resistance 0.39, death style `ragdoll`.
- **Navigation:** speed 6.67 m/s, turn 231°/s, stopping distance 0.91 m.
- **Attack count:** 5; **signature:** a proud crest and a coral-tipped spear.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Tail Lash\|Tail Lash]] | aoe | 1.2 | 7 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Tide Lash\|Tide Lash]] | magic | 1.5 | 10 s | Water | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Ancient Lizardman is a **wild reptile** encountered at C rank, around level 76. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Lightning**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a proud crest and a coral-tipped spear. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Lumbaya|Lumbaya]], [[Regions/Xochitl Mire|Xochitl Mire]], [[Regions/Greymoor|Greymoor]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Reptiles C|loot_reptile_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Scale\|Scale]] | 60% | 1–3 |
| [[Items/Reptile Eye\|Reptile Eye]] | 30% | 1–1 |
| [[Items/Tail Meat\|Tail Meat]] | 15% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Lumbaya\|Lumbaya]] | 6 | C+, B, D+, C-, C | 56–108 | Day & Night |
| [[Regions/Greymoor\|Greymoor]] | 2 | B-, C | 76–96 | Day & Night |
| [[Regions/Xochitl Mire\|Xochitl Mire]] | 3 | C-, C, B- | 65–96 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04153` | Lumbaya Ancient Lizardman Scarred | [[Regions/Lumbaya\|Lumbaya]] | Scarred | C+ | 86 | 3.3 m | Day & Night | Like a typical Ancient Lizardman, but covered in old battle scars, with vivid tropical markings. |
| `pop_04154` | Greymoor Ancient Lizardman Alpha | [[Regions/Greymoor\|Greymoor]] | Alpha | B- | 96 | 3.75 m | Day & Night | Like a typical Ancient Lizardman, but larger and scarred, and others of its kind follow it, with mud-slick, algae-streaked skin. |
| `pop_04155` | Xochitl Mire Ancient Lizardman Juvenile | [[Regions/Xochitl Mire\|Xochitl Mire]] | Juvenile | C- | 65 | 2.55 m | Day & Night | Like a typical Ancient Lizardman, but young, with brighter colors and unworn features, with mud-slick, algae-streaked skin. |
| `pop_04156` | Xochitl Mire Ancient Lizardman | [[Regions/Xochitl Mire\|Xochitl Mire]] | Adult | C | 76 | 3 m | Day & Night | A typical adult Ancient Lizardman of this region, with mud-slick, algae-streaked skin. |
| `pop_04157` | Lumbaya Ancient Lizardman Elderborn | [[Regions/Lumbaya\|Lumbaya]] | Elderborn | B | 108 | 4.05 m | Day & Night | Like a typical Ancient Lizardman, but old and wise, with greying features and a cautious hunting style, with vivid tropical markings. |
| `pop_04158` | Lumbaya Ancient Lizardman Runt | [[Regions/Lumbaya\|Lumbaya]] | Runt | D+ | 56 | 2.1 m | Day & Night | Like a typical Ancient Lizardman, but smaller and scrappier than usual, with vivid tropical markings. |
| `pop_04159` | Greymoor Ancient Lizardman | [[Regions/Greymoor\|Greymoor]] | Adult | C | 76 | 3 m | Day & Night | A typical adult Ancient Lizardman of this region, with mud-slick, algae-streaked skin. |
| `pop_04160` | Lumbaya Ancient Lizardman Albino | [[Regions/Lumbaya\|Lumbaya]] | Albino | C+ | 86 | 3 m | Day & Night | Like a typical Ancient Lizardman, but a rare pale form with white skin or fur and red eyes. |
| `pop_04161` | Lumbaya Ancient Lizardman Juvenile | [[Regions/Lumbaya\|Lumbaya]] | Juvenile | C- | 65 | 2.55 m | Day & Night | Like a typical Ancient Lizardman, but young, with brighter colors and unworn features, with vivid tropical markings. |
| `pop_04162` | Xochitl Mire Ancient Lizardman Alpha | [[Regions/Xochitl Mire\|Xochitl Mire]] | Alpha | B- | 96 | 3.75 m | Day & Night | Like a typical Ancient Lizardman, but larger and scarred, and others of its kind follow it, with mud-slick, algae-streaked skin. |
| `pop_04163` | Lumbaya Ancient Lizardman | [[Regions/Lumbaya\|Lumbaya]] | Adult | C | 76 | 3 m | Day & Night | A typical adult Ancient Lizardman of this region, with vivid tropical markings. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `scale_matte` · VFX `mist_droplets` · palette `#a99b54` `#706537` `#4fa8e8` · real-animal silhouette with one fantasy exaggeration
