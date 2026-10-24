---
type: monster
id: mon_vesper_touched_crystal_golem
family: "Constructs & Mimics"
rank: "A"
tier: variant
tags: [monster, constructs-mimics]
---
# Vesper-Touched Crystal Golem

![[mon_vesper_touched_crystal_golem_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_vesper_touched_crystal_golem_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Vesper-Touched Crystal Golem is a large creature with a towering machine-like frame, about 3.5 m tall. Its surface is rough, scarred and spiked, colored in warm gold and pearl white. Guild sketches always show a body of prisms that splits light into rainbows. It has eyes that catch torchlight like coins. An elegant crest and glowing veins of mana mark it as a champion of its kind. It strides with heavy steps, surrounded by soft radiance and floating motes of light. Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.

| Field | Value |
|---|---|
| Family · type | [[Families/Constructs & Mimics|Constructs & Mimics]] · Construct |
| Variant of | [[Monsters/Constructs & Mimics/Crystal Golem\|Crystal Golem]] (corrupted) |
| Rank · level | A · 146 (132–159) |
| Menace | 3 · Menacing |
| Element · weakness | Light · Dark |
| Size | 3.5 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 34058 · 594 · 891 · 356 · 594 · 70 |
| XP · gold | 8719 · 1611 |
| Ring | 7 |
| Rig · animation | [[Systems/Rigs/golem\|golem]] · `anim_golem` |
| Habitats | [[Regions/Sky Archipelago\|Sky Archipelago]], [[Regions/Heavenreach\|Heavenreach]] |
| Genre | Ancient Ruins |
| Trope | Treasure-chest mimics and ancient guardian golems |

**Field note:** Weak to Dark. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/golem|golem]] (rigId); animation set `anim_golem`.
- **Dimensions:** 3.5 m high × 1.05 m long × 1.47 m wide; prefab scale 1.167.
- **Physics:** 1955.1 kg, gravity ×1.08, poise 378, knockback resistance 1, death style `crumble_into_rubble`.
- **Navigation:** speed 3.57 m/s, turn 107°/s, stopping distance 1.17 m.
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

Vesper-Touched Crystal Golem is a **menacing construct** encountered at A rank, around level 146. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Dark**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a body of prisms that splits light into rainbows. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Sky Archipelago|Sky Archipelago]], [[Regions/Heavenreach|Heavenreach]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_golem`, animation set `anim_golem`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Constructs & Mimics A|loot_construct_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Golem Core\|Golem Core]] | 60% | 1–3 |
| [[Items/Rune Plate\|Rune Plate]] | 30% | 1–1 |
| [[Items/Gear\|Gear]] | 15% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Heavenreach\|Heavenreach]] | 4 | S, A+, B+, A | 120–188 | Day & Night |
| [[Regions/Sky Archipelago\|Sky Archipelago]] | 7 | A+, S-, S, A-, B+, A | 120–188 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04407` | Heavenreach Vesper-Touched Crystal Golem Elderborn | [[Regions/Heavenreach\|Heavenreach]] | Elderborn | S | 188 | 4.73 m | Day & Night | Like a typical Vesper-Touched Crystal Golem, but old and wise, with greying features and a cautious hunting style, with cloud-pale coloring and lighter bones. |
| `pop_04408` | Sky Archipelago Vesper-Touched Crystal Golem Scarred | [[Regions/Sky Archipelago\|Sky Archipelago]] | Scarred | A+ | 159 | 3.85 m | Day & Night | Like a typical Vesper-Touched Crystal Golem, but covered in old battle scars, with cloud-pale coloring and lighter bones. |
| `pop_04409` | Heavenreach Vesper-Touched Crystal Golem Albino | [[Regions/Heavenreach\|Heavenreach]] | Albino | A+ | 159 | 3.5 m | Day & Night | Like a typical Vesper-Touched Crystal Golem, but a rare pale form with white skin or fur and red eyes. |
| `pop_04410` | Sky Archipelago Vesper-Touched Crystal Golem Alpha | [[Regions/Sky Archipelago\|Sky Archipelago]] | Alpha | S- | 173 | 4.38 m | Day & Night | Like a typical Vesper-Touched Crystal Golem, but larger and scarred, and others of its kind follow it, with cloud-pale coloring and lighter bones. |
| `pop_04411` | Sky Archipelago Vesper-Touched Crystal Golem Elderborn | [[Regions/Sky Archipelago\|Sky Archipelago]] | Elderborn | S | 188 | 4.73 m | Day & Night | Like a typical Vesper-Touched Crystal Golem, but old and wise, with greying features and a cautious hunting style, with cloud-pale coloring and lighter bones. |
| `pop_04412` | Heavenreach Vesper-Touched Crystal Golem Runt | [[Regions/Heavenreach\|Heavenreach]] | Runt | B+ | 120 | 2.45 m | Day & Night | Like a typical Vesper-Touched Crystal Golem, but smaller and scrappier than usual, with cloud-pale coloring and lighter bones. |
| `pop_04413` | Heavenreach Vesper-Touched Crystal Golem | [[Regions/Heavenreach\|Heavenreach]] | Adult | A | 146 | 3.5 m | Day & Night | A typical adult Vesper-Touched Crystal Golem of this region, with cloud-pale coloring and lighter bones. |
| `pop_04414` | Sky Archipelago Vesper-Touched Crystal Golem Juvenile | [[Regions/Sky Archipelago\|Sky Archipelago]] | Juvenile | A- | 132 | 2.98 m | Day & Night | Like a typical Vesper-Touched Crystal Golem, but young, with brighter colors and unworn features, with cloud-pale coloring and lighter bones. |
| `pop_04415` | Sky Archipelago Vesper-Touched Crystal Golem Runt | [[Regions/Sky Archipelago\|Sky Archipelago]] | Runt | B+ | 120 | 2.45 m | Day & Night | Like a typical Vesper-Touched Crystal Golem, but smaller and scrappier than usual, with cloud-pale coloring and lighter bones. |
| `pop_04416` | Sky Archipelago Vesper-Touched Crystal Golem Albino | [[Regions/Sky Archipelago\|Sky Archipelago]] | Albino | A+ | 159 | 3.5 m | Day & Night | Like a typical Vesper-Touched Crystal Golem, but a rare pale form with white skin or fur and red eyes. |
| `pop_04417` | Sky Archipelago Vesper-Touched Crystal Golem | [[Regions/Sky Archipelago\|Sky Archipelago]] | Adult | A | 146 | 3.5 m | Day & Night | A typical adult Vesper-Touched Crystal Golem of this region, with cloud-pale coloring and lighter bones. |

## Design recipe

Rig `rig_golem` · mesh `golem_base` · material `stone_metal_runes` · VFX `holy_motes` · palette `#fff3b0` `#ffd166` `#ffffff` · triangle-based silhouette, sharp asymmetric spikes
