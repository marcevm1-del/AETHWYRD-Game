---
type: monster
id: mon_demon_knight
family: "Demons"
rank: "A"
tier: core
tags: [monster, demons]
---
# Demon Knight

![[mon_demon_knight_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_demon_knight_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,826 tris · 1.355 × 1.695 × 2.5 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Demon Knight is a large creature with a broad-shouldered humanoid build, about 2.5 m tall. Its hide is rough, scarred and spiked, colored in bruised violet. Its most striking feature is black-steel armor engraved with the Overlord's sigil. It has eyes that catch torchlight like coins. An elegant crest and glowing veins of mana mark it as a champion of its kind. It charges without hesitation, surrounded by shadows that lean toward it.

| Field | Value |
|---|---|
| Family · type | [[Families/Demons|Demons]] · Demon |
| Rank · level | A · 146 (132–159) |
| Menace | 3 · Menacing |
| Element · weakness | Dark · Light |
| Size | 2.5 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 23900 · 713 · 594 · 475 · 535 · 100 |
| XP · gold | 8719 · 1611 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Nox Dominion\|Nox Dominion]], [[Regions/Aurumdeep\|Aurumdeep]], [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/Iron Hold\|Iron Hold]] |
| Genre | Abyssal |
| Trope | Demons as a people of the Abyss, not just evil (Frieren, Maoyuu) |

**Field note:** Weak to Light. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 2.5 m high × 0.75 m long × 0.8 m wide; prefab scale 1.389.
- **Physics:** 203.1 kg, gravity ×1.5, poise 103, knockback resistance 0.45, death style `ragdoll`.
- **Navigation:** speed 6.71 m/s, turn 253°/s, stopping distance 0.83 m.
- **Attack count:** 5; **signature:** black-steel armor engraved with the Overlord's sigil.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Hellfire Brand\|Hellfire Brand]] | magic | 1.4 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Demon Knight is a **menacing demon** encountered at A rank, around level 146. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** black-steel armor engraved with the Overlord's sigil. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Nox Dominion|Nox Dominion]], [[Regions/Aurumdeep|Aurumdeep]], [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]], [[Regions/Iron Hold|Iron Hold]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Demons A|loot_demon_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Demon Core\|Demon Core]] | 60% | 1–3 |
| [[Items/Horn Shard\|Horn Shard]] | 30% | 1–1 |
| [[Items/Brimstone\|Brimstone]] | 15% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Demons/Rot Demon Knight|Rot Demon Knight]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Iron Hold\|Iron Hold]] | 2 | B+, S- | 120–173 | Day & Night |
| [[Regions/Aurumdeep\|Aurumdeep]] | 2 | S-, A+ | 159–173 | Day & Night |
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 3 | S, S-, A+ | 159–188 | Day & Night |
| [[Regions/Nox Dominion\|Nox Dominion]] | 4 | S, A-, A+, B+ | 120–188 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01890` | Iron Hold Demon Knight Runt | [[Regions/Iron Hold\|Iron Hold]] | Runt | B+ | 120 | 1.75 m | Day & Night | Like a typical Demon Knight, but smaller and scrappier than usual, with ash-dark coloring with glowing cracks. |
| `pop_01891` | Aurumdeep Demon Knight Alpha | [[Regions/Aurumdeep\|Aurumdeep]] | Alpha | S- | 173 | 3.13 m | Day & Night | Like a typical Demon Knight, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_01892` | Great Labyrinth (Floors 41-90) Demon Knight Elderborn | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Elderborn | S | 188 | 3.38 m | Day & Night | Like a typical Demon Knight, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_01893` | Nox Dominion Demon Knight Elderborn | [[Regions/Nox Dominion\|Nox Dominion]] | Elderborn | S | 188 | 3.38 m | Day & Night | Like a typical Demon Knight, but old and wise, with greying features and a cautious hunting style, with red-black coloring with faint ember veins. |
| `pop_01894` | Great Labyrinth (Floors 41-90) Demon Knight Alpha | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Alpha | S- | 173 | 3.13 m | Day & Night | Like a typical Demon Knight, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_01895` | Iron Hold Demon Knight Alpha | [[Regions/Iron Hold\|Iron Hold]] | Alpha | S- | 173 | 3.13 m | Day & Night | Like a typical Demon Knight, but larger and scarred, and others of its kind follow it, with ash-dark coloring with glowing cracks. |
| `pop_01896` | Nox Dominion Demon Knight Juvenile | [[Regions/Nox Dominion\|Nox Dominion]] | Juvenile | A- | 132 | 2.13 m | Day & Night | Like a typical Demon Knight, but young, with brighter colors and unworn features, with red-black coloring with faint ember veins. |
| `pop_01897` | Nox Dominion Demon Knight Albino | [[Regions/Nox Dominion\|Nox Dominion]] | Albino | A+ | 159 | 2.5 m | Day & Night | Like a typical Demon Knight, but a rare pale form with white skin or fur and red eyes. |
| `pop_01898` | Aurumdeep Demon Knight Scarred | [[Regions/Aurumdeep\|Aurumdeep]] | Scarred | A+ | 159 | 2.75 m | Day & Night | Like a typical Demon Knight, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_01899` | Great Labyrinth (Floors 41-90) Demon Knight Scarred | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Scarred | A+ | 159 | 2.75 m | Day & Night | Like a typical Demon Knight, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_01900` | Nox Dominion Demon Knight Runt | [[Regions/Nox Dominion\|Nox Dominion]] | Runt | B+ | 120 | 1.75 m | Day & Night | Like a typical Demon Knight, but smaller and scrappier than usual, with red-black coloring with faint ember veins. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `demon_hide_emissive` · VFX `shadow_wisps` · palette `#634470` `#453551` `#9a86d8` · triangle-based silhouette, sharp asymmetric spikes
