---
type: monster
id: mon_goblin_bomber
family: "Goblinoids"
rank: "D"
tier: core
tags: [monster, goblinoids]
---
# Goblin Bomber

![[mon_goblin_bomber_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_goblin_bomber_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,678 tris · 0.502 × 0.442 × 1 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Goblin Bomber is a small creature with a hunched, wiry humanoid frame, about 1 m tall. Its skin is rough, scarred and spiked, colored in ember reds fading to soot black. Its most striking feature is a barrel of black powder strapped to its back and a lit fuse in its teeth. It has burning slit pupils. A distinctive marking runs along its back. It charges without hesitation, surrounded by heat-shimmer and drifting sparks.

| Field | Value |
|---|---|
| Family · type | [[Families/Goblinoids|Goblinoids]] · Humanoid |
| Rank · level | D · 48 (40–56) |
| Menace | 3 · Menacing |
| Element · weakness | Fire · Water |
| Size | 1 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 2595 · 202 · 162 · 141 · 162 · 135 |
| XP · gold | 1477 · 342 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/small_biped\|small_biped]] · `anim_small_biped` |
| Habitats | [[Regions/Iron Hold\|Iron Hold]], [[Regions/Moraveil\|Moraveil]], [[Regions/Strife Marches\|Strife Marches]], [[Regions/Aldmere\|Aldmere]] |
| Genre | Dark Fantasy |
| Trope | Goblins as horror in numbers (Goblin Slayer); hobgoblin → champion → king evolution |

**Field note:** Weak to Water. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/small_biped|small_biped]] (rigId); animation set `anim_small_biped`.
- **Dimensions:** 1 m high × 0.3 m long × 0.4 m wide; prefab scale 0.909.
- **Physics:** 16 kg, gravity ×1.5, poise 37, knockback resistance 0.21, death style `ragdoll_crumple`.
- **Navigation:** speed 5.59 m/s, turn 420°/s, stopping distance 0.6 m.
- **Attack count:** 5; **signature:** a barrel of black powder strapped to its back and a lit fuse in its teeth.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stab\|Stab]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Thrown Junk\|Thrown Junk]] | ranged | 0.8 | 4 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Frenzied Lunge\|Frenzied Lunge]] | melee | 1.5 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Sand Toss\|Sand Toss]] | debuff | 0 | 12 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Ember Burst\|Ember Burst]] | magic | 1.5 | 10 s | Fire | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Goblin Bomber is a **menacing humanoid** encountered at D rank, around level 48. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Water**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a barrel of black powder strapped to its back and a lit fuse in its teeth. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Iron Hold|Iron Hold]], [[Regions/Moraveil|Moraveil]], [[Regions/Strife Marches|Strife Marches]], [[Regions/Aldmere|Aldmere]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_small_biped`, animation set `anim_small_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Goblinoids D|loot_goblinoid_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Goblin Ear\|Goblin Ear]] | 60% | 1–3 |
| [[Items/Crude Blade\|Crude Blade]] | 30% | 1–1 |
| [[Items/Stolen Trinket\|Stolen Trinket]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Goblinoids/Vesper-Touched Goblin Bomber|Vesper-Touched Goblin Bomber]]
- [[Monsters/Goblinoids/Ruin Goblin Bomber|Ruin Goblin Bomber]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Strife Marches\|Strife Marches]] | 4 | D+, C-, D, E+ | 32–65 | Day & Night |
| [[Regions/Aldmere\|Aldmere]] | 2 | D-, C- | 40–65 | Day & Night |
| [[Regions/Iron Hold\|Iron Hold]] | 3 | D-, D+, E+ | 32–56 | Day & Night |
| [[Regions/Moraveil\|Moraveil]] | 2 | E+, D+ | 32–56 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00211` | Strife Marches Goblin Bomber Scarred | [[Regions/Strife Marches\|Strife Marches]] | Scarred | D+ | 56 | 1.1 m | Day & Night | Like a typical Goblin Bomber, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_00212` | Aldmere Goblin Bomber Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | D- | 40 | 0.85 m | Day & Night | Like a typical Goblin Bomber, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_00213` | Iron Hold Goblin Bomber Juvenile | [[Regions/Iron Hold\|Iron Hold]] | Juvenile | D- | 40 | 0.85 m | Day & Night | Like a typical Goblin Bomber, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_00214` | Strife Marches Goblin Bomber Alpha | [[Regions/Strife Marches\|Strife Marches]] | Alpha | C- | 65 | 1.25 m | Day & Night | Like a typical Goblin Bomber, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_00215` | Strife Marches Goblin Bomber | [[Regions/Strife Marches\|Strife Marches]] | Adult | D | 48 | 1 m | Day & Night | A typical adult Goblin Bomber of this region, with golden, grass-toned coloring. |
| `pop_00216` | Iron Hold Goblin Bomber Scarred | [[Regions/Iron Hold\|Iron Hold]] | Scarred | D+ | 56 | 1.1 m | Day & Night | Like a typical Goblin Bomber, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_00217` | Moraveil Goblin Bomber Runt | [[Regions/Moraveil\|Moraveil]] | Runt | E+ | 32 | 0.7 m | Day & Night | Like a typical Goblin Bomber, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_00218` | Aldmere Goblin Bomber Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | C- | 65 | 1.25 m | Day & Night | Like a typical Goblin Bomber, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_00219` | Strife Marches Goblin Bomber Runt | [[Regions/Strife Marches\|Strife Marches]] | Runt | E+ | 32 | 0.7 m | Day & Night | Like a typical Goblin Bomber, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_00220` | Iron Hold Goblin Bomber Runt | [[Regions/Iron Hold\|Iron Hold]] | Runt | E+ | 32 | 0.7 m | Day & Night | Like a typical Goblin Bomber, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_00221` | Moraveil Goblin Bomber Scarred | [[Regions/Moraveil\|Moraveil]] | Scarred | D+ | 56 | 1.1 m | Day & Night | Like a typical Goblin Bomber, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `rough_skin_leather` · VFX `embers_heat_haze` · palette `#e2502b` `#ffb347` `#3a1a12` · triangle-based silhouette, sharp asymmetric spikes
