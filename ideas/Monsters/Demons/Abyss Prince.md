---
type: monster
id: mon_abyss_prince
family: "Demons"
rank: "SSS"
tier: core
tags: [monster, demons]
---
# Abyss Prince

![[mon_abyss_prince_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_abyss_prince_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 20,000 tris · 4.969 × 2.511 × 4 m · local file `Game/Assets/_Game/Art/Models/Monsters/Demons/mon_abyss_prince.fbx`

> The Abyss Prince is a large creature with an upright humanoid build, about 4 m tall. Its hide is rough, scarred and spiked, colored in char-black, with violet-edged markings. Survivors describe a crown of black flame and wings of torn night. It has narrow glowing eyes. Its outline is crowned by slowly turning rings of light; lesser monsters flee from it. It circles its prey, surrounded by warped air, as if space bends around it.

| Field | Value |
|---|---|
| Family · type | [[Families/Demons|Demons]] · Demon |
| Rank · level | SSS · 281 (267–294) |
| Menace | 3 · Menacing |
| Element · weakness | Void · Light |
| Size | 4 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 74479 · 1361 · 1134 · 907 · 1021 · 100 |
| XP · gold | 24842 · 4024 |
| Ring | 8 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Nox Dominion\|Nox Dominion]], [[Regions/Vesper\|Vesper]] |
| Genre | Abyssal |
| Trope | Demons as a people of the Abyss, not just evil (Frieren, Maoyuu) |

**Field note:** Weak to Light. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 4 m high × 1.2 m long × 1.28 m wide; prefab scale 2.222.
- **Physics:** 832 kg, gravity ×1.05, poise 164, knockback resistance 0.54, death style `ragdoll`.
- **Navigation:** speed 8.09 m/s, turn 200°/s, stopping distance 1.08 m.
- **Attack count:** 5; **signature:** a crown of black flame and wings of torn night.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Hellfire Brand\|Hellfire Brand]] | magic | 1.4 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Null Rift\|Null Rift]] | magic | 1.5 | 10 s | Void | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Abyss Prince is a **menacing demon** encountered at SSS rank, around level 281. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a crown of black flame and wings of torn night. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Nox Dominion|Nox Dominion]], [[Regions/Vesper|Vesper]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Demons SSS|loot_demon_sss]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Demon Core\|Demon Core]] | 60% | 1–3 |
| [[Items/Horn Shard\|Horn Shard]] | 30% | 1–1 |
| [[Items/Brimstone\|Brimstone]] | 15% | 1–1 |
| [[Items/SSS-Rank Monster Core\|SSS-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Demons/Ancient Abyss Prince|Ancient Abyss Prince]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Vesper\|Vesper]] | 6 | SSS-, SSS, EX-, EX, SS+, SSS+ | 253–300 | Day & Night |
| [[Regions/Nox Dominion\|Nox Dominion]] | 5 | EX, SSS-, SSS+, EX-, SS+ | 253–300 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01912` | Vesper Abyss Prince Juvenile | [[Regions/Vesper\|Vesper]] | Juvenile | SSS- | 267 | 3.4 m | Day & Night | Like a typical Abyss Prince, but young, with brighter colors and unworn features, with red-black coloring with faint ember veins. |
| `pop_01913` | Nox Dominion Abyss Prince Elderborn | [[Regions/Nox Dominion\|Nox Dominion]] | Elderborn | EX | 300 | 5.4 m | Day & Night | Like a typical Abyss Prince, but old and wise, with greying features and a cautious hunting style, with red-black coloring with faint ember veins. |
| `pop_01914` | Vesper Abyss Prince | [[Regions/Vesper\|Vesper]] | Adult | SSS | 281 | 4 m | Day & Night | A typical adult Abyss Prince of this region, with red-black coloring with faint ember veins. |
| `pop_01915` | Vesper Abyss Prince Alpha | [[Regions/Vesper\|Vesper]] | Alpha | EX- | 300 | 5 m | Day & Night | Like a typical Abyss Prince, but larger and scarred, and others of its kind follow it, with red-black coloring with faint ember veins. |
| `pop_01916` | Nox Dominion Abyss Prince Juvenile | [[Regions/Nox Dominion\|Nox Dominion]] | Juvenile | SSS- | 267 | 3.4 m | Day & Night | Like a typical Abyss Prince, but young, with brighter colors and unworn features, with red-black coloring with faint ember veins. |
| `pop_01917` | Vesper Abyss Prince Elderborn | [[Regions/Vesper\|Vesper]] | Elderborn | EX | 300 | 5.4 m | Day & Night | Like a typical Abyss Prince, but old and wise, with greying features and a cautious hunting style, with red-black coloring with faint ember veins. |
| `pop_01918` | Nox Dominion Abyss Prince Scarred | [[Regions/Nox Dominion\|Nox Dominion]] | Scarred | SSS+ | 294 | 4.4 m | Day & Night | Like a typical Abyss Prince, but covered in old battle scars, with red-black coloring with faint ember veins. |
| `pop_01919` | Vesper Abyss Prince Runt | [[Regions/Vesper\|Vesper]] | Runt | SS+ | 253 | 2.8 m | Day & Night | Like a typical Abyss Prince, but smaller and scrappier than usual, with red-black coloring with faint ember veins. |
| `pop_01920` | Nox Dominion Abyss Prince Alpha | [[Regions/Nox Dominion\|Nox Dominion]] | Alpha | EX- | 300 | 5 m | Day & Night | Like a typical Abyss Prince, but larger and scarred, and others of its kind follow it, with red-black coloring with faint ember veins. |
| `pop_01921` | Vesper Abyss Prince Albino | [[Regions/Vesper\|Vesper]] | Albino | SSS+ | 294 | 4 m | Day & Night | Like a typical Abyss Prince, but a rare pale form with white skin or fur and red eyes. |
| `pop_01922` | Nox Dominion Abyss Prince Runt | [[Regions/Nox Dominion\|Nox Dominion]] | Runt | SS+ | 253 | 2.8 m | Day & Night | Like a typical Abyss Prince, but smaller and scrappier than usual, with red-black coloring with faint ember veins. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `demon_hide_emissive` · VFX `void_distortion` · palette `#4e4b5a` `#403d49` `#8a7cff` · triangle-based silhouette, sharp asymmetric spikes
