---
type: monster
id: mon_vesper_touched_dullahan
family: "The Headless"
rank: "A-"
tier: variant
tags: [monster, the-headless]
---
# Vesper-Touched Dullahan

![[mon_vesper_touched_dullahan_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_vesper_touched_dullahan_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (1,746 tris · 2.188 × 3.611 × 2.8 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Vesper-Touched Dullahan is a large creature with an armored humanoid body without a head, about 2.8 m tall. Its armor is stretched, stitched and constantly shifting, colored in ink black with bruised violet. Its own laughing head carried under one arm. It has too many eyes, opening one after another. An elegant crest and glowing veins of mana mark it as a champion of its kind. It unfolds into something larger, surrounded by shadows that lean toward it. Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.

| Field | Value |
|---|---|
| Family · type | [[Families/The Headless|The Headless]] · Undead |
| Variant of | [[Monsters/The Headless/Dullahan\|Dullahan]] (corrupted) |
| Rank · level | A- · 132 (120–146) |
| Menace | 5 · Horror |
| Element · weakness | Dark · Light |
| Size | 2.8 m |
| Behaviour | Guardian (guardian_hold+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 27190 · 538 · 807 · 323 · 538 · 70 |
| XP · gold | 7422 · 1399 |
| Ring | 7 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_headless` |
| Habitats | [[Regions/Sky Archipelago\|Sky Archipelago]], [[Regions/Aurumdeep\|Aurumdeep]] |
| Genre | Celtic Gothic |
| Trope | The dullahan of Irish folklore |

**Field note:** Weak to Light. Protects something nearby: a nest, a treasure, or a place.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_headless`.
- **Dimensions:** 2.8 m high × 0.84 m long × 0.9 m wide; prefab scale 1.556.
- **Physics:** 285.4 kg, gravity ×1.5, poise 109, knockback resistance 0.45, death style `ragdoll`.
- **Navigation:** speed 5.81 m/s, turn 239°/s, stopping distance 0.88 m.
- **Attack count:** 5; **signature:** its own laughing head carried under one arm.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Sweep\|Sweep]] | melee | 1.3 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Charge\|Charge]] | dash | 1.3 | 5 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Head Throw\|Head Throw]] | ranged | 1.4 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Lantern Hurl\|Lantern Hurl]] | ranged | 1.3 | 8 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Vesper-Touched Dullahan is a **horror undead** encountered at A- rank, around level 132. Its documented behaviour is *Guardian* and its AI pattern is *guardian_hold+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** its own laughing head carried under one arm. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Sky Archipelago|Sky Archipelago]], [[Regions/Aurumdeep|Aurumdeep]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_headless`, animation set `anim_headless`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/The Headless A|loot_headless_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Rider's Lantern\|Rider's Lantern]] | 60% | 1–3 |
| [[Items/Cursed Iron\|Cursed Iron]] | 30% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Sky Archipelago\|Sky Archipelago]] | 5 | A+, A, B, A- | 108–159 | Night |
| [[Regions/Aurumdeep\|Aurumdeep]] | 6 | A, S-, A+, B+, A- | 120–173 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05191` | Sky Archipelago Vesper-Touched Dullahan Alpha | [[Regions/Sky Archipelago\|Sky Archipelago]] | Alpha | A+ | 159 | 3.5 m | Night | Like a typical Vesper-Touched Dullahan, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_05192` | Aurumdeep Vesper-Touched Dullahan Albino | [[Regions/Aurumdeep\|Aurumdeep]] | Albino | A | 146 | 2.8 m | Night | Like a typical Vesper-Touched Dullahan, but a rare pale form with white skin or fur and red eyes. |
| `pop_05193` | Aurumdeep Vesper-Touched Dullahan Elderborn | [[Regions/Aurumdeep\|Aurumdeep]] | Elderborn | S- | 173 | 3.78 m | Night | Like a typical Vesper-Touched Dullahan, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_05194` | Sky Archipelago Vesper-Touched Dullahan Scarred | [[Regions/Sky Archipelago\|Sky Archipelago]] | Scarred | A | 146 | 3.08 m | Night | Like a typical Vesper-Touched Dullahan, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_05195` | Aurumdeep Vesper-Touched Dullahan Scarred | [[Regions/Aurumdeep\|Aurumdeep]] | Scarred | A | 146 | 3.08 m | Night | Like a typical Vesper-Touched Dullahan, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_05196` | Sky Archipelago Vesper-Touched Dullahan Albino | [[Regions/Sky Archipelago\|Sky Archipelago]] | Albino | A | 146 | 2.8 m | Night | Like a typical Vesper-Touched Dullahan, but a rare pale form with white skin or fur and red eyes. |
| `pop_05197` | Aurumdeep Vesper-Touched Dullahan Alpha | [[Regions/Aurumdeep\|Aurumdeep]] | Alpha | A+ | 159 | 3.5 m | Night | Like a typical Vesper-Touched Dullahan, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_05198` | Aurumdeep Vesper-Touched Dullahan Juvenile | [[Regions/Aurumdeep\|Aurumdeep]] | Juvenile | B+ | 120 | 2.38 m | Night | Like a typical Vesper-Touched Dullahan, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_05199` | Sky Archipelago Vesper-Touched Dullahan Runt | [[Regions/Sky Archipelago\|Sky Archipelago]] | Runt | B | 108 | 1.96 m | Night | Like a typical Vesper-Touched Dullahan, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_05200` | Sky Archipelago Vesper-Touched Dullahan | [[Regions/Sky Archipelago\|Sky Archipelago]] | Adult | A- | 132 | 2.8 m | Night | A typical adult Vesper-Touched Dullahan of this region, with dust-grey coloring and old rune scars. |
| `pop_05201` | Aurumdeep Vesper-Touched Dullahan | [[Regions/Aurumdeep\|Aurumdeep]] | Adult | A- | 132 | 2.8 m | Night | A typical adult Vesper-Touched Dullahan of this region, with dust-grey coloring and old rune scars. |

## Design recipe

Rig `rig_headless` · mesh `headless_base` · material `old_iron` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · broken symmetry, mimicry, audio-first reveal
