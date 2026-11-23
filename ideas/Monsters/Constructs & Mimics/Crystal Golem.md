---
type: monster
id: mon_crystal_golem
family: "Constructs & Mimics"
rank: "B+"
tier: core
tags: [monster, constructs-mimics]
---
# Crystal Golem

![[mon_crystal_golem_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_crystal_golem_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 20,000 tris · 3.431 × 1.378 × 3.5 m · local file `Game/Assets/_Game/Art/Models/Monsters/Constructs & Mimics/mon_crystal_golem.fbx`

> The Crystal Golem is a large creature with a blocky construct body, about 3.5 m tall. Its surface is weathered and natural, colored in weathered stone, with gold markings. Its most striking feature is a body of prisms that splits light into rainbows. It has alert animal eyes. Faint runes glow along its body when it fights. It stalks low to the ground, surrounded by soft radiance and floating motes of light.

| Field | Value |
|---|---|
| Family · type | [[Families/Constructs & Mimics|Constructs & Mimics]] · Construct |
| Rank · level | B+ · 120 (108–132) |
| Menace | 2 · Wild |
| Element · weakness | Light · Dark |
| Size | 3.5 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 25411 · 490 · 735 · 294 · 490 · 70 |
| XP · gold | 6373 · 1225 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/golem\|golem]] · `anim_golem` |
| Habitats | [[Regions/Heavenreach\|Heavenreach]], [[Regions/Sunscar\|Sunscar]], [[Regions/Zarvan\|Zarvan]], [[Regions/Aurumdeep\|Aurumdeep]] |
| Genre | Ancient Ruins |
| Trope | Treasure-chest mimics and ancient guardian golems |

**Field note:** Weak to Dark. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/golem|golem]] (rigId); animation set `anim_golem`.
- **Dimensions:** 3.5 m high × 1.05 m long × 1.47 m wide; prefab scale 1.167.
- **Physics:** 1955.1 kg, gravity ×1.08, poise 346, knockback resistance 1, death style `crumble_into_rubble`.
- **Navigation:** speed 3.4 m/s, turn 107°/s, stopping distance 1.17 m.
- **Attack count:** 5; **signature:** a body of prisms that splits light into rainbows.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slam\|Slam]] | melee | 1.4 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Ground Pound\|Ground Pound]] | aoe | 1.8 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Stance\|Guard Stance]] | buff | 0 | 15 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Rune Pulse\|Rune Pulse]] | magic | 1.3 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Radiant Pulse\|Radiant Pulse]] | magic | 1.5 | 10 s | Light | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Crystal Golem is a **wild construct** encountered at B+ rank, around level 120. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Dark**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a body of prisms that splits light into rainbows. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Heavenreach|Heavenreach]], [[Regions/Sunscar|Sunscar]], [[Regions/Zarvan|Zarvan]], [[Regions/Aurumdeep|Aurumdeep]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_golem`, animation set `anim_golem`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Constructs & Mimics B|loot_construct_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Golem Core\|Golem Core]] | 60% | 1–3 |
| [[Items/Rune Plate\|Rune Plate]] | 30% | 1–1 |
| [[Items/Gear\|Gear]] | 15% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Constructs & Mimics/Vesper-Touched Crystal Golem|Vesper-Touched Crystal Golem]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Heavenreach\|Heavenreach]] | 3 | B+, A+, B- | 96–159 | Day & Night |
| [[Regions/Aurumdeep\|Aurumdeep]] | 2 | A, A- | 132–146 | Day & Night |
| [[Regions/Zarvan\|Zarvan]] | 5 | A-, A+, A, B, B+ | 108–159 | Day & Night |
| [[Regions/Sunscar\|Sunscar]] | 1 | B- | 96–96 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01528` | Heavenreach Crystal Golem | [[Regions/Heavenreach\|Heavenreach]] | Adult | B+ | 120 | 3.5 m | Day & Night | A typical adult Crystal Golem of this region, with cloud-pale coloring and lighter bones. |
| `pop_01529` | Aurumdeep Crystal Golem Alpha | [[Regions/Aurumdeep\|Aurumdeep]] | Alpha | A | 146 | 4.38 m | Day & Night | Like a typical Crystal Golem, but larger and scarred, and others of its kind follow it, with bioluminescent spots along its body. |
| `pop_01530` | Zarvan Crystal Golem Albino | [[Regions/Zarvan\|Zarvan]] | Albino | A- | 132 | 3.5 m | Day & Night | Like a typical Crystal Golem, but a rare pale form with white skin or fur and red eyes. |
| `pop_01531` | Zarvan Crystal Golem Elderborn | [[Regions/Zarvan\|Zarvan]] | Elderborn | A+ | 159 | 4.73 m | Day & Night | Like a typical Crystal Golem, but old and wise, with greying features and a cautious hunting style, with sun-bleached, sand-scoured coloring. |
| `pop_01532` | Heavenreach Crystal Golem Elderborn | [[Regions/Heavenreach\|Heavenreach]] | Elderborn | A+ | 159 | 4.73 m | Day & Night | Like a typical Crystal Golem, but old and wise, with greying features and a cautious hunting style, with cloud-pale coloring and lighter bones. |
| `pop_01533` | Aurumdeep Crystal Golem Scarred | [[Regions/Aurumdeep\|Aurumdeep]] | Scarred | A- | 132 | 3.85 m | Day & Night | Like a typical Crystal Golem, but covered in old battle scars, with bioluminescent spots along its body. |
| `pop_01534` | Heavenreach Crystal Golem Runt | [[Regions/Heavenreach\|Heavenreach]] | Runt | B- | 96 | 2.45 m | Day & Night | Like a typical Crystal Golem, but smaller and scrappier than usual, with cloud-pale coloring and lighter bones. |
| `pop_01535` | Zarvan Crystal Golem Alpha | [[Regions/Zarvan\|Zarvan]] | Alpha | A | 146 | 4.38 m | Day & Night | Like a typical Crystal Golem, but larger and scarred, and others of its kind follow it, with sun-bleached, sand-scoured coloring. |
| `pop_01536` | Zarvan Crystal Golem Juvenile | [[Regions/Zarvan\|Zarvan]] | Juvenile | B | 108 | 2.98 m | Day & Night | Like a typical Crystal Golem, but young, with brighter colors and unworn features, with sun-bleached, sand-scoured coloring. |
| `pop_01537` | Zarvan Crystal Golem | [[Regions/Zarvan\|Zarvan]] | Adult | B+ | 120 | 3.5 m | Day & Night | A typical adult Crystal Golem of this region, with sun-bleached, sand-scoured coloring. |
| `pop_01538` | Sunscar Crystal Golem Runt | [[Regions/Sunscar\|Sunscar]] | Runt | B- | 96 | 2.45 m | Day & Night | Like a typical Crystal Golem, but smaller and scrappier than usual, with sun-bleached, sand-scoured coloring. |

## Design recipe

Rig `rig_golem` · mesh `golem_base` · material `stone_metal_runes` · VFX `holy_motes` · palette `#8b8a84` `#5b5a55` `#ffd166` · real-animal silhouette with one fantasy exaggeration
