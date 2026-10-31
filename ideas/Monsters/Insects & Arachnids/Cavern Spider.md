---
type: monster
id: mon_cavern_spider
family: "Insects & Arachnids"
rank: "D+"
tier: variant
tags: [monster, insects-arachnids]
---
# Cavern Spider

![[mon_cavern_spider_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_cavern_spider_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (4,334 tris · 1.361 × 1.4 × 1.475 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Cavern Spider is a person-sized creature with an eight-legged arachnid body, about 1.4 m long. Its chitin is rough, scarred and spiked, colored in amber, with ochre markings. Guild sketches always show green-striped legs and dripping fangs. It has eyes that catch torchlight like coins. A distinctive marking runs along its back. It strides with heavy steps, surrounded by pebbles that tremble and float near it. Adapted to cave lands, it has pale, light-starved coloring and oversized eyes.

| Field | Value |
|---|---|
| Family · type | [[Families/Insects & Arachnids|Insects & Arachnids]] · Insectoid |
| Variant of | [[Monsters/Insects & Arachnids/Venom Spider\|Venom Spider]] (regional) |
| Rank · level | D+ · 56 (48–65) |
| Menace | 3 · Menacing |
| Element · weakness | Earth · Wind |
| Size | 1.4 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 3642 · 234 · 187 · 164 · 187 · 135 |
| XP · gold | 1888 · 423 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/arachnid\|arachnid]] · `anim_octopod` |
| Habitats | [[Regions/Moraveil\|Moraveil]], [[Regions/Iron Hold\|Iron Hold]] |
| Genre | Classic Fantasy |
| Trope | Giant insects as low-floor threats; the arachne as an intelligent monster race |

**Field note:** Weak to Wind. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/arachnid|arachnid]] (rigId); animation set `anim_octopod`.
- **Dimensions:** 0.39 m high × 1.4 m long × 0.96 m wide; prefab scale 1.4.
- **Physics:** 117.7 kg, gravity ×1.54, poise 74, knockback resistance 0.41, death style `flip_legs_curl`.
- **Navigation:** speed 5.55 m/s, turn 507°/s, stopping distance 0.75 m.
- **Attack count:** 5; **signature:** green-striped legs and dripping fangs.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Fang Bite\|Fang Bite]] | melee | 1.1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Web Shot\|Web Shot]] | ranged | 0.5 | 8 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Ceiling Drop\|Ceiling Drop]] | dash | 1.7 | 12 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Silk Snare\|Silk Snare]] | ranged | 0.4 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Cavern Spider is a **menacing insectoid** encountered at D+ rank, around level 56. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** green-striped legs and dripping fangs. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Moraveil|Moraveil]], [[Regions/Iron Hold|Iron Hold]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_octopod`, animation set `anim_octopod`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Insects & Arachnids D|loot_insect_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Carapace Shard\|Carapace Shard]] | 60% | 1–3 |
| [[Items/Silk\|Silk]] | 30% | 1–1 |
| [[Items/Venom Sac\|Venom Sac]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Iron Hold\|Iron Hold]] | 6 | C-, D+, C, D, C+ | 48–86 | Day & Night |
| [[Regions/Moraveil\|Moraveil]] | 5 | C+, C-, D-, D | 40–86 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06396` | Iron Hold Cavern Spider Scarred | [[Regions/Iron Hold\|Iron Hold]] | Scarred | C- | 65 | 1.54 m | Day & Night | Like a typical Cavern Spider, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_06397` | Iron Hold Cavern Spider Albino | [[Regions/Iron Hold\|Iron Hold]] | Albino | C- | 65 | 1.4 m | Day & Night | Like a typical Cavern Spider, but a rare pale form with white skin or fur and red eyes. |
| `pop_06398` | Moraveil Cavern Spider Elderborn | [[Regions/Moraveil\|Moraveil]] | Elderborn | C+ | 86 | 1.89 m | Day & Night | Like a typical Cavern Spider, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_06399` | Iron Hold Cavern Spider | [[Regions/Iron Hold\|Iron Hold]] | Adult | D+ | 56 | 1.4 m | Day & Night | A typical adult Cavern Spider of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_06400` | Moraveil Cavern Spider Scarred | [[Regions/Moraveil\|Moraveil]] | Scarred | C- | 65 | 1.54 m | Day & Night | Like a typical Cavern Spider, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_06401` | Iron Hold Cavern Spider Alpha | [[Regions/Iron Hold\|Iron Hold]] | Alpha | C | 76 | 1.75 m | Day & Night | Like a typical Cavern Spider, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_06402` | Moraveil Cavern Spider Albino | [[Regions/Moraveil\|Moraveil]] | Albino | C- | 65 | 1.4 m | Day & Night | Like a typical Cavern Spider, but a rare pale form with white skin or fur and red eyes. |
| `pop_06403` | Iron Hold Cavern Spider Juvenile | [[Regions/Iron Hold\|Iron Hold]] | Juvenile | D | 48 | 1.19 m | Day & Night | Like a typical Cavern Spider, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_06404` | Iron Hold Cavern Spider Elderborn | [[Regions/Iron Hold\|Iron Hold]] | Elderborn | C+ | 86 | 1.89 m | Day & Night | Like a typical Cavern Spider, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_06405` | Moraveil Cavern Spider Runt | [[Regions/Moraveil\|Moraveil]] | Runt | D- | 40 | 0.98 m | Day & Night | Like a typical Cavern Spider, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_06406` | Moraveil Cavern Spider Juvenile | [[Regions/Moraveil\|Moraveil]] | Juvenile | D | 48 | 1.19 m | Day & Night | Like a typical Cavern Spider, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_octopod` · mesh `octopod_base` · material `chitin_gloss` · VFX `rock_debris` · palette `#b7742c` `#74481b` `#d1a15a` · triangle-based silhouette, sharp asymmetric spikes
