---
type: monster
id: mon_greater_demon
family: "Demons"
rank: "B"
tier: core
tags: [monster, demons]
---
# Greater Demon

![[mon_greater_demon_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_greater_demon_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Greater Demon is a large creature with a lean humanoid frame, about 3.5 m tall. Its hide is rough, scarred and spiked, colored in ink black with bruised violet. Its most striking feature is a noble's coat and a crown of horns. It has burning slit pupils. Faint runes glow along its body when it fights. It circles its prey, surrounded by shadows that lean toward it.

| Field | Value |
|---|---|
| Family · type | [[Families/Demons|Demons]] · Demon |
| Rank · level | B · 108 (96–120) |
| Menace | 3 · Menacing |
| Element · weakness | Dark · Light |
| Size | 3.5 m |
| Behaviour | Guardian (guardian_hold) |
| HP · ATK · DEF · MATK · MDEF · SPD | 17062 · 530 · 442 · 354 · 398 · 100 |
| XP · gold | 5386 · 1057 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Lumbaya\|Lumbaya]], [[Regions/Sunscar\|Sunscar]], [[Regions/Cinderhole\|Cinderhole]], [[Regions/Aurumdeep\|Aurumdeep]], [[Regions/Strife Marches\|Strife Marches]] |
| Genre | Abyssal |
| Trope | Demons as a people of the Abyss, not just evil (Frieren, Maoyuu) |

**Field note:** Weak to Light. Protects something nearby: a nest, a treasure, or a place.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 3.5 m high × 1.05 m long × 1.12 m wide; prefab scale 1.944.
- **Physics:** 557.4 kg, gravity ×1.5, poise 112, knockback resistance 0.42, death style `ragdoll`.
- **Navigation:** speed 6.5 m/s, turn 214°/s, stopping distance 1 m.
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

Greater Demon is a **menacing demon** encountered at B rank, around level 108. Its documented behaviour is *Guardian* and its AI pattern is *guardian_hold*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a noble's coat and a crown of horns. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Lumbaya|Lumbaya]], [[Regions/Sunscar|Sunscar]], [[Regions/Cinderhole|Cinderhole]], [[Regions/Aurumdeep|Aurumdeep]], [[Regions/Strife Marches|Strife Marches]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Demons B|loot_demon_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Demon Core\|Demon Core]] | 60% | 1–3 |
| [[Items/Horn Shard\|Horn Shard]] | 30% | 1–1 |
| [[Items/Brimstone\|Brimstone]] | 15% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Demons/Elder Greater Demon|Elder Greater Demon]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Strife Marches\|Strife Marches]] | 3 | C+, B, A | 86–146 | Day & Night |
| [[Regions/Cinderhole\|Cinderhole]] | 2 | B-, B+ | 96–120 | Day & Night |
| [[Regions/Sunscar\|Sunscar]] | 3 | B+, B, C+ | 86–120 | Day & Night |
| [[Regions/Lumbaya\|Lumbaya]] | 2 | B+, C+ | 86–120 | Day & Night |
| [[Regions/Aurumdeep\|Aurumdeep]] | 1 | A- | 132–132 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01868` | Strife Marches Greater Demon Runt | [[Regions/Strife Marches\|Strife Marches]] | Runt | C+ | 86 | 2.45 m | Day & Night | Like a typical Greater Demon, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_01869` | Strife Marches Greater Demon | [[Regions/Strife Marches\|Strife Marches]] | Adult | B | 108 | 3.5 m | Day & Night | A typical adult Greater Demon of this region, with dust-grey coloring and old rune scars. |
| `pop_01870` | Strife Marches Greater Demon Elderborn | [[Regions/Strife Marches\|Strife Marches]] | Elderborn | A | 146 | 4.73 m | Day & Night | Like a typical Greater Demon, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_01871` | Cinderhole Greater Demon Juvenile | [[Regions/Cinderhole\|Cinderhole]] | Juvenile | B- | 96 | 2.98 m | Day & Night | Like a typical Greater Demon, but young, with brighter colors and unworn features, with soot-stained hide and scavenged scraps. |
| `pop_01872` | Cinderhole Greater Demon Albino | [[Regions/Cinderhole\|Cinderhole]] | Albino | B+ | 120 | 3.5 m | Day & Night | Like a typical Greater Demon, but a rare pale form with white skin or fur and red eyes. |
| `pop_01873` | Sunscar Greater Demon Scarred | [[Regions/Sunscar\|Sunscar]] | Scarred | B+ | 120 | 3.85 m | Day & Night | Like a typical Greater Demon, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_01874` | Sunscar Greater Demon | [[Regions/Sunscar\|Sunscar]] | Adult | B | 108 | 3.5 m | Day & Night | A typical adult Greater Demon of this region, with dust-grey coloring and old rune scars. |
| `pop_01875` | Sunscar Greater Demon Runt | [[Regions/Sunscar\|Sunscar]] | Runt | C+ | 86 | 2.45 m | Day & Night | Like a typical Greater Demon, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_01876` | Lumbaya Greater Demon Scarred | [[Regions/Lumbaya\|Lumbaya]] | Scarred | B+ | 120 | 3.85 m | Day & Night | Like a typical Greater Demon, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_01877` | Aurumdeep Greater Demon Alpha | [[Regions/Aurumdeep\|Aurumdeep]] | Alpha | A- | 132 | 4.38 m | Day & Night | Like a typical Greater Demon, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_01878` | Lumbaya Greater Demon Runt | [[Regions/Lumbaya\|Lumbaya]] | Runt | C+ | 86 | 2.45 m | Day & Night | Like a typical Greater Demon, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `demon_hide_emissive` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · triangle-based silhouette, sharp asymmetric spikes
