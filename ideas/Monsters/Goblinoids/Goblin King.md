---
type: monster
id: mon_goblin_king
family: "Goblinoids"
rank: "B"
tier: core
tags: [monster, goblinoids]
---
# Goblin King

> The Goblin King is a large creature with a massive hunched brute frame, about 2.8 m tall. Its skin is rough, scarred and spiked, colored in ochre, clay and mossy stone. Look for throne-backed armor and a crown of hammered coins. It has burning slit pupils. Faint runes glow along its body when it fights. It charges without hesitation, surrounded by pebbles that tremble and float near it.

| Field | Value |
|---|---|
| Family · type | [[Families/Goblinoids|Goblinoids]] · Humanoid |
| Rank · level | B · 108 (96–120) |
| Menace | 3 · Menacing |
| Element · weakness | Earth · Wind |
| Size | 2.8 m |
| Behaviour | Pack (pack_flank) |
| HP · ATK · DEF · MATK · MDEF · SPD | 20154 · 442 · 663 · 265 · 442 · 70 |
| XP · gold | 5386 · 1057 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/large_biped\|large_biped]] · `anim_large_biped` |
| Habitats | [[Regions/Moraveil\|Moraveil]], [[Regions/Iron Hold\|Iron Hold]], [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/Hoshizora\|Hoshizora]], [[Regions/Shen-Lu\|Shen-Lu]] |
| Genre | Dark Fantasy |
| Trope | Goblins as horror in numbers (Goblin Slayer); hobgoblin → champion → king evolution |

**Field note:** Weak to Wind. Never alone. Kill the leader first and the rest may scatter.

## Motion implementation

- **Rig:** [[Systems/Rigs/large_biped|large_biped]] (rigId); animation set `anim_large_biped`.
- **Dimensions:** 2.8 m high × 0.84 m long × 1.18 m wide; prefab scale 0.8.
- **Physics:** 513.7 kg, gravity ×1.43, poise 200, knockback resistance 1, death style `heavy_fall_dust`.
- **Navigation:** speed 5.44 m/s, turn 227°/s, stopping distance 0.96 m.
- **Attack count:** 5; **signature:** throne-backed armor and a crown of hammered coins.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stomp\|Stomp]] | aoe | 1.3 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Club Slam\|Club Slam]] | melee | 1.8 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Grab and Throw\|Grab and Throw]] | grab | 2 | 14 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Sand Toss\|Sand Toss]] | debuff | 0 | 12 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Goblin King is a **menacing humanoid** encountered at B rank, around level 108. Its documented behaviour is *Pack* and its AI pattern is *pack_flank*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** throne-backed armor and a crown of hammered coins. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Moraveil|Moraveil]], [[Regions/Iron Hold|Iron Hold]], [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]], [[Regions/Hoshizora|Hoshizora]], [[Regions/Shen-Lu|Shen-Lu]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_large_biped`, animation set `anim_large_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Goblinoids B|loot_goblinoid_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Goblin Ear\|Goblin Ear]] | 60% | 1–3 |
| [[Items/Crude Blade\|Crude Blade]] | 30% | 1–1 |
| [[Items/Stolen Trinket\|Stolen Trinket]] | 15% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Goblinoids/Zephyr Goblin King|Zephyr Goblin King]]
- [[Monsters/Goblinoids/Ancient Goblin King|Ancient Goblin King]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Hoshizora\|Hoshizora]] | 4 | B-, B+, A-, B | 96–132 | Day & Night |
| [[Regions/Moraveil\|Moraveil]] | 2 | B-, A- | 96–132 | Day & Night |
| [[Regions/Iron Hold\|Iron Hold]] | 2 | C+, A | 86–146 | Day & Night |
| [[Regions/Shen-Lu\|Shen-Lu]] | 2 | B-, B | 96–108 | Day & Night |
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 1 | A | 146–146 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00255` | Hoshizora Goblin King Juvenile | [[Regions/Hoshizora\|Hoshizora]] | Juvenile | B- | 96 | 2.38 m | Day & Night | Like a typical Goblin King, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_00256` | Moraveil Goblin King Juvenile | [[Regions/Moraveil\|Moraveil]] | Juvenile | B- | 96 | 2.38 m | Day & Night | Like a typical Goblin King, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_00257` | Iron Hold Goblin King Runt | [[Regions/Iron Hold\|Iron Hold]] | Runt | C+ | 86 | 1.96 m | Day & Night | Like a typical Goblin King, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_00258` | Moraveil Goblin King Alpha | [[Regions/Moraveil\|Moraveil]] | Alpha | A- | 132 | 3.5 m | Day & Night | Like a typical Goblin King, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_00259` | Shen-Lu Goblin King Juvenile | [[Regions/Shen-Lu\|Shen-Lu]] | Juvenile | B- | 96 | 2.38 m | Day & Night | Like a typical Goblin King, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_00260` | Hoshizora Goblin King Scarred | [[Regions/Hoshizora\|Hoshizora]] | Scarred | B+ | 120 | 3.08 m | Day & Night | Like a typical Goblin King, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_00261` | Iron Hold Goblin King Elderborn | [[Regions/Iron Hold\|Iron Hold]] | Elderborn | A | 146 | 3.78 m | Day & Night | Like a typical Goblin King, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_00262` | Hoshizora Goblin King Alpha | [[Regions/Hoshizora\|Hoshizora]] | Alpha | A- | 132 | 3.5 m | Day & Night | Like a typical Goblin King, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_00263` | Shen-Lu Goblin King | [[Regions/Shen-Lu\|Shen-Lu]] | Adult | B | 108 | 2.8 m | Day & Night | A typical adult Goblin King of this region, with slate-grey coloring and hardened hide. |
| `pop_00264` | Great Labyrinth (Floors 41-90) Goblin King Elderborn | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Elderborn | A | 146 | 3.78 m | Day & Night | Like a typical Goblin King, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_00265` | Hoshizora Goblin King | [[Regions/Hoshizora\|Hoshizora]] | Adult | B | 108 | 2.8 m | Day & Night | A typical adult Goblin King of this region, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_large_biped` · mesh `large_biped_base` · material `rough_skin_leather` · VFX `rock_debris` · palette `#8b5a2b` `#c2a878` `#4a4a3a` · triangle-based silhouette, sharp asymmetric spikes
