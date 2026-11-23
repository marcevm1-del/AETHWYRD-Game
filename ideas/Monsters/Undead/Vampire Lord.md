---
type: monster
id: mon_vampire_lord
family: "Undead"
rank: "S"
tier: core
tags: [monster, undead]
---
# Vampire Lord

![[mon_vampire_lord_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_vampire_lord_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 12,000 tris · 0.748 × 0.847 × 2.2 m · local file `Game/Assets/_Game/Art/Models/Monsters/Undead/mon_vampire_lord.fbx`

> The Vampire Lord is a person-sized creature with a broad-shouldered humanoid build, about 2.2 m tall. Its flesh and bone are rough, scarred and spiked, colored in bleached bone and grave-cloth, with crimson markings. Look for a cape that dissolves into bats. It has narrow glowing eyes. Its regal silhouette is crowned by a halo-like ring of aura. It charges without hesitation, surrounded by a faint red mist that smells of iron.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Rank · level | S · 188 (173–203) |
| Menace | 3 · Menacing |
| Element · weakness | Blood · Light |
| Size | 2.2 m |
| Behaviour | Guardian (guardian_hold) |
| HP · ATK · DEF · MATK · MDEF · SPD | 33392 · 914 · 762 · 610 · 686 · 100 |
| XP · gold | 13063 · 2293 |
| Ring | 8 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Vesper\|Vesper]], [[Regions/Nox Dominion\|Nox Dominion]] |
| Genre | Gothic Horror |
| Trope | Graveyard night threats; the lich and its phylactery; the vampire noble |

**Field note:** Weak to Light. Protects something nearby: a nest, a treasure, or a place.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 2.2 m high × 0.66 m long × 0.7 m wide; prefab scale 1.222.
- **Physics:** 152.3 kg, gravity ×1.5, poise 105, knockback resistance 0.48, death style `ragdoll`.
- **Navigation:** speed 4.91 m/s, turn 270°/s, stopping distance 0.77 m.
- **Attack count:** 5; **signature:** a cape that dissolves into bats.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Grave Grasp\|Grave Grasp]] | grab | 1.2 | 10 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Blood Lance\|Blood Lance]] | magic | 1.5 | 10 s | Blood | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Vampire Lord is a **menacing undead** encountered at S rank, around level 188. Its documented behaviour is *Guardian* and its AI pattern is *guardian_hold*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a cape that dissolves into bats. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Vesper|Vesper]], [[Regions/Nox Dominion|Nox Dominion]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Undead S|loot_undead_s]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Bone Dust\|Bone Dust]] | 60% | 1–3 |
| [[Items/Grave Cloth\|Grave Cloth]] | 30% | 1–1 |
| [[Items/Soul Ember\|Soul Ember]] | 15% | 1–1 |
| [[Items/S-Rank Monster Core\|S-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Undead/Ash Vampire Lord|Ash Vampire Lord]]
- [[Monsters/Undead/Rot Vampire Lord|Rot Vampire Lord]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Vesper\|Vesper]] | 6 | S+, SS-, SS, A+, S | 159–236 | Night |
| [[Regions/Nox Dominion\|Nox Dominion]] | 5 | SS-, S, S-, S+, A+ | 159–218 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00950` | Vesper Vampire Lord Scarred | [[Regions/Vesper\|Vesper]] | Scarred | S+ | 203 | 2.42 m | Night | Like a typical Vampire Lord, but covered in old battle scars, with red-black coloring with faint ember veins. |
| `pop_00951` | Nox Dominion Vampire Lord Alpha | [[Regions/Nox Dominion\|Nox Dominion]] | Alpha | SS- | 218 | 2.75 m | Night | Like a typical Vampire Lord, but larger and scarred, and others of its kind follow it, with red-black coloring with faint ember veins. |
| `pop_00952` | Nox Dominion Vampire Lord | [[Regions/Nox Dominion\|Nox Dominion]] | Adult | S | 188 | 2.2 m | Night | A typical adult Vampire Lord of this region, with red-black coloring with faint ember veins. |
| `pop_00953` | Vesper Vampire Lord Alpha | [[Regions/Vesper\|Vesper]] | Alpha | SS- | 218 | 2.75 m | Night | Like a typical Vampire Lord, but larger and scarred, and others of its kind follow it, with red-black coloring with faint ember veins. |
| `pop_00954` | Vesper Vampire Lord Elderborn | [[Regions/Vesper\|Vesper]] | Elderborn | SS | 236 | 2.97 m | Night | Like a typical Vampire Lord, but old and wise, with greying features and a cautious hunting style, with red-black coloring with faint ember veins. |
| `pop_00955` | Vesper Vampire Lord Runt | [[Regions/Vesper\|Vesper]] | Runt | A+ | 159 | 1.54 m | Night | Like a typical Vampire Lord, but smaller and scrappier than usual, with red-black coloring with faint ember veins. |
| `pop_00956` | Nox Dominion Vampire Lord Juvenile | [[Regions/Nox Dominion\|Nox Dominion]] | Juvenile | S- | 173 | 1.87 m | Night | Like a typical Vampire Lord, but young, with brighter colors and unworn features, with red-black coloring with faint ember veins. |
| `pop_00957` | Vesper Vampire Lord Albino | [[Regions/Vesper\|Vesper]] | Albino | S+ | 203 | 2.2 m | Night | Like a typical Vampire Lord, but a rare pale form with white skin or fur and red eyes. |
| `pop_00958` | Nox Dominion Vampire Lord Albino | [[Regions/Nox Dominion\|Nox Dominion]] | Albino | S+ | 203 | 2.2 m | Night | Like a typical Vampire Lord, but a rare pale form with white skin or fur and red eyes. |
| `pop_00959` | Vesper Vampire Lord | [[Regions/Vesper\|Vesper]] | Adult | S | 188 | 2.2 m | Night | A typical adult Vampire Lord of this region, with red-black coloring with faint ember veins. |
| `pop_00960` | Nox Dominion Vampire Lord Runt | [[Regions/Nox Dominion\|Nox Dominion]] | Runt | A+ | 159 | 1.54 m | Night | Like a typical Vampire Lord, but smaller and scrappier than usual, with red-black coloring with faint ember veins. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `rot_bone` · VFX `blood_mist` · palette `#ebd6bf` `#968371` `#e0344a` · triangle-based silhouette, sharp asymmetric spikes
