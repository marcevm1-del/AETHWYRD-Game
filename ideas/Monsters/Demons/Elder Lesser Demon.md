---
type: monster
id: mon_elder_lesser_demon
family: "Demons"
rank: "B"
tier: variant
tags: [monster, demons]
---
# Elder Lesser Demon

![[mon_elder_lesser_demon_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_elder_lesser_demon_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (3,120 tris · 1.897 × 1.315 × 3.5 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Elder Lesser Demon is a large creature with a lean humanoid frame, about 3.5 m tall. Its hide is rough, scarred and spiked, colored in brimstone red, with violet markings. Look for curled horns and a leathery hide. It has eyes that catch torchlight like coins. Faint runes glow along its body when it fights. It charges without hesitation, surrounded by shadows that lean toward it. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Demons|Demons]] · Demon |
| Variant of | [[Monsters/Demons/Lesser Demon\|Lesser Demon]] (elder) |
| Rank · level | B · 108 (96–120) |
| Menace | 3 · Menacing |
| Element · weakness | Dark · Light |
| Size | 3.5 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 17062 · 530 · 442 · 354 · 398 · 100 |
| XP · gold | 5386 · 1057 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Strife Marches\|Strife Marches]], [[Regions/Cinderhole\|Cinderhole]], [[Regions/Lumbaya\|Lumbaya]] |
| Genre | Abyssal |
| Trope | Demons as a people of the Abyss, not just evil (Frieren, Maoyuu) |

**Field note:** Weak to Light. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 3.5 m high × 1.05 m long × 1.12 m wide; prefab scale 1.944.
- **Physics:** 557.4 kg, gravity ×1.5, poise 112, knockback resistance 0.42, death style `ragdoll`.
- **Navigation:** speed 7.95 m/s, turn 214°/s, stopping distance 1 m.
- **Attack count:** 5; **signature:** curled horns and a leathery hide.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Hellfire Brand\|Hellfire Brand]] | magic | 1.4 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Elder Lesser Demon is a **menacing demon** encountered at B rank, around level 108. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** curled horns and a leathery hide. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Strife Marches|Strife Marches]], [[Regions/Cinderhole|Cinderhole]], [[Regions/Lumbaya|Lumbaya]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Demons B|loot_demon_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Demon Core\|Demon Core]] | 60% | 1–3 |
| [[Items/Horn Shard\|Horn Shard]] | 30% | 1–1 |
| [[Items/Brimstone\|Brimstone]] | 15% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Strife Marches\|Strife Marches]] | 3 | B, A-, C+ | 86–132 | Day & Night |
| [[Regions/Cinderhole\|Cinderhole]] | 4 | B, B+, A | 108–146 | Day & Night |
| [[Regions/Lumbaya\|Lumbaya]] | 4 | A-, B+, A | 120–146 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04711` | Strife Marches Elder Lesser Demon | [[Regions/Strife Marches\|Strife Marches]] | Adult | B | 108 | 3.5 m | Day & Night | A typical adult Elder Lesser Demon of this region, with dust-grey coloring and old rune scars. |
| `pop_04712` | Cinderhole Elder Lesser Demon | [[Regions/Cinderhole\|Cinderhole]] | Adult | B | 108 | 3.5 m | Day & Night | A typical adult Elder Lesser Demon of this region, with soot-stained hide and scavenged scraps. |
| `pop_04713` | Strife Marches Elder Lesser Demon Alpha | [[Regions/Strife Marches\|Strife Marches]] | Alpha | A- | 132 | 4.38 m | Day & Night | Like a typical Elder Lesser Demon, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_04714` | Lumbaya Elder Lesser Demon Alpha | [[Regions/Lumbaya\|Lumbaya]] | Alpha | A- | 132 | 4.38 m | Day & Night | Like a typical Elder Lesser Demon, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_04715` | Lumbaya Elder Lesser Demon Scarred | [[Regions/Lumbaya\|Lumbaya]] | Scarred | B+ | 120 | 3.85 m | Day & Night | Like a typical Elder Lesser Demon, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_04716` | Lumbaya Elder Lesser Demon Elderborn | [[Regions/Lumbaya\|Lumbaya]] | Elderborn | A | 146 | 4.73 m | Day & Night | Like a typical Elder Lesser Demon, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_04717` | Strife Marches Elder Lesser Demon Runt | [[Regions/Strife Marches\|Strife Marches]] | Runt | C+ | 86 | 2.45 m | Day & Night | Like a typical Elder Lesser Demon, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_04718` | Cinderhole Elder Lesser Demon Scarred | [[Regions/Cinderhole\|Cinderhole]] | Scarred | B+ | 120 | 3.85 m | Day & Night | Like a typical Elder Lesser Demon, but covered in old battle scars, with soot-stained hide and scavenged scraps. |
| `pop_04719` | Cinderhole Elder Lesser Demon Albino | [[Regions/Cinderhole\|Cinderhole]] | Albino | B+ | 120 | 3.5 m | Day & Night | Like a typical Elder Lesser Demon, but a rare pale form with white skin or fur and red eyes. |
| `pop_04720` | Lumbaya Elder Lesser Demon Albino | [[Regions/Lumbaya\|Lumbaya]] | Albino | B+ | 120 | 3.5 m | Day & Night | Like a typical Elder Lesser Demon, but a rare pale form with white skin or fur and red eyes. |
| `pop_04721` | Cinderhole Elder Lesser Demon Elderborn | [[Regions/Cinderhole\|Cinderhole]] | Elderborn | A | 146 | 4.73 m | Day & Night | Like a typical Elder Lesser Demon, but old and wise, with greying features and a cautious hunting style, with soot-stained hide and scavenged scraps. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `demon_hide_emissive` · VFX `shadow_wisps` · palette `#ac2c34` `#60292e` `#9a86d8` · triangle-based silhouette, sharp asymmetric spikes
