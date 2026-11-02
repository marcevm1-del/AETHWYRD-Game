---
type: monster
id: mon_grove_goblin
family: "Goblinoids"
rank: "F"
tier: variant
tags: [monster, goblinoids]
---
# Grove Goblin

![[mon_grove_goblin_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_grove_goblin_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,154 tris · 0.495 × 0.583 × 1 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Grove Goblin is a small creature with a small, compact humanoid body, about 1 m tall. Its skin is rough, scarred and spiked, colored in olive and hide brown, with leaf-green markings. Survivors describe a grin of needle teeth under a stolen tin helmet. It has narrow glowing eyes. It has no ornament at all: simple, readable shapes. It charges without hesitation, surrounded by drifting pollen and tiny blossoms. Adapted to forest lands, it has moss-green coloring that blends with the undergrowth.

| Field | Value |
|---|---|
| Family · type | [[Families/Goblinoids|Goblinoids]] · Humanoid |
| Variant of | [[Monsters/Goblinoids/Goblin\|Goblin]] (regional) |
| Rank · level | F · 8 (3–13) |
| Menace | 3 · Menacing |
| Element · weakness | Nature · Fire |
| Size | 1 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 224 · 42 · 34 · 29 · 34 · 135 |
| XP · gold | 92 · 31 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/small_biped\|small_biped]] · `anim_small_biped` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Dark Fantasy |
| Trope | Goblins as horror in numbers (Goblin Slayer); hobgoblin → champion → king evolution |

**Field note:** Weak to Fire. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/small_biped|small_biped]] (override (base species)); animation set `anim_small_biped`.
- **Dimensions:** 1 m high × 0.3 m long × 0.4 m wide; prefab scale 0.909.
- **Physics:** 16 kg, gravity ×1.5, poise 29, knockback resistance 0.15, death style `ragdoll_crumple`.
- **Navigation:** speed 5.32 m/s, turn 420°/s, stopping distance 0.6 m.
- **Attack count:** 5; **signature:** a grin of needle teeth under a stolen tin helmet.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stab\|Stab]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Thrown Junk\|Thrown Junk]] | ranged | 0.8 | 4 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Frenzied Lunge\|Frenzied Lunge]] | melee | 1.5 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Sand Toss\|Sand Toss]] | debuff | 0 | 12 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Thorn Volley\|Thorn Volley]] | magic | 1.5 | 10 s | Nature | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Grove Goblin is a **menacing humanoid** encountered at F rank, around level 8. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a grin of needle teeth under a stolen tin helmet. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Whisperwood|Whisperwood]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_small_biped`, animation set `anim_small_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Goblinoids F|loot_goblinoid_f]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Goblin Ear\|Goblin Ear]] | 60% | 1–3 |
| [[Items/Crude Blade\|Crude Blade]] | 30% | 1–1 |
| [[Items/Stolen Trinket\|Stolen Trinket]] | 15% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Aldmere\|Aldmere]] | 6 | F-, F+, E, E- | 3–26 | Day & Night |
| [[Regions/Whisperwood\|Whisperwood]] | 5 | F+, F-, E-, F | 3–19 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03060` | Aldmere Grove Goblin Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | F- | 3 | 0.85 m | Day & Night | Like a typical Grove Goblin, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_03061` | Whisperwood Grove Goblin Albino | [[Regions/Whisperwood\|Whisperwood]] | Albino | F+ | 13 | 1 m | Day & Night | Like a typical Grove Goblin, but a rare pale form with white skin or fur and red eyes. |
| `pop_03062` | Whisperwood Grove Goblin Runt | [[Regions/Whisperwood\|Whisperwood]] | Runt | F- | 3 | 0.7 m | Day & Night | Like a typical Grove Goblin, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_03063` | Aldmere Grove Goblin Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | F+ | 13 | 1.1 m | Day & Night | Like a typical Grove Goblin, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_03064` | Aldmere Grove Goblin Albino | [[Regions/Aldmere\|Aldmere]] | Albino | F+ | 13 | 1 m | Day & Night | Like a typical Grove Goblin, but a rare pale form with white skin or fur and red eyes. |
| `pop_03065` | Aldmere Grove Goblin Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | E | 26 | 1.35 m | Day & Night | Like a typical Grove Goblin, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_03066` | Aldmere Grove Goblin Runt | [[Regions/Aldmere\|Aldmere]] | Runt | F- | 3 | 0.7 m | Day & Night | Like a typical Grove Goblin, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_03067` | Whisperwood Grove Goblin Scarred | [[Regions/Whisperwood\|Whisperwood]] | Scarred | F+ | 13 | 1.1 m | Day & Night | Like a typical Grove Goblin, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_03068` | Aldmere Grove Goblin Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | E- | 19 | 1.25 m | Day & Night | Like a typical Grove Goblin, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_03069` | Whisperwood Grove Goblin Alpha | [[Regions/Whisperwood\|Whisperwood]] | Alpha | E- | 19 | 1.25 m | Day & Night | Like a typical Grove Goblin, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_03070` | Whisperwood Grove Goblin | [[Regions/Whisperwood\|Whisperwood]] | Adult | F | 8 | 1 m | Day & Night | A typical adult Grove Goblin of this region, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `rough_skin_leather` · VFX `pollen_petals` · palette `#838b44` `#603f2b` `#8fd16a` · triangle-based silhouette, sharp asymmetric spikes
