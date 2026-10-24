---
type: monster
id: mon_kijin_warrior
family: "Goblinoids"
rank: "A"
tier: core
tags: [monster, goblinoids]
---
# Kijin Warrior

![[mon_kijin_warrior_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_kijin_warrior_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,606 tris · 1.301 × 2.141 × 2.4 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Kijin Warrior is a person-sized creature with a broad-shouldered humanoid build, about 2.4 m tall. Its skin is rough, scarred and spiked, colored in ember reds fading to soot black. Survivors describe twin horns, a disciplined stance and a lacquered blade. It has narrow glowing eyes. An elegant crest and glowing veins of mana mark it as a champion of its kind. It charges without hesitation, surrounded by heat-shimmer and drifting sparks.

| Field | Value |
|---|---|
| Family · type | [[Families/Goblinoids|Goblinoids]] · Humanoid |
| Rank · level | A · 146 (132–159) |
| Menace | 3 · Menacing |
| Element · weakness | Fire · Water |
| Size | 2.4 m |
| Behaviour | Pack (pack_flank) |
| HP · ATK · DEF · MATK · MDEF · SPD | 23570 · 713 · 594 · 475 · 535 · 100 |
| XP · gold | 8719 · 1611 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Iron Hold\|Iron Hold]], [[Regions/Moraveil\|Moraveil]], [[Regions/Zarvan\|Zarvan]], [[Regions/Dragon Spine\|Dragon Spine]], [[Regions/Zaruma\|Zaruma]] |
| Genre | Dark Fantasy |
| Trope | Goblins as horror in numbers (Goblin Slayer); hobgoblin → champion → king evolution |

**Field note:** Weak to Water. Never alone. Kill the leader first and the rest may scatter.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 2.4 m high × 0.72 m long × 0.77 m wide; prefab scale 1.333.
- **Physics:** 179.7 kg, gravity ×1.5, poise 101, knockback resistance 0.45, death style `ragdoll`.
- **Navigation:** speed 6.28 m/s, turn 258°/s, stopping distance 0.81 m.
- **Attack count:** 5; **signature:** twin horns, a disciplined stance and a lacquered blade.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Sand Toss\|Sand Toss]] | debuff | 0 | 12 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Ember Burst\|Ember Burst]] | magic | 1.5 | 10 s | Fire | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Kijin Warrior is a **menacing humanoid** encountered at A rank, around level 146. Its documented behaviour is *Pack* and its AI pattern is *pack_flank*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Water**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** twin horns, a disciplined stance and a lacquered blade. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Iron Hold|Iron Hold]], [[Regions/Moraveil|Moraveil]], [[Regions/Zarvan|Zarvan]], [[Regions/Dragon Spine|Dragon Spine]], [[Regions/Zaruma|Zaruma]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Goblinoids A|loot_goblinoid_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Goblin Ear\|Goblin Ear]] | 60% | 1–3 |
| [[Items/Crude Blade\|Crude Blade]] | 30% | 1–1 |
| [[Items/Stolen Trinket\|Stolen Trinket]] | 15% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Goblinoids/Elite Kijin Warrior|Elite Kijin Warrior]]
- [[Monsters/Goblinoids/Briar Kijin Warrior|Briar Kijin Warrior]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Iron Hold\|Iron Hold]] | 3 | A, S, B+ | 120–188 | Day & Night |
| [[Regions/Zaruma\|Zaruma]] | 3 | A+, A | 146–159 | Day & Night |
| [[Regions/Zarvan\|Zarvan]] | 2 | B+, A+ | 120–159 | Day & Night |
| [[Regions/Moraveil\|Moraveil]] | 2 | A+, A- | 132–159 | Day & Night |
| [[Regions/Dragon Spine\|Dragon Spine]] | 1 | A+ | 159–159 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00266` | Iron Hold Kijin Warrior | [[Regions/Iron Hold\|Iron Hold]] | Adult | A | 146 | 2.4 m | Day & Night | A typical adult Kijin Warrior of this region, with slate-grey coloring and hardened hide. |
| `pop_00267` | Zaruma Kijin Warrior Scarred | [[Regions/Zaruma\|Zaruma]] | Scarred | A+ | 159 | 2.64 m | Day & Night | Like a typical Kijin Warrior, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_00268` | Iron Hold Kijin Warrior Elderborn | [[Regions/Iron Hold\|Iron Hold]] | Elderborn | S | 188 | 3.24 m | Day & Night | Like a typical Kijin Warrior, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_00269` | Zarvan Kijin Warrior Runt | [[Regions/Zarvan\|Zarvan]] | Runt | B+ | 120 | 1.68 m | Day & Night | Like a typical Kijin Warrior, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_00270` | Moraveil Kijin Warrior Albino | [[Regions/Moraveil\|Moraveil]] | Albino | A+ | 159 | 2.4 m | Day & Night | Like a typical Kijin Warrior, but a rare pale form with white skin or fur and red eyes. |
| `pop_00271` | Zaruma Kijin Warrior Albino | [[Regions/Zaruma\|Zaruma]] | Albino | A+ | 159 | 2.4 m | Day & Night | Like a typical Kijin Warrior, but a rare pale form with white skin or fur and red eyes. |
| `pop_00272` | Moraveil Kijin Warrior Juvenile | [[Regions/Moraveil\|Moraveil]] | Juvenile | A- | 132 | 2.04 m | Day & Night | Like a typical Kijin Warrior, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_00273` | Zaruma Kijin Warrior | [[Regions/Zaruma\|Zaruma]] | Adult | A | 146 | 2.4 m | Day & Night | A typical adult Kijin Warrior of this region, with golden, grass-toned coloring. |
| `pop_00274` | Zarvan Kijin Warrior Scarred | [[Regions/Zarvan\|Zarvan]] | Scarred | A+ | 159 | 2.64 m | Day & Night | Like a typical Kijin Warrior, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_00275` | Dragon Spine Kijin Warrior Scarred | [[Regions/Dragon Spine\|Dragon Spine]] | Scarred | A+ | 159 | 2.64 m | Day & Night | Like a typical Kijin Warrior, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_00276` | Iron Hold Kijin Warrior Runt | [[Regions/Iron Hold\|Iron Hold]] | Runt | B+ | 120 | 1.68 m | Day & Night | Like a typical Kijin Warrior, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `rough_skin_leather` · VFX `embers_heat_haze` · palette `#e2502b` `#ffb347` `#3a1a12` · triangle-based silhouette, sharp asymmetric spikes
