---
type: monster
id: mon_phantom_death_knight
family: "Undead"
rank: "B+"
tier: variant
tags: [monster, undead]
---
# Phantom Death Knight

![[mon_phantom_death_knight_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_phantom_death_knight_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,550 tris · 1.002 × 1.842 × 2.4 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Phantom Death Knight is a person-sized creature with an upright humanoid build, about 2.4 m tall. Its flesh and bone are patchy and subtly wrong, as if assembled from memory, colored in warm gold and pearl white. Its most striking feature is black plate, a cloak of ash and a sword of cold fire. It has eyes set slightly too far apart. Faint runes glow along its body when it fights. It freezes whenever it is looked at, surrounded by soft radiance and floating motes of light. Its body is translucent blue, half in the spirit world; weapons pass through it unless they are blessed or enchanted.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Variant of | [[Monsters/Undead/Death Knight\|Death Knight]] (spirit) |
| Rank · level | B+ · 120 (108–132) |
| Menace | 4 · Dread |
| Element · weakness | Light · Dark |
| Size | 2.4 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 17586 · 588 · 490 · 392 · 441 · 100 |
| XP · gold | 6373 · 1225 |
| Ring | 7 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Sunscar\|Sunscar]], [[Regions/Zarvan\|Zarvan]], [[Regions/Zaruma\|Zaruma]] |
| Genre | Gothic Horror |
| Trope | Graveyard night threats; the lich and its phylactery; the vampire noble |

**Field note:** Weak to Dark. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 2.4 m high × 0.72 m long × 0.77 m wide; prefab scale 1.333.
- **Physics:** 170.7 kg, gravity ×1.35, poise 92, knockback resistance 0.42, death style `ragdoll`.
- **Navigation:** speed 5.97 m/s, turn 258°/s, stopping distance 0.81 m.
- **Attack count:** 5; **signature:** black plate, a cloak of ash and a sword of cold fire.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Grave Grasp\|Grave Grasp]] | grab | 1.2 | 10 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Radiant Pulse\|Radiant Pulse]] | magic | 1.5 | 10 s | Light | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Phantom Death Knight is a **dread undead** encountered at B+ rank, around level 120. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Dark**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** black plate, a cloak of ash and a sword of cold fire. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Sunscar|Sunscar]], [[Regions/Zarvan|Zarvan]], [[Regions/Zaruma|Zaruma]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Undead B|loot_undead_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Bone Dust\|Bone Dust]] | 60% | 1–3 |
| [[Items/Grave Cloth\|Grave Cloth]] | 30% | 1–1 |
| [[Items/Soul Ember\|Soul Ember]] | 15% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Zaruma\|Zaruma]] | 4 | B+, B, A, A- | 108–146 | Night |
| [[Regions/Zarvan\|Zarvan]] | 3 | B+, A+, B- | 96–159 | Night |
| [[Regions/Sunscar\|Sunscar]] | 4 | A-, B+, A, B- | 96–146 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06660` | Zaruma Phantom Death Knight | [[Regions/Zaruma\|Zaruma]] | Adult | B+ | 120 | 2.4 m | Night | A typical adult Phantom Death Knight of this region, with sun-bleached, sand-scoured coloring. |
| `pop_06661` | Zaruma Phantom Death Knight Juvenile | [[Regions/Zaruma\|Zaruma]] | Juvenile | B | 108 | 2.04 m | Night | Like a typical Phantom Death Knight, but young, with brighter colors and unworn features, with sun-bleached, sand-scoured coloring. |
| `pop_06662` | Zarvan Phantom Death Knight | [[Regions/Zarvan\|Zarvan]] | Adult | B+ | 120 | 2.4 m | Night | A typical adult Phantom Death Knight of this region, with sun-bleached, sand-scoured coloring. |
| `pop_06663` | Sunscar Phantom Death Knight Albino | [[Regions/Sunscar\|Sunscar]] | Albino | A- | 132 | 2.4 m | Night | Like a typical Phantom Death Knight, but a rare pale form with white skin or fur and red eyes. |
| `pop_06664` | Sunscar Phantom Death Knight | [[Regions/Sunscar\|Sunscar]] | Adult | B+ | 120 | 2.4 m | Night | A typical adult Phantom Death Knight of this region, with sun-bleached, sand-scoured coloring. |
| `pop_06665` | Sunscar Phantom Death Knight Alpha | [[Regions/Sunscar\|Sunscar]] | Alpha | A | 146 | 3 m | Night | Like a typical Phantom Death Knight, but larger and scarred, and others of its kind follow it, with sun-bleached, sand-scoured coloring. |
| `pop_06666` | Zaruma Phantom Death Knight Alpha | [[Regions/Zaruma\|Zaruma]] | Alpha | A | 146 | 3 m | Night | Like a typical Phantom Death Knight, but larger and scarred, and others of its kind follow it, with sun-bleached, sand-scoured coloring. |
| `pop_06667` | Zarvan Phantom Death Knight Elderborn | [[Regions/Zarvan\|Zarvan]] | Elderborn | A+ | 159 | 3.24 m | Night | Like a typical Phantom Death Knight, but old and wise, with greying features and a cautious hunting style, with sun-bleached, sand-scoured coloring. |
| `pop_06668` | Sunscar Phantom Death Knight Runt | [[Regions/Sunscar\|Sunscar]] | Runt | B- | 96 | 1.68 m | Night | Like a typical Phantom Death Knight, but smaller and scrappier than usual, with sun-bleached, sand-scoured coloring. |
| `pop_06669` | Zaruma Phantom Death Knight Scarred | [[Regions/Zaruma\|Zaruma]] | Scarred | A- | 132 | 2.64 m | Night | Like a typical Phantom Death Knight, but covered in old battle scars, with sun-bleached, sand-scoured coloring. |
| `pop_06670` | Zarvan Phantom Death Knight Runt | [[Regions/Zarvan\|Zarvan]] | Runt | B- | 96 | 1.68 m | Night | Like a typical Phantom Death Knight, but smaller and scrappier than usual, with sun-bleached, sand-scoured coloring. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `rot_bone` · VFX `holy_motes` · palette `#fff3b0` `#ffd166` `#ffffff` · elongated, irregular silhouette; still-then-sudden timing
