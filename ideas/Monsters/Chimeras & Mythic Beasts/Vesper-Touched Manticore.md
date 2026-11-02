---
type: monster
id: mon_vesper_touched_manticore
family: "Chimeras & Mythic Beasts"
rank: "A-"
tier: variant
tags: [monster, chimeras-mythic-beasts]
---
# Vesper-Touched Manticore

![[mon_vesper_touched_manticore_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_vesper_touched_manticore_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,680 tris · 0.924 × 3 × 2.545 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Vesper-Touched Manticore is a large creature with a long-legged predatory quadruped build, about 3 m long. Its hide is patchy and subtly wrong, as if assembled from memory, colored in lion-tawny, with sickly green markings. Its most striking feature is a lion's body, a scorpion tail and a too-human smile. It has pale, pupil-less eyes. An elegant crest and glowing veins of mana mark it as a champion of its kind. It freezes whenever it is looked at, surrounded by a low toxic haze that clings to the ground. Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.

| Field | Value |
|---|---|
| Family · type | [[Families/Chimeras & Mythic Beasts|Chimeras & Mythic Beasts]] · Mythic Beast |
| Variant of | [[Monsters/Chimeras & Mythic Beasts/Manticore\|Manticore]] (corrupted) |
| Rank · level | A- · 132 (120–146) |
| Menace | 4 · Dread |
| Element · weakness | Poison · Light |
| Size | 3 m |
| Behaviour | Territorial (territorial_guard+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 21866 · 646 · 538 · 430 · 484 · 100 |
| XP · gold | 7422 · 1399 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/quad_large\|quad_large]] · `anim_quad_large` |
| Habitats | [[Regions/Lumbaya\|Lumbaya]], [[Regions/Iron Hold\|Iron Hold]] |
| Genre | World Myth |
| Trope | Greek, Persian and East Asian mythic beasts |

**Field note:** Weak to Light. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_large|quad_large]] (rigId); animation set `anim_quad_large`.
- **Dimensions:** 1.95 m high × 3 m long × 0.48 m wide; prefab scale 0.75.
- **Physics:** 540 kg, gravity ×1.2, poise 106, knockback resistance 1, death style `heavy_fall_dust`.
- **Navigation:** speed 6.18 m/s, turn 185°/s, stopping distance 1 m.
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

Vesper-Touched Manticore is a **dread mythic beast** encountered at A- rank, around level 132. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a lion's body, a scorpion tail and a too-human smile. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Lumbaya|Lumbaya]], [[Regions/Iron Hold|Iron Hold]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_large`, animation set `anim_quad_large`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Chimeras & Mythic Beasts A|loot_chimera_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Chimera Heart\|Chimera Heart]] | 60% | 1–3 |
| [[Items/Mythic Horn\|Mythic Horn]] | 30% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Lumbaya\|Lumbaya]] | 5 | A, A+, A-, B, S- | 108–173 | Night |
| [[Regions/Iron Hold\|Iron Hold]] | 6 | A, A+, A-, S-, B+ | 120–173 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05015` | Lumbaya Vesper-Touched Manticore Scarred | [[Regions/Lumbaya\|Lumbaya]] | Scarred | A | 146 | 3.3 m | Night | Like a typical Vesper-Touched Manticore, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_05016` | Lumbaya Vesper-Touched Manticore Alpha | [[Regions/Lumbaya\|Lumbaya]] | Alpha | A+ | 159 | 3.75 m | Night | Like a typical Vesper-Touched Manticore, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_05017` | Iron Hold Vesper-Touched Manticore Albino | [[Regions/Iron Hold\|Iron Hold]] | Albino | A | 146 | 3 m | Night | Like a typical Vesper-Touched Manticore, but a rare pale form with white skin or fur and red eyes. |
| `pop_05018` | Lumbaya Vesper-Touched Manticore | [[Regions/Lumbaya\|Lumbaya]] | Adult | A- | 132 | 3 m | Night | A typical adult Vesper-Touched Manticore of this region, with dust-grey coloring and old rune scars. |
| `pop_05019` | Iron Hold Vesper-Touched Manticore Scarred | [[Regions/Iron Hold\|Iron Hold]] | Scarred | A | 146 | 3.3 m | Night | Like a typical Vesper-Touched Manticore, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_05020` | Iron Hold Vesper-Touched Manticore Alpha | [[Regions/Iron Hold\|Iron Hold]] | Alpha | A+ | 159 | 3.75 m | Night | Like a typical Vesper-Touched Manticore, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_05021` | Iron Hold Vesper-Touched Manticore | [[Regions/Iron Hold\|Iron Hold]] | Adult | A- | 132 | 3 m | Night | A typical adult Vesper-Touched Manticore of this region, with slate-grey coloring and hardened hide. |
| `pop_05022` | Lumbaya Vesper-Touched Manticore Runt | [[Regions/Lumbaya\|Lumbaya]] | Runt | B | 108 | 2.1 m | Night | Like a typical Vesper-Touched Manticore, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_05023` | Lumbaya Vesper-Touched Manticore Elderborn | [[Regions/Lumbaya\|Lumbaya]] | Elderborn | S- | 173 | 4.05 m | Night | Like a typical Vesper-Touched Manticore, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_05024` | Iron Hold Vesper-Touched Manticore Elderborn | [[Regions/Iron Hold\|Iron Hold]] | Elderborn | S- | 173 | 4.05 m | Night | Like a typical Vesper-Touched Manticore, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_05025` | Iron Hold Vesper-Touched Manticore Juvenile | [[Regions/Iron Hold\|Iron Hold]] | Juvenile | B+ | 120 | 2.55 m | Night | Like a typical Vesper-Touched Manticore, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `mixed_hide` · VFX `toxic_fog` · palette `#b88854` `#785636` `#b8e986` · elongated, irregular silhouette; still-then-sudden timing
