---
type: monster
id: mon_elder_greater_demon
family: "Demons"
rank: "A"
tier: variant
tags: [monster, demons]
---
# Elder Greater Demon

![[mon_elder_greater_demon_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_elder_greater_demon_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,570 tris · 3.299 × 5.43 × 5.6 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Elder Greater Demon is a huge creature with an upright humanoid build, about 5.6 m tall. Its hide is rough, scarred and spiked, colored in ink black with bruised violet. Survivors describe a noble's coat and a crown of horns. It has narrow glowing eyes. An elegant crest and glowing veins of mana mark it as a champion of its kind. It strides with heavy steps, surrounded by shadows that lean toward it. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Demons|Demons]] · Demon |
| Variant of | [[Monsters/Demons/Greater Demon\|Greater Demon]] (elder) |
| Rank · level | A · 146 (132–159) |
| Menace | 3 · Menacing |
| Element · weakness | Dark · Light |
| Size | 5.6 m |
| Behaviour | Guardian (guardian_hold) |
| HP · ATK · DEF · MATK · MDEF · SPD | 31119 · 713 · 594 · 475 · 535 · 100 |
| XP · gold | 8719 · 1611 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Nox Dominion\|Nox Dominion]], [[Regions/Sunscar\|Sunscar]], [[Regions/Iron Hold\|Iron Hold]] |
| Genre | Abyssal |
| Trope | Demons as a people of the Abyss, not just evil (Frieren, Maoyuu) |

**Field note:** Weak to Light. Protects something nearby: a nest, a treasure, or a place.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 5.6 m high × 1.68 m long × 1.79 m wide; prefab scale 3.111.
- **Physics:** 2283 kg, gravity ×1.5, poise 154, knockback resistance 0.45, death style `ragdoll`.
- **Navigation:** speed 8.22 m/s, turn 169°/s, stopping distance 1.35 m.
- **Attack count:** 5; **signature:** a noble's coat and a crown of horns.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Hellfire Brand\|Hellfire Brand]] | magic | 1.4 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Elder Greater Demon is a **menacing demon** encountered at A rank, around level 146. Its documented behaviour is *Guardian* and its AI pattern is *guardian_hold*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a noble's coat and a crown of horns. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Nox Dominion|Nox Dominion]], [[Regions/Sunscar|Sunscar]], [[Regions/Iron Hold|Iron Hold]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Demons A|loot_demon_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Demon Core\|Demon Core]] | 60% | 1–3 |
| [[Items/Horn Shard\|Horn Shard]] | 30% | 1–1 |
| [[Items/Brimstone\|Brimstone]] | 15% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Sunscar\|Sunscar]] | 2 | S-, S | 173–188 | Day & Night |
| [[Regions/Iron Hold\|Iron Hold]] | 4 | A, B+, A+ | 120–159 | Day & Night |
| [[Regions/Nox Dominion\|Nox Dominion]] | 5 | S, A, B+, A+, S- | 120–188 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04744` | Sunscar Elder Greater Demon Alpha | [[Regions/Sunscar\|Sunscar]] | Alpha | S- | 173 | 7 m | Day & Night | Like a typical Elder Greater Demon, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_04745` | Iron Hold Elder Greater Demon | [[Regions/Iron Hold\|Iron Hold]] | Adult | A | 146 | 5.6 m | Day & Night | A typical adult Elder Greater Demon of this region, with ash-dark coloring with glowing cracks. |
| `pop_04746` | Nox Dominion Elder Greater Demon Elderborn | [[Regions/Nox Dominion\|Nox Dominion]] | Elderborn | S | 188 | 7.56 m | Day & Night | Like a typical Elder Greater Demon, but old and wise, with greying features and a cautious hunting style, with red-black coloring with faint ember veins. |
| `pop_04747` | Nox Dominion Elder Greater Demon | [[Regions/Nox Dominion\|Nox Dominion]] | Adult | A | 146 | 5.6 m | Day & Night | A typical adult Elder Greater Demon of this region, with red-black coloring with faint ember veins. |
| `pop_04748` | Nox Dominion Elder Greater Demon Runt | [[Regions/Nox Dominion\|Nox Dominion]] | Runt | B+ | 120 | 3.92 m | Day & Night | Like a typical Elder Greater Demon, but smaller and scrappier than usual, with red-black coloring with faint ember veins. |
| `pop_04749` | Iron Hold Elder Greater Demon Runt | [[Regions/Iron Hold\|Iron Hold]] | Runt | B+ | 120 | 3.92 m | Day & Night | Like a typical Elder Greater Demon, but smaller and scrappier than usual, with ash-dark coloring with glowing cracks. |
| `pop_04750` | Nox Dominion Elder Greater Demon Scarred | [[Regions/Nox Dominion\|Nox Dominion]] | Scarred | A+ | 159 | 6.16 m | Day & Night | Like a typical Elder Greater Demon, but covered in old battle scars, with red-black coloring with faint ember veins. |
| `pop_04751` | Iron Hold Elder Greater Demon Scarred | [[Regions/Iron Hold\|Iron Hold]] | Scarred | A+ | 159 | 6.16 m | Day & Night | Like a typical Elder Greater Demon, but covered in old battle scars, with ash-dark coloring with glowing cracks. |
| `pop_04752` | Nox Dominion Elder Greater Demon Alpha | [[Regions/Nox Dominion\|Nox Dominion]] | Alpha | S- | 173 | 7 m | Day & Night | Like a typical Elder Greater Demon, but larger and scarred, and others of its kind follow it, with red-black coloring with faint ember veins. |
| `pop_04753` | Iron Hold Elder Greater Demon Albino | [[Regions/Iron Hold\|Iron Hold]] | Albino | A+ | 159 | 5.6 m | Day & Night | Like a typical Elder Greater Demon, but a rare pale form with white skin or fur and red eyes. |
| `pop_04754` | Sunscar Elder Greater Demon Elderborn | [[Regions/Sunscar\|Sunscar]] | Elderborn | S | 188 | 7.56 m | Day & Night | Like a typical Elder Greater Demon, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `demon_hide_emissive` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · triangle-based silhouette, sharp asymmetric spikes
