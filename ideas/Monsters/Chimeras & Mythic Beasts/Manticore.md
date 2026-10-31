---
type: monster
id: mon_manticore
family: "Chimeras & Mythic Beasts"
rank: "B"
tier: core
tags: [monster, chimeras-mythic-beasts]
---
# Manticore

![[mon_manticore_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_manticore_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,266 tris · 1.157 × 3 × 2.61 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Manticore is a large creature with a long-legged predatory quadruped build, about 3 m long. Its hide is rough, scarred and spiked, colored in lion-tawny, with sickly green markings. Guild sketches always show a lion's body, a scorpion tail and a too-human smile. It has burning slit pupils. Faint runes glow along its body when it fights. It charges without hesitation, surrounded by a low toxic haze that clings to the ground.

| Field | Value |
|---|---|
| Family · type | [[Families/Chimeras & Mythic Beasts|Chimeras & Mythic Beasts]] · Mythic Beast |
| Rank · level | B · 108 (96–120) |
| Menace | 3 · Menacing |
| Element · weakness | Poison · Light |
| Size | 3 m |
| Behaviour | Guardian (guardian_hold) |
| HP · ATK · DEF · MATK · MDEF · SPD | 16207 · 530 · 442 · 354 · 398 · 100 |
| XP · gold | 5386 · 1057 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/quad_large\|quad_large]] · `anim_quad_large` |
| Habitats | [[Regions/Lumbaya\|Lumbaya]], [[Regions/Iron Hold\|Iron Hold]], [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] |
| Genre | World Myth |
| Trope | Greek, Persian and East Asian mythic beasts |

**Field note:** Weak to Light. Protects something nearby: a nest, a treasure, or a place.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_large|quad_large]] (rigId); animation set `anim_quad_large`.
- **Dimensions:** 1.95 m high × 3 m long × 0.48 m wide; prefab scale 0.75.
- **Physics:** 540 kg, gravity ×1.2, poise 97, knockback resistance 0.97, death style `heavy_fall_dust`.
- **Navigation:** speed 5.84 m/s, turn 185°/s, stopping distance 1 m.
- **Attack count:** 5; **signature:** a lion's body, a scorpion tail and a too-human smile.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Maul\|Maul]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Pounce\|Pounce]] | dash | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Howl\|Howl]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Many-Headed Bite\|Many-Headed Bite]] | melee | 1.5 | 7 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Venom Spit\|Venom Spit]] | magic | 1.5 | 10 s | Poison | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Manticore is a **menacing mythic beast** encountered at B rank, around level 108. Its documented behaviour is *Guardian* and its AI pattern is *guardian_hold*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a lion's body, a scorpion tail and a too-human smile. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Lumbaya|Lumbaya]], [[Regions/Iron Hold|Iron Hold]], [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_large`, animation set `anim_quad_large`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Chimeras & Mythic Beasts B|loot_chimera_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Chimera Heart\|Chimera Heart]] | 60% | 1–3 |
| [[Items/Mythic Horn\|Mythic Horn]] | 30% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Chimeras & Mythic Beasts/Vesper-Touched Manticore|Vesper-Touched Manticore]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Lumbaya\|Lumbaya]] | 4 | B+, A-, B | 108–132 | Day & Night |
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 3 | C+, A-, B | 86–132 | Day & Night |
| [[Regions/Iron Hold\|Iron Hold]] | 4 | C+, A-, B-, B+ | 86–132 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02163` | Lumbaya Manticore Scarred | [[Regions/Lumbaya\|Lumbaya]] | Scarred | B+ | 120 | 3.3 m | Day & Night | Like a typical Manticore, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_02164` | Great Labyrinth (Floors 41-90) Manticore Runt | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Runt | C+ | 86 | 2.1 m | Day & Night | Like a typical Manticore, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_02165` | Iron Hold Manticore Runt | [[Regions/Iron Hold\|Iron Hold]] | Runt | C+ | 86 | 2.1 m | Day & Night | Like a typical Manticore, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_02166` | Iron Hold Manticore Alpha | [[Regions/Iron Hold\|Iron Hold]] | Alpha | A- | 132 | 3.75 m | Day & Night | Like a typical Manticore, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_02167` | Lumbaya Manticore Albino | [[Regions/Lumbaya\|Lumbaya]] | Albino | B+ | 120 | 3 m | Day & Night | Like a typical Manticore, but a rare pale form with white skin or fur and red eyes. |
| `pop_02168` | Lumbaya Manticore Alpha | [[Regions/Lumbaya\|Lumbaya]] | Alpha | A- | 132 | 3.75 m | Day & Night | Like a typical Manticore, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_02169` | Iron Hold Manticore Juvenile | [[Regions/Iron Hold\|Iron Hold]] | Juvenile | B- | 96 | 2.55 m | Day & Night | Like a typical Manticore, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_02170` | Great Labyrinth (Floors 41-90) Manticore Alpha | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Alpha | A- | 132 | 3.75 m | Day & Night | Like a typical Manticore, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_02171` | Iron Hold Manticore Albino | [[Regions/Iron Hold\|Iron Hold]] | Albino | B+ | 120 | 3 m | Day & Night | Like a typical Manticore, but a rare pale form with white skin or fur and red eyes. |
| `pop_02172` | Great Labyrinth (Floors 41-90) Manticore | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Adult | B | 108 | 3 m | Day & Night | A typical adult Manticore of this region, with dust-grey coloring and old rune scars. |
| `pop_02173` | Lumbaya Manticore | [[Regions/Lumbaya\|Lumbaya]] | Adult | B | 108 | 3 m | Day & Night | A typical adult Manticore of this region, with dust-grey coloring and old rune scars. |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `mixed_hide` · VFX `toxic_fog` · palette `#b37c52` `#754e35` `#b8e986` · triangle-based silhouette, sharp asymmetric spikes
