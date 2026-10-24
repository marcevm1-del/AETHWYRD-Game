---
type: monster
id: mon_zephyr_goblin_king
family: "Goblinoids"
rank: "B+"
tier: variant
tags: [monster, goblinoids]
---
# Zephyr Goblin King

![[mon_zephyr_goblin_king_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_zephyr_goblin_king_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Zephyr Goblin King is a large creature with a giant, barrel-chested humanoid body, about 2.8 m tall. Its skin is rough, scarred and spiked, colored in pale jade and cloud white. Survivors describe throne-backed armor and a crown of hammered coins. It has eyes that catch torchlight like coins. Faint runes glow along its body when it fights. It charges without hesitation, surrounded by swirling leaves and a constant breeze. This Wind-attuned variant carries one extra elemental feature, like a crest of elemental energy, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Goblinoids|Goblinoids]] · Humanoid |
| Variant of | [[Monsters/Goblinoids/Goblin King\|Goblin King]] (elemental) |
| Rank · level | B+ · 120 (108–132) |
| Menace | 3 · Menacing |
| Element · weakness | Wind · Fire |
| Size | 2.8 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 23584 · 490 · 735 · 294 · 490 · 70 |
| XP · gold | 6373 · 1225 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/large_biped\|large_biped]] · `anim_large_biped` |
| Habitats | [[Regions/Moraveil\|Moraveil]], [[Regions/Strife Marches\|Strife Marches]], [[Regions/Iron Hold\|Iron Hold]] |
| Genre | Dark Fantasy |
| Trope | Goblins as horror in numbers (Goblin Slayer); hobgoblin → champion → king evolution |

**Field note:** Weak to Fire. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/large_biped|large_biped]] (rigId); animation set `anim_large_biped`.
- **Dimensions:** 2.8 m high × 0.84 m long × 1.18 m wide; prefab scale 0.8.
- **Physics:** 355.6 kg, gravity ×1.04, poise 200, knockback resistance 0.87, death style `heavy_fall_dust`.
- **Navigation:** speed 6.68 m/s, turn 227°/s, stopping distance 0.96 m.
- **Attack count:** 5; **signature:** throne-backed armor and a crown of hammered coins.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stomp\|Stomp]] | aoe | 1.3 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Club Slam\|Club Slam]] | melee | 1.8 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Grab and Throw\|Grab and Throw]] | grab | 2 | 14 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Sand Toss\|Sand Toss]] | debuff | 0 | 12 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Gale Cutter\|Gale Cutter]] | magic | 1.5 | 10 s | Wind | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Zephyr Goblin King is a **menacing humanoid** encountered at B+ rank, around level 120. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** throne-backed armor and a crown of hammered coins. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Moraveil|Moraveil]], [[Regions/Strife Marches|Strife Marches]], [[Regions/Iron Hold|Iron Hold]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_large_biped`, animation set `anim_large_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

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
| [[Regions/Strife Marches\|Strife Marches]] | 5 | A, A+, A-, B+ | 120–159 | Day & Night |
| [[Regions/Iron Hold\|Iron Hold]] | 5 | B-, A+, A, B+, B | 96–159 | Day & Night |
| [[Regions/Moraveil\|Moraveil]] | 1 | A | 146–146 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03159` | Strife Marches Zephyr Goblin King Alpha | [[Regions/Strife Marches\|Strife Marches]] | Alpha | A | 146 | 3.5 m | Day & Night | Like a typical Zephyr Goblin King, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_03160` | Strife Marches Zephyr Goblin King Elderborn | [[Regions/Strife Marches\|Strife Marches]] | Elderborn | A+ | 159 | 3.78 m | Day & Night | Like a typical Zephyr Goblin King, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_03161` | Strife Marches Zephyr Goblin King Scarred | [[Regions/Strife Marches\|Strife Marches]] | Scarred | A- | 132 | 3.08 m | Day & Night | Like a typical Zephyr Goblin King, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_03162` | Iron Hold Zephyr Goblin King Runt | [[Regions/Iron Hold\|Iron Hold]] | Runt | B- | 96 | 1.96 m | Day & Night | Like a typical Zephyr Goblin King, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_03163` | Iron Hold Zephyr Goblin King Elderborn | [[Regions/Iron Hold\|Iron Hold]] | Elderborn | A+ | 159 | 3.78 m | Day & Night | Like a typical Zephyr Goblin King, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_03164` | Iron Hold Zephyr Goblin King Alpha | [[Regions/Iron Hold\|Iron Hold]] | Alpha | A | 146 | 3.5 m | Day & Night | Like a typical Zephyr Goblin King, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_03165` | Strife Marches Zephyr Goblin King Albino | [[Regions/Strife Marches\|Strife Marches]] | Albino | A- | 132 | 2.8 m | Day & Night | Like a typical Zephyr Goblin King, but a rare pale form with white skin or fur and red eyes. |
| `pop_03166` | Iron Hold Zephyr Goblin King | [[Regions/Iron Hold\|Iron Hold]] | Adult | B+ | 120 | 2.8 m | Day & Night | A typical adult Zephyr Goblin King of this region, with slate-grey coloring and hardened hide. |
| `pop_03167` | Moraveil Zephyr Goblin King Alpha | [[Regions/Moraveil\|Moraveil]] | Alpha | A | 146 | 3.5 m | Day & Night | Like a typical Zephyr Goblin King, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_03168` | Iron Hold Zephyr Goblin King Juvenile | [[Regions/Iron Hold\|Iron Hold]] | Juvenile | B | 108 | 2.38 m | Day & Night | Like a typical Zephyr Goblin King, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_03169` | Strife Marches Zephyr Goblin King | [[Regions/Strife Marches\|Strife Marches]] | Adult | B+ | 120 | 2.8 m | Day & Night | A typical adult Zephyr Goblin King of this region, with golden, grass-toned coloring. |

## Design recipe

Rig `rig_large_biped` · mesh `large_biped_base` · material `rough_skin_leather` · VFX `wind_ribbons` · palette `#a8e6cf` `#dcedc1` `#5b8c85` · triangle-based silhouette, sharp asymmetric spikes
