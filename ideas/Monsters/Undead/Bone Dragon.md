---
type: monster
id: mon_bone_dragon
family: "Undead"
rank: "S"
tier: core
tags: [monster, undead]
---
# Bone Dragon

![[mon_bone_dragon_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_bone_dragon_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Bone Dragon is a colossal creature with a vast quadruped dragon frame with cathedral wings, about 20 m long. Its flesh and bone are patchy and subtly wrong, as if assembled from memory, colored in ink black with bruised violet. Its most striking feature is a dragon skeleton held together by green fire. It has eyes that never blink. Its regal silhouette is crowned by a halo-like ring of aura. It freezes whenever it is looked at, surrounded by shadows that lean toward it.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Rank · level | S · 188 (173–203) |
| Menace | 4 · Dread |
| Element · weakness | Dark · Light |
| Size | 20 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 88149 · 991 · 914 · 991 · 914 · 100 |
| XP · gold | 13063 · 2293 |
| Ring | 8 |
| Rig · animation | [[Systems/Rigs/dragon\|dragon]] · `anim_dragon` |
| Habitats | [[Regions/Vesper\|Vesper]], [[Regions/Nox Dominion\|Nox Dominion]] |
| Genre | Gothic Horror |
| Trope | Graveyard night threats; the lich and its phylactery; the vampire noble |

**Field note:** Weak to Light. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/dragon|dragon]] (rigId); animation set `anim_dragon`.
- **Dimensions:** 11.2 m high × 20 m long × 28.2 m wide; prefab scale 1.667.
- **Physics:** 55200 kg, gravity ×1, poise 981, knockback resistance 1, death style `cinematic_collapse`.
- **Navigation:** speed 10.48 m/s, turn 134°/s, stopping distance 2 m.
- **Attack count:** 6; **signature:** a dragon skeleton held together by green fire.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Claw\|Claw]] | melee | 1.4 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Breath\|Breath]] | aoe | 2.2 | 14 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Wing Gust\|Wing Gust]] | aoe | 1 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Tail Blade\|Tail Blade]] | melee | 1.8 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Grave Grasp\|Grave Grasp]] | grab | 1.2 | 10 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Bone Dragon is a **dread undead** encountered at S rank, around level 188. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a dragon skeleton held together by green fire. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Vesper|Vesper]], [[Regions/Nox Dominion|Nox Dominion]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_dragon`, animation set `anim_dragon`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Undead S|loot_undead_s]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Bone Dust\|Bone Dust]] | 60% | 1–3 |
| [[Items/Grave Cloth\|Grave Cloth]] | 30% | 1–1 |
| [[Items/Soul Ember\|Soul Ember]] | 15% | 1–1 |
| [[Items/S-Rank Monster Core\|S-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Undead/Dawn Bone Dragon|Dawn Bone Dragon]]
- [[Monsters/Undead/Elder Bone Dragon|Elder Bone Dragon]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Nox Dominion\|Nox Dominion]] | 7 | A+, SS, S-, S, SS-, S+ | 159–236 | Night |
| [[Regions/Vesper\|Vesper]] | 4 | S+, SS, SS- | 203–236 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00961` | Nox Dominion Bone Dragon Runt | [[Regions/Nox Dominion\|Nox Dominion]] | Runt | A+ | 159 | 14 m | Night | Like a typical Bone Dragon, but smaller and scrappier than usual, with red-black coloring with faint ember veins. |
| `pop_00962` | Vesper Bone Dragon Albino | [[Regions/Vesper\|Vesper]] | Albino | S+ | 203 | 20 m | Night | Like a typical Bone Dragon, but a rare pale form with white skin or fur and red eyes. |
| `pop_00963` | Nox Dominion Bone Dragon Elderborn | [[Regions/Nox Dominion\|Nox Dominion]] | Elderborn | SS | 236 | 27 m | Night | Like a typical Bone Dragon, but old and wise, with greying features and a cautious hunting style, with red-black coloring with faint ember veins. |
| `pop_00964` | Vesper Bone Dragon Elderborn | [[Regions/Vesper\|Vesper]] | Elderborn | SS | 236 | 27 m | Night | Like a typical Bone Dragon, but old and wise, with greying features and a cautious hunting style, with red-black coloring with faint ember veins. |
| `pop_00965` | Nox Dominion Bone Dragon Juvenile | [[Regions/Nox Dominion\|Nox Dominion]] | Juvenile | S- | 173 | 17 m | Night | Like a typical Bone Dragon, but young, with brighter colors and unworn features, with red-black coloring with faint ember veins. |
| `pop_00966` | Nox Dominion Bone Dragon | [[Regions/Nox Dominion\|Nox Dominion]] | Adult | S | 188 | 20 m | Night | A typical adult Bone Dragon of this region, with red-black coloring with faint ember veins. |
| `pop_00967` | Vesper Bone Dragon Scarred | [[Regions/Vesper\|Vesper]] | Scarred | S+ | 203 | 22 m | Night | Like a typical Bone Dragon, but covered in old battle scars, with red-black coloring with faint ember veins. |
| `pop_00968` | Vesper Bone Dragon Alpha | [[Regions/Vesper\|Vesper]] | Alpha | SS- | 218 | 25 m | Night | Like a typical Bone Dragon, but larger and scarred, and others of its kind follow it, with red-black coloring with faint ember veins. |
| `pop_00969` | Nox Dominion Bone Dragon Alpha | [[Regions/Nox Dominion\|Nox Dominion]] | Alpha | SS- | 218 | 25 m | Night | Like a typical Bone Dragon, but larger and scarred, and others of its kind follow it, with red-black coloring with faint ember veins. |
| `pop_00970` | Nox Dominion Bone Dragon Scarred | [[Regions/Nox Dominion\|Nox Dominion]] | Scarred | S+ | 203 | 22 m | Night | Like a typical Bone Dragon, but covered in old battle scars, with red-black coloring with faint ember veins. |
| `pop_00971` | Nox Dominion Bone Dragon Albino | [[Regions/Nox Dominion\|Nox Dominion]] | Albino | S+ | 203 | 20 m | Night | Like a typical Bone Dragon, but a rare pale form with white skin or fur and red eyes. |

## Design recipe

Rig `rig_dragon` · mesh `dragon_base` · material `rot_bone` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · elongated, irregular silhouette; still-then-sudden timing
