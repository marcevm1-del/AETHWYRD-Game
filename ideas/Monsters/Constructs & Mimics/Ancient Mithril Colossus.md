---
type: monster
id: mon_ancient_mithril_colossus
family: "Constructs & Mimics"
rank: "SS"
tier: variant
tags: [monster, constructs-mimics]
---
# Ancient Mithril Colossus

![[mon_ancient_mithril_colossus_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_ancient_mithril_colossus_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (1,108 tris · 73.475 × 50.254 × 75 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Ancient Mithril Colossus is a colossal creature with a blocky construct body, about 75 m tall. Its surface is weathered and natural, colored in weathered stone, with gold markings. Look for silver plating and a face like a temple mask. It has alert animal eyes. The air distorts slightly around its outline. It lopes in long strides, surrounded by soft radiance and floating motes of light. Moss, crystals and centuries-old scars cover its body; it has outlived every hunter sent after it.

| Field | Value |
|---|---|
| Family · type | [[Families/Constructs & Mimics|Constructs & Mimics]] · Construct |
| Variant of | [[Monsters/Constructs & Mimics/Mithril Colossus\|Mithril Colossus]] (ancient) |
| Rank · level | SS · 236 (218–253) |
| Menace | 2 · Wild |
| Element · weakness | Light · Dark |
| Size | 75 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 153843 · 954 · 1431 · 572 · 954 · 70 |
| XP · gold | 18792 · 3152 |
| Ring | 8 |
| Rig · animation | [[Systems/Rigs/golem\|golem]] · `anim_golem` |
| Habitats | [[Regions/Sky Archipelago\|Sky Archipelago]], [[Regions/Vesper\|Vesper]] |
| Genre | Ancient Ruins |
| Trope | Treasure-chest mimics and ancient guardian golems |

**Field note:** Weak to Dark. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/golem|golem]] (rigId); animation set `anim_golem`.
- **Dimensions:** 75 m high × 22.5 m long × 31.5 m wide; prefab scale 25.
- **Physics:** 19237500 kg, gravity ×1.08, poise 2050, knockback resistance 1, death style `crumble_into_rubble`.
- **Navigation:** speed 15.72 m/s, turn 60°/s, stopping distance 12.4 m.
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

Ancient Mithril Colossus is a **wild construct** encountered at SS rank, around level 236. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Dark**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** silver plating and a face like a temple mask. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Sky Archipelago|Sky Archipelago]], [[Regions/Vesper|Vesper]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_golem`, animation set `anim_golem`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Constructs & Mimics SS|loot_construct_ss]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Golem Core\|Golem Core]] | 60% | 1–3 |
| [[Items/Rune Plate\|Rune Plate]] | 30% | 1–1 |
| [[Items/Gear\|Gear]] | 15% | 1–1 |
| [[Items/SS-Rank Monster Core\|SS-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Vesper\|Vesper]] | 5 | SS+, SS, SSS, S+ | 203–281 | Day & Night |
| [[Regions/Sky Archipelago\|Sky Archipelago]] | 6 | SS-, SS, S+, SSS-, SS+ | 203–267 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04429` | Vesper Ancient Mithril Colossus Scarred | [[Regions/Vesper\|Vesper]] | Scarred | SS+ | 253 | 82.5 m | Day & Night | Like a typical Ancient Mithril Colossus, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_04430` | Vesper Ancient Mithril Colossus Albino | [[Regions/Vesper\|Vesper]] | Albino | SS+ | 253 | 75 m | Day & Night | Like a typical Ancient Mithril Colossus, but a rare pale form with white skin or fur and red eyes. |
| `pop_04431` | Sky Archipelago Ancient Mithril Colossus Juvenile | [[Regions/Sky Archipelago\|Sky Archipelago]] | Juvenile | SS- | 218 | 63.75 m | Day & Night | Like a typical Ancient Mithril Colossus, but young, with brighter colors and unworn features, with cloud-pale coloring and lighter bones. |
| `pop_04432` | Sky Archipelago Ancient Mithril Colossus | [[Regions/Sky Archipelago\|Sky Archipelago]] | Adult | SS | 236 | 75 m | Day & Night | A typical adult Ancient Mithril Colossus of this region, with cloud-pale coloring and lighter bones. |
| `pop_04433` | Sky Archipelago Ancient Mithril Colossus Runt | [[Regions/Sky Archipelago\|Sky Archipelago]] | Runt | S+ | 203 | 52.5 m | Day & Night | Like a typical Ancient Mithril Colossus, but smaller and scrappier than usual, with cloud-pale coloring and lighter bones. |
| `pop_04434` | Sky Archipelago Ancient Mithril Colossus Alpha | [[Regions/Sky Archipelago\|Sky Archipelago]] | Alpha | SSS- | 267 | 93.75 m | Day & Night | Like a typical Ancient Mithril Colossus, but larger and scarred, and others of its kind follow it, with cloud-pale coloring and lighter bones. |
| `pop_04435` | Vesper Ancient Mithril Colossus | [[Regions/Vesper\|Vesper]] | Adult | SS | 236 | 75 m | Day & Night | A typical adult Ancient Mithril Colossus of this region, with dust-grey coloring and old rune scars. |
| `pop_04436` | Sky Archipelago Ancient Mithril Colossus Scarred | [[Regions/Sky Archipelago\|Sky Archipelago]] | Scarred | SS+ | 253 | 82.5 m | Day & Night | Like a typical Ancient Mithril Colossus, but covered in old battle scars, with cloud-pale coloring and lighter bones. |
| `pop_04437` | Vesper Ancient Mithril Colossus Elderborn | [[Regions/Vesper\|Vesper]] | Elderborn | SSS | 281 | 101.25 m | Day & Night | Like a typical Ancient Mithril Colossus, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_04438` | Vesper Ancient Mithril Colossus Runt | [[Regions/Vesper\|Vesper]] | Runt | S+ | 203 | 52.5 m | Day & Night | Like a typical Ancient Mithril Colossus, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_04439` | Sky Archipelago Ancient Mithril Colossus Albino | [[Regions/Sky Archipelago\|Sky Archipelago]] | Albino | SS+ | 253 | 75 m | Day & Night | Like a typical Ancient Mithril Colossus, but a rare pale form with white skin or fur and red eyes. |

## Design recipe

Rig `rig_golem` · mesh `golem_base` · material `stone_metal_runes` · VFX `holy_motes` · palette `#85847e` `#575651` `#ffd166` · real-animal silhouette with one fantasy exaggeration
