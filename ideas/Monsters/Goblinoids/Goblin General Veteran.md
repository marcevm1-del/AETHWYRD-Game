---
type: monster
id: mon_goblin_general_veteran
family: "Goblinoids"
rank: "B"
tier: variant
tags: [monster, goblinoids]
---
# Goblin General Veteran

![[mon_goblin_general_veteran_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_goblin_general_veteran_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (3,172 tris · 2.062 × 2.608 × 3.5 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Goblin General Veteran is a large creature with a lean humanoid frame, about 3.5 m tall. Its skin is rough, scarred and spiked, colored in grey-green and patched leather. Its most striking feature is a war banner and a horn carved from an ogre's tusk. It has narrow glowing eyes. Faint runes glow along its body when it fights. It charges without hesitation. It has no visible aura; you hear its breathing before you see it. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Goblinoids|Goblinoids]] · Humanoid |
| Variant of | [[Monsters/Goblinoids/Goblin General\|Goblin General]] (elder) |
| Rank · level | B · 108 (96–120) |
| Menace | 3 · Menacing |
| Element · weakness | None · Fire |
| Size | 3.5 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 17062 · 530 · 442 · 248 · 398 · 100 |
| XP · gold | 5386 · 1057 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Moraveil\|Moraveil]], [[Regions/Strife Marches\|Strife Marches]] |
| Genre | Dark Fantasy |
| Trope | Goblins as horror in numbers (Goblin Slayer); hobgoblin → champion → king evolution |

**Field note:** Weak to Fire. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 3.5 m high × 1.05 m long × 1.12 m wide; prefab scale 1.944.
- **Physics:** 557.4 kg, gravity ×1.5, poise 112, knockback resistance 0.42, death style `ragdoll`.
- **Navigation:** speed 7.57 m/s, turn 214°/s, stopping distance 1 m.
- **Attack count:** 4; **signature:** a war banner and a horn carved from an ogre's tusk.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Sand Toss\|Sand Toss]] | debuff | 0 | 12 s | None | none | Keep moving and read the animation; do not assume a safe block. |

## Field guide

Goblin General Veteran is a **menacing humanoid** encountered at B rank, around level 108. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a war banner and a horn carved from an ogre's tusk. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Moraveil|Moraveil]], [[Regions/Strife Marches|Strife Marches]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Goblinoids B|loot_goblinoid_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Goblin Ear\|Goblin Ear]] | 60% | 1–3 |
| [[Items/Crude Blade\|Crude Blade]] | 30% | 1–1 |
| [[Items/Stolen Trinket\|Stolen Trinket]] | 15% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Strife Marches\|Strife Marches]] | 5 | B+, B, C+, A, A- | 86–146 | Day & Night |
| [[Regions/Moraveil\|Moraveil]] | 6 | B+, C+, A-, B-, B | 86–132 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05989` | Strife Marches Goblin General Veteran Albino | [[Regions/Strife Marches\|Strife Marches]] | Albino | B+ | 120 | 3.5 m | Day & Night | Like a typical Goblin General Veteran, but a rare pale form with white skin or fur and red eyes. |
| `pop_05990` | Strife Marches Goblin General Veteran | [[Regions/Strife Marches\|Strife Marches]] | Adult | B | 108 | 3.5 m | Day & Night | A typical adult Goblin General Veteran of this region, with golden, grass-toned coloring. |
| `pop_05991` | Moraveil Goblin General Veteran Albino | [[Regions/Moraveil\|Moraveil]] | Albino | B+ | 120 | 3.5 m | Day & Night | Like a typical Goblin General Veteran, but a rare pale form with white skin or fur and red eyes. |
| `pop_05992` | Moraveil Goblin General Veteran Runt | [[Regions/Moraveil\|Moraveil]] | Runt | C+ | 86 | 2.45 m | Day & Night | Like a typical Goblin General Veteran, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_05993` | Strife Marches Goblin General Veteran Runt | [[Regions/Strife Marches\|Strife Marches]] | Runt | C+ | 86 | 2.45 m | Day & Night | Like a typical Goblin General Veteran, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_05994` | Strife Marches Goblin General Veteran Elderborn | [[Regions/Strife Marches\|Strife Marches]] | Elderborn | A | 146 | 4.73 m | Day & Night | Like a typical Goblin General Veteran, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_05995` | Moraveil Goblin General Veteran Alpha | [[Regions/Moraveil\|Moraveil]] | Alpha | A- | 132 | 4.38 m | Day & Night | Like a typical Goblin General Veteran, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_05996` | Strife Marches Goblin General Veteran Alpha | [[Regions/Strife Marches\|Strife Marches]] | Alpha | A- | 132 | 4.38 m | Day & Night | Like a typical Goblin General Veteran, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_05997` | Moraveil Goblin General Veteran Juvenile | [[Regions/Moraveil\|Moraveil]] | Juvenile | B- | 96 | 2.98 m | Day & Night | Like a typical Goblin General Veteran, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_05998` | Moraveil Goblin General Veteran Scarred | [[Regions/Moraveil\|Moraveil]] | Scarred | B+ | 120 | 3.85 m | Day & Night | Like a typical Goblin General Veteran, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_05999` | Moraveil Goblin General Veteran | [[Regions/Moraveil\|Moraveil]] | Adult | B | 108 | 3.5 m | Day & Night | A typical adult Goblin General Veteran of this region, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `rough_skin_leather` · VFX `dust_puffs` · palette `#6e8663` `#54482f` `#b5cf9a` · triangle-based silhouette, sharp asymmetric spikes
