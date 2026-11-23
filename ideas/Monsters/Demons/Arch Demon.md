---
type: monster
id: mon_arch_demon
family: "Demons"
rank: "S"
tier: core
tags: [monster, demons]
---
# Arch Demon

![[mon_arch_demon_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_arch_demon_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 30,000 tris · 12.606 × 8.001 × 5.459 m · local file `Game/Assets/_Game/Art/Models/Monsters/Demons/mon_arch_demon.fbx`

> The Arch Demon is a huge creature with a sleek flying build, about 8 m long. Its hide is rough, scarred and spiked, colored in brimstone red, with violet markings. Guild sketches always show four wings and a voice like a choir. It has burning slit pupils. Its regal silhouette is crowned by a halo-like ring of aura. It strides with heavy steps, surrounded by shadows that lean toward it.

| Field | Value |
|---|---|
| Family · type | [[Families/Demons|Demons]] · Demon |
| Rank · level | S · 188 (173–203) |
| Menace | 3 · Menacing |
| Element · weakness | Dark · Light |
| Size | 8 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 50569 · 914 · 762 · 610 · 686 · 100 |
| XP · gold | 13063 · 2293 |
| Ring | 8 |
| Rig · animation | [[Systems/Rigs/wyvern\|wyvern]] · `anim_wyvern` |
| Habitats | [[Regions/Nox Dominion\|Nox Dominion]], [[Regions/Vesper\|Vesper]] |
| Genre | Abyssal |
| Trope | Demons as a people of the Abyss, not just evil (Frieren, Maoyuu) |

**Field note:** Weak to Light. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/wyvern|wyvern]] (rigId); animation set `anim_wyvern`.
- **Dimensions:** 4 m high × 8 m long × 12.21 m wide; prefab scale 1.333.
- **Physics:** 2355.2 kg, gravity ×1, poise 303, knockback resistance 0.98, death style `crash_slide`.
- **Navigation:** speed 7.89 m/s, turn 212°/s, stopping distance 1.04 m.
- **Attack count:** 5; **signature:** four wings and a voice like a choir.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Talon Rake\|Talon Rake]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Dive Bomb\|Dive Bomb]] | dash | 1.9 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Tail Whip\|Tail Whip]] | aoe | 1.3 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Hellfire Brand\|Hellfire Brand]] | magic | 1.4 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Arch Demon is a **menacing demon** encountered at S rank, around level 188. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** four wings and a voice like a choir. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Nox Dominion|Nox Dominion]], [[Regions/Vesper|Vesper]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_wyvern`, animation set `anim_wyvern`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Demons S|loot_demon_s]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Demon Core\|Demon Core]] | 60% | 1–3 |
| [[Items/Horn Shard\|Horn Shard]] | 30% | 1–1 |
| [[Items/Brimstone\|Brimstone]] | 15% | 1–1 |
| [[Items/S-Rank Monster Core\|S-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Demons/Blight Arch Demon|Blight Arch Demon]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Nox Dominion\|Nox Dominion]] | 7 | S+, S-, S, SS, A+, SS- | 159–236 | Day & Night |
| [[Regions/Vesper\|Vesper]] | 4 | SS, A+, S+, S | 159–236 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01901` | Nox Dominion Arch Demon Albino | [[Regions/Nox Dominion\|Nox Dominion]] | Albino | S+ | 203 | 8 m | Day & Night | Like a typical Arch Demon, but a rare pale form with white skin or fur and red eyes. |
| `pop_01902` | Nox Dominion Arch Demon Juvenile | [[Regions/Nox Dominion\|Nox Dominion]] | Juvenile | S- | 173 | 6.8 m | Day & Night | Like a typical Arch Demon, but young, with brighter colors and unworn features, with red-black coloring with faint ember veins. |
| `pop_01903` | Vesper Arch Demon Elderborn | [[Regions/Vesper\|Vesper]] | Elderborn | SS | 236 | 10.8 m | Day & Night | Like a typical Arch Demon, but old and wise, with greying features and a cautious hunting style, with red-black coloring with faint ember veins. |
| `pop_01904` | Nox Dominion Arch Demon | [[Regions/Nox Dominion\|Nox Dominion]] | Adult | S | 188 | 8 m | Day & Night | A typical adult Arch Demon of this region, with red-black coloring with faint ember veins. |
| `pop_01905` | Nox Dominion Arch Demon Elderborn | [[Regions/Nox Dominion\|Nox Dominion]] | Elderborn | SS | 236 | 10.8 m | Day & Night | Like a typical Arch Demon, but old and wise, with greying features and a cautious hunting style, with red-black coloring with faint ember veins. |
| `pop_01906` | Nox Dominion Arch Demon Runt | [[Regions/Nox Dominion\|Nox Dominion]] | Runt | A+ | 159 | 5.6 m | Day & Night | Like a typical Arch Demon, but smaller and scrappier than usual, with red-black coloring with faint ember veins. |
| `pop_01907` | Nox Dominion Arch Demon Scarred | [[Regions/Nox Dominion\|Nox Dominion]] | Scarred | S+ | 203 | 8.8 m | Day & Night | Like a typical Arch Demon, but covered in old battle scars, with red-black coloring with faint ember veins. |
| `pop_01908` | Nox Dominion Arch Demon Alpha | [[Regions/Nox Dominion\|Nox Dominion]] | Alpha | SS- | 218 | 10 m | Day & Night | Like a typical Arch Demon, but larger and scarred, and others of its kind follow it, with red-black coloring with faint ember veins. |
| `pop_01909` | Vesper Arch Demon Runt | [[Regions/Vesper\|Vesper]] | Runt | A+ | 159 | 5.6 m | Day & Night | Like a typical Arch Demon, but smaller and scrappier than usual, with red-black coloring with faint ember veins. |
| `pop_01910` | Vesper Arch Demon Albino | [[Regions/Vesper\|Vesper]] | Albino | S+ | 203 | 8 m | Day & Night | Like a typical Arch Demon, but a rare pale form with white skin or fur and red eyes. |
| `pop_01911` | Vesper Arch Demon | [[Regions/Vesper\|Vesper]] | Adult | S | 188 | 8 m | Day & Night | A typical adult Arch Demon of this region, with red-black coloring with faint ember veins. |

## Design recipe

Rig `rig_wyvern` · mesh `wyvern_base` · material `demon_hide_emissive` · VFX `shadow_wisps` · palette `#a23629` `#5b2b27` `#9a86d8` · triangle-based silhouette, sharp asymmetric spikes
