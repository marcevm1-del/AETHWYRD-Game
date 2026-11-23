---
type: monster
id: mon_tide_arachne
family: "Insects & Arachnids"
rank: "A-"
tier: variant
tags: [monster, insects-arachnids]
---
# Tide Arachne

![[mon_tide_arachne_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_tide_arachne_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 20,000 tris · 3.368 × 3 × 1.816 m · local file `Game/Assets/_Game/Art/Models/Monsters/Insects & Arachnids/mon_tide_arachne.fbx`

> The Tide Arachne is a large creature with a squat, many-legged arachnid build, about 3 m long. Its chitin is rough, scarred and spiked, colored in blue-black. Its most striking feature is a woman's upper body rising from a spider's. It has burning slit pupils. An elegant crest and glowing veins of mana mark it as a champion of its kind. It circles its prey, surrounded by fine mist and droplets that orbit it. This Water-attuned variant carries one extra elemental feature, like element-scarred hide, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Insects & Arachnids|Insects & Arachnids]] · Insectoid |
| Variant of | [[Monsters/Insects & Arachnids/Arachne\|Arachne]] (elemental) |
| Rank · level | A- · 132 (120–146) |
| Menace | 3 · Menacing |
| Element · weakness | Water · Lightning |
| Size | 3 m |
| Behaviour | Swarm (swarm_surround) |
| HP · ATK · DEF · MATK · MDEF · SPD | 16896 · 538 · 430 · 377 · 430 · 135 |
| XP · gold | 7422 · 1399 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/arachnid\|arachnid]] · `anim_octopod` |
| Habitats | [[Regions/Moraveil\|Moraveil]], [[Regions/Hoshizora\|Hoshizora]], [[Regions/Kitsune Isles\|Kitsune Isles]] |
| Genre | Classic Fantasy |
| Trope | Giant insects as low-floor threats; the arachne as an intelligent monster race |

**Field note:** Weak to Lightning. Dangerous in numbers. Area attacks and chokepoints help.

## Motion implementation

- **Rig:** [[Systems/Rigs/arachnid|arachnid]] (rigId); animation set `anim_octopod`.
- **Dimensions:** 0.84 m high × 3 m long × 2.05 m wide; prefab scale 3.
- **Physics:** 935.6 kg, gravity ×1.4, poise 303, knockback resistance 0.35, death style `flip_legs_curl`.
- **Navigation:** speed 9.27 m/s, turn 346°/s, stopping distance 1.15 m.
- **Attack count:** 5; **signature:** a woman's upper body rising from a spider's.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Fang Bite\|Fang Bite]] | melee | 1.1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Web Shot\|Web Shot]] | ranged | 0.5 | 8 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Ceiling Drop\|Ceiling Drop]] | dash | 1.7 | 12 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Silk Snare\|Silk Snare]] | ranged | 0.4 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Tide Lash\|Tide Lash]] | magic | 1.5 | 10 s | Water | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Tide Arachne is a **menacing insectoid** encountered at A- rank, around level 132. Its documented behaviour is *Swarm* and its AI pattern is *swarm_surround*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Lightning**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a woman's upper body rising from a spider's. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Moraveil|Moraveil]], [[Regions/Hoshizora|Hoshizora]], [[Regions/Kitsune Isles|Kitsune Isles]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

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
| [[Regions/Moraveil\|Moraveil]] | 5 | B, B+, A+, A-, A | 108–159 | Day & Night |
| [[Regions/Hoshizora\|Hoshizora]] | 3 | B, B+, A- | 108–132 | Day & Night |
| [[Regions/Kitsune Isles\|Kitsune Isles]] | 3 | S-, A-, A | 132–173 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03595` | Moraveil Tide Arachne Runt | [[Regions/Moraveil\|Moraveil]] | Runt | B | 108 | 2.1 m | Day & Night | Like a typical Tide Arachne, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_03596` | Hoshizora Tide Arachne Runt | [[Regions/Hoshizora\|Hoshizora]] | Runt | B | 108 | 2.1 m | Day & Night | Like a typical Tide Arachne, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_03597` | Moraveil Tide Arachne Juvenile | [[Regions/Moraveil\|Moraveil]] | Juvenile | B+ | 120 | 2.55 m | Day & Night | Like a typical Tide Arachne, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_03598` | Moraveil Tide Arachne Alpha | [[Regions/Moraveil\|Moraveil]] | Alpha | A+ | 159 | 3.75 m | Day & Night | Like a typical Tide Arachne, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_03599` | Hoshizora Tide Arachne Juvenile | [[Regions/Hoshizora\|Hoshizora]] | Juvenile | B+ | 120 | 2.55 m | Day & Night | Like a typical Tide Arachne, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_03600` | Kitsune Isles Tide Arachne Elderborn | [[Regions/Kitsune Isles\|Kitsune Isles]] | Elderborn | S- | 173 | 4.05 m | Day & Night | Like a typical Tide Arachne, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_03601` | Moraveil Tide Arachne | [[Regions/Moraveil\|Moraveil]] | Adult | A- | 132 | 3 m | Day & Night | A typical adult Tide Arachne of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_03602` | Kitsune Isles Tide Arachne | [[Regions/Kitsune Isles\|Kitsune Isles]] | Adult | A- | 132 | 3 m | Day & Night | A typical adult Tide Arachne of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_03603` | Hoshizora Tide Arachne | [[Regions/Hoshizora\|Hoshizora]] | Adult | A- | 132 | 3 m | Day & Night | A typical adult Tide Arachne of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_03604` | Kitsune Isles Tide Arachne Albino | [[Regions/Kitsune Isles\|Kitsune Isles]] | Albino | A | 146 | 3 m | Day & Night | Like a typical Tide Arachne, but a rare pale form with white skin or fur and red eyes. |
| `pop_03605` | Moraveil Tide Arachne Scarred | [[Regions/Moraveil\|Moraveil]] | Scarred | A | 146 | 3.3 m | Day & Night | Like a typical Tide Arachne, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_octopod` · mesh `octopod_base` · material `chitin_gloss` · VFX `mist_droplets` · palette `#494b7f` `#36365c` `#4fa8e8` · triangle-based silhouette, sharp asymmetric spikes
