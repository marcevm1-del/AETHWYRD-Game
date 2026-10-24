---
type: monster
id: mon_arachne
family: "Insects & Arachnids"
rank: "B+"
tier: core
tags: [monster, insects-arachnids]
---
# Arachne

![[mon_arachne_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_arachne_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Arachne is a large creature with a bulbous spider frame on long jointed legs, about 3 m long. Its chitin is rough, scarred and spiked, colored in ink black with bruised violet. Its most striking feature is a woman's upper body rising from a spider's. It has burning slit pupils. Faint runes glow along its body when it fights. It charges without hesitation, surrounded by shadows that lean toward it.

| Field | Value |
|---|---|
| Family · type | [[Families/Insects & Arachnids|Insects & Arachnids]] · Insectoid |
| Rank · level | B+ · 120 (108–132) |
| Menace | 3 · Menacing |
| Element · weakness | Dark · Light |
| Size | 3 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 14655 · 490 · 392 · 343 · 392 · 135 |
| XP · gold | 6373 · 1225 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/arachnid\|arachnid]] · `anim_octopod` |
| Habitats | [[Regions/Moraveil\|Moraveil]], [[Regions/Strife Marches\|Strife Marches]], [[Regions/Umbravel\|Umbravel]] |
| Genre | Classic Fantasy |
| Trope | Giant insects as low-floor threats; the arachne as an intelligent monster race |

**Field note:** Weak to Light. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/arachnid|arachnid]] (rigId); animation set `anim_octopod`.
- **Dimensions:** 0.84 m high × 3 m long × 2.05 m wide; prefab scale 3.
- **Physics:** 891 kg, gravity ×1.4, poise 272, knockback resistance 0.32, death style `flip_legs_curl`.
- **Navigation:** speed 10.19 m/s, turn 346°/s, stopping distance 1.15 m.
- **Attack count:** 5; **signature:** a woman's upper body rising from a spider's.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Fang Bite\|Fang Bite]] | melee | 1.1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Web Shot\|Web Shot]] | ranged | 0.5 | 8 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Ceiling Drop\|Ceiling Drop]] | dash | 1.7 | 12 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Silk Snare\|Silk Snare]] | ranged | 0.4 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Arachne is a **menacing insectoid** encountered at B+ rank, around level 120. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a woman's upper body rising from a spider's. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Moraveil|Moraveil]], [[Regions/Strife Marches|Strife Marches]], [[Regions/Umbravel|Umbravel]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_octopod`, animation set `anim_octopod`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Insects & Arachnids B|loot_insect_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Carapace Shard\|Carapace Shard]] | 60% | 1–3 |
| [[Items/Silk\|Silk]] | 30% | 1–1 |
| [[Items/Venom Sac\|Venom Sac]] | 15% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Insects & Arachnids/Tide Arachne|Tide Arachne]]
- [[Monsters/Insects & Arachnids/Frost Arachne|Frost Arachne]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Umbravel\|Umbravel]] | 5 | A+, B+, A-, A, B- | 96–159 | Day & Night |
| [[Regions/Strife Marches\|Strife Marches]] | 4 | A-, B, B+ | 108–132 | Day & Night |
| [[Regions/Moraveil\|Moraveil]] | 2 | B+, A- | 120–132 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00696` | Umbravel Arachne Elderborn | [[Regions/Umbravel\|Umbravel]] | Elderborn | A+ | 159 | 4.05 m | Day & Night | Like a typical Arachne, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_00697` | Umbravel Arachne | [[Regions/Umbravel\|Umbravel]] | Adult | B+ | 120 | 3 m | Day & Night | A typical adult Arachne of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_00698` | Umbravel Arachne Albino | [[Regions/Umbravel\|Umbravel]] | Albino | A- | 132 | 3 m | Day & Night | Like a typical Arachne, but a rare pale form with white skin or fur and red eyes. |
| `pop_00699` | Strife Marches Arachne Albino | [[Regions/Strife Marches\|Strife Marches]] | Albino | A- | 132 | 3 m | Day & Night | Like a typical Arachne, but a rare pale form with white skin or fur and red eyes. |
| `pop_00700` | Strife Marches Arachne Juvenile | [[Regions/Strife Marches\|Strife Marches]] | Juvenile | B | 108 | 2.55 m | Day & Night | Like a typical Arachne, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_00701` | Strife Marches Arachne | [[Regions/Strife Marches\|Strife Marches]] | Adult | B+ | 120 | 3 m | Day & Night | A typical adult Arachne of this region, with golden, grass-toned coloring. |
| `pop_00702` | Moraveil Arachne | [[Regions/Moraveil\|Moraveil]] | Adult | B+ | 120 | 3 m | Day & Night | A typical adult Arachne of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_00703` | Moraveil Arachne Albino | [[Regions/Moraveil\|Moraveil]] | Albino | A- | 132 | 3 m | Day & Night | Like a typical Arachne, but a rare pale form with white skin or fur and red eyes. |
| `pop_00704` | Strife Marches Arachne Scarred | [[Regions/Strife Marches\|Strife Marches]] | Scarred | A- | 132 | 3.3 m | Day & Night | Like a typical Arachne, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_00705` | Umbravel Arachne Alpha | [[Regions/Umbravel\|Umbravel]] | Alpha | A | 146 | 3.75 m | Day & Night | Like a typical Arachne, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_00706` | Umbravel Arachne Runt | [[Regions/Umbravel\|Umbravel]] | Runt | B- | 96 | 2.1 m | Day & Night | Like a typical Arachne, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |

## Design recipe

Rig `rig_octopod` · mesh `octopod_base` · material `chitin_gloss` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · triangle-based silhouette, sharp asymmetric spikes
