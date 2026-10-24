---
type: monster
id: mon_nue
family: "Chimeras & Mythic Beasts"
rank: "B"
tier: core
tags: [monster, chimeras-mythic-beasts]
---
# Nue

![[mon_nue_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_nue_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Nue is a large creature with a long-legged predatory quadruped build, about 3 m long. Its hide is patchy and subtly wrong, as if assembled from memory, colored in storm violet shot through with electric yellow. Its most striking feature is a monkey's face, a tiger's body and a snake for a tail. It has eyes set slightly too far apart. Faint runes glow along its body when it fights. It moves in jerky stop-motion bursts, surrounded by crackling arcs that jump across its body.

| Field | Value |
|---|---|
| Family · type | [[Families/Chimeras & Mythic Beasts|Chimeras & Mythic Beasts]] · Mythic Beast |
| Rank · level | B · 108 (96–120) |
| Menace | 4 · Dread |
| Element · weakness | Lightning · Earth |
| Size | 3 m |
| Behaviour | Guardian (guardian_hold+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 16207 · 530 · 442 · 354 · 398 · 100 |
| XP · gold | 5386 · 1057 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/quad_large\|quad_large]] · `anim_quad_large` |
| Habitats | [[Regions/Zarvan\|Zarvan]], [[Regions/Vharlen\|Vharlen]], [[Regions/Lumbaya\|Lumbaya]] |
| Genre | World Myth |
| Trope | Greek, Persian and East Asian mythic beasts |

**Field note:** Weak to Earth. Protects something nearby: a nest, a treasure, or a place.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_large|quad_large]] (rigId); animation set `anim_quad_large`.
- **Dimensions:** 1.95 m high × 3 m long × 0.48 m wide; prefab scale 0.75.
- **Physics:** 540 kg, gravity ×1.2, poise 97, knockback resistance 0.97, death style `heavy_fall_dust`.
- **Navigation:** speed 6.19 m/s, turn 185°/s, stopping distance 1 m.
- **Attack count:** 5; **signature:** a monkey's face, a tiger's body and a snake for a tail.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Maul\|Maul]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Pounce\|Pounce]] | dash | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Howl\|Howl]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Many-Headed Bite\|Many-Headed Bite]] | melee | 1.5 | 7 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Static Arc\|Static Arc]] | magic | 1.5 | 10 s | Lightning | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Nue is a **dread mythic beast** encountered at B rank, around level 108. Its documented behaviour is *Guardian* and its AI pattern is *guardian_hold+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Earth**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a monkey's face, a tiger's body and a snake for a tail. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Zarvan|Zarvan]], [[Regions/Vharlen|Vharlen]], [[Regions/Lumbaya|Lumbaya]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_large`, animation set `anim_quad_large`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Chimeras & Mythic Beasts B|loot_chimera_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Chimera Heart\|Chimera Heart]] | 60% | 1–3 |
| [[Items/Mythic Horn\|Mythic Horn]] | 30% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Chimeras & Mythic Beasts/Phantom Nue|Phantom Nue]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Zarvan\|Zarvan]] | 5 | A, B+, A-, C+, B- | 86–146 | Night |
| [[Regions/Lumbaya\|Lumbaya]] | 3 | A-, B, B+ | 108–132 | Night |
| [[Regions/Vharlen\|Vharlen]] | 3 | B-, C+, B+ | 86–120 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02185` | Zarvan Nue Elderborn | [[Regions/Zarvan\|Zarvan]] | Elderborn | A | 146 | 4.05 m | Night | Like a typical Nue, but old and wise, with greying features and a cautious hunting style, with sun-bleached, sand-scoured coloring. |
| `pop_02186` | Zarvan Nue Albino | [[Regions/Zarvan\|Zarvan]] | Albino | B+ | 120 | 3 m | Night | Like a typical Nue, but a rare pale form with white skin or fur and red eyes. |
| `pop_02187` | Zarvan Nue Alpha | [[Regions/Zarvan\|Zarvan]] | Alpha | A- | 132 | 3.75 m | Night | Like a typical Nue, but larger and scarred, and others of its kind follow it, with sun-bleached, sand-scoured coloring. |
| `pop_02188` | Zarvan Nue Runt | [[Regions/Zarvan\|Zarvan]] | Runt | C+ | 86 | 2.1 m | Night | Like a typical Nue, but smaller and scrappier than usual, with sun-bleached, sand-scoured coloring. |
| `pop_02189` | Lumbaya Nue Alpha | [[Regions/Lumbaya\|Lumbaya]] | Alpha | A- | 132 | 3.75 m | Night | Like a typical Nue, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_02190` | Vharlen Nue Juvenile | [[Regions/Vharlen\|Vharlen]] | Juvenile | B- | 96 | 2.55 m | Night | Like a typical Nue, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_02191` | Vharlen Nue Runt | [[Regions/Vharlen\|Vharlen]] | Runt | C+ | 86 | 2.1 m | Night | Like a typical Nue, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_02192` | Lumbaya Nue | [[Regions/Lumbaya\|Lumbaya]] | Adult | B | 108 | 3 m | Night | A typical adult Nue of this region, with dust-grey coloring and old rune scars. |
| `pop_02193` | Zarvan Nue Juvenile | [[Regions/Zarvan\|Zarvan]] | Juvenile | B- | 96 | 2.55 m | Night | Like a typical Nue, but young, with brighter colors and unworn features, with sun-bleached, sand-scoured coloring. |
| `pop_02194` | Lumbaya Nue Scarred | [[Regions/Lumbaya\|Lumbaya]] | Scarred | B+ | 120 | 3.3 m | Night | Like a typical Nue, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_02195` | Vharlen Nue Albino | [[Regions/Vharlen\|Vharlen]] | Albino | B+ | 120 | 3 m | Night | Like a typical Nue, but a rare pale form with white skin or fur and red eyes. |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `mixed_hide` · VFX `arc_sparks` · palette `#ffe14d` `#6c5ce7` `#1b1b3a` · elongated, irregular silhouette; still-then-sudden timing
