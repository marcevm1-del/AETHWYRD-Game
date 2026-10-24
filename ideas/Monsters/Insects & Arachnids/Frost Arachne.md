---
type: monster
id: mon_frost_arachne
family: "Insects & Arachnids"
rank: "A-"
tier: variant
tags: [monster, insects-arachnids]
---
# Frost Arachne

![[mon_frost_arachne_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_frost_arachne_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (4,152 tris · 2.732 × 3 × 2.96 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Frost Arachne is a large creature with a squat, many-legged arachnid build, about 3 m long. Its chitin is rough, scarred and spiked, colored in pale blues and frost-white. Guild sketches always show a woman's upper body rising from a spider's. It has narrow glowing eyes. An elegant crest and glowing veins of mana mark it as a champion of its kind. It strides with heavy steps, surrounded by falling snow motes and frosted ground where it steps. This Ice-attuned variant carries one extra elemental feature, like crystal spikes, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Insects & Arachnids|Insects & Arachnids]] · Insectoid |
| Variant of | [[Monsters/Insects & Arachnids/Arachne\|Arachne]] (elemental) |
| Rank · level | A- · 132 (120–146) |
| Menace | 3 · Menacing |
| Element · weakness | Ice · Fire |
| Size | 3 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 16896 · 538 · 430 · 377 · 430 · 135 |
| XP · gold | 7422 · 1399 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/arachnid\|arachnid]] · `anim_octopod` |
| Habitats | [[Regions/Moraveil\|Moraveil]], [[Regions/Iron Hold\|Iron Hold]] |
| Genre | Classic Fantasy |
| Trope | Giant insects as low-floor threats; the arachne as an intelligent monster race |

**Field note:** Weak to Fire. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/arachnid|arachnid]] (rigId); animation set `anim_octopod`.
- **Dimensions:** 0.84 m high × 3 m long × 2.05 m wide; prefab scale 3.
- **Physics:** 980.1 kg, gravity ×1.47, poise 309, knockback resistance 0.35, death style `flip_legs_curl`.
- **Navigation:** speed 8.93 m/s, turn 346°/s, stopping distance 1.15 m.
- **Attack count:** 5; **signature:** a woman's upper body rising from a spider's.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Fang Bite\|Fang Bite]] | melee | 1.1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Web Shot\|Web Shot]] | ranged | 0.5 | 8 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Ceiling Drop\|Ceiling Drop]] | dash | 1.7 | 12 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Silk Snare\|Silk Snare]] | ranged | 0.4 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Frost Breath\|Frost Breath]] | magic | 1.5 | 10 s | Ice | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Frost Arachne is a **menacing insectoid** encountered at A- rank, around level 132. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a woman's upper body rising from a spider's. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Moraveil|Moraveil]], [[Regions/Iron Hold|Iron Hold]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_octopod`, animation set `anim_octopod`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Insects & Arachnids A|loot_insect_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Carapace Shard\|Carapace Shard]] | 60% | 1–3 |
| [[Items/Silk\|Silk]] | 30% | 1–1 |
| [[Items/Venom Sac\|Venom Sac]] | 15% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Iron Hold\|Iron Hold]] | 6 | B, A-, A, S-, A+, B+ | 108–173 | Day & Night |
| [[Regions/Moraveil\|Moraveil]] | 5 | B+, A+, S-, B, A | 108–173 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06440` | Iron Hold Frost Arachne Runt | [[Regions/Iron Hold\|Iron Hold]] | Runt | B | 108 | 2.1 m | Day & Night | Like a typical Frost Arachne, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_06441` | Moraveil Frost Arachne Juvenile | [[Regions/Moraveil\|Moraveil]] | Juvenile | B+ | 120 | 2.55 m | Day & Night | Like a typical Frost Arachne, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_06442` | Moraveil Frost Arachne Alpha | [[Regions/Moraveil\|Moraveil]] | Alpha | A+ | 159 | 3.75 m | Day & Night | Like a typical Frost Arachne, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_06443` | Iron Hold Frost Arachne | [[Regions/Iron Hold\|Iron Hold]] | Adult | A- | 132 | 3 m | Day & Night | A typical adult Frost Arachne of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_06444` | Moraveil Frost Arachne Elderborn | [[Regions/Moraveil\|Moraveil]] | Elderborn | S- | 173 | 4.05 m | Day & Night | Like a typical Frost Arachne, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_06445` | Moraveil Frost Arachne Runt | [[Regions/Moraveil\|Moraveil]] | Runt | B | 108 | 2.1 m | Day & Night | Like a typical Frost Arachne, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_06446` | Iron Hold Frost Arachne Albino | [[Regions/Iron Hold\|Iron Hold]] | Albino | A | 146 | 3 m | Day & Night | Like a typical Frost Arachne, but a rare pale form with white skin or fur and red eyes. |
| `pop_06447` | Iron Hold Frost Arachne Elderborn | [[Regions/Iron Hold\|Iron Hold]] | Elderborn | S- | 173 | 4.05 m | Day & Night | Like a typical Frost Arachne, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_06448` | Moraveil Frost Arachne Scarred | [[Regions/Moraveil\|Moraveil]] | Scarred | A | 146 | 3.3 m | Day & Night | Like a typical Frost Arachne, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_06449` | Iron Hold Frost Arachne Alpha | [[Regions/Iron Hold\|Iron Hold]] | Alpha | A+ | 159 | 3.75 m | Day & Night | Like a typical Frost Arachne, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_06450` | Iron Hold Frost Arachne Juvenile | [[Regions/Iron Hold\|Iron Hold]] | Juvenile | B+ | 120 | 2.55 m | Day & Night | Like a typical Frost Arachne, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |

## Design recipe

Rig `rig_octopod` · mesh `octopod_base` · material `chitin_gloss` · VFX `frost_trail_snow` · palette `#bfe9ff` `#5fa8d3` `#f4fbff` · triangle-based silhouette, sharp asymmetric spikes
