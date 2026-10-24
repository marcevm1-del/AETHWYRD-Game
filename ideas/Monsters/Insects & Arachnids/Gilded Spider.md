---
type: monster
id: mon_gilded_spider
family: "Insects & Arachnids"
rank: "D+"
tier: variant
tags: [monster, insects-arachnids]
---
# Gilded Spider

![[mon_gilded_spider_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_gilded_spider_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (3,320 tris · 1.275 × 1.4 × 0.791 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Gilded Spider is a person-sized creature with a squat, many-legged arachnid build, about 1.4 m long. Its chitin is rough, scarred and spiked, colored in warm gold and pearl white. Look for green-striped legs and dripping fangs. It has burning slit pupils. A distinctive marking runs along its back. It strides with heavy steps, surrounded by soft radiance and floating motes of light. This Light-attuned variant carries one extra elemental feature, like a crest of elemental energy, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Insects & Arachnids|Insects & Arachnids]] · Insectoid |
| Variant of | [[Monsters/Insects & Arachnids/Venom Spider\|Venom Spider]] (elemental) |
| Rank · level | D+ · 56 (48–65) |
| Menace | 3 · Menacing |
| Element · weakness | Light · Dark |
| Size | 1.4 m |
| Behaviour | Swarm (swarm_surround) |
| HP · ATK · DEF · MATK · MDEF · SPD | 3642 · 234 · 187 · 164 · 187 · 135 |
| XP · gold | 1888 · 423 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/arachnid\|arachnid]] · `anim_octopod` |
| Habitats | [[Regions/Moraveil\|Moraveil]], [[Regions/Kitsune Isles\|Kitsune Isles]] |
| Genre | Classic Fantasy |
| Trope | Giant insects as low-floor threats; the arachne as an intelligent monster race |

**Field note:** Weak to Dark. Dangerous in numbers. Area attacks and chokepoints help.

## Motion implementation

- **Rig:** [[Systems/Rigs/arachnid|arachnid]] (rigId); animation set `anim_octopod`.
- **Dimensions:** 0.39 m high × 1.4 m long × 0.96 m wide; prefab scale 1.4.
- **Physics:** 86 kg, gravity ×1.26, poise 66, knockback resistance 0.26, death style `flip_legs_curl`.
- **Navigation:** speed 6.33 m/s, turn 507°/s, stopping distance 0.75 m.
- **Attack count:** 5; **signature:** green-striped legs and dripping fangs.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Fang Bite\|Fang Bite]] | melee | 1.1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Web Shot\|Web Shot]] | ranged | 0.5 | 8 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Ceiling Drop\|Ceiling Drop]] | dash | 1.7 | 12 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Silk Snare\|Silk Snare]] | ranged | 0.4 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Radiant Pulse\|Radiant Pulse]] | magic | 1.5 | 10 s | Light | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Gilded Spider is a **menacing insectoid** encountered at D+ rank, around level 56. Its documented behaviour is *Swarm* and its AI pattern is *swarm_surround*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Dark**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** green-striped legs and dripping fangs. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Moraveil|Moraveil]], [[Regions/Kitsune Isles|Kitsune Isles]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

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
| [[Regions/Moraveil\|Moraveil]] | 6 | C, D, D+, D-, C- | 40–76 | Day & Night |
| [[Regions/Kitsune Isles\|Kitsune Isles]] | 5 | D-, C+, C, D, C- | 40–86 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03551` | Moraveil Gilded Spider Alpha | [[Regions/Moraveil\|Moraveil]] | Alpha | C | 76 | 1.75 m | Day & Night | Like a typical Gilded Spider, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_03552` | Kitsune Isles Gilded Spider Runt | [[Regions/Kitsune Isles\|Kitsune Isles]] | Runt | D- | 40 | 0.98 m | Day & Night | Like a typical Gilded Spider, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_03553` | Kitsune Isles Gilded Spider Elderborn | [[Regions/Kitsune Isles\|Kitsune Isles]] | Elderborn | C+ | 86 | 1.89 m | Day & Night | Like a typical Gilded Spider, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_03554` | Moraveil Gilded Spider Juvenile | [[Regions/Moraveil\|Moraveil]] | Juvenile | D | 48 | 1.19 m | Day & Night | Like a typical Gilded Spider, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_03555` | Moraveil Gilded Spider | [[Regions/Moraveil\|Moraveil]] | Adult | D+ | 56 | 1.4 m | Day & Night | A typical adult Gilded Spider of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_03556` | Kitsune Isles Gilded Spider Alpha | [[Regions/Kitsune Isles\|Kitsune Isles]] | Alpha | C | 76 | 1.75 m | Day & Night | Like a typical Gilded Spider, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_03557` | Moraveil Gilded Spider Runt | [[Regions/Moraveil\|Moraveil]] | Runt | D- | 40 | 0.98 m | Day & Night | Like a typical Gilded Spider, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_03558` | Moraveil Gilded Spider Scarred | [[Regions/Moraveil\|Moraveil]] | Scarred | C- | 65 | 1.54 m | Day & Night | Like a typical Gilded Spider, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_03559` | Kitsune Isles Gilded Spider Juvenile | [[Regions/Kitsune Isles\|Kitsune Isles]] | Juvenile | D | 48 | 1.19 m | Day & Night | Like a typical Gilded Spider, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_03560` | Moraveil Gilded Spider Albino | [[Regions/Moraveil\|Moraveil]] | Albino | C- | 65 | 1.4 m | Day & Night | Like a typical Gilded Spider, but a rare pale form with white skin or fur and red eyes. |
| `pop_03561` | Kitsune Isles Gilded Spider Albino | [[Regions/Kitsune Isles\|Kitsune Isles]] | Albino | C- | 65 | 1.4 m | Day & Night | Like a typical Gilded Spider, but a rare pale form with white skin or fur and red eyes. |

## Design recipe

Rig `rig_octopod` · mesh `octopod_base` · material `chitin_gloss` · VFX `holy_motes` · palette `#fff3b0` `#ffd166` `#ffffff` · triangle-based silhouette, sharp asymmetric spikes
