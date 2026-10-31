---
type: monster
id: mon_mithril_colossus
family: "Constructs & Mimics"
rank: "S"
tier: core
tags: [monster, constructs-mimics]
---
# Mithril Colossus

![[mon_mithril_colossus_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_mithril_colossus_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,644 tris · 47.028 × 32.165 × 50 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Mithril Colossus is a colossal creature with a heavy, hand-built humanoid shell, about 50 m tall. Its surface is weathered and natural, colored in weathered stone, with gold markings. Survivors describe silver plating and a face like a temple mask. It has alert animal eyes. Its regal silhouette is crowned by a halo-like ring of aura. It stalks low to the ground, surrounded by soft radiance and floating motes of light.

| Field | Value |
|---|---|
| Family · type | [[Families/Constructs & Mimics|Constructs & Mimics]] · Construct |
| Rank · level | S · 188 (173–203) |
| Menace | 2 · Wild |
| Element · weakness | Light · Dark |
| Size | 50 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 101031 · 762 · 1143 · 457 · 762 · 70 |
| XP · gold | 13063 · 2293 |
| Ring | 7 |
| Rig · animation | [[Systems/Rigs/golem\|golem]] · `anim_golem` |
| Habitats | [[Regions/Sky Archipelago\|Sky Archipelago]], [[Regions/Vesper\|Vesper]] |
| Genre | Ancient Ruins |
| Trope | Treasure-chest mimics and ancient guardian golems |

**Field note:** Weak to Dark. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/golem|golem]] (rigId); animation set `anim_golem`.
- **Dimensions:** 50 m high × 15 m long × 21 m wide; prefab scale 16.667.
- **Physics:** 5700000 kg, gravity ×1.08, poise 1551, knockback resistance 1, death style `crumble_into_rubble`.
- **Navigation:** speed 12.84 m/s, turn 60°/s, stopping distance 11.4 m.
- **Attack count:** 5; **signature:** silver plating and a face like a temple mask.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slam\|Slam]] | melee | 1.4 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Ground Pound\|Ground Pound]] | aoe | 1.8 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Stance\|Guard Stance]] | buff | 0 | 15 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Rune Pulse\|Rune Pulse]] | magic | 1.3 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Radiant Pulse\|Radiant Pulse]] | magic | 1.5 | 10 s | Light | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Mithril Colossus is a **wild construct** encountered at S rank, around level 188. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Dark**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** silver plating and a face like a temple mask. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Sky Archipelago|Sky Archipelago]], [[Regions/Vesper|Vesper]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_golem`, animation set `anim_golem`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Constructs & Mimics S|loot_construct_s]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Golem Core\|Golem Core]] | 60% | 1–3 |
| [[Items/Rune Plate\|Rune Plate]] | 30% | 1–1 |
| [[Items/Gear\|Gear]] | 15% | 1–1 |
| [[Items/S-Rank Monster Core\|S-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Constructs & Mimics/Ancient Mithril Colossus|Ancient Mithril Colossus]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Sky Archipelago\|Sky Archipelago]] | 5 | S+, S, S-, SS | 173–236 | Day & Night |
| [[Regions/Vesper\|Vesper]] | 6 | SS-, A+, S+, S-, S, SS | 159–236 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01550` | Sky Archipelago Mithril Colossus Scarred | [[Regions/Sky Archipelago\|Sky Archipelago]] | Scarred | S+ | 203 | 55 m | Day & Night | Like a typical Mithril Colossus, but covered in old battle scars, with cloud-pale coloring and lighter bones. |
| `pop_01551` | Sky Archipelago Mithril Colossus | [[Regions/Sky Archipelago\|Sky Archipelago]] | Adult | S | 188 | 50 m | Day & Night | A typical adult Mithril Colossus of this region, with cloud-pale coloring and lighter bones. |
| `pop_01552` | Sky Archipelago Mithril Colossus Albino | [[Regions/Sky Archipelago\|Sky Archipelago]] | Albino | S+ | 203 | 50 m | Day & Night | Like a typical Mithril Colossus, but a rare pale form with white skin or fur and red eyes. |
| `pop_01553` | Sky Archipelago Mithril Colossus Juvenile | [[Regions/Sky Archipelago\|Sky Archipelago]] | Juvenile | S- | 173 | 42.5 m | Day & Night | Like a typical Mithril Colossus, but young, with brighter colors and unworn features, with cloud-pale coloring and lighter bones. |
| `pop_01554` | Vesper Mithril Colossus Alpha | [[Regions/Vesper\|Vesper]] | Alpha | SS- | 218 | 62.5 m | Day & Night | Like a typical Mithril Colossus, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_01555` | Vesper Mithril Colossus Runt | [[Regions/Vesper\|Vesper]] | Runt | A+ | 159 | 35 m | Day & Night | Like a typical Mithril Colossus, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_01556` | Vesper Mithril Colossus Albino | [[Regions/Vesper\|Vesper]] | Albino | S+ | 203 | 50 m | Day & Night | Like a typical Mithril Colossus, but a rare pale form with white skin or fur and red eyes. |
| `pop_01557` | Vesper Mithril Colossus Juvenile | [[Regions/Vesper\|Vesper]] | Juvenile | S- | 173 | 42.5 m | Day & Night | Like a typical Mithril Colossus, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_01558` | Sky Archipelago Mithril Colossus Elderborn | [[Regions/Sky Archipelago\|Sky Archipelago]] | Elderborn | SS | 236 | 67.5 m | Day & Night | Like a typical Mithril Colossus, but old and wise, with greying features and a cautious hunting style, with cloud-pale coloring and lighter bones. |
| `pop_01559` | Vesper Mithril Colossus | [[Regions/Vesper\|Vesper]] | Adult | S | 188 | 50 m | Day & Night | A typical adult Mithril Colossus of this region, with dust-grey coloring and old rune scars. |
| `pop_01560` | Vesper Mithril Colossus Elderborn | [[Regions/Vesper\|Vesper]] | Elderborn | SS | 236 | 67.5 m | Day & Night | Like a typical Mithril Colossus, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |

## Design recipe

Rig `rig_golem` · mesh `golem_base` · material `stone_metal_runes` · VFX `holy_motes` · palette `#888581` `#5a5754` `#ffd166` · real-animal silhouette with one fantasy exaggeration
