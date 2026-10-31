---
type: monster
id: mon_venom_spider
family: "Insects & Arachnids"
rank: "D"
tier: core
tags: [monster, insects-arachnids]
---
# Venom Spider

![[mon_venom_spider_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_venom_spider_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (3,416 tris · 1.26 × 1.4 × 0.782 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Venom Spider is a person-sized creature with a bulbous spider frame on long jointed legs, about 1.4 m long. Its chitin is rough, scarred and spiked, colored in amber, with sickly green markings. Its most striking feature is green-striped legs and dripping fangs. It has burning slit pupils. A distinctive marking runs along its back. It charges without hesitation, surrounded by a low toxic haze that clings to the ground.

| Field | Value |
|---|---|
| Family · type | [[Families/Insects & Arachnids|Insects & Arachnids]] · Insectoid |
| Rank · level | D · 48 (40–56) |
| Menace | 3 · Menacing |
| Element · weakness | Poison · Light |
| Size | 1.4 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 2902 · 202 · 162 · 141 · 162 · 135 |
| XP · gold | 1477 · 342 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/arachnid\|arachnid]] · `anim_octopod` |
| Habitats | [[Regions/Moraveil\|Moraveil]], [[Regions/Aldmere\|Aldmere]], [[Regions/Xochitl Mire\|Xochitl Mire]] |
| Genre | Classic Fantasy |
| Trope | Giant insects as low-floor threats; the arachne as an intelligent monster race |

**Field note:** Weak to Light. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/arachnid|arachnid]] (rigId); animation set `anim_octopod`.
- **Dimensions:** 0.39 m high × 1.4 m long × 0.96 m wide; prefab scale 1.4.
- **Physics:** 90.6 kg, gravity ×1.4, poise 68, knockback resistance 0.26, death style `flip_legs_curl`.
- **Navigation:** speed 5.85 m/s, turn 507°/s, stopping distance 0.75 m.
- **Attack count:** 5; **signature:** green-striped legs and dripping fangs.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Fang Bite\|Fang Bite]] | melee | 1.1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Web Shot\|Web Shot]] | ranged | 0.5 | 8 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Ceiling Drop\|Ceiling Drop]] | dash | 1.7 | 12 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Silk Snare\|Silk Snare]] | ranged | 0.4 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Venom Spit\|Venom Spit]] | magic | 1.5 | 10 s | Poison | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Venom Spider is a **menacing insectoid** encountered at D rank, around level 48. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** green-striped legs and dripping fangs. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Moraveil|Moraveil]], [[Regions/Aldmere|Aldmere]], [[Regions/Xochitl Mire|Xochitl Mire]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_octopod`, animation set `anim_octopod`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Insects & Arachnids D|loot_insect_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Carapace Shard\|Carapace Shard]] | 60% | 1–3 |
| [[Items/Silk\|Silk]] | 30% | 1–1 |
| [[Items/Venom Sac\|Venom Sac]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Insects & Arachnids/Gilded Spider|Gilded Spider]]
- [[Monsters/Insects & Arachnids/Cavern Spider|Cavern Spider]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Xochitl Mire\|Xochitl Mire]] | 3 | C-, D+, D | 48–65 | Day & Night |
| [[Regions/Moraveil\|Moraveil]] | 5 | D+, D, E+, C | 32–76 | Day & Night |
| [[Regions/Aldmere\|Aldmere]] | 3 | E+, D-, D | 32–48 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00652` | Xochitl Mire Venom Spider Alpha | [[Regions/Xochitl Mire\|Xochitl Mire]] | Alpha | C- | 65 | 1.75 m | Day & Night | Like a typical Venom Spider, but larger and scarred, and others of its kind follow it, with vivid tropical markings. |
| `pop_00653` | Moraveil Venom Spider Scarred | [[Regions/Moraveil\|Moraveil]] | Scarred | D+ | 56 | 1.54 m | Day & Night | Like a typical Venom Spider, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_00654` | Aldmere Venom Spider Runt | [[Regions/Aldmere\|Aldmere]] | Runt | E+ | 32 | 0.98 m | Day & Night | Like a typical Venom Spider, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_00655` | Xochitl Mire Venom Spider Albino | [[Regions/Xochitl Mire\|Xochitl Mire]] | Albino | D+ | 56 | 1.4 m | Day & Night | Like a typical Venom Spider, but a rare pale form with white skin or fur and red eyes. |
| `pop_00656` | Xochitl Mire Venom Spider | [[Regions/Xochitl Mire\|Xochitl Mire]] | Adult | D | 48 | 1.4 m | Day & Night | A typical adult Venom Spider of this region, with vivid tropical markings. |
| `pop_00657` | Aldmere Venom Spider Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | D- | 40 | 1.19 m | Day & Night | Like a typical Venom Spider, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_00658` | Aldmere Venom Spider | [[Regions/Aldmere\|Aldmere]] | Adult | D | 48 | 1.4 m | Day & Night | A typical adult Venom Spider of this region, with golden, grass-toned coloring. |
| `pop_00659` | Moraveil Venom Spider | [[Regions/Moraveil\|Moraveil]] | Adult | D | 48 | 1.4 m | Day & Night | A typical adult Venom Spider of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_00660` | Moraveil Venom Spider Runt | [[Regions/Moraveil\|Moraveil]] | Runt | E+ | 32 | 0.98 m | Day & Night | Like a typical Venom Spider, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_00661` | Moraveil Venom Spider Albino | [[Regions/Moraveil\|Moraveil]] | Albino | D+ | 56 | 1.4 m | Day & Night | Like a typical Venom Spider, but a rare pale form with white skin or fur and red eyes. |
| `pop_00662` | Moraveil Venom Spider Elderborn | [[Regions/Moraveil\|Moraveil]] | Elderborn | C | 76 | 1.89 m | Day & Night | Like a typical Venom Spider, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_octopod` · mesh `octopod_base` · material `chitin_gloss` · VFX `toxic_fog` · palette `#b0642a` `#703e1a` `#b8e986` · triangle-based silhouette, sharp asymmetric spikes
